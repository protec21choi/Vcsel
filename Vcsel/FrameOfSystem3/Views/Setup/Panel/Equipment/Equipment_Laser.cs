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
using Define.DefineEnumProject.DigitalIO;
using Define.DefineEnumProject.Cylinder;
using Define.DefineEnumProject.Task;
using Define.DefineEnumProject.Laser;
using Define.DefineEnumProject.Laser.Power;

using FrameOfSystem3.Component;
using FrameOfSystem3.Recipe;
using FrameOfSystem3.Functional;
using FrameOfSystem3.Laser;
using ZedGraph;

using EQUIPMENT_PARAM = FrameOfSystem3.Recipe.PARAM_EQUIPMENT;
using BONDER_TASK_PARAM = Define.DefineEnumProject.Task.BondHead.PARAM_PROCESS;
using WORKZONE_TASK_PARAM = Define.DefineEnumProject.Task.WorkZone.PARAM_PROCESS;
using Define.DefineEnumProject.Mail;

using RecipeManager_;

namespace FrameOfSystem3.Views.Setup.Equipment
{
    public partial class Equipment_Laser : UserControl, ISetupPanel
    {
        #region Consturct
        public Equipment_Laser()
        {
            this.DoubleBuffered = true;

            InitializeComponent();
            InitGridPositionParameter();
            InitGridEnableParameter();
            InitGridPowerMesureParameter();
            InitGridDevice();
            InitializeGraph();
			#region DescriptionEvent
			#endregion

			#region Instance
			_Calculator_Instance_m_p			= Functional.Form_Calculator.GetInstance();
			_Keyboard_Instance_m_p				= Functional.Form_Keyboard.GetInstance();
			_MessageBox_Instance_m_p			= Functional.Form_MessageBox.GetInstance();

            m_instanceRecipe                    = FrameOfSystem3.Recipe.Recipe.GetInstance();

            m_LaserCalManager = Laser.ProtecLaserChannelCalibration.GetInstance();

            #region recovery
            RunningTask_.RunningTask pTempTask = null;
            Task.TaskOperator.GetInstance().GetTaskInstance(Define.DefineEnumProject.Task.EN_TASK_LIST.BOND_HEAD.ToString(), ref pTempTask);
            m_TaskBonder_Instance = pTempTask as Task.TaskBondHead;
            #endregion
			#endregion

            _postOffice =   FrameOfSystem3.Functional.PostOffice.GetInstance();
            _postOffice.RequestSubscribe(EN_SUBSCRIBER.SETUP_EQUP_LASER, NotificationMailArrive);

            ComboBox_Channel.SelectedIndex = 0;
		}
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

		#region Constants
        private readonly Color c_clrLebel = Color.SteelBlue;
        private readonly Color c_clrTrue = Color.Green;
        private readonly Color c_clrFalse = Color.White;
		#endregion

		#region Variable

		#region Information
        private List<string> m_lstChannelIndex = new List<string>();

		#endregion

		#region Instance
		private Functional.Form_MessageBox _MessageBox_Instance_m_p		= null;
        private Functional.Form_Keyboard _Keyboard_Instance_m_p			= null;
		private Functional.Form_Calculator _Calculator_Instance_m_p		= null;

        private FrameOfSystem3.Recipe.Recipe m_instanceRecipe = null;

        private Laser.ProtecLaserChannelCalibration m_LaserCalManager = null;

        private FileDialog m_instanceFile = new OpenFileDialog();

        private Task.TaskBondHead m_TaskBonder_Instance = null;

        PostOffice _postOffice = null;
        #endregion

		#endregion

		#region Override Interface
		public void Activation()
        {
            gridViewControl_Enable_Parameter.UpdateValue();
            gridViewControl_Position_Parameter.UpdateValue();
            gridViewControl_Power_Measure_Parameter.UpdateValue();
            UpdatePowerTable();
            InitializeGraph();

            m_ZedGraph.Visible = FrameOfSystem3.Config.SystemConfig.GetInstance().PowermeterGraphVisible;
			this.Show();
        }
        public void Deactivation()
        {
			this.Hide();
        }
        public void CallFunction()
        {
            gridVeiwControl_Device.UpdateState();
            gridVeiwControl_Cylinder_Device.UpdateState();

            UpdateAlamCode();
            UpdatePowerMeasureResult();
        }
        #endregion

