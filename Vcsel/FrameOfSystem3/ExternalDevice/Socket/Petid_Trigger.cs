using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ModbusPeTid;
using Socket_;
using System.Threading;

namespace FrameOfSystem3.ExternalDevice.Socket
{
    class PetidTrigger
    {
        public enum EN_CHANNEL
        {
            A = 0,
            B = 1,
        }
        #region 변수
        private PeTid m_PeTidTrigger = new PeTid();

        private string m_strIP = "192.168.0.5"; // TriggerBoard IP 
        private ushort m_nPort = 502;

        private SOCKET_ITEM_STATE m_enState = SOCKET_ITEM_STATE.READY;
        private bool m_bInit = false;
        private bool m_bConnect = false;

        private double m_dCurrentFreq = -1;
        private int m_nCurrentDuty = -1;
        private bool m_bChAEnable = false;
        private bool m_bChBEnable = false;

        //private Thread m_ThreadForAsync;
        #endregion
        
        #region 싱글톤
        private PetidTrigger() { }

        private static readonly Lazy<PetidTrigger> lazyInstance = new Lazy<PetidTrigger>(() => new PetidTrigger());
        static public PetidTrigger GetInstance() 
        {
            return lazyInstance.Value; 
        }
        #endregion

        #region 속성
        public SOCKET_ITEM_STATE enState
        {
            get
            {
                return m_enState;
            }
        }
      
        #endregion

        #region 외부 인터페이스
        public bool Init(int nIndexOfSocket)
        {
            Socket_.Socket.GetInstance().GetParameter(nIndexOfSocket, PARAM_LIST.TARGET_IP, ref m_strIP);
            Socket_.Socket.GetInstance().GetParameter(nIndexOfSocket, PARAM_LIST.TARGET_PORT, ref m_nPort);
            m_bInit = true;

            return true;
        }

        public void Connect()
        {
            m_PeTidTrigger.Connect(m_strIP, m_nPort);
            if (Isconnected)
            m_bConnect = true;
        }
        public void Disconnect()
        {
            if (Isconnected)
                m_PeTidTrigger.Disconnect(); 
                m_bConnect = false;
        }

        public void Start()
        {
            if (Isconnected)
            {
                m_PeTidTrigger.TriggerControl_BEnable = 1;
            }
        }

        public void Stop()
        {
            if (Isconnected)
            {
                m_PeTidTrigger.TriggerControl_BEnable = 0;
            }
        }

        public bool SetFrequencyModeParameter(double dFrequency, double dWidth, int Count)
        {
            if (Isconnected)
            {
                m_PeTidTrigger.FrequencyFreq = (Int32)(dFrequency);

                Int32 value32;
                value32 = m_PeTidTrigger.CalStoreddValue_double(dWidth, 1000, 20);
                if (!m_PeTidTrigger.CheckValueRange(0, 65535, value32, "Output Width (0xf303)", "20ns"))
                    return false;
                m_PeTidTrigger.FrequencyWidth = (UInt16)value32;

                m_PeTidTrigger.FrequencyCount = 65535;
                return true;
            }
            Connect();
            return false;
        }
        public bool SetModeForDuty100()
        {
            if (Isconnected)
            {
                m_PeTidTrigger.TriggerControl_AOpMode = 2;
                //m_PeTidTrigger.TriggerControl_ADirection = 1;
                m_PeTidTrigger.TriggerControl_AStartBit = 1;

                m_PeTidTrigger.TriggerControl_BOpMode = 2;
                //m_PeTidTrigger.TriggerControl_BDirection = 1;
                m_PeTidTrigger.TriggerControl_BStartBit = 1;
                return true;
            }
            Connect();
            return false;
        }
        public bool SetChannelEnable(EN_CHANNEL enCh, bool bUsed)
        {
            if (Isconnected)
            {
                switch (enCh)
                {
                    case EN_CHANNEL.A:
                        m_bChAEnable = bUsed;
                        if (bUsed)
                        {
                            m_PeTidTrigger.FrequencyEnable_ChSelTA = 1;
                        }
                        else
                        {
                            m_PeTidTrigger.FrequencyEnable_ChSelTA = 0;
                        }
                        break;
                    case EN_CHANNEL.B:
                        m_bChBEnable = bUsed;
                        if (bUsed)
                        {
                            m_PeTidTrigger.FrequencyEnable_ChSelTB = 1;
                        }
                        else
                        {
                            m_PeTidTrigger.FrequencyEnable_ChSelTB = 0;
                        }
                        break;
                }
                return true;
            }
            Connect();
            return false;
        }

        public bool SetRunFrequencyMode(bool bStart)
        {
            if (Isconnected)
            {
                if (bStart)
                    m_PeTidTrigger.FrequencyEnable_OutEnable = 1;
                else
                    m_PeTidTrigger.FrequencyEnable_OutEnable = 0;
                return true;
            }
            Connect();
            return false;
        }

