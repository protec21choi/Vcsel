using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FrameOfSystem3.Component;
using FrameOfSystem3.Tool;

using Define.DefineEnumProject.Tool;

namespace FrameOfSystem3.Views.Setup.Equipment
{
    public partial class Equipment_Tool : UserControl, ISetupPanel
	{
		#region <CONSTRUCTOR>
        public Equipment_Tool()
		{
			InitializeComponent();

			_configTool = FrameOfSystem3.Config.ConfigTool.GetInstance();
		}
		#endregion </CONSTRUCTOR>

		FrameOfSystem3.Config.ConfigTool _configTool = null;
		EN_WORK_TOOL _selectedTool = EN_WORK_TOOL.LD_EMITTER_CH_1;

		enum EN_GRID_ITEM
		{
			INDEX,
			NAME,
			ID,
			STATE,
			TYPE,
			CURRENT,
			WARNING,
			ERROR,
		}
      
        #region Override Interface
        public void Activation()
        {
            UpdateMonitor();

            this.Show();
        }
        public void Deactivation()
        {
            this.Hide();
        }
        public void CallFunction()
        {

        }
        #endregion
		private void UpdateMonitor()
		{
			var gridValue = new Dictionary<EN_GRID_ITEM, string>();

			grid_ToolMonitor.Rows.Clear();
			foreach (EN_WORK_TOOL item in Enum.GetValues(typeof(EN_WORK_TOOL)))
			{
				string[] configNames = null;
				string[] configValues = null;
				_configTool.GetItemsValue(((int)item).ToString(), ref configNames, ref configValues);

				string[] monitorNames = null;
				string[] monitorValues = null;
				_configTool.GetMonitoringData(((int)item).ToString(), ref monitorNames, ref monitorValues);

				grid_ToolMonitor.Rows.Add();
				grid_ToolMonitor[(int)EN_GRID_ITEM.INDEX, (int)item].Value = ((int)item).ToString();
				grid_ToolMonitor[(int)EN_GRID_ITEM.NAME, (int)item].Value = item.ToString();
				grid_ToolMonitor[(int)EN_GRID_ITEM.ID, (int)item].Value = monitorValues[(int)EN_TOOL_MONITORING.TOOL_ID];
				grid_ToolMonitor[(int)EN_GRID_ITEM.STATE, (int)item].Value = monitorValues[(int)EN_TOOL_MONITORING.TOOL_STATE];

				grid_ToolMonitor[(int)EN_GRID_ITEM.TYPE, (int)item].Value = configValues[(int)EN_TOOL_PARAM.USAGE_TYPE];
				EN_USAGE_TYPE usingType;
				if (false == Enum.TryParse(configValues[(int)EN_TOOL_PARAM.USAGE_TYPE], out usingType))
					return;

				switch (usingType)
				{
					case EN_USAGE_TYPE.COUNT:
						grid_ToolMonitor[(int)EN_GRID_ITEM.CURRENT, (int)item].Value = monitorValues[(int)EN_TOOL_MONITORING.USED_COUNT];
						grid_ToolMonitor[(int)EN_GRID_ITEM.WARNING, (int)item].Value = configValues[(int)EN_TOOL_PARAM.NOTICE_LIMIT_COUNT];
						grid_ToolMonitor[(int)EN_GRID_ITEM.ERROR, (int)item].Value = configValues[(int)EN_TOOL_PARAM.WARNING_LIMIT_COUNT];
						break;
					case EN_USAGE_TYPE.TIME:
						grid_ToolMonitor[(int)EN_GRID_ITEM.CURRENT, (int)item].Value = monitorValues[(int)EN_TOOL_MONITORING.USED_TIME].Substring(0, 8);
						grid_ToolMonitor[(int)EN_GRID_ITEM.WARNING, (int)item].Value = configValues[(int)EN_TOOL_PARAM.NOTICE_LIMIT_TIME];
						grid_ToolMonitor[(int)EN_GRID_ITEM.ERROR, (int)item].Value = configValues[(int)EN_TOOL_PARAM.WARNING_LIMIT_TIME];
						break;
					default: return;
				}
			}
			UpdateSelectedItem();
		}

		private void btn_Refresh_Click(object sender, EventArgs e)
		{
			UpdateMonitor();
		}

