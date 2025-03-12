using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;

using Account_;

using Define.DefineConstant;
using Define.DefineEnumProject.ButtonEvent;
using Define.DefineEnumBase.ButtonEvent;
using System.Runtime.InteropServices;
using EquipmentState_;

namespace FrameOfSystem3.Views
{
    public partial class Form_Frame : Form
    {
        #region 32 bit API
        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);

        /// <summary>
        /// 2021.01.13 by yjlee [ADD] Enumerate the special flags for the setting the position of the windows.
        /// </summary>
        private enum WINPOS_SPFLAG
        {
            HWND_TOP        = 0,
            HWND_BOTTOM     = 1,
            HWND_TOPMOST    = -1,
            HWND_NOTOPMOST  = -2,
        }
        /// <summary>
        /// 2021.01.13 by yjlee [ADD] Enumerate the flags for the setting the position of the windows.
        /// </summary>
        private enum WINPOS_FLAG
        {
            NOSIZE          = 0x0001,
            NOMOVE          = 0x0002,
            NOZORDER        = 0x0004,
            NOREDRAW        = 0x0008,
            NOACTIVATE      = 0x0010,
            DRAWFRAME       = 0x0020,
            FRAMECHANGED    = 0x0020,
            SHOWWINDOW      = 0x0040,
            HIDEWINDOW      = 0x0080,
            NOCOPYBITS      = 0x0100,
            NOOWNERZORDER   = 0x0200,
            NOREPOSITION    = 0x0200,
            NOSENDCHANGING  = 0x0400,
            DEFERERASE      = 0x2000,
            ASYNCWINDOWPOS  = 0x4000,
        }
        #endregion End - 32 bit API

        #region Variables

        #region Panel

        TitleBar  m_viewTitleBar      = new TitleBar();
        SubMenu   m_viewSubMenu       = new SubMenu();
        MainMenu  m_viewMainMenu      = new MainMenu();

        private Dictionary<EN_BUTTONEVENT_MAINMENU, List<string>> m_dicOfSubMenus       = new Dictionary<EN_BUTTONEVENT_MAINMENU, List<string>>();

        EN_BUTTONEVENT_MAINMENU m_enClickedMainMenu     = EN_BUTTONEVENT_MAINMENU.OPERATION;
        EN_BUTTONEVENT_SUBMENU m_enClickedSubMenu       = EN_BUTTONEVENT_SUBMENU.OPERATION_MAIN;

        #region Main view
        Dictionary<EN_BUTTONEVENT_SUBMENU, UserControlForMainView.CustomView> m_dicOfMainView           = new Dictionary<EN_BUTTONEVENT_SUBMENU, UserControlForMainView.CustomView>();
        Dictionary<EN_BUTTONEVENT_MAINMENU, EN_BUTTONEVENT_SUBMENU> m_dicOfMainViewByMainButtonEvent    = new Dictionary<EN_BUTTONEVENT_MAINMENU, EN_BUTTONEVENT_SUBMENU>();
        Dictionary<EN_BUTTONEVENT_SUBMENU, string> m_mappingForButtonName                               = new Dictionary<EN_BUTTONEVENT_SUBMENU,string>();
        Dictionary<EN_BUTTONEVENT_SUBMENU, int> m_dicOfTimerInterval                                    = new Dictionary<EN_BUTTONEVENT_SUBMENU, int>();

        UserControlForMainView.CustomView m_viewRecentView;

		#region Operation
		Views.Operation.Operation_Main			m_viewOperationMain				= new Operation.Operation_Main();
		//Views.Operation.Operation_StateMonitor	m_viewOperationMonitor			= new Operation.Operation_StateMonitor();
		//Views.Operation.Operation_Tracking		m_viewOperationTracking			= new Operation.Operation_Tracking();
  //      Views.Operation.Operation_RAMMetrics    m_viewOperationRAMMetrics       = new Operation.Operation_RAMMetrics();
		#endregion

