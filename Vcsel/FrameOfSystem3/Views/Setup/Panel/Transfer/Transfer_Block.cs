using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

using Define.DefineEnumProject.Motion;
using Define.DefineEnumProject.Cylinder;
using Define.DefineEnumProject.AnalogIO;
using Define.DefineEnumProject.DigitalIO;
using Define.DefineEnumProject.Task;

using FrameOfSystem3.Component;
using FrameOfSystem3.Recipe;
using FrameOfSystem3.Functional;
using FrameOfSystem3.Laser;
using ZedGraph;

using EQUIPMENT_PARAM = FrameOfSystem3.Recipe.PARAM_EQUIPMENT;
using BONDER_TASK_PARAM = Define.DefineEnumProject.Task.BondHead.PARAM_PROCESS;
using WORKZONE_TASK_PARAM = Define.DefineEnumProject.Task.WorkZone.PARAM_PROCESS;
using TRANSFER_TASK_PARAM = Define.DefineEnumProject.Task.Transfer.PARAM_PROCESS;
using Define.DefineEnumProject.Mail;

using RecipeManager_;

namespace FrameOfSystem3.Views.Setup.Transfer
{
    public partial class Transfer_Block : UserControl, ISetupPanel
    {
        #region Consturct
        public Transfer_Block()
        {
            this.DoubleBuffered = true;

            InitializeComponent();
       
			#region DescriptionEvent
			#endregion

			#region Instance
			_Calculator_Instance_m_p			= Functional.Form_Calculator.GetInstance();
			_Keyboard_Instance_m_p				= Functional.Form_Keyboard.GetInstance();
			_MessageBox_Instance_m_p			= Functional.Form_MessageBox.GetInstance();

            m_instanceRecipe                    = FrameOfSystem3.Recipe.Recipe.GetInstance();
			#endregion

            InitalizeHandlerGridVeiw();
            InitalizeBlockGridVeiw();
		}
        #endregion

		#region Constants
        private readonly Color c_clrLebel = Color.SteelBlue;
        private readonly Color c_clrTrue = Color.Green;
        private readonly Color c_clrFalse = Color.White;
		#endregion

		#region Variable

		#region Information

		#endregion

		#region Instance
		private Functional.Form_MessageBox _MessageBox_Instance_m_p		= null;
        private Functional.Form_Keyboard _Keyboard_Instance_m_p			= null;
		private Functional.Form_Calculator _Calculator_Instance_m_p		= null;

        private FrameOfSystem3.Recipe.Recipe m_instanceRecipe = null;
        #endregion

		#endregion

		#region Override Interface
		public void Activation()
        {
			this.Show();
            gridViewControl_Handler_Parameter.UpdateValue();
            gridViewControl_Block_Parameter.UpdateValue();
            gridViewControl_Handler_Position_Parameter.UpdateValue();
            gridViewControl_Handler_2Axis_Position_Parameter.UpdateValue();
            gridViewControl_Block_Position_Parameter.UpdateValue();
            gridViewControl_Block_2Axis_Position_Parameter.UpdateValue();
        }
        public void Deactivation()
        {
			this.Hide();
        }
        public void CallFunction()
        {
            gridVeiwControl_Handler_Device.UpdateState();
            gridVeiwControl_Block_Device.UpdateState();
        }
        #endregion

        #region Internal Interface

