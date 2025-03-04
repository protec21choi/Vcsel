using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Concurrent;

using Define.DefineConstant;
using Define.DefineEnumProject.Serial;
using Serial_;

using FileIOManager_;
using FileComposite_;

namespace FrameOfSystem3.ExternalDevice.Serial
{
    class Homogenizer
    {
        #region Enum
        public enum EN_HOMOGENIZER_STATUS
        {
            WAIT,

            GET_ACTUAL_X,
            GET_ACTUAL_Y,

            INITIALIZE,
            MOVE,

            WAITING_READ,
        }
        public enum EN_HOMOGENIZER_COMMAND
        {
            DEFAULT,
            GET_POSITION_X,
            GET_POSITION_Y,

            SET_INITIALIZE,

            SET_MOVE,
        }
        public enum EN_HOMOGENIZER_AXIS
        {
            X = 0,
            Y
        }

        public enum EN_CALTABLE_ITEM
        {
            COUNT_X,
            VALUE_X,
            COUNT_Y,
            VALUE_Y,
        }
        #endregion
        #region 변수
        private int m_nInstanceIndex = 0;
        private int m_nSerialIndex = 0;
        private Config.ConfigSerial m_Serial = Config.ConfigSerial.GetInstance();
        private EN_HOMOGENIZER_STATUS                    m_enStatus;
        private ConcurrentQueue<EN_HOMOGENIZER_STATUS>   m_enCommandStatus;
        private double                  m_dblMovePositionX;
        private double                  m_dblMovePositionY;
        private double                  m_nMaxLimit = 300000;
        private EN_HOMOGENIZER_STATUS                                                           enLastStatus = EN_HOMOGENIZER_STATUS.GET_ACTUAL_X;

       // private List<Dictionary<EN_CALTABLE_ITEM, double>> m_lstofTable                         = new List<Dictionary<EN_CALTABLE_ITEM, double>>();
        Dictionary<EN_CALTABLE_ITEM, List<double>> m_dicOfTable                                 = new Dictionary<EN_CALTABLE_ITEM, List<double>>();
        private IPointXY                                                                        m_nPositionCount = new IPointXY();
        private DPointXY                                                                        m_dblPositionValue = new DPointXY();

        private bool                                                                            m_bMoveDoneX = true;
        private bool                                                                            m_bMoveDoneY = true;

        private bool                                                                            m_bInitialize = true;

        private string m_strCountX = string.Empty;
        private string m_strCountY = string.Empty;
        private string m_strRecieve = string.Empty;

        byte[] CR = new byte[1];
        byte[] LF = new byte[1];

        private int m_nObjectCode;

        private TickCounter_.TickCounter m_TickForTimeOut = new TickCounter_.TickCounter();
        private TickCounter_.TickCounter m_TickForDelay = new TickCounter_.TickCounter();

        #endregion

        #region 싱글톤
        private Homogenizer(int nIndex)
        {
            m_nInstanceIndex = nIndex;
        }
        private static List<Homogenizer> _Instance = null;
        public static Homogenizer GetInstance(int nIndex)
        {
            if (_Instance == null)
            {
                _Instance = new List<Homogenizer>();
            }
            while (_Instance.Count <= nIndex)
                _Instance.Add(new Homogenizer(nIndex));
            return _Instance[nIndex];
        }
        #endregion

        #region 속성
        /// <summary>
        /// Homogenizer 의 Actual Count 값을 가져온다.
        /// </summary>
        public IPointXY nPositionCount { get { return m_nPositionCount; } }
        /// <summary>
        /// Homogenizer 의 Actual Value 값을 가져온다.
        /// </summary>
        public DPointXY dblPositionValue { get { return m_dblPositionValue; } }
        public bool MoveDoneX { get { return m_bMoveDoneX; } }
        public bool MoveDoneY { get { return m_bMoveDoneY; } }
        public bool bInitialized { get { return m_bInitialize; } }
        public int nObjectCode { get { return m_nObjectCode; } set { m_nObjectCode = value; } }
        #endregion

