using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Define.DefineEnumeration.Work;
using FrameOfSystem3.SubSequence.SubBlockUpDown.Block;
using TaskDevice_;
using TickCounter_;

namespace FrameOfSystem3.SubSequence.SubBlockUpDown
{
    namespace Block
    {
        public enum EN_AXIS
        {
            BLOCK_Z,
            WIDTH,
        }
        public enum EN_CYLINDER
        {
            ALIGN,
        }
        public enum EN_DIGITAL_INPUT
        {
            VACUUM,
        }
        public enum EN_DIGITAL_OUTPUT
        {
            VACUUM_1,
            VACUUM_2,
            VACUUM_3,
            VACUUM_4,
        }
        public enum EN_ANALOG_INPUT
        {
            VACUUM,
        }
        public enum EN_PARAMETER
        {
            READY_POSITION,
            CONTACT_POSITION,
            BASE_POSITION,
            LOADING_SPEED,
            UNLOADING_SPEED,
            SLOW_SPEED,
            GAP_DELAY,
            ON_DELAY,
            VACUUM_TOLERANCE_MIN,
            VACUUM_TOLERANCE_MAX,
            VACUUM_TIME_OUT,
            VACUUM_WORK_TYPE,
            VACUUM_OFF_BEFORE_TIME,
            VACUUM_OFF_AFTER_TIME,

            ALIGN_MODE,
            ALIGN_OFFSET,

            USE_MASK,
        }
        public enum EN_ALARM
        {
            NONE = -1,
            TIME_OUT = 0,
            VACUUM_LOW = 1,
            VACUUM_HIGH = 2,
        }
    }

    class SubCtrlBlock : ASubControl, IBlock
    {
        #region <CONSTRUCTOR>
        public SubCtrlBlock(Task.RunningTaskEx tRunningTask)
            : base(tRunningTask)
        {
        }
        #endregion </CONSTRUCTOR>

        #region <VARIABLE>
        private TickCounter m_tickCheckTime = new TickCounter();
        #endregion

        #region <PROPERTY>
        public TickCounter TimeChecker { get { return m_tickCheckTime; } set { m_tickCheckTime = value; } }
        #endregion

