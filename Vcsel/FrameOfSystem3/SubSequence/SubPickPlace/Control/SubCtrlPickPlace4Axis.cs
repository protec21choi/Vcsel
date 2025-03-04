using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FrameOfSystem3.SubSequence.SubPickPlace.PickPlace4Axis;

using Motion_;

namespace FrameOfSystem3.SubSequence.SubPickPlace
{
    namespace PickPlace4Axis
    {
        public enum EN_AXIS
        {
			Z1 = 0,
			Z2 = 1,
			Z3 = 2,
			Z4 = 3,
			
            Z_BUNDLE = 4,

			TOUCH_ENCODER	= 5,
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

    class SubCtrlPickPlace4Axis : ASubControl, IPickPlace
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
        public SubCtrlPickPlace4Axis(Task.RunningTaskEx tRunningTask)
            : base(tRunningTask)
        {
        }
        #endregion </CONSTRUCTOR>

        #region <INTERFACE>
        public MOTION_RESULT MoveReadyPosition(double dReadyPos, int nPreDelay, int nPostDelay)
        {
            int[] arAxis = new int[AXIS_COUNT];
            double[] arReadyPosition = new double[AXIS_COUNT];

            for (int nAxisCount = 0; nAxisCount < AXIS_COUNT; ++nAxisCount)
            {
                arReadyPosition[nAxisCount] = dReadyPos;
            }

            arAxis[(int)EN_AXIS.Z1] = p_dicOfMotion[(int)EN_AXIS.Z1];
            arAxis[(int)EN_AXIS.Z2] = p_dicOfMotion[(int)EN_AXIS.Z2];
            arAxis[(int)EN_AXIS.Z3] = p_dicOfMotion[(int)EN_AXIS.Z3];
            arAxis[(int)EN_AXIS.Z4] = p_dicOfMotion[(int)EN_AXIS.Z4];

            return m_InstanceTask.MoveSyncVectorMotion(arAxis, arReadyPosition, -1, MOTION_SPEED_CONTENT.RUN, 100, true, false, nPostDelay, nPreDelay);
        }
        public MOTION_RESULT MoveSearchStartPosition(double dSearchStartPos, int nPreDelay, int nPostDelay)
        {
            int[] arAxis = new int[AXIS_COUNT];
            double[] arSearchPosition = new double[AXIS_COUNT];
            for (int nAxisCount = 0; nAxisCount < AXIS_COUNT; ++nAxisCount)
            {
                arSearchPosition[nAxisCount] = dSearchStartPos;
            }

            arAxis[(int)EN_AXIS.Z1] = p_dicOfMotion[(int)EN_AXIS.Z1];
            arAxis[(int)EN_AXIS.Z2] = p_dicOfMotion[(int)EN_AXIS.Z2];
            arAxis[(int)EN_AXIS.Z3] = p_dicOfMotion[(int)EN_AXIS.Z3];
            arAxis[(int)EN_AXIS.Z4] = p_dicOfMotion[(int)EN_AXIS.Z4];

            return m_InstanceTask.MoveSyncVectorMotion(arAxis, arSearchPosition, -1, MOTION_SPEED_CONTENT.RUN, 100, true, false, nPostDelay, nPreDelay);
        }

        public MOTION_RESULT MoveContactPosition(double dSearchEndPos, double dSearchSpeed, int nSpeedRatio, bool bTouchUsed, double dTouchGap, int nPreDelay, int nPostDelay)
		{
            if (bTouchUsed)
            {
                int nAxisZ = p_dicOfMotion[(int)EN_AXIS.Z_BUNDLE];

                int nEncoderIndex = p_dicOfMotion[(int)EN_AXIS.TOUCH_ENCODER];

                m_InstanceTask.SetPostion(nEncoderIndex, 0);

                double dblTouchThreshold = m_InstanceTask.GetAxisActualPosition(nEncoderIndex) + dTouchGap;

                return m_InstanceTask.MoveUntilTouch(nAxisZ, dSearchEndPos - 1, nEncoderIndex, dblTouchThreshold, dSearchSpeed, MOTION_SPEED_CONTENT.RUN, nSpeedRatio, nPostDelay, nPreDelay);
            }
            else
            {
                int[] arAxis = new int[AXIS_COUNT];
                double[] arSearchPosition = new double[AXIS_COUNT];
                for (int nAxisCount = 0; nAxisCount < AXIS_COUNT; ++nAxisCount)
                {
                    arSearchPosition[nAxisCount] = dSearchEndPos;
                }

                arAxis[(int)EN_AXIS.Z1] = p_dicOfMotion[(int)EN_AXIS.Z1];
                arAxis[(int)EN_AXIS.Z2] = p_dicOfMotion[(int)EN_AXIS.Z2];
                arAxis[(int)EN_AXIS.Z3] = p_dicOfMotion[(int)EN_AXIS.Z3];
                arAxis[(int)EN_AXIS.Z4] = p_dicOfMotion[(int)EN_AXIS.Z4];

                return m_InstanceTask.MoveSyncVectorMotion(arAxis, arSearchPosition, 0, MOTION_SPEED_CONTENT.RUN, nSpeedRatio, true, false, nPostDelay, nPreDelay);
            }
		}
        public bool IsTouched(bool bTouchUsed)
		{
            if (!bTouchUsed)
                return true;

            int nAxis = p_dicOfMotion[(int)EN_AXIS.Z_BUNDLE];

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
			int[] arAxis	= new int[AXIS_COUNT];
			double[] arReleasePosition	= new double[AXIS_COUNT];

			for (int nAxisIndex = 0; nAxisIndex < AXIS_COUNT; ++nAxisIndex)
			{
                double dCurrntPos = m_InstanceTask.GetAxisCommandPosition(p_dicOfMotion[nAxisIndex]);
				arReleasePosition[nAxisIndex] =  dCurrntPos + dReleaseLevel;
			}

			arAxis[(int)EN_AXIS.Z1] = p_dicOfMotion[(int)EN_AXIS.Z1];
			arAxis[(int)EN_AXIS.Z2] = p_dicOfMotion[(int)EN_AXIS.Z2];
			arAxis[(int)EN_AXIS.Z3] = p_dicOfMotion[(int)EN_AXIS.Z3];
			arAxis[(int)EN_AXIS.Z4] = p_dicOfMotion[(int)EN_AXIS.Z4];

            return m_InstanceTask.MoveSyncVectorMotion(arAxis, arReleasePosition, -1, MOTION_SPEED_CONTENT.RUN, nSpeedRatio, true, false, nPostDelay, nPreDelay);
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
