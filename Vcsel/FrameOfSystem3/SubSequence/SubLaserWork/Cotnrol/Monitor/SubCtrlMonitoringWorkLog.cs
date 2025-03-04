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

    //2021.05.26 [ADD] by wdw Ajin List 출력 
    //Analog 직접 제어 함으로 Init Deivice 등록 시 TargetIndex 등록
    class SubCtrlMonitoringWorkLog : ASubControl, IMonitoringControl
    {
        #region <FIELD>
        private Log.WorkLog m_WorkLog = Log.WorkLog.GetInstance();
        #endregion </FIELD>

        #region <CONSTRUCTOR>
        public SubCtrlMonitoringWorkLog(Task.RunningTaskEx tRunningTask)
            : base(tRunningTask)
        {
			m_InstanceDevice	= Config.ConfigDevice.GetInstance();
			m_InstanceAnalog	= AnalogIO_.AnalogIO.GetInstance();
        }
        #endregion </CONSTRUCTOR>

        #region <INTERFACE>
        public bool StartMonitor(bool bUsed)
        {
            if (!bUsed)
                return true;

            m_WorkLog.SaveStart();
            return true;
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

            m_WorkLog.SaveStop();
            return true;
        }
        #endregion </INTERFACE>

 
    }
}
