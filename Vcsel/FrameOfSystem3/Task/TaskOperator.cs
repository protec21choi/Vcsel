using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Define.DefineConstant;
using Define.DefineEnumBase.ThreadTimer;
using Define.DefineEnumBase.Common;
using Define.DefineEnumProject.Task;
using DefineTask = Define.DefineEnumProject.Task;
using Define.DefineEnumProject.Map;

using RunningMain_;
using RunningTask_;
using ThreadTimer_;

using Interrupt_;

using RegisteredInstances_;

using DesignPattern_.Observer_;
using FrameOfSystem3.Work;

namespace FrameOfSystem3.Task
{
    // 2020.05.20 by yjlee [ADD] Use the alias for the instances.
    extern alias AlarmInstance;

    /// <summary>
    /// 2020.05.18 by yjlee [ADD] This class controls the tasks and operates them.
    /// </summary>
    class TaskOperator : RunningMain
    {
        #region Singleton
		private TaskOperator() : base(Define.DefineConstant.FilePath.FILEPATH_LOG_MAIN) 
        { 
        }
        static private TaskOperator m_Instance      = new TaskOperator();
        static public TaskOperator GetInstance() { return m_Instance; }
        #endregion

        #region Constant
        const string NAMESPACE_TASK     = "FrameOfSystem3.Task.";
        #endregion

		#region <FILED>

        #region Init & Exit
        Functional.Initializer m_pInitializer       = null;
		#endregion

		/// <summary>
        /// 2020.05.12 by yjlee [ADD] Declare the delegates to pass to the Dll.
        /// </summary>
        #region Thread Timer
        private deleCallbackFunction delegateThreadTimerForMain             = null;
        private deleCallbackFunction delegateThreadTimerForObserver         = null;
        #endregion

        #region Instances for Obserber
		private Subject subjectEquipmentState	= null;
		private Subject subjectAlarm			= null;
        #endregion

		#region Alarm
		private int m_nIndexOfBuzzerOutput		= -1;
		private int m_nIndexOfGeneratedAlarm	= -1;
		#endregion

        #region Common
        FrameOfSystem3.Config.ConfigDevice m_InstanceOfDevice	= null;
		FrameOfSystem3.Config.ConfigAlarm.TaskAlarmInformation m_instancOfTaskInformation	= null;
        #endregion

        private Dictionary<string, RunningTaskEx> m_dicOfTask = new Dictionary<string, RunningTaskEx>();

        // 2020.12.01 by jhchoo [ADD] Recovery 객체 모음
        #region Recovery
        private Dictionary<EN_TASK_LIST, RecoveryData> m_dicRecovery = new Dictionary<EN_TASK_LIST, RecoveryData>();
        #endregion

		#region for Tast Functions
		private TickCounter_.TickCounter _efemWaitingTimeCounter = new TickCounter_.TickCounter();
		private static Recipe.Recipe _recipe = Recipe.Recipe.GetInstance();

        private TickCounter_.TickCounter m_tickForPreHeating = new TickCounter_.TickCounter();
        #endregion
        
		#endregion </FIELD>

        #region Inherit Interface
        /// <summary>
        /// 2020.05.18 by yjlee [ADD] This function will be called to initialize the equipment.
        /// </summary>
        protected override bool DoUndefinedSequence()
        {
            return m_pInitializer.DoInitializeSequence();
        }

        /// <summary>
        /// 2020.05.19 by yjlee [ADD] Monitor the 'UNDEFINED' state to update the equipment state to 'PAUSE'.
        ///     - if the function return 'false', the equipment state can't become to 'PAUSE'.
        /// </summary>
        protected override bool MonitorUndefined()
        {
            return true;
        }

        /// <summary>
        /// 2020.05.19 by yjlee [ADD] Monitor the 'PAUSE' state to check whether an error occur or not.
        ///     - if the function return 'false', the equipment state will be change to 'UNDEFINED'.
        ///     - Don't add the blocking sequence here.
        /// </summary>
        protected override bool MonitorPause()
        {			
            return true;
        }

        /// <summary>
        /// 2020.05.19 by yjlee [ADD] Monitor the 'IDLE' state to check whether an error occur or not.
        ///     - if the function return 'false', the equipment state will be change to 'PUASE'.
        ///     - Don't add the blocking sequence here.
        /// </summary>
        protected override bool MonitorIdle()
        {
            return true;
        }

        #region RunMode
        /// <summary>
        /// 2020.12.03 by yjlee [ADD] If the run mode is changed, it will be called.
        ///     - Don't add the blocking sequence here.
        /// </summary>
        protected override void ChangeRunMode(RUN_MODE enRunMode)
        {
			//bool bVisionSkipped     = false;

			Log.LogManager.GetInstance().WriteProcessLog("GENERAL", "CHANGE_RUN_MODE", enRunMode.ToString());
			switch (enRunMode)
            {
                case RUN_MODE.AUTO:
					//bVisionSkipped  = false;
                    break;

                case RUN_MODE.DRY_RUN:
					//bVisionSkipped  = true;
                    break;

                case RUN_MODE.SIMULATION:
					//bVisionSkipped  = true;
                    break;
            }

			// Vision_.Vision.GetInstance().SetRunMode(bVisionSkipped);
        }
        #endregion

