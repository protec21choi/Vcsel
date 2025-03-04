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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Operation_Main));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.m_labelRunMode = new Sys3Controls.Sys3Label();
            this.m_btnStop = new Sys3Controls.Sys3button();
            this.m_btnRun = new Sys3Controls.Sys3button();
            this.m_btnInitialize = new Sys3Controls.Sys3button();
            this.m_groupRunMode = new Sys3Controls.Sys3GroupBox();
            this.sys3GroupBox4 = new Sys3Controls.Sys3GroupBox();
            this.btnFrontDoor = new Sys3Controls.Sys3DoorButton();
            this.sys3GroupBox1 = new Sys3Controls.Sys3GroupBox();
            this.lblTransfer = new Sys3Controls.Sys3Label();
            this.lblWorkBlock = new Sys3Controls.Sys3Label();
            this.lblBondHead = new Sys3Controls.Sys3Label();
            this.sys3GroupBox2 = new Sys3Controls.Sys3GroupBox();
            this.sys3button1 = new Sys3Controls.Sys3button();
            this.btn_Reset = new Sys3Controls.Sys3button();
            this.m_lblAlarmCodeMonitor = new Sys3Controls.Sys3Label();
            this.m_lblAlarmCodePort3 = new Sys3Controls.Sys3Label();
            this.m_lblAlarmCodePort2 = new Sys3Controls.Sys3Label();
            this.m_lblAlarmCodePort1 = new Sys3Controls.Sys3Label();
            this.sys3Label4 = new Sys3Controls.Sys3Label();
            this.sys3Label17 = new Sys3Controls.Sys3Label();
            this.sys3Label14 = new Sys3Controls.Sys3Label();
            this.sys3Label13 = new Sys3Controls.Sys3Label();
            this.sys3GroupBox3 = new Sys3Controls.Sys3GroupBox();
            this.sys3GroupBox6 = new Sys3Controls.Sys3GroupBox();
            this.sys3GroupBox7 = new Sys3Controls.Sys3GroupBox();
            this.dataGridView_Heater = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sys3GroupBox5 = new Sys3Controls.Sys3GroupBox();
            this.btnRearDoor = new Sys3Controls.Sys3DoorButton();
            this.sys3button2 = new Sys3Controls.Sys3button();
            this.sys3button3 = new Sys3Controls.Sys3button();
            this.m_lblWorkStatus = new Sys3Controls.Sys3Label();
            this.m_lblID = new Sys3Controls.Sys3Label();
            this.sys3Label1 = new Sys3Controls.Sys3Label();
            this.sys3Label2 = new Sys3Controls.Sys3Label();
            this.sys3GroupBox8 = new Sys3Controls.Sys3GroupBox();
            this.m_lblPreHeatingTime = new Sys3Controls.Sys3Label();
            this.sys3Label3 = new Sys3Controls.Sys3Label();
            this.btnFrontMagnetic = new Sys3Controls.Sys3DoorButton();
            this.btnRearMagnetic = new Sys3Controls.Sys3DoorButton();
            this.sys3GroupBox9 = new Sys3Controls.Sys3GroupBox();
            this.gridViewControl_WorkStatus_Parameter = new FrameOfSystem3.Component.GridViewControl_Parameter();
            this.gridVeiwControl_Util_Device = new FrameOfSystem3.Component.GridVeiwControl_Device();
            this.gridVeiwControl_Head_Device = new FrameOfSystem3.Component.GridVeiwControl_Device();
            this.gridVeiwControl_Block_Device = new FrameOfSystem3.Component.GridVeiwControl_Device();
            this.gridVeiwControl_Handler_Device = new FrameOfSystem3.Component.GridVeiwControl_Device();
            this.gridVeiwControl_Smema_Device = new FrameOfSystem3.Component.GridVeiwControl_Device();
            this.gridVeiwControl_Laser_Device = new FrameOfSystem3.Component.GridVeiwControl_Device();
            this.LB_LotID = new Sys3Controls.Sys3Label();
            this.sys3Label6 = new Sys3Controls.Sys3Label();
            this.sys3Label7 = new Sys3Controls.Sys3Label();
            this.LB_WaferCol = new Sys3Controls.Sys3Label();
            this.sys3Label9 = new Sys3Controls.Sys3Label();
            this.sys3Label10 = new Sys3Controls.Sys3Label();
            this.LB_PartName = new Sys3Controls.Sys3Label();
            this.LB_WaferRow = new Sys3Controls.Sys3Label();
            this.sys3Label15 = new Sys3Controls.Sys3Label();
            this.sys3Label16 = new Sys3Controls.Sys3Label();
            this.LB_LotType = new Sys3Controls.Sys3Label();
            this.LB_Angle = new Sys3Controls.Sys3Label();
            this.sys3Label20 = new Sys3Controls.Sys3Label();
            this.LB_StepSeq = new Sys3Controls.Sys3Label();
            this.sys3Label24 = new Sys3Controls.Sys3Label();
            this.sys3Label25 = new Sys3Controls.Sys3Label();
            this.LB_SlotNo = new Sys3Controls.Sys3Label();
            this.LB_CountChips = new Sys3Controls.Sys3Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Heater)).BeginInit();
            this.SuspendLayout();
            // 
            // m_labelRunMode
            // 
            this.m_labelRunMode.BackGroundColor = System.Drawing.Color.WhiteSmoke;
            this.m_labelRunMode.BorderStroke = 2;
            this.m_labelRunMode.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_labelRunMode.Description = "";
            this.m_labelRunMode.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_labelRunMode.EdgeRadius = 1;
            this.m_labelRunMode.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_labelRunMode.ImageSize = new System.Drawing.Point(0, 0);
            this.m_labelRunMode.LoadImage = null;
            this.m_labelRunMode.Location = new System.Drawing.Point(911, 847);
            this.m_labelRunMode.MainFont = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.m_labelRunMode.MainFontColor = System.Drawing.Color.Black;
            this.m_labelRunMode.Name = "m_labelRunMode";
            this.m_labelRunMode.Size = new System.Drawing.Size(229, 53);
            this.m_labelRunMode.SubFont = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.m_labelRunMode.SubFontColor = System.Drawing.Color.Gray;
            this.m_labelRunMode.SubText = "▶";
            this.m_labelRunMode.TabIndex = 1354;
            this.m_labelRunMode.Text = "AUTO";
            this.m_labelRunMode.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_labelRunMode.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.m_labelRunMode.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_labelRunMode.ThemeIndex = 0;
            this.m_labelRunMode.UnitAreaRate = 30;
            this.m_labelRunMode.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_labelRunMode.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_labelRunMode.UnitPositionVertical = false;
            this.m_labelRunMode.UnitText = "";
            this.m_labelRunMode.UseBorder = true;
            this.m_labelRunMode.UseEdgeRadius = false;
            this.m_labelRunMode.UseImage = false;
            this.m_labelRunMode.UseSubFont = true;
            this.m_labelRunMode.UseUnitFont = false;
            this.m_labelRunMode.Click += new System.EventHandler(this.Click_RunMode);
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
            this.m_btnStop.ImagePosition = new System.Drawing.Point(37, 25);
            this.m_btnStop.ImageSize = new System.Drawing.Point(30, 30);
            this.m_btnStop.LoadImage = global::FrameOfSystem3.Properties.Resources.Stop_white;
            this.m_btnStop.Location = new System.Drawing.Point(954, 35);
            this.m_btnStop.MainFont = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.m_btnStop.MainFontColor = System.Drawing.Color.White;
            this.m_btnStop.Name = "m_btnStop";
            this.m_btnStop.Size = new System.Drawing.Size(178, 79);
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
            this.m_btnStop.UserHoverEmpahsize = true;
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
            this.m_btnRun.LoadImage = global::FrameOfSystem3.Properties.Resources.Start_white;
            this.m_btnRun.Location = new System.Drawing.Point(769, 35);
            this.m_btnRun.MainFont = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.m_btnRun.MainFontColor = System.Drawing.Color.White;
            this.m_btnRun.Name = "m_btnRun";
            this.m_btnRun.Size = new System.Drawing.Size(178, 79);
            this.m_btnRun.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.m_btnRun.SubFontColor = System.Drawing.Color.Black;
            this.m_btnRun.SubText = "";
            this.m_btnRun.TabIndex = 1;
            this.m_btnRun.Text = "　RUN";
            this.m_btnRun.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_btnRun.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_btnRun.ThemeIndex = 0;
            this.m_btnRun.UseBorder = true;
            this.m_btnRun.UseClickedEmphasizeTextColor = false;
            this.m_btnRun.UseCustomizeClickedColor = false;
            this.m_btnRun.UseEdge = true;
            this.m_btnRun.UseHoverEmphasizeCustomColor = false;
            this.m_btnRun.UseImage = true;
            this.m_btnRun.UserHoverEmpahsize = true;
            this.m_btnRun.UseSubFont = false;
            this.m_btnRun.Click += new System.EventHandler(this.Click_OperationButton);
            // 
            // m_btnInitialize
            // 
            this.m_btnInitialize.BorderWidth = 5;
            this.m_btnInitialize.ButtonClicked = false;
            this.m_btnInitialize.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.m_btnInitialize.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.m_btnInitialize.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.m_btnInitialize.Description = "";
            this.m_btnInitialize.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_btnInitialize.EdgeRadius = 5;
            this.m_btnInitialize.GradientAngle = 60F;
            this.m_btnInitialize.GradientFirstColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.m_btnInitialize.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(65)))), ((int)(((byte)(200)))));
            this.m_btnInitialize.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.m_btnInitialize.ImagePosition = new System.Drawing.Point(26, 25);
            this.m_btnInitialize.ImageSize = new System.Drawing.Point(30, 30);
            this.m_btnInitialize.LoadImage = global::FrameOfSystem3.Properties.Resources.Home_White;
            this.m_btnInitialize.Location = new System.Drawing.Point(585, 35);
            this.m_btnInitialize.MainFont = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.m_btnInitialize.MainFontColor = System.Drawing.Color.White;
            this.m_btnInitialize.Name = "m_btnInitialize";
            this.m_btnInitialize.Size = new System.Drawing.Size(178, 79);
            this.m_btnInitialize.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.m_btnInitialize.SubFontColor = System.Drawing.Color.Black;
            this.m_btnInitialize.SubText = "";
            this.m_btnInitialize.TabIndex = 0;
            this.m_btnInitialize.Text = "　　INITIALIZE";
            this.m_btnInitialize.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_btnInitialize.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_btnInitialize.ThemeIndex = 0;
            this.m_btnInitialize.UseBorder = true;
            this.m_btnInitialize.UseClickedEmphasizeTextColor = false;
            this.m_btnInitialize.UseCustomizeClickedColor = false;
            this.m_btnInitialize.UseEdge = true;
            this.m_btnInitialize.UseHoverEmphasizeCustomColor = false;
            this.m_btnInitialize.UseImage = true;
            this.m_btnInitialize.UserHoverEmpahsize = true;
            this.m_btnInitialize.UseSubFont = false;
            this.m_btnInitialize.Click += new System.EventHandler(this.Click_OperationButton);
            // 
            // m_groupRunMode
            // 
            this.m_groupRunMode.BackGroundColor = System.Drawing.Color.WhiteSmoke;
            this.m_groupRunMode.EdgeBorderStroke = 2;
            this.m_groupRunMode.EdgeRadius = 2;
            this.m_groupRunMode.LabelFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_groupRunMode.LabelGradientColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.m_groupRunMode.LabelGradientColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_groupRunMode.LabelHeight = 30;
            this.m_groupRunMode.LabelTextColor = System.Drawing.Color.Black;
            this.m_groupRunMode.Location = new System.Drawing.Point(910, 817);
            this.m_groupRunMode.Name = "m_groupRunMode";
            this.m_groupRunMode.Size = new System.Drawing.Size(231, 84);
            this.m_groupRunMode.TabIndex = 1347;
            this.m_groupRunMode.Text = "SELECT RUNMODE";
            this.m_groupRunMode.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_groupRunMode.ThemeIndex = 0;
            this.m_groupRunMode.UseLabelBorder = true;
            // 
            // sys3GroupBox4
            // 
            this.sys3GroupBox4.BackGroundColor = System.Drawing.Color.WhiteSmoke;
            this.sys3GroupBox4.EdgeBorderStroke = 2;
            this.sys3GroupBox4.EdgeRadius = 2;
            this.sys3GroupBox4.LabelFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3GroupBox4.LabelGradientColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.sys3GroupBox4.LabelGradientColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.sys3GroupBox4.LabelHeight = 30;
            this.sys3GroupBox4.LabelTextColor = System.Drawing.Color.Black;
            this.sys3GroupBox4.Location = new System.Drawing.Point(574, -1);
            this.sys3GroupBox4.Name = "sys3GroupBox4";
            this.sys3GroupBox4.Size = new System.Drawing.Size(567, 168);
            this.sys3GroupBox4.TabIndex = 1347;
            this.sys3GroupBox4.Text = "OPERATION BUTTON";
            this.sys3GroupBox4.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3GroupBox4.ThemeIndex = 0;
            this.sys3GroupBox4.UseLabelBorder = true;
            // 
            // btnFrontDoor
            // 
            this.btnFrontDoor.BorderWidth = 3;
            this.btnFrontDoor.ButtonClicked = false;
            this.btnFrontDoor.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.btnFrontDoor.ColorClose = System.Drawing.Color.Gold;
            this.btnFrontDoor.ColorLocked = System.Drawing.Color.Green;
            this.btnFrontDoor.ColorOpen = System.Drawing.Color.Red;
            this.btnFrontDoor.CurrentDoorState = Sys3Controls.EDoorState.CLOSED;
            this.btnFrontDoor.Description = "";
            this.btnFrontDoor.DisabledColor = System.Drawing.Color.DarkGray;
            this.btnFrontDoor.EdgeRadius = 5;
            this.btnFrontDoor.GradientAngle = 90F;
            this.btnFrontDoor.GradientFirstColor = System.Drawing.Color.White;
            this.btnFrontDoor.GradientSecondColor = System.Drawing.Color.Gold;
            this.btnFrontDoor.HoverEmphasizeCustomColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnFrontDoor.ImageClose = ((System.Drawing.Image)(resources.GetObject("btnFrontDoor.ImageClose")));
            this.btnFrontDoor.ImageLocked = ((System.Drawing.Image)(resources.GetObject("btnFrontDoor.ImageLocked")));
            this.btnFrontDoor.ImageOpen = ((System.Drawing.Image)(resources.GetObject("btnFrontDoor.ImageOpen")));
            this.btnFrontDoor.ImagePosition = new System.Drawing.Point(10, 5);
            this.btnFrontDoor.ImageSize = new System.Drawing.Point(50, 50);
            this.btnFrontDoor.LoadImage = ((System.Drawing.Image)(resources.GetObject("btnFrontDoor.LoadImage")));
            this.btnFrontDoor.Location = new System.Drawing.Point(66, 35);
            this.btnFrontDoor.MainFont = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnFrontDoor.MainFontColor = System.Drawing.Color.White;
            this.btnFrontDoor.Name = "btnFrontDoor";
            this.btnFrontDoor.Size = new System.Drawing.Size(178, 58);
            this.btnFrontDoor.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.btnFrontDoor.SubFontColor = System.Drawing.Color.Black;
            this.btnFrontDoor.SubText = "";
            this.btnFrontDoor.TabIndex = 0;
            this.btnFrontDoor.Text = "FRONT DOOR";
            this.btnFrontDoor.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.btnFrontDoor.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.btnFrontDoor.ThemeIndex = 0;
            this.btnFrontDoor.UseBorder = true;
            this.btnFrontDoor.UseClickedEmphasizeTextColor = false;
            this.btnFrontDoor.UseEdge = true;
            this.btnFrontDoor.UseHoverEmphasizeCustomColor = true;
            this.btnFrontDoor.UseImage = true;
            this.btnFrontDoor.UserHoverEmpahsize = true;
            this.btnFrontDoor.UseSubFont = false;
            this.btnFrontDoor.Click += new System.EventHandler(this.Click_DoorButton);
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
            this.sys3GroupBox1.Location = new System.Drawing.Point(0, 254);
            this.sys3GroupBox1.Name = "sys3GroupBox1";
            this.sys3GroupBox1.Size = new System.Drawing.Size(924, 154);
            this.sys3GroupBox1.TabIndex = 1347;
            this.sys3GroupBox1.Text = "TASK STATE";
            this.sys3GroupBox1.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3GroupBox1.ThemeIndex = 0;
            this.sys3GroupBox1.UseLabelBorder = true;
            // 
            // lblTransfer
            // 
            this.lblTransfer.BackGroundColor = System.Drawing.Color.White;
            this.lblTransfer.BorderStroke = 3;
            this.lblTransfer.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Outset;
            this.lblTransfer.Description = "";
            this.lblTransfer.DisabledColor = System.Drawing.Color.DarkGray;
            this.lblTransfer.EdgeRadius = 10;
            this.lblTransfer.ImagePosition = new System.Drawing.Point(0, 0);
            this.lblTransfer.ImageSize = new System.Drawing.Point(0, 0);
            this.lblTransfer.LoadImage = null;
            this.lblTransfer.Location = new System.Drawing.Point(10, 298);
            this.lblTransfer.MainFont = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTransfer.MainFontColor = System.Drawing.Color.Black;
            this.lblTransfer.Name = "lblTransfer";
            this.lblTransfer.Size = new System.Drawing.Size(261, 80);
            this.lblTransfer.SubFont = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTransfer.SubFontColor = System.Drawing.Color.Black;
            this.lblTransfer.SubText = "TRANSFER";
            this.lblTransfer.TabIndex = 1355;
            this.lblTransfer.Text = "EQUIPMENT UNLOADING";
            this.lblTransfer.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.lblTransfer.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.lblTransfer.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
            this.lblTransfer.ThemeIndex = 0;
            this.lblTransfer.UnitAreaRate = 30;
            this.lblTransfer.UnitFont = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTransfer.UnitFontColor = System.Drawing.Color.Black;
            this.lblTransfer.UnitPositionVertical = false;
            this.lblTransfer.UnitText = "EMPTY";
            this.lblTransfer.UseBorder = true;
            this.lblTransfer.UseEdgeRadius = false;
            this.lblTransfer.UseImage = false;
            this.lblTransfer.UseSubFont = true;
            this.lblTransfer.UseUnitFont = false;
            // 
            // lblWorkBlock
            // 
            this.lblWorkBlock.BackGroundColor = System.Drawing.Color.Lime;
            this.lblWorkBlock.BorderStroke = 4;
            this.lblWorkBlock.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Outset;
            this.lblWorkBlock.Description = "";
            this.lblWorkBlock.DisabledColor = System.Drawing.Color.DarkGray;
            this.lblWorkBlock.EdgeRadius = 1;
            this.lblWorkBlock.ImagePosition = new System.Drawing.Point(0, 0);
            this.lblWorkBlock.ImageSize = new System.Drawing.Point(0, 0);
            this.lblWorkBlock.LoadImage = null;
            this.lblWorkBlock.Location = new System.Drawing.Point(275, 298);
            this.lblWorkBlock.MainFont = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblWorkBlock.MainFontColor = System.Drawing.Color.Black;
            this.lblWorkBlock.Name = "lblWorkBlock";
            this.lblWorkBlock.Size = new System.Drawing.Size(261, 80);
            this.lblWorkBlock.SubFont = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblWorkBlock.SubFontColor = System.Drawing.Color.Black;
            this.lblWorkBlock.SubText = "WORK BLOCK";
            this.lblWorkBlock.TabIndex = 1355;
            this.lblWorkBlock.Text = "LOADING";
            this.lblWorkBlock.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.lblWorkBlock.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.lblWorkBlock.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
            this.lblWorkBlock.ThemeIndex = 0;
            this.lblWorkBlock.UnitAreaRate = 30;
            this.lblWorkBlock.UnitFont = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblWorkBlock.UnitFontColor = System.Drawing.Color.Black;
            this.lblWorkBlock.UnitPositionVertical = false;
            this.lblWorkBlock.UnitText = "";
            this.lblWorkBlock.UseBorder = true;
            this.lblWorkBlock.UseEdgeRadius = false;
            this.lblWorkBlock.UseImage = false;
            this.lblWorkBlock.UseSubFont = true;
            this.lblWorkBlock.UseUnitFont = false;
            // 
            // lblBondHead
            // 
            this.lblBondHead.BackGroundColor = System.Drawing.Color.Lime;
            this.lblBondHead.BorderStroke = 4;
            this.lblBondHead.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Outset;
            this.lblBondHead.Description = "";
            this.lblBondHead.DisabledColor = System.Drawing.Color.DarkGray;
            this.lblBondHead.EdgeRadius = 1;
            this.lblBondHead.ImagePosition = new System.Drawing.Point(0, 0);
            this.lblBondHead.ImageSize = new System.Drawing.Point(0, 0);
            this.lblBondHead.LoadImage = null;
            this.lblBondHead.Location = new System.Drawing.Point(541, 298);
            this.lblBondHead.MainFont = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblBondHead.MainFontColor = System.Drawing.Color.Black;
            this.lblBondHead.Name = "lblBondHead";
            this.lblBondHead.Size = new System.Drawing.Size(261, 80);
            this.lblBondHead.SubFont = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblBondHead.SubFontColor = System.Drawing.Color.Black;
            this.lblBondHead.SubText = "BOND HEAD";
            this.lblBondHead.TabIndex = 1355;
            this.lblBondHead.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.lblBondHead.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.lblBondHead.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
            this.lblBondHead.ThemeIndex = 0;
            this.lblBondHead.UnitAreaRate = 30;
            this.lblBondHead.UnitFont = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblBondHead.UnitFontColor = System.Drawing.Color.Black;
            this.lblBondHead.UnitPositionVertical = false;
            this.lblBondHead.UnitText = "";
            this.lblBondHead.UseBorder = true;
            this.lblBondHead.UseEdgeRadius = false;
            this.lblBondHead.UseImage = false;
            this.lblBondHead.UseSubFont = true;
            this.lblBondHead.UseUnitFont = false;
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
            this.sys3GroupBox2.Location = new System.Drawing.Point(0, -1);
            this.sys3GroupBox2.Name = "sys3GroupBox2";
            this.sys3GroupBox2.Size = new System.Drawing.Size(579, 168);
            this.sys3GroupBox2.TabIndex = 1347;
            this.sys3GroupBox2.Text = "DOOR";
            this.sys3GroupBox2.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3GroupBox2.ThemeIndex = 0;
            this.sys3GroupBox2.UseLabelBorder = true;
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
            this.sys3button1.Location = new System.Drawing.Point(1002, 516);
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
            this.btn_Reset.Location = new System.Drawing.Point(868, 516);
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
            this.m_lblAlarmCodeMonitor.Location = new System.Drawing.Point(990, 478);
            this.m_lblAlarmCodeMonitor.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_lblAlarmCodeMonitor.MainFontColor = System.Drawing.Color.White;
            this.m_lblAlarmCodeMonitor.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_lblAlarmCodeMonitor.Name = "m_lblAlarmCodeMonitor";
            this.m_lblAlarmCodeMonitor.Size = new System.Drawing.Size(143, 37);
            this.m_lblAlarmCodeMonitor.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblAlarmCodeMonitor.SubFontColor = System.Drawing.Color.Gray;
            this.m_lblAlarmCodeMonitor.SubText = "";
            this.m_lblAlarmCodeMonitor.TabIndex = 20868;
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
            this.m_lblAlarmCodePort3.Location = new System.Drawing.Point(754, 478);
            this.m_lblAlarmCodePort3.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_lblAlarmCodePort3.MainFontColor = System.Drawing.Color.White;
            this.m_lblAlarmCodePort3.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_lblAlarmCodePort3.Name = "m_lblAlarmCodePort3";
            this.m_lblAlarmCodePort3.Size = new System.Drawing.Size(143, 37);
            this.m_lblAlarmCodePort3.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblAlarmCodePort3.SubFontColor = System.Drawing.Color.Gray;
            this.m_lblAlarmCodePort3.SubText = "";
            this.m_lblAlarmCodePort3.TabIndex = 20869;
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
            this.m_lblAlarmCodePort2.Location = new System.Drawing.Point(990, 440);
            this.m_lblAlarmCodePort2.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_lblAlarmCodePort2.MainFontColor = System.Drawing.Color.White;
            this.m_lblAlarmCodePort2.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_lblAlarmCodePort2.Name = "m_lblAlarmCodePort2";
            this.m_lblAlarmCodePort2.Size = new System.Drawing.Size(143, 37);
            this.m_lblAlarmCodePort2.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblAlarmCodePort2.SubFontColor = System.Drawing.Color.Gray;
            this.m_lblAlarmCodePort2.SubText = "";
            this.m_lblAlarmCodePort2.TabIndex = 20870;
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
            this.m_lblAlarmCodePort1.Location = new System.Drawing.Point(754, 440);
            this.m_lblAlarmCodePort1.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_lblAlarmCodePort1.MainFontColor = System.Drawing.Color.White;
            this.m_lblAlarmCodePort1.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_lblAlarmCodePort1.Name = "m_lblAlarmCodePort1";
            this.m_lblAlarmCodePort1.Size = new System.Drawing.Size(143, 37);
            this.m_lblAlarmCodePort1.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblAlarmCodePort1.SubFontColor = System.Drawing.Color.Gray;
            this.m_lblAlarmCodePort1.SubText = "";
            this.m_lblAlarmCodePort1.TabIndex = 20871;
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
            this.sys3Label4.Location = new System.Drawing.Point(898, 478);
            this.sys3Label4.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label4.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label4.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label4.Name = "sys3Label4";
            this.sys3Label4.Size = new System.Drawing.Size(91, 37);
            this.sys3Label4.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label4.SubFontColor = System.Drawing.Color.DarkRed;
            this.sys3Label4.SubText = "";
            this.sys3Label4.TabIndex = 20864;
            this.sys3Label4.Tag = "";
            this.sys3Label4.Text = "MONITOR";
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
            this.sys3Label17.Location = new System.Drawing.Point(662, 478);
            this.sys3Label17.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label17.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label17.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label17.Name = "sys3Label17";
            this.sys3Label17.Size = new System.Drawing.Size(91, 37);
            this.sys3Label17.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label17.SubFontColor = System.Drawing.Color.DarkRed;
            this.sys3Label17.SubText = "";
            this.sys3Label17.TabIndex = 20865;
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
            this.sys3Label14.Location = new System.Drawing.Point(898, 440);
            this.sys3Label14.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label14.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label14.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label14.Name = "sys3Label14";
            this.sys3Label14.Size = new System.Drawing.Size(91, 37);
            this.sys3Label14.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label14.SubFontColor = System.Drawing.Color.DarkRed;
            this.sys3Label14.SubText = "";
            this.sys3Label14.TabIndex = 20866;
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
            this.sys3Label13.Location = new System.Drawing.Point(662, 440);
            this.sys3Label13.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label13.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label13.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label13.Name = "sys3Label13";
            this.sys3Label13.Size = new System.Drawing.Size(91, 37);
            this.sys3Label13.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label13.SubFontColor = System.Drawing.Color.DarkRed;
            this.sys3Label13.SubText = "";
            this.sys3Label13.TabIndex = 20867;
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
            this.sys3GroupBox3.Location = new System.Drawing.Point(654, 406);
            this.sys3GroupBox3.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3GroupBox3.Name = "sys3GroupBox3";
            this.sys3GroupBox3.Size = new System.Drawing.Size(488, 413);
            this.sys3GroupBox3.TabIndex = 20863;
            this.sys3GroupBox3.Tag = "";
            this.sys3GroupBox3.Text = "BOND HEAD MONITOR";
            this.sys3GroupBox3.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3GroupBox3.ThemeIndex = 0;
            this.sys3GroupBox3.UseLabelBorder = true;
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
            this.sys3GroupBox6.Location = new System.Drawing.Point(0, 406);
            this.sys3GroupBox6.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3GroupBox6.Name = "sys3GroupBox6";
            this.sys3GroupBox6.Size = new System.Drawing.Size(365, 265);
            this.sys3GroupBox6.TabIndex = 20863;
            this.sys3GroupBox6.Tag = "";
            this.sys3GroupBox6.Text = "TRANSFER MONITOR";
            this.sys3GroupBox6.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3GroupBox6.ThemeIndex = 0;
            this.sys3GroupBox6.UseLabelBorder = true;
            // 
            // sys3GroupBox7
            // 
            this.sys3GroupBox7.BackGroundColor = System.Drawing.Color.WhiteSmoke;
            this.sys3GroupBox7.EdgeBorderStroke = 2;
            this.sys3GroupBox7.EdgeRadius = 2;
            this.sys3GroupBox7.LabelFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3GroupBox7.LabelGradientColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.sys3GroupBox7.LabelGradientColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.sys3GroupBox7.LabelHeight = 30;
            this.sys3GroupBox7.LabelTextColor = System.Drawing.Color.Black;
            this.sys3GroupBox7.Location = new System.Drawing.Point(922, 254);
            this.sys3GroupBox7.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3GroupBox7.Name = "sys3GroupBox7";
            this.sys3GroupBox7.Size = new System.Drawing.Size(219, 154);
            this.sys3GroupBox7.TabIndex = 20863;
            this.sys3GroupBox7.Tag = "";
            this.sys3GroupBox7.Text = "MAIN UTIL";
            this.sys3GroupBox7.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3GroupBox7.ThemeIndex = 0;
            this.sys3GroupBox7.UseLabelBorder = true;
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
            this.dataGridView_Heater.Location = new System.Drawing.Point(366, 437);
            this.dataGridView_Heater.MultiSelect = false;
            this.dataGridView_Heater.Name = "dataGridView_Heater";
            this.dataGridView_Heater.ReadOnly = true;
            this.dataGridView_Heater.RowHeadersVisible = false;
            this.dataGridView_Heater.RowTemplate.Height = 25;
            this.dataGridView_Heater.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView_Heater.Size = new System.Drawing.Size(287, 53);
            this.dataGridView_Heater.TabIndex = 20873;
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
            this.sys3GroupBox5.Location = new System.Drawing.Point(363, 406);
            this.sys3GroupBox5.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3GroupBox5.Name = "sys3GroupBox5";
            this.sys3GroupBox5.Size = new System.Drawing.Size(293, 265);
            this.sys3GroupBox5.TabIndex = 20863;
            this.sys3GroupBox5.Tag = "";
            this.sys3GroupBox5.Text = "BLOCK MONITOR";
            this.sys3GroupBox5.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3GroupBox5.ThemeIndex = 0;
            this.sys3GroupBox5.UseLabelBorder = true;
            // 
            // btnRearDoor
            // 
            this.btnRearDoor.BorderWidth = 3;
            this.btnRearDoor.ButtonClicked = false;
            this.btnRearDoor.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.btnRearDoor.ColorClose = System.Drawing.Color.Gold;
            this.btnRearDoor.ColorLocked = System.Drawing.Color.Green;
            this.btnRearDoor.ColorOpen = System.Drawing.Color.Red;
            this.btnRearDoor.CurrentDoorState = Sys3Controls.EDoorState.CLOSED;
            this.btnRearDoor.Description = "";
            this.btnRearDoor.DisabledColor = System.Drawing.Color.DarkGray;
            this.btnRearDoor.EdgeRadius = 5;
            this.btnRearDoor.GradientAngle = 90F;
            this.btnRearDoor.GradientFirstColor = System.Drawing.Color.White;
            this.btnRearDoor.GradientSecondColor = System.Drawing.Color.Gold;
            this.btnRearDoor.HoverEmphasizeCustomColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnRearDoor.ImageClose = ((System.Drawing.Image)(resources.GetObject("btnRearDoor.ImageClose")));
            this.btnRearDoor.ImageLocked = ((System.Drawing.Image)(resources.GetObject("btnRearDoor.ImageLocked")));
            this.btnRearDoor.ImageOpen = ((System.Drawing.Image)(resources.GetObject("btnRearDoor.ImageOpen")));
            this.btnRearDoor.ImagePosition = new System.Drawing.Point(10, 5);
            this.btnRearDoor.ImageSize = new System.Drawing.Point(50, 50);
            this.btnRearDoor.LoadImage = ((System.Drawing.Image)(resources.GetObject("btnRearDoor.LoadImage")));
            this.btnRearDoor.Location = new System.Drawing.Point(338, 35);
            this.btnRearDoor.MainFont = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRearDoor.MainFontColor = System.Drawing.Color.White;
            this.btnRearDoor.Name = "btnRearDoor";
            this.btnRearDoor.Size = new System.Drawing.Size(178, 58);
            this.btnRearDoor.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.btnRearDoor.SubFontColor = System.Drawing.Color.Black;
            this.btnRearDoor.SubText = "";
            this.btnRearDoor.TabIndex = 1;
            this.btnRearDoor.Text = "REAR DOOR";
            this.btnRearDoor.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.btnRearDoor.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.btnRearDoor.ThemeIndex = 0;
            this.btnRearDoor.UseBorder = true;
            this.btnRearDoor.UseClickedEmphasizeTextColor = false;
            this.btnRearDoor.UseEdge = true;
            this.btnRearDoor.UseHoverEmphasizeCustomColor = true;
            this.btnRearDoor.UseImage = true;
            this.btnRearDoor.UserHoverEmpahsize = true;
            this.btnRearDoor.UseSubFont = false;
            this.btnRearDoor.Click += new System.EventHandler(this.Click_DoorButton);
            // 
            // sys3button2
            // 
            this.sys3button2.BorderWidth = 3;
            this.sys3button2.ButtonClicked = false;
            this.sys3button2.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.sys3button2.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.sys3button2.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.sys3button2.Description = "";
            this.sys3button2.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3button2.EdgeRadius = 1;
            this.sys3button2.GradientAngle = 90F;
            this.sys3button2.GradientFirstColor = System.Drawing.Color.White;
            this.sys3button2.GradientSecondColor = System.Drawing.Color.Silver;
            this.sys3button2.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.sys3button2.ImagePosition = new System.Drawing.Point(7, 7);
            this.sys3button2.ImageSize = new System.Drawing.Point(30, 30);
            this.sys3button2.LoadImage = global::FrameOfSystem3.Properties.Resources.CONFIG_ADD3;
            this.sys3button2.Location = new System.Drawing.Point(808, 362);
            this.sys3button2.MainFont = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.sys3button2.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
            this.sys3button2.Name = "sys3button2";
            this.sys3button2.Size = new System.Drawing.Size(109, 40);
            this.sys3button2.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.sys3button2.SubFontColor = System.Drawing.Color.DarkBlue;
            this.sys3button2.SubText = "STATUS";
            this.sys3button2.TabIndex = 0;
            this.sys3button2.Text = "CLEAR";
            this.sys3button2.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3button2.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.sys3button2.ThemeIndex = 0;
            this.sys3button2.UseBorder = false;
            this.sys3button2.UseClickedEmphasizeTextColor = false;
            this.sys3button2.UseCustomizeClickedColor = false;
            this.sys3button2.UseEdge = false;
            this.sys3button2.UseHoverEmphasizeCustomColor = false;
            this.sys3button2.UseImage = false;
            this.sys3button2.UserHoverEmpahsize = true;
            this.sys3button2.UseSubFont = false;
            this.sys3button2.Click += new System.EventHandler(this.Click_MaterialClear);
            // 
            // sys3button3
            // 
            this.sys3button3.BorderWidth = 3;
            this.sys3button3.ButtonClicked = false;
            this.sys3button3.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.sys3button3.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.sys3button3.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.sys3button3.Description = "";
            this.sys3button3.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3button3.EdgeRadius = 1;
            this.sys3button3.GradientAngle = 90F;
            this.sys3button3.GradientFirstColor = System.Drawing.Color.White;
            this.sys3button3.GradientSecondColor = System.Drawing.Color.Silver;
            this.sys3button3.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.sys3button3.ImagePosition = new System.Drawing.Point(7, 7);
            this.sys3button3.ImageSize = new System.Drawing.Point(30, 30);
            this.sys3button3.LoadImage = global::FrameOfSystem3.Properties.Resources.CONFIG_ADD3;
            this.sys3button3.Location = new System.Drawing.Point(1024, 362);
            this.sys3button3.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3button3.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
            this.sys3button3.Name = "sys3button3";
            this.sys3button3.Size = new System.Drawing.Size(109, 40);
            this.sys3button3.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.sys3button3.SubFontColor = System.Drawing.Color.DarkBlue;
            this.sys3button3.SubText = "STATUS";
            this.sys3button3.TabIndex = 0;
            this.sys3button3.Text = "VAC ON/OFF";
            this.sys3button3.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3button3.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.sys3button3.ThemeIndex = 0;
            this.sys3button3.UseBorder = false;
            this.sys3button3.UseClickedEmphasizeTextColor = false;
            this.sys3button3.UseCustomizeClickedColor = false;
            this.sys3button3.UseEdge = false;
            this.sys3button3.UseHoverEmphasizeCustomColor = false;
            this.sys3button3.UseImage = false;
            this.sys3button3.UserHoverEmpahsize = true;
            this.sys3button3.UseSubFont = false;
            this.sys3button3.Click += new System.EventHandler(this.Click_VacOnOff);
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
            this.m_lblWorkStatus.Location = new System.Drawing.Point(706, 203);
            this.m_lblWorkStatus.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_lblWorkStatus.MainFontColor = System.Drawing.Color.White;
            this.m_lblWorkStatus.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_lblWorkStatus.Name = "m_lblWorkStatus";
            this.m_lblWorkStatus.Size = new System.Drawing.Size(87, 37);
            this.m_lblWorkStatus.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblWorkStatus.SubFontColor = System.Drawing.Color.Gray;
            this.m_lblWorkStatus.SubText = "";
            this.m_lblWorkStatus.TabIndex = 20878;
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
            this.m_lblID.Location = new System.Drawing.Point(99, 203);
            this.m_lblID.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_lblID.MainFontColor = System.Drawing.Color.White;
            this.m_lblID.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_lblID.Name = "m_lblID";
            this.m_lblID.Size = new System.Drawing.Size(514, 37);
            this.m_lblID.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblID.SubFontColor = System.Drawing.Color.Gray;
            this.m_lblID.SubText = "";
            this.m_lblID.TabIndex = 20879;
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
            this.sys3Label1.Location = new System.Drawing.Point(614, 203);
            this.sys3Label1.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label1.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label1.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label1.Name = "sys3Label1";
            this.sys3Label1.Size = new System.Drawing.Size(91, 37);
            this.sys3Label1.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label1.SubFontColor = System.Drawing.Color.DarkRed;
            this.sys3Label1.SubText = "";
            this.sys3Label1.TabIndex = 20876;
            this.sys3Label1.Tag = "";
            this.sys3Label1.Text = "STATUS";
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
            this.sys3Label2.Location = new System.Drawing.Point(7, 203);
            this.sys3Label2.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label2.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label2.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label2.Name = "sys3Label2";
            this.sys3Label2.Size = new System.Drawing.Size(91, 37);
            this.sys3Label2.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label2.SubFontColor = System.Drawing.Color.DarkRed;
            this.sys3Label2.SubText = "";
            this.sys3Label2.TabIndex = 20877;
            this.sys3Label2.Tag = "";
            this.sys3Label2.Text = "ID ";
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
            // sys3GroupBox8
            // 
            this.sys3GroupBox8.BackGroundColor = System.Drawing.Color.WhiteSmoke;
            this.sys3GroupBox8.EdgeBorderStroke = 2;
            this.sys3GroupBox8.EdgeRadius = 2;
            this.sys3GroupBox8.LabelFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3GroupBox8.LabelGradientColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.sys3GroupBox8.LabelGradientColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.sys3GroupBox8.LabelHeight = 30;
            this.sys3GroupBox8.LabelTextColor = System.Drawing.Color.Black;
            this.sys3GroupBox8.Location = new System.Drawing.Point(0, 166);
            this.sys3GroupBox8.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3GroupBox8.Name = "sys3GroupBox8";
            this.sys3GroupBox8.Size = new System.Drawing.Size(1139, 87);
            this.sys3GroupBox8.TabIndex = 20875;
            this.sys3GroupBox8.Tag = "";
            this.sys3GroupBox8.Text = "WORK INFORMATION";
            this.sys3GroupBox8.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3GroupBox8.ThemeIndex = 0;
            this.sys3GroupBox8.UseLabelBorder = true;
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
            this.m_lblPreHeatingTime.Location = new System.Drawing.Point(780, 767);
            this.m_lblPreHeatingTime.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_lblPreHeatingTime.MainFontColor = System.Drawing.Color.White;
            this.m_lblPreHeatingTime.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_lblPreHeatingTime.Name = "m_lblPreHeatingTime";
            this.m_lblPreHeatingTime.Size = new System.Drawing.Size(179, 37);
            this.m_lblPreHeatingTime.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblPreHeatingTime.SubFontColor = System.Drawing.Color.Gray;
            this.m_lblPreHeatingTime.SubText = "";
            this.m_lblPreHeatingTime.TabIndex = 20881;
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
            this.sys3Label3.Location = new System.Drawing.Point(657, 767);
            this.sys3Label3.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label3.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label3.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label3.Name = "sys3Label3";
            this.sys3Label3.Size = new System.Drawing.Size(122, 37);
            this.sys3Label3.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label3.SubFontColor = System.Drawing.Color.DarkRed;
            this.sys3Label3.SubText = "";
            this.sys3Label3.TabIndex = 20880;
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
            // btnFrontMagnetic
            // 
            this.btnFrontMagnetic.BorderWidth = 3;
            this.btnFrontMagnetic.ButtonClicked = false;
            this.btnFrontMagnetic.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.btnFrontMagnetic.ColorClose = System.Drawing.Color.Gold;
            this.btnFrontMagnetic.ColorLocked = System.Drawing.Color.Green;
            this.btnFrontMagnetic.ColorOpen = System.Drawing.Color.Red;
            this.btnFrontMagnetic.CurrentDoorState = Sys3Controls.EDoorState.CLOSED;
            this.btnFrontMagnetic.Description = "";
            this.btnFrontMagnetic.DisabledColor = System.Drawing.Color.DarkGray;
            this.btnFrontMagnetic.EdgeRadius = 5;
            this.btnFrontMagnetic.GradientAngle = 90F;
            this.btnFrontMagnetic.GradientFirstColor = System.Drawing.Color.White;
            this.btnFrontMagnetic.GradientSecondColor = System.Drawing.Color.Gold;
            this.btnFrontMagnetic.HoverEmphasizeCustomColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnFrontMagnetic.ImageClose = ((System.Drawing.Image)(resources.GetObject("btnFrontMagnetic.ImageClose")));
            this.btnFrontMagnetic.ImageLocked = ((System.Drawing.Image)(resources.GetObject("btnFrontMagnetic.ImageLocked")));
            this.btnFrontMagnetic.ImageOpen = ((System.Drawing.Image)(resources.GetObject("btnFrontMagnetic.ImageOpen")));
            this.btnFrontMagnetic.ImagePosition = new System.Drawing.Point(10, 5);
            this.btnFrontMagnetic.ImageSize = new System.Drawing.Point(50, 50);
            this.btnFrontMagnetic.LoadImage = ((System.Drawing.Image)(resources.GetObject("btnFrontMagnetic.LoadImage")));
            this.btnFrontMagnetic.Location = new System.Drawing.Point(66, 95);
            this.btnFrontMagnetic.MainFont = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnFrontMagnetic.MainFontColor = System.Drawing.Color.White;
            this.btnFrontMagnetic.Name = "btnFrontMagnetic";
            this.btnFrontMagnetic.Size = new System.Drawing.Size(178, 58);
            this.btnFrontMagnetic.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.btnFrontMagnetic.SubFontColor = System.Drawing.Color.Black;
            this.btnFrontMagnetic.SubText = "";
            this.btnFrontMagnetic.TabIndex = 10;
            this.btnFrontMagnetic.Text = "FRONT DOOR";
            this.btnFrontMagnetic.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.btnFrontMagnetic.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.btnFrontMagnetic.ThemeIndex = 0;
            this.btnFrontMagnetic.UseBorder = true;
            this.btnFrontMagnetic.UseClickedEmphasizeTextColor = false;
            this.btnFrontMagnetic.UseEdge = true;
            this.btnFrontMagnetic.UseHoverEmphasizeCustomColor = true;
            this.btnFrontMagnetic.UseImage = true;
            this.btnFrontMagnetic.UserHoverEmpahsize = true;
            this.btnFrontMagnetic.UseSubFont = false;
            this.btnFrontMagnetic.Click += new System.EventHandler(this.Click_DoorButton);
            // 
            // btnRearMagnetic
            // 
            this.btnRearMagnetic.BorderWidth = 3;
            this.btnRearMagnetic.ButtonClicked = false;
            this.btnRearMagnetic.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.btnRearMagnetic.ColorClose = System.Drawing.Color.Gold;
            this.btnRearMagnetic.ColorLocked = System.Drawing.Color.Green;
            this.btnRearMagnetic.ColorOpen = System.Drawing.Color.Red;
            this.btnRearMagnetic.CurrentDoorState = Sys3Controls.EDoorState.CLOSED;
            this.btnRearMagnetic.Description = "";
            this.btnRearMagnetic.DisabledColor = System.Drawing.Color.DarkGray;
            this.btnRearMagnetic.EdgeRadius = 5;
            this.btnRearMagnetic.GradientAngle = 90F;
            this.btnRearMagnetic.GradientFirstColor = System.Drawing.Color.White;
            this.btnRearMagnetic.GradientSecondColor = System.Drawing.Color.Gold;
            this.btnRearMagnetic.HoverEmphasizeCustomColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnRearMagnetic.ImageClose = ((System.Drawing.Image)(resources.GetObject("btnRearMagnetic.ImageClose")));
            this.btnRearMagnetic.ImageLocked = ((System.Drawing.Image)(resources.GetObject("btnRearMagnetic.ImageLocked")));
            this.btnRearMagnetic.ImageOpen = ((System.Drawing.Image)(resources.GetObject("btnRearMagnetic.ImageOpen")));
            this.btnRearMagnetic.ImagePosition = new System.Drawing.Point(10, 5);
            this.btnRearMagnetic.ImageSize = new System.Drawing.Point(50, 50);
            this.btnRearMagnetic.LoadImage = ((System.Drawing.Image)(resources.GetObject("btnRearMagnetic.LoadImage")));
            this.btnRearMagnetic.Location = new System.Drawing.Point(338, 95);
            this.btnRearMagnetic.MainFont = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRearMagnetic.MainFontColor = System.Drawing.Color.White;
            this.btnRearMagnetic.Name = "btnRearMagnetic";
            this.btnRearMagnetic.Size = new System.Drawing.Size(178, 58);
            this.btnRearMagnetic.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.btnRearMagnetic.SubFontColor = System.Drawing.Color.Black;
            this.btnRearMagnetic.SubText = "";
            this.btnRearMagnetic.TabIndex = 11;
            this.btnRearMagnetic.Text = "REAR DOOR";
            this.btnRearMagnetic.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.btnRearMagnetic.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.btnRearMagnetic.ThemeIndex = 0;
            this.btnRearMagnetic.UseBorder = true;
            this.btnRearMagnetic.UseClickedEmphasizeTextColor = false;
            this.btnRearMagnetic.UseEdge = true;
            this.btnRearMagnetic.UseHoverEmphasizeCustomColor = true;
            this.btnRearMagnetic.UseImage = true;
            this.btnRearMagnetic.UserHoverEmpahsize = true;
            this.btnRearMagnetic.UseSubFont = false;
            this.btnRearMagnetic.Click += new System.EventHandler(this.Click_DoorButton);
            // 
            // sys3GroupBox9
            // 
            this.sys3GroupBox9.BackGroundColor = System.Drawing.Color.WhiteSmoke;
            this.sys3GroupBox9.EdgeBorderStroke = 2;
            this.sys3GroupBox9.EdgeRadius = 2;
            this.sys3GroupBox9.LabelFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3GroupBox9.LabelGradientColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.sys3GroupBox9.LabelGradientColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.sys3GroupBox9.LabelHeight = 30;
            this.sys3GroupBox9.LabelTextColor = System.Drawing.Color.Black;
            this.sys3GroupBox9.Location = new System.Drawing.Point(0, 670);
            this.sys3GroupBox9.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3GroupBox9.Name = "sys3GroupBox9";
            this.sys3GroupBox9.Size = new System.Drawing.Size(656, 229);
            this.sys3GroupBox9.TabIndex = 20863;
            this.sys3GroupBox9.Tag = "";
            this.sys3GroupBox9.Text = "WAFER INFORMATION";
            this.sys3GroupBox9.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3GroupBox9.ThemeIndex = 0;
            this.sys3GroupBox9.UseLabelBorder = true;
            // 
            // gridViewControl_WorkStatus_Parameter
            // 
            this.gridViewControl_WorkStatus_Parameter.Control_Enable = true;
            this.gridViewControl_WorkStatus_Parameter.controlCollection = null;
            this.gridViewControl_WorkStatus_Parameter.Location = new System.Drawing.Point(796, 197);
            this.gridViewControl_WorkStatus_Parameter.Name = "gridViewControl_WorkStatus_Parameter";
            this.gridViewControl_WorkStatus_Parameter.Size = new System.Drawing.Size(340, 53);
            this.gridViewControl_WorkStatus_Parameter.TabIndex = 20874;
            // 
            // gridVeiwControl_Util_Device
            // 
            this.gridVeiwControl_Util_Device.Control_Enable = true;
            this.gridVeiwControl_Util_Device.controlCollection = null;
            this.gridVeiwControl_Util_Device.Location = new System.Drawing.Point(924, 284);
            this.gridVeiwControl_Util_Device.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.gridVeiwControl_Util_Device.Name = "gridVeiwControl_Util_Device";
            this.gridVeiwControl_Util_Device.Size = new System.Drawing.Size(214, 72);
            this.gridVeiwControl_Util_Device.TabIndex = 20872;
            // 
            // gridVeiwControl_Head_Device
            // 
            this.gridVeiwControl_Head_Device.Control_Enable = true;
            this.gridVeiwControl_Head_Device.controlCollection = null;
            this.gridVeiwControl_Head_Device.Location = new System.Drawing.Point(657, 738);
            this.gridVeiwControl_Head_Device.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.gridVeiwControl_Head_Device.Name = "gridVeiwControl_Head_Device";
            this.gridVeiwControl_Head_Device.Size = new System.Drawing.Size(483, 28);
            this.gridVeiwControl_Head_Device.TabIndex = 20872;
            // 
            // gridVeiwControl_Block_Device
            // 
            this.gridVeiwControl_Block_Device.Control_Enable = true;
            this.gridVeiwControl_Block_Device.controlCollection = null;
            this.gridVeiwControl_Block_Device.Location = new System.Drawing.Point(366, 490);
            this.gridVeiwControl_Block_Device.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.gridVeiwControl_Block_Device.Name = "gridVeiwControl_Block_Device";
            this.gridVeiwControl_Block_Device.Size = new System.Drawing.Size(287, 178);
            this.gridVeiwControl_Block_Device.TabIndex = 20872;
            // 
            // gridVeiwControl_Handler_Device
            // 
            this.gridVeiwControl_Handler_Device.Control_Enable = true;
            this.gridVeiwControl_Handler_Device.controlCollection = null;
            this.gridVeiwControl_Handler_Device.Location = new System.Drawing.Point(2, 565);
            this.gridVeiwControl_Handler_Device.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.gridVeiwControl_Handler_Device.Name = "gridVeiwControl_Handler_Device";
            this.gridVeiwControl_Handler_Device.Size = new System.Drawing.Size(360, 103);
            this.gridVeiwControl_Handler_Device.TabIndex = 20872;
            // 
            // gridVeiwControl_Smema_Device
            // 
            this.gridVeiwControl_Smema_Device.Control_Enable = false;
            this.gridVeiwControl_Smema_Device.controlCollection = null;
            this.gridVeiwControl_Smema_Device.Location = new System.Drawing.Point(2, 437);
            this.gridVeiwControl_Smema_Device.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.gridVeiwControl_Smema_Device.Name = "gridVeiwControl_Smema_Device";
            this.gridVeiwControl_Smema_Device.Size = new System.Drawing.Size(360, 128);
            this.gridVeiwControl_Smema_Device.TabIndex = 20872;
            // 
            // gridVeiwControl_Laser_Device
            // 
            this.gridVeiwControl_Laser_Device.Control_Enable = true;
            this.gridVeiwControl_Laser_Device.controlCollection = null;
            this.gridVeiwControl_Laser_Device.Location = new System.Drawing.Point(657, 560);
            this.gridVeiwControl_Laser_Device.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.gridVeiwControl_Laser_Device.Name = "gridVeiwControl_Laser_Device";
            this.gridVeiwControl_Laser_Device.Size = new System.Drawing.Size(483, 178);
            this.gridVeiwControl_Laser_Device.TabIndex = 20872;
            // 
            // LB_LotID
            // 
            this.LB_LotID.BackGroundColor = System.Drawing.Color.DimGray;
            this.LB_LotID.BorderStroke = 2;
            this.LB_LotID.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.LB_LotID.Description = "";
            this.LB_LotID.DisabledColor = System.Drawing.Color.DarkGray;
            this.LB_LotID.EdgeRadius = 1;
            this.LB_LotID.ImagePosition = new System.Drawing.Point(0, 0);
            this.LB_LotID.ImageSize = new System.Drawing.Point(0, 0);
            this.LB_LotID.LoadImage = null;
            this.LB_LotID.Location = new System.Drawing.Point(126, 704);
            this.LB_LotID.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.LB_LotID.MainFontColor = System.Drawing.Color.White;
            this.LB_LotID.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.LB_LotID.Name = "LB_LotID";
            this.LB_LotID.Size = new System.Drawing.Size(201, 37);
            this.LB_LotID.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LB_LotID.SubFontColor = System.Drawing.Color.Gray;
            this.LB_LotID.SubText = "";
            this.LB_LotID.TabIndex = 20883;
            this.LB_LotID.Tag = "";
            this.LB_LotID.Text = "NONE";
            this.LB_LotID.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.LB_LotID.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.LB_LotID.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.LB_LotID.ThemeIndex = 0;
            this.LB_LotID.UnitAreaRate = 30;
            this.LB_LotID.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LB_LotID.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.LB_LotID.UnitPositionVertical = false;
            this.LB_LotID.UnitText = "W";
            this.LB_LotID.UseBorder = true;
            this.LB_LotID.UseEdgeRadius = false;
            this.LB_LotID.UseImage = false;
            this.LB_LotID.UseSubFont = true;
            this.LB_LotID.UseUnitFont = false;
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
            this.sys3Label6.Location = new System.Drawing.Point(10, 704);
            this.sys3Label6.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label6.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label6.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label6.Name = "sys3Label6";
            this.sys3Label6.Size = new System.Drawing.Size(115, 37);
            this.sys3Label6.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label6.SubFontColor = System.Drawing.Color.DarkRed;
            this.sys3Label6.SubText = "";
            this.sys3Label6.TabIndex = 20882;
            this.sys3Label6.Tag = "";
            this.sys3Label6.Text = "LOT ID";
            this.sys3Label6.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3Label6.TextAlignSub = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
            this.sys3Label6.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label6.ThemeIndex = 0;
            this.sys3Label6.UnitAreaRate = 40;
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
            this.sys3Label7.Location = new System.Drawing.Point(329, 704);
            this.sys3Label7.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label7.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label7.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label7.Name = "sys3Label7";
            this.sys3Label7.Size = new System.Drawing.Size(115, 37);
            this.sys3Label7.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label7.SubFontColor = System.Drawing.Color.DarkRed;
            this.sys3Label7.SubText = "";
            this.sys3Label7.TabIndex = 20882;
            this.sys3Label7.Tag = "";
            this.sys3Label7.Text = "WAFER COL";
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
            // LB_WaferCol
            // 
            this.LB_WaferCol.BackGroundColor = System.Drawing.Color.DimGray;
            this.LB_WaferCol.BorderStroke = 2;
            this.LB_WaferCol.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.LB_WaferCol.Description = "";
            this.LB_WaferCol.DisabledColor = System.Drawing.Color.DarkGray;
            this.LB_WaferCol.EdgeRadius = 1;
            this.LB_WaferCol.ImagePosition = new System.Drawing.Point(0, 0);
            this.LB_WaferCol.ImageSize = new System.Drawing.Point(0, 0);
            this.LB_WaferCol.LoadImage = null;
            this.LB_WaferCol.Location = new System.Drawing.Point(445, 704);
            this.LB_WaferCol.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.LB_WaferCol.MainFontColor = System.Drawing.Color.White;
            this.LB_WaferCol.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.LB_WaferCol.Name = "LB_WaferCol";
            this.LB_WaferCol.Size = new System.Drawing.Size(201, 37);
            this.LB_WaferCol.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LB_WaferCol.SubFontColor = System.Drawing.Color.Gray;
            this.LB_WaferCol.SubText = "";
            this.LB_WaferCol.TabIndex = 20883;
            this.LB_WaferCol.Tag = "";
            this.LB_WaferCol.Text = "NONE";
            this.LB_WaferCol.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.LB_WaferCol.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.LB_WaferCol.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.LB_WaferCol.ThemeIndex = 0;
            this.LB_WaferCol.UnitAreaRate = 30;
            this.LB_WaferCol.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LB_WaferCol.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.LB_WaferCol.UnitPositionVertical = false;
            this.LB_WaferCol.UnitText = "W";
            this.LB_WaferCol.UseBorder = true;
            this.LB_WaferCol.UseEdgeRadius = false;
            this.LB_WaferCol.UseImage = false;
            this.LB_WaferCol.UseSubFont = true;
            this.LB_WaferCol.UseUnitFont = false;
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
            this.sys3Label9.Location = new System.Drawing.Point(10, 742);
            this.sys3Label9.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label9.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label9.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label9.Name = "sys3Label9";
            this.sys3Label9.Size = new System.Drawing.Size(115, 37);
            this.sys3Label9.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label9.SubFontColor = System.Drawing.Color.DarkRed;
            this.sys3Label9.SubText = "";
            this.sys3Label9.TabIndex = 20882;
            this.sys3Label9.Tag = "";
            this.sys3Label9.Text = "PART NAME";
            this.sys3Label9.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3Label9.TextAlignSub = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
            this.sys3Label9.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label9.ThemeIndex = 0;
            this.sys3Label9.UnitAreaRate = 40;
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
            this.sys3Label10.Location = new System.Drawing.Point(329, 742);
            this.sys3Label10.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label10.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label10.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label10.Name = "sys3Label10";
            this.sys3Label10.Size = new System.Drawing.Size(115, 37);
            this.sys3Label10.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label10.SubFontColor = System.Drawing.Color.DarkRed;
            this.sys3Label10.SubText = "";
            this.sys3Label10.TabIndex = 20882;
            this.sys3Label10.Tag = "";
            this.sys3Label10.Text = "WAFER ROW";
            this.sys3Label10.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3Label10.TextAlignSub = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
            this.sys3Label10.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label10.ThemeIndex = 0;
            this.sys3Label10.UnitAreaRate = 40;
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
            // LB_PartName
            // 
            this.LB_PartName.BackGroundColor = System.Drawing.Color.DimGray;
            this.LB_PartName.BorderStroke = 2;
            this.LB_PartName.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.LB_PartName.Description = "";
            this.LB_PartName.DisabledColor = System.Drawing.Color.DarkGray;
            this.LB_PartName.EdgeRadius = 1;
            this.LB_PartName.ImagePosition = new System.Drawing.Point(0, 0);
            this.LB_PartName.ImageSize = new System.Drawing.Point(0, 0);
            this.LB_PartName.LoadImage = null;
            this.LB_PartName.Location = new System.Drawing.Point(126, 742);
            this.LB_PartName.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.LB_PartName.MainFontColor = System.Drawing.Color.White;
            this.LB_PartName.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.LB_PartName.Name = "LB_PartName";
            this.LB_PartName.Size = new System.Drawing.Size(201, 37);
            this.LB_PartName.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LB_PartName.SubFontColor = System.Drawing.Color.Gray;
            this.LB_PartName.SubText = "";
            this.LB_PartName.TabIndex = 20883;
            this.LB_PartName.Tag = "";
            this.LB_PartName.Text = "NONE";
            this.LB_PartName.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.LB_PartName.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.LB_PartName.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.LB_PartName.ThemeIndex = 0;
            this.LB_PartName.UnitAreaRate = 30;
            this.LB_PartName.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LB_PartName.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.LB_PartName.UnitPositionVertical = false;
            this.LB_PartName.UnitText = "W";
            this.LB_PartName.UseBorder = true;
            this.LB_PartName.UseEdgeRadius = false;
            this.LB_PartName.UseImage = false;
            this.LB_PartName.UseSubFont = true;
            this.LB_PartName.UseUnitFont = false;
            // 
            // LB_WaferRow
            // 
            this.LB_WaferRow.BackGroundColor = System.Drawing.Color.DimGray;
            this.LB_WaferRow.BorderStroke = 2;
            this.LB_WaferRow.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.LB_WaferRow.Description = "";
            this.LB_WaferRow.DisabledColor = System.Drawing.Color.DarkGray;
            this.LB_WaferRow.EdgeRadius = 1;
            this.LB_WaferRow.ImagePosition = new System.Drawing.Point(0, 0);
            this.LB_WaferRow.ImageSize = new System.Drawing.Point(0, 0);
            this.LB_WaferRow.LoadImage = null;
            this.LB_WaferRow.Location = new System.Drawing.Point(445, 742);
            this.LB_WaferRow.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.LB_WaferRow.MainFontColor = System.Drawing.Color.White;
            this.LB_WaferRow.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.LB_WaferRow.Name = "LB_WaferRow";
            this.LB_WaferRow.Size = new System.Drawing.Size(201, 37);
            this.LB_WaferRow.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LB_WaferRow.SubFontColor = System.Drawing.Color.Gray;
            this.LB_WaferRow.SubText = "";
            this.LB_WaferRow.TabIndex = 20883;
            this.LB_WaferRow.Tag = "";
            this.LB_WaferRow.Text = "NONE";
            this.LB_WaferRow.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.LB_WaferRow.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.LB_WaferRow.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.LB_WaferRow.ThemeIndex = 0;
            this.LB_WaferRow.UnitAreaRate = 30;
            this.LB_WaferRow.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LB_WaferRow.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.LB_WaferRow.UnitPositionVertical = false;
            this.LB_WaferRow.UnitText = "W";
            this.LB_WaferRow.UseBorder = true;
            this.LB_WaferRow.UseEdgeRadius = false;
            this.LB_WaferRow.UseImage = false;
            this.LB_WaferRow.UseSubFont = true;
            this.LB_WaferRow.UseUnitFont = false;
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
            this.sys3Label15.Location = new System.Drawing.Point(10, 780);
            this.sys3Label15.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label15.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label15.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label15.Name = "sys3Label15";
            this.sys3Label15.Size = new System.Drawing.Size(115, 37);
            this.sys3Label15.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label15.SubFontColor = System.Drawing.Color.DarkRed;
            this.sys3Label15.SubText = "";
            this.sys3Label15.TabIndex = 20882;
            this.sys3Label15.Tag = "";
            this.sys3Label15.Text = "LOT TYPE";
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
            this.sys3Label16.Location = new System.Drawing.Point(329, 780);
            this.sys3Label16.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label16.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label16.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label16.Name = "sys3Label16";
            this.sys3Label16.Size = new System.Drawing.Size(115, 37);
            this.sys3Label16.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label16.SubFontColor = System.Drawing.Color.DarkRed;
            this.sys3Label16.SubText = "";
            this.sys3Label16.TabIndex = 20882;
            this.sys3Label16.Tag = "";
            this.sys3Label16.Text = "ANGLE";
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
            // LB_LotType
            // 
            this.LB_LotType.BackGroundColor = System.Drawing.Color.DimGray;
            this.LB_LotType.BorderStroke = 2;
            this.LB_LotType.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.LB_LotType.Description = "";
            this.LB_LotType.DisabledColor = System.Drawing.Color.DarkGray;
            this.LB_LotType.EdgeRadius = 1;
            this.LB_LotType.ImagePosition = new System.Drawing.Point(0, 0);
            this.LB_LotType.ImageSize = new System.Drawing.Point(0, 0);
            this.LB_LotType.LoadImage = null;
            this.LB_LotType.Location = new System.Drawing.Point(126, 780);
            this.LB_LotType.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.LB_LotType.MainFontColor = System.Drawing.Color.White;
            this.LB_LotType.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.LB_LotType.Name = "LB_LotType";
            this.LB_LotType.Size = new System.Drawing.Size(201, 37);
            this.LB_LotType.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LB_LotType.SubFontColor = System.Drawing.Color.Gray;
            this.LB_LotType.SubText = "";
            this.LB_LotType.TabIndex = 20883;
            this.LB_LotType.Tag = "";
            this.LB_LotType.Text = "NONE";
            this.LB_LotType.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.LB_LotType.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.LB_LotType.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.LB_LotType.ThemeIndex = 0;
            this.LB_LotType.UnitAreaRate = 30;
            this.LB_LotType.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LB_LotType.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.LB_LotType.UnitPositionVertical = false;
            this.LB_LotType.UnitText = "W";
            this.LB_LotType.UseBorder = true;
            this.LB_LotType.UseEdgeRadius = false;
            this.LB_LotType.UseImage = false;
            this.LB_LotType.UseSubFont = true;
            this.LB_LotType.UseUnitFont = false;
            // 
            // LB_Angle
            // 
            this.LB_Angle.BackGroundColor = System.Drawing.Color.DimGray;
            this.LB_Angle.BorderStroke = 2;
            this.LB_Angle.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.LB_Angle.Description = "";
            this.LB_Angle.DisabledColor = System.Drawing.Color.DarkGray;
            this.LB_Angle.EdgeRadius = 1;
            this.LB_Angle.ImagePosition = new System.Drawing.Point(0, 0);
            this.LB_Angle.ImageSize = new System.Drawing.Point(0, 0);
            this.LB_Angle.LoadImage = null;
            this.LB_Angle.Location = new System.Drawing.Point(445, 780);
            this.LB_Angle.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.LB_Angle.MainFontColor = System.Drawing.Color.White;
            this.LB_Angle.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.LB_Angle.Name = "LB_Angle";
            this.LB_Angle.Size = new System.Drawing.Size(201, 37);
            this.LB_Angle.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LB_Angle.SubFontColor = System.Drawing.Color.Gray;
            this.LB_Angle.SubText = "";
            this.LB_Angle.TabIndex = 20883;
            this.LB_Angle.Tag = "";
            this.LB_Angle.Text = "NONE";
            this.LB_Angle.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.LB_Angle.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.LB_Angle.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.LB_Angle.ThemeIndex = 0;
            this.LB_Angle.UnitAreaRate = 30;
            this.LB_Angle.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LB_Angle.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.LB_Angle.UnitPositionVertical = false;
            this.LB_Angle.UnitText = "W";
            this.LB_Angle.UseBorder = true;
            this.LB_Angle.UseEdgeRadius = false;
            this.LB_Angle.UseImage = false;
            this.LB_Angle.UseSubFont = true;
            this.LB_Angle.UseUnitFont = false;
            // 
            // sys3Label20
            // 
            this.sys3Label20.BackGroundColor = System.Drawing.Color.DarkGray;
            this.sys3Label20.BorderStroke = 2;
            this.sys3Label20.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.sys3Label20.Description = "";
            this.sys3Label20.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3Label20.EdgeRadius = 1;
            this.sys3Label20.ImagePosition = new System.Drawing.Point(0, 0);
            this.sys3Label20.ImageSize = new System.Drawing.Point(0, 0);
            this.sys3Label20.LoadImage = null;
            this.sys3Label20.Location = new System.Drawing.Point(10, 818);
            this.sys3Label20.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label20.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label20.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label20.Name = "sys3Label20";
            this.sys3Label20.Size = new System.Drawing.Size(115, 37);
            this.sys3Label20.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label20.SubFontColor = System.Drawing.Color.DarkRed;
            this.sys3Label20.SubText = "";
            this.sys3Label20.TabIndex = 20882;
            this.sys3Label20.Tag = "";
            this.sys3Label20.Text = "STEP SEQ";
            this.sys3Label20.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3Label20.TextAlignSub = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
            this.sys3Label20.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label20.ThemeIndex = 0;
            this.sys3Label20.UnitAreaRate = 40;
            this.sys3Label20.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label20.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sys3Label20.UnitPositionVertical = false;
            this.sys3Label20.UnitText = "";
            this.sys3Label20.UseBorder = true;
            this.sys3Label20.UseEdgeRadius = false;
            this.sys3Label20.UseImage = false;
            this.sys3Label20.UseSubFont = true;
            this.sys3Label20.UseUnitFont = false;
            // 
            // LB_StepSeq
            // 
            this.LB_StepSeq.BackGroundColor = System.Drawing.Color.DimGray;
            this.LB_StepSeq.BorderStroke = 2;
            this.LB_StepSeq.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.LB_StepSeq.Description = "";
            this.LB_StepSeq.DisabledColor = System.Drawing.Color.DarkGray;
            this.LB_StepSeq.EdgeRadius = 1;
            this.LB_StepSeq.ImagePosition = new System.Drawing.Point(0, 0);
            this.LB_StepSeq.ImageSize = new System.Drawing.Point(0, 0);
            this.LB_StepSeq.LoadImage = null;
            this.LB_StepSeq.Location = new System.Drawing.Point(126, 818);
            this.LB_StepSeq.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.LB_StepSeq.MainFontColor = System.Drawing.Color.White;
            this.LB_StepSeq.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.LB_StepSeq.Name = "LB_StepSeq";
            this.LB_StepSeq.Size = new System.Drawing.Size(201, 37);
            this.LB_StepSeq.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LB_StepSeq.SubFontColor = System.Drawing.Color.Gray;
            this.LB_StepSeq.SubText = "";
            this.LB_StepSeq.TabIndex = 20883;
            this.LB_StepSeq.Tag = "";
            this.LB_StepSeq.Text = "NONE";
            this.LB_StepSeq.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.LB_StepSeq.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.LB_StepSeq.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.LB_StepSeq.ThemeIndex = 0;
            this.LB_StepSeq.UnitAreaRate = 30;
            this.LB_StepSeq.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LB_StepSeq.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.LB_StepSeq.UnitPositionVertical = false;
            this.LB_StepSeq.UnitText = "W";
            this.LB_StepSeq.UseBorder = true;
            this.LB_StepSeq.UseEdgeRadius = false;
            this.LB_StepSeq.UseImage = false;
            this.LB_StepSeq.UseSubFont = true;
            this.LB_StepSeq.UseUnitFont = false;
            // 
            // sys3Label24
            // 
            this.sys3Label24.BackGroundColor = System.Drawing.Color.DarkGray;
            this.sys3Label24.BorderStroke = 2;
            this.sys3Label24.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.sys3Label24.Description = "";
            this.sys3Label24.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3Label24.EdgeRadius = 1;
            this.sys3Label24.ImagePosition = new System.Drawing.Point(0, 0);
            this.sys3Label24.ImageSize = new System.Drawing.Point(0, 0);
            this.sys3Label24.LoadImage = null;
            this.sys3Label24.Location = new System.Drawing.Point(328, 856);
            this.sys3Label24.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label24.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label24.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label24.Name = "sys3Label24";
            this.sys3Label24.Size = new System.Drawing.Size(115, 37);
            this.sys3Label24.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label24.SubFontColor = System.Drawing.Color.DarkRed;
            this.sys3Label24.SubText = "";
            this.sys3Label24.TabIndex = 20882;
            this.sys3Label24.Tag = "";
            this.sys3Label24.Text = "SLOT NO";
            this.sys3Label24.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3Label24.TextAlignSub = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
            this.sys3Label24.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label24.ThemeIndex = 0;
            this.sys3Label24.UnitAreaRate = 40;
            this.sys3Label24.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label24.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sys3Label24.UnitPositionVertical = false;
            this.sys3Label24.UnitText = "";
            this.sys3Label24.UseBorder = true;
            this.sys3Label24.UseEdgeRadius = false;
            this.sys3Label24.UseImage = false;
            this.sys3Label24.UseSubFont = true;
            this.sys3Label24.UseUnitFont = false;
            // 
            // sys3Label25
            // 
            this.sys3Label25.BackGroundColor = System.Drawing.Color.DarkGray;
            this.sys3Label25.BorderStroke = 2;
            this.sys3Label25.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.sys3Label25.Description = "";
            this.sys3Label25.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3Label25.EdgeRadius = 1;
            this.sys3Label25.ImagePosition = new System.Drawing.Point(0, 0);
            this.sys3Label25.ImageSize = new System.Drawing.Point(0, 0);
            this.sys3Label25.LoadImage = null;
            this.sys3Label25.Location = new System.Drawing.Point(329, 818);
            this.sys3Label25.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label25.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label25.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label25.Name = "sys3Label25";
            this.sys3Label25.Size = new System.Drawing.Size(115, 37);
            this.sys3Label25.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label25.SubFontColor = System.Drawing.Color.DarkRed;
            this.sys3Label25.SubText = "";
            this.sys3Label25.TabIndex = 20882;
            this.sys3Label25.Tag = "";
            this.sys3Label25.Text = "COUNT CHIPS";
            this.sys3Label25.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3Label25.TextAlignSub = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
            this.sys3Label25.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label25.ThemeIndex = 0;
            this.sys3Label25.UnitAreaRate = 40;
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
            // LB_SlotNo
            // 
            this.LB_SlotNo.BackGroundColor = System.Drawing.Color.DimGray;
            this.LB_SlotNo.BorderStroke = 2;
            this.LB_SlotNo.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.LB_SlotNo.Description = "";
            this.LB_SlotNo.DisabledColor = System.Drawing.Color.DarkGray;
            this.LB_SlotNo.EdgeRadius = 1;
            this.LB_SlotNo.ImagePosition = new System.Drawing.Point(0, 0);
            this.LB_SlotNo.ImageSize = new System.Drawing.Point(0, 0);
            this.LB_SlotNo.LoadImage = null;
            this.LB_SlotNo.Location = new System.Drawing.Point(444, 856);
            this.LB_SlotNo.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.LB_SlotNo.MainFontColor = System.Drawing.Color.White;
            this.LB_SlotNo.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.LB_SlotNo.Name = "LB_SlotNo";
            this.LB_SlotNo.Size = new System.Drawing.Size(201, 37);
            this.LB_SlotNo.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LB_SlotNo.SubFontColor = System.Drawing.Color.Gray;
            this.LB_SlotNo.SubText = "";
            this.LB_SlotNo.TabIndex = 20883;
            this.LB_SlotNo.Tag = "";
            this.LB_SlotNo.Text = "NONE";
            this.LB_SlotNo.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.LB_SlotNo.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.LB_SlotNo.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.LB_SlotNo.ThemeIndex = 0;
            this.LB_SlotNo.UnitAreaRate = 30;
            this.LB_SlotNo.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LB_SlotNo.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.LB_SlotNo.UnitPositionVertical = false;
            this.LB_SlotNo.UnitText = "W";
            this.LB_SlotNo.UseBorder = true;
            this.LB_SlotNo.UseEdgeRadius = false;
            this.LB_SlotNo.UseImage = false;
            this.LB_SlotNo.UseSubFont = true;
            this.LB_SlotNo.UseUnitFont = false;
            // 
            // LB_CountChips
            // 
            this.LB_CountChips.BackGroundColor = System.Drawing.Color.DimGray;
            this.LB_CountChips.BorderStroke = 2;
            this.LB_CountChips.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.LB_CountChips.Description = "";
            this.LB_CountChips.DisabledColor = System.Drawing.Color.DarkGray;
            this.LB_CountChips.EdgeRadius = 1;
            this.LB_CountChips.ImagePosition = new System.Drawing.Point(0, 0);
            this.LB_CountChips.ImageSize = new System.Drawing.Point(0, 0);
            this.LB_CountChips.LoadImage = null;
            this.LB_CountChips.Location = new System.Drawing.Point(445, 818);
            this.LB_CountChips.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.LB_CountChips.MainFontColor = System.Drawing.Color.White;
            this.LB_CountChips.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.LB_CountChips.Name = "LB_CountChips";
            this.LB_CountChips.Size = new System.Drawing.Size(201, 37);
            this.LB_CountChips.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LB_CountChips.SubFontColor = System.Drawing.Color.Gray;
            this.LB_CountChips.SubText = "";
            this.LB_CountChips.TabIndex = 20883;
            this.LB_CountChips.Tag = "";
            this.LB_CountChips.Text = "NONE";
            this.LB_CountChips.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.LB_CountChips.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.LB_CountChips.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.LB_CountChips.ThemeIndex = 0;
            this.LB_CountChips.UnitAreaRate = 30;
            this.LB_CountChips.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LB_CountChips.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.LB_CountChips.UnitPositionVertical = false;
            this.LB_CountChips.UnitText = "W";
            this.LB_CountChips.UseBorder = true;
            this.LB_CountChips.UseEdgeRadius = false;
            this.LB_CountChips.UseImage = false;
            this.LB_CountChips.UseSubFont = true;
            this.LB_CountChips.UseUnitFont = false;
            // 
            // Operation_Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.LB_CountChips);
            this.Controls.Add(this.LB_Angle);
            this.Controls.Add(this.LB_WaferRow);
            this.Controls.Add(this.LB_WaferCol);
            this.Controls.Add(this.LB_SlotNo);
            this.Controls.Add(this.LB_StepSeq);
            this.Controls.Add(this.LB_LotType);
            this.Controls.Add(this.LB_PartName);
            this.Controls.Add(this.LB_LotID);
            this.Controls.Add(this.sys3Label25);
            this.Controls.Add(this.sys3Label16);
            this.Controls.Add(this.sys3Label10);
            this.Controls.Add(this.sys3Label7);
            this.Controls.Add(this.sys3Label24);
            this.Controls.Add(this.sys3Label20);
            this.Controls.Add(this.sys3Label15);
            this.Controls.Add(this.sys3Label9);
            this.Controls.Add(this.sys3Label6);
            this.Controls.Add(this.m_lblPreHeatingTime);
            this.Controls.Add(this.sys3Label3);
            this.Controls.Add(this.m_lblWorkStatus);
            this.Controls.Add(this.m_lblID);
            this.Controls.Add(this.sys3Label1);
            this.Controls.Add(this.sys3Label2);
            this.Controls.Add(this.gridViewControl_WorkStatus_Parameter);
            this.Controls.Add(this.sys3GroupBox8);
            this.Controls.Add(this.dataGridView_Heater);
            this.Controls.Add(this.gridVeiwControl_Util_Device);
            this.Controls.Add(this.gridVeiwControl_Head_Device);
            this.Controls.Add(this.gridVeiwControl_Block_Device);
            this.Controls.Add(this.gridVeiwControl_Handler_Device);
            this.Controls.Add(this.gridVeiwControl_Smema_Device);
            this.Controls.Add(this.gridVeiwControl_Laser_Device);
            this.Controls.Add(this.sys3button1);
            this.Controls.Add(this.sys3button3);
            this.Controls.Add(this.sys3button2);
            this.Controls.Add(this.btn_Reset);
            this.Controls.Add(this.m_lblAlarmCodeMonitor);
            this.Controls.Add(this.m_lblAlarmCodePort3);
            this.Controls.Add(this.m_lblAlarmCodePort2);
            this.Controls.Add(this.m_lblAlarmCodePort1);
            this.Controls.Add(this.sys3Label4);
            this.Controls.Add(this.sys3Label17);
            this.Controls.Add(this.sys3Label14);
            this.Controls.Add(this.sys3Label13);
            this.Controls.Add(this.sys3GroupBox9);
            this.Controls.Add(this.sys3GroupBox6);
            this.Controls.Add(this.sys3GroupBox5);
            this.Controls.Add(this.sys3GroupBox7);
            this.Controls.Add(this.sys3GroupBox3);
            this.Controls.Add(this.lblBondHead);
            this.Controls.Add(this.lblWorkBlock);
            this.Controls.Add(this.lblTransfer);
            this.Controls.Add(this.btnRearMagnetic);
            this.Controls.Add(this.btnRearDoor);
            this.Controls.Add(this.btnFrontMagnetic);
            this.Controls.Add(this.btnFrontDoor);
            this.Controls.Add(this.m_labelRunMode);
            this.Controls.Add(this.m_btnStop);
            this.Controls.Add(this.m_btnRun);
            this.Controls.Add(this.m_btnInitialize);
            this.Controls.Add(this.m_groupRunMode);
            this.Controls.Add(this.sys3GroupBox1);
            this.Controls.Add(this.sys3GroupBox2);
            this.Controls.Add(this.sys3GroupBox4);
            this.Name = "Operation_Main";
            this.Size = new System.Drawing.Size(1140, 900);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Heater)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private Sys3Controls.Sys3button m_btnInitialize;
		private Sys3Controls.Sys3button m_btnRun;
        private Sys3Controls.Sys3button m_btnStop;
        private Sys3Controls.Sys3GroupBox sys3GroupBox4;
        private Sys3Controls.Sys3GroupBox m_groupRunMode;
        private Sys3Controls.Sys3Label m_labelRunMode;
        private Sys3Controls.Sys3DoorButton btnFrontDoor;
        private Sys3Controls.Sys3GroupBox sys3GroupBox1;
        private Sys3Controls.Sys3Label lblTransfer;
        private Sys3Controls.Sys3Label lblWorkBlock;
        private Sys3Controls.Sys3Label lblBondHead;
        private Sys3Controls.Sys3GroupBox sys3GroupBox2;
        private Sys3Controls.Sys3button sys3button1;
        private Sys3Controls.Sys3button btn_Reset;
        private Sys3Controls.Sys3Label m_lblAlarmCodeMonitor;
        private Sys3Controls.Sys3Label m_lblAlarmCodePort3;
        private Sys3Controls.Sys3Label m_lblAlarmCodePort2;
        private Sys3Controls.Sys3Label m_lblAlarmCodePort1;
        private Sys3Controls.Sys3Label sys3Label4;
        private Sys3Controls.Sys3Label sys3Label17;
        private Sys3Controls.Sys3Label sys3Label14;
        private Sys3Controls.Sys3Label sys3Label13;
        private Sys3Controls.Sys3GroupBox sys3GroupBox3;
        private Component.GridVeiwControl_Device gridVeiwControl_Laser_Device;
        private Sys3Controls.Sys3GroupBox sys3GroupBox6;
        private Component.GridVeiwControl_Device gridVeiwControl_Smema_Device;
        private Sys3Controls.Sys3GroupBox sys3GroupBox7;
        private System.Windows.Forms.DataGridView dataGridView_Heater;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private Component.GridVeiwControl_Device gridVeiwControl_Handler_Device;
        private Component.GridVeiwControl_Device gridVeiwControl_Block_Device;
        private Sys3Controls.Sys3GroupBox sys3GroupBox5;
        private Component.GridVeiwControl_Device gridVeiwControl_Head_Device;
        private Component.GridVeiwControl_Device gridVeiwControl_Util_Device;
        private Sys3Controls.Sys3DoorButton btnRearDoor;
        private Sys3Controls.Sys3button sys3button2;
        private Sys3Controls.Sys3button sys3button3;
        private Sys3Controls.Sys3Label m_lblWorkStatus;
        private Sys3Controls.Sys3Label m_lblID;
        private Sys3Controls.Sys3Label sys3Label1;
        private Sys3Controls.Sys3Label sys3Label2;
        private Component.GridViewControl_Parameter gridViewControl_WorkStatus_Parameter;
        private Sys3Controls.Sys3GroupBox sys3GroupBox8;
        private Sys3Controls.Sys3Label m_lblPreHeatingTime;
        private Sys3Controls.Sys3Label sys3Label3;
        private Sys3Controls.Sys3DoorButton btnFrontMagnetic;
        private Sys3Controls.Sys3DoorButton btnRearMagnetic;
        private Sys3Controls.Sys3GroupBox sys3GroupBox9;
        private Sys3Controls.Sys3Label LB_LotID;
        private Sys3Controls.Sys3Label sys3Label6;
        private Sys3Controls.Sys3Label sys3Label7;
        private Sys3Controls.Sys3Label LB_WaferCol;
        private Sys3Controls.Sys3Label sys3Label9;
        private Sys3Controls.Sys3Label sys3Label10;
        private Sys3Controls.Sys3Label LB_PartName;
        private Sys3Controls.Sys3Label LB_WaferRow;
        private Sys3Controls.Sys3Label sys3Label15;
        private Sys3Controls.Sys3Label sys3Label16;
        private Sys3Controls.Sys3Label LB_LotType;
        private Sys3Controls.Sys3Label LB_Angle;
        private Sys3Controls.Sys3Label sys3Label20;
        private Sys3Controls.Sys3Label LB_StepSeq;
        private Sys3Controls.Sys3Label sys3Label24;
        private Sys3Controls.Sys3Label sys3Label25;
        private Sys3Controls.Sys3Label LB_SlotNo;
        private Sys3Controls.Sys3Label LB_CountChips;
	}
}
