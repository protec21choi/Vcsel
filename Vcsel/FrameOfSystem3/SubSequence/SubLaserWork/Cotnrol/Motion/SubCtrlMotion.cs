using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FrameOfSystem3.Recipe;
using FrameOfSystem3.SubSequence.SubLaserWork.LaserMotionControl;
using TickCounter_;
using Motion_;

namespace FrameOfSystem3.SubSequence.SubLaserWork
{
    namespace LaserMotionControl
    {
        public enum EN_AXIS
        {
            Z = 0,
        }
    }

    class SubCtrlLaserMotion : ASubControl, ILaserMotionControl
    {
        #region <FIELD>
        private int m_nSeqNum = 0;

        private TickCounter m_TimeDelay = new TickCounter();
        #endregion </FIELD>

        #region <CONSTRUCTOR>
        public SubCtrlLaserMotion(Task.RunningTaskEx tRunningTask)
            : base(tRunningTask)
        {
        }
        #endregion </CONSTRUCTOR>

        #region <INTERFACE>
        public MOTION_RESULT MoveDuringLaser(bool bUsed, double[] arLevel, double[] arFinalVelocity, double[] arTime)
        {
            if (!bUsed || arLevel.Length == 0)
            {
                return MOTION_RESULT.OK;
            }
            double[] arPos = new double[arLevel.Length];
            double CurrentPos = m_InstanceTask.GetAxisCommandPosition(p_dicOfMotion[(int)EN_AXIS.Z]);
            for (int Step = 0; Step < arLevel.Length; Step++ )
            {
                arPos[Step] = CurrentPos + arLevel[Step];
            }
            return m_InstanceTask.MovePVT(p_dicOfMotion[(int)EN_AXIS.Z], arPos.Length, arPos, arFinalVelocity, arTime, false);

        }
       
        public bool CheckMotionDone()
        {
            return m_InstanceTask.IsAxisMotionDone(p_dicOfMotion[(int)EN_AXIS.Z]);
        }
        #endregion </INTERFACE>
    }
}
