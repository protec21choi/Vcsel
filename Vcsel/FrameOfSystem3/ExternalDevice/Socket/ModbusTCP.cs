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

namespace FrameOfSystem3.ExternalDevice.Socket
{
 
    public enum EN_MODBUS_STATUS
    {
        WAITING_READ,
        SETTING_COMMAND,
    }
    
    class ModbusTCP
    {
        #region 변수
        private int m_nSocketIndex;
        private Config.ConfigSocket m_Socket = Config.ConfigSocket.GetInstance();
        private Dictionary<int, ModbusTCPDevice> m_dicOfModbus = new Dictionary<int, ModbusTCPDevice>();

        private int m_nObjectCode;
        private int m_nCurrentKey = 1;
        private byte[] m_bRecievedData = new byte[0];


        private TickCounter_.TickCounter m_TickForTimeOut = new TickCounter_.TickCounter();
        #endregion

        #region 싱글톤
        private ModbusTCP()
        {
        }
        private static Dictionary<int, ModbusTCP> _Instance = null;
        public static ModbusTCP GetInstance(int nIndex) 
        {
            if (_Instance == null)
            {
                _Instance = new Dictionary<int, ModbusTCP>();
            }
            if (!_Instance.ContainsKey(nIndex))
            {
                _Instance.Add(nIndex, new ModbusTCP());
            }
            return _Instance[nIndex];
        }
        #endregion

