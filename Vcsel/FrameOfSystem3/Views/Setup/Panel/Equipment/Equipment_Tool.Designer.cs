namespace FrameOfSystem3.Views.Setup.Equipment
{
    partial class Equipment_Tool
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
			this.grid_ToolMonitor = new Sys3Controls.Sys3DoubleBufferedDataGridView();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btn_Refresh = new Sys3Controls.Sys3button();
			this.lbl_SelectedItem = new Sys3Controls.Sys3Label();
			this.sys3Label17 = new Sys3Controls.Sys3Label();
			this.lbl_ID = new Sys3Controls.Sys3Label();
			this.sys3Label2 = new Sys3Controls.Sys3Label();
			this.lbl_Current = new Sys3Controls.Sys3Label();
			this.sys3Label15 = new Sys3Controls.Sys3Label();
			this.btn_CurrentReset = new Sys3Controls.Sys3button();
			this.lbl_CountError = new Sys3Controls.Sys3Label();
			this.lbl_HourError = new Sys3Controls.Sys3Label();
			this.lbl_DayError = new Sys3Controls.Sys3Label();
			this.lbl_HourWarning = new Sys3Controls.Sys3Label();
			this.lbl_DayWarning = new Sys3Controls.Sys3Label();
			this.lbl_CountWarning = new Sys3Controls.Sys3Label();
			this.sys3Label12 = new Sys3Controls.Sys3Label();
			this.sys3Label13 = new Sys3Controls.Sys3Label();
			this.sys3Label11 = new Sys3Controls.Sys3Label();
			this.sys3Label6 = new Sys3Controls.Sys3Label();
			this.sys3Label14 = new Sys3Controls.Sys3Label();
			this.sys3Label5 = new Sys3Controls.Sys3Label();
			((System.ComponentModel.ISupportInitialize)(this.grid_ToolMonitor)).BeginInit();
			this.SuspendLayout();
			// 
			// grid_ToolMonitor
			// 
			this.grid_ToolMonitor.AllowUserToAddRows = false;
			this.grid_ToolMonitor.AllowUserToDeleteRows = false;
			this.grid_ToolMonitor.AllowUserToResizeColumns = false;
			this.grid_ToolMonitor.AllowUserToResizeRows = false;
			this.grid_ToolMonitor.BackgroundColor = System.Drawing.Color.White;
			this.grid_ToolMonitor.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
			this.grid_ToolMonitor.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.grid_ToolMonitor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.grid_ToolMonitor.ColumnHeadersHeight = 30;
			this.grid_ToolMonitor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.grid_ToolMonitor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn4,
            this.Column1,
            this.Column3,
            this.Column2,
            this.Column4,
            this.Column5,
            this.Column6});
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.grid_ToolMonitor.DefaultCellStyle = dataGridViewCellStyle2;
			this.grid_ToolMonitor.EnableHeadersVisualStyles = false;
			this.grid_ToolMonitor.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
			this.grid_ToolMonitor.Location = new System.Drawing.Point(0, 163);
			this.grid_ToolMonitor.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
			this.grid_ToolMonitor.MultiSelect = false;
			this.grid_ToolMonitor.Name = "grid_ToolMonitor";
			this.grid_ToolMonitor.ReadOnly = true;
			this.grid_ToolMonitor.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("맑은 고딕", 11F);
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.grid_ToolMonitor.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.grid_ToolMonitor.RowHeadersVisible = false;
			this.grid_ToolMonitor.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.grid_ToolMonitor.RowTemplate.Height = 30;
			this.grid_ToolMonitor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.grid_ToolMonitor.Size = new System.Drawing.Size(1140, 637);
			this.grid_ToolMonitor.TabIndex = 21087;
			this.grid_ToolMonitor.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SelectItem);
			// 
			// dataGridViewTextBoxColumn2
			// 
			this.dataGridViewTextBoxColumn2.Frozen = true;
			this.dataGridViewTextBoxColumn2.HeaderText = "No.";
			this.dataGridViewTextBoxColumn2.MaxInputLength = 30;
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn2.Width = 50;
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
			// Column1
			// 
			this.Column1.HeaderText = "ID";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// Column3
			// 
			this.Column3.HeaderText = "STATE";
			this.Column3.Name = "Column3";
			this.Column3.ReadOnly = true;
			this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
			this.Column3.Width = 140;
			// 
			// Column2
			// 
			this.Column2.HeaderText = "TYPE";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Column2.Width = 120;
			// 
			// Column4
			// 
			this.Column4.HeaderText = "CURRENT";
			this.Column4.Name = "Column4";
			this.Column4.ReadOnly = true;
			this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Column4.Width = 150;
			// 
			// Column5
			// 
			this.Column5.HeaderText = "WARNING";
			this.Column5.Name = "Column5";
			this.Column5.ReadOnly = true;
			this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Column5.Width = 150;
			// 
			// Column6
			// 
			this.Column6.HeaderText = "ERROR";
			this.Column6.Name = "Column6";
			this.Column6.ReadOnly = true;
			this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Column6.Width = 150;
			// 
			// btn_Refresh
			// 
			this.btn_Refresh.BorderWidth = 3;
			this.btn_Refresh.ButtonClicked = false;
			this.btn_Refresh.ClickedEmphasizeTextColor = System.Drawing.Color.White;
			this.btn_Refresh.CustomClickedGradientFirstColor = System.Drawing.Color.White;
			this.btn_Refresh.CustomClickedGradientSecondColor = System.Drawing.Color.White;
			this.btn_Refresh.Description = "";
			this.btn_Refresh.DisabledColor = System.Drawing.Color.DarkGray;
			this.btn_Refresh.EdgeRadius = 5;
			this.btn_Refresh.GradientAngle = 70F;
			this.btn_Refresh.GradientFirstColor = System.Drawing.Color.White;
			this.btn_Refresh.GradientSecondColor = System.Drawing.Color.MidnightBlue;
			this.btn_Refresh.HoverEmphasizeCustomColor = System.Drawing.Color.White;
			this.btn_Refresh.ImagePosition = new System.Drawing.Point(7, 7);
			this.btn_Refresh.ImageSize = new System.Drawing.Point(30, 30);
			this.btn_Refresh.LoadImage = global::FrameOfSystem3.Properties.Resources.refresh_52px;
			this.btn_Refresh.Location = new System.Drawing.Point(1004, 120);
			this.btn_Refresh.MainFont = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
			this.btn_Refresh.MainFontColor = System.Drawing.Color.White;
			this.btn_Refresh.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
			this.btn_Refresh.Name = "btn_Refresh";
			this.btn_Refresh.Size = new System.Drawing.Size(136, 42);
			this.btn_Refresh.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
			this.btn_Refresh.SubFontColor = System.Drawing.Color.DarkBlue;
			this.btn_Refresh.SubText = "STATUS";
			this.btn_Refresh.TabIndex = 21088;
			this.btn_Refresh.Text = "REFRESH";
			this.btn_Refresh.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
			this.btn_Refresh.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.btn_Refresh.ThemeIndex = 0;
			this.btn_Refresh.UseBorder = true;
			this.btn_Refresh.UseClickedEmphasizeTextColor = false;
			this.btn_Refresh.UseCustomizeClickedColor = false;
			this.btn_Refresh.UseEdge = true;
			this.btn_Refresh.UseHoverEmphasizeCustomColor = false;
			this.btn_Refresh.UseImage = true;
			this.btn_Refresh.UserHoverEmpahsize = false;
			this.btn_Refresh.UseSubFont = false;
			this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
			// 
			// lbl_SelectedItem
			// 
			this.lbl_SelectedItem.BackGroundColor = System.Drawing.Color.White;
			this.lbl_SelectedItem.BorderStroke = 2;
			this.lbl_SelectedItem.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.lbl_SelectedItem.Description = "";
			this.lbl_SelectedItem.DisabledColor = System.Drawing.Color.DarkGray;
			this.lbl_SelectedItem.EdgeRadius = 1;
			this.lbl_SelectedItem.ImagePosition = new System.Drawing.Point(0, 0);
			this.lbl_SelectedItem.ImageSize = new System.Drawing.Point(0, 0);
			this.lbl_SelectedItem.LoadImage = null;
			this.lbl_SelectedItem.Location = new System.Drawing.Point(186, 6);
			this.lbl_SelectedItem.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.lbl_SelectedItem.MainFontColor = System.Drawing.Color.Black;
			this.lbl_SelectedItem.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
			this.lbl_SelectedItem.Name = "lbl_SelectedItem";
			this.lbl_SelectedItem.Size = new System.Drawing.Size(420, 30);
			this.lbl_SelectedItem.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.lbl_SelectedItem.SubFontColor = System.Drawing.Color.DarkRed;
			this.lbl_SelectedItem.SubText = "";
			this.lbl_SelectedItem.TabIndex = 21089;
			this.lbl_SelectedItem.Tag = "";
			this.lbl_SelectedItem.Text = "--";
			this.lbl_SelectedItem.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
			this.lbl_SelectedItem.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.lbl_SelectedItem.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.lbl_SelectedItem.ThemeIndex = 0;
			this.lbl_SelectedItem.UnitAreaRate = 40;
			this.lbl_SelectedItem.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.lbl_SelectedItem.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.lbl_SelectedItem.UnitPositionVertical = false;
			this.lbl_SelectedItem.UnitText = "";
			this.lbl_SelectedItem.UseBorder = true;
			this.lbl_SelectedItem.UseEdgeRadius = false;
			this.lbl_SelectedItem.UseImage = false;
			this.lbl_SelectedItem.UseSubFont = true;
			this.lbl_SelectedItem.UseUnitFont = false;
			this.lbl_SelectedItem.Click += new System.EventHandler(this.lbl_SelectedItem_Click);
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
			this.sys3Label17.Location = new System.Drawing.Point(6, 6);
			this.sys3Label17.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.sys3Label17.MainFontColor = System.Drawing.Color.Black;
			this.sys3Label17.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
			this.sys3Label17.Name = "sys3Label17";
			this.sys3Label17.Size = new System.Drawing.Size(179, 30);
			this.sys3Label17.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.sys3Label17.SubFontColor = System.Drawing.Color.DarkRed;
			this.sys3Label17.SubText = "";
			this.sys3Label17.TabIndex = 21090;
			this.sys3Label17.Tag = "";
			this.sys3Label17.Text = "SELECTED ITEM";
			this.sys3Label17.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
			this.sys3Label17.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
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
			// lbl_ID
			// 
			this.lbl_ID.BackGroundColor = System.Drawing.Color.White;
			this.lbl_ID.BorderStroke = 2;
			this.lbl_ID.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.lbl_ID.Description = "";
			this.lbl_ID.DisabledColor = System.Drawing.Color.DarkGray;
			this.lbl_ID.EdgeRadius = 1;
			this.lbl_ID.ImagePosition = new System.Drawing.Point(0, 0);
			this.lbl_ID.ImageSize = new System.Drawing.Point(0, 0);
			this.lbl_ID.LoadImage = null;
			this.lbl_ID.Location = new System.Drawing.Point(186, 37);
			this.lbl_ID.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.lbl_ID.MainFontColor = System.Drawing.Color.Black;
			this.lbl_ID.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
			this.lbl_ID.Name = "lbl_ID";
			this.lbl_ID.Size = new System.Drawing.Size(420, 30);
			this.lbl_ID.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.lbl_ID.SubFontColor = System.Drawing.Color.DarkRed;
			this.lbl_ID.SubText = "";
			this.lbl_ID.TabIndex = 21091;
			this.lbl_ID.Tag = "";
			this.lbl_ID.Text = "--";
			this.lbl_ID.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
			this.lbl_ID.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.lbl_ID.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.lbl_ID.ThemeIndex = 0;
			this.lbl_ID.UnitAreaRate = 40;
			this.lbl_ID.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.lbl_ID.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.lbl_ID.UnitPositionVertical = false;
			this.lbl_ID.UnitText = "";
			this.lbl_ID.UseBorder = true;
			this.lbl_ID.UseEdgeRadius = false;
			this.lbl_ID.UseImage = false;
			this.lbl_ID.UseSubFont = true;
			this.lbl_ID.UseUnitFont = false;
			this.lbl_ID.Click += new System.EventHandler(this.lbl_ID_Click);
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
			this.sys3Label2.Location = new System.Drawing.Point(6, 37);
			this.sys3Label2.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.sys3Label2.MainFontColor = System.Drawing.Color.Black;
			this.sys3Label2.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
			this.sys3Label2.Name = "sys3Label2";
			this.sys3Label2.Size = new System.Drawing.Size(179, 30);
			this.sys3Label2.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.sys3Label2.SubFontColor = System.Drawing.Color.DarkRed;
			this.sys3Label2.SubText = "";
			this.sys3Label2.TabIndex = 21092;
			this.sys3Label2.Tag = "";
			this.sys3Label2.Text = "ID";
			this.sys3Label2.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
			this.sys3Label2.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
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
			// lbl_Current
			// 
			this.lbl_Current.BackGroundColor = System.Drawing.Color.White;
			this.lbl_Current.BorderStroke = 2;
			this.lbl_Current.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.lbl_Current.Description = "";
			this.lbl_Current.DisabledColor = System.Drawing.Color.DarkGray;
			this.lbl_Current.EdgeRadius = 1;
			this.lbl_Current.ImagePosition = new System.Drawing.Point(0, 0);
			this.lbl_Current.ImageSize = new System.Drawing.Point(0, 0);
			this.lbl_Current.LoadImage = null;
			this.lbl_Current.Location = new System.Drawing.Point(186, 68);
			this.lbl_Current.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.lbl_Current.MainFontColor = System.Drawing.Color.Black;
			this.lbl_Current.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
			this.lbl_Current.Name = "lbl_Current";
			this.lbl_Current.Size = new System.Drawing.Size(420, 30);
			this.lbl_Current.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.lbl_Current.SubFontColor = System.Drawing.Color.DarkRed;
			this.lbl_Current.SubText = "";
			this.lbl_Current.TabIndex = 21093;
			this.lbl_Current.Tag = "";
			this.lbl_Current.Text = "--";
			this.lbl_Current.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
			this.lbl_Current.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.lbl_Current.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.lbl_Current.ThemeIndex = 0;
			this.lbl_Current.UnitAreaRate = 40;
			this.lbl_Current.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.lbl_Current.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.lbl_Current.UnitPositionVertical = false;
			this.lbl_Current.UnitText = "";
			this.lbl_Current.UseBorder = true;
			this.lbl_Current.UseEdgeRadius = false;
			this.lbl_Current.UseImage = false;
			this.lbl_Current.UseSubFont = true;
			this.lbl_Current.UseUnitFont = false;
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
			this.sys3Label15.Location = new System.Drawing.Point(6, 68);
			this.sys3Label15.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.sys3Label15.MainFontColor = System.Drawing.Color.Black;
			this.sys3Label15.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
			this.sys3Label15.Name = "sys3Label15";
			this.sys3Label15.Size = new System.Drawing.Size(179, 30);
			this.sys3Label15.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.sys3Label15.SubFontColor = System.Drawing.Color.DarkRed;
			this.sys3Label15.SubText = "";
			this.sys3Label15.TabIndex = 21094;
			this.sys3Label15.Tag = "";
			this.sys3Label15.Text = "CURRENT";
			this.sys3Label15.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
			this.sys3Label15.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
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
			// btn_CurrentReset
			// 
			this.btn_CurrentReset.BorderWidth = 3;
			this.btn_CurrentReset.ButtonClicked = false;
			this.btn_CurrentReset.ClickedEmphasizeTextColor = System.Drawing.Color.White;
			this.btn_CurrentReset.CustomClickedGradientFirstColor = System.Drawing.Color.White;
			this.btn_CurrentReset.CustomClickedGradientSecondColor = System.Drawing.Color.White;
			this.btn_CurrentReset.Description = "";
			this.btn_CurrentReset.DisabledColor = System.Drawing.Color.DarkGray;
			this.btn_CurrentReset.EdgeRadius = 5;
			this.btn_CurrentReset.GradientAngle = 70F;
			this.btn_CurrentReset.GradientFirstColor = System.Drawing.Color.White;
			this.btn_CurrentReset.GradientSecondColor = System.Drawing.Color.DarkRed;
			this.btn_CurrentReset.HoverEmphasizeCustomColor = System.Drawing.Color.White;
			this.btn_CurrentReset.ImagePosition = new System.Drawing.Point(10, 8);
			this.btn_CurrentReset.ImageSize = new System.Drawing.Point(15, 15);
			this.btn_CurrentReset.LoadImage = global::FrameOfSystem3.Properties.Resources.refresh_52px;
			this.btn_CurrentReset.Location = new System.Drawing.Point(509, 99);
			this.btn_CurrentReset.MainFont = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
			this.btn_CurrentReset.MainFontColor = System.Drawing.Color.White;
			this.btn_CurrentReset.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
			this.btn_CurrentReset.Name = "btn_CurrentReset";
			this.btn_CurrentReset.Size = new System.Drawing.Size(97, 30);
			this.btn_CurrentReset.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
			this.btn_CurrentReset.SubFontColor = System.Drawing.Color.DarkBlue;
			this.btn_CurrentReset.SubText = "STATUS";
			this.btn_CurrentReset.TabIndex = 21095;
			this.btn_CurrentReset.Text = "RESET";
			this.btn_CurrentReset.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
			this.btn_CurrentReset.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.btn_CurrentReset.ThemeIndex = 0;
			this.btn_CurrentReset.UseBorder = true;
			this.btn_CurrentReset.UseClickedEmphasizeTextColor = false;
			this.btn_CurrentReset.UseCustomizeClickedColor = false;
			this.btn_CurrentReset.UseEdge = true;
			this.btn_CurrentReset.UseHoverEmphasizeCustomColor = false;
			this.btn_CurrentReset.UseImage = false;
			this.btn_CurrentReset.UserHoverEmpahsize = false;
			this.btn_CurrentReset.UseSubFont = false;
			this.btn_CurrentReset.Click += new System.EventHandler(this.btn_CurrentReset_Click);
			// 
			// lbl_CountError
			// 
			this.lbl_CountError.BackGroundColor = System.Drawing.Color.White;
			this.lbl_CountError.BorderStroke = 2;
			this.lbl_CountError.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.lbl_CountError.Description = "";
			this.lbl_CountError.DisabledColor = System.Drawing.Color.DarkGray;
			this.lbl_CountError.EdgeRadius = 1;
			this.lbl_CountError.ImagePosition = new System.Drawing.Point(0, 0);
			this.lbl_CountError.ImageSize = new System.Drawing.Point(0, 0);
			this.lbl_CountError.LoadImage = null;
			this.lbl_CountError.Location = new System.Drawing.Point(803, 68);
			this.lbl_CountError.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.lbl_CountError.MainFontColor = System.Drawing.Color.Black;
			this.lbl_CountError.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
			this.lbl_CountError.Name = "lbl_CountError";
			this.lbl_CountError.Size = new System.Drawing.Size(130, 30);
			this.lbl_CountError.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.lbl_CountError.SubFontColor = System.Drawing.Color.DarkRed;
			this.lbl_CountError.SubText = "";
			this.lbl_CountError.TabIndex = 21096;
			this.lbl_CountError.Tag = "";
			this.lbl_CountError.Text = "--";
			this.lbl_CountError.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.lbl_CountError.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.lbl_CountError.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.lbl_CountError.ThemeIndex = 0;
			this.lbl_CountError.UnitAreaRate = 40;
			this.lbl_CountError.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.lbl_CountError.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.lbl_CountError.UnitPositionVertical = false;
			this.lbl_CountError.UnitText = "";
			this.lbl_CountError.UseBorder = true;
			this.lbl_CountError.UseEdgeRadius = false;
			this.lbl_CountError.UseImage = false;
			this.lbl_CountError.UseSubFont = true;
			this.lbl_CountError.UseUnitFont = false;
			this.lbl_CountError.Click += new System.EventHandler(this.lbl_Count_Click);
			// 
			// lbl_HourError
			// 
			this.lbl_HourError.BackGroundColor = System.Drawing.Color.White;
			this.lbl_HourError.BorderStroke = 2;
			this.lbl_HourError.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.lbl_HourError.Description = "";
			this.lbl_HourError.DisabledColor = System.Drawing.Color.DarkGray;
			this.lbl_HourError.EdgeRadius = 1;
			this.lbl_HourError.ImagePosition = new System.Drawing.Point(0, 0);
			this.lbl_HourError.ImageSize = new System.Drawing.Point(0, 0);
			this.lbl_HourError.LoadImage = null;
			this.lbl_HourError.Location = new System.Drawing.Point(1035, 68);
			this.lbl_HourError.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.lbl_HourError.MainFontColor = System.Drawing.Color.Black;
			this.lbl_HourError.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
			this.lbl_HourError.Name = "lbl_HourError";
			this.lbl_HourError.Size = new System.Drawing.Size(100, 30);
			this.lbl_HourError.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.lbl_HourError.SubFontColor = System.Drawing.Color.DarkRed;
			this.lbl_HourError.SubText = "";
			this.lbl_HourError.TabIndex = 21097;
			this.lbl_HourError.Tag = "";
			this.lbl_HourError.Text = "--";
			this.lbl_HourError.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.lbl_HourError.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.lbl_HourError.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.lbl_HourError.ThemeIndex = 0;
			this.lbl_HourError.UnitAreaRate = 40;
			this.lbl_HourError.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.lbl_HourError.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.lbl_HourError.UnitPositionVertical = false;
			this.lbl_HourError.UnitText = "";
			this.lbl_HourError.UseBorder = true;
			this.lbl_HourError.UseEdgeRadius = false;
			this.lbl_HourError.UseImage = false;
			this.lbl_HourError.UseSubFont = true;
			this.lbl_HourError.UseUnitFont = false;
			this.lbl_HourError.Click += new System.EventHandler(this.lbl_Hour_Click);
			// 
			// lbl_DayError
			// 
			this.lbl_DayError.BackGroundColor = System.Drawing.Color.White;
			this.lbl_DayError.BorderStroke = 2;
			this.lbl_DayError.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.lbl_DayError.Description = "";
			this.lbl_DayError.DisabledColor = System.Drawing.Color.DarkGray;
			this.lbl_DayError.EdgeRadius = 1;
			this.lbl_DayError.ImagePosition = new System.Drawing.Point(0, 0);
			this.lbl_DayError.ImageSize = new System.Drawing.Point(0, 0);
			this.lbl_DayError.LoadImage = null;
			this.lbl_DayError.Location = new System.Drawing.Point(934, 68);
			this.lbl_DayError.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.lbl_DayError.MainFontColor = System.Drawing.Color.Black;
			this.lbl_DayError.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
			this.lbl_DayError.Name = "lbl_DayError";
			this.lbl_DayError.Size = new System.Drawing.Size(100, 30);
			this.lbl_DayError.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.lbl_DayError.SubFontColor = System.Drawing.Color.DarkRed;
			this.lbl_DayError.SubText = "";
			this.lbl_DayError.TabIndex = 21098;
			this.lbl_DayError.Tag = "";
			this.lbl_DayError.Text = "--";
			this.lbl_DayError.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.lbl_DayError.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.lbl_DayError.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.lbl_DayError.ThemeIndex = 0;
			this.lbl_DayError.UnitAreaRate = 40;
			this.lbl_DayError.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.lbl_DayError.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.lbl_DayError.UnitPositionVertical = false;
			this.lbl_DayError.UnitText = "";
			this.lbl_DayError.UseBorder = true;
			this.lbl_DayError.UseEdgeRadius = false;
			this.lbl_DayError.UseImage = false;
			this.lbl_DayError.UseSubFont = true;
			this.lbl_DayError.UseUnitFont = false;
			this.lbl_DayError.Click += new System.EventHandler(this.lbl_Day_Click);
			// 
			// lbl_HourWarning
			// 
			this.lbl_HourWarning.BackGroundColor = System.Drawing.Color.White;
			this.lbl_HourWarning.BorderStroke = 2;
			this.lbl_HourWarning.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.lbl_HourWarning.Description = "";
			this.lbl_HourWarning.DisabledColor = System.Drawing.Color.DarkGray;
			this.lbl_HourWarning.EdgeRadius = 1;
			this.lbl_HourWarning.ImagePosition = new System.Drawing.Point(0, 0);
			this.lbl_HourWarning.ImageSize = new System.Drawing.Point(0, 0);
			this.lbl_HourWarning.LoadImage = null;
			this.lbl_HourWarning.Location = new System.Drawing.Point(1035, 37);
			this.lbl_HourWarning.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.lbl_HourWarning.MainFontColor = System.Drawing.Color.Black;
			this.lbl_HourWarning.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
			this.lbl_HourWarning.Name = "lbl_HourWarning";
			this.lbl_HourWarning.Size = new System.Drawing.Size(100, 30);
			this.lbl_HourWarning.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.lbl_HourWarning.SubFontColor = System.Drawing.Color.DarkRed;
			this.lbl_HourWarning.SubText = "";
			this.lbl_HourWarning.TabIndex = 21099;
			this.lbl_HourWarning.Tag = "";
			this.lbl_HourWarning.Text = "--";
			this.lbl_HourWarning.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.lbl_HourWarning.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.lbl_HourWarning.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.lbl_HourWarning.ThemeIndex = 0;
			this.lbl_HourWarning.UnitAreaRate = 40;
			this.lbl_HourWarning.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.lbl_HourWarning.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.lbl_HourWarning.UnitPositionVertical = false;
			this.lbl_HourWarning.UnitText = "";
			this.lbl_HourWarning.UseBorder = true;
			this.lbl_HourWarning.UseEdgeRadius = false;
			this.lbl_HourWarning.UseImage = false;
			this.lbl_HourWarning.UseSubFont = true;
			this.lbl_HourWarning.UseUnitFont = false;
			this.lbl_HourWarning.Click += new System.EventHandler(this.lbl_Hour_Click);
			// 
			// lbl_DayWarning
			// 
			this.lbl_DayWarning.BackGroundColor = System.Drawing.Color.White;
			this.lbl_DayWarning.BorderStroke = 2;
			this.lbl_DayWarning.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.lbl_DayWarning.Description = "";
			this.lbl_DayWarning.DisabledColor = System.Drawing.Color.DarkGray;
			this.lbl_DayWarning.EdgeRadius = 1;
			this.lbl_DayWarning.ImagePosition = new System.Drawing.Point(0, 0);
			this.lbl_DayWarning.ImageSize = new System.Drawing.Point(0, 0);
			this.lbl_DayWarning.LoadImage = null;
			this.lbl_DayWarning.Location = new System.Drawing.Point(934, 37);
			this.lbl_DayWarning.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.lbl_DayWarning.MainFontColor = System.Drawing.Color.Black;
			this.lbl_DayWarning.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
			this.lbl_DayWarning.Name = "lbl_DayWarning";
			this.lbl_DayWarning.Size = new System.Drawing.Size(100, 30);
			this.lbl_DayWarning.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.lbl_DayWarning.SubFontColor = System.Drawing.Color.DarkRed;
			this.lbl_DayWarning.SubText = "";
			this.lbl_DayWarning.TabIndex = 21100;
			this.lbl_DayWarning.Tag = "";
			this.lbl_DayWarning.Text = "--";
			this.lbl_DayWarning.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.lbl_DayWarning.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.lbl_DayWarning.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.lbl_DayWarning.ThemeIndex = 0;
			this.lbl_DayWarning.UnitAreaRate = 40;
			this.lbl_DayWarning.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.lbl_DayWarning.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.lbl_DayWarning.UnitPositionVertical = false;
			this.lbl_DayWarning.UnitText = "";
			this.lbl_DayWarning.UseBorder = true;
			this.lbl_DayWarning.UseEdgeRadius = false;
			this.lbl_DayWarning.UseImage = false;
			this.lbl_DayWarning.UseSubFont = true;
			this.lbl_DayWarning.UseUnitFont = false;
			this.lbl_DayWarning.Click += new System.EventHandler(this.lbl_Day_Click);
			// 
			// lbl_CountWarning
			// 
			this.lbl_CountWarning.BackGroundColor = System.Drawing.Color.White;
			this.lbl_CountWarning.BorderStroke = 2;
			this.lbl_CountWarning.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.lbl_CountWarning.Description = "";
			this.lbl_CountWarning.DisabledColor = System.Drawing.Color.DarkGray;
			this.lbl_CountWarning.EdgeRadius = 1;
			this.lbl_CountWarning.ImagePosition = new System.Drawing.Point(0, 0);
			this.lbl_CountWarning.ImageSize = new System.Drawing.Point(0, 0);
			this.lbl_CountWarning.LoadImage = null;
			this.lbl_CountWarning.Location = new System.Drawing.Point(803, 37);
			this.lbl_CountWarning.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.lbl_CountWarning.MainFontColor = System.Drawing.Color.Black;
			this.lbl_CountWarning.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
			this.lbl_CountWarning.Name = "lbl_CountWarning";
			this.lbl_CountWarning.Size = new System.Drawing.Size(130, 30);
			this.lbl_CountWarning.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.lbl_CountWarning.SubFontColor = System.Drawing.Color.DarkRed;
			this.lbl_CountWarning.SubText = "";
			this.lbl_CountWarning.TabIndex = 21101;
			this.lbl_CountWarning.Tag = "";
			this.lbl_CountWarning.Text = "--";
			this.lbl_CountWarning.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.lbl_CountWarning.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.lbl_CountWarning.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.lbl_CountWarning.ThemeIndex = 0;
			this.lbl_CountWarning.UnitAreaRate = 40;
			this.lbl_CountWarning.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.lbl_CountWarning.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.lbl_CountWarning.UnitPositionVertical = false;
			this.lbl_CountWarning.UnitText = "";
			this.lbl_CountWarning.UseBorder = true;
			this.lbl_CountWarning.UseEdgeRadius = false;
			this.lbl_CountWarning.UseImage = false;
			this.lbl_CountWarning.UseSubFont = true;
			this.lbl_CountWarning.UseUnitFont = false;
			this.lbl_CountWarning.Click += new System.EventHandler(this.lbl_Count_Click);
			// 
			// sys3Label12
			// 
			this.sys3Label12.BackGroundColor = System.Drawing.Color.DarkGray;
			this.sys3Label12.BorderStroke = 2;
			this.sys3Label12.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.sys3Label12.Description = "";
			this.sys3Label12.DisabledColor = System.Drawing.Color.DarkGray;
			this.sys3Label12.EdgeRadius = 1;
			this.sys3Label12.ImagePosition = new System.Drawing.Point(0, 0);
			this.sys3Label12.ImageSize = new System.Drawing.Point(0, 0);
			this.sys3Label12.LoadImage = null;
			this.sys3Label12.Location = new System.Drawing.Point(1035, 6);
			this.sys3Label12.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.sys3Label12.MainFontColor = System.Drawing.Color.Black;
			this.sys3Label12.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
			this.sys3Label12.Name = "sys3Label12";
			this.sys3Label12.Size = new System.Drawing.Size(100, 30);
			this.sys3Label12.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.sys3Label12.SubFontColor = System.Drawing.Color.DarkRed;
			this.sys3Label12.SubText = "";
			this.sys3Label12.TabIndex = 21102;
			this.sys3Label12.Tag = "";
			this.sys3Label12.Text = "HOUR";
			this.sys3Label12.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.sys3Label12.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.sys3Label12.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.sys3Label12.ThemeIndex = 0;
			this.sys3Label12.UnitAreaRate = 40;
			this.sys3Label12.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.sys3Label12.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.sys3Label12.UnitPositionVertical = false;
			this.sys3Label12.UnitText = "";
			this.sys3Label12.UseBorder = true;
			this.sys3Label12.UseEdgeRadius = false;
			this.sys3Label12.UseImage = false;
			this.sys3Label12.UseSubFont = true;
			this.sys3Label12.UseUnitFont = false;
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
			this.sys3Label13.Location = new System.Drawing.Point(803, 6);
			this.sys3Label13.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.sys3Label13.MainFontColor = System.Drawing.Color.Black;
			this.sys3Label13.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
			this.sys3Label13.Name = "sys3Label13";
			this.sys3Label13.Size = new System.Drawing.Size(130, 30);
			this.sys3Label13.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.sys3Label13.SubFontColor = System.Drawing.Color.DarkRed;
			this.sys3Label13.SubText = "";
			this.sys3Label13.TabIndex = 21103;
			this.sys3Label13.Tag = "";
			this.sys3Label13.Text = "COUNT";
			this.sys3Label13.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.sys3Label13.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
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
			// sys3Label11
			// 
			this.sys3Label11.BackGroundColor = System.Drawing.Color.DarkGray;
			this.sys3Label11.BorderStroke = 2;
			this.sys3Label11.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.sys3Label11.Description = "";
			this.sys3Label11.DisabledColor = System.Drawing.Color.DarkGray;
			this.sys3Label11.EdgeRadius = 1;
			this.sys3Label11.ImagePosition = new System.Drawing.Point(0, 0);
			this.sys3Label11.ImageSize = new System.Drawing.Point(0, 0);
			this.sys3Label11.LoadImage = null;
			this.sys3Label11.Location = new System.Drawing.Point(934, 6);
			this.sys3Label11.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.sys3Label11.MainFontColor = System.Drawing.Color.Black;
			this.sys3Label11.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
			this.sys3Label11.Name = "sys3Label11";
			this.sys3Label11.Size = new System.Drawing.Size(100, 30);
			this.sys3Label11.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.sys3Label11.SubFontColor = System.Drawing.Color.DarkRed;
			this.sys3Label11.SubText = "";
			this.sys3Label11.TabIndex = 21104;
			this.sys3Label11.Tag = "";
			this.sys3Label11.Text = "DAY";
			this.sys3Label11.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.sys3Label11.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.sys3Label11.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.sys3Label11.ThemeIndex = 0;
			this.sys3Label11.UnitAreaRate = 40;
			this.sys3Label11.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.sys3Label11.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.sys3Label11.UnitPositionVertical = false;
			this.sys3Label11.UnitText = "";
			this.sys3Label11.UseBorder = true;
			this.sys3Label11.UseEdgeRadius = false;
			this.sys3Label11.UseImage = false;
			this.sys3Label11.UseSubFont = true;
			this.sys3Label11.UseUnitFont = false;
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
			this.sys3Label6.Location = new System.Drawing.Point(623, 68);
			this.sys3Label6.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.sys3Label6.MainFontColor = System.Drawing.Color.Black;
			this.sys3Label6.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
			this.sys3Label6.Name = "sys3Label6";
			this.sys3Label6.Size = new System.Drawing.Size(179, 30);
			this.sys3Label6.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.sys3Label6.SubFontColor = System.Drawing.Color.DarkRed;
			this.sys3Label6.SubText = "";
			this.sys3Label6.TabIndex = 21105;
			this.sys3Label6.Tag = "";
			this.sys3Label6.Text = "ERROR";
			this.sys3Label6.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
			this.sys3Label6.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
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
			this.sys3Label14.Location = new System.Drawing.Point(623, 6);
			this.sys3Label14.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.sys3Label14.MainFontColor = System.Drawing.Color.Black;
			this.sys3Label14.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
			this.sys3Label14.Name = "sys3Label14";
			this.sys3Label14.Size = new System.Drawing.Size(179, 30);
			this.sys3Label14.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.sys3Label14.SubFontColor = System.Drawing.Color.DarkRed;
			this.sys3Label14.SubText = "";
			this.sys3Label14.TabIndex = 21106;
			this.sys3Label14.Tag = "";
			this.sys3Label14.Text = "LIMIT COUNT";
			this.sys3Label14.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
			this.sys3Label14.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
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
			// sys3Label5
			// 
			this.sys3Label5.BackGroundColor = System.Drawing.Color.DarkGray;
			this.sys3Label5.BorderStroke = 2;
			this.sys3Label5.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.sys3Label5.Description = "";
			this.sys3Label5.DisabledColor = System.Drawing.Color.DarkGray;
			this.sys3Label5.EdgeRadius = 1;
			this.sys3Label5.ImagePosition = new System.Drawing.Point(0, 0);
			this.sys3Label5.ImageSize = new System.Drawing.Point(0, 0);
			this.sys3Label5.LoadImage = null;
			this.sys3Label5.Location = new System.Drawing.Point(623, 37);
			this.sys3Label5.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.sys3Label5.MainFontColor = System.Drawing.Color.Black;
			this.sys3Label5.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
			this.sys3Label5.Name = "sys3Label5";
			this.sys3Label5.Size = new System.Drawing.Size(179, 30);
			this.sys3Label5.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.sys3Label5.SubFontColor = System.Drawing.Color.DarkRed;
			this.sys3Label5.SubText = "";
			this.sys3Label5.TabIndex = 21107;
			this.sys3Label5.Tag = "";
			this.sys3Label5.Text = "WARNING";
			this.sys3Label5.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
			this.sys3Label5.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.sys3Label5.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.sys3Label5.ThemeIndex = 0;
			this.sys3Label5.UnitAreaRate = 40;
			this.sys3Label5.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
			this.sys3Label5.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.sys3Label5.UnitPositionVertical = false;
			this.sys3Label5.UnitText = "";
			this.sys3Label5.UseBorder = true;
			this.sys3Label5.UseEdgeRadius = false;
			this.sys3Label5.UseImage = false;
			this.sys3Label5.UseSubFont = true;
			this.sys3Label5.UseUnitFont = false;
			// 
			// SetupToolMonitor
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.lbl_CountError);
			this.Controls.Add(this.lbl_HourError);
			this.Controls.Add(this.lbl_DayError);
			this.Controls.Add(this.lbl_HourWarning);
			this.Controls.Add(this.lbl_DayWarning);
			this.Controls.Add(this.lbl_CountWarning);
			this.Controls.Add(this.sys3Label12);
			this.Controls.Add(this.sys3Label13);
			this.Controls.Add(this.sys3Label11);
			this.Controls.Add(this.sys3Label6);
			this.Controls.Add(this.sys3Label14);
			this.Controls.Add(this.sys3Label5);
			this.Controls.Add(this.btn_CurrentReset);
			this.Controls.Add(this.lbl_Current);
			this.Controls.Add(this.sys3Label15);
			this.Controls.Add(this.lbl_ID);
			this.Controls.Add(this.sys3Label2);
			this.Controls.Add(this.lbl_SelectedItem);
			this.Controls.Add(this.sys3Label17);
			this.Controls.Add(this.btn_Refresh);
			this.Controls.Add(this.grid_ToolMonitor);
			this.Name = "SetupToolMonitor";
			this.Padding = new System.Windows.Forms.Padding(5);
			this.Size = new System.Drawing.Size(1140, 800);
			this.Tag = "MONITOR";
			((System.ComponentModel.ISupportInitialize)(this.grid_ToolMonitor)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private Sys3Controls.Sys3DoubleBufferedDataGridView grid_ToolMonitor;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
		private Sys3Controls.Sys3button btn_Refresh;
		private Sys3Controls.Sys3Label lbl_SelectedItem;
		private Sys3Controls.Sys3Label sys3Label17;
		private Sys3Controls.Sys3Label lbl_ID;
		private Sys3Controls.Sys3Label sys3Label2;
		private Sys3Controls.Sys3Label lbl_Current;
		private Sys3Controls.Sys3Label sys3Label15;
		private Sys3Controls.Sys3button btn_CurrentReset;
		private Sys3Controls.Sys3Label lbl_CountError;
		private Sys3Controls.Sys3Label lbl_HourError;
		private Sys3Controls.Sys3Label lbl_DayError;
		private Sys3Controls.Sys3Label lbl_HourWarning;
		private Sys3Controls.Sys3Label lbl_DayWarning;
		private Sys3Controls.Sys3Label lbl_CountWarning;
		private Sys3Controls.Sys3Label sys3Label12;
		private Sys3Controls.Sys3Label sys3Label13;
		private Sys3Controls.Sys3Label sys3Label11;
		private Sys3Controls.Sys3Label sys3Label6;
		private Sys3Controls.Sys3Label sys3Label14;
		private Sys3Controls.Sys3Label sys3Label5;



	}
}