        #region <INTERFACE>
        public bool CheckExist()
        {
            return true;
        }
        public bool MoveReady()
        {
            int nAxisZ = p_dicOfMotion[(int)EN_AXIS.BLOCK_Z];
            int nDeviceIndex = 0;
            p_instanceTask.GetDeviceTargetIndex(nAxisZ, TYPE_DEVICE.MOTION, ref nDeviceIndex);

            double dblPosition = p_instanceTask.GetParameter(p_dicOfParameter[(int)EN_PARAMETER.READY_POSITION],
                0,
                0.0);
            int nRatio = 100;

            if (false == p_instanceTaskOperator.IsRunningMode())
            {
                p_instanceMotion.MoveAbsolutely(nDeviceIndex
                    , dblPosition
                    , Config.ConfigMotion.EN_SPEED_CONTENT.RUN
                    , nRatio
                    , 300);
            }
            else
            {
                p_instanceTask.MovePosition(nAxisZ, dblPosition, nRatio);
            }

            return true;
        }
        public bool MoveAlignIn()
        {
            bool bUseMask = p_instanceTask.GetParameter(p_dicOfParameter[(int)EN_PARAMETER.USE_MASK]
                , 0
                , false);

            if (true == bUseMask)
                return true;

            EN_CONVEYOR_ALIGN_MODE enMode = p_instanceTask.GetParameter(p_dicOfParameter[(int)EN_PARAMETER.ALIGN_MODE]
                , 0
                , EN_CONVEYOR_ALIGN_MODE.WIDTH_AXIS);

            switch (enMode)
            {
                case EN_CONVEYOR_ALIGN_MODE.ALIGN_CYLINDER:
                    if (false == p_dicOfCylinder.ContainsKey((int)EN_CYLINDER.ALIGN))
                        break;

                    p_instanceTask.MoveCylinderForward(p_dicOfCylinder[(int)EN_CYLINDER.ALIGN], true);
                    break;
                case EN_CONVEYOR_ALIGN_MODE.WIDTH_AXIS:
                    double dblParameter = p_instanceTask.GetParameter(p_dicOfParameter[(int)EN_PARAMETER.ALIGN_OFFSET]
                        , 0
                        , 0.0);

                    p_instanceTask.MoveDistance(p_dicOfParameter[(int)EN_AXIS.WIDTH], (dblParameter * -1));

                    break;
            }

            return true;
        }
        public bool MoveContact(bool bUpDown, bool bSlowSpeed)
        {
            int nAxisZ = p_dicOfMotion[(int)EN_AXIS.BLOCK_Z];
            int nDeviceIndex = 0;
            p_instanceTask.GetDeviceTargetIndex(nAxisZ, TYPE_DEVICE.MOTION, ref nDeviceIndex);

            double dblPosition = p_instanceTask.GetParameter(p_dicOfParameter[(int)EN_PARAMETER.CONTACT_POSITION],
                0,
                0.0);

            int nRatio = 100;

            if (bUpDown)
            {
                nRatio = p_instanceTask.GetParameter(p_dicOfParameter[(int)EN_PARAMETER.LOADING_SPEED],
                    0,
                    100);
            }
            else
            {
                if (bSlowSpeed)
                {
                    nRatio = p_instanceTask.GetParameter(p_dicOfParameter[(int)EN_PARAMETER.SLOW_SPEED],
                        0,
                        100);
                }
                else
                {
                    nRatio = p_instanceTask.GetParameter(p_dicOfParameter[(int)EN_PARAMETER.UNLOADING_SPEED],
                        0,
                        100);
                }
            }

            if (false == p_instanceTaskOperator.IsRunningMode())
            {
                p_instanceMotion.MoveAbsolutely(nDeviceIndex
                    , dblPosition
                    , Config.ConfigMotion.EN_SPEED_CONTENT.RUN
                    , nRatio
                    , 300);
            }
            else
            {
                p_instanceTask.MovePosition(nAxisZ, dblPosition, nRatio);
            }

            return true;
        }
        public bool MoveAlignOut()
        {
            bool bUseMask = p_instanceTask.GetParameter(p_dicOfParameter[(int)EN_PARAMETER.USE_MASK]
                , 0
                , false);

            if (true == bUseMask)
                return true;

            EN_CONVEYOR_ALIGN_MODE enMode = p_instanceTask.GetParameter(p_dicOfParameter[(int)EN_PARAMETER.ALIGN_MODE]
                , 0
                , EN_CONVEYOR_ALIGN_MODE.WIDTH_AXIS);

            switch (enMode)
            {
                case EN_CONVEYOR_ALIGN_MODE.ALIGN_CYLINDER:
                    if (false == p_dicOfCylinder.ContainsKey((int)EN_CYLINDER.ALIGN))
                        break;

                    p_instanceTask.MoveCylinderBackward(p_dicOfCylinder[(int)EN_CYLINDER.ALIGN], true);
                    break;
                case EN_CONVEYOR_ALIGN_MODE.WIDTH_AXIS:
                    double dblParameter = p_instanceTask.GetParameter(p_dicOfParameter[(int)EN_PARAMETER.ALIGN_OFFSET]
                        , 0
                        , 0.0);

                    p_instanceTask.MoveDistance(p_dicOfParameter[(int)EN_AXIS.WIDTH], dblParameter);

                    break;
            }

            return true;
        }
        public bool MoveBase()
        {
            int nAxisZ = p_dicOfMotion[(int)EN_AXIS.BLOCK_Z];
            double dblPosition = p_instanceTask.GetParameter(p_dicOfParameter[(int)EN_PARAMETER.BASE_POSITION],
                0,
                0.0);
            int nRatio = 100;

            p_instanceTask.MovePosition(nAxisZ, dblPosition, nRatio);

            return true;
        }
        public bool IsMoveDone()
        {
            int nAxisZ = p_dicOfMotion[(int)EN_AXIS.BLOCK_Z];
            int nDeviceIndex = 0;
            p_instanceTask.GetDeviceTargetIndex(nAxisZ, TYPE_DEVICE.MOTION, ref nDeviceIndex);

            if (false == p_instanceTaskOperator.IsRunningMode())
                return p_instanceMotion.GetState(nDeviceIndex, Config.ConfigMotion.EN_MOTOR_STATE.MOTION_DONE);
            else
                return p_instanceTask.IsMoveDone(nAxisZ);
        }
        public bool TurnOnVacuum()
        {
            switch (p_nSubSeqNum)
            {
                case 0:
                    int nTimeOut = p_instanceTask.GetParameter(p_dicOfParameter[(int)EN_PARAMETER.VACUUM_TIME_OUT],
                        0,
                        60000);

                    m_tickCheckTime.SetTickCount((uint)nTimeOut);

                    p_nSubSeqNum++;
                    break;
                case 1:
                    TurnOnVacuum(1);

                    p_nSubSeqNum++;
                    break;
                case 2:
                    int nGapDelay = p_instanceTask.GetParameter(p_dicOfParameter[(int)EN_PARAMETER.GAP_DELAY],
                        0,
                        0);

                    p_instanceTask.SetDelaySequenceAtBackground(nGapDelay);
                    p_nSubSeqNum++;
                    break;
                case 3:
                    TurnOnVacuum(2);

                    p_nSubSeqNum++;
                    break;
                case 4:
                    int nOnDelay = p_instanceTask.GetParameter(p_dicOfParameter[(int)EN_PARAMETER.ON_DELAY],
                        0,
                        0);

                    p_instanceTask.SetDelaySequenceAtBackground(nOnDelay);
                    p_nSubSeqNum++;
                    break;
                case 5:
                    p_nSubSeqNum = 0;
                    return true;
            }

            return false;
        }
        public bool TurnOffVacuum()
        {
            switch (p_nSubSeqNum)
            {
                case 0:
                    int nOffBeforeDelay = p_instanceTask.GetParameter(p_dicOfParameter[(int)EN_PARAMETER.VACUUM_OFF_BEFORE_TIME],
                        0,
                        0);

                    p_instanceTask.SetDelaySequenceAtBackground(nOffBeforeDelay);
                    p_nSubSeqNum++;
                    break;
                case 1:
                    p_instanceTask.WriteDigitalOutput(p_dicOfDigitalOutput[(int)EN_DIGITAL_OUTPUT.VACUUM_1], false);
                    p_instanceTask.WriteDigitalOutput(p_dicOfDigitalOutput[(int)EN_DIGITAL_OUTPUT.VACUUM_2], false);

                    p_nSubSeqNum++;
                    break;
                case 2:
                    int nOffAfterDelay = p_instanceTask.GetParameter(p_dicOfParameter[(int)EN_PARAMETER.VACUUM_OFF_AFTER_TIME],
                        0,
                        0);

                    p_instanceTask.SetDelaySequenceAtBackground(nOffAfterDelay);
                    p_nSubSeqNum++;
                    break;
                case 3:
                    p_nSubSeqNum = 0;
                    return true;
            }

            return false;
        }
        public bool CheckVacuum(ref EN_ALARM enVacuumAlarm)
        {
            if (false == p_instanceTask.ReadDigitalInput(p_dicOfDigitalInput[(int)EN_DIGITAL_INPUT.VACUUM], true))
                return false;

            double dblMin = p_instanceTask.GetParameter(p_dicOfParameter[(int)EN_PARAMETER.VACUUM_TOLERANCE_MIN], 
                0, 
                0.0);
            double dblMax = p_instanceTask.GetParameter(p_dicOfParameter[(int)EN_PARAMETER.VACUUM_TOLERANCE_MAX],
                0,
                0.0);

            double dblCurrentValue = Math.Abs(p_instanceTask.ReadAnalogInputValue(p_dicOfDigitalOutput[(int)EN_ANALOG_INPUT.VACUUM]));

            if (dblMin <= dblCurrentValue && dblCurrentValue <= dblMax)
                return true;
            else
            {
                if (dblCurrentValue < dblMin)
                    enVacuumAlarm = EN_ALARM.VACUUM_LOW;

                if (dblCurrentValue > dblMax)
                    enVacuumAlarm = EN_ALARM.VACUUM_HIGH;

                return false;
            }
        }

