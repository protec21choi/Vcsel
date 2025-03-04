using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FrameOfSystem3.Recipe;
using FrameOfSystem3.SubSequence.SubLaserWork.IPGLaserDeviceControl;
using TickCounter_;

namespace FrameOfSystem3.SubSequence.SubLaserWork
{
    namespace IPGLaserDeviceControl
    {
        public enum EN_DIGITAL_INPUT
        {
            POWER_ON = 0,
            POWER_SUPPLY = 1,
            EMISSION = 2,
        }
        public enum EN_DIGITAL_OUTPUT
        {
            REMOTE_KEY = 0,
            REMOTE_START = 1,
            EMISSION = 2,
        }
        public enum EN_SOCKET_INDEX
        {
            SOCKET = 0,
        }
    }

    class SubCtrlDeviceIPGLaser : ASubControl, IDeviceControl
    {
        #region <FIELD>
        private int m_nSeqNum = 0;

        private TickCounter m_TimeDelay = new TickCounter();

        private Socket_.Socket m_Socket = Socket_.Socket.GetInstance();
        #endregion </FIELD>

        #region costant
        private readonly string ExeternalAnalogEnable = "EEC";
        private readonly string ExeternalGuideEnable = "EEABC";
        private readonly string ExeternalEmissionEnable = "ELE";
        private readonly string ModulationEnable = "EMOD";
        private readonly string CR = Encoding.ASCII.GetString(new byte[] { 0x0D });

        #endregion

        #region <CONSTRUCTOR>
        public SubCtrlDeviceIPGLaser(Task.RunningTaskEx tRunningTask)
            : base(tRunningTask)
        {
        }
        #endregion </CONSTRUCTOR>

        #region <Enumalation>
        private enum INITIALIZE_STEP
        {
            INIT_DIGITAL = 0,

            INIT_SOCKET = 100,
        }

        #endregion </Enumalation>

