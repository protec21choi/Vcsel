namespace FrameOfSystem3.Views.Functional
{
    partial class Form_SelectionList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components=null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing&&(components!=null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.m_groupTitleMain = new Sys3Controls.Sys3GroupBox();
			this.m_groupTitleSelected = new Sys3Controls.Sys3GroupBox();
			this.m_groupTitle = new Sys3Controls.Sys3GroupBox();
			this.m_btnLPrevious = new Sys3Controls.Sys3button();
			this.m_btnLPage = new Sys3Controls.Sys3button();
			this.m_btnLNext = new Sys3Controls.Sys3button();
			this.m_btnRNext = new Sys3Controls.Sys3button();
			this.m_btnRPage = new Sys3Controls.Sys3button();
			this.m_btnRPrevious = new Sys3Controls.Sys3button();
			this.m_btnApply = new Sys3Controls.Sys3button();
			this.m_btnCancel = new Sys3Controls.Sys3button();
			this.m_btnAllSelect = new Sys3Controls.Sys3button();
			this.m_btnAllUnSelect = new Sys3Controls.Sys3button();
			this.SuspendLayout();
			// 
			// m_groupTitleMain
			// 
			this.m_groupTitleMain.BackGroundColor = System.Drawing.Color.WhiteSmoke;
			this.m_groupTitleMain.EdgeBorderStroke = 2;
			this.m_groupTitleMain.EdgeRadius = 2;
			this.m_groupTitleMain.LabelFont = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
			this.m_groupTitleMain.LabelGradientColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
			this.m_groupTitleMain.LabelGradientColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.m_groupTitleMain.LabelHeight = 40;
			this.m_groupTitleMain.LabelTextColor = System.Drawing.Color.Black;
			this.m_groupTitleMain.Location = new System.Drawing.Point(0, 0);
			this.m_groupTitleMain.Name = "m_groupTitleMain";
			this.m_groupTitleMain.Size = new System.Drawing.Size(840, 170);
			this.m_groupTitleMain.TabIndex = 1372;
			this.m_groupTitleMain.Text = "SELECTION LIST";
			this.m_groupTitleMain.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_groupTitleMain.UseLabelBorder = true;
			this.m_groupTitleMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown_Title);
			this.m_groupTitleMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove_Title);
			this.m_groupTitleMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUp_Title);
			// 
			// m_groupTitleSelected
			// 
			this.m_groupTitleSelected.BackGroundColor = System.Drawing.Color.WhiteSmoke;
			this.m_groupTitleSelected.EdgeBorderStroke = 2;
			this.m_groupTitleSelected.EdgeRadius = 2;
			this.m_groupTitleSelected.LabelFont = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
			this.m_groupTitleSelected.LabelGradientColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
			this.m_groupTitleSelected.LabelGradientColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.m_groupTitleSelected.LabelHeight = 50;
			this.m_groupTitleSelected.LabelTextColor = System.Drawing.Color.Black;
			this.m_groupTitleSelected.Location = new System.Drawing.Point(0, 40);
			this.m_groupTitleSelected.Name = "m_groupTitleSelected";
			this.m_groupTitleSelected.Size = new System.Drawing.Size(421, 130);
			this.m_groupTitleSelected.TabIndex = 1373;
			this.m_groupTitleSelected.Text = "SELECTED ITEMS";
			this.m_groupTitleSelected.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_groupTitleSelected.UseLabelBorder = true;
			// 
			// m_groupTitle
			// 
			this.m_groupTitle.BackGroundColor = System.Drawing.Color.WhiteSmoke;
			this.m_groupTitle.EdgeBorderStroke = 2;
			this.m_groupTitle.EdgeRadius = 2;
			this.m_groupTitle.LabelFont = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
			this.m_groupTitle.LabelGradientColorFirst = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
			this.m_groupTitle.LabelGradientColorSecond = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.m_groupTitle.LabelHeight = 50;
			this.m_groupTitle.LabelTextColor = System.Drawing.Color.Black;
			this.m_groupTitle.Location = new System.Drawing.Point(419, 40);
			this.m_groupTitle.Name = "m_groupTitle";
			this.m_groupTitle.Size = new System.Drawing.Size(421, 130);
			this.m_groupTitle.TabIndex = 1374;
			this.m_groupTitle.TextAlign = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_groupTitle.UseLabelBorder = true;
			// 
			// m_btnLPrevious
			// 
			this.m_btnLPrevious.BorderWidth = 2;
			this.m_btnLPrevious.ButtonClicked = false;
			this.m_btnLPrevious.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_btnLPrevious.EdgeRadius = 5;
			this.m_btnLPrevious.GradientAngle = 60F;
			this.m_btnLPrevious.GradientFirstColor = System.Drawing.Color.White;
			this.m_btnLPrevious.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(196)))), ((int)(((byte)(203)))));
			this.m_btnLPrevious.ImagePosition = new System.Drawing.Point(7, 7);
			this.m_btnLPrevious.ImageSize = new System.Drawing.Point(30, 30);
			this.m_btnLPrevious.LoadImage = global::FrameOfSystem3.Properties.Resources.CONFIG_ADD3;
			this.m_btnLPrevious.Location = new System.Drawing.Point(12, 110);
			this.m_btnLPrevious.MainFont = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
			this.m_btnLPrevious.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
			this.m_btnLPrevious.Name = "m_btnLPrevious";
			this.m_btnLPrevious.Size = new System.Drawing.Size(65, 50);
			this.m_btnLPrevious.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
			this.m_btnLPrevious.SubFontColor = System.Drawing.Color.DarkBlue;
			this.m_btnLPrevious.SubText = "STATUS";
			this.m_btnLPrevious.TabIndex = 2;
			this.m_btnLPrevious.Text = "<<";
			this.m_btnLPrevious.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_btnLPrevious.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_btnLPrevious.UseBorder = true;
			this.m_btnLPrevious.UseEdge = true;
			this.m_btnLPrevious.UseImage = false;
			this.m_btnLPrevious.UseSubFont = false;
			this.m_btnLPrevious.Click += new System.EventHandler(this.Click_MovePage);
			// 
			// m_btnLPage
			// 
			this.m_btnLPage.BorderWidth = 2;
			this.m_btnLPage.ButtonClicked = false;
			this.m_btnLPage.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_btnLPage.EdgeRadius = 5;
			this.m_btnLPage.GradientAngle = 60F;
			this.m_btnLPage.GradientFirstColor = System.Drawing.Color.White;
			this.m_btnLPage.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(196)))), ((int)(((byte)(203)))));
			this.m_btnLPage.ImagePosition = new System.Drawing.Point(7, 7);
			this.m_btnLPage.ImageSize = new System.Drawing.Point(30, 30);
			this.m_btnLPage.LoadImage = global::FrameOfSystem3.Properties.Resources.CONFIG_ADD3;
			this.m_btnLPage.Location = new System.Drawing.Point(83, 110);
			this.m_btnLPage.MainFont = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
			this.m_btnLPage.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
			this.m_btnLPage.Name = "m_btnLPage";
			this.m_btnLPage.Size = new System.Drawing.Size(55, 50);
			this.m_btnLPage.SubFont = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
			this.m_btnLPage.SubFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
			this.m_btnLPage.SubText = "/ 1";
			this.m_btnLPage.TabIndex = 1375;
			this.m_btnLPage.Text = "1";
			this.m_btnLPage.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_LEFT;
			this.m_btnLPage.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
			this.m_btnLPage.UseBorder = true;
			this.m_btnLPage.UseEdge = true;
			this.m_btnLPage.UseImage = false;
			this.m_btnLPage.UseSubFont = true;
			// 
			// m_btnLNext
			// 
			this.m_btnLNext.BorderWidth = 2;
			this.m_btnLNext.ButtonClicked = false;
			this.m_btnLNext.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_btnLNext.EdgeRadius = 5;
			this.m_btnLNext.GradientAngle = 60F;
			this.m_btnLNext.GradientFirstColor = System.Drawing.Color.White;
			this.m_btnLNext.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(196)))), ((int)(((byte)(203)))));
			this.m_btnLNext.ImagePosition = new System.Drawing.Point(7, 7);
			this.m_btnLNext.ImageSize = new System.Drawing.Point(30, 30);
			this.m_btnLNext.LoadImage = global::FrameOfSystem3.Properties.Resources.CONFIG_ADD3;
			this.m_btnLNext.Location = new System.Drawing.Point(144, 110);
			this.m_btnLNext.MainFont = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
			this.m_btnLNext.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
			this.m_btnLNext.Name = "m_btnLNext";
			this.m_btnLNext.Size = new System.Drawing.Size(65, 50);
			this.m_btnLNext.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
			this.m_btnLNext.SubFontColor = System.Drawing.Color.DarkBlue;
			this.m_btnLNext.SubText = "STATUS";
			this.m_btnLNext.TabIndex = 3;
			this.m_btnLNext.Text = ">>";
			this.m_btnLNext.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_btnLNext.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_btnLNext.UseBorder = true;
			this.m_btnLNext.UseEdge = true;
			this.m_btnLNext.UseImage = false;
			this.m_btnLNext.UseSubFont = false;
			this.m_btnLNext.Click += new System.EventHandler(this.Click_MovePage);
			// 
			// m_btnRNext
			// 
			this.m_btnRNext.BorderWidth = 2;
			this.m_btnRNext.ButtonClicked = false;
			this.m_btnRNext.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_btnRNext.EdgeRadius = 5;
			this.m_btnRNext.GradientAngle = 60F;
			this.m_btnRNext.GradientFirstColor = System.Drawing.Color.White;
			this.m_btnRNext.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(196)))), ((int)(((byte)(203)))));
			this.m_btnRNext.ImagePosition = new System.Drawing.Point(7, 7);
			this.m_btnRNext.ImageSize = new System.Drawing.Point(30, 30);
			this.m_btnRNext.LoadImage = global::FrameOfSystem3.Properties.Resources.CONFIG_ADD3;
			this.m_btnRNext.Location = new System.Drawing.Point(563, 110);
			this.m_btnRNext.MainFont = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
			this.m_btnRNext.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
			this.m_btnRNext.Name = "m_btnRNext";
			this.m_btnRNext.Size = new System.Drawing.Size(65, 50);
			this.m_btnRNext.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
			this.m_btnRNext.SubFontColor = System.Drawing.Color.DarkBlue;
			this.m_btnRNext.SubText = "STATUS";
			this.m_btnRNext.TabIndex = 1;
			this.m_btnRNext.Text = ">>";
			this.m_btnRNext.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_btnRNext.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_btnRNext.UseBorder = true;
			this.m_btnRNext.UseEdge = true;
			this.m_btnRNext.UseImage = false;
			this.m_btnRNext.UseSubFont = false;
			this.m_btnRNext.Click += new System.EventHandler(this.Click_MovePage);
			// 
			// m_btnRPage
			// 
			this.m_btnRPage.BorderWidth = 2;
			this.m_btnRPage.ButtonClicked = false;
			this.m_btnRPage.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_btnRPage.EdgeRadius = 5;
			this.m_btnRPage.GradientAngle = 60F;
			this.m_btnRPage.GradientFirstColor = System.Drawing.Color.White;
			this.m_btnRPage.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(196)))), ((int)(((byte)(203)))));
			this.m_btnRPage.ImagePosition = new System.Drawing.Point(7, 7);
			this.m_btnRPage.ImageSize = new System.Drawing.Point(30, 30);
			this.m_btnRPage.LoadImage = global::FrameOfSystem3.Properties.Resources.CONFIG_ADD3;
			this.m_btnRPage.Location = new System.Drawing.Point(502, 110);
			this.m_btnRPage.MainFont = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
			this.m_btnRPage.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
			this.m_btnRPage.Name = "m_btnRPage";
			this.m_btnRPage.Size = new System.Drawing.Size(55, 50);
			this.m_btnRPage.SubFont = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
			this.m_btnRPage.SubFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
			this.m_btnRPage.SubText = "/ 1";
			this.m_btnRPage.TabIndex = 1377;
			this.m_btnRPage.Text = "1";
			this.m_btnRPage.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_LEFT;
			this.m_btnRPage.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_RIGHT;
			this.m_btnRPage.UseBorder = true;
			this.m_btnRPage.UseEdge = true;
			this.m_btnRPage.UseImage = false;
			this.m_btnRPage.UseSubFont = true;
			// 
			// m_btnRPrevious
			// 
			this.m_btnRPrevious.BorderWidth = 2;
			this.m_btnRPrevious.ButtonClicked = false;
			this.m_btnRPrevious.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_btnRPrevious.EdgeRadius = 5;
			this.m_btnRPrevious.GradientAngle = 60F;
			this.m_btnRPrevious.GradientFirstColor = System.Drawing.Color.White;
			this.m_btnRPrevious.GradientSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(196)))), ((int)(((byte)(203)))));
			this.m_btnRPrevious.ImagePosition = new System.Drawing.Point(7, 7);
			this.m_btnRPrevious.ImageSize = new System.Drawing.Point(30, 30);
			this.m_btnRPrevious.LoadImage = global::FrameOfSystem3.Properties.Resources.CONFIG_ADD3;
			this.m_btnRPrevious.Location = new System.Drawing.Point(431, 110);
			this.m_btnRPrevious.MainFont = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
			this.m_btnRPrevious.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
			this.m_btnRPrevious.Name = "m_btnRPrevious";
			this.m_btnRPrevious.Size = new System.Drawing.Size(65, 50);
			this.m_btnRPrevious.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
			this.m_btnRPrevious.SubFontColor = System.Drawing.Color.DarkBlue;
			this.m_btnRPrevious.SubText = "STATUS";
			this.m_btnRPrevious.TabIndex = 0;
			this.m_btnRPrevious.Text = "<<";
			this.m_btnRPrevious.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_btnRPrevious.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_LEFT;
			this.m_btnRPrevious.UseBorder = true;
			this.m_btnRPrevious.UseEdge = true;
			this.m_btnRPrevious.UseImage = false;
			this.m_btnRPrevious.UseSubFont = false;
			this.m_btnRPrevious.Click += new System.EventHandler(this.Click_MovePage);
			// 
			// m_btnApply
			// 
			this.m_btnApply.BorderWidth = 3;
			this.m_btnApply.ButtonClicked = false;
			this.m_btnApply.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_btnApply.EdgeRadius = 5;
			this.m_btnApply.GradientAngle = 70F;
			this.m_btnApply.GradientFirstColor = System.Drawing.Color.White;
			this.m_btnApply.GradientSecondColor = System.Drawing.Color.LightSlateGray;
			this.m_btnApply.ImagePosition = new System.Drawing.Point(10, 10);
			this.m_btnApply.ImageSize = new System.Drawing.Point(30, 30);
			this.m_btnApply.LoadImage = global::FrameOfSystem3.Properties.Resources.CLEAR_BLACK;
			this.m_btnApply.Location = new System.Drawing.Point(634, 110);
			this.m_btnApply.MainFont = new System.Drawing.Font("맑은 고딕", 12.5F, System.Drawing.FontStyle.Bold);
			this.m_btnApply.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
			this.m_btnApply.Name = "m_btnApply";
			this.m_btnApply.Size = new System.Drawing.Size(95, 50);
			this.m_btnApply.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
			this.m_btnApply.SubFontColor = System.Drawing.Color.DarkBlue;
			this.m_btnApply.SubText = "MOVE";
			this.m_btnApply.TabIndex = 0;
			this.m_btnApply.Text = "APPLY";
			this.m_btnApply.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_btnApply.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_RIGHT;
			this.m_btnApply.UseBorder = true;
			this.m_btnApply.UseEdge = true;
			this.m_btnApply.UseImage = false;
			this.m_btnApply.UseSubFont = false;
			this.m_btnApply.Click += new System.EventHandler(this.Click_ApplyOrCancel);
			// 
			// m_btnCancel
			// 
			this.m_btnCancel.BorderWidth = 3;
			this.m_btnCancel.ButtonClicked = false;
			this.m_btnCancel.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_btnCancel.EdgeRadius = 5;
			this.m_btnCancel.GradientAngle = 70F;
			this.m_btnCancel.GradientFirstColor = System.Drawing.Color.White;
			this.m_btnCancel.GradientSecondColor = System.Drawing.Color.LightSlateGray;
			this.m_btnCancel.ImagePosition = new System.Drawing.Point(10, 10);
			this.m_btnCancel.ImageSize = new System.Drawing.Point(30, 30);
			this.m_btnCancel.LoadImage = global::FrameOfSystem3.Properties.Resources.CLEAR_BLACK;
			this.m_btnCancel.Location = new System.Drawing.Point(735, 110);
			this.m_btnCancel.MainFont = new System.Drawing.Font("맑은 고딕", 12.5F, System.Drawing.FontStyle.Bold);
			this.m_btnCancel.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
			this.m_btnCancel.Name = "m_btnCancel";
			this.m_btnCancel.Size = new System.Drawing.Size(95, 50);
			this.m_btnCancel.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
			this.m_btnCancel.SubFontColor = System.Drawing.Color.DarkBlue;
			this.m_btnCancel.SubText = "MOVE";
			this.m_btnCancel.TabIndex = 1;
			this.m_btnCancel.Text = "CANCEL";
			this.m_btnCancel.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_btnCancel.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_RIGHT;
			this.m_btnCancel.UseBorder = true;
			this.m_btnCancel.UseEdge = true;
			this.m_btnCancel.UseImage = false;
			this.m_btnCancel.UseSubFont = false;
			this.m_btnCancel.Click += new System.EventHandler(this.Click_ApplyOrCancel);
			// 
			// m_btnAllSelect
			// 
			this.m_btnAllSelect.BorderWidth = 3;
			this.m_btnAllSelect.ButtonClicked = false;
			this.m_btnAllSelect.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_btnAllSelect.EdgeRadius = 5;
			this.m_btnAllSelect.GradientAngle = 70F;
			this.m_btnAllSelect.GradientFirstColor = System.Drawing.Color.White;
			this.m_btnAllSelect.GradientSecondColor = System.Drawing.Color.LightSlateGray;
			this.m_btnAllSelect.ImagePosition = new System.Drawing.Point(10, 10);
			this.m_btnAllSelect.ImageSize = new System.Drawing.Point(30, 30);
			this.m_btnAllSelect.LoadImage = global::FrameOfSystem3.Properties.Resources.CLEAR_BLACK;
			this.m_btnAllSelect.Location = new System.Drawing.Point(735, 44);
			this.m_btnAllSelect.MainFont = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.m_btnAllSelect.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
			this.m_btnAllSelect.Name = "m_btnAllSelect";
			this.m_btnAllSelect.Size = new System.Drawing.Size(95, 44);
			this.m_btnAllSelect.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
			this.m_btnAllSelect.SubFontColor = System.Drawing.Color.DarkBlue;
			this.m_btnAllSelect.SubText = "MOVE";
			this.m_btnAllSelect.TabIndex = 1;
			this.m_btnAllSelect.Text = "SELECT\\nALL";
			this.m_btnAllSelect.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_btnAllSelect.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_RIGHT;
			this.m_btnAllSelect.UseBorder = true;
			this.m_btnAllSelect.UseEdge = true;
			this.m_btnAllSelect.UseImage = false;
			this.m_btnAllSelect.UseSubFont = false;
			this.m_btnAllSelect.Click += new System.EventHandler(this.Click_SelectButton);
			// 
			// m_btnAllUnSelect
			// 
			this.m_btnAllUnSelect.BorderWidth = 3;
			this.m_btnAllUnSelect.ButtonClicked = false;
			this.m_btnAllUnSelect.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_btnAllUnSelect.EdgeRadius = 5;
			this.m_btnAllUnSelect.GradientAngle = 70F;
			this.m_btnAllUnSelect.GradientFirstColor = System.Drawing.Color.White;
			this.m_btnAllUnSelect.GradientSecondColor = System.Drawing.Color.LightSlateGray;
			this.m_btnAllUnSelect.ImagePosition = new System.Drawing.Point(10, 10);
			this.m_btnAllUnSelect.ImageSize = new System.Drawing.Point(30, 30);
			this.m_btnAllUnSelect.LoadImage = global::FrameOfSystem3.Properties.Resources.CLEAR_BLACK;
			this.m_btnAllUnSelect.Location = new System.Drawing.Point(12, 44);
			this.m_btnAllUnSelect.MainFont = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.m_btnAllUnSelect.MainFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(0)))));
			this.m_btnAllUnSelect.Name = "m_btnAllUnSelect";
			this.m_btnAllUnSelect.Size = new System.Drawing.Size(95, 44);
			this.m_btnAllUnSelect.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
			this.m_btnAllUnSelect.SubFontColor = System.Drawing.Color.DarkBlue;
			this.m_btnAllUnSelect.SubText = "MOVE";
			this.m_btnAllUnSelect.TabIndex = 0;
			this.m_btnAllUnSelect.Text = "UNSELECT ALL";
			this.m_btnAllUnSelect.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_btnAllUnSelect.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_RIGHT;
			this.m_btnAllUnSelect.UseBorder = true;
			this.m_btnAllUnSelect.UseEdge = true;
			this.m_btnAllUnSelect.UseImage = false;
			this.m_btnAllUnSelect.UseSubFont = false;
			this.m_btnAllUnSelect.Click += new System.EventHandler(this.Click_SelectButton);
			// 
			// Form_SelectionList
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
			this.ClientSize = new System.Drawing.Size(840, 170);
			this.ControlBox = false;
			this.Controls.Add(this.m_btnAllUnSelect);
			this.Controls.Add(this.m_btnAllSelect);
			this.Controls.Add(this.m_btnCancel);
			this.Controls.Add(this.m_btnApply);
			this.Controls.Add(this.m_btnRNext);
			this.Controls.Add(this.m_btnRPage);
			this.Controls.Add(this.m_btnRPrevious);
			this.Controls.Add(this.m_btnLNext);
			this.Controls.Add(this.m_btnLPage);
			this.Controls.Add(this.m_btnLPrevious);
			this.Controls.Add(this.m_groupTitle);
			this.Controls.Add(this.m_groupTitleSelected);
			this.Controls.Add(this.m_groupTitleMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form_SelectionList";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form_SelectionList";
			this.TopMost = true;
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_SelectionList_KeyDown);
			this.ResumeLayout(false);

        }

        #endregion

		private Sys3Controls.Sys3GroupBox m_groupTitleMain;
		private Sys3Controls.Sys3GroupBox m_groupTitleSelected;
		private Sys3Controls.Sys3GroupBox m_groupTitle;
		private Sys3Controls.Sys3button m_btnLPrevious;
		private Sys3Controls.Sys3button m_btnLPage;
		private Sys3Controls.Sys3button m_btnLNext;
		private Sys3Controls.Sys3button m_btnRNext;
		private Sys3Controls.Sys3button m_btnRPage;
		private Sys3Controls.Sys3button m_btnRPrevious;
		private Sys3Controls.Sys3button m_btnApply;
		private Sys3Controls.Sys3button m_btnCancel;
		private Sys3Controls.Sys3button m_btnAllSelect;
		private Sys3Controls.Sys3button m_btnAllUnSelect;
    }
}