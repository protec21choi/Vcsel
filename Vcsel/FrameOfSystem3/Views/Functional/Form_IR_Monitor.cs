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

using Define.DefineEnumProject.Task;

using EQUIPMENT_PARAM = FrameOfSystem3.Recipe.PARAM_EQUIPMENT;
using BONDHEAD_PARAM = Define.DefineEnumProject.Task.BondHead.PARAM_PROCESS;


namespace FrameOfSystem3.Views.Functional
{
	public partial class Form_IR_Monitor : Form
	{
        private Form_IR_Monitor()
		{
			InitializeComponent();

            InitializeDictionary();
            InitailizeParametrGrid();

            m_timerForUpdate.Interval = 10;
            m_timerForUpdate.Tick += new EventHandler(UpdateTimer);
		}

		#region 싱글톤
        private static Form_IR_Monitor _Instance;
        public static Form_IR_Monitor GetInstance()
		{
            if (_Instance == null)
                _Instance = new Form_IR_Monitor();
			return _Instance;
		}
		#endregion

		#region 열거형
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
           
            //sensor 제거
//             PYRO_TEMP_1,
//             PYRO_TEMP_2,
//             PYRO_TEMP_3,
//             PYRO_TEMP_4,
//             PYRO_TEMP_5,

            //BLOCK_VAC,

            //HEAD_FLOW,

            IR_SENSOR_1,
            IR_SENSOR_2,
            IR_SENSOR_3,
            IR_SENSOR_4,
        }

		#endregion

		#region 상수

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

		#endregion

		#region 변수
        private FrameOfSystem3.Recipe.Recipe m_InstanceOfRecipe = FrameOfSystem3.Recipe.Recipe.GetInstance();
		private FrameOfSystem3.Config.ConfigAnalogIO m_InstanceOfAnalogIO = FrameOfSystem3.Config.ConfigAnalogIO.GetInstance();
        private FrameOfSystem3.Config.ConfigDigitalIO m_InstanceOfDigitalIO = FrameOfSystem3.Config.ConfigDigitalIO.GetInstance();
        private FrameOfSystem3.Config.ConfigMotion m_InstanceOfMotion = FrameOfSystem3.Config.ConfigMotion.GetInstance();

        private Log.WorkLog m_InstanceOfLaserMonitor = Log.WorkLog.GetInstance();
        private Functional.Form_Calculator m_InstanceOfCalculator = Functional.Form_Calculator.GetInstance();

		private static Timer m_timerForUpdate				= new Timer();
        private TickCounter_.TickCounter m_TickCount        = new TickCounter_.TickCounter();

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
        #endregion

		#region 외부인터페이스
		/// <summary>
		/// 2020.08.12 by twkang [ADD] Jog 폼을 생성한다.
		/// </summary>
		public void CreateForm()
		{
            SetSectionArea();
            InitializeGraph();

            this.Size = new Size(1203, 490);

            m_timerForUpdate.Start();

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

        #region 내부 인터페이스
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
            
//             m_dicVisibleItem.Add(EN_GRAPH_PARAM.PYRO_TEMP_1, m_InstanceOfRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.MONOTORING_TEMP_1_VISIBLE.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, true));
//             m_dicVisibleItem.Add(EN_GRAPH_PARAM.PYRO_TEMP_2, m_InstanceOfRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.MONOTORING_TEMP_2_VISIBLE.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, true));
//             m_dicVisibleItem.Add(EN_GRAPH_PARAM.PYRO_TEMP_3, m_InstanceOfRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.MONOTORING_TEMP_3_VISIBLE.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, true));
//             m_dicVisibleItem.Add(EN_GRAPH_PARAM.PYRO_TEMP_4, m_InstanceOfRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.MONOTORING_TEMP_4_VISIBLE.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, true));
//             m_dicVisibleItem.Add(EN_GRAPH_PARAM.PYRO_TEMP_5, m_InstanceOfRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.MONOTORING_TEMP_5_VISIBLE.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, true));

            m_dicVisibleItem.Add(EN_GRAPH_PARAM.IR_SENSOR_1, m_InstanceOfRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.MONITORING_IR_SENSOR_1_VISIBLE.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, true));
            m_dicVisibleItem.Add(EN_GRAPH_PARAM.IR_SENSOR_2, m_InstanceOfRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.MONITORING_IR_SENSOR_2_VISIBLE.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, true));
            m_dicVisibleItem.Add(EN_GRAPH_PARAM.IR_SENSOR_3, m_InstanceOfRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.MONITORING_IR_SENSOR_3_VISIBLE.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, true));
            m_dicVisibleItem.Add(EN_GRAPH_PARAM.IR_SENSOR_4, m_InstanceOfRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.MONITORING_IR_SENSOR_4_VISIBLE.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, true));

            m_dicVisibleColor.Clear();

