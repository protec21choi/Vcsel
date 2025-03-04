using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using RunningTask_;
using TaskAction_;

using Motion_;

using FrameOfSystem3.Log;

using Define.DefineEnumBase.Log;
using Define.DefineEnumProject.Task;
using Define.DefineEnumProject.Task.Transfer;
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

using WORKZONE_TASK_PARAM = Define.DefineEnumProject.Task.WorkZone.PARAM_PROCESS;

using Define.DefineEnumProject.Mail;

using FrameOfSystem3.ExternalDevice;

namespace FrameOfSystem3.Task
{
    class TaskTransfer : RunningTaskEx
    {
        #region Constructor
		public TaskTransfer(int nIndexOfTask, string strTaskName)
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
            m_tRecovery = new TransferRecovery(strTaskName, nPortCount);

            RecoveryData tRecovery = m_tRecovery as RecoveryData;

            Enum.TryParse(strTaskName, out m_enTaskName);
            m_instanceOperator.AddRecoveryData(m_enTaskName, ref tRecovery);

            _mySubscriberName = EN_SUBSCRIBER.TASK_TRANSFER;

            _postOffice = PostOffice.GetInstance();
            _postOffice.RequestSubscribe(_mySubscriberName);

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

        PostOffice _postOffice = null;
        readonly EN_SUBSCRIBER _mySubscriberName;

        #endregion

        #region Action
        private EN_TASK_ACTION m_enAction          = EN_TASK_ACTION.STOP;

		private Dictionary<string, EN_TASK_ACTION> m_mapppingForAction     = new Dictionary<string, EN_TASK_ACTION>();
        private string m_strTargetSignal = string.Empty;

        #endregion

        #region Delegates for condition

        #region Equipment Loading
        ActionNode.CheckConditionDelegate m_delegatePreconditionEquipmentLoading            = null;
        ActionNode.CheckActionDelegate m_delegatePostconditionEquipmentLoading = null;
        #endregion

        #region Block Loading
        ActionNode.CheckConditionDelegate m_delegatePreconditionBlockLoading = null;
        ActionNode.CheckActionDelegate m_delegatePostconditionBlockLoading = null;
        #endregion

        #region Block Unloading
        ActionNode.CheckConditionDelegate m_delegatePreconditionBlockUnloading = null;
        ActionNode.CheckActionDelegate m_delegatePostconditionBlockUnloading = null;
        #endregion
		
        #region Equipment Unloading
        ActionNode.CheckConditionDelegate m_delegatePreconditionEquipmentUnloading = null;
        ActionNode.CheckActionDelegate m_delegatePostconditionEquipmentUnloading = null;
        #endregion

		#endregion

        #region Time out / Tickcounter
        private TickCounter_.TickCounter m_tickofDelaySequence = new TickCounter_.TickCounter();
        private TickCounter_.TickCounter m_tickTimeCheck = new TickCounter_.TickCounter();
        private TickCounter_.TickCounter m_TickForDelay = new TickCounter_.TickCounter();
        private TickCounter_.TickCounter m_tickTimeOut = new TickCounter_.TickCounter();

        private int m_nInterlockTimeOut = 30000;
        private int m_nCommunicationTimeOut = 180000;
        #endregion

		#region Manual Action Used
        #endregion

        #region Recovery
        // 2020.11.27 by jhchoo [ADD] Recovery 객체 선언
        private TransferRecovery m_tRecovery = null;
        #endregion

        #region Alram Sub Information
        private string   m_strAlarmSubInfo = string.Empty;
        private string[] m_arAlarmSubInfo  = new string[] { "", "" };
        private int      m_nAlarmSubNumber = -1;
        #endregion

        private int m_nRunRatio = 100;

        private EN_TASK_ACTION m_enRecoveryAction = EN_TASK_ACTION.STOP;
        private int m_nRecoveryStep = 0;

        private string m_strID = string.Empty;

        private bool m_bExistBlock = false;
        private bool m_bExistHandler = false;
        private bool m_bExistLift = false;

        string[] m_arWaferInfo = new string[14];
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
                    m_instanceOperator.MainVacControl(true);

                    PostOffice.GetInstance().EmptyMailBoxAll();
                    m_enRecoveryAction = EN_TASK_ACTION.STOP;
                    m_nRecoveryStep = 0;
                    m_nSeqNum = (int)EN_INITIALIZE_STEP.CYLINDER;
                    break;

                #region Cylinder
                case (int)EN_INITIALIZE_STEP.CYLINDER:
                    if (Cylinder_.CYLINDER_RESULT.OK != MoveBackward((int)EN_CYLINDER_LIST.WARPAGE_PUSHER, true))
                    {
                        m_arAlarmSubInfo = new string[] { "WARPAGE CYLINDER" };
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.MOVE_FAIL, false, ref m_arAlarmSubInfo);
                        m_nSeqNum = (int)EN_INITIALIZE_STEP.END;
                        break;
                    }
                      m_nSeqNum++;
                    break;
                case (int)EN_INITIALIZE_STEP.CYLINDER+1:
                    if(Cylinder_.Cylinder.GetInstance().GetCylinderState((int)Define.DefineEnumProject.Cylinder.EN_CYLINDER.POWERMETER) 
                        == Cylinder_.CYLINDER_STATE.BACKWARD)
                    m_nSeqNum = (int)EN_INITIALIZE_STEP.MOTION;
                    break;
                #endregion /Cylinder

