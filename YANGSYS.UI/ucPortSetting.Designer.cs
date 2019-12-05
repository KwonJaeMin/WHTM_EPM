namespace YANGSYS.UI.WHTM
{
    partial class ucPortSetting
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
            this.cmbSelect = new System.Windows.Forms.ComboBox();
            this.btnEnable = new System.Windows.Forms.Button();
            this.btnAGV = new System.Windows.Forms.Button();
            this.Label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbSelect
            // 
            this.cmbSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelect.FormattingEnabled = true;
            this.cmbSelect.Location = new System.Drawing.Point(4, 82);
            this.cmbSelect.Name = "cmbSelect";
            this.cmbSelect.Size = new System.Drawing.Size(78, 20);
            this.cmbSelect.TabIndex = 192;
            // 
            // btnEnable
            // 
            this.btnEnable.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnEnable.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnEnable.Location = new System.Drawing.Point(3, 53);
            this.btnEnable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEnable.Name = "btnEnable";
            this.btnEnable.Size = new System.Drawing.Size(80, 29);
            this.btnEnable.TabIndex = 191;
            this.btnEnable.Tag = "1";
            this.btnEnable.Text = "ENABLE";
            this.btnEnable.UseVisualStyleBackColor = true;
            // 
            // btnAGV
            // 
            this.btnAGV.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAGV.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAGV.Location = new System.Drawing.Point(3, 23);
            this.btnAGV.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAGV.Name = "btnAGV";
            this.btnAGV.Size = new System.Drawing.Size(80, 31);
            this.btnAGV.TabIndex = 190;
            this.btnAGV.Tag = "1";
            this.btnAGV.Text = "AGV";
            this.btnAGV.UseVisualStyleBackColor = true;
            // 
            // Label7
            // 
            this.Label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label7.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label7.ForeColor = System.Drawing.Color.White;
            this.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label7.Location = new System.Drawing.Point(3, 0);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(80, 24);
            this.Label7.TabIndex = 189;
            this.Label7.Text = "P01";
            this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucPortSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.cmbSelect);
            this.Controls.Add(this.btnEnable);
            this.Controls.Add(this.btnAGV);
            this.Controls.Add(this.Label7);
            this.Name = "ucPortSetting";
            this.Size = new System.Drawing.Size(85, 106);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ComboBox cmbSelect;
        internal System.Windows.Forms.Button btnEnable;
        internal System.Windows.Forms.Button btnAGV;
        internal System.Windows.Forms.Label Label7;
    }
}
