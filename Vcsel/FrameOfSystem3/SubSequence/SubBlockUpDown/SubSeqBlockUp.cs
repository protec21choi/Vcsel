using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Define.DefineEnumeration.SubSequence;
using FrameOfSystem3.SubSequence.SubBlockUpDown.Block;
using TickCounter_;

namespace FrameOfSystem3.SubSequence.SubBlockUpDown
{
    #region <VALUE CLASS>
    /// <summary>
    /// Sequence 에서 사용하는 Parameter 이며 Client 로 부터 전달 받음
    /// </summary>
    public class SubSeqBlockUpParam : SubSequenceParam
    {
        public bool UseVacuum = false;
        public bool UseAlign = false;
    }
    #endregion </VALUE CLASS>

    class SubSeqBlockUp : ASubSequence
    {
        #region <ENUMERATION>
        private enum EN_SEQUENCE_STEP
        {
            READY = 0,
            
            MOVE_CONTACT = 100,
            TURN_ON_VACUUM = 200,
            CHECK_VACUUM = 300,
            MOVE_BASE = 400,

            FINISH = 1000,
        }
        #endregion <ENUMERATION>

        #region <FIELD>
        private IBlock m_iBlock = null;

        private SubSeqBlockUpParam[] m_SubSeqParam = null;

        private TickCounter m_TimeDelay = new TickCounter();

        private EN_ALARM m_enCurrentAlarm = EN_ALARM.NONE;
        #endregion </FIELD>

        #region <CONSTRUCTOR>
        public SubSeqBlockUp(ASubControl control) : base(control)
        {
            m_iBlock = control as SubCtrlBlock;
        }
        #endregion </CONSTRUCTOR>

        #region <OVERRIDE>
        public override void AddParameter<T>(params T[] param)
        {
            m_SubSeqParam = new SubSeqBlockUpParam[param.Length];

            for (int i = 0; i < param.Length; i++)
            {
                m_SubSeqParam[i] = param[i] as SubSeqBlockUpParam;
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
                    if (true == m_SubSeqParam[0].UseAlign)
                    {
                        if (false == m_iBlock.MoveAlignIn())
                            break;
                    }

                    m_nStepNo++;
                    break;
                case (int)EN_SEQUENCE_STEP.MOVE_CONTACT + 1:
                    if (false == m_iBlock.MoveContact(true, false))
                        break;

                    m_nStepNo++;
                    break;
                case (int)EN_SEQUENCE_STEP.MOVE_CONTACT + 2:
                    if (true == m_SubSeqParam[0].UseAlign)
                    {
                        if (false == m_iBlock.MoveAlignOut())
                            break;
                    }

                    m_nStepNo++;
                    break;
                case (int)EN_SEQUENCE_STEP.MOVE_CONTACT + 3:
                    m_nStepNo = (int)EN_SEQUENCE_STEP.TURN_ON_VACUUM;
                    break;
                #endregion </MOVE_CONTACT>

                #region <TURN_ON_VACUUM>
                case (int)EN_SEQUENCE_STEP.TURN_ON_VACUUM:
                    if (true == m_SubSeqParam[0].UseVacuum)
                    {
                        if (false == m_iBlock.TurnOnVacuum())
                            break;
                    }

                    m_nStepNo = (int)EN_SEQUENCE_STEP.CHECK_VACUUM;
                    break;
                #endregion </TURN_ON_VACUUM>

                #region <CHECK_VACUUM>
                case (int)EN_SEQUENCE_STEP.CHECK_VACUUM:
                    if (true == IsOperationDryRunMode())
                    {
                        m_nStepNo = (int)EN_SEQUENCE_STEP.MOVE_BASE;
                        break;
                    }

                    if (true == m_iBlock.TimeChecker.IsTickOver(false))
                    {
                        p_SubSeqErrorInformation = String.Format("Vacuum is not formed.");
                        p_nAlarmCode = (int)EN_ALARM.TIME_OUT;
                        return EN_SUBSEQUENCE_RESULT.ERROR;
                    }

                    if (true == IsEquipmentFinishing())
                    {
                        return EN_SUBSEQUENCE_RESULT.STOP;
                    }

                    if (true == m_SubSeqParam[0].UseVacuum)
                    {
                        if (false == m_iBlock.CheckVacuum(ref m_enCurrentAlarm))
                            break;
                    }

                    m_nStepNo = (int)EN_SEQUENCE_STEP.MOVE_BASE;
                    break;
                #endregion </CHECK_VACUUM>

                #region <MOVE_BASE>
                case (int)EN_SEQUENCE_STEP.MOVE_BASE:
                    if (false == m_iBlock.MoveBase())
                        break;

                    m_nStepNo = (int)EN_SEQUENCE_STEP.FINISH;
                    break;
                #endregion </MOVE_BASE>

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
