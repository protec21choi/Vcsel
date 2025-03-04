﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FrameOfSystem3.Recipe;
using Define.DefineEnumProject.SelectionList;

namespace FrameOfSystem3.Component
{
    /*
     *  Label TabIndex 구분
     *  0 : Process Calculator
     *  1 : Process Keyboard
     *  10 ~ : Process Selection List
     *  
     *  100 : Equipment Calculator
     *  101 : Equipment Keyboard
     *  110 ~ : Equipment Selection List
     *  
     *  200 : Common Calculator
     *  201 : Common Keyboard
     *  210 ~ : Common Selection List
     *  
     * 
     *  Button TabIndex 구분
     *  Task 내 Motion 및 Cylinder Index
     */ 

    public class ControlInterface
	{
        public ControlInterface()
        {

        }

		#region Variable
		private FrameOfSystem3.Recipe.Recipe m_instanceRecipe = FrameOfSystem3.Recipe.Recipe.GetInstance();
        private FrameOfSystem3.Config.ConfigMotion m_instanceMotion = FrameOfSystem3.Config.ConfigMotion.GetInstance();
        private FrameOfSystem3.Config.ConfigDevice m_instanceDevice = FrameOfSystem3.Config.ConfigDevice.GetInstance();

        private FrameOfSystem3.Views.Functional.Form_Calculator m_instanceCalculator = FrameOfSystem3.Views.Functional.Form_Calculator.GetInstance();
        private FrameOfSystem3.Views.Functional.Form_Keyboard m_instnaceKeyboard = FrameOfSystem3.Views.Functional.Form_Keyboard.GetInstance();
        private FrameOfSystem3.Views.Functional.Form_MessageBox m_instanceMessageBox = FrameOfSystem3.Views.Functional.Form_MessageBox.GetInstance();
        private FrameOfSystem3.Views.Functional.Form_SelectionList m_instanceSelection = FrameOfSystem3.Views.Functional.Form_SelectionList.GetInstance();

		private Define.DefineEnumProject.Task.EN_TASK_LIST m_enTaskName;

        private FrameOfSystem3.Recipe.PARAM_COMMON m_enCommon = (PARAM_COMMON)0;
        private FrameOfSystem3.Recipe.PARAM_EQUIPMENT m_enEquipment = (PARAM_EQUIPMENT)0;

        private string m_strErrorMessage = string.Empty;

        private Dictionary<CustomParameterLabel, bool> dicOfParameterLabel = new Dictionary<CustomParameterLabel, bool>();
        private Dictionary<CustomParameterButton, bool> dicOfParameterButton = new Dictionary<CustomParameterButton, bool>();
        private Dictionary<CustomParameterToggleButton, bool> dicOfParameterToggle = new Dictionary<CustomParameterToggleButton, bool>();
		private Dictionary<CustomJogButton, bool> dicOfCustomJogButton = new Dictionary<CustomJogButton, bool>();   // 2021.08.02. by shkim. [ADD] CUSTOM JOG BUTTON
		private Dictionary<CustomActionButton, bool> dicOfCustomActionButton = new Dictionary<CustomActionButton, bool>();   // 2021.08.03. by junho [ADD] CUSTOM ACTION BUTTON
        #endregion

        #region Property
        public string strErrorMessage { get { return m_strErrorMessage; } }
        #endregion

        public void AssignControls(System.Windows.Forms.Control.ControlCollection parentControlColletion, DelAftetSetValue afterSetValue_Del = null)
        {
            foreach (var control in parentControlColletion)
            {
                System.Windows.Forms.Control ctrl = control as System.Windows.Forms.Control;


                // 2022.04.15. by WDW. [REMOVE] Disable이어도 값 표시되도록
//                 if (ctrl.Enabled == false)
//                     continue;

                // 2021.08.08. by shkim. [ADD] 그룹박스 처리 추가
                if (control is System.Windows.Forms.GroupBox)
                {
                    System.Windows.Forms.GroupBox group = (System.Windows.Forms.GroupBox)control;
                    AssignControls(group.Controls, afterSetValue_Del);
                }

                if (control is CustomParameterLabel)
                {
                    CustomParameterLabel paraLabel = (CustomParameterLabel)control;

					if (paraLabel.ParameterName.Equals(string.Empty))
						paraLabel.ParameterName = paraLabel.Name;

                    dicOfParameterLabel.Add(paraLabel, paraLabel.NeedRemakeMap);
                    paraLabel.Click += ChangeParameter;
					paraLabel.delAfterSetValue	= afterSetValue_Del;
                }
                if (control is CustomParameterButton)
                {
                    CustomParameterButton paraBtn = (CustomParameterButton)control;
                    dicOfParameterButton.Add(paraBtn, paraBtn.NeedRemakeMap);
                    paraBtn.Click += ChangeParameter;
					paraBtn.delAfterSetValue	= afterSetValue_Del;
                }
                if (control is CustomParameterToggleButton)
                {
                    CustomParameterToggleButton paraTg = (CustomParameterToggleButton)control;

					if (paraTg.ParameterName.Equals(string.Empty))
						paraTg.ParameterName = paraTg.Name;

                    dicOfParameterToggle.Add(paraTg, paraTg.NeedRemakeMap);
                    paraTg.ActiveChanged += ChangeParameter;
					paraTg.delAfterSetValue	= afterSetValue_Del;
                }
                if (control is CustomJogButton)    // 2021.08.02. by shkim. [ADD] CUSTOM JOG BUTTON
                {
                    CustomJogButton customJogButton = (CustomJogButton)control;

                    dicOfCustomJogButton.Add(customJogButton, false);
                    customJogButton.Click += OpenCustomJog;
					customJogButton.delAfterSetValue	= afterSetValue_Del;
                }
				if(control is CustomActionButton)
				{
					CustomActionButton customActionButton = (CustomActionButton)control;

					dicOfCustomActionButton.Add(customActionButton, false);
					customActionButton.Click += DoTargetAction;
				}
            }
        }
        public void RefreshValueParameter()
        {
            foreach (var pLabel in dicOfParameterLabel)
            {
                CustomParameterLabel label = pLabel.Key;
                GetParameter(label);
            }

			foreach(var pToggle in dicOfParameterToggle)
			{
				CustomParameterToggleButton togle = pToggle.Key;
				GetParameter(togle);
			}
        }
        public void ActivateControls()
        {
            foreach (var pTgBtn in dicOfParameterToggle)
            {
                CustomParameterToggleButton tgBtn = pTgBtn.Key;
                GetParameter(tgBtn);
            }
        }

