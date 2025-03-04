namespace FrameOfSystem3.Views.Config
{
    partial class Config_Tool
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
            Sys3Controls.Sys3GroupBox sys3GroupBox1;
            Sys3Controls.Sys3GroupBox sys3GroupBox3;
            Sys3Controls.Sys3GroupBox sys3GroupBox2;
            Sys3Controls.Sys3GroupBox sys3GroupBox4;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.m_btnDisable = new Sys3Controls.Sys3button();
            this.m_btnEnable = new Sys3Controls.Sys3button();
            this.m_btnRemove = new Sys3Controls.Sys3button();
            this.m_btnAdd = new Sys3Controls.Sys3button();
            this.m_dgViewToolList = new Sys3Controls.Sys3DoubleBufferedDataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgViewItemList = new Sys3Controls.Sys3DoubleBufferedDataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgViewMonitoringData = new Sys3Controls.Sys3DoubleBufferedDataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Reset = new Sys3Controls.Sys3button();
            this.m_btnActivate = new Sys3Controls.Sys3button();
            this.m_btnDeactivate = new Sys3Controls.Sys3button();
            sys3GroupBox1 = new Sys3Controls.Sys3GroupBox();
            sys3GroupBox3 = new Sys3Controls.Sys3GroupBox();
            sys3GroupBox2 = new Sys3Controls.Sys3GroupBox();
            sys3GroupBox4 = new Sys3Controls.Sys3GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgViewToolList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgViewItemList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgViewMonitoringData)).BeginInit();
            this.SuspendLayout();
            // 
            // sys3GroupBox1
            // 
            sys3GroupBox1.BackGroundColor = System.Drawing.Color.WhiteSmoke;
            sys3GroupBox1.EdgeBorderStroke = 2;
            sys3GroupBox1.EdgeRadius = 2;
            sys3GroupBox1.LabelFont = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            sys3GroupBox1.LabelGradientColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            sys3GroupBox1.LabelGradientColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            sys3GroupBox1.LabelHeight = 42;
            sys3GroupBox1.LabelTextColor = System.Drawing.Color.Black;
            sys3GroupBox1.Location = new System.Drawing.Point(3, 3);
            sys3GroupBox1.Name = "sys3GroupBox1";
            sys3GroupBox1.Size = new System.Drawing.Size(290, 664);
            sys3GroupBox1.TabIndex = 1473;
            sys3GroupBox1.Text = "TOOL LIST";
            sys3GroupBox1.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            sys3GroupBox1.ThemeIndex = 0;
            sys3GroupBox1.UseLabelBorder = true;
            // 
            // sys3GroupBox3
            // 
            sys3GroupBox3.BackGroundColor = System.Drawing.Color.WhiteSmoke;
            sys3GroupBox3.EdgeBorderStroke = 2;
            sys3GroupBox3.EdgeRadius = 2;
            sys3GroupBox3.LabelFont = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            sys3GroupBox3.LabelGradientColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            sys3GroupBox3.LabelGradientColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            sys3GroupBox3.LabelHeight = 42;
            sys3GroupBox3.LabelTextColor = System.Drawing.Color.Black;
            sys3GroupBox3.Location = new System.Drawing.Point(3, 673);
            sys3GroupBox3.Name = "sys3GroupBox3";
            sys3GroupBox3.Size = new System.Drawing.Size(1134, 224);
            sys3GroupBox3.TabIndex = 1477;
            sys3GroupBox3.Text = "EDIT";
            sys3GroupBox3.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            sys3GroupBox3.ThemeIndex = 0;
            sys3GroupBox3.UseLabelBorder = true;
            // 
            // sys3GroupBox2
            // 
            sys3GroupBox2.BackGroundColor = System.Drawing.Color.WhiteSmoke;
            sys3GroupBox2.EdgeBorderStroke = 2;
            sys3GroupBox2.EdgeRadius = 2;
            sys3GroupBox2.LabelFont = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            sys3GroupBox2.LabelGradientColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            sys3GroupBox2.LabelGradientColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            sys3GroupBox2.LabelHeight = 42;
            sys3GroupBox2.LabelTextColor = System.Drawing.Color.Black;
            sys3GroupBox2.Location = new System.Drawing.Point(294, 3);
            sys3GroupBox2.Name = "sys3GroupBox2";
            sys3GroupBox2.Size = new System.Drawing.Size(452, 664);
            sys3GroupBox2.TabIndex = 1478;
            sys3GroupBox2.Text = "ITEM LIST";
            sys3GroupBox2.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            sys3GroupBox2.ThemeIndex = 0;
            sys3GroupBox2.UseLabelBorder = true;
            // 
            // sys3GroupBox4
            // 
            sys3GroupBox4.BackGroundColor = System.Drawing.Color.WhiteSmoke;
            sys3GroupBox4.EdgeBorderStroke = 2;
            sys3GroupBox4.EdgeRadius = 2;
            sys3GroupBox4.LabelFont = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            sys3GroupBox4.LabelGradientColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            sys3GroupBox4.LabelGradientColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            sys3GroupBox4.LabelHeight = 42;
            sys3GroupBox4.LabelTextColor = System.Drawing.Color.Black;
            sys3GroupBox4.Location = new System.Drawing.Point(747, 3);
            sys3GroupBox4.Name = "sys3GroupBox4";
            sys3GroupBox4.Size = new System.Drawing.Size(390, 664);
            sys3GroupBox4.TabIndex = 1480;
            sys3GroupBox4.Text = "MONITORING DATA";
            sys3GroupBox4.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            sys3GroupBox4.ThemeIndex = 0;
            sys3GroupBox4.UseLabelBorder = true;
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
            this.m_btnDisable.Location = new System.Drawing.Point(153, 777);
            this.m_btnDisable.MainFont = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.m_btnDisable.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
            this.m_btnDisable.Name = "m_btnDisable";
            this.m_btnDisable.Size = new System.Drawing.Size(126, 79);
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
            this.m_btnEnable.Location = new System.Drawing.Point(16, 777);
            this.m_btnEnable.MainFont = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.m_btnEnable.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
            this.m_btnEnable.Name = "m_btnEnable";
            this.m_btnEnable.Size = new System.Drawing.Size(126, 79);
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
            this.m_btnRemove.Location = new System.Drawing.Point(421, 777);
            this.m_btnRemove.MainFont = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.m_btnRemove.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
            this.m_btnRemove.Name = "m_btnRemove";
            this.m_btnRemove.Size = new System.Drawing.Size(126, 79);
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
            this.m_btnAdd.Location = new System.Drawing.Point(285, 777);
            this.m_btnAdd.MainFont = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.m_btnAdd.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
            this.m_btnAdd.Name = "m_btnAdd";
            this.m_btnAdd.Size = new System.Drawing.Size(126, 79);
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
            this.m_btnAdd.Click += new System.EventHandler(this.Click_Add);
            // 
            // m_dgViewToolList
            // 
            this.m_dgViewToolList.AllowUserToAddRows = false;
            this.m_dgViewToolList.AllowUserToDeleteRows = false;
            this.m_dgViewToolList.AllowUserToResizeColumns = false;
            this.m_dgViewToolList.AllowUserToResizeRows = false;
            this.m_dgViewToolList.BackgroundColor = System.Drawing.Color.White;
            this.m_dgViewToolList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.m_dgViewToolList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_dgViewToolList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.m_dgViewToolList.ColumnHeadersHeight = 30;
            this.m_dgViewToolList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.m_dgViewToolList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn1});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.m_dgViewToolList.DefaultCellStyle = dataGridViewCellStyle2;
            this.m_dgViewToolList.EnableHeadersVisualStyles = false;
            this.m_dgViewToolList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            this.m_dgViewToolList.Location = new System.Drawing.Point(17, 53);
            this.m_dgViewToolList.MultiSelect = false;
            this.m_dgViewToolList.Name = "m_dgViewToolList";
            this.m_dgViewToolList.ReadOnly = true;
            this.m_dgViewToolList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("맑은 고딕", 11F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_dgViewToolList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.m_dgViewToolList.RowHeadersVisible = false;
            this.m_dgViewToolList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.m_dgViewToolList.RowTemplate.Height = 30;
            this.m_dgViewToolList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgViewToolList.Size = new System.Drawing.Size(262, 602);
            this.m_dgViewToolList.TabIndex = 1472;
            this.m_dgViewToolList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Click_dgViewToolList);
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.Frozen = true;
            this.dataGridViewTextBoxColumn3.HeaderText = "INDEX";
            this.dataGridViewTextBoxColumn3.MaxInputLength = 20;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.Width = 60;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "NAME";
            this.dataGridViewTextBoxColumn1.MaxInputLength = 20;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 200;
            // 
            // m_dgViewItemList
            // 
            this.m_dgViewItemList.AllowUserToAddRows = false;
            this.m_dgViewItemList.AllowUserToDeleteRows = false;
            this.m_dgViewItemList.AllowUserToResizeColumns = false;
            this.m_dgViewItemList.AllowUserToResizeRows = false;
            this.m_dgViewItemList.BackgroundColor = System.Drawing.Color.White;
            this.m_dgViewItemList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.m_dgViewItemList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_dgViewItemList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.m_dgViewItemList.ColumnHeadersHeight = 30;
            this.m_dgViewItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.m_dgViewItemList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn4});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.m_dgViewItemList.DefaultCellStyle = dataGridViewCellStyle5;
            this.m_dgViewItemList.EnableHeadersVisualStyles = false;
            this.m_dgViewItemList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            this.m_dgViewItemList.Location = new System.Drawing.Point(309, 53);
            this.m_dgViewItemList.MultiSelect = false;
            this.m_dgViewItemList.Name = "m_dgViewItemList";
            this.m_dgViewItemList.ReadOnly = true;
            this.m_dgViewItemList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("맑은 고딕", 11F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_dgViewItemList.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.m_dgViewItemList.RowHeadersVisible = false;
            this.m_dgViewItemList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.m_dgViewItemList.RowTemplate.Height = 30;
            this.m_dgViewItemList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgViewItemList.Size = new System.Drawing.Size(422, 602);
            this.m_dgViewItemList.TabIndex = 1479;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.Frozen = true;
            this.dataGridViewTextBoxColumn2.HeaderText = "ITEM";
            this.dataGridViewTextBoxColumn2.MaxInputLength = 30;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.Width = 240;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.Frozen = true;
            this.dataGridViewTextBoxColumn4.HeaderText = "VALUE";
            this.dataGridViewTextBoxColumn4.MaxInputLength = 20;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 180;
            // 
            // m_dgViewMonitoringData
            // 
            this.m_dgViewMonitoringData.AllowUserToAddRows = false;
            this.m_dgViewMonitoringData.AllowUserToDeleteRows = false;
            this.m_dgViewMonitoringData.AllowUserToResizeColumns = false;
            this.m_dgViewMonitoringData.AllowUserToResizeRows = false;
            this.m_dgViewMonitoringData.BackgroundColor = System.Drawing.Color.White;
            this.m_dgViewMonitoringData.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.m_dgViewMonitoringData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_dgViewMonitoringData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.m_dgViewMonitoringData.ColumnHeadersHeight = 30;
            this.m_dgViewMonitoringData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.m_dgViewMonitoringData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.m_dgViewMonitoringData.DefaultCellStyle = dataGridViewCellStyle8;
            this.m_dgViewMonitoringData.EnableHeadersVisualStyles = false;
            this.m_dgViewMonitoringData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            this.m_dgViewMonitoringData.Location = new System.Drawing.Point(761, 53);
            this.m_dgViewMonitoringData.MultiSelect = false;
            this.m_dgViewMonitoringData.Name = "m_dgViewMonitoringData";
            this.m_dgViewMonitoringData.ReadOnly = true;
            this.m_dgViewMonitoringData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("맑은 고딕", 11F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_dgViewMonitoringData.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.m_dgViewMonitoringData.RowHeadersVisible = false;
            this.m_dgViewMonitoringData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.m_dgViewMonitoringData.RowTemplate.Height = 30;
            this.m_dgViewMonitoringData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgViewMonitoringData.Size = new System.Drawing.Size(362, 602);
            this.m_dgViewMonitoringData.TabIndex = 1481;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.Frozen = true;
            this.dataGridViewTextBoxColumn5.HeaderText = "ITEM";
            this.dataGridViewTextBoxColumn5.MaxInputLength = 30;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn5.Width = 200;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.Frozen = true;
            this.dataGridViewTextBoxColumn6.HeaderText = "VALUE";
            this.dataGridViewTextBoxColumn6.MaxInputLength = 20;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn6.Width = 160;
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
            this.btn_Reset.EdgeRadius = 5;
            this.btn_Reset.GradientAngle = 70F;
            this.btn_Reset.GradientFirstColor = System.Drawing.Color.White;
            this.btn_Reset.GradientSecondColor = System.Drawing.Color.LightSeaGreen;
            this.btn_Reset.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.btn_Reset.ImagePosition = new System.Drawing.Point(7, 7);
            this.btn_Reset.ImageSize = new System.Drawing.Point(30, 30);
            this.btn_Reset.LoadImage = global::FrameOfSystem3.Properties.Resources.REPEAT_BLACK;
            this.btn_Reset.Location = new System.Drawing.Point(976, 777);
            this.btn_Reset.MainFont = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.btn_Reset.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(126, 79);
            this.btn_Reset.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.btn_Reset.SubFontColor = System.Drawing.Color.DarkBlue;
            this.btn_Reset.SubText = "STATUS";
            this.btn_Reset.TabIndex = 1;
            this.btn_Reset.Text = "RESET";
            this.btn_Reset.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.btn_Reset.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.btn_Reset.ThemeIndex = 0;
            this.btn_Reset.UseBorder = true;
            this.btn_Reset.UseClickedEmphasizeTextColor = false;
            this.btn_Reset.UseCustomizeClickedColor = false;
            this.btn_Reset.UseEdge = true;
            this.btn_Reset.UseHoverEmphasizeCustomColor = false;
            this.btn_Reset.UseImage = true;
            this.btn_Reset.UserHoverEmpahsize = false;
            this.btn_Reset.UseSubFont = false;
            this.btn_Reset.Click += new System.EventHandler(this.Click_Reset);
            // 
            // m_btnActivate
            // 
            this.m_btnActivate.BorderWidth = 3;
            this.m_btnActivate.ButtonClicked = false;
            this.m_btnActivate.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.m_btnActivate.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.m_btnActivate.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.m_btnActivate.Description = "";
            this.m_btnActivate.DisabledColor = System.Drawing.Color.LightSlateGray;
            this.m_btnActivate.EdgeRadius = 5;
            this.m_btnActivate.GradientAngle = 70F;
            this.m_btnActivate.GradientFirstColor = System.Drawing.Color.White;
            this.m_btnActivate.GradientSecondColor = System.Drawing.Color.LightSlateGray;
            this.m_btnActivate.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.m_btnActivate.ImagePosition = new System.Drawing.Point(7, 7);
            this.m_btnActivate.ImageSize = new System.Drawing.Point(30, 30);
            this.m_btnActivate.LoadImage = global::FrameOfSystem3.Properties.Resources.ENABLE_BLACK;
            this.m_btnActivate.Location = new System.Drawing.Point(558, 777);
            this.m_btnActivate.MainFont = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.m_btnActivate.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
            this.m_btnActivate.Name = "m_btnActivate";
            this.m_btnActivate.Size = new System.Drawing.Size(126, 79);
            this.m_btnActivate.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.m_btnActivate.SubFontColor = System.Drawing.Color.DarkBlue;
            this.m_btnActivate.SubText = "STATUS";
            this.m_btnActivate.TabIndex = 0;
            this.m_btnActivate.Text = "ACTIVATE";
            this.m_btnActivate.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.m_btnActivate.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_RIGHT;
            this.m_btnActivate.ThemeIndex = 0;
            this.m_btnActivate.UseBorder = true;
            this.m_btnActivate.UseClickedEmphasizeTextColor = false;
            this.m_btnActivate.UseCustomizeClickedColor = false;
            this.m_btnActivate.UseEdge = true;
            this.m_btnActivate.UseHoverEmphasizeCustomColor = false;
            this.m_btnActivate.UseImage = true;
            this.m_btnActivate.UserHoverEmpahsize = false;
            this.m_btnActivate.UseSubFont = true;
            this.m_btnActivate.Click += new System.EventHandler(this.m_btnActivate_Click);
            // 
            // m_btnDeactivate
            // 
            this.m_btnDeactivate.BorderWidth = 3;
            this.m_btnDeactivate.ButtonClicked = false;
            this.m_btnDeactivate.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.m_btnDeactivate.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.m_btnDeactivate.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.m_btnDeactivate.Description = "";
            this.m_btnDeactivate.DisabledColor = System.Drawing.Color.LightSlateGray;
            this.m_btnDeactivate.EdgeRadius = 5;
            this.m_btnDeactivate.GradientAngle = 70F;
            this.m_btnDeactivate.GradientFirstColor = System.Drawing.Color.White;
            this.m_btnDeactivate.GradientSecondColor = System.Drawing.Color.LightSlateGray;
            this.m_btnDeactivate.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.m_btnDeactivate.ImagePosition = new System.Drawing.Point(7, 7);
            this.m_btnDeactivate.ImageSize = new System.Drawing.Point(30, 30);
            this.m_btnDeactivate.LoadImage = global::FrameOfSystem3.Properties.Resources.DISABLE_BLACK;
            this.m_btnDeactivate.Location = new System.Drawing.Point(695, 777);
            this.m_btnDeactivate.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_btnDeactivate.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
            this.m_btnDeactivate.Name = "m_btnDeactivate";
            this.m_btnDeactivate.Size = new System.Drawing.Size(126, 79);
            this.m_btnDeactivate.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.m_btnDeactivate.SubFontColor = System.Drawing.Color.DarkBlue;
            this.m_btnDeactivate.SubText = "STATUS";
            this.m_btnDeactivate.TabIndex = 1;
            this.m_btnDeactivate.Text = "DEACTIVATE";
            this.m_btnDeactivate.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.m_btnDeactivate.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_RIGHT;
            this.m_btnDeactivate.ThemeIndex = 0;
            this.m_btnDeactivate.UseBorder = true;
            this.m_btnDeactivate.UseClickedEmphasizeTextColor = false;
            this.m_btnDeactivate.UseCustomizeClickedColor = false;
            this.m_btnDeactivate.UseEdge = true;
            this.m_btnDeactivate.UseHoverEmphasizeCustomColor = false;
            this.m_btnDeactivate.UseImage = true;
            this.m_btnDeactivate.UserHoverEmpahsize = false;
            this.m_btnDeactivate.UseSubFont = true;
            this.m_btnDeactivate.Click += new System.EventHandler(this.m_btnDeactivate_Click);
            // 
            // Config_Tool
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.m_dgViewMonitoringData);
            this.Controls.Add(sys3GroupBox4);
            this.Controls.Add(this.m_dgViewItemList);
            this.Controls.Add(sys3GroupBox2);
            this.Controls.Add(this.m_dgViewToolList);
            this.Controls.Add(sys3GroupBox1);
            this.Controls.Add(this.m_btnDeactivate);
            this.Controls.Add(this.m_btnDisable);
            this.Controls.Add(this.m_btnActivate);
            this.Controls.Add(this.m_btnEnable);
            this.Controls.Add(this.btn_Reset);
            this.Controls.Add(this.m_btnRemove);
            this.Controls.Add(this.m_btnAdd);
            this.Controls.Add(sys3GroupBox3);
            this.Name = "Config_Tool";
            this.Size = new System.Drawing.Size(1140, 900);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgViewToolList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgViewItemList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgViewMonitoringData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sys3Controls.Sys3button m_btnRemove;
		private Sys3Controls.Sys3button m_btnAdd;
		private Sys3Controls.Sys3button m_btnDisable;
		private Sys3Controls.Sys3button m_btnEnable;
        private Sys3Controls.Sys3DoubleBufferedDataGridView m_dgViewToolList;
        private Sys3Controls.Sys3DoubleBufferedDataGridView m_dgViewItemList;
        private Sys3Controls.Sys3DoubleBufferedDataGridView m_dgViewMonitoringData;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
		private Sys3Controls.Sys3button btn_Reset;
        private Sys3Controls.Sys3button m_btnActivate;
        private Sys3Controls.Sys3button m_btnDeactivate;
    }
}
