using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrameOfSystem3.Views.Setup
{
    public partial class Setup_Equipment : UserControlForMainView.CustomView
	{

		#region Construct
		public Setup_Equipment()
		{
			InitializeComponent();

			InitControl();

			#region TabIndex
            m_tab0.TabIndex = (int)EN_TABINDEX.LASER;
            m_tab1.TabIndex = (int)EN_TABINDEX.DEVICE;
            m_tab2.TabIndex = (int)EN_TABINDEX.PRE_EQUIPMENT;
            m_tab3.TabIndex = (int)EN_TABINDEX.EFEM;
            m_tab4.TabIndex = (int)EN_TABINDEX.TOOL;
			#endregion
		}

		private void InitControl()
		{
            m_pnSubView.Controls.Add(m_pnLaser);
            m_pnSubView.Controls.Add(m_pnDevice);
            m_pnSubView.Controls.Add(m_pnPreEqComm);
            m_pnSubView.Controls.Add(m_pnEFEMComm);
            m_pnSubView.Controls.Add(m_pnTool);

			m_btnSelectedPanel = m_tab0;
            m_ISelectedPanel = m_pnLaser as ISetupPanel;

            m_pnDevice.Hide();
            m_pnPreEqComm.Hide();
            m_pnEFEMComm.Hide();
            m_pnTool.Hide();
		}
		#endregion

		#region Enum
		private enum EN_TABINDEX
		{
            LASER = 0,
            DEVICE = 1,
            PRE_EQUIPMENT = 2,
            EFEM = 3,
            TOOL = 4,
		}
		#endregion

		#region Variable
		#region Panel
        private Equipment.Equipment_Laser m_pnLaser = new Equipment.Equipment_Laser();
        private Equipment.Equipment_Device m_pnDevice = new Equipment.Equipment_Device();
        private Equipment.Equipment_PreEquipComm m_pnPreEqComm = new Equipment.Equipment_PreEquipComm();
        private Equipment.Equipment_EFEMComm m_pnEFEMComm = new Equipment.Equipment_EFEMComm();
        private Equipment.Equipment_Tool m_pnTool = new Equipment.Equipment_Tool();

		private ISetupPanel m_ISelectedPanel	= null;
		private Sys3Controls.Sys3button m_btnSelectedPanel	= null;
		#endregion
      
        private FrameOfSystem3.Recipe.Recipe m_instanceRecipe = FrameOfSystem3.Recipe.Recipe.GetInstance();
        Functional.Form_MessageBox m_MessageBox = Functional.Form_MessageBox.GetInstance();
		#endregion

		#region Override Interface
		protected override void ProcessWhenActivation()
		{
			m_ISelectedPanel.Activation();

		}
		protected override void ProcessWhenDeactivation()
		{
			m_ISelectedPanel.Deactivation();

            if (m_instanceRecipe.IsExistDeferredStorage())
            {
                if (m_MessageBox.ShowMessage("Do You Want To Save Recipe?"))
                    m_instanceRecipe.ApplyDeferredStorage();
                else
                    m_instanceRecipe.ClearDeferredStorage();
            }
		}
		public override void CallFunctionByTimer()
		{
			m_ISelectedPanel.CallFunction();
		}
		#endregion

		private void Click_Tab(object sender, EventArgs e)
		{
			Sys3Controls.Sys3button btnClicked = sender as Sys3Controls.Sys3button;

			if (m_btnSelectedPanel.Equals(btnClicked) == true)
				return;

			m_btnSelectedPanel.GradientFirstColor = Color.White;
			m_btnSelectedPanel.GradientSecondColor = Color.White;
			m_btnSelectedPanel.MainFontColor = Color.DarkBlue;
			m_btnSelectedPanel.ButtonClicked = false;
			m_ISelectedPanel.Deactivation();

			switch (btnClicked.TabIndex)
			{
                case (int)EN_TABINDEX.LASER:
                    m_ISelectedPanel = m_pnLaser as ISetupPanel;
                    break;

                case (int)EN_TABINDEX.DEVICE:
                    m_ISelectedPanel = m_pnDevice as ISetupPanel;
                    break;

                case (int)EN_TABINDEX.PRE_EQUIPMENT:
                    m_ISelectedPanel = m_pnPreEqComm as ISetupPanel;
                    break;

                case (int)EN_TABINDEX.EFEM:
                    m_ISelectedPanel = m_pnEFEMComm as ISetupPanel;
                    break;

                case (int)EN_TABINDEX.TOOL:
                    m_ISelectedPanel = m_pnTool as ISetupPanel;
                    break;
			}

			m_btnSelectedPanel = btnClicked;
			m_btnSelectedPanel.ButtonClicked = true;
			m_btnSelectedPanel.GradientFirstColor = Color.DarkBlue;
			m_btnSelectedPanel.GradientSecondColor = Color.DarkBlue;
			m_btnSelectedPanel.MainFontColor = Color.White;

			m_ISelectedPanel.Activation();
		}

        private void ClickParameterUndo(object sender, EventArgs e)
        {
            if (m_MessageBox.ShowMessage("Do You Want To Undo Recipe?"))
                m_instanceRecipe.ClearDeferredStorage();

            ProcessWhenActivation();
        }

        private void ClickParameterSave(object sender, EventArgs e)
        {
            if (m_MessageBox.ShowMessage("Do You Want To Save Recipe?"))
                m_instanceRecipe.ApplyDeferredStorage();

            ProcessWhenActivation();
        }
	}
}
