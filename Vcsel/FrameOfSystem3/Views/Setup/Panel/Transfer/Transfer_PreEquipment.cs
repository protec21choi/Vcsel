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
    public partial class Transfer_PreEquipment : UserControl, ISetupPanel
    {
        #region Consturct
        public Transfer_PreEquipment()
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
            gridViewControl_Handler_Position_Parameter.UpdateValue();
            //gridViewControl_Handler_2Axis_Position_Parameter.UpdateValue();
            gridViewControl_Handler_Port1_Position_Parameter.UpdateValue();
            gridViewControl_Handler_Port2_Position_Parameter.UpdateValue();
        }
        public void Deactivation()
        {
			this.Hide();
        }
        public void CallFunction()
        {
            gridVeiwControl_Handler_Device_Port1.UpdateState();
            gridVeiwControl_Handler_Device_Port2.UpdateState();
            gridVeiwControl_Handler_Device.UpdateState();
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
            AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.INPUT_SMEMA_USED);
            AddParaItem.DisplayName = "SMEMA USED";
            AddParaItem.ParameterSettingType = Define.DefineEnumBase.Component.EN_PARAMETER_SETTING_TYPE.TRUE_FALSE;
            parameterList.Add(AddParaItem);

            AddParaList = new List<string>();
            AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.PREEQUIPMENT_WCF_USED);
            AddParaItem.DisplayName = "WCF USED";
            AddParaItem.ParameterSettingType = Define.DefineEnumBase.Component.EN_PARAMETER_SETTING_TYPE.TRUE_FALSE;
            parameterList.Add(AddParaItem);

            AddParaList = new List<string>();
            AddParaList.Add(Define.DefineEnumProject.Task.Transfer.PARAM_PROCESS.HANDLER_MATERIAL_VAC_THRESHOLD.ToString());
            AddParaItem = new GridViewControl_Parameter.ParameterItem(EN_TASK_LIST.TRANSFER, AddParaList);
            AddParaItem.DisplayName = "VAC THRESHOLD";
            parameterList.Add(AddParaItem);

            AddParaList = new List<string>();
            AddParaList.Add(Define.DefineEnumProject.Task.Transfer.PARAM_PROCESS.HANDLER_MATERIAL_VAC_ON_DELAY.ToString());
            AddParaItem = new GridViewControl_Parameter.ParameterItem(EN_TASK_LIST.TRANSFER, AddParaList);
            AddParaItem.DisplayName = "VAC ON DELAY";
            parameterList.Add(AddParaItem);

            AddParaList = new List<string>();
            AddParaList.Add(Define.DefineEnumProject.Task.Transfer.PARAM_PROCESS.HANDLER_MATERIAL_VAC_OFF_DELAY.ToString());
            AddParaItem = new GridViewControl_Parameter.ParameterItem(EN_TASK_LIST.TRANSFER, AddParaList);
            AddParaItem.DisplayName = "VAC OFF DELAY";
            parameterList.Add(AddParaItem);

