using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Define.DefineConstant;
using Define.DefineEnumBase.Log;
using FrameOfSystem3.ExternalDevice.Socket.IR_Property.Enumerable;
using FrameOfSystem3.ExternalDevice.Socket.IR_Property.Structures;
using FrameOfSystem3.Log;
using FrameOfSystem3.Recipe;
using RecipeManager_;
using Socket_;
using TickCounter_;

namespace FrameOfSystem3.ExternalDevice.Socket
{
    public class IR
    {
        #region SingleTon
        private IR() { }
        private static IR _Instance = null;
        public static IR GetInstance()
        {
            if (_Instance == null)
            {
                _Instance = new IR();
            }
            return _Instance;
        }
        #endregion

        #region Enumerable
        private enum EN_CONNECT_STATUS
        {
            NONE = 0,
            DISCONNECT,
            CONNECTING,
            CONNECTED,
        }

        public enum EN_IR_UNIT_STATUS
        {
            DISABLE = 0,
            SKIP = 1,
            REJECT = 2,
            WAIT = 3,
            ALIGN_DONE = 4,
            WORK_DONE = 5,

            LOW_TEMP = 6,
            TEMP_GROW_FAIL = 7,
            TEMP_DEVOVER = 8,
            HIGH_TEMP = 9,
            MAX_HIGH_TEMP = 10,

            EMG_LOW_TEMP = 11,
            EMG_HIGH_TEMP = 12,
        }
        #endregion

        #region Variables

        #region Common
        private int m_nSocketIndex = 0;

        private EN_COMMUNICATION_RESULT m_enCommResult = EN_COMMUNICATION_RESULT.NONE;
        private EN_COMMUNICATION_RESULT m_enAlwaysResult = EN_COMMUNICATION_RESULT.NONE;
        
        private EN_CONNECT_STATUS m_enStatus = EN_CONNECT_STATUS.NONE;

        private bool m_bUsedOption = false;

        private int m_nSeqNum = 0;
        private TickCounter m_tickTimeOut = new TickCounter();
        #endregion

        #region Work
        private int m_nCurrentWorkSequence = 1;

        #region Result
        private Dictionary<int, int> m_dicStatus = new Dictionary<int, int>();
        private Dictionary<int, double> m_dicPeakTemp = new Dictionary<int, double>();
        private Dictionary<int, double> m_dicSubIndexTemp = new Dictionary<int, double>();
        private int m_nRisingTime = 0;
        #endregion

        #endregion

        #region Instance
        private Socket_.Socket m_instanceSocket = Socket_.Socket.GetInstance();
        private Account_.Account m_instanceAccount = Account_.Account.GetInstance();

        private Recipe.Recipe m_instanceRecipe = Recipe.Recipe.GetInstance();
        private LogManager m_instanceLog = LogManager.GetInstance();

//         private Work.ReferanceMap.ReferanceMapManager m_ReferanceMap = Work.ReferanceMap.ReferanceMapManager.GetInstance();
//         private Work.WorkMap.WorkMapManager m_WorkMap = Work.WorkMap.WorkMapManager.GetInstance();
//         private Work.StatusMap m_StatusMap = Work.StatusMap.GetInstance();
        #endregion

        #endregion

        #region Property
        public Dictionary<int, int> ResultStatus { get { return m_dicStatus; } }
        public Dictionary<int, double> ResultPeakTemp { get { return m_dicPeakTemp; } }
        public Dictionary<int, double> ResultSubIndexTemp { get { return m_dicSubIndexTemp; } }

        public bool bUsedOption { get { return m_bUsedOption; } set { m_bUsedOption = value; } }
        public int nCurrentWorkSequence { get { return m_nCurrentWorkSequence; } set { m_nCurrentWorkSequence = value; } }
        #endregion

        #region External Interface

        #region Initialize & Exit
        public bool Init(int nSocketIndex)
        {
            m_nSocketIndex = nSocketIndex;

            m_instanceSocket.Connect(m_nSocketIndex);

            if (m_instanceSocket.GetState(m_nSocketIndex) == SOCKET_ITEM_STATE.DISCONNECTED)
                return false;

            m_enStatus = EN_CONNECT_STATUS.DISCONNECT;
           
            return true;
        }
        public void Exit()
        {
            m_instanceSocket.Disconnect(m_nSocketIndex);
        }

        public void InitSequence()
        {
            m_nSeqNum = 0;
        }
        #endregion