        #region External Interface

        #region Get Parameter

        public void GetParameter(Component.CustomParameterLabel labelTarget)
        {
			// 2021.10.28 by junho [ADD] Recipe Change Confirm
			if (labelTarget.ParameterStored)
			{
				labelTarget.Text = labelTarget.ParameterStorage;
				return;
			}

            string strTaskName = labelTarget.TaskName.ToString();

            if (false == IsCorrectiveName(strTaskName, labelTarget.ParameterName, labelTarget.ParameterType))
            {
				// 2023.02.03 by junho [ADD] parameter 설정 안되면 message 띄우지 않고 색으로 알리도록 변경
				labelTarget.BackGroundColor = System.Drawing.Color.IndianRed;

                labelTarget.Text = string.Empty;
                return;
            }

            string strParameter = string.Empty;

            switch (labelTarget.ParameterType)
            {
                case EN_RECIPE_TYPE.PROCESS:
                    strParameter = m_instanceRecipe.GetValue(strTaskName
                        , labelTarget.ParameterName
                        , labelTarget.ParameterIndex
                        , FrameOfSystem3.Recipe.EN_RECIPE_PARAM_TYPE.VALUE
                        , string.Empty);

                    break;
                case EN_RECIPE_TYPE.EQUIPMENT:
                case EN_RECIPE_TYPE.COMMON:
                    strParameter = m_instanceRecipe.GetValue(labelTarget.ParameterType
                        , labelTarget.ParameterName
                        , labelTarget.ParameterIndex
                        , FrameOfSystem3.Recipe.EN_RECIPE_PARAM_TYPE.VALUE
                        , string.Empty);

                    break;
            }

            labelTarget.Text = strParameter;

            SetMinMaxUnit(labelTarget);
        }
        public void GetParameter(Component.CustomParameterToggleButton tgTarget)
        {
			// 2021.10.28 by junho [ADD] Recipe Change Confirm
			if (tgTarget.ParameterStored)
			{
				bool storageValue;
				if (bool.TryParse(tgTarget.ParameterStorage, out storageValue))
					tgTarget.Active = storageValue;

				return;
			}

            string strTaskName = tgTarget.TaskName.ToString();

            if (false == IsCorrectiveName(strTaskName, tgTarget.ParameterName, tgTarget.ParameterType))
			{
				// 2023.02.03 by junho [ADD] parameter 설정 안되면 message 띄우지 않고 색으로 알리도록 변경
				tgTarget.BackColor = System.Drawing.Color.IndianRed;

				tgTarget.Active = false;
                return;
            }

            bool bParameter = false;
            switch (tgTarget.ParameterType)
            {
                case EN_RECIPE_TYPE.PROCESS:
                    bParameter = m_instanceRecipe.GetValue(strTaskName
                        , tgTarget.ParameterName
                        , tgTarget.ParameterIndex
                        , FrameOfSystem3.Recipe.EN_RECIPE_PARAM_TYPE.VALUE
                        , false);

                    break;
                case EN_RECIPE_TYPE.EQUIPMENT:
                case EN_RECIPE_TYPE.COMMON:
                    bParameter = m_instanceRecipe.GetValue(tgTarget.ParameterType
                        , tgTarget.ParameterName
                        , tgTarget.ParameterIndex
                        , FrameOfSystem3.Recipe.EN_RECIPE_PARAM_TYPE.VALUE
                        , false);

                    break;
            }
            tgTarget.Active = bParameter;
        }
        #endregion

        #region Set Parameter