		#region Recipe
		Views.Recipe.Recipe_Main	m_viewRecipeMain	= new Recipe.Recipe_Main();
		Views.Recipe.Recipe_Options m_viewRecipeOptions = new Recipe.Recipe_Options();
        #endregion

        #region Setup
        Views.Setup.Setup_Work                      m_viewSetupWork                 = new Setup.Setup_Work();
        //Views.Setup.Setup_Transfer				m_viewSetupTransfer			    = new Setup.Setup_Transfer();
        //Views.Setup.Setup_Equipment				m_viewSetupEquipment			= new Setup.Setup_Equipment();
        #endregion

        #region History
        Views.History.History_MainLog       m_viewHistoryMainLog            = new History.History_MainLog();
        #endregion

        #region Config
        Views.Config.Config_Alarm           m_viewConfigAlarm               = new Config.Config_Alarm();
        Views.Config.Config_Analog          m_viewConfigAnalog              = new Config.Config_Analog();
        Views.Config.Config_Cylinder        m_viewConfigCylindre            = new Config.Config_Cylinder();
        Views.Config.Config_Digital         m_viewConfigDigital             = new Config.Config_Digital();
        Views.Config.Config_Trigger			m_viewConfigTrigger				= new Config.Config_Trigger();
        Views.Config.Config_Language        m_viewConfigLanguage            = new Config.Config_Language();
        Views.Config.Config_Motion          m_viewConfigMotion              = new Config.Config_Motion();
		
		// 2021.08.06 by junho [MOD] merge Socket and Serial to Communication
		//Views.Config.Config_Serial          m_viewConfigSerial              = new Config.Config_Serial();
		//Views.Config.Config_Socket          m_viewConfigSocket              = new Config.Config_Socket();
		Views.Config.Config_Communication m_viewConfigCommunication = new Config.Config_Communication();

        Views.Config.Config_Interrupt       m_viewConfigInterrupt           = new Config.Config_Interrupt();
        Views.Config.Config_Tool            m_viewConfigTool                = new Config.Config_Tool();     // 2021.10.06 jhchoo [ADD]

		// Link, Flow, Port -> Action 내의 탭 전환 페이지로 변경
		Views.Config.Config_Action          m_viewConfigAction              = new Config.Config_Action();

		// 2022.10.25 by junho [MOD] for jog manager
		//Views.Config.Config_Jog				m_viewConfigJog					= new Config.Config_Jog();
		Views.Config.Config_JogManage		m_viewConfigJog					= new Config.Config_JogManage();

		Views.Config.Config_Device			m_viewConfigDevice				= new Config.Config_Device();
		Views.Config.Config_Parameters		m_viewConfigParameter			= new Config.Config_Parameters();
		Views.Config.Config_Interlock		m_viewConfigInterlock			= new Config.Config_Interlock(); // 2022.02.15 WDW [ADD]
        #endregion

        #region Log Process
        Process m_processLog                = null;
        #endregion End - Log Process

        #endregion

        #endregion

        #region Functional Form
        private Views.Login.Form_Login				m_fLogin            = new Views.Login.Form_Login();
        #endregion

		#region Log
		private Log.LogManager m_InstanceOfLog				= null;
		#endregion

		#region AlarmForm
		private Views.Functional.Form_AlarmMessage		m_fAlarmMessage		= Views.Functional.Form_AlarmMessage.GetInstance();

		private Queue<EN_ALARM_FORM_STATE> queueState	= new Queue<EN_ALARM_FORM_STATE>();
		private System.Threading.ReaderWriterLockSlim m_RWLock	= new System.Threading.ReaderWriterLockSlim();
		#endregion

		#region ProgressBar Form
		private Views.Functional.Form_ProgressBar		m_fProgressBar		= null;
		private EN_PROGRESS_BAR_FORM_STATE enProgressBarState				= EN_PROGRESS_BAR_FORM_STATE.WATING;
		#endregion

