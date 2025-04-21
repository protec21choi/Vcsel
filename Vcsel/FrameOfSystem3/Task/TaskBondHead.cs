using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RunningTask_;
using TaskAction_;
using Motion_;
using Cylinder_;

using FrameOfSystem3.Log;

using Define.DefineEnumBase.Log;
using Define.DefineEnumProject.Task;
using Define.DefineEnumProject.Task.BondHead;
using Define.DefineEnumProject.Vision;
using Define.DefineEnumProject.SubSequence;
using Define.DefineEnumProject.SubSequence.Laser;
using Define.DefineEnumProject.Laser;
using Define.DefineEnumProject.Tool;

using EquipmentState_;
using FrameOfSystem3.Recipe;
using FrameOfSystem3.Work;
using FrameOfSystem3.DynamicLink_;
using FrameOfSystem3.SubSequence;
using FrameOfSystem3.SubSequence.SubLaserWork;
using FrameOfSystem3.Functional;

using FileComposite_;
using FrameOfSystem3.Views.Functional;
using FrameOfSystem3.ExternalDevice.Serial;
using FrameOfSystem3.Laser;

using Define.DefineEnumProject.Mail;

using FrameOfSystem3.ExternalDevice;

namespace FrameOfSystem3.Task
{
    class TaskBondHead : RunningTaskEx
    {
        #region Constructor
        public TaskBondHead(int nIndexOfTask, string strTaskName)
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

            _DynamicLink = DynamicLink.GetInstance();
            m_instanceTaskInformation = FrameOfSystem3.Config.ConfigTask.GetInstance();
            m_instanceLog = LogManager.GetInstance();

            // 2020.01.27 by twkang [ADD] Vision Sub Action 추가, 데이터 저장 Log 인스턴스 추가

            // 2020.11.27 by jhchoo [ADD] Recovery 객체 생성
            int nPortCount = 1;
            m_tRecovery = new TaskBondHeadRecovery(strTaskName, nPortCount);

            RecoveryData tRecovery = m_tRecovery as RecoveryData;

            Enum.TryParse(strTaskName, out m_enTaskName);
            m_instanceOperator.AddRecoveryData(m_enTaskName, ref tRecovery);

            InitialzeLaserWorkTool();


            _mySubscriberName = EN_SUBSCRIBER.TASK_BONDHEAD;

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

        static FrameOfSystem3.Config.ConfigTask m_instanceTaskInformation = null;

        // 2020.12.05 by jhchoo [ADD] TaskOperator 인스턴스
        private TaskOperator m_instanceOperator = TaskOperator.GetInstance();

        private Form_ProgressBar m_instanceProgress = Form_ProgressBar.GetInstance();

        private Recipe.Recipe m_Recipe = Recipe.Recipe.GetInstance();

        Laser.ProtecLaserMananger m_Laser = Laser.ProtecLaserMananger.GetInstance();
        Laser.ProtecLaserMananger_2 m_Laser_2 = Laser.ProtecLaserMananger_2.GetInstance();

        //#region IR
        //private ExternalDevice.Socket.IR m_instanceIR = ExternalDevice.Socket.IR.GetInstance();
        //private ExternalDevice.Socket.IR_Property.Enumerable.EN_COMMUNICATION_RESULT m_enIRResult = ExternalDevice.Socket.IR_Property.Enumerable.EN_COMMUNICATION_RESULT.SUCCESS;
        //#endregion

        #endregion

        #region Action
        private EN_TASK_ACTION m_enAction = EN_TASK_ACTION.STOP;

        private Dictionary<string, EN_TASK_ACTION> m_mapppingForAction = new Dictionary<string, EN_TASK_ACTION>();
        private string m_strTargetSignal = string.Empty;
        private bool m_bLaserOutputStarted = false;
        private bool m_bLaserOutputOn = false;
        private int m_nLaserOutputCount = 0;
        private int m_nLaserOnDelay = 0;
        private int m_nLaserOffDelay = 0;
        private int m_nLaserRepeatCount = 0;
        #endregion

        #region Collections
        private Dictionary<EN_AXIS_LIST, string> m_dicofMoveAxisTarget = new Dictionary<EN_AXIS_LIST, string>();
        private Dictionary<EN_AXIS_LIST, double> m_dicofMoveAxisPitch = new Dictionary<EN_AXIS_LIST, double>();
        #endregion

        #region Time out / Tickcounter
        private TickCounter_.TickCounter m_tickofDelaySequence = new TickCounter_.TickCounter();
        private TickCounter_.TickCounter m_tickTimeCheck = new TickCounter_.TickCounter();
        private TickCounter_.TickCounter m_TickForDelay = new TickCounter_.TickCounter();
        private TickCounter_.TickCounter m_tickTimeOut = new TickCounter_.TickCounter();
        private TickCounter_.TickCounter m_tickForFFU = new TickCounter_.TickCounter();
        private TickCounter_.TickCounter m_tickLaserOutput = new TickCounter_.TickCounter();
        #endregion

        #region VisionInspection
        //private Vision_.VISION_DATA m_VisionData = null;
        #endregion

        #region Manual Action Used

        #region Vision Calibration
        //private int m_nDLCGageRNRCount = 0;
        //private int m_nULCGageRNRCount = 0;
        //private Vision_.VISION_RESULT m_clCalibrationDistance		= new Vision_.VISION_RESULT();
        //private Vision_.VISION_RESULT m_clCalibrationULCDistance	= new Vision_.VISION_RESULT();

        //private EN_CAMERA_LIST m_enSelectedCalibrationCamera = EN_CAMERA_LIST.BOND_HEAD_DLC_CAMERA;
        //private EN_RESULT_LIST m_enCalibrationResult = EN_RESULT_LIST.RECEIVE_DATA;
        #endregion

        #region Vision Result Offset
        private DPointXY m_dblptDistanceOffset = new DPointXY(0, 0);
        #endregion

        #endregion

        #region Recovery
        // 2020.11.27 by jhchoo [ADD] Recovery 객체 선언
        private TaskBondHeadRecovery m_tRecovery = null;
        #endregion

        #region Alram Sub Information
        private string m_strAlarmSubInfo = string.Empty;
        private string[] m_arAlarmSubInfo = new string[] { "", "" };
        private int m_nAlarmSubNumber = -1;
        #endregion

        #region PowerMeasure
        private int m_nPowerMeasureCurrentRepeatCount = 0;
        #region Calibration
        private int m_nCalibrationChannel = 0;

        private int m_nCalibrationCurrentStep = 0;
        private int m_nCalibrationStep = 1;
        private double[] m_arCalibrationStepVolt = new double[0];

        private int m_nCalChannelAnalogInput = 0;
        private List<double> m_lstCurrentVolt = new List<double>();
        private TickCounter_.TickCounter m_tickForPowerMeasureRest = new TickCounter_.TickCounter();
        private TickCounter_.TickCounter m_tickForSerialCommunication = new TickCounter_.TickCounter();
        #endregion
        #endregion

        #region SubSequence
        SubSeqLaserWork m_Subseq_Laser_Work = null;
        SubSeqLaserWork m_Subseq_Laser_Work_2 = null;
        #endregion /SubSequence

        private int m_nRunRatio = 100;


        PostOffice _postOffice = null;
        readonly EN_SUBSCRIBER _mySubscriberName;

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
            //FFU_Monitoring();

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
                    
                    m_nSeqNum = (int)EN_INITIALIZE_STEP.END;
                    break;

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
                case EN_TASK_ACTION.LASER_WORK:
                    if (ActionLaserWork())
                        return true;
                    break;

                case EN_TASK_ACTION.LASER_WORK_2:
                    //if (ActionLaserWork_2())
                        return true;
                    break;

                case EN_TASK_ACTION.MEASURE_POWER:
                case EN_TASK_ACTION.MEASURE_VOLT:
                case EN_TASK_ACTION.CALIBRATION_CHANNEL_POWER:
                case EN_TASK_ACTION.CALIBRATION_POWER_LOSS_RATE:
                    if (Action_PowerMeasure())
                        return true;
                    break;

                case EN_TASK_ACTION.MEASURE_POWER_2:
                case EN_TASK_ACTION.MEASURE_VOLT_2:
                case EN_TASK_ACTION.CALIBRATION_CHANNEL_POWER_2:
                case EN_TASK_ACTION.CALIBRATION_POWER_LOSS_RATE_2:
                    if (Action_PowerMeasure_2())
                        return true;
                    break;

                case EN_TASK_ACTION.SHORT_TEST:
                    if (ActionShortCheck())
                        return true;
                    break;

                case EN_TASK_ACTION.SHORT_TEST_2:
                    if (ActionShortCheck_2())
                        return true;
                    break;