        #region Typing Parameter
        public bool SetParameter(Component.CustomParameterToggleButton tgTarget)
        {
            string strTaskName = tgTarget.TaskName.ToString();
            if (false == IsCorrectiveName(strTaskName, tgTarget.ParameterName, tgTarget.ParameterType))
            {
				// 2023.02.03 by junho [ADD] parameter 설정 안되면 message 띄우지 않고 색으로 알리도록 변경
				tgTarget.BackColor = System.Drawing.Color.IndianRed;

				tgTarget.Active = false;
                return false;
            }
            bool bNewValue = tgTarget.Active;

			// 2021.10.28 by junho [MOD] Recipe Change Confirm
			//switch(tgTarget.ParameterType)
			//{
			//	case EN_RECIPE_TYPE.PROCESS:
			//		if(false == m_instanceRecipe.SetValue(strTaskName,
			//			tgTarget.ParameterName,
			//			tgTarget.ParameterIndex,
			//			EN_RECIPE_PARAM_TYPE.VALUE,
			//			bNewValue.ToString()))
			//		{
			//			return false;
			//		}
			//		break;
			//	case EN_RECIPE_TYPE.EQUIPMENT:
			//	case EN_RECIPE_TYPE.COMMON:
			//		if (false == m_instanceRecipe.SetValue(tgTarget.ParameterType
			//			, tgTarget.ParameterName
			//			, tgTarget.ParameterIndex
			//			, EN_RECIPE_PARAM_TYPE.VALUE
			//			, bNewValue.ToString()))
			//			return false;
			//		break;
			//	default:
			//		return false;
			//}
			tgTarget.ParameterStorage = bNewValue.ToString();
			tgTarget.ParameterStored = true;
			if (tgTarget.UseParameterChangeConfirm)
			{
				tgTarget.ActiveColorFirst = tgTarget.ParameterChangeWaitColorFirst;
				tgTarget.ActiveColorSecond = tgTarget.ParameterChangeWaitColorSecond;
				tgTarget.NormalColorFirst = tgTarget.ParameterChangeWaitColorFirst;
				tgTarget.NormalColorSecond = tgTarget.ParameterChangeWaitColorSecond;
			}
			else
			{
				DecideSetParameter(tgTarget);
			}


            return true;
        }
        public bool SetParameter(Component.CustomParameterLabel labelTarget)
        {
            string strTaskName = labelTarget.TaskName.ToString();

			if (false == IsCorrectiveName(strTaskName, labelTarget.ParameterName, labelTarget.ParameterType))
            {
				// 2023.02.03 by junho [ADD] parameter 설정 안되면 message 띄우지 않고 색으로 알리도록 변경
				labelTarget.BackGroundColor = System.Drawing.Color.IndianRed;

				labelTarget.Text = string.Empty;
                return false;
            }

            string strResult = string.Empty;

            switch (labelTarget.ParameterSettingType)
            {
                case Component.EN_LABEL_PARAMETER_TYPE.CALCULATE:
                    if (false == GetResultByCalculator(labelTarget, ref strResult))
                        return false;

                    break;
                case Component.EN_LABEL_PARAMETER_TYPE.KEYBOARD:
                    if (m_instnaceKeyboard.CreateForm(labelTarget.Text) == false)
                        return false;

                    m_instnaceKeyboard.GetResult(ref strResult);
                    break;
                case Component.EN_LABEL_PARAMETER_TYPE.SELECT:
                    if (false == m_instanceSelection.CreateForm(strTaskName, labelTarget.SelectionList, labelTarget.Text))
                        return false;

                    m_instanceSelection.GetResult(ref strResult);
                    break;
                case Component.EN_LABEL_PARAMETER_TYPE.FOLDER_DIALOG:
                    // if(false == )
                    System.Windows.Forms.FolderBrowserDialog dlg = new System.Windows.Forms.FolderBrowserDialog();
                    if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                    {
                        dlg.Dispose();
                        return false;
                    }
                    strResult = dlg.SelectedPath;
                    dlg.Dispose();
                    break;
                default:
                    m_strErrorMessage = String.Format("You have not [Parameter Setting Type] set it up.");
                    return false;
            }

			// 2021.10.28 by junho [MOD] Recipe Change Confirm
			//switch (labelTarget.ParameterType)
			//{
			//	case EN_RECIPE_TYPE.PROCESS:
			//		if (false == m_instanceRecipe.SetValue(strTaskName
			//			, labelTarget.ParameterName
			//			, labelTarget.ParameterIndex
			//			, EN_RECIPE_PARAM_TYPE.VALUE
			//			, strResult))
			//			return false;
			//		break;
			//	case EN_RECIPE_TYPE.EQUIPMENT:
			//	case EN_RECIPE_TYPE.COMMON:
			//		if (false == m_instanceRecipe.SetValue(labelTarget.ParameterType
			//			, labelTarget.ParameterName
			//			, labelTarget.ParameterIndex
			//			, EN_RECIPE_PARAM_TYPE.VALUE
			//			, strResult))
			//			return false;
			//		break;
			//}
			//labelTarget.Text = strResult;
			labelTarget.ParameterStorage = strResult;
			labelTarget.ParameterStored = true;
			if (labelTarget.UseParameterChangeConfirm)
			{
				labelTarget.MainFontColor = labelTarget.ParameterChangeWaitColor;
				labelTarget.Text = strResult;
			}
			else
			{
				DecideSetParameter(labelTarget);
			}

            return true;
        }

