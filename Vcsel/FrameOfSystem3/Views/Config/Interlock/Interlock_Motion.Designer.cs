namespace FrameOfSystem3.Views.Config
{
    partial class Interlock_Motion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.m_dgViewMotion = new Sys3Controls.Sys3DoubleBufferedDataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ENABLE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_groupTaskList = new Sys3Controls.Sys3GroupBox();
            this.m_groupDeviceList = new Sys3Controls.Sys3GroupBox();
            this.m_dgViewCondition = new Sys3Controls.Sys3DoubleBufferedDataGridView();
            this.m_btnAdd = new Sys3Controls.Sys3button();
            this.sys3button1 = new Sys3Controls.Sys3button();
            this.sys3GroupBox1 = new Sys3Controls.Sys3GroupBox();
            this.m_dgViewCompareCondition = new Sys3Controls.Sys3DoubleBufferedDataGridView();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Device = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RELATIVE_INDEX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DIRECTION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POSITION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sys3button3 = new Sys3Controls.Sys3button();
            this.m_groupItemList = new Sys3Controls.Sys3GroupBox();
            this.sys3button2 = new Sys3Controls.Sys3button();
            this.m_dgViewCompareGroup = new Sys3Controls.Sys3DoubleBufferedDataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POST_SKIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_btnStop = new Sys3Controls.Sys3button();
            this.sys3button4 = new Sys3Controls.Sys3button();
            this.sys3button5 = new Sys3Controls.Sys3button();
            this.sys3button6 = new Sys3Controls.Sys3button();
            this.sys3button7 = new Sys3Controls.Sys3button();
            this.sys3button8 = new Sys3Controls.Sys3button();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Postion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.START = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgViewMotion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgViewCondition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgViewCompareCondition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgViewCompareGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // m_dgViewMotion
            // 
            this.m_dgViewMotion.AllowUserToAddRows = false;
            this.m_dgViewMotion.AllowUserToDeleteRows = false;
            this.m_dgViewMotion.AllowUserToResizeColumns = false;
            this.m_dgViewMotion.AllowUserToResizeRows = false;
            this.m_dgViewMotion.BackgroundColor = System.Drawing.Color.White;
            this.m_dgViewMotion.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.m_dgViewMotion.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_dgViewMotion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.m_dgViewMotion.ColumnHeadersHeight = 30;
            this.m_dgViewMotion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.m_dgViewMotion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.ENABLE,
            this.dataGridViewTextBoxColumn2});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.m_dgViewMotion.DefaultCellStyle = dataGridViewCellStyle2;
            this.m_dgViewMotion.EnableHeadersVisualStyles = false;
            this.m_dgViewMotion.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            this.m_dgViewMotion.Location = new System.Drawing.Point(2, 31);
            this.m_dgViewMotion.MultiSelect = false;
            this.m_dgViewMotion.Name = "m_dgViewMotion";
            this.m_dgViewMotion.ReadOnly = true;
            this.m_dgViewMotion.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("맑은 고딕", 11F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_dgViewMotion.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.m_dgViewMotion.RowHeadersVisible = false;
            this.m_dgViewMotion.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.m_dgViewMotion.RowTemplate.Height = 30;
            this.m_dgViewMotion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgViewMotion.Size = new System.Drawing.Size(559, 318);
            this.m_dgViewMotion.TabIndex = 1372;
            this.m_dgViewMotion.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Click_MotionGrid);
            this.m_dgViewMotion.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DoubleClick_MotionGrid);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "INDEX";
            this.dataGridViewTextBoxColumn1.MaxInputLength = 10;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ENABLE
            // 
            this.ENABLE.HeaderText = "ENABLE";
            this.ENABLE.Name = "ENABLE";
            this.ENABLE.ReadOnly = true;
            this.ENABLE.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ENABLE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            this.m_groupTaskList.Size = new System.Drawing.Size(564, 424);
            this.m_groupTaskList.TabIndex = 1373;
            this.m_groupTaskList.Text = "MOTION LIST";
            this.m_groupTaskList.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_groupTaskList.ThemeIndex = 0;
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
            this.m_groupDeviceList.Location = new System.Drawing.Point(0, 429);
            this.m_groupDeviceList.Name = "m_groupDeviceList";
            this.m_groupDeviceList.Size = new System.Drawing.Size(563, 420);
            this.m_groupDeviceList.TabIndex = 1373;
            this.m_groupDeviceList.Text = "INTERLOCK CONDITION LIST";
            this.m_groupDeviceList.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_groupDeviceList.ThemeIndex = 0;
            this.m_groupDeviceList.UseLabelBorder = true;
            // 
            // m_dgViewCondition
            // 
            this.m_dgViewCondition.AllowUserToAddRows = false;
            this.m_dgViewCondition.AllowUserToDeleteRows = false;
            this.m_dgViewCondition.AllowUserToResizeColumns = false;
            this.m_dgViewCondition.AllowUserToResizeRows = false;
            this.m_dgViewCondition.BackgroundColor = System.Drawing.Color.White;
            this.m_dgViewCondition.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.m_dgViewCondition.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_dgViewCondition.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.m_dgViewCondition.ColumnHeadersHeight = 40;
            this.m_dgViewCondition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.m_dgViewCondition.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.Column1,
            this.Postion,
            this.START,
            this.Column2});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.m_dgViewCondition.DefaultCellStyle = dataGridViewCellStyle5;
            this.m_dgViewCondition.EnableHeadersVisualStyles = false;
            this.m_dgViewCondition.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            this.m_dgViewCondition.Location = new System.Drawing.Point(2, 461);
            this.m_dgViewCondition.MultiSelect = false;
            this.m_dgViewCondition.Name = "m_dgViewCondition";
            this.m_dgViewCondition.ReadOnly = true;
            this.m_dgViewCondition.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("맑은 고딕", 11F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_dgViewCondition.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.m_dgViewCondition.RowHeadersVisible = false;
            this.m_dgViewCondition.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.m_dgViewCondition.RowTemplate.Height = 30;
            this.m_dgViewCondition.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgViewCondition.Size = new System.Drawing.Size(559, 318);
            this.m_dgViewCondition.TabIndex = 1372;
            this.m_dgViewCondition.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Click_InterlockConditionGrid);
            this.m_dgViewCondition.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DoubleClick_InterLockConditionGrid);
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
            this.m_btnAdd.Location = new System.Drawing.Point(253, 355);
            this.m_btnAdd.MainFont = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.m_btnAdd.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
            this.m_btnAdd.Name = "m_btnAdd";
            this.m_btnAdd.Size = new System.Drawing.Size(147, 56);
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
            this.m_btnAdd.Click += new System.EventHandler(this.Click_AddButton);
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
            this.sys3button1.EdgeRadius = 5;
            this.sys3button1.GradientAngle = 70F;
            this.sys3button1.GradientFirstColor = System.Drawing.Color.White;
            this.sys3button1.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
            this.sys3button1.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.sys3button1.ImagePosition = new System.Drawing.Point(7, 7);
            this.sys3button1.ImageSize = new System.Drawing.Point(30, 30);
            this.sys3button1.LoadImage = global::FrameOfSystem3.Properties.Resources.CONFIG_ADD3;
            this.sys3button1.Location = new System.Drawing.Point(253, 786);
            this.sys3button1.MainFont = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.sys3button1.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
            this.sys3button1.Name = "sys3button1";
            this.sys3button1.Size = new System.Drawing.Size(147, 56);
            this.sys3button1.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.sys3button1.SubFontColor = System.Drawing.Color.DarkBlue;
            this.sys3button1.SubText = "STATUS";
            this.sys3button1.TabIndex = 1;
            this.sys3button1.Text = "ADD";
            this.sys3button1.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3button1.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.sys3button1.ThemeIndex = 0;
            this.sys3button1.UseBorder = true;
            this.sys3button1.UseClickedEmphasizeTextColor = false;
            this.sys3button1.UseCustomizeClickedColor = false;
            this.sys3button1.UseEdge = true;
            this.sys3button1.UseHoverEmphasizeCustomColor = false;
            this.sys3button1.UseImage = true;
            this.sys3button1.UserHoverEmpahsize = false;
            this.sys3button1.UseSubFont = false;
            this.sys3button1.Click += new System.EventHandler(this.Click_AddButton);
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
            this.sys3GroupBox1.Location = new System.Drawing.Point(568, 429);
            this.sys3GroupBox1.Name = "sys3GroupBox1";
            this.sys3GroupBox1.Size = new System.Drawing.Size(562, 420);
            this.sys3GroupBox1.TabIndex = 1375;
            this.sys3GroupBox1.Text = "COMPARE CONDITION LIST";
            this.sys3GroupBox1.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3GroupBox1.ThemeIndex = 0;
            this.sys3GroupBox1.UseLabelBorder = true;
            // 
            // m_dgViewCompareCondition
            // 
            this.m_dgViewCompareCondition.AllowUserToAddRows = false;
            this.m_dgViewCompareCondition.AllowUserToDeleteRows = false;
            this.m_dgViewCompareCondition.AllowUserToResizeColumns = false;
            this.m_dgViewCompareCondition.AllowUserToResizeRows = false;
            this.m_dgViewCompareCondition.BackgroundColor = System.Drawing.Color.White;
            this.m_dgViewCompareCondition.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.m_dgViewCompareCondition.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_dgViewCompareCondition.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.m_dgViewCompareCondition.ColumnHeadersHeight = 40;
            this.m_dgViewCompareCondition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.m_dgViewCompareCondition.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn9,
            this.Device,
            this.dataGridViewTextBoxColumn8,
            this.RELATIVE_INDEX,
            this.DIRECTION,
            this.POSITION});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.m_dgViewCompareCondition.DefaultCellStyle = dataGridViewCellStyle8;
            this.m_dgViewCompareCondition.EnableHeadersVisualStyles = false;
            this.m_dgViewCompareCondition.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            this.m_dgViewCompareCondition.Location = new System.Drawing.Point(571, 461);
            this.m_dgViewCompareCondition.MultiSelect = false;
            this.m_dgViewCompareCondition.Name = "m_dgViewCompareCondition";
            this.m_dgViewCompareCondition.ReadOnly = true;
            this.m_dgViewCompareCondition.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("맑은 고딕", 11F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_dgViewCompareCondition.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.m_dgViewCompareCondition.RowHeadersVisible = false;
            this.m_dgViewCompareCondition.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.m_dgViewCompareCondition.RowTemplate.Height = 30;
            this.m_dgViewCompareCondition.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgViewCompareCondition.Size = new System.Drawing.Size(557, 318);
            this.m_dgViewCompareCondition.TabIndex = 1374;
            this.m_dgViewCompareCondition.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Click_CompareConditionGrid);
            this.m_dgViewCompareCondition.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DoubleClick_CompareConditionGrid);
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "GROUP";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn9.Width = 70;
            // 
            // Device
            // 
            this.Device.HeaderText = "TYPE";
            this.Device.Name = "Device";
            this.Device.ReadOnly = true;
            this.Device.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "DEVICE INDEX";
            this.dataGridViewTextBoxColumn8.MaxInputLength = 20;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // RELATIVE_INDEX
            // 
            this.RELATIVE_INDEX.HeaderText = "RELATIVE INDEX";
            this.RELATIVE_INDEX.Name = "RELATIVE_INDEX";
            this.RELATIVE_INDEX.ReadOnly = true;
            // 
            // DIRECTION
            // 
            this.DIRECTION.HeaderText = "DIRECTION";
            this.DIRECTION.Name = "DIRECTION";
            this.DIRECTION.ReadOnly = true;
            this.DIRECTION.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DIRECTION.Width = 90;
            // 
            // POSITION
            // 
            this.POSITION.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.POSITION.HeaderText = "THRESHOLD";
            this.POSITION.Name = "POSITION";
            this.POSITION.ReadOnly = true;
            this.POSITION.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            this.sys3button3.EdgeRadius = 5;
            this.sys3button3.GradientAngle = 70F;
            this.sys3button3.GradientFirstColor = System.Drawing.Color.White;
            this.sys3button3.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
            this.sys3button3.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.sys3button3.ImagePosition = new System.Drawing.Point(7, 7);
            this.sys3button3.ImageSize = new System.Drawing.Point(30, 30);
            this.sys3button3.LoadImage = global::FrameOfSystem3.Properties.Resources.CONFIG_ADD3;
            this.sys3button3.Location = new System.Drawing.Point(819, 786);
            this.sys3button3.MainFont = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.sys3button3.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
            this.sys3button3.Name = "sys3button3";
            this.sys3button3.Size = new System.Drawing.Size(147, 56);
            this.sys3button3.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.sys3button3.SubFontColor = System.Drawing.Color.DarkBlue;
            this.sys3button3.SubText = "STATUS";
            this.sys3button3.TabIndex = 3;
            this.sys3button3.Text = "ADD";
            this.sys3button3.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3button3.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.sys3button3.ThemeIndex = 0;
            this.sys3button3.UseBorder = true;
            this.sys3button3.UseClickedEmphasizeTextColor = false;
            this.sys3button3.UseCustomizeClickedColor = false;
            this.sys3button3.UseEdge = true;
            this.sys3button3.UseHoverEmphasizeCustomColor = false;
            this.sys3button3.UseImage = true;
            this.sys3button3.UserHoverEmpahsize = false;
            this.sys3button3.UseSubFont = false;
            this.sys3button3.Click += new System.EventHandler(this.Click_AddButton);
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
            this.m_groupItemList.Location = new System.Drawing.Point(568, 0);
            this.m_groupItemList.Name = "m_groupItemList";
            this.m_groupItemList.Size = new System.Drawing.Size(562, 424);
            this.m_groupItemList.TabIndex = 1375;
            this.m_groupItemList.Text = "COMPARE GROUP LIST";
            this.m_groupItemList.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_groupItemList.ThemeIndex = 0;
            this.m_groupItemList.UseLabelBorder = true;
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
            this.sys3button2.EdgeRadius = 5;
            this.sys3button2.GradientAngle = 70F;
            this.sys3button2.GradientFirstColor = System.Drawing.Color.White;
            this.sys3button2.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
            this.sys3button2.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.sys3button2.ImagePosition = new System.Drawing.Point(7, 7);
            this.sys3button2.ImageSize = new System.Drawing.Point(30, 30);
            this.sys3button2.LoadImage = global::FrameOfSystem3.Properties.Resources.CONFIG_ADD3;
            this.sys3button2.Location = new System.Drawing.Point(819, 355);
            this.sys3button2.MainFont = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.sys3button2.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
            this.sys3button2.Name = "sys3button2";
            this.sys3button2.Size = new System.Drawing.Size(147, 56);
            this.sys3button2.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.sys3button2.SubFontColor = System.Drawing.Color.DarkBlue;
            this.sys3button2.SubText = "STATUS";
            this.sys3button2.TabIndex = 2;
            this.sys3button2.Text = "ADD";
            this.sys3button2.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3button2.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.sys3button2.ThemeIndex = 0;
            this.sys3button2.UseBorder = true;
            this.sys3button2.UseClickedEmphasizeTextColor = false;
            this.sys3button2.UseCustomizeClickedColor = false;
            this.sys3button2.UseEdge = true;
            this.sys3button2.UseHoverEmphasizeCustomColor = false;
            this.sys3button2.UseImage = true;
            this.sys3button2.UserHoverEmpahsize = false;
            this.sys3button2.UseSubFont = false;
            this.sys3button2.Click += new System.EventHandler(this.Click_AddButton);
            // 
            // m_dgViewCompareGroup
            // 
            this.m_dgViewCompareGroup.AllowUserToAddRows = false;
            this.m_dgViewCompareGroup.AllowUserToDeleteRows = false;
            this.m_dgViewCompareGroup.AllowUserToResizeColumns = false;
            this.m_dgViewCompareGroup.AllowUserToResizeRows = false;
            this.m_dgViewCompareGroup.BackgroundColor = System.Drawing.Color.White;
            this.m_dgViewCompareGroup.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.m_dgViewCompareGroup.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.m_dgViewCompareGroup.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_dgViewCompareGroup.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.m_dgViewCompareGroup.ColumnHeadersHeight = 30;
            this.m_dgViewCompareGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.m_dgViewCompareGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.POST_SKIP,
            this.dataGridViewTextBoxColumn6});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.m_dgViewCompareGroup.DefaultCellStyle = dataGridViewCellStyle11;
            this.m_dgViewCompareGroup.EnableHeadersVisualStyles = false;
            this.m_dgViewCompareGroup.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            this.m_dgViewCompareGroup.Location = new System.Drawing.Point(571, 30);
            this.m_dgViewCompareGroup.MultiSelect = false;
            this.m_dgViewCompareGroup.Name = "m_dgViewCompareGroup";
            this.m_dgViewCompareGroup.ReadOnly = true;
            this.m_dgViewCompareGroup.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("맑은 고딕", 11F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_dgViewCompareGroup.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.m_dgViewCompareGroup.RowHeadersVisible = false;
            this.m_dgViewCompareGroup.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.m_dgViewCompareGroup.RowTemplate.Height = 30;
            this.m_dgViewCompareGroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgViewCompareGroup.Size = new System.Drawing.Size(557, 318);
            this.m_dgViewCompareGroup.TabIndex = 1374;
            this.m_dgViewCompareGroup.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Click_CompareGroupGrid);
            this.m_dgViewCompareGroup.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DoubleClick_CompareGroupGrid);
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
            // POST_SKIP
            // 
            this.POST_SKIP.HeaderText = "ENABLE";
            this.POST_SKIP.Name = "POST_SKIP";
            this.POST_SKIP.ReadOnly = true;
            this.POST_SKIP.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.POST_SKIP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            // m_btnStop
            // 
            this.m_btnStop.BorderWidth = 3;
            this.m_btnStop.ButtonClicked = false;
            this.m_btnStop.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.m_btnStop.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.m_btnStop.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.m_btnStop.Description = "";
            this.m_btnStop.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_btnStop.EdgeRadius = 5;
            this.m_btnStop.GradientAngle = 70F;
            this.m_btnStop.GradientFirstColor = System.Drawing.Color.White;
            this.m_btnStop.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
            this.m_btnStop.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.m_btnStop.ImagePosition = new System.Drawing.Point(7, 7);
            this.m_btnStop.ImageSize = new System.Drawing.Point(30, 30);
            this.m_btnStop.LoadImage = global::FrameOfSystem3.Properties.Resources.CONNECT_BLACK;
            this.m_btnStop.Location = new System.Drawing.Point(100, 786);
            this.m_btnStop.MainFont = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.m_btnStop.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
            this.m_btnStop.Name = "m_btnStop";
            this.m_btnStop.Size = new System.Drawing.Size(147, 56);
            this.m_btnStop.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.m_btnStop.SubFontColor = System.Drawing.Color.DarkBlue;
            this.m_btnStop.SubText = "GET POSITION";
            this.m_btnStop.TabIndex = 0;
            this.m_btnStop.Text = "GET POSITION";
            this.m_btnStop.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.m_btnStop.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_RIGHT;
            this.m_btnStop.ThemeIndex = 0;
            this.m_btnStop.UseBorder = true;
            this.m_btnStop.UseClickedEmphasizeTextColor = false;
            this.m_btnStop.UseCustomizeClickedColor = false;
            this.m_btnStop.UseEdge = true;
            this.m_btnStop.UseHoverEmphasizeCustomColor = false;
            this.m_btnStop.UseImage = false;
            this.m_btnStop.UserHoverEmpahsize = false;
            this.m_btnStop.UseSubFont = false;
            this.m_btnStop.Click += new System.EventHandler(this.Click_SetPosition);
            // 
            // sys3button4
            // 
            this.sys3button4.BorderWidth = 3;
            this.sys3button4.ButtonClicked = false;
            this.sys3button4.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.sys3button4.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.sys3button4.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.sys3button4.Description = "";
            this.sys3button4.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3button4.EdgeRadius = 5;
            this.sys3button4.GradientAngle = 70F;
            this.sys3button4.GradientFirstColor = System.Drawing.Color.White;
            this.sys3button4.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
            this.sys3button4.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.sys3button4.ImagePosition = new System.Drawing.Point(7, 7);
            this.sys3button4.ImageSize = new System.Drawing.Point(30, 30);
            this.sys3button4.LoadImage = global::FrameOfSystem3.Properties.Resources.CONNECT_BLACK;
            this.sys3button4.Location = new System.Drawing.Point(666, 786);
            this.sys3button4.MainFont = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.sys3button4.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
            this.sys3button4.Name = "sys3button4";
            this.sys3button4.Size = new System.Drawing.Size(147, 56);
            this.sys3button4.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.sys3button4.SubFontColor = System.Drawing.Color.DarkBlue;
            this.sys3button4.SubText = "GET POSITION";
            this.sys3button4.TabIndex = 1;
            this.sys3button4.Text = "GET POSITION";
            this.sys3button4.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3button4.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_RIGHT;
            this.sys3button4.ThemeIndex = 0;
            this.sys3button4.UseBorder = true;
            this.sys3button4.UseClickedEmphasizeTextColor = false;
            this.sys3button4.UseCustomizeClickedColor = false;
            this.sys3button4.UseEdge = true;
            this.sys3button4.UseHoverEmphasizeCustomColor = false;
            this.sys3button4.UseImage = false;
            this.sys3button4.UserHoverEmpahsize = false;
            this.sys3button4.UseSubFont = false;
            this.sys3button4.Click += new System.EventHandler(this.Click_SetPosition);
            // 
            // sys3button5
            // 
            this.sys3button5.BorderWidth = 3;
            this.sys3button5.ButtonClicked = false;
            this.sys3button5.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.sys3button5.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.sys3button5.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.sys3button5.Description = "";
            this.sys3button5.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3button5.EdgeRadius = 5;
            this.sys3button5.GradientAngle = 70F;
            this.sys3button5.GradientFirstColor = System.Drawing.Color.White;
            this.sys3button5.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
            this.sys3button5.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.sys3button5.ImagePosition = new System.Drawing.Point(7, 7);
            this.sys3button5.ImageSize = new System.Drawing.Point(30, 30);
            this.sys3button5.LoadImage = global::FrameOfSystem3.Properties.Resources.REMOVE;
            this.sys3button5.Location = new System.Drawing.Point(406, 786);
            this.sys3button5.MainFont = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.sys3button5.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
            this.sys3button5.Name = "sys3button5";
            this.sys3button5.Size = new System.Drawing.Size(147, 56);
            this.sys3button5.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.sys3button5.SubFontColor = System.Drawing.Color.DarkBlue;
            this.sys3button5.SubText = "STATUS";
            this.sys3button5.TabIndex = 1;
            this.sys3button5.Text = "REMOVE";
            this.sys3button5.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3button5.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.sys3button5.ThemeIndex = 0;
            this.sys3button5.UseBorder = true;
            this.sys3button5.UseClickedEmphasizeTextColor = false;
            this.sys3button5.UseCustomizeClickedColor = false;
            this.sys3button5.UseEdge = true;
            this.sys3button5.UseHoverEmphasizeCustomColor = false;
            this.sys3button5.UseImage = true;
            this.sys3button5.UserHoverEmpahsize = false;
            this.sys3button5.UseSubFont = false;
            this.sys3button5.Click += new System.EventHandler(this.Click_RemoveButton);
            // 
            // sys3button6
            // 
            this.sys3button6.BorderWidth = 3;
            this.sys3button6.ButtonClicked = false;
            this.sys3button6.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.sys3button6.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.sys3button6.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.sys3button6.Description = "";
            this.sys3button6.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3button6.EdgeRadius = 5;
            this.sys3button6.GradientAngle = 70F;
            this.sys3button6.GradientFirstColor = System.Drawing.Color.White;
            this.sys3button6.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
            this.sys3button6.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.sys3button6.ImagePosition = new System.Drawing.Point(7, 7);
            this.sys3button6.ImageSize = new System.Drawing.Point(30, 30);
            this.sys3button6.LoadImage = global::FrameOfSystem3.Properties.Resources.REMOVE;
            this.sys3button6.Location = new System.Drawing.Point(406, 355);
            this.sys3button6.MainFont = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.sys3button6.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
            this.sys3button6.Name = "sys3button6";
            this.sys3button6.Size = new System.Drawing.Size(147, 56);
            this.sys3button6.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.sys3button6.SubFontColor = System.Drawing.Color.DarkBlue;
            this.sys3button6.SubText = "STATUS";
            this.sys3button6.TabIndex = 0;
            this.sys3button6.Text = "REMOVE";
            this.sys3button6.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3button6.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.sys3button6.ThemeIndex = 0;
            this.sys3button6.UseBorder = true;
            this.sys3button6.UseClickedEmphasizeTextColor = false;
            this.sys3button6.UseCustomizeClickedColor = false;
            this.sys3button6.UseEdge = true;
            this.sys3button6.UseHoverEmphasizeCustomColor = false;
            this.sys3button6.UseImage = true;
            this.sys3button6.UserHoverEmpahsize = false;
            this.sys3button6.UseSubFont = false;
            this.sys3button6.Click += new System.EventHandler(this.Click_RemoveButton);
            // 
            // sys3button7
            // 
            this.sys3button7.BorderWidth = 3;
            this.sys3button7.ButtonClicked = false;
            this.sys3button7.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.sys3button7.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.sys3button7.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.sys3button7.Description = "";
            this.sys3button7.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3button7.EdgeRadius = 5;
            this.sys3button7.GradientAngle = 70F;
            this.sys3button7.GradientFirstColor = System.Drawing.Color.White;
            this.sys3button7.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
            this.sys3button7.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.sys3button7.ImagePosition = new System.Drawing.Point(7, 7);
            this.sys3button7.ImageSize = new System.Drawing.Point(30, 30);
            this.sys3button7.LoadImage = global::FrameOfSystem3.Properties.Resources.REMOVE;
            this.sys3button7.Location = new System.Drawing.Point(972, 355);
            this.sys3button7.MainFont = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.sys3button7.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
            this.sys3button7.Name = "sys3button7";
            this.sys3button7.Size = new System.Drawing.Size(147, 56);
            this.sys3button7.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.sys3button7.SubFontColor = System.Drawing.Color.DarkBlue;
            this.sys3button7.SubText = "STATUS";
            this.sys3button7.TabIndex = 2;
            this.sys3button7.Text = "REMOVE";
            this.sys3button7.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3button7.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.sys3button7.ThemeIndex = 0;
            this.sys3button7.UseBorder = true;
            this.sys3button7.UseClickedEmphasizeTextColor = false;
            this.sys3button7.UseCustomizeClickedColor = false;
            this.sys3button7.UseEdge = true;
            this.sys3button7.UseHoverEmphasizeCustomColor = false;
            this.sys3button7.UseImage = true;
            this.sys3button7.UserHoverEmpahsize = false;
            this.sys3button7.UseSubFont = false;
            this.sys3button7.Click += new System.EventHandler(this.Click_RemoveButton);
            // 
            // sys3button8
            // 
            this.sys3button8.BorderWidth = 3;
            this.sys3button8.ButtonClicked = false;
            this.sys3button8.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.sys3button8.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.sys3button8.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.sys3button8.Description = "";
            this.sys3button8.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3button8.EdgeRadius = 5;
            this.sys3button8.GradientAngle = 70F;
            this.sys3button8.GradientFirstColor = System.Drawing.Color.White;
            this.sys3button8.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
            this.sys3button8.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.sys3button8.ImagePosition = new System.Drawing.Point(7, 7);
            this.sys3button8.ImageSize = new System.Drawing.Point(30, 30);
            this.sys3button8.LoadImage = global::FrameOfSystem3.Properties.Resources.REMOVE;
            this.sys3button8.Location = new System.Drawing.Point(972, 786);
            this.sys3button8.MainFont = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.sys3button8.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
            this.sys3button8.Name = "sys3button8";
            this.sys3button8.Size = new System.Drawing.Size(147, 56);
            this.sys3button8.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.sys3button8.SubFontColor = System.Drawing.Color.DarkBlue;
            this.sys3button8.SubText = "STATUS";
            this.sys3button8.TabIndex = 3;
            this.sys3button8.Text = "REMOVE";
            this.sys3button8.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3button8.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.sys3button8.ThemeIndex = 0;
            this.sys3button8.UseBorder = true;
            this.sys3button8.UseClickedEmphasizeTextColor = false;
            this.sys3button8.UseCustomizeClickedColor = false;
            this.sys3button8.UseEdge = true;
            this.sys3button8.UseHoverEmphasizeCustomColor = false;
            this.sys3button8.UseImage = true;
            this.sys3button8.UserHoverEmpahsize = false;
            this.sys3button8.UseSubFont = false;
            this.sys3button8.Click += new System.EventHandler(this.Click_RemoveButton);
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "COMPARE KEY";
            this.dataGridViewTextBoxColumn4.MaxInputLength = 20;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 80;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "DIRECTION";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Postion
            // 
            this.Postion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Postion.HeaderText = "THRESHOLD";
            this.Postion.Name = "Postion";
            this.Postion.ReadOnly = true;
            // 
            // START
            // 
            this.START.HeaderText = "MOVING DIRCTION";
            this.START.Name = "START";
            this.START.ReadOnly = true;
            this.START.Width = 135;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "RELATIVE";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 80;
            // 
            // Interlock_Motion
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.sys3button4);
            this.Controls.Add(this.m_btnStop);
            this.Controls.Add(this.sys3button3);
            this.Controls.Add(this.sys3button2);
            this.Controls.Add(this.sys3button8);
            this.Controls.Add(this.sys3button7);
            this.Controls.Add(this.sys3button6);
            this.Controls.Add(this.sys3button5);
            this.Controls.Add(this.sys3button1);
            this.Controls.Add(this.m_btnAdd);
            this.Controls.Add(this.m_dgViewCompareCondition);
            this.Controls.Add(this.m_dgViewCompareGroup);
            this.Controls.Add(this.sys3GroupBox1);
            this.Controls.Add(this.m_groupItemList);
            this.Controls.Add(this.m_dgViewCondition);
            this.Controls.Add(this.m_groupDeviceList);
            this.Controls.Add(this.m_dgViewMotion);
            this.Controls.Add(this.m_groupTaskList);
            this.Name = "Interlock_Motion";
            this.Size = new System.Drawing.Size(1140, 850);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgViewMotion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgViewCondition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgViewCompareCondition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgViewCompareGroup)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private Sys3Controls.Sys3DoubleBufferedDataGridView m_dgViewMotion;
		private Sys3Controls.Sys3GroupBox m_groupTaskList;
		private Sys3Controls.Sys3GroupBox m_groupDeviceList;
        private Sys3Controls.Sys3DoubleBufferedDataGridView m_dgViewCondition;
        private Sys3Controls.Sys3button m_btnAdd;
        private Sys3Controls.Sys3button sys3button1;
        private Sys3Controls.Sys3GroupBox sys3GroupBox1;
        private Sys3Controls.Sys3DoubleBufferedDataGridView m_dgViewCompareCondition;
        private Sys3Controls.Sys3button sys3button3;
        private Sys3Controls.Sys3GroupBox m_groupItemList;
        private Sys3Controls.Sys3button sys3button2;
        private Sys3Controls.Sys3DoubleBufferedDataGridView m_dgViewCompareGroup;
        private Sys3Controls.Sys3button m_btnStop;
        private Sys3Controls.Sys3button sys3button4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn POST_SKIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ENABLE;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Device;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn RELATIVE_INDEX;
        private System.Windows.Forms.DataGridViewTextBoxColumn DIRECTION;
        private System.Windows.Forms.DataGridViewTextBoxColumn POSITION;
        private Sys3Controls.Sys3button sys3button5;
        private Sys3Controls.Sys3button sys3button6;
        private Sys3Controls.Sys3button sys3button7;
        private Sys3Controls.Sys3button sys3button8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Postion;
        private System.Windows.Forms.DataGridViewTextBoxColumn START;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
	}
}