//             AddParaList = new List<string>();
//             AddParaList.Add(Define.DefineEnumProject.Task.Transfer.PARAM_PROCESS.HANDLER_MATERIAL_BLOW_USED.ToString());
//             AddParaItem = new GridViewControl_Parameter.ParameterItem(EN_TASK_LIST.TRANSFER, AddParaList);
//             AddParaItem.ParameterSettingType = Define.DefineEnumBase.Component.EN_PARAMETER_SETTING_TYPE.TRUE_FALSE;
//             parameterList.Add(AddParaItem);

            AddParaList = new List<string>();
            AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.HANDLER_X_MATERIAL_HANDLE_SPEED);
            AddParaItem.DisplayName = "HANDLE SPEED X";
            parameterList.Add(AddParaItem);

            AddParaList = new List<string>();
            AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.HANDLER_Y_MATERIAL_HANDLE_SPEED);
            AddParaItem.DisplayName = "HANDLE SPEED Y";
            parameterList.Add(AddParaItem);

            AddParaList = new List<string>();
            AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.HANDLER_R_MATERIAL_HANDLE_SPEED);
            AddParaItem.DisplayName = "HANDLE SPEED R";
            parameterList.Add(AddParaItem);

            AddParaList = new List<string>();
            AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.HANDLER_Z_MATERIAL_CONTACT_SPEED);
            AddParaItem.DisplayName = "CONTACT SPEED Z";
            parameterList.Add(AddParaItem);

            AddParaList = new List<string>();
            AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.HANDLER_Z_MATERIAL_HANDLE_SPEED);
            AddParaItem.DisplayName = "HANDLE SPEED Z";
            parameterList.Add(AddParaItem);

            gridViewControl_Handler_Parameter.Initialize(parameterList);

            List<string> HeaderList = new List<string>();
            #endregion /Parameter Grid

            #region Position Parameter Grid
            List<GridViewControl_Position_Parameter.ControlItem> PositionParamList = new List<GridViewControl_Position_Parameter.ControlItem>();

            GridViewControl_Position_Parameter.ControlItem AddPositionParam;

            AddPositionParam = new GridViewControl_Position_Parameter.ControlItem(EN_TASK_LIST.TRANSFER, TRANSFER_TASK_PARAM.HANDLER_PRE_EQUIPMENT_TRANSFER_POSITION_X_2.ToString(), (int)EN_AXIS.HANDLER_X);
            AddPositionParam.DisplayName = "TRNASFER";
            AddPositionParam.AxisName = "HANDLER X";
            AddPositionParam.ParameterIndex = 0;
            PositionParamList.Add(AddPositionParam);

            AddPositionParam = new GridViewControl_Position_Parameter.ControlItem(EN_TASK_LIST.TRANSFER, TRANSFER_TASK_PARAM.HANDLER_PRE_EQUIPMENT_TRANSFER_POSITION_Y_2.ToString(), (int)EN_AXIS.HANDLER_Y);
            AddPositionParam.DisplayName = "TRNASFER";
            AddPositionParam.AxisName = "HANDLER Y";
            AddPositionParam.ParameterIndex = 0;
            PositionParamList.Add(AddPositionParam);

            AddPositionParam = new GridViewControl_Position_Parameter.ControlItem(EN_TASK_LIST.TRANSFER, TRANSFER_TASK_PARAM.HANDLER_PRE_EQUIPMENT_TRANSFER_OFFSET_Y_2.ToString(), (int)EN_AXIS.HANDLER_Y);
            AddPositionParam.DisplayName = "AVOID OFFSET";
            AddPositionParam.AxisName = "HANDLER Y";
            AddPositionParam.ParameterIndex = 0;
            AddPositionParam.GetOffsetValue = GetOffsetHandlerYPort1;
            PositionParamList.Add(AddPositionParam);

            AddPositionParam = new GridViewControl_Position_Parameter.ControlItem(EN_TASK_LIST.TRANSFER, TRANSFER_TASK_PARAM.HANDLER_PRE_EQUIPMENT_TRANSFER_UP_POSITION_Z_2.ToString(), (int)EN_AXIS.HANDLER_Z);
            AddPositionParam.DisplayName = "UP";
            AddPositionParam.AxisName = "HANDLER Z";
            AddPositionParam.ParameterIndex = 0;
            PositionParamList.Add(AddPositionParam);

            AddPositionParam = new GridViewControl_Position_Parameter.ControlItem(EN_TASK_LIST.TRANSFER, TRANSFER_TASK_PARAM.HANDLER_PRE_EQUIPMENT_TRANSFER_CONTACT_POSITION_Z_2.ToString(), (int)EN_AXIS.HANDLER_Z);
            AddPositionParam.DisplayName = "CONTACT";
            AddPositionParam.AxisName = "HANDLER Z";
            AddPositionParam.ParameterIndex = 0;
            PositionParamList.Add(AddPositionParam);

            AddPositionParam = new GridViewControl_Position_Parameter.ControlItem(EN_TASK_LIST.TRANSFER, TRANSFER_TASK_PARAM.HANDLER_PRE_EQUIPMENT_TRANSFER_DOWN_POSITION_Z_2.ToString(), (int)EN_AXIS.HANDLER_Z);
            AddPositionParam.DisplayName = "DOWN";
            AddPositionParam.AxisName = "HANDLER Z";
            AddPositionParam.ParameterIndex = 0;
            PositionParamList.Add(AddPositionParam);

            gridViewControl_Handler_Port1_Position_Parameter.Initialize(PositionParamList);

            PositionParamList = new List<GridViewControl_Position_Parameter.ControlItem>();

            AddPositionParam = new GridViewControl_Position_Parameter.ControlItem(EN_TASK_LIST.TRANSFER, TRANSFER_TASK_PARAM.HANDLER_PRE_EQUIPMENT_TRANSFER_POSITION_X_2.ToString(), (int)EN_AXIS.HANDLER_X);
            AddPositionParam.DisplayName = "TRNASFER";
            AddPositionParam.AxisName = "HANDLER X";
            AddPositionParam.ParameterIndex = 1;
            PositionParamList.Add(AddPositionParam);

            AddPositionParam = new GridViewControl_Position_Parameter.ControlItem(EN_TASK_LIST.TRANSFER, TRANSFER_TASK_PARAM.HANDLER_PRE_EQUIPMENT_TRANSFER_POSITION_Y_2.ToString(), (int)EN_AXIS.HANDLER_Y);
            AddPositionParam.DisplayName = "TRNASFER";
            AddPositionParam.AxisName = "HANDLER Y";
            AddPositionParam.ParameterIndex = 1;
            PositionParamList.Add(AddPositionParam);

            AddPositionParam = new GridViewControl_Position_Parameter.ControlItem(EN_TASK_LIST.TRANSFER, TRANSFER_TASK_PARAM.HANDLER_PRE_EQUIPMENT_TRANSFER_OFFSET_Y_2.ToString(), (int)EN_AXIS.HANDLER_Y);
            AddPositionParam.DisplayName = "AVOID OFFSET";
            AddPositionParam.AxisName = "HANDLER Y";
            AddPositionParam.ParameterIndex = 1;
            AddPositionParam.GetOffsetValue = GetOffsetHandlerYPort2;
            PositionParamList.Add(AddPositionParam);


            AddPositionParam = new GridViewControl_Position_Parameter.ControlItem(EN_TASK_LIST.TRANSFER, TRANSFER_TASK_PARAM.HANDLER_PRE_EQUIPMENT_TRANSFER_UP_POSITION_Z_2.ToString(), (int)EN_AXIS.HANDLER_Z);
            AddPositionParam.DisplayName = "UP";
            AddPositionParam.AxisName = "HANDLER Z";
            AddPositionParam.ParameterIndex = 1;
            PositionParamList.Add(AddPositionParam);


            AddPositionParam = new GridViewControl_Position_Parameter.ControlItem(EN_TASK_LIST.TRANSFER, TRANSFER_TASK_PARAM.HANDLER_PRE_EQUIPMENT_TRANSFER_CONTACT_POSITION_Z_2.ToString(), (int)EN_AXIS.HANDLER_Z);
            AddPositionParam.DisplayName = "CONTACT";
            AddPositionParam.AxisName = "HANDLER Z";
            AddPositionParam.ParameterIndex = 1;
            PositionParamList.Add(AddPositionParam);

            AddPositionParam = new GridViewControl_Position_Parameter.ControlItem(EN_TASK_LIST.TRANSFER, TRANSFER_TASK_PARAM.HANDLER_PRE_EQUIPMENT_TRANSFER_DOWN_POSITION_Z_2.ToString(), (int)EN_AXIS.HANDLER_Z);
            AddPositionParam.DisplayName = "DOWN";
            AddPositionParam.AxisName = "HANDLER Z";
            AddPositionParam.ParameterIndex = 1;
            PositionParamList.Add(AddPositionParam);

            gridViewControl_Handler_Port2_Position_Parameter.Initialize(PositionParamList);

            PositionParamList = new List<GridViewControl_Position_Parameter.ControlItem>();

            AddPositionParam = new GridViewControl_Position_Parameter.ControlItem(EN_TASK_LIST.TRANSFER, TRANSFER_TASK_PARAM.HANDLER_PRE_EQUIPMENT_TRANSFER_POSITION_R.ToString(), (int)EN_AXIS.HANDLER_R);
            AddPositionParam.DisplayName = "TRANSFER";
            AddPositionParam.AxisName = "HANDLER R";
            PositionParamList.Add(AddPositionParam);

            AddPositionParam = new GridViewControl_Position_Parameter.ControlItem(EQUIPMENT_PARAM.HANDLER_READY_X, (int)EN_AXIS.HANDLER_X);
            AddPositionParam.DisplayName = "READY";
            AddPositionParam.AxisName = "HANDLER X";
            PositionParamList.Add(AddPositionParam);

            gridViewControl_Handler_Position_Parameter.Initialize(PositionParamList);
            #endregion /Position Parameter Grid

            #region Device
            List<GridVeiwControl_Device.ControlItem> ControlList = new List<GridVeiwControl_Device.ControlItem>();

            GridVeiwControl_Device.ControlItem AddControlItem;

            List<int> lstDeviceIndex = new List<int>();
            List<GridVeiwControl_Device.EN_CONTROL_TYPE> lstDeviceType = new List<GridVeiwControl_Device.EN_CONTROL_TYPE>();
            lstDeviceIndex.Add((int)EN_DIGITAL_IN.PRE_SMEMA_PORT1);
            lstDeviceType.Add(GridVeiwControl_Device.EN_CONTROL_TYPE.DIGITAL_INPUT);
            lstDeviceIndex.Add((int)EN_DIGITAL_OUT.PRE_SMEMA_PORT1);
            lstDeviceType.Add(GridVeiwControl_Device.EN_CONTROL_TYPE.DIGITAL_OUTPUT);
            AddControlItem = new GridVeiwControl_Device.ControlItem(lstDeviceIndex, lstDeviceType);
            AddControlItem.Name = "SMEMA";
            ControlList.Add(AddControlItem);

            lstDeviceIndex = new List<int>();
            lstDeviceType = new List<GridVeiwControl_Device.EN_CONTROL_TYPE>();
            lstDeviceIndex.Add((int)EN_DIGITAL_IN.PRE_SMEMA_SUB_PORT1);
            lstDeviceType.Add(GridVeiwControl_Device.EN_CONTROL_TYPE.DIGITAL_INPUT);
            lstDeviceIndex.Add((int)EN_DIGITAL_OUT.PRE_SMEMA_SUB_PORT1);
            lstDeviceType.Add(GridVeiwControl_Device.EN_CONTROL_TYPE.DIGITAL_OUTPUT);
            AddControlItem = new GridVeiwControl_Device.ControlItem(lstDeviceIndex, lstDeviceType);
            AddControlItem.Name = "SMEMA SUB";
            ControlList.Add(AddControlItem);

            gridVeiwControl_Handler_Device_Port1.Initialize(ControlList);

            
            List<string> lstHeader = new List<string>();

            lstHeader.Add("");
            lstHeader.Add("INPUT");
            lstHeader.Add("OUTPUT");

            gridVeiwControl_Handler_Device_Port1.ShowHeader(lstHeader);

            ControlList = new List<GridVeiwControl_Device.ControlItem>();

            lstDeviceIndex = new List<int>();
            lstDeviceType = new List<GridVeiwControl_Device.EN_CONTROL_TYPE>();
            lstDeviceIndex.Add((int)EN_DIGITAL_IN.PRE_SMEMA_PORT2);
            lstDeviceType.Add(GridVeiwControl_Device.EN_CONTROL_TYPE.DIGITAL_INPUT);
            lstDeviceIndex.Add((int)EN_DIGITAL_OUT.PRE_SMEMA_PORT2);
            lstDeviceType.Add(GridVeiwControl_Device.EN_CONTROL_TYPE.DIGITAL_OUTPUT);
            AddControlItem = new GridVeiwControl_Device.ControlItem(lstDeviceIndex, lstDeviceType);
            AddControlItem.Name = "SMEMA";
            ControlList.Add(AddControlItem);

            lstDeviceIndex = new List<int>();
            lstDeviceType = new List<GridVeiwControl_Device.EN_CONTROL_TYPE>();
            lstDeviceIndex.Add((int)EN_DIGITAL_IN.PRE_SMEMA_SUB_PORT2);
            lstDeviceType.Add(GridVeiwControl_Device.EN_CONTROL_TYPE.DIGITAL_INPUT);
            lstDeviceIndex.Add((int)EN_DIGITAL_OUT.PRE_SMEMA_SUB_PORT2);
            lstDeviceType.Add(GridVeiwControl_Device.EN_CONTROL_TYPE.DIGITAL_OUTPUT);
            AddControlItem = new GridVeiwControl_Device.ControlItem(lstDeviceIndex, lstDeviceType);
            AddControlItem.Name = "SMEMA SUB";
            ControlList.Add(AddControlItem);

            gridVeiwControl_Handler_Device_Port2.Initialize(ControlList);

            gridVeiwControl_Handler_Device_Port2.ShowHeader(lstHeader);


            ControlList = new List<GridVeiwControl_Device.ControlItem>();

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

        private double GetOffsetHandlerYPort1()
        {
            return m_instanceRecipe.GetValue(EN_TASK_LIST.TRANSFER.ToString(), TRANSFER_TASK_PARAM.HANDLER_PRE_EQUIPMENT_TRANSFER_POSITION_Y_2.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
        }

        private double GetOffsetHandlerYPort2()
        {
            return m_instanceRecipe.GetValue(EN_TASK_LIST.TRANSFER.ToString(), TRANSFER_TASK_PARAM.HANDLER_PRE_EQUIPMENT_TRANSFER_POSITION_Y_2.ToString(), 1, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
        }
        #endregion

        #endregion
    }
}
