using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FrameOfSystem3.Recipe;
using FrameOfSystem3.SubSequence.SubLaserWork.HeaterControl;
using TickCounter_;

namespace FrameOfSystem3.SubSequence.SubLaserWork
{
    namespace HeaterControl
    {
        public enum EN_DIGITAL_OUTPUT
        {
            COOLING_AIR = 0,
        }
    }

    class SubCtrlLaserHeater : ASubControl, ILaserHeaterControl
    {
        #region <FIELD>

        private TickCounter m_TimeDelay = new TickCounter();

        private ExternalDevice.Heater.Heater m_Heater = ExternalDevice.Heater.Heater.GetInstance();

        
        #endregion </FIELD>
   
        #region <CONSTRUCTOR>
        public SubCtrlLaserHeater(Task.RunningTaskEx tRunningTask)
            : base(tRunningTask)
        {
        }
        #endregion </CONSTRUCTOR>

        #region <Enumalation>
        
        #endregion </Enumalation>

        #region <INTERFACE>
        public bool ReadyHeater(int nHeaterIndex)
        {
            m_InstanceTask.WriteDigitalOutput(p_dicOfDigitalOutput[(int)EN_DIGITAL_OUTPUT.COOLING_AIR], false);
            m_Heater.SetRunStatus(nHeaterIndex, true);
            return true;

        }
        public bool StartTempProfile(int nHeaterIndex)
        {
            //from here : 추후 작성
            return true;

        }
        public bool StartCooling(int nHeaterIndex, bool bHeaterOff)
        {
            m_InstanceTask.WriteDigitalOutput(p_dicOfDigitalOutput[(int)EN_DIGITAL_OUTPUT.COOLING_AIR], true);
            if (bHeaterOff)
                m_Heater.SetRunStatus(nHeaterIndex, false);
            return true;

        }
    
       
        #endregion </INTERFACE>
    }
}
