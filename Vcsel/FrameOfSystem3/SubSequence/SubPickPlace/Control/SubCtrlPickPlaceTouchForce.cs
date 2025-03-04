using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FrameOfSystem3.SubSequence.SubPickPlace.PickPlace;

using Motion_;

namespace FrameOfSystem3.SubSequence.SubPickPlace
{
    namespace PickPlaceTouchForce
    {
        public enum EN_AXIS
        {
			Z = 0,

			TOUCH_ENCODER	= 1,
        }
        public enum EN_DIGITAL_OUTPUT
        {
            VACUUM_1 = 0,
            VACUUM_2 = 1,
            BLOW_1 = 2,
            BLOW_2 = 3,
        }
        public enum EN_ANALOG_INPUT
        {
            VAC,

			FORCE1,
			FORCE2,
			FORCE3,
        }
    }

    class SubCtrlPickPlaceTouchForce : ASubControl, IPickPlace
    {
        #region Variable
        private double dblTouchedPosition = 0.0;
        private double dblTouchedEncoderPosition = 0.0;
        #endregion

		#region Constants
		private const int USE_STEP		= 1;
		private const int AXIS_COUNT	= 4;
		#endregion

        #region <CONSTRUCTOR>
        public SubCtrlPickPlaceTouchForce(Task.RunningTaskEx tRunningTask)
            : base(tRunningTask)
        {
        }
        #endregion </CONSTRUCTOR>

        #region <INTERFACE>
        public MOTION_RESULT MoveReadyPosition(double dReadyPos, int nPreDelay, int nPostDelay)
        {
            m_InstanceTask.AddMoveAbsolutely(p_dicOfMotion[(int)EN_AXIS.Z], dReadyPos, 100, MOTION_SPEED_CONTENT.RUN, true, nPostDelay, nPreDelay);

            return m_InstanceTask.MoveMotion();
        }
        public MOTION_RESULT MoveSearchStartPosition(double dSearchStartPos, int nPreDelay, int nPostDelay)
        {
            m_InstanceTask.AddMoveAbsolutely(p_dicOfMotion[(int)EN_AXIS.Z], dSearchStartPos, 100, MOTION_SPEED_CONTENT.RUN, true, nPostDelay, nPreDelay);

            return m_InstanceTask.MoveMotion();
        }

        public MOTION_RESULT MoveContactPosition(double dSearchEndPos, double dSearchSpeed, int nSpeedRatio, bool bTouchUsed, double dTouchGap, int nPreDelay, int nPostDelay)
		{
            int nAxisZ = p_dicOfMotion[(int)EN_AXIS.Z];

            int nEncoderIndex = p_dicOfMotion[(int)EN_AXIS.TOUCH_ENCODER];

            m_InstanceTask.SetPostion(nEncoderIndex, 0);
            if (bTouchUsed)
            {
                int[] arForceIndex = new int[]{p_dicOfAnalogInput[(int)EN_ANALOG_INPUT.FORCE1]
                                            , p_dicOfAnalogInput[(int)EN_ANALOG_INPUT.FORCE2]
                                            , p_dicOfAnalogInput[(int)EN_ANALOG_INPUT.FORCE3]};

                double dblTouchThreshold = dTouchGap;

                return m_InstanceTask.MoveUntilTouch_Analog(nAxisZ, dSearchEndPos, arForceIndex, dblTouchThreshold, dSearchSpeed, MOTION_SPEED_CONTENT.RUN, nSpeedRatio, nPostDelay, nPreDelay);
            }
            else
            {
                m_InstanceTask.AddMoveAbsolutely(p_dicOfMotion[(int)EN_AXIS.Z], dSearchEndPos, dSearchSpeed, nSpeedRatio, true, nPostDelay, nPreDelay);

                return m_InstanceTask.MoveMotion();
            }
		}
        public bool IsTouched(bool bTouchUsed)
		{
            if (!bTouchUsed)
                return true;

            int nAxis = p_dicOfMotion[(int)EN_AXIS.Z];

			
            if(m_InstanceTask.IsTouched(nAxis, ref dblTouchedPosition, ref dblTouchedEncoderPosition))
            {
               return true;
            }

            return false;
		}
        public bool GetTouchedData(ref double TouchedPosition, ref double TouchedEncorder)
        {
            TouchedPosition = dblTouchedPosition;
            TouchedEncorder = dblTouchedEncoderPosition;
            return true;
        }

