namespace YANGSYS.UI.WHTM.FormSub
{
    partial class frmAutoRecipeMode
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
            this.btnCIMModeOff = new System.Windows.Forms.Button();
            this.Label8 = new System.Windows.Forms.Label();
            this.btnCIMModeON = new System.Windows.Forms.Button();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblCurrentVCRMode = new System.Windows.Forms.Label();
            this.GroupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.btnCIMModeOff);
            this.GroupBox2.Controls.Add(this.Label8);
            this.GroupBox2.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.GroupBox2.Location = new System.Drawing.Point(3, 188);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(648, 137);
            this.GroupBox2.TabIndex = 50;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "AUTO RECIPE CHANGE DISABLE";
            // 
            // btnCIMModeOff
            // 
            this.btnCIMModeOff.BackColor = System.Drawing.Color.White;
            this.btnCIMModeOff.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCIMModeOff.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCIMModeOff.Location = new System.Drawing.Point(504, 21);
            this.btnCIMModeOff.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCIMModeOff.Name = "btnCIMModeOff";
            this.btnCIMModeOff.Size = new System.Drawing.Size(136, 40);
            this.btnCIMModeOff.TabIndex = 29;
            this.btnCIMModeOff.Text = "DISABLE";
            this.btnCIMModeOff.UseVisualStyleBackColor = false;
            this.btnCIMModeOff.Click += new System.EventHandler(this.btnDisable_Click);
            // 
            // Label8
            // 
            this.Label8.BackColor = System.Drawing.SystemColors.Control;
            this.Label8.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Label8.ForeColor = System.Drawing.Color.Black;
            this.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label8.Location = new System.Drawing.Point(8, 21);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(488, 72);
            this.Label8.TabIndex = 8;
            this.Label8.Text = "Machine should change Recipe ID by manual";
            this.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCIMModeON
            // 
            this.btnCIMModeON.BackColor = System.Drawing.Color.Lime;
            this.btnCIMModeON.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCIMModeON.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCIMModeON.Location = new System.Drawing.Point(504, 21);
            this.btnCIMModeON.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCIMModeON.Name = "btnCIMModeON";
            this.btnCIMModeON.Size = new System.Drawing.Size(136, 56);
            this.btnCIMModeON.TabIndex = 30;
            this.btnCIMModeON.Text = "ENABLE";
            this.btnCIMModeON.UseVisualStyleBackColor = false;
            this.btnCIMModeON.Click += new System.EventHandler(this.btnEnable_Click);
            // 
            // Label5
            // 
            this.Label5.BackColor = System.Drawing.SystemColors.Control;
            this.Label5.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Label5.ForeColor = System.Drawing.Color.Black;
            this.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label5.Location = new System.Drawing.Point(8, 21);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(488, 56);
            this.Label5.TabIndex = 8;
            this.Label5.Text = "Machine should change Recipe ID by automatic.";
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
            this.Label2.TabIndex = 53;
            this.Label2.Text = "AUTO RECIPE CHANGE MODE";
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
            this.panel1.TabIndex = 54;
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
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.btnCIMModeON);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.GroupBox1.Location = new System.Drawing.Point(3, 44);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(648, 137);
            this.GroupBox1.TabIndex = 49;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "AUTO RECIPE CHANGE ENABLE";
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
            this.Label3.Text = "CURRENT";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.panel2.Size = new System.Drawing.Size(660, 388);
            this.panel2.TabIndex = 55;
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
            this.lblCurrentVCRMode.Text = "ENABLE";
            this.lblCurrentVCRMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmAutoRecipeMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(664, 424);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Label2);
            this.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmAutoRecipeMode";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Text = "AUTO RECIPE CHANGE MODE";
            this.GroupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.Button btnCIMModeOff;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Button btnCIMModeON;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label2;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.Label lblCurrentVCRMode;

    }
}