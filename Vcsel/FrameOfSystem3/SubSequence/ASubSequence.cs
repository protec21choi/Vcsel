using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Define.DefineEnumProject.SubSequence;

namespace FrameOfSystem3.SubSequence
{
    #region <VALUE CLASS>
    /// <summary>
    /// SEQUENCE 에서 사용하는 DATA 이며 CLIENT 로 부터 전달 받음
    /// </summary>
    public class SubSequenceParam
    {
        // Parameter Base Class
    }
    
    public class SubSeqInspectionResult
    {
        public string ID = string.Empty;

        public double PositionT = 0.0;
        public double PositionX = 0.0;
        public double PositionY = 0.0;
    }
    #endregion </VALUE CLASS>

    // OBJECT ROLE : 재사용 가능한 단위 시퀀스를 위해 순서(프로시저)를 제공한다. 
    public abstract class ASubSequence
    {
        #region <FIELD>
        /// <summary>
        /// TRUE 인 경우 SUB SEQUENCE 의 STEP 이 절차대로 진행할 수 있으며
        /// FALSE 인 경우 SUB SEQUENCE 의 STEP 진행이 멈추고, SubSequenceProcedure() 는 OK 를 반환한다.
        /// </summary>
        protected bool m_bActivate = false;

        protected int m_nStepNo = 0;

        protected SubSeqInspectionResult m_SubSeqResult         = new SubSeqInspectionResult();
        protected SubSeqInspectionResult[] m_SubSeqVisionResult = null;
        protected SubSeqInspectionResult[] m_SubSeqPositionResult = null;

        protected double m_dTouchedPosition = 0;
        protected double m_dTouchedEncorder = 0;

        protected string m_strSeqResultInfo = string.Empty;
        #endregion </FIELD>

        #region <PROPERTY>
        /// <summary>
        /// SUB SEQUENCE 를 실행 시키고자 할 때, TASK 에서 SubSequenceProcedure() 의 주기호출 전에 [Activate] 를 TRUE 로 설정
        /// 정상적인든 비정상적이든 SUB SEQUENCE 가 종료될 때 [Activate] 를 FALSE 로 설정 (일회성 시퀀스 수행 보장)
        /// </summary>
        public bool Activate 
        {
            get { return m_bActivate; } 
            set 
            { 
                m_bActivate = value;
                m_nStepNo = 0;
            } 
        }

        public int SequenceNum
        {
            get{ return m_nStepNo; }
        }
        #endregion </PROPERTY>

        #region <ABSTRACT>
        /// <summary>
        /// SUB SEQUENCE 에서 사용되는 DATA 를 인자로 받는다
        /// </summary>
        public abstract void AddParameter<T>(params T[] param) where T : SubSequenceParam;
        /// <summary>
        /// SUB SEQUENCE 의 시나리오가 정의되어 있으며, TASK 에서 주기적으로 호출해 주어야 한다.
        /// </summary>
        public abstract EN_SUBSEQUENCE_RESULT SubSequenceProcedure();
        #endregion </ABSTRACT>

        #region <VIRTUAL>
        /// <summary>
        /// int nBranch : 각 SUB SEQUENCE 에서 정의된 EUNM 의 INT VALUE
        /// </summary>
        public virtual void SetSubSeqBranch(int nBranch)
        { 
            // SEQUENCE BRANCH 가 필요한 SUB SEQUENCE 만 구현한다.
        }
        #endregion </VIRTUAL>

        #region <INTERFACE>
        /// <summary>
        /// INSPECTION RESULT 를 CLIENT 에게 전달 (VISION 관련 SUB SEQUENCE 만 사용한다.)
        /// </summary>
        public SubSeqInspectionResult GetResultData()
        {
            return m_SubSeqResult;
        }
        public SubSeqInspectionResult[] GetVisionData()
        {
            return m_SubSeqVisionResult;
        }
        public SubSeqInspectionResult[] GetPositionData()
        {
            return m_SubSeqPositionResult;
        }
        public string GetActionResultInfo()
        {
            return m_strSeqResultInfo;
        }

        public double GetTouchedPosition()
        {
            return m_dTouchedPosition;
        }

        public double GetTouchedEncorder()
        {
            return m_dTouchedEncorder;
        }
        #endregion
    }
}
