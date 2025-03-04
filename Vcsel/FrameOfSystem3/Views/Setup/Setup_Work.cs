using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using EQUIPMENT_PARAM = FrameOfSystem3.Recipe.PARAM_EQUIPMENT;
using BONDER_TASK_PARAM = Define.DefineEnumProject.Task.BondHead.PARAM_PROCESS;
using WORKZONE_TASK_PARAM = Define.DefineEnumProject.Task.WorkZone.PARAM_PROCESS;

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
 
namespace FrameOfSystem3.Views.Setup
{
    public partial class Setup_Work : UserControlForMainView.CustomView
	{
		public Setup_Work()
		{
			InitializeComponent();

            InitalizeBlockGridVeiw();
            InitGridEnableParameter();
            InitWorkPositionGridVeiw();
            InitGridLaserDevice();
            InitGridLaserParameter();
            //InitHeaterGridView();
            InitalizeWorkStatusGridVeiw();
            InitGridPowerMesureParameter();
            ComboBox_Channel.SelectedIndex = 0;

            #region Instance
            _Calculator_Instance_m_p = Functional.Form_Calculator.GetInstance();
            m_LaserCalManager = Laser.ProtecLaserChannelCalibration.GetInstance();
            #endregion
        }

        #region Constants
        private readonly Color c_clrMonitor = Color.LightGray;
        private readonly Color c_clrControl = Color.SteelBlue;
        private readonly Color c_clrTrue = Color.Green;
        private readonly Color c_clrFalse = Color.White;
        #endregion

        #region Enum
        private enum EN_GRID_INDEX
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
        private FileDialog m_instanceFile = new OpenFileDialog();
        private Functional.Form_Calculator _Calculator_Instance_m_p = null;
        #endregion </FIELD>

