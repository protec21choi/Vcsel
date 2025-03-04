using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Define.DefineEnumBase.Common;

namespace FrameOfSystem3.Views
{
	public class PanelInterface
	{
		#region <FILED>
		List<Action> _parameterSaveActionList = new List<Action>();
		List<Action> _parameterUndoActionList = new List<Action>();

		string _selectedPanel;
		Dictionary<Sys3Controls.Sys3button, string> _tabButtonList = new Dictionary<Sys3Controls.Sys3button, string>();
		Dictionary<string, List<ParameterGroupPanel>> _panelList = new Dictionary<string, List<ParameterGroupPanel>>();
		Dictionary<int, Dictionary<Sys3Controls.Sys3button, string>> _dataSelectionButtonList = new Dictionary<int, Dictionary<Sys3Controls.Sys3button, string>>();
		Dictionary<int, List<ParameterPanel>> _dataSelectionPanelList = new Dictionary<int, List<ParameterPanel>>();

		List<ParameterPanel> _disabledPanelList = new List<ParameterPanel>();
		#endregion </FILED>

		#region <INTERFACE>
		public void InitializeSubPanels(Panel panelSubView
			, Dictionary<string, List<ParameterGroupPanel>> addPanelList
			, Dictionary<Sys3Controls.Sys3button, string> tabButtonList)
		{
			Action<string, ParameterGroupPanel> AddPanel = (page, groupPanel) =>
			{
				if (false == _panelList.ContainsKey(page))
					_panelList.Add(page, new List<ParameterGroupPanel>());

				_panelList[page].Add(groupPanel);
				panelSubView.Controls.Add(groupPanel);
			};

			List<ParameterGroupPanel> reversePanelList;
			foreach (var kvp in addPanelList)
			{
				reversePanelList = new List<ParameterGroupPanel>();
				foreach (var panel in kvp.Value)
				{
					reversePanelList.Add(panel);
				}
				reversePanelList.Reverse();
				foreach (var panel in reversePanelList)
				{
					AddPanel(kvp.Key, panel);
					_parameterSaveActionList.Add(panel.GetFuncParameterSave());
					_parameterUndoActionList.Add(panel.GetFuncParameterUndo());
				}
			}

			string firstTab = string.Empty;
			foreach (var kvp in tabButtonList)
			{
				_tabButtonList.Add(kvp.Key, kvp.Value);

				if (firstTab == string.Empty)
				{
					firstTab = kvp.Value;
				}
			}

			SelectPanel(firstTab);
		}
		public void InitializeSubPanels(Panel panelSubView
			, Dictionary<string, List<ParameterGroupPanel>> addPanelList
			, string panelName)
		{
			Action<string, ParameterGroupPanel> AddPanel = (page, groupPanel) =>
			{
				if (false == _panelList.ContainsKey(page))
					_panelList.Add(page, new List<ParameterGroupPanel>());

				_panelList[page].Add(groupPanel);
				panelSubView.Controls.Add(groupPanel);
			};

			List<ParameterGroupPanel> reversePanelList;
			foreach (var kvp in addPanelList)
			{
				reversePanelList = new List<ParameterGroupPanel>();
				foreach (var panel in kvp.Value)
				{
					reversePanelList.Add(panel);
				}
				reversePanelList.Reverse();
				foreach (var panel in reversePanelList)
				{
					AddPanel(kvp.Key, panel);
					_parameterSaveActionList.Add(panel.GetFuncParameterSave());
					_parameterUndoActionList.Add(panel.GetFuncParameterUndo());
				}
			}

			SelectPanel(panelName);
		}
		public void InitializeDataSelectButton(int groupKey, Dictionary<Sys3Controls.Sys3button, string> buttonList, List<ParameterPanel> applyPanels)
		{
			if (_dataSelectionButtonList.ContainsKey(groupKey))
				_dataSelectionButtonList.Remove(groupKey);
			_dataSelectionButtonList.Add(groupKey, buttonList);

			if (_dataSelectionPanelList.ContainsKey(groupKey))
				_dataSelectionPanelList.Remove(groupKey);
			_dataSelectionPanelList.Add(groupKey, applyPanels);
		}
		public void InitializeDataSelectButton(Dictionary<Sys3Controls.Sys3button, string> buttonList, List<ParameterPanel> applyPanels)
		{
			InitializeDataSelectButton(0, buttonList, applyPanels);
		}