		#region Parameter Confirm
		// 2021.10.28 by junho [ADD] Recipe Change Confirm
		public bool DecideSetParameter(Component.CustomParameterLabel labelTarget)
		{
			if (false == labelTarget.ParameterStored)
				return true;

			string strTaskName = labelTarget.TaskName.ToString();
			string strResult = labelTarget.ParameterStorage;

			switch (labelTarget.ParameterType)
			{
				case EN_RECIPE_TYPE.PROCESS:
					if (false == m_instanceRecipe.SetValue(strTaskName
						, labelTarget.ParameterName
						, labelTarget.ParameterIndex
						, EN_RECIPE_PARAM_TYPE.VALUE
						, strResult))
						return false;
					break;
				case EN_RECIPE_TYPE.EQUIPMENT:
				case EN_RECIPE_TYPE.COMMON:
					if (false == m_instanceRecipe.SetValue(labelTarget.ParameterType
						, labelTarget.ParameterName
						, labelTarget.ParameterIndex
						, EN_RECIPE_PARAM_TYPE.VALUE
						, strResult))
						return false;
					break;
			}

			labelTarget.MainFontColor = labelTarget.ParameterChangeDefaultColor;
			labelTarget.Text = strResult;
			labelTarget.ParameterStored = false;

			return true;
		}
		public bool DecideSetParameter(Component.CustomParameterToggleButton tgTarget)
		{
			if (false == tgTarget.ParameterStored)
				return true;

			string strTaskName = tgTarget.TaskName.ToString();
			string strResult = tgTarget.ParameterStorage;

			switch (tgTarget.ParameterType)
			{
				case EN_RECIPE_TYPE.PROCESS:
					if (false == m_instanceRecipe.SetValue(strTaskName
						, tgTarget.ParameterName
						, tgTarget.ParameterIndex
						, EN_RECIPE_PARAM_TYPE.VALUE
						, strResult))
						return false;
					break;
				case EN_RECIPE_TYPE.EQUIPMENT:
				case EN_RECIPE_TYPE.COMMON:
					if (false == m_instanceRecipe.SetValue(tgTarget.ParameterType
						, tgTarget.ParameterName
						, tgTarget.ParameterIndex
						, EN_RECIPE_PARAM_TYPE.VALUE
						, strResult))
						return false;
					break;
			}

			tgTarget.ActiveColorFirst = tgTarget.ParameterChangeDefaultActiveColorFirst;
			tgTarget.ActiveColorSecond = tgTarget.ParameterChangeDefaultActiveColorSecond;
			tgTarget.NormalColorFirst = tgTarget.ParameterChangeDefaultNormalColorFirst;
			tgTarget.NormalColorSecond = tgTarget.ParameterChangeDefaultNormalColorSecond;

			tgTarget.ParameterStored = false;

			return true;
		}
		public void DecideSetParameterAll()
		{
			foreach (var pLabel in dicOfParameterLabel)
			{
				CustomParameterLabel label = pLabel.Key;
				DecideSetParameter(label);
			}
			foreach(var pToggle in dicOfParameterToggle)
			{
				CustomParameterToggleButton toggle = pToggle.Key;
				DecideSetParameter(toggle);
			}
		}
		public void ParameterUndo(Component.CustomParameterLabel labelTarget)
		{
			if (false == labelTarget.ParameterStored)
				return;

			labelTarget.MainFontColor = labelTarget.ParameterChangeDefaultColor;
			labelTarget.ParameterStored = false;
		}
		public void ParameterUndo(Component.CustomParameterToggleButton tgTarget)
		{
			if (false == tgTarget.ParameterStored)
				return;

			tgTarget.ActiveColorFirst = tgTarget.ParameterChangeDefaultActiveColorFirst;
			tgTarget.ActiveColorSecond = tgTarget.ParameterChangeDefaultActiveColorSecond;
			tgTarget.NormalColorFirst = tgTarget.ParameterChangeDefaultNormalColorFirst;
			tgTarget.NormalColorSecond = tgTarget.ParameterChangeDefaultNormalColorSecond;

			tgTarget.ParameterStored = false;
		}
		public void ParameterUndoAll()
		{
			foreach (var pLabel in dicOfParameterLabel)
			{
				CustomParameterLabel label = pLabel.Key;
				ParameterUndo(label);
			}
			foreach (var pToggle in dicOfParameterToggle)
			{
				CustomParameterToggleButton toggle = pToggle.Key;
				ParameterUndo(toggle);
			}
		}
		#endregion

		#endregion

		#region Position Parameter
		public bool SetParameter(Component.CustomParameterButton buttonTarget)
        {
            m_strErrorMessage = string.Empty;

            string strTaskName = buttonTarget.TaskName.ToString();
            string strAxisName = string.Empty;

            if (false == IsCorrectiveName(buttonTarget.TaskName.ToString(), buttonTarget.ParameterName, buttonTarget.ParameterType))
			{
				// 2023.02.03 by junho [ADD] parameter 설정 안되면 message 띄우지 않고 색으로 알리도록 변경
				buttonTarget.GradientFirstColor = System.Drawing.Color.IndianRed;
				buttonTarget.GradientSecondColor = System.Drawing.Color.IndianRed;

                return false;
			}

            // double dblActualPosition = GetActualPosition(buttonTarget, ref strAxisName);
            double dblActualPosition = 0.0;
            if (false == GetActualPosition(buttonTarget, ref strAxisName, ref dblActualPosition))
                return false;
            
            // string strMessage = String.Format("Do you want Set parameter? \\n AXIS : {0} \\n PARAMETER : {1} \\n{2}"
            string strMessage = String.Format("Do you want Set parameter? \\n PARAMETER : {0} \\n AXIS : {1} | Value : {2}"
                , buttonTarget.ParameterName
                , strAxisName
                , Math.Round(dblActualPosition,3));

            if (m_instanceMessageBox.ShowMessage(strMessage, "SET PARAMETER") == false)
                return false;

            string strActualPosition = String.Format("{0:0.000}", dblActualPosition);

            switch (buttonTarget.ParameterType)
            {
                case EN_RECIPE_TYPE.PROCESS:
                    if (false == m_instanceRecipe.SetValue(strTaskName
                        , buttonTarget.ParameterName
                        , buttonTarget.ParameterIndex
                        , FrameOfSystem3.Recipe.EN_RECIPE_PARAM_TYPE.VALUE
                        , strActualPosition))
                        return false;

                    break;
                case EN_RECIPE_TYPE.EQUIPMENT:
                    if (false == m_instanceRecipe.SetValue(EN_RECIPE_TYPE.EQUIPMENT
                        , buttonTarget.ParameterName
                        , buttonTarget.ParameterIndex
                        , FrameOfSystem3.Recipe.EN_RECIPE_PARAM_TYPE.VALUE
                        , strActualPosition))
                        return false;

                    break;
                case EN_RECIPE_TYPE.COMMON:
                    if (false == m_instanceRecipe.SetValue(EN_RECIPE_TYPE.COMMON
                        , buttonTarget.ParameterName
                        , buttonTarget.ParameterIndex
                        , FrameOfSystem3.Recipe.EN_RECIPE_PARAM_TYPE.VALUE
                        , strActualPosition))
                        return false;

                    break;
            }


            return true;
        }
        #endregion

        #endregion

