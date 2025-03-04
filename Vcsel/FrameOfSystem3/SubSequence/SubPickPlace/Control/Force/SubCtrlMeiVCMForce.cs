using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FrameOfSystem3.SubSequence.SubPickPlace.MeiVCMForce;

using Motion_;

namespace FrameOfSystem3.SubSequence.SubPickPlace
{
    namespace MeiVCMForce
    {
        public enum EN_AXIS
        {
            FORCE = 0,
        }
    }

    class SubCtrlMeIVcmForce : ASubControl, IPickPlaceForce
    {
        #region <CONSTRUCTOR>
        public SubCtrlMeIVcmForce(Task.RunningTaskEx tRunningTask)
            : base(tRunningTask)
        {
        }
        #endregion </CONSTRUCTOR>

        #region <INTERFACE>
        public bool SetForce(double dForce)
		{
            return m_InstanceTask.SetGainOffset(p_dicOfMotion[(int)EN_AXIS.FORCE], dForce);
		}
        #endregion </INTERFACE>
    }
}
