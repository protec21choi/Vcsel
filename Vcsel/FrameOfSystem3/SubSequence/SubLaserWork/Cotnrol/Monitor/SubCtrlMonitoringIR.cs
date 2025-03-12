using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FrameOfSystem3.Config;
using FrameOfSystem3.Recipe;
using FrameOfSystem3.SubSequence.SubLaserWork.AnalogMonitor;
using TickCounter_;

namespace FrameOfSystem3.SubSequence.SubLaserWork
{

    //Analog 직접 제어 함으로 Init Deivice 등록 시 TargetIndex 등록
    class SubCtrlMonitoringIR : ASubControl, IMonitoringControl
    {
        #region <FIELD>
        //ExternalDevice.Socket.IR m_IR = ExternalDevice.Socket.IR.GetInstance();
        #endregion </FIELD>

        #region <CONSTRUCTOR>
        public SubCtrlMonitoringIR(Task.RunningTaskEx tRunningTask)
            : base(tRunningTask)
        {
			//m_IR = ExternalDevice.Socket.IR.GetInstance();
        }
        #endregion </CONSTRUCTOR>

        #region <INTERFACE>
        public bool StartMonitor(bool bUsed)
        {
            if (!bUsed)
                return true;

            //if (m_IR.DoWorkStart() == ExternalDevice.Socket.IR_Property.Enumerable.EN_SEQUENCE_RESULT.OK)
            //    return true;
            else 
                return false;
        }

        //Abort면 true;
        public bool CheckAbort(bool bUsed, double dAbortValue)
        {
            if (!bUsed)
                return false;


            return false;
        }
        public double GetTemp()
        {
            return 0;
        }

        //EMG면 true;
        public bool CheckEMG(bool bUsed, double dEMGTemp)
        {
            if (!bUsed)
                return false;

            return false;
        }

        public bool CheckPower(bool bUsed, double dTarget, double dTolerance)
        {
            if (!bUsed)
                return true;

            return false;
        }

        public bool StopMonitor(bool bUsed)
        {
            if (!bUsed)
                return true;

            //if (m_IR.DoWorkEnd() != ExternalDevice.Socket.IR_Property.Enumerable.EN_SEQUENCE_RESULT.WORKING)
            //    return true;
            else 
                return false;
        }
        #endregion </INTERFACE>

 
    }
}
