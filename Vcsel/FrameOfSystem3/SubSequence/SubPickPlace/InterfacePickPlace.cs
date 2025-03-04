using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Motion_;

namespace FrameOfSystem3.SubSequence.SubPickPlace
{
    #region <INTERFACE CLASS>
	/// <summary>
	/// 2022.01.11 by twkang [ADD] 단일축 + AutoTouch 기능을 이용하는 인터페이스
    /// 2022.05.20 by jhlee [Modify] Bonding 작업 후 Vaccum 사용하는 경우 - Vacuum On == false , Blow On == false
	/// </summary>
	public interface IPickPlace
	{
        MOTION_RESULT MoveReadyPosition(double dReadyPos, int nPreDelay, int nPostDelay);
        MOTION_RESULT MoveSearchStartPosition(double dSearchStartPos, int nPreDelay, int nPostDelay);

        MOTION_RESULT MoveContactPosition(double dSearchEndPos, double SearchSpeed, int nSpeedRatio, bool bTouchUsed, double dTouchGap, int nPreDelay, int nPostDelay);
        bool IsTouched(bool bTouchUsed);
        bool GetTouchedData(ref double TouchedPosition, ref double TouchedEncorder);

        MOTION_RESULT MoveReleasePosition(double dReleaseLevel, double RealeaseSpeed, int nSpeedRatio, int nPreDelay, int nPostDelay);

		void VacuumOnBlowOff();
		void VacuumOffBlowOn(bool bVacuumKeepUsed = false, bool bBlowUsed = true);
		void BlowOff();

		bool CheckVacuum(double dVacuumThreshold);
	}

    public interface IPickPlaceForce
    {
        bool SetForce(double dVacuumThreshold);
    }
    #endregion </INTERFACE CLASS>

	
}