        #region Execute
        public void Execute()
        {
            switch (m_enStatus)
            {
                case EN_CONNECT_STATUS.DISCONNECT:
                    switch (m_instanceSocket.GetState(m_nSocketIndex))
                    {
                        case SOCKET_ITEM_STATE.READY:
                        case SOCKET_ITEM_STATE.DISCONNECTED:
                            break;
                    }

                    m_enStatus = EN_CONNECT_STATUS.CONNECTING;
                    break;
                case EN_CONNECT_STATUS.CONNECTING:
                    SendAccount();
                    SendRecipe();

                    m_enStatus = EN_CONNECT_STATUS.CONNECTED;
                    break;
                case EN_CONNECT_STATUS.CONNECTED:
                    switch (m_instanceSocket.GetState(m_nSocketIndex))
                    {
                        case SOCKET_ITEM_STATE.WAITING_RECEIVE:
                        case SOCKET_ITEM_STATE.CONNECTED:
                        case SOCKET_ITEM_STATE.TIMEOUT_RECEIVE:
                            break;
                        default:
                            m_enStatus = EN_CONNECT_STATUS.DISCONNECT;
                            break;
                    }

                    ParsingReceiveData();
                    break;
            }
        }
        #endregion 

        #region Command

        #region Manual Command
        public void ManualCommand(EN_SEND_TYPE enType)
        {
            SendManualCommand(enType);
        }
        #endregion

        #region Entry Sequence
        public EN_SEQUENCE_RESULT DoEntrySequence()
        {
            switch (m_nSeqNum)
            {
                case 0:
                    
                    m_nSeqNum++;
                    break;
                case 1:
                    if (false == m_bUsedOption)
                        m_nSeqNum = 1000;
                    else
                        m_nSeqNum++;

                    break;
                case 2:
                    if (m_enStatus != EN_CONNECT_STATUS.CONNECTED)
                        return EN_SEQUENCE_RESULT.DISCONNECT;

                    m_nSeqNum++;
                    break;
                case 3:
                    SendRecipe();

                    m_nSeqNum++;
                    break;
                case 4:
                    switch (m_enCommResult)
                    {
                        case EN_COMMUNICATION_RESULT.RECEIVING:
                            if (true == m_tickTimeOut.IsTickOver(false))
                                return EN_SEQUENCE_RESULT.TIME_OUT;

                            break;

                        case EN_COMMUNICATION_RESULT.SUCCESS:
                            m_nSeqNum++;
                            break;
                    }
                    break;
                case 5:
                    SendManualCommand(EN_SEND_TYPE.RUN_START);

                    m_nSeqNum++;
                    break;
                case 6:
//                     switch (m_enCommResult)
//                     {
//                         case EN_COMMUNICATION_RESULT.RECEIVING:
//                             if (true == m_tickTimeOut.IsTickOver(false))
//                                 return EN_SEQUENCE_RESULT.TIME_OUT;
// 
//                             break;
// 
//                         case EN_COMMUNICATION_RESULT.SUCCESS:
//                             m_nSeqNum++;
//                             break;
//                     }
                    m_nSeqNum++;
                    break;
                case 7:
                    m_nSeqNum = 1000;
                    break;

                case 1000:
                    m_nSeqNum = 0;
                    return EN_SEQUENCE_RESULT.OK;
            }

            return EN_SEQUENCE_RESULT.WORKING;
        }
        #endregion

        #region Work Ready
        public EN_SEQUENCE_RESULT DoWorkReady()
        {
            switch (m_nSeqNum)
            {
                case 0:
                    if (false == m_bUsedOption)
                        m_nSeqNum = 1000;
                    else
                        m_nSeqNum++;
                    break;
                case 1:
                    if (m_enStatus != EN_CONNECT_STATUS.CONNECTED)
                        return EN_SEQUENCE_RESULT.DISCONNECT;

                    m_nSeqNum++;
                    break;

                case 2:
                    SendManualCommand(EN_SEND_TYPE.SAVE_CAPACITY_CHECK);

                    m_nSeqNum++;
                    break;
                case 3:
                    switch (m_enCommResult)
                    {
                        case EN_COMMUNICATION_RESULT.RECEIVING:
                            if (true == m_tickTimeOut.IsTickOver(false))
                                return EN_SEQUENCE_RESULT.TIME_OUT;

                            break;

                        case EN_COMMUNICATION_RESULT.SUCCESS:
                            m_nSeqNum++;
                            break;
                        case EN_COMMUNICATION_RESULT.FULL_CAPACITY:
                            m_nSeqNum = 0;
                            return EN_SEQUENCE_RESULT.FULL_CAPACITY;
                    }
                    break;
                case 4:
                    SendHeadInformation();

                    m_nSeqNum++;
                    break;
                case 5:
                    switch (m_enCommResult)
                    {
                        case EN_COMMUNICATION_RESULT.RECEIVING:
                            if (true == m_tickTimeOut.IsTickOver(false))
                                return EN_SEQUENCE_RESULT.TIME_OUT;

                            break;

                        case EN_COMMUNICATION_RESULT.SUCCESS:
                            m_nSeqNum++;
                            break;
                    }

                    break;
                case 6:
                    m_nSeqNum = 1000;
                    break;

                case 1000:
                    m_nSeqNum = 0;
                    return EN_SEQUENCE_RESULT.OK;
            }

            return EN_SEQUENCE_RESULT.WORKING;
        }
        #endregion

