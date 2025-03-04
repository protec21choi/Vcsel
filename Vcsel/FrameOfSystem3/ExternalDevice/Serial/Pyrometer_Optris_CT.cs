using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FrameOfSystem3.ExternalDevice.Serial
{
    class Pyrometer_Optris_CT
    {
        public Pyrometer_Optris_CT()
        {
            m_arSetByte = new byte[2];
            m_dicPyrometerItems = new Dictionary<int, PyrometerItem>();
            m_InstanceOfSerial = FrameOfSystem3.Config.ConfigSerial.GetInstance();
        }
        private static Pyrometer_Optris_CT _Instance = new Pyrometer_Optris_CT();
        public static Pyrometer_Optris_CT GetInstance()
        {
            return _Instance;
        }

        #region <Constant>

        private readonly byte[] READ_TEMP_BYTE = { 0x81 };
        private readonly byte[] WRITE_TEMP_BYTE = { 0x84 };
        private readonly byte[] READ_SET_TEMP_BYTE = { 0x04 };

        private const int ByteFrontMask = 0xff00;
        private const int ByteBackMask = 0x00ff;

        private const int ByteWaitMask = 0x07;

        #region <Enum>

        public enum EN_STATE
        {
            WAIT,

            SEND,
            RECEIVE,
        }

        public enum EN_COMMAND
        {
            WAIT,
            SET_EMISSIVITY_TARGET,

            READ_CURRENT_VALUE,
            READ_SET_VALUE,
        }

        #endregion </Enum>

        #endregion </Constant>

        #region <Variables>
        private EN_COMMAND m_enCurCommand = EN_COMMAND.WAIT;

        private double m_dbSetValue = -1;
        private byte[] m_arSetByte = null;

        private List<byte> m_arRecivebuffer = new List<byte>();

        FrameOfSystem3.Config.ConfigSerial m_InstanceOfSerial = null;

        private int nWait = 0;
        private bool m_bInit = false;
        private Dictionary<int, PyrometerItem> m_dicPyrometerItems = null;
        private ReaderWriterLockSlim m_rwLock = new ReaderWriterLockSlim();
        #endregion </Varialbles>

        #region Internal Instance

        #region < CRC >

        private byte[] CheckSum (ref byte[] arMessageFormat)
        {
            byte[] byChecksum = {0};
            foreach(byte Data in arMessageFormat)
            {
                byChecksum[0] ^= Data; 
            }

            arMessageFormat = arMessageFormat.Concat(byChecksum).ToArray();

            return arMessageFormat;
        }

        #endregion

        #region <Data Parsing>

        private bool Parsing(ref byte[] arReceiveData, ref double dbValue)
        {
            dbValue = 0;

            switch(m_enCurCommand)
            {
                case EN_COMMAND.READ_CURRENT_VALUE:
                    if (arReceiveData.Length != 2)
                        return false;

                    dbValue = (double)(arReceiveData[0] * 256 + arReceiveData[1] -1000 )/ 10;
                    break;

                case EN_COMMAND.READ_SET_VALUE:
                    if (arReceiveData.Length != 2)
                        return false;
                    dbValue = (double)(arReceiveData[0] * 256 + arReceiveData[1] )/ 1000;
                    break;
                    
                case EN_COMMAND.SET_EMISSIVITY_TARGET:
                    if (arReceiveData.Length != 2)
                        return false;
                    // 데이터 갯수나 받아온 값이 Set Value와 다를경우
                    dbValue = (double)(arReceiveData[0] * 256 + arReceiveData[1]) / 1000;
                    double setValue = (double)(m_arSetByte[0] * 256 + m_arSetByte[1]) / 1000;
                    if (dbValue != setValue)
                        return false;
                    break;
            }
            return true;
        }

        #endregion </Data Parsing>

        #region <TRANSMIT COMMAND>

        private bool Send_DataFormat(int nPortIndex, EN_COMMAND enCMD)
        {
            byte[] DataFormat = null;

            switch(enCMD)
            {
                case EN_COMMAND.SET_EMISSIVITY_TARGET:
                    DataFormat = new byte[3];

                    DataFormat[0] = WRITE_TEMP_BYTE[0];
                    DataFormat[1] = m_arSetByte[0];
                    DataFormat[2] = m_arSetByte[1];
                    CheckSum(ref DataFormat);
                    break;

                case EN_COMMAND.READ_CURRENT_VALUE:
                    DataFormat = READ_TEMP_BYTE;
                    break;

                case EN_COMMAND.READ_SET_VALUE:
                    DataFormat = READ_SET_TEMP_BYTE;
                    break;
            }
            return m_InstanceOfSerial.Write(nPortIndex, DataFormat);
        }

        #endregion </TRANSMIT COMMAND>

        #endregion

        #region Extern Interface
        public bool Init(int[] arSerialIndex)
        {
            bool bReturn = true;
            for (int nIndex = 0; nIndex < arSerialIndex.Length; ++nIndex)
            {
                m_dicPyrometerItems.Add(nIndex, new PyrometerItem(arSerialIndex[nIndex]));
                m_dicPyrometerItems[nIndex].m_CurState = EN_STATE.WAIT;

                bReturn &= m_InstanceOfSerial.Open(arSerialIndex[nIndex]);

            }


            m_bInit = true;

            return bReturn;
        }

        public void Execute()
        {
            foreach (PyrometerItem Item in m_dicPyrometerItems.Values)
            {
                switch (Item.m_CurState)
                {
                    case EN_STATE.WAIT:
                        break;

                    case EN_STATE.SEND:

                        #region <Clear Buff>
                        byte[] ClearBuff = null;
                        m_InstanceOfSerial.Read(Item.nPortIndex, ref ClearBuff);
                        #endregion </Clear Buff>

                        #region <Send Message Format>
                        Send_DataFormat(Item.nPortIndex, m_enCurCommand);
                        #endregion </Send Messasge Format>

                        #region <Set Tick Count and Monitoring TimeOut>
                        Item.m_TickCountForDelay.SetTickCount(3);
                      
                        Item.m_TickCountForTimeOut.SetTickCount(10);
                        #endregion </Set Tick Count and Monitoring TimeOut>

                        Item.m_CurState = EN_STATE.RECEIVE;
                        break;

                    case EN_STATE.RECEIVE:

                        #region <Delay For Receive ( Tick Count 3 )>
                        if (Item.m_TickCountForDelay.GetTickCount() < 3)
                            break;
                        #endregion <Delay For Receive ( Tick Count 3 )>

                        #region <Receive Message and Data Parsing>

                        byte[] arReceived = null;

                        if (m_InstanceOfSerial.Read(Item.nPortIndex, ref arReceived))
                        {
                            double dValue = 0;
                            if (false == Parsing(ref arReceived, ref dValue))
                            {
                                //현재 Command 다시 전송
                                Item.m_CurState = EN_STATE.SEND;
                                return;
                            }

                            switch (m_enCurCommand)
                            {
                                case EN_COMMAND.READ_CURRENT_VALUE:
                                    Item.dTempValue = dValue;
                                    break;

                                case EN_COMMAND.READ_SET_VALUE:
                                    break;

                                case EN_COMMAND.SET_EMISSIVITY_TARGET:
                                    Item.dCurrentEmissivity = dValue;
                                    break;
                            }
                            Item.m_CurState = EN_STATE.WAIT;
                        }
                        #endregion </Receive Message and Data Parsing>

                        #region time out
                        ulong CycleTime = Item.m_TickCountForTimeOut.GetTickCount();
                        if (CycleTime > 5000)
                        {
                            Item.m_CurState = EN_STATE.SEND;
                        }
                        #endregion

                        return;

                }
            }
        }
     
        public double GetTemp(int nChannel) { return m_dicPyrometerItems[nChannel].dTempValue; }
        public double GetSettingEmissivity(int nChannel) { return m_dicPyrometerItems[nChannel].dSettingEmissivity; }
        public double GetCurrentEmissivity(int nChannel) { return m_dicPyrometerItems[nChannel].dCurrentEmissivity; }
        public void SetCommand(EN_COMMAND enCommand, double dbValue = 0.0)
        {
            m_enCurCommand = enCommand;
            switch (enCommand)
            {
                case EN_COMMAND.SET_EMISSIVITY_TARGET:
                    uint nValue = (uint)(dbValue * 1000);
                    byte[] ar = BitConverter.GetBytes(nValue);
                    m_arSetByte[0] = ar[1];
                    m_arSetByte[1] = ar[0];
                    break;
            }
            foreach (PyrometerItem Item in m_dicPyrometerItems.Values)
            {
                switch (enCommand)
                {
                    case EN_COMMAND.SET_EMISSIVITY_TARGET:
                        Item.dSettingEmissivity = dbValue;
                        break;
                }
                Item.m_CurState = EN_STATE.SEND;
            }
        }
        #endregion Extern Interface

        #region <Class>
        private class PyrometerItem
        {
            public PyrometerItem(int nPortIndex)
            {
                m_nPortIndex = nPortIndex;
            }

            private int m_nPortIndex = -1;
            private double m_dTempValue = -1;
            private double m_dCurrentEmissivity = 0;
            private double m_dSettingEmissivity = 0;

            public EN_STATE m_CurState = EN_STATE.WAIT;

            public TickCounter_.TickCounter m_TickCountForDelay = new TickCounter_.TickCounter();
            public TickCounter_.TickCounter m_TickCountForTimeOut = new TickCounter_.TickCounter();

            public int nPortIndex { get { return m_nPortIndex; } }
            public double dTempValue { get { return m_dTempValue; } set { m_dTempValue = value; } }
            public double dSettingEmissivity { get { return m_dSettingEmissivity; } set { m_dSettingEmissivity = value; } }
            public double dCurrentEmissivity { get { return m_dCurrentEmissivity; } set { m_dCurrentEmissivity = value; } }
        }

        #endregion </Class>

    }


        
}