		#region Change recipe property
		/// <summary>
		/// 가지고있는 control의 target task가 taskFrom이면 taskTo로 교체한다.
		/// </summary>
		public void ChangeTargetTask(string taskFrom, string taskTo)
		{
			foreach(var control in dicOfParameterLabel.Keys)
			{
				if (control.TaskName == taskFrom)
					control.TaskName = taskTo;
			}
			foreach (var control in dicOfParameterButton.Keys)
			{
				if (control.TaskName == taskFrom)
					control.TaskName = taskTo;
			}
			foreach (var control in dicOfParameterToggle.Keys)
			{
				if (control.TaskName == taskFrom)
					control.TaskName = taskTo;
			}
			foreach (var control in dicOfCustomJogButton.Keys)
			{
				if (control.TaskName1 == taskFrom)
					control.TaskName1 = taskTo;
				if (control.TaskName2 == taskFrom)
					control.TaskName2 = taskTo;
			}
			foreach (var control in dicOfCustomActionButton.Keys)
			{
				if (control.TaskName == taskFrom)
					control.TaskName = taskTo;
			}
		}
		public void ChangeTargetAxis(string axixFrom, string axisTo)
		{
			foreach (var control in dicOfCustomJogButton.Keys)
			{
				if (control.AxisName1 == axixFrom)
					control.AxisName1 = axisTo;
				if (control.AxisName2 == axixFrom)
					control.AxisName2 = axisTo;
			}
		}
		#endregion /Change recipe property

		#endregion

		#region Internal Interface

		#region Name Check
		private bool IsCorrectiveName(string strTaskName, string strParameterName, EN_RECIPE_TYPE enParameterType)
        {
            switch (enParameterType)
            {
                case EN_RECIPE_TYPE.COMMON:
                    if (Enum.TryParse(strParameterName, out m_enCommon) == false)
                    {
						// 2023.02.03 by junho [DEL] parameter 설정 안되면 message 띄우지 않고 색으로 알리도록 변경
						//m_strErrorMessage = String.Format("You entered Parameter Name incorrectly! \\n PARAMETER TYPE : {0} \\n PARAMETER NAME : {1}", EN_RECIPE_TYPE.COMMON, strParameterName);
						//m_instanceMessageBox.ShowMessage(m_strErrorMessage);
                        return false;
                    }
                    break;
                case EN_RECIPE_TYPE.EQUIPMENT:
                    if (Enum.TryParse(strParameterName, out m_enEquipment) == false)
                    {
						// 2023.02.03 by junho [DEL] parameter 설정 안되면 message 띄우지 않고 색으로 알리도록 변경
						//m_strErrorMessage = String.Format("You entered Parameter Name incorrectly! \\n PARAMETER TYPE : {0} \\n PARAMETER NAME : {1}", EN_RECIPE_TYPE.EQUIPMENT, strParameterName);
						//m_instanceMessageBox.ShowMessage(m_strErrorMessage);
                        return false;
                    }

                    break;
                case EN_RECIPE_TYPE.PROCESS:
                    #region Process
                    if (Enum.TryParse(strTaskName, out m_enTaskName) == false)
                    {
						// 2023.02.03 by junho [DEL] parameter 설정 안되면 message 띄우지 않고 색으로 알리도록 변경
						//m_strErrorMessage = String.Format("You entered Task Name incorrectly! \\n TASK NAME : {0}", m_enTaskName);
						//m_instanceMessageBox.ShowMessage(m_strErrorMessage);
						return false;
                    }

					if(false == ConvertProjectTaskData.IsDefinedParameter(m_enTaskName, strParameterName))
					{
						// 2023.02.03 by junho [DEL] parameter 설정 안되면 message 띄우지 않고 색으로 알리도록 변경
						//m_strErrorMessage = String.Format("You entered Parameter Name incorrectly! \\n TASK NAME : {0} \\n PARAMETER NAME : {1}", m_enTaskName, strParameterName);
						//m_instanceMessageBox.ShowMessage(m_strErrorMessage);
						return false;
					}
                    #endregion
                    break;
            }

            return true;
        }
        #endregion

        #region Axis Check
        private int GetAxisNumber(Component.CustomParameterButton buttonTarget, ref string strAxisName)
        {
            int nAxisNumber = 0;
            string strTaskName = buttonTarget.TaskName.ToString();

            return nAxisNumber;
        }
        #endregion