        public MOTION_RESULT MoveReleasePosition(double dReleaseLevel, double dReleaseSpeed, int nSpeedRatio, int nPreDelay, int nPostDelay)
        {
            double dCurrntPos = m_InstanceTask.GetAxisCommandPosition(p_dicOfMotion[(int)EN_AXIS.Z]);

            m_InstanceTask.AddMoveAbsolutely(p_dicOfMotion[(int)EN_AXIS.Z], dCurrntPos + dReleaseLevel, dReleaseSpeed, nSpeedRatio, true, nPostDelay, nPreDelay);

            return m_InstanceTask.MoveMotion();
        }

        public void WriteForceMeasure(bool bWrite)
        {
            m_InstanceTask.WriteDigitalOutput(p_dicOfDigitalOutput[(int)EN_DIGITAL_OUTPUT.FORCE_MEASURE], bWrite);
        }

        public void VacuumOnBlowOff()
        {
            m_InstanceTask.WriteDigitalOutput(p_dicOfDigitalOutput[(int)EN_DIGITAL_OUTPUT.VACUUM_1], true);
            if (p_dicOfDigitalOutput.ContainsKey((int)EN_DIGITAL_OUTPUT.VACUUM_2))
                m_InstanceTask.WriteDigitalOutput(p_dicOfDigitalOutput[(int)EN_DIGITAL_OUTPUT.VACUUM_2], true);

            m_InstanceTask.WriteDigitalOutput(p_dicOfDigitalOutput[(int)EN_DIGITAL_OUTPUT.BLOW_1], false);
            if (p_dicOfDigitalOutput.ContainsKey((int)EN_DIGITAL_OUTPUT.BLOW_2))
                m_InstanceTask.WriteDigitalOutput(p_dicOfDigitalOutput[(int)EN_DIGITAL_OUTPUT.BLOW_2], false);
        }
        public void VacuumOffBlowOn(bool bVacuumKeepUsed = false, bool bBlowUsed = true)
        {
            if (false == bVacuumKeepUsed)
            {
                m_InstanceTask.WriteDigitalOutput(p_dicOfDigitalOutput[(int)EN_DIGITAL_OUTPUT.VACUUM_1], false);
                if (p_dicOfDigitalOutput.ContainsKey((int)EN_DIGITAL_OUTPUT.VACUUM_2))
                    m_InstanceTask.WriteDigitalOutput(p_dicOfDigitalOutput[(int)EN_DIGITAL_OUTPUT.VACUUM_2], false);

                if (bBlowUsed)
                {
                    m_InstanceTask.WriteDigitalOutput(p_dicOfDigitalOutput[(int)EN_DIGITAL_OUTPUT.BLOW_1], true);
                    if (p_dicOfDigitalOutput.ContainsKey((int)EN_DIGITAL_OUTPUT.BLOW_2))
                        m_InstanceTask.WriteDigitalOutput(p_dicOfDigitalOutput[(int)EN_DIGITAL_OUTPUT.BLOW_2], true);
                }
            }
        }
        public void BlowOff()
        {
            m_InstanceTask.WriteDigitalOutput(p_dicOfDigitalOutput[(int)EN_DIGITAL_OUTPUT.BLOW_1], false);
            if (p_dicOfDigitalOutput.ContainsKey((int)EN_DIGITAL_OUTPUT.BLOW_2))
                m_InstanceTask.WriteDigitalOutput(p_dicOfDigitalOutput[(int)EN_DIGITAL_OUTPUT.BLOW_2], false);
        }

        public bool CheckVacuum(double dVacuumThreshold)
        {
            if (m_InstanceTask.ReadAnalogInputValue(p_dicOfAnalogInput[(int)EN_ANALOG_INPUT.VAC]) <= dVacuumThreshold)
                return true;

            return false;
        }
        #endregion </INTERFACE>
    }
}
