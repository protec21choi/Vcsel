﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FrameOfSystem3.Component;

namespace FrameOfSystem3.Views.Functional.Jog
{
	public partial class JogPanel_DpadNormal : UserControl
	{
		#region <CONSTRUCTOR>
		public JogPanel_DpadNormal(Form_Jog parentsInstance)
		{
			InitializeComponent();

			_parents = parentsInstance;
		}
		#endregion </CONSTRUCTOR>

		#region <FILED>
		Form_Jog _parents = null;
		#endregion </FILED>

		#region <UI EVENT>
		private void Down_Mouse(object sender, MouseEventArgs e)
		{
			bool clickLR = true;
			bool clickUD = true;
			bool directionLR = true;
			bool directionUD = true;

			if (sender == btn_Left || sender == btn_Right)
				clickUD = false;
			else if (sender == btn_Up || sender == btn_Down)
				clickLR = false;

			if (sender == btn_Left || sender == btn_UpLeft || sender == btn_DownLeft)
				directionLR = false;
			if (sender == btn_Down || sender == btn_DownLeft || sender == btn_DownRight)
				directionUD = false;

			_parents.Down_Mouse(clickLR, clickUD, directionLR, directionUD, false);
		}
		private void Up_Mouse(object sender, MouseEventArgs e)
		{
            bool clickLR = true;
            bool clickUD = true;

            if (sender == btn_Left || sender == btn_Right)
                clickUD = false;
            else if (sender == btn_Up || sender == btn_Down)
                clickLR = false;

            _parents.Up_Mouse(clickLR, clickUD, false);
		}
		private void Click_Stop(object sender, EventArgs e)
		{
            bool clickLR = true;
            bool clickUD = true;

            _parents.Click_Stop(clickLR, clickUD, false);
		}
		#endregion </UI EVENT>

		#region <INTERFACE>

		public void SetAcitveMoveButtons(bool useX, bool useY)
		{
			btn_Stop.Enabled = useX || useY;

			if (useX)
			{
				btn_Left.Show();
				btn_Right.Show();
			}
			else
			{
				btn_Left.Hide();
				btn_Right.Hide();
			}

			if (useY)
			{
				btn_Up.Show();
				btn_Down.Show();
			}
			else
			{
				btn_Up.Hide();
				btn_Down.Hide();
			}

			if (useX && useY)
			{
				btn_UpLeft.Show();
				btn_UpRight.Show();
				btn_DownLeft.Show();
				btn_DownRight.Show();
			}
			else
			{
				btn_UpLeft.Hide();
				btn_UpRight.Hide();
				btn_DownLeft.Hide();
				btn_DownRight.Hide();
			}
		}
		#endregion </INTERFACE>

	}
}
