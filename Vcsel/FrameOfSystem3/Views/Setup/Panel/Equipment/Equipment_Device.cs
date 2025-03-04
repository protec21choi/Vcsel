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
using Define.DefineEnumProject.Task;
using Define.DefineEnumProject.Laser;
using Define.DefineEnumProject.Laser.Power;

using FrameOfSystem3.Component;
using FrameOfSystem3.Recipe;

using EQUIPMENT_PARAM = FrameOfSystem3.Recipe.PARAM_EQUIPMENT;
using BONDER_TASK_PARAM = Define.DefineEnumProject.Task.BondHead.PARAM_PROCESS;
using WORKZONE_TASK_PARAM = Define.DefineEnumProject.Task.WorkZone.PARAM_PROCESS;

using RecipeManager_;

namespace FrameOfSystem3.Views.Setup.Equipment
{
    public partial class Equipment_Device : UserControl, ISetupPanel
    {
        #region Consturct
        public Equipment_Device()
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

            InitalizeGridVeiw();

		}
        #endregion

		#region Enum
		
		#endregion

		#region Constants
        private readonly Color c_clrControlLebel = Color.SteelBlue;
        private readonly Color c_clrMonitorLebel = Color.LightGray;
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
            gridViewControl_FFU_Parameter.UpdateValue();
            gridViewControl_Heater_Parameter.UpdateValue();
          
