using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using RunningMain_;
using TaskAction_;

using FrameOfSystem3.Work;
using FrameOfSystem3.Component;
using Define.DefineEnumProject.Task;
using Define.DefineEnumProject.DigitalIO;
using Define.DefineEnumProject.AnalogIO;
using FrameOfSystem3.Recipe;
using RecipeManager_;

using EQUIPMENT_PARAM = FrameOfSystem3.Recipe.PARAM_EQUIPMENT;

namespace FrameOfSystem3.Views.Operation
{
	public partial class Operation_Main : UserControlForMainView.CustomView
	{
		public Operation_Main()
		{
			InitializeComponent();


			MakeMappingTable();

			m_InstanceOfSelectionList = Functional.Form_SelectionList.GetInstance();

            InitGridMainUtil();
            InitGridLaserDevice();
            InitalizeBlockGridVeiw();
            InitSmemaGrid();
            InitHandlerGridVeiw();
            InitHeaterGridView();
            InitalizeWorkStatusGridVeiw();
		}

		#region 상수
		private readonly string STR_INITALIZE_TASK					= "INITIALIZE TASK";

        private readonly Color c_clrMonitor = Color.LightGray;
        private readonly Color c_clrControl = Color.SteelBlue;
        private readonly Color c_clrTrue = Color.Green;
        private readonly Color c_clrFalse = Color.White;
		#endregion 

		#region 변수
		Dictionary<string, RUN_MODE> m_DicForRunMode	= new Dictionary<string,RUN_MODE>();
		
		Functional.Form_SelectionList m_InstanceOfSelectionList		= null;
        Functional.Form_MessageBox m_InstanceMessageBox = null;

        private FrameOfSystem3.Recipe.Recipe m_instanceRecipe = FrameOfSystem3.Recipe.Recipe.GetInstance();

		#region Task
		Task.TaskOperator m_instanceOperator						= null;
		private int m_nCountOfTask									= 0;
		string[] m_arTaskList										= null;
		#endregion

		#region Action
		TaskActionFlow m_instanceActionFlow				= null;
		#endregion

		#endregion

		#region 상속 인터페이스
		/// <summary>
		/// 
		/// </summary>
		protected override void ProcessWhenActivation()
		{
			m_instanceOperator		= Task.TaskOperator.GetInstance();
            m_InstanceMessageBox = Functional.Form_MessageBox.GetInstance();

			if(m_instanceOperator.GetListOfTask(ref m_nCountOfTask,ref m_arTaskList))
			{

			}

			m_instanceActionFlow		= TaskActionFlow.GetInstance();

            gridViewControl_WorkStatus_Parameter.UpdateValue();            
		}
		/// <summary>
		/// 
		/// </summary>
		protected override void ProcessWhenDeactivation()
		{
            
		}

        /// <summary>
		/// 
		/// </summary>
		public override void CallFunctionByTimer()
		{
            UpdateDoorState();
            UpdateAlamCode();
            UpdateHeaterGridView();
            gridVeiwControl_Util_Device.UpdateState();
            gridVeiwControl_Laser_Device.UpdateState();
            gridVeiwControl_Head_Device.UpdateState();
            gridVeiwControl_Block_Device.UpdateState();
            gridVeiwControl_Smema_Device.UpdateState();
            gridVeiwControl_Handler_Device.UpdateState();
            UpadateInformation();
            UpdateWaferInformation();
            //우선 개별로 하자 label 많아지면 별도 Method
            if (m_instanceOperator.IsPreHeatingOver())
            {
                m_lblPreHeatingTime.Text = "TIME OVER";
            }
            else
            {
                int nPreheatingTime = (int)m_instanceOperator.GetPreHeatingTime() / 1000; //초단위 표시하자

                m_lblPreHeatingTime.Text = nPreheatingTime.ToString() + " s";
            }
		}

		#endregion

		#region 내부인터페이스
		/// <summary>
		/// 2020.07.20 by twkang [ADD] 클래스에서 사용할 MappingTable 을 만든다.
		/// </summary>
		private void MakeMappingTable()
		{
			m_DicForRunMode.Clear();
			foreach(RUN_MODE en in Enum.GetValues(typeof(RUN_MODE)))
			{
				m_DicForRunMode.Add(en.ToString(), en);
			}
		}
		/// <summary>
		/// 2020.09.15 by twkang [ADD] 이니셜라이즈 동작할 테스크를 선택한다.
		/// </summary>
		private bool SetInitializeTask()
		{
			string[] arTask					= null;
			int[] arIndex					= null;
			bool[] arInit					= null;
			string strPreValue				= string.Empty;
			List<string> listInitializeTask	= new List<string>();
			
            if (false == Task.TaskOperator.GetInstance().GetInitializingTask(ref arTask, ref arInit))
			{
				return false;
			}

			for(int nIndex = 0, nEnd = arInit.Length; nIndex < nEnd; ++nIndex)
			{
				if(false == arInit[nIndex])
				{
					listInitializeTask.Add(arTask[nIndex]);
				}
			}
			strPreValue	= string.Join(", ", listInitializeTask);
			
			if(m_InstanceOfSelectionList.CreateForm(STR_INITALIZE_TASK, arTask, strPreValue, true))
			{
				m_InstanceOfSelectionList.GetResult(ref arIndex);

                for(int nIndex = 0, nEnd = arInit.Length; nIndex < nEnd; ++nIndex)
				{
					arInit[nIndex]	        = false;
				}

				for(int nIndex = 0, nEnd = arIndex.Length; nIndex < nEnd; ++nIndex)
				{
					arInit[arIndex[nIndex]]	= true;
				}

				return Task.TaskOperator.GetInstance().SetInitializingTask(ref arTask, ref arInit);
			}
			return false;
		}

