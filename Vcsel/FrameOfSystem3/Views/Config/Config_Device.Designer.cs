namespace FrameOfSystem3.Views.Config
{
	partial class Config_Device
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
			this.m_dgViewTask = new Sys3Controls.Sys3DoubleBufferedDataGridView();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.m_groupTaskList = new Sys3Controls.Sys3GroupBox();
			this.m_groupDeviceList = new Sys3Controls.Sys3GroupBox();
			this.m_dgViewDevice = new Sys3Controls.Sys3DoubleBufferedDataGridView();
			this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.m_dgViewItem = new Sys3Controls.Sys3DoubleBufferedDataGridView();
			this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.POST_SKIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.m_groupItemList = new Sys3Controls.Sys3GroupBox();
			this.m_lblName = new Sys3Controls.Sys3Label();
			this.m_labelName = new Sys3Controls.Sys3Label();
			this.m_groupConfiguration = new Sys3Controls.Sys3GroupBox();
			this.m_btnRemove = new Sys3Controls.Sys3button();
			this.m_btnAdd = new Sys3Controls.Sys3button();
			this.m_labelTargetIndex = new Sys3Controls.Sys3Label();
			this.m_lblTargetIndex = new Sys3Controls.Sys3Label();
			((System.ComponentModel.ISupportInitialize)(this.m_dgViewTask)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.m_dgViewDevice)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.m_dgViewItem)).BeginInit();
			this.SuspendLayout();
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
			dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle19.BackColor = System.Drawing.Color.LightGray;
			dataGridViewCellStyle19.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			dataGridViewCellStyle19.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.White;
			dataGridViewCellStyle19.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.m_dgViewTask.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
			this.m_dgViewTask.ColumnHeadersHeight = 30;
			this.m_dgViewTask.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.m_dgViewTask.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
			dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle20.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
			dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.m_dgViewTask.DefaultCellStyle = dataGridViewCellStyle20;
			this.m_dgViewTask.EnableHeadersVisualStyles = false;
			this.m_dgViewTask.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
			this.m_dgViewTask.Location = new System.Drawing.Point(2, 30);
			this.m_dgViewTask.MultiSelect = false;
			this.m_dgViewTask.Name = "m_dgViewTask";
			this.m_dgViewTask.ReadOnly = true;
			this.m_dgViewTask.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle21.BackColor = System.Drawing.Color.White;
			dataGridViewCellStyle21.Font = new System.Drawing.Font("맑은 고딕", 11F);
			dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
			dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.m_dgViewTask.RowHeadersDefaultCellStyle = dataGridViewCellStyle21;
			this.m_dgViewTask.RowHeadersVisible = false;
			this.m_dgViewTask.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.m_dgViewTask.RowTemplate.Height = 30;
			this.m_dgViewTask.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.m_dgViewTask.Size = new System.Drawing.Size(425, 422);
			this.m_dgViewTask.TabIndex = 1372;
			this.m_dgViewTask.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Click_TaskList);
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
			// m_groupTaskList
			// 
			this.m_groupTaskList.BackGroundColor = System.Drawing.Color.WhiteSmoke;
			this.m_groupTaskList.EdgeBorderStroke = 2;
			this.m_groupTaskList.EdgeRadius = 2;
			this.m_groupTaskList.LabelFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_groupTaskList.LabelGradientColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
			this.m_groupTaskList.LabelGradientColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.m_groupTaskList.LabelHeight = 32;
			this.m_groupTaskList.LabelTextColor = System.Drawing.Color.Black;
			this.m_groupTaskList.Location = new System.Drawing.Point(0, 0);
			this.m_groupTaskList.Name = "m_groupTaskList";
			this.m_groupTaskList.Size = new System.Drawing.Size(429, 454);
			this.m_groupTaskList.TabIndex = 1373;
			this.m_groupTaskList.Text = "TASK LIST";
			this.m_groupTaskList.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_groupTaskList.UseLabelBorder = true;
			// 
			// m_groupDeviceList
			// 
			this.m_groupDeviceList.BackGroundColor = System.Drawing.Color.WhiteSmoke;
			this.m_groupDeviceList.EdgeBorderStroke = 2;
			this.m_groupDeviceList.EdgeRadius = 2;
			this.m_groupDeviceList.LabelFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_groupDeviceList.LabelGradientColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
			this.m_groupDeviceList.LabelGradientColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.m_groupDeviceList.LabelHeight = 32;
			this.m_groupDeviceList.LabelTextColor = System.Drawing.Color.Black;
			this.m_groupDeviceList.Location = new System.Drawing.Point(0, 450);
			this.m_groupDeviceList.Name = "m_groupDeviceList";
			this.m_groupDeviceList.Size = new System.Drawing.Size(429, 450);
			this.m_groupDeviceList.TabIndex = 1373;
			this.m_groupDeviceList.Text = "DEVICE LIST";
			this.m_groupDeviceList.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_groupDeviceList.UseLabelBorder = true;
			// 
			// m_dgViewDevice
			// 
			this.m_dgViewDevice.AllowUserToAddRows = false;
			this.m_dgViewDevice.AllowUserToDeleteRows = false;
			this.m_dgViewDevice.AllowUserToResizeColumns = false;
			this.m_dgViewDevice.AllowUserToResizeRows = false;
			this.m_dgViewDevice.BackgroundColor = System.Drawing.Color.White;
			this.m_dgViewDevice.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
			this.m_dgViewDevice.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle22.BackColor = System.Drawing.Color.LightGray;
			dataGridViewCellStyle22.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			dataGridViewCellStyle22.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle22.SelectionBackColor = System.Drawing.Color.White;
			dataGridViewCellStyle22.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.m_dgViewDevice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
			this.m_dgViewDevice.ColumnHeadersHeight = 30;
			this.m_dgViewDevice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.m_dgViewDevice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
			dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle23.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle23.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
			dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.m_dgViewDevice.DefaultCellStyle = dataGridViewCellStyle23;
			this.m_dgViewDevice.EnableHeadersVisualStyles = false;
			this.m_dgViewDevice.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
			this.m_dgViewDevice.Location = new System.Drawing.Point(2, 480);
			this.m_dgViewDevice.MultiSelect = false;
			this.m_dgViewDevice.Name = "m_dgViewDevice";
			this.m_dgViewDevice.ReadOnly = true;
			this.m_dgViewDevice.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle24.BackColor = System.Drawing.Color.White;
			dataGridViewCellStyle24.Font = new System.Drawing.Font("맑은 고딕", 11F);
			dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
			dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.m_dgViewDevice.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
			this.m_dgViewDevice.RowHeadersVisible = false;
			this.m_dgViewDevice.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.m_dgViewDevice.RowTemplate.Height = 30;
			this.m_dgViewDevice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.m_dgViewDevice.Size = new System.Drawing.Size(425, 419);
			this.m_dgViewDevice.TabIndex = 1372;
			this.m_dgViewDevice.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Click_DeviceList);
			// 
			// dataGridViewTextBoxColumn3
			// 
			this.dataGridViewTextBoxColumn3.Frozen = true;
			this.dataGridViewTextBoxColumn3.HeaderText = "INDEX";
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
			this.dataGridViewTextBoxColumn4.HeaderText = "NAME";
			this.dataGridViewTextBoxColumn4.MaxInputLength = 20;
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn4.ReadOnly = true;
			this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// m_dgViewItem
			// 
			this.m_dgViewItem.AllowUserToAddRows = false;
			this.m_dgViewItem.AllowUserToDeleteRows = false;
			this.m_dgViewItem.AllowUserToResizeColumns = false;
			this.m_dgViewItem.AllowUserToResizeRows = false;
			this.m_dgViewItem.BackgroundColor = System.Drawing.Color.White;
			this.m_dgViewItem.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
			this.m_dgViewItem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle25.BackColor = System.Drawing.Color.LightGray;
			dataGridViewCellStyle25.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			dataGridViewCellStyle25.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle25.SelectionBackColor = System.Drawing.Color.White;
			dataGridViewCellStyle25.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.m_dgViewItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle25;
			this.m_dgViewItem.ColumnHeadersHeight = 30;
			this.m_dgViewItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.m_dgViewItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.POST_SKIP});
			dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle26.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle26.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			dataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle26.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
			dataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.m_dgViewItem.DefaultCellStyle = dataGridViewCellStyle26;
			this.m_dgViewItem.EnableHeadersVisualStyles = false;
			this.m_dgViewItem.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
			this.m_dgViewItem.Location = new System.Drawing.Point(428, 30);
			this.m_dgViewItem.MultiSelect = false;
			this.m_dgViewItem.Name = "m_dgViewItem";
			this.m_dgViewItem.ReadOnly = true;
			this.m_dgViewItem.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle27.BackColor = System.Drawing.Color.White;
			dataGridViewCellStyle27.Font = new System.Drawing.Font("맑은 고딕", 11F);
			dataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle27.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
			dataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.m_dgViewItem.RowHeadersDefaultCellStyle = dataGridViewCellStyle27;
			this.m_dgViewItem.RowHeadersVisible = false;
			this.m_dgViewItem.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.m_dgViewItem.RowTemplate.Height = 30;
			this.m_dgViewItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.m_dgViewItem.Size = new System.Drawing.Size(710, 653);
			this.m_dgViewItem.TabIndex = 1374;
			this.m_dgViewItem.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Click_ItemList);
			this.m_dgViewItem.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Click_ItemList);
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
			// 
			// dataGridViewTextBoxColumn6
			// 
			this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn6.HeaderText = "NAME";
			this.dataGridViewTextBoxColumn6.MaxInputLength = 20;
			this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
			this.dataGridViewTextBoxColumn6.ReadOnly = true;
			this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// POST_SKIP
			// 
			this.POST_SKIP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			this.POST_SKIP.HeaderText = "TARGET INDEX";
			this.POST_SKIP.Name = "POST_SKIP";
			this.POST_SKIP.ReadOnly = true;
			this.POST_SKIP.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.POST_SKIP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.POST_SKIP.Width = 123;
			// 
			// m_groupItemList
			// 
			this.m_groupItemList.BackGroundColor = System.Drawing.Color.WhiteSmoke;
			this.m_groupItemList.EdgeBorderStroke = 2;
			this.m_groupItemList.EdgeRadius = 2;
			this.m_groupItemList.LabelFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_groupItemList.LabelGradientColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
			this.m_groupItemList.LabelGradientColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.m_groupItemList.LabelHeight = 32;
			this.m_groupItemList.LabelTextColor = System.Drawing.Color.Black;
			this.m_groupItemList.Location = new System.Drawing.Point(427, 0);
			this.m_groupItemList.Name = "m_groupItemList";
			this.m_groupItemList.Size = new System.Drawing.Size(713, 685);
			this.m_groupItemList.TabIndex = 1375;
			this.m_groupItemList.Text = "ITEM LIST";
			this.m_groupItemList.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_groupItemList.UseLabelBorder = true;
			// 
			// m_lblName
			// 
			this.m_lblName.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_lblName.BorderStroke = 2;
			this.m_lblName.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_lblName.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_lblName.EdgeRadius = 1;
			this.m_lblName.Location = new System.Drawing.Point(453, 748);
			this.m_lblName.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblName.MainFontColor = System.Drawing.Color.Black;
			this.m_lblName.Name = "m_lblName";
			this.m_lblName.Size = new System.Drawing.Size(155, 52);
			this.m_lblName.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_lblName.SubFontColor = System.Drawing.Color.Black;
			this.m_lblName.SubText = "";
			this.m_lblName.TabIndex = 1379;
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
			// m_labelName
			// 
			this.m_labelName.BackGroundColor = System.Drawing.Color.White;
			this.m_labelName.BorderStroke = 2;
			this.m_labelName.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelName.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelName.EdgeRadius = 1;
			this.m_labelName.Enabled = false;
			this.m_labelName.Location = new System.Drawing.Point(609, 748);
			this.m_labelName.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelName.MainFontColor = System.Drawing.Color.Black;
			this.m_labelName.Name = "m_labelName";
			this.m_labelName.Size = new System.Drawing.Size(322, 52);
			this.m_labelName.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
			this.m_labelName.SubFontColor = System.Drawing.Color.Black;
			this.m_labelName.SubText = "";
			this.m_labelName.TabIndex = 0;
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
			this.m_groupConfiguration.Location = new System.Drawing.Point(428, 682);
			this.m_groupConfiguration.Name = "m_groupConfiguration";
			this.m_groupConfiguration.Size = new System.Drawing.Size(713, 217);
			this.m_groupConfiguration.TabIndex = 1377;
			this.m_groupConfiguration.Text = "CONFIGURATION";
			this.m_groupConfiguration.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_groupConfiguration.UseLabelBorder = true;
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
			this.m_btnRemove.Location = new System.Drawing.Point(953, 806);
			this.m_btnRemove.MainFont = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
			this.m_btnRemove.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
			this.m_btnRemove.Name = "m_btnRemove";
			this.m_btnRemove.Size = new System.Drawing.Size(147, 77);
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
			this.m_btnRemove.Click += new System.EventHandler(this.Click_Button);
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
			this.m_btnAdd.Location = new System.Drawing.Point(953, 723);
			this.m_btnAdd.MainFont = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
			this.m_btnAdd.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
			this.m_btnAdd.Name = "m_btnAdd";
			this.m_btnAdd.Size = new System.Drawing.Size(147, 77);
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
			this.m_btnAdd.Click += new System.EventHandler(this.Click_Button);
			// 
			// m_labelTargetIndex
			// 
			this.m_labelTargetIndex.BackGroundColor = System.Drawing.Color.White;
			this.m_labelTargetIndex.BorderStroke = 2;
			this.m_labelTargetIndex.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_labelTargetIndex.DisabledColor = System.Drawing.Color.LightGray;
			this.m_labelTargetIndex.EdgeRadius = 1;
			this.m_labelTargetIndex.Enabled = false;
			this.m_labelTargetIndex.Location = new System.Drawing.Point(609, 806);
			this.m_labelTargetIndex.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_labelTargetIndex.MainFontColor = System.Drawing.Color.Black;
			this.m_labelTargetIndex.Name = "m_labelTargetIndex";
			this.m_labelTargetIndex.Size = new System.Drawing.Size(322, 52);
			this.m_labelTargetIndex.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelTargetIndex.SubFontColor = System.Drawing.Color.Black;
			this.m_labelTargetIndex.SubText = "[ -1 ]";
			this.m_labelTargetIndex.TabIndex = 1;
			this.m_labelTargetIndex.Text = "--";
			this.m_labelTargetIndex.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_labelTargetIndex.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_labelTargetIndex.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_labelTargetIndex.UnitAreaRate = 40;
			this.m_labelTargetIndex.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_labelTargetIndex.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_labelTargetIndex.UnitPositionVertical = false;
			this.m_labelTargetIndex.UnitText = "";
			this.m_labelTargetIndex.UseBorder = true;
			this.m_labelTargetIndex.UseEdgeRadius = false;
			this.m_labelTargetIndex.UseSubFont = false;
			this.m_labelTargetIndex.UseUnitFont = false;
			this.m_labelTargetIndex.Click += new System.EventHandler(this.Click_TargetIndex);
			// 
			// m_lblTargetIndex
			// 
			this.m_lblTargetIndex.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
			this.m_lblTargetIndex.BorderStroke = 2;
			this.m_lblTargetIndex.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.m_lblTargetIndex.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_lblTargetIndex.EdgeRadius = 1;
			this.m_lblTargetIndex.Location = new System.Drawing.Point(453, 806);
			this.m_lblTargetIndex.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblTargetIndex.MainFontColor = System.Drawing.Color.Black;
			this.m_lblTargetIndex.Name = "m_lblTargetIndex";
			this.m_lblTargetIndex.Size = new System.Drawing.Size(155, 52);
			this.m_lblTargetIndex.SubFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			this.m_lblTargetIndex.SubFontColor = System.Drawing.Color.Black;
			this.m_lblTargetIndex.SubText = "TARGET NAME";
			this.m_lblTargetIndex.TabIndex = 1379;
			this.m_lblTargetIndex.Text = "TARGET INDEX";
			this.m_lblTargetIndex.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_lblTargetIndex.TextAlignSub = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
			this.m_lblTargetIndex.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_lblTargetIndex.UnitAreaRate = 40;
			this.m_lblTargetIndex.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.m_lblTargetIndex.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.m_lblTargetIndex.UnitPositionVertical = false;
			this.m_lblTargetIndex.UnitText = "";
			this.m_lblTargetIndex.UseBorder = true;
			this.m_lblTargetIndex.UseEdgeRadius = false;
			this.m_lblTargetIndex.UseSubFont = false;
			this.m_lblTargetIndex.UseUnitFont = false;
			// 
			// Config_Device
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.m_btnRemove);
			this.Controls.Add(this.m_btnAdd);
			this.Controls.Add(this.m_lblTargetIndex);
			this.Controls.Add(this.m_labelTargetIndex);
			this.Controls.Add(this.m_lblName);
			this.Controls.Add(this.m_labelName);
			this.Controls.Add(this.m_groupConfiguration);
			this.Controls.Add(this.m_dgViewItem);
			this.Controls.Add(this.m_groupItemList);
			this.Controls.Add(this.m_dgViewDevice);
			this.Controls.Add(this.m_groupDeviceList);
			this.Controls.Add(this.m_dgViewTask);
			this.Controls.Add(this.m_groupTaskList);
			this.Name = "Config_Device";
			this.Size = new System.Drawing.Size(1140, 900);
			((System.ComponentModel.ISupportInitialize)(this.m_dgViewTask)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.m_dgViewDevice)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.m_dgViewItem)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private Sys3Controls.Sys3DoubleBufferedDataGridView m_dgViewTask;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private Sys3Controls.Sys3GroupBox m_groupTaskList;
		private Sys3Controls.Sys3GroupBox m_groupDeviceList;
		private Sys3Controls.Sys3DoubleBufferedDataGridView m_dgViewDevice;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
		private Sys3Controls.Sys3DoubleBufferedDataGridView m_dgViewItem;
		private Sys3Controls.Sys3GroupBox m_groupItemList;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
		private System.Windows.Forms.DataGridViewTextBoxColumn POST_SKIP;
		private Sys3Controls.Sys3Label m_lblName;
		private Sys3Controls.Sys3Label m_labelName;
		private Sys3Controls.Sys3GroupBox m_groupConfiguration;
		private Sys3Controls.Sys3button m_btnRemove;
		private Sys3Controls.Sys3button m_btnAdd;
		private Sys3Controls.Sys3Label m_labelTargetIndex;
		private Sys3Controls.Sys3Label m_lblTargetIndex;
	}
}
