using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Define.DefineEnumProject.SubSequence;
using Define.DefineEnumProject.SubSequence.Vision;

using TickCounter_;
using Vision_;
using Motion_;

namespace FrameOfSystem3.SubSequence.SubVisionInspection
{
    #region <VALUE CLASS>
    /// <summary>
    /// Sequence 에서 사용하는 Parameter 이며 Client 로 부터 전달 받음
    /// </summary>
    public class SubSeqInspDualVisionParam : SubSequenceParam
    {
        public int CameraNo_ULC = 0;
        public int AlgorithmNo_ULC = 0;

        public int CameraNo_DLC = 0;
        public int AlgorithmNo_DLC = 0;

        // GRAB POSITION XY
        public double PositionX = 0.0;
        public double PositionY = 0.0;

		public int DelayForGrab	= 0;

		// 2021.01.06 by twkang [ADD]
		// Dryrun, Simulation 모드에서 False 로 설정하면 파라미터로 입력한 2포인트의 센터값이 결과로 나온다.
		public bool VisionUse	= true;
    }
    #endregion </VALUE CLASS>

    public class SubSeqInspDualVision : ASubSequence
    {
        #region <ENUMERATION>
        private enum EN_INSPECTION_STEP
        {
            READY = 0,

            MOVE_POSITION = 100,
            CHAGNE_ALGORISM = 200,
            GRAB_IMAGE = 300,
            GET_RESULT = 400,

            FINAL_MOVE = 500,

            FINISH = 1000,
        }
        enum EN_POINT_INDEX
        {
            LT = 0,
            RB = 1,
            RT = 2,
            LB = 3,
        }

        public enum EN_RESULT_INDEX
        {
            LT_ULC = 0,
            LT_DLC = 1,
            RB_ULC = 2,
            RB_DLC = 3,
            RT_ULC = 4,
            RT_DLC = 5,
            LB_ULC = 6,
            LB_DLC = 7,
            ULC_CENTER = 8,
            DLC_CENTER = 9,
        }
        #endregion </ENUMERATION>

        #region <FIELD>
        private IVisionInspection m_SubControl = null;

		private EN_SEQUENCE_BRANCH m_enSubSeqBrance	= EN_SEQUENCE_BRANCH.NORMAL_ACTION;

        private SubSeqInspDualVisionParam[] m_SubSeqParam = null;


        // Save For Actual Position
        private DPointXY[] m_dpAcutalAxisPos = new DPointXY[4];

        private DPointXY[] m_dpAcutalDLCPos = new DPointXY[4];
        private DPointXY[] m_dpAcutalULCPos = new DPointXY[4];

		private TickCounter m_TimeDelay = new TickCounter();
        private int m_nPointIndex = 0;
        private int m_nCamIndex = 0;
        private int m_nAlgorithmIndex = 0;
        private int m_nRetryCount = 0;
        private int m_nResultIndex = 0; 

        private int m_nPointCount = 0;

        
     
      
        #endregion </FIELD>

        #region <CONSTRUCTOR>
        public SubSeqInspDualVision(ASubControl control)
        {
            m_SubControl = control as IVisionInspection;
        }
        #endregion </CONSTRUCTOR>