        #region Alarm
        /// <summary>
        /// 2021.02.16 by yjlee [ADD] Get the task information when an alarm occur in the system.
        /// </summary>
		
        protected override void GetTaskAlarmInformartion(ref TaskAlarmData[] arTaskAlarmData)
        {
			foreach (TaskAlarmData pTaskData in arTaskAlarmData)
			{
				m_instancOfTaskInformation.UpdateTaskInformation(pTaskData);
			}
        }

        /// <summary>
        /// 2020.06.09 by yjlee [ADD] Show an alarm message.
        /// </summary>
        protected override void ShowAlarmMessage()
        {
			Views.Functional.Form_AlarmMessage.GetInstance().SetAlarmMessageForm(true);
        }
        /// <summary>
        /// 2020.06.09 by yjlee [ADD] Hide an alarm message.
        /// </summary>
        protected override void HideAlarmMessage()
        {
			Views.Functional.Form_AlarmMessage.GetInstance().SetAlarmMessageForm(false);
        }

        /// <summary>
        /// 2021.04.27 by yjlee [ADD] Start a buzzer action.
        /// </summary>
        protected override void StartBuzzer()
        {
   //         m_nIndexOfBuzzerOutput = (int)Define.DefineEnumProject.DigitalIO.EN_DIGITAL_OUT.BUZZER;

			//DigitalIO_.DigitalIO.GetInstance().WriteOutput(m_nIndexOfBuzzerOutput, true);
        }

        /// <summary>
        /// 2021.04.27 by yjlee [ADD] Stop a buzzer action.
        /// </summary>
        protected override void StopBuzzer()
        {
			//DigitalIO_.DigitalIO.GetInstance().WriteOutput(m_nIndexOfBuzzerOutput, false);
        }
        #endregion

        #endregion

		#region <METHOD>

        #region Init
        /// <summary>
        /// 2020.05.18 by yjlee [ADD] Initialize the instances to operator the machine.
        /// </summary>
        private void InitializeMainInstances()
        {
            // 1. Registers the subject of the task operator.
            subjectEquipmentState       = EquipmentState_.EquipmentState.GetInstance();
            subjectAlarm                = Alarm_.Alarm.GetInstance();

            RegisterSubject(subjectEquipmentState);
            RegisterSubject(subjectAlarm);

            // 2. Initialize the thread timer.
            ThreadTimer.GetInstance().Init(false);

            // 3. Add the instances to the thread timer.
            delegateThreadTimerForObserver     = new deleCallbackFunction(DesignPattern_.Observer_.NotifyThread.GetInstance().Run);
            ThreadTimer.GetInstance().AddTimer((int)EN_THREADTIMER_INDEX.THREADTIMER_INDEX_OBSERVER
                , ThreadTimerInterval.THREADTIMER_INTERVAL_OBSERVER
                , delegateThreadTimerForObserver);
            ThreadTimer.GetInstance().StartTimer((int)EN_THREADTIMER_INDEX.THREADTIMER_INDEX_OBSERVER);

            delegateThreadTimerForMain              = new deleCallbackFunction(Task.TaskOperator.GetInstance().Execute);
            ThreadTimer.GetInstance().AddTimer((int)EN_THREADTIMER_INDEX.THREADTIMER_INDEX_MAIN
                , ThreadTimerInterval.THREADTIMER_INTERVAL_MAIN
                , delegateThreadTimerForMain);
            ThreadTimer.GetInstance().StartTimer((int)EN_THREADTIMER_INDEX.THREADTIMER_INDEX_MAIN);
		}		
        /// <summary>
        /// 2020.05.18 by yjlee [ADD] Wait to be complete for the initialization.
        /// </summary>
        private void WaitForInitializing()
        {
            while (false == m_pInitializer.IsInitializationEnd());
        }
        #endregion

        #region Interrupt Actions
        /// <summary>
        /// 2020.05.12 by yjlee [ADD] There are functions for the Interrupt actions.
        /// </summary>
        private void InterruptStart(int nParam) { SetOperation(RunningMain_.OPERATION_EQUIPMENT.RUN); }
        private void InterruptStop(int nParam) { SetOperation(RunningMain_.OPERATION_EQUIPMENT.STOP); }
        // private void InterruptReset(int nParam) { Alarm_.Alarm.GetInstance().SetAlarmResult(AlarmInstance::Alarm_.ALARM_RESULT.RESET);}

        // 2021.07.25. by shkim. [MOD] 인터럽트 Reset Action (Motion Position Clear)하도록 수정 (기존에는 작동안함)

        /// <summary>
        /// 2021.07.25. by shkim. [MOD] 인터럽트 Reset Action (Motion Position Clear)하도록 수정 (기존에는 작동안함)
        /// 2021.09.06. by shkim. [MOD] 인터럽트 Reset Action에 Motion Position Clear +  알람 리셋 하도록 수정
        /// </summary>
        /// <param name="nParam"></param>
        private void InterruptReset(int nParam)
        {
            DoInteruptActionReset();
            Alarm_.Alarm.GetInstance().SetAlarmResult(AlarmInstance::Alarm_.ALARM_RESULT.RESET);
        }
        private void InterruptAlarm(int nParam) { Alarm_.Alarm.GetInstance().GenerateAlarm(0, 0, nParam, false);  }

