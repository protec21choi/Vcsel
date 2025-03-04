using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FrameOfSystem3.SubSequence.SubConveyor.Conveyor;

using Motion_;

namespace FrameOfSystem3.SubSequence.SubConveyor
{
    namespace Conveyor
    {
        public enum EN_AXIS
        {
            CONVEYOR
        }
        public enum EN_CYLINDER
        {
            STOPPER,
            STOPPER_SIDE
        }
        public enum EN_DIGITAL_INPUT
        {
            IN,
            EXIST,
            ARRIVED,
            OUT,
        }
        public enum EN_PARAMETER
        {
            DECEL_DELAY,
            DECEL_RATIO,
            STOP_DELAY,
            STOP_MODE, //ALIVE SENESOR, AFTER DECEL
            UNLOAD_DELAY,
        }
    }

    class SubCtrlConveyor : ASubControl, IConveyor
    {
        #region <CONSTRUCTOR>
        public SubCtrlConveyor(Task.RunningTaskEx tRunningTask)
            : base(tRunningTask)
        {
        }
        #endregion </CONSTRUCTOR>

        #region <INTERFACE>
        public void StopperOn()
        {
            m_InstanceTask.MoveCylinderForward(p_dicOfCylinder[(int)EN_CYLINDER.STOPPER], false);

            if (p_dicOfCylinder.ContainsKey((int)EN_CYLINDER.STOPPER_SIDE))
                m_InstanceTask.MoveCylinderForward(p_dicOfCylinder[(int)EN_CYLINDER.STOPPER_SIDE], true);

            return;
        }
        public bool CheckEntry()
        {
            int nIndexIn = p_dicOfDigitalInput[(int)EN_DIGITAL_INPUT.IN];
            int nIndexExist = p_dicOfDigitalInput[(int)EN_DIGITAL_INPUT.EXIST];

            if (m_InstanceTask.ReadDigitalInput(nIndexIn, true, 1000)
                || m_InstanceTask.ReadDigitalInput(nIndexExist, true, 1000))
                return true;

            return false;
        }
        public bool MoveForward()
        {
            m_InstanceTask.ClearMoveMotion();
            m_InstanceTask.SetPostion(p_dicOfMotion[(int)EN_AXIS.CONVEYOR], 0);

            if (m_InstanceTask.MoveSpeedDirection(p_dicOfMotion[(int)EN_AXIS.CONVEYOR], true) != MOTION_RESULT.OK)
                return false;

            return true;
        }
        public bool CheckApproach()
        {
            return m_InstanceTask.ReadDigitalInput(p_dicOfDigitalInput[(int)EN_DIGITAL_INPUT.EXIST], true, 1000);
        }
        public void MoveSlow(int nSpeedRatio)
        {
            m_InstanceTask.MoveOverrideSpeed(p_dicOfMotion[(int)EN_AXIS.CONVEYOR], nSpeedRatio, MOTION_SPEED_CONTENT.JOG_HIGH);
        }
        public bool CheckArrived(string sStopDelayMode)
        {
            string sDetectSensor = Define.DefineEnumProject.Transfer.Conveyor.EN_STOP_MODE.DETECT_SENSOR.ToString();

            bool bDetectSensor = sStopDelayMode.Equals(sDetectSensor);

            int nIndex = p_dicOfDigitalInput[(int)EN_DIGITAL_INPUT.ARRIVED];

            if (bDetectSensor && !m_InstanceTask.ReadDigitalInput(nIndex, true, 1000))
                return false;
            
            return true;
        }
        public void MoveStop()
        {
            m_InstanceTask.StopMotion(p_dicOfMotion[(int)EN_AXIS.CONVEYOR]);
        }

        public void StopperOff()
        {
            m_InstanceTask.MoveCylinderBackward(p_dicOfCylinder[(int)EN_CYLINDER.STOPPER], true);

            if (p_dicOfCylinder.ContainsKey((int)EN_CYLINDER.STOPPER_SIDE))
                m_InstanceTask.MoveCylinderBackward(p_dicOfCylinder[(int)EN_CYLINDER.STOPPER_SIDE], true);
            
            return;
        }
        public bool CheckExit()
        {
            int nIndexArived = p_dicOfDigitalInput[(int)EN_DIGITAL_INPUT.ARRIVED];
            int nIndexOut = p_dicOfDigitalInput[(int)EN_DIGITAL_INPUT.OUT];

            if (m_InstanceTask.ReadDigitalInput(nIndexArived, false, 0)
                || m_InstanceTask.ReadDigitalInput(nIndexOut, false, 0))
            {
                return false;
            }

            return true;
        }

        #endregion </INTERFACE>
    }
}
