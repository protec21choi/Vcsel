namespace FrameOfSystem3.Views.Config.MotionPanel
{
    partial class MotorGantry
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
			this.m_ledSlave = new Sys3Controls.Sys3LedLabel();
			this.m_ledMaster = new Sys3Controls.Sys3LedLabel();
			this.m_groupGantryStatus = new Sys3Controls.Sys3GroupBox();
			this.m_lblMaster = new Sys3Controls.Sys3Label();
			this.m_lblSlave = new Sys3Controls.Sys3Label();
			this.m_groupGantryConfiguration = new Sys3Controls.Sys3GroupBox();
			this.m_lblEnableGantry = new Sys3Controls.Sys3Label();
			this.m_lblMasterItem = new Sys3Controls.Sys3Label();
			this.m_lblSlaveItem = new Sys3Controls.Sys3Label();
			this.m_lblSlaveInverse = new Sys3Controls.Sys3Label();
			this.m_labelMasterItem = new Sys3Controls.Sys3Label();
			this.m_labelSlaveItem = new Sys3Controls.Sys3Label();
			this.m_labelSlaveInverse = new Sys3Controls.Sys3Label();
			this.m_ToggleEnableGantry = new Sys3Controls.Sys3ToggleButton();
			this.m_btnResetGantry = new Sys3Controls.Sys3button();
			this.SuspendLayout();
			// 
			// m_ledSlave
			// 
			this.m_ledSlave.Active = false;
			this.m_ledSlave.ColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(216)))), ((int)(((byte)(101)))));
			this.m_ledSlave.ColorNormal = System.Drawing.Color.DimGray;
			this.m_ledSlave.Location = new System.Drawing.Point(16, 102);
			this.m_ledSlave.Name = "m_ledSlave";
			this.m_ledSlave.Size = new System.Drawing.Size(22, 47);
			this.m_ledSlave.TabIndex = 1214;
			// 
			// m_ledMaster
			// 
			this.m_ledMaster.Active = false;
			this.m_ledMaster.ColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(216)))), ((int)(((byte)(101)))));
			this.m_ledMaster.ColorNormal = System.Drawing.Color.DimGray;
			this.m_ledMaster.Location = new System.Drawing.Point(16, 47);
			this.m_ledMaster.Name = "m_ledMaster";
			this.m_ledMaster.Size = new System.Drawing.Size(22, 47);
			this.m_ledMaster.TabIndex = 1212;
			// 
			// m_groupGantryStatus
			// 
			this.m_groupGantryStatus.BackGroundColor = System.Drawing.Color.WhiteSmoke;
			this.m_groupGantryStatus.EdgeBorderStroke = 2;
			this.m_groupGantryStatus.EdgeRadius = 2;
			this.m_groupGantryStatus.LabelFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_groupGantryStatus.LabelGradientColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
			this.m_groupGantryStatus.LabelGradientColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.m_groupGantryStatus.LabelHeight = 32;
			this.m_groupGantryStatus.LabelTextColor = System.Drawing.Color.Black;
			this.m_groupGantryStatus.Location = new System.Drawing.Point(0, 0);
			this.m_groupGantryStatus.Name = "m_groupGantryStatus";
			this.m_groupGantryStatus.Size = new System.Drawing.Size(219, 399);
			this.m_groupGantryStatus.TabIndex = 1370;
			this.m_groupGantryStatus.Text = "GANTRY STATUS";
			this.m_groupGantryStatus.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_groupGantryStatus.UseLabelBorder = true;
			// 
			// m_lblMaster
			// 
			this.m_lblMaster.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_lblMaster.BorderStroke = 2;
			this.m_lblMaster.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_lblMaster.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_lblMaster.EdgeRadius = 1;
			this.m_lblMaster.Location = new System.Drawing.Point(38, 47);
			this.m_lblMaster.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblMaster.MainFontColor = System.Drawing.Color.Black;
			this.m_lblMaster.Name = "m_lblMaster";
			this.m_lblMaster.Size = new System.Drawing.Size(160, 47);
			this.m_lblMaster.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_lblMaster.SubFontColor = System.Drawing.Color.Black;
			this.m_lblMaster.SubText = "";
			this.m_lblMaster.TabIndex = 1375;
			this.m_lblMaster.Text = "MASTER";
			this.m_lblMaster.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_lblMaster.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblMaster.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblMaster.UnitAreaRate = 40;
			this.m_lblMaster.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_lblMaster.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_lblMaster.UnitPositionVertical = false;
			this.m_lblMaster.UnitText = "";
			this.m_lblMaster.UseBorder = true;
			this.m_lblMaster.UseEdgeRadius = false;
			this.m_lblMaster.UseSubFont = false;
			this.m_lblMaster.UseUnitFont = false;
			// 
			// m_lblSlave
			// 
			this.m_lblSlave.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_lblSlave.BorderStroke = 2;
			this.m_lblSlave.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_lblSlave.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_lblSlave.EdgeRadius = 1;
			this.m_lblSlave.Location = new System.Drawing.Point(38, 102);
			this.m_lblSlave.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblSlave.MainFontColor = System.Drawing.Color.Black;
			this.m_lblSlave.Name = "m_lblSlave";
			this.m_lblSlave.Size = new System.Drawing.Size(160, 47);
			this.m_lblSlave.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_lblSlave.SubFontColor = System.Drawing.Color.Black;
			this.m_lblSlave.SubText = "";
			this.m_lblSlave.TabIndex = 1376;
			this.m_lblSlave.Text = "SLAVE";
			this.m_lblSlave.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_lblSlave.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblSlave.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblSlave.UnitAreaRate = 40;
			this.m_lblSlave.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_lblSlave.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_lblSlave.UnitPositionVertical = false;
			this.m_lblSlave.UnitText = "";
			this.m_lblSlave.UseBorder = true;
			this.m_lblSlave.UseEdgeRadius = false;
			this.m_lblSlave.UseSubFont = false;
			this.m_lblSlave.UseUnitFont = false;
			// 
			// m_groupGantryConfiguration
			// 
			this.m_groupGantryConfiguration.BackGroundColor = System.Drawing.Color.WhiteSmoke;
			this.m_groupGantryConfiguration.EdgeBorderStroke = 2;
			this.m_groupGantryConfiguration.EdgeRadius = 2;
			this.m_groupGantryConfiguration.LabelFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_groupGantryConfiguration.LabelGradientColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
			this.m_groupGantryConfiguration.LabelGradientColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.m_groupGantryConfiguration.LabelHeight = 32;
			this.m_groupGantryConfiguration.LabelTextColor = System.Drawing.Color.Black;
			this.m_groupGantryConfiguration.Location = new System.Drawing.Point(217, 0);
			this.m_groupGantryConfiguration.Name = "m_groupGantryConfiguration";
			this.m_groupGantryConfiguration.Size = new System.Drawing.Size(903, 399);
			this.m_groupGantryConfiguration.TabIndex = 1377;
			this.m_groupGantryConfiguration.Text = "GANTRY CONFIGURATION";
			this.m_groupGantryConfiguration.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_groupGantryConfiguration.UseLabelBorder = true;
			// 
			// m_lblEnableGantry
			// 
			this.m_lblEnableGantry.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_lblEnableGantry.BorderStroke = 2;
			this.m_lblEnableGantry.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_lblEnableGantry.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_lblEnableGantry.EdgeRadius = 1;
			this.m_lblEnableGantry.Location = new System.Drawing.Point(232, 47);
			this.m_lblEnableGantry.MainFont = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
			this.m_lblEnableGantry.MainFontColor = System.Drawing.Color.Black;
			this.m_lblEnableGantry.Name = "m_lblEnableGantry";
			this.m_lblEnableGantry.Size = new System.Drawing.Size(490, 55);
			this.m_lblEnableGantry.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_lblEnableGantry.SubFontColor = System.Drawing.Color.Black;
			this.m_lblEnableGantry.SubText = "";
			this.m_lblEnableGantry.TabIndex = 1378;
			this.m_lblEnableGantry.Text = "ENABLE GANTRY";
			this.m_lblEnableGantry.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_LEFT;
			this.m_lblEnableGantry.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblEnableGantry.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblEnableGantry.UnitAreaRate = 40;
			this.m_lblEnableGantry.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_lblEnableGantry.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_lblEnableGantry.UnitPositionVertical = false;
			this.m_lblEnableGantry.UnitText = "";
			this.m_lblEnableGantry.UseBorder = true;
			this.m_lblEnableGantry.UseEdgeRadius = false;
			this.m_lblEnableGantry.UseSubFont = false;
			this.m_lblEnableGantry.UseUnitFont = false;
			// 
			// m_lblMasterItem
			// 
			this.m_lblMasterItem.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_lblMasterItem.BorderStroke = 2;
			this.m_lblMasterItem.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_lblMasterItem.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_lblMasterItem.EdgeRadius = 1;
			this.m_lblMasterItem.Location = new System.Drawing.Point(232, 110);
			this.m_lblMasterItem.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblMasterItem.MainFontColor = System.Drawing.Color.Black;
			this.m_lblMasterItem.Name = "m_lblMasterItem";
			this.m_lblMasterItem.Size = new System.Drawing.Size(182, 47);
			this.m_lblMasterItem.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_lblMasterItem.SubFontColor = System.Drawing.Color.Black;
			this.m_lblMasterItem.SubText = "";
			this.m_lblMasterItem.TabIndex = 1379;
			this.m_lblMasterItem.Text = "MASTER ITEM";
			this.m_lblMasterItem.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_lblMasterItem.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblMasterItem.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblMasterItem.UnitAreaRate = 40;
			this.m_lblMasterItem.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_lblMasterItem.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_lblMasterItem.UnitPositionVertical = false;
			this.m_lblMasterItem.UnitText = "";
			this.m_lblMasterItem.UseBorder = true;
			this.m_lblMasterItem.UseEdgeRadius = false;
			this.m_lblMasterItem.UseSubFont = false;
			this.m_lblMasterItem.UseUnitFont = false;
			// 
			// m_lblSlaveItem
			// 
			this.m_lblSlaveItem.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_lblSlaveItem.BorderStroke = 2;
			this.m_lblSlaveItem.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_lblSlaveItem.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_lblSlaveItem.EdgeRadius = 1;
			this.m_lblSlaveItem.Location = new System.Drawing.Point(232, 165);
			this.m_lblSlaveItem.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblSlaveItem.MainFontColor = System.Drawing.Color.Black;
			this.m_lblSlaveItem.Name = "m_lblSlaveItem";
			this.m_lblSlaveItem.Size = new System.Drawing.Size(182, 47);
			this.m_lblSlaveItem.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_lblSlaveItem.SubFontColor = System.Drawing.Color.Black;
			this.m_lblSlaveItem.SubText = "";
			this.m_lblSlaveItem.TabIndex = 1380;
			this.m_lblSlaveItem.Text = "SLAVE ITEM";
			this.m_lblSlaveItem.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_lblSlaveItem.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblSlaveItem.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblSlaveItem.UnitAreaRate = 40;
			this.m_lblSlaveItem.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_lblSlaveItem.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_lblSlaveItem.UnitPositionVertical = false;
			this.m_lblSlaveItem.UnitText = "";
			this.m_lblSlaveItem.UseBorder = true;
			this.m_lblSlaveItem.UseEdgeRadius = false;
			this.m_lblSlaveItem.UseSubFont = false;
			this.m_lblSlaveItem.UseUnitFont = false;
			// 
			// m_lblSlaveInverse
			// 
			this.m_lblSlaveInverse.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_lblSlaveInverse.BorderStroke = 2;
			this.m_lblSlaveInverse.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_lblSlaveInverse.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_lblSlaveInverse.EdgeRadius = 1;
			this.m_lblSlaveInverse.Location = new System.Drawing.Point(232, 220);
			this.m_lblSlaveInverse.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblSlaveInverse.MainFontColor = System.Drawing.Color.Black;
			this.m_lblSlaveInverse.Name = "m_lblSlaveInverse";
			this.m_lblSlaveInverse.Size = new System.Drawing.Size(182, 47);
			this.m_lblSlaveInverse.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_lblSlaveInverse.SubFontColor = System.Drawing.Color.Black;
			this.m_lblSlaveInverse.SubText = "";
			this.m_lblSlaveInverse.TabIndex = 1381;
			this.m_lblSlaveInverse.Text = "INVERSE SLAVE DIRECTION";
			this.m_lblSlaveInverse.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_lblSlaveInverse.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblSlaveInverse.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblSlaveInverse.UnitAreaRate = 40;
			this.m_lblSlaveInverse.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_lblSlaveInverse.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_lblSlaveInverse.UnitPositionVertical = false;
			this.m_lblSlaveInverse.UnitText = "";
			this.m_lblSlaveInverse.UseBorder = true;
			this.m_lblSlaveInverse.UseEdgeRadius = false;
			this.m_lblSlaveInverse.UseSubFont = false;
			this.m_lblSlaveInverse.UseUnitFont = false;
			// 
			// m_labelMasterItem
			// 
			this.m_labelMasterItem.BackGroundColor = System.Drawing.Color.White;
			this.m_labelMasterItem.BorderStroke = 2;
			this.m_labelMasterItem.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelMasterItem.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelMasterItem.EdgeRadius = 1;
			this.m_labelMasterItem.Enabled = false;
			this.m_labelMasterItem.Location = new System.Drawing.Point(416, 110);
			this.m_labelMasterItem.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelMasterItem.MainFontColor = System.Drawing.Color.Black;
			this.m_labelMasterItem.Name = "m_labelMasterItem";
			this.m_labelMasterItem.Size = new System.Drawing.Size(306, 47);
			this.m_labelMasterItem.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelMasterItem.SubFontColor = System.Drawing.Color.Black;
			this.m_labelMasterItem.SubText = "[ -1 ]";
			this.m_labelMasterItem.TabIndex = 1;
			this.m_labelMasterItem.Text = "--";
			this.m_labelMasterItem.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelMasterItem.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_labelMasterItem.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelMasterItem.UnitAreaRate = 40;
			this.m_labelMasterItem.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelMasterItem.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_labelMasterItem.UnitPositionVertical = false;
			this.m_labelMasterItem.UnitText = "";
			this.m_labelMasterItem.UseBorder = true;
			this.m_labelMasterItem.UseEdgeRadius = false;
			this.m_labelMasterItem.UseSubFont = true;
			this.m_labelMasterItem.UseUnitFont = false;
			this.m_labelMasterItem.Click += new System.EventHandler(this.Click_Configuration);
			// 
			// m_labelSlaveItem
			// 
			this.m_labelSlaveItem.BackGroundColor = System.Drawing.Color.White;
			this.m_labelSlaveItem.BorderStroke = 2;
			this.m_labelSlaveItem.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelSlaveItem.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelSlaveItem.EdgeRadius = 1;
			this.m_labelSlaveItem.Enabled = false;
			this.m_labelSlaveItem.Location = new System.Drawing.Point(416, 165);
			this.m_labelSlaveItem.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelSlaveItem.MainFontColor = System.Drawing.Color.Black;
			this.m_labelSlaveItem.Name = "m_labelSlaveItem";
			this.m_labelSlaveItem.Size = new System.Drawing.Size(306, 47);
			this.m_labelSlaveItem.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelSlaveItem.SubFontColor = System.Drawing.Color.Black;
			this.m_labelSlaveItem.SubText = "[ -1 ]";
			this.m_labelSlaveItem.TabIndex = 2;
			this.m_labelSlaveItem.Text = "--";
			this.m_labelSlaveItem.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelSlaveItem.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_labelSlaveItem.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelSlaveItem.UnitAreaRate = 40;
			this.m_labelSlaveItem.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelSlaveItem.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_labelSlaveItem.UnitPositionVertical = false;
			this.m_labelSlaveItem.UnitText = "";
			this.m_labelSlaveItem.UseBorder = true;
			this.m_labelSlaveItem.UseEdgeRadius = false;
			this.m_labelSlaveItem.UseSubFont = true;
			this.m_labelSlaveItem.UseUnitFont = false;
			this.m_labelSlaveItem.Click += new System.EventHandler(this.Click_Configuration);
			// 
			// m_labelSlaveInverse
			// 
			this.m_labelSlaveInverse.BackGroundColor = System.Drawing.Color.White;
			this.m_labelSlaveInverse.BorderStroke = 2;
			this.m_labelSlaveInverse.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelSlaveInverse.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelSlaveInverse.EdgeRadius = 1;
			this.m_labelSlaveInverse.Enabled = false;
			this.m_labelSlaveInverse.Location = new System.Drawing.Point(416, 220);
			this.m_labelSlaveInverse.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelSlaveInverse.MainFontColor = System.Drawing.Color.Black;
			this.m_labelSlaveInverse.Name = "m_labelSlaveInverse";
			this.m_labelSlaveInverse.Size = new System.Drawing.Size(306, 47);
			this.m_labelSlaveInverse.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelSlaveInverse.SubFontColor = System.Drawing.Color.Black;
			this.m_labelSlaveInverse.SubText = "[ -1 ]";
			this.m_labelSlaveInverse.TabIndex = 3;
			this.m_labelSlaveInverse.Text = "--";
			this.m_labelSlaveInverse.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelSlaveInverse.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_labelSlaveInverse.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelSlaveInverse.UnitAreaRate = 40;
			this.m_labelSlaveInverse.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelSlaveInverse.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_labelSlaveInverse.UnitPositionVertical = false;
			this.m_labelSlaveInverse.UnitText = "";
			this.m_labelSlaveInverse.UseBorder = true;
			this.m_labelSlaveInverse.UseEdgeRadius = false;
			this.m_labelSlaveInverse.UseSubFont = false;
			this.m_labelSlaveInverse.UseUnitFont = false;
			this.m_labelSlaveInverse.Click += new System.EventHandler(this.Click_Configuration);
			// 
			// m_ToggleEnableGantry
			// 
			this.m_ToggleEnableGantry.Active = false;
			this.m_ToggleEnableGantry.ActiveColorFirst = System.Drawing.Color.RoyalBlue;
			this.m_ToggleEnableGantry.ActiveColorSecond = System.Drawing.Color.DodgerBlue;
			this.m_ToggleEnableGantry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_ToggleEnableGantry.Location = new System.Drawing.Point(626, 54);
			this.m_ToggleEnableGantry.Name = "m_ToggleEnableGantry";
			this.m_ToggleEnableGantry.NormalColorFirst = System.Drawing.Color.DarkGray;
			this.m_ToggleEnableGantry.NormalColorSecond = System.Drawing.Color.Silver;
			this.m_ToggleEnableGantry.Size = new System.Drawing.Size(86, 43);
			this.m_ToggleEnableGantry.TabIndex = 0;
			this.m_ToggleEnableGantry.Click += new System.EventHandler(this.Click_Configuration);
			this.m_ToggleEnableGantry.DoubleClick += new System.EventHandler(this.Click_Configuration);
			// 
			// m_btnResetGantry
			// 
			this.m_btnResetGantry.BorderWidth = 3;
			this.m_btnResetGantry.ButtonClicked = false;
			this.m_btnResetGantry.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_btnResetGantry.EdgeRadius = 5;
			this.m_btnResetGantry.Enabled = false;
			this.m_btnResetGantry.GradientAngle = 70F;
			this.m_btnResetGantry.GradientFirstColor = System.Drawing.Color.White;
			this.m_btnResetGantry.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
			this.m_btnResetGantry.ImagePosition = new System.Drawing.Point(7, 7);
			this.m_btnResetGantry.ImageSize = new System.Drawing.Point(30, 30);
			this.m_btnResetGantry.LoadImage = global::FrameOfSystem3.Properties.Resources.CONFIG_ADD3;
			this.m_btnResetGantry.Location = new System.Drawing.Point(940, 281);
			this.m_btnResetGantry.MainFont = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
			this.m_btnResetGantry.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
			this.m_btnResetGantry.Name = "m_btnResetGantry";
			this.m_btnResetGantry.Size = new System.Drawing.Size(165, 103);
			this.m_btnResetGantry.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
			this.m_btnResetGantry.SubFontColor = System.Drawing.Color.DarkBlue;
			this.m_btnResetGantry.SubText = "STATUS";
			this.m_btnResetGantry.TabIndex = 4;
			this.m_btnResetGantry.Text = "RESET GANTRY";
			this.m_btnResetGantry.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
			this.m_btnResetGantry.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_btnResetGantry.UseBorder = true;
			this.m_btnResetGantry.UseEdge = true;
			this.m_btnResetGantry.UseImage = false;
			this.m_btnResetGantry.UseSubFont = false;
			this.m_btnResetGantry.Click += new System.EventHandler(this.Click_Configuration);
			// 
			// MotorGantry
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.m_btnResetGantry);
			this.Controls.Add(this.m_ToggleEnableGantry);
			this.Controls.Add(this.m_labelSlaveInverse);
			this.Controls.Add(this.m_labelSlaveItem);
			this.Controls.Add(this.m_labelMasterItem);
			this.Controls.Add(this.m_lblSlaveInverse);
			this.Controls.Add(this.m_lblSlaveItem);
			this.Controls.Add(this.m_lblMasterItem);
			this.Controls.Add(this.m_lblEnableGantry);
			this.Controls.Add(this.m_lblSlave);
			this.Controls.Add(this.m_lblMaster);
			this.Controls.Add(this.m_ledSlave);
			this.Controls.Add(this.m_ledMaster);
			this.Controls.Add(this.m_groupGantryStatus);
			this.Controls.Add(this.m_groupGantryConfiguration);
			this.Name = "MotorGantry";
			this.Size = new System.Drawing.Size(1120, 399);
			this.ResumeLayout(false);

        }

        #endregion

		private Sys3Controls.Sys3LedLabel m_ledSlave;
		private Sys3Controls.Sys3LedLabel m_ledMaster;
		private Sys3Controls.Sys3GroupBox m_groupGantryStatus;
		private Sys3Controls.Sys3Label m_lblMaster;
		private Sys3Controls.Sys3Label m_lblSlave;
		private Sys3Controls.Sys3GroupBox m_groupGantryConfiguration;
		private Sys3Controls.Sys3Label m_lblEnableGantry;
		private Sys3Controls.Sys3Label m_lblMasterItem;
		private Sys3Controls.Sys3Label m_lblSlaveItem;
		private Sys3Controls.Sys3Label m_lblSlaveInverse;
		private Sys3Controls.Sys3Label m_labelMasterItem;
		private Sys3Controls.Sys3Label m_labelSlaveItem;
		private Sys3Controls.Sys3Label m_labelSlaveInverse;
		private Sys3Controls.Sys3ToggleButton m_ToggleEnableGantry;
		private Sys3Controls.Sys3button m_btnResetGantry;
    }
}
