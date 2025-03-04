using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RunningTask_;
using TaskAction_;

using Motion_;

using FrameOfSystem3.Log;

using Define.DefineEnumBase.Log;
using Define.DefineEnumProject.Task;
using Define.DefineEnumProject.Task.WorkZone;
using Define.DefineEnumProject.Vision;
using Define.DefineEnumProject.SubSequence;
using EquipmentState_;
using FrameOfSystem3.Recipe;
using FrameOfSystem3.Work;
using FrameOfSystem3.DynamicLink_;
using FrameOfSystem3.SubSequence;
using FrameOfSystem3.Functional;

using FileComposite_;
using FrameOfSystem3.Views.Functional;

using BONDHEAD_TASK_PARAM = Define.DefineEnumProject.Task.BondHead.PARAM_PROCESS;

namespace FrameOfSystem3.Task
{
    class TaskWorkZone : RunningTaskEx
    {
        #region Constructor
		public TaskWorkZone(int nIndexOfTask, string strTaskName)
            : base(nIndexOfTask, strTaskName, (int)Enum.GetValues(typeof(PARAM_PROCESS)).Length)
		{
            m_enTaskName = (EN_TASK_LIST)Enum.Parse(typeof(EN_TASK_LIST), strTaskName);

			// 2020.06.02 by yjlee [ADD] Register the process parameters.
			foreach (var enParam in Enum.GetValues(typeof(PARAM_PROCESS)))
			{
				AddProcessRecipeParameter((int)enParam, enParam.ToString());
			}

			MakeMappingTableForAction();

            // 2020.06.15 by yjlee [ADD] Get the instances for the action.
            //m_instanceTaskAction        = TaskActionManager.GetInstance();
            //m_instanceActionFlow        = TaskActionFlow.GetInstance();

            _DynamicLink     = DynamicLink.GetInstance();
			m_instanceTaskInformation	= FrameOfSystem3.Config.ConfigTask.GetInstance();
            m_instanceLog = LogManager.GetInstance();

			// 2020.01.27 by twkang [ADD] Vision Sub Action 추가, 데이터 저장 Log 인스턴스 추가

            // 2020.11.27 by jhchoo [ADD] Recovery 객체 생성
            int nPortCount = 1;
            m_tRecovery = new TaskWorkZoneRecovery(strTaskName, nPortCount);

            RecoveryData tRecovery = m_tRecovery as RecoveryData;

            Enum.TryParse(strTaskName, out m_enTaskName);
            m_instanceOperator.AddRecoveryData(m_enTaskName, ref tRecovery);

        }
        #endregion

        #region Constants
        private const int DELAY_MOTION = 10;
        private const int RATIO_MOTION = 100;
        private const int DELAY_ACTION = 500;

        private const int COUNT_COLLISION_PREVENTION = 2000;
        #endregion

        #region Variables

        #region Task Information
        private EN_TASK_LIST m_enTaskName = (EN_TASK_LIST)1;
        #endregion

        #region Instances
        private static LogManager m_instanceLog = null;
        
        static DynamicLink_.DynamicLink _DynamicLink = null;

		static FrameOfSystem3.Config.ConfigTask m_instanceTaskInformation		= null;

        // 2020.12.05 by jhchoo [ADD] TaskOperator 인스턴스
        private TaskOperator m_instanceOperator = TaskOperator.GetInstance();

        private Form_ProgressBar m_instanceProgress = Form_ProgressBar.GetInstance();

        private Recipe.Recipe m_Recipe = Recipe.Recipe.GetInstance();
        #endregion

        #region Action
        private EN_TASK_ACTION m_enAction          = EN_TASK_ACTION.STOP;

		private Dictionary<string, EN_TASK_ACTION> m_mapppingForAction     = new Dictionary<string, EN_TASK_ACTION>();
        private string m_strTargetSignal = string.Empty;

        #endregion

        #region Delegates for condition

        #region Loading
        ActionNode.CheckConditionDelegate m_delegatePreconditionLoading            = null;
        ActionNode.CheckActionDelegate m_delegatePostconditionLoading               = null;
        #endregion

        #region Unloading
        ActionNode.CheckConditionDelegate m_delegatePreconditionUnloading = null;
        ActionNode.CheckActionDelegate m_delegatePostconditionUnloading = null;
        #endregion
		
		#endregion

        #region Time out / Tickcounter
        private TickCounter_.TickCounter m_tickofDelaySequence = new TickCounter_.TickCounter();
        private TickCounter_.TickCounter m_tickTimeCheck = new TickCounter_.TickCounter();
        private TickCounter_.TickCounter m_TickForDelay = new TickCounter_.TickCounter();
        private TickCounter_.TickCounter m_tickTimeOut = new TickCounter_.TickCounter();

        private int m_nInterlockTimeOut = 30000;

        #endregion

		#region Manual Action Used
        #endregion

        #region Recovery
        // 2020.11.27 by jhchoo [ADD] Recovery 객체 선언
        private TaskWorkZoneRecovery m_tRecovery = null;
        #endregion

        #region Alram Sub Information
        private string   m_strAlarmSubInfo = string.Empty;
        private string[] m_arAlarmSubInfo  = new string[] { "", "" };
        private int      m_nAlarmSubNumber = -1;
        #endregion

        private int m_nRunRatio = 100;

        #endregion

        #region Inherit Interface

        #region Status
        /// <summary>
        /// 2020.12.11 by yjlee [ADD] Get the status of the task.
        /// </summary>
        protected override void GetTaskStatus(ref int[] arIndexes, ref int[] arStatus)
        {
        }
        #endregion

        #region State Sequence
        #region Always
        /// <summary>
        /// 2020.06.02 by yjlee [ADD] It will be called always.
        /// </summary>
        protected override void DoAlwaysSequence()
        {

        }
        #endregion