        #region initComponent
        private void InitalizeHandlerGridVeiw()
        {
            #region Parameter Grid
            List<GridViewControl_Parameter.ParameterItem> parameterList = new List<GridViewControl_Parameter.ParameterItem>();

            GridViewControl_Parameter.ParameterItem AddParaItem;

            List<string> AddParaList;

            AddParaList = new List<string>();
            AddParaList.Add(Define.DefineEnumProject.Task.Transfer.PARAM_PROCESS.HANDLER_MATERIAL_VAC_THRESHOLD.ToString());
            AddParaItem = new GridViewControl_Parameter.ParameterItem(EN_TASK_LIST.TRANSFER, AddParaList);
            parameterList.Add(AddParaItem);

            AddParaList = new List<string>();
            AddParaList.Add(Define.DefineEnumProject.Task.Transfer.PARAM_PROCESS.HANDLER_MATERIAL_VAC_ON_DELAY.ToString());
            AddParaItem = new GridViewControl_Parameter.ParameterItem(EN_TASK_LIST.TRANSFER, AddParaList);
            parameterList.Add(AddParaItem);

            AddParaList = new List<string>();
            AddParaList.Add(Define.DefineEnumProject.Task.Transfer.PARAM_PROCESS.HANDLER_MATERIAL_VAC_OFF_DELAY.ToString());
            AddParaItem = new GridViewControl_Parameter.ParameterItem(EN_TASK_LIST.TRANSFER, AddParaList);
            parameterList.Add(AddParaItem);
// 
//             AddParaList = new List<string>();
//             AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.HANDLER_Z_MATERIAL_CONTACT_SPEED);
//             parameterList.Add(AddParaItem);
// 
//             AddParaList = new List<string>();
//             AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.HANDLER_Z_MATERIAL_HANDLE_SPEED);
//             parameterList.Add(AddParaItem);

            gridViewControl_Handler_Parameter.Initialize(parameterList, -1, 150);

            List<string> HeaderList = new List<string>();
            #endregion /Parameter Grid

            #region 2Axis Position Parameter Grid

            List<GridViewControl_2Axis_Position_Parameter.ControlItem> PositionParamList2Axis = new List<GridViewControl_2Axis_Position_Parameter.ControlItem>();

            GridViewControl_2Axis_Position_Parameter.ControlItem AddPositionParam2Axis;


            AddPositionParam2Axis = new GridViewControl_2Axis_Position_Parameter.ControlItem(EN_TASK_LIST.TRANSFER, TRANSFER_TASK_PARAM.HANDLER_WORKBLOCK_TRANSFER_POSITION_X.ToString(), (int)EN_AXIS.HANDLER_X
                                                                                                    , TRANSFER_TASK_PARAM.HANDLER_WORKBLOCK_TRANSFER_POSITION_Y.ToString(), (int)EN_AXIS.HANDLER_Y);
            AddPositionParam2Axis.DisplayName = "TRANSFER";
            AddPositionParam2Axis.FirstAxisName = "X";
            AddPositionParam2Axis.SecondAxisName = "Y";
            PositionParamList2Axis.Add(AddPositionParam2Axis);

            gridViewControl_Handler_2Axis_Position_Parameter.Initialize(PositionParamList2Axis, -1, 30);
            #endregion /2Axis Position Parameter Grid

            #region Position Parameter Grid
            List<GridViewControl_Position_Parameter.ControlItem> PositionParamList = new List<GridViewControl_Position_Parameter.ControlItem>();

            GridViewControl_Position_Parameter.ControlItem AddPositionParam;

            AddPositionParam = new GridViewControl_Position_Parameter.ControlItem(EQUIPMENT_PARAM.HANDLER_WORK_BLOCK_AVOID_POSITION_X, (int)EN_AXIS.HANDLER_X);
            AddPositionParam.DisplayName = "AVOID";
            AddPositionParam.AxisName = "HANDLER X";
            PositionParamList.Add(AddPositionParam);

            AddPositionParam = new GridViewControl_Position_Parameter.ControlItem(EN_TASK_LIST.TRANSFER, TRANSFER_TASK_PARAM.HANDLER_WORKBLOCK_TRANSFER_UP_POSITION_Z.ToString(), (int)EN_AXIS.HANDLER_Z);
            AddPositionParam.DisplayName = "UP";
            AddPositionParam.AxisName = "HANDLER Z";
            PositionParamList.Add(AddPositionParam);

            AddPositionParam = new GridViewControl_Position_Parameter.ControlItem(EN_TASK_LIST.TRANSFER, TRANSFER_TASK_PARAM.HANDLER_WORKBLOCK_TRANSFER_CONTACT_POSITION_Z.ToString(), (int)EN_AXIS.HANDLER_Z);
            AddPositionParam.DisplayName = "CONTACT";
            AddPositionParam.AxisName = "HANDLER Z";
            PositionParamList.Add(AddPositionParam);

            AddPositionParam = new GridViewControl_Position_Parameter.ControlItem(EN_TASK_LIST.TRANSFER, TRANSFER_TASK_PARAM.HANDLER_WORKBLOCK_TRANSFER_DOWN_POSITION_Z.ToString(), (int)EN_AXIS.HANDLER_Z);
            AddPositionParam.DisplayName = "DOWN";
            AddPositionParam.AxisName = "HANDLER Z";
            PositionParamList.Add(AddPositionParam);

            AddPositionParam = new GridViewControl_Position_Parameter.ControlItem(EN_TASK_LIST.TRANSFER, TRANSFER_TASK_PARAM.HANDLER_WORKBLOCK_TRANSFER_POSITION_R.ToString(), (int)EN_AXIS.HANDLER_R);
            AddPositionParam.DisplayName = "TRANSFER";
            AddPositionParam.AxisName = "HANDLER R";
            PositionParamList.Add(AddPositionParam);

            AddPositionParam = new GridViewControl_Position_Parameter.ControlItem(EQUIPMENT_PARAM.HANDLER_WORK_BLOCK_AVOID_POSITION_R, (int)EN_AXIS.HANDLER_R);
            AddPositionParam.DisplayName = "AVOID";
            AddPositionParam.AxisName = "HANDLER R";
            PositionParamList.Add(AddPositionParam);

            gridViewControl_Handler_Position_Parameter.Initialize(PositionParamList, -1, 120);
            #endregion /Position Parameter Grid

            #region Device

            List<GridVeiwControl_Device.ControlItem> ControlList = new List<GridVeiwControl_Device.ControlItem>();

            GridVeiwControl_Device.ControlItem AddControlItem;

            AddControlItem = new GridVeiwControl_Device.ControlItem((int)EN_DIGITAL_OUT.HANDLER_MATERIAL_VAC, GridVeiwControl_Device.EN_CONTROL_TYPE.DIGITAL_OUTPUT);
            ControlList.Add(AddControlItem);
            AddControlItem = new GridVeiwControl_Device.ControlItem((int)EN_DIGITAL_OUT.HANDLER_MATERIAL_BLOW, GridVeiwControl_Device.EN_CONTROL_TYPE.DIGITAL_OUTPUT);
            ControlList.Add(AddControlItem);

            AddControlItem = new GridVeiwControl_Device.ControlItem((int)EN_ANALOG_IN.HANDLER_MATERIAL_VAC, GridVeiwControl_Device.EN_CONTROL_TYPE.ANALOG_INPUT_VALUE);
            AddControlItem.AnalogUnit = "kPa";
            ControlList.Add(AddControlItem);

            gridVeiwControl_Handler_Device.Initialize(ControlList);
            #endregion /Device
        }

