using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FrameOfSystem3.Recipe;
using FrameOfSystem3.SubSequence.SubLaserWork.ProtecDeviceControl;
using TickCounter_;

namespace FrameOfSystem3.SubSequence.SubLaserWork
{
    namespace ProtecDeviceControl
    {
        public enum EN_DIGITAL_INPUT
        {
            READY = 0,
            ON = 1,
            ALARM = 2,

            READY_2 = 3,
            ON_2 = 4,
            ALARM_2 = 5,
        }
        public enum EN_DIGITAL_OUTPUT
        {
            READY = 0,
            ON = 1,
            RESET = 2,
            EMO = 3,

            READY_2 = 4,
            ON_2 = 5,
            RESET_2 = 6,
            EMO_2 = 7,
        }
    }

    class SubCtrlDeviceProtecLaser : ASubControl, IDeviceControl
    {
        #region <FIELD>
        private int m_nSeqNum = 0;

        private TickCounter m_TimeDelay = new TickCounter();
        #endregion </FIELD>

        #region <CONSTRUCTOR>
        public SubCtrlDeviceProtecLaser(Task.RunningTaskEx tRunningTask)
            : base(tRunningTask)
        {
        }
        #endregion </CONSTRUCTOR>

        #region <INTERFACE>
        public void EntryDeviceControl()
        {
            m_nSeqNum = 0;

        }
        public bool ReadyDeviceSetting()
        {
            int[] arReadInputKey = null;
            bool[] arReadInputValue = null;

            switch (m_nSeqNum)
            {
                case 0:
                    arReadInputKey = new int[1];
                    arReadInputValue = new bool[1];

                    arReadInputKey[0] = p_dicOfDigitalInput[(int)EN_DIGITAL_INPUT.READY];

                    arReadInputValue[0] = true;

                    if (false == m_InstanceTask.WriteDigitalAndRead(p_dicOfDigitalOutput[(int)EN_DIGITAL_OUTPUT.READY]
                                                                    , true
                                                                    , arReadInputKey
                                                                    , arReadInputValue))
                    {
                        break;
                    }

                    ++m_nSeqNum;
                    break;
                case 1:
                    m_nSeqNum = 0;
                    return true;
            }

            return false;
        }
        public bool StartWorkToDevice()
        {
            

            return true;
        }
        public bool StopWorkToDevice()
        {
            

            return true;
        }
        public bool FinishDevice()
        {
            int[] arReadInputKey = null;
            bool[] arReadInputType = null;

            switch (m_nSeqNum)
            {
                case 0:
                    arReadInputKey = new int[1];
                    arReadInputType = new bool[1];

                    arReadInputKey[0] = p_dicOfDigitalInput[(int)EN_DIGITAL_INPUT.READY];

                    arReadInputType[0] = false;

                    if (false == m_InstanceTask.WriteDigitalAndRead(p_dicOfDigitalOutput[(int)EN_DIGITAL_OUTPUT.READY]
                                                                    , false
                                                                    , arReadInputKey
                                                                    , arReadInputType))
                    {
                        break;
                    }

                    ++m_nSeqNum;
                    break;
                case 1:
                    m_nSeqNum = 0;
                    return true;
            }

            return false;
        }
        public bool InitializeDevice()
        {
            return true;
        }
        public bool StopEMO()
        {
            m_InstanceTask.WriteDigitalOutput(p_dicOfDigitalOutput[(int)EN_DIGITAL_OUTPUT.EMO], true);
            return true;
        }

        #endregion </INTERFACE>
    }
}
