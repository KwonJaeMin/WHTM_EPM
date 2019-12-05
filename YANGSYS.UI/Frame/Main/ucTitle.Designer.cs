namespace YANGSYS.UI.WHTM
{
    partial class ucTitle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucTitle));
            this.Panel1 = new System.Windows.Forms.Panel();
            this.lbTimehhmmss = new System.Windows.Forms.Label();
            this.lbTimeyyymmdd = new System.Windows.Forms.Label();
            this.lblSite = new System.Windows.Forms.Label();
            this.lblProjectName = new System.Windows.Forms.Label();
            this.lblShortVersion = new System.Windows.Forms.Label();
            this.lblCimMode = new System.Windows.Forms.Label();
            this.lblSimulatorMode = new System.Windows.Forms.Label();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.lblEqpID = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.picSiteLogo = new System.Windows.Forms.PictureBox();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSiteLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel1.Controls.Add(this.lbTimehhmmss);
            this.Panel1.Controls.Add(this.lbTimeyyymmdd);
            this.Panel1.Controls.Add(this.lblSite);
            this.Panel1.Controls.Add(this.lblProjectName);
            this.Panel1.Controls.Add(this.lblShortVersion);
            this.Panel1.Controls.Add(this.btnClose);
            this.Panel1.Controls.Add(this.lblCimMode);
            this.Panel1.Controls.Add(this.lblSimulatorMode);
            this.Panel1.Controls.Add(this.lblCurrentUser);
            this.Panel1.Controls.Add(this.lblEqpID);
            this.Panel1.Controls.Add(this.picSiteLogo);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(1262, 49);
            this.Panel1.TabIndex = 1;
            // 
            // lbTimehhmmss
            // 
            this.lbTimehhmmss.BackColor = System.Drawing.Color.Black;
            this.lbTimehhmmss.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTimehhmmss.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.lbTimehhmmss.ForeColor = System.Drawing.Color.White;
            this.lbTimehhmmss.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbTimehhmmss.Location = new System.Drawing.Point(1100, 18);
            this.lbTimehhmmss.Name = "lbTimehhmmss";
            this.lbTimehhmmss.Size = new System.Drawing.Size(120, 28);
            this.lbTimehhmmss.TabIndex = 25;
            this.lbTimehhmmss.Text = "23 : 59 : 59";
            this.lbTimehhmmss.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbTimeyyymmdd
            // 
            this.lbTimeyyymmdd.BackColor = System.Drawing.Color.Black;
            this.lbTimeyyymmdd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTimeyyymmdd.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lbTimeyyymmdd.ForeColor = System.Drawing.Color.White;
            this.lbTimeyyymmdd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbTimeyyymmdd.Location = new System.Drawing.Point(1100, 0);
            this.lbTimeyyymmdd.Name = "lbTimeyyymmdd";
            this.lbTimeyyymmdd.Size = new System.Drawing.Size(120, 18);
            this.lbTimeyyymmdd.TabIndex = 24;
            this.lbTimeyyymmdd.Text = "2010-02-10-MON";
            this.lbTimeyyymmdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSite
            // 
            this.lblSite.BackColor = System.Drawing.Color.MidnightBlue;
            this.lblSite.Font = new System.Drawing.Font("Malgun Gothic", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSite.ForeColor = System.Drawing.Color.White;
            this.lblSite.Location = new System.Drawing.Point(1, 37);
            this.lblSite.Name = "lblSite";
            this.lblSite.Size = new System.Drawing.Size(59, 11);
            this.lblSite.TabIndex = 23;
            this.lblSite.Text = "SITENAME";
            this.lblSite.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblProjectName
            // 
            this.lblProjectName.BackColor = System.Drawing.Color.MidnightBlue;
            this.lblProjectName.Font = new System.Drawing.Font("Malgun Gothic", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblProjectName.ForeColor = System.Drawing.Color.White;
            this.lblProjectName.Location = new System.Drawing.Point(60, 37);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(154, 11);
            this.lblProjectName.TabIndex = 23;
            this.lblProjectName.Text = "PROJECT";
            this.lblProjectName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblShortVersion
            // 
            this.lblShortVersion.BackColor = System.Drawing.Color.Black;
            this.lblShortVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblShortVersion.Font = new System.Drawing.Font("Malgun Gothic", 9.75F);
            this.lblShortVersion.ForeColor = System.Drawing.Color.Silver;
            this.lblShortVersion.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblShortVersion.Location = new System.Drawing.Point(940, 17);
            this.lblShortVersion.Name = "lblShortVersion";
            this.lblShortVersion.Size = new System.Drawing.Size(154, 23);
            this.lblShortVersion.TabIndex = 22;
            this.lblShortVersion.Text = "Ver1.00(2016-11-08)";
            this.lblShortVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCimMode
            // 
            this.lblCimMode.BackColor = System.Drawing.Color.Red;
            this.lblCimMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCimMode.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCimMode.ForeColor = System.Drawing.Color.White;
            this.lblCimMode.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblCimMode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCimMode.Location = new System.Drawing.Point(372, 9);
            this.lblCimMode.Name = "lblCimMode";
            this.lblCimMode.Size = new System.Drawing.Size(77, 28);
            this.lblCimMode.TabIndex = 16;
            this.lblCimMode.Text = "CIM OFF";
            this.lblCimMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCimMode.Click += new System.EventHandler(this.OnMenuButtonCliceked);
            // 
            // lblSimulatorMode
            // 
            this.lblSimulatorMode.BackColor = System.Drawing.Color.Red;
            this.lblSimulatorMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSimulatorMode.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSimulatorMode.ForeColor = System.Drawing.Color.White;
            this.lblSimulatorMode.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblSimulatorMode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSimulatorMode.Location = new System.Drawing.Point(455, 9);
            this.lblSimulatorMode.Name = "lblSimulatorMode";
            this.lblSimulatorMode.Size = new System.Drawing.Size(99, 28);
            this.lblSimulatorMode.TabIndex = 16;
            this.lblSimulatorMode.Text = "SIMULATOR";
            this.lblSimulatorMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSimulatorMode.Click += new System.EventHandler(this.OnMenuButtonCliceked);
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.BackColor = System.Drawing.Color.Lime;
            this.lblCurrentUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCurrentUser.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblCurrentUser.ForeColor = System.Drawing.Color.Black;
            this.lblCurrentUser.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCurrentUser.Location = new System.Drawing.Point(222, 9);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(144, 28);
            this.lblCurrentUser.TabIndex = 16;
            this.lblCurrentUser.Text = "ADMINISTRATOR";
            this.lblCurrentUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCurrentUser.Click += new System.EventHandler(this.OnMenuButtonCliceked);
            // 
            // lblEqpID
            // 
            this.lblEqpID.BackColor = System.Drawing.Color.Black;
            this.lblEqpID.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblEqpID.ForeColor = System.Drawing.Color.White;
            this.lblEqpID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblEqpID.Location = new System.Drawing.Point(264, 0);
            this.lblEqpID.Name = "lblEqpID";
            this.lblEqpID.Size = new System.Drawing.Size(836, 46);
            this.lblEqpID.TabIndex = 6;
            this.lblEqpID.Text = "PROGRAM NAME";
            this.lblEqpID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEqpID.Click += new System.EventHandler(this.OnMenuButtonCliceked);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Black;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(1220, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 46);
            this.btnClose.TabIndex = 21;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.OnMenuButtonCliceked);
            // 
            // picSiteLogo
            // 
            this.picSiteLogo.BackColor = System.Drawing.Color.White;
            this.picSiteLogo.Image = global::YANGSYS.UI.WHTM.Properties.Resources.Tianma_Logo1;
            this.picSiteLogo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picSiteLogo.Location = new System.Drawing.Point(-2, -1);
            this.picSiteLogo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.picSiteLogo.Name = "picSiteLogo";
            this.picSiteLogo.Size = new System.Drawing.Size(216, 40);
            this.picSiteLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSiteLogo.TabIndex = 5;
            this.picSiteLogo.TabStop = false;
            this.picSiteLogo.Click += new System.EventHandler(this.OnMenuButtonCliceked);
            // 
            // ucTitle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.Panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Name = "ucTitle";
            this.Size = new System.Drawing.Size(1262, 49);
            this.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSiteLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label lblShortVersion;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Label lblCurrentUser;
        internal System.Windows.Forms.Label lblEqpID;
        internal System.Windows.Forms.PictureBox picSiteLogo;
        private System.Windows.Forms.Label lblProjectName;
        internal System.Windows.Forms.Label lbTimehhmmss;
        internal System.Windows.Forms.Label lbTimeyyymmdd;
        private System.Windows.Forms.Label lblSite;
        internal System.Windows.Forms.Label lblSimulatorMode;
        internal System.Windows.Forms.Label lblCimMode;



    }
}
