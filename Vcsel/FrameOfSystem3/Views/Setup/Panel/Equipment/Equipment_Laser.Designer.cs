namespace FrameOfSystem3.Views.Setup.Equipment
{
    partial class Equipment_Laser
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
            this.sys3GroupBox1 = new Sys3Controls.Sys3GroupBox();
            this.ComboBox_Channel = new System.Windows.Forms.ComboBox();
            this.m_dgViewCalibration = new Sys3Controls.Sys3DoubleBufferedDataGridView();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OutputVolt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InputVolt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Watt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sys3Label1 = new Sys3Controls.Sys3Label();
            this.m_lblCalFileName = new Sys3Controls.Sys3Label();
            this.sys3Label3 = new Sys3Controls.Sys3Label();
            this.m_lblAvgValue = new Sys3Controls.Sys3Label();
            this.m_lblMaxValue = new Sys3Controls.Sys3Label();
            this.m_lblLastValue = new Sys3Controls.Sys3Label();
            this.m_lblMinValue = new Sys3Controls.Sys3Label();
            this.sys3Label25 = new Sys3Controls.Sys3Label();
            this.sys3Label16 = new Sys3Controls.Sys3Label();
            this.sys3Label50 = new Sys3Controls.Sys3Label();
            this.m_ZedGraph = new ZedGraph.ZedGraphControl();
            this.sys3GroupBox2 = new Sys3Controls.Sys3GroupBox();
            this.sys3Label48 = new Sys3Controls.Sys3Label();
            this.sys3Label4 = new Sys3Controls.Sys3Label();
            this.m_lblRepeatCount = new Sys3Controls.Sys3Label();
            this.sys3button2 = new Sys3Controls.Sys3button();
            this.sys3button7 = new Sys3Controls.Sys3button();
            this.m_btnRun = new Sys3Controls.Sys3button();
            this.sys3Label6 = new Sys3Controls.Sys3Label();
            this.m_lblRestTime = new Sys3Controls.Sys3Label();
            this.sys3Label8 = new Sys3Controls.Sys3Label();
            this.sys3Label9 = new Sys3Controls.Sys3Label();
            this.m_lblRepeatAvg = new Sys3Controls.Sys3Label();
            this.sys3Label11 = new Sys3Controls.Sys3Label();
            this.m_lblCalChannel = new Sys3Controls.Sys3Label();
            this.sys3Label13 = new Sys3Controls.Sys3Label();
            this.m_lblAlarmCodePort1 = new Sys3Controls.Sys3Label();
            this.sys3Label5 = new Sys3Controls.Sys3Label();
            this.sys3Label7 = new Sys3Controls.Sys3Label();
            this.m_lblCalStep = new Sys3Controls.Sys3Label();
            this.sys3Label12 = new Sys3Controls.Sys3Label();
            this.m_lblCalVolt = new Sys3Controls.Sys3Label();
            this.sys3GroupBox3 = new Sys3Controls.Sys3GroupBox();
            this.sys3Label2 = new Sys3Controls.Sys3Label();
            this.m_lblAlarmCodeMonitor = new Sys3Controls.Sys3Label();
            this.sys3Label14 = new Sys3Controls.Sys3Label();
            this.m_lblAlarmCodePort2 = new Sys3Controls.Sys3Label();
            this.sys3Label17 = new Sys3Controls.Sys3Label();
            this.m_lblAlarmCodePort3 = new Sys3Controls.Sys3Label();
            this.gridVeiwControl_Device = new FrameOfSystem3.Component.GridVeiwControl_Device();
            this.gridViewControl_Power_Measure_Parameter = new FrameOfSystem3.Component.GridViewControl_Parameter();
            this.gridViewControl_Enable_Parameter = new FrameOfSystem3.Component.GridViewControl_Parameter();
            this.gridViewControl_Position_Parameter = new FrameOfSystem3.Component.GridViewControl_2Axis_Position_Parameter();
            this.m_btnStop = new Sys3Controls.Sys3button();
            this.btn_CalLoad = new Sys3Controls.Sys3button();
            this.btn_Reset = new Sys3Controls.Sys3button();
            this.sys3button1 = new Sys3Controls.Sys3button();
            this.sys3Label10 = new Sys3Controls.Sys3Label();
            this.m_lblinputVolt = new Sys3Controls.Sys3Label();
            this.sys3button3 = new Sys3Controls.Sys3button();
            this.gridVeiwControl_Cylinder_Device = new FrameOfSystem3.Component.GridVeiwControl_Device();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgViewCalibration)).BeginInit();
            this.SuspendLayout();
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
            this.sys3GroupBox1.Location = new System.Drawing.Point(0, 55);
            this.sys3GroupBox1.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3GroupBox1.Name = "sys3GroupBox1";
            this.sys3GroupBox1.Size = new System.Drawing.Size(421, 439);
            this.sys3GroupBox1.TabIndex = 20683;
            this.sys3GroupBox1.Tag = "";
            this.sys3GroupBox1.Text = "POWER TABLE";
            this.sys3GroupBox1.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3GroupBox1.ThemeIndex = 0;
            this.sys3GroupBox1.UseLabelBorder = true;
            // 
            // ComboBox_Channel
            // 
            this.ComboBox_Channel.AutoCompleteCustomSource.AddRange(new string[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16"});
            this.ComboBox_Channel.Font = new System.Drawing.Font("굴림", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ComboBox_Channel.FormattingEnabled = true;
            this.ComboBox_Channel.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18"});
            this.ComboBox_Channel.Location = new System.Drawing.Point(53, 88);
            this.ComboBox_Channel.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.ComboBox_Channel.Name = "ComboBox_Channel";
            this.ComboBox_Channel.Size = new System.Drawing.Size(74, 37);
            this.ComboBox_Channel.TabIndex = 20686;
            this.ComboBox_Channel.SelectedIndexChanged += new System.EventHandler(this.ComboBox_Channel_SelectedIndexChanged);
            // 
            // m_dgViewCalibration
            // 
            this.m_dgViewCalibration.AllowUserToAddRows = false;
            this.m_dgViewCalibration.AllowUserToDeleteRows = false;
            this.m_dgViewCalibration.AllowUserToResizeColumns = false;
            this.m_dgViewCalibration.AllowUserToResizeRows = false;
            this.m_dgViewCalibration.BackgroundColor = System.Drawing.Color.White;
            this.m_dgViewCalibration.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.m_dgViewCalibration.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_dgViewCalibration.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.m_dgViewCalibration.ColumnHeadersHeight = 25;
            this.m_dgViewCalibration.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.m_dgViewCalibration.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn7,
            this.OutputVolt,
            this.InputVolt,
            this.Watt});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.m_dgViewCalibration.DefaultCellStyle = dataGridViewCellStyle2;
            this.m_dgViewCalibration.EnableHeadersVisualStyles = false;
            this.m_dgViewCalibration.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            this.m_dgViewCalibration.Location = new System.Drawing.Point(4, 126);
            this.m_dgViewCalibration.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_dgViewCalibration.MultiSelect = false;
            this.m_dgViewCalibration.Name = "m_dgViewCalibration";
            this.m_dgViewCalibration.ReadOnly = true;
            this.m_dgViewCalibration.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_dgViewCalibration.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.m_dgViewCalibration.RowHeadersVisible = false;
            this.m_dgViewCalibration.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.m_dgViewCalibration.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.m_dgViewCalibration.RowTemplate.Height = 23;
            this.m_dgViewCalibration.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgViewCalibration.Size = new System.Drawing.Size(415, 365);
            this.m_dgViewCalibration.TabIndex = 20684;
            this.m_dgViewCalibration.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dgViewCalibration_CellContentClick);
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn7.HeaderText = "INDEX";
            this.dataGridViewTextBoxColumn7.MaxInputLength = 20;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // OutputVolt
            // 
            this.OutputVolt.HeaderText = "OUTPUT VOLT";
            this.OutputVolt.Name = "OutputVolt";
            this.OutputVolt.ReadOnly = true;
            this.OutputVolt.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.OutputVolt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // InputVolt
            // 
            this.InputVolt.HeaderText = "INPUT VOLT";
            this.InputVolt.Name = "InputVolt";
            this.InputVolt.ReadOnly = true;
            this.InputVolt.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.InputVolt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Watt
            // 
            this.Watt.HeaderText = "WATT";
            this.Watt.Name = "Watt";
            this.Watt.ReadOnly = true;
            this.Watt.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Watt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // sys3Label1
            // 
            this.sys3Label1.BackGroundColor = System.Drawing.Color.DarkGray;
            this.sys3Label1.BorderStroke = 2;
            this.sys3Label1.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.sys3Label1.Description = "";
            this.sys3Label1.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3Label1.EdgeRadius = 1;
            this.sys3Label1.ImagePosition = new System.Drawing.Point(0, 0);
            this.sys3Label1.ImageSize = new System.Drawing.Point(0, 0);
            this.sys3Label1.LoadImage = null;
            this.sys3Label1.Location = new System.Drawing.Point(4, 88);
            this.sys3Label1.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label1.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label1.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label1.Name = "sys3Label1";
            this.sys3Label1.Size = new System.Drawing.Size(48, 37);
            this.sys3Label1.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label1.SubFontColor = System.Drawing.Color.DarkRed;
            this.sys3Label1.SubText = "";
            this.sys3Label1.TabIndex = 20687;
            this.sys3Label1.Tag = "";
            this.sys3Label1.Text = "CH";
            this.sys3Label1.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3Label1.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.sys3Label1.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label1.ThemeIndex = 0;
            this.sys3Label1.UnitAreaRate = 40;
            this.sys3Label1.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label1.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sys3Label1.UnitPositionVertical = false;
            this.sys3Label1.UnitText = "";
            this.sys3Label1.UseBorder = true;
            this.sys3Label1.UseEdgeRadius = false;
            this.sys3Label1.UseImage = false;
            this.sys3Label1.UseSubFont = true;
            this.sys3Label1.UseUnitFont = false;
            // 
            // m_lblCalFileName
            // 
            this.m_lblCalFileName.BackGroundColor = System.Drawing.Color.White;
            this.m_lblCalFileName.BorderStroke = 2;
            this.m_lblCalFileName.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblCalFileName.Description = "";
            this.m_lblCalFileName.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblCalFileName.EdgeRadius = 1;
            this.m_lblCalFileName.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_lblCalFileName.ImageSize = new System.Drawing.Point(0, 0);
            this.m_lblCalFileName.LoadImage = null;
            this.m_lblCalFileName.Location = new System.Drawing.Point(220, 88);
            this.m_lblCalFileName.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_lblCalFileName.MainFontColor = System.Drawing.Color.Black;
            this.m_lblCalFileName.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_lblCalFileName.Name = "m_lblCalFileName";
            this.m_lblCalFileName.Size = new System.Drawing.Size(161, 37);
            this.m_lblCalFileName.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblCalFileName.SubFontColor = System.Drawing.Color.DarkRed;
            this.m_lblCalFileName.SubText = "";
            this.m_lblCalFileName.TabIndex = 20825;
            this.m_lblCalFileName.Tag = "";
            this.m_lblCalFileName.Text = "--";
            this.m_lblCalFileName.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.m_lblCalFileName.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblCalFileName.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblCalFileName.ThemeIndex = 0;
            this.m_lblCalFileName.UnitAreaRate = 40;
            this.m_lblCalFileName.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblCalFileName.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblCalFileName.UnitPositionVertical = false;
            this.m_lblCalFileName.UnitText = "";
            this.m_lblCalFileName.UseBorder = true;
            this.m_lblCalFileName.UseEdgeRadius = false;
            this.m_lblCalFileName.UseImage = false;
            this.m_lblCalFileName.UseSubFont = true;
            this.m_lblCalFileName.UseUnitFont = false;
            // 
            // sys3Label3
            // 
            this.sys3Label3.BackGroundColor = System.Drawing.Color.DarkGray;
            this.sys3Label3.BorderStroke = 2;
            this.sys3Label3.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.sys3Label3.Description = "";
            this.sys3Label3.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3Label3.EdgeRadius = 1;
            this.sys3Label3.ImagePosition = new System.Drawing.Point(0, 0);
            this.sys3Label3.ImageSize = new System.Drawing.Point(0, 0);
            this.sys3Label3.LoadImage = null;
            this.sys3Label3.Location = new System.Drawing.Point(128, 88);
            this.sys3Label3.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label3.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label3.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label3.Name = "sys3Label3";
            this.sys3Label3.Size = new System.Drawing.Size(91, 37);
            this.sys3Label3.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label3.SubFontColor = System.Drawing.Color.DarkRed;
            this.sys3Label3.SubText = "";
            this.sys3Label3.TabIndex = 20687;
            this.sys3Label3.Tag = "";
            this.sys3Label3.Text = "FILE NAME";
            this.sys3Label3.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3Label3.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
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
            this.sys3Label3.UseSubFont = true;
            this.sys3Label3.UseUnitFont = false;
            // 
            // m_lblAvgValue
            // 
            this.m_lblAvgValue.BackGroundColor = System.Drawing.Color.DimGray;
            this.m_lblAvgValue.BorderStroke = 2;
            this.m_lblAvgValue.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblAvgValue.Description = "";
            this.m_lblAvgValue.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblAvgValue.EdgeRadius = 1;
            this.m_lblAvgValue.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_lblAvgValue.ImageSize = new System.Drawing.Point(0, 0);
            this.m_lblAvgValue.LoadImage = null;
            this.m_lblAvgValue.Location = new System.Drawing.Point(635, 627);
            this.m_lblAvgValue.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_lblAvgValue.MainFontColor = System.Drawing.Color.White;
            this.m_lblAvgValue.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_lblAvgValue.Name = "m_lblAvgValue";
            this.m_lblAvgValue.Size = new System.Drawing.Size(89, 30);
            this.m_lblAvgValue.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblAvgValue.SubFontColor = System.Drawing.Color.Gray;
            this.m_lblAvgValue.SubText = "";
            this.m_lblAvgValue.TabIndex = 20831;
            this.m_lblAvgValue.Tag = "";
            this.m_lblAvgValue.Text = "9999.9";
            this.m_lblAvgValue.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblAvgValue.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblAvgValue.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblAvgValue.ThemeIndex = 0;
            this.m_lblAvgValue.UnitAreaRate = 30;
            this.m_lblAvgValue.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblAvgValue.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblAvgValue.UnitPositionVertical = false;
            this.m_lblAvgValue.UnitText = "W";
            this.m_lblAvgValue.UseBorder = true;
            this.m_lblAvgValue.UseEdgeRadius = false;
            this.m_lblAvgValue.UseImage = false;
            this.m_lblAvgValue.UseSubFont = true;
            this.m_lblAvgValue.UseUnitFont = true;
            // 
            // m_lblMaxValue
            // 
            this.m_lblMaxValue.BackGroundColor = System.Drawing.Color.DimGray;
            this.m_lblMaxValue.BorderStroke = 2;
            this.m_lblMaxValue.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblMaxValue.Description = "";
            this.m_lblMaxValue.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblMaxValue.EdgeRadius = 1;
            this.m_lblMaxValue.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_lblMaxValue.ImageSize = new System.Drawing.Point(0, 0);
            this.m_lblMaxValue.LoadImage = null;
            this.m_lblMaxValue.Location = new System.Drawing.Point(635, 596);
            this.m_lblMaxValue.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_lblMaxValue.MainFontColor = System.Drawing.Color.White;
            this.m_lblMaxValue.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_lblMaxValue.Name = "m_lblMaxValue";
            this.m_lblMaxValue.Size = new System.Drawing.Size(89, 30);
            this.m_lblMaxValue.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblMaxValue.SubFontColor = System.Drawing.Color.Gray;
            this.m_lblMaxValue.SubText = "";
            this.m_lblMaxValue.TabIndex = 20832;
            this.m_lblMaxValue.Tag = "";
            this.m_lblMaxValue.Text = "9999.9";
            this.m_lblMaxValue.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblMaxValue.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblMaxValue.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblMaxValue.ThemeIndex = 0;
            this.m_lblMaxValue.UnitAreaRate = 30;
            this.m_lblMaxValue.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblMaxValue.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblMaxValue.UnitPositionVertical = false;
            this.m_lblMaxValue.UnitText = "W";
            this.m_lblMaxValue.UseBorder = true;
            this.m_lblMaxValue.UseEdgeRadius = false;
            this.m_lblMaxValue.UseImage = false;
            this.m_lblMaxValue.UseSubFont = true;
            this.m_lblMaxValue.UseUnitFont = true;
            // 
            // m_lblLastValue
            // 
            this.m_lblLastValue.BackGroundColor = System.Drawing.Color.DimGray;
            this.m_lblLastValue.BorderStroke = 2;
            this.m_lblLastValue.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblLastValue.Description = "";
            this.m_lblLastValue.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblLastValue.EdgeRadius = 1;
            this.m_lblLastValue.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_lblLastValue.ImageSize = new System.Drawing.Point(0, 0);
            this.m_lblLastValue.LoadImage = null;
            this.m_lblLastValue.Location = new System.Drawing.Point(635, 530);
            this.m_lblLastValue.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_lblLastValue.MainFontColor = System.Drawing.Color.White;
            this.m_lblLastValue.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_lblLastValue.Name = "m_lblLastValue";
            this.m_lblLastValue.Size = new System.Drawing.Size(89, 30);
            this.m_lblLastValue.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblLastValue.SubFontColor = System.Drawing.Color.Gray;
            this.m_lblLastValue.SubText = "";
            this.m_lblLastValue.TabIndex = 20833;
            this.m_lblLastValue.Tag = "";
            this.m_lblLastValue.Text = "9999.9";
            this.m_lblLastValue.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblLastValue.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblLastValue.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblLastValue.ThemeIndex = 0;
            this.m_lblLastValue.UnitAreaRate = 30;
            this.m_lblLastValue.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblLastValue.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblLastValue.UnitPositionVertical = false;
            this.m_lblLastValue.UnitText = "W";
            this.m_lblLastValue.UseBorder = true;
            this.m_lblLastValue.UseEdgeRadius = false;
            this.m_lblLastValue.UseImage = false;
            this.m_lblLastValue.UseSubFont = true;
            this.m_lblLastValue.UseUnitFont = true;
            // 
            // m_lblMinValue
            // 
            this.m_lblMinValue.BackGroundColor = System.Drawing.Color.DimGray;
            this.m_lblMinValue.BorderStroke = 2;
            this.m_lblMinValue.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblMinValue.Description = "";
            this.m_lblMinValue.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblMinValue.EdgeRadius = 1;
            this.m_lblMinValue.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_lblMinValue.ImageSize = new System.Drawing.Point(0, 0);
            this.m_lblMinValue.LoadImage = null;
            this.m_lblMinValue.Location = new System.Drawing.Point(635, 565);
            this.m_lblMinValue.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_lblMinValue.MainFontColor = System.Drawing.Color.White;
            this.m_lblMinValue.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_lblMinValue.Name = "m_lblMinValue";
            this.m_lblMinValue.Size = new System.Drawing.Size(89, 30);
            this.m_lblMinValue.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblMinValue.SubFontColor = System.Drawing.Color.Gray;
            this.m_lblMinValue.SubText = "";
            this.m_lblMinValue.TabIndex = 20834;
            this.m_lblMinValue.Tag = "";
            this.m_lblMinValue.Text = "9999.9";
            this.m_lblMinValue.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblMinValue.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblMinValue.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblMinValue.ThemeIndex = 0;
            this.m_lblMinValue.UnitAreaRate = 30;
            this.m_lblMinValue.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblMinValue.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblMinValue.UnitPositionVertical = false;
            this.m_lblMinValue.UnitText = "W";
            this.m_lblMinValue.UseBorder = true;
            this.m_lblMinValue.UseEdgeRadius = false;
            this.m_lblMinValue.UseImage = false;
            this.m_lblMinValue.UseSubFont = true;
            this.m_lblMinValue.UseUnitFont = true;
            // 
            // sys3Label25
            // 
            this.sys3Label25.BackGroundColor = System.Drawing.Color.DarkGray;
            this.sys3Label25.BorderStroke = 2;
            this.sys3Label25.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.sys3Label25.Description = "";
            this.sys3Label25.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3Label25.EdgeRadius = 1;
            this.sys3Label25.ImagePosition = new System.Drawing.Point(0, 0);
            this.sys3Label25.ImageSize = new System.Drawing.Point(0, 0);
            this.sys3Label25.LoadImage = null;
            this.sys3Label25.Location = new System.Drawing.Point(562, 627);
            this.sys3Label25.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label25.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label25.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label25.Name = "sys3Label25";
            this.sys3Label25.Size = new System.Drawing.Size(72, 30);
            this.sys3Label25.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label25.SubFontColor = System.Drawing.Color.Gray;
            this.sys3Label25.SubText = "";
            this.sys3Label25.TabIndex = 20827;
            this.sys3Label25.Tag = "";
            this.sys3Label25.Text = "AVG";
            this.sys3Label25.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3Label25.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.sys3Label25.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label25.ThemeIndex = 0;
            this.sys3Label25.UnitAreaRate = 30;
            this.sys3Label25.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label25.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sys3Label25.UnitPositionVertical = false;
            this.sys3Label25.UnitText = "";
            this.sys3Label25.UseBorder = true;
            this.sys3Label25.UseEdgeRadius = false;
            this.sys3Label25.UseImage = false;
            this.sys3Label25.UseSubFont = true;
            this.sys3Label25.UseUnitFont = false;
            // 
            // sys3Label16
            // 
            this.sys3Label16.BackGroundColor = System.Drawing.Color.DarkGray;
            this.sys3Label16.BorderStroke = 2;
            this.sys3Label16.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.sys3Label16.Description = "";
            this.sys3Label16.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3Label16.EdgeRadius = 1;
            this.sys3Label16.ImagePosition = new System.Drawing.Point(0, 0);
            this.sys3Label16.ImageSize = new System.Drawing.Point(0, 0);
            this.sys3Label16.LoadImage = null;
            this.sys3Label16.Location = new System.Drawing.Point(562, 530);
            this.sys3Label16.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label16.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label16.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label16.Name = "sys3Label16";
            this.sys3Label16.Size = new System.Drawing.Size(72, 30);
            this.sys3Label16.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label16.SubFontColor = System.Drawing.Color.Gray;
            this.sys3Label16.SubText = "";
            this.sys3Label16.TabIndex = 20828;
            this.sys3Label16.Tag = "";
            this.sys3Label16.Text = "LAST";
            this.sys3Label16.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3Label16.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.sys3Label16.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label16.ThemeIndex = 0;
            this.sys3Label16.UnitAreaRate = 30;
            this.sys3Label16.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label16.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sys3Label16.UnitPositionVertical = false;
            this.sys3Label16.UnitText = "";
            this.sys3Label16.UseBorder = true;
            this.sys3Label16.UseEdgeRadius = false;
            this.sys3Label16.UseImage = false;
            this.sys3Label16.UseSubFont = true;
            this.sys3Label16.UseUnitFont = false;
            // 
            // sys3Label50
            // 
            this.sys3Label50.BackGroundColor = System.Drawing.Color.DarkGray;
            this.sys3Label50.BorderStroke = 2;
            this.sys3Label50.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.sys3Label50.Description = "";
            this.sys3Label50.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3Label50.EdgeRadius = 1;
            this.sys3Label50.ImagePosition = new System.Drawing.Point(0, 0);
            this.sys3Label50.ImageSize = new System.Drawing.Point(0, 0);
            this.sys3Label50.LoadImage = null;
            this.sys3Label50.Location = new System.Drawing.Point(562, 565);
            this.sys3Label50.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label50.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label50.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label50.Name = "sys3Label50";
            this.sys3Label50.Size = new System.Drawing.Size(72, 30);
            this.sys3Label50.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label50.SubFontColor = System.Drawing.Color.Gray;
            this.sys3Label50.SubText = "";
            this.sys3Label50.TabIndex = 20829;
            this.sys3Label50.Tag = "";
            this.sys3Label50.Text = "MIN";
            this.sys3Label50.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3Label50.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.sys3Label50.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label50.ThemeIndex = 0;
            this.sys3Label50.UnitAreaRate = 30;
            this.sys3Label50.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label50.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sys3Label50.UnitPositionVertical = false;
            this.sys3Label50.UnitText = "";
            this.sys3Label50.UseBorder = true;
            this.sys3Label50.UseEdgeRadius = false;
            this.sys3Label50.UseImage = false;
            this.sys3Label50.UseSubFont = true;
            this.sys3Label50.UseUnitFont = false;
            // 
            // m_ZedGraph
            // 
            this.m_ZedGraph.Location = new System.Drawing.Point(3, 528);
            this.m_ZedGraph.Name = "m_ZedGraph";
            this.m_ZedGraph.ScrollGrace = 0D;
            this.m_ZedGraph.ScrollMaxX = 0D;
            this.m_ZedGraph.ScrollMaxY = 0D;
            this.m_ZedGraph.ScrollMaxY2 = 0D;
            this.m_ZedGraph.ScrollMinX = 0D;
            this.m_ZedGraph.ScrollMinY = 0D;
            this.m_ZedGraph.ScrollMinY2 = 0D;
            this.m_ZedGraph.Size = new System.Drawing.Size(555, 303);
            this.m_ZedGraph.TabIndex = 20830;
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
            this.sys3GroupBox2.Location = new System.Drawing.Point(0, 495);
            this.sys3GroupBox2.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3GroupBox2.Name = "sys3GroupBox2";
            this.sys3GroupBox2.Size = new System.Drawing.Size(902, 341);
            this.sys3GroupBox2.TabIndex = 20826;
            this.sys3GroupBox2.Tag = "";
            this.sys3GroupBox2.Text = "RESULT";
            this.sys3GroupBox2.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3GroupBox2.ThemeIndex = 0;
            this.sys3GroupBox2.UseLabelBorder = true;
            // 
            // sys3Label48
            // 
            this.sys3Label48.BackGroundColor = System.Drawing.Color.DarkGray;
            this.sys3Label48.BorderStroke = 2;
            this.sys3Label48.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.sys3Label48.Description = "";
            this.sys3Label48.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3Label48.EdgeRadius = 1;
            this.sys3Label48.ImagePosition = new System.Drawing.Point(0, 0);
            this.sys3Label48.ImageSize = new System.Drawing.Point(0, 0);
            this.sys3Label48.LoadImage = null;
            this.sys3Label48.Location = new System.Drawing.Point(562, 596);
            this.sys3Label48.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label48.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label48.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label48.Name = "sys3Label48";
            this.sys3Label48.Size = new System.Drawing.Size(72, 30);
            this.sys3Label48.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label48.SubFontColor = System.Drawing.Color.Gray;
            this.sys3Label48.SubText = "";
            this.sys3Label48.TabIndex = 20835;
            this.sys3Label48.Tag = "";
            this.sys3Label48.Text = "MAX";
            this.sys3Label48.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3Label48.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.sys3Label48.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label48.ThemeIndex = 0;
            this.sys3Label48.UnitAreaRate = 30;
            this.sys3Label48.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label48.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sys3Label48.UnitPositionVertical = false;
            this.sys3Label48.UnitText = "";
            this.sys3Label48.UseBorder = true;
            this.sys3Label48.UseEdgeRadius = false;
            this.sys3Label48.UseImage = false;
            this.sys3Label48.UseSubFont = true;
            this.sys3Label48.UseUnitFont = false;
            // 
            // sys3Label4
            // 
            this.sys3Label4.BackGroundColor = System.Drawing.Color.DarkGray;
            this.sys3Label4.BorderStroke = 2;
            this.sys3Label4.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.sys3Label4.Description = "";
            this.sys3Label4.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3Label4.EdgeRadius = 1;
            this.sys3Label4.ImagePosition = new System.Drawing.Point(0, 0);
            this.sys3Label4.ImageSize = new System.Drawing.Point(0, 0);
            this.sys3Label4.LoadImage = null;
            this.sys3Label4.Location = new System.Drawing.Point(728, 561);
            this.sys3Label4.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label4.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label4.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label4.Name = "sys3Label4";
            this.sys3Label4.Size = new System.Drawing.Size(72, 30);
            this.sys3Label4.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label4.SubFontColor = System.Drawing.Color.Gray;
            this.sys3Label4.SubText = "";
            this.sys3Label4.TabIndex = 20827;
            this.sys3Label4.Tag = "";
            this.sys3Label4.Text = "COUNT";
            this.sys3Label4.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3Label4.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.sys3Label4.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label4.ThemeIndex = 0;
            this.sys3Label4.UnitAreaRate = 30;
            this.sys3Label4.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label4.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sys3Label4.UnitPositionVertical = false;
            this.sys3Label4.UnitText = "";
            this.sys3Label4.UseBorder = true;
            this.sys3Label4.UseEdgeRadius = false;
            this.sys3Label4.UseImage = false;
            this.sys3Label4.UseSubFont = true;
            this.sys3Label4.UseUnitFont = false;
            // 
            // m_lblRepeatCount
            // 
            this.m_lblRepeatCount.BackGroundColor = System.Drawing.Color.DimGray;
            this.m_lblRepeatCount.BorderStroke = 2;
            this.m_lblRepeatCount.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblRepeatCount.Description = "";
            this.m_lblRepeatCount.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblRepeatCount.EdgeRadius = 1;
            this.m_lblRepeatCount.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_lblRepeatCount.ImageSize = new System.Drawing.Point(0, 0);
            this.m_lblRepeatCount.LoadImage = null;
            this.m_lblRepeatCount.Location = new System.Drawing.Point(801, 561);
            this.m_lblRepeatCount.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_lblRepeatCount.MainFontColor = System.Drawing.Color.White;
            this.m_lblRepeatCount.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_lblRepeatCount.Name = "m_lblRepeatCount";
            this.m_lblRepeatCount.Size = new System.Drawing.Size(89, 30);
            this.m_lblRepeatCount.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblRepeatCount.SubFontColor = System.Drawing.Color.Gray;
            this.m_lblRepeatCount.SubText = "";
            this.m_lblRepeatCount.TabIndex = 20831;
            this.m_lblRepeatCount.Tag = "";
            this.m_lblRepeatCount.Text = "9999.9";
            this.m_lblRepeatCount.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblRepeatCount.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblRepeatCount.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblRepeatCount.ThemeIndex = 0;
            this.m_lblRepeatCount.UnitAreaRate = 30;
            this.m_lblRepeatCount.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblRepeatCount.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblRepeatCount.UnitPositionVertical = false;
            this.m_lblRepeatCount.UnitText = "W";
            this.m_lblRepeatCount.UseBorder = true;
            this.m_lblRepeatCount.UseEdgeRadius = false;
            this.m_lblRepeatCount.UseImage = false;
            this.m_lblRepeatCount.UseSubFont = true;
            this.m_lblRepeatCount.UseUnitFont = false;
            // 
            // sys3button2
            // 
            this.sys3button2.BorderWidth = 5;
            this.sys3button2.ButtonClicked = false;
            this.sys3button2.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.sys3button2.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.sys3button2.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.sys3button2.Description = "";
            this.sys3button2.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3button2.EdgeRadius = 5;
            this.sys3button2.GradientAngle = 60F;
            this.sys3button2.GradientFirstColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(230)))), ((int)(((byte)(115)))));
            this.sys3button2.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(135)))), ((int)(((byte)(20)))));
            this.sys3button2.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.sys3button2.ImagePosition = new System.Drawing.Point(37, 25);
            this.sys3button2.ImageSize = new System.Drawing.Point(30, 30);
            this.sys3button2.LoadImage = null;
            this.sys3button2.Location = new System.Drawing.Point(907, 572);
            this.sys3button2.MainFont = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sys3button2.MainFontColor = System.Drawing.Color.White;
            this.sys3button2.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3button2.Name = "sys3button2";
            this.sys3button2.Size = new System.Drawing.Size(222, 63);
            this.sys3button2.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.sys3button2.SubFontColor = System.Drawing.Color.Black;
            this.sys3button2.SubText = "";
            this.sys3button2.TabIndex = 1;
            this.sys3button2.Tag = "";
            this.sys3button2.Text = "MEASURE\\nVOLT";
            this.sys3button2.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3button2.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3button2.ThemeIndex = 0;
            this.sys3button2.UseBorder = true;
            this.sys3button2.UseClickedEmphasizeTextColor = false;
            this.sys3button2.UseCustomizeClickedColor = false;
            this.sys3button2.UseEdge = true;
            this.sys3button2.UseHoverEmphasizeCustomColor = false;
            this.sys3button2.UseImage = true;
            this.sys3button2.UserHoverEmpahsize = false;
            this.sys3button2.UseSubFont = false;
            this.sys3button2.Click += new System.EventHandler(this.Click_Action);
            // 
            // sys3button7
            // 
            this.sys3button7.BorderWidth = 5;
            this.sys3button7.ButtonClicked = false;
            this.sys3button7.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.sys3button7.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.sys3button7.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.sys3button7.Description = "";
            this.sys3button7.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3button7.EdgeRadius = 5;
            this.sys3button7.GradientAngle = 60F;
            this.sys3button7.GradientFirstColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(230)))), ((int)(((byte)(115)))));
            this.sys3button7.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(135)))), ((int)(((byte)(20)))));
            this.sys3button7.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.sys3button7.ImagePosition = new System.Drawing.Point(37, 25);
            this.sys3button7.ImageSize = new System.Drawing.Point(30, 30);
            this.sys3button7.LoadImage = null;
            this.sys3button7.Location = new System.Drawing.Point(907, 636);
            this.sys3button7.MainFont = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sys3button7.MainFontColor = System.Drawing.Color.White;
            this.sys3button7.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3button7.Name = "sys3button7";
            this.sys3button7.Size = new System.Drawing.Size(222, 63);
            this.sys3button7.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.sys3button7.SubFontColor = System.Drawing.Color.Black;
            this.sys3button7.SubText = "";
            this.sys3button7.TabIndex = 2;
            this.sys3button7.Tag = "";
            this.sys3button7.Text = "CALIBRATION\\nCH POWER";
            this.sys3button7.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3button7.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3button7.ThemeIndex = 0;
            this.sys3button7.UseBorder = true;
            this.sys3button7.UseClickedEmphasizeTextColor = false;
            this.sys3button7.UseCustomizeClickedColor = false;
            this.sys3button7.UseEdge = true;
            this.sys3button7.UseHoverEmphasizeCustomColor = false;
            this.sys3button7.UseImage = true;
            this.sys3button7.UserHoverEmpahsize = false;
            this.sys3button7.UseSubFont = false;
            this.sys3button7.Click += new System.EventHandler(this.Click_Action);
            // 
            // m_btnRun
            // 
            this.m_btnRun.BorderWidth = 5;
            this.m_btnRun.ButtonClicked = false;
            this.m_btnRun.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.m_btnRun.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.m_btnRun.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.m_btnRun.Description = "";
            this.m_btnRun.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_btnRun.EdgeRadius = 5;
            this.m_btnRun.GradientAngle = 60F;
            this.m_btnRun.GradientFirstColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(230)))), ((int)(((byte)(115)))));
            this.m_btnRun.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(135)))), ((int)(((byte)(20)))));
            this.m_btnRun.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.m_btnRun.ImagePosition = new System.Drawing.Point(37, 25);
            this.m_btnRun.ImageSize = new System.Drawing.Point(30, 30);
            this.m_btnRun.LoadImage = null;
            this.m_btnRun.Location = new System.Drawing.Point(907, 508);
            this.m_btnRun.MainFont = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.m_btnRun.MainFontColor = System.Drawing.Color.White;
            this.m_btnRun.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_btnRun.Name = "m_btnRun";
            this.m_btnRun.Size = new System.Drawing.Size(222, 63);
            this.m_btnRun.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.m_btnRun.SubFontColor = System.Drawing.Color.Black;
            this.m_btnRun.SubText = "";
            this.m_btnRun.TabIndex = 0;
            this.m_btnRun.Tag = "";
            this.m_btnRun.Text = "MEASURE\\nPOWER";
            this.m_btnRun.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_btnRun.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_btnRun.ThemeIndex = 0;
            this.m_btnRun.UseBorder = true;
            this.m_btnRun.UseClickedEmphasizeTextColor = false;
            this.m_btnRun.UseCustomizeClickedColor = false;
            this.m_btnRun.UseEdge = true;
            this.m_btnRun.UseHoverEmphasizeCustomColor = false;
            this.m_btnRun.UseImage = true;
            this.m_btnRun.UserHoverEmpahsize = false;
            this.m_btnRun.UseSubFont = false;
            this.m_btnRun.Click += new System.EventHandler(this.Click_Action);
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
            this.sys3Label6.Location = new System.Drawing.Point(728, 623);
            this.sys3Label6.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label6.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label6.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label6.Name = "sys3Label6";
            this.sys3Label6.Size = new System.Drawing.Size(72, 30);
            this.sys3Label6.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label6.SubFontColor = System.Drawing.Color.Gray;
            this.sys3Label6.SubText = "";
            this.sys3Label6.TabIndex = 20827;
            this.sys3Label6.Tag = "";
            this.sys3Label6.Text = "REST";
            this.sys3Label6.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3Label6.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.sys3Label6.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label6.ThemeIndex = 0;
            this.sys3Label6.UnitAreaRate = 30;
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
            // m_lblRestTime
            // 
            this.m_lblRestTime.BackGroundColor = System.Drawing.Color.DimGray;
            this.m_lblRestTime.BorderStroke = 2;
            this.m_lblRestTime.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblRestTime.Description = "";
            this.m_lblRestTime.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblRestTime.EdgeRadius = 1;
            this.m_lblRestTime.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_lblRestTime.ImageSize = new System.Drawing.Point(0, 0);
            this.m_lblRestTime.LoadImage = null;
            this.m_lblRestTime.Location = new System.Drawing.Point(801, 623);
            this.m_lblRestTime.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_lblRestTime.MainFontColor = System.Drawing.Color.White;
            this.m_lblRestTime.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_lblRestTime.Name = "m_lblRestTime";
            this.m_lblRestTime.Size = new System.Drawing.Size(89, 30);
            this.m_lblRestTime.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblRestTime.SubFontColor = System.Drawing.Color.Gray;
            this.m_lblRestTime.SubText = "";
            this.m_lblRestTime.TabIndex = 20831;
            this.m_lblRestTime.Tag = "";
            this.m_lblRestTime.Text = "9999.9";
            this.m_lblRestTime.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblRestTime.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblRestTime.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblRestTime.ThemeIndex = 0;
            this.m_lblRestTime.UnitAreaRate = 30;
            this.m_lblRestTime.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblRestTime.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblRestTime.UnitPositionVertical = false;
            this.m_lblRestTime.UnitText = "S";
            this.m_lblRestTime.UseBorder = true;
            this.m_lblRestTime.UseEdgeRadius = false;
            this.m_lblRestTime.UseImage = false;
            this.m_lblRestTime.UseSubFont = true;
            this.m_lblRestTime.UseUnitFont = true;
            // 
            // sys3Label8
            // 
            this.sys3Label8.BackGroundColor = System.Drawing.Color.DarkGray;
            this.sys3Label8.BorderStroke = 2;
            this.sys3Label8.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.sys3Label8.Description = "";
            this.sys3Label8.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3Label8.EdgeRadius = 1;
            this.sys3Label8.ImagePosition = new System.Drawing.Point(0, 0);
            this.sys3Label8.ImageSize = new System.Drawing.Point(0, 0);
            this.sys3Label8.LoadImage = null;
            this.sys3Label8.Location = new System.Drawing.Point(728, 530);
            this.sys3Label8.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label8.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label8.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label8.Name = "sys3Label8";
            this.sys3Label8.Size = new System.Drawing.Size(162, 30);
            this.sys3Label8.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label8.SubFontColor = System.Drawing.Color.Gray;
            this.sys3Label8.SubText = "";
            this.sys3Label8.TabIndex = 20827;
            this.sys3Label8.Tag = "";
            this.sys3Label8.Text = "REPEAT";
            this.sys3Label8.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label8.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.sys3Label8.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label8.ThemeIndex = 0;
            this.sys3Label8.UnitAreaRate = 30;
            this.sys3Label8.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label8.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sys3Label8.UnitPositionVertical = false;
            this.sys3Label8.UnitText = "";
            this.sys3Label8.UseBorder = true;
            this.sys3Label8.UseEdgeRadius = false;
            this.sys3Label8.UseImage = false;
            this.sys3Label8.UseSubFont = true;
            this.sys3Label8.UseUnitFont = false;
            // 
            // sys3Label9
            // 
            this.sys3Label9.BackGroundColor = System.Drawing.Color.DarkGray;
            this.sys3Label9.BorderStroke = 2;
            this.sys3Label9.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.sys3Label9.Description = "";
            this.sys3Label9.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3Label9.EdgeRadius = 1;
            this.sys3Label9.ImagePosition = new System.Drawing.Point(0, 0);
            this.sys3Label9.ImageSize = new System.Drawing.Point(0, 0);
            this.sys3Label9.LoadImage = null;
            this.sys3Label9.Location = new System.Drawing.Point(728, 592);
            this.sys3Label9.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label9.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label9.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label9.Name = "sys3Label9";
            this.sys3Label9.Size = new System.Drawing.Size(72, 30);
            this.sys3Label9.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label9.SubFontColor = System.Drawing.Color.Gray;
            this.sys3Label9.SubText = "";
            this.sys3Label9.TabIndex = 20827;
            this.sys3Label9.Tag = "";
            this.sys3Label9.Text = "AVG";
            this.sys3Label9.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3Label9.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.sys3Label9.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label9.ThemeIndex = 0;
            this.sys3Label9.UnitAreaRate = 30;
            this.sys3Label9.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label9.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sys3Label9.UnitPositionVertical = false;
            this.sys3Label9.UnitText = "";
            this.sys3Label9.UseBorder = true;
            this.sys3Label9.UseEdgeRadius = false;
            this.sys3Label9.UseImage = false;
            this.sys3Label9.UseSubFont = true;
            this.sys3Label9.UseUnitFont = false;
            // 
            // m_lblRepeatAvg
            // 
            this.m_lblRepeatAvg.BackGroundColor = System.Drawing.Color.DimGray;
            this.m_lblRepeatAvg.BorderStroke = 2;
            this.m_lblRepeatAvg.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblRepeatAvg.Description = "";
            this.m_lblRepeatAvg.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblRepeatAvg.EdgeRadius = 1;
            this.m_lblRepeatAvg.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_lblRepeatAvg.ImageSize = new System.Drawing.Point(0, 0);
            this.m_lblRepeatAvg.LoadImage = null;
            this.m_lblRepeatAvg.Location = new System.Drawing.Point(801, 592);
            this.m_lblRepeatAvg.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_lblRepeatAvg.MainFontColor = System.Drawing.Color.White;
            this.m_lblRepeatAvg.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_lblRepeatAvg.Name = "m_lblRepeatAvg";
            this.m_lblRepeatAvg.Size = new System.Drawing.Size(89, 30);
            this.m_lblRepeatAvg.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblRepeatAvg.SubFontColor = System.Drawing.Color.Gray;
            this.m_lblRepeatAvg.SubText = "";
            this.m_lblRepeatAvg.TabIndex = 20831;
            this.m_lblRepeatAvg.Tag = "";
            this.m_lblRepeatAvg.Text = "9999.9";
            this.m_lblRepeatAvg.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblRepeatAvg.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblRepeatAvg.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblRepeatAvg.ThemeIndex = 0;
            this.m_lblRepeatAvg.UnitAreaRate = 30;
            this.m_lblRepeatAvg.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblRepeatAvg.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblRepeatAvg.UnitPositionVertical = false;
            this.m_lblRepeatAvg.UnitText = "W";
            this.m_lblRepeatAvg.UseBorder = true;
            this.m_lblRepeatAvg.UseEdgeRadius = false;
            this.m_lblRepeatAvg.UseImage = false;
            this.m_lblRepeatAvg.UseSubFont = true;
            this.m_lblRepeatAvg.UseUnitFont = true;
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
            this.sys3Label11.Location = new System.Drawing.Point(728, 704);
            this.sys3Label11.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label11.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label11.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label11.Name = "sys3Label11";
            this.sys3Label11.Size = new System.Drawing.Size(72, 30);
            this.sys3Label11.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label11.SubFontColor = System.Drawing.Color.Gray;
            this.sys3Label11.SubText = "";
            this.sys3Label11.TabIndex = 20827;
            this.sys3Label11.Tag = "";
            this.sys3Label11.Text = "CH";
            this.sys3Label11.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3Label11.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.sys3Label11.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label11.ThemeIndex = 0;
            this.sys3Label11.UnitAreaRate = 30;
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
            // m_lblCalChannel
            // 
            this.m_lblCalChannel.BackGroundColor = System.Drawing.Color.DimGray;
            this.m_lblCalChannel.BorderStroke = 2;
            this.m_lblCalChannel.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblCalChannel.Description = "";
            this.m_lblCalChannel.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblCalChannel.EdgeRadius = 1;
            this.m_lblCalChannel.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_lblCalChannel.ImageSize = new System.Drawing.Point(0, 0);
            this.m_lblCalChannel.LoadImage = null;
            this.m_lblCalChannel.Location = new System.Drawing.Point(801, 704);
            this.m_lblCalChannel.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_lblCalChannel.MainFontColor = System.Drawing.Color.White;
            this.m_lblCalChannel.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_lblCalChannel.Name = "m_lblCalChannel";
            this.m_lblCalChannel.Size = new System.Drawing.Size(89, 30);
            this.m_lblCalChannel.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblCalChannel.SubFontColor = System.Drawing.Color.Gray;
            this.m_lblCalChannel.SubText = "";
            this.m_lblCalChannel.TabIndex = 20831;
            this.m_lblCalChannel.Tag = "";
            this.m_lblCalChannel.Text = "9999.9";
            this.m_lblCalChannel.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblCalChannel.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblCalChannel.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblCalChannel.ThemeIndex = 0;
            this.m_lblCalChannel.UnitAreaRate = 30;
            this.m_lblCalChannel.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblCalChannel.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblCalChannel.UnitPositionVertical = false;
            this.m_lblCalChannel.UnitText = "W";
            this.m_lblCalChannel.UseBorder = true;
            this.m_lblCalChannel.UseEdgeRadius = false;
            this.m_lblCalChannel.UseImage = false;
            this.m_lblCalChannel.UseSubFont = true;
            this.m_lblCalChannel.UseUnitFont = false;
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
            this.sys3Label13.Location = new System.Drawing.Point(656, 372);
            this.sys3Label13.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label13.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label13.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label13.Name = "sys3Label13";
            this.sys3Label13.Size = new System.Drawing.Size(91, 37);
            this.sys3Label13.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label13.SubFontColor = System.Drawing.Color.DarkRed;
            this.sys3Label13.SubText = "";
            this.sys3Label13.TabIndex = 20687;
            this.sys3Label13.Tag = "";
            this.sys3Label13.Text = "PORT 1";
            this.sys3Label13.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3Label13.TextAlignSub = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
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
            // m_lblAlarmCodePort1
            // 
            this.m_lblAlarmCodePort1.BackGroundColor = System.Drawing.Color.DimGray;
            this.m_lblAlarmCodePort1.BorderStroke = 2;
            this.m_lblAlarmCodePort1.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblAlarmCodePort1.Description = "";
            this.m_lblAlarmCodePort1.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblAlarmCodePort1.EdgeRadius = 1;
            this.m_lblAlarmCodePort1.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_lblAlarmCodePort1.ImageSize = new System.Drawing.Point(0, 0);
            this.m_lblAlarmCodePort1.LoadImage = null;
            this.m_lblAlarmCodePort1.Location = new System.Drawing.Point(748, 372);
            this.m_lblAlarmCodePort1.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_lblAlarmCodePort1.MainFontColor = System.Drawing.Color.White;
            this.m_lblAlarmCodePort1.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_lblAlarmCodePort1.Name = "m_lblAlarmCodePort1";
            this.m_lblAlarmCodePort1.Size = new System.Drawing.Size(143, 37);
            this.m_lblAlarmCodePort1.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblAlarmCodePort1.SubFontColor = System.Drawing.Color.Gray;
            this.m_lblAlarmCodePort1.SubText = "";
            this.m_lblAlarmCodePort1.TabIndex = 20833;
            this.m_lblAlarmCodePort1.Tag = "";
            this.m_lblAlarmCodePort1.Text = "NONE";
            this.m_lblAlarmCodePort1.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.m_lblAlarmCodePort1.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblAlarmCodePort1.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblAlarmCodePort1.ThemeIndex = 0;
            this.m_lblAlarmCodePort1.UnitAreaRate = 30;
            this.m_lblAlarmCodePort1.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblAlarmCodePort1.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblAlarmCodePort1.UnitPositionVertical = false;
            this.m_lblAlarmCodePort1.UnitText = "W";
            this.m_lblAlarmCodePort1.UseBorder = true;
            this.m_lblAlarmCodePort1.UseEdgeRadius = false;
            this.m_lblAlarmCodePort1.UseImage = false;
            this.m_lblAlarmCodePort1.UseSubFont = true;
            this.m_lblAlarmCodePort1.UseUnitFont = false;
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
            this.sys3Label5.Location = new System.Drawing.Point(728, 673);
            this.sys3Label5.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label5.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label5.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label5.Name = "sys3Label5";
            this.sys3Label5.Size = new System.Drawing.Size(162, 30);
            this.sys3Label5.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label5.SubFontColor = System.Drawing.Color.Gray;
            this.sys3Label5.SubText = "";
            this.sys3Label5.TabIndex = 20827;
            this.sys3Label5.Tag = "";
            this.sys3Label5.Text = "CALIBRATION";
            this.sys3Label5.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label5.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.sys3Label5.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label5.ThemeIndex = 0;
            this.sys3Label5.UnitAreaRate = 30;
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
            // sys3Label7
            // 
            this.sys3Label7.BackGroundColor = System.Drawing.Color.DarkGray;
            this.sys3Label7.BorderStroke = 2;
            this.sys3Label7.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.sys3Label7.Description = "";
            this.sys3Label7.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3Label7.EdgeRadius = 1;
            this.sys3Label7.ImagePosition = new System.Drawing.Point(0, 0);
            this.sys3Label7.ImageSize = new System.Drawing.Point(0, 0);
            this.sys3Label7.LoadImage = null;
            this.sys3Label7.Location = new System.Drawing.Point(728, 735);
            this.sys3Label7.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label7.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label7.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label7.Name = "sys3Label7";
            this.sys3Label7.Size = new System.Drawing.Size(72, 30);
            this.sys3Label7.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label7.SubFontColor = System.Drawing.Color.Gray;
            this.sys3Label7.SubText = "";
            this.sys3Label7.TabIndex = 20827;
            this.sys3Label7.Tag = "";
            this.sys3Label7.Text = "STEP";
            this.sys3Label7.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3Label7.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.sys3Label7.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label7.ThemeIndex = 0;
            this.sys3Label7.UnitAreaRate = 30;
            this.sys3Label7.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label7.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sys3Label7.UnitPositionVertical = false;
            this.sys3Label7.UnitText = "";
            this.sys3Label7.UseBorder = true;
            this.sys3Label7.UseEdgeRadius = false;
            this.sys3Label7.UseImage = false;
            this.sys3Label7.UseSubFont = true;
            this.sys3Label7.UseUnitFont = false;
            // 
            // m_lblCalStep
            // 
            this.m_lblCalStep.BackGroundColor = System.Drawing.Color.DimGray;
            this.m_lblCalStep.BorderStroke = 2;
            this.m_lblCalStep.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblCalStep.Description = "";
            this.m_lblCalStep.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblCalStep.EdgeRadius = 1;
            this.m_lblCalStep.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_lblCalStep.ImageSize = new System.Drawing.Point(0, 0);
            this.m_lblCalStep.LoadImage = null;
            this.m_lblCalStep.Location = new System.Drawing.Point(801, 735);
            this.m_lblCalStep.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_lblCalStep.MainFontColor = System.Drawing.Color.White;
            this.m_lblCalStep.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_lblCalStep.Name = "m_lblCalStep";
            this.m_lblCalStep.Size = new System.Drawing.Size(89, 30);
            this.m_lblCalStep.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblCalStep.SubFontColor = System.Drawing.Color.Gray;
            this.m_lblCalStep.SubText = "";
            this.m_lblCalStep.TabIndex = 20831;
            this.m_lblCalStep.Tag = "";
            this.m_lblCalStep.Text = "9999.9";
            this.m_lblCalStep.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblCalStep.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblCalStep.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblCalStep.ThemeIndex = 0;
            this.m_lblCalStep.UnitAreaRate = 30;
            this.m_lblCalStep.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblCalStep.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblCalStep.UnitPositionVertical = false;
            this.m_lblCalStep.UnitText = "W";
            this.m_lblCalStep.UseBorder = true;
            this.m_lblCalStep.UseEdgeRadius = false;
            this.m_lblCalStep.UseImage = false;
            this.m_lblCalStep.UseSubFont = true;
            this.m_lblCalStep.UseUnitFont = false;
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
            this.sys3Label12.Location = new System.Drawing.Point(728, 766);
            this.sys3Label12.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label12.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label12.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label12.Name = "sys3Label12";
            this.sys3Label12.Size = new System.Drawing.Size(72, 30);
            this.sys3Label12.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label12.SubFontColor = System.Drawing.Color.Gray;
            this.sys3Label12.SubText = "";
            this.sys3Label12.TabIndex = 20827;
            this.sys3Label12.Tag = "";
            this.sys3Label12.Text = "VOLT";
            this.sys3Label12.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3Label12.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.sys3Label12.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label12.ThemeIndex = 0;
            this.sys3Label12.UnitAreaRate = 30;
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
            // m_lblCalVolt
            // 
            this.m_lblCalVolt.BackGroundColor = System.Drawing.Color.DimGray;
            this.m_lblCalVolt.BorderStroke = 2;
            this.m_lblCalVolt.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblCalVolt.Description = "";
            this.m_lblCalVolt.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblCalVolt.EdgeRadius = 1;
            this.m_lblCalVolt.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_lblCalVolt.ImageSize = new System.Drawing.Point(0, 0);
            this.m_lblCalVolt.LoadImage = null;
            this.m_lblCalVolt.Location = new System.Drawing.Point(801, 766);
            this.m_lblCalVolt.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_lblCalVolt.MainFontColor = System.Drawing.Color.White;
            this.m_lblCalVolt.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_lblCalVolt.Name = "m_lblCalVolt";
            this.m_lblCalVolt.Size = new System.Drawing.Size(89, 30);
            this.m_lblCalVolt.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblCalVolt.SubFontColor = System.Drawing.Color.Gray;
            this.m_lblCalVolt.SubText = "";
            this.m_lblCalVolt.TabIndex = 20831;
            this.m_lblCalVolt.Tag = "";
            this.m_lblCalVolt.Text = "9999.9";
            this.m_lblCalVolt.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblCalVolt.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblCalVolt.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblCalVolt.ThemeIndex = 0;
            this.m_lblCalVolt.UnitAreaRate = 30;
            this.m_lblCalVolt.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblCalVolt.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblCalVolt.UnitPositionVertical = false;
            this.m_lblCalVolt.UnitText = "V";
            this.m_lblCalVolt.UseBorder = true;
            this.m_lblCalVolt.UseEdgeRadius = false;
            this.m_lblCalVolt.UseImage = false;
            this.m_lblCalVolt.UseSubFont = true;
            this.m_lblCalVolt.UseUnitFont = true;
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
            this.sys3GroupBox3.Location = new System.Drawing.Point(647, 338);
            this.sys3GroupBox3.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3GroupBox3.Name = "sys3GroupBox3";
            this.sys3GroupBox3.Size = new System.Drawing.Size(488, 156);
            this.sys3GroupBox3.TabIndex = 20683;
            this.sys3GroupBox3.Tag = "";
            this.sys3GroupBox3.Text = "SOURCE ALARM CODE";
            this.sys3GroupBox3.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3GroupBox3.ThemeIndex = 0;
            this.sys3GroupBox3.UseLabelBorder = true;
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
            this.sys3Label2.Location = new System.Drawing.Point(892, 410);
            this.sys3Label2.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label2.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label2.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label2.Name = "sys3Label2";
            this.sys3Label2.Size = new System.Drawing.Size(91, 37);
            this.sys3Label2.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label2.SubFontColor = System.Drawing.Color.DarkRed;
            this.sys3Label2.SubText = "";
            this.sys3Label2.TabIndex = 20687;
            this.sys3Label2.Tag = "";
            this.sys3Label2.Text = "MONITOR";
            this.sys3Label2.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3Label2.TextAlignSub = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
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
            // m_lblAlarmCodeMonitor
            // 
            this.m_lblAlarmCodeMonitor.BackGroundColor = System.Drawing.Color.DimGray;
            this.m_lblAlarmCodeMonitor.BorderStroke = 2;
            this.m_lblAlarmCodeMonitor.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblAlarmCodeMonitor.Description = "";
            this.m_lblAlarmCodeMonitor.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblAlarmCodeMonitor.EdgeRadius = 1;
            this.m_lblAlarmCodeMonitor.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_lblAlarmCodeMonitor.ImageSize = new System.Drawing.Point(0, 0);
            this.m_lblAlarmCodeMonitor.LoadImage = null;
            this.m_lblAlarmCodeMonitor.Location = new System.Drawing.Point(984, 410);
            this.m_lblAlarmCodeMonitor.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_lblAlarmCodeMonitor.MainFontColor = System.Drawing.Color.White;
            this.m_lblAlarmCodeMonitor.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_lblAlarmCodeMonitor.Name = "m_lblAlarmCodeMonitor";
            this.m_lblAlarmCodeMonitor.Size = new System.Drawing.Size(143, 37);
            this.m_lblAlarmCodeMonitor.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblAlarmCodeMonitor.SubFontColor = System.Drawing.Color.Gray;
            this.m_lblAlarmCodeMonitor.SubText = "";
            this.m_lblAlarmCodeMonitor.TabIndex = 20833;
            this.m_lblAlarmCodeMonitor.Tag = "";
            this.m_lblAlarmCodeMonitor.Text = "NONE";
            this.m_lblAlarmCodeMonitor.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.m_lblAlarmCodeMonitor.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblAlarmCodeMonitor.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblAlarmCodeMonitor.ThemeIndex = 0;
            this.m_lblAlarmCodeMonitor.UnitAreaRate = 30;
            this.m_lblAlarmCodeMonitor.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblAlarmCodeMonitor.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblAlarmCodeMonitor.UnitPositionVertical = false;
            this.m_lblAlarmCodeMonitor.UnitText = "W";
            this.m_lblAlarmCodeMonitor.UseBorder = true;
            this.m_lblAlarmCodeMonitor.UseEdgeRadius = false;
            this.m_lblAlarmCodeMonitor.UseImage = false;
            this.m_lblAlarmCodeMonitor.UseSubFont = true;
            this.m_lblAlarmCodeMonitor.UseUnitFont = false;
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
            this.sys3Label14.Location = new System.Drawing.Point(892, 372);
            this.sys3Label14.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label14.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label14.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label14.Name = "sys3Label14";
            this.sys3Label14.Size = new System.Drawing.Size(91, 37);
            this.sys3Label14.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label14.SubFontColor = System.Drawing.Color.DarkRed;
            this.sys3Label14.SubText = "";
            this.sys3Label14.TabIndex = 20687;
            this.sys3Label14.Tag = "";
            this.sys3Label14.Text = "PORT 2";
            this.sys3Label14.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3Label14.TextAlignSub = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
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
            // m_lblAlarmCodePort2
            // 
            this.m_lblAlarmCodePort2.BackGroundColor = System.Drawing.Color.DimGray;
            this.m_lblAlarmCodePort2.BorderStroke = 2;
            this.m_lblAlarmCodePort2.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblAlarmCodePort2.Description = "";
            this.m_lblAlarmCodePort2.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblAlarmCodePort2.EdgeRadius = 1;
            this.m_lblAlarmCodePort2.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_lblAlarmCodePort2.ImageSize = new System.Drawing.Point(0, 0);
            this.m_lblAlarmCodePort2.LoadImage = null;
            this.m_lblAlarmCodePort2.Location = new System.Drawing.Point(984, 372);
            this.m_lblAlarmCodePort2.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_lblAlarmCodePort2.MainFontColor = System.Drawing.Color.White;
            this.m_lblAlarmCodePort2.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_lblAlarmCodePort2.Name = "m_lblAlarmCodePort2";
            this.m_lblAlarmCodePort2.Size = new System.Drawing.Size(143, 37);
            this.m_lblAlarmCodePort2.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblAlarmCodePort2.SubFontColor = System.Drawing.Color.Gray;
            this.m_lblAlarmCodePort2.SubText = "";
            this.m_lblAlarmCodePort2.TabIndex = 20833;
            this.m_lblAlarmCodePort2.Tag = "";
            this.m_lblAlarmCodePort2.Text = "NONE";
            this.m_lblAlarmCodePort2.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.m_lblAlarmCodePort2.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblAlarmCodePort2.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblAlarmCodePort2.ThemeIndex = 0;
            this.m_lblAlarmCodePort2.UnitAreaRate = 30;
            this.m_lblAlarmCodePort2.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblAlarmCodePort2.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblAlarmCodePort2.UnitPositionVertical = false;
            this.m_lblAlarmCodePort2.UnitText = "W";
            this.m_lblAlarmCodePort2.UseBorder = true;
            this.m_lblAlarmCodePort2.UseEdgeRadius = false;
            this.m_lblAlarmCodePort2.UseImage = false;
            this.m_lblAlarmCodePort2.UseSubFont = true;
            this.m_lblAlarmCodePort2.UseUnitFont = false;
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
            this.sys3Label17.Location = new System.Drawing.Point(656, 410);
            this.sys3Label17.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label17.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label17.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label17.Name = "sys3Label17";
            this.sys3Label17.Size = new System.Drawing.Size(91, 37);
            this.sys3Label17.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label17.SubFontColor = System.Drawing.Color.DarkRed;
            this.sys3Label17.SubText = "";
            this.sys3Label17.TabIndex = 20687;
            this.sys3Label17.Tag = "";
            this.sys3Label17.Text = "PORT 3";
            this.sys3Label17.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3Label17.TextAlignSub = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
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
            // m_lblAlarmCodePort3
            // 
            this.m_lblAlarmCodePort3.BackGroundColor = System.Drawing.Color.DimGray;
            this.m_lblAlarmCodePort3.BorderStroke = 2;
            this.m_lblAlarmCodePort3.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblAlarmCodePort3.Description = "";
            this.m_lblAlarmCodePort3.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblAlarmCodePort3.EdgeRadius = 1;
            this.m_lblAlarmCodePort3.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_lblAlarmCodePort3.ImageSize = new System.Drawing.Point(0, 0);
            this.m_lblAlarmCodePort3.LoadImage = null;
            this.m_lblAlarmCodePort3.Location = new System.Drawing.Point(748, 410);
            this.m_lblAlarmCodePort3.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_lblAlarmCodePort3.MainFontColor = System.Drawing.Color.White;
            this.m_lblAlarmCodePort3.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_lblAlarmCodePort3.Name = "m_lblAlarmCodePort3";
            this.m_lblAlarmCodePort3.Size = new System.Drawing.Size(143, 37);
            this.m_lblAlarmCodePort3.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblAlarmCodePort3.SubFontColor = System.Drawing.Color.Gray;
            this.m_lblAlarmCodePort3.SubText = "";
            this.m_lblAlarmCodePort3.TabIndex = 20833;
            this.m_lblAlarmCodePort3.Tag = "";
            this.m_lblAlarmCodePort3.Text = "NONE";
            this.m_lblAlarmCodePort3.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.m_lblAlarmCodePort3.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblAlarmCodePort3.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblAlarmCodePort3.ThemeIndex = 0;
            this.m_lblAlarmCodePort3.UnitAreaRate = 30;
            this.m_lblAlarmCodePort3.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblAlarmCodePort3.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblAlarmCodePort3.UnitPositionVertical = false;
            this.m_lblAlarmCodePort3.UnitText = "W";
            this.m_lblAlarmCodePort3.UseBorder = true;
            this.m_lblAlarmCodePort3.UseEdgeRadius = false;
            this.m_lblAlarmCodePort3.UseImage = false;
            this.m_lblAlarmCodePort3.UseSubFont = true;
            this.m_lblAlarmCodePort3.UseUnitFont = false;
            // 
            // gridVeiwControl_Device
            // 
            this.gridVeiwControl_Device.Control_Enable = true;
            this.gridVeiwControl_Device.controlCollection = null;
            this.gridVeiwControl_Device.Location = new System.Drawing.Point(647, 159);
            this.gridVeiwControl_Device.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.gridVeiwControl_Device.Name = "gridVeiwControl_Device";
            this.gridVeiwControl_Device.Size = new System.Drawing.Size(488, 178);
            this.gridVeiwControl_Device.TabIndex = 20842;
            // 
            // gridViewControl_Power_Measure_Parameter
            // 
            this.gridViewControl_Power_Measure_Parameter.Control_Enable = true;
            this.gridViewControl_Power_Measure_Parameter.controlCollection = null;
            this.gridViewControl_Power_Measure_Parameter.Location = new System.Drawing.Point(422, 159);
            this.gridViewControl_Power_Measure_Parameter.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.gridViewControl_Power_Measure_Parameter.Name = "gridViewControl_Power_Measure_Parameter";
            this.gridViewControl_Power_Measure_Parameter.Size = new System.Drawing.Size(224, 293);
            this.gridViewControl_Power_Measure_Parameter.TabIndex = 20837;
            // 
            // gridViewControl_Enable_Parameter
            // 
            this.gridViewControl_Enable_Parameter.Control_Enable = true;
            this.gridViewControl_Enable_Parameter.controlCollection = null;
            this.gridViewControl_Enable_Parameter.Location = new System.Drawing.Point(1, 1);
            this.gridViewControl_Enable_Parameter.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.gridViewControl_Enable_Parameter.Name = "gridViewControl_Enable_Parameter";
            this.gridViewControl_Enable_Parameter.Size = new System.Drawing.Size(1134, 53);
            this.gridViewControl_Enable_Parameter.TabIndex = 20837;
            // 
            // gridViewControl_Position_Parameter
            // 
            this.gridViewControl_Position_Parameter.Control_Enable = true;
            this.gridViewControl_Position_Parameter.controlCollection = null;
            this.gridViewControl_Position_Parameter.Location = new System.Drawing.Point(422, 55);
            this.gridViewControl_Position_Parameter.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.gridViewControl_Position_Parameter.Name = "gridViewControl_Position_Parameter";
            this.gridViewControl_Position_Parameter.Size = new System.Drawing.Size(713, 103);
            this.gridViewControl_Position_Parameter.TabIndex = 20836;
            // 
            // m_btnStop
            // 
            this.m_btnStop.BorderWidth = 5;
            this.m_btnStop.ButtonClicked = false;
            this.m_btnStop.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.m_btnStop.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.m_btnStop.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.m_btnStop.Description = "";
            this.m_btnStop.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_btnStop.EdgeRadius = 5;
            this.m_btnStop.GradientAngle = 60F;
            this.m_btnStop.GradientFirstColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.m_btnStop.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.m_btnStop.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.m_btnStop.ImagePosition = new System.Drawing.Point(37, 16);
            this.m_btnStop.ImageSize = new System.Drawing.Point(30, 30);
            this.m_btnStop.LoadImage = global::FrameOfSystem3.Properties.Resources.Stop_white;
            this.m_btnStop.Location = new System.Drawing.Point(907, 764);
            this.m_btnStop.MainFont = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.m_btnStop.MainFontColor = System.Drawing.Color.White;
            this.m_btnStop.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_btnStop.Name = "m_btnStop";
            this.m_btnStop.Size = new System.Drawing.Size(222, 63);
            this.m_btnStop.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.m_btnStop.SubFontColor = System.Drawing.Color.Black;
            this.m_btnStop.SubText = "";
            this.m_btnStop.TabIndex = 20841;
            this.m_btnStop.Text = "　STOP";
            this.m_btnStop.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_btnStop.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_btnStop.ThemeIndex = 0;
            this.m_btnStop.UseBorder = true;
            this.m_btnStop.UseClickedEmphasizeTextColor = false;
            this.m_btnStop.UseCustomizeClickedColor = false;
            this.m_btnStop.UseEdge = true;
            this.m_btnStop.UseHoverEmphasizeCustomColor = false;
            this.m_btnStop.UseImage = true;
            this.m_btnStop.UserHoverEmpahsize = false;
            this.m_btnStop.UseSubFont = false;
            this.m_btnStop.Click += new System.EventHandler(this.Click_Stop);
            // 
            // btn_CalLoad
            // 
            this.btn_CalLoad.BorderWidth = 2;
            this.btn_CalLoad.ButtonClicked = false;
            this.btn_CalLoad.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.btn_CalLoad.CustomClickedGradientFirstColor = System.Drawing.Color.BlanchedAlmond;
            this.btn_CalLoad.CustomClickedGradientSecondColor = System.Drawing.Color.Gold;
            this.btn_CalLoad.Description = "";
            this.btn_CalLoad.DisabledColor = System.Drawing.Color.DarkGray;
            this.btn_CalLoad.EdgeRadius = 5;
            this.btn_CalLoad.GradientAngle = 60F;
            this.btn_CalLoad.GradientFirstColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_CalLoad.GradientSecondColor = System.Drawing.Color.SteelBlue;
            this.btn_CalLoad.HoverEmphasizeCustomColor = System.Drawing.Color.Firebrick;
            this.btn_CalLoad.ImagePosition = new System.Drawing.Point(1, 1);
            this.btn_CalLoad.ImageSize = new System.Drawing.Point(35, 35);
            this.btn_CalLoad.LoadImage = global::FrameOfSystem3.Properties.Resources.file_96px;
            this.btn_CalLoad.Location = new System.Drawing.Point(382, 88);
            this.btn_CalLoad.MainFont = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_CalLoad.MainFontColor = System.Drawing.Color.White;
            this.btn_CalLoad.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.btn_CalLoad.Name = "btn_CalLoad";
            this.btn_CalLoad.Size = new System.Drawing.Size(37, 37);
            this.btn_CalLoad.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.btn_CalLoad.SubFontColor = System.Drawing.Color.Black;
            this.btn_CalLoad.SubText = "";
            this.btn_CalLoad.TabIndex = 20824;
            this.btn_CalLoad.Tag = "";
            this.btn_CalLoad.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.btn_CalLoad.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.btn_CalLoad.ThemeIndex = 0;
            this.btn_CalLoad.UseBorder = true;
            this.btn_CalLoad.UseClickedEmphasizeTextColor = false;
            this.btn_CalLoad.UseCustomizeClickedColor = true;
            this.btn_CalLoad.UseEdge = true;
            this.btn_CalLoad.UseHoverEmphasizeCustomColor = true;
            this.btn_CalLoad.UseImage = true;
            this.btn_CalLoad.UserHoverEmpahsize = true;
            this.btn_CalLoad.UseSubFont = false;
            this.btn_CalLoad.Click += new System.EventHandler(this.Click_CalFileLoad);
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
            this.btn_Reset.EdgeRadius = 1;
            this.btn_Reset.GradientAngle = 90F;
            this.btn_Reset.GradientFirstColor = System.Drawing.Color.White;
            this.btn_Reset.GradientSecondColor = System.Drawing.Color.Silver;
            this.btn_Reset.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.btn_Reset.ImagePosition = new System.Drawing.Point(7, 7);
            this.btn_Reset.ImageSize = new System.Drawing.Point(30, 30);
            this.btn_Reset.LoadImage = global::FrameOfSystem3.Properties.Resources.CONFIG_ADD3;
            this.btn_Reset.Location = new System.Drawing.Point(862, 448);
            this.btn_Reset.MainFont = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.btn_Reset.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(131, 40);
            this.btn_Reset.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.btn_Reset.SubFontColor = System.Drawing.Color.DarkBlue;
            this.btn_Reset.SubText = "STATUS";
            this.btn_Reset.TabIndex = 0;
            this.btn_Reset.Text = "ALL RESET";
            this.btn_Reset.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.btn_Reset.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.btn_Reset.ThemeIndex = 0;
            this.btn_Reset.UseBorder = false;
            this.btn_Reset.UseClickedEmphasizeTextColor = false;
            this.btn_Reset.UseCustomizeClickedColor = false;
            this.btn_Reset.UseEdge = false;
            this.btn_Reset.UseHoverEmphasizeCustomColor = false;
            this.btn_Reset.UseImage = false;
            this.btn_Reset.UserHoverEmpahsize = true;
            this.btn_Reset.UseSubFont = false;
            this.btn_Reset.Click += new System.EventHandler(this.Cick_All_IO);
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
            this.sys3button1.EdgeRadius = 1;
            this.sys3button1.GradientAngle = 90F;
            this.sys3button1.GradientFirstColor = System.Drawing.Color.White;
            this.sys3button1.GradientSecondColor = System.Drawing.Color.Silver;
            this.sys3button1.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.sys3button1.ImagePosition = new System.Drawing.Point(7, 7);
            this.sys3button1.ImageSize = new System.Drawing.Point(30, 30);
            this.sys3button1.LoadImage = global::FrameOfSystem3.Properties.Resources.CONFIG_ADD3;
            this.sys3button1.Location = new System.Drawing.Point(996, 448);
            this.sys3button1.MainFont = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.sys3button1.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
            this.sys3button1.Name = "sys3button1";
            this.sys3button1.Size = new System.Drawing.Size(131, 40);
            this.sys3button1.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.sys3button1.SubFontColor = System.Drawing.Color.DarkBlue;
            this.sys3button1.SubText = "STATUS";
            this.sys3button1.TabIndex = 1;
            this.sys3button1.Text = "ALL EMO";
            this.sys3button1.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3button1.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.sys3button1.ThemeIndex = 0;
            this.sys3button1.UseBorder = false;
            this.sys3button1.UseClickedEmphasizeTextColor = false;
            this.sys3button1.UseCustomizeClickedColor = false;
            this.sys3button1.UseEdge = false;
            this.sys3button1.UseHoverEmphasizeCustomColor = false;
            this.sys3button1.UseImage = false;
            this.sys3button1.UserHoverEmpahsize = true;
            this.sys3button1.UseSubFont = false;
            this.sys3button1.Click += new System.EventHandler(this.Cick_All_IO);
            // 
            // sys3Label10
            // 
            this.sys3Label10.BackGroundColor = System.Drawing.Color.DarkGray;
            this.sys3Label10.BorderStroke = 2;
            this.sys3Label10.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.sys3Label10.Description = "";
            this.sys3Label10.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3Label10.EdgeRadius = 1;
            this.sys3Label10.ImagePosition = new System.Drawing.Point(0, 0);
            this.sys3Label10.ImageSize = new System.Drawing.Point(0, 0);
            this.sys3Label10.LoadImage = null;
            this.sys3Label10.Location = new System.Drawing.Point(562, 673);
            this.sys3Label10.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label10.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label10.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label10.Name = "sys3Label10";
            this.sys3Label10.Size = new System.Drawing.Size(72, 30);
            this.sys3Label10.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label10.SubFontColor = System.Drawing.Color.Gray;
            this.sys3Label10.SubText = "";
            this.sys3Label10.TabIndex = 20827;
            this.sys3Label10.Tag = "";
            this.sys3Label10.Text = "INPUT";
            this.sys3Label10.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3Label10.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.sys3Label10.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label10.ThemeIndex = 0;
            this.sys3Label10.UnitAreaRate = 30;
            this.sys3Label10.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label10.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sys3Label10.UnitPositionVertical = false;
            this.sys3Label10.UnitText = "";
            this.sys3Label10.UseBorder = true;
            this.sys3Label10.UseEdgeRadius = false;
            this.sys3Label10.UseImage = false;
            this.sys3Label10.UseSubFont = true;
            this.sys3Label10.UseUnitFont = false;
            // 
            // m_lblinputVolt
            // 
            this.m_lblinputVolt.BackGroundColor = System.Drawing.Color.DimGray;
            this.m_lblinputVolt.BorderStroke = 2;
            this.m_lblinputVolt.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.m_lblinputVolt.Description = "";
            this.m_lblinputVolt.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_lblinputVolt.EdgeRadius = 1;
            this.m_lblinputVolt.ImagePosition = new System.Drawing.Point(0, 0);
            this.m_lblinputVolt.ImageSize = new System.Drawing.Point(0, 0);
            this.m_lblinputVolt.LoadImage = null;
            this.m_lblinputVolt.Location = new System.Drawing.Point(635, 673);
            this.m_lblinputVolt.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_lblinputVolt.MainFontColor = System.Drawing.Color.White;
            this.m_lblinputVolt.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.m_lblinputVolt.Name = "m_lblinputVolt";
            this.m_lblinputVolt.Size = new System.Drawing.Size(89, 30);
            this.m_lblinputVolt.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblinputVolt.SubFontColor = System.Drawing.Color.Gray;
            this.m_lblinputVolt.SubText = "";
            this.m_lblinputVolt.TabIndex = 20831;
            this.m_lblinputVolt.Tag = "";
            this.m_lblinputVolt.Text = "9999.9";
            this.m_lblinputVolt.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblinputVolt.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.m_lblinputVolt.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_lblinputVolt.ThemeIndex = 0;
            this.m_lblinputVolt.UnitAreaRate = 30;
            this.m_lblinputVolt.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.m_lblinputVolt.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_lblinputVolt.UnitPositionVertical = false;
            this.m_lblinputVolt.UnitText = "V";
            this.m_lblinputVolt.UseBorder = true;
            this.m_lblinputVolt.UseEdgeRadius = false;
            this.m_lblinputVolt.UseImage = false;
            this.m_lblinputVolt.UseSubFont = true;
            this.m_lblinputVolt.UseUnitFont = true;
            // 
            // sys3button3
            // 
            this.sys3button3.BorderWidth = 5;
            this.sys3button3.ButtonClicked = false;
            this.sys3button3.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.sys3button3.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.sys3button3.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.sys3button3.Description = "";
            this.sys3button3.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3button3.EdgeRadius = 5;
            this.sys3button3.GradientAngle = 60F;
            this.sys3button3.GradientFirstColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(230)))), ((int)(((byte)(115)))));
            this.sys3button3.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(135)))), ((int)(((byte)(20)))));
            this.sys3button3.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.sys3button3.ImagePosition = new System.Drawing.Point(37, 25);
            this.sys3button3.ImageSize = new System.Drawing.Point(30, 30);
            this.sys3button3.LoadImage = null;
            this.sys3button3.Location = new System.Drawing.Point(907, 700);
            this.sys3button3.MainFont = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sys3button3.MainFontColor = System.Drawing.Color.White;
            this.sys3button3.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3button3.Name = "sys3button3";
            this.sys3button3.Size = new System.Drawing.Size(222, 63);
            this.sys3button3.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.sys3button3.SubFontColor = System.Drawing.Color.Black;
            this.sys3button3.SubText = "";
            this.sys3button3.TabIndex = 3;
            this.sys3button3.Tag = "";
            this.sys3button3.Text = "SHORT TEST";
            this.sys3button3.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3button3.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3button3.ThemeIndex = 0;
            this.sys3button3.UseBorder = true;
            this.sys3button3.UseClickedEmphasizeTextColor = false;
            this.sys3button3.UseCustomizeClickedColor = false;
            this.sys3button3.UseEdge = true;
            this.sys3button3.UseHoverEmphasizeCustomColor = false;
            this.sys3button3.UseImage = true;
            this.sys3button3.UserHoverEmpahsize = false;
            this.sys3button3.UseSubFont = false;
            this.sys3button3.Click += new System.EventHandler(this.Click_Action);
            // 
            // gridVeiwControl_Cylinder_Device
            // 
            this.gridVeiwControl_Cylinder_Device.Control_Enable = true;
            this.gridVeiwControl_Cylinder_Device.controlCollection = null;
            this.gridVeiwControl_Cylinder_Device.Location = new System.Drawing.Point(422, 466);
            this.gridVeiwControl_Cylinder_Device.Name = "gridVeiwControl_Cylinder_Device";
            this.gridVeiwControl_Cylinder_Device.Size = new System.Drawing.Size(224, 28);
            this.gridVeiwControl_Cylinder_Device.TabIndex = 20859;
            // 
            // Equipment_Laser
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.gridVeiwControl_Cylinder_Device);
            this.Controls.Add(this.sys3button1);
            this.Controls.Add(this.btn_Reset);
            this.Controls.Add(this.gridVeiwControl_Device);
            this.Controls.Add(this.m_btnStop);
            this.Controls.Add(this.sys3button2);
            this.Controls.Add(this.sys3button3);
            this.Controls.Add(this.sys3button7);
            this.Controls.Add(this.m_btnRun);
            this.Controls.Add(this.gridViewControl_Power_Measure_Parameter);
            this.Controls.Add(this.gridViewControl_Enable_Parameter);
            this.Controls.Add(this.gridViewControl_Position_Parameter);
            this.Controls.Add(this.sys3Label48);
            this.Controls.Add(this.m_lblCalVolt);
            this.Controls.Add(this.m_lblCalStep);
            this.Controls.Add(this.m_lblCalChannel);
            this.Controls.Add(this.m_lblRestTime);
            this.Controls.Add(this.m_lblRepeatAvg);
            this.Controls.Add(this.m_lblRepeatCount);
            this.Controls.Add(this.m_lblinputVolt);
            this.Controls.Add(this.m_lblAvgValue);
            this.Controls.Add(this.m_lblMaxValue);
            this.Controls.Add(this.m_lblAlarmCodeMonitor);
            this.Controls.Add(this.m_lblAlarmCodePort3);
            this.Controls.Add(this.m_lblAlarmCodePort2);
            this.Controls.Add(this.m_lblAlarmCodePort1);
            this.Controls.Add(this.sys3Label12);
            this.Controls.Add(this.m_lblLastValue);
            this.Controls.Add(this.sys3Label7);
            this.Controls.Add(this.m_lblMinValue);
            this.Controls.Add(this.sys3Label11);
            this.Controls.Add(this.sys3Label6);
            this.Controls.Add(this.sys3Label5);
            this.Controls.Add(this.sys3Label8);
            this.Controls.Add(this.sys3Label9);
            this.Controls.Add(this.sys3Label10);
            this.Controls.Add(this.sys3Label4);
            this.Controls.Add(this.sys3Label25);
            this.Controls.Add(this.sys3Label16);
            this.Controls.Add(this.sys3Label50);
            this.Controls.Add(this.m_ZedGraph);
            this.Controls.Add(this.sys3GroupBox2);
            this.Controls.Add(this.m_lblCalFileName);
            this.Controls.Add(this.btn_CalLoad);
            this.Controls.Add(this.sys3Label2);
            this.Controls.Add(this.sys3Label17);
            this.Controls.Add(this.sys3Label14);
            this.Controls.Add(this.sys3Label13);
            this.Controls.Add(this.sys3Label3);
            this.Controls.Add(this.sys3Label1);
            this.Controls.Add(this.ComboBox_Channel);
            this.Controls.Add(this.m_dgViewCalibration);
            this.Controls.Add(this.sys3GroupBox3);
            this.Controls.Add(this.sys3GroupBox1);
            this.Name = "Equipment_Laser";
            this.Size = new System.Drawing.Size(1136, 849);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgViewCalibration)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sys3Controls.Sys3GroupBox sys3GroupBox1;
        private System.Windows.Forms.ComboBox ComboBox_Channel;
        private Sys3Controls.Sys3DoubleBufferedDataGridView m_dgViewCalibration;
        private Sys3Controls.Sys3Label sys3Label1;
        private Sys3Controls.Sys3button btn_CalLoad;
        private Sys3Controls.Sys3Label m_lblCalFileName;
        private Sys3Controls.Sys3Label sys3Label3;
        private Sys3Controls.Sys3Label m_lblAvgValue;
        private Sys3Controls.Sys3Label m_lblMaxValue;
        private Sys3Controls.Sys3Label m_lblLastValue;
        private Sys3Controls.Sys3Label m_lblMinValue;
        private Sys3Controls.Sys3Label sys3Label25;
        private Sys3Controls.Sys3Label sys3Label16;
        private Sys3Controls.Sys3Label sys3Label50;
        private ZedGraph.ZedGraphControl m_ZedGraph;
        private Sys3Controls.Sys3GroupBox sys3GroupBox2;
        private Sys3Controls.Sys3Label sys3Label48;
        private Sys3Controls.Sys3Label sys3Label4;
        private Sys3Controls.Sys3Label m_lblRepeatCount;
        private Component.GridViewControl_2Axis_Position_Parameter gridViewControl_Position_Parameter;
        private Component.GridViewControl_Parameter gridViewControl_Enable_Parameter;
        private Component.GridViewControl_Parameter gridViewControl_Power_Measure_Parameter;
        private Sys3Controls.Sys3button m_btnStop;
        private Sys3Controls.Sys3button sys3button2;
        private Sys3Controls.Sys3button sys3button7;
        private Sys3Controls.Sys3button m_btnRun;
        private Sys3Controls.Sys3Label sys3Label6;
        private Sys3Controls.Sys3Label m_lblRestTime;
        private Sys3Controls.Sys3Label sys3Label8;
        private Sys3Controls.Sys3Label sys3Label9;
        private Sys3Controls.Sys3Label m_lblRepeatAvg;
        private Sys3Controls.Sys3Label sys3Label11;
        private Sys3Controls.Sys3Label m_lblCalChannel;
        private Component.GridVeiwControl_Device gridVeiwControl_Device;
        private Sys3Controls.Sys3Label sys3Label13;
        private Sys3Controls.Sys3Label m_lblAlarmCodePort1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn OutputVolt;
        private System.Windows.Forms.DataGridViewTextBoxColumn InputVolt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Watt;
        private Sys3Controls.Sys3Label sys3Label5;
        private Sys3Controls.Sys3Label sys3Label7;
        private Sys3Controls.Sys3Label m_lblCalStep;
        private Sys3Controls.Sys3Label sys3Label12;
        private Sys3Controls.Sys3Label m_lblCalVolt;
        private Sys3Controls.Sys3GroupBox sys3GroupBox3;
        private Sys3Controls.Sys3Label sys3Label2;
        private Sys3Controls.Sys3Label m_lblAlarmCodeMonitor;
        private Sys3Controls.Sys3Label sys3Label14;
        private Sys3Controls.Sys3Label m_lblAlarmCodePort2;
        private Sys3Controls.Sys3Label sys3Label17;
        private Sys3Controls.Sys3Label m_lblAlarmCodePort3;
        private Sys3Controls.Sys3button btn_Reset;
        private Sys3Controls.Sys3button sys3button1;
        private Sys3Controls.Sys3Label sys3Label10;
        private Sys3Controls.Sys3Label m_lblinputVolt;
        private Sys3Controls.Sys3button sys3button3;
        private Component.GridVeiwControl_Device gridVeiwControl_Cylinder_Device;


    }
}