        #region 외부 인터페이스
        #region 초기화 및 종료
        /// <summary>
        /// 2019.01.23 by ssh [ADD] 프로그램 가동 시 Homogenizer 초기화 함수입니다.
        /// </summary>
        public bool Init(int nIndex)
        {
            CR[0] = 0x0D;
            LF[0] = 0x0A;
            m_nSerialIndex = nIndex;

            m_enStatus = EN_HOMOGENIZER_STATUS.GET_ACTUAL_X;
            m_enCommandStatus = new ConcurrentQueue<EN_HOMOGENIZER_STATUS>();

            m_nObjectCode = m_nSerialIndex * 100;

            Load();

            if (m_Serial.Open(m_nSerialIndex) == false)
                return false;
            
            return true;
        }
        public void Close()
        {
            m_Serial.Close(m_nSerialIndex);
        }
    
        #endregion

        #region 주기 호출 함수
        public void Execute()
        {
            if (m_enCommandStatus == null)
                return;
            if (m_Serial.IsOpen(m_nSerialIndex) == false)
                return;

            EN_HOMOGENIZER_COMMAND eCommand = EN_HOMOGENIZER_COMMAND.DEFAULT;

            // 주기 호출 전 사용자 입력 호출이 있을 시 변경
            if (m_enCommandStatus.Count != 0)
            {
                if (m_enStatus < EN_HOMOGENIZER_STATUS.WAITING_READ)
                {
                    EN_HOMOGENIZER_STATUS eTrancition = EN_HOMOGENIZER_STATUS.WAIT;
                    m_enCommandStatus.TryDequeue(out eTrancition);
                    m_enStatus = eTrancition;
                }
            }

            switch (m_enStatus)
            {
                case EN_HOMOGENIZER_STATUS.GET_ACTUAL_X:
                    //if (m_tickDelayCount.isTimeOver())
                    {
                        eCommand = EN_HOMOGENIZER_COMMAND.GET_POSITION_X;
                        //m_tickDelayCount.SetTickTime(1000);

                        m_enStatus = EN_HOMOGENIZER_STATUS.WAITING_READ;
                    }
                    break;
                case EN_HOMOGENIZER_STATUS.GET_ACTUAL_Y:
                    //if (m_tickDelayCount.isTimeOver())
                    {
                        eCommand = EN_HOMOGENIZER_COMMAND.GET_POSITION_Y;
                      //  m_tickDelayCount.SetTickTime(1000);

                        m_enStatus = EN_HOMOGENIZER_STATUS.WAITING_READ;
                    }
                    break;

                case EN_HOMOGENIZER_STATUS.INITIALIZE:
                    m_bInitialize = false;

                    eCommand = EN_HOMOGENIZER_COMMAND.SET_INITIALIZE;
                    break;
            
                case EN_HOMOGENIZER_STATUS.MOVE:
                    eCommand = EN_HOMOGENIZER_COMMAND.SET_MOVE;
                    break;

                case EN_HOMOGENIZER_STATUS.WAITING_READ:
                    if (DataReceive())
                    {
                        if (!m_bInitialize)
                            eCommand = EN_HOMOGENIZER_COMMAND.SET_INITIALIZE;

                        break;
                    }
                    else
                    {
                        if (m_TickForTimeOut.IsTickOver(false))
                        {
                            m_enStatus = enLastStatus;
                            m_strCountX = "";
                            m_strCountY = "";
                            break;
                        }
                    }
                    break;
            }

            if (eCommand != EN_HOMOGENIZER_COMMAND.DEFAULT)
                ActionCommand(eCommand);
        }
        #endregion  

    
        #region 명령 함수
        public bool Initialize()
        {
            m_bInitialize = false;
            m_enCommandStatus.Enqueue(EN_HOMOGENIZER_STATUS.INITIALIZE);

            return true;
        }
        public bool MovePosition(DPointXY dblPosition)
        {
            if (0 > dblPosition.x)
                dblPosition.x = 0;
            if (m_nMaxLimit < dblPosition.x)
                dblPosition.x = m_nMaxLimit;

            if (0 > dblPosition.y)
                dblPosition.y = 0;
            if (m_nMaxLimit < dblPosition.y)
                dblPosition.y = m_nMaxLimit;

            m_dblMovePositionX = dblPosition.x;
            m_dblMovePositionY = dblPosition.y;

            m_bMoveDoneX = false;
            m_bMoveDoneY = false;
            m_enCommandStatus.Enqueue(EN_HOMOGENIZER_STATUS.MOVE);

            return true;
        }
        public bool SetMode()
        {
//             m_enCommandStatus.Enqueue(EN_HOMOGENIZER_STATUS.MODE_CHANGE_ANALOG);
//             m_enCommandStatus.Enqueue(EN_HOMOGENIZER_STATUS.TRANCITION_MODE_Y_WRITE);
            //enMode = eType;

            return true;
        }
        public bool SetInitDone(bool bValue)
        {
            m_bInitialize = bValue;
            return true;
        }
        #endregion