		#region Timer
		System.Windows.Forms.Timer m_pTimerForUpdateGUI						= new Timer();
		System.Windows.Forms.Timer m_pTimerForAlarm							= new Timer();
        #endregion

        #endregion

        public Form_Frame()
        {
            InitializeComponent();

            InitializePanel();

            InitializeMainView();

            InitializeInstances();

			RegisterEventForGUI();

			InitializeFuntional();

            SetExternalProcess();

            // 2021.10.06. jhlim [ADD] 통신 및 시나리오를 초기화한다.
            InitScenarioHandler();
			// GUI 생성 전 발생한 알람이 있는지 확인한다.
			m_fAlarmMessage.ManualCheckIsGeneratedAlarm();
        }

		public enum EN_ALARM_FORM_STATE
		{
			WATING,
			DISPLAYING,
			OFF,
		}
		public enum EN_PROGRESS_BAR_FORM_STATE
		{
			WATING,
			DISPLAYING,
			OFF,
		}

        #region Initialize Panel
        /// <summary>
        /// 2020.02.05 by yjlee [ADD] Initialize the panels.
        /// </summary>
        private void InitializePanel()
        {
            // 1. TitleBar
            m_panelTitleBar.Controls.Add(m_viewTitleBar);

            // 2. MainMenu
            m_viewMainMenu.evtButtonClick   += ReceiveEventFromMainMenu;
            m_panelMainMenu.Controls.Add(m_viewMainMenu);

            // 3. SubMenu
            m_viewSubMenu.evtButtonClick    += ReceiveEventFromSubMenu;
            m_panelSubMenu.Controls.Add(m_viewSubMenu);

            // 4. Make default mapping tables.
            foreach(EN_BUTTONEVENT_MAINMENU enMainMenu in Enum.GetValues(typeof(EN_BUTTONEVENT_MAINMENU)))
            {
                m_dicOfSubMenus.Add(enMainMenu, new List<string>());
            }

            foreach(EN_BUTTONEVENT_SUBMENU enSubMenu in Enum.GetValues(typeof(EN_BUTTONEVENT_SUBMENU)))
            {
                string strSubMenu       = enSubMenu.ToString();
                int nIndexOfToken       = strSubMenu.IndexOf('_');

                if(-1 != nIndexOfToken)
                {
                    EN_BUTTONEVENT_MAINMENU enMainMenu  = EN_BUTTONEVENT_MAINMENU.EXIT;

                    string strMainMenu      = strSubMenu.Substring(0, nIndexOfToken);
                    
                    if(Enum.TryParse(strMainMenu, out enMainMenu))
                    {
                        string strButtonName    = strSubMenu.Substring(nIndexOfToken + 1).Replace('_', ' ');

                        m_dicOfSubMenus[enMainMenu].Add(strButtonName);
                        m_mappingForButtonName.Add(enSubMenu, strButtonName);
                    }
                }
            }

            // 5. set initialization state
            m_viewSubMenu.SetButtons(m_dicOfSubMenus[m_enClickedMainMenu]);
        }
        #endregion

