﻿namespace FrameOfSystem3.Views.Config.MotionPanel
{
	partial class MotorLimit
	{
		/// <summary> 
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		/// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region 구성 요소 디자이너에서 생성한 코드

		/// <summary> 
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
			this.m_ToggleHWLimitPositive = new Sys3Controls.Sys3ToggleButton();
			this.m_ToggleHWLimitNegative = new Sys3Controls.Sys3ToggleButton();
			this.m_ToggleSWLimitPositive = new Sys3Controls.Sys3ToggleButton();
			this.m_ToggleSWLimitNegative = new Sys3Controls.Sys3ToggleButton();
			this.m_labelSWLimitStopModePositive = new Sys3Controls.Sys3Label();
			this.m_labelSWLimitStopModeNegative = new Sys3Controls.Sys3Label();
			this.m_labelSWLimitPositionPositive = new Sys3Controls.Sys3Label();
			this.m_labelSWLimitPositionNegative = new Sys3Controls.Sys3Label();
			this.m_labelHWLimitStopModePositive = new Sys3Controls.Sys3Label();
			this.m_labelHWLimitStopModeNegative = new Sys3Controls.Sys3Label();
			this.m_labelHWLimitLogicPositive = new Sys3Controls.Sys3Label();
			this.m_labelHWLimitLogicNegative = new Sys3Controls.Sys3Label();
			this.m_lblUseSWLimitPositive = new Sys3Controls.Sys3Label();
			this.m_lblUseHWLimitPositive = new Sys3Controls.Sys3Label();
			this.m_lblSWLimitPositionPositive = new Sys3Controls.Sys3Label();
			this.m_lblHWLimitLogicPositive = new Sys3Controls.Sys3Label();
			this.m_lblSWLimitStopModePositive = new Sys3Controls.Sys3Label();
			this.m_lblHWLimitStopModePositive = new Sys3Controls.Sys3Label();
			this.m_lblSWLimitStopModeNegative = new Sys3Controls.Sys3Label();
			this.m_lblSWLimitPositionNegative = new Sys3Controls.Sys3Label();
			this.m_lblHWLimitStopModeNegative = new Sys3Controls.Sys3Label();
			this.m_lblUseSWLimitNegative = new Sys3Controls.Sys3Label();
			this.m_lblHWLimitLogicNegative = new Sys3Controls.Sys3Label();
			this.m_lblUseHWLimitNegative = new Sys3Controls.Sys3Label();
			this.m_groupHWLimitConfig = new Sys3Controls.Sys3GroupBox();
			this.m_groupSWLimitConfig = new Sys3Controls.Sys3GroupBox();
			this.SuspendLayout();
			// 
			// m_ToggleHWLimitPositive
			// 
			this.m_ToggleHWLimitPositive.Active = false;
			this.m_ToggleHWLimitPositive.ActiveColorFirst = System.Drawing.Color.RoyalBlue;
			this.m_ToggleHWLimitPositive.ActiveColorSecond = System.Drawing.Color.DodgerBlue;
			this.m_ToggleHWLimitPositive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_ToggleHWLimitPositive.Enabled = false;
			this.m_ToggleHWLimitPositive.Location = new System.Drawing.Point(373, 49);
			this.m_ToggleHWLimitPositive.Name = "m_ToggleHWLimitPositive";
			this.m_ToggleHWLimitPositive.NormalColorFirst = System.Drawing.Color.DarkGray;
			this.m_ToggleHWLimitPositive.NormalColorSecond = System.Drawing.Color.Silver;
			this.m_ToggleHWLimitPositive.Size = new System.Drawing.Size(114, 57);
			this.m_ToggleHWLimitPositive.TabIndex = 3;
			this.m_ToggleHWLimitPositive.Click += new System.EventHandler(this.Click_HWLimitLabels);
			// 
			// m_ToggleHWLimitNegative
			// 
			this.m_ToggleHWLimitNegative.Active = false;
			this.m_ToggleHWLimitNegative.ActiveColorFirst = System.Drawing.Color.RoyalBlue;
			this.m_ToggleHWLimitNegative.ActiveColorSecond = System.Drawing.Color.DodgerBlue;
			this.m_ToggleHWLimitNegative.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_ToggleHWLimitNegative.Enabled = false;
			this.m_ToggleHWLimitNegative.Location = new System.Drawing.Point(373, 223);
			this.m_ToggleHWLimitNegative.Name = "m_ToggleHWLimitNegative";
			this.m_ToggleHWLimitNegative.NormalColorFirst = System.Drawing.Color.DarkGray;
			this.m_ToggleHWLimitNegative.NormalColorSecond = System.Drawing.Color.Silver;
			this.m_ToggleHWLimitNegative.Size = new System.Drawing.Size(114, 57);
			this.m_ToggleHWLimitNegative.TabIndex = 0;
			this.m_ToggleHWLimitNegative.Click += new System.EventHandler(this.Click_HWLimitLabels);
			// 
			// m_ToggleSWLimitPositive
			// 
			this.m_ToggleSWLimitPositive.Active = false;
			this.m_ToggleSWLimitPositive.ActiveColorFirst = System.Drawing.Color.RoyalBlue;
			this.m_ToggleSWLimitPositive.ActiveColorSecond = System.Drawing.Color.DodgerBlue;
			this.m_ToggleSWLimitPositive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_ToggleSWLimitPositive.Enabled = false;
			this.m_ToggleSWLimitPositive.Location = new System.Drawing.Point(942, 50);
			this.m_ToggleSWLimitPositive.Name = "m_ToggleSWLimitPositive";
			this.m_ToggleSWLimitPositive.NormalColorFirst = System.Drawing.Color.DarkGray;
			this.m_ToggleSWLimitPositive.NormalColorSecond = System.Drawing.Color.Silver;
			this.m_ToggleSWLimitPositive.Size = new System.Drawing.Size(114, 57);
			this.m_ToggleSWLimitPositive.TabIndex = 3;
			this.m_ToggleSWLimitPositive.Click += new System.EventHandler(this.Click_SWLimitLabels);
			// 
			// m_ToggleSWLimitNegative
			// 
			this.m_ToggleSWLimitNegative.Active = false;
			this.m_ToggleSWLimitNegative.ActiveColorFirst = System.Drawing.Color.RoyalBlue;
			this.m_ToggleSWLimitNegative.ActiveColorSecond = System.Drawing.Color.DodgerBlue;
			this.m_ToggleSWLimitNegative.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_ToggleSWLimitNegative.Enabled = false;
			this.m_ToggleSWLimitNegative.Location = new System.Drawing.Point(942, 223);
			this.m_ToggleSWLimitNegative.Name = "m_ToggleSWLimitNegative";
			this.m_ToggleSWLimitNegative.NormalColorFirst = System.Drawing.Color.DarkGray;
			this.m_ToggleSWLimitNegative.NormalColorSecond = System.Drawing.Color.Silver;
			this.m_ToggleSWLimitNegative.Size = new System.Drawing.Size(114, 57);
			this.m_ToggleSWLimitNegative.TabIndex = 0;
			this.m_ToggleSWLimitNegative.Click += new System.EventHandler(this.Click_SWLimitLabels);
			// 
			// m_labelSWLimitStopModePositive
			// 
			this.m_labelSWLimitStopModePositive.BackGroundColor = System.Drawing.Color.White;
			this.m_labelSWLimitStopModePositive.BorderStroke = 2;
			this.m_labelSWLimitStopModePositive.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelSWLimitStopModePositive.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelSWLimitStopModePositive.EdgeRadius = 1;
			this.m_labelSWLimitStopModePositive.Enabled = false;
			this.m_labelSWLimitStopModePositive.Location = new System.Drawing.Point(786, 161);
			this.m_labelSWLimitStopModePositive.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelSWLimitStopModePositive.MainFontColor = System.Drawing.Color.Black;
			this.m_labelSWLimitStopModePositive.Name = "m_labelSWLimitStopModePositive";
			this.m_labelSWLimitStopModePositive.Size = new System.Drawing.Size(278, 47);
			this.m_labelSWLimitStopModePositive.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_labelSWLimitStopModePositive.SubFontColor = System.Drawing.Color.Black;
			this.m_labelSWLimitStopModePositive.SubText = "";
			this.m_labelSWLimitStopModePositive.TabIndex = 5;
			this.m_labelSWLimitStopModePositive.Text = "--";
			this.m_labelSWLimitStopModePositive.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelSWLimitStopModePositive.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelSWLimitStopModePositive.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelSWLimitStopModePositive.UnitAreaRate = 40;
			this.m_labelSWLimitStopModePositive.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelSWLimitStopModePositive.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_labelSWLimitStopModePositive.UnitPositionVertical = false;
			this.m_labelSWLimitStopModePositive.UnitText = "";
			this.m_labelSWLimitStopModePositive.UseBorder = true;
			this.m_labelSWLimitStopModePositive.UseEdgeRadius = false;
			this.m_labelSWLimitStopModePositive.UseSubFont = false;
			this.m_labelSWLimitStopModePositive.UseUnitFont = false;
			this.m_labelSWLimitStopModePositive.Click += new System.EventHandler(this.Click_SWLimitLabels);
			// 
			// m_labelSWLimitStopModeNegative
			// 
			this.m_labelSWLimitStopModeNegative.BackGroundColor = System.Drawing.Color.White;
			this.m_labelSWLimitStopModeNegative.BorderStroke = 2;
			this.m_labelSWLimitStopModeNegative.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelSWLimitStopModeNegative.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelSWLimitStopModeNegative.EdgeRadius = 1;
			this.m_labelSWLimitStopModeNegative.Enabled = false;
			this.m_labelSWLimitStopModeNegative.Location = new System.Drawing.Point(786, 335);
			this.m_labelSWLimitStopModeNegative.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelSWLimitStopModeNegative.MainFontColor = System.Drawing.Color.Black;
			this.m_labelSWLimitStopModeNegative.Name = "m_labelSWLimitStopModeNegative";
			this.m_labelSWLimitStopModeNegative.Size = new System.Drawing.Size(278, 47);
			this.m_labelSWLimitStopModeNegative.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_labelSWLimitStopModeNegative.SubFontColor = System.Drawing.Color.Black;
			this.m_labelSWLimitStopModeNegative.SubText = "";
			this.m_labelSWLimitStopModeNegative.TabIndex = 2;
			this.m_labelSWLimitStopModeNegative.Text = "--";
			this.m_labelSWLimitStopModeNegative.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelSWLimitStopModeNegative.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelSWLimitStopModeNegative.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelSWLimitStopModeNegative.UnitAreaRate = 40;
			this.m_labelSWLimitStopModeNegative.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelSWLimitStopModeNegative.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_labelSWLimitStopModeNegative.UnitPositionVertical = false;
			this.m_labelSWLimitStopModeNegative.UnitText = "";
			this.m_labelSWLimitStopModeNegative.UseBorder = true;
			this.m_labelSWLimitStopModeNegative.UseEdgeRadius = false;
			this.m_labelSWLimitStopModeNegative.UseSubFont = false;
			this.m_labelSWLimitStopModeNegative.UseUnitFont = false;
			this.m_labelSWLimitStopModeNegative.Click += new System.EventHandler(this.Click_SWLimitLabels);
			// 
			// m_labelSWLimitPositionPositive
			// 
			this.m_labelSWLimitPositionPositive.BackGroundColor = System.Drawing.Color.White;
			this.m_labelSWLimitPositionPositive.BorderStroke = 2;
			this.m_labelSWLimitPositionPositive.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelSWLimitPositionPositive.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelSWLimitPositionPositive.EdgeRadius = 1;
			this.m_labelSWLimitPositionPositive.Enabled = false;
			this.m_labelSWLimitPositionPositive.Location = new System.Drawing.Point(786, 113);
			this.m_labelSWLimitPositionPositive.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelSWLimitPositionPositive.MainFontColor = System.Drawing.Color.Black;
			this.m_labelSWLimitPositionPositive.Name = "m_labelSWLimitPositionPositive";
			this.m_labelSWLimitPositionPositive.Size = new System.Drawing.Size(278, 47);
			this.m_labelSWLimitPositionPositive.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_labelSWLimitPositionPositive.SubFontColor = System.Drawing.Color.Black;
			this.m_labelSWLimitPositionPositive.SubText = "";
			this.m_labelSWLimitPositionPositive.TabIndex = 4;
			this.m_labelSWLimitPositionPositive.Text = "--";
			this.m_labelSWLimitPositionPositive.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelSWLimitPositionPositive.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelSWLimitPositionPositive.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelSWLimitPositionPositive.UnitAreaRate = 40;
			this.m_labelSWLimitPositionPositive.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelSWLimitPositionPositive.UnitFontColor = System.Drawing.Color.Black;
			this.m_labelSWLimitPositionPositive.UnitPositionVertical = false;
			this.m_labelSWLimitPositionPositive.UnitText = "mm";
			this.m_labelSWLimitPositionPositive.UseBorder = true;
			this.m_labelSWLimitPositionPositive.UseEdgeRadius = false;
			this.m_labelSWLimitPositionPositive.UseSubFont = false;
			this.m_labelSWLimitPositionPositive.UseUnitFont = false;
			this.m_labelSWLimitPositionPositive.Click += new System.EventHandler(this.Click_SWLimitLabels);
			// 
			// m_labelSWLimitPositionNegative
			// 
			this.m_labelSWLimitPositionNegative.BackGroundColor = System.Drawing.Color.White;
			this.m_labelSWLimitPositionNegative.BorderStroke = 2;
			this.m_labelSWLimitPositionNegative.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelSWLimitPositionNegative.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelSWLimitPositionNegative.EdgeRadius = 1;
			this.m_labelSWLimitPositionNegative.Enabled = false;
			this.m_labelSWLimitPositionNegative.Location = new System.Drawing.Point(786, 286);
			this.m_labelSWLimitPositionNegative.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelSWLimitPositionNegative.MainFontColor = System.Drawing.Color.Black;
			this.m_labelSWLimitPositionNegative.Name = "m_labelSWLimitPositionNegative";
			this.m_labelSWLimitPositionNegative.Size = new System.Drawing.Size(278, 47);
			this.m_labelSWLimitPositionNegative.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_labelSWLimitPositionNegative.SubFontColor = System.Drawing.Color.Black;
			this.m_labelSWLimitPositionNegative.SubText = "";
			this.m_labelSWLimitPositionNegative.TabIndex = 1;
			this.m_labelSWLimitPositionNegative.Text = "--";
			this.m_labelSWLimitPositionNegative.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelSWLimitPositionNegative.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelSWLimitPositionNegative.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelSWLimitPositionNegative.UnitAreaRate = 40;
			this.m_labelSWLimitPositionNegative.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelSWLimitPositionNegative.UnitFontColor = System.Drawing.Color.Black;
			this.m_labelSWLimitPositionNegative.UnitPositionVertical = false;
			this.m_labelSWLimitPositionNegative.UnitText = "mm";
			this.m_labelSWLimitPositionNegative.UseBorder = true;
			this.m_labelSWLimitPositionNegative.UseEdgeRadius = false;
			this.m_labelSWLimitPositionNegative.UseSubFont = false;
			this.m_labelSWLimitPositionNegative.UseUnitFont = false;
			this.m_labelSWLimitPositionNegative.Click += new System.EventHandler(this.Click_SWLimitLabels);
			// 
			// m_labelHWLimitStopModePositive
			// 
			this.m_labelHWLimitStopModePositive.BackGroundColor = System.Drawing.Color.White;
			this.m_labelHWLimitStopModePositive.BorderStroke = 2;
			this.m_labelHWLimitStopModePositive.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelHWLimitStopModePositive.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelHWLimitStopModePositive.EdgeRadius = 1;
			this.m_labelHWLimitStopModePositive.Enabled = false;
			this.m_labelHWLimitStopModePositive.Location = new System.Drawing.Point(218, 162);
			this.m_labelHWLimitStopModePositive.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelHWLimitStopModePositive.MainFontColor = System.Drawing.Color.Black;
			this.m_labelHWLimitStopModePositive.Name = "m_labelHWLimitStopModePositive";
			this.m_labelHWLimitStopModePositive.Size = new System.Drawing.Size(278, 47);
			this.m_labelHWLimitStopModePositive.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_labelHWLimitStopModePositive.SubFontColor = System.Drawing.Color.Black;
			this.m_labelHWLimitStopModePositive.SubText = "";
			this.m_labelHWLimitStopModePositive.TabIndex = 5;
			this.m_labelHWLimitStopModePositive.Text = "--";
			this.m_labelHWLimitStopModePositive.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelHWLimitStopModePositive.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelHWLimitStopModePositive.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelHWLimitStopModePositive.UnitAreaRate = 40;
			this.m_labelHWLimitStopModePositive.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelHWLimitStopModePositive.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_labelHWLimitStopModePositive.UnitPositionVertical = false;
			this.m_labelHWLimitStopModePositive.UnitText = "";
			this.m_labelHWLimitStopModePositive.UseBorder = true;
			this.m_labelHWLimitStopModePositive.UseEdgeRadius = false;
			this.m_labelHWLimitStopModePositive.UseSubFont = false;
			this.m_labelHWLimitStopModePositive.UseUnitFont = false;
			this.m_labelHWLimitStopModePositive.Click += new System.EventHandler(this.Click_HWLimitLabels);
			// 
			// m_labelHWLimitStopModeNegative
			// 
			this.m_labelHWLimitStopModeNegative.BackGroundColor = System.Drawing.Color.White;
			this.m_labelHWLimitStopModeNegative.BorderStroke = 2;
			this.m_labelHWLimitStopModeNegative.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelHWLimitStopModeNegative.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelHWLimitStopModeNegative.EdgeRadius = 1;
			this.m_labelHWLimitStopModeNegative.Enabled = false;
			this.m_labelHWLimitStopModeNegative.Location = new System.Drawing.Point(218, 335);
			this.m_labelHWLimitStopModeNegative.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelHWLimitStopModeNegative.MainFontColor = System.Drawing.Color.Black;
			this.m_labelHWLimitStopModeNegative.Name = "m_labelHWLimitStopModeNegative";
			this.m_labelHWLimitStopModeNegative.Size = new System.Drawing.Size(278, 47);
			this.m_labelHWLimitStopModeNegative.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_labelHWLimitStopModeNegative.SubFontColor = System.Drawing.Color.Black;
			this.m_labelHWLimitStopModeNegative.SubText = "";
			this.m_labelHWLimitStopModeNegative.TabIndex = 2;
			this.m_labelHWLimitStopModeNegative.Text = "--";
			this.m_labelHWLimitStopModeNegative.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelHWLimitStopModeNegative.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelHWLimitStopModeNegative.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelHWLimitStopModeNegative.UnitAreaRate = 40;
			this.m_labelHWLimitStopModeNegative.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelHWLimitStopModeNegative.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_labelHWLimitStopModeNegative.UnitPositionVertical = false;
			this.m_labelHWLimitStopModeNegative.UnitText = "";
			this.m_labelHWLimitStopModeNegative.UseBorder = true;
			this.m_labelHWLimitStopModeNegative.UseEdgeRadius = false;
			this.m_labelHWLimitStopModeNegative.UseSubFont = false;
			this.m_labelHWLimitStopModeNegative.UseUnitFont = false;
			this.m_labelHWLimitStopModeNegative.Click += new System.EventHandler(this.Click_HWLimitLabels);
			// 
			// m_labelHWLimitLogicPositive
			// 
			this.m_labelHWLimitLogicPositive.BackGroundColor = System.Drawing.Color.White;
			this.m_labelHWLimitLogicPositive.BorderStroke = 2;
			this.m_labelHWLimitLogicPositive.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelHWLimitLogicPositive.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelHWLimitLogicPositive.EdgeRadius = 1;
			this.m_labelHWLimitLogicPositive.Enabled = false;
			this.m_labelHWLimitLogicPositive.Location = new System.Drawing.Point(218, 113);
			this.m_labelHWLimitLogicPositive.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelHWLimitLogicPositive.MainFontColor = System.Drawing.Color.Black;
			this.m_labelHWLimitLogicPositive.Name = "m_labelHWLimitLogicPositive";
			this.m_labelHWLimitLogicPositive.Size = new System.Drawing.Size(278, 47);
			this.m_labelHWLimitLogicPositive.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_labelHWLimitLogicPositive.SubFontColor = System.Drawing.Color.Black;
			this.m_labelHWLimitLogicPositive.SubText = "";
			this.m_labelHWLimitLogicPositive.TabIndex = 4;
			this.m_labelHWLimitLogicPositive.Text = "--";
			this.m_labelHWLimitLogicPositive.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelHWLimitLogicPositive.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelHWLimitLogicPositive.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelHWLimitLogicPositive.UnitAreaRate = 40;
			this.m_labelHWLimitLogicPositive.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelHWLimitLogicPositive.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_labelHWLimitLogicPositive.UnitPositionVertical = false;
			this.m_labelHWLimitLogicPositive.UnitText = "";
			this.m_labelHWLimitLogicPositive.UseBorder = true;
			this.m_labelHWLimitLogicPositive.UseEdgeRadius = false;
			this.m_labelHWLimitLogicPositive.UseSubFont = false;
			this.m_labelHWLimitLogicPositive.UseUnitFont = false;
			this.m_labelHWLimitLogicPositive.Click += new System.EventHandler(this.Click_HWLimitLabels);
			// 
			// m_labelHWLimitLogicNegative
			// 
			this.m_labelHWLimitLogicNegative.BackGroundColor = System.Drawing.Color.White;
			this.m_labelHWLimitLogicNegative.BorderStroke = 2;
			this.m_labelHWLimitLogicNegative.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelHWLimitLogicNegative.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelHWLimitLogicNegative.EdgeRadius = 1;
			this.m_labelHWLimitLogicNegative.Enabled = false;
			this.m_labelHWLimitLogicNegative.Location = new System.Drawing.Point(218, 286);
			this.m_labelHWLimitLogicNegative.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelHWLimitLogicNegative.MainFontColor = System.Drawing.Color.Black;
			this.m_labelHWLimitLogicNegative.Name = "m_labelHWLimitLogicNegative";
			this.m_labelHWLimitLogicNegative.Size = new System.Drawing.Size(278, 47);
			this.m_labelHWLimitLogicNegative.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_labelHWLimitLogicNegative.SubFontColor = System.Drawing.Color.Black;
			this.m_labelHWLimitLogicNegative.SubText = "";
			this.m_labelHWLimitLogicNegative.TabIndex = 1;
			this.m_labelHWLimitLogicNegative.Text = "--";
			this.m_labelHWLimitLogicNegative.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelHWLimitLogicNegative.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelHWLimitLogicNegative.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelHWLimitLogicNegative.UnitAreaRate = 40;
			this.m_labelHWLimitLogicNegative.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelHWLimitLogicNegative.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_labelHWLimitLogicNegative.UnitPositionVertical = false;
			this.m_labelHWLimitLogicNegative.UnitText = "";
			this.m_labelHWLimitLogicNegative.UseBorder = true;
			this.m_labelHWLimitLogicNegative.UseEdgeRadius = false;
			this.m_labelHWLimitLogicNegative.UseSubFont = false;
			this.m_labelHWLimitLogicNegative.UseUnitFont = false;
			this.m_labelHWLimitLogicNegative.Click += new System.EventHandler(this.Click_HWLimitLabels);
			// 
			// m_lblUseSWLimitPositive
			// 
			this.m_lblUseSWLimitPositive.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_lblUseSWLimitPositive.BorderStroke = 2;
			this.m_lblUseSWLimitPositive.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_lblUseSWLimitPositive.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_lblUseSWLimitPositive.EdgeRadius = 1;
			this.m_lblUseSWLimitPositive.Location = new System.Drawing.Point(610, 45);
			this.m_lblUseSWLimitPositive.MainFont = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.m_lblUseSWLimitPositive.MainFontColor = System.Drawing.Color.Black;
			this.m_lblUseSWLimitPositive.Name = "m_lblUseSWLimitPositive";
			this.m_lblUseSWLimitPositive.Size = new System.Drawing.Size(454, 66);
			this.m_lblUseSWLimitPositive.SubFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblUseSWLimitPositive.SubFontColor = System.Drawing.Color.DarkBlue;
			this.m_lblUseSWLimitPositive.SubText = "POSITIVE LIMIT";
			this.m_lblUseSWLimitPositive.TabIndex = 1417;
			this.m_lblUseSWLimitPositive.Text = "SOFTWARE LIMIT";
			this.m_lblUseSWLimitPositive.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_lblUseSWLimitPositive.TextAlignSub = Sys3Controls.EN_TEXTALIGN.BOTTOM_LEFT;
			this.m_lblUseSWLimitPositive.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblUseSWLimitPositive.UnitAreaRate = 40;
			this.m_lblUseSWLimitPositive.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_lblUseSWLimitPositive.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_lblUseSWLimitPositive.UnitPositionVertical = false;
			this.m_lblUseSWLimitPositive.UnitText = "";
			this.m_lblUseSWLimitPositive.UseBorder = true;
			this.m_lblUseSWLimitPositive.UseEdgeRadius = false;
			this.m_lblUseSWLimitPositive.UseSubFont = true;
			this.m_lblUseSWLimitPositive.UseUnitFont = false;
			// 
			// m_lblUseHWLimitPositive
			// 
			this.m_lblUseHWLimitPositive.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_lblUseHWLimitPositive.BorderStroke = 2;
			this.m_lblUseHWLimitPositive.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_lblUseHWLimitPositive.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_lblUseHWLimitPositive.EdgeRadius = 1;
			this.m_lblUseHWLimitPositive.Location = new System.Drawing.Point(42, 45);
			this.m_lblUseHWLimitPositive.MainFont = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.m_lblUseHWLimitPositive.MainFontColor = System.Drawing.Color.Black;
			this.m_lblUseHWLimitPositive.Name = "m_lblUseHWLimitPositive";
			this.m_lblUseHWLimitPositive.Size = new System.Drawing.Size(454, 66);
			this.m_lblUseHWLimitPositive.SubFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblUseHWLimitPositive.SubFontColor = System.Drawing.Color.DarkBlue;
			this.m_lblUseHWLimitPositive.SubText = "POSITIVE LIMIT";
			this.m_lblUseHWLimitPositive.TabIndex = 1416;
			this.m_lblUseHWLimitPositive.Text = "HARDWARE LIMIT";
			this.m_lblUseHWLimitPositive.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_lblUseHWLimitPositive.TextAlignSub = Sys3Controls.EN_TEXTALIGN.BOTTOM_LEFT;
			this.m_lblUseHWLimitPositive.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblUseHWLimitPositive.UnitAreaRate = 40;
			this.m_lblUseHWLimitPositive.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_lblUseHWLimitPositive.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_lblUseHWLimitPositive.UnitPositionVertical = false;
			this.m_lblUseHWLimitPositive.UnitText = "";
			this.m_lblUseHWLimitPositive.UseBorder = true;
			this.m_lblUseHWLimitPositive.UseEdgeRadius = false;
			this.m_lblUseHWLimitPositive.UseSubFont = true;
			this.m_lblUseHWLimitPositive.UseUnitFont = false;
			// 
			// m_lblSWLimitPositionPositive
			// 
			this.m_lblSWLimitPositionPositive.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_lblSWLimitPositionPositive.BorderStroke = 2;
			this.m_lblSWLimitPositionPositive.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_lblSWLimitPositionPositive.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_lblSWLimitPositionPositive.EdgeRadius = 1;
			this.m_lblSWLimitPositionPositive.Location = new System.Drawing.Point(610, 113);
			this.m_lblSWLimitPositionPositive.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblSWLimitPositionPositive.MainFontColor = System.Drawing.Color.Black;
			this.m_lblSWLimitPositionPositive.Name = "m_lblSWLimitPositionPositive";
			this.m_lblSWLimitPositionPositive.Size = new System.Drawing.Size(174, 47);
			this.m_lblSWLimitPositionPositive.SubFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblSWLimitPositionPositive.SubFontColor = System.Drawing.Color.DarkBlue;
			this.m_lblSWLimitPositionPositive.SubText = "POSITIVE POSITION";
			this.m_lblSWLimitPositionPositive.TabIndex = 1406;
			this.m_lblSWLimitPositionPositive.Text = "SOFTWARE LIMIT";
			this.m_lblSWLimitPositionPositive.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_lblSWLimitPositionPositive.TextAlignSub = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_lblSWLimitPositionPositive.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblSWLimitPositionPositive.UnitAreaRate = 40;
			this.m_lblSWLimitPositionPositive.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_lblSWLimitPositionPositive.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_lblSWLimitPositionPositive.UnitPositionVertical = false;
			this.m_lblSWLimitPositionPositive.UnitText = "";
			this.m_lblSWLimitPositionPositive.UseBorder = true;
			this.m_lblSWLimitPositionPositive.UseEdgeRadius = false;
			this.m_lblSWLimitPositionPositive.UseSubFont = true;
			this.m_lblSWLimitPositionPositive.UseUnitFont = false;
			// 
			// m_lblHWLimitLogicPositive
			// 
			this.m_lblHWLimitLogicPositive.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_lblHWLimitLogicPositive.BorderStroke = 2;
			this.m_lblHWLimitLogicPositive.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_lblHWLimitLogicPositive.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_lblHWLimitLogicPositive.EdgeRadius = 1;
			this.m_lblHWLimitLogicPositive.Location = new System.Drawing.Point(42, 113);
			this.m_lblHWLimitLogicPositive.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblHWLimitLogicPositive.MainFontColor = System.Drawing.Color.Black;
			this.m_lblHWLimitLogicPositive.Name = "m_lblHWLimitLogicPositive";
			this.m_lblHWLimitLogicPositive.Size = new System.Drawing.Size(174, 47);
			this.m_lblHWLimitLogicPositive.SubFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblHWLimitLogicPositive.SubFontColor = System.Drawing.Color.DarkBlue;
			this.m_lblHWLimitLogicPositive.SubText = "POSITIVE LOGIC";
			this.m_lblHWLimitLogicPositive.TabIndex = 1407;
			this.m_lblHWLimitLogicPositive.Text = "HARDWARE LIMIT";
			this.m_lblHWLimitLogicPositive.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_lblHWLimitLogicPositive.TextAlignSub = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_lblHWLimitLogicPositive.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblHWLimitLogicPositive.UnitAreaRate = 40;
			this.m_lblHWLimitLogicPositive.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_lblHWLimitLogicPositive.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_lblHWLimitLogicPositive.UnitPositionVertical = false;
			this.m_lblHWLimitLogicPositive.UnitText = "";
			this.m_lblHWLimitLogicPositive.UseBorder = true;
			this.m_lblHWLimitLogicPositive.UseEdgeRadius = false;
			this.m_lblHWLimitLogicPositive.UseSubFont = true;
			this.m_lblHWLimitLogicPositive.UseUnitFont = false;
			// 
			// m_lblSWLimitStopModePositive
			// 
			this.m_lblSWLimitStopModePositive.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_lblSWLimitStopModePositive.BorderStroke = 2;
			this.m_lblSWLimitStopModePositive.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_lblSWLimitStopModePositive.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_lblSWLimitStopModePositive.EdgeRadius = 1;
			this.m_lblSWLimitStopModePositive.Location = new System.Drawing.Point(610, 161);
			this.m_lblSWLimitStopModePositive.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblSWLimitStopModePositive.MainFontColor = System.Drawing.Color.Black;
			this.m_lblSWLimitStopModePositive.Name = "m_lblSWLimitStopModePositive";
			this.m_lblSWLimitStopModePositive.Size = new System.Drawing.Size(174, 47);
			this.m_lblSWLimitStopModePositive.SubFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblSWLimitStopModePositive.SubFontColor = System.Drawing.Color.DarkBlue;
			this.m_lblSWLimitStopModePositive.SubText = "STOP MODE";
			this.m_lblSWLimitStopModePositive.TabIndex = 1408;
			this.m_lblSWLimitStopModePositive.Text = "SOFTWARE LIMIT";
			this.m_lblSWLimitStopModePositive.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_lblSWLimitStopModePositive.TextAlignSub = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_lblSWLimitStopModePositive.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblSWLimitStopModePositive.UnitAreaRate = 40;
			this.m_lblSWLimitStopModePositive.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_lblSWLimitStopModePositive.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_lblSWLimitStopModePositive.UnitPositionVertical = false;
			this.m_lblSWLimitStopModePositive.UnitText = "";
			this.m_lblSWLimitStopModePositive.UseBorder = true;
			this.m_lblSWLimitStopModePositive.UseEdgeRadius = false;
			this.m_lblSWLimitStopModePositive.UseSubFont = true;
			this.m_lblSWLimitStopModePositive.UseUnitFont = false;
			// 
			// m_lblHWLimitStopModePositive
			// 
			this.m_lblHWLimitStopModePositive.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_lblHWLimitStopModePositive.BorderStroke = 2;
			this.m_lblHWLimitStopModePositive.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_lblHWLimitStopModePositive.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_lblHWLimitStopModePositive.EdgeRadius = 1;
			this.m_lblHWLimitStopModePositive.Location = new System.Drawing.Point(42, 161);
			this.m_lblHWLimitStopModePositive.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblHWLimitStopModePositive.MainFontColor = System.Drawing.Color.Black;
			this.m_lblHWLimitStopModePositive.Name = "m_lblHWLimitStopModePositive";
			this.m_lblHWLimitStopModePositive.Size = new System.Drawing.Size(174, 48);
			this.m_lblHWLimitStopModePositive.SubFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblHWLimitStopModePositive.SubFontColor = System.Drawing.Color.DarkBlue;
			this.m_lblHWLimitStopModePositive.SubText = "STOP MODE";
			this.m_lblHWLimitStopModePositive.TabIndex = 1409;
			this.m_lblHWLimitStopModePositive.Text = "HARDWARE LIMIT";
			this.m_lblHWLimitStopModePositive.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_lblHWLimitStopModePositive.TextAlignSub = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_lblHWLimitStopModePositive.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblHWLimitStopModePositive.UnitAreaRate = 40;
			this.m_lblHWLimitStopModePositive.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_lblHWLimitStopModePositive.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_lblHWLimitStopModePositive.UnitPositionVertical = false;
			this.m_lblHWLimitStopModePositive.UnitText = "";
			this.m_lblHWLimitStopModePositive.UseBorder = true;
			this.m_lblHWLimitStopModePositive.UseEdgeRadius = false;
			this.m_lblHWLimitStopModePositive.UseSubFont = true;
			this.m_lblHWLimitStopModePositive.UseUnitFont = false;
			// 
			// m_lblSWLimitStopModeNegative
			// 
			this.m_lblSWLimitStopModeNegative.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_lblSWLimitStopModeNegative.BorderStroke = 2;
			this.m_lblSWLimitStopModeNegative.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_lblSWLimitStopModeNegative.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_lblSWLimitStopModeNegative.EdgeRadius = 1;
			this.m_lblSWLimitStopModeNegative.Location = new System.Drawing.Point(610, 335);
			this.m_lblSWLimitStopModeNegative.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblSWLimitStopModeNegative.MainFontColor = System.Drawing.Color.Black;
			this.m_lblSWLimitStopModeNegative.Name = "m_lblSWLimitStopModeNegative";
			this.m_lblSWLimitStopModeNegative.Size = new System.Drawing.Size(174, 47);
			this.m_lblSWLimitStopModeNegative.SubFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblSWLimitStopModeNegative.SubFontColor = System.Drawing.Color.DarkBlue;
			this.m_lblSWLimitStopModeNegative.SubText = "STOP MODE";
			this.m_lblSWLimitStopModeNegative.TabIndex = 1410;
			this.m_lblSWLimitStopModeNegative.Text = "SOFTWARE LIMIT";
			this.m_lblSWLimitStopModeNegative.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_lblSWLimitStopModeNegative.TextAlignSub = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_lblSWLimitStopModeNegative.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblSWLimitStopModeNegative.UnitAreaRate = 40;
			this.m_lblSWLimitStopModeNegative.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_lblSWLimitStopModeNegative.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_lblSWLimitStopModeNegative.UnitPositionVertical = false;
			this.m_lblSWLimitStopModeNegative.UnitText = "";
			this.m_lblSWLimitStopModeNegative.UseBorder = true;
			this.m_lblSWLimitStopModeNegative.UseEdgeRadius = false;
			this.m_lblSWLimitStopModeNegative.UseSubFont = true;
			this.m_lblSWLimitStopModeNegative.UseUnitFont = false;
			// 
			// m_lblSWLimitPositionNegative
			// 
			this.m_lblSWLimitPositionNegative.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_lblSWLimitPositionNegative.BorderStroke = 2;
			this.m_lblSWLimitPositionNegative.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_lblSWLimitPositionNegative.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_lblSWLimitPositionNegative.EdgeRadius = 1;
			this.m_lblSWLimitPositionNegative.Location = new System.Drawing.Point(610, 286);
			this.m_lblSWLimitPositionNegative.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblSWLimitPositionNegative.MainFontColor = System.Drawing.Color.Black;
			this.m_lblSWLimitPositionNegative.Name = "m_lblSWLimitPositionNegative";
			this.m_lblSWLimitPositionNegative.Size = new System.Drawing.Size(174, 47);
			this.m_lblSWLimitPositionNegative.SubFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblSWLimitPositionNegative.SubFontColor = System.Drawing.Color.DarkBlue;
			this.m_lblSWLimitPositionNegative.SubText = "NEGATIVE POSITION";
			this.m_lblSWLimitPositionNegative.TabIndex = 1411;
			this.m_lblSWLimitPositionNegative.Text = "SOFTWARE LIMIT";
			this.m_lblSWLimitPositionNegative.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_lblSWLimitPositionNegative.TextAlignSub = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_lblSWLimitPositionNegative.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblSWLimitPositionNegative.UnitAreaRate = 40;
			this.m_lblSWLimitPositionNegative.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_lblSWLimitPositionNegative.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_lblSWLimitPositionNegative.UnitPositionVertical = false;
			this.m_lblSWLimitPositionNegative.UnitText = "";
			this.m_lblSWLimitPositionNegative.UseBorder = true;
			this.m_lblSWLimitPositionNegative.UseEdgeRadius = false;
			this.m_lblSWLimitPositionNegative.UseSubFont = true;
			this.m_lblSWLimitPositionNegative.UseUnitFont = false;
			// 
			// m_lblHWLimitStopModeNegative
			// 
			this.m_lblHWLimitStopModeNegative.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_lblHWLimitStopModeNegative.BorderStroke = 2;
			this.m_lblHWLimitStopModeNegative.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_lblHWLimitStopModeNegative.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_lblHWLimitStopModeNegative.EdgeRadius = 1;
			this.m_lblHWLimitStopModeNegative.Location = new System.Drawing.Point(42, 335);
			this.m_lblHWLimitStopModeNegative.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblHWLimitStopModeNegative.MainFontColor = System.Drawing.Color.Black;
			this.m_lblHWLimitStopModeNegative.Name = "m_lblHWLimitStopModeNegative";
			this.m_lblHWLimitStopModeNegative.Size = new System.Drawing.Size(174, 47);
			this.m_lblHWLimitStopModeNegative.SubFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblHWLimitStopModeNegative.SubFontColor = System.Drawing.Color.DarkBlue;
			this.m_lblHWLimitStopModeNegative.SubText = "STOP MODE";
			this.m_lblHWLimitStopModeNegative.TabIndex = 1412;
			this.m_lblHWLimitStopModeNegative.Text = "HARDWARE LIMIT";
			this.m_lblHWLimitStopModeNegative.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_lblHWLimitStopModeNegative.TextAlignSub = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_lblHWLimitStopModeNegative.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblHWLimitStopModeNegative.UnitAreaRate = 40;
			this.m_lblHWLimitStopModeNegative.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_lblHWLimitStopModeNegative.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_lblHWLimitStopModeNegative.UnitPositionVertical = false;
			this.m_lblHWLimitStopModeNegative.UnitText = "";
			this.m_lblHWLimitStopModeNegative.UseBorder = true;
			this.m_lblHWLimitStopModeNegative.UseEdgeRadius = false;
			this.m_lblHWLimitStopModeNegative.UseSubFont = true;
			this.m_lblHWLimitStopModeNegative.UseUnitFont = false;
			// 
			// m_lblUseSWLimitNegative
			// 
			this.m_lblUseSWLimitNegative.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_lblUseSWLimitNegative.BorderStroke = 2;
			this.m_lblUseSWLimitNegative.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_lblUseSWLimitNegative.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_lblUseSWLimitNegative.EdgeRadius = 1;
			this.m_lblUseSWLimitNegative.Location = new System.Drawing.Point(610, 218);
			this.m_lblUseSWLimitNegative.MainFont = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.m_lblUseSWLimitNegative.MainFontColor = System.Drawing.Color.Black;
			this.m_lblUseSWLimitNegative.Name = "m_lblUseSWLimitNegative";
			this.m_lblUseSWLimitNegative.Size = new System.Drawing.Size(454, 66);
			this.m_lblUseSWLimitNegative.SubFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblUseSWLimitNegative.SubFontColor = System.Drawing.Color.DarkBlue;
			this.m_lblUseSWLimitNegative.SubText = "NEGATIVE LIMIT";
			this.m_lblUseSWLimitNegative.TabIndex = 1413;
			this.m_lblUseSWLimitNegative.Text = "SOFTWARE LIMIT";
			this.m_lblUseSWLimitNegative.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_lblUseSWLimitNegative.TextAlignSub = Sys3Controls.EN_TEXTALIGN.BOTTOM_LEFT;
			this.m_lblUseSWLimitNegative.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblUseSWLimitNegative.UnitAreaRate = 40;
			this.m_lblUseSWLimitNegative.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_lblUseSWLimitNegative.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_lblUseSWLimitNegative.UnitPositionVertical = false;
			this.m_lblUseSWLimitNegative.UnitText = "";
			this.m_lblUseSWLimitNegative.UseBorder = true;
			this.m_lblUseSWLimitNegative.UseEdgeRadius = false;
			this.m_lblUseSWLimitNegative.UseSubFont = true;
			this.m_lblUseSWLimitNegative.UseUnitFont = false;
			// 
			// m_lblHWLimitLogicNegative
			// 
			this.m_lblHWLimitLogicNegative.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_lblHWLimitLogicNegative.BorderStroke = 2;
			this.m_lblHWLimitLogicNegative.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_lblHWLimitLogicNegative.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_lblHWLimitLogicNegative.EdgeRadius = 1;
			this.m_lblHWLimitLogicNegative.Location = new System.Drawing.Point(42, 286);
			this.m_lblHWLimitLogicNegative.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblHWLimitLogicNegative.MainFontColor = System.Drawing.Color.Black;
			this.m_lblHWLimitLogicNegative.Name = "m_lblHWLimitLogicNegative";
			this.m_lblHWLimitLogicNegative.Size = new System.Drawing.Size(174, 47);
			this.m_lblHWLimitLogicNegative.SubFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblHWLimitLogicNegative.SubFontColor = System.Drawing.Color.DarkBlue;
			this.m_lblHWLimitLogicNegative.SubText = "NEGATIVE LOGIC";
			this.m_lblHWLimitLogicNegative.TabIndex = 1414;
			this.m_lblHWLimitLogicNegative.Text = "HARDWARE LIMIT";
			this.m_lblHWLimitLogicNegative.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_lblHWLimitLogicNegative.TextAlignSub = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_lblHWLimitLogicNegative.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblHWLimitLogicNegative.UnitAreaRate = 40;
			this.m_lblHWLimitLogicNegative.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_lblHWLimitLogicNegative.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_lblHWLimitLogicNegative.UnitPositionVertical = false;
			this.m_lblHWLimitLogicNegative.UnitText = "";
			this.m_lblHWLimitLogicNegative.UseBorder = true;
			this.m_lblHWLimitLogicNegative.UseEdgeRadius = false;
			this.m_lblHWLimitLogicNegative.UseSubFont = true;
			this.m_lblHWLimitLogicNegative.UseUnitFont = false;
			// 
			// m_lblUseHWLimitNegative
			// 
			this.m_lblUseHWLimitNegative.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_lblUseHWLimitNegative.BorderStroke = 2;
			this.m_lblUseHWLimitNegative.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_lblUseHWLimitNegative.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_lblUseHWLimitNegative.EdgeRadius = 1;
			this.m_lblUseHWLimitNegative.Location = new System.Drawing.Point(42, 218);
			this.m_lblUseHWLimitNegative.MainFont = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.m_lblUseHWLimitNegative.MainFontColor = System.Drawing.Color.Black;
			this.m_lblUseHWLimitNegative.Name = "m_lblUseHWLimitNegative";
			this.m_lblUseHWLimitNegative.Size = new System.Drawing.Size(454, 66);
			this.m_lblUseHWLimitNegative.SubFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblUseHWLimitNegative.SubFontColor = System.Drawing.Color.DarkBlue;
			this.m_lblUseHWLimitNegative.SubText = "NEGATIVE LIMIT";
			this.m_lblUseHWLimitNegative.TabIndex = 1415;
			this.m_lblUseHWLimitNegative.Text = "HARDWARE LIMIT";
			this.m_lblUseHWLimitNegative.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_lblUseHWLimitNegative.TextAlignSub = Sys3Controls.EN_TEXTALIGN.BOTTOM_LEFT;
			this.m_lblUseHWLimitNegative.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblUseHWLimitNegative.UnitAreaRate = 40;
			this.m_lblUseHWLimitNegative.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_lblUseHWLimitNegative.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_lblUseHWLimitNegative.UnitPositionVertical = false;
			this.m_lblUseHWLimitNegative.UnitText = "";
			this.m_lblUseHWLimitNegative.UseBorder = true;
			this.m_lblUseHWLimitNegative.UseEdgeRadius = false;
			this.m_lblUseHWLimitNegative.UseSubFont = true;
			this.m_lblUseHWLimitNegative.UseUnitFont = false;
			// 
			// m_groupHWLimitConfig
			// 
			this.m_groupHWLimitConfig.BackGroundColor = System.Drawing.Color.WhiteSmoke;
			this.m_groupHWLimitConfig.EdgeBorderStroke = 2;
			this.m_groupHWLimitConfig.EdgeRadius = 2;
			this.m_groupHWLimitConfig.LabelFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_groupHWLimitConfig.LabelGradientColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
			this.m_groupHWLimitConfig.LabelGradientColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.m_groupHWLimitConfig.LabelHeight = 30;
			this.m_groupHWLimitConfig.LabelTextColor = System.Drawing.Color.Black;
			this.m_groupHWLimitConfig.Location = new System.Drawing.Point(0, 0);
			this.m_groupHWLimitConfig.Name = "m_groupHWLimitConfig";
			this.m_groupHWLimitConfig.Size = new System.Drawing.Size(560, 399);
			this.m_groupHWLimitConfig.TabIndex = 1404;
			this.m_groupHWLimitConfig.Text = "HARDWARE LIMIT CONFIG";
			this.m_groupHWLimitConfig.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_groupHWLimitConfig.UseLabelBorder = true;
			// 
			// m_groupSWLimitConfig
			// 
			this.m_groupSWLimitConfig.BackGroundColor = System.Drawing.Color.WhiteSmoke;
			this.m_groupSWLimitConfig.EdgeBorderStroke = 2;
			this.m_groupSWLimitConfig.EdgeRadius = 2;
			this.m_groupSWLimitConfig.LabelFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_groupSWLimitConfig.LabelGradientColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
			this.m_groupSWLimitConfig.LabelGradientColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.m_groupSWLimitConfig.LabelHeight = 30;
			this.m_groupSWLimitConfig.LabelTextColor = System.Drawing.Color.Black;
			this.m_groupSWLimitConfig.Location = new System.Drawing.Point(560, 0);
			this.m_groupSWLimitConfig.Name = "m_groupSWLimitConfig";
			this.m_groupSWLimitConfig.Size = new System.Drawing.Size(560, 399);
			this.m_groupSWLimitConfig.TabIndex = 1405;
			this.m_groupSWLimitConfig.Text = "SOFTWARE LIMIT CONFIG";
			this.m_groupSWLimitConfig.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_groupSWLimitConfig.UseLabelBorder = true;
			// 
			// MotorLimit
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.m_ToggleHWLimitPositive);
			this.Controls.Add(this.m_ToggleHWLimitNegative);
			this.Controls.Add(this.m_ToggleSWLimitPositive);
			this.Controls.Add(this.m_ToggleSWLimitNegative);
			this.Controls.Add(this.m_labelSWLimitStopModePositive);
			this.Controls.Add(this.m_labelSWLimitStopModeNegative);
			this.Controls.Add(this.m_labelSWLimitPositionPositive);
			this.Controls.Add(this.m_labelSWLimitPositionNegative);
			this.Controls.Add(this.m_labelHWLimitStopModePositive);
			this.Controls.Add(this.m_labelHWLimitStopModeNegative);
			this.Controls.Add(this.m_labelHWLimitLogicPositive);
			this.Controls.Add(this.m_labelHWLimitLogicNegative);
			this.Controls.Add(this.m_lblUseSWLimitPositive);
			this.Controls.Add(this.m_lblUseHWLimitPositive);
			this.Controls.Add(this.m_lblSWLimitPositionPositive);
			this.Controls.Add(this.m_lblHWLimitLogicPositive);
			this.Controls.Add(this.m_lblSWLimitStopModePositive);
			this.Controls.Add(this.m_lblHWLimitStopModePositive);
			this.Controls.Add(this.m_lblSWLimitStopModeNegative);
			this.Controls.Add(this.m_lblSWLimitPositionNegative);
			this.Controls.Add(this.m_lblHWLimitStopModeNegative);
			this.Controls.Add(this.m_lblUseSWLimitNegative);
			this.Controls.Add(this.m_lblHWLimitLogicNegative);
			this.Controls.Add(this.m_lblUseHWLimitNegative);
			this.Controls.Add(this.m_groupHWLimitConfig);
			this.Controls.Add(this.m_groupSWLimitConfig);
			this.Name = "MotorLimit";
			this.Size = new System.Drawing.Size(1120, 399);
			this.ResumeLayout(false);

		}

		#endregion

		private Sys3Controls.Sys3ToggleButton m_ToggleHWLimitPositive;
		private Sys3Controls.Sys3ToggleButton m_ToggleHWLimitNegative;
		private Sys3Controls.Sys3ToggleButton m_ToggleSWLimitPositive;
		private Sys3Controls.Sys3ToggleButton m_ToggleSWLimitNegative;
		private Sys3Controls.Sys3Label m_labelSWLimitStopModePositive;
		private Sys3Controls.Sys3Label m_labelSWLimitStopModeNegative;
		private Sys3Controls.Sys3Label m_labelSWLimitPositionPositive;
		private Sys3Controls.Sys3Label m_labelSWLimitPositionNegative;
		private Sys3Controls.Sys3Label m_labelHWLimitStopModePositive;
		private Sys3Controls.Sys3Label m_labelHWLimitStopModeNegative;
		private Sys3Controls.Sys3Label m_labelHWLimitLogicPositive;
		private Sys3Controls.Sys3Label m_labelHWLimitLogicNegative;
		private Sys3Controls.Sys3Label m_lblUseSWLimitPositive;
		private Sys3Controls.Sys3Label m_lblUseHWLimitPositive;
		private Sys3Controls.Sys3Label m_lblSWLimitPositionPositive;
		private Sys3Controls.Sys3Label m_lblHWLimitLogicPositive;
		private Sys3Controls.Sys3Label m_lblSWLimitStopModePositive;
		private Sys3Controls.Sys3Label m_lblHWLimitStopModePositive;
		private Sys3Controls.Sys3Label m_lblSWLimitStopModeNegative;
		private Sys3Controls.Sys3Label m_lblSWLimitPositionNegative;
		private Sys3Controls.Sys3Label m_lblHWLimitStopModeNegative;
		private Sys3Controls.Sys3Label m_lblUseSWLimitNegative;
		private Sys3Controls.Sys3Label m_lblHWLimitLogicNegative;
		private Sys3Controls.Sys3Label m_lblUseHWLimitNegative;
		private Sys3Controls.Sys3GroupBox m_groupHWLimitConfig;
		private Sys3Controls.Sys3GroupBox m_groupSWLimitConfig;
	}
}