        #region Internal Interface

        #region initComponent
        private void InitGridPositionParameter()
        {
            List<GridViewControl_2Axis_Position_Parameter.ControlItem> PositionParamList2Axis = new List<GridViewControl_2Axis_Position_Parameter.ControlItem>();

            GridViewControl_2Axis_Position_Parameter.ControlItem AddPositionParam2Axis;

            AddPositionParam2Axis = new GridViewControl_2Axis_Position_Parameter.ControlItem(EQUIPMENT_PARAM.POWER_MEASURE_BLOCK_AVOID_POSITION_X, (int)EN_AXIS.BLOCK_X
                                                                                                           , EQUIPMENT_PARAM.POWER_MEASURE_HEAD_AVOID_POSITION_Y, (int)EN_AXIS.GANTRY_Y);
            AddPositionParam2Axis.DisplayName = "BLOCK AVOID POSITION";
            AddPositionParam2Axis.FirstAxisName = "X";
            AddPositionParam2Axis.SecondAxisName = "Y";
            PositionParamList2Axis.Add(AddPositionParam2Axis);

            AddPositionParam2Axis = new GridViewControl_2Axis_Position_Parameter.ControlItem(EQUIPMENT_PARAM.HANDLER_WORK_BLOCK_AVOID_POSITION_R, (int)EN_AXIS.HANDLER_R
                                                                                                          , EQUIPMENT_PARAM.HANDLER_WORK_BLOCK_AVOID_POSITION_Z, (int)EN_AXIS.HANDLER_Z);
            AddPositionParam2Axis.DisplayName = "HANDLER AVOID POSITION";
            AddPositionParam2Axis.FirstAxisName = "R";
            AddPositionParam2Axis.SecondAxisName = "Z";
            PositionParamList2Axis.Add(AddPositionParam2Axis);

            AddPositionParam2Axis = new GridViewControl_2Axis_Position_Parameter.ControlItem(EQUIPMENT_PARAM.POWERMETER_READY_POSITION_X, (int)EN_AXIS.POWERMETER_X
                                                                                                          , EQUIPMENT_PARAM.POWERMETER_READY_POSITION_Y, (int)EN_AXIS.GANTRY_Y);
            AddPositionParam2Axis.DisplayName = "POWERMETER READY POSITION";
            AddPositionParam2Axis.FirstAxisName = "X";
            AddPositionParam2Axis.SecondAxisName = "Y";
            PositionParamList2Axis.Add(AddPositionParam2Axis);

            for (int nCh = 0; nCh < Laser.ProtecLaserMananger.GetInstance().ChannelCount; nCh++)
            {
                AddPositionParam2Axis = new GridViewControl_2Axis_Position_Parameter.ControlItem(EQUIPMENT_PARAM.POWER_MEASURE_POSITION_X_18, (int)EN_AXIS.POWERMETER_X
                                                                                                            , EQUIPMENT_PARAM.POWER_MEASURE_POSITION_Y_18, (int)EN_AXIS.GANTRY_Y, nCh);
                AddPositionParam2Axis.DisplayName = "POSITION CH " + (nCh+ 1).ToString();
                AddPositionParam2Axis.FirstAxisName = "X";
                AddPositionParam2Axis.SecondAxisName = "Y";
                PositionParamList2Axis.Add(AddPositionParam2Axis);
            }

            gridViewControl_Position_Parameter.Initialize(PositionParamList2Axis, 4, 30);
        }