                #region Motion
                case (int)EN_INITIALIZE_STEP.MOTION:
                    {
                        WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.BLOCK_MATERIAL_VAC_1, false);
                        WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.BLOCK_MATERIAL_VAC_2, false);
                        WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LIFT_MATERIAL_VAC, true);
                        WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.HANDLER_MATERIAL_VAC, true);
                        int nDelay = m_Recipe.GetValue(EN_TASK_LIST.WORK_ZONE.ToString(), WORKZONE_TASK_PARAM.BLOCK_MATERIAL_VAC_OFF_DELAY.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);
                        SetDelayForSequence(nDelay);
                        ++m_nSeqNum;
                    }
                   
                    break;
                case (int)EN_INITIALIZE_STEP.MOTION + 1:
                    double dVacValue = 0;
                    if (CheckMaterialExistInLift(ref dVacValue))
                    {
                        //Lift에 자재 감지되면 제거하자
                        m_arAlarmSubInfo = new string[] { "PLEASE REJECT WAFER" };
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.MAETRIAL_EXIST, false, ref m_arAlarmSubInfo);
                        m_nSeqNum = (int)EN_INITIALIZE_STEP.END;
                        break;
                    }
                    ++m_nSeqNum;
                    break;
                case (int)EN_INITIALIZE_STEP.MOTION + 2:
                     MoveToHome((int)EN_AXIS_LIST.LIFT_Z, true);
                    ++m_nSeqNum;
                  
                    break;

                case (int)EN_INITIALIZE_STEP.MOTION + 3:
                    //Lift home 이후 block 자재 유무 판단
                    {
                        WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.BLOCK_MATERIAL_VAC_1, true);
                        int nDelay = m_Recipe.GetValue(EN_TASK_LIST.WORK_ZONE.ToString(), WORKZONE_TASK_PARAM.BLOCK_MATERIAL_VAC_TIMELAG_DELAY.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);
                        SetDelayForSequence(nDelay);
                        ++m_nSeqNum;
                    }
                    ++m_nSeqNum;
                    break;
                case (int)EN_INITIALIZE_STEP.MOTION + 4:
                    {
                        WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.BLOCK_MATERIAL_VAC_2, true);
                        int nDelay = m_Recipe.GetValue(EN_TASK_LIST.WORK_ZONE.ToString(), WORKZONE_TASK_PARAM.BLOCK_MATERIAL_VAC_ON_DELAY.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);
                        SetDelayForSequence(nDelay);
                        ++m_nSeqNum;
                    }
                    ++m_nSeqNum;
                    break;

                case (int)EN_INITIALIZE_STEP.MOTION + 5:
                    {
                        WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LIFT_MATERIAL_VAC, false);
                        int nDelay = m_Recipe.GetValue(EN_TASK_LIST.WORK_ZONE.ToString(), WORKZONE_TASK_PARAM.LIFT_MATERIAL_VAC_OFF_DELAY.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);
                        SetDelayForSequence(nDelay);
                    }
                    ++m_nSeqNum;
                    break;

                case (int)EN_INITIALIZE_STEP.MOTION + 6:
                    dVacValue = 0;
                    if (CheckMaterialExistInBlock(ref dVacValue) == false)  
                    {
                        WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.BLOCK_MATERIAL_VAC_1, false);
                        WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.BLOCK_MATERIAL_VAC_2, false);
                    }
                    else
                    {
                        DynamicLink_.EN_PORT_STATUS enPortStatus = DynamicLink_.EN_PORT_STATUS.EXIST;
                        _DynamicLink.GetPortStatus(EN_TASK_LIST.WORK_ZONE.ToString(), EN_PORT_LIST.WORK_PORT.ToString(), ref enPortStatus);
                        if (enPortStatus == DynamicLink_.EN_PORT_STATUS.EMPTY)
                        {
                            if (WorkMap.GetInstance().GetWorkStatus() == EN_WORK_STATUS.WAIT)
                            {
                                _DynamicLink.SetPortStatus(EN_TASK_LIST.BOND_HEAD.ToString(), EN_PORT_LIST.WORK_PORT.ToString(), DynamicLink_.EN_PORT_STATUS.WORKING, false);
                                _DynamicLink.SetPortStatus(EN_TASK_LIST.WORK_ZONE.ToString(), EN_PORT_LIST.WORK_PORT.ToString(), DynamicLink_.EN_PORT_STATUS.WORKING);
                            }
                            else
                            {
                                _DynamicLink.SetPortStatus(EN_TASK_LIST.BOND_HEAD.ToString(), EN_PORT_LIST.WORK_PORT.ToString(), DynamicLink_.EN_PORT_STATUS.FINISHED, false);
                                _DynamicLink.SetPortStatus(EN_TASK_LIST.WORK_ZONE.ToString(), EN_PORT_LIST.WORK_PORT.ToString(), DynamicLink_.EN_PORT_STATUS.WORKING);
                            }
                        }
                    }
                    if (CheckMaterialExistInHandler(ref dVacValue) == false) 
                    {
                        WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.HANDLER_MATERIAL_VAC, false);
                    }
                    m_instanceOperator.MainVacControl(false);
                    ++m_nSeqNum;
                    break;
                case (int)EN_INITIALIZE_STEP.MOTION + 7:
                    MoveToHome((int)EN_AXIS_LIST.BLOCK_Z, true);
                    ++m_nSeqNum;
                    break;
                case (int)EN_INITIALIZE_STEP.MOTION + 8:
                    if (CheckMail(EN_SUBSCRIBER.TASK_BONDHEAD, EN_MAIL.POWERMETEER_HOME_DONE))
                    {
                        MoveToHome((int)EN_AXIS_LIST.BLOCK_X, true);
                        ++m_nSeqNum;
                    }
                    break;
                case (int)EN_INITIALIZE_STEP.MOTION + 9:
                    MoveToHome((int)EN_AXIS_LIST.HANDLER_X, true);
                     ++m_nSeqNum;
                    break;
                case (int)EN_INITIALIZE_STEP.MOTION + 10:
                    MoveToHome((int)EN_AXIS_LIST.HANDLER_Z, true);
                    MoveToHome((int)EN_AXIS_LIST.HANDLER_Y, true);
                    ++m_nSeqNum;
                    break;
                case (int)EN_INITIALIZE_STEP.MOTION + 11:
                    MoveToHome((int)EN_AXIS_LIST.HANDLER_R, true);
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
                    StartTransferTest();
                    PostOffice.GetInstance().EmptyMailBoxAll();
                    m_instanceOperator.MainVacControl(true);
                    m_nRunRatio = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.RUN_RATIO.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 100);
                    m_nSeqNum++;
                    break;
                case (int)EN_ENTRY_STEP.START + 1:
                    if (m_instanceOperator.GetRunMode() != RunningMain_.RUN_MODE.AUTO)
                    {
                        SetDelayForSequence(2000);
                        _DynamicLink.SetPortStatus(GetTaskName(), EN_PORT_LIST.WORK_PORT.ToString(), DynamicLink_.EN_PORT_STATUS.EMPTY);
                        m_nSeqNum = (int)EN_ENTRY_STEP.INITIALIZE;
                        break;

                    }
                    m_nSeqNum = (int)EN_ENTRY_STEP.CHECK_MATERIAL;
                    break;

                case (int)EN_ENTRY_STEP.CHECK_MATERIAL:
                    if (m_nRecoveryStep != 0)
                    {
                        m_nSeqNum = (int)EN_ENTRY_STEP.INITIALIZE;
                        break;
                    }
                    {
                        WriteOutput((int)EN_DIGITAL_OUTPUT_LIST.LIFT_MATERIAL_VAC, true);
                        int nDelay = m_Recipe.GetValue(EN_TASK_LIST.WORK_ZONE.ToString(), WORKZONE_TASK_PARAM.LIFT_MATERIAL_VAC_ON_DELAY.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);
                        SetDelayForSequence(nDelay);
                      
                    }
                    m_nSeqNum++;
                    break;

                case (int)EN_ENTRY_STEP.CHECK_MATERIAL + 1:
                    double dVac = 0;
                    m_bExistLift = CheckMaterialExistInLift(ref dVac);
                    {
                        WriteOutput((int)EN_DIGITAL_OUTPUT_LIST.LIFT_MATERIAL_VAC, false);
                        int nDelay = m_Recipe.GetValue(EN_TASK_LIST.WORK_ZONE.ToString(), WORKZONE_TASK_PARAM.LIFT_MATERIAL_VAC_OFF_DELAY.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);
                        SetDelayForSequence(nDelay);
                        m_tickTimeOut.SetTickCount((uint)m_nInterlockTimeOut);
                    }
                    m_nSeqNum++;
                    break;

                case (int)EN_ENTRY_STEP.CHECK_MATERIAL + 2:
                    double Position_Lift_Z = m_Recipe.GetValue(EN_TASK_LIST.WORK_ZONE.ToString(), WORKZONE_TASK_PARAM.LIFT_READY_POSITION_Z.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);

                    MOTION_RESULT enResultLiftZ = MoveAbsolutely((int)EN_AXIS_LIST.LIFT_Z,
                                    Position_Lift_Z,
                                   MOTION_SPEED_CONTENT.RUN,
                                    100,
                                    0,
                                    true);

                    if (enResultLiftZ == MOTION_RESULT.OK)
                        m_nSeqNum++;

                    //if (GetSequenceTime() > m_nInterlockTimeOut) //entry에서는 GetSequenceTime 사용하면 안됨
                    if (m_tickTimeOut.IsTickOver(false))
                    {
                        m_arAlarmSubInfo[0] = "LIFT MOVE FAIL";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_nSeqNum = (int)EN_ENTRY_STEP.END;
                        break;
                    }
                    break;
                case (int)EN_ENTRY_STEP.CHECK_MATERIAL + 3:
                    if (ReadOutput((int)EN_DIGITAL_OUTPUT_LIST.BLOCK_MATERIAL_VAC_1, false)
                        && ReadOutput((int)EN_DIGITAL_OUTPUT_LIST.BLOCK_MATERIAL_VAC_2, false))
                    {
                        m_nSeqNum += 2;
                        break;
                    }
                    {
                        WriteOutput((int)EN_DIGITAL_OUTPUT_LIST.BLOCK_MATERIAL_BLOW, false);
                        WriteOutput((int)EN_DIGITAL_OUTPUT_LIST.BLOCK_MATERIAL_VAC_1, true); // 1-1
                        int nDelay = m_Recipe.GetValue(EN_TASK_LIST.WORK_ZONE.ToString(), WORKZONE_TASK_PARAM.BLOCK_MATERIAL_VAC_TIMELAG_DELAY.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);
                        SetDelayForSequence(nDelay);
                    }
                    m_nSeqNum++;
                    break;

                case (int)EN_ENTRY_STEP.CHECK_MATERIAL + 4:
                    {
                        WriteOutput((int)EN_DIGITAL_OUTPUT_LIST.BLOCK_MATERIAL_VAC_2, true); // 1-1
                        int nDelay = m_Recipe.GetValue(EN_TASK_LIST.WORK_ZONE.ToString(), WORKZONE_TASK_PARAM.BLOCK_MATERIAL_VAC_ON_DELAY.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);
                        SetDelayForSequence(nDelay);
                    }
                    m_nSeqNum++;
                    break;
                case (int)EN_ENTRY_STEP.CHECK_MATERIAL + 5:
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.HANDLER_MATERIAL_BLOW, false);
                    if (ReadOutput((int)EN_DIGITAL_OUTPUT_LIST.HANDLER_MATERIAL_VAC, false))
                    {
                        m_nSeqNum++;
                        break;
                    }
                    {
                        WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.HANDLER_MATERIAL_VAC, true);
                        int nDelay = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.HANDLER_MATERIAL_VAC_ON_DELAY.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);
                        SetDelayForSequence(nDelay);
                    }
                    m_nSeqNum++;
                    break;
                case (int)EN_ENTRY_STEP.CHECK_MATERIAL + 6:
                    dVac = 0;
                    m_bExistBlock = CheckMaterialExistInBlock(ref dVac);
                    m_bExistHandler = CheckMaterialExistInHandler(ref dVac);
                    if (m_nRecoveryStep == 0)
                    {
                        if (m_bExistBlock == false
                            && m_bExistHandler == false)
                        {
                            _DynamicLink.SetPortStatus(GetTaskName(), EN_PORT_LIST.WORK_PORT.ToString(), DynamicLink_.EN_PORT_STATUS.EMPTY, false);
                            _DynamicLink.SetPortStatus(EN_TASK_LIST.WORK_ZONE.ToString(), EN_PORT_LIST.WORK_PORT.ToString(), DynamicLink_.EN_PORT_STATUS.EMPTY, false);
                            _DynamicLink.SetPortStatus(EN_TASK_LIST.BOND_HEAD.ToString(), EN_PORT_LIST.WORK_PORT.ToString(), DynamicLink_.EN_PORT_STATUS.EMPTY);
                        }
                        else if (m_bExistBlock
                           && m_bExistHandler == false)
                        {
                            if (WorkMap.GetInstance().GetWorkStatus() == EN_WORK_STATUS.WAIT)
                            {
                                //블럭에 안착된 상태임으로 WORKING으로 하자
                                _DynamicLink.SetPortStatus(GetTaskName(), EN_PORT_LIST.WORK_PORT.ToString(), DynamicLink_.EN_PORT_STATUS.WORKING, false);
                                _DynamicLink.SetPortStatus(EN_TASK_LIST.WORK_ZONE.ToString(), EN_PORT_LIST.WORK_PORT.ToString(), DynamicLink_.EN_PORT_STATUS.WORKING, false);
                                _DynamicLink.SetPortStatus(EN_TASK_LIST.BOND_HEAD.ToString(), EN_PORT_LIST.WORK_PORT.ToString(), DynamicLink_.EN_PORT_STATUS.WORKING);
                            }
                            else
                            {
                                _DynamicLink.SetPortStatus(GetTaskName(), EN_PORT_LIST.WORK_PORT.ToString(), DynamicLink_.EN_PORT_STATUS.WORKING, false);
                                _DynamicLink.SetPortStatus(EN_TASK_LIST.WORK_ZONE.ToString(), EN_PORT_LIST.WORK_PORT.ToString(), DynamicLink_.EN_PORT_STATUS.WORKING, false);
                                _DynamicLink.SetPortStatus(EN_TASK_LIST.BOND_HEAD.ToString(), EN_PORT_LIST.WORK_PORT.ToString(), DynamicLink_.EN_PORT_STATUS.FINISHED);
                            }
                            if(m_bExistLift)
                            {
                                //Loading 된 상태임으로 PreHeating Reset
                                m_instanceOperator.ResetPreHeatingTimer();
                            }
                        }
                        else if (m_bExistBlock == false
                         && m_bExistHandler)
                        {
                            if (WorkMap.GetInstance().GetWorkStatus() == EN_WORK_STATUS.WAIT)
                            {
                                _DynamicLink.SetPortStatus(GetTaskName(), EN_PORT_LIST.WORK_PORT.ToString(), DynamicLink_.EN_PORT_STATUS.EXIST, false);
                                _DynamicLink.SetPortStatus(EN_TASK_LIST.WORK_ZONE.ToString(), EN_PORT_LIST.WORK_PORT.ToString(), DynamicLink_.EN_PORT_STATUS.EMPTY, false);
                                _DynamicLink.SetPortStatus(EN_TASK_LIST.BOND_HEAD.ToString(), EN_PORT_LIST.WORK_PORT.ToString(), DynamicLink_.EN_PORT_STATUS.FINISHED);
                            }
                            else
                            {
                                _DynamicLink.SetPortStatus(GetTaskName(), EN_PORT_LIST.WORK_PORT.ToString(), DynamicLink_.EN_PORT_STATUS.FINISHED, false);
                                _DynamicLink.SetPortStatus(EN_TASK_LIST.WORK_ZONE.ToString(), EN_PORT_LIST.WORK_PORT.ToString(), DynamicLink_.EN_PORT_STATUS.FINISHED, false);
                                _DynamicLink.SetPortStatus(EN_TASK_LIST.BOND_HEAD.ToString(), EN_PORT_LIST.WORK_PORT.ToString(), DynamicLink_.EN_PORT_STATUS.FINISHED);
                            }
                        }
                        else
                        {
                            m_arAlarmSubInfo[0] = "IN HANDLE & BLOCK";
                            GenerateSequenceAlarm((int)EN_TASK_ALARM.MAETRIAL_EXIST, false, ref m_arAlarmSubInfo);
                        }
                    }
                   
                    if(m_bExistBlock == false)
                    {
                        WriteOutput((int)EN_DIGITAL_OUTPUT_LIST.BLOCK_MATERIAL_VAC_1, false);
                        WriteOutput((int)EN_DIGITAL_OUTPUT_LIST.BLOCK_MATERIAL_VAC_2, false);
                        int nDelay = m_Recipe.GetValue(EN_TASK_LIST.WORK_ZONE.ToString(), WORKZONE_TASK_PARAM.BLOCK_MATERIAL_VAC_OFF_DELAY.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);
                        SetDelayForSequence(nDelay);
                    }
                    if(m_bExistHandler == false)
                    {
                        WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.HANDLER_MATERIAL_VAC, false);
                        int nDelay = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.HANDLER_MATERIAL_VAC_ON_DELAY.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);
                        SetDelayForSequence(nDelay);
                    }
                    m_tickTimeOut.SetTickCount((uint)m_nInterlockTimeOut);
                    m_nSeqNum++;
                    break;
                case (int)EN_ENTRY_STEP.CHECK_MATERIAL + 7:
                    double Position_Block_Z = m_Recipe.GetValue(EN_TASK_LIST.WORK_ZONE.ToString(), WORKZONE_TASK_PARAM.BLOCK_READY_POSITION_Z.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);
                    
                    MOTION_RESULT enResultBlockZ = MoveAbsolutely((int)EN_AXIS_LIST.BLOCK_Z,
                                   Position_Block_Z,
                                  MOTION_SPEED_CONTENT.RUN,
                                   100,
                                   0,
                                   true);

                    if (enResultBlockZ == MOTION_RESULT.OK)
                        m_nSeqNum = (int)EN_ENTRY_STEP.INITIALIZE;

                    //if (GetSequenceTime() > m_nInterlockTimeOut) //entry에서는 GetSequenceTime 사용하면 안됨
                    if (m_tickTimeOut.IsTickOver(false))
                    {
                        m_arAlarmSubInfo[0] = "BLOCK MOVE FAIL";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_nSeqNum = (int)EN_ENTRY_STEP.END;
                        break;
                    }
                    break;

                case (int)EN_ENTRY_STEP.INITIALIZE:
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
                case EN_TASK_ACTION.EQUIPMENT_LOADING:
                    if (ActionEquipmentLoading())
                        return true;
                    break;

                case EN_TASK_ACTION.BLOCK_LOADING:
                    if (ActionBlockLoading())
                        return true;
                    break;

                case EN_TASK_ACTION.BLOCK_UNLOADING:
                    if (ActionBlockUnloading())
                        return true;
                    break;

                case EN_TASK_ACTION.EQUIPMENT_UNLOADING:
                    if (ActionEquipmentUnloading())
                        return true;
                    break;

                case EN_TASK_ACTION.MOVE_AVOID:
                    if (ActionMoveAvoid())
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
                case EN_TASK_ACTION.EQUIPMENT_LOADING:
                    if (ActionEquipmentLoading())
                        return true;
                    break;

                case EN_TASK_ACTION.BLOCK_LOADING:
                    if (ActionBlockLoading())
                        return true;
                    break;

                case EN_TASK_ACTION.BLOCK_UNLOADING:
                    if (ActionBlockUnloading())
                        return true;
                    break;

                case EN_TASK_ACTION.EQUIPMENT_UNLOADING:
                    if (ActionEquipmentUnloading())
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
            _DynamicLink.SetPortFinalCondition(GetTaskName(), EN_TASK_ACTION.EQUIPMENT_LOADING.ToString(), PortFinalconditionEquipmentLoading);
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

        private bool ActionEquipmentLoading()
        {
            switch (m_nSeqNum)
            {
                #region ACTION START (0 ~ )
                case (int)EN_LOADING_STEP.ACTION_START:
                    loadingstarttime = DateTime.Now;
//                     if (m_instanceOperator.GetRunMode() == RunningMain_.RUN_MODE.SIMULATION)
//                     {
//                         SetDelayForSequence(2000);
//                         m_nSeqNum = (int)EN_LOADING_STEP.ACTION_FINISH;
//                         break;
//                     }
                    //자재 있으면 알람 하자.
                    DynamicLink_.EN_PORT_STATUS enPortStatus = DynamicLink_.EN_PORT_STATUS.EXIST;
                    _DynamicLink.GetPortStatus(GetTaskName(), EN_PORT_LIST.WORK_PORT.ToString(), ref enPortStatus);
                    if (enPortStatus != DynamicLink_.EN_PORT_STATUS.EMPTY)
                    {
                        m_arAlarmSubInfo[0] = "";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.STATUS_MISMATCH, false, ref m_arAlarmSubInfo);
                        m_nSeqNum = (int)EN_UNLOADING_STEP.FINISH;
                        break;
                    }
                    switch (m_enRecoveryAction)
                    {
                        case EN_TASK_ACTION.EQUIPMENT_LOADING:
                            m_nSeqNum = m_nRecoveryStep;
                            break;

                        case EN_TASK_ACTION.STOP:
                            if (CheckPreSmema(true))
                                m_nSeqNum++;
                            break;

                        default:
                            m_arAlarmSubInfo[0] = "RECOVERY ACTION : " + m_enRecoveryAction.ToString();
                            GenerateSequenceAlarm((int)EN_TASK_ALARM.RECOVERY_STATUS_ALARM, false, ref m_arAlarmSubInfo);
                            m_nSeqNum = (int)EN_LOADING_STEP.FINISH;
                            break;
                    }
                    break;
                case (int)EN_LOADING_STEP.ACTION_START + 1:
                    IonizerTriggerOnOff(true);
                    int nDelay = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.IONIZER_CHECK_DELAY.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);
                    SetDelayForSequence(nDelay);
                     m_nSeqNum++;
                    break;
                case (int)EN_LOADING_STEP.ACTION_START + 2:
                    IonizerInterluptOnOff(true);
                      m_nSeqNum++;
                    break;
                case (int)EN_LOADING_STEP.ACTION_START + 3:
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.HANDLER_MATERIAL_VAC, true);
                    nDelay = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.HANDLER_MATERIAL_VAC_ON_DELAY.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);
                    SetDelayForSequence(nDelay);
                    m_nSeqNum++;
                    break;
                case (int)EN_LOADING_STEP.ACTION_START + 4:
                    if (m_instanceOperator.GetRunMode() == RunningMain_.RUN_MODE.AUTO)
                    {
                        double dVacValue = 0;
                        if (CheckMaterialExistInHandler(ref dVacValue))
                        {
                            m_arAlarmSubInfo[0] = "EXIST HANDLER. VAC VALUE : " + dVacValue.ToString();
                            GenerateSequenceAlarm((int)EN_TASK_ALARM.VAC_CHECK_FAIL, false, ref m_arAlarmSubInfo);
                            m_enRecoveryAction = m_enAction;
                            m_nRecoveryStep = m_nSeqNum;
                            m_nSeqNum = (int)EN_LOADING_STEP.FINISH;
                            break;
                        }
                    }
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.HANDLER_MATERIAL_VAC, false);
                    m_nSeqNum = (int)EN_LOADING_STEP.MOVE_LOADING;
                    break;
                #endregion

                #region MOVE_LOADING
                case (int)EN_LOADING_STEP.MOVE_LOADING:
                    // 이동 순서 바뀔 수 있음
                    if (m_tRecovery.nInSmemaPort < 1)
                        m_tRecovery.nInSmemaPort = 1;
                    // 이동 순서 바뀔 수 있음
                    double Position_R = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.HANDLER_WORK_BLOCK_AVOID_POSITION_R.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

                    MOTION_RESULT enResultR = MoveAbsolutely((int)EN_AXIS_LIST.HANDLER_R,
                                    Position_R,
                                    MOTION_SPEED_CONTENT.RUN,
                                    m_nRunRatio,
                                    0,
                                    true);

                    if (enResultR == MOTION_RESULT.OK)
                        m_nSeqNum++;

                    if (GetSequenceTime() > m_nInterlockTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "HANDLER MOVE FAIL";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_enRecoveryAction = m_enAction;
                        m_nRecoveryStep = m_nSeqNum;
                        m_nSeqNum = (int)EN_LOADING_STEP.FINISH;
                        break;
                    }


                    break;
                case (int)EN_LOADING_STEP.MOVE_LOADING + 1:
                    // 이동 순서 바뀔 수 있음
                    double Position_X = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.HANDLER_READY_X.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);


                    MOTION_RESULT enResultX = MoveAbsolutely((int)EN_AXIS_LIST.HANDLER_X,
                                    Position_X,
                                    MOTION_SPEED_CONTENT.RUN,
                                    m_nRunRatio,
                                    0,
                                 true);

                    if (enResultX == MOTION_RESULT.OK)
                        m_nSeqNum++;

                    if (GetSequenceTime() > m_nInterlockTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "HANDLER MOVE FAIL";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_enRecoveryAction = m_enAction;
                        m_nRecoveryStep = m_nSeqNum;
                        m_nSeqNum = (int)EN_LOADING_STEP.FINISH;
                        break;
                    }

                    break;

                case (int)EN_LOADING_STEP.MOVE_LOADING + 2:
                    //23.11.23 by wdw [ADD] R축 충돌 방지 동작 추가
                    double Position_Y = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.HANDLER_PRE_EQUIPMENT_TRANSFER_POSITION_Y_2.ToString(), m_tRecovery.nInSmemaPort - 1, EN_RECIPE_PARAM_TYPE.VALUE, 0.0)
                                        + m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.HANDLER_PRE_EQUIPMENT_TRANSFER_OFFSET_Y_2.ToString(), m_tRecovery.nInSmemaPort - 1, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

                    MOTION_RESULT enResultY = MoveAbsolutely((int)EN_AXIS_LIST.HANDLER_Y,
                                    Position_Y,
                                    MOTION_SPEED_CONTENT.RUN,
                                    m_nRunRatio,
                                    0,
                                    true);

                    if (enResultY == MOTION_RESULT.OK)
                        m_nSeqNum++;

                    if (GetSequenceTime() > m_nInterlockTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "HANDLER MOVE FAIL";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_enRecoveryAction = m_enAction;
                        m_nRecoveryStep = m_nSeqNum;
                        m_nSeqNum = (int)EN_LOADING_STEP.FINISH;
                        break;
                    }
                    break;
                case (int)EN_LOADING_STEP.MOVE_LOADING + 3:
                     double Position_Z = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.HANDLER_PRE_EQUIPMENT_TRANSFER_DOWN_POSITION_Z_2.ToString(), m_tRecovery.nInSmemaPort - 1, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

                    MOTION_RESULT enResultZ = MoveAbsolutely((int)EN_AXIS_LIST.HANDLER_Z,
                                 Position_Z,
                                 MOTION_SPEED_CONTENT.RUN,
                                 m_nRunRatio,
                                 0,
                                 true);
                

                    if (enResultZ == MOTION_RESULT.OK)
                        m_nSeqNum++;

                    if (GetSequenceTime() > m_nInterlockTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "HANDLER MOVE FAIL";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo); 
                        m_enRecoveryAction = m_enAction;
                        m_nRecoveryStep = m_nSeqNum;
                        m_nSeqNum = (int)EN_LOADING_STEP.FINISH;
                        break;
                    }
                    break;
                case (int)EN_LOADING_STEP.MOVE_LOADING + 4:
                    SetPreSmemaOutput(true);
                    m_nSeqNum++;
                    break;
                case (int)EN_LOADING_STEP.MOVE_LOADING + 5:
                    if (GetSequenceTime() > m_nCommunicationTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "SMEMA SUB " + m_tRecovery.nInSmemaPort + " ON";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.COMMUNICATION_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_enRecoveryAction = m_enAction;
                        m_nRecoveryStep = m_nSeqNum;
                        m_nSeqNum = (int)EN_LOADING_STEP.FINISH;
                        break;
                    }
                    if (CheckPreSmemaSub(true))
                        m_nSeqNum++;
                    break;

                case (int)EN_LOADING_STEP.MOVE_LOADING + 6:
                    // 이동 순서 바뀔 수 있음
                    Position_R = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.HANDLER_PRE_EQUIPMENT_TRANSFER_POSITION_R.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

                    enResultR = MoveAbsolutely((int)EN_AXIS_LIST.HANDLER_R,
                                    Position_R,
                                    MOTION_SPEED_CONTENT.RUN,
                                    m_nRunRatio,
                                    0,
                                    true);

                    if (enResultR == MOTION_RESULT.OK)
                        m_nSeqNum++;

                    if (GetSequenceTime() > m_nInterlockTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "HANDLER MOVE FAIL";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_enRecoveryAction = m_enAction;
                        m_nRecoveryStep = m_nSeqNum;
                        m_nSeqNum = (int)EN_LOADING_STEP.FINISH;
                        break;
                    }

                    break;

                case (int)EN_LOADING_STEP.MOVE_LOADING + 7:
                    Position_Y = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.HANDLER_PRE_EQUIPMENT_TRANSFER_POSITION_Y_2.ToString(), m_tRecovery.nInSmemaPort - 1, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

                    enResultY = MoveAbsolutely((int)EN_AXIS_LIST.HANDLER_Y,
                                    Position_Y,
                                    MOTION_SPEED_CONTENT.RUN,
                                    m_nRunRatio,
                                    0,
                                    true);

                    if (enResultY == MOTION_RESULT.OK)
                        m_nSeqNum = (int)EN_LOADING_STEP.LOADING;

                    if (GetSequenceTime() > m_nInterlockTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "HANDLER MOVE FAIL";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_enRecoveryAction = m_enAction;
                        m_nRecoveryStep = m_nSeqNum;
                        m_nSeqNum = (int)EN_LOADING_STEP.FINISH;
                        break;
                    }

                    break;

                #endregion

                #region LOADING
                case (int)EN_LOADING_STEP.LOADING:
                  
                    Position_X = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.HANDLER_PRE_EQUIPMENT_TRANSFER_POSITION_X_2.ToString(), m_tRecovery.nInSmemaPort - 1, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

                    enResultX = MoveAbsolutely((int)EN_AXIS_LIST.HANDLER_X,
                                    Position_X,
                                    MOTION_SPEED_CONTENT.RUN,
                                    m_nRunRatio,
                                    0,
                                    true);

                    if (enResultX == MOTION_RESULT.OK)
                        m_nSeqNum++;

                    if (GetSequenceTime() > m_nInterlockTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "HANDLER MOVE FAIL";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_enRecoveryAction = m_enAction;
                        m_nRecoveryStep = m_nSeqNum;
                        m_nSeqNum = (int)EN_LOADING_STEP.FINISH;
                        break;
                    }
                    break;
                case (int)EN_LOADING_STEP.LOADING + 1:
                    SetPreSmemaSubOutput(true);
                    m_nSeqNum++;
                    break;
                case (int)EN_LOADING_STEP.LOADING + 2:
                    Position_Z = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.HANDLER_PRE_EQUIPMENT_TRANSFER_CONTACT_POSITION_Z_2.ToString(), m_tRecovery.nInSmemaPort - 1, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                    double dSpeed = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.HANDLER_Z_MATERIAL_CONTACT_SPEED.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

                    enResultZ = MoveAbsolutely((int)EN_AXIS_LIST.HANDLER_Z,
                                    Position_Z,
                                    dSpeed,
                                    MOTION_SPEED_CONTENT.RUN,
                                    100,
                                    0,
                                    true);

                    if (enResultZ == MOTION_RESULT.OK)
                        m_nSeqNum++;

                    if (GetSequenceTime() > m_nInterlockTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "HANDLER MOVE FAIL";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_enRecoveryAction = m_enAction;
                        m_nRecoveryStep = m_nSeqNum;
                        m_nSeqNum = (int)EN_LOADING_STEP.FINISH;
                        break;
                    }
                    break;
                case (int)EN_LOADING_STEP.LOADING + 3:
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.HANDLER_MATERIAL_VAC, true);
                    nDelay = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.HANDLER_MATERIAL_VAC_ON_DELAY.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);
                    SetDelayForSequence(nDelay);
                    m_nSeqNum++;
                    break;

                case (int)EN_LOADING_STEP.LOADING + 4:
                    Position_Z = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.HANDLER_PRE_EQUIPMENT_TRANSFER_UP_POSITION_Z_2.ToString(), m_tRecovery.nInSmemaPort - 1, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                    dSpeed = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.HANDLER_Z_MATERIAL_HANDLE_SPEED.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

                    enResultZ = MoveAbsolutely((int)EN_AXIS_LIST.HANDLER_Z,
                                    Position_Z,
                                    dSpeed,
                                    MOTION_SPEED_CONTENT.RUN,
                                    100,
                                    0,
                                    true);

                    if (enResultZ == MOTION_RESULT.OK)
                        m_nSeqNum++;

                    if (GetSequenceTime() > m_nInterlockTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "HANDLER MOVE FAIL";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_enRecoveryAction = m_enAction;
                        m_nRecoveryStep = m_nSeqNum;
                        m_nSeqNum = (int)EN_LOADING_STEP.FINISH;
                        break;
                    }
                    break;
                case (int)EN_LOADING_STEP.LOADING + 5:
                    if (m_instanceOperator.GetRunMode() == RunningMain_.RUN_MODE.AUTO)
                    {
                        double dVacValue = 0;
                        if (CheckMaterialExistInHandler(ref dVacValue) == false)
                        {
                            m_arAlarmSubInfo[0] = "LOAD END NOT EXIST HANDLER. VAC VALUE : " + dVacValue.ToString();
                            GenerateSequenceAlarm((int)EN_TASK_ALARM.VAC_CHECK_FAIL, false, ref m_arAlarmSubInfo);
                            m_enRecoveryAction = m_enAction;
                            m_nRecoveryStep = m_nSeqNum;
                            m_nSeqNum = (int)EN_LOADING_STEP.FINISH;
                            break;
                        }
                    }
                    m_nSeqNum++;
                    break;
                case (int)EN_LOADING_STEP.LOADING + 6:
                    SetPreSmemaSubOutput(false);
                    m_nSeqNum++;
                    break;
                case (int)EN_LOADING_STEP.LOADING + 7:
                    bool bUseWCF = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, Recipe.PARAM_EQUIPMENT.PREEQUIPMENT_WCF_USED.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, true);

                    if (bUseWCF)
                    {
                        if (GetSequenceTime() > m_nCommunicationTimeOut)
                        {
                            m_arAlarmSubInfo[0] = "RECEIVE ID FAIL";
                            GenerateSequenceAlarm((int)EN_TASK_ALARM.COMMUNICATION_TIMEOUT, false, ref m_arAlarmSubInfo);
                            m_enRecoveryAction = m_enAction;
                            m_nRecoveryStep = m_nSeqNum;
                            m_nSeqNum = (int)EN_LOADING_STEP.FINISH;
                            break;
                        }
                        List<Mail> lstMail = GetMail(EN_SUBSCRIBER.PRE_EQUIPMENT_WCF, EN_MAIL.WCF_RECEIVE);
                        if (lstMail == null)
                            break;

                        m_strID = (string)lstMail[0].Content[(int)TransportWIR.EN_DATA.SubjectId];
                        m_arWaferInfo[(int)TransportWIR.EN_DATA.SubjectId] = (string)lstMail[0].Content[(int)TransportWIR.EN_DATA.SubjectId] ;
                        m_arWaferInfo[(int)TransportWIR.EN_DATA.Lane] = (string)lstMail[0].Content[(int)TransportWIR.EN_DATA.Lane] ;
                        m_arWaferInfo[(int)TransportWIR.EN_DATA.WAFER_ID] = (string)lstMail[0].Content[(int)TransportWIR.EN_DATA.WAFER_ID] ;
                        m_arWaferInfo[(int)TransportWIR.EN_DATA.LOT_ID] = (string)lstMail[0].Content[(int)TransportWIR.EN_DATA.LOT_ID] ;
                        m_arWaferInfo[(int)TransportWIR.EN_DATA.PART_NAME] = (string)lstMail[0].Content[(int)TransportWIR.EN_DATA.PART_NAME];
                        m_arWaferInfo[(int)TransportWIR.EN_DATA.LOT_TYPE] = (string)lstMail[0].Content[(int)TransportWIR.EN_DATA.LOT_TYPE] ;
                        m_arWaferInfo[(int)TransportWIR.EN_DATA.STEP_SEQ] = (string)lstMail[0].Content[(int)TransportWIR.EN_DATA.STEP_SEQ] ;
                        m_arWaferInfo[(int)TransportWIR.EN_DATA.WAFER_COL] = (string)lstMail[0].Content[(int)TransportWIR.EN_DATA.WAFER_COL];
                        m_arWaferInfo[(int)TransportWIR.EN_DATA.WAFER_ROW] = (string)lstMail[0].Content[(int)TransportWIR.EN_DATA.WAFER_ROW];
                        m_arWaferInfo[(int)TransportWIR.EN_DATA.ANGLE] = (string)lstMail[0].Content[(int)TransportWIR.EN_DATA.ANGLE] ;
                        m_arWaferInfo[(int)TransportWIR.EN_DATA.WAFER_MAP] = (string)lstMail[0].Content[(int)TransportWIR.EN_DATA.WAFER_MAP];
                        m_arWaferInfo[(int)TransportWIR.EN_DATA.COUNT_CHIPS] = (string)lstMail[0].Content[(int)TransportWIR.EN_DATA.COUNT_CHIPS] ;
                        m_arWaferInfo[(int)TransportWIR.EN_DATA.SLOT_NO] = (string)lstMail[0].Content[(int)TransportWIR.EN_DATA.SLOT_NO] ;
                        //m_arWaferInfo[(int)TransportWIR.EN_DATA.ProcessResult] = (string)lstMail[0].Content[(int)TransportWIR.EN_DATA.ProcessResult] ;

//                         foreach (Mail mail in lstMail)
//                         {
//                             foreach (object Content in mail.Content)
//                             {
//                                 m_strID = Content.ToString();
//                             }
//                         }
                    }
                    else
                    {
                        m_strID = "WORK";
                        m_strID += String.Format("_{0:0000}{1:00}{2:00}{3:00}{4:00}{5:00}",
                            DateTime.Now.Year,
                            DateTime.Now.Month,
                            DateTime.Now.Day,
                            DateTime.Now.Hour,
                            DateTime.Now.Minute,
                            DateTime.Now.Second);
                    }
                    m_nSeqNum++;
                    break;
                case (int)EN_LOADING_STEP.LOADING + 8:
                    if (GetSequenceTime() > m_nCommunicationTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "SMEMA SUB " + m_tRecovery.nInSmemaPort + " OFF";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.COMMUNICATION_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_enRecoveryAction = m_enAction;
                        m_nRecoveryStep = m_nSeqNum;
                        m_nSeqNum = (int)EN_LOADING_STEP.FINISH;
                        break;
                    }
                    if (CheckPreSmemaSub(false))
                        m_nSeqNum++;
                    break;
                case (int)EN_LOADING_STEP.LOADING + 9:
                    Position_X = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.HANDLER_READY_X.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                    dSpeed = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.HANDLER_X_MATERIAL_HANDLE_SPEED.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

                    enResultX = MoveAbsolutely((int)EN_AXIS_LIST.HANDLER_X,
                                    Position_X,
                                    dSpeed,
                                    MOTION_SPEED_CONTENT.RUN,
                                    100,
                                    0,
                                    true);

                    if (enResultX == MOTION_RESULT.OK)
                        m_nSeqNum++;

                    if (GetSequenceTime() > m_nInterlockTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "HANDLER MOVE FAIL";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_enRecoveryAction = m_enAction;
                        m_nRecoveryStep = m_nSeqNum;
                        m_nSeqNum = (int)EN_LOADING_STEP.FINISH;
                        break;
                    }
                    break;
                case (int)EN_LOADING_STEP.LOADING + 10:
                    //23.11.23 by wdw [ADD] R축 충돌 방지 동작 추가
                    Position_Y = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.HANDLER_PRE_EQUIPMENT_TRANSFER_POSITION_Y_2.ToString(), m_tRecovery.nInSmemaPort - 1, EN_RECIPE_PARAM_TYPE.VALUE, 0.0)
                                        + m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.HANDLER_PRE_EQUIPMENT_TRANSFER_OFFSET_Y_2.ToString(), m_tRecovery.nInSmemaPort - 1, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                    dSpeed = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.HANDLER_Y_MATERIAL_HANDLE_SPEED.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

                    enResultY = MoveAbsolutely((int)EN_AXIS_LIST.HANDLER_Y,
                                    Position_Y,
                                    dSpeed,
                                    MOTION_SPEED_CONTENT.RUN,
                                    m_nRunRatio,
                                    0,
                                    true);

                    if (enResultY == MOTION_RESULT.OK)
                        m_nSeqNum++;

                    if (GetSequenceTime() > m_nInterlockTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "HANDLER MOVE FAIL";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_enRecoveryAction = m_enAction;
                        m_nRecoveryStep = m_nSeqNum;
                        m_nSeqNum = (int)EN_LOADING_STEP.FINISH;
                        break;
                    }
                    break;

                case (int)EN_LOADING_STEP.LOADING + 11:
                    Position_R = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.HANDLER_WORKBLOCK_TRANSFER_POSITION_R.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                    dSpeed = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.HANDLER_R_MATERIAL_HANDLE_SPEED.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

                    enResultR = MoveAbsolutely((int)EN_AXIS_LIST.HANDLER_R,
                                    Position_R,
                                    dSpeed,
                                    MOTION_SPEED_CONTENT.RUN,
                                    100,
                                    0,
                                    true);

                    if (enResultR == MOTION_RESULT.OK)
                        m_nSeqNum++;

                    if (GetSequenceTime() > m_nInterlockTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "HANDLER MOVE FAIL";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_enRecoveryAction = m_enAction;
                        m_nRecoveryStep = m_nSeqNum;
                        m_nSeqNum = (int)EN_LOADING_STEP.FINISH;
                        break;
                    }
                    break;

                case (int)EN_LOADING_STEP.LOADING + 12:
                    SetPreSmemaOutput(false);
                    m_nSeqNum++;
                    break;
                case (int)EN_LOADING_STEP.LOADING + 13:
                    if (GetSequenceTime() > m_nCommunicationTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "SMEMA " + m_tRecovery.nInSmemaPort + " OFF";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.COMMUNICATION_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_enRecoveryAction = m_enAction;
                        m_nRecoveryStep = m_nSeqNum;
                        m_nSeqNum = (int)EN_LOADING_STEP.FINISH;
                        break;
                    }
                    if (CheckPreSmema(false))
                      m_nSeqNum = (int)EN_LOADING_STEP.ACTION_FINISH;
                    break;
                #endregion

                #region ACTION_FINISH
                case (int)EN_LOADING_STEP.ACTION_FINISH:
                   
                    WorkMap.GetInstance().ResetMap(m_strID, false);
                     WorkMap.GetInstance().SetValue(EN_WAFER_ITEM.Lane, m_arWaferInfo[(int)TransportWIR.EN_DATA.Lane], false);
                     WorkMap.GetInstance().SetValue(EN_WAFER_ITEM.WAFER_ID, m_arWaferInfo[(int)TransportWIR.EN_DATA.WAFER_ID], false);
                     WorkMap.GetInstance().SetValue(EN_WAFER_ITEM.LOT_ID, m_arWaferInfo[(int)TransportWIR.EN_DATA.LOT_ID], false);
                     WorkMap.GetInstance().SetValue(EN_WAFER_ITEM.PART_NAME, m_arWaferInfo[(int)TransportWIR.EN_DATA.PART_NAME], false);
                     WorkMap.GetInstance().SetValue(EN_WAFER_ITEM.LOT_TYPE, m_arWaferInfo[(int)TransportWIR.EN_DATA.LOT_TYPE], false);
                     WorkMap.GetInstance().SetValue(EN_WAFER_ITEM.STEP_SEQ, m_arWaferInfo[(int)TransportWIR.EN_DATA.STEP_SEQ], false);
                     WorkMap.GetInstance().SetValue(EN_WAFER_ITEM.WAFER_COL, m_arWaferInfo[(int)TransportWIR.EN_DATA.WAFER_COL], false);
                     WorkMap.GetInstance().SetValue(EN_WAFER_ITEM.WAFER_ROW, m_arWaferInfo[(int)TransportWIR.EN_DATA.WAFER_ROW], false);
                     WorkMap.GetInstance().SetValue(EN_WAFER_ITEM.ANGLE, m_arWaferInfo[(int)TransportWIR.EN_DATA.ANGLE], false);
                     WorkMap.GetInstance().SetValue(EN_WAFER_ITEM.WAFER_MAP, m_arWaferInfo[(int)TransportWIR.EN_DATA.WAFER_MAP], false);
                     WorkMap.GetInstance().SetValue(EN_WAFER_ITEM.COUNT_CHIPS, m_arWaferInfo[(int)TransportWIR.EN_DATA.COUNT_CHIPS], false);
                     WorkMap.GetInstance().SetValue(EN_WAFER_ITEM.SLOT_NO, m_arWaferInfo[(int)TransportWIR.EN_DATA.SLOT_NO], false);
                     //WorkMap.GetInstance().SetValue(EN_WAFER_ITEM.ProcessResult, m_arWaferInfo[(int)TransportWIR.EN_DATA.ProcessResult]);
                    _DynamicLink.SetPortStatus(GetTaskName(), EN_PORT_LIST.WORK_PORT.ToString(), DynamicLink_.EN_PORT_STATUS.EXIST);

                    EFEMManager.GetInstance().AddQueCeid(EFEMManager.EN_CEID.PLR_START);

                    m_enRecoveryAction = EN_TASK_ACTION.STOP;
                    m_nRecoveryStep = 0;
                    m_nSeqNum = (int)EN_LOADING_STEP.FINISH;
                    break;
                #endregion

                #region FINISH
                case (int)EN_LOADING_STEP.FINISH:
                    return true;
                #endregion
            }
            return false;
        }

        private bool ActionBlockLoading()
        {
            switch (m_nSeqNum)
            {
                #region ACTION START (0 ~ )
                case (int)EN_LOADING_STEP.ACTION_START:
                    if (m_instanceOperator.GetRunMode() == RunningMain_.RUN_MODE.SIMULATION)
                    {
                        SetDelayForSequence(2000);
                        m_nSeqNum = (int)EN_LOADING_STEP.ACTION_FINISH;
                        break;

                    }
                    DynamicLink_.EN_PORT_STATUS enPortStatus = DynamicLink_.EN_PORT_STATUS.EXIST;
                    _DynamicLink.GetPortStatus(GetTaskName(), EN_PORT_LIST.WORK_PORT.ToString(), ref enPortStatus);
                    if (enPortStatus != DynamicLink_.EN_PORT_STATUS.EXIST)
                    {
                        m_arAlarmSubInfo[0] = "";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.STATUS_MISMATCH, false, ref m_arAlarmSubInfo);
                        m_nSeqNum = (int)EN_LOADING_STEP.FINISH;
                        break;
                    }
                    switch (m_enRecoveryAction)
                    {
                        case EN_TASK_ACTION.BLOCK_LOADING:
                            m_nSeqNum = m_nRecoveryStep;
                            break;

                        case EN_TASK_ACTION.STOP:
                            m_nSeqNum = (int)EN_LOADING_STEP.MOVE_LOADING;
                            break;

                        default:
                            m_arAlarmSubInfo[0] = "RECOVERY ACTION : " + m_enRecoveryAction.ToString();
                            GenerateSequenceAlarm((int)EN_TASK_ALARM.RECOVERY_STATUS_ALARM, false, ref m_arAlarmSubInfo);
                            m_nSeqNum = (int)EN_LOADING_STEP.FINISH;
                            break;
                    }
                    break;
                #endregion

                #region MOVE_LOADING
                case (int)EN_LOADING_STEP.MOVE_LOADING:
                    // 이동 순서 바뀔 수 있음
                    double Position_X = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.HANDLER_WORKBLOCK_TRANSFER_POSITION_X.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                    double Position_Y = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.HANDLER_WORKBLOCK_TRANSFER_POSITION_Y.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                    double Position_Block_X = m_Recipe.GetValue(EN_TASK_LIST.WORK_ZONE.ToString(), WORKZONE_TASK_PARAM.BLOCK_TRANSFER_POSITION_X.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                    double Position_Z = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.HANDLER_WORKBLOCK_TRANSFER_UP_POSITION_Z.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                   
                    double dSpeed_X = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.HANDLER_X_MATERIAL_HANDLE_SPEED.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                    double dSpeed_Y = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.HANDLER_Y_MATERIAL_HANDLE_SPEED.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                    double dSpeed_Z = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.HANDLER_Z_MATERIAL_HANDLE_SPEED.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

                    MOTION_RESULT enResultX = MoveAbsolutely((int)EN_AXIS_LIST.HANDLER_X,
                                    Position_X,
                                    dSpeed_X,
                                    MOTION_SPEED_CONTENT.RUN,
                                    m_nRunRatio,
                                    0,
                                    true);
                    MOTION_RESULT enResultY = MoveAbsolutely((int)EN_AXIS_LIST.HANDLER_Y,
                                    Position_Y,
                                    dSpeed_Y,
                                    MOTION_SPEED_CONTENT.RUN,
                                    m_nRunRatio,
                                    0,
                                    true);


                    MOTION_RESULT enResultBlockX = MoveAbsolutely((int)EN_AXIS_LIST.BLOCK_X,
                              Position_Block_X,
                              MOTION_SPEED_CONTENT.RUN,
                              m_nRunRatio,
                              0,
                              true);

                    MOTION_RESULT enResultZ = MoveAbsolutely((int)EN_AXIS_LIST.HANDLER_Z,
                                 Position_Z,
                                 dSpeed_Z,
                                 MOTION_SPEED_CONTENT.RUN,
                                 m_nRunRatio,
                                 0,
                                 true);

                    if (enResultZ == MOTION_RESULT.OK
                        && enResultX == MOTION_RESULT.OK
                         && enResultY == MOTION_RESULT.OK
                        && enResultBlockX == MOTION_RESULT.OK)
                        m_nSeqNum++;

                    if (GetSequenceTime() > m_nInterlockTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "HANDLER MOVE FAIL";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_enRecoveryAction = m_enAction;
                        m_nRecoveryStep = m_nSeqNum;
                        m_nSeqNum = (int)EN_LOADING_STEP.FINISH;
                        break;
                    }

                    break;

                case (int)EN_LOADING_STEP.MOVE_LOADING + 1:
                    double Position_R = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.HANDLER_WORKBLOCK_TRANSFER_POSITION_R.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

                    double dSpeed_R = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.HANDLER_R_MATERIAL_HANDLE_SPEED.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

                    MOTION_RESULT enResultR = MoveAbsolutely((int)EN_AXIS_LIST.HANDLER_R,
                                    Position_R,
                                    dSpeed_R,
                                    MOTION_SPEED_CONTENT.RUN,
                                    m_nRunRatio,
                                    0,
                                    true);


                    if (enResultR == MOTION_RESULT.OK)
                        m_nSeqNum++;

                    if (GetSequenceTime() > m_nInterlockTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "HANDLER MOVE FAIL";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_enRecoveryAction = m_enAction;
                        m_nRecoveryStep = m_nSeqNum;
                        m_nSeqNum = (int)EN_LOADING_STEP.FINISH;
                        break;
                    }

                    break;

                case (int)EN_LOADING_STEP.MOVE_LOADING + 2:
                    // 이동 순서 바뀔 수 있음
                    double Position_Block_Z = m_Recipe.GetValue(EN_TASK_LIST.WORK_ZONE.ToString(), WORKZONE_TASK_PARAM.BLOCK_TRANSFER_POSITION_Z.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

                    dSpeed_Z = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.HANDLER_Z_MATERIAL_HANDLE_SPEED.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

                    MOTION_RESULT enResultBlockZ = MoveAbsolutely((int)EN_AXIS_LIST.BLOCK_Z,
                                    Position_Block_Z,
                                    MOTION_SPEED_CONTENT.RUN,
                                    m_nRunRatio,
                                    0,
                                    true);

                    if (enResultBlockZ == MOTION_RESULT.OK)
                        m_nSeqNum++;

                    if (GetSequenceTime() > m_nInterlockTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "HANDLER MOVE FAIL";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_enRecoveryAction = m_enAction;
                        m_nRecoveryStep = m_nSeqNum;
                        m_nSeqNum = (int)EN_LOADING_STEP.FINISH;
                        break;
                    }

                    break;

                case (int)EN_LOADING_STEP.MOVE_LOADING + 3:
                    if (ReadDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.BLOCK_MATERIAL_VAC_1, false, 0) // 일단는 켜져있다면 확인 추후 필요시 윗스텝에서 VAC ON
                        && ReadDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.BLOCK_MATERIAL_VAC_2, false, 0))
                    {
                        if (m_instanceOperator.GetRunMode() == RunningMain_.RUN_MODE.AUTO)
                        {
                            double dVacValue = 0;
                            if (CheckMaterialExistInBlock(ref dVacValue))
                            {
                                m_arAlarmSubInfo[0] = "PLEASE REJECT WAFER. VAC VALUE : " + dVacValue.ToString();
                                GenerateSequenceAlarm((int)EN_TASK_ALARM.VAC_CHECK_FAIL, false, ref m_arAlarmSubInfo);
                                m_enRecoveryAction = m_enAction;
                                m_nRecoveryStep = m_nSeqNum;
                                m_nSeqNum = (int)EN_LOADING_STEP.FINISH;
                                break;
                            }
                        }
                    }
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.BLOCK_MATERIAL_VAC_1, false);// 유무 확인 후 VAC 꺼 주자 INTERLOCK 발생 
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.BLOCK_MATERIAL_VAC_2, false);
                    m_nSeqNum++;
                    break;

                // 이동 순서 바뀔 수 있음
                case (int)EN_LOADING_STEP.MOVE_LOADING + 4:
                    double Position_Lift_Z = m_Recipe.GetValue(EN_TASK_LIST.WORK_ZONE.ToString(), WORKZONE_TASK_PARAM.LIFT_TRANSFER_POSITION_Z.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

                    MOTION_RESULT enResultLiftZ = MoveAbsolutely((int)EN_AXIS_LIST.LIFT_Z,
                                    Position_Lift_Z,
                                    MOTION_SPEED_CONTENT.RUN,
                                    m_nRunRatio,
                                    0,
                                    true);

                    if (enResultLiftZ == MOTION_RESULT.OK)
                        m_nSeqNum = (int)EN_LOADING_STEP.LOADING;

                    if (GetSequenceTime() > m_nInterlockTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "HANDLER MOVE FAIL";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_enRecoveryAction = m_enAction;
                        m_nRecoveryStep = m_nSeqNum;
                        m_nSeqNum = (int)EN_LOADING_STEP.FINISH;
                        break;
                    }
                    break;
                #endregion

                #region LOADING
                case (int)EN_LOADING_STEP.LOADING:
                    Position_Z = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.HANDLER_WORKBLOCK_TRANSFER_CONTACT_POSITION_Z.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                    dSpeed_Z = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.HANDLER_Z_MATERIAL_CONTACT_SPEED.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

                    enResultZ = MoveAbsolutely((int)EN_AXIS_LIST.HANDLER_Z,
                                    Position_Z,
                                    dSpeed_Z,
                                    MOTION_SPEED_CONTENT.RUN,
                                    m_nRunRatio,
                                    0,
                                    true);

                    if (enResultZ == MOTION_RESULT.OK)
                        m_nSeqNum++;

                    if (GetSequenceTime() > m_nInterlockTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "HANDLER MOVE FAIL";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_enRecoveryAction = m_enAction;
                        m_nRecoveryStep = m_nSeqNum;
                        m_nSeqNum = (int)EN_LOADING_STEP.FINISH;
                        break;
                    }
                    break;
                case (int)EN_LOADING_STEP.LOADING + 1:
                    //23.11.20 by wdw [FIX] vac 순서 변경
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.HANDLER_MATERIAL_VAC, false);
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.HANDLER_MATERIAL_BLOW, true);
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LIFT_MATERIAL_VAC, true);
                    int nDelay = m_Recipe.GetValue(EN_TASK_LIST.WORK_ZONE.ToString(), WORKZONE_TASK_PARAM.LIFT_MATERIAL_VAC_ON_DELAY.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);
                    SetDelayForSequence(nDelay);
                    m_nSeqNum++;
                    break;
                case (int)EN_LOADING_STEP.LOADING + 2:
                    Position_Z = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.HANDLER_WORKBLOCK_TRANSFER_DOWN_POSITION_Z.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                    dSpeed_Z = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.HANDLER_Z_MATERIAL_CONTACT_SPEED.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

                    enResultZ = MoveAbsolutely((int)EN_AXIS_LIST.HANDLER_Z,
                                    Position_Z,
                                    dSpeed_Z,
                                    MOTION_SPEED_CONTENT.RUN,
                                    m_nRunRatio,
                                    0,
                                    true);

                    if (enResultZ == MOTION_RESULT.OK)
                        m_nSeqNum++;

                    if (GetSequenceTime() > m_nInterlockTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "HANDLER MOVE FAIL";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_enRecoveryAction = m_enAction;
                        m_nRecoveryStep = m_nSeqNum;
                        m_nSeqNum = (int)EN_LOADING_STEP.FINISH;
                        break;
                    }
                    break;
                case (int)EN_LOADING_STEP.LOADING + 3:
                    //23.11.20 by wdw [FIX] vac 순서 변경
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.HANDLER_MATERIAL_VAC, false);
                    nDelay = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.HANDLER_MATERIAL_VAC_OFF_DELAY.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);
                    SetDelayForSequence(nDelay);
                    m_nSeqNum++;
                    break;
                case (int)EN_LOADING_STEP.LOADING + 4:
                    if (m_instanceOperator.GetRunMode() == RunningMain_.RUN_MODE.AUTO)
                    {
                        double dVacValue = 0;
                        if (CheckMaterialExistInLift(ref dVacValue) == false)
                        {
                            m_arAlarmSubInfo[0] = "NOT EXIST LIFT VAC VALUE : " + dVacValue.ToString();
                            GenerateSequenceAlarm((int)EN_TASK_ALARM.VAC_CHECK_FAIL, false, ref m_arAlarmSubInfo);
                            m_enRecoveryAction = m_enAction;
                            m_nRecoveryStep = m_nSeqNum;
                            m_nSeqNum = (int)EN_LOADING_STEP.FINISH;
                            break;
                        }
                    }
                    m_nSeqNum++;
                    break;
                case (int)EN_LOADING_STEP.LOADING + 5:
                    Position_X = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.HANDLER_WORK_BLOCK_AVOID_POSITION_X.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                    //천천히 피해야 할까?

                    enResultX = MoveAbsolutely((int)EN_AXIS_LIST.HANDLER_X,
                                    Position_X,
                                    MOTION_SPEED_CONTENT.RUN,
                                    m_nRunRatio,
                                    0,
                                    true);

                    if (enResultX == MOTION_RESULT.OK)
                        m_nSeqNum++;

                    if (GetSequenceTime() > m_nInterlockTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "HANDLER MOVE FAIL";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_enRecoveryAction = m_enAction;
                        m_nRecoveryStep = m_nSeqNum;
                        m_nSeqNum = (int)EN_LOADING_STEP.FINISH;
                        break;
                    }
                    break;
                case (int)EN_LOADING_STEP.LOADING + 6:
                    Position_R = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.HANDLER_WORK_BLOCK_AVOID_POSITION_R.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                    //천천히 피해야 할까?

                    enResultR = MoveAbsolutely((int)EN_AXIS_LIST.HANDLER_R,
                                    Position_R,
                                    MOTION_SPEED_CONTENT.RUN,
                                    m_nRunRatio,
                                    0,
                                    true);

                    if (enResultR == MOTION_RESULT.OK)
                        m_nSeqNum++;

                    if (GetSequenceTime() > m_nInterlockTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "HANDLER MOVE FAIL";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_enRecoveryAction = m_enAction;
                        m_nRecoveryStep = m_nSeqNum;
                        m_nSeqNum = (int)EN_LOADING_STEP.FINISH;
                        break;
                    }
                    break;
                case (int)EN_LOADING_STEP.LOADING + 7:
                    Position_Z = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.HANDLER_WORK_BLOCK_AVOID_POSITION_Z.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

                    enResultZ = MoveAbsolutely((int)EN_AXIS_LIST.HANDLER_Z,
                                    Position_Z,
                                    MOTION_SPEED_CONTENT.RUN,
                                    m_nRunRatio,
                                    0,
                                    true);

                    if (enResultZ == MOTION_RESULT.OK)
                        m_nSeqNum++;

                    if (GetSequenceTime() > m_nInterlockTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "HANDLER MOVE FAIL";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_enRecoveryAction = m_enAction;
                        m_nRecoveryStep = m_nSeqNum;
                        m_nSeqNum = (int)EN_LOADING_STEP.FINISH;
                        break;
                    }
                    break;

                case (int)EN_LOADING_STEP.LOADING + 8:
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.HANDLER_MATERIAL_BLOW, false);
                    m_nSeqNum = (int)EN_LOADING_STEP.ACTION_FINISH;
                    break;
                #endregion

                #region ACTION_FINISH
                case (int)EN_LOADING_STEP.ACTION_FINISH:
                    _DynamicLink.SetPortStatus(GetTaskName(), EN_PORT_LIST.WORK_PORT.ToString(), DynamicLink_.EN_PORT_STATUS.WORKING, false);
                    _DynamicLink.SetPortStatus(EN_TASK_LIST.WORK_ZONE.ToString(), EN_PORT_LIST.WORK_PORT.ToString(), DynamicLink_.EN_PORT_STATUS.EXIST);
                    m_enRecoveryAction = EN_TASK_ACTION.STOP;
                    m_nRecoveryStep = 0;
                    IonizerInterluptOnOff(false);
                    IonizerTriggerOnOff(false);
                    m_nSeqNum = (int)EN_LOADING_STEP.FINISH;
                    break;
                #endregion

                #region FINISH
                case (int)EN_LOADING_STEP.FINISH:
                    return true;
                #endregion
            }
            return false;
        }

        private bool ActionBlockUnloading()
        {
            switch (m_nSeqNum)
            {
                #region ACTION START (0 ~ )
                case (int)EN_UNLOADING_STEP.ACTION_START:
                    if (m_instanceOperator.GetRunMode() == RunningMain_.RUN_MODE.SIMULATION)
                    {
                        SetDelayForSequence(2000);
                        m_nSeqNum = (int)EN_UNLOADING_STEP.ACTION_FINISH;
                        break;
                    }
                         DynamicLink_.EN_PORT_STATUS enPortStatus = DynamicLink_.EN_PORT_STATUS.EXIST;
                         DynamicLink_.EN_PORT_STATUS enWorkZonePortStatus = DynamicLink_.EN_PORT_STATUS.EXIST;
                    _DynamicLink.GetPortStatus(GetTaskName(), EN_PORT_LIST.WORK_PORT.ToString(), ref enPortStatus);
                    _DynamicLink.GetPortStatus(EN_TASK_LIST.WORK_ZONE.ToString(), EN_PORT_LIST.WORK_PORT.ToString(), ref enWorkZonePortStatus);
                    if (enWorkZonePortStatus != DynamicLink_.EN_PORT_STATUS.FINISHED)
                    {
                        m_arAlarmSubInfo[0] = "";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.STATUS_MISMATCH, false, ref m_arAlarmSubInfo);
                        m_nSeqNum = (int)EN_LOADING_STEP.FINISH;
                        break;
                    }

                    if (enPortStatus != DynamicLink_.EN_PORT_STATUS.WORKING)
                    {
                        m_arAlarmSubInfo[0] = "";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.STATUS_MISMATCH, false, ref m_arAlarmSubInfo);
                        m_nSeqNum = (int)EN_LOADING_STEP.FINISH;
                        break;
                    }

                    switch (m_enRecoveryAction)
                    {
                        case EN_TASK_ACTION.BLOCK_UNLOADING:
                            m_nSeqNum = m_nRecoveryStep;
                            break;

                        case EN_TASK_ACTION.STOP:
                            m_nSeqNum++;
                            break;

                        default:
                            m_arAlarmSubInfo[0] = "RECOVERY ACTION : " + m_enRecoveryAction.ToString();
                            GenerateSequenceAlarm((int)EN_TASK_ALARM.RECOVERY_STATUS_ALARM, false, ref m_arAlarmSubInfo);
                            m_nSeqNum = (int)EN_LOADING_STEP.FINISH;
                            break;
                    }
                    break;
                case (int)EN_UNLOADING_STEP.ACTION_START + 1:
                    IonizerTriggerOnOff(true);
                    int nDelay = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.IONIZER_CHECK_DELAY.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);
                    SetDelayForSequence(nDelay);
                    m_nSeqNum++;
                    break;
                case (int)EN_UNLOADING_STEP.ACTION_START + 2:
                    IonizerInterluptOnOff(true);
                    m_nSeqNum++;
                    break;
                case (int)EN_UNLOADING_STEP.ACTION_START + 3:
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.HANDLER_MATERIAL_VAC, true);
                    nDelay = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.HANDLER_MATERIAL_VAC_ON_DELAY.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);
                    SetDelayForSequence(nDelay);
                    m_nSeqNum++;
                    break;
                case (int)EN_UNLOADING_STEP.ACTION_START + 4:
                    if (m_instanceOperator.GetRunMode() == RunningMain_.RUN_MODE.AUTO)
                    {
                        double dVacValue = 0;
                        if (CheckMaterialExistInHandler(ref dVacValue))
                        {
                            m_arAlarmSubInfo[0] = "EXIST HANDLER. VAC VALUE : " + dVacValue.ToString();
                            GenerateSequenceAlarm((int)EN_TASK_ALARM.VAC_CHECK_FAIL, false, ref m_arAlarmSubInfo);
                            m_enRecoveryAction = m_enAction;
                            m_nRecoveryStep = m_nSeqNum;
                            m_nSeqNum = (int)EN_UNLOADING_STEP.FINISH;
                            break;
                        }
                    }
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.HANDLER_MATERIAL_VAC, false);
                    m_nSeqNum = (int)EN_UNLOADING_STEP.MOVE_UNLOADING;
                    break;
                #endregion

                #region MOVE_UNUNLOADING
                case (int)EN_UNLOADING_STEP.MOVE_UNLOADING:
                    // 이동 순서 바뀔 수 있음
                    double Position_Z = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.HANDLER_WORK_BLOCK_AVOID_POSITION_Z.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

                    MOTION_RESULT enResultZ = MoveAbsolutely((int)EN_AXIS_LIST.HANDLER_Z,
                                 Position_Z,
                                 MOTION_SPEED_CONTENT.RUN,
                                 m_nRunRatio,
                                 0,
                                 true);

                    if (enResultZ == MOTION_RESULT.OK)
                        m_nSeqNum++;

                    if (GetSequenceTime() > m_nInterlockTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "HANDLER MOVE FAIL";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_enRecoveryAction = m_enAction;
                        m_nRecoveryStep = m_nSeqNum;
                        m_nSeqNum = (int)EN_UNLOADING_STEP.FINISH;
                        break;
                    }

                    break;

                case (int)EN_UNLOADING_STEP.MOVE_UNLOADING + 1:
                    // 이동 순서 바뀔 수 있음
                    double Position_X = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.HANDLER_WORK_BLOCK_AVOID_POSITION_X.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                    double Position_Y = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.HANDLER_WORKBLOCK_TRANSFER_POSITION_Y.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

                    double Position_R = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.HANDLER_WORK_BLOCK_AVOID_POSITION_R.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                    double Position_Block_X = m_Recipe.GetValue(EN_TASK_LIST.WORK_ZONE.ToString(), WORKZONE_TASK_PARAM.BLOCK_TRANSFER_POSITION_X.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

                    MOTION_RESULT enResultX = MoveAbsolutely((int)EN_AXIS_LIST.HANDLER_X,
                                    Position_X,
                                    MOTION_SPEED_CONTENT.RUN,
                                    m_nRunRatio,
                                    0,
                                    true);
                    MOTION_RESULT enResultY = MoveAbsolutely((int)EN_AXIS_LIST.HANDLER_Y,
                                    Position_Y,
                                    MOTION_SPEED_CONTENT.RUN,
                                    m_nRunRatio,
                                    0,
                                    true);

                    MOTION_RESULT enResultR = MoveAbsolutely((int)EN_AXIS_LIST.HANDLER_R,
                                    Position_R,
                                    MOTION_SPEED_CONTENT.RUN,
                                    m_nRunRatio,
                                    0,
                                    true);
                    MOTION_RESULT enResultBlockX = MoveAbsolutely((int)EN_AXIS_LIST.BLOCK_X,
                              Position_Block_X,
                              MOTION_SPEED_CONTENT.RUN,
                              m_nRunRatio,
                              0,
                              true);

                    if (enResultX == MOTION_RESULT.OK
                         && enResultY == MOTION_RESULT.OK
                        && enResultR == MOTION_RESULT.OK
                        && enResultBlockX == MOTION_RESULT.OK)
                        m_nSeqNum++;

                    if (GetSequenceTime() > m_nInterlockTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "HANDLER MOVE FAIL";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_enRecoveryAction = m_enAction;
                        m_nRecoveryStep = m_nSeqNum;
                        m_nSeqNum = (int)EN_UNLOADING_STEP.FINISH;
                        break;
                    }
                    break;

                case (int)EN_UNLOADING_STEP.MOVE_UNLOADING + 2:
                    double Position_Block_Z = m_Recipe.GetValue(EN_TASK_LIST.WORK_ZONE.ToString(), WORKZONE_TASK_PARAM.BLOCK_TRANSFER_POSITION_Z.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

                    MOTION_RESULT enResultBlockZ = MoveAbsolutely((int)EN_AXIS_LIST.BLOCK_Z,
                                 Position_Block_Z,
                                 MOTION_SPEED_CONTENT.RUN,
                                 m_nRunRatio,
                                 0,
                                 true);
       
                    if (enResultBlockZ == MOTION_RESULT.OK)
                        m_nSeqNum++;

                    if (GetSequenceTime() > m_nInterlockTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "BLOCK MOVE FAIL";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_enRecoveryAction = m_enAction;
                        m_nRecoveryStep = m_nSeqNum;
                        m_nSeqNum = (int)EN_UNLOADING_STEP.FINISH;
                        break;
                    }
                    break;

                case (int)EN_UNLOADING_STEP.MOVE_UNLOADING + 3:
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LIFT_MATERIAL_VAC, true);
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.BLOCK_MATERIAL_VAC_1, false);
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.BLOCK_MATERIAL_VAC_2, false);
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.BLOCK_MATERIAL_BLOW, true);
                    int dLiftVacOffDelay = m_Recipe.GetValue(EN_TASK_LIST.WORK_ZONE.ToString(), WORKZONE_TASK_PARAM.BLOCK_MATERIAL_VAC_OFF_DELAY.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);
                    SetDelayForSequence(dLiftVacOffDelay);
                    m_nSeqNum++;
                    break;
                case (int)EN_UNLOADING_STEP.MOVE_UNLOADING + 4:
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.BLOCK_MATERIAL_BLOW, false);
                    m_nSeqNum++;
                    break;

                case (int)EN_UNLOADING_STEP.MOVE_UNLOADING + 5:
                    // 이동 순서 바뀔 수 있음
                    double Position_Lift_Z = m_Recipe.GetValue(EN_TASK_LIST.WORK_ZONE.ToString(), WORKZONE_TASK_PARAM.LIFT_TRANSFER_POSITION_Z.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                    Position_Z = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.HANDLER_WORKBLOCK_TRANSFER_DOWN_POSITION_Z.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);


                    enResultZ = MoveAbsolutely((int)EN_AXIS_LIST.HANDLER_Z,
                                 Position_Z,
                                 MOTION_SPEED_CONTENT.RUN,
                                 m_nRunRatio,
                                 0,
                                 true);

                    MOTION_RESULT enResultLiftZ = MoveAbsolutely((int)EN_AXIS_LIST.LIFT_Z,
                                    Position_Lift_Z,
                                    MOTION_SPEED_CONTENT.RUN,
                                    m_nRunRatio,
                                    0,
                                    true);

                    if (enResultLiftZ == MOTION_RESULT.OK
                        && enResultZ == MOTION_RESULT.OK)
                        m_nSeqNum++;

                    if (GetSequenceTime() > m_nInterlockTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "HANDLER MOVE FAIL";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_enRecoveryAction = m_enAction;
                        m_nRecoveryStep = m_nSeqNum;
                        m_nSeqNum = (int)EN_UNLOADING_STEP.FINISH;
                        break;
                    }
                    break;
                // 이동 순서 바뀔 수 있음
                case (int)EN_UNLOADING_STEP.MOVE_UNLOADING + 6:
                    Position_R = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.HANDLER_WORKBLOCK_TRANSFER_POSITION_R.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

                    enResultR = MoveAbsolutely((int)EN_AXIS_LIST.HANDLER_R,
                                    Position_R,
                                    MOTION_SPEED_CONTENT.RUN,
                                    m_nRunRatio,
                                    0,
                                    true);

                    if (enResultR == MOTION_RESULT.OK)
                        m_nSeqNum = (int)EN_UNLOADING_STEP.UNLOADING;

                    if (GetSequenceTime() > m_nInterlockTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "HANDLER MOVE FAIL";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_enRecoveryAction = m_enAction;
                        m_nRecoveryStep = m_nSeqNum;
                        m_nSeqNum = (int)EN_UNLOADING_STEP.FINISH;
                        break;
                    }
                    break;
                #endregion

                #region UNLOADING
                case (int)EN_UNLOADING_STEP.UNLOADING:
                    Position_X = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.HANDLER_WORKBLOCK_TRANSFER_POSITION_X.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                    enResultX = MoveAbsolutely((int)EN_AXIS_LIST.HANDLER_X,
                                    Position_X,
                                    MOTION_SPEED_CONTENT.RUN,
                                    m_nRunRatio,
                                    0,
                                    true);

                    if (enResultX == MOTION_RESULT.OK)
                        m_nSeqNum++;

                    if (GetSequenceTime() > m_nInterlockTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "HANDLER MOVE FAIL";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_enRecoveryAction = m_enAction;
                        m_nRecoveryStep = m_nSeqNum;
                        m_nSeqNum = (int)EN_UNLOADING_STEP.FINISH;
                        break;
                    }
                    break;

                case (int)EN_UNLOADING_STEP.UNLOADING + 1:
                    Position_Z = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.HANDLER_WORKBLOCK_TRANSFER_CONTACT_POSITION_Z.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

                    double dSpeed = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.HANDLER_Z_MATERIAL_CONTACT_SPEED.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

                    enResultZ = MoveAbsolutely((int)EN_AXIS_LIST.HANDLER_Z,
                                    Position_Z,
                                    dSpeed,
                                    MOTION_SPEED_CONTENT.RUN,
                                    m_nRunRatio,
                                    0,
                                    true);

                    if (enResultZ == MOTION_RESULT.OK)
                        m_nSeqNum++;

                    if (GetSequenceTime() > m_nInterlockTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "HANDLER MOVE FAIL";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_enRecoveryAction = m_enAction;
                        m_nRecoveryStep = m_nSeqNum;
                        m_nSeqNum = (int)EN_UNLOADING_STEP.FINISH;
                        break;
                    }
                    break;
                case (int)EN_UNLOADING_STEP.UNLOADING + 2:
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.HANDLER_MATERIAL_VAC, true);
                    //23.11.20 by wdw [FIX] vac 순서 변경
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LIFT_MATERIAL_VAC, false);
                    nDelay = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.HANDLER_MATERIAL_VAC_ON_DELAY.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);
                    SetDelayForSequence(nDelay);
                    m_nSeqNum++;
                    break;
                case (int)EN_UNLOADING_STEP.UNLOADING + 3:
                    Position_Z = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.HANDLER_WORKBLOCK_TRANSFER_UP_POSITION_Z.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

                    dSpeed = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.HANDLER_Z_MATERIAL_CONTACT_SPEED.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

                    enResultZ = MoveAbsolutely((int)EN_AXIS_LIST.HANDLER_Z,
                                    Position_Z,
                                    dSpeed,
                                    MOTION_SPEED_CONTENT.RUN,
                                    m_nRunRatio,
                                    0,
                                    true);

                    if (enResultZ == MOTION_RESULT.OK)
                        m_nSeqNum++;

                    if (GetSequenceTime() > m_nInterlockTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "HANDLER MOVE FAIL";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_enRecoveryAction = m_enAction;
                        m_nRecoveryStep = m_nSeqNum;
                        m_nSeqNum = (int)EN_UNLOADING_STEP.FINISH;
                        break;
                    }
                    break;

                case (int)EN_UNLOADING_STEP.UNLOADING + 4:
                    //23.11.20 by wdw [FIX] vac 순서 변경
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LIFT_MATERIAL_VAC, false);
                    nDelay = m_Recipe.GetValue(EN_TASK_LIST.WORK_ZONE.ToString(), WORKZONE_TASK_PARAM.LIFT_MATERIAL_VAC_OFF_DELAY.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);
                    SetDelayForSequence(nDelay);
                    m_nSeqNum++;
                    break;
                case (int)EN_UNLOADING_STEP.UNLOADING + 5:
                    if (m_instanceOperator.GetRunMode() == RunningMain_.RUN_MODE.AUTO)
                    {
                        double dVacValue = 0;
                        if (CheckMaterialExistInHandler(ref dVacValue) == false)
                        {
                            m_arAlarmSubInfo[0] = "NOT EXIST HANDLER. VAC VALUE : " + dVacValue.ToString();
                            GenerateSequenceAlarm((int)EN_TASK_ALARM.VAC_CHECK_FAIL, false, ref m_arAlarmSubInfo);
                            m_enRecoveryAction = m_enAction;
                            m_nRecoveryStep = m_nSeqNum;
                            m_nSeqNum = (int)EN_UNLOADING_STEP.FINISH;
                            break;
                        }
                    }
                    m_nSeqNum++;
                    break;
                case (int)EN_UNLOADING_STEP.UNLOADING + 6:
                    Position_Block_Z = m_Recipe.GetValue(EN_TASK_LIST.WORK_ZONE.ToString(), WORKZONE_TASK_PARAM.BLOCK_READY_POSITION_Z.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                    Position_Lift_Z = m_Recipe.GetValue(EN_TASK_LIST.WORK_ZONE.ToString(), WORKZONE_TASK_PARAM.LIFT_READY_POSITION_Z.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

                    enResultBlockZ = MoveAbsolutely((int)EN_AXIS_LIST.BLOCK_Z,
                                 Position_Block_Z,
                                 MOTION_SPEED_CONTENT.RUN,
                                 m_nRunRatio,
                                 0,
                                 true);
                    enResultLiftZ = MoveAbsolutely((int)EN_AXIS_LIST.LIFT_Z,
                                    Position_Lift_Z,
                                    MOTION_SPEED_CONTENT.RUN,
                                    m_nRunRatio,
                                    0,
                                    true);

                    if (enResultBlockZ == MOTION_RESULT.OK
                         && enResultLiftZ == MOTION_RESULT.OK)
                        m_nSeqNum++;


                    if (GetSequenceTime() > m_nInterlockTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "HANDLER MOVE FAIL";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_enRecoveryAction = m_enAction;
                        m_nRecoveryStep = m_nSeqNum;
                        m_nSeqNum = (int)EN_UNLOADING_STEP.FINISH;
                        break;
                    }

                    break;
                case (int)EN_UNLOADING_STEP.UNLOADING + 7:
                    Position_R = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.HANDLER_WORK_BLOCK_AVOID_POSITION_R.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                    dSpeed = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.HANDLER_R_MATERIAL_HANDLE_SPEED.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

                    enResultR = MoveAbsolutely((int)EN_AXIS_LIST.HANDLER_R,
                                    Position_R,
                                    dSpeed,
                                    MOTION_SPEED_CONTENT.RUN,
                                    100,
                                    0,
                                    true);

                    if (enResultR == MOTION_RESULT.OK)
                        m_nSeqNum = (int)EN_UNLOADING_STEP.ACTION_FINISH;

                    if (GetSequenceTime() > m_nInterlockTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "HANDLER MOVE FAIL";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_enRecoveryAction = m_enAction;
                        m_nRecoveryStep = m_nSeqNum;
                        m_nSeqNum = (int)EN_UNLOADING_STEP.FINISH;
                        break;
                    }
                    break;
                case (int)EN_UNLOADING_STEP.UNLOADING + 8:
                    Position_Z = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.HANDLER_WORK_BLOCK_AVOID_POSITION_Z.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                    dSpeed = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.HANDLER_Z_MATERIAL_HANDLE_SPEED.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

                    enResultZ = MoveAbsolutely((int)EN_AXIS_LIST.HANDLER_Z,
                                 Position_Z,
                                 dSpeed,
                                 MOTION_SPEED_CONTENT.RUN,
                                 m_nRunRatio,
                                 0,
                                 true);

                    if (enResultZ == MOTION_RESULT.OK)
                        m_nSeqNum = (int)EN_UNLOADING_STEP.ACTION_FINISH;

                    if (GetSequenceTime() > m_nInterlockTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "HANDLER MOVE FAIL";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_enRecoveryAction = m_enAction;
                        m_nRecoveryStep = m_nSeqNum;
                        m_nSeqNum = (int)EN_UNLOADING_STEP.FINISH;
                        break;
                    }
                    break;
                #endregion

                #region ACTION_FINISH
                case (int)EN_UNLOADING_STEP.ACTION_FINISH:
                    _DynamicLink.SetPortStatus(GetTaskName(), EN_PORT_LIST.WORK_PORT.ToString(), DynamicLink_.EN_PORT_STATUS.FINISHED, false);
                    _DynamicLink.SetPortStatus(EN_TASK_LIST.WORK_ZONE.ToString(), EN_PORT_LIST.WORK_PORT.ToString(), DynamicLink_.EN_PORT_STATUS.EMPTY);
                    m_enRecoveryAction = EN_TASK_ACTION.STOP;
                    m_nRecoveryStep = 0;
                    m_nSeqNum = (int)EN_UNLOADING_STEP.FINISH;
                    break;
                #endregion

                #region FINISH
                case (int)EN_UNLOADING_STEP.FINISH:
                    return true;
                #endregion
            }
            return false;
        }
     
        private bool ActionEquipmentUnloading()
        {
            switch (m_nSeqNum)
            {
                #region ACTION START (0 ~ )
                case (int)EN_UNLOADING_STEP.ACTION_START:
                    if (m_instanceOperator.GetRunMode() == RunningMain_.RUN_MODE.SIMULATION)
                    {
                        SetDelayForSequence(2000);
                        m_nSeqNum = (int)EN_UNLOADING_STEP.ACTION_FINISH;
                        break;
                    }
                     DynamicLink_.EN_PORT_STATUS enPortStatus = DynamicLink_.EN_PORT_STATUS.EXIST;
                    _DynamicLink.GetPortStatus(GetTaskName(), EN_PORT_LIST.WORK_PORT.ToString(), ref enPortStatus);
                    if (enPortStatus != DynamicLink_.EN_PORT_STATUS.FINISHED)
                    {
                        m_arAlarmSubInfo[0] = "";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.STATUS_MISMATCH, false, ref m_arAlarmSubInfo);
                        m_nSeqNum = (int)EN_UNLOADING_STEP.FINISH;
                        break;
                    }
                    switch (m_enRecoveryAction)
                    {
                        case EN_TASK_ACTION.EQUIPMENT_UNLOADING:
                            m_nSeqNum = m_nRecoveryStep;
                            break;

                        case EN_TASK_ACTION.STOP:
                            if (m_tRecovery.nInSmemaPort < 1)
                                m_tRecovery.nInSmemaPort = 1;
                            else if (m_tRecovery.nInSmemaPort > 2)
                                m_tRecovery.nInSmemaPort = 2;
                            m_nSeqNum = (int)EN_UNLOADING_STEP.MOVE_UNLOADING;
                            break;

                        default:
                            m_arAlarmSubInfo[0] = "RECOVERY ACTION : " + m_enRecoveryAction.ToString();
                            GenerateSequenceAlarm((int)EN_TASK_ALARM.RECOVERY_STATUS_ALARM, false, ref m_arAlarmSubInfo);
                            m_nSeqNum = (int)EN_LOADING_STEP.FINISH;
                            break;
                    }
                    break;
                #endregion

                #region MOVE_UNLOADING
                case (int)EN_UNLOADING_STEP.MOVE_UNLOADING:
                    // 이동 순서 바뀔 수 있음
                    double Position_X = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.HANDLER_READY_X.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                    double Position_Y = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.HANDLER_PRE_EQUIPMENT_TRANSFER_POSITION_Y_2.ToString(), m_tRecovery.nInSmemaPort - 1, EN_RECIPE_PARAM_TYPE.VALUE, 0.0)
                                        + m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.HANDLER_PRE_EQUIPMENT_TRANSFER_OFFSET_Y_2.ToString(), m_tRecovery.nInSmemaPort - 1, EN_RECIPE_PARAM_TYPE.VALUE, 0.0); //23.11.23 by wdw [ADD] R축 충돌 방지 동작 추가
                    double Position_Z = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.HANDLER_PRE_EQUIPMENT_TRANSFER_UP_POSITION_Z_2.ToString(), m_tRecovery.nInSmemaPort - 1, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                    double Position_R = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.HANDLER_WORK_BLOCK_AVOID_POSITION_R.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

                    double dSpeed_X = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.HANDLER_X_MATERIAL_HANDLE_SPEED.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                    double dSpeed_Y = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.HANDLER_Y_MATERIAL_HANDLE_SPEED.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                    double dSpeed_Z = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.HANDLER_Z_MATERIAL_HANDLE_SPEED.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                    double dSpeed_R = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.HANDLER_R_MATERIAL_HANDLE_SPEED.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

                    MOTION_RESULT enResultX = MoveAbsolutely((int)EN_AXIS_LIST.HANDLER_X,
                                    Position_X,
                                    dSpeed_X,
                                    MOTION_SPEED_CONTENT.RUN,
                                    100,
                                    0,
                                    true);
                    MOTION_RESULT enResultY = MoveAbsolutely((int)EN_AXIS_LIST.HANDLER_Y,
                                    Position_Y,
                                    dSpeed_Y,
                                    MOTION_SPEED_CONTENT.RUN,
                                    100,
                                    0,
                                    true);
                    MOTION_RESULT enResultZ = MoveAbsolutely((int)EN_AXIS_LIST.HANDLER_Z,
                                 Position_Z,
                                 dSpeed_Z,
                                 MOTION_SPEED_CONTENT.RUN,
                                 100,
                                 0,
                                 true);
                    MOTION_RESULT enResultR = MoveAbsolutely((int)EN_AXIS_LIST.HANDLER_R,
                                    Position_R,
                                    dSpeed_R,
                                    MOTION_SPEED_CONTENT.RUN,
                                    100,
                                    0,
                                    true);

                    if (enResultX == MOTION_RESULT.OK
                        && enResultY == MOTION_RESULT.OK
                        && enResultZ == MOTION_RESULT.OK
                        && enResultR == MOTION_RESULT.OK)
                        m_nSeqNum = (int)EN_UNLOADING_STEP.UNLOADING;

                    if (GetSequenceTime() > m_nInterlockTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "HANDLER MOVE FAIL";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_enRecoveryAction = m_enAction;
                        m_nRecoveryStep = m_nSeqNum;
                        m_nSeqNum = (int)EN_UNLOADING_STEP.FINISH;
                        break;
                    }

                    break;
                #endregion

                #region UNLOADING
                case (int)EN_UNLOADING_STEP.UNLOADING:
                    SetPreSmemaOutput(true);
                    m_nSeqNum++;
                    break;
                case (int)EN_UNLOADING_STEP.UNLOADING + 1:
                    if(m_instanceOperator.IsEquipmentFinishing())
                    {
                        // UNLOADING 시작 전 정지 가능 
                        SetPreSmemaOutput(false);
                        m_nSeqNum = (int)EN_LOADING_STEP.FINISH;
                        break;
                    }
                    if(CheckPreSmema(true, false))
                        m_nSeqNum++;
                    else //Sequence TimeOut 방지
                        m_nSeqNum--;
                    break;
                case (int)EN_UNLOADING_STEP.UNLOADING + 2:
                    if (GetSequenceTime() > m_nCommunicationTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "SMEMA SUB " + m_tRecovery.nInSmemaPort + " ON";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.COMMUNICATION_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_enRecoveryAction = m_enAction;
                        m_nRecoveryStep = m_nSeqNum;
                        m_nSeqNum = (int)EN_LOADING_STEP.FINISH;
                        break;
                    }
                    if (CheckPreSmemaSub(true))
                        m_nSeqNum++;
                    break;
                case (int)EN_UNLOADING_STEP.UNLOADING + 3:
                    Position_R = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.HANDLER_PRE_EQUIPMENT_TRANSFER_POSITION_R.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                    dSpeed_R = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.HANDLER_R_MATERIAL_HANDLE_SPEED.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

                    enResultR = MoveAbsolutely((int)EN_AXIS_LIST.HANDLER_R,
                                    Position_R,
                                    dSpeed_R,
                                    MOTION_SPEED_CONTENT.RUN,
                                    100,
                                    0,
                                    true);

                    if (enResultR == MOTION_RESULT.OK)
                        m_nSeqNum++;

                    if (GetSequenceTime() > m_nInterlockTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "HANDLER MOVE FAIL";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_enRecoveryAction = m_enAction;
                        m_nRecoveryStep = m_nSeqNum;
                        m_nSeqNum = (int)EN_UNLOADING_STEP.FINISH;
                        break;
                    }
                    break;
                case (int)EN_UNLOADING_STEP.UNLOADING + 4:
                    //23.11.23 by wdw [ADD] R축 충돌 방지 동작 추가
                    Position_Y = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.HANDLER_PRE_EQUIPMENT_TRANSFER_POSITION_Y_2.ToString(), m_tRecovery.nInSmemaPort - 1, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                    dSpeed_Y = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.HANDLER_Y_MATERIAL_HANDLE_SPEED.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

                    enResultY = MoveAbsolutely((int)EN_AXIS_LIST.HANDLER_Y,
                                    Position_Y,
                                    dSpeed_Y,
                                    MOTION_SPEED_CONTENT.RUN,
                                    100,
                                    0,
                                    true);

                    if (enResultY == MOTION_RESULT.OK)
                        m_nSeqNum++;

                    if (GetSequenceTime() > m_nInterlockTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "HANDLER MOVE FAIL";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_enRecoveryAction = m_enAction;
                        m_nRecoveryStep = m_nSeqNum;
                        m_nSeqNum = (int)EN_UNLOADING_STEP.FINISH;
                        break;
                    }
                    break;
                case (int)EN_UNLOADING_STEP.UNLOADING + 5:
                    Position_X = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.HANDLER_PRE_EQUIPMENT_TRANSFER_POSITION_X_2.ToString(), m_tRecovery.nInSmemaPort - 1, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                    dSpeed_X = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.HANDLER_X_MATERIAL_HANDLE_SPEED.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

                    enResultX = MoveAbsolutely((int)EN_AXIS_LIST.HANDLER_X,
                                    Position_X,
                                    dSpeed_X,
                                    MOTION_SPEED_CONTENT.RUN,
                                    100,
                                    0,
                                    true);

                    if (enResultX == MOTION_RESULT.OK)
                        m_nSeqNum++;

                    if (GetSequenceTime() > m_nInterlockTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "HANDLER MOVE FAIL";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_enRecoveryAction = m_enAction;
                        m_nRecoveryStep = m_nSeqNum;
                        m_nSeqNum = (int)EN_UNLOADING_STEP.FINISH;
                        break;
                    }
                    break;
                case (int)EN_UNLOADING_STEP.UNLOADING + 6:
                    SetPreSmemaSubOutput(true);
                    m_nSeqNum++;

                    break;
                case (int)EN_UNLOADING_STEP.UNLOADING + 7:
                     bool bUseWCF = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, Recipe.PARAM_EQUIPMENT.PREEQUIPMENT_WCF_USED.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, true);

                     if (bUseWCF)
                     {
                         if (GetSequenceTime() > m_nCommunicationTimeOut)
                         {
                             m_arAlarmSubInfo[0] = "SEND RESULT FAIL";
                             GenerateSequenceAlarm((int)EN_TASK_ALARM.COMMUNICATION_TIMEOUT, false, ref m_arAlarmSubInfo);
                             m_enRecoveryAction = m_enAction;
                             m_nRecoveryStep = m_nSeqNum;
                             m_nSeqNum = (int)EN_LOADING_STEP.FINISH;
                             break;
                         }
                         if (ExternalDevice.TransportWIR.GetInstance().SendWorkResult(m_tRecovery.nInSmemaPort, WorkMap.GetInstance().GetWorkStatus()))
                             m_nSeqNum++;
                         else //재연결
                             ExternalDevice.TransportWIR.GetInstance().Connect();
                     }
                     else
                     {
                         m_nSeqNum++;
                     }
                    break;

                case (int)EN_UNLOADING_STEP.UNLOADING + 8:
                    bUseWCF = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, Recipe.PARAM_EQUIPMENT.PREEQUIPMENT_WCF_USED.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, true);

                    if (bUseWCF)
                    {
                        if (GetSequenceTime() > m_nCommunicationTimeOut)
                        {
                            m_arAlarmSubInfo[0] = "RECEIVE RESPONE FAIL";
                            GenerateSequenceAlarm((int)EN_TASK_ALARM.COMMUNICATION_TIMEOUT, false, ref m_arAlarmSubInfo);
                            m_enRecoveryAction = m_enAction;
                            m_nRecoveryStep = m_nSeqNum - 1; //재전송
                            m_nSeqNum = (int)EN_LOADING_STEP.FINISH;
                            break;
                        }
                        List<Mail> lstMail = GetMail(EN_SUBSCRIBER.PRE_EQUIPMENT_WCF, EN_MAIL.WCF_RESOPONE);
                        if (lstMail == null)
                            break;
                        foreach (Mail mail in lstMail)
                        {
                            foreach (object Content in mail.Content)
                            {
                                if (Content.ToString() != "Good")
                                {
                                    //ALARM 넣어야 하나? 일단 넣자
                                    m_arAlarmSubInfo[0] = "RECEIVE " + Content.ToString() + " ACK";
                                    GenerateSequenceAlarm((int)EN_TASK_ALARM.COMMUNICATION_ALARM, false, ref m_arAlarmSubInfo);
                                    m_enRecoveryAction = m_enAction;
                                    m_nRecoveryStep = m_nSeqNum - 1; //재전송
                                    m_nSeqNum = (int)EN_LOADING_STEP.FINISH;
                                    break;
                                }
                            }
                        }
                    }
                    m_nSeqNum++;
                    break;

                case (int)EN_UNLOADING_STEP.UNLOADING + 9:
                    //23.11.20 by wdw [FIX] vac 순서 변경
