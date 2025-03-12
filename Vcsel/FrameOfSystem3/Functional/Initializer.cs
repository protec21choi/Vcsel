using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Define.DefineConstant;
using Define.DefineEnumBase.ThreadTimer;
using Define.DefineEnumBase.Initialize;

using ThreadTimer_;

using Account_;
using Alarm_;

using Motion_;

using Cylinder_;

using DigitalIO_;
using AnalogIO_;

using Socket_;
using Serial_;
using Trigger_;
using Interrupt_;
using TaskDevice_;

using Vision_;
using RegisteredInstances_;

using DesignPattern_.Observer_;

using Define.DefineEnumProject.Task;

using FrameOfSystem3.Recipe;

using EQUIPMENT_PARAM = FrameOfSystem3.Recipe.PARAM_EQUIPMENT;
using BONDER_TASK_PARAM = Define.DefineEnumProject.Task.BondHead.PARAM_PROCESS;
using WORKZONE_TASK_PARAM = Define.DefineEnumProject.Task.WorkZone.PARAM_PROCESS;


namespace FrameOfSystem3.Functional
{
    /// <summary>
    /// 2020.05.13 by yjlee [ADD] Initialize the instances of the dll.
    /// </summary>
    public class Initializer
    {
        #region Variables
        // 2022.01.17. [ADD] PROGRESS BAR DEBUG 모드 확인용 (기본값 false)
        private static bool m_bShowProgressWhenAttachedDebuger = false;

        private EN_INITIALIZATION_STEP m_enInitializeStep      = EN_INITIALIZATION_STEP.INIT_START;

        #region Delegate
        /// <summary>
        /// 2020.05.12 by yjlee [ADD] Declare the delegates to pass to the Dll.
        /// </summary>
        #region Thread Timer
        private deleCallbackFunction delegateThreadTimerForFileIO           = null;
        private deleCallbackFunction delegateThreadTimerForDigitalIO        = null;
        private deleCallbackFunction delegateThreadTimerForAnalogIO         = null;
        private deleCallbackFunction delegateThreadTimerForMotion           = null;
        private deleCallbackFunction delegateThreadTimerForMotionGathering  = null;
        private deleCallbackFunction delegateThreadTimerForCommunication    = null;
        private deleCallbackFunction delegateThreadTimerForETC              = null;
        #endregion

        #region Cylinder
        private DelegateForReadingIO delegateCylinderForReadingInput           = null;
        private DelegateForReadingIO delegateCylinderForReadingOutput          = null;
        private DelegateForWritingIO delegateCylinderForWritingOutput          = null;
        #endregion

        #region Interrupt
        private DelegateForReadingInput delegateInterruptForReadingInput      = null;
        private DelegateForWriteDigitalOutput delegateInterruptForWriteOutput      = null;
        private DelegateForInterruptAction delegateInterruptForActionStart    = null;
        private DelegateForInterruptAction delegateInterruptForActionStop     = null;
        private DelegateForInterruptAction delegateInterruptForActionReset    = null;
        private DelegateForInterruptAction delegateInterruptForActionAlarm    = null;
        #endregion

        #region Trigger
        private Trigger_.DelegateForWritingOutput delegateTriggerForWritingOutput        = null;
        #endregion

        #endregion

        #region Instances for Obserber
        private Subject subjectEquipmentState     = null;
        private Subject subjectAlarm              = null;
        #endregion

        #region for Form progress
        FrameOfSystem3.Views.Functional.Form_Progress m_Progress   = null;        
        System.Timers.Timer m_timerForProgressForm                 = null;
        #endregion

        #region Instance for Interfaces
        RegisteredInterfaces m_pRegisteredInterface = null;
        #endregion Instance for Interfaces

        #region DLL instances
        private Motion_.Motion m_instanceMotion     = null;
        private Socket m_instanceSocket             = null;
        private Serial m_instanceSerial             = null;
        private Vision_.Vision m_instanceVision     = null;
        private Interrupt m_instanceInterrupt       = null;
        private Cylinder m_instanceCylinder         = null;
        private Trigger m_instanceTrigger           = null;
        private RegisteredInstanceManager m_instanceRegisteredManager       = null;
        #endregion

        #region Controller
        Vision_.VisionController m_visionController     = null;
        AnalogIOController[] m_arAnalogIOController     = null;
        DigitalIOController[] m_arDigitalIOController   = null;

		// 2023.02.13. jhlim [MOD] 멀티 컨트롤러 사용을 위해 배열로 변경
		//MotionController m_MotionController = null;
		MotionController[] m_arMotionController = null;
        #endregion

        #endregion Variables

        #region Contructor & Destructor
        public Initializer() {}

        #endregion

        #region Internal Interface
        /// <summary>
        /// 2020.05.12 by yjlee [ADD] Register the event of the observer.
        /// </summary>
        private void RegisterObserverEvent()
        {
            subjectEquipmentState       = EquipmentState_.EquipmentState.GetInstance();
            subjectAlarm                = Alarm_.Alarm.GetInstance();

            Interrupt.GetInstance().RegisterSubject(subjectEquipmentState);

            Trigger.GetInstance().RegisterSubject(subjectEquipmentState);
            Trigger.GetInstance().RegisterSubject(subjectAlarm);

			Config.ConfigAlarm.GetInstance().RegisterSubject(subjectAlarm);
        }

