namespace YANGSYS.UI.WHTM
{
    partial class ucButtonImg
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
            this.plBtn = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // plBtn
            // 
            this.plBtn.BackgroundImage = global::YANGSYS.UI.WHTM.Properties.Resources.btn_power2;
            this.plBtn.Location = new System.Drawing.Point(3, 3);
            this.plBtn.Name = "plBtn";
            this.plBtn.Size = new System.Drawing.Size(55, 48);
            this.plBtn.TabIndex = 0;
            // 
            // ucButtonImg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Controls.Add(this.plBtn);
            this.Name = "ucButtonImg";
            this.Size = new System.Drawing.Size(71, 58);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plBtn;
    }
}
