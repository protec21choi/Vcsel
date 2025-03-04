﻿namespace FrameOfSystem3.Views.Config
{
    partial class Config_Trigger
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.m_ledIO = new Sys3Controls.Sys3LedLabel();
            this.m_dgViewInterLock = new Sys3Controls.Sys3DoubleBufferedDataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ENABLE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PASSWORD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AUTHORITY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CONDITION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.active = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BLINK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Active2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_groupList = new Sys3Controls.Sys3GroupBox();
            this.m_groupSelectedItem = new Sys3Controls.Sys3GroupBox();
            this.m_groupConfiguration = new Sys3Controls.Sys3GroupBox();
            this.m_lblBlinkInterval = new Sys3Controls.Sys3Label();
            this.m_lblBlinkConditionAlarm = new Sys3Controls.Sys3Label();
            this.m_lblBlinkCondition = new Sys3Controls.Sys3Label();
            this.m_lblKey = new Sys3Controls.Sys3Label();
            this.m_lblConditionAlarm = new Sys3Controls.Sys3Label();
            this.m_lblCondition = new Sys3Controls.Sys3Label();
            this.m_lblTarget = new Sys3Controls.Sys3Label();
            this.m_lblName = new Sys3Controls.Sys3Label();
            this.m_labelName = new Sys3Controls.Sys3Label();
            this.m_labelBlinkInterval = new Sys3Controls.Sys3Label();
            this.m_labelTarget = new Sys3Controls.Sys3Label();
            this.m_labelCondition = new Sys3Controls.Sys3Label();
            this.m_labelConditionAlarm = new Sys3Controls.Sys3Label();
            this.m_labelBlinkCondition = new Sys3Controls.Sys3Label();
            this.m_labelBlinkConditionAlarm = new Sys3Controls.Sys3Label();
            this.m_labelKey = new Sys3Controls.Sys3Label();
            this.m_btnDisable = new Sys3Controls.Sys3button();
            this.m_btnEnable = new Sys3Controls.Sys3button();
            this.m_btnRemove = new Sys3Controls.Sys3button();
            this.m_btnAdd = new Sys3Controls.Sys3button();
            this.m_labelCheckInterval = new Sys3Controls.Sys3Label();
            this.sys3Label2 = new Sys3Controls.Sys3Label();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgViewInterLock)).BeginInit();
            this.SuspendLayout();
            // 
            // m_ledIO
            // 
            this.m_ledIO.Active = false;
            this.m_ledIO.ColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(216)))), ((int)(((byte)(101)))));
            this.m_ledIO.ColorNormal = System.Drawing.Color.DimGray;
            this.m_ledIO.Location = new System.Drawing.Point(163, 729);
            this.m_ledIO.Name = "m_ledIO";
            this.m_ledIO.Size = new System.Drawing.Size(20, 46);
            this.m_ledIO.TabIndex = 1122;
            // 
            // m_dgViewInterLock
            // 
            this.m_dgViewInterLock.AllowUserToAddRows = false;
            this.m_dgViewInterLock.AllowUserToDeleteRows = false;
            this.m_dgViewInterLock.AllowUserToResizeColumns = false;
            this.m_dgViewInterLock.AllowUserToResizeRows = false;
            this.m_dgViewInterLock.BackgroundColor = System.Drawing.Color.White;
            this.m_dgViewInterLock.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.m_dgViewInterLock.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_dgViewInterLock.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.m_dgViewInterLock.ColumnHeadersHeight = 30;
            this.m_dgViewInterLock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.m_dgViewInterLock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.ENABLE,
            this.PASSWORD,
            this.AUTHORITY,
            this.STATE,
            this.CONDITION,
            this.active,
            this.BLINK,
            this.Active2});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.m_dgViewInterLock.DefaultCellStyle = dataGridViewCellStyle8;
            this.m_dgViewInterLock.EnableHeadersVisualStyles = false;
            this.m_dgViewInterLock.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            this.m_dgViewInterLock.Location = new System.Drawing.Point(3, 31);
            this.m_dgViewInterLock.MultiSelect = false;
            this.m_dgViewInterLock.Name = "m_dgViewInterLock";
            this.m_dgViewInterLock.ReadOnly = true;
            this.m_dgViewInterLock.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("맑은 고딕", 11F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_dgViewInterLock.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.m_dgViewInterLock.RowHeadersVisible = false;
            this.m_dgViewInterLock.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.m_dgViewInterLock.RowTemplate.Height = 23;
            this.m_dgViewInterLock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgViewInterLock.Size = new System.Drawing.Size(1133, 522);
            this.m_dgViewInterLock.TabIndex = 1112;
            this.m_dgViewInterLock.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Click_Dgview);
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
            this.ID.Width = 60;
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
            // PASSWORD
            // 
            this.PASSWORD.Frozen = true;
            this.PASSWORD.HeaderText = "NAME";
            this.PASSWORD.MaxInputLength = 20;
            this.PASSWORD.Name = "PASSWORD";
            this.PASSWORD.ReadOnly = true;
            this.PASSWORD.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PASSWORD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PASSWORD.Width = 300;
            // 
            // AUTHORITY
            // 
            this.AUTHORITY.HeaderText = "TARGET";
            this.AUTHORITY.MaxInputLength = 20;
            this.AUTHORITY.Name = "AUTHORITY";
            this.AUTHORITY.ReadOnly = true;
            this.AUTHORITY.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.AUTHORITY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.AUTHORITY.Width = 65;
            // 
            // STATE
            // 
            this.STATE.HeaderText = "";
            this.STATE.Name = "STATE";
            this.STATE.ReadOnly = true;
            this.STATE.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.STATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.STATE.Width = 30;
            // 
            // CONDITION
            // 
            this.CONDITION.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CONDITION.HeaderText = "CONDITION";
            this.CONDITION.Name = "CONDITION";
            this.CONDITION.ReadOnly = true;
            this.CONDITION.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CONDITION.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // active
            // 
            this.active.HeaderText = "";
            this.active.Name = "active";
            this.active.ReadOnly = true;
            this.active.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.active.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.active.Width = 30;
            // 
            // BLINK
            // 
            this.BLINK.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BLINK.HeaderText = "BLINK CONDITION";
            this.BLINK.Name = "BLINK";
            this.BLINK.ReadOnly = true;
            this.BLINK.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.BLINK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Active2
            // 
            this.Active2.HeaderText = "";
            this.Active2.Name = "Active2";
            this.Active2.ReadOnly = true;
            this.Active2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Active2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Active2.Width = 30;
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
            this.m_groupList.Size = new System.Drawing.Size(1140, 553);
            this.m_groupList.TabIndex = 1370;
            this.m_groupList.Text = "TRIGGER LIST";
            this.m_groupList.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
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
            this.m_groupSelectedItem.LabelHeight = 32;
            this.m_groupSelectedItem.LabelTextColor = System.Drawing.Color.Black;
            this.m_groupSelectedItem.Location = new System.Drawing.Point(0, 552);
            this.m_groupSelectedItem.Name = "m_groupSelectedItem";
            this.m_groupSelectedItem.Size = new System.Drawing.Size(1137, 98);
            this.m_groupSelectedItem.TabIndex = 1371;
            this.m_groupSelectedItem.Text = "SELECTED ITEM";
            this.m_groupSelectedItem.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
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
            this.m_groupConfiguration.LabelHeight = 32;
            this.m_groupConfiguration.LabelTextColor = System.Drawing.Color.Black;
            this.m_groupConfiguration.Location = new System.Drawing.Point(0, 646);
            this.m_groupConfiguration.Name = "m_groupConfiguration";
            this.m_groupConfiguration.Size = new System.Drawing.Size(1137, 254);
            this.m_groupConfiguration.TabIndex = 1372;
            this.m_groupConfiguration.Text = "CONFIGURATION";
            this.m_groupConfiguration.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_groupConfiguration.UseLabelBorder = true;
            // 
            // m_lblBlinkInterval
            // 
            this.m_lblBlinkInterval.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
            this.m_lblBlinkInterval.BorderStroke = 2;
            this.m_lblBlinkInterval.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblBlinkInterval.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblBlinkInterval.EdgeRadius = 1;
            this.m_lblBlinkInterval.Location = new System.Drawing.Point(858, 592);
            this.m_lblBlinkInterval.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.m_lblBlinkInterval.MainFontColor = System.Drawing.Color.Black;
            this.m_lblBlinkInterval.Name = "m_lblBlinkInterval";
            this.m_lblBlinkInterval.Size = new System.Drawing.Size(155, 45);
            this.m_lblBlinkInterval.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.m_lblBlinkInterval.SubFontColor = System.Drawing.Color.Black;
            this.m_lblBlinkInterval.SubText = "";
            this.m_lblBlinkInterval.TabIndex = 1377;
            this.m_lblBlinkInterval.Text = "BLINK INTERVAL";
            this.m_lblBlinkInterval.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblBlinkInterval.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblBlinkInterval.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblBlinkInterval.UnitAreaRate = 40;
            this.m_lblBlinkInterval.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblBlinkInterval.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblBlinkInterval.UnitPositionVertical = false;
            this.m_lblBlinkInterval.UnitText = "";
            this.m_lblBlinkInterval.UseBorder = true;
            this.m_lblBlinkInterval.UseEdgeRadius = false;
            this.m_lblBlinkInterval.UseSubFont = false;
            this.m_lblBlinkInterval.UseUnitFont = false;
            // 
            // m_lblBlinkConditionAlarm
            // 
            this.m_lblBlinkConditionAlarm.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
            this.m_lblBlinkConditionAlarm.BorderStroke = 2;
            this.m_lblBlinkConditionAlarm.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblBlinkConditionAlarm.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblBlinkConditionAlarm.EdgeRadius = 1;
            this.m_lblBlinkConditionAlarm.Location = new System.Drawing.Point(568, 750);
            this.m_lblBlinkConditionAlarm.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.m_lblBlinkConditionAlarm.MainFontColor = System.Drawing.Color.Black;
            this.m_lblBlinkConditionAlarm.Name = "m_lblBlinkConditionAlarm";
            this.m_lblBlinkConditionAlarm.Size = new System.Drawing.Size(155, 57);
            this.m_lblBlinkConditionAlarm.SubFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.m_lblBlinkConditionAlarm.SubFontColor = System.Drawing.Color.Red;
            this.m_lblBlinkConditionAlarm.SubText = "ALARM STATE";
            this.m_lblBlinkConditionAlarm.TabIndex = 1378;
            this.m_lblBlinkConditionAlarm.Text = "BLINK CONDITION";
            this.m_lblBlinkConditionAlarm.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblBlinkConditionAlarm.TextAlignSub = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
            this.m_lblBlinkConditionAlarm.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblBlinkConditionAlarm.UnitAreaRate = 40;
            this.m_lblBlinkConditionAlarm.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblBlinkConditionAlarm.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblBlinkConditionAlarm.UnitPositionVertical = false;
            this.m_lblBlinkConditionAlarm.UnitText = "";
            this.m_lblBlinkConditionAlarm.UseBorder = true;
            this.m_lblBlinkConditionAlarm.UseEdgeRadius = false;
            this.m_lblBlinkConditionAlarm.UseSubFont = true;
            this.m_lblBlinkConditionAlarm.UseUnitFont = false;
            // 
            // m_lblBlinkCondition
            // 
            this.m_lblBlinkCondition.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
            this.m_lblBlinkCondition.BorderStroke = 2;
            this.m_lblBlinkCondition.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblBlinkCondition.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblBlinkCondition.EdgeRadius = 1;
            this.m_lblBlinkCondition.Location = new System.Drawing.Point(568, 687);
            this.m_lblBlinkCondition.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.m_lblBlinkCondition.MainFontColor = System.Drawing.Color.Black;
            this.m_lblBlinkCondition.Name = "m_lblBlinkCondition";
            this.m_lblBlinkCondition.Size = new System.Drawing.Size(155, 57);
            this.m_lblBlinkCondition.SubFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.m_lblBlinkCondition.SubFontColor = System.Drawing.Color.Blue;
            this.m_lblBlinkCondition.SubText = "EQUIPMENT STATE";
            this.m_lblBlinkCondition.TabIndex = 1379;
            this.m_lblBlinkCondition.Text = "BLINK CONDITION";
            this.m_lblBlinkCondition.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblBlinkCondition.TextAlignSub = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
            this.m_lblBlinkCondition.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblBlinkCondition.UnitAreaRate = 40;
            this.m_lblBlinkCondition.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblBlinkCondition.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblBlinkCondition.UnitPositionVertical = false;
            this.m_lblBlinkCondition.UnitText = "";
            this.m_lblBlinkCondition.UseBorder = true;
            this.m_lblBlinkCondition.UseEdgeRadius = false;
            this.m_lblBlinkCondition.UseSubFont = true;
            this.m_lblBlinkCondition.UseUnitFont = false;
            // 
            // m_lblKey
            // 
            this.m_lblKey.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
            this.m_lblKey.BorderStroke = 2;
            this.m_lblKey.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblKey.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblKey.EdgeRadius = 1;
            this.m_lblKey.Location = new System.Drawing.Point(7, 592);
            this.m_lblKey.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.m_lblKey.MainFontColor = System.Drawing.Color.Black;
            this.m_lblKey.Name = "m_lblKey";
            this.m_lblKey.Size = new System.Drawing.Size(155, 45);
            this.m_lblKey.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.m_lblKey.SubFontColor = System.Drawing.Color.Black;
            this.m_lblKey.SubText = "";
            this.m_lblKey.TabIndex = 1380;
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
            // m_lblConditionAlarm
            // 
            this.m_lblConditionAlarm.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
            this.m_lblConditionAlarm.BorderStroke = 2;
            this.m_lblConditionAlarm.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblConditionAlarm.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblConditionAlarm.EdgeRadius = 1;
            this.m_lblConditionAlarm.Location = new System.Drawing.Point(7, 838);
            this.m_lblConditionAlarm.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.m_lblConditionAlarm.MainFontColor = System.Drawing.Color.Black;
            this.m_lblConditionAlarm.Name = "m_lblConditionAlarm";
            this.m_lblConditionAlarm.Size = new System.Drawing.Size(155, 53);
            this.m_lblConditionAlarm.SubFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.m_lblConditionAlarm.SubFontColor = System.Drawing.Color.Red;
            this.m_lblConditionAlarm.SubText = "ALARM STATE";
            this.m_lblConditionAlarm.TabIndex = 1381;
            this.m_lblConditionAlarm.Text = "CONDITION";
            this.m_lblConditionAlarm.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblConditionAlarm.TextAlignSub = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
            this.m_lblConditionAlarm.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblConditionAlarm.UnitAreaRate = 40;
            this.m_lblConditionAlarm.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblConditionAlarm.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblConditionAlarm.UnitPositionVertical = false;
            this.m_lblConditionAlarm.UnitText = "";
            this.m_lblConditionAlarm.UseBorder = true;
            this.m_lblConditionAlarm.UseEdgeRadius = false;
            this.m_lblConditionAlarm.UseSubFont = true;
            this.m_lblConditionAlarm.UseUnitFont = false;
            // 
            // m_lblCondition
            // 
            this.m_lblCondition.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
            this.m_lblCondition.BorderStroke = 2;
            this.m_lblCondition.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblCondition.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblCondition.EdgeRadius = 1;
            this.m_lblCondition.Location = new System.Drawing.Point(7, 781);
            this.m_lblCondition.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.m_lblCondition.MainFontColor = System.Drawing.Color.Black;
            this.m_lblCondition.Name = "m_lblCondition";
            this.m_lblCondition.Size = new System.Drawing.Size(155, 51);
            this.m_lblCondition.SubFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.m_lblCondition.SubFontColor = System.Drawing.Color.Blue;
            this.m_lblCondition.SubText = "EQUIPMENT STATE";
            this.m_lblCondition.TabIndex = 1382;
            this.m_lblCondition.Text = "CONDITION";
            this.m_lblCondition.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblCondition.TextAlignSub = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
            this.m_lblCondition.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblCondition.UnitAreaRate = 40;
            this.m_lblCondition.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblCondition.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblCondition.UnitPositionVertical = false;
            this.m_lblCondition.UnitText = "";
            this.m_lblCondition.UseBorder = true;
            this.m_lblCondition.UseEdgeRadius = false;
            this.m_lblCondition.UseSubFont = true;
            this.m_lblCondition.UseUnitFont = false;
            // 
            // m_lblTarget
            // 
            this.m_lblTarget.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
            this.m_lblTarget.BorderStroke = 2;
            this.m_lblTarget.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblTarget.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblTarget.EdgeRadius = 1;
            this.m_lblTarget.Location = new System.Drawing.Point(7, 729);
            this.m_lblTarget.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.m_lblTarget.MainFontColor = System.Drawing.Color.Black;
            this.m_lblTarget.Name = "m_lblTarget";
            this.m_lblTarget.Size = new System.Drawing.Size(155, 46);
            this.m_lblTarget.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.m_lblTarget.SubFontColor = System.Drawing.Color.Black;
            this.m_lblTarget.SubText = "";
            this.m_lblTarget.TabIndex = 1383;
            this.m_lblTarget.Text = "OUTPUT TARGET";
            this.m_lblTarget.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblTarget.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblTarget.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblTarget.UnitAreaRate = 40;
            this.m_lblTarget.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblTarget.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblTarget.UnitPositionVertical = false;
            this.m_lblTarget.UnitText = "";
            this.m_lblTarget.UseBorder = true;
            this.m_lblTarget.UseEdgeRadius = false;
            this.m_lblTarget.UseSubFont = false;
            this.m_lblTarget.UseUnitFont = false;
            // 
            // m_lblName
            // 
            this.m_lblName.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
            this.m_lblName.BorderStroke = 2;
            this.m_lblName.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblName.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblName.EdgeRadius = 1;
            this.m_lblName.Location = new System.Drawing.Point(7, 687);
            this.m_lblName.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.m_lblName.MainFontColor = System.Drawing.Color.Black;
            this.m_lblName.Name = "m_lblName";
            this.m_lblName.Size = new System.Drawing.Size(155, 36);
            this.m_lblName.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.m_lblName.SubFontColor = System.Drawing.Color.Black;
            this.m_lblName.SubText = "";
            this.m_lblName.TabIndex = 1384;
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
            this.m_labelName.Location = new System.Drawing.Point(163, 687);
            this.m_labelName.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_labelName.MainFontColor = System.Drawing.Color.Black;
            this.m_labelName.Name = "m_labelName";
            this.m_labelName.Size = new System.Drawing.Size(399, 36);
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
            this.m_labelName.Click += new System.EventHandler(this.Click_Configuration);
            // 
            // m_labelBlinkInterval
            // 
            this.m_labelBlinkInterval.BackGroundColor = System.Drawing.Color.White;
            this.m_labelBlinkInterval.BorderStroke = 2;
            this.m_labelBlinkInterval.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_labelBlinkInterval.DisabledColor = System.Drawing.Color.LightGray;
            this.m_labelBlinkInterval.EdgeRadius = 1;
            this.m_labelBlinkInterval.Enabled = false;
            this.m_labelBlinkInterval.Location = new System.Drawing.Point(1015, 592);
            this.m_labelBlinkInterval.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_labelBlinkInterval.MainFontColor = System.Drawing.Color.Black;
            this.m_labelBlinkInterval.Name = "m_labelBlinkInterval";
            this.m_labelBlinkInterval.Size = new System.Drawing.Size(116, 45);
            this.m_labelBlinkInterval.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.m_labelBlinkInterval.SubFontColor = System.Drawing.Color.Black;
            this.m_labelBlinkInterval.SubText = "";
            this.m_labelBlinkInterval.TabIndex = 1;
            this.m_labelBlinkInterval.Text = "--";
            this.m_labelBlinkInterval.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
            this.m_labelBlinkInterval.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_labelBlinkInterval.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
            this.m_labelBlinkInterval.UnitAreaRate = 40;
            this.m_labelBlinkInterval.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_labelBlinkInterval.UnitFontColor = System.Drawing.Color.Black;
            this.m_labelBlinkInterval.UnitPositionVertical = false;
            this.m_labelBlinkInterval.UnitText = "ms";
            this.m_labelBlinkInterval.UseBorder = true;
            this.m_labelBlinkInterval.UseEdgeRadius = false;
            this.m_labelBlinkInterval.UseSubFont = false;
            this.m_labelBlinkInterval.UseUnitFont = true;
            this.m_labelBlinkInterval.Click += new System.EventHandler(this.Click_BlinkInterval);
            // 
            // m_labelTarget
            // 
            this.m_labelTarget.BackGroundColor = System.Drawing.Color.White;
            this.m_labelTarget.BorderStroke = 2;
            this.m_labelTarget.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_labelTarget.DisabledColor = System.Drawing.Color.LightGray;
            this.m_labelTarget.EdgeRadius = 1;
            this.m_labelTarget.Enabled = false;
            this.m_labelTarget.Location = new System.Drawing.Point(181, 729);
            this.m_labelTarget.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_labelTarget.MainFontColor = System.Drawing.Color.Black;
            this.m_labelTarget.Name = "m_labelTarget";
            this.m_labelTarget.Size = new System.Drawing.Size(381, 46);
            this.m_labelTarget.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_labelTarget.SubFontColor = System.Drawing.Color.Black;
            this.m_labelTarget.SubText = "[ -1 ]";
            this.m_labelTarget.TabIndex = 1;
            this.m_labelTarget.Text = "--";
            this.m_labelTarget.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
            this.m_labelTarget.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_labelTarget.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_labelTarget.UnitAreaRate = 40;
            this.m_labelTarget.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_labelTarget.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_labelTarget.UnitPositionVertical = false;
            this.m_labelTarget.UnitText = "";
            this.m_labelTarget.UseBorder = true;
            this.m_labelTarget.UseEdgeRadius = false;
            this.m_labelTarget.UseSubFont = true;
            this.m_labelTarget.UseUnitFont = false;
            this.m_labelTarget.Click += new System.EventHandler(this.Click_Configuration);
            // 
            // m_labelCondition
            // 
            this.m_labelCondition.BackGroundColor = System.Drawing.Color.White;
            this.m_labelCondition.BorderStroke = 2;
            this.m_labelCondition.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_labelCondition.DisabledColor = System.Drawing.Color.LightGray;
            this.m_labelCondition.EdgeRadius = 1;
            this.m_labelCondition.Enabled = false;
            this.m_labelCondition.Location = new System.Drawing.Point(163, 781);
            this.m_labelCondition.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_labelCondition.MainFontColor = System.Drawing.Color.Black;
            this.m_labelCondition.Name = "m_labelCondition";
            this.m_labelCondition.Size = new System.Drawing.Size(399, 51);
            this.m_labelCondition.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.m_labelCondition.SubFontColor = System.Drawing.Color.Black;
            this.m_labelCondition.SubText = "";
            this.m_labelCondition.TabIndex = 2;
            this.m_labelCondition.Text = "--";
            this.m_labelCondition.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
            this.m_labelCondition.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_labelCondition.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_labelCondition.UnitAreaRate = 40;
            this.m_labelCondition.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_labelCondition.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_labelCondition.UnitPositionVertical = false;
            this.m_labelCondition.UnitText = "";
            this.m_labelCondition.UseBorder = true;
            this.m_labelCondition.UseEdgeRadius = false;
            this.m_labelCondition.UseSubFont = false;
            this.m_labelCondition.UseUnitFont = false;
            this.m_labelCondition.Click += new System.EventHandler(this.Click_Configuration);
            // 
            // m_labelConditionAlarm
            // 
            this.m_labelConditionAlarm.BackGroundColor = System.Drawing.Color.White;
            this.m_labelConditionAlarm.BorderStroke = 2;
            this.m_labelConditionAlarm.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_labelConditionAlarm.DisabledColor = System.Drawing.Color.LightGray;
            this.m_labelConditionAlarm.EdgeRadius = 1;
            this.m_labelConditionAlarm.Enabled = false;
            this.m_labelConditionAlarm.Location = new System.Drawing.Point(163, 838);
            this.m_labelConditionAlarm.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_labelConditionAlarm.MainFontColor = System.Drawing.Color.Black;
            this.m_labelConditionAlarm.Name = "m_labelConditionAlarm";
            this.m_labelConditionAlarm.Size = new System.Drawing.Size(399, 53);
            this.m_labelConditionAlarm.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.m_labelConditionAlarm.SubFontColor = System.Drawing.Color.Black;
            this.m_labelConditionAlarm.SubText = "";
            this.m_labelConditionAlarm.TabIndex = 3;
            this.m_labelConditionAlarm.Text = "--";
            this.m_labelConditionAlarm.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
            this.m_labelConditionAlarm.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_labelConditionAlarm.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_labelConditionAlarm.UnitAreaRate = 40;
            this.m_labelConditionAlarm.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_labelConditionAlarm.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_labelConditionAlarm.UnitPositionVertical = false;
            this.m_labelConditionAlarm.UnitText = "";
            this.m_labelConditionAlarm.UseBorder = true;
            this.m_labelConditionAlarm.UseEdgeRadius = false;
            this.m_labelConditionAlarm.UseSubFont = false;
            this.m_labelConditionAlarm.UseUnitFont = false;
            this.m_labelConditionAlarm.Click += new System.EventHandler(this.Click_Configuration);
            // 
            // m_labelBlinkCondition
            // 
            this.m_labelBlinkCondition.BackGroundColor = System.Drawing.Color.White;
            this.m_labelBlinkCondition.BorderStroke = 2;
            this.m_labelBlinkCondition.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_labelBlinkCondition.DisabledColor = System.Drawing.Color.LightGray;
            this.m_labelBlinkCondition.EdgeRadius = 1;
            this.m_labelBlinkCondition.Enabled = false;
            this.m_labelBlinkCondition.Location = new System.Drawing.Point(725, 687);
            this.m_labelBlinkCondition.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_labelBlinkCondition.MainFontColor = System.Drawing.Color.Black;
            this.m_labelBlinkCondition.Name = "m_labelBlinkCondition";
            this.m_labelBlinkCondition.Size = new System.Drawing.Size(406, 57);
            this.m_labelBlinkCondition.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.m_labelBlinkCondition.SubFontColor = System.Drawing.Color.Black;
            this.m_labelBlinkCondition.SubText = "";
            this.m_labelBlinkCondition.TabIndex = 4;
            this.m_labelBlinkCondition.Text = "--";
            this.m_labelBlinkCondition.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
            this.m_labelBlinkCondition.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_labelBlinkCondition.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_labelBlinkCondition.UnitAreaRate = 40;
            this.m_labelBlinkCondition.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_labelBlinkCondition.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_labelBlinkCondition.UnitPositionVertical = false;
            this.m_labelBlinkCondition.UnitText = "";
            this.m_labelBlinkCondition.UseBorder = true;
            this.m_labelBlinkCondition.UseEdgeRadius = false;
            this.m_labelBlinkCondition.UseSubFont = false;
            this.m_labelBlinkCondition.UseUnitFont = false;
            this.m_labelBlinkCondition.Click += new System.EventHandler(this.Click_Configuration);
            // 
            // m_labelBlinkConditionAlarm
            // 
            this.m_labelBlinkConditionAlarm.BackGroundColor = System.Drawing.Color.White;
            this.m_labelBlinkConditionAlarm.BorderStroke = 2;
            this.m_labelBlinkConditionAlarm.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_labelBlinkConditionAlarm.DisabledColor = System.Drawing.Color.LightGray;
            this.m_labelBlinkConditionAlarm.EdgeRadius = 1;
            this.m_labelBlinkConditionAlarm.Enabled = false;
            this.m_labelBlinkConditionAlarm.Location = new System.Drawing.Point(725, 750);
            this.m_labelBlinkConditionAlarm.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_labelBlinkConditionAlarm.MainFontColor = System.Drawing.Color.Black;
            this.m_labelBlinkConditionAlarm.Name = "m_labelBlinkConditionAlarm";
            this.m_labelBlinkConditionAlarm.Size = new System.Drawing.Size(406, 57);
            this.m_labelBlinkConditionAlarm.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.m_labelBlinkConditionAlarm.SubFontColor = System.Drawing.Color.Black;
            this.m_labelBlinkConditionAlarm.SubText = "";
            this.m_labelBlinkConditionAlarm.TabIndex = 5;
            this.m_labelBlinkConditionAlarm.Text = "--";
            this.m_labelBlinkConditionAlarm.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
            this.m_labelBlinkConditionAlarm.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_labelBlinkConditionAlarm.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_labelBlinkConditionAlarm.UnitAreaRate = 40;
            this.m_labelBlinkConditionAlarm.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_labelBlinkConditionAlarm.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_labelBlinkConditionAlarm.UnitPositionVertical = false;
            this.m_labelBlinkConditionAlarm.UnitText = "";
            this.m_labelBlinkConditionAlarm.UseBorder = true;
            this.m_labelBlinkConditionAlarm.UseEdgeRadius = false;
            this.m_labelBlinkConditionAlarm.UseSubFont = false;
            this.m_labelBlinkConditionAlarm.UseUnitFont = false;
            this.m_labelBlinkConditionAlarm.Click += new System.EventHandler(this.Click_Configuration);
            // 
            // m_labelKey
            // 
            this.m_labelKey.BackGroundColor = System.Drawing.Color.White;
            this.m_labelKey.BorderStroke = 2;
            this.m_labelKey.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_labelKey.DisabledColor = System.Drawing.Color.LightGray;
            this.m_labelKey.EdgeRadius = 1;
            this.m_labelKey.Enabled = false;
            this.m_labelKey.Location = new System.Drawing.Point(163, 592);
            this.m_labelKey.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_labelKey.MainFontColor = System.Drawing.Color.Black;
            this.m_labelKey.Name = "m_labelKey";
            this.m_labelKey.Size = new System.Drawing.Size(399, 45);
            this.m_labelKey.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.m_labelKey.SubFontColor = System.Drawing.Color.Black;
            this.m_labelKey.SubText = "";
            this.m_labelKey.TabIndex = 1392;
            this.m_labelKey.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
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
            this.m_btnDisable.Location = new System.Drawing.Point(705, 814);
            this.m_btnDisable.MainFont = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.m_btnDisable.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
            this.m_btnDisable.Name = "m_btnDisable";
            this.m_btnDisable.Size = new System.Drawing.Size(134, 77);
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
            this.m_btnEnable.Location = new System.Drawing.Point(568, 814);
            this.m_btnEnable.MainFont = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.m_btnEnable.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
            this.m_btnEnable.Name = "m_btnEnable";
            this.m_btnEnable.Size = new System.Drawing.Size(134, 77);
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
            this.m_btnRemove.Location = new System.Drawing.Point(995, 814);
            this.m_btnRemove.MainFont = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.m_btnRemove.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
            this.m_btnRemove.Name = "m_btnRemove";
            this.m_btnRemove.Size = new System.Drawing.Size(134, 77);
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
            this.m_btnAdd.Location = new System.Drawing.Point(858, 814);
            this.m_btnAdd.MainFont = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.m_btnAdd.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
            this.m_btnAdd.Name = "m_btnAdd";
            this.m_btnAdd.Size = new System.Drawing.Size(134, 77);
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
            // m_labelCheckInterval
            // 
            this.m_labelCheckInterval.BackGroundColor = System.Drawing.Color.White;
            this.m_labelCheckInterval.BorderStroke = 2;
            this.m_labelCheckInterval.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_labelCheckInterval.DisabledColor = System.Drawing.Color.LightGray;
            this.m_labelCheckInterval.EdgeRadius = 1;
            this.m_labelCheckInterval.Enabled = false;
            this.m_labelCheckInterval.Location = new System.Drawing.Point(725, 592);
            this.m_labelCheckInterval.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_labelCheckInterval.MainFontColor = System.Drawing.Color.Black;
            this.m_labelCheckInterval.Name = "m_labelCheckInterval";
            this.m_labelCheckInterval.Size = new System.Drawing.Size(116, 45);
            this.m_labelCheckInterval.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.m_labelCheckInterval.SubFontColor = System.Drawing.Color.Black;
            this.m_labelCheckInterval.SubText = "";
            this.m_labelCheckInterval.TabIndex = 0;
            this.m_labelCheckInterval.Text = "--";
            this.m_labelCheckInterval.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
            this.m_labelCheckInterval.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_labelCheckInterval.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
            this.m_labelCheckInterval.UnitAreaRate = 40;
            this.m_labelCheckInterval.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_labelCheckInterval.UnitFontColor = System.Drawing.Color.Black;
            this.m_labelCheckInterval.UnitPositionVertical = false;
            this.m_labelCheckInterval.UnitText = "ms";
            this.m_labelCheckInterval.UseBorder = true;
            this.m_labelCheckInterval.UseEdgeRadius = false;
            this.m_labelCheckInterval.UseSubFont = false;
            this.m_labelCheckInterval.UseUnitFont = true;
            this.m_labelCheckInterval.Click += new System.EventHandler(this.Click_BlinkInterval);
            // 
            // sys3Label2
            // 
            this.sys3Label2.BackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(220)))));
            this.sys3Label2.BorderStroke = 2;
            this.sys3Label2.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.sys3Label2.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3Label2.EdgeRadius = 1;
            this.sys3Label2.Location = new System.Drawing.Point(568, 592);
            this.sys3Label2.MainFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.sys3Label2.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label2.Name = "sys3Label2";
            this.sys3Label2.Size = new System.Drawing.Size(165, 45);
            this.sys3Label2.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.sys3Label2.SubFontColor = System.Drawing.Color.Black;
            this.sys3Label2.SubText = "";
            this.sys3Label2.TabIndex = 1394;
            this.sys3Label2.Text = "CHECK INTERVAL";
            this.sys3Label2.TextAlignMain = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.sys3Label2.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label2.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label2.UnitAreaRate = 40;
            this.sys3Label2.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label2.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sys3Label2.UnitPositionVertical = false;
            this.sys3Label2.UnitText = "";
            this.sys3Label2.UseBorder = true;
            this.sys3Label2.UseEdgeRadius = false;
            this.sys3Label2.UseSubFont = false;
            this.sys3Label2.UseUnitFont = false;
            // 
            // Config_Trigger
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_labelCheckInterval);
            this.Controls.Add(this.sys3Label2);
            this.Controls.Add(this.m_btnRemove);
            this.Controls.Add(this.m_btnAdd);
            this.Controls.Add(this.m_btnDisable);
            this.Controls.Add(this.m_btnEnable);
            this.Controls.Add(this.m_labelKey);
            this.Controls.Add(this.m_labelBlinkConditionAlarm);
            this.Controls.Add(this.m_labelBlinkCondition);
            this.Controls.Add(this.m_labelConditionAlarm);
            this.Controls.Add(this.m_labelCondition);
            this.Controls.Add(this.m_labelTarget);
            this.Controls.Add(this.m_labelBlinkInterval);
            this.Controls.Add(this.m_labelName);
            this.Controls.Add(this.m_lblName);
            this.Controls.Add(this.m_lblTarget);
            this.Controls.Add(this.m_lblCondition);
            this.Controls.Add(this.m_lblConditionAlarm);
            this.Controls.Add(this.m_lblKey);
            this.Controls.Add(this.m_lblBlinkCondition);
            this.Controls.Add(this.m_lblBlinkConditionAlarm);
            this.Controls.Add(this.m_lblBlinkInterval);
            this.Controls.Add(this.m_ledIO);
            this.Controls.Add(this.m_dgViewInterLock);
            this.Controls.Add(this.m_groupList);
            this.Controls.Add(this.m_groupSelectedItem);
            this.Controls.Add(this.m_groupConfiguration);
            this.Name = "Config_Trigger";
            this.Size = new System.Drawing.Size(1136, 900);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgViewInterLock)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

		private Sys3Controls.Sys3LedLabel m_ledIO;
		private Sys3Controls.Sys3DoubleBufferedDataGridView m_dgViewInterLock;
		private System.Windows.Forms.DataGridViewTextBoxColumn ID;
		private System.Windows.Forms.DataGridViewTextBoxColumn ENABLE;
		private System.Windows.Forms.DataGridViewTextBoxColumn PASSWORD;
		private System.Windows.Forms.DataGridViewTextBoxColumn AUTHORITY;
		private System.Windows.Forms.DataGridViewTextBoxColumn STATE;
		private System.Windows.Forms.DataGridViewTextBoxColumn CONDITION;
		private System.Windows.Forms.DataGridViewTextBoxColumn active;
		private System.Windows.Forms.DataGridViewTextBoxColumn BLINK;
		private System.Windows.Forms.DataGridViewTextBoxColumn Active2;
		private Sys3Controls.Sys3GroupBox m_groupList;
		private Sys3Controls.Sys3GroupBox m_groupSelectedItem;
		private Sys3Controls.Sys3GroupBox m_groupConfiguration;
		private Sys3Controls.Sys3Label m_lblBlinkInterval;
		private Sys3Controls.Sys3Label m_lblBlinkConditionAlarm;
		private Sys3Controls.Sys3Label m_lblBlinkCondition;
		private Sys3Controls.Sys3Label m_lblKey;
		private Sys3Controls.Sys3Label m_lblConditionAlarm;
		private Sys3Controls.Sys3Label m_lblCondition;
		private Sys3Controls.Sys3Label m_lblTarget;
		private Sys3Controls.Sys3Label m_lblName;
		private Sys3Controls.Sys3Label m_labelName;
		private Sys3Controls.Sys3Label m_labelBlinkInterval;
		private Sys3Controls.Sys3Label m_labelTarget;
		private Sys3Controls.Sys3Label m_labelCondition;
		private Sys3Controls.Sys3Label m_labelConditionAlarm;
		private Sys3Controls.Sys3Label m_labelBlinkCondition;
		private Sys3Controls.Sys3Label m_labelBlinkConditionAlarm;
		private Sys3Controls.Sys3Label m_labelKey;
		private Sys3Controls.Sys3button m_btnDisable;
		private Sys3Controls.Sys3button m_btnEnable;
		private Sys3Controls.Sys3button m_btnRemove;
		private Sys3Controls.Sys3button m_btnAdd;
        private Sys3Controls.Sys3Label m_labelCheckInterval;
        private Sys3Controls.Sys3Label sys3Label2;
    }
}
