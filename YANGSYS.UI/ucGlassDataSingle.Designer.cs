namespace YANGSYS.UI.WHTM
{
    partial class ucGlassDataSingle
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
            this.txtRecipe = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtJudge = new System.Windows.Forms.TextBox();
            this.grbGlassData = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtGlassType = new System.Windows.Forms.TextBox();
            this.txtGlassCode = new System.Windows.Forms.TextBox();
            this.txtGlassID = new System.Windows.Forms.TextBox();
            this.txtLotID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grbGlassData.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtRecipe
            // 
            this.txtRecipe.BackColor = System.Drawing.Color.White;
            this.txtRecipe.Location = new System.Drawing.Point(327, 45);
            this.txtRecipe.Name = "txtRecipe";
            this.txtRecipe.ReadOnly = true;
            this.txtRecipe.Size = new System.Drawing.Size(105, 21);
            this.txtRecipe.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.Control;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(230, 46);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 21);
            this.label10.TabIndex = 12;
            this.label10.Text = "RECIPE :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtJudge
            // 
            this.txtJudge.BackColor = System.Drawing.Color.White;
            this.txtJudge.Location = new System.Drawing.Point(327, 16);
            this.txtJudge.Name = "txtJudge";
            this.txtJudge.ReadOnly = true;
            this.txtJudge.Size = new System.Drawing.Size(105, 21);
            this.txtJudge.TabIndex = 11;
            // 
            // grbGlassData
            // 
            this.grbGlassData.Controls.Add(this.txtRecipe);
            this.grbGlassData.Controls.Add(this.label10);
            this.grbGlassData.Controls.Add(this.txtJudge);
            this.grbGlassData.Controls.Add(this.label9);
            this.grbGlassData.Controls.Add(this.txtGlassType);
            this.grbGlassData.Controls.Add(this.txtGlassCode);
            this.grbGlassData.Controls.Add(this.txtGlassID);
            this.grbGlassData.Controls.Add(this.txtLotID);
            this.grbGlassData.Controls.Add(this.label4);
            this.grbGlassData.Controls.Add(this.label3);
            this.grbGlassData.Controls.Add(this.label2);
            this.grbGlassData.Controls.Add(this.label1);
            this.grbGlassData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbGlassData.Location = new System.Drawing.Point(21, 454);
            this.grbGlassData.Name = "grbGlassData";
            this.grbGlassData.Size = new System.Drawing.Size(500, 99);
            this.grbGlassData.TabIndex = 2;
            this.grbGlassData.TabStop = false;
            this.grbGlassData.Text = "GLS DATA";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(230, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 21);
            this.label9.TabIndex = 10;
            this.label9.Text = "GLS JUDGE  :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGlassType
            // 
            this.txtGlassType.BackColor = System.Drawing.Color.White;
            this.txtGlassType.Location = new System.Drawing.Point(327, 71);
            this.txtGlassType.Name = "txtGlassType";
            this.txtGlassType.ReadOnly = true;
            this.txtGlassType.Size = new System.Drawing.Size(105, 21);
            this.txtGlassType.TabIndex = 9;
            // 
            // txtGlassCode
            // 
            this.txtGlassCode.BackColor = System.Drawing.Color.White;
            this.txtGlassCode.Location = new System.Drawing.Point(104, 72);
            this.txtGlassCode.Name = "txtGlassCode";
            this.txtGlassCode.ReadOnly = true;
            this.txtGlassCode.Size = new System.Drawing.Size(105, 21);
            this.txtGlassCode.TabIndex = 8;
            // 
            // txtGlassID
            // 
            this.txtGlassID.BackColor = System.Drawing.Color.White;
            this.txtGlassID.Location = new System.Drawing.Point(104, 45);
            this.txtGlassID.Name = "txtGlassID";
            this.txtGlassID.ReadOnly = true;
            this.txtGlassID.Size = new System.Drawing.Size(105, 21);
            this.txtGlassID.TabIndex = 7;
            // 
            // txtLotID
            // 
            this.txtLotID.BackColor = System.Drawing.Color.White;
            this.txtLotID.Location = new System.Drawing.Point(104, 17);
            this.txtLotID.Name = "txtLotID";
            this.txtLotID.ReadOnly = true;
            this.txtLotID.Size = new System.Drawing.Size(105, 21);
            this.txtLotID.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(230, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 21);
            this.label4.TabIndex = 5;
            this.label4.Text = "GLS TYPE :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "GLS CODE :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "GLS ID :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "LOT ID :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ucGlassDataSingle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.grbGlassData);
            this.Name = "ucGlassDataSingle";
            this.Size = new System.Drawing.Size(595, 556);
            this.grbGlassData.ResumeLayout(false);
            this.grbGlassData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtRecipe;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtJudge;
        private System.Windows.Forms.GroupBox grbGlassData;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtGlassType;
        private System.Windows.Forms.TextBox txtGlassCode;
        private System.Windows.Forms.TextBox txtGlassID;
        private System.Windows.Forms.TextBox txtLotID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