        public bool StartFrequencyMode(double dFrequency, int nDuty)
        {
            if (Isconnected)
            {
                if (dFrequency == 0 || nDuty == 0)
                {
                    m_PeTidTrigger.TriggerControl_AEnable = 0;
                    m_PeTidTrigger.TriggerControl_BEnable = 0;
                    m_PeTidTrigger.FrequencyEnable_OutEnable = 0;
                    return true;
                }
                    if (m_dCurrentFreq == dFrequency
                    && m_nCurrentDuty == nDuty)
                {
                    if (nDuty == 100)
                    {
                        m_PeTidTrigger.FrequencyEnable_OutEnable = 0;
                        if (m_bChAEnable)
                            m_PeTidTrigger.TriggerControl_AEnable = 1;
                        if (m_bChBEnable)
                            m_PeTidTrigger.TriggerControl_BEnable = 1;
                    }
                    else
                    {
                        m_PeTidTrigger.TriggerControl_AEnable = 0;
                        m_PeTidTrigger.TriggerControl_BEnable = 0;
                        m_PeTidTrigger.FrequencyEnable_OutEnable = 0;
                        m_PeTidTrigger.FrequencyEnable_OutEnable = 1;
                    }
                }
                else
                {
                    if (nDuty == 100)
                    {
                        m_PeTidTrigger.FrequencyEnable_OutEnable = 0;
                        if (m_bChAEnable)
                            m_PeTidTrigger.TriggerControl_AEnable = 1;
                        if (m_bChBEnable)
                            m_PeTidTrigger.TriggerControl_BEnable = 1;
                    }
                    else
                    {
                        m_PeTidTrigger.TriggerControl_AEnable = 0;
                        m_PeTidTrigger.TriggerControl_BEnable = 0;
                       
                        m_PeTidTrigger.FrequencyEnable_OutEnable = 0;
                        m_PeTidTrigger.FrequencyFreq = (Int32)(dFrequency);
                        double dBandWidt = nDuty / dFrequency * 10 * 1000;
                        
                        Int32 value32;
                        value32 = m_PeTidTrigger.CalStoreddValue_double(dBandWidt, 1000, 20);
//                         if (!m_PeTidTrigger.CheckValueRange(0, 65535, value32, "Output Width (0xf303)", "20ns"))
//                             return false;
//                         m_PeTidTrigger.FrequencyWidth = (UInt16)value32;
                        m_PeTidTrigger.FrequencyPulse_WidthMode = 1;
                        m_PeTidTrigger.FrequencyWidth32Bit = (Int32)value32;

                        m_PeTidTrigger.FrequencyEnable_OutEnable = 1;
                    }
                    m_dCurrentFreq = dFrequency;
                    m_nCurrentDuty = nDuty;
                }
                return true;
            }
            Connect();
            return false;
        }
        public bool SetFrequencyMode(double dFrequency, int nDuty)
        {
            if (Isconnected)
            {
                if (nDuty != 100)
                {
                    m_PeTidTrigger.TriggerControl_AEnable = 0;
                    m_PeTidTrigger.TriggerControl_BEnable = 0;

                    m_PeTidTrigger.FrequencyEnable_OutEnable = 0;
                    m_PeTidTrigger.FrequencyFreq = (Int32)(dFrequency);
                    double dBandWidt = nDuty / dFrequency * 10 * 1000;

                    Int32 value32;
                    value32 = m_PeTidTrigger.CalStoreddValue_double(dBandWidt, 1000, 20);
//                     if (!m_PeTidTrigger.CheckValueRange(0, 65535, value32, "Output Width (0xf303)", "20ns"))
//                         return false;
//                    m_PeTidTrigger.FrequencyWidth = (UInt16)value32;

                    m_PeTidTrigger.FrequencyPulse_WidthMode = 1;
                    m_PeTidTrigger.FrequencyWidth32Bit = (Int32)value32;
                    
                    m_PeTidTrigger.FrequencyEnable_OutEnable = 1;
                }
                m_dCurrentFreq = dFrequency;
                m_nCurrentDuty = nDuty;

                return true;
            }
            Connect();
            return false;
        }
        public bool StopTrigger()
        {
            if (Isconnected)
            {
                m_PeTidTrigger.TriggerControl_AEnable = 0;
                m_PeTidTrigger.TriggerControl_BEnable = 0;
                m_PeTidTrigger.FrequencyEnable_OutEnable = 0;
                return true;
            }
            Connect();
            return false;
        }
        public bool GetRunFrequencyMode()
        {
            if (Isconnected)
            {
                return m_PeTidTrigger.FrequencyEnable_OutEnable == 1;
               
            }
            Connect();
            return false;
        }
        public bool GetRunTrigger()
        {
            if (Isconnected)
            {
                return  m_PeTidTrigger.TriggerControl_AEnable == 1
                        || m_PeTidTrigger.TriggerControl_BEnable == 1;

            }
            Connect();
            return false;
        }

        public int GetRunFrequencyCount()
        {
            if (Isconnected)
            {
                return m_PeTidTrigger.FrequencyOutputCount;

            }
            Connect();
            return 0;
        }

    
        #endregion

        #region 내부 인터페이스
        

        public bool Isconnected
        {
            get
            {
                if (!m_bInit )
                    return false;

                bool bConnect = false;
                bConnect =  m_PeTidTrigger.connected;
                return bConnect;
            }
        }

        #endregion
    }
}