		public void ChangeTargetTask(string panelName, string taskFrom, string taskTo)
		{
			if (false == _panelList.ContainsKey(panelName))
				return;

			foreach (var groupPanel in _panelList[panelName])
			{
				groupPanel.ChangeTargetTask(taskFrom, taskTo);
			}
		}
		public void SetVisiblePanel(ParameterPanel panel, bool isVisible)
		{
			if ((false == isVisible) == _disabledPanelList.Contains(panel))
				return;

			if(isVisible)
			{
				_disabledPanelList.Remove(panel);
			}
			else
			{
				_disabledPanelList.Add(panel);
			}
		}
		public void SetVisiblePanel(List<ParameterPanel> panelList, bool isVisible)
		{
			foreach(var panel in panelList)
			{
				SetVisiblePanel(panel, isVisible);
			}
		}
		#endregion </INTERFACE>

		#region <OVERRIDE>
		public void CallFunctionByTimer()
		{
			if (false == _panelList.ContainsKey(_selectedPanel))
				return;

			foreach (ParameterGroupPanel panel in _panelList[_selectedPanel])
			{
				panel.CallFunctionByTimer();
			}
		}
		public void ProcessWhenActivation()
		{
			if (false == _panelList.ContainsKey(_selectedPanel))
				return;

			foreach (ParameterGroupPanel panel in _panelList[_selectedPanel])
			{
				bool isDisabled = false;
				foreach (ParameterPanel disabledPanel in _disabledPanelList)
				{
					if (panel.IsThisPanel(disabledPanel))
					{
						isDisabled = true;
						break;
					}
				}

				if (isDisabled)
					continue;

				panel.ActivateView();
			}
		}
		public void ProcessWhenDeactivation()
		{
			if (false == _panelList.ContainsKey(_selectedPanel))
				return;

			foreach (ParameterGroupPanel panel in _panelList[_selectedPanel])
			{
				panel.DeactivateView();
			}
		}
		#endregion </OVERRIDE>

		#region <METHOD>
		private bool SelectPanel(string selectPanel)
		{
			if (false == _panelList.ContainsKey(selectPanel)) return false;
			foreach (KeyValuePair<string, List<ParameterGroupPanel>> kvp in _panelList)
			{
				foreach (ParameterGroupPanel panel in kvp.Value)
				{
					panel.Hide();
				}
			}

			// 버튼 클릭 표시
			foreach (var kvp in _tabButtonList)
			{
				kvp.Key.ButtonClicked = kvp.Value == selectPanel;
			}

			_selectedPanel = selectPanel;
			return true;
		}
		private void SelectData(int groupKey, string selectData)
		{
			if (false == _dataSelectionPanelList.ContainsKey(groupKey)
				|| false == _dataSelectionButtonList.ContainsKey(groupKey))
				return;

			foreach (var panel in _dataSelectionPanelList[groupKey])
			{
				panel.ChangeSelectData(selectData);
			}

			// 버튼 클릭 표시
			foreach (var kvp in _dataSelectionButtonList[groupKey])
			{
				kvp.Key.ButtonClicked = kvp.Value == selectData;
			}
		}
		#endregion </METHOD>

		#region <UI EVENT>
		public bool Click_TabButton(Sys3Controls.Sys3button btn)
		{
			if (btn == null || false == _tabButtonList.ContainsKey(btn)
				|| false == SelectPanel(_tabButtonList[btn]))
				return false;

			ProcessWhenActivation();
			return true;
		}
		public void Click_AllExtendReduce(bool isExtend)
		{
			foreach (ParameterGroupPanel panel in _panelList[_selectedPanel])
			{
				panel.PanelExtendReduce(isExtend);
			}
		}
		public void ClickParameterSave()
		{
			foreach (Action save in _parameterSaveActionList)
			{
				save();
			}
		}
		public void ClickParameterUndo()
		{
			foreach (Action undo in _parameterUndoActionList)
			{
				undo();
			}
		}
		public bool Click_DataSelectButton(int groupKey, Sys3Controls.Sys3button btn)
		{
			if (btn == null
				|| false == _dataSelectionButtonList.ContainsKey(groupKey)
				|| false == _dataSelectionButtonList[groupKey].ContainsKey(btn))
				return false;

			SelectData(groupKey, _dataSelectionButtonList[groupKey][btn]);
			ProcessWhenActivation();
			return true;
		}
		public bool Click_DataSelectButton(Sys3Controls.Sys3button btn)
		{
			return Click_DataSelectButton(0, btn);
		}
		#endregion </UI EVENT>
	}
}
