namespace YANGSYS.UI
{
    partial class frmHostControlMode
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
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.btnOffline = new System.Windows.Forms.Button();
            this.Label8 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.btnLocal = new System.Windows.Forms.Button();
            this.btnOnline = new System.Windows.Forms.Button();
            this.Label5 = new System.Windows.Forms.Label();
            this.lbHostModeStatus = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.cboEqpList = new System.Windows.Forms.ComboBox();
            this.GroupBox2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.btnOffline);
            this.GroupBox2.Controls.Add(this.Label8);
            this.GroupBox2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.GroupBox2.Location = new System.Drawing.Point(7, 247);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(488, 80);
            this.GroupBox2.TabIndex = 56;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "OFFLINE";
            // 
            // btnOffline
            // 
            this.btnOffline.BackColor = System.Drawing.Color.Red;
            this.btnOffline.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOffline.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOffline.Location = new System.Drawing.Point(344, 24);
            this.btnOffline.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOffline.Name = "btnOffline";
            this.btnOffline.Size = new System.Drawing.Size(136, 40);
            this.btnOffline.TabIndex = 29;
            this.btnOffline.Text = "OFFLINE";
            this.btnOffline.UseVisualStyleBackColor = false;
            this.btnOffline.Click += new System.EventHandler(this.btnOffline_Click);
            // 
            // Label8
            // 
            this.Label8.BackColor = System.Drawing.SystemColors.Control;
            this.Label8.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Label8.ForeColor = System.Drawing.Color.Black;
            this.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label8.Location = new System.Drawing.Point(8, 24);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(328, 40);
            this.Label8.TabIndex = 8;
            this.Label8.Text = "Operation of the Equipment is performed by Operator at the operator console on eq" +
                "uipment.";
            this.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.Label6);
            this.GroupBox1.Controls.Add(this.btnLocal);
            this.GroupBox1.Controls.Add(this.btnOnline);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.GroupBox1.Location = new System.Drawing.Point(7, 73);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(488, 170);
            this.GroupBox1.TabIndex = 55;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "ONLINE";
            // 
            // Label6
            // 
            this.Label6.BackColor = System.Drawing.SystemColors.Control;
            this.Label6.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Label6.ForeColor = System.Drawing.Color.Black;
            this.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label6.Location = new System.Drawing.Point(7, 108);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(328, 40);
            this.Label6.TabIndex = 33;
            this.Label6.Text = "Operation of the Equipment is implemented by direct action of an Operator.";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnLocal
            // 
            this.btnLocal.BackColor = System.Drawing.Color.Yellow;
            this.btnLocal.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLocal.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnLocal.Location = new System.Drawing.Point(344, 108);
            this.btnLocal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLocal.Name = "btnLocal";
            this.btnLocal.Size = new System.Drawing.Size(136, 40);
            this.btnLocal.TabIndex = 32;
            this.btnLocal.Text = "LOCAL";
            this.btnLocal.UseVisualStyleBackColor = false;
            this.btnLocal.Click += new System.EventHandler(this.btnLocal_Click);
            // 
            // btnOnline
            // 
            this.btnOnline.BackColor = System.Drawing.Color.Lime;
            this.btnOnline.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOnline.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOnline.Location = new System.Drawing.Point(344, 24);
            this.btnOnline.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOnline.Name = "btnOnline";
            this.btnOnline.Size = new System.Drawing.Size(136, 64);
            this.btnOnline.TabIndex = 30;
            this.btnOnline.Text = "REMOTE";
            this.btnOnline.UseVisualStyleBackColor = false;
            this.btnOnline.Click += new System.EventHandler(this.btnOnline_Click);
            // 
            // Label5
            // 
            this.Label5.BackColor = System.Drawing.SystemColors.Control;
            this.Label5.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label5.Location = new System.Drawing.Point(8, 24);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(328, 56);
            this.Label5.TabIndex = 8;
            this.Label5.Text = "The host must be able to access the nessary commands to operate the Equipment thr" +
                "ough the full process cycle in an automated manner.";
            this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbHostModeStatus
            // 
            this.lbHostModeStatus.BackColor = System.Drawing.Color.Lime;
            this.lbHostModeStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbHostModeStatus.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbHostModeStatus.ForeColor = System.Drawing.Color.Black;
            this.lbHostModeStatus.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbHostModeStatus.Location = new System.Drawing.Point(171, 39);
            this.lbHostModeStatus.Name = "lbHostModeStatus";
            this.lbHostModeStatus.Size = new System.Drawing.Size(324, 29);
            this.lbHostModeStatus.TabIndex = 54;
            this.lbHostModeStatus.Text = "ONLINE - REMOTE";
            this.lbHostModeStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label3
            // 
            this.Label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label3.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label3.ForeColor = System.Drawing.Color.White;
            this.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label3.Location = new System.Drawing.Point(7, 39);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(158, 29);
            this.Label3.TabIndex = 53;
            this.Label3.Text = "CURRENT MODE";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnClose.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(351, 335);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(136, 40);
            this.btnClose.TabIndex = 52;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.Color.Black;
            this.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label2.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Label2.ForeColor = System.Drawing.Color.White;
            this.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label2.Location = new System.Drawing.Point(-1, -1);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(504, 32);
            this.Label2.TabIndex = 51;
            this.Label2.Text = "HOST CONTROL CHANGE";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboEqpList
            // 
            this.cboEqpList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEqpList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboEqpList.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.cboEqpList.FormattingEnabled = true;
            this.cboEqpList.Location = new System.Drawing.Point(337, 39);
            this.cboEqpList.Name = "cboEqpList";
            this.cboEqpList.Size = new System.Drawing.Size(158, 25);
            this.cboEqpList.TabIndex = 62;
            this.cboEqpList.SelectedIndexChanged += new System.EventHandler(this.cboEqpList_SelectedIndexChanged);
            // 
            // frmHostControlMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 383);
            this.ControlBox = false;
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.lbHostModeStatus);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.cboEqpList);
            this.Name = "frmHostControlMode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HOST CONTROL";
            this.TopMost = true;
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.Button btnOffline;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Button btnOnline;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label lbHostModeStatus;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Label Label2;
        private System.Windows.Forms.ComboBox cboEqpList;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Button btnLocal;
    }
}