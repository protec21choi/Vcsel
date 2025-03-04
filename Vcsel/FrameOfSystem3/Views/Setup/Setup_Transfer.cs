using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using EQUIPMENT_PARAM = FrameOfSystem3.Recipe.PARAM_EQUIPMENT;
using BONDER_TASK_PARAM = Define.DefineEnumProject.Task.BondHead.PARAM_PROCESS;
using WORKZONE_TASK_PARAM = Define.DefineEnumProject.Task.WorkZone.PARAM_PROCESS;
using TRANSFER_TASK_PARAM = Define.DefineEnumProject.Task.Transfer.PARAM_PROCESS;

using Define.DefineEnumProject.Motion;
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
 
namespace FrameOfSystem3.Views.Setup
{
    public partial class Setup_Transfer : UserControlForMainView.CustomView
	{
        public Setup_Transfer()
		{
			InitializeComponent();

            #region TabIndex
            m_tab0.TabIndex = (int)EN_TABINDEX.PRE_EQUIPMENT;
            m_tab1.TabIndex = (int)EN_TABINDEX.BLOCK;
            #endregion

            InitControl();
		}

        #region Constants
        private readonly Color c_clrMonitor = Color.LightGray;
        private readonly Color c_clrControl = Color.SteelBlue;
        private readonly Color c_clrTrue = Color.Green;
        private readonly Color c_clrFalse = Color.White;
        #endregion
        #region Enum
        private enum EN_TABINDEX
        {
            PRE_EQUIPMENT = 0,
            BLOCK = 1,
        }
        #endregion

        #region <FIELD>
        private FrameOfSystem3.Recipe.Recipe m_instanceRecipe = FrameOfSystem3.Recipe.Recipe.GetInstance();
        TaskOperator m_Operator = TaskOperator.GetInstance();
        Functional.Form_MessageBox m_MessageBox = Functional.Form_MessageBox.GetInstance();

        private Transfer.Transfer_PreEquipment m_pnTransferPreEquipment = new Transfer.Transfer_PreEquipment();
        private Transfer.Transfer_Block m_pnTransferBlock = new Transfer.Transfer_Block();

        private ISetupPanel m_ISelectedPanel = null;
        private Sys3Controls.Sys3button m_btnSelectedPanel = null;

        #endregion </FIELD>
      
        #region <OVERRIDE>
        public override void CallFunctionByTimer()
		{
			base.CallFunctionByTimer();
            m_ISelectedPanel.CallFunction();
		}
		protected override void ProcessWhenActivation()
		{
            base.ProcessWhenActivation();
            m_ISelectedPanel.Activation();


		}
		protected override void ProcessWhenDeactivation()
		{
			base.ProcessWhenDeactivation();

            if (m_instanceRecipe.IsExistDeferredStorage())
            {
                if (m_MessageBox.ShowMessage("Do You Want To Save Recipe?"))
                    m_instanceRecipe.ApplyDeferredStorage();
                else
                    m_instanceRecipe.ClearDeferredStorage();
            }
            m_ISelectedPanel.Deactivation();

		}
		#endregion </OVERRIDE>

        #region <INTERNAL>
        private void InitControl()
        {
            m_pnSubView.Controls.Add(m_pnTransferPreEquipment);
            m_pnSubView.Controls.Add(m_pnTransferBlock);

            m_btnSelectedPanel = m_tab0;
            m_ISelectedPanel = m_pnTransferPreEquipment as ISetupPanel;

            m_pnTransferBlock.Hide();
        }

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
                case (int)EN_TABINDEX.PRE_EQUIPMENT:
                    m_ISelectedPanel = m_pnTransferPreEquipment as ISetupPanel;
                    break;


                case (int)EN_TABINDEX.BLOCK:
                    m_ISelectedPanel = m_pnTransferBlock as ISetupPanel;
                    break;
            }

            m_btnSelectedPanel = btnClicked;
            m_btnSelectedPanel.ButtonClicked = true;
            m_btnSelectedPanel.GradientFirstColor = Color.DarkBlue;
            m_btnSelectedPanel.GradientSecondColor = Color.DarkBlue;
            m_btnSelectedPanel.MainFontColor = Color.White;

            m_ISelectedPanel.Activation();
        }
 
        private void Click_Stop(object sender, EventArgs e)
        {
            Task.TaskOperator.GetInstance().SetOperation(RunningMain_.OPERATION_EQUIPMENT.STOP);
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
                    arSelectAction = new string[1][];
                    arSelectTask = new string[] { EN_TASK_LIST.TRANSFER.ToString() };
                    arSelectAction[0] = new string[] { Define.DefineEnumProject.Task.Transfer.EN_TASK_ACTION.EQUIPMENT_LOADING.ToString() };
                    Task.TaskOperator.GetInstance().SetOperation(ref arSelectTask, ref arSelectAction, nRetryTime);
                    break;

                case 1:
                    arSelectAction = new string[2][];
                    arSelectTask = new string[] {EN_TASK_LIST.TRANSFER.ToString() , EN_TASK_LIST.WORK_ZONE.ToString() };
                    arSelectAction[0] = new string[] {Define.DefineEnumProject.Task.Transfer.EN_TASK_ACTION.BLOCK_LOADING.ToString() , "" };
                    arSelectAction[1] = new string[] {"" , Define.DefineEnumProject.Task.WorkZone.EN_TASK_ACTION.LOADING.ToString() };
                    Task.TaskOperator.GetInstance().SetOperation(ref arSelectTask, ref arSelectAction, nRetryTime);
                    break;

                case 2:
                    arSelectAction = new string[2][];
                    arSelectTask = new string[] {EN_TASK_LIST.TRANSFER.ToString() , EN_TASK_LIST.WORK_ZONE.ToString() };
                    arSelectAction[0] = new string[] {"" , Define.DefineEnumProject.Task.WorkZone.EN_TASK_ACTION.UNLOADING.ToString() };
                    arSelectAction[1] = new string[] {Define.DefineEnumProject.Task.Transfer.EN_TASK_ACTION.BLOCK_UNLOADING.ToString() , "" };
                    Task.TaskOperator.GetInstance().SetOperation(ref arSelectTask, ref arSelectAction, nRetryTime);
                    break;

                case 3:
                    arSelectAction = new string[1][];
                    arSelectTask = new string[] { EN_TASK_LIST.TRANSFER.ToString() };
                    arSelectAction[0] = new string[] { Define.DefineEnumProject.Task.Transfer.EN_TASK_ACTION.EQUIPMENT_UNLOADING.ToString() };
                    Task.TaskOperator.GetInstance().SetOperation(ref arSelectTask, ref arSelectAction, nRetryTime);
                    break;
            }
        }

      
        #endregion </INTERNAL>

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