//                     WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.HANDLER_MATERIAL_VAC, false);
//                     WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.HANDLER_MATERIAL_BLOW, true);
//                     int nDelay = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.HANDLER_MATERIAL_VAC_OFF_DELAY.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);
//                     SetDelayForSequence(nDelay);
                    m_nSeqNum++;
                    break;

                case (int)EN_UNLOADING_STEP.UNLOADING + 10:
                    // VAC CHECK 해야 할까?
//                     double dThreshold = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.HANDLER_MATERIAL_VAC_THRESHOLD.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
//                     double dVacValue = ReadAnalogInputValue((int)EN_ANALOG_INPUT_LIST.HANDLER_MATERIAL_VAC);
//                     if (dThreshold > dVacValue)
//                     {
//                         m_arAlarmSubInfo[0] = "HANDLER VAC VALUE : " + dVacValue.ToString();
//                         GenerateSequenceAlarm((int)EN_TASK_ALARM.VAC_CHECK_FAIL, false, ref m_arAlarmSubInfo);
//                         m_nSeqNum = (int)EN_UNLOADING_STEP.FINISH;
//                         break;
//                     }
//                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.HANDLER_MATERIAL_BLOW, false);
                    m_nSeqNum++;
                    break;
                case (int)EN_UNLOADING_STEP.UNLOADING + 11:
                    Position_Z = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.HANDLER_PRE_EQUIPMENT_TRANSFER_CONTACT_POSITION_Z_2.ToString(), m_tRecovery.nInSmemaPort - 1, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                    dSpeed_Z = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.HANDLER_Z_MATERIAL_CONTACT_SPEED.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

                    enResultZ = MoveAbsolutely((int)EN_AXIS_LIST.HANDLER_Z,
                                    Position_Z,
                                    dSpeed_Z,
                                    MOTION_SPEED_CONTENT.RUN,
                                    m_nRunRatio,
                                    0,
                                    true);

                    if (enResultZ == MOTION_RESULT.OK)
                        m_nSeqNum++;

                    if (GetSequenceTime() > m_nInterlockTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "HANDLER MOVE FAIL";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_enRecoveryAction = m_enAction;
                        m_nRecoveryStep = m_nSeqNum;
                        m_nSeqNum = (int)EN_UNLOADING_STEP.FINISH;
                        break;
                    }
                    break;
                case (int)EN_UNLOADING_STEP.UNLOADING + 12:
                    //23.11.20 by wdw [FIX] vac 순서 변경
                    if (m_bTransferTest == false)
                    {
                        WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.HANDLER_MATERIAL_VAC, false);
                        int nDelay = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.HANDLER_MATERIAL_VAC_OFF_DELAY.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);
                        SetDelayForSequence(nDelay);
                    }
                    m_nSeqNum++;
                    break;
                case (int)EN_UNLOADING_STEP.UNLOADING + 13:
                    Position_Z = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.HANDLER_PRE_EQUIPMENT_TRANSFER_DOWN_POSITION_Z_2.ToString(), m_tRecovery.nInSmemaPort - 1, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                    dSpeed_Z = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.HANDLER_Z_MATERIAL_CONTACT_SPEED.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

                    enResultZ = MoveAbsolutely((int)EN_AXIS_LIST.HANDLER_Z,
                                    Position_Z,
                                    dSpeed_Z,
                                    MOTION_SPEED_CONTENT.RUN,
                                    m_nRunRatio,
                                    0,
                                    true);

                    if (enResultZ == MOTION_RESULT.OK)
                        m_nSeqNum++;

                    if (GetSequenceTime() > m_nInterlockTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "HANDLER MOVE FAIL";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_enRecoveryAction = m_enAction;
                        m_nRecoveryStep = m_nSeqNum;
                        m_nSeqNum = (int)EN_UNLOADING_STEP.FINISH;
                        break;
                    }
                    break;
                case (int)EN_UNLOADING_STEP.UNLOADING + 14:
                    SetPreSmemaSubOutput(false);
                    m_nSeqNum++;
                    break;
                case (int)EN_UNLOADING_STEP.UNLOADING + 15:
                    if (GetSequenceTime() > m_nCommunicationTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "SMEMA SUB " + m_tRecovery.nInSmemaPort + " OFF";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.COMMUNICATION_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_enRecoveryAction = m_enAction;
                        m_nRecoveryStep = m_nSeqNum;
                        m_nSeqNum = (int)EN_LOADING_STEP.FINISH;
                        break;
                    }
                    if (CheckPreSmemaSub(false))
                        m_nSeqNum++;
                    break;
                case (int)EN_UNLOADING_STEP.UNLOADING + 16:
                    Position_X = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.HANDLER_READY_X.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

                    enResultX = MoveAbsolutely((int)EN_AXIS_LIST.HANDLER_X,
                                    Position_X,
                                    MOTION_SPEED_CONTENT.RUN,
                                    m_nRunRatio,
                                    0,
                                    true);

                    if (enResultX == MOTION_RESULT.OK)
                        m_nSeqNum++;

                    if (GetSequenceTime() > m_nInterlockTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "HANDLER MOVE FAIL";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_enRecoveryAction = m_enAction;
                        m_nRecoveryStep = m_nSeqNum;
                        m_nSeqNum = (int)EN_UNLOADING_STEP.FINISH;
                        break;
                    }
                    break;
                case (int)EN_UNLOADING_STEP.UNLOADING + 17:
                    //23.11.23 by wdw [ADD] R축 충돌 방지 동작 추가
                    Position_Y = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.HANDLER_PRE_EQUIPMENT_TRANSFER_POSITION_Y_2.ToString(), m_tRecovery.nInSmemaPort - 1, EN_RECIPE_PARAM_TYPE.VALUE, 0.0)
                                + m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.HANDLER_PRE_EQUIPMENT_TRANSFER_OFFSET_Y_2.ToString(), m_tRecovery.nInSmemaPort - 1, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

                    enResultY = MoveAbsolutely((int)EN_AXIS_LIST.HANDLER_Y,
                                    Position_Y,
                                    MOTION_SPEED_CONTENT.RUN,
                                    100,
                                    0,
                                    true);

                    if (enResultY == MOTION_RESULT.OK)
                        m_nSeqNum++;

                    if (GetSequenceTime() > m_nInterlockTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "HANDLER MOVE FAIL";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_enRecoveryAction = m_enAction;
                        m_nRecoveryStep = m_nSeqNum;
                        m_nSeqNum = (int)EN_UNLOADING_STEP.FINISH;
                        break;
                    }
                    break;
                case (int)EN_UNLOADING_STEP.UNLOADING + 18:
                    Position_R = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.HANDLER_WORK_BLOCK_AVOID_POSITION_R.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

                    enResultR = MoveAbsolutely((int)EN_AXIS_LIST.HANDLER_R,
                                    Position_R,
                                    0,
                                    MOTION_SPEED_CONTENT.RUN,
                                    100,
                                    0,
                                    true);

                    if (enResultR == MOTION_RESULT.OK)
                        m_nSeqNum++;

                    if (GetSequenceTime() > m_nInterlockTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "HANDLER MOVE FAIL";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_enRecoveryAction = m_enAction;
                        m_nRecoveryStep = m_nSeqNum;
                        m_nSeqNum = (int)EN_UNLOADING_STEP.FINISH;
                        break;
                    }
                    break;

                case (int)EN_UNLOADING_STEP.UNLOADING + 19:
                    SetPreSmemaOutput(false);
                    m_nSeqNum++;
                    break;
                case (int)EN_UNLOADING_STEP.UNLOADING + 20:
                    if (GetSequenceTime() > m_nCommunicationTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "SMEMA " + m_tRecovery.nInSmemaPort + " OFF";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.COMMUNICATION_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_enRecoveryAction = m_enAction;
                        m_nRecoveryStep = m_nSeqNum;
                        m_nSeqNum = (int)EN_LOADING_STEP.FINISH;
                        break;
                    }
                    if (CheckPreSmema(false))
                        m_nSeqNum = (int)EN_UNLOADING_STEP.ACTION_FINISH;
                    break;
                #endregion

                #region ACTION_FINISH
                case (int)EN_UNLOADING_STEP.ACTION_FINISH:
                    _DynamicLink.SetPortStatus(GetTaskName(), EN_PORT_LIST.WORK_PORT.ToString(), DynamicLink_.EN_PORT_STATUS.EMPTY, false);
                    _DynamicLink.SetPortStatus(EN_TASK_LIST.WORK_ZONE.ToString(), EN_PORT_LIST.WORK_PORT.ToString(), DynamicLink_.EN_PORT_STATUS.EMPTY);
                    WorkMap.GetInstance().SaveBackup();
                    m_enRecoveryAction = EN_TASK_ACTION.STOP;
                    m_nRecoveryStep = 0;
                    IonizerInterluptOnOff(false);
                    IonizerTriggerOnOff(false);
                    WriteTranferTestLog();
                    EFEMManager.GetInstance().AddQueCeid(EFEMManager.EN_CEID.PLR_END);

                    m_nSeqNum = (int)EN_UNLOADING_STEP.FINISH;
                    break;
                #endregion

                #region FINISH
                case (int)EN_UNLOADING_STEP.FINISH:
                    return true;
                #endregion
            }
            return false;
        }
        #endregion

        #region Manual
        private bool ActionMoveAvoid()
        {
            switch (m_nSeqNum)
            {
                #region ACTION START (0 ~ )
                case (int)EN_MOVE_STEP.ACTION_START:

                            m_nSeqNum = (int)EN_MOVE_STEP.MOVE;
                            break;

                    break;
                #endregion

                #region MOVE_UNLOADING
                case (int)EN_MOVE_STEP.MOVE:
                    // 이동 순서 바뀔 수 있음
                    double Position_Z = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.HANDLER_WORK_BLOCK_AVOID_POSITION_Z.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                    double Position_R = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.HANDLER_WORK_BLOCK_AVOID_POSITION_R.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

                    double dSpeed_Z = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.HANDLER_Z_MATERIAL_HANDLE_SPEED.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                    double dSpeed_R = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.HANDLER_R_MATERIAL_HANDLE_SPEED.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                
                    MOTION_RESULT enResultZ = MoveAbsolutely((int)EN_AXIS_LIST.HANDLER_Z,
                                 Position_Z,
                                 dSpeed_Z,
                                 MOTION_SPEED_CONTENT.RUN,
                                 100,
                                 0,
                                 true);
                    MOTION_RESULT enResultR = MoveAbsolutely((int)EN_AXIS_LIST.HANDLER_R,
                                    Position_R,
                                    dSpeed_R,
                                    MOTION_SPEED_CONTENT.RUN,
                                    100,
                                    0,
                                    true);

                    if (enResultZ == MOTION_RESULT.OK
                        && enResultR == MOTION_RESULT.OK)
                        m_nSeqNum = (int)EN_MOVE_STEP.ACTION_FINISH;

                    if (GetSequenceTime() > m_nInterlockTimeOut)
                    {
                        m_arAlarmSubInfo[0] = "HANDLER MOVE FAIL";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.INTERLOCK_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_enRecoveryAction = m_enAction;
                        m_nRecoveryStep = m_nSeqNum;
                        m_nSeqNum = (int)EN_MOVE_STEP.FINISH;
                        break;
                    }

                    break;
                #endregion

                #region ACTION_FINISH
                case (int)EN_MOVE_STEP.ACTION_FINISH:
                    m_nSeqNum = (int)EN_MOVE_STEP.FINISH;
                    break;
                #endregion

                #region FINISH
                case (int)EN_MOVE_STEP.FINISH:
                    return true;
                #endregion
            }
            return false;
        }
        #endregion

        #endregion Action Sequence List

        #region Condition
        #region Loading
        private EN_CONDITION_RESULT PortFinalconditionEquipmentLoading()
        {
            if (CheckPreSmema(true))
            {
                return EN_CONDITION_RESULT.OK;
            }

            return EN_CONDITION_RESULT.NG;
        }

      
        #endregion

        #region Unloading
  
        #endregion
        #endregion

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
                case DynamicLink_.EN_PORT_STATUS.EXIST:
                    _DynamicLink.SetNodeState(GetTaskName(), EN_TASK_ACTION.EQUIPMENT_LOADING.ToString(), EN_ACTION_STATE.DONE);
                    break;

                case DynamicLink_.EN_PORT_STATUS.WORKING:
                    _DynamicLink.SetNodeState(GetTaskName(), EN_TASK_ACTION.EQUIPMENT_LOADING.ToString(), EN_ACTION_STATE.DONE);
                    _DynamicLink.SetNodeState(GetTaskName(), EN_TASK_ACTION.BLOCK_LOADING.ToString(), EN_ACTION_STATE.DONE);
                    break;

                case DynamicLink_.EN_PORT_STATUS.FINISHED:
                    _DynamicLink.SetNodeState(GetTaskName(), EN_TASK_ACTION.EQUIPMENT_LOADING.ToString(), EN_ACTION_STATE.DONE);
                    _DynamicLink.SetNodeState(GetTaskName(), EN_TASK_ACTION.BLOCK_LOADING.ToString(), EN_ACTION_STATE.DONE);
                    _DynamicLink.SetNodeState(GetTaskName(), EN_TASK_ACTION.BLOCK_UNLOADING.ToString(), EN_ACTION_STATE.DONE);
                    break;
            }
        }
        #endregion

        private bool CheckMaterialExistInHandler(ref double dCurrentVac)
        {
            int nAIIndex = (int)EN_ANALOG_INPUT_LIST.HANDLER_MATERIAL_VAC;
          
            double dThreshold = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.HANDLER_MATERIAL_VAC_THRESHOLD.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

            dCurrentVac = ReadAnalogInputValue(nAIIndex);
            return dThreshold > dCurrentVac;
        }

        private bool CheckMaterialExistInLift(ref double dCurrentVac)
        {
            int nAIIndex = (int)EN_ANALOG_INPUT_LIST.LIFT_MATERIAL_VAC;
          
            double dThreshold = m_Recipe.GetValue(EN_TASK_LIST.WORK_ZONE.ToString(), WORKZONE_TASK_PARAM.LIFT_MATERIAL_VAC_THRESHOLD.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

            dCurrentVac = ReadAnalogInputValue(nAIIndex);
            return dThreshold > dCurrentVac;
        }

        private bool CheckMaterialExistInBlock(ref double dCurrentVac)
         {
             int nAIIndex = (int)EN_ANALOG_INPUT_LIST.BLOCK_MATERIAL_VAC;

             double dThreshold = m_Recipe.GetValue(EN_TASK_LIST.WORK_ZONE.ToString(), WORKZONE_TASK_PARAM.BLOCK_MATERIAL_VAC_THRESHOLD.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

             dCurrentVac = ReadAnalogInputValue(nAIIndex);
             return dThreshold > dCurrentVac;
         }

        #region SMEMA
        private bool CheckPreSmema(bool bPulse, bool bSetPort = true)
        {
            bool bReturn = true;
            bool bUseSmeama = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, Recipe.PARAM_EQUIPMENT.INPUT_SMEMA_USED.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, true);
            int nPort = 1;
            if (bUseSmeama)
            {
                if (ReadInput((int)EN_DIGITAL_INPUT_LIST.PRE_SMEMA_PORT1, false) == bPulse)
                    nPort = 1;
                else if (ReadInput((int)EN_DIGITAL_INPUT_LIST.PRE_SMEMA_PORT2, false) == bPulse)
                    nPort = 2;
                else
                    bReturn = false;
            }
            if (bReturn && bSetPort && bPulse)
            {
                m_tRecovery.nInSmemaPort = nPort;
            }
            return bReturn;
        }

        private bool SetPreSmemaOutput(bool bSmemaOn)
        {
            bool bReturn = true;
            bool bUseSmeama = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, Recipe.PARAM_EQUIPMENT.INPUT_SMEMA_USED.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, true);

            if (bUseSmeama)
            {
                switch (m_tRecovery.nInSmemaPort)
                {
                    case 1:
                        WriteOutput((int)EN_DIGITAL_OUTPUT_LIST.PRE_SMEMA_PORT_1, bSmemaOn);
                        WriteOutput((int)EN_DIGITAL_OUTPUT_LIST.PRE_SMEMA_PORT_2, false);
                        break;
                    case 2:
                        WriteOutput((int)EN_DIGITAL_OUTPUT_LIST.PRE_SMEMA_PORT_1, false);
                        WriteOutput((int)EN_DIGITAL_OUTPUT_LIST.PRE_SMEMA_PORT_2, bSmemaOn);
                        break;
                }
            }
            return bReturn;
        }

        private bool CheckPreSmemaSub(bool bPulse)
        {
            bool bUseSmeama = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, Recipe.PARAM_EQUIPMENT.INPUT_SMEMA_USED.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, true);

            if (bUseSmeama)
            {
                switch (m_tRecovery.nInSmemaPort)
                {
                    case 1:
                        return ReadInput((int)EN_DIGITAL_INPUT_LIST.PRE_SMEMA_SUB_PORT1, false) == bPulse;
                    case 2:
                        return ReadInput((int)EN_DIGITAL_INPUT_LIST.PRE_SMEMA_SUB_PORT2, false) == bPulse;
                }

                return false;
            }
            return true;
        }

        private bool SetPreSmemaSubOutput(bool bSmemaOn)
        {
            bool bReturn = true;
            bool bUseSmeama = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, Recipe.PARAM_EQUIPMENT.INPUT_SMEMA_USED.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, true);

            if (bUseSmeama)
            {
                switch (m_tRecovery.nInSmemaPort)
                {
                    case 1:
                        WriteOutput((int)EN_DIGITAL_OUTPUT_LIST.PRE_SMEMA_SUB_PORT_1, bSmemaOn);
                        WriteOutput((int)EN_DIGITAL_OUTPUT_LIST.PRE_SMEMA_SUB_PORT_2, false);
                        break;
                    case 2:
                        WriteOutput((int)EN_DIGITAL_OUTPUT_LIST.PRE_SMEMA_SUB_PORT_1, false);
                        WriteOutput((int)EN_DIGITAL_OUTPUT_LIST.PRE_SMEMA_SUB_PORT_2, bSmemaOn);
                        break;
                }
            }
            return bReturn;
        }
        #endregion

        #region post office
        protected bool CheckMail(EN_MAIL title)
        {
            return _postOffice.CheckMail(_mySubscriberName, title);
        }
        protected bool CheckMail(EN_SUBSCRIBER sender, EN_MAIL title)
        {
            return _postOffice.CheckMail(_mySubscriberName, sender, title);
        }
        protected bool SendMail(EN_SUBSCRIBER receiver, EN_MAIL title, params object[] content)
        {
            return _postOffice.SendMail(_mySubscriberName, receiver, title, content);
        }
        protected List<Mail> GetMail(EN_MAIL title)
        {
            List<Mail> result;
            if (false == _postOffice.GetMail(_mySubscriberName, title, out result))
                return null;

            return result;
        }
        protected List<Mail> GetMail(EN_SUBSCRIBER sender, EN_MAIL title)
        {
            List<Mail> result;
            if (false == _postOffice.GetMail(_mySubscriberName, sender, title, out result))
                return null;

            return result;
        }
        #endregion /post office

        #region Ionizer
        private void IonizerTriggerOnOff(bool bOnOff)
        {
            int nIonizeerTriggerIndex = 10;
            Config.ConfigTrigger.GetInstance().SetParameter(nIonizeerTriggerIndex, Config.ConfigTrigger.EN_PARAM_TRIGGER.ENABLE, bOnOff);
        }
        private void IonizerInterluptOnOff(bool bOnOff)
        {
            bool bIonizerInterluptEnable = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.IONIZER_INTERLUPT_ENABLE.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, true);
            if (false == bIonizerInterluptEnable && bOnOff)
                return;

            int nIonizeerInteruptIndex = 28;
            Config.ConfigInterrupt.GetInstance().SetParameter(nIonizeerInteruptIndex, Config.ConfigInterrupt.EN_PARAM_INTERRUPT.ENABLE, bOnOff);
        }
        #endregion /Ionizer

        #region TransferTest
        bool m_bTransferTest = false;
        DateTime teststarttime = DateTime.Now;
        DateTime loadingstarttime = DateTime.Now;
        int nTestRepeatIndex = 0;

        private void StartTransferTest()
        {
            m_bTransferTest = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.TRANSFER_TEST.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, false);

            teststarttime = DateTime.Now;
            nTestRepeatIndex = 0;
        }

        private void WriteTranferTestLog()
        {
            if (m_bTransferTest == false)
                return;
            nTestRepeatIndex++;
            string strFolderName = "TRANSFER TEST";
            string strFileName = "TEST";
            strFileName += String.Format("_{0:0000}{1:00}{2:00}{3:00}{4:00}",
                       teststarttime.Year,
                       teststarttime.Month,
                       teststarttime.Day,
                       teststarttime.Hour,
                       teststarttime.Minute);


            string strFolderPath = string.Format("{0}\\{1}", Define.DefineConstant.FilePath.FILEPATH_TEST_LOG, strFolderName);

            string strFileFullPath = string.Format("{0}\\{1}{2}", strFolderPath, strFileName, Define.DefineConstant.FileFormat.FILEFORMAT_CSV);

            if (false == Directory.Exists(strFolderPath))
            {
                Directory.CreateDirectory(strFolderPath);
            }

            bool bFileExist = File.Exists(strFileFullPath);

            List<string> Temps = new List<string>();

            using (FileStream fstream = new FileStream(strFileFullPath, FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter swriter = new StreamWriter(fstream, Encoding.UTF8))
                {

                    string strData;

                    if (!bFileExist)
                    {
                        strData = "INDEX, LOADING START TIME, ULOADING END TIME";

                        swriter.WriteLine(strData);
                    }

                    strData = string.Format("{0},{1},{2}", nTestRepeatIndex, loadingstarttime, DateTime.Now);

                    swriter.WriteLine(strData);

                    swriter.Close();
                }
                fstream.Close();
            }
        }
        

        #endregion

        #endregion

        #region External Interface
        public override void ClearMaterial()
        {
            _DynamicLink.SetPortStatus(GetTaskName(), EN_PORT_LIST.WORK_PORT.ToString(), DynamicLink_.EN_PORT_STATUS.EMPTY);
            m_enRecoveryAction = EN_TASK_ACTION.STOP;
            m_nRecoveryStep = 0;
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
        private enum EN_LOADING_STEP
        {
            ACTION_START = 0,

            MOVE_LOADING = 1000,

            LOADING = 2000,

            ACTION_FINISH = 9900,
            FINISH = 10000,
        }

        private enum EN_UNLOADING_STEP
        {
            ACTION_START = 0,

            MOVE_UNLOADING = 1000,

            UNLOADING = 2000,

            ACTION_FINISH = 9900,
            FINISH = 10000,
        }

        private enum EN_MOVE_STEP
        {
            ACTION_START = 0,

            MOVE = 1000,

            ACTION_FINISH = 9900,
            FINISH = 10000,
        }
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
        class TransferRecovery : RecoveryData
        {
            #region 변수
            private string m_strID = "";
            private int m_nInSmemaPort = 0;
            private int m_nOutSmemaPort = 0;
            #endregion

            #region 속성
            public string strID { set { m_strID = value; } get { return m_strID; } }
            public int nInSmemaPort { set { m_nInSmemaPort = value; } get { return m_nInSmemaPort; } }
            public int nOutSmemaPort { set { m_nOutSmemaPort = value; } get { return m_nOutSmemaPort; } }
            #endregion

            #region 생성자
            public TransferRecovery(string sTaskName, int nPortCount)
                : base(sTaskName, nPortCount)
            {
            }
            #endregion

            #region SAVE
            protected override void SaveData(ref FileComposite fComp, string sRootName)
            {
                fComp.SetValue(sRootName, "ID", m_strID);
                fComp.SetValue(sRootName, "InSmemaPort", m_nInSmemaPort.ToString());
                fComp.SetValue(sRootName, "OutSmemaPort", m_nOutSmemaPort.ToString());
            }
            #endregion

            #region LOAD
            protected override void LoadData(ref FileComposite fComp, string sRootName)
            {
                fComp.GetValue(sRootName, "ID", ref m_strID);
                fComp.GetValue(sRootName, "InSmemaPort", ref m_nInSmemaPort);
                fComp.GetValue(sRootName, "OutSmemaPort", ref m_nOutSmemaPort);
            }
            #endregion
        }
        #endregion
    }
}
