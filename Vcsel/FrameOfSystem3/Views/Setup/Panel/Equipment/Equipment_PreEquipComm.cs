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
    public partial class Equipment_PreEquipComm : UserControl, ISetupPanel
    {
        #region Consturct
        public Equipment_PreEquipComm()
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

            ExternalDevice.Wcf.WcfLogEvent.onWriteLog += new ExternalDevice.Wcf.WcfLogEvent.EventWriteLog(WriteLog);

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
            gridViewControl_Pre_Equip_Parameter.UpdateValue();
          
			this.Show();
        }
        public void Deactivation()
        {
			this.Hide();
        }
        public void CallFunction()
        {
            lbl_PreEqHostStatus.Text = ExternalDevice.TransportWIR.GetInstance().GetHostState();
            lbl_PreEqConnectStatus.Text = ExternalDevice.TransportWIR.GetInstance().GetConnectState();
        }
        #endregion

        #region Internal Interface
        private void InitalizeGridVeiw()
        {
            GridViewControl_Parameter.ParameterItem AddParaItem;

            List<GridViewControl_Parameter.ParameterItem> parameterList = new List<GridViewControl_Parameter.ParameterItem>();

            AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.PREEQUIPMENT_WCF_USED, 0);
            AddParaItem.DisplayName = "PRE EQ COMM USED";
            AddParaItem.ParameterSettingType = Define.DefineEnumBase.Component.EN_PARAMETER_SETTING_TYPE.TRUE_FALSE;
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.PREEQUIPMENT_HOST_IP, 0);
            AddParaItem.DisplayName = "PRE EQ HOST IP";
            AddParaItem.ParameterSettingType = Define.DefineEnumBase.Component.EN_PARAMETER_SETTING_TYPE.KEYBOARD;
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.PREEQUIPMENT_HOST_PORT, 0);
            AddParaItem.DisplayName = "PRE EQ HOST PORT";
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.PREEQUIPMENT_TARGET_IP, 0);
            AddParaItem.DisplayName = "PRE EQ TARGET IP";
            AddParaItem.ParameterSettingType = Define.DefineEnumBase.Component.EN_PARAMETER_SETTING_TYPE.KEYBOARD;
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.PREEQUIPMENT_TARGET_PORT, 0);
            AddParaItem.DisplayName = "PRE EQ TARGET PORT";
            parameterList.Add(AddParaItem);

            gridViewControl_Pre_Equip_Parameter.Initialize(parameterList);
        }
        #endregion

		#region UI Event
        private void Click_Conection(object sender, EventArgs e)
        {
            Control ctrButton = sender as Control;

            switch (ctrButton.TabIndex)
            {
                case 0:
                    ExternalDevice.TransportWIR.GetInstance().Open();
                    break;
                case 1:
                    ExternalDevice.TransportWIR.GetInstance().Close();
                    break;
                case 2:
                    ExternalDevice.TransportWIR.GetInstance().Connect();
                    break;
                case 3:
                    ExternalDevice.TransportWIR.GetInstance().Disconnect();
                    break;
            }
        }

        private void Click_Send_Message(object sender, EventArgs e)
        {
            Control ctrButton = sender as Control;

            switch (ctrButton.TabIndex)
            {
                case 20850:
                    bool bresult = ExternalDevice.TransportWIR.GetInstance().SendWorkResult(1, Work.EN_WORK_STATUS.HIGH_TEMP);
                    break;
            }
        }
        #endregion     


        #region messsage log
        private delegate void WriteLogCallBack(string message);
        private void WriteLog(string fullMessage)
        {
            if (this.InvokeRequired)
            {
                WriteLogCallBack d = new WriteLogCallBack(WriteLog);
                this.Invoke(d, fullMessage);
            }
            else
            {

                string now = DateTime.Now.ToString();

                string[] splitMessage = fullMessage.Split('\n');

                for (int i = splitMessage.Length - 1; i >= 0; i--)
                {
                    m_listMessage.Items.Insert(0, string.Format("[{0}] {1}", now, splitMessage[i]));
                }

                while (m_listMessage.Items.Count > 500)
                {
                    try
                    {
                        m_listMessage.Items.RemoveAt(m_listMessage.Items.Count - 1);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        break;
                    }
                }
            }
        }
        private void ClearLog(object sender, EventArgs e)
        {
            m_listMessage.Items.Clear();
        }
        #endregion /messsage log
    }
}
