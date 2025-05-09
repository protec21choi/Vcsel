namespace FrameOfSystem3.Views.Operation
{
	partial class Operation_Main
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.sys3GroupBox1 = new Sys3Controls.Sys3GroupBox();
            this.btn_EMO = new Sys3Controls.Sys3button();
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
            this.m_btnStop = new Sys3Controls.Sys3button();
            this.m_btnRun = new Sys3Controls.Sys3button();
            this.sys3GroupBox5 = new Sys3Controls.Sys3GroupBox();
            this.btn_EMO_2 = new Sys3Controls.Sys3button();
            this.btn_Reset_2 = new Sys3Controls.Sys3button();
            this.m_lblAlarmCodeMonitor_2 = new Sys3Controls.Sys3Label();
            this.m_lblAlarmCodePort3_2 = new Sys3Controls.Sys3Label();
            this.m_lblAlarmCodePort2_2 = new Sys3Controls.Sys3Label();
            this.m_lblAlarmCodePort1_2 = new Sys3Controls.Sys3Label();
            this.sys3Label11 = new Sys3Controls.Sys3Label();
            this.sys3Label12 = new Sys3Controls.Sys3Label();
            this.sys3Label15 = new Sys3Controls.Sys3Label();
            this.sys3Label16 = new Sys3Controls.Sys3Label();
            this.sys3GroupBox6 = new Sys3Controls.Sys3GroupBox();
            this.m_btnReset = new Sys3Controls.Sys3button();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.SB_GraphTime = new System.Windows.Forms.HScrollBar();
            this._Graph = new ZedGraph.ZedGraphControl();
            this.sys3GroupBox8 = new Sys3Controls.Sys3GroupBox();
            this.btn_ParameterUndo = new Sys3Controls.Sys3button();
            this.btn_DecideParameterAll = new Sys3Controls.Sys3button();
            this.gridViewControl_AutoRun_Parameter = new FrameOfSystem3.Component.GridViewControl_Parameter();
            this.gridVeiwControl_Laser_Device_2 = new FrameOfSystem3.Component.GridVeiwControl_Device();
            this.gridViewControl_Enable_Parameter_2 = new FrameOfSystem3.Component.GridViewControl_Parameter();
            this.gridVeiwControl_Laser_Device = new FrameOfSystem3.Component.GridVeiwControl_Device();
            this.gridViewControl_Enable_Parameter = new FrameOfSystem3.Component.GridViewControl_Parameter();
            this.sys3button1 = new Sys3Controls.Sys3button();
            this.sys3GroupBox2 = new Sys3Controls.Sys3GroupBox();
            this.gridVeiwControl_External_IO = new FrameOfSystem3.Component.GridVeiwControl_Device();
            this.m_lblCycleTotal = new Sys3Controls.Sys3Label();
            this.sys3Label1 = new Sys3Controls.Sys3Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
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
            this.sys3GroupBox1.Location = new System.Drawing.Point(201, 632);
            this.sys3GroupBox1.Name = "sys3GroupBox1";
            this.sys3GroupBox1.Size = new System.Drawing.Size(937, 267);
            this.sys3GroupBox1.TabIndex = 20893;
            this.sys3GroupBox1.Text = "LASER_2 STATE";
            this.sys3GroupBox1.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3GroupBox1.ThemeIndex = 0;
            this.sys3GroupBox1.UseLabelBorder = true;
            // 
            // btn_EMO
            // 
            this.btn_EMO.BorderWidth = 3;
            this.btn_EMO.ButtonClicked = false;
            this.btn_EMO.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.btn_EMO.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.btn_EMO.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.btn_EMO.Description = "";
            this.btn_EMO.DisabledColor = System.Drawing.Color.DarkGray;
            this.btn_EMO.EdgeRadius = 1;
            this.btn_EMO.GradientAngle = 90F;
            this.btn_EMO.GradientFirstColor = System.Drawing.Color.White;
            this.btn_EMO.GradientSecondColor = System.Drawing.Color.Silver;
            this.btn_EMO.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.btn_EMO.ImagePosition = new System.Drawing.Point(7, 7);
            this.btn_EMO.ImageSize = new System.Drawing.Point(30, 30);
            this.btn_EMO.LoadImage = global::FrameOfSystem3.Properties.Resources.CONFIG_ADD3;
            this.btn_EMO.Location = new System.Drawing.Point(998, 572);
            this.btn_EMO.MainFont = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.btn_EMO.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
            this.btn_EMO.Name = "btn_EMO";
            this.btn_EMO.Size = new System.Drawing.Size(131, 40);
            this.btn_EMO.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.btn_EMO.SubFontColor = System.Drawing.Color.DarkBlue;
            this.btn_EMO.SubText = "STATUS";
            this.btn_EMO.TabIndex = 1;
            this.btn_EMO.Text = "ALL EMO";
            this.btn_EMO.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.btn_EMO.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.btn_EMO.ThemeIndex = 0;
            this.btn_EMO.UseBorder = false;
            this.btn_EMO.UseClickedEmphasizeTextColor = false;
            this.btn_EMO.UseCustomizeClickedColor = false;
            this.btn_EMO.UseEdge = false;
            this.btn_EMO.UseHoverEmphasizeCustomColor = false;
            this.btn_EMO.UseImage = false;
            this.btn_EMO.UserHoverEmpahsize = true;
            this.btn_EMO.UseSubFont = false;
            this.btn_EMO.Click += new System.EventHandler(this.Cick_All_IO);
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
            this.btn_Reset.Location = new System.Drawing.Point(864, 572);
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
            this.m_lblAlarmCodeMonitor.Location = new System.Drawing.Point(1009, 524);
            this.m_lblAlarmCodeMonitor.MainFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblAlarmCodeMonitor.MainFontColor = System.Drawing.Color.White;
            this.m_lblAlarmCodeMonitor.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_lblAlarmCodeMonitor.Name = "m_lblAlarmCodeMonitor";
            this.m_lblAlarmCodeMonitor.Size = new System.Drawing.Size(120, 37);
            this.m_lblAlarmCodeMonitor.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblAlarmCodeMonitor.SubFontColor = System.Drawing.Color.Gray;
            this.m_lblAlarmCodeMonitor.SubText = "";
            this.m_lblAlarmCodeMonitor.TabIndex = 20887;
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
            this.m_lblAlarmCodePort3.Location = new System.Drawing.Point(807, 524);
            this.m_lblAlarmCodePort3.MainFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblAlarmCodePort3.MainFontColor = System.Drawing.Color.White;
            this.m_lblAlarmCodePort3.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_lblAlarmCodePort3.Name = "m_lblAlarmCodePort3";
            this.m_lblAlarmCodePort3.Size = new System.Drawing.Size(120, 37);
            this.m_lblAlarmCodePort3.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblAlarmCodePort3.SubFontColor = System.Drawing.Color.Gray;
            this.m_lblAlarmCodePort3.SubText = "";
            this.m_lblAlarmCodePort3.TabIndex = 20888;
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
            this.m_lblAlarmCodePort2.Location = new System.Drawing.Point(1009, 486);
            this.m_lblAlarmCodePort2.MainFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblAlarmCodePort2.MainFontColor = System.Drawing.Color.White;
            this.m_lblAlarmCodePort2.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_lblAlarmCodePort2.Name = "m_lblAlarmCodePort2";
            this.m_lblAlarmCodePort2.Size = new System.Drawing.Size(120, 37);
            this.m_lblAlarmCodePort2.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblAlarmCodePort2.SubFontColor = System.Drawing.Color.Gray;
            this.m_lblAlarmCodePort2.SubText = "";
            this.m_lblAlarmCodePort2.TabIndex = 20889;
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
            this.m_lblAlarmCodePort1.Location = new System.Drawing.Point(807, 486);
            this.m_lblAlarmCodePort1.MainFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblAlarmCodePort1.MainFontColor = System.Drawing.Color.White;
            this.m_lblAlarmCodePort1.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_lblAlarmCodePort1.Name = "m_lblAlarmCodePort1";
            this.m_lblAlarmCodePort1.Size = new System.Drawing.Size(120, 37);
            this.m_lblAlarmCodePort1.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblAlarmCodePort1.SubFontColor = System.Drawing.Color.Gray;
            this.m_lblAlarmCodePort1.SubText = "";
            this.m_lblAlarmCodePort1.TabIndex = 20890;
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
            this.sys3Label2.Location = new System.Drawing.Point(928, 524);
            this.sys3Label2.MainFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label2.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label2.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label2.Name = "sys3Label2";
            this.sys3Label2.Size = new System.Drawing.Size(80, 37);
            this.sys3Label2.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label2.SubFontColor = System.Drawing.Color.DarkRed;
            this.sys3Label2.SubText = "";
            this.sys3Label2.TabIndex = 20883;
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
            this.sys3Label17.Location = new System.Drawing.Point(726, 524);
            this.sys3Label17.MainFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label17.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label17.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label17.Name = "sys3Label17";
            this.sys3Label17.Size = new System.Drawing.Size(80, 37);
            this.sys3Label17.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label17.SubFontColor = System.Drawing.Color.DarkRed;
            this.sys3Label17.SubText = "";
            this.sys3Label17.TabIndex = 20884;
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
            this.sys3Label14.Location = new System.Drawing.Point(928, 486);
            this.sys3Label14.MainFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label14.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label14.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label14.Name = "sys3Label14";
            this.sys3Label14.Size = new System.Drawing.Size(80, 37);
            this.sys3Label14.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label14.SubFontColor = System.Drawing.Color.DarkRed;
            this.sys3Label14.SubText = "";
            this.sys3Label14.TabIndex = 20885;
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
            this.sys3Label13.Location = new System.Drawing.Point(726, 486);
            this.sys3Label13.MainFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label13.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label13.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label13.Name = "sys3Label13";
            this.sys3Label13.Size = new System.Drawing.Size(80, 37);
            this.sys3Label13.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label13.SubFontColor = System.Drawing.Color.DarkRed;
            this.sys3Label13.SubText = "";
            this.sys3Label13.TabIndex = 20886;
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
            this.sys3GroupBox3.Location = new System.Drawing.Point(719, 445);
            this.sys3GroupBox3.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3GroupBox3.Name = "sys3GroupBox3";
            this.sys3GroupBox3.Size = new System.Drawing.Size(416, 176);
            this.sys3GroupBox3.TabIndex = 20882;
            this.sys3GroupBox3.Tag = "";
            this.sys3GroupBox3.Text = "LASER_1 ALARM CODE";
            this.sys3GroupBox3.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3GroupBox3.ThemeIndex = 0;
            this.sys3GroupBox3.UseLabelBorder = true;
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
            this.m_btnStop.Location = new System.Drawing.Point(204, 2);
            this.m_btnStop.MainFont = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.m_btnStop.MainFontColor = System.Drawing.Color.White;
            this.m_btnStop.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_btnStop.Name = "m_btnStop";
            this.m_btnStop.Size = new System.Drawing.Size(200, 43);
            this.m_btnStop.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.m_btnStop.SubFontColor = System.Drawing.Color.Black;
            this.m_btnStop.SubText = "";
            this.m_btnStop.TabIndex = 2;
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
            this.m_btnStop.Click += new System.EventHandler(this.Click_OperationButton);
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
            this.m_btnRun.Location = new System.Drawing.Point(3, 2);
            this.m_btnRun.MainFont = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.m_btnRun.MainFontColor = System.Drawing.Color.White;
            this.m_btnRun.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_btnRun.Name = "m_btnRun";
            this.m_btnRun.Size = new System.Drawing.Size(200, 43);
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
            this.sys3GroupBox5.Location = new System.Drawing.Point(201, 359);
            this.sys3GroupBox5.Name = "sys3GroupBox5";
            this.sys3GroupBox5.Size = new System.Drawing.Size(937, 267);
            this.sys3GroupBox5.TabIndex = 20877;
            this.sys3GroupBox5.Text = "LASER_1 STATE";
            this.sys3GroupBox5.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3GroupBox5.ThemeIndex = 0;
            this.sys3GroupBox5.UseLabelBorder = true;
            // 
            // btn_EMO_2
            // 
            this.btn_EMO_2.BorderWidth = 3;
            this.btn_EMO_2.ButtonClicked = false;
            this.btn_EMO_2.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.btn_EMO_2.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.btn_EMO_2.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.btn_EMO_2.Description = "";
            this.btn_EMO_2.DisabledColor = System.Drawing.Color.DarkGray;
            this.btn_EMO_2.EdgeRadius = 1;
            this.btn_EMO_2.GradientAngle = 90F;
            this.btn_EMO_2.GradientFirstColor = System.Drawing.Color.White;
            this.btn_EMO_2.GradientSecondColor = System.Drawing.Color.Silver;
            this.btn_EMO_2.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.btn_EMO_2.ImagePosition = new System.Drawing.Point(7, 7);
            this.btn_EMO_2.ImageSize = new System.Drawing.Point(30, 30);
            this.btn_EMO_2.LoadImage = global::FrameOfSystem3.Properties.Resources.CONFIG_ADD3;
            this.btn_EMO_2.Location = new System.Drawing.Point(998, 846);
            this.btn_EMO_2.MainFont = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.btn_EMO_2.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
            this.btn_EMO_2.Name = "btn_EMO_2";
            this.btn_EMO_2.Size = new System.Drawing.Size(131, 40);
            this.btn_EMO_2.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.btn_EMO_2.SubFontColor = System.Drawing.Color.DarkBlue;
            this.btn_EMO_2.SubText = "STATUS";
            this.btn_EMO_2.TabIndex = 1;
            this.btn_EMO_2.Text = "ALL EMO";
            this.btn_EMO_2.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.btn_EMO_2.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.btn_EMO_2.ThemeIndex = 0;
            this.btn_EMO_2.UseBorder = false;
            this.btn_EMO_2.UseClickedEmphasizeTextColor = false;
            this.btn_EMO_2.UseCustomizeClickedColor = false;
            this.btn_EMO_2.UseEdge = false;
            this.btn_EMO_2.UseHoverEmphasizeCustomColor = false;
            this.btn_EMO_2.UseImage = false;
            this.btn_EMO_2.UserHoverEmpahsize = true;
            this.btn_EMO_2.UseSubFont = false;
            this.btn_EMO_2.Click += new System.EventHandler(this.Cick_All_IO_2);
            // 
            // btn_Reset_2
            // 
            this.btn_Reset_2.BorderWidth = 3;
            this.btn_Reset_2.ButtonClicked = false;
            this.btn_Reset_2.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.btn_Reset_2.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.btn_Reset_2.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.btn_Reset_2.Description = "";
            this.btn_Reset_2.DisabledColor = System.Drawing.Color.DarkGray;
            this.btn_Reset_2.EdgeRadius = 1;
            this.btn_Reset_2.GradientAngle = 90F;
            this.btn_Reset_2.GradientFirstColor = System.Drawing.Color.White;
            this.btn_Reset_2.GradientSecondColor = System.Drawing.Color.Silver;
            this.btn_Reset_2.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.btn_Reset_2.ImagePosition = new System.Drawing.Point(7, 7);
            this.btn_Reset_2.ImageSize = new System.Drawing.Point(30, 30);
            this.btn_Reset_2.LoadImage = global::FrameOfSystem3.Properties.Resources.CONFIG_ADD3;
            this.btn_Reset_2.Location = new System.Drawing.Point(864, 846);
            this.btn_Reset_2.MainFont = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.btn_Reset_2.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
            this.btn_Reset_2.Name = "btn_Reset_2";
            this.btn_Reset_2.Size = new System.Drawing.Size(131, 40);
            this.btn_Reset_2.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.btn_Reset_2.SubFontColor = System.Drawing.Color.DarkBlue;
            this.btn_Reset_2.SubText = "STATUS";
            this.btn_Reset_2.TabIndex = 0;
            this.btn_Reset_2.Text = "ALL RESET";
            this.btn_Reset_2.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.btn_Reset_2.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.btn_Reset_2.ThemeIndex = 0;
            this.btn_Reset_2.UseBorder = false;
            this.btn_Reset_2.UseClickedEmphasizeTextColor = false;
            this.btn_Reset_2.UseCustomizeClickedColor = false;
            this.btn_Reset_2.UseEdge = false;
            this.btn_Reset_2.UseHoverEmphasizeCustomColor = false;
            this.btn_Reset_2.UseImage = false;
            this.btn_Reset_2.UserHoverEmpahsize = true;
            this.btn_Reset_2.UseSubFont = false;
            this.btn_Reset_2.Click += new System.EventHandler(this.Cick_All_IO_2);
            // 
            // m_lblAlarmCodeMonitor_2
            // 
            this.m_lblAlarmCodeMonitor_2.BackGroundColor = System.Drawing.Color.DimGray;
            this.m_lblAlarmCodeMonitor_2.BorderStroke = 2;
            this.m_lblAlarmCodeMonitor_2.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblAlarmCodeMonitor_2.Description = "";
            this.m_lblAlarmCodeMonitor_2.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblAlarmCodeMonitor_2.EdgeRadius = 1;
            this.m_lblAlarmCodeMonitor_2.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_lblAlarmCodeMonitor_2.ImageSize = new System.Drawing.Point(0, 0);
            this.m_lblAlarmCodeMonitor_2.LoadImage = null;
            this.m_lblAlarmCodeMonitor_2.Location = new System.Drawing.Point(1009, 798);
            this.m_lblAlarmCodeMonitor_2.MainFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblAlarmCodeMonitor_2.MainFontColor = System.Drawing.Color.White;
            this.m_lblAlarmCodeMonitor_2.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_lblAlarmCodeMonitor_2.Name = "m_lblAlarmCodeMonitor_2";
            this.m_lblAlarmCodeMonitor_2.Size = new System.Drawing.Size(120, 37);
            this.m_lblAlarmCodeMonitor_2.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblAlarmCodeMonitor_2.SubFontColor = System.Drawing.Color.Gray;
            this.m_lblAlarmCodeMonitor_2.SubText = "";
            this.m_lblAlarmCodeMonitor_2.TabIndex = 20913;
            this.m_lblAlarmCodeMonitor_2.Tag = "";
            this.m_lblAlarmCodeMonitor_2.Text = "NONE";
            this.m_lblAlarmCodeMonitor_2.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.m_lblAlarmCodeMonitor_2.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblAlarmCodeMonitor_2.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblAlarmCodeMonitor_2.ThemeIndex = 0;
            this.m_lblAlarmCodeMonitor_2.UnitAreaRate = 30;
            this.m_lblAlarmCodeMonitor_2.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblAlarmCodeMonitor_2.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblAlarmCodeMonitor_2.UnitPositionVertical = false;
            this.m_lblAlarmCodeMonitor_2.UnitText = "W";
            this.m_lblAlarmCodeMonitor_2.UseBorder = true;
            this.m_lblAlarmCodeMonitor_2.UseEdgeRadius = false;
            this.m_lblAlarmCodeMonitor_2.UseImage = false;
            this.m_lblAlarmCodeMonitor_2.UseSubFont = true;
            this.m_lblAlarmCodeMonitor_2.UseUnitFont = false;
            // 
            // m_lblAlarmCodePort3_2
            // 
            this.m_lblAlarmCodePort3_2.BackGroundColor = System.Drawing.Color.DimGray;
            this.m_lblAlarmCodePort3_2.BorderStroke = 2;
            this.m_lblAlarmCodePort3_2.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblAlarmCodePort3_2.Description = "";
            this.m_lblAlarmCodePort3_2.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblAlarmCodePort3_2.EdgeRadius = 1;
            this.m_lblAlarmCodePort3_2.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_lblAlarmCodePort3_2.ImageSize = new System.Drawing.Point(0, 0);
            this.m_lblAlarmCodePort3_2.LoadImage = null;
            this.m_lblAlarmCodePort3_2.Location = new System.Drawing.Point(807, 798);
            this.m_lblAlarmCodePort3_2.MainFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblAlarmCodePort3_2.MainFontColor = System.Drawing.Color.White;
            this.m_lblAlarmCodePort3_2.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_lblAlarmCodePort3_2.Name = "m_lblAlarmCodePort3_2";
            this.m_lblAlarmCodePort3_2.Size = new System.Drawing.Size(120, 37);
            this.m_lblAlarmCodePort3_2.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblAlarmCodePort3_2.SubFontColor = System.Drawing.Color.Gray;
            this.m_lblAlarmCodePort3_2.SubText = "";
            this.m_lblAlarmCodePort3_2.TabIndex = 20914;
            this.m_lblAlarmCodePort3_2.Tag = "";
            this.m_lblAlarmCodePort3_2.Text = "NONE";
            this.m_lblAlarmCodePort3_2.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.m_lblAlarmCodePort3_2.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblAlarmCodePort3_2.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblAlarmCodePort3_2.ThemeIndex = 0;
            this.m_lblAlarmCodePort3_2.UnitAreaRate = 30;
            this.m_lblAlarmCodePort3_2.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblAlarmCodePort3_2.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblAlarmCodePort3_2.UnitPositionVertical = false;
            this.m_lblAlarmCodePort3_2.UnitText = "W";
            this.m_lblAlarmCodePort3_2.UseBorder = true;
            this.m_lblAlarmCodePort3_2.UseEdgeRadius = false;
            this.m_lblAlarmCodePort3_2.UseImage = false;
            this.m_lblAlarmCodePort3_2.UseSubFont = true;
            this.m_lblAlarmCodePort3_2.UseUnitFont = false;
            // 
            // m_lblAlarmCodePort2_2
            // 
            this.m_lblAlarmCodePort2_2.BackGroundColor = System.Drawing.Color.DimGray;
            this.m_lblAlarmCodePort2_2.BorderStroke = 2;
            this.m_lblAlarmCodePort2_2.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblAlarmCodePort2_2.Description = "";
            this.m_lblAlarmCodePort2_2.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblAlarmCodePort2_2.EdgeRadius = 1;
            this.m_lblAlarmCodePort2_2.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_lblAlarmCodePort2_2.ImageSize = new System.Drawing.Point(0, 0);
            this.m_lblAlarmCodePort2_2.LoadImage = null;
            this.m_lblAlarmCodePort2_2.Location = new System.Drawing.Point(1009, 760);
            this.m_lblAlarmCodePort2_2.MainFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblAlarmCodePort2_2.MainFontColor = System.Drawing.Color.White;
            this.m_lblAlarmCodePort2_2.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_lblAlarmCodePort2_2.Name = "m_lblAlarmCodePort2_2";
            this.m_lblAlarmCodePort2_2.Size = new System.Drawing.Size(120, 37);
            this.m_lblAlarmCodePort2_2.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblAlarmCodePort2_2.SubFontColor = System.Drawing.Color.Gray;
            this.m_lblAlarmCodePort2_2.SubText = "";
            this.m_lblAlarmCodePort2_2.TabIndex = 20915;
            this.m_lblAlarmCodePort2_2.Tag = "";
            this.m_lblAlarmCodePort2_2.Text = "NONE";
            this.m_lblAlarmCodePort2_2.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.m_lblAlarmCodePort2_2.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblAlarmCodePort2_2.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblAlarmCodePort2_2.ThemeIndex = 0;
            this.m_lblAlarmCodePort2_2.UnitAreaRate = 30;
            this.m_lblAlarmCodePort2_2.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblAlarmCodePort2_2.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblAlarmCodePort2_2.UnitPositionVertical = false;
            this.m_lblAlarmCodePort2_2.UnitText = "W";
            this.m_lblAlarmCodePort2_2.UseBorder = true;
            this.m_lblAlarmCodePort2_2.UseEdgeRadius = false;
            this.m_lblAlarmCodePort2_2.UseImage = false;
            this.m_lblAlarmCodePort2_2.UseSubFont = true;
            this.m_lblAlarmCodePort2_2.UseUnitFont = false;
            // 
            // m_lblAlarmCodePort1_2
            // 
            this.m_lblAlarmCodePort1_2.BackGroundColor = System.Drawing.Color.DimGray;
            this.m_lblAlarmCodePort1_2.BorderStroke = 2;
            this.m_lblAlarmCodePort1_2.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblAlarmCodePort1_2.Description = "";
            this.m_lblAlarmCodePort1_2.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblAlarmCodePort1_2.EdgeRadius = 1;
            this.m_lblAlarmCodePort1_2.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_lblAlarmCodePort1_2.ImageSize = new System.Drawing.Point(0, 0);
            this.m_lblAlarmCodePort1_2.LoadImage = null;
            this.m_lblAlarmCodePort1_2.Location = new System.Drawing.Point(807, 760);
            this.m_lblAlarmCodePort1_2.MainFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblAlarmCodePort1_2.MainFontColor = System.Drawing.Color.White;
            this.m_lblAlarmCodePort1_2.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_lblAlarmCodePort1_2.Name = "m_lblAlarmCodePort1_2";
            this.m_lblAlarmCodePort1_2.Size = new System.Drawing.Size(120, 37);
            this.m_lblAlarmCodePort1_2.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblAlarmCodePort1_2.SubFontColor = System.Drawing.Color.Gray;
            this.m_lblAlarmCodePort1_2.SubText = "";
            this.m_lblAlarmCodePort1_2.TabIndex = 20916;
            this.m_lblAlarmCodePort1_2.Tag = "";
            this.m_lblAlarmCodePort1_2.Text = "NONE";
            this.m_lblAlarmCodePort1_2.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.m_lblAlarmCodePort1_2.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblAlarmCodePort1_2.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblAlarmCodePort1_2.ThemeIndex = 0;
            this.m_lblAlarmCodePort1_2.UnitAreaRate = 30;
            this.m_lblAlarmCodePort1_2.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblAlarmCodePort1_2.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblAlarmCodePort1_2.UnitPositionVertical = false;
            this.m_lblAlarmCodePort1_2.UnitText = "W";
            this.m_lblAlarmCodePort1_2.UseBorder = true;
            this.m_lblAlarmCodePort1_2.UseEdgeRadius = false;
            this.m_lblAlarmCodePort1_2.UseImage = false;
            this.m_lblAlarmCodePort1_2.UseSubFont = true;
            this.m_lblAlarmCodePort1_2.UseUnitFont = false;
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
            this.sys3Label11.Location = new System.Drawing.Point(928, 798);
            this.sys3Label11.MainFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label11.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label11.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label11.Name = "sys3Label11";
            this.sys3Label11.Size = new System.Drawing.Size(80, 37);
            this.sys3Label11.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label11.SubFontColor = System.Drawing.Color.DarkRed;
            this.sys3Label11.SubText = "";
            this.sys3Label11.TabIndex = 20909;
            this.sys3Label11.Tag = "";
            this.sys3Label11.Text = "MONITOR";
            this.sys3Label11.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3Label11.TextAlignSub = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
            this.sys3Label11.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label11.ThemeIndex = 0;
            this.sys3Label11.UnitAreaRate = 40;
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
            this.sys3Label12.Location = new System.Drawing.Point(726, 798);
            this.sys3Label12.MainFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label12.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label12.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label12.Name = "sys3Label12";
            this.sys3Label12.Size = new System.Drawing.Size(80, 37);
            this.sys3Label12.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label12.SubFontColor = System.Drawing.Color.DarkRed;
            this.sys3Label12.SubText = "";
            this.sys3Label12.TabIndex = 20910;
            this.sys3Label12.Tag = "";
            this.sys3Label12.Text = "PORT 3";
            this.sys3Label12.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3Label12.TextAlignSub = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
            this.sys3Label12.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label12.ThemeIndex = 0;
            this.sys3Label12.UnitAreaRate = 40;
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
            // sys3Label15
            // 
            this.sys3Label15.BackGroundColor = System.Drawing.Color.DarkGray;
            this.sys3Label15.BorderStroke = 2;
            this.sys3Label15.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.sys3Label15.Description = "";
            this.sys3Label15.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3Label15.EdgeRadius = 1;
            this.sys3Label15.ImagePosition = new System.Drawing.Point(0, 0);
            this.sys3Label15.ImageSize = new System.Drawing.Point(0, 0);
            this.sys3Label15.LoadImage = null;
            this.sys3Label15.Location = new System.Drawing.Point(928, 760);
            this.sys3Label15.MainFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label15.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label15.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label15.Name = "sys3Label15";
            this.sys3Label15.Size = new System.Drawing.Size(80, 37);
            this.sys3Label15.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label15.SubFontColor = System.Drawing.Color.DarkRed;
            this.sys3Label15.SubText = "";
            this.sys3Label15.TabIndex = 20911;
            this.sys3Label15.Tag = "";
            this.sys3Label15.Text = "PORT 2";
            this.sys3Label15.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3Label15.TextAlignSub = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
            this.sys3Label15.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label15.ThemeIndex = 0;
            this.sys3Label15.UnitAreaRate = 40;
            this.sys3Label15.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label15.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sys3Label15.UnitPositionVertical = false;
            this.sys3Label15.UnitText = "";
            this.sys3Label15.UseBorder = true;
            this.sys3Label15.UseEdgeRadius = false;
            this.sys3Label15.UseImage = false;
            this.sys3Label15.UseSubFont = true;
            this.sys3Label15.UseUnitFont = false;
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
            this.sys3Label16.Location = new System.Drawing.Point(726, 760);
            this.sys3Label16.MainFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label16.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label16.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label16.Name = "sys3Label16";
            this.sys3Label16.Size = new System.Drawing.Size(80, 37);
            this.sys3Label16.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label16.SubFontColor = System.Drawing.Color.DarkRed;
            this.sys3Label16.SubText = "";
            this.sys3Label16.TabIndex = 20912;
            this.sys3Label16.Tag = "";
            this.sys3Label16.Text = "PORT 1";
            this.sys3Label16.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3Label16.TextAlignSub = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
            this.sys3Label16.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label16.ThemeIndex = 0;
            this.sys3Label16.UnitAreaRate = 40;
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
            // sys3GroupBox6
            // 
            this.sys3GroupBox6.BackGroundColor = System.Drawing.Color.WhiteSmoke;
            this.sys3GroupBox6.EdgeBorderStroke = 2;
            this.sys3GroupBox6.EdgeRadius = 2;
            this.sys3GroupBox6.LabelFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3GroupBox6.LabelGradientColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.sys3GroupBox6.LabelGradientColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.sys3GroupBox6.LabelHeight = 30;
            this.sys3GroupBox6.LabelTextColor = System.Drawing.Color.Black;
            this.sys3GroupBox6.Location = new System.Drawing.Point(719, 719);
            this.sys3GroupBox6.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3GroupBox6.Name = "sys3GroupBox6";
            this.sys3GroupBox6.Size = new System.Drawing.Size(416, 176);
            this.sys3GroupBox6.TabIndex = 20908;
            this.sys3GroupBox6.Tag = "";
            this.sys3GroupBox6.Text = "LASER_2 ALARM CODE";
            this.sys3GroupBox6.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3GroupBox6.ThemeIndex = 0;
            this.sys3GroupBox6.UseLabelBorder = true;
            // 
            // m_btnReset
            // 
            this.m_btnReset.BorderWidth = 5;
            this.m_btnReset.ButtonClicked = false;
            this.m_btnReset.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.m_btnReset.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.m_btnReset.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.m_btnReset.Description = "";
            this.m_btnReset.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_btnReset.EdgeRadius = 5;
            this.m_btnReset.GradientAngle = 60F;
            this.m_btnReset.GradientFirstColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.m_btnReset.GradientSecondColor = System.Drawing.Color.MediumBlue;
            this.m_btnReset.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.m_btnReset.ImagePosition = new System.Drawing.Point(37, 25);
            this.m_btnReset.ImageSize = new System.Drawing.Point(30, 30);
            this.m_btnReset.LoadImage = null;
            this.m_btnReset.Location = new System.Drawing.Point(405, 2);
            this.m_btnReset.MainFont = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold);
            this.m_btnReset.MainFontColor = System.Drawing.Color.White;
            this.m_btnReset.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_btnReset.Name = "m_btnReset";
            this.m_btnReset.Size = new System.Drawing.Size(200, 43);
            this.m_btnReset.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.m_btnReset.SubFontColor = System.Drawing.Color.Black;
            this.m_btnReset.SubText = "";
            this.m_btnReset.TabIndex = 3;
            this.m_btnReset.Tag = "";
            this.m_btnReset.Text = "RESET";
            this.m_btnReset.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_btnReset.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_btnReset.ThemeIndex = 0;
            this.m_btnReset.UseBorder = true;
            this.m_btnReset.UseClickedEmphasizeTextColor = false;
            this.m_btnReset.UseCustomizeClickedColor = false;
            this.m_btnReset.UseEdge = true;
            this.m_btnReset.UseHoverEmphasizeCustomColor = false;
            this.m_btnReset.UseImage = true;
            this.m_btnReset.UserHoverEmpahsize = false;
            this.m_btnReset.UseSubFont = false;
            this.m_btnReset.Click += new System.EventHandler(this.Click_OperationButton);
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn6.HeaderText = "COLOR";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 50;
            // 
            // Value
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Value.DefaultCellStyle = dataGridViewCellStyle2;
            this.Value.HeaderText = "VALUE";
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            this.Value.Width = 90;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn1.HeaderText = "NAME";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.ColumnHeadersVisible = false;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Value,
            this.dataGridViewTextBoxColumn6});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView.Location = new System.Drawing.Point(7, 245);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowTemplate.Height = 25;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView.Size = new System.Drawing.Size(269, 108);
            this.dataGridView.TabIndex = 20954;
            // 
            // SB_GraphTime
            // 
            this.SB_GraphTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SB_GraphTime.Enabled = false;
            this.SB_GraphTime.Location = new System.Drawing.Point(277, 321);
            this.SB_GraphTime.Name = "SB_GraphTime";
            this.SB_GraphTime.Size = new System.Drawing.Size(858, 32);
            this.SB_GraphTime.TabIndex = 20950;
            // 
            // _Graph
            // 
            this._Graph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._Graph.Location = new System.Drawing.Point(277, 80);
            this._Graph.Name = "_Graph";
            this._Graph.ScrollGrace = 0D;
            this._Graph.ScrollMaxX = 0D;
            this._Graph.ScrollMaxY = 0D;
            this._Graph.ScrollMaxY2 = 0D;
            this._Graph.ScrollMinX = 0D;
            this._Graph.ScrollMinY = 0D;
            this._Graph.ScrollMinY2 = 0D;
            this._Graph.Size = new System.Drawing.Size(858, 238);
            this._Graph.TabIndex = 20946;
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
            this.sys3GroupBox8.Location = new System.Drawing.Point(3, 48);
            this.sys3GroupBox8.Name = "sys3GroupBox8";
            this.sys3GroupBox8.Size = new System.Drawing.Size(1135, 310);
            this.sys3GroupBox8.TabIndex = 20947;
            this.sys3GroupBox8.Text = "PARAMETER & IR MONITOR";
            this.sys3GroupBox8.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3GroupBox8.ThemeIndex = 0;
            this.sys3GroupBox8.UseLabelBorder = true;
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
            this.btn_ParameterUndo.Location = new System.Drawing.Point(1010, 4);
            this.btn_ParameterUndo.MainFont = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_ParameterUndo.MainFontColor = System.Drawing.Color.White;
            this.btn_ParameterUndo.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.btn_ParameterUndo.Name = "btn_ParameterUndo";
            this.btn_ParameterUndo.Size = new System.Drawing.Size(49, 43);
            this.btn_ParameterUndo.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.btn_ParameterUndo.SubFontColor = System.Drawing.Color.Black;
            this.btn_ParameterUndo.SubText = "";
            this.btn_ParameterUndo.TabIndex = 20996;
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
            this.btn_DecideParameterAll.Location = new System.Drawing.Point(1082, 4);
            this.btn_DecideParameterAll.MainFont = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_DecideParameterAll.MainFontColor = System.Drawing.Color.White;
            this.btn_DecideParameterAll.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.btn_DecideParameterAll.Name = "btn_DecideParameterAll";
            this.btn_DecideParameterAll.Size = new System.Drawing.Size(49, 43);
            this.btn_DecideParameterAll.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.btn_DecideParameterAll.SubFontColor = System.Drawing.Color.Black;
            this.btn_DecideParameterAll.SubText = "";
            this.btn_DecideParameterAll.TabIndex = 20997;
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
            // gridViewControl_AutoRun_Parameter
            // 
            this.gridViewControl_AutoRun_Parameter.Control_Enable = true;
            this.gridViewControl_AutoRun_Parameter.controlCollection = null;
            this.gridViewControl_AutoRun_Parameter.Location = new System.Drawing.Point(7, 80);
            this.gridViewControl_AutoRun_Parameter.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.gridViewControl_AutoRun_Parameter.Name = "gridViewControl_AutoRun_Parameter";
            this.gridViewControl_AutoRun_Parameter.Size = new System.Drawing.Size(269, 100);
            this.gridViewControl_AutoRun_Parameter.TabIndex = 21000;
            // 
            // gridVeiwControl_Laser_Device_2
            // 
            this.gridVeiwControl_Laser_Device_2.Control_Enable = true;
            this.gridVeiwControl_Laser_Device_2.controlCollection = null;
            this.gridVeiwControl_Laser_Device_2.Location = new System.Drawing.Point(204, 716);
            this.gridVeiwControl_Laser_Device_2.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.gridVeiwControl_Laser_Device_2.Name = "gridVeiwControl_Laser_Device_2";
            this.gridVeiwControl_Laser_Device_2.Size = new System.Drawing.Size(513, 178);
            this.gridVeiwControl_Laser_Device_2.TabIndex = 20906;
            // 
            // gridViewControl_Enable_Parameter_2
            // 
            this.gridViewControl_Enable_Parameter_2.Control_Enable = true;
            this.gridViewControl_Enable_Parameter_2.controlCollection = null;
            this.gridViewControl_Enable_Parameter_2.Location = new System.Drawing.Point(204, 662);
            this.gridViewControl_Enable_Parameter_2.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.gridViewControl_Enable_Parameter_2.Name = "gridViewControl_Enable_Parameter_2";
            this.gridViewControl_Enable_Parameter_2.Size = new System.Drawing.Size(932, 53);
            this.gridViewControl_Enable_Parameter_2.TabIndex = 20905;
            // 
            // gridVeiwControl_Laser_Device
            // 
            this.gridVeiwControl_Laser_Device.Control_Enable = true;
            this.gridVeiwControl_Laser_Device.controlCollection = null;
            this.gridVeiwControl_Laser_Device.Location = new System.Drawing.Point(204, 443);
            this.gridVeiwControl_Laser_Device.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.gridVeiwControl_Laser_Device.Name = "gridVeiwControl_Laser_Device";
            this.gridVeiwControl_Laser_Device.Size = new System.Drawing.Size(513, 178);
            this.gridVeiwControl_Laser_Device.TabIndex = 20879;
            // 
            // gridViewControl_Enable_Parameter
            // 
            this.gridViewControl_Enable_Parameter.Control_Enable = true;
            this.gridViewControl_Enable_Parameter.controlCollection = null;
            this.gridViewControl_Enable_Parameter.Location = new System.Drawing.Point(204, 389);
            this.gridViewControl_Enable_Parameter.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.gridViewControl_Enable_Parameter.Name = "gridViewControl_Enable_Parameter";
            this.gridViewControl_Enable_Parameter.Size = new System.Drawing.Size(932, 53);
            this.gridViewControl_Enable_Parameter.TabIndex = 20878;
            // 
            // sys3button1
            // 
            this.sys3button1.BorderWidth = 1;
            this.sys3button1.ButtonClicked = false;
            this.sys3button1.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.sys3button1.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.sys3button1.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.sys3button1.Description = "";
            this.sys3button1.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3button1.EdgeRadius = 5;
            this.sys3button1.GradientAngle = 60F;
            this.sys3button1.GradientFirstColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.sys3button1.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.sys3button1.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.sys3button1.ImagePosition = new System.Drawing.Point(37, 25);
            this.sys3button1.ImageSize = new System.Drawing.Point(30, 30);
            this.sys3button1.LoadImage = null;
            this.sys3button1.Location = new System.Drawing.Point(606, 2);
            this.sys3button1.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3button1.MainFontColor = System.Drawing.Color.White;
            this.sys3button1.Margin = new System.Windows.Forms.Padding(0);
            this.sys3button1.Name = "sys3button1";
            this.sys3button1.Size = new System.Drawing.Size(200, 43);
            this.sys3button1.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.sys3button1.SubFontColor = System.Drawing.Color.Black;
            this.sys3button1.SubText = "";
            this.sys3button1.TabIndex = 10;
            this.sys3button1.Tag = "";
            this.sys3button1.Text = "1 CYCLE TEST SHOT\\n(DOUBLE CLICK)";
            this.sys3button1.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3button1.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3button1.ThemeIndex = 0;
            this.sys3button1.UseBorder = true;
            this.sys3button1.UseClickedEmphasizeTextColor = false;
            this.sys3button1.UseCustomizeClickedColor = false;
            this.sys3button1.UseEdge = true;
            this.sys3button1.UseHoverEmphasizeCustomColor = false;
            this.sys3button1.UseImage = true;
            this.sys3button1.UserHoverEmpahsize = false;
            this.sys3button1.UseSubFont = false;
            this.sys3button1.DoubleClick += new System.EventHandler(this.Click_Action);
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
            this.sys3GroupBox2.Location = new System.Drawing.Point(3, 359);
            this.sys3GroupBox2.Name = "sys3GroupBox2";
            this.sys3GroupBox2.Size = new System.Drawing.Size(199, 213);
            this.sys3GroupBox2.TabIndex = 21002;
            this.sys3GroupBox2.Text = "EXTERNAL PLC IO";
            this.sys3GroupBox2.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3GroupBox2.ThemeIndex = 0;
            this.sys3GroupBox2.UseLabelBorder = true;
            // 
            // gridVeiwControl_External_IO
            // 
            this.gridVeiwControl_External_IO.Control_Enable = true;
            this.gridVeiwControl_External_IO.controlCollection = null;
            this.gridVeiwControl_External_IO.Location = new System.Drawing.Point(7, 389);
            this.gridVeiwControl_External_IO.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.gridVeiwControl_External_IO.Name = "gridVeiwControl_External_IO";
            this.gridVeiwControl_External_IO.Size = new System.Drawing.Size(191, 178);
            this.gridVeiwControl_External_IO.TabIndex = 21003;
            // 
            // m_lblCycleTotal
            // 
            this.m_lblCycleTotal.BackGroundColor = System.Drawing.Color.DimGray;
            this.m_lblCycleTotal.BorderStroke = 2;
            this.m_lblCycleTotal.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblCycleTotal.Description = "";
            this.m_lblCycleTotal.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblCycleTotal.EdgeRadius = 1;
            this.m_lblCycleTotal.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_lblCycleTotal.ImageSize = new System.Drawing.Point(0, 0);
            this.m_lblCycleTotal.LoadImage = null;
            this.m_lblCycleTotal.Location = new System.Drawing.Point(112, 214);
            this.m_lblCycleTotal.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_lblCycleTotal.MainFontColor = System.Drawing.Color.White;
            this.m_lblCycleTotal.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_lblCycleTotal.Name = "m_lblCycleTotal";
            this.m_lblCycleTotal.Size = new System.Drawing.Size(164, 28);
            this.m_lblCycleTotal.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblCycleTotal.SubFontColor = System.Drawing.Color.Gray;
            this.m_lblCycleTotal.SubText = "";
            this.m_lblCycleTotal.TabIndex = 21004;
            this.m_lblCycleTotal.Tag = "";
            this.m_lblCycleTotal.Text = "999999";
            this.m_lblCycleTotal.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblCycleTotal.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblCycleTotal.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblCycleTotal.ThemeIndex = 0;
            this.m_lblCycleTotal.UnitAreaRate = 30;
            this.m_lblCycleTotal.UnitFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.m_lblCycleTotal.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblCycleTotal.UnitPositionVertical = false;
            this.m_lblCycleTotal.UnitText = "ms";
            this.m_lblCycleTotal.UseBorder = true;
            this.m_lblCycleTotal.UseEdgeRadius = false;
            this.m_lblCycleTotal.UseImage = false;
            this.m_lblCycleTotal.UseSubFont = true;
            this.m_lblCycleTotal.UseUnitFont = true;
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
            this.sys3Label1.Location = new System.Drawing.Point(7, 214);
            this.sys3Label1.MainFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label1.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label1.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label1.Name = "sys3Label1";
            this.sys3Label1.Size = new System.Drawing.Size(104, 28);
            this.sys3Label1.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label1.SubFontColor = System.Drawing.Color.DarkRed;
            this.sys3Label1.SubText = "";
            this.sys3Label1.TabIndex = 21005;
            this.sys3Label1.Tag = "";
            this.sys3Label1.Text = "CYCLE TOTAL";
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
            // Operation_Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.sys3Label1);
            this.Controls.Add(this.m_lblCycleTotal);
            this.Controls.Add(this.gridVeiwControl_External_IO);
            this.Controls.Add(this.sys3GroupBox2);
            this.Controls.Add(this.sys3button1);
            this.Controls.Add(this.gridViewControl_AutoRun_Parameter);
            this.Controls.Add(this.btn_ParameterUndo);
            this.Controls.Add(this.btn_DecideParameterAll);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.SB_GraphTime);
            this.Controls.Add(this._Graph);
            this.Controls.Add(this.sys3GroupBox8);
            this.Controls.Add(this.m_btnReset);
            this.Controls.Add(this.btn_EMO_2);
            this.Controls.Add(this.btn_Reset_2);
            this.Controls.Add(this.m_lblAlarmCodeMonitor_2);
            this.Controls.Add(this.m_lblAlarmCodePort3_2);
            this.Controls.Add(this.m_lblAlarmCodePort2_2);
            this.Controls.Add(this.m_lblAlarmCodePort1_2);
            this.Controls.Add(this.sys3Label11);
            this.Controls.Add(this.sys3Label12);
            this.Controls.Add(this.sys3Label15);
            this.Controls.Add(this.sys3Label16);
            this.Controls.Add(this.sys3GroupBox6);
            this.Controls.Add(this.gridVeiwControl_Laser_Device_2);
            this.Controls.Add(this.gridViewControl_Enable_Parameter_2);
            this.Controls.Add(this.sys3GroupBox1);
            this.Controls.Add(this.btn_EMO);
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
            this.Controls.Add(this.gridVeiwControl_Laser_Device);
            this.Controls.Add(this.gridViewControl_Enable_Parameter);
            this.Controls.Add(this.sys3GroupBox5);
            this.Name = "Operation_Main";
            this.Size = new System.Drawing.Size(1140, 900);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

		}

        #endregion
        private Sys3Controls.Sys3GroupBox sys3GroupBox1;
        private Sys3Controls.Sys3button btn_EMO;
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
        private Sys3Controls.Sys3button m_btnStop;
        private Sys3Controls.Sys3button m_btnRun;
        private Component.GridVeiwControl_Device gridVeiwControl_Laser_Device;
        private Component.GridViewControl_Parameter gridViewControl_Enable_Parameter;
        private Sys3Controls.Sys3GroupBox sys3GroupBox5;
        private Sys3Controls.Sys3button btn_EMO_2;
        private Sys3Controls.Sys3button btn_Reset_2;
        private Sys3Controls.Sys3Label m_lblAlarmCodeMonitor_2;
        private Sys3Controls.Sys3Label m_lblAlarmCodePort3_2;
        private Sys3Controls.Sys3Label m_lblAlarmCodePort2_2;
        private Sys3Controls.Sys3Label m_lblAlarmCodePort1_2;
        private Sys3Controls.Sys3Label sys3Label11;
        private Sys3Controls.Sys3Label sys3Label12;
        private Sys3Controls.Sys3Label sys3Label15;
        private Sys3Controls.Sys3Label sys3Label16;
        private Sys3Controls.Sys3GroupBox sys3GroupBox6;
        private Component.GridVeiwControl_Device gridVeiwControl_Laser_Device_2;
        private Component.GridViewControl_Parameter gridViewControl_Enable_Parameter_2;
        private Sys3Controls.Sys3button m_btnReset;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.HScrollBar SB_GraphTime;
        private ZedGraph.ZedGraphControl _Graph;
        private Sys3Controls.Sys3GroupBox sys3GroupBox8;
        private Sys3Controls.Sys3button btn_ParameterUndo;
        private Sys3Controls.Sys3button btn_DecideParameterAll;
        private Component.GridViewControl_Parameter gridViewControl_AutoRun_Parameter;
        private Sys3Controls.Sys3button sys3button1;
        private Sys3Controls.Sys3GroupBox sys3GroupBox2;
        private Component.GridVeiwControl_Device gridVeiwControl_External_IO;
        private Sys3Controls.Sys3Label m_lblCycleTotal;
        private Sys3Controls.Sys3Label sys3Label1;
    }
}
