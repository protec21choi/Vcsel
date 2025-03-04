﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrameOfSystem3.Views
{
    public partial class SubMenu : UserControl
    {
        public delegate bool callbackFunctionForEvent(string strEnum);
        public event callbackFunctionForEvent evtButtonClick;

		#region Constants
		private readonly Color c_clrFirst		= Color.White;
		private readonly Color c_clrSeccond		= Color.FromArgb(124, 123, 131);
		#endregion

		#region Variables
		private List<Sys3Controls.Sys3button> m_listOfButtons   = new List<Sys3Controls.Sys3button>();

        private Sys3Controls.Sys3button m_btnPreviousClicked;
        #endregion

        public SubMenu()
        {
            InitializeComponent();

            InitializeButtons();
        }

        #region Internal Interface
        /// <summary>
        /// 2020.02.05 by yjlee [ADD] Initialize the buttons.
        /// </summary>
        private void InitializeButtons()
        {            
            m_listOfButtons.Add(m_btn1);
            m_listOfButtons.Add(m_btn2);
            m_listOfButtons.Add(m_btn3);
            m_listOfButtons.Add(m_btn4);
            m_listOfButtons.Add(m_btn5);
            m_listOfButtons.Add(m_btn6);
            m_listOfButtons.Add(m_btn7);
            m_listOfButtons.Add(m_btn8);
            m_listOfButtons.Add(m_btn9);
            m_listOfButtons.Add(m_btn10);
            m_listOfButtons.Add(m_btn11);
            m_listOfButtons.Add(m_btn12);
            m_listOfButtons.Add(m_btn13);
            m_listOfButtons.Add(m_btn14);
            m_listOfButtons.Add(m_btn15);
            m_listOfButtons.Add(m_btn16);       // 2021.10.07 by jhchoo [ADD]

            // 2020.05.15 by twkang [ADD] Set the first button.
            m_btnPreviousClicked        = m_btn1;
        }
        /// <summary>
        /// 2020.05.15 by twkang [ADD] Display the button state that clicked.
        /// </summary>
        private void SetButtonClicked(ref Sys3Controls.Sys3button btnClicked)
        {
			m_btnPreviousClicked.GradientFirstColor		= c_clrFirst;
			m_btnPreviousClicked.GradientSecondColor	= c_clrFirst;
			m_btnPreviousClicked.MainFontColor			= c_clrSeccond;

            m_btnPreviousClicked.ButtonClicked			= false;
            m_btnPreviousClicked						= btnClicked;
            m_btnPreviousClicked.ButtonClicked			= true;

			m_btnPreviousClicked.GradientFirstColor		= c_clrSeccond;
			m_btnPreviousClicked.GradientSecondColor	= c_clrSeccond;
			m_btnPreviousClicked.MainFontColor			= c_clrFirst;
        }
        #endregion

        #region External Interface

        #region Set Buttons
        /// <summary>
        /// 2020.02.05 by yjlee [ADD] Set the button's text and state.
        /// </summary>
        public void SetButtons(List<string> listOfButtonNames)
        {
            foreach(var btn in m_listOfButtons)
            {
                btn.Visible     = false;
            }

            int nCountOfItem    = listOfButtonNames.Count > m_listOfButtons.Count
                ? m_listOfButtons.Count : listOfButtonNames.Count;

            for(int i = 0 ; i < listOfButtonNames.Count ; ++ i)
            {
                // 2021.04.30. by shkim. [ADD] FAKE BUTTON 숨김
                if (listOfButtonNames[i].Contains("FAKE")) continue;

                m_listOfButtons[i].Text     = listOfButtonNames[i];
                m_listOfButtons[i].Visible  = true;
            }

            SetButtonClicked(ref m_btn1);
        }
        /// <summary>
        /// 2020.05.15 by yjlee [ADD] Set the clicked button by the string name.
        /// </summary>
        public void SetClickedButton(string strButtonName)
        {
            m_btnPreviousClicked.ButtonClicked      = false;

            foreach (var btn in m_listOfButtons)
            {
                if(strButtonName.Equals(btn.Text))
                {
					Sys3Controls.Sys3button	sys3btn	= btn;
					SetButtonClicked(ref sys3btn);
                }
            }

            m_btnPreviousClicked.ButtonClicked      = true;
        }
        #endregion

        #endregion

        #region GUI Event
        /// <summary>
        /// 2020.05.15 by twkang [MOD] Set the state of button clicked.
        /// </summary>
        private void ClickButtons(object sender, EventArgs e)
        {
            Sys3Controls.Sys3button btn = (Sys3Controls.Sys3button)sender;

            if(evtButtonClick(btn.Text))
			{
				SetButtonClicked(ref btn);
			}
        }
        #endregion
    }
}
