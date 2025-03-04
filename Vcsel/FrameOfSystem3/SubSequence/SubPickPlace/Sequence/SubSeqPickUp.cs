using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Define.DefineEnumProject.SubSequence;
using TickCounter_;
using Motion_;

namespace FrameOfSystem3.SubSequence.SubPickPlace
{
    #region <VALUE CLASS>
    /// <summary>
    /// Sequence 에서 사용하는 Parameter 이며 Client 로 부터 전달 받음
    /// </summary>
    public class SubSeqPickUpParam : SubSequenceParam
    {
        public double ReadyPosition		= 0.0;
        public double ContactPosition	= 0.0;
        public double SearchLevel		= 0.0;
		public double TouchThreshold	= 0.0;
        public double ReleaseLevel		= 0.0;
        public double VacuumThreshold	= 0.0;
        public int SearchRatio = 0;
        public double SearchSpeed = -1.0;
        public int ReleaseRatio = 0;
        public double ReleaseSpeed = -1.0;
        public int VacuumOnDelay = 0;
        public int MotionPreDelay = 0;
        public int MotionPostDelay = 0;

        public bool TouchUsed = false;
    }

    public class SubSeqPickForceParam : SubSequenceParam
    {
        public double ContactForce = 0.0;
        public double MovingForce = 0.0;
    }
    #endregion </VALUE CLASS>


	/// <summary>
	/// READY -> DOWN -> MOVE UNTIL SEARCH -> RELEASE -> READY
	/// </summary>
    class SubSeqPickUp : ASubSequence
    {
        #region <ENUMERATION>
        private enum EN_PICKUP_STEP
        {
            READY = 0, 

			MOVE_SEARCH_POS		= 100,
			MOVE_UNTIL_TOUCH	= 200,
			TOUCH_CHECK			= 300,
            PICK_MATERIAL		= 400,
            MOVE_RELEASE_POS	= 500,
            MOVE_READY_POS		= 600,
            CHECK_VACUUM		= 700,

            FINISH = 1000,
        }
        #endregion </ENUMERATION>

        #region <FIELD>
        private IPickPlace m_SubControl = null;
        private IPickPlaceForce m_SubForceControl = null;

        private SubSeqPickUpParam[] m_SubSeqParam = null;
        private SubSeqPickForceParam[] m_SubSeqForceParam = null;

        private TickCounter m_TimeDelay = new TickCounter();
        private TickCounter m_TimeOut = new TickCounter();
        #endregion </FIELD>

        #region <CONSTRUCTOR>
        public SubSeqPickUp(ASubControl control)
        {
            m_SubControl = control as IPickPlace;
        }
        #endregion </CONSTRUCTOR>