        #region Initialize
        /// <summary>
        /// 2020.06.02 by yjlee [ADD] Code the sequence to initialize this task.
        /// - Before returning 'true', it will be called continuously.
        /// </summary>
        protected override bool DoInitializeSequence()
        {
            if (m_nSeqNum > (int)EN_INITIALIZE_STEP.START)
            {
                m_instanceProgress.UpdateStep(m_enTaskName.ToString()
                    , (uint)m_nSeqNum);
            }

            switch (m_nSeqNum)
            {
                case (int)EN_INITIALIZE_STEP.START:
                    m_instanceProgress.ShowForm(m_enTaskName.ToString()
                        , (int)EN_INITIALIZE_STEP.END);

                    PostOffice.GetInstance().EmptyMailBoxAll();

                    m_nSeqNum = (int)EN_INITIALIZE_STEP.CYLINDER;
                    break;

                #region Cylinder
                case (int)EN_INITIALIZE_STEP.CYLINDER:

//                     if (Cylinder_.CYLINDER_RESULT.OK != MoveBackward((int)EN_CYLINDER_LIST.WARPAGE_PUSHER, true))
//                     {
//                         m_arAlarmSubInfo = new string[] { "CYLINDER STOPPER" };
//                         GenerateSequenceAlarm((int)EN_TASK_ALARM.CYLINDER_MOVE_FALE, false, ref m_arAlarmSubInfo);
//                         m_nSeqNum = (int)EN_INITIALIZE_STEP.END;
//                         break;
//                     }
                    m_nSeqNum = (int)EN_INITIALIZE_STEP.MOTION;
                    break;
                #endregion /Cylinder

                #region Motion
                case (int)EN_INITIALIZE_STEP.MOTION:
//                     if (IsHomeEnd((int)EN_AXIS_LIST.LIFT_Z) == false) 
//                         break;

                    ++m_nSeqNum;
                    break;

                case (int)EN_INITIALIZE_STEP.MOTION + 1:
                    ++m_nSeqNum;
                    break;

                case (int)EN_INITIALIZE_STEP.MOTION + 2:
                    m_nSeqNum = (int)EN_INITIALIZE_STEP.END;
                    break;
                #endregion /Motion

                case (int)EN_INITIALIZE_STEP.END:
                    return true;
            }

            return false;
        }
        #endregion

        #region Entry
        /// <summary>
        /// 2020.06.02 by yjlee [ADD] Code the sequence for entry.
        /// - Before returning 'true', it will be called continuously.
        /// </summary>
        protected override bool DoEntrySequence()
        {
            switch (m_nSeqNum)
            {
                case (int)EN_ENTRY_STEP.START:
                    PostOffice.GetInstance().EmptyMailBoxAll();
                    m_instanceOperator.MainVacControl(true);
                    m_nRunRatio = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.RUN_RATIO.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 100);
                    ++m_nSeqNum;
                    break;

                case (int)EN_ENTRY_STEP.START + 1:
                    if (m_instanceOperator.GetRunMode() != RunningMain_.RUN_MODE.AUTO)
                    {
                        SetDelayForSequence(2000);
                        _DynamicLink.SetPortStatus(GetTaskName(), EN_PORT_LIST.WORK_PORT.ToString(), DynamicLink_.EN_PORT_STATUS.EMPTY);
                        m_nSeqNum = (int)EN_ENTRY_STEP.INITIALIZE;
                        break;

                    }
                    m_tickTimeCheck.SetTickCount(1000);
                    m_nSeqNum = (int)EN_ENTRY_STEP.INITIALIZE;
                    break;

              

                case (int)EN_ENTRY_STEP.INITIALIZE:
                    RunningMain_.TaskData pTaskTransferData = null;
                    if (m_instanceOperator.GetTaskInformation((int)EN_TASK_LIST.TRANSFER, ref pTaskTransferData) == false
                        || pTaskTransferData.strTaskState != TaskState_.TASK_STATE.READY.ToString())
                        break;
                    _DynamicLink.InitializeNodeLink(GetTaskName());
                    _DynamicLink.InitializePortLink(GetTaskName());
                    EntryNodeState();
                    m_nSeqNum = (int)EN_ENTRY_STEP.END;
                    break;

                case (int)EN_ENTRY_STEP.END:
                    return true;
            }

            return false;
        }
        #endregion

        /// <summary>
        /// 2020.06.02 by yjlee [ADD] If there is a manual action to be operated.
        /// - Before returning 'true', it will be called continuously.
        /// </summary>
        protected override bool DoSetupSequence()
        {
            switch (m_enAction)
            {
                case EN_TASK_ACTION.LOADING:
                    if (ActionBlockLoading())
                        return true;
                    break;

                case EN_TASK_ACTION.UNLOADING:
                    if (ActionBlockUnloading())
                        return true;
                    break;

                case EN_TASK_ACTION.MANUAL_LOADING:
                    if (ActionManualLoading())
                        return true;
                    break;

                case EN_TASK_ACTION.MATERIAL_RELEASE:
                    if (ActionMaterialRelease())
                        return true;
                    break;
            }

            return false;
        }

        /// <summary>
        /// 2020.06.02 by yjlee [ADD] If there is an executing action to be operated.
        /// - Before returning 'true', it will be called continuously.
        /// </summary>
        protected override bool DoExecutingSequence()
        {
            _DynamicLink.CheckState(GetTaskName());

            switch (m_enAction)
            {
                case EN_TASK_ACTION.LOADING:
                    if (ActionBlockLoading())
                        return true;
                    break;

                case EN_TASK_ACTION.UNLOADING:
                    if (ActionBlockUnloading())
                        return true;
                    break;
            }

            return false;
        }

        #region Exit
        /// <summary>
        /// 2020.06.02 by yjlee [ADD] Code the sequence for exit.
        /// - Before returning 'true', it will be called continuously.
        /// </summary>
        protected override bool DoExitSequence()
        {
            switch (m_nSeqNum)
            {
                case (int)EN_EXIT_STEP.START:
                    m_nSeqNum = (int)EN_EXIT_STEP.END;
                    break;
                case (int)EN_EXIT_STEP.END:
                    _DynamicLink.TerminateWorkFlow(GetTaskName());
                    return true;
            }

            return false;
        }
        #endregion

        #endregion

        #region Action Sequence
        /// <summary>
        /// 2020.06.02 by yjlee [ADD] Check whether a sequence is existent or not.
        /// </summary>
        protected override bool SelectSetupSequence(ref string strSequenceName)
        {
            if (m_mapppingForAction.ContainsKey(strSequenceName))
            {
                m_enAction = m_mapppingForAction[strSequenceName];

                return true;
            }
            else
            {
                m_enAction = EN_TASK_ACTION.STOP;

                return false;
            }
        }

        /// <summary>
        /// 2020.06.02 by yjlee [ADD] Check whether a sequence is existent or not.
        /// </summary>
        protected override bool SelectExecutingSequence(ref string strActionName)
        {
            string sActivatedActionName;

            if (_DynamicLink.TransitState(GetTaskName(), out sActivatedActionName))
            {
                m_enAction = m_mapppingForAction[sActivatedActionName];
                strActionName = sActivatedActionName;

                return true;
            }

            return false;
        }
        #endregion

        #region Error Sequence
        /// <summary>
        /// 2020.06.02 by yjlee [ADD] Before a warning occur, it will be called.
        /// - Before returning 'true', it will be called continuously.
        /// </summary>
        protected override bool ProcessBeforeWarning()
        {
            switch (m_nBeforeErrorSeqNum)
            {
                case (int)ERRORSEQUENCE_BEFORE_WARNING.START:
                    return true;
            }

            return false;
        }

        /// <summary>
        /// 2020.06.02 by yjlee [ADD] After a warning occur, it will be called.
        /// - Before returning 'true', it will be called continuously.
        /// </summary>
        protected override bool ProcessAfterWarning()
        {
            switch (m_nBeforeErrorSeqNum)
            {
                case (int)ERRORSEQUENCE_AFTER_WARNING.START:
                    return true;
            }

            return false;
        }

