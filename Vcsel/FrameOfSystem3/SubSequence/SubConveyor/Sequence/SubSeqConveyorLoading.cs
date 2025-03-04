using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Define.DefineEnumProject.SubSequence;
using TickCounter_;

namespace FrameOfSystem3.SubSequence.SubConveyor
{
    #region <VALUE CLASS>
    /// <summary>
    /// Sequence 에서 사용하는 Parameter 이며 Client 로 부터 전달 받음
    /// </summary>
    public class SubSeqConveyorLoadingParam : SubSequenceParam
    {
        public int SpeedRatio = 0;
        public int DecelDelay = 0;
        public int StopDelay = 0;

        public string StopDelayMode = string.Empty;
    }
    #endregion </VALUE CLASS>

    class SubSeqConveyorLoading : ASubSequence
    {
        #region <ENUMERATION>
        private enum EN_LOADING_STEP
        {
            READY = 0,

            CHECK_ENTRY = 100,
            MOVE_FORWARD = 200,
            CHECK_APPROACH = 300,
            MOVE_SLOW = 400,
            CHECK_ARRIVED = 500,
            MOVE_STOP = 600,

            FINISH = 1000,
        }
        #endregion <ENUMERATION>

        #region <FIELD>
        private IConveyor m_SubControl = null;

        private SubSeqConveyorLoadingParam[] m_SubSeqParam = null;

        private TickCounter m_TimeDelay = new TickCounter();
        #endregion </FIELD>

        #region <CONSTRUCTOR>
        public SubSeqConveyorLoading(ASubControl control)
        {
            m_SubControl = control as IConveyor;
        }
        #endregion </CONSTRUCTOR>

        #region <OVERRIDE>
        public override void AddParameter<T>(params T[] param)
        {
            m_SubSeqParam = new SubSeqConveyorLoadingParam[param.Length];

            for (int i = 0; i < param.Length; i++)
            {
                m_SubSeqParam[i] = param[i] as SubSeqConveyorLoadingParam;
            }
        }
        public override void SetSubSeqBranch(int nBranch)
        {
            // Not Used
        }
        public override EN_SUBSEQUENCE_RESULT SubSequenceProcedure()
        {
            if (Activate.Equals(false))
                return EN_SUBSEQUENCE_RESULT.OK;

            switch (m_nStepNo)
            {
                #region <READY>
                case (int)EN_LOADING_STEP.READY:
                    m_SubControl.StopperOn();

                    m_nStepNo = (int)EN_LOADING_STEP.CHECK_ENTRY;
                    break;
                #endregion </READY>

                #region <CHECK_ENTRY>
                case (int)EN_LOADING_STEP.CHECK_ENTRY:
                    if (m_SubControl.CheckEntry())
                        m_nStepNo = (int)EN_LOADING_STEP.MOVE_FORWARD;

                    break;
                #endregion </CHECK_ENTRY>

                #region <MOVE_FORWARD>
                case (int)EN_LOADING_STEP.MOVE_FORWARD:
                    m_SubControl.MoveForward();

                    m_nStepNo = (int)EN_LOADING_STEP.CHECK_APPROACH;
                    break;
                #endregion </MOVE_FORWARD>

                #region <CHECK_APPROACH>
                case (int)EN_LOADING_STEP.CHECK_APPROACH:
                    if (m_SubControl.CheckApproach().Equals(false))
                        break;

                    m_TimeDelay.SetTickCount((uint)m_SubSeqParam[0].DecelDelay);
                    m_nStepNo++;
                    break;
                case (int)EN_LOADING_STEP.CHECK_APPROACH + 1:
                    if (m_TimeDelay.IsTickOver(true).Equals(false))
                        break;

                    m_nStepNo = (int)EN_LOADING_STEP.MOVE_SLOW;
                    break;
                #endregion </CHECK_APPROACH>

                #region <MOVE_SLOW>
                case (int)EN_LOADING_STEP.MOVE_SLOW:
                    m_SubControl.MoveSlow(m_SubSeqParam[0].SpeedRatio);

                    m_nStepNo = (int)EN_LOADING_STEP.CHECK_ARRIVED;
                    break;
                #endregion </MOVE_SLOW>

                #region <CHECK_ARRIVED>
                case (int)EN_LOADING_STEP.CHECK_ARRIVED:
                    if (m_SubControl.CheckArrived(m_SubSeqParam[0].StopDelayMode).Equals(false))
                        break;

                    m_TimeDelay.SetTickCount((uint)m_SubSeqParam[0].StopDelay);
                    m_nStepNo++;
                    break;
                case (int)EN_LOADING_STEP.CHECK_ARRIVED + 1:
                    if (m_TimeDelay.IsTickOver(true).Equals(false))
                        break;

                    m_nStepNo = (int)EN_LOADING_STEP.MOVE_STOP;
                    break;
                #endregion </CHECK_ARRIVED>

                #region <MOVE_STOP>
                case (int)EN_LOADING_STEP.MOVE_STOP:
                    m_SubControl.MoveStop();
                    
                    m_nStepNo = (int)EN_LOADING_STEP.FINISH;
                    break;
                #endregion </MOVE_STOP>

                #region <FINISH>
                case (int)EN_LOADING_STEP.FINISH:
                    Activate = false;

                    return EN_SUBSEQUENCE_RESULT.OK;
                #endregion </FINISH>
            }

            return EN_SUBSEQUENCE_RESULT.WORKING;
        }
        #endregion </OVERRIDE>
    }
}