        #region 데이터 값 갱신
      
       
        #endregion

        #region 데이터 값 반환
        public bool IsOpened()
        {
            return m_Serial.IsOpen(m_nSerialIndex);
        }

        #endregion
        #endregion

        #region 내부 인터페이스
        #region 통신 인터페이스
        private bool DataReceive()
        {
            bool bReturn = false;
            string strResult = "";

            if (m_Serial.Read(m_nSerialIndex, ref strResult))
            {
                switch (enLastStatus)
                {
                    case EN_HOMOGENIZER_STATUS.GET_ACTUAL_X:
                        if (strResult == "")
                            break;
                        m_strCountX += strResult;
                        if (m_strCountX.Length > 10)
                            m_strCountX = string.Empty;
                        if (m_strCountX.Length > 2 
                            && m_strCountX.Remove(0, m_strCountX.Length - 2).Equals("\r\n"))
                        {
                            m_strCountX = m_strCountX.Replace("\r\n", string.Empty);

                            try
                            {
                                Int32.TryParse(m_strCountX, out m_nPositionCount.x);
                                m_dblPositionValue.x = GetConvertCountToValue(EN_HOMOGENIZER_AXIS.X, m_nPositionCount.x);
                            }
                            catch
                            {
                                m_enStatus = EN_HOMOGENIZER_STATUS.GET_ACTUAL_Y;
                                enLastStatus = EN_HOMOGENIZER_STATUS.GET_ACTUAL_Y;
                                break;
                            }

                            m_strCountX = "";
                            bReturn = true;
                        }
                        else
                        {
                            break;
                        }

                        m_enStatus = EN_HOMOGENIZER_STATUS.GET_ACTUAL_Y;
                        enLastStatus = EN_HOMOGENIZER_STATUS.GET_ACTUAL_Y;
                        break;
                    case EN_HOMOGENIZER_STATUS.GET_ACTUAL_Y:
                        if (strResult == "")
                            break;
                        m_strCountY += strResult;
                        if (m_strCountY.Length > 10)
                            m_strCountY = string.Empty;
                        if (m_strCountY.Length > 2 && m_strCountY.Remove(0, m_strCountY.Length - 2).Equals("\r\n"))
                        {
                            m_strCountY = m_strCountY.Replace("\r\n", string.Empty);

                            try
                            {
                                Int32.TryParse(m_strCountY, out m_nPositionCount.y);
                                m_dblPositionValue.y = GetConvertCountToValue(EN_HOMOGENIZER_AXIS.Y, m_nPositionCount.y);
                            }
                            catch
                            {
                                m_enStatus = EN_HOMOGENIZER_STATUS.GET_ACTUAL_X;
                                enLastStatus = EN_HOMOGENIZER_STATUS.GET_ACTUAL_X;
                                break;
                            }

                            m_strCountY = "";
                            bReturn = true;
                        }
                        else
                        {
                            break;
                        }

                        m_enStatus = EN_HOMOGENIZER_STATUS.GET_ACTUAL_X;
                        enLastStatus = EN_HOMOGENIZER_STATUS.GET_ACTUAL_X;
                        break;

                    case EN_HOMOGENIZER_STATUS.MOVE:
                        m_strRecieve += strResult;
                        m_strRecieve = m_strRecieve.Replace("\r\n", string.Empty);
                        if (m_strRecieve != "pp")
                            break;

                        m_bMoveDoneX = true;
                        m_bMoveDoneY = true;
                        bReturn = true;
                        m_strRecieve = string.Empty;
                        m_enStatus = EN_HOMOGENIZER_STATUS.GET_ACTUAL_X;
                        enLastStatus = EN_HOMOGENIZER_STATUS.GET_ACTUAL_X;
                        break;

                    case EN_HOMOGENIZER_STATUS.INITIALIZE:
                        //Console.WriteLine(strResult);
                        m_strRecieve += strResult;
                        m_strRecieve = m_strRecieve.Replace("\r\n", string.Empty);
                        if (m_strRecieve != "tt")
                            break;

                        m_bInitialize = true;
                        bReturn = true;
                        m_strRecieve = string.Empty;
                        m_enStatus = EN_HOMOGENIZER_STATUS.GET_ACTUAL_X;
                        enLastStatus = EN_HOMOGENIZER_STATUS.GET_ACTUAL_X;
                        break;
                }
            }

            return bReturn;
        }
        private bool ActionCommand(EN_HOMOGENIZER_COMMAND eCommand)
        {
            switch (eCommand)
            {
                case EN_HOMOGENIZER_COMMAND.GET_POSITION_X:
                    WriteCommand((int)EN_HOMOGENIZER_AXIS.X, "POS");
                    m_strCountX = "";
                    m_enStatus = EN_HOMOGENIZER_STATUS.WAITING_READ;
                    m_TickForTimeOut.SetTickCount(1000);

                    break;
                case EN_HOMOGENIZER_COMMAND.GET_POSITION_Y:
                    WriteCommand((int)EN_HOMOGENIZER_AXIS.Y, "POS");
                    m_strCountY = "";
                    m_enStatus = EN_HOMOGENIZER_STATUS.WAITING_READ;
                    m_TickForTimeOut.SetTickCount(1000);

                    break;
// 
//                 case EN_HOMOGENIZER_COMMAND.SET_MODE_X:
//                     switch (enMode)
//                     {
//                         case EN_LASER_SIZE_CONTROL_TYPE.INTERFACE:
//                             WriteCommand((int)EN_HOMOGENIZER_AXIS.X, "SOR", 0);
//                             WriteCommand((int)EN_HOMOGENIZER_AXIS.X, "STEPMOD");
//                             break;
//                         case EN_LASER_SIZE_CONTROL_TYPE.ANALOG:
//                             WriteCommand((int)EN_HOMOGENIZER_AXIS.X, "SOR", 1);
//                             WriteCommand((int)EN_HOMOGENIZER_AXIS.X, "APCMOD");
//                             break;
//                     }
// 
//                     m_enStatus = EN_HOMOGENIZER_STATUS.GET_ACTUAL_X;
//                     enLastStatus = EN_HOMOGENIZER_STATUS.GET_ACTUAL_X;
//                     break;
//                 case EN_HOMOGENIZER_COMMAND.SET_MODE_Y:
//                     switch (enMode)
//                     {
//                         case EN_LASER_SIZE_CONTROL_TYPE.INTERFACE:
//                             WriteCommand((int)EN_HOMOGENIZER_AXIS.Y, "SOR", 0);
//                             WriteCommand((int)EN_HOMOGENIZER_AXIS.Y, "STEPMOD");
//                             break;
//                         case EN_LASER_SIZE_CONTROL_TYPE.ANALOG:
//                             WriteCommand((int)EN_HOMOGENIZER_AXIS.Y, "SOR", 1);
//                             WriteCommand((int)EN_HOMOGENIZER_AXIS.Y, "APCMOD");
//                             break;
//                     }
// 
//                     m_enStatus = EN_HOMOGENIZER_STATUS.GET_ACTUAL_X;
//                     enLastStatus = EN_HOMOGENIZER_STATUS.GET_ACTUAL_X;
//                     break;
                case EN_HOMOGENIZER_COMMAND.SET_INITIALIZE:
                    WriteCommand((int)EN_HOMOGENIZER_AXIS.X, "ANSW1");
                    WriteCommand((int)EN_HOMOGENIZER_AXIS.X, "SHN4");
                    WriteCommand((int)EN_HOMOGENIZER_AXIS.X, "GOHOSEQ");
                     
                    WriteCommand((int)EN_HOMOGENIZER_AXIS.Y, "ANSW1");
                    WriteCommand((int)EN_HOMOGENIZER_AXIS.Y, "SHN4");
                    WriteCommand((int)EN_HOMOGENIZER_AXIS.Y, "GOHOSEQ");

                    m_strRecieve = string.Empty;

                    m_enStatus = EN_HOMOGENIZER_STATUS.WAITING_READ;
                    enLastStatus = EN_HOMOGENIZER_STATUS.INITIALIZE;
                    m_TickForTimeOut.SetTickCount(10000);

                    break;
                case EN_HOMOGENIZER_COMMAND.SET_MOVE:
                    WriteCommand((int)EN_HOMOGENIZER_AXIS.X, "EN");
                    WriteCommand((int)EN_HOMOGENIZER_AXIS.X, "LA" + ((int)m_dblMovePositionX).ToString());
                    WriteCommand((int)EN_HOMOGENIZER_AXIS.X, "V" + "5000");
                    WriteCommand((int)EN_HOMOGENIZER_AXIS.X, "ANSW1");
                    WriteCommand((int)EN_HOMOGENIZER_AXIS.X, "NP");
                    WriteCommand((int)EN_HOMOGENIZER_AXIS.X, "M");
                 
                    WriteCommand((int)EN_HOMOGENIZER_AXIS.Y, "EN");
                    WriteCommand((int)EN_HOMOGENIZER_AXIS.Y, "LA" + ((int)m_dblMovePositionY).ToString());
                    WriteCommand((int)EN_HOMOGENIZER_AXIS.Y, "V" + "5000");
                    WriteCommand((int)EN_HOMOGENIZER_AXIS.Y, "ANSW1");
                    WriteCommand((int)EN_HOMOGENIZER_AXIS.Y, "NP");
                    WriteCommand((int)EN_HOMOGENIZER_AXIS.Y, "M");

                    m_strRecieve = string.Empty;

                    m_enStatus = EN_HOMOGENIZER_STATUS.WAITING_READ;
                    enLastStatus = EN_HOMOGENIZER_STATUS.MOVE;
                    m_TickForTimeOut.SetTickCount(10000);
                    break;
            }

            return true;
        }
        private bool WriteCommand(int nNode, string strCommand, int nValue = -1)
        {
            string strData = "";

            strData = nNode.ToString();
            strData += strCommand;
            strData += nValue == -1 ? "" : nValue.ToString();
        //    strData += System.Text.Encoding.Default.GetString(CR);

            return m_Serial.Write(m_nSerialIndex, strData);

        }
        
