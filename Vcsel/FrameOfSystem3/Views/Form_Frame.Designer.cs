namespace FrameOfSystem3.Views
{
    partial class Form_Frame
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Frame));
            this.m_panelTitleBar = new System.Windows.Forms.Panel();
            this.m_panelMainView = new System.Windows.Forms.Panel();
            this.m_panelSubMenu = new System.Windows.Forms.Panel();
            this.m_panelMainMenu = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // m_panelTitleBar
            // 
            this.m_panelTitleBar.Location = new System.Drawing.Point(0, 0);
            this.m_panelTitleBar.Margin = new System.Windows.Forms.Padding(0);
            this.m_panelTitleBar.Name = "m_panelTitleBar";
            this.m_panelTitleBar.Size = new System.Drawing.Size(1280, 66);
            this.m_panelTitleBar.TabIndex = 0;
            // 
            // m_panelMainView
            // 
            this.m_panelMainView.Location = new System.Drawing.Point(0, 66);
            this.m_panelMainView.Name = "m_panelMainView";
            this.m_panelMainView.Size = new System.Drawing.Size(1140, 900);
            this.m_panelMainView.TabIndex = 1;
            // 
            // m_panelSubMenu
            // 
            this.m_panelSubMenu.Location = new System.Drawing.Point(1140, 66);
            this.m_panelSubMenu.Name = "m_panelSubMenu";
            this.m_panelSubMenu.Size = new System.Drawing.Size(140, 900);
            this.m_panelSubMenu.TabIndex = 2;
            // 
            // m_panelMainMenu
            // 
            this.m_panelMainMenu.Location = new System.Drawing.Point(0, 966);
            this.m_panelMainMenu.Name = "m_panelMainMenu";
            this.m_panelMainMenu.Size = new System.Drawing.Size(1280, 58);
            this.m_panelMainMenu.TabIndex = 3;
            // 
            // Form_Frame
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1280, 1024);
            this.ControlBox = false;
            this.Controls.Add(this.m_panelSubMenu);
            this.Controls.Add(this.m_panelMainMenu);
            this.Controls.Add(this.m_panelMainView);
            this.Controls.Add(this.m_panelTitleBar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Frame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form_Frame";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel m_panelTitleBar;
        private System.Windows.Forms.Panel m_panelMainView;
        private System.Windows.Forms.Panel m_panelSubMenu;
		private System.Windows.Forms.Panel m_panelMainMenu;
    }
}

