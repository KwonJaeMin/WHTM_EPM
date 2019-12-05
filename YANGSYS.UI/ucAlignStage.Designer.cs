namespace WindowsFormsApplication1
{
    partial class ucAlignStage
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
            this.pnl_Status = new System.Windows.Forms.Panel();
            this.lbl_Gls_Exist = new System.Windows.Forms.Label();
            this.lbl_Align_Status = new System.Windows.Forms.Label();
            this.pnl_Status.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_Status
            // 
            this.pnl_Status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_Status.Controls.Add(this.lbl_Align_Status);
            this.pnl_Status.Controls.Add(this.lbl_Gls_Exist);
            this.pnl_Status.Location = new System.Drawing.Point(3, 3);
            this.pnl_Status.Name = "pnl_Status";
            this.pnl_Status.Size = new System.Drawing.Size(152, 31);
            this.pnl_Status.TabIndex = 226;
            // 
            // lbl_Gls_Exist
            // 
            this.lbl_Gls_Exist.BackColor = System.Drawing.Color.Gray;
            this.lbl_Gls_Exist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Gls_Exist.Font = new System.Drawing.Font("Malgun Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_Gls_Exist.ForeColor = System.Drawing.Color.Black;
            this.lbl_Gls_Exist.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_Gls_Exist.Location = new System.Drawing.Point(3, 4);
            this.lbl_Gls_Exist.Name = "lbl_Gls_Exist";
            this.lbl_Gls_Exist.Size = new System.Drawing.Size(113, 21);
            this.lbl_Gls_Exist.TabIndex = 215;
            this.lbl_Gls_Exist.Text = "EMPTY";
            this.lbl_Gls_Exist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Align_Status
            // 
            this.lbl_Align_Status.BackColor = System.Drawing.Color.White;
            this.lbl_Align_Status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Align_Status.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_Align_Status.ForeColor = System.Drawing.Color.Black;
            this.lbl_Align_Status.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_Align_Status.Location = new System.Drawing.Point(116, 4);
            this.lbl_Align_Status.Name = "lbl_Align_Status";
            this.lbl_Align_Status.Size = new System.Drawing.Size(31, 21);
            this.lbl_Align_Status.TabIndex = 225;
            this.lbl_Align_Status.Text = "LR";
            this.lbl_Align_Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucAlignStage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pnl_Status);
            this.Name = "ucAlignStage";
            this.Size = new System.Drawing.Size(159, 37);
            this.pnl_Status.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel pnl_Status;
        internal System.Windows.Forms.Label lbl_Gls_Exist;
        internal System.Windows.Forms.Label lbl_Align_Status;
    }
}
