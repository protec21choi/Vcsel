using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FrameOfSystem3.Recipe;
using FrameOfSystem3.SubSequence.SubLaserWork.PetidModulateionControl;
using TickCounter_;

namespace FrameOfSystem3.SubSequence.SubLaserWork
{
    namespace PetidModulateionControl
    {
        public enum EN_DIGITAL_INPUT
        {
            READY = 0,
            POWER_ON = 1,
            POWER_SUPPLY = 2,
            EMISSION = 3,
        }
        public enum EN_DIGITAL_OUTPUT
        {
            REMOTE_KEY = 0,
            REMOTE_START = 1,
            EMISSION = 2,
        }
        public enum EN_SOCKET_INDEX
        {
            SOCKET = 0,
        }
    }

    class SubCtrlModulationPetid : ASubControl, IModulationControl
    {
        #region <FIELD>

        private TickCounter m_TimeDelay = new TickCounter();

        private Socket_.Socket m_Socket = Socket_.Socket.GetInstance();

        ExternalDevice.Socket.PetidTrigger m_PetidTrigger = ExternalDevice.Socket.PetidTrigger.GetInstance();

        int[] m_arTime = new int[] { };
        double[] m_arFrequency = new double[] { };
        int[] m_arDuty = new int[] { };
        int nStep = 0;
        #endregion </FIELD>

   
        #region <CONSTRUCTOR>
        public SubCtrlModulationPetid(Task.RunningTaskEx tRunningTask)
            : base(tRunningTask)
        {
        }
        #endregion </CONSTRUCTOR>

        #region <Enumalation>
        
        #endregion </Enumalation>

        #region <INTERFACE>
        public bool EntryModulationControl()
        {
            if (!m_PetidTrigger.Isconnected)
                m_PetidTrigger.Connect();
            return m_PetidTrigger.Isconnected;

        }
        public bool ReadyMudulationSetting(int[] arTime, double[] arFrequency, int[] arDuty)
        {
            nStep = 0;
            m_PetidTrigger.StopTrigger();
            m_arTime = arTime;
            m_arDuty = arDuty;
            m_arFrequency = arFrequency;
            return m_PetidTrigger.SetFrequencyMode(m_arFrequency[nStep], m_arDuty[nStep]);
        }
        public bool StartModulation()
        {
            m_TimeDelay.SetTickCount((uint)m_arTime[nStep]);
            return m_PetidTrigger.StartFrequencyMode(m_arFrequency[nStep], m_arDuty[nStep]);
        }

        public bool WorkingModulation()
        {
            if (m_TimeDelay.IsTickOver(true))
            {
                nStep++;
                if (nStep >= 5)
                    return true;
                m_TimeDelay.SetTickCount((uint)m_arTime[nStep]);
                return m_PetidTrigger.StartFrequencyMode(m_arFrequency[nStep], m_arDuty[nStep]);
            }
            return true;
        }
        public bool StopModulation()
        {
            return m_PetidTrigger.StopTrigger();
        }
        public bool FinishModulation()
        {
            m_PetidTrigger.Disconnect();
            return true;
        }
       
        #endregion </INTERFACE>
    }
}