        #endregion

		#endregion </METHOD>

		#region <INTERFACE>

        #region Init & Exit
        /// <summary>
        /// 2020.05.18 by yjlee [ADD] Initialize the instances for the equipment.
        /// </summary>
        public void Init()
        {
            m_pInitializer      = new Functional.Initializer();

            m_pInitializer.Init(new DelegateForInterruptAction(InterruptStart)
                , new DelegateForInterruptAction(InterruptStop)
                , new DelegateForInterruptAction(InterruptReset)
                , new DelegateForInterruptAction(InterruptAlarm));

            // 2020.05.18 by yjlee [ADD] Initialize the instances of the taskoperator.
            InitializeMainInstances();

            // 2020.05.18 by yjlee [ADD] Wait to be complete for the initializing.
            WaitForInitializing();
        }

        /// <summary>
        /// 2020.05.18 by yjlee [ADD] Release the resources of the instances.
        /// </summary>
        public void Exit()
        {
            // 2021.08.18. by shkim [ADD] 설비 종료시 설비 상태 UNDEFINED로 변경 후 종료
            RequestExitProgram();
            m_pInitializer.Exit();
        }
        #endregion

        #region Initialize of instances
        /// <summary>
        /// 2020.06.15 by yjlee [ADD] Initialize the task.
        /// </summary>
        public bool InitializeTask()
        {
			RunningTask.SetRecipeInstance(RecipeManager_.RecipeManager.GetInstance());

			RunningTask.SetTimeoutOfSequence(Define.DefineConstant.Task.TIMEOUT_SEQUENCE);

            string[] arTaskName     = null;
            int[] arInstanceOfTask  = null;
            string[] arClassName    = null;
			bool bInitializeTask	= true;

			m_InstanceOfDevice			= FrameOfSystem3.Config.ConfigDevice.GetInstance();
			m_instancOfTaskInformation	= FrameOfSystem3.Config.ConfigAlarm.TaskAlarmInformation.GetInstance(); 

            if(FrameOfSystem3.Config.ConfigTask.GetInstance().GetListOfTask(ref arTaskName)
                && FrameOfSystem3.Config.ConfigTask.GetInstance().GetListOfIndexOfInstance(ref arInstanceOfTask)
                && FrameOfSystem3.Config.ConfigTask.GetInstance().GetListOfClassName(ref arClassName))
            {
                for(int nIndex = 0, nEndOfIndex = arClassName.Length
                    ; nIndex < nEndOfIndex ; ++ nIndex)
                {
                    int nIndexOfInstance    = arInstanceOfTask[nIndex];

                    // 2020.07.29 by yjlee [ADD] Can't use the '0' as the instance or a task has the same instance number.
                    if (1 > nIndexOfInstance) { return false; }

                    var typeClass           = Type.GetType(NAMESPACE_TASK + arClassName[nIndex]);

                    // 2020.07.29 by yjlee [ADD] Can't find the class file in the project.
                    if (null == typeClass) { return false;}

                    object[] arParam    = new object[]{nIndexOfInstance, arTaskName[nIndex]};

                    var instanceOfClass = Activator.CreateInstance(typeClass, arParam);

                    RunningTaskEx pTask = instanceOfClass as RunningTaskEx;

					#region Device
					int nCountOfDevice		= 0;
					int[] arDevice			= null;

					#region Motion
					/// 2020.11.16 by twkang [ADD] Motion 인스턴스를 추가한다.
					m_InstanceOfDevice.GetIndexesOfDevice(arTaskName[nIndex], Config.ConfigDevice.EN_TYPE_DEVICE.MOTION, ref nCountOfDevice, ref arDevice);
					for(int nIndexOfKey = 0; nIndexOfKey < nCountOfDevice; ++nIndexOfKey)
					{
						int nTargetIndex				= -1;
						RegisteredMotion pMotion        = null;

						if(m_InstanceOfDevice.GetDeviceTargetIndex(arTaskName[nIndex], Config.ConfigDevice.EN_TYPE_DEVICE.MOTION, arDevice[nIndexOfKey], ref nTargetIndex))
						{
							if(nTargetIndex > -1)
							{
								bInitializeTask &= RegisteredInstanceManager.GetInstance().AddMotionInstance(nIndexOfInstance, nTargetIndex, ref pMotion);
								bInitializeTask &= pTask.AddInstanceOfMotion(arDevice[nIndexOfKey], ref pMotion);
							}
						}
					}
					#endregion

					#region Cylinder
					/// 2020.11.16 by twkang [ADD] Cylinder 인스턴스를 추가한다.
					m_InstanceOfDevice.GetIndexesOfDevice(arTaskName[nIndex], Config.ConfigDevice.EN_TYPE_DEVICE.CYLINDER, ref nCountOfDevice, ref arDevice);
					for(int nIndexOfKey = 0; nIndexOfKey < nCountOfDevice; ++nIndexOfKey)
					{
						int nTargetIndex				= -1;
						RegisteredCylinder pCylinder        = null;

						if(m_InstanceOfDevice.GetDeviceTargetIndex(arTaskName[nIndex], Config.ConfigDevice.EN_TYPE_DEVICE.CYLINDER, arDevice[nIndexOfKey], ref nTargetIndex))
						{
							if(nTargetIndex > -1)
							{
								bInitializeTask &= RegisteredInstanceManager.GetInstance().AddCylinderInstance(nIndexOfInstance, nTargetIndex, ref pCylinder);
								bInitializeTask &= pTask.AddInstanceOfCylinder(arDevice[nIndexOfKey], ref pCylinder);
							}
						}
					}
					#endregion

					#region Digital IO
					/// 2020.11.16 by twkang [ADD] Digital Input 인스턴스를 추가한다.
					m_InstanceOfDevice.GetIndexesOfDevice(arTaskName[nIndex], Config.ConfigDevice.EN_TYPE_DEVICE.DIGITAL_INPUT, ref nCountOfDevice, ref arDevice);
					for (int nIndexOfKey = 0; nIndexOfKey < nCountOfDevice; ++nIndexOfKey)
					{
						int nTargetIndex						= -1;
						RegisteredDigitalInput pDigitalInput    = null;

						if (m_InstanceOfDevice.GetDeviceTargetIndex(arTaskName[nIndex], Config.ConfigDevice.EN_TYPE_DEVICE.DIGITAL_INPUT, arDevice[nIndexOfKey], ref nTargetIndex))
						{
							if(nTargetIndex > -1)
							{
								bInitializeTask &= RegisteredInstanceManager.GetInstance().AddDigitalInputInstance(nIndexOfInstance, nTargetIndex, ref pDigitalInput);
								bInitializeTask &= pTask.AddInstanceOfDigitalInput(arDevice[nIndexOfKey], ref pDigitalInput);
							}
						}
					}

					/// 2020.11.16 by twkang [ADD] Digital Output 인스턴스를 추가한다.
					m_InstanceOfDevice.GetIndexesOfDevice(arTaskName[nIndex], Config.ConfigDevice.EN_TYPE_DEVICE.DIGITAL_OUTPUT, ref nCountOfDevice, ref arDevice);
					for (int nIndexOfKey = 0; nIndexOfKey < nCountOfDevice; ++nIndexOfKey)
					{
						int nTargetIndex						= -1;
						RegisteredDigitalOutput pDigitalOutput	= null;

						if (m_InstanceOfDevice.GetDeviceTargetIndex(arTaskName[nIndex], Config.ConfigDevice.EN_TYPE_DEVICE.DIGITAL_OUTPUT, arDevice[nIndexOfKey], ref nTargetIndex))
						{
							if(nTargetIndex > -1)
							{
								bInitializeTask &= RegisteredInstanceManager.GetInstance().AddDigitalOutputInstance(nIndexOfInstance, nTargetIndex, ref pDigitalOutput);
								bInitializeTask &= pTask.AddInstanceOfDigitalOutput(arDevice[nIndexOfKey], ref pDigitalOutput);
							}
						}
					}
					#endregion

					#region Analog IO
					/// 2020.11.16 by twkang [ADD] Analog Input 인스턴스를 추가한다.
					m_InstanceOfDevice.GetIndexesOfDevice(arTaskName[nIndex], Config.ConfigDevice.EN_TYPE_DEVICE.ANALOG_INPUT, ref nCountOfDevice, ref arDevice);

					for (int nIndexOfKey = 0; nIndexOfKey < nCountOfDevice; ++nIndexOfKey)
					{
						int nTargetIndex						= -1;
						RegisteredAnalogInput pAnalogInput    = null;

						if (m_InstanceOfDevice.GetDeviceTargetIndex(arTaskName[nIndex], Config.ConfigDevice.EN_TYPE_DEVICE.ANALOG_INPUT, arDevice[nIndexOfKey], ref nTargetIndex))
						{
							if(nTargetIndex > -1)
							{
								bInitializeTask &= RegisteredInstanceManager.GetInstance().AddAnalogInputInstance(nIndexOfInstance, nTargetIndex, ref pAnalogInput);
								bInitializeTask &= pTask.AddInstanceOfAnalogInput(arDevice[nIndexOfKey], ref pAnalogInput);
							}
						}
					}

					/// 2020.11.16 by twkang [ADD] Analog Output 인스턴스를 추가한다.
					m_InstanceOfDevice.GetIndexesOfDevice(arTaskName[nIndex], Config.ConfigDevice.EN_TYPE_DEVICE.ANALOG_OUTPUT, ref nCountOfDevice, ref arDevice);
					for (int nIndexOfKey = 0; nIndexOfKey < nCountOfDevice; ++nIndexOfKey)
					{
						int nTargetIndex						= -1;
						RegisteredAnalogOutput pAnalogOutput    = null;

						if (m_InstanceOfDevice.GetDeviceTargetIndex(arTaskName[nIndex], Config.ConfigDevice.EN_TYPE_DEVICE.ANALOG_OUTPUT, arDevice[nIndexOfKey], ref nTargetIndex))
						{
							if(nTargetIndex > -1)
							{
								bInitializeTask &= RegisteredInstanceManager.GetInstance().AddAnalogOutputInstance(nIndexOfInstance, nTargetIndex, ref pAnalogOutput);
								bInitializeTask &= pTask.AddInstanceOfAnalogOutput(arDevice[nIndexOfKey], ref pAnalogOutput);
							}
						}
					}
					#endregion

					#endregion

					#region Alarm
					// 2020.07.29 by yjlee [ADD] Add an alarm instance of the task.
					RegisteredAlarm pAlarmInstance      = null;

					if (false == RegisteredInstanceManager.GetInstance().AddAlarmInstance(nIndexOfInstance
						, ref pAlarmInstance))
					{
						return false;
					}

					pTask.AddInstanceOfAlarm(ref pAlarmInstance);
					#endregion

                    AddTask(pTask);

                    m_dicOfTask.Add(arTaskName[nIndex], pTask);
                }

                return bInitializeTask;
            }

            return false;
        }
        #endregion

