namespace FrameOfSystem3.Views.Config.MotionPanel
{
    partial class MotorHome
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
			this.m_groupHomeConfig = new Sys3Controls.Sys3GroupBox();
			this.m_groupHomeSpeedConfig = new Sys3Controls.Sys3GroupBox();
			this.m_lblSpeedPattern = new Sys3Controls.Sys3Label();
			this.m_lblVelocityStart = new Sys3Controls.Sys3Label();
			this.m_lblTime = new Sys3Controls.Sys3Label();
			this.m_lblJerk = new Sys3Controls.Sys3Label();
			this.m_lblHomeTimeout = new Sys3Controls.Sys3Label();
			this.m_labelVelocityStart = new Sys3Controls.Sys3Label();
			this.m_labelVelocityEnd = new Sys3Controls.Sys3Label();
			this.m_labelAccelTime = new Sys3Controls.Sys3Label();
			this.m_labelDecelTime = new Sys3Controls.Sys3Label();
			this.m_labelHomeTimeout = new Sys3Controls.Sys3Label();
			this.m_labelJerkAccel = new Sys3Controls.Sys3Label();
			this.m_labelJerkDecel = new Sys3Controls.Sys3Label();
			this.m_labelSpeedPattern = new Sys3Controls.Sys3Label();
			this.m_lblAlwaysHomeEnd = new Sys3Controls.Sys3Label();
			this.m_lblEZCount = new Sys3Controls.Sys3Label();
			this.m_lblEscapeDistance = new Sys3Controls.Sys3Label();
			this.m_lblHomeLogic = new Sys3Controls.Sys3Label();
			this.m_lblHomeMode = new Sys3Controls.Sys3Label();
			this.m_lblBasePosition = new Sys3Controls.Sys3Label();
			this.m_lblHomeOffset = new Sys3Controls.Sys3Label();
			this.m_lblHomeDirection = new Sys3Controls.Sys3Label();
			this.m_labelHomeMode = new Sys3Controls.Sys3Label();
			this.m_labelHomeLogic = new Sys3Controls.Sys3Label();
			this.m_labelEscapeDistance = new Sys3Controls.Sys3Label();
			this.m_labelEZCount = new Sys3Controls.Sys3Label();
			this.m_labelBasePosition = new Sys3Controls.Sys3Label();
			this.m_labelHomeDirection = new Sys3Controls.Sys3Label();
			this.m_labelHomeOffset = new Sys3Controls.Sys3Label();
			this.m_ToggleAlwaysHomeEnd = new Sys3Controls.Sys3ToggleButton();
			this.m_lblAbsolutePosition = new Sys3Controls.Sys3Label();
			this.m_labelAbsolutePosition = new Sys3Controls.Sys3Label();
			this.m_labelAbsolutePositionSet = new Sys3Controls.Sys3Label();
			this.m_btnGet = new Sys3Controls.Sys3button();
			this.m_btnSet = new Sys3Controls.Sys3button();
			this.sys3Label1 = new Sys3Controls.Sys3Label();
			this.sys3Label2 = new Sys3Controls.Sys3Label();
			this.sys3Label3 = new Sys3Controls.Sys3Label();
			this.m_labelAccelVelocity = new Sys3Controls.Sys3Label();
			this.m_labelDeccelVelocity = new Sys3Controls.Sys3Label();
			this.SuspendLayout();
			// 
			// m_groupHomeConfig
			// 
			this.m_groupHomeConfig.BackGroundColor = System.Drawing.Color.WhiteSmoke;
			this.m_groupHomeConfig.EdgeBorderStroke = 2;
			this.m_groupHomeConfig.EdgeRadius = 2;
			this.m_groupHomeConfig.LabelFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_groupHomeConfig.LabelGradientColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
			this.m_groupHomeConfig.LabelGradientColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.m_groupHomeConfig.LabelHeight = 30;
			this.m_groupHomeConfig.LabelTextColor = System.Drawing.Color.Black;
			this.m_groupHomeConfig.Location = new System.Drawing.Point(0, 0);
			this.m_groupHomeConfig.Name = "m_groupHomeConfig";
			this.m_groupHomeConfig.Size = new System.Drawing.Size(670, 399);
			this.m_groupHomeConfig.TabIndex = 1372;
			this.m_groupHomeConfig.Text = "HOME CONFIGURATION";
			this.m_groupHomeConfig.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_groupHomeConfig.UseLabelBorder = true;
			// 
			// m_groupHomeSpeedConfig
			// 
			this.m_groupHomeSpeedConfig.BackGroundColor = System.Drawing.Color.WhiteSmoke;
			this.m_groupHomeSpeedConfig.EdgeBorderStroke = 2;
			this.m_groupHomeSpeedConfig.EdgeRadius = 2;
			this.m_groupHomeSpeedConfig.LabelFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_groupHomeSpeedConfig.LabelGradientColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
			this.m_groupHomeSpeedConfig.LabelGradientColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.m_groupHomeSpeedConfig.LabelHeight = 30;
			this.m_groupHomeSpeedConfig.LabelTextColor = System.Drawing.Color.Black;
			this.m_groupHomeSpeedConfig.Location = new System.Drawing.Point(667, 0);
			this.m_groupHomeSpeedConfig.Name = "m_groupHomeSpeedConfig";
			this.m_groupHomeSpeedConfig.Size = new System.Drawing.Size(453, 399);
			this.m_groupHomeSpeedConfig.TabIndex = 1373;
			this.m_groupHomeSpeedConfig.Text = "HOME SPEED CONFIGURATION";
			this.m_groupHomeSpeedConfig.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_groupHomeSpeedConfig.UseLabelBorder = true;
			// 
			// m_lblSpeedPattern
			// 
			this.m_lblSpeedPattern.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_lblSpeedPattern.BorderStroke = 2;
			this.m_lblSpeedPattern.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_lblSpeedPattern.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_lblSpeedPattern.EdgeRadius = 1;
			this.m_lblSpeedPattern.Location = new System.Drawing.Point(674, 47);
			this.m_lblSpeedPattern.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblSpeedPattern.MainFontColor = System.Drawing.Color.Black;
			this.m_lblSpeedPattern.Name = "m_lblSpeedPattern";
			this.m_lblSpeedPattern.Size = new System.Drawing.Size(126, 39);
			this.m_lblSpeedPattern.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_lblSpeedPattern.SubFontColor = System.Drawing.Color.Black;
			this.m_lblSpeedPattern.SubText = "";
			this.m_lblSpeedPattern.TabIndex = 1387;
			this.m_lblSpeedPattern.Text = "SPEED PATTERN";
			this.m_lblSpeedPattern.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_lblSpeedPattern.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblSpeedPattern.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblSpeedPattern.UnitAreaRate = 40;
			this.m_lblSpeedPattern.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_lblSpeedPattern.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_lblSpeedPattern.UnitPositionVertical = false;
			this.m_lblSpeedPattern.UnitText = "";
			this.m_lblSpeedPattern.UseBorder = true;
			this.m_lblSpeedPattern.UseEdgeRadius = false;
			this.m_lblSpeedPattern.UseSubFont = false;
			this.m_lblSpeedPattern.UseUnitFont = false;
			// 
			// m_lblVelocityStart
			// 
			this.m_lblVelocityStart.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_lblVelocityStart.BorderStroke = 2;
			this.m_lblVelocityStart.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_lblVelocityStart.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_lblVelocityStart.EdgeRadius = 1;
			this.m_lblVelocityStart.Location = new System.Drawing.Point(674, 89);
			this.m_lblVelocityStart.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblVelocityStart.MainFontColor = System.Drawing.Color.Black;
			this.m_lblVelocityStart.Name = "m_lblVelocityStart";
			this.m_lblVelocityStart.Size = new System.Drawing.Size(126, 39);
			this.m_lblVelocityStart.SubFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblVelocityStart.SubFontColor = System.Drawing.Color.DarkBlue;
			this.m_lblVelocityStart.SubText = "(START, END)";
			this.m_lblVelocityStart.TabIndex = 1387;
			this.m_lblVelocityStart.Text = "VELOCITY";
			this.m_lblVelocityStart.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_lblVelocityStart.TextAlignSub = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_lblVelocityStart.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblVelocityStart.UnitAreaRate = 40;
			this.m_lblVelocityStart.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_lblVelocityStart.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_lblVelocityStart.UnitPositionVertical = false;
			this.m_lblVelocityStart.UnitText = "";
			this.m_lblVelocityStart.UseBorder = true;
			this.m_lblVelocityStart.UseEdgeRadius = false;
			this.m_lblVelocityStart.UseSubFont = true;
			this.m_lblVelocityStart.UseUnitFont = false;
			// 
			// m_lblTime
			// 
			this.m_lblTime.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_lblTime.BorderStroke = 2;
			this.m_lblTime.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_lblTime.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_lblTime.EdgeRadius = 1;
			this.m_lblTime.Location = new System.Drawing.Point(674, 298);
			this.m_lblTime.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblTime.MainFontColor = System.Drawing.Color.Black;
			this.m_lblTime.Name = "m_lblTime";
			this.m_lblTime.Size = new System.Drawing.Size(126, 39);
			this.m_lblTime.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_lblTime.SubFontColor = System.Drawing.Color.Black;
			this.m_lblTime.SubText = "";
			this.m_lblTime.TabIndex = 1387;
			this.m_lblTime.Text = "TIME";
			this.m_lblTime.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_lblTime.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblTime.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblTime.UnitAreaRate = 40;
			this.m_lblTime.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_lblTime.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_lblTime.UnitPositionVertical = false;
			this.m_lblTime.UnitText = "";
			this.m_lblTime.UseBorder = true;
			this.m_lblTime.UseEdgeRadius = false;
			this.m_lblTime.UseSubFont = false;
			this.m_lblTime.UseUnitFont = false;
			// 
			// m_lblJerk
			// 
			this.m_lblJerk.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_lblJerk.BorderStroke = 2;
			this.m_lblJerk.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_lblJerk.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_lblJerk.EdgeRadius = 1;
			this.m_lblJerk.Location = new System.Drawing.Point(674, 340);
			this.m_lblJerk.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblJerk.MainFontColor = System.Drawing.Color.Black;
			this.m_lblJerk.Name = "m_lblJerk";
			this.m_lblJerk.Size = new System.Drawing.Size(126, 39);
			this.m_lblJerk.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_lblJerk.SubFontColor = System.Drawing.Color.Black;
			this.m_lblJerk.SubText = "";
			this.m_lblJerk.TabIndex = 1387;
			this.m_lblJerk.Text = "JERK";
			this.m_lblJerk.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_lblJerk.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblJerk.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblJerk.UnitAreaRate = 40;
			this.m_lblJerk.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_lblJerk.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_lblJerk.UnitPositionVertical = false;
			this.m_lblJerk.UnitText = "";
			this.m_lblJerk.UseBorder = true;
			this.m_lblJerk.UseEdgeRadius = false;
			this.m_lblJerk.UseSubFont = false;
			this.m_lblJerk.UseUnitFont = false;
			// 
			// m_lblHomeTimeout
			// 
			this.m_lblHomeTimeout.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_lblHomeTimeout.BorderStroke = 2;
			this.m_lblHomeTimeout.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_lblHomeTimeout.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_lblHomeTimeout.EdgeRadius = 1;
			this.m_lblHomeTimeout.Location = new System.Drawing.Point(674, 131);
			this.m_lblHomeTimeout.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblHomeTimeout.MainFontColor = System.Drawing.Color.Black;
			this.m_lblHomeTimeout.Name = "m_lblHomeTimeout";
			this.m_lblHomeTimeout.Size = new System.Drawing.Size(126, 39);
			this.m_lblHomeTimeout.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_lblHomeTimeout.SubFontColor = System.Drawing.Color.Black;
			this.m_lblHomeTimeout.SubText = "";
			this.m_lblHomeTimeout.TabIndex = 1387;
			this.m_lblHomeTimeout.Text = "HOME TIMEOUT";
			this.m_lblHomeTimeout.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_lblHomeTimeout.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblHomeTimeout.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblHomeTimeout.UnitAreaRate = 40;
			this.m_lblHomeTimeout.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_lblHomeTimeout.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_lblHomeTimeout.UnitPositionVertical = false;
			this.m_lblHomeTimeout.UnitText = "";
			this.m_lblHomeTimeout.UseBorder = true;
			this.m_lblHomeTimeout.UseEdgeRadius = false;
			this.m_lblHomeTimeout.UseSubFont = false;
			this.m_lblHomeTimeout.UseUnitFont = false;
			// 
			// m_labelVelocityStart
			// 
			this.m_labelVelocityStart.BackGroundColor = System.Drawing.Color.White;
			this.m_labelVelocityStart.BorderStroke = 2;
			this.m_labelVelocityStart.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelVelocityStart.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelVelocityStart.EdgeRadius = 1;
			this.m_labelVelocityStart.Enabled = false;
			this.m_labelVelocityStart.Location = new System.Drawing.Point(802, 89);
			this.m_labelVelocityStart.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelVelocityStart.MainFontColor = System.Drawing.Color.Black;
			this.m_labelVelocityStart.Name = "m_labelVelocityStart";
			this.m_labelVelocityStart.Size = new System.Drawing.Size(154, 39);
			this.m_labelVelocityStart.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_labelVelocityStart.SubFontColor = System.Drawing.Color.Black;
			this.m_labelVelocityStart.SubText = "";
			this.m_labelVelocityStart.TabIndex = 1;
			this.m_labelVelocityStart.Text = "--";
			this.m_labelVelocityStart.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelVelocityStart.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelVelocityStart.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelVelocityStart.UnitAreaRate = 37;
			this.m_labelVelocityStart.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelVelocityStart.UnitFontColor = System.Drawing.Color.Black;
			this.m_labelVelocityStart.UnitPositionVertical = false;
			this.m_labelVelocityStart.UnitText = "mm/s";
			this.m_labelVelocityStart.UseBorder = true;
			this.m_labelVelocityStart.UseEdgeRadius = false;
			this.m_labelVelocityStart.UseSubFont = false;
			this.m_labelVelocityStart.UseUnitFont = true;
			this.m_labelVelocityStart.Click += new System.EventHandler(this.Click_SpeedConfiguration);
			// 
			// m_labelVelocityEnd
			// 
			this.m_labelVelocityEnd.BackGroundColor = System.Drawing.Color.White;
			this.m_labelVelocityEnd.BorderStroke = 2;
			this.m_labelVelocityEnd.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelVelocityEnd.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelVelocityEnd.EdgeRadius = 1;
			this.m_labelVelocityEnd.Enabled = false;
			this.m_labelVelocityEnd.Location = new System.Drawing.Point(958, 89);
			this.m_labelVelocityEnd.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelVelocityEnd.MainFontColor = System.Drawing.Color.Black;
			this.m_labelVelocityEnd.Name = "m_labelVelocityEnd";
			this.m_labelVelocityEnd.Size = new System.Drawing.Size(154, 39);
			this.m_labelVelocityEnd.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_labelVelocityEnd.SubFontColor = System.Drawing.Color.Black;
			this.m_labelVelocityEnd.SubText = "";
			this.m_labelVelocityEnd.TabIndex = 2;
			this.m_labelVelocityEnd.Text = "--";
			this.m_labelVelocityEnd.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelVelocityEnd.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelVelocityEnd.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelVelocityEnd.UnitAreaRate = 37;
			this.m_labelVelocityEnd.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelVelocityEnd.UnitFontColor = System.Drawing.Color.Black;
			this.m_labelVelocityEnd.UnitPositionVertical = false;
			this.m_labelVelocityEnd.UnitText = "mm/s";
			this.m_labelVelocityEnd.UseBorder = true;
			this.m_labelVelocityEnd.UseEdgeRadius = false;
			this.m_labelVelocityEnd.UseSubFont = false;
			this.m_labelVelocityEnd.UseUnitFont = true;
			this.m_labelVelocityEnd.Click += new System.EventHandler(this.Click_SpeedConfiguration);
			// 
			// m_labelAccelTime
			// 
			this.m_labelAccelTime.BackGroundColor = System.Drawing.Color.White;
			this.m_labelAccelTime.BorderStroke = 2;
			this.m_labelAccelTime.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelAccelTime.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelAccelTime.EdgeRadius = 1;
			this.m_labelAccelTime.Enabled = false;
			this.m_labelAccelTime.Location = new System.Drawing.Point(802, 298);
			this.m_labelAccelTime.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelAccelTime.MainFontColor = System.Drawing.Color.Black;
			this.m_labelAccelTime.Name = "m_labelAccelTime";
			this.m_labelAccelTime.Size = new System.Drawing.Size(154, 39);
			this.m_labelAccelTime.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_labelAccelTime.SubFontColor = System.Drawing.Color.Black;
			this.m_labelAccelTime.SubText = "";
			this.m_labelAccelTime.TabIndex = 3;
			this.m_labelAccelTime.Text = "--";
			this.m_labelAccelTime.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelAccelTime.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelAccelTime.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelAccelTime.UnitAreaRate = 37;
			this.m_labelAccelTime.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelAccelTime.UnitFontColor = System.Drawing.Color.Black;
			this.m_labelAccelTime.UnitPositionVertical = false;
			this.m_labelAccelTime.UnitText = "sec";
			this.m_labelAccelTime.UseBorder = true;
			this.m_labelAccelTime.UseEdgeRadius = false;
			this.m_labelAccelTime.UseSubFont = false;
			this.m_labelAccelTime.UseUnitFont = true;
			this.m_labelAccelTime.Click += new System.EventHandler(this.Click_SpeedConfiguration);
			// 
			// m_labelDecelTime
			// 
			this.m_labelDecelTime.BackGroundColor = System.Drawing.Color.White;
			this.m_labelDecelTime.BorderStroke = 2;
			this.m_labelDecelTime.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelDecelTime.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelDecelTime.EdgeRadius = 1;
			this.m_labelDecelTime.Enabled = false;
			this.m_labelDecelTime.Location = new System.Drawing.Point(958, 298);
			this.m_labelDecelTime.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelDecelTime.MainFontColor = System.Drawing.Color.Black;
			this.m_labelDecelTime.Name = "m_labelDecelTime";
			this.m_labelDecelTime.Size = new System.Drawing.Size(154, 39);
			this.m_labelDecelTime.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_labelDecelTime.SubFontColor = System.Drawing.Color.Black;
			this.m_labelDecelTime.SubText = "";
			this.m_labelDecelTime.TabIndex = 4;
			this.m_labelDecelTime.Text = "--";
			this.m_labelDecelTime.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelDecelTime.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelDecelTime.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelDecelTime.UnitAreaRate = 37;
			this.m_labelDecelTime.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelDecelTime.UnitFontColor = System.Drawing.Color.Black;
			this.m_labelDecelTime.UnitPositionVertical = false;
			this.m_labelDecelTime.UnitText = "sec";
			this.m_labelDecelTime.UseBorder = true;
			this.m_labelDecelTime.UseEdgeRadius = false;
			this.m_labelDecelTime.UseSubFont = false;
			this.m_labelDecelTime.UseUnitFont = true;
			this.m_labelDecelTime.Click += new System.EventHandler(this.Click_SpeedConfiguration);
			// 
			// m_labelHomeTimeout
			// 
			this.m_labelHomeTimeout.BackGroundColor = System.Drawing.Color.White;
			this.m_labelHomeTimeout.BorderStroke = 2;
			this.m_labelHomeTimeout.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelHomeTimeout.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelHomeTimeout.EdgeRadius = 1;
			this.m_labelHomeTimeout.Enabled = false;
			this.m_labelHomeTimeout.Location = new System.Drawing.Point(802, 131);
			this.m_labelHomeTimeout.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelHomeTimeout.MainFontColor = System.Drawing.Color.Black;
			this.m_labelHomeTimeout.Name = "m_labelHomeTimeout";
			this.m_labelHomeTimeout.Size = new System.Drawing.Size(310, 39);
			this.m_labelHomeTimeout.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_labelHomeTimeout.SubFontColor = System.Drawing.Color.Black;
			this.m_labelHomeTimeout.SubText = "";
			this.m_labelHomeTimeout.TabIndex = 7;
			this.m_labelHomeTimeout.Text = "--";
			this.m_labelHomeTimeout.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelHomeTimeout.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelHomeTimeout.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelHomeTimeout.UnitAreaRate = 40;
			this.m_labelHomeTimeout.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelHomeTimeout.UnitFontColor = System.Drawing.Color.Black;
			this.m_labelHomeTimeout.UnitPositionVertical = false;
			this.m_labelHomeTimeout.UnitText = "ms";
			this.m_labelHomeTimeout.UseBorder = true;
			this.m_labelHomeTimeout.UseEdgeRadius = false;
			this.m_labelHomeTimeout.UseSubFont = false;
			this.m_labelHomeTimeout.UseUnitFont = true;
			this.m_labelHomeTimeout.Click += new System.EventHandler(this.Click_SpeedConfiguration);
			// 
			// m_labelJerkAccel
			// 
			this.m_labelJerkAccel.BackGroundColor = System.Drawing.Color.White;
			this.m_labelJerkAccel.BorderStroke = 2;
			this.m_labelJerkAccel.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelJerkAccel.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelJerkAccel.EdgeRadius = 1;
			this.m_labelJerkAccel.Enabled = false;
			this.m_labelJerkAccel.Location = new System.Drawing.Point(802, 340);
			this.m_labelJerkAccel.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelJerkAccel.MainFontColor = System.Drawing.Color.Black;
			this.m_labelJerkAccel.Name = "m_labelJerkAccel";
			this.m_labelJerkAccel.Size = new System.Drawing.Size(154, 39);
			this.m_labelJerkAccel.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_labelJerkAccel.SubFontColor = System.Drawing.Color.Black;
			this.m_labelJerkAccel.SubText = "";
			this.m_labelJerkAccel.TabIndex = 5;
			this.m_labelJerkAccel.Text = "--";
			this.m_labelJerkAccel.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelJerkAccel.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelJerkAccel.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelJerkAccel.UnitAreaRate = 37;
			this.m_labelJerkAccel.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelJerkAccel.UnitFontColor = System.Drawing.Color.Black;
			this.m_labelJerkAccel.UnitPositionVertical = false;
			this.m_labelJerkAccel.UnitText = "mm/s³";
			this.m_labelJerkAccel.UseBorder = true;
			this.m_labelJerkAccel.UseEdgeRadius = false;
			this.m_labelJerkAccel.UseSubFont = false;
			this.m_labelJerkAccel.UseUnitFont = true;
			this.m_labelJerkAccel.Click += new System.EventHandler(this.Click_SpeedConfiguration);
			// 
			// m_labelJerkDecel
			// 
			this.m_labelJerkDecel.BackGroundColor = System.Drawing.Color.White;
			this.m_labelJerkDecel.BorderStroke = 2;
			this.m_labelJerkDecel.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelJerkDecel.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelJerkDecel.EdgeRadius = 1;
			this.m_labelJerkDecel.Enabled = false;
			this.m_labelJerkDecel.Location = new System.Drawing.Point(958, 340);
			this.m_labelJerkDecel.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelJerkDecel.MainFontColor = System.Drawing.Color.Black;
			this.m_labelJerkDecel.Name = "m_labelJerkDecel";
			this.m_labelJerkDecel.Size = new System.Drawing.Size(154, 39);
			this.m_labelJerkDecel.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_labelJerkDecel.SubFontColor = System.Drawing.Color.Black;
			this.m_labelJerkDecel.SubText = "";
			this.m_labelJerkDecel.TabIndex = 6;
			this.m_labelJerkDecel.Text = "--";
			this.m_labelJerkDecel.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelJerkDecel.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelJerkDecel.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelJerkDecel.UnitAreaRate = 37;
			this.m_labelJerkDecel.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelJerkDecel.UnitFontColor = System.Drawing.Color.Black;
			this.m_labelJerkDecel.UnitPositionVertical = false;
			this.m_labelJerkDecel.UnitText = "mm/s³";
			this.m_labelJerkDecel.UseBorder = true;
			this.m_labelJerkDecel.UseEdgeRadius = false;
			this.m_labelJerkDecel.UseSubFont = false;
			this.m_labelJerkDecel.UseUnitFont = true;
			this.m_labelJerkDecel.Click += new System.EventHandler(this.Click_SpeedConfiguration);
			// 
			// m_labelSpeedPattern
			// 
			this.m_labelSpeedPattern.BackGroundColor = System.Drawing.Color.White;
			this.m_labelSpeedPattern.BorderStroke = 2;
			this.m_labelSpeedPattern.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelSpeedPattern.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelSpeedPattern.EdgeRadius = 1;
			this.m_labelSpeedPattern.Enabled = false;
			this.m_labelSpeedPattern.Location = new System.Drawing.Point(802, 47);
			this.m_labelSpeedPattern.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelSpeedPattern.MainFontColor = System.Drawing.Color.Black;
			this.m_labelSpeedPattern.Name = "m_labelSpeedPattern";
			this.m_labelSpeedPattern.Size = new System.Drawing.Size(310, 39);
			this.m_labelSpeedPattern.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_labelSpeedPattern.SubFontColor = System.Drawing.Color.Black;
			this.m_labelSpeedPattern.SubText = "";
			this.m_labelSpeedPattern.TabIndex = 0;
			this.m_labelSpeedPattern.Text = "--";
			this.m_labelSpeedPattern.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelSpeedPattern.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelSpeedPattern.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelSpeedPattern.UnitAreaRate = 40;
			this.m_labelSpeedPattern.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelSpeedPattern.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_labelSpeedPattern.UnitPositionVertical = false;
			this.m_labelSpeedPattern.UnitText = "";
			this.m_labelSpeedPattern.UseBorder = true;
			this.m_labelSpeedPattern.UseEdgeRadius = false;
			this.m_labelSpeedPattern.UseSubFont = false;
			this.m_labelSpeedPattern.UseUnitFont = false;
			this.m_labelSpeedPattern.Click += new System.EventHandler(this.Click_SpeedConfiguration);
			// 
			// m_lblAlwaysHomeEnd
			// 
			this.m_lblAlwaysHomeEnd.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_lblAlwaysHomeEnd.BorderStroke = 2;
			this.m_lblAlwaysHomeEnd.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_lblAlwaysHomeEnd.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_lblAlwaysHomeEnd.EdgeRadius = 1;
			this.m_lblAlwaysHomeEnd.Location = new System.Drawing.Point(18, 50);
			this.m_lblAlwaysHomeEnd.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_lblAlwaysHomeEnd.MainFontColor = System.Drawing.Color.Black;
			this.m_lblAlwaysHomeEnd.Name = "m_lblAlwaysHomeEnd";
			this.m_lblAlwaysHomeEnd.Size = new System.Drawing.Size(266, 59);
			this.m_lblAlwaysHomeEnd.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_lblAlwaysHomeEnd.SubFontColor = System.Drawing.Color.Black;
			this.m_lblAlwaysHomeEnd.SubText = "";
			this.m_lblAlwaysHomeEnd.TabIndex = 1388;
			this.m_lblAlwaysHomeEnd.Text = "ALWAYS HOME END";
			this.m_lblAlwaysHomeEnd.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_LEFT;
			this.m_lblAlwaysHomeEnd.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblAlwaysHomeEnd.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblAlwaysHomeEnd.UnitAreaRate = 40;
			this.m_lblAlwaysHomeEnd.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_lblAlwaysHomeEnd.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_lblAlwaysHomeEnd.UnitPositionVertical = false;
			this.m_lblAlwaysHomeEnd.UnitText = "";
			this.m_lblAlwaysHomeEnd.UseBorder = true;
			this.m_lblAlwaysHomeEnd.UseEdgeRadius = false;
			this.m_lblAlwaysHomeEnd.UseSubFont = false;
			this.m_lblAlwaysHomeEnd.UseUnitFont = false;
			// 
			// m_lblEZCount
			// 
			this.m_lblEZCount.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_lblEZCount.BorderStroke = 2;
			this.m_lblEZCount.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_lblEZCount.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_lblEZCount.EdgeRadius = 1;
			this.m_lblEZCount.Location = new System.Drawing.Point(18, 256);
			this.m_lblEZCount.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblEZCount.MainFontColor = System.Drawing.Color.Black;
			this.m_lblEZCount.Name = "m_lblEZCount";
			this.m_lblEZCount.Size = new System.Drawing.Size(148, 39);
			this.m_lblEZCount.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_lblEZCount.SubFontColor = System.Drawing.Color.Black;
			this.m_lblEZCount.SubText = "";
			this.m_lblEZCount.TabIndex = 1389;
			this.m_lblEZCount.Text = "ENCODER Z COUNT";
			this.m_lblEZCount.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_lblEZCount.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblEZCount.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblEZCount.UnitAreaRate = 40;
			this.m_lblEZCount.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_lblEZCount.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_lblEZCount.UnitPositionVertical = false;
			this.m_lblEZCount.UnitText = "";
			this.m_lblEZCount.UseBorder = true;
			this.m_lblEZCount.UseEdgeRadius = false;
			this.m_lblEZCount.UseSubFont = false;
			this.m_lblEZCount.UseUnitFont = false;
			// 
			// m_lblEscapeDistance
			// 
			this.m_lblEscapeDistance.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_lblEscapeDistance.BorderStroke = 2;
			this.m_lblEscapeDistance.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_lblEscapeDistance.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_lblEscapeDistance.EdgeRadius = 1;
			this.m_lblEscapeDistance.Location = new System.Drawing.Point(18, 214);
			this.m_lblEscapeDistance.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblEscapeDistance.MainFontColor = System.Drawing.Color.Black;
			this.m_lblEscapeDistance.Name = "m_lblEscapeDistance";
			this.m_lblEscapeDistance.Size = new System.Drawing.Size(148, 39);
			this.m_lblEscapeDistance.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_lblEscapeDistance.SubFontColor = System.Drawing.Color.Black;
			this.m_lblEscapeDistance.SubText = "";
			this.m_lblEscapeDistance.TabIndex = 1390;
			this.m_lblEscapeDistance.Text = "ESCAPE DISTANCE";
			this.m_lblEscapeDistance.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_lblEscapeDistance.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblEscapeDistance.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblEscapeDistance.UnitAreaRate = 40;
			this.m_lblEscapeDistance.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_lblEscapeDistance.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_lblEscapeDistance.UnitPositionVertical = false;
			this.m_lblEscapeDistance.UnitText = "";
			this.m_lblEscapeDistance.UseBorder = true;
			this.m_lblEscapeDistance.UseEdgeRadius = false;
			this.m_lblEscapeDistance.UseSubFont = false;
			this.m_lblEscapeDistance.UseUnitFont = false;
			// 
			// m_lblHomeLogic
			// 
			this.m_lblHomeLogic.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_lblHomeLogic.BorderStroke = 2;
			this.m_lblHomeLogic.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_lblHomeLogic.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_lblHomeLogic.EdgeRadius = 1;
			this.m_lblHomeLogic.Location = new System.Drawing.Point(18, 172);
			this.m_lblHomeLogic.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblHomeLogic.MainFontColor = System.Drawing.Color.Black;
			this.m_lblHomeLogic.Name = "m_lblHomeLogic";
			this.m_lblHomeLogic.Size = new System.Drawing.Size(148, 39);
			this.m_lblHomeLogic.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_lblHomeLogic.SubFontColor = System.Drawing.Color.Black;
			this.m_lblHomeLogic.SubText = "";
			this.m_lblHomeLogic.TabIndex = 1391;
			this.m_lblHomeLogic.Text = "HOME LOGIC";
			this.m_lblHomeLogic.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_lblHomeLogic.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblHomeLogic.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblHomeLogic.UnitAreaRate = 40;
			this.m_lblHomeLogic.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_lblHomeLogic.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_lblHomeLogic.UnitPositionVertical = false;
			this.m_lblHomeLogic.UnitText = "";
			this.m_lblHomeLogic.UseBorder = true;
			this.m_lblHomeLogic.UseEdgeRadius = false;
			this.m_lblHomeLogic.UseSubFont = false;
			this.m_lblHomeLogic.UseUnitFont = false;
			// 
			// m_lblHomeMode
			// 
			this.m_lblHomeMode.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_lblHomeMode.BorderStroke = 2;
			this.m_lblHomeMode.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_lblHomeMode.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_lblHomeMode.EdgeRadius = 1;
			this.m_lblHomeMode.Location = new System.Drawing.Point(18, 131);
			this.m_lblHomeMode.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblHomeMode.MainFontColor = System.Drawing.Color.Black;
			this.m_lblHomeMode.Name = "m_lblHomeMode";
			this.m_lblHomeMode.Size = new System.Drawing.Size(148, 39);
			this.m_lblHomeMode.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_lblHomeMode.SubFontColor = System.Drawing.Color.Black;
			this.m_lblHomeMode.SubText = "";
			this.m_lblHomeMode.TabIndex = 1392;
			this.m_lblHomeMode.Text = "HOME MODE";
			this.m_lblHomeMode.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_lblHomeMode.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblHomeMode.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblHomeMode.UnitAreaRate = 40;
			this.m_lblHomeMode.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_lblHomeMode.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_lblHomeMode.UnitPositionVertical = false;
			this.m_lblHomeMode.UnitText = "";
			this.m_lblHomeMode.UseBorder = true;
			this.m_lblHomeMode.UseEdgeRadius = false;
			this.m_lblHomeMode.UseSubFont = false;
			this.m_lblHomeMode.UseUnitFont = false;
			// 
			// m_lblBasePosition
			// 
			this.m_lblBasePosition.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_lblBasePosition.BorderStroke = 2;
			this.m_lblBasePosition.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_lblBasePosition.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_lblBasePosition.EdgeRadius = 1;
			this.m_lblBasePosition.Location = new System.Drawing.Point(340, 256);
			this.m_lblBasePosition.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblBasePosition.MainFontColor = System.Drawing.Color.Black;
			this.m_lblBasePosition.Name = "m_lblBasePosition";
			this.m_lblBasePosition.Size = new System.Drawing.Size(148, 39);
			this.m_lblBasePosition.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_lblBasePosition.SubFontColor = System.Drawing.Color.Black;
			this.m_lblBasePosition.SubText = "";
			this.m_lblBasePosition.TabIndex = 1393;
			this.m_lblBasePosition.Text = "BASE POSITION";
			this.m_lblBasePosition.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_lblBasePosition.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblBasePosition.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblBasePosition.UnitAreaRate = 40;
			this.m_lblBasePosition.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_lblBasePosition.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_lblBasePosition.UnitPositionVertical = false;
			this.m_lblBasePosition.UnitText = "";
			this.m_lblBasePosition.UseBorder = true;
			this.m_lblBasePosition.UseEdgeRadius = false;
			this.m_lblBasePosition.UseSubFont = false;
			this.m_lblBasePosition.UseUnitFont = false;
			// 
			// m_lblHomeOffset
			// 
			this.m_lblHomeOffset.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_lblHomeOffset.BorderStroke = 2;
			this.m_lblHomeOffset.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_lblHomeOffset.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_lblHomeOffset.EdgeRadius = 1;
			this.m_lblHomeOffset.Location = new System.Drawing.Point(340, 214);
			this.m_lblHomeOffset.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblHomeOffset.MainFontColor = System.Drawing.Color.Black;
			this.m_lblHomeOffset.Name = "m_lblHomeOffset";
			this.m_lblHomeOffset.Size = new System.Drawing.Size(148, 39);
			this.m_lblHomeOffset.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_lblHomeOffset.SubFontColor = System.Drawing.Color.Black;
			this.m_lblHomeOffset.SubText = "";
			this.m_lblHomeOffset.TabIndex = 1394;
			this.m_lblHomeOffset.Text = "HOME OFFSET";
			this.m_lblHomeOffset.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_lblHomeOffset.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblHomeOffset.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblHomeOffset.UnitAreaRate = 40;
			this.m_lblHomeOffset.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_lblHomeOffset.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_lblHomeOffset.UnitPositionVertical = false;
			this.m_lblHomeOffset.UnitText = "";
			this.m_lblHomeOffset.UseBorder = true;
			this.m_lblHomeOffset.UseEdgeRadius = false;
			this.m_lblHomeOffset.UseSubFont = false;
			this.m_lblHomeOffset.UseUnitFont = false;
			// 
			// m_lblHomeDirection
			// 
			this.m_lblHomeDirection.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_lblHomeDirection.BorderStroke = 2;
			this.m_lblHomeDirection.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_lblHomeDirection.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_lblHomeDirection.EdgeRadius = 1;
			this.m_lblHomeDirection.Location = new System.Drawing.Point(340, 172);
			this.m_lblHomeDirection.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblHomeDirection.MainFontColor = System.Drawing.Color.Black;
			this.m_lblHomeDirection.Name = "m_lblHomeDirection";
			this.m_lblHomeDirection.Size = new System.Drawing.Size(148, 39);
			this.m_lblHomeDirection.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_lblHomeDirection.SubFontColor = System.Drawing.Color.Black;
			this.m_lblHomeDirection.SubText = "";
			this.m_lblHomeDirection.TabIndex = 1395;
			this.m_lblHomeDirection.Text = "HOME DIRECTION";
			this.m_lblHomeDirection.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_lblHomeDirection.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblHomeDirection.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblHomeDirection.UnitAreaRate = 40;
			this.m_lblHomeDirection.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_lblHomeDirection.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_lblHomeDirection.UnitPositionVertical = false;
			this.m_lblHomeDirection.UnitText = "";
			this.m_lblHomeDirection.UseBorder = true;
			this.m_lblHomeDirection.UseEdgeRadius = false;
			this.m_lblHomeDirection.UseSubFont = false;
			this.m_lblHomeDirection.UseUnitFont = false;
			// 
			// m_labelHomeMode
			// 
			this.m_labelHomeMode.BackGroundColor = System.Drawing.Color.White;
			this.m_labelHomeMode.BorderStroke = 2;
			this.m_labelHomeMode.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelHomeMode.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelHomeMode.EdgeRadius = 1;
			this.m_labelHomeMode.Enabled = false;
			this.m_labelHomeMode.Location = new System.Drawing.Point(168, 131);
			this.m_labelHomeMode.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelHomeMode.MainFontColor = System.Drawing.Color.Black;
			this.m_labelHomeMode.Name = "m_labelHomeMode";
			this.m_labelHomeMode.Size = new System.Drawing.Size(320, 39);
			this.m_labelHomeMode.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_labelHomeMode.SubFontColor = System.Drawing.Color.Black;
			this.m_labelHomeMode.SubText = "";
			this.m_labelHomeMode.TabIndex = 1;
			this.m_labelHomeMode.Text = "--";
			this.m_labelHomeMode.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelHomeMode.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelHomeMode.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelHomeMode.UnitAreaRate = 40;
			this.m_labelHomeMode.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelHomeMode.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_labelHomeMode.UnitPositionVertical = false;
			this.m_labelHomeMode.UnitText = "";
			this.m_labelHomeMode.UseBorder = true;
			this.m_labelHomeMode.UseEdgeRadius = false;
			this.m_labelHomeMode.UseSubFont = false;
			this.m_labelHomeMode.UseUnitFont = false;
			this.m_labelHomeMode.Click += new System.EventHandler(this.Click_Configuration);
			// 
			// m_labelHomeLogic
			// 
			this.m_labelHomeLogic.BackGroundColor = System.Drawing.Color.White;
			this.m_labelHomeLogic.BorderStroke = 2;
			this.m_labelHomeLogic.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelHomeLogic.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelHomeLogic.EdgeRadius = 1;
			this.m_labelHomeLogic.Enabled = false;
			this.m_labelHomeLogic.Location = new System.Drawing.Point(168, 172);
			this.m_labelHomeLogic.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelHomeLogic.MainFontColor = System.Drawing.Color.Black;
			this.m_labelHomeLogic.Name = "m_labelHomeLogic";
			this.m_labelHomeLogic.Size = new System.Drawing.Size(170, 39);
			this.m_labelHomeLogic.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_labelHomeLogic.SubFontColor = System.Drawing.Color.Black;
			this.m_labelHomeLogic.SubText = "";
			this.m_labelHomeLogic.TabIndex = 2;
			this.m_labelHomeLogic.Text = "--";
			this.m_labelHomeLogic.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelHomeLogic.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelHomeLogic.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelHomeLogic.UnitAreaRate = 40;
			this.m_labelHomeLogic.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelHomeLogic.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_labelHomeLogic.UnitPositionVertical = false;
			this.m_labelHomeLogic.UnitText = "";
			this.m_labelHomeLogic.UseBorder = true;
			this.m_labelHomeLogic.UseEdgeRadius = false;
			this.m_labelHomeLogic.UseSubFont = false;
			this.m_labelHomeLogic.UseUnitFont = false;
			this.m_labelHomeLogic.Click += new System.EventHandler(this.Click_Configuration);
			// 
			// m_labelEscapeDistance
			// 
			this.m_labelEscapeDistance.BackGroundColor = System.Drawing.Color.White;
			this.m_labelEscapeDistance.BorderStroke = 2;
			this.m_labelEscapeDistance.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelEscapeDistance.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelEscapeDistance.EdgeRadius = 1;
			this.m_labelEscapeDistance.Enabled = false;
			this.m_labelEscapeDistance.Location = new System.Drawing.Point(168, 214);
			this.m_labelEscapeDistance.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelEscapeDistance.MainFontColor = System.Drawing.Color.Black;
			this.m_labelEscapeDistance.Name = "m_labelEscapeDistance";
			this.m_labelEscapeDistance.Size = new System.Drawing.Size(170, 39);
			this.m_labelEscapeDistance.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_labelEscapeDistance.SubFontColor = System.Drawing.Color.Black;
			this.m_labelEscapeDistance.SubText = "";
			this.m_labelEscapeDistance.TabIndex = 3;
			this.m_labelEscapeDistance.Text = "--";
			this.m_labelEscapeDistance.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelEscapeDistance.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelEscapeDistance.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelEscapeDistance.UnitAreaRate = 40;
			this.m_labelEscapeDistance.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelEscapeDistance.UnitFontColor = System.Drawing.Color.Black;
			this.m_labelEscapeDistance.UnitPositionVertical = false;
			this.m_labelEscapeDistance.UnitText = "mm";
			this.m_labelEscapeDistance.UseBorder = true;
			this.m_labelEscapeDistance.UseEdgeRadius = false;
			this.m_labelEscapeDistance.UseSubFont = false;
			this.m_labelEscapeDistance.UseUnitFont = true;
			this.m_labelEscapeDistance.Click += new System.EventHandler(this.Click_Configuration);
			// 
			// m_labelEZCount
			// 
			this.m_labelEZCount.BackGroundColor = System.Drawing.Color.White;
			this.m_labelEZCount.BorderStroke = 2;
			this.m_labelEZCount.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelEZCount.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelEZCount.EdgeRadius = 1;
			this.m_labelEZCount.Enabled = false;
			this.m_labelEZCount.Location = new System.Drawing.Point(168, 256);
			this.m_labelEZCount.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelEZCount.MainFontColor = System.Drawing.Color.Black;
			this.m_labelEZCount.Name = "m_labelEZCount";
			this.m_labelEZCount.Size = new System.Drawing.Size(170, 39);
			this.m_labelEZCount.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_labelEZCount.SubFontColor = System.Drawing.Color.Black;
			this.m_labelEZCount.SubText = "";
			this.m_labelEZCount.TabIndex = 4;
			this.m_labelEZCount.Text = "--";
			this.m_labelEZCount.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelEZCount.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelEZCount.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelEZCount.UnitAreaRate = 40;
			this.m_labelEZCount.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelEZCount.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_labelEZCount.UnitPositionVertical = false;
			this.m_labelEZCount.UnitText = "";
			this.m_labelEZCount.UseBorder = true;
			this.m_labelEZCount.UseEdgeRadius = false;
			this.m_labelEZCount.UseSubFont = false;
			this.m_labelEZCount.UseUnitFont = false;
			this.m_labelEZCount.Click += new System.EventHandler(this.Click_Configuration);
			// 
			// m_labelBasePosition
			// 
			this.m_labelBasePosition.BackGroundColor = System.Drawing.Color.White;
			this.m_labelBasePosition.BorderStroke = 2;
			this.m_labelBasePosition.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelBasePosition.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelBasePosition.EdgeRadius = 1;
			this.m_labelBasePosition.Enabled = false;
			this.m_labelBasePosition.Location = new System.Drawing.Point(490, 256);
			this.m_labelBasePosition.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelBasePosition.MainFontColor = System.Drawing.Color.Black;
			this.m_labelBasePosition.Name = "m_labelBasePosition";
			this.m_labelBasePosition.Size = new System.Drawing.Size(170, 39);
			this.m_labelBasePosition.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_labelBasePosition.SubFontColor = System.Drawing.Color.Black;
			this.m_labelBasePosition.SubText = "";
			this.m_labelBasePosition.TabIndex = 5;
			this.m_labelBasePosition.Text = "--";
			this.m_labelBasePosition.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelBasePosition.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelBasePosition.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelBasePosition.UnitAreaRate = 40;
			this.m_labelBasePosition.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelBasePosition.UnitFontColor = System.Drawing.Color.Black;
			this.m_labelBasePosition.UnitPositionVertical = false;
			this.m_labelBasePosition.UnitText = "mm";
			this.m_labelBasePosition.UseBorder = true;
			this.m_labelBasePosition.UseEdgeRadius = false;
			this.m_labelBasePosition.UseSubFont = false;
			this.m_labelBasePosition.UseUnitFont = true;
			this.m_labelBasePosition.Click += new System.EventHandler(this.Click_Configuration);
			// 
			// m_labelHomeDirection
			// 
			this.m_labelHomeDirection.BackGroundColor = System.Drawing.Color.White;
			this.m_labelHomeDirection.BorderStroke = 2;
			this.m_labelHomeDirection.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelHomeDirection.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelHomeDirection.EdgeRadius = 1;
			this.m_labelHomeDirection.Enabled = false;
			this.m_labelHomeDirection.Location = new System.Drawing.Point(490, 172);
			this.m_labelHomeDirection.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelHomeDirection.MainFontColor = System.Drawing.Color.Black;
			this.m_labelHomeDirection.Name = "m_labelHomeDirection";
			this.m_labelHomeDirection.Size = new System.Drawing.Size(170, 39);
			this.m_labelHomeDirection.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_labelHomeDirection.SubFontColor = System.Drawing.Color.Black;
			this.m_labelHomeDirection.SubText = "";
			this.m_labelHomeDirection.TabIndex = 6;
			this.m_labelHomeDirection.Text = "--";
			this.m_labelHomeDirection.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelHomeDirection.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelHomeDirection.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelHomeDirection.UnitAreaRate = 40;
			this.m_labelHomeDirection.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelHomeDirection.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_labelHomeDirection.UnitPositionVertical = false;
			this.m_labelHomeDirection.UnitText = "";
			this.m_labelHomeDirection.UseBorder = true;
			this.m_labelHomeDirection.UseEdgeRadius = false;
			this.m_labelHomeDirection.UseSubFont = false;
			this.m_labelHomeDirection.UseUnitFont = false;
			this.m_labelHomeDirection.Click += new System.EventHandler(this.Click_Configuration);
			// 
			// m_labelHomeOffset
			// 
			this.m_labelHomeOffset.BackGroundColor = System.Drawing.Color.White;
			this.m_labelHomeOffset.BorderStroke = 2;
			this.m_labelHomeOffset.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelHomeOffset.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelHomeOffset.EdgeRadius = 1;
			this.m_labelHomeOffset.Enabled = false;
			this.m_labelHomeOffset.Location = new System.Drawing.Point(490, 214);
			this.m_labelHomeOffset.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelHomeOffset.MainFontColor = System.Drawing.Color.Black;
			this.m_labelHomeOffset.Name = "m_labelHomeOffset";
			this.m_labelHomeOffset.Size = new System.Drawing.Size(170, 39);
			this.m_labelHomeOffset.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_labelHomeOffset.SubFontColor = System.Drawing.Color.Black;
			this.m_labelHomeOffset.SubText = "";
			this.m_labelHomeOffset.TabIndex = 7;
			this.m_labelHomeOffset.Text = "--";
			this.m_labelHomeOffset.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelHomeOffset.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelHomeOffset.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelHomeOffset.UnitAreaRate = 40;
			this.m_labelHomeOffset.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelHomeOffset.UnitFontColor = System.Drawing.Color.Black;
			this.m_labelHomeOffset.UnitPositionVertical = false;
			this.m_labelHomeOffset.UnitText = "mm";
			this.m_labelHomeOffset.UseBorder = true;
			this.m_labelHomeOffset.UseEdgeRadius = false;
			this.m_labelHomeOffset.UseSubFont = false;
			this.m_labelHomeOffset.UseUnitFont = true;
			this.m_labelHomeOffset.Click += new System.EventHandler(this.Click_Configuration);
			// 
			// m_ToggleAlwaysHomeEnd
			// 
			this.m_ToggleAlwaysHomeEnd.Active = false;
			this.m_ToggleAlwaysHomeEnd.ActiveColorFirst = System.Drawing.Color.RoyalBlue;
			this.m_ToggleAlwaysHomeEnd.ActiveColorSecond = System.Drawing.Color.DodgerBlue;
			this.m_ToggleAlwaysHomeEnd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_ToggleAlwaysHomeEnd.Enabled = false;
			this.m_ToggleAlwaysHomeEnd.Location = new System.Drawing.Point(193, 61);
			this.m_ToggleAlwaysHomeEnd.Name = "m_ToggleAlwaysHomeEnd";
			this.m_ToggleAlwaysHomeEnd.NormalColorFirst = System.Drawing.Color.DarkGray;
			this.m_ToggleAlwaysHomeEnd.NormalColorSecond = System.Drawing.Color.Silver;
			this.m_ToggleAlwaysHomeEnd.Size = new System.Drawing.Size(78, 39);
			this.m_ToggleAlwaysHomeEnd.TabIndex = 0;
			this.m_ToggleAlwaysHomeEnd.Click += new System.EventHandler(this.Click_Configuration);
			this.m_ToggleAlwaysHomeEnd.DoubleClick += new System.EventHandler(this.Click_Configuration);
			// 
			// m_lblAbsolutePosition
			// 
			this.m_lblAbsolutePosition.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_lblAbsolutePosition.BorderStroke = 2;
			this.m_lblAbsolutePosition.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_lblAbsolutePosition.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_lblAbsolutePosition.EdgeRadius = 1;
			this.m_lblAbsolutePosition.Location = new System.Drawing.Point(18, 329);
			this.m_lblAbsolutePosition.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblAbsolutePosition.MainFontColor = System.Drawing.Color.Black;
			this.m_lblAbsolutePosition.Name = "m_lblAbsolutePosition";
			this.m_lblAbsolutePosition.Size = new System.Drawing.Size(148, 39);
			this.m_lblAbsolutePosition.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_lblAbsolutePosition.SubFontColor = System.Drawing.Color.Black;
			this.m_lblAbsolutePosition.SubText = "";
			this.m_lblAbsolutePosition.TabIndex = 1393;
			this.m_lblAbsolutePosition.Text = "ABSOLUTE POSITION";
			this.m_lblAbsolutePosition.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_lblAbsolutePosition.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblAbsolutePosition.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblAbsolutePosition.UnitAreaRate = 40;
			this.m_lblAbsolutePosition.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_lblAbsolutePosition.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_lblAbsolutePosition.UnitPositionVertical = false;
			this.m_lblAbsolutePosition.UnitText = "";
			this.m_lblAbsolutePosition.UseBorder = true;
			this.m_lblAbsolutePosition.UseEdgeRadius = false;
			this.m_lblAbsolutePosition.UseSubFont = false;
			this.m_lblAbsolutePosition.UseUnitFont = false;
			// 
			// m_labelAbsolutePosition
			// 
			this.m_labelAbsolutePosition.BackGroundColor = System.Drawing.Color.White;
			this.m_labelAbsolutePosition.BorderStroke = 2;
			this.m_labelAbsolutePosition.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelAbsolutePosition.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelAbsolutePosition.EdgeRadius = 1;
			this.m_labelAbsolutePosition.Enabled = false;
			this.m_labelAbsolutePosition.Location = new System.Drawing.Point(168, 329);
			this.m_labelAbsolutePosition.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelAbsolutePosition.MainFontColor = System.Drawing.Color.Black;
			this.m_labelAbsolutePosition.Name = "m_labelAbsolutePosition";
			this.m_labelAbsolutePosition.Size = new System.Drawing.Size(170, 39);
			this.m_labelAbsolutePosition.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_labelAbsolutePosition.SubFontColor = System.Drawing.Color.Black;
			this.m_labelAbsolutePosition.SubText = "";
			this.m_labelAbsolutePosition.TabIndex = 5;
			this.m_labelAbsolutePosition.Text = "--";
			this.m_labelAbsolutePosition.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelAbsolutePosition.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelAbsolutePosition.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelAbsolutePosition.UnitAreaRate = 40;
			this.m_labelAbsolutePosition.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelAbsolutePosition.UnitFontColor = System.Drawing.Color.Black;
			this.m_labelAbsolutePosition.UnitPositionVertical = false;
			this.m_labelAbsolutePosition.UnitText = "mm";
			this.m_labelAbsolutePosition.UseBorder = true;
			this.m_labelAbsolutePosition.UseEdgeRadius = false;
			this.m_labelAbsolutePosition.UseSubFont = false;
			this.m_labelAbsolutePosition.UseUnitFont = true;
			// 
			// m_labelAbsolutePositionSet
			// 
			this.m_labelAbsolutePositionSet.BackGroundColor = System.Drawing.Color.White;
			this.m_labelAbsolutePositionSet.BorderStroke = 2;
			this.m_labelAbsolutePositionSet.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelAbsolutePositionSet.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelAbsolutePositionSet.EdgeRadius = 1;
			this.m_labelAbsolutePositionSet.Enabled = false;
			this.m_labelAbsolutePositionSet.Location = new System.Drawing.Point(337, 329);
			this.m_labelAbsolutePositionSet.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelAbsolutePositionSet.MainFontColor = System.Drawing.Color.Black;
			this.m_labelAbsolutePositionSet.Name = "m_labelAbsolutePositionSet";
			this.m_labelAbsolutePositionSet.Size = new System.Drawing.Size(159, 39);
			this.m_labelAbsolutePositionSet.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_labelAbsolutePositionSet.SubFontColor = System.Drawing.Color.Black;
			this.m_labelAbsolutePositionSet.SubText = "";
			this.m_labelAbsolutePositionSet.TabIndex = 8;
			this.m_labelAbsolutePositionSet.Text = "--";
			this.m_labelAbsolutePositionSet.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelAbsolutePositionSet.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelAbsolutePositionSet.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelAbsolutePositionSet.UnitAreaRate = 40;
			this.m_labelAbsolutePositionSet.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelAbsolutePositionSet.UnitFontColor = System.Drawing.Color.Black;
			this.m_labelAbsolutePositionSet.UnitPositionVertical = false;
			this.m_labelAbsolutePositionSet.UnitText = "mm";
			this.m_labelAbsolutePositionSet.UseBorder = true;
			this.m_labelAbsolutePositionSet.UseEdgeRadius = false;
			this.m_labelAbsolutePositionSet.UseSubFont = false;
			this.m_labelAbsolutePositionSet.UseUnitFont = true;
			this.m_labelAbsolutePositionSet.Click += new System.EventHandler(this.Click_Configuration);
			// 
			// m_btnGet
			// 
			this.m_btnGet.BorderWidth = 1;
			this.m_btnGet.ButtonClicked = false;
			this.m_btnGet.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_btnGet.EdgeRadius = 1;
			this.m_btnGet.Enabled = false;
			this.m_btnGet.GradientAngle = 70F;
			this.m_btnGet.GradientFirstColor = System.Drawing.Color.White;
			this.m_btnGet.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
			this.m_btnGet.ImagePosition = new System.Drawing.Point(7, 7);
			this.m_btnGet.ImageSize = new System.Drawing.Point(30, 30);
			this.m_btnGet.LoadImage = global::FrameOfSystem3.Properties.Resources.CONFIG_ADD3;
			this.m_btnGet.Location = new System.Drawing.Point(494, 328);
			this.m_btnGet.MainFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_btnGet.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
			this.m_btnGet.Name = "m_btnGet";
			this.m_btnGet.Size = new System.Drawing.Size(55, 41);
			this.m_btnGet.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
			this.m_btnGet.SubFontColor = System.Drawing.Color.DarkBlue;
			this.m_btnGet.SubText = "STATUS";
			this.m_btnGet.TabIndex = 0;
			this.m_btnGet.Text = "GET";
			this.m_btnGet.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_btnGet.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_btnGet.UseBorder = false;
			this.m_btnGet.UseEdge = false;
			this.m_btnGet.UseImage = false;
			this.m_btnGet.UseSubFont = false;
			this.m_btnGet.Click += new System.EventHandler(this.Click_AbsolutePositionButton);
			// 
			// m_btnSet
			// 
			this.m_btnSet.BorderWidth = 1;
			this.m_btnSet.ButtonClicked = false;
			this.m_btnSet.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_btnSet.EdgeRadius = 1;
			this.m_btnSet.Enabled = false;
			this.m_btnSet.GradientAngle = 70F;
			this.m_btnSet.GradientFirstColor = System.Drawing.Color.White;
			this.m_btnSet.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
			this.m_btnSet.ImagePosition = new System.Drawing.Point(7, 7);
			this.m_btnSet.ImageSize = new System.Drawing.Point(30, 30);
			this.m_btnSet.LoadImage = global::FrameOfSystem3.Properties.Resources.CONFIG_ADD3;
			this.m_btnSet.Location = new System.Drawing.Point(547, 328);
			this.m_btnSet.MainFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_btnSet.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
			this.m_btnSet.Name = "m_btnSet";
			this.m_btnSet.Size = new System.Drawing.Size(55, 41);
			this.m_btnSet.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
			this.m_btnSet.SubFontColor = System.Drawing.Color.DarkBlue;
			this.m_btnSet.SubText = "STATUS";
			this.m_btnSet.TabIndex = 1;
			this.m_btnSet.Text = "SET";
			this.m_btnSet.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_btnSet.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_btnSet.UseBorder = false;
			this.m_btnSet.UseEdge = false;
			this.m_btnSet.UseImage = false;
			this.m_btnSet.UseSubFont = false;
			this.m_btnSet.Click += new System.EventHandler(this.Click_AbsolutePositionButton);
			// 
			// sys3Label1
			// 
			this.sys3Label1.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.sys3Label1.BorderStroke = 2;
			this.sys3Label1.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.sys3Label1.DisabledColor = System.Drawing.Color.DarkGray;
			this.sys3Label1.EdgeRadius = 1;
			this.sys3Label1.Location = new System.Drawing.Point(802, 214);
			this.sys3Label1.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.sys3Label1.MainFontColor = System.Drawing.Color.Black;
			this.sys3Label1.Name = "sys3Label1";
			this.sys3Label1.Size = new System.Drawing.Size(154, 39);
			this.sys3Label1.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.sys3Label1.SubFontColor = System.Drawing.Color.Black;
			this.sys3Label1.SubText = "";
			this.sys3Label1.TabIndex = 1387;
			this.sys3Label1.Text = "ACCELERATION";
			this.sys3Label1.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
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
			this.sys3Label2.DisabledColor = System.Drawing.Color.DarkGray;
			this.sys3Label2.EdgeRadius = 1;
			this.sys3Label2.Location = new System.Drawing.Point(958, 214);
			this.sys3Label2.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.sys3Label2.MainFontColor = System.Drawing.Color.Black;
			this.sys3Label2.Name = "sys3Label2";
			this.sys3Label2.Size = new System.Drawing.Size(154, 39);
			this.sys3Label2.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.sys3Label2.SubFontColor = System.Drawing.Color.Black;
			this.sys3Label2.SubText = "";
			this.sys3Label2.TabIndex = 1387;
			this.sys3Label2.Text = "DECELERATION";
			this.sys3Label2.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
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
			this.sys3Label3.DisabledColor = System.Drawing.Color.DarkGray;
			this.sys3Label3.EdgeRadius = 1;
			this.sys3Label3.Location = new System.Drawing.Point(674, 256);
			this.sys3Label3.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.sys3Label3.MainFontColor = System.Drawing.Color.Black;
			this.sys3Label3.Name = "sys3Label3";
			this.sys3Label3.Size = new System.Drawing.Size(126, 39);
			this.sys3Label3.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.sys3Label3.SubFontColor = System.Drawing.Color.Black;
			this.sys3Label3.SubText = "";
			this.sys3Label3.TabIndex = 1387;
			this.sys3Label3.Text = "PARAMETER";
			this.sys3Label3.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
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
			// m_labelAccelVelocity
			// 
			this.m_labelAccelVelocity.BackGroundColor = System.Drawing.Color.White;
			this.m_labelAccelVelocity.BorderStroke = 2;
			this.m_labelAccelVelocity.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelAccelVelocity.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelAccelVelocity.EdgeRadius = 1;
			this.m_labelAccelVelocity.Enabled = false;
			this.m_labelAccelVelocity.Location = new System.Drawing.Point(802, 256);
			this.m_labelAccelVelocity.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelAccelVelocity.MainFontColor = System.Drawing.Color.Black;
			this.m_labelAccelVelocity.Name = "m_labelAccelVelocity";
			this.m_labelAccelVelocity.Size = new System.Drawing.Size(154, 39);
			this.m_labelAccelVelocity.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_labelAccelVelocity.SubFontColor = System.Drawing.Color.Black;
			this.m_labelAccelVelocity.SubText = "";
			this.m_labelAccelVelocity.TabIndex = 8;
			this.m_labelAccelVelocity.Text = "--";
			this.m_labelAccelVelocity.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelAccelVelocity.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelAccelVelocity.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelAccelVelocity.UnitAreaRate = 37;
			this.m_labelAccelVelocity.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelAccelVelocity.UnitFontColor = System.Drawing.Color.Black;
			this.m_labelAccelVelocity.UnitPositionVertical = false;
			this.m_labelAccelVelocity.UnitText = "mm/s²";
			this.m_labelAccelVelocity.UseBorder = true;
			this.m_labelAccelVelocity.UseEdgeRadius = false;
			this.m_labelAccelVelocity.UseSubFont = false;
			this.m_labelAccelVelocity.UseUnitFont = true;
			this.m_labelAccelVelocity.Click += new System.EventHandler(this.Click_SpeedConfiguration);
			// 
			// m_labelDeccelVelocity
			// 
			this.m_labelDeccelVelocity.BackGroundColor = System.Drawing.Color.White;
			this.m_labelDeccelVelocity.BorderStroke = 2;
			this.m_labelDeccelVelocity.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelDeccelVelocity.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelDeccelVelocity.EdgeRadius = 1;
			this.m_labelDeccelVelocity.Enabled = false;
			this.m_labelDeccelVelocity.Location = new System.Drawing.Point(958, 256);
			this.m_labelDeccelVelocity.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelDeccelVelocity.MainFontColor = System.Drawing.Color.Black;
			this.m_labelDeccelVelocity.Name = "m_labelDeccelVelocity";
			this.m_labelDeccelVelocity.Size = new System.Drawing.Size(154, 39);
			this.m_labelDeccelVelocity.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_labelDeccelVelocity.SubFontColor = System.Drawing.Color.Black;
			this.m_labelDeccelVelocity.SubText = "";
			this.m_labelDeccelVelocity.TabIndex = 9;
			this.m_labelDeccelVelocity.Text = "--";
			this.m_labelDeccelVelocity.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelDeccelVelocity.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelDeccelVelocity.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelDeccelVelocity.UnitAreaRate = 37;
			this.m_labelDeccelVelocity.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelDeccelVelocity.UnitFontColor = System.Drawing.Color.Black;
			this.m_labelDeccelVelocity.UnitPositionVertical = false;
			this.m_labelDeccelVelocity.UnitText = "mm/s²";
			this.m_labelDeccelVelocity.UseBorder = true;
			this.m_labelDeccelVelocity.UseEdgeRadius = false;
			this.m_labelDeccelVelocity.UseSubFont = false;
			this.m_labelDeccelVelocity.UseUnitFont = true;
			this.m_labelDeccelVelocity.Click += new System.EventHandler(this.Click_SpeedConfiguration);
			// 
			// MotorHome
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.m_btnGet);
			this.Controls.Add(this.m_btnSet);
			this.Controls.Add(this.m_ToggleAlwaysHomeEnd);
			this.Controls.Add(this.m_labelHomeOffset);
			this.Controls.Add(this.m_labelHomeDirection);
			this.Controls.Add(this.m_labelAbsolutePositionSet);
			this.Controls.Add(this.m_labelAbsolutePosition);
			this.Controls.Add(this.m_labelBasePosition);
			this.Controls.Add(this.m_labelEZCount);
			this.Controls.Add(this.m_labelEscapeDistance);
			this.Controls.Add(this.m_labelHomeLogic);
			this.Controls.Add(this.m_labelHomeMode);
			this.Controls.Add(this.m_lblHomeDirection);
			this.Controls.Add(this.m_lblAbsolutePosition);
			this.Controls.Add(this.m_lblHomeOffset);
			this.Controls.Add(this.m_lblBasePosition);
			this.Controls.Add(this.m_lblHomeMode);
			this.Controls.Add(this.m_lblHomeLogic);
			this.Controls.Add(this.m_lblEscapeDistance);
			this.Controls.Add(this.m_lblEZCount);
			this.Controls.Add(this.m_lblAlwaysHomeEnd);
			this.Controls.Add(this.m_labelSpeedPattern);
			this.Controls.Add(this.m_labelJerkDecel);
			this.Controls.Add(this.m_labelJerkAccel);
			this.Controls.Add(this.m_labelHomeTimeout);
			this.Controls.Add(this.m_labelDeccelVelocity);
			this.Controls.Add(this.m_labelDecelTime);
			this.Controls.Add(this.m_labelAccelVelocity);
			this.Controls.Add(this.m_labelAccelTime);
			this.Controls.Add(this.m_labelVelocityEnd);
			this.Controls.Add(this.m_labelVelocityStart);
			this.Controls.Add(this.m_lblHomeTimeout);
			this.Controls.Add(this.m_lblJerk);
			this.Controls.Add(this.sys3Label2);
			this.Controls.Add(this.sys3Label1);
			this.Controls.Add(this.sys3Label3);
			this.Controls.Add(this.m_lblTime);
			this.Controls.Add(this.m_lblVelocityStart);
			this.Controls.Add(this.m_lblSpeedPattern);
			this.Controls.Add(this.m_groupHomeConfig);
			this.Controls.Add(this.m_groupHomeSpeedConfig);
			this.Name = "MotorHome";
			this.Size = new System.Drawing.Size(1120, 399);
			this.ResumeLayout(false);

        }

        #endregion

		private Sys3Controls.Sys3GroupBox m_groupHomeConfig;
		private Sys3Controls.Sys3GroupBox m_groupHomeSpeedConfig;
		private Sys3Controls.Sys3Label m_lblSpeedPattern;
		private Sys3Controls.Sys3Label m_lblVelocityStart;
		private Sys3Controls.Sys3Label m_lblTime;
		private Sys3Controls.Sys3Label m_lblJerk;
		private Sys3Controls.Sys3Label m_lblHomeTimeout;
		private Sys3Controls.Sys3Label m_labelVelocityStart;
		private Sys3Controls.Sys3Label m_labelVelocityEnd;
		private Sys3Controls.Sys3Label m_labelAccelTime;
		private Sys3Controls.Sys3Label m_labelDecelTime;
		private Sys3Controls.Sys3Label m_labelHomeTimeout;
		private Sys3Controls.Sys3Label m_labelJerkAccel;
		private Sys3Controls.Sys3Label m_labelJerkDecel;
		private Sys3Controls.Sys3Label m_labelSpeedPattern;
		private Sys3Controls.Sys3Label m_lblAlwaysHomeEnd;
		private Sys3Controls.Sys3Label m_lblEZCount;
		private Sys3Controls.Sys3Label m_lblEscapeDistance;
		private Sys3Controls.Sys3Label m_lblHomeLogic;
		private Sys3Controls.Sys3Label m_lblHomeMode;
		private Sys3Controls.Sys3Label m_lblBasePosition;
		private Sys3Controls.Sys3Label m_lblHomeOffset;
		private Sys3Controls.Sys3Label m_lblHomeDirection;
		private Sys3Controls.Sys3Label m_labelHomeMode;
		private Sys3Controls.Sys3Label m_labelHomeLogic;
		private Sys3Controls.Sys3Label m_labelEscapeDistance;
		private Sys3Controls.Sys3Label m_labelEZCount;
		private Sys3Controls.Sys3Label m_labelBasePosition;
		private Sys3Controls.Sys3Label m_labelHomeDirection;
		private Sys3Controls.Sys3Label m_labelHomeOffset;
		private Sys3Controls.Sys3ToggleButton m_ToggleAlwaysHomeEnd;
		private Sys3Controls.Sys3Label m_lblAbsolutePosition;
		private Sys3Controls.Sys3Label m_labelAbsolutePosition;
		private Sys3Controls.Sys3Label m_labelAbsolutePositionSet;
		private Sys3Controls.Sys3button m_btnGet;
		private Sys3Controls.Sys3button m_btnSet;
		private Sys3Controls.Sys3Label sys3Label1;
		private Sys3Controls.Sys3Label sys3Label2;
		private Sys3Controls.Sys3Label sys3Label3;
		private Sys3Controls.Sys3Label m_labelAccelVelocity;
		private Sys3Controls.Sys3Label m_labelDeccelVelocity;
    }
}