        /// <summary>
        /// 2020.10.07 by yjlee [ADD] Get the instances of the dlls.
        /// </summary>
        private void GetDllInstance()
        {
            m_instanceMotion        = Motion_.Motion.GetInstance();
            m_instanceSocket        = Socket_.Socket.GetInstance();
            m_instanceSerial        = Serial_.Serial.GetInstance();
            m_instanceVision        = Vision_.Vision.GetInstance();
            m_instanceInterrupt     = Interrupt_.Interrupt.GetInstance();
            m_instanceCylinder      = Cylinder.GetInstance();
            m_instanceTrigger       = Trigger.GetInstance();
            m_instanceRegisteredManager     = RegisteredInstanceManager.GetInstance();
        }

        /// <summary>
        /// 2020.05.12 by yjlee [ADD] Set the thread timer to run.
        /// </summary>
        private bool SetThreadTimer()
        {
            delegateThreadTimerForFileIO       = new deleCallbackFunction(FileIOManager_.FileIOManager.GetInstance().Execute);
            ThreadTimer.GetInstance().AddTimer((int)EN_THREADTIMER_INDEX.THREADTIMER_INDEX_FILEIO
                , ThreadTimerInterval.THREADTIMER_INTERVAL_FILEIO
                , delegateThreadTimerForFileIO);
            ThreadTimer.GetInstance().StartTimer((int)EN_THREADTIMER_INDEX.THREADTIMER_INDEX_FILEIO);

            delegateThreadTimerForDigitalIO    = new deleCallbackFunction(DigitalIO.GetInstance().Execute);
            ThreadTimer.GetInstance().AddTimer((int)EN_THREADTIMER_INDEX.THREADTIMER_INDEX_DIGITALIO
                , ThreadTimerInterval.THREADTIMER_INTERVAL_DIGITALIO
                , delegateThreadTimerForDigitalIO);
            ThreadTimer.GetInstance().StartTimer((int)EN_THREADTIMER_INDEX.THREADTIMER_INDEX_DIGITALIO);
			
            delegateThreadTimerForAnalogIO     = new deleCallbackFunction(AnalogIO.GetInstance().Execute);
            ThreadTimer.GetInstance().AddTimer((int)EN_THREADTIMER_INDEX.THERADTIMER_INDEX_ANALOGIO
                , ThreadTimerInterval.THREADTIMER_INTERVAL_ANALOGIO
                , delegateThreadTimerForAnalogIO);
            ThreadTimer.GetInstance().StartTimer((int)EN_THREADTIMER_INDEX.THERADTIMER_INDEX_ANALOGIO);

            delegateThreadTimerForMotion       = new deleCallbackFunction(Motion_.Motion.GetInstance().Execute);
            ThreadTimer.GetInstance().AddTimer((int)EN_THREADTIMER_INDEX.THREADTIMER_INDEX_MOTION
                , ThreadTimerInterval.THREADTIMER_INTERVAL_MOTION
                , delegateThreadTimerForMotion);
            ThreadTimer.GetInstance().StartTimer((int)EN_THREADTIMER_INDEX.THREADTIMER_INDEX_MOTION);

            delegateThreadTimerForMotionGathering  = new deleCallbackFunction(ExecuteForMotionGathering);
            ThreadTimer.GetInstance().AddTimer((int)EN_THREADTIMER_INDEX.THREADTIMER_INDEX_MOTION_GATHERING
                , ThreadTimerInterval.THREADTIMER_INTERVAL_MOTION_GATHERING
                , delegateThreadTimerForMotionGathering);
            ThreadTimer.GetInstance().StartTimer((int)EN_THREADTIMER_INDEX.THREADTIMER_INDEX_MOTION_GATHERING);

			delegateThreadTimerForCommunication    = new deleCallbackFunction(ExecuteForCommunication);
			ThreadTimer.GetInstance().AddTimer((int)EN_THREADTIMER_INDEX.THREADTIMER_INDEX_COMMUNICATION
			    , ThreadTimerInterval.THREADTIMER_INTERVAL_COMMUNICATION
			    , delegateThreadTimerForCommunication);
			ThreadTimer.GetInstance().StartTimer((int)EN_THREADTIMER_INDEX.THREADTIMER_INDEX_COMMUNICATION);
			
			delegateThreadTimerForETC              = new deleCallbackFunction(ExecuteForETC);
			ThreadTimer.GetInstance().AddTimer((int)EN_THREADTIMER_INDEX.THREADTIMER_INDEX_ETC_INSTANCES
			    , ThreadTimerInterval.THREADTIMER_INTERVAL_ETC_INSTANCES
			    , delegateThreadTimerForETC);
			ThreadTimer.GetInstance().StartTimer((int)EN_THREADTIMER_INDEX.THREADTIMER_INDEX_ETC_INSTANCES);
            return true;
        }

        #region Execute
        /// <summary>
        /// 2020.05.21 by yjlee [ADD] Execute to gather the data for the motion.
        /// </summary>
        private void ExecuteForMotionGathering()
        {
           var enControllerState       = Motion_.CONTROLLER_STATE.STOP;
           m_instanceMotion.ExecuteForGathering(ref enControllerState);
        }

        /// <summary>
        /// 2020.05.21 by yjlee [ADD] Execute to communicate the external devices.
        /// </summary>
        private void ExecuteForCommunication()
        {
            m_instanceSocket.Execute();
            m_instanceSerial.Execute();
            m_instanceVision.Execute();

            //ExternalDevice.Serial.Powermeter.GetInstance().Execute();
            //ExternalDevice.Socket.IR.GetInstance().Execute();
            //ExternalDevice.Serial.ModbusRTU.GetInstance((int)Define.DefineEnumProject.Serial.EN_SERIAL_INDEX.MODBUS_CHILLER).Execute();
            //ExternalDevice.Serial.ModbusRTU.GetInstance((int)Define.DefineEnumProject.Serial.EN_SERIAL_INDEX.HEATER).Execute();
            //ExternalDevice.TransportWIR.GetInstance().Execute();
            //ExternalDevice.EFEMManager.GetInstance().Execute();
        }