        #region Task Instance
        /// <summary>
        /// 2021.05.27 by yjlee [ADD] Get the task instance.
        /// </summary>
        public bool GetTaskInstance(string strTaskName, ref RunningTask pTask)
        {
            if(m_dicOfTask.ContainsKey(strTaskName))
            {
                pTask       = m_dicOfTask[strTaskName];

                return true;
            }

            return false;
        }
        #endregion

        #region EquipmentSate
		public bool IsRunningMode()
		{
			EquipmentState_.EQUIPMENT_STATE current = EquipmentState_.EquipmentState.GetInstance().GetState();
			switch (current)
			{
				case EquipmentState_.EQUIPMENT_STATE.INITIALIZE:
				case EquipmentState_.EQUIPMENT_STATE.READY:
				case EquipmentState_.EQUIPMENT_STATE.EXECUTING:
				case EquipmentState_.EQUIPMENT_STATE.SETUP:
				case EquipmentState_.EQUIPMENT_STATE.FINISHING:
					return true;
				default:
					return false;
			}
		}
        public bool IsEquipmentStateFinishing()
        {
            return EquipmentState_.EquipmentState.GetInstance().GetState() == EquipmentState_.EQUIPMENT_STATE.FINISHING;
        }
		public bool IsEquipmentFinishing(bool bCheckAlarm = true)
        {
            bool bIsFinishing = EquipmentState_.EquipmentState.GetInstance().GetState() == EquipmentState_.EQUIPMENT_STATE.FINISHING;

            int nAlarmState = (int)Alarm_.Alarm.GetInstance().GetAlarmState();

            return (bIsFinishing ||
                (bCheckAlarm && (nAlarmState == (int)AlarmInstance.Alarm_.ALARM_STATE.WARNING || nAlarmState == (int)AlarmInstance.Alarm_.ALARM_STATE.ERROR)));
		}
		#endregion