		private void lbl_SelectedItem_Click(object sender, EventArgs e)
		{
			var selectionList = Functional.Form_SelectionList.GetInstance();

			if (selectionList.CreateForm("EN_WORK_TOOL", Enum.GetNames(typeof(EN_WORK_TOOL)), ""))
			{
				string strSelect = string.Empty;
				selectionList.GetResult(ref strSelect);

				EN_WORK_TOOL enSelect;
				if (false == Enum.TryParse(strSelect, out enSelect)) return;
				_selectedTool = enSelect;
				UpdateSelectedItem();
			}
		}
		private void SelectItem(object sender, DataGridViewCellEventArgs e)
		{
			int nRowIndex = e.RowIndex;

			if (nRowIndex < 0 || nRowIndex >= grid_ToolMonitor.RowCount)
				return;

			if(Enum.GetValues(typeof(EN_WORK_TOOL)).Length <= nRowIndex)
				return;

			EN_WORK_TOOL enSelect = (EN_WORK_TOOL)nRowIndex;
			_selectedTool = enSelect;

			UpdateSelectedItem();
		}
		private void UpdateSelectedItem()
		{
			string[] configNames = null;
			string[] configValues = null;
			_configTool.GetItemsValue(((int)_selectedTool).ToString(), ref configNames, ref configValues);

			string[] monitorNames = null;
			string[] monitorValues = null;
			_configTool.GetMonitoringData(((int)_selectedTool).ToString(), ref monitorNames, ref monitorValues);

			lbl_SelectedItem.Text = _selectedTool.ToString();
			lbl_ID.Text = monitorValues[(int)EN_TOOL_MONITORING.TOOL_ID];

			EN_USAGE_TYPE usingType;
			if (false == Enum.TryParse(configValues[(int)EN_TOOL_PARAM.USAGE_TYPE], out usingType))
				return;
			switch (usingType)
			{
				case EN_USAGE_TYPE.COUNT:
					lbl_Current.Text = monitorValues[(int)EN_TOOL_MONITORING.USED_COUNT];

					lbl_CountWarning.Enabled = true;
					lbl_CountWarning.Text = configValues[(int)EN_TOOL_PARAM.NOTICE_LIMIT_COUNT];
					lbl_CountError.Enabled = true;
					lbl_CountError.Text = configValues[(int)EN_TOOL_PARAM.WARNING_LIMIT_COUNT];

					lbl_DayWarning.Enabled = false;
					lbl_DayWarning.Text = "--";
					lbl_DayError.Enabled = false;
					lbl_DayError.Text = "--";
					lbl_HourWarning.Enabled = false;
					lbl_HourWarning.Text = "--";
					lbl_HourError.Enabled = false;
					lbl_HourError.Text = "--";
					break;
				case EN_USAGE_TYPE.TIME:
					lbl_Current.Text = monitorValues[(int)EN_TOOL_MONITORING.USED_TIME];

					lbl_CountWarning.Enabled = false;
					lbl_CountWarning.Text = "--";
					lbl_CountError.Enabled = false;
					lbl_CountError.Text = "--";

					TimeSpan time;
					if (TimeSpan.TryParse(configValues[(int)EN_TOOL_PARAM.NOTICE_LIMIT_TIME], out time))
					{
						lbl_DayWarning.Enabled = true;
						lbl_DayWarning.Text = time.Days.ToString();
						lbl_HourWarning.Enabled = true;
						lbl_HourWarning.Text = time.Hours.ToString();
					}
					if (TimeSpan.TryParse(configValues[(int)EN_TOOL_PARAM.WARNING_LIMIT_TIME], out time))
					{
						lbl_DayError.Enabled = true;
						lbl_DayError.Text = time.Days.ToString();
						lbl_HourError.Enabled = true;
						lbl_HourError.Text = time.Hours.ToString();
					}
					break;
				default: return;
			}
		}

		private void lbl_ID_Click(object sender, EventArgs e)
		{
			var keyBoard = Functional.Form_Keyboard.GetInstance();
			if (false == keyBoard.CreateForm())
				return;

			string newValue = string.Empty;
			keyBoard.GetResult(ref newValue);
			_configTool.SetToolId((int)_selectedTool, newValue);

			UpdateMonitor();
		}
		private void lbl_Count_Click(object sender, EventArgs e)
		{
			var calculator = Functional.Form_Calculator.GetInstance();
			if (false == calculator.CreateForm("0", "0", Int32.MaxValue.ToString(), "count")) return;
			int newValue = 0;
			calculator.GetResult(ref newValue);

			if (sender == lbl_CountWarning)
			{
				_configTool.SetNoticeLimitCount((int)_selectedTool, newValue);
			}
			else if (sender == lbl_CountError)
			{
				_configTool.SetWarningLimitCount((int)_selectedTool, newValue);
			}
			else return;

			UpdateMonitor();
		}
		private void lbl_Day_Click(object sender, EventArgs e)
		{
			var calculator = Functional.Form_Calculator.GetInstance();
			if (false == calculator.CreateForm("0", "0", Int32.MaxValue.ToString(), "count")) return;
			int newValue = 0;
			calculator.GetResult(ref newValue);

			TimeSpan oldTime;
			if (sender == lbl_DayWarning)
			{
				if (false == _configTool.GetNoticeLimitTime((int)_selectedTool, out oldTime)) return;
				TimeSpan newTime = new TimeSpan(newValue, oldTime.Hours, 0, 0);
				_configTool.SetNoticeLimitTime((int)_selectedTool, newTime);
			}
			else if (sender == lbl_DayError)
			{
				if (false == _configTool.GetWarningLimitTime((int)_selectedTool, out oldTime)) return;
				TimeSpan newTime = new TimeSpan(newValue, oldTime.Hours, 0, 0);
				_configTool.SetWarningLimitTime((int)_selectedTool, newTime);
			}
			else return;

			UpdateMonitor();
		}
		private void lbl_Hour_Click(object sender, EventArgs e)
		{
			var calculator = Functional.Form_Calculator.GetInstance();
			if (false == calculator.CreateForm("0", "0", "24", "count")) return;
			int newValue = 0;
			calculator.GetResult(ref newValue);

			TimeSpan oldTime;
			if (sender == lbl_HourWarning)
			{
				if (false == _configTool.GetNoticeLimitTime((int)_selectedTool, out oldTime)) return;
				TimeSpan newTime = new TimeSpan(oldTime.Days, newValue, 0, 0);
				_configTool.SetNoticeLimitTime((int)_selectedTool, newTime);
			}
			else if (sender == lbl_HourError)
			{
				if (false == _configTool.GetWarningLimitTime((int)_selectedTool, out oldTime)) return;
				TimeSpan newTime = new TimeSpan(oldTime.Days, newValue, 0, 0);
				_configTool.SetWarningLimitTime((int)_selectedTool, newTime);
			}
			else return;

			UpdateMonitor();
		}
		private void btn_CurrentReset_Click(object sender, EventArgs e)
		{
			_configTool.ResetItem((int)_selectedTool, false);
			UpdateMonitor();
		}
	}
}
