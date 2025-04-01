using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TickCounter_;

using RunningMain_;
using TaskAction_;

using EQUIPMENT_PARAM = FrameOfSystem3.Recipe.PARAM_EQUIPMENT;
using BONDER_TASK_PARAM = Define.DefineEnumProject.Task.BondHead.PARAM_PROCESS;
//using WORKZONE_TASK_PARAM = Define.DefineEnumProject.Task.WorkZone.PARAM_PROCESS;

using Define.DefineEnumProject.Motion;
using Define.DefineEnumProject.DigitalIO;
using Define.DefineEnumProject.AnalogIO;
using Define.DefineEnumProject.Task;

using FrameOfSystem3.Work;
using FrameOfSystem3.Config;
using FrameOfSystem3.Task;

using FrameOfSystem3.Views.Setup;
using FrameOfSystem3.Component;
using FrameOfSystem3.Recipe;
using FrameOfSystem3.Laser;
using RecipeManager_;

namespace FrameOfSystem3.Views.Operation
{
	public partial class Operation_Main : UserControlForMainView.CustomView
	{
		public Operation_Main()
		{
			InitializeComponent();
            MakeMappingTable();
            m_InstanceOfSelectionList = Functional.Form_SelectionList.GetInstance();
            InitGridEnableParameter();
            InitGridLaserDevice();
            InitGridLaserParameter();
            InitGridPowerMesureParameter();
            
            InitGridEnableParameter_2();
            InitGridLaserDevice_2();
            InitGridLaserParameter_2();
            InitGridPowerMesureParameter_2();

            #region Instance
            _Calculator_Instance_m_p = Functional.Form_Calculator.GetInstance();
            m_LaserCalManager = Laser.ProtecLaserChannelCalibration.GetInstance();
            m_LaserCalManager_2 = Laser.ProtecLaserChannelCalibration_2.GetInstance();
            #endregion

            ComboBox_Channel.SelectedIndex = 0;
            ComboBox_Channel_2.SelectedIndex = 0;
        }

        #region Enum
        private enum EN_GRID_INDEX
        {
            INDEX = 0,
            VOLT = 1,
            INPUT_VOLT = 2,
            OUTPUT_POWER = 3,
        }
        private enum EN_GRID_INDEX_2
        {
            INDEX = 0,
            VOLT = 1,
            INPUT_VOLT = 2,
            OUTPUT_POWER = 3,
        }
        #endregion

        #region <FIELD>
        private FrameOfSystem3.Recipe.Recipe m_instanceRecipe = FrameOfSystem3.Recipe.Recipe.GetInstance();
        TaskOperator m_Operator = TaskOperator.GetInstance();
        Functional.Form_MessageBox m_MessageBox = Functional.Form_MessageBox.GetInstance();

        private Laser.ProtecLaserChannelCalibration m_LaserCalManager = null;
        private Laser.ProtecLaserChannelCalibration_2 m_LaserCalManager_2 = null;
        private FileDialog m_instanceFile = new OpenFileDialog();
        private Functional.Form_Calculator _Calculator_Instance_m_p = null;
        Laser.ProtecLaserMananger m_Laser = Laser.ProtecLaserMananger.GetInstance();
        Laser.ProtecLaserMananger_2 m_Laser_2 = Laser.ProtecLaserMananger_2.GetInstance();
        private TickCounter m_tickCount = new TickCounter();

        Dictionary<string, RUN_MODE> m_DicForRunMode = new Dictionary<string, RUN_MODE>();
        Functional.Form_SelectionList m_InstanceOfSelectionList = null;
        Functional.Form_MessageBox m_InstanceMessageBox = null;
        private readonly string STR_INITALIZE_TASK = "INITIALIZE TASK";
        #region Task
        Task.TaskOperator m_instanceOperator = null;
        private int m_nCountOfTask = 0;
        string[] m_arTaskList = null;
        #endregion

        #region Action
        TaskActionFlow m_instanceActionFlow = null;
        #endregion
        #endregion </FIELD>