        #endregion

        #region Table

        #region Get/Set
        public void GetTable(EN_HOMOGENIZER_AXIS enAxis, ref double[] arCount, ref double[] arValue)
        {
            if (enAxis == EN_HOMOGENIZER_AXIS.X)
            {
                if (m_dicOfTable.ContainsKey(EN_CALTABLE_ITEM.COUNT_X))
                    arCount = m_dicOfTable[EN_CALTABLE_ITEM.COUNT_X].ToArray();
                if (m_dicOfTable.ContainsKey(EN_CALTABLE_ITEM.VALUE_X))
                    arValue = m_dicOfTable[EN_CALTABLE_ITEM.VALUE_X].ToArray();
            }
            else
            {
                if (m_dicOfTable.ContainsKey(EN_CALTABLE_ITEM.COUNT_Y))
                    arCount = m_dicOfTable[EN_CALTABLE_ITEM.COUNT_Y].ToArray();
                if (m_dicOfTable.ContainsKey(EN_CALTABLE_ITEM.VALUE_Y))
                    arValue = m_dicOfTable[EN_CALTABLE_ITEM.VALUE_Y].ToArray();
            }
        }
        
        public void SetTableValue(EN_HOMOGENIZER_AXIS enAxis, int nIndex, int nCount, double dValue)
        {
            if(enAxis == EN_HOMOGENIZER_AXIS.X)
            {
                SetTableValue(nIndex, EN_CALTABLE_ITEM.COUNT_X, nCount);
                SetTableValue(nIndex, EN_CALTABLE_ITEM.VALUE_X, dValue);
            }
            else
            {
                SetTableValue(nIndex, EN_CALTABLE_ITEM.COUNT_Y, nCount);
                SetTableValue(nIndex, EN_CALTABLE_ITEM.VALUE_Y, dValue);
            }
            Save();
        }
        public void SetTableValue(int nIndex, EN_CALTABLE_ITEM enItem, double dblValue)
        {
            if (!m_dicOfTable.ContainsKey(enItem))
                m_dicOfTable.Add(enItem, new List<double>());

            while (m_dicOfTable[enItem].Count <= nIndex)
                m_dicOfTable[enItem].Add(0);

            m_dicOfTable[enItem][nIndex] = dblValue;

            Save();
        }
        #endregion