        private void InitalizeBlockGridVeiw()
        {
            #region 2Axis Position Parameter Grid

            List<GridViewControl_2Axis_Position_Parameter.ControlItem> PositionParamList2Axis = new List<GridViewControl_2Axis_Position_Parameter.ControlItem>();

            GridViewControl_2Axis_Position_Parameter.ControlItem AddPositionParam2Axis;

            AddPositionParam2Axis = new GridViewControl_2Axis_Position_Parameter.ControlItem(EN_TASK_LIST.WORK_ZONE, WORKZONE_TASK_PARAM.BLOCK_WARPAGE_PRESS_POSITION_X.ToString(), (int)EN_AXIS.BLOCK_X
                                                                                                           , WORKZONE_TASK_PARAM.HEAD_WARPAGE_PRESS_POSITION_Y.ToString(), (int)EN_AXIS.GANTRY_Y);
            AddPositionParam2Axis.DisplayName = "WARPAGE PRESS";
            AddPositionParam2Axis.FirstAxisName = "X";
            AddPositionParam2Axis.SecondAxisName = "Y";
            AddPositionParam2Axis.ParameterIndex = 0;
            PositionParamList2Axis.Add(AddPositionParam2Axis);

            gridViewControl_Block_2Axis_Position_Parameter.Initialize(PositionParamList2Axis, -1, 30);
            #endregion /2Axis Position Parameter Grid

            #region Position Parameter Grid
            List<GridViewControl_Position_Parameter.ControlItem> PositionParamList = new List<GridViewControl_Position_Parameter.ControlItem>();

            GridViewControl_Position_Parameter.ControlItem AddPositionParam;

            AddPositionParam = new GridViewControl_Position_Parameter.ControlItem(EN_TASK_LIST.WORK_ZONE, WORKZONE_TASK_PARAM.BLOCK_TRANSFER_POSITION_X.ToString(), (int)EN_AXIS.BLOCK_X);
            AddPositionParam.DisplayName = "TRANSFER";
            AddPositionParam.AxisName = "BLOCK X";
            PositionParamList.Add(AddPositionParam);

            AddPositionParam = new GridViewControl_Position_Parameter.ControlItem(EN_TASK_LIST.WORK_ZONE, WORKZONE_TASK_PARAM.BLOCK_TRANSFER_POSITION_Z.ToString(), (int)EN_AXIS.BLOCK_Z);
            AddPositionParam.DisplayName = "TRANSFER";
            AddPositionParam.AxisName = "BLOCK Z";
            PositionParamList.Add(AddPositionParam);

            AddPositionParam = new GridViewControl_Position_Parameter.ControlItem(EN_TASK_LIST.WORK_ZONE, WORKZONE_TASK_PARAM.BLOCK_READY_POSITION_Z.ToString(), (int)EN_AXIS.BLOCK_Z);
            AddPositionParam.DisplayName = "READY";
            AddPositionParam.AxisName = "BLOCK Z";
            PositionParamList.Add(AddPositionParam);

            AddPositionParam = new GridViewControl_Position_Parameter.ControlItem(EN_TASK_LIST.WORK_ZONE, WORKZONE_TASK_PARAM.LIFT_TRANSFER_POSITION_Z.ToString(), (int)EN_AXIS.LIFT_Z);
            AddPositionParam.DisplayName = "TRANSFER";
            AddPositionParam.AxisName = "LIFT Z";
            PositionParamList.Add(AddPositionParam);

            AddPositionParam = new GridViewControl_Position_Parameter.ControlItem(EN_TASK_LIST.WORK_ZONE, WORKZONE_TASK_PARAM.LIFT_READY_POSITION_Z.ToString(), (int)EN_AXIS.LIFT_Z);
            AddPositionParam.DisplayName = "READY";
            AddPositionParam.AxisName = "LIFT Z";
            PositionParamList.Add(AddPositionParam);

            gridViewControl_Block_Position_Parameter.Initialize(PositionParamList);
            #endregion /Position Parameter Grid

            #region Parameter Grid
            List<GridViewControl_Parameter.ParameterItem> parameterList = new List<GridViewControl_Parameter.ParameterItem>();

            GridViewControl_Parameter.ParameterItem AddParaItem;

            List<string> AddParaList;

            AddParaList = new List<string>();
            AddParaList.Add(Define.DefineEnumProject.Task.WorkZone.PARAM_PROCESS.BLOCK_MATERIAL_VAC_THRESHOLD.ToString());
            AddParaItem = new GridViewControl_Parameter.ParameterItem(EN_TASK_LIST.WORK_ZONE, AddParaList);
            AddParaItem.DisplayName = "BLOCK MATERIAL VAC THRESHOLD";
            parameterList.Add(AddParaItem);

            AddParaList = new List<string>();
            AddParaList.Add(Define.DefineEnumProject.Task.WorkZone.PARAM_PROCESS.BLOCK_MATERIAL_VAC_TIMELAG_DELAY.ToString());
            AddParaItem = new GridViewControl_Parameter.ParameterItem(EN_TASK_LIST.WORK_ZONE, AddParaList);
            AddParaItem.DisplayName = "BLOCK MATERIAL VAC TIMELAG";
            parameterList.Add(AddParaItem);

            AddParaList = new List<string>();
            AddParaList.Add(Define.DefineEnumProject.Task.WorkZone.PARAM_PROCESS.BLOCK_MATERIAL_VAC_ON_DELAY.ToString());
            AddParaItem = new GridViewControl_Parameter.ParameterItem(EN_TASK_LIST.WORK_ZONE, AddParaList);
            AddParaItem.DisplayName = "BLOCK MATERIAL VAC ON DELAY";
            parameterList.Add(AddParaItem);

            AddParaList = new List<string>();
            AddParaList.Add(Define.DefineEnumProject.Task.WorkZone.PARAM_PROCESS.BLOCK_MATERIAL_VAC_OFF_DELAY.ToString());
            AddParaItem = new GridViewControl_Parameter.ParameterItem(EN_TASK_LIST.WORK_ZONE, AddParaList);
            AddParaItem.DisplayName = "BLOCK MATERIAL VAC OFF DELAY";
            parameterList.Add(AddParaItem);

            AddParaList = new List<string>();
            AddParaList.Add(Define.DefineEnumProject.Task.WorkZone.PARAM_PROCESS.LIFT_MATERIAL_VAC_THRESHOLD.ToString());
            AddParaItem = new GridViewControl_Parameter.ParameterItem(EN_TASK_LIST.WORK_ZONE, AddParaList);
            AddParaItem.DisplayName = "LIFT MATERIAL VAC THRESHOLD";
            parameterList.Add(AddParaItem);

            AddParaList = new List<string>();
            AddParaList.Add(Define.DefineEnumProject.Task.WorkZone.PARAM_PROCESS.LIFT_MATERIAL_VAC_ON_DELAY.ToString());
            AddParaItem = new GridViewControl_Parameter.ParameterItem(EN_TASK_LIST.WORK_ZONE, AddParaList);
            AddParaItem.DisplayName = "LIFT MATERIAL VAC ON DELAY";
            parameterList.Add(AddParaItem);

            AddParaList = new List<string>();
            AddParaList.Add(Define.DefineEnumProject.Task.WorkZone.PARAM_PROCESS.LIFT_MATERIAL_VAC_OFF_DELAY.ToString());
            AddParaItem = new GridViewControl_Parameter.ParameterItem(EN_TASK_LIST.WORK_ZONE, AddParaList);
            AddParaItem.DisplayName = "LIFT MATERIAL VAC OFF DELAY";
            parameterList.Add(AddParaItem);

            AddParaList = new List<string>();
            AddParaList.Add(Define.DefineEnumProject.Task.WorkZone.PARAM_PROCESS.WARPAGE_PRESS_USED.ToString());
            AddParaItem = new GridViewControl_Parameter.ParameterItem(EN_TASK_LIST.WORK_ZONE, AddParaList);
            AddParaItem.ParameterSettingType = Define.DefineEnumBase.Component.EN_PARAMETER_SETTING_TYPE.TRUE_FALSE;
            AddParaItem.DisplayName = "WARPAGE PRESS USED";
            parameterList.Add(AddParaItem);

            AddParaList = new List<string>();
            AddParaList.Add(Define.DefineEnumProject.Task.WorkZone.PARAM_PROCESS.WARPAGE_PRESS_TIME.ToString());
            AddParaItem = new GridViewControl_Parameter.ParameterItem(EN_TASK_LIST.WORK_ZONE, AddParaList);
            AddParaItem.DisplayName = "WARPAGE PRESS TIME";
            parameterList.Add(AddParaItem);


            gridViewControl_Block_Parameter.Initialize(parameterList, -1, 150);

            List<string> HeaderList = new List<string>();
            #endregion /Parameter Grid

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

            AddControlItem = new GridVeiwControl_Device.ControlItem((int)EN_DIGITAL_OUT.PLATE_BLOCK_VAC, GridVeiwControl_Device.EN_CONTROL_TYPE.DIGITAL_OUTPUT);
            AddControlItem.Name = "PLATE VAC";
            ControlList.Add(AddControlItem);

            AddControlItem = new GridVeiwControl_Device.ControlItem((int)EN_ANALOG_IN.PLATE_BLOCK_VAC, GridVeiwControl_Device.EN_CONTROL_TYPE.ANALOG_INPUT_VALUE);
            AddControlItem.AnalogUnit = "kPa";
            ControlList.Add(AddControlItem);

            AddControlItem = new GridVeiwControl_Device.ControlItem((int)EN_CYLINDER.WARPAGE_PRESS, GridVeiwControl_Device.EN_CONTROL_TYPE.CYLINDER);
            ControlList.Add(AddControlItem);

            gridVeiwControl_Block_Device.Initialize(ControlList);
            #endregion /Device
        }

        #endregion


        #endregion



    }
}