        #region Actual Position
        // 2021.06.15. by shkim. [MOD] Enum 값이 아닌 컨트롤에 사전에 설정된 taskName, axisName으로 Target Index를 확인하도록 수정
        private bool GetActualPosition(Component.CustomParameterButton buttonTarget, ref string strAxisName, ref double actualPos)
        {
            int nAxisNumber = 0;
            int nIndexOfTaskAxis = 0;
            string strTaskName = buttonTarget.TaskName.ToString();
            
            int nDeviceCount = 0;
            int[] arrDeviceIndexNumbers = null;
            Config.ConfigDevice.GetInstance().GetIndexesOfDevice(strTaskName, Config.ConfigDevice.EN_TYPE_DEVICE.MOTION, ref nDeviceCount, ref arrDeviceIndexNumbers);

            for(int i = 0; i < nDeviceCount; i++)
            {
                string tempTargetDeviceName = string.Empty;
                Config.ConfigDevice.GetInstance().GetDeviceTargetName(strTaskName, Config.ConfigDevice.EN_TYPE_DEVICE.MOTION, arrDeviceIndexNumbers[i], ref tempTargetDeviceName);
                if (buttonTarget.AxisName.Equals(tempTargetDeviceName))
                {
                    nIndexOfTaskAxis = arrDeviceIndexNumbers[i];

                    if (false == m_instanceDevice.GetDeviceTargetIndex(strTaskName
                    , FrameOfSystem3.Config.ConfigDevice.EN_TYPE_DEVICE.MOTION
                    , nIndexOfTaskAxis
                    , ref nAxisNumber))
                    {
                        return false;
                    }
                        
                    if (false == m_instanceDevice.GetDeviceTargetName(strTaskName
                                , FrameOfSystem3.Config.ConfigDevice.EN_TYPE_DEVICE.MOTION
                                , nIndexOfTaskAxis
                                , ref strAxisName))
                    {
                        return false;
                    }

                    actualPos = m_instanceMotion.GetActualPosition(nAxisNumber);
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region Calculator
        private bool GetResultByCalculator(Component.CustomParameterLabel labelTarget, ref string strResult)
        {
            string strOld = string.Empty; // 2021.06.08. by shkim. [ADD] 이전 값 출력 추가
            string strMin = string.Empty;
            string strMax = string.Empty;
            string strUnit = string.Empty;

			#region Get old, min, max, unit
			switch (labelTarget.ParameterType)
            {
                case EN_RECIPE_TYPE.PROCESS:
                    strMin = m_instanceRecipe.GetValue(labelTarget.TaskName.ToString()
                        , labelTarget.ParameterName
                        , labelTarget.ParameterIndex
                        , FrameOfSystem3.Recipe.EN_RECIPE_PARAM_TYPE.MIN
                        , string.Empty);

                    strMax = m_instanceRecipe.GetValue(labelTarget.TaskName.ToString()
                        , labelTarget.ParameterName
                        , labelTarget.ParameterIndex
                        , FrameOfSystem3.Recipe.EN_RECIPE_PARAM_TYPE.MAX
                        , string.Empty);

                    strUnit = m_instanceRecipe.GetValue(labelTarget.TaskName.ToString()
                        , labelTarget.ParameterName
                        , labelTarget.ParameterIndex
                        , FrameOfSystem3.Recipe.EN_RECIPE_PARAM_TYPE.UNIT
                        , string.Empty);

                    strOld = m_instanceRecipe.GetValue(labelTarget.TaskName.ToString()
                        , labelTarget.ParameterName
                        , labelTarget.ParameterIndex
                        , FrameOfSystem3.Recipe.EN_RECIPE_PARAM_TYPE.VALUE
                        , string.Empty);

                    break;
                case EN_RECIPE_TYPE.COMMON:
                case EN_RECIPE_TYPE.EQUIPMENT:
                    strMin = m_instanceRecipe.GetValue(labelTarget.ParameterType
                        , labelTarget.ParameterName
                        , labelTarget.ParameterIndex
                        , FrameOfSystem3.Recipe.EN_RECIPE_PARAM_TYPE.MIN
                        , string.Empty);

                    strMax = m_instanceRecipe.GetValue(labelTarget.ParameterType
                        , labelTarget.ParameterName
                        , labelTarget.ParameterIndex
                        , FrameOfSystem3.Recipe.EN_RECIPE_PARAM_TYPE.MAX
                        , string.Empty);

                    strUnit = m_instanceRecipe.GetValue(labelTarget.ParameterType
                        , labelTarget.ParameterName
                        , labelTarget.ParameterIndex
                        , FrameOfSystem3.Recipe.EN_RECIPE_PARAM_TYPE.UNIT
                        , string.Empty);

                    strOld = m_instanceRecipe.GetValue(labelTarget.ParameterType
                        , labelTarget.ParameterName
                        , labelTarget.ParameterIndex
                        , FrameOfSystem3.Recipe.EN_RECIPE_PARAM_TYPE.VALUE
                        , string.Empty);

                    break;
			}
			#endregion

			// 2023.02.07 by junho [ADD] title 표시 할 수 있도록 기능 추가
			// if (m_instanceCalculator.CreateForm(labelTarget.Text, strMin, strMax, labelTarget.ParameterName, strUnit) == false)
			//if (m_instanceCalculator.CreateForm(strOld, strMin, strMax, strUnit) == false)
			if (m_instanceCalculator.CreateForm(strOld, strMin, strMax, strUnit, labelTarget.ParameterName) == false)
                return false;

            double dblResult = 0, dblMin = 0, dblMax = 0;
            m_instanceCalculator.GetResult(ref dblResult);

			m_instanceCalculator.GetMin(ref dblMin);
			m_instanceCalculator.GetMax(ref dblMax);
			m_instanceCalculator.GetUnit(ref strUnit);

			#region Set min, max, unit
			switch (labelTarget.ParameterType)
			{
				case EN_RECIPE_TYPE.PROCESS:
					m_instanceRecipe.SetValue(labelTarget.TaskName.ToString()
						, labelTarget.ParameterName
						, labelTarget.ParameterIndex
						, FrameOfSystem3.Recipe.EN_RECIPE_PARAM_TYPE.MIN
						, dblMin.ToString());

					m_instanceRecipe.SetValue(labelTarget.TaskName.ToString()
						, labelTarget.ParameterName
						, labelTarget.ParameterIndex
						, FrameOfSystem3.Recipe.EN_RECIPE_PARAM_TYPE.MAX
						, dblMax.ToString());

					m_instanceRecipe.SetValue(labelTarget.TaskName.ToString()
						, labelTarget.ParameterName
						, labelTarget.ParameterIndex
						, FrameOfSystem3.Recipe.EN_RECIPE_PARAM_TYPE.UNIT
						, strUnit);
					break;
				case EN_RECIPE_TYPE.COMMON:
				case EN_RECIPE_TYPE.EQUIPMENT:
					m_instanceRecipe.SetValue(labelTarget.ParameterType
						, labelTarget.ParameterName
						, labelTarget.ParameterIndex
						, FrameOfSystem3.Recipe.EN_RECIPE_PARAM_TYPE.MIN
						, dblMin.ToString());

					m_instanceRecipe.SetValue(labelTarget.ParameterType
						, labelTarget.ParameterName
						, labelTarget.ParameterIndex
						, FrameOfSystem3.Recipe.EN_RECIPE_PARAM_TYPE.MAX
						, dblMax.ToString());

					m_instanceRecipe.SetValue(labelTarget.ParameterType
						, labelTarget.ParameterName
						, labelTarget.ParameterIndex
						, FrameOfSystem3.Recipe.EN_RECIPE_PARAM_TYPE.UNIT
						, strUnit);
					break;
			}
			#endregion

			if(dblMin > dblResult || dblResult > dblMax)
			{
				m_instanceMessageBox.ShowMessage("Out of parameter min/max range");
				return false;
			}

			strResult = dblResult.ToString();


            return true;
        }
        #endregion

        #region Min Max Unit
        private void SetMinMaxUnit(Component.CustomParameterLabel labelTarget)
        {
            string strMin = string.Empty;
            string strMax = string.Empty;
            string strUnit = string.Empty;

            switch (labelTarget.ParameterType)
            {
                case EN_RECIPE_TYPE.PROCESS:
                    strMin = m_instanceRecipe.GetValue(labelTarget.TaskName.ToString()
                        , labelTarget.ParameterName
                        , labelTarget.ParameterIndex
                        , FrameOfSystem3.Recipe.EN_RECIPE_PARAM_TYPE.MIN
                        , string.Empty);

                    strMax = m_instanceRecipe.GetValue(labelTarget.TaskName.ToString()
                        , labelTarget.ParameterName
                        , labelTarget.ParameterIndex
                        , FrameOfSystem3.Recipe.EN_RECIPE_PARAM_TYPE.MAX
                        , string.Empty);

                    strUnit = m_instanceRecipe.GetValue(labelTarget.TaskName.ToString()
                        , labelTarget.ParameterName
                        , labelTarget.ParameterIndex
                        , FrameOfSystem3.Recipe.EN_RECIPE_PARAM_TYPE.UNIT
                        , string.Empty);
                    break;
                case EN_RECIPE_TYPE.EQUIPMENT:
                case EN_RECIPE_TYPE.COMMON:
                    strMin = m_instanceRecipe.GetValue(labelTarget.ParameterType
                        , labelTarget.ParameterName
                        , labelTarget.ParameterIndex
                        , FrameOfSystem3.Recipe.EN_RECIPE_PARAM_TYPE.MIN
                        , string.Empty);

                    strMax = m_instanceRecipe.GetValue(labelTarget.ParameterType
                        , labelTarget.ParameterName
                        , labelTarget.ParameterIndex
                        , FrameOfSystem3.Recipe.EN_RECIPE_PARAM_TYPE.MAX
                        , string.Empty);

                    strUnit = m_instanceRecipe.GetValue(labelTarget.ParameterType
                        , labelTarget.ParameterName
                        , labelTarget.ParameterIndex
                        , FrameOfSystem3.Recipe.EN_RECIPE_PARAM_TYPE.UNIT
                        , string.Empty);

                    break;
            }

            if (strMin.Equals(string.Empty))
            {
                if (false == labelTarget.ParameterMIN.Equals(string.Empty))
                {
                    switch (labelTarget.ParameterType)
                    {
                        case EN_RECIPE_TYPE.PROCESS:
                            m_instanceRecipe.SetValue(labelTarget.TaskName.ToString()
                                , labelTarget.ParameterName
                                , labelTarget.ParameterIndex
                                , FrameOfSystem3.Recipe.EN_RECIPE_PARAM_TYPE.MIN
                                , labelTarget.ParameterMIN);

                            break;
                        case EN_RECIPE_TYPE.EQUIPMENT:
                        case EN_RECIPE_TYPE.COMMON:
                            m_instanceRecipe.SetValue(labelTarget.ParameterType
                                , labelTarget.ParameterName
                                , labelTarget.ParameterIndex
                                , FrameOfSystem3.Recipe.EN_RECIPE_PARAM_TYPE.MIN
                                , labelTarget.ParameterMIN);

                            break;
                    }
                }
            }

            if (strMax.Equals(string.Empty))
            {
                if (false == labelTarget.ParameterMAX.Equals(string.Empty))
                {
                    switch (labelTarget.ParameterType)
                    {
                        case EN_RECIPE_TYPE.PROCESS:
                            m_instanceRecipe.SetValue(labelTarget.TaskName.ToString()
                                , labelTarget.ParameterName
                                , labelTarget.ParameterIndex
                                , FrameOfSystem3.Recipe.EN_RECIPE_PARAM_TYPE.MAX
                                , labelTarget.ParameterMAX);

                            break;
                        case EN_RECIPE_TYPE.EQUIPMENT:
                        case EN_RECIPE_TYPE.COMMON:
                            m_instanceRecipe.SetValue(labelTarget.ParameterType
                                , labelTarget.ParameterName
                                , labelTarget.ParameterIndex
                                , FrameOfSystem3.Recipe.EN_RECIPE_PARAM_TYPE.MAX
                                , labelTarget.ParameterMAX);

                            break;
                    }
                }
            }

            if (strUnit.Equals(string.Empty))
            {
                if (false == labelTarget.ParameterUNIT.Equals(string.Empty))
                {
                    switch (labelTarget.ParameterType)
                    {
                        case EN_RECIPE_TYPE.PROCESS:
                            m_instanceRecipe.SetValue(labelTarget.TaskName.ToString()
                                , labelTarget.ParameterName
                                , labelTarget.ParameterIndex
                                , FrameOfSystem3.Recipe.EN_RECIPE_PARAM_TYPE.UNIT
                                , labelTarget.ParameterUNIT);

                            break;
                        case EN_RECIPE_TYPE.EQUIPMENT:
                        case EN_RECIPE_TYPE.COMMON:
                            m_instanceRecipe.SetValue(labelTarget.ParameterType
                                , labelTarget.ParameterName
                                , labelTarget.ParameterIndex
                                , FrameOfSystem3.Recipe.EN_RECIPE_PARAM_TYPE.UNIT
                                , labelTarget.ParameterUNIT);

                            break;
                    }

                    labelTarget.UseUnitFont = true;
                    labelTarget.UnitText = labelTarget.ParameterUNIT;
                }
                else
                {
                    labelTarget.UseUnitFont = false;
                }
            }
            else
            {
                labelTarget.UseUnitFont = true;
                labelTarget.UnitText = strUnit;
            }
        }
        #endregion

        #endregion

        /// <summary>
        /// 2021.06.14. by shkim. [ADD] 파라미터 변경 가능한 상태 확인
        /// </summary>
        /// <returns></returns>
        private bool ChangeableStateForParameter()
        {
            EquipmentState_.EQUIPMENT_STATE equipmentState = EquipmentState_.EquipmentState.GetInstance().GetState();
            return (equipmentState == EquipmentState_.EQUIPMENT_STATE.PAUSE || equipmentState == EquipmentState_.EQUIPMENT_STATE.IDLE);
        }
        private void ChangeParameter(object sender, EventArgs e)
        {
			// 2021.11.12 by junho [ADD] 설비 가동중 파라미터 변경 가능 옵션 추가
			if (sender is CustomParameterLabel)
			{
				bool isUnlock = m_instanceRecipe.GetValue(EN_RECIPE_TYPE.EQUIPMENT, Recipe.PARAM_EQUIPMENT.UnlockParameterChange.ToString(), 0, EN_RECIPE_PARAM_TYPE.VALUE, false);

				if (false == ChangeableStateForParameter() && false == isUnlock)
					return;
			}
			else
			{
				// 설비 가동 중 파라미터 변경 금지
				if (false == ChangeableStateForParameter())
				{
					if (sender is CustomParameterToggleButton)
					{
						GetParameter(sender as CustomParameterToggleButton);
					}
					return;
				}
			}

            if (sender is CustomParameterLabel)
            {
                CustomParameterLabel label = (CustomParameterLabel)sender;
                if (SetParameter(label))
                {
                    if (label.NeedRemakeMap)
                    {
                        Define.DefineEnumProject.Map.EN_MAP_TYPE targetMap;
                        if (Enum.TryParse<Define.DefineEnumProject.Map.EN_MAP_TYPE>(label.AssociatedMap, out targetMap))
                        {
							// Map을 다시 그려야 할 경우 여기서 처리
                        }

						if (label.delAfterSetValue != null)
							label.delAfterSetValue(label.ParameterType, label.TaskName, label.ParameterName);
                    }
                }
            }
            else if (sender is CustomParameterButton)
            {
                CustomParameterButton btn = (CustomParameterButton)sender;
                if (SetParameter(btn))
                {
                    if (btn.NeedRemakeMap)
                    {
                        Define.DefineEnumProject.Map.EN_MAP_TYPE targetMap;
                        if (Enum.TryParse<Define.DefineEnumProject.Map.EN_MAP_TYPE>(btn.AssociatedMap, out targetMap))
                        {
							// Map을 다시 그려야 할 경우 여기서 처리
                        }

						if (btn.delAfterSetValue != null)
							btn.delAfterSetValue(btn.ParameterType, btn.TaskName, btn.ParameterName);
                    }
                }
            }
            else if (sender is CustomParameterToggleButton)
            {
                CustomParameterToggleButton btn = (CustomParameterToggleButton)sender;
                if (SetParameter(btn))
                {
                    btn.InformParameterValueChanged(btn, btn.Active);

                    if (btn.NeedRemakeMap)
                    {
                        Define.DefineEnumProject.Map.EN_MAP_TYPE targetMap;
                        if (Enum.TryParse<Define.DefineEnumProject.Map.EN_MAP_TYPE>(btn.AssociatedMap, out targetMap))
                        {
							// Map을 다시 그려야 할 경우 여기서 처리
                        }

						if (btn.delAfterSetValue != null)
							btn.delAfterSetValue(btn.ParameterType, btn.TaskName, btn.ParameterName);
                    }
                }
            }
        }

        private void OpenCustomJog(object sender, EventArgs e)
        {
            CustomJogButton jogButton = (CustomJogButton)sender;
			string recipeKey1, recipeKey2;

			if (jogButton.ParameterType1 == EN_RECIPE_TYPE.PROCESS)
				recipeKey1 = jogButton.TaskName1;
			else
				recipeKey1 = jogButton.ParameterType1.ToString();


			if (jogButton.ParameterType2 == EN_RECIPE_TYPE.PROCESS)
				recipeKey2 = jogButton.TaskName2;
			else
				recipeKey2 = jogButton.ParameterType2.ToString();

            FrameOfSystem3.Views.Functional.Jog.Form_Jog.GetInstance().CreateForm(
                jogButton.JogTitle,
				recipeKey1,
                jogButton.ParameterName1,
                jogButton.AxisIndex1,
				recipeKey2,
                jogButton.ParameterName2,
                jogButton.AxisIndex2);
        }

		private void DoTargetAction(object sender, EventArgs e)
		{
			CustomActionButton actionButton = (CustomActionButton)sender;

			string[] task = new string[] { actionButton.TaskName };
			string[] action = new string[] { actionButton.ActionName };

			m_strErrorMessage = String.Format("Do you want This Action START? \\n TASK NAME : {0} \\n ACTION NAME : {1}", actionButton.TaskName, actionButton.ActionName);
			if (false == m_instanceMessageBox.ShowMessage(m_strErrorMessage))
				return;

			bool rtn = Task.TaskOperator.GetInstance().SetOperation(ref task, ref action);

			if(rtn)
			{

			}
		}
    }
}
