using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Define.DefineEnumeration.SubSequence;
using TickCounter_;

namespace FrameOfSystem3.SubSequence.SubBlockUpDown
{
    #region <VALUE CLASS>
    /// <summary>
    /// Sequence 에서 사용하는 Parameter 이며 Client 로 부터 전달 받음
    /// </summary>
    public class SubSeqBlockDownParam : SubSequenceParam
    {
        public bool SlowSpeed = false;
    }
    #endregion </VALUE CLASS>

    class SubSeqBlockDown : ASubSequence
    {
        #region <ENUMERATION>
        private enum EN_SEQUENCE_STEP
        {
            READY = 0,
            
            MOVE_CONTACT = 100,
            TURN_OFF_VACUUM = 200,
            MOVE_READY = 300,

            FINISH = 1000,
        }
        #endregion <ENUMERATION>

        #region <FIELD>
        private IBlock m_iBlock = null;

        private SubSeqBlockDownParam[] m_SubSeqParam = null;

        private TickCounter m_TimeDelay = new TickCounter();
        #endregion </FIELD>

        #region <CONSTRUCTOR>
        public SubSeqBlockDown(ASubControl control) : base(control)
        {
            m_iBlock = control as SubCtrlBlock;
        }
        #endregion </CONSTRUCTOR>

        #region <OVERRIDE>
        public override void AddParameter<T>(params T[] param)
        {
            m_SubSeqParam = new SubSeqBlockDownParam[param.Length];

            for (int i = 0; i < param.Length; i++)
            {
                m_SubSeqParam[i] = param[i] as SubSeqBlockDownParam;
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
                case (int)EN_SEQUENCE_STEP.READY:
                    p_SubSeqErrorInformation = "";

                    m_nStepNo = (int)EN_SEQUENCE_STEP.MOVE_CONTACT;
                    break;
                #endregion </READY>

                #region <MOVE_CONTACT>
                case (int)EN_SEQUENCE_STEP.MOVE_CONTACT:
                    if (false == m_iBlock.MoveContact(false, m_SubSeqParam[0].SlowSpeed))
                        break;

                    m_nStepNo++;
                    break;
                case (int)EN_SEQUENCE_STEP.MOVE_CONTACT + 1:
                    if (false == m_iBlock.IsMoveDone())
                        break;

                    m_nStepNo++;
                    break;
                case (int)EN_SEQUENCE_STEP.MOVE_CONTACT + 2:
                    m_nStepNo = (int)EN_SEQUENCE_STEP.TURN_OFF_VACUUM;
                    break;
                #endregion </MOVE_CONTACT>

                #region <TURN_OFF_VACUUM>
                case (int)EN_SEQUENCE_STEP.TURN_OFF_VACUUM:
                    if (false == m_iBlock.TurnOffVacuum())
                        break;

                    m_nStepNo++;
                    break;
                case (int)EN_SEQUENCE_STEP.TURN_OFF_VACUUM + 1:
                    m_nStepNo = (int)EN_SEQUENCE_STEP.MOVE_READY;
                    break;
                #endregion </TURN_OFF_VACUUM>

                #region <MOVE_READY>
                case (int)EN_SEQUENCE_STEP.MOVE_READY:
                    if (false == m_iBlock.MoveReady())
                        break;

                    m_nStepNo++;
                    break;
                case (int)EN_SEQUENCE_STEP.MOVE_READY + 1:
                    if (false == m_iBlock.IsMoveDone())
                        break;

                    m_nStepNo++;
                    break;
                case (int)EN_SEQUENCE_STEP.MOVE_READY + 2:
                    m_nStepNo = (int)EN_SEQUENCE_STEP.FINISH;
                    break;
                #endregion </MOVE_READY>

                #region <FINISH>
                case (int)EN_SEQUENCE_STEP.FINISH:
                    return EN_SUBSEQUENCE_RESULT.OK;
                #endregion </FINISH>
            }

            return EN_SUBSEQUENCE_RESULT.WORKING;
        }
        #endregion </OVERRIDE>
    }
}
