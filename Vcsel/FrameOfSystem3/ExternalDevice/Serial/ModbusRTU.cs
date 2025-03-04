using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Define.DefineConstant;
using Define.DefineEnumProject.Modbus;

using FileIOManager_;
using FileComposite_;

namespace FrameOfSystem3.ExternalDevice.Serial
{
 
    public enum EN_MODBUS_STATUS
    {
        WAITING_READ,
        SETTING_COMMAND,
    }
    
    class ModbusRTU
    {
        #region 변수
        private int m_nSerialIndex;
        private Config.ConfigSerial m_Serial = Config.ConfigSerial.GetInstance();
        private Dictionary<int, ModbusRTUDevice> m_dicOfModbus = new Dictionary<int, ModbusRTUDevice>();

        private int m_nObjectCode;
        private int m_nCurrentKey = -1;
        private byte[] m_bRecievedData = new byte[0];

        private TickCounter_.TickCounter m_TickForTimeOut = new TickCounter_.TickCounter();
        #endregion

        #region 싱글톤
        private ModbusRTU()
        {
           
        }
        private static Dictionary<int, ModbusRTU> _Instance = null;
        public static ModbusRTU GetInstance(int nIndex) 
        {
            if (_Instance == null)
            {
                _Instance = new Dictionary<int, ModbusRTU>();
            }
            if (!_Instance.ContainsKey(nIndex))
            {
                _Instance.Add(nIndex, new ModbusRTU());
            }
            return _Instance[nIndex];
        }
        #endregion

        #region 주기 호출 함수
        public void Execute()
        {
            if (m_Serial.IsOpen(m_nSerialIndex) == false
                || m_dicOfModbus.ContainsKey(m_nCurrentKey) == false)
                return;

            switch (m_dicOfModbus[m_nCurrentKey].enStatus)
            {
                case EN_MODBUS_STATUS.SETTING_COMMAND:
                    byte[] SendData = null;

                    m_dicOfModbus[m_nCurrentKey].GetSendCommand(ref SendData);

                    if (SendData != null)
                    {
                      
                        m_Serial.Write(m_nSerialIndex, SendData);
                        m_TickForTimeOut.SetTickCount(5000);
                        m_dicOfModbus[m_nCurrentKey].enStatus = EN_MODBUS_STATUS.WAITING_READ;
                    }
                    break;

                case EN_MODBUS_STATUS.WAITING_READ:
                    byte[] ReciveData = null;
                    if (DataReceived(ref ReciveData))
                    {
                        if (m_dicOfModbus.ContainsKey(ReciveData[0])
                           && m_dicOfModbus[ReciveData[0]].ParshingData(ReciveData))
                        {
                            m_dicOfModbus[m_nCurrentKey].enStatus = EN_MODBUS_STATUS.SETTING_COMMAND;
                            SetNextDevice();
                            break;
                        }
                    }
                    if (m_TickForTimeOut.IsTickOver(false))
                    {
                        m_bRecievedData = new byte[0];
                        m_dicOfModbus[m_nCurrentKey].enStatus = EN_MODBUS_STATUS.SETTING_COMMAND;
                        SetNextDevice();
                    }
                    break;
            }
        }
        #endregion

        #region 외부 인터페이스
        #region 초기화 및 종료
        public bool Init(int nIndexOfSerial)
        {
            m_nSerialIndex = nIndexOfSerial;

         
            if (m_Serial.Open(m_nSerialIndex) == false)
                return false;


            m_nObjectCode = m_nSerialIndex * 100;

            return true;
        }

        public void AddDevice(ModbusRTUDevice enDevice)
        {
            if (m_nCurrentKey == -1)
                m_nCurrentKey = enDevice.bSlaveID;
            m_dicOfModbus.Add(enDevice.bSlaveID, enDevice);

        }
        public void Close()
        {
            m_Serial.Close(m_nSerialIndex);
        }
        #endregion

        #region 아이템 값 반환
        /// <summary>
        /// 2018.08.31 by yjlee [ADD] 통신이 열린 상태인지 확인한다.
        /// </summary>
        public bool IsOpened()
        {
            return m_Serial.IsOpen(m_nSerialIndex);
        }
        #endregion
        #endregion

