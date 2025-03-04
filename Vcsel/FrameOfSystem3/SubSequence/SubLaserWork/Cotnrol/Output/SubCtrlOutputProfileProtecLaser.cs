using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FrameOfSystem3.Config;
using FrameOfSystem3.Recipe;
using FrameOfSystem3.SubSequence.SubLaserWork.ProtecLaserOutputProfile;
using TickCounter_;

namespace FrameOfSystem3.SubSequence.SubLaserWork
{
    namespace ProtecLaserOutputProfile
    {
        public enum EN_DIGITAL_INPUT
        {
            READY = 0,
            ON = 1,
            ALARM = 2,
        }
        public enum EN_DIGITAL_OUTPUT
        {
            READY = 0,
            ON = 1,
            RESET = 2,
            EMO = 3,
        }
        public enum EN_SERIAL
        {
            COTNROL = 0,
        }
    }

    class SubCtrlOutputProfileProtecLaser : ASubControl, IOutputProfile
    {
        #region <ENUMERATION>
        private enum EN_OUTPUT_MODE
        {
            STEP,
            LINEAR
        }
        #endregion </ENUMERATION>

        #region <CONSTANT>
        #endregion </CONSTANT>

        #region <FIELD>
        private TickCounter m_tickCounter = new TickCounter();
        private int nLaserTime = 0;
        #endregion </FIELD>

        #region <CONSTRUCTOR>
        public SubCtrlOutputProfileProtecLaser(Task.RunningTaskEx tRunningTask)
            : base(tRunningTask)
        {
			
        }
        #endregion </CONSTRUCTOR>

        #region <INTERFACE>
        public bool CheckOutputCurrent(double dOutput)
        {
            return true;
        }
        
        public bool ReadyOutputProfile(double[] dOutput, int[] nTime, string[] sMode, bool bKeepLastValue)
        {
            nLaserTime = 0;
            foreach (int Time in nTime)
            {
                nLaserTime += Time;
            }
            return true;
            //그냥 외부에서 설정 하자
//             if (Laser.ProtecLaserMananger.GetInstance().SetParameter(p_dicOfSerial[(int)EN_SERIAL.COTNROL], dOutput, nTime))
//                 return true;
// 
//             return false;
           
        }
        /// <summary>
        /// bTimeSyncOutputs = true 인 경우, nTimeSyncCounts 의 수량만큼 TargetKey 를 수집하고, 수량이 일치할 때 동시출력한다.
        /// </summary>
        public bool StartOutputProfile(bool bTimeSyncOutputs = false, int nTimeSyncCounts = 1)
        {
            int[] arReadInputKey = null;
            bool[] arReadInputValue = null;

            arReadInputKey = new int[1];
            arReadInputValue = new bool[1];

            arReadInputKey[0] = p_dicOfDigitalInput[(int)EN_DIGITAL_INPUT.ON];

            arReadInputValue[0] = true;

//             if (false == m_InstanceTask.WriteDigitalAndRead(p_dicOfDigitalOutput[(int)EN_DIGITAL_OUTPUT.ON]
//                                                             , true
//                                                             , arReadInputKey
//                                                             , arReadInputValue))
//             {
//                 return false;
//             }

            //임시
            m_InstanceTask.WriteDigitalOutput(p_dicOfDigitalOutput[(int)EN_DIGITAL_OUTPUT.ON], true);

            m_tickCounter.SetTickCount((uint)nLaserTime);
            return true;
        }
        public bool WorkingOutputProfile(ref int nElapsedTime)
        {
            nElapsedTime = (int)m_tickCounter.GetTickCount();
            if (false == m_InstanceTask.ReadDigitalInput(p_dicOfDigitalInput[(int)EN_DIGITAL_INPUT.ON], false, 0)
                && m_tickCounter.IsTickOver(true))
            {
                return true;
            }

            return false;
        }
        public bool StopOutputProfile(bool bKeepLastValue, bool bTimeSyncOutputs = false, int nTimeSyncCounts = 1)
        {
            int[] arReadInputKey = null;
            bool[] arReadInputType = null;

            arReadInputKey = new int[1];
            arReadInputType = new bool[1];

            arReadInputKey[0] = p_dicOfDigitalInput[(int)EN_DIGITAL_INPUT.ON];

            arReadInputType[0] = false;
// 
//             if (false == m_InstanceTask.WriteDigitalAndRead(p_dicOfDigitalOutput[(int)EN_DIGITAL_OUTPUT.ON]
//                                                             , false
//                                                             , arReadInputKey
//                                                             , arReadInputType))
//             {
//                 return false;
//             }
            m_InstanceTask.WriteDigitalOutput(p_dicOfDigitalOutput[(int)EN_DIGITAL_OUTPUT.ON], false);

            return true;
        }
        #endregion </INTERFACE>

        #region <METHOD>

        #endregion </METHOD>
    }
}
