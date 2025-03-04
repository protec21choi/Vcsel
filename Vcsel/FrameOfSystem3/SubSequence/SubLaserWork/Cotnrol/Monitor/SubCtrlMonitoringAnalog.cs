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
    namespace AnalogMonitor
    {
        public enum EN_ANALOG_INPUT
        {
            TEMP = 0,
            POWER = 0,
        }
    }

    //2021.05.26 [ADD] by wdw Ajin List 출력 
    //Analog 직접 제어 함으로 Init Deivice 등록 시 TargetIndex 등록
    class SubCtrlMonitoringAnalog : ASubControl, IMonitoringControl
    {
        #region <CONSTANT>
        #endregion </CONSTANT>

        #region <FIELD>
        #endregion </FIELD>

        #region <CONSTRUCTOR>
        public SubCtrlMonitoringAnalog(Task.RunningTaskEx tRunningTask)
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

            return true;
        }

        //Abort면 true;
        public bool CheckAbort(bool bUsed, double dAbortTemp)
        {
            if (!bUsed)
                return false;

            if (m_InstanceTask.ReadAnalogInputValue(p_dicOfAnalogInput[(int)EN_ANALOG_INPUT.TEMP]) > dAbortTemp)
                return true;

            return false;
        }
        public double GetTemp()
        {
            return m_InstanceTask.ReadAnalogInputValue(p_dicOfAnalogInput[(int)EN_ANALOG_INPUT.TEMP]);
        }

        //EMG면 true;
        public bool CheckEMG(bool bUsed, double dEMGTemp)
        {
            if (!bUsed)
                return false;

            if (m_InstanceTask.ReadAnalogInputValue(p_dicOfAnalogInput[(int)EN_ANALOG_INPUT.TEMP]) > dEMGTemp)
                return true;

            return false;
        }

        public bool CheckPower(bool bUsed, double dTarget, double dTolerance)
        {
            if (!bUsed)
                return true;

            double dDev = Math.Abs(m_InstanceTask.ReadAnalogInputValue(p_dicOfAnalogInput[(int)EN_ANALOG_INPUT.POWER]) - dTarget);
            //dTolerance는 %
            if (dDev / dTarget < dTolerance)
                return true;

            return false;
        }
        public bool StopMonitor(bool bUsed)
        {
            if (!bUsed)
                return true;

            return true;
        }
        #endregion </INTERFACE>

 
    }
}