        #region Initialize Main View
        /// <summary>
        /// 2020.05.15 by yjlee [ADD] Initialize the data structure for the main views.
        /// </summary>
        private void InitializeMainView()
        {
            #region Make mapping table
			m_dicOfMainViewByMainButtonEvent.Add(EN_BUTTONEVENT_MAINMENU.OPERATION, EN_BUTTONEVENT_SUBMENU.OPERATION_MAIN);
            m_dicOfMainViewByMainButtonEvent.Add(EN_BUTTONEVENT_MAINMENU.CONFIG, EN_BUTTONEVENT_SUBMENU.CONFIG_MOTION);
            m_dicOfMainViewByMainButtonEvent.Add(EN_BUTTONEVENT_MAINMENU.RECIPE, EN_BUTTONEVENT_SUBMENU.RECIPE_MAIN);
            m_dicOfMainViewByMainButtonEvent.Add(EN_BUTTONEVENT_MAINMENU.HISTORY, EN_BUTTONEVENT_SUBMENU.HISTORY_MAIN_LOG);
			m_dicOfMainViewByMainButtonEvent.Add(EN_BUTTONEVENT_MAINMENU.SETUP, EN_BUTTONEVENT_SUBMENU.SETUP_WORK);
            #endregion

			#region Operation
			m_dicOfMainView.Add(EN_BUTTONEVENT_SUBMENU.OPERATION_MAIN, m_viewOperationMain);
            //m_dicOfMainView.Add(EN_BUTTONEVENT_SUBMENU.OPERATION_MONITORING, m_viewOperationMonitor);
            //m_dicOfMainView.Add(EN_BUTTONEVENT_SUBMENU.OPERATION_RAM_METRICS, m_viewOperationRAMMetrics);
			//m_dicOfMainView.Add(EN_BUTTONEVENT_SUBMENU.OPERATION_TRACKING, m_viewOperationTracking);
			#endregion

			#region Recipe
			m_dicOfMainView.Add(EN_BUTTONEVENT_SUBMENU.RECIPE_MAIN, m_viewRecipeMain);
			//m_dicOfMainView.Add(EN_BUTTONEVENT_SUBMENU.RECIPE_OPTIONS, m_viewRecipeOptions);
            #endregion

            #region History
            m_dicOfMainView.Add(EN_BUTTONEVENT_SUBMENU.HISTORY_MAIN_LOG, m_viewHistoryMainLog);
            #endregion

            #region Setup
            m_dicOfMainView.Add(EN_BUTTONEVENT_SUBMENU.SETUP_WORK, m_viewSetupWork);
            //m_dicOfMainView.Add(EN_BUTTONEVENT_SUBMENU.SETUP_TRANSFER, m_viewSetupTransfer);
            //m_dicOfMainView.Add(EN_BUTTONEVENT_SUBMENU.SETUP_EQUIPMENT, m_viewSetupEquipment);
            #endregion

            #region Config
            m_dicOfMainView.Add(EN_BUTTONEVENT_SUBMENU.CONFIG_ALARM, m_viewConfigAlarm);
            m_dicOfMainView.Add(EN_BUTTONEVENT_SUBMENU.CONFIG_ANALOG, m_viewConfigAnalog);
            m_dicOfMainView.Add(EN_BUTTONEVENT_SUBMENU.CONFIG_CYLINDER, m_viewConfigCylindre);
            m_dicOfMainView.Add(EN_BUTTONEVENT_SUBMENU.CONFIG_DIGITAL, m_viewConfigDigital);
            m_dicOfMainView.Add(EN_BUTTONEVENT_SUBMENU.CONFIG_TRIGGER, m_viewConfigTrigger);
			m_dicOfMainView.Add(EN_BUTTONEVENT_SUBMENU.CONFIG_LANGUAGE, m_viewConfigLanguage);
            m_dicOfMainView.Add(EN_BUTTONEVENT_SUBMENU.CONFIG_MOTION, m_viewConfigMotion);
			m_dicOfMainView.Add(EN_BUTTONEVENT_SUBMENU.CONFIG_COMMUNICATION, m_viewConfigCommunication);
			m_dicOfMainView.Add(EN_BUTTONEVENT_SUBMENU.CONFIG_INTERRUPT, m_viewConfigInterrupt);
			m_dicOfMainView.Add(EN_BUTTONEVENT_SUBMENU.CONFIG_ACTION, m_viewConfigAction);
            m_dicOfMainView.Add(EN_BUTTONEVENT_SUBMENU.CONFIG_TOOL, m_viewConfigTool);      // 2021.10.06 jhchoo [ADD]
			m_dicOfMainView.Add(EN_BUTTONEVENT_SUBMENU.CONFIG_JOG, m_viewConfigJog);
			m_dicOfMainView.Add(EN_BUTTONEVENT_SUBMENU.CONFIG_DEVICE, m_viewConfigDevice);
            m_dicOfMainView.Add(EN_BUTTONEVENT_SUBMENU.CONFIG_PARAMETERS, m_viewConfigParameter);
            m_dicOfMainView.Add(EN_BUTTONEVENT_SUBMENU.CONFIG_INTERLOCK, m_viewConfigInterlock);
            #endregion

			#region SetPage TimerInterval
			foreach (var kvp in m_dicOfMainView)
			{
				m_panelMainView.Controls.Add(kvp.Value);
				kvp.Value.Hide();

				switch (kvp.Key)
				{
					default:
						m_dicOfTimerInterval.Add(kvp.Key, Define.DefineConstant.MainForm.INTERVAL_UPDATE_GUI);
						break;
// 
// 					case EN_BUTTONEVENT_SUBMENU.OPERATION_TRACKING:
// 						m_dicOfTimerInterval.Add(kvp.Key, Define.DefineConstant.MainForm.INTERVAL_GRAPH);
// 						break;
				}
			}
			#endregion

			m_viewRecentView = m_viewOperationMain;

			m_viewRecentView.Show();
			m_viewRecentView.ActivateView();
        }
        #endregion

