namespace FrameOfSystem3.Views.Config.Action
{
    partial class Config_Flow
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
            Sys3Controls.Sys3GroupBox m_groupFlowTable;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.m_dgViewTask = new Sys3Controls.Sys3DoubleBufferedDataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgViewAction = new Sys3Controls.Sys3DoubleBufferedDataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgViewFlow = new Sys3Controls.Sys3DoubleBufferedDataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRE_OK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRE_NG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRE_SKIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRE_PASS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POST_OK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POST_NG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_groupList = new Sys3Controls.Sys3GroupBox();
            this.sys3GroupBox1 = new Sys3Controls.Sys3GroupBox();
            this.m_groupActionList = new Sys3Controls.Sys3GroupBox();
            this.m_btnRemove = new Sys3Controls.Sys3button();
            this.m_btnInsert = new Sys3Controls.Sys3button();
            this.m_btnAdd = new Sys3Controls.Sys3button();
            this.m_dgViewFlowTable = new Sys3Controls.Sys3DoubleBufferedDataGridView();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            m_groupFlowTable = new Sys3Controls.Sys3GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgViewTask)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgViewAction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgViewFlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgViewFlowTable)).BeginInit();
            this.SuspendLayout();
            // 
            // m_groupFlowTable
            // 
            m_groupFlowTable.BackGroundColor = System.Drawing.Color.WhiteSmoke;
            m_groupFlowTable.EdgeBorderStroke = 2;
            m_groupFlowTable.EdgeRadius = 2;
            m_groupFlowTable.LabelFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            m_groupFlowTable.LabelGradientColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            m_groupFlowTable.LabelGradientColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            m_groupFlowTable.LabelHeight = 32;
            m_groupFlowTable.LabelTextColor = System.Drawing.Color.Black;
            m_groupFlowTable.Location = new System.Drawing.Point(0, 300);
            m_groupFlowTable.Name = "m_groupFlowTable";
            m_groupFlowTable.Size = new System.Drawing.Size(350, 242);
            m_groupFlowTable.TabIndex = 1377;
            m_groupFlowTable.Text = "FLOW TABLE";
            m_groupFlowTable.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            m_groupFlowTable.ThemeIndex = 0;
            m_groupFlowTable.UseLabelBorder = true;
            // 
            // m_dgViewTask
            // 
            this.m_dgViewTask.AllowUserToAddRows = false;
            this.m_dgViewTask.AllowUserToDeleteRows = false;
            this.m_dgViewTask.AllowUserToResizeColumns = false;
            this.m_dgViewTask.AllowUserToResizeRows = false;
            this.m_dgViewTask.BackgroundColor = System.Drawing.Color.White;
            this.m_dgViewTask.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.m_dgViewTask.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_dgViewTask.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.m_dgViewTask.ColumnHeadersHeight = 30;
            this.m_dgViewTask.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.m_dgViewTask.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.m_dgViewTask.DefaultCellStyle = dataGridViewCellStyle2;
            this.m_dgViewTask.EnableHeadersVisualStyles = false;
            this.m_dgViewTask.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            this.m_dgViewTask.Location = new System.Drawing.Point(6, 36);
            this.m_dgViewTask.MultiSelect = false;
            this.m_dgViewTask.Name = "m_dgViewTask";
            this.m_dgViewTask.ReadOnly = true;
            this.m_dgViewTask.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("맑은 고딕", 11F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_dgViewTask.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.m_dgViewTask.RowHeadersVisible = false;
            this.m_dgViewTask.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.m_dgViewTask.RowTemplate.Height = 30;
            this.m_dgViewTask.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgViewTask.Size = new System.Drawing.Size(338, 254);
            this.m_dgViewTask.TabIndex = 1241;
            this.m_dgViewTask.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Click_Task);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "INDEX";
            this.dataGridViewTextBoxColumn1.MaxInputLength = 20;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 65;
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
            // m_dgViewAction
            // 
            this.m_dgViewAction.AllowUserToAddRows = false;
            this.m_dgViewAction.AllowUserToDeleteRows = false;
            this.m_dgViewAction.AllowUserToResizeColumns = false;
            this.m_dgViewAction.AllowUserToResizeRows = false;
            this.m_dgViewAction.BackgroundColor = System.Drawing.Color.White;
            this.m_dgViewAction.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.m_dgViewAction.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_dgViewAction.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.m_dgViewAction.ColumnHeadersHeight = 30;
            this.m_dgViewAction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.m_dgViewAction.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.m_dgViewAction.DefaultCellStyle = dataGridViewCellStyle5;
            this.m_dgViewAction.Enabled = false;
            this.m_dgViewAction.EnableHeadersVisualStyles = false;
            this.m_dgViewAction.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            this.m_dgViewAction.Location = new System.Drawing.Point(6, 572);
            this.m_dgViewAction.MultiSelect = false;
            this.m_dgViewAction.Name = "m_dgViewAction";
            this.m_dgViewAction.ReadOnly = true;
            this.m_dgViewAction.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("맑은 고딕", 11F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_dgViewAction.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.m_dgViewAction.RowHeadersVisible = false;
            this.m_dgViewAction.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.m_dgViewAction.RowTemplate.Height = 30;
            this.m_dgViewAction.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgViewAction.Size = new System.Drawing.Size(338, 273);
            this.m_dgViewAction.TabIndex = 1241;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.Frozen = true;
            this.dataGridViewTextBoxColumn3.HeaderText = "ENABLE";
            this.dataGridViewTextBoxColumn3.MaxInputLength = 20;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 65;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.HeaderText = "ACTION NAME";
            this.dataGridViewTextBoxColumn4.MaxInputLength = 20;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // m_dgViewFlow
            // 
            this.m_dgViewFlow.AllowUserToAddRows = false;
            this.m_dgViewFlow.AllowUserToDeleteRows = false;
            this.m_dgViewFlow.AllowUserToResizeColumns = false;
            this.m_dgViewFlow.AllowUserToResizeRows = false;
            this.m_dgViewFlow.BackgroundColor = System.Drawing.Color.White;
            this.m_dgViewFlow.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.m_dgViewFlow.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_dgViewFlow.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.m_dgViewFlow.ColumnHeadersHeight = 30;
            this.m_dgViewFlow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.m_dgViewFlow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.PRE_OK,
            this.PRE_NG,
            this.PRE_SKIP,
            this.PRE_PASS,
            this.POST_OK,
            this.POST_NG});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.m_dgViewFlow.DefaultCellStyle = dataGridViewCellStyle8;
            this.m_dgViewFlow.EnableHeadersVisualStyles = false;
            this.m_dgViewFlow.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            this.m_dgViewFlow.Location = new System.Drawing.Point(355, 36);
            this.m_dgViewFlow.MultiSelect = false;
            this.m_dgViewFlow.Name = "m_dgViewFlow";
            this.m_dgViewFlow.ReadOnly = true;
            this.m_dgViewFlow.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("맑은 고딕", 11F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_dgViewFlow.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.m_dgViewFlow.RowHeadersVisible = false;
            this.m_dgViewFlow.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.m_dgViewFlow.RowTemplate.Height = 30;
            this.m_dgViewFlow.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgViewFlow.Size = new System.Drawing.Size(778, 732);
            this.m_dgViewFlow.TabIndex = 1257;
            this.m_dgViewFlow.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Click_Cell);
            this.m_dgViewFlow.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DoubleClick_Cell);
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.Frozen = true;
            this.dataGridViewTextBoxColumn5.HeaderText = "INDEX";
            this.dataGridViewTextBoxColumn5.MaxInputLength = 20;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn5.Width = 65;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn6.HeaderText = "ACTION";
            this.dataGridViewTextBoxColumn6.MaxInputLength = 20;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PRE_OK
            // 
            this.PRE_OK.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.PRE_OK.HeaderText = "OK";
            this.PRE_OK.Name = "PRE_OK";
            this.PRE_OK.ReadOnly = true;
            this.PRE_OK.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PRE_OK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PRE_OK.Width = 29;
            // 
            // PRE_NG
            // 
            this.PRE_NG.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.PRE_NG.HeaderText = "NG";
            this.PRE_NG.Name = "PRE_NG";
            this.PRE_NG.ReadOnly = true;
            this.PRE_NG.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PRE_NG.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PRE_NG.Width = 31;
            // 
            // PRE_SKIP
            // 
            this.PRE_SKIP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.PRE_SKIP.HeaderText = "ESCAPE";
            this.PRE_SKIP.Name = "PRE_SKIP";
            this.PRE_SKIP.ReadOnly = true;
            this.PRE_SKIP.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PRE_SKIP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PRE_SKIP.Width = 54;
            // 
            // PRE_PASS
            // 
            this.PRE_PASS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.PRE_PASS.HeaderText = "SUCCESS";
            this.PRE_PASS.Name = "PRE_PASS";
            this.PRE_PASS.ReadOnly = true;
            this.PRE_PASS.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PRE_PASS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PRE_PASS.Width = 64;
            // 
            // POST_OK
            // 
            this.POST_OK.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.POST_OK.HeaderText = "FAILURE";
            this.POST_OK.Name = "POST_OK";
            this.POST_OK.ReadOnly = true;
            this.POST_OK.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.POST_OK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.POST_OK.Width = 59;
            // 
            // POST_NG
            // 
            this.POST_NG.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.POST_NG.HeaderText = "INVALID";
            this.POST_NG.Name = "POST_NG";
            this.POST_NG.ReadOnly = true;
            this.POST_NG.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.POST_NG.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.POST_NG.Width = 61;
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
            this.m_groupList.Size = new System.Drawing.Size(350, 296);
            this.m_groupList.TabIndex = 1371;
            this.m_groupList.Text = "TASK LIST";
            this.m_groupList.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_groupList.ThemeIndex = 0;
            this.m_groupList.UseLabelBorder = true;
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
            this.sys3GroupBox1.Location = new System.Drawing.Point(349, 0);
            this.sys3GroupBox1.Name = "sys3GroupBox1";
            this.sys3GroupBox1.Size = new System.Drawing.Size(791, 850);
            this.sys3GroupBox1.TabIndex = 1372;
            this.sys3GroupBox1.Text = "FLOW LIST";
            this.sys3GroupBox1.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3GroupBox1.ThemeIndex = 0;
            this.sys3GroupBox1.UseLabelBorder = true;
            // 
            // m_groupActionList
            // 
            this.m_groupActionList.BackGroundColor = System.Drawing.Color.WhiteSmoke;
            this.m_groupActionList.EdgeBorderStroke = 2;
            this.m_groupActionList.EdgeRadius = 2;
            this.m_groupActionList.LabelFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_groupActionList.LabelGradientColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.m_groupActionList.LabelGradientColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_groupActionList.LabelHeight = 32;
            this.m_groupActionList.LabelTextColor = System.Drawing.Color.Black;
            this.m_groupActionList.Location = new System.Drawing.Point(0, 536);
            this.m_groupActionList.Name = "m_groupActionList";
            this.m_groupActionList.Size = new System.Drawing.Size(350, 314);
            this.m_groupActionList.TabIndex = 1373;
            this.m_groupActionList.Text = "ACTION LIST";
            this.m_groupActionList.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_groupActionList.ThemeIndex = 0;
            this.m_groupActionList.UseLabelBorder = true;
            // 
            // m_btnRemove
            // 
            this.m_btnRemove.BorderWidth = 1;
            this.m_btnRemove.ButtonClicked = false;
            this.m_btnRemove.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.m_btnRemove.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.m_btnRemove.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.m_btnRemove.Description = "";
            this.m_btnRemove.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_btnRemove.EdgeRadius = 5;
            this.m_btnRemove.GradientAngle = 80F;
            this.m_btnRemove.GradientFirstColor = System.Drawing.Color.White;
            this.m_btnRemove.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
            this.m_btnRemove.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.m_btnRemove.ImagePosition = new System.Drawing.Point(7, 7);
            this.m_btnRemove.ImageSize = new System.Drawing.Point(30, 30);
            this.m_btnRemove.LoadImage = global::FrameOfSystem3.Properties.Resources.REMOVE;
            this.m_btnRemove.Location = new System.Drawing.Point(875, 773);
            this.m_btnRemove.MainFont = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.m_btnRemove.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
            this.m_btnRemove.Name = "m_btnRemove";
            this.m_btnRemove.Size = new System.Drawing.Size(253, 72);
            this.m_btnRemove.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.m_btnRemove.SubFontColor = System.Drawing.Color.DarkBlue;
            this.m_btnRemove.SubText = "STATUS";
            this.m_btnRemove.TabIndex = 1375;
            this.m_btnRemove.Text = "REMOVE";
            this.m_btnRemove.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_btnRemove.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_btnRemove.ThemeIndex = 0;
            this.m_btnRemove.UseBorder = true;
            this.m_btnRemove.UseClickedEmphasizeTextColor = false;
            this.m_btnRemove.UseCustomizeClickedColor = false;
            this.m_btnRemove.UseEdge = false;
            this.m_btnRemove.UseHoverEmphasizeCustomColor = false;
            this.m_btnRemove.UseImage = true;
            this.m_btnRemove.UserHoverEmpahsize = false;
            this.m_btnRemove.UseSubFont = false;
            this.m_btnRemove.Click += new System.EventHandler(this.Click_Remove);
            // 
            // m_btnInsert
            // 
            this.m_btnInsert.BorderWidth = 1;
            this.m_btnInsert.ButtonClicked = false;
            this.m_btnInsert.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.m_btnInsert.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.m_btnInsert.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.m_btnInsert.Description = "";
            this.m_btnInsert.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_btnInsert.EdgeRadius = 5;
            this.m_btnInsert.GradientAngle = 80F;
            this.m_btnInsert.GradientFirstColor = System.Drawing.Color.White;
            this.m_btnInsert.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
            this.m_btnInsert.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.m_btnInsert.ImagePosition = new System.Drawing.Point(7, 7);
            this.m_btnInsert.ImageSize = new System.Drawing.Point(30, 30);
            this.m_btnInsert.LoadImage = global::FrameOfSystem3.Properties.Resources.INSERT_BLACK;
            this.m_btnInsert.Location = new System.Drawing.Point(615, 773);
            this.m_btnInsert.MainFont = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.m_btnInsert.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
            this.m_btnInsert.Name = "m_btnInsert";
            this.m_btnInsert.Size = new System.Drawing.Size(253, 72);
            this.m_btnInsert.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.m_btnInsert.SubFontColor = System.Drawing.Color.DarkBlue;
            this.m_btnInsert.SubText = "STATUS";
            this.m_btnInsert.TabIndex = 1374;
            this.m_btnInsert.Text = "INSERT";
            this.m_btnInsert.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_btnInsert.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_btnInsert.ThemeIndex = 0;
            this.m_btnInsert.UseBorder = true;
            this.m_btnInsert.UseClickedEmphasizeTextColor = false;
            this.m_btnInsert.UseCustomizeClickedColor = false;
            this.m_btnInsert.UseEdge = false;
            this.m_btnInsert.UseHoverEmphasizeCustomColor = false;
            this.m_btnInsert.UseImage = true;
            this.m_btnInsert.UserHoverEmpahsize = false;
            this.m_btnInsert.UseSubFont = false;
            this.m_btnInsert.Click += new System.EventHandler(this.Click_Insert);
            // 
            // m_btnAdd
            // 
            this.m_btnAdd.BorderWidth = 1;
            this.m_btnAdd.ButtonClicked = false;
            this.m_btnAdd.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.m_btnAdd.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.m_btnAdd.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.m_btnAdd.Description = "";
            this.m_btnAdd.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_btnAdd.EdgeRadius = 5;
            this.m_btnAdd.GradientAngle = 80F;
            this.m_btnAdd.GradientFirstColor = System.Drawing.Color.White;
            this.m_btnAdd.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
            this.m_btnAdd.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.m_btnAdd.ImagePosition = new System.Drawing.Point(7, 7);
            this.m_btnAdd.ImageSize = new System.Drawing.Point(30, 30);
            this.m_btnAdd.LoadImage = global::FrameOfSystem3.Properties.Resources.CONFIG_ADD3;
            this.m_btnAdd.Location = new System.Drawing.Point(355, 773);
            this.m_btnAdd.MainFont = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.m_btnAdd.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
            this.m_btnAdd.Name = "m_btnAdd";
            this.m_btnAdd.Size = new System.Drawing.Size(253, 72);
            this.m_btnAdd.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.m_btnAdd.SubFontColor = System.Drawing.Color.DarkBlue;
            this.m_btnAdd.SubText = "STATUS";
            this.m_btnAdd.TabIndex = 1374;
            this.m_btnAdd.Text = "ADD";
            this.m_btnAdd.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_btnAdd.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_btnAdd.ThemeIndex = 0;
            this.m_btnAdd.UseBorder = true;
            this.m_btnAdd.UseClickedEmphasizeTextColor = false;
            this.m_btnAdd.UseCustomizeClickedColor = false;
            this.m_btnAdd.UseEdge = false;
            this.m_btnAdd.UseHoverEmphasizeCustomColor = false;
            this.m_btnAdd.UseImage = true;
            this.m_btnAdd.UserHoverEmpahsize = false;
            this.m_btnAdd.UseSubFont = false;
            this.m_btnAdd.Click += new System.EventHandler(this.Click_Add);
            // 
            // m_dgViewFlowTable
            // 
            this.m_dgViewFlowTable.AllowUserToAddRows = false;
            this.m_dgViewFlowTable.AllowUserToDeleteRows = false;
            this.m_dgViewFlowTable.AllowUserToResizeColumns = false;
            this.m_dgViewFlowTable.AllowUserToResizeRows = false;
            this.m_dgViewFlowTable.BackgroundColor = System.Drawing.Color.White;
            this.m_dgViewFlowTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.m_dgViewFlowTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_dgViewFlowTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.m_dgViewFlowTable.ColumnHeadersHeight = 30;
            this.m_dgViewFlowTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.m_dgViewFlowTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.m_dgViewFlowTable.DefaultCellStyle = dataGridViewCellStyle11;
            this.m_dgViewFlowTable.EnableHeadersVisualStyles = false;
            this.m_dgViewFlowTable.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            this.m_dgViewFlowTable.Location = new System.Drawing.Point(6, 337);
            this.m_dgViewFlowTable.MultiSelect = false;
            this.m_dgViewFlowTable.Name = "m_dgViewFlowTable";
            this.m_dgViewFlowTable.ReadOnly = true;
            this.m_dgViewFlowTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("맑은 고딕", 11F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_dgViewFlowTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.m_dgViewFlowTable.RowHeadersVisible = false;
            this.m_dgViewFlowTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.m_dgViewFlowTable.RowTemplate.Height = 30;
            this.m_dgViewFlowTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgViewFlowTable.Size = new System.Drawing.Size(337, 199);
            this.m_dgViewFlowTable.TabIndex = 1376;
            this.m_dgViewFlowTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Click_Table);
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.Frozen = true;
            this.dataGridViewTextBoxColumn7.HeaderText = "INDEX";
            this.dataGridViewTextBoxColumn7.MaxInputLength = 20;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn7.Width = 65;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn8.HeaderText = "FLOW NAME";
            this.dataGridViewTextBoxColumn8.MaxInputLength = 20;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Config_Flow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_dgViewFlowTable);
            this.Controls.Add(m_groupFlowTable);
            this.Controls.Add(this.m_btnRemove);
            this.Controls.Add(this.m_btnInsert);
            this.Controls.Add(this.m_btnAdd);
            this.Controls.Add(this.m_dgViewFlow);
            this.Controls.Add(this.m_dgViewAction);
            this.Controls.Add(this.m_dgViewTask);
            this.Controls.Add(this.m_groupList);
            this.Controls.Add(this.sys3GroupBox1);
            this.Controls.Add(this.m_groupActionList);
            this.Name = "Config_Flow";
            this.Size = new System.Drawing.Size(1140, 850);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgViewTask)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgViewAction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgViewFlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgViewFlowTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

		private Sys3Controls.Sys3DoubleBufferedDataGridView m_dgViewTask;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private Sys3Controls.Sys3DoubleBufferedDataGridView m_dgViewAction;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
		private Sys3Controls.Sys3DoubleBufferedDataGridView m_dgViewFlow;
		private Sys3Controls.Sys3GroupBox m_groupList;
		private Sys3Controls.Sys3GroupBox sys3GroupBox1;
		private Sys3Controls.Sys3GroupBox m_groupActionList;
		private Sys3Controls.Sys3button m_btnRemove;
		private Sys3Controls.Sys3button m_btnAdd;
		private Sys3Controls.Sys3button m_btnInsert;
		private Sys3Controls.Sys3DoubleBufferedDataGridView m_dgViewFlowTable;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
		private System.Windows.Forms.DataGridViewTextBoxColumn PRE_OK;
		private System.Windows.Forms.DataGridViewTextBoxColumn PRE_NG;
		private System.Windows.Forms.DataGridViewTextBoxColumn PRE_SKIP;
		private System.Windows.Forms.DataGridViewTextBoxColumn PRE_PASS;
		private System.Windows.Forms.DataGridViewTextBoxColumn POST_OK;
		private System.Windows.Forms.DataGridViewTextBoxColumn POST_NG;
    }
}