        #region <OVERRIDE>
        public override void AddParameter<T>(params T[] param)
        {
            m_SubSeqParam = new SubSeqInspDualVisionParam[param.Length];

            for (int i = 0; i < param.Length; i++)
            {
                m_SubSeqParam[i] = param[i] as SubSeqInspDualVisionParam;
            }

            m_nPointCount = param.Length;
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
                    m_nPointIndex           = 0;
                    m_dpAcutalAxisPos       = new DPointXY[4]; // EN_POINT_INDEX
                    m_SubSeqVisionResult = new SubSeqInspectionResult[10]; // EN_RESULT_INDEX
                    m_SubSeqPositionResult    = new SubSeqInspectionResult[10]; // EN_RESULT_INDEX
                    m_nCamIndex             = m_SubSeqParam[m_nPointIndex].CameraNo_ULC; // ULC First
                    m_nAlgorithmIndex       = m_SubSeqParam[m_nPointIndex].AlgorithmNo_ULC; // ULC First
                    m_nResultIndex = 0;
                    m_nStepNo = (int)EN_INSPECTION_STEP.MOVE_POSITION;
                    break;
                #endregion </READY>

                #region <MOVE_POSITION>
                case (int)EN_INSPECTION_STEP.MOVE_POSITION:
                    m_nRetryCount = 0;

                    if (m_SubControl.MovePosition(m_SubSeqParam[m_nPointIndex].PositionX, m_SubSeqParam[m_nPointIndex].PositionY) != MOTION_RESULT.OK)
                    {
                        Activate = false;
                        return EN_SUBSEQUENCE_RESULT.ERROR_MOTION;
                    }

                    ++m_nStepNo;
                    break;
				case (int)EN_INSPECTION_STEP.MOVE_POSITION + 1:
					m_TimeDelay.SetTickCount((uint)m_SubSeqParam[m_nPointIndex].DelayForGrab);
					++m_nStepNo;
					break;
				case (int)EN_INSPECTION_STEP.MOVE_POSITION + 2:
					if(m_TimeDelay.IsTickOver(true))
						m_nStepNo = (int)EN_INSPECTION_STEP.CHAGNE_ALGORISM;
					break;
                #endregion </MOVE_POSITION>

                #region <CHAGNE_ALGORISM>
                case (int)EN_INSPECTION_STEP.CHAGNE_ALGORISM:
                    enResult = m_SubControl.ChangeAlgorism(m_nCamIndex, m_nAlgorithmIndex);

                    switch (enResult)
                    {
                        case VISION_RESULT.IN_PROCESS:
                        case VISION_RESULT.NOT_COMPLETE:
                            break;

                        case VISION_RESULT.COMPLETE:
                            m_nStepNo = (int)EN_INSPECTION_STEP.GRAB_IMAGE;
                            break;

                        case VISION_RESULT.ERROR_COMMAND:
                            Activate = false;
                            return EN_SUBSEQUENCE_RESULT.ERROR_COMMAND;
                        case VISION_RESULT.ERROR_VISION:
                            Activate = false;
                            return EN_SUBSEQUENCE_RESULT.ERROR_VISION;
                        case VISION_RESULT.TIMEOUT_VISION:
                            Activate = false;
                            return EN_SUBSEQUENCE_RESULT.ERROR_TIMEOUT;
                    }
                    break;
                #endregion </CHAGNE_ALGORISM>

                #region <GRAB_IMAGE>
                case (int)EN_INSPECTION_STEP.GRAB_IMAGE:
                    enResult = m_SubControl.Inspection(m_nCamIndex);

                    switch (enResult)
                    {
                        case VISION_RESULT.IN_PROCESS:
                        case VISION_RESULT.NOT_COMPLETE:
                            break;

                        case VISION_RESULT.COMPLETE:
							++m_nStepNo;
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
				case (int)EN_INSPECTION_STEP.GRAB_IMAGE + 1:
					switch(m_enSubSeqBrance)
					{
						case EN_SEQUENCE_BRANCH.NORMAL_ACTION:
							m_nStepNo	= (int)EN_INSPECTION_STEP.GET_RESULT;
							break;
						case EN_SEQUENCE_BRANCH.END_AFTER_GRAB:
							m_nStepNo	= (int)EN_INSPECTION_STEP.GET_RESULT + 1;
							break;
					}
					break;
                #endregion </GRAB_IMAGE>

                #region <GET_RESULT>
                case (int)EN_INSPECTION_STEP.GET_RESULT:
                    enResult = m_SubControl.GetResult(m_nCamIndex);
                    switch (enResult)
                    {
                        case VISION_RESULT.IN_PROCESS:
                        case VISION_RESULT.NOT_COMPLETE:
                            break;

                        case VISION_RESULT.COMPLETE:
                            m_nStepNo++;
                            break;

                        case VISION_RESULT.ERROR_VISION:
                            Activate = false;
                            return EN_SUBSEQUENCE_RESULT.ERROR_VISION;
                        case VISION_RESULT.TIMEOUT_VISION:
                            Activate = false;
                            return EN_SUBSEQUENCE_RESULT.ERROR_TIMEOUT;
                    }
                    break;
                case (int)EN_INSPECTION_STEP.GET_RESULT + 1:
                    if(m_nCamIndex == m_SubSeqParam[m_nPointIndex].CameraNo_ULC
                        && m_nAlgorithmIndex == m_SubSeqParam[m_nPointIndex].AlgorithmNo_ULC)
                    {
                        m_nCamIndex = m_SubSeqParam[m_nPointIndex].CameraNo_DLC;
                        m_nAlgorithmIndex = m_SubSeqParam[m_nPointIndex].AlgorithmNo_DLC;

                        m_SubSeqVisionResult[m_nResultIndex++] = m_SubControl.GetInspectionResult(); // ULC LT - DLC LT , ULC RB - DLC RB 
                        m_nStepNo = (int)EN_INSPECTION_STEP.CHAGNE_ALGORISM;
                    }

                    else
                    {
                        m_dpAcutalAxisPos[m_nPointIndex] = m_SubControl.GetActualPosition();
                        m_SubSeqVisionResult[m_nResultIndex++] = m_SubControl.GetInspectionResult();

                        ++m_nStepNo;
                    }
                    
                    break;

                case (int)EN_INSPECTION_STEP.GET_RESULT + 2:
                    m_nPointIndex++;
                    if (m_nPointIndex < m_nPointCount)
                    {
                        m_nCamIndex = m_SubSeqParam[m_nPointIndex].CameraNo_ULC;    // Next Camera Index
                        m_nAlgorithmIndex = m_SubSeqParam[m_nPointIndex].AlgorithmNo_ULC; // Next Algorithm Index
                        m_nStepNo = (int)EN_INSPECTION_STEP.MOVE_POSITION;
                    }
                    else
                    {
                        CorrectAxisPosition();
                        m_nStepNo = (int)EN_INSPECTION_STEP.FINISH;
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
        /// 검색 대상의 위치를 축 좌표로 수정 (Camera 좌표 > Axis 좌표)
        /// </summary>
        /// <returns></returns>
        private void CorrectAxisPosition()
        {
            DPointXY dpDLCCenterPos = CalculateDLCCenterPosition();
            DPointXY dpULCCenterPos = CalculateULCCenterPosition();
            DPointXY dpCenterGap;
            double dbULCAngle = -1;
            double dbDLCAngle = -1;

            dpCenterGap = (dpULCCenterPos - dpDLCCenterPos);

            if (m_nPointCount == 1)
            {
                // 1P 검사시 첫번째 검사인 LT가 Center
                dbULCAngle = m_SubSeqVisionResult[(int)EN_RESULT_INDEX.LT_ULC].PositionT;
                dbDLCAngle = m_SubSeqVisionResult[(int)EN_RESULT_INDEX.LT_DLC].PositionT;
            }
            else if (m_nPointCount == 2)
            {
                //양안비전에서는 카메라가 움직임으로 항상 정좌표계
                dbULCAngle = MathFormula.anglePtoP(m_dpAcutalULCPos[(int)EN_POINT_INDEX.LT], m_dpAcutalULCPos[(int)EN_POINT_INDEX.RB]);
                dbDLCAngle = MathFormula.anglePtoP(m_dpAcutalDLCPos[(int)EN_POINT_INDEX.LT], m_dpAcutalDLCPos[(int)EN_POINT_INDEX.RB]);
            }
            else
            {
                //양안비전에서는 카메라가 움직임으로 항상 정좌표계
                dbULCAngle = MathFormula.anglePtoP(m_dpAcutalULCPos[(int)EN_POINT_INDEX.LT], m_dpAcutalULCPos[(int)EN_POINT_INDEX.RT]);
                dbDLCAngle = MathFormula.anglePtoP(m_dpAcutalDLCPos[(int)EN_POINT_INDEX.LT], m_dpAcutalDLCPos[(int)EN_POINT_INDEX.RT]);
            }
            m_SubSeqPositionResult[(int)EN_RESULT_INDEX.ULC_CENTER] = new SubSeqInspectionResult();
            m_SubSeqPositionResult[(int)EN_RESULT_INDEX.ULC_CENTER].PositionX = dpULCCenterPos.x;
            m_SubSeqPositionResult[(int)EN_RESULT_INDEX.ULC_CENTER].PositionY = dpULCCenterPos.y;
            m_SubSeqPositionResult[(int)EN_RESULT_INDEX.ULC_CENTER].PositionT = dbULCAngle;

            m_SubSeqPositionResult[(int)EN_RESULT_INDEX.DLC_CENTER] = new SubSeqInspectionResult();
            m_SubSeqPositionResult[(int)EN_RESULT_INDEX.DLC_CENTER].PositionX = dpDLCCenterPos.x;
            m_SubSeqPositionResult[(int)EN_RESULT_INDEX.DLC_CENTER].PositionY = dpDLCCenterPos.y;
            m_SubSeqPositionResult[(int)EN_RESULT_INDEX.DLC_CENTER].PositionT = dbDLCAngle;

            m_SubSeqResult.PositionX = dpCenterGap.x;
            m_SubSeqResult.PositionY = dpCenterGap.y;
            m_SubSeqResult.PositionT = dbDLCAngle - dbULCAngle;

        }
        /// <summary>
        /// 두 지점의 중심 값 및 각도 계산하기
        /// </summary>
        private DPointXY CalculateULCCenterPosition()
        {
            DPointXY dpULCCenterPos = new DPointXY();

            m_dpAcutalULCPos[(int)EN_POINT_INDEX.LT] = new DPointXY(m_SubSeqVisionResult[(int)EN_RESULT_INDEX.LT_ULC].PositionX + m_dpAcutalAxisPos[(int)EN_POINT_INDEX.LT].x
                                                                    , m_SubSeqVisionResult[(int)EN_RESULT_INDEX.LT_ULC].PositionY + m_dpAcutalAxisPos[(int)EN_POINT_INDEX.LT].y);

            m_SubSeqPositionResult[(int)EN_RESULT_INDEX.LT_ULC] = new SubSeqInspectionResult();
            m_SubSeqPositionResult[(int)EN_RESULT_INDEX.LT_ULC].PositionX = m_dpAcutalULCPos[(int)EN_POINT_INDEX.LT].x;
            m_SubSeqPositionResult[(int)EN_RESULT_INDEX.LT_ULC].PositionY = m_dpAcutalULCPos[(int)EN_POINT_INDEX.LT].y;
           
            if(m_nPointCount == 1) 
            {
                // 1P 검사시 첫번째 검사인 LT가 Center
                dpULCCenterPos = m_dpAcutalULCPos[(int)EN_POINT_INDEX.LT];
                return dpULCCenterPos;
            }

            m_dpAcutalULCPos[(int)EN_POINT_INDEX.RB] = new DPointXY(m_SubSeqVisionResult[(int)EN_RESULT_INDEX.RB_ULC].PositionX + m_dpAcutalAxisPos[(int)EN_POINT_INDEX.RB].x
                                                                    , m_SubSeqVisionResult[(int)EN_RESULT_INDEX.RB_ULC].PositionY + m_dpAcutalAxisPos[(int)EN_POINT_INDEX.RB].y);

            m_SubSeqPositionResult[(int)EN_RESULT_INDEX.RB_ULC] = new SubSeqInspectionResult();
            m_SubSeqPositionResult[(int)EN_RESULT_INDEX.RB_ULC].PositionX = m_dpAcutalULCPos[(int)EN_POINT_INDEX.RB].x;
            m_SubSeqPositionResult[(int)EN_RESULT_INDEX.RB_ULC].PositionY = m_dpAcutalULCPos[(int)EN_POINT_INDEX.RB].y;

            if (m_nPointCount == 2)
            {
                dpULCCenterPos = MathFormula.centerPtoP(m_dpAcutalULCPos[(int)EN_POINT_INDEX.LT], m_dpAcutalULCPos[(int)EN_POINT_INDEX.RB]);
                return dpULCCenterPos;
            }

            m_dpAcutalULCPos[(int)EN_POINT_INDEX.RT] = new DPointXY(m_SubSeqVisionResult[(int)EN_RESULT_INDEX.RT_ULC].PositionX + m_dpAcutalAxisPos[(int)EN_POINT_INDEX.RT].x
                                                               , m_SubSeqVisionResult[(int)EN_RESULT_INDEX.RT_ULC].PositionY + m_dpAcutalAxisPos[(int)EN_POINT_INDEX.RT].y);

            m_SubSeqPositionResult[(int)EN_RESULT_INDEX.RT_ULC] = new SubSeqInspectionResult();
            m_SubSeqPositionResult[(int)EN_RESULT_INDEX.RT_ULC].PositionX = m_dpAcutalULCPos[(int)EN_POINT_INDEX.RT].x;
            m_SubSeqPositionResult[(int)EN_RESULT_INDEX.RT_ULC].PositionY = m_dpAcutalULCPos[(int)EN_POINT_INDEX.RT].y;

            if (m_nPointCount == 3)
            {
                dpULCCenterPos = MathFormula.centerPtoP(m_dpAcutalULCPos[(int)EN_POINT_INDEX.LT], m_dpAcutalULCPos[(int)EN_POINT_INDEX.RB]);
                return dpULCCenterPos;
            }

            m_dpAcutalULCPos[(int)EN_POINT_INDEX.LB] = new DPointXY(m_SubSeqVisionResult[(int)EN_RESULT_INDEX.LB_ULC].PositionX + m_dpAcutalAxisPos[(int)EN_POINT_INDEX.LB].x
                                                                  , m_SubSeqVisionResult[(int)EN_RESULT_INDEX.LB_ULC].PositionY + m_dpAcutalAxisPos[(int)EN_POINT_INDEX.LB].y);

            m_SubSeqPositionResult[(int)EN_RESULT_INDEX.LB_ULC] = new SubSeqInspectionResult();
            m_SubSeqPositionResult[(int)EN_RESULT_INDEX.LB_ULC].PositionX = m_dpAcutalULCPos[(int)EN_POINT_INDEX.LB].x;
            m_SubSeqPositionResult[(int)EN_RESULT_INDEX.LB_ULC].PositionY = m_dpAcutalULCPos[(int)EN_POINT_INDEX.LB].y;
       
            dpULCCenterPos = MathFormula.center4Point(m_dpAcutalULCPos[(int)EN_POINT_INDEX.LT]
                                                                , m_dpAcutalULCPos[(int)EN_POINT_INDEX.RB]
                                                                , m_dpAcutalULCPos[(int)EN_POINT_INDEX.RT]
                                                                , m_dpAcutalULCPos[(int)EN_POINT_INDEX.LB]);
            
            return dpULCCenterPos;
        }

        private DPointXY CalculateDLCCenterPosition()
        {
            DPointXY dpDLCCenterPos = new DPointXY();

            m_dpAcutalDLCPos[(int)EN_POINT_INDEX.LT] = new DPointXY(m_SubSeqVisionResult[(int)EN_RESULT_INDEX.LT_DLC].PositionX + m_dpAcutalAxisPos[(int)EN_POINT_INDEX.LT].x
                                                                    , m_SubSeqVisionResult[(int)EN_RESULT_INDEX.LT_DLC].PositionY + m_dpAcutalAxisPos[(int)EN_POINT_INDEX.LT].y);

            m_SubSeqPositionResult[(int)EN_RESULT_INDEX.LT_DLC] = new SubSeqInspectionResult();
            m_SubSeqPositionResult[(int)EN_RESULT_INDEX.LT_DLC].PositionX = m_dpAcutalDLCPos[(int)EN_POINT_INDEX.LT].x;
            m_SubSeqPositionResult[(int)EN_RESULT_INDEX.LT_DLC].PositionY = m_dpAcutalDLCPos[(int)EN_POINT_INDEX.LT].y;
        
            if (m_nPointCount == 1)
            {
                // 1P 검사시 첫번째 검사인 LT가 Center
                dpDLCCenterPos = m_dpAcutalDLCPos[(int)EN_POINT_INDEX.LT];
                return dpDLCCenterPos;
            }

            m_dpAcutalDLCPos[(int)EN_POINT_INDEX.RB] = new DPointXY(m_SubSeqVisionResult[(int)EN_RESULT_INDEX.RB_DLC].PositionX + m_dpAcutalAxisPos[(int)EN_POINT_INDEX.RB].x
                                                                    , m_SubSeqVisionResult[(int)EN_RESULT_INDEX.RB_DLC].PositionY + m_dpAcutalAxisPos[(int)EN_POINT_INDEX.RB].y);

            m_SubSeqPositionResult[(int)EN_RESULT_INDEX.RB_DLC] = new SubSeqInspectionResult();
            m_SubSeqPositionResult[(int)EN_RESULT_INDEX.RB_DLC].PositionX = m_dpAcutalDLCPos[(int)EN_POINT_INDEX.RB].x;
            m_SubSeqPositionResult[(int)EN_RESULT_INDEX.RB_DLC].PositionY = m_dpAcutalDLCPos[(int)EN_POINT_INDEX.RB].y;

            if (m_nPointCount == 2)
            {
                dpDLCCenterPos = MathFormula.centerPtoP(m_dpAcutalDLCPos[(int)EN_POINT_INDEX.LT], m_dpAcutalDLCPos[(int)EN_POINT_INDEX.RB]);
                return dpDLCCenterPos;
            }
         
            m_dpAcutalDLCPos[(int)EN_POINT_INDEX.RT] = new DPointXY(m_SubSeqVisionResult[(int)EN_RESULT_INDEX.RT_DLC].PositionX + m_dpAcutalAxisPos[(int)EN_POINT_INDEX.RT].x
                                                                    , m_SubSeqVisionResult[(int)EN_RESULT_INDEX.RT_DLC].PositionY + m_dpAcutalAxisPos[(int)EN_POINT_INDEX.RT].y);

            m_SubSeqPositionResult[(int)EN_RESULT_INDEX.RT_DLC] = new SubSeqInspectionResult();
            m_SubSeqPositionResult[(int)EN_RESULT_INDEX.RT_DLC].PositionX = m_dpAcutalDLCPos[(int)EN_POINT_INDEX.RT].x;
            m_SubSeqPositionResult[(int)EN_RESULT_INDEX.RT_DLC].PositionY = m_dpAcutalDLCPos[(int)EN_POINT_INDEX.RT].y;

            if (m_nPointCount == 3)
            {
                dpDLCCenterPos = MathFormula.centerPtoP(m_dpAcutalDLCPos[(int)EN_POINT_INDEX.LT], m_dpAcutalDLCPos[(int)EN_POINT_INDEX.RB]);
                return dpDLCCenterPos;
            }

            m_dpAcutalDLCPos[(int)EN_POINT_INDEX.LB] = new DPointXY(m_SubSeqVisionResult[(int)EN_RESULT_INDEX.LB_DLC].PositionX + m_dpAcutalAxisPos[(int)EN_POINT_INDEX.LB].x
                                                                 , m_SubSeqVisionResult[(int)EN_RESULT_INDEX.LB_DLC].PositionY + m_dpAcutalAxisPos[(int)EN_POINT_INDEX.LB].y);

            m_SubSeqPositionResult[(int)EN_RESULT_INDEX.LB_DLC] = new SubSeqInspectionResult();
            m_SubSeqPositionResult[(int)EN_RESULT_INDEX.LB_DLC].PositionX = m_dpAcutalDLCPos[(int)EN_POINT_INDEX.LB].x;
            m_SubSeqPositionResult[(int)EN_RESULT_INDEX.LB_DLC].PositionY = m_dpAcutalDLCPos[(int)EN_POINT_INDEX.LB].y;

            dpDLCCenterPos = MathFormula.center4Point(m_dpAcutalDLCPos[(int)EN_POINT_INDEX.LT]
                                                                , m_dpAcutalDLCPos[(int)EN_POINT_INDEX.RB]
                                                                , m_dpAcutalDLCPos[(int)EN_POINT_INDEX.RT]
                                                                , m_dpAcutalDLCPos[(int)EN_POINT_INDEX.LB]);
            
            return dpDLCCenterPos;
        }
        #endregion </METHOD>
    }
}