		#region UI 이벤트
		/// <summary>
		/// 2020.06.03 by twkang [ADD] INITIALIZE, RUN, STOP 버튼 클릭 이벤트이다. SelectionList 를 호출한다.
		/// </summary>
		private void Click_OperationButton(object sender, EventArgs e)
		{
			Control ctrl = sender as Control;

			switch (ctrl.TabIndex)
			{
				case 0: // INITIALIZE
					if (SetInitializeTask())
					{
						Task.TaskOperator.GetInstance().SetOperation(OPERATION_EQUIPMENT.INITIALIZE);
					}
					break;
				case 1: // RUN
                    if(m_instanceRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.LASER_USED.ToString(), false) == false)
                    {
                        if (m_InstanceMessageBox.ShowMessage("LASER PARAMETER OFF\nDO YOU WANT RUN?", "CONFIRMATION MESSAGE", true) == false)
                            return;
                    }
					Task.TaskOperator.GetInstance().SetOperation(OPERATION_EQUIPMENT.RUN);
					break;
				case 2: // STOP
					Task.TaskOperator.GetInstance().SetOperation(OPERATION_EQUIPMENT.STOP);
					return;
			}
		}
		/// <summary>
		/// 2020.07.20 by twkang [ADD] RunMode label 클릭 이벤트, 동작 모드를 설정한다.
		/// </summary>
		private void Click_RunMode(object sender, EventArgs e)
		{
			string strValue		= string.Empty;

			if (m_InstanceOfSelectionList.CreateForm(m_groupRunMode.Text, Define.DefineEnumProject.SelectionList.EN_SELECTIONLIST.OPERATION_EQUIPMENT, m_labelRunMode.Text))
			{
				m_InstanceOfSelectionList.GetResult(ref strValue);

				if(m_DicForRunMode.ContainsKey(strValue))
				{
					Task.TaskOperator.GetInstance().SetRunMode(m_DicForRunMode[strValue]);
					m_labelRunMode.Text	= Task.TaskOperator.GetInstance().GetRunMode().ToString();
				}
			}
		}

        private void Click_DoorButton(object sender, EventArgs e)
        {
            Control ctrl = sender as Control;

            switch (ctrl.TabIndex)
            {
                case 0:
                    if (!FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().ReadItem(false, (int)EN_DIGITAL_OUT.DOOR_LOCK_1))
                    {
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(true, (int)EN_DIGITAL_OUT.DOOR_LOCK_1);
                    }
                    else
                    {
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(false, (int)EN_DIGITAL_OUT.DOOR_LOCK_1);
                    }
                    break;
                case 1:
                    if (!FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().ReadItem(false, (int)EN_DIGITAL_OUT.DOOR_LOCK_2))
                    {
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(true, (int)EN_DIGITAL_OUT.DOOR_LOCK_2);
                    }
                    else
                    {
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(false, (int)EN_DIGITAL_OUT.DOOR_LOCK_2);
                    }
                    break;

                case 10:
                    if (!FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().ReadItem(false, (int)EN_DIGITAL_OUT.DOOR_MAGNETIC_1))
                    {
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(true, (int)EN_DIGITAL_OUT.DOOR_MAGNETIC_1);
                    }
                    else
                    {
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(false, (int)EN_DIGITAL_OUT.DOOR_MAGNETIC_1);
                    }
                    break;
                case 11:
                    if (!FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().ReadItem(false, (int)EN_DIGITAL_OUT.DOOR_MAGNETIC_2))
                    {
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(true, (int)EN_DIGITAL_OUT.DOOR_MAGNETIC_2);
                    }
                    else
                    {
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(false, (int)EN_DIGITAL_OUT.DOOR_MAGNETIC_2);
                    }
                    break;
            }
        }

        private void Cick_All_IO(object sender, EventArgs e)
        {
            Control ctrButton = sender as Control;
            switch (ctrButton.TabIndex)
            {
                case 0: // RESET
                    if (!FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().ReadItem(false, (int)EN_DIGITAL_OUT.LD_1_ALARM_CLEAR)
                        || !FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().ReadItem(false, (int)EN_DIGITAL_OUT.LD_2_ALARM_CLEAR)
                        || !FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().ReadItem(false, (int)EN_DIGITAL_OUT.LD_3_ALARM_CLEAR)
                        || !FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().ReadItem(false, (int)EN_DIGITAL_OUT.MONITOR_ALARM_CLEAR))
                    {
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(true, (int)EN_DIGITAL_OUT.LD_1_ALARM_CLEAR);
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(true, (int)EN_DIGITAL_OUT.LD_2_ALARM_CLEAR);
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(true, (int)EN_DIGITAL_OUT.LD_3_ALARM_CLEAR);
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(true, (int)EN_DIGITAL_OUT.MONITOR_ALARM_CLEAR);
                    }
                    else
                    {
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(false, (int)EN_DIGITAL_OUT.LD_1_ALARM_CLEAR);
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(false, (int)EN_DIGITAL_OUT.LD_2_ALARM_CLEAR);
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(false, (int)EN_DIGITAL_OUT.LD_3_ALARM_CLEAR);
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(false, (int)EN_DIGITAL_OUT.MONITOR_ALARM_CLEAR);
                    }
                    break;

                case 1://EMO
                    if (!FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().ReadItem(false, (int)EN_DIGITAL_OUT.LD_1_EMO)
                        || !FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().ReadItem(false, (int)EN_DIGITAL_OUT.LD_2_EMO)
                        || !FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().ReadItem(false, (int)EN_DIGITAL_OUT.LD_3_EMO)
                        || !FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().ReadItem(false, (int)EN_DIGITAL_OUT.MONITOR_EMO))
                    {
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(true, (int)EN_DIGITAL_OUT.LD_1_EMO);
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(true, (int)EN_DIGITAL_OUT.LD_2_EMO);
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(true, (int)EN_DIGITAL_OUT.LD_3_EMO);
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(true, (int)EN_DIGITAL_OUT.MONITOR_EMO);
                    }
                    else
                    {
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(false, (int)EN_DIGITAL_OUT.LD_1_EMO);
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(false, (int)EN_DIGITAL_OUT.LD_2_EMO);
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(false, (int)EN_DIGITAL_OUT.LD_3_EMO);
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(false, (int)EN_DIGITAL_OUT.MONITOR_EMO);
                    }
                    break;
            }
        }