        private void InitGridEnableParameter()
        {
//             List<GridViewControl_Parameter.ParameterItem> parameterList = new List<GridViewControl_Parameter.ParameterItem>();
// 
//             GridViewControl_Parameter.ParameterItem AddParaItem;
//             List<int> lstIndex = new List<int>();
//             List<string> lstHeader = new List<string>();
//             List<EQUIPMENT_PARAM> lstParam = new List<EQUIPMENT_PARAM>();
//             lstHeader.Add("");
//             for (int nCh = 0; nCh < Laser.ProtecLaserMananger.GetInstance().ChannelCount; nCh++)
//             {
//                 lstIndex.Add(nCh);
//                 lstHeader.Add("CH " + (nCh + 1).ToString());
//                 lstParam.Add(EQUIPMENT_PARAM.POWER_MEASURE_CHANNEL_ENABLE_18);
//             }
// 
//             AddParaItem = new GridViewControl_Parameter.ParameterItem(lstParam, lstIndex);
//             AddParaItem.DisplayName = "ENABLE";
//             AddParaItem.ParameterSettingType = Define.DefineEnumBase.Component.EN_PARAMETER_SETTING_TYPE.TRUE_FALSE;
//             AddParaItem.AfterSetParameter = SetPowerMinMax;
//             parameterList.Add(AddParaItem);
// 
//             gridViewControl_Enable_Parameter.Initialize(parameterList, -1, 65);
//             gridViewControl_Enable_Parameter.ShowHeader(lstHeader);

            List<GridViewControl_Parameter.ParameterItem> parameterList = new List<GridViewControl_Parameter.ParameterItem>();

            GridViewControl_Parameter.ParameterItem AddParaItem;
            List<int> lstIndex = new List<int>();
            List<string> lstDisplay = new List<string>();
            List<EQUIPMENT_PARAM> lstParam = new List<EQUIPMENT_PARAM>();
            for (int nCh = Laser.ProtecLaserMananger.GetInstance().ChannelCount / 2; nCh < Laser.ProtecLaserMananger.GetInstance().ChannelCount; nCh++)
            {
                lstIndex.Add(nCh);
                lstDisplay.Add("CH " + (nCh + 1).ToString());
                lstParam.Add(EQUIPMENT_PARAM.POWER_MEASURE_CHANNEL_ENABLE_18);
            }

            AddParaItem = new GridViewControl_Parameter.ParameterItem(lstParam, lstIndex);
            AddParaItem.DisplayName = "ENABLE";
            AddParaItem.ParameterSettingType = Define.DefineEnumBase.Component.EN_PARAMETER_SETTING_TYPE.TRUE_FALSE;
            AddParaItem.TrueFalseName = lstDisplay;
            AddParaItem.AfterSetParameter = SetPowerMinMax;
            parameterList.Add(AddParaItem);

            lstIndex = new List<int>();
            lstDisplay = new List<string>();
            lstParam = lstParam = new List<EQUIPMENT_PARAM>();
            for (int nCh = 0; nCh < Laser.ProtecLaserMananger.GetInstance().ChannelCount / 2; nCh++)
            {
                lstIndex.Add(nCh);
                lstDisplay.Add("CH " + (nCh + 1).ToString());
                lstParam.Add(EQUIPMENT_PARAM.POWER_MEASURE_CHANNEL_ENABLE_18);
            }

            AddParaItem = new GridViewControl_Parameter.ParameterItem(lstParam, lstIndex);
            AddParaItem.DisplayName = " ";
            AddParaItem.ParameterSettingType = Define.DefineEnumBase.Component.EN_PARAMETER_SETTING_TYPE.TRUE_FALSE;
            AddParaItem.TrueFalseName = lstDisplay;
            AddParaItem.AfterSetParameter = SetPowerMinMax;
            parameterList.Add(AddParaItem);

            gridViewControl_Enable_Parameter.Initialize(parameterList, -1, 110);
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

        private void InitGridDevice()
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


            gridVeiwControl_Device.Initialize(ControlList);

            List<string> lstHeader = new List<string>();

            lstHeader.Add("");
            lstHeader.Add("PORT 1");
            lstHeader.Add("PORT 2");
            lstHeader.Add("PORT 3");
            lstHeader.Add("MONITOR");

            gridVeiwControl_Device.ShowHeader(lstHeader);

            ControlList = new List<GridVeiwControl_Device.ControlItem>();

            AddControlItem = new GridVeiwControl_Device.ControlItem((int)EN_CYLINDER.POWERMETER, GridVeiwControl_Device.EN_CONTROL_TYPE.CYLINDER);
            ControlList.Add(AddControlItem);

            gridVeiwControl_Cylinder_Device.Initialize(ControlList);
        }

