namespace YANGSYS.UI.WHTM
{
    partial class frmGlassData
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
            this.Label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnReceve = new System.Windows.Forms.Button();
            this.btnProc = new System.Windows.Forms.Button();
            this.btnSentOut = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnGlassDataRequest = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.ucGlassData1 = new YANGSYS.UI.WHTM.ucGlassData();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label7
            // 
            this.Label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.ForeColor = System.Drawing.Color.White;
            this.Label7.Location = new System.Drawing.Point(0, 0);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(632, 29);
            this.Label7.TabIndex = 98;
            this.Label7.Text = "GLASS DATA";
            this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnReceve);
            this.panel1.Controls.Add(this.btnProc);
            this.panel1.Controls.Add(this.btnSentOut);
            this.panel1.Controls.Add(this.btnModify);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 562);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(632, 60);
            this.panel1.TabIndex = 137;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(438, 9);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(184, 40);
            this.btnClose.TabIndex = 55;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReceve
            // 
            this.btnReceve.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnReceve.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnReceve.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnReceve.Location = new System.Drawing.Point(0, 9);
            this.btnReceve.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReceve.Name = "btnReceve";
            this.btnReceve.Size = new System.Drawing.Size(91, 40);
            this.btnReceve.TabIndex = 54;
            this.btnReceve.Text = "RECEVE";
            this.btnReceve.UseVisualStyleBackColor = false;
            this.btnReceve.Click += new System.EventHandler(this.btnReceve_Click);
            // 
            // btnProc
            // 
            this.btnProc.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnProc.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnProc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnProc.Location = new System.Drawing.Point(101, 9);
            this.btnProc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnProc.Name = "btnProc";
            this.btnProc.Size = new System.Drawing.Size(91, 40);
            this.btnProc.TabIndex = 54;
            this.btnProc.Text = "PROC";
            this.btnProc.UseVisualStyleBackColor = false;
            this.btnProc.Click += new System.EventHandler(this.btnProc_Click);
            // 
            // btnSentOut
            // 
            this.btnSentOut.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnSentOut.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSentOut.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSentOut.Location = new System.Drawing.Point(203, 9);
            this.btnSentOut.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSentOut.Name = "btnSentOut";
            this.btnSentOut.Size = new System.Drawing.Size(91, 40);
            this.btnSentOut.TabIndex = 54;
            this.btnSentOut.Text = "SENT OUT";
            this.btnSentOut.UseVisualStyleBackColor = false;
            this.btnSentOut.Click += new System.EventHandler(this.btnSentOut_Click);
            // 
            // btnModify
            // 
            this.btnModify.BackColor = System.Drawing.Color.Tomato;
            this.btnModify.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnModify.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnModify.Location = new System.Drawing.Point(314, 9);
            this.btnModify.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(107, 40);
            this.btnModify.TabIndex = 54;
            this.btnModify.Text = "CHANGE";
            this.btnModify.UseVisualStyleBackColor = false;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnGlassDataRequest
            // 
            this.btnGlassDataRequest.BackColor = System.Drawing.Color.Yellow;
            this.btnGlassDataRequest.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnGlassDataRequest.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnGlassDataRequest.Location = new System.Drawing.Point(438, 52);
            this.btnGlassDataRequest.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGlassDataRequest.Name = "btnGlassDataRequest";
            this.btnGlassDataRequest.Size = new System.Drawing.Size(184, 40);
            this.btnGlassDataRequest.TabIndex = 54;
            this.btnGlassDataRequest.Text = "GLASS DATA REQUEST";
            this.btnGlassDataRequest.UseVisualStyleBackColor = false;
            this.btnGlassDataRequest.Click += new System.EventHandler(this.btnGlassDataRequest_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.btnGlassDataRequest);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label28);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 463);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(632, 99);
            this.panel2.TabIndex = 139;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox2.Location = new System.Drawing.Point(109, 33);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(207, 23);
            this.textBox2.TabIndex = 156;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox1.Location = new System.Drawing.Point(109, 60);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(207, 23);
            this.textBox1.TabIndex = 156;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1:GLS ID",
            "2:GLS CODE"});
            this.comboBox1.Location = new System.Drawing.Point(109, 5);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(207, 23);
            this.comboBox1.TabIndex = 155;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(3, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 24);
            this.label3.TabIndex = 153;
            this.label3.Text = "OPTION";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(3, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 24);
            this.label2.TabIndex = 153;
            this.label2.Text = "GLS ID";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label28
            // 
            this.label28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label28.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.label28.ForeColor = System.Drawing.Color.Black;
            this.label28.Location = new System.Drawing.Point(3, 59);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(104, 24);
            this.label28.TabIndex = 153;
            this.label28.Text = "GLS CODE";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucGlassData1
            // 
            this.ucGlassData1.ARRAY = "";
            this.ucGlassData1.ASSEMBLED = "";
            this.ucGlassData1.BackColor = System.Drawing.Color.Gray;
            this.ucGlassData1.CF = "";
            this.ucGlassData1.CIMPCData1 = "";
            this.ucGlassData1.CIMPCData2 = "0000000000000000";
            this.ucGlassData1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucGlassData1.DummyType = "";
            this.ucGlassData1.FIRSTLOT = "";
            this.ucGlassData1.GlassCodeXXYYYY = "";
            this.ucGlassData1.GlassCodeZZZ = "000";
            this.ucGlassData1.GlassID = "";
            this.ucGlassData1.GlassJudgeCode = "";
            this.ucGlassData1.GlassType1 = "0000000000000000";
            this.ucGlassData1.GlassType2 = "0000000000000000";
            this.ucGlassData1.GLSANGLE = "";
            this.ucGlassData1.GLSSIZE = "";
            this.ucGlassData1.GLSTHICK = "";
            this.ucGlassData1.InspectionFlag1 = "0000000000000000";
            this.ucGlassData1.InspectionFlag2 = "0000000000000000";
            this.ucGlassData1.JudgeFlag1 = "0000000000000000";
            this.ucGlassData1.JudgeFlag2 = "0000000000000000";
            this.ucGlassData1.LASTLOT = "";
            this.ucGlassData1.Location = new System.Drawing.Point(0, 29);
            this.ucGlassData1.LotID = "";
            this.ucGlassData1.Mode = "";
            this.ucGlassData1.ModifyMode = false;
            this.ucGlassData1.Name = "ucGlassData1";
            this.ucGlassData1.OperID = "";
            this.ucGlassData1.PNLGRADE = "";
            this.ucGlassData1.PPID = "";
            this.ucGlassData1.ProcFlag1 = "0000000000000000";
            this.ucGlassData1.ProcFlag2 = "0000000000000000";
            this.ucGlassData1.ProdID = "";
            this.ucGlassData1.ReservedData1 = "";
            this.ucGlassData1.ReservedData2 = "";
            this.ucGlassData1.ReservedData3 = "";
            this.ucGlassData1.ReservedData4 = "";
            this.ucGlassData1.ReservedData5 = "";
            this.ucGlassData1.ReservedData6 = "";
            this.ucGlassData1.Size = new System.Drawing.Size(632, 434);
            this.ucGlassData1.SkipFlag1 = "0000000000000000";
            this.ucGlassData1.SkipFlag2 = "0000000000000000";
            this.ucGlassData1.TabIndex = 140;
            // 
            // frmGlassData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(632, 622);
            this.ControlBox = false;
            this.Controls.Add(this.ucGlassData1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Label7);
            this.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmGlassData";
            this.Text = "Glass Data";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmGlassData_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label Label7;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Button btnGlassDataRequest;
        internal System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox comboBox1;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        internal System.Windows.Forms.Button btnModify;
        internal System.Windows.Forms.Button btnSentOut;
        internal System.Windows.Forms.Button btnReceve;
        internal System.Windows.Forms.Button btnProc;
        private ucGlassData ucGlassData1;
    }
}