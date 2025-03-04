namespace FrameOfSystem3.Views.Config
{
	partial class Config_Serial
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.m_listMessage = new System.Windows.Forms.ListBox();
            this.m_dgViewSerial = new Sys3Controls.Sys3DoubleBufferedDataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ENABLE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PASSWORD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MONITORING = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TARGETPORT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CONDITION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AUTHORITY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_groupList = new Sys3Controls.Sys3GroupBox();
            this.m_groupSelectedItem = new Sys3Controls.Sys3GroupBox();
            this.m_groupConfiguration = new Sys3Controls.Sys3GroupBox();
            this.m_groupSerialDemonstration = new Sys3Controls.Sys3GroupBox();
            this.m_lblName = new Sys3Controls.Sys3Label();
            this.m_lblDataBit = new Sys3Controls.Sys3Label();
            this.m_lblBaudRate = new Sys3Controls.Sys3Label();
            this.m_lblStopBit = new Sys3Controls.Sys3Label();
            this.m_lblParityBit = new Sys3Controls.Sys3Label();
            this.m_lblReceiveTimeout = new Sys3Controls.Sys3Label();
            this.m_lblPortName = new Sys3Controls.Sys3Label();
            this.m_lblIndex = new Sys3Controls.Sys3Label();
            this.m_lblState = new Sys3Controls.Sys3Label();
            this.m_labelPortName = new Sys3Controls.Sys3Label();
            this.m_labelName = new Sys3Controls.Sys3Label();
            this.m_labelDataBit = new Sys3Controls.Sys3Label();
            this.m_labelBaudRate = new Sys3Controls.Sys3Label();
            this.m_labelReceiveTimeout = new Sys3Controls.Sys3Label();
            this.m_labelParityBit = new Sys3Controls.Sys3Label();
            this.m_labelStopBit = new Sys3Controls.Sys3Label();
            this.m_labelIndex = new Sys3Controls.Sys3Label();
            this.m_labelState = new Sys3Controls.Sys3Label();
            this.m_labelMessage = new Sys3Controls.Sys3Label();
            this.m_lblMessage = new Sys3Controls.Sys3Label();
            this.m_btnSend = new Sys3Controls.Sys3button();
            this.m_btnClearMessage = new Sys3Controls.Sys3button();
            this.m_btnClose = new Sys3Controls.Sys3button();
            this.m_btnOpen = new Sys3Controls.Sys3button();
            this.m_btnRemove = new Sys3Controls.Sys3button();
            this.m_btnAdd = new Sys3Controls.Sys3button();
            this.m_btnDisable = new Sys3Controls.Sys3button();
            this.m_btnEnable = new Sys3Controls.Sys3button();
            this.m_labelLogType = new Sys3Controls.Sys3Label();
            this.m_lblLogType = new Sys3Controls.Sys3Label();
            this.m_labelReceiveStart = new Sys3Controls.Sys3Label();
            this.m_labelSendStart = new Sys3Controls.Sys3Label();
            this.sys3Label3 = new Sys3Controls.Sys3Label();
            this.sys3Label4 = new Sys3Controls.Sys3Label();
            this.sys3GroupBox1 = new Sys3Controls.Sys3GroupBox();
            this.m_labelReceiveEnd = new Sys3Controls.Sys3Label();
            this.m_labelSendEnd = new Sys3Controls.Sys3Label();
            this.sys3Label7 = new Sys3Controls.Sys3Label();
            this.sys3Label8 = new Sys3Controls.Sys3Label();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgViewSerial)).BeginInit();
            this.SuspendLayout();
            // 
            // m_listMessage
            // 
            this.m_listMessage.BackColor = System.Drawing.Color.Gainsboro;
            this.m_listMessage.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.m_listMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.m_listMessage.FormattingEnabled = true;
            this.m_listMessage.ItemHeight = 17;
            this.m_listMessage.Location = new System.Drawing.Point(578, 419);
            this.m_listMessage.Name = "m_listMessage";
            this.m_listMessage.Size = new System.Drawing.Size(551, 293);
            this.m_listMessage.TabIndex = 1357;
            // 
            // m_dgViewSerial
            // 
            this.m_dgViewSerial.AllowUserToAddRows = false;
            this.m_dgViewSerial.AllowUserToDeleteRows = false;
            this.m_dgViewSerial.AllowUserToResizeColumns = false;
            this.m_dgViewSerial.AllowUserToResizeRows = false;
            this.m_dgViewSerial.BackgroundColor = System.Drawing.Color.White;
            this.m_dgViewSerial.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.m_dgViewSerial.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_dgViewSerial.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.m_dgViewSerial.ColumnHeadersHeight = 30;
            this.m_dgViewSerial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.m_dgViewSerial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.ENABLE,
            this.NAME,
            this.PASSWORD,
            this.MONITORING,
            this.TARGETPORT,
            this.CONDITION,
            this.AUTHORITY,
            this.STATE});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.m_dgViewSerial.DefaultCellStyle = dataGridViewCellStyle2;
            this.m_dgViewSerial.EnableHeadersVisualStyles = false;
            this.m_dgViewSerial.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            this.m_dgViewSerial.Location = new System.Drawing.Point(2, 31);
            this.m_dgViewSerial.MultiSelect = false;
            this.m_dgViewSerial.Name = "m_dgViewSerial";
            this.m_dgViewSerial.ReadOnly = true;
            this.m_dgViewSerial.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("맑은 고딕", 11F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_dgViewSerial.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.m_dgViewSerial.RowHeadersVisible = false;
            this.m_dgViewSerial.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.m_dgViewSerial.RowTemplate.Height = 23;
            this.m_dgViewSerial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgViewSerial.Size = new System.Drawing.Size(1135, 139);
            this.m_dgViewSerial.TabIndex = 1347;
            this.m_dgViewSerial.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Click_Dgview);
            // 
            // ID
            // 
            this.ID.Frozen = true;
            this.ID.HeaderText = "INDEX";
            this.ID.MaxInputLength = 20;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ID.Width = 65;
            // 
            // ENABLE
            // 
            this.ENABLE.Frozen = true;
            this.ENABLE.HeaderText = "ENABLE";
            this.ENABLE.Name = "ENABLE";
            this.ENABLE.ReadOnly = true;
            this.ENABLE.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ENABLE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ENABLE.Width = 65;
            // 
            // NAME
            // 
            this.NAME.HeaderText = "NAME";
            this.NAME.Name = "NAME";
            this.NAME.ReadOnly = true;
            this.NAME.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NAME.Width = 200;
            // 
            // PASSWORD
            // 
            this.PASSWORD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PASSWORD.HeaderText = "PORT NAME";
            this.PASSWORD.MaxInputLength = 20;
            this.PASSWORD.Name = "PASSWORD";
            this.PASSWORD.ReadOnly = true;
            this.PASSWORD.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PASSWORD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // MONITORING
            // 
            this.MONITORING.HeaderText = "BAUDRATE";
            this.MONITORING.Name = "MONITORING";
            this.MONITORING.ReadOnly = true;
            this.MONITORING.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.MONITORING.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MONITORING.Width = 160;
            // 
            // TARGETPORT
            // 
            this.TARGETPORT.HeaderText = "DATA BIT";
            this.TARGETPORT.Name = "TARGETPORT";
            this.TARGETPORT.ReadOnly = true;
            this.TARGETPORT.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.TARGETPORT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TARGETPORT.Width = 130;
            // 
            // CONDITION
            // 
            this.CONDITION.HeaderText = "STOP BIT";
            this.CONDITION.Name = "CONDITION";
            this.CONDITION.ReadOnly = true;
            this.CONDITION.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CONDITION.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CONDITION.Width = 130;
            // 
            // AUTHORITY
            // 
            this.AUTHORITY.HeaderText = "PARITY";
            this.AUTHORITY.MaxInputLength = 20;
            this.AUTHORITY.Name = "AUTHORITY";
            this.AUTHORITY.ReadOnly = true;
            this.AUTHORITY.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.AUTHORITY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.AUTHORITY.Width = 90;
            // 
            // STATE
            // 
            this.STATE.HeaderText = "STATE";
            this.STATE.Name = "STATE";
            this.STATE.ReadOnly = true;
            this.STATE.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.STATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.STATE.Width = 130;
            // 
            // m_groupList
            // 
            this.m_groupList.BackGroundColor = System.Drawing.Color.WhiteSmoke;
            this.m_groupList.EdgeBorderStroke = 2;
            this.m_groupList.EdgeRadius = 2;
            this.m_groupList.LabelFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_groupList.LabelGradientColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.m_groupList.LabelGradientColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_groupList.LabelHeight = 32;
            this.m_groupList.LabelTextColor = System.Drawing.Color.Black;
            this.m_groupList.Location = new System.Drawing.Point(0, 0);
            this.m_groupList.Name = "m_groupList";
            this.m_groupList.Size = new System.Drawing.Size(1140, 170);
            this.m_groupList.TabIndex = 1369;
            this.m_groupList.Text = "SERIAL LIST";
            this.m_groupList.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_groupList.ThemeIndex = 0;
            this.m_groupList.UseLabelBorder = true;
            // 
            // m_groupSelectedItem
            // 
            this.m_groupSelectedItem.BackGroundColor = System.Drawing.Color.WhiteSmoke;
            this.m_groupSelectedItem.EdgeBorderStroke = 2;
            this.m_groupSelectedItem.EdgeRadius = 2;
            this.m_groupSelectedItem.LabelFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_groupSelectedItem.LabelGradientColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.m_groupSelectedItem.LabelGradientColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_groupSelectedItem.LabelHeight = 30;
            this.m_groupSelectedItem.LabelTextColor = System.Drawing.Color.Black;
            this.m_groupSelectedItem.Location = new System.Drawing.Point(0, 168);
            this.m_groupSelectedItem.Name = "m_groupSelectedItem";
            this.m_groupSelectedItem.Size = new System.Drawing.Size(1140, 87);
            this.m_groupSelectedItem.TabIndex = 1370;
            this.m_groupSelectedItem.Text = "SELECTED ITEM";
            this.m_groupSelectedItem.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_groupSelectedItem.ThemeIndex = 0;
            this.m_groupSelectedItem.UseLabelBorder = true;
            // 
            // m_groupConfiguration
            // 
            this.m_groupConfiguration.BackGroundColor = System.Drawing.Color.WhiteSmoke;
            this.m_groupConfiguration.EdgeBorderStroke = 2;
            this.m_groupConfiguration.EdgeRadius = 2;
            this.m_groupConfiguration.LabelFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_groupConfiguration.LabelGradientColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.m_groupConfiguration.LabelGradientColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_groupConfiguration.LabelHeight = 30;
            this.m_groupConfiguration.LabelTextColor = System.Drawing.Color.Black;
            this.m_groupConfiguration.Location = new System.Drawing.Point(0, 384);
            this.m_groupConfiguration.Name = "m_groupConfiguration";
            this.m_groupConfiguration.Size = new System.Drawing.Size(570, 466);
            this.m_groupConfiguration.TabIndex = 1371;
            this.m_groupConfiguration.Text = "CONFIGURATION";
            this.m_groupConfiguration.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_groupConfiguration.ThemeIndex = 0;
            this.m_groupConfiguration.UseLabelBorder = true;
            // 
            // m_groupSerialDemonstration
            // 
            this.m_groupSerialDemonstration.BackGroundColor = System.Drawing.Color.WhiteSmoke;
            this.m_groupSerialDemonstration.EdgeBorderStroke = 2;
            this.m_groupSerialDemonstration.EdgeRadius = 2;
            this.m_groupSerialDemonstration.LabelFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_groupSerialDemonstration.LabelGradientColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.m_groupSerialDemonstration.LabelGradientColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_groupSerialDemonstration.LabelHeight = 30;
            this.m_groupSerialDemonstration.LabelTextColor = System.Drawing.Color.Black;
            this.m_groupSerialDemonstration.Location = new System.Drawing.Point(568, 384);
            this.m_groupSerialDemonstration.Name = "m_groupSerialDemonstration";
            this.m_groupSerialDemonstration.Size = new System.Drawing.Size(572, 466);
            this.m_groupSerialDemonstration.TabIndex = 1372;
            this.m_groupSerialDemonstration.Text = "SERIAL DEMONSTRATION";
            this.m_groupSerialDemonstration.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_groupSerialDemonstration.ThemeIndex = 0;
            this.m_groupSerialDemonstration.UseLabelBorder = true;
            // 
            // m_lblName
            // 
            this.m_lblName.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
            this.m_lblName.BorderStroke = 2;
            this.m_lblName.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblName.Description = "";
            this.m_lblName.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblName.EdgeRadius = 1;
            this.m_lblName.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_lblName.ImageSize = new System.Drawing.Point(0, 0);
            this.m_lblName.LoadImage = null;
            this.m_lblName.Location = new System.Drawing.Point(9, 469);
            this.m_lblName.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.m_lblName.MainFontColor = System.Drawing.Color.Black;
            this.m_lblName.Name = "m_lblName";
            this.m_lblName.Size = new System.Drawing.Size(155, 43);
            this.m_lblName.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.m_lblName.SubFontColor = System.Drawing.Color.Black;
            this.m_lblName.SubText = "";
            this.m_lblName.TabIndex = 1373;
            this.m_lblName.Text = "NAME";
            this.m_lblName.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblName.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblName.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblName.ThemeIndex = 0;
            this.m_lblName.UnitAreaRate = 40;
            this.m_lblName.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblName.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblName.UnitPositionVertical = false;
            this.m_lblName.UnitText = "";
            this.m_lblName.UseBorder = true;
            this.m_lblName.UseEdgeRadius = false;
            this.m_lblName.UseImage = false;
            this.m_lblName.UseSubFont = false;
            this.m_lblName.UseUnitFont = false;
            // 
            // m_lblDataBit
            // 
            this.m_lblDataBit.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
            this.m_lblDataBit.BorderStroke = 2;
            this.m_lblDataBit.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblDataBit.Description = "";
            this.m_lblDataBit.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblDataBit.EdgeRadius = 1;
            this.m_lblDataBit.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_lblDataBit.ImageSize = new System.Drawing.Point(0, 0);
            this.m_lblDataBit.LoadImage = null;
            this.m_lblDataBit.Location = new System.Drawing.Point(9, 518);
            this.m_lblDataBit.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.m_lblDataBit.MainFontColor = System.Drawing.Color.Black;
            this.m_lblDataBit.Name = "m_lblDataBit";
            this.m_lblDataBit.Size = new System.Drawing.Size(155, 43);
            this.m_lblDataBit.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.m_lblDataBit.SubFontColor = System.Drawing.Color.Black;
            this.m_lblDataBit.SubText = "";
            this.m_lblDataBit.TabIndex = 1373;
            this.m_lblDataBit.Text = "DATA BIT";
            this.m_lblDataBit.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblDataBit.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblDataBit.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblDataBit.ThemeIndex = 0;
            this.m_lblDataBit.UnitAreaRate = 40;
            this.m_lblDataBit.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblDataBit.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblDataBit.UnitPositionVertical = false;
            this.m_lblDataBit.UnitText = "";
            this.m_lblDataBit.UseBorder = true;
            this.m_lblDataBit.UseEdgeRadius = false;
            this.m_lblDataBit.UseImage = false;
            this.m_lblDataBit.UseSubFont = false;
            this.m_lblDataBit.UseUnitFont = false;
            // 
            // m_lblBaudRate
            // 
            this.m_lblBaudRate.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
            this.m_lblBaudRate.BorderStroke = 2;
            this.m_lblBaudRate.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblBaudRate.Description = "";
            this.m_lblBaudRate.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblBaudRate.EdgeRadius = 1;
            this.m_lblBaudRate.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_lblBaudRate.ImageSize = new System.Drawing.Point(0, 0);
            this.m_lblBaudRate.LoadImage = null;
            this.m_lblBaudRate.Location = new System.Drawing.Point(9, 567);
            this.m_lblBaudRate.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.m_lblBaudRate.MainFontColor = System.Drawing.Color.Black;
            this.m_lblBaudRate.Name = "m_lblBaudRate";
            this.m_lblBaudRate.Size = new System.Drawing.Size(155, 43);
            this.m_lblBaudRate.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.m_lblBaudRate.SubFontColor = System.Drawing.Color.Black;
            this.m_lblBaudRate.SubText = "";
            this.m_lblBaudRate.TabIndex = 1373;
            this.m_lblBaudRate.Text = "BAUDRATE";
            this.m_lblBaudRate.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblBaudRate.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblBaudRate.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblBaudRate.ThemeIndex = 0;
            this.m_lblBaudRate.UnitAreaRate = 40;
            this.m_lblBaudRate.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblBaudRate.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblBaudRate.UnitPositionVertical = false;
            this.m_lblBaudRate.UnitText = "";
            this.m_lblBaudRate.UseBorder = true;
            this.m_lblBaudRate.UseEdgeRadius = false;
            this.m_lblBaudRate.UseImage = false;
            this.m_lblBaudRate.UseSubFont = false;
            this.m_lblBaudRate.UseUnitFont = false;
            // 
            // m_lblStopBit
            // 
            this.m_lblStopBit.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
            this.m_lblStopBit.BorderStroke = 2;
            this.m_lblStopBit.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblStopBit.Description = "";
            this.m_lblStopBit.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblStopBit.EdgeRadius = 1;
            this.m_lblStopBit.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_lblStopBit.ImageSize = new System.Drawing.Point(0, 0);
            this.m_lblStopBit.LoadImage = null;
            this.m_lblStopBit.Location = new System.Drawing.Point(9, 616);
            this.m_lblStopBit.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.m_lblStopBit.MainFontColor = System.Drawing.Color.Black;
            this.m_lblStopBit.Name = "m_lblStopBit";
            this.m_lblStopBit.Size = new System.Drawing.Size(155, 43);
            this.m_lblStopBit.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.m_lblStopBit.SubFontColor = System.Drawing.Color.Black;
            this.m_lblStopBit.SubText = "";
            this.m_lblStopBit.TabIndex = 1373;
            this.m_lblStopBit.Text = "STOP BIT";
            this.m_lblStopBit.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblStopBit.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblStopBit.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblStopBit.ThemeIndex = 0;
            this.m_lblStopBit.UnitAreaRate = 40;
            this.m_lblStopBit.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblStopBit.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblStopBit.UnitPositionVertical = false;
            this.m_lblStopBit.UnitText = "";
            this.m_lblStopBit.UseBorder = true;
            this.m_lblStopBit.UseEdgeRadius = false;
            this.m_lblStopBit.UseImage = false;
            this.m_lblStopBit.UseSubFont = false;
            this.m_lblStopBit.UseUnitFont = false;
            // 
            // m_lblParityBit
            // 
            this.m_lblParityBit.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
            this.m_lblParityBit.BorderStroke = 2;
            this.m_lblParityBit.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblParityBit.Description = "";
            this.m_lblParityBit.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblParityBit.EdgeRadius = 1;
            this.m_lblParityBit.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_lblParityBit.ImageSize = new System.Drawing.Point(0, 0);
            this.m_lblParityBit.LoadImage = null;
            this.m_lblParityBit.Location = new System.Drawing.Point(287, 616);
            this.m_lblParityBit.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.m_lblParityBit.MainFontColor = System.Drawing.Color.Black;
            this.m_lblParityBit.Name = "m_lblParityBit";
            this.m_lblParityBit.Size = new System.Drawing.Size(155, 43);
            this.m_lblParityBit.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.m_lblParityBit.SubFontColor = System.Drawing.Color.Black;
            this.m_lblParityBit.SubText = "";
            this.m_lblParityBit.TabIndex = 1373;
            this.m_lblParityBit.Text = "PARITY BIT";
            this.m_lblParityBit.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblParityBit.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblParityBit.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblParityBit.ThemeIndex = 0;
            this.m_lblParityBit.UnitAreaRate = 40;
            this.m_lblParityBit.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblParityBit.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblParityBit.UnitPositionVertical = false;
            this.m_lblParityBit.UnitText = "";
            this.m_lblParityBit.UseBorder = true;
            this.m_lblParityBit.UseEdgeRadius = false;
            this.m_lblParityBit.UseImage = false;
            this.m_lblParityBit.UseSubFont = false;
            this.m_lblParityBit.UseUnitFont = false;
            // 
            // m_lblReceiveTimeout
            // 
            this.m_lblReceiveTimeout.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
            this.m_lblReceiveTimeout.BorderStroke = 2;
            this.m_lblReceiveTimeout.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblReceiveTimeout.Description = "";
            this.m_lblReceiveTimeout.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblReceiveTimeout.EdgeRadius = 1;
            this.m_lblReceiveTimeout.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_lblReceiveTimeout.ImageSize = new System.Drawing.Point(0, 0);
            this.m_lblReceiveTimeout.LoadImage = null;
            this.m_lblReceiveTimeout.Location = new System.Drawing.Point(9, 665);
            this.m_lblReceiveTimeout.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.m_lblReceiveTimeout.MainFontColor = System.Drawing.Color.Black;
            this.m_lblReceiveTimeout.Name = "m_lblReceiveTimeout";
            this.m_lblReceiveTimeout.Size = new System.Drawing.Size(155, 43);
            this.m_lblReceiveTimeout.SubFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.m_lblReceiveTimeout.SubFontColor = System.Drawing.Color.Indigo;
            this.m_lblReceiveTimeout.SubText = "RECIVE";
            this.m_lblReceiveTimeout.TabIndex = 1373;
            this.m_lblReceiveTimeout.Text = "TIMEOUT";
            this.m_lblReceiveTimeout.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblReceiveTimeout.TextAlignSub = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
            this.m_lblReceiveTimeout.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblReceiveTimeout.ThemeIndex = 0;
            this.m_lblReceiveTimeout.UnitAreaRate = 40;
            this.m_lblReceiveTimeout.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblReceiveTimeout.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblReceiveTimeout.UnitPositionVertical = false;
            this.m_lblReceiveTimeout.UnitText = "";
            this.m_lblReceiveTimeout.UseBorder = true;
            this.m_lblReceiveTimeout.UseEdgeRadius = false;
            this.m_lblReceiveTimeout.UseImage = false;
            this.m_lblReceiveTimeout.UseSubFont = true;
            this.m_lblReceiveTimeout.UseUnitFont = false;
            // 
            // m_lblPortName
            // 
            this.m_lblPortName.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
            this.m_lblPortName.BorderStroke = 2;
            this.m_lblPortName.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblPortName.Description = "";
            this.m_lblPortName.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblPortName.EdgeRadius = 1;
            this.m_lblPortName.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_lblPortName.ImageSize = new System.Drawing.Point(0, 0);
            this.m_lblPortName.LoadImage = null;
            this.m_lblPortName.Location = new System.Drawing.Point(9, 420);
            this.m_lblPortName.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.m_lblPortName.MainFontColor = System.Drawing.Color.Black;
            this.m_lblPortName.Name = "m_lblPortName";
            this.m_lblPortName.Size = new System.Drawing.Size(155, 43);
            this.m_lblPortName.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.m_lblPortName.SubFontColor = System.Drawing.Color.Black;
            this.m_lblPortName.SubText = "";
            this.m_lblPortName.TabIndex = 1374;
            this.m_lblPortName.Text = "PROT NAME";
            this.m_lblPortName.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblPortName.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblPortName.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblPortName.ThemeIndex = 0;
            this.m_lblPortName.UnitAreaRate = 40;
            this.m_lblPortName.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblPortName.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblPortName.UnitPositionVertical = false;
            this.m_lblPortName.UnitText = "";
            this.m_lblPortName.UseBorder = true;
            this.m_lblPortName.UseEdgeRadius = false;
            this.m_lblPortName.UseImage = false;
            this.m_lblPortName.UseSubFont = false;
            this.m_lblPortName.UseUnitFont = false;
            // 
            // m_lblIndex
            // 
            this.m_lblIndex.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
            this.m_lblIndex.BorderStroke = 2;
            this.m_lblIndex.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblIndex.Description = "";
            this.m_lblIndex.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblIndex.EdgeRadius = 1;
            this.m_lblIndex.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_lblIndex.ImageSize = new System.Drawing.Point(0, 0);
            this.m_lblIndex.LoadImage = null;
            this.m_lblIndex.Location = new System.Drawing.Point(9, 205);
            this.m_lblIndex.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.m_lblIndex.MainFontColor = System.Drawing.Color.Black;
            this.m_lblIndex.Name = "m_lblIndex";
            this.m_lblIndex.Size = new System.Drawing.Size(155, 40);
            this.m_lblIndex.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.m_lblIndex.SubFontColor = System.Drawing.Color.Black;
            this.m_lblIndex.SubText = "";
            this.m_lblIndex.TabIndex = 1375;
            this.m_lblIndex.Text = "INDEX";
            this.m_lblIndex.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblIndex.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblIndex.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblIndex.ThemeIndex = 0;
            this.m_lblIndex.UnitAreaRate = 40;
            this.m_lblIndex.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblIndex.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblIndex.UnitPositionVertical = false;
            this.m_lblIndex.UnitText = "";
            this.m_lblIndex.UseBorder = true;
            this.m_lblIndex.UseEdgeRadius = false;
            this.m_lblIndex.UseImage = false;
            this.m_lblIndex.UseSubFont = false;
            this.m_lblIndex.UseUnitFont = false;
            // 
            // m_lblState
            // 
            this.m_lblState.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
            this.m_lblState.BorderStroke = 2;
            this.m_lblState.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblState.Description = "";
            this.m_lblState.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblState.EdgeRadius = 1;
            this.m_lblState.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_lblState.ImageSize = new System.Drawing.Point(0, 0);
            this.m_lblState.LoadImage = null;
            this.m_lblState.Location = new System.Drawing.Point(572, 205);
            this.m_lblState.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.m_lblState.MainFontColor = System.Drawing.Color.Black;
            this.m_lblState.Name = "m_lblState";
            this.m_lblState.Size = new System.Drawing.Size(159, 40);
            this.m_lblState.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.m_lblState.SubFontColor = System.Drawing.Color.Black;
            this.m_lblState.SubText = "";
            this.m_lblState.TabIndex = 1376;
            this.m_lblState.Text = "STATE";
            this.m_lblState.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblState.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblState.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblState.ThemeIndex = 0;
            this.m_lblState.UnitAreaRate = 40;
            this.m_lblState.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblState.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblState.UnitPositionVertical = false;
            this.m_lblState.UnitText = "";
            this.m_lblState.UseBorder = true;
            this.m_lblState.UseEdgeRadius = false;
            this.m_lblState.UseImage = false;
            this.m_lblState.UseSubFont = false;
            this.m_lblState.UseUnitFont = false;
            // 
            // m_labelPortName
            // 
            this.m_labelPortName.BackGroundColor = System.Drawing.Color.White;
            this.m_labelPortName.BorderStroke = 2;
            this.m_labelPortName.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_labelPortName.Description = "";
            this.m_labelPortName.DisabledColor = System.Drawing.Color.LightGray;
            this.m_labelPortName.EdgeRadius = 1;
            this.m_labelPortName.Enabled = false;
            this.m_labelPortName.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_labelPortName.ImageSize = new System.Drawing.Point(0, 0);
            this.m_labelPortName.LoadImage = null;
            this.m_labelPortName.Location = new System.Drawing.Point(165, 420);
            this.m_labelPortName.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_labelPortName.MainFontColor = System.Drawing.Color.Black;
            this.m_labelPortName.Name = "m_labelPortName";
            this.m_labelPortName.Size = new System.Drawing.Size(395, 43);
            this.m_labelPortName.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.m_labelPortName.SubFontColor = System.Drawing.Color.Black;
            this.m_labelPortName.SubText = "";
            this.m_labelPortName.TabIndex = 0;
            this.m_labelPortName.Text = "--";
            this.m_labelPortName.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
            this.m_labelPortName.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_labelPortName.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_labelPortName.ThemeIndex = 0;
            this.m_labelPortName.UnitAreaRate = 40;
            this.m_labelPortName.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_labelPortName.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_labelPortName.UnitPositionVertical = false;
            this.m_labelPortName.UnitText = "";
            this.m_labelPortName.UseBorder = true;
            this.m_labelPortName.UseEdgeRadius = false;
            this.m_labelPortName.UseImage = false;
            this.m_labelPortName.UseSubFont = false;
            this.m_labelPortName.UseUnitFont = false;
            this.m_labelPortName.Click += new System.EventHandler(this.Click_Configuration);
            // 
            // m_labelName
            // 
            this.m_labelName.BackGroundColor = System.Drawing.Color.White;
            this.m_labelName.BorderStroke = 2;
            this.m_labelName.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_labelName.Description = "";
            this.m_labelName.DisabledColor = System.Drawing.Color.LightGray;
            this.m_labelName.EdgeRadius = 1;
            this.m_labelName.Enabled = false;
            this.m_labelName.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_labelName.ImageSize = new System.Drawing.Point(0, 0);
            this.m_labelName.LoadImage = null;
            this.m_labelName.Location = new System.Drawing.Point(165, 469);
            this.m_labelName.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_labelName.MainFontColor = System.Drawing.Color.Black;
            this.m_labelName.Name = "m_labelName";
            this.m_labelName.Size = new System.Drawing.Size(395, 43);
            this.m_labelName.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.m_labelName.SubFontColor = System.Drawing.Color.Black;
            this.m_labelName.SubText = "";
            this.m_labelName.TabIndex = 5;
            this.m_labelName.Text = "--";
            this.m_labelName.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
            this.m_labelName.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_labelName.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_labelName.ThemeIndex = 0;
            this.m_labelName.UnitAreaRate = 40;
            this.m_labelName.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_labelName.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_labelName.UnitPositionVertical = false;
            this.m_labelName.UnitText = "";
            this.m_labelName.UseBorder = true;
            this.m_labelName.UseEdgeRadius = false;
            this.m_labelName.UseImage = false;
            this.m_labelName.UseSubFont = false;
            this.m_labelName.UseUnitFont = false;
            this.m_labelName.Click += new System.EventHandler(this.Click_Configuration);
            // 
            // m_labelDataBit
            // 
            this.m_labelDataBit.BackGroundColor = System.Drawing.Color.White;
            this.m_labelDataBit.BorderStroke = 2;
            this.m_labelDataBit.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_labelDataBit.Description = "";
            this.m_labelDataBit.DisabledColor = System.Drawing.Color.LightGray;
            this.m_labelDataBit.EdgeRadius = 1;
            this.m_labelDataBit.Enabled = false;
            this.m_labelDataBit.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_labelDataBit.ImageSize = new System.Drawing.Point(0, 0);
            this.m_labelDataBit.LoadImage = null;
            this.m_labelDataBit.Location = new System.Drawing.Point(165, 518);
            this.m_labelDataBit.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_labelDataBit.MainFontColor = System.Drawing.Color.Black;
            this.m_labelDataBit.Name = "m_labelDataBit";
            this.m_labelDataBit.Size = new System.Drawing.Size(395, 43);
            this.m_labelDataBit.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.m_labelDataBit.SubFontColor = System.Drawing.Color.Black;
            this.m_labelDataBit.SubText = "";
            this.m_labelDataBit.TabIndex = 1;
            this.m_labelDataBit.Text = "--";
            this.m_labelDataBit.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
            this.m_labelDataBit.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_labelDataBit.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_labelDataBit.ThemeIndex = 0;
            this.m_labelDataBit.UnitAreaRate = 40;
            this.m_labelDataBit.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_labelDataBit.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_labelDataBit.UnitPositionVertical = false;
            this.m_labelDataBit.UnitText = "";
            this.m_labelDataBit.UseBorder = true;
            this.m_labelDataBit.UseEdgeRadius = false;
            this.m_labelDataBit.UseImage = false;
            this.m_labelDataBit.UseSubFont = false;
            this.m_labelDataBit.UseUnitFont = false;
            this.m_labelDataBit.Click += new System.EventHandler(this.Click_Configuration);
            // 
            // m_labelBaudRate
            // 
            this.m_labelBaudRate.BackGroundColor = System.Drawing.Color.White;
            this.m_labelBaudRate.BorderStroke = 2;
            this.m_labelBaudRate.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_labelBaudRate.Description = "";
            this.m_labelBaudRate.DisabledColor = System.Drawing.Color.LightGray;
            this.m_labelBaudRate.EdgeRadius = 1;
            this.m_labelBaudRate.Enabled = false;
            this.m_labelBaudRate.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_labelBaudRate.ImageSize = new System.Drawing.Point(0, 0);
            this.m_labelBaudRate.LoadImage = null;
            this.m_labelBaudRate.Location = new System.Drawing.Point(165, 567);
            this.m_labelBaudRate.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_labelBaudRate.MainFontColor = System.Drawing.Color.Black;
            this.m_labelBaudRate.Name = "m_labelBaudRate";
            this.m_labelBaudRate.Size = new System.Drawing.Size(395, 43);
            this.m_labelBaudRate.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.m_labelBaudRate.SubFontColor = System.Drawing.Color.Black;
            this.m_labelBaudRate.SubText = "";
            this.m_labelBaudRate.TabIndex = 2;
            this.m_labelBaudRate.Text = "--";
            this.m_labelBaudRate.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
            this.m_labelBaudRate.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_labelBaudRate.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_labelBaudRate.ThemeIndex = 0;
            this.m_labelBaudRate.UnitAreaRate = 40;
            this.m_labelBaudRate.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_labelBaudRate.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_labelBaudRate.UnitPositionVertical = false;
            this.m_labelBaudRate.UnitText = "";
            this.m_labelBaudRate.UseBorder = true;
            this.m_labelBaudRate.UseEdgeRadius = false;
            this.m_labelBaudRate.UseImage = false;
            this.m_labelBaudRate.UseSubFont = false;
            this.m_labelBaudRate.UseUnitFont = false;
            this.m_labelBaudRate.Click += new System.EventHandler(this.Click_Configuration);
            // 
            // m_labelReceiveTimeout
            // 
            this.m_labelReceiveTimeout.BackGroundColor = System.Drawing.Color.White;
            this.m_labelReceiveTimeout.BorderStroke = 2;
            this.m_labelReceiveTimeout.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_labelReceiveTimeout.Description = "";
            this.m_labelReceiveTimeout.DisabledColor = System.Drawing.Color.LightGray;
            this.m_labelReceiveTimeout.EdgeRadius = 1;
            this.m_labelReceiveTimeout.Enabled = false;
            this.m_labelReceiveTimeout.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_labelReceiveTimeout.ImageSize = new System.Drawing.Point(0, 0);
            this.m_labelReceiveTimeout.LoadImage = null;
            this.m_labelReceiveTimeout.Location = new System.Drawing.Point(165, 665);
            this.m_labelReceiveTimeout.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_labelReceiveTimeout.MainFontColor = System.Drawing.Color.Black;
            this.m_labelReceiveTimeout.Name = "m_labelReceiveTimeout";
            this.m_labelReceiveTimeout.Size = new System.Drawing.Size(395, 43);
            this.m_labelReceiveTimeout.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.m_labelReceiveTimeout.SubFontColor = System.Drawing.Color.Black;
            this.m_labelReceiveTimeout.SubText = "";
            this.m_labelReceiveTimeout.TabIndex = 6;
            this.m_labelReceiveTimeout.Text = "--";
            this.m_labelReceiveTimeout.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
            this.m_labelReceiveTimeout.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_labelReceiveTimeout.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
            this.m_labelReceiveTimeout.ThemeIndex = 0;
            this.m_labelReceiveTimeout.UnitAreaRate = 20;
            this.m_labelReceiveTimeout.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_labelReceiveTimeout.UnitFontColor = System.Drawing.Color.Black;
            this.m_labelReceiveTimeout.UnitPositionVertical = false;
            this.m_labelReceiveTimeout.UnitText = "ms";
            this.m_labelReceiveTimeout.UseBorder = true;
            this.m_labelReceiveTimeout.UseEdgeRadius = false;
            this.m_labelReceiveTimeout.UseImage = false;
            this.m_labelReceiveTimeout.UseSubFont = false;
            this.m_labelReceiveTimeout.UseUnitFont = true;
            this.m_labelReceiveTimeout.Click += new System.EventHandler(this.Click_Configuration);
            // 
            // m_labelParityBit
            // 
            this.m_labelParityBit.BackGroundColor = System.Drawing.Color.White;
            this.m_labelParityBit.BorderStroke = 2;
            this.m_labelParityBit.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_labelParityBit.Description = "";
            this.m_labelParityBit.DisabledColor = System.Drawing.Color.LightGray;
            this.m_labelParityBit.EdgeRadius = 1;
            this.m_labelParityBit.Enabled = false;
            this.m_labelParityBit.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_labelParityBit.ImageSize = new System.Drawing.Point(0, 0);
            this.m_labelParityBit.LoadImage = null;
            this.m_labelParityBit.Location = new System.Drawing.Point(443, 616);
            this.m_labelParityBit.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_labelParityBit.MainFontColor = System.Drawing.Color.Black;
            this.m_labelParityBit.Name = "m_labelParityBit";
            this.m_labelParityBit.Size = new System.Drawing.Size(117, 43);
            this.m_labelParityBit.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.m_labelParityBit.SubFontColor = System.Drawing.Color.Black;
            this.m_labelParityBit.SubText = "";
            this.m_labelParityBit.TabIndex = 4;
            this.m_labelParityBit.Text = "--";
            this.m_labelParityBit.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
            this.m_labelParityBit.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_labelParityBit.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_labelParityBit.ThemeIndex = 0;
            this.m_labelParityBit.UnitAreaRate = 40;
            this.m_labelParityBit.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_labelParityBit.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_labelParityBit.UnitPositionVertical = false;
            this.m_labelParityBit.UnitText = "";
            this.m_labelParityBit.UseBorder = true;
            this.m_labelParityBit.UseEdgeRadius = false;
            this.m_labelParityBit.UseImage = false;
            this.m_labelParityBit.UseSubFont = false;
            this.m_labelParityBit.UseUnitFont = false;
            this.m_labelParityBit.Click += new System.EventHandler(this.Click_Configuration);
            // 
            // m_labelStopBit
            // 
            this.m_labelStopBit.BackGroundColor = System.Drawing.Color.White;
            this.m_labelStopBit.BorderStroke = 2;
            this.m_labelStopBit.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_labelStopBit.Description = "";
            this.m_labelStopBit.DisabledColor = System.Drawing.Color.LightGray;
            this.m_labelStopBit.EdgeRadius = 1;
            this.m_labelStopBit.Enabled = false;
            this.m_labelStopBit.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_labelStopBit.ImageSize = new System.Drawing.Point(0, 0);
            this.m_labelStopBit.LoadImage = null;
            this.m_labelStopBit.Location = new System.Drawing.Point(165, 616);
            this.m_labelStopBit.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_labelStopBit.MainFontColor = System.Drawing.Color.Black;
            this.m_labelStopBit.Name = "m_labelStopBit";
            this.m_labelStopBit.Size = new System.Drawing.Size(117, 43);
            this.m_labelStopBit.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.m_labelStopBit.SubFontColor = System.Drawing.Color.Black;
            this.m_labelStopBit.SubText = "";
            this.m_labelStopBit.TabIndex = 3;
            this.m_labelStopBit.Text = "--";
            this.m_labelStopBit.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
            this.m_labelStopBit.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_labelStopBit.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_labelStopBit.ThemeIndex = 0;
            this.m_labelStopBit.UnitAreaRate = 40;
            this.m_labelStopBit.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_labelStopBit.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_labelStopBit.UnitPositionVertical = false;
            this.m_labelStopBit.UnitText = "";
            this.m_labelStopBit.UseBorder = true;
            this.m_labelStopBit.UseEdgeRadius = false;
            this.m_labelStopBit.UseImage = false;
            this.m_labelStopBit.UseSubFont = false;
            this.m_labelStopBit.UseUnitFont = false;
            this.m_labelStopBit.Click += new System.EventHandler(this.Click_Configuration);
            // 
            // m_labelIndex
            // 
            this.m_labelIndex.BackGroundColor = System.Drawing.Color.White;
            this.m_labelIndex.BorderStroke = 2;
            this.m_labelIndex.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_labelIndex.Description = "";
            this.m_labelIndex.DisabledColor = System.Drawing.Color.LightGray;
            this.m_labelIndex.EdgeRadius = 1;
            this.m_labelIndex.Enabled = false;
            this.m_labelIndex.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_labelIndex.ImageSize = new System.Drawing.Point(0, 0);
            this.m_labelIndex.LoadImage = null;
            this.m_labelIndex.Location = new System.Drawing.Point(165, 205);
            this.m_labelIndex.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_labelIndex.MainFontColor = System.Drawing.Color.Black;
            this.m_labelIndex.Name = "m_labelIndex";
            this.m_labelIndex.Size = new System.Drawing.Size(402, 39);
            this.m_labelIndex.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.m_labelIndex.SubFontColor = System.Drawing.Color.Black;
            this.m_labelIndex.SubText = "";
            this.m_labelIndex.TabIndex = 1384;
            this.m_labelIndex.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_labelIndex.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_labelIndex.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_labelIndex.ThemeIndex = 0;
            this.m_labelIndex.UnitAreaRate = 40;
            this.m_labelIndex.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_labelIndex.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_labelIndex.UnitPositionVertical = false;
            this.m_labelIndex.UnitText = "";
            this.m_labelIndex.UseBorder = true;
            this.m_labelIndex.UseEdgeRadius = false;
            this.m_labelIndex.UseImage = false;
            this.m_labelIndex.UseSubFont = false;
            this.m_labelIndex.UseUnitFont = false;
            // 
            // m_labelState
            // 
            this.m_labelState.BackGroundColor = System.Drawing.Color.White;
            this.m_labelState.BorderStroke = 2;
            this.m_labelState.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_labelState.Description = "";
            this.m_labelState.DisabledColor = System.Drawing.Color.LightGray;
            this.m_labelState.EdgeRadius = 1;
            this.m_labelState.Enabled = false;
            this.m_labelState.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_labelState.ImageSize = new System.Drawing.Point(0, 0);
            this.m_labelState.LoadImage = null;
            this.m_labelState.Location = new System.Drawing.Point(732, 205);
            this.m_labelState.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_labelState.MainFontColor = System.Drawing.Color.Black;
            this.m_labelState.Name = "m_labelState";
            this.m_labelState.Size = new System.Drawing.Size(402, 39);
            this.m_labelState.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.m_labelState.SubFontColor = System.Drawing.Color.Black;
            this.m_labelState.SubText = "";
            this.m_labelState.TabIndex = 1385;
            this.m_labelState.Text = "--";
            this.m_labelState.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
            this.m_labelState.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_labelState.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_labelState.ThemeIndex = 0;
            this.m_labelState.UnitAreaRate = 40;
            this.m_labelState.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_labelState.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_labelState.UnitPositionVertical = false;
            this.m_labelState.UnitText = "";
            this.m_labelState.UseBorder = true;
            this.m_labelState.UseEdgeRadius = false;
            this.m_labelState.UseImage = false;
            this.m_labelState.UseSubFont = false;
            this.m_labelState.UseUnitFont = false;
            // 
            // m_labelMessage
            // 
            this.m_labelMessage.BackGroundColor = System.Drawing.Color.White;
            this.m_labelMessage.BorderStroke = 2;
            this.m_labelMessage.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_labelMessage.Description = "";
            this.m_labelMessage.DisabledColor = System.Drawing.Color.LightGray;
            this.m_labelMessage.EdgeRadius = 1;
            this.m_labelMessage.Enabled = false;
            this.m_labelMessage.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_labelMessage.ImageSize = new System.Drawing.Point(0, 0);
            this.m_labelMessage.LoadImage = null;
            this.m_labelMessage.Location = new System.Drawing.Point(662, 718);
            this.m_labelMessage.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_labelMessage.MainFontColor = System.Drawing.Color.Black;
            this.m_labelMessage.Name = "m_labelMessage";
            this.m_labelMessage.Size = new System.Drawing.Size(329, 39);
            this.m_labelMessage.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.m_labelMessage.SubFontColor = System.Drawing.Color.Black;
            this.m_labelMessage.SubText = "";
            this.m_labelMessage.TabIndex = 0;
            this.m_labelMessage.Text = "--";
            this.m_labelMessage.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
            this.m_labelMessage.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_labelMessage.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_labelMessage.ThemeIndex = 0;
            this.m_labelMessage.UnitAreaRate = 40;
            this.m_labelMessage.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_labelMessage.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_labelMessage.UnitPositionVertical = false;
            this.m_labelMessage.UnitText = "";
            this.m_labelMessage.UseBorder = true;
            this.m_labelMessage.UseEdgeRadius = false;
            this.m_labelMessage.UseImage = false;
            this.m_labelMessage.UseSubFont = false;
            this.m_labelMessage.UseUnitFont = false;
            this.m_labelMessage.Click += new System.EventHandler(this.Click_SendOrClearMessage);
            // 
            // m_lblMessage
            // 
            this.m_lblMessage.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
            this.m_lblMessage.BorderStroke = 2;
            this.m_lblMessage.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblMessage.Description = "";
            this.m_lblMessage.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblMessage.EdgeRadius = 1;
            this.m_lblMessage.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_lblMessage.ImageSize = new System.Drawing.Point(0, 0);
            this.m_lblMessage.LoadImage = null;
            this.m_lblMessage.Location = new System.Drawing.Point(578, 718);
            this.m_lblMessage.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.m_lblMessage.MainFontColor = System.Drawing.Color.Black;
            this.m_lblMessage.Name = "m_lblMessage";
            this.m_lblMessage.Size = new System.Drawing.Size(83, 39);
            this.m_lblMessage.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.m_lblMessage.SubFontColor = System.Drawing.Color.Black;
            this.m_lblMessage.SubText = "";
            this.m_lblMessage.TabIndex = 1386;
            this.m_lblMessage.Text = "MESSAGE";
            this.m_lblMessage.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblMessage.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblMessage.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblMessage.ThemeIndex = 0;
            this.m_lblMessage.UnitAreaRate = 40;
            this.m_lblMessage.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblMessage.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblMessage.UnitPositionVertical = false;
            this.m_lblMessage.UnitText = "";
            this.m_lblMessage.UseBorder = true;
            this.m_lblMessage.UseEdgeRadius = false;
            this.m_lblMessage.UseImage = false;
            this.m_lblMessage.UseSubFont = false;
            this.m_lblMessage.UseUnitFont = false;
            // 
            // m_btnSend
            // 
            this.m_btnSend.BorderWidth = 3;
            this.m_btnSend.ButtonClicked = false;
            this.m_btnSend.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.m_btnSend.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.m_btnSend.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.m_btnSend.Description = "";
            this.m_btnSend.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_btnSend.EdgeRadius = 5;
            this.m_btnSend.Enabled = false;
            this.m_btnSend.GradientAngle = 70F;
            this.m_btnSend.GradientFirstColor = System.Drawing.Color.White;
            this.m_btnSend.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
            this.m_btnSend.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.m_btnSend.ImagePosition = new System.Drawing.Point(8, 4);
            this.m_btnSend.ImageSize = new System.Drawing.Point(30, 30);
            this.m_btnSend.LoadImage = global::FrameOfSystem3.Properties.Resources.SEND_BLACK;
            this.m_btnSend.Location = new System.Drawing.Point(1003, 718);
            this.m_btnSend.MainFont = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.m_btnSend.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
            this.m_btnSend.Name = "m_btnSend";
            this.m_btnSend.Size = new System.Drawing.Size(128, 39);
            this.m_btnSend.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.m_btnSend.SubFontColor = System.Drawing.Color.DarkBlue;
            this.m_btnSend.SubText = "STATUS";
            this.m_btnSend.TabIndex = 1;
            this.m_btnSend.Text = "SEND";
            this.m_btnSend.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.m_btnSend.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_btnSend.ThemeIndex = 0;
            this.m_btnSend.UseBorder = true;
            this.m_btnSend.UseClickedEmphasizeTextColor = false;
            this.m_btnSend.UseCustomizeClickedColor = false;
            this.m_btnSend.UseEdge = true;
            this.m_btnSend.UseHoverEmphasizeCustomColor = false;
            this.m_btnSend.UseImage = true;
            this.m_btnSend.UserHoverEmpahsize = false;
            this.m_btnSend.UseSubFont = false;
            this.m_btnSend.Click += new System.EventHandler(this.Click_SendOrClearMessage);
            // 
            // m_btnClearMessage
            // 
            this.m_btnClearMessage.BorderWidth = 3;
            this.m_btnClearMessage.ButtonClicked = false;
            this.m_btnClearMessage.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.m_btnClearMessage.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.m_btnClearMessage.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.m_btnClearMessage.Description = "";
            this.m_btnClearMessage.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_btnClearMessage.EdgeRadius = 5;
            this.m_btnClearMessage.Enabled = false;
            this.m_btnClearMessage.GradientAngle = 70F;
            this.m_btnClearMessage.GradientFirstColor = System.Drawing.Color.White;
            this.m_btnClearMessage.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
            this.m_btnClearMessage.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.m_btnClearMessage.ImagePosition = new System.Drawing.Point(7, 7);
            this.m_btnClearMessage.ImageSize = new System.Drawing.Point(30, 30);
            this.m_btnClearMessage.LoadImage = global::FrameOfSystem3.Properties.Resources.CONFIG_ADD3;
            this.m_btnClearMessage.Location = new System.Drawing.Point(1003, 763);
            this.m_btnClearMessage.MainFont = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.m_btnClearMessage.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
            this.m_btnClearMessage.Name = "m_btnClearMessage";
            this.m_btnClearMessage.Size = new System.Drawing.Size(128, 77);
            this.m_btnClearMessage.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.m_btnClearMessage.SubFontColor = System.Drawing.Color.DarkBlue;
            this.m_btnClearMessage.SubText = "STATUS";
            this.m_btnClearMessage.TabIndex = 2;
            this.m_btnClearMessage.Text = "CLEAR MESSAGE";
            this.m_btnClearMessage.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.m_btnClearMessage.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_btnClearMessage.ThemeIndex = 0;
            this.m_btnClearMessage.UseBorder = true;
            this.m_btnClearMessage.UseClickedEmphasizeTextColor = false;
            this.m_btnClearMessage.UseCustomizeClickedColor = false;
            this.m_btnClearMessage.UseEdge = true;
            this.m_btnClearMessage.UseHoverEmphasizeCustomColor = false;
            this.m_btnClearMessage.UseImage = false;
            this.m_btnClearMessage.UserHoverEmpahsize = false;
            this.m_btnClearMessage.UseSubFont = false;
            this.m_btnClearMessage.Click += new System.EventHandler(this.Click_SendOrClearMessage);
            // 
            // m_btnClose
            // 
            this.m_btnClose.BorderWidth = 3;
            this.m_btnClose.ButtonClicked = false;
            this.m_btnClose.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.m_btnClose.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.m_btnClose.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.m_btnClose.Description = "";
            this.m_btnClose.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_btnClose.EdgeRadius = 5;
            this.m_btnClose.Enabled = false;
            this.m_btnClose.GradientAngle = 70F;
            this.m_btnClose.GradientFirstColor = System.Drawing.Color.White;
            this.m_btnClose.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
            this.m_btnClose.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.m_btnClose.ImagePosition = new System.Drawing.Point(7, 7);
            this.m_btnClose.ImageSize = new System.Drawing.Point(30, 30);
            this.m_btnClose.LoadImage = global::FrameOfSystem3.Properties.Resources.DISCONNECT_BLACK;
            this.m_btnClose.Location = new System.Drawing.Point(710, 763);
            this.m_btnClose.MainFont = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.m_btnClose.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
            this.m_btnClose.Name = "m_btnClose";
            this.m_btnClose.Size = new System.Drawing.Size(128, 77);
            this.m_btnClose.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.m_btnClose.SubFontColor = System.Drawing.Color.DarkBlue;
            this.m_btnClose.SubText = "STATUS";
            this.m_btnClose.TabIndex = 1;
            this.m_btnClose.Text = "CLOSE";
            this.m_btnClose.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.m_btnClose.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_RIGHT;
            this.m_btnClose.ThemeIndex = 0;
            this.m_btnClose.UseBorder = true;
            this.m_btnClose.UseClickedEmphasizeTextColor = false;
            this.m_btnClose.UseCustomizeClickedColor = false;
            this.m_btnClose.UseEdge = true;
            this.m_btnClose.UseHoverEmphasizeCustomColor = false;
            this.m_btnClose.UseImage = true;
            this.m_btnClose.UserHoverEmpahsize = false;
            this.m_btnClose.UseSubFont = true;
            this.m_btnClose.Click += new System.EventHandler(this.Click_OpenOrClose);
            // 
            // m_btnOpen
            // 
            this.m_btnOpen.BorderWidth = 3;
            this.m_btnOpen.ButtonClicked = false;
            this.m_btnOpen.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.m_btnOpen.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.m_btnOpen.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.m_btnOpen.Description = "";
            this.m_btnOpen.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_btnOpen.EdgeRadius = 5;
            this.m_btnOpen.Enabled = false;
            this.m_btnOpen.GradientAngle = 70F;
            this.m_btnOpen.GradientFirstColor = System.Drawing.Color.White;
            this.m_btnOpen.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
            this.m_btnOpen.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.m_btnOpen.ImagePosition = new System.Drawing.Point(7, 7);
            this.m_btnOpen.ImageSize = new System.Drawing.Point(30, 30);
            this.m_btnOpen.LoadImage = global::FrameOfSystem3.Properties.Resources.CONNECT_BLACK;
            this.m_btnOpen.Location = new System.Drawing.Point(578, 763);
            this.m_btnOpen.MainFont = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.m_btnOpen.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
            this.m_btnOpen.Name = "m_btnOpen";
            this.m_btnOpen.Size = new System.Drawing.Size(128, 77);
            this.m_btnOpen.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.m_btnOpen.SubFontColor = System.Drawing.Color.DarkBlue;
            this.m_btnOpen.SubText = "STATUS";
            this.m_btnOpen.TabIndex = 0;
            this.m_btnOpen.Text = "OPEN";
            this.m_btnOpen.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.m_btnOpen.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_RIGHT;
            this.m_btnOpen.ThemeIndex = 0;
            this.m_btnOpen.UseBorder = true;
            this.m_btnOpen.UseClickedEmphasizeTextColor = false;
            this.m_btnOpen.UseCustomizeClickedColor = false;
            this.m_btnOpen.UseEdge = true;
            this.m_btnOpen.UseHoverEmphasizeCustomColor = false;
            this.m_btnOpen.UseImage = true;
            this.m_btnOpen.UserHoverEmpahsize = false;
            this.m_btnOpen.UseSubFont = true;
            this.m_btnOpen.Click += new System.EventHandler(this.Click_OpenOrClose);
            // 
            // m_btnRemove
            // 
            this.m_btnRemove.BorderWidth = 3;
            this.m_btnRemove.ButtonClicked = false;
            this.m_btnRemove.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.m_btnRemove.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.m_btnRemove.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.m_btnRemove.Description = "";
            this.m_btnRemove.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_btnRemove.EdgeRadius = 5;
            this.m_btnRemove.Enabled = false;
            this.m_btnRemove.GradientAngle = 70F;
            this.m_btnRemove.GradientFirstColor = System.Drawing.Color.White;
            this.m_btnRemove.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
            this.m_btnRemove.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.m_btnRemove.ImagePosition = new System.Drawing.Point(7, 7);
            this.m_btnRemove.ImageSize = new System.Drawing.Point(30, 30);
            this.m_btnRemove.LoadImage = global::FrameOfSystem3.Properties.Resources.REMOVE;
            this.m_btnRemove.Location = new System.Drawing.Point(431, 763);
            this.m_btnRemove.MainFont = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.m_btnRemove.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
            this.m_btnRemove.Name = "m_btnRemove";
            this.m_btnRemove.Size = new System.Drawing.Size(128, 77);
            this.m_btnRemove.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.m_btnRemove.SubFontColor = System.Drawing.Color.DarkBlue;
            this.m_btnRemove.SubText = "STATUS";
            this.m_btnRemove.TabIndex = 1;
            this.m_btnRemove.Text = "REMOVE";
            this.m_btnRemove.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.m_btnRemove.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_btnRemove.ThemeIndex = 0;
            this.m_btnRemove.UseBorder = true;
            this.m_btnRemove.UseClickedEmphasizeTextColor = false;
            this.m_btnRemove.UseCustomizeClickedColor = false;
            this.m_btnRemove.UseEdge = true;
            this.m_btnRemove.UseHoverEmphasizeCustomColor = false;
            this.m_btnRemove.UseImage = true;
            this.m_btnRemove.UserHoverEmpahsize = false;
            this.m_btnRemove.UseSubFont = false;
            this.m_btnRemove.Click += new System.EventHandler(this.Click_AddOrRemove);
            // 
            // m_btnAdd
            // 
            this.m_btnAdd.BorderWidth = 3;
            this.m_btnAdd.ButtonClicked = false;
            this.m_btnAdd.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.m_btnAdd.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.m_btnAdd.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.m_btnAdd.Description = "";
            this.m_btnAdd.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_btnAdd.EdgeRadius = 5;
            this.m_btnAdd.GradientAngle = 70F;
            this.m_btnAdd.GradientFirstColor = System.Drawing.Color.White;
            this.m_btnAdd.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
            this.m_btnAdd.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.m_btnAdd.ImagePosition = new System.Drawing.Point(7, 7);
            this.m_btnAdd.ImageSize = new System.Drawing.Point(30, 30);
            this.m_btnAdd.LoadImage = global::FrameOfSystem3.Properties.Resources.CONFIG_ADD3;
            this.m_btnAdd.Location = new System.Drawing.Point(299, 763);
            this.m_btnAdd.MainFont = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.m_btnAdd.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
            this.m_btnAdd.Name = "m_btnAdd";
            this.m_btnAdd.Size = new System.Drawing.Size(128, 77);
            this.m_btnAdd.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.m_btnAdd.SubFontColor = System.Drawing.Color.DarkBlue;
            this.m_btnAdd.SubText = "STATUS";
            this.m_btnAdd.TabIndex = 0;
            this.m_btnAdd.Text = "ADD";
            this.m_btnAdd.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.m_btnAdd.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_btnAdd.ThemeIndex = 0;
            this.m_btnAdd.UseBorder = true;
            this.m_btnAdd.UseClickedEmphasizeTextColor = false;
            this.m_btnAdd.UseCustomizeClickedColor = false;
            this.m_btnAdd.UseEdge = true;
            this.m_btnAdd.UseHoverEmphasizeCustomColor = false;
            this.m_btnAdd.UseImage = true;
            this.m_btnAdd.UserHoverEmpahsize = false;
            this.m_btnAdd.UseSubFont = false;
            this.m_btnAdd.Click += new System.EventHandler(this.Click_AddOrRemove);
            // 
            // m_btnDisable
            // 
            this.m_btnDisable.BorderWidth = 3;
            this.m_btnDisable.ButtonClicked = false;
            this.m_btnDisable.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.m_btnDisable.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.m_btnDisable.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.m_btnDisable.Description = "";
            this.m_btnDisable.DisabledColor = System.Drawing.Color.LightSlateGray;
            this.m_btnDisable.EdgeRadius = 5;
            this.m_btnDisable.Enabled = false;
            this.m_btnDisable.GradientAngle = 70F;
            this.m_btnDisable.GradientFirstColor = System.Drawing.Color.White;
            this.m_btnDisable.GradientSecondColor = System.Drawing.Color.LightSlateGray;
            this.m_btnDisable.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.m_btnDisable.ImagePosition = new System.Drawing.Point(7, 7);
            this.m_btnDisable.ImageSize = new System.Drawing.Point(30, 30);
            this.m_btnDisable.LoadImage = global::FrameOfSystem3.Properties.Resources.DISABLE_BLACK;
            this.m_btnDisable.Location = new System.Drawing.Point(140, 763);
            this.m_btnDisable.MainFont = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.m_btnDisable.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
            this.m_btnDisable.Name = "m_btnDisable";
            this.m_btnDisable.Size = new System.Drawing.Size(128, 77);
            this.m_btnDisable.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.m_btnDisable.SubFontColor = System.Drawing.Color.DarkBlue;
            this.m_btnDisable.SubText = "STATUS";
            this.m_btnDisable.TabIndex = 1;
            this.m_btnDisable.Text = "DISABLE";
            this.m_btnDisable.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.m_btnDisable.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_RIGHT;
            this.m_btnDisable.ThemeIndex = 0;
            this.m_btnDisable.UseBorder = true;
            this.m_btnDisable.UseClickedEmphasizeTextColor = false;
            this.m_btnDisable.UseCustomizeClickedColor = false;
            this.m_btnDisable.UseEdge = true;
            this.m_btnDisable.UseHoverEmphasizeCustomColor = false;
            this.m_btnDisable.UseImage = true;
            this.m_btnDisable.UserHoverEmpahsize = false;
            this.m_btnDisable.UseSubFont = true;
            this.m_btnDisable.Click += new System.EventHandler(this.Click_EnableOrDisable);
            // 
            // m_btnEnable
            // 
            this.m_btnEnable.BorderWidth = 3;
            this.m_btnEnable.ButtonClicked = false;
            this.m_btnEnable.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.m_btnEnable.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.m_btnEnable.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.m_btnEnable.Description = "";
            this.m_btnEnable.DisabledColor = System.Drawing.Color.LightSlateGray;
            this.m_btnEnable.EdgeRadius = 5;
            this.m_btnEnable.Enabled = false;
            this.m_btnEnable.GradientAngle = 70F;
            this.m_btnEnable.GradientFirstColor = System.Drawing.Color.White;
            this.m_btnEnable.GradientSecondColor = System.Drawing.Color.LightSlateGray;
            this.m_btnEnable.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.m_btnEnable.ImagePosition = new System.Drawing.Point(7, 7);
            this.m_btnEnable.ImageSize = new System.Drawing.Point(30, 30);
            this.m_btnEnable.LoadImage = global::FrameOfSystem3.Properties.Resources.ENABLE_BLACK;
            this.m_btnEnable.Location = new System.Drawing.Point(9, 763);
            this.m_btnEnable.MainFont = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.m_btnEnable.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
            this.m_btnEnable.Name = "m_btnEnable";
            this.m_btnEnable.Size = new System.Drawing.Size(128, 77);
            this.m_btnEnable.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.m_btnEnable.SubFontColor = System.Drawing.Color.DarkBlue;
            this.m_btnEnable.SubText = "STATUS";
            this.m_btnEnable.TabIndex = 0;
            this.m_btnEnable.Text = "ENABLE";
            this.m_btnEnable.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.m_btnEnable.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_RIGHT;
            this.m_btnEnable.ThemeIndex = 0;
            this.m_btnEnable.UseBorder = true;
            this.m_btnEnable.UseClickedEmphasizeTextColor = false;
            this.m_btnEnable.UseCustomizeClickedColor = false;
            this.m_btnEnable.UseEdge = true;
            this.m_btnEnable.UseHoverEmphasizeCustomColor = false;
            this.m_btnEnable.UseImage = true;
            this.m_btnEnable.UserHoverEmpahsize = false;
            this.m_btnEnable.UseSubFont = true;
            this.m_btnEnable.Click += new System.EventHandler(this.Click_EnableOrDisable);
            // 
            // m_labelLogType
            // 
            this.m_labelLogType.BackGroundColor = System.Drawing.Color.White;
            this.m_labelLogType.BorderStroke = 2;
            this.m_labelLogType.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_labelLogType.Description = "";
            this.m_labelLogType.DisabledColor = System.Drawing.Color.LightGray;
            this.m_labelLogType.EdgeRadius = 1;
            this.m_labelLogType.Enabled = false;
            this.m_labelLogType.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_labelLogType.ImageSize = new System.Drawing.Point(0, 0);
            this.m_labelLogType.LoadImage = null;
            this.m_labelLogType.Location = new System.Drawing.Point(165, 714);
            this.m_labelLogType.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_labelLogType.MainFontColor = System.Drawing.Color.Black;
            this.m_labelLogType.Name = "m_labelLogType";
            this.m_labelLogType.Size = new System.Drawing.Size(395, 43);
            this.m_labelLogType.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.m_labelLogType.SubFontColor = System.Drawing.Color.Black;
            this.m_labelLogType.SubText = "";
            this.m_labelLogType.TabIndex = 7;
            this.m_labelLogType.Text = "--";
            this.m_labelLogType.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
            this.m_labelLogType.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_labelLogType.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_labelLogType.ThemeIndex = 0;
            this.m_labelLogType.UnitAreaRate = 40;
            this.m_labelLogType.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_labelLogType.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_labelLogType.UnitPositionVertical = false;
            this.m_labelLogType.UnitText = "";
            this.m_labelLogType.UseBorder = true;
            this.m_labelLogType.UseEdgeRadius = false;
            this.m_labelLogType.UseImage = false;
            this.m_labelLogType.UseSubFont = false;
            this.m_labelLogType.UseUnitFont = false;
            this.m_labelLogType.Click += new System.EventHandler(this.Click_Configuration);
            // 
            // m_lblLogType
            // 
            this.m_lblLogType.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
            this.m_lblLogType.BorderStroke = 2;
            this.m_lblLogType.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblLogType.Description = "";
            this.m_lblLogType.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblLogType.EdgeRadius = 1;
            this.m_lblLogType.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_lblLogType.ImageSize = new System.Drawing.Point(0, 0);
            this.m_lblLogType.LoadImage = null;
            this.m_lblLogType.Location = new System.Drawing.Point(9, 714);
            this.m_lblLogType.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.m_lblLogType.MainFontColor = System.Drawing.Color.Black;
            this.m_lblLogType.Name = "m_lblLogType";
            this.m_lblLogType.Size = new System.Drawing.Size(155, 43);
            this.m_lblLogType.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.m_lblLogType.SubFontColor = System.Drawing.Color.Black;
            this.m_lblLogType.SubText = "";
            this.m_lblLogType.TabIndex = 1388;
            this.m_lblLogType.Text = "LOG TYPE";
            this.m_lblLogType.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblLogType.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblLogType.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblLogType.ThemeIndex = 0;
            this.m_lblLogType.UnitAreaRate = 40;
            this.m_lblLogType.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblLogType.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblLogType.UnitPositionVertical = false;
            this.m_lblLogType.UnitText = "";
            this.m_lblLogType.UseBorder = true;
            this.m_lblLogType.UseEdgeRadius = false;
            this.m_lblLogType.UseImage = false;
            this.m_lblLogType.UseSubFont = false;
            this.m_lblLogType.UseUnitFont = false;
            // 
            // m_labelReceiveStart
            // 
            this.m_labelReceiveStart.BackGroundColor = System.Drawing.Color.White;
            this.m_labelReceiveStart.BorderStroke = 2;
            this.m_labelReceiveStart.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_labelReceiveStart.Description = "";
            this.m_labelReceiveStart.DisabledColor = System.Drawing.Color.LightGray;
            this.m_labelReceiveStart.EdgeRadius = 1;
            this.m_labelReceiveStart.Enabled = false;
            this.m_labelReceiveStart.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_labelReceiveStart.ImageSize = new System.Drawing.Point(0, 0);
            this.m_labelReceiveStart.LoadImage = null;
            this.m_labelReceiveStart.Location = new System.Drawing.Point(734, 289);
            this.m_labelReceiveStart.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_labelReceiveStart.MainFontColor = System.Drawing.Color.Black;
            this.m_labelReceiveStart.Name = "m_labelReceiveStart";
            this.m_labelReceiveStart.Size = new System.Drawing.Size(402, 39);
            this.m_labelReceiveStart.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.m_labelReceiveStart.SubFontColor = System.Drawing.Color.Black;
            this.m_labelReceiveStart.SubText = "";
            this.m_labelReceiveStart.TabIndex = 1393;
            this.m_labelReceiveStart.Text = "--";
            this.m_labelReceiveStart.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
            this.m_labelReceiveStart.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_labelReceiveStart.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_labelReceiveStart.ThemeIndex = 0;
            this.m_labelReceiveStart.UnitAreaRate = 40;
            this.m_labelReceiveStart.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_labelReceiveStart.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_labelReceiveStart.UnitPositionVertical = false;
            this.m_labelReceiveStart.UnitText = "";
            this.m_labelReceiveStart.UseBorder = true;
            this.m_labelReceiveStart.UseEdgeRadius = false;
            this.m_labelReceiveStart.UseImage = false;
            this.m_labelReceiveStart.UseSubFont = false;
            this.m_labelReceiveStart.UseUnitFont = false;
            this.m_labelReceiveStart.Click += new System.EventHandler(this.Click_TokenSetting);
            // 
            // m_labelSendStart
            // 
            this.m_labelSendStart.BackGroundColor = System.Drawing.Color.White;
            this.m_labelSendStart.BorderStroke = 2;
            this.m_labelSendStart.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_labelSendStart.Description = "";
            this.m_labelSendStart.DisabledColor = System.Drawing.Color.LightGray;
            this.m_labelSendStart.EdgeRadius = 1;
            this.m_labelSendStart.Enabled = false;
            this.m_labelSendStart.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_labelSendStart.ImageSize = new System.Drawing.Point(0, 0);
            this.m_labelSendStart.LoadImage = null;
            this.m_labelSendStart.Location = new System.Drawing.Point(168, 290);
            this.m_labelSendStart.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_labelSendStart.MainFontColor = System.Drawing.Color.Black;
            this.m_labelSendStart.Name = "m_labelSendStart";
            this.m_labelSendStart.Size = new System.Drawing.Size(400, 39);
            this.m_labelSendStart.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.m_labelSendStart.SubFontColor = System.Drawing.Color.Black;
            this.m_labelSendStart.SubText = "";
            this.m_labelSendStart.TabIndex = 1392;
            this.m_labelSendStart.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_labelSendStart.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_labelSendStart.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_labelSendStart.ThemeIndex = 0;
            this.m_labelSendStart.UnitAreaRate = 40;
            this.m_labelSendStart.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_labelSendStart.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_labelSendStart.UnitPositionVertical = false;
            this.m_labelSendStart.UnitText = "";
            this.m_labelSendStart.UseBorder = true;
            this.m_labelSendStart.UseEdgeRadius = false;
            this.m_labelSendStart.UseImage = false;
            this.m_labelSendStart.UseSubFont = false;
            this.m_labelSendStart.UseUnitFont = false;
            this.m_labelSendStart.Click += new System.EventHandler(this.Click_TokenSetting);
            // 
            // sys3Label3
            // 
            this.sys3Label3.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
            this.sys3Label3.BorderStroke = 2;
            this.sys3Label3.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.sys3Label3.Description = "";
            this.sys3Label3.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3Label3.EdgeRadius = 1;
            this.sys3Label3.ImagePosition = new System.Drawing.Point(0, 0);
            this.sys3Label3.ImageSize = new System.Drawing.Point(0, 0);
            this.sys3Label3.LoadImage = null;
            this.sys3Label3.Location = new System.Drawing.Point(574, 289);
            this.sys3Label3.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.sys3Label3.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label3.Name = "sys3Label3";
            this.sys3Label3.Size = new System.Drawing.Size(159, 40);
            this.sys3Label3.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.sys3Label3.SubFontColor = System.Drawing.Color.Black;
            this.sys3Label3.SubText = "";
            this.sys3Label3.TabIndex = 1391;
            this.sys3Label3.Text = "RECEIVE START";
            this.sys3Label3.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.sys3Label3.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
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
            this.sys3Label3.UseSubFont = false;
            this.sys3Label3.UseUnitFont = false;
            // 
            // sys3Label4
            // 
            this.sys3Label4.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
            this.sys3Label4.BorderStroke = 2;
            this.sys3Label4.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.sys3Label4.Description = "";
            this.sys3Label4.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3Label4.EdgeRadius = 1;
            this.sys3Label4.ImagePosition = new System.Drawing.Point(0, 0);
            this.sys3Label4.ImageSize = new System.Drawing.Point(0, 0);
            this.sys3Label4.LoadImage = null;
            this.sys3Label4.Location = new System.Drawing.Point(11, 289);
            this.sys3Label4.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.sys3Label4.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label4.Name = "sys3Label4";
            this.sys3Label4.Size = new System.Drawing.Size(155, 40);
            this.sys3Label4.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.sys3Label4.SubFontColor = System.Drawing.Color.Black;
            this.sys3Label4.SubText = "";
            this.sys3Label4.TabIndex = 1390;
            this.sys3Label4.Text = "SEND START";
            this.sys3Label4.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.sys3Label4.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
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
            this.sys3Label4.UseSubFont = false;
            this.sys3Label4.UseUnitFont = false;
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
            this.sys3GroupBox1.Location = new System.Drawing.Point(2, 252);
            this.sys3GroupBox1.Name = "sys3GroupBox1";
            this.sys3GroupBox1.Size = new System.Drawing.Size(1140, 134);
            this.sys3GroupBox1.TabIndex = 1389;
            this.sys3GroupBox1.Text = "TOKEN ITEM";
            this.sys3GroupBox1.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3GroupBox1.ThemeIndex = 0;
            this.sys3GroupBox1.UseLabelBorder = true;
            // 
            // m_labelReceiveEnd
            // 
            this.m_labelReceiveEnd.BackGroundColor = System.Drawing.Color.White;
            this.m_labelReceiveEnd.BorderStroke = 2;
            this.m_labelReceiveEnd.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_labelReceiveEnd.Description = "";
            this.m_labelReceiveEnd.DisabledColor = System.Drawing.Color.LightGray;
            this.m_labelReceiveEnd.EdgeRadius = 1;
            this.m_labelReceiveEnd.Enabled = false;
            this.m_labelReceiveEnd.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_labelReceiveEnd.ImageSize = new System.Drawing.Point(0, 0);
            this.m_labelReceiveEnd.LoadImage = null;
            this.m_labelReceiveEnd.Location = new System.Drawing.Point(734, 334);
            this.m_labelReceiveEnd.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_labelReceiveEnd.MainFontColor = System.Drawing.Color.Black;
            this.m_labelReceiveEnd.Name = "m_labelReceiveEnd";
            this.m_labelReceiveEnd.Size = new System.Drawing.Size(402, 39);
            this.m_labelReceiveEnd.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.m_labelReceiveEnd.SubFontColor = System.Drawing.Color.Black;
            this.m_labelReceiveEnd.SubText = "";
            this.m_labelReceiveEnd.TabIndex = 1397;
            this.m_labelReceiveEnd.Text = "--";
            this.m_labelReceiveEnd.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
            this.m_labelReceiveEnd.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_labelReceiveEnd.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_labelReceiveEnd.ThemeIndex = 0;
            this.m_labelReceiveEnd.UnitAreaRate = 40;
            this.m_labelReceiveEnd.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_labelReceiveEnd.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_labelReceiveEnd.UnitPositionVertical = false;
            this.m_labelReceiveEnd.UnitText = "";
            this.m_labelReceiveEnd.UseBorder = true;
            this.m_labelReceiveEnd.UseEdgeRadius = false;
            this.m_labelReceiveEnd.UseImage = false;
            this.m_labelReceiveEnd.UseSubFont = false;
            this.m_labelReceiveEnd.UseUnitFont = false;
            this.m_labelReceiveEnd.Click += new System.EventHandler(this.Click_TokenSetting);
            // 
            // m_labelSendEnd
            // 
            this.m_labelSendEnd.BackGroundColor = System.Drawing.Color.White;
            this.m_labelSendEnd.BorderStroke = 2;
            this.m_labelSendEnd.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_labelSendEnd.Description = "";
            this.m_labelSendEnd.DisabledColor = System.Drawing.Color.LightGray;
            this.m_labelSendEnd.EdgeRadius = 1;
            this.m_labelSendEnd.Enabled = false;
            this.m_labelSendEnd.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_labelSendEnd.ImageSize = new System.Drawing.Point(0, 0);
            this.m_labelSendEnd.LoadImage = null;
            this.m_labelSendEnd.Location = new System.Drawing.Point(167, 334);
            this.m_labelSendEnd.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_labelSendEnd.MainFontColor = System.Drawing.Color.Black;
            this.m_labelSendEnd.Name = "m_labelSendEnd";
            this.m_labelSendEnd.Size = new System.Drawing.Size(400, 39);
            this.m_labelSendEnd.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.m_labelSendEnd.SubFontColor = System.Drawing.Color.Black;
            this.m_labelSendEnd.SubText = "";
            this.m_labelSendEnd.TabIndex = 1396;
            this.m_labelSendEnd.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_labelSendEnd.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_labelSendEnd.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_labelSendEnd.ThemeIndex = 0;
            this.m_labelSendEnd.UnitAreaRate = 40;
            this.m_labelSendEnd.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_labelSendEnd.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_labelSendEnd.UnitPositionVertical = false;
            this.m_labelSendEnd.UnitText = "";
            this.m_labelSendEnd.UseBorder = true;
            this.m_labelSendEnd.UseEdgeRadius = false;
            this.m_labelSendEnd.UseImage = false;
            this.m_labelSendEnd.UseSubFont = false;
            this.m_labelSendEnd.UseUnitFont = false;
            this.m_labelSendEnd.Click += new System.EventHandler(this.Click_TokenSetting);
            // 
            // sys3Label7
            // 
            this.sys3Label7.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
            this.sys3Label7.BorderStroke = 2;
            this.sys3Label7.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.sys3Label7.Description = "";
            this.sys3Label7.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3Label7.EdgeRadius = 1;
            this.sys3Label7.ImagePosition = new System.Drawing.Point(0, 0);
            this.sys3Label7.ImageSize = new System.Drawing.Point(0, 0);
            this.sys3Label7.LoadImage = null;
            this.sys3Label7.Location = new System.Drawing.Point(574, 334);
            this.sys3Label7.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.sys3Label7.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label7.Name = "sys3Label7";
            this.sys3Label7.Size = new System.Drawing.Size(159, 40);
            this.sys3Label7.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.sys3Label7.SubFontColor = System.Drawing.Color.Black;
            this.sys3Label7.SubText = "";
            this.sys3Label7.TabIndex = 1395;
            this.sys3Label7.Text = "RECEIVE END";
            this.sys3Label7.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.sys3Label7.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
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
            this.sys3Label7.UseSubFont = false;
            this.sys3Label7.UseUnitFont = false;
            // 
            // sys3Label8
            // 
            this.sys3Label8.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
            this.sys3Label8.BorderStroke = 2;
            this.sys3Label8.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.sys3Label8.Description = "";
            this.sys3Label8.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3Label8.EdgeRadius = 1;
            this.sys3Label8.ImagePosition = new System.Drawing.Point(0, 0);
            this.sys3Label8.ImageSize = new System.Drawing.Point(0, 0);
            this.sys3Label8.LoadImage = null;
            this.sys3Label8.Location = new System.Drawing.Point(11, 334);
            this.sys3Label8.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.sys3Label8.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label8.Name = "sys3Label8";
            this.sys3Label8.Size = new System.Drawing.Size(155, 40);
            this.sys3Label8.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.sys3Label8.SubFontColor = System.Drawing.Color.Black;
            this.sys3Label8.SubText = "";
            this.sys3Label8.TabIndex = 1394;
            this.sys3Label8.Text = "SEND END";
            this.sys3Label8.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.sys3Label8.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label8.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label8.ThemeIndex = 0;
            this.sys3Label8.UnitAreaRate = 40;
            this.sys3Label8.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label8.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sys3Label8.UnitPositionVertical = false;
            this.sys3Label8.UnitText = "";
            this.sys3Label8.UseBorder = true;
            this.sys3Label8.UseEdgeRadius = false;
            this.sys3Label8.UseImage = false;
            this.sys3Label8.UseSubFont = false;
            this.sys3Label8.UseUnitFont = false;
            // 
            // Config_Serial
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_labelReceiveEnd);
            this.Controls.Add(this.m_labelSendEnd);
            this.Controls.Add(this.sys3Label7);
            this.Controls.Add(this.sys3Label8);
            this.Controls.Add(this.m_labelReceiveStart);
            this.Controls.Add(this.m_labelSendStart);
            this.Controls.Add(this.sys3Label3);
            this.Controls.Add(this.sys3Label4);
            this.Controls.Add(this.sys3GroupBox1);
            this.Controls.Add(this.m_labelLogType);
            this.Controls.Add(this.m_lblLogType);
            this.Controls.Add(this.m_btnSend);
            this.Controls.Add(this.m_btnClearMessage);
            this.Controls.Add(this.m_btnClose);
            this.Controls.Add(this.m_btnOpen);
            this.Controls.Add(this.m_labelMessage);
            this.Controls.Add(this.m_lblMessage);
            this.Controls.Add(this.m_btnRemove);
            this.Controls.Add(this.m_btnAdd);
            this.Controls.Add(this.m_btnDisable);
            this.Controls.Add(this.m_btnEnable);
            this.Controls.Add(this.m_labelState);
            this.Controls.Add(this.m_labelIndex);
            this.Controls.Add(this.m_labelStopBit);
            this.Controls.Add(this.m_labelParityBit);
            this.Controls.Add(this.m_labelReceiveTimeout);
            this.Controls.Add(this.m_labelBaudRate);
            this.Controls.Add(this.m_labelDataBit);
            this.Controls.Add(this.m_labelName);
            this.Controls.Add(this.m_labelPortName);
            this.Controls.Add(this.m_lblState);
            this.Controls.Add(this.m_lblIndex);
            this.Controls.Add(this.m_lblPortName);
            this.Controls.Add(this.m_lblReceiveTimeout);
            this.Controls.Add(this.m_lblParityBit);
            this.Controls.Add(this.m_lblStopBit);
            this.Controls.Add(this.m_lblBaudRate);
            this.Controls.Add(this.m_lblDataBit);
            this.Controls.Add(this.m_lblName);
            this.Controls.Add(this.m_listMessage);
            this.Controls.Add(this.m_dgViewSerial);
            this.Controls.Add(this.m_groupList);
            this.Controls.Add(this.m_groupSelectedItem);
            this.Controls.Add(this.m_groupConfiguration);
            this.Controls.Add(this.m_groupSerialDemonstration);
            this.Name = "Config_Serial";
            this.Size = new System.Drawing.Size(1140, 850);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgViewSerial)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

		private System.Windows.Forms.ListBox m_listMessage;
		private Sys3Controls.Sys3DoubleBufferedDataGridView m_dgViewSerial;
		private System.Windows.Forms.DataGridViewTextBoxColumn ID;
		private System.Windows.Forms.DataGridViewTextBoxColumn ENABLE;
		private System.Windows.Forms.DataGridViewTextBoxColumn NAME;
		private System.Windows.Forms.DataGridViewTextBoxColumn PASSWORD;
		private System.Windows.Forms.DataGridViewTextBoxColumn MONITORING;
		private System.Windows.Forms.DataGridViewTextBoxColumn TARGETPORT;
		private System.Windows.Forms.DataGridViewTextBoxColumn CONDITION;
		private System.Windows.Forms.DataGridViewTextBoxColumn AUTHORITY;
		private System.Windows.Forms.DataGridViewTextBoxColumn STATE;
		private Sys3Controls.Sys3GroupBox m_groupList;
		private Sys3Controls.Sys3GroupBox m_groupSelectedItem;
		private Sys3Controls.Sys3GroupBox m_groupConfiguration;
		private Sys3Controls.Sys3GroupBox m_groupSerialDemonstration;
		private Sys3Controls.Sys3Label m_lblName;
		private Sys3Controls.Sys3Label m_lblDataBit;
		private Sys3Controls.Sys3Label m_lblBaudRate;
		private Sys3Controls.Sys3Label m_lblStopBit;
		private Sys3Controls.Sys3Label m_lblParityBit;
		private Sys3Controls.Sys3Label m_lblReceiveTimeout;
		private Sys3Controls.Sys3Label m_lblPortName;
		private Sys3Controls.Sys3Label m_lblIndex;
		private Sys3Controls.Sys3Label m_lblState;
		private Sys3Controls.Sys3Label m_labelPortName;
		private Sys3Controls.Sys3Label m_labelName;
		private Sys3Controls.Sys3Label m_labelDataBit;
		private Sys3Controls.Sys3Label m_labelBaudRate;
		private Sys3Controls.Sys3Label m_labelReceiveTimeout;
		private Sys3Controls.Sys3Label m_labelParityBit;
		private Sys3Controls.Sys3Label m_labelStopBit;
		private Sys3Controls.Sys3Label m_labelIndex;
		private Sys3Controls.Sys3Label m_labelState;
		private Sys3Controls.Sys3button m_btnDisable;
		private Sys3Controls.Sys3button m_btnEnable;
		private Sys3Controls.Sys3button m_btnRemove;
		private Sys3Controls.Sys3button m_btnAdd;
		private Sys3Controls.Sys3Label m_labelMessage;
		private Sys3Controls.Sys3Label m_lblMessage;
		private Sys3Controls.Sys3button m_btnOpen;
		private Sys3Controls.Sys3button m_btnClose;
		private Sys3Controls.Sys3button m_btnClearMessage;
		private Sys3Controls.Sys3button m_btnSend;
        private Sys3Controls.Sys3Label m_labelLogType;
        private Sys3Controls.Sys3Label m_lblLogType;
        private Sys3Controls.Sys3Label m_labelReceiveStart;
        private Sys3Controls.Sys3Label m_labelSendStart;
        private Sys3Controls.Sys3Label sys3Label3;
        private Sys3Controls.Sys3Label sys3Label4;
        private Sys3Controls.Sys3GroupBox sys3GroupBox1;
        private Sys3Controls.Sys3Label m_labelReceiveEnd;
        private Sys3Controls.Sys3Label m_labelSendEnd;
        private Sys3Controls.Sys3Label sys3Label7;
        private Sys3Controls.Sys3Label sys3Label8;
    }
}