        #region Initialize Intances
        private void InitializeInstances()
        {
			#region LOG
			m_InstanceOfLog			= Log.LogManager.GetInstance();
			#endregion

            #region GUI Timer
            m_pTimerForUpdateGUI.Tick       += new EventHandler(FunctionForTimerTick);

            m_pTimerForUpdateGUI.Start();
            #endregion

			#region ProgressBar
			m_fProgressBar	= Views.Functional.Form_ProgressBar.GetInstance();
			#endregion

		}
        #endregion

        #region Internal Interface
        /// <summary>
        /// 2020.05.15 by yjlee [ADD] Set a main view that clicked.
        /// </summary>
        private void SetMainView(UserControlForMainView.CustomView viewMain, int nTimerInterval)
        {
            m_pTimerForUpdateGUI.Stop();

            m_viewRecentView.Hide();
            m_viewRecentView.DeactivateView();

            m_viewRecentView    = viewMain;

            m_viewRecentView.BringToFront();

            m_viewRecentView.Show();
            m_viewRecentView.ActivateView();

            m_pTimerForUpdateGUI.Interval       = nTimerInterval;
			m_pTimerForUpdateGUI.Start();
        }
		/// <summary>
		/// 2020.07.09 by twkang [ADD] 
		/// </summary>
		private void InitializeFuntional()
		{
			m_pTimerForAlarm.Interval	= 100;
			m_pTimerForAlarm.Tick		+= new EventHandler(FuntionForAlarm);
			Views.Functional.Form_AlarmMessage.GetInstance().evtAlarmMessage	+= SetAlarmMessageForm;
			Views.Functional.Form_ProgressBar.GetInstance().evtProgressBar		+= SetProgressBarForm;
			m_pTimerForAlarm.Start();
		}
		
