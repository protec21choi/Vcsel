using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameOfSystem3.SubSequence
{
    // OBJECT ROLE : 재사용 가능한 단위 시퀀스를 위해 방법(컨트롤)을 제공한다. 
    public abstract class ASubControl
    {
        #region <FIELD>

        #region Control Index
        /// <summary>
        /// KEY int : SUB CONTROL 에서 정의된 DEVICE INDEX
        /// VALUE int : TASK 에서 정의된 DEVICE INDEX
        /// </summary>
        protected Dictionary<int, int> p_dicOfMotion = new Dictionary<int, int>();
        protected Dictionary<int, int> p_dicOfCylinder = new Dictionary<int, int>();
        protected Dictionary<int, int> p_dicOfDigitalInput = new Dictionary<int, int>();
        protected Dictionary<int, int> p_dicOfDigitalOutput = new Dictionary<int, int>();
        protected Dictionary<int, int> p_dicOfAnalogInput = new Dictionary<int, int>();
        protected Dictionary<int, int> p_dicOfAnalogOutput = new Dictionary<int, int>();
        protected Dictionary<int, int> p_dicOfSocket = new Dictionary<int, int>();
        protected Dictionary<int, int> p_dicOfSerial = new Dictionary<int, int>();
        #endregion 

        #region Instance
        protected Task.RunningTaskEx m_InstanceTask = null;
        protected Motion_.Motion p_instanceMotion = null;
        protected DigitalIO_.DigitalIO p_instanceDigital = null;
        protected AnalogIO_.AnalogIO m_InstanceAnalog = null;
        protected Socket_.Socket p_instanceSocket = null;
        protected Serial_.Serial p_instanceSerial = null;
        protected Config.ConfigDevice m_InstanceDevice = null;
        #endregion

        #endregion </FIELD>

        #region <CONSTRUCTOR>
        public ASubControl(Task.RunningTaskEx rRunningTask)
        {
            m_InstanceTask = rRunningTask;
        }
        #endregion </CONSTRUCTOR>

        #region <INTERFACE>

        #region Target Index & Parameter
        public void SetTargetMotion(int nIndex, int nTargetIndex)
        {
            if (true == p_dicOfMotion.ContainsKey(nIndex))
                return;

            p_dicOfMotion.Add(nIndex, nTargetIndex);
        }
        public void SetTargetCylinder(int nIndex, int nTargetIndex)
        {
            if (true == p_dicOfCylinder.ContainsKey(nIndex))
                return;

            p_dicOfCylinder.Add(nIndex, nTargetIndex);
        }
        public void SetTargetDigitalInput(int nIndex, int nTargetIndex)
        {
            if (true == p_dicOfDigitalInput.ContainsKey(nIndex))
                return;

            p_dicOfDigitalInput.Add(nIndex, nTargetIndex);
        }
        public void SetTargetDigitalOutput(int nIndex, int nTargetIndex)
        {
            if (true == p_dicOfDigitalOutput.ContainsKey(nIndex))
                return;

            p_dicOfDigitalOutput.Add(nIndex, nTargetIndex);
        }
        public void SetTargetAnalogInput(int nIndex, int nTargetIndex)
        {
            if (true == p_dicOfAnalogInput.ContainsKey(nIndex))
                return;

            p_dicOfAnalogInput.Add(nIndex, nTargetIndex);
        }
        public void SetTargetAnalogOutput(int nIndex, int nTargetIndex)
        {
            if (true == p_dicOfAnalogOutput.ContainsKey(nIndex))
                return;

            p_dicOfAnalogOutput.Add(nIndex, nTargetIndex);
        }
        #endregion

        #endregion </INTERFACE>
    }
}