        // 2020.12.01 by jhchoo [ADD] Recovery Method
        #region Recovery
        public void AddRecoveryData(EN_TASK_LIST eTaskItem, ref RecoveryData tRecovery)
        {
            if (m_dicRecovery.ContainsKey(eTaskItem))
            {
                m_dicRecovery[eTaskItem] = tRecovery;
                return;
            }

            m_dicRecovery.Add(eTaskItem, tRecovery);
        }
        public bool GetRecoveryData(EN_TASK_LIST eTaskItem, out RecoveryData tRecovery)
        {
            tRecovery = null;

            if (m_dicRecovery.ContainsKey(eTaskItem))
            {
                tRecovery = m_dicRecovery[eTaskItem];
                return true;
            }

            return false;
        }
        public bool GetPortStatus(EN_TASK_LIST eTaskItem, int nPortNumber, out EN_PORT_STATUS enPortStatus)
        {
            RecoveryData tRecovery = null;
            enPortStatus = EN_PORT_STATUS.EMPTY;

            if (false == m_dicRecovery.ContainsKey(eTaskItem))
                return false;

            tRecovery = m_dicRecovery[eTaskItem];

            tRecovery.GetPortStatus(nPortNumber, out enPortStatus);

            return true;
        }
        public bool GetPortStatus(string strTaskItem, int nPortNumber, out EN_PORT_STATUS enPortStatus)
        {
            RecoveryData tRecovery = null;
            enPortStatus = EN_PORT_STATUS.EMPTY;

            EN_TASK_LIST eTaskItem = EN_TASK_LIST.BOND_HEAD;

            Enum.TryParse(strTaskItem, out eTaskItem);

            if (false == m_dicRecovery.ContainsKey(eTaskItem))
                return false;

            tRecovery = m_dicRecovery[eTaskItem];

            tRecovery.GetPortStatus(nPortNumber, out enPortStatus);

            return true;
        }
        #endregion

		#region Task Functions

		#region Is Machine mode
     