			this.Show();
        }
        public void Deactivation()
        {
			this.Hide();
        }
        public void CallFunction()
        {
            UpdateHeaterGridView();
            UpdateChillerGridView();
            UpdateFFUGridView();

        }
        #endregion

        #region Internal Interface
        private void InitalizeGridVeiw()
        {
            List<string> AddParaList;
            GridViewControl_Parameter.ParameterItem AddParaItem;

            List<GridViewControl_Parameter.ParameterItem> parameterList = new List<GridViewControl_Parameter.ParameterItem>();

            AddParaList = new List<string>();
            AddParaList.Add(WORKZONE_TASK_PARAM.HEATER_TARGET_TEMP.ToString());
            AddParaItem = new GridViewControl_Parameter.ParameterItem(EN_TASK_LIST.WORK_ZONE, AddParaList);
            AddParaItem.DisplayName = "BLOCK TEMP";
            //AddParaItem.AfterSetParameter = SetBlockTemp;
            parameterList.Add(AddParaItem);

            AddParaList = new List<string>();
            AddParaList.Add(WORKZONE_TASK_PARAM.HEATER_OFFSET_TEMP.ToString());
            AddParaItem = new GridViewControl_Parameter.ParameterItem(EN_TASK_LIST.WORK_ZONE, AddParaList);
            AddParaItem.DisplayName = "BLOCK TEMP OFFSET";
            //AddParaItem.AfterSetParameter = SetBlockOffset;
            parameterList.Add(AddParaItem);

            //             AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.WORK_BLOCK_CH_OFFSET_8, 0);
            //             AddParaItem.DisplayName = "BLOCK CH1 OFFSET";
            //             AddParaItem.AfterSetParameter = SetBlockOffset;
            //             parameterList.Add(AddParaItem);
            // 
            //             AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.WORK_BLOCK_CH_OFFSET_8, 1);
            //             AddParaItem.DisplayName = "BLOCK CH2 OFFSET";
            //             AddParaItem.AfterSetParameter = SetBlockOffset;
            //             parameterList.Add(AddParaItem);
            // 
            //               AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.WORK_BLOCK_CH_OFFSET_8, 2);
            //             AddParaItem.DisplayName = "BLOCK CH3 OFFSET";
            //             AddParaItem.AfterSetParameter = SetBlockOffset;
            //             parameterList.Add(AddParaItem);
            // 
            //               AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.WORK_BLOCK_CH_OFFSET_8, 3);
            //             AddParaItem.DisplayName = "BLOCK CH4 OFFSET";
            //             AddParaItem.AfterSetParameter = SetBlockOffset;
            //             parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.WORK_BLOCK_TOLERANCE_MAX, 0);
            AddParaItem.DisplayName = "BLOCK PLUS TOLERANCE";
           // AddParaItem.AfterSetParameter = SetBlockTolerance;
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.WORK_BLOCK_TOLERANCE_MIN, 0);
            AddParaItem.DisplayName = "BLOCK MINUS TOLERANCE";
            //AddParaItem.AfterSetParameter = SetBlockTolerance;
            parameterList.Add(AddParaItem);

            gridViewControl_Heater_Parameter.Initialize(parameterList);

            int nRow = 0;
            dataGridView_Heater.Rows.Clear();

            dataGridView_Heater.Rows.Add();
            dataGridView_Heater[0, nRow].Value = "BLOCK HEATER ON";
            dataGridView_Heater[0, nRow].Style.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridView_Heater[0, nRow].Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridView_Heater[0, nRow].Style.BackColor = c_clrControlLebel;
            dataGridView_Heater[0, nRow].Style.SelectionBackColor = c_clrControlLebel;
            nRow++;

            dataGridView_Heater.Rows.Add();
            dataGridView_Heater[0, nRow].Value = "BLOCK TEMP";
            dataGridView_Heater[0, nRow].Style.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridView_Heater[0, nRow].Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridView_Heater[0, nRow].Style.BackColor = c_clrMonitorLebel;
            dataGridView_Heater[0, nRow].Style.SelectionBackColor = c_clrMonitorLebel;
            dataGridView_Heater[1, nRow].Style.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridView_Heater[1, nRow].Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            nRow++;

            dataGridView_Heater.Rows.Add();
            dataGridView_Heater[0, nRow].Value = "BLOCK CH1 TEMP";
            dataGridView_Heater[0, nRow].Style.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridView_Heater[0, nRow].Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridView_Heater[0, nRow].Style.BackColor = c_clrMonitorLebel;
            dataGridView_Heater[0, nRow].Style.SelectionBackColor = c_clrMonitorLebel;
            dataGridView_Heater[1, nRow].Style.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridView_Heater[1, nRow].Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            nRow++;

            dataGridView_Heater.Rows.Add();
            dataGridView_Heater[0, nRow].Value = "BLOCK CH2 TEMP";
            dataGridView_Heater[0, nRow].Style.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridView_Heater[0, nRow].Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridView_Heater[0, nRow].Style.BackColor = c_clrMonitorLebel;
            dataGridView_Heater[0, nRow].Style.SelectionBackColor = c_clrMonitorLebel;
            dataGridView_Heater[1, nRow].Style.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridView_Heater[1, nRow].Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            nRow++;
            // 
            //             dataGridView_Heater.Rows.Add();
            //             dataGridView_Heater[0, nRow].Value = "BLOCK CH3 TEMP";
            //             dataGridView_Heater[0, nRow].Style.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            //             dataGridView_Heater[0, nRow].Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            //             dataGridView_Heater[0, nRow].Style.BackColor = c_clrMonitorLebel;
            //             dataGridView_Heater[0, nRow].Style.SelectionBackColor = c_clrMonitorLebel;
            //             dataGridView_Heater[1, nRow].Style.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            //             dataGridView_Heater[1, nRow].Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            //             nRow++;
            // 
            //             dataGridView_Heater.Rows.Add();
            //             dataGridView_Heater[0, nRow].Value = "BLOCK CH4 TEMP";
            //             dataGridView_Heater[0, nRow].Style.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            //             dataGridView_Heater[0, nRow].Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            //             dataGridView_Heater[0, nRow].Style.BackColor = c_clrMonitorLebel;
            //             dataGridView_Heater[0, nRow].Style.SelectionBackColor = c_clrMonitorLebel;
            //             dataGridView_Heater[1, nRow].Style.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            //             dataGridView_Heater[1, nRow].Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            //             nRow++;

            nRow = 0;
            dataGridView_Chiller.Rows.Clear();

            dataGridView_Chiller.Rows.Add();
            dataGridView_Chiller[0, nRow].Value = "CHILLER ON";
            dataGridView_Chiller[0, nRow].Style.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridView_Chiller[0, nRow].Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridView_Chiller[0, nRow].Style.BackColor = c_clrControlLebel;
            dataGridView_Chiller[0, nRow].Style.SelectionBackColor = c_clrControlLebel;
            nRow++;

            dataGridView_Chiller.Rows.Add();
            dataGridView_Chiller[0, nRow].Value = "CHILLER TEMP";
            dataGridView_Chiller[0, nRow].Style.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridView_Chiller[0, nRow].Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridView_Chiller[0, nRow].Style.BackColor = c_clrMonitorLebel;
            dataGridView_Chiller[0, nRow].Style.SelectionBackColor = c_clrMonitorLebel;
            dataGridView_Chiller[1, nRow].Style.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridView_Chiller[1, nRow].Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            nRow++;

            dataGridView_Chiller.Rows.Add();
            dataGridView_Chiller[0, nRow].Value = "CHILLER ALARM";
            dataGridView_Chiller[0, nRow].Style.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridView_Chiller[0, nRow].Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridView_Chiller[0, nRow].Style.BackColor = c_clrMonitorLebel;
            dataGridView_Chiller[0, nRow].Style.SelectionBackColor = c_clrMonitorLebel;
            dataGridView_Chiller[1, nRow].Style.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridView_Chiller[1, nRow].Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            nRow++;

            parameterList = new List<GridViewControl_Parameter.ParameterItem>();
            AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.FFU_USE, 0);
            AddParaItem.ParameterSettingType = Define.DefineEnumBase.Component.EN_PARAMETER_SETTING_TYPE.TRUE_FALSE;
            AddParaItem.DisplayName = "FFU USE";
            AddParaItem.AfterSetParameter = SetFFUUsed;
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.FFU_FULL_SPEED);
            AddParaItem.DisplayName = "FFU FULL SPEED";
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.FFU_TARGET_SPEED_4, 0);
            AddParaItem.DisplayName = "FFU 1 SPEED";
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.FFU_TARGET_SPEED_4, 1);
            AddParaItem.DisplayName = "FFU 2 SPEED";
            parameterList.Add(AddParaItem);

            gridViewControl_FFU_Parameter.Initialize(parameterList);


            nRow = 0;
            dataGridView_FFU.Rows.Clear();

            dataGridView_FFU.Rows.Add();
            dataGridView_FFU[0, nRow].Value = "FFU 1 STATUS";
            dataGridView_FFU[0, nRow].Style.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridView_FFU[0, nRow].Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridView_FFU[0, nRow].Style.BackColor = c_clrMonitorLebel;
            dataGridView_FFU[0, nRow].Style.SelectionBackColor = c_clrMonitorLebel;
            dataGridView_FFU[1, nRow].Style.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridView_FFU[1, nRow].Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            nRow++;

            dataGridView_FFU.Rows.Add();
            dataGridView_FFU[0, nRow].Value = "FFU 1 SPEED";
            dataGridView_FFU[0, nRow].Style.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridView_FFU[0, nRow].Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridView_FFU[0, nRow].Style.BackColor = c_clrMonitorLebel;
            dataGridView_FFU[0, nRow].Style.SelectionBackColor = c_clrMonitorLebel;
            dataGridView_FFU[1, nRow].Style.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridView_FFU[1, nRow].Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            nRow++;

            dataGridView_FFU.Rows.Add();
            dataGridView_FFU[0, nRow].Value = "FFU 2 STATUS";
            dataGridView_FFU[0, nRow].Style.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridView_FFU[0, nRow].Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridView_FFU[0, nRow].Style.BackColor = c_clrMonitorLebel;
            dataGridView_FFU[0, nRow].Style.SelectionBackColor = c_clrMonitorLebel;
            dataGridView_FFU[1, nRow].Style.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridView_FFU[1, nRow].Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            nRow++;

            dataGridView_FFU.Rows.Add();
            dataGridView_FFU[0, nRow].Value = "FFU 2 SPEED";
            dataGridView_FFU[0, nRow].Style.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridView_FFU[0, nRow].Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridView_FFU[0, nRow].Style.BackColor = c_clrMonitorLebel;
            dataGridView_FFU[0, nRow].Style.SelectionBackColor = c_clrMonitorLebel;
            dataGridView_FFU[1, nRow].Style.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridView_FFU[1, nRow].Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            nRow++;

        }

        private void SetBlockTemp()
        {
            double dTemp = m_instanceRecipe.GetValue(EN_TASK_LIST.WORK_ZONE.ToString(), WORKZONE_TASK_PARAM.HEATER_TARGET_TEMP.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);

            ExternalDevice.Heater.Heater.GetInstance().SetTargetTemp((int)Define.DefineEnumProject.Heater.EN_HEATER_ZONE_LIST.BLCOK, dTemp);
        }

        private void SetFFUUsed()
        {
            //ExternalDevice.FFUManager.GetInstance().RequestStopAll();

          //  ExternalDevice.FFUManager.GetInstance().IsSkipped = (false == m_instanceRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.FFU_USE.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, true));

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

        private void SetBlockTolerance()
        {
            double dPlusTolerance = m_instanceRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.WORK_BLOCK_TOLERANCE_MAX.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
            ExternalDevice.Heater.Heater.GetInstance().SetTempPlusTolerance((int)Define.DefineEnumProject.Heater.EN_HEATER_ZONE_LIST.BLCOK, dPlusTolerance);
          
            double dMinusTolerance = m_instanceRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, EQUIPMENT_PARAM.WORK_BLOCK_TOLERANCE_MIN.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, 0.0);
            ExternalDevice.Heater.Heater.GetInstance().SetTempMinusTolerance((int)Define.DefineEnumProject.Heater.EN_HEATER_ZONE_LIST.BLCOK, dMinusTolerance);
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
// 
//             //dataGridView_Heater[0, nRow].Value = "BLOCK CH1 TEMP";
             dataGridView_Heater[1, nRow].Value = ExternalDevice.Heater.Heater.GetInstance().GetMeasuredValue((int)Define.DefineEnumProject.Heater.EN_HEATER_ZONE_LIST.BLCOK, 1) + " ℃";
             nRow++;
// 
//             //dataGridView_Heater[0, nRow].Value = "BLOCK CH2 TEMP";
             dataGridView_Heater[1, nRow].Value = ExternalDevice.Heater.Heater.GetInstance().GetMeasuredValue((int)Define.DefineEnumProject.Heater.EN_HEATER_ZONE_LIST.BLCOK, 2) + " ℃";
             nRow++;
// 
//             //dataGridView_Heater[0, nRow].Value = "BLOCK CH3 TEMP";
//             dataGridView_Heater[1, nRow].Value = ExternalDevice.Heater.Heater.GetInstance().GetMeasuredValue((int)Define.DefineEnumProject.Heater.EN_HEATER_ZONE_LIST.BLCOK, 3) + " ℃";
//             nRow++;
// 
//             //dataGridView_Heater[0, nRow].Value = "BLOCK CH4 TEMP";
//             dataGridView_Heater[1, nRow].Value = ExternalDevice.Heater.Heater.GetInstance().GetMeasuredValue((int)Define.DefineEnumProject.Heater.EN_HEATER_ZONE_LIST.BLCOK, 4) + " ℃";
//             nRow++;


        }

        private void UpdateFFUGridView()
        {
            int nRow = 0;
            for (int i = 0; i < 1; ++i)// 일단 HARDCODING CONTROLLER 1개
            {
                for (int j = 0; j < 2; ++j)// 일단 HARDCODING UNIT 2개
                {
                    // State
                    int nState = (int)ExternalDevice.FFUManager.EN_FFU_STATE.REMOTE_RUN;
                    ExternalDevice.FFUManager.GetInstance().GetLCUUnitState(i, j, ref nState);
                    dataGridView_FFU[1, nRow].Value = ((ExternalDevice.FFUManager.EN_FFU_STATE)nState).ToString();
                    nRow++;

                    int nCurrSpeed = ExternalDevice.FFUManager.GetInstance().GetCurrentSpeedSingleLCU(i, j);
                    dataGridView_FFU[1, nRow].Value = nCurrSpeed.ToString() + " rpm";
                    nRow++;
                }
            }
        }

        private void UpdateChillerGridView()
        {
            int nRow = 0;
            bool bRun = ExternalDevice.Serial.Chiller.GetInstance().bRunStatus;
            dataGridView_Chiller[1, nRow].Style.BackColor = bRun ? c_clrTrue : c_clrFalse;
            dataGridView_Chiller[1, nRow].Style.SelectionBackColor = bRun ? c_clrTrue : c_clrFalse;
            nRow++;

            dataGridView_Chiller[1, nRow].Value = ExternalDevice.Serial.Chiller.GetInstance().dCurTmp + " ℃";
            nRow++;

            dataGridView_Chiller[1, nRow].Value = ExternalDevice.Serial.Chiller.GetInstance().enAlarm;
            nRow++;
        }
        #endregion

		#region UI Event

        private void dataGridView_Heater_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int nRowindex = e.RowIndex;
            int nColumnIndex = e.ColumnIndex;

            if (nColumnIndex != 1 || nRowindex < 0
                || nRowindex >= dataGridView_Heater.RowCount) { return; }

            switch (nRowindex)
            {
                case 0:
                    bool bRun = ExternalDevice.Heater.Heater.GetInstance().GetRunStatus((int)Define.DefineEnumProject.Heater.EN_HEATER_ZONE_LIST.BLCOK, 1);
                    ExternalDevice.Heater.Heater.GetInstance().SetRunStatus((int)Define.DefineEnumProject.Heater.EN_HEATER_ZONE_LIST.BLCOK, !bRun);
                    break;
            }
        }

        private void dataGridView_Chiller_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int nRowindex = e.RowIndex;
            int nColumnIndex = e.ColumnIndex;

            if (nColumnIndex != 1 || nRowindex < 0
                || nRowindex >= dataGridView_Chiller.RowCount) { return; }


            switch (nRowindex)
            {
                case 0: //ch1 run
                    bool bRun = ExternalDevice.Serial.Chiller.GetInstance().bRunStatus;
                    if (bRun)
                        ExternalDevice.Serial.Chiller.GetInstance().StopChiller();
                    else
                        ExternalDevice.Serial.Chiller.GetInstance().RunChiller();
                    break;
            }

        }
        #endregion     
    }
}