        #region Timer
        /// <summary>
        /// 2020.05.15 by yjlee [ADD] This function will be called by the system timer to update the GUI.
        /// </summary>
        private void FunctionForTimerTick(object sender, EventArgs e)
        {
            m_viewRecentView.CallFunctionByTimer();
        }
		/// <summary>
		/// 2020.07.10 by twkang [ADD] 타이머에 의해 호출되는함수, 
		/// </summary>
		private void FuntionForAlarm(object sender, EventArgs e)
		{
			m_RWLock.EnterReadLock();
			int nQueueCount	= queueState.Count;
			m_RWLock.ExitReadLock();
			
			if(nQueueCount > 0)
			{
				m_RWLock.EnterWriteLock();
				var enState = queueState.Dequeue();
				m_RWLock.ExitWriteLock();

				switch (enState)
				{
					case EN_ALARM_FORM_STATE.DISPLAYING: // 알람창 발생
						Views.Functional.Form_AlarmMessage.GetInstance().CreateForm();
						SetProgressBarForm(false);
						break;
					case EN_ALARM_FORM_STATE.OFF:
						Views.Functional.Form_AlarmMessage.GetInstance().CloseForm();
						break;
					default:
						break;
				}
			}
			
			switch(enProgressBarState)
			{
				case EN_PROGRESS_BAR_FORM_STATE.WATING:
					break;
				case EN_PROGRESS_BAR_FORM_STATE.DISPLAYING:
					Views.Functional.Form_ProgressBar.GetInstance().ShowByMainForm();
					enProgressBarState	= EN_PROGRESS_BAR_FORM_STATE.WATING;
					break;
				case EN_PROGRESS_BAR_FORM_STATE.OFF:
					Views.Functional.Form_ProgressBar.GetInstance().HideByMainForm();
					enProgressBarState	= EN_PROGRESS_BAR_FORM_STATE.WATING;
					break;
			}
		}
        #endregion

        #endregion
		
		#region Register Event
		/// <summary>
		/// 2020.06.01 by yjlee [ADD] Register the events for the GUI.
		/// </summary>
		private void RegisterEventForGUI()
		{
			m_viewTitleBar.RegisterSubject(EquipmentState_.EquipmentState.GetInstance());
			m_viewTitleBar.RegisterSubject(Account_.Account.GetInstance());
			m_viewMainMenu.RegisterSubject(Account_.Account.GetInstance());
		}
		#endregion

        #region External Process
        /// <summary>
        /// 2021.01.13 by yjlee [ADD] Set the external process.
        /// </summary>
        private void SetExternalProcess()
        {
            ExitExternalProcess();

            string strLogProcessName                = ExternalProcess.PROCESS_NAME_LOG + ".exe";

            System.IO.FileInfo fInfo                = new System.IO.FileInfo(strLogProcessName);

            if(fInfo.Exists)
            {
                m_processLog    = new Process();

                m_processLog.StartInfo.FileName = ExternalProcess.PROCESS_NAME_LOG + ".exe";
				m_processLog.StartInfo.Arguments = FilePath.FILEPATH_LOG_MAIN;	// 2022.11.14 by junho [ADD] for have same Log path
				m_processLog.Start();

                // 2021.01.13 by yjlee [ADD] Wait for getting the window handle.
                //TickCounter_.TickCounter tickCount	= new TickCounter_.TickCounter();
                //tickCount.SetTickCount((uint)ExternalProcess.TIMEOUT_PROCESS_START);
				// 2021.06.08 by twkang [MOD] 설정한 시간동안 기다린다.
                //while (IntPtr.Zero == m_processLog.MainWindowHandle
                //    && false == tickCount.IsTickOver(true)
                //    || (m_panelMainView.Location.X == 0
                //    && m_panelMainView.Location.Y == 0))
                //{
                //    System.Threading.Thread.Sleep(50);
                //}
                while (IntPtr.Zero == m_processLog.MainWindowHandle)
                    System.Threading.Thread.Sleep(50);

                while (true)
                {
                    System.Threading.Thread.Sleep(50);

                    if (0 == m_panelMainView.Location.X && 0 == m_panelMainView.Location.Y) continue;

                    var rtn = SetWindowPos(m_processLog.MainWindowHandle, (int)WINPOS_SPFLAG.HWND_BOTTOM
                        , m_panelMainView.Location.X
                        , m_panelMainView.Location.Y
                        , 0
                        , 0
                        , (int)WINPOS_FLAG.HIDEWINDOW | (int)WINPOS_FLAG.NOSIZE);

                    Console.WriteLine(rtn.ToString());

                    if (rtn != IntPtr.Zero) break;
                }
            }
        }
        /// <summary>
        /// 2021.01.22 by yjlee [ADD] Exit the external process.
        /// </summary>
        private void ExitExternalProcess()
        {
            foreach(Process pr in Process.GetProcesses())
            {
                if(pr.ProcessName.StartsWith(ExternalProcess.PROCESS_NAME_LOG))
                {
					if(false == pr.CloseMainWindow())
                    {
                        // 2022.11.03. by shkim. [MOD] 이미 프로세스가 종료됬을 때에 대한 예외처리 추가
                        try
                        {
                            pr.Kill();    
                        }
                        catch
                        {

                        }
                    }
				}
            }

            if(null != m_processLog)
            {
                m_processLog.Dispose();
                m_processLog    = null;
            }
        }
        #endregion End - External Process

