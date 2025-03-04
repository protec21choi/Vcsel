using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FrameOfSystem3.SubSequence.SubPickPlace.PickPlaceListMotion;

using Motion_;

namespace FrameOfSystem3.SubSequence.SubPickPlace
{
    namespace PickPlaceListMotion
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
        }
    }

    class SubCtrlPickPlaceListMotion : ASubControl, IPickPlace
    {
        #region Variable
        private double dblTouchedPosition = 0.0;
        private double dblTouchedEncoderPosition = 0.0;
        #endregion

		#region Constants
		private const int USE_STEP		= 1;
		private const int AXIS_COUNT	= 4;
        private const int StepCount = 2;
		#endregion

        #region ForListParameter

        private double[] m_arPos = new double[StepCount];
        private double[] m_arSpeed = new double[StepCount];
        private MOTION_SPEED_CONTENT[] m_arSpeedContent = new MOTION_SPEED_CONTENT[StepCount];
        private int[] m_arRatio = new int[StepCount];
        #endregion

        #region <CONSTRUCTOR>
        public SubCtrlPickPlaceListMotion(Task.RunningTaskEx tRunningTask)
            : base(tRunningTask)
        {
        }
        #endregion </CONSTRUCTOR>

        #region <INTERFACE>
        public MOTION_RESULT MoveReadyPosition(double dReadyPos, int nPreDelay, int nPostDelay)
        {

            m_arPos[1] = dReadyPos;
            m_arSpeed[1] = 0;
            m_arSpeedContent[1] = MOTION_SPEED_CONTENT.RUN;
            m_arRatio[1] = 100;

            return m_InstanceTask.MoveByList(p_dicOfMotion[(int)EN_AXIS.Z], StepCount, m_arPos, m_arSpeed, m_arRatio, m_arSpeedContent, nPostDelay, nPreDelay, true);
        }
        public MOTION_RESULT MoveSearchStartPosition(double dSearchStartPos, int nPreDelay, int nPostDelay)
        {
            m_arPos[0] = dSearchStartPos;
            m_arSpeed[0] = 0;
            m_arSpeedContent[0] = MOTION_SPEED_CONTENT.RUN;
            m_arRatio[0] = 100;

            return MOTION_RESULT.OK;
        }

        public MOTION_RESULT MoveContactPosition(double dSearchEndPos, double dSearchSpeed, int nSpeedRatio, bool bTouchUsed, double dTouchGap, int nPreDelay, int nPostDelay)
		{
            
            m_arSpeed[1] = dSearchSpeed;
            m_arSpeedContent[1] = MOTION_SPEED_CONTENT.RUN;
            m_arRatio[1] = nSpeedRatio;

            int nAxisZ = p_dicOfMotion[(int)EN_AXIS.Z];

            int nEncoderIndex = p_dicOfMotion[(int)EN_AXIS.TOUCH_ENCODER];

            m_InstanceTask.SetPostion(nEncoderIndex, 0);

            if (bTouchUsed)
            {
                m_arPos[1] = dSearchEndPos - 1;
                double dblTouchThreshold = m_InstanceTask.GetAxisActualPosition(nEncoderIndex) + dTouchGap;

                return m_InstanceTask.MoveByListUntilTouch(nAxisZ, StepCount, m_arPos, nEncoderIndex, dblTouchThreshold, m_arSpeed, m_arRatio, m_arSpeedContent, nPostDelay, nPreDelay);
            }
            else
            {
                m_arPos[1] = dSearchEndPos;
                return m_InstanceTask.MoveByList(nAxisZ, StepCount, m_arPos, m_arSpeed, m_arRatio, m_arSpeedContent, nPostDelay, nPreDelay, true);
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

            m_arPos[0] = dCurrntPos + dReleaseLevel;
            m_arSpeed[0] = dReleaseSpeed;
            m_arSpeedContent[0] = MOTION_SPEED_CONTENT.RUN;
            m_arRatio[0] = nSpeedRatio;

            return MOTION_RESULT.OK;
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
