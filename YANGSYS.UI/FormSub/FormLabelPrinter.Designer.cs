namespace MainProgram
{
    partial class FormLabelPrinter
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
            this.lbTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReconnect = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbTestPrintOffline = new System.Windows.Forms.GroupBox();
            this.btnLabelTest = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtPartNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLOTID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.picBoxBarCode = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbxTestHeader = new System.Windows.Forms.TextBox();
            this.tbxTestLOTID = new System.Windows.Forms.TextBox();
            this.tbxTestBOXID = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.gbOnlineRePrint = new System.Windows.Forms.GroupBox();
            this.btnReload = new System.Windows.Forms.Button();
            this.cbLOTID = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnReprint = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gbTestPrintOffline.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxBarCode)).BeginInit();
            this.gbOnlineRePrint.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitle.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbTitle.Location = new System.Drawing.Point(0, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(533, 32);
            this.lbTitle.TabIndex = 63;
            this.lbTitle.Text = "LABEL PRINTER INFORMATION";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.btnClose.Location = new System.Drawing.Point(376, 336);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(145, 36);
            this.btnClose.TabIndex = 66;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReconnect);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(525, 49);
            this.groupBox1.TabIndex = 213;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Printer";
            // 
            // btnReconnect
            // 
            this.btnReconnect.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnReconnect.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReconnect.ForeColor = System.Drawing.Color.White;
            this.btnReconnect.Location = new System.Drawing.Point(376, 14);
            this.btnReconnect.Name = "btnReconnect";
            this.btnReconnect.Size = new System.Drawing.Size(136, 24);
            this.btnReconnect.TabIndex = 215;
            this.btnReconnect.Text = "Reconnect";
            this.btnReconnect.UseVisualStyleBackColor = false;
            this.btnReconnect.Click += new System.EventHandler(this.btnReconnect_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(236, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 17);
            this.label8.TabIndex = 1;
            this.label8.Text = " - 140Xi4 203dpi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(87, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Zebra Label Printer";
            // 
            // gbTestPrintOffline
            // 
            this.gbTestPrintOffline.Controls.Add(this.btnLabelTest);
            this.gbTestPrintOffline.Controls.Add(this.groupBox5);
            this.gbTestPrintOffline.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gbTestPrintOffline.Location = new System.Drawing.Point(260, 90);
            this.gbTestPrintOffline.Name = "gbTestPrintOffline";
            this.gbTestPrintOffline.Size = new System.Drawing.Size(261, 240);
            this.gbTestPrintOffline.TabIndex = 217;
            this.gbTestPrintOffline.TabStop = false;
            this.gbTestPrintOffline.Text = "Manual Print";
            // 
            // btnLabelTest
            // 
            this.btnLabelTest.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnLabelTest.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLabelTest.ForeColor = System.Drawing.Color.White;
            this.btnLabelTest.Location = new System.Drawing.Point(116, 210);
            this.btnLabelTest.Name = "btnLabelTest";
            this.btnLabelTest.Size = new System.Drawing.Size(136, 24);
            this.btnLabelTest.TabIndex = 213;
            this.btnLabelTest.Text = "Manual Print ";
            this.btnLabelTest.UseVisualStyleBackColor = false;
            this.btnLabelTest.Click += new System.EventHandler(this.btnLabelTest_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox5.Controls.Add(this.txtPartNumber);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.txtLOTID);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.picBoxBarCode);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.tbxTestHeader);
            this.groupBox5.Controls.Add(this.tbxTestLOTID);
            this.groupBox5.Controls.Add(this.tbxTestBOXID);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Location = new System.Drawing.Point(6, 20);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(246, 184);
            this.groupBox5.TabIndex = 214;
            this.groupBox5.TabStop = false;
            // 
            // txtPartNumber
            // 
            this.txtPartNumber.Location = new System.Drawing.Point(55, 131);
            this.txtPartNumber.Name = "txtPartNumber";
            this.txtPartNumber.Size = new System.Drawing.Size(167, 21);
            this.txtPartNumber.TabIndex = 235;
            this.txtPartNumber.Text = "CSMP9-0101A";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 15);
            this.label3.TabIndex = 234;
            this.label3.Text = "P/N:";
            // 
            // txtLOTID
            // 
            this.txtLOTID.Location = new System.Drawing.Point(56, 157);
            this.txtLOTID.Name = "txtLOTID";
            this.txtLOTID.Size = new System.Drawing.Size(166, 21);
            this.txtLOTID.TabIndex = 233;
            this.txtLOTID.Text = "LOTID0001";
            this.txtLOTID.TextChanged += new System.EventHandler(this.txtLOTID_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 232;
            this.label2.Text = "LOTID:";
            // 
            // picBoxBarCode
            // 
            this.picBoxBarCode.Location = new System.Drawing.Point(6, 40);
            this.picBoxBarCode.Name = "picBoxBarCode";
            this.picBoxBarCode.Size = new System.Drawing.Size(231, 42);
            this.picBoxBarCode.TabIndex = 231;
            this.picBoxBarCode.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(85, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(136, 15);
            this.label12.TabIndex = 230;
            this.label12.Text = "YYYY/MM/DD hh:mm:ss";
            // 
            // tbxTestHeader
            // 
            this.tbxTestHeader.Location = new System.Drawing.Point(11, 17);
            this.tbxTestHeader.Name = "tbxTestHeader";
            this.tbxTestHeader.Size = new System.Drawing.Size(74, 21);
            this.tbxTestHeader.TabIndex = 227;
            this.tbxTestHeader.Text = "HAC";
            // 
            // tbxTestLOTID
            // 
            this.tbxTestLOTID.Enabled = false;
            this.tbxTestLOTID.Location = new System.Drawing.Point(14, 82);
            this.tbxTestLOTID.Name = "tbxTestLOTID";
            this.tbxTestLOTID.Size = new System.Drawing.Size(216, 21);
            this.tbxTestLOTID.TabIndex = 226;
            this.tbxTestLOTID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbxTestBOXID
            // 
            this.tbxTestBOXID.Location = new System.Drawing.Point(55, 104);
            this.tbxTestBOXID.Name = "tbxTestBOXID";
            this.tbxTestBOXID.Size = new System.Drawing.Size(166, 21);
            this.tbxTestBOXID.TabIndex = 223;
            this.tbxTestBOXID.Text = "PANELIDTEST001";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(12, 106);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 15);
            this.label11.TabIndex = 222;
            this.label11.Text = "BOXID:";
            // 
            // gbOnlineRePrint
            // 
            this.gbOnlineRePrint.Controls.Add(this.btnReload);
            this.gbOnlineRePrint.Controls.Add(this.cbLOTID);
            this.gbOnlineRePrint.Controls.Add(this.label10);
            this.gbOnlineRePrint.Controls.Add(this.btnReprint);
            this.gbOnlineRePrint.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbOnlineRePrint.Location = new System.Drawing.Point(12, 90);
            this.gbOnlineRePrint.Name = "gbOnlineRePrint";
            this.gbOnlineRePrint.Size = new System.Drawing.Size(242, 85);
            this.gbOnlineRePrint.TabIndex = 218;
            this.gbOnlineRePrint.TabStop = false;
            this.gbOnlineRePrint.Text = "Reprint";
            // 
            // btnReload
            // 
            this.btnReload.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnReload.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReload.ForeColor = System.Drawing.Color.White;
            this.btnReload.Location = new System.Drawing.Point(60, 56);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(83, 24);
            this.btnReload.TabIndex = 216;
            this.btnReload.Text = "RELOAD";
            this.btnReload.UseVisualStyleBackColor = false;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // cbLOTID
            // 
            this.cbLOTID.FormattingEnabled = true;
            this.cbLOTID.Items.AddRange(new object[] {
            "OPERPNL",
            "PACKING",
            "ANALYSIS"});
            this.cbLOTID.Location = new System.Drawing.Point(60, 29);
            this.cbLOTID.Name = "cbLOTID";
            this.cbLOTID.Size = new System.Drawing.Size(176, 21);
            this.cbLOTID.TabIndex = 215;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 15);
            this.label10.TabIndex = 214;
            this.label10.Text = "LOT ID";
            // 
            // btnReprint
            // 
            this.btnReprint.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnReprint.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReprint.ForeColor = System.Drawing.Color.White;
            this.btnReprint.Location = new System.Drawing.Point(153, 56);
            this.btnReprint.Name = "btnReprint";
            this.btnReprint.Size = new System.Drawing.Size(83, 24);
            this.btnReprint.TabIndex = 213;
            this.btnReprint.Text = "재발행";
            this.btnReprint.UseVisualStyleBackColor = false;
            // 
            // FormLabelPrinter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 384);
            this.CloseButtonEnable = true;
            this.ControlBox = false;
            this.Controls.Add(this.gbOnlineRePrint);
            this.Controls.Add(this.gbTestPrintOffline);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbTitle);
            this.Name = "FormLabelPrinter";
            this.Text = "FormPortInfo";
            this.Load += new System.EventHandler(this.FormLabelPrinter_Load);
            this.Move += new System.EventHandler(this.FormLabelPrinter_Move);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPortInfo_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbTestPrintOffline.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxBarCode)).EndInit();
            this.gbOnlineRePrint.ResumeLayout(false);
            this.gbOnlineRePrint.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbTestPrintOffline;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.PictureBox picBoxBarCode;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbxTestHeader;
        private System.Windows.Forms.TextBox tbxTestLOTID;
        private System.Windows.Forms.TextBox tbxTestBOXID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnLabelTest;
        private System.Windows.Forms.GroupBox gbOnlineRePrint;
        private System.Windows.Forms.ComboBox cbLOTID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnReprint;
        private System.Windows.Forms.TextBox txtLOTID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPartNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnReconnect;
    }
}