        #region GUI Event
        /// <summary>
        /// 2020.02.05 by yjlee [ADD] When a user click the main menu, this function will be called.
        /// </summary>
        private bool ReceiveEventFromMainMenu(string strEnum)
        {
            EN_BUTTONEVENT_MAINMENU enButtonEvent   = EN_BUTTONEVENT_MAINMENU.EXIT;

            if(Enum.TryParse(strEnum, out enButtonEvent))
            {
                switch(enButtonEvent)
                {
                    case EN_BUTTONEVENT_MAINMENU.USER:
                        m_fLogin.CreateForm();
                        return false;

                    case EN_BUTTONEVENT_MAINMENU.HISTORY:
                        if(null != m_processLog)
                        {
							SetWindowPos(m_processLog.MainWindowHandle, (int)WINPOS_SPFLAG.HWND_TOPMOST, 0, 0, 0, 0, (int)WINPOS_FLAG.SHOWWINDOW | (int)WINPOS_FLAG.NOSIZE | (int)WINPOS_FLAG.NOMOVE);
                        }
                        break;

                    case EN_BUTTONEVENT_MAINMENU.EXIT:
						// 2021.11.20 by Thienvv [ADD] Do not exit program when perform autorun
                        EQUIPMENT_STATE enState = EquipmentState.GetInstance().GetState();
                        if (enState != EQUIPMENT_STATE.IDLE && enState != EQUIPMENT_STATE.PAUSE)
                        {
                            return false;
                        }
                        if (Functional.Form_MessageBox.GetInstance().ShowMessage("Do you want Exit program?") == false)
                            return false;
                        // 여기서 프로그램 종료 전 꺼야하는 DIGITAL IO 처리한다.
                        
                        // 2021.10.06. jhlim [ADD] 통신 및 시나리오를 종료한다.
                        CloseScenarioHandler();

						Log.LogManager.GetInstance().Exit();

                        ExitExternalProcess();
                        
                        Application.Exit();
                        return false;

                    default:
                        if(null != m_processLog)
                        {
                            SetWindowPos(m_processLog.MainWindowHandle, (int)WINPOS_SPFLAG.HWND_BOTTOM, 0, 0, 0, 0, (int)WINPOS_FLAG.HIDEWINDOW | (int)WINPOS_FLAG.NOSIZE | (int)WINPOS_FLAG.NOMOVE);
                        }
                        break;
                }

                m_enClickedMainMenu     = enButtonEvent;

                m_viewSubMenu.SetButtons(m_dicOfSubMenus[enButtonEvent]);
                m_viewSubMenu.SetClickedButton(m_mappingForButtonName[m_dicOfMainViewByMainButtonEvent[enButtonEvent]]);

                var enSubmenuEvent      = m_dicOfMainViewByMainButtonEvent[enButtonEvent];

                SetMainView(m_dicOfMainView[enSubmenuEvent], m_dicOfTimerInterval[enSubmenuEvent]);

                return true;
            }

            return false;
        }
        /// <summary>
        /// 2020.02.05 by yjlee [ADD] When a user click the sub menu, this function will be called.
        /// </summary>
        private bool ReceiveEventFromSubMenu(string strEnum)
        {
            EN_BUTTONEVENT_SUBMENU enButtonEvent        = EN_BUTTONEVENT_SUBMENU.OPERATION_MAIN;
            
            string strSubMenu       = string.Format("{0}_{1}"
                                        , m_enClickedMainMenu.ToString()
                                        , strEnum.Replace(' ', '_'));

			//if(EN_BUTTONEVENT_SUBMENU.SETUP_JOG.ToString() == strSubMenu)
			//{
			//	Functional.Jog.Form_Jog.GetInstance().CreateForm();

			//	return false;
			//}

   //         if (EN_BUTTONEVENT_SUBMENU.SETUP_MONITOR.ToString() == strSubMenu)
   //         {
   //             Functional.Form_Monitor.GetInstance().CreateForm();

   //             return false;
   //         }

            if (Enum.TryParse(strSubMenu, out enButtonEvent))
            {
                if (m_enClickedSubMenu == enButtonEvent) { return false; }

                m_enClickedSubMenu      = enButtonEvent;

                m_dicOfMainViewByMainButtonEvent[m_enClickedMainMenu]   = m_enClickedSubMenu;

                SetMainView(m_dicOfMainView[m_enClickedSubMenu], m_dicOfTimerInterval[m_enClickedSubMenu]);

                return true;
            }

            return false;
        }
        #endregion
		