        #region <OVERRIDE>
        public override void AddParameter<T>(params T[] param)
        {
            m_SubSeqParam = new SubSeqPickUpParam[param.Length];

            for (int i = 0; i < param.Length; i++)
            {
                m_SubSeqParam[i] = param[i] as SubSeqPickUpParam;
            }
        }
        public override EN_SUBSEQUENCE_RESULT SubSequenceProcedure()
        {
            if (Activate.Equals(false))
                return EN_SUBSEQUENCE_RESULT.OK;

            switch (m_nStepNo)
            {
                #region <READY>
                case (int)EN_PICKUP_STEP.READY:
                    m_nStepNo = (int)EN_PICKUP_STEP.MOVE_SEARCH_POS;
                    break;
                #endregion </READY>

                #region <MOVE_SEARCH_POS>
                case (int)EN_PICKUP_STEP.MOVE_SEARCH_POS:
					// Search 동작 시작 포지션
                    if (m_SubControl.MoveSearchStartPosition(m_SubSeqParam[0].ContactPosition + m_SubSeqParam[0].SearchLevel
                                                         , m_SubSeqParam[0].MotionPreDelay
                                                         , m_SubSeqParam[0].MotionPostDelay) != MOTION_RESULT.OK)
                    {
                        Activate = false;
                        return EN_SUBSEQUENCE_RESULT.ERROR_MOTION;
                    }

                    m_nStepNo = (int)EN_PICKUP_STEP.MOVE_UNTIL_TOUCH;
                    break;
                #endregion </MOVE_SEARCH_POS>

                #region <MOVE UNTIL TOUCH>
                case (int)EN_PICKUP_STEP.MOVE_UNTIL_TOUCH:
                    if (m_SubForceControl != null)
                    {
                        if (m_SubSeqForceParam == null)
                            return EN_SUBSEQUENCE_RESULT.ERROR_PARAMETER;
                        if (!m_SubForceControl.SetForce(m_SubSeqForceParam[0].ContactForce))
                            break;
                    }
                    m_nStepNo++;
                    break;
                case (int)EN_PICKUP_STEP.MOVE_UNTIL_TOUCH + 1:
					// CONTACT POS 에서 1mm 정도 아래 까지 서치
                    if (m_SubControl.MoveContactPosition(m_SubSeqParam[0].ContactPosition
                                                         , m_SubSeqParam[0].SearchSpeed
                                                         , m_SubSeqParam[0].SearchRatio
                                                         , m_SubSeqParam[0].TouchUsed
                                                         , m_SubSeqParam[0].TouchThreshold
                                                         , m_SubSeqParam[0].MotionPreDelay
                                                         , m_SubSeqParam[0].MotionPostDelay) != MOTION_RESULT.OK)
                    {
                        Activate = false;
                        return EN_SUBSEQUENCE_RESULT.ERROR_MOTION;
                    }

                    m_nStepNo = (int)EN_PICKUP_STEP.TOUCH_CHECK;
                    break;
                #endregion

				#region <TOUCH CHECK>
				case (int)EN_PICKUP_STEP.TOUCH_CHECK:
                    if (m_SubControl.IsTouched(m_SubSeqParam[0].TouchUsed).Equals(false))
					{
                        Activate = false;
                        return EN_SUBSEQUENCE_RESULT.ERROR_MOTION;
					}
                    else
                    {
                        m_SubControl.GetTouchedData(ref m_dTouchedPosition, ref m_dTouchedEncorder);
                        m_nStepNo = (int)EN_PICKUP_STEP.PICK_MATERIAL;
                    }
					break;
				#endregion

				#region <PICK_MATERIAL>
				case (int)EN_PICKUP_STEP.PICK_MATERIAL:
                    m_SubControl.VacuumOnBlowOff();

                    m_TimeDelay.SetTickCount((uint)m_SubSeqParam[0].VacuumOnDelay);

					++m_nStepNo;
                    break;
                case (int)EN_PICKUP_STEP.PICK_MATERIAL + 1:
                    if (m_TimeDelay.IsTickOver(true).Equals(false))
                        break;

                    m_nStepNo = (int)EN_PICKUP_STEP.MOVE_RELEASE_POS;
                    break;
                case (int)EN_PICKUP_STEP.PICK_MATERIAL + 2:
                    if (m_TimeOut.IsTickOver(false))
                    {
                        Activate = false;
                        m_strSeqResultInfo = "Pick Up Fail";
                        return EN_SUBSEQUENCE_RESULT.ERROR_TIMEOUT;
                    }

                    if (m_SubControl.CheckVacuum(m_SubSeqParam[0].VacuumThreshold).Equals(false))
                        break;

                    m_nStepNo = (int)EN_PICKUP_STEP.MOVE_RELEASE_POS;
                    break;
                #endregion </PICK_MATERIAL>

                #region <MOVE_RELEASE_POS>
                case (int)EN_PICKUP_STEP.MOVE_RELEASE_POS:
                    if (m_SubControl.MoveReleasePosition(m_SubSeqParam[0].ReleaseLevel
                                                         , m_SubSeqParam[0].ReleaseSpeed
                                                         , m_SubSeqParam[0].ReleaseRatio
                                                         , m_SubSeqParam[0].MotionPreDelay
                                                         , m_SubSeqParam[0].MotionPostDelay) != MOTION_RESULT.OK)
                    {
                        Activate = false;
                        return EN_SUBSEQUENCE_RESULT.ERROR_MOTION;
                    }

                    m_nStepNo = (int)EN_PICKUP_STEP.MOVE_READY_POS;
                    break;
                
                #endregion <MOVE_RELEASE_POS>

                #region <MOVE_READY_POS>
                case (int)EN_PICKUP_STEP.MOVE_READY_POS:
                    if (m_SubForceControl != null)
                    {
                        if (m_SubSeqForceParam == null)
                            return EN_SUBSEQUENCE_RESULT.ERROR_PARAMETER;
                        if (!m_SubForceControl.SetForce(m_SubSeqForceParam[0].MovingForce))
                            break;
                    }
                    m_nStepNo++;
                    break;
                case (int)EN_PICKUP_STEP.MOVE_READY_POS + 1:
                    if (m_SubControl.MoveReadyPosition(m_SubSeqParam[0].ReadyPosition
                                                         , m_SubSeqParam[0].MotionPreDelay
                                                         , m_SubSeqParam[0].MotionPostDelay) != MOTION_RESULT.OK)
                    {
                        Activate = false;
                        return EN_SUBSEQUENCE_RESULT.ERROR_MOTION;
                    }

                    m_nStepNo = (int)EN_PICKUP_STEP.CHECK_VACUUM;
                    break;
                #endregion </MOVE_READY_POS>

                #region <CHECK_VACUUM>
                case (int)EN_PICKUP_STEP.CHECK_VACUUM:
                    if (m_SubControl.CheckVacuum(m_SubSeqParam[0].VacuumThreshold).Equals(false))
                    {
                        Activate = false;

                        m_strSeqResultInfo = "Pick Up Fail";

                        return EN_SUBSEQUENCE_RESULT.ERROR;
                    }

                    m_nStepNo = (int)EN_PICKUP_STEP.FINISH;
                    break;
                #endregion </CHECK_VACUUM>

                #region <FINISH>
                case (int)EN_PICKUP_STEP.FINISH:
                    Activate = false;

                    return EN_SUBSEQUENCE_RESULT.OK;
                #endregion </FINISH>
            }

            return EN_SUBSEQUENCE_RESULT.WORKING;
        }
        #endregion </OVERRIDE>

        #region <PUBLIC>
        #region Force
        public void SetForceControl(ASubControl control)
        {
            m_SubForceControl = control as IPickPlaceForce;
        }
        public void AddForceParameter<T>(params T[] param)
        {
            m_SubSeqForceParam = new SubSeqPickForceParam[param.Length];

            for (int i = 0; i < param.Length; i++)
            {
                m_SubSeqForceParam[i] = param[i] as SubSeqPickForceParam;
            }
        }
        #endregion
        #endregion </PUBLIC>
    }
}