        #region 내부 인터페이스
        #region 통신 인터페이스
        private bool DataReceived(ref byte[] ReciveData)
        {
            byte[] Result = null;

            if (m_Serial.Read(m_nSerialIndex, ref Result))
            {
                byte[] buff = new byte[m_bRecievedData.Length];
                Array.Copy(m_bRecievedData, buff, buff.Length);
                m_bRecievedData = new byte[buff.Length + Result.Length];
                Array.Copy(buff, m_bRecievedData, buff.Length);
                Array.Copy(Result, 0, m_bRecievedData, buff.Length, Result.Length);

                if (m_bRecievedData.Length > 5)
                {
                    if (m_dicOfModbus.ContainsKey(m_bRecievedData[0])
                        && m_dicOfModbus[m_bRecievedData[0]].CheckRecieveData(m_bRecievedData))
                    {
                        ReciveData = m_bRecievedData;
                        m_bRecievedData = new byte[0];
                        return true;
                    }
                }
            }
            ReciveData = m_bRecievedData;
            return false;
        }
        #endregion

    

        private bool SetNextDevice()
        {
           
            bool CurrentKeyCheck = false;
            foreach (var modbus in m_dicOfModbus)
            {
                if (CurrentKeyCheck)
                {
                    m_nCurrentKey = modbus.Key;
                    return true;
                }
                if(modbus.Key == m_nCurrentKey)
                    CurrentKeyCheck = true;
            }

            List<int> list = new List<int>(m_dicOfModbus.Keys);
            m_nCurrentKey = list[0];
            return true;

        }
        #endregion

        #region 파일 입출력
//         /// <summary>
//         /// 2018.08.03 by yjlee [ADD] 알람 정보를 파일로 저장한다.
//         /// </summary>
//         private bool Save()
//          {
//              FileComposite fComp = FileComposite.GetInstance();
// 
//              fComp.RemoveRoot(m_strModbus);
//              if (!fComp.CreateRoot(m_strModbus))
//                  return false;
// 
//              foreach (var ModbusItem in m_dicOfModbus)
//              {
//                  if (!fComp.AddGroup(m_strModbus, ModbusItem.Key.ToString()))
//                      return false;
//                  if (!fComp.AddItem(m_strModbus, "DEVICE", ModbusItem.Value.enDevice.ToString(), ModbusItem.Key.ToString()))
//                      return false;
//                  if (!fComp.AddItem(m_strModbus, "SLAVE ID", ModbusItem.Value.bSlaveID.ToString(), ModbusItem.Key.ToString()))
//                      return false;
//              }
//              
//              FileIOManager fIO = FileIOManager.GetInstance();
// 
//              string sFilePath = FilePath.FILEPATH_CONFIG;
//              string sFileName = m_strModbus + FileFormat.FILEFORMAT_CONFIG;
//              string sFileData = string.Empty;
// 
//              if (!fComp.GetStructureAsString(m_strModbus, ref sFileData))
//                  return false;
// 
//              fComp.RemoveRoot(m_strModbus);
// 
//              if (!fIO.Write(sFilePath, sFileName, sFileData, false, false))
//                  return false;
// 
//             return true;
//         }
//         /// <summary>
//         /// 2018.08.03 by yjlee [ADD] 알람 정보를 파일로부터 읽어온다.
//         /// </summary>
//         private bool Load()
//         {
//             string strName = string.Empty;
//             string strType = string.Empty;
// 
//             string sFilePath = FilePath.FILEPATH_CONFIG;
//             string sFileName = m_strModbus + FileFormat.FILEFORMAT_CONFIG;
// 
//             if (!System.IO.File.Exists(Path.Combine(sFilePath, sFileName)))
//                 return false;
// 
//             FileIOManager fIO = FileIOManager.GetInstance();
// 
//             string sFileData = string.Empty;
// 
//             if (!fIO.Read(sFilePath, sFileName, ref sFileData, FileIO.TIMEOUT_READ))
//                 return false;
// 
//             FileComposite fComp = FileComposite.GetInstance();
// 
//             string[] arData = sFileData.Split('\n');
//             fComp.RemoveRoot(m_strModbus);
// 
//             if (!fComp.CreateRootByString(ref arData))
//                 return false;
// 
//             m_dicOfModbus.Clear();
// 
//             string[] arGroupList = null;
//             fComp.GetListOfGroup(m_strModbus, ref arGroupList);
// 
//             foreach (string sGroup in arGroupList)
//             {
//                 string strDevice = "";
//                 string strSlaveID = "";
//                 int nSlaveID = 0;
//                 if (!fComp.GetValue(m_strModbus, "DEVICE", ref strDevice, sGroup))
//                     return false;
//                 if (!fComp.GetValue(m_strModbus, "SLAVE ID", ref strSlaveID, sGroup))
//                     return false;
// 
//                 EN_MODEBUSRTU_DEVICE enDevice = (EN_MODEBUSRTU_DEVICE)Enum.Parse(typeof(EN_MODEBUSRTU_DEVICE), strDevice);
//                 if (int.TryParse(strSlaveID, out nSlaveID))
//                     continue;
// 
// //                switch (enDevice)
// //                {
// //                     case EN_MODEBUSRTU_DEVICE.CHILLER_DOTECH_CX9230:
// //                         ChillerCX9230Modbus m_ChillerModbus = new ChillerCX9230Modbus(Convert.ToByte(nSlaveID));
// //                         m_ChillerModbus.enDevice = EN_MODEBUSRTU_DEVICE.CHILLER_DOTECH_CX9230;
// //                         m_dicOfModbus.Add(nSlaveID, m_ChillerModbus);
// //                         break;
// //                }
// 
// 
//             }
// 
//             return true;
//         }
        #endregion
    }