        private void InitializeGraph()
        {
            m_ZedGraph.GraphPane.Title.IsVisible = false;
            m_ZedGraph.GraphPane.Legend.FontSpec.Size = 6;
            m_ZedGraph.GraphPane.XAxis.Title.Text = "REAL TIME(s)";
            m_ZedGraph.GraphPane.YAxis.Scale.FontSpec.Size = 8;
            m_ZedGraph.GraphPane.XAxis.Scale.FontSpec.Size = 8;

            m_ZedGraph.GraphPane.XAxis.MajorTic.IsAllTics = false;
            m_ZedGraph.GraphPane.XAxis.MajorTic.IsOpposite = false;
            m_ZedGraph.GraphPane.XAxis.MinorTic.IsOpposite = false;

            // modify //
            m_ZedGraph.GraphPane.YAxis.Title.Text = "POWER";
            // modify end //

            m_ZedGraph.GraphPane.YAxis.Scale.FontSpec.Size = 8;
            m_ZedGraph.GraphPane.YAxis.MinorTic.IsOpposite = false;
           // m_ZedGraph.GraphPane.YAxis.MinorTic.IsOpposite = true;
            m_ZedGraph.GraphPane.XAxis.MajorTic.IsOpposite = false;
            m_ZedGraph.GraphPane.YAxis.MajorTic.IsAllTics = false;
            m_ZedGraph.GraphPane.YAxis.MinorTic.IsAllTics = false;


            m_ZedGraph.GraphPane.YAxis.MajorGrid.IsVisible = true;


            m_ZedGraph.IsShowPointValues = true;
        }
        #endregion

        #region Cal Table Grid
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

        #endregion

        #region Update
        private void UpdatePowerMeasureResult()
        {
          //  ExternalDevice.Serial.Powermeter.GetInstance().CalculateRepeatAVG();

            m_lblMinValue.Text = ExternalDevice.Serial.Powermeter.GetInstance().Measure_Min.ToString();
            m_lblMaxValue.Text = ExternalDevice.Serial.Powermeter.GetInstance().Measure_Max.ToString();
            m_lblAvgValue.Text = ExternalDevice.Serial.Powermeter.GetInstance().Measure_Avg.ToString();
            m_lblLastValue.Text = ExternalDevice.Serial.Powermeter.GetInstance().Measure_Cur.ToString();

            m_lblRepeatCount.Text = m_TaskBonder_Instance.GetPowerMeasureRepeatCount().ToString();
            m_lblRepeatAvg.Text = ExternalDevice.Serial.Powermeter.GetInstance().Measure_Repeat_Avg.ToString();
            m_lblRestTime.Text = m_TaskBonder_Instance.GetPowermeasureRestTime().ToString();

            m_lblCalChannel.Text = m_TaskBonder_Instance.GetPowerCalCh().ToString();
            m_lblCalStep.Text = m_TaskBonder_Instance.GetPowerCalStep().ToString();
            m_lblCalVolt.Text = m_TaskBonder_Instance.GetPowerCalVolt().ToString();

            m_lblinputVolt.Text = m_TaskBonder_Instance.GetMeasuredInputVolt().ToString();
            UpdateGraph();
        }
        private void UpdateGraph()
        {
            m_ZedGraph.GraphPane.CurveList.Clear();

            List<double> MeasuredPower = new List<double>(ExternalDevice.Serial.Powermeter.GetInstance().Measure_List);
            List<double> MeasuredTime = new List<double>(ExternalDevice.Serial.Powermeter.GetInstance().Time_List);

            if (MeasuredPower.Count > 0)
            {
                m_ZedGraph.GraphPane.YAxis.Scale.Min = MeasuredPower.Min();
                m_ZedGraph.GraphPane.YAxis.Scale.Max = MeasuredPower.Max();

                m_ZedGraph.GraphPane.YAxis.Scale.MajorStep = ((MeasuredPower.Max() - MeasuredPower.Min()) / 10);
                m_ZedGraph.GraphPane.YAxis.Scale.MinorStep = ((MeasuredPower.Max() - MeasuredPower.Min()) / 20);
            }
            if (MeasuredTime.Count > 0)
            {
                m_ZedGraph.GraphPane.XAxis.Scale.Min = 0;
                m_ZedGraph.GraphPane.XAxis.Scale.Max = MeasuredTime.Max();

                m_ZedGraph.GraphPane.XAxis.Scale.MajorStep = (MeasuredTime.Max() / 10);
                m_ZedGraph.GraphPane.XAxis.Scale.MinorStep = ((MeasuredTime.Max() - MeasuredTime.Min()) / 20);
            }
            double[] X = MeasuredTime.ToArray();
            double[] Y = MeasuredPower.ToArray();

            m_ZedGraph.GraphPane.AddCurve("POWER", X, Y, Color.Red, SymbolType.None);
            m_ZedGraph.Refresh();
        }

