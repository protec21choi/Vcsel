using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using System.IO;

using FrameOfSystem3.Recipe;
using Define.DefineEnumProject.AnalogIO;
using FrameOfSystem3.Component;
using Define.DefineEnumProject.Task;
using FrameOfSystem3.Laser;

using EQUIPMENT_PARAM = FrameOfSystem3.Recipe.PARAM_EQUIPMENT;
using BONDER_TASK_PARAM = Define.DefineEnumProject.Task.BondHead.PARAM_PROCESS;


namespace FrameOfSystem3.Views.Functional
{
    public partial class Form_CAL_Monitor : Form
    {
        private Form_CAL_Monitor()
        {
            InitializeComponent();

            InitGridLaserParameter();
            InitGridLaserParameter5Step();
            InitGridPowerMesureParameter();

            InitGridLaserParameter_2();
            InitGridLaserParameter5Step_2();
            InitGridPowerMesureParameter_2();

            #region Instance
            _Calculator_Instance_m_p = Functional.Form_Calculator.GetInstance();
            m_LaserCalManager = Laser.ProtecLaserChannelCalibration.GetInstance();
            m_LaserCalManager_2 = Laser.ProtecLaserChannelCalibration_2.GetInstance();
            #endregion

            ComboBox_Channel.SelectedIndex = 0;
            ComboBox_Channel_2.SelectedIndex = 0;

            m_ZedGraph.Visible = FrameOfSystem3.Config.SystemConfig.GetInstance().PowermeterGraphVisible;
            #region recovery
            RunningTask_.RunningTask pTempTask = null;
            Task.TaskOperator.GetInstance().GetTaskInstance(Define.DefineEnumProject.Task.EN_TASK_LIST.BOND_HEAD.ToString(), ref pTempTask);
            m_TaskBonder_Instance = pTempTask as Task.TaskBondHead;
            #endregion

            UpdatePowerMeasureResult();
            UpdateParamter();
            UpdatePowerLabel();
            gridViewControl_Power_Measure_Parameter.UpdateValue();
            UpdatePowerTable();

            UpdatePowerLabel_2();
            gridViewControl_Power_Measure_Parameter_2.UpdateValue();
            UpdatePowerTable_2();
        }
        
