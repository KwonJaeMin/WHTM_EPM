namespace YANGSYS.UI
{
    partial class frmHostTerminalMessage
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
            this.lblHostMessage = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.Label11 = new System.Windows.Forms.Label();
            this.lblTid = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.lblHostTitleMessage = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnBuzzer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnlButtonBack
            // 
            this.pnlButtonBack.Location = new System.Drawing.Point(0, 209);
            this.pnlButtonBack.Size = new System.Drawing.Size(760, 39);
            // 
            // lblHostMessage
            // 
            this.lblHostMessage.BackColor = System.Drawing.Color.White;
            this.lblHostMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHostMessage.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblHostMessage.ForeColor = System.Drawing.Color.Black;
            this.lblHostMessage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblHostMessage.Location = new System.Drawing.Point(8, 68);
            this.lblHostMessage.Margin = new System.Windows.Forms.Padding(3);
            this.lblHostMessage.Name = "lblHostMessage";
            this.lblHostMessage.Size = new System.Drawing.Size(744, 120);
            this.lblHostMessage.TabIndex = 88;
            this.lblHostMessage.Text = "[MESSAGE HERE]";
            this.lblHostMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTime
            // 
            this.lblTime.BackColor = System.Drawing.Color.White;
            this.lblTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTime.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTime.ForeColor = System.Drawing.Color.Black;
            this.lblTime.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTime.Location = new System.Drawing.Point(152, 44);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(208, 24);
            this.lblTime.TabIndex = 87;
            this.lblTime.Text = "2010-03-21 23:59:59";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label11
            // 
            this.Label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label11.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label11.ForeColor = System.Drawing.Color.White;
            this.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label11.Location = new System.Drawing.Point(8, 44);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(144, 24);
            this.Label11.TabIndex = 86;
            this.Label11.Text = "받은 시각";
            this.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTid
            // 
            this.lblTid.BackColor = System.Drawing.Color.White;
            this.lblTid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTid.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTid.ForeColor = System.Drawing.Color.Black;
            this.lblTid.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTid.Location = new System.Drawing.Point(712, 44);
            this.lblTid.Name = "lblTid";
            this.lblTid.Size = new System.Drawing.Size(40, 24);
            this.lblTid.TabIndex = 85;
            this.lblTid.Text = "1";
            this.lblTid.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label6
            // 
            this.Label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label6.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label6.ForeColor = System.Drawing.Color.White;
            this.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label6.Location = new System.Drawing.Point(672, 44);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(40, 24);
            this.Label6.TabIndex = 84;
            this.Label6.Text = "TID";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHostTitleMessage
            // 
            this.lblHostTitleMessage.BackColor = System.Drawing.Color.Black;
            this.lblHostTitleMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHostTitleMessage.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblHostTitleMessage.ForeColor = System.Drawing.Color.White;
            this.lblHostTitleMessage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblHostTitleMessage.Location = new System.Drawing.Point(0, 4);
            this.lblHostTitleMessage.Name = "lblHostTitleMessage";
            this.lblHostTitleMessage.Size = new System.Drawing.Size(760, 32);
            this.lblHostTitleMessage.TabIndex = 83;
            this.lblHostTitleMessage.Text = "HOST TERMINAL MESSAGE";
            this.lblHostTitleMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnClose.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(568, 204);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(184, 40);
            this.btnClose.TabIndex = 82;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnBuzzer
            // 
            this.btnBuzzer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnBuzzer.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnBuzzer.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBuzzer.Location = new System.Drawing.Point(8, 204);
            this.btnBuzzer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBuzzer.Name = "btnBuzzer";
            this.btnBuzzer.Size = new System.Drawing.Size(184, 40);
            this.btnBuzzer.TabIndex = 89;
            this.btnBuzzer.Text = "BUZZER OFF";
            this.btnBuzzer.UseVisualStyleBackColor = false;
            this.btnBuzzer.Click += new System.EventHandler(this.btnBuzzer_Click);
            // 
            // frmHostTerminalMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 248);
            this.ControlBox = false;
            this.Controls.Add(this.btnBuzzer);
            this.Controls.Add(this.lblHostMessage);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.Label11);
            this.Controls.Add(this.lblTid);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.lblHostTitleMessage);
            this.Controls.Add(this.btnClose);
            this.Name = "frmHostTerminalMessage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HostTerminalMSG";
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.lblHostTitleMessage, 0);
            this.Controls.SetChildIndex(this.Label6, 0);
            this.Controls.SetChildIndex(this.lblTid, 0);
            this.Controls.SetChildIndex(this.Label11, 0);
            this.Controls.SetChildIndex(this.lblTime, 0);
            this.Controls.SetChildIndex(this.lblHostMessage, 0);
            this.Controls.SetChildIndex(this.btnBuzzer, 0);
            this.Controls.SetChildIndex(this.pnlButtonBack, 0);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label lblHostMessage;
        internal System.Windows.Forms.Label lblTime;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.Label lblTid;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label lblHostTitleMessage;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Button btnBuzzer;


    }
}