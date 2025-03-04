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

using FrameOfSystem3.Functional;
using FrameOfSystem3.ExternalDevice;

namespace FrameOfSystem3.Views.Setup.Equipment
{
    public partial class Equipment_EFEMComm : UserControl, ISetupPanel
    {
        #region Consturct
        public Equipment_EFEMComm()
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

            // ExternalDevice.Wcf.WcfLogEvent.onWriteLog += new ExternalDevice.Wcf.WcfLogEvent.EventWriteLog(WriteLog);
            EfemLogMessageEvent.onWriteLog += new EfemLogMessageEvent.WriteLogEvent(WriteLog);


            m_instanceEFEM = EFEMManager.GetInstance();
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
        private EFEMManager m_instanceEFEM = null;
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
            lbl_PreEqHostStatus.Text = ExternalDevice.EFEMManager.GetInstance().GetHostStatus();
            lbl_PreEqConnectStatus.Text = ExternalDevice.EFEMManager.GetInstance().GetServerStatus();
        }
        #endregion

        #region Internal Interface
        private void InitalizeGridVeiw()
        {
            GridViewControl_Parameter.ParameterItem AddParaItem;

            List<GridViewControl_Parameter.ParameterItem> parameterList = new List<GridViewControl_Parameter.ParameterItem>();

            AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.EFEM_USE, 0);
            AddParaItem.DisplayName = "EFEM COMM USED";
            AddParaItem.ParameterSettingType = Define.DefineEnumBase.Component.EN_PARAMETER_SETTING_TYPE.TRUE_FALSE;
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.EFEM_HOST_IP, 0);
            AddParaItem.DisplayName = "EFEM HOST IP";
            AddParaItem.ParameterSettingType = Define.DefineEnumBase.Component.EN_PARAMETER_SETTING_TYPE.KEYBOARD;
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.EFEM_HOST_PORT, 0);
            AddParaItem.DisplayName = "EFEM HOST PORT";
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.EFEM_TARGET_IP, 0);
            AddParaItem.DisplayName = "EFEM TARGET IP";
            AddParaItem.ParameterSettingType = Define.DefineEnumBase.Component.EN_PARAMETER_SETTING_TYPE.KEYBOARD;
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.EFEM_TARGET_PORT, 0);
            AddParaItem.DisplayName = "EFEM TARGET PORT";
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.EFEM_UPDATE_ECID, 0);
            AddParaItem.DisplayName = "EFEM UPDATE ECID";
            AddParaItem.ParameterSettingType = Define.DefineEnumBase.Component.EN_PARAMETER_SETTING_TYPE.TRUE_FALSE;
            parameterList.Add(AddParaItem);


            AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.EFEM_FDC_LOGGING, 0);
            AddParaItem.DisplayName = "EFEM FDC LOGGING";
            AddParaItem.ParameterSettingType = Define.DefineEnumBase.Component.EN_PARAMETER_SETTING_TYPE.TRUE_FALSE;
            parameterList.Add(AddParaItem);

            AddParaItem = new GridViewControl_Parameter.ParameterItem(EQUIPMENT_PARAM.EFEM_FDC_INTERVAL, 0);
            AddParaItem.DisplayName = "EFEM FDC INTERVAL";
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

        #region manual request
        private void Click_GetEfemMessage(object sender, EventArgs e)
        {
//             Sys3Controls.Sys3Label label = sender as Sys3Controls.Sys3Label;
//             if (label == null) return;
// 
//             Functional.Form_SelectionList selectionList = Functional.Form_SelectionList.GetInstance();
// 
//             if (selectionList.CreateForm("EFEM MESSAGE"
//                 , Enum.GetNames(typeof(EFEMManager.EN_EFEM_MESSAGE))
//                 , lbl_TargetEfemMessage.Text))
//             {
//                 string message = string.Empty;
//                 selectionList.GetResult(ref message);
//                 lbl_TargetEfemMessage.Text = message;
//             }
        }
        private void Click_SendEfemMessage(object sender, EventArgs e)
        {
            EFEMManager.EN_EFEM_MESSAGE efemMessage;
//             if (false == Enum.TryParse(lbl_TargetEfemMessage.Text, out efemMessage))
//             {
//                 WriteLog("-- Is Abnormal Message. Please check property of controls (EFEM MESSAGE)");
//                 return;
//             }
// 
//             m_instanceEFEM.DoRequest(efemMessage);

            m_instanceEFEM.UpdateECID_ALL();
        }

        private void Click_GetCeid(object sender, EventArgs e)
        {
            var label = sender as Sys3Controls.Sys3Label;
            if (label == null) return;

            var selectionList = Functional.Form_SelectionList.GetInstance();

            if (selectionList.CreateForm("CEID"
                , Enum.GetNames(typeof(EFEMManager.EN_CEID))
                , lbl_TargetCeid.Text))
            {
                string message = string.Empty;
                selectionList.GetResult(ref message);
                lbl_TargetCeid.Text = message;
            }
        }
        private void Click_RmsTest(object sender, EventArgs e)
        {
            if (sender == lbl_RecipeDownload)
            {
                string path, name;
                if (false == FunctionsETC.GetFilePathWithOpenFileDialog(out path, out name)) return;

                var messageData = new Dictionary<string, string>();
                messageData.Add("PATH", path);
                messageData.Add("NAME", name);
                string result, description;
                m_instanceEFEM.ReceiveRMS(EFEMManager.EN_RMS.DOWNLOAD_RECIPE.ToString(), messageData, out result, out description);
            }
            else if (sender == lbl_RecipeUpload)
            {
                bool result = m_instanceEFEM.RequestRecipeUpload();
                _MessageBox_Instance_m_p.ShowMessage(result ? "Success" : "Fail");
            }
        }
        private void Click_SendSecsGemEvent(object sender, EventArgs e)
        {
            EFEMManager.EN_CEID ceid;
            if (false == Enum.TryParse(lbl_TargetCeid.Text, out ceid))
            {
                WriteLog("-- Is Abnormal Message. Please check property of controls (CEID)");
                return;
            }

            if(Work.WorkMap.GetInstance().GetID() == string.Empty)
            {
                Work.WorkMap.GetInstance().ResetMap("TEST_ID");
            }
            // 2023.04.30 by junho [MOD] mail로 변경
            //Work.UIComunicationEvent.Inform_ToTask(Work.UIComunicationEvent.EN_REQUEST_FROM_UI.SECSGEM_SEND_CEID, Define.DefineEnumProject.Task.EN_TASK_LIST.Device.ToString()
            //	, new object[] { ceid });
            //             PostOffice.GetInstance().SendMail(Define.DefineEnumProject.Mail.EN_SUBSCRIBER.EFEM_MANAGER, Define.DefineEnumProject.Mail.EN_MAIL.SendSecsGemCEID
            //                 , new object[] { ceid });
            m_instanceEFEM.AddQueCeid(ceid);
        }
        #endregion /manual request
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

        private void Click_Test_Alarm(object sender, EventArgs e)
        {
            Alarm_.Alarm.GetInstance().GenerateAlarm(0, 0, 1, false);
        }
    }
}