        /// <summary>
        /// 2020.05.21 by yjlee [ADD] Execute for the ETC Instances.
        /// </summary>
        private void ExecuteForETC()
        {
            m_instanceInterrupt.Execute();
            m_instanceCylinder.Execute();
            m_instanceTrigger.Execute();
            Scheduler.GetInstance().Excute();
            Log.WorkLog.GetInstance().Execute();
            EquipmentMonitor.RAM_Metrics.GetInstance().Execute();
        }
        #endregion

        #region Progress Form
        private bool ShowProgressForm()
        {            
            if (!m_bShowProgressWhenAttachedDebuger == System.Diagnostics.Debugger.IsAttached)
            {
                return true;
            }
            else if(null != m_Progress && false != m_Progress.IsFormLoad())
            {
                m_Progress.SetEndStep(Enum.GetValues(typeof(EN_INITIALIZATION_STEP)).Length);
                return true;
            }
            return false;
        }
        /// <summary>
        /// 2020.05.13 by yjlee [ADD] Initialize the progress form.
        /// </summary>
        private void InitProgressForm()
        {
            if (!m_bShowProgressWhenAttachedDebuger == System.Diagnostics.Debugger.IsAttached)
            {
                return;
            }

            #region Init Timer
            m_timerForProgressForm      = new System.Timers.Timer();
            m_timerForProgressForm.BeginInit();
            m_timerForProgressForm.Elapsed      += new System.Timers.ElapsedEventHandler(CallbackFunctionForTimer);
            m_timerForProgressForm.AutoReset    = false;
            m_timerForProgressForm.Interval     = InitializationProgressForm.INTERVAL_CHECKING_INIT_STATE;
            m_timerForProgressForm.EndInit();
            #endregion

            m_timerForProgressForm.Start();
        }

        /// <summary>
        /// 2020.05.13 by yjlee [ADD] Release the resources.
        /// </summary>
        private void ExitProgressForm()
        {
            if (null == m_timerForProgressForm)
            {
                return;
            }

            string temp = Enum.GetValues(typeof(EN_INITIALIZATION_STEP)).Length.ToString();
            m_Progress.EnqueueResult(true, ref temp);

            m_timerForProgressForm.Dispose();
            m_timerForProgressForm      = null;
        }

        /// <summary>
        /// 2020.05.13 by yjlee [ADD] It will be called by the timer routine.
        /// </summary>
        private void CallbackFunctionForTimer(object sender, System.Timers.ElapsedEventArgs args)
        {
            m_Progress  = new Views.Functional.Form_Progress(InitializationProgressForm.INTERVAL_CHECKING_QUEUE_OF_PROGRESS);
            m_Progress.ShowDialog();

            m_Progress.Dispose();
            m_Progress  = null;
        }
        #endregion

        #region External

        //void WhenRecipeChangedHeater(bool result, List<Recipe.Recipe.ParameterItem> changeList)
        //{
        //    if (result == false)
        //        return;

        //    double dTemp = Recipe.Recipe.GetInstance().GetValue(EN_TASK_LIST.WORK_ZONE.ToString(), WORKZONE_TASK_PARAM.HEATER_TARGET_TEMP.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
        //    ExternalDevice.Heater.Heater.GetInstance().SetTargetTemp((int)Define.DefineEnumProject.Heater.EN_HEATER_ZONE_LIST.BLCOK, dTemp);

        //    double dCh1Offset = Recipe.Recipe.GetInstance().GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.WORK_BLOCK_CH_OFFSET_8.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
        //    ExternalDevice.Heater.Heater.GetInstance().SetChannelTempOffset((int)Define.DefineEnumProject.Heater.EN_HEATER_ZONE_LIST.BLCOK, 1, dCh1Offset, false);

        //    double dCh2Offset = Recipe.Recipe.GetInstance().GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.WORK_BLOCK_CH_OFFSET_8.ToString(), 1, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
        //    ExternalDevice.Heater.Heater.GetInstance().SetChannelTempOffset((int)Define.DefineEnumProject.Heater.EN_HEATER_ZONE_LIST.BLCOK, 2, dCh2Offset, false);

        //    double dCh3Offset = Recipe.Recipe.GetInstance().GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.WORK_BLOCK_CH_OFFSET_8.ToString(), 2, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
        //    ExternalDevice.Heater.Heater.GetInstance().SetChannelTempOffset((int)Define.DefineEnumProject.Heater.EN_HEATER_ZONE_LIST.BLCOK, 3, dCh3Offset, false);

        //    double dCh4Offset = Recipe.Recipe.GetInstance().GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.WORK_BLOCK_CH_OFFSET_8.ToString(), 3, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
        //    ExternalDevice.Heater.Heater.GetInstance().SetChannelTempOffset((int)Define.DefineEnumProject.Heater.EN_HEATER_ZONE_LIST.BLCOK, 4, dCh4Offset, false);

        //    double dZoneOffset = Recipe.Recipe.GetInstance().GetValue(EN_TASK_LIST.WORK_ZONE.ToString(), WORKZONE_TASK_PARAM.HEATER_OFFSET_TEMP.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
        //    ExternalDevice.Heater.Heater.GetInstance().SetTempOffset((int)Define.DefineEnumProject.Heater.EN_HEATER_ZONE_LIST.BLCOK, dZoneOffset);

        //    double dPlusTolerance = Recipe.Recipe.GetInstance().GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.WORK_BLOCK_TOLERANCE_MAX.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
        //    ExternalDevice.Heater.Heater.GetInstance().SetTempPlusTolerance((int)Define.DefineEnumProject.Heater.EN_HEATER_ZONE_LIST.BLCOK, dPlusTolerance);