        #endregion </INTERFACE>

        #region INTERNAL INTERFACE

        #region Turn On Vacuum
        private void TurnOnVacuum(int nIndex)
        {
            string strParameter = string.Empty;
            EN_WORK_VACUUM_TYPE enType = EN_WORK_VACUUM_TYPE.INPUT_2_WORK_2;

            if (-1 != p_dicOfParameter[(int)EN_PARAMETER.VACUUM_WORK_TYPE])
            {
                enType = p_instanceTask.GetParameter(p_dicOfParameter[(int)EN_PARAMETER.VACUUM_WORK_TYPE],
                    0,
                    EN_WORK_VACUUM_TYPE.INPUT_2_WORK_2);
            }

            switch (nIndex)
            {
                case 1:
                    switch (enType)
                    {
                        case EN_WORK_VACUUM_TYPE.INPUT_2_WORK_2:
                            p_instanceTask.WriteDigitalOutput(p_dicOfDigitalOutput[(int)EN_DIGITAL_OUTPUT.VACUUM_1], true);
                            break;
                        case EN_WORK_VACUUM_TYPE.INPUT_0_WORK_4:
                            p_instanceTask.WriteDigitalOutput(p_dicOfDigitalOutput[(int)EN_DIGITAL_OUTPUT.VACUUM_1], true);
                            p_instanceTask.WriteDigitalOutput(p_dicOfDigitalOutput[(int)EN_DIGITAL_OUTPUT.VACUUM_3], true);
                            break;
                    }
                    break;
                case 2:
                    switch (enType)
                    {
                        case EN_WORK_VACUUM_TYPE.INPUT_2_WORK_2:
                            p_instanceTask.WriteDigitalOutput(p_dicOfDigitalOutput[(int)EN_DIGITAL_OUTPUT.VACUUM_2], true);
                            break;
                        case EN_WORK_VACUUM_TYPE.INPUT_0_WORK_4:
                            p_instanceTask.WriteDigitalOutput(p_dicOfDigitalOutput[(int)EN_DIGITAL_OUTPUT.VACUUM_2], true);
                            p_instanceTask.WriteDigitalOutput(p_dicOfDigitalOutput[(int)EN_DIGITAL_OUTPUT.VACUUM_4], true);
                            break;
                    }
                    break;
            }
        }
        #endregion

        #endregion
    }
}
