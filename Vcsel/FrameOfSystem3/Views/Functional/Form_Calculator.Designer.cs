﻿namespace FrameOfSystem3.Views.Functional
{
    partial class Form_Calculator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.m_groupbox = new Sys3Controls.Sys3GroupBox();
			this.m_labelOld = new Sys3Controls.Sys3Label();
			this.m_labelMin = new Sys3Controls.Sys3Label();
			this.m_labelMax = new Sys3Controls.Sys3Label();
			this.m_labelUnit = new Sys3Controls.Sys3Label();
			this.m_btnClear = new Sys3Controls.Sys3button();
			this.sys3button1 = new Sys3Controls.Sys3button();
			this.m_btnApply = new Sys3Controls.Sys3button();
			this.m_btnCancel = new Sys3Controls.Sys3button();
			this.sys3button2 = new Sys3Controls.Sys3button();
			this.sys3button3 = new Sys3Controls.Sys3button();
			this.sys3button4 = new Sys3Controls.Sys3button();
			this.sys3button5 = new Sys3Controls.Sys3button();
			this.sys3button6 = new Sys3Controls.Sys3button();
			this.sys3button7 = new Sys3Controls.Sys3button();
			this.sys3button8 = new Sys3Controls.Sys3button();
			this.sys3button9 = new Sys3Controls.Sys3button();
			this.sys3button10 = new Sys3Controls.Sys3button();
			this.sys3button11 = new Sys3Controls.Sys3button();
			this.sys3button12 = new Sys3Controls.Sys3button();
			this.sys3button13 = new Sys3Controls.Sys3button();
			this.sys3button14 = new Sys3Controls.Sys3button();
			this.sys3button15 = new Sys3Controls.Sys3button();
			this.sys3button16 = new Sys3Controls.Sys3button();
			this.sys3button17 = new Sys3Controls.Sys3button();
			this.sys3button18 = new Sys3Controls.Sys3button();
			this.m_labelDisplay = new Sys3Controls.Sys3Label();
			this.m_TitleBar = new Sys3Controls.Sys3GroupBox();
			this.SuspendLayout();
			// 
			// m_groupbox
			// 
			this.m_groupbox.BackGroundColor = System.Drawing.Color.WhiteSmoke;
			this.m_groupbox.EdgeBorderStroke = 2;
			this.m_groupbox.EdgeRadius = 2;
			this.m_groupbox.LabelFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_groupbox.LabelGradientColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
			this.m_groupbox.LabelGradientColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.m_groupbox.LabelHeight = 40;
			this.m_groupbox.LabelTextColor = System.Drawing.Color.Black;
			this.m_groupbox.Location = new System.Drawing.Point(0, 0);
			this.m_groupbox.Name = "m_groupbox";
			this.m_groupbox.Size = new System.Drawing.Size(431, 498);
			this.m_groupbox.TabIndex = 1371;
			this.m_groupbox.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_groupbox.ThemeIndex = 0;
			this.m_groupbox.UseLabelBorder = true;
			// 
			// m_labelOld
			// 
			this.m_labelOld.BackGroundColor = System.Drawing.Color.White;
			this.m_labelOld.BorderStroke = 2;
			this.m_labelOld.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelOld.Description = "";
			this.m_labelOld.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_labelOld.EdgeRadius = 1;
			this.m_labelOld.ImagePosition = new System.Drawing.Point(0, 0);
			this.m_labelOld.ImageSize = new System.Drawing.Point(0, 0);
			this.m_labelOld.LoadImage = null;
			this.m_labelOld.Location = new System.Drawing.Point(12, 146);
			this.m_labelOld.MainFont = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
			this.m_labelOld.MainFontColor = System.Drawing.Color.Black;
			this.m_labelOld.Name = "m_labelOld";
			this.m_labelOld.Size = new System.Drawing.Size(137, 55);
			this.m_labelOld.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelOld.SubFontColor = System.Drawing.Color.Black;
			this.m_labelOld.SubText = "PREVIOUS";
			this.m_labelOld.TabIndex = 1372;
			this.m_labelOld.Text = "0";
			this.m_labelOld.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelOld.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_labelOld.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelOld.ThemeIndex = 0;
			this.m_labelOld.UnitAreaRate = 35;
			this.m_labelOld.UnitFont = new System.Drawing.Font("맑은 고딕", 9.5F, System.Drawing.FontStyle.Bold);
			this.m_labelOld.UnitFontColor = System.Drawing.Color.Black;
			this.m_labelOld.UnitPositionVertical = false;
			this.m_labelOld.UnitText = "mm/s";
			this.m_labelOld.UseBorder = true;
			this.m_labelOld.UseEdgeRadius = false;
			this.m_labelOld.UseImage = false;
			this.m_labelOld.UseSubFont = true;
			this.m_labelOld.UseUnitFont = true;
			this.m_labelOld.DoubleClick += new System.EventHandler(this.Click_Previous);
			// 
			// m_labelMin
			// 
			this.m_labelMin.BackGroundColor = System.Drawing.Color.Silver;
			this.m_labelMin.BorderStroke = 2;
			this.m_labelMin.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelMin.Description = "";
			this.m_labelMin.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_labelMin.EdgeRadius = 1;
			this.m_labelMin.ImagePosition = new System.Drawing.Point(0, 0);
			this.m_labelMin.ImageSize = new System.Drawing.Point(0, 0);
			this.m_labelMin.LoadImage = null;
			this.m_labelMin.Location = new System.Drawing.Point(12, 207);
			this.m_labelMin.MainFont = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
			this.m_labelMin.MainFontColor = System.Drawing.Color.Black;
			this.m_labelMin.Name = "m_labelMin";
			this.m_labelMin.Size = new System.Drawing.Size(137, 55);
			this.m_labelMin.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelMin.SubFontColor = System.Drawing.Color.Blue;
			this.m_labelMin.SubText = "MIN";
			this.m_labelMin.TabIndex = 0;
			this.m_labelMin.Text = "0";
			this.m_labelMin.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelMin.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_labelMin.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelMin.ThemeIndex = 0;
			this.m_labelMin.UnitAreaRate = 35;
			this.m_labelMin.UnitFont = new System.Drawing.Font("맑은 고딕", 9.5F, System.Drawing.FontStyle.Bold);
			this.m_labelMin.UnitFontColor = System.Drawing.Color.Black;
			this.m_labelMin.UnitPositionVertical = false;
			this.m_labelMin.UnitText = "mm/s";
			this.m_labelMin.UseBorder = true;
			this.m_labelMin.UseEdgeRadius = false;
			this.m_labelMin.UseImage = false;
			this.m_labelMin.UseSubFont = true;
			this.m_labelMin.UseUnitFont = true;
			this.m_labelMin.DoubleClick += new System.EventHandler(this.Click_MinMaxLabel);
			// 
			// m_labelMax
			// 
			this.m_labelMax.BackGroundColor = System.Drawing.Color.Silver;
			this.m_labelMax.BorderStroke = 2;
			this.m_labelMax.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelMax.Description = "";
			this.m_labelMax.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_labelMax.EdgeRadius = 1;
			this.m_labelMax.ImagePosition = new System.Drawing.Point(0, 0);
			this.m_labelMax.ImageSize = new System.Drawing.Point(0, 0);
			this.m_labelMax.LoadImage = null;
			this.m_labelMax.Location = new System.Drawing.Point(12, 268);
			this.m_labelMax.MainFont = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
			this.m_labelMax.MainFontColor = System.Drawing.Color.Black;
			this.m_labelMax.Name = "m_labelMax";
			this.m_labelMax.Size = new System.Drawing.Size(137, 55);
			this.m_labelMax.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelMax.SubFontColor = System.Drawing.Color.Red;
			this.m_labelMax.SubText = "MAX";
			this.m_labelMax.TabIndex = 1;
			this.m_labelMax.Text = "0";
			this.m_labelMax.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelMax.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_labelMax.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelMax.ThemeIndex = 0;
			this.m_labelMax.UnitAreaRate = 35;
			this.m_labelMax.UnitFont = new System.Drawing.Font("맑은 고딕", 9.5F, System.Drawing.FontStyle.Bold);
			this.m_labelMax.UnitFontColor = System.Drawing.Color.Black;
			this.m_labelMax.UnitPositionVertical = false;
			this.m_labelMax.UnitText = "mm/s";
			this.m_labelMax.UseBorder = true;
			this.m_labelMax.UseEdgeRadius = false;
			this.m_labelMax.UseImage = false;
			this.m_labelMax.UseSubFont = true;
			this.m_labelMax.UseUnitFont = true;
			this.m_labelMax.DoubleClick += new System.EventHandler(this.Click_MinMaxLabel);
			// 
			// m_labelUnit
			// 
			this.m_labelUnit.BackGroundColor = System.Drawing.Color.Silver;
			this.m_labelUnit.BorderStroke = 2;
			this.m_labelUnit.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelUnit.Description = "";
			this.m_labelUnit.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_labelUnit.EdgeRadius = 1;
			this.m_labelUnit.ImagePosition = new System.Drawing.Point(0, 0);
			this.m_labelUnit.ImageSize = new System.Drawing.Point(0, 0);
			this.m_labelUnit.LoadImage = null;
			this.m_labelUnit.Location = new System.Drawing.Point(12, 329);
			this.m_labelUnit.MainFont = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
			this.m_labelUnit.MainFontColor = System.Drawing.Color.Black;
			this.m_labelUnit.Name = "m_labelUnit";
			this.m_labelUnit.Size = new System.Drawing.Size(137, 55);
			this.m_labelUnit.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelUnit.SubFontColor = System.Drawing.Color.DarkCyan;
			this.m_labelUnit.SubText = "UNIT";
			this.m_labelUnit.TabIndex = 2;
			this.m_labelUnit.Text = "mm";
			this.m_labelUnit.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_CENTER;
			this.m_labelUnit.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_labelUnit.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelUnit.ThemeIndex = 0;
			this.m_labelUnit.UnitAreaRate = 35;
			this.m_labelUnit.UnitFont = new System.Drawing.Font("맑은 고딕", 9.5F, System.Drawing.FontStyle.Bold);
			this.m_labelUnit.UnitFontColor = System.Drawing.Color.Black;
			this.m_labelUnit.UnitPositionVertical = false;
			this.m_labelUnit.UnitText = "mm/s";
			this.m_labelUnit.UseBorder = true;
			this.m_labelUnit.UseEdgeRadius = false;
			this.m_labelUnit.UseImage = false;
			this.m_labelUnit.UseSubFont = true;
			this.m_labelUnit.UseUnitFont = false;
			this.m_labelUnit.DoubleClick += new System.EventHandler(this.Click_UnitLabel);
			// 
			// m_btnClear
			// 
			this.m_btnClear.BorderWidth = 2;
			this.m_btnClear.ButtonClicked = false;
			this.m_btnClear.ClickedEmphasizeTextColor = System.Drawing.Color.White;
			this.m_btnClear.CustomClickedGradientFirstColor = System.Drawing.Color.White;
			this.m_btnClear.CustomClickedGradientSecondColor = System.Drawing.Color.White;
			this.m_btnClear.Description = "";
			this.m_btnClear.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_btnClear.EdgeRadius = 5;
			this.m_btnClear.GradientAngle = 70F;
			this.m_btnClear.GradientFirstColor = System.Drawing.Color.White;
			this.m_btnClear.GradientSecondColor = System.Drawing.Color.LightSlateGray;
			this.m_btnClear.HoverEmphasizeCustomColor = System.Drawing.Color.White;
			this.m_btnClear.ImagePosition = new System.Drawing.Point(7, 7);
			this.m_btnClear.ImageSize = new System.Drawing.Point(30, 30);
			this.m_btnClear.LoadImage = global::FrameOfSystem3.Properties.Resources.CONFIG_ADD3;
			this.m_btnClear.Location = new System.Drawing.Point(152, 146);
			this.m_btnClear.MainFont = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
			this.m_btnClear.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
			this.m_btnClear.Name = "m_btnClear";
			this.m_btnClear.Size = new System.Drawing.Size(98, 55);
			this.m_btnClear.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
			this.m_btnClear.SubFontColor = System.Drawing.Color.DarkBlue;
			this.m_btnClear.SubText = "STATUS";
			this.m_btnClear.TabIndex = 0;
			this.m_btnClear.Text = "CLEAR";
			this.m_btnClear.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_btnClear.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_btnClear.ThemeIndex = 0;
			this.m_btnClear.UseBorder = true;
			this.m_btnClear.UseClickedEmphasizeTextColor = false;
			this.m_btnClear.UseCustomizeClickedColor = false;
			this.m_btnClear.UseEdge = true;
			this.m_btnClear.UseHoverEmphasizeCustomColor = false;
			this.m_btnClear.UseImage = false;
			this.m_btnClear.UserHoverEmpahsize = false;
			this.m_btnClear.UseSubFont = false;
			this.m_btnClear.Click += new System.EventHandler(this.Click_ClearOrBackSpace);
			// 
			// sys3button1
			// 
			this.sys3button1.BorderWidth = 2;
			this.sys3button1.ButtonClicked = false;
			this.sys3button1.ClickedEmphasizeTextColor = System.Drawing.Color.White;
			this.sys3button1.CustomClickedGradientFirstColor = System.Drawing.Color.White;
			this.sys3button1.CustomClickedGradientSecondColor = System.Drawing.Color.White;
			this.sys3button1.Description = "";
			this.sys3button1.DisabledColor = System.Drawing.Color.DarkGray;
			this.sys3button1.EdgeRadius = 5;
			this.sys3button1.GradientAngle = 70F;
			this.sys3button1.GradientFirstColor = System.Drawing.Color.White;
			this.sys3button1.GradientSecondColor = System.Drawing.Color.LightSlateGray;
			this.sys3button1.HoverEmphasizeCustomColor = System.Drawing.Color.White;
			this.sys3button1.ImagePosition = new System.Drawing.Point(7, 7);
			this.sys3button1.ImageSize = new System.Drawing.Point(30, 30);
			this.sys3button1.LoadImage = global::FrameOfSystem3.Properties.Resources.CONFIG_ADD3;
			this.sys3button1.Location = new System.Drawing.Point(253, 146);
			this.sys3button1.MainFont = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
			this.sys3button1.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
			this.sys3button1.Name = "sys3button1";
			this.sys3button1.Size = new System.Drawing.Size(98, 55);
			this.sys3button1.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
			this.sys3button1.SubFontColor = System.Drawing.Color.DarkBlue;
			this.sys3button1.SubText = "STATUS";
			this.sys3button1.TabIndex = 1;
			this.sys3button1.Text = "<ㅡ";
			this.sys3button1.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.sys3button1.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.sys3button1.ThemeIndex = 0;
			this.sys3button1.UseBorder = true;
			this.sys3button1.UseClickedEmphasizeTextColor = false;
			this.sys3button1.UseCustomizeClickedColor = false;
			this.sys3button1.UseEdge = true;
			this.sys3button1.UseHoverEmphasizeCustomColor = false;
			this.sys3button1.UseImage = false;
			this.sys3button1.UserHoverEmpahsize = false;
			this.sys3button1.UseSubFont = false;
			this.sys3button1.Click += new System.EventHandler(this.Click_ClearOrBackSpace);
			// 
			// m_btnApply
			// 
			this.m_btnApply.BorderWidth = 2;
			this.m_btnApply.ButtonClicked = false;
			this.m_btnApply.ClickedEmphasizeTextColor = System.Drawing.Color.White;
			this.m_btnApply.CustomClickedGradientFirstColor = System.Drawing.Color.White;
			this.m_btnApply.CustomClickedGradientSecondColor = System.Drawing.Color.White;
			this.m_btnApply.Description = "";
			this.m_btnApply.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_btnApply.EdgeRadius = 5;
			this.m_btnApply.GradientAngle = 70F;
			this.m_btnApply.GradientFirstColor = System.Drawing.Color.White;
			this.m_btnApply.GradientSecondColor = System.Drawing.Color.LightSlateGray;
			this.m_btnApply.HoverEmphasizeCustomColor = System.Drawing.Color.White;
			this.m_btnApply.ImagePosition = new System.Drawing.Point(7, 7);
			this.m_btnApply.ImageSize = new System.Drawing.Point(30, 30);
			this.m_btnApply.LoadImage = global::FrameOfSystem3.Properties.Resources.CONFIG_ADD3;
			this.m_btnApply.Location = new System.Drawing.Point(152, 432);
			this.m_btnApply.MainFont = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
			this.m_btnApply.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
			this.m_btnApply.Name = "m_btnApply";
			this.m_btnApply.Size = new System.Drawing.Size(131, 55);
			this.m_btnApply.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
			this.m_btnApply.SubFontColor = System.Drawing.Color.DarkBlue;
			this.m_btnApply.SubText = "STATUS";
			this.m_btnApply.TabIndex = 0;
			this.m_btnApply.Text = "APPLY";
			this.m_btnApply.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_btnApply.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_btnApply.ThemeIndex = 0;
			this.m_btnApply.UseBorder = true;
			this.m_btnApply.UseClickedEmphasizeTextColor = false;
			this.m_btnApply.UseCustomizeClickedColor = false;
			this.m_btnApply.UseEdge = true;
			this.m_btnApply.UseHoverEmphasizeCustomColor = false;
			this.m_btnApply.UseImage = false;
			this.m_btnApply.UserHoverEmpahsize = false;
			this.m_btnApply.UseSubFont = false;
			this.m_btnApply.Click += new System.EventHandler(this.Click_ApplyOrCancel);
			// 
			// m_btnCancel
			// 
			this.m_btnCancel.BorderWidth = 2;
			this.m_btnCancel.ButtonClicked = false;
			this.m_btnCancel.ClickedEmphasizeTextColor = System.Drawing.Color.White;
			this.m_btnCancel.CustomClickedGradientFirstColor = System.Drawing.Color.White;
			this.m_btnCancel.CustomClickedGradientSecondColor = System.Drawing.Color.White;
			this.m_btnCancel.Description = "";
			this.m_btnCancel.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_btnCancel.EdgeRadius = 5;
			this.m_btnCancel.GradientAngle = 70F;
			this.m_btnCancel.GradientFirstColor = System.Drawing.Color.White;
			this.m_btnCancel.GradientSecondColor = System.Drawing.Color.LightSlateGray;
			this.m_btnCancel.HoverEmphasizeCustomColor = System.Drawing.Color.White;
			this.m_btnCancel.ImagePosition = new System.Drawing.Point(7, 7);
			this.m_btnCancel.ImageSize = new System.Drawing.Point(30, 30);
			this.m_btnCancel.LoadImage = global::FrameOfSystem3.Properties.Resources.CONFIG_ADD3;
			this.m_btnCancel.Location = new System.Drawing.Point(286, 432);
			this.m_btnCancel.MainFont = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
			this.m_btnCancel.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
			this.m_btnCancel.Name = "m_btnCancel";
			this.m_btnCancel.Size = new System.Drawing.Size(131, 55);
			this.m_btnCancel.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
			this.m_btnCancel.SubFontColor = System.Drawing.Color.DarkBlue;
			this.m_btnCancel.SubText = "STATUS";
			this.m_btnCancel.TabIndex = 1;
			this.m_btnCancel.Text = "CANCEL";
			this.m_btnCancel.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_btnCancel.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_btnCancel.ThemeIndex = 0;
			this.m_btnCancel.UseBorder = true;
			this.m_btnCancel.UseClickedEmphasizeTextColor = false;
			this.m_btnCancel.UseCustomizeClickedColor = false;
			this.m_btnCancel.UseEdge = true;
			this.m_btnCancel.UseHoverEmphasizeCustomColor = false;
			this.m_btnCancel.UseImage = false;
			this.m_btnCancel.UserHoverEmpahsize = false;
			this.m_btnCancel.UseSubFont = false;
			this.m_btnCancel.Click += new System.EventHandler(this.Click_ApplyOrCancel);
			// 
			// sys3button2
			// 
			this.sys3button2.BorderWidth = 2;
			this.sys3button2.ButtonClicked = false;
			this.sys3button2.ClickedEmphasizeTextColor = System.Drawing.Color.White;
			this.sys3button2.CustomClickedGradientFirstColor = System.Drawing.Color.White;
			this.sys3button2.CustomClickedGradientSecondColor = System.Drawing.Color.White;
			this.sys3button2.Description = "";
			this.sys3button2.DisabledColor = System.Drawing.Color.DarkGray;
			this.sys3button2.EdgeRadius = 5;
			this.sys3button2.GradientAngle = 70F;
			this.sys3button2.GradientFirstColor = System.Drawing.Color.White;
			this.sys3button2.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
			this.sys3button2.HoverEmphasizeCustomColor = System.Drawing.Color.White;
			this.sys3button2.ImagePosition = new System.Drawing.Point(7, 7);
			this.sys3button2.ImageSize = new System.Drawing.Point(30, 30);
			this.sys3button2.LoadImage = global::FrameOfSystem3.Properties.Resources.CONFIG_ADD3;
			this.sys3button2.Location = new System.Drawing.Point(152, 203);
			this.sys3button2.MainFont = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
			this.sys3button2.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
			this.sys3button2.Name = "sys3button2";
			this.sys3button2.Size = new System.Drawing.Size(65, 55);
			this.sys3button2.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
			this.sys3button2.SubFontColor = System.Drawing.Color.DarkBlue;
			this.sys3button2.SubText = "STATUS";
			this.sys3button2.TabIndex = 7;
			this.sys3button2.Text = "7";
			this.sys3button2.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.sys3button2.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.sys3button2.ThemeIndex = 0;
			this.sys3button2.UseBorder = true;
			this.sys3button2.UseClickedEmphasizeTextColor = false;
			this.sys3button2.UseCustomizeClickedColor = false;
			this.sys3button2.UseEdge = true;
			this.sys3button2.UseHoverEmphasizeCustomColor = false;
			this.sys3button2.UseImage = false;
			this.sys3button2.UserHoverEmpahsize = false;
			this.sys3button2.UseSubFont = false;
			this.sys3button2.Click += new System.EventHandler(this.Click_Number);
			this.sys3button2.DoubleClick += new System.EventHandler(this.DoubleClick_Number);
			// 
			// sys3button3
			// 
			this.sys3button3.BorderWidth = 2;
			this.sys3button3.ButtonClicked = false;
			this.sys3button3.ClickedEmphasizeTextColor = System.Drawing.Color.White;
			this.sys3button3.CustomClickedGradientFirstColor = System.Drawing.Color.White;
			this.sys3button3.CustomClickedGradientSecondColor = System.Drawing.Color.White;
			this.sys3button3.Description = "";
			this.sys3button3.DisabledColor = System.Drawing.Color.DarkGray;
			this.sys3button3.EdgeRadius = 5;
			this.sys3button3.GradientAngle = 70F;
			this.sys3button3.GradientFirstColor = System.Drawing.Color.White;
			this.sys3button3.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
			this.sys3button3.HoverEmphasizeCustomColor = System.Drawing.Color.White;
			this.sys3button3.ImagePosition = new System.Drawing.Point(7, 7);
			this.sys3button3.ImageSize = new System.Drawing.Point(30, 30);
			this.sys3button3.LoadImage = global::FrameOfSystem3.Properties.Resources.CONFIG_ADD3;
			this.sys3button3.Location = new System.Drawing.Point(219, 203);
			this.sys3button3.MainFont = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
			this.sys3button3.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
			this.sys3button3.Name = "sys3button3";
			this.sys3button3.Size = new System.Drawing.Size(65, 55);
			this.sys3button3.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
			this.sys3button3.SubFontColor = System.Drawing.Color.DarkBlue;
			this.sys3button3.SubText = "STATUS";
			this.sys3button3.TabIndex = 8;
			this.sys3button3.Text = "8";
			this.sys3button3.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.sys3button3.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.sys3button3.ThemeIndex = 0;
			this.sys3button3.UseBorder = true;
			this.sys3button3.UseClickedEmphasizeTextColor = false;
			this.sys3button3.UseCustomizeClickedColor = false;
			this.sys3button3.UseEdge = true;
			this.sys3button3.UseHoverEmphasizeCustomColor = false;
			this.sys3button3.UseImage = false;
			this.sys3button3.UserHoverEmpahsize = false;
			this.sys3button3.UseSubFont = false;
			this.sys3button3.Click += new System.EventHandler(this.Click_Number);
			this.sys3button3.DoubleClick += new System.EventHandler(this.DoubleClick_Number);
			// 
			// sys3button4
			// 
			this.sys3button4.BorderWidth = 2;
			this.sys3button4.ButtonClicked = false;
			this.sys3button4.ClickedEmphasizeTextColor = System.Drawing.Color.White;
			this.sys3button4.CustomClickedGradientFirstColor = System.Drawing.Color.White;
			this.sys3button4.CustomClickedGradientSecondColor = System.Drawing.Color.White;
			this.sys3button4.Description = "";
			this.sys3button4.DisabledColor = System.Drawing.Color.DarkGray;
			this.sys3button4.EdgeRadius = 5;
			this.sys3button4.GradientAngle = 70F;
			this.sys3button4.GradientFirstColor = System.Drawing.Color.White;
			this.sys3button4.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
			this.sys3button4.HoverEmphasizeCustomColor = System.Drawing.Color.White;
			this.sys3button4.ImagePosition = new System.Drawing.Point(7, 7);
			this.sys3button4.ImageSize = new System.Drawing.Point(30, 30);
			this.sys3button4.LoadImage = global::FrameOfSystem3.Properties.Resources.CONFIG_ADD3;
			this.sys3button4.Location = new System.Drawing.Point(286, 203);
			this.sys3button4.MainFont = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
			this.sys3button4.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
			this.sys3button4.Name = "sys3button4";
			this.sys3button4.Size = new System.Drawing.Size(65, 55);
			this.sys3button4.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
			this.sys3button4.SubFontColor = System.Drawing.Color.DarkBlue;
			this.sys3button4.SubText = "STATUS";
			this.sys3button4.TabIndex = 9;
			this.sys3button4.Text = "9";
			this.sys3button4.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.sys3button4.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.sys3button4.ThemeIndex = 0;
			this.sys3button4.UseBorder = true;
			this.sys3button4.UseClickedEmphasizeTextColor = false;
			this.sys3button4.UseCustomizeClickedColor = false;
			this.sys3button4.UseEdge = true;
			this.sys3button4.UseHoverEmphasizeCustomColor = false;
			this.sys3button4.UseImage = false;
			this.sys3button4.UserHoverEmpahsize = false;
			this.sys3button4.UseSubFont = false;
			this.sys3button4.Click += new System.EventHandler(this.Click_Number);
			this.sys3button4.DoubleClick += new System.EventHandler(this.DoubleClick_Number);
			// 
			// sys3button5
			// 
			this.sys3button5.BorderWidth = 2;
			this.sys3button5.ButtonClicked = false;
			this.sys3button5.ClickedEmphasizeTextColor = System.Drawing.Color.White;
			this.sys3button5.CustomClickedGradientFirstColor = System.Drawing.Color.White;
			this.sys3button5.CustomClickedGradientSecondColor = System.Drawing.Color.White;
			this.sys3button5.Description = "";
			this.sys3button5.DisabledColor = System.Drawing.Color.DarkGray;
			this.sys3button5.EdgeRadius = 5;
			this.sys3button5.GradientAngle = 70F;
			this.sys3button5.GradientFirstColor = System.Drawing.Color.White;
			this.sys3button5.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
			this.sys3button5.HoverEmphasizeCustomColor = System.Drawing.Color.White;
			this.sys3button5.ImagePosition = new System.Drawing.Point(7, 7);
			this.sys3button5.ImageSize = new System.Drawing.Point(30, 30);
			this.sys3button5.LoadImage = global::FrameOfSystem3.Properties.Resources.CONFIG_ADD3;
			this.sys3button5.Location = new System.Drawing.Point(352, 203);
			this.sys3button5.MainFont = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
			this.sys3button5.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
			this.sys3button5.Name = "sys3button5";
			this.sys3button5.Size = new System.Drawing.Size(65, 55);
			this.sys3button5.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
			this.sys3button5.SubFontColor = System.Drawing.Color.DarkBlue;
			this.sys3button5.SubText = "STATUS";
			this.sys3button5.TabIndex = 2;
			this.sys3button5.Text = "×";
			this.sys3button5.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.sys3button5.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.sys3button5.ThemeIndex = 0;
			this.sys3button5.UseBorder = true;
			this.sys3button5.UseClickedEmphasizeTextColor = false;
			this.sys3button5.UseCustomizeClickedColor = false;
			this.sys3button5.UseEdge = true;
			this.sys3button5.UseHoverEmphasizeCustomColor = false;
			this.sys3button5.UseImage = false;
			this.sys3button5.UserHoverEmpahsize = false;
			this.sys3button5.UseSubFont = false;
			this.sys3button5.Click += new System.EventHandler(this.Click_Operator);
			// 
			// sys3button6
			// 
			this.sys3button6.BorderWidth = 2;
			this.sys3button6.ButtonClicked = false;
			this.sys3button6.ClickedEmphasizeTextColor = System.Drawing.Color.White;
			this.sys3button6.CustomClickedGradientFirstColor = System.Drawing.Color.White;
			this.sys3button6.CustomClickedGradientSecondColor = System.Drawing.Color.White;
			this.sys3button6.Description = "";
			this.sys3button6.DisabledColor = System.Drawing.Color.DarkGray;
			this.sys3button6.EdgeRadius = 5;
			this.sys3button6.GradientAngle = 70F;
			this.sys3button6.GradientFirstColor = System.Drawing.Color.White;
			this.sys3button6.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
			this.sys3button6.HoverEmphasizeCustomColor = System.Drawing.Color.White;
			this.sys3button6.ImagePosition = new System.Drawing.Point(7, 7);
			this.sys3button6.ImageSize = new System.Drawing.Point(30, 30);
			this.sys3button6.LoadImage = global::FrameOfSystem3.Properties.Resources.CONFIG_ADD3;
			this.sys3button6.Location = new System.Drawing.Point(352, 260);
			this.sys3button6.MainFont = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
			this.sys3button6.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
			this.sys3button6.Name = "sys3button6";
			this.sys3button6.Size = new System.Drawing.Size(65, 55);
			this.sys3button6.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
			this.sys3button6.SubFontColor = System.Drawing.Color.DarkBlue;
			this.sys3button6.SubText = "STATUS";
			this.sys3button6.TabIndex = 1;
			this.sys3button6.Text = "-";
			this.sys3button6.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.sys3button6.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.sys3button6.ThemeIndex = 0;
			this.sys3button6.UseBorder = true;
			this.sys3button6.UseClickedEmphasizeTextColor = false;
			this.sys3button6.UseCustomizeClickedColor = false;
			this.sys3button6.UseEdge = true;
			this.sys3button6.UseHoverEmphasizeCustomColor = false;
			this.sys3button6.UseImage = false;
			this.sys3button6.UserHoverEmpahsize = false;
			this.sys3button6.UseSubFont = false;
			this.sys3button6.Click += new System.EventHandler(this.Click_Operator);
			// 
			// sys3button7
			// 
			this.sys3button7.BorderWidth = 2;
			this.sys3button7.ButtonClicked = false;
			this.sys3button7.ClickedEmphasizeTextColor = System.Drawing.Color.White;
			this.sys3button7.CustomClickedGradientFirstColor = System.Drawing.Color.White;
			this.sys3button7.CustomClickedGradientSecondColor = System.Drawing.Color.White;
			this.sys3button7.Description = "";
			this.sys3button7.DisabledColor = System.Drawing.Color.DarkGray;
			this.sys3button7.EdgeRadius = 5;
			this.sys3button7.GradientAngle = 70F;
			this.sys3button7.GradientFirstColor = System.Drawing.Color.White;
			this.sys3button7.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
			this.sys3button7.HoverEmphasizeCustomColor = System.Drawing.Color.White;
			this.sys3button7.ImagePosition = new System.Drawing.Point(7, 7);
			this.sys3button7.ImageSize = new System.Drawing.Point(30, 30);
			this.sys3button7.LoadImage = global::FrameOfSystem3.Properties.Resources.CONFIG_ADD3;
			this.sys3button7.Location = new System.Drawing.Point(286, 260);
			this.sys3button7.MainFont = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
			this.sys3button7.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
			this.sys3button7.Name = "sys3button7";
			this.sys3button7.Size = new System.Drawing.Size(65, 55);
			this.sys3button7.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
			this.sys3button7.SubFontColor = System.Drawing.Color.DarkBlue;
			this.sys3button7.SubText = "STATUS";
			this.sys3button7.TabIndex = 6;
			this.sys3button7.Text = "6";
			this.sys3button7.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.sys3button7.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.sys3button7.ThemeIndex = 0;
			this.sys3button7.UseBorder = true;
			this.sys3button7.UseClickedEmphasizeTextColor = false;
			this.sys3button7.UseCustomizeClickedColor = false;
			this.sys3button7.UseEdge = true;
			this.sys3button7.UseHoverEmphasizeCustomColor = false;
			this.sys3button7.UseImage = false;
			this.sys3button7.UserHoverEmpahsize = false;
			this.sys3button7.UseSubFont = false;
			this.sys3button7.Click += new System.EventHandler(this.Click_Number);
			this.sys3button7.DoubleClick += new System.EventHandler(this.DoubleClick_Number);
			// 
			// sys3button8
			// 
			this.sys3button8.BorderWidth = 2;
			this.sys3button8.ButtonClicked = false;
			this.sys3button8.ClickedEmphasizeTextColor = System.Drawing.Color.White;
			this.sys3button8.CustomClickedGradientFirstColor = System.Drawing.Color.White;
			this.sys3button8.CustomClickedGradientSecondColor = System.Drawing.Color.White;
			this.sys3button8.Description = "";
			this.sys3button8.DisabledColor = System.Drawing.Color.DarkGray;
			this.sys3button8.EdgeRadius = 5;
			this.sys3button8.GradientAngle = 70F;
			this.sys3button8.GradientFirstColor = System.Drawing.Color.White;
			this.sys3button8.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
			this.sys3button8.HoverEmphasizeCustomColor = System.Drawing.Color.White;
			this.sys3button8.ImagePosition = new System.Drawing.Point(7, 7);
			this.sys3button8.ImageSize = new System.Drawing.Point(30, 30);
			this.sys3button8.LoadImage = global::FrameOfSystem3.Properties.Resources.CONFIG_ADD3;
			this.sys3button8.Location = new System.Drawing.Point(219, 260);
			this.sys3button8.MainFont = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
			this.sys3button8.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
			this.sys3button8.Name = "sys3button8";
			this.sys3button8.Size = new System.Drawing.Size(65, 55);
			this.sys3button8.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
			this.sys3button8.SubFontColor = System.Drawing.Color.DarkBlue;
			this.sys3button8.SubText = "STATUS";
			this.sys3button8.TabIndex = 5;
			this.sys3button8.Text = "5";
			this.sys3button8.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.sys3button8.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.sys3button8.ThemeIndex = 0;
			this.sys3button8.UseBorder = true;
			this.sys3button8.UseClickedEmphasizeTextColor = false;
			this.sys3button8.UseCustomizeClickedColor = false;
			this.sys3button8.UseEdge = true;
			this.sys3button8.UseHoverEmphasizeCustomColor = false;
			this.sys3button8.UseImage = false;
			this.sys3button8.UserHoverEmpahsize = false;
			this.sys3button8.UseSubFont = false;
			this.sys3button8.Click += new System.EventHandler(this.Click_Number);
			this.sys3button8.DoubleClick += new System.EventHandler(this.DoubleClick_Number);
			// 
			// sys3button9
			// 
			this.sys3button9.BorderWidth = 2;
			this.sys3button9.ButtonClicked = false;
			this.sys3button9.ClickedEmphasizeTextColor = System.Drawing.Color.White;
			this.sys3button9.CustomClickedGradientFirstColor = System.Drawing.Color.White;
			this.sys3button9.CustomClickedGradientSecondColor = System.Drawing.Color.White;
			this.sys3button9.Description = "";
			this.sys3button9.DisabledColor = System.Drawing.Color.DarkGray;
			this.sys3button9.EdgeRadius = 5;
			this.sys3button9.GradientAngle = 70F;
			this.sys3button9.GradientFirstColor = System.Drawing.Color.White;
			this.sys3button9.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
			this.sys3button9.HoverEmphasizeCustomColor = System.Drawing.Color.White;
			this.sys3button9.ImagePosition = new System.Drawing.Point(7, 7);
			this.sys3button9.ImageSize = new System.Drawing.Point(30, 30);
			this.sys3button9.LoadImage = global::FrameOfSystem3.Properties.Resources.CONFIG_ADD3;
			this.sys3button9.Location = new System.Drawing.Point(152, 260);
			this.sys3button9.MainFont = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
			this.sys3button9.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
			this.sys3button9.Name = "sys3button9";
			this.sys3button9.Size = new System.Drawing.Size(65, 55);
			this.sys3button9.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
			this.sys3button9.SubFontColor = System.Drawing.Color.DarkBlue;
			this.sys3button9.SubText = "STATUS";
			this.sys3button9.TabIndex = 4;
			this.sys3button9.Text = "4";
			this.sys3button9.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.sys3button9.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.sys3button9.ThemeIndex = 0;
			this.sys3button9.UseBorder = true;
			this.sys3button9.UseClickedEmphasizeTextColor = false;
			this.sys3button9.UseCustomizeClickedColor = false;
			this.sys3button9.UseEdge = true;
			this.sys3button9.UseHoverEmphasizeCustomColor = false;
			this.sys3button9.UseImage = false;
			this.sys3button9.UserHoverEmpahsize = false;
			this.sys3button9.UseSubFont = false;
			this.sys3button9.Click += new System.EventHandler(this.Click_Number);
			this.sys3button9.DoubleClick += new System.EventHandler(this.DoubleClick_Number);
			// 
			// sys3button10
			// 
			this.sys3button10.BorderWidth = 2;
			this.sys3button10.ButtonClicked = false;
			this.sys3button10.ClickedEmphasizeTextColor = System.Drawing.Color.White;
			this.sys3button10.CustomClickedGradientFirstColor = System.Drawing.Color.White;
			this.sys3button10.CustomClickedGradientSecondColor = System.Drawing.Color.White;
			this.sys3button10.Description = "";
			this.sys3button10.DisabledColor = System.Drawing.Color.DarkGray;
			this.sys3button10.EdgeRadius = 5;
			this.sys3button10.GradientAngle = 70F;
			this.sys3button10.GradientFirstColor = System.Drawing.Color.White;
			this.sys3button10.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
			this.sys3button10.HoverEmphasizeCustomColor = System.Drawing.Color.White;
			this.sys3button10.ImagePosition = new System.Drawing.Point(7, 7);
			this.sys3button10.ImageSize = new System.Drawing.Point(30, 30);
			this.sys3button10.LoadImage = global::FrameOfSystem3.Properties.Resources.CONFIG_ADD3;
			this.sys3button10.Location = new System.Drawing.Point(353, 146);
			this.sys3button10.MainFont = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
			this.sys3button10.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
			this.sys3button10.Name = "sys3button10";
			this.sys3button10.Size = new System.Drawing.Size(65, 55);
			this.sys3button10.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
			this.sys3button10.SubFontColor = System.Drawing.Color.DarkBlue;
			this.sys3button10.SubText = "STATUS";
			this.sys3button10.TabIndex = 3;
			this.sys3button10.Text = "÷";
			this.sys3button10.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.sys3button10.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.sys3button10.ThemeIndex = 0;
			this.sys3button10.UseBorder = true;
			this.sys3button10.UseClickedEmphasizeTextColor = false;
			this.sys3button10.UseCustomizeClickedColor = false;
			this.sys3button10.UseEdge = true;
			this.sys3button10.UseHoverEmphasizeCustomColor = false;
			this.sys3button10.UseImage = false;
			this.sys3button10.UserHoverEmpahsize = false;
			this.sys3button10.UseSubFont = false;
			this.sys3button10.Click += new System.EventHandler(this.Click_Operator);
			// 
			// sys3button11
			// 
			this.sys3button11.BorderWidth = 2;
			this.sys3button11.ButtonClicked = false;
			this.sys3button11.ClickedEmphasizeTextColor = System.Drawing.Color.White;
			this.sys3button11.CustomClickedGradientFirstColor = System.Drawing.Color.White;
			this.sys3button11.CustomClickedGradientSecondColor = System.Drawing.Color.White;
			this.sys3button11.Description = "";
			this.sys3button11.DisabledColor = System.Drawing.Color.DarkGray;
			this.sys3button11.EdgeRadius = 5;
			this.sys3button11.GradientAngle = 70F;
			this.sys3button11.GradientFirstColor = System.Drawing.Color.White;
			this.sys3button11.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
			this.sys3button11.HoverEmphasizeCustomColor = System.Drawing.Color.White;
			this.sys3button11.ImagePosition = new System.Drawing.Point(7, 7);
			this.sys3button11.ImageSize = new System.Drawing.Point(30, 30);
			this.sys3button11.LoadImage = global::FrameOfSystem3.Properties.Resources.CONFIG_ADD3;
			this.sys3button11.Location = new System.Drawing.Point(152, 317);
			this.sys3button11.MainFont = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
			this.sys3button11.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
			this.sys3button11.Name = "sys3button11";
			this.sys3button11.Size = new System.Drawing.Size(65, 55);
			this.sys3button11.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
			this.sys3button11.SubFontColor = System.Drawing.Color.DarkBlue;
			this.sys3button11.SubText = "STATUS";
			this.sys3button11.TabIndex = 1;
			this.sys3button11.Text = "1";
			this.sys3button11.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.sys3button11.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.sys3button11.ThemeIndex = 0;
			this.sys3button11.UseBorder = true;
			this.sys3button11.UseClickedEmphasizeTextColor = false;
			this.sys3button11.UseCustomizeClickedColor = false;
			this.sys3button11.UseEdge = true;
			this.sys3button11.UseHoverEmphasizeCustomColor = false;
			this.sys3button11.UseImage = false;
			this.sys3button11.UserHoverEmpahsize = false;
			this.sys3button11.UseSubFont = false;
			this.sys3button11.Click += new System.EventHandler(this.Click_Number);
			this.sys3button11.DoubleClick += new System.EventHandler(this.DoubleClick_Number);
			// 
			// sys3button12
			// 
			this.sys3button12.BorderWidth = 2;
			this.sys3button12.ButtonClicked = false;
			this.sys3button12.ClickedEmphasizeTextColor = System.Drawing.Color.White;
			this.sys3button12.CustomClickedGradientFirstColor = System.Drawing.Color.White;
			this.sys3button12.CustomClickedGradientSecondColor = System.Drawing.Color.White;
			this.sys3button12.Description = "";
			this.sys3button12.DisabledColor = System.Drawing.Color.DarkGray;
			this.sys3button12.EdgeRadius = 5;
			this.sys3button12.GradientAngle = 70F;
			this.sys3button12.GradientFirstColor = System.Drawing.Color.White;
			this.sys3button12.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
			this.sys3button12.HoverEmphasizeCustomColor = System.Drawing.Color.White;
			this.sys3button12.ImagePosition = new System.Drawing.Point(7, 7);
			this.sys3button12.ImageSize = new System.Drawing.Point(30, 30);
			this.sys3button12.LoadImage = global::FrameOfSystem3.Properties.Resources.CONFIG_ADD3;
			this.sys3button12.Location = new System.Drawing.Point(219, 317);
			this.sys3button12.MainFont = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
			this.sys3button12.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
			this.sys3button12.Name = "sys3button12";
			this.sys3button12.Size = new System.Drawing.Size(65, 55);
			this.sys3button12.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
			this.sys3button12.SubFontColor = System.Drawing.Color.DarkBlue;
			this.sys3button12.SubText = "STATUS";
			this.sys3button12.TabIndex = 2;
			this.sys3button12.Text = "2";
			this.sys3button12.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.sys3button12.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.sys3button12.ThemeIndex = 0;
			this.sys3button12.UseBorder = true;
			this.sys3button12.UseClickedEmphasizeTextColor = false;
			this.sys3button12.UseCustomizeClickedColor = false;
			this.sys3button12.UseEdge = true;
			this.sys3button12.UseHoverEmphasizeCustomColor = false;
			this.sys3button12.UseImage = false;
			this.sys3button12.UserHoverEmpahsize = false;
			this.sys3button12.UseSubFont = false;
			this.sys3button12.Click += new System.EventHandler(this.Click_Number);
			this.sys3button12.DoubleClick += new System.EventHandler(this.DoubleClick_Number);
			// 
			// sys3button13
			// 
			this.sys3button13.BorderWidth = 2;
			this.sys3button13.ButtonClicked = false;
			this.sys3button13.ClickedEmphasizeTextColor = System.Drawing.Color.White;
			this.sys3button13.CustomClickedGradientFirstColor = System.Drawing.Color.White;
			this.sys3button13.CustomClickedGradientSecondColor = System.Drawing.Color.White;
			this.sys3button13.Description = "";
			this.sys3button13.DisabledColor = System.Drawing.Color.DarkGray;
			this.sys3button13.EdgeRadius = 5;
			this.sys3button13.GradientAngle = 70F;
			this.sys3button13.GradientFirstColor = System.Drawing.Color.White;
			this.sys3button13.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
			this.sys3button13.HoverEmphasizeCustomColor = System.Drawing.Color.White;
			this.sys3button13.ImagePosition = new System.Drawing.Point(7, 7);
			this.sys3button13.ImageSize = new System.Drawing.Point(30, 30);
			this.sys3button13.LoadImage = global::FrameOfSystem3.Properties.Resources.CONFIG_ADD3;
			this.sys3button13.Location = new System.Drawing.Point(286, 317);
			this.sys3button13.MainFont = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
			this.sys3button13.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
			this.sys3button13.Name = "sys3button13";
			this.sys3button13.Size = new System.Drawing.Size(65, 55);
			this.sys3button13.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
			this.sys3button13.SubFontColor = System.Drawing.Color.DarkBlue;
			this.sys3button13.SubText = "STATUS";
			this.sys3button13.TabIndex = 3;
			this.sys3button13.Text = "3";
			this.sys3button13.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.sys3button13.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.sys3button13.ThemeIndex = 0;
			this.sys3button13.UseBorder = true;
			this.sys3button13.UseClickedEmphasizeTextColor = false;
			this.sys3button13.UseCustomizeClickedColor = false;
			this.sys3button13.UseEdge = true;
			this.sys3button13.UseHoverEmphasizeCustomColor = false;
			this.sys3button13.UseImage = false;
			this.sys3button13.UserHoverEmpahsize = false;
			this.sys3button13.UseSubFont = false;
			this.sys3button13.Click += new System.EventHandler(this.Click_Number);
			this.sys3button13.DoubleClick += new System.EventHandler(this.DoubleClick_Number);
			// 
			// sys3button14
			// 
			this.sys3button14.BorderWidth = 2;
			this.sys3button14.ButtonClicked = false;
			this.sys3button14.ClickedEmphasizeTextColor = System.Drawing.Color.White;
			this.sys3button14.CustomClickedGradientFirstColor = System.Drawing.Color.White;
			this.sys3button14.CustomClickedGradientSecondColor = System.Drawing.Color.White;
			this.sys3button14.Description = "";
			this.sys3button14.DisabledColor = System.Drawing.Color.DarkGray;
			this.sys3button14.EdgeRadius = 5;
			this.sys3button14.GradientAngle = 70F;
			this.sys3button14.GradientFirstColor = System.Drawing.Color.White;
			this.sys3button14.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
			this.sys3button14.HoverEmphasizeCustomColor = System.Drawing.Color.White;
			this.sys3button14.ImagePosition = new System.Drawing.Point(7, 7);
			this.sys3button14.ImageSize = new System.Drawing.Point(30, 30);
			this.sys3button14.LoadImage = global::FrameOfSystem3.Properties.Resources.CONFIG_ADD3;
			this.sys3button14.Location = new System.Drawing.Point(352, 317);
			this.sys3button14.MainFont = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
			this.sys3button14.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
			this.sys3button14.Name = "sys3button14";
			this.sys3button14.Size = new System.Drawing.Size(65, 55);
			this.sys3button14.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
			this.sys3button14.SubFontColor = System.Drawing.Color.DarkBlue;
			this.sys3button14.SubText = "STATUS";
			this.sys3button14.TabIndex = 0;
			this.sys3button14.Text = "+";
			this.sys3button14.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.sys3button14.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.sys3button14.ThemeIndex = 0;
			this.sys3button14.UseBorder = true;
			this.sys3button14.UseClickedEmphasizeTextColor = false;
			this.sys3button14.UseCustomizeClickedColor = false;
			this.sys3button14.UseEdge = true;
			this.sys3button14.UseHoverEmphasizeCustomColor = false;
			this.sys3button14.UseImage = false;
			this.sys3button14.UserHoverEmpahsize = false;
			this.sys3button14.UseSubFont = false;
			this.sys3button14.Click += new System.EventHandler(this.Click_Operator);
			// 
			// sys3button15
			// 
			this.sys3button15.BorderWidth = 2;
			this.sys3button15.ButtonClicked = false;
			this.sys3button15.ClickedEmphasizeTextColor = System.Drawing.Color.White;
			this.sys3button15.CustomClickedGradientFirstColor = System.Drawing.Color.White;
			this.sys3button15.CustomClickedGradientSecondColor = System.Drawing.Color.White;
			this.sys3button15.Description = "";
			this.sys3button15.DisabledColor = System.Drawing.Color.DarkGray;
			this.sys3button15.EdgeRadius = 5;
			this.sys3button15.GradientAngle = 70F;
			this.sys3button15.GradientFirstColor = System.Drawing.Color.White;
			this.sys3button15.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
			this.sys3button15.HoverEmphasizeCustomColor = System.Drawing.Color.White;
			this.sys3button15.ImagePosition = new System.Drawing.Point(7, 7);
			this.sys3button15.ImageSize = new System.Drawing.Point(30, 30);
			this.sys3button15.LoadImage = global::FrameOfSystem3.Properties.Resources.CONFIG_ADD3;
			this.sys3button15.Location = new System.Drawing.Point(219, 374);
			this.sys3button15.MainFont = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
			this.sys3button15.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
			this.sys3button15.Name = "sys3button15";
			this.sys3button15.Size = new System.Drawing.Size(65, 55);
			this.sys3button15.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
			this.sys3button15.SubFontColor = System.Drawing.Color.DarkBlue;
			this.sys3button15.SubText = "STATUS";
			this.sys3button15.TabIndex = 0;
			this.sys3button15.Text = "0";
			this.sys3button15.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.sys3button15.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.sys3button15.ThemeIndex = 0;
			this.sys3button15.UseBorder = true;
			this.sys3button15.UseClickedEmphasizeTextColor = false;
			this.sys3button15.UseCustomizeClickedColor = false;
			this.sys3button15.UseEdge = true;
			this.sys3button15.UseHoverEmphasizeCustomColor = false;
			this.sys3button15.UseImage = false;
			this.sys3button15.UserHoverEmpahsize = false;
			this.sys3button15.UseSubFont = false;
			this.sys3button15.Click += new System.EventHandler(this.Click_Number);
			this.sys3button15.DoubleClick += new System.EventHandler(this.DoubleClick_Number);
			// 
			// sys3button16
			// 
			this.sys3button16.BorderWidth = 2;
			this.sys3button16.ButtonClicked = false;
			this.sys3button16.ClickedEmphasizeTextColor = System.Drawing.Color.White;
			this.sys3button16.CustomClickedGradientFirstColor = System.Drawing.Color.White;
			this.sys3button16.CustomClickedGradientSecondColor = System.Drawing.Color.White;
			this.sys3button16.Description = "";
			this.sys3button16.DisabledColor = System.Drawing.Color.DarkGray;
			this.sys3button16.EdgeRadius = 5;
			this.sys3button16.GradientAngle = 70F;
			this.sys3button16.GradientFirstColor = System.Drawing.Color.White;
			this.sys3button16.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
			this.sys3button16.HoverEmphasizeCustomColor = System.Drawing.Color.White;
			this.sys3button16.ImagePosition = new System.Drawing.Point(7, 7);
			this.sys3button16.ImageSize = new System.Drawing.Point(30, 30);
			this.sys3button16.LoadImage = global::FrameOfSystem3.Properties.Resources.CONFIG_ADD3;
			this.sys3button16.Location = new System.Drawing.Point(152, 374);
			this.sys3button16.MainFont = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
			this.sys3button16.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
			this.sys3button16.Name = "sys3button16";
			this.sys3button16.Size = new System.Drawing.Size(65, 55);
			this.sys3button16.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
			this.sys3button16.SubFontColor = System.Drawing.Color.DarkBlue;
			this.sys3button16.SubText = "STATUS";
			this.sys3button16.TabIndex = 1;
			this.sys3button16.Text = "±";
			this.sys3button16.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.sys3button16.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.sys3button16.ThemeIndex = 0;
			this.sys3button16.UseBorder = true;
			this.sys3button16.UseClickedEmphasizeTextColor = false;
			this.sys3button16.UseCustomizeClickedColor = false;
			this.sys3button16.UseEdge = true;
			this.sys3button16.UseHoverEmphasizeCustomColor = false;
			this.sys3button16.UseImage = false;
			this.sys3button16.UserHoverEmpahsize = false;
			this.sys3button16.UseSubFont = false;
			this.sys3button16.Click += new System.EventHandler(this.Click_Functional);
			// 
			// sys3button17
			// 
			this.sys3button17.BorderWidth = 2;
			this.sys3button17.ButtonClicked = false;
			this.sys3button17.ClickedEmphasizeTextColor = System.Drawing.Color.White;
			this.sys3button17.CustomClickedGradientFirstColor = System.Drawing.Color.White;
			this.sys3button17.CustomClickedGradientSecondColor = System.Drawing.Color.White;
			this.sys3button17.Description = "";
			this.sys3button17.DisabledColor = System.Drawing.Color.DarkGray;
			this.sys3button17.EdgeRadius = 5;
			this.sys3button17.GradientAngle = 70F;
			this.sys3button17.GradientFirstColor = System.Drawing.Color.White;
			this.sys3button17.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
			this.sys3button17.HoverEmphasizeCustomColor = System.Drawing.Color.White;
			this.sys3button17.ImagePosition = new System.Drawing.Point(7, 7);
			this.sys3button17.ImageSize = new System.Drawing.Point(30, 30);
			this.sys3button17.LoadImage = global::FrameOfSystem3.Properties.Resources.CONFIG_ADD3;
			this.sys3button17.Location = new System.Drawing.Point(286, 374);
			this.sys3button17.MainFont = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
			this.sys3button17.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
			this.sys3button17.Name = "sys3button17";
			this.sys3button17.Size = new System.Drawing.Size(65, 55);
			this.sys3button17.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
			this.sys3button17.SubFontColor = System.Drawing.Color.DarkBlue;
			this.sys3button17.SubText = "STATUS";
			this.sys3button17.TabIndex = 0;
			this.sys3button17.Text = ".";
			this.sys3button17.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.sys3button17.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.sys3button17.ThemeIndex = 0;
			this.sys3button17.UseBorder = true;
			this.sys3button17.UseClickedEmphasizeTextColor = false;
			this.sys3button17.UseCustomizeClickedColor = false;
			this.sys3button17.UseEdge = true;
			this.sys3button17.UseHoverEmphasizeCustomColor = false;
			this.sys3button17.UseImage = false;
			this.sys3button17.UserHoverEmpahsize = false;
			this.sys3button17.UseSubFont = false;
			this.sys3button17.Click += new System.EventHandler(this.Click_Functional);
			// 
			// sys3button18
			// 
			this.sys3button18.BorderWidth = 2;
			this.sys3button18.ButtonClicked = false;
			this.sys3button18.ClickedEmphasizeTextColor = System.Drawing.Color.White;
			this.sys3button18.CustomClickedGradientFirstColor = System.Drawing.Color.White;
			this.sys3button18.CustomClickedGradientSecondColor = System.Drawing.Color.White;
			this.sys3button18.Description = "";
			this.sys3button18.DisabledColor = System.Drawing.Color.DarkGray;
			this.sys3button18.EdgeRadius = 5;
			this.sys3button18.GradientAngle = 70F;
			this.sys3button18.GradientFirstColor = System.Drawing.Color.White;
			this.sys3button18.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
			this.sys3button18.HoverEmphasizeCustomColor = System.Drawing.Color.White;
			this.sys3button18.ImagePosition = new System.Drawing.Point(7, 7);
			this.sys3button18.ImageSize = new System.Drawing.Point(30, 30);
			this.sys3button18.LoadImage = global::FrameOfSystem3.Properties.Resources.CONFIG_ADD3;
			this.sys3button18.Location = new System.Drawing.Point(352, 374);
			this.sys3button18.MainFont = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
			this.sys3button18.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
			this.sys3button18.Name = "sys3button18";
			this.sys3button18.Size = new System.Drawing.Size(65, 55);
			this.sys3button18.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
			this.sys3button18.SubFontColor = System.Drawing.Color.DarkBlue;
			this.sys3button18.SubText = "STATUS";
			this.sys3button18.TabIndex = 1373;
			this.sys3button18.Text = "=";
			this.sys3button18.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.sys3button18.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.sys3button18.ThemeIndex = 0;
			this.sys3button18.UseBorder = true;
			this.sys3button18.UseClickedEmphasizeTextColor = false;
			this.sys3button18.UseCustomizeClickedColor = false;
			this.sys3button18.UseEdge = true;
			this.sys3button18.UseHoverEmphasizeCustomColor = false;
			this.sys3button18.UseImage = false;
			this.sys3button18.UserHoverEmpahsize = false;
			this.sys3button18.UseSubFont = false;
			this.sys3button18.Click += new System.EventHandler(this.Click_Calculation);
			// 
			// m_labelDisplay
			// 
			this.m_labelDisplay.BackGroundColor = System.Drawing.Color.White;
			this.m_labelDisplay.BorderStroke = 2;
			this.m_labelDisplay.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelDisplay.Description = "";
			this.m_labelDisplay.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_labelDisplay.EdgeRadius = 1;
			this.m_labelDisplay.ImagePosition = new System.Drawing.Point(0, 0);
			this.m_labelDisplay.ImageSize = new System.Drawing.Point(0, 0);
			this.m_labelDisplay.LoadImage = null;
			this.m_labelDisplay.Location = new System.Drawing.Point(12, 58);
			this.m_labelDisplay.MainFont = new System.Drawing.Font("맑은 고딕", 30F, System.Drawing.FontStyle.Bold);
			this.m_labelDisplay.MainFontColor = System.Drawing.Color.Black;
			this.m_labelDisplay.Name = "m_labelDisplay";
			this.m_labelDisplay.Size = new System.Drawing.Size(405, 80);
			this.m_labelDisplay.SubFont = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
			this.m_labelDisplay.SubFontColor = System.Drawing.Color.Black;
			this.m_labelDisplay.SubText = "0";
			this.m_labelDisplay.TabIndex = 1;
			this.m_labelDisplay.Text = "0";
			this.m_labelDisplay.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelDisplay.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_RIGHT;
			this.m_labelDisplay.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelDisplay.ThemeIndex = 0;
			this.m_labelDisplay.UnitAreaRate = 35;
			this.m_labelDisplay.UnitFont = new System.Drawing.Font("맑은 고딕", 9.5F, System.Drawing.FontStyle.Bold);
			this.m_labelDisplay.UnitFontColor = System.Drawing.Color.Black;
			this.m_labelDisplay.UnitPositionVertical = false;
			this.m_labelDisplay.UnitText = "mm/s";
			this.m_labelDisplay.UseBorder = true;
			this.m_labelDisplay.UseEdgeRadius = false;
			this.m_labelDisplay.UseImage = false;
			this.m_labelDisplay.UseSubFont = true;
			this.m_labelDisplay.UseUnitFont = false;
			// 
			// m_TitleBar
			// 
			this.m_TitleBar.BackGroundColor = System.Drawing.Color.WhiteSmoke;
			this.m_TitleBar.EdgeBorderStroke = 2;
			this.m_TitleBar.EdgeRadius = 2;
			this.m_TitleBar.LabelFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_TitleBar.LabelGradientColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
			this.m_TitleBar.LabelGradientColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.m_TitleBar.LabelHeight = 40;
			this.m_TitleBar.LabelTextColor = System.Drawing.Color.Black;
			this.m_TitleBar.Location = new System.Drawing.Point(1, 0);
			this.m_TitleBar.Name = "m_TitleBar";
			this.m_TitleBar.Size = new System.Drawing.Size(430, 42);
			this.m_TitleBar.TabIndex = 1374;
			this.m_TitleBar.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_TitleBar.ThemeIndex = 0;
			this.m_TitleBar.UseLabelBorder = true;
			this.m_TitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown_Title);
			this.m_TitleBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove_Title);
			this.m_TitleBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUp_Title);
			// 
			// Form_Calculator
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.Gray;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.ClientSize = new System.Drawing.Size(432, 499);
			this.ControlBox = false;
			this.Controls.Add(this.m_TitleBar);
			this.Controls.Add(this.m_labelDisplay);
			this.Controls.Add(this.sys3button16);
			this.Controls.Add(this.sys3button18);
			this.Controls.Add(this.sys3button17);
			this.Controls.Add(this.sys3button15);
			this.Controls.Add(this.sys3button14);
			this.Controls.Add(this.sys3button13);
			this.Controls.Add(this.sys3button12);
			this.Controls.Add(this.sys3button11);
			this.Controls.Add(this.sys3button9);
			this.Controls.Add(this.sys3button8);
			this.Controls.Add(this.sys3button7);
			this.Controls.Add(this.sys3button6);
			this.Controls.Add(this.sys3button10);
			this.Controls.Add(this.sys3button5);
			this.Controls.Add(this.sys3button4);
			this.Controls.Add(this.sys3button3);
			this.Controls.Add(this.sys3button2);
			this.Controls.Add(this.m_btnCancel);
			this.Controls.Add(this.m_btnApply);
			this.Controls.Add(this.sys3button1);
			this.Controls.Add(this.m_btnClear);
			this.Controls.Add(this.m_labelUnit);
			this.Controls.Add(this.m_labelMax);
			this.Controls.Add(this.m_labelMin);
			this.Controls.Add(this.m_labelOld);
			this.Controls.Add(this.m_groupbox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form_Calculator";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "From_EditNumber";
			this.TopMost = true;
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_EditNumber_KeyDown);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form_EditNumber_KeyUp);
			this.ResumeLayout(false);

        }

        #endregion

		private Sys3Controls.Sys3GroupBox m_groupbox;
		private Sys3Controls.Sys3Label m_labelOld;
		private Sys3Controls.Sys3Label m_labelMin;
		private Sys3Controls.Sys3Label m_labelMax;
		private Sys3Controls.Sys3Label m_labelUnit;
		private Sys3Controls.Sys3button m_btnClear;
		private Sys3Controls.Sys3button sys3button1;
		private Sys3Controls.Sys3button m_btnApply;
		private Sys3Controls.Sys3button m_btnCancel;
		private Sys3Controls.Sys3button sys3button2;
		private Sys3Controls.Sys3button sys3button3;
		private Sys3Controls.Sys3button sys3button4;
		private Sys3Controls.Sys3button sys3button5;
		private Sys3Controls.Sys3button sys3button6;
		private Sys3Controls.Sys3button sys3button7;
		private Sys3Controls.Sys3button sys3button8;
		private Sys3Controls.Sys3button sys3button9;
		private Sys3Controls.Sys3button sys3button10;
		private Sys3Controls.Sys3button sys3button11;
		private Sys3Controls.Sys3button sys3button12;
		private Sys3Controls.Sys3button sys3button13;
		private Sys3Controls.Sys3button sys3button14;
		private Sys3Controls.Sys3button sys3button15;
		private Sys3Controls.Sys3button sys3button16;
		private Sys3Controls.Sys3button sys3button17;
		private Sys3Controls.Sys3button sys3button18;
		private Sys3Controls.Sys3Label m_labelDisplay;
		private Sys3Controls.Sys3GroupBox m_TitleBar;
    }
}