        //    double dMinusTolerance = Recipe.Recipe.GetInstance().GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.WORK_BLOCK_TOLERANCE_MIN.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
        //    ExternalDevice.Heater.Heater.GetInstance().SetTempMinusTolerance((int)Define.DefineEnumProject.Heater.EN_HEATER_ZONE_LIST.BLCOK, dMinusTolerance);
        //}
        #endregion
        #endregion

        #region External Interface
        /// <summary>
        /// 2020.02.05 by yjlee [ADD] Initialize the software.
        /// </summary>
        public void Init(DelegateForInterruptAction delegateStart
            , DelegateForInterruptAction delegateStop
            , DelegateForInterruptAction delegateReset
            , DelegateForInterruptAction delegateAlarm)
        {
            m_enInitializeStep      = EN_INITIALIZATION_STEP.INIT_START;
            
            // 2020.05.18 by yjlee [ADD] Set an interrupt actions.
            delegateInterruptForActionStart     = delegateStart;
            delegateInterruptForActionStop      = delegateStop;
            delegateInterruptForActionReset     = delegateReset;
            delegateInterruptForActionAlarm     = delegateAlarm;

            InitProgressForm();
        }
        /// <summary>
        /// 2020.02.05 by yjlee [ADD] Exit the software.
        /// 2021.08.18. by shkim [MOD] Task Thread가 정지되기 전에 Recipe 인스턴스를 소멸시키면 Exception 발생하여 위치 변경
        /// </summary>
        public void Exit()
		{
            // 2021.08.14 by junho [ADD] FFU : 중지가 Recipe보다 먼저 수행되어야 한다.
            //ExternalDevice.FFUManager.GetInstance().Deactivate();

			// Save 이후 인스턴스 소멸동작이 아닌
			// 클래스 내부에서 사용하는 인스턴스들을 유지하고, Process Recipe Save 동작만 하도록 변경
			#region Recipe
			Recipe.Recipe.GetInstance().SaveProcessRecipe();
			#endregion

			#region Logging
			Log.LogManager.GetInstance().Exit();
            Log.LogWriter.GetInstance().Deactivate();
            #endregion

            #region Config
            Account_.Account.GetInstance().Exit();
            Alarm.GetInstance().Exit();
            Socket.GetInstance().Exit();
            Serial.GetInstance().Exit();
            Cylinder.GetInstance().Exit();
            Interrupt.GetInstance().Exit();
            Trigger.GetInstance().Exit();
            AnalogIO_.AnalogIO.GetInstance().Exit();
            DigitalIO_.DigitalIO.GetInstance().Exit();
            Motion_.Motion.GetInstance().Exit();
            Vision_.Vision.GetInstance().Exit();
            Language_.Language.GetInstance().Exit();
            JogManager_.JogManager.GetInstance().Exit();
            #endregion

            #region Task
            RegisteredInstances_.RegisteredInstanceManager.GetInstance().Exit();
            TaskAction_.TaskActionFlow.GetInstance().Exit();
            TaskAction_.TaskActionManager.GetInstance().Exit();
            TaskDevice_.TaskDevice.GetInstance().Exit();
            #endregion

            #region Recipe
            RecipeManager_.RecipeManager.GetInstance().Exit();
            #endregion

            #region File Management
            FileBorn_.FileBorn.GetInstance().Exit();
            FileComposite_.FileComposite.GetInstance().Exit();
			FileIOManager_.FileIOManager.GetInstance().Exit();
            #endregion

//             ExternalDevice.TransportWIR.GetInstance().con();
//             ExternalDevice.TransportWIR.GetInstance().Close();

            #region Thread Timer
            ThreadTimer.GetInstance().Exit();
            #endregion
        }
        /// <summary>
        /// 2020.05.12 by yjlee [ADD] Initialize the instances of the DLL.
        /// </summary>
        public bool DoInitializeSequence()
        {
            bool bResult                = false;
            string strContentsResult    = null;

            switch (m_enInitializeStep)
            {
                case EN_INITIALIZATION_STEP.INIT_START:
                    if (false == ShowProgressForm()) { return false; }
                    strContentsResult = "The System is being Start... ";
                    break;

                #region Observer
                case EN_INITIALIZATION_STEP.INIT_OBSERVER_START:
                    strContentsResult = "The observers are being attached to the subjects... ";
                    break;

                case EN_INITIALIZATION_STEP.INIT_OBSERVER_END:
                    RegisterObserverEvent();
                    bResult = true;
                    break;
                #endregion

                #region File IO
                case EN_INITIALIZATION_STEP.INIT_FILEIO_START:
                    strContentsResult = "The file I/O is being initialized... ";
                    break;

                case EN_INITIALIZATION_STEP.INIT_FILEIO_END:
                    Log.LogWriter.GetInstance().Activate();
                    bResult = FileIOManager_.FileIOManager.GetInstance().Init();
                    break;
                #endregion

                #region Account
                case EN_INITIALIZATION_STEP.INIT_ACCOUNT_START:
                    strContentsResult = "The accout is being initialized... ";
                    break;

                case EN_INITIALIZATION_STEP.INIT_ACCOUNT_END:
                    bResult = Account_.Account.GetInstance().Init(System.Diagnostics.Debugger.IsAttached);

                    break;
                #endregion

                #region Alarm
                case EN_INITIALIZATION_STEP.INIT_ALARM_START:
                    strContentsResult = "The alarm is being initialized... ";
                    break;

                case EN_INITIALIZATION_STEP.INIT_ALARM_END:
                    bResult = Alarm_.Alarm.GetInstance().Init();
                    break;
                #endregion

                #region Socket
                case EN_INITIALIZATION_STEP.INIT_SOCKET_START:
                    strContentsResult = "The socket communication is being initialized... ";
                    break;

                case EN_INITIALIZATION_STEP.INIT_SOCKET_END:
                    bResult = Socket_.Socket.GetInstance().Init();
                    break;
                #endregion

                #region Serial
                case EN_INITIALIZATION_STEP.INIT_SERIAL_START:
                    strContentsResult = "The serial communication is being initialized... ";
                    break;

                case EN_INITIALIZATION_STEP.INIT_SERIAL_END:
                    bResult = Serial.GetInstance().Init();
                    break;
                #endregion

                #region Analog IO
                case EN_INITIALIZATION_STEP.INIT_ANALOG_IO_START:
                    strContentsResult = "The analog I/O is being initialized... ";
                    break;

                case EN_INITIALIZATION_STEP.INIT_ANALOG_IO_END:
                    // AnalogIO.AnalogIOController
                    //m_arAnalogIOController = new AnalogIOController[1];

                    //m_arAnalogIOController[0] = new Controller.AnalogIO.RSAAnalogIOController();
                    //bResult = AnalogIO.GetInstance().Init(ref m_arAnalogIOController);
                    break;
                #endregion

                #region Digital IO
                case EN_INITIALIZATION_STEP.INIT_DIGITAL_IO_START:
                    strContentsResult = "The digital I/O is being initialized... ";
                    break;

                case EN_INITIALIZATION_STEP.INIT_DIGITAL_IO_END:
                    // DigitalIO.DigitalIOController
                    //m_arDigitalIOController = new DigitalIOController[1];

                    //m_arDigitalIOController[0] = new Controller.DigitalIO.RSADigitalIOController();
                    //bResult = DigitalIO.GetInstance().Init(ref m_arDigitalIOController);
                    break;
                #endregion

                #region Cylinder
                case EN_INITIALIZATION_STEP.INIT_CYLINDER_START:
                    strContentsResult = "The cylinder is being initialized... ";
                    break;

                case EN_INITIALIZATION_STEP.INIT_CYLINDER_END:
                    delegateCylinderForReadingInput = new DelegateForReadingIO(DigitalIO.GetInstance().ReadInput);
                    delegateCylinderForReadingOutput = new DelegateForReadingIO(DigitalIO.GetInstance().ReadOutput);
                    delegateCylinderForWritingOutput = new DelegateForWritingIO(DigitalIO.GetInstance().WriteOutput);

                    bResult = Cylinder.GetInstance().Init(delegateCylinderForReadingInput
                        , delegateCylinderForReadingOutput
                        , delegateCylinderForWritingOutput);
                    break;
                #endregion

                #region Interrupt
                case EN_INITIALIZATION_STEP.INIT_INTERRUPT_START:
                    strContentsResult = "The interrupt is being initialized... ";
                    break;

                case EN_INITIALIZATION_STEP.INIT_INTERRUPT_END:
                    delegateInterruptForReadingInput = new DelegateForReadingInput(DigitalIO.GetInstance().ReadInput);
                    delegateInterruptForWriteOutput = new DelegateForWriteDigitalOutput(DigitalIO.GetInstance().WriteOutput);

                    bResult = Interrupt.GetInstance().Init(delegateInterruptForReadingInput
                        , delegateInterruptForWriteOutput
                        , delegateInterruptForActionStart
                        , delegateInterruptForActionStop
                        , delegateInterruptForActionReset
                        , delegateInterruptForActionAlarm);
                    break;
                #endregion

                #region Trigger
                case EN_INITIALIZATION_STEP.INIT_TRIGGER_START:
                    strContentsResult = "The trigger is being initialized... ";
                    break;

                case EN_INITIALIZATION_STEP.INIT_TRIGGER_END:
                    delegateTriggerForWritingOutput = new DelegateForWritingOutput(DigitalIO.GetInstance().WriteOutput);
                    bResult = Trigger.GetInstance().Init(delegateTriggerForWritingOutput);
                    break;
                #endregion

                #region Motion
                case EN_INITIALIZATION_STEP.INIT_MOTION_START:
                    strContentsResult = "The motion is being initialized... ";
                    break;

                case EN_INITIALIZATION_STEP.INIT_MOTION_END:
                    // Motion.MotionController
                    //m_arMotionController = new MotionController[1];
                    //m_arMotionController[0] = new FrameOfSystem3.Controller.Motion.RSAMotionController();	// < RSA 일경우
                    //m_arMotionController[0] = null;

                    bResult = Motion_.Motion.GetInstance().Init(ref m_arMotionController, Define.DefineConstant.Motion.INTERVAL_CHECKING_CONNECTION);
                    break;
                #endregion

                #region Langauge
                case EN_INITIALIZATION_STEP.INIT_LANGUAGE_START:
                    strContentsResult = "The language is being initialized... ";
                    break;

                case EN_INITIALIZATION_STEP.INIT_LANGUAGE_END:
                    bResult = Language_.Language.GetInstance().Init();
                    break;
                #endregion

                #region TaskDevice
                case EN_INITIALIZATION_STEP.INIT_TASK_DEVICE_START:
                    strContentsResult = "The Task Device is being initialized... ";
                    break;

                case EN_INITIALIZATION_STEP.INIT_TASK_DEVICE_END:
                    bResult = TaskDevice.GetInstance().Init();
                    break;
                #endregion

                #region Registered Instances
                case EN_INITIALIZATION_STEP.INIT_REGISTERED_INSTANCES_START:
                    strContentsResult = "The registered manager is being initialized... ";
                    break;

                case EN_INITIALIZATION_STEP.INIT_REGISTERED_INSTANCES_END:
                    Interface.RegisteredInterface pInterface = new Interface.RegisteredInterface();
                    m_pRegisteredInterface = pInterface as RegisteredInterfaces;

                    bResult = RegisteredInstanceManager.GetInstance().Init(m_pRegisteredInterface);
                    break;
                #endregion

                #region Thread Timer
                case EN_INITIALIZATION_STEP.INIT_THREADTIMER_START:
                    strContentsResult = "The ThreadTimer is being initialized... ";
                    break;

                case EN_INITIALIZATION_STEP.INIT_THREADTIMER_END:
                    GetDllInstance();

                    bResult = SetThreadTimer();
                    break;
                #endregion

                #region Recipe
                case EN_INITIALIZATION_STEP.INIT_RECIPE_START:
                    strContentsResult = "The instance of the recipe is being initialized... ";
                    break;

                case EN_INITIALIZATION_STEP.INIT_RECIPE_END:
                    bResult = RecipeManager_.RecipeManager.GetInstance().Init();
                    break;
                #endregion

                #region Config Files
                case EN_INITIALIZATION_STEP.INIT_CONFIG_INSTANCES_START:
                    strContentsResult = "The system makes the instances for the device configurations... ";
                    break;

                case EN_INITIALIZATION_STEP.INIT_CONFIG_INSTANCES_END:
                    Functional.Storage.GetInstance().Init();
                    FileBorn_.FileBorn.GetInstance().Init();

                    bResult = true;
                    bResult &= Config.ConfigTask.GetInstance().Init();
                    bResult &= Config.ConfigDigitalIO.GetInstance().Init();
                    bResult &= Config.ConfigAnalogIO.GetInstance().Init();
                    bResult &= Config.ConfigCylinder.GetInstance().Init();
                    bResult &= Config.ConfigSocket.GetInstance().Init();
                    bResult &= Config.ConfigSerial.GetInstance().Init();
                    bResult &= Config.ConfigInterrupt.GetInstance().Init();
                    bResult &= Config.ConfigTrigger.GetInstance().Init();
                    bResult &= Config.ConfigLanguage.GetInstance().Init();
                    bResult &= Config.ConfigAlarm.GetInstance().Init();
                    bResult &= Config.ConfigMotion.GetInstance().Init();
                    bResult &= Config.ConfigMotionSpeed.GetInstance().Init();
                    bResult &= Config.ConfigJog.GetInstance().Init();
                    bResult &= Config.ConfigDevice.GetInstance().Init();
                    bResult &= Config.ConfigPort.GetInstance().Init();
                    bResult &= Config.ConfigDynamicLink.GetInstance().Init();
                    bResult &= Config.ConfigFlow.GetInstance().Init();
                    bResult &= Config.ConfigTool.GetInstance().Init();          // 2021.09.27 by jhchoo [ADD]
                    bResult &= Account.CAccount.GetInstance().Init();
                    break;
                #endregion

                #region Task
                case EN_INITIALIZATION_STEP.INIT_TASK_START:
                    strContentsResult = "The system makes the instances of the task... ";
                    break;

                case EN_INITIALIZATION_STEP.INIT_TASK_END:
                    bResult = Task.TaskOperator.GetInstance().InitializeTask();
                    break;
                #endregion

                #region Load Recipe
                case EN_INITIALIZATION_STEP.LOAD_RECIPE_START:
                    strContentsResult = "The system is loading the file of the recipe... ";
                    break;

                case EN_INITIALIZATION_STEP.LOAD_RECIPE_END:
                    bResult = Recipe.Recipe.GetInstance().Init();
                    break;
                #endregion

                #region Vision
                case EN_INITIALIZATION_STEP.INIT_VISION_START:
                    strContentsResult = "The vision is being initialized... ";
                    break;

                case EN_INITIALIZATION_STEP.INIT_VISION_END:
                    Vision_.Vision vision = Vision_.Vision.GetInstance();
                    bResult = vision.Init(new Controller.Vision.ProtecVisionController((int)Define.DefineEnumProject.Socket.EN_SOCKET_INDEX.VISION), Define.DefineConstant.Vision.COUNT_CAM);
                    if (bResult)
                    {
                        FrameOfSystem3.Task.TaskOperator.GetInstance().AddDelegateSetOperation(new RunningMain_.RunningMain.DelegateWithSetOperation(vision.ResetVision));

                        // check here : vision algorithm assine
                        //vision.AddResultParsingDelegate((int)EN_CAMERA_LIST.ALIGN, (int)EN_VISION_ALGORITHM.FLUX_SUBJECT_1st, VisionResultParser_BP5000IR.ALIGN_MATCHING_DB);
                    }
                    break;
                #endregion

                #region LOG
                case EN_INITIALIZATION_STEP.INIT_LOG_START:
                    strContentsResult = "The log instance is being initialized... ";
                    break;

                case EN_INITIALIZATION_STEP.INIT_LOG_END:
                    bResult = Log.LogManager.GetInstance().Init();
                    break;
                #endregion

                #region INTERLOCK
                case EN_INITIALIZATION_STEP.INIT_INTERLOCK_START:
                    strContentsResult = "The Interlock instance is being initialized... ";
                    break;

                case EN_INITIALIZATION_STEP.INIT_INTERLOCK_END:
                    bResult = Config.ConfigInterlock.GetInstance().Init();
                    break;
                #endregion

                #region EXTERNAL
                case EN_INITIALIZATION_STEP.INIT_EXTERNAL_DEVICE_START:
                    strContentsResult = "The External Device is being initialized... ";
                    break;

                case EN_INITIALIZATION_STEP.INIT_EXTERNAL_DEVICE_END:
                    bResult = true;
                    //#region POWERMETER
                    ////Powermeter
                    //ExternalDevice.Serial.Powermeter.GetInstance().Init((int)Define.DefineEnumProject.Serial.EN_SERIAL_INDEX.POWERMETER);
                    //ExternalDevice.Serial.Powermeter.GetInstance().SetDeviceType(Config.SystemConfig.GetInstance().Powermeter);
                    //#endregion /POWERMETER

                    #region Laser LD 1
                    int nLaserCount = 18;
                    int[] arControl = new int[]{(int)Define.DefineEnumProject.Serial.EN_SERIAL_INDEX.LD_CONTROL_1
                                              , (int)Define.DefineEnumProject.Serial.EN_SERIAL_INDEX.LD_CONTROL_2
                                              , (int)Define.DefineEnumProject.Serial.EN_SERIAL_INDEX.LD_CONTROL_3};
                    bResult &= ExternalDevice.Serial.ProtecLaserController.GetInstance().Initialize(arControl, (int)Define.DefineEnumProject.Serial.EN_SERIAL_INDEX.LD_MONITOR);
                    bResult &= Laser.ProtecLaserMananger.GetInstance().Init(nLaserCount);

                    Laser.ProtecLaserChannelCalibration.GetInstance().Init(nLaserCount);
                    for (int nIndex = 0; nIndex < nLaserCount; nIndex++)
                    {
                        Laser.ProtecLaserChannelCalibration.GetInstance().LinkLaserChannel(nIndex, (int)Define.DefineEnumProject.AnalogIO.EN_ANALOG_IN.POWER_CH_1 + nIndex);
                    }
                    #endregion /Laser LD 1

                    #region Laser LD 2
                    int nLaserCount_2 = 18;
                    int[] arControl_2 = new int[]{(int)Define.DefineEnumProject.Serial.EN_SERIAL_INDEX.LD_2_CONTROL_1
                                                , (int)Define.DefineEnumProject.Serial.EN_SERIAL_INDEX.LD_2_CONTROL_2
                                                , (int)Define.DefineEnumProject.Serial.EN_SERIAL_INDEX.LD_2_CONTROL_3};
                    bResult &= ExternalDevice.Serial.ProtecLaserController_2.GetInstance().Initialize(arControl_2, (int)Define.DefineEnumProject.Serial.EN_SERIAL_INDEX.LD_2_MONITOR);
                    bResult &= Laser.ProtecLaserMananger_2.GetInstance().Init(nLaserCount_2);

                    Laser.ProtecLaserChannelCalibration_2.GetInstance().Init(nLaserCount_2);
                    for (int nIndex = 0; nIndex < nLaserCount_2; nIndex++)
                    {
                        Laser.ProtecLaserChannelCalibration_2.GetInstance().LinkLaserChannel(nIndex, (int)Define.DefineEnumProject.AnalogIO.EN_ANALOG_IN.POWER_2_CH_1 + nIndex);
                    }
                    #endregion /Laser LD 2

                    //#region CHILLER
                    //int nChilerIndex = (int)Define.DefineEnumProject.Serial.EN_SERIAL_INDEX.MODBUS_CHILLER;
                    //bResult &= ExternalDevice.Serial.ModbusRTU.GetInstance(nChilerIndex).Init(nChilerIndex);
                    //ExternalDevice.Serial.ChillerCX9230Modbus Chiller = new ExternalDevice.Serial.ChillerCX9230Modbus(nChilerIndex, 1);
                    //ExternalDevice.Serial.ModbusRTU.GetInstance(nChilerIndex).AddDevice(Chiller);
                    //#endregion /CHILLER

                    //#region Heater
                    ////Heater
                    //int nHeaterSerialIndex = (int)Define.DefineEnumProject.Serial.EN_SERIAL_INDEX.HEATER;
                    //bResult &= ExternalDevice.Serial.ModbusRTU.GetInstance(nHeaterSerialIndex).Init(nHeaterSerialIndex);
                    //ExternalDevice.Serial.Heater_TX4S Heater = new ExternalDevice.Serial.Heater_TX4S(nHeaterSerialIndex, 1);
                    //ExternalDevice.Serial.ModbusRTU.GetInstance(nHeaterSerialIndex).AddDevice(Heater);
                    //Heater = new ExternalDevice.Serial.Heater_TX4S(nHeaterSerialIndex, 2);
                    //ExternalDevice.Serial.ModbusRTU.GetInstance(nHeaterSerialIndex).AddDevice(Heater);
                    //ExternalDevice.Heater.Heater.GetInstance().AddSerialHeaterZone((int)Define.DefineEnumProject.Heater.EN_HEATER_ZONE_LIST.BLCOK, nHeaterSerialIndex, 1, 2);
               
                    //double dTemp = Recipe.Recipe.GetInstance().GetValue(EN_TASK_LIST.WORK_ZONE.ToString(), WORKZONE_TASK_PARAM.HEATER_TARGET_TEMP.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                    //ExternalDevice.Heater.Heater.GetInstance().SetTargetTemp((int)Define.DefineEnumProject.Heater.EN_HEATER_ZONE_LIST.BLCOK, dTemp, false);

                    //double dPlusTolerance = Recipe.Recipe.GetInstance().GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.WORK_BLOCK_TOLERANCE_MAX.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                    //ExternalDevice.Heater.Heater.GetInstance().SetTempPlusTolerance((int)Define.DefineEnumProject.Heater.EN_HEATER_ZONE_LIST.BLCOK, dPlusTolerance);

                    //double dMinusTolerance = Recipe.Recipe.GetInstance().GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.WORK_BLOCK_TOLERANCE_MIN.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
                    //ExternalDevice.Heater.Heater.GetInstance().SetTempMinusTolerance((int)Define.DefineEnumProject.Heater.EN_HEATER_ZONE_LIST.BLCOK, dMinusTolerance);

                    //Recipe.Recipe.ParameterChangedNotify += WhenRecipeChangedHeater;

                    //#endregion /Heater

                    //#region IR CAM
                    //bResult &= ExternalDevice.Socket.IR.GetInstance().Init((int)Define.DefineEnumProject.Socket.EN_SOCKET_INDEX.IR);
                    //#endregion /IR CAM

                    //#region FFU
                    //bResult &= ExternalDevice.FFUManager.GetInstance().Activate();
                    //#endregion /FFU

                    //#region WCF
                    //ExternalDevice.TransportWIR.GetInstance().Init();

                    //ExternalDevice.EFEMManager.GetInstance().Init();

                    //#endregion

                    break;
                #endregion

                #region SCHEDULER
                case EN_INITIALIZATION_STEP.INIT_SCHEDULER_START:
                    strContentsResult = "The Scheduler is being initialized... ";
                    break;

                case EN_INITIALIZATION_STEP.INIT_SCHEDULER_END:
                    Scheduler.Schedule DeleteLog = new Scheduler.Schedule();
                    DeleteLog.Hour = 0;
                    DeleteLog.delFunction = new Scheduler.delGenerateFunction(FunctionsETC.DeleteLogFile);
                    Scheduler.GetInstance().AddSchedule("DeleteFile", DeleteLog);

                    Scheduler.Schedule BackUpFile = new Scheduler.Schedule();
                    BackUpFile.Hour = 0;
                    BackUpFile.delFunction = new Scheduler.delGenerateFunction(FunctionsETC.ImportantFileBackup);
                    Scheduler.GetInstance().AddSchedule("BackUpFile", BackUpFile);

                    bResult = Scheduler.GetInstance().Init();
                    break;
                #endregion

                #region TOOL
                case EN_INITIALIZATION_STEP.INIT_TOOL_START:
                    strContentsResult = "The Tool is being initialized... ";
                    break;

                case EN_INITIALIZATION_STEP.INIT_TOOL_END:
                    Tool.WorkTool.GetInstance().Init();
                    bResult = true;
                    break;
                #endregion

                #region WORK INFORMATION
                case EN_INITIALIZATION_STEP.INIT_WORKINFORMATION_START:
                    strContentsResult = "The WorkInformation is being initialized... ";
                    break;

                case EN_INITIALIZATION_STEP.INIT_WORKINFORMATION_END:
                    Work.WorkMap.GetInstance().Init();
                    bResult = true;
                    break;
                #endregion


                #region WORK INFORMATION
                case EN_INITIALIZATION_STEP.INIT_E10_START:
                    strContentsResult = "The E10 is being initialized... ";
                    break;

                case EN_INITIALIZATION_STEP.INIT_E10_END:
                    EquipmentMonitor.RAM_Metrics.GetInstance().Init();
                    bResult = true;
                    break;
                #endregion

                case EN_INITIALIZATION_STEP.INIT_END:
                    ExitProgressForm();
                    return true;
            }

            //Release 모드이다.
            if (m_bShowProgressWhenAttachedDebuger == System.Diagnostics.Debugger.IsAttached)
            {
                int nInitializeStep = (int)m_enInitializeStep;

                if (0 != nInitializeStep % 2 && nInitializeStep > 2)
                {
                    m_Progress.EnqueueResult(false, ref bResult);
                }
                else
                {
                    m_Progress.EnqueueResult(true, ref strContentsResult);
                }                
            }

            ++ m_enInitializeStep;            

            return false;
        }
        /// <summary>
        /// 2020.05.18 by yjlee [ADD] Check whether the initialization sequence is end or not.
        /// </summary>
        public bool IsInitializationEnd()
        {
            return m_enInitializeStep == EN_INITIALIZATION_STEP.INIT_END
                && null == m_Progress;
        }
        #endregion

