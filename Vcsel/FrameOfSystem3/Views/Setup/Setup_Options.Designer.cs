﻿namespace FrameOfSystem3.Views.Setup
{
	partial class Setup_Options
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
			this.btn_Common = new Sys3Controls.Sys3button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btn_AllExtend = new Sys3Controls.Sys3button();
			this.btn_AllReduce = new Sys3Controls.Sys3button();
			this.btn_ParameterUndo = new Sys3Controls.Sys3button();
			this.btn_DecideParameterAll = new Sys3Controls.Sys3button();
			this.panelSubView = new System.Windows.Forms.Panel();
			this.btn_Equipment = new Sys3Controls.Sys3button();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btn_Common
			// 
			this.btn_Common.BorderWidth = 5;
			this.btn_Common.ButtonClicked = false;
			this.btn_Common.ClickedEmphasizeTextColor = System.Drawing.Color.White;
			this.btn_Common.CustomClickedGradientFirstColor = System.Drawing.Color.Thistle;
			this.btn_Common.CustomClickedGradientSecondColor = System.Drawing.Color.PaleVioletRed;
			this.btn_Common.Description = "";
			this.btn_Common.DisabledColor = System.Drawing.Color.DarkGray;
			this.btn_Common.Dock = System.Windows.Forms.DockStyle.Left;
			this.btn_Common.EdgeRadius = 1;
			this.btn_Common.GradientAngle = 60F;
			this.btn_Common.GradientFirstColor = System.Drawing.Color.WhiteSmoke;
			this.btn_Common.GradientSecondColor = System.Drawing.Color.Gray;
			this.btn_Common.HoverEmphasizeCustomColor = System.Drawing.Color.Firebrick;
			this.btn_Common.ImagePosition = new System.Drawing.Point(37, 25);
			this.btn_Common.ImageSize = new System.Drawing.Point(30, 30);
			this.btn_Common.LoadImage = null;
			this.btn_Common.Location = new System.Drawing.Point(0, 0);
			this.btn_Common.MainFont = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.btn_Common.MainFontColor = System.Drawing.Color.White;
			this.btn_Common.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
			this.btn_Common.Name = "btn_Common";
			this.btn_Common.Size = new System.Drawing.Size(150, 49);
			this.btn_Common.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.btn_Common.SubFontColor = System.Drawing.Color.Black;
			this.btn_Common.SubText = "";
			this.btn_Common.TabIndex = 20535;
			this.btn_Common.Text = "COMMON";
			this.btn_Common.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.btn_Common.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.btn_Common.ThemeIndex = 0;
			this.btn_Common.UseBorder = true;
			this.btn_Common.UseClickedEmphasizeTextColor = false;
			this.btn_Common.UseCustomizeClickedColor = true;
			this.btn_Common.UseEdge = true;
			this.btn_Common.UseHoverEmphasizeCustomColor = true;
			this.btn_Common.UseImage = true;
			this.btn_Common.UserHoverEmpahsize = true;
			this.btn_Common.UseSubFont = true;
			this.btn_Common.Click += new System.EventHandler(this.Click_TabButton);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btn_Equipment);
			this.panel1.Controls.Add(this.btn_AllExtend);
			this.panel1.Controls.Add(this.btn_AllReduce);
			this.panel1.Controls.Add(this.btn_ParameterUndo);
			this.panel1.Controls.Add(this.btn_DecideParameterAll);
			this.panel1.Controls.Add(this.btn_Common);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1140, 49);
			this.panel1.TabIndex = 20536;
			// 
			// btn_AllExtend
			// 
			this.btn_AllExtend.BorderWidth = 5;
			this.btn_AllExtend.ButtonClicked = true;
			this.btn_AllExtend.ClickedEmphasizeTextColor = System.Drawing.Color.White;
			this.btn_AllExtend.CustomClickedGradientFirstColor = System.Drawing.Color.Silver;
			this.btn_AllExtend.CustomClickedGradientSecondColor = System.Drawing.Color.Gray;
			this.btn_AllExtend.Description = "";
			this.btn_AllExtend.DisabledColor = System.Drawing.Color.DarkGray;
			this.btn_AllExtend.Dock = System.Windows.Forms.DockStyle.Right;
			this.btn_AllExtend.EdgeRadius = 1;
			this.btn_AllExtend.GradientAngle = 60F;
			this.btn_AllExtend.GradientFirstColor = System.Drawing.Color.WhiteSmoke;
			this.btn_AllExtend.GradientSecondColor = System.Drawing.Color.Gray;
			this.btn_AllExtend.HoverEmphasizeCustomColor = System.Drawing.Color.Firebrick;
			this.btn_AllExtend.ImagePosition = new System.Drawing.Point(37, 25);
			this.btn_AllExtend.ImageSize = new System.Drawing.Point(30, 30);
			this.btn_AllExtend.LoadImage = null;
			this.btn_AllExtend.Location = new System.Drawing.Point(944, 0);
			this.btn_AllExtend.MainFont = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Bold);
			this.btn_AllExtend.MainFontColor = System.Drawing.Color.White;
			this.btn_AllExtend.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
			this.btn_AllExtend.Name = "btn_AllExtend";
			this.btn_AllExtend.Size = new System.Drawing.Size(49, 49);
			this.btn_AllExtend.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.btn_AllExtend.SubFontColor = System.Drawing.Color.Black;
			this.btn_AllExtend.SubText = "";
			this.btn_AllExtend.TabIndex = 20830;
			this.btn_AllExtend.Text = "▼▲";
			this.btn_AllExtend.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.btn_AllExtend.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.btn_AllExtend.ThemeIndex = 0;
			this.btn_AllExtend.UseBorder = true;
			this.btn_AllExtend.UseClickedEmphasizeTextColor = false;
			this.btn_AllExtend.UseCustomizeClickedColor = true;
			this.btn_AllExtend.UseEdge = true;
			this.btn_AllExtend.UseHoverEmphasizeCustomColor = true;
			this.btn_AllExtend.UseImage = true;
			this.btn_AllExtend.UserHoverEmpahsize = true;
			this.btn_AllExtend.UseSubFont = true;
			this.btn_AllExtend.Click += new System.EventHandler(this.Click_AllExtendReduce);
			// 
			// btn_AllReduce
			// 
			this.btn_AllReduce.BorderWidth = 5;
			this.btn_AllReduce.ButtonClicked = true;
			this.btn_AllReduce.ClickedEmphasizeTextColor = System.Drawing.Color.White;
			this.btn_AllReduce.CustomClickedGradientFirstColor = System.Drawing.Color.Silver;
			this.btn_AllReduce.CustomClickedGradientSecondColor = System.Drawing.Color.Gray;
			this.btn_AllReduce.Description = "";
			this.btn_AllReduce.DisabledColor = System.Drawing.Color.DarkGray;
			this.btn_AllReduce.Dock = System.Windows.Forms.DockStyle.Right;
			this.btn_AllReduce.EdgeRadius = 1;
			this.btn_AllReduce.GradientAngle = 60F;
			this.btn_AllReduce.GradientFirstColor = System.Drawing.Color.WhiteSmoke;
			this.btn_AllReduce.GradientSecondColor = System.Drawing.Color.Gray;
			this.btn_AllReduce.HoverEmphasizeCustomColor = System.Drawing.Color.Firebrick;
			this.btn_AllReduce.ImagePosition = new System.Drawing.Point(37, 25);
			this.btn_AllReduce.ImageSize = new System.Drawing.Point(30, 30);
			this.btn_AllReduce.LoadImage = null;
			this.btn_AllReduce.Location = new System.Drawing.Point(993, 0);
			this.btn_AllReduce.MainFont = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Bold);
			this.btn_AllReduce.MainFontColor = System.Drawing.Color.White;
			this.btn_AllReduce.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
			this.btn_AllReduce.Name = "btn_AllReduce";
			this.btn_AllReduce.Size = new System.Drawing.Size(49, 49);
			this.btn_AllReduce.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.btn_AllReduce.SubFontColor = System.Drawing.Color.Black;
			this.btn_AllReduce.SubText = "";
			this.btn_AllReduce.TabIndex = 20829;
			this.btn_AllReduce.Text = "▲";
			this.btn_AllReduce.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.btn_AllReduce.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.btn_AllReduce.ThemeIndex = 0;
			this.btn_AllReduce.UseBorder = true;
			this.btn_AllReduce.UseClickedEmphasizeTextColor = false;
			this.btn_AllReduce.UseCustomizeClickedColor = true;
			this.btn_AllReduce.UseEdge = true;
			this.btn_AllReduce.UseHoverEmphasizeCustomColor = true;
			this.btn_AllReduce.UseImage = true;
			this.btn_AllReduce.UserHoverEmpahsize = true;
			this.btn_AllReduce.UseSubFont = true;
			this.btn_AllReduce.Click += new System.EventHandler(this.Click_AllExtendReduce);
			// 
			// btn_ParameterUndo
			// 
			this.btn_ParameterUndo.BorderWidth = 2;
			this.btn_ParameterUndo.ButtonClicked = false;
			this.btn_ParameterUndo.ClickedEmphasizeTextColor = System.Drawing.Color.White;
			this.btn_ParameterUndo.CustomClickedGradientFirstColor = System.Drawing.Color.BlanchedAlmond;
			this.btn_ParameterUndo.CustomClickedGradientSecondColor = System.Drawing.Color.Gold;
			this.btn_ParameterUndo.Description = "";
			this.btn_ParameterUndo.DisabledColor = System.Drawing.Color.DarkGray;
			this.btn_ParameterUndo.Dock = System.Windows.Forms.DockStyle.Right;
			this.btn_ParameterUndo.EdgeRadius = 5;
			this.btn_ParameterUndo.GradientAngle = 60F;
			this.btn_ParameterUndo.GradientFirstColor = System.Drawing.Color.DeepSkyBlue;
			this.btn_ParameterUndo.GradientSecondColor = System.Drawing.Color.SteelBlue;
			this.btn_ParameterUndo.HoverEmphasizeCustomColor = System.Drawing.Color.Firebrick;
			this.btn_ParameterUndo.ImagePosition = new System.Drawing.Point(8, 7);
			this.btn_ParameterUndo.ImageSize = new System.Drawing.Point(35, 35);
			this.btn_ParameterUndo.LoadImage = global::FrameOfSystem3.Properties.Resources.undo_52px;
			this.btn_ParameterUndo.Location = new System.Drawing.Point(1042, 0);
			this.btn_ParameterUndo.MainFont = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.btn_ParameterUndo.MainFontColor = System.Drawing.Color.White;
			this.btn_ParameterUndo.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
			this.btn_ParameterUndo.Name = "btn_ParameterUndo";
			this.btn_ParameterUndo.Size = new System.Drawing.Size(49, 49);
			this.btn_ParameterUndo.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.btn_ParameterUndo.SubFontColor = System.Drawing.Color.Black;
			this.btn_ParameterUndo.SubText = "";
			this.btn_ParameterUndo.TabIndex = 20822;
			this.btn_ParameterUndo.Tag = "";
			this.btn_ParameterUndo.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.btn_ParameterUndo.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.btn_ParameterUndo.ThemeIndex = 0;
			this.btn_ParameterUndo.UseBorder = true;
			this.btn_ParameterUndo.UseClickedEmphasizeTextColor = false;
			this.btn_ParameterUndo.UseCustomizeClickedColor = true;
			this.btn_ParameterUndo.UseEdge = true;
			this.btn_ParameterUndo.UseHoverEmphasizeCustomColor = true;
			this.btn_ParameterUndo.UseImage = true;
			this.btn_ParameterUndo.UserHoverEmpahsize = true;
			this.btn_ParameterUndo.UseSubFont = false;
			this.btn_ParameterUndo.Click += new System.EventHandler(this.ClickParameterUndo);
			// 
			// btn_DecideParameterAll
			// 
			this.btn_DecideParameterAll.BorderWidth = 2;
			this.btn_DecideParameterAll.ButtonClicked = false;
			this.btn_DecideParameterAll.ClickedEmphasizeTextColor = System.Drawing.Color.White;
			this.btn_DecideParameterAll.CustomClickedGradientFirstColor = System.Drawing.Color.BlanchedAlmond;
			this.btn_DecideParameterAll.CustomClickedGradientSecondColor = System.Drawing.Color.Gold;
			this.btn_DecideParameterAll.Description = "";
			this.btn_DecideParameterAll.DisabledColor = System.Drawing.Color.DarkGray;
			this.btn_DecideParameterAll.Dock = System.Windows.Forms.DockStyle.Right;
			this.btn_DecideParameterAll.EdgeRadius = 5;
			this.btn_DecideParameterAll.GradientAngle = 60F;
			this.btn_DecideParameterAll.GradientFirstColor = System.Drawing.Color.DeepSkyBlue;
			this.btn_DecideParameterAll.GradientSecondColor = System.Drawing.Color.SteelBlue;
			this.btn_DecideParameterAll.HoverEmphasizeCustomColor = System.Drawing.Color.Firebrick;
			this.btn_DecideParameterAll.ImagePosition = new System.Drawing.Point(8, 7);
			this.btn_DecideParameterAll.ImageSize = new System.Drawing.Point(35, 35);
			this.btn_DecideParameterAll.LoadImage = global::FrameOfSystem3.Properties.Resources.save_52px;
			this.btn_DecideParameterAll.Location = new System.Drawing.Point(1091, 0);
			this.btn_DecideParameterAll.MainFont = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.btn_DecideParameterAll.MainFontColor = System.Drawing.Color.White;
			this.btn_DecideParameterAll.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
			this.btn_DecideParameterAll.Name = "btn_DecideParameterAll";
			this.btn_DecideParameterAll.Size = new System.Drawing.Size(49, 49);
			this.btn_DecideParameterAll.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.btn_DecideParameterAll.SubFontColor = System.Drawing.Color.Black;
			this.btn_DecideParameterAll.SubText = "";
			this.btn_DecideParameterAll.TabIndex = 20823;
			this.btn_DecideParameterAll.Tag = "";
			this.btn_DecideParameterAll.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.btn_DecideParameterAll.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.btn_DecideParameterAll.ThemeIndex = 0;
			this.btn_DecideParameterAll.UseBorder = true;
			this.btn_DecideParameterAll.UseClickedEmphasizeTextColor = false;
			this.btn_DecideParameterAll.UseCustomizeClickedColor = true;
			this.btn_DecideParameterAll.UseEdge = true;
			this.btn_DecideParameterAll.UseHoverEmphasizeCustomColor = true;
			this.btn_DecideParameterAll.UseImage = true;
			this.btn_DecideParameterAll.UserHoverEmpahsize = true;
			this.btn_DecideParameterAll.UseSubFont = false;
			this.btn_DecideParameterAll.Click += new System.EventHandler(this.ClickParameterSave);
			// 
			// panelSubView
			// 
			this.panelSubView.AutoScroll = true;
			this.panelSubView.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelSubView.Location = new System.Drawing.Point(0, 50);
			this.panelSubView.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
			this.panelSubView.Name = "panelSubView";
			this.panelSubView.Size = new System.Drawing.Size(1140, 850);
			this.panelSubView.TabIndex = 5;
			// 
			// btn_Equipment
			// 
			this.btn_Equipment.BorderWidth = 5;
			this.btn_Equipment.ButtonClicked = false;
			this.btn_Equipment.ClickedEmphasizeTextColor = System.Drawing.Color.White;
			this.btn_Equipment.CustomClickedGradientFirstColor = System.Drawing.Color.Thistle;
			this.btn_Equipment.CustomClickedGradientSecondColor = System.Drawing.Color.PaleVioletRed;
			this.btn_Equipment.Description = "";
			this.btn_Equipment.DisabledColor = System.Drawing.Color.DarkGray;
			this.btn_Equipment.Dock = System.Windows.Forms.DockStyle.Left;
			this.btn_Equipment.EdgeRadius = 1;
			this.btn_Equipment.GradientAngle = 60F;
			this.btn_Equipment.GradientFirstColor = System.Drawing.Color.WhiteSmoke;
			this.btn_Equipment.GradientSecondColor = System.Drawing.Color.Gray;
			this.btn_Equipment.HoverEmphasizeCustomColor = System.Drawing.Color.Firebrick;
			this.btn_Equipment.ImagePosition = new System.Drawing.Point(37, 25);
			this.btn_Equipment.ImageSize = new System.Drawing.Point(30, 30);
			this.btn_Equipment.LoadImage = null;
			this.btn_Equipment.Location = new System.Drawing.Point(150, 0);
			this.btn_Equipment.MainFont = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.btn_Equipment.MainFontColor = System.Drawing.Color.White;
			this.btn_Equipment.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
			this.btn_Equipment.Name = "btn_Equipment";
			this.btn_Equipment.Size = new System.Drawing.Size(150, 49);
			this.btn_Equipment.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.btn_Equipment.SubFontColor = System.Drawing.Color.Black;
			this.btn_Equipment.SubText = "";
			this.btn_Equipment.TabIndex = 20831;
			this.btn_Equipment.Text = "EQUIPMENT";
			this.btn_Equipment.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.btn_Equipment.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.btn_Equipment.ThemeIndex = 0;
			this.btn_Equipment.UseBorder = true;
			this.btn_Equipment.UseClickedEmphasizeTextColor = false;
			this.btn_Equipment.UseCustomizeClickedColor = true;
			this.btn_Equipment.UseEdge = true;
			this.btn_Equipment.UseHoverEmphasizeCustomColor = true;
			this.btn_Equipment.UseImage = true;
			this.btn_Equipment.UserHoverEmpahsize = true;
			this.btn_Equipment.UseSubFont = true;
			this.btn_Equipment.Click += new System.EventHandler(this.Click_TabButton);
			// 
			// Setup_Options
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panelSubView);
			this.Name = "Setup_Options";
			this.Size = new System.Drawing.Size(1140, 900);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private Sys3Controls.Sys3button btn_Common;
		private System.Windows.Forms.Panel panel1;
		private Sys3Controls.Sys3button btn_ParameterUndo;
		private Sys3Controls.Sys3button btn_DecideParameterAll;
		private System.Windows.Forms.Panel panelSubView;
		private Sys3Controls.Sys3button btn_AllExtend;
		private Sys3Controls.Sys3button btn_AllReduce;
		private Sys3Controls.Sys3button btn_Equipment;

	}
}
