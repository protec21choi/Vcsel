namespace FrameOfSystem3.Views.Setup.Equipment
{
    partial class Equipment_Device
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
            this.dataGridView_Heater = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sys3GroupBox1 = new Sys3Controls.Sys3GroupBox();
            this.sys3GroupBox2 = new Sys3Controls.Sys3GroupBox();
            this.dataGridView_Chiller = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sys3GroupBox3 = new Sys3Controls.Sys3GroupBox();
            this.dataGridView_FFU = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridViewControl_FFU_Parameter = new FrameOfSystem3.Component.GridViewControl_Parameter();
            this.gridViewControl_Heater_Parameter = new FrameOfSystem3.Component.GridViewControl_Parameter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Heater)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Chiller)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_FFU)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Heater
            // 
            this.dataGridView_Heater.AllowUserToAddRows = false;
            this.dataGridView_Heater.AllowUserToDeleteRows = false;
            this.dataGridView_Heater.AllowUserToResizeColumns = false;
            this.dataGridView_Heater.AllowUserToResizeRows = false;
            this.dataGridView_Heater.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Heater.ColumnHeadersVisible = false;
            this.dataGridView_Heater.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn9});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_Heater.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_Heater.Location = new System.Drawing.Point(372, 34);
            this.dataGridView_Heater.MultiSelect = false;
            this.dataGridView_Heater.Name = "dataGridView_Heater";
            this.dataGridView_Heater.ReadOnly = true;
            this.dataGridView_Heater.RowHeadersVisible = false;
            this.dataGridView_Heater.RowTemplate.Height = 25;
            this.dataGridView_Heater.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView_Heater.Size = new System.Drawing.Size(396, 103);
            this.dataGridView_Heater.TabIndex = 20685;
            this.dataGridView_Heater.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Heater_CellClick);
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.HeaderText = "NAME";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "SET";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 70;
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
            this.sys3GroupBox1.Location = new System.Drawing.Point(1, 1);
            this.sys3GroupBox1.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3GroupBox1.Name = "sys3GroupBox1";
            this.sys3GroupBox1.Size = new System.Drawing.Size(771, 146);
            this.sys3GroupBox1.TabIndex = 20683;
            this.sys3GroupBox1.Tag = "";
            this.sys3GroupBox1.Text = "HEATER";
            this.sys3GroupBox1.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3GroupBox1.ThemeIndex = 0;
            this.sys3GroupBox1.UseLabelBorder = true;
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
            this.sys3GroupBox2.Location = new System.Drawing.Point(773, 1);
            this.sys3GroupBox2.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3GroupBox2.Name = "sys3GroupBox2";
            this.sys3GroupBox2.Size = new System.Drawing.Size(363, 146);
            this.sys3GroupBox2.TabIndex = 20683;
            this.sys3GroupBox2.Tag = "";
            this.sys3GroupBox2.Text = "CHILLER";
            this.sys3GroupBox2.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3GroupBox2.ThemeIndex = 0;
            this.sys3GroupBox2.UseLabelBorder = true;
            // 
            // dataGridView_Chiller
            // 
            this.dataGridView_Chiller.AllowUserToAddRows = false;
            this.dataGridView_Chiller.AllowUserToDeleteRows = false;
            this.dataGridView_Chiller.AllowUserToResizeColumns = false;
            this.dataGridView_Chiller.AllowUserToResizeRows = false;
            this.dataGridView_Chiller.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Chiller.ColumnHeadersVisible = false;
            this.dataGridView_Chiller.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_Chiller.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_Chiller.Location = new System.Drawing.Point(777, 34);
            this.dataGridView_Chiller.MultiSelect = false;
            this.dataGridView_Chiller.Name = "dataGridView_Chiller";
            this.dataGridView_Chiller.ReadOnly = true;
            this.dataGridView_Chiller.RowHeadersVisible = false;
            this.dataGridView_Chiller.RowTemplate.Height = 25;
            this.dataGridView_Chiller.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView_Chiller.Size = new System.Drawing.Size(355, 78);
            this.dataGridView_Chiller.TabIndex = 20685;
            this.dataGridView_Chiller.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Chiller_CellClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "NAME";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "SET";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 70;
            // 
            // sys3GroupBox3
            // 
            this.sys3GroupBox3.BackGroundColor = System.Drawing.Color.WhiteSmoke;
            this.sys3GroupBox3.EdgeBorderStroke = 2;
            this.sys3GroupBox3.EdgeRadius = 2;
            this.sys3GroupBox3.LabelFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3GroupBox3.LabelGradientColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.sys3GroupBox3.LabelGradientColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.sys3GroupBox3.LabelHeight = 30;
            this.sys3GroupBox3.LabelTextColor = System.Drawing.Color.Black;
            this.sys3GroupBox3.Location = new System.Drawing.Point(1, 148);
            this.sys3GroupBox3.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3GroupBox3.Name = "sys3GroupBox3";
            this.sys3GroupBox3.Size = new System.Drawing.Size(771, 149);
            this.sys3GroupBox3.TabIndex = 20683;
            this.sys3GroupBox3.Tag = "";
            this.sys3GroupBox3.Text = "FFU";
            this.sys3GroupBox3.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3GroupBox3.ThemeIndex = 0;
            this.sys3GroupBox3.UseLabelBorder = true;
            // 
            // dataGridView_FFU
            // 
            this.dataGridView_FFU.AllowUserToAddRows = false;
            this.dataGridView_FFU.AllowUserToDeleteRows = false;
            this.dataGridView_FFU.AllowUserToResizeColumns = false;
            this.dataGridView_FFU.AllowUserToResizeRows = false;
            this.dataGridView_FFU.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_FFU.ColumnHeadersVisible = false;
            this.dataGridView_FFU.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_FFU.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_FFU.Location = new System.Drawing.Point(372, 182);
            this.dataGridView_FFU.MultiSelect = false;
            this.dataGridView_FFU.Name = "dataGridView_FFU";
            this.dataGridView_FFU.ReadOnly = true;
            this.dataGridView_FFU.RowHeadersVisible = false;
            this.dataGridView_FFU.RowTemplate.Height = 25;
            this.dataGridView_FFU.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView_FFU.Size = new System.Drawing.Size(396, 103);
            this.dataGridView_FFU.TabIndex = 20685;
            this.dataGridView_FFU.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Heater_CellClick);
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.HeaderText = "NAME";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "SET";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 200;
            // 
            // gridViewControl_FFU_Parameter
            // 
            this.gridViewControl_FFU_Parameter.Control_Enable = true;
            this.gridViewControl_FFU_Parameter.controlCollection = null;
            this.gridViewControl_FFU_Parameter.Location = new System.Drawing.Point(6, 182);
            this.gridViewControl_FFU_Parameter.Name = "gridViewControl_FFU_Parameter";
            this.gridViewControl_FFU_Parameter.Size = new System.Drawing.Size(365, 103);
            this.gridViewControl_FFU_Parameter.TabIndex = 20684;
            // 
            // gridViewControl_Heater_Parameter
            // 
            this.gridViewControl_Heater_Parameter.Control_Enable = true;
            this.gridViewControl_Heater_Parameter.controlCollection = null;
            this.gridViewControl_Heater_Parameter.Location = new System.Drawing.Point(6, 34);
            this.gridViewControl_Heater_Parameter.Name = "gridViewControl_Heater_Parameter";
            this.gridViewControl_Heater_Parameter.Size = new System.Drawing.Size(365, 103);
            this.gridViewControl_Heater_Parameter.TabIndex = 20684;
            // 
            // Equipment_Device
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.dataGridView_Chiller);
            this.Controls.Add(this.dataGridView_FFU);
            this.Controls.Add(this.dataGridView_Heater);
            this.Controls.Add(this.gridViewControl_FFU_Parameter);
            this.Controls.Add(this.gridViewControl_Heater_Parameter);
            this.Controls.Add(this.sys3GroupBox2);
            this.Controls.Add(this.sys3GroupBox3);
            this.Controls.Add(this.sys3GroupBox1);
            this.Name = "Equipment_Device";
            this.Size = new System.Drawing.Size(1136, 791);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Heater)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Chiller)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_FFU)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Heater;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private Component.GridViewControl_Parameter gridViewControl_Heater_Parameter;
        private Sys3Controls.Sys3GroupBox sys3GroupBox1;
        private Sys3Controls.Sys3GroupBox sys3GroupBox2;
        private System.Windows.Forms.DataGridView dataGridView_Chiller;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private Sys3Controls.Sys3GroupBox sys3GroupBox3;
        private Component.GridViewControl_Parameter gridViewControl_FFU_Parameter;
        private System.Windows.Forms.DataGridView dataGridView_FFU;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;


    }
}
