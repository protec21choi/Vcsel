namespace FrameOfSystem3.Views.Functional
{
    partial class Form_Monitor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BT_Play = new Sys3Controls.Sys3button();
            this.BT_Pause = new Sys3Controls.Sys3button();
            this.BT_Rewind = new Sys3Controls.Sys3button();
            this.sys3Label31 = new Sys3Controls.Sys3Label();
            this.sys3Label28 = new Sys3Controls.Sys3Label();
            this.LB_STEP = new Sys3Controls.Sys3Label();
            this.LB_Time = new Sys3Controls.Sys3Label();
            this.SB_GraphTime = new System.Windows.Forms.HScrollBar();
            this.BT_Load = new Sys3Controls.Sys3button();
            this.btn_Save = new Sys3Controls.Sys3button();
            this.LB_SAVE_STATE = new Sys3Controls.Sys3Label();
            this.sys3Label25 = new Sys3Controls.Sys3Label();
            this._Graph = new ZedGraph.ZedGraphControl();
            this.sys3GroupBox8 = new Sys3Controls.Sys3GroupBox();
            this.sys3button7 = new Sys3Controls.Sys3button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sys3button1 = new Sys3Controls.Sys3button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // BT_Play
            // 
            this.BT_Play.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BT_Play.BorderWidth = 1;
            this.BT_Play.ButtonClicked = false;
            this.BT_Play.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.BT_Play.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.BT_Play.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.BT_Play.Description = "";
            this.BT_Play.DisabledColor = System.Drawing.Color.DarkGray;
            this.BT_Play.EdgeRadius = 1;
            this.BT_Play.Enabled = false;
            this.BT_Play.GradientAngle = 70F;
            this.BT_Play.GradientFirstColor = System.Drawing.Color.White;
            this.BT_Play.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
            this.BT_Play.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.BT_Play.ImagePosition = new System.Drawing.Point(7, 7);
            this.BT_Play.ImageSize = new System.Drawing.Point(30, 30);
            this.BT_Play.LoadImage = global::FrameOfSystem3.Properties.Resources.CONFIG_ADD3;
            this.BT_Play.Location = new System.Drawing.Point(1130, 368);
            this.BT_Play.MainFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.BT_Play.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
            this.BT_Play.Name = "BT_Play";
            this.BT_Play.Size = new System.Drawing.Size(53, 32);
            this.BT_Play.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.BT_Play.SubFontColor = System.Drawing.Color.DarkBlue;
            this.BT_Play.SubText = "STATUS";
            this.BT_Play.TabIndex = 2;
            this.BT_Play.Tag = "";
            this.BT_Play.Text = "▶";
            this.BT_Play.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.BT_Play.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.BT_Play.ThemeIndex = 0;
            this.BT_Play.UseBorder = false;
            this.BT_Play.UseClickedEmphasizeTextColor = false;
            this.BT_Play.UseCustomizeClickedColor = false;
            this.BT_Play.UseEdge = false;
            this.BT_Play.UseHoverEmphasizeCustomColor = false;
            this.BT_Play.UseImage = false;
            this.BT_Play.UserHoverEmpahsize = false;
            this.BT_Play.UseSubFont = false;
            this.BT_Play.Click += new System.EventHandler(this.Click_Graph_Control);
            // 
            // BT_Pause
            // 
            this.BT_Pause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BT_Pause.BorderWidth = 1;
            this.BT_Pause.ButtonClicked = false;
            this.BT_Pause.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.BT_Pause.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.BT_Pause.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.BT_Pause.Description = "";
            this.BT_Pause.DisabledColor = System.Drawing.Color.DarkGray;
            this.BT_Pause.EdgeRadius = 1;
            this.BT_Pause.Enabled = false;
            this.BT_Pause.GradientAngle = 70F;
            this.BT_Pause.GradientFirstColor = System.Drawing.Color.White;
            this.BT_Pause.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
            this.BT_Pause.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.BT_Pause.ImagePosition = new System.Drawing.Point(7, 7);
            this.BT_Pause.ImageSize = new System.Drawing.Point(30, 30);
            this.BT_Pause.LoadImage = global::FrameOfSystem3.Properties.Resources.CONFIG_ADD3;
            this.BT_Pause.Location = new System.Drawing.Point(1076, 368);
            this.BT_Pause.MainFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.BT_Pause.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
            this.BT_Pause.Name = "BT_Pause";
            this.BT_Pause.Size = new System.Drawing.Size(53, 32);
            this.BT_Pause.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.BT_Pause.SubFontColor = System.Drawing.Color.DarkBlue;
            this.BT_Pause.SubText = "STATUS";
            this.BT_Pause.TabIndex = 1;
            this.BT_Pause.Tag = "";
            this.BT_Pause.Text = "■";
            this.BT_Pause.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.BT_Pause.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.BT_Pause.ThemeIndex = 0;
            this.BT_Pause.UseBorder = false;
            this.BT_Pause.UseClickedEmphasizeTextColor = false;
            this.BT_Pause.UseCustomizeClickedColor = false;
            this.BT_Pause.UseEdge = false;
            this.BT_Pause.UseHoverEmphasizeCustomColor = false;
            this.BT_Pause.UseImage = false;
            this.BT_Pause.UserHoverEmpahsize = false;
            this.BT_Pause.UseSubFont = false;
            this.BT_Pause.Click += new System.EventHandler(this.Click_Graph_Control);
            // 
            // BT_Rewind
            // 
            this.BT_Rewind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BT_Rewind.BorderWidth = 1;
            this.BT_Rewind.ButtonClicked = false;
            this.BT_Rewind.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.BT_Rewind.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.BT_Rewind.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.BT_Rewind.Description = "";
            this.BT_Rewind.DisabledColor = System.Drawing.Color.DarkGray;
            this.BT_Rewind.EdgeRadius = 1;
            this.BT_Rewind.Enabled = false;
            this.BT_Rewind.GradientAngle = 70F;
            this.BT_Rewind.GradientFirstColor = System.Drawing.Color.White;
            this.BT_Rewind.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
            this.BT_Rewind.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.BT_Rewind.ImagePosition = new System.Drawing.Point(7, 7);
            this.BT_Rewind.ImageSize = new System.Drawing.Point(30, 30);
            this.BT_Rewind.LoadImage = global::FrameOfSystem3.Properties.Resources.CONFIG_ADD3;
            this.BT_Rewind.Location = new System.Drawing.Point(1022, 368);
            this.BT_Rewind.MainFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.BT_Rewind.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
            this.BT_Rewind.Name = "BT_Rewind";
            this.BT_Rewind.Size = new System.Drawing.Size(53, 32);
            this.BT_Rewind.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.BT_Rewind.SubFontColor = System.Drawing.Color.DarkBlue;
            this.BT_Rewind.SubText = "STATUS";
            this.BT_Rewind.TabIndex = 0;
            this.BT_Rewind.Tag = "";
            this.BT_Rewind.Text = "◀";
            this.BT_Rewind.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.BT_Rewind.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.BT_Rewind.ThemeIndex = 0;
            this.BT_Rewind.UseBorder = false;
            this.BT_Rewind.UseClickedEmphasizeTextColor = false;
            this.BT_Rewind.UseCustomizeClickedColor = false;
            this.BT_Rewind.UseEdge = false;
            this.BT_Rewind.UseHoverEmphasizeCustomColor = false;
            this.BT_Rewind.UseImage = false;
            this.BT_Rewind.UserHoverEmpahsize = false;
            this.BT_Rewind.UseSubFont = false;
            this.BT_Rewind.Click += new System.EventHandler(this.Click_Graph_Control);
            // 
            // sys3Label31
            // 
            this.sys3Label31.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sys3Label31.BackGroundColor = System.Drawing.Color.DarkGray;
            this.sys3Label31.BorderStroke = 2;
            this.sys3Label31.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.sys3Label31.Description = "";
            this.sys3Label31.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3Label31.EdgeRadius = 1;
            this.sys3Label31.ImagePosition = new System.Drawing.Point(0, 0);
            this.sys3Label31.ImageSize = new System.Drawing.Point(0, 0);
            this.sys3Label31.LoadImage = null;
            this.sys3Label31.Location = new System.Drawing.Point(868, 368);
            this.sys3Label31.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label31.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label31.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label31.Name = "sys3Label31";
            this.sys3Label31.Size = new System.Drawing.Size(67, 32);
            this.sys3Label31.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label31.SubFontColor = System.Drawing.Color.Gray;
            this.sys3Label31.SubText = "";
            this.sys3Label31.TabIndex = 20903;
            this.sys3Label31.Tag = "";
            this.sys3Label31.Text = "STEP";
            this.sys3Label31.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3Label31.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.sys3Label31.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label31.ThemeIndex = 0;
            this.sys3Label31.UnitAreaRate = 30;
            this.sys3Label31.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label31.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sys3Label31.UnitPositionVertical = false;
            this.sys3Label31.UnitText = "";
            this.sys3Label31.UseBorder = true;
            this.sys3Label31.UseEdgeRadius = false;
            this.sys3Label31.UseImage = false;
            this.sys3Label31.UseSubFont = true;
            this.sys3Label31.UseUnitFont = false;
            // 
            // sys3Label28
            // 
            this.sys3Label28.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sys3Label28.BackGroundColor = System.Drawing.Color.DarkGray;
            this.sys3Label28.BorderStroke = 2;
            this.sys3Label28.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.sys3Label28.Description = "";
            this.sys3Label28.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3Label28.EdgeRadius = 1;
            this.sys3Label28.ImagePosition = new System.Drawing.Point(0, 0);
            this.sys3Label28.ImageSize = new System.Drawing.Point(0, 0);
            this.sys3Label28.LoadImage = null;
            this.sys3Label28.Location = new System.Drawing.Point(6, 368);
            this.sys3Label28.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label28.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label28.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label28.Name = "sys3Label28";
            this.sys3Label28.Size = new System.Drawing.Size(66, 32);
            this.sys3Label28.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label28.SubFontColor = System.Drawing.Color.Gray;
            this.sys3Label28.SubText = "";
            this.sys3Label28.TabIndex = 20902;
            this.sys3Label28.Tag = "";
            this.sys3Label28.Text = "TIME";
            this.sys3Label28.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3Label28.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.sys3Label28.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label28.ThemeIndex = 0;
            this.sys3Label28.UnitAreaRate = 30;
            this.sys3Label28.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label28.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sys3Label28.UnitPositionVertical = false;
            this.sys3Label28.UnitText = "";
            this.sys3Label28.UseBorder = true;
            this.sys3Label28.UseEdgeRadius = false;
            this.sys3Label28.UseImage = false;
            this.sys3Label28.UseSubFont = true;
            this.sys3Label28.UseUnitFont = false;
            // 
            // LB_STEP
            // 
            this.LB_STEP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LB_STEP.BackGroundColor = System.Drawing.Color.White;
            this.LB_STEP.BorderStroke = 2;
            this.LB_STEP.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.LB_STEP.Description = "";
            this.LB_STEP.DisabledColor = System.Drawing.Color.DarkGray;
            this.LB_STEP.EdgeRadius = 1;
            this.LB_STEP.Enabled = false;
            this.LB_STEP.ImagePosition = new System.Drawing.Point(0, 0);
            this.LB_STEP.ImageSize = new System.Drawing.Point(0, 0);
            this.LB_STEP.LoadImage = null;
            this.LB_STEP.Location = new System.Drawing.Point(936, 368);
            this.LB_STEP.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LB_STEP.MainFontColor = System.Drawing.Color.Black;
            this.LB_STEP.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.LB_STEP.Name = "LB_STEP";
            this.LB_STEP.Size = new System.Drawing.Size(83, 32);
            this.LB_STEP.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LB_STEP.SubFontColor = System.Drawing.Color.Gray;
            this.LB_STEP.SubText = "";
            this.LB_STEP.TabIndex = 10;
            this.LB_STEP.Tag = "";
            this.LB_STEP.Text = "1";
            this.LB_STEP.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.LB_STEP.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.LB_STEP.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.LB_STEP.ThemeIndex = 0;
            this.LB_STEP.UnitAreaRate = 30;
            this.LB_STEP.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LB_STEP.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.LB_STEP.UnitPositionVertical = false;
            this.LB_STEP.UnitText = "℃";
            this.LB_STEP.UseBorder = true;
            this.LB_STEP.UseEdgeRadius = false;
            this.LB_STEP.UseImage = false;
            this.LB_STEP.UseSubFont = true;
            this.LB_STEP.UseUnitFont = false;
            this.LB_STEP.Click += new System.EventHandler(this.Click_Graph_Control);
            // 
            // LB_Time
            // 
            this.LB_Time.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LB_Time.BackGroundColor = System.Drawing.Color.DarkGray;
            this.LB_Time.BorderStroke = 2;
            this.LB_Time.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.LB_Time.Description = "";
            this.LB_Time.DisabledColor = System.Drawing.Color.DarkGray;
            this.LB_Time.EdgeRadius = 1;
            this.LB_Time.ImagePosition = new System.Drawing.Point(0, 0);
            this.LB_Time.ImageSize = new System.Drawing.Point(0, 0);
            this.LB_Time.LoadImage = null;
            this.LB_Time.Location = new System.Drawing.Point(73, 368);
            this.LB_Time.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LB_Time.MainFontColor = System.Drawing.Color.Black;
            this.LB_Time.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.LB_Time.Name = "LB_Time";
            this.LB_Time.Size = new System.Drawing.Size(83, 32);
            this.LB_Time.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LB_Time.SubFontColor = System.Drawing.Color.Gray;
            this.LB_Time.SubText = "";
            this.LB_Time.TabIndex = 20890;
            this.LB_Time.Tag = "TIME";
            this.LB_Time.Text = "9999";
            this.LB_Time.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.LB_Time.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.LB_Time.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.LB_Time.ThemeIndex = 0;
            this.LB_Time.UnitAreaRate = 30;
            this.LB_Time.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LB_Time.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.LB_Time.UnitPositionVertical = false;
            this.LB_Time.UnitText = "℃";
            this.LB_Time.UseBorder = true;
            this.LB_Time.UseEdgeRadius = false;
            this.LB_Time.UseImage = false;
            this.LB_Time.UseSubFont = true;
            this.LB_Time.UseUnitFont = false;
            // 
            // SB_GraphTime
            // 
            this.SB_GraphTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SB_GraphTime.Enabled = false;
            this.SB_GraphTime.Location = new System.Drawing.Point(158, 368);
            this.SB_GraphTime.Name = "SB_GraphTime";
            this.SB_GraphTime.Size = new System.Drawing.Size(708, 32);
            this.SB_GraphTime.TabIndex = 20889;
            this.SB_GraphTime.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrollTime);
            // 
            // BT_Load
            // 
            this.BT_Load.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BT_Load.BorderWidth = 5;
            this.BT_Load.ButtonClicked = false;
            this.BT_Load.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.BT_Load.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.BT_Load.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.BT_Load.Description = "";
            this.BT_Load.DisabledColor = System.Drawing.Color.DarkGray;
            this.BT_Load.EdgeRadius = 1;
            this.BT_Load.GradientAngle = 60F;
            this.BT_Load.GradientFirstColor = System.Drawing.Color.WhiteSmoke;
            this.BT_Load.GradientSecondColor = System.Drawing.Color.DimGray;
            this.BT_Load.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.BT_Load.ImagePosition = new System.Drawing.Point(37, 25);
            this.BT_Load.ImageSize = new System.Drawing.Point(30, 30);
            this.BT_Load.LoadImage = null;
            this.BT_Load.Location = new System.Drawing.Point(258, 401);
            this.BT_Load.MainFont = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BT_Load.MainFontColor = System.Drawing.Color.White;
            this.BT_Load.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.BT_Load.Name = "BT_Load";
            this.BT_Load.Size = new System.Drawing.Size(99, 49);
            this.BT_Load.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.BT_Load.SubFontColor = System.Drawing.Color.Black;
            this.BT_Load.SubText = "";
            this.BT_Load.TabIndex = 20883;
            this.BT_Load.Text = "LOAD";
            this.BT_Load.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.BT_Load.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.BT_Load.ThemeIndex = 0;
            this.BT_Load.UseBorder = true;
            this.BT_Load.UseClickedEmphasizeTextColor = false;
            this.BT_Load.UseCustomizeClickedColor = false;
            this.BT_Load.UseEdge = true;
            this.BT_Load.UseHoverEmphasizeCustomColor = false;
            this.BT_Load.UseImage = true;
            this.BT_Load.UserHoverEmpahsize = false;
            this.BT_Load.UseSubFont = false;
            this.BT_Load.Click += new System.EventHandler(this.Click_Load);
            // 
            // btn_Save
            // 
            this.btn_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Save.BorderWidth = 5;
            this.btn_Save.ButtonClicked = false;
            this.btn_Save.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.btn_Save.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.btn_Save.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.btn_Save.Description = "";
            this.btn_Save.DisabledColor = System.Drawing.Color.DarkGray;
            this.btn_Save.EdgeRadius = 1;
            this.btn_Save.GradientAngle = 60F;
            this.btn_Save.GradientFirstColor = System.Drawing.Color.WhiteSmoke;
            this.btn_Save.GradientSecondColor = System.Drawing.Color.DimGray;
            this.btn_Save.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.btn_Save.ImagePosition = new System.Drawing.Point(37, 25);
            this.btn_Save.ImageSize = new System.Drawing.Point(30, 30);
            this.btn_Save.LoadImage = null;
            this.btn_Save.Location = new System.Drawing.Point(358, 401);
            this.btn_Save.MainFont = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Save.MainFontColor = System.Drawing.Color.White;
            this.btn_Save.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(100, 49);
            this.btn_Save.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.btn_Save.SubFontColor = System.Drawing.Color.Black;
            this.btn_Save.SubText = "";
            this.btn_Save.TabIndex = 20882;
            this.btn_Save.Text = "SAVE";
            this.btn_Save.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.btn_Save.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.btn_Save.ThemeIndex = 0;
            this.btn_Save.UseBorder = true;
            this.btn_Save.UseClickedEmphasizeTextColor = false;
            this.btn_Save.UseCustomizeClickedColor = false;
            this.btn_Save.UseEdge = true;
            this.btn_Save.UseHoverEmphasizeCustomColor = false;
            this.btn_Save.UseImage = true;
            this.btn_Save.UserHoverEmpahsize = false;
            this.btn_Save.UseSubFont = false;
            this.btn_Save.Click += new System.EventHandler(this.Click_Save);
            // 
            // LB_SAVE_STATE
            // 
            this.LB_SAVE_STATE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LB_SAVE_STATE.BackGroundColor = System.Drawing.Color.DimGray;
            this.LB_SAVE_STATE.BorderStroke = 2;
            this.LB_SAVE_STATE.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.LB_SAVE_STATE.Description = "";
            this.LB_SAVE_STATE.DisabledColor = System.Drawing.Color.DarkGray;
            this.LB_SAVE_STATE.EdgeRadius = 1;
            this.LB_SAVE_STATE.ImagePosition = new System.Drawing.Point(0, 0);
            this.LB_SAVE_STATE.ImageSize = new System.Drawing.Point(0, 0);
            this.LB_SAVE_STATE.LoadImage = null;
            this.LB_SAVE_STATE.Location = new System.Drawing.Point(72, 401);
            this.LB_SAVE_STATE.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.LB_SAVE_STATE.MainFontColor = System.Drawing.Color.White;
            this.LB_SAVE_STATE.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.LB_SAVE_STATE.Name = "LB_SAVE_STATE";
            this.LB_SAVE_STATE.Size = new System.Drawing.Size(84, 48);
            this.LB_SAVE_STATE.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LB_SAVE_STATE.SubFontColor = System.Drawing.Color.Gray;
            this.LB_SAVE_STATE.SubText = "";
            this.LB_SAVE_STATE.TabIndex = 20861;
            this.LB_SAVE_STATE.Tag = "";
            this.LB_SAVE_STATE.Text = "9999.9";
            this.LB_SAVE_STATE.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.LB_SAVE_STATE.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.LB_SAVE_STATE.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.LB_SAVE_STATE.ThemeIndex = 0;
            this.LB_SAVE_STATE.UnitAreaRate = 30;
            this.LB_SAVE_STATE.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LB_SAVE_STATE.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.LB_SAVE_STATE.UnitPositionVertical = false;
            this.LB_SAVE_STATE.UnitText = "℃";
            this.LB_SAVE_STATE.UseBorder = true;
            this.LB_SAVE_STATE.UseEdgeRadius = false;
            this.LB_SAVE_STATE.UseImage = false;
            this.LB_SAVE_STATE.UseSubFont = true;
            this.LB_SAVE_STATE.UseUnitFont = false;
            // 
            // sys3Label25
            // 
            this.sys3Label25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sys3Label25.BackGroundColor = System.Drawing.Color.DarkGray;
            this.sys3Label25.BorderStroke = 2;
            this.sys3Label25.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.sys3Label25.Description = "";
            this.sys3Label25.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3Label25.EdgeRadius = 1;
            this.sys3Label25.ImagePosition = new System.Drawing.Point(0, 0);
            this.sys3Label25.ImageSize = new System.Drawing.Point(0, 0);
            this.sys3Label25.LoadImage = null;
            this.sys3Label25.Location = new System.Drawing.Point(6, 401);
            this.sys3Label25.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label25.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label25.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label25.Name = "sys3Label25";
            this.sys3Label25.Size = new System.Drawing.Size(65, 48);
            this.sys3Label25.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label25.SubFontColor = System.Drawing.Color.Gray;
            this.sys3Label25.SubText = "";
            this.sys3Label25.TabIndex = 20879;
            this.sys3Label25.Tag = "";
            this.sys3Label25.Text = "STATE";
            this.sys3Label25.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label25.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.sys3Label25.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label25.ThemeIndex = 0;
            this.sys3Label25.UnitAreaRate = 30;
            this.sys3Label25.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label25.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sys3Label25.UnitPositionVertical = false;
            this.sys3Label25.UnitText = "";
            this.sys3Label25.UseBorder = true;
            this.sys3Label25.UseEdgeRadius = false;
            this.sys3Label25.UseImage = false;
            this.sys3Label25.UseSubFont = true;
            this.sys3Label25.UseUnitFont = false;
            // 
            // _Graph
            // 
            this._Graph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._Graph.Location = new System.Drawing.Point(6, 34);
            this._Graph.Name = "_Graph";
            this._Graph.ScrollGrace = 0D;
            this._Graph.ScrollMaxX = 0D;
            this._Graph.ScrollMaxY = 0D;
            this._Graph.ScrollMaxY2 = 0D;
            this._Graph.ScrollMinX = 0D;
            this._Graph.ScrollMinY = 0D;
            this._Graph.ScrollMinY2 = 0D;
            this._Graph.Size = new System.Drawing.Size(860, 328);
            this._Graph.TabIndex = 20876;
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
            this.sys3GroupBox8.Location = new System.Drawing.Point(2, 2);
            this.sys3GroupBox8.Name = "sys3GroupBox8";
            this.sys3GroupBox8.Size = new System.Drawing.Size(1184, 364);
            this.sys3GroupBox8.TabIndex = 20877;
            this.sys3GroupBox8.Text = "GRPAH";
            this.sys3GroupBox8.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3GroupBox8.ThemeIndex = 0;
            this.sys3GroupBox8.UseLabelBorder = true;
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
            this.sys3button7.Location = new System.Drawing.Point(1053, 401);
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
            this.dataGridView.Location = new System.Drawing.Point(868, 34);
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
            this.dataGridView.Size = new System.Drawing.Size(314, 328);
            this.dataGridView.TabIndex = 20940;
            this.dataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ClickGrid);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn1.HeaderText = "NAME";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
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
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn6.HeaderText = "COLOR";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 50;
            // 
            // sys3button1
            // 
            this.sys3button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sys3button1.BorderWidth = 5;
            this.sys3button1.ButtonClicked = false;
            this.sys3button1.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.sys3button1.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.sys3button1.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.sys3button1.Description = "";
            this.sys3button1.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3button1.EdgeRadius = 1;
            this.sys3button1.GradientAngle = 60F;
            this.sys3button1.GradientFirstColor = System.Drawing.Color.WhiteSmoke;
            this.sys3button1.GradientSecondColor = System.Drawing.Color.DimGray;
            this.sys3button1.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.sys3button1.ImagePosition = new System.Drawing.Point(37, 25);
            this.sys3button1.ImageSize = new System.Drawing.Point(30, 30);
            this.sys3button1.LoadImage = null;
            this.sys3button1.Location = new System.Drawing.Point(158, 401);
            this.sys3button1.MainFont = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sys3button1.MainFontColor = System.Drawing.Color.White;
            this.sys3button1.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3button1.Name = "sys3button1";
            this.sys3button1.Size = new System.Drawing.Size(99, 49);
            this.sys3button1.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.sys3button1.SubFontColor = System.Drawing.Color.Black;
            this.sys3button1.SubText = "";
            this.sys3button1.TabIndex = 20883;
            this.sys3button1.Text = "LIVE";
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
            this.sys3button1.Click += new System.EventHandler(this.Click_Live);
            // 
            // Form_Monitor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1187, 451);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.BT_Play);
            this.Controls.Add(this.BT_Pause);
            this.Controls.Add(this.BT_Rewind);
            this.Controls.Add(this.sys3Label31);
            this.Controls.Add(this.sys3Label28);
            this.Controls.Add(this.LB_STEP);
            this.Controls.Add(this.LB_Time);
            this.Controls.Add(this.SB_GraphTime);
            this.Controls.Add(this.sys3button7);
            this.Controls.Add(this.sys3button1);
            this.Controls.Add(this.BT_Load);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.LB_SAVE_STATE);
            this.Controls.Add(this.sys3Label25);
            this.Controls.Add(this._Graph);
            this.Controls.Add(this.sys3GroupBox8);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Monitor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MORNITOR";
            this.TopMost = true;
            this.Resize += new System.EventHandler(this.Form_Monitor_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private Sys3Controls.Sys3button BT_Play;
        private Sys3Controls.Sys3button BT_Pause;
        private Sys3Controls.Sys3button BT_Rewind;
        private Sys3Controls.Sys3Label sys3Label31;
        private Sys3Controls.Sys3Label sys3Label28;
        private Sys3Controls.Sys3Label LB_STEP;
        private Sys3Controls.Sys3Label LB_Time;
        private System.Windows.Forms.HScrollBar SB_GraphTime;
        private Sys3Controls.Sys3button BT_Load;
        private Sys3Controls.Sys3button btn_Save;
        private Sys3Controls.Sys3Label LB_SAVE_STATE;
        private Sys3Controls.Sys3Label sys3Label25;
        private ZedGraph.ZedGraphControl _Graph;
        private Sys3Controls.Sys3GroupBox sys3GroupBox8;
        private Sys3Controls.Sys3button sys3button7;
        private System.Windows.Forms.DataGridView dataGridView;
        private Sys3Controls.Sys3button sys3button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;


    }
}