        #region Unit Work Information
        public EN_SEQUENCE_RESULT DoWorkUnitInformation()
        {
            switch (m_nSeqNum)
            {
                case 0:
                    if (false == m_bUsedOption)
                        m_nSeqNum = 1000;
                    else
                        m_nSeqNum++;
                    break;
                case 1:
                    if (m_enStatus != EN_CONNECT_STATUS.CONNECTED)
                        return EN_SEQUENCE_RESULT.DISCONNECT;

                    m_nSeqNum++;
                    break;

                case 2:
                    SendUnitInformation();

                    m_nSeqNum++;
                    break;
                case 3:
                    switch (m_enCommResult)
                    {
                        case EN_COMMUNICATION_RESULT.RECEIVING:
                            if (true == m_tickTimeOut.IsTickOver(false))
                                return EN_SEQUENCE_RESULT.TIME_OUT;

                            break;

                        case EN_COMMUNICATION_RESULT.SUCCESS:
                            m_nSeqNum++;
                            break;
                    }
                    break;
                case 4:
                    m_nSeqNum = 1000;
                    break;

                case 1000:
                    m_nSeqNum = 0;
                    return EN_SEQUENCE_RESULT.OK;
            }

            return EN_SEQUENCE_RESULT.WORKING;
        }
        #endregion

        #region Work Start
        public EN_SEQUENCE_RESULT DoWorkStart()
        {
            switch (m_nSeqNum)
            {
                case 0:
                    if (false == m_bUsedOption)
                        m_nSeqNum = 1000;
                    else
                        m_nSeqNum++;
                    break;
                case 1:
                    if (m_enStatus != EN_CONNECT_STATUS.CONNECTED)
                        return EN_SEQUENCE_RESULT.DISCONNECT;

                    m_nSeqNum++;
                    break;

                case 2:
                    SendWorkStart();

                    m_nSeqNum++;
                    break;
                case 3:
                    switch (m_enCommResult)
                    {
                        case EN_COMMUNICATION_RESULT.RECEIVING:
                            if (true == m_tickTimeOut.IsTickOver(false))
                                return EN_SEQUENCE_RESULT.TIME_OUT;

                            break;

                        case EN_COMMUNICATION_RESULT.SUCCESS:
                            m_nSeqNum++;
                            break;
                    }
                    break;
                case 4:
                    m_nSeqNum = 1000;
                    break;

                case 1000:
                    m_nSeqNum = 0;
                    return EN_SEQUENCE_RESULT.OK;
            }

            return EN_SEQUENCE_RESULT.WORKING;
        }
        #endregion

        #region Work End
        public EN_SEQUENCE_RESULT DoWorkEnd()
        {
            switch (m_nSeqNum)
            {
                case 0:
                    if (false == m_bUsedOption)
                        m_nSeqNum = 1000;
                    else
                        m_nSeqNum++;
                    break;
                case 1:
                    if (m_enStatus != EN_CONNECT_STATUS.CONNECTED)
                        return EN_SEQUENCE_RESULT.DISCONNECT;

                    m_nSeqNum++;
                    break;

                case 2:
                    SendWorkEnd();

                    m_nSeqNum++;
                    break;
                case 3:
                    switch (m_enCommResult)
                    {
                        case EN_COMMUNICATION_RESULT.RECEIVING:
                            if (true == m_tickTimeOut.IsTickOver(false))
                                return EN_SEQUENCE_RESULT.TIME_OUT;

                            break;

                        case EN_COMMUNICATION_RESULT.SUCCESS:
                            m_nSeqNum++;
                            break;
                    }
                    break;
                case 4:
                    m_nSeqNum = 1000;
                    break;

                case 1000:
                    m_nSeqNum = 0;
                    return EN_SEQUENCE_RESULT.OK;
            }

            return EN_SEQUENCE_RESULT.WORKING;
        }
        #endregion

        #region Login
        public void Login()
        {
            SendAccount();
        }
        #endregion

        #region Recipe
        public void UpdateRecipe()
        {
            SendRecipe();
        }
        #endregion

        #endregion

        #endregion

        #region Internal Interface

        #region Send Data

        #region Command & Message

