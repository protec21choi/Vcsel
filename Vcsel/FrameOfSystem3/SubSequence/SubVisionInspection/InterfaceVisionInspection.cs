using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Motion_;
using Vision_;

namespace FrameOfSystem3.SubSequence.SubVisionInspection
{
    #region <INTERFACE CLASS>
    public interface IVisionInspection
    {
        VISION_RESULT ChangeAlgorism(int nCamNo, int nAlgorismNo);
        VISION_RESULT Inspection(int nCamNo);
        VISION_RESULT GetResult(int nCamNo);

        VISION_RESULT Set4PCalibration(int nCamNo, double dDistX, double dDistY);
        VISION_RESULT Grab(int nCamNo);

        MOTION_RESULT MovePosition(double dPosX, double dPosY, int nDelay = 100);
        DPointXY GetActualPosition();
        SubSeqInspectionResult GetInspectionResult();
    }
    #endregion </INTERFACE CLASS>
}
