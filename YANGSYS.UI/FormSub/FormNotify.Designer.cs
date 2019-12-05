namespace YANGSYS.UI
{
    partial class FormNotify
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
            this.lboccurredTime = new System.Windows.Forms.Label();
            this.lbCount = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lbMessage = new System.Windows.Forms.Label();
            this.lbTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.btnBuzzOff.Text = "부저 OFF";
            this.btnBuzzOff.UseVisualStyleBackColor = false;
            this.btnBuzzOff.Click += new System.EventHandler(this.btnBuzzOff_Click);
            // 
            // lboccurredTime
            // 
            this.lboccurredTime.BackColor = System.Drawing.SystemColors.Control;
            this.lboccurredTime.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.lboccurredTime.ForeColor = System.Drawing.Color.Black;
            this.lboccurredTime.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lboccurredTime.Location = new System.Drawing.Point(-2, 150);
            this.lboccurredTime.Margin = new System.Windows.Forms.Padding(3);
            this.lboccurredTime.Name = "lboccurredTime";
            this.lboccurredTime.Size = new System.Drawing.Size(608, 28);
            this.lboccurredTime.TabIndex = 156;
            this.lboccurredTime.Text = "[OCCURRED TIME]";
            this.lboccurredTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.btnClose.Text = "닫기";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lbMessage
            // 
            this.lbMessage.BackColor = System.Drawing.Color.White;
            this.lbMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbMessage.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbMessage.ForeColor = System.Drawing.Color.Black;
            this.lbMessage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbMessage.Location = new System.Drawing.Point(-2, 30);
            this.lbMessage.Margin = new System.Windows.Forms.Padding(3);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(608, 120);
            this.lbMessage.TabIndex = 153;
            this.lbMessage.Text = "[MESSAGE HERE]";
            this.lbMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTitle
            // 
            this.lbTitle.BackColor = System.Drawing.Color.Black;
            this.lbTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTitle.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbTitle.Location = new System.Drawing.Point(30, -2);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(576, 32);
            this.lbTitle.TabIndex = 152;
            this.lbTitle.Text = "[TITLE HERE]";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormNotify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 239);
            this.ControlBox = false;
            this.Controls.Add(this.btnBuzzOff);
            this.Controls.Add(this.lboccurredTime);
            this.Controls.Add(this.lbCount);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbMessage);
            this.Controls.Add(this.lbTitle);
            this.Name = "FormNotify";
            this.Text = "알림";
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button btnBuzzOff;
        internal System.Windows.Forms.Label lboccurredTime;
        internal System.Windows.Forms.Label lbCount;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Label lbMessage;
        internal System.Windows.Forms.Label lbTitle;
    }
}