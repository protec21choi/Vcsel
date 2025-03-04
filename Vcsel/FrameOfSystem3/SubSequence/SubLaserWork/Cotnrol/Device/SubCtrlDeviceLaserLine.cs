using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FrameOfSystem3.Recipe;
using FrameOfSystem3.SubSequence.SubLaserWork.LaserLineDeviceControl;
using TickCounter_;

namespace FrameOfSystem3.SubSequence.SubLaserWork
{
    namespace LaserLineDeviceControl
    {
        public enum EN_DIGITAL_INPUT
        {
            SAFETY_STATUS = 0,
            SLEEP_MODE = 1,
            WARNING = 2,
            ERROR = 3,
            SHUTTER_ON = 4,
            SHUTTER_OFF = 5,
            READY = 6,
            ACTIVE = 7,
            LIGHT_CABLE_ERROR = 8,
        }
        public enum EN_DIGITAL_OUTPUT
        {
            RESETTING = 0,
            READY = 1,
            SHUTTER = 2,
            ACTIVE = 3,
            ALIGNMENT = 4,
        }
    }

    class SubCtrlDeviceLaserLine : ASubControl, IDeviceControl
    {
        #region <FIELD>
        private int m_nSeqNum = 0;

        private TickCounter m_TimeDelay = new TickCounter();
        #endregion </FIELD>

        #region <CONSTRUCTOR>
        public SubCtrlDeviceLaserLine(Task.RunningTaskEx tRunningTask)
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
                    arReadInputKey = new int[4];
                    arReadInputValue = new bool[4];

                    arReadInputKey[0] = p_dicOfDigitalInput[(int)EN_DIGITAL_INPUT.ERROR];
                    arReadInputKey[1] = p_dicOfDigitalInput[(int)EN_DIGITAL_INPUT.LIGHT_CABLE_ERROR];
                    arReadInputKey[2] = p_dicOfDigitalInput[(int)EN_DIGITAL_INPUT.SLEEP_MODE];
                    arReadInputKey[3] = p_dicOfDigitalInput[(int)EN_DIGITAL_INPUT.WARNING];

                    arReadInputValue[0] = false;
                    arReadInputValue[1] = false;
                    arReadInputValue[2] = false;
                    arReadInputValue[3] = false;

                    if (false == m_InstanceTask.WriteDigitalAndRead(p_dicOfDigitalOutput[(int)EN_DIGITAL_OUTPUT.RESETTING]
                                                                    , true
                                                                    , arReadInputKey
                                                                    , arReadInputValue))
                    {
                        m_TimeDelay.SetTickCount(500);
                        break;
                    }

                    ++m_nSeqNum;
                    break;
                case 1:
                    if (!m_TimeDelay.IsTickOver(true))
                        break;

                    m_InstanceTask.WriteDigitalOutput(p_dicOfDigitalOutput[(int)EN_DIGITAL_OUTPUT.RESETTING], false);

                    ++m_nSeqNum;
                    break;
                case 2:
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
                case 3:
                    arReadInputKey = new int[2];
                    arReadInputValue = new bool[2];

                    arReadInputKey[0] = p_dicOfDigitalInput[(int)EN_DIGITAL_INPUT.SHUTTER_ON];
                    arReadInputKey[1] = p_dicOfDigitalInput[(int)EN_DIGITAL_INPUT.SHUTTER_OFF];

                    arReadInputValue[0] = true;
                    arReadInputValue[1] = false;

                    if (false == m_InstanceTask.WriteDigitalAndRead(p_dicOfDigitalOutput[(int)EN_DIGITAL_OUTPUT.SHUTTER]
                                                                    , true
                                                                    , arReadInputKey
                                                                    , arReadInputValue))
                    {
                        break;
                    }

                    ++m_nSeqNum;
                    break;
                case 4:
                    m_nSeqNum = 0;
                    return true;
            }

            return false;
        }
        public bool StartWorkToDevice()
        {
            int[] arReadInputKey = null;
            bool[] arReadInputValue = null;

            arReadInputKey = new int[1];
            arReadInputValue = new bool[1];

            arReadInputKey[0] = p_dicOfDigitalInput[(int)EN_DIGITAL_INPUT.ACTIVE];

            arReadInputValue[0] = true;

            if (false == m_InstanceTask.WriteDigitalAndRead(p_dicOfDigitalOutput[(int)EN_DIGITAL_OUTPUT.ACTIVE]
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

            arReadInputKey[0] = p_dicOfDigitalInput[(int)EN_DIGITAL_INPUT.ACTIVE];

            arReadInputType[0] = false;

            if (false == m_InstanceTask.WriteDigitalAndRead(p_dicOfDigitalOutput[(int)EN_DIGITAL_OUTPUT.ACTIVE]
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
            int[] arReadInputKey = null;
            bool[] arReadInputType = null;

            switch (m_nSeqNum)
            {
                case 0:
                    arReadInputKey = new int[2];
                    arReadInputType = new bool[2];

                    arReadInputKey[0] = p_dicOfDigitalInput[(int)EN_DIGITAL_INPUT.SHUTTER_ON];
                    arReadInputKey[1] = p_dicOfDigitalInput[(int)EN_DIGITAL_INPUT.SHUTTER_OFF];

                    arReadInputType[0] = false;
                    arReadInputType[1] = true;

                    if (false == m_InstanceTask.WriteDigitalAndRead(p_dicOfDigitalOutput[(int)EN_DIGITAL_OUTPUT.SHUTTER]
                                                                    , false
                                                                    , arReadInputKey
                                                                    , arReadInputType))
                    {
                        break;
                    }

                    ++m_nSeqNum;
                    break;
                case 1:
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
                case 2:
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
            return true;
        }
        #endregion </INTERFACE>
    }
}
