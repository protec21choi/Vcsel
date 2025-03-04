using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Define.DefineEnumProject.SubSequence;
using Vision_;
using Motion_;
using TickCounter_;

namespace FrameOfSystem3.SubSequence.SubVisionInspection
{
    #region <VALUE CLASS>
    
    public class SubSeqInsp4PCalibrationParam : SubSequenceParam
    {
        public int CameraNo = 0;
        public int AlgorithmNo = 0;

        // GRAB POSITION XY
        public double PositionX = 0.0;
        public double PositionY = 0.0;
        public double DistanceX = 0.0;
        public double DistanceY = 0.0;

        public int DelayForGrab = 0;
    }
    #endregion </VALUE CLASS>

    public class SubSeqInsp4PCalibration : ASubSequence
    {
        #region <ENUMERATION>
        private enum EN_INSPECTION_STEP
        {
            READY = 0,

            MOVE_POSITION = 100,
            GRAB_IMAGE = 200,
            GET_RESULT = 300,

            FINISH = 1000,
        }
        #endregion </ENUMERATION>

        #region <CONSTANT>
        private const int INSP = 0;
        #endregion </CONSTANT>

        #region <FIELD>
        private IVisionInspection m_SubControl = null;

        private SubSeqInsp4PCalibrationParam[] m_SubSeqParam = null;

        // 검색 대상(2 Points)의 수정된 축 좌표 (Camera > Axis 좌표)
        private DPointXY[] m_dpAxisPos = new DPointXY[4];

        private TickCounter m_TimeDelay = new TickCounter();
        private int m_nPointIndex = 0;
        private int m_nRetryCount = 0;
        #endregion </FIELD>

        #region <CONSTRUCTOR>
        public SubSeqInsp4PCalibration(ASubControl _control)
        {
            m_SubControl = _control as IVisionInspection;
        }
        #endregion </CONSTRUCTOR>

