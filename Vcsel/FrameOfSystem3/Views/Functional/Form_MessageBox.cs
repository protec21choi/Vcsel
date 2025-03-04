using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrameOfSystem3.Views.Functional
{
    /// <summary>
    /// 2018.06.23 by yjlee [ADD] OK , CANCEL을 위한 확인용 메시지 폼이다.
    /// </summary>
    public partial class Form_MessageBox : Form
    {
        #region 싱글톤
        private static Form_MessageBox _Instance = null;
        public static Form_MessageBox GetInstance()
        {
            if (_Instance == null)
            {
                _Instance = new Form_MessageBox();
            }

            return _Instance;
        }
        private Form_MessageBox()
        {
            DoubleBuffered = true;

			m_InstanceOfLanguage	= FrameOfSystem3.Config.ConfigLanguage.GetInstance();

            InitializeComponent();
        }
        #endregion

		#region 상수
		private readonly string OK_BUTTON_TEXT					= "OK";
		private readonly string CANCEL_BUTTON_TEXT				= "CANCEL";
		#endregion

		#region 변수

		#region Instance
		FrameOfSystem3.Config.ConfigLanguage m_InstanceOfLanguage		= null;
		#endregion

		#region GUI
		private bool m_bMouseDownTitle					= false;
		private Point m_pMouseDownCoordinate			= new Point();
		#endregion

		#endregion

		#region Internal Interface
		/// <summary>
		/// 2021.08.24 by twkang [ADD] 이벤트 처리
		/// </summary>
		private void ProcessingEvent(Keys enInputedKey)
		{
			switch(enInputedKey)
			{
				case Keys.Enter:
					this.DialogResult = System.Windows.Forms.DialogResult.OK;
					break;
				case Keys.Escape:
					this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
					break;
				default:
					return;
			}

			this.Close();
		}
		#endregion

		#region 외부 인터페이스
		/// <summary>
        /// 2018.06.23 by yjlee [ADD] 메시지 창을 화면에 출력한다.
        /// </summary>
        /// <param name="strMessage"></param>
        /// <returns></returns>
        public bool ShowMessage(string strMessage, string strTitle = "CONFIRMATION MESSAGE", bool bBuzzer = false)
        {
            m_labelMessage.Text = strMessage;

            m_TitleBar.Text		= m_InstanceOfLanguage.TranslateWord(strTitle);
            m_btnOK.Text		= m_InstanceOfLanguage.TranslateWord(OK_BUTTON_TEXT);
            m_btnCancel.Text	= m_InstanceOfLanguage.TranslateWord(CANCEL_BUTTON_TEXT);

            if (bBuzzer)
            {
                DigitalIO_.DigitalIO.GetInstance().WriteOutput((int)Define.DefineEnumProject.DigitalIO.EN_DIGITAL_OUT.BUZZER, true);
            }
            this.CenterToScreen();

            if(!this.Modal)
                this.ShowDialog();

            DigitalIO_.DigitalIO.GetInstance().WriteOutput((int)Define.DefineEnumProject.DigitalIO.EN_DIGITAL_OUT.BUZZER, false);

            if (this.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                return true;
            }

            return false;
        }
        #endregion

        #region UI 이벤트 처리
        /// <summary>
        /// 2018.06.23 by yjlee [ADD] OK 또는 CANCEL 버튼을 눌렀을 경우 처리
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_OkorCancel(object sender, EventArgs e)
        {
            Control ctr = sender as Control;

            switch (ctr.TabIndex)
            {
                case 0: // OK
					ProcessingEvent(Keys.Enter);
                    break;
                case 1: // CANCEL
					ProcessingEvent(Keys.Escape);
                    break;
            }
        }
		/// <summary>
		/// 2021.07.28 by twkang [ADD] TitleBar Mouse Down 이벤트
		/// </summary>
		private void MouseDown_Title(object sender, MouseEventArgs e)
		{
			m_bMouseDownTitle = true;
			m_pMouseDownCoordinate = e.Location;
		}
		/// <summary>
		/// 2021.07.28 by twkang [ADD] TitleBar Mouse Move 이벤트
		/// </summary>
		private void MouseMove_Title(object sender, MouseEventArgs e)
		{
			if (m_bMouseDownTitle)
			{
				this.SetDesktopLocation(MousePosition.X - m_pMouseDownCoordinate.X, MousePosition.Y - m_pMouseDownCoordinate.Y);
			}
		}
		/// <summary>
		/// 2021.07.28 by twkang [ADD] TitleBar Mouse Up 이벤트
		/// </summary>
		private void MouseUp_Title(object sender, MouseEventArgs e)
		{
			m_bMouseDownTitle = false;
		}

		/// <summary>
		/// 2021.08.24 by twkang [ADD] 키입력 이벤트
		/// </summary>
		private void KeyDown_Event(object sender, KeyEventArgs e)
		{
			ProcessingEvent(e.KeyCode);
		}
        #endregion
    }
}
