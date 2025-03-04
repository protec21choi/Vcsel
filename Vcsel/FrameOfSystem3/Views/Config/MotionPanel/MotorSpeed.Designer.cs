namespace FrameOfSystem3.Views.Config.MotionPanel
{
    partial class MotorSpeed
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
			this.m_ledCustom2 = new Sys3Controls.Sys3LedLabel();
			this.m_ledCustom1 = new Sys3Controls.Sys3LedLabel();
			this.m_ledManual = new Sys3Controls.Sys3LedLabel();
			this.m_ledJogHigh = new Sys3Controls.Sys3LedLabel();
			this.m_ledJogLow = new Sys3Controls.Sys3LedLabel();
			this.m_ledRun = new Sys3Controls.Sys3LedLabel();
			this.m_groupSpeedContents = new Sys3Controls.Sys3GroupBox();
			this.m_groupSelectedContents = new Sys3Controls.Sys3GroupBox();
			this.m_groupSpeedParameters = new Sys3Controls.Sys3GroupBox();
			this.m_labelRun = new Sys3Controls.Sys3Label();
			this.m_labelJogLow = new Sys3Controls.Sys3Label();
			this.m_labelJogHigh = new Sys3Controls.Sys3Label();
			this.m_labelManual = new Sys3Controls.Sys3Label();
			this.m_labelCustom1 = new Sys3Controls.Sys3Label();
			this.m_labelCustom2 = new Sys3Controls.Sys3Label();
			this.m_labelName = new Sys3Controls.Sys3Label();
			this.m_labelSpeedPattern = new Sys3Controls.Sys3Label();
			this.m_labelVelocity = new Sys3Controls.Sys3Label();
			this.m_labelAccelTime = new Sys3Controls.Sys3Label();
			this.m_labelJerkAccel = new Sys3Controls.Sys3Label();
			this.m_labelTimeout = new Sys3Controls.Sys3Label();
			this.m_labelMaxVelocity = new Sys3Controls.Sys3Label();
			this.m_labelDecelTime = new Sys3Controls.Sys3Label();
			this.m_labelJerkDecel = new Sys3Controls.Sys3Label();
			this.m_lblName = new Sys3Controls.Sys3Label();
			this.m_lblSpeedPattern = new Sys3Controls.Sys3Label();
			this.m_lblVelocity = new Sys3Controls.Sys3Label();
			this.m_lblAccelTime = new Sys3Controls.Sys3Label();
			this.m_lblJerkAccel = new Sys3Controls.Sys3Label();
			this.m_lblTimeout = new Sys3Controls.Sys3Label();
			this.m_lblJerkDecel = new Sys3Controls.Sys3Label();
			this.m_lblDecelTime = new Sys3Controls.Sys3Label();
			this.m_lblMaxVelocity = new Sys3Controls.Sys3Label();
			this.m_lblShortDistance = new Sys3Controls.Sys3Label();
			this.m_labelShortDistance = new Sys3Controls.Sys3Label();
			this.m_lblShortDistanceAuto = new Sys3Controls.Sys3Label();
			this.m_labelShortDistanceAuto = new Sys3Controls.Sys3Label();
			this.m_labelAccel = new Sys3Controls.Sys3Label();
			this.m_labelDecel = new Sys3Controls.Sys3Label();
			this.m_lblAccel = new Sys3Controls.Sys3Label();
			this.m_lblDecel = new Sys3Controls.Sys3Label();
			this.m_btnCopy = new Sys3Controls.Sys3button();
			this.SuspendLayout();
			// 
			// m_ledCustom2
			// 
			this.m_ledCustom2.Active = false;
			this.m_ledCustom2.ColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(216)))), ((int)(((byte)(101)))));
			this.m_ledCustom2.ColorNormal = System.Drawing.Color.DimGray;
			this.m_ledCustom2.Location = new System.Drawing.Point(18, 320);
			this.m_ledCustom2.Name = "m_ledCustom2";
			this.m_ledCustom2.Size = new System.Drawing.Size(28, 50);
			this.m_ledCustom2.TabIndex = 1143;
			// 
			// m_ledCustom1
			// 
			this.m_ledCustom1.Active = false;
			this.m_ledCustom1.ColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(216)))), ((int)(((byte)(101)))));
			this.m_ledCustom1.ColorNormal = System.Drawing.Color.DimGray;
			this.m_ledCustom1.Location = new System.Drawing.Point(18, 267);
			this.m_ledCustom1.Name = "m_ledCustom1";
			this.m_ledCustom1.Size = new System.Drawing.Size(28, 50);
			this.m_ledCustom1.TabIndex = 1142;
			// 
			// m_ledManual
			// 
			this.m_ledManual.Active = false;
			this.m_ledManual.ColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(216)))), ((int)(((byte)(101)))));
			this.m_ledManual.ColorNormal = System.Drawing.Color.DimGray;
			this.m_ledManual.Location = new System.Drawing.Point(18, 214);
			this.m_ledManual.Name = "m_ledManual";
			this.m_ledManual.Size = new System.Drawing.Size(28, 50);
			this.m_ledManual.TabIndex = 1141;
			// 
			// m_ledJogHigh
			// 
			this.m_ledJogHigh.Active = false;
			this.m_ledJogHigh.ColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(216)))), ((int)(((byte)(101)))));
			this.m_ledJogHigh.ColorNormal = System.Drawing.Color.DimGray;
			this.m_ledJogHigh.Location = new System.Drawing.Point(18, 161);
			this.m_ledJogHigh.Name = "m_ledJogHigh";
			this.m_ledJogHigh.Size = new System.Drawing.Size(28, 50);
			this.m_ledJogHigh.TabIndex = 1140;
			// 
			// m_ledJogLow
			// 
			this.m_ledJogLow.Active = false;
			this.m_ledJogLow.ColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(216)))), ((int)(((byte)(101)))));
			this.m_ledJogLow.ColorNormal = System.Drawing.Color.DimGray;
			this.m_ledJogLow.Location = new System.Drawing.Point(18, 108);
			this.m_ledJogLow.Name = "m_ledJogLow";
			this.m_ledJogLow.Size = new System.Drawing.Size(28, 50);
			this.m_ledJogLow.TabIndex = 1138;
			// 
			// m_ledRun
			// 
			this.m_ledRun.Active = false;
			this.m_ledRun.ColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(216)))), ((int)(((byte)(101)))));
			this.m_ledRun.ColorNormal = System.Drawing.Color.DimGray;
			this.m_ledRun.Location = new System.Drawing.Point(18, 55);
			this.m_ledRun.Name = "m_ledRun";
			this.m_ledRun.Size = new System.Drawing.Size(28, 50);
			this.m_ledRun.TabIndex = 1134;
			// 
			// m_groupSpeedContents
			// 
			this.m_groupSpeedContents.BackGroundColor = System.Drawing.Color.WhiteSmoke;
			this.m_groupSpeedContents.EdgeBorderStroke = 2;
			this.m_groupSpeedContents.EdgeRadius = 2;
			this.m_groupSpeedContents.LabelFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_groupSpeedContents.LabelGradientColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
			this.m_groupSpeedContents.LabelGradientColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.m_groupSpeedContents.LabelHeight = 30;
			this.m_groupSpeedContents.LabelTextColor = System.Drawing.Color.Black;
			this.m_groupSpeedContents.Location = new System.Drawing.Point(0, 0);
			this.m_groupSpeedContents.Name = "m_groupSpeedContents";
			this.m_groupSpeedContents.Size = new System.Drawing.Size(285, 399);
			this.m_groupSpeedContents.TabIndex = 1371;
			this.m_groupSpeedContents.Text = "SPEED CONTENTS";
			this.m_groupSpeedContents.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_groupSpeedContents.UseLabelBorder = true;
			// 
			// m_groupSelectedContents
			// 
			this.m_groupSelectedContents.BackGroundColor = System.Drawing.Color.WhiteSmoke;
			this.m_groupSelectedContents.EdgeBorderStroke = 2;
			this.m_groupSelectedContents.EdgeRadius = 2;
			this.m_groupSelectedContents.LabelFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_groupSelectedContents.LabelGradientColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
			this.m_groupSelectedContents.LabelGradientColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.m_groupSelectedContents.LabelHeight = 30;
			this.m_groupSelectedContents.LabelTextColor = System.Drawing.Color.Black;
			this.m_groupSelectedContents.Location = new System.Drawing.Point(283, 0);
			this.m_groupSelectedContents.Name = "m_groupSelectedContents";
			this.m_groupSelectedContents.Size = new System.Drawing.Size(837, 125);
			this.m_groupSelectedContents.TabIndex = 1372;
			this.m_groupSelectedContents.Text = "SELECTED CONTENTS";
			this.m_groupSelectedContents.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_groupSelectedContents.UseLabelBorder = true;
			// 
			// m_groupSpeedParameters
			// 
			this.m_groupSpeedParameters.BackGroundColor = System.Drawing.Color.WhiteSmoke;
			this.m_groupSpeedParameters.EdgeBorderStroke = 2;
			this.m_groupSpeedParameters.EdgeRadius = 2;
			this.m_groupSpeedParameters.LabelFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_groupSpeedParameters.LabelGradientColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
			this.m_groupSpeedParameters.LabelGradientColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.m_groupSpeedParameters.LabelHeight = 30;
			this.m_groupSpeedParameters.LabelTextColor = System.Drawing.Color.Black;
			this.m_groupSpeedParameters.Location = new System.Drawing.Point(282, 122);
			this.m_groupSpeedParameters.Name = "m_groupSpeedParameters";
			this.m_groupSpeedParameters.Size = new System.Drawing.Size(838, 277);
			this.m_groupSpeedParameters.TabIndex = 1373;
			this.m_groupSpeedParameters.Text = "SPEED PARAMETERS";
			this.m_groupSpeedParameters.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_groupSpeedParameters.UseLabelBorder = true;
			// 
			// m_labelRun
			// 
			this.m_labelRun.BackGroundColor = System.Drawing.Color.White;
			this.m_labelRun.BorderStroke = 2;
			this.m_labelRun.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelRun.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelRun.EdgeRadius = 1;
			this.m_labelRun.Enabled = false;
			this.m_labelRun.Location = new System.Drawing.Point(46, 55);
			this.m_labelRun.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelRun.MainFontColor = System.Drawing.Color.Black;
			this.m_labelRun.Name = "m_labelRun";
			this.m_labelRun.Size = new System.Drawing.Size(220, 50);
			this.m_labelRun.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_labelRun.SubFontColor = System.Drawing.Color.Black;
			this.m_labelRun.SubText = "";
			this.m_labelRun.TabIndex = 0;
			this.m_labelRun.Text = "RUN";
			this.m_labelRun.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelRun.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelRun.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelRun.UnitAreaRate = 40;
			this.m_labelRun.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelRun.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_labelRun.UnitPositionVertical = false;
			this.m_labelRun.UnitText = "";
			this.m_labelRun.UseBorder = true;
			this.m_labelRun.UseEdgeRadius = false;
			this.m_labelRun.UseSubFont = false;
			this.m_labelRun.UseUnitFont = false;
			this.m_labelRun.Click += new System.EventHandler(this.Click_SpeedContents);
			// 
			// m_labelJogLow
			// 
			this.m_labelJogLow.BackGroundColor = System.Drawing.Color.White;
			this.m_labelJogLow.BorderStroke = 2;
			this.m_labelJogLow.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelJogLow.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelJogLow.EdgeRadius = 1;
			this.m_labelJogLow.Enabled = false;
			this.m_labelJogLow.Location = new System.Drawing.Point(46, 108);
			this.m_labelJogLow.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelJogLow.MainFontColor = System.Drawing.Color.Black;
			this.m_labelJogLow.Name = "m_labelJogLow";
			this.m_labelJogLow.Size = new System.Drawing.Size(220, 50);
			this.m_labelJogLow.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_labelJogLow.SubFontColor = System.Drawing.Color.Black;
			this.m_labelJogLow.SubText = "";
			this.m_labelJogLow.TabIndex = 1;
			this.m_labelJogLow.Text = "JOG LOW";
			this.m_labelJogLow.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelJogLow.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelJogLow.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelJogLow.UnitAreaRate = 40;
			this.m_labelJogLow.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelJogLow.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_labelJogLow.UnitPositionVertical = false;
			this.m_labelJogLow.UnitText = "";
			this.m_labelJogLow.UseBorder = true;
			this.m_labelJogLow.UseEdgeRadius = false;
			this.m_labelJogLow.UseSubFont = false;
			this.m_labelJogLow.UseUnitFont = false;
			this.m_labelJogLow.Click += new System.EventHandler(this.Click_SpeedContents);
			// 
			// m_labelJogHigh
			// 
			this.m_labelJogHigh.BackGroundColor = System.Drawing.Color.White;
			this.m_labelJogHigh.BorderStroke = 2;
			this.m_labelJogHigh.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelJogHigh.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelJogHigh.EdgeRadius = 1;
			this.m_labelJogHigh.Enabled = false;
			this.m_labelJogHigh.Location = new System.Drawing.Point(46, 161);
			this.m_labelJogHigh.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelJogHigh.MainFontColor = System.Drawing.Color.Black;
			this.m_labelJogHigh.Name = "m_labelJogHigh";
			this.m_labelJogHigh.Size = new System.Drawing.Size(220, 50);
			this.m_labelJogHigh.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_labelJogHigh.SubFontColor = System.Drawing.Color.Black;
			this.m_labelJogHigh.SubText = "";
			this.m_labelJogHigh.TabIndex = 2;
			this.m_labelJogHigh.Text = "JOG HIGH";
			this.m_labelJogHigh.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelJogHigh.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelJogHigh.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelJogHigh.UnitAreaRate = 40;
			this.m_labelJogHigh.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelJogHigh.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_labelJogHigh.UnitPositionVertical = false;
			this.m_labelJogHigh.UnitText = "";
			this.m_labelJogHigh.UseBorder = true;
			this.m_labelJogHigh.UseEdgeRadius = false;
			this.m_labelJogHigh.UseSubFont = false;
			this.m_labelJogHigh.UseUnitFont = false;
			this.m_labelJogHigh.Click += new System.EventHandler(this.Click_SpeedContents);
			// 
			// m_labelManual
			// 
			this.m_labelManual.BackGroundColor = System.Drawing.Color.White;
			this.m_labelManual.BorderStroke = 2;
			this.m_labelManual.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelManual.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelManual.EdgeRadius = 1;
			this.m_labelManual.Enabled = false;
			this.m_labelManual.Location = new System.Drawing.Point(46, 214);
			this.m_labelManual.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelManual.MainFontColor = System.Drawing.Color.Black;
			this.m_labelManual.Name = "m_labelManual";
			this.m_labelManual.Size = new System.Drawing.Size(220, 50);
			this.m_labelManual.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_labelManual.SubFontColor = System.Drawing.Color.Black;
			this.m_labelManual.SubText = "";
			this.m_labelManual.TabIndex = 3;
			this.m_labelManual.Text = "MANUAL";
			this.m_labelManual.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelManual.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelManual.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelManual.UnitAreaRate = 40;
			this.m_labelManual.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelManual.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_labelManual.UnitPositionVertical = false;
			this.m_labelManual.UnitText = "";
			this.m_labelManual.UseBorder = true;
			this.m_labelManual.UseEdgeRadius = false;
			this.m_labelManual.UseSubFont = false;
			this.m_labelManual.UseUnitFont = false;
			this.m_labelManual.Click += new System.EventHandler(this.Click_SpeedContents);
			// 
			// m_labelCustom1
			// 
			this.m_labelCustom1.BackGroundColor = System.Drawing.Color.White;
			this.m_labelCustom1.BorderStroke = 2;
			this.m_labelCustom1.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelCustom1.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelCustom1.EdgeRadius = 1;
			this.m_labelCustom1.Enabled = false;
			this.m_labelCustom1.Location = new System.Drawing.Point(46, 267);
			this.m_labelCustom1.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelCustom1.MainFontColor = System.Drawing.Color.Black;
			this.m_labelCustom1.Name = "m_labelCustom1";
			this.m_labelCustom1.Size = new System.Drawing.Size(220, 50);
			this.m_labelCustom1.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_labelCustom1.SubFontColor = System.Drawing.Color.Black;
			this.m_labelCustom1.SubText = "";
			this.m_labelCustom1.TabIndex = 4;
			this.m_labelCustom1.Text = "CUSTOM 1";
			this.m_labelCustom1.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelCustom1.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelCustom1.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelCustom1.UnitAreaRate = 40;
			this.m_labelCustom1.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelCustom1.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_labelCustom1.UnitPositionVertical = false;
			this.m_labelCustom1.UnitText = "";
			this.m_labelCustom1.UseBorder = true;
			this.m_labelCustom1.UseEdgeRadius = false;
			this.m_labelCustom1.UseSubFont = false;
			this.m_labelCustom1.UseUnitFont = false;
			this.m_labelCustom1.Click += new System.EventHandler(this.Click_SpeedContents);
			// 
			// m_labelCustom2
			// 
			this.m_labelCustom2.BackGroundColor = System.Drawing.Color.White;
			this.m_labelCustom2.BorderStroke = 2;
			this.m_labelCustom2.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelCustom2.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelCustom2.EdgeRadius = 1;
			this.m_labelCustom2.Enabled = false;
			this.m_labelCustom2.Location = new System.Drawing.Point(46, 320);
			this.m_labelCustom2.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelCustom2.MainFontColor = System.Drawing.Color.Black;
			this.m_labelCustom2.Name = "m_labelCustom2";
			this.m_labelCustom2.Size = new System.Drawing.Size(220, 50);
			this.m_labelCustom2.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_labelCustom2.SubFontColor = System.Drawing.Color.Black;
			this.m_labelCustom2.SubText = "";
			this.m_labelCustom2.TabIndex = 5;
			this.m_labelCustom2.Text = "SHORT DISTANCE";
			this.m_labelCustom2.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelCustom2.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelCustom2.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelCustom2.UnitAreaRate = 40;
			this.m_labelCustom2.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelCustom2.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_labelCustom2.UnitPositionVertical = false;
			this.m_labelCustom2.UnitText = "";
			this.m_labelCustom2.UseBorder = true;
			this.m_labelCustom2.UseEdgeRadius = false;
			this.m_labelCustom2.UseSubFont = false;
			this.m_labelCustom2.UseUnitFont = false;
			this.m_labelCustom2.Click += new System.EventHandler(this.Click_SpeedContents);
			// 
			// m_labelName
			// 
			this.m_labelName.BackGroundColor = System.Drawing.Color.White;
			this.m_labelName.BorderStroke = 2;
			this.m_labelName.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelName.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelName.EdgeRadius = 1;
			this.m_labelName.Enabled = false;
			this.m_labelName.Location = new System.Drawing.Point(454, 39);
			this.m_labelName.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelName.MainFontColor = System.Drawing.Color.Black;
			this.m_labelName.Name = "m_labelName";
			this.m_labelName.Size = new System.Drawing.Size(234, 37);
			this.m_labelName.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_labelName.SubFontColor = System.Drawing.Color.Black;
			this.m_labelName.SubText = "";
			this.m_labelName.TabIndex = 1385;
			this.m_labelName.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelName.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelName.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelName.UnitAreaRate = 40;
			this.m_labelName.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelName.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_labelName.UnitPositionVertical = false;
			this.m_labelName.UnitText = "";
			this.m_labelName.UseBorder = true;
			this.m_labelName.UseEdgeRadius = false;
			this.m_labelName.UseSubFont = false;
			this.m_labelName.UseUnitFont = false;
			// 
			// m_labelSpeedPattern
			// 
			this.m_labelSpeedPattern.BackGroundColor = System.Drawing.Color.White;
			this.m_labelSpeedPattern.BorderStroke = 2;
			this.m_labelSpeedPattern.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelSpeedPattern.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelSpeedPattern.EdgeRadius = 1;
			this.m_labelSpeedPattern.Enabled = false;
			this.m_labelSpeedPattern.Location = new System.Drawing.Point(456, 160);
			this.m_labelSpeedPattern.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelSpeedPattern.MainFontColor = System.Drawing.Color.Black;
			this.m_labelSpeedPattern.Name = "m_labelSpeedPattern";
			this.m_labelSpeedPattern.Size = new System.Drawing.Size(234, 37);
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
			this.m_labelSpeedPattern.Click += new System.EventHandler(this.Click_Parameters);
			// 
			// m_labelVelocity
			// 
			this.m_labelVelocity.BackGroundColor = System.Drawing.Color.White;
			this.m_labelVelocity.BorderStroke = 2;
			this.m_labelVelocity.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelVelocity.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelVelocity.EdgeRadius = 1;
			this.m_labelVelocity.Enabled = false;
			this.m_labelVelocity.Location = new System.Drawing.Point(456, 238);
			this.m_labelVelocity.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelVelocity.MainFontColor = System.Drawing.Color.Black;
			this.m_labelVelocity.Name = "m_labelVelocity";
			this.m_labelVelocity.Size = new System.Drawing.Size(234, 35);
			this.m_labelVelocity.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_labelVelocity.SubFontColor = System.Drawing.Color.Black;
			this.m_labelVelocity.SubText = "";
			this.m_labelVelocity.TabIndex = 1;
			this.m_labelVelocity.Text = "--";
			this.m_labelVelocity.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelVelocity.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelVelocity.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelVelocity.UnitAreaRate = 40;
			this.m_labelVelocity.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelVelocity.UnitFontColor = System.Drawing.Color.Black;
			this.m_labelVelocity.UnitPositionVertical = false;
			this.m_labelVelocity.UnitText = "mm/s";
			this.m_labelVelocity.UseBorder = true;
			this.m_labelVelocity.UseEdgeRadius = false;
			this.m_labelVelocity.UseSubFont = false;
			this.m_labelVelocity.UseUnitFont = true;
			this.m_labelVelocity.Click += new System.EventHandler(this.Click_Parameters);
			// 
			// m_labelAccelTime
			// 
			this.m_labelAccelTime.BackGroundColor = System.Drawing.Color.White;
			this.m_labelAccelTime.BorderStroke = 2;
			this.m_labelAccelTime.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelAccelTime.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelAccelTime.EdgeRadius = 1;
			this.m_labelAccelTime.Enabled = false;
			this.m_labelAccelTime.Location = new System.Drawing.Point(456, 314);
			this.m_labelAccelTime.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelAccelTime.MainFontColor = System.Drawing.Color.Black;
			this.m_labelAccelTime.Name = "m_labelAccelTime";
			this.m_labelAccelTime.Size = new System.Drawing.Size(234, 35);
			this.m_labelAccelTime.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_labelAccelTime.SubFontColor = System.Drawing.Color.Black;
			this.m_labelAccelTime.SubText = "";
			this.m_labelAccelTime.TabIndex = 2;
			this.m_labelAccelTime.Text = "--";
			this.m_labelAccelTime.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelAccelTime.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelAccelTime.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelAccelTime.UnitAreaRate = 40;
			this.m_labelAccelTime.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelAccelTime.UnitFontColor = System.Drawing.Color.Black;
			this.m_labelAccelTime.UnitPositionVertical = false;
			this.m_labelAccelTime.UnitText = "sec";
			this.m_labelAccelTime.UseBorder = true;
			this.m_labelAccelTime.UseEdgeRadius = false;
			this.m_labelAccelTime.UseSubFont = false;
			this.m_labelAccelTime.UseUnitFont = true;
			this.m_labelAccelTime.Click += new System.EventHandler(this.Click_Parameters);
			// 
			// m_labelJerkAccel
			// 
			this.m_labelJerkAccel.BackGroundColor = System.Drawing.Color.White;
			this.m_labelJerkAccel.BorderStroke = 2;
			this.m_labelJerkAccel.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelJerkAccel.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelJerkAccel.EdgeRadius = 1;
			this.m_labelJerkAccel.Enabled = false;
			this.m_labelJerkAccel.Location = new System.Drawing.Point(456, 352);
			this.m_labelJerkAccel.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelJerkAccel.MainFontColor = System.Drawing.Color.Black;
			this.m_labelJerkAccel.Name = "m_labelJerkAccel";
			this.m_labelJerkAccel.Size = new System.Drawing.Size(234, 35);
			this.m_labelJerkAccel.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_labelJerkAccel.SubFontColor = System.Drawing.Color.Black;
			this.m_labelJerkAccel.SubText = "";
			this.m_labelJerkAccel.TabIndex = 3;
			this.m_labelJerkAccel.Text = "--";
			this.m_labelJerkAccel.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelJerkAccel.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelJerkAccel.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelJerkAccel.UnitAreaRate = 40;
			this.m_labelJerkAccel.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelJerkAccel.UnitFontColor = System.Drawing.Color.Black;
			this.m_labelJerkAccel.UnitPositionVertical = false;
			this.m_labelJerkAccel.UnitText = "mm/s³";
			this.m_labelJerkAccel.UseBorder = true;
			this.m_labelJerkAccel.UseEdgeRadius = false;
			this.m_labelJerkAccel.UseSubFont = false;
			this.m_labelJerkAccel.UseUnitFont = true;
			this.m_labelJerkAccel.Click += new System.EventHandler(this.Click_Parameters);
			// 
			// m_labelTimeout
			// 
			this.m_labelTimeout.BackGroundColor = System.Drawing.Color.White;
			this.m_labelTimeout.BorderStroke = 2;
			this.m_labelTimeout.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelTimeout.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelTimeout.EdgeRadius = 1;
			this.m_labelTimeout.Enabled = false;
			this.m_labelTimeout.Location = new System.Drawing.Point(456, 200);
			this.m_labelTimeout.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelTimeout.MainFontColor = System.Drawing.Color.Black;
			this.m_labelTimeout.Name = "m_labelTimeout";
			this.m_labelTimeout.Size = new System.Drawing.Size(234, 35);
			this.m_labelTimeout.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_labelTimeout.SubFontColor = System.Drawing.Color.Black;
			this.m_labelTimeout.SubText = "";
			this.m_labelTimeout.TabIndex = 4;
			this.m_labelTimeout.Text = "--";
			this.m_labelTimeout.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelTimeout.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelTimeout.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelTimeout.UnitAreaRate = 40;
			this.m_labelTimeout.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelTimeout.UnitFontColor = System.Drawing.Color.Black;
			this.m_labelTimeout.UnitPositionVertical = false;
			this.m_labelTimeout.UnitText = "ms";
			this.m_labelTimeout.UseBorder = true;
			this.m_labelTimeout.UseEdgeRadius = false;
			this.m_labelTimeout.UseSubFont = false;
			this.m_labelTimeout.UseUnitFont = true;
			this.m_labelTimeout.Click += new System.EventHandler(this.Click_Parameters);
			// 
			// m_labelMaxVelocity
			// 
			this.m_labelMaxVelocity.BackGroundColor = System.Drawing.Color.White;
			this.m_labelMaxVelocity.BorderStroke = 2;
			this.m_labelMaxVelocity.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelMaxVelocity.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelMaxVelocity.EdgeRadius = 1;
			this.m_labelMaxVelocity.Enabled = false;
			this.m_labelMaxVelocity.Location = new System.Drawing.Point(859, 238);
			this.m_labelMaxVelocity.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelMaxVelocity.MainFontColor = System.Drawing.Color.Black;
			this.m_labelMaxVelocity.Name = "m_labelMaxVelocity";
			this.m_labelMaxVelocity.Size = new System.Drawing.Size(234, 35);
			this.m_labelMaxVelocity.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_labelMaxVelocity.SubFontColor = System.Drawing.Color.Black;
			this.m_labelMaxVelocity.SubText = "";
			this.m_labelMaxVelocity.TabIndex = 5;
			this.m_labelMaxVelocity.Text = "--";
			this.m_labelMaxVelocity.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelMaxVelocity.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelMaxVelocity.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelMaxVelocity.UnitAreaRate = 40;
			this.m_labelMaxVelocity.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelMaxVelocity.UnitFontColor = System.Drawing.Color.Black;
			this.m_labelMaxVelocity.UnitPositionVertical = false;
			this.m_labelMaxVelocity.UnitText = "mm/s";
			this.m_labelMaxVelocity.UseBorder = true;
			this.m_labelMaxVelocity.UseEdgeRadius = false;
			this.m_labelMaxVelocity.UseSubFont = false;
			this.m_labelMaxVelocity.UseUnitFont = true;
			this.m_labelMaxVelocity.Click += new System.EventHandler(this.Click_Parameters);
			// 
			// m_labelDecelTime
			// 
			this.m_labelDecelTime.BackGroundColor = System.Drawing.Color.White;
			this.m_labelDecelTime.BorderStroke = 2;
			this.m_labelDecelTime.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelDecelTime.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelDecelTime.EdgeRadius = 1;
			this.m_labelDecelTime.Enabled = false;
			this.m_labelDecelTime.Location = new System.Drawing.Point(859, 314);
			this.m_labelDecelTime.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelDecelTime.MainFontColor = System.Drawing.Color.Black;
			this.m_labelDecelTime.Name = "m_labelDecelTime";
			this.m_labelDecelTime.Size = new System.Drawing.Size(234, 35);
			this.m_labelDecelTime.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_labelDecelTime.SubFontColor = System.Drawing.Color.Black;
			this.m_labelDecelTime.SubText = "";
			this.m_labelDecelTime.TabIndex = 6;
			this.m_labelDecelTime.Text = "--";
			this.m_labelDecelTime.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelDecelTime.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelDecelTime.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelDecelTime.UnitAreaRate = 40;
			this.m_labelDecelTime.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelDecelTime.UnitFontColor = System.Drawing.Color.Black;
			this.m_labelDecelTime.UnitPositionVertical = false;
			this.m_labelDecelTime.UnitText = "sec";
			this.m_labelDecelTime.UseBorder = true;
			this.m_labelDecelTime.UseEdgeRadius = false;
			this.m_labelDecelTime.UseSubFont = false;
			this.m_labelDecelTime.UseUnitFont = true;
			this.m_labelDecelTime.Click += new System.EventHandler(this.Click_Parameters);
			// 
			// m_labelJerkDecel
			// 
			this.m_labelJerkDecel.BackGroundColor = System.Drawing.Color.White;
			this.m_labelJerkDecel.BorderStroke = 2;
			this.m_labelJerkDecel.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelJerkDecel.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelJerkDecel.EdgeRadius = 1;
			this.m_labelJerkDecel.Enabled = false;
			this.m_labelJerkDecel.Location = new System.Drawing.Point(859, 352);
			this.m_labelJerkDecel.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelJerkDecel.MainFontColor = System.Drawing.Color.Black;
			this.m_labelJerkDecel.Name = "m_labelJerkDecel";
			this.m_labelJerkDecel.Size = new System.Drawing.Size(234, 35);
			this.m_labelJerkDecel.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_labelJerkDecel.SubFontColor = System.Drawing.Color.Black;
			this.m_labelJerkDecel.SubText = "";
			this.m_labelJerkDecel.TabIndex = 7;
			this.m_labelJerkDecel.Text = "--";
			this.m_labelJerkDecel.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelJerkDecel.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelJerkDecel.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelJerkDecel.UnitAreaRate = 40;
			this.m_labelJerkDecel.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelJerkDecel.UnitFontColor = System.Drawing.Color.Black;
			this.m_labelJerkDecel.UnitPositionVertical = false;
			this.m_labelJerkDecel.UnitText = "mm/s³";
			this.m_labelJerkDecel.UseBorder = true;
			this.m_labelJerkDecel.UseEdgeRadius = false;
			this.m_labelJerkDecel.UseSubFont = false;
			this.m_labelJerkDecel.UseUnitFont = true;
			this.m_labelJerkDecel.Click += new System.EventHandler(this.Click_Parameters);
			// 
			// m_lblName
			// 
			this.m_lblName.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_lblName.BorderStroke = 2;
			this.m_lblName.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_lblName.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_lblName.EdgeRadius = 1;
			this.m_lblName.Location = new System.Drawing.Point(304, 39);
			this.m_lblName.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblName.MainFontColor = System.Drawing.Color.Black;
			this.m_lblName.Name = "m_lblName";
			this.m_lblName.Size = new System.Drawing.Size(148, 37);
			this.m_lblName.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_lblName.SubFontColor = System.Drawing.Color.Black;
			this.m_lblName.SubText = "";
			this.m_lblName.TabIndex = 1386;
			this.m_lblName.Text = "NAME";
			this.m_lblName.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_lblName.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblName.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblName.UnitAreaRate = 40;
			this.m_lblName.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_lblName.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_lblName.UnitPositionVertical = false;
			this.m_lblName.UnitText = "";
			this.m_lblName.UseBorder = true;
			this.m_lblName.UseEdgeRadius = false;
			this.m_lblName.UseSubFont = false;
			this.m_lblName.UseUnitFont = false;
			// 
			// m_lblSpeedPattern
			// 
			this.m_lblSpeedPattern.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_lblSpeedPattern.BorderStroke = 2;
			this.m_lblSpeedPattern.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_lblSpeedPattern.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_lblSpeedPattern.EdgeRadius = 1;
			this.m_lblSpeedPattern.Location = new System.Drawing.Point(306, 160);
			this.m_lblSpeedPattern.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblSpeedPattern.MainFontColor = System.Drawing.Color.Black;
			this.m_lblSpeedPattern.Name = "m_lblSpeedPattern";
			this.m_lblSpeedPattern.Size = new System.Drawing.Size(148, 37);
			this.m_lblSpeedPattern.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_lblSpeedPattern.SubFontColor = System.Drawing.Color.Black;
			this.m_lblSpeedPattern.SubText = "";
			this.m_lblSpeedPattern.TabIndex = 1386;
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
			// m_lblVelocity
			// 
			this.m_lblVelocity.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_lblVelocity.BorderStroke = 2;
			this.m_lblVelocity.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_lblVelocity.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_lblVelocity.EdgeRadius = 1;
			this.m_lblVelocity.Location = new System.Drawing.Point(306, 238);
			this.m_lblVelocity.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblVelocity.MainFontColor = System.Drawing.Color.Black;
			this.m_lblVelocity.Name = "m_lblVelocity";
			this.m_lblVelocity.Size = new System.Drawing.Size(148, 35);
			this.m_lblVelocity.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_lblVelocity.SubFontColor = System.Drawing.Color.Black;
			this.m_lblVelocity.SubText = "";
			this.m_lblVelocity.TabIndex = 1386;
			this.m_lblVelocity.Text = "VELOCITY";
			this.m_lblVelocity.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_lblVelocity.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblVelocity.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblVelocity.UnitAreaRate = 40;
			this.m_lblVelocity.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_lblVelocity.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_lblVelocity.UnitPositionVertical = false;
			this.m_lblVelocity.UnitText = "";
			this.m_lblVelocity.UseBorder = true;
			this.m_lblVelocity.UseEdgeRadius = false;
			this.m_lblVelocity.UseSubFont = false;
			this.m_lblVelocity.UseUnitFont = false;
			// 
			// m_lblAccelTime
			// 
			this.m_lblAccelTime.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_lblAccelTime.BorderStroke = 2;
			this.m_lblAccelTime.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_lblAccelTime.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_lblAccelTime.EdgeRadius = 1;
			this.m_lblAccelTime.Location = new System.Drawing.Point(306, 314);
			this.m_lblAccelTime.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblAccelTime.MainFontColor = System.Drawing.Color.Black;
			this.m_lblAccelTime.Name = "m_lblAccelTime";
			this.m_lblAccelTime.Size = new System.Drawing.Size(148, 35);
			this.m_lblAccelTime.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_lblAccelTime.SubFontColor = System.Drawing.Color.Black;
			this.m_lblAccelTime.SubText = "";
			this.m_lblAccelTime.TabIndex = 1386;
			this.m_lblAccelTime.Text = "ACCELERATION TIME";
			this.m_lblAccelTime.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_lblAccelTime.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblAccelTime.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblAccelTime.UnitAreaRate = 40;
			this.m_lblAccelTime.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_lblAccelTime.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_lblAccelTime.UnitPositionVertical = false;
			this.m_lblAccelTime.UnitText = "";
			this.m_lblAccelTime.UseBorder = true;
			this.m_lblAccelTime.UseEdgeRadius = false;
			this.m_lblAccelTime.UseSubFont = false;
			this.m_lblAccelTime.UseUnitFont = false;
			// 
			// m_lblJerkAccel
			// 
			this.m_lblJerkAccel.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_lblJerkAccel.BorderStroke = 2;
			this.m_lblJerkAccel.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_lblJerkAccel.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_lblJerkAccel.EdgeRadius = 1;
			this.m_lblJerkAccel.Location = new System.Drawing.Point(306, 352);
			this.m_lblJerkAccel.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblJerkAccel.MainFontColor = System.Drawing.Color.Black;
			this.m_lblJerkAccel.Name = "m_lblJerkAccel";
			this.m_lblJerkAccel.Size = new System.Drawing.Size(148, 35);
			this.m_lblJerkAccel.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_lblJerkAccel.SubFontColor = System.Drawing.Color.Black;
			this.m_lblJerkAccel.SubText = "";
			this.m_lblJerkAccel.TabIndex = 1386;
			this.m_lblJerkAccel.Text = "ACCELERATION JERK";
			this.m_lblJerkAccel.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_lblJerkAccel.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblJerkAccel.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblJerkAccel.UnitAreaRate = 40;
			this.m_lblJerkAccel.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_lblJerkAccel.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_lblJerkAccel.UnitPositionVertical = false;
			this.m_lblJerkAccel.UnitText = "";
			this.m_lblJerkAccel.UseBorder = true;
			this.m_lblJerkAccel.UseEdgeRadius = false;
			this.m_lblJerkAccel.UseSubFont = false;
			this.m_lblJerkAccel.UseUnitFont = false;
			// 
			// m_lblTimeout
			// 
			this.m_lblTimeout.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_lblTimeout.BorderStroke = 2;
			this.m_lblTimeout.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_lblTimeout.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_lblTimeout.EdgeRadius = 1;
			this.m_lblTimeout.Location = new System.Drawing.Point(306, 200);
			this.m_lblTimeout.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblTimeout.MainFontColor = System.Drawing.Color.Black;
			this.m_lblTimeout.Name = "m_lblTimeout";
			this.m_lblTimeout.Size = new System.Drawing.Size(148, 35);
			this.m_lblTimeout.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_lblTimeout.SubFontColor = System.Drawing.Color.Black;
			this.m_lblTimeout.SubText = "";
			this.m_lblTimeout.TabIndex = 1386;
			this.m_lblTimeout.Text = "MOTION TIMEOUT";
			this.m_lblTimeout.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_lblTimeout.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblTimeout.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblTimeout.UnitAreaRate = 40;
			this.m_lblTimeout.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_lblTimeout.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_lblTimeout.UnitPositionVertical = false;
			this.m_lblTimeout.UnitText = "";
			this.m_lblTimeout.UseBorder = true;
			this.m_lblTimeout.UseEdgeRadius = false;
			this.m_lblTimeout.UseSubFont = false;
			this.m_lblTimeout.UseUnitFont = false;
			// 
			// m_lblJerkDecel
			// 
			this.m_lblJerkDecel.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_lblJerkDecel.BorderStroke = 2;
			this.m_lblJerkDecel.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_lblJerkDecel.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_lblJerkDecel.EdgeRadius = 1;
			this.m_lblJerkDecel.Location = new System.Drawing.Point(709, 352);
			this.m_lblJerkDecel.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblJerkDecel.MainFontColor = System.Drawing.Color.Black;
			this.m_lblJerkDecel.Name = "m_lblJerkDecel";
			this.m_lblJerkDecel.Size = new System.Drawing.Size(148, 35);
			this.m_lblJerkDecel.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_lblJerkDecel.SubFontColor = System.Drawing.Color.Black;
			this.m_lblJerkDecel.SubText = "";
			this.m_lblJerkDecel.TabIndex = 1386;
			this.m_lblJerkDecel.Text = "DECELERATION JERK";
			this.m_lblJerkDecel.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_lblJerkDecel.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblJerkDecel.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblJerkDecel.UnitAreaRate = 40;
			this.m_lblJerkDecel.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_lblJerkDecel.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_lblJerkDecel.UnitPositionVertical = false;
			this.m_lblJerkDecel.UnitText = "";
			this.m_lblJerkDecel.UseBorder = true;
			this.m_lblJerkDecel.UseEdgeRadius = false;
			this.m_lblJerkDecel.UseSubFont = false;
			this.m_lblJerkDecel.UseUnitFont = false;
			// 
			// m_lblDecelTime
			// 
			this.m_lblDecelTime.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_lblDecelTime.BorderStroke = 2;
			this.m_lblDecelTime.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_lblDecelTime.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_lblDecelTime.EdgeRadius = 1;
			this.m_lblDecelTime.Location = new System.Drawing.Point(709, 314);
			this.m_lblDecelTime.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblDecelTime.MainFontColor = System.Drawing.Color.Black;
			this.m_lblDecelTime.Name = "m_lblDecelTime";
			this.m_lblDecelTime.Size = new System.Drawing.Size(148, 35);
			this.m_lblDecelTime.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_lblDecelTime.SubFontColor = System.Drawing.Color.Black;
			this.m_lblDecelTime.SubText = "";
			this.m_lblDecelTime.TabIndex = 1386;
			this.m_lblDecelTime.Text = "DECELERATION TIME";
			this.m_lblDecelTime.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_lblDecelTime.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblDecelTime.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblDecelTime.UnitAreaRate = 40;
			this.m_lblDecelTime.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_lblDecelTime.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_lblDecelTime.UnitPositionVertical = false;
			this.m_lblDecelTime.UnitText = "";
			this.m_lblDecelTime.UseBorder = true;
			this.m_lblDecelTime.UseEdgeRadius = false;
			this.m_lblDecelTime.UseSubFont = false;
			this.m_lblDecelTime.UseUnitFont = false;
			// 
			// m_lblMaxVelocity
			// 
			this.m_lblMaxVelocity.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_lblMaxVelocity.BorderStroke = 2;
			this.m_lblMaxVelocity.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_lblMaxVelocity.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_lblMaxVelocity.EdgeRadius = 1;
			this.m_lblMaxVelocity.Location = new System.Drawing.Point(709, 238);
			this.m_lblMaxVelocity.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblMaxVelocity.MainFontColor = System.Drawing.Color.Black;
			this.m_lblMaxVelocity.Name = "m_lblMaxVelocity";
			this.m_lblMaxVelocity.Size = new System.Drawing.Size(148, 35);
			this.m_lblMaxVelocity.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_lblMaxVelocity.SubFontColor = System.Drawing.Color.Black;
			this.m_lblMaxVelocity.SubText = "";
			this.m_lblMaxVelocity.TabIndex = 1386;
			this.m_lblMaxVelocity.Text = "MAX VELOCITY";
			this.m_lblMaxVelocity.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_lblMaxVelocity.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblMaxVelocity.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblMaxVelocity.UnitAreaRate = 40;
			this.m_lblMaxVelocity.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_lblMaxVelocity.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_lblMaxVelocity.UnitPositionVertical = false;
			this.m_lblMaxVelocity.UnitText = "";
			this.m_lblMaxVelocity.UseBorder = true;
			this.m_lblMaxVelocity.UseEdgeRadius = false;
			this.m_lblMaxVelocity.UseSubFont = false;
			this.m_lblMaxVelocity.UseUnitFont = false;
			// 
			// m_lblShortDistance
			// 
			this.m_lblShortDistance.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_lblShortDistance.BorderStroke = 2;
			this.m_lblShortDistance.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_lblShortDistance.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_lblShortDistance.EdgeRadius = 1;
			this.m_lblShortDistance.Location = new System.Drawing.Point(709, 39);
			this.m_lblShortDistance.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblShortDistance.MainFontColor = System.Drawing.Color.Black;
			this.m_lblShortDistance.Name = "m_lblShortDistance";
			this.m_lblShortDistance.Size = new System.Drawing.Size(148, 37);
			this.m_lblShortDistance.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_lblShortDistance.SubFontColor = System.Drawing.Color.Black;
			this.m_lblShortDistance.SubText = "";
			this.m_lblShortDistance.TabIndex = 1388;
			this.m_lblShortDistance.Text = "SHORT DISTANCE";
			this.m_lblShortDistance.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_lblShortDistance.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblShortDistance.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblShortDistance.UnitAreaRate = 40;
			this.m_lblShortDistance.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_lblShortDistance.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_lblShortDistance.UnitPositionVertical = false;
			this.m_lblShortDistance.UnitText = "";
			this.m_lblShortDistance.UseBorder = true;
			this.m_lblShortDistance.UseEdgeRadius = false;
			this.m_lblShortDistance.UseSubFont = false;
			this.m_lblShortDistance.UseUnitFont = false;
			// 
			// m_labelShortDistance
			// 
			this.m_labelShortDistance.BackGroundColor = System.Drawing.Color.White;
			this.m_labelShortDistance.BorderStroke = 2;
			this.m_labelShortDistance.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelShortDistance.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelShortDistance.EdgeRadius = 1;
			this.m_labelShortDistance.Enabled = false;
			this.m_labelShortDistance.Location = new System.Drawing.Point(859, 39);
			this.m_labelShortDistance.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelShortDistance.MainFontColor = System.Drawing.Color.Black;
			this.m_labelShortDistance.Name = "m_labelShortDistance";
			this.m_labelShortDistance.Size = new System.Drawing.Size(234, 37);
			this.m_labelShortDistance.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_labelShortDistance.SubFontColor = System.Drawing.Color.Black;
			this.m_labelShortDistance.SubText = "";
			this.m_labelShortDistance.TabIndex = 8;
			this.m_labelShortDistance.Text = "--";
			this.m_labelShortDistance.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelShortDistance.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelShortDistance.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelShortDistance.UnitAreaRate = 40;
			this.m_labelShortDistance.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelShortDistance.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_labelShortDistance.UnitPositionVertical = false;
			this.m_labelShortDistance.UnitText = "";
			this.m_labelShortDistance.UseBorder = true;
			this.m_labelShortDistance.UseEdgeRadius = false;
			this.m_labelShortDistance.UseSubFont = false;
			this.m_labelShortDistance.UseUnitFont = false;
			this.m_labelShortDistance.Click += new System.EventHandler(this.Click_Parameters);
			// 
			// m_lblShortDistanceAuto
			// 
			this.m_lblShortDistanceAuto.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_lblShortDistanceAuto.BorderStroke = 2;
			this.m_lblShortDistanceAuto.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_lblShortDistanceAuto.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_lblShortDistanceAuto.EdgeRadius = 1;
			this.m_lblShortDistanceAuto.Location = new System.Drawing.Point(709, 79);
			this.m_lblShortDistanceAuto.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblShortDistanceAuto.MainFontColor = System.Drawing.Color.Black;
			this.m_lblShortDistanceAuto.Name = "m_lblShortDistanceAuto";
			this.m_lblShortDistanceAuto.Size = new System.Drawing.Size(148, 37);
			this.m_lblShortDistanceAuto.SubFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.m_lblShortDistanceAuto.SubFontColor = System.Drawing.Color.Purple;
			this.m_lblShortDistanceAuto.SubText = "AUTO";
			this.m_lblShortDistanceAuto.TabIndex = 1390;
			this.m_lblShortDistanceAuto.Text = "SHORT DISTANCE";
			this.m_lblShortDistanceAuto.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_lblShortDistanceAuto.TextAlignSub = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_lblShortDistanceAuto.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblShortDistanceAuto.UnitAreaRate = 40;
			this.m_lblShortDistanceAuto.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_lblShortDistanceAuto.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_lblShortDistanceAuto.UnitPositionVertical = false;
			this.m_lblShortDistanceAuto.UnitText = "";
			this.m_lblShortDistanceAuto.UseBorder = true;
			this.m_lblShortDistanceAuto.UseEdgeRadius = false;
			this.m_lblShortDistanceAuto.UseSubFont = true;
			this.m_lblShortDistanceAuto.UseUnitFont = false;
			// 
			// m_labelShortDistanceAuto
			// 
			this.m_labelShortDistanceAuto.BackGroundColor = System.Drawing.Color.White;
			this.m_labelShortDistanceAuto.BorderStroke = 2;
			this.m_labelShortDistanceAuto.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelShortDistanceAuto.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelShortDistanceAuto.EdgeRadius = 1;
			this.m_labelShortDistanceAuto.Enabled = false;
			this.m_labelShortDistanceAuto.Location = new System.Drawing.Point(859, 79);
			this.m_labelShortDistanceAuto.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelShortDistanceAuto.MainFontColor = System.Drawing.Color.Black;
			this.m_labelShortDistanceAuto.Name = "m_labelShortDistanceAuto";
			this.m_labelShortDistanceAuto.Size = new System.Drawing.Size(234, 37);
			this.m_labelShortDistanceAuto.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_labelShortDistanceAuto.SubFontColor = System.Drawing.Color.Black;
			this.m_labelShortDistanceAuto.SubText = "";
			this.m_labelShortDistanceAuto.TabIndex = 9;
			this.m_labelShortDistanceAuto.Text = "--";
			this.m_labelShortDistanceAuto.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelShortDistanceAuto.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelShortDistanceAuto.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelShortDistanceAuto.UnitAreaRate = 40;
			this.m_labelShortDistanceAuto.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelShortDistanceAuto.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_labelShortDistanceAuto.UnitPositionVertical = false;
			this.m_labelShortDistanceAuto.UnitText = "";
			this.m_labelShortDistanceAuto.UseBorder = true;
			this.m_labelShortDistanceAuto.UseEdgeRadius = false;
			this.m_labelShortDistanceAuto.UseSubFont = false;
			this.m_labelShortDistanceAuto.UseUnitFont = false;
			this.m_labelShortDistanceAuto.Click += new System.EventHandler(this.Click_Parameters);
			// 
			// m_labelAccel
			// 
			this.m_labelAccel.BackGroundColor = System.Drawing.Color.White;
			this.m_labelAccel.BorderStroke = 2;
			this.m_labelAccel.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelAccel.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelAccel.EdgeRadius = 1;
			this.m_labelAccel.Enabled = false;
			this.m_labelAccel.Location = new System.Drawing.Point(456, 276);
			this.m_labelAccel.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelAccel.MainFontColor = System.Drawing.Color.Black;
			this.m_labelAccel.Name = "m_labelAccel";
			this.m_labelAccel.Size = new System.Drawing.Size(234, 35);
			this.m_labelAccel.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_labelAccel.SubFontColor = System.Drawing.Color.Black;
			this.m_labelAccel.SubText = "";
			this.m_labelAccel.TabIndex = 10;
			this.m_labelAccel.Text = "--";
			this.m_labelAccel.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelAccel.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelAccel.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelAccel.UnitAreaRate = 40;
			this.m_labelAccel.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelAccel.UnitFontColor = System.Drawing.Color.Black;
			this.m_labelAccel.UnitPositionVertical = false;
			this.m_labelAccel.UnitText = "mm/s²";
			this.m_labelAccel.UseBorder = true;
			this.m_labelAccel.UseEdgeRadius = false;
			this.m_labelAccel.UseSubFont = false;
			this.m_labelAccel.UseUnitFont = true;
			this.m_labelAccel.Click += new System.EventHandler(this.Click_Parameters);
			// 
			// m_labelDecel
			// 
			this.m_labelDecel.BackGroundColor = System.Drawing.Color.White;
			this.m_labelDecel.BorderStroke = 2;
			this.m_labelDecel.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelDecel.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelDecel.EdgeRadius = 1;
			this.m_labelDecel.Enabled = false;
			this.m_labelDecel.Location = new System.Drawing.Point(859, 276);
			this.m_labelDecel.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelDecel.MainFontColor = System.Drawing.Color.Black;
			this.m_labelDecel.Name = "m_labelDecel";
			this.m_labelDecel.Size = new System.Drawing.Size(234, 35);
			this.m_labelDecel.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_labelDecel.SubFontColor = System.Drawing.Color.Black;
			this.m_labelDecel.SubText = "";
			this.m_labelDecel.TabIndex = 11;
			this.m_labelDecel.Text = "--";
			this.m_labelDecel.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelDecel.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelDecel.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelDecel.UnitAreaRate = 40;
			this.m_labelDecel.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelDecel.UnitFontColor = System.Drawing.Color.Black;
			this.m_labelDecel.UnitPositionVertical = false;
			this.m_labelDecel.UnitText = "mm/s²";
			this.m_labelDecel.UseBorder = true;
			this.m_labelDecel.UseEdgeRadius = false;
			this.m_labelDecel.UseSubFont = false;
			this.m_labelDecel.UseUnitFont = true;
			this.m_labelDecel.Click += new System.EventHandler(this.Click_Parameters);
			// 
			// m_lblAccel
			// 
			this.m_lblAccel.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_lblAccel.BorderStroke = 2;
			this.m_lblAccel.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_lblAccel.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_lblAccel.EdgeRadius = 1;
			this.m_lblAccel.Location = new System.Drawing.Point(306, 276);
			this.m_lblAccel.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblAccel.MainFontColor = System.Drawing.Color.Black;
			this.m_lblAccel.Name = "m_lblAccel";
			this.m_lblAccel.Size = new System.Drawing.Size(148, 35);
			this.m_lblAccel.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_lblAccel.SubFontColor = System.Drawing.Color.Black;
			this.m_lblAccel.SubText = "";
			this.m_lblAccel.TabIndex = 1386;
			this.m_lblAccel.Text = "ACCELERATION";
			this.m_lblAccel.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_lblAccel.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblAccel.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblAccel.UnitAreaRate = 40;
			this.m_lblAccel.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_lblAccel.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_lblAccel.UnitPositionVertical = false;
			this.m_lblAccel.UnitText = "";
			this.m_lblAccel.UseBorder = true;
			this.m_lblAccel.UseEdgeRadius = false;
			this.m_lblAccel.UseSubFont = false;
			this.m_lblAccel.UseUnitFont = false;
			// 
			// m_lblDecel
			// 
			this.m_lblDecel.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_lblDecel.BorderStroke = 2;
			this.m_lblDecel.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_lblDecel.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_lblDecel.EdgeRadius = 1;
			this.m_lblDecel.Location = new System.Drawing.Point(709, 276);
			this.m_lblDecel.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblDecel.MainFontColor = System.Drawing.Color.Black;
			this.m_lblDecel.Name = "m_lblDecel";
			this.m_lblDecel.Size = new System.Drawing.Size(148, 35);
			this.m_lblDecel.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_lblDecel.SubFontColor = System.Drawing.Color.Black;
			this.m_lblDecel.SubText = "";
			this.m_lblDecel.TabIndex = 1386;
			this.m_lblDecel.Text = "DECELERATION";
			this.m_lblDecel.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_lblDecel.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblDecel.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblDecel.UnitAreaRate = 40;
			this.m_lblDecel.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_lblDecel.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_lblDecel.UnitPositionVertical = false;
			this.m_lblDecel.UnitText = "";
			this.m_lblDecel.UseBorder = true;
			this.m_lblDecel.UseEdgeRadius = false;
			this.m_lblDecel.UseSubFont = false;
			this.m_lblDecel.UseUnitFont = false;
			// 
			// m_btnCopy
			// 
			this.m_btnCopy.BorderWidth = 3;
			this.m_btnCopy.ButtonClicked = false;
			this.m_btnCopy.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_btnCopy.EdgeRadius = 5;
			this.m_btnCopy.Enabled = false;
			this.m_btnCopy.GradientAngle = 80F;
			this.m_btnCopy.GradientFirstColor = System.Drawing.Color.White;
			this.m_btnCopy.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
			this.m_btnCopy.ImagePosition = new System.Drawing.Point(13, 13);
			this.m_btnCopy.ImageSize = new System.Drawing.Point(30, 30);
			this.m_btnCopy.LoadImage = global::FrameOfSystem3.Properties.Resources.COPY;
			this.m_btnCopy.Location = new System.Drawing.Point(859, 160);
			this.m_btnCopy.MainFont = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
			this.m_btnCopy.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
			this.m_btnCopy.Name = "m_btnCopy";
			this.m_btnCopy.Size = new System.Drawing.Size(234, 68);
			this.m_btnCopy.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
			this.m_btnCopy.SubFontColor = System.Drawing.Color.DarkBlue;
			this.m_btnCopy.SubText = "STATUS";
			this.m_btnCopy.TabIndex = 1392;
			this.m_btnCopy.Text = "PARAMETER COPY";
			this.m_btnCopy.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
			this.m_btnCopy.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_btnCopy.UseBorder = true;
			this.m_btnCopy.UseEdge = true;
			this.m_btnCopy.UseImage = true;
			this.m_btnCopy.UseSubFont = false;
			this.m_btnCopy.Click += new System.EventHandler(this.Click_CopySpeedParameter);
			// 
			// MotorSpeed
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.m_btnCopy);
			this.Controls.Add(this.m_lblShortDistanceAuto);
			this.Controls.Add(this.m_labelShortDistanceAuto);
			this.Controls.Add(this.m_lblShortDistance);
			this.Controls.Add(this.m_labelShortDistance);
			this.Controls.Add(this.m_lblMaxVelocity);
			this.Controls.Add(this.m_lblDecel);
			this.Controls.Add(this.m_lblDecelTime);
			this.Controls.Add(this.m_lblJerkDecel);
			this.Controls.Add(this.m_lblTimeout);
			this.Controls.Add(this.m_lblJerkAccel);
			this.Controls.Add(this.m_lblAccel);
			this.Controls.Add(this.m_lblAccelTime);
			this.Controls.Add(this.m_lblVelocity);
			this.Controls.Add(this.m_lblSpeedPattern);
			this.Controls.Add(this.m_lblName);
			this.Controls.Add(this.m_labelJerkDecel);
			this.Controls.Add(this.m_labelTimeout);
			this.Controls.Add(this.m_labelDecel);
			this.Controls.Add(this.m_labelDecelTime);
			this.Controls.Add(this.m_labelMaxVelocity);
			this.Controls.Add(this.m_labelJerkAccel);
			this.Controls.Add(this.m_labelAccel);
			this.Controls.Add(this.m_labelAccelTime);
			this.Controls.Add(this.m_labelVelocity);
			this.Controls.Add(this.m_labelSpeedPattern);
			this.Controls.Add(this.m_labelName);
			this.Controls.Add(this.m_labelCustom2);
			this.Controls.Add(this.m_labelCustom1);
			this.Controls.Add(this.m_labelManual);
			this.Controls.Add(this.m_labelJogHigh);
			this.Controls.Add(this.m_labelJogLow);
			this.Controls.Add(this.m_labelRun);
			this.Controls.Add(this.m_ledCustom2);
			this.Controls.Add(this.m_ledCustom1);
			this.Controls.Add(this.m_ledManual);
			this.Controls.Add(this.m_ledJogHigh);
			this.Controls.Add(this.m_ledJogLow);
			this.Controls.Add(this.m_ledRun);
			this.Controls.Add(this.m_groupSpeedContents);
			this.Controls.Add(this.m_groupSpeedParameters);
			this.Controls.Add(this.m_groupSelectedContents);
			this.Name = "MotorSpeed";
			this.Size = new System.Drawing.Size(1120, 399);
			this.ResumeLayout(false);

        }

        #endregion

		private Sys3Controls.Sys3LedLabel m_ledCustom2;
		private Sys3Controls.Sys3LedLabel m_ledCustom1;
		private Sys3Controls.Sys3LedLabel m_ledManual;
		private Sys3Controls.Sys3LedLabel m_ledJogHigh;
		private Sys3Controls.Sys3LedLabel m_ledJogLow;
		private Sys3Controls.Sys3LedLabel m_ledRun;
		private Sys3Controls.Sys3GroupBox m_groupSpeedContents;
		private Sys3Controls.Sys3GroupBox m_groupSelectedContents;
		private Sys3Controls.Sys3GroupBox m_groupSpeedParameters;
		private Sys3Controls.Sys3Label m_labelRun;
		private Sys3Controls.Sys3Label m_labelJogLow;
		private Sys3Controls.Sys3Label m_labelJogHigh;
		private Sys3Controls.Sys3Label m_labelManual;
		private Sys3Controls.Sys3Label m_labelCustom1;
		private Sys3Controls.Sys3Label m_labelCustom2;
		private Sys3Controls.Sys3Label m_labelName;
		private Sys3Controls.Sys3Label m_labelSpeedPattern;
		private Sys3Controls.Sys3Label m_labelVelocity;
		private Sys3Controls.Sys3Label m_labelAccelTime;
		private Sys3Controls.Sys3Label m_labelJerkAccel;
		private Sys3Controls.Sys3Label m_labelTimeout;
		private Sys3Controls.Sys3Label m_labelMaxVelocity;
		private Sys3Controls.Sys3Label m_labelDecelTime;
		private Sys3Controls.Sys3Label m_labelJerkDecel;
		private Sys3Controls.Sys3Label m_lblName;
		private Sys3Controls.Sys3Label m_lblSpeedPattern;
		private Sys3Controls.Sys3Label m_lblVelocity;
		private Sys3Controls.Sys3Label m_lblAccelTime;
		private Sys3Controls.Sys3Label m_lblJerkAccel;
		private Sys3Controls.Sys3Label m_lblTimeout;
		private Sys3Controls.Sys3Label m_lblJerkDecel;
		private Sys3Controls.Sys3Label m_lblDecelTime;
		private Sys3Controls.Sys3Label m_lblMaxVelocity;
        private Sys3Controls.Sys3Label m_lblShortDistance;
        private Sys3Controls.Sys3Label m_labelShortDistance;
        private Sys3Controls.Sys3Label m_lblShortDistanceAuto;
        private Sys3Controls.Sys3Label m_labelShortDistanceAuto;
		private Sys3Controls.Sys3Label m_labelAccel;
		private Sys3Controls.Sys3Label m_labelDecel;
		private Sys3Controls.Sys3Label m_lblAccel;
		private Sys3Controls.Sys3Label m_lblDecel;
		private Sys3Controls.Sys3button m_btnCopy;
    }
}