        #region <INTERFACE>
        public void EntryDeviceControl()
        {
            m_nSeqNum = 0;

        }
        public bool ReadyDeviceSetting()
        {
            if (!m_InstanceTask.ReadDigitalInput(p_dicOfDigitalInput[(int)EN_DIGITAL_INPUT.POWER_ON], true, 0)
                || !m_InstanceTask.ReadDigitalInput(p_dicOfDigitalInput[(int)EN_DIGITAL_INPUT.POWER_SUPPLY], true, 0))
                return false;
            return true;
        }
        public bool StartWorkToDevice()
        {
            int[] arReadInputKey = null;
            bool[] arReadInputValue = null;

            arReadInputKey = new int[1];
            arReadInputValue = new bool[1];

            arReadInputKey[0] = p_dicOfDigitalInput[(int)EN_DIGITAL_INPUT.EMISSION];

            arReadInputValue[0] = true;

            if (false == m_InstanceTask.WriteDigitalAndRead(p_dicOfDigitalOutput[(int)EN_DIGITAL_OUTPUT.EMISSION]
                                                            , true
                                                            , arReadInputKey
                                                            , arReadInputValue))
            {
                return false;
            }

            return true;
        }
        public bool StopWorkToDevice()
        {
            int[] arReadInputKey = null;
            bool[] arReadInputType = null;

            arReadInputKey = new int[1];
            arReadInputType = new bool[1];

            arReadInputKey[0] = p_dicOfDigitalInput[(int)EN_DIGITAL_INPUT.EMISSION];

            arReadInputType[0] = false;

            if (false == m_InstanceTask.WriteDigitalAndRead(p_dicOfDigitalOutput[(int)EN_DIGITAL_OUTPUT.EMISSION]
                                                            , false
                                                            , arReadInputKey
                                                            , arReadInputType))
            {
                return false;
            }

            return true;
        }
        public bool FinishDevice()
        {
            return true;
        }
        public bool InitializeDevice()
        {
            switch(m_nSeqNum)
            {
                case (int)INITIALIZE_STEP.INIT_DIGITAL:
                    if(!m_InstanceTask.ReadDigitalInput(p_dicOfDigitalInput[(int)EN_DIGITAL_INPUT.POWER_ON], true, 0))
                    {
                        m_InstanceTask.WriteDigitalOutput(p_dicOfDigitalOutput[(int)EN_DIGITAL_OUTPUT.REMOTE_KEY], true);
                        m_TimeDelay.SetTickCount(10000); //LASER 초기화 대기
                    }
                    m_nSeqNum++;
                    break;
                case (int)INITIALIZE_STEP.INIT_DIGITAL + 1:
                    if (!m_TimeDelay.IsTickOver(true))
                        break;
                    if (m_InstanceTask.ReadDigitalInput(p_dicOfDigitalInput[(int)EN_DIGITAL_INPUT.POWER_ON], true, 0)
                         && m_InstanceTask.ReadDigitalInput(p_dicOfDigitalInput[(int)EN_DIGITAL_INPUT.POWER_SUPPLY], true, 0))
                    {
                        m_nSeqNum = (int)INITIALIZE_STEP.INIT_SOCKET;
                        break;
                    }
                    m_nSeqNum++;
                    break;
                case (int)INITIALIZE_STEP.INIT_DIGITAL + 2:
                    m_InstanceTask.WriteDigitalOutput(p_dicOfDigitalOutput[(int)EN_DIGITAL_OUTPUT.REMOTE_START], true);
                    m_TimeDelay.SetTickCount(2000); //1.2s 이상 push 되어야 함
                    m_nSeqNum++;
                    break;

                case (int)INITIALIZE_STEP.INIT_DIGITAL + 3:
                    if (!m_TimeDelay.IsTickOver(true))
                        break;
                    m_InstanceTask.WriteDigitalOutput(p_dicOfDigitalOutput[(int)EN_DIGITAL_OUTPUT.REMOTE_START], false);
                    m_TimeDelay.SetTickCount(200); // 100ms 후 power supply 신호 on 됨
                    m_nSeqNum++;
                    break;
                case (int)INITIALIZE_STEP.INIT_DIGITAL + 4:
                    if (!m_TimeDelay.IsTickOver(true))
                        break;
                    if (m_InstanceTask.ReadDigitalInput(p_dicOfDigitalInput[(int)EN_DIGITAL_INPUT.POWER_ON], true, 0)
                        && m_InstanceTask.ReadDigitalInput(p_dicOfDigitalInput[(int)EN_DIGITAL_INPUT.POWER_SUPPLY], true, 0))
                    {
                        m_nSeqNum = (int)INITIALIZE_STEP.INIT_SOCKET;
                        break;
                    }
                    m_nSeqNum = (int)INITIALIZE_STEP.INIT_DIGITAL;
                    break;

                case (int)INITIALIZE_STEP.INIT_SOCKET:
                    m_Socket.Connect(p_dicOfSocket[(int)EN_SOCKET_INDEX.SOCKET]);
                    m_nSeqNum++;
                    break;
                case (int)INITIALIZE_STEP.INIT_SOCKET + 1:
                    m_Socket.Send(p_dicOfSocket[(int)EN_SOCKET_INDEX.SOCKET], ExeternalAnalogEnable + CR);
                    m_nSeqNum++;
                    break;
                case (int)INITIALIZE_STEP.INIT_SOCKET + 2:
                    if (m_Socket.GetState(p_dicOfSocket[(int)EN_SOCKET_INDEX.SOCKET]) == Socket_.SOCKET_ITEM_STATE.TIMEOUT_RECEIVE)
                        return true;
                    string strRecive = "";
                   if(m_Socket.Receive(p_dicOfSocket[(int)EN_SOCKET_INDEX.SOCKET],ref strRecive)
                       && strRecive == ExeternalAnalogEnable + CR)
                    m_nSeqNum++;
                    break;
                case (int)INITIALIZE_STEP.INIT_SOCKET + 3:
                    m_Socket.Send(p_dicOfSocket[(int)EN_SOCKET_INDEX.SOCKET], ExeternalGuideEnable + CR);
                    m_nSeqNum++;
                    break;
                case (int)INITIALIZE_STEP.INIT_SOCKET + 4:
                    if (m_Socket.GetState(p_dicOfSocket[(int)EN_SOCKET_INDEX.SOCKET]) == Socket_.SOCKET_ITEM_STATE.TIMEOUT_RECEIVE)
                        return true;
                    strRecive = "";
                    if (m_Socket.Receive(p_dicOfSocket[(int)EN_SOCKET_INDEX.SOCKET], ref strRecive)
                        && strRecive == ExeternalGuideEnable + CR)
                        m_nSeqNum++;
                    break;
                case (int)INITIALIZE_STEP.INIT_SOCKET + 5:
                    m_Socket.Send(p_dicOfSocket[(int)EN_SOCKET_INDEX.SOCKET], ExeternalEmissionEnable + CR);
                    m_nSeqNum++;
                    break;
                case (int)INITIALIZE_STEP.INIT_SOCKET + 6:
                    if (m_Socket.GetState(p_dicOfSocket[(int)EN_SOCKET_INDEX.SOCKET]) == Socket_.SOCKET_ITEM_STATE.TIMEOUT_RECEIVE)
                        return true;
                    strRecive = "";
                    if (m_Socket.Receive(p_dicOfSocket[(int)EN_SOCKET_INDEX.SOCKET], ref strRecive)
                        && strRecive == ExeternalEmissionEnable + CR)
                        m_nSeqNum++;
                    break;
                case (int)INITIALIZE_STEP.INIT_SOCKET + 7:
                    m_Socket.Send(p_dicOfSocket[(int)EN_SOCKET_INDEX.SOCKET], ModulationEnable + CR);
                    m_nSeqNum++;
                    break;
                case (int)INITIALIZE_STEP.INIT_SOCKET + 8:
                    if (m_Socket.GetState(p_dicOfSocket[(int)EN_SOCKET_INDEX.SOCKET]) == Socket_.SOCKET_ITEM_STATE.TIMEOUT_RECEIVE)
                        return true;
                    strRecive = "";
                    if (m_Socket.Receive(p_dicOfSocket[(int)EN_SOCKET_INDEX.SOCKET], ref strRecive)
                        && strRecive == ModulationEnable + CR)
                        m_nSeqNum++;
                    break;
                case (int)INITIALIZE_STEP.INIT_SOCKET + 9:
                    m_nSeqNum = 0;
                    return true;
            }
            return false;
        }

        public bool StopEMO()
        {
            return true;
        }
        #endregion </INTERFACE>
    }
}
