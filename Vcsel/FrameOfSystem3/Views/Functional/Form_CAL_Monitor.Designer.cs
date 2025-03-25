﻿namespace FrameOfSystem3.Views.Functional
{
    partial class Form_CAL_Monitor
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
            this.components = new System.ComponentModel.Container();
            this.sys3GroupBox8 = new Sys3Controls.Sys3GroupBox();
            this.m_ZedGraph = new ZedGraph.ZedGraphControl();
            this.sys3Label48 = new Sys3Controls.Sys3Label();
            this.m_lblCalVolt = new Sys3Controls.Sys3Label();
            this.m_lblCalStep = new Sys3Controls.Sys3Label();
            this.m_lblCalChannel = new Sys3Controls.Sys3Label();
            this.m_lblRestTime = new Sys3Controls.Sys3Label();
            this.m_lblRepeatAvg = new Sys3Controls.Sys3Label();
            this.m_lblRepeatCount = new Sys3Controls.Sys3Label();
            this.m_lblinputVolt = new Sys3Controls.Sys3Label();
            this.m_lblAvgValue = new Sys3Controls.Sys3Label();
            this.m_lblMaxValue = new Sys3Controls.Sys3Label();
            this.sys3Label12 = new Sys3Controls.Sys3Label();
            this.m_lblLastValue = new Sys3Controls.Sys3Label();
            this.sys3Label7 = new Sys3Controls.Sys3Label();
            this.m_lblMinValue = new Sys3Controls.Sys3Label();
            this.sys3Label11 = new Sys3Controls.Sys3Label();
            this.sys3Label6 = new Sys3Controls.Sys3Label();
            this.sys3Label5 = new Sys3Controls.Sys3Label();
            this.sys3Label8 = new Sys3Controls.Sys3Label();
            this.sys3Label9 = new Sys3Controls.Sys3Label();
            this.sys3Label10 = new Sys3Controls.Sys3Label();
            this.sys3Label4 = new Sys3Controls.Sys3Label();
            this.sys3Label1 = new Sys3Controls.Sys3Label();
            this.sys3Label16 = new Sys3Controls.Sys3Label();
            this.sys3Label50 = new Sys3Controls.Sys3Label();
            this.sys3button7 = new Sys3Controls.Sys3button();
            this.SuspendLayout();
            // 
            // sys3GroupBox8
            // 
            this.sys3GroupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sys3GroupBox8.BackGroundColor = System.Drawing.Color.WhiteSmoke;
            this.sys3GroupBox8.EdgeBorderStroke = 2;
            this.sys3GroupBox8.EdgeRadius = 2;
            this.sys3GroupBox8.LabelFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3GroupBox8.LabelGradientColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.sys3GroupBox8.LabelGradientColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.sys3GroupBox8.LabelHeight = 30;
            this.sys3GroupBox8.LabelTextColor = System.Drawing.Color.Black;
            this.sys3GroupBox8.Location = new System.Drawing.Point(0, 2);
            this.sys3GroupBox8.Name = "sys3GroupBox8";
            this.sys3GroupBox8.Size = new System.Drawing.Size(1184, 304);
            this.sys3GroupBox8.TabIndex = 20877;
            this.sys3GroupBox8.Text = "LASER CAL MONITOR";
            this.sys3GroupBox8.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3GroupBox8.ThemeIndex = 0;
            this.sys3GroupBox8.UseLabelBorder = true;
            // 
            // m_ZedGraph
            // 
            this.m_ZedGraph.Location = new System.Drawing.Point(6, 35);
            this.m_ZedGraph.Name = "m_ZedGraph";
            this.m_ZedGraph.ScrollGrace = 0D;
            this.m_ZedGraph.ScrollMaxX = 0D;
            this.m_ZedGraph.ScrollMaxY = 0D;
            this.m_ZedGraph.ScrollMaxY2 = 0D;
            this.m_ZedGraph.ScrollMinX = 0D;
            this.m_ZedGraph.ScrollMinY = 0D;
            this.m_ZedGraph.ScrollMinY2 = 0D;
            this.m_ZedGraph.Size = new System.Drawing.Size(845, 266);
            this.m_ZedGraph.TabIndex = 20941;
            // 
            // sys3Label48
            // 
            this.sys3Label48.BackGroundColor = System.Drawing.Color.DarkGray;
            this.sys3Label48.BorderStroke = 2;
            this.sys3Label48.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.sys3Label48.Description = "";
            this.sys3Label48.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3Label48.EdgeRadius = 1;
            this.sys3Label48.ImagePosition = new System.Drawing.Point(0, 0);
            this.sys3Label48.ImageSize = new System.Drawing.Point(0, 0);
            this.sys3Label48.LoadImage = null;
            this.sys3Label48.Location = new System.Drawing.Point(854, 101);
            this.sys3Label48.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label48.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label48.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label48.Name = "sys3Label48";
            this.sys3Label48.Size = new System.Drawing.Size(70, 30);
            this.sys3Label48.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label48.SubFontColor = System.Drawing.Color.Gray;
            this.sys3Label48.SubText = "";
            this.sys3Label48.TabIndex = 20965;
            this.sys3Label48.Tag = "";
            this.sys3Label48.Text = "MAX";
            this.sys3Label48.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3Label48.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.sys3Label48.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label48.ThemeIndex = 0;
            this.sys3Label48.UnitAreaRate = 30;
            this.sys3Label48.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label48.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sys3Label48.UnitPositionVertical = false;
            this.sys3Label48.UnitText = "";
            this.sys3Label48.UseBorder = true;
            this.sys3Label48.UseEdgeRadius = false;
            this.sys3Label48.UseImage = false;
            this.sys3Label48.UseSubFont = true;
            this.sys3Label48.UseUnitFont = false;
            // 
            // m_lblCalVolt
            // 
            this.m_lblCalVolt.BackGroundColor = System.Drawing.Color.DimGray;
            this.m_lblCalVolt.BorderStroke = 2;
            this.m_lblCalVolt.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblCalVolt.Description = "";
            this.m_lblCalVolt.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblCalVolt.EdgeRadius = 1;
            this.m_lblCalVolt.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_lblCalVolt.ImageSize = new System.Drawing.Point(0, 0);
            this.m_lblCalVolt.LoadImage = null;
            this.m_lblCalVolt.Location = new System.Drawing.Point(1091, 271);
            this.m_lblCalVolt.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_lblCalVolt.MainFontColor = System.Drawing.Color.White;
            this.m_lblCalVolt.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_lblCalVolt.Name = "m_lblCalVolt";
            this.m_lblCalVolt.Size = new System.Drawing.Size(89, 30);
            this.m_lblCalVolt.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblCalVolt.SubFontColor = System.Drawing.Color.Gray;
            this.m_lblCalVolt.SubText = "";
            this.m_lblCalVolt.TabIndex = 20961;
            this.m_lblCalVolt.Tag = "";
            this.m_lblCalVolt.Text = "9999.9";
            this.m_lblCalVolt.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblCalVolt.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblCalVolt.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblCalVolt.ThemeIndex = 0;
            this.m_lblCalVolt.UnitAreaRate = 30;
            this.m_lblCalVolt.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblCalVolt.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblCalVolt.UnitPositionVertical = false;
            this.m_lblCalVolt.UnitText = "V";
            this.m_lblCalVolt.UseBorder = true;
            this.m_lblCalVolt.UseEdgeRadius = false;
            this.m_lblCalVolt.UseImage = false;
            this.m_lblCalVolt.UseSubFont = true;
            this.m_lblCalVolt.UseUnitFont = true;
            // 
            // m_lblCalStep
            // 
            this.m_lblCalStep.BackGroundColor = System.Drawing.Color.DimGray;
            this.m_lblCalStep.BorderStroke = 2;
            this.m_lblCalStep.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblCalStep.Description = "";
            this.m_lblCalStep.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblCalStep.EdgeRadius = 1;
            this.m_lblCalStep.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_lblCalStep.ImageSize = new System.Drawing.Point(0, 0);
            this.m_lblCalStep.LoadImage = null;
            this.m_lblCalStep.Location = new System.Drawing.Point(1091, 240);
            this.m_lblCalStep.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_lblCalStep.MainFontColor = System.Drawing.Color.White;
            this.m_lblCalStep.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_lblCalStep.Name = "m_lblCalStep";
            this.m_lblCalStep.Size = new System.Drawing.Size(89, 30);
            this.m_lblCalStep.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblCalStep.SubFontColor = System.Drawing.Color.Gray;
            this.m_lblCalStep.SubText = "";
            this.m_lblCalStep.TabIndex = 20960;
            this.m_lblCalStep.Tag = "";
            this.m_lblCalStep.Text = "9999.9";
            this.m_lblCalStep.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblCalStep.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblCalStep.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblCalStep.ThemeIndex = 0;
            this.m_lblCalStep.UnitAreaRate = 30;
            this.m_lblCalStep.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblCalStep.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblCalStep.UnitPositionVertical = false;
            this.m_lblCalStep.UnitText = "W";
            this.m_lblCalStep.UseBorder = true;
            this.m_lblCalStep.UseEdgeRadius = false;
            this.m_lblCalStep.UseImage = false;
            this.m_lblCalStep.UseSubFont = true;
            this.m_lblCalStep.UseUnitFont = false;
            // 
            // m_lblCalChannel
            // 
            this.m_lblCalChannel.BackGroundColor = System.Drawing.Color.DimGray;
            this.m_lblCalChannel.BorderStroke = 2;
            this.m_lblCalChannel.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblCalChannel.Description = "";
            this.m_lblCalChannel.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblCalChannel.EdgeRadius = 1;
            this.m_lblCalChannel.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_lblCalChannel.ImageSize = new System.Drawing.Point(0, 0);
            this.m_lblCalChannel.LoadImage = null;
            this.m_lblCalChannel.Location = new System.Drawing.Point(1091, 209);
            this.m_lblCalChannel.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_lblCalChannel.MainFontColor = System.Drawing.Color.White;
            this.m_lblCalChannel.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_lblCalChannel.Name = "m_lblCalChannel";
            this.m_lblCalChannel.Size = new System.Drawing.Size(89, 30);
            this.m_lblCalChannel.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblCalChannel.SubFontColor = System.Drawing.Color.Gray;
            this.m_lblCalChannel.SubText = "";
            this.m_lblCalChannel.TabIndex = 20959;
            this.m_lblCalChannel.Tag = "";
            this.m_lblCalChannel.Text = "9999.9";
            this.m_lblCalChannel.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblCalChannel.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblCalChannel.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblCalChannel.ThemeIndex = 0;
            this.m_lblCalChannel.UnitAreaRate = 30;
            this.m_lblCalChannel.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblCalChannel.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblCalChannel.UnitPositionVertical = false;
            this.m_lblCalChannel.UnitText = "W";
            this.m_lblCalChannel.UseBorder = true;
            this.m_lblCalChannel.UseEdgeRadius = false;
            this.m_lblCalChannel.UseImage = false;
            this.m_lblCalChannel.UseSubFont = true;
            this.m_lblCalChannel.UseUnitFont = false;
            // 
            // m_lblRestTime
            // 
            this.m_lblRestTime.BackGroundColor = System.Drawing.Color.DimGray;
            this.m_lblRestTime.BorderStroke = 2;
            this.m_lblRestTime.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblRestTime.Description = "";
            this.m_lblRestTime.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblRestTime.EdgeRadius = 1;
            this.m_lblRestTime.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_lblRestTime.ImageSize = new System.Drawing.Point(0, 0);
            this.m_lblRestTime.LoadImage = null;
            this.m_lblRestTime.Location = new System.Drawing.Point(1091, 128);
            this.m_lblRestTime.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_lblRestTime.MainFontColor = System.Drawing.Color.White;
            this.m_lblRestTime.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_lblRestTime.Name = "m_lblRestTime";
            this.m_lblRestTime.Size = new System.Drawing.Size(89, 30);
            this.m_lblRestTime.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblRestTime.SubFontColor = System.Drawing.Color.Gray;
            this.m_lblRestTime.SubText = "";
            this.m_lblRestTime.TabIndex = 20958;
            this.m_lblRestTime.Tag = "";
            this.m_lblRestTime.Text = "9999.9";
            this.m_lblRestTime.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblRestTime.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblRestTime.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblRestTime.ThemeIndex = 0;
            this.m_lblRestTime.UnitAreaRate = 30;
            this.m_lblRestTime.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblRestTime.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblRestTime.UnitPositionVertical = false;
            this.m_lblRestTime.UnitText = "S";
            this.m_lblRestTime.UseBorder = true;
            this.m_lblRestTime.UseEdgeRadius = false;
            this.m_lblRestTime.UseImage = false;
            this.m_lblRestTime.UseSubFont = true;
            this.m_lblRestTime.UseUnitFont = true;
            // 
            // m_lblRepeatAvg
            // 
            this.m_lblRepeatAvg.BackGroundColor = System.Drawing.Color.DimGray;
            this.m_lblRepeatAvg.BorderStroke = 2;
            this.m_lblRepeatAvg.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblRepeatAvg.Description = "";
            this.m_lblRepeatAvg.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblRepeatAvg.EdgeRadius = 1;
            this.m_lblRepeatAvg.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_lblRepeatAvg.ImageSize = new System.Drawing.Point(0, 0);
            this.m_lblRepeatAvg.LoadImage = null;
            this.m_lblRepeatAvg.Location = new System.Drawing.Point(1091, 97);
            this.m_lblRepeatAvg.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_lblRepeatAvg.MainFontColor = System.Drawing.Color.White;
            this.m_lblRepeatAvg.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_lblRepeatAvg.Name = "m_lblRepeatAvg";
            this.m_lblRepeatAvg.Size = new System.Drawing.Size(89, 30);
            this.m_lblRepeatAvg.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblRepeatAvg.SubFontColor = System.Drawing.Color.Gray;
            this.m_lblRepeatAvg.SubText = "";
            this.m_lblRepeatAvg.TabIndex = 20957;
            this.m_lblRepeatAvg.Tag = "";
            this.m_lblRepeatAvg.Text = "9999.9";
            this.m_lblRepeatAvg.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblRepeatAvg.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblRepeatAvg.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblRepeatAvg.ThemeIndex = 0;
            this.m_lblRepeatAvg.UnitAreaRate = 30;
            this.m_lblRepeatAvg.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblRepeatAvg.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblRepeatAvg.UnitPositionVertical = false;
            this.m_lblRepeatAvg.UnitText = "W";
            this.m_lblRepeatAvg.UseBorder = true;
            this.m_lblRepeatAvg.UseEdgeRadius = false;
            this.m_lblRepeatAvg.UseImage = false;
            this.m_lblRepeatAvg.UseSubFont = true;
            this.m_lblRepeatAvg.UseUnitFont = true;
            // 
            // m_lblRepeatCount
            // 
            this.m_lblRepeatCount.BackGroundColor = System.Drawing.Color.DimGray;
            this.m_lblRepeatCount.BorderStroke = 2;
            this.m_lblRepeatCount.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblRepeatCount.Description = "";
            this.m_lblRepeatCount.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblRepeatCount.EdgeRadius = 1;
            this.m_lblRepeatCount.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_lblRepeatCount.ImageSize = new System.Drawing.Point(0, 0);
            this.m_lblRepeatCount.LoadImage = null;
            this.m_lblRepeatCount.Location = new System.Drawing.Point(1091, 66);
            this.m_lblRepeatCount.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_lblRepeatCount.MainFontColor = System.Drawing.Color.White;
            this.m_lblRepeatCount.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_lblRepeatCount.Name = "m_lblRepeatCount";
            this.m_lblRepeatCount.Size = new System.Drawing.Size(89, 30);
            this.m_lblRepeatCount.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblRepeatCount.SubFontColor = System.Drawing.Color.Gray;
            this.m_lblRepeatCount.SubText = "";
            this.m_lblRepeatCount.TabIndex = 20956;
            this.m_lblRepeatCount.Tag = "";
            this.m_lblRepeatCount.Text = "9999.9";
            this.m_lblRepeatCount.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblRepeatCount.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblRepeatCount.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblRepeatCount.ThemeIndex = 0;
            this.m_lblRepeatCount.UnitAreaRate = 30;
            this.m_lblRepeatCount.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblRepeatCount.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblRepeatCount.UnitPositionVertical = false;
            this.m_lblRepeatCount.UnitText = "W";
            this.m_lblRepeatCount.UseBorder = true;
            this.m_lblRepeatCount.UseEdgeRadius = false;
            this.m_lblRepeatCount.UseImage = false;
            this.m_lblRepeatCount.UseSubFont = true;
            this.m_lblRepeatCount.UseUnitFont = false;
            // 
            // m_lblinputVolt
            // 
            this.m_lblinputVolt.BackGroundColor = System.Drawing.Color.DimGray;
            this.m_lblinputVolt.BorderStroke = 2;
            this.m_lblinputVolt.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblinputVolt.Description = "";
            this.m_lblinputVolt.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblinputVolt.EdgeRadius = 1;
            this.m_lblinputVolt.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_lblinputVolt.ImageSize = new System.Drawing.Point(0, 0);
            this.m_lblinputVolt.LoadImage = null;
            this.m_lblinputVolt.Location = new System.Drawing.Point(925, 178);
            this.m_lblinputVolt.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_lblinputVolt.MainFontColor = System.Drawing.Color.White;
            this.m_lblinputVolt.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_lblinputVolt.Name = "m_lblinputVolt";
            this.m_lblinputVolt.Size = new System.Drawing.Size(89, 30);
            this.m_lblinputVolt.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblinputVolt.SubFontColor = System.Drawing.Color.Gray;
            this.m_lblinputVolt.SubText = "";
            this.m_lblinputVolt.TabIndex = 20955;
            this.m_lblinputVolt.Tag = "";
            this.m_lblinputVolt.Text = "9999.9";
            this.m_lblinputVolt.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblinputVolt.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblinputVolt.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblinputVolt.ThemeIndex = 0;
            this.m_lblinputVolt.UnitAreaRate = 30;
            this.m_lblinputVolt.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblinputVolt.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblinputVolt.UnitPositionVertical = false;
            this.m_lblinputVolt.UnitText = "V";
            this.m_lblinputVolt.UseBorder = true;
            this.m_lblinputVolt.UseEdgeRadius = false;
            this.m_lblinputVolt.UseImage = false;
            this.m_lblinputVolt.UseSubFont = true;
            this.m_lblinputVolt.UseUnitFont = true;
            // 
            // m_lblAvgValue
            // 
            this.m_lblAvgValue.BackGroundColor = System.Drawing.Color.DimGray;
            this.m_lblAvgValue.BorderStroke = 2;
            this.m_lblAvgValue.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblAvgValue.Description = "";
            this.m_lblAvgValue.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblAvgValue.EdgeRadius = 1;
            this.m_lblAvgValue.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_lblAvgValue.ImageSize = new System.Drawing.Point(0, 0);
            this.m_lblAvgValue.LoadImage = null;
            this.m_lblAvgValue.Location = new System.Drawing.Point(925, 132);
            this.m_lblAvgValue.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_lblAvgValue.MainFontColor = System.Drawing.Color.White;
            this.m_lblAvgValue.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_lblAvgValue.Name = "m_lblAvgValue";
            this.m_lblAvgValue.Size = new System.Drawing.Size(89, 30);
            this.m_lblAvgValue.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblAvgValue.SubFontColor = System.Drawing.Color.Gray;
            this.m_lblAvgValue.SubText = "";
            this.m_lblAvgValue.TabIndex = 20954;
            this.m_lblAvgValue.Tag = "";
            this.m_lblAvgValue.Text = "9999.9";
            this.m_lblAvgValue.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblAvgValue.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblAvgValue.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblAvgValue.ThemeIndex = 0;
            this.m_lblAvgValue.UnitAreaRate = 30;
            this.m_lblAvgValue.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblAvgValue.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblAvgValue.UnitPositionVertical = false;
            this.m_lblAvgValue.UnitText = "W";
            this.m_lblAvgValue.UseBorder = true;
            this.m_lblAvgValue.UseEdgeRadius = false;
            this.m_lblAvgValue.UseImage = false;
            this.m_lblAvgValue.UseSubFont = true;
            this.m_lblAvgValue.UseUnitFont = true;
            // 
            // m_lblMaxValue
            // 
            this.m_lblMaxValue.BackGroundColor = System.Drawing.Color.DimGray;
            this.m_lblMaxValue.BorderStroke = 2;
            this.m_lblMaxValue.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblMaxValue.Description = "";
            this.m_lblMaxValue.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblMaxValue.EdgeRadius = 1;
            this.m_lblMaxValue.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_lblMaxValue.ImageSize = new System.Drawing.Point(0, 0);
            this.m_lblMaxValue.LoadImage = null;
            this.m_lblMaxValue.Location = new System.Drawing.Point(925, 101);
            this.m_lblMaxValue.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_lblMaxValue.MainFontColor = System.Drawing.Color.White;
            this.m_lblMaxValue.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_lblMaxValue.Name = "m_lblMaxValue";
            this.m_lblMaxValue.Size = new System.Drawing.Size(89, 30);
            this.m_lblMaxValue.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblMaxValue.SubFontColor = System.Drawing.Color.Gray;
            this.m_lblMaxValue.SubText = "";
            this.m_lblMaxValue.TabIndex = 20962;
            this.m_lblMaxValue.Tag = "";
            this.m_lblMaxValue.Text = "9999.9";
            this.m_lblMaxValue.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblMaxValue.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblMaxValue.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblMaxValue.ThemeIndex = 0;
            this.m_lblMaxValue.UnitAreaRate = 30;
            this.m_lblMaxValue.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblMaxValue.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblMaxValue.UnitPositionVertical = false;
            this.m_lblMaxValue.UnitText = "W";
            this.m_lblMaxValue.UseBorder = true;
            this.m_lblMaxValue.UseEdgeRadius = false;
            this.m_lblMaxValue.UseImage = false;
            this.m_lblMaxValue.UseSubFont = true;
            this.m_lblMaxValue.UseUnitFont = true;
            // 
            // sys3Label12
            // 
            this.sys3Label12.BackGroundColor = System.Drawing.Color.DarkGray;
            this.sys3Label12.BorderStroke = 2;
            this.sys3Label12.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.sys3Label12.Description = "";
            this.sys3Label12.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3Label12.EdgeRadius = 1;
            this.sys3Label12.ImagePosition = new System.Drawing.Point(0, 0);
            this.sys3Label12.ImageSize = new System.Drawing.Point(0, 0);
            this.sys3Label12.LoadImage = null;
            this.sys3Label12.Location = new System.Drawing.Point(1018, 271);
            this.sys3Label12.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label12.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label12.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label12.Name = "sys3Label12";
            this.sys3Label12.Size = new System.Drawing.Size(72, 30);
            this.sys3Label12.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label12.SubFontColor = System.Drawing.Color.Gray;
            this.sys3Label12.SubText = "";
            this.sys3Label12.TabIndex = 20942;
            this.sys3Label12.Tag = "";
            this.sys3Label12.Text = "VOLT";
            this.sys3Label12.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3Label12.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.sys3Label12.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label12.ThemeIndex = 0;
            this.sys3Label12.UnitAreaRate = 30;
            this.sys3Label12.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label12.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sys3Label12.UnitPositionVertical = false;
            this.sys3Label12.UnitText = "";
            this.sys3Label12.UseBorder = true;
            this.sys3Label12.UseEdgeRadius = false;
            this.sys3Label12.UseImage = false;
            this.sys3Label12.UseSubFont = true;
            this.sys3Label12.UseUnitFont = false;
            // 
            // m_lblLastValue
            // 
            this.m_lblLastValue.BackGroundColor = System.Drawing.Color.DimGray;
            this.m_lblLastValue.BorderStroke = 2;
            this.m_lblLastValue.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblLastValue.Description = "";
            this.m_lblLastValue.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblLastValue.EdgeRadius = 1;
            this.m_lblLastValue.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_lblLastValue.ImageSize = new System.Drawing.Point(0, 0);
            this.m_lblLastValue.LoadImage = null;
            this.m_lblLastValue.Location = new System.Drawing.Point(925, 35);
            this.m_lblLastValue.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_lblLastValue.MainFontColor = System.Drawing.Color.White;
            this.m_lblLastValue.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_lblLastValue.Name = "m_lblLastValue";
            this.m_lblLastValue.Size = new System.Drawing.Size(89, 30);
            this.m_lblLastValue.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblLastValue.SubFontColor = System.Drawing.Color.Gray;
            this.m_lblLastValue.SubText = "";
            this.m_lblLastValue.TabIndex = 20963;
            this.m_lblLastValue.Tag = "";
            this.m_lblLastValue.Text = "9999.9";
            this.m_lblLastValue.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblLastValue.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblLastValue.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblLastValue.ThemeIndex = 0;
            this.m_lblLastValue.UnitAreaRate = 30;
            this.m_lblLastValue.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblLastValue.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblLastValue.UnitPositionVertical = false;
            this.m_lblLastValue.UnitText = "W";
            this.m_lblLastValue.UseBorder = true;
            this.m_lblLastValue.UseEdgeRadius = false;
            this.m_lblLastValue.UseImage = false;
            this.m_lblLastValue.UseSubFont = true;
            this.m_lblLastValue.UseUnitFont = true;
            // 
            // sys3Label7
            // 
            this.sys3Label7.BackGroundColor = System.Drawing.Color.DarkGray;
            this.sys3Label7.BorderStroke = 2;
            this.sys3Label7.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.sys3Label7.Description = "";
            this.sys3Label7.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3Label7.EdgeRadius = 1;
            this.sys3Label7.ImagePosition = new System.Drawing.Point(0, 0);
            this.sys3Label7.ImageSize = new System.Drawing.Point(0, 0);
            this.sys3Label7.LoadImage = null;
            this.sys3Label7.Location = new System.Drawing.Point(1018, 240);
            this.sys3Label7.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label7.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label7.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label7.Name = "sys3Label7";
            this.sys3Label7.Size = new System.Drawing.Size(72, 30);
            this.sys3Label7.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label7.SubFontColor = System.Drawing.Color.Gray;
            this.sys3Label7.SubText = "";
            this.sys3Label7.TabIndex = 20949;
            this.sys3Label7.Tag = "";
            this.sys3Label7.Text = "STEP";
            this.sys3Label7.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3Label7.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.sys3Label7.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label7.ThemeIndex = 0;
            this.sys3Label7.UnitAreaRate = 30;
            this.sys3Label7.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label7.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sys3Label7.UnitPositionVertical = false;
            this.sys3Label7.UnitText = "";
            this.sys3Label7.UseBorder = true;
            this.sys3Label7.UseEdgeRadius = false;
            this.sys3Label7.UseImage = false;
            this.sys3Label7.UseSubFont = true;
            this.sys3Label7.UseUnitFont = false;
            // 
            // m_lblMinValue
            // 
            this.m_lblMinValue.BackGroundColor = System.Drawing.Color.DimGray;
            this.m_lblMinValue.BorderStroke = 2;
            this.m_lblMinValue.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblMinValue.Description = "";
            this.m_lblMinValue.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblMinValue.EdgeRadius = 1;
            this.m_lblMinValue.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_lblMinValue.ImageSize = new System.Drawing.Point(0, 0);
            this.m_lblMinValue.LoadImage = null;
            this.m_lblMinValue.Location = new System.Drawing.Point(925, 70);
            this.m_lblMinValue.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_lblMinValue.MainFontColor = System.Drawing.Color.White;
            this.m_lblMinValue.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_lblMinValue.Name = "m_lblMinValue";
            this.m_lblMinValue.Size = new System.Drawing.Size(89, 30);
            this.m_lblMinValue.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblMinValue.SubFontColor = System.Drawing.Color.Gray;
            this.m_lblMinValue.SubText = "";
            this.m_lblMinValue.TabIndex = 20964;
            this.m_lblMinValue.Tag = "";
            this.m_lblMinValue.Text = "9999.9";
            this.m_lblMinValue.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblMinValue.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblMinValue.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblMinValue.ThemeIndex = 0;
            this.m_lblMinValue.UnitAreaRate = 30;
            this.m_lblMinValue.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblMinValue.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblMinValue.UnitPositionVertical = false;
            this.m_lblMinValue.UnitText = "W";
            this.m_lblMinValue.UseBorder = true;
            this.m_lblMinValue.UseEdgeRadius = false;
            this.m_lblMinValue.UseImage = false;
            this.m_lblMinValue.UseSubFont = true;
            this.m_lblMinValue.UseUnitFont = true;
            // 
            // sys3Label11
            // 
            this.sys3Label11.BackGroundColor = System.Drawing.Color.DarkGray;
            this.sys3Label11.BorderStroke = 2;
            this.sys3Label11.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.sys3Label11.Description = "";
            this.sys3Label11.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3Label11.EdgeRadius = 1;
            this.sys3Label11.ImagePosition = new System.Drawing.Point(0, 0);
            this.sys3Label11.ImageSize = new System.Drawing.Point(0, 0);
            this.sys3Label11.LoadImage = null;
            this.sys3Label11.Location = new System.Drawing.Point(1018, 209);
            this.sys3Label11.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label11.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label11.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label11.Name = "sys3Label11";
            this.sys3Label11.Size = new System.Drawing.Size(72, 30);
            this.sys3Label11.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label11.SubFontColor = System.Drawing.Color.Gray;
            this.sys3Label11.SubText = "";
            this.sys3Label11.TabIndex = 20947;
            this.sys3Label11.Tag = "";
            this.sys3Label11.Text = "CH";
            this.sys3Label11.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3Label11.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.sys3Label11.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label11.ThemeIndex = 0;
            this.sys3Label11.UnitAreaRate = 30;
            this.sys3Label11.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label11.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sys3Label11.UnitPositionVertical = false;
            this.sys3Label11.UnitText = "";
            this.sys3Label11.UseBorder = true;
            this.sys3Label11.UseEdgeRadius = false;
            this.sys3Label11.UseImage = false;
            this.sys3Label11.UseSubFont = true;
            this.sys3Label11.UseUnitFont = false;
            // 
            // sys3Label6
            // 
            this.sys3Label6.BackGroundColor = System.Drawing.Color.DarkGray;
            this.sys3Label6.BorderStroke = 2;
            this.sys3Label6.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.sys3Label6.Description = "";
            this.sys3Label6.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3Label6.EdgeRadius = 1;
            this.sys3Label6.ImagePosition = new System.Drawing.Point(0, 0);
            this.sys3Label6.ImageSize = new System.Drawing.Point(0, 0);
            this.sys3Label6.LoadImage = null;
            this.sys3Label6.Location = new System.Drawing.Point(1018, 128);
            this.sys3Label6.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label6.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label6.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label6.Name = "sys3Label6";
            this.sys3Label6.Size = new System.Drawing.Size(72, 30);
            this.sys3Label6.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label6.SubFontColor = System.Drawing.Color.Gray;
            this.sys3Label6.SubText = "";
            this.sys3Label6.TabIndex = 20946;
            this.sys3Label6.Tag = "";
            this.sys3Label6.Text = "REST";
            this.sys3Label6.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3Label6.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.sys3Label6.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label6.ThemeIndex = 0;
            this.sys3Label6.UnitAreaRate = 30;
            this.sys3Label6.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label6.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sys3Label6.UnitPositionVertical = false;
            this.sys3Label6.UnitText = "";
            this.sys3Label6.UseBorder = true;
            this.sys3Label6.UseEdgeRadius = false;
            this.sys3Label6.UseImage = false;
            this.sys3Label6.UseSubFont = true;
            this.sys3Label6.UseUnitFont = false;
            // 
            // sys3Label5
            // 
            this.sys3Label5.BackGroundColor = System.Drawing.Color.DarkGray;
            this.sys3Label5.BorderStroke = 2;
            this.sys3Label5.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.sys3Label5.Description = "";
            this.sys3Label5.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3Label5.EdgeRadius = 1;
            this.sys3Label5.ImagePosition = new System.Drawing.Point(0, 0);
            this.sys3Label5.ImageSize = new System.Drawing.Point(0, 0);
            this.sys3Label5.LoadImage = null;
            this.sys3Label5.Location = new System.Drawing.Point(1018, 178);
            this.sys3Label5.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label5.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label5.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label5.Name = "sys3Label5";
            this.sys3Label5.Size = new System.Drawing.Size(162, 30);
            this.sys3Label5.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label5.SubFontColor = System.Drawing.Color.Gray;
            this.sys3Label5.SubText = "";
            this.sys3Label5.TabIndex = 20945;
            this.sys3Label5.Tag = "";
            this.sys3Label5.Text = "CALIBRATION";
            this.sys3Label5.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label5.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.sys3Label5.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label5.ThemeIndex = 0;
            this.sys3Label5.UnitAreaRate = 30;
            this.sys3Label5.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label5.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sys3Label5.UnitPositionVertical = false;
            this.sys3Label5.UnitText = "";
            this.sys3Label5.UseBorder = true;
            this.sys3Label5.UseEdgeRadius = false;
            this.sys3Label5.UseImage = false;
            this.sys3Label5.UseSubFont = true;
            this.sys3Label5.UseUnitFont = false;
            // 
            // sys3Label8
            // 
            this.sys3Label8.BackGroundColor = System.Drawing.Color.DarkGray;
            this.sys3Label8.BorderStroke = 2;
            this.sys3Label8.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.sys3Label8.Description = "";
            this.sys3Label8.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3Label8.EdgeRadius = 1;
            this.sys3Label8.ImagePosition = new System.Drawing.Point(0, 0);
            this.sys3Label8.ImageSize = new System.Drawing.Point(0, 0);
            this.sys3Label8.LoadImage = null;
            this.sys3Label8.Location = new System.Drawing.Point(1018, 35);
            this.sys3Label8.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label8.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label8.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label8.Name = "sys3Label8";
            this.sys3Label8.Size = new System.Drawing.Size(162, 30);
            this.sys3Label8.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label8.SubFontColor = System.Drawing.Color.Gray;
            this.sys3Label8.SubText = "";
            this.sys3Label8.TabIndex = 20944;
            this.sys3Label8.Tag = "";
            this.sys3Label8.Text = "REPEAT";
            this.sys3Label8.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label8.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.sys3Label8.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label8.ThemeIndex = 0;
            this.sys3Label8.UnitAreaRate = 30;
            this.sys3Label8.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label8.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sys3Label8.UnitPositionVertical = false;
            this.sys3Label8.UnitText = "";
            this.sys3Label8.UseBorder = true;
            this.sys3Label8.UseEdgeRadius = false;
            this.sys3Label8.UseImage = false;
            this.sys3Label8.UseSubFont = true;
            this.sys3Label8.UseUnitFont = false;
            // 
            // sys3Label9
            // 
            this.sys3Label9.BackGroundColor = System.Drawing.Color.DarkGray;
            this.sys3Label9.BorderStroke = 2;
            this.sys3Label9.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.sys3Label9.Description = "";
            this.sys3Label9.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3Label9.EdgeRadius = 1;
            this.sys3Label9.ImagePosition = new System.Drawing.Point(0, 0);
            this.sys3Label9.ImageSize = new System.Drawing.Point(0, 0);
            this.sys3Label9.LoadImage = null;
            this.sys3Label9.Location = new System.Drawing.Point(1018, 97);
            this.sys3Label9.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label9.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label9.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label9.Name = "sys3Label9";
            this.sys3Label9.Size = new System.Drawing.Size(72, 30);
            this.sys3Label9.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label9.SubFontColor = System.Drawing.Color.Gray;
            this.sys3Label9.SubText = "";
            this.sys3Label9.TabIndex = 20943;
            this.sys3Label9.Tag = "";
            this.sys3Label9.Text = "AVG";
            this.sys3Label9.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3Label9.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.sys3Label9.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label9.ThemeIndex = 0;
            this.sys3Label9.UnitAreaRate = 30;
            this.sys3Label9.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label9.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sys3Label9.UnitPositionVertical = false;
            this.sys3Label9.UnitText = "";
            this.sys3Label9.UseBorder = true;
            this.sys3Label9.UseEdgeRadius = false;
            this.sys3Label9.UseImage = false;
            this.sys3Label9.UseSubFont = true;
            this.sys3Label9.UseUnitFont = false;
            // 
            // sys3Label10
            // 
            this.sys3Label10.BackGroundColor = System.Drawing.Color.DarkGray;
            this.sys3Label10.BorderStroke = 2;
            this.sys3Label10.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.sys3Label10.Description = "";
            this.sys3Label10.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3Label10.EdgeRadius = 1;
            this.sys3Label10.ImagePosition = new System.Drawing.Point(0, 0);
            this.sys3Label10.ImageSize = new System.Drawing.Point(0, 0);
            this.sys3Label10.LoadImage = null;
            this.sys3Label10.Location = new System.Drawing.Point(854, 178);
            this.sys3Label10.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label10.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label10.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label10.Name = "sys3Label10";
            this.sys3Label10.Size = new System.Drawing.Size(70, 30);
            this.sys3Label10.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label10.SubFontColor = System.Drawing.Color.Gray;
            this.sys3Label10.SubText = "";
            this.sys3Label10.TabIndex = 20950;
            this.sys3Label10.Tag = "";
            this.sys3Label10.Text = "INPUT";
            this.sys3Label10.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3Label10.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.sys3Label10.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label10.ThemeIndex = 0;
            this.sys3Label10.UnitAreaRate = 30;
            this.sys3Label10.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label10.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sys3Label10.UnitPositionVertical = false;
            this.sys3Label10.UnitText = "";
            this.sys3Label10.UseBorder = true;
            this.sys3Label10.UseEdgeRadius = false;
            this.sys3Label10.UseImage = false;
            this.sys3Label10.UseSubFont = true;
            this.sys3Label10.UseUnitFont = false;
            // 
            // sys3Label4
            // 
            this.sys3Label4.BackGroundColor = System.Drawing.Color.DarkGray;
            this.sys3Label4.BorderStroke = 2;
            this.sys3Label4.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.sys3Label4.Description = "";
            this.sys3Label4.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3Label4.EdgeRadius = 1;
            this.sys3Label4.ImagePosition = new System.Drawing.Point(0, 0);
            this.sys3Label4.ImageSize = new System.Drawing.Point(0, 0);
            this.sys3Label4.LoadImage = null;
            this.sys3Label4.Location = new System.Drawing.Point(1018, 66);
            this.sys3Label4.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label4.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label4.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label4.Name = "sys3Label4";
            this.sys3Label4.Size = new System.Drawing.Size(72, 30);
            this.sys3Label4.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label4.SubFontColor = System.Drawing.Color.Gray;
            this.sys3Label4.SubText = "";
            this.sys3Label4.TabIndex = 20951;
            this.sys3Label4.Tag = "";
            this.sys3Label4.Text = "COUNT";
            this.sys3Label4.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3Label4.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.sys3Label4.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label4.ThemeIndex = 0;
            this.sys3Label4.UnitAreaRate = 30;
            this.sys3Label4.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label4.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sys3Label4.UnitPositionVertical = false;
            this.sys3Label4.UnitText = "";
            this.sys3Label4.UseBorder = true;
            this.sys3Label4.UseEdgeRadius = false;
            this.sys3Label4.UseImage = false;
            this.sys3Label4.UseSubFont = true;
            this.sys3Label4.UseUnitFont = false;
            // 
            // sys3Label1
            // 
            this.sys3Label1.BackGroundColor = System.Drawing.Color.DarkGray;
            this.sys3Label1.BorderStroke = 2;
            this.sys3Label1.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.sys3Label1.Description = "";
            this.sys3Label1.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3Label1.EdgeRadius = 1;
            this.sys3Label1.ImagePosition = new System.Drawing.Point(0, 0);
            this.sys3Label1.ImageSize = new System.Drawing.Point(0, 0);
            this.sys3Label1.LoadImage = null;
            this.sys3Label1.Location = new System.Drawing.Point(854, 132);
            this.sys3Label1.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label1.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label1.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label1.Name = "sys3Label1";
            this.sys3Label1.Size = new System.Drawing.Size(70, 30);
            this.sys3Label1.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label1.SubFontColor = System.Drawing.Color.Gray;
            this.sys3Label1.SubText = "";
            this.sys3Label1.TabIndex = 20948;
            this.sys3Label1.Tag = "";
            this.sys3Label1.Text = "AVG";
            this.sys3Label1.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3Label1.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.sys3Label1.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label1.ThemeIndex = 0;
            this.sys3Label1.UnitAreaRate = 30;
            this.sys3Label1.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label1.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sys3Label1.UnitPositionVertical = false;
            this.sys3Label1.UnitText = "";
            this.sys3Label1.UseBorder = true;
            this.sys3Label1.UseEdgeRadius = false;
            this.sys3Label1.UseImage = false;
            this.sys3Label1.UseSubFont = true;
            this.sys3Label1.UseUnitFont = false;
            // 
            // sys3Label16
            // 
            this.sys3Label16.BackGroundColor = System.Drawing.Color.DarkGray;
            this.sys3Label16.BorderStroke = 2;
            this.sys3Label16.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.sys3Label16.Description = "";
            this.sys3Label16.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3Label16.EdgeRadius = 1;
            this.sys3Label16.ImagePosition = new System.Drawing.Point(0, 0);
            this.sys3Label16.ImageSize = new System.Drawing.Point(0, 0);
            this.sys3Label16.LoadImage = null;
            this.sys3Label16.Location = new System.Drawing.Point(854, 35);
            this.sys3Label16.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label16.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label16.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label16.Name = "sys3Label16";
            this.sys3Label16.Size = new System.Drawing.Size(70, 30);
            this.sys3Label16.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label16.SubFontColor = System.Drawing.Color.Gray;
            this.sys3Label16.SubText = "";
            this.sys3Label16.TabIndex = 20952;
            this.sys3Label16.Tag = "";
            this.sys3Label16.Text = "LAST";
            this.sys3Label16.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3Label16.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.sys3Label16.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label16.ThemeIndex = 0;
            this.sys3Label16.UnitAreaRate = 30;
            this.sys3Label16.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label16.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sys3Label16.UnitPositionVertical = false;
            this.sys3Label16.UnitText = "";
            this.sys3Label16.UseBorder = true;
            this.sys3Label16.UseEdgeRadius = false;
            this.sys3Label16.UseImage = false;
            this.sys3Label16.UseSubFont = true;
            this.sys3Label16.UseUnitFont = false;
            // 
            // sys3Label50
            // 
            this.sys3Label50.BackGroundColor = System.Drawing.Color.DarkGray;
            this.sys3Label50.BorderStroke = 2;
            this.sys3Label50.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.sys3Label50.Description = "";
            this.sys3Label50.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3Label50.EdgeRadius = 1;
            this.sys3Label50.ImagePosition = new System.Drawing.Point(0, 0);
            this.sys3Label50.ImageSize = new System.Drawing.Point(0, 0);
            this.sys3Label50.LoadImage = null;
            this.sys3Label50.Location = new System.Drawing.Point(854, 70);
            this.sys3Label50.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label50.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label50.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label50.Name = "sys3Label50";
            this.sys3Label50.Size = new System.Drawing.Size(70, 30);
            this.sys3Label50.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label50.SubFontColor = System.Drawing.Color.Gray;
            this.sys3Label50.SubText = "";
            this.sys3Label50.TabIndex = 20953;
            this.sys3Label50.Tag = "";
            this.sys3Label50.Text = "MIN";
            this.sys3Label50.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3Label50.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.sys3Label50.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label50.ThemeIndex = 0;
            this.sys3Label50.UnitAreaRate = 30;
            this.sys3Label50.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label50.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sys3Label50.UnitPositionVertical = false;
            this.sys3Label50.UnitText = "";
            this.sys3Label50.UseBorder = true;
            this.sys3Label50.UseEdgeRadius = false;
            this.sys3Label50.UseImage = false;
            this.sys3Label50.UseSubFont = true;
            this.sys3Label50.UseUnitFont = false;
            // 
            // sys3button7
            // 
            this.sys3button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sys3button7.BorderWidth = 5;
            this.sys3button7.ButtonClicked = false;
            this.sys3button7.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.sys3button7.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.sys3button7.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.sys3button7.Description = "";
            this.sys3button7.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3button7.EdgeRadius = 1;
            this.sys3button7.GradientAngle = 60F;
            this.sys3button7.GradientFirstColor = System.Drawing.Color.WhiteSmoke;
            this.sys3button7.GradientSecondColor = System.Drawing.Color.DimGray;
            this.sys3button7.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.sys3button7.ImagePosition = new System.Drawing.Point(37, 25);
            this.sys3button7.ImageSize = new System.Drawing.Point(30, 30);
            this.sys3button7.LoadImage = null;
            this.sys3button7.Location = new System.Drawing.Point(1053, 309);
            this.sys3button7.MainFont = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sys3button7.MainFontColor = System.Drawing.Color.White;
            this.sys3button7.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3button7.Name = "sys3button7";
            this.sys3button7.Size = new System.Drawing.Size(130, 49);
            this.sys3button7.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.sys3button7.SubFontColor = System.Drawing.Color.Black;
            this.sys3button7.SubText = "";
            this.sys3button7.TabIndex = 20883;
            this.sys3button7.Text = "CLOSE";
            this.sys3button7.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3button7.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3button7.ThemeIndex = 0;
            this.sys3button7.UseBorder = true;
            this.sys3button7.UseClickedEmphasizeTextColor = false;
            this.sys3button7.UseCustomizeClickedColor = false;
            this.sys3button7.UseEdge = true;
            this.sys3button7.UseHoverEmphasizeCustomColor = false;
            this.sys3button7.UseImage = true;
            this.sys3button7.UserHoverEmpahsize = false;
            this.sys3button7.UseSubFont = false;
            this.sys3button7.Click += new System.EventHandler(this.Click_Close);
            // 
            // Form_CAL_Monitor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1187, 362);
            this.ControlBox = false;
            this.Controls.Add(this.sys3Label48);
            this.Controls.Add(this.m_lblCalVolt);
            this.Controls.Add(this.m_lblCalStep);
            this.Controls.Add(this.m_lblCalChannel);
            this.Controls.Add(this.m_lblRestTime);
            this.Controls.Add(this.m_lblRepeatAvg);
            this.Controls.Add(this.m_lblRepeatCount);
            this.Controls.Add(this.m_lblinputVolt);
            this.Controls.Add(this.m_lblAvgValue);
            this.Controls.Add(this.m_lblMaxValue);
            this.Controls.Add(this.sys3Label12);
            this.Controls.Add(this.m_lblLastValue);
            this.Controls.Add(this.sys3Label7);
            this.Controls.Add(this.m_lblMinValue);
            this.Controls.Add(this.sys3Label11);
            this.Controls.Add(this.sys3Label6);
            this.Controls.Add(this.sys3Label5);
            this.Controls.Add(this.sys3Label8);
            this.Controls.Add(this.sys3Label9);
            this.Controls.Add(this.sys3Label10);
            this.Controls.Add(this.sys3Label4);
            this.Controls.Add(this.sys3Label1);
            this.Controls.Add(this.sys3Label16);
            this.Controls.Add(this.sys3Label50);
            this.Controls.Add(this.m_ZedGraph);
            this.Controls.Add(this.sys3button7);
            this.Controls.Add(this.sys3GroupBox8);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_CAL_Monitor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MORNITOR";
            this.TopMost = true;
            this.Resize += new System.EventHandler(this.Form_Monitor_Resize);
            this.ResumeLayout(false);

        }

        #endregion
        private Sys3Controls.Sys3GroupBox sys3GroupBox8;
        private ZedGraph.ZedGraphControl m_ZedGraph;
        private Sys3Controls.Sys3Label sys3Label48;
        private Sys3Controls.Sys3Label m_lblCalVolt;
        private Sys3Controls.Sys3Label m_lblCalStep;
        private Sys3Controls.Sys3Label m_lblCalChannel;
        private Sys3Controls.Sys3Label m_lblRestTime;
        private Sys3Controls.Sys3Label m_lblRepeatAvg;
        private Sys3Controls.Sys3Label m_lblRepeatCount;
        private Sys3Controls.Sys3Label m_lblinputVolt;
        private Sys3Controls.Sys3Label m_lblAvgValue;
        private Sys3Controls.Sys3Label m_lblMaxValue;
        private Sys3Controls.Sys3Label sys3Label12;
        private Sys3Controls.Sys3Label m_lblLastValue;
        private Sys3Controls.Sys3Label sys3Label7;
        private Sys3Controls.Sys3Label m_lblMinValue;
        private Sys3Controls.Sys3Label sys3Label11;
        private Sys3Controls.Sys3Label sys3Label6;
        private Sys3Controls.Sys3Label sys3Label5;
        private Sys3Controls.Sys3Label sys3Label8;
        private Sys3Controls.Sys3Label sys3Label9;
        private Sys3Controls.Sys3Label sys3Label10;
        private Sys3Controls.Sys3Label sys3Label4;
        private Sys3Controls.Sys3Label sys3Label1;
        private Sys3Controls.Sys3Label sys3Label16;
        private Sys3Controls.Sys3Label sys3Label50;
        private Sys3Controls.Sys3button sys3button7;
    }
}