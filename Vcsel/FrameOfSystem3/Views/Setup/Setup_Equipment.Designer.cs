namespace FrameOfSystem3.Views.Setup
{
    partial class Setup_Equipment
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
            this.m_pnSubView = new System.Windows.Forms.Panel();
            this.m_tab5 = new Sys3Controls.Sys3button();
            this.m_tab3 = new Sys3Controls.Sys3button();
            this.m_tab2 = new Sys3Controls.Sys3button();
            this.m_tab1 = new Sys3Controls.Sys3button();
            this.m_tab4 = new Sys3Controls.Sys3button();
            this.m_tab0 = new Sys3Controls.Sys3button();
            this.btn_ParameterUndo = new Sys3Controls.Sys3button();
            this.btn_DecideParameterAll = new Sys3Controls.Sys3button();
            this.SuspendLayout();
            // 
            // m_pnSubView
            // 
            this.m_pnSubView.Location = new System.Drawing.Point(2, 48);
            this.m_pnSubView.Name = "m_pnSubView";
            this.m_pnSubView.Size = new System.Drawing.Size(1136, 849);
            this.m_pnSubView.TabIndex = 1613;
            // 
            // m_tab5
            // 
            this.m_tab5.BorderWidth = 2;
            this.m_tab5.ButtonClicked = false;
            this.m_tab5.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.m_tab5.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.m_tab5.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.m_tab5.Description = "";
            this.m_tab5.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_tab5.EdgeRadius = 5;
            this.m_tab5.GradientAngle = 70F;
            this.m_tab5.GradientFirstColor = System.Drawing.Color.White;
            this.m_tab5.GradientSecondColor = System.Drawing.Color.White;
            this.m_tab5.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.m_tab5.ImagePosition = new System.Drawing.Point(7, 7);
            this.m_tab5.ImageSize = new System.Drawing.Point(30, 30);
            this.m_tab5.LoadImage = global::FrameOfSystem3.Properties.Resources.Home_black;
            this.m_tab5.Location = new System.Drawing.Point(736, 1);
            this.m_tab5.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_tab5.MainFontColor = System.Drawing.Color.Black;
            this.m_tab5.Name = "m_tab5";
            this.m_tab5.Size = new System.Drawing.Size(149, 47);
            this.m_tab5.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.m_tab5.SubFontColor = System.Drawing.Color.DarkBlue;
            this.m_tab5.SubText = "STATUS";
            this.m_tab5.TabIndex = 1614;
            this.m_tab5.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_tab5.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_RIGHT;
            this.m_tab5.ThemeIndex = 0;
            this.m_tab5.UseBorder = false;
            this.m_tab5.UseClickedEmphasizeTextColor = false;
            this.m_tab5.UseCustomizeClickedColor = false;
            this.m_tab5.UseEdge = false;
            this.m_tab5.UseHoverEmphasizeCustomColor = false;
            this.m_tab5.UseImage = false;
            this.m_tab5.UserHoverEmpahsize = false;
            this.m_tab5.UseSubFont = false;
            this.m_tab5.Visible = false;
            this.m_tab5.Click += new System.EventHandler(this.Click_Tab);
            // 
            // m_tab3
            // 
            this.m_tab3.BorderWidth = 2;
            this.m_tab3.ButtonClicked = false;
            this.m_tab3.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.m_tab3.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.m_tab3.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.m_tab3.Description = "";
            this.m_tab3.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_tab3.EdgeRadius = 5;
            this.m_tab3.GradientAngle = 70F;
            this.m_tab3.GradientFirstColor = System.Drawing.Color.White;
            this.m_tab3.GradientSecondColor = System.Drawing.Color.White;
            this.m_tab3.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.m_tab3.ImagePosition = new System.Drawing.Point(7, 7);
            this.m_tab3.ImageSize = new System.Drawing.Point(30, 30);
            this.m_tab3.LoadImage = global::FrameOfSystem3.Properties.Resources.Home_black;
            this.m_tab3.Location = new System.Drawing.Point(442, 1);
            this.m_tab3.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_tab3.MainFontColor = System.Drawing.Color.Black;
            this.m_tab3.Name = "m_tab3";
            this.m_tab3.Size = new System.Drawing.Size(149, 47);
            this.m_tab3.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.m_tab3.SubFontColor = System.Drawing.Color.DarkBlue;
            this.m_tab3.SubText = "STATUS";
            this.m_tab3.TabIndex = 1611;
            this.m_tab3.Text = "EFEM";
            this.m_tab3.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_tab3.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_RIGHT;
            this.m_tab3.ThemeIndex = 0;
            this.m_tab3.UseBorder = false;
            this.m_tab3.UseClickedEmphasizeTextColor = false;
            this.m_tab3.UseCustomizeClickedColor = false;
            this.m_tab3.UseEdge = false;
            this.m_tab3.UseHoverEmphasizeCustomColor = false;
            this.m_tab3.UseImage = false;
            this.m_tab3.UserHoverEmpahsize = false;
            this.m_tab3.UseSubFont = false;
            this.m_tab3.Click += new System.EventHandler(this.Click_Tab);
            // 
            // m_tab2
            // 
            this.m_tab2.BorderWidth = 2;
            this.m_tab2.ButtonClicked = false;
            this.m_tab2.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.m_tab2.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.m_tab2.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.m_tab2.Description = "";
            this.m_tab2.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_tab2.EdgeRadius = 5;
            this.m_tab2.GradientAngle = 70F;
            this.m_tab2.GradientFirstColor = System.Drawing.Color.White;
            this.m_tab2.GradientSecondColor = System.Drawing.Color.White;
            this.m_tab2.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.m_tab2.ImagePosition = new System.Drawing.Point(7, 7);
            this.m_tab2.ImageSize = new System.Drawing.Point(30, 30);
            this.m_tab2.LoadImage = global::FrameOfSystem3.Properties.Resources.Home_black;
            this.m_tab2.Location = new System.Drawing.Point(295, 1);
            this.m_tab2.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_tab2.MainFontColor = System.Drawing.Color.Black;
            this.m_tab2.Name = "m_tab2";
            this.m_tab2.Size = new System.Drawing.Size(149, 47);
            this.m_tab2.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.m_tab2.SubFontColor = System.Drawing.Color.DarkBlue;
            this.m_tab2.SubText = "STATUS";
            this.m_tab2.TabIndex = 1610;
            this.m_tab2.Text = "PRE EQUIPMENT";
            this.m_tab2.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_tab2.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_RIGHT;
            this.m_tab2.ThemeIndex = 0;
            this.m_tab2.UseBorder = false;
            this.m_tab2.UseClickedEmphasizeTextColor = false;
            this.m_tab2.UseCustomizeClickedColor = false;
            this.m_tab2.UseEdge = false;
            this.m_tab2.UseHoverEmphasizeCustomColor = false;
            this.m_tab2.UseImage = false;
            this.m_tab2.UserHoverEmpahsize = false;
            this.m_tab2.UseSubFont = false;
            this.m_tab2.Click += new System.EventHandler(this.Click_Tab);
            // 
            // m_tab1
            // 
            this.m_tab1.BorderWidth = 2;
            this.m_tab1.ButtonClicked = false;
            this.m_tab1.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.m_tab1.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.m_tab1.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.m_tab1.Description = "";
            this.m_tab1.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_tab1.EdgeRadius = 5;
            this.m_tab1.GradientAngle = 70F;
            this.m_tab1.GradientFirstColor = System.Drawing.Color.White;
            this.m_tab1.GradientSecondColor = System.Drawing.Color.White;
            this.m_tab1.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.m_tab1.ImagePosition = new System.Drawing.Point(7, 7);
            this.m_tab1.ImageSize = new System.Drawing.Point(30, 30);
            this.m_tab1.LoadImage = global::FrameOfSystem3.Properties.Resources.Home_black;
            this.m_tab1.Location = new System.Drawing.Point(148, 1);
            this.m_tab1.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_tab1.MainFontColor = System.Drawing.Color.Black;
            this.m_tab1.Name = "m_tab1";
            this.m_tab1.Size = new System.Drawing.Size(149, 47);
            this.m_tab1.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.m_tab1.SubFontColor = System.Drawing.Color.DarkBlue;
            this.m_tab1.SubText = "STATUS";
            this.m_tab1.TabIndex = 1609;
            this.m_tab1.Text = "DEVICE";
            this.m_tab1.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_tab1.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_RIGHT;
            this.m_tab1.ThemeIndex = 0;
            this.m_tab1.UseBorder = false;
            this.m_tab1.UseClickedEmphasizeTextColor = false;
            this.m_tab1.UseCustomizeClickedColor = false;
            this.m_tab1.UseEdge = false;
            this.m_tab1.UseHoverEmphasizeCustomColor = false;
            this.m_tab1.UseImage = false;
            this.m_tab1.UserHoverEmpahsize = false;
            this.m_tab1.UseSubFont = false;
            this.m_tab1.Click += new System.EventHandler(this.Click_Tab);
            // 
            // m_tab4
            // 
            this.m_tab4.BorderWidth = 2;
            this.m_tab4.ButtonClicked = false;
            this.m_tab4.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.m_tab4.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.m_tab4.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.m_tab4.Description = "";
            this.m_tab4.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_tab4.EdgeRadius = 5;
            this.m_tab4.GradientAngle = 70F;
            this.m_tab4.GradientFirstColor = System.Drawing.Color.White;
            this.m_tab4.GradientSecondColor = System.Drawing.Color.White;
            this.m_tab4.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.m_tab4.ImagePosition = new System.Drawing.Point(7, 7);
            this.m_tab4.ImageSize = new System.Drawing.Point(30, 30);
            this.m_tab4.LoadImage = global::FrameOfSystem3.Properties.Resources.Home_black;
            this.m_tab4.Location = new System.Drawing.Point(589, 1);
            this.m_tab4.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_tab4.MainFontColor = System.Drawing.Color.Black;
            this.m_tab4.Name = "m_tab4";
            this.m_tab4.Size = new System.Drawing.Size(149, 47);
            this.m_tab4.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.m_tab4.SubFontColor = System.Drawing.Color.DarkBlue;
            this.m_tab4.SubText = "STATUS";
            this.m_tab4.TabIndex = 1612;
            this.m_tab4.Text = "TOOL";
            this.m_tab4.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_tab4.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_RIGHT;
            this.m_tab4.ThemeIndex = 0;
            this.m_tab4.UseBorder = false;
            this.m_tab4.UseClickedEmphasizeTextColor = false;
            this.m_tab4.UseCustomizeClickedColor = false;
            this.m_tab4.UseEdge = false;
            this.m_tab4.UseHoverEmphasizeCustomColor = false;
            this.m_tab4.UseImage = false;
            this.m_tab4.UserHoverEmpahsize = false;
            this.m_tab4.UseSubFont = false;
            this.m_tab4.Click += new System.EventHandler(this.Click_Tab);
            // 
            // m_tab0
            // 
            this.m_tab0.BorderWidth = 2;
            this.m_tab0.ButtonClicked = true;
            this.m_tab0.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.m_tab0.CustomClickedGradientFirstColor = System.Drawing.Color.White;
            this.m_tab0.CustomClickedGradientSecondColor = System.Drawing.Color.White;
            this.m_tab0.Description = "";
            this.m_tab0.DisabledColor = System.Drawing.Color.DarkGray;
            this.m_tab0.EdgeRadius = 5;
            this.m_tab0.GradientAngle = 70F;
            this.m_tab0.GradientFirstColor = System.Drawing.Color.DarkBlue;
            this.m_tab0.GradientSecondColor = System.Drawing.Color.DarkBlue;
            this.m_tab0.HoverEmphasizeCustomColor = System.Drawing.Color.White;
            this.m_tab0.ImagePosition = new System.Drawing.Point(7, 7);
            this.m_tab0.ImageSize = new System.Drawing.Point(30, 30);
            this.m_tab0.LoadImage = global::FrameOfSystem3.Properties.Resources.Home_black;
            this.m_tab0.Location = new System.Drawing.Point(1, 1);
            this.m_tab0.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.m_tab0.MainFontColor = System.Drawing.Color.White;
            this.m_tab0.Name = "m_tab0";
            this.m_tab0.Size = new System.Drawing.Size(149, 47);
            this.m_tab0.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.m_tab0.SubFontColor = System.Drawing.Color.DarkBlue;
            this.m_tab0.SubText = "STATUS";
            this.m_tab0.TabIndex = 1608;
            this.m_tab0.Text = "LASER";
            this.m_tab0.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.m_tab0.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_RIGHT;
            this.m_tab0.ThemeIndex = 0;
            this.m_tab0.UseBorder = false;
            this.m_tab0.UseClickedEmphasizeTextColor = false;
            this.m_tab0.UseCustomizeClickedColor = false;
            this.m_tab0.UseEdge = false;
            this.m_tab0.UseHoverEmphasizeCustomColor = false;
            this.m_tab0.UseImage = false;
            this.m_tab0.UserHoverEmpahsize = false;
            this.m_tab0.UseSubFont = false;
            this.m_tab0.Click += new System.EventHandler(this.Click_Tab);
            // 
            // btn_ParameterUndo
            // 
            this.btn_ParameterUndo.BorderWidth = 2;
            this.btn_ParameterUndo.ButtonClicked = false;
            this.btn_ParameterUndo.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.btn_ParameterUndo.CustomClickedGradientFirstColor = System.Drawing.Color.BlanchedAlmond;
            this.btn_ParameterUndo.CustomClickedGradientSecondColor = System.Drawing.Color.Gold;
            this.btn_ParameterUndo.Description = "";
            this.btn_ParameterUndo.DisabledColor = System.Drawing.Color.DarkGray;
            this.btn_ParameterUndo.EdgeRadius = 5;
            this.btn_ParameterUndo.GradientAngle = 60F;
            this.btn_ParameterUndo.GradientFirstColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_ParameterUndo.GradientSecondColor = System.Drawing.Color.SteelBlue;
            this.btn_ParameterUndo.HoverEmphasizeCustomColor = System.Drawing.Color.Firebrick;
            this.btn_ParameterUndo.ImagePosition = new System.Drawing.Point(8, 7);
            this.btn_ParameterUndo.ImageSize = new System.Drawing.Point(35, 30);
            this.btn_ParameterUndo.LoadImage = global::FrameOfSystem3.Properties.Resources.undo_52px;
            this.btn_ParameterUndo.Location = new System.Drawing.Point(1039, 2);
            this.btn_ParameterUndo.MainFont = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_ParameterUndo.MainFontColor = System.Drawing.Color.White;
            this.btn_ParameterUndo.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.btn_ParameterUndo.Name = "btn_ParameterUndo";
            this.btn_ParameterUndo.Size = new System.Drawing.Size(49, 43);
            this.btn_ParameterUndo.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.btn_ParameterUndo.SubFontColor = System.Drawing.Color.Black;
            this.btn_ParameterUndo.SubText = "";
            this.btn_ParameterUndo.TabIndex = 20853;
            this.btn_ParameterUndo.Tag = "";
            this.btn_ParameterUndo.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.btn_ParameterUndo.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.btn_ParameterUndo.ThemeIndex = 0;
            this.btn_ParameterUndo.UseBorder = true;
            this.btn_ParameterUndo.UseClickedEmphasizeTextColor = false;
            this.btn_ParameterUndo.UseCustomizeClickedColor = true;
            this.btn_ParameterUndo.UseEdge = true;
            this.btn_ParameterUndo.UseHoverEmphasizeCustomColor = true;
            this.btn_ParameterUndo.UseImage = true;
            this.btn_ParameterUndo.UserHoverEmpahsize = true;
            this.btn_ParameterUndo.UseSubFont = false;
            this.btn_ParameterUndo.Click += new System.EventHandler(this.ClickParameterUndo);
            // 
            // btn_DecideParameterAll
            // 
            this.btn_DecideParameterAll.BorderWidth = 2;
            this.btn_DecideParameterAll.ButtonClicked = false;
            this.btn_DecideParameterAll.ClickedEmphasizeTextColor = System.Drawing.Color.White;
            this.btn_DecideParameterAll.CustomClickedGradientFirstColor = System.Drawing.Color.BlanchedAlmond;
            this.btn_DecideParameterAll.CustomClickedGradientSecondColor = System.Drawing.Color.Gold;
            this.btn_DecideParameterAll.Description = "";
            this.btn_DecideParameterAll.DisabledColor = System.Drawing.Color.DarkGray;
            this.btn_DecideParameterAll.EdgeRadius = 5;
            this.btn_DecideParameterAll.GradientAngle = 60F;
            this.btn_DecideParameterAll.GradientFirstColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_DecideParameterAll.GradientSecondColor = System.Drawing.Color.SteelBlue;
            this.btn_DecideParameterAll.HoverEmphasizeCustomColor = System.Drawing.Color.Firebrick;
            this.btn_DecideParameterAll.ImagePosition = new System.Drawing.Point(8, 7);
            this.btn_DecideParameterAll.ImageSize = new System.Drawing.Point(35, 30);
            this.btn_DecideParameterAll.LoadImage = global::FrameOfSystem3.Properties.Resources.save_52px;
            this.btn_DecideParameterAll.Location = new System.Drawing.Point(1088, 2);
            this.btn_DecideParameterAll.MainFont = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_DecideParameterAll.MainFontColor = System.Drawing.Color.White;
            this.btn_DecideParameterAll.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.btn_DecideParameterAll.Name = "btn_DecideParameterAll";
            this.btn_DecideParameterAll.Size = new System.Drawing.Size(49, 43);
            this.btn_DecideParameterAll.SubFont = new System.Drawing.Font("맑은 고딕", 10F);
            this.btn_DecideParameterAll.SubFontColor = System.Drawing.Color.Black;
            this.btn_DecideParameterAll.SubText = "";
            this.btn_DecideParameterAll.TabIndex = 20854;
            this.btn_DecideParameterAll.Tag = "";
            this.btn_DecideParameterAll.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.btn_DecideParameterAll.TextAlignSub = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
            this.btn_DecideParameterAll.ThemeIndex = 0;
            this.btn_DecideParameterAll.UseBorder = true;
            this.btn_DecideParameterAll.UseClickedEmphasizeTextColor = false;
            this.btn_DecideParameterAll.UseCustomizeClickedColor = true;
            this.btn_DecideParameterAll.UseEdge = true;
            this.btn_DecideParameterAll.UseHoverEmphasizeCustomColor = true;
            this.btn_DecideParameterAll.UseImage = true;
            this.btn_DecideParameterAll.UserHoverEmpahsize = true;
            this.btn_DecideParameterAll.UseSubFont = false;
            this.btn_DecideParameterAll.Click += new System.EventHandler(this.ClickParameterSave);
            // 
            // Setup_Equipment
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.btn_ParameterUndo);
            this.Controls.Add(this.btn_DecideParameterAll);
            this.Controls.Add(this.m_tab5);
            this.Controls.Add(this.m_tab3);
            this.Controls.Add(this.m_tab2);
            this.Controls.Add(this.m_tab1);
            this.Controls.Add(this.m_tab4);
            this.Controls.Add(this.m_tab0);
            this.Controls.Add(this.m_pnSubView);
            this.Name = "Setup_Equipment";
            this.Size = new System.Drawing.Size(1140, 900);
            this.ResumeLayout(false);

		}
		#endregion

        private Sys3Controls.Sys3button m_tab5;
		private Sys3Controls.Sys3button m_tab3;
		private Sys3Controls.Sys3button m_tab2;
		private Sys3Controls.Sys3button m_tab1;
		private Sys3Controls.Sys3button m_tab4;
		private Sys3Controls.Sys3button m_tab0;
		private System.Windows.Forms.Panel m_pnSubView;
        private Sys3Controls.Sys3button btn_ParameterUndo;
        private Sys3Controls.Sys3button btn_DecideParameterAll;
	}
}
