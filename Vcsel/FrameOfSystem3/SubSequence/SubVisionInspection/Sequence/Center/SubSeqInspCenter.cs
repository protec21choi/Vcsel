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
    public class SubSeqInspCenterParam : SubSequenceParam
    {
        public int CameraNo = 0;
        public int AlgorithmNo = 0;

        // GRAB POSITION XY
        public double PositionX = 0.0;
        public double PositionY = 0.0;

		public int DelayForGrab	= 0;
        
        // 2022.03.24 by wdw [ADD]
        public bool Axis_Reverse_X = false; //모션 좌표계 방향// 카메라가 움직이면 정좌표계 대상이 움직이면 역좌표계
        public bool Axis_Reverse_Y = false; //모션 좌표계 방향// 카메라가 움직이면 정좌표계 대상이 움직이면 역좌표계

		// 2022.01.06 by twkang [ADD]
		// Dryrun, Simulation 모드에서 False 로 설정하면 파라미터로 입력한 2포인트의 센터값이 결과로 나온다.
		public bool VisionUse	= true;
    }
    #endregion </VALUE CLASS>

    public class SubSeqInspCenter : ASubSequence
    {
        #region <ENUMERATION>
        private enum EN_INSPECTION_STEP
        {
            READY = 0,

            MOVE_POSITION = 100,
            CHAGNE_ALGORISM = 200,
            GRAB_IMAGE = 300,
            GET_RESULT = 400,

            FINISH = 1000,
        }
        #endregion </ENUMERATION>

        #region <FIELD>
        private IVisionInspection m_SubControl = null;

		private EN_SEQUENCE_BRANCH m_enSubSeqBrance	= EN_SEQUENCE_BRANCH.NORMAL_ACTION;

        private SubSeqInspCenterParam[] m_SubSeqParam = null;
		
        // 검색 대상(2 Points)의 수정된 축 좌표 (Camera > Axis 좌표)
        private DPointXY[] m_dpAxisPos = new DPointXY[4];

		private TickCounter m_TimeDelay = new TickCounter();
        private int m_nPointIndex = 0;
        private int m_nRetryCount = 0;

        private int m_nPointCount = 1;
        #endregion </FIELD>

        #region <CONSTRUCTOR>
        public SubSeqInspCenter(ASubControl control)
        {
            m_SubControl = control as IVisionInspection;
        }
        #endregion </CONSTRUCTOR>

        #region <OVERRIDE>
        public override void AddParameter<T>(params T[] param)
        {
            m_nPointCount = param.Length;
            m_SubSeqParam = new SubSeqInspCenterParam[param.Length];

            for (int i = 0; i < param.Length; i++)
            {
                m_SubSeqParam[i] = param[i] as SubSeqInspCenterParam;
            }
        }
        public override EN_SUBSEQUENCE_RESULT SubSequenceProcedure()
        {
            //2022.11.10 by jhlee [MODIFY] Dry run 동작 시, 입력된 모터값을 기준으로 Reference Map Center 설정
            if (Activate.Equals(false))
            {
                CalculateCenterPosition();
                return EN_SUBSEQUENCE_RESULT.OK;
            }

            VISION_RESULT enResult;

            switch (m_nStepNo)
            {
                #region <READY>
                case (int)EN_INSPECTION_STEP.READY:
                    m_nPointIndex = 0;
                    m_SubSeqVisionResult = new SubSeqInspectionResult[m_nPointCount];
                    m_SubSeqPositionResult = new SubSeqInspectionResult[m_nPointCount];
                    m_dpAxisPos = new DPointXY[m_nPointCount];

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
                    enResult = m_SubControl.ChangeAlgorism(m_SubSeqParam[m_nPointIndex].CameraNo, m_SubSeqParam[m_nPointIndex].AlgorithmNo);

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
                    enResult = m_SubControl.Inspection(m_SubSeqParam[m_nPointIndex].CameraNo);

                    switch (enResult)
                    {
                        case VISION_RESULT.IN_PROCESS:
                        case VISION_RESULT.NOT_COMPLETE:
                            break;

                        case VISION_RESULT.COMPLETE:
							// 2021.12.10 by twkang [MOD]
							++m_nStepNo;
                            //m_nStepNo = (int)EN_INSPECTION_STEP.GET_RESULT; 
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
                    enResult = m_SubControl.GetResult(m_SubSeqParam[m_nPointIndex].CameraNo);

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
                    m_SubSeqVisionResult[m_nPointIndex] = m_SubControl.GetInspectionResult();
                    m_dpAxisPos[m_nPointIndex] = CorrectAxisPosition();

                    m_SubSeqPositionResult[m_nPointIndex] = new SubSeqInspectionResult();
                    m_SubSeqPositionResult[m_nPointIndex].PositionX =  m_dpAxisPos[m_nPointIndex].x;
                    m_SubSeqPositionResult[m_nPointIndex].PositionY =  m_dpAxisPos[m_nPointIndex].y;

                    m_nPointIndex++;

                    if (m_nPointIndex < m_nPointCount)
                    {
                        m_nStepNo = (int)EN_INSPECTION_STEP.MOVE_POSITION;
                    }
                    else
                    {
                        CalculateCenterPosition();
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
        private DPointXY CorrectAxisPosition()
        {
            DPointXY dpAxisPos;
            DPointXY dpActPos;

            SubSeqInspectionResult InspResult;

			if(!m_SubSeqParam[m_nPointIndex].VisionUse)
				dpActPos = m_SubControl.GetActualPosition();
			else
				dpActPos = new DPointXY(m_SubSeqParam[m_nPointIndex].PositionX, m_SubSeqParam[m_nPointIndex].PositionY); 
            
            InspResult = m_SubControl.GetInspectionResult();

            if (m_SubSeqParam[m_nPointIndex].Axis_Reverse_X)
            {
                dpAxisPos.x = dpActPos.x - InspResult.PositionX;
            }
            else
            {
                dpAxisPos.x = dpActPos.x + InspResult.PositionX;
            }

            if (m_SubSeqParam[m_nPointIndex].Axis_Reverse_Y)
            {
                dpAxisPos.y = dpActPos.y - InspResult.PositionY;
            }
            else
            {
                dpAxisPos.y = dpActPos.y + InspResult.PositionY;
            }

            return dpAxisPos;
        }
        /// <summary>
        /// 두 지점의 중심 값 및 각도 계산하기
        /// </summary>
        private void CalculateCenterPosition()
        {
            DPointXY dpCenterPos;

            switch (m_nPointCount)
            {
                case 2:
                    dpCenterPos = MathFormula.centerPtoP(m_dpAxisPos[0], m_dpAxisPos[1]);

                    m_SubSeqResult.PositionX = dpCenterPos.x;
                    m_SubSeqResult.PositionY = dpCenterPos.y;
                    m_SubSeqResult.PositionT = MathFormula.anglePtoP(m_dpAxisPos[0], m_dpAxisPos[1], m_SubSeqParam[0].Axis_Reverse_X, m_SubSeqParam[0].Axis_Reverse_Y);
                    break;
                case 3:
                    dpCenterPos = MathFormula.centerPtoP(m_dpAxisPos[0], m_dpAxisPos[1]);

                    m_SubSeqResult.PositionX = dpCenterPos.x;
                    m_SubSeqResult.PositionY = dpCenterPos.y;
                    m_SubSeqResult.PositionT = MathFormula.anglePtoP(m_dpAxisPos[0], m_dpAxisPos[2], m_SubSeqParam[0].Axis_Reverse_X, m_SubSeqParam[0].Axis_Reverse_Y);
                    break;
                case 4:
                    dpCenterPos = MathFormula.center4Point(m_dpAxisPos[0], m_dpAxisPos[1], m_dpAxisPos[2], m_dpAxisPos[3]);

                    m_SubSeqResult.PositionX = dpCenterPos.x;
                    m_SubSeqResult.PositionY = dpCenterPos.y;
                    m_SubSeqResult.PositionT = MathFormula.anglePtoP(m_dpAxisPos[0], m_dpAxisPos[2], m_SubSeqParam[0].Axis_Reverse_X, m_SubSeqParam[0].Axis_Reverse_Y);
                    break;
            }
        }
        #endregion </METHOD>
    }
}