//             m_dicVisibleColor.Add(EN_GRAPH_PARAM.PYRO_TEMP_1, Color.FromArgb(m_InstanceOfRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.MONOTORING_TEMP_1_COLOR.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0)));
//             m_dicVisibleColor.Add(EN_GRAPH_PARAM.PYRO_TEMP_2, Color.FromArgb(m_InstanceOfRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.MONOTORING_TEMP_2_COLOR.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0)));
//             m_dicVisibleColor.Add(EN_GRAPH_PARAM.PYRO_TEMP_3, Color.FromArgb(m_InstanceOfRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.MONOTORING_TEMP_3_COLOR.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0)));
//             m_dicVisibleColor.Add(EN_GRAPH_PARAM.PYRO_TEMP_4, Color.FromArgb(m_InstanceOfRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.MONOTORING_TEMP_4_COLOR.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0)));
//             m_dicVisibleColor.Add(EN_GRAPH_PARAM.PYRO_TEMP_5, Color.FromArgb(m_InstanceOfRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.MONOTORING_TEMP_5_COLOR.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0)));

            m_dicVisibleColor.Add(EN_GRAPH_PARAM.IR_SENSOR_1, Color.FromArgb(m_InstanceOfRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.MONITORING_IR_SENSOR_1_COLOR.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0)));
            m_dicVisibleColor.Add(EN_GRAPH_PARAM.IR_SENSOR_2, Color.FromArgb(m_InstanceOfRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.MONITORING_IR_SENSOR_2_COLOR.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0)));
            m_dicVisibleColor.Add(EN_GRAPH_PARAM.IR_SENSOR_3, Color.FromArgb(m_InstanceOfRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.MONITORING_IR_SENSOR_3_COLOR.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0)));
            m_dicVisibleColor.Add(EN_GRAPH_PARAM.IR_SENSOR_4, Color.FromArgb(m_InstanceOfRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.MONITORING_IR_SENSOR_4_COLOR.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0)));



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
            m_TickCount.SetTickCount(1);

            m_dicScaleIdnex.Clear();
            _Graph.GraphPane.CurveList.Clear();


            m_dicGraph.Clear();

            _Graph.IsShowPointValues = true;
            
            
            _Graph.GraphPane.Title.IsVisible = false;
            _Graph.GraphPane.Legend.FontSpec.Size = 6;
            _Graph.GraphPane.Legend.IsVisible = false;

            int nTimeMax = m_unMaxLiveCount;

            Dictionary<int, Dictionary<Log.WorkLog.EN_LOG_ITEM, double>> dicLoadedData = m_InstanceOfLaserMonitor.dicLoadedLog;
            if (dicLoadedData.Keys.Count > 0 && m_enGraphMode == EN_GRAPH_MODE.LOAD)
                nTimeMax = dicLoadedData.Keys.Max();

            _Graph.GraphPane.XAxis.Scale.Min = 0;
            _Graph.GraphPane.XAxis.Scale.Max = nTimeMax;

            _Graph.GraphPane.XAxis.Title.IsVisible = false;

            _Graph.GraphPane.YAxisList.Clear();
            _Graph.GraphPane.Y2AxisList.Clear();

            int Ynumber = 1;
            int Y1Index = 0;
            int Y2Index = 0;


            #region Temp
