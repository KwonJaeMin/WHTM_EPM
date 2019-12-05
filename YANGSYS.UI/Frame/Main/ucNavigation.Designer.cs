namespace YANGSYS.UI.WHTM
{
    partial class ucNavigation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucNavigation));
            this.plTop2 = new System.Windows.Forms.Panel();
            this.plRight = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.plLeft = new System.Windows.Forms.Panel();
            this.btn_GlassData = new System.Windows.Forms.Button();
            this.btnMain = new System.Windows.Forms.Button();
            this.btnSystem = new System.Windows.Forms.Button();
            this.btnLog = new System.Windows.Forms.Button();
            this.btnAlarm = new System.Windows.Forms.Button();
            this.plTop2.SuspendLayout();
            this.plRight.SuspendLayout();
            this.plLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // plTop2
            // 
            this.plTop2.Controls.Add(this.plRight);
            this.plTop2.Controls.Add(this.plLeft);
            this.plTop2.Dock = System.Windows.Forms.DockStyle.Top;
            this.plTop2.Location = new System.Drawing.Point(0, 0);
            this.plTop2.Name = "plTop2";
            this.plTop2.Size = new System.Drawing.Size(1280, 86);
            this.plTop2.TabIndex = 54;
            // 
            // plRight
            // 
            this.plRight.Controls.Add(this.btnClose);
            this.plRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.plRight.Location = new System.Drawing.Point(1181, 0);
            this.plRight.Name = "plRight";
            this.plRight.Size = new System.Drawing.Size(99, 86);
            this.plRight.TabIndex = 56;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(5, 2);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 80);
            this.btnClose.TabIndex = 34;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.OnMenuButtonCliceked);
            // 
            // plLeft
            // 
            this.plLeft.Controls.Add(this.btn_GlassData);
            this.plLeft.Controls.Add(this.btnMain);
            this.plLeft.Controls.Add(this.btnSystem);
            this.plLeft.Controls.Add(this.btnLog);
            this.plLeft.Controls.Add(this.btnAlarm);
            this.plLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plLeft.Location = new System.Drawing.Point(0, 0);
            this.plLeft.Name = "plLeft";
            this.plLeft.Size = new System.Drawing.Size(1280, 86);
            this.plLeft.TabIndex = 55;
            // 
            // btn_GlassData
            // 
            this.btn_GlassData.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_GlassData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_GlassData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_GlassData.Image = ((System.Drawing.Image)(resources.GetObject("btn_GlassData.Image")));
            this.btn_GlassData.Location = new System.Drawing.Point(375, 2);
            this.btn_GlassData.Margin = new System.Windows.Forms.Padding(2);
            this.btn_GlassData.Name = "btn_GlassData";
            this.btn_GlassData.Size = new System.Drawing.Size(90, 80);
            this.btn_GlassData.TabIndex = 33;
            this.btn_GlassData.Text = "Glass Data";
            this.btn_GlassData.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_GlassData.UseVisualStyleBackColor = false;
            this.btn_GlassData.Click += new System.EventHandler(this.OnMenuButtonCliceked);
            // 
            // btnMain
            // 
            this.btnMain.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnMain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMain.Image = ((System.Drawing.Image)(resources.GetObject("btnMain.Image")));
            this.btnMain.Location = new System.Drawing.Point(2, 2);
            this.btnMain.Margin = new System.Windows.Forms.Padding(2);
            this.btnMain.Name = "btnMain";
            this.btnMain.Size = new System.Drawing.Size(90, 80);
            this.btnMain.TabIndex = 1;
            this.btnMain.Text = "Main";
            this.btnMain.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMain.UseVisualStyleBackColor = false;
            this.btnMain.Click += new System.EventHandler(this.OnMenuButtonCliceked);
            // 
            // btnSystem
            // 
            this.btnSystem.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSystem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSystem.Image = ((System.Drawing.Image)(resources.GetObject("btnSystem.Image")));
            this.btnSystem.Location = new System.Drawing.Point(96, 2);
            this.btnSystem.Margin = new System.Windows.Forms.Padding(2);
            this.btnSystem.Name = "btnSystem";
            this.btnSystem.Size = new System.Drawing.Size(90, 80);
            this.btnSystem.TabIndex = 0;
            this.btnSystem.Text = "System";
            this.btnSystem.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSystem.UseVisualStyleBackColor = false;
            this.btnSystem.Click += new System.EventHandler(this.OnMenuButtonCliceked);
            // 
            // btnLog
            // 
            this.btnLog.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLog.Image = ((System.Drawing.Image)(resources.GetObject("btnLog.Image")));
            this.btnLog.Location = new System.Drawing.Point(282, 2);
            this.btnLog.Margin = new System.Windows.Forms.Padding(2);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(90, 80);
            this.btnLog.TabIndex = 32;
            this.btnLog.Text = "Log";
            this.btnLog.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLog.UseVisualStyleBackColor = false;
            this.btnLog.Click += new System.EventHandler(this.OnMenuButtonCliceked);
            // 
            // btnAlarm
            // 
            this.btnAlarm.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAlarm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAlarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlarm.Image = ((System.Drawing.Image)(resources.GetObject("btnAlarm.Image")));
            this.btnAlarm.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAlarm.Location = new System.Drawing.Point(189, 2);
            this.btnAlarm.Margin = new System.Windows.Forms.Padding(1);
            this.btnAlarm.Name = "btnAlarm";
            this.btnAlarm.Size = new System.Drawing.Size(90, 80);
            this.btnAlarm.TabIndex = 30;
            this.btnAlarm.Text = "Alarm";
            this.btnAlarm.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAlarm.UseVisualStyleBackColor = false;
            this.btnAlarm.Click += new System.EventHandler(this.OnMenuButtonCliceked);
            // 
            // ucNavigation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.plTop2);
            this.Name = "ucNavigation";
            this.Size = new System.Drawing.Size(1280, 110);
            this.plTop2.ResumeLayout(false);
            this.plRight.ResumeLayout(false);
            this.plLeft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAlarm;
        private System.Windows.Forms.Button btnMain;
        private System.Windows.Forms.Button btnSystem;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel plTop2;
        private System.Windows.Forms.Panel plRight;
        private System.Windows.Forms.Panel plLeft;
        private System.Windows.Forms.Button btn_GlassData;
    }
}