        #region 싱글톤
        private static Form_CAL_Monitor _Instance;
        public static Form_CAL_Monitor GetInstance()
        {
            if (_Instance == null)
                _Instance = new Form_CAL_Monitor();
            return _Instance;
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
        private enum EN_GRID_INDEX_2
        {
            INDEX = 0,
            VOLT = 1,
            INPUT_VOLT = 2,
            OUTPUT_POWER = 3,
        }
        #endregion

        #region 변수
        private Task.TaskBondHead m_TaskBonder_Instance = null;
        private static Timer m_timerForUpdate = new Timer();
        private static Timer m_pTimerForUpdateGUI = new Timer();
        private TickCounter_.TickCounter m_TickCount = new TickCounter_.TickCounter();
        Functional.Form_MessageBox m_MessageBox = Functional.Form_MessageBox.GetInstance();

        private FrameOfSystem3.Recipe.Recipe m_instanceRecipe = FrameOfSystem3.Recipe.Recipe.GetInstance();
        private Laser.ProtecLaserChannelCalibration m_LaserCalManager = null;
        private Laser.ProtecLaserChannelCalibration_2 m_LaserCalManager_2 = null;
        private FileDialog m_instanceFile = new OpenFileDialog();
        private Functional.Form_Calculator _Calculator_Instance_m_p = null;
        Laser.ProtecLaserMananger m_Laser = Laser.ProtecLaserMananger.GetInstance();
        Laser.ProtecLaserMananger_2 m_Laser_2 = Laser.ProtecLaserMananger_2.GetInstance();

        #endregion

        #region Timer
        /// <summary>
        /// 2020.05.15 by yjlee [ADD] This function will be called by the system timer to update the GUI.
        /// </summary>
        private void FunctionForTimerTick(object sender, EventArgs e)
        {
            //InitializeGraph();
            UpdatePowerMeasureResult();
        }
        #endregion


        #region 외부인터페이스
        /// <summary>
        /// 2020.08.12 by twkang [ADD] Jog 폼을 생성한다.
        /// </summary>
        public void CreateForm()
        {
            InitializeGraph();
            // Min Max Recipe Data Set

            this.Size = new Size(1280, 770);

            m_pTimerForUpdateGUI.Tick += new EventHandler(FunctionForTimerTick);
            m_timerForUpdate.Start();
            m_pTimerForUpdateGUI.Start();

            this.Show();
        }
        public void SetLiveMode()
        {
            InitializeGraph();
        }
        #endregion

        #region <INITIALIZE>
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
        #endregion </INITIALIZE>

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


        #endregion
        #region INTERNAL
        private void InitGridLaserParameter()
        {
            List<GridViewControl_Parameter.ParameterItem> parameterList = new List<GridViewControl_Parameter.ParameterItem>();

            List<int> AddParaIndexList = new List<int> { 0, 1, 2, 3, 4 };
            List<string> AddParaList = new List<string>
    {
        BONDER_TASK_PARAM.SHOT_PARAMETER_TOTAL_POWER.ToString()
    };
            
            GridViewControl_Parameter.ParameterItem AddParaItem = new GridViewControl_Parameter.ParameterItem(
                EN_TASK_LIST.BOND_HEAD, AddParaList, AddParaIndexList
            );
            AddParaItem.DisplayName = "LASER TOTAL POWER";
            AddParaItem.BeforeSetParameter = UpdatePowerMinMax;

            // 파라미터 값 가져오기
            double totalPowerWatt = m_instanceRecipe.GetValue(EN_TASK_LIST.BOND_HEAD.ToString(),
                BONDER_TASK_PARAM.SHOT_PARAMETER_TOTAL_POWER.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

            double laserOnDelayMs = m_instanceRecipe.GetValue(EN_TASK_LIST.BOND_HEAD.ToString(),
                BONDER_TASK_PARAM.LASER_ON_DELAY.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

            int repeatCount = m_instanceRecipe.GetValue(EN_TASK_LIST.BOND_HEAD.ToString(),
                BONDER_TASK_PARAM.LASER_WORK_COUNT.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 1);

            double dutyTimeMs = laserOnDelayMs * repeatCount;
            double dutyRatio = dutyTimeMs / 1000.0; // ex) On Delay 75ms * 10 Count = 750ms = 75%

            int channelCount = Laser.ProtecLaserMananger.GetInstance().ChannelCount;
            double totalAreaCm2 = channelCount * 50.0; // 각 채널당 50cm²
            double averagePower = totalPowerWatt * dutyRatio;
            double density = (totalAreaCm2 > 0) ? averagePower / totalAreaCm2 : 0.0;

            AddParaItem.DisplayName = $"LASER TOTAL POWER: {totalPowerWatt:F1} W ({density:F3} W/cm²)";
            parameterList.Add(AddParaItem);

            // 그리드 초기화 시, 파라미터 리스트와 기본 값을 넘겨줌
            gridViewControl_Laser_Parameter.Initialize(parameterList, -1, 230);
        }

        private void UpdatePowerMinMax()
        {
            if (m_instanceRecipe.GetValue(EN_TASK_LIST.BOND_HEAD.ToString(), BONDER_TASK_PARAM.TOTAL_POWER_MIN_MAX_RELEASE.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, false))
                return;

            // 1. 사용 채널 정보
            int channelCount = ProtecLaserMananger.GetInstance().ChannelCount;
            bool[] arUsed = new bool[channelCount];
            for (int nCh = 0; nCh < channelCount; ++nCh)
            {
                arUsed[nCh] = m_instanceRecipe.GetValue(EN_TASK_LIST.BOND_HEAD.ToString(),
                    BONDER_TASK_PARAM.SHOT_PARAMETER_ENABLE_18.ToString(),nCh,EN_RECIPE_PARAM_TYPE.VALUE,false);}

            // 2. 최소/최대 값 계산
            double minPower = m_LaserCalManager.GetMinPower(arUsed);
            double maxPower = m_LaserCalManager.GetMaxPower(arUsed);

            // 3. 레시피에 저장
            m_instanceRecipe.SetValue(EN_TASK_LIST.BOND_HEAD.ToString(),
                BONDER_TASK_PARAM.SHOT_PARAMETER_TOTAL_POWER.ToString(),0,EN_RECIPE_PARAM_TYPE.MIN,minPower.ToString());

            m_instanceRecipe.SetValue(EN_TASK_LIST.BOND_HEAD.ToString(),
                BONDER_TASK_PARAM.SHOT_PARAMETER_TOTAL_POWER.ToString(),0,EN_RECIPE_PARAM_TYPE.MAX,maxPower.ToString());
        }

        private void InitGridLaserParameter_2()
        {
            List<GridViewControl_Parameter.ParameterItem> parameterList = new List<GridViewControl_Parameter.ParameterItem>();

            List<int> AddParaIndexList = new List<int> { 0, 1, 2, 3, 4 };
            List<string> AddParaList = new List<string>
                  {
                    BONDER_TASK_PARAM.SHOT_PARAMETER_2_TOTAL_POWER.ToString()
                  };

            GridViewControl_Parameter.ParameterItem AddParaItem = new GridViewControl_Parameter.ParameterItem(
                EN_TASK_LIST.BOND_HEAD, AddParaList, AddParaIndexList
            );
            AddParaItem.DisplayName = "LASER TOTAL POWER";
            AddParaItem.BeforeSetParameter = UpdatePowerMinMax_2;

            // 파라미터 값 가져오기
            double totalPowerWatt = m_instanceRecipe.GetValue(EN_TASK_LIST.BOND_HEAD.ToString(),
                BONDER_TASK_PARAM.SHOT_PARAMETER_2_TOTAL_POWER.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

            double laserOnDelayMs = m_instanceRecipe.GetValue(EN_TASK_LIST.BOND_HEAD.ToString(),
                BONDER_TASK_PARAM.LASER_ON_DELAY.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

            int repeatCount = m_instanceRecipe.GetValue(EN_TASK_LIST.BOND_HEAD.ToString(),
                BONDER_TASK_PARAM.LASER_WORK_COUNT.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 1);

            double dutyTimeMs = laserOnDelayMs * repeatCount;
            double dutyRatio = dutyTimeMs / 1000.0; //ex) On Delay 75ms * 10 Count = 750ms = 75%

            int channelCount = Laser.ProtecLaserMananger_2.GetInstance().ChannelCount;
            double totalAreaCm2 = channelCount * 50.0; // 각 채널당 50cm²
            double averagePower = totalPowerWatt * dutyRatio;
            double density = (totalAreaCm2 > 0) ? averagePower / totalAreaCm2 : 0.0;

            AddParaItem.DisplayName = $"LASER TOTAL POWER: {totalPowerWatt:F1} W ({density:F3} W/cm²)";
            parameterList.Add(AddParaItem);

            gridViewControl_Laser_Parameter_2.Initialize(parameterList, -1, 230);


            //List<GridViewControl_Parameter.ParameterItem> parameterList = new List<GridViewControl_Parameter.ParameterItem>();

            //List<int> AddParaIndexList = new List<int>();
            //AddParaIndexList.Add(0);
            //AddParaIndexList.Add(1);
            //AddParaIndexList.Add(2);
            //AddParaIndexList.Add(3);
            //AddParaIndexList.Add(4);

            //List<string> AddParaList = new List<string>();

            //AddParaList.Add(BONDER_TASK_PARAM.SHOT_PARAMETER_2_TOTAL_POWER.ToString());

            //GridViewControl_Parameter.ParameterItem AddParaItem = new GridViewControl_Parameter.ParameterItem(EN_TASK_LIST.BOND_HEAD, AddParaList, AddParaIndexList);
            //AddParaItem.DisplayName = "LASER TOTAL POWER";

            //AddParaItem.BeforeSetParameter = UpdatePowerMinMax_2;
            //parameterList.Add(AddParaItem);

            //gridViewControl_Laser_Parameter_2.Initialize(parameterList, -1, 425);
        }
        private void UpdatePowerMinMax_2()
        {
            if (m_instanceRecipe.GetValue(EN_TASK_LIST.BOND_HEAD.ToString(), BONDER_TASK_PARAM.TOTAL_POWER_2_MIN_MAX_RELEASE.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, false))
                return;

            // 1. 사용 채널 정보
            int channelCount = ProtecLaserMananger_2.GetInstance().ChannelCount;
            bool[] arUsed = new bool[channelCount];
            for (int nCh = 0; nCh < channelCount; ++nCh)
            {
                arUsed[nCh] = m_instanceRecipe.GetValue(EN_TASK_LIST.BOND_HEAD.ToString(),
                    BONDER_TASK_PARAM.SHOT_PARAMETER_2_ENABLE_18.ToString(), nCh, EN_RECIPE_PARAM_TYPE.VALUE, false);
            }

            // 2. 최소/최대 값 계산
            double minPower = m_LaserCalManager_2.GetMinPower(arUsed);
            double maxPower = m_LaserCalManager_2.GetMaxPower(arUsed);

            // 3. 레시피에 저장
            m_instanceRecipe.SetValue(EN_TASK_LIST.BOND_HEAD.ToString(),
                BONDER_TASK_PARAM.SHOT_PARAMETER_2_TOTAL_POWER.ToString(), 0, EN_RECIPE_PARAM_TYPE.MIN, minPower.ToString());

            m_instanceRecipe.SetValue(EN_TASK_LIST.BOND_HEAD.ToString(),
                BONDER_TASK_PARAM.SHOT_PARAMETER_2_TOTAL_POWER.ToString(), 0, EN_RECIPE_PARAM_TYPE.MAX, maxPower.ToString());
        }
        private void InitGridLaserParameter5Step()
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
            AddParaItem.DisplayName = "LASER POWER 5STEP";
            parameterList.Add(AddParaItem);

            AddParaList = new List<string>();
            AddParaList.Add(BONDER_TASK_PARAM.SHOT_PARAMETER_STEP_TIME_5.ToString());
            AddParaList.Add(BONDER_TASK_PARAM.SHOT_PARAMETER_STEP_TIME_5.ToString());
            AddParaList.Add(BONDER_TASK_PARAM.SHOT_PARAMETER_STEP_TIME_5.ToString());
            AddParaList.Add(BONDER_TASK_PARAM.SHOT_PARAMETER_STEP_TIME_5.ToString());
            AddParaList.Add(BONDER_TASK_PARAM.SHOT_PARAMETER_STEP_TIME_5.ToString());
            AddParaItem = new GridViewControl_Parameter.ParameterItem(EN_TASK_LIST.BOND_HEAD, AddParaList, AddParaIndexList);
            AddParaItem.DisplayName = "LASER TIME 5STEP";
            parameterList.Add(AddParaItem);

            gridViewControl_Laser_Parameter_5Step.Initialize(parameterList, -1, 85);
        }
        private void InitGridLaserParameter5Step_2()
        {
            List<GridViewControl_Parameter.ParameterItem> parameterList = new List<GridViewControl_Parameter.ParameterItem>();


            List<int> AddParaIndexList = new List<int>();
            AddParaIndexList.Add(0);
            AddParaIndexList.Add(1);
            AddParaIndexList.Add(2);
            AddParaIndexList.Add(3);
            AddParaIndexList.Add(4);

            List<string> AddParaList = new List<string>();

            AddParaList.Add(BONDER_TASK_PARAM.SHOT_PARAMETER_2_STEP_POWER_5.ToString());
            AddParaList.Add(BONDER_TASK_PARAM.SHOT_PARAMETER_2_STEP_POWER_5.ToString());
            AddParaList.Add(BONDER_TASK_PARAM.SHOT_PARAMETER_2_STEP_POWER_5.ToString());
            AddParaList.Add(BONDER_TASK_PARAM.SHOT_PARAMETER_2_STEP_POWER_5.ToString());
            AddParaList.Add(BONDER_TASK_PARAM.SHOT_PARAMETER_2_STEP_POWER_5.ToString());
            GridViewControl_Parameter.ParameterItem AddParaItem = new GridViewControl_Parameter.ParameterItem(EN_TASK_LIST.BOND_HEAD, AddParaList, AddParaIndexList);
            AddParaItem.DisplayName = "LASER POWER 5STEP";
            parameterList.Add(AddParaItem);

            AddParaList = new List<string>();
            AddParaList.Add(BONDER_TASK_PARAM.SHOT_PARAMETER_2_STEP_TIME_5.ToString());
            AddParaList.Add(BONDER_TASK_PARAM.SHOT_PARAMETER_2_STEP_TIME_5.ToString());
            AddParaList.Add(BONDER_TASK_PARAM.SHOT_PARAMETER_2_STEP_TIME_5.ToString());
            AddParaList.Add(BONDER_TASK_PARAM.SHOT_PARAMETER_2_STEP_TIME_5.ToString());
            AddParaList.Add(BONDER_TASK_PARAM.SHOT_PARAMETER_2_STEP_TIME_5.ToString());
            AddParaItem = new GridViewControl_Parameter.ParameterItem(EN_TASK_LIST.BOND_HEAD, AddParaList, AddParaIndexList);
            AddParaItem.DisplayName = "LASER TIME 5STEP";
            parameterList.Add(AddParaItem);

            gridViewControl_Laser_Parameter_5Step_2.Initialize(parameterList, -1, 85);
        }
        private void SetPowerMinMax()
        {
            bool[] arUsed = new bool[ProtecLaserMananger.GetInstance().ChannelCount];
            for (int nCh = 0; nCh < ProtecLaserMananger.GetInstance().ChannelCount; ++nCh)
            {
                arUsed[nCh] = m_instanceRecipe.GetValue(EN_TASK_LIST.BOND_HEAD.ToString(), BONDER_TASK_PARAM.SHOT_PARAMETER_ENABLE_18.ToString(), nCh, EN_RECIPE_PARAM_TYPE.VALUE, false);
            }

            m_instanceRecipe.SetValue(EN_TASK_LIST.BOND_HEAD.ToString(), BONDER_TASK_PARAM.POWER_MEASURE_WATT.ToString(), 0, EN_RECIPE_PARAM_TYPE.MAX, m_LaserCalManager.GetMaxPower(arUsed).ToString());
            m_instanceRecipe.SetValue(EN_TASK_LIST.BOND_HEAD.ToString(), BONDER_TASK_PARAM.POWER_MEASURE_WATT.ToString(), 0, EN_RECIPE_PARAM_TYPE.MIN, m_LaserCalManager.GetMinPower(arUsed).ToString());
        }
        private void SetPowerMinMax_2()
        {
            bool[] arUsed = new bool[ProtecLaserMananger_2.GetInstance().ChannelCount];
            for (int nCh = 0; nCh < ProtecLaserMananger_2.GetInstance().ChannelCount; ++nCh)
            {
                arUsed[nCh] = m_instanceRecipe.GetValue(EN_TASK_LIST.BOND_HEAD.ToString(), BONDER_TASK_PARAM.SHOT_PARAMETER_2_ENABLE_18.ToString(), nCh, EN_RECIPE_PARAM_TYPE.VALUE, false);
            }

            m_instanceRecipe.SetValue(EN_TASK_LIST.BOND_HEAD.ToString(), BONDER_TASK_PARAM.POWER_MEASURE_2_WATT.ToString(), 0, EN_RECIPE_PARAM_TYPE.MAX, m_LaserCalManager_2.GetMaxPower(arUsed).ToString());
            m_instanceRecipe.SetValue(EN_TASK_LIST.BOND_HEAD.ToString(), BONDER_TASK_PARAM.POWER_MEASURE_2_WATT.ToString(), 0, EN_RECIPE_PARAM_TYPE.MIN, m_LaserCalManager_2.GetMinPower(arUsed).ToString());
        }
        #endregion </INTERNAL>
        private void ClickParameterUndo(object sender, EventArgs e)
        {
            if (m_MessageBox.ShowMessage("Do You Want To Undo Recipe?"))
                m_instanceRecipe.ClearDeferredStorage();

            UpdateParamter();

            InitGridLaserParameter();
            InitGridLaserParameter_2();
        }

        private void ClickParameterSave(object sender, EventArgs e)
        {
            if (m_MessageBox.ShowMessage("Do You Want To Save Recipe?"))
                m_instanceRecipe.ApplyDeferredStorage();

            UpdateParamter();

            UpdatePowerLabel();
            UpdatePowerLabel_2();

            InitGridLaserParameter();
            InitGridLaserParameter_2();
        }

        private void UpdateParamter()
        {
            gridViewControl_Laser_Parameter.UpdateValue();
            gridViewControl_Laser_Parameter_5Step.UpdateValue();
            gridViewControl_Power_Measure_Parameter.UpdateValue();
            
            gridViewControl_Laser_Parameter_2.UpdateValue();
            gridViewControl_Laser_Parameter_5Step_2.UpdateValue();
            gridViewControl_Power_Measure_Parameter_2.UpdateValue();
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
            AddParaItem.DisplayName = "CAL REPEAT COUNT";
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
        private void Click_Close(object sender, EventArgs e)
        {
            m_timerForUpdate.Stop();
            m_pTimerForUpdateGUI.Stop();
            this.Hide();
        }
        private void Form_Monitor_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }
        private void Click_Action_Measure_Manual(object sender, EventArgs e)
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
                case 15:
                    arSelectAction = new string[1][];
                    arSelectTask = new string[] { EN_TASK_LIST.BOND_HEAD.ToString() };
                    arSelectAction[0] = new string[] { Define.DefineEnumProject.Task.BondHead.EN_TASK_ACTION.MEASURE_POWER_2.ToString() };
                    Task.TaskOperator.GetInstance().SetOperation(ref arSelectTask, ref arSelectAction, nRetryTime);
                    break;
                case 16:
                    arSelectAction = new string[1][];
                    arSelectTask = new string[] { EN_TASK_LIST.BOND_HEAD.ToString() };
                    arSelectAction[0] = new string[] { Define.DefineEnumProject.Task.BondHead.EN_TASK_ACTION.MEASURE_VOLT_2.ToString() };
                    Task.TaskOperator.GetInstance().SetOperation(ref arSelectTask, ref arSelectAction, nRetryTime);
                    break;
            }
        }
        private void Click_Action_Cal_Laser_1(object sender, EventArgs e)
        {
            bool[] arUsed = new bool[ProtecLaserMananger.GetInstance().ChannelCount];
            List<int> listUsedChannel = new List<int>();

            for (int nCh = 0; nCh < ProtecLaserMananger.GetInstance().ChannelCount; ++nCh)
            {
                arUsed[nCh] = m_instanceRecipe.GetValue(
                    EN_TASK_LIST.BOND_HEAD.ToString(),
                    BONDER_TASK_PARAM.SHOT_PARAMETER_ENABLE_18.ToString(),
                    nCh,
                    EN_RECIPE_PARAM_TYPE.VALUE,
                    false
                );

                if (arUsed[nCh])
                    listUsedChannel.Add(nCh);
            }

            if (!EquipmentState_.EquipmentState.GetInstance().GetState().Equals(EquipmentState_.EQUIPMENT_STATE.IDLE))
                return;

            Control ctrButton = sender as Control;
            string strAction = ctrButton.Text.Replace("\\n", "");

            // 사용 중인 채널 정보 표시
            string strUsedInfo = listUsedChannel.Count > 0
                ? $"사용 설정된 채널: {string.Join(", ", listUsedChannel.Select(ch => $"CH{ch + 1}"))}"
                : "사용 설정된 채널이 없습니다.";

            // 메시지 출력
            if (!m_MessageBox.ShowMessage($"{strUsedInfo}\n\nDo You Want {strAction}?"))
                return;

            // 채널이 2개 이상 선택되어 있으면 진입 불가
            if (listUsedChannel.Count > 1)
            {
                m_MessageBox.ShowMessage("2개 이상의 채널이 선택되어 있어 작업을 수행할 수 없습니다.\n1개 채널만 선택해주세요.");
                return;
            }

            string[] arSelectTask = new string[] { };
            string[][] arSelectAction = new string[][] { };
            int nRetryTime = 1;

            switch (ctrButton.TabIndex)
            {
                case 7:
                    arSelectAction = new string[1][];
                    arSelectTask = new string[] { EN_TASK_LIST.BOND_HEAD.ToString() };
                    arSelectAction[0] = new string[] { Define.DefineEnumProject.Task.BondHead.EN_TASK_ACTION.CALIBRATION_CHANNEL_POWER.ToString() };
                    Task.TaskOperator.GetInstance().SetOperation(ref arSelectTask, ref arSelectAction, nRetryTime);
                    break;
            }
        }
        private void Click_Action_Cal_Laser_2(object sender, EventArgs e)
        {
            bool[] arUsed = new bool[ProtecLaserMananger.GetInstance().ChannelCount];
            List<int> listUsedChannel = new List<int>();

            for (int nCh = 0; nCh < ProtecLaserMananger.GetInstance().ChannelCount; ++nCh)
            {
                arUsed[nCh] = m_instanceRecipe.GetValue(
                    EN_TASK_LIST.BOND_HEAD.ToString(),
                    BONDER_TASK_PARAM.SHOT_PARAMETER_2_ENABLE_18.ToString(),
                    nCh,
                    EN_RECIPE_PARAM_TYPE.VALUE,
                    false
                );

                if (arUsed[nCh])
                    listUsedChannel.Add(nCh);
            }

            if (!EquipmentState_.EquipmentState.GetInstance().GetState().Equals(EquipmentState_.EQUIPMENT_STATE.IDLE))
                return;

            Control ctrButton = sender as Control;
            string strAction = ctrButton.Text.Replace("\\n", "");

            // 사용 중인 채널 정보 표시
            string strUsedInfo = listUsedChannel.Count > 0
                ? $"사용 설정된 채널: {string.Join(", ", listUsedChannel.Select(ch => $"CH{ch + 1}"))}"
                : "사용 설정된 채널이 없습니다.";

            // 메시지 출력
            if (!m_MessageBox.ShowMessage($"{strUsedInfo}\n\nDo You Want {strAction}?"))
                return;

            // 채널이 2개 이상 선택되어 있으면 진입 불가
            if (listUsedChannel.Count > 1)
            {
                m_MessageBox.ShowMessage("2개 이상의 채널이 선택되어 있어 작업을 수행할 수 없습니다.\n1개 채널만 선택해주세요.");
                return;
            }

            string[] arSelectTask = new string[] { };
            string[][] arSelectAction = new string[][] { };
            int nRetryTime = 1;

            switch (ctrButton.TabIndex)
            {
                case 17:
                    arSelectAction = new string[1][];
                    arSelectTask = new string[] { EN_TASK_LIST.BOND_HEAD.ToString() };
                    arSelectAction[0] = new string[] { Define.DefineEnumProject.Task.BondHead.EN_TASK_ACTION.CALIBRATION_CHANNEL_POWER_2.ToString() };
                    Task.TaskOperator.GetInstance().SetOperation(ref arSelectTask, ref arSelectAction, nRetryTime);
                    break;
            }
        }
    }
}