        #region 내부인터페이스
        /// <summary>
        /// 2020.07.20 by twkang [ADD] 클래스에서 사용할 MappingTable 을 만든다.
        /// </summary>
        private void MakeMappingTable()
        {
            m_DicForRunMode.Clear();
            foreach (RUN_MODE en in Enum.GetValues(typeof(RUN_MODE)))
            {
                m_DicForRunMode.Add(en.ToString(), en);
            }
        }
        /// <summary>
        /// 2020.09.15 by twkang [ADD] 이니셜라이즈 동작할 테스크를 선택한다.
        /// </summary>
        private bool SetInitializeTask()
        {
            string[] arTask = null;
            int[] arIndex = null;
            bool[] arInit = null;
            string strPreValue = string.Empty;
            List<string> listInitializeTask = new List<string>();

            if (false == Task.TaskOperator.GetInstance().GetInitializingTask(ref arTask, ref arInit))
            {
                return false;
            }

            for (int nIndex = 0, nEnd = arInit.Length; nIndex < nEnd; ++nIndex)
            {
                // 2023.05.19 by junho [ADD] Initialize button 눌렀을 때에는 항상 모든 Task가 선택되어 있도록 변경
                arInit[nIndex] = false;

                if (false == arInit[nIndex])
                {
                    listInitializeTask.Add(arTask[nIndex]);
                }
            }
            strPreValue = string.Join(", ", listInitializeTask);

            if (m_InstanceOfSelectionList.CreateForm(STR_INITALIZE_TASK, arTask, strPreValue, true))
            {
                m_InstanceOfSelectionList.GetResult(ref arIndex);

                for (int nIndex = 0, nEnd = arInit.Length; nIndex < nEnd; ++nIndex)
                {
                    arInit[nIndex] = false;
                }

                for (int nIndex = 0, nEnd = arIndex.Length; nIndex < nEnd; ++nIndex)
                {
                    arInit[arIndex[nIndex]] = true;
                }

                return Task.TaskOperator.GetInstance().SetInitializingTask(ref arTask, ref arInit);
            }
            return false;
        }
        #endregion
        #region UI 이벤트
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
                    //if (m_instanceRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, PARAM_EQUIPMENT.LASER_USED.ToString(), false) == false)
                    //{
                    //    if (m_InstanceMessageBox.ShowMessage("LASER PARAMETER OFF\nDO YOU WANT RUN?", "CONFIRMATION MESSAGE", true) == false)
                    //        return;
                    //}
                    Task.TaskOperator.GetInstance().SetOperation(OPERATION_EQUIPMENT.RUN);
                    break;
                case 2: // STOP
                    Task.TaskOperator.GetInstance().SetOperation(OPERATION_EQUIPMENT.STOP);
                    return;
            }
        }
        private void Click_RunMode(object sender, EventArgs e)
        {
            string strValue = string.Empty;

            if (m_InstanceOfSelectionList.CreateForm(m_groupRunMode.Text, Define.DefineEnumProject.SelectionList.EN_SELECTIONLIST.OPERATION_EQUIPMENT, m_labelRunMode.Text))
            {
                m_InstanceOfSelectionList.GetResult(ref strValue);

                if (m_DicForRunMode.ContainsKey(strValue))
                {
                    Task.TaskOperator.GetInstance().SetRunMode(m_DicForRunMode[strValue]);
                    m_labelRunMode.Text = Task.TaskOperator.GetInstance().GetRunMode().ToString();
                }
            }
        }
        
        #endregion
        #region <OVERRIDE>
        public override void CallFunctionByTimer()
        {
            base.CallFunctionByTimer();
            UpdateAlamCode();
            gridVeiwControl_Laser_Device.UpdateState();

            UpdateAlamCode_2();
            gridVeiwControl_Laser_Device_2.UpdateState();
        }
        protected override void ProcessWhenActivation()
        {
            m_instanceOperator = Task.TaskOperator.GetInstance();
            m_InstanceMessageBox = Functional.Form_MessageBox.GetInstance();

            if (m_instanceOperator.GetListOfTask(ref m_nCountOfTask, ref m_arTaskList))
            {

            }

            m_instanceActionFlow = TaskActionFlow.GetInstance();

            base.ProcessWhenActivation();
            UpdateParamter();
            UpdatePowerLabel();
            gridViewControl_Power_Measure_Parameter.UpdateValue();
            UpdatePowerTable();

            UpdatePowerLabel_2();
            gridViewControl_Power_Measure_Parameter_2.UpdateValue();
            UpdatePowerTable_2();
        }
        protected override void ProcessWhenDeactivation()
        {
            if (m_instanceRecipe.IsExistDeferredStorage())
            {
                if (m_MessageBox.ShowMessage("Do You Want To Save Recipe?"))
                    m_instanceRecipe.ApplyDeferredStorage();
                else
                    m_instanceRecipe.ClearDeferredStorage();
            }

            base.ProcessWhenDeactivation();
        }
        #endregion </OVERRIDE>

        #region <INTERNAL>
        private void InitGridEnableParameter()
        {
            List<GridViewControl_Parameter.ParameterItem> parameterList = new List<GridViewControl_Parameter.ParameterItem>();

            GridViewControl_Parameter.ParameterItem AddParaItem;
            List<int> lstIndex = new List<int>();
            List<string> lstDisplay = new List<string>();
            List<string> lstParam = new List<string>();
            for (int nCh = Laser.ProtecLaserMananger.GetInstance().ChannelCount / 2; nCh < Laser.ProtecLaserMananger.GetInstance().ChannelCount; nCh++)
            {
                lstIndex.Add(nCh);
                lstDisplay.Add("CH " + (nCh + 1).ToString());
                lstParam.Add(BONDER_TASK_PARAM.SHOT_PARAMETER_ENABLE_18.ToString());
            }

            AddParaItem = new GridViewControl_Parameter.ParameterItem(EN_TASK_LIST.BOND_HEAD, lstParam, lstIndex);
            AddParaItem.DisplayName = "ENABLE";
            AddParaItem.ParameterSettingType = Define.DefineEnumBase.Component.EN_PARAMETER_SETTING_TYPE.TRUE_FALSE;
            AddParaItem.TrueFalseName = lstDisplay;
            AddParaItem.AfterSetParameter = SetPowerMinMax;
            parameterList.Add(AddParaItem);

            lstIndex = new List<int>();
            lstDisplay = new List<string>();
            lstParam = new List<string>();
            for (int nCh = 0; nCh < Laser.ProtecLaserMananger.GetInstance().ChannelCount / 2; nCh++)
            {
                lstIndex.Add(nCh);
                lstDisplay.Add("CH " + (nCh + 1).ToString());
                lstParam.Add(BONDER_TASK_PARAM.SHOT_PARAMETER_ENABLE_18.ToString());
            }

            AddParaItem = new GridViewControl_Parameter.ParameterItem(EN_TASK_LIST.BOND_HEAD, lstParam, lstIndex);
            AddParaItem.DisplayName = " ";
            AddParaItem.ParameterSettingType = Define.DefineEnumBase.Component.EN_PARAMETER_SETTING_TYPE.TRUE_FALSE;
            AddParaItem.TrueFalseName = lstDisplay;
            AddParaItem.AfterSetParameter = SetPowerMinMax;
            parameterList.Add(AddParaItem);

            gridViewControl_Enable_Parameter.Initialize(parameterList, -1, 110);
        }
        private void InitGridEnableParameter_2()
        {
            List<GridViewControl_Parameter.ParameterItem> parameterList = new List<GridViewControl_Parameter.ParameterItem>();

            GridViewControl_Parameter.ParameterItem AddParaItem;
            List<int> lstIndex = new List<int>();
            List<string> lstDisplay = new List<string>();
            List<string> lstParam = new List<string>();
            for (int nCh = Laser.ProtecLaserMananger_2.GetInstance().ChannelCount / 2; nCh < Laser.ProtecLaserMananger_2.GetInstance().ChannelCount; nCh++)
            {
                lstIndex.Add(nCh);
                lstDisplay.Add("CH " + (nCh + 1).ToString());
                lstParam.Add(BONDER_TASK_PARAM.SHOT_PARAMETER_2_ENABLE_18.ToString());
            }

            AddParaItem = new GridViewControl_Parameter.ParameterItem(EN_TASK_LIST.BOND_HEAD, lstParam, lstIndex);
            AddParaItem.DisplayName = "ENABLE";
            AddParaItem.ParameterSettingType = Define.DefineEnumBase.Component.EN_PARAMETER_SETTING_TYPE.TRUE_FALSE;
            AddParaItem.TrueFalseName = lstDisplay;
            AddParaItem.AfterSetParameter = SetPowerMinMax_2;
            parameterList.Add(AddParaItem);

            lstIndex = new List<int>();
            lstDisplay = new List<string>();
            lstParam = new List<string>();
            for (int nCh = 0; nCh < Laser.ProtecLaserMananger_2.GetInstance().ChannelCount / 2; nCh++)
            {
                lstIndex.Add(nCh);
                lstDisplay.Add("CH " + (nCh + 1).ToString());
                lstParam.Add(BONDER_TASK_PARAM.SHOT_PARAMETER_2_ENABLE_18.ToString());
            }

            AddParaItem = new GridViewControl_Parameter.ParameterItem(EN_TASK_LIST.BOND_HEAD, lstParam, lstIndex);
            AddParaItem.DisplayName = " ";
            AddParaItem.ParameterSettingType = Define.DefineEnumBase.Component.EN_PARAMETER_SETTING_TYPE.TRUE_FALSE;
            AddParaItem.TrueFalseName = lstDisplay;
            AddParaItem.AfterSetParameter = SetPowerMinMax_2;
            parameterList.Add(AddParaItem);

            gridViewControl_Enable_Parameter_2.Initialize(parameterList, -1, 110);
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
        }
        private void InitGridLaserDevice_2()
        {
            List<GridVeiwControl_Device.ControlItem> ControlList = new List<GridVeiwControl_Device.ControlItem>();

            GridVeiwControl_Device.ControlItem AddControlItem;

            List<int> lstIndex = new List<int>();

            lstIndex = new List<int>();
            lstIndex.Add((int)EN_DIGITAL_IN.LD_1_ON_2);
            lstIndex.Add((int)EN_DIGITAL_IN.LD_2_ON_2);
            lstIndex.Add((int)EN_DIGITAL_IN.LD_3_ON_2);
            AddControlItem = new GridVeiwControl_Device.ControlItem(lstIndex, GridVeiwControl_Device.EN_CONTROL_TYPE.DIGITAL_INPUT);
            AddControlItem.Name = "ON";
            ControlList.Add(AddControlItem);

            lstIndex = new List<int>();
            lstIndex.Add((int)EN_DIGITAL_IN.LD_1_READY_2);
            lstIndex.Add((int)EN_DIGITAL_IN.LD_2_READY_2);
            lstIndex.Add((int)EN_DIGITAL_IN.LD_3_READY_2);
            AddControlItem = new GridVeiwControl_Device.ControlItem(lstIndex, GridVeiwControl_Device.EN_CONTROL_TYPE.DIGITAL_INPUT);
            AddControlItem.Name = "READY";
            ControlList.Add(AddControlItem);

            lstIndex = new List<int>();
            lstIndex.Add((int)EN_DIGITAL_OUT.LD_1_READY_2);
            lstIndex.Add((int)EN_DIGITAL_OUT.LD_2_READY_2);
            lstIndex.Add((int)EN_DIGITAL_OUT.LD_3_READY_2);
            AddControlItem = new GridVeiwControl_Device.ControlItem(lstIndex, GridVeiwControl_Device.EN_CONTROL_TYPE.DIGITAL_OUTPUT);
            AddControlItem.Name = "READY";
            ControlList.Add(AddControlItem);

            lstIndex = new List<int>();
            lstIndex.Add((int)EN_DIGITAL_IN.LD_1_ALARM_2);
            lstIndex.Add((int)EN_DIGITAL_IN.LD_2_ALARM_2);
            lstIndex.Add((int)EN_DIGITAL_IN.LD_3_ALARM_2);
            lstIndex.Add((int)EN_DIGITAL_IN.MONITOR_ALARM_2);
            AddControlItem = new GridVeiwControl_Device.ControlItem(lstIndex, GridVeiwControl_Device.EN_CONTROL_TYPE.DIGITAL_INPUT);
            AddControlItem.Name = "ALARM";
            ControlList.Add(AddControlItem);

            lstIndex = new List<int>();
            lstIndex.Add((int)EN_DIGITAL_OUT.LD_1_ALARM_CLEAR_2);
            lstIndex.Add((int)EN_DIGITAL_OUT.LD_2_ALARM_CLEAR_2);
            lstIndex.Add((int)EN_DIGITAL_OUT.LD_3_ALARM_CLEAR_2);
            lstIndex.Add((int)EN_DIGITAL_OUT.MONITOR_ALARM_CLEAR_2);
            AddControlItem = new GridVeiwControl_Device.ControlItem(lstIndex, GridVeiwControl_Device.EN_CONTROL_TYPE.DIGITAL_OUTPUT);
            AddControlItem.Name = "RESET";
            ControlList.Add(AddControlItem);

            lstIndex = new List<int>();
            lstIndex.Add((int)EN_DIGITAL_OUT.LD_1_EMO_2);
            lstIndex.Add((int)EN_DIGITAL_OUT.LD_2_EMO_2);
            lstIndex.Add((int)EN_DIGITAL_OUT.LD_3_EMO_2);
            lstIndex.Add((int)EN_DIGITAL_OUT.MONITOR_EMO_2);
            AddControlItem = new GridVeiwControl_Device.ControlItem(lstIndex, GridVeiwControl_Device.EN_CONTROL_TYPE.DIGITAL_OUTPUT);
            AddControlItem.Name = "EMO";
            ControlList.Add(AddControlItem);


            gridVeiwControl_Laser_Device_2.Initialize(ControlList);

            List<string> lstHeader = new List<string>();

            lstHeader.Add("");
            lstHeader.Add("PORT 1");
            lstHeader.Add("PORT 2");
            lstHeader.Add("PORT 3");
            lstHeader.Add("MONITOR");

            gridVeiwControl_Laser_Device_2.ShowHeader(lstHeader);
        }
        private void InitGridLaserParameter()
        {
            List<GridViewControl_Parameter.ParameterItem> parameterList = new List<GridViewControl_Parameter.ParameterItem>();

            List<int> AddParaIndexList = new List<int>();
            AddParaIndexList.Add(0);
            AddParaIndexList.Add(1);
            AddParaIndexList.Add(2);
            AddParaIndexList.Add(3);
            AddParaIndexList.Add(4);

            List<string> AddParaList = new List<string>();

            AddParaList.Add(BONDER_TASK_PARAM.SHOT_PARAMETER_TOTAL_POWER.ToString());

            GridViewControl_Parameter.ParameterItem AddParaItem = new GridViewControl_Parameter.ParameterItem(EN_TASK_LIST.BOND_HEAD, AddParaList, AddParaIndexList);
            AddParaItem.DisplayName = "LASER TOTAL POWER";
            parameterList.Add(AddParaItem);

            

            gridViewControl_Laser_Parameter.Initialize(parameterList, -1, 105);

            List<string> HeaderList = new List<string>();
            HeaderList.Add("");
            HeaderList.Add("WATT");
            gridViewControl_Laser_Parameter.ShowHeader(HeaderList);
        }
        //private void InitGridLaserParameter()
        //{
        //    List<GridViewControl_Parameter.ParameterItem> parameterList = new List<GridViewControl_Parameter.ParameterItem>();
        //    List<int> addParaIndexList = Enumerable.Range(0, 18).ToList(); 

        //    AddLaserParameter(parameterList, BONDER_TASK_PARAM.SHOT_PARA_CONTINUOUS_POWER_18, "LASER POWER", addParaIndexList);

        //    gridViewControl_Laser_Parameter.Initialize(parameterList, -1, 55);
        //    gridViewControl_Laser_Parameter.ShowHeader(GenerateHeaderList(18));
        //}

        //private void AddLaserParameter(List<GridViewControl_Parameter.ParameterItem> parameterList, BONDER_TASK_PARAM param, string displayName, List<int> indexList)
        //{
        //    List<string> addParaList = Enumerable.Repeat(param.ToString(), indexList.Count).ToList();
        //    var addParaItem = new GridViewControl_Parameter.ParameterItem(EN_TASK_LIST.BOND_HEAD, addParaList, indexList)
        //    {
        //        DisplayName = displayName
        //    };
        //    parameterList.Add(addParaItem);
        //}

        //private List<string> GenerateHeaderList(int stepCount)
        //{
        //    List<string> headerList = new List<string> { "" };
        //    headerList.AddRange(Enumerable.Range(1, stepCount).Select(step => $"CH {step}"));
        //    return headerList;
        //}
        private void InitGridLaserParameter_2()
        {
            List<GridViewControl_Parameter.ParameterItem> parameterList = new List<GridViewControl_Parameter.ParameterItem>();

            List<int> AddParaIndexList = new List<int>();
            AddParaIndexList.Add(0);
            AddParaIndexList.Add(1);
            AddParaIndexList.Add(2);
            AddParaIndexList.Add(3);
            AddParaIndexList.Add(4);

            List<string> AddParaList = new List<string>();

            AddParaList.Add(BONDER_TASK_PARAM.SHOT_PARAMETER_2_TOTAL_POWER.ToString());

            GridViewControl_Parameter.ParameterItem AddParaItem = new GridViewControl_Parameter.ParameterItem(EN_TASK_LIST.BOND_HEAD, AddParaList, AddParaIndexList);
            AddParaItem.DisplayName = "LASER TOTAL POWER";
            parameterList.Add(AddParaItem);



            gridViewControl_Laser_Parameter_2.Initialize(parameterList, -1, 105);

            List<string> HeaderList = new List<string>();
            HeaderList.Add("");
            HeaderList.Add("WATT");
            gridViewControl_Laser_Parameter_2.ShowHeader(HeaderList);
            //List<GridViewControl_Parameter.ParameterItem> parameterList = new List<GridViewControl_Parameter.ParameterItem>();

            //List<int> AddParaIndexList = new List<int>();
            //AddParaIndexList.Add(0);
            //AddParaIndexList.Add(1);
            //AddParaIndexList.Add(2);
            //AddParaIndexList.Add(3);
            //AddParaIndexList.Add(4);

            //List<string> AddParaList = new List<string>();

            //AddParaList.Add(BONDER_TASK_PARAM.SHOT_PARAMETER_2_STEP_POWER_5.ToString());
            //AddParaList.Add(BONDER_TASK_PARAM.SHOT_PARAMETER_2_STEP_POWER_5.ToString());
            //AddParaList.Add(BONDER_TASK_PARAM.SHOT_PARAMETER_2_STEP_POWER_5.ToString());
            //AddParaList.Add(BONDER_TASK_PARAM.SHOT_PARAMETER_2_STEP_POWER_5.ToString());
            //AddParaList.Add(BONDER_TASK_PARAM.SHOT_PARAMETER_2_STEP_POWER_5.ToString());
            //GridViewControl_Parameter.ParameterItem AddParaItem = new GridViewControl_Parameter.ParameterItem(EN_TASK_LIST.BOND_HEAD, AddParaList, AddParaIndexList);
            //AddParaItem.DisplayName = "LASER POWER";
            //parameterList.Add(AddParaItem);

            //AddParaList = new List<string>();
            //AddParaList.Add(BONDER_TASK_PARAM.SHOT_PARAMETER_2_STEP_TIME_5.ToString());
            //AddParaList.Add(BONDER_TASK_PARAM.SHOT_PARAMETER_2_STEP_TIME_5.ToString());
            //AddParaList.Add(BONDER_TASK_PARAM.SHOT_PARAMETER_2_STEP_TIME_5.ToString());
            //AddParaList.Add(BONDER_TASK_PARAM.SHOT_PARAMETER_2_STEP_TIME_5.ToString());
            //AddParaList.Add(BONDER_TASK_PARAM.SHOT_PARAMETER_2_STEP_TIME_5.ToString());
            //AddParaItem = new GridViewControl_Parameter.ParameterItem(EN_TASK_LIST.BOND_HEAD, AddParaList, AddParaIndexList);
            //AddParaItem.DisplayName = "LASER TIME";
            //parameterList.Add(AddParaItem);

            //gridViewControl_Laser_Parameter_2.Initialize(parameterList, -1, 85);

            //List<string> HeaderList = new List<string>();
            //HeaderList.Add("");
            //HeaderList.Add("STEP 1");
            //HeaderList.Add("STEP 2");
            //HeaderList.Add("STEP 3");
            //HeaderList.Add("STEP 4");
            //HeaderList.Add("STEP 5");
            //gridViewControl_Laser_Parameter_2.ShowHeader(HeaderList);
        }


        private void Click_Stop(object sender, EventArgs e)
        {
            FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(false, (int)EN_DIGITAL_OUT.LD_1_ON);
            FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(false, (int)EN_DIGITAL_OUT.LD_2_ON);
            FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(false, (int)EN_DIGITAL_OUT.LD_3_ON);
            FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(false, (int)EN_DIGITAL_OUT.LD_1_ON_2);
            FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(false, (int)EN_DIGITAL_OUT.LD_2_ON_2);
            FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(false, (int)EN_DIGITAL_OUT.LD_3_ON_2);
        }

        private void Click_Action(object sender, EventArgs e)
        {
            if (!EquipmentState_.EquipmentState.GetInstance().GetState().Equals(EquipmentState_.EQUIPMENT_STATE.IDLE))
                return;

            Control ctrButton = sender as Control;

            string strAction = ctrButton.Text.Replace("\\n", "");
            if (!m_MessageBox.ShowMessage(string.Format("Do You Want {0}?", strAction)))
                return;


            string[] arSelectTask = new string[] { };
            string[][] arSelectAction = new string[][] { };
            int nRetryTime = 1;
            switch (ctrButton.TabIndex)
            {
                case 0:
                    arSelectAction = new string[1][];
                    arSelectTask = new string[] { EN_TASK_LIST.BOND_HEAD.ToString() };
                    arSelectAction[0] = new string[] { Define.DefineEnumProject.Task.BondHead.EN_TASK_ACTION.LASER_WORK.ToString() };
                    Task.TaskOperator.GetInstance().SetOperation(ref arSelectTask, ref arSelectAction, nRetryTime);
                    break;

                case 5:
                    arSelectAction = new string[1][];
                    arSelectTask = new string[] { EN_TASK_LIST.BOND_HEAD.ToString() };
                    arSelectAction[0] = new string[] { Define.DefineEnumProject.Task.BondHead.EN_TASK_ACTION.MEASURE_POWER.ToString() };
                    Task.TaskOperator.GetInstance().SetOperation(ref arSelectTask, ref arSelectAction, nRetryTime);
                    break;
                case 6:
                    arSelectAction = new string[1][];
                    arSelectTask = new string[] { EN_TASK_LIST.BOND_HEAD.ToString() };
                    arSelectAction[0] = new string[] { Define.DefineEnumProject.Task.BondHead.EN_TASK_ACTION.MEASURE_VOLT.ToString() };
                    Task.TaskOperator.GetInstance().SetOperation(ref arSelectTask, ref arSelectAction, nRetryTime);
                    break;
                case 7:
                    arSelectAction = new string[1][];
                    arSelectTask = new string[] { EN_TASK_LIST.BOND_HEAD.ToString() };
                    arSelectAction[0] = new string[] { Define.DefineEnumProject.Task.BondHead.EN_TASK_ACTION.CALIBRATION_CHANNEL_POWER.ToString() };
                    Task.TaskOperator.GetInstance().SetOperation(ref arSelectTask, ref arSelectAction, nRetryTime);
                    break;
                case 8:
                    arSelectAction = new string[1][];
                    arSelectTask = new string[] { EN_TASK_LIST.BOND_HEAD.ToString() };
                    arSelectAction[0] = new string[] { Define.DefineEnumProject.Task.BondHead.EN_TASK_ACTION.SHORT_TEST.ToString() };
                    Task.TaskOperator.GetInstance().SetOperation(ref arSelectTask, ref arSelectAction, nRetryTime);
                    break;
            }
        }
        private void SetPowerMinMax()
        {
            bool[] arUsed = new bool[ProtecLaserMananger.GetInstance().ChannelCount];
            for (int nCh = 0; nCh < ProtecLaserMananger.GetInstance().ChannelCount; ++nCh)
            {
                arUsed[nCh] = m_instanceRecipe.GetValue(EN_TASK_LIST.BOND_HEAD.ToString(), BONDER_TASK_PARAM.POWER_MEASURE_CHANNEL_ENABLE_18.ToString(), nCh, EN_RECIPE_PARAM_TYPE.VALUE, false);
            }

            m_instanceRecipe.SetValue(EN_TASK_LIST.BOND_HEAD.ToString(), BONDER_TASK_PARAM.POWER_MEASURE_WATT.ToString(), 0, EN_RECIPE_PARAM_TYPE.MAX, m_LaserCalManager.GetMaxPower(arUsed).ToString());
            m_instanceRecipe.SetValue(EN_TASK_LIST.BOND_HEAD.ToString(), BONDER_TASK_PARAM.POWER_MEASURE_WATT.ToString(), 0, EN_RECIPE_PARAM_TYPE.MIN, m_LaserCalManager.GetMinPower(arUsed).ToString());
        }
        private void SetPowerMinMax_2()
        {
            bool[] arUsed = new bool[ProtecLaserMananger_2.GetInstance().ChannelCount];
            for (int nCh = 0; nCh < ProtecLaserMananger_2.GetInstance().ChannelCount; ++nCh)
            {
                arUsed[nCh] = m_instanceRecipe.GetValue(EN_TASK_LIST.BOND_HEAD.ToString(), BONDER_TASK_PARAM.POWER_MEASURE_2_CHANNEL_ENABLE_18.ToString(), nCh, EN_RECIPE_PARAM_TYPE.VALUE, false);
            }

            m_instanceRecipe.SetValue(EN_TASK_LIST.BOND_HEAD.ToString(), BONDER_TASK_PARAM.POWER_MEASURE_2_WATT.ToString(), 0, EN_RECIPE_PARAM_TYPE.MAX, m_LaserCalManager_2.GetMaxPower(arUsed).ToString());
            m_instanceRecipe.SetValue(EN_TASK_LIST.BOND_HEAD.ToString(), BONDER_TASK_PARAM.POWER_MEASURE_2_WATT.ToString(), 0, EN_RECIPE_PARAM_TYPE.MIN, m_LaserCalManager_2.GetMinPower(arUsed).ToString());
        }

        private void UpdateAlamCode()
        {
            if (!EquipmentState_.EquipmentState.GetInstance().GetState().Equals(EquipmentState_.EQUIPMENT_STATE.IDLE))
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
        private void UpdateAlamCode_2()
        {
            if (!EquipmentState_.EquipmentState.GetInstance().GetState().Equals(EquipmentState_.EQUIPMENT_STATE.IDLE))
                return;

            if (DigitalIO_.DigitalIO.GetInstance().ReadInput((int)EN_DIGITAL_IN.LD_1_ALARM_2))
            {
                ExternalDevice.Serial.ProtecLaserController_2.EN_CONTROL_ALARM_2 enAlarm = ExternalDevice.Serial.ProtecLaserController_2.EN_CONTROL_ALARM_2.NONE;
                if (ExternalDevice.Serial.ProtecLaserController_2.GetInstance().GetAlarmCode(0, ref enAlarm) == ExternalDevice.Serial.ProtecLaserController_2.EN_RESULT_2.DONE)
                {
                    ExternalDevice.Serial.ProtecLaserController_2.GetInstance().ClearPortData(0);
                    m_lblAlarmCodePort1_2.Text = enAlarm.ToString();
                }
            }
            else
            {
                m_lblAlarmCodePort1.Text = ExternalDevice.Serial.ProtecLaserController_2.EN_CONTROL_ALARM_2.NONE.ToString();
            }

            if (DigitalIO_.DigitalIO.GetInstance().ReadInput((int)EN_DIGITAL_IN.LD_2_ALARM_2))
            {
                ExternalDevice.Serial.ProtecLaserController_2.EN_CONTROL_ALARM_2 enAlarm = ExternalDevice.Serial.ProtecLaserController_2.EN_CONTROL_ALARM_2.NONE;
                if (ExternalDevice.Serial.ProtecLaserController_2.GetInstance().GetAlarmCode(1, ref enAlarm) == ExternalDevice.Serial.ProtecLaserController_2.EN_RESULT_2.DONE)
                {
                    ExternalDevice.Serial.ProtecLaserController_2.GetInstance().ClearPortData(1);
                    m_lblAlarmCodePort2_2.Text = enAlarm.ToString();
                }
            }
            else
            {
                m_lblAlarmCodePort2.Text = ExternalDevice.Serial.ProtecLaserController_2.EN_CONTROL_ALARM_2.NONE.ToString();
            }

            if (DigitalIO_.DigitalIO.GetInstance().ReadInput((int)EN_DIGITAL_IN.LD_3_ALARM_2))
            {
                ExternalDevice.Serial.ProtecLaserController_2.EN_CONTROL_ALARM_2 enAlarm = ExternalDevice.Serial.ProtecLaserController_2.EN_CONTROL_ALARM_2.NONE;
                if (ExternalDevice.Serial.ProtecLaserController_2.GetInstance().GetAlarmCode(2, ref enAlarm) == ExternalDevice.Serial.ProtecLaserController_2.EN_RESULT_2.DONE)
                {
                    ExternalDevice.Serial.ProtecLaserController_2.GetInstance().ClearPortData(2);
                    m_lblAlarmCodePort3_2.Text = enAlarm.ToString();
                }
            }
            else
            {
                m_lblAlarmCodePort3.Text = ExternalDevice.Serial.ProtecLaserController_2.EN_CONTROL_ALARM_2.NONE.ToString();
            }

            if (DigitalIO_.DigitalIO.GetInstance().ReadInput((int)EN_DIGITAL_IN.MONITOR_ALARM_2))
            {
                ExternalDevice.Serial.ProtecLaserController_2.EN_MONITOR_ALARM_2 enAlarm = ExternalDevice.Serial.ProtecLaserController_2.EN_MONITOR_ALARM_2.NONE;
                if (ExternalDevice.Serial.ProtecLaserController_2.GetInstance().GetAlarmCode(ref enAlarm) == ExternalDevice.Serial.ProtecLaserController_2.EN_RESULT_2.DONE)
                {
                    ExternalDevice.Serial.ProtecLaserController_2.GetInstance().ClearMonitorPortData();
                    m_lblAlarmCodeMonitor_2.Text = enAlarm.ToString();
                }
            }
            else
            {
                m_lblAlarmCodeMonitor_2.Text = ExternalDevice.Serial.ProtecLaserController_2.EN_MONITOR_ALARM_2.NONE.ToString();
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
        private void Cick_All_IO_2(object sender, EventArgs e)
        {
            Control ctrButton = sender as Control;
            switch (ctrButton.TabIndex)
            {
                case 0: // RESET
                    if (!FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().ReadItem(false, (int)EN_DIGITAL_OUT.LD_1_ALARM_CLEAR_2)
                        || !FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().ReadItem(false, (int)EN_DIGITAL_OUT.LD_2_ALARM_CLEAR_2)
                        || !FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().ReadItem(false, (int)EN_DIGITAL_OUT.LD_3_ALARM_CLEAR_2)
                        || !FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().ReadItem(false, (int)EN_DIGITAL_OUT.MONITOR_ALARM_CLEAR_2))
                    {
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(true, (int)EN_DIGITAL_OUT.LD_1_ALARM_CLEAR_2);
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(true, (int)EN_DIGITAL_OUT.LD_2_ALARM_CLEAR_2);
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(true, (int)EN_DIGITAL_OUT.LD_3_ALARM_CLEAR_2);
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(true, (int)EN_DIGITAL_OUT.MONITOR_ALARM_CLEAR_2);
                    }
                    else
                    {
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(false, (int)EN_DIGITAL_OUT.LD_1_ALARM_CLEAR_2);
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(false, (int)EN_DIGITAL_OUT.LD_2_ALARM_CLEAR_2);
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(false, (int)EN_DIGITAL_OUT.LD_3_ALARM_CLEAR_2);
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(false, (int)EN_DIGITAL_OUT.MONITOR_ALARM_CLEAR_2);
                    }
                    break;

                case 1://EMO
                    if (!FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().ReadItem(false, (int)EN_DIGITAL_OUT.LD_1_EMO_2)
                        || !FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().ReadItem(false, (int)EN_DIGITAL_OUT.LD_2_EMO_2)
                        || !FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().ReadItem(false, (int)EN_DIGITAL_OUT.LD_3_EMO_2)
                        || !FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().ReadItem(false, (int)EN_DIGITAL_OUT.MONITOR_EMO_2))
                    {
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(true, (int)EN_DIGITAL_OUT.LD_1_EMO_2);
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(true, (int)EN_DIGITAL_OUT.LD_2_EMO_2);
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(true, (int)EN_DIGITAL_OUT.LD_3_EMO_2);
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(true, (int)EN_DIGITAL_OUT.MONITOR_EMO_2);
                    }
                    else
                    {
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(false, (int)EN_DIGITAL_OUT.LD_1_EMO_2);
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(false, (int)EN_DIGITAL_OUT.LD_2_EMO_2);
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(false, (int)EN_DIGITAL_OUT.LD_3_EMO_2);
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(false, (int)EN_DIGITAL_OUT.MONITOR_EMO_2);
                    }
                    break;
            }
        }
        #endregion </INTERNAL>

        private void ClickParameterUndo(object sender, EventArgs e)
        {
            if(m_MessageBox.ShowMessage("Do You Want To Undo Recipe?"))
                m_instanceRecipe.ClearDeferredStorage();

            UpdateParamter();
        }

        private void ClickParameterSave(object sender, EventArgs e)
        {
            if (m_MessageBox.ShowMessage("Do You Want To Save Recipe?"))
                m_instanceRecipe.ApplyDeferredStorage();

            UpdateParamter();

            UpdatePowerLabel();
            UpdatePowerLabel_2();
        }

        private void UpdateParamter()
        {
            gridViewControl_Enable_Parameter.UpdateValue();
            gridViewControl_Laser_Parameter.UpdateValue();
            gridViewControl_Enable_Parameter_2.UpdateValue();
            gridViewControl_Laser_Parameter_2.UpdateValue();
        }

        private void UpdatePowerLabel()
        {
            double[] arChPower = new double[5];
            double[] arSidePower = new double[5];
            double[] arTotalPower = new double[5];

            bool[] arUsed = new bool[Laser.ProtecLaserMananger.GetInstance().ChannelCount];
            //double dSidePercent = m_instanceRecipe.GetValue(EN_TASK_LIST.BOND_HEAD.ToString(), BONDER_TASK_PARAM.SIDE_POWER_PERCENT.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
            int[] arSideCh = new int[] { 0, 8, 9, 17 };

            for (int nCh = 0; nCh < Laser.ProtecLaserMananger.GetInstance().ChannelCount; ++nCh)
            {
                arUsed[nCh] = m_instanceRecipe.GetValue(EN_TASK_LIST.BOND_HEAD.ToString(), BONDER_TASK_PARAM.SHOT_PARAMETER_ENABLE_18.ToString(), nCh, EN_RECIPE_PARAM_TYPE.VALUE, false);
            }

            double nUsedChannelCount = 0;
            // int nSideChCount = 0;
            for (int nIndex = 0; nIndex < Laser.ProtecLaserMananger.GetInstance().ChannelCount; nIndex++)
            {
                if (arUsed[nIndex])
                {
                    nUsedChannelCount++;
                    //                     if (arSideCh.Contains(nIndex))
                    //                     {
                    //                         nSideChCount++;
                    //                     }
                }
            }
        }
        private void UpdatePowerLabel_2()
        {
            double[] arChPower = new double[5];
            double[] arSidePower = new double[5];
            double[] arTotalPower = new double[5];

            bool[] arUsed = new bool[Laser.ProtecLaserMananger_2.GetInstance().ChannelCount];
            //double dSidePercent = m_instanceRecipe.GetValue(EN_TASK_LIST.BOND_HEAD.ToString(), BONDER_TASK_PARAM.SIDE_POWER_2_PERCENT.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
            int[] arSideCh = new int[] { 0, 8, 9, 17 };

            for (int nCh = 0; nCh < Laser.ProtecLaserMananger_2.GetInstance().ChannelCount; ++nCh)
            {
                arUsed[nCh] = m_instanceRecipe.GetValue(EN_TASK_LIST.BOND_HEAD.ToString(), BONDER_TASK_PARAM.SHOT_PARAMETER_2_ENABLE_18.ToString(), nCh, EN_RECIPE_PARAM_TYPE.VALUE, false);
            }

            double nUsedChannelCount = 0;
            // int nSideChCount = 0;
            for (int nIndex = 0; nIndex < Laser.ProtecLaserMananger_2.GetInstance().ChannelCount; nIndex++)
            {
                if (arUsed[nIndex])
                {
                    nUsedChannelCount++;
                    //                     if (arSideCh.Contains(nIndex))
                    //                     {
                    //                         nSideChCount++;
                    //                     }
                }
            }
        }
        #region Cal Table Grid & Power Measure Grid
        private void Click_CalFileLoad(object sender, EventArgs e)
        {
            m_instanceFile.DefaultExt = Define.DefineConstant.FileFormat.FILEFORMAT_CALIBRATION;
            m_instanceFile.InitialDirectory = Define.DefineConstant.FilePath.FILEPATH_CALIBRATION_LASER;

            if (m_instanceFile.ShowDialog() == DialogResult.Cancel)
                return;

           string strFullFileName = m_instanceFile.FileName;
           string[] arFileName = strFullFileName.Split('\\');
           string strFileName = arFileName[arFileName.Length - 1].Split('.')[0];
            string strFileRoot = string.Join("\\", arFileName.Take(arFileName.Length - 1));
            m_LaserCalManager.ModifyChannelCalibrationFile(ComboBox_Channel.SelectedIndex, strFileRoot, strFileName);

            UpdatePowerTable();
        }
        private void Click_CalFileLoad_2(object sender, EventArgs e)
        {
            m_instanceFile.DefaultExt = Define.DefineConstant.FileFormat.FILEFORMAT_CALIBRATION;
            m_instanceFile.InitialDirectory = Define.DefineConstant.FilePath.FILEPATH_CALIBRATION_LASER;

            if (m_instanceFile.ShowDialog() == DialogResult.Cancel)
                return;

            string strFullFileName = m_instanceFile.FileName;
            string[] arFileName = strFullFileName.Split('\\');
            string strFileName = arFileName[arFileName.Length - 1].Split('.')[0];
            string strFileRoot = string.Join("\\", arFileName.Take(arFileName.Length - 1));
            m_LaserCalManager_2.ModifyChannelCalibrationFile(ComboBox_Channel_2.SelectedIndex, strFileRoot, strFileName);

            UpdatePowerTable_2();
        }
        private void UpdatePowerTable()
        {
            m_lblCalFileName.Text = m_LaserCalManager.CalibrationChannelFileName(ComboBox_Channel.SelectedIndex);
            m_dgViewCalibration.Rows.Clear();
            foreach (var kvp in m_LaserCalManager.CalibrationDatas(ComboBox_Channel.SelectedIndex))
            {
                m_dgViewCalibration.Rows.Add();
                m_dgViewCalibration[(int)EN_GRID_INDEX.INDEX, kvp.Key].Value = kvp.Key;
                m_dgViewCalibration[(int)EN_GRID_INDEX.VOLT, kvp.Key].Value = kvp.Value.TargetVolt;
                m_dgViewCalibration[(int)EN_GRID_INDEX.OUTPUT_POWER, kvp.Key].Value = kvp.Value.PowerOutputWatt;
                m_dgViewCalibration[(int)EN_GRID_INDEX.INPUT_VOLT, kvp.Key].Value = kvp.Value.PowerInputVolt;
            }
        }
        private void UpdatePowerTable_2()
        {
            m_lblCalFileName_2.Text = m_LaserCalManager_2.CalibrationChannelFileName(ComboBox_Channel_2.SelectedIndex);
            m_dgViewCalibration_2.Rows.Clear();
            foreach (var kvp in m_LaserCalManager_2.CalibrationDatas(ComboBox_Channel_2.SelectedIndex))
            {
                m_dgViewCalibration_2.Rows.Add();
                m_dgViewCalibration_2[(int)EN_GRID_INDEX_2.INDEX, kvp.Key].Value = kvp.Key;
                m_dgViewCalibration_2[(int)EN_GRID_INDEX_2.VOLT, kvp.Key].Value = kvp.Value.TargetVolt_2;
                m_dgViewCalibration_2[(int)EN_GRID_INDEX_2.OUTPUT_POWER, kvp.Key].Value = kvp.Value.PowerOutputWatt_2;
                m_dgViewCalibration_2[(int)EN_GRID_INDEX_2.INPUT_VOLT, kvp.Key].Value = kvp.Value.PowerInputVolt_2;
            }
        }
        private void ComboBox_Channel_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePowerTable();
        }
        private void ComboBox_Channel_SelectedIndexChanged_2(object sender, EventArgs e)
        {
            UpdatePowerTable_2();
        }
        private void m_dgViewCalibration_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int nRowindex = e.RowIndex;
            int nColumnIndex = e.ColumnIndex;

            if (nRowindex < 0
                || nRowindex >= m_dgViewCalibration.RowCount) { return; }

            double dWriteValue = 0;

            switch (nColumnIndex)
            {
                case 1: //output volt
                    if (_Calculator_Instance_m_p.CreateForm(m_dgViewCalibration[nColumnIndex, nRowindex].ToString(), "0", "5000"))
                    {
                        _Calculator_Instance_m_p.GetResult(ref dWriteValue);
                        ProtecLaserChannelCalibration.GetInstance().UpdateCalibrationInformation(ComboBox_Channel.SelectedIndex, nRowindex, (int)EN_CALIBRATION_INDEX.TARGET_VOLT, dWriteValue);
                    }
                    break;

                case 2: //Input Volt
                    if (_Calculator_Instance_m_p.CreateForm(m_dgViewCalibration[nColumnIndex, nRowindex].ToString(), "0", "5000"))
                    {
                        _Calculator_Instance_m_p.GetResult(ref dWriteValue);
                        ProtecLaserChannelCalibration.GetInstance().UpdateCalibrationInformation(ComboBox_Channel.SelectedIndex, nRowindex, (int)EN_CALIBRATION_INDEX.POWER_INPUT_VOLT, dWriteValue);
                    }
                    break;

                case 3: //output watt
                    if (_Calculator_Instance_m_p.CreateForm(m_dgViewCalibration[nColumnIndex, nRowindex].ToString(), "0", "5000"))
                    {
                        _Calculator_Instance_m_p.GetResult(ref dWriteValue);
                        ProtecLaserChannelCalibration.GetInstance().UpdateCalibrationInformation(ComboBox_Channel.SelectedIndex, nRowindex, (int)EN_CALIBRATION_INDEX.POWER_OUTPUT_WATT, dWriteValue);
                    }

                    break;
            }

            UpdatePowerTable();
            SetPowerMinMax();
        }
        private void m_dgViewCalibration_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {
            int nRowindex = e.RowIndex;
            int nColumnIndex = e.ColumnIndex;

            if (nRowindex < 0
                || nRowindex >= m_dgViewCalibration_2.RowCount) { return; }

            double dWriteValue = 0;

            switch (nColumnIndex)
            {
                case 1: //output volt
                    if (_Calculator_Instance_m_p.CreateForm(m_dgViewCalibration_2[nColumnIndex, nRowindex].ToString(), "0", "5000"))
                    {
                        _Calculator_Instance_m_p.GetResult(ref dWriteValue);
                        ProtecLaserChannelCalibration_2.GetInstance().UpdateCalibrationInformation(ComboBox_Channel_2.SelectedIndex, nRowindex, (int)EN_CALIBRATION_INDEX_2.TARGET_VOLT, dWriteValue);
                    }
                    break;

                case 2: //Input Volt
                    if (_Calculator_Instance_m_p.CreateForm(m_dgViewCalibration_2[nColumnIndex, nRowindex].ToString(), "0", "5000"))
                    {
                        _Calculator_Instance_m_p.GetResult(ref dWriteValue);
                        ProtecLaserChannelCalibration_2.GetInstance().UpdateCalibrationInformation(ComboBox_Channel_2.SelectedIndex, nRowindex, (int)EN_CALIBRATION_INDEX_2.POWER_INPUT_VOLT, dWriteValue);
                    }
                    break;

                case 3: //output watt
                    if (_Calculator_Instance_m_p.CreateForm(m_dgViewCalibration_2[nColumnIndex, nRowindex].ToString(), "0", "5000"))
                    {
                        _Calculator_Instance_m_p.GetResult(ref dWriteValue);
                        ProtecLaserChannelCalibration_2.GetInstance().UpdateCalibrationInformation(ComboBox_Channel_2.SelectedIndex, nRowindex, (int)EN_CALIBRATION_INDEX_2.POWER_OUTPUT_WATT, dWriteValue);
                    }

                    break;
            }

            UpdatePowerTable_2();
            SetPowerMinMax_2();
        }
        private void InitGridPowerMesureParameter()
        {
            List<GridViewControl_Parameter.ParameterItem> parameterList = new List<GridViewControl_Parameter.ParameterItem>();

            GridViewControl_Parameter.ParameterItem AddParaItem;

            AddParaItem = new GridViewControl_Parameter.ParameterItem
                (EN_TASK_LIST.BOND_HEAD, BONDER_TASK_PARAM.POWER_MEASURE_SELLECTED_CHANNEL.ToString());
            AddParaItem.DisplayName = "SELLECT CH";
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem
                (EN_TASK_LIST.BOND_HEAD, BONDER_TASK_PARAM.POWER_MEASURE_WATT.ToString());
            AddParaItem.DisplayName = "TARGET WATT";
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem
                (EN_TASK_LIST.BOND_HEAD, BONDER_TASK_PARAM.POWER_MEASURE_VOLT.ToString());
            AddParaItem.DisplayName = "TARGET VOLT";
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem
                (EN_TASK_LIST.BOND_HEAD, BONDER_TASK_PARAM.POWER_MEASURE_SHOT_TIME.ToString());
            AddParaItem.DisplayName = "LASER TIME";
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem
                (EN_TASK_LIST.BOND_HEAD, BONDER_TASK_PARAM.POWER_MEASURE_WAIT_TIME.ToString());
            AddParaItem.DisplayName = "WAIT TIME";
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem
                (EN_TASK_LIST.BOND_HEAD, BONDER_TASK_PARAM.POWER_MEASURE_REPEAT_COUNT.ToString());
            AddParaItem.DisplayName = "REPEAT COUNT";
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem
                (EN_TASK_LIST.BOND_HEAD, BONDER_TASK_PARAM.POWER_MEASURE_REST_TIME.ToString());
            AddParaItem.DisplayName = "REST TIME";
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem
                (EN_TASK_LIST.BOND_HEAD, BONDER_TASK_PARAM.POWER_CALIBRATION_MIN_VOLT.ToString());
            AddParaItem.DisplayName = "CAL START VOLT";
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem
                (EN_TASK_LIST.BOND_HEAD, BONDER_TASK_PARAM.POWER_CALIBRATION_MAX_VOLT.ToString());
            AddParaItem.DisplayName = "CAL END VOLT";
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem
                (EN_TASK_LIST.BOND_HEAD, BONDER_TASK_PARAM.POWER_CALIBRATION_STEP_COUNT.ToString());
            AddParaItem.DisplayName = "CAL STEP";
            parameterList.Add(AddParaItem);

            gridViewControl_Power_Measure_Parameter.Initialize(parameterList, -1, 80);
        }
        private void InitGridPowerMesureParameter_2()
        {
            List<GridViewControl_Parameter.ParameterItem> parameterList = new List<GridViewControl_Parameter.ParameterItem>();

            GridViewControl_Parameter.ParameterItem AddParaItem;

            AddParaItem = new GridViewControl_Parameter.ParameterItem
                (EN_TASK_LIST.BOND_HEAD, BONDER_TASK_PARAM.POWER_MEASURE_2_SELLECTED_CHANNEL.ToString());
            AddParaItem.DisplayName = "SELLECT CH";
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem
                (EN_TASK_LIST.BOND_HEAD, BONDER_TASK_PARAM.POWER_MEASURE_2_WATT.ToString());
            AddParaItem.DisplayName = "TARGET WATT";
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem
                (EN_TASK_LIST.BOND_HEAD, BONDER_TASK_PARAM.POWER_MEASURE_2_VOLT.ToString());
            AddParaItem.DisplayName = "TARGET VOLT";
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem
                (EN_TASK_LIST.BOND_HEAD, BONDER_TASK_PARAM.POWER_MEASURE_2_SHOT_TIME.ToString());
            AddParaItem.DisplayName = "LASER TIME";
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem
                (EN_TASK_LIST.BOND_HEAD, BONDER_TASK_PARAM.POWER_MEASURE_2_WAIT_TIME.ToString());
            AddParaItem.DisplayName = "WAIT TIME";
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem
                (EN_TASK_LIST.BOND_HEAD, BONDER_TASK_PARAM.POWER_MEASURE_2_REPEAT_COUNT.ToString()); 
            AddParaItem.DisplayName = "REPEAT COUNT";
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem
                (EN_TASK_LIST.BOND_HEAD, BONDER_TASK_PARAM.POWER_MEASURE_2_REST_TIME.ToString());
            AddParaItem.DisplayName = "REST TIME";
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem
                (EN_TASK_LIST.BOND_HEAD, BONDER_TASK_PARAM.POWER_CALIBRATION_2_MIN_VOLT.ToString());
            AddParaItem.DisplayName = "CAL START VOLT";
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem
                (EN_TASK_LIST.BOND_HEAD, BONDER_TASK_PARAM.POWER_CALIBRATION_2_MAX_VOLT.ToString());
            AddParaItem.DisplayName = "CAL END VOLT";
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem
                (EN_TASK_LIST.BOND_HEAD, BONDER_TASK_PARAM.POWER_CALIBRATION_2_STEP_COUNT.ToString());
            AddParaItem.DisplayName = "CAL STEP";
            parameterList.Add(AddParaItem);

            gridViewControl_Power_Measure_Parameter_2.Initialize(parameterList, -1, 80);
        }
        #endregion
    }
}