//              if (m_dicVisibleItem[EN_GRAPH_PARAM.PYRO_TEMP_1]
//                 || m_dicVisibleItem[EN_GRAPH_PARAM.PYRO_TEMP_2]
//                 || m_dicVisibleItem[EN_GRAPH_PARAM.PYRO_TEMP_3]
//                 || m_dicVisibleItem[EN_GRAPH_PARAM.PYRO_TEMP_4]
//                 || m_dicVisibleItem[EN_GRAPH_PARAM.PYRO_TEMP_5])
//             {
//                 if (Ynumber == 1)
//                 {
// 
//                     YAxis yAxis = new YAxis("TEMP (℃)");
//                     yAxis.Scale.Min = m_unMinLiveTemp;
//                     yAxis.Scale.Max = m_unMaxLiveTemp;
//                     yAxis.Title.FontSpec.Size = 13;
//                     yAxis.Scale.FontSpec.Size = 10;
//                     yAxis.MinorTic.IsAllTics = false;
//                     _Graph.GraphPane.YAxisList.Add(yAxis);
// 
//                     m_dicScaleIdnex.Add(EN_GRAPH_PARAM.PYRO_TEMP_1, new int[] { Ynumber, Y1Index });
//                     m_dicScaleIdnex.Add(EN_GRAPH_PARAM.PYRO_TEMP_2, new int[] { Ynumber, Y1Index });
//                     m_dicScaleIdnex.Add(EN_GRAPH_PARAM.PYRO_TEMP_3, new int[] { Ynumber, Y1Index });
//                     m_dicScaleIdnex.Add(EN_GRAPH_PARAM.PYRO_TEMP_4, new int[] { Ynumber, Y1Index });
//                     m_dicScaleIdnex.Add(EN_GRAPH_PARAM.PYRO_TEMP_5, new int[] { Ynumber, Y1Index });
// 
//                     Ynumber = 2;
//                     Y1Index++;
//                 }
//                 else
//                 {
//                     Y2Axis yAxis = new Y2Axis("TEMP (℃)");
//                     yAxis.Scale.Min = m_unMinLiveTemp;
//                     yAxis.Scale.Max = m_unMaxLiveTemp;
//                     yAxis.Title.FontSpec.Size = 13;
//                     yAxis.Scale.FontSpec.Size = 10;
//                     yAxis.IsVisible = true;
//                     yAxis.MinorTic.IsAllTics = false;
//                     _Graph.GraphPane.Y2AxisList.Add(yAxis);
// 
//                     m_dicScaleIdnex.Add(EN_GRAPH_PARAM.PYRO_TEMP_1, new int[] { Ynumber, Y2Index });
//                     m_dicScaleIdnex.Add(EN_GRAPH_PARAM.PYRO_TEMP_2, new int[] { Ynumber, Y2Index });
//                     m_dicScaleIdnex.Add(EN_GRAPH_PARAM.PYRO_TEMP_3, new int[] { Ynumber, Y2Index });
//                     m_dicScaleIdnex.Add(EN_GRAPH_PARAM.PYRO_TEMP_4, new int[] { Ynumber, Y2Index });
//                     m_dicScaleIdnex.Add(EN_GRAPH_PARAM.PYRO_TEMP_5, new int[] { Ynumber, Y2Index });
// 
//                     Ynumber = 1;
//                     Y2Index++;
//                 }
//             }
            #endregion /Temp

            #region IR_SENSOR
            if (m_dicVisibleItem[EN_GRAPH_PARAM.IR_SENSOR_1])
            {
                if (Ynumber == 1)
                {

                    YAxis yAxis = new YAxis("IR_1 (℃)");
                    yAxis.Scale.Min = m_unMinLiveIR_Scale;
                    yAxis.Scale.Max = m_unMaxLiveIR_Scale;
                    yAxis.Title.FontSpec.Size = 13;
                    yAxis.Scale.FontSpec.Size = 10;
                    yAxis.MinorTic.IsAllTics = false;
                    _Graph.GraphPane.YAxisList.Add(yAxis);

                    m_dicScaleIdnex.Add(EN_GRAPH_PARAM.IR_SENSOR_1, new int[] { Ynumber, Y1Index });

                    Ynumber = 2;
                    Y1Index++;
                }
                else
                {
                    Y2Axis yAxis = new Y2Axis("IR_1 (℃)");
                    yAxis.Scale.Min = m_unMinLiveIR_Scale;
                    yAxis.Scale.Max = m_unMaxLiveIR_Scale;
                    yAxis.Title.FontSpec.Size = 13;
                    yAxis.Scale.FontSpec.Size = 10;
                    yAxis.IsVisible = true;
                    yAxis.MinorTic.IsAllTics = false;
                    _Graph.GraphPane.Y2AxisList.Add(yAxis);

                    m_dicScaleIdnex.Add(EN_GRAPH_PARAM.IR_SENSOR_1, new int[] { Ynumber, Y2Index });

                    Ynumber = 1;
                    Y2Index++;
                }
            }
            if (m_dicVisibleItem[EN_GRAPH_PARAM.IR_SENSOR_2])
            {
                if (Ynumber == 1)
                {

                    YAxis yAxis = new YAxis("IR_2 (℃)");
                    yAxis.Scale.Min = m_unMinLiveIR_Scale;
                    yAxis.Scale.Max = m_unMaxLiveIR_Scale;
                    yAxis.Title.FontSpec.Size = 13;
                    yAxis.Scale.FontSpec.Size = 10;
                    yAxis.MinorTic.IsAllTics = false;
                    _Graph.GraphPane.YAxisList.Add(yAxis);

                    m_dicScaleIdnex.Add(EN_GRAPH_PARAM.IR_SENSOR_2, new int[] { Ynumber, Y1Index });

                    Ynumber = 2;
                    Y1Index++;
                }
                else
                {
                    Y2Axis yAxis = new Y2Axis("IR_2 (℃)");
                    yAxis.Scale.Min = m_unMinLiveIR_Scale;
                    yAxis.Scale.Max = m_unMaxLiveIR_Scale;
                    yAxis.Title.FontSpec.Size = 13;
                    yAxis.Scale.FontSpec.Size = 10;
                    yAxis.IsVisible = true;
                    yAxis.MinorTic.IsAllTics = false;
                    _Graph.GraphPane.Y2AxisList.Add(yAxis);

                    m_dicScaleIdnex.Add(EN_GRAPH_PARAM.IR_SENSOR_2, new int[] { Ynumber, Y2Index });

                    Ynumber = 1;
                    Y2Index++;
                }
            }
            if (m_dicVisibleItem[EN_GRAPH_PARAM.IR_SENSOR_3])
            {
                if (Ynumber == 1)
                {

                    YAxis yAxis = new YAxis("IR_3 (℃)");
                    yAxis.Scale.Min = m_unMinLiveIR_Scale;
                    yAxis.Scale.Max = m_unMaxLiveIR_Scale;
                    yAxis.Title.FontSpec.Size = 13;
                    yAxis.Scale.FontSpec.Size = 10;
                    yAxis.MinorTic.IsAllTics = false;
                    _Graph.GraphPane.YAxisList.Add(yAxis);

                    m_dicScaleIdnex.Add(EN_GRAPH_PARAM.IR_SENSOR_3, new int[] { Ynumber, Y1Index });

                    Ynumber = 2;
                    Y1Index++;
                }
                else
                {
                    Y2Axis yAxis = new Y2Axis("IR_3 (℃)");
                    yAxis.Scale.Min = m_unMinLiveIR_Scale;
                    yAxis.Scale.Max = m_unMaxLiveIR_Scale;
                    yAxis.Title.FontSpec.Size = 13;
                    yAxis.Scale.FontSpec.Size = 10;
                    yAxis.IsVisible = true;
                    yAxis.MinorTic.IsAllTics = false;
                    _Graph.GraphPane.Y2AxisList.Add(yAxis);

                    m_dicScaleIdnex.Add(EN_GRAPH_PARAM.IR_SENSOR_3, new int[] { Ynumber, Y2Index });

                    Ynumber = 1;
                    Y2Index++;
                }
            }
            if (m_dicVisibleItem[EN_GRAPH_PARAM.IR_SENSOR_4])
            {
                if (Ynumber == 1)
                {

                    YAxis yAxis = new YAxis("IR_4 (℃)");
                    yAxis.Scale.Min = m_unMinLiveIR_Scale;
                    yAxis.Scale.Max = m_unMaxLiveIR_Scale;
                    yAxis.Title.FontSpec.Size = 13;
                    yAxis.Scale.FontSpec.Size = 10;
                    yAxis.MinorTic.IsAllTics = false;
                    _Graph.GraphPane.YAxisList.Add(yAxis);

                    m_dicScaleIdnex.Add(EN_GRAPH_PARAM.IR_SENSOR_4, new int[] { Ynumber, Y1Index });

                    Ynumber = 2;
                    Y1Index++;
                }
                else
                {
                    Y2Axis yAxis = new Y2Axis("IR_4 (℃)");
                    yAxis.Scale.Min = m_unMinLiveIR_Scale;
                    yAxis.Scale.Max = m_unMaxLiveIR_Scale;
                    yAxis.Title.FontSpec.Size = 13;
                    yAxis.Scale.FontSpec.Size = 10;
                    yAxis.IsVisible = true;
                    yAxis.MinorTic.IsAllTics = false;
                    _Graph.GraphPane.Y2AxisList.Add(yAxis);

                    m_dicScaleIdnex.Add(EN_GRAPH_PARAM.IR_SENSOR_4, new int[] { Ynumber, Y2Index });

                    Ynumber = 1;
                    Y2Index++;
                }
            }
            #endregion /IR_SENSOR




            #region Add DicGraph
            foreach (EN_GRAPH_PARAM en in Enum.GetValues(typeof(EN_GRAPH_PARAM)))
            {
                if (m_dicVisibleItem[en])
                {
                    m_dicGraph.Add(en, new RollingPointPairList(nTimeMax));
                    var LineItem = _Graph.GraphPane.AddCurve(en.ToString(), m_dicGraph[en], m_dicVisibleColor[en], SymbolType.None);
                    LineItem.Line.Width = 3;
                    LineItem.Line.Width = 3;
                    LineItem.Label.FontSpec = new FontSpec();
                    LineItem.Label.FontSpec.Size = 9;
                    LineItem.Label.FontSpec.Border.IsVisible = false;

                    if (m_dicScaleIdnex[en][0] == 2)
                        LineItem.IsY2Axis = true;
                    LineItem.YAxisIndex = m_dicScaleIdnex[en][1];
                }
            }
            #endregion /Add DicGraph

            if (m_enGraphMode == EN_GRAPH_MODE.LOAD)
            {
                foreach (var kpv in dicLoadedData)
                {
                    
//                     if (m_dicVisibleItem[EN_GRAPH_PARAM.PYRO_TEMP_1])
//                         m_dicGraph[EN_GRAPH_PARAM.PYRO_TEMP_1].Add(kpv.Key, kpv.Value[Log.WorkLog.EN_LOG_ITEM.PYRO_TEMP_1]);
//                     if (m_dicVisibleItem[EN_GRAPH_PARAM.PYRO_TEMP_2])
//                         m_dicGraph[EN_GRAPH_PARAM.PYRO_TEMP_2].Add(kpv.Key, kpv.Value[Log.WorkLog.EN_LOG_ITEM.PYRO_TEMP_2]);
//                     if (m_dicVisibleItem[EN_GRAPH_PARAM.PYRO_TEMP_3])
//                         m_dicGraph[EN_GRAPH_PARAM.PYRO_TEMP_3].Add(kpv.Key, kpv.Value[Log.WorkLog.EN_LOG_ITEM.PYRO_TEMP_3]);
//                     if (m_dicVisibleItem[EN_GRAPH_PARAM.PYRO_TEMP_4])
//                         m_dicGraph[EN_GRAPH_PARAM.PYRO_TEMP_4].Add(kpv.Key, kpv.Value[Log.WorkLog.EN_LOG_ITEM.PYRO_TEMP_4]);
//                     if (m_dicVisibleItem[EN_GRAPH_PARAM.PYRO_TEMP_5])
//                         m_dicGraph[EN_GRAPH_PARAM.PYRO_TEMP_5].Add(kpv.Key, kpv.Value[Log.WorkLog.EN_LOG_ITEM.PYRO_TEMP_5]);

                    if (m_dicVisibleItem[EN_GRAPH_PARAM.IR_SENSOR_1])
                    {
                        //Log에 추후에 추가되어서 없는 경우 Load하기 위해
                        if (kpv.Value.ContainsKey(Log.WorkLog.EN_LOG_ITEM.IR_SENSOR_1))
                            m_dicGraph[EN_GRAPH_PARAM.IR_SENSOR_1].Add(kpv.Key, kpv.Value[Log.WorkLog.EN_LOG_ITEM.IR_SENSOR_1]);
                        else
                            m_dicGraph[EN_GRAPH_PARAM.IR_SENSOR_1].Add(kpv.Key, 0);
                    }
                    if (m_dicVisibleItem[EN_GRAPH_PARAM.IR_SENSOR_2])
                    {
                        //Log에 추후에 추가되어서 없는 경우 Load하기 위해
                        if (kpv.Value.ContainsKey(Log.WorkLog.EN_LOG_ITEM.IR_SENSOR_2))
                            m_dicGraph[EN_GRAPH_PARAM.IR_SENSOR_2].Add(kpv.Key, kpv.Value[Log.WorkLog.EN_LOG_ITEM.IR_SENSOR_2]);
                        else
                            m_dicGraph[EN_GRAPH_PARAM.IR_SENSOR_2].Add(kpv.Key, 0);
                    }
                    if (m_dicVisibleItem[EN_GRAPH_PARAM.IR_SENSOR_3])
                    {
                        //Log에 추후에 추가되어서 없는 경우 Load하기 위해
                        if (kpv.Value.ContainsKey(Log.WorkLog.EN_LOG_ITEM.IR_SENSOR_3))
                            m_dicGraph[EN_GRAPH_PARAM.IR_SENSOR_3].Add(kpv.Key, kpv.Value[Log.WorkLog.EN_LOG_ITEM.IR_SENSOR_3]);
                        else
                            m_dicGraph[EN_GRAPH_PARAM.IR_SENSOR_3].Add(kpv.Key, 0);
                    }
                    if (m_dicVisibleItem[EN_GRAPH_PARAM.IR_SENSOR_4])
                    {
                        //Log에 추후에 추가되어서 없는 경우 Load하기 위해
                        if (kpv.Value.ContainsKey(Log.WorkLog.EN_LOG_ITEM.IR_SENSOR_4))
                            m_dicGraph[EN_GRAPH_PARAM.IR_SENSOR_4].Add(kpv.Key, kpv.Value[Log.WorkLog.EN_LOG_ITEM.IR_SENSOR_4]);
                        else
                            m_dicGraph[EN_GRAPH_PARAM.IR_SENSOR_4].Add(kpv.Key, 0);
                    }
                }
            }
            if (Y1Index == 0)
            {
                YAxis yAxis = new YAxis("");
                yAxis.IsVisible = false;
                _Graph.GraphPane.YAxisList.Add(yAxis);
            }
            if (Y2Index == 0)
            {
                Y2Axis yAxis = new Y2Axis("");
                yAxis.IsVisible = false;
                _Graph.GraphPane.Y2AxisList.Add(yAxis);
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
            UpdateLabel();
            Update_Graph();
            UpdateGrid();
            SetCurrentLine();
        }
        public void UpdateLabel()
        {
            LB_SAVE_STATE.Text = m_InstanceOfLaserMonitor.enStatus.ToString();
            if (m_InstanceOfLaserMonitor.enStatus == Log.WorkLog.EN_SAVE_STATUS.WAIT)
                btn_Save.Text = "SAVE";
            else
                btn_Save.Text = "STOP";

            switch (m_enGraphMode)
            {
                case EN_GRAPH_MODE.LIVE:
                    LB_Time.Text = "";
                   
                    break;
                case EN_GRAPH_MODE.LOAD:
                    LB_Time.Text = m_nCurrentGraphTime.ToString();
                
                    break;
            }

            LB_STEP.Text = m_nStepTime.ToString();
        }

        private void UpdateGrid()
        {
            int nRow = 0;
            foreach (EN_GRAPH_PARAM en in Enum.GetValues(typeof(EN_GRAPH_PARAM)))
            {
                dataGridView[1, nRow].Value = m_dicValue[en].ToString("f3") + m_dicValueUnit[en];

                if(m_dicVisibleItem[en])
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
            TestGraphFluctuation();
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
                    if (m_TickCount.GetTickCount() > m_unMaxLiveCount)
                    {
                        _Graph.GraphPane.XAxis.Scale.Min = m_TickCount.GetTickCount() - m_unMaxLiveCount;
                        _Graph.GraphPane.XAxis.Scale.Max = m_TickCount.GetTickCount();
                    }

                    foreach (EN_GRAPH_PARAM en in Enum.GetValues(typeof(EN_GRAPH_PARAM)))
                    {
                        if (m_dicVisibleItem[en])
                        {
                            m_dicGraph[en].Add(m_TickCount.GetTickCount(), m_dicValue[en]);
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
//             for (int nIndex = 0; nIndex < 5; nIndex++)
//             {
//                 if (m_dicOfGraphList.ContainsKey(m_strSectionHighTemp + nIndex.ToString()) == false)
//                     m_dicOfGraphList.Add(m_strSectionHighTemp + nIndex.ToString(), new PointPairList());
// 
//                 m_dicOfGraphList[m_strSectionHighTemp + nIndex.ToString()].Clear();
// 
//                 if (m_dicOfGraphList.ContainsKey(m_strSectionLowTemp + nIndex.ToString()) == false)
//                     m_dicOfGraphList.Add(m_strSectionLowTemp + nIndex.ToString(), new PointPairList());
// 
//                 m_dicOfGraphList[m_strSectionLowTemp + nIndex.ToString()].Clear();
// 
//                 m_arSectionTime[nIndex] = m_InstanceOfRecipe.GetValue(EN_TASK_LIST.BOND_HEAD.ToString(), BONDHEAD_PARAM.TEMPERATURE_SAFTY_AREA_TIME_5.ToString(), nIndex, EN_RECIPE_PARAM_TYPE.VALUE, 0);
//                 m_arSectionHighTemp[nIndex] = m_InstanceOfRecipe.GetValue(EN_TASK_LIST.BOND_HEAD.ToString(), BONDHEAD_PARAM.TEMPERATURE_SAFTY_AREA_HIGH_LIMIT_5.ToString(), nIndex, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
//                 m_arSectionLowTemp[nIndex] = m_InstanceOfRecipe.GetValue(EN_TASK_LIST.BOND_HEAD.ToString(), BONDHEAD_PARAM.TEMPERATURE_SAFTY_AREA_LOW_LIMIT_5.ToString(), nIndex, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
//             }
// 
//             for (int nIndex = 0; nIndex < 6; nIndex++) // time Line 은 하나 더 많음
//             {
//                 if (m_dicOfGraphList.ContainsKey(m_strSectionTime + nIndex.ToString()) == false)
//                     m_dicOfGraphList.Add(m_strSectionTime + nIndex.ToString(), new PointPairList());
// 
//                 m_dicOfGraphList[m_strSectionTime + nIndex.ToString()].Clear();
//             }
// 
//             if (m_enGraphMode == EN_GRAPH_MODE.LIVE)
//                 return;
// 
//             //pyro temp에 Axis Sacle 설정
//             bool bY2Axis = false;
//             EN_GRAPH_PARAM enTempScale = EN_GRAPH_PARAM.PYRO_TEMP_1;
//             if (m_dicScaleIdnex.ContainsKey(EN_GRAPH_PARAM.PYRO_TEMP_1))
//                 enTempScale = EN_GRAPH_PARAM.PYRO_TEMP_1;
//             else if (m_dicScaleIdnex.ContainsKey(EN_GRAPH_PARAM.PYRO_TEMP_2))
//                 enTempScale = EN_GRAPH_PARAM.PYRO_TEMP_2;
//             else if (m_dicScaleIdnex.ContainsKey(EN_GRAPH_PARAM.PYRO_TEMP_3))
//                 enTempScale = EN_GRAPH_PARAM.PYRO_TEMP_3;
//             else if (m_dicScaleIdnex.ContainsKey(EN_GRAPH_PARAM.PYRO_TEMP_4))
//                 enTempScale = EN_GRAPH_PARAM.PYRO_TEMP_4;
//             else if (m_dicScaleIdnex.ContainsKey(EN_GRAPH_PARAM.PYRO_TEMP_5))
//                 enTempScale = EN_GRAPH_PARAM.PYRO_TEMP_5;
//             else
//                 return;
// 
//             if (m_dicScaleIdnex[enTempScale][0] == 2)
//                 bY2Axis = true;
//             int nYAxisIndex = m_dicScaleIdnex[enTempScale][1];
// 
//             int nSectionStartTime = Log.WorkLog.GetInstance().nLaserStartTime;
//             int nSectionEndTime = nSectionStartTime;
//             for (int nIndex = 0; nIndex < 6; nIndex++)
//             {
//                 LineItem Item = null;
//                 if (nIndex == 5 || m_arSectionTime[nIndex] == 0)
//                 {
//                     if (nIndex == 0)
//                         return;
//                     else
//                     {
//                         m_dicOfGraphList[m_strSectionTime + nIndex.ToString()].Add(new PointPair(nSectionEndTime, 0));
//                         m_dicOfGraphList[m_strSectionTime + nIndex.ToString()].Add(new PointPair(nSectionEndTime, _Graph.GraphPane.YAxis.Scale.Max));
// 
//                         Item = _Graph.GraphPane.AddCurve(m_strSectionTime + nIndex.ToString(), m_dicOfGraphList[m_strGuideLine], Color.Red, SymbolType.None);
//                         Item.Label.IsVisible = false;
//                         Item.IsY2Axis = bY2Axis;
//                         Item.YAxisIndex = nYAxisIndex;
//                         return;
//                     }
//                 }
// 
//                 nSectionEndTime += m_arSectionTime[nIndex];
// 
//                 m_dicOfGraphList[m_strSectionTime + nIndex.ToString()].Add(new PointPair(nSectionStartTime, 0));
//                 m_dicOfGraphList[m_strSectionTime + nIndex.ToString()].Add(new PointPair(nSectionStartTime, _Graph.GraphPane.YAxis.Scale.Max));
// 
//                 Item = _Graph.GraphPane.AddCurve(m_strSectionTime + nIndex.ToString(), m_dicOfGraphList[m_strGuideLine], Color.Red, SymbolType.None);
//                 Item.Label.IsVisible = false;
//                 Item.IsY2Axis = bY2Axis;
//                 Item.YAxisIndex = nYAxisIndex;
// 
//                 m_dicOfGraphList[m_strSectionHighTemp + nIndex.ToString()].Add(new PointPair(nSectionStartTime, m_arSectionHighTemp[nIndex]));
//                 m_dicOfGraphList[m_strSectionHighTemp + nIndex.ToString()].Add(new PointPair(nSectionEndTime, m_arSectionHighTemp[nIndex]));
// 
//                 Item = _Graph.GraphPane.AddCurve(m_strSectionHighTemp + nIndex.ToString(), m_dicOfGraphList[m_strGuideLine], Color.Red, SymbolType.None);
//                 Item.Label.IsVisible = false;
//                 Item.IsY2Axis = bY2Axis;
//                 Item.YAxisIndex = nYAxisIndex;
// 
//                 m_dicOfGraphList[m_strSectionLowTemp + nIndex.ToString()].Add(new PointPair(nSectionStartTime, m_arSectionLowTemp[nIndex]));
//                 m_dicOfGraphList[m_strSectionLowTemp + nIndex.ToString()].Add(new PointPair(nSectionEndTime, m_arSectionLowTemp[nIndex]));
// 
//                 Item = _Graph.GraphPane.AddCurve(m_strSectionLowTemp + nIndex.ToString(), m_dicOfGraphList[m_strGuideLine], Color.Red, SymbolType.None);
//                 Item.Label.IsVisible = false;
//                 Item.IsY2Axis = bY2Axis;
//                 Item.YAxisIndex = nYAxisIndex;
// 
//                 nSectionStartTime = nSectionEndTime;
//             }
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
            LB_STEP.Enabled = bEnable;
            BT_Pause.Enabled = bEnable;
            BT_Play.Enabled = bEnable;
            BT_Rewind.Enabled = bEnable;
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
        #endregion

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
                        

//                         case EN_GRAPH_PARAM.PYRO_TEMP_1:
//                             strPara = EQUIPMENT_PARAM.MONOTORING_TEMP_1_COLOR.ToString();
//                             break;
//                         case EN_GRAPH_PARAM.PYRO_TEMP_2:
//                             strPara = EQUIPMENT_PARAM.MONOTORING_TEMP_2_COLOR.ToString();
//                             break;
//                         case EN_GRAPH_PARAM.PYRO_TEMP_3:
//                             strPara = EQUIPMENT_PARAM.MONOTORING_TEMP_3_COLOR.ToString();
//                             break;
//                         case EN_GRAPH_PARAM.PYRO_TEMP_4:
//                             strPara = EQUIPMENT_PARAM.MONOTORING_TEMP_4_COLOR.ToString();
//                             break;
//                         case EN_GRAPH_PARAM.PYRO_TEMP_5:
//                             strPara = EQUIPMENT_PARAM.MONOTORING_TEMP_5_COLOR.ToString();
//                             break;

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

                    m_InstanceOfRecipe.SetValue(EN_RECIPE_TYPE.EQUIPMENT, strPara, 0, EN_RECIPE_PARAM_TYPE.VALUE, m_dicVisibleColor[enParam].ToArgb().ToString());
                }
            }
            else
            {
                m_dicVisibleItem[enParam] = !m_dicVisibleItem[enParam];

                string strPara = "";
                switch (enParam)
                {
//                     case EN_GRAPH_PARAM.PYRO_TEMP_1:
//                         strPara = EQUIPMENT_PARAM.MONOTORING_TEMP_1_VISIBLE.ToString();
//                         break;
//                     case EN_GRAPH_PARAM.PYRO_TEMP_2:
//                         strPara = EQUIPMENT_PARAM.MONOTORING_TEMP_2_VISIBLE.ToString();
//                         break;
//                     case EN_GRAPH_PARAM.PYRO_TEMP_3:
//                         strPara = EQUIPMENT_PARAM.MONOTORING_TEMP_3_VISIBLE.ToString();
//                         break;
//                     case EN_GRAPH_PARAM.PYRO_TEMP_4:
//                         strPara = EQUIPMENT_PARAM.MONOTORING_TEMP_4_VISIBLE.ToString();
//                         break;
//                     case EN_GRAPH_PARAM.PYRO_TEMP_5:
//                         strPara = EQUIPMENT_PARAM.MONOTORING_TEMP_5_VISIBLE.ToString();
//                         break;

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

                m_InstanceOfRecipe.SetValue(EN_RECIPE_TYPE.EQUIPMENT, strPara, 0, EN_RECIPE_PARAM_TYPE.VALUE, m_dicVisibleItem[enParam].ToString());
            }
            InitializeGraph();
            UpdateGrid();
        }

        private void Form_Monitor_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }

       
    }
}
