namespace FrameOfSystem3.Views.Setup.Equipment
{
    partial class Equipment_EFEMComm
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
            this.sys3GroupBox1 = new Sys3Controls.Sys3GroupBox();
            this.sys3Label4 = new Sys3Controls.Sys3Label();
            this.lbl_PreEqHostStatus = new Sys3Controls.Sys3Label();
            this.sys3GroupBox4 = new Sys3Controls.Sys3GroupBox();
            this.btn_ClearLog = new Sys3Controls.Sys3button();
            this.m_listMessage = new System.Windows.Forms.ListBox();
            this.lbl_PreEqConnectStatus = new Sys3Controls.Sys3Label();
            this.sys3Label2 = new Sys3Controls.Sys3Label();
            this.sys3button1 = new Sys3Controls.Sys3button();
            this.sys3button2 = new Sys3Controls.Sys3button();
            this.sys3button3 = new Sys3Controls.Sys3button();
            this.sys3button4 = new Sys3Controls.Sys3button();
            this.lbl_RecipeDownload = new Sys3Controls.Sys3button();
            this.lbl_RecipeUpload = new Sys3Controls.Sys3button();
            this.sys3Label14 = new Sys3Controls.Sys3Label();
            this.sys3Label7 = new Sys3Controls.Sys3Label();
            this.lbl_TargetCeid = new Sys3Controls.Sys3Label();
            this.sys3button5 = new Sys3Controls.Sys3button();
            this.sys3Label11 = new Sys3Controls.Sys3Label();
            this.btn_SendEfemMessage_Front = new Sys3Controls.Sys3button();
            this.gridViewControl_Pre_Equip_Parameter = new FrameOfSystem3.Component.GridViewControl_Parameter();
            this.sys3button6 = new Sys3Controls.Sys3button();
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
            this.sys3GroupBox1.Location = new System.Drawing.Point(-1, -1);
            this.sys3GroupBox1.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3GroupBox1.Name = "sys3GroupBox1";
            this.sys3GroupBox1.Size = new System.Drawing.Size(1135, 238);
            this.sys3GroupBox1.TabIndex = 20683;
            this.sys3GroupBox1.Tag = "";
            this.sys3GroupBox1.Text = "EFEM";
            this.sys3GroupBox1.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3GroupBox1.ThemeIndex = 0;
            this.sys3GroupBox1.UseLabelBorder = true;
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
            this.sys3Label4.Location = new System.Drawing.Point(348, 31);
            this.sys3Label4.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label4.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label4.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label4.Name = "sys3Label4";
            this.sys3Label4.Size = new System.Drawing.Size(160, 30);
            this.sys3Label4.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label4.SubFontColor = System.Drawing.Color.Gray;
            this.sys3Label4.SubText = "";
            this.sys3Label4.TabIndex = 20832;
            this.sys3Label4.Text = "HOST STATE";
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
            // lbl_PreEqHostStatus
            // 
            this.lbl_PreEqHostStatus.BackGroundColor = System.Drawing.Color.Silver;
            this.lbl_PreEqHostStatus.BorderStroke = 2;
            this.lbl_PreEqHostStatus.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.lbl_PreEqHostStatus.Description = "";
            this.lbl_PreEqHostStatus.DisabledColor = System.Drawing.Color.LightGray;
            this.lbl_PreEqHostStatus.EdgeRadius = 1;
            this.lbl_PreEqHostStatus.Enabled = false;
            this.lbl_PreEqHostStatus.ImagePosition = new System.Drawing.Point(0, 0);
            this.lbl_PreEqHostStatus.ImageSize = new System.Drawing.Point(0, 0);
            this.lbl_PreEqHostStatus.LoadImage = null;
            this.lbl_PreEqHostStatus.Location = new System.Drawing.Point(509, 31);
            this.lbl_PreEqHostStatus.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lbl_PreEqHostStatus.MainFontColor = System.Drawing.Color.Black;
            this.lbl_PreEqHostStatus.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.lbl_PreEqHostStatus.Name = "lbl_PreEqHostStatus";
            this.lbl_PreEqHostStatus.Size = new System.Drawing.Size(180, 30);
            this.lbl_PreEqHostStatus.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.lbl_PreEqHostStatus.SubFontColor = System.Drawing.Color.Black;
            this.lbl_PreEqHostStatus.SubText = "";
            this.lbl_PreEqHostStatus.TabIndex = 20831;
            this.lbl_PreEqHostStatus.Text = "--";
            this.lbl_PreEqHostStatus.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
            this.lbl_PreEqHostStatus.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.lbl_PreEqHostStatus.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.lbl_PreEqHostStatus.ThemeIndex = 0;
            this.lbl_PreEqHostStatus.UnitAreaRate = 30;
            this.lbl_PreEqHostStatus.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_PreEqHostStatus.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbl_PreEqHostStatus.UnitPositionVertical = false;
            this.lbl_PreEqHostStatus.UnitText = "";
            this.lbl_PreEqHostStatus.UseBorder = true;
            this.lbl_PreEqHostStatus.UseEdgeRadius = false;
            this.lbl_PreEqHostStatus.UseImage = false;
            this.lbl_PreEqHostStatus.UseSubFont = false;
            this.lbl_PreEqHostStatus.UseUnitFont = false;
            // 
            // sys3GroupBox4
            // 
            this.sys3GroupBox4.BackGroundColor = System.Drawing.Color.WhiteSmoke;
            this.sys3GroupBox4.EdgeBorderStroke = 2;
            this.sys3GroupBox4.EdgeRadius = 2;
            this.sys3GroupBox4.LabelFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3GroupBox4.LabelGradientColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.sys3GroupBox4.LabelGradientColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.sys3GroupBox4.LabelHeight = 30;
            this.sys3GroupBox4.LabelTextColor = System.Drawing.Color.Black;
            this.sys3GroupBox4.Location = new System.Drawing.Point(-2, 238);
            this.sys3GroupBox4.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3GroupBox4.Name = "sys3GroupBox4";
            this.sys3GroupBox4.Size = new System.Drawing.Size(1138, 426);
            this.sys3GroupBox4.TabIndex = 20683;
            this.sys3GroupBox4.Tag = "";
            this.sys3GroupBox4.Text = "LOG";
            this.sys3GroupBox4.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3GroupBox4.ThemeIndex = 0;
            this.sys3GroupBox4.UseLabelBorder = true;
            // 
            // btn_ClearLog
            // 
            this.btn_ClearLog.BorderWidth = 2;
            this.btn_ClearLog.ButtonClicked = false;
            this.btn_ClearLog.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.btn_ClearLog.CustomClickedGradientFirstColor = System.Drawing.Color.BlanchedAlmond;
            this.btn_ClearLog.CustomClickedGradientSecondColor = System.Drawing.Color.Gold;
            this.btn_ClearLog.Description = "";
            this.btn_ClearLog.DisabledColor = System.Drawing.Color.DarkGray;
            this.btn_ClearLog.EdgeRadius = 5;
            this.btn_ClearLog.GradientAngle = 60F;
            this.btn_ClearLog.GradientFirstColor = System.Drawing.Color.Silver;
            this.btn_ClearLog.GradientSecondColor = System.Drawing.Color.Gray;
            this.btn_ClearLog.HoverEmphasizeCustomColor = System.Drawing.Color.Firebrick;
            this.btn_ClearLog.ImagePosition = new System.Drawing.Point(7, 5);
            this.btn_ClearLog.ImageSize = new System.Drawing.Point(30, 30);
            this.btn_ClearLog.LoadImage = global::FrameOfSystem3.Properties.Resources.empty_trash_52px;
            this.btn_ClearLog.Location = new System.Drawing.Point(995, 270);
            this.btn_ClearLog.MainFont = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.btn_ClearLog.MainFontColor = System.Drawing.Color.White;
            this.btn_ClearLog.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.btn_ClearLog.Name = "btn_ClearLog";
            this.btn_ClearLog.Size = new System.Drawing.Size(138, 44);
            this.btn_ClearLog.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.btn_ClearLog.SubFontColor = System.Drawing.Color.DarkBlue;
            this.btn_ClearLog.SubText = "STATUS";
            this.btn_ClearLog.TabIndex = 20842;
            this.btn_ClearLog.Text = "CLEAR";
            this.btn_ClearLog.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.btn_ClearLog.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.btn_ClearLog.ThemeIndex = 0;
            this.btn_ClearLog.UseBorder = true;
            this.btn_ClearLog.UseClickedEmphasizeTextColor = false;
            this.btn_ClearLog.UseCustomizeClickedColor = true;
            this.btn_ClearLog.UseEdge = true;
            this.btn_ClearLog.UseHoverEmphasizeCustomColor = true;
            this.btn_ClearLog.UseImage = true;
            this.btn_ClearLog.UserHoverEmpahsize = true;
            this.btn_ClearLog.UseSubFont = false;
            this.btn_ClearLog.Click += new System.EventHandler(this.ClearLog);
            // 
            // m_listMessage
            // 
            this.m_listMessage.BackColor = System.Drawing.Color.Gainsboro;
            this.m_listMessage.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.m_listMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.m_listMessage.FormattingEnabled = true;
            this.m_listMessage.HorizontalScrollbar = true;
            this.m_listMessage.ItemHeight = 17;
            this.m_listMessage.Location = new System.Drawing.Point(2, 317);
            this.m_listMessage.Name = "m_listMessage";
            this.m_listMessage.ScrollAlwaysVisible = true;
            this.m_listMessage.Size = new System.Drawing.Size(1131, 344);
            this.m_listMessage.TabIndex = 20843;
            this.m_listMessage.UseTabStops = false;
            // 
            // lbl_PreEqConnectStatus
            // 
            this.lbl_PreEqConnectStatus.BackGroundColor = System.Drawing.Color.Silver;
            this.lbl_PreEqConnectStatus.BorderStroke = 2;
            this.lbl_PreEqConnectStatus.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.lbl_PreEqConnectStatus.Description = "";
            this.lbl_PreEqConnectStatus.DisabledColor = System.Drawing.Color.LightGray;
            this.lbl_PreEqConnectStatus.EdgeRadius = 1;
            this.lbl_PreEqConnectStatus.Enabled = false;
            this.lbl_PreEqConnectStatus.ImagePosition = new System.Drawing.Point(0, 0);
            this.lbl_PreEqConnectStatus.ImageSize = new System.Drawing.Point(0, 0);
            this.lbl_PreEqConnectStatus.LoadImage = null;
            this.lbl_PreEqConnectStatus.Location = new System.Drawing.Point(509, 62);
            this.lbl_PreEqConnectStatus.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lbl_PreEqConnectStatus.MainFontColor = System.Drawing.Color.Black;
            this.lbl_PreEqConnectStatus.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.lbl_PreEqConnectStatus.Name = "lbl_PreEqConnectStatus";
            this.lbl_PreEqConnectStatus.Size = new System.Drawing.Size(180, 30);
            this.lbl_PreEqConnectStatus.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.lbl_PreEqConnectStatus.SubFontColor = System.Drawing.Color.Black;
            this.lbl_PreEqConnectStatus.SubText = "";
            this.lbl_PreEqConnectStatus.TabIndex = 20831;
            this.lbl_PreEqConnectStatus.Text = "--";
            this.lbl_PreEqConnectStatus.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
            this.lbl_PreEqConnectStatus.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.lbl_PreEqConnectStatus.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.lbl_PreEqConnectStatus.ThemeIndex = 0;
            this.lbl_PreEqConnectStatus.UnitAreaRate = 30;
            this.lbl_PreEqConnectStatus.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_PreEqConnectStatus.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbl_PreEqConnectStatus.UnitPositionVertical = false;
            this.lbl_PreEqConnectStatus.UnitText = "";
            this.lbl_PreEqConnectStatus.UseBorder = true;
            this.lbl_PreEqConnectStatus.UseEdgeRadius = false;
            this.lbl_PreEqConnectStatus.UseImage = false;
            this.lbl_PreEqConnectStatus.UseSubFont = false;
            this.lbl_PreEqConnectStatus.UseUnitFont = false;
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
            this.sys3Label2.Location = new System.Drawing.Point(348, 62);
            this.sys3Label2.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label2.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label2.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label2.Name = "sys3Label2";
            this.sys3Label2.Size = new System.Drawing.Size(160, 30);
            this.sys3Label2.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label2.SubFontColor = System.Drawing.Color.Gray;
            this.sys3Label2.SubText = "";
            this.sys3Label2.TabIndex = 20832;
            this.sys3Label2.Text = "CONNECT STATE";
            this.sys3Label2.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3Label2.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.sys3Label2.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label2.ThemeIndex = 0;
            this.sys3Label2.UnitAreaRate = 30;
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
            // sys3button1
            // 
            this.sys3button1.BorderWidth = 2;
            this.sys3button1.ButtonClicked = false;
            this.sys3button1.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.sys3button1.CustomClickedGradientFirstColor = System.Drawing.Color.BlanchedAlmond;
            this.sys3button1.CustomClickedGradientSecondColor = System.Drawing.Color.Gold;
            this.sys3button1.Description = "";
            this.sys3button1.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3button1.EdgeRadius = 5;
            this.sys3button1.GradientAngle = 60F;
            this.sys3button1.GradientFirstColor = System.Drawing.Color.Silver;
            this.sys3button1.GradientSecondColor = System.Drawing.Color.Gray;
            this.sys3button1.HoverEmphasizeCustomColor = System.Drawing.Color.Firebrick;
            this.sys3button1.ImagePosition = new System.Drawing.Point(7, 5);
            this.sys3button1.ImageSize = new System.Drawing.Point(30, 30);
            this.sys3button1.LoadImage = null;
            this.sys3button1.Location = new System.Drawing.Point(690, 31);
            this.sys3button1.MainFont = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.sys3button1.MainFontColor = System.Drawing.Color.White;
            this.sys3button1.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3button1.Name = "sys3button1";
            this.sys3button1.Size = new System.Drawing.Size(125, 30);
            this.sys3button1.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.sys3button1.SubFontColor = System.Drawing.Color.DarkBlue;
            this.sys3button1.SubText = "STATUS";
            this.sys3button1.TabIndex = 0;
            this.sys3button1.Text = "OPEN";
            this.sys3button1.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3button1.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3button1.ThemeIndex = 0;
            this.sys3button1.UseBorder = true;
            this.sys3button1.UseClickedEmphasizeTextColor = false;
            this.sys3button1.UseCustomizeClickedColor = true;
            this.sys3button1.UseEdge = true;
            this.sys3button1.UseHoverEmphasizeCustomColor = true;
            this.sys3button1.UseImage = true;
            this.sys3button1.UserHoverEmpahsize = true;
            this.sys3button1.UseSubFont = false;
            this.sys3button1.Click += new System.EventHandler(this.Click_Conection);
            // 
            // sys3button2
            // 
            this.sys3button2.BorderWidth = 2;
            this.sys3button2.ButtonClicked = false;
            this.sys3button2.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.sys3button2.CustomClickedGradientFirstColor = System.Drawing.Color.BlanchedAlmond;
            this.sys3button2.CustomClickedGradientSecondColor = System.Drawing.Color.Gold;
            this.sys3button2.Description = "";
            this.sys3button2.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3button2.EdgeRadius = 5;
            this.sys3button2.GradientAngle = 60F;
            this.sys3button2.GradientFirstColor = System.Drawing.Color.Silver;
            this.sys3button2.GradientSecondColor = System.Drawing.Color.Gray;
            this.sys3button2.HoverEmphasizeCustomColor = System.Drawing.Color.Firebrick;
            this.sys3button2.ImagePosition = new System.Drawing.Point(7, 5);
            this.sys3button2.ImageSize = new System.Drawing.Point(30, 30);
            this.sys3button2.LoadImage = null;
            this.sys3button2.Location = new System.Drawing.Point(816, 31);
            this.sys3button2.MainFont = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.sys3button2.MainFontColor = System.Drawing.Color.White;
            this.sys3button2.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3button2.Name = "sys3button2";
            this.sys3button2.Size = new System.Drawing.Size(125, 30);
            this.sys3button2.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.sys3button2.SubFontColor = System.Drawing.Color.DarkBlue;
            this.sys3button2.SubText = "STATUS";
            this.sys3button2.TabIndex = 1;
            this.sys3button2.Text = "CLOSE";
            this.sys3button2.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3button2.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3button2.ThemeIndex = 0;
            this.sys3button2.UseBorder = true;
            this.sys3button2.UseClickedEmphasizeTextColor = false;
            this.sys3button2.UseCustomizeClickedColor = true;
            this.sys3button2.UseEdge = true;
            this.sys3button2.UseHoverEmphasizeCustomColor = true;
            this.sys3button2.UseImage = true;
            this.sys3button2.UserHoverEmpahsize = true;
            this.sys3button2.UseSubFont = false;
            this.sys3button2.Click += new System.EventHandler(this.Click_Conection);
            // 
            // sys3button3
            // 
            this.sys3button3.BorderWidth = 2;
            this.sys3button3.ButtonClicked = false;
            this.sys3button3.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.sys3button3.CustomClickedGradientFirstColor = System.Drawing.Color.BlanchedAlmond;
            this.sys3button3.CustomClickedGradientSecondColor = System.Drawing.Color.Gold;
            this.sys3button3.Description = "";
            this.sys3button3.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3button3.EdgeRadius = 5;
            this.sys3button3.GradientAngle = 60F;
            this.sys3button3.GradientFirstColor = System.Drawing.Color.Silver;
            this.sys3button3.GradientSecondColor = System.Drawing.Color.Gray;
            this.sys3button3.HoverEmphasizeCustomColor = System.Drawing.Color.Firebrick;
            this.sys3button3.ImagePosition = new System.Drawing.Point(7, 5);
            this.sys3button3.ImageSize = new System.Drawing.Point(30, 30);
            this.sys3button3.LoadImage = null;
            this.sys3button3.Location = new System.Drawing.Point(690, 62);
            this.sys3button3.MainFont = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.sys3button3.MainFontColor = System.Drawing.Color.White;
            this.sys3button3.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3button3.Name = "sys3button3";
            this.sys3button3.Size = new System.Drawing.Size(125, 30);
            this.sys3button3.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.sys3button3.SubFontColor = System.Drawing.Color.DarkBlue;
            this.sys3button3.SubText = "STATUS";
            this.sys3button3.TabIndex = 2;
            this.sys3button3.Text = "CONNECT";
            this.sys3button3.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3button3.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3button3.ThemeIndex = 0;
            this.sys3button3.UseBorder = true;
            this.sys3button3.UseClickedEmphasizeTextColor = false;
            this.sys3button3.UseCustomizeClickedColor = true;
            this.sys3button3.UseEdge = true;
            this.sys3button3.UseHoverEmphasizeCustomColor = true;
            this.sys3button3.UseImage = true;
            this.sys3button3.UserHoverEmpahsize = true;
            this.sys3button3.UseSubFont = false;
            this.sys3button3.Click += new System.EventHandler(this.Click_Conection);
            // 
            // sys3button4
            // 
            this.sys3button4.BorderWidth = 2;
            this.sys3button4.ButtonClicked = false;
            this.sys3button4.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.sys3button4.CustomClickedGradientFirstColor = System.Drawing.Color.BlanchedAlmond;
            this.sys3button4.CustomClickedGradientSecondColor = System.Drawing.Color.Gold;
            this.sys3button4.Description = "";
            this.sys3button4.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3button4.EdgeRadius = 5;
            this.sys3button4.GradientAngle = 60F;
            this.sys3button4.GradientFirstColor = System.Drawing.Color.Silver;
            this.sys3button4.GradientSecondColor = System.Drawing.Color.Gray;
            this.sys3button4.HoverEmphasizeCustomColor = System.Drawing.Color.Firebrick;
            this.sys3button4.ImagePosition = new System.Drawing.Point(7, 5);
            this.sys3button4.ImageSize = new System.Drawing.Point(30, 30);
            this.sys3button4.LoadImage = null;
            this.sys3button4.Location = new System.Drawing.Point(816, 62);
            this.sys3button4.MainFont = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.sys3button4.MainFontColor = System.Drawing.Color.White;
            this.sys3button4.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3button4.Name = "sys3button4";
            this.sys3button4.Size = new System.Drawing.Size(125, 30);
            this.sys3button4.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.sys3button4.SubFontColor = System.Drawing.Color.DarkBlue;
            this.sys3button4.SubText = "STATUS";
            this.sys3button4.TabIndex = 3;
            this.sys3button4.Text = "DISCONNECT";
            this.sys3button4.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3button4.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3button4.ThemeIndex = 0;
            this.sys3button4.UseBorder = true;
            this.sys3button4.UseClickedEmphasizeTextColor = false;
            this.sys3button4.UseCustomizeClickedColor = true;
            this.sys3button4.UseEdge = true;
            this.sys3button4.UseHoverEmphasizeCustomColor = true;
            this.sys3button4.UseImage = true;
            this.sys3button4.UserHoverEmpahsize = true;
            this.sys3button4.UseSubFont = false;
            this.sys3button4.Click += new System.EventHandler(this.Click_Conection);
            // 
            // lbl_RecipeDownload
            // 
            this.lbl_RecipeDownload.BorderWidth = 2;
            this.lbl_RecipeDownload.ButtonClicked = false;
            this.lbl_RecipeDownload.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.lbl_RecipeDownload.CustomClickedGradientFirstColor = System.Drawing.Color.BlanchedAlmond;
            this.lbl_RecipeDownload.CustomClickedGradientSecondColor = System.Drawing.Color.Gold;
            this.lbl_RecipeDownload.Description = "";
            this.lbl_RecipeDownload.DisabledColor = System.Drawing.Color.DarkGray;
            this.lbl_RecipeDownload.EdgeRadius = 5;
            this.lbl_RecipeDownload.GradientAngle = 60F;
            this.lbl_RecipeDownload.GradientFirstColor = System.Drawing.Color.Silver;
            this.lbl_RecipeDownload.GradientSecondColor = System.Drawing.Color.Gray;
            this.lbl_RecipeDownload.HoverEmphasizeCustomColor = System.Drawing.Color.Firebrick;
            this.lbl_RecipeDownload.ImagePosition = new System.Drawing.Point(7, 5);
            this.lbl_RecipeDownload.ImageSize = new System.Drawing.Point(30, 30);
            this.lbl_RecipeDownload.LoadImage = null;
            this.lbl_RecipeDownload.Location = new System.Drawing.Point(486, 198);
            this.lbl_RecipeDownload.MainFont = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_RecipeDownload.MainFontColor = System.Drawing.Color.White;
            this.lbl_RecipeDownload.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.lbl_RecipeDownload.Name = "lbl_RecipeDownload";
            this.lbl_RecipeDownload.Size = new System.Drawing.Size(150, 30);
            this.lbl_RecipeDownload.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.lbl_RecipeDownload.SubFontColor = System.Drawing.Color.DarkBlue;
            this.lbl_RecipeDownload.SubText = "STATUS";
            this.lbl_RecipeDownload.TabIndex = 20857;
            this.lbl_RecipeDownload.Text = "DOWNLOAD";
            this.lbl_RecipeDownload.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.lbl_RecipeDownload.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.lbl_RecipeDownload.ThemeIndex = 0;
            this.lbl_RecipeDownload.UseBorder = true;
            this.lbl_RecipeDownload.UseClickedEmphasizeTextColor = false;
            this.lbl_RecipeDownload.UseCustomizeClickedColor = true;
            this.lbl_RecipeDownload.UseEdge = true;
            this.lbl_RecipeDownload.UseHoverEmphasizeCustomColor = true;
            this.lbl_RecipeDownload.UseImage = true;
            this.lbl_RecipeDownload.UserHoverEmpahsize = true;
            this.lbl_RecipeDownload.UseSubFont = false;
            this.lbl_RecipeDownload.Click += new System.EventHandler(this.Click_RmsTest);
            // 
            // lbl_RecipeUpload
            // 
            this.lbl_RecipeUpload.BorderWidth = 2;
            this.lbl_RecipeUpload.ButtonClicked = false;
            this.lbl_RecipeUpload.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.lbl_RecipeUpload.CustomClickedGradientFirstColor = System.Drawing.Color.BlanchedAlmond;
            this.lbl_RecipeUpload.CustomClickedGradientSecondColor = System.Drawing.Color.Gold;
            this.lbl_RecipeUpload.Description = "";
            this.lbl_RecipeUpload.DisabledColor = System.Drawing.Color.DarkGray;
            this.lbl_RecipeUpload.EdgeRadius = 5;
            this.lbl_RecipeUpload.GradientAngle = 60F;
            this.lbl_RecipeUpload.GradientFirstColor = System.Drawing.Color.Silver;
            this.lbl_RecipeUpload.GradientSecondColor = System.Drawing.Color.Gray;
            this.lbl_RecipeUpload.HoverEmphasizeCustomColor = System.Drawing.Color.Firebrick;
            this.lbl_RecipeUpload.ImagePosition = new System.Drawing.Point(7, 5);
            this.lbl_RecipeUpload.ImageSize = new System.Drawing.Point(30, 30);
            this.lbl_RecipeUpload.LoadImage = null;
            this.lbl_RecipeUpload.Location = new System.Drawing.Point(637, 198);
            this.lbl_RecipeUpload.MainFont = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_RecipeUpload.MainFontColor = System.Drawing.Color.White;
            this.lbl_RecipeUpload.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.lbl_RecipeUpload.Name = "lbl_RecipeUpload";
            this.lbl_RecipeUpload.Size = new System.Drawing.Size(150, 30);
            this.lbl_RecipeUpload.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.lbl_RecipeUpload.SubFontColor = System.Drawing.Color.DarkBlue;
            this.lbl_RecipeUpload.SubText = "STATUS";
            this.lbl_RecipeUpload.TabIndex = 20856;
            this.lbl_RecipeUpload.Text = "UPLOAD";
            this.lbl_RecipeUpload.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.lbl_RecipeUpload.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.lbl_RecipeUpload.ThemeIndex = 0;
            this.lbl_RecipeUpload.UseBorder = true;
            this.lbl_RecipeUpload.UseClickedEmphasizeTextColor = false;
            this.lbl_RecipeUpload.UseCustomizeClickedColor = true;
            this.lbl_RecipeUpload.UseEdge = true;
            this.lbl_RecipeUpload.UseHoverEmphasizeCustomColor = true;
            this.lbl_RecipeUpload.UseImage = true;
            this.lbl_RecipeUpload.UserHoverEmpahsize = true;
            this.lbl_RecipeUpload.UseSubFont = false;
            this.lbl_RecipeUpload.Click += new System.EventHandler(this.Click_RmsTest);
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
            this.sys3Label14.Location = new System.Drawing.Point(348, 198);
            this.sys3Label14.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label14.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label14.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label14.Name = "sys3Label14";
            this.sys3Label14.Size = new System.Drawing.Size(137, 30);
            this.sys3Label14.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label14.SubFontColor = System.Drawing.Color.Gray;
            this.sys3Label14.SubText = "";
            this.sys3Label14.TabIndex = 20855;
            this.sys3Label14.Text = "RMS";
            this.sys3Label14.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3Label14.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.sys3Label14.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.sys3Label14.ThemeIndex = 0;
            this.sys3Label14.UnitAreaRate = 30;
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
            this.sys3Label7.Location = new System.Drawing.Point(348, 167);
            this.sys3Label7.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label7.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label7.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label7.Name = "sys3Label7";
            this.sys3Label7.Size = new System.Drawing.Size(137, 30);
            this.sys3Label7.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label7.SubFontColor = System.Drawing.Color.Gray;
            this.sys3Label7.SubText = "";
            this.sys3Label7.TabIndex = 20854;
            this.sys3Label7.Text = "CEID";
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
            // lbl_TargetCeid
            // 
            this.lbl_TargetCeid.BackGroundColor = System.Drawing.Color.White;
            this.lbl_TargetCeid.BorderStroke = 2;
            this.lbl_TargetCeid.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.lbl_TargetCeid.Description = "";
            this.lbl_TargetCeid.DisabledColor = System.Drawing.Color.LightGray;
            this.lbl_TargetCeid.EdgeRadius = 1;
            this.lbl_TargetCeid.ImagePosition = new System.Drawing.Point(0, 0);
            this.lbl_TargetCeid.ImageSize = new System.Drawing.Point(0, 0);
            this.lbl_TargetCeid.LoadImage = null;
            this.lbl_TargetCeid.Location = new System.Drawing.Point(486, 167);
            this.lbl_TargetCeid.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lbl_TargetCeid.MainFontColor = System.Drawing.Color.Black;
            this.lbl_TargetCeid.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.lbl_TargetCeid.Name = "lbl_TargetCeid";
            this.lbl_TargetCeid.Size = new System.Drawing.Size(341, 30);
            this.lbl_TargetCeid.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.lbl_TargetCeid.SubFontColor = System.Drawing.Color.Gray;
            this.lbl_TargetCeid.SubText = "Target";
            this.lbl_TargetCeid.TabIndex = 20853;
            this.lbl_TargetCeid.Text = "--";
            this.lbl_TargetCeid.TextAlignMain = Sys3Controls.EN_TEXTALIGN.BOTTOM_RIGHT;
            this.lbl_TargetCeid.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.lbl_TargetCeid.TextAlignUnit = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.lbl_TargetCeid.ThemeIndex = 0;
            this.lbl_TargetCeid.UnitAreaRate = 30;
            this.lbl_TargetCeid.UnitFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_TargetCeid.UnitFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbl_TargetCeid.UnitPositionVertical = false;
            this.lbl_TargetCeid.UnitText = "";
            this.lbl_TargetCeid.UseBorder = true;
            this.lbl_TargetCeid.UseEdgeRadius = false;
            this.lbl_TargetCeid.UseImage = false;
            this.lbl_TargetCeid.UseSubFont = true;
            this.lbl_TargetCeid.UseUnitFont = false;
            this.lbl_TargetCeid.Click += new System.EventHandler(this.Click_GetCeid);
            // 
            // sys3button5
            // 
            this.sys3button5.BorderWidth = 2;
            this.sys3button5.ButtonClicked = false;
            this.sys3button5.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.sys3button5.CustomClickedGradientFirstColor = System.Drawing.Color.BlanchedAlmond;
            this.sys3button5.CustomClickedGradientSecondColor = System.Drawing.Color.Gold;
            this.sys3button5.Description = "";
            this.sys3button5.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3button5.EdgeRadius = 5;
            this.sys3button5.GradientAngle = 60F;
            this.sys3button5.GradientFirstColor = System.Drawing.Color.Silver;
            this.sys3button5.GradientSecondColor = System.Drawing.Color.Gray;
            this.sys3button5.HoverEmphasizeCustomColor = System.Drawing.Color.Firebrick;
            this.sys3button5.ImagePosition = new System.Drawing.Point(7, 7);
            this.sys3button5.ImageSize = new System.Drawing.Point(30, 30);
            this.sys3button5.LoadImage = null;
            this.sys3button5.Location = new System.Drawing.Point(828, 167);
            this.sys3button5.MainFont = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.sys3button5.MainFontColor = System.Drawing.Color.White;
            this.sys3button5.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3button5.Name = "sys3button5";
            this.sys3button5.Size = new System.Drawing.Size(125, 30);
            this.sys3button5.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.sys3button5.SubFontColor = System.Drawing.Color.DarkBlue;
            this.sys3button5.SubText = "SEND";
            this.sys3button5.TabIndex = 20852;
            this.sys3button5.Text = "CEID";
            this.sys3button5.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3button5.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.sys3button5.ThemeIndex = 0;
            this.sys3button5.UseBorder = true;
            this.sys3button5.UseClickedEmphasizeTextColor = false;
            this.sys3button5.UseCustomizeClickedColor = true;
            this.sys3button5.UseEdge = true;
            this.sys3button5.UseHoverEmphasizeCustomColor = true;
            this.sys3button5.UseImage = true;
            this.sys3button5.UserHoverEmpahsize = true;
            this.sys3button5.UseSubFont = true;
            this.sys3button5.Click += new System.EventHandler(this.Click_SendSecsGemEvent);
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
            this.sys3Label11.Location = new System.Drawing.Point(348, 136);
            this.sys3Label11.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.sys3Label11.MainFontColor = System.Drawing.Color.Black;
            this.sys3Label11.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3Label11.Name = "sys3Label11";
            this.sys3Label11.Size = new System.Drawing.Size(288, 30);
            this.sys3Label11.SubFont = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.sys3Label11.SubFontColor = System.Drawing.Color.Gray;
            this.sys3Label11.SubText = "";
            this.sys3Label11.TabIndex = 20851;
            this.sys3Label11.Text = "MESSAGE TEST";
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
            // btn_SendEfemMessage_Front
            // 
            this.btn_SendEfemMessage_Front.BorderWidth = 2;
            this.btn_SendEfemMessage_Front.ButtonClicked = false;
            this.btn_SendEfemMessage_Front.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.btn_SendEfemMessage_Front.CustomClickedGradientFirstColor = System.Drawing.Color.BlanchedAlmond;
            this.btn_SendEfemMessage_Front.CustomClickedGradientSecondColor = System.Drawing.Color.Gold;
            this.btn_SendEfemMessage_Front.Description = "";
            this.btn_SendEfemMessage_Front.DisabledColor = System.Drawing.Color.DarkGray;
            this.btn_SendEfemMessage_Front.EdgeRadius = 5;
            this.btn_SendEfemMessage_Front.GradientAngle = 60F;
            this.btn_SendEfemMessage_Front.GradientFirstColor = System.Drawing.Color.Silver;
            this.btn_SendEfemMessage_Front.GradientSecondColor = System.Drawing.Color.Gray;
            this.btn_SendEfemMessage_Front.HoverEmphasizeCustomColor = System.Drawing.Color.Firebrick;
            this.btn_SendEfemMessage_Front.ImagePosition = new System.Drawing.Point(7, 7);
            this.btn_SendEfemMessage_Front.ImageSize = new System.Drawing.Point(30, 30);
            this.btn_SendEfemMessage_Front.LoadImage = null;
            this.btn_SendEfemMessage_Front.Location = new System.Drawing.Point(637, 136);
            this.btn_SendEfemMessage_Front.MainFont = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.btn_SendEfemMessage_Front.MainFontColor = System.Drawing.Color.White;
            this.btn_SendEfemMessage_Front.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.btn_SendEfemMessage_Front.Name = "btn_SendEfemMessage_Front";
            this.btn_SendEfemMessage_Front.Size = new System.Drawing.Size(150, 30);
            this.btn_SendEfemMessage_Front.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.btn_SendEfemMessage_Front.SubFontColor = System.Drawing.Color.DarkBlue;
            this.btn_SendEfemMessage_Front.SubText = "SEND";
            this.btn_SendEfemMessage_Front.TabIndex = 20848;
            this.btn_SendEfemMessage_Front.Text = "ECID UPDATE";
            this.btn_SendEfemMessage_Front.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.btn_SendEfemMessage_Front.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.btn_SendEfemMessage_Front.ThemeIndex = 0;
            this.btn_SendEfemMessage_Front.UseBorder = true;
            this.btn_SendEfemMessage_Front.UseClickedEmphasizeTextColor = false;
            this.btn_SendEfemMessage_Front.UseCustomizeClickedColor = true;
            this.btn_SendEfemMessage_Front.UseEdge = true;
            this.btn_SendEfemMessage_Front.UseHoverEmphasizeCustomColor = true;
            this.btn_SendEfemMessage_Front.UseImage = true;
            this.btn_SendEfemMessage_Front.UserHoverEmpahsize = true;
            this.btn_SendEfemMessage_Front.UseSubFont = false;
            this.btn_SendEfemMessage_Front.Click += new System.EventHandler(this.Click_SendEfemMessage);
            // 
            // gridViewControl_Pre_Equip_Parameter
            // 
            this.gridViewControl_Pre_Equip_Parameter.Control_Enable = true;
            this.gridViewControl_Pre_Equip_Parameter.controlCollection = null;
            this.gridViewControl_Pre_Equip_Parameter.Location = new System.Drawing.Point(2, 30);
            this.gridViewControl_Pre_Equip_Parameter.Name = "gridViewControl_Pre_Equip_Parameter";
            this.gridViewControl_Pre_Equip_Parameter.Size = new System.Drawing.Size(342, 203);
            this.gridViewControl_Pre_Equip_Parameter.TabIndex = 20684;
            // 
            // sys3button6
            // 
            this.sys3button6.BorderWidth = 2;
            this.sys3button6.ButtonClicked = false;
            this.sys3button6.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.sys3button6.CustomClickedGradientFirstColor = System.Drawing.Color.BlanchedAlmond;
            this.sys3button6.CustomClickedGradientSecondColor = System.Drawing.Color.Gold;
            this.sys3button6.Description = "";
            this.sys3button6.DisabledColor = System.Drawing.Color.DarkGray;
            this.sys3button6.EdgeRadius = 5;
            this.sys3button6.GradientAngle = 60F;
            this.sys3button6.GradientFirstColor = System.Drawing.Color.Silver;
            this.sys3button6.GradientSecondColor = System.Drawing.Color.Gray;
            this.sys3button6.HoverEmphasizeCustomColor = System.Drawing.Color.Firebrick;
            this.sys3button6.ImagePosition = new System.Drawing.Point(7, 7);
            this.sys3button6.ImageSize = new System.Drawing.Point(30, 30);
            this.sys3button6.LoadImage = null;
            this.sys3button6.Location = new System.Drawing.Point(791, 136);
            this.sys3button6.MainFont = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.sys3button6.MainFontColor = System.Drawing.Color.White;
            this.sys3button6.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sys3button6.Name = "sys3button6";
            this.sys3button6.Size = new System.Drawing.Size(150, 30);
            this.sys3button6.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.sys3button6.SubFontColor = System.Drawing.Color.DarkBlue;
            this.sys3button6.SubText = "SEND";
            this.sys3button6.TabIndex = 20848;
            this.sys3button6.Text = "TEST ALARM";
            this.sys3button6.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
            this.sys3button6.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
            this.sys3button6.ThemeIndex = 0;
            this.sys3button6.UseBorder = true;
            this.sys3button6.UseClickedEmphasizeTextColor = false;
            this.sys3button6.UseCustomizeClickedColor = true;
            this.sys3button6.UseEdge = true;
            this.sys3button6.UseHoverEmphasizeCustomColor = true;
            this.sys3button6.UseImage = true;
            this.sys3button6.UserHoverEmpahsize = true;
            this.sys3button6.UseSubFont = false;
            this.sys3button6.Click += new System.EventHandler(this.Click_Test_Alarm);
            // 
            // Equipment_EFEMComm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.lbl_RecipeDownload);
            this.Controls.Add(this.lbl_RecipeUpload);
            this.Controls.Add(this.sys3Label14);
            this.Controls.Add(this.sys3Label7);
            this.Controls.Add(this.lbl_TargetCeid);
            this.Controls.Add(this.sys3button5);
            this.Controls.Add(this.sys3Label11);
            this.Controls.Add(this.sys3button6);
            this.Controls.Add(this.btn_SendEfemMessage_Front);
            this.Controls.Add(this.sys3button2);
            this.Controls.Add(this.sys3button4);
            this.Controls.Add(this.sys3button3);
            this.Controls.Add(this.sys3button1);
            this.Controls.Add(this.m_listMessage);
            this.Controls.Add(this.btn_ClearLog);
            this.Controls.Add(this.sys3Label2);
            this.Controls.Add(this.lbl_PreEqConnectStatus);
            this.Controls.Add(this.sys3Label4);
            this.Controls.Add(this.lbl_PreEqHostStatus);
            this.Controls.Add(this.gridViewControl_Pre_Equip_Parameter);
            this.Controls.Add(this.sys3GroupBox4);
            this.Controls.Add(this.sys3GroupBox1);
            this.Name = "Equipment_EFEMComm";
            this.Size = new System.Drawing.Size(1136, 791);
            this.ResumeLayout(false);

        }

        #endregion

        private Component.GridViewControl_Parameter gridViewControl_Pre_Equip_Parameter;
        private Sys3Controls.Sys3GroupBox sys3GroupBox1;
        private Sys3Controls.Sys3Label sys3Label4;
        private Sys3Controls.Sys3Label lbl_PreEqHostStatus;
        private Sys3Controls.Sys3GroupBox sys3GroupBox4;
        private Sys3Controls.Sys3button btn_ClearLog;
        private System.Windows.Forms.ListBox m_listMessage;
        private Sys3Controls.Sys3Label lbl_PreEqConnectStatus;
        private Sys3Controls.Sys3Label sys3Label2;
        private Sys3Controls.Sys3button sys3button1;
        private Sys3Controls.Sys3button sys3button2;
        private Sys3Controls.Sys3button sys3button3;
        private Sys3Controls.Sys3button sys3button4;
        private Sys3Controls.Sys3button lbl_RecipeDownload;
        private Sys3Controls.Sys3button lbl_RecipeUpload;
        private Sys3Controls.Sys3Label sys3Label14;
        private Sys3Controls.Sys3Label sys3Label7;
        private Sys3Controls.Sys3Label lbl_TargetCeid;
        private Sys3Controls.Sys3button sys3button5;
        private Sys3Controls.Sys3Label sys3Label11;
        private Sys3Controls.Sys3button btn_SendEfemMessage_Front;
        private Sys3Controls.Sys3button sys3button6;


    }
}
