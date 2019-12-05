namespace YANGSYS.UI.WHTM.SubForm
{
    partial class frmVCRMode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVCRMode));
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.btnVCROffErrSkip = new System.Windows.Forms.Button();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.lblCurrentVCRMode = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnVCROnErrKeyIn = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.btnVcrOnErrSkip = new System.Windows.Forms.Button();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.GroupBox2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.btnVCROffErrSkip);
            this.GroupBox2.Controls.Add(this.Label8);
            this.GroupBox2.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.GroupBox2.Location = new System.Drawing.Point(3, 259);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(648, 72);
            this.GroupBox2.TabIndex = 50;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "VCR OFF";
            // 
            // btnVCROffErrSkip
            // 
            this.btnVCROffErrSkip.BackColor = System.Drawing.Color.White;
            this.btnVCROffErrSkip.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnVCROffErrSkip.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnVCROffErrSkip.Location = new System.Drawing.Point(504, 21);
            this.btnVCROffErrSkip.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnVCROffErrSkip.Name = "btnVCROffErrSkip";
            this.btnVCROffErrSkip.Size = new System.Drawing.Size(136, 40);
            this.btnVCROffErrSkip.TabIndex = 29;
            this.btnVCROffErrSkip.Text = "ERROR-SKIP";
            this.btnVCROffErrSkip.UseVisualStyleBackColor = false;
            this.btnVCROffErrSkip.Click += new System.EventHandler(this.btnVCROffErrSkip_Click);
            // 
            // Label8
            // 
            this.Label8.BackColor = System.Drawing.SystemColors.Control;
            this.Label8.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Label8.ForeColor = System.Drawing.Color.Black;
            this.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label8.Location = new System.Drawing.Point(8, 21);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(488, 40);
            this.Label8.TabIndex = 8;
            this.Label8.Text = "When the VCR mode is OFF, the equipment ignores reading the glass ID. The Equipme" +
                "nt should set the GLSID as the Host Information (S2F103 - HGLSID).";
            this.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label7
            // 
            this.Label7.BackColor = System.Drawing.SystemColors.Control;
            this.Label7.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Label7.ForeColor = System.Drawing.Color.Black;
            this.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label7.Location = new System.Drawing.Point(8, 173);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(488, 24);
            this.Label7.TabIndex = 33;
            this.Label7.Text = "The Equipment should set the GLSID as the inputted Glass ID (RGLSID).";
            this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.SystemColors.Control;
            this.Label1.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label1.Location = new System.Drawing.Point(8, 61);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(488, 24);
            this.Label1.TabIndex = 32;
            this.Label1.Text = "The Equipment should set the GLSID as the Host Information(S2F103-HGLSID).";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCurrentVCRMode
            // 
            this.lblCurrentVCRMode.BackColor = System.Drawing.Color.Lime;
            this.lblCurrentVCRMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCurrentVCRMode.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblCurrentVCRMode.ForeColor = System.Drawing.Color.Black;
            this.lblCurrentVCRMode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCurrentVCRMode.Location = new System.Drawing.Point(227, 11);
            this.lblCurrentVCRMode.Name = "lblCurrentVCRMode";
            this.lblCurrentVCRMode.Size = new System.Drawing.Size(424, 24);
            this.lblCurrentVCRMode.TabIndex = 48;
            this.lblCurrentVCRMode.Text = "VCR ON(ERROR-SKIP)";
            this.lblCurrentVCRMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label3
            // 
            this.Label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label3.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label3.ForeColor = System.Drawing.Color.White;
            this.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label3.Location = new System.Drawing.Point(3, 11);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(224, 24);
            this.Label3.TabIndex = 47;
            this.Label3.Text = "CURRENT VCR MODE";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnClose.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(507, 5);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(136, 40);
            this.btnClose.TabIndex = 46;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnVCROnErrKeyIn
            // 
            this.btnVCROnErrKeyIn.BackColor = System.Drawing.Color.Yellow;
            this.btnVCROnErrKeyIn.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnVCROnErrKeyIn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnVCROnErrKeyIn.Location = new System.Drawing.Point(504, 93);
            this.btnVCROnErrKeyIn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnVCROnErrKeyIn.Name = "btnVCROnErrKeyIn";
            this.btnVCROnErrKeyIn.Size = new System.Drawing.Size(136, 104);
            this.btnVCROnErrKeyIn.TabIndex = 31;
            this.btnVCROnErrKeyIn.Text = "ERROR-KEY IN";
            this.btnVCROnErrKeyIn.UseVisualStyleBackColor = false;
            this.btnVCROnErrKeyIn.Click += new System.EventHandler(this.btnVCROnErrKeyIn_Click);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.Label7);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.btnVCROnErrKeyIn);
            this.GroupBox1.Controls.Add(this.btnVcrOnErrSkip);
            this.GroupBox1.Controls.Add(this.Label6);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.GroupBox1.Location = new System.Drawing.Point(3, 43);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(648, 208);
            this.GroupBox1.TabIndex = 49;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "VCR ON";
            // 
            // btnVcrOnErrSkip
            // 
            this.btnVcrOnErrSkip.BackColor = System.Drawing.Color.Lime;
            this.btnVcrOnErrSkip.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnVcrOnErrSkip.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnVcrOnErrSkip.Location = new System.Drawing.Point(504, 21);
            this.btnVcrOnErrSkip.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnVcrOnErrSkip.Name = "btnVcrOnErrSkip";
            this.btnVcrOnErrSkip.Size = new System.Drawing.Size(136, 56);
            this.btnVcrOnErrSkip.TabIndex = 30;
            this.btnVcrOnErrSkip.Text = "ERROR-SKIP";
            this.btnVcrOnErrSkip.UseVisualStyleBackColor = false;
            this.btnVcrOnErrSkip.Click += new System.EventHandler(this.btnVcrOnErrSkip_Click);
            // 
            // Label6
            // 
            this.Label6.BackColor = System.Drawing.SystemColors.Control;
            this.Label6.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Label6.ForeColor = System.Drawing.Color.Black;
            this.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label6.Location = new System.Drawing.Point(8, 101);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(488, 72);
            this.Label6.TabIndex = 9;
            this.Label6.Text = resources.GetString("Label6.Text");
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label5
            // 
            this.Label5.BackColor = System.Drawing.SystemColors.Control;
            this.Label5.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label5.Location = new System.Drawing.Point(8, 21);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(488, 40);
            this.Label5.TabIndex = 8;
            this.Label5.Text = "Read the Veri Code ID of the glass by using the VCR. If an error is happened when" +
                " VCR try to read the Veri Code ID.";
            this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.Color.Black;
            this.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label2.Font = new System.Drawing.Font("Malgun Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Label2.ForeColor = System.Drawing.Color.White;
            this.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label2.Location = new System.Drawing.Point(2, 2);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(660, 32);
            this.Label2.TabIndex = 45;
            this.Label2.Text = "VCR MODE CHANGE";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(2, 370);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(660, 52);
            this.panel1.TabIndex = 51;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.Label3);
            this.panel2.Controls.Add(this.GroupBox2);
            this.panel2.Controls.Add(this.GroupBox1);
            this.panel2.Controls.Add(this.lblCurrentVCRMode);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(2, 34);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(660, 336);
            this.panel2.TabIndex = 52;
            // 
            // frmVCRMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(664, 424);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmVCRMode";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VCR MODE";
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.Button btnVCROffErrSkip;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label lblCurrentVCRMode;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Button btnVCROnErrKeyIn;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Button btnVcrOnErrSkip;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}