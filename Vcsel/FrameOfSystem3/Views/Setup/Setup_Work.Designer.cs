namespace FrameOfSystem3.Views.Setup
{
    partial class Setup_Work
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
            this.m_btnRun = new Sys3Controls.Sys3button();
            this.m_btnStop = new Sys3Controls.Sys3button();
            this.sys3GroupBox5 = new Sys3Controls.Sys3GroupBox();
            this.sys3button1 = new Sys3Controls.Sys3button();
            this.btn_Reset = new Sys3Controls.Sys3button();
            this.m_lblAlarmCodeMonitor = new Sys3Controls.Sys3Label();
            this.m_lblAlarmCodePort3 = new Sys3Controls.Sys3Label();
            this.m_lblAlarmCodePort2 = new Sys3Controls.Sys3Label();
            this.m_lblAlarmCodePort1 = new Sys3Controls.Sys3Label();
            this.sys3Label2 = new Sys3Controls.Sys3Label();
            this.sys3Label17 = new Sys3Controls.Sys3Label();
            this.sys3Label14 = new Sys3Controls.Sys3Label();
            this.sys3Label13 = new Sys3Controls.Sys3Label();
            this.sys3GroupBox3 = new Sys3Controls.Sys3GroupBox();
            this.btn_ParameterUndo = new Sys3Controls.Sys3button();
            this.btn_DecideParameterAll = new Sys3Controls.Sys3button();
            this.gridViewControl_Laser_Parameter = new FrameOfSystem3.Component.GridViewControl_Parameter();
            this.gridVeiwControl_Laser_Device = new FrameOfSystem3.Component.GridVeiwControl_Device();
            this.gridViewControl_Enable_Parameter = new FrameOfSystem3.Component.GridViewControl_Parameter();
            this.sys3GroupBox1 = new Sys3Controls.Sys3GroupBox();
            this.SuspendLayout();
            // 
            // m_btnRun
            // 
            this.m_btnRun.BorderWidth = 5;
            this.m_btnRun.ButtonClicked = false;
            this.m_btnRun.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.m_btnRun.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.m_btnRun.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.m_btnRun.Description = "";
            this.m_btnRun.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_btnRun.EdgeRadius = 5;
            this.m_btnRun.GradientAngle = 60F;
            this.m_btnRun.GradientFirstColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(230)))), ((int)(((byte)(115)))));
            this.m_btnRun.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(135)))), ((int)(((byte)(20)))));
            this.m_btnRun.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.m_btnRun.ImagePosition = new System.Drawing.Point(37, 25);
            this.m_btnRun.ImageSize = new System.Drawing.Point(30, 30);
            this.m_btnRun.LoadImage = null;
            this.m_btnRun.Location = new System.Drawing.Point(3, 1);
            this.m_btnRun.MainFont = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.m_btnRun.MainFontColor = System.Drawing.Color.White;
            this.m_btnRun.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_btnRun.Name = "m_btnRun";
            this.m_btnRun.Size = new System.Drawing.Size(222, 43);
            this.m_btnRun.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.m_btnRun.SubFontColor = System.Drawing.Color.Black;
            this.m_btnRun.SubText = "";
            this.m_btnRun.TabIndex = 0;
            this.m_btnRun.Tag = "";
            this.m_btnRun.Text = "LASER WORK";
            this.m_btnRun.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_btnRun.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_btnRun.ThemeIndex = 0;
            this.m_btnRun.UseBorder = true;
            this.m_btnRun.UseClickedEmphasizeTextColor = false;
            this.m_btnRun.UseCustomizeClickedColor = false;
            this.m_btnRun.UseEdge = true;
            this.m_btnRun.UseHoverEmphasizeCustomColor = false;
            this.m_btnRun.UseImage = true;
            this.m_btnRun.UserHoverEmpahsize = false;
            this.m_btnRun.UseSubFont = false;
            this.m_btnRun.Click += new System.EventHandler(this.Click_Action);
            // 
            // m_btnStop
            // 
            this.m_btnStop.BorderWidth = 5;
            this.m_btnStop.ButtonClicked = false;
            this.m_btnStop.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.m_btnStop.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.m_btnStop.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.m_btnStop.Description = "";
            this.m_btnStop.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_btnStop.EdgeRadius = 5;
            this.m_btnStop.GradientAngle = 60F;
            this.m_btnStop.GradientFirstColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.m_btnStop.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.m_btnStop.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.m_btnStop.ImagePosition = new System.Drawing.Point(37, 7);
            this.m_btnStop.ImageSize = new System.Drawing.Point(30, 30);
            this.m_btnStop.LoadImage = global::FrameOfSystem3.Properties.Resources.Stop_white;
            this.m_btnStop.Location = new System.Drawing.Point(226, 0);
            this.m_btnStop.MainFont = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.m_btnStop.MainFontColor = System.Drawing.Color.White;
            this.m_btnStop.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_btnStop.Name = "m_btnStop";
            this.m_btnStop.Size = new System.Drawing.Size(222, 43);
            this.m_btnStop.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.m_btnStop.SubFontColor = System.Drawing.Color.Black;
            this.m_btnStop.SubText = "";
            this.m_btnStop.TabIndex = 20849;
            this.m_btnStop.Text = "　STOP";
            this.m_btnStop.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_btnStop.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_btnStop.ThemeIndex = 0;
            this.m_btnStop.UseBorder = true;
            this.m_btnStop.UseClickedEmphasizeTextColor = false;
            this.m_btnStop.UseCustomizeClickedColor = false;
            this.m_btnStop.UseEdge = true;
            this.m_btnStop.UseHoverEmphasizeCustomColor = false;
            this.m_btnStop.UseImage = true;
            this.m_btnStop.UserHoverEmpahsize = false;
            this.m_btnStop.UseSubFont = false;
            this.m_btnStop.Click += new System.EventHandler(this.Click_Stop);
            // 
            // sys3GroupBox5
            // 
            this.sys3GroupBox5.BackGroundColor = System.Drawing.Color.WhiteSmoke;
            this.sys3GroupBox5.EdgeBorderStroke = 2;
            this.sys3GroupBox5.EdgeRadius = 2;
            this.sys3GroupBox5.LabelFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3GroupBox5.LabelGradientColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.sys3GroupBox5.LabelGradientColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.sys3GroupBox5.LabelHeight = 30;
            this.sys3GroupBox5.LabelTextColor = System.Drawing.Color.Black;
            this.sys3GroupBox5.Location = new System.Drawing.Point(1, 47);
            this.sys3GroupBox5.Name = "sys3GroupBox5";
            this.sys3GroupBox5.Size = new System.Drawing.Size(1137, 423);
            this.sys3GroupBox5.TabIndex = 9623;
            this.sys3GroupBox5.Text = "LASER_1";
            this.sys3GroupBox5.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3GroupBox5.ThemeIndex = 0;
            this.sys3GroupBox5.UseLabelBorder = true;
            // 
            // sys3button1
            // 
            this.sys3button1.BorderWidth = 3;
            this.sys3button1.ButtonClicked = false;
            this.sys3button1.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.sys3button1.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.sys3button1.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.sys3button1.Description = "";
            this.sys3button1.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3button1.EdgeRadius = 1;
            this.sys3button1.GradientAngle = 90F;
            this.sys3button1.GradientFirstColor = System.Drawing.Color.White;
            this.sys3button1.GradientSecondColor = System.Drawing.Color.Silver;
            this.sys3button1.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.sys3button1.ImagePosition = new System.Drawing.Point(7, 7);
            this.sys3button1.ImageSize = new System.Drawing.Point(30, 30);
            this.sys3button1.LoadImage = global::FrameOfSystem3.Properties.Resources.CONFIG_ADD3;
            this.sys3button1.Location = new System.Drawing.Point(997, 422);
            this.sys3button1.MainFont = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.sys3button1.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
            this.sys3button1.Name = "sys3button1";
            this.sys3button1.Size = new System.Drawing.Size(131, 40);
            this.sys3button1.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.sys3button1.SubFontColor = System.Drawing.Color.DarkBlue;
            this.sys3button1.SubText = "STATUS";
            this.sys3button1.TabIndex = 1;
            this.sys3button1.Text = "ALL EMO";
            this.sys3button1.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3button1.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.sys3button1.ThemeIndex = 0;
            this.sys3button1.UseBorder = false;
            this.sys3button1.UseClickedEmphasizeTextColor = false;
            this.sys3button1.UseCustomizeClickedColor = false;
            this.sys3button1.UseEdge = false;
            this.sys3button1.UseHoverEmphasizeCustomColor = false;
            this.sys3button1.UseImage = false;
            this.sys3button1.UserHoverEmpahsize = true;
            this.sys3button1.UseSubFont = false;
            this.sys3button1.Click += new System.EventHandler(this.Cick_All_IO);
            // 
            // btn_Reset
            // 
            this.btn_Reset.BorderWidth = 3;
            this.btn_Reset.ButtonClicked = false;
            this.btn_Reset.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.btn_Reset.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.btn_Reset.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.btn_Reset.Description = "";
            this.btn_Reset.DisabledColor = System.Drawing.Color.DarkGray;
            this.btn_Reset.EdgeRadius = 1;
            this.btn_Reset.GradientAngle = 90F;
            this.btn_Reset.GradientFirstColor = System.Drawing.Color.White;
            this.btn_Reset.GradientSecondColor = System.Drawing.Color.Silver;
            this.btn_Reset.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.btn_Reset.ImagePosition = new System.Drawing.Point(7, 7);
            this.btn_Reset.ImageSize = new System.Drawing.Point(30, 30);
            this.btn_Reset.LoadImage = global::FrameOfSystem3.Properties.Resources.CONFIG_ADD3;
            this.btn_Reset.Location = new System.Drawing.Point(863, 422);
            this.btn_Reset.MainFont = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.btn_Reset.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(131, 40);
            this.btn_Reset.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.btn_Reset.SubFontColor = System.Drawing.Color.DarkBlue;
            this.btn_Reset.SubText = "STATUS";
            this.btn_Reset.TabIndex = 0;
            this.btn_Reset.Text = "ALL RESET";
            this.btn_Reset.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.btn_Reset.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.btn_Reset.ThemeIndex = 0;
            this.btn_Reset.UseBorder = false;
            this.btn_Reset.UseClickedEmphasizeTextColor = false;
            this.btn_Reset.UseCustomizeClickedColor = false;
            this.btn_Reset.UseEdge = false;
            this.btn_Reset.UseHoverEmphasizeCustomColor = false;
            this.btn_Reset.UseImage = false;
            this.btn_Reset.UserHoverEmpahsize = true;
            this.btn_Reset.UseSubFont = false;
            this.btn_Reset.Click += new System.EventHandler(this.Cick_All_IO);
            // 
            // m_lblAlarmCodeMonitor
            // 
            this.m_lblAlarmCodeMonitor.BackGroundColor = System.Drawing.Color.DimGray;
            this.m_lblAlarmCodeMonitor.BorderStroke = 2;
            this.m_lblAlarmCodeMonitor.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblAlarmCodeMonitor.Description = "";
            this.m_lblAlarmCodeMonitor.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblAlarmCodeMonitor.EdgeRadius = 1;
            this.m_lblAlarmCodeMonitor.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_lblAlarmCodeMonitor.ImageSize = new System.Drawing.Point(0, 0);
            this.m_lblAlarmCodeMonitor.LoadImage = null;
            this.m_lblAlarmCodeMonitor.Location = new System.Drawing.Point(985, 384);
            this.m_lblAlarmCodeMonitor.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_lblAlarmCodeMonitor.MainFontColor = System.Drawing.Color.White;
            this.m_lblAlarmCodeMonitor.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_lblAlarmCodeMonitor.Name = "m_lblAlarmCodeMonitor";
            this.m_lblAlarmCodeMonitor.Size = new System.Drawing.Size(143, 37);
            this.m_lblAlarmCodeMonitor.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblAlarmCodeMonitor.SubFontColor = System.Drawing.Color.Gray;
            this.m_lblAlarmCodeMonitor.SubText = "";
            this.m_lblAlarmCodeMonitor.TabIndex = 20857;
            this.m_lblAlarmCodeMonitor.Tag = "";
            this.m_lblAlarmCodeMonitor.Text = "NONE";
            this.m_lblAlarmCodeMonitor.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.m_lblAlarmCodeMonitor.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblAlarmCodeMonitor.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblAlarmCodeMonitor.ThemeIndex = 0;
            this.m_lblAlarmCodeMonitor.UnitAreaRate = 30;
            this.m_lblAlarmCodeMonitor.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblAlarmCodeMonitor.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblAlarmCodeMonitor.UnitPositionVertical = false;
            this.m_lblAlarmCodeMonitor.UnitText = "W";
            this.m_lblAlarmCodeMonitor.UseBorder = true;
            this.m_lblAlarmCodeMonitor.UseEdgeRadius = false;
            this.m_lblAlarmCodeMonitor.UseImage = false;
            this.m_lblAlarmCodeMonitor.UseSubFont = true;
            this.m_lblAlarmCodeMonitor.UseUnitFont = false;
            // 
            // m_lblAlarmCodePort3
            // 
            this.m_lblAlarmCodePort3.BackGroundColor = System.Drawing.Color.DimGray;
            this.m_lblAlarmCodePort3.BorderStroke = 2;
            this.m_lblAlarmCodePort3.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblAlarmCodePort3.Description = "";
            this.m_lblAlarmCodePort3.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblAlarmCodePort3.EdgeRadius = 1;
            this.m_lblAlarmCodePort3.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_lblAlarmCodePort3.ImageSize = new System.Drawing.Point(0, 0);
            this.m_lblAlarmCodePort3.LoadImage = null;
            this.m_lblAlarmCodePort3.Location = new System.Drawing.Point(749, 384);
            this.m_lblAlarmCodePort3.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_lblAlarmCodePort3.MainFontColor = System.Drawing.Color.White;
            this.m_lblAlarmCodePort3.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_lblAlarmCodePort3.Name = "m_lblAlarmCodePort3";
            this.m_lblAlarmCodePort3.Size = new System.Drawing.Size(143, 37);
            this.m_lblAlarmCodePort3.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblAlarmCodePort3.SubFontColor = System.Drawing.Color.Gray;
            this.m_lblAlarmCodePort3.SubText = "";
            this.m_lblAlarmCodePort3.TabIndex = 20858;
            this.m_lblAlarmCodePort3.Tag = "";
            this.m_lblAlarmCodePort3.Text = "NONE";
            this.m_lblAlarmCodePort3.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.m_lblAlarmCodePort3.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblAlarmCodePort3.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblAlarmCodePort3.ThemeIndex = 0;
            this.m_lblAlarmCodePort3.UnitAreaRate = 30;
            this.m_lblAlarmCodePort3.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblAlarmCodePort3.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblAlarmCodePort3.UnitPositionVertical = false;
            this.m_lblAlarmCodePort3.UnitText = "W";
            this.m_lblAlarmCodePort3.UseBorder = true;
            this.m_lblAlarmCodePort3.UseEdgeRadius = false;
            this.m_lblAlarmCodePort3.UseImage = false;
            this.m_lblAlarmCodePort3.UseSubFont = true;
            this.m_lblAlarmCodePort3.UseUnitFont = false;
            // 
            // m_lblAlarmCodePort2
            // 
            this.m_lblAlarmCodePort2.BackGroundColor = System.Drawing.Color.DimGray;
            this.m_lblAlarmCodePort2.BorderStroke = 2;
            this.m_lblAlarmCodePort2.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblAlarmCodePort2.Description = "";
            this.m_lblAlarmCodePort2.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblAlarmCodePort2.EdgeRadius = 1;
            this.m_lblAlarmCodePort2.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_lblAlarmCodePort2.ImageSize = new System.Drawing.Point(0, 0);
            this.m_lblAlarmCodePort2.LoadImage = null;
            this.m_lblAlarmCodePort2.Location = new System.Drawing.Point(985, 346);
            this.m_lblAlarmCodePort2.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_lblAlarmCodePort2.MainFontColor = System.Drawing.Color.White;
            this.m_lblAlarmCodePort2.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_lblAlarmCodePort2.Name = "m_lblAlarmCodePort2";
            this.m_lblAlarmCodePort2.Size = new System.Drawing.Size(143, 37);
            this.m_lblAlarmCodePort2.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblAlarmCodePort2.SubFontColor = System.Drawing.Color.Gray;
            this.m_lblAlarmCodePort2.SubText = "";
            this.m_lblAlarmCodePort2.TabIndex = 20859;
            this.m_lblAlarmCodePort2.Tag = "";
            this.m_lblAlarmCodePort2.Text = "NONE";
            this.m_lblAlarmCodePort2.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.m_lblAlarmCodePort2.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblAlarmCodePort2.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblAlarmCodePort2.ThemeIndex = 0;
            this.m_lblAlarmCodePort2.UnitAreaRate = 30;
            this.m_lblAlarmCodePort2.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblAlarmCodePort2.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblAlarmCodePort2.UnitPositionVertical = false;
            this.m_lblAlarmCodePort2.UnitText = "W";
            this.m_lblAlarmCodePort2.UseBorder = true;
            this.m_lblAlarmCodePort2.UseEdgeRadius = false;
            this.m_lblAlarmCodePort2.UseImage = false;
            this.m_lblAlarmCodePort2.UseSubFont = true;
            this.m_lblAlarmCodePort2.UseUnitFont = false;
            // 
            // m_lblAlarmCodePort1
            // 
            this.m_lblAlarmCodePort1.BackGroundColor = System.Drawing.Color.DimGray;
            this.m_lblAlarmCodePort1.BorderStroke = 2;
            this.m_lblAlarmCodePort1.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblAlarmCodePort1.Description = "";
            this.m_lblAlarmCodePort1.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblAlarmCodePort1.EdgeRadius = 1;
            this.m_lblAlarmCodePort1.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_lblAlarmCodePort1.ImageSize = new System.Drawing.Point(0, 0);
            this.m_lblAlarmCodePort1.LoadImage = null;
            this.m_lblAlarmCodePort1.Location = new System.Drawing.Point(749, 346);
            this.m_lblAlarmCodePort1.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_lblAlarmCodePort1.MainFontColor = System.Drawing.Color.White;
            this.m_lblAlarmCodePort1.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_lblAlarmCodePort1.Name = "m_lblAlarmCodePort1";
            this.m_lblAlarmCodePort1.Size = new System.Drawing.Size(143, 37);
            this.m_lblAlarmCodePort1.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblAlarmCodePort1.SubFontColor = System.Drawing.Color.Gray;
            this.m_lblAlarmCodePort1.SubText = "";
            this.m_lblAlarmCodePort1.TabIndex = 20860;
            this.m_lblAlarmCodePort1.Tag = "";
            this.m_lblAlarmCodePort1.Text = "NONE";
            this.m_lblAlarmCodePort1.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.m_lblAlarmCodePort1.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblAlarmCodePort1.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblAlarmCodePort1.ThemeIndex = 0;
            this.m_lblAlarmCodePort1.UnitAreaRate = 30;
            this.m_lblAlarmCodePort1.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblAlarmCodePort1.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblAlarmCodePort1.UnitPositionVertical = false;
            this.m_lblAlarmCodePort1.UnitText = "W";
            this.m_lblAlarmCodePort1.UseBorder = true;
            this.m_lblAlarmCodePort1.UseEdgeRadius = false;
            this.m_lblAlarmCodePort1.UseImage = false;
            this.m_lblAlarmCodePort1.UseSubFont = true;
            this.m_lblAlarmCodePort1.UseUnitFont = false;
            // 
            // sys3Label2
            // 
            this.sys3Label2.BackGroundColor = System.Drawing.Color.DarkGray;
            this.sys3Label2.BorderStroke = 2;
            this.sys3Label2.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.sys3Label2.Description = "";
            this.sys3Label2.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3Label2.EdgeRadius = 1;
            this.sys3Label2.ImagePosition = new System.Drawing.Point(0, 0);
            this.sys3Label2.ImageSize = new System.Drawing.Point(0, 0);
            this.sys3Label2.LoadImage = null;
            this.sys3Label2.Location = new System.Drawing.Point(893, 384);
            this.sys3Label2.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label2.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label2.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label2.Name = "sys3Label2";
            this.sys3Label2.Size = new System.Drawing.Size(91, 37);
            this.sys3Label2.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label2.SubFontColor = System.Drawing.Color.DarkRed;
            this.sys3Label2.SubText = "";
            this.sys3Label2.TabIndex = 20853;
            this.sys3Label2.Tag = "";
            this.sys3Label2.Text = "MONITOR";
            this.sys3Label2.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3Label2.TextAlignSub = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
            this.sys3Label2.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label2.ThemeIndex = 0;
            this.sys3Label2.UnitAreaRate = 40;
            this.sys3Label2.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label2.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sys3Label2.UnitPositionVertical = false;
            this.sys3Label2.UnitText = "";
            this.sys3Label2.UseBorder = true;
            this.sys3Label2.UseEdgeRadius = false;
            this.sys3Label2.UseImage = false;
            this.sys3Label2.UseSubFont = true;
            this.sys3Label2.UseUnitFont = false;
            // 
            // sys3Label17
            // 
            this.sys3Label17.BackGroundColor = System.Drawing.Color.DarkGray;
            this.sys3Label17.BorderStroke = 2;
            this.sys3Label17.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.sys3Label17.Description = "";
            this.sys3Label17.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3Label17.EdgeRadius = 1;
            this.sys3Label17.ImagePosition = new System.Drawing.Point(0, 0);
            this.sys3Label17.ImageSize = new System.Drawing.Point(0, 0);
            this.sys3Label17.LoadImage = null;
            this.sys3Label17.Location = new System.Drawing.Point(657, 384);
            this.sys3Label17.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label17.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label17.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label17.Name = "sys3Label17";
            this.sys3Label17.Size = new System.Drawing.Size(91, 37);
            this.sys3Label17.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label17.SubFontColor = System.Drawing.Color.DarkRed;
            this.sys3Label17.SubText = "";
            this.sys3Label17.TabIndex = 20854;
            this.sys3Label17.Tag = "";
            this.sys3Label17.Text = "PORT 3";
            this.sys3Label17.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3Label17.TextAlignSub = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
            this.sys3Label17.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label17.ThemeIndex = 0;
            this.sys3Label17.UnitAreaRate = 40;
            this.sys3Label17.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label17.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sys3Label17.UnitPositionVertical = false;
            this.sys3Label17.UnitText = "";
            this.sys3Label17.UseBorder = true;
            this.sys3Label17.UseEdgeRadius = false;
            this.sys3Label17.UseImage = false;
            this.sys3Label17.UseSubFont = true;
            this.sys3Label17.UseUnitFont = false;
            // 
            // sys3Label14
            // 
            this.sys3Label14.BackGroundColor = System.Drawing.Color.DarkGray;
            this.sys3Label14.BorderStroke = 2;
            this.sys3Label14.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.sys3Label14.Description = "";
            this.sys3Label14.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3Label14.EdgeRadius = 1;
            this.sys3Label14.ImagePosition = new System.Drawing.Point(0, 0);
            this.sys3Label14.ImageSize = new System.Drawing.Point(0, 0);
            this.sys3Label14.LoadImage = null;
            this.sys3Label14.Location = new System.Drawing.Point(893, 346);
            this.sys3Label14.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label14.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label14.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label14.Name = "sys3Label14";
            this.sys3Label14.Size = new System.Drawing.Size(91, 37);
            this.sys3Label14.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label14.SubFontColor = System.Drawing.Color.DarkRed;
            this.sys3Label14.SubText = "";
            this.sys3Label14.TabIndex = 20855;
            this.sys3Label14.Tag = "";
            this.sys3Label14.Text = "PORT 2";
            this.sys3Label14.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3Label14.TextAlignSub = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
            this.sys3Label14.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label14.ThemeIndex = 0;
            this.sys3Label14.UnitAreaRate = 40;
            this.sys3Label14.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label14.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sys3Label14.UnitPositionVertical = false;
            this.sys3Label14.UnitText = "";
            this.sys3Label14.UseBorder = true;
            this.sys3Label14.UseEdgeRadius = false;
            this.sys3Label14.UseImage = false;
            this.sys3Label14.UseSubFont = true;
            this.sys3Label14.UseUnitFont = false;
            // 
            // sys3Label13
            // 
            this.sys3Label13.BackGroundColor = System.Drawing.Color.DarkGray;
            this.sys3Label13.BorderStroke = 2;
            this.sys3Label13.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.sys3Label13.Description = "";
            this.sys3Label13.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3Label13.EdgeRadius = 1;
            this.sys3Label13.ImagePosition = new System.Drawing.Point(0, 0);
            this.sys3Label13.ImageSize = new System.Drawing.Point(0, 0);
            this.sys3Label13.LoadImage = null;
            this.sys3Label13.Location = new System.Drawing.Point(657, 346);
            this.sys3Label13.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label13.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label13.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label13.Name = "sys3Label13";
            this.sys3Label13.Size = new System.Drawing.Size(91, 37);
            this.sys3Label13.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label13.SubFontColor = System.Drawing.Color.DarkRed;
            this.sys3Label13.SubText = "";
            this.sys3Label13.TabIndex = 20856;
            this.sys3Label13.Tag = "";
            this.sys3Label13.Text = "PORT 1";
            this.sys3Label13.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3Label13.TextAlignSub = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
            this.sys3Label13.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label13.ThemeIndex = 0;
            this.sys3Label13.UnitAreaRate = 40;
            this.sys3Label13.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label13.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sys3Label13.UnitPositionVertical = false;
            this.sys3Label13.UnitText = "";
            this.sys3Label13.UseBorder = true;
            this.sys3Label13.UseEdgeRadius = false;
            this.sys3Label13.UseImage = false;
            this.sys3Label13.UseSubFont = true;
            this.sys3Label13.UseUnitFont = false;
            // 
            // sys3GroupBox3
            // 
            this.sys3GroupBox3.BackGroundColor = System.Drawing.Color.WhiteSmoke;
            this.sys3GroupBox3.EdgeBorderStroke = 2;
            this.sys3GroupBox3.EdgeRadius = 2;
            this.sys3GroupBox3.LabelFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3GroupBox3.LabelGradientColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.sys3GroupBox3.LabelGradientColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.sys3GroupBox3.LabelHeight = 30;
            this.sys3GroupBox3.LabelTextColor = System.Drawing.Color.Black;
            this.sys3GroupBox3.Location = new System.Drawing.Point(648, 312);
            this.sys3GroupBox3.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3GroupBox3.Name = "sys3GroupBox3";
            this.sys3GroupBox3.Size = new System.Drawing.Size(488, 156);
            this.sys3GroupBox3.TabIndex = 20852;
            this.sys3GroupBox3.Tag = "";
            this.sys3GroupBox3.Text = "SOURCE ALARM CODE";
            this.sys3GroupBox3.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3GroupBox3.ThemeIndex = 0;
            this.sys3GroupBox3.UseLabelBorder = true;
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
            this.btn_ParameterUndo.EdgeRadius = 5;
            this.btn_ParameterUndo.GradientAngle = 60F;
            this.btn_ParameterUndo.GradientFirstColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_ParameterUndo.GradientSecondColor = System.Drawing.Color.SteelBlue;
            this.btn_ParameterUndo.HoverEmphasizeCustomColor = System.Drawing.Color.Firebrick;
            this.btn_ParameterUndo.ImagePosition = new System.Drawing.Point(8, 7);
            this.btn_ParameterUndo.ImageSize = new System.Drawing.Point(35, 30);
            this.btn_ParameterUndo.LoadImage = global::FrameOfSystem3.Properties.Resources.undo_52px;
            this.btn_ParameterUndo.Location = new System.Drawing.Point(1041, 1);
            this.btn_ParameterUndo.MainFont = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_ParameterUndo.MainFontColor = System.Drawing.Color.White;
            this.btn_ParameterUndo.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.btn_ParameterUndo.Name = "btn_ParameterUndo";
            this.btn_ParameterUndo.Size = new System.Drawing.Size(49, 43);
            this.btn_ParameterUndo.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.btn_ParameterUndo.SubFontColor = System.Drawing.Color.Black;
            this.btn_ParameterUndo.SubText = "";
            this.btn_ParameterUndo.TabIndex = 20863;
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
            this.btn_DecideParameterAll.EdgeRadius = 5;
            this.btn_DecideParameterAll.GradientAngle = 60F;
            this.btn_DecideParameterAll.GradientFirstColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_DecideParameterAll.GradientSecondColor = System.Drawing.Color.SteelBlue;
            this.btn_DecideParameterAll.HoverEmphasizeCustomColor = System.Drawing.Color.Firebrick;
            this.btn_DecideParameterAll.ImagePosition = new System.Drawing.Point(8, 7);
            this.btn_DecideParameterAll.ImageSize = new System.Drawing.Point(35, 30);
            this.btn_DecideParameterAll.LoadImage = global::FrameOfSystem3.Properties.Resources.save_52px;
            this.btn_DecideParameterAll.Location = new System.Drawing.Point(1090, 1);
            this.btn_DecideParameterAll.MainFont = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_DecideParameterAll.MainFontColor = System.Drawing.Color.White;
            this.btn_DecideParameterAll.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.btn_DecideParameterAll.Name = "btn_DecideParameterAll";
            this.btn_DecideParameterAll.Size = new System.Drawing.Size(49, 43);
            this.btn_DecideParameterAll.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.btn_DecideParameterAll.SubFontColor = System.Drawing.Color.Black;
            this.btn_DecideParameterAll.SubText = "";
            this.btn_DecideParameterAll.TabIndex = 20864;
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
            // gridViewControl_Laser_Parameter
            // 
            this.gridViewControl_Laser_Parameter.Control_Enable = true;
            this.gridViewControl_Laser_Parameter.controlCollection = null;
            this.gridViewControl_Laser_Parameter.Location = new System.Drawing.Point(3, 132);
            this.gridViewControl_Laser_Parameter.Name = "gridViewControl_Laser_Parameter";
            this.gridViewControl_Laser_Parameter.Size = new System.Drawing.Size(642, 78);
            this.gridViewControl_Laser_Parameter.TabIndex = 20845;
            // 
            // gridVeiwControl_Laser_Device
            // 
            this.gridVeiwControl_Laser_Device.Control_Enable = true;
            this.gridVeiwControl_Laser_Device.controlCollection = null;
            this.gridVeiwControl_Laser_Device.Location = new System.Drawing.Point(646, 132);
            this.gridVeiwControl_Laser_Device.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.gridVeiwControl_Laser_Device.Name = "gridVeiwControl_Laser_Device";
            this.gridVeiwControl_Laser_Device.Size = new System.Drawing.Size(490, 178);
            this.gridVeiwControl_Laser_Device.TabIndex = 20844;
            // 
            // gridViewControl_Enable_Parameter
            // 
            this.gridViewControl_Enable_Parameter.Control_Enable = true;
            this.gridViewControl_Enable_Parameter.controlCollection = null;
            this.gridViewControl_Enable_Parameter.Location = new System.Drawing.Point(3, 78);
            this.gridViewControl_Enable_Parameter.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.gridViewControl_Enable_Parameter.Name = "gridViewControl_Enable_Parameter";
            this.gridViewControl_Enable_Parameter.Size = new System.Drawing.Size(1133, 53);
            this.gridViewControl_Enable_Parameter.TabIndex = 20843;
            // 
            // sys3GroupBox1
            // 
            this.sys3GroupBox1.BackGroundColor = System.Drawing.Color.WhiteSmoke;
            this.sys3GroupBox1.EdgeBorderStroke = 2;
            this.sys3GroupBox1.EdgeRadius = 2;
            this.sys3GroupBox1.LabelFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3GroupBox1.LabelGradientColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.sys3GroupBox1.LabelGradientColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.sys3GroupBox1.LabelHeight = 30;
            this.sys3GroupBox1.LabelTextColor = System.Drawing.Color.Black;
            this.sys3GroupBox1.Location = new System.Drawing.Point(1, 474);
            this.sys3GroupBox1.Name = "sys3GroupBox1";
            this.sys3GroupBox1.Size = new System.Drawing.Size(1137, 423);
            this.sys3GroupBox1.TabIndex = 20865;
            this.sys3GroupBox1.Text = "LASER_2";
            this.sys3GroupBox1.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3GroupBox1.ThemeIndex = 0;
            this.sys3GroupBox1.UseLabelBorder = true;
            // 
            // Setup_Work
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.sys3GroupBox1);
            this.Controls.Add(this.btn_ParameterUndo);
            this.Controls.Add(this.btn_DecideParameterAll);
            this.Controls.Add(this.sys3button1);
            this.Controls.Add(this.btn_Reset);
            this.Controls.Add(this.m_lblAlarmCodeMonitor);
            this.Controls.Add(this.m_lblAlarmCodePort3);
            this.Controls.Add(this.m_lblAlarmCodePort2);
            this.Controls.Add(this.m_lblAlarmCodePort1);
            this.Controls.Add(this.sys3Label2);
            this.Controls.Add(this.sys3Label17);
            this.Controls.Add(this.sys3Label14);
            this.Controls.Add(this.sys3Label13);
            this.Controls.Add(this.sys3GroupBox3);
            this.Controls.Add(this.m_btnStop);
            this.Controls.Add(this.m_btnRun);
            this.Controls.Add(this.gridViewControl_Laser_Parameter);
            this.Controls.Add(this.gridVeiwControl_Laser_Device);
            this.Controls.Add(this.gridViewControl_Enable_Parameter);
            this.Controls.Add(this.sys3GroupBox5);
            this.Name = "Setup_Work";
            this.Size = new System.Drawing.Size(1140, 900);
            this.ResumeLayout(false);

		}
		#endregion
        private Component.GridVeiwControl_Device gridVeiwControl_Laser_Device;
        private Component.GridViewControl_Parameter gridViewControl_Enable_Parameter;
        private Component.GridViewControl_Parameter gridViewControl_Laser_Parameter;
        private Sys3Controls.Sys3button m_btnStop;
        private Sys3Controls.Sys3button m_btnRun;
        private Sys3Controls.Sys3GroupBox sys3GroupBox5;
        private Sys3Controls.Sys3button sys3button1;
        private Sys3Controls.Sys3button btn_Reset;
        private Sys3Controls.Sys3Label m_lblAlarmCodeMonitor;
        private Sys3Controls.Sys3Label m_lblAlarmCodePort3;
        private Sys3Controls.Sys3Label m_lblAlarmCodePort2;
        private Sys3Controls.Sys3Label m_lblAlarmCodePort1;
        private Sys3Controls.Sys3Label sys3Label2;
        private Sys3Controls.Sys3Label sys3Label17;
        private Sys3Controls.Sys3Label sys3Label14;
        private Sys3Controls.Sys3Label sys3Label13;
        private Sys3Controls.Sys3GroupBox sys3GroupBox3;
        private Sys3Controls.Sys3button btn_ParameterUndo;
        private Sys3Controls.Sys3button btn_DecideParameterAll;
        private Sys3Controls.Sys3GroupBox sys3GroupBox1;
    }
}