        /// <summary>
        /// 2020.06.02 by yjlee [ADD] Before an error occur, it will be called.
        /// - Before returning 'true', it will be called continuously.
        /// </summary>
        protected override bool ProcessBeforeError()
        {
            switch (m_nBeforeErrorSeqNum)
            {
                case (int)ERRORSEQUENCE_BEFORE_ERROR.START:
                    return true;
            }

            return false;
        }

        /// <summary>
        /// 2020.06.02 by yjlee [ADD] After an error occur, it will be called.
        /// - Before returning 'true', it will be called continuously.
        /// </summary>
        protected override bool ProcessAfterError()
        {
            switch (m_nBeforeErrorSeqNum)
            {
                case (int)ERRORSEQUENCE_AFTER_ERROR.START:
                    return true;
            }

            return false;
        }
        #endregion

        #region Condition Sequence
        /// <summary>
        /// 2020.06.09 by yjlee [ADD] It will be called before an action start.
        /// </summary>
        protected override void DoExecutingPrecondition()
        {
            WriteTransferLog(EN_XFR_TYPE.START);
        }

        /// <summary>
        /// 2020.06.09 by yjlee [ADD] It will be called after an action has finished.
        /// </summary>
        protected override void DoExecutingPostcondition()
        {
            _DynamicLink.SetNodeState(GetTaskName(), m_enAction.ToString(), EN_ACTION_STATE.DONE);
            
            _DynamicLink.FinishAction(GetTaskName());

            WriteTransferLog(EN_XFR_TYPE.END);
        }

        /// <summary>
        /// 2020.06.09 by yjlee [ADD] It will be called before a manual action start.
        /// </summary>
        protected override void DoSetupPrecondition()
        {
            WriteTransferLog(EN_XFR_TYPE.START);
        }

        /// <summary>
        /// 2020.06.09 by yjlee [ADD] It will be called after a manual action has finished.
        /// </summary>
        protected override void DoSetupPostcondition()
        {
            WriteTransferLog(EN_XFR_TYPE.END);
        }
        #endregion

        #region Init Condition
        public override void InitializeActionCondition()
        {
//             #region Block Loading
//             _DynamicLink.SetPortFinalCondition(GetTaskName(), EN_TASK_ACTION.LOADING.ToString(), PortFinalconditionBlockLoading);
//             _DynamicLink.SetFlowPrecondition(GetTaskName(), EN_TASK_ACTION.LOADING.ToString(), PreconditionBlockLoading);
//             _DynamicLink.SetFlowPostcondition(GetTaskName(), EN_TASK_ACTION.LOADING.ToString(), PostconditionBlockLoading);
//             #endregion
// 
//             #region Block Unloading
//             _DynamicLink.SetFlowPrecondition(GetTaskName(), EN_TASK_ACTION.UNLOADING.ToString(), PreconditionBlockUnloading);
//             _DynamicLink.SetFlowPostcondition(GetTaskName(), EN_TASK_ACTION.UNLOADING.ToString(), PostconditionBlockUnloading);
//             #endregion
        }
        #endregion

        #region Finished Action
        public override void UpdateFinishedAction(string strTargetTask, string strActionName)
        {
        }
        #endregion

        #region Move Success
        protected override bool IsMoveAbsolutelyOK(int nTargetIndex, double dblPosition)
        {
            return true;
        }
        protected override bool IsMoveReleativelyOK(int nTargetIndex, double dblDistance)
        {
            return true;
        }
        #endregion

        protected void MakeMappingTableForAction()
        {
            foreach (EN_TASK_ACTION enAction in Enum.GetValues(typeof(EN_TASK_ACTION)))
            {
                m_mapppingForAction.Add(enAction.ToString(), enAction);
            }
        }
     
	
        #region SubAction
        /// <summary>
        /// 2021.01.04 by yjlee [ADD] If there is an sub sequence.
        /// - after all sub sequence is complete, the executing sequence will be called.
        /// </summary>
        protected override bool DoExcutingSubSequence(int nIndexOfSubSequence, ref int nSequenceNumber)
        {
            switch (nIndexOfSubSequence)
            {
                case 0:
                    return true;
            }

            return false;
        }

        protected override void InitSubSequence()
        {

        }
        #endregion

        #endregion

        #region Internal Interface

        #region Action Sequence List

        #region Auto

        #region Block Loading
        private bool ActionBlockLoading()
        {
            switch (m_nSeqNum)
            {
                #region ACTION START (0 ~ )
                case (int)EN_BLOCK_LOADING_STEP.ACTION_START:
                    if (m_instanceOperator.GetRunMode() == RunningMain_.RUN_MODE.SIMULATION)
                    {
                        SetDelayForSequence(2000);
                        m_nSeqNum = (int)EN_BLOCK_LOADING_STEP.ACTION_FINISH;
                        break;

                    }
                    m_nSeqNum = (int)EN_BLOCK_LOADING_STEP.LOADING;
                    break;
                #endregion

                case (int)EN_BLOCK_LOADING_STEP.LOADING:
                    //24.07.01 by wdw [FIX] vac 순서 변경
                    //23.11.20 by wdw [FIX] vac 순서 변경
                    //WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LIFT_MATERIAL_VAC, false);
//                     WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.BLOCK_MATERIAL_VAC_1, true);
//                     WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.BLOCK_MATERIAL_VAC_2, true);
//                     int dVacuumOnDelay = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.BLOCK_MATERIAL_VAC_ON_DELAY.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);
//                     SetDelayForSequence(dVacuumOnDelay);
                    m_nSeqNum++;
                    break;

                case (int)EN_BLOCK_LOADING_STEP.LOADING + 1:
                    double Position_Z = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.LIFT_READY_POSITION_Z.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                    MOTION_RESULT enResultZ = MoveAbsolutely((int)EN_AXIS_LIST.LIFT_Z,
                                    Position_Z,
                                    MOTION_SPEED_CONTENT.RUN,
                                    m_nRunRatio,
                                    0,
                                    true);

                    if (enResultZ == MOTION_RESULT.OK)
                        m_nSeqNum++;

                    if (GetSequenceTime() > m_nInterlockTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "LIFT MOVE FAIL";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_nSeqNum = (int)EN_BLOCK_LOADING_STEP.FINISH;
                        break;
                    }
                    break;

                case (int)EN_BLOCK_LOADING_STEP.LOADING + 2:
                    //24.07.01 by wdw [FIX] vac 순서 변경
                    //23.11.20 by wdw [FIX] vac 순서 변경
//                     WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LIFT_MATERIAL_VAC, false);
//                     int dVacuumOffDelay = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.LIFT_MATERIAL_VAC_OFF_DELAY.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);
//                     SetDelayForSequence(dVacuumOffDelay);
//                     m_instanceOperator.ResetPreHeatingTimer();
//                     
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.BLOCK_MATERIAL_VAC_1, true);
                    int dVacuumLagDelay = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.BLOCK_MATERIAL_VAC_TIMELAG_DELAY.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);
                    SetDelayForSequence(dVacuumLagDelay);
                    