		public bool IsAutoRunMode()
		{
			return (EquipmentState_.EquipmentState.GetInstance().GetState() == EquipmentState_.EQUIPMENT_STATE.EXECUTING);
		}
		public bool IsManualMode()
		{
			return (EquipmentState_.EquipmentState.GetInstance().GetState() == EquipmentState_.EQUIPMENT_STATE.SETUP);
		}
		public bool IsExecutingMode()
		{
			EquipmentState_.EQUIPMENT_STATE current = EquipmentState_.EquipmentState.GetInstance().GetState();
			switch (current)
			{
				case EquipmentState_.EQUIPMENT_STATE.EXECUTING:
				case EquipmentState_.EQUIPMENT_STATE.SETUP:
					return true;
				default:
					return false;
			}
		}
		public bool IsFinishingMode()
		{
			// 2022.01.24 by junho [ADD] check alarm
			bool isFinishing = EquipmentState_.EquipmentState.GetInstance().GetState() == EquipmentState_.EQUIPMENT_STATE.FINISHING;

			//bool isAlarm = Alarm_.Alarm.GetInstance().GetGeneratedAlarm(ref alarmNo);
			bool isAlarm = (int)Alarm_.Alarm.GetInstance().GetAlarmState() > 1;
			return isFinishing || isAlarm;
		}
		public bool IsIdleMode(bool isIdleOnly = false)
		{
			switch(EquipmentState_.EquipmentState.GetInstance().GetState())
			{
				case EquipmentState_.EQUIPMENT_STATE.IDLE:
					return true;

				case EquipmentState_.EQUIPMENT_STATE.PAUSE:
					return false == isIdleOnly;
			}
			return false;
		}

		public bool IsDryRunOrSimulationMode()
		{
			switch (GetRunMode())
			{
				case RUN_MODE.DRY_RUN:
				case RUN_MODE.SIMULATION:
					return true;
				default:
					return false;
			}
		}
		public bool IsDryRunMode()
		{
			RUN_MODE mode = GetRunMode();
			return mode == RUN_MODE.DRY_RUN;
		}
		public bool IsSimulationMode()
		{
			RUN_MODE mode = GetRunMode();
			return mode == RUN_MODE.SIMULATION;
		}
		#endregion