        #region 주기 호출 함수
        public void Execute()
        {
            if (m_Socket.IsConnected(ref m_nSocketIndex) == false
                || m_dicOfModbus.ContainsKey(m_nCurrentKey) == false)
                return;

            switch (m_dicOfModbus[m_nCurrentKey].enStatus)
            {
                case EN_MODBUS_STATUS.SETTING_COMMAND:
                    byte[] SendData = null;

                    m_dicOfModbus[m_nCurrentKey].GetSendCommand(ref SendData);

                    if (SendData != null)
                    {
                        m_Socket.send(m_nSocketIndex, SendData);
                        m_TickForTimeOut.SetTickCount(5000);
                        m_dicOfModbus[m_nCurrentKey].enStatus = EN_MODBUS_STATUS.WAITING_READ;
                    }
                    break;

                case EN_MODBUS_STATUS.WAITING_READ:
                    byte[] ReciveData = null;
                    if (DataReceived(ref ReciveData))
                    {
                        if (m_dicOfModbus.ContainsKey(ReciveData[6]))
                            m_dicOfModbus[ReciveData[6]].ParshingData(ReciveData);
                        m_dicOfModbus[m_nCurrentKey].enStatus = EN_MODBUS_STATUS.SETTING_COMMAND;
                        SetNextDevice();
                        break;
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
        public bool Init(int nIndexOfSocket)
        {
            m_nSocketIndex = nIndexOfSocket;


            if (m_Socket.Connect(ref m_nSocketIndex) == false)
                return false;


            m_nObjectCode = m_nSocketIndex * 100;

            return true;
        }

        public void AddDevice(ModbusTCPDevice enDevice)
        {
            m_dicOfModbus.Add(enDevice.bSlaveID, enDevice);
            m_nCurrentKey = enDevice.bSlaveID;

        }
        public void Close()
        {
            m_Socket.DisConnect(ref m_nSocketIndex);
        }
        #endregion

        #region 아이템 값 반환
        /// <summary>
        /// 2018.08.31 by yjlee [ADD] 통신이 열린 상태인지 확인한다.
        /// </summary>
        public bool IsOpened()
        {
            return m_Socket.IsConnected(ref m_nSocketIndex);
        }
        #endregion
        #endregion

        #region 내부 인터페이스
        #region 통신 인터페이스
        private bool DataReceived(ref byte[] ReciveDate)
        {
            byte[] Result = null;

            if (m_Socket.Receive(m_nSocketIndex, ref Result))
            {
                byte[] buff = new byte[m_bRecievedData.Length];
                Array.Copy(m_bRecievedData, buff, buff.Length);
                m_bRecievedData = new byte[buff.Length + Result.Length];
                Array.Copy(buff, m_bRecievedData, buff.Length);
                Array.Copy(Result, 0, m_bRecievedData, buff.Length, Result.Length);

                if (m_bRecievedData.Length > 5)
                {
                    if (m_dicOfModbus.ContainsKey(m_bRecievedData[6]) // 6번이 유닛ID
                        && m_dicOfModbus[m_bRecievedData[6]].CheckRecieveData(m_bRecievedData))
                    {
                        ReciveDate = m_bRecievedData;
                        m_bRecievedData = new byte[0];
                        return true;
                    }
                }
            }
            ReciveDate = m_bRecievedData;
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
    }

    public class ModbusTCPDevice
    {
        #region 상수
        protected const byte Read_Coil = 1;
        protected const byte Read_Holding_Register = 3;
        protected const byte Read_Input_Register = 4;

        protected const byte Write_Single_Coil = 5;
        protected const byte Write_Multi_Coil = 15;
        protected const byte Write_Single_Register = 6;
        protected const byte Write_Multi_Register = 16;

        protected const ushort Protocol_ID = 0;

        #endregion

        #region 변수
        private int m_nSocketIndex = 0;
        private byte m_bSlaveID;

        private EN_MODBUS_STATUS m_enStatus = EN_MODBUS_STATUS.SETTING_COMMAND;

        protected byte m_nFunctionCode;
        protected ushort m_nRequestAddress;
        protected ushort m_nRequestCount;
        protected ushort m_nTransaction_ID = 0;

        #endregion

        public ModbusTCPDevice(int SerialIndex ,byte SlaveID)
        {
            m_nSocketIndex = SerialIndex;
            m_bSlaveID = SlaveID;
        }

        #region 속성
        public byte bSlaveID { get { return m_bSlaveID; } }
        public int nSocketIndex { get { return m_nSocketIndex; } }
     
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

            byte[] byteCmd = new byte[12];
            byteCmd[0] = (byte)((m_nTransaction_ID & 0xff00) >> 8);
            byteCmd[1] = (byte)(m_nTransaction_ID & 0xff);
            byteCmd[2] = (byte)((Protocol_ID & 0xff00) >> 8);
            byteCmd[3] = (byte)(Protocol_ID & 0xff);
            byteCmd[4] = (byte)((6 & 0xff00) >> 8);
            byteCmd[5] = (byte)(6 & 0xff);
            byteCmd[6] = 0;
            byteCmd[7] = FunctionCode;
            byteCmd[8] = (byte)((Address & 0xff00) >> 8);
            byteCmd[9] = (byte)(Address & 0xff);
            byteCmd[10] = (byte)((RequestCount & 0xff00) >> 8);
            byteCmd[11] = (byte)(RequestCount & 0xff);
            return byteCmd;
        }

        protected byte[] GetWriteSingleCommand(byte FunctionCode, ushort Address, bool bValue)
        {
            m_nFunctionCode = FunctionCode;
            m_nRequestAddress = Address;

            byte[] byteCmd = new byte[12];
            byteCmd[0] = (byte)((m_nTransaction_ID & 0xff00) >> 8);
            byteCmd[1] = (byte)(m_nTransaction_ID & 0xff);
            byteCmd[2] = (byte)((Protocol_ID & 0xff00) >> 8);
            byteCmd[3] = (byte)(Protocol_ID & 0xff);
            byteCmd[4] = (byte)((6 & 0xff00) >> 8);
            byteCmd[5] = (byte)(6 & 0xff);
            byteCmd[6] = bSlaveID;
            byteCmd[7] = FunctionCode;
            byteCmd[8] = (byte)((Address & 0xff00) >> 8);
            byteCmd[9] = (byte)(Address & 0xff);
            if (bValue)
                byteCmd[10] = 0xff;
            else
                byteCmd[10] = 0x00;
            byteCmd[11] = 0x00;
            return byteCmd;
        }

        protected byte[] GetWriteSingleCommand(byte FunctionCode, ushort Address, ushort nValue)
        {
            m_nFunctionCode = FunctionCode;
            m_nRequestAddress = Address;

            byte[] byteCmd = new byte[12];
            byteCmd[0] = (byte)((m_nTransaction_ID & 0xff00) >> 8);
            byteCmd[1] = (byte)(m_nTransaction_ID & 0xff);
            byteCmd[2] = (byte)((Protocol_ID & 0xff00) >> 8);
            byteCmd[3] = (byte)(Protocol_ID & 0xff);
            byteCmd[4] = (byte)((6 & 0xff00) >> 8);
            byteCmd[5] = (byte)(6 & 0xff);
            byteCmd[6] = bSlaveID;
            byteCmd[7] = FunctionCode;
            byteCmd[8] = (byte)((Address & 0xff00) >> 8);
            byteCmd[9] = (byte)(Address & 0xff);
            byteCmd[10] = (byte)((nValue & 0xff00) >> 8);
            byteCmd[11] = (byte)(nValue & 0xff);
            return byteCmd;
        }
        //MultiWrite는 추후에 생각하자

        //기본은 big endian이지만 little endian인 경우도 있다.Parsing은 각 Device 별로 하자 
        public bool CheckRecieveData(byte[] arRecieveData)
        {
            byte[] ArrayLittleEndian;
            ArrayLittleEndian = arRecieveData.Skip(0).Take(2).Reverse().ToArray();
            if (BitConverter.ToUInt16(ArrayLittleEndian, 0) != m_nTransaction_ID)
                return false;
            ArrayLittleEndian = arRecieveData.Skip(4).Take(2).Reverse().ToArray();
            if (BitConverter.ToUInt16(ArrayLittleEndian, 0) != arRecieveData.Length - 6)//Slave ID + Function Code + Data 길이
                return false;
            if (arRecieveData[6] != bSlaveID)
                return false;
            if (arRecieveData[7] != m_nFunctionCode)
                return false;
            switch (m_nFunctionCode)
            {
                case 1:
                case 2:
                    if (arRecieveData.Length - 8        // HEADER, Function Code 제외
                        != ((m_nRequestCount - 1) / 8) + 1) //Bit로 ON/OFF가 표시됨으로
                        return false;
                    break;

                case 3:
                case 4:
                    if(arRecieveData[8] != m_nRequestCount * 2) //byte 갯수
                        return false;
                    if (arRecieveData.Length - 9        // HEADER, Function Code, Length 제외
                       != m_nRequestCount * 2)  //2byte 값으로 받는다.
                        return false;
                    break;
            }
            m_nTransaction_ID++;
            return true;
        }
        
    }
}
