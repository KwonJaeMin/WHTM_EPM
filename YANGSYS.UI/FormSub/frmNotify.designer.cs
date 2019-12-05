namespace YANGSYS.UI
{
    partial class frmNotify
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBuzzOff = new System.Windows.Forms.Button();
            this.lbloccurredTime = new System.Windows.Forms.Label();
            this.lbCount = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnlButtonBack
            // 
            this.pnlButtonBack.Location = new System.Drawing.Point(0, 200);
            this.pnlButtonBack.Size = new System.Drawing.Size(603, 39);
            // 
            // btnBuzzOff
            // 
            this.btnBuzzOff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnBuzzOff.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnBuzzOff.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBuzzOff.Location = new System.Drawing.Point(6, 190);
            this.btnBuzzOff.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBuzzOff.Name = "btnBuzzOff";
            this.btnBuzzOff.Size = new System.Drawing.Size(136, 40);
            this.btnBuzzOff.TabIndex = 157;
            this.btnBuzzOff.Text = "BUZZER OFF";
            this.btnBuzzOff.UseVisualStyleBackColor = false;
            this.btnBuzzOff.Click += new System.EventHandler(this.btnBuzzOff_Click);
            // 
            // lbloccurredTime
            // 
            this.lbloccurredTime.BackColor = System.Drawing.SystemColors.Control;
            this.lbloccurredTime.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbloccurredTime.ForeColor = System.Drawing.Color.Black;
            this.lbloccurredTime.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbloccurredTime.Location = new System.Drawing.Point(-2, 150);
            this.lbloccurredTime.Margin = new System.Windows.Forms.Padding(3);
            this.lbloccurredTime.Name = "lbloccurredTime";
            this.lbloccurredTime.Size = new System.Drawing.Size(608, 28);
            this.lbloccurredTime.TabIndex = 156;
            this.lbloccurredTime.Text = "[OCCURRED TIME]";
            this.lbloccurredTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbCount
            // 
            this.lbCount.BackColor = System.Drawing.Color.Black;
            this.lbCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbCount.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbCount.ForeColor = System.Drawing.Color.White;
            this.lbCount.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbCount.Location = new System.Drawing.Point(-2, -2);
            this.lbCount.Name = "lbCount";
            this.lbCount.Size = new System.Drawing.Size(35, 32);
            this.lbCount.TabIndex = 155;
            this.lbCount.Text = "99";
            this.lbCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnClose.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(414, 190);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(184, 40);
            this.btnClose.TabIndex = 154;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = System.Drawing.Color.White;
            this.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMessage.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMessage.ForeColor = System.Drawing.Color.Black;
            this.lblMessage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblMessage.Location = new System.Drawing.Point(-2, 30);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(3);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(608, 120);
            this.lblMessage.TabIndex = 153;
            this.lblMessage.Text = "[MESSAGE HERE]";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Black;
            this.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTitle.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTitle.Location = new System.Drawing.Point(30, -2);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(576, 32);
            this.lblTitle.TabIndex = 152;
            this.lblTitle.Text = "[TITLE HERE]";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmNotify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 239);
            this.ControlBox = false;
            this.Controls.Add(this.btnBuzzOff);
            this.Controls.Add(this.lbloccurredTime);
            this.Controls.Add(this.lbCount);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblTitle);
            this.Name = "frmNotify";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "알림";
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.lblMessage, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.lbCount, 0);
            this.Controls.SetChildIndex(this.lbloccurredTime, 0);
            this.Controls.SetChildIndex(this.btnBuzzOff, 0);
            this.Controls.SetChildIndex(this.pnlButtonBack, 0);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button btnBuzzOff;
        internal System.Windows.Forms.Label lbloccurredTime;
        internal System.Windows.Forms.Label lbCount;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Label lblMessage;
        internal System.Windows.Forms.Label lblTitle;
    }
}