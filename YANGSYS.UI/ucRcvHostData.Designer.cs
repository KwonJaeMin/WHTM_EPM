namespace Widgets
{
    partial class ucRcvHostData
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
            this.lblRcvHostData = new System.Windows.Forms.Label();
            this.Label13 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblRcvHostData
            // 
            this.lblRcvHostData.BackColor = System.Drawing.Color.White;
            this.lblRcvHostData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRcvHostData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRcvHostData.Font = new System.Drawing.Font("Malgun Gothic", 9.75F);
            this.lblRcvHostData.ForeColor = System.Drawing.Color.Black;
            this.lblRcvHostData.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblRcvHostData.Location = new System.Drawing.Point(128, 0);
            this.lblRcvHostData.Name = "lblRcvHostData";
            this.lblRcvHostData.Size = new System.Drawing.Size(828, 24);
            this.lblRcvHostData.TabIndex = 20;
            this.lblRcvHostData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label13
            // 
            this.Label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label13.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label13.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label13.ForeColor = System.Drawing.Color.White;
            this.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label13.Location = new System.Drawing.Point(0, 0);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(128, 24);
            this.Label13.TabIndex = 19;
            this.Label13.Text = "RCV HOST DATA";
            this.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucRcvHostData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.lblRcvHostData);
            this.Controls.Add(this.Label13);
            this.Name = "ucRcvHostData";
            this.Size = new System.Drawing.Size(956, 24);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label lblRcvHostData;
        internal System.Windows.Forms.Label Label13;
    }
}
