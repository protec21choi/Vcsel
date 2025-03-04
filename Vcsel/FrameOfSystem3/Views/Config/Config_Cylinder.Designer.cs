namespace FrameOfSystem3.Views.Config
{
    partial class Config_Cylinder
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
			this.m_ledRepeat = new Sys3Controls.Sys3LedLabel();
			this.m_dgViewCylinder = new Sys3Controls.Sys3DoubleBufferedDataGridView();
			this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.PASSWORD = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.MONITORING = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.AUTHORITY = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.CONDITION = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.BLINK = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Led = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.STATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.BWOUT = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.m_labelMonitoring = new Sys3Controls.Sys3Label();
			this.m_labelState = new Sys3Controls.Sys3Label();
			this.m_labelTimeout = new Sys3Controls.Sys3Label();
			this.m_labelDelay = new Sys3Controls.Sys3Label();
			this.m_labelName = new Sys3Controls.Sys3Label();
			this.m_labelKey = new Sys3Controls.Sys3Label();
			this.m_groupList = new Sys3Controls.Sys3GroupBox();
			this.m_groupConfiguration = new Sys3Controls.Sys3GroupBox();
			this.m_lblState = new Sys3Controls.Sys3Label();
			this.m_lblMonitoring = new Sys3Controls.Sys3Label();
			this.m_lblDelay = new Sys3Controls.Sys3Label();
			this.m_lblName = new Sys3Controls.Sys3Label();
			this.m_lblKey = new Sys3Controls.Sys3Label();
			this.m_lblTimeout = new Sys3Controls.Sys3Label();
			this.m_btnDisable = new Sys3Controls.Sys3button();
			this.m_btnEnable = new Sys3Controls.Sys3button();
			this.m_btnBackward = new Sys3Controls.Sys3button();
			this.m_btnForward = new Sys3Controls.Sys3button();
			this.m_btnRepeat = new Sys3Controls.Sys3button();
			this.m_btnRemove = new Sys3Controls.Sys3button();
			this.m_btnAdd = new Sys3Controls.Sys3button();
			this.m_dgViewINPUT = new Sys3Controls.Sys3DoubleBufferedDataGridView();
			this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.sys3GroupBox1 = new Sys3Controls.Sys3GroupBox();
			this.m_tabBackward = new Sys3Controls.Sys3button();
			this.m_tabForward = new Sys3Controls.Sys3button();
			this.m_dgViewOutput = new Sys3Controls.Sys3DoubleBufferedDataGridView();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.m_btnAddInput = new Sys3Controls.Sys3button();
			this.m_btnAddOutput = new Sys3Controls.Sys3button();
			this.sys3GroupBox2 = new Sys3Controls.Sys3GroupBox();
			((System.ComponentModel.ISupportInitialize)(this.m_dgViewCylinder)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.m_dgViewINPUT)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.m_dgViewOutput)).BeginInit();
			this.SuspendLayout();
			// 
			// m_ledRepeat
			// 
			this.m_ledRepeat.Active = false;
			this.m_ledRepeat.ColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(216)))), ((int)(((byte)(101)))));
			this.m_ledRepeat.ColorNormal = System.Drawing.Color.DimGray;
			this.m_ledRepeat.Location = new System.Drawing.Point(726, 813);
			this.m_ledRepeat.Name = "m_ledRepeat";
			this.m_ledRepeat.Size = new System.Drawing.Size(20, 77);
			this.m_ledRepeat.TabIndex = 1195;
			// 
			// m_dgViewCylinder
			// 
			this.m_dgViewCylinder.AllowUserToAddRows = false;
			this.m_dgViewCylinder.AllowUserToDeleteRows = false;
			this.m_dgViewCylinder.AllowUserToResizeColumns = false;
			this.m_dgViewCylinder.AllowUserToResizeRows = false;
			this.m_dgViewCylinder.BackgroundColor = System.Drawing.Color.White;
			this.m_dgViewCylinder.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
			this.m_dgViewCylinder.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.m_dgViewCylinder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.m_dgViewCylinder.ColumnHeadersHeight = 30;
			this.m_dgViewCylinder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.m_dgViewCylinder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.PASSWORD,
            this.MONITORING,
            this.AUTHORITY,
            this.CONDITION,
            this.Column2,
            this.BLINK,
            this.Led,
            this.STATE,
            this.Column1,
            this.BWOUT,
            this.Column3});
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.m_dgViewCylinder.DefaultCellStyle = dataGridViewCellStyle2;
			this.m_dgViewCylinder.EnableHeadersVisualStyles = false;
			this.m_dgViewCylinder.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
			this.m_dgViewCylinder.Location = new System.Drawing.Point(2, 31);
			this.m_dgViewCylinder.MultiSelect = false;
			this.m_dgViewCylinder.Name = "m_dgViewCylinder";
			this.m_dgViewCylinder.ReadOnly = true;
			this.m_dgViewCylinder.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("맑은 고딕", 11F);
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.m_dgViewCylinder.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.m_dgViewCylinder.RowHeadersVisible = false;
			this.m_dgViewCylinder.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.m_dgViewCylinder.RowTemplate.Height = 23;
			this.m_dgViewCylinder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.m_dgViewCylinder.Size = new System.Drawing.Size(1135, 384);
			this.m_dgViewCylinder.TabIndex = 1179;
			this.m_dgViewCylinder.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Click_Item);
			this.m_dgViewCylinder.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Click_Item);
			// 
			// ID
			// 
			this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.ID.Frozen = true;
			this.ID.HeaderText = "INDEX";
			this.ID.MaxInputLength = 20;
			this.ID.Name = "ID";
			this.ID.ReadOnly = true;
			this.ID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.ID.Width = 60;
			// 
			// PASSWORD
			// 
			this.PASSWORD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.PASSWORD.HeaderText = "NAME";
			this.PASSWORD.MaxInputLength = 20;
			this.PASSWORD.Name = "PASSWORD";
			this.PASSWORD.ReadOnly = true;
			this.PASSWORD.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.PASSWORD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// MONITORING
			// 
			this.MONITORING.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.MONITORING.HeaderText = "MONITORING MODE";
			this.MONITORING.Name = "MONITORING";
			this.MONITORING.ReadOnly = true;
			this.MONITORING.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.MONITORING.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.MONITORING.Width = 166;
			// 
			// AUTHORITY
			// 
			this.AUTHORITY.HeaderText = "STATE";
			this.AUTHORITY.MaxInputLength = 20;
			this.AUTHORITY.Name = "AUTHORITY";
			this.AUTHORITY.ReadOnly = true;
			this.AUTHORITY.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.AUTHORITY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.AUTHORITY.Width = 180;
			// 
			// CONDITION
			// 
			this.CONDITION.HeaderText = "FW IN";
			this.CONDITION.Name = "CONDITION";
			this.CONDITION.ReadOnly = true;
			this.CONDITION.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.CONDITION.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.CONDITION.Width = 76;
			// 
			// Column2
			// 
			this.Column2.HeaderText = "";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Column2.Width = 30;
			// 
			// BLINK
			// 
			this.BLINK.HeaderText = "FW OUT";
			this.BLINK.Name = "BLINK";
			this.BLINK.ReadOnly = true;
			this.BLINK.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.BLINK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.BLINK.Width = 76;
			// 
			// Led
			// 
			this.Led.HeaderText = "";
			this.Led.Name = "Led";
			this.Led.ReadOnly = true;
			this.Led.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.Led.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Led.Width = 30;
			// 
			// STATE
			// 
			this.STATE.HeaderText = "BW IN";
			this.STATE.Name = "STATE";
			this.STATE.ReadOnly = true;
			this.STATE.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.STATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.STATE.Width = 76;
			// 
			// Column1
			// 
			this.Column1.HeaderText = "";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Column1.Width = 30;
			// 
			// BWOUT
			// 
			this.BWOUT.HeaderText = "BW OUT";
			this.BWOUT.Name = "BWOUT";
			this.BWOUT.ReadOnly = true;
			this.BWOUT.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.BWOUT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.BWOUT.Width = 76;
			// 
			// Column3
			// 
			this.Column3.HeaderText = "";
			this.Column3.Name = "Column3";
			this.Column3.ReadOnly = true;
			this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Column3.Width = 30;
			// 
			// m_labelMonitoring
			// 
			this.m_labelMonitoring.BackGroundColor = System.Drawing.Color.White;
			this.m_labelMonitoring.BorderStroke = 2;
			this.m_labelMonitoring.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelMonitoring.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelMonitoring.EdgeRadius = 1;
			this.m_labelMonitoring.Enabled = false;
			this.m_labelMonitoring.Location = new System.Drawing.Point(853, 496);
			this.m_labelMonitoring.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelMonitoring.MainFontColor = System.Drawing.Color.Black;
			this.m_labelMonitoring.Name = "m_labelMonitoring";
			this.m_labelMonitoring.Size = new System.Drawing.Size(279, 39);
			this.m_labelMonitoring.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_labelMonitoring.SubFontColor = System.Drawing.Color.Black;
			this.m_labelMonitoring.SubText = "";
			this.m_labelMonitoring.TabIndex = 0;
			this.m_labelMonitoring.Text = "--";
			this.m_labelMonitoring.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelMonitoring.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelMonitoring.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelMonitoring.UnitAreaRate = 40;
			this.m_labelMonitoring.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelMonitoring.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_labelMonitoring.UnitPositionVertical = false;
			this.m_labelMonitoring.UnitText = "";
			this.m_labelMonitoring.UseBorder = true;
			this.m_labelMonitoring.UseEdgeRadius = false;
			this.m_labelMonitoring.UseSubFont = false;
			this.m_labelMonitoring.UseUnitFont = false;
			this.m_labelMonitoring.Click += new System.EventHandler(this.Click_Monitoring);
			// 
			// m_labelState
			// 
			this.m_labelState.BackGroundColor = System.Drawing.Color.White;
			this.m_labelState.BorderStroke = 2;
			this.m_labelState.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelState.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelState.EdgeRadius = 1;
			this.m_labelState.Enabled = false;
			this.m_labelState.Location = new System.Drawing.Point(447, 496);
			this.m_labelState.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelState.MainFontColor = System.Drawing.Color.Black;
			this.m_labelState.Name = "m_labelState";
			this.m_labelState.Size = new System.Drawing.Size(248, 39);
			this.m_labelState.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_labelState.SubFontColor = System.Drawing.Color.Black;
			this.m_labelState.SubText = "";
			this.m_labelState.TabIndex = 1355;
			this.m_labelState.Text = "--";
			this.m_labelState.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelState.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelState.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelState.UnitAreaRate = 40;
			this.m_labelState.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelState.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_labelState.UnitPositionVertical = false;
			this.m_labelState.UnitText = "";
			this.m_labelState.UseBorder = true;
			this.m_labelState.UseEdgeRadius = false;
			this.m_labelState.UseSubFont = false;
			this.m_labelState.UseUnitFont = false;
			// 
			// m_labelTimeout
			// 
			this.m_labelTimeout.BackGroundColor = System.Drawing.Color.White;
			this.m_labelTimeout.BorderStroke = 2;
			this.m_labelTimeout.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelTimeout.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelTimeout.EdgeRadius = 1;
			this.m_labelTimeout.Enabled = false;
			this.m_labelTimeout.Location = new System.Drawing.Point(729, 745);
			this.m_labelTimeout.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelTimeout.MainFontColor = System.Drawing.Color.Black;
			this.m_labelTimeout.Name = "m_labelTimeout";
			this.m_labelTimeout.Size = new System.Drawing.Size(404, 39);
			this.m_labelTimeout.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_labelTimeout.SubFontColor = System.Drawing.Color.Black;
			this.m_labelTimeout.SubText = "";
			this.m_labelTimeout.TabIndex = 1;
			this.m_labelTimeout.Text = "--";
			this.m_labelTimeout.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelTimeout.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelTimeout.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelTimeout.UnitAreaRate = 10;
			this.m_labelTimeout.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelTimeout.UnitFontColor = System.Drawing.Color.Black;
			this.m_labelTimeout.UnitPositionVertical = false;
			this.m_labelTimeout.UnitText = "ms";
			this.m_labelTimeout.UseBorder = true;
			this.m_labelTimeout.UseEdgeRadius = false;
			this.m_labelTimeout.UseSubFont = false;
			this.m_labelTimeout.UseUnitFont = true;
			this.m_labelTimeout.Click += new System.EventHandler(this.Click_ValueOfNumber);
			// 
			// m_labelDelay
			// 
			this.m_labelDelay.BackGroundColor = System.Drawing.Color.White;
			this.m_labelDelay.BorderStroke = 2;
			this.m_labelDelay.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelDelay.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelDelay.EdgeRadius = 1;
			this.m_labelDelay.Enabled = false;
			this.m_labelDelay.Location = new System.Drawing.Point(163, 745);
			this.m_labelDelay.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelDelay.MainFontColor = System.Drawing.Color.Black;
			this.m_labelDelay.Name = "m_labelDelay";
			this.m_labelDelay.Size = new System.Drawing.Size(404, 39);
			this.m_labelDelay.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_labelDelay.SubFontColor = System.Drawing.Color.Black;
			this.m_labelDelay.SubText = "";
			this.m_labelDelay.TabIndex = 0;
			this.m_labelDelay.Text = "--";
			this.m_labelDelay.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelDelay.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelDelay.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelDelay.UnitAreaRate = 10;
			this.m_labelDelay.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelDelay.UnitFontColor = System.Drawing.Color.Black;
			this.m_labelDelay.UnitPositionVertical = false;
			this.m_labelDelay.UnitText = "ms";
			this.m_labelDelay.UseBorder = true;
			this.m_labelDelay.UseEdgeRadius = false;
			this.m_labelDelay.UseSubFont = false;
			this.m_labelDelay.UseUnitFont = true;
			this.m_labelDelay.Click += new System.EventHandler(this.Click_ValueOfNumber);
			// 
			// m_labelName
			// 
			this.m_labelName.BackGroundColor = System.Drawing.Color.White;
			this.m_labelName.BorderStroke = 2;
			this.m_labelName.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelName.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelName.EdgeRadius = 1;
			this.m_labelName.Enabled = false;
			this.m_labelName.Location = new System.Drawing.Point(697, 451);
			this.m_labelName.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelName.MainFontColor = System.Drawing.Color.Black;
			this.m_labelName.Name = "m_labelName";
			this.m_labelName.Size = new System.Drawing.Size(436, 39);
			this.m_labelName.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_labelName.SubFontColor = System.Drawing.Color.Black;
			this.m_labelName.SubText = "";
			this.m_labelName.TabIndex = 1354;
			this.m_labelName.Text = "--";
			this.m_labelName.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
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
			this.m_labelName.Click += new System.EventHandler(this.Click_ValueOfCharacter);
			// 
			// m_labelKey
			// 
			this.m_labelKey.BackGroundColor = System.Drawing.Color.White;
			this.m_labelKey.BorderStroke = 2;
			this.m_labelKey.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelKey.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelKey.EdgeRadius = 1;
			this.m_labelKey.Enabled = false;
			this.m_labelKey.Location = new System.Drawing.Point(447, 451);
			this.m_labelKey.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelKey.MainFontColor = System.Drawing.Color.Black;
			this.m_labelKey.Name = "m_labelKey";
			this.m_labelKey.Size = new System.Drawing.Size(87, 39);
			this.m_labelKey.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_labelKey.SubFontColor = System.Drawing.Color.Black;
			this.m_labelKey.SubText = "";
			this.m_labelKey.TabIndex = 1353;
			this.m_labelKey.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelKey.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelKey.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelKey.UnitAreaRate = 40;
			this.m_labelKey.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelKey.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_labelKey.UnitPositionVertical = false;
			this.m_labelKey.UnitText = "";
			this.m_labelKey.UseBorder = true;
			this.m_labelKey.UseEdgeRadius = false;
			this.m_labelKey.UseSubFont = false;
			this.m_labelKey.UseUnitFont = false;
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
			this.m_groupList.Size = new System.Drawing.Size(1140, 415);
			this.m_groupList.TabIndex = 1349;
			this.m_groupList.Text = "CYLINDER LIST";
			this.m_groupList.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_groupList.UseLabelBorder = true;
			// 
			// m_groupConfiguration
			// 
			this.m_groupConfiguration.BackGroundColor = System.Drawing.Color.WhiteSmoke;
			this.m_groupConfiguration.EdgeBorderStroke = 2;
			this.m_groupConfiguration.EdgeRadius = 2;
			this.m_groupConfiguration.LabelFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_groupConfiguration.LabelGradientColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
			this.m_groupConfiguration.LabelGradientColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.m_groupConfiguration.LabelHeight = 32;
			this.m_groupConfiguration.LabelTextColor = System.Drawing.Color.Black;
			this.m_groupConfiguration.Location = new System.Drawing.Point(0, 414);
			this.m_groupConfiguration.Name = "m_groupConfiguration";
			this.m_groupConfiguration.Size = new System.Drawing.Size(1140, 486);
			this.m_groupConfiguration.TabIndex = 1351;
			this.m_groupConfiguration.Text = "CONFIGURATION";
			this.m_groupConfiguration.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_groupConfiguration.UseLabelBorder = true;
			// 
			// m_lblState
			// 
			this.m_lblState.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_lblState.BorderStroke = 2;
			this.m_lblState.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_lblState.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_lblState.EdgeRadius = 1;
			this.m_lblState.Location = new System.Drawing.Point(291, 496);
			this.m_lblState.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblState.MainFontColor = System.Drawing.Color.Black;
			this.m_lblState.Name = "m_lblState";
			this.m_lblState.Size = new System.Drawing.Size(155, 39);
			this.m_lblState.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_lblState.SubFontColor = System.Drawing.Color.Black;
			this.m_lblState.SubText = "";
			this.m_lblState.TabIndex = 1361;
			this.m_lblState.Text = "CYLINDER STATE";
			this.m_lblState.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_lblState.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblState.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblState.UnitAreaRate = 40;
			this.m_lblState.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_lblState.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_lblState.UnitPositionVertical = false;
			this.m_lblState.UnitText = "";
			this.m_lblState.UseBorder = true;
			this.m_lblState.UseEdgeRadius = false;
			this.m_lblState.UseSubFont = false;
			this.m_lblState.UseUnitFont = false;
			// 
			// m_lblMonitoring
			// 
			this.m_lblMonitoring.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_lblMonitoring.BorderStroke = 2;
			this.m_lblMonitoring.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_lblMonitoring.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_lblMonitoring.EdgeRadius = 1;
			this.m_lblMonitoring.Location = new System.Drawing.Point(697, 496);
			this.m_lblMonitoring.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblMonitoring.MainFontColor = System.Drawing.Color.Black;
			this.m_lblMonitoring.Name = "m_lblMonitoring";
			this.m_lblMonitoring.Size = new System.Drawing.Size(155, 39);
			this.m_lblMonitoring.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_lblMonitoring.SubFontColor = System.Drawing.Color.Black;
			this.m_lblMonitoring.SubText = "";
			this.m_lblMonitoring.TabIndex = 1366;
			this.m_lblMonitoring.Text = "MONITORING MODE";
			this.m_lblMonitoring.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_lblMonitoring.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblMonitoring.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblMonitoring.UnitAreaRate = 40;
			this.m_lblMonitoring.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_lblMonitoring.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_lblMonitoring.UnitPositionVertical = false;
			this.m_lblMonitoring.UnitText = "";
			this.m_lblMonitoring.UseBorder = true;
			this.m_lblMonitoring.UseEdgeRadius = false;
			this.m_lblMonitoring.UseSubFont = false;
			this.m_lblMonitoring.UseUnitFont = false;
			// 
			// m_lblDelay
			// 
			this.m_lblDelay.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_lblDelay.BorderStroke = 2;
			this.m_lblDelay.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_lblDelay.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_lblDelay.EdgeRadius = 1;
			this.m_lblDelay.Location = new System.Drawing.Point(7, 745);
			this.m_lblDelay.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblDelay.MainFontColor = System.Drawing.Color.Black;
			this.m_lblDelay.Name = "m_lblDelay";
			this.m_lblDelay.Size = new System.Drawing.Size(155, 39);
			this.m_lblDelay.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_lblDelay.SubFontColor = System.Drawing.Color.Black;
			this.m_lblDelay.SubText = "";
			this.m_lblDelay.TabIndex = 1367;
			this.m_lblDelay.Text = "FORWARD DELAY";
			this.m_lblDelay.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_lblDelay.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblDelay.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblDelay.UnitAreaRate = 40;
			this.m_lblDelay.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_lblDelay.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_lblDelay.UnitPositionVertical = false;
			this.m_lblDelay.UnitText = "";
			this.m_lblDelay.UseBorder = true;
			this.m_lblDelay.UseEdgeRadius = false;
			this.m_lblDelay.UseSubFont = false;
			this.m_lblDelay.UseUnitFont = false;
			// 
			// m_lblName
			// 
			this.m_lblName.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_lblName.BorderStroke = 2;
			this.m_lblName.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_lblName.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_lblName.EdgeRadius = 1;
			this.m_lblName.Location = new System.Drawing.Point(540, 451);
			this.m_lblName.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblName.MainFontColor = System.Drawing.Color.Black;
			this.m_lblName.Name = "m_lblName";
			this.m_lblName.Size = new System.Drawing.Size(155, 39);
			this.m_lblName.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_lblName.SubFontColor = System.Drawing.Color.Black;
			this.m_lblName.SubText = "";
			this.m_lblName.TabIndex = 1370;
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
			// m_lblKey
			// 
			this.m_lblKey.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_lblKey.BorderStroke = 2;
			this.m_lblKey.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_lblKey.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_lblKey.EdgeRadius = 1;
			this.m_lblKey.Location = new System.Drawing.Point(291, 451);
			this.m_lblKey.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblKey.MainFontColor = System.Drawing.Color.Black;
			this.m_lblKey.Name = "m_lblKey";
			this.m_lblKey.Size = new System.Drawing.Size(155, 39);
			this.m_lblKey.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_lblKey.SubFontColor = System.Drawing.Color.Black;
			this.m_lblKey.SubText = "";
			this.m_lblKey.TabIndex = 1371;
			this.m_lblKey.Text = "KEY";
			this.m_lblKey.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_lblKey.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblKey.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblKey.UnitAreaRate = 40;
			this.m_lblKey.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_lblKey.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_lblKey.UnitPositionVertical = false;
			this.m_lblKey.UnitText = "";
			this.m_lblKey.UseBorder = true;
			this.m_lblKey.UseEdgeRadius = false;
			this.m_lblKey.UseSubFont = false;
			this.m_lblKey.UseUnitFont = false;
			// 
			// m_lblTimeout
			// 
			this.m_lblTimeout.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_lblTimeout.BorderStroke = 2;
			this.m_lblTimeout.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_lblTimeout.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_lblTimeout.EdgeRadius = 1;
			this.m_lblTimeout.Location = new System.Drawing.Point(573, 745);
			this.m_lblTimeout.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblTimeout.MainFontColor = System.Drawing.Color.Black;
			this.m_lblTimeout.Name = "m_lblTimeout";
			this.m_lblTimeout.Size = new System.Drawing.Size(155, 39);
			this.m_lblTimeout.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_lblTimeout.SubFontColor = System.Drawing.Color.Black;
			this.m_lblTimeout.SubText = "";
			this.m_lblTimeout.TabIndex = 1372;
			this.m_lblTimeout.Text = "FORWARD TIMEOUT";
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
			// m_btnDisable
			// 
			this.m_btnDisable.BorderWidth = 3;
			this.m_btnDisable.ButtonClicked = false;
			this.m_btnDisable.DisabledColor = System.Drawing.Color.LightSlateGray;
			this.m_btnDisable.EdgeRadius = 5;
			this.m_btnDisable.Enabled = false;
			this.m_btnDisable.GradientAngle = 70F;
			this.m_btnDisable.GradientFirstColor = System.Drawing.Color.White;
			this.m_btnDisable.GradientSecondColor = System.Drawing.Color.LightSlateGray;
			this.m_btnDisable.ImagePosition = new System.Drawing.Point(7, 7);
			this.m_btnDisable.ImageSize = new System.Drawing.Point(30, 30);
			this.m_btnDisable.LoadImage = global::FrameOfSystem3.Properties.Resources.DISABLE_BLACK;
			this.m_btnDisable.Location = new System.Drawing.Point(140, 813);
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
			this.m_btnDisable.UseBorder = true;
			this.m_btnDisable.UseEdge = true;
			this.m_btnDisable.UseImage = true;
			this.m_btnDisable.UseSubFont = true;
			this.m_btnDisable.Click += new System.EventHandler(this.Click_EnableOrDisable);
			// 
			// m_btnEnable
			// 
			this.m_btnEnable.BorderWidth = 3;
			this.m_btnEnable.ButtonClicked = false;
			this.m_btnEnable.DisabledColor = System.Drawing.Color.LightSlateGray;
			this.m_btnEnable.EdgeRadius = 5;
			this.m_btnEnable.Enabled = false;
			this.m_btnEnable.GradientAngle = 70F;
			this.m_btnEnable.GradientFirstColor = System.Drawing.Color.White;
			this.m_btnEnable.GradientSecondColor = System.Drawing.Color.LightSlateGray;
			this.m_btnEnable.ImagePosition = new System.Drawing.Point(7, 7);
			this.m_btnEnable.ImageSize = new System.Drawing.Point(30, 30);
			this.m_btnEnable.LoadImage = global::FrameOfSystem3.Properties.Resources.ENABLE_BLACK;
			this.m_btnEnable.Location = new System.Drawing.Point(9, 813);
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
			this.m_btnEnable.UseBorder = true;
			this.m_btnEnable.UseEdge = true;
			this.m_btnEnable.UseImage = true;
			this.m_btnEnable.UseSubFont = true;
			this.m_btnEnable.Click += new System.EventHandler(this.Click_EnableOrDisable);
			// 
			// m_btnBackward
			// 
			this.m_btnBackward.BorderWidth = 3;
			this.m_btnBackward.ButtonClicked = false;
			this.m_btnBackward.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_btnBackward.EdgeRadius = 5;
			this.m_btnBackward.Enabled = false;
			this.m_btnBackward.GradientAngle = 70F;
			this.m_btnBackward.GradientFirstColor = System.Drawing.Color.White;
			this.m_btnBackward.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
			this.m_btnBackward.ImagePosition = new System.Drawing.Point(7, 7);
			this.m_btnBackward.ImageSize = new System.Drawing.Point(30, 30);
			this.m_btnBackward.LoadImage = global::FrameOfSystem3.Properties.Resources.CONFIG_ADD3;
			this.m_btnBackward.Location = new System.Drawing.Point(1007, 813);
			this.m_btnBackward.MainFont = new System.Drawing.Font("맑은 고딕", 12.5F, System.Drawing.FontStyle.Bold);
			this.m_btnBackward.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
			this.m_btnBackward.Name = "m_btnBackward";
			this.m_btnBackward.Size = new System.Drawing.Size(121, 77);
			this.m_btnBackward.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
			this.m_btnBackward.SubFontColor = System.Drawing.Color.DarkBlue;
			this.m_btnBackward.SubText = "ACTION";
			this.m_btnBackward.TabIndex = 2;
			this.m_btnBackward.Text = "BACKWARD";
			this.m_btnBackward.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
			this.m_btnBackward.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_RIGHT;
			this.m_btnBackward.UseBorder = true;
			this.m_btnBackward.UseEdge = true;
			this.m_btnBackward.UseImage = false;
			this.m_btnBackward.UseSubFont = true;
			this.m_btnBackward.Click += new System.EventHandler(this.Click_Action);
			// 
			// m_btnForward
			// 
			this.m_btnForward.BorderWidth = 3;
			this.m_btnForward.ButtonClicked = false;
			this.m_btnForward.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_btnForward.EdgeRadius = 5;
			this.m_btnForward.Enabled = false;
			this.m_btnForward.GradientAngle = 70F;
			this.m_btnForward.GradientFirstColor = System.Drawing.Color.White;
			this.m_btnForward.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
			this.m_btnForward.ImagePosition = new System.Drawing.Point(7, 7);
			this.m_btnForward.ImageSize = new System.Drawing.Point(30, 30);
			this.m_btnForward.LoadImage = global::FrameOfSystem3.Properties.Resources.CONFIG_ADD3;
			this.m_btnForward.Location = new System.Drawing.Point(883, 813);
			this.m_btnForward.MainFont = new System.Drawing.Font("맑은 고딕", 12.5F, System.Drawing.FontStyle.Bold);
			this.m_btnForward.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
			this.m_btnForward.Name = "m_btnForward";
			this.m_btnForward.Size = new System.Drawing.Size(121, 77);
			this.m_btnForward.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
			this.m_btnForward.SubFontColor = System.Drawing.Color.DarkBlue;
			this.m_btnForward.SubText = "ACTION";
			this.m_btnForward.TabIndex = 1;
			this.m_btnForward.Text = "FORWARD";
			this.m_btnForward.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
			this.m_btnForward.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_RIGHT;
			this.m_btnForward.UseBorder = true;
			this.m_btnForward.UseEdge = true;
			this.m_btnForward.UseImage = false;
			this.m_btnForward.UseSubFont = true;
			this.m_btnForward.Click += new System.EventHandler(this.Click_Action);
			// 
			// m_btnRepeat
			// 
			this.m_btnRepeat.BorderWidth = 2;
			this.m_btnRepeat.ButtonClicked = false;
			this.m_btnRepeat.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_btnRepeat.EdgeRadius = 5;
			this.m_btnRepeat.Enabled = false;
			this.m_btnRepeat.GradientAngle = 70F;
			this.m_btnRepeat.GradientFirstColor = System.Drawing.Color.White;
			this.m_btnRepeat.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
			this.m_btnRepeat.ImagePosition = new System.Drawing.Point(7, 7);
			this.m_btnRepeat.ImageSize = new System.Drawing.Point(30, 30);
			this.m_btnRepeat.LoadImage = global::FrameOfSystem3.Properties.Resources.REPEAT_BLACK;
			this.m_btnRepeat.Location = new System.Drawing.Point(744, 812);
			this.m_btnRepeat.MainFont = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
			this.m_btnRepeat.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
			this.m_btnRepeat.Name = "m_btnRepeat";
			this.m_btnRepeat.Size = new System.Drawing.Size(128, 80);
			this.m_btnRepeat.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
			this.m_btnRepeat.SubFontColor = System.Drawing.Color.DarkBlue;
			this.m_btnRepeat.SubText = "ACTION";
			this.m_btnRepeat.TabIndex = 0;
			this.m_btnRepeat.Text = "REPEAT";
			this.m_btnRepeat.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
			this.m_btnRepeat.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_RIGHT;
			this.m_btnRepeat.UseBorder = true;
			this.m_btnRepeat.UseEdge = false;
			this.m_btnRepeat.UseImage = true;
			this.m_btnRepeat.UseSubFont = true;
			this.m_btnRepeat.Click += new System.EventHandler(this.Click_Action);
			// 
			// m_btnRemove
			// 
			this.m_btnRemove.BorderWidth = 3;
			this.m_btnRemove.ButtonClicked = false;
			this.m_btnRemove.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_btnRemove.EdgeRadius = 5;
			this.m_btnRemove.Enabled = false;
			this.m_btnRemove.GradientAngle = 70F;
			this.m_btnRemove.GradientFirstColor = System.Drawing.Color.White;
			this.m_btnRemove.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
			this.m_btnRemove.ImagePosition = new System.Drawing.Point(7, 7);
			this.m_btnRemove.ImageSize = new System.Drawing.Point(30, 30);
			this.m_btnRemove.LoadImage = global::FrameOfSystem3.Properties.Resources.REMOVE;
			this.m_btnRemove.Location = new System.Drawing.Point(435, 813);
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
			this.m_btnRemove.UseBorder = true;
			this.m_btnRemove.UseEdge = true;
			this.m_btnRemove.UseImage = true;
			this.m_btnRemove.UseSubFont = false;
			this.m_btnRemove.Click += new System.EventHandler(this.Click_AddOrRemove);
			// 
			// m_btnAdd
			// 
			this.m_btnAdd.BorderWidth = 3;
			this.m_btnAdd.ButtonClicked = false;
			this.m_btnAdd.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_btnAdd.EdgeRadius = 5;
			this.m_btnAdd.GradientAngle = 70F;
			this.m_btnAdd.GradientFirstColor = System.Drawing.Color.White;
			this.m_btnAdd.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
			this.m_btnAdd.ImagePosition = new System.Drawing.Point(7, 7);
			this.m_btnAdd.ImageSize = new System.Drawing.Point(30, 30);
			this.m_btnAdd.LoadImage = global::FrameOfSystem3.Properties.Resources.CONFIG_ADD3;
			this.m_btnAdd.Location = new System.Drawing.Point(304, 813);
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
			this.m_btnAdd.UseBorder = true;
			this.m_btnAdd.UseEdge = true;
			this.m_btnAdd.UseImage = true;
			this.m_btnAdd.UseSubFont = false;
			this.m_btnAdd.Click += new System.EventHandler(this.Click_AddOrRemove);
			// 
			// m_dgViewINPUT
			// 
			this.m_dgViewINPUT.AllowUserToAddRows = false;
			this.m_dgViewINPUT.AllowUserToDeleteRows = false;
			this.m_dgViewINPUT.AllowUserToResizeColumns = false;
			this.m_dgViewINPUT.AllowUserToResizeRows = false;
			this.m_dgViewINPUT.BackgroundColor = System.Drawing.Color.White;
			this.m_dgViewINPUT.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
			this.m_dgViewINPUT.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightGray;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.m_dgViewINPUT.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
			this.m_dgViewINPUT.ColumnHeadersHeight = 30;
			this.m_dgViewINPUT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.m_dgViewINPUT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle5.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
			dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.m_dgViewINPUT.DefaultCellStyle = dataGridViewCellStyle5;
			this.m_dgViewINPUT.Enabled = false;
			this.m_dgViewINPUT.EnableHeadersVisualStyles = false;
			this.m_dgViewINPUT.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
			this.m_dgViewINPUT.Location = new System.Drawing.Point(6, 572);
			this.m_dgViewINPUT.MultiSelect = false;
			this.m_dgViewINPUT.Name = "m_dgViewINPUT";
			this.m_dgViewINPUT.ReadOnly = true;
			this.m_dgViewINPUT.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
			dataGridViewCellStyle6.Font = new System.Drawing.Font("맑은 고딕", 11F);
			dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
			dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.m_dgViewINPUT.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
			this.m_dgViewINPUT.RowHeadersVisible = false;
			this.m_dgViewINPUT.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.m_dgViewINPUT.RowTemplate.Height = 23;
			this.m_dgViewINPUT.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.m_dgViewINPUT.Size = new System.Drawing.Size(440, 162);
			this.m_dgViewINPUT.TabIndex = 1373;
			// 
			// dataGridViewTextBoxColumn3
			// 
			this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.dataGridViewTextBoxColumn3.Frozen = true;
			this.dataGridViewTextBoxColumn3.HeaderText = "INDEX";
			this.dataGridViewTextBoxColumn3.MaxInputLength = 20;
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.ReadOnly = true;
			this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn3.Width = 60;
			// 
			// dataGridViewTextBoxColumn4
			// 
			this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn4.HeaderText = "NAME";
			this.dataGridViewTextBoxColumn4.MaxInputLength = 20;
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn4.ReadOnly = true;
			this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// dataGridViewTextBoxColumn5
			// 
			this.dataGridViewTextBoxColumn5.HeaderText = "";
			this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn5.ReadOnly = true;
			this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn5.Width = 30;
			// 
			// sys3GroupBox1
			// 
			this.sys3GroupBox1.BackGroundColor = System.Drawing.Color.WhiteSmoke;
			this.sys3GroupBox1.EdgeBorderStroke = 2;
			this.sys3GroupBox1.EdgeRadius = 2;
			this.sys3GroupBox1.LabelFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.sys3GroupBox1.LabelGradientColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
			this.sys3GroupBox1.LabelGradientColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.sys3GroupBox1.LabelHeight = 32;
			this.sys3GroupBox1.LabelTextColor = System.Drawing.Color.Black;
			this.sys3GroupBox1.Location = new System.Drawing.Point(3, 541);
			this.sys3GroupBox1.Name = "sys3GroupBox1";
			this.sys3GroupBox1.Size = new System.Drawing.Size(569, 198);
			this.sys3GroupBox1.TabIndex = 1374;
			this.sys3GroupBox1.Text = "INPUT IO LIST";
			this.sys3GroupBox1.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.sys3GroupBox1.UseLabelBorder = true;
			// 
			// m_tabBackward
			// 
			this.m_tabBackward.BorderWidth = 2;
			this.m_tabBackward.ButtonClicked = false;
			this.m_tabBackward.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_tabBackward.EdgeRadius = 5;
			this.m_tabBackward.GradientAngle = 70F;
			this.m_tabBackward.GradientFirstColor = System.Drawing.Color.White;
			this.m_tabBackward.GradientSecondColor = System.Drawing.Color.White;
			this.m_tabBackward.ImagePosition = new System.Drawing.Point(7, 7);
			this.m_tabBackward.ImageSize = new System.Drawing.Point(30, 30);
			this.m_tabBackward.LoadImage = global::FrameOfSystem3.Properties.Resources.Home_black;
			this.m_tabBackward.Location = new System.Drawing.Point(135, 451);
			this.m_tabBackward.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_tabBackward.MainFontColor = System.Drawing.Color.DarkBlue;
			this.m_tabBackward.Name = "m_tabBackward";
			this.m_tabBackward.Size = new System.Drawing.Size(131, 84);
			this.m_tabBackward.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
			this.m_tabBackward.SubFontColor = System.Drawing.Color.DarkBlue;
			this.m_tabBackward.SubText = "STATUS";
			this.m_tabBackward.TabIndex = 1;
			this.m_tabBackward.Text = "BACKWARD";
			this.m_tabBackward.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_tabBackward.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_RIGHT;
			this.m_tabBackward.UseBorder = false;
			this.m_tabBackward.UseEdge = false;
			this.m_tabBackward.UseImage = false;
			this.m_tabBackward.UseSubFont = false;
			this.m_tabBackward.Click += new System.EventHandler(this.Click_TabLabel);
			// 
			// m_tabForward
			// 
			this.m_tabForward.BorderWidth = 2;
			this.m_tabForward.ButtonClicked = true;
			this.m_tabForward.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_tabForward.EdgeRadius = 5;
			this.m_tabForward.GradientAngle = 70F;
			this.m_tabForward.GradientFirstColor = System.Drawing.Color.DarkBlue;
			this.m_tabForward.GradientSecondColor = System.Drawing.Color.DarkBlue;
			this.m_tabForward.ImagePosition = new System.Drawing.Point(7, 7);
			this.m_tabForward.ImageSize = new System.Drawing.Point(30, 30);
			this.m_tabForward.LoadImage = global::FrameOfSystem3.Properties.Resources.Home_black;
			this.m_tabForward.Location = new System.Drawing.Point(6, 451);
			this.m_tabForward.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_tabForward.MainFontColor = System.Drawing.Color.White;
			this.m_tabForward.Name = "m_tabForward";
			this.m_tabForward.Size = new System.Drawing.Size(131, 84);
			this.m_tabForward.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
			this.m_tabForward.SubFontColor = System.Drawing.Color.DarkBlue;
			this.m_tabForward.SubText = "STATUS";
			this.m_tabForward.TabIndex = 0;
			this.m_tabForward.Text = "FORWARD";
			this.m_tabForward.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_tabForward.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_RIGHT;
			this.m_tabForward.UseBorder = false;
			this.m_tabForward.UseEdge = false;
			this.m_tabForward.UseImage = false;
			this.m_tabForward.UseSubFont = false;
			this.m_tabForward.Click += new System.EventHandler(this.Click_TabLabel);
			// 
			// m_dgViewOutput
			// 
			this.m_dgViewOutput.AllowUserToAddRows = false;
			this.m_dgViewOutput.AllowUserToDeleteRows = false;
			this.m_dgViewOutput.AllowUserToResizeColumns = false;
			this.m_dgViewOutput.AllowUserToResizeRows = false;
			this.m_dgViewOutput.BackgroundColor = System.Drawing.Color.White;
			this.m_dgViewOutput.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
			this.m_dgViewOutput.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle7.BackColor = System.Drawing.Color.LightGray;
			dataGridViewCellStyle7.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White;
			dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.m_dgViewOutput.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
			this.m_dgViewOutput.ColumnHeadersHeight = 30;
			this.m_dgViewOutput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.m_dgViewOutput.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn6});
			dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle8.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
			dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.m_dgViewOutput.DefaultCellStyle = dataGridViewCellStyle8;
			this.m_dgViewOutput.Enabled = false;
			this.m_dgViewOutput.EnableHeadersVisualStyles = false;
			this.m_dgViewOutput.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
			this.m_dgViewOutput.Location = new System.Drawing.Point(571, 573);
			this.m_dgViewOutput.MultiSelect = false;
			this.m_dgViewOutput.Name = "m_dgViewOutput";
			this.m_dgViewOutput.ReadOnly = true;
			this.m_dgViewOutput.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
			dataGridViewCellStyle9.Font = new System.Drawing.Font("맑은 고딕", 11F);
			dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
			dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.m_dgViewOutput.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
			this.m_dgViewOutput.RowHeadersVisible = false;
			this.m_dgViewOutput.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.m_dgViewOutput.RowTemplate.Height = 23;
			this.m_dgViewOutput.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.m_dgViewOutput.Size = new System.Drawing.Size(440, 162);
			this.m_dgViewOutput.TabIndex = 1373;
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.dataGridViewTextBoxColumn1.Frozen = true;
			this.dataGridViewTextBoxColumn1.HeaderText = "INDEX";
			this.dataGridViewTextBoxColumn1.MaxInputLength = 20;
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn1.Width = 60;
			// 
			// dataGridViewTextBoxColumn2
			// 
			this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn2.HeaderText = "NAME";
			this.dataGridViewTextBoxColumn2.MaxInputLength = 20;
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// dataGridViewTextBoxColumn6
			// 
			this.dataGridViewTextBoxColumn6.HeaderText = "";
			this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
			this.dataGridViewTextBoxColumn6.ReadOnly = true;
			this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn6.Width = 30;
			// 
			// m_btnAddInput
			// 
			this.m_btnAddInput.BorderWidth = 3;
			this.m_btnAddInput.ButtonClicked = false;
			this.m_btnAddInput.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_btnAddInput.EdgeRadius = 5;
			this.m_btnAddInput.GradientAngle = 70F;
			this.m_btnAddInput.GradientFirstColor = System.Drawing.Color.White;
			this.m_btnAddInput.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
			this.m_btnAddInput.ImagePosition = new System.Drawing.Point(7, 7);
			this.m_btnAddInput.ImageSize = new System.Drawing.Point(30, 30);
			this.m_btnAddInput.LoadImage = global::FrameOfSystem3.Properties.Resources.CONFIG_ADD3;
			this.m_btnAddInput.Location = new System.Drawing.Point(450, 610);
			this.m_btnAddInput.MainFont = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
			this.m_btnAddInput.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
			this.m_btnAddInput.Name = "m_btnAddInput";
			this.m_btnAddInput.Size = new System.Drawing.Size(116, 94);
			this.m_btnAddInput.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
			this.m_btnAddInput.SubFontColor = System.Drawing.Color.DarkBlue;
			this.m_btnAddInput.SubText = "STATUS";
			this.m_btnAddInput.TabIndex = 1377;
			this.m_btnAddInput.Text = "EDIT INPUT LIST";
			this.m_btnAddInput.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
			this.m_btnAddInput.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_btnAddInput.UseBorder = true;
			this.m_btnAddInput.UseEdge = true;
			this.m_btnAddInput.UseImage = false;
			this.m_btnAddInput.UseSubFont = false;
			this.m_btnAddInput.Click += new System.EventHandler(this.Click_InputListButton);
			// 
			// m_btnAddOutput
			// 
			this.m_btnAddOutput.BorderWidth = 3;
			this.m_btnAddOutput.ButtonClicked = false;
			this.m_btnAddOutput.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_btnAddOutput.EdgeRadius = 5;
			this.m_btnAddOutput.GradientAngle = 70F;
			this.m_btnAddOutput.GradientFirstColor = System.Drawing.Color.White;
			this.m_btnAddOutput.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
			this.m_btnAddOutput.ImagePosition = new System.Drawing.Point(7, 7);
			this.m_btnAddOutput.ImageSize = new System.Drawing.Point(30, 30);
			this.m_btnAddOutput.LoadImage = global::FrameOfSystem3.Properties.Resources.CONFIG_ADD3;
			this.m_btnAddOutput.Location = new System.Drawing.Point(1016, 610);
			this.m_btnAddOutput.MainFont = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
			this.m_btnAddOutput.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
			this.m_btnAddOutput.Name = "m_btnAddOutput";
			this.m_btnAddOutput.Size = new System.Drawing.Size(116, 94);
			this.m_btnAddOutput.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
			this.m_btnAddOutput.SubFontColor = System.Drawing.Color.DarkBlue;
			this.m_btnAddOutput.SubText = "STATUS";
			this.m_btnAddOutput.TabIndex = 1377;
			this.m_btnAddOutput.Text = "EDIT OUTPUT LIST";
			this.m_btnAddOutput.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
			this.m_btnAddOutput.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_btnAddOutput.UseBorder = true;
			this.m_btnAddOutput.UseEdge = true;
			this.m_btnAddOutput.UseImage = false;
			this.m_btnAddOutput.UseSubFont = false;
			this.m_btnAddOutput.Click += new System.EventHandler(this.Click_OutputListButton);
			// 
			// sys3GroupBox2
			// 
			this.sys3GroupBox2.BackGroundColor = System.Drawing.Color.WhiteSmoke;
			this.sys3GroupBox2.EdgeBorderStroke = 2;
			this.sys3GroupBox2.EdgeRadius = 2;
			this.sys3GroupBox2.LabelFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.sys3GroupBox2.LabelGradientColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
			this.sys3GroupBox2.LabelGradientColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.sys3GroupBox2.LabelHeight = 32;
			this.sys3GroupBox2.LabelTextColor = System.Drawing.Color.Black;
			this.sys3GroupBox2.Location = new System.Drawing.Point(569, 541);
			this.sys3GroupBox2.Name = "sys3GroupBox2";
			this.sys3GroupBox2.Size = new System.Drawing.Size(570, 198);
			this.sys3GroupBox2.TabIndex = 1378;
			this.sys3GroupBox2.Text = "OUTPUT IO LIST";
			this.sys3GroupBox2.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.sys3GroupBox2.UseLabelBorder = true;
			// 
			// Config_Cylinder
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.m_btnAddOutput);
			this.Controls.Add(this.m_dgViewOutput);
			this.Controls.Add(this.sys3GroupBox2);
			this.Controls.Add(this.m_btnAddInput);
			this.Controls.Add(this.m_dgViewINPUT);
			this.Controls.Add(this.m_tabBackward);
			this.Controls.Add(this.m_tabForward);
			this.Controls.Add(this.m_lblTimeout);
			this.Controls.Add(this.m_lblKey);
			this.Controls.Add(this.m_lblName);
			this.Controls.Add(this.m_lblDelay);
			this.Controls.Add(this.m_lblMonitoring);
			this.Controls.Add(this.m_lblState);
			this.Controls.Add(this.m_btnDisable);
			this.Controls.Add(this.m_btnEnable);
			this.Controls.Add(this.m_btnBackward);
			this.Controls.Add(this.m_btnForward);
			this.Controls.Add(this.m_btnRepeat);
			this.Controls.Add(this.m_btnRemove);
			this.Controls.Add(this.m_btnAdd);
			this.Controls.Add(this.m_labelMonitoring);
			this.Controls.Add(this.m_labelState);
			this.Controls.Add(this.m_labelTimeout);
			this.Controls.Add(this.m_labelDelay);
			this.Controls.Add(this.m_labelName);
			this.Controls.Add(this.m_labelKey);
			this.Controls.Add(this.m_ledRepeat);
			this.Controls.Add(this.m_dgViewCylinder);
			this.Controls.Add(this.m_groupList);
			this.Controls.Add(this.sys3GroupBox1);
			this.Controls.Add(this.m_groupConfiguration);
			this.Name = "Config_Cylinder";
			this.Size = new System.Drawing.Size(1140, 900);
			((System.ComponentModel.ISupportInitialize)(this.m_dgViewCylinder)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.m_dgViewINPUT)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.m_dgViewOutput)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

		private Sys3Controls.Sys3LedLabel m_ledRepeat;
		private Sys3Controls.Sys3DoubleBufferedDataGridView m_dgViewCylinder;
		private Sys3Controls.Sys3GroupBox m_groupList;
		private Sys3Controls.Sys3GroupBox m_groupConfiguration;
		private Sys3Controls.Sys3Label m_labelKey;
		private Sys3Controls.Sys3Label m_labelName;
		private Sys3Controls.Sys3Label m_labelDelay;
		private Sys3Controls.Sys3Label m_labelTimeout;
		private Sys3Controls.Sys3Label m_labelState;
		private Sys3Controls.Sys3Label m_labelMonitoring;
		private Sys3Controls.Sys3button m_btnAdd;
		private Sys3Controls.Sys3button m_btnRemove;
		private Sys3Controls.Sys3button m_btnRepeat;
		private Sys3Controls.Sys3button m_btnForward;
		private Sys3Controls.Sys3button m_btnBackward;
		private Sys3Controls.Sys3button m_btnDisable;
		private Sys3Controls.Sys3button m_btnEnable;
		private Sys3Controls.Sys3Label m_lblState;
		private Sys3Controls.Sys3Label m_lblMonitoring;
		private Sys3Controls.Sys3Label m_lblDelay;
		private Sys3Controls.Sys3Label m_lblName;
		private Sys3Controls.Sys3Label m_lblKey;
		private Sys3Controls.Sys3Label m_lblTimeout;
		private System.Windows.Forms.DataGridViewTextBoxColumn ID;
		private System.Windows.Forms.DataGridViewTextBoxColumn PASSWORD;
		private System.Windows.Forms.DataGridViewTextBoxColumn MONITORING;
		private System.Windows.Forms.DataGridViewTextBoxColumn AUTHORITY;
		private System.Windows.Forms.DataGridViewTextBoxColumn CONDITION;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.DataGridViewTextBoxColumn BLINK;
		private System.Windows.Forms.DataGridViewTextBoxColumn Led;
		private System.Windows.Forms.DataGridViewTextBoxColumn STATE;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn BWOUT;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
		private Sys3Controls.Sys3DoubleBufferedDataGridView m_dgViewINPUT;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
		private Sys3Controls.Sys3GroupBox sys3GroupBox1;
		private Sys3Controls.Sys3button m_tabBackward;
		private Sys3Controls.Sys3button m_tabForward;
		private Sys3Controls.Sys3DoubleBufferedDataGridView m_dgViewOutput;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
		private Sys3Controls.Sys3button m_btnAddInput;
		private Sys3Controls.Sys3button m_btnAddOutput;
		private Sys3Controls.Sys3GroupBox sys3GroupBox2;
    }
}