        #region Manual Command
        private void SendManualCommand(EN_SEND_TYPE enSendType)
        {
            SendCommonCommand sCommand = new SendCommonCommand();

            sCommand.nSendCommand = (int)enSendType;

            m_instanceLog.WriteCommunicationLog("IR"
                , EN_COMMUNICATION_TYPE.SEND
                , enSendType.ToString());

            m_enCommResult = EN_COMMUNICATION_RESULT.RECEIVING;
            SendMessage(sCommand);
        }
        #endregion

        #region Login
        private void SendAccount()
        {
            LoginInformation sLoginInformation = new LoginInformation(100, 100);
            string strLoginedID = m_instanceAccount.GetLoginedID();
            string strLoginedLevel = m_instanceAccount.GetLoginedAuthority().ToString();
                
            Array.Copy(strLoginedID.ToCharArray()
                , sLoginInformation.ID
                , strLoginedID.ToCharArray().Length);
            Array.Copy(strLoginedLevel.ToCharArray()
                , sLoginInformation.Level
                , strLoginedLevel.ToCharArray().Length);

            string strMessage = string.Format("ID : {0} Level : {1}"
                , strLoginedID
                , strLoginedLevel);

            m_instanceLog.WriteCommunicationLog("IR"
                , EN_COMMUNICATION_TYPE.SEND
                , strMessage);

            m_enCommResult = EN_COMMUNICATION_RESULT.RECEIVING;
            SendMessage(sLoginInformation);
        }
        #endregion

        #region Recipe
        private void SendRecipe()
        {
            RecipeInformation sRecipeInformation = new RecipeInformation(200, 200);
            string strFilePath = m_instanceRecipe.GetValue(EN_RECIPE_TYPE.COMMON
                , PARAM_COMMON.PROCESS_FILE_PATH.ToString()
                , 0
                , EN_RECIPE_PARAM_TYPE.VALUE
                , string.Empty);
            string strFileName = m_instanceRecipe.GetValue(EN_RECIPE_TYPE.COMMON
                , PARAM_COMMON.PROCESS_FILE_NAME.ToString()
                , 0
                , EN_RECIPE_PARAM_TYPE.VALUE
                , string.Empty);

            
            strFilePath = strFilePath.Replace("D:\\PROTECDB", "");

            strFilePath = ""; //Online RMS 대응 때문에 로컬 고정으로 쓰자.추후 고민
            strFileName = System.IO.Path.GetFileNameWithoutExtension(strFileName);
            Array.Copy(strFilePath.ToCharArray()
                , sRecipeInformation.FilePath
                , strFilePath.ToCharArray().Length);
            Array.Copy(strFileName.ToCharArray()
                , sRecipeInformation.FileName
                , strFileName.ToCharArray().Length);

            string strMessage = string.Format("FilePath : {0} FileName : {1}"
                , strFilePath
                , strFileName);

            m_instanceLog.WriteCommunicationLog("IR"
            , EN_COMMUNICATION_TYPE.SEND
            , strMessage);

            m_enCommResult = EN_COMMUNICATION_RESULT.RECEIVING;
            SendMessage(sRecipeInformation);
        }
        #endregion

        #region Head Information
        private void SendHeadInformation()
        {
            HeadWorkInformation sHeadWorkInformation = new HeadWorkInformation(200);
 
            string strSubstrateID = "WORK";
            strSubstrateID += String.Format("_{0:0000}{1:00}{2:00}{3:00}{4:00}{5:00}{6:000}",
                       DateTime.Now.Year,
                       DateTime.Now.Month,
                       DateTime.Now.Day,
                       DateTime.Now.Hour,
                       DateTime.Now.Minute,
                       DateTime.Now.Second,
                       DateTime.Now.Millisecond);
            Array.Copy(strSubstrateID.ToCharArray()
                , sHeadWorkInformation.SubstrateId
                , strSubstrateID.ToCharArray().Length);
            Array.Resize(ref sHeadWorkInformation.SubstrateId, 200);

            string strSubstrateStatus = "0";
            sHeadWorkInformation.WorkMap = strSubstrateStatus.ToCharArray();
            Array.Resize(ref sHeadWorkInformation.WorkMap, 200);

            sHeadWorkInformation.TotalWorkCount = 1;

            sHeadWorkInformation.ShotInUnitCount = 1;
            int UnitCountX = 1;
            int UnitCountY = 1;
            int GroupCountX = 1;
            int GroupCountY = 1;
            sHeadWorkInformation.XCount = UnitCountX * GroupCountX;
            sHeadWorkInformation.YCount = UnitCountY * GroupCountY;
           
            sHeadWorkInformation.HistoryPath = ("NONE").ToCharArray();
            Array.Resize(ref sHeadWorkInformation.HistoryPath, 100);

            sHeadWorkInformation.LotID = ("NONE").ToCharArray();
            Array.Resize(ref sHeadWorkInformation.LotID, 100);

            sHeadWorkInformation.PartID = ("NONE").ToCharArray();
            Array.Resize(ref sHeadWorkInformation.PartID, 100);

            string strEquipID = "PLR 100";
            sHeadWorkInformation.EquipmentID = strEquipID.ToCharArray();
            Array.Resize(ref sHeadWorkInformation.EquipmentID, 100);

            string strMessage = string.Format("HEAD Info - ID : {0}"
                , strSubstrateID);

            m_instanceLog.WriteCommunicationLog("IR"
                , EN_COMMUNICATION_TYPE.SEND
                , strMessage);

            m_enCommResult = EN_COMMUNICATION_RESULT.RECEIVING;
            SendMessage(sHeadWorkInformation);
        }
        #endregion

