namespace FrameOfSystem3.Views.Config
{
	partial class Config_Communication
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
			this.m_tabSocket = new Sys3Controls.Sys3button();
			this.m_tabSerial = new Sys3Controls.Sys3button();
			this.m_panel = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// m_tabSocket
			// 
			this.m_tabSocket.BorderWidth = 2;
			this.m_tabSocket.ButtonClicked = true;
			this.m_tabSocket.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_tabSocket.EdgeRadius = 5;
			this.m_tabSocket.GradientAngle = 70F;
			this.m_tabSocket.GradientFirstColor = System.Drawing.Color.DarkBlue;
			this.m_tabSocket.GradientSecondColor = System.Drawing.Color.DarkBlue;
			this.m_tabSocket.ImagePosition = new System.Drawing.Point(7, 7);
			this.m_tabSocket.ImageSize = new System.Drawing.Point(30, 30);
			this.m_tabSocket.LoadImage = global::FrameOfSystem3.Properties.Resources.Home_black;
			this.m_tabSocket.Location = new System.Drawing.Point(913, 2);
			this.m_tabSocket.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_tabSocket.MainFontColor = System.Drawing.Color.White;
			this.m_tabSocket.Name = "m_tabSocket";
			this.m_tabSocket.Size = new System.Drawing.Size(113, 45);
			this.m_tabSocket.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
			this.m_tabSocket.SubFontColor = System.Drawing.Color.DarkBlue;
			this.m_tabSocket.SubText = "STATUS";
			this.m_tabSocket.TabIndex = 2;
			this.m_tabSocket.Text = "SOCKET";
			this.m_tabSocket.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_tabSocket.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_RIGHT;
			this.m_tabSocket.UseBorder = false;
			this.m_tabSocket.UseEdge = false;
			this.m_tabSocket.UseImage = false;
			this.m_tabSocket.UseSubFont = false;
			this.m_tabSocket.Click += new System.EventHandler(this.Click_Tab);
			// 
			// m_tabSerial
			// 
			this.m_tabSerial.BorderWidth = 2;
			this.m_tabSerial.ButtonClicked = false;
			this.m_tabSerial.DisabledColor = System.Drawing.Color.DarkGray;
			this.m_tabSerial.EdgeRadius = 5;
			this.m_tabSerial.GradientAngle = 70F;
			this.m_tabSerial.GradientFirstColor = System.Drawing.Color.White;
			this.m_tabSerial.GradientSecondColor = System.Drawing.Color.White;
			this.m_tabSerial.ImagePosition = new System.Drawing.Point(7, 7);
			this.m_tabSerial.ImageSize = new System.Drawing.Point(30, 30);
			this.m_tabSerial.LoadImage = global::FrameOfSystem3.Properties.Resources.Home_black;
			this.m_tabSerial.Location = new System.Drawing.Point(1024, 2);
			this.m_tabSerial.MainFont = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
			this.m_tabSerial.MainFontColor = System.Drawing.Color.DarkBlue;
			this.m_tabSerial.Name = "m_tabSerial";
			this.m_tabSerial.Size = new System.Drawing.Size(113, 45);
			this.m_tabSerial.SubFont = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
			this.m_tabSerial.SubFontColor = System.Drawing.Color.DarkBlue;
			this.m_tabSerial.SubText = "STATUS";
			this.m_tabSerial.TabIndex = 3;
			this.m_tabSerial.Text = "SERIAL";
			this.m_tabSerial.TextAlignMain = Sys3Controls.EN_TEXTALIGN.MIDDLE_CENTER;
			this.m_tabSerial.TextAlignSub = Sys3Controls.EN_TEXTALIGN.TOP_RIGHT;
			this.m_tabSerial.UseBorder = false;
			this.m_tabSerial.UseEdge = false;
			this.m_tabSerial.UseImage = false;
			this.m_tabSerial.UseSubFont = false;
			this.m_tabSerial.Click += new System.EventHandler(this.Click_Tab);
			// 
			// m_panel
			// 
			this.m_panel.Location = new System.Drawing.Point(0, 49);
			this.m_panel.Name = "m_panel";
			this.m_panel.Size = new System.Drawing.Size(1140, 850);
			this.m_panel.TabIndex = 1155;
			// 
			// Config_Communication
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.m_panel);
			this.Controls.Add(this.m_tabSocket);
			this.Controls.Add(this.m_tabSerial);
			this.Name = "Config_Communication";
			this.Size = new System.Drawing.Size(1140, 900);
			this.ResumeLayout(false);

        }

        #endregion

		private Sys3Controls.Sys3button m_tabSocket;
		private Sys3Controls.Sys3button m_tabSerial;
		private System.Windows.Forms.Panel m_panel;

	}
}
