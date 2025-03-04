namespace FrameOfSystem3.Views.Operation
{
	partial class Operation_Tracking
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Operation_Tracking));
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.m_btnAdd1 = new Sys3Controls.Sys3button();
            this.sys3GroupBox3 = new Sys3Controls.Sys3GroupBox();
            this.m_btnAdd3 = new Sys3Controls.Sys3button();
            this.m_btnAdd4 = new Sys3Controls.Sys3button();
            this.m_btnAdd2 = new Sys3Controls.Sys3button();
            this.sys3button1 = new Sys3Controls.Sys3button();
            this.sys3GroupBox1 = new Sys3Controls.Sys3GroupBox();
            this.m_ToggleInputOnDelay = new Sys3Controls.Sys3ToggleButton();
            this.m_labelStart = new Sys3Controls.Sys3Label();
            this.sys3GroupBox2 = new Sys3Controls.Sys3GroupBox();
            this.sys3Label1 = new Sys3Controls.Sys3Label();
            this.sys3Label2 = new Sys3Controls.Sys3Label();
            this.sys3Label3 = new Sys3Controls.Sys3Label();
            this.sys3Label4 = new Sys3Controls.Sys3Label();
            this.SuspendLayout();
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(3, 30);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(1033, 726);
            this.zedGraphControl1.TabIndex = 0;
            // 
            // m_btnAdd1
            // 
            this.m_btnAdd1.BorderWidth = 3;
            this.m_btnAdd1.ButtonClicked = false;
            this.m_btnAdd1.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_btnAdd1.EdgeRadius = 5;
            this.m_btnAdd1.GradientAngle = 50F;
            this.m_btnAdd1.GradientFirstColor = System.Drawing.Color.White;
            this.m_btnAdd1.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
            this.m_btnAdd1.ImagePosition = new System.Drawing.Point(12, 10);
            this.m_btnAdd1.ImageSize = new System.Drawing.Point(30, 30);
            this.m_btnAdd1.LoadImage = global::FrameOfSystem3.Properties.Resources.CONFIG_ADD3;
            this.m_btnAdd1.Location = new System.Drawing.Point(6, 791);
            this.m_btnAdd1.MainFont = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.m_btnAdd1.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
            this.m_btnAdd1.Name = "m_btnAdd1";
            this.m_btnAdd1.Size = new System.Drawing.Size(164, 102);
            this.m_btnAdd1.SubFont = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.m_btnAdd1.SubFontColor = System.Drawing.Color.DarkBlue;
            this.m_btnAdd1.SubText = "MOTION";
            this.m_btnAdd1.TabIndex = 0;
            this.m_btnAdd1.Text = "\\nADD";
            this.m_btnAdd1.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.m_btnAdd1.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_RIGHT;
            this.m_btnAdd1.UseBorder = true;
            this.m_btnAdd1.UseEdge = true;
            this.m_btnAdd1.UseImage = true;
            this.m_btnAdd1.UseSubFont = true;
            this.m_btnAdd1.Click += new System.EventHandler(this.Click_AddButton);
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
            this.sys3GroupBox3.Location = new System.Drawing.Point(0, 0);
            this.sys3GroupBox3.Name = "sys3GroupBox3";
            this.sys3GroupBox3.Size = new System.Drawing.Size(1140, 900);
            this.sys3GroupBox3.TabIndex = 1353;
            this.sys3GroupBox3.Text = "DEVICE VIEW";
            this.sys3GroupBox3.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3GroupBox3.UseLabelBorder = true;
            // 
            // m_btnAdd3
            // 
            this.m_btnAdd3.BorderWidth = 3;
            this.m_btnAdd3.ButtonClicked = false;
            this.m_btnAdd3.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_btnAdd3.EdgeRadius = 5;
            this.m_btnAdd3.GradientAngle = 50F;
            this.m_btnAdd3.GradientFirstColor = System.Drawing.Color.White;
            this.m_btnAdd3.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
            this.m_btnAdd3.ImagePosition = new System.Drawing.Point(12, 10);
            this.m_btnAdd3.ImageSize = new System.Drawing.Point(30, 30);
            this.m_btnAdd3.LoadImage = ((System.Drawing.Image)(resources.GetObject("m_btnAdd3.LoadImage")));
            this.m_btnAdd3.Location = new System.Drawing.Point(171, 791);
            this.m_btnAdd3.MainFont = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.m_btnAdd3.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
            this.m_btnAdd3.Name = "m_btnAdd3";
            this.m_btnAdd3.Size = new System.Drawing.Size(164, 102);
            this.m_btnAdd3.SubFont = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.m_btnAdd3.SubFontColor = System.Drawing.Color.DarkBlue;
            this.m_btnAdd3.SubText = "DIGITAL";
            this.m_btnAdd3.TabIndex = 1;
            this.m_btnAdd3.Text = "\\nADD";
            this.m_btnAdd3.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.m_btnAdd3.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_RIGHT;
            this.m_btnAdd3.UseBorder = true;
            this.m_btnAdd3.UseEdge = true;
            this.m_btnAdd3.UseImage = true;
            this.m_btnAdd3.UseSubFont = true;
            this.m_btnAdd3.Click += new System.EventHandler(this.Click_AddButton);
            // 
            // m_btnAdd4
            // 
            this.m_btnAdd4.BorderWidth = 3;
            this.m_btnAdd4.ButtonClicked = false;
            this.m_btnAdd4.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_btnAdd4.EdgeRadius = 5;
            this.m_btnAdd4.GradientAngle = 50F;
            this.m_btnAdd4.GradientFirstColor = System.Drawing.Color.White;
            this.m_btnAdd4.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
            this.m_btnAdd4.ImagePosition = new System.Drawing.Point(12, 10);
            this.m_btnAdd4.ImageSize = new System.Drawing.Point(30, 30);
            this.m_btnAdd4.LoadImage = ((System.Drawing.Image)(resources.GetObject("m_btnAdd4.LoadImage")));
            this.m_btnAdd4.Location = new System.Drawing.Point(501, 791);
            this.m_btnAdd4.MainFont = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.m_btnAdd4.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
            this.m_btnAdd4.Name = "m_btnAdd4";
            this.m_btnAdd4.Size = new System.Drawing.Size(164, 102);
            this.m_btnAdd4.SubFont = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.m_btnAdd4.SubFontColor = System.Drawing.Color.DarkBlue;
            this.m_btnAdd4.SubText = "CYLINDER";
            this.m_btnAdd4.TabIndex = 3;
            this.m_btnAdd4.Text = "\\nADD";
            this.m_btnAdd4.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.m_btnAdd4.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_RIGHT;
            this.m_btnAdd4.UseBorder = true;
            this.m_btnAdd4.UseEdge = true;
            this.m_btnAdd4.UseImage = true;
            this.m_btnAdd4.UseSubFont = true;
            this.m_btnAdd4.Click += new System.EventHandler(this.Click_AddButton);
            // 
            // m_btnAdd2
            // 
            this.m_btnAdd2.BorderWidth = 3;
            this.m_btnAdd2.ButtonClicked = false;
            this.m_btnAdd2.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_btnAdd2.EdgeRadius = 5;
            this.m_btnAdd2.GradientAngle = 50F;
            this.m_btnAdd2.GradientFirstColor = System.Drawing.Color.White;
            this.m_btnAdd2.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
            this.m_btnAdd2.ImagePosition = new System.Drawing.Point(12, 10);
            this.m_btnAdd2.ImageSize = new System.Drawing.Point(30, 30);
            this.m_btnAdd2.LoadImage = ((System.Drawing.Image)(resources.GetObject("m_btnAdd2.LoadImage")));
            this.m_btnAdd2.Location = new System.Drawing.Point(336, 791);
            this.m_btnAdd2.MainFont = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.m_btnAdd2.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
            this.m_btnAdd2.Name = "m_btnAdd2";
            this.m_btnAdd2.Size = new System.Drawing.Size(164, 102);
            this.m_btnAdd2.SubFont = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.m_btnAdd2.SubFontColor = System.Drawing.Color.DarkBlue;
            this.m_btnAdd2.SubText = "ANALOG";
            this.m_btnAdd2.TabIndex = 2;
            this.m_btnAdd2.Text = "\\nADD";
            this.m_btnAdd2.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.m_btnAdd2.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_RIGHT;
            this.m_btnAdd2.UseBorder = true;
            this.m_btnAdd2.UseEdge = true;
            this.m_btnAdd2.UseImage = true;
            this.m_btnAdd2.UseSubFont = true;
            this.m_btnAdd2.Click += new System.EventHandler(this.Click_AddButton);
            // 
            // sys3button1
            // 
            this.sys3button1.BorderWidth = 3;
            this.sys3button1.ButtonClicked = false;
            this.sys3button1.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3button1.EdgeRadius = 5;
            this.sys3button1.GradientAngle = 70F;
            this.sys3button1.GradientFirstColor = System.Drawing.Color.White;
            this.sys3button1.GradientSecondColor = System.Drawing.Color.LightSlateGray;
            this.sys3button1.ImagePosition = new System.Drawing.Point(10, 10);
            this.sys3button1.ImageSize = new System.Drawing.Point(30, 30);
            this.sys3button1.LoadImage = global::FrameOfSystem3.Properties.Resources.CLEAR_BLACK;
            this.sys3button1.Location = new System.Drawing.Point(994, 789);
            this.sys3button1.MainFont = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.sys3button1.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
            this.sys3button1.Name = "sys3button1";
            this.sys3button1.Size = new System.Drawing.Size(141, 104);
            this.sys3button1.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.sys3button1.SubFontColor = System.Drawing.Color.DarkBlue;
            this.sys3button1.SubText = "STATUS";
            this.sys3button1.TabIndex = 9;
            this.sys3button1.Text = "CLEAR ITEM";
            this.sys3button1.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3button1.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.sys3button1.UseBorder = true;
            this.sys3button1.UseEdge = true;
            this.sys3button1.UseImage = false;
            this.sys3button1.UseSubFont = false;
            this.sys3button1.Click += new System.EventHandler(this.Click_ClearItem);
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
            this.sys3GroupBox1.Location = new System.Drawing.Point(1, 755);
            this.sys3GroupBox1.Name = "sys3GroupBox1";
            this.sys3GroupBox1.Size = new System.Drawing.Size(1138, 144);
            this.sys3GroupBox1.TabIndex = 1354;
            this.sys3GroupBox1.Text = "DEVICE ITEM";
            this.sys3GroupBox1.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3GroupBox1.UseLabelBorder = true;
            // 
            // m_ToggleInputOnDelay
            // 
            this.m_ToggleInputOnDelay.Active = false;
            this.m_ToggleInputOnDelay.ActiveColorFirst = System.Drawing.Color.RoyalBlue;
            this.m_ToggleInputOnDelay.ActiveColorSecond = System.Drawing.Color.DodgerBlue;
            this.m_ToggleInputOnDelay.BackColor = System.Drawing.Color.WhiteSmoke;
            this.m_ToggleInputOnDelay.Location = new System.Drawing.Point(875, 828);
            this.m_ToggleInputOnDelay.Name = "m_ToggleInputOnDelay";
            this.m_ToggleInputOnDelay.NormalColorFirst = System.Drawing.Color.DarkGray;
            this.m_ToggleInputOnDelay.NormalColorSecond = System.Drawing.Color.Silver;
            this.m_ToggleInputOnDelay.Size = new System.Drawing.Size(112, 56);
            this.m_ToggleInputOnDelay.TabIndex = 1355;
            this.m_ToggleInputOnDelay.Click += new System.EventHandler(this.Click_ToggleButton);
            this.m_ToggleInputOnDelay.DoubleClick += new System.EventHandler(this.Click_ToggleButton);
            // 
            // m_labelStart
            // 
            this.m_labelStart.BackGroundColor = System.Drawing.Color.WhiteSmoke;
            this.m_labelStart.BorderStroke = 2;
            this.m_labelStart.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_labelStart.DisabledColor = System.Drawing.Color.Silver;
            this.m_labelStart.EdgeRadius = 1;
            this.m_labelStart.Location = new System.Drawing.Point(774, 821);
            this.m_labelStart.MainFont = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.m_labelStart.MainFontColor = System.Drawing.Color.Black;
            this.m_labelStart.Name = "m_labelStart";
            this.m_labelStart.Size = new System.Drawing.Size(217, 74);
            this.m_labelStart.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.m_labelStart.SubFontColor = System.Drawing.Color.Black;
            this.m_labelStart.SubText = "";
            this.m_labelStart.TabIndex = 1356;
            this.m_labelStart.Text = "OFF / ON";
            this.m_labelStart.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_LEFT;
            this.m_labelStart.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_labelStart.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_labelStart.UnitAreaRate = 40;
            this.m_labelStart.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_labelStart.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_labelStart.UnitPositionVertical = false;
            this.m_labelStart.UnitText = "";
            this.m_labelStart.UseBorder = true;
            this.m_labelStart.UseEdgeRadius = false;
            this.m_labelStart.UseSubFont = false;
            this.m_labelStart.UseUnitFont = false;
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
            this.sys3GroupBox2.Location = new System.Drawing.Point(772, 790);
            this.sys3GroupBox2.Name = "sys3GroupBox2";
            this.sys3GroupBox2.Size = new System.Drawing.Size(220, 104);
            this.sys3GroupBox2.TabIndex = 1357;
            this.sys3GroupBox2.Text = "TRACKING";
            this.sys3GroupBox2.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3GroupBox2.UseLabelBorder = true;
            // 
            // sys3Label1
            // 
            this.sys3Label1.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
            this.sys3Label1.BorderStroke = 2;
            this.sys3Label1.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.sys3Label1.DisabledColor = System.Drawing.Color.Silver;
            this.sys3Label1.EdgeRadius = 1;
            this.sys3Label1.Location = new System.Drawing.Point(1041, 162);
            this.sys3Label1.MainFont = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.sys3Label1.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label1.Name = "sys3Label1";
            this.sys3Label1.Size = new System.Drawing.Size(93, 122);
            this.sys3Label1.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.sys3Label1.SubFontColor = System.Drawing.Color.Black;
            this.sys3Label1.SubText = "";
            this.sys3Label1.TabIndex = 1358;
            this.sys3Label1.Text = "CYLINDER";
            this.sys3Label1.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label1.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label1.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label1.UnitAreaRate = 40;
            this.sys3Label1.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label1.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sys3Label1.UnitPositionVertical = false;
            this.sys3Label1.UnitText = "";
            this.sys3Label1.UseBorder = true;
            this.sys3Label1.UseEdgeRadius = false;
            this.sys3Label1.UseSubFont = false;
            this.sys3Label1.UseUnitFont = false;
            // 
            // sys3Label2
            // 
            this.sys3Label2.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
            this.sys3Label2.BorderStroke = 2;
            this.sys3Label2.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.sys3Label2.DisabledColor = System.Drawing.Color.Silver;
            this.sys3Label2.EdgeRadius = 1;
            this.sys3Label2.Location = new System.Drawing.Point(1041, 288);
            this.sys3Label2.MainFont = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.sys3Label2.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label2.Name = "sys3Label2";
            this.sys3Label2.Size = new System.Drawing.Size(93, 122);
            this.sys3Label2.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.sys3Label2.SubFontColor = System.Drawing.Color.Black;
            this.sys3Label2.SubText = "";
            this.sys3Label2.TabIndex = 1358;
            this.sys3Label2.Text = "ANALOG";
            this.sys3Label2.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label2.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label2.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label2.UnitAreaRate = 40;
            this.sys3Label2.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label2.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sys3Label2.UnitPositionVertical = false;
            this.sys3Label2.UnitText = "";
            this.sys3Label2.UseBorder = true;
            this.sys3Label2.UseEdgeRadius = false;
            this.sys3Label2.UseSubFont = false;
            this.sys3Label2.UseUnitFont = false;
            // 
            // sys3Label3
            // 
            this.sys3Label3.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
            this.sys3Label3.BorderStroke = 2;
            this.sys3Label3.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.sys3Label3.DisabledColor = System.Drawing.Color.Silver;
            this.sys3Label3.EdgeRadius = 1;
            this.sys3Label3.Location = new System.Drawing.Point(1041, 414);
            this.sys3Label3.MainFont = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.sys3Label3.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label3.Name = "sys3Label3";
            this.sys3Label3.Size = new System.Drawing.Size(93, 122);
            this.sys3Label3.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.sys3Label3.SubFontColor = System.Drawing.Color.Black;
            this.sys3Label3.SubText = "";
            this.sys3Label3.TabIndex = 1358;
            this.sys3Label3.Text = "DIGITAL";
            this.sys3Label3.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label3.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label3.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label3.UnitAreaRate = 40;
            this.sys3Label3.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label3.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sys3Label3.UnitPositionVertical = false;
            this.sys3Label3.UnitText = "";
            this.sys3Label3.UseBorder = true;
            this.sys3Label3.UseEdgeRadius = false;
            this.sys3Label3.UseSubFont = false;
            this.sys3Label3.UseUnitFont = false;
            // 
            // sys3Label4
            // 
            this.sys3Label4.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
            this.sys3Label4.BorderStroke = 2;
            this.sys3Label4.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.sys3Label4.DisabledColor = System.Drawing.Color.Silver;
            this.sys3Label4.EdgeRadius = 1;
            this.sys3Label4.Location = new System.Drawing.Point(1041, 540);
            this.sys3Label4.MainFont = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.sys3Label4.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label4.Name = "sys3Label4";
            this.sys3Label4.Size = new System.Drawing.Size(93, 122);
            this.sys3Label4.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.sys3Label4.SubFontColor = System.Drawing.Color.Black;
            this.sys3Label4.SubText = "";
            this.sys3Label4.TabIndex = 1358;
            this.sys3Label4.Text = "MOTION";
            this.sys3Label4.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label4.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label4.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label4.UnitAreaRate = 40;
            this.sys3Label4.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label4.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sys3Label4.UnitPositionVertical = false;
            this.sys3Label4.UnitText = "";
            this.sys3Label4.UseBorder = true;
            this.sys3Label4.UseEdgeRadius = false;
            this.sys3Label4.UseSubFont = false;
            this.sys3Label4.UseUnitFont = false;
            // 
            // Operation_Tracking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.sys3Label4);
            this.Controls.Add(this.sys3Label3);
            this.Controls.Add(this.sys3Label2);
            this.Controls.Add(this.sys3Label1);
            this.Controls.Add(this.m_ToggleInputOnDelay);
            this.Controls.Add(this.m_labelStart);
            this.Controls.Add(this.sys3GroupBox2);
            this.Controls.Add(this.sys3button1);
            this.Controls.Add(this.m_btnAdd4);
            this.Controls.Add(this.m_btnAdd2);
            this.Controls.Add(this.m_btnAdd3);
            this.Controls.Add(this.m_btnAdd1);
            this.Controls.Add(this.sys3GroupBox1);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.sys3GroupBox3);
            this.Name = "Operation_Tracking";
            this.Size = new System.Drawing.Size(1140, 900);
            this.ResumeLayout(false);

		}

		#endregion

		private ZedGraph.ZedGraphControl zedGraphControl1;
		private Sys3Controls.Sys3button m_btnAdd1;
		private Sys3Controls.Sys3GroupBox sys3GroupBox3;
		private Sys3Controls.Sys3button m_btnAdd3;
		private Sys3Controls.Sys3button m_btnAdd4;
		private Sys3Controls.Sys3button m_btnAdd2;
		private Sys3Controls.Sys3button sys3button1;
		private Sys3Controls.Sys3GroupBox sys3GroupBox1;
		private Sys3Controls.Sys3ToggleButton m_ToggleInputOnDelay;
		private Sys3Controls.Sys3Label m_labelStart;
		private Sys3Controls.Sys3GroupBox sys3GroupBox2;
		private Sys3Controls.Sys3Label sys3Label1;
		private Sys3Controls.Sys3Label sys3Label2;
		private Sys3Controls.Sys3Label sys3Label3;
		private Sys3Controls.Sys3Label sys3Label4;
	}
}