        #region Unit Information
        private void SendUnitInformation()
        {
            UnitWorkInformation sWorkInformation = new UnitWorkInformation(100);
            sWorkInformation.ShotNumber = 1;
            sWorkInformation.ArrayX = 1;
            sWorkInformation.ArrayY = 1;

            int UnitCountX = 1;
            int GroupCountX = 1;
           int countX = UnitCountX * GroupCountX;
            int nIndexX = ((m_nCurrentWorkSequence - 1) % countX) + 1;
            int nIndexY = ((m_nCurrentWorkSequence - 1) / countX) + 1;

            sWorkInformation.PCBIndexX[0] = nIndexX;
            sWorkInformation.PCBIndexY[0] = nIndexY;

            sWorkInformation.Status[0] =  1;
            
            sWorkInformation.UnitIndex[0] = m_nCurrentWorkSequence;

            sWorkInformation.bLastVariable = false;
            sWorkInformation.bVariableUsed = false;
            sWorkInformation.nVariable = 1;

            string strMessage = string.Format("UNIT Info - Sequence : {0}, ArrayX : {1}, ArrayY : {2}"
                , sWorkInformation.ShotNumber
                , sWorkInformation.ArrayX
                , sWorkInformation.ArrayY);

            m_instanceLog.WriteCommunicationLog("IR"
                , EN_COMMUNICATION_TYPE.SEND
                , strMessage);

            m_enCommResult = EN_COMMUNICATION_RESULT.RECEIVING;
            SendMessage(sWorkInformation);
        }
        #endregion

        #region Work Start
        private void SendWorkStart()
        {
            m_dicStatus.Clear();
            m_dicPeakTemp.Clear();
            m_dicSubIndexTemp.Clear();
            m_nRisingTime = 0;

            SendManualCommand(EN_SEND_TYPE.WORK_START);
        }
        #endregion

        #region Work End
        private void SendWorkEnd()
        {
            SendManualCommand(EN_SEND_TYPE.WORK_END);
        }
        #endregion

        #endregion

        #region Send Message
        private void SendMessage(object oMessage)
        {
            byte[] arSendMessage = StructureToByte(oMessage);

            m_instanceSocket.Send(m_nSocketIndex, arSendMessage);

            m_tickTimeOut.SetTickCount(30000);
        }
        #endregion