                    m_nSeqNum++;
                    break;

                case (int)EN_BLOCK_LOADING_STEP.LOADING + 3:
                    //24.07.01 by wdw [FIX] vac 순서 변경
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.BLOCK_MATERIAL_VAC_2, true);
                    int dVacuumOnDelay = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.BLOCK_MATERIAL_VAC_ON_DELAY.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);
                    SetDelayForSequence(dVacuumOnDelay);
                    m_nSeqNum++;
                    break;

                case (int)EN_BLOCK_LOADING_STEP.LOADING + 4:
                    //24.07.01 by wdw [FIX] vac 순서 변경
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LIFT_MATERIAL_VAC, false);
                    int dVacuumOffDelay = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.LIFT_MATERIAL_VAC_OFF_DELAY.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);
                    SetDelayForSequence(dVacuumOffDelay);
                     m_nSeqNum++;
                    break;
                case (int)EN_BLOCK_LOADING_STEP.LOADING + 5:
                    bool bWarpagePressUsed = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.WARPAGE_PRESS_USED.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, false);
                    if (m_instanceOperator.GetRunMode() == RunningMain_.RUN_MODE.AUTO)
                    {
                        double dThreshold = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.BLOCK_MATERIAL_VAC_THRESHOLD.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                        double dVacValue = ReadAnalogInputValue((int)EN_ANALOG_INPUT_LIST.BLOCK_MATERIAL_VAC);
                        if (dThreshold >= dVacValue)
                        {
                            bWarpagePressUsed = false; //vac 잡히면 사용 안함
                        }
                    }
                    if(bWarpagePressUsed)
                        m_nSeqNum = (int)EN_BLOCK_LOADING_STEP.WARPAGE_PRESS;
                    else
                        m_nSeqNum = (int)EN_BLOCK_LOADING_STEP.MOVE_WORK;
                    break;

                case (int)EN_BLOCK_LOADING_STEP.WARPAGE_PRESS:
                    double Position_X = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.BLOCK_WARPAGE_PRESS_POSITION_X.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                    double Position_Y = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.HEAD_WARPAGE_PRESS_POSITION_Y.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

                    MOTION_RESULT enResultX = MoveAbsolutely((int)EN_AXIS_LIST.BLOCK_X,
                                  Position_X,
                                  MOTION_SPEED_CONTENT.RUN,
                                  m_nRunRatio,
                                  0,
                                  true);

                    MOTION_RESULT enResultY = MoveAbsolutely((int)EN_AXIS_LIST.HEAD_Y,
                                  Position_Y,
                                  MOTION_SPEED_CONTENT.RUN,
                                  m_nRunRatio,
                                  0,
                                  true);

                    if (enResultX == MOTION_RESULT.OK
                        && enResultY == MOTION_RESULT.OK)
                        m_nSeqNum++;

                    if (GetSequenceTime() > m_nInterlockTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "HEAD MOVE FAIL";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_nSeqNum = (int)EN_BLOCK_LOADING_STEP.FINISH;
                        break;
                    }
                    break;
                case (int)EN_BLOCK_LOADING_STEP.WARPAGE_PRESS + 1:
                     Position_Z = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.BLOCK_TRANSFER_POSITION_Z.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

                    enResultZ = MoveAbsolutely((int)EN_AXIS_LIST.BLOCK_Z,
                                    Position_Z,
                                    MOTION_SPEED_CONTENT.RUN,
                                    m_nRunRatio,
                                    0,
                                    true);

                    if (enResultZ == MOTION_RESULT.OK)
                        m_nSeqNum++;

                    if (GetSequenceTime() > m_nInterlockTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "BLOCK MOVE FAIL";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_nSeqNum = (int)EN_BLOCK_LOADING_STEP.FINISH;
                        break;
                    }
                    break;
                case (int)EN_BLOCK_LOADING_STEP.WARPAGE_PRESS + 2:
                    Cylinder_.CYLINDER_RESULT enResultCylinder = MoveForward((int)EN_CYLINDER_LIST.WARPAGE_PUSHER, true);
                    if (enResultCylinder == Cylinder_.CYLINDER_RESULT.OK)
                        m_nSeqNum++;

                    if (GetSequenceTime() > m_nInterlockTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "WARPAGE PRESURE MOVE FAIL";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_nSeqNum = (int)EN_BLOCK_LOADING_STEP.FINISH;
                        break;
                    }
                    break;
                case (int)EN_BLOCK_LOADING_STEP.WARPAGE_PRESS + 3:
                    int dPressTime = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.WARPAGE_PRESS_TIME.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);
                    SetDelayForSequence(dPressTime);
                    m_nSeqNum++;
                    break;
                case (int)EN_BLOCK_LOADING_STEP.WARPAGE_PRESS + 4:
                    enResultCylinder = MoveBackward((int)EN_CYLINDER_LIST.WARPAGE_PUSHER, true);

                    if (enResultCylinder == Cylinder_.CYLINDER_RESULT.OK)
                        m_nSeqNum = (int)EN_BLOCK_LOADING_STEP.MOVE_WORK;

                    if (GetSequenceTime() > m_nInterlockTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "WARPAGE PRESURE MOVE FAIL";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_nSeqNum = (int)EN_BLOCK_LOADING_STEP.FINISH;
                        break;
                    }
                    break;

                case (int)EN_BLOCK_LOADING_STEP.MOVE_WORK:
                    if (m_instanceOperator.GetRunMode() == RunningMain_.RUN_MODE.AUTO)
                    {
                        double dThreshold = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.BLOCK_MATERIAL_VAC_THRESHOLD.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                        double dVacValue = ReadAnalogInputValue((int)EN_ANALOG_INPUT_LIST.BLOCK_MATERIAL_VAC);
                        if (dThreshold < dVacValue)
                        {
                            m_arAlarmSubInfo[0] = "BLOCK VAC VALUE : " + dVacValue.ToString();
                            GenerateSequenceAlarm((int)EN_TASK_ALARM.VAC_CHECK_FAIL, false, ref m_arAlarmSubInfo);
                            m_nSeqNum = (int)EN_BLOCK_LOADING_STEP.ACTION_FINISH; //일단  자재가 블럭 위  임으로 DONE으로 보자
                            break;
                        }
                    }
                    m_instanceOperator.ResetPreHeatingTimer();
                    m_nSeqNum++;
                    break;
                case (int)EN_BLOCK_LOADING_STEP.MOVE_WORK + 1:
                    Position_Z = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.BLOCK_READY_POSITION_Z.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

                    enResultZ = MoveAbsolutely((int)EN_AXIS_LIST.BLOCK_Z,
                                    Position_Z,
                                    MOTION_SPEED_CONTENT.RUN,
                                    m_nRunRatio,
                                    0,
                                    true);
                    
                    if (enResultZ == MOTION_RESULT.OK)
                        m_nSeqNum++;

                    if (GetSequenceTime() > m_nInterlockTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "BLOCK MOVE FAIL";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_nSeqNum = (int)EN_BLOCK_LOADING_STEP.ACTION_FINISH; //일단 자재가 블럭 위 임으로 DONE으로 보자
                        break;
                    }
                   
                    break;

                case (int)EN_BLOCK_LOADING_STEP.MOVE_WORK + 2:
                    Position_X = m_Recipe.GetValue(EN_TASK_LIST.BOND_HEAD.ToString(), BONDHEAD_TASK_PARAM.LASER_WORK_POSITION_X.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                    Position_Y = m_Recipe.GetValue(EN_TASK_LIST.BOND_HEAD.ToString(), BONDHEAD_TASK_PARAM.LASER_WORK_POSITION_Y.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

                    enResultX = MoveAbsolutely((int)EN_AXIS_LIST.BLOCK_X,
                                  Position_X,
                                  MOTION_SPEED_CONTENT.RUN,
                                  m_nRunRatio,
                                  0,
                                  true);


                    enResultY = MoveAbsolutely((int)EN_AXIS_LIST.HEAD_Y,
                                  Position_Y,
                                  MOTION_SPEED_CONTENT.RUN,
                                  m_nRunRatio,
                                  0,
                                  true);

                    if (enResultX == MOTION_RESULT.OK
                        && enResultY == MOTION_RESULT.OK)
                        m_nSeqNum = (int)EN_BLOCK_LOADING_STEP.ACTION_FINISH;

                    if (GetSequenceTime() > m_nInterlockTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "HEAD MOVE FAIL";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_nSeqNum = (int)EN_BLOCK_LOADING_STEP.ACTION_FINISH; //일단 자재가 블럭 위 임으로 DONE으로 보자
                        break;
                    }
                    break;


                #region ACTION FINISH (9900 ~ )
                case (int)EN_BLOCK_LOADING_STEP.ACTION_FINISH:
                    _DynamicLink.SetPortStatus(GetTaskName(), EN_PORT_LIST.WORK_PORT.ToString(), DynamicLink_.EN_PORT_STATUS.WORKING, false);
                    _DynamicLink.SetPortStatus(EN_TASK_LIST.BOND_HEAD.ToString(), EN_PORT_LIST.WORK_PORT.ToString(), DynamicLink_.EN_PORT_STATUS.WORKING);
                    m_nSeqNum = (int)EN_BLOCK_LOADING_STEP.FINISH;
                    break;
                #endregion

                #region FINISH
                case (int)EN_BLOCK_LOADING_STEP.FINISH:
                    return true;
                #endregion
            }
            return false;
        }
        #endregion

        #region Block Unloading
        private bool ActionBlockUnloading()
        {
            switch (m_nSeqNum)
            {
                #region ACTION START (0 ~ )
                case (int)EN_BLOCK_UNLOADING_STEP.ACTION_START:
                    if (m_instanceOperator.GetRunMode() == RunningMain_.RUN_MODE.SIMULATION)
                    {
                        SetDelayForSequence(2000);
                        m_nSeqNum = (int)EN_BLOCK_UNLOADING_STEP.ACTION_FINISH;
                        break;

                    }
                    m_nSeqNum = (int)EN_BLOCK_UNLOADING_STEP.MOVE_UNLOADING;
                    break;
                #endregion

                case (int)EN_BLOCK_UNLOADING_STEP.MOVE_UNLOADING:
                    double Position_Z = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.BLOCK_READY_POSITION_Z.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

                    MOTION_RESULT enResultZ = MoveAbsolutely((int)EN_AXIS_LIST.BLOCK_Z,
                                  Position_Z,
                                  MOTION_SPEED_CONTENT.RUN,
                                  m_nRunRatio,
                                  0,
                                  true);

                    if (enResultZ == MOTION_RESULT.OK)
                        m_nSeqNum++;

                    if (GetSequenceTime() > m_nInterlockTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "BLOCK MOVE FAIL";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_nSeqNum = (int)EN_BLOCK_UNLOADING_STEP.FINISH;
                        break;
                    }
                    break;
                case (int)EN_BLOCK_UNLOADING_STEP.MOVE_UNLOADING + 1:

                    double Position_X = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.BLOCK_TRANSFER_POSITION_X.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

                    MOTION_RESULT enResultX = MoveAbsolutely((int)EN_AXIS_LIST.BLOCK_X,
                                  Position_X,
                                  MOTION_SPEED_CONTENT.RUN,
                                  m_nRunRatio,
                                  0,
                                  true);

                    if (enResultX == MOTION_RESULT.OK)
                        m_nSeqNum++;

                    if (GetSequenceTime() > m_nInterlockTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "BLOCK MOVE FAIL";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_nSeqNum = (int)EN_BLOCK_UNLOADING_STEP.FINISH;
                        break;
                    }
                    break;
                case (int)EN_BLOCK_UNLOADING_STEP.MOVE_UNLOADING + 2:
                    m_nSeqNum = (int)EN_BLOCK_UNLOADING_STEP.UNLOADING;
                    break;

                case (int)EN_BLOCK_UNLOADING_STEP.UNLOADING:
                    //                     WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LIFT_MATERIAL_VAC, true);
                    //                     WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.BLOCK_MATERIAL_VAC_1, false);
                    //                     WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.BLOCK_MATERIAL_VAC_2, false);
                    //                     WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.BLOCK_MATERIAL_BLOW, true);
                    //                     int dLiftVacOffDelay = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.LIFT_MATERIAL_VAC_OFF_DELAY.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);
                    //                     SetDelayForSequence(dLiftVacOffDelay);
                    m_nSeqNum++;
                    break;
                case (int)EN_BLOCK_UNLOADING_STEP.UNLOADING + 1:
                    //                     Position_Z = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.LIFT_TRANSFER_POSITION_Z.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                    // 
                    //                  
                    // 
                    //                     enResultZ= MoveAbsolutely((int)EN_AXIS_LIST.LIFT_Z,
                    //                                   Position_Z,
                    //                                   MOTION_SPEED_CONTENT.RUN,
                    //                                   m_nRunRatio,
                    //                                   0,
                    //                                   true);
                    // 
                    //                     if (enResultZ == MOTION_RESULT.OK)
                    //                         m_nSeqNum++;
                    // 
                    //                     if (GetSequenceTime() > m_nInterlockTimeOut)
                    //                     {
                    //                         m_arAlarmSubInfo[0] = "LIFT MOVE FAIL";
                    //                         GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo);
                    //                         m_nSeqNum = (int)EN_BLOCK_UNLOADING_STEP.FINISH;
                    //                         break;
                    //                     }
                    m_nSeqNum++;
                    break;
                case (int)EN_BLOCK_UNLOADING_STEP.UNLOADING + 2:
                    //WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.BLOCK_MATERIAL_BLOW, false);
                    m_nSeqNum = (int)EN_BLOCK_UNLOADING_STEP.ACTION_FINISH;
                    break;

                #region ACTION FINISH (9900 ~ )
                case (int)EN_BLOCK_UNLOADING_STEP.ACTION_FINISH:
                    _DynamicLink.SetPortStatus(GetTaskName(), EN_PORT_LIST.WORK_PORT.ToString(), DynamicLink_.EN_PORT_STATUS.FINISHED);
                    m_nSeqNum = (int)EN_BLOCK_UNLOADING_STEP.FINISH;
                    break;
                #endregion

                #region FINISH
                case (int)EN_BLOCK_UNLOADING_STEP.FINISH:
                    return true;
                #endregion

            }
            return false;
        }
        #endregion
        #endregion

        #region Manaul
        private bool ActionManualLoading()
        {
            switch (m_nSeqNum)
            {
                #region ACTION START (0 ~ )
                case (int)EN_BLOCK_LOADING_STEP.ACTION_START:
                    if (m_instanceOperator.GetRunMode() == RunningMain_.RUN_MODE.SIMULATION)
                    {
                        SetDelayForSequence(2000);
                        m_nSeqNum = (int)EN_BLOCK_LOADING_STEP.ACTION_FINISH;
                        break;

                    }
                    m_nSeqNum = (int)EN_BLOCK_LOADING_STEP.LOADING;
                    break;
                #endregion

                case (int)EN_BLOCK_LOADING_STEP.LOADING:
                    //23.11.20 by wdw [FIX] vac 순서 변경
                    //WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LIFT_MATERIAL_VAC, false);
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.BLOCK_MATERIAL_VAC_1, true);
                    int dVacuumOnDelay = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.BLOCK_MATERIAL_VAC_TIMELAG_DELAY.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);
                    SetDelayForSequence(dVacuumOnDelay);
                    m_nSeqNum++;
                    break;

                case (int)EN_BLOCK_LOADING_STEP.LOADING + 1:
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.BLOCK_MATERIAL_VAC_2, true);
                    dVacuumOnDelay = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.BLOCK_MATERIAL_VAC_ON_DELAY.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);
                    SetDelayForSequence(dVacuumOnDelay);
                    m_nSeqNum++;
                    break;

                case (int)EN_BLOCK_LOADING_STEP.LOADING + 2:
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LIFT_MATERIAL_VAC, false);
                    int dVacuumOffDelay = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.LIFT_MATERIAL_VAC_OFF_DELAY.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);
                    SetDelayForSequence(dVacuumOffDelay);
                    m_instanceOperator.ResetPreHeatingTimer();
                    m_nSeqNum = (int)EN_BLOCK_LOADING_STEP.MOVE_WORK;
                    break;
            
                case (int)EN_BLOCK_LOADING_STEP.MOVE_WORK:
                    if (m_instanceOperator.GetRunMode() == RunningMain_.RUN_MODE.AUTO)
                    {
                        double dThreshold = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.BLOCK_MATERIAL_VAC_THRESHOLD.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                        double dVacValue = ReadAnalogInputValue((int)EN_ANALOG_INPUT_LIST.BLOCK_MATERIAL_VAC);
                        if (dThreshold < dVacValue)
                        {
                            m_arAlarmSubInfo[0] = "BLOCK VAC VALUE : " + dVacValue.ToString();
                            GenerateSequenceAlarm((int)EN_TASK_ALARM.VAC_CHECK_FAIL, false, ref m_arAlarmSubInfo);
                            m_nSeqNum = (int)EN_BLOCK_LOADING_STEP.ACTION_FINISH; //일단  자재가 블럭 위  임으로 DONE으로 보자
                            break;
                        }
                    }
                    m_nSeqNum++;
                    break;
              

                case (int)EN_BLOCK_LOADING_STEP.MOVE_WORK + 1:
                    double Position_X = m_Recipe.GetValue(EN_TASK_LIST.BOND_HEAD.ToString(), BONDHEAD_TASK_PARAM.LASER_WORK_POSITION_X.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                    double Position_Y = m_Recipe.GetValue(EN_TASK_LIST.BOND_HEAD.ToString(), BONDHEAD_TASK_PARAM.LASER_WORK_POSITION_Y.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

                    MOTION_RESULT enResultX = MoveAbsolutely((int)EN_AXIS_LIST.BLOCK_X,
                                  Position_X,
                                  MOTION_SPEED_CONTENT.RUN,
                                  m_nRunRatio,
                                  0,
                                  true);


                    MOTION_RESULT enResultY = MoveAbsolutely((int)EN_AXIS_LIST.HEAD_Y,
                                  Position_Y,
                                  MOTION_SPEED_CONTENT.RUN,
                                  m_nRunRatio,
                                  0,
                                  true);

                    if (enResultX == MOTION_RESULT.OK
                        && enResultY == MOTION_RESULT.OK)
                        m_nSeqNum = (int)EN_BLOCK_LOADING_STEP.ACTION_FINISH;

                    if (GetSequenceTime() > m_nInterlockTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "HEAD MOVE FAIL";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_nSeqNum = (int)EN_BLOCK_LOADING_STEP.ACTION_FINISH; //일단 자재가 블럭 위 임으로 DONE으로 보자
                        break;
                    }
                    break;

                case (int)EN_BLOCK_LOADING_STEP.MOVE_WORK + 2:
                    double Position_Z = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.BLOCK_WORK_POSITION_Z.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

                    MOTION_RESULT enResultZ = MoveAbsolutely((int)EN_AXIS_LIST.BLOCK_Z,
                                    Position_Z,
                                    MOTION_SPEED_CONTENT.RUN,
                                    m_nRunRatio,
                                    0,
                                    true);

                    if (enResultZ == MOTION_RESULT.OK)
                        m_nSeqNum = (int)EN_BLOCK_LOADING_STEP.ACTION_FINISH;

                    if (GetSequenceTime() > m_nInterlockTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "BLOCK MOVE FAIL";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_nSeqNum = (int)EN_BLOCK_LOADING_STEP.ACTION_FINISH; //일단 자재가 블럭 위 임으로 DONE으로 보자
                        break;
                    }

                    break;
                #region ACTION FINISH (9900 ~ )
                case (int)EN_BLOCK_LOADING_STEP.ACTION_FINISH:
                     string strID = "WORK";
                    strID += String.Format("_{0:0000}{1:00}{2:00}{3:00}{4:00}{5:00}",
                        DateTime.Now.Year,
                        DateTime.Now.Month,
                        DateTime.Now.Day,
                        DateTime.Now.Hour,
                        DateTime.Now.Minute,
                        DateTime.Now.Second);
                    WorkMap.GetInstance().ResetMap(strID);
                    _DynamicLink.SetPortStatus(GetTaskName(), EN_PORT_LIST.WORK_PORT.ToString(), DynamicLink_.EN_PORT_STATUS.WORKING, false);
                    _DynamicLink.SetPortStatus(EN_TASK_LIST.BOND_HEAD.ToString(), EN_PORT_LIST.WORK_PORT.ToString(), DynamicLink_.EN_PORT_STATUS.WORKING);
                    m_nSeqNum = (int)EN_BLOCK_LOADING_STEP.FINISH;
                    break;
                #endregion

                #region FINISH
                case (int)EN_BLOCK_LOADING_STEP.FINISH:
                    return true;
                #endregion
            }
            return false;
        }

        #region Material Release
        private bool ActionMaterialRelease()
        {
            switch (m_nSeqNum)
            {
                #region ACTION START (0 ~ )
                case (int)EN_MATERIAL_RELEASE_STEP.ACTION_START:
                    if (m_instanceOperator.GetRunMode() == RunningMain_.RUN_MODE.SIMULATION)
                        SetDelayForSequence(2000);

                    m_nSeqNum = (int)EN_MATERIAL_RELEASE_STEP.MOVE_READY;
                    break;
                #endregion

           
                case (int)EN_MATERIAL_RELEASE_STEP.MOVE_READY:
                    double Position_X = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.HEAD_READY_POSITION_X.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                    double Position_Y = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.HEAD_READY_POSITION_Y.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

                    MOTION_RESULT enResultX = MoveAbsolutely((int)EN_AXIS_LIST.BLOCK_X,
                                Position_X,
                                MOTION_SPEED_CONTENT.RUN,
                                m_nRunRatio,
                                0,
                                true);

                    MOTION_RESULT enResultY = MoveAbsolutely((int)EN_AXIS_LIST.HEAD_Y,
                                  Position_Y,
                                  MOTION_SPEED_CONTENT.RUN,
                                  m_nRunRatio,
                                  0,
                                  true);

                    if (enResultX == MOTION_RESULT.OK
                        && enResultY == MOTION_RESULT.OK)
                        ++m_nSeqNum;

                    if (GetSequenceTime() > m_nInterlockTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "HEAD MOVE FAIL";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_nSeqNum = (int)EN_BLOCK_LOADING_STEP.ACTION_FINISH; //일단 자재가 블럭 위 임으로 DONE으로 보자
                        break;
                    }
                    break;
              
                case (int)EN_MATERIAL_RELEASE_STEP.MOVE_READY + 1:
                    double Position_Z = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.BLOCK_READY_POSITION_Z.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

                    if (MoveAbsolutely((int)EN_AXIS_LIST.BLOCK_Z, Position_Z, Motion_.MOTION_SPEED_CONTENT.RUN, m_nRunRatio, 0, true) == Motion_.MOTION_RESULT.OK)
                        m_nSeqNum = (int)EN_MATERIAL_RELEASE_STEP.VAC_RELEASE;
                    break;

                case (int)EN_MATERIAL_RELEASE_STEP.VAC_RELEASE:
                    WriteOutput((int)EN_DIGITAL_OUTPUT_LIST.BLOCK_MATERIAL_VAC_1, false);
                    WriteOutput((int)EN_DIGITAL_OUTPUT_LIST.BLOCK_MATERIAL_VAC_2, false);
                    WriteOutput((int)EN_DIGITAL_OUTPUT_LIST.BLOCK_MATERIAL_BLOW, true);
                    int nDelay = 0;
                    GetParameter((int)PARAM_PROCESS.BLOCK_MATERIAL_VAC_OFF_DELAY, 0, ref nDelay);
                    SetDelayForSequence(nDelay);
                    ++m_nSeqNum;
                    break;
                case (int)EN_MATERIAL_RELEASE_STEP.VAC_RELEASE + 1:
                    WriteOutput((int)EN_DIGITAL_OUTPUT_LIST.BLOCK_MATERIAL_BLOW, false);
                    m_nSeqNum = (int)EN_MATERIAL_RELEASE_STEP.ACTION_FINISH;
                    break;

                #region ACTION FINISH (9900 ~ )
                case (int)EN_MATERIAL_RELEASE_STEP.ACTION_FINISH:
                    _DynamicLink.SetPortStatus(GetTaskName(), EN_PORT_LIST.WORK_PORT.ToString(), DynamicLink_.EN_PORT_STATUS.EMPTY);
                    m_nSeqNum = (int)EN_MATERIAL_RELEASE_STEP.FINISH;
                    break;
                #endregion

                #region FINISH
                case (int)EN_MATERIAL_RELEASE_STEP.FINISH:
                    return true;
                #endregion
            }
            return false;
        }
        #endregion
        #endregion

        #region Delay

        #region Background Check
        /// <summary>
        /// 2020.08.05 by twkang [ADD] 시퀀스에 맞는 딜레이를 설정한다.
        /// 2020.09.14 by ssh [MOD] Delay for Background
        /// </summary>
        private void SetDelaySequenceAtBackground(PARAM_PROCESS enParam)
        {
            //switch (enParam)
            //{
            //    case PARAM_PROCESS.DELAY_TIME_DIE_SHUTTLE_PAD_BLOW_ON:
            //    case PARAM_PROCESS.DELAY_TIME_HEAD_DIPPING_DOWN:
            //    case PARAM_PROCESS.DELAY_TIME_HEAD_PICK_DOWN:
            //    case PARAM_PROCESS.DELAY_TIME_LASER_RESETTING:
            //        break;
            //    default:
            //        return;
            //}

            int nDelay = 0;

            GetParameter((int)enParam, 0, ref nDelay);

            SetDelayForSequence(nDelay);
        }
        #endregion

        #region Sequence Check
        /// <summary>
        /// 2020.09.14 by ssh [ADD] Setting delay check at the in sequence.
        /// </summary>
        private void SetDelaySequenceAtInSequence(int nDelay)
        {
            //switch (enParam)
            //{
            //    case PARAM_PROCESS.DELAY_TIME_DIE_SHUTTLE_PAD_BLOW_ON:
            //    case PARAM_PROCESS.DELAY_TIME_HEAD_DIPPING_DOWN:
            //    case PARAM_PROCESS.DELAY_TIME_HEAD_PICK_DOWN:
            //    case PARAM_PROCESS.DELAY_TIME_LASER_RESETTING:
            //        break;
            //    default:
            //        return;
            //}

            m_tickofDelaySequence.SetTickCount((uint)nDelay);
        }

        /// <summary>
        /// 2020.09.14 by ssh [ADD] Check delay in sequence
        /// </summary>
        /// <returns>Over the setting value</returns>
        private bool IsDelaySequenceByInSequence()
        {
            return m_tickofDelaySequence.IsTickOver(false);
        }
        #endregion

        #endregion

        #region Compare Position
        /// <summary>
        /// 2020.12.11 by ssh [ADD] Check target axis Actual Position to Target Position compare
        /// </summary>
        /// <param name="nAxis">Axis Number</param>
        /// <param name="enProcess">Target Process</param>
        /// <param name="bCompare">true : Above / false : Below</param>
        /// <returns>compare result</returns>
        private bool ComparePosition(int nAxis, PARAM_PROCESS enProcess, bool bCompare)
        {
            double dblTargetPosition = 0;
            double dblActualPosition = 0;

            GetParameter((int)enProcess, 0, ref dblTargetPosition);
            dblActualPosition = GetActualPosition(nAxis);

            if (bCompare)           // Above
            {
                return dblActualPosition >= dblTargetPosition;
            }
            else                    // Below
            {
                return dblActualPosition <= dblTargetPosition;
            }
        }
        #endregion

        #endregion Action Sequence List

        #region Log
        /// <summary>
        /// 2021.01.18 by yjlee [ADD] Write the transfer log.
        /// </summary>
        private void WriteTransferLog(EN_XFR_TYPE enLogType)
        {
            m_instanceLog.WriteTransferLog(GetTaskName()
                                            , enLogType
                                            , m_enAction.ToString()
                                            , string.Empty      // Material ID
                                            , string.Empty      // Material Type
                                            , string.Empty      // From
                                            , string.Empty);    // To
        }
        #endregion End - Log

        #region DynamicLink
        private void EntryNodeState()
        {
            _DynamicLink.InitializeNodeState(GetTaskName());
            DynamicLink_.EN_PORT_STATUS enPort = DynamicLink_.EN_PORT_STATUS.EMPTY;
            _DynamicLink.GetPortStatus(GetTaskName(), EN_PORT_LIST.WORK_PORT.ToString(), ref enPort);

            switch (enPort)
            {
                
                case DynamicLink_.EN_PORT_STATUS.WORKING:
                    _DynamicLink.SetNodeState(GetTaskName(), EN_TASK_ACTION.LOADING.ToString(), EN_ACTION_STATE.DONE);
                    break;

                case DynamicLink_.EN_PORT_STATUS.FINISHED:
                    _DynamicLink.SetNodeState(GetTaskName(), EN_TASK_ACTION.LOADING.ToString(), EN_ACTION_STATE.DONE);
                    _DynamicLink.SetNodeState(GetTaskName(), EN_TASK_ACTION.UNLOADING.ToString(), EN_ACTION_STATE.DONE);
                    break;
            }
        }
        #endregion

        private bool CheckMaterialExist()
        {
            int nAIIndex = (int)EN_ANALOG_INPUT_LIST.BLOCK_MATERIAL_VAC;
          
            double dThreshold = m_Recipe.GetValue(GetTaskName(), Define.DefineEnumProject.Task.WorkZone.PARAM_PROCESS.BLOCK_MATERIAL_VAC_THRESHOLD.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

            return dThreshold > ReadAnalogInputValue(nAIIndex);
        }
        #endregion

        #region External Interface
        public override void ClearMaterial()
        {
            _DynamicLink.SetPortStatus(GetTaskName(), EN_PORT_LIST.WORK_PORT.ToString(), DynamicLink_.EN_PORT_STATUS.EMPTY);
        }
        #endregion

        #region Enumerable

        #region Step

        private enum EN_INITIALIZE_STEP
        {
            START = 0,
            PREPARE = 50,
            CYLINDER = 100,
            MOTION = 200,
            END = 10000,
        }

        #region Entry
        /// <summary>
        /// 2020.06.02 by yjlee [ADD] Enumerate the step for entry sequence.
        /// </summary>
        private enum EN_ENTRY_STEP
        {
            START = 0,        // 'START' must be '0'.

            CHECK_MATERIAL = 100,

            INITIALIZE = 500,

            END = 1000,
        }
        #endregion

        #region Exit
        /// <summary>
        /// 2020.06.02 by yjlee [ADD] Enumerate the step for exit sequence.
        /// </summary>
        private enum EN_EXIT_STEP
        {
            START = 0,        // 'START' must be '0'.

            END = 1000,
        }
        #endregion

        #region Error Step
        /// <summary>
        /// 2020.06.02 by yjlee [ADD Enumerate the sequence step for the 'before warning'.
        /// </summary>
        private enum ERRORSEQUENCE_BEFORE_WARNING
        {
            START = 0,

            END = 1000,
        }
        /// <summary>
        /// 2020.06.02 by yjlee [ADD Enumerate the sequence step for the 'after warning'.
        /// </summary>
        private enum ERRORSEQUENCE_AFTER_WARNING
        {
            START = 0,

            END = 1000,
        }
        /// <summary>
        /// 2020.06.02 by yjlee [ADD Enumerate the sequence step for the 'before error'.
        /// </summary>
        private enum ERRORSEQUENCE_BEFORE_ERROR
        {
            START = 0,

            END = 1000,
        }
        /// <summary>
        /// 2020.06.02 by yjlee [ADD Enumerate the sequence step for the 'after error'.
        /// </summary>
        private enum ERRORSEQUENCE_AFTER_ERROR
        {
            START = 0,

            END = 1000,
        }
        #endregion

        #region Action
        private enum EN_BLOCK_LOADING_STEP
        {
            ACTION_START = 0,

            LOADING = 1000,
            WARPAGE_PRESS = 2000,
            MOVE_WORK = 3000,
            
            ACTION_FINISH = 9900,
            FINISH = 10000,
        }

        private enum EN_BLOCK_UNLOADING_STEP
        {
            ACTION_START = 0,

            MOVE_UNLOADING = 1000,
            UNLOADING = 2000,

            ACTION_FINISH = 9900,
            FINISH = 10000,
        }

        #region Manual

        #region Material Release
        private enum EN_MATERIAL_RELEASE_STEP
        {
            ACTION_START = 0,

            WORK_READY = 100,

            MOVE_READY = 1000,
            VAC_RELEASE = 2000,
            
            ACTION_FINISH = 9900,
            FINISH = 10000,
        }
        #endregion

        #endregion
      
        #endregion

        #endregion

        #region SubAction
        private enum EN_SUBACTION_LIST
        {
            INPUT_PICK = 0,
            OUTPUT_PLACE = 1,
        }
        #endregion

        #endregion

        // 2020.12.01 by jhchoo [ADD] RecoveryData Class 
        #region Recovery Inherit Class
        class TaskWorkZoneRecovery : RecoveryData
        {
            #region 변수
            private string m_strID = "";
            #endregion

            #region 속성
            public string strID { set { m_strID = value; } get { return m_strID; } }
            #endregion

            #region 생성자
            public TaskWorkZoneRecovery(string sTaskName, int nPortCount)
                : base(sTaskName, nPortCount)
            {
            }
            #endregion

            #region SAVE
            protected override void SaveData(ref FileComposite fComp, string sRootName)
            {
                fComp.AddItem(sRootName, "ID", m_strID);
            }
            #endregion

            #region LOAD
            protected override void LoadData(ref FileComposite fComp, string sRootName)
            {
                fComp.GetValue(sRootName, "ID", ref m_strID);
            }
            #endregion
        }
        #endregion
    }
}