    public class ModbusRTUDevice
    {
        #region 상수
        protected const byte Read_Coil = 1;
        protected const byte Read_Holding_Register = 3;
        protected const byte Read_Input_Register = 4;

        protected const byte Write_Single_Coil = 5;
        protected const byte Write_Multi_Coil = 15;
        protected const byte Write_Single_Register = 6;
        protected const byte Write_Multi_Register = 16;
        #endregion

        #region 변수
        private int m_nSerialIndex = 0;
        private byte m_bSlaveID;
        //private EN_MODEBUSRTU_DEVICE m_enDevice;

        private EN_MODBUS_STATUS m_enStatus = EN_MODBUS_STATUS.SETTING_COMMAND;

        protected byte m_nFunctionCode;
        protected ushort m_nRequestAddress;
        protected ushort m_nRequestCount;
        #endregion

        public ModbusRTUDevice(int SerialIndex ,byte SlaveID)
        {
            m_nSerialIndex = SerialIndex;
            m_bSlaveID = SlaveID;
        }

        #region 속성
        public byte bSlaveID { get { return m_bSlaveID; } }
        public int nSerialIndex { get { return m_nSerialIndex; } }
     
        public EN_MODBUS_STATUS enStatus { set { m_enStatus = value; } get { return m_enStatus; } }
        #endregion

        #region 가상 함수
        public virtual bool ParshingData(byte[] data)
        {
            return true;
        }
        public virtual void GetSendCommand(ref byte[] data)
        {

        }
        #endregion

        protected byte[] GetReadCommand(byte FunctionCode, ushort Address, ushort RequestCount)
        {
            m_nFunctionCode = FunctionCode;
            m_nRequestAddress = Address;
            m_nRequestCount = RequestCount;

            byte[] byteCmd = new byte[8];
            byteCmd[0] = bSlaveID;
            byteCmd[1] = FunctionCode;
            byteCmd[2] = (byte)((Address & 0xff00) >> 8);
            byteCmd[3] = (byte)(Address & 0xff);
            byteCmd[4] = (byte)((RequestCount & 0xff00) >> 8);
            byteCmd[5] = (byte)(RequestCount & 0xff);
            ushort usCRC = ModRTU_CRC(byteCmd, byteCmd.Length - 2);
            byteCmd[6] = (byte)((usCRC & 0xff00) >> 8);
            byteCmd[7] = (byte)(usCRC & 0xff);
            return byteCmd;
        }

