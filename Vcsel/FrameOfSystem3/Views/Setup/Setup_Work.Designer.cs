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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.sys3GroupBox2 = new Sys3Controls.Sys3GroupBox();
            this.sys3button2 = new Sys3Controls.Sys3button();
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
            this.dataGridView_Heater = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sys3button3 = new Sys3Controls.Sys3button();
            this.sys3GroupBox1 = new Sys3Controls.Sys3GroupBox();
            this.sys3Label1 = new Sys3Controls.Sys3Label();
            this.m_lblID = new Sys3Controls.Sys3Label();
            this.sys3Label4 = new Sys3Controls.Sys3Label();
            this.m_lblWorkStatus = new Sys3Controls.Sys3Label();
            this.m_lblWorkStatus_Color = new Sys3Controls.Sys3Label();
            this.sys3Label3 = new Sys3Controls.Sys3Label();
            this.m_lblPreHeatingTime = new Sys3Controls.Sys3Label();
            this.btn_ParameterUndo = new Sys3Controls.Sys3button();
            this.btn_DecideParameterAll = new Sys3Controls.Sys3button();
            this.sys3Label5 = new Sys3Controls.Sys3Label();
            this.m_lblChPower = new Sys3Controls.Sys3Label();
            this.sys3Label7 = new Sys3Controls.Sys3Label();
            this.m_lblSidePower = new Sys3Controls.Sys3Label();
            this.gridViewControl_Head_Position_Parameter = new FrameOfSystem3.Component.GridViewControl_2Axis_Position_Parameter();
            this.gridViewControl_Laser_Parameter = new FrameOfSystem3.Component.GridViewControl_Parameter();
            this.gridVeiwControl_Laser_Device = new FrameOfSystem3.Component.GridVeiwControl_Device();
            this.gridViewControl_Enable_Parameter = new FrameOfSystem3.Component.GridViewControl_Parameter();
            this.gridVeiwControl_Head_Device = new FrameOfSystem3.Component.GridVeiwControl_Device();
            this.gridVeiwControl_Block_Device = new FrameOfSystem3.Component.GridVeiwControl_Device();
            this.gridViewControl_Block_Position_Parameter = new FrameOfSystem3.Component.GridViewControl_Position_Parameter();
            this.gridViewControl_WorkStatus_Parameter = new FrameOfSystem3.Component.GridViewControl_Parameter();
            this.gridViewControl_Laser_Option_Parameter = new FrameOfSystem3.Component.GridViewControl_Parameter();
            this.gridViewControl_Block_Parameter = new FrameOfSystem3.Component.GridViewControl_Parameter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Heater)).BeginInit();
            this.SuspendLayout();
            // 
            // sys3GroupBox2
            // 
            this.sys3GroupBox2.BackGroundColor = System.Drawing.Color.WhiteSmoke;
            this.sys3GroupBox2.EdgeBorderStroke = 2;
            this.sys3GroupBox2.EdgeRadius = 2;
            this.sys3GroupBox2.LabelFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3GroupBox2.LabelGradientColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.sys3GroupBox2.LabelGradientColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.sys3GroupBox2.LabelHeight = 30;
            this.sys3GroupBox2.LabelTextColor = System.Drawing.Color.Black;
            this.sys3GroupBox2.Location = new System.Drawing.Point(1, 637);
            this.sys3GroupBox2.Name = "sys3GroupBox2";
            this.sys3GroupBox2.Size = new System.Drawing.Size(1135, 194);
            this.sys3GroupBox2.TabIndex = 9623;
            this.sys3GroupBox2.Text = "BLOCK";
            this.sys3GroupBox2.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3GroupBox2.ThemeIndex = 0;
            this.sys3GroupBox2.UseLabelBorder = true;
            // 
            // sys3button2
            // 
            this.sys3button2.BorderWidth = 5;
            this.sys3button2.ButtonClicked = false;
            this.sys3button2.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.sys3button2.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.sys3button2.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.sys3button2.Description = "";
            this.sys3button2.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3button2.EdgeRadius = 5;
            this.sys3button2.GradientAngle = 60F;
            this.sys3button2.GradientFirstColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(230)))), ((int)(((byte)(115)))));
            this.sys3button2.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(135)))), ((int)(((byte)(20)))));
            this.sys3button2.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.sys3button2.ImagePosition = new System.Drawing.Point(37, 25);
            this.sys3button2.ImageSize = new System.Drawing.Point(30, 30);
            this.sys3button2.LoadImage = null;
            this.sys3button2.Location = new System.Drawing.Point(223, 835);
            this.sys3button2.MainFont = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sys3button2.MainFontColor = System.Drawing.Color.White;
            this.sys3button2.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3button2.Name = "sys3button2";
            this.sys3button2.Size = new System.Drawing.Size(222, 63);
            this.sys3button2.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.sys3button2.SubFontColor = System.Drawing.Color.Black;
            this.sys3button2.SubText = "";
            this.sys3button2.TabIndex = 1;
            this.sys3button2.Tag = "";
            this.sys3button2.Text = "MANUAL LOAD";
            this.sys3button2.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3button2.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3button2.ThemeIndex = 0;
            this.sys3button2.UseBorder = true;
            this.sys3button2.UseClickedEmphasizeTextColor = false;
            this.sys3button2.UseCustomizeClickedColor = false;
            this.sys3button2.UseEdge = true;
            this.sys3button2.UseHoverEmphasizeCustomColor = false;
            this.sys3button2.UseImage = true;
            this.sys3button2.UserHoverEmpahsize = false;
            this.sys3button2.UseSubFont = false;
            this.sys3button2.Click += new System.EventHandler(this.Click_Action);
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
            this.m_btnRun.Location = new System.Drawing.Point(0, 835);
            this.m_btnRun.MainFont = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.m_btnRun.MainFontColor = System.Drawing.Color.White;
            this.m_btnRun.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_btnRun.Name = "m_btnRun";
            this.m_btnRun.Size = new System.Drawing.Size(222, 63);
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
            this.m_btnStop.ImagePosition = new System.Drawing.Point(37, 16);
            this.m_btnStop.ImageSize = new System.Drawing.Point(30, 30);
            this.m_btnStop.LoadImage = global::FrameOfSystem3.Properties.Resources.Stop_white;
            this.m_btnStop.Location = new System.Drawing.Point(911, 835);
            this.m_btnStop.MainFont = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.m_btnStop.MainFontColor = System.Drawing.Color.White;
            this.m_btnStop.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_btnStop.Name = "m_btnStop";
            this.m_btnStop.Size = new System.Drawing.Size(222, 63);
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
            this.sys3GroupBox5.Location = new System.Drawing.Point(1, 135);
            this.sys3GroupBox5.Name = "sys3GroupBox5";
            this.sys3GroupBox5.Size = new System.Drawing.Size(1137, 501);
            this.sys3GroupBox5.TabIndex = 9623;
            this.sys3GroupBox5.Text = "LASER";
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
            this.sys3button1.Location = new System.Drawing.Point(997, 510);
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
            this.btn_Reset.Location = new System.Drawing.Point(863, 510);
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
            this.m_lblAlarmCodeMonitor.Location = new System.Drawing.Point(985, 472);
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
            this.m_lblAlarmCodePort3.Location = new System.Drawing.Point(749, 472);
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
            this.m_lblAlarmCodePort2.Location = new System.Drawing.Point(985, 434);
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
            this.m_lblAlarmCodePort1.Location = new System.Drawing.Point(749, 434);
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
            this.sys3Label2.Location = new System.Drawing.Point(893, 472);
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
            this.sys3Label17.Location = new System.Drawing.Point(657, 472);
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
            this.sys3Label14.Location = new System.Drawing.Point(893, 434);
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
            this.sys3Label13.Location = new System.Drawing.Point(657, 434);
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
            this.sys3GroupBox3.Location = new System.Drawing.Point(648, 400);
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
            // dataGridView_Heater
            // 
            this.dataGridView_Heater.AllowUserToAddRows = false;
            this.dataGridView_Heater.AllowUserToDeleteRows = false;
            this.dataGridView_Heater.AllowUserToResizeColumns = false;
            this.dataGridView_Heater.AllowUserToResizeRows = false;
            this.dataGridView_Heater.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Heater.ColumnHeadersVisible = false;
            this.dataGridView_Heater.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn9});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_Heater.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_Heater.Location = new System.Drawing.Point(884, 772);
            this.dataGridView_Heater.MultiSelect = false;
            this.dataGridView_Heater.Name = "dataGridView_Heater";
            this.dataGridView_Heater.ReadOnly = true;
            this.dataGridView_Heater.RowHeadersVisible = false;
            this.dataGridView_Heater.RowTemplate.Height = 25;
            this.dataGridView_Heater.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView_Heater.Size = new System.Drawing.Size(249, 53);
            this.dataGridView_Heater.TabIndex = 20861;
            this.dataGridView_Heater.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Heater_CellClick);
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.HeaderText = "NAME";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "SET";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // sys3button3
            // 
            this.sys3button3.BorderWidth = 5;
            this.sys3button3.ButtonClicked = false;
            this.sys3button3.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.sys3button3.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.sys3button3.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.sys3button3.Description = "";
            this.sys3button3.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3button3.EdgeRadius = 5;
            this.sys3button3.GradientAngle = 60F;
            this.sys3button3.GradientFirstColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(230)))), ((int)(((byte)(115)))));
            this.sys3button3.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(135)))), ((int)(((byte)(20)))));
            this.sys3button3.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.sys3button3.ImagePosition = new System.Drawing.Point(37, 25);
            this.sys3button3.ImageSize = new System.Drawing.Point(30, 30);
            this.sys3button3.LoadImage = null;
            this.sys3button3.Location = new System.Drawing.Point(446, 835);
            this.sys3button3.MainFont = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sys3button3.MainFontColor = System.Drawing.Color.White;
            this.sys3button3.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3button3.Name = "sys3button3";
            this.sys3button3.Size = new System.Drawing.Size(222, 63);
            this.sys3button3.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.sys3button3.SubFontColor = System.Drawing.Color.Black;
            this.sys3button3.SubText = "";
            this.sys3button3.TabIndex = 2;
            this.sys3button3.Tag = "";
            this.sys3button3.Text = "MANUAL UNLOAD";
            this.sys3button3.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3button3.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3button3.ThemeIndex = 0;
            this.sys3button3.UseBorder = true;
            this.sys3button3.UseClickedEmphasizeTextColor = false;
            this.sys3button3.UseCustomizeClickedColor = false;
            this.sys3button3.UseEdge = true;
            this.sys3button3.UseHoverEmphasizeCustomColor = false;
            this.sys3button3.UseImage = true;
            this.sys3button3.UserHoverEmpahsize = false;
            this.sys3button3.UseSubFont = false;
            this.sys3button3.Click += new System.EventHandler(this.Click_Action);
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
            this.sys3GroupBox1.Location = new System.Drawing.Point(1, 45);
            this.sys3GroupBox1.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3GroupBox1.Name = "sys3GroupBox1";
            this.sys3GroupBox1.Size = new System.Drawing.Size(1139, 87);
            this.sys3GroupBox1.TabIndex = 20852;
            this.sys3GroupBox1.Tag = "";
            this.sys3GroupBox1.Text = "WORK INFORMATION";
            this.sys3GroupBox1.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3GroupBox1.ThemeIndex = 0;
            this.sys3GroupBox1.UseLabelBorder = true;
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
            this.sys3Label1.Location = new System.Drawing.Point(8, 82);
            this.sys3Label1.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label1.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label1.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label1.Name = "sys3Label1";
            this.sys3Label1.Size = new System.Drawing.Size(91, 37);
            this.sys3Label1.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label1.SubFontColor = System.Drawing.Color.DarkRed;
            this.sys3Label1.SubText = "";
            this.sys3Label1.TabIndex = 20856;
            this.sys3Label1.Tag = "";
            this.sys3Label1.Text = "ID ";
            this.sys3Label1.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3Label1.TextAlignSub = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
            this.sys3Label1.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label1.ThemeIndex = 0;
            this.sys3Label1.UnitAreaRate = 40;
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
            // m_lblID
            // 
            this.m_lblID.BackGroundColor = System.Drawing.Color.DimGray;
            this.m_lblID.BorderStroke = 2;
            this.m_lblID.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblID.Description = "";
            this.m_lblID.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblID.EdgeRadius = 1;
            this.m_lblID.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_lblID.ImageSize = new System.Drawing.Point(0, 0);
            this.m_lblID.LoadImage = null;
            this.m_lblID.Location = new System.Drawing.Point(100, 82);
            this.m_lblID.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_lblID.MainFontColor = System.Drawing.Color.White;
            this.m_lblID.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_lblID.Name = "m_lblID";
            this.m_lblID.Size = new System.Drawing.Size(468, 37);
            this.m_lblID.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblID.SubFontColor = System.Drawing.Color.Gray;
            this.m_lblID.SubText = "";
            this.m_lblID.TabIndex = 20860;
            this.m_lblID.Tag = "";
            this.m_lblID.Text = "NONE";
            this.m_lblID.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.m_lblID.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblID.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblID.ThemeIndex = 0;
            this.m_lblID.UnitAreaRate = 30;
            this.m_lblID.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblID.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblID.UnitPositionVertical = false;
            this.m_lblID.UnitText = "W";
            this.m_lblID.UseBorder = true;
            this.m_lblID.UseEdgeRadius = false;
            this.m_lblID.UseImage = false;
            this.m_lblID.UseSubFont = true;
            this.m_lblID.UseUnitFont = false;
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
            this.sys3Label4.Location = new System.Drawing.Point(573, 82);
            this.sys3Label4.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label4.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label4.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label4.Name = "sys3Label4";
            this.sys3Label4.Size = new System.Drawing.Size(91, 37);
            this.sys3Label4.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label4.SubFontColor = System.Drawing.Color.DarkRed;
            this.sys3Label4.SubText = "";
            this.sys3Label4.TabIndex = 20856;
            this.sys3Label4.Tag = "";
            this.sys3Label4.Text = "STATUS";
            this.sys3Label4.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3Label4.TextAlignSub = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
            this.sys3Label4.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label4.ThemeIndex = 0;
            this.sys3Label4.UnitAreaRate = 40;
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
            // m_lblWorkStatus
            // 
            this.m_lblWorkStatus.BackGroundColor = System.Drawing.Color.DimGray;
            this.m_lblWorkStatus.BorderStroke = 2;
            this.m_lblWorkStatus.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblWorkStatus.Description = "";
            this.m_lblWorkStatus.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblWorkStatus.EdgeRadius = 1;
            this.m_lblWorkStatus.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_lblWorkStatus.ImageSize = new System.Drawing.Point(0, 0);
            this.m_lblWorkStatus.LoadImage = null;
            this.m_lblWorkStatus.Location = new System.Drawing.Point(708, 82);
            this.m_lblWorkStatus.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_lblWorkStatus.MainFontColor = System.Drawing.Color.White;
            this.m_lblWorkStatus.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_lblWorkStatus.Name = "m_lblWorkStatus";
            this.m_lblWorkStatus.Size = new System.Drawing.Size(87, 37);
            this.m_lblWorkStatus.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblWorkStatus.SubFontColor = System.Drawing.Color.Gray;
            this.m_lblWorkStatus.SubText = "";
            this.m_lblWorkStatus.TabIndex = 20860;
            this.m_lblWorkStatus.Tag = "";
            this.m_lblWorkStatus.Text = "NONE";
            this.m_lblWorkStatus.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.m_lblWorkStatus.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblWorkStatus.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblWorkStatus.ThemeIndex = 0;
            this.m_lblWorkStatus.UnitAreaRate = 30;
            this.m_lblWorkStatus.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblWorkStatus.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblWorkStatus.UnitPositionVertical = false;
            this.m_lblWorkStatus.UnitText = "W";
            this.m_lblWorkStatus.UseBorder = true;
            this.m_lblWorkStatus.UseEdgeRadius = false;
            this.m_lblWorkStatus.UseImage = false;
            this.m_lblWorkStatus.UseSubFont = true;
            this.m_lblWorkStatus.UseUnitFont = false;
            // 
            // m_lblWorkStatus_Color
            // 
            this.m_lblWorkStatus_Color.BackGroundColor = System.Drawing.Color.Lime;
            this.m_lblWorkStatus_Color.BorderStroke = 4;
            this.m_lblWorkStatus_Color.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Outset;
            this.m_lblWorkStatus_Color.Description = "";
            this.m_lblWorkStatus_Color.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblWorkStatus_Color.EdgeRadius = 1;
            this.m_lblWorkStatus_Color.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_lblWorkStatus_Color.ImageSize = new System.Drawing.Point(0, 0);
            this.m_lblWorkStatus_Color.LoadImage = null;
            this.m_lblWorkStatus_Color.Location = new System.Drawing.Point(663, 82);
            this.m_lblWorkStatus_Color.MainFont = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.m_lblWorkStatus_Color.MainFontColor = System.Drawing.Color.Black;
            this.m_lblWorkStatus_Color.Name = "m_lblWorkStatus_Color";
            this.m_lblWorkStatus_Color.Size = new System.Drawing.Size(45, 37);
            this.m_lblWorkStatus_Color.SubFont = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.m_lblWorkStatus_Color.SubFontColor = System.Drawing.Color.Black;
            this.m_lblWorkStatus_Color.SubText = "BOND HEAD";
            this.m_lblWorkStatus_Color.TabIndex = 20862;
            this.m_lblWorkStatus_Color.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblWorkStatus_Color.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblWorkStatus_Color.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
            this.m_lblWorkStatus_Color.ThemeIndex = 0;
            this.m_lblWorkStatus_Color.UnitAreaRate = 30;
            this.m_lblWorkStatus_Color.UnitFont = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.m_lblWorkStatus_Color.UnitFontColor = System.Drawing.Color.Black;
            this.m_lblWorkStatus_Color.UnitPositionVertical = false;
            this.m_lblWorkStatus_Color.UnitText = "";
            this.m_lblWorkStatus_Color.UseBorder = true;
            this.m_lblWorkStatus_Color.UseEdgeRadius = false;
            this.m_lblWorkStatus_Color.UseImage = false;
            this.m_lblWorkStatus_Color.UseSubFont = false;
            this.m_lblWorkStatus_Color.UseUnitFont = false;
            // 
            // sys3Label3
            // 
            this.sys3Label3.BackGroundColor = System.Drawing.Color.DarkGray;
            this.sys3Label3.BorderStroke = 2;
            this.sys3Label3.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.sys3Label3.Description = "";
            this.sys3Label3.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3Label3.EdgeRadius = 1;
            this.sys3Label3.ImagePosition = new System.Drawing.Point(0, 0);
            this.sys3Label3.ImageSize = new System.Drawing.Point(0, 0);
            this.sys3Label3.LoadImage = null;
            this.sys3Label3.Location = new System.Drawing.Point(342, 385);
            this.sys3Label3.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label3.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label3.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label3.Name = "sys3Label3";
            this.sys3Label3.Size = new System.Drawing.Size(122, 37);
            this.sys3Label3.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label3.SubFontColor = System.Drawing.Color.DarkRed;
            this.sys3Label3.SubText = "";
            this.sys3Label3.TabIndex = 20854;
            this.sys3Label3.Tag = "";
            this.sys3Label3.Text = "PREHEAT TIME";
            this.sys3Label3.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3Label3.TextAlignSub = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
            this.sys3Label3.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label3.ThemeIndex = 0;
            this.sys3Label3.UnitAreaRate = 40;
            this.sys3Label3.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label3.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sys3Label3.UnitPositionVertical = false;
            this.sys3Label3.UnitText = "";
            this.sys3Label3.UseBorder = true;
            this.sys3Label3.UseEdgeRadius = false;
            this.sys3Label3.UseImage = false;
            this.sys3Label3.UseSubFont = true;
            this.sys3Label3.UseUnitFont = false;
            // 
            // m_lblPreHeatingTime
            // 
            this.m_lblPreHeatingTime.BackGroundColor = System.Drawing.Color.DimGray;
            this.m_lblPreHeatingTime.BorderStroke = 2;
            this.m_lblPreHeatingTime.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblPreHeatingTime.Description = "";
            this.m_lblPreHeatingTime.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblPreHeatingTime.EdgeRadius = 1;
            this.m_lblPreHeatingTime.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_lblPreHeatingTime.ImageSize = new System.Drawing.Point(0, 0);
            this.m_lblPreHeatingTime.LoadImage = null;
            this.m_lblPreHeatingTime.Location = new System.Drawing.Point(465, 385);
            this.m_lblPreHeatingTime.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_lblPreHeatingTime.MainFontColor = System.Drawing.Color.White;
            this.m_lblPreHeatingTime.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_lblPreHeatingTime.Name = "m_lblPreHeatingTime";
            this.m_lblPreHeatingTime.Size = new System.Drawing.Size(179, 37);
            this.m_lblPreHeatingTime.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblPreHeatingTime.SubFontColor = System.Drawing.Color.Gray;
            this.m_lblPreHeatingTime.SubText = "";
            this.m_lblPreHeatingTime.TabIndex = 20858;
            this.m_lblPreHeatingTime.Tag = "";
            this.m_lblPreHeatingTime.Text = "NONE";
            this.m_lblPreHeatingTime.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.m_lblPreHeatingTime.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblPreHeatingTime.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblPreHeatingTime.ThemeIndex = 0;
            this.m_lblPreHeatingTime.UnitAreaRate = 30;
            this.m_lblPreHeatingTime.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblPreHeatingTime.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblPreHeatingTime.UnitPositionVertical = false;
            this.m_lblPreHeatingTime.UnitText = "W";
            this.m_lblPreHeatingTime.UseBorder = true;
            this.m_lblPreHeatingTime.UseEdgeRadius = false;
            this.m_lblPreHeatingTime.UseImage = false;
            this.m_lblPreHeatingTime.UseSubFont = true;
            this.m_lblPreHeatingTime.UseUnitFont = false;
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
            this.sys3Label5.Location = new System.Drawing.Point(657, 557);
            this.sys3Label5.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label5.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label5.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label5.Name = "sys3Label5";
            this.sys3Label5.Size = new System.Drawing.Size(122, 37);
            this.sys3Label5.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label5.SubFontColor = System.Drawing.Color.DarkRed;
            this.sys3Label5.SubText = "";
            this.sys3Label5.TabIndex = 20854;
            this.sys3Label5.Tag = "";
            this.sys3Label5.Text = "CH POWER";
            this.sys3Label5.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3Label5.TextAlignSub = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
            this.sys3Label5.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label5.ThemeIndex = 0;
            this.sys3Label5.UnitAreaRate = 40;
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
            // m_lblChPower
            // 
            this.m_lblChPower.BackGroundColor = System.Drawing.Color.DimGray;
            this.m_lblChPower.BorderStroke = 2;
            this.m_lblChPower.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblChPower.Description = "";
            this.m_lblChPower.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblChPower.EdgeRadius = 1;
            this.m_lblChPower.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_lblChPower.ImageSize = new System.Drawing.Point(0, 0);
            this.m_lblChPower.LoadImage = null;
            this.m_lblChPower.Location = new System.Drawing.Point(780, 557);
            this.m_lblChPower.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_lblChPower.MainFontColor = System.Drawing.Color.White;
            this.m_lblChPower.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_lblChPower.Name = "m_lblChPower";
            this.m_lblChPower.Size = new System.Drawing.Size(348, 37);
            this.m_lblChPower.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblChPower.SubFontColor = System.Drawing.Color.Gray;
            this.m_lblChPower.SubText = "";
            this.m_lblChPower.TabIndex = 20858;
            this.m_lblChPower.Tag = "";
            this.m_lblChPower.Text = "NONE";
            this.m_lblChPower.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.m_lblChPower.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblChPower.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblChPower.ThemeIndex = 0;
            this.m_lblChPower.UnitAreaRate = 30;
            this.m_lblChPower.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblChPower.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblChPower.UnitPositionVertical = false;
            this.m_lblChPower.UnitText = "W";
            this.m_lblChPower.UseBorder = true;
            this.m_lblChPower.UseEdgeRadius = false;
            this.m_lblChPower.UseImage = false;
            this.m_lblChPower.UseSubFont = true;
            this.m_lblChPower.UseUnitFont = false;
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
            this.sys3Label7.Location = new System.Drawing.Point(657, 595);
            this.sys3Label7.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label7.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label7.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label7.Name = "sys3Label7";
            this.sys3Label7.Size = new System.Drawing.Size(122, 37);
            this.sys3Label7.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label7.SubFontColor = System.Drawing.Color.DarkRed;
            this.sys3Label7.SubText = "";
            this.sys3Label7.TabIndex = 20854;
            this.sys3Label7.Tag = "";
            this.sys3Label7.Text = "SIDE POWER";
            this.sys3Label7.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3Label7.TextAlignSub = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
            this.sys3Label7.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label7.ThemeIndex = 0;
            this.sys3Label7.UnitAreaRate = 40;
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
            // m_lblSidePower
            // 
            this.m_lblSidePower.BackGroundColor = System.Drawing.Color.DimGray;
            this.m_lblSidePower.BorderStroke = 2;
            this.m_lblSidePower.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblSidePower.Description = "";
            this.m_lblSidePower.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblSidePower.EdgeRadius = 1;
            this.m_lblSidePower.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_lblSidePower.ImageSize = new System.Drawing.Point(0, 0);
            this.m_lblSidePower.LoadImage = null;
            this.m_lblSidePower.Location = new System.Drawing.Point(780, 595);
            this.m_lblSidePower.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_lblSidePower.MainFontColor = System.Drawing.Color.White;
            this.m_lblSidePower.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_lblSidePower.Name = "m_lblSidePower";
            this.m_lblSidePower.Size = new System.Drawing.Size(348, 37);
            this.m_lblSidePower.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblSidePower.SubFontColor = System.Drawing.Color.Gray;
            this.m_lblSidePower.SubText = "";
            this.m_lblSidePower.TabIndex = 20858;
            this.m_lblSidePower.Tag = "";
            this.m_lblSidePower.Text = "NONE";
            this.m_lblSidePower.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.m_lblSidePower.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblSidePower.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblSidePower.ThemeIndex = 0;
            this.m_lblSidePower.UnitAreaRate = 30;
            this.m_lblSidePower.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblSidePower.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblSidePower.UnitPositionVertical = false;
            this.m_lblSidePower.UnitText = "W";
            this.m_lblSidePower.UseBorder = true;
            this.m_lblSidePower.UseEdgeRadius = false;
            this.m_lblSidePower.UseImage = false;
            this.m_lblSidePower.UseSubFont = true;
            this.m_lblSidePower.UseUnitFont = false;
            // 
            // gridViewControl_Head_Position_Parameter
            // 
            this.gridViewControl_Head_Position_Parameter.Control_Enable = true;
            this.gridViewControl_Head_Position_Parameter.controlCollection = null;
            this.gridViewControl_Head_Position_Parameter.Location = new System.Drawing.Point(3, 220);
            this.gridViewControl_Head_Position_Parameter.Name = "gridViewControl_Head_Position_Parameter";
            this.gridViewControl_Head_Position_Parameter.Size = new System.Drawing.Size(642, 53);
            this.gridViewControl_Head_Position_Parameter.TabIndex = 20846;
            // 
            // gridViewControl_Laser_Parameter
            // 
            this.gridViewControl_Laser_Parameter.Control_Enable = true;
            this.gridViewControl_Laser_Parameter.controlCollection = null;
            this.gridViewControl_Laser_Parameter.Location = new System.Drawing.Point(3, 274);
            this.gridViewControl_Laser_Parameter.Name = "gridViewControl_Laser_Parameter";
            this.gridViewControl_Laser_Parameter.Size = new System.Drawing.Size(642, 78);
            this.gridViewControl_Laser_Parameter.TabIndex = 20845;
            // 
            // gridVeiwControl_Laser_Device
            // 
            this.gridVeiwControl_Laser_Device.Control_Enable = true;
            this.gridVeiwControl_Laser_Device.controlCollection = null;
            this.gridVeiwControl_Laser_Device.Location = new System.Drawing.Point(646, 220);
            this.gridVeiwControl_Laser_Device.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.gridVeiwControl_Laser_Device.Name = "gridVeiwControl_Laser_Device";
            this.gridVeiwControl_Laser_Device.Size = new System.Drawing.Size(490, 178);
            this.gridVeiwControl_Laser_Device.TabIndex = 20844;
            // 
            // gridViewControl_Enable_Parameter
            // 
            this.gridViewControl_Enable_Parameter.Control_Enable = true;
            this.gridViewControl_Enable_Parameter.controlCollection = null;
            this.gridViewControl_Enable_Parameter.Location = new System.Drawing.Point(3, 166);
            this.gridViewControl_Enable_Parameter.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.gridViewControl_Enable_Parameter.Name = "gridViewControl_Enable_Parameter";
            this.gridViewControl_Enable_Parameter.Size = new System.Drawing.Size(1133, 53);
            this.gridViewControl_Enable_Parameter.TabIndex = 20843;
            // 
            // gridVeiwControl_Head_Device
            // 
            this.gridVeiwControl_Head_Device.Control_Enable = true;
            this.gridVeiwControl_Head_Device.controlCollection = null;
            this.gridVeiwControl_Head_Device.Location = new System.Drawing.Point(342, 353);
            this.gridVeiwControl_Head_Device.Name = "gridVeiwControl_Head_Device";
            this.gridVeiwControl_Head_Device.Size = new System.Drawing.Size(302, 28);
            this.gridVeiwControl_Head_Device.TabIndex = 9631;
            // 
            // gridVeiwControl_Block_Device
            // 
            this.gridVeiwControl_Block_Device.Control_Enable = true;
            this.gridVeiwControl_Block_Device.controlCollection = null;
            this.gridVeiwControl_Block_Device.Location = new System.Drawing.Point(884, 668);
            this.gridVeiwControl_Block_Device.Name = "gridVeiwControl_Block_Device";
            this.gridVeiwControl_Block_Device.Size = new System.Drawing.Size(249, 103);
            this.gridVeiwControl_Block_Device.TabIndex = 9631;
            // 
            // gridViewControl_Block_Position_Parameter
            // 
            this.gridViewControl_Block_Position_Parameter.Control_Enable = true;
            this.gridViewControl_Block_Position_Parameter.controlCollection = null;
            this.gridViewControl_Block_Position_Parameter.Location = new System.Drawing.Point(3, 668);
            this.gridViewControl_Block_Position_Parameter.Name = "gridViewControl_Block_Position_Parameter";
            this.gridViewControl_Block_Position_Parameter.Size = new System.Drawing.Size(521, 53);
            this.gridViewControl_Block_Position_Parameter.TabIndex = 9630;
            // 
            // gridViewControl_WorkStatus_Parameter
            // 
            this.gridViewControl_WorkStatus_Parameter.Control_Enable = true;
            this.gridViewControl_WorkStatus_Parameter.controlCollection = null;
            this.gridViewControl_WorkStatus_Parameter.Location = new System.Drawing.Point(797, 76);
            this.gridViewControl_WorkStatus_Parameter.Name = "gridViewControl_WorkStatus_Parameter";
            this.gridViewControl_WorkStatus_Parameter.Size = new System.Drawing.Size(340, 53);
            this.gridViewControl_WorkStatus_Parameter.TabIndex = 9629;
            // 
            // gridViewControl_Laser_Option_Parameter
            // 
            this.gridViewControl_Laser_Option_Parameter.Control_Enable = true;
            this.gridViewControl_Laser_Option_Parameter.controlCollection = null;
            this.gridViewControl_Laser_Option_Parameter.Location = new System.Drawing.Point(3, 353);
            this.gridViewControl_Laser_Option_Parameter.Name = "gridViewControl_Laser_Option_Parameter";
            this.gridViewControl_Laser_Option_Parameter.Size = new System.Drawing.Size(338, 253);
            this.gridViewControl_Laser_Option_Parameter.TabIndex = 9629;
            // 
            // gridViewControl_Block_Parameter
            // 
            this.gridViewControl_Block_Parameter.Control_Enable = true;
            this.gridViewControl_Block_Parameter.controlCollection = null;
            this.gridViewControl_Block_Parameter.Location = new System.Drawing.Point(526, 668);
            this.gridViewControl_Block_Parameter.Name = "gridViewControl_Block_Parameter";
            this.gridViewControl_Block_Parameter.Size = new System.Drawing.Size(356, 102);
            this.gridViewControl_Block_Parameter.TabIndex = 9629;
            // 
            // Setup_Work
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.btn_ParameterUndo);
            this.Controls.Add(this.btn_DecideParameterAll);
            this.Controls.Add(this.m_lblWorkStatus_Color);
            this.Controls.Add(this.dataGridView_Heater);
            this.Controls.Add(this.sys3button1);
            this.Controls.Add(this.btn_Reset);
            this.Controls.Add(this.m_lblAlarmCodeMonitor);
            this.Controls.Add(this.m_lblSidePower);
            this.Controls.Add(this.m_lblChPower);
            this.Controls.Add(this.m_lblPreHeatingTime);
            this.Controls.Add(this.m_lblAlarmCodePort3);
            this.Controls.Add(this.m_lblAlarmCodePort2);
            this.Controls.Add(this.m_lblWorkStatus);
            this.Controls.Add(this.m_lblID);
            this.Controls.Add(this.m_lblAlarmCodePort1);
            this.Controls.Add(this.sys3Label7);
            this.Controls.Add(this.sys3Label2);
            this.Controls.Add(this.sys3Label5);
            this.Controls.Add(this.sys3Label3);
            this.Controls.Add(this.sys3Label17);
            this.Controls.Add(this.sys3Label14);
            this.Controls.Add(this.sys3Label4);
            this.Controls.Add(this.sys3Label1);
            this.Controls.Add(this.sys3Label13);
            this.Controls.Add(this.sys3GroupBox3);
            this.Controls.Add(this.m_btnStop);
            this.Controls.Add(this.sys3button3);
            this.Controls.Add(this.sys3button2);
            this.Controls.Add(this.m_btnRun);
            this.Controls.Add(this.gridViewControl_Head_Position_Parameter);
            this.Controls.Add(this.gridViewControl_Laser_Parameter);
            this.Controls.Add(this.gridVeiwControl_Laser_Device);
            this.Controls.Add(this.gridViewControl_Enable_Parameter);
            this.Controls.Add(this.gridVeiwControl_Head_Device);
            this.Controls.Add(this.gridVeiwControl_Block_Device);
            this.Controls.Add(this.gridViewControl_Block_Position_Parameter);
            this.Controls.Add(this.gridViewControl_WorkStatus_Parameter);
            this.Controls.Add(this.gridViewControl_Laser_Option_Parameter);
            this.Controls.Add(this.gridViewControl_Block_Parameter);
            this.Controls.Add(this.sys3GroupBox5);
            this.Controls.Add(this.sys3GroupBox2);
            this.Controls.Add(this.sys3GroupBox1);
            this.Name = "Setup_Work";
            this.Size = new System.Drawing.Size(1140, 900);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Heater)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        private Component.GridVeiwControl_Device gridVeiwControl_Block_Device;
        private Component.GridViewControl_Position_Parameter gridViewControl_Block_Position_Parameter;
        private Component.GridViewControl_Parameter gridViewControl_Block_Parameter;
        private Component.GridVeiwControl_Device gridVeiwControl_Laser_Device;
        private Component.GridViewControl_Parameter gridViewControl_Enable_Parameter;
        private Component.GridViewControl_Parameter gridViewControl_Laser_Parameter;
        private Component.GridViewControl_2Axis_Position_Parameter gridViewControl_Head_Position_Parameter;
        private Sys3Controls.Sys3GroupBox sys3GroupBox2;
        private Sys3Controls.Sys3button m_btnStop;
        private Sys3Controls.Sys3button sys3button2;
        private Sys3Controls.Sys3button m_btnRun;
        private Sys3Controls.Sys3GroupBox sys3GroupBox5;
        private Component.GridViewControl_Parameter gridViewControl_Laser_Option_Parameter;
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
        private System.Windows.Forms.DataGridView dataGridView_Heater;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private Component.GridVeiwControl_Device gridVeiwControl_Head_Device;
        private Sys3Controls.Sys3button sys3button3;
        private Sys3Controls.Sys3GroupBox sys3GroupBox1;
        private Sys3Controls.Sys3Label sys3Label1;
        private Sys3Controls.Sys3Label m_lblID;
        private Sys3Controls.Sys3Label sys3Label4;
        private Sys3Controls.Sys3Label m_lblWorkStatus;
        private Component.GridViewControl_Parameter gridViewControl_WorkStatus_Parameter;
        private Sys3Controls.Sys3Label m_lblWorkStatus_Color;
        private Sys3Controls.Sys3Label sys3Label3;
        private Sys3Controls.Sys3Label m_lblPreHeatingTime;
        private Sys3Controls.Sys3button btn_ParameterUndo;
        private Sys3Controls.Sys3button btn_DecideParameterAll;
        private Sys3Controls.Sys3Label sys3Label5;
        private Sys3Controls.Sys3Label m_lblChPower;
        private Sys3Controls.Sys3Label sys3Label7;
        private Sys3Controls.Sys3Label m_lblSidePower;


    }
}