        #region Equipment Property
        private void UpdateEquipmentProperty()
        {
            bool bRunning = false;
            foreach (Define.DefineEnumProject.Task.EN_TASK_LIST en in Enum.GetValues(typeof(Define.DefineEnumProject.Task.EN_TASK_LIST)))
            {
                RunningMain_.TaskData taskData = null;
                if (Task.TaskOperator.GetInstance().GetTaskInformation((int)en, ref taskData))
                    bRunning |= taskData.strTaskState == "RUN";
            }
            if (bRunning)
            {
                EquipmentProperty.EquipmentProperty.GetInstance().SetValue(EquipmentProperty.EN_EQUIPMENT_PROPERTY_LIST.ACTION_RUNNING, EquipmentProperty.EN_ACTION_RUNNING_VALUES.RUNNING);
            }
            else
            {
                EquipmentProperty.EquipmentProperty.GetInstance().SetValue(EquipmentProperty.EN_EQUIPMENT_PROPERTY_LIST.ACTION_RUNNING, EquipmentProperty.EN_ACTION_RUNNING_VALUES.STOP);
            }


            if (EquipmentProperty.RawMaterialPortManager.GetInstance().GetRawMaterialExist())
                EquipmentProperty.EquipmentProperty.GetInstance().SetValue(EquipmentProperty.EN_EQUIPMENT_PROPERTY_LIST.MATERIAL_EXIST, EquipmentProperty.EN_MATERIAL_EXIST_VALUES.EXIST);
            else
                EquipmentProperty.EquipmentProperty.GetInstance().SetValue(EquipmentProperty.EN_EQUIPMENT_PROPERTY_LIST.MATERIAL_EXIST, EquipmentProperty.EN_MATERIAL_EXIST_VALUES.EMPTY);
        }

        #endregion
    }
}