        #region <OVERRIDE>
        public override void CallFunctionByTimer()
		{
			base.CallFunctionByTimer();
            UpdateAlamCode();
            //UpdateHeaterGridView();
            //UpdateWorkInformation();
            gridVeiwControl_Laser_Device.UpdateState();
            //gridVeiwControl_Block_Device.UpdateState();
            //gridVeiwControl_Head_Device.UpdateState();

            //우선 개별로 하자 label 많아지면 별도 Method
            //if (m_Operator.IsPreHeatingOver())
            //{
            //    m_lblPreHeatingTime.Text = "TIME OVER";
            //}
            //else
            //{
            //    int nPreheatingTime = (int)m_Operator.GetPreHeatingTime() / 1000; //초단위 표시하자

            //    m_lblPreHeatingTime.Text = nPreheatingTime.ToString() + " s";
            //}


		}
		protected override void ProcessWhenActivation()
		{
            base.ProcessWhenActivation();
            UpdateParamter();
//             gridViewControl_Block_Parameter.UpdateValue();
//             gridViewControl_Block_Position_Parameter.UpdateValue();
//             gridViewControl_Enable_Parameter.UpdateValue();
//             gridViewControl_Head_Position_Parameter.UpdateValue();
//             gridViewControl_Laser_Option_Parameter.UpdateValue();
//             gridViewControl_Laser_Parameter.UpdateValue();
//             gridViewControl_WorkStatus_Parameter.UpdateValue();
            UpdatePowerLabel();
            gridViewControl_Power_Measure_Parameter.UpdateValue();

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
        private void InitalizeBlockGridVeiw()
        {
            #region Parameter Grid
            List<GridViewControl_Parameter.ParameterItem> parameterList = new List<GridViewControl_Parameter.ParameterItem>();

            GridViewControl_Parameter.ParameterItem AddParaItem;

            List<string> AddParaList;

            AddParaList = new List<string>();
            AddParaList.Add(Define.DefineEnumProject.Task.WorkZone.PARAM_PROCESS.BLOCK_MATERIAL_VAC_THRESHOLD.ToString());
            AddParaItem = new GridViewControl_Parameter.ParameterItem(EN_TASK_LIST.WORK_ZONE, AddParaList);
            AddParaItem.DisplayName = "BLOCK VAC THRESHOLD";
            parameterList.Add(AddParaItem);

            AddParaList = new List<string>();
            AddParaList.Add(Define.DefineEnumProject.Task.WorkZone.PARAM_PROCESS.BLOCK_MATERIAL_VAC_TIMELAG_DELAY.ToString());
            AddParaItem = new GridViewControl_Parameter.ParameterItem(EN_TASK_LIST.WORK_ZONE, AddParaList);
            AddParaItem.DisplayName = "BLOCK VAC TIMELAG";
            parameterList.Add(AddParaItem);

            AddParaList = new List<string>();
            AddParaList.Add(Define.DefineEnumProject.Task.WorkZone.PARAM_PROCESS.BLOCK_MATERIAL_VAC_ON_DELAY.ToString());
            AddParaItem = new GridViewControl_Parameter.ParameterItem(EN_TASK_LIST.WORK_ZONE, AddParaList);
            AddParaItem.DisplayName = "BLOCK VAC ON DELAY";
            parameterList.Add(AddParaItem);

            AddParaList = new List<string>();
            AddParaList.Add(Define.DefineEnumProject.Task.WorkZone.PARAM_PROCESS.BLOCK_MATERIAL_VAC_OFF_DELAY.ToString());
            AddParaItem = new GridViewControl_Parameter.ParameterItem(EN_TASK_LIST.WORK_ZONE, AddParaList);
            AddParaItem.DisplayName = "BLOCK VAC OFF DELAY";
            parameterList.Add(AddParaItem);


            AddParaList = new List<string>();
            AddParaList.Add(Define.DefineEnumProject.Task.WorkZone.PARAM_PROCESS.HEATER_TARGET_TEMP.ToString());
            AddParaItem = new GridViewControl_Parameter.ParameterItem(EN_TASK_LIST.WORK_ZONE, AddParaList);
            AddParaItem.AfterSetParameter = SetBlockTemp;
            parameterList.Add(AddParaItem);

            AddParaList = new List<string>();
            AddParaList.Add(Define.DefineEnumProject.Task.WorkZone.PARAM_PROCESS.HEATER_OFFSET_TEMP.ToString());
            AddParaItem = new GridViewControl_Parameter.ParameterItem(EN_TASK_LIST.WORK_ZONE, AddParaList);
            AddParaItem.AfterSetParameter = SetBlockOffset;
            parameterList.Add(AddParaItem);

            //gridViewControl_Block_Parameter.Initialize(parameterList, -1, 150);

            List<string> HeaderList = new List<string>();
            #endregion /Parameter Grid

            #region Position Parameter Grid
            List<GridViewControl_Position_Parameter.ControlItem> PositionParamList = new List<GridViewControl_Position_Parameter.ControlItem>();

            GridViewControl_Position_Parameter.ControlItem AddPositionParam;

            AddPositionParam = new GridViewControl_Position_Parameter.ControlItem(EN_TASK_LIST.WORK_ZONE, WORKZONE_TASK_PARAM.BLOCK_WORK_POSITION_Z.ToString(), (int)EN_AXIS.BLOCK_Z);
            AddPositionParam.DisplayName = "BLOCK WORK";
            AddPositionParam.AxisName = "BLOCK Z";
            PositionParamList.Add(AddPositionParam);

            AddPositionParam = new GridViewControl_Position_Parameter.ControlItem(EN_TASK_LIST.WORK_ZONE, WORKZONE_TASK_PARAM.BLOCK_READY_POSITION_Z.ToString(), (int)EN_AXIS.BLOCK_Z);
            AddPositionParam.DisplayName = "BLOCK READY";
            AddPositionParam.AxisName = "BLOCK Z";
            PositionParamList.Add(AddPositionParam);


            //gridViewControl_Block_Position_Parameter.Initialize(PositionParamList, -1, 120);
            #endregion /Position Parameter Grid

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
            AddControlItem.Name = "BLOCK VAC";
            AddControlItem.AnalogUnit = "kPa";
            ControlList.Add(AddControlItem);

            //gridVeiwControl_Block_Device.Initialize(ControlList);
            #endregion /Device
        }

        private void InitGridEnableParameter()
        {
            List<GridViewControl_Parameter.ParameterItem> parameterList = new List<GridViewControl_Parameter.ParameterItem>();

            GridViewControl_Parameter.ParameterItem AddParaItem;
            List<int> lstIndex = new List<int>();
            List<string> lstDisplay = new List<string>();
            List<string> lstParam = new List<string>();
            for (int nCh = Laser.ProtecLaserMananger.GetInstance(0).ChannelCount / 2; nCh < Laser.ProtecLaserMananger.GetInstance(0).ChannelCount; nCh++)
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
            for (int nCh = 0; nCh < Laser.ProtecLaserMananger.GetInstance(0).ChannelCount / 2; nCh++)
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

        private void InitWorkPositionGridVeiw()
        {
            List<GridViewControl_2Axis_Position_Parameter.ControlItem> PositionParamList2Axis = new List<GridViewControl_2Axis_Position_Parameter.ControlItem>();

            GridViewControl_2Axis_Position_Parameter.ControlItem AddPositionParam2Axis;

            AddPositionParam2Axis = new GridViewControl_2Axis_Position_Parameter.ControlItem(EN_TASK_LIST.BOND_HEAD, BONDER_TASK_PARAM.LASER_WORK_POSITION_X.ToString(), (int)EN_AXIS.BLOCK_X
                                                                                                           , BONDER_TASK_PARAM.LASER_WORK_POSITION_Y.ToString(), (int)EN_AXIS.GANTRY_Y);
            AddPositionParam2Axis.DisplayName = "WORK POSITION";
            AddPositionParam2Axis.FirstAxisName = "X";
            AddPositionParam2Axis.SecondAxisName = "Y";
            PositionParamList2Axis.Add(AddPositionParam2Axis);


            AddPositionParam2Axis = new GridViewControl_2Axis_Position_Parameter.ControlItem(EQUIPMENT_PARAM.HEAD_READY_POSITION_X, (int)EN_AXIS.BLOCK_X
                                                                                                           , EQUIPMENT_PARAM.HEAD_READY_POSITION_Y, (int)EN_AXIS.GANTRY_Y);
            AddPositionParam2Axis.DisplayName = "READY POSITION";
            AddPositionParam2Axis.FirstAxisName = "X";
            AddPositionParam2Axis.SecondAxisName = "Y";
            PositionParamList2Axis.Add(AddPositionParam2Axis);

            //gridViewControl_Head_Position_Parameter.Initialize(PositionParamList2Axis, -1, 30);

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
            AddControlItem.Name = "HEAD FLOW";
            AddControlItem.AnalogUnit = "L/min";
            ControlList.Add(AddControlItem);

            //gridVeiwControl_Head_Device.Initialize(ControlList);
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

            AddParaList.Add(BONDER_TASK_PARAM.SHOT_PARAMETER_STEP_POWER_5.ToString());
            AddParaList.Add(BONDER_TASK_PARAM.SHOT_PARAMETER_STEP_POWER_5.ToString());
            AddParaList.Add(BONDER_TASK_PARAM.SHOT_PARAMETER_STEP_POWER_5.ToString());
            AddParaList.Add(BONDER_TASK_PARAM.SHOT_PARAMETER_STEP_POWER_5.ToString());
            AddParaList.Add(BONDER_TASK_PARAM.SHOT_PARAMETER_STEP_POWER_5.ToString());
            GridViewControl_Parameter.ParameterItem AddParaItem = new GridViewControl_Parameter.ParameterItem(EN_TASK_LIST.BOND_HEAD, AddParaList, AddParaIndexList);
            AddParaItem.DisplayName = "LASER POWER";
            parameterList.Add(AddParaItem);

            AddParaList = new List<string>();
            AddParaList.Add(BONDER_TASK_PARAM.SHOT_PARAMETER_STEP_TIME_5.ToString());
            AddParaList.Add(BONDER_TASK_PARAM.SHOT_PARAMETER_STEP_TIME_5.ToString());
            AddParaList.Add(BONDER_TASK_PARAM.SHOT_PARAMETER_STEP_TIME_5.ToString());
            AddParaList.Add(BONDER_TASK_PARAM.SHOT_PARAMETER_STEP_TIME_5.ToString());
            AddParaList.Add(BONDER_TASK_PARAM.SHOT_PARAMETER_STEP_TIME_5.ToString());
            AddParaItem = new GridViewControl_Parameter.ParameterItem(EN_TASK_LIST.BOND_HEAD, AddParaList, AddParaIndexList);
            AddParaItem.DisplayName = "LASER TIME";
            parameterList.Add(AddParaItem);
// 
//             AddParaList = new List<string>();
//             AddParaList.Add(BONDER_TASK_PARAM.TEMPERATURE_SAFTY_AREA_HIGH_LIMIT_5.ToString());
//             AddParaList.Add(BONDER_TASK_PARAM.TEMPERATURE_SAFTY_AREA_HIGH_LIMIT_5.ToString());
//             AddParaList.Add(BONDER_TASK_PARAM.TEMPERATURE_SAFTY_AREA_HIGH_LIMIT_5.ToString());
//             AddParaList.Add(BONDER_TASK_PARAM.TEMPERATURE_SAFTY_AREA_HIGH_LIMIT_5.ToString());
//             AddParaList.Add(BONDER_TASK_PARAM.TEMPERATURE_SAFTY_AREA_HIGH_LIMIT_5.ToString());
//             AddParaItem = new GridViewControl_Parameter.ParameterItem(EN_TASK_LIST.BOND_HEAD, AddParaList, AddParaIndexList);
//             AddParaItem.DisplayName = "PYROMETER HIGH TEMP";
//             parameterList.Add(AddParaItem);
// 
//             AddParaList = new List<string>();
//             AddParaList.Add(BONDER_TASK_PARAM.TEMPERATURE_SAFTY_AREA_LOW_LIMIT_5.ToString());
//             AddParaList.Add(BONDER_TASK_PARAM.TEMPERATURE_SAFTY_AREA_LOW_LIMIT_5.ToString());
//             AddParaList.Add(BONDER_TASK_PARAM.TEMPERATURE_SAFTY_AREA_LOW_LIMIT_5.ToString());
//             AddParaList.Add(BONDER_TASK_PARAM.TEMPERATURE_SAFTY_AREA_LOW_LIMIT_5.ToString());
//             AddParaList.Add(BONDER_TASK_PARAM.TEMPERATURE_SAFTY_AREA_LOW_LIMIT_5.ToString());
//             AddParaItem = new GridViewControl_Parameter.ParameterItem(EN_TASK_LIST.BOND_HEAD, AddParaList, AddParaIndexList);
//             AddParaItem.DisplayName = "PYROMETER LOW TEMP";
//             parameterList.Add(AddParaItem);
// 
//             AddParaList = new List<string>();
//             AddParaList.Add(BONDER_TASK_PARAM.TEMPERATURE_SAFTY_AREA_TIME_5.ToString());
//             AddParaList.Add(BONDER_TASK_PARAM.TEMPERATURE_SAFTY_AREA_TIME_5.ToString());
//             AddParaList.Add(BONDER_TASK_PARAM.TEMPERATURE_SAFTY_AREA_TIME_5.ToString());
//             AddParaList.Add(BONDER_TASK_PARAM.TEMPERATURE_SAFTY_AREA_TIME_5.ToString());
//             AddParaList.Add(BONDER_TASK_PARAM.TEMPERATURE_SAFTY_AREA_TIME_5.ToString());
//             AddParaItem = new GridViewControl_Parameter.ParameterItem(EN_TASK_LIST.BOND_HEAD, AddParaList, AddParaIndexList);
//             AddParaItem.DisplayName = "PYROMETER TIME";
//             parameterList.Add(AddParaItem);

            gridViewControl_Laser_Parameter.Initialize(parameterList, -1, 85);

            List<string>  HeaderList = new List<string>();
            HeaderList.Add("");
            HeaderList.Add("STEP 1");
            HeaderList.Add("STEP 2");
            HeaderList.Add("STEP 3");
            HeaderList.Add("STEP 4");
            HeaderList.Add("STEP 5");
            gridViewControl_Laser_Parameter.ShowHeader(HeaderList);

            parameterList = new List<GridViewControl_Parameter.ParameterItem>();


            AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.LASER_USED);
            AddParaItem.DisplayName = "LASER USED";
            AddParaItem.ParameterSettingType = Define.DefineEnumBase.Component.EN_PARAMETER_SETTING_TYPE.TRUE_FALSE;
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.IR_USED);
            AddParaItem.DisplayName = "IR USED";
            AddParaItem.ParameterSettingType = Define.DefineEnumBase.Component.EN_PARAMETER_SETTING_TYPE.TRUE_FALSE;
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.POWERCHECK_USED);
            AddParaItem.DisplayName = "POWER CHECK USED";
            AddParaItem.ParameterSettingType = Define.DefineEnumBase.Component.EN_PARAMETER_SETTING_TYPE.TRUE_FALSE;
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.POWERCHECK_TOLERANCE);
            AddParaItem.DisplayName = "POWER CHECK TOLERANCE";
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem(EN_TASK_LIST.BOND_HEAD, BONDER_TASK_PARAM.TEMPERATURE_SAVE_PRE_DELAY.ToString());
            AddParaItem.DisplayName = "SAVE PRE DELAY";
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem(EN_TASK_LIST.BOND_HEAD, BONDER_TASK_PARAM.TEMPERATURE_SAVE_POST_DELAY.ToString());
            AddParaItem.DisplayName = "SAVE POST DELAY";
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.HEAD_FLOW_THRESHOLD);
            parameterList.Add(AddParaItem);


            AddParaItem = new GridViewControl_Parameter.ParameterItem(EN_TASK_LIST.BOND_HEAD, BONDER_TASK_PARAM.MATERIAL_COOLING_TIME.ToString());
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem(EN_TASK_LIST.BOND_HEAD, BONDER_TASK_PARAM.MATERIAL_PREHEATING_TIME.ToString());
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem(EN_TASK_LIST.BOND_HEAD, BONDER_TASK_PARAM.SIDE_POWER_PERCENT.ToString());
            parameterList.Add(AddParaItem);

            //gridViewControl_Laser_Option_Parameter.Initialize(parameterList, -1, 85);
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

            //gridViewControl_WorkStatus_Parameter.Initialize(parameterList, 2, 80);

            #endregion /Parameter Grid

        }

        private void Click_Stop(object sender, EventArgs e)
        {
            Task.TaskOperator.GetInstance().SetOperation(RunningMain_.OPERATION_EQUIPMENT.STOP);
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

                case 1:
                    arSelectAction = new string[1][];
                    arSelectTask = new string[] { EN_TASK_LIST.WORK_ZONE.ToString() };
                    arSelectAction[0] = new string[] {Define.DefineEnumProject.Task.WorkZone.EN_TASK_ACTION.MANUAL_LOADING.ToString() };
                    Task.TaskOperator.GetInstance().SetOperation(ref arSelectTask, ref arSelectAction, nRetryTime);
                    break;

                case 2:
                    arSelectAction = new string[1][];
                    arSelectTask = new string[] { EN_TASK_LIST.WORK_ZONE.ToString() };
                    arSelectAction[0] = new string[] {Define.DefineEnumProject.Task.WorkZone.EN_TASK_ACTION.MATERIAL_RELEASE.ToString() };
                    Task.TaskOperator.GetInstance().SetOperation(ref arSelectTask, ref arSelectAction, nRetryTime);
                    break;
            }
        }

        private void SetPowerMinMax()
        {
            bool[] arUsed = new bool[ProtecLaserMananger.GetInstance(0).ChannelCount];
            for (int nCh = 0; nCh < ProtecLaserMananger.GetInstance(0).ChannelCount; ++nCh)
            {
                arUsed[nCh] = m_instanceRecipe.GetValue(EN_TASK_LIST.BOND_HEAD.ToString(), BONDER_TASK_PARAM.SHOT_PARAMETER_ENABLE_18.ToString(), nCh, EN_RECIPE_PARAM_TYPE.VALUE, false);
            }

            for (int nStep = 0; nStep < 5; ++nStep)
            {
                m_instanceRecipe.SetValue(EN_TASK_LIST.BOND_HEAD.ToString(), BONDER_TASK_PARAM.SHOT_PARAMETER_STEP_POWER_5.ToString(), nStep, EN_RECIPE_PARAM_TYPE.MAX, ProtecLaserChannelCalibration.GetInstance().GetMaxPower(arUsed).ToString());
                m_instanceRecipe.SetValue(EN_TASK_LIST.BOND_HEAD.ToString(), BONDER_TASK_PARAM.SHOT_PARAMETER_STEP_POWER_5.ToString(), nStep, EN_RECIPE_PARAM_TYPE.MIN, ProtecLaserChannelCalibration.GetInstance().GetMinPower(arUsed).ToString());
            }
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

        #region Heater
        //private void InitHeaterGridView()
        //{
        //    int nRow = 0;
        //    dataGridView_Heater.Rows.Clear();

        //    dataGridView_Heater.Rows.Add();
        //    dataGridView_Heater[0, nRow].Value = "HEATER ON";
        //    dataGridView_Heater[0, nRow].Style.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
        //    dataGridView_Heater[0, nRow].Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        //    dataGridView_Heater[0, nRow].Style.BackColor = c_clrControl;
        //    dataGridView_Heater[0, nRow].Style.SelectionBackColor = c_clrControl;
        //    nRow++;

        //    dataGridView_Heater.Rows.Add();
        //    dataGridView_Heater[0, nRow].Value = "BLOCK TEMP";
        //    dataGridView_Heater[0, nRow].Style.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
        //    dataGridView_Heater[0, nRow].Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        //    dataGridView_Heater[0, nRow].Style.BackColor = c_clrMonitor;
        //    dataGridView_Heater[0, nRow].Style.SelectionBackColor = c_clrControl;
        //    dataGridView_Heater[1, nRow].Style.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
        //    dataGridView_Heater[1, nRow].Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
        //    nRow++;
        //}

        //private void UpdateHeaterGridView()
        //{
        //    int nRow = 0;
        //    //dataGridView_Heater[0, nRow].Value = "BLOCK HEATER ON";
        //    bool bRun = ExternalDevice.Heater.Heater.GetInstance().GetRunStatus((int)Define.DefineEnumProject.Heater.EN_HEATER_ZONE_LIST.BLCOK, 1);
        //    dataGridView_Heater[1, nRow].Style.BackColor = bRun ? c_clrTrue : c_clrFalse;
        //    dataGridView_Heater[1, nRow].Style.SelectionBackColor = bRun ? c_clrTrue : c_clrFalse;
        //    nRow++;

        //    //dataGridView_Heater[0, nRow].Value = "BLOCK TEMP";
        //    dataGridView_Heater[1, nRow].Value = ExternalDevice.Heater.Heater.GetInstance().GetMeanValue((int)Define.DefineEnumProject.Heater.EN_HEATER_ZONE_LIST.BLCOK) + " ℃";
        //    nRow++;
        //}

        //private void dataGridView_Heater_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    int nRowindex = e.RowIndex;
        //    int nColumnIndex = e.ColumnIndex;

        //    if (nColumnIndex != 1 || nRowindex < 0
        //        || nRowindex >= dataGridView_Heater.RowCount) { return; }

        //    switch (nRowindex)
        //    {
        //        case 0:
        //            bool bRun = ExternalDevice.Heater.Heater.GetInstance().GetRunStatus((int)Define.DefineEnumProject.Heater.EN_HEATER_ZONE_LIST.BLCOK, 1);
        //            ExternalDevice.Heater.Heater.GetInstance().SetRunStatus((int)Define.DefineEnumProject.Heater.EN_HEATER_ZONE_LIST.BLCOK, !bRun);
        //            break;
        //    }
        //}

        private void SetBlockTemp()
        {
            double dTemp = m_instanceRecipe.GetValue(EN_TASK_LIST.WORK_ZONE.ToString(), WORKZONE_TASK_PARAM.HEATER_TARGET_TEMP.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

            ExternalDevice.Heater.Heater.GetInstance().SetTargetTemp((int)Define.DefineEnumProject.Heater.EN_HEATER_ZONE_LIST.BLCOK, dTemp);
        }

        private void SetBlockOffset()
        {
            double dCh1Offset = m_instanceRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.WORK_BLOCK_CH_OFFSET_8.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
            ExternalDevice.Heater.Heater.GetInstance().SetChannelTempOffset((int)Define.DefineEnumProject.Heater.EN_HEATER_ZONE_LIST.BLCOK, 1, dCh1Offset, false);

            double dCh2Offset = m_instanceRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.WORK_BLOCK_CH_OFFSET_8.ToString(), 1, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
            ExternalDevice.Heater.Heater.GetInstance().SetChannelTempOffset((int)Define.DefineEnumProject.Heater.EN_HEATER_ZONE_LIST.BLCOK, 2, dCh2Offset, false);

            double dCh3Offset = m_instanceRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.WORK_BLOCK_CH_OFFSET_8.ToString(), 2, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
            ExternalDevice.Heater.Heater.GetInstance().SetChannelTempOffset((int)Define.DefineEnumProject.Heater.EN_HEATER_ZONE_LIST.BLCOK, 3, dCh3Offset, false);

            double dCh4Offset = m_instanceRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.WORK_BLOCK_CH_OFFSET_8.ToString(), 3, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
            ExternalDevice.Heater.Heater.GetInstance().SetChannelTempOffset((int)Define.DefineEnumProject.Heater.EN_HEATER_ZONE_LIST.BLCOK, 4, dCh4Offset, false);


            double dZoneOffset = m_instanceRecipe.GetValue(EN_TASK_LIST.WORK_ZONE.ToString(), WORKZONE_TASK_PARAM.HEATER_OFFSET_TEMP.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
            ExternalDevice.Heater.Heater.GetInstance().SetTempOffset((int)Define.DefineEnumProject.Heater.EN_HEATER_ZONE_LIST.BLCOK, dZoneOffset);

        }

        #endregion </Heater>

        //private void UpdateWorkInformation()
        //{
        //    m_lblID.Text = Work.WorkMap.GetInstance().GetID();
        //    m_lblWorkStatus.Text = Work.WorkMap.GetInstance().GetWorkStatus().ToString();

        //    Color StatusColor = Color.White;

        //    switch(Work.WorkMap.GetInstance().GetWorkStatus())
        //    {
        //        case EN_WORK_STATUS.WAIT:
        //            StatusColor = Color.FromArgb(m_instanceRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.WAIT_COLOR.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0));
        //            break;

        //        case EN_WORK_STATUS.DONE:
        //            StatusColor = Color.FromArgb(m_instanceRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.DONE_COLOR.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0));
        //            break;

        //        case EN_WORK_STATUS.LOW_TEMP:
        //            StatusColor = Color.FromArgb(m_instanceRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.LOW_TEMP_COLOR.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0));
        //            break;

        //        case EN_WORK_STATUS.TEMP_GROW_FAIL:
        //            StatusColor = Color.FromArgb(m_instanceRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.TEMP_GROW_FAIL_COLOR.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0));
        //            break;

        //        case EN_WORK_STATUS.TEMP_DEVOVER:
        //            StatusColor = Color.FromArgb(m_instanceRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.TEMP_DEVOVER_COLOR.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0));
        //            break;

        //        case EN_WORK_STATUS.HIGH_TEMP:
        //            StatusColor = Color.FromArgb(m_instanceRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.HIGH_TEMP_COLOR.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0));
        //            break;

        //        case EN_WORK_STATUS.MAX_HIGH_TEMP:
        //            StatusColor = Color.FromArgb(m_instanceRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.MAX_HIGH_TEMP_COLOR.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0));
        //            break;

        //        case EN_WORK_STATUS.EMG_LOW_TEMP:
        //            StatusColor = Color.FromArgb(m_instanceRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.EMG_LOW_TEMP_COLOR.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0));
        //            break;

        //        case EN_WORK_STATUS.EMG_HIGH_TEMP:
        //            StatusColor = Color.FromArgb(m_instanceRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.EMG_HIGH_TEMP_COLOR.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0));
        //            break;

        //        case EN_WORK_STATUS.POWER_FAULT:
        //            StatusColor = Color.FromArgb(m_instanceRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.POWER_FAULT_COLOR.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0));
        //            break;

        //        case EN_WORK_STATUS.SOURCE_ALARM:
        //            StatusColor = Color.FromArgb(m_instanceRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.SOURCE_ALARM_COLOR.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0));
        //            break;

        //        case EN_WORK_STATUS.RESULT_GETFAIL:
        //            StatusColor = Color.FromArgb(m_instanceRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.RESULT_GETFAIL_COLOR.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0));
        //            break;
        //    }
        //    m_lblWorkStatus_Color.BackGroundColor = StatusColor;
        //}
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

        }

        private void UpdateParamter()
        {
            //gridViewControl_Block_Parameter.UpdateValue();
            //gridViewControl_Block_Position_Parameter.UpdateValue();
            gridViewControl_Enable_Parameter.UpdateValue();
            //gridViewControl_Head_Position_Parameter.UpdateValue();
            //gridViewControl_Laser_Option_Parameter.UpdateValue();
            gridViewControl_Laser_Parameter.UpdateValue();
            //gridViewControl_WorkStatus_Parameter.UpdateValue();
        }

        private void UpdatePowerLabel()
        {
            double[] arChPower = new double[5];
            double[] arSidePower = new double[5];
            double[] arTotalPower = new double[5];

            bool[] arUsed = new bool[Laser.ProtecLaserMananger.GetInstance(0).ChannelCount];
            double dSidePercent = m_instanceRecipe.GetValue(EN_TASK_LIST.BOND_HEAD.ToString(), BONDER_TASK_PARAM.SIDE_POWER_PERCENT.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
            int[] arSideCh = new int[] { 0, 8, 9, 17 };

            for (int nCh = 0; nCh < Laser.ProtecLaserMananger.GetInstance(0).ChannelCount; ++nCh)
            {
                arUsed[nCh] = m_instanceRecipe.GetValue(EN_TASK_LIST.BOND_HEAD.ToString(), BONDER_TASK_PARAM.SHOT_PARAMETER_ENABLE_18.ToString(), nCh, EN_RECIPE_PARAM_TYPE.VALUE, false);
            }

            double nUsedChannelCount = 0;
           // int nSideChCount = 0;
            for (int nIndex = 0; nIndex < Laser.ProtecLaserMananger.GetInstance(0).ChannelCount; nIndex++)
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

         //   nUsedChannelCount += (dSidePercent / 100 * nSideChCount);

            for (int nStep = 0; nStep < 5; ++nStep)
            {
                double dPower = m_instanceRecipe.GetValue(EN_TASK_LIST.BOND_HEAD.ToString(), BONDER_TASK_PARAM.SHOT_PARAMETER_STEP_POWER_5.ToString(), nStep, EN_RECIPE_PARAM_TYPE.VALUE, 0);
                arChPower[nStep] = Math.Round(dPower / nUsedChannelCount);
                arSidePower[nStep] = Math.Round(arChPower[nStep] * (1 + (dSidePercent / 100)));
            }


            //m_lblChPower.Text = string.Format("[{0} W] [{1} W] [{2} W] [{3} W] [{4} W]", arChPower[0], arChPower[1], arChPower[2], arChPower[3], arChPower[4]);
            //m_lblSidePower.Text = string.Format("[{0} W] [{1} W] [{2} W] [{3} W] [{4} W]", arSidePower[0], arSidePower[1], arSidePower[2], arSidePower[3], arSidePower[4]);
            
            // 검증용 남겨놓음
            //                  int[] arTime = new int[5];
            //             double[] arPower = new double[5];
            //              for (int nStep = 0; nStep < 5; ++nStep)
            //             {
            //                 arTime[nStep] = m_instanceRecipe.GetValue(EN_TASK_LIST.BOND_HEAD.ToString(), BONDER_TASK_PARAM.SHOT_PARAMETER_STEP_TIME_5.ToString(), nStep, EN_RECIPE_PARAM_TYPE.VALUE, 0);
            //                 arPower[nStep] = m_instanceRecipe.GetValue(EN_TASK_LIST.BOND_HEAD.ToString(), BONDER_TASK_PARAM.SHOT_PARAMETER_STEP_POWER_5.ToString(), nStep, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
            //             }
            //              Laser.ProtecLaserMananger.GetInstance(0).SetParameter(arUsed, arPower, arTime, dSidePercent, arSideCh);

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

        private void ComboBox_Channel_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePowerTable();
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
        private void InitGridPowerMesureParameter()
        {
            List<GridViewControl_Parameter.ParameterItem> parameterList = new List<GridViewControl_Parameter.ParameterItem>();

            GridViewControl_Parameter.ParameterItem AddParaItem;

            AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.POWER_MEASURE_SELLECTED_CHANNEL);
            AddParaItem.DisplayName = "SELLECT CH";
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.POWER_MEASURE_WATT);
            AddParaItem.DisplayName = "TARGET WATT";
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.POWER_MEASURE_VOLT);
            AddParaItem.DisplayName = "TARGET VOLT";
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.POWER_MEASURE_SHOT_TIME);
            AddParaItem.DisplayName = "LASER TIME";
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.POWER_MEASURE_WAIT_TIME);
            AddParaItem.DisplayName = "WAIT TIME";
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.POWER_MEASURE_REPEAT_COUNT);
            AddParaItem.DisplayName = "REPEAT COUNT";
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.POWER_MEASURE_REST_TIME);
            AddParaItem.DisplayName = "REST TIME";
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.POWER_CALIBRATION_MIN_VOLT);
            AddParaItem.DisplayName = "CAL START VOLT";
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.POWER_CALIBRATION_MAX_VOLT);
            AddParaItem.DisplayName = "CAL END VOLT";
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.POWER_CALIBRATION_STEP_COUNT);
            AddParaItem.DisplayName = "CAL STEP";
            parameterList.Add(AddParaItem);

            gridViewControl_Power_Measure_Parameter.Initialize(parameterList, -1, 80);
        }
        #endregion
    }
}