        #region 파일 입/출력 관련 함수
        public bool Save()
        {
            string strHomo = "HOMOGENIZER";
            FileComposite fComp = FileComposite.GetInstance();

            fComp.RemoveRoot(strHomo);
            if (!fComp.CreateRoot(strHomo))
                return false;

            foreach (var mItem in m_dicOfTable)
            {
                if (!fComp.AddGroup(strHomo, mItem.Key.ToString()))
                    return false;

                for (int i = 0; i < mItem.Value.Count; i++)
                    if (!fComp.AddItem(strHomo, i.ToString(), mItem.Value[i].ToString(), mItem.Key.ToString()))
                        return false;
            }

            FileIOManager fIO = FileIOManager.GetInstance();

            string sFilePath = Path.Combine(FilePath.FILEPATH_CONFIG);
            string sFileName = strHomo + m_nInstanceIndex.ToString() + FileFormat.FILEFORMAT_CONFIG;
            string sFileData = string.Empty;

            if (!fComp.GetStructureAsString(strHomo, ref sFileData))
                return false;

            fComp.RemoveRoot(strHomo);

            if (!fIO.Write(sFilePath, sFileName, sFileData, false, false))
                return false;


            return true;
        }
        // 파일에서 읽어온다.
        public bool Load()
        {
            string strHomo = "HOMOGENIZER";

            string sFilePath = Path.Combine(FilePath.FILEPATH_CONFIG);
            string sFileName = strHomo + m_nInstanceIndex.ToString() + FileFormat.FILEFORMAT_CONFIG;

            if (!System.IO.File.Exists(Path.Combine(sFilePath, sFileName)))
                return false;

            FileIOManager fIO = FileIOManager.GetInstance();

            string sFileData = string.Empty;

            if (!fIO.Read(sFilePath, sFileName, ref sFileData, FileIO.TIMEOUT_READ))
                return false;

            FileComposite fComp = FileComposite.GetInstance();

            string[] arData = sFileData.Split('\n');
            fComp.RemoveRoot(strHomo);

            if (!fComp.CreateRootByString(ref arData))
                return false;

            m_dicOfTable.Clear();
            string[] arGroupList = null;

            fComp.GetListOfGroup(strHomo, ref arGroupList);

            foreach (string sGroup in arGroupList)
            {
                EN_CALTABLE_ITEM enItem;
                if (Enum.TryParse(sGroup, out enItem))
                {
                    List<double> lstTable = new List<double>();
                    string[] arItemList = null;
                    if (fComp.GetListOfItem(strHomo, ref arItemList, sGroup))
                        for (int i = 0; i < arItemList.Length; i++)
                        {
                            double dValue = 0;
                            if (fComp.GetValue(strHomo, i.ToString(), ref dValue, sGroup))
                                lstTable.Add(dValue);
                        }
                    m_dicOfTable.Add(enItem, lstTable);
                }

            }
            return true;
        }
        #endregion