        private void Click_MaterialClear(object sender, EventArgs e)
        {
            FrameOfSystem3.Config.ConfigAlarm.GetInstance().SaveAlarmList();
            m_instanceOperator.ClearMaterial();
            WorkMap.GetInstance().SaveBackup();
        }

        private void Click_VacOnOff(object sender, EventArgs e)
        {
            int nMainVacTriggerIndex = 7;
            bool bOnOff = true;

            FrameOfSystem3.Config.ConfigTrigger.GetInstance().GetParameter(nMainVacTriggerIndex, FrameOfSystem3.Config.ConfigTrigger.EN_PARAM_TRIGGER.ENABLE, ref bOnOff);

            FrameOfSystem3.Config.ConfigTrigger.GetInstance().SetParameter(nMainVacTriggerIndex, FrameOfSystem3.Config.ConfigTrigger.EN_PARAM_TRIGGER.ENABLE, !bOnOff);
        }
		#endregion
       
        #region Initialize Control
        private void InitGridMainUtil()
        {
            List<GridVeiwControl_Device.ControlItem> ControlList = new List<GridVeiwControl_Device.ControlItem>();

            GridVeiwControl_Device.ControlItem AddControlItem;

            ControlList = new List<GridVeiwControl_Device.ControlItem>();

            AddControlItem = new GridVeiwControl_Device.ControlItem((int)EN_ANALOG_IN.MAIN_AIR, GridVeiwControl_Device.EN_CONTROL_TYPE.ANALOG_INPUT_VALUE);
            AddControlItem.Name = "MAIN AIR";
            AddControlItem.AnalogUnit = "kPa";
            ControlList.Add(AddControlItem);

            AddControlItem = new GridVeiwControl_Device.ControlItem((int)EN_ANALOG_IN.MAIN_VAC, GridVeiwControl_Device.EN_CONTROL_TYPE.ANALOG_INPUT_VALUE);
            AddControlItem.Name = "MAIN VAC";
            AddControlItem.AnalogUnit = "kPa";
            ControlList.Add(AddControlItem);

            gridVeiwControl_Util_Device.Initialize(ControlList);

        }
        private void InitGridLaserDevice()
        {
            List<GridVeiwControl_Device.ControlItem> ControlList = new List<GridVeiwControl_Device.ControlItem>();

            GridVeiwControl_Device.ControlItem AddControlItem;

            List<int> lstIndex = new List<int>();

            lstIndex = new List<int>();
            lstIndex.Add((int)EN_DIGITAL_IN.LD_1_ON);
            lstIndex.Add((int)EN_DIGITAL_IN.LD_2_ON);
            lstIndex.Add((int)EN_DIGITAL_IN.LD_3_ON);
            AddControlItem = new GridVeiwControl_Device.ControlItem(lstIndex, GridVeiwControl_Device.EN_CONTROL_TYPE.DIGITAL_INPUT);
            AddControlItem.Name = "ON";
            ControlList.Add(AddControlItem);

            lstIndex = new List<int>();
            lstIndex.Add((int)EN_DIGITAL_IN.LD_1_READY);
            lstIndex.Add((int)EN_DIGITAL_IN.LD_2_READY);
            lstIndex.Add((int)EN_DIGITAL_IN.LD_3_READY);
            AddControlItem = new GridVeiwControl_Device.ControlItem(lstIndex, GridVeiwControl_Device.EN_CONTROL_TYPE.DIGITAL_INPUT);
            AddControlItem.Name = "READY";
            ControlList.Add(AddControlItem);

            lstIndex = new List<int>();
            lstIndex.Add((int)EN_DIGITAL_OUT.LD_1_READY);
            lstIndex.Add((int)EN_DIGITAL_OUT.LD_2_READY);
            lstIndex.Add((int)EN_DIGITAL_OUT.LD_3_READY);
            AddControlItem = new GridVeiwControl_Device.ControlItem(lstIndex, GridVeiwControl_Device.EN_CONTROL_TYPE.DIGITAL_OUTPUT);
            AddControlItem.Name = "READY";
            ControlList.Add(AddControlItem);

            lstIndex = new List<int>();
            lstIndex.Add((int)EN_DIGITAL_IN.LD_1_ALARM);
            lstIndex.Add((int)EN_DIGITAL_IN.LD_2_ALARM);
            lstIndex.Add((int)EN_DIGITAL_IN.LD_3_ALARM);
            lstIndex.Add((int)EN_DIGITAL_IN.MONITOR_ALARM);
            AddControlItem = new GridVeiwControl_Device.ControlItem(lstIndex, GridVeiwControl_Device.EN_CONTROL_TYPE.DIGITAL_INPUT);
            AddControlItem.Name = "ALARM";
            ControlList.Add(AddControlItem);

            lstIndex = new List<int>();
            lstIndex.Add((int)EN_DIGITAL_OUT.LD_1_ALARM_CLEAR);
            lstIndex.Add((int)EN_DIGITAL_OUT.LD_2_ALARM_CLEAR);
            lstIndex.Add((int)EN_DIGITAL_OUT.LD_3_ALARM_CLEAR);
            lstIndex.Add((int)EN_DIGITAL_OUT.MONITOR_ALARM_CLEAR);
            AddControlItem = new GridVeiwControl_Device.ControlItem(lstIndex, GridVeiwControl_Device.EN_CONTROL_TYPE.DIGITAL_OUTPUT);
            AddControlItem.Name = "RESET";
            ControlList.Add(AddControlItem);

            lstIndex = new List<int>();
            lstIndex.Add((int)EN_DIGITAL_OUT.LD_1_EMO);
            lstIndex.Add((int)EN_DIGITAL_OUT.LD_2_EMO);
            lstIndex.Add((int)EN_DIGITAL_OUT.LD_3_EMO);
            lstIndex.Add((int)EN_DIGITAL_OUT.MONITOR_EMO);
            AddControlItem = new GridVeiwControl_Device.ControlItem(lstIndex, GridVeiwControl_Device.EN_CONTROL_TYPE.DIGITAL_OUTPUT);
            AddControlItem.Name = "EMO";
            ControlList.Add(AddControlItem);


            gridVeiwControl_Laser_Device.Initialize(ControlList);

            List<string> lstHeader = new List<string>();

            lstHeader.Add("");
            lstHeader.Add("PORT 1");
            lstHeader.Add("PORT 2");
            lstHeader.Add("PORT 3");
            lstHeader.Add("MONITOR");

            gridVeiwControl_Laser_Device.ShowHeader(lstHeader);

            ControlList = new List<GridVeiwControl_Device.ControlItem>();

            AddControlItem = new GridVeiwControl_Device.ControlItem((int)EN_ANALOG_IN.HEAD_TOTAL_FLOW, GridVeiwControl_Device.EN_CONTROL_TYPE.ANALOG_INPUT_VALUE);
            AddControlItem.Name = "TOTAL FLOW";
            AddControlItem.AnalogUnit = "L/min";
            ControlList.Add(AddControlItem);

//             AddControlItem = new GridVeiwControl_Device.ControlItem((int)EN_ANALOG_IN.HEAD_LEFT_FLOW, GridVeiwControl_Device.EN_CONTROL_TYPE.ANALOG_INPUT_VALUE);
//             AddControlItem.Name = "LEFT FLOW";
//             AddControlItem.AnalogUnit = "L/min";
//             ControlList.Add(AddControlItem);
// 
//             AddControlItem = new GridVeiwControl_Device.ControlItem((int)EN_ANALOG_IN.HEAD_RIGHT_FLOW, GridVeiwControl_Device.EN_CONTROL_TYPE.ANALOG_INPUT_VALUE);
//             AddControlItem.Name = "RIGHT FLOW";
//             AddControlItem.AnalogUnit = "L/min";
//             ControlList.Add(AddControlItem);

            gridVeiwControl_Head_Device.Initialize(ControlList);
        }
        private void InitalizeBlockGridVeiw()
        {
            #region Device

            List<GridVeiwControl_Device.ControlItem> ControlList = new List<GridVeiwControl_Device.ControlItem>();

            GridVeiwControl_Device.ControlItem AddControlItem;

            AddControlItem = new GridVeiwControl_Device.ControlItem((int)EN_DIGITAL_OUT.BLOCK_MATERIAL_VAC_1, GridVeiwControl_Device.EN_CONTROL_TYPE.DIGITAL_OUTPUT);
            AddControlItem.Name = "BLOCK VAC 1";
            ControlList.Add(AddControlItem);
            AddControlItem = new GridVeiwControl_Device.ControlItem((int)EN_DIGITAL_OUT.BLOCK_MATERIAL_VAC_2, GridVeiwControl_Device.EN_CONTROL_TYPE.DIGITAL_OUTPUT);
            AddControlItem.Name = "BLOCK VAC 2";
            ControlList.Add(AddControlItem);
            AddControlItem = new GridVeiwControl_Device.ControlItem((int)EN_DIGITAL_OUT.BLOCK_MATERIAL_BLOW, GridVeiwControl_Device.EN_CONTROL_TYPE.DIGITAL_OUTPUT);
            AddControlItem.Name = "BLOCK BLOW";
            ControlList.Add(AddControlItem);
            AddControlItem = new GridVeiwControl_Device.ControlItem((int)EN_ANALOG_IN.BLOCK_MATERIAL_VAC, GridVeiwControl_Device.EN_CONTROL_TYPE.ANALOG_INPUT_VALUE);
            AddControlItem.AnalogUnit = "kPa";
            ControlList.Add(AddControlItem);
            AddControlItem = new GridVeiwControl_Device.ControlItem((int)EN_DIGITAL_OUT.LIFT_MATERIAL_VAC, GridVeiwControl_Device.EN_CONTROL_TYPE.DIGITAL_OUTPUT);
            AddControlItem.Name = "LIFT VAC";
            ControlList.Add(AddControlItem);
            AddControlItem = new GridVeiwControl_Device.ControlItem((int)EN_ANALOG_IN.LIFT_MATERIAL_VAC, GridVeiwControl_Device.EN_CONTROL_TYPE.ANALOG_INPUT_VALUE);
            AddControlItem.AnalogUnit = "kPa";
            ControlList.Add(AddControlItem);

            gridVeiwControl_Block_Device.Initialize(ControlList);
            #endregion /Device
        }
        private void InitSmemaGrid()
        {
            List<GridVeiwControl_Device.ControlItem> ControlList = new List<GridVeiwControl_Device.ControlItem>();

            GridVeiwControl_Device.ControlItem AddControlItem;

            List<int> lstDeviceIndex = new List<int>();
            List<GridVeiwControl_Device.EN_CONTROL_TYPE> lstDeviceType = new List<GridVeiwControl_Device.EN_CONTROL_TYPE>();
            lstDeviceIndex.Add((int)EN_DIGITAL_IN.PRE_SMEMA_PORT1);
            lstDeviceType.Add(GridVeiwControl_Device.EN_CONTROL_TYPE.DIGITAL_INPUT);
            lstDeviceIndex.Add((int)EN_DIGITAL_OUT.PRE_SMEMA_PORT1);
            lstDeviceType.Add(GridVeiwControl_Device.EN_CONTROL_TYPE.DIGITAL_OUTPUT);
            AddControlItem = new GridVeiwControl_Device.ControlItem(lstDeviceIndex, lstDeviceType);
            AddControlItem.Name = "SMEMA 1";
            ControlList.Add(AddControlItem);

            lstDeviceIndex = new List<int>();
            lstDeviceType = new List<GridVeiwControl_Device.EN_CONTROL_TYPE>();
            lstDeviceIndex.Add((int)EN_DIGITAL_IN.PRE_SMEMA_SUB_PORT1);
            lstDeviceType.Add(GridVeiwControl_Device.EN_CONTROL_TYPE.DIGITAL_INPUT);
            lstDeviceIndex.Add((int)EN_DIGITAL_OUT.PRE_SMEMA_SUB_PORT1);
            lstDeviceType.Add(GridVeiwControl_Device.EN_CONTROL_TYPE.DIGITAL_OUTPUT);
            AddControlItem = new GridVeiwControl_Device.ControlItem(lstDeviceIndex, lstDeviceType);
            AddControlItem.Name = "SMEMA SUB 1";
            ControlList.Add(AddControlItem);

            lstDeviceIndex = new List<int>();
            lstDeviceType = new List<GridVeiwControl_Device.EN_CONTROL_TYPE>();
            lstDeviceIndex.Add((int)EN_DIGITAL_IN.PRE_SMEMA_PORT2);
            lstDeviceType.Add(GridVeiwControl_Device.EN_CONTROL_TYPE.DIGITAL_INPUT);
            lstDeviceIndex.Add((int)EN_DIGITAL_OUT.PRE_SMEMA_PORT2);
            lstDeviceType.Add(GridVeiwControl_Device.EN_CONTROL_TYPE.DIGITAL_OUTPUT);
            AddControlItem = new GridVeiwControl_Device.ControlItem(lstDeviceIndex, lstDeviceType);
            AddControlItem.Name = "SMEMA 2";
            ControlList.Add(AddControlItem);

            lstDeviceIndex = new List<int>();
            lstDeviceType = new List<GridVeiwControl_Device.EN_CONTROL_TYPE>();
            lstDeviceIndex.Add((int)EN_DIGITAL_IN.PRE_SMEMA_SUB_PORT2);
            lstDeviceType.Add(GridVeiwControl_Device.EN_CONTROL_TYPE.DIGITAL_INPUT);
            lstDeviceIndex.Add((int)EN_DIGITAL_OUT.PRE_SMEMA_SUB_PORT2);
            lstDeviceType.Add(GridVeiwControl_Device.EN_CONTROL_TYPE.DIGITAL_OUTPUT);
            AddControlItem = new GridVeiwControl_Device.ControlItem(lstDeviceIndex, lstDeviceType);
            AddControlItem.Name = "SMEMA SUB 2";
            ControlList.Add(AddControlItem);

            gridVeiwControl_Smema_Device.Initialize(ControlList);

            List<string> lstHeader = new List<string>();

            lstHeader.Add("");
            lstHeader.Add("INPUT");
            lstHeader.Add("OUTPUT");

            gridVeiwControl_Smema_Device.ShowHeader(lstHeader);
        }
        private void InitHandlerGridVeiw()
        {
            #region Device

            List<GridVeiwControl_Device.ControlItem> ControlList = new List<GridVeiwControl_Device.ControlItem>();

            GridVeiwControl_Device.ControlItem AddControlItem;

            AddControlItem = new GridVeiwControl_Device.ControlItem((int)EN_DIGITAL_OUT.HANDLER_MATERIAL_VAC, GridVeiwControl_Device.EN_CONTROL_TYPE.DIGITAL_OUTPUT);
            AddControlItem.Name = "HANDLER VAC";
            ControlList.Add(AddControlItem);
            AddControlItem = new GridVeiwControl_Device.ControlItem((int)EN_DIGITAL_OUT.HANDLER_MATERIAL_BLOW, GridVeiwControl_Device.EN_CONTROL_TYPE.DIGITAL_OUTPUT);
            AddControlItem.Name = "HANDLER BLOW";
            ControlList.Add(AddControlItem);
            AddControlItem = new GridVeiwControl_Device.ControlItem((int)EN_ANALOG_IN.BLOCK_MATERIAL_VAC, GridVeiwControl_Device.EN_CONTROL_TYPE.ANALOG_INPUT_VALUE);
            AddControlItem.AnalogUnit = "kPa";
            AddControlItem = new GridVeiwControl_Device.ControlItem((int)EN_ANALOG_IN.HANDLER_MATERIAL_VAC, GridVeiwControl_Device.EN_CONTROL_TYPE.ANALOG_INPUT_VALUE);
            AddControlItem.AnalogUnit = "kPa";
            ControlList.Add(AddControlItem);

            gridVeiwControl_Handler_Device.Initialize(ControlList);
            #endregion /Device
        }
        private void InitHeaterGridView()
        {
            int nRow = 0;
            dataGridView_Heater.Rows.Clear();

            dataGridView_Heater.Rows.Add();
            dataGridView_Heater[0, nRow].Value = "HEATER ON";
            dataGridView_Heater[0, nRow].Style.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridView_Heater[0, nRow].Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridView_Heater[0, nRow].Style.BackColor = c_clrControl;
            dataGridView_Heater[0, nRow].Style.SelectionBackColor = c_clrControl;
            nRow++;

            dataGridView_Heater.Rows.Add();
            dataGridView_Heater[0, nRow].Value = "BLOCK TEMP";
            dataGridView_Heater[0, nRow].Style.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridView_Heater[0, nRow].Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridView_Heater[0, nRow].Style.BackColor = c_clrMonitor;
            dataGridView_Heater[0, nRow].Style.SelectionBackColor = c_clrControl;
            dataGridView_Heater[1, nRow].Style.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridView_Heater[1, nRow].Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            nRow++;
        }
        private void InitalizeWorkStatusGridVeiw()
        {
            #region Parameter Grid
            List<GridViewControl_Parameter.ParameterItem> parameterList = new List<GridViewControl_Parameter.ParameterItem>();

            GridViewControl_Parameter.ParameterItem AddParaItem;

            AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.WAIT_COLOR);
            AddParaItem.ParameterSettingType = Define.DefineEnumBase.Component.EN_PARAMETER_SETTING_TYPE.COLOR;
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.DONE_COLOR);
            AddParaItem.ParameterSettingType = Define.DefineEnumBase.Component.EN_PARAMETER_SETTING_TYPE.COLOR;
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.LOW_TEMP_COLOR);
            AddParaItem.ParameterSettingType = Define.DefineEnumBase.Component.EN_PARAMETER_SETTING_TYPE.COLOR;
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.TEMP_GROW_FAIL_COLOR);
            AddParaItem.ParameterSettingType = Define.DefineEnumBase.Component.EN_PARAMETER_SETTING_TYPE.COLOR;
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.TEMP_DEVOVER_COLOR);
            AddParaItem.ParameterSettingType = Define.DefineEnumBase.Component.EN_PARAMETER_SETTING_TYPE.COLOR;
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.HIGH_TEMP_COLOR);
            AddParaItem.ParameterSettingType = Define.DefineEnumBase.Component.EN_PARAMETER_SETTING_TYPE.COLOR;
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.MAX_HIGH_TEMP_COLOR);
            AddParaItem.ParameterSettingType = Define.DefineEnumBase.Component.EN_PARAMETER_SETTING_TYPE.COLOR;
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.EMG_LOW_TEMP_COLOR);
            AddParaItem.ParameterSettingType = Define.DefineEnumBase.Component.EN_PARAMETER_SETTING_TYPE.COLOR;
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.EMG_HIGH_TEMP_COLOR);
            AddParaItem.ParameterSettingType = Define.DefineEnumBase.Component.EN_PARAMETER_SETTING_TYPE.COLOR;
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.POWER_FAULT_COLOR);
            AddParaItem.ParameterSettingType = Define.DefineEnumBase.Component.EN_PARAMETER_SETTING_TYPE.COLOR;
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.SOURCE_ALARM_COLOR);
            AddParaItem.ParameterSettingType = Define.DefineEnumBase.Component.EN_PARAMETER_SETTING_TYPE.COLOR;
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.RESULT_GETFAIL_COLOR);
            AddParaItem.ParameterSettingType = Define.DefineEnumBase.Component.EN_PARAMETER_SETTING_TYPE.COLOR;
            parameterList.Add(AddParaItem);

            gridViewControl_WorkStatus_Parameter.Initialize(parameterList, 2, 80);

            #endregion /Parameter Grid
        }
        #endregion /Initialize Control

        #region Update Control
        private void UpdateDoorState()
        {
            if (DigitalIO_.DigitalIO.GetInstance().ReadInput((int)EN_DIGITAL_IN.DOOR_LOCK_1))
            {
                btnFrontDoor.CurrentDoorState = Sys3Controls.EDoorState.OPEN;
            }
            else
            {
                if (DigitalIO_.DigitalIO.GetInstance().ReadOutput((int)EN_DIGITAL_OUT.DOOR_LOCK_1))
                {
                    btnFrontDoor.CurrentDoorState = Sys3Controls.EDoorState.LOCKED;
                }
                else
                {
                    btnFrontDoor.CurrentDoorState = Sys3Controls.EDoorState.CLOSED;
                }
            }

            if (DigitalIO_.DigitalIO.GetInstance().ReadOutput((int)EN_DIGITAL_OUT.DOOR_MAGNETIC_1))
            {
                btnFrontMagnetic.CurrentDoorState = Sys3Controls.EDoorState.LOCKED;
            }
            else
            {
                btnFrontMagnetic.CurrentDoorState = Sys3Controls.EDoorState.OPEN;
            }

            if (DigitalIO_.DigitalIO.GetInstance().ReadInput((int)EN_DIGITAL_IN.DOOR_LOCK_2))
            {
                btnRearDoor.CurrentDoorState = Sys3Controls.EDoorState.OPEN;
            }
            else
            {
                if (DigitalIO_.DigitalIO.GetInstance().ReadOutput((int)EN_DIGITAL_OUT.DOOR_LOCK_2))
                {
                    btnRearDoor.CurrentDoorState = Sys3Controls.EDoorState.LOCKED;
                }
                else
                {
                    btnRearDoor.CurrentDoorState = Sys3Controls.EDoorState.CLOSED;
                }
            }

            if (DigitalIO_.DigitalIO.GetInstance().ReadOutput((int)EN_DIGITAL_OUT.DOOR_MAGNETIC_2))
            {
                btnRearMagnetic.CurrentDoorState = Sys3Controls.EDoorState.LOCKED;
            }
            else
            {
                btnRearMagnetic.CurrentDoorState = Sys3Controls.EDoorState.OPEN;
            }

        }
        private void UpdateAlamCode()
        {
            if (!EquipmentState_.EquipmentState.GetInstance().GetState().Equals(EquipmentState_.EQUIPMENT_STATE.IDLE)
                && !EquipmentState_.EquipmentState.GetInstance().GetState().Equals(EquipmentState_.EQUIPMENT_STATE.PAUSE))
                return;

            if (DigitalIO_.DigitalIO.GetInstance().ReadInput((int)EN_DIGITAL_IN.LD_1_ALARM))
            {
                ExternalDevice.Serial.ProtecLaserController.EN_CONTROL_ALARM enAlarm = ExternalDevice.Serial.ProtecLaserController.EN_CONTROL_ALARM.NONE;
                if (ExternalDevice.Serial.ProtecLaserController.GetInstance().GetAlarmCode(0, ref enAlarm) == ExternalDevice.Serial.ProtecLaserController.EN_RESULT.DONE)
                {
                    ExternalDevice.Serial.ProtecLaserController.GetInstance().ClearPortData(0);
                    m_lblAlarmCodePort1.Text = enAlarm.ToString();
                }
            }
            else
            {
                m_lblAlarmCodePort1.Text = ExternalDevice.Serial.ProtecLaserController.EN_CONTROL_ALARM.NONE.ToString();
            }

            if (DigitalIO_.DigitalIO.GetInstance().ReadInput((int)EN_DIGITAL_IN.LD_2_ALARM))
            {
                ExternalDevice.Serial.ProtecLaserController.EN_CONTROL_ALARM enAlarm = ExternalDevice.Serial.ProtecLaserController.EN_CONTROL_ALARM.NONE;
                if (ExternalDevice.Serial.ProtecLaserController.GetInstance().GetAlarmCode(1, ref enAlarm) == ExternalDevice.Serial.ProtecLaserController.EN_RESULT.DONE)
                {
                    ExternalDevice.Serial.ProtecLaserController.GetInstance().ClearPortData(1);
                    m_lblAlarmCodePort2.Text = enAlarm.ToString();
                }
            }
            else
            {
                m_lblAlarmCodePort2.Text = ExternalDevice.Serial.ProtecLaserController.EN_CONTROL_ALARM.NONE.ToString();
            }

            if (DigitalIO_.DigitalIO.GetInstance().ReadInput((int)EN_DIGITAL_IN.LD_3_ALARM))
            {
                ExternalDevice.Serial.ProtecLaserController.EN_CONTROL_ALARM enAlarm = ExternalDevice.Serial.ProtecLaserController.EN_CONTROL_ALARM.NONE;
                if (ExternalDevice.Serial.ProtecLaserController.GetInstance().GetAlarmCode(2, ref enAlarm) == ExternalDevice.Serial.ProtecLaserController.EN_RESULT.DONE)
                {
                    ExternalDevice.Serial.ProtecLaserController.GetInstance().ClearPortData(2);
                    m_lblAlarmCodePort3.Text = enAlarm.ToString();
                }
            }
            else
            {
                m_lblAlarmCodePort3.Text = ExternalDevice.Serial.ProtecLaserController.EN_CONTROL_ALARM.NONE.ToString();
            }

            if (DigitalIO_.DigitalIO.GetInstance().ReadInput((int)EN_DIGITAL_IN.MONITOR_ALARM))
            {
                ExternalDevice.Serial.ProtecLaserController.EN_MONITOR_ALARM enAlarm = ExternalDevice.Serial.ProtecLaserController.EN_MONITOR_ALARM.NONE;
                if (ExternalDevice.Serial.ProtecLaserController.GetInstance().GetAlarmCode(ref enAlarm) == ExternalDevice.Serial.ProtecLaserController.EN_RESULT.DONE)
                {
                    ExternalDevice.Serial.ProtecLaserController.GetInstance().ClearMonitorPortData();
                    m_lblAlarmCodeMonitor.Text = enAlarm.ToString();
                }
            }
            else
            {
                m_lblAlarmCodeMonitor.Text = ExternalDevice.Serial.ProtecLaserController.EN_MONITOR_ALARM.NONE.ToString();
            }
        }
        private void UpdateHeaterGridView()
        {
            int nRow = 0;
            //dataGridView_Heater[0, nRow].Value = "BLOCK HEATER ON";
            bool bRun = ExternalDevice.Heater.Heater.GetInstance().GetRunStatus((int)Define.DefineEnumProject.Heater.EN_HEATER_ZONE_LIST.BLCOK, 1);
            dataGridView_Heater[1, nRow].Style.BackColor = bRun ? c_clrTrue : c_clrFalse;
            dataGridView_Heater[1, nRow].Style.SelectionBackColor = bRun ? c_clrTrue : c_clrFalse;
            nRow++;

            //dataGridView_Heater[0, nRow].Value = "BLOCK TEMP";
            dataGridView_Heater[1, nRow].Value = ExternalDevice.Heater.Heater.GetInstance().GetMeanValue((int)Define.DefineEnumProject.Heater.EN_HEATER_ZONE_LIST.BLCOK) + " ℃";
            nRow++;
        }

        private void UpadateInformation()
        {
            m_lblID.Text = Work.WorkMap.GetInstance().GetID();
            m_lblWorkStatus.Text = Work.WorkMap.GetInstance().GetWorkStatus().ToString();

            Color StatusColor = Color.White;

            switch (Work.WorkMap.GetInstance().GetWorkStatus())
            {
                case EN_WORK_STATUS.WAIT:
                    StatusColor = Color.FromArgb(m_instanceRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.WAIT_COLOR.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0));
                    break;

                case EN_WORK_STATUS.DONE:
                    StatusColor = Color.FromArgb(m_instanceRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.DONE_COLOR.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0));
                    break;

                case EN_WORK_STATUS.LOW_TEMP:
                    StatusColor = Color.FromArgb(m_instanceRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.LOW_TEMP_COLOR.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0));
                    break;

                case EN_WORK_STATUS.TEMP_GROW_FAIL:
                    StatusColor = Color.FromArgb(m_instanceRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.TEMP_GROW_FAIL_COLOR.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0));
                    break;

                case EN_WORK_STATUS.TEMP_DEVOVER:
                    StatusColor = Color.FromArgb(m_instanceRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.TEMP_DEVOVER_COLOR.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0));
                    break;

                case EN_WORK_STATUS.HIGH_TEMP:
                    StatusColor = Color.FromArgb(m_instanceRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.HIGH_TEMP_COLOR.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0));
                    break;

                case EN_WORK_STATUS.MAX_HIGH_TEMP:
                    StatusColor = Color.FromArgb(m_instanceRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.MAX_HIGH_TEMP_COLOR.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0));
                    break;

                case EN_WORK_STATUS.EMG_LOW_TEMP:
                    StatusColor = Color.FromArgb(m_instanceRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.EMG_LOW_TEMP_COLOR.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0));
                    break;

                case EN_WORK_STATUS.EMG_HIGH_TEMP:
                    StatusColor = Color.FromArgb(m_instanceRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.EMG_HIGH_TEMP_COLOR.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0));
                    break;

                case EN_WORK_STATUS.POWER_FAULT:
                    StatusColor = Color.FromArgb(m_instanceRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.POWER_FAULT_COLOR.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0));
                    break;

                case EN_WORK_STATUS.SOURCE_ALARM:
                    StatusColor = Color.FromArgb(m_instanceRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.SOURCE_ALARM_COLOR.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0));
                    break;

                case EN_WORK_STATUS.RESULT_GETFAIL:
                    StatusColor = Color.FromArgb(m_instanceRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.RESULT_GETFAIL_COLOR.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0));
                    break;
            }

            string strPortName = "WORK_PORT";
            string TransferState  = "";
            string WorkZoneState  = "";
            string BondHeadState  = "";

            FrameOfSystem3.Config.ConfigPort.GetInstance().GetPortStatus(EN_TASK_LIST.TRANSFER.ToString(), strPortName, ref TransferState);
            FrameOfSystem3.Config.ConfigPort.GetInstance().GetPortStatus(EN_TASK_LIST.WORK_ZONE.ToString(), strPortName, ref WorkZoneState);
            FrameOfSystem3.Config.ConfigPort.GetInstance().GetPortStatus(EN_TASK_LIST.BOND_HEAD.ToString(), strPortName, ref BondHeadState);

            lblTransfer.UnitText = TransferState;
            lblWorkBlock.UnitText = WorkZoneState;
            lblBondHead.UnitText = BondHeadState;

            if(BondHeadState == DynamicLink_.EN_PORT_STATUS.WORKING.ToString())
            {
                lblTransfer.BackGroundColor = Color.White;
                lblWorkBlock.BackGroundColor = Color.White;
                lblBondHead.BackGroundColor = StatusColor;
            }
            else if (TransferState == DynamicLink_.EN_PORT_STATUS.EXIST.ToString()
                || TransferState == DynamicLink_.EN_PORT_STATUS.FINISHED.ToString())
            {
                lblTransfer.BackGroundColor = StatusColor;
                lblWorkBlock.BackGroundColor = Color.White;
                lblBondHead.BackGroundColor = Color.White;
            }
            else if(TransferState == DynamicLink_.EN_PORT_STATUS.EMPTY.ToString())
            {
                lblTransfer.BackGroundColor = Color.White;
                lblWorkBlock.BackGroundColor = Color.White;
                lblBondHead.BackGroundColor = Color.White;
            }
            else
            {
                lblTransfer.BackGroundColor = Color.White;
                lblWorkBlock.BackGroundColor = StatusColor;
                lblBondHead.BackGroundColor = Color.White;
            }

            TaskData pTaskData = null;
            m_instanceOperator.GetTaskInformation((int)EN_TASK_LIST.TRANSFER, ref pTaskData);
            lblTransfer.Text = pTaskData.strRunningAction.Replace("_"," ");

            m_instanceOperator.GetTaskInformation((int)EN_TASK_LIST.WORK_ZONE, ref pTaskData);
            lblWorkBlock.Text = pTaskData.strRunningAction.Replace("_", " ");

            m_instanceOperator.GetTaskInformation((int)EN_TASK_LIST.BOND_HEAD, ref pTaskData);
            lblBondHead.Text = pTaskData.strRunningAction.Replace("_", " ");
        }

        private void UpdateWaferInformation()
        {
            LB_LotID.Text = WorkMap.GetInstance().GetValue(EN_WAFER_ITEM.LOT_ID);
            LB_PartName.Text = WorkMap.GetInstance().GetValue(EN_WAFER_ITEM.PART_NAME);
            LB_LotType.Text = WorkMap.GetInstance().GetValue(EN_WAFER_ITEM.LOT_TYPE);
            LB_StepSeq.Text = WorkMap.GetInstance().GetValue(EN_WAFER_ITEM.STEP_SEQ);
            LB_WaferCol.Text = WorkMap.GetInstance().GetValue(EN_WAFER_ITEM.WAFER_COL);
            LB_WaferRow.Text = WorkMap.GetInstance().GetValue(EN_WAFER_ITEM.WAFER_ROW);
            LB_Angle.Text = WorkMap.GetInstance().GetValue(EN_WAFER_ITEM.ANGLE);
            //LB_WaferMap.Text = WorkMap.GetInstance().GetValue(EN_WAFER_ITEM.WAFER_MAP);
            LB_CountChips.Text = WorkMap.GetInstance().GetValue(EN_WAFER_ITEM.COUNT_CHIPS);
            LB_SlotNo.Text = WorkMap.GetInstance().GetValue(EN_WAFER_ITEM.SLOT_NO);
        
        }
        #endregion /Update Control
        #endregion

     

    }
}