        #region Transrate
        private byte[] StructureToByte(object obj)
        {
            try
            {
                int datasize = Marshal.SizeOf(obj);//((PACKET_DATA)obj).TotalBytes; // 구조체에 할당된 메모리의 크기를 구한다.
                IntPtr buff = Marshal.AllocHGlobal(datasize); // 비관리 메모리 영역에 구조체 크기만큼의 메모리를 할당한다.
                Marshal.StructureToPtr(obj, buff, true); // 할당된 구조체 객체의 주소를 구한다.
                byte[] data = new byte[datasize]; // 구조체가 복사될 배열
                Marshal.Copy(buff, data, 0, datasize); // 구조체 객체를 배열에 복사
                Marshal.FreeHGlobal(buff); // 비관리 메모리 영역에 할당했던 메모리를 해제함
                return data; // 배열을 리턴
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #endregion

        #region Receive Data

        #region Parsing
        private void ParsingReceiveData()
        {
            byte[] arReceivedData = null;
            if (false == m_instanceSocket.Receive(m_nSocketIndex, ref arReceivedData))
                return;
            
            string strLogMessage = string.Empty;

            if (ByteToStructure(arReceivedData, typeof(ReceiveCommonCommand)) != null)
            {
                ReceiveCommonCommand rCommand = (ReceiveCommonCommand)ByteToStructure(arReceivedData, typeof(ReceiveCommonCommand));

                EN_RECEIVE_TYPE enType = (EN_RECEIVE_TYPE)rCommand.nReceiveCommand;

                m_instanceLog.WriteCommunicationLog("IR"
                    , EN_COMMUNICATION_TYPE.RECIEVE
                    , enType.ToString());

                ReceiveDataToProcess(enType);
            }
            else if (ByteToStructure(arReceivedData, typeof(WorkResultInformation)) != null)
            {
                WorkResultInformation rResult = (WorkResultInformation)ByteToStructure(arReceivedData, typeof(WorkResultInformation));
                
                strLogMessage = String.Format("SHOT RESULT - Shot Number : {0} / Status : {1}"
                    , rResult.nShotNumber
                    , string.Concat(rResult.nWorkResult));
                m_instanceLog.WriteCommunicationLog("IR"
                    , EN_COMMUNICATION_TYPE.RECIEVE
                    , strLogMessage);

                ReceiveDataToResult(rResult);
            }
            else if (ByteToStructure(arReceivedData, typeof(JCETWorkResultInformation)) != null)
            {
                JCETWorkResultInformation rResult = (JCETWorkResultInformation)ByteToStructure(arReceivedData, typeof(JCETWorkResultInformation));

                strLogMessage = String.Format("SHOT RESULT - Shot Number : {0} / Status : {1}"
                    , rResult.nShotNumber
                    , string.Concat(rResult.nWorkResult));
                m_instanceLog.WriteCommunicationLog("IR"
                    , EN_COMMUNICATION_TYPE.RECIEVE
                    , strLogMessage);

                ReceiveDataToResult(rResult);
            }
        }
        #endregion

        #region Receive Command

        #region Common Command
        private void ReceiveDataToProcess(EN_RECEIVE_TYPE enType)
        {
            switch (enType)
            {
                #region Receive
                case EN_RECEIVE_TYPE.EMPTY_SAVE_DRIVE:
                case EN_RECEIVE_TYPE.RECEIVE_COMPLETE:
                case EN_RECEIVE_TYPE.HEADINFORMATION_COMPLETE:
                case EN_RECEIVE_TYPE.WORKINFORMATION_COMPLETE:
                case EN_RECEIVE_TYPE.LASERINFORMATION_COMPLETE:
                case EN_RECEIVE_TYPE.WORKSTART_COMPLETE:
                    m_enCommResult = EN_COMMUNICATION_RESULT.SUCCESS;
                    break;

                case EN_RECEIVE_TYPE.FULL_SAVE_DRIVE:
                    m_enCommResult = EN_COMMUNICATION_RESULT.FULL_CAPACITY;
                    break;

                case EN_RECEIVE_TYPE.EXIST_ID_SEQUENCE:
                    m_enCommResult = EN_COMMUNICATION_RESULT.EXIST_ID;
                    break;
                case EN_RECEIVE_TYPE.RECEIVE_FAIL:
                    m_enCommResult = EN_COMMUNICATION_RESULT.FAIL;
                    break;
                #endregion

                #region Always Receive
                case EN_RECEIVE_TYPE.CAMERA_DISCONNECT:
                    m_enAlwaysResult = EN_COMMUNICATION_RESULT.CAMERA_DISCONNECT;
                    break;
                case EN_RECEIVE_TYPE.CAMERA_CONNECT:
                    m_enAlwaysResult = EN_COMMUNICATION_RESULT.NONE;
                    break;
                case EN_RECEIVE_TYPE.WORKING_EMG_TEMP:
                    m_enAlwaysResult = EN_COMMUNICATION_RESULT.WORKING_EMERGENCY_TEMP;
                    break;
                #endregion

                #region Receive And Reply
                case EN_RECEIVE_TYPE.LOGIN:
                    SendAccount();
                    break;
                case EN_RECEIVE_TYPE.RECIPE:
                    SendRecipe();
                    break;
                #endregion
            }
        }
        #endregion

        #region Work Result
        private void ReceiveDataToResult(WorkResultInformation rResult)
        {
            m_dicStatus.Clear();
            m_dicPeakTemp.Clear();
            m_dicSubIndexTemp.Clear();
            m_nRisingTime = 0;

            for (int i = 0; i < rResult.nWorkResult.Length; i++)
            {
                m_dicStatus.Add(i, rResult.nWorkResult[i]);
            }
            for (int i = 0; i < rResult.dPeakTemp.Length; i++)
            {
                m_dicPeakTemp.Add(i, rResult.dPeakTemp[i]);
            }
            m_nRisingTime = rResult.nRisingTime;

            m_enCommResult = EN_COMMUNICATION_RESULT.SUCCESS;
        }
        private void ReceiveDataToResult(JCETWorkResultInformation rResult)
        {
            m_dicStatus.Clear();
            m_dicPeakTemp.Clear();
            m_dicSubIndexTemp.Clear();
            m_nRisingTime = 0;

            for (int i = 0; i < rResult.nWorkResult.Length; i++)
            {
                m_dicStatus.Add(i, rResult.nWorkResult[i]);
            }
            for (int i = 0; i < rResult.dPeakTemp.Length; i++)
            {
                m_dicPeakTemp.Add(i, rResult.dPeakTemp[i]);
            }
            for (int i = 0; i < rResult.dSubIndexTemp.Length; i++)
            {
                m_dicSubIndexTemp.Add(i, rResult.dSubIndexTemp[i]);
            }
            m_nRisingTime = rResult.nRisingTime;

            m_enCommResult = EN_COMMUNICATION_RESULT.SUCCESS;
        }
        #endregion

        #endregion

        #region Transrate
        private object ByteToStructure(byte[] data, Type type)
        {
            try
            {
                IntPtr buff = Marshal.AllocHGlobal(data.Length);                // 배열의 크기만큼 비관리 메모리 영역에 메모리를 할당한다.
                Marshal.Copy(data, 0, buff, data.Length);                       // 배열에 저장된 데이터를 위에서 할당한 메모리 영역에 복사한다.
                object obj = Marshal.PtrToStructure(buff, type);                // 복사된 데이터를 구조체 객체로 변환한다.
                Marshal.FreeHGlobal(buff);                                      // 비관리 메모리 영역에 할당했던 메모리를 해제함
                if (Marshal.SizeOf(obj) != data.Length)                         // (((PACKET_DATA)obj).TotalBytes != data.Length) // 구조체와 원래의 데이터의 크기 비교
                {
                    return null;                                                // 크기가 다르면 null 리턴
                }
                return obj;                                                     // 구조체 리턴
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #endregion

        #region Parse Data Structure
        //private static T ByteToStruct<T>(byte[] buffer) where T : struct
        //{
        //    int size = Marshal.SizeOf(typeof(T));
        //    if (size > buffer.Length)
        //    {
        //        throw new Exception();
        //    }
        //    IntPtr ptr = Marshal.AllocHGlobal(size);
        //    Marshal.Copy(buffer, 0, ptr, size);
        //    T obj = (T)Marshal.PtrToStructure(ptr, typeof(T));
        //    Marshal.FreeHGlobal(ptr);
        //    return obj;
        //}
        private string ByteToString(byte[] strByte)
        {
            string str = Encoding.Default.GetString(strByte);
            return str;
        }
        private byte[] StringToByte(string str)
        {
            byte[] StrByte = Encoding.UTF8.GetBytes(str);
            return StrByte;
        }
        #endregion

        #endregion
    }

    namespace IR_Property
    {
        namespace Enumerable
        {
            public enum EN_SEQUENCE_RESULT
            {
                OK,
                WORKING,
                STOP,

                // ERROR
                DISCONNECT,

                FULL_CAPACITY,
                CAMERA_DISCONNECT,
                WORKING_EMERGENCY_TEMP,

                FAIL,
                TIME_OUT,
                EXIST_ID,
            }

            public enum EN_COMMUNICATION_RESULT
            {
                NONE,
                RECEIVING,
                
                FAIL,
                TIME_OUT,
                EXIST_ID,

                FULL_CAPACITY,
                CAMERA_DISCONNECT,
                WORKING_EMERGENCY_TEMP,

                SUCCESS,
            }
            public enum EN_RECEIVE_TYPE
            {
                NONE = 0,
                RECIPE = 1,
                CHANGE_RECIPE = 2,
                CURRENT_TIME = 3,
                WORK_RESULT = 4,
                LOGIN = 5,
                EMPTY_SAVE_DRIVE = 6,
                FULL_SAVE_DRIVE = 7,
                WORKING_EMG_TEMP = 8,

                EXIST_ID_SEQUENCE = 9,

                RECEIVE_FAIL = 10,       // 2019.05.01 by junho [ADD] Add the IR Receive Fail
                RECEIVE_COMPLETE = 11,

                HEADINFORMATION_COMPLETE = 12,
                WORKINFORMATION_COMPLETE = 13,
                LASERINFORMATION_COMPLETE = 14,

                WORKSTART_COMPLETE = 15,
                JCET_WORK_RESULT = 16,

                CAMERA_DISCONNECT = 17,
                CAMERA_CONNECT = 18,
            }
            public enum EN_SEND_TYPE
            {
                NONE = 0,
                CURRENT_RECIPE = 1,
                CURRENT_TIME = 2,
                CURRENT_HEAD_WORK_INFORMATION = 3,
                CURRENT_WORK_INFORMATION = 4,
                WORK_START = 5,
                WORK_END = 6,
                WORK_FINISH = 7,
                WORK_RESULT = 8,
                LIVE_START = 9,
                LIVE_STOP = 10,
                LOG_SAVE_START = 11,
                LOG_SAVE_STOP = 12,
                AUTO_FOCUS = 13,
                LOGIN = 14,
                NUC_ACTION = 15,
                SAVE_CAPACITY_CHECK = 16,

                RUN_START = 19,
                RUN_STOP = 20,

                DEVICE_MEASURE_INFORMATION = 21,
                DEVICE_MEASURE_START = 22,
                DEVICE_MEASURE_STOP = 23,
            }
        }
        namespace Structures
        {
            #region Recive

            #region Common

            public struct ReceiveCommonCommand
            {
                public int nReceiveCommand;

                public ReceiveCommonCommand(int ReceiveCommand)
                {
                    nReceiveCommand = ReceiveCommand;
                }
            }

            #endregion

            #region Work Result
            public struct WorkResultInformation
            {
                public int nShotNumber;
                public int nRisingTime;

                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
                public double[] dPeakTemp;

                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
                public int[] nWorkResult;

                public WorkResultInformation(int ShotNumber, int RisingTime, int[] WorkResult, double[] PeakTemp)
                {
                    nShotNumber = ShotNumber;
                    nRisingTime = RisingTime;
                    nWorkResult = WorkResult;
                    dPeakTemp = PeakTemp;
                }
            }
            #endregion

            #region JCET Work Result

            public struct JCETWorkResultInformation
            {
                public int nShotNumber;
                public int nRisingTime;

                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
                public double[] dPeakTemp;

                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
                public double[] dSubIndexTemp;

                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
                public int[] nWorkResult;

                public JCETWorkResultInformation(int ShotNumber, int RisingTime, int[] WorkResult, double[] PeakTemp,
                    double[] SubIndexTemp)
                {
                    nShotNumber = ShotNumber;
                    nRisingTime = RisingTime;
                    nWorkResult = WorkResult;
                    dPeakTemp = PeakTemp;
                    dSubIndexTemp = SubIndexTemp;
                }
            }

            #endregion

            #endregion

            #region Send

            #region Common

            public struct SendCommonCommand
            {
                public int nSendCommand;
            }

            #endregion

            #region Login Information

            public struct LoginInformation
            {
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
                public char[] ID;

                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
                public char[] Level;

                public LoginInformation(int Id, int Level)
                {
                    ID = new char[100];
                    this.Level = new char[100];
                }
            }

            #endregion

            #region Recipe Information

            public struct RecipeInformation
            {
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 200)]
                public char[] FilePath;

                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 200)]
                public char[] FileName;

                public RecipeInformation(int PathLengh, int NameLengh)
                {
                    FilePath = new char[200];
                    FileName = new char[200];
                }
            }

            #endregion

            #region Head Work Information

            public struct HeadWorkInformation
            {
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 200)]
                public char[] SubstrateId;

                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 200)]
                public char[] WorkMap;

                //             [MarshalAs(UnmanagedType.ByValArray, SizeConst = 200)]
                //             public char[] strArrayInformation;
                public int TotalUnitCount;
                public int XCount;
                public int YCount;
                public int TotalWorkCount;
                public int ShotInUnitCount;
                public int nSubROICount;

                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
                public char[] HistoryPath;

                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
                public char[] LotID;

                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
                public char[] EquipmentID;

                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
                public char[] PartID;


                public HeadWorkInformation(int ArraySize)
                {
                    SubstrateId = new char[100];
                    WorkMap = new char[100];
                    //   strArrayInformation = new char[ArraySize];
                    TotalUnitCount = 0;
                    XCount = 0;
                    YCount = 0;
                    TotalWorkCount = 0;
                    ShotInUnitCount = 0;
                    nSubROICount = 0;
                    HistoryPath = new char[100];
                    LotID = new char[100];
                    PartID = new char[100];
                    EquipmentID = new char[100];
                }
            }

            #endregion

            #region Unit Work Information

            public struct UnitWorkInformation
            {
                public int ShotNumber;
                public int ArrayX;
                public int ArrayY;

                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
                public int[] PCBIndexX;

                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
                public int[] PCBIndexY;

                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
                public int[] Status;

                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
                public int[] UnitIndex;

                public bool bLastVariable;
                public bool bVariableUsed;
                public int nVariable;

                public UnitWorkInformation(int ArrayCount)
                {
                    ShotNumber = 0;
                    ArrayX = 0;
                    ArrayY = 0;


                    PCBIndexX = new int[ArrayCount];
                    PCBIndexY = new int[ArrayCount];
                    Status = new int[ArrayCount];
                    UnitIndex = new int[ArrayCount];

                    bLastVariable = true;
                    bVariableUsed = false;
                    nVariable = 0;
                }
            }

            #endregion

            #endregion
        }
    }
}
