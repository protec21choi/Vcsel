using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Define.DefineEnumProject.SubSequence;
using Define.DefineEnumProject.SubSequence.Vision;

using Vision_;

namespace FrameOfSystem3.SubSequence.SubVisionInspection
{
    #region <VALUE CLASS>
    public class SubSeqInspectionParam : SubSequenceParam
    {
        public int CameraNo = 0;
        public int AlgorithmNo = 0;
    }
    #endregion </VALUE CLASS>

    public class SubSeqInspection : ASubSequence
    {
        #region <ENUMERATION>
        private enum EN_INSPECTION_STEP
        {
            READY = 0,

            CHAGNE_ALGORISM = 100,
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

		private EN_SEQUENCE_BRANCH m_enSubSeqBrance	= EN_SEQUENCE_BRANCH.NORMAL_ACTION;

        private SubSeqInspectionParam[] m_SubSeqParam = null;

        private int m_nRetryCount = 0;
        #endregion </FIELD>

        #region <CONSTRUCTOR>
        public SubSeqInspection(ASubControl control)
        {
            m_SubControl = control as IVisionInspection;
        }
        #endregion </CONSTRUCTOR>

        #region <OVERRIDE>
        public override void AddParameter<T>(params T[] param)
        {
            m_SubSeqParam = new SubSeqInspectionParam[param.Length];

            for (int i = 0; i < param.Length; i++)
            {
                m_SubSeqParam[i] = param[i] as SubSeqInspectionParam;
            }
        }
		public override void SetSubSeqBranch(int nBranch)
		{
			m_enSubSeqBrance	= (EN_SEQUENCE_BRANCH)nBranch;
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
                    m_nRetryCount = 0;
                    m_nStepNo = (int)EN_INSPECTION_STEP.CHAGNE_ALGORISM;
                    break;
                #endregion </READY>

                #region <CHAGNE_ALGORISM>
                case (int)EN_INSPECTION_STEP.CHAGNE_ALGORISM:
                    enResult = m_SubControl.ChangeAlgorism(m_SubSeqParam[INSP].CameraNo, m_SubSeqParam[INSP].AlgorithmNo);

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
                    enResult = m_SubControl.Inspection(m_SubSeqParam[INSP].CameraNo);

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
							m_nStepNo	= (int)EN_INSPECTION_STEP.FINISH;
							break;
					}
					break;
                #endregion </GRAB_IMAGE>

                #region <GET_RESULT>
                case (int)EN_INSPECTION_STEP.GET_RESULT:
                    enResult = m_SubControl.GetResult(m_SubSeqParam[INSP].CameraNo);

                    switch (enResult)
                    {
                        case VISION_RESULT.IN_PROCESS:
                        case VISION_RESULT.NOT_COMPLETE:
                            break;

                        case VISION_RESULT.COMPLETE:
                            m_SubSeqResult = m_SubControl.GetInspectionResult();
                            m_nStepNo = (int)EN_INSPECTION_STEP.FINISH;
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
    }
}