                //case EN_TASK_ACTION.MOVE_READY:
                //    //if (ActionMoveReady())
                //    //    return true;
                //    break;
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
                case EN_TASK_ACTION.LASER_WORK:
                    if (ActionLaserWork())
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
                    //m_instanceIR.ManualCommand(ExternalDevice.Socket.IR_Property.Enumerable.EN_SEND_TYPE.RUN_STOP);
                    //m_instanceOperator.MainVacControl(false);
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
                    WorkLog.GetInstance().SaveStop();

                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_ON_PORT_1, false);
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_ON_PORT_2, false);
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_ON_PORT_3, false);

                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_READY_PORT_1, false);
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_READY_PORT_2, false);
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_READY_PORT_3, false);

                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_2_ON_PORT_1, false);
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_2_ON_PORT_2, false);
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_2_ON_PORT_3, false);

                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_2_READY_PORT_1, false);
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_2_READY_PORT_2, false);
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_2_READY_PORT_3, false);

                    //m_instanceIR.ManualCommand(ExternalDevice.Socket.IR_Property.Enumerable.EN_SEND_TYPE.WORK_END);
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
                    //m_instanceIR.ManualCommand(ExternalDevice.Socket.IR_Property.Enumerable.EN_SEND_TYPE.RUN_STOP);
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
                    WorkLog.GetInstance().SaveStop();
                    // 2025.4.3 by ecchoi [ADD] Test 후 복구
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_ON_PORT_1, false);
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_ON_PORT_2, false);
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_ON_PORT_3, false);

                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_READY_PORT_1, false);
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_READY_PORT_2, false);
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_READY_PORT_3, false);

                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_EMO_PORT_1, true);
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_EMO_PORT_2, true);
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_EMO_PORT_3, true);
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_MONITOR_EMO, true);

                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_2_ON_PORT_1, false);
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_2_ON_PORT_2, false);
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_2_ON_PORT_3, false);

                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_2_READY_PORT_1, false);
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_2_READY_PORT_2, false);
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_2_READY_PORT_3, false);

                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_2_EMO_PORT_1, true);
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_2_EMO_PORT_2, true);
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_2_EMO_PORT_3, true);
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_2_MONITOR_EMO, true);

                    //m_instanceIR.ManualCommand(ExternalDevice.Socket.IR_Property.Enumerable.EN_SEND_TYPE.WORK_END);
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
                    //m_instanceIR.ManualCommand(ExternalDevice.Socket.IR_Property.Enumerable.EN_SEND_TYPE.RUN_STOP);
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
            //             #region Laser Bonding
            //             _DynamicLink.SetFlowPrecondition(GetTaskName(), EN_TASK_ACTION.LASER_WORK.ToString(), PreconditionLaserBonding);
            //             _DynamicLink.SetFlowPostcondition(GetTaskName(), EN_TASK_ACTION.LASER_WORK.ToString(), PostconditionLaserBonding);
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
            #region Laser #1 Total

            #region Device
            ASubControl[] arCtrlLaserDevice = new ASubControl[3];

            ASubControl SubCtrlLaserDevice = new SubCtrlDeviceProtecLaser(this as RunningTaskEx);

            SubCtrlLaserDevice.SetTargetDigitalOutput((int)SubSequence.SubLaserWork.ProtecDeviceControl.EN_DIGITAL_OUTPUT.RESET
                                                    , (int)EN_DIGITAL_OUTPUT_LIST.LD_ALARM_CLEAR_PORT_1);
            SubCtrlLaserDevice.SetTargetDigitalOutput((int)SubSequence.SubLaserWork.ProtecDeviceControl.EN_DIGITAL_OUTPUT.READY
                                                    , (int)EN_DIGITAL_OUTPUT_LIST.LD_READY_PORT_1);
            SubCtrlLaserDevice.SetTargetDigitalOutput((int)SubSequence.SubLaserWork.ProtecDeviceControl.EN_DIGITAL_OUTPUT.ON
                                                    , (int)EN_DIGITAL_OUTPUT_LIST.LD_ON_PORT_1);
            SubCtrlLaserDevice.SetTargetDigitalOutput((int)SubSequence.SubLaserWork.ProtecDeviceControl.EN_DIGITAL_OUTPUT.EMO
                                                    , (int)EN_DIGITAL_OUTPUT_LIST.LD_MONITOR_EMO);

            SubCtrlLaserDevice.SetTargetDigitalInput((int)SubSequence.SubLaserWork.ProtecDeviceControl.EN_DIGITAL_INPUT.ALARM
                                                   , (int)EN_DIGITAL_INPUT_LIST.LD_ALARM_PORT_1);
            SubCtrlLaserDevice.SetTargetDigitalInput((int)SubSequence.SubLaserWork.ProtecDeviceControl.EN_DIGITAL_INPUT.ON
                                                  , (int)EN_DIGITAL_INPUT_LIST.LD_ON_PORT_1);
            SubCtrlLaserDevice.SetTargetDigitalInput((int)SubSequence.SubLaserWork.ProtecDeviceControl.EN_DIGITAL_INPUT.READY
                                                  , (int)EN_DIGITAL_INPUT_LIST.LD_READY_PORT_1);
            
            arCtrlLaserDevice[0] = SubCtrlLaserDevice;


            SubCtrlLaserDevice = new SubCtrlDeviceProtecLaser(this as RunningTaskEx);

            SubCtrlLaserDevice.SetTargetDigitalOutput((int)SubSequence.SubLaserWork.ProtecDeviceControl.EN_DIGITAL_OUTPUT.RESET
                                                    , (int)EN_DIGITAL_OUTPUT_LIST.LD_ALARM_CLEAR_PORT_2);
            SubCtrlLaserDevice.SetTargetDigitalOutput((int)SubSequence.SubLaserWork.ProtecDeviceControl.EN_DIGITAL_OUTPUT.READY
                                                    , (int)EN_DIGITAL_OUTPUT_LIST.LD_READY_PORT_2);
            SubCtrlLaserDevice.SetTargetDigitalOutput((int)SubSequence.SubLaserWork.ProtecDeviceControl.EN_DIGITAL_OUTPUT.ON
                                                    , (int)EN_DIGITAL_OUTPUT_LIST.LD_ON_PORT_2);
            SubCtrlLaserDevice.SetTargetDigitalOutput((int)SubSequence.SubLaserWork.ProtecDeviceControl.EN_DIGITAL_OUTPUT.EMO
                                                    , (int)EN_DIGITAL_OUTPUT_LIST.LD_MONITOR_EMO);

            SubCtrlLaserDevice.SetTargetDigitalInput((int)SubSequence.SubLaserWork.ProtecDeviceControl.EN_DIGITAL_INPUT.ALARM
                                                   , (int)EN_DIGITAL_INPUT_LIST.LD_ALARM_PORT_2);
            SubCtrlLaserDevice.SetTargetDigitalInput((int)SubSequence.SubLaserWork.ProtecDeviceControl.EN_DIGITAL_INPUT.ON
                                                  , (int)EN_DIGITAL_INPUT_LIST.LD_ON_PORT_2);
            SubCtrlLaserDevice.SetTargetDigitalInput((int)SubSequence.SubLaserWork.ProtecDeviceControl.EN_DIGITAL_INPUT.READY
                                                  , (int)EN_DIGITAL_INPUT_LIST.LD_READY_PORT_2);

            

            arCtrlLaserDevice[1] = SubCtrlLaserDevice;


            SubCtrlLaserDevice = new SubCtrlDeviceProtecLaser(this as RunningTaskEx);

            SubCtrlLaserDevice.SetTargetDigitalOutput((int)SubSequence.SubLaserWork.ProtecDeviceControl.EN_DIGITAL_OUTPUT.RESET
                                                    , (int)EN_DIGITAL_OUTPUT_LIST.LD_ALARM_CLEAR_PORT_3);
            SubCtrlLaserDevice.SetTargetDigitalOutput((int)SubSequence.SubLaserWork.ProtecDeviceControl.EN_DIGITAL_OUTPUT.READY
                                                    , (int)EN_DIGITAL_OUTPUT_LIST.LD_READY_PORT_3);
            SubCtrlLaserDevice.SetTargetDigitalOutput((int)SubSequence.SubLaserWork.ProtecDeviceControl.EN_DIGITAL_OUTPUT.ON
                                                    , (int)EN_DIGITAL_OUTPUT_LIST.LD_ON_PORT_3);
            SubCtrlLaserDevice.SetTargetDigitalOutput((int)SubSequence.SubLaserWork.ProtecDeviceControl.EN_DIGITAL_OUTPUT.EMO
                                                    , (int)EN_DIGITAL_OUTPUT_LIST.LD_MONITOR_EMO);

            SubCtrlLaserDevice.SetTargetDigitalInput((int)SubSequence.SubLaserWork.ProtecDeviceControl.EN_DIGITAL_INPUT.ALARM
                                                   , (int)EN_DIGITAL_INPUT_LIST.LD_ALARM_PORT_3);
            SubCtrlLaserDevice.SetTargetDigitalInput((int)SubSequence.SubLaserWork.ProtecDeviceControl.EN_DIGITAL_INPUT.ON
                                                  , (int)EN_DIGITAL_INPUT_LIST.LD_ON_PORT_3);
            SubCtrlLaserDevice.SetTargetDigitalInput((int)SubSequence.SubLaserWork.ProtecDeviceControl.EN_DIGITAL_INPUT.READY
                                                  , (int)EN_DIGITAL_INPUT_LIST.LD_READY_PORT_3);

            

            arCtrlLaserDevice[2] = SubCtrlLaserDevice;
            #endregion

            #region Analog OutPut
            ASubControl[,] arSubCtrlOutputProfile = new ASubControl[3, 1];

            ASubControl SubCtrlOutputProfile = new SubCtrlOutputProfileProtecLaser(this as RunningTaskEx);

            SubCtrlOutputProfile.SetTargetDigitalOutput((int)SubSequence.SubLaserWork.ProtecLaserOutputProfile.EN_DIGITAL_OUTPUT.RESET
                                                  , (int)EN_DIGITAL_OUTPUT_LIST.LD_ALARM_CLEAR_PORT_1);
            SubCtrlOutputProfile.SetTargetDigitalOutput((int)SubSequence.SubLaserWork.ProtecLaserOutputProfile.EN_DIGITAL_OUTPUT.READY
                                                    , (int)EN_DIGITAL_OUTPUT_LIST.LD_READY_PORT_1);
            SubCtrlOutputProfile.SetTargetDigitalOutput((int)SubSequence.SubLaserWork.ProtecLaserOutputProfile.EN_DIGITAL_OUTPUT.ON
                                                    , (int)EN_DIGITAL_OUTPUT_LIST.LD_ON_PORT_1);
            SubCtrlOutputProfile.SetTargetDigitalOutput((int)SubSequence.SubLaserWork.ProtecLaserOutputProfile.EN_DIGITAL_OUTPUT.EMO
                                                    , (int)EN_DIGITAL_OUTPUT_LIST.LD_MONITOR_EMO);

            SubCtrlOutputProfile.SetTargetDigitalInput((int)SubSequence.SubLaserWork.ProtecLaserOutputProfile.EN_DIGITAL_INPUT.ALARM
                                                   , (int)EN_DIGITAL_INPUT_LIST.LD_ALARM_PORT_1);
            SubCtrlOutputProfile.SetTargetDigitalInput((int)SubSequence.SubLaserWork.ProtecLaserOutputProfile.EN_DIGITAL_INPUT.ON
                                                  , (int)EN_DIGITAL_INPUT_LIST.LD_ON_PORT_1);
            SubCtrlOutputProfile.SetTargetDigitalInput((int)SubSequence.SubLaserWork.ProtecLaserOutputProfile.EN_DIGITAL_INPUT.READY
                                                  , (int)EN_DIGITAL_INPUT_LIST.LD_READY_PORT_1);

            SubCtrlOutputProfile.SetTargetDigitalInput((int)SubSequence.SubLaserWork.ProtecLaserOutputProfile.EN_SERIAL.COTNROL
                                                  , (int)Define.DefineEnumProject.Serial.EN_SERIAL_INDEX.LD_CONTROL_1);

            

            arSubCtrlOutputProfile[0, 0] = SubCtrlOutputProfile;

            SubCtrlOutputProfile = new SubCtrlOutputProfileProtecLaser(this as RunningTaskEx);

            SubCtrlOutputProfile.SetTargetDigitalOutput((int)SubSequence.SubLaserWork.ProtecLaserOutputProfile.EN_DIGITAL_OUTPUT.RESET
                                                  , (int)EN_DIGITAL_OUTPUT_LIST.LD_ALARM_CLEAR_PORT_2);
            SubCtrlOutputProfile.SetTargetDigitalOutput((int)SubSequence.SubLaserWork.ProtecLaserOutputProfile.EN_DIGITAL_OUTPUT.READY
                                                    , (int)EN_DIGITAL_OUTPUT_LIST.LD_READY_PORT_2);
            SubCtrlOutputProfile.SetTargetDigitalOutput((int)SubSequence.SubLaserWork.ProtecLaserOutputProfile.EN_DIGITAL_OUTPUT.ON
                                                    , (int)EN_DIGITAL_OUTPUT_LIST.LD_ON_PORT_2);
            SubCtrlOutputProfile.SetTargetDigitalOutput((int)SubSequence.SubLaserWork.ProtecLaserOutputProfile.EN_DIGITAL_OUTPUT.EMO
                                                    , (int)EN_DIGITAL_OUTPUT_LIST.LD_MONITOR_EMO);

            SubCtrlOutputProfile.SetTargetDigitalInput((int)SubSequence.SubLaserWork.ProtecLaserOutputProfile.EN_DIGITAL_INPUT.ALARM
                                                   , (int)EN_DIGITAL_INPUT_LIST.LD_ALARM_PORT_2);
            SubCtrlOutputProfile.SetTargetDigitalInput((int)SubSequence.SubLaserWork.ProtecLaserOutputProfile.EN_DIGITAL_INPUT.ON
                                                  , (int)EN_DIGITAL_INPUT_LIST.LD_ON_PORT_2);
            SubCtrlOutputProfile.SetTargetDigitalInput((int)SubSequence.SubLaserWork.ProtecLaserOutputProfile.EN_DIGITAL_INPUT.READY
                                                  , (int)EN_DIGITAL_INPUT_LIST.LD_READY_PORT_2);

            SubCtrlOutputProfile.SetTargetDigitalInput((int)SubSequence.SubLaserWork.ProtecLaserOutputProfile.EN_SERIAL.COTNROL
                                                  , (int)Define.DefineEnumProject.Serial.EN_SERIAL_INDEX.LD_CONTROL_2);

            

            arSubCtrlOutputProfile[1, 0] = SubCtrlOutputProfile;

            SubCtrlOutputProfile = new SubCtrlOutputProfileProtecLaser(this as RunningTaskEx);

            SubCtrlOutputProfile.SetTargetDigitalOutput((int)SubSequence.SubLaserWork.ProtecLaserOutputProfile.EN_DIGITAL_OUTPUT.RESET
                                                  , (int)EN_DIGITAL_OUTPUT_LIST.LD_ALARM_CLEAR_PORT_3);
            SubCtrlOutputProfile.SetTargetDigitalOutput((int)SubSequence.SubLaserWork.ProtecLaserOutputProfile.EN_DIGITAL_OUTPUT.READY
                                                    , (int)EN_DIGITAL_OUTPUT_LIST.LD_READY_PORT_3);
            SubCtrlOutputProfile.SetTargetDigitalOutput((int)SubSequence.SubLaserWork.ProtecLaserOutputProfile.EN_DIGITAL_OUTPUT.ON
                                                    , (int)EN_DIGITAL_OUTPUT_LIST.LD_ON_PORT_3);
            SubCtrlOutputProfile.SetTargetDigitalOutput((int)SubSequence.SubLaserWork.ProtecLaserOutputProfile.EN_DIGITAL_OUTPUT.EMO
                                                    , (int)EN_DIGITAL_OUTPUT_LIST.LD_MONITOR_EMO);

            SubCtrlOutputProfile.SetTargetDigitalInput((int)SubSequence.SubLaserWork.ProtecLaserOutputProfile.EN_DIGITAL_INPUT.ALARM
                                                   , (int)EN_DIGITAL_INPUT_LIST.LD_ALARM_PORT_3);
            SubCtrlOutputProfile.SetTargetDigitalInput((int)SubSequence.SubLaserWork.ProtecLaserOutputProfile.EN_DIGITAL_INPUT.ON
                                                  , (int)EN_DIGITAL_INPUT_LIST.LD_ON_PORT_3);
            SubCtrlOutputProfile.SetTargetDigitalInput((int)SubSequence.SubLaserWork.ProtecLaserOutputProfile.EN_DIGITAL_INPUT.READY
                                                  , (int)EN_DIGITAL_INPUT_LIST.LD_READY_PORT_3);

            SubCtrlOutputProfile.SetTargetDigitalInput((int)SubSequence.SubLaserWork.ProtecLaserOutputProfile.EN_SERIAL.COTNROL
                                                  , (int)Define.DefineEnumProject.Serial.EN_SERIAL_INDEX.LD_CONTROL_3);

            

            arSubCtrlOutputProfile[2, 0] = SubCtrlOutputProfile;

            #endregion

            m_Subseq_Laser_Work = new SubSeqLaserWork(arCtrlLaserDevice, arSubCtrlOutputProfile);
            

            #region Monitor
            ASubControl[] arCtrlMonitor = new ASubControl[20];


            ASubControl SubCtrlAnalogMonitor = new SubCtrlMonitoringAnalog(this as RunningTaskEx);


            SubCtrlAnalogMonitor.SetTargetAnalogInput((int)SubSequence.SubLaserWork.AnalogMonitor.EN_ANALOG_INPUT.POWER
                                     , (int)EN_ANALOG_INPUT_LIST.LD_POWER_1);
            //             SubCtrlAnalogMonitor.SetTargetAnalogInput((int)SubSequence.SubLaserWork.AnalogMonitor.EN_ANALOG_INPUT.TEMP
            //                                      , (int)EN_ANALOG_INPUT_LIST.TEMP_SENSOR_1);
            arCtrlMonitor[0] = SubCtrlAnalogMonitor;

            SubCtrlAnalogMonitor = new SubCtrlMonitoringAnalog(this as RunningTaskEx);

            SubCtrlAnalogMonitor.SetTargetAnalogInput((int)SubSequence.SubLaserWork.AnalogMonitor.EN_ANALOG_INPUT.POWER
                                     , (int)EN_ANALOG_INPUT_LIST.LD_POWER_2);
            //             SubCtrlAnalogMonitor.SetTargetAnalogInput((int)SubSequence.SubLaserWork.AnalogMonitor.EN_ANALOG_INPUT.TEMP
            //                                      , (int)EN_ANALOG_INPUT_LIST.TEMP_SENSOR_2);
            arCtrlMonitor[1] = SubCtrlAnalogMonitor;

            SubCtrlAnalogMonitor = new SubCtrlMonitoringAnalog(this as RunningTaskEx);

            SubCtrlAnalogMonitor.SetTargetAnalogInput((int)SubSequence.SubLaserWork.AnalogMonitor.EN_ANALOG_INPUT.POWER
                                      , (int)EN_ANALOG_INPUT_LIST.LD_POWER_3);
            //             SubCtrlAnalogMonitor.SetTargetAnalogInput((int)SubSequence.SubLaserWork.AnalogMonitor.EN_ANALOG_INPUT.TEMP
            //                                       , (int)EN_ANALOG_INPUT_LIST.TEMP_SENSOR_3);
            arCtrlMonitor[2] = SubCtrlAnalogMonitor;

            SubCtrlAnalogMonitor = new SubCtrlMonitoringAnalog(this as RunningTaskEx);

            SubCtrlAnalogMonitor.SetTargetAnalogInput((int)SubSequence.SubLaserWork.AnalogMonitor.EN_ANALOG_INPUT.POWER
                                      , (int)EN_ANALOG_INPUT_LIST.LD_POWER_4);
            //             SubCtrlAnalogMonitor.SetTargetAnalogInput((int)SubSequence.SubLaserWork.AnalogMonitor.EN_ANALOG_INPUT.TEMP
            //                                       , (int)EN_ANALOG_INPUT_LIST.TEMP_SENSOR_4);
            arCtrlMonitor[3] = SubCtrlAnalogMonitor;

            SubCtrlAnalogMonitor = new SubCtrlMonitoringAnalog(this as RunningTaskEx);

            SubCtrlAnalogMonitor.SetTargetAnalogInput((int)SubSequence.SubLaserWork.AnalogMonitor.EN_ANALOG_INPUT.POWER
                                      , (int)EN_ANALOG_INPUT_LIST.LD_POWER_5);
            //             SubCtrlAnalogMonitor.SetTargetAnalogInput((int)SubSequence.SubLaserWork.AnalogMonitor.EN_ANALOG_INPUT.TEMP
            //                                       , (int)EN_ANALOG_INPUT_LIST.TEMP_SENSOR_5);
            arCtrlMonitor[4] = SubCtrlAnalogMonitor;

            SubCtrlAnalogMonitor = new SubCtrlMonitoringAnalog(this as RunningTaskEx);

            SubCtrlAnalogMonitor.SetTargetAnalogInput((int)SubSequence.SubLaserWork.AnalogMonitor.EN_ANALOG_INPUT.POWER
                                      , (int)EN_ANALOG_INPUT_LIST.LD_POWER_6);
            arCtrlMonitor[5] = SubCtrlAnalogMonitor;

            SubCtrlAnalogMonitor = new SubCtrlMonitoringAnalog(this as RunningTaskEx);

            SubCtrlAnalogMonitor.SetTargetAnalogInput((int)SubSequence.SubLaserWork.AnalogMonitor.EN_ANALOG_INPUT.POWER
                                      , (int)EN_ANALOG_INPUT_LIST.LD_POWER_7);
            arCtrlMonitor[6] = SubCtrlAnalogMonitor;

            SubCtrlAnalogMonitor = new SubCtrlMonitoringAnalog(this as RunningTaskEx);

            SubCtrlAnalogMonitor.SetTargetAnalogInput((int)SubSequence.SubLaserWork.AnalogMonitor.EN_ANALOG_INPUT.POWER
                                      , (int)EN_ANALOG_INPUT_LIST.LD_POWER_8);
            arCtrlMonitor[7] = SubCtrlAnalogMonitor;

            SubCtrlAnalogMonitor = new SubCtrlMonitoringAnalog(this as RunningTaskEx);

            SubCtrlAnalogMonitor.SetTargetAnalogInput((int)SubSequence.SubLaserWork.AnalogMonitor.EN_ANALOG_INPUT.POWER
                                      , (int)EN_ANALOG_INPUT_LIST.LD_POWER_9);
            arCtrlMonitor[8] = SubCtrlAnalogMonitor;

            SubCtrlAnalogMonitor = new SubCtrlMonitoringAnalog(this as RunningTaskEx);

            SubCtrlAnalogMonitor.SetTargetAnalogInput((int)SubSequence.SubLaserWork.AnalogMonitor.EN_ANALOG_INPUT.POWER
                                      , (int)EN_ANALOG_INPUT_LIST.LD_POWER_10);
            arCtrlMonitor[9] = SubCtrlAnalogMonitor;

            SubCtrlAnalogMonitor = new SubCtrlMonitoringAnalog(this as RunningTaskEx);

            SubCtrlAnalogMonitor.SetTargetAnalogInput((int)SubSequence.SubLaserWork.AnalogMonitor.EN_ANALOG_INPUT.POWER
                                      , (int)EN_ANALOG_INPUT_LIST.LD_POWER_11);
            arCtrlMonitor[10] = SubCtrlAnalogMonitor;

            SubCtrlAnalogMonitor = new SubCtrlMonitoringAnalog(this as RunningTaskEx);

            SubCtrlAnalogMonitor.SetTargetAnalogInput((int)SubSequence.SubLaserWork.AnalogMonitor.EN_ANALOG_INPUT.POWER
                                      , (int)EN_ANALOG_INPUT_LIST.LD_POWER_12);
            arCtrlMonitor[11] = SubCtrlAnalogMonitor;

            SubCtrlAnalogMonitor = new SubCtrlMonitoringAnalog(this as RunningTaskEx);

            SubCtrlAnalogMonitor.SetTargetAnalogInput((int)SubSequence.SubLaserWork.AnalogMonitor.EN_ANALOG_INPUT.POWER
                                      , (int)EN_ANALOG_INPUT_LIST.LD_POWER_13);
            arCtrlMonitor[12] = SubCtrlAnalogMonitor;

            SubCtrlAnalogMonitor = new SubCtrlMonitoringAnalog(this as RunningTaskEx);

            SubCtrlAnalogMonitor.SetTargetAnalogInput((int)SubSequence.SubLaserWork.AnalogMonitor.EN_ANALOG_INPUT.POWER
                                      , (int)EN_ANALOG_INPUT_LIST.LD_POWER_14);
            arCtrlMonitor[13] = SubCtrlAnalogMonitor;

            SubCtrlAnalogMonitor = new SubCtrlMonitoringAnalog(this as RunningTaskEx);

            SubCtrlAnalogMonitor.SetTargetAnalogInput((int)SubSequence.SubLaserWork.AnalogMonitor.EN_ANALOG_INPUT.POWER
                                      , (int)EN_ANALOG_INPUT_LIST.LD_POWER_15);
            arCtrlMonitor[14] = SubCtrlAnalogMonitor;

            SubCtrlAnalogMonitor = new SubCtrlMonitoringAnalog(this as RunningTaskEx);

            SubCtrlAnalogMonitor.SetTargetAnalogInput((int)SubSequence.SubLaserWork.AnalogMonitor.EN_ANALOG_INPUT.POWER
                                      , (int)EN_ANALOG_INPUT_LIST.LD_POWER_16);
            arCtrlMonitor[15] = SubCtrlAnalogMonitor;

            SubCtrlAnalogMonitor = new SubCtrlMonitoringAnalog(this as RunningTaskEx);

            SubCtrlAnalogMonitor.SetTargetAnalogInput((int)SubSequence.SubLaserWork.AnalogMonitor.EN_ANALOG_INPUT.POWER
                                     , (int)EN_ANALOG_INPUT_LIST.LD_POWER_17);
            arCtrlMonitor[16] = SubCtrlAnalogMonitor;

            SubCtrlAnalogMonitor = new SubCtrlMonitoringAnalog(this as RunningTaskEx);

            SubCtrlAnalogMonitor.SetTargetAnalogInput((int)SubSequence.SubLaserWork.AnalogMonitor.EN_ANALOG_INPUT.POWER
                                     , (int)EN_ANALOG_INPUT_LIST.LD_POWER_18);
            arCtrlMonitor[17] = SubCtrlAnalogMonitor;

            SubCtrlMonitoringWorkLog SubCtrlWorkLogMonitor = new SubCtrlMonitoringWorkLog(this as RunningTaskEx);

            arCtrlMonitor[18] = SubCtrlWorkLogMonitor;

            SubCtrlMonitoringIR SubCtrlIRMonitor = new SubCtrlMonitoringIR(this as RunningTaskEx);

            arCtrlMonitor[19] = SubCtrlIRMonitor;

            
            m_Subseq_Laser_Work.AddMonitorControl(arCtrlMonitor);

            #endregion

            #endregion /Laser #1 Total

            #region Laser#2 Total

            #region Device Laser #2

            ASubControl[] arCtrlLaserDevice_2 = new ASubControl[3];

            ASubControl SubCtrlLaserDevice_2 = new SubCtrlDeviceProtecLaser(this as RunningTaskEx);

            SubCtrlLaserDevice_2.SetTargetDigitalOutput((int)SubSequence.SubLaserWork.ProtecDeviceControl.EN_DIGITAL_OUTPUT.RESET
                                                    , (int)EN_DIGITAL_OUTPUT_LIST.LD_2_ALARM_CLEAR_PORT_1);
            SubCtrlLaserDevice_2.SetTargetDigitalOutput((int)SubSequence.SubLaserWork.ProtecDeviceControl.EN_DIGITAL_OUTPUT.READY
                                                    , (int)EN_DIGITAL_OUTPUT_LIST.LD_2_READY_PORT_1);
            SubCtrlLaserDevice_2.SetTargetDigitalOutput((int)SubSequence.SubLaserWork.ProtecDeviceControl.EN_DIGITAL_OUTPUT.ON
                                                    , (int)EN_DIGITAL_OUTPUT_LIST.LD_2_ON_PORT_1);
            SubCtrlLaserDevice_2.SetTargetDigitalOutput((int)SubSequence.SubLaserWork.ProtecDeviceControl.EN_DIGITAL_OUTPUT.EMO
                                                    , (int)EN_DIGITAL_OUTPUT_LIST.LD_2_MONITOR_EMO);

            SubCtrlLaserDevice_2.SetTargetDigitalInput((int)SubSequence.SubLaserWork.ProtecDeviceControl.EN_DIGITAL_INPUT.ALARM
                                                   , (int)EN_DIGITAL_INPUT_LIST.LD_2_ALARM_PORT_1);
            SubCtrlLaserDevice_2.SetTargetDigitalInput((int)SubSequence.SubLaserWork.ProtecDeviceControl.EN_DIGITAL_INPUT.ON
                                                  , (int)EN_DIGITAL_INPUT_LIST.LD_2_ON_PORT_1);
            SubCtrlLaserDevice_2.SetTargetDigitalInput((int)SubSequence.SubLaserWork.ProtecDeviceControl.EN_DIGITAL_INPUT.READY
                                                  , (int)EN_DIGITAL_INPUT_LIST.LD_2_READY_PORT_1);
            
            arCtrlLaserDevice_2[0] = SubCtrlLaserDevice_2;


            SubCtrlLaserDevice_2 = new SubCtrlDeviceProtecLaser(this as RunningTaskEx);

            SubCtrlLaserDevice_2.SetTargetDigitalOutput((int)SubSequence.SubLaserWork.ProtecDeviceControl.EN_DIGITAL_OUTPUT.RESET
                                                    , (int)EN_DIGITAL_OUTPUT_LIST.LD_2_ALARM_CLEAR_PORT_2);
            SubCtrlLaserDevice_2.SetTargetDigitalOutput((int)SubSequence.SubLaserWork.ProtecDeviceControl.EN_DIGITAL_OUTPUT.READY
                                                    , (int)EN_DIGITAL_OUTPUT_LIST.LD_2_READY_PORT_2);
            SubCtrlLaserDevice_2.SetTargetDigitalOutput((int)SubSequence.SubLaserWork.ProtecDeviceControl.EN_DIGITAL_OUTPUT.ON
                                                    , (int)EN_DIGITAL_OUTPUT_LIST.LD_2_ON_PORT_2);
            SubCtrlLaserDevice_2.SetTargetDigitalOutput((int)SubSequence.SubLaserWork.ProtecDeviceControl.EN_DIGITAL_OUTPUT.EMO
                                                    , (int)EN_DIGITAL_OUTPUT_LIST.LD_2_MONITOR_EMO);

            SubCtrlLaserDevice_2.SetTargetDigitalInput((int)SubSequence.SubLaserWork.ProtecDeviceControl.EN_DIGITAL_INPUT.ALARM
                                                   , (int)EN_DIGITAL_INPUT_LIST.LD_2_ALARM_PORT_2);
            SubCtrlLaserDevice_2.SetTargetDigitalInput((int)SubSequence.SubLaserWork.ProtecDeviceControl.EN_DIGITAL_INPUT.ON
                                                  , (int)EN_DIGITAL_INPUT_LIST.LD_2_ON_PORT_2);
            SubCtrlLaserDevice_2.SetTargetDigitalInput((int)SubSequence.SubLaserWork.ProtecDeviceControl.EN_DIGITAL_INPUT.READY
                                                  , (int)EN_DIGITAL_INPUT_LIST.LD_2_READY_PORT_2);
            
            arCtrlLaserDevice_2[1] = SubCtrlLaserDevice_2;

            SubCtrlLaserDevice_2 = new SubCtrlDeviceProtecLaser(this as RunningTaskEx);

            SubCtrlLaserDevice_2.SetTargetDigitalOutput((int)SubSequence.SubLaserWork.ProtecDeviceControl.EN_DIGITAL_OUTPUT.RESET
                                                    , (int)EN_DIGITAL_OUTPUT_LIST.LD_2_ALARM_CLEAR_PORT_3);
            SubCtrlLaserDevice_2.SetTargetDigitalOutput((int)SubSequence.SubLaserWork.ProtecDeviceControl.EN_DIGITAL_OUTPUT.READY
                                                    , (int)EN_DIGITAL_OUTPUT_LIST.LD_2_READY_PORT_3);
            SubCtrlLaserDevice_2.SetTargetDigitalOutput((int)SubSequence.SubLaserWork.ProtecDeviceControl.EN_DIGITAL_OUTPUT.ON
                                                    , (int)EN_DIGITAL_OUTPUT_LIST.LD_2_ON_PORT_3);
            SubCtrlLaserDevice_2.SetTargetDigitalOutput((int)SubSequence.SubLaserWork.ProtecDeviceControl.EN_DIGITAL_OUTPUT.EMO
                                                    , (int)EN_DIGITAL_OUTPUT_LIST.LD_2_MONITOR_EMO);

            SubCtrlLaserDevice_2.SetTargetDigitalInput((int)SubSequence.SubLaserWork.ProtecDeviceControl.EN_DIGITAL_INPUT.ALARM
                                                   , (int)EN_DIGITAL_INPUT_LIST.LD_2_ALARM_PORT_3);
            SubCtrlLaserDevice_2.SetTargetDigitalInput((int)SubSequence.SubLaserWork.ProtecDeviceControl.EN_DIGITAL_INPUT.ON
                                                  , (int)EN_DIGITAL_INPUT_LIST.LD_2_ON_PORT_3);
            SubCtrlLaserDevice_2.SetTargetDigitalInput((int)SubSequence.SubLaserWork.ProtecDeviceControl.EN_DIGITAL_INPUT.READY
                                                  , (int)EN_DIGITAL_INPUT_LIST.LD_2_READY_PORT_3);

            arCtrlLaserDevice_2[2] = SubCtrlLaserDevice_2;
            #endregion

            #region Analog OutPut Laser #2
            ASubControl[,] arSubCtrlOutputProfile_2 = new ASubControl[3, 1];

            ASubControl SubCtrlOutputProfile_2 = new SubCtrlOutputProfileProtecLaser(this as RunningTaskEx);

            SubCtrlOutputProfile_2.SetTargetDigitalOutput((int)SubSequence.SubLaserWork.ProtecLaserOutputProfile.EN_DIGITAL_OUTPUT.RESET
                                                  , (int)EN_DIGITAL_OUTPUT_LIST.LD_2_ALARM_CLEAR_PORT_1);
            SubCtrlOutputProfile_2.SetTargetDigitalOutput((int)SubSequence.SubLaserWork.ProtecLaserOutputProfile.EN_DIGITAL_OUTPUT.READY
                                                    , (int)EN_DIGITAL_OUTPUT_LIST.LD_2_READY_PORT_1);
            SubCtrlOutputProfile_2.SetTargetDigitalOutput((int)SubSequence.SubLaserWork.ProtecLaserOutputProfile.EN_DIGITAL_OUTPUT.ON
                                                    , (int)EN_DIGITAL_OUTPUT_LIST.LD_2_ON_PORT_1);
            SubCtrlOutputProfile_2.SetTargetDigitalOutput((int)SubSequence.SubLaserWork.ProtecLaserOutputProfile.EN_DIGITAL_OUTPUT.EMO
                                                    , (int)EN_DIGITAL_OUTPUT_LIST.LD_2_MONITOR_EMO);

            SubCtrlOutputProfile_2.SetTargetDigitalInput((int)SubSequence.SubLaserWork.ProtecLaserOutputProfile.EN_DIGITAL_INPUT.ALARM
                                                   , (int)EN_DIGITAL_INPUT_LIST.LD_2_ALARM_PORT_1);
            SubCtrlOutputProfile_2.SetTargetDigitalInput((int)SubSequence.SubLaserWork.ProtecLaserOutputProfile.EN_DIGITAL_INPUT.ON
                                                  , (int)EN_DIGITAL_INPUT_LIST.LD_2_ON_PORT_1);
            SubCtrlOutputProfile_2.SetTargetDigitalInput((int)SubSequence.SubLaserWork.ProtecLaserOutputProfile.EN_DIGITAL_INPUT.READY
                                                  , (int)EN_DIGITAL_INPUT_LIST.LD_2_READY_PORT_1);

            SubCtrlOutputProfile_2.SetTargetDigitalInput((int)SubSequence.SubLaserWork.ProtecLaserOutputProfile.EN_SERIAL.COTNROL
                                                  , (int)Define.DefineEnumProject.Serial.EN_SERIAL_INDEX.LD_2_CONTROL_1);

            arSubCtrlOutputProfile_2[0, 0] = SubCtrlOutputProfile_2;

            SubCtrlOutputProfile_2 = new SubCtrlOutputProfileProtecLaser(this as RunningTaskEx);

            SubCtrlOutputProfile_2.SetTargetDigitalOutput((int)SubSequence.SubLaserWork.ProtecLaserOutputProfile.EN_DIGITAL_OUTPUT.RESET
                                                  , (int)EN_DIGITAL_OUTPUT_LIST.LD_2_ALARM_CLEAR_PORT_2);
            SubCtrlOutputProfile_2.SetTargetDigitalOutput((int)SubSequence.SubLaserWork.ProtecLaserOutputProfile.EN_DIGITAL_OUTPUT.READY
                                                    , (int)EN_DIGITAL_OUTPUT_LIST.LD_2_READY_PORT_2);
            SubCtrlOutputProfile_2.SetTargetDigitalOutput((int)SubSequence.SubLaserWork.ProtecLaserOutputProfile.EN_DIGITAL_OUTPUT.ON
                                                    , (int)EN_DIGITAL_OUTPUT_LIST.LD_2_ON_PORT_2);
            SubCtrlOutputProfile_2.SetTargetDigitalOutput((int)SubSequence.SubLaserWork.ProtecLaserOutputProfile.EN_DIGITAL_OUTPUT.EMO
                                                    , (int)EN_DIGITAL_OUTPUT_LIST.LD_2_MONITOR_EMO);

            SubCtrlOutputProfile_2.SetTargetDigitalInput((int)SubSequence.SubLaserWork.ProtecLaserOutputProfile.EN_DIGITAL_INPUT.ALARM
                                                   , (int)EN_DIGITAL_INPUT_LIST.LD_2_ALARM_PORT_2);
            SubCtrlOutputProfile_2.SetTargetDigitalInput((int)SubSequence.SubLaserWork.ProtecLaserOutputProfile.EN_DIGITAL_INPUT.ON
                                                  , (int)EN_DIGITAL_INPUT_LIST.LD_2_ON_PORT_2);
            SubCtrlOutputProfile_2.SetTargetDigitalInput((int)SubSequence.SubLaserWork.ProtecLaserOutputProfile.EN_DIGITAL_INPUT.READY
                                                  , (int)EN_DIGITAL_INPUT_LIST.LD_2_READY_PORT_2);

            SubCtrlOutputProfile_2.SetTargetDigitalInput((int)SubSequence.SubLaserWork.ProtecLaserOutputProfile.EN_SERIAL.COTNROL
                                                  , (int)Define.DefineEnumProject.Serial.EN_SERIAL_INDEX.LD_2_CONTROL_2);

            arSubCtrlOutputProfile_2[1, 0] = SubCtrlOutputProfile_2;

            SubCtrlOutputProfile_2 = new SubCtrlOutputProfileProtecLaser(this as RunningTaskEx);

            SubCtrlOutputProfile_2.SetTargetDigitalOutput((int)SubSequence.SubLaserWork.ProtecLaserOutputProfile.EN_DIGITAL_OUTPUT.RESET
                                                  , (int)EN_DIGITAL_OUTPUT_LIST.LD_2_ALARM_CLEAR_PORT_3);
            SubCtrlOutputProfile_2.SetTargetDigitalOutput((int)SubSequence.SubLaserWork.ProtecLaserOutputProfile.EN_DIGITAL_OUTPUT.READY
                                                    , (int)EN_DIGITAL_OUTPUT_LIST.LD_2_READY_PORT_3);
            SubCtrlOutputProfile_2.SetTargetDigitalOutput((int)SubSequence.SubLaserWork.ProtecLaserOutputProfile.EN_DIGITAL_OUTPUT.ON
                                                    , (int)EN_DIGITAL_OUTPUT_LIST.LD_2_ON_PORT_3);
            SubCtrlOutputProfile_2.SetTargetDigitalOutput((int)SubSequence.SubLaserWork.ProtecLaserOutputProfile.EN_DIGITAL_OUTPUT.EMO
                                                    , (int)EN_DIGITAL_OUTPUT_LIST.LD_2_MONITOR_EMO);

            SubCtrlOutputProfile_2.SetTargetDigitalInput((int)SubSequence.SubLaserWork.ProtecLaserOutputProfile.EN_DIGITAL_INPUT.ALARM
                                                   , (int)EN_DIGITAL_INPUT_LIST.LD_2_ALARM_PORT_3);
            SubCtrlOutputProfile_2.SetTargetDigitalInput((int)SubSequence.SubLaserWork.ProtecLaserOutputProfile.EN_DIGITAL_INPUT.ON
                                                  , (int)EN_DIGITAL_INPUT_LIST.LD_2_ON_PORT_3);
            SubCtrlOutputProfile_2.SetTargetDigitalInput((int)SubSequence.SubLaserWork.ProtecLaserOutputProfile.EN_DIGITAL_INPUT.READY
                                                  , (int)EN_DIGITAL_INPUT_LIST.LD_2_READY_PORT_3);

            SubCtrlOutputProfile_2.SetTargetDigitalInput((int)SubSequence.SubLaserWork.ProtecLaserOutputProfile.EN_SERIAL.COTNROL
                                                  , (int)Define.DefineEnumProject.Serial.EN_SERIAL_INDEX.LD_2_CONTROL_3);

            arSubCtrlOutputProfile_2[2, 0] = SubCtrlOutputProfile_2;

            #endregion


            m_Subseq_Laser_Work_2 = new SubSeqLaserWork(arCtrlLaserDevice_2, arSubCtrlOutputProfile_2);

            #region Monitor Lader #2
            ASubControl[] arCtrlMonitor_2 = new ASubControl[20];


            ASubControl SubCtrlAnalogMonitor_2 = new SubCtrlMonitoringAnalog(this as RunningTaskEx);

            SubCtrlAnalogMonitor_2.SetTargetAnalogInput((int)SubSequence.SubLaserWork.AnalogMonitor.EN_ANALOG_INPUT.POWER
                                     , (int)EN_ANALOG_INPUT_LIST.LD_2_POWER_1);
            //             SubCtrlAnalogMonitor_2.SetTargetAnalogInput((int)SubSequence.SubLaserWork.AnalogMonitor.EN_ANALOG_INPUT.TEMP
            //                                      , (int)EN_ANALOG_INPUT_LIST.TEMP_SENSOR_1);
            arCtrlMonitor_2[0] = SubCtrlAnalogMonitor_2;

            SubCtrlAnalogMonitor_2 = new SubCtrlMonitoringAnalog(this as RunningTaskEx);

            SubCtrlAnalogMonitor_2.SetTargetAnalogInput((int)SubSequence.SubLaserWork.AnalogMonitor.EN_ANALOG_INPUT.POWER
                                     , (int)EN_ANALOG_INPUT_LIST.LD_2_POWER_2);
            //             SubCtrlAnalogMonitor_2.SetTargetAnalogInput((int)SubSequence.SubLaserWork.AnalogMonitor.EN_ANALOG_INPUT.TEMP
            //                                      , (int)EN_ANALOG_INPUT_LIST.TEMP_SENSOR_2);
            arCtrlMonitor_2[1] = SubCtrlAnalogMonitor_2;

            SubCtrlAnalogMonitor_2 = new SubCtrlMonitoringAnalog(this as RunningTaskEx);

            SubCtrlAnalogMonitor_2.SetTargetAnalogInput((int)SubSequence.SubLaserWork.AnalogMonitor.EN_ANALOG_INPUT.POWER
                                      , (int)EN_ANALOG_INPUT_LIST.LD_2_POWER_3);
            //             SubCtrlAnalogMonitor_2.SetTargetAnalogInput((int)SubSequence.SubLaserWork.AnalogMonitor.EN_ANALOG_INPUT.TEMP
            //                                       , (int)EN_ANALOG_INPUT_LIST.TEMP_SENSOR_3);
            arCtrlMonitor_2[2] = SubCtrlAnalogMonitor_2;

            SubCtrlAnalogMonitor_2 = new SubCtrlMonitoringAnalog(this as RunningTaskEx);

            SubCtrlAnalogMonitor_2.SetTargetAnalogInput((int)SubSequence.SubLaserWork.AnalogMonitor.EN_ANALOG_INPUT.POWER
                                      , (int)EN_ANALOG_INPUT_LIST.LD_2_POWER_4);
            //             SubCtrlAnalogMonitor_2.SetTargetAnalogInput((int)SubSequence.SubLaserWork.AnalogMonitor.EN_ANALOG_INPUT.TEMP
            //                                       , (int)EN_ANALOG_INPUT_LIST.TEMP_SENSOR_4);
            arCtrlMonitor_2[3] = SubCtrlAnalogMonitor_2;

            SubCtrlAnalogMonitor_2 = new SubCtrlMonitoringAnalog(this as RunningTaskEx);

            SubCtrlAnalogMonitor_2.SetTargetAnalogInput((int)SubSequence.SubLaserWork.AnalogMonitor.EN_ANALOG_INPUT.POWER
                                      , (int)EN_ANALOG_INPUT_LIST.LD_2_POWER_5);
            //             SubCtrlAnalogMonitor_2.SetTargetAnalogInput((int)SubSequence.SubLaserWork.AnalogMonitor.EN_ANALOG_INPUT.TEMP
            //                                       , (int)EN_ANALOG_INPUT_LIST.TEMP_SENSOR_5);
            arCtrlMonitor_2[4] = SubCtrlAnalogMonitor_2;

            SubCtrlAnalogMonitor_2 = new SubCtrlMonitoringAnalog(this as RunningTaskEx);

            SubCtrlAnalogMonitor_2.SetTargetAnalogInput((int)SubSequence.SubLaserWork.AnalogMonitor.EN_ANALOG_INPUT.POWER
                                      , (int)EN_ANALOG_INPUT_LIST.LD_2_POWER_6);
            arCtrlMonitor_2[5] = SubCtrlAnalogMonitor_2;

            SubCtrlAnalogMonitor_2 = new SubCtrlMonitoringAnalog(this as RunningTaskEx);

            SubCtrlAnalogMonitor_2.SetTargetAnalogInput((int)SubSequence.SubLaserWork.AnalogMonitor.EN_ANALOG_INPUT.POWER
                                      , (int)EN_ANALOG_INPUT_LIST.LD_2_POWER_7);
            arCtrlMonitor_2[6] = SubCtrlAnalogMonitor_2;

            SubCtrlAnalogMonitor_2 = new SubCtrlMonitoringAnalog(this as RunningTaskEx);

            SubCtrlAnalogMonitor_2.SetTargetAnalogInput((int)SubSequence.SubLaserWork.AnalogMonitor.EN_ANALOG_INPUT.POWER
                                      , (int)EN_ANALOG_INPUT_LIST.LD_2_POWER_8);
            arCtrlMonitor_2[7] = SubCtrlAnalogMonitor_2;

            SubCtrlAnalogMonitor_2 = new SubCtrlMonitoringAnalog(this as RunningTaskEx);

            SubCtrlAnalogMonitor_2.SetTargetAnalogInput((int)SubSequence.SubLaserWork.AnalogMonitor.EN_ANALOG_INPUT.POWER
                                      , (int)EN_ANALOG_INPUT_LIST.LD_2_POWER_9);
            arCtrlMonitor_2[8] = SubCtrlAnalogMonitor_2;

            SubCtrlAnalogMonitor_2 = new SubCtrlMonitoringAnalog(this as RunningTaskEx);

            SubCtrlAnalogMonitor_2.SetTargetAnalogInput((int)SubSequence.SubLaserWork.AnalogMonitor.EN_ANALOG_INPUT.POWER
                                      , (int)EN_ANALOG_INPUT_LIST.LD_2_POWER_10);
            arCtrlMonitor_2[9] = SubCtrlAnalogMonitor_2;

            SubCtrlAnalogMonitor_2 = new SubCtrlMonitoringAnalog(this as RunningTaskEx);

            SubCtrlAnalogMonitor_2.SetTargetAnalogInput((int)SubSequence.SubLaserWork.AnalogMonitor.EN_ANALOG_INPUT.POWER
                                      , (int)EN_ANALOG_INPUT_LIST.LD_2_POWER_11);
            arCtrlMonitor_2[10] = SubCtrlAnalogMonitor_2;

            SubCtrlAnalogMonitor_2 = new SubCtrlMonitoringAnalog(this as RunningTaskEx);

            SubCtrlAnalogMonitor_2.SetTargetAnalogInput((int)SubSequence.SubLaserWork.AnalogMonitor.EN_ANALOG_INPUT.POWER
                                      , (int)EN_ANALOG_INPUT_LIST.LD_2_POWER_12);
            arCtrlMonitor_2[11] = SubCtrlAnalogMonitor_2;

            SubCtrlAnalogMonitor_2 = new SubCtrlMonitoringAnalog(this as RunningTaskEx);

            SubCtrlAnalogMonitor_2.SetTargetAnalogInput((int)SubSequence.SubLaserWork.AnalogMonitor.EN_ANALOG_INPUT.POWER
                                      , (int)EN_ANALOG_INPUT_LIST.LD_2_POWER_13);
            arCtrlMonitor_2[12] = SubCtrlAnalogMonitor_2;

            SubCtrlAnalogMonitor_2 = new SubCtrlMonitoringAnalog(this as RunningTaskEx);

            SubCtrlAnalogMonitor_2.SetTargetAnalogInput((int)SubSequence.SubLaserWork.AnalogMonitor.EN_ANALOG_INPUT.POWER
                                      , (int)EN_ANALOG_INPUT_LIST.LD_2_POWER_14);
            arCtrlMonitor_2[13] = SubCtrlAnalogMonitor_2;

            SubCtrlAnalogMonitor_2 = new SubCtrlMonitoringAnalog(this as RunningTaskEx);

            SubCtrlAnalogMonitor_2.SetTargetAnalogInput((int)SubSequence.SubLaserWork.AnalogMonitor.EN_ANALOG_INPUT.POWER
                                      , (int)EN_ANALOG_INPUT_LIST.LD_2_POWER_15);
            arCtrlMonitor_2[14] = SubCtrlAnalogMonitor_2;

            SubCtrlAnalogMonitor_2 = new SubCtrlMonitoringAnalog(this as RunningTaskEx);

            SubCtrlAnalogMonitor_2.SetTargetAnalogInput((int)SubSequence.SubLaserWork.AnalogMonitor.EN_ANALOG_INPUT.POWER
                                      , (int)EN_ANALOG_INPUT_LIST.LD_2_POWER_16);
            arCtrlMonitor_2[15] = SubCtrlAnalogMonitor_2;

            SubCtrlAnalogMonitor_2 = new SubCtrlMonitoringAnalog(this as RunningTaskEx);

            SubCtrlAnalogMonitor_2.SetTargetAnalogInput((int)SubSequence.SubLaserWork.AnalogMonitor.EN_ANALOG_INPUT.POWER
                                     , (int)EN_ANALOG_INPUT_LIST.LD_2_POWER_17);
            arCtrlMonitor_2[16] = SubCtrlAnalogMonitor_2;

            SubCtrlAnalogMonitor_2 = new SubCtrlMonitoringAnalog(this as RunningTaskEx);

            SubCtrlAnalogMonitor_2.SetTargetAnalogInput((int)SubSequence.SubLaserWork.AnalogMonitor.EN_ANALOG_INPUT.POWER
                                     , (int)EN_ANALOG_INPUT_LIST.LD_2_POWER_18);
            arCtrlMonitor_2[17] = SubCtrlAnalogMonitor_2;

            SubCtrlMonitoringWorkLog SubCtrlWorkLogMonitor_2 = new SubCtrlMonitoringWorkLog(this as RunningTaskEx);

            arCtrlMonitor_2[18] = SubCtrlWorkLogMonitor_2;

            SubCtrlMonitoringIR SubCtrlIRMonitor_2 = new SubCtrlMonitoringIR(this as RunningTaskEx);

            arCtrlMonitor_2[19] = SubCtrlIRMonitor_2;

            #endregion
            m_Subseq_Laser_Work_2.AddMonitorControl(arCtrlMonitor_2);
            #endregion /Laser#2 Total
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

        #endregion

        #region Internal Interface

        #region Action Sequence List
        #region Auto
        private bool ActionLaserWork()
        {
            bool bLaserUsed_1 = m_Recipe.GetValue(GetTaskName().ToString(), PARAM_PROCESS.LASER_1_USED.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, true);
            bool bLaserUsed_2 = m_Recipe.GetValue(GetTaskName().ToString(), PARAM_PROCESS.LASER_2_USED.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, true);
            //bool m_bLaserOutputStarted = false;
            //bool m_bLaserOutputOn = false;
            //int m_nLaserOutputCount = 0;
            //int m_nLaserOnDelay = 0;
            //int m_nLaserOffDelay = 0;
            //int m_nLaserRepeatCount = 0;

            switch (m_nSeqNum)
            {
                case (int)EN_LASER_WORK_STEP.ACTION_START:
                    int nLaserCount = 18;
                    //Action이 시작되면 Calibration Table File을 Load 한다.
                    Laser.ProtecLaserChannelCalibration.GetInstance().Init(nLaserCount);
                    Laser.ProtecLaserChannelCalibration_2.GetInstance().Init(nLaserCount);

                    m_tickTimeOut.SetTickCount(5000);
                    if (!bLaserUsed_1)
                    {
                        m_nSeqNum = (int)EN_LASER_WORK_STEP.PARAMETER_READY_LASER_2;
                        break;
                    }
                    m_nSeqNum = (int)EN_LASER_WORK_STEP.PARAMETER_READY_LASER_1;
                    break;

                case (int)EN_LASER_WORK_STEP.PARAMETER_READY_LASER_1:
                    #region Laser#1
                    // 2025.3.31 by ecchoi [ADD] Test 후 복구
                    if (m_tickTimeOut.IsTickOver(false))
                    {
                        m_arAlarmSubInfo[0] = "";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.LD1_COMMNUNICATION_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_nSeqNum = (int)EN_LASER_WORK_STEP.FINISH;
                        break;
                    }
                    bool[] arUsed = new bool[m_Laser.ChannelCount];
                    double arTotalPower = 0.0;

                    for (int nCh = 0; nCh < m_Laser.ChannelCount; ++nCh)
                    {
                        arUsed[nCh] = m_Recipe.GetValue(GetTaskName().ToString(), PARAM_PROCESS.SHOT_PARAMETER_ENABLE_18.ToString(), nCh, EN_RECIPE_PARAM_TYPE.VALUE, false);
                    }

                    arTotalPower = m_Recipe.GetValue(GetTaskName().ToString(), PARAM_PROCESS.SHOT_PARAMETER_TOTAL_POWER.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                    switch (m_Laser.SetParameterIOMode(arUsed, arTotalPower))
                    {
                        case ProtecLaserMananger.EN_SET_RESULT.OK:
                            int nDelay = m_Recipe.GetValue(GetTaskName().ToString(), PARAM_PROCESS.LASER_SETTING_DELAY.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);
                            SetDelayForSequence(nDelay);
                            m_nSeqNum ++;
                            break;
                        case ProtecLaserMananger.EN_SET_RESULT.WORKING:
                            if (EquipmentState_.EquipmentState.GetInstance().GetState() == EquipmentState_.EQUIPMENT_STATE.FINISHING)
                                m_nSeqNum = (int)EN_LASER_WORK_STEP.FINISH;
                            break;
                        case ProtecLaserMananger.EN_SET_RESULT.POWER_OVER_MAX:
                            Alarm_.Alarm.GetInstance().GenerateAlarm(0, 0, 101, false); //POWER IS TOO HIGH
                            break;
                        case ProtecLaserMananger.EN_SET_RESULT.CH_POWER_OVER:
                            Alarm_.Alarm.GetInstance().GenerateAlarm(0, 0, 102, false); //CHANNEL POWER IS TOO HIGH
                            break;
                        case ProtecLaserMananger.EN_SET_RESULT.POWER_UNDER_MIN:
                            Alarm_.Alarm.GetInstance().GenerateAlarm(0, 0, 103, false); //POWER IS TOO LOW
                            break;
                        default:
                            Alarm_.Alarm.GetInstance().GenerateAlarm(0, 0, 104, false); //LASER COMMUNICATION FAIL
                            break;

                    }
                    break;

                case (int)EN_LASER_WORK_STEP.PARAMETER_READY_LASER_1 +1:
                    // 2025.3.31 by ecchoi [ADD] Test 후 복구
                    if (m_tickTimeOut.IsTickOver(false))
                    {
                        m_arAlarmSubInfo[0] = "";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.LD1_COMMNUNICATION_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_nSeqNum = (int)EN_LASER_WORK_STEP.FINISH;
                        break;
                    }
                    int nLimitSec = 30;

                    nLimitSec = m_Recipe.GetValue(GetTaskName().ToString(), PARAM_PROCESS.AUTO_SAFETY_LIMIT.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 30);
                    switch (m_Laser.SetParameterTimeLimit(nLimitSec))
                    {
                        case ProtecLaserMananger.EN_SET_RESULT.OK:
                            int nDelay = m_Recipe.GetValue(GetTaskName().ToString(), PARAM_PROCESS.LASER_SETTING_DELAY.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);
                            SetDelayForSequence(nDelay);
                            m_nSeqNum = (int)EN_LASER_WORK_STEP.PARAMETER_READY_LASER_2;
                            break;
                        case ProtecLaserMananger.EN_SET_RESULT.WORKING:
                            if (EquipmentState_.EquipmentState.GetInstance().GetState() == EquipmentState_.EQUIPMENT_STATE.FINISHING)
                                m_nSeqNum = (int)EN_LASER_WORK_STEP.FINISH;
                            break;
                        case ProtecLaserMananger.EN_SET_RESULT.POWER_OVER_MAX:
                            Alarm_.Alarm.GetInstance().GenerateAlarm(0, 0, 101, false); //POWER IS TOO HIGH
                            break;
                        case ProtecLaserMananger.EN_SET_RESULT.CH_POWER_OVER:
                            Alarm_.Alarm.GetInstance().GenerateAlarm(0, 0, 102, false); //CHANNEL POWER IS TOO HIGH
                            break;
                        case ProtecLaserMananger.EN_SET_RESULT.POWER_UNDER_MIN:
                            Alarm_.Alarm.GetInstance().GenerateAlarm(0, 0, 103, false); //POWER IS TOO LOW
                            break;
                        default:
                            Alarm_.Alarm.GetInstance().GenerateAlarm(0, 0, 104, false); //LASER COMMUNICATION FAIL
                            break;

                    }

                    #endregion /Laser#1 end
                    break;

                case (int)EN_LASER_WORK_STEP.PARAMETER_READY_LASER_2:
                    if (bLaserUsed_1 && !bLaserUsed_2)
                    {
                        m_nSeqNum = (int)EN_LASER_WORK_STEP.PARAMETER_COMPLETE_1;
                        break;
                        // 2025.4.15 by ecchoi [ADD] 둘다 False(Unused) 일경우 LD2 Comm TimeOut 알람을 띄운다
                    }
                    #region Laser#2
                    // 2025.3.31 by ecchoi [ADD] Test 후 복구
                    if (m_tickTimeOut.IsTickOver(false))
                    {
                        //m_arAlarmSubInfo[0] = "";
                        //GenerateSequenceAlarm((int)EN_TASK_ALARM.LD2_COMMNUNICATION_TIMEOUT, false, ref m_arAlarmSubInfo);
                        //m_nSeqNum = (int)EN_LASER_WORK_STEP.FINISH;
                        //break;
                    }
                    bool[] arUsed_2 = new bool[m_Laser_2.ChannelCount];
                    double arTotalPower_2 = 0.0;

                    for (int nCh = 0; nCh < m_Laser_2.ChannelCount; ++nCh)
                    {
                        arUsed_2[nCh] = m_Recipe.GetValue(GetTaskName().ToString(), PARAM_PROCESS.SHOT_PARAMETER_2_ENABLE_18.ToString(), nCh, EN_RECIPE_PARAM_TYPE.VALUE, false);
                    }

                    arTotalPower_2 = m_Recipe.GetValue(GetTaskName().ToString(), PARAM_PROCESS.SHOT_PARAMETER_2_TOTAL_POWER.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                    switch (m_Laser_2.SetParameterIOMode(arUsed_2, arTotalPower_2))
                    {
                        case ProtecLaserMananger_2.EN_SET_RESULT_2.OK:
                            int nDelay = m_Recipe.GetValue(GetTaskName().ToString(), PARAM_PROCESS.LASER_SETTING_DELAY.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);
                            SetDelayForSequence(nDelay);
                            m_nSeqNum ++;
                            break;
                        case ProtecLaserMananger_2.EN_SET_RESULT_2.WORKING:
                            if (EquipmentState_.EquipmentState.GetInstance().GetState() == EquipmentState_.EQUIPMENT_STATE.FINISHING)
                                m_nSeqNum = (int)EN_LASER_WORK_STEP.FINISH;
                            break;
                        case ProtecLaserMananger_2.EN_SET_RESULT_2.POWER_OVER_MAX:
                            Alarm_.Alarm.GetInstance().GenerateAlarm(0, 0, 101, false); //POWER IS TOO HIGH
                            break;
                        case ProtecLaserMananger_2.EN_SET_RESULT_2.CH_POWER_OVER:
                            Alarm_.Alarm.GetInstance().GenerateAlarm(0, 0, 102, false); //CHANNEL POWER IS TOO HIGH
                            break;
                        case ProtecLaserMananger_2.EN_SET_RESULT_2.POWER_UNDER_MIN:
                            Alarm_.Alarm.GetInstance().GenerateAlarm(0, 0, 103, false); //POWER IS TOO LOW
                            break;
                        default:
                            Alarm_.Alarm.GetInstance().GenerateAlarm(0, 0, 104, false); //LASER COMMUNICATION FAIL
                            break;

                    }
                    break;

                case (int)EN_LASER_WORK_STEP.PARAMETER_READY_LASER_2 +1:
                    if (bLaserUsed_1 && !bLaserUsed_2)
                    {
                        m_nSeqNum = (int)EN_LASER_WORK_STEP.PARAMETER_COMPLETE_1;
                        break;
                        // 2025.4.15 by ecchoi [ADD] 둘다 False(Unused) 일경우 LD2 Comm TimeOut 알람을 띄운다
                    }
                    // 2025.3.31 by ecchoi [ADD] Test 후 복구
                    if (m_tickTimeOut.IsTickOver(false))
                    {
                        //m_arAlarmSubInfo[0] = "";
                        //GenerateSequenceAlarm((int)EN_TASK_ALARM.LD2_COMMNUNICATION_TIMEOUT, false, ref m_arAlarmSubInfo);
                        //m_nSeqNum = (int)EN_LASER_WORK_STEP.FINISH;
                        //break;
                    }
                    int nLimitSec_2 = 30;

                    nLimitSec_2 = m_Recipe.GetValue(GetTaskName().ToString(), PARAM_PROCESS.AUTO_SAFETY_LIMIT.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 30);
                    switch (m_Laser_2.SetParameterTimeLimit(nLimitSec_2))
                    {
                        case ProtecLaserMananger_2.EN_SET_RESULT_2.OK:
                            int nDelay = m_Recipe.GetValue(GetTaskName().ToString(), PARAM_PROCESS.LASER_SETTING_DELAY.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);
                            SetDelayForSequence(nDelay);
                            m_nSeqNum = (int)EN_LASER_WORK_STEP.PARAMETER_COMPLETE_1;
                            break;
                        case ProtecLaserMananger_2.EN_SET_RESULT_2.WORKING:
                            if (EquipmentState_.EquipmentState.GetInstance().GetState() == EquipmentState_.EQUIPMENT_STATE.FINISHING)
                                m_nSeqNum = (int)EN_LASER_WORK_STEP.FINISH;
                            break;
                        case ProtecLaserMananger_2.EN_SET_RESULT_2.POWER_OVER_MAX:
                            Alarm_.Alarm.GetInstance().GenerateAlarm(0, 0, 101, false); //POWER IS TOO HIGH
                            break;
                        case ProtecLaserMananger_2.EN_SET_RESULT_2.CH_POWER_OVER:
                            Alarm_.Alarm.GetInstance().GenerateAlarm(0, 0, 102, false); //CHANNEL POWER IS TOO HIGH
                            break;
                        case ProtecLaserMananger_2.EN_SET_RESULT_2.POWER_UNDER_MIN:
                            Alarm_.Alarm.GetInstance().GenerateAlarm(0, 0, 103, false); //POWER IS TOO LOW
                            break;
                        default:
                            Alarm_.Alarm.GetInstance().GenerateAlarm(0, 0, 104, false); //LASER COMMUNICATION FAIL
                            break;

                    }

                    #endregion /Laser#2 end
                    break;

                case (int)EN_LASER_WORK_STEP.PARAMETER_COMPLETE_1:
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_READY_PORT_1, true);
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_READY_PORT_2, true);
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_READY_PORT_3, true);
                    if (bLaserUsed_2)
                    {
                        m_nSeqNum = (int)EN_LASER_WORK_STEP.PARAMETER_COMPLETE_2;
                        break;
                    }
                    else
                    {
                        m_nSeqNum = (int)EN_LASER_WORK_STEP.WAIT_AND_OUTPUT;
                        break;
                    }

                case (int)EN_LASER_WORK_STEP.PARAMETER_COMPLETE_2:
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_2_READY_PORT_1, true);
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_2_READY_PORT_2, true);
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_2_READY_PORT_3, true);
                    m_nSeqNum = (int)EN_LASER_WORK_STEP.WAIT_AND_OUTPUT;
                    break;

                case (int)EN_LASER_WORK_STEP.WAIT_AND_OUTPUT:
                    {
                        if (EquipmentState_.EquipmentState.GetInstance().GetState() == EquipmentState_.EQUIPMENT_STATE.FINISHING)
                            m_nSeqNum = (int)EN_LASER_WORK_STEP.FINISH;
                        // 2025.4.11 by ecchoi [ADD] PARAMETER 설정이 끝나면 PLC에서 ON 신호를 받을때까지 여기서 대기 한다.
                        if (!ReadInput((int)EN_DIGITAL_INPUT_LIST.FROM_PLC_IN_2, true))
                        {
                            if (!m_bLaserOutputStarted) //최초 1회만 진입 후 완료되면 false 전환
                            {
                                m_bLaserOutputStarted = true;
                                m_nLaserOutputCount = 0;
                                m_bLaserOutputOn = true;

                                m_nLaserOnDelay = m_Recipe.GetValue(GetTaskName().ToString(), PARAM_PROCESS.LASER_ON_DELAY.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);
                                m_nLaserOffDelay = m_Recipe.GetValue(GetTaskName().ToString(), PARAM_PROCESS.LASER_OFF_DELAY.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);
                                m_nLaserRepeatCount = m_Recipe.GetValue(GetTaskName().ToString(), PARAM_PROCESS.LASER_COUNT.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 1);

                                m_tickLaserOutput.SetTickCount((uint)m_nLaserOnDelay);
                                // 2025.4.16 by ecchoi [ADD] Test 후 복구
                                //WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_ON_PORT_1, bLaserUsed_1); // 첫 ON
                                //WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_ON_PORT_2, bLaserUsed_1);
                                //WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_ON_PORT_3, bLaserUsed_1);
                                //WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_2_ON_PORT_1, bLaserUsed_2);
                                //WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_2_ON_PORT_2, bLaserUsed_2);
                                //WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_2_ON_PORT_3, bLaserUsed_2);

                                WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_ALARM_CLEAR_PORT_1, bLaserUsed_1); 
                                WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_ALARM_CLEAR_PORT_2, bLaserUsed_1);
                                WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_ALARM_CLEAR_PORT_3, bLaserUsed_1);
                                WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_2_ALARM_CLEAR_PORT_1, bLaserUsed_2);
                                WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_2_ALARM_CLEAR_PORT_2, bLaserUsed_2);
                                WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_2_ALARM_CLEAR_PORT_3, bLaserUsed_2);
                            }
                            else
                            {
                                if (m_bLaserOutputOn) 
                                {
                                    if (m_tickLaserOutput.IsTickOver(false)) // 현재 ON인 경우 여기로 진입
                                    {
                                        // ON -> OFF
                                        //WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_ON_PORT_1, false);
                                        //WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_ON_PORT_2, false);
                                        //WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_ON_PORT_3, false);
                                        //WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_2_ON_PORT_1, false);
                                        //WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_2_ON_PORT_2, false);
                                        //WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_2_ON_PORT_3, false);

                                        WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_ALARM_CLEAR_PORT_1, false);
                                        WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_ALARM_CLEAR_PORT_2, false);
                                        WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_ALARM_CLEAR_PORT_3, false);
                                        WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_2_ALARM_CLEAR_PORT_1, false);
                                        WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_2_ALARM_CLEAR_PORT_2, false);
                                        WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_2_ALARM_CLEAR_PORT_3, false);

                                        m_bLaserOutputOn = false;
                                        m_tickLaserOutput.SetTickCount((uint)m_nLaserOffDelay);
                                    }
                                }
                                else
                                {
                                    if (m_tickLaserOutput.IsTickOver(false)) // 현재 OFF인 경우 여기로 진입
                                    {
                                        m_nLaserOutputCount++;

                                        if (m_nLaserOutputCount >= m_nLaserRepeatCount)
                                        {
                                            // 반복 종료
                                            m_bLaserOutputStarted = false;
                                            m_nSeqNum = (int)EN_LASER_WORK_STEP.FINISH;
                                            break;
                                        }

                                        // OFF -> ON
                                        //WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_ON_PORT_1, bLaserUsed_1);
                                        //WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_ON_PORT_2, bLaserUsed_1);
                                        //WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_ON_PORT_3, bLaserUsed_1);
                                        //WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_2_ON_PORT_1, bLaserUsed_2);
                                        //WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_2_ON_PORT_2, bLaserUsed_2);
                                        //WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_2_ON_PORT_3, bLaserUsed_2);

                                        WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_ALARM_CLEAR_PORT_1, bLaserUsed_1);
                                        WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_ALARM_CLEAR_PORT_2, bLaserUsed_1);
                                        WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_ALARM_CLEAR_PORT_3, bLaserUsed_1);
                                        WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_2_ALARM_CLEAR_PORT_1, bLaserUsed_2);
                                        WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_2_ALARM_CLEAR_PORT_2, bLaserUsed_2);
                                        WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_2_ALARM_CLEAR_PORT_3, bLaserUsed_2);

                                        m_bLaserOutputOn = true;
                                        m_tickLaserOutput.SetTickCount((uint)m_nLaserOnDelay);
                                    }
                                }
                            }
                        }
                    }

                    
                    break;

                case (int)EN_LASER_WORK_STEP.FINISH:
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_READY_PORT_1, false);
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_READY_PORT_2, false);
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_READY_PORT_3, false);
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_2_READY_PORT_1, false);
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_2_READY_PORT_2, false);
                    WriteDigitalOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_2_READY_PORT_3, false);
                    // 2025.4.11 by ecchoi [ADD] 알람이나 사용자 정지는 여기로 빠져나온다.
                    return true;
            }

            return false;
        }
        #endregion
        
        #region Manaul
        private bool Action_PowerMeasure()
        {
            switch (m_nSeqNum)
            {
                case (int)EN_POWER_MEASURE_STEP.ACTION_START:
                    Powermeter.GetInstance().Open();
                    SetDelayForSequence(1000);
                    ++m_nSeqNum;
                    break;
                case (int)EN_POWER_MEASURE_STEP.ACTION_START + 1:
                    if (m_enAction == EN_TASK_ACTION.CALIBRATION_CHANNEL_POWER)
                        InitializeCalibrationData();
                    m_nPowerMeasureCurrentRepeatCount = 0;
                    m_lstCurrentVolt.Clear();
                    m_tickForPowerMeasureRest.SetTickCount(1);
                    m_nSeqNum = (int)EN_POWER_MEASURE_STEP.POWERMETER_READY;
                    break;

                case (int)EN_POWER_MEASURE_STEP.POWERMETER_READY:
                    Powermeter.GetInstance().ClearRepeatData();
                    Powermeter.GetInstance().nWait_Time = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.POWER_MEASURE_WAIT_TIME.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);
                    ++m_nSeqNum;
                    break;

                case (int)EN_POWER_MEASURE_STEP.POWERMETER_READY + 1:
                    Powermeter.GetInstance().SetCommand(EN_POWERMETER_COMMAND.HANDCHECKING_OFF);
                    SetDelayForSequence(300);
                    m_nSeqNum++;
                    break;
                case (int)EN_POWER_MEASURE_STEP.POWERMETER_READY + 2:
                    Powermeter.GetInstance().SetCommand(EN_POWERMETER_COMMAND.RECIEVE_LAST);
                    SetDelayForSequence(300);
                    m_nSeqNum++;
                    break;
                case (int)EN_POWER_MEASURE_STEP.POWERMETER_READY + 3:
                    Powermeter.GetInstance().SetCommand(EN_POWERMETER_COMMAND.RECIEVE_ONLY_POWER);
                    SetDelayForSequence(300);
                    m_nSeqNum++;
                    break;
                case (int)EN_POWER_MEASURE_STEP.POWERMETER_READY + 4:
                    Powermeter.GetInstance().SetCommand(EN_POWERMETER_COMMAND.ERROR_CLEAR);
                    SetDelayForSequence(300);
                    m_nSeqNum++;
                    break;
                case (int)EN_POWER_MEASURE_STEP.POWERMETER_READY + 5:
                    m_nSeqNum = (int)EN_POWER_MEASURE_STEP.MOVE_SHOT_POSITION;
                    break;

                #region MOVE SHOT POSITION
                case (int)EN_POWER_MEASURE_STEP.MOVE_SHOT_POSITION:
                    switch (m_enAction)
                    {
                        case EN_TASK_ACTION.MEASURE_POWER:
                        case EN_TASK_ACTION.MEASURE_VOLT:
                        case EN_TASK_ACTION.CALIBRATION_POWER_LOSS_RATE:
                            int ChMeasureCount = 0;
                            int nMeasureCh = 0;
                            for (int nCh = 0; nCh < m_Laser.ChannelCount; ++nCh)
                            {
                                if (m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.SHOT_PARAMETER_ENABLE_18.ToString(), nCh, EN_RECIPE_PARAM_TYPE.VALUE, false))
                                {
                                    ChMeasureCount++;
                                    nMeasureCh = nCh;
                                }
                            }
                            if (ChMeasureCount > 1)
                                nMeasureCh = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.POWER_MEASURE_SELLECTED_CHANNEL.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0) - 1;
                            
                            break;

                        case EN_TASK_ACTION.CALIBRATION_CHANNEL_POWER:
                            break;
                    }

                        m_nSeqNum = (int)EN_POWER_MEASURE_STEP.LASER_READY;

                    break;
                #endregion

                #region LASER READY SUB SEQ
                case (int)EN_POWER_MEASURE_STEP.LASER_READY:
                    if (EquipmentState_.EquipmentState.GetInstance().GetState() == EquipmentState_.EQUIPMENT_STATE.FINISHING)
                        m_nSeqNum = (int)EN_POWER_MEASURE_STEP.ACTION_FINISH;
                    if (m_tickForPowerMeasureRest.IsTickOver(true))
                    {
                        int nRestTime = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.POWER_MEASURE_REST_TIME.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);
                        
                        m_tickForPowerMeasureRest.SetTickCount((uint)nRestTime);
                        m_tickTimeOut.SetTickCount(2000);
                        m_nSeqNum++;
                    }
                    break;
                case (int)EN_POWER_MEASURE_STEP.LASER_READY + 1:
                    // 2025.4.5 by ecchoi [ADD] Test 후 복구
                    //if (m_tickTimeOut.IsTickOver(false))
                    //{
                    //    m_arAlarmSubInfo[0] = "";
                    //    GenerateSequenceAlarm((int)EN_TASK_ALARM.LD1_COMMNUNICATION_TIMEOUT, false, ref m_arAlarmSubInfo);
                    //    m_nSeqNum = (int)EN_POWER_MEASURE_STEP.ACTION_FINISH;
                    //    break;
                    //}
                    bool[] arUsed = new bool[m_Laser.ChannelCount];
                    int nTime = 0;
                    double dOutput = 0;

                    nTime = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.POWER_MEASURE_SHOT_TIME.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);
                    
                    switch (m_enAction)
                    {
                        case EN_TASK_ACTION.MEASURE_POWER:
                            for (int nCh = 0; nCh < m_Laser.ChannelCount; ++nCh)
                            {
                                arUsed[nCh] = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.SHOT_PARAMETER_ENABLE_18.ToString(), nCh, EN_RECIPE_PARAM_TYPE.VALUE, false);
                            }
                            dOutput = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.POWER_MEASURE_WATT.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                            switch (m_Laser.SetParameter(arUsed, dOutput, nTime))
                            {
                                case ProtecLaserMananger.EN_SET_RESULT.OK:
                                    m_nSeqNum++;
                                    break;
                                case ProtecLaserMananger.EN_SET_RESULT.WORKING:
                                    if (EquipmentState_.EquipmentState.GetInstance().GetState() == EquipmentState_.EQUIPMENT_STATE.FINISHING)
                                        m_nSeqNum = (int)EN_POWER_MEASURE_STEP.ACTION_FINISH;
                                    break;
                                case ProtecLaserMananger.EN_SET_RESULT.POWER_OVER_MAX:
                                    m_arAlarmSubInfo[0] = "POWER IS TOO HIGH";
                                    m_arAlarmSubInfo[1] = "";
                                    GenerateSequenceAlarm((int)EN_TASK_ALARM.LD1_POWER_OVER_MAX, false, ref m_arAlarmSubInfo);
                                    m_nSeqNum = (int)EN_POWER_MEASURE_STEP.ACTION_FINISH;
                                    break;
                                case ProtecLaserMananger.EN_SET_RESULT.POWER_UNDER_MIN:
                                    m_arAlarmSubInfo[0] = "POWER IS TOO LOW";
                                    m_arAlarmSubInfo[1] = "";
                                    GenerateSequenceAlarm((int)EN_TASK_ALARM.LD1_POWER_UNDER_MIN, false, ref m_arAlarmSubInfo);
                                    m_nSeqNum = (int)EN_POWER_MEASURE_STEP.ACTION_FINISH;
                                    break;
                                default:
                                    m_arAlarmSubInfo[0] = "";
                                    m_arAlarmSubInfo[1] = "";
                                    GenerateSequenceAlarm((int)EN_TASK_ALARM.LD1_LASER_SETTING_FAIL, false, ref m_arAlarmSubInfo);
                                    m_nSeqNum = (int)EN_POWER_MEASURE_STEP.ACTION_FINISH;
                                    break;
                            }
                            break;
                        case EN_TASK_ACTION.MEASURE_VOLT:
                            for (int nCh = 0; nCh < m_Laser.ChannelCount; ++nCh)
                            {
                                arUsed[nCh] = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.SHOT_PARAMETER_ENABLE_18.ToString(), nCh, EN_RECIPE_PARAM_TYPE.VALUE, false);
                            }
                            dOutput = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.POWER_MEASURE_VOLT.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                            switch (m_Laser.SetParameterVolt(arUsed, dOutput, nTime))
                            {
                                case ProtecLaserMananger.EN_SET_RESULT.OK:
                                    m_nSeqNum++;
                                    break;
                                case ProtecLaserMananger.EN_SET_RESULT.WORKING:
                                    if (EquipmentState_.EquipmentState.GetInstance().GetState() == EquipmentState_.EQUIPMENT_STATE.FINISHING)
                                        m_nSeqNum = (int)EN_POWER_MEASURE_STEP.ACTION_FINISH;
                                    break;
                                case ProtecLaserMananger.EN_SET_RESULT.POWER_OVER_MAX:
                                    m_arAlarmSubInfo[0] = "POWER IS TOO HIGH";
                                    m_arAlarmSubInfo[1] = "";
                                    GenerateSequenceAlarm((int)EN_TASK_ALARM.LD1_POWER_OVER_MAX, false, ref m_arAlarmSubInfo);
                                    m_nSeqNum = (int)EN_POWER_MEASURE_STEP.ACTION_FINISH;
                                    break;
                                case ProtecLaserMananger.EN_SET_RESULT.POWER_UNDER_MIN:
                                    m_arAlarmSubInfo[0] = "POWER IS TOO LOW";
                                    m_arAlarmSubInfo[1] = "";
                                    GenerateSequenceAlarm((int)EN_TASK_ALARM.LD1_POWER_UNDER_MIN, false, ref m_arAlarmSubInfo);
                                    m_nSeqNum = (int)EN_POWER_MEASURE_STEP.ACTION_FINISH;
                                    break;
                                default:
                                    m_arAlarmSubInfo[0] = "";
                                    m_arAlarmSubInfo[1] = "";
                                    GenerateSequenceAlarm((int)EN_TASK_ALARM.LD1_LASER_SETTING_FAIL, false, ref m_arAlarmSubInfo);
                                    m_nSeqNum = (int)EN_POWER_MEASURE_STEP.ACTION_FINISH;
                                    break;
                            }
                            break;

                        case EN_TASK_ACTION.CALIBRATION_CHANNEL_POWER:
                            for (int nCh = 0; nCh < m_Laser.ChannelCount; ++nCh)
                            {
                                if (m_nCalibrationChannel == nCh)
                                {
                                    arUsed[nCh] = true;
                                    m_nCalChannelAnalogInput = (int)EN_ANALOG_INPUT_LIST.LD_POWER_1 + nCh;
                                }
                                else
                                {
                                    arUsed[nCh] = false;
                                }
                            }
                            dOutput = m_arCalibrationStepVolt[m_nCalibrationCurrentStep];
                            switch (m_Laser.SetParameterVolt(arUsed, dOutput, nTime))
                            {
                                case ProtecLaserMananger.EN_SET_RESULT.OK:
                                    m_nSeqNum++;
                                    break;
                                case ProtecLaserMananger.EN_SET_RESULT.WORKING:
                                    if (EquipmentState_.EquipmentState.GetInstance().GetState() == EquipmentState_.EQUIPMENT_STATE.FINISHING)
                                        m_nSeqNum = (int)EN_POWER_MEASURE_STEP.ACTION_FINISH;
                                    break;
                                default:
                                    //alarm 추가
                                    break;
                            }
                            break;


                            //                         case EN_TASK_ACTION.CALIBRATION_POWER_LOSS_RATE:
                            //                             for (int nCh = 0; nCh < m_Laser.ChannelCount; ++nCh)
                            //                             {
                            //                                 arUsed[nCh] = false;
                            //                             }
                            //                             dOutput = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.POWER_MEASURE_VOLT.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                            //                             if (m_Laser.SetParameterVolt(arUsed, dOutput, nTime))
                            //                                 m_nSeqNum++;
                            //                             break;

                    }
                    break;
                case (int)EN_POWER_MEASURE_STEP.LASER_READY + 2:
                    #region SetSubSeqPara
                    SubSeqLaserWorkParam[] LaserWorkPara = new SubSeqLaserWorkParam[3];

                    for (int nPortIndex = 0; nPortIndex < 3; nPortIndex++)
                    {
                        //bLaserUsed = m_Recipe.GetValue(EN_RECIPE_TYPE.PROCESS, PARAM_PROCESS.LASER_USED.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, false);

                        LaserWorkPara[nPortIndex] = new SubSeqLaserWorkParam();
                        LaserWorkPara[nPortIndex].LaserUsed = true;
                        LaserWorkPara[nPortIndex].CurrentParamIndex = 1;
                        LaserWorkPara[nPortIndex].KeepLastValuePower = false;
                        LaserWorkPara[nPortIndex].KeepLastValueSizeX = true;
                        LaserWorkPara[nPortIndex].KeepLastValueSizeY = true;

                        LaserWorkPara[nPortIndex].ParamUsed[0] = true;
                        LaserWorkPara[nPortIndex].LaserSizeStepUsed[0] = false;
                        LaserWorkPara[nPortIndex].LaserSizeStepUsed[0] = false;

                        for (int nStep = 0; nStep < 5; ++nStep)
                        {
                            LaserWorkPara[nPortIndex].LaserPower[nStep, 0] = 0;
                            LaserWorkPara[nPortIndex].LaserTime[nStep, 0] = 0;

                            LaserWorkPara[nPortIndex].LaserPowerMode[nStep, 0] = EN_OUTPUT_MODE.STEP.ToString();
                            LaserWorkPara[nPortIndex].LaserSizeX[nStep, 0] = 0;
                            LaserWorkPara[nPortIndex].LaserSizeY[nStep, 0] = 0;
                            LaserWorkPara[nPortIndex].LaserSizeMode[nStep, 0] = EN_OUTPUT_MODE.STEP.ToString();
                        }
                        LaserWorkPara[nPortIndex].LaserTime[0, 0] = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.POWER_MEASURE_SHOT_TIME.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);

                    }

                    SubSeqLaserMonitorParam[] LaserMoinotrPara = new SubSeqLaserMonitorParam[20];
                    for (int nChCount = 0; nChCount < 18; nChCount++)
                    {
                        LaserMoinotrPara[nChCount] = new SubSeqLaserMonitorParam();
                        LaserMoinotrPara[nChCount].MonitorUsed = false;
                        LaserMoinotrPara[nChCount].MonitorPreDelay = 0;
                        LaserMoinotrPara[nChCount].MonitorPostDelay = 0;

                        if (nChCount < 5)//Temp Sensor는 5개
                        {
                            LaserMoinotrPara[nChCount].TempCheckUsed = true;
                            LaserMoinotrPara[nChCount].EMGTemp = 500;
                            LaserMoinotrPara[nChCount].AbortUsed = false;
                            LaserMoinotrPara[nChCount].AbortTemp = 500;
                        }
                        else
                        {
                            LaserMoinotrPara[nChCount].TempCheckUsed = false;
                            LaserMoinotrPara[nChCount].EMGTemp = 500;
                            LaserMoinotrPara[nChCount].AbortUsed = false;
                            LaserMoinotrPara[nChCount].AbortTemp = 500;
                        }

                        LaserMoinotrPara[nChCount].PowerCheckUsed = false;
                        LaserMoinotrPara[nChCount].PowerCheckTolerance = 0.1;
                    }

                    // WorkLog
                    LaserMoinotrPara[18] = new SubSeqLaserMonitorParam();
                    LaserMoinotrPara[18].MonitorUsed = false;

                    LaserMoinotrPara[19] = new SubSeqLaserMonitorParam();
                    LaserMoinotrPara[19].MonitorUsed = false;


                    m_Subseq_Laser_Work.AddMonitorParameter(LaserMoinotrPara);


                    m_Subseq_Laser_Work.Activate = true;
                    m_Subseq_Laser_Work.AddParameter(LaserWorkPara);
                    #endregion
                    Powermeter.GetInstance().SetCommand(EN_POWERMETER_COMMAND.START);
                    m_TickForDelay.SetTickCount(90);
                    m_nSeqNum = (int)EN_POWER_MEASURE_STEP.LASER_WORKING;
                    break;

                #endregion

                #region Laser Working
                case (int)EN_POWER_MEASURE_STEP.LASER_WORKING:
                    //m_nSeqNum++;
                    //             break;
                    switch (m_Subseq_Laser_Work.SubSequenceProcedure()) // 2025.4.7 by ecchoi [ADD] 출력 시간을 계산해서 합산한다
                    {
                        case EN_SUBSEQUENCE_RESULT.OK:
                            m_nSeqNum++;
                            break;

                        case EN_SUBSEQUENCE_RESULT.WORKING:
                            //CheckLaserWorkTool(); // 2025.4.5 by ecchoi [ADD] Test 후 복구?

                            if (m_TickForDelay.IsTickOver(true)
                               && (ReadOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_ON_PORT_1, false) //LASER ON 중에만 측정
                                    || ReadOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_ON_PORT_2, false)
                                    || ReadOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_ON_PORT_3, false)))
                            {
                                m_Laser.ReadMessage();// 출력 모니터링 통신 받기 위해. 실제 모니터링은 AnalogInput을 사용. Parsing 안함

                                m_lstCurrentVolt.Add(ReadAnalogInputVolt(m_nCalChannelAnalogInput));
                                // 2025.4.7 by ecchoi [ADD] 여기로 강제로 이동시켜서 test
                                if (ExternalDevice.Serial.Powermeter.GetInstance().RecieveDone)
                                {
                                    Powermeter.GetInstance().SetCommand(EN_POWERMETER_COMMAND.READ); 
                                }
                                m_TickForDelay.SetTickCount(90);
                            }

                            if (ReadInput((int)EN_DIGITAL_INPUT_LIST.LD_ALARM_PORT_1, false)
                                    || ReadInput((int)EN_DIGITAL_INPUT_LIST.LD_ALARM_PORT_2, false)
                                    || ReadInput((int)EN_DIGITAL_INPUT_LIST.LD_ALARM_PORT_3, false))
                            {
                                m_arAlarmSubInfo[0] = "DETECT ALARM FROM LASER SOURCE";
                                GenerateSequenceAlarm((int)EN_TASK_ALARM.LD1_LASER_EMISSION_ALARM, false, ref m_arAlarmSubInfo);
                                m_nSeqNum = (int)EN_POWER_MEASURE_STEP.ACTION_FINISH;
                                break;
                            }
                            break;

                        default:
                            m_arAlarmSubInfo[0] = m_Subseq_Laser_Work.GetActionResultInfo();
                            GenerateSequenceAlarm((int)EN_TASK_ALARM.LD1_LASER_EMISSION_ALARM, false, ref m_arAlarmSubInfo);
                            m_nSeqNum = (int)EN_POWER_MEASURE_STEP.ACTION_FINISH;
                            break;
                    }
                    break;
                case (int)EN_POWER_MEASURE_STEP.LASER_WORKING + 1:
                    Powermeter.GetInstance().SetCommand(EN_POWERMETER_COMMAND.STOP);
                    SetDelayForSequence(300);
                    m_nPowerMeasureCurrentRepeatCount++;
                    m_nSeqNum = (int)EN_POWER_MEASURE_STEP.CHECK_REPEAT;
                    break;
                #endregion

                case (int)EN_POWER_MEASURE_STEP.CHECK_REPEAT:
                    if (m_enAction == EN_TASK_ACTION.MEASURE_POWER
                            || m_enAction == EN_TASK_ACTION.MEASURE_VOLT)
                    {
                        if (m_nPowerMeasureCurrentRepeatCount >= m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.POWER_MEASURE_REPEAT_COUNT.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0))
                        {
                            m_nSeqNum = (int)EN_POWER_MEASURE_STEP.ACTION_FINISH;
                        }
                        else
                        {
                            int nRestTime = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.POWER_MEASURE_REST_TIME.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);
                            m_tickForPowerMeasureRest.SetTickCount((uint)nRestTime);
                            m_nSeqNum = (int)EN_POWER_MEASURE_STEP.LASER_READY;
                        }
                    }
                    else
                    {
                        if (m_nPowerMeasureCurrentRepeatCount >= m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.POWER_MEASURE_REPEAT_COUNT.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0))
                        {
                            m_nPowerMeasureCurrentRepeatCount = 0;
                            Powermeter.GetInstance().ClearRepeatData();
                            m_nSeqNum = (int)EN_POWER_MEASURE_STEP.SET_CALIBRATION_DATA;
                        }
                        else
                        {
                            int nRestTime = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.POWER_MEASURE_REST_TIME.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);
                            m_tickForPowerMeasureRest.SetTickCount((uint)nRestTime);
                            m_nSeqNum = (int)EN_POWER_MEASURE_STEP.LASER_READY;
                        }
                    }
                    break;


                case (int)EN_POWER_MEASURE_STEP.SET_CALIBRATION_DATA:
                    if (m_enAction == EN_TASK_ACTION.CALIBRATION_CHANNEL_POWER)
                    {
                        ProtecLaserChannelCalibration.GetInstance().UpdateCalibrationInformation(m_nCalibrationChannel, m_nCalibrationCurrentStep, (int)EN_CALIBRATION_INDEX.TARGET_VOLT, m_arCalibrationStepVolt[m_nCalibrationCurrentStep]);
                        ProtecLaserChannelCalibration.GetInstance().UpdateCalibrationInformation(m_nCalibrationChannel, m_nCalibrationCurrentStep, (int)EN_CALIBRATION_INDEX.POWER_OUTPUT_WATT, Powermeter.GetInstance().Measure_Repeat_Avg);
                        if (m_lstCurrentVolt.Count > 0)
                            ProtecLaserChannelCalibration.GetInstance().UpdateCalibrationInformation(m_nCalibrationChannel, m_nCalibrationCurrentStep, (int)EN_CALIBRATION_INDEX.POWER_INPUT_VOLT, m_lstCurrentVolt.Average());
                        m_lstCurrentVolt.Clear();

                        PostOffice.GetInstance().SendMail(EN_SUBSCRIBER.Unknown, EN_SUBSCRIBER.SETUP_EQUP_LASER, EN_MAIL.UPDATE_UI); //Caldata UI 통지

                        m_nCalibrationCurrentStep++;
                        //다음 Step 측정
                        if (m_nCalibrationStep > m_nCalibrationCurrentStep)
                        {
                            int nRestTime = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.POWER_MEASURE_REST_TIME.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);
                            m_tickForPowerMeasureRest.SetTickCount((uint)nRestTime);
                            m_nSeqNum = (int)EN_POWER_MEASURE_STEP.LASER_READY;
                            break;
                        }
                        else
                        {
                            //다음 channel 측정
                            for (int nCh = 0; nCh < m_Laser.ChannelCount; ++nCh)
                            {
                                if (m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.SHOT_PARAMETER_ENABLE_18.ToString(), nCh, EN_RECIPE_PARAM_TYPE.VALUE, false))
                                {
                                    if (m_nCalibrationChannel < nCh)
                                    {
                                        m_nCalibrationCurrentStep = 0;
                                        m_nCalibrationChannel = nCh;
                                        ProtecLaserChannelCalibration.GetInstance().NewChannelCalibrationFile(m_nCalibrationChannel);

                                        int nRestTime = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.POWER_MEASURE_REST_TIME.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);
                                        m_tickForPowerMeasureRest.SetTickCount((uint)nRestTime);
                                        m_nSeqNum = (int)EN_POWER_MEASURE_STEP.MOVE_SHOT_POSITION;
                                        return false;
                                    }
                                }
                            }
                        }
                    }
                    if (m_enAction == EN_TASK_ACTION.CALIBRATION_POWER_LOSS_RATE)
                    {
                        //구현 필요
                    }
                    m_nSeqNum = (int)EN_POWER_MEASURE_STEP.ACTION_FINISH;
                    break;


                case (int)EN_POWER_MEASURE_STEP.ACTION_FINISH:
                    
                        m_nSeqNum++;
                    break;

                case (int)EN_POWER_MEASURE_STEP.ACTION_FINISH + 1:
                    
                        m_nSeqNum = (int)EN_POWER_MEASURE_STEP.FINISH;
                    break;

                case (int)EN_POWER_MEASURE_STEP.FINISH:
                    return true;
            }
            return false;
        }

        private bool Action_PowerMeasure_2()
        {
            switch (m_nSeqNum)
            {
                case (int)EN_POWER_MEASURE_STEP_2.ACTION_START:
                    Powermeter.GetInstance().Open();
                    SetDelayForSequence(1000);
                    ++m_nSeqNum;
                    break;
                case (int)EN_POWER_MEASURE_STEP_2.ACTION_START + 1:
                    if (m_enAction == EN_TASK_ACTION.CALIBRATION_CHANNEL_POWER_2)
                        InitializeCalibrationData_2();
                    m_nPowerMeasureCurrentRepeatCount = 0;
                    m_lstCurrentVolt.Clear();
                    m_tickForPowerMeasureRest.SetTickCount(1);
                    m_nSeqNum = (int)EN_POWER_MEASURE_STEP_2.POWERMETER_READY;
                    break;

                case (int)EN_POWER_MEASURE_STEP_2.POWERMETER_READY:
                    Powermeter.GetInstance().ClearRepeatData();
                    Powermeter.GetInstance().nWait_Time = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.POWER_MEASURE_2_WAIT_TIME.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);
                    ++m_nSeqNum;
                    break;

                case (int)EN_POWER_MEASURE_STEP_2.POWERMETER_READY + 1:
                    Powermeter.GetInstance().SetCommand(EN_POWERMETER_COMMAND.HANDCHECKING_OFF);
                    SetDelayForSequence(300);
                    m_nSeqNum++;
                    break;
                case (int)EN_POWER_MEASURE_STEP_2.POWERMETER_READY + 2:
                    Powermeter.GetInstance().SetCommand(EN_POWERMETER_COMMAND.RECIEVE_LAST);
                    SetDelayForSequence(300);
                    m_nSeqNum++;
                    break;
                case (int)EN_POWER_MEASURE_STEP_2.POWERMETER_READY + 3:
                    Powermeter.GetInstance().SetCommand(EN_POWERMETER_COMMAND.RECIEVE_ONLY_POWER);
                    SetDelayForSequence(300);
                    m_nSeqNum++;
                    break;
                case (int)EN_POWER_MEASURE_STEP_2.POWERMETER_READY + 4:
                    Powermeter.GetInstance().SetCommand(EN_POWERMETER_COMMAND.ERROR_CLEAR);
                    SetDelayForSequence(300);
                    m_nSeqNum++;
                    break;
                case (int)EN_POWER_MEASURE_STEP_2.POWERMETER_READY + 5:
                    m_nSeqNum = (int)EN_POWER_MEASURE_STEP_2.MOVE_SHOT_POSITION;
                    break;

                #region MOVE SHOT POSITION
                case (int)EN_POWER_MEASURE_STEP_2.MOVE_SHOT_POSITION:
                    switch (m_enAction)
                    {
                        case EN_TASK_ACTION.MEASURE_POWER_2:
                        case EN_TASK_ACTION.MEASURE_VOLT_2:
                        case EN_TASK_ACTION.CALIBRATION_POWER_LOSS_RATE_2:
                            int ChMeasureCount = 0;
                            int nMeasureCh = 0;
                            for (int nCh = 0; nCh < m_Laser_2.ChannelCount; ++nCh)
                            {
                                if (m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.SHOT_PARAMETER_2_ENABLE_18.ToString(), nCh, EN_RECIPE_PARAM_TYPE.VALUE, false))
                                {
                                    ChMeasureCount++;
                                    nMeasureCh = nCh;
                                }
                            }
                            if (ChMeasureCount > 1)
                                nMeasureCh = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.POWER_MEASURE_2_SELLECTED_CHANNEL.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0) - 1;

                            break;

                        case EN_TASK_ACTION.CALIBRATION_CHANNEL_POWER_2:
                            break;
                    }

                    m_nSeqNum = (int)EN_POWER_MEASURE_STEP_2.LASER_READY;

                    break;
                #endregion

                #region LASER READY SUB SEQ
                case (int)EN_POWER_MEASURE_STEP_2.LASER_READY:
                    if (EquipmentState_.EquipmentState.GetInstance().GetState() == EquipmentState_.EQUIPMENT_STATE.FINISHING)
                        m_nSeqNum = (int)EN_POWER_MEASURE_STEP_2.ACTION_FINISH;
                    if (m_tickForPowerMeasureRest.IsTickOver(true))
                    {
                        int nRestTime = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.POWER_MEASURE_2_REST_TIME.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);

                        m_tickForPowerMeasureRest.SetTickCount((uint)nRestTime);
                        m_tickTimeOut.SetTickCount(2000);
                        m_nSeqNum++;
                    }
                    break;
                case (int)EN_POWER_MEASURE_STEP_2.LASER_READY + 1:

                    if (m_tickTimeOut.IsTickOver(false))
                    {
                        m_arAlarmSubInfo[0] = "";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.LD1_COMMNUNICATION_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_nSeqNum = (int)EN_POWER_MEASURE_STEP_2.ACTION_FINISH;
                        break;
                    }
                    bool[] arUsed = new bool[m_Laser_2.ChannelCount];
                    int nTime = 0;
                    double dOutput = 0;

                    nTime = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.POWER_MEASURE_2_SHOT_TIME.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);

                    switch (m_enAction)
                    {
                        case EN_TASK_ACTION.MEASURE_POWER_2:
                            for (int nCh = 0; nCh < m_Laser_2.ChannelCount; ++nCh)
                            {
                                arUsed[nCh] = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.SHOT_PARAMETER_2_ENABLE_18.ToString(), nCh, EN_RECIPE_PARAM_TYPE.VALUE, false);
                            }
                            dOutput = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.POWER_MEASURE_WATT.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                            switch (m_Laser_2.SetParameter(arUsed, dOutput, nTime))
                            {
                                case ProtecLaserMananger_2.EN_SET_RESULT_2.OK:
                                    m_nSeqNum++;
                                    break;
                                case ProtecLaserMananger_2.EN_SET_RESULT_2.WORKING:
                                    if (EquipmentState_.EquipmentState.GetInstance().GetState() == EquipmentState_.EQUIPMENT_STATE.FINISHING)
                                        m_nSeqNum = (int)EN_POWER_MEASURE_STEP_2.ACTION_FINISH;
                                    break;
                                case ProtecLaserMananger_2.EN_SET_RESULT_2.POWER_OVER_MAX:
                                    m_arAlarmSubInfo[0] = "POWER IS TOO HIGH";
                                    m_arAlarmSubInfo[1] = "";
                                    GenerateSequenceAlarm((int)EN_TASK_ALARM.LD2_POWER_OVER_MAX, false, ref m_arAlarmSubInfo);
                                    m_nSeqNum = (int)EN_POWER_MEASURE_STEP_2.ACTION_FINISH;
                                    break;
                                case ProtecLaserMananger_2.EN_SET_RESULT_2.POWER_UNDER_MIN:
                                    m_arAlarmSubInfo[0] = "POWER IS TOO LOW";
                                    m_arAlarmSubInfo[1] = "";
                                    GenerateSequenceAlarm((int)EN_TASK_ALARM.LD2_POWER_UNDER_MIN, false, ref m_arAlarmSubInfo);
                                    m_nSeqNum = (int)EN_POWER_MEASURE_STEP_2.ACTION_FINISH;
                                    break;
                                default:
                                    m_arAlarmSubInfo[0] = "";
                                    m_arAlarmSubInfo[1] = "";
                                    GenerateSequenceAlarm((int)EN_TASK_ALARM.LD2_LASER_SETTING_FAIL, false, ref m_arAlarmSubInfo);
                                    m_nSeqNum = (int)EN_POWER_MEASURE_STEP_2.ACTION_FINISH;
                                    break;
                            }
                            break;
                        case EN_TASK_ACTION.MEASURE_VOLT_2:
                            for (int nCh = 0; nCh < m_Laser_2.ChannelCount; ++nCh)
                            {
                                arUsed[nCh] = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.SHOT_PARAMETER_2_ENABLE_18.ToString(), nCh, EN_RECIPE_PARAM_TYPE.VALUE, false);
                            }
                            dOutput = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.POWER_MEASURE_VOLT.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                            switch (m_Laser_2.SetParameterVolt(arUsed, dOutput, nTime))
                            {
                                case ProtecLaserMananger_2.EN_SET_RESULT_2.OK:
                                    m_nSeqNum++;
                                    break;
                                case ProtecLaserMananger_2.EN_SET_RESULT_2.WORKING:
                                    if (EquipmentState_.EquipmentState.GetInstance().GetState() == EquipmentState_.EQUIPMENT_STATE.FINISHING)
                                        m_nSeqNum = (int)EN_POWER_MEASURE_STEP_2.ACTION_FINISH;
                                    break;
                                case ProtecLaserMananger_2.EN_SET_RESULT_2.POWER_OVER_MAX:
                                    m_arAlarmSubInfo[0] = "POWER IS TOO HIGH";
                                    m_arAlarmSubInfo[1] = "";
                                    GenerateSequenceAlarm((int)EN_TASK_ALARM.LD2_POWER_OVER_MAX, false, ref m_arAlarmSubInfo);
                                    m_nSeqNum = (int)EN_POWER_MEASURE_STEP_2.ACTION_FINISH;
                                    break;
                                case ProtecLaserMananger_2.EN_SET_RESULT_2.POWER_UNDER_MIN:
                                    m_arAlarmSubInfo[0] = "POWER IS TOO LOW";
                                    m_arAlarmSubInfo[1] = "";
                                    GenerateSequenceAlarm((int)EN_TASK_ALARM.LD2_POWER_UNDER_MIN, false, ref m_arAlarmSubInfo);
                                    m_nSeqNum = (int)EN_POWER_MEASURE_STEP_2.ACTION_FINISH;
                                    break;
                                default:
                                    m_arAlarmSubInfo[0] = "";
                                    m_arAlarmSubInfo[1] = "";
                                    GenerateSequenceAlarm((int)EN_TASK_ALARM.LD2_LASER_SETTING_FAIL, false, ref m_arAlarmSubInfo);
                                    m_nSeqNum = (int)EN_POWER_MEASURE_STEP_2.ACTION_FINISH;
                                    break;
                            }
                            break;

                        case EN_TASK_ACTION.CALIBRATION_CHANNEL_POWER_2:
                            for (int nCh = 0; nCh < m_Laser_2.ChannelCount; ++nCh)
                            {
                                if (m_nCalibrationChannel == nCh)
                                {
                                    arUsed[nCh] = true;
                                    m_nCalChannelAnalogInput = (int)EN_ANALOG_INPUT_LIST.LD_2_POWER_1 + nCh;
                                }
                                else
                                {
                                    arUsed[nCh] = false;
                                }
                            }
                            dOutput = m_arCalibrationStepVolt[m_nCalibrationCurrentStep];
                            switch (m_Laser_2.SetParameterVolt(arUsed, dOutput, nTime))
                            {
                                case ProtecLaserMananger_2.EN_SET_RESULT_2.OK:
                                    m_nSeqNum++;
                                    break;
                                case ProtecLaserMananger_2.EN_SET_RESULT_2.WORKING:
                                    if (EquipmentState_.EquipmentState.GetInstance().GetState() == EquipmentState_.EQUIPMENT_STATE.FINISHING)
                                        m_nSeqNum = (int)EN_POWER_MEASURE_STEP_2.ACTION_FINISH;
                                    break;
                                default:
                                    //alarm 추가
                                    break;
                            }
                            break;


                            //                         case EN_TASK_ACTION.CALIBRATION_POWER_LOSS_RATE:
                            //                             for (int nCh = 0; nCh < m_Laser_2.ChannelCount; ++nCh)
                            //                             {
                            //                                 arUsed[nCh] = false;
                            //                             }
                            //                             dOutput = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.POWER_MEASURE_VOLT.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                            //                             if (m_Laser_2.SetParameterVolt(arUsed, dOutput, nTime))
                            //                                 m_nSeqNum++;
                            //                             break;

                    }
                    break;
                case (int)EN_POWER_MEASURE_STEP_2.LASER_READY + 2:
                    #region SetSubSeqPara
                    SubSeqLaserWorkParam[] LaserWorkPara = new SubSeqLaserWorkParam[3];

                    for (int nPortIndex = 0; nPortIndex < 3; nPortIndex++)
                    {
                        //bLaserUsed = m_Recipe.GetValue(EN_RECIPE_TYPE.PROCESS, PARAM_PROCESS.LASER_USED.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, false);

                        LaserWorkPara[nPortIndex] = new SubSeqLaserWorkParam();
                        LaserWorkPara[nPortIndex].LaserUsed = true;
                        LaserWorkPara[nPortIndex].CurrentParamIndex = 1;
                        LaserWorkPara[nPortIndex].KeepLastValuePower = false;
                        LaserWorkPara[nPortIndex].KeepLastValueSizeX = true;
                        LaserWorkPara[nPortIndex].KeepLastValueSizeY = true;

                        LaserWorkPara[nPortIndex].ParamUsed[0] = true;
                        LaserWorkPara[nPortIndex].LaserSizeStepUsed[0] = false;
                        LaserWorkPara[nPortIndex].LaserSizeStepUsed[0] = false;

                        for (int nStep = 0; nStep < 5; ++nStep)
                        {
                            LaserWorkPara[nPortIndex].LaserPower[nStep, 0] = 0;
                            LaserWorkPara[nPortIndex].LaserTime[nStep, 0] = 0;

                            LaserWorkPara[nPortIndex].LaserPowerMode[nStep, 0] = EN_OUTPUT_MODE.STEP.ToString();
                            LaserWorkPara[nPortIndex].LaserSizeX[nStep, 0] = 0;
                            LaserWorkPara[nPortIndex].LaserSizeY[nStep, 0] = 0;
                            LaserWorkPara[nPortIndex].LaserSizeMode[nStep, 0] = EN_OUTPUT_MODE.STEP.ToString();
                        }
                        LaserWorkPara[nPortIndex].LaserTime[0, 0] = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.POWER_MEASURE_2_SHOT_TIME.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);

                    }

                    SubSeqLaserMonitorParam[] LaserMoinotrPara = new SubSeqLaserMonitorParam[20];
                    for (int nChCount = 0; nChCount < 18; nChCount++)
                    {
                        LaserMoinotrPara[nChCount] = new SubSeqLaserMonitorParam();
                        LaserMoinotrPara[nChCount].MonitorUsed = false;
                        LaserMoinotrPara[nChCount].MonitorPreDelay = 0;
                        LaserMoinotrPara[nChCount].MonitorPostDelay = 0;

                        if (nChCount < 5)//Temp Sensor는 5개
                        {
                            LaserMoinotrPara[nChCount].TempCheckUsed = true;
                            LaserMoinotrPara[nChCount].EMGTemp = 500;
                            LaserMoinotrPara[nChCount].AbortUsed = false;
                            LaserMoinotrPara[nChCount].AbortTemp = 500;
                        }
                        else
                        {
                            LaserMoinotrPara[nChCount].TempCheckUsed = false;
                            LaserMoinotrPara[nChCount].EMGTemp = 500;
                            LaserMoinotrPara[nChCount].AbortUsed = false;
                            LaserMoinotrPara[nChCount].AbortTemp = 500;
                        }

                        LaserMoinotrPara[nChCount].PowerCheckUsed = false;
                        LaserMoinotrPara[nChCount].PowerCheckTolerance = 0.1;
                    }

                    // WorkLog
                    LaserMoinotrPara[18] = new SubSeqLaserMonitorParam();
                    LaserMoinotrPara[18].MonitorUsed = false;

                    LaserMoinotrPara[19] = new SubSeqLaserMonitorParam();
                    LaserMoinotrPara[19].MonitorUsed = false;


                    m_Subseq_Laser_Work_2.AddMonitorParameter(LaserMoinotrPara);


                    m_Subseq_Laser_Work_2.Activate = true;
                    m_Subseq_Laser_Work_2.AddParameter(LaserWorkPara);
                    #endregion
                    Powermeter.GetInstance().SetCommand(EN_POWERMETER_COMMAND.START);
                    m_TickForDelay.SetTickCount(90);
                    m_nSeqNum = (int)EN_POWER_MEASURE_STEP_2.LASER_WORKING;
                    break;

                #endregion

                #region Laser Working
                case (int)EN_POWER_MEASURE_STEP_2.LASER_WORKING:
                    //m_nSeqNum++;
                    //             break;
                    switch (m_Subseq_Laser_Work_2.SubSequenceProcedure())
                    {
                        case EN_SUBSEQUENCE_RESULT.OK:
                            m_nSeqNum++;
                            break;

                        case EN_SUBSEQUENCE_RESULT.WORKING:
                            //CheckLaserWorkTool();

                            if (m_TickForDelay.IsTickOver(true)
                               && (ReadOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_2_ON_PORT_1, false) //LASER ON 중에만 측정
                                    || ReadOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_2_ON_PORT_2, false)
                                    || ReadOutput((int)EN_DIGITAL_OUTPUT_LIST.LD_2_ON_PORT_3, false)))
                            {
                                m_Laser_2.ReadMessage();// 출력 모니터링 통신 받기 위해. 실제 모니터링은 AnalogInput을 사용. Parsing 안함

                                m_lstCurrentVolt.Add(ReadAnalogInputVolt(m_nCalChannelAnalogInput));

                                if (ExternalDevice.Serial.Powermeter.GetInstance().RecieveDone)
                                {
                                    Powermeter.GetInstance().SetCommand(EN_POWERMETER_COMMAND.READ);
                                }
                                m_TickForDelay.SetTickCount(90);
                            }

                            if (ReadInput((int)EN_DIGITAL_INPUT_LIST.LD_2_ALARM_PORT_1, false)
                                    || ReadInput((int)EN_DIGITAL_INPUT_LIST.LD_2_ALARM_PORT_2, false)
                                    || ReadInput((int)EN_DIGITAL_INPUT_LIST.LD_2_ALARM_PORT_3, false))
                            {
                                m_arAlarmSubInfo[0] = "DETECT ALARM FROM LASER SOURCE";
                                GenerateSequenceAlarm((int)EN_TASK_ALARM.LD1_LASER_EMISSION_ALARM, false, ref m_arAlarmSubInfo);
                                m_nSeqNum = (int)EN_POWER_MEASURE_STEP_2.ACTION_FINISH;
                                break;
                            }
                            break;

                        default:
                            m_arAlarmSubInfo[0] = m_Subseq_Laser_Work_2.GetActionResultInfo();
                            GenerateSequenceAlarm((int)EN_TASK_ALARM.LD1_LASER_EMISSION_ALARM, false, ref m_arAlarmSubInfo);
                            m_nSeqNum = (int)EN_POWER_MEASURE_STEP_2.ACTION_FINISH;
                            break;
                    }
                    break;
                case (int)EN_POWER_MEASURE_STEP_2.LASER_WORKING + 1:
                    Powermeter.GetInstance().SetCommand(EN_POWERMETER_COMMAND.STOP);
                    SetDelayForSequence(300);
                    m_nPowerMeasureCurrentRepeatCount++;
                    m_nSeqNum = (int)EN_POWER_MEASURE_STEP_2.CHECK_REPEAT;
                    break;
                #endregion

                case (int)EN_POWER_MEASURE_STEP_2.CHECK_REPEAT:
                    if (m_enAction == EN_TASK_ACTION.MEASURE_POWER_2
                            || m_enAction == EN_TASK_ACTION.MEASURE_VOLT_2)
                    {
                        if (m_nPowerMeasureCurrentRepeatCount >= m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.POWER_MEASURE_2_REPEAT_COUNT.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0))
                        {
                            m_nSeqNum = (int)EN_POWER_MEASURE_STEP_2.ACTION_FINISH;
                        }
                        else
                        {
                            int nRestTime = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.POWER_MEASURE_2_REST_TIME.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);
                            m_tickForPowerMeasureRest.SetTickCount((uint)nRestTime);
                            m_nSeqNum = (int)EN_POWER_MEASURE_STEP_2.LASER_READY;
                        }
                    }
                    else
                    {
                        if (m_nPowerMeasureCurrentRepeatCount >= m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.POWER_MEASURE_2_REPEAT_COUNT.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0))
                        {
                            m_nPowerMeasureCurrentRepeatCount = 0;
                            Powermeter.GetInstance().ClearRepeatData();
                            m_nSeqNum = (int)EN_POWER_MEASURE_STEP_2.SET_CALIBRATION_DATA;
                        }
                        else
                        {
                            int nRestTime = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.POWER_MEASURE_2_REST_TIME.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);
                            m_tickForPowerMeasureRest.SetTickCount((uint)nRestTime);
                            m_nSeqNum = (int)EN_POWER_MEASURE_STEP_2.LASER_READY;
                        }
                    }
                    break;


                case (int)EN_POWER_MEASURE_STEP_2.SET_CALIBRATION_DATA:
                    if (m_enAction == EN_TASK_ACTION.CALIBRATION_CHANNEL_POWER_2)
                    {
                        ProtecLaserChannelCalibration_2.GetInstance().UpdateCalibrationInformation(m_nCalibrationChannel, m_nCalibrationCurrentStep, (int)EN_CALIBRATION_INDEX.TARGET_VOLT, m_arCalibrationStepVolt[m_nCalibrationCurrentStep]);
                        ProtecLaserChannelCalibration_2.GetInstance().UpdateCalibrationInformation(m_nCalibrationChannel, m_nCalibrationCurrentStep, (int)EN_CALIBRATION_INDEX.POWER_OUTPUT_WATT, Powermeter.GetInstance().Measure_Repeat_Avg);
                        if (m_lstCurrentVolt.Count > 0)
                            ProtecLaserChannelCalibration_2.GetInstance().UpdateCalibrationInformation(m_nCalibrationChannel, m_nCalibrationCurrentStep, (int)EN_CALIBRATION_INDEX.POWER_INPUT_VOLT, m_lstCurrentVolt.Average());
                        m_lstCurrentVolt.Clear();

                        PostOffice.GetInstance().SendMail(EN_SUBSCRIBER.Unknown, EN_SUBSCRIBER.SETUP_EQUP_LASER, EN_MAIL.UPDATE_UI); //Caldata UI 통지

                        m_nCalibrationCurrentStep++;
                        //다음 Step 측정
                        if (m_nCalibrationStep > m_nCalibrationCurrentStep)
                        {
                            int nRestTime = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.POWER_MEASURE_2_REST_TIME.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);
                            m_tickForPowerMeasureRest.SetTickCount((uint)nRestTime);
                            m_nSeqNum = (int)EN_POWER_MEASURE_STEP_2.LASER_READY;
                            break;
                        }
                        else
                        {
                            //다음 channel 측정
                            for (int nCh = 0; nCh < m_Laser_2.ChannelCount; ++nCh)
                            {
                                if (m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.SHOT_PARAMETER_ENABLE_18.ToString(), nCh, EN_RECIPE_PARAM_TYPE.VALUE, false))
                                {
                                    if (m_nCalibrationChannel < nCh)
                                    {
                                        m_nCalibrationCurrentStep = 0;
                                        m_nCalibrationChannel = nCh;
                                        ProtecLaserChannelCalibration_2.GetInstance().NewChannelCalibrationFile(m_nCalibrationChannel);

                                        int nRestTime = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.POWER_MEASURE_2_REST_TIME.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0);
                                        m_tickForPowerMeasureRest.SetTickCount((uint)nRestTime);
                                        m_nSeqNum = (int)EN_POWER_MEASURE_STEP_2.MOVE_SHOT_POSITION;
                                        return false;
                                    }
                                }
                            }
                        }
                    }
                    if (m_enAction == EN_TASK_ACTION.CALIBRATION_POWER_LOSS_RATE_2)
                    {
                        //구현 필요
                    }
                    m_nSeqNum = (int)EN_POWER_MEASURE_STEP_2.ACTION_FINISH;
                    break;


                case (int)EN_POWER_MEASURE_STEP_2.ACTION_FINISH:

                    m_nSeqNum++;
                    break;

                case (int)EN_POWER_MEASURE_STEP_2.ACTION_FINISH + 1:

                    m_nSeqNum = (int)EN_POWER_MEASURE_STEP_2.FINISH;
                    break;

                case (int)EN_POWER_MEASURE_STEP_2.FINISH:
                    return true;
            }
            return false;
        }

        private bool ActionShortCheck()
        {
            switch (m_nSeqNum)
            {
                #region ACTION START (0 ~ )
                case (int)EN_LASER_SHORT_TEST_STEP.ACTION_START:
                    m_nSeqNum = (int)EN_LASER_SHORT_TEST_STEP.SHORT_TEST;
                    break;
                #endregion

                #region SHORT CHECK
                case (int)EN_LASER_SHORT_TEST_STEP.SHORT_TEST:
                    m_tickTimeOut.SetTickCount(60000);
                    m_nSeqNum++;
                    break;

                case (int)EN_LASER_SHORT_TEST_STEP.SHORT_TEST + 1:
                    if (m_tickTimeOut.IsTickOver(false))
                    {
                        m_arAlarmSubInfo[0] = "SHORT CHECK";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.LD1_COMMNUNICATION_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_nSeqNum = (int)EN_LASER_SHORT_TEST_STEP.ACTION_FINISH;
                        break;
                    }
                    bool[] arUsed = new bool[m_Laser.ChannelCount];

                    for (int nCh = 0; nCh < m_Laser.ChannelCount; ++nCh)
                    {
                        arUsed[nCh] = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.SHOT_PARAMETER_ENABLE_18.ToString(), nCh, EN_RECIPE_PARAM_TYPE.VALUE, false);
                    }

                    switch (m_Laser.CheckShort(arUsed))
                    {
                        case ProtecLaserMananger.EN_SET_RESULT.OK:
                            m_nSeqNum = (int)EN_LASER_SHORT_TEST_STEP.ACTION_FINISH;
                            break;
                        case ProtecLaserMananger.EN_SET_RESULT.WORKING:
                            if (EquipmentState_.EquipmentState.GetInstance().GetState() == EquipmentState_.EQUIPMENT_STATE.FINISHING)
                                m_nSeqNum = (int)EN_LASER_SHORT_TEST_STEP.ACTION_FINISH;
                            break;
                        default:
                            m_arAlarmSubInfo[0] = "";
                            m_arAlarmSubInfo[1] = "";
                            GenerateSequenceAlarm((int)EN_TASK_ALARM.LD1_SHORT_CHECK_FAIL, false, ref m_arAlarmSubInfo);
                            m_nSeqNum = (int)EN_LASER_SHORT_TEST_STEP.ACTION_FINISH;
                            break;
                    }
                    break;



                #endregion

                #region ACTION FINISH (9900 ~ )
                case (int)EN_LASER_SHORT_TEST_STEP.ACTION_FINISH:
                    m_nSeqNum = (int)EN_LASER_SHORT_TEST_STEP.FINISH;
                    break;
                #endregion

                #region FINISH
                case (int)EN_LASER_SHORT_TEST_STEP.FINISH:
                    return true;
                    #endregion
            }

            return false;
        }

        private bool ActionShortCheck_2()
        {
            switch (m_nSeqNum)
            {
                #region ACTION START (0 ~ )
                case (int)EN_LASER_SHORT_TEST_STEP_2.ACTION_START:
                    m_nSeqNum = (int)EN_LASER_SHORT_TEST_STEP_2.SHORT_TEST;
                    break;
                #endregion

                #region SHORT CHECK
                case (int)EN_LASER_SHORT_TEST_STEP_2.SHORT_TEST:
                    m_tickTimeOut.SetTickCount(60000);
                    m_nSeqNum++;
                    break;

                case (int)EN_LASER_SHORT_TEST_STEP_2.SHORT_TEST + 1:
                    if (m_tickTimeOut.IsTickOver(false))
                    {
                        m_arAlarmSubInfo[0] = "SHORT CHECK";
                        GenerateSequenceAlarm((int)EN_TASK_ALARM.LD1_COMMNUNICATION_TIMEOUT, false, ref m_arAlarmSubInfo);
                        m_nSeqNum = (int)EN_LASER_SHORT_TEST_STEP_2.ACTION_FINISH;
                        break;
                    }
                    bool[] arUsed = new bool[m_Laser_2.ChannelCount];

                    for (int nCh = 0; nCh < m_Laser_2.ChannelCount; ++nCh)
                    {
                        arUsed[nCh] = m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.SHOT_PARAMETER_2_ENABLE_18.ToString(), nCh, EN_RECIPE_PARAM_TYPE.VALUE, false);
                    }

                    switch (m_Laser_2.CheckShort(arUsed))
                    {
                        case ProtecLaserMananger_2.EN_SET_RESULT_2.OK:
                            m_nSeqNum = (int)EN_LASER_SHORT_TEST_STEP_2.ACTION_FINISH;
                            break;
                        case ProtecLaserMananger_2.EN_SET_RESULT_2.WORKING:
                            if (EquipmentState_.EquipmentState.GetInstance().GetState() == EquipmentState_.EQUIPMENT_STATE.FINISHING)
                                m_nSeqNum = (int)EN_LASER_SHORT_TEST_STEP_2.ACTION_FINISH;
                            break;
                        default:
                            m_arAlarmSubInfo[0] = "";
                            m_arAlarmSubInfo[1] = "";
                            GenerateSequenceAlarm((int)EN_TASK_ALARM.LD1_SHORT_CHECK_FAIL, false, ref m_arAlarmSubInfo);
                            m_nSeqNum = (int)EN_LASER_SHORT_TEST_STEP_2.ACTION_FINISH;
                            break;
                    }
                    break;



                #endregion

                #region ACTION FINISH (9900 ~ )
                case (int)EN_LASER_SHORT_TEST_STEP.ACTION_FINISH:
                    m_nSeqNum = (int)EN_LASER_SHORT_TEST_STEP.FINISH;
                    break;
                #endregion

                #region FINISH
                case (int)EN_LASER_SHORT_TEST_STEP.FINISH:
                    return true;
                    #endregion
            }

            return false;
        }

        //private bool ActionMoveReady()
        //{
        //    switch (m_nSeqNum)
        //    {
        //        #region ACTION START (0 ~ )
        //        case (int)EN_LASER_WORK_STEP.ACTION_START:
        //            m_nSeqNum = (int)EN_LASER_WORK_STEP.MOVE_POS;
        //            break;
        //        #endregion

        //        #region MOVE
        //        case (int)EN_LASER_WORK_STEP.MOVE_POS:
        //            if (MoveReadyPosition())
        //                m_nSeqNum++;
        //            break;
        //        case (int)EN_LASER_WORK_STEP.MOVE_POS + 1:
        //            m_nSeqNum = (int)EN_LASER_WORK_STEP.FINISH;
        //            break;
        //        #endregion

        //        #region FINISH
        //        case (int)EN_LASER_WORK_STEP.FINISH:
        //            return true;
        //            #endregion
        //    }

        //    return false;
        //}
        #endregion
        #endregion Action Sequence List

        #region Calibration Data
        private void InitializeCalibrationData()
        {
            m_nCalibrationChannel = 0;
            m_nCalibrationCurrentStep = 0;
            for (int nCh = 0; nCh < m_Laser.ChannelCount; ++nCh)
            {
                if (m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.SHOT_PARAMETER_ENABLE_18.ToString(), nCh, EN_RECIPE_PARAM_TYPE.VALUE, false))
                {
                    m_nCalibrationChannel = nCh;
                    break;
                }
            }

            ProtecLaserChannelCalibration.GetInstance().NewChannelCalibrationFile(m_nCalibrationChannel);


            m_nCalibrationStep = m_Recipe.GetValue(GetTaskName()
                , PARAM_PROCESS.POWER_CALIBRATION_STEP_COUNT.ToString()
                , 0
                , EN_RECIPE_PARAM_TYPE.VALUE
                , 1);

            m_arCalibrationStepVolt = new double[m_nCalibrationStep];
            double dblCalMaxVolt = m_Recipe.GetValue(GetTaskName()
                , PARAM_PROCESS.POWER_CALIBRATION_MAX_VOLT.ToString()
                , 0
                , EN_RECIPE_PARAM_TYPE.VALUE
                , -1.0);
            double dblCalMinVolt = m_Recipe.GetValue(GetTaskName()
                , PARAM_PROCESS.POWER_CALIBRATION_MIN_VOLT.ToString()
                , 0
                , EN_RECIPE_PARAM_TYPE.VALUE
                , -1.0);

            double dblCalStepVolt;
            if (m_nCalibrationStep == 1)
                dblCalStepVolt = 0;
            else
                dblCalStepVolt = (dblCalMaxVolt - dblCalMinVolt) / (m_nCalibrationStep - 1);

            for (int i = 0; i < m_nCalibrationStep; i++)
            {
                m_arCalibrationStepVolt[i] = dblCalMinVolt + (i * dblCalStepVolt);
            }
        }
        private void InitializeCalibrationData_2()
        {
            m_nCalibrationChannel = 0;
            m_nCalibrationCurrentStep = 0;
            for (int nCh = 0; nCh < m_Laser_2.ChannelCount; ++nCh)
            {
                if (m_Recipe.GetValue(GetTaskName(), PARAM_PROCESS.SHOT_PARAMETER_2_ENABLE_18.ToString(), nCh, EN_RECIPE_PARAM_TYPE.VALUE, false))
                {
                    m_nCalibrationChannel = nCh;
                    break;
                }
            }

            ProtecLaserChannelCalibration_2.GetInstance().NewChannelCalibrationFile(m_nCalibrationChannel);


            m_nCalibrationStep = m_Recipe.GetValue(GetTaskName()
                , PARAM_PROCESS.POWER_CALIBRATION_2_STEP_COUNT.ToString()
                , 0
                , EN_RECIPE_PARAM_TYPE.VALUE
                , 1);

            m_arCalibrationStepVolt = new double[m_nCalibrationStep];
            double dblCalMaxVolt = m_Recipe.GetValue(GetTaskName()
                , PARAM_PROCESS.POWER_CALIBRATION_2_MAX_VOLT.ToString()
                , 0
                , EN_RECIPE_PARAM_TYPE.VALUE
                , -1.0);
            double dblCalMinVolt = m_Recipe.GetValue(GetTaskName()
                , PARAM_PROCESS.POWER_CALIBRATION_2_MIN_VOLT.ToString()
                , 0
                , EN_RECIPE_PARAM_TYPE.VALUE
                , -1.0);

            double dblCalStepVolt;
            if (m_nCalibrationStep == 1)
                dblCalStepVolt = 0;
            else
                dblCalStepVolt = (dblCalMaxVolt - dblCalMinVolt) / (m_nCalibrationStep - 1);

            for (int i = 0; i < m_nCalibrationStep; i++)
            {
                m_arCalibrationStepVolt[i] = dblCalMinVolt + (i * dblCalStepVolt);
            }
        }
        #endregion

        //#region Block
        //private MOTION_RESULT MoveBlockWork()
        //{
        //    string strTaskName = EN_TASK_LIST.WORK_ZONE.ToString();

        //    int nAxisIndex = (int)EN_AXIS_LIST.BLOCK_Z;

        //    double dPos = m_Recipe.GetValue(strTaskName, Define.DefineEnumProject.Task.WorkZone.PARAM_PROCESS.BLOCK_WORK_POSITION_Z.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

        //    MOTION_RESULT enResult = MoveAbsolutely(nAxisIndex, dPos, MOTION_SPEED_CONTENT.RUN, m_nRunRatio, 0, true);

        //    return enResult;
        //}
        //private MOTION_RESULT MoveBlockReady()
        //{
        //    string strTaskName = EN_TASK_LIST.WORK_ZONE.ToString();

        //    int nAxisIndex = (int)EN_AXIS_LIST.BLOCK_Z;

        //    double dPos = m_Recipe.GetValue(strTaskName, Define.DefineEnumProject.Task.WorkZone.PARAM_PROCESS.BLOCK_READY_POSITION_Z.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

        //    return MoveAbsolutely(nAxisIndex, dPos, MOTION_SPEED_CONTENT.RUN, m_nRunRatio, 0, true);
        //}

        //private bool CheckMaterialExist()
        //{
        //    int nAIIndex = (int)EN_ANALOG_INPUT_LIST.BLOCK_VAC;
        //    string strTaskName = EN_TASK_LIST.WORK_ZONE.ToString();

        //    double dThreshold = m_Recipe.GetValue(strTaskName, Define.DefineEnumProject.Task.WorkZone.PARAM_PROCESS.BLOCK_MATERIAL_VAC_THRESHOLD.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

        //    return dThreshold > ReadAnalogInputValue(nAIIndex);
        //}

        //private bool CheckHeaterError()
        //{
        //    return ExternalDevice.Heater.Heater.GetInstance().IsError((int)Define.DefineEnumProject.Heater.EN_HEATER_ZONE_LIST.BLCOK);
        //}
        //#endregion /block

        //#region Haad Flow
        //private bool CheckHeadFlowLow()
        //{
        //    bool bLaserUsed = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.LASER_USED.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, false);
        //    if (bLaserUsed == false)
        //        return false;
        //    int nAIIndex = (int)EN_ANALOG_INPUT_LIST.HEAD_TOTAL_FLOW;

        //    double dThreshold = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.HEAD_FLOW_THRESHOLD.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

        //    return dThreshold > ReadAnalogInputValue(nAIIndex);
        //}
        //#endregion /Haad Flow

        //#region Move Ready Position
        //private bool MoveReadyPosition()
        //{
        //    DPointXY dSafetyPosition = new DPointXY();

        //    dSafetyPosition.x = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT
        //        , PARAM_EQUIPMENT.HEAD_READY_POSITION_X.ToString()
        //        , 0
        //        , EN_RECIPE_PARAM_TYPE.VALUE
        //        , 0.0);
        //    dSafetyPosition.y = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT
        //        , PARAM_EQUIPMENT.HEAD_READY_POSITION_Y.ToString()
        //        , 0
        //        , EN_RECIPE_PARAM_TYPE.VALUE
        //        , 0.0);

        //    MOTION_RESULT enResultX = MoveAbsolutely((int)EN_AXIS_LIST.HEAD_X, dSafetyPosition.x, Motion_.MOTION_SPEED_CONTENT.RUN, m_nRunRatio, 0, true);
        //    MOTION_RESULT enResultY = MoveAbsolutely((int)EN_AXIS_LIST.HEAD_Y, dSafetyPosition.y, Motion_.MOTION_SPEED_CONTENT.RUN, m_nRunRatio, 0, true);


        //    if (enResultX == MOTION_RESULT.OK
        //        && enResultY == MOTION_RESULT.OK)
        //        return true;

        //    return false;
        //}
        //#endregion

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

        #region Tool
        DateTime[] m_arStartTime = new DateTime[18];
        bool[] m_arLaserOn = new bool[18];
        int[] m_arAnalogTarget = new int[18];

        private void InitialzeLaserWorkTool()
        {
            for (int nIndex = 0; nIndex < 18; nIndex++)
            {
                m_arLaserOn[nIndex] = false;
            }
            m_arAnalogTarget[0] = (int)EN_ANALOG_INPUT_LIST.LD_POWER_1;
            m_arAnalogTarget[1] = (int)EN_ANALOG_INPUT_LIST.LD_POWER_2;
            m_arAnalogTarget[2] = (int)EN_ANALOG_INPUT_LIST.LD_POWER_3;
            m_arAnalogTarget[3] = (int)EN_ANALOG_INPUT_LIST.LD_POWER_4;
            m_arAnalogTarget[4] = (int)EN_ANALOG_INPUT_LIST.LD_POWER_5;
            m_arAnalogTarget[5] = (int)EN_ANALOG_INPUT_LIST.LD_POWER_6;
            m_arAnalogTarget[6] = (int)EN_ANALOG_INPUT_LIST.LD_POWER_7;
            m_arAnalogTarget[7] = (int)EN_ANALOG_INPUT_LIST.LD_POWER_8;
            m_arAnalogTarget[8] = (int)EN_ANALOG_INPUT_LIST.LD_POWER_9;
            m_arAnalogTarget[9] = (int)EN_ANALOG_INPUT_LIST.LD_POWER_10;
            m_arAnalogTarget[10] = (int)EN_ANALOG_INPUT_LIST.LD_POWER_11;
            m_arAnalogTarget[11] = (int)EN_ANALOG_INPUT_LIST.LD_POWER_12;
            m_arAnalogTarget[12] = (int)EN_ANALOG_INPUT_LIST.LD_POWER_13;
            m_arAnalogTarget[13] = (int)EN_ANALOG_INPUT_LIST.LD_POWER_14;
            m_arAnalogTarget[14] = (int)EN_ANALOG_INPUT_LIST.LD_POWER_15;
            m_arAnalogTarget[15] = (int)EN_ANALOG_INPUT_LIST.LD_POWER_16;
            m_arAnalogTarget[16] = (int)EN_ANALOG_INPUT_LIST.LD_POWER_17;
            m_arAnalogTarget[17] = (int)EN_ANALOG_INPUT_LIST.LD_POWER_18;
        }
        //private void ClearLaserWorkTool()
        //{
        //    for (int nIndex = (int)EN_WORK_TOOL.LD_EMITTER_CH_1; nIndex < (int)EN_WORK_TOOL.LD_EMITTER_CH_1 + 18; nIndex++)
        //    {
        //        m_arLaserOn[nIndex] = false;
        //    }
        //}
        //private void CheckLaserWorkTool()
        //{
        //    double dThreshold = m_Recipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.LASER_ON_VOLT_THRESHOLD.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
        //    for (int nIndex = (int)EN_WORK_TOOL.LD_EMITTER_CH_1; nIndex < (int)EN_WORK_TOOL.LD_EMITTER_CH_1 + 18; nIndex++)
        //    {
        //        if (m_arLaserOn[nIndex])
        //        {
        //            if (ReadAnalogInputVolt(m_arAnalogTarget[nIndex]) < dThreshold)
        //            {
        //                m_arLaserOn[nIndex] = false;
        //                TimeSpan OnTime = DateTime.Now - m_arStartTime[nIndex];
        //                Tool.WorkTool.GetInstance().IncreaseWorkToolUsedTime(nIndex, OnTime);
        //            }
        //        }
        //        else
        //        {
        //            if (ReadDigitalInput((int)EN_DIGITAL_INPUT_LIST.LD_ON_PORT_1, false, 0)
        //               || ReadDigitalInput((int)EN_DIGITAL_INPUT_LIST.LD_ON_PORT_2, false, 0)
        //               || ReadDigitalInput((int)EN_DIGITAL_INPUT_LIST.LD_ON_PORT_3, false, 0))
        //            {
        //                if (ReadAnalogInputVolt(m_arAnalogTarget[nIndex]) > dThreshold)
        //                {
        //                    m_arLaserOn[nIndex] = true;
        //                    m_arStartTime[nIndex] = DateTime.Now;
        //                }
        //            }
        //        }
        //    }
        //}
        #endregion

        private void EntryNodeState()
        {
            _DynamicLink.InitializeNodeState(GetTaskName());
            DynamicLink_.EN_PORT_STATUS enPort = DynamicLink_.EN_PORT_STATUS.EMPTY;
            _DynamicLink.GetPortStatus(GetTaskName(), EN_PORT_LIST.WORK_PORT.ToString(), ref enPort);

            switch (enPort)
            {

                case DynamicLink_.EN_PORT_STATUS.FINISHED:
                    _DynamicLink.SetNodeState(GetTaskName(), EN_TASK_ACTION.LASER_WORK.ToString(), EN_ACTION_STATE.DONE);
                    break;
            }
        }

        //private void FFU_Monitoring()
        //{
        //    if (false == m_tickForFFU.IsTickOver(true))
        //        return;

        //    m_tickForFFU.SetTickCount(5000);

        //    if (ExternalDevice.FFUManager.GetInstance().IsSkipped)
        //        return;

        //    bool doorOpened = false;
        //    doorOpened |= DigitalIO_.DigitalIO.GetInstance().ReadInput((int)Define.DefineEnumProject.DigitalIO.EN_DIGITAL_IN.DOOR_LOCK_1);
        //    doorOpened |= DigitalIO_.DigitalIO.GetInstance().ReadInput((int)Define.DefineEnumProject.DigitalIO.EN_DIGITAL_IN.DOOR_LOCK_2);

        //    bool coverOpened = false;
        //    coverOpened |= DigitalIO_.DigitalIO.GetInstance().ReadInput((int)Define.DefineEnumProject.DigitalIO.EN_DIGITAL_IN.COVER_1);
        //    coverOpened |= DigitalIO_.DigitalIO.GetInstance().ReadInput((int)Define.DefineEnumProject.DigitalIO.EN_DIGITAL_IN.COVER_2);

        //    if (doorOpened || coverOpened)
        //    {
        //        ExternalDevice.FFUManager.GetInstance().RequestFullSpeedAll();
        //    }
        //    else
        //    {
        //        ExternalDevice.FFUManager.GetInstance().RequestNormalSpeedAll();
        //    }
        //}


        #endregion

        #region External Interface
        public int GetPowerMeasureRepeatCount()
        {
            return m_nPowerMeasureCurrentRepeatCount + 1;
        }
        public int GetPowerCalCh()
        {
            return m_nCalibrationChannel + 1;
        }
        public int GetPowerCalStep()
        {
            return m_nCalibrationCurrentStep + 1;
        }

        public double GetPowerCalVolt()
        {
            if (m_arCalibrationStepVolt.Length > m_nCalibrationCurrentStep)
                return m_arCalibrationStepVolt[m_nCalibrationCurrentStep];
            else
                return 0;
        }

        public double GetMeasuredInputVolt()
        {
            if (m_lstCurrentVolt.Count > 0)
                return new List<double>(m_lstCurrentVolt).Average();
            else
                return 0;
        }

        public double GetPowermeasureRestTime()
        {
            //초로 반환
            return m_tickForPowerMeasureRest.GetTickCount() / 1000;
        }
        public override void ClearMaterial()
        {
            _DynamicLink.SetPortStatus(GetTaskName(), EN_PORT_LIST.WORK_PORT.ToString(), DynamicLink_.EN_PORT_STATUS.EMPTY);
        }
        #endregion

        #region Enumerable

        #region Work Port
        private enum EN_WORK_PORT
        {
            NONE = 0,
            PORT_1 = 1,
            PORT_2 = 2,
        }
        #endregion

        #region Step

        private enum EN_INITIALIZE_STEP
        {
            START = 0,
            PREPARE = 50,
            PYROMETER = 100,
            HEAD = 200,
            END = 10000,
        }

        #region Entry
        /// <summary>
        /// 2020.06.02 by yjlee [ADD] Enumerate the step for entry sequence.
        /// </summary>
        private enum EN_ENTRY_STEP
        {
            START = 0,        // 'START' must be '0'.

            READY_DEVICE = 100,

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

        #region Auto

        #region Laser Bonding
        private enum EN_LASER_WORK_STEP
        {
            ACTION_START = 0,

            PARAMETER_READY_LASER_1 =100,
            PARAMETER_READY_LASER_2 = 200,
            PARAMETER_COMPLETE_1 = 300,
            PARAMETER_COMPLETE_2 = 400,
            WAIT_AND_OUTPUT = 500,

            ACTION_FINISH = 9900,
            FINISH = 10000,
        }
        private enum EN_LASER_WORK_STEP_2
        {
            ACTION_START = 0,

            PARAMETER_READY,

            ACTION_FINISH = 9900,
            FINISH = 10000,
        }
        #endregion

        #endregion

        #region Manaul

        #region Calibration
        private enum EN_POWER_MEASURE_STEP
        {
            ACTION_START = 0,

            POWERMETER_READY = 100,
            MOVE_SHOT_POSITION = 200,
            LASER_READY = 300,
            LASER_WORKING = 400,

            CHECK_REPEAT = 500,

            SET_CALIBRATION_DATA = 600,

            ACTION_FINISH = 900,

            FINISH = 10000,
        }
        private enum EN_POWER_MEASURE_STEP_2
        {
            ACTION_START = 0,

            POWERMETER_READY = 100,
            MOVE_SHOT_POSITION = 200,
            LASER_READY = 300,
            LASER_WORKING = 400,

            CHECK_REPEAT = 500,

            SET_CALIBRATION_DATA = 600,

            ACTION_FINISH = 900,

            FINISH = 10000,
        }
        private enum EN_LASER_SHORT_TEST_STEP
        {
            ACTION_START = 0,

            MOVE_POS = 100,

            SHORT_TEST = 200,

            WORK_FINISH = 300,

            ACTION_FINISH = 9900,
            FINISH = 10000,
        }
        private enum EN_LASER_SHORT_TEST_STEP_2
        {
            ACTION_START = 0,

            MOVE_POS = 100,

            SHORT_TEST = 200,

            WORK_FINISH = 300,

            ACTION_FINISH = 9900,
            FINISH = 10000,
        }
        #endregion /Calibration
        #endregion

        #endregion

        #endregion

        #region SubAction
        private enum EN_SUBACTION_LIST
        {
            INITIAZLIZE = 0,

            LASER_WORK = 1,
        }
        #endregion

        #endregion

        // 2020.12.01 by jhchoo [ADD] RecoveryData Class 
        #region Recovery Inherit Class
        class TaskBondHeadRecovery : RecoveryData
        {
            #region 변수
            #endregion

            #region 속성
            #endregion

            #region 생성자
            public TaskBondHeadRecovery(string sTaskName, int nPortCount)
                : base(sTaskName, nPortCount)
            {
            }
            #endregion

            #region SAVE
            protected override void SaveData(ref FileComposite fComp, string sRootName)
            {

            }
            #endregion

            #region LOAD
            protected override void LoadData(ref FileComposite fComp, string sRootName)
            {

            }
            #endregion
        }
        #endregion
    }
}