        #region <OVERRIDE>
        public override void AddParameter<T>(params T[] param)
        {
            m_SubSeqParam = new SubSeqInsp4PCalibrationParam[param.Length];

            for (int i = 0; i < param.Length; i++)
            {
                m_SubSeqParam[i] = param[i] as SubSeqInsp4PCalibrationParam;
            }
        }
        public override EN_SUBSEQUENCE_RESULT SubSequenceProcedure()
        {
            if (Activate.Equals(false))
                return EN_SUBSEQUENCE_RESULT.OK;

            VISION_RESULT enResult;

            switch (m_nStepNo)
            {
                #region <READY>
                case (int)EN_INSPECTION_STEP.READY:
                    m_nPointIndex = 0;
                    m_nRetryCount = 0;
                    m_nStepNo++;
                    break;

                case (int)EN_INSPECTION_STEP.READY + 1:
                    DPointXY dpDistance = CalculateDistance();
                    enResult = m_SubControl.Set4PCalibration(m_SubSeqParam[INSP].CameraNo, dpDistance.x, dpDistance.y);
                    
                    switch (enResult)
                    {
                        case VISION_RESULT.IN_PROCESS:
                        case VISION_RESULT.NOT_COMPLETE:
                            break;

                        case VISION_RESULT.COMPLETE:
                            m_nStepNo = (int)EN_INSPECTION_STEP.MOVE_POSITION;
                            break;

                        case VISION_RESULT.ERROR_COMMAND:
                            if (m_nRetryCount > 3)
                            {
                                Activate = false;
                                return EN_SUBSEQUENCE_RESULT.ERROR_COMMAND;
                            }
                            m_nStepNo = (int)EN_INSPECTION_STEP.FINISH;
                            break;
                        case VISION_RESULT.ERROR_VISION:
                            if (m_nRetryCount > 3)
                            {
                                Activate = false;
                                return EN_SUBSEQUENCE_RESULT.ERROR_VISION;
                            }
                            m_nStepNo = (int)EN_INSPECTION_STEP.FINISH;
                            break;
                        case VISION_RESULT.TIMEOUT_VISION:
                            if (m_nRetryCount > 3)
                            {
                                Activate = false;
                                return EN_SUBSEQUENCE_RESULT.ERROR_TIMEOUT;
                            }
                            m_nStepNo = (int)EN_INSPECTION_STEP.FINISH;
                            break;
                    }
                    break;
                #endregion </READY>

                #region <MOVE_POSITION>
                case (int)EN_INSPECTION_STEP.MOVE_POSITION:
                    m_nRetryCount = 0;

                    DPointXY dpPosition = CalculatePosition();

                    if (m_SubControl.MovePosition(dpPosition.x, dpPosition.y) != MOTION_RESULT.OK)
                    {
                        Activate = false;
                        return EN_SUBSEQUENCE_RESULT.ERROR_MOTION;
                    }
                    m_TimeDelay.SetTickCount((uint)m_SubSeqParam[INSP].DelayForGrab);
                    m_nRetryCount++;
                    break;
                case (int)EN_INSPECTION_STEP.MOVE_POSITION + 1:
                    if (m_TimeDelay.IsTickOver(true))
                        m_nStepNo = (int)EN_INSPECTION_STEP.GRAB_IMAGE;
                    break;
                #endregion </MOVE_POSITION>

                #region <GRAB_IMAGE>
                case (int)EN_INSPECTION_STEP.GRAB_IMAGE:
                    enResult = m_SubControl.Grab(m_SubSeqParam[INSP].CameraNo);

                    switch (enResult)
                    {
                        case VISION_RESULT.IN_PROCESS:
                        case VISION_RESULT.NOT_COMPLETE:
                            break;

                        case VISION_RESULT.COMPLETE:
                            m_nStepNo = (int)EN_INSPECTION_STEP.GET_RESULT;
                            break;

                        case VISION_RESULT.ERROR_COMMAND:
                            if (m_nRetryCount > 3)
                            {
                                Activate = false;
                                return EN_SUBSEQUENCE_RESULT.ERROR_COMMAND;
                            }

                            m_nRetryCount++;
                            break;
                        case VISION_RESULT.ERROR_VISION:
                            if (m_nRetryCount > 3)
                            {
                                Activate = false;
                                return EN_SUBSEQUENCE_RESULT.ERROR_VISION;
                            }

                            m_nRetryCount++;
                            break;
                        case VISION_RESULT.TIMEOUT_VISION:
                            if (m_nRetryCount > 3)
                            {
                                Activate = false;
                                return EN_SUBSEQUENCE_RESULT.ERROR_TIMEOUT;
                            }

                            m_nRetryCount++;
                            break;
                    }
                    break;
                #endregion </GRAB_IMAGE>

                #region <GET_RESULT>
                case (int)EN_INSPECTION_STEP.GET_RESULT:
                    switch (m_nPointIndex)
                    {
                        case 0: // RIGHT
                        case 1: // LEFT
                        case 2: // TOP
                            m_nPointIndex++;
                            m_nStepNo = (int)EN_INSPECTION_STEP.MOVE_POSITION;
                            break;
                        case 3: // BOTTOM
                            m_nStepNo = (int)EN_INSPECTION_STEP.FINISH;
                            break;
                    }
                    break;
                #endregion </GET_RESULT>

                #region <FINISH>
                case (int)EN_INSPECTION_STEP.FINISH:
                    Activate = false;

                    return EN_SUBSEQUENCE_RESULT.OK;
                #endregion </FINISH>
            }
            return EN_SUBSEQUENCE_RESULT.WORKING;
        }
        #endregion </OVERRIDE>

        #region <METHOD>
        /// <summary>
        /// 이동 거리 계산하기
        /// </summary>
        private DPointXY CalculateDistance()
        {
            DPointXY dpDistance = new DPointXY(m_SubSeqParam[INSP].DistanceX, m_SubSeqParam[INSP].DistanceY);

            dpDistance.x *= 1000;   // 단위변환 mm > um
            dpDistance.y *= 1000;   // 단위변환 mm > um
            dpDistance.x *= 2;      // 이동거리
            dpDistance.y *= 2;      // 이동거리

            return dpDistance;
        }
        /// <summary>
        /// 이동 좌표 계산하기
        /// </summary>
        private DPointXY CalculatePosition()
        {
            DPointXY dpPosition = new DPointXY(m_SubSeqParam[INSP].PositionX, m_SubSeqParam[INSP].PositionY);

            switch (m_nPointIndex)
            {
                case 0:
                    dpPosition.x += m_SubSeqParam[INSP].DistanceX;
                    break;
                case 1:
                    dpPosition.x -= m_SubSeqParam[INSP].DistanceX;
                    break;
                case 2:
                    dpPosition.y += m_SubSeqParam[INSP].DistanceY;
                    break;
                case 3:
                    dpPosition.y -= m_SubSeqParam[INSP].DistanceY;
                    break;
            }

            return dpPosition;
        }
        #endregion </METHOD>
    }
}
