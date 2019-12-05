namespace YANGSYS.UI.WHTM
{
    partial class ucButtonTop
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
            this.lbTitle = new System.Windows.Forms.Label();
            this.picLEDRed = new System.Windows.Forms.PictureBox();
            this.picLEDGreen = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picLEDRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLEDGreen)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.BackColor = System.Drawing.Color.Transparent;
            this.lbTitle.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbTitle.Location = new System.Drawing.Point(36, 9);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(49, 25);
            this.lbTitle.TabIndex = 2;
            this.lbTitle.Text = "Title";
            // 
            // picLEDRed
            // 
            this.picLEDRed.Image = global::YANGSYS.UI.WHTM.Properties.Resources.led_red;
            this.picLEDRed.Location = new System.Drawing.Point(6, 10);
            this.picLEDRed.Margin = new System.Windows.Forms.Padding(0);
            this.picLEDRed.Name = "picLEDRed";
            this.picLEDRed.Size = new System.Drawing.Size(23, 23);
            this.picLEDRed.TabIndex = 3;
            this.picLEDRed.TabStop = false;
            // 
            // picLEDGreen
            // 
            this.picLEDGreen.Image = global::YANGSYS.UI.WHTM.Properties.Resources.led_green;
            this.picLEDGreen.Location = new System.Drawing.Point(109, 11);
            this.picLEDGreen.Margin = new System.Windows.Forms.Padding(0);
            this.picLEDGreen.Name = "picLEDGreen";
            this.picLEDGreen.Size = new System.Drawing.Size(23, 23);
            this.picLEDGreen.TabIndex = 4;
            this.picLEDGreen.TabStop = false;
            this.picLEDGreen.Visible = false;
            // 
            // ucButtonTop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::YANGSYS.UI.WHTM.Properties.Resources.top_bar_center_bg;
            this.Controls.Add(this.picLEDGreen);
            this.Controls.Add(this.picLEDRed);
            this.Controls.Add(this.lbTitle);
            this.Name = "ucButtonTop";
            this.Size = new System.Drawing.Size(162, 44);
            ((System.ComponentModel.ISupportInitialize)(this.picLEDRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLEDGreen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.PictureBox picLEDRed;
        private System.Windows.Forms.PictureBox picLEDGreen;
    }
}