        #region Convert 함수
        private int GetConvertedCount(EN_HOMOGENIZER_AXIS enAxis, double dblValue)
        {
            List<double> lstValue = new List<double>();
            List<double> lstCount = new List<double>();
            double dblMinCount = 0.0;
            double dblMinValue = 0.0;
            double dblMaxCount = 0.0;
            double dblMaxValue = 0.0;

            switch (enAxis)
            {
                case EN_HOMOGENIZER_AXIS.X:
                    if (m_dicOfTable.ContainsKey(EN_CALTABLE_ITEM.COUNT_X))
                        lstCount = m_dicOfTable[EN_CALTABLE_ITEM.COUNT_X];
                    if (m_dicOfTable.ContainsKey(EN_CALTABLE_ITEM.VALUE_X))
                        lstValue = m_dicOfTable[EN_CALTABLE_ITEM.VALUE_X];
                    break;
                case EN_HOMOGENIZER_AXIS.Y:
                   if (m_dicOfTable.ContainsKey(EN_CALTABLE_ITEM.COUNT_Y))
                        lstCount = m_dicOfTable[EN_CALTABLE_ITEM.COUNT_Y];
                    if (m_dicOfTable.ContainsKey(EN_CALTABLE_ITEM.VALUE_Y))
                        lstValue = m_dicOfTable[EN_CALTABLE_ITEM.VALUE_Y];
                    break;
            }

            if (lstValue.Count == 0 || lstCount.Count == 0
                || lstValue.Count != lstCount.Count)
                return 0;

            for (int i = 0; i < lstValue.Count; i++)
            {

                if (i == lstValue.Count - 1)
                {
                    return (int)lstCount[i];
                }

                // Homogenizer Value 값은 Count 가 올라갈수록 Value 값이 낮아진다.
                if (lstValue[i + 1] < dblValue && dblValue <= lstValue[i])
                {
                    dblMinCount = lstCount[i + 1];
                    dblMinValue = lstValue[i + 1];
                    dblMaxCount = lstCount[i];
                    dblMaxValue = lstValue[i];

                    break;
                }
            }

            if (dblMinCount == 0.0 || dblMinValue == 0.0 || dblMaxCount == 0.0 || dblMaxValue == 0.0)
            {
                return (int)lstCount[0];
            }

            double dblCount = (((dblMaxCount - dblMinCount) / (dblMaxValue - dblMinValue)) * dblValue) + (dblMaxCount - (((dblMaxCount - dblMinCount) / (dblMaxValue - dblMinValue)) * dblMaxValue));
            return (int)dblCount;

        }
        public double GetConvertCountToValue(EN_HOMOGENIZER_AXIS enAxis, double dblCount)
        {
            List<double> lstValue = new List<double>();
            List<double> lstCount = new List<double>();

            double dblMinCount = 0.0;
            double dblMinValue = 0.0;
            double dblMaxCount = 0.0;
            double dblMaxValue = 0.0;

            switch (enAxis)
            {
                case EN_HOMOGENIZER_AXIS.X:
                    if (m_dicOfTable.ContainsKey(EN_CALTABLE_ITEM.COUNT_X))
                        lstCount = m_dicOfTable[EN_CALTABLE_ITEM.COUNT_X];
                    if (m_dicOfTable.ContainsKey(EN_CALTABLE_ITEM.VALUE_X))
                        lstValue = m_dicOfTable[EN_CALTABLE_ITEM.VALUE_X];
                    break;
                case EN_HOMOGENIZER_AXIS.Y:
                    if (m_dicOfTable.ContainsKey(EN_CALTABLE_ITEM.COUNT_Y))
                        lstCount = m_dicOfTable[EN_CALTABLE_ITEM.COUNT_Y];
                    if (m_dicOfTable.ContainsKey(EN_CALTABLE_ITEM.VALUE_Y))
                        lstValue = m_dicOfTable[EN_CALTABLE_ITEM.VALUE_Y];
                    break;
            }

            if (lstValue.Count == 0 || lstCount.Count == 0
                || lstValue.Count != lstCount.Count)
                return 0;
            int i = 0;
            for (i = 0; i < lstValue.Count; i++)
            {

                if (lstValue[i] == 0)
                    break;
                
                if (i == lstValue.Count - 1)
                {
                    return lstValue[i];
                }

                if (lstCount[i] < dblCount && dblCount <= lstCount[i + 1])
                {
                    dblMinCount = lstCount[i + 1];
                    dblMinValue = lstValue[i + 1];
                    dblMaxCount = lstCount[i];
                    dblMaxValue = lstValue[i];

                    break;
                }
            }



            if (dblMinCount == 0.0 || dblMinValue == 0.0 || dblMaxCount == 0.0 || dblMaxValue == 0.0)
            {
                if (dblCount > lstCount[0])
                    return lstValue[0];
                else
                    return lstValue[i - 1];
            }

            double dblValue = (dblCount - (dblMaxCount - (((dblMaxCount - dblMinCount) / (dblMaxValue - dblMinValue)) * dblMaxValue))) / ((dblMaxCount - dblMinCount) / (dblMaxValue - dblMinValue));
            return Math.Round(dblValue, 2);
       }
        #endregion

        #endregion
        #endregion
    }
}
