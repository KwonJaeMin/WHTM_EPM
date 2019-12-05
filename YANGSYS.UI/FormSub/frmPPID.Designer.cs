namespace YANGSYS.UI.SubForm
{
    partial class frmPPID
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
            this.lblLCTime = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.cmbPPIDList = new System.Windows.Forms.ComboBox();
            this.btnPortDelete = new System.Windows.Forms.Button();
            this.btnSetCurrentPPID = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblSelectedPortNo = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.btnPortAdd = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPortAllClear = new System.Windows.Forms.Button();
            this.Label7 = new System.Windows.Forms.Label();
            this.cmbUseType = new System.Windows.Forms.ComboBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnAddorModify = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.Label36 = new System.Windows.Forms.Label();
            this.Label19 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.lsbPPIDInfo = new System.Windows.Forms.ListBox();
            this.Label13 = new System.Windows.Forms.Label();
            this.cmbRcpNo = new System.Windows.Forms.ComboBox();
            this.btnGetEqpPPIDList = new System.Windows.Forms.Button();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLCTime
            // 
            this.lblLCTime.BackColor = System.Drawing.Color.White;
            this.lblLCTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLCTime.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLCTime.ForeColor = System.Drawing.Color.Black;
            this.lblLCTime.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblLCTime.Location = new System.Drawing.Point(384, 32);
            this.lblLCTime.Name = "lblLCTime";
            this.lblLCTime.Size = new System.Drawing.Size(208, 24);
            this.lblLCTime.TabIndex = 184;
            this.lblLCTime.Text = "2010-03-29 23:59:59";
            this.lblLCTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label3
            // 
            this.Label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label3.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label3.ForeColor = System.Drawing.Color.White;
            this.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label3.Location = new System.Drawing.Point(304, 32);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(80, 24);
            this.Label3.TabIndex = 183;
            this.Label3.Text = "LCTIME";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbPPIDList
            // 
            this.cmbPPIDList.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmbPPIDList.FormattingEnabled = true;
            this.cmbPPIDList.Location = new System.Drawing.Point(120, 32);
            this.cmbPPIDList.Name = "cmbPPIDList";
            this.cmbPPIDList.Size = new System.Drawing.Size(176, 25);
            this.cmbPPIDList.TabIndex = 182;
            // 
            // btnPortDelete
            // 
            this.btnPortDelete.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPortDelete.Location = new System.Drawing.Point(168, 99);
            this.btnPortDelete.Name = "btnPortDelete";
            this.btnPortDelete.Size = new System.Drawing.Size(112, 32);
            this.btnPortDelete.TabIndex = 178;
            this.btnPortDelete.Text = "DELETE";
            this.btnPortDelete.UseVisualStyleBackColor = true;
            this.btnPortDelete.Click += new System.EventHandler(this.btnPortDelete_Click);
            // 
            // btnSetCurrentPPID
            // 
            this.btnSetCurrentPPID.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSetCurrentPPID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSetCurrentPPID.Location = new System.Drawing.Point(8, 328);
            this.btnSetCurrentPPID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSetCurrentPPID.Name = "btnSetCurrentPPID";
            this.btnSetCurrentPPID.Size = new System.Drawing.Size(288, 40);
            this.btnSetCurrentPPID.TabIndex = 185;
            this.btnSetCurrentPPID.Text = "SET CURRENT PPID";
            this.btnSetCurrentPPID.UseVisualStyleBackColor = true;
            this.btnSetCurrentPPID.Click += new System.EventHandler(this.btnSetCurrentPPID_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDelete.Location = new System.Drawing.Point(456, 272);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(136, 40);
            this.btnDelete.TabIndex = 181;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblSelectedPortNo
            // 
            this.lblSelectedPortNo.BackColor = System.Drawing.Color.White;
            this.lblSelectedPortNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSelectedPortNo.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSelectedPortNo.ForeColor = System.Drawing.Color.Black;
            this.lblSelectedPortNo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSelectedPortNo.Location = new System.Drawing.Point(168, 24);
            this.lblSelectedPortNo.Name = "lblSelectedPortNo";
            this.lblSelectedPortNo.Size = new System.Drawing.Size(40, 24);
            this.lblSelectedPortNo.TabIndex = 177;
            this.lblSelectedPortNo.Text = "1";
            this.lblSelectedPortNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label5
            // 
            this.Label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label5.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label5.ForeColor = System.Drawing.Color.White;
            this.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label5.Location = new System.Drawing.Point(8, 24);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(160, 24);
            this.Label5.TabIndex = 176;
            this.Label5.Text = "SELECTED PORTNO";
            this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPortAdd
            // 
            this.btnPortAdd.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPortAdd.Location = new System.Drawing.Point(168, 64);
            this.btnPortAdd.Name = "btnPortAdd";
            this.btnPortAdd.Size = new System.Drawing.Size(112, 32);
            this.btnPortAdd.TabIndex = 175;
            this.btnPortAdd.Text = "ADD";
            this.btnPortAdd.UseVisualStyleBackColor = true;
            this.btnPortAdd.Click += new System.EventHandler(this.btnPortAdd_Click);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.Label13);
            this.GroupBox1.Controls.Add(this.cmbRcpNo);
            this.GroupBox1.Controls.Add(this.btnGetEqpPPIDList);
            this.GroupBox1.Controls.Add(this.btnPortAllClear);
            this.GroupBox1.Controls.Add(this.btnPortDelete);
            this.GroupBox1.Controls.Add(this.lblSelectedPortNo);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.btnPortAdd);
            this.GroupBox1.Controls.Add(this.Label7);
            this.GroupBox1.Controls.Add(this.cmbUseType);
            this.GroupBox1.Location = new System.Drawing.Point(304, 64);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(288, 200);
            this.GroupBox1.TabIndex = 186;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "PORT SETTING";
            // 
            // btnPortAllClear
            // 
            this.btnPortAllClear.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPortAllClear.Location = new System.Drawing.Point(168, 134);
            this.btnPortAllClear.Name = "btnPortAllClear";
            this.btnPortAllClear.Size = new System.Drawing.Size(112, 32);
            this.btnPortAllClear.TabIndex = 179;
            this.btnPortAllClear.Text = "ALL CLEAR";
            this.btnPortAllClear.UseVisualStyleBackColor = true;
            this.btnPortAllClear.Click += new System.EventHandler(this.btnPortAllClear_Click);
            // 
            // Label7
            // 
            this.Label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label7.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label7.ForeColor = System.Drawing.Color.White;
            this.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label7.Location = new System.Drawing.Point(8, 64);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(88, 24);
            this.Label7.TabIndex = 174;
            this.Label7.Text = "USETYPE";
            this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbUseType
            // 
            this.cmbUseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUseType.FormattingEnabled = true;
            this.cmbUseType.Location = new System.Drawing.Point(96, 64);
            this.cmbUseType.Name = "cmbUseType";
            this.cmbUseType.Size = new System.Drawing.Size(64, 23);
            this.cmbUseType.TabIndex = 173;
            // 
            // btnTest
            // 
            this.btnTest.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnTest.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnTest.Location = new System.Drawing.Point(304, 328);
            this.btnTest.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(136, 40);
            this.btnTest.TabIndex = 180;
            this.btnTest.Text = "TEST";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Visible = false;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnAddorModify
            // 
            this.btnAddorModify.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnAddorModify.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAddorModify.Location = new System.Drawing.Point(304, 272);
            this.btnAddorModify.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddorModify.Name = "btnAddorModify";
            this.btnAddorModify.Size = new System.Drawing.Size(136, 40);
            this.btnAddorModify.TabIndex = 179;
            this.btnAddorModify.Text = "ADD/MODIFY";
            this.btnAddorModify.UseVisualStyleBackColor = true;
            this.btnAddorModify.Click += new System.EventHandler(this.btnAddorModify_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnClose.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(456, 328);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(136, 40);
            this.btnClose.TabIndex = 178;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Label36
            // 
            this.Label36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label36.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label36.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label36.ForeColor = System.Drawing.Color.White;
            this.Label36.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label36.Location = new System.Drawing.Point(0, 0);
            this.Label36.Name = "Label36";
            this.Label36.Size = new System.Drawing.Size(600, 24);
            this.Label36.TabIndex = 177;
            this.Label36.Text = "PPID INFORMATION";
            this.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label19
            // 
            this.Label19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label19.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label19.ForeColor = System.Drawing.Color.White;
            this.Label19.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label19.Location = new System.Drawing.Point(8, 64);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(288, 24);
            this.Label19.TabIndex = 176;
            this.Label19.Text = "SELECTED PPID INFO";
            this.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label1.Location = new System.Drawing.Point(8, 32);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(112, 24);
            this.Label1.TabIndex = 175;
            this.Label1.Text = "PPID LIST";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lsbPPIDInfo
            // 
            this.lsbPPIDInfo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsbPPIDInfo.FormattingEnabled = true;
            this.lsbPPIDInfo.ItemHeight = 16;
            this.lsbPPIDInfo.Items.AddRange(new object[] {
            "1,",
            "2,",
            "3,AA_BB_CC",
            "4,DD_EE",
            "5,FF_GG",
            "6,HH_II",
            "7,JJ_KK_JA_JB_KA",
            "8,LL_MM",
            "9,NN_OO",
            "10,UU,PP_QQ",
            "11,RR_SS",
            "12,TT_UU",
            "13,VV_WW",
            "14,XX_YY_ZZ"});
            this.lsbPPIDInfo.Location = new System.Drawing.Point(8, 88);
            this.lsbPPIDInfo.Name = "lsbPPIDInfo";
            this.lsbPPIDInfo.ScrollAlwaysVisible = true;
            this.lsbPPIDInfo.Size = new System.Drawing.Size(288, 228);
            this.lsbPPIDInfo.TabIndex = 174;
            // 
            // Label13
            // 
            this.Label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label13.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label13.ForeColor = System.Drawing.Color.White;
            this.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label13.Location = new System.Drawing.Point(9, 169);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(72, 24);
            this.Label13.TabIndex = 185;
            this.Label13.Text = "RCPNO";
            this.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbRcpNo
            // 
            this.cmbRcpNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRcpNo.FormattingEnabled = true;
            this.cmbRcpNo.Location = new System.Drawing.Point(81, 170);
            this.cmbRcpNo.Name = "cmbRcpNo";
            this.cmbRcpNo.Size = new System.Drawing.Size(64, 23);
            this.cmbRcpNo.TabIndex = 184;
            // 
            // btnGetEqpPPIDList
            // 
            this.btnGetEqpPPIDList.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnGetEqpPPIDList.Location = new System.Drawing.Point(152, 170);
            this.btnGetEqpPPIDList.Name = "btnGetEqpPPIDList";
            this.btnGetEqpPPIDList.Size = new System.Drawing.Size(128, 24);
            this.btnGetEqpPPIDList.TabIndex = 183;
            this.btnGetEqpPPIDList.Text = "GET EQP PPID LIST";
            this.btnGetEqpPPIDList.UseVisualStyleBackColor = true;
            this.btnGetEqpPPIDList.Click += new System.EventHandler(this.btnGetEqpPPIDList_Click);
            // 
            // frmPPID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 377);
            this.ControlBox = false;
            this.Controls.Add(this.lblLCTime);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.cmbPPIDList);
            this.Controls.Add(this.btnSetCurrentPPID);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnAddorModify);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.Label36);
            this.Controls.Add(this.Label19);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.lsbPPIDInfo);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPPID";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PPID";
            this.GroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label lblLCTime;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.ComboBox cmbPPIDList;
        internal System.Windows.Forms.Button btnPortDelete;
        internal System.Windows.Forms.Button btnSetCurrentPPID;
        internal System.Windows.Forms.Button btnDelete;
        internal System.Windows.Forms.Label lblSelectedPortNo;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Button btnPortAdd;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Button btnPortAllClear;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.ComboBox cmbUseType;
        internal System.Windows.Forms.Button btnTest;
        internal System.Windows.Forms.Button btnAddorModify;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Label Label36;
        internal System.Windows.Forms.Label Label19;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ListBox lsbPPIDInfo;
        internal System.Windows.Forms.Label Label13;
        internal System.Windows.Forms.ComboBox cmbRcpNo;
        internal System.Windows.Forms.Button btnGetEqpPPIDList;

    }
}