        #region <TASK_DEVICE>
        /// <summary>
        /// 2022.04.14. by shkim. [ADD] 각 Task에서 SpeedContents를 이용해 등록된 Motion의 Speed값 받아오기 (리스트 모션 등에 활용)
        /// </summary>
        public bool GetSpeedOfTaskMotionByRunMode(string sTaskName, int nRegisteredMotionIndex, int nSpeedContents, ref double dSpeed)
        {
            int nMotionTargetIndex = -1;

            if (false == GetTargetIndexOfDeviceByRegisteredIndex(sTaskName, TaskDevice_.TYPE_DEVICE.MOTION, nRegisteredMotionIndex, ref nMotionTargetIndex))
            {
                return false;
            }

            if (false == Config.ConfigMotionSpeed.GetInstance().GetSpeedParameter(nMotionTargetIndex,
                (Config.ConfigMotion.EN_SPEED_CONTENT)nSpeedContents,
                Config.ConfigMotionSpeed.EN_PARAM_SPEED.VELOCITY,
                ref dSpeed))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 2022.04.15. by shkim. [ADD] 각 Task에 등록된 디바이스 RegisteredIndex로 Target Index
        /// </summary>
        /// <param name="sTaskName"></param>
        /// <param name="enDeviceType"></param>
        /// <param name="nRegisteredMotionIndex"></param>
        /// <param name="nTargetIndex"></param>
        /// <returns></returns>
        public bool GetTargetIndexOfDeviceByRegisteredIndex(string sTaskName, TaskDevice_.TYPE_DEVICE enDeviceType, int nRegisteredMotionIndex, ref int nTargetIndex)
        {
            return TaskDevice_.TaskDevice.GetInstance().GetDeviceTargetIndex(sTaskName,
                enDeviceType,
                nRegisteredMotionIndex,
                ref nTargetIndex);
        }

		public Config.ConfigMotion.EN_SPEED_CONTENT GetConfigSpeedContentByOperation(bool isCustomSpeed = false)
		{
			if (isCustomSpeed)
			{
				return Config.ConfigMotion.EN_SPEED_CONTENT.CUSTOM_1;
			}

			bool bIsRunMode = (GetOperationOfEquipment() == RunningMain_.OPERATION_EQUIPMENT.RUN);
			return bIsRunMode ? Config.ConfigMotion.EN_SPEED_CONTENT.RUN : Config.ConfigMotion.EN_SPEED_CONTENT.MANUAL;
		}
        public Motion_.MOTION_SPEED_CONTENT GetMotionSpeedContentByOperation(bool isCustomSpeed = false)
		{
			if(isCustomSpeed)
			{
				return Motion_.MOTION_SPEED_CONTENT.CUSTOM_1;
			}

			bool bIsRunMode = (GetOperationOfEquipment() == RunningMain_.OPERATION_EQUIPMENT.RUN);
			var motionSpeedContent = bIsRunMode ? Motion_.MOTION_SPEED_CONTENT.RUN : Motion_.MOTION_SPEED_CONTENT.MANUAL;
			return (Motion_.MOTION_SPEED_CONTENT)motionSpeedContent;
		}
		public List<Motion_.MOTION_SPEED_CONTENT> GetMotionSpeedContentByOperation(List<bool> isCustomSpeeds)
		{
			var result = new List<Motion_.MOTION_SPEED_CONTENT>();
			foreach (bool isCustomSpeed in isCustomSpeeds)
			{
				if (isCustomSpeed)
					result.Add(Motion_.MOTION_SPEED_CONTENT.CUSTOM_1);
				else
				{
					bool bIsRunMode = (GetOperationOfEquipment() == RunningMain_.OPERATION_EQUIPMENT.RUN);
					var motionSpeedContent = bIsRunMode ? Motion_.MOTION_SPEED_CONTENT.RUN : Motion_.MOTION_SPEED_CONTENT.MANUAL;
					result.Add(motionSpeedContent);
				}
			}

			return result;
		}
		#endregion

		#region Simple Recipe controll

		#region process
		public double GetProcessValue(string taskName, string parameterName, double defaultValue)
		{
			return _recipe.GetValue(taskName, parameterName, 0, Recipe.EN_RECIPE_PARAM_TYPE.VALUE, defaultValue);
		}
		public int GetProcessValue(string taskName, string parameterName, int defaultValue)
		{
			return _recipe.GetValue(taskName, parameterName, 0, Recipe.EN_RECIPE_PARAM_TYPE.VALUE, defaultValue);
		}
		public bool GetProcessValue(string taskName, string parameterName, bool defaultValue)
		{
			return _recipe.GetValue(taskName, parameterName, 0, Recipe.EN_RECIPE_PARAM_TYPE.VALUE, defaultValue);
		}
		public string GetProcessValue(string taskName, string parameterName, string defaultValue)
		{
			return _recipe.GetValue(taskName, parameterName, 0, Recipe.EN_RECIPE_PARAM_TYPE.VALUE, defaultValue);
		}

		public bool SetProcessValue(string taskName, string parameterName, string setValue)
		{
			return _recipe.SetValue(taskName, parameterName, 0, Recipe.EN_RECIPE_PARAM_TYPE.VALUE, setValue);
		}

		#endregion

		#region equipment
		public double GetEquipmentValue(Recipe.PARAM_EQUIPMENT equipItem, double defaultValue)
		{
			return _recipe.GetValue(Recipe.EN_RECIPE_TYPE.EQUIPMENT, equipItem.ToString(), 0, Recipe.EN_RECIPE_PARAM_TYPE.VALUE, defaultValue);
		}
		public int GetEquipmentValue(Recipe.PARAM_EQUIPMENT equipItem, int defaultValue)
		{
			return _recipe.GetValue(Recipe.EN_RECIPE_TYPE.EQUIPMENT, equipItem.ToString(), 0, Recipe.EN_RECIPE_PARAM_TYPE.VALUE, defaultValue);
		}
		public bool GetEquipmentValue(Recipe.PARAM_EQUIPMENT equipItem, bool defaultValue)
		{
			return _recipe.GetValue(Recipe.EN_RECIPE_TYPE.EQUIPMENT, equipItem.ToString(), 0, Recipe.EN_RECIPE_PARAM_TYPE.VALUE, defaultValue);
		}
		public string GetEquipmentValue(Recipe.PARAM_EQUIPMENT equipItem, string defaultValue)
		{
			return _recipe.GetValue(Recipe.EN_RECIPE_TYPE.EQUIPMENT, equipItem.ToString(), 0, Recipe.EN_RECIPE_PARAM_TYPE.VALUE, defaultValue);
		}

		public bool SetEquipmentValue(Recipe.PARAM_EQUIPMENT equipItem, string setValue)
		{
			return _recipe.SetValue(Recipe.EN_RECIPE_TYPE.EQUIPMENT, equipItem.ToString(), 0, Recipe.EN_RECIPE_PARAM_TYPE.VALUE, setValue);
		}
		#endregion

		#region common
		public double GetCommonValue(Recipe.PARAM_COMMON commonItem, double defaultValue)
		{
			return _recipe.GetValue(Recipe.EN_RECIPE_TYPE.COMMON, commonItem.ToString(), 0, Recipe.EN_RECIPE_PARAM_TYPE.VALUE, defaultValue);
		}
		public int GetCommonValue(Recipe.PARAM_COMMON commonItem, int defaultValue)
		{
			return _recipe.GetValue(Recipe.EN_RECIPE_TYPE.COMMON, commonItem.ToString(), 0, Recipe.EN_RECIPE_PARAM_TYPE.VALUE, defaultValue);
		}
		public bool GetCommonValue(Recipe.PARAM_COMMON commonItem, bool defaultValue)
		{
			return _recipe.GetValue(Recipe.EN_RECIPE_TYPE.COMMON, commonItem.ToString(), 0, Recipe.EN_RECIPE_PARAM_TYPE.VALUE, defaultValue);
		}
		public string GetCommonValue(Recipe.PARAM_COMMON commonItem, string defaultValue)
		{
			return _recipe.GetValue(Recipe.EN_RECIPE_TYPE.COMMON, commonItem.ToString(), 0, Recipe.EN_RECIPE_PARAM_TYPE.VALUE, defaultValue);
		}

		public bool SetCommonValue(Recipe.PARAM_COMMON commonItem, string setValue)
		{
			return _recipe.SetValue(Recipe.EN_RECIPE_TYPE.COMMON, commonItem.ToString(), 0, Recipe.EN_RECIPE_PARAM_TYPE.VALUE, setValue);
		}
		#endregion

		#endregion


		public new bool SetOperation(OPERATION_EQUIPMENT enOperation)
		{
			Log.LogManager.GetInstance().WriteProcessLog("GENERAL", "OPERATION", enOperation.ToString());
			return base.SetOperation(enOperation);
		}
		public bool GetManualActionName(out string actionName)
		{
			actionName = "";
			if (GetOperationOfEquipment() != RunningMain_.OPERATION_EQUIPMENT.MANUAL)
				return false;

			var operationName = new string[][] { };
			if (false == GetManualOperation(ref operationName))
				return false;

			if (operationName.Length < 1 || operationName[0].Length < 1)
				return false;

			actionName = operationName[0][0];
			return true;
		}
		public bool GetManualActionName(out string[][] result)
		{
			result = new string[][] { };
			if (GetOperationOfEquipment() != RunningMain_.OPERATION_EQUIPMENT.MANUAL)
				return false;

			if (false == GetManualOperation(ref result))
				return false;

			return true;
		}
		public bool GetManualActionName(out List<string> taskName, out List<List<string>> actionName)
		{
			string[] arTaskName = new string[] { };
			string[][] arActionName = new string[][] { };
			if (GetOperationOfEquipment() != RunningMain_.OPERATION_EQUIPMENT.MANUAL
				|| false == GetManualOperation(ref arTaskName, ref arActionName))
			{
				taskName = null;
				actionName = null;
				return false;
			}

			taskName = arTaskName.ToList();

			actionName = new List<List<string>>();
			for (int i = 0; i < arActionName.Length; ++i)
			{
				actionName.Add(new List<string>());
				actionName[i] = arActionName[i].ToList();
			}

			return true;
		}
		public void SetUiOperation(string[] taskName, string[] actionName)
		{
			if (taskName.Length != actionName.Length) return;

			string message = "";
			for (int i = 0; i < taskName.Length; ++i)
			{
				if (i == 0) message += string.Format("Do you want This Action START?\n{0}_{1}", taskName[i], actionName[i]);
				else message += string.Format(" -> {0}_{1}", taskName[i], actionName[i]);
			}

			var messageBox = Views.Functional.Form_MessageBox.GetInstance();
			if (false == messageBox.ShowMessage(message))
				return;

			SetOperation(ref taskName, ref actionName);
		}

        public void ClearMaterial()
        {
            foreach(var kpv in m_dicOfTask)
            {
                kpv.Value.ClearMaterial();
            }
        }

        public void MainVacControl(bool bOnOff)
        {
            //정지시 자재가 없다면 off
  
            string strPortName = "WORK_PORT";
            string TransferState = "";
            string WorkZoneState = "";
            string BondHeadState = "";

            FrameOfSystem3.Config.ConfigPort.GetInstance().GetPortStatus(EN_TASK_LIST.TRANSFER.ToString(), strPortName, ref TransferState);
            FrameOfSystem3.Config.ConfigPort.GetInstance().GetPortStatus(EN_TASK_LIST.WORK_ZONE.ToString(), strPortName, ref WorkZoneState);
            FrameOfSystem3.Config.ConfigPort.GetInstance().GetPortStatus(EN_TASK_LIST.BOND_HEAD.ToString(), strPortName, ref BondHeadState);
        
            int nMainVacTriggerIndex = 7;

            if (bOnOff == false)
            {
                if (TransferState == DynamicLink_.EN_PORT_STATUS.EMPTY.ToString()
                    && WorkZoneState == DynamicLink_.EN_PORT_STATUS.EMPTY.ToString()
                    && (BondHeadState == DynamicLink_.EN_PORT_STATUS.EMPTY.ToString()
                    || BondHeadState == DynamicLink_.EN_PORT_STATUS.FINISHED.ToString()))
                {
                    Config.ConfigTrigger.GetInstance().SetParameter(nMainVacTriggerIndex, Config.ConfigTrigger.EN_PARAM_TRIGGER.ENABLE, bOnOff);
                }
            }
            else
            {
                Config.ConfigTrigger.GetInstance().SetParameter(nMainVacTriggerIndex, Config.ConfigTrigger.EN_PARAM_TRIGGER.ENABLE, bOnOff);
            }

        }
		#endregion </INTERFACE>

        //#region PreHeating
        //public void ResetPreHeatingTimer()
        //{
        //    string strParaName = DefineTask.BondHead.PARAM_PROCESS.MATERIAL_PREHEATING_TIME.ToString();

        //    int nPreHeatingTime = _recipe.GetValue(EN_TASK_LIST.BOND_HEAD.ToString(), strParaName, 0, Recipe.EN_RECIPE_PARAM_TYPE.VALUE, 0);

        //    m_tickForPreHeating.SetTickCount((uint)nPreHeatingTime);
        //}

        //public bool IsPreHeatingOver()
        //{
        //    return m_tickForPreHeating.IsTickOver(true);
        //}

        //public ulong GetPreHeatingTime()
        //{
        //    return m_tickForPreHeating.GetTickCount();
        //}
        //#endregion

        /// <summary>
        /// 2022.01.18 by junho [ADD] Check machine is not working.
        /// 설비 상태가 Execute 상태여도 작업을 안하고 있을 수 있다.
        /// </summary>
        public bool IsMachineWait()
        {
            TaskData tData;
            foreach (EN_TASK_LIST task in Enum.GetValues(typeof(EN_TASK_LIST)))
            {
                tData = null;
                if (false == GetTaskInformation((int)task, ref tData))
                    return false;

                string strTaskAction = tData.strRunningAction;
                if (false == string.IsNullOrEmpty(strTaskAction))
                    return false;
            }

            return true;
        }

        #endregion </INTERFACE>
    }
}
