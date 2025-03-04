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
    public class SubSeqConveyorUnloadingParam : SubSequenceParam
    {
        public int StopDelay = 0;
    }
    #endregion </VALUE CLASS>

    class SubSeqConveyorUnloading : ASubSequence
    {
        #region <ENUMERATION>
        private enum EN_UNLOADING_STEP
        {
            READY = 0,

            MOVE_FORWARD = 100,
            CHECK_EXIT = 200,
            MOVE_STOP = 300,

            FINISH = 1000,
        }
        #endregion <ENUMERATION>

        #region <FIELD>
        private IConveyor m_SubControl = null;

        private SubSeqConveyorUnloadingParam[] m_SubSeqParam = null;

        private TickCounter m_TimeDelay = new TickCounter();
        #endregion </FIELD>

        #region <CONSTRUCTOR>
        public SubSeqConveyorUnloading(ASubControl control)
        {
            m_SubControl = control as IConveyor;
        }
        #endregion </CONSTRUCTOR>

        #region <OVERRIDE>
        public override void AddParameter<T>(params T[] param)
        {
            m_SubSeqParam = new SubSeqConveyorUnloadingParam[param.Length];

            for (int i = 0; i < param.Length; i++)
            {
                m_SubSeqParam[i] = param[i] as SubSeqConveyorUnloadingParam;
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
                case (int)EN_UNLOADING_STEP.READY:
                    m_SubControl.StopperOff();

                    m_nStepNo = (int)EN_UNLOADING_STEP.MOVE_FORWARD;
                    break;
                #endregion </READY>

                #region <MOVE_FORWARD>
                case (int)EN_UNLOADING_STEP.MOVE_FORWARD:
                    m_SubControl.MoveForward();

                    m_nStepNo = (int)EN_UNLOADING_STEP.CHECK_EXIT;
                    break;
                #endregion </MOVE_FORWARD>

                #region <CHECK_EXIT>
                case (int)EN_UNLOADING_STEP.CHECK_EXIT:
                    if (m_SubControl.CheckExit().Equals(false))
                        break;

                    m_TimeDelay.SetTickCount((uint)m_SubSeqParam[0].StopDelay);
                    m_nStepNo++;
                    break;
                case (int)EN_UNLOADING_STEP.CHECK_EXIT + 1:
                    if (m_TimeDelay.IsTickOver(true).Equals(false))
                        break;

                    m_nStepNo = (int)EN_UNLOADING_STEP.MOVE_STOP;
                    break;
                #endregion </CHECK_EXIT>

                #region <MOVE_STOP>
                case (int)EN_UNLOADING_STEP.MOVE_STOP:
                    // 2021.11.23 by jhchoo [ADD] Action 에서 처리되는 부분을 Sub Sequence 에서 처리 (주석해제)
                    m_SubControl.MoveStop();

                    m_nStepNo = (int)EN_UNLOADING_STEP.FINISH;
                    break;
                #endregion </MOVE_STOP>

                #region <FINISH>
                case (int)EN_UNLOADING_STEP.FINISH:
                    Activate = false;

                    return EN_SUBSEQUENCE_RESULT.OK;
                #endregion </FINISH>
            }

            return EN_SUBSEQUENCE_RESULT.WORKING;
        }
        #endregion </OVERRIDE>
    }
}
