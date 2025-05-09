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
using ZedGraph;
using System.IO;

using RunningMain_;
using TaskAction_;

using EQUIPMENT_PARAM = FrameOfSystem3.Recipe.PARAM_EQUIPMENT;
using BONDER_TASK_PARAM = Define.DefineEnumProject.Task.BondHead.PARAM_PROCESS;

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
            InitGridExternalIO();
            TotalCycleTimeCheck();

            InitGridAutoRunParameter();

            InitGridEnableParameter_2();
            InitGridLaserDevice_2();

            InitializeDictionary();
            InitailizeParametrGrid();

            m_timerForUpdate.Interval = 10;
            m_timerForUpdate.Tick += new EventHandler(UpdateTimer);
            InitializeGraph();
            m_timerForUpdate.Start();

            #region Instance
            _Calculator_Instance_m_p = Functional.Form_Calculator.GetInstance();
            m_LaserCalManager = Laser.ProtecLaserChannelCalibration.GetInstance();
            m_LaserCalManager_2 = Laser.ProtecLaserChannelCalibration_2.GetInstance();
            #endregion
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
        enum EN_GRAPH_MODE
        {
            LIVE,
            LOAD,
        }
        enum EN_PLAY_MODE
        {
            STOP,
            PLAY,
            REWIND,
        }
        enum EN_GRAPH_PARAM
        {
            IR_SENSOR_1,
            IR_SENSOR_2,
            IR_SENSOR_3,
            IR_SENSOR_4,
        }
        #endregion
        #region Graph 상수

        private const int m_unMaxLiveCount = 5000;

        private const int m_unMinLiveTemp = 0;
        private const int m_unMaxLiveTemp = 500;

        private const uint m_unMinLiveTotalPower = 0;
        private const uint m_unMaxLiveTotalPower = 12000;

        private const uint m_unMinLiveChPower = 0;
        private const uint m_unMaxLiveChPower = 700;

        private const int m_unMinLiveIR_Scale = 0;
        private const int m_unMaxLiveIR_Scale = 200;

        private const uint m_unMinLiveHeadFlow = 0;
        private const uint m_unMaxLiveHeadFlow = 50;

        private const string m_strGuideLine = "GuideLine";

        private const string m_strSectionTime = "Section Time";
        private const string m_strSectionHighTemp = "Section High Temp";
        private const string m_strSectionLowTemp = "Section Low Temp";

        #endregion</Graph 상수>

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

        private static Timer m_timerForUpdate = new Timer();
        private EN_GRAPH_MODE m_enGraphMode = EN_GRAPH_MODE.LIVE;
        private int m_nCurrentGraphTime = 0;
        private int m_nStepTime = 1;
        private EN_PLAY_MODE m_enPlayMode = EN_PLAY_MODE.STOP;
        private Dictionary<string, PointPairList> m_dicOfGraphList = new Dictionary<string, PointPairList>(); // FOR GUIDE
        private Dictionary<EN_GRAPH_PARAM, RollingPointPairList> m_dicGraph = new Dictionary<EN_GRAPH_PARAM, RollingPointPairList>(); // Channel, Values
        private Dictionary<EN_GRAPH_PARAM, bool> m_dicVisibleItem = new Dictionary<EN_GRAPH_PARAM, bool>();
        private Dictionary<EN_GRAPH_PARAM, Color> m_dicVisibleColor = new Dictionary<EN_GRAPH_PARAM, Color>();
        private Dictionary<EN_GRAPH_PARAM, int[]> m_dicScaleIdnex = new Dictionary<EN_GRAPH_PARAM, int[]>(); // int arry 0 : 그래프 y number, 1: scale index
        private Dictionary<EN_GRAPH_PARAM, double> m_dicValue = new Dictionary<EN_GRAPH_PARAM, double>();
        private Dictionary<EN_GRAPH_PARAM, string> m_dicValueUnit = new Dictionary<EN_GRAPH_PARAM, string>();
        private string m_strWorkLogPath = "";
        private int[] m_arSectionTime = new int[5];
        private double[] m_arSectionHighTemp = new double[5];
        private double[] m_arSectionLowTemp = new double[5];
        private Log.WorkLog m_InstanceOfLaserMonitor = Log.WorkLog.GetInstance();
        private FrameOfSystem3.Config.ConfigAnalogIO m_InstanceOfAnalogIO = FrameOfSystem3.Config.ConfigAnalogIO.GetInstance();
        private Functional.Form_Calculator m_InstanceOfCalculator = Functional.Form_Calculator.GetInstance();

        #region Task
        Task.TaskOperator m_instanceOperator = null;
        private int m_nCountOfTask = 0;
        string[] m_arTaskList = null;
        #endregion

        #region Action
        TaskActionFlow m_instanceActionFlow = null;
        #endregion
        #endregion </FIELD>

        #region 외부인터페이스
        /// <summary>
        /// 2020.08.12 by twkang [ADD] Jog 폼을 생성한다.
        /// </summary>
        public void CreateForm()
        {
            SetSectionArea();
            InitializeGraph();
            m_timerForUpdate.Start();

            this.Size = new Size(1203, 490);

            

            this.Show();
        }
        public void SetLiveMode()
        {
            m_enGraphMode = EN_GRAPH_MODE.LIVE;
            InitializeGraph();
            SetEnableStroll(false);
            SetSectionArea();
        }
        #endregion

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
                    FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(false, (int)EN_DIGITAL_OUT.LD_1_READY);
                    FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(false, (int)EN_DIGITAL_OUT.LD_2_READY);
                    FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(false, (int)EN_DIGITAL_OUT.LD_3_READY);
                    FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(false, (int)EN_DIGITAL_OUT.LD_1_READY_2);
                    FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(false, (int)EN_DIGITAL_OUT.LD_2_READY_2);
                    FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(false, (int)EN_DIGITAL_OUT.LD_3_READY_2);
                    return;
                case 3: // RESET
                    if (!FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().ReadItem(false, (int)EN_DIGITAL_OUT.LD_1_ALARM_CLEAR)
                        || !FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().ReadItem(false, (int)EN_DIGITAL_OUT.LD_2_ALARM_CLEAR)
                        || !FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().ReadItem(false, (int)EN_DIGITAL_OUT.LD_3_ALARM_CLEAR)
                        || !FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().ReadItem(false, (int)EN_DIGITAL_OUT.MONITOR_ALARM_CLEAR)
                        || !FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().ReadItem(false, (int)EN_DIGITAL_OUT.LD_1_ALARM_CLEAR_2)
                        || !FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().ReadItem(false, (int)EN_DIGITAL_OUT.LD_2_ALARM_CLEAR_2)
                        || !FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().ReadItem(false, (int)EN_DIGITAL_OUT.LD_3_ALARM_CLEAR_2)
                        || !FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().ReadItem(false, (int)EN_DIGITAL_OUT.MONITOR_ALARM_CLEAR_2)
                        || !FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().ReadItem(false, (int)EN_DIGITAL_OUT.SAFETY_RESET))
                    {
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(true, (int)EN_DIGITAL_OUT.LD_1_ALARM_CLEAR);
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(true, (int)EN_DIGITAL_OUT.LD_2_ALARM_CLEAR);
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(true, (int)EN_DIGITAL_OUT.LD_3_ALARM_CLEAR);
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(true, (int)EN_DIGITAL_OUT.MONITOR_ALARM_CLEAR);
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(true, (int)EN_DIGITAL_OUT.LD_1_ALARM_CLEAR_2);
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(true, (int)EN_DIGITAL_OUT.LD_2_ALARM_CLEAR_2);
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(true, (int)EN_DIGITAL_OUT.LD_3_ALARM_CLEAR_2);
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(true, (int)EN_DIGITAL_OUT.MONITOR_ALARM_CLEAR_2);
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(true, (int)EN_DIGITAL_OUT.SAFETY_RESET);
                    }
                    else
                    {
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(false, (int)EN_DIGITAL_OUT.LD_1_ALARM_CLEAR);
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(false, (int)EN_DIGITAL_OUT.LD_2_ALARM_CLEAR);
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(false, (int)EN_DIGITAL_OUT.LD_3_ALARM_CLEAR);
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(false, (int)EN_DIGITAL_OUT.MONITOR_ALARM_CLEAR);
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(false, (int)EN_DIGITAL_OUT.LD_1_ALARM_CLEAR_2);
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(false, (int)EN_DIGITAL_OUT.LD_2_ALARM_CLEAR_2);
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(false, (int)EN_DIGITAL_OUT.LD_3_ALARM_CLEAR_2);
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(false, (int)EN_DIGITAL_OUT.MONITOR_ALARM_CLEAR_2);
                        FrameOfSystem3.Config.ConfigDigitalIO.GetInstance().WriteOutput(false, (int)EN_DIGITAL_OUT.SAFETY_RESET);
                    }
                    return;
            }
        }
        //private void Click_RunMode(object sender, EventArgs e)
        //{
        //    string strValue = string.Empty;

        //    if (m_InstanceOfSelectionList.CreateForm(m_groupRunMode.Text, Define.DefineEnumProject.SelectionList.EN_SELECTIONLIST.OPERATION_EQUIPMENT, m_labelRunMode.Text))
        //    {
        //        m_InstanceOfSelectionList.GetResult(ref strValue);

        //        if (m_DicForRunMode.ContainsKey(strValue))
        //        {
        //            Task.TaskOperator.GetInstance().SetRunMode(m_DicForRunMode[strValue]);
        //            m_labelRunMode.Text = Task.TaskOperator.GetInstance().GetRunMode().ToString();
        //        }
        //    }
        //}
        
        #endregion
        #region <OVERRIDE>
        public override void CallFunctionByTimer()
        {
            base.CallFunctionByTimer();
            UpdateAlamCode();
            gridVeiwControl_Laser_Device.UpdateState();

            UpdateAlamCode_2();
            gridVeiwControl_Laser_Device_2.UpdateState();
            gridVeiwControl_External_IO.UpdateState();
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

            UpdatePowerLabel_2();

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
        #region <INITIALIZE>
        private void InitailizeParametrGrid()
        {
            dataGridView.Rows.Clear();
            int nRow = 0;
            foreach (EN_GRAPH_PARAM en in Enum.GetValues(typeof(EN_GRAPH_PARAM)))
            {
                dataGridView.Rows.Add();
                dataGridView[0, nRow].Value = en.ToString().Replace("_", " ");
                dataGridView[0, nRow].Style.BackColor = Color.LightGray;
                dataGridView[0, nRow].Style.SelectionBackColor = Color.LightGray;
                nRow++;
            }
            UpdateGrid();
        }
        private void InitializeDictionary()
        {
            m_dicVisibleItem.Clear();

            //             m_dicVisibleItem.Add(EN_GRAPH_PARAM.PYRO_TEMP_1, m_instanceRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.MONOTORING_TEMP_1_VISIBLE.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, true));
            //             m_dicVisibleItem.Add(EN_GRAPH_PARAM.PYRO_TEMP_2, m_instanceRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.MONOTORING_TEMP_2_VISIBLE.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, true));
            //             m_dicVisibleItem.Add(EN_GRAPH_PARAM.PYRO_TEMP_3, m_instanceRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.MONOTORING_TEMP_3_VISIBLE.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, true));
            //             m_dicVisibleItem.Add(EN_GRAPH_PARAM.PYRO_TEMP_4, m_instanceRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.MONOTORING_TEMP_4_VISIBLE.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, true));
            //             m_dicVisibleItem.Add(EN_GRAPH_PARAM.PYRO_TEMP_5, m_instanceRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.MONOTORING_TEMP_5_VISIBLE.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, true));

            m_dicVisibleItem.Add(EN_GRAPH_PARAM.IR_SENSOR_1, m_instanceRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.MONITORING_IR_SENSOR_1_VISIBLE.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, true));
            m_dicVisibleItem.Add(EN_GRAPH_PARAM.IR_SENSOR_2, m_instanceRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.MONITORING_IR_SENSOR_2_VISIBLE.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, true));
            m_dicVisibleItem.Add(EN_GRAPH_PARAM.IR_SENSOR_3, m_instanceRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.MONITORING_IR_SENSOR_3_VISIBLE.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, true));
            m_dicVisibleItem.Add(EN_GRAPH_PARAM.IR_SENSOR_4, m_instanceRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.MONITORING_IR_SENSOR_4_VISIBLE.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, true));

            m_dicVisibleColor.Clear();

            //             m_dicVisibleColor.Add(EN_GRAPH_PARAM.PYRO_TEMP_1, Color.FromArgb(m_instanceRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.MONOTORING_TEMP_1_COLOR.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0)));
            //             m_dicVisibleColor.Add(EN_GRAPH_PARAM.PYRO_TEMP_2, Color.FromArgb(m_instanceRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.MONOTORING_TEMP_2_COLOR.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0)));
            //             m_dicVisibleColor.Add(EN_GRAPH_PARAM.PYRO_TEMP_3, Color.FromArgb(m_instanceRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.MONOTORING_TEMP_3_COLOR.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0)));
            //             m_dicVisibleColor.Add(EN_GRAPH_PARAM.PYRO_TEMP_4, Color.FromArgb(m_instanceRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.MONOTORING_TEMP_4_COLOR.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0)));
            //             m_dicVisibleColor.Add(EN_GRAPH_PARAM.PYRO_TEMP_5, Color.FromArgb(m_instanceRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.MONOTORING_TEMP_5_COLOR.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0)));

            m_dicVisibleColor.Add(EN_GRAPH_PARAM.IR_SENSOR_1, Color.FromArgb(m_instanceRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.MONITORING_IR_SENSOR_1_COLOR.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0)));
            m_dicVisibleColor.Add(EN_GRAPH_PARAM.IR_SENSOR_2, Color.FromArgb(m_instanceRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.MONITORING_IR_SENSOR_2_COLOR.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0)));
            m_dicVisibleColor.Add(EN_GRAPH_PARAM.IR_SENSOR_3, Color.FromArgb(m_instanceRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.MONITORING_IR_SENSOR_3_COLOR.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0)));
            m_dicVisibleColor.Add(EN_GRAPH_PARAM.IR_SENSOR_4, Color.FromArgb(m_instanceRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.MONITORING_IR_SENSOR_4_COLOR.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0)));



            m_dicValueUnit.Clear();

            //             m_dicValueUnit.Add(EN_GRAPH_PARAM.PYRO_TEMP_1, " ℃");
            //             m_dicValueUnit.Add(EN_GRAPH_PARAM.PYRO_TEMP_2, " ℃");
            //             m_dicValueUnit.Add(EN_GRAPH_PARAM.PYRO_TEMP_3, " ℃");
            //             m_dicValueUnit.Add(EN_GRAPH_PARAM.PYRO_TEMP_4, " ℃");
            //             m_dicValueUnit.Add(EN_GRAPH_PARAM.PYRO_TEMP_5, " ℃");

            m_dicValueUnit.Add(EN_GRAPH_PARAM.IR_SENSOR_1, " ℃");
            m_dicValueUnit.Add(EN_GRAPH_PARAM.IR_SENSOR_2, " ℃");
            m_dicValueUnit.Add(EN_GRAPH_PARAM.IR_SENSOR_3, " ℃");
            m_dicValueUnit.Add(EN_GRAPH_PARAM.IR_SENSOR_4, " ℃");

            m_dicValue.Clear();

            //             m_dicValue.Add(EN_GRAPH_PARAM.PYRO_TEMP_1, 0);
            //             m_dicValue.Add(EN_GRAPH_PARAM.PYRO_TEMP_2, 0);
            //             m_dicValue.Add(EN_GRAPH_PARAM.PYRO_TEMP_3, 0);
            //             m_dicValue.Add(EN_GRAPH_PARAM.PYRO_TEMP_4, 0);
            //             m_dicValue.Add(EN_GRAPH_PARAM.PYRO_TEMP_5, 0);

            m_dicValue.Add(EN_GRAPH_PARAM.IR_SENSOR_1, 0);
            m_dicValue.Add(EN_GRAPH_PARAM.IR_SENSOR_2, 0);
            m_dicValue.Add(EN_GRAPH_PARAM.IR_SENSOR_3, 0);
            m_dicValue.Add(EN_GRAPH_PARAM.IR_SENSOR_4, 0);
        }
        private void InitializeGraph()
        {
            m_tickCount.SetTickCount(1);

            m_dicScaleIdnex.Clear();
            _Graph.GraphPane.CurveList.Clear();

            m_dicGraph.Clear();

            _Graph.IsShowPointValues = true;

            _Graph.GraphPane.Title.IsVisible = false;
            _Graph.GraphPane.Legend.FontSpec.Size = 6;
            _Graph.GraphPane.Legend.IsVisible = true;

            int nTimeMax = m_unMaxLiveCount;

            Dictionary<int, Dictionary<Log.WorkLog.EN_LOG_ITEM, double>> dicLoadedData = m_InstanceOfLaserMonitor.dicLoadedLog;
            if (dicLoadedData.Keys.Count > 0 && m_enGraphMode == EN_GRAPH_MODE.LOAD)
                nTimeMax = dicLoadedData.Keys.Max();

            _Graph.GraphPane.XAxis.Scale.Min = 0;
            _Graph.GraphPane.XAxis.Scale.Max = nTimeMax;

            _Graph.GraphPane.XAxis.Title.IsVisible = false;

            _Graph.GraphPane.YAxisList.Clear(); // Clear existing Y axes

            int Ynumber = 1;
            int YIndex = 0;

            #region IR_SENSOR
            // 하나의 Y축을 사용하여 4개의 IR 센서를 표시합니다.
            if (m_dicVisibleItem[EN_GRAPH_PARAM.IR_SENSOR_1] || m_dicVisibleItem[EN_GRAPH_PARAM.IR_SENSOR_2] || m_dicVisibleItem[EN_GRAPH_PARAM.IR_SENSOR_3] || m_dicVisibleItem[EN_GRAPH_PARAM.IR_SENSOR_4])
            {
                // 기존의 여러 Y축을 하나로 통합
                YAxis yAxis = new YAxis("IR SENSOR (℃)");
                yAxis.Scale.Min = m_unMinLiveIR_Scale;
                yAxis.Scale.Max = m_unMaxLiveIR_Scale;
                yAxis.Title.FontSpec.Size = 18;
                yAxis.Scale.FontSpec.Size = 15;
                yAxis.MinorTic.IsAllTics = false;
                _Graph.GraphPane.YAxisList.Add(yAxis);

                m_dicScaleIdnex.Add(EN_GRAPH_PARAM.IR_SENSOR_1, new int[] { Ynumber, YIndex });
            }
            #endregion /IR_SENSOR

            #region Add DicGraph
            // 하나의 Y축에 4개의 센서를 추가하여 그리기
            foreach (EN_GRAPH_PARAM en in Enum.GetValues(typeof(EN_GRAPH_PARAM)))
            {
                if (m_dicVisibleItem[en] && (en == EN_GRAPH_PARAM.IR_SENSOR_1 || en == EN_GRAPH_PARAM.IR_SENSOR_2 || en == EN_GRAPH_PARAM.IR_SENSOR_3 || en == EN_GRAPH_PARAM.IR_SENSOR_4))
                {
                    m_dicGraph.Add(en, new RollingPointPairList(nTimeMax));

                    var LineItem = _Graph.GraphPane.AddCurve(en.ToString(), m_dicGraph[en], m_dicVisibleColor[en], SymbolType.None);
                    LineItem.Line.Width = 3;
                    LineItem.Label.FontSpec = new FontSpec();
                    LineItem.Label.FontSpec.Size = 9;
                    LineItem.Label.FontSpec.Border.IsVisible = false;

                    LineItem.YAxisIndex = YIndex; // 모두 동일한 Y축을 사용합니다.
                }
            }
            #endregion /Add DicGraph

            if (m_enGraphMode == EN_GRAPH_MODE.LOAD)
            {
                foreach (var kpv in dicLoadedData)
                {
                    // 각 센서 데이터를 하나의 리스트에 추가
                    if (m_dicVisibleItem[EN_GRAPH_PARAM.IR_SENSOR_1])
                    {
                        if (kpv.Value.ContainsKey(Log.WorkLog.EN_LOG_ITEM.IR_SENSOR_1))
                            m_dicGraph[EN_GRAPH_PARAM.IR_SENSOR_1].Add(kpv.Key, kpv.Value[Log.WorkLog.EN_LOG_ITEM.IR_SENSOR_1]);
                        else
                            m_dicGraph[EN_GRAPH_PARAM.IR_SENSOR_1].Add(kpv.Key, 0);
                    }
                    if (m_dicVisibleItem[EN_GRAPH_PARAM.IR_SENSOR_2])
                    {
                        if (kpv.Value.ContainsKey(Log.WorkLog.EN_LOG_ITEM.IR_SENSOR_2))
                            m_dicGraph[EN_GRAPH_PARAM.IR_SENSOR_2].Add(kpv.Key, kpv.Value[Log.WorkLog.EN_LOG_ITEM.IR_SENSOR_2]);
                        else
                            m_dicGraph[EN_GRAPH_PARAM.IR_SENSOR_2].Add(kpv.Key, 0);
                    }
                    if (m_dicVisibleItem[EN_GRAPH_PARAM.IR_SENSOR_3])
                    {
                        if (kpv.Value.ContainsKey(Log.WorkLog.EN_LOG_ITEM.IR_SENSOR_3))
                            m_dicGraph[EN_GRAPH_PARAM.IR_SENSOR_3].Add(kpv.Key, kpv.Value[Log.WorkLog.EN_LOG_ITEM.IR_SENSOR_3]);
                        else
                            m_dicGraph[EN_GRAPH_PARAM.IR_SENSOR_3].Add(kpv.Key, 0);
                    }
                    if (m_dicVisibleItem[EN_GRAPH_PARAM.IR_SENSOR_4])
                    {
                        if (kpv.Value.ContainsKey(Log.WorkLog.EN_LOG_ITEM.IR_SENSOR_4))
                            m_dicGraph[EN_GRAPH_PARAM.IR_SENSOR_4].Add(kpv.Key, kpv.Value[Log.WorkLog.EN_LOG_ITEM.IR_SENSOR_4]);
                        else
                            m_dicGraph[EN_GRAPH_PARAM.IR_SENSOR_4].Add(kpv.Key, 0);
                    }
                }
            }

            _Graph.AxisChange();
            _Graph.Invalidate();
        }
        
        #endregion </INITIALIZE>

        #region UpdateUI
        private void UpdateTimer(object sender, EventArgs e)
        {
            PlayGraph();
            UpdateValue();
            //UpdateLabel();
            Update_Graph();
            UpdateGrid();
            SetCurrentLine();
        }
        //public void UpdateLabel()
        //{
        //    LB_SAVE_STATE.Text = m_InstanceOfLaserMonitor.enStatus.ToString();
        //    if (m_InstanceOfLaserMonitor.enStatus == Log.WorkLog.EN_SAVE_STATUS.WAIT)
        //        btn_Save.Text = "SAVE";
        //    else
        //        btn_Save.Text = "STOP";

        //    switch (m_enGraphMode)
        //    {
        //        case EN_GRAPH_MODE.LIVE:
        //            LB_Time.Text = "";

        //            break;
        //        case EN_GRAPH_MODE.LOAD:
        //            LB_Time.Text = m_nCurrentGraphTime.ToString();

        //            break;
        //    }

        //    LB_STEP.Text = m_nStepTime.ToString();
        //}

        private void UpdateGrid()
        {
            int nRow = 0;
            foreach (EN_GRAPH_PARAM en in Enum.GetValues(typeof(EN_GRAPH_PARAM)))
            {
                dataGridView[1, nRow].Value = m_dicValue[en].ToString("f3") + m_dicValueUnit[en];

                if (m_dicVisibleItem[en])
                {
                    dataGridView[2, nRow].Style.BackColor = m_dicVisibleColor[en];
                    dataGridView[2, nRow].Style.SelectionBackColor = m_dicVisibleColor[en];
                }
                else
                {
                    dataGridView[2, nRow].Style.BackColor = Color.White;
                    dataGridView[2, nRow].Style.SelectionBackColor = Color.White;
                }
                nRow++;
            }
        }
        private void UpdateValue()
        {

            switch (m_enGraphMode)
            {
                case EN_GRAPH_MODE.LIVE:

                    //                     m_dicValue[EN_GRAPH_PARAM.PYRO_TEMP_1] = m_InstanceOfAnalogIO.ReadInputValue((int)EN_ANALOG_IN.TEMP_CH_1);
                    //                     m_dicValue[EN_GRAPH_PARAM.PYRO_TEMP_2] = m_InstanceOfAnalogIO.ReadInputValue((int)EN_ANALOG_IN.TEMP_CH_2);
                    //                     m_dicValue[EN_GRAPH_PARAM.PYRO_TEMP_3] = m_InstanceOfAnalogIO.ReadInputValue((int)EN_ANALOG_IN.TEMP_CH_3);
                    //                     m_dicValue[EN_GRAPH_PARAM.PYRO_TEMP_4] = m_InstanceOfAnalogIO.ReadInputValue((int)EN_ANALOG_IN.TEMP_CH_4);
                    //                     m_dicValue[EN_GRAPH_PARAM.PYRO_TEMP_5] = m_InstanceOfAnalogIO.ReadInputValue((int)EN_ANALOG_IN.TEMP_CH_5);

                    m_dicValue[EN_GRAPH_PARAM.IR_SENSOR_1] = m_InstanceOfAnalogIO.ReadInputValue((int)EN_ANALOG_IN.IR_SENSOR_1);
                    m_dicValue[EN_GRAPH_PARAM.IR_SENSOR_2] = m_InstanceOfAnalogIO.ReadInputValue((int)EN_ANALOG_IN.IR_SENSOR_2);
                    m_dicValue[EN_GRAPH_PARAM.IR_SENSOR_3] = m_InstanceOfAnalogIO.ReadInputValue((int)EN_ANALOG_IN.IR_SENSOR_3);
                    m_dicValue[EN_GRAPH_PARAM.IR_SENSOR_4] = m_InstanceOfAnalogIO.ReadInputValue((int)EN_ANALOG_IN.IR_SENSOR_4);


                    break;
                case EN_GRAPH_MODE.LOAD:
                    Dictionary<int, Dictionary<Log.WorkLog.EN_LOG_ITEM, double>> dicLoadedData = m_InstanceOfLaserMonitor.dicLoadedLog;
                    int nValueTime = m_nCurrentGraphTime;
                    while (!dicLoadedData.ContainsKey(nValueTime))
                    {
                        nValueTime--;
                        if (nValueTime <= 0)
                            break;
                    }

                    //                     m_dicValue[EN_GRAPH_PARAM.PYRO_TEMP_1] = dicLoadedData[nValueTime][Log.WorkLog.EN_LOG_ITEM.PYRO_TEMP_1];
                    //                     m_dicValue[EN_GRAPH_PARAM.PYRO_TEMP_2] = dicLoadedData[nValueTime][Log.WorkLog.EN_LOG_ITEM.PYRO_TEMP_2];
                    //                     m_dicValue[EN_GRAPH_PARAM.PYRO_TEMP_3] = dicLoadedData[nValueTime][Log.WorkLog.EN_LOG_ITEM.PYRO_TEMP_3];
                    //                     m_dicValue[EN_GRAPH_PARAM.PYRO_TEMP_4] = dicLoadedData[nValueTime][Log.WorkLog.EN_LOG_ITEM.PYRO_TEMP_4];
                    //                     m_dicValue[EN_GRAPH_PARAM.PYRO_TEMP_5] = dicLoadedData[nValueTime][Log.WorkLog.EN_LOG_ITEM.PYRO_TEMP_5];
                    //m_dicValue[EN_GRAPH_PARAM.IR_SENSOR_1] = dicLoadedData[nValueTime][Log.WorkLog.EN_LOG_ITEM.IR_SENSOR_1];
                    //m_dicValue[EN_GRAPH_PARAM.IR_SENSOR_2] = dicLoadedData[nValueTime][Log.WorkLog.EN_LOG_ITEM.IR_SENSOR_2];
                    //m_dicValue[EN_GRAPH_PARAM.IR_SENSOR_3] = dicLoadedData[nValueTime][Log.WorkLog.EN_LOG_ITEM.IR_SENSOR_3];
                    //m_dicValue[EN_GRAPH_PARAM.IR_SENSOR_4] = dicLoadedData[nValueTime][Log.WorkLog.EN_LOG_ITEM.IR_SENSOR_4];

                    if (dicLoadedData[nValueTime].ContainsKey(Log.WorkLog.EN_LOG_ITEM.IR_SENSOR_1))
                        m_dicValue[EN_GRAPH_PARAM.IR_SENSOR_1] = dicLoadedData[nValueTime][Log.WorkLog.EN_LOG_ITEM.IR_SENSOR_1];
                    else
                        m_dicValue[EN_GRAPH_PARAM.IR_SENSOR_1] = 0;

                    if (dicLoadedData[nValueTime].ContainsKey(Log.WorkLog.EN_LOG_ITEM.IR_SENSOR_2))
                        m_dicValue[EN_GRAPH_PARAM.IR_SENSOR_2] = dicLoadedData[nValueTime][Log.WorkLog.EN_LOG_ITEM.IR_SENSOR_2];
                    else
                        m_dicValue[EN_GRAPH_PARAM.IR_SENSOR_2] = 0;

                    if (dicLoadedData[nValueTime].ContainsKey(Log.WorkLog.EN_LOG_ITEM.IR_SENSOR_3))
                        m_dicValue[EN_GRAPH_PARAM.IR_SENSOR_3] = dicLoadedData[nValueTime][Log.WorkLog.EN_LOG_ITEM.IR_SENSOR_3];
                    else
                        m_dicValue[EN_GRAPH_PARAM.IR_SENSOR_3] = 0;

                    if (dicLoadedData[nValueTime].ContainsKey(Log.WorkLog.EN_LOG_ITEM.IR_SENSOR_4))
                        m_dicValue[EN_GRAPH_PARAM.IR_SENSOR_4] = dicLoadedData[nValueTime][Log.WorkLog.EN_LOG_ITEM.IR_SENSOR_4];
                    else
                        m_dicValue[EN_GRAPH_PARAM.IR_SENSOR_4] = 0;

                    break;
            }
            // 2025.3.18 by ecchoi [ADD] Graph Test 용 함수
            //TestGraphFluctuation();
        }
        private void TestGraphFluctuation()
        {
            // 2025.3.18 by ecchoi [ADD] Graph Test Value
            double baseValue = 50; // 기본 값
            double fluctuation = 30 * Math.Sin(DateTime.Now.Second / 5.0 * Math.PI); // 5초 간격으로 변동

            m_dicValue[EN_GRAPH_PARAM.IR_SENSOR_1] = baseValue + fluctuation;
            m_dicValue[EN_GRAPH_PARAM.IR_SENSOR_2] = baseValue - fluctuation;
            m_dicValue[EN_GRAPH_PARAM.IR_SENSOR_3] = baseValue + fluctuation / 2;
            m_dicValue[EN_GRAPH_PARAM.IR_SENSOR_4] = baseValue - fluctuation / 2;
        }
        #region Graph
        public void Update_Graph()
        {
            switch (m_enGraphMode)
            {
                case EN_GRAPH_MODE.LIVE:
                    if (m_tickCount.GetTickCount() > m_unMaxLiveCount)
                    {
                        _Graph.GraphPane.XAxis.Scale.Min = m_tickCount.GetTickCount() - m_unMaxLiveCount;
                        _Graph.GraphPane.XAxis.Scale.Max = m_tickCount.GetTickCount();
                    }

                    foreach (EN_GRAPH_PARAM en in Enum.GetValues(typeof(EN_GRAPH_PARAM)))
                    {
                        if (m_dicVisibleItem[en])
                        {
                            m_dicGraph[en].Add(m_tickCount.GetTickCount(), m_dicValue[en]);
                        }
                    }
                    break;
            }
            _Graph.AxisChange();
            _Graph.Invalidate();
        }
        private void SetCurrentLine()
        {
            if (m_enGraphMode == EN_GRAPH_MODE.LIVE)
                return;

            if (m_dicOfGraphList.ContainsKey(m_strGuideLine) == false)
                m_dicOfGraphList.Add(m_strGuideLine, new PointPairList());

            m_dicOfGraphList[m_strGuideLine].Clear();

            m_dicOfGraphList[m_strGuideLine].Add(new PointPair(m_nCurrentGraphTime, 0));
            m_dicOfGraphList[m_strGuideLine].Add(new PointPair(m_nCurrentGraphTime, _Graph.GraphPane.YAxis.Scale.Max));

            LineItem Item = null;
            Item = _Graph.GraphPane.AddCurve(m_strGuideLine, m_dicOfGraphList[m_strGuideLine], Color.Red, SymbolType.None);
            Item.Label.IsVisible = false;

        }
        private void PlayGraph()
        {
            if (m_enGraphMode == EN_GRAPH_MODE.LIVE)
                return;

            switch (m_enPlayMode)
            {
                case EN_PLAY_MODE.PLAY:
                    if (SB_GraphTime.Maximum < SB_GraphTime.Value + m_nStepTime)
                    {
                        m_enPlayMode = EN_PLAY_MODE.STOP;
                        return;
                    }
                    SB_GraphTime.Value += m_nStepTime;
                    break;
                case EN_PLAY_MODE.REWIND:
                    if (SB_GraphTime.Minimum > SB_GraphTime.Value - m_nStepTime)
                    {
                        m_enPlayMode = EN_PLAY_MODE.STOP;
                        return;
                    }
                    SB_GraphTime.Value -= m_nStepTime;
                    break;
            }
            m_nCurrentGraphTime = m_InstanceOfLaserMonitor.dicLoadedLog.Keys.ToArray()[SB_GraphTime.Value];

        }
        private void SetSectionArea()
        {
            return;
        }
        #endregion
        #endregion

        #region Event
        private void Click_Save(object sender, EventArgs e)
        {
            if (EquipmentState_.EquipmentState.GetInstance().GetState() != EquipmentState_.EQUIPMENT_STATE.IDLE
                && EquipmentState_.EquipmentState.GetInstance().GetState() != EquipmentState_.EQUIPMENT_STATE.PAUSE)
                return;

            Control ctrl = sender as Control;

            switch (m_InstanceOfLaserMonitor.enStatus)
            {
                case Log.WorkLog.EN_SAVE_STATUS.WAIT:
                    m_enGraphMode = EN_GRAPH_MODE.LIVE;
                    InitializeGraph();
                    SetSectionArea();
                    m_InstanceOfLaserMonitor.SaveStart();
                    break;

                case Log.WorkLog.EN_SAVE_STATUS.GET_DATA:
                    m_InstanceOfLaserMonitor.SaveStop();

                    break;
            }

            _Graph.Refresh();
        }

        private void Click_Live(object sender, EventArgs e)
        {
            SetLiveMode();
        }

        private void Click_Load(object sender, EventArgs e)
        {
            OpenFileDialog ofDialog = new OpenFileDialog();

            if (m_strWorkLogPath == "")
            {
                string strFolderName = string.Format("{0}-{1}-{2}", System.DateTime.Now.Year, System.DateTime.Now.Month, System.DateTime.Now.Day);
                m_strWorkLogPath = string.Format("{0}\\{1}", Define.DefineConstant.FilePath.FILEPATH_LASER_WORK_LOG, strFolderName);
                DirectoryInfo di = new DirectoryInfo(m_strWorkLogPath);
                if (!di.Exists)
                    m_strWorkLogPath = Define.DefineConstant.FilePath.FILEPATH_LASER_WORK_LOG;
            }
            ofDialog.InitialDirectory = m_strWorkLogPath;

            if (DialogResult.OK != ofDialog.ShowDialog())
            {
                return;
            }

            string fullPathName = ofDialog.FileName;
            string fileName = ofDialog.SafeFileName;
            string pathName = fullPathName.Substring(0, (fullPathName.Length - fileName.Length));

            m_strWorkLogPath = pathName;

            m_enGraphMode = EN_GRAPH_MODE.LOAD;
            string strFileName = ofDialog.FileName;

            if (!m_InstanceOfLaserMonitor.ReadLog(strFileName))
                return;

            InitializeGraph();

            SetSectionArea();

            SB_GraphTime.SmallChange = m_nStepTime;

            SB_GraphTime.Minimum = 0;
            SB_GraphTime.Maximum = m_InstanceOfLaserMonitor.dicLoadedLog.Count - 1;
            m_nCurrentGraphTime = 0;

            SetEnableStroll(true);
        }
        private void SetEnableStroll(bool bEnable)
        {
            SB_GraphTime.Enabled = bEnable;
            //LB_STEP.Enabled = bEnable;
            //BT_Pause.Enabled = bEnable;
            //BT_Play.Enabled = bEnable;
            //BT_Rewind.Enabled = bEnable;
            SB_GraphTime.LargeChange = m_nStepTime;
            SB_GraphTime.SmallChange = m_nStepTime;
        }
        private void ScrollTime(object sender, ScrollEventArgs e)
        {
            if (m_enGraphMode == EN_GRAPH_MODE.LOAD)
                m_nCurrentGraphTime = m_InstanceOfLaserMonitor.dicLoadedLog.Keys.ToArray()[e.NewValue];
            SetCurrentLine();
        }
        private void Click_Graph_Control(object sender, EventArgs e)
        {
            Control ctr = sender as Control;

            switch (ctr.TabIndex)
            {
                case 0:
                    m_enPlayMode = EN_PLAY_MODE.REWIND;
                    break;
                case 1:
                    m_enPlayMode = EN_PLAY_MODE.STOP;
                    break;
                case 2:
                    m_enPlayMode = EN_PLAY_MODE.PLAY;
                    break;

                case 10:
                    if (m_InstanceOfCalculator.CreateForm(m_nStepTime.ToString(), "1", "1000"))
                    {
                        m_InstanceOfCalculator.GetResult(ref m_nStepTime);
                        SB_GraphTime.LargeChange = m_nStepTime;
                        SB_GraphTime.SmallChange = m_nStepTime;
                    }
                    break;
            }
        }
        #endregion

        private void ClearGraph()
        {
            if (m_enGraphMode == EN_GRAPH_MODE.LOAD)
                return;
            foreach (EN_GRAPH_PARAM en in Enum.GetValues(typeof(EN_GRAPH_PARAM)))
            {
                m_dicGraph[en].Clear();
            }
        }

        private void Click_Close(object sender, EventArgs e)
        {
            m_timerForUpdate.Stop();
            this.Hide();
        }

        private void ClickGrid(object sender, DataGridViewCellMouseEventArgs e)
        {
            int nRow = e.RowIndex;
            EN_GRAPH_PARAM enParam = (EN_GRAPH_PARAM)nRow;

            if (e.Button == MouseButtons.Right)
            {
                ColorDialog cd = new ColorDialog();

                if (cd.ShowDialog() == DialogResult.OK)
                {
                    m_dicVisibleColor[enParam] = cd.Color;

                    string strPara = "";
                    switch (enParam)
                    {
                        case EN_GRAPH_PARAM.IR_SENSOR_1:
                            strPara = EQUIPMENT_PARAM.MONITORING_IR_SENSOR_1_COLOR.ToString();
                            break;
                        case EN_GRAPH_PARAM.IR_SENSOR_2:
                            strPara = EQUIPMENT_PARAM.MONITORING_IR_SENSOR_2_COLOR.ToString();
                            break;
                        case EN_GRAPH_PARAM.IR_SENSOR_3:
                            strPara = EQUIPMENT_PARAM.MONITORING_IR_SENSOR_3_COLOR.ToString();
                            break;
                        case EN_GRAPH_PARAM.IR_SENSOR_4:
                            strPara = EQUIPMENT_PARAM.MONITORING_IR_SENSOR_4_COLOR.ToString();
                            break;
                    }

                    m_instanceRecipe.SetValue(EN_RECIPE_TYPE.EQUIPMENT, strPara, 0, EN_RECIPE_PARAM_TYPE.VALUE, m_dicVisibleColor[enParam].ToArgb().ToString());
                }
            }
            else
            {
                m_dicVisibleItem[enParam] = !m_dicVisibleItem[enParam];

                string strPara = "";
                switch (enParam)
                {
                    case EN_GRAPH_PARAM.IR_SENSOR_1:
                        strPara = EQUIPMENT_PARAM.MONITORING_IR_SENSOR_1_VISIBLE.ToString();
                        break;
                    case EN_GRAPH_PARAM.IR_SENSOR_2:
                        strPara = EQUIPMENT_PARAM.MONITORING_IR_SENSOR_2_VISIBLE.ToString();
                        break;
                    case EN_GRAPH_PARAM.IR_SENSOR_3:
                        strPara = EQUIPMENT_PARAM.MONITORING_IR_SENSOR_3_VISIBLE.ToString();
                        break;
                    case EN_GRAPH_PARAM.IR_SENSOR_4:
                        strPara = EQUIPMENT_PARAM.MONITORING_IR_SENSOR_4_VISIBLE.ToString();
                        break;
                }
                m_instanceRecipe.SetValue(EN_RECIPE_TYPE.EQUIPMENT, strPara, 0, EN_RECIPE_PARAM_TYPE.VALUE, m_dicVisibleItem[enParam].ToString());
            }
            InitializeGraph();
            UpdateGrid();
        }

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

            gridViewControl_Enable_Parameter.Initialize(parameterList, -1, 90);
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

            gridViewControl_Enable_Parameter_2.Initialize(parameterList, -1, 90);
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
        private void InitGridExternalIO()
        {
            List<GridVeiwControl_Device.ControlItem> ControlList = new List<GridVeiwControl_Device.ControlItem>();

            GridVeiwControl_Device.ControlItem AddControlItem;

            List<int> lstIndex = new List<int>();

            lstIndex = new List<int>();
            lstIndex.Add((int)EN_DIGITAL_IN.FROM_PLC_IN_1_ALARM);
            AddControlItem = new GridVeiwControl_Device.ControlItem(lstIndex, GridVeiwControl_Device.EN_CONTROL_TYPE.DIGITAL_INPUT);
            AddControlItem.Name = "ALARM";
            ControlList.Add(AddControlItem);

            lstIndex = new List<int>();
            lstIndex.Add((int)EN_DIGITAL_IN.FROM_PLC_IN_2_LASER_ON);
            AddControlItem = new GridVeiwControl_Device.ControlItem(lstIndex, GridVeiwControl_Device.EN_CONTROL_TYPE.DIGITAL_INPUT);
            AddControlItem.Name = "LASER ON";
            ControlList.Add(AddControlItem);

            lstIndex = new List<int>();
            lstIndex.Add((int)EN_DIGITAL_IN.FROM_PLC_IN_3_FEED_ON);
            AddControlItem = new GridVeiwControl_Device.ControlItem(lstIndex, GridVeiwControl_Device.EN_CONTROL_TYPE.DIGITAL_INPUT);
            AddControlItem.Name = "FEED MODE";
            ControlList.Add(AddControlItem);

            lstIndex = new List<int>();
            lstIndex.Add((int)EN_DIGITAL_OUT.TO_PLC_OUT_1_ALARM);
            AddControlItem = new GridVeiwControl_Device.ControlItem(lstIndex, GridVeiwControl_Device.EN_CONTROL_TYPE.DIGITAL_OUTPUT);
            AddControlItem.Name = "ALARM";
            ControlList.Add(AddControlItem);

            lstIndex = new List<int>();
            lstIndex.Add((int)EN_DIGITAL_OUT.TO_PLC_OUT_2_LASER_ON_REPEAT);
            AddControlItem = new GridVeiwControl_Device.ControlItem(lstIndex, GridVeiwControl_Device.EN_CONTROL_TYPE.DIGITAL_OUTPUT);
            AddControlItem.Name = "LASER ON";
            ControlList.Add(AddControlItem);

            lstIndex = new List<int>();
            lstIndex.Add((int)EN_DIGITAL_OUT.TO_PLC_OUT_3_FEED_ON_REPEAT);
            AddControlItem = new GridVeiwControl_Device.ControlItem(lstIndex, GridVeiwControl_Device.EN_CONTROL_TYPE.DIGITAL_OUTPUT);
            AddControlItem.Name = "FEED MODE";
            ControlList.Add(AddControlItem);


            gridVeiwControl_External_IO.Initialize(ControlList);

            List<string> lstHeader = new List<string>();

            lstHeader.Add("");
            lstHeader.Add("INOUT");

            gridVeiwControl_External_IO.ShowHeader(lstHeader);
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
        private void InitGridAutoRunParameter()
        {
            List<GridViewControl_Parameter.ParameterItem> parameterList = new List<GridViewControl_Parameter.ParameterItem>();

            GridViewControl_Parameter.ParameterItem AddParaItem;

            AddParaItem = new GridViewControl_Parameter.ParameterItem
                (EN_TASK_LIST.BOND_HEAD, BONDER_TASK_PARAM.LASER_ON_DELAY.ToString());
            AddParaItem.DisplayName = "ON DELAY";
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem
                (EN_TASK_LIST.BOND_HEAD, BONDER_TASK_PARAM.LASER_OFF_DELAY.ToString());
            AddParaItem.DisplayName = "OFF DELAY";
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem
                (EN_TASK_LIST.BOND_HEAD, BONDER_TASK_PARAM.LASER_WORK_COUNT.ToString());
            AddParaItem.DisplayName = "REPEAT COUNT";
            parameterList.Add(AddParaItem);

            //AddParaItem = new GridViewControl_Parameter.ParameterItem
            //    (EN_TASK_LIST.BOND_HEAD, BONDER_TASK_PARAM.BYPASS_ON_DELAY.ToString());
            //AddParaItem.DisplayName = "BYPASS ON TIME";
            //parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem
                (EN_TASK_LIST.BOND_HEAD, BONDER_TASK_PARAM.AUTO_SAFETY_LIMIT.ToString());
            AddParaItem.DisplayName = "AUTO SAFETY LIMIT";
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem
                (EN_TASK_LIST.BOND_HEAD, BONDER_TASK_PARAM.FEED_MODE_LIMIT.ToString());
            AddParaItem.DisplayName = "FEED MODE LIMIT";
            parameterList.Add(AddParaItem);

            gridViewControl_AutoRun_Parameter.Initialize(parameterList, -1, 80);
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
            bool bLaserUsed_1 = m_instanceRecipe.GetValue(EN_TASK_LIST.BOND_HEAD.ToString(), BONDER_TASK_PARAM.LASER_1_USED.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, true);
            bool bLaserUsed_2 = m_instanceRecipe.GetValue(EN_TASK_LIST.BOND_HEAD.ToString(), BONDER_TASK_PARAM.LASER_2_USED.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, true);

            if (!EquipmentState_.EquipmentState.GetInstance().GetState().Equals(EquipmentState_.EQUIPMENT_STATE.IDLE))
                return;

            Control ctrButton = sender as Control;
            string strAction = ctrButton.Text.Replace("\\n", "");

            // 레이저 사용 상태 팝업 메시지
            string strLaserStatus = $"Laser 사용 설정 상태:\n - LASER 1: {(bLaserUsed_1 ? "사용" : "미사용")}\n - LASER 2: {(bLaserUsed_2 ? "사용" : "미사용")}";
            strLaserStatus += $"\n\nDo You Want {strAction}?";

            if (!m_MessageBox.ShowMessage(strLaserStatus))
                return;

            // 둘 다 미사용일 경우
            if (!bLaserUsed_1 && !bLaserUsed_2)
            {
                m_MessageBox.ShowMessage("LD1과 LD2 모두 사용 안 함으로 설정되어 있어 레이저 작업을 실행할 수 없습니다.");
                return;
            }

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
                case 10:
                    arSelectAction = new string[1][];
                    arSelectTask = new string[] { EN_TASK_LIST.BOND_HEAD.ToString() };
                    arSelectAction[0] = new string[] { Define.DefineEnumProject.Task.BondHead.EN_TASK_ACTION.LASER_WORK_1CYCLE.ToString() };
                    Task.TaskOperator.GetInstance().SetOperation(ref arSelectTask, ref arSelectAction, nRetryTime);
                    break;
            }
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
                m_lblAlarmCodePort1_2.Text = ExternalDevice.Serial.ProtecLaserController_2.EN_CONTROL_ALARM_2.NONE.ToString();
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
                m_lblAlarmCodePort2_2.Text = ExternalDevice.Serial.ProtecLaserController_2.EN_CONTROL_ALARM_2.NONE.ToString();
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
                m_lblAlarmCodePort3_2.Text = ExternalDevice.Serial.ProtecLaserController_2.EN_CONTROL_ALARM_2.NONE.ToString();
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
            if (m_MessageBox.ShowMessage("Do You Want To Undo Recipe?"))
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
            TotalCycleTimeCheck();
        }
        private void TotalCycleTimeCheck()
        {
            double laserOnDelayMs = m_instanceRecipe.GetValue(EN_TASK_LIST.BOND_HEAD.ToString(),
                BONDER_TASK_PARAM.LASER_ON_DELAY.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

            double laserOffDelayMs = m_instanceRecipe.GetValue(EN_TASK_LIST.BOND_HEAD.ToString(),
                BONDER_TASK_PARAM.LASER_OFF_DELAY.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

            int repeatCount = m_instanceRecipe.GetValue(EN_TASK_LIST.BOND_HEAD.ToString(),
                BONDER_TASK_PARAM.LASER_WORK_COUNT.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 1);

            double totalCycleTime = (laserOnDelayMs + laserOffDelayMs) * repeatCount;

            m_lblCycleTotal.Text = $"{totalCycleTime}";

            double feedModeLimit = 1000 * m_instanceRecipe.GetValue(EN_TASK_LIST.BOND_HEAD.ToString(),
                BONDER_TASK_PARAM.FEED_MODE_LIMIT.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

            if (totalCycleTime > feedModeLimit)
            {
                string strWarning = $"TOTAL CYCLE TIME({totalCycleTime} ms) 이 FEED_MODE_LIMIT({feedModeLimit} ms) 를 초과했습니다. 계속 진행하시겠습니까?";
                if (!m_MessageBox.ShowMessage(strWarning))
                    return;
            }
        }

        private void UpdateParamter()
        {
            gridViewControl_Enable_Parameter.UpdateValue();
            gridViewControl_Enable_Parameter_2.UpdateValue();
            gridViewControl_AutoRun_Parameter.UpdateValue();
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

        
    }
}