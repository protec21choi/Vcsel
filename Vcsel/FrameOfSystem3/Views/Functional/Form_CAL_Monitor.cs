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
	public partial class Form_CAL_Monitor : Form
	{
        private Form_CAL_Monitor()
		{
			InitializeComponent();

            m_ZedGraph.Visible = FrameOfSystem3.Config.SystemConfig.GetInstance().PowermeterGraphVisible;
            #region recovery
            RunningTask_.RunningTask pTempTask = null;
            Task.TaskOperator.GetInstance().GetTaskInstance(Define.DefineEnumProject.Task.EN_TASK_LIST.BOND_HEAD.ToString(), ref pTempTask);
            m_TaskBonder_Instance = pTempTask as Task.TaskBondHead;
            #endregion

            UpdatePowerMeasureResult();
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

        #region 열거형

        #endregion

        #region 변수
        private Task.TaskBondHead m_TaskBonder_Instance = null;
        private static Timer m_timerForUpdate = new Timer();
        private TickCounter_.TickCounter m_TickCount = new TickCounter_.TickCounter();
        Functional.Form_MessageBox m_MessageBox = Functional.Form_MessageBox.GetInstance();
        #endregion

        #region 외부인터페이스
        /// <summary>
        /// 2020.08.12 by twkang [ADD] Jog 폼을 생성한다.
        /// </summary>
        public void CreateForm()
        {
            InitializeGraph();

            this.Size = new Size(1203, 431);

            m_timerForUpdate.Start();

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

        private void Click_Close(object sender, EventArgs e)
        {
            m_timerForUpdate.Stop();
            this.Hide();
        }
        private void Form_Monitor_Resize(object sender, EventArgs e)
        {
            this.Refresh();
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
                    arSelectAction = new string[2][];
                    arSelectTask = new string[] { EN_TASK_LIST.BOND_HEAD.ToString(), EN_TASK_LIST.BOND_HEAD.ToString() };
                    arSelectAction[0] = new string[] { null, Define.DefineEnumProject.Task.BondHead.EN_TASK_ACTION.LASER_WORK.ToString() };
                    arSelectAction[1] = new string[] { Define.DefineEnumProject.Task.BondHead.EN_TASK_ACTION.LASER_WORK_2.ToString(), null };
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
                case 17:
                    arSelectAction = new string[1][];
                    arSelectTask = new string[] { EN_TASK_LIST.BOND_HEAD.ToString() };
                    arSelectAction[0] = new string[] { Define.DefineEnumProject.Task.BondHead.EN_TASK_ACTION.CALIBRATION_CHANNEL_POWER_2.ToString() };
                    Task.TaskOperator.GetInstance().SetOperation(ref arSelectTask, ref arSelectAction, nRetryTime);
                    break;
                case 18:
                    arSelectAction = new string[1][];
                    arSelectTask = new string[] { EN_TASK_LIST.BOND_HEAD.ToString() };
                    arSelectAction[0] = new string[] { Define.DefineEnumProject.Task.BondHead.EN_TASK_ACTION.SHORT_TEST_2.ToString() };
                    Task.TaskOperator.GetInstance().SetOperation(ref arSelectTask, ref arSelectAction, nRetryTime);
                    break;
            }
        }
    }
}
