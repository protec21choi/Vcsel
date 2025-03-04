﻿namespace FrameOfSystem3.Views.Config
{
    partial class Config_Analog
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Config_Analog));
            this.m_dgViewLookupOutput = new Sys3Controls.Sys3DoubleBufferedDataGridView();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_dgViewLookupInput = new Sys3Controls.Sys3DoubleBufferedDataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_groupInputList = new Sys3Controls.Sys3GroupBox();
            this.m_btnInputRemove = new Sys3Controls.Sys3button();
            this.m_btnInputAdd = new Sys3Controls.Sys3button();
            this.m_btnOutputExtend = new Sys3Controls.Sys3button();
            this.m_btnInputExtend = new Sys3Controls.Sys3button();
            this.m_groupLookupInput = new Sys3Controls.Sys3GroupBox();
            this.m_groupOutputList = new Sys3Controls.Sys3GroupBox();
            this.m_groupLookupOutput = new Sys3Controls.Sys3GroupBox();
            this.m_btnOutputRemove = new Sys3Controls.Sys3button();
            this.m_btnOutputAdd = new Sys3Controls.Sys3button();
            this.sys3GroupBox1 = new Sys3Controls.Sys3GroupBox();
            this.m_groupGraph = new Sys3Controls.Sys3GroupBox();
            this.sys3GroupBox2 = new Sys3Controls.Sys3GroupBox();
            this.m_ToggleInputOnDelay = new Sys3Controls.Sys3ToggleButton();
            this.m_labelStart = new Sys3Controls.Sys3Label();
            this.m_ZedGraph = new ZedGraph.ZedGraphControl();
            this.m_btnOutAdd = new Sys3Controls.Sys3button();
            this.sys3btnClear = new Sys3Controls.Sys3button();
            this.m_btnInAdd = new Sys3Controls.Sys3button();
            this.m_btnOutput = new Sys3Controls.Sys3button();
            this.m_btnInput = new Sys3Controls.Sys3button();
            this.m_pnlAnalogItemView = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgViewLookupOutput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgViewLookupInput)).BeginInit();
            this.SuspendLayout();
            // 
            // m_dgViewLookupOutput
            // 
            this.m_dgViewLookupOutput.AllowUserToAddRows = false;
            this.m_dgViewLookupOutput.AllowUserToDeleteRows = false;
            this.m_dgViewLookupOutput.AllowUserToResizeColumns = false;
            this.m_dgViewLookupOutput.AllowUserToResizeRows = false;
            this.m_dgViewLookupOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_dgViewLookupOutput.BackgroundColor = System.Drawing.Color.White;
            this.m_dgViewLookupOutput.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.m_dgViewLookupOutput.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_dgViewLookupOutput.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.m_dgViewLookupOutput.ColumnHeadersHeight = 30;
            this.m_dgViewLookupOutput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.m_dgViewLookupOutput.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.m_dgViewLookupOutput.DefaultCellStyle = dataGridViewCellStyle2;
            this.m_dgViewLookupOutput.EnableHeadersVisualStyles = false;
            this.m_dgViewLookupOutput.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            this.m_dgViewLookupOutput.Location = new System.Drawing.Point(916, 43);
            this.m_dgViewLookupOutput.MultiSelect = false;
            this.m_dgViewLookupOutput.Name = "m_dgViewLookupOutput";
            this.m_dgViewLookupOutput.ReadOnly = true;
            this.m_dgViewLookupOutput.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("맑은 고딕", 11F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_dgViewLookupOutput.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.m_dgViewLookupOutput.RowHeadersVisible = false;
            this.m_dgViewLookupOutput.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.m_dgViewLookupOutput.RowTemplate.Height = 23;
            this.m_dgViewLookupOutput.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgViewLookupOutput.Size = new System.Drawing.Size(225, 328);
            this.m_dgViewLookupOutput.TabIndex = 1360;
            this.m_dgViewLookupOutput.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DoubleClick_Output_Table);
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.Frozen = true;
            this.dataGridViewTextBoxColumn12.HeaderText = "";
            this.dataGridViewTextBoxColumn12.MaxInputLength = 20;
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn12.Width = 35;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn13.HeaderText = "VOLT";
            this.dataGridViewTextBoxColumn13.MaxInputLength = 20;
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn14.HeaderText = "VALUE";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // m_dgViewLookupInput
            // 
            this.m_dgViewLookupInput.AllowUserToAddRows = false;
            this.m_dgViewLookupInput.AllowUserToDeleteRows = false;
            this.m_dgViewLookupInput.AllowUserToResizeColumns = false;
            this.m_dgViewLookupInput.AllowUserToResizeRows = false;
            this.m_dgViewLookupInput.BackgroundColor = System.Drawing.Color.White;
            this.m_dgViewLookupInput.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.m_dgViewLookupInput.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_dgViewLookupInput.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.m_dgViewLookupInput.ColumnHeadersHeight = 30;
            this.m_dgViewLookupInput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.m_dgViewLookupInput.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.m_dgViewLookupInput.DefaultCellStyle = dataGridViewCellStyle5;
            this.m_dgViewLookupInput.EnableHeadersVisualStyles = false;
            this.m_dgViewLookupInput.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            this.m_dgViewLookupInput.Location = new System.Drawing.Point(916, 43);
            this.m_dgViewLookupInput.MultiSelect = false;
            this.m_dgViewLookupInput.Name = "m_dgViewLookupInput";
            this.m_dgViewLookupInput.ReadOnly = true;
            this.m_dgViewLookupInput.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("맑은 고딕", 11F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_dgViewLookupInput.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.m_dgViewLookupInput.RowHeadersVisible = false;
            this.m_dgViewLookupInput.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.m_dgViewLookupInput.RowTemplate.Height = 23;
            this.m_dgViewLookupInput.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgViewLookupInput.Size = new System.Drawing.Size(225, 328);
            this.m_dgViewLookupInput.TabIndex = 1108;
            this.m_dgViewLookupInput.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DoubleClick_Input_Table);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "";
            this.dataGridViewTextBoxColumn1.MaxInputLength = 20;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 35;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "VOLT";
            this.dataGridViewTextBoxColumn2.MaxInputLength = 20;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.HeaderText = "VALUE";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // m_groupInputList
            // 
            this.m_groupInputList.BackGroundColor = System.Drawing.Color.WhiteSmoke;
            this.m_groupInputList.EdgeBorderStroke = 1;
            this.m_groupInputList.EdgeRadius = 0;
            this.m_groupInputList.LabelFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_groupInputList.LabelGradientColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.m_groupInputList.LabelGradientColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_groupInputList.LabelHeight = 44;
            this.m_groupInputList.LabelTextColor = System.Drawing.Color.Black;
            this.m_groupInputList.Location = new System.Drawing.Point(0, 0);
            this.m_groupInputList.Name = "m_groupInputList";
            this.m_groupInputList.Size = new System.Drawing.Size(872, 45);
            this.m_groupInputList.TabIndex = 1348;
            this.m_groupInputList.Text = "INPUT LIST";
            this.m_groupInputList.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_groupInputList.ThemeIndex = 0;
            this.m_groupInputList.UseLabelBorder = true;
            // 
            // m_btnInputRemove
            // 
            this.m_btnInputRemove.BorderWidth = 3;
            this.m_btnInputRemove.ButtonClicked = false;
            this.m_btnInputRemove.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.m_btnInputRemove.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.m_btnInputRemove.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.m_btnInputRemove.Description = "";
            this.m_btnInputRemove.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_btnInputRemove.EdgeRadius = 1;
            this.m_btnInputRemove.Enabled = false;
            this.m_btnInputRemove.GradientAngle = 80F;
            this.m_btnInputRemove.GradientFirstColor = System.Drawing.Color.White;
            this.m_btnInputRemove.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
            this.m_btnInputRemove.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.m_btnInputRemove.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_btnInputRemove.ImageSize = new System.Drawing.Point(0, 0);
            this.m_btnInputRemove.LoadImage = null;
            this.m_btnInputRemove.Location = new System.Drawing.Point(730, -1);
            this.m_btnInputRemove.MainFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_btnInputRemove.MainFontColor = System.Drawing.Color.Black;
            this.m_btnInputRemove.Name = "m_btnInputRemove";
            this.m_btnInputRemove.Size = new System.Drawing.Size(142, 44);
            this.m_btnInputRemove.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.m_btnInputRemove.SubFontColor = System.Drawing.Color.Black;
            this.m_btnInputRemove.SubText = "";
            this.m_btnInputRemove.TabIndex = 1;
            this.m_btnInputRemove.Text = "REMOVE";
            this.m_btnInputRemove.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_btnInputRemove.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_btnInputRemove.ThemeIndex = 0;
            this.m_btnInputRemove.UseBorder = true;
            this.m_btnInputRemove.UseClickedEmphasizeTextColor = false;
            this.m_btnInputRemove.UseCustomizeClickedColor = false;
            this.m_btnInputRemove.UseEdge = true;
            this.m_btnInputRemove.UseHoverEmphasizeCustomColor = false;
            this.m_btnInputRemove.UseImage = false;
            this.m_btnInputRemove.UserHoverEmpahsize = false;
            this.m_btnInputRemove.UseSubFont = false;
            this.m_btnInputRemove.Click += new System.EventHandler(this.Click_InputButtons);
            this.m_btnInputRemove.DoubleClick += new System.EventHandler(this.Click_InputButtons);
            // 
            // m_btnInputAdd
            // 
            this.m_btnInputAdd.BorderWidth = 3;
            this.m_btnInputAdd.ButtonClicked = false;
            this.m_btnInputAdd.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.m_btnInputAdd.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.m_btnInputAdd.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.m_btnInputAdd.Description = "";
            this.m_btnInputAdd.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_btnInputAdd.EdgeRadius = 1;
            this.m_btnInputAdd.GradientAngle = 80F;
            this.m_btnInputAdd.GradientFirstColor = System.Drawing.Color.White;
            this.m_btnInputAdd.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
            this.m_btnInputAdd.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.m_btnInputAdd.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_btnInputAdd.ImageSize = new System.Drawing.Point(0, 0);
            this.m_btnInputAdd.LoadImage = null;
            this.m_btnInputAdd.Location = new System.Drawing.Point(590, -1);
            this.m_btnInputAdd.MainFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_btnInputAdd.MainFontColor = System.Drawing.Color.Black;
            this.m_btnInputAdd.Name = "m_btnInputAdd";
            this.m_btnInputAdd.Size = new System.Drawing.Size(142, 44);
            this.m_btnInputAdd.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.m_btnInputAdd.SubFontColor = System.Drawing.Color.Black;
            this.m_btnInputAdd.SubText = "";
            this.m_btnInputAdd.TabIndex = 0;
            this.m_btnInputAdd.Text = "ADD";
            this.m_btnInputAdd.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_btnInputAdd.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_btnInputAdd.ThemeIndex = 0;
            this.m_btnInputAdd.UseBorder = true;
            this.m_btnInputAdd.UseClickedEmphasizeTextColor = false;
            this.m_btnInputAdd.UseCustomizeClickedColor = false;
            this.m_btnInputAdd.UseEdge = true;
            this.m_btnInputAdd.UseHoverEmphasizeCustomColor = false;
            this.m_btnInputAdd.UseImage = false;
            this.m_btnInputAdd.UserHoverEmpahsize = false;
            this.m_btnInputAdd.UseSubFont = false;
            this.m_btnInputAdd.Click += new System.EventHandler(this.Click_InputButtons);
            this.m_btnInputAdd.DoubleClick += new System.EventHandler(this.Click_InputButtons);
            // 
            // m_btnOutputExtend
            // 
            this.m_btnOutputExtend.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnOutputExtend.BorderWidth = 3;
            this.m_btnOutputExtend.ButtonClicked = false;
            this.m_btnOutputExtend.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.m_btnOutputExtend.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.m_btnOutputExtend.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.m_btnOutputExtend.Description = "";
            this.m_btnOutputExtend.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_btnOutputExtend.EdgeRadius = 1;
            this.m_btnOutputExtend.GradientAngle = 60F;
            this.m_btnOutputExtend.GradientFirstColor = System.Drawing.Color.White;
            this.m_btnOutputExtend.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
            this.m_btnOutputExtend.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.m_btnOutputExtend.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_btnOutputExtend.ImageSize = new System.Drawing.Point(0, 0);
            this.m_btnOutputExtend.LoadImage = null;
            this.m_btnOutputExtend.Location = new System.Drawing.Point(871, -1);
            this.m_btnOutputExtend.MainFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_btnOutputExtend.MainFontColor = System.Drawing.Color.Black;
            this.m_btnOutputExtend.Name = "m_btnOutputExtend";
            this.m_btnOutputExtend.Size = new System.Drawing.Size(45, 45);
            this.m_btnOutputExtend.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.m_btnOutputExtend.SubFontColor = System.Drawing.Color.Black;
            this.m_btnOutputExtend.SubText = "";
            this.m_btnOutputExtend.TabIndex = 1;
            this.m_btnOutputExtend.Text = "◀";
            this.m_btnOutputExtend.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_btnOutputExtend.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_btnOutputExtend.ThemeIndex = 0;
            this.m_btnOutputExtend.UseBorder = true;
            this.m_btnOutputExtend.UseClickedEmphasizeTextColor = false;
            this.m_btnOutputExtend.UseCustomizeClickedColor = false;
            this.m_btnOutputExtend.UseEdge = true;
            this.m_btnOutputExtend.UseHoverEmphasizeCustomColor = false;
            this.m_btnOutputExtend.UseImage = false;
            this.m_btnOutputExtend.UserHoverEmpahsize = false;
            this.m_btnOutputExtend.UseSubFont = false;
            this.m_btnOutputExtend.Click += new System.EventHandler(this.Click_ArrowButton);
            this.m_btnOutputExtend.DoubleClick += new System.EventHandler(this.Click_ArrowButton);
            // 
            // m_btnInputExtend
            // 
            this.m_btnInputExtend.BorderWidth = 3;
            this.m_btnInputExtend.ButtonClicked = false;
            this.m_btnInputExtend.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.m_btnInputExtend.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.m_btnInputExtend.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.m_btnInputExtend.Description = "";
            this.m_btnInputExtend.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_btnInputExtend.EdgeRadius = 1;
            this.m_btnInputExtend.GradientAngle = 60F;
            this.m_btnInputExtend.GradientFirstColor = System.Drawing.Color.White;
            this.m_btnInputExtend.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
            this.m_btnInputExtend.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.m_btnInputExtend.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_btnInputExtend.ImageSize = new System.Drawing.Point(0, 0);
            this.m_btnInputExtend.LoadImage = null;
            this.m_btnInputExtend.Location = new System.Drawing.Point(871, -1);
            this.m_btnInputExtend.MainFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_btnInputExtend.MainFontColor = System.Drawing.Color.Black;
            this.m_btnInputExtend.Name = "m_btnInputExtend";
            this.m_btnInputExtend.Size = new System.Drawing.Size(45, 45);
            this.m_btnInputExtend.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.m_btnInputExtend.SubFontColor = System.Drawing.Color.Black;
            this.m_btnInputExtend.SubText = "";
            this.m_btnInputExtend.TabIndex = 0;
            this.m_btnInputExtend.Text = "◀";
            this.m_btnInputExtend.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_btnInputExtend.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_btnInputExtend.ThemeIndex = 0;
            this.m_btnInputExtend.UseBorder = true;
            this.m_btnInputExtend.UseClickedEmphasizeTextColor = false;
            this.m_btnInputExtend.UseCustomizeClickedColor = false;
            this.m_btnInputExtend.UseEdge = true;
            this.m_btnInputExtend.UseHoverEmphasizeCustomColor = false;
            this.m_btnInputExtend.UseImage = false;
            this.m_btnInputExtend.UserHoverEmpahsize = false;
            this.m_btnInputExtend.UseSubFont = false;
            this.m_btnInputExtend.Click += new System.EventHandler(this.Click_ArrowButton);
            this.m_btnInputExtend.DoubleClick += new System.EventHandler(this.Click_ArrowButton);
            // 
            // m_groupLookupInput
            // 
            this.m_groupLookupInput.BackGroundColor = System.Drawing.Color.WhiteSmoke;
            this.m_groupLookupInput.EdgeBorderStroke = 1;
            this.m_groupLookupInput.EdgeRadius = 0;
            this.m_groupLookupInput.LabelFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_groupLookupInput.LabelGradientColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.m_groupLookupInput.LabelGradientColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_groupLookupInput.LabelHeight = 43;
            this.m_groupLookupInput.LabelTextColor = System.Drawing.Color.Black;
            this.m_groupLookupInput.Location = new System.Drawing.Point(916, 0);
            this.m_groupLookupInput.Name = "m_groupLookupInput";
            this.m_groupLookupInput.Size = new System.Drawing.Size(225, 371);
            this.m_groupLookupInput.TabIndex = 1350;
            this.m_groupLookupInput.Text = "INPUT LOOKUP TABLE";
            this.m_groupLookupInput.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_groupLookupInput.ThemeIndex = 0;
            this.m_groupLookupInput.UseLabelBorder = true;
            // 
            // m_groupOutputList
            // 
            this.m_groupOutputList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_groupOutputList.BackGroundColor = System.Drawing.Color.WhiteSmoke;
            this.m_groupOutputList.EdgeBorderStroke = 1;
            this.m_groupOutputList.EdgeRadius = 0;
            this.m_groupOutputList.LabelFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_groupOutputList.LabelGradientColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.m_groupOutputList.LabelGradientColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_groupOutputList.LabelHeight = 44;
            this.m_groupOutputList.LabelTextColor = System.Drawing.Color.Black;
            this.m_groupOutputList.Location = new System.Drawing.Point(0, 0);
            this.m_groupOutputList.Name = "m_groupOutputList";
            this.m_groupOutputList.Size = new System.Drawing.Size(872, 45);
            this.m_groupOutputList.TabIndex = 1349;
            this.m_groupOutputList.Text = "OUTPUT LIST";
            this.m_groupOutputList.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_groupOutputList.ThemeIndex = 0;
            this.m_groupOutputList.UseLabelBorder = true;
            this.m_groupOutputList.Visible = false;
            // 
            // m_groupLookupOutput
            // 
            this.m_groupLookupOutput.BackGroundColor = System.Drawing.Color.WhiteSmoke;
            this.m_groupLookupOutput.EdgeBorderStroke = 1;
            this.m_groupLookupOutput.EdgeRadius = 0;
            this.m_groupLookupOutput.LabelFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_groupLookupOutput.LabelGradientColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.m_groupLookupOutput.LabelGradientColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_groupLookupOutput.LabelHeight = 43;
            this.m_groupLookupOutput.LabelTextColor = System.Drawing.Color.Black;
            this.m_groupLookupOutput.Location = new System.Drawing.Point(916, 0);
            this.m_groupLookupOutput.Name = "m_groupLookupOutput";
            this.m_groupLookupOutput.Size = new System.Drawing.Size(225, 371);
            this.m_groupLookupOutput.TabIndex = 1351;
            this.m_groupLookupOutput.Text = "OUTPUT LOOKUP TABLE";
            this.m_groupLookupOutput.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_groupLookupOutput.ThemeIndex = 0;
            this.m_groupLookupOutput.UseLabelBorder = true;
            this.m_groupLookupOutput.Visible = false;
            // 
            // m_btnOutputRemove
            // 
            this.m_btnOutputRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnOutputRemove.BorderWidth = 3;
            this.m_btnOutputRemove.ButtonClicked = false;
            this.m_btnOutputRemove.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.m_btnOutputRemove.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.m_btnOutputRemove.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.m_btnOutputRemove.Description = "";
            this.m_btnOutputRemove.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_btnOutputRemove.EdgeRadius = 1;
            this.m_btnOutputRemove.Enabled = false;
            this.m_btnOutputRemove.GradientAngle = 80F;
            this.m_btnOutputRemove.GradientFirstColor = System.Drawing.Color.White;
            this.m_btnOutputRemove.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
            this.m_btnOutputRemove.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.m_btnOutputRemove.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_btnOutputRemove.ImageSize = new System.Drawing.Point(0, 0);
            this.m_btnOutputRemove.LoadImage = null;
            this.m_btnOutputRemove.Location = new System.Drawing.Point(730, -1);
            this.m_btnOutputRemove.MainFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_btnOutputRemove.MainFontColor = System.Drawing.Color.Black;
            this.m_btnOutputRemove.Name = "m_btnOutputRemove";
            this.m_btnOutputRemove.Size = new System.Drawing.Size(142, 44);
            this.m_btnOutputRemove.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.m_btnOutputRemove.SubFontColor = System.Drawing.Color.Black;
            this.m_btnOutputRemove.SubText = "";
            this.m_btnOutputRemove.TabIndex = 1;
            this.m_btnOutputRemove.Text = "REMOVE";
            this.m_btnOutputRemove.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_btnOutputRemove.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_btnOutputRemove.ThemeIndex = 0;
            this.m_btnOutputRemove.UseBorder = true;
            this.m_btnOutputRemove.UseClickedEmphasizeTextColor = false;
            this.m_btnOutputRemove.UseCustomizeClickedColor = false;
            this.m_btnOutputRemove.UseEdge = true;
            this.m_btnOutputRemove.UseHoverEmphasizeCustomColor = false;
            this.m_btnOutputRemove.UseImage = false;
            this.m_btnOutputRemove.UserHoverEmpahsize = false;
            this.m_btnOutputRemove.UseSubFont = false;
            this.m_btnOutputRemove.Click += new System.EventHandler(this.Click_OutputButtons);
            this.m_btnOutputRemove.DoubleClick += new System.EventHandler(this.Click_OutputButtons);
            // 
            // m_btnOutputAdd
            // 
            this.m_btnOutputAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnOutputAdd.BorderWidth = 3;
            this.m_btnOutputAdd.ButtonClicked = false;
            this.m_btnOutputAdd.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.m_btnOutputAdd.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.m_btnOutputAdd.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.m_btnOutputAdd.Description = "";
            this.m_btnOutputAdd.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_btnOutputAdd.EdgeRadius = 1;
            this.m_btnOutputAdd.GradientAngle = 80F;
            this.m_btnOutputAdd.GradientFirstColor = System.Drawing.Color.White;
            this.m_btnOutputAdd.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
            this.m_btnOutputAdd.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.m_btnOutputAdd.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_btnOutputAdd.ImageSize = new System.Drawing.Point(0, 0);
            this.m_btnOutputAdd.LoadImage = null;
            this.m_btnOutputAdd.Location = new System.Drawing.Point(590, -1);
            this.m_btnOutputAdd.MainFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_btnOutputAdd.MainFontColor = System.Drawing.Color.Black;
            this.m_btnOutputAdd.Name = "m_btnOutputAdd";
            this.m_btnOutputAdd.Size = new System.Drawing.Size(142, 44);
            this.m_btnOutputAdd.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.m_btnOutputAdd.SubFontColor = System.Drawing.Color.Black;
            this.m_btnOutputAdd.SubText = "";
            this.m_btnOutputAdd.TabIndex = 0;
            this.m_btnOutputAdd.Text = "ADD";
            this.m_btnOutputAdd.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_btnOutputAdd.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_btnOutputAdd.ThemeIndex = 0;
            this.m_btnOutputAdd.UseBorder = true;
            this.m_btnOutputAdd.UseClickedEmphasizeTextColor = false;
            this.m_btnOutputAdd.UseCustomizeClickedColor = false;
            this.m_btnOutputAdd.UseEdge = true;
            this.m_btnOutputAdd.UseHoverEmphasizeCustomColor = false;
            this.m_btnOutputAdd.UseImage = false;
            this.m_btnOutputAdd.UserHoverEmpahsize = false;
            this.m_btnOutputAdd.UseSubFont = false;
            this.m_btnOutputAdd.Click += new System.EventHandler(this.Click_OutputButtons);
            this.m_btnOutputAdd.DoubleClick += new System.EventHandler(this.Click_OutputButtons);
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
            this.sys3GroupBox1.Location = new System.Drawing.Point(915, 372);
            this.sys3GroupBox1.Name = "sys3GroupBox1";
            this.sys3GroupBox1.Size = new System.Drawing.Size(226, 82);
            this.sys3GroupBox1.TabIndex = 1361;
            this.sys3GroupBox1.Text = "CHANGE LIST";
            this.sys3GroupBox1.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3GroupBox1.ThemeIndex = 0;
            this.sys3GroupBox1.UseLabelBorder = true;
            // 
            // m_groupGraph
            // 
            this.m_groupGraph.BackGroundColor = System.Drawing.Color.WhiteSmoke;
            this.m_groupGraph.EdgeBorderStroke = 1;
            this.m_groupGraph.EdgeRadius = 0;
            this.m_groupGraph.Font = new System.Drawing.Font("굴림", 12F);
            this.m_groupGraph.LabelFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_groupGraph.LabelGradientColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.m_groupGraph.LabelGradientColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.m_groupGraph.LabelHeight = 80;
            this.m_groupGraph.LabelTextColor = System.Drawing.Color.Black;
            this.m_groupGraph.Location = new System.Drawing.Point(0, 372);
            this.m_groupGraph.Name = "m_groupGraph";
            this.m_groupGraph.Size = new System.Drawing.Size(249, 81);
            this.m_groupGraph.TabIndex = 1362;
            this.m_groupGraph.Text = "VOLTAGE GRAPH";
            this.m_groupGraph.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_groupGraph.ThemeIndex = 0;
            this.m_groupGraph.UseLabelBorder = true;
            // 
            // sys3GroupBox2
            // 
            this.sys3GroupBox2.BackGroundColor = System.Drawing.Color.WhiteSmoke;
            this.sys3GroupBox2.EdgeBorderStroke = 2;
            this.sys3GroupBox2.EdgeRadius = 2;
            this.sys3GroupBox2.LabelFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3GroupBox2.LabelGradientColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.sys3GroupBox2.LabelGradientColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.sys3GroupBox2.LabelHeight = 30;
            this.sys3GroupBox2.LabelTextColor = System.Drawing.Color.Black;
            this.sys3GroupBox2.Location = new System.Drawing.Point(679, 372);
            this.sys3GroupBox2.Name = "sys3GroupBox2";
            this.sys3GroupBox2.Size = new System.Drawing.Size(237, 82);
            this.sys3GroupBox2.TabIndex = 1364;
            this.sys3GroupBox2.Text = "TRACKING";
            this.sys3GroupBox2.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3GroupBox2.ThemeIndex = 0;
            this.sys3GroupBox2.UseLabelBorder = true;
            // 
            // m_ToggleInputOnDelay
            // 
            this.m_ToggleInputOnDelay.Active = false;
            this.m_ToggleInputOnDelay.ActiveColorFirst = System.Drawing.Color.RoyalBlue;
            this.m_ToggleInputOnDelay.ActiveColorSecond = System.Drawing.Color.DodgerBlue;
            this.m_ToggleInputOnDelay.BackColor = System.Drawing.Color.WhiteSmoke;
            this.m_ToggleInputOnDelay.Location = new System.Drawing.Point(805, 405);
            this.m_ToggleInputOnDelay.Name = "m_ToggleInputOnDelay";
            this.m_ToggleInputOnDelay.NormalColorFirst = System.Drawing.Color.DarkGray;
            this.m_ToggleInputOnDelay.NormalColorSecond = System.Drawing.Color.Silver;
            this.m_ToggleInputOnDelay.Size = new System.Drawing.Size(86, 43);
            this.m_ToggleInputOnDelay.TabIndex = 1365;
            this.m_ToggleInputOnDelay.Click += new System.EventHandler(this.Click_ToggleButton);
            this.m_ToggleInputOnDelay.DoubleClick += new System.EventHandler(this.Click_ToggleButton);
            // 
            // m_labelStart
            // 
            this.m_labelStart.BackGroundColor = System.Drawing.Color.WhiteSmoke;
            this.m_labelStart.BorderStroke = 2;
            this.m_labelStart.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_labelStart.Description = "";
            this.m_labelStart.DisabledColor = System.Drawing.Color.Silver;
            this.m_labelStart.EdgeRadius = 1;
            this.m_labelStart.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_labelStart.ImageSize = new System.Drawing.Point(0, 0);
            this.m_labelStart.LoadImage = null;
            this.m_labelStart.Location = new System.Drawing.Point(680, 401);
            this.m_labelStart.MainFont = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.m_labelStart.MainFontColor = System.Drawing.Color.Black;
            this.m_labelStart.Name = "m_labelStart";
            this.m_labelStart.Size = new System.Drawing.Size(235, 52);
            this.m_labelStart.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.m_labelStart.SubFontColor = System.Drawing.Color.Black;
            this.m_labelStart.SubText = "";
            this.m_labelStart.TabIndex = 1366;
            this.m_labelStart.Text = "  OFF / ON";
            this.m_labelStart.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_LEFT;
            this.m_labelStart.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_labelStart.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_labelStart.ThemeIndex = 0;
            this.m_labelStart.UnitAreaRate = 30;
            this.m_labelStart.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_labelStart.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_labelStart.UnitPositionVertical = false;
            this.m_labelStart.UnitText = "";
            this.m_labelStart.UseBorder = true;
            this.m_labelStart.UseEdgeRadius = false;
            this.m_labelStart.UseImage = false;
            this.m_labelStart.UseSubFont = false;
            this.m_labelStart.UseUnitFont = false;
            // 
            // m_ZedGraph
            // 
            this.m_ZedGraph.Location = new System.Drawing.Point(4, 454);
            this.m_ZedGraph.Name = "m_ZedGraph";
            this.m_ZedGraph.ScrollGrace = 0D;
            this.m_ZedGraph.ScrollMaxX = 0D;
            this.m_ZedGraph.ScrollMaxY = 0D;
            this.m_ZedGraph.ScrollMaxY2 = 0D;
            this.m_ZedGraph.ScrollMinX = 0D;
            this.m_ZedGraph.ScrollMinY = 0D;
            this.m_ZedGraph.ScrollMinY2 = 0D;
            this.m_ZedGraph.Size = new System.Drawing.Size(1133, 443);
            this.m_ZedGraph.TabIndex = 1369;
            // 
            // m_btnOutAdd
            // 
            this.m_btnOutAdd.BorderWidth = 3;
            this.m_btnOutAdd.ButtonClicked = false;
            this.m_btnOutAdd.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.m_btnOutAdd.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.m_btnOutAdd.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.m_btnOutAdd.Description = "";
            this.m_btnOutAdd.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_btnOutAdd.EdgeRadius = 5;
            this.m_btnOutAdd.GradientAngle = 50F;
            this.m_btnOutAdd.GradientFirstColor = System.Drawing.Color.White;
            this.m_btnOutAdd.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
            this.m_btnOutAdd.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.m_btnOutAdd.ImagePosition = new System.Drawing.Point(12, 10);
            this.m_btnOutAdd.ImageSize = new System.Drawing.Point(30, 30);
            this.m_btnOutAdd.LoadImage = ((System.Drawing.Image)(resources.GetObject("m_btnOutAdd.LoadImage")));
            this.m_btnOutAdd.Location = new System.Drawing.Point(394, 374);
            this.m_btnOutAdd.MainFont = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.m_btnOutAdd.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
            this.m_btnOutAdd.Name = "m_btnOutAdd";
            this.m_btnOutAdd.Size = new System.Drawing.Size(133, 80);
            this.m_btnOutAdd.SubFont = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.m_btnOutAdd.SubFontColor = System.Drawing.Color.DarkBlue;
            this.m_btnOutAdd.SubText = "OUTPUT";
            this.m_btnOutAdd.TabIndex = 11;
            this.m_btnOutAdd.Text = "ADD";
            this.m_btnOutAdd.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.m_btnOutAdd.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_RIGHT;
            this.m_btnOutAdd.ThemeIndex = 0;
            this.m_btnOutAdd.UseBorder = true;
            this.m_btnOutAdd.UseClickedEmphasizeTextColor = false;
            this.m_btnOutAdd.UseCustomizeClickedColor = false;
            this.m_btnOutAdd.UseEdge = true;
            this.m_btnOutAdd.UseHoverEmphasizeCustomColor = false;
            this.m_btnOutAdd.UseImage = true;
            this.m_btnOutAdd.UserHoverEmpahsize = false;
            this.m_btnOutAdd.UseSubFont = true;
            this.m_btnOutAdd.Click += new System.EventHandler(this.Click_btnADD);
            this.m_btnOutAdd.DoubleClick += new System.EventHandler(this.Click_btnADD);
            // 
            // sys3btnClear
            // 
            this.sys3btnClear.BorderWidth = 3;
            this.sys3btnClear.ButtonClicked = false;
            this.sys3btnClear.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.sys3btnClear.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.sys3btnClear.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.sys3btnClear.Description = "";
            this.sys3btnClear.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3btnClear.EdgeRadius = 5;
            this.sys3btnClear.GradientAngle = 70F;
            this.sys3btnClear.GradientFirstColor = System.Drawing.Color.White;
            this.sys3btnClear.GradientSecondColor = System.Drawing.Color.LightSlateGray;
            this.sys3btnClear.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.sys3btnClear.ImagePosition = new System.Drawing.Point(10, 10);
            this.sys3btnClear.ImageSize = new System.Drawing.Point(30, 30);
            this.sys3btnClear.LoadImage = global::FrameOfSystem3.Properties.Resources.CLEAR_BLACK;
            this.sys3btnClear.Location = new System.Drawing.Point(533, 373);
            this.sys3btnClear.MainFont = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.sys3btnClear.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
            this.sys3btnClear.Name = "sys3btnClear";
            this.sys3btnClear.Size = new System.Drawing.Size(140, 80);
            this.sys3btnClear.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.sys3btnClear.SubFontColor = System.Drawing.Color.DarkBlue;
            this.sys3btnClear.SubText = "STATUS";
            this.sys3btnClear.TabIndex = 1368;
            this.sys3btnClear.Text = "CLEAR ITEM";
            this.sys3btnClear.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3btnClear.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.sys3btnClear.ThemeIndex = 0;
            this.sys3btnClear.UseBorder = true;
            this.sys3btnClear.UseClickedEmphasizeTextColor = false;
            this.sys3btnClear.UseCustomizeClickedColor = false;
            this.sys3btnClear.UseEdge = true;
            this.sys3btnClear.UseHoverEmphasizeCustomColor = false;
            this.sys3btnClear.UseImage = false;
            this.sys3btnClear.UserHoverEmpahsize = false;
            this.sys3btnClear.UseSubFont = false;
            this.sys3btnClear.Click += new System.EventHandler(this.Click_Clear);
            // 
            // m_btnInAdd
            // 
            this.m_btnInAdd.BorderWidth = 3;
            this.m_btnInAdd.ButtonClicked = false;
            this.m_btnInAdd.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.m_btnInAdd.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.m_btnInAdd.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.m_btnInAdd.Description = "";
            this.m_btnInAdd.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_btnInAdd.EdgeRadius = 5;
            this.m_btnInAdd.GradientAngle = 50F;
            this.m_btnInAdd.GradientFirstColor = System.Drawing.Color.White;
            this.m_btnInAdd.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(176)))), ((int)(((byte)(183)))));
            this.m_btnInAdd.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.m_btnInAdd.ImagePosition = new System.Drawing.Point(12, 10);
            this.m_btnInAdd.ImageSize = new System.Drawing.Point(30, 30);
            this.m_btnInAdd.LoadImage = ((System.Drawing.Image)(resources.GetObject("m_btnInAdd.LoadImage")));
            this.m_btnInAdd.Location = new System.Drawing.Point(255, 373);
            this.m_btnInAdd.MainFont = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.m_btnInAdd.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
            this.m_btnInAdd.Name = "m_btnInAdd";
            this.m_btnInAdd.Size = new System.Drawing.Size(133, 80);
            this.m_btnInAdd.SubFont = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.m_btnInAdd.SubFontColor = System.Drawing.Color.DarkBlue;
            this.m_btnInAdd.SubText = "INPUT";
            this.m_btnInAdd.TabIndex = 10;
            this.m_btnInAdd.Text = "ADD";
            this.m_btnInAdd.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.m_btnInAdd.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_RIGHT;
            this.m_btnInAdd.ThemeIndex = 0;
            this.m_btnInAdd.UseBorder = true;
            this.m_btnInAdd.UseClickedEmphasizeTextColor = false;
            this.m_btnInAdd.UseCustomizeClickedColor = false;
            this.m_btnInAdd.UseEdge = true;
            this.m_btnInAdd.UseHoverEmphasizeCustomColor = false;
            this.m_btnInAdd.UseImage = true;
            this.m_btnInAdd.UserHoverEmpahsize = false;
            this.m_btnInAdd.UseSubFont = true;
            this.m_btnInAdd.Click += new System.EventHandler(this.Click_btnADD);
            this.m_btnInAdd.DoubleClick += new System.EventHandler(this.Click_btnADD);
            // 
            // m_btnOutput
            // 
            this.m_btnOutput.BorderWidth = 2;
            this.m_btnOutput.ButtonClicked = false;
            this.m_btnOutput.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.m_btnOutput.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.m_btnOutput.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.m_btnOutput.Description = "";
            this.m_btnOutput.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_btnOutput.EdgeRadius = 5;
            this.m_btnOutput.GradientAngle = 70F;
            this.m_btnOutput.GradientFirstColor = System.Drawing.Color.White;
            this.m_btnOutput.GradientSecondColor = System.Drawing.Color.White;
            this.m_btnOutput.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.m_btnOutput.ImagePosition = new System.Drawing.Point(7, 7);
            this.m_btnOutput.ImageSize = new System.Drawing.Point(30, 30);
            this.m_btnOutput.LoadImage = global::FrameOfSystem3.Properties.Resources.Home_black;
            this.m_btnOutput.Location = new System.Drawing.Point(1027, 401);
            this.m_btnOutput.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_btnOutput.MainFontColor = System.Drawing.Color.DarkBlue;
            this.m_btnOutput.Name = "m_btnOutput";
            this.m_btnOutput.Size = new System.Drawing.Size(113, 52);
            this.m_btnOutput.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.m_btnOutput.SubFontColor = System.Drawing.Color.DarkBlue;
            this.m_btnOutput.SubText = "STATUS";
            this.m_btnOutput.TabIndex = 1;
            this.m_btnOutput.Text = "OUTPUT";
            this.m_btnOutput.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_btnOutput.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_RIGHT;
            this.m_btnOutput.ThemeIndex = 0;
            this.m_btnOutput.UseBorder = false;
            this.m_btnOutput.UseClickedEmphasizeTextColor = false;
            this.m_btnOutput.UseCustomizeClickedColor = false;
            this.m_btnOutput.UseEdge = false;
            this.m_btnOutput.UseHoverEmphasizeCustomColor = false;
            this.m_btnOutput.UseImage = false;
            this.m_btnOutput.UserHoverEmpahsize = false;
            this.m_btnOutput.UseSubFont = false;
            this.m_btnOutput.Click += new System.EventHandler(this.Click_ChangeList);
            this.m_btnOutput.DoubleClick += new System.EventHandler(this.Click_ChangeList);
            // 
            // m_btnInput
            // 
            this.m_btnInput.BorderWidth = 2;
            this.m_btnInput.ButtonClicked = true;
            this.m_btnInput.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.m_btnInput.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.m_btnInput.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.m_btnInput.Description = "";
            this.m_btnInput.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_btnInput.EdgeRadius = 5;
            this.m_btnInput.GradientAngle = 70F;
            this.m_btnInput.GradientFirstColor = System.Drawing.Color.DarkBlue;
            this.m_btnInput.GradientSecondColor = System.Drawing.Color.DarkBlue;
            this.m_btnInput.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.m_btnInput.ImagePosition = new System.Drawing.Point(7, 7);
            this.m_btnInput.ImageSize = new System.Drawing.Point(30, 30);
            this.m_btnInput.LoadImage = global::FrameOfSystem3.Properties.Resources.Home_black;
            this.m_btnInput.Location = new System.Drawing.Point(916, 402);
            this.m_btnInput.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_btnInput.MainFontColor = System.Drawing.Color.White;
            this.m_btnInput.Name = "m_btnInput";
            this.m_btnInput.Size = new System.Drawing.Size(113, 52);
            this.m_btnInput.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.m_btnInput.SubFontColor = System.Drawing.Color.DarkBlue;
            this.m_btnInput.SubText = "STATUS";
            this.m_btnInput.TabIndex = 0;
            this.m_btnInput.Text = "INPUT";
            this.m_btnInput.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_btnInput.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_RIGHT;
            this.m_btnInput.ThemeIndex = 0;
            this.m_btnInput.UseBorder = false;
            this.m_btnInput.UseClickedEmphasizeTextColor = false;
            this.m_btnInput.UseCustomizeClickedColor = false;
            this.m_btnInput.UseEdge = false;
            this.m_btnInput.UseHoverEmphasizeCustomColor = false;
            this.m_btnInput.UseImage = false;
            this.m_btnInput.UserHoverEmpahsize = false;
            this.m_btnInput.UseSubFont = false;
            this.m_btnInput.Click += new System.EventHandler(this.Click_ChangeList);
            this.m_btnInput.DoubleClick += new System.EventHandler(this.Click_ChangeList);
            // 
            // m_pnlAnalogItemView
            // 
            this.m_pnlAnalogItemView.Location = new System.Drawing.Point(0, 43);
            this.m_pnlAnalogItemView.Margin = new System.Windows.Forms.Padding(0);
            this.m_pnlAnalogItemView.Name = "m_pnlAnalogItemView";
            this.m_pnlAnalogItemView.Size = new System.Drawing.Size(915, 328);
            this.m_pnlAnalogItemView.TabIndex = 1370;
            // 
            // Config_Analog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_pnlAnalogItemView);
            this.Controls.Add(this.m_btnOutAdd);
            this.Controls.Add(this.m_ZedGraph);
            this.Controls.Add(this.sys3btnClear);
            this.Controls.Add(this.m_btnInAdd);
            this.Controls.Add(this.m_ToggleInputOnDelay);
            this.Controls.Add(this.m_labelStart);
            this.Controls.Add(this.sys3GroupBox2);
            this.Controls.Add(this.m_groupGraph);
            this.Controls.Add(this.m_btnInputExtend);
            this.Controls.Add(this.m_groupInputList);
            this.Controls.Add(this.m_groupOutputList);
            this.Controls.Add(this.m_btnOutput);
            this.Controls.Add(this.m_btnInput);
            this.Controls.Add(this.sys3GroupBox1);
            this.Controls.Add(this.m_dgViewLookupInput);
            this.Controls.Add(this.m_dgViewLookupOutput);
            this.Controls.Add(this.m_btnInputRemove);
            this.Controls.Add(this.m_btnInputAdd);
            this.Controls.Add(this.m_btnOutputExtend);
            this.Controls.Add(this.m_groupLookupInput);
            this.Controls.Add(this.m_groupLookupOutput);
            this.Controls.Add(this.m_btnOutputRemove);
            this.Controls.Add(this.m_btnOutputAdd);
            this.Name = "Config_Analog";
            this.Size = new System.Drawing.Size(1140, 900);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgViewLookupOutput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgViewLookupInput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sys3Controls.Sys3DoubleBufferedDataGridView m_dgViewLookupOutput;
		private Sys3Controls.Sys3DoubleBufferedDataGridView m_dgViewLookupInput;
		private Sys3Controls.Sys3GroupBox m_groupInputList;
		private Sys3Controls.Sys3GroupBox m_groupOutputList;
		private Sys3Controls.Sys3GroupBox m_groupLookupInput;
		private Sys3Controls.Sys3GroupBox m_groupLookupOutput;
		private Sys3Controls.Sys3button m_btnInputExtend;
		private Sys3Controls.Sys3button m_btnOutputExtend;
		private Sys3Controls.Sys3button m_btnInputAdd;
		private Sys3Controls.Sys3button m_btnInputRemove;
		private Sys3Controls.Sys3button m_btnOutputAdd;
		private Sys3Controls.Sys3button m_btnOutputRemove;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private Sys3Controls.Sys3button m_btnOutput;
        private Sys3Controls.Sys3button m_btnInput;
        private Sys3Controls.Sys3GroupBox sys3GroupBox1;
        private Sys3Controls.Sys3GroupBox m_groupGraph;
        private Sys3Controls.Sys3GroupBox sys3GroupBox2;
        private Sys3Controls.Sys3ToggleButton m_ToggleInputOnDelay;
        private Sys3Controls.Sys3Label m_labelStart;
        private Sys3Controls.Sys3button m_btnInAdd;
        private Sys3Controls.Sys3button sys3btnClear;
        private global::ZedGraph.ZedGraphControl m_ZedGraph;
        private Sys3Controls.Sys3button m_btnOutAdd;
        private System.Windows.Forms.Panel m_pnlAnalogItemView;
    }
}
