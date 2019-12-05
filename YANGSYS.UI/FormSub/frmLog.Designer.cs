namespace MainProgram
{
    partial class frmLog
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
            this.btnLinkLog = new System.Windows.Forms.Button();
            this.btnAlarmLog = new System.Windows.Forms.Button();
            this.btnHostLog = new System.Windows.Forms.Button();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.btnCimLog = new System.Windows.Forms.Button();
            this.Label8 = new System.Windows.Forms.Label();
            this.Panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLinkLog
            // 
            this.btnLinkLog.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLinkLog.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnLinkLog.Location = new System.Drawing.Point(869, 24);
            this.btnLinkLog.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLinkLog.Name = "btnLinkLog";
            this.btnLinkLog.Size = new System.Drawing.Size(279, 32);
            this.btnLinkLog.TabIndex = 41;
            this.btnLinkLog.Text = "LINK";
            this.btnLinkLog.UseVisualStyleBackColor = true;
            // 
            // btnAlarmLog
            // 
            this.btnAlarmLog.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAlarmLog.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAlarmLog.Location = new System.Drawing.Point(587, 24);
            this.btnAlarmLog.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAlarmLog.Name = "btnAlarmLog";
            this.btnAlarmLog.Size = new System.Drawing.Size(283, 32);
            this.btnAlarmLog.TabIndex = 37;
            this.btnAlarmLog.Text = "ALARM";
            this.btnAlarmLog.UseVisualStyleBackColor = true;
            // 
            // btnHostLog
            // 
            this.btnHostLog.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnHostLog.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnHostLog.Location = new System.Drawing.Point(297, 24);
            this.btnHostLog.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHostLog.Name = "btnHostLog";
            this.btnHostLog.Size = new System.Drawing.Size(291, 32);
            this.btnHostLog.TabIndex = 36;
            this.btnHostLog.Text = "HOST";
            this.btnHostLog.UseVisualStyleBackColor = true;
            // 
            // Panel4
            // 
            this.Panel4.BackColor = System.Drawing.SystemColors.Control;
            this.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel4.Controls.Add(this.btnLinkLog);
            this.Panel4.Controls.Add(this.btnAlarmLog);
            this.Panel4.Controls.Add(this.btnHostLog);
            this.Panel4.Controls.Add(this.btnCimLog);
            this.Panel4.Controls.Add(this.Label8);
            this.Panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel4.Location = new System.Drawing.Point(0, 0);
            this.Panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Panel4.Name = "Panel4";
            this.Panel4.Size = new System.Drawing.Size(1144, 787);
            this.Panel4.TabIndex = 21;
            // 
            // btnCimLog
            // 
            this.btnCimLog.BackColor = System.Drawing.Color.Gray;
            this.btnCimLog.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCimLog.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCimLog.Location = new System.Drawing.Point(0, 24);
            this.btnCimLog.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCimLog.Name = "btnCimLog";
            this.btnCimLog.Size = new System.Drawing.Size(298, 32);
            this.btnCimLog.TabIndex = 35;
            this.btnCimLog.Text = "CIM";
            this.btnCimLog.UseVisualStyleBackColor = false;
            // 
            // Label8
            // 
            this.Label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label8.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label8.ForeColor = System.Drawing.Color.White;
            this.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label8.Location = new System.Drawing.Point(-1, 0);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(1150, 24);
            this.Label8.TabIndex = 34;
            this.Label8.Text = "LOG MONITORING";
            this.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 787);
            this.Controls.Add(this.Panel4);
            this.Name = "frmLog";
            this.Text = "Log";
            this.Panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button btnLinkLog;
        internal System.Windows.Forms.Button btnAlarmLog;
        internal System.Windows.Forms.Button btnHostLog;
        internal System.Windows.Forms.Panel Panel4;
        internal System.Windows.Forms.Button btnCimLog;
        internal System.Windows.Forms.Label Label8;
    }
}