		/// <summary>
		/// 2020.07.10 by twkang [ADD] AlamMessage Form 을 위한 상태를 바꿔준다.
		/// </summary>
		public void SetAlarmMessageForm(bool bShow)
		{
			m_RWLock.EnterWriteLock();
			queueState.Enqueue(bShow ? EN_ALARM_FORM_STATE.DISPLAYING : EN_ALARM_FORM_STATE.OFF);
			m_RWLock.ExitWriteLock();
		}
		/// <summary>
		/// 2021.06.14 by twkang [ADD] ProgressBar 폼을 설정해준다.
		/// </summary>
		public void SetProgressBarForm(bool bShow)
		{
			enProgressBarState = bShow ? EN_PROGRESS_BAR_FORM_STATE.DISPLAYING : EN_PROGRESS_BAR_FORM_STATE.OFF;
		}

        #region Secs/Gem 관련
        // private Views.Functional.Form_TerminalMessage m_instanceTerminal = Views.Functional.Form_TerminalMessage.GetInstance();

        delegate void deleTerminalMessage_Called(string strMessage);
        private void EnqueueTerminalMessage(string strMessage)
        {
            if (this.InvokeRequired)
            {
                deleTerminalMessage_Called d = new deleTerminalMessage_Called(EnqueueTerminalMessage);
                this.BeginInvoke(d, new object[] { strMessage });
            }
            else
            {
                // m_instanceTerminal.ShowMessage(strMessage);
            }
        }

        // 2021.10.06. jhlim [ADD] 델리게이트를 등록한다.
        private void RegistSecsGemFunctions()
        {
            // SECSGEM.Communicator.SecsGemHandler.GetInstance().EventTerminalMessage(EnqueueTerminalMessage);
        }

        // 2021.10.06. jhlim [ADD] 통신 및 시나리오를 초기화한다.
        private void InitScenarioHandler()
        {
            //FrameOfSystem3.SECSGEM.ScenarioHandler.GetInstance().Initialize();
            //m_viewOperationMain.RegistSecsGemFunctions();
            //RegistSecsGemFunctions();
        }

        // 2021.10.06. jhlim [ADD] 통신 및 시나리오를 종료한다.
        private void CloseScenarioHandler()
        {
            // FrameOfSystem3.SECSGEM.ScenarioHandler.GetInstance().Exit();
        }
        #endregion
    }
}