        private void UpdateAlamCode()
        {
            if(DigitalIO_.DigitalIO.GetInstance().ReadInput((int)EN_DIGITAL_IN.LD_1_ALARM))
            {
                ExternalDevice.Serial.ProtecLaserController.EN_CONTROL_ALARM enAlarm = ExternalDevice.Serial.ProtecLaserController.EN_CONTROL_ALARM.NONE; 
                if(ExternalDevice.Serial.ProtecLaserController.GetInstance().GetAlarmCode(0, ref enAlarm) == ExternalDevice.Serial.ProtecLaserController.EN_RESULT.DONE)
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
        #endregion

        #region Action
        private void Click_Action(object sender, EventArgs e)
        {
            if (!EquipmentState_.EquipmentState.GetInstance().GetState().Equals(EquipmentState_.EQUIPMENT_STATE.IDLE))
                return;

            Control ctrButton = sender as Control;

            string strAction = ctrButton.Text.Replace("\\n", "");
            if (!_MessageBox_Instance_m_p.ShowMessage(string.Format("Do You Want {0}?", strAction)))
                return;


            string[] arSelectTask = new string[] { };
            string[][] arSelectAction = new string[][] { };
            int nRetryTime = 1;
            switch (ctrButton.TabIndex)
            {
                case 0:
                    arSelectAction = new string[2][];
                    arSelectTask = new string[] { EN_TASK_LIST.BOND_HEAD.ToString() , EN_TASK_LIST.TRANSFER.ToString() };
                    arSelectAction[0] = new string[] {null , Define.DefineEnumProject.Task.Transfer.EN_TASK_ACTION.MOVE_AVOID.ToString() };
                    arSelectAction[1] = new string[] { Define.DefineEnumProject.Task.BondHead.EN_TASK_ACTION.MEASURE_POWER.ToString(), null };
                    Task.TaskOperator.GetInstance().SetOperation(ref arSelectTask, ref arSelectAction, nRetryTime);
                    break;

                case 1:
                    arSelectAction = new string[2][];
                    arSelectTask = new string[] { EN_TASK_LIST.BOND_HEAD.ToString() , EN_TASK_LIST.TRANSFER.ToString() };
                    arSelectAction[0] = new string[] {"" , Define.DefineEnumProject.Task.Transfer.EN_TASK_ACTION.MOVE_AVOID.ToString() };
                    arSelectAction[1] = new string[] { Define.DefineEnumProject.Task.BondHead.EN_TASK_ACTION.MEASURE_VOLT.ToString() , ""};
                    Task.TaskOperator.GetInstance().SetOperation(ref arSelectTask, ref arSelectAction, nRetryTime);
                    break;

                case 2:
                    arSelectAction = new string[2][];
                    arSelectTask = new string[] { EN_TASK_LIST.BOND_HEAD.ToString() , EN_TASK_LIST.TRANSFER.ToString() };
                    arSelectAction[0] = new string[] {null , Define.DefineEnumProject.Task.Transfer.EN_TASK_ACTION.MOVE_AVOID.ToString() };
                    arSelectAction[1] = new string[] { Define.DefineEnumProject.Task.BondHead.EN_TASK_ACTION.CALIBRATION_CHANNEL_POWER.ToString(), null };
                    Task.TaskOperator.GetInstance().SetOperation(ref arSelectTask, ref arSelectAction, nRetryTime);
                    break;

                case 3:
                    arSelectAction = new string[1][];
                    arSelectTask = new string[] { EN_TASK_LIST.BOND_HEAD.ToString() };
                    arSelectAction[0] = new string[] { Define.DefineEnumProject.Task.BondHead.EN_TASK_ACTION.SHORT_TEST.ToString() };
                    Task.TaskOperator.GetInstance().SetOperation(ref arSelectTask, ref arSelectAction, nRetryTime);
                    break;
            }
        }

        private void Click_Stop(object sender, EventArgs e)
        {
            Task.TaskOperator.GetInstance().SetOperation(RunningMain_.OPERATION_EQUIPMENT.STOP);
        }
        #endregion

        #region Mail
        #region <MAIL>
        private void NotificationMailArrive(EN_MAIL title)
        {
            if (this.InvokeRequired)
            {
                var d = new PostOffice.DelegateNotificationMailArrive(NotificationMailArrive);
                this.Invoke(d, title);
            }
            else
            {
                List<Mail> mails;
                if (false == _postOffice.GetMail(EN_SUBSCRIBER.SETUP_EQUP_LASER, title, out mails)) return;

                foreach (Mail mail in mails)
                {
                    switch (mail.Title)
                    {
                        case EN_MAIL.UPDATE_UI:
                            {
                                gridViewControl_Enable_Parameter.UpdateValue();
                                gridViewControl_Position_Parameter.UpdateValue();
                                gridViewControl_Power_Measure_Parameter.UpdateValue();
                                UpdatePowerTable();
                                SetPowerMinMax();
                            }
                            break;

                    }
                }
            }
        }
        #endregion </MAIL>

        #endregion

        private void Cick_All_IO(object sender, EventArgs e)
        {
            Control ctrButton = sender as Control;
            switch (ctrButton.TabIndex)
            {
                case 0: // RESET
                    if(!FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().ReadItem(false, (int)EN_DIGITAL_OUT.LD_1_ALARM_CLEAR)
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

        private void SetPowerMinMax()
        {
            bool[] arUsed = new bool[ProtecLaserMananger.GetInstance().ChannelCount];
            for (int nCh = 0; nCh < ProtecLaserMananger.GetInstance().ChannelCount; ++nCh)
            {
                arUsed[nCh] = m_instanceRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.POWER_MEASURE_CHANNEL_ENABLE_18.ToString(), nCh, EN_RECIPE_PARAM_TYPE.VALUE, false);
                //  arUsed[nCh] = m_instanceRecipe.GetValue(EN_TASK_LIST.BONDER.ToString(), BONDER_TASK_PARAM.LASER_ENABLED.ToString(), nCh, EN_RECIPE_PARAM_TYPE.VALUE, false);
            }

            m_instanceRecipe.SetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.POWER_MEASURE_WATT.ToString(), 0, EN_RECIPE_PARAM_TYPE.MAX, m_LaserCalManager.GetMaxPower(arUsed).ToString());
            m_instanceRecipe.SetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.POWER_MEASURE_WATT.ToString(), 0, EN_RECIPE_PARAM_TYPE.MIN, m_LaserCalManager.GetMinPower(arUsed).ToString());
        }
        #endregion
    }
}
