using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Motion_;
using Vision_;
using FrameOfSystem3.SubSequence.SubVisionInspection.Inspection;
using FrameOfSystem3.Controller.Vision;

namespace FrameOfSystem3.SubSequence.SubVisionInspection
{
    namespace Inspection
    {
        public enum EN_AXIS
        {
            X,
            Y,
            Z,
        }
    }

    class SubCtrlInspection : ASubControl, IVisionInspection
    {
        #region <FIELD>
        private Vision_.Vision m_Vision = Vision_.Vision.GetInstance();

        private RequestDataOfProtecVision m_VisionRequest = new RequestDataOfProtecVision(0, null);
        private VisionResultData m_VisionResult = new VisionResultData();
        #endregion </FIELD>

        #region <CONSTRUCTOR>
        public SubCtrlInspection(Task.RunningTaskEx tRunningTask)
            : base(tRunningTask)
        {
        }
        #endregion </CONSTRUCTOR>

        #region <INTERFACE>
        public VISION_RESULT ChangeAlgorism(int nCamNo, int nAlgorismNo)
        {
            return m_Vision.ChangeScene(nCamNo, nAlgorismNo);
        }
        public VISION_RESULT Inspection(int nCamNo)
        {
            return m_Vision.ExecuteInspection(nCamNo, m_VisionRequest);
        }
        public VISION_RESULT GetResult(int nCamNo)
        {
            return m_Vision.GetVisionResult(nCamNo, ref m_VisionResult);
        }

        public VISION_RESULT Set4PCalibration(int nCamNo, double dDistX, double dDistY)
        {
            return m_Vision.ExcuteResolutionCalibration(nCamNo, dDistX, dDistY);
        }
        public VISION_RESULT Grab(int nCamNo)
        {
            return m_Vision.GrabImage(nCamNo, m_VisionRequest);
        }

        //Ratio 추가

        public MOTION_RESULT MovePosition(double dPosX, double dPosY)
        {
            m_InstanceTask.ClearMoveMotion();

            int nAxisX = p_dicOfMotion[(int)EN_AXIS.X];
            int nAxisY = p_dicOfMotion[(int)EN_AXIS.Y];

            m_InstanceTask.AddMoveAbsolutely(nAxisX, dPosX);
            m_InstanceTask.AddMoveAbsolutely(nAxisY, dPosY);

            return m_InstanceTask.MoveMotion();
        }
        public MOTION_RESULT MovePosition(double dPosX, double dPosY, int nRatio = 100)
        {
            m_InstanceTask.ClearMoveMotion();

            int nAxisX = p_dicOfMotion[(int)EN_AXIS.X];
            int nAxisY = p_dicOfMotion[(int)EN_AXIS.Y];

            m_InstanceTask.AddMoveAbsolutely(nAxisX, dPosX, nRatio);
            m_InstanceTask.AddMoveAbsolutely(nAxisY, dPosY, nRatio);

            return m_InstanceTask.MoveMotion();
        }
        public DPointXY GetActualPosition()
        {
            DPointXY dpActPos;

            dpActPos.x = m_InstanceTask.GetAxisActualPosition(p_dicOfMotion[(int)EN_AXIS.X]);
            dpActPos.y = m_InstanceTask.GetAxisActualPosition(p_dicOfMotion[(int)EN_AXIS.Y]);

            return dpActPos;
        }
        public SubSeqInspectionResult GetInspectionResult()
        {
            SubSeqInspectionResult InspResult = new SubSeqInspectionResult();

            Vision_.DPointXYT dPosition = new Vision_.DPointXYT();

            m_VisionResult.GetVisionResult(0, ref dPosition);

            InspResult.PositionX = dPosition.x;
            InspResult.PositionY = dPosition.y;
            InspResult.PositionT = dPosition.t;

            InspResult.ID = m_VisionResult.Message;

            return InspResult;
        }
        #endregion </INTERFACE>
    }
}
