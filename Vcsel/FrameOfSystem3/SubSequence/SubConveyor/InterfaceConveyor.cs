using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameOfSystem3.SubSequence.SubConveyor
{
    #region <INTERFACE CLASS>
    interface IConveyor
    {
        void StopperOn();
        bool CheckEntry();
        bool MoveForward();
        bool CheckApproach();
        void MoveSlow(int nSpeedRatio);
        bool CheckArrived(string sStopDelayMode);
        void MoveStop();

        void StopperOff();
        bool CheckExit();
    }
    #endregion </INTERFACE CLASS>
}