        protected byte[] GetWriteSingleCommand(byte FunctionCode, ushort Address, bool bValue)
        {
            m_nFunctionCode = FunctionCode;
            m_nRequestAddress = Address;

            byte[] byteCmd = new byte[8];
            byteCmd[0] = bSlaveID;
            byteCmd[1] = FunctionCode;
            byteCmd[2] = (byte)((Address & 0xff00) >> 8);
            byteCmd[3] = (byte)(Address & 0xff);
            if (bValue)
                byteCmd[4] = 0xff;
            else
                byteCmd[4] = 0x00;
            byteCmd[5] = 0x00;
            ushort usCRC = ModRTU_CRC(byteCmd, byteCmd.Length - 2);
            byteCmd[6] = (byte)((usCRC & 0xff00) >> 8);
            byteCmd[7] = (byte)(usCRC & 0xff);
            return byteCmd;
        }

        protected byte[] GetWriteSingleCommand(byte FunctionCode, ushort Address, ushort nValue)
        {
            m_nFunctionCode = FunctionCode;
            m_nRequestAddress = Address;

            byte[] byteCmd = new byte[8];
            byteCmd[0] = bSlaveID;
            byteCmd[1] = FunctionCode;
            byteCmd[2] = (byte)((Address & 0xff00) >> 8);
            byteCmd[3] = (byte)(Address & 0xff);
            byteCmd[4] = (byte)((nValue & 0xff00) >> 8);
            byteCmd[5] = (byte)(nValue & 0xff);
            ushort usCRC = ModRTU_CRC(byteCmd, byteCmd.Length - 2);
            byteCmd[6] = (byte)((usCRC & 0xff00) >> 8);
            byteCmd[7] = (byte)(usCRC & 0xff);
            return byteCmd;
        }
        //MultiWrite는 추후에 생각하자

        //기본은 big endian이지만 little endian인 경우도 있다.Parsing은 각 Device 별로 하자 
        public bool CheckRecieveData(byte[] arRecieveData)
        {
            if (arRecieveData[0] != bSlaveID)
                return false;
            if (arRecieveData[1] != m_nFunctionCode)
                return false;
            if (!CheckCRC(arRecieveData, arRecieveData.Length))
                return false;

            switch (m_nFunctionCode)
            {
                case 1:
                case 2:
                    if (arRecieveData.Length - 5        // ID, Function Code, conunt,CRC 제외
                        != ((m_nRequestCount - 1) / 8) + 1) //Bit로 ON/OFF가 표시됨으로
                        return false;
                    break;

                case 3:
                case 4:
                    if(arRecieveData[2] != m_nRequestCount * 2) //byte 갯수
                        return false;
                    if (arRecieveData.Length - 5        // ID, Function Code, conunt, CRC 제외
                       != m_nRequestCount * 2)  //2byte 값으로 받는다.
                        return false;
                    break;
            }
            return true;
        }


        private ushort ModRTU_CRC(byte[] data, int nLen)
        {
            ushort remainder = 0xffff;

            for (int i = 0; i < nLen; i++)
            {
                remainder ^= (ushort)data[i];
                for (int j = 8; j != 0; j--)
                {
                    if ((remainder & 0x0001) != 0)
                    {
                        remainder >>= 1;
                        remainder ^= 0xA001;
                    }
                    else
                        remainder >>= 1;
                }
            }

            // byte swap
            byte high = (byte)((remainder & 0xff00) >> 8);
            byte low = (byte)(remainder & 0xff);

            remainder = (ushort)(low << 8 | high);

            return remainder;
        }
        private bool CheckCRC(byte[] data, int nLength)
        {
            bool rtn;

            ushort crcCal = ModRTU_CRC(data, nLength - 2);
            ushort crcData = (ushort)((data[nLength - 2] << 8) | data[nLength - 1]);

            if (crcCal == crcData) rtn = true;
            else rtn = false;

            return rtn;
        }
        
    }
}
