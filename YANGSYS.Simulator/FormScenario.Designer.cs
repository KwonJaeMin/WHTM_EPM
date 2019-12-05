namespace SmartPLCSimulator
{
    partial class FormScenario
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
            this.components = new System.ComponentModel.Container();
            this.lstScenario = new System.Windows.Forms.ListBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSetInterval = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInterval = new System.Windows.Forms.TextBox();
            this.btnScenarioStart = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnScenarioPause = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.grbWord = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtWordData = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.grbBit = new System.Windows.Forms.GroupBox();
            this.chkPulse = new System.Windows.Forms.CheckBox();
            this.optBitOff = new System.Windows.Forms.RadioButton();
            this.optBitOn = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStepNo = new System.Windows.Forms.TextBox();
            this.optWord = new System.Windows.Forms.RadioButton();
            this.optBit = new System.Windows.Forms.RadioButton();
            this.tmrInterval = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.lbStep = new System.Windows.Forms.Label();
            this.chkCCLink = new System.Windows.Forms.RadioButton();
            this.chkPLC = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.grbWord.SuspendLayout();
            this.grbBit.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstScenario
            // 
            this.lstScenario.FormattingEnabled = true;
            this.lstScenario.ItemHeight = 12;
            this.lstScenario.Location = new System.Drawing.Point(240, 14);
            this.lstScenario.Name = "lstScenario";
            this.lstScenario.Size = new System.Drawing.Size(342, 304);
            this.lstScenario.TabIndex = 0;
            this.lstScenario.SelectedIndexChanged += new System.EventHandler(this.lstScenario_SelectedIndexChanged);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(486, 330);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(96, 28);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(384, 330);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(96, 28);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Scenario Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSetInterval
            // 
            this.btnSetInterval.Location = new System.Drawing.Point(191, 14);
            this.btnSetInterval.Name = "btnSetInterval";
            this.btnSetInterval.Size = new System.Drawing.Size(43, 26);
            this.btnSetInterval.TabIndex = 3;
            this.btnSetInterval.Text = "SET";
            this.btnSetInterval.UseVisualStyleBackColor = true;
            this.btnSetInterval.Click += new System.EventHandler(this.btnSetInterval_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "Step Timer Interval(ms)";
            // 
            // txtInterval
            // 
            this.txtInterval.Location = new System.Drawing.Point(148, 18);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(40, 21);
            this.txtInterval.TabIndex = 5;
            // 
            // btnScenarioStart
            // 
            this.btnScenarioStart.Location = new System.Drawing.Point(5, 330);
            this.btnScenarioStart.Name = "btnScenarioStart";
            this.btnScenarioStart.Size = new System.Drawing.Size(118, 28);
            this.btnScenarioStart.TabIndex = 6;
            this.btnScenarioStart.Text = "Scenario Start";
            this.btnScenarioStart.UseVisualStyleBackColor = true;
            this.btnScenarioStart.Click += new System.EventHandler(this.btnScenarioStart_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(282, 330);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 28);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Scenario Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnScenarioPause
            // 
            this.btnScenarioPause.Enabled = false;
            this.btnScenarioPause.Location = new System.Drawing.Point(129, 330);
            this.btnScenarioPause.Name = "btnScenarioPause";
            this.btnScenarioPause.Size = new System.Drawing.Size(108, 28);
            this.btnScenarioPause.TabIndex = 8;
            this.btnScenarioPause.Text = "Scenario Pause";
            this.btnScenarioPause.UseVisualStyleBackColor = true;
            this.btnScenarioPause.Click += new System.EventHandler(this.btnScenarioPause_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtDesc);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtAddress);
            this.groupBox1.Controls.Add(this.grbWord);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnModify);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.grbBit);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtStepNo);
            this.groupBox1.Controls.Add(this.optWord);
            this.groupBox1.Controls.Add(this.optBit);
            this.groupBox1.Location = new System.Drawing.Point(9, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 222);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Scenario Data";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 12);
            this.label6.TabIndex = 20;
            this.label6.Text = "Desc";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(46, 162);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(166, 21);
            this.txtDesc.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(102, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "(Hex)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "Address";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(62, 70);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(40, 21);
            this.txtAddress.TabIndex = 15;
            this.txtAddress.Text = "0";
            // 
            // grbWord
            // 
            this.grbWord.Controls.Add(this.label5);
            this.grbWord.Controls.Add(this.txtWordData);
            this.grbWord.Location = new System.Drawing.Point(8, 108);
            this.grbWord.Name = "grbWord";
            this.grbWord.Size = new System.Drawing.Size(204, 48);
            this.grbWord.TabIndex = 12;
            this.grbWord.TabStop = false;
            this.grbWord.Text = "Word Data";
            this.grbWord.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(153, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 12);
            this.label5.TabIndex = 18;
            this.label5.Text = "(Hex)";
            // 
            // txtWordData
            // 
            this.txtWordData.Location = new System.Drawing.Point(8, 20);
            this.txtWordData.Name = "txtWordData";
            this.txtWordData.Size = new System.Drawing.Size(144, 21);
            this.txtWordData.TabIndex = 13;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(145, 188);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(63, 28);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(76, 188);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(63, 28);
            this.btnModify.TabIndex = 13;
            this.btnModify.Text = "Modify";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(8, 188);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(62, 28);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // grbBit
            // 
            this.grbBit.Controls.Add(this.chkPulse);
            this.grbBit.Controls.Add(this.optBitOff);
            this.grbBit.Controls.Add(this.optBitOn);
            this.grbBit.Location = new System.Drawing.Point(8, 97);
            this.grbBit.Name = "grbBit";
            this.grbBit.Size = new System.Drawing.Size(204, 59);
            this.grbBit.TabIndex = 11;
            this.grbBit.TabStop = false;
            this.grbBit.Text = "Bit Data";
            // 
            // chkPulse
            // 
            this.chkPulse.AutoSize = true;
            this.chkPulse.Location = new System.Drawing.Point(21, 39);
            this.chkPulse.Name = "chkPulse";
            this.chkPulse.Size = new System.Drawing.Size(89, 16);
            this.chkPulse.TabIndex = 12;
            this.chkPulse.Text = "Pulse Type";
            this.chkPulse.UseVisualStyleBackColor = true;
            // 
            // optBitOff
            // 
            this.optBitOff.AutoSize = true;
            this.optBitOff.Location = new System.Drawing.Point(76, 17);
            this.optBitOff.Name = "optBitOff";
            this.optBitOff.Size = new System.Drawing.Size(46, 16);
            this.optBitOff.TabIndex = 1;
            this.optBitOff.TabStop = true;
            this.optBitOff.Text = "OFF";
            this.optBitOff.UseVisualStyleBackColor = true;
            // 
            // optBitOn
            // 
            this.optBitOn.AutoSize = true;
            this.optBitOn.Location = new System.Drawing.Point(21, 17);
            this.optBitOn.Name = "optBitOn";
            this.optBitOn.Size = new System.Drawing.Size(41, 16);
            this.optBitOn.TabIndex = 0;
            this.optBitOn.TabStop = true;
            this.optBitOn.Text = "ON";
            this.optBitOn.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "Step No";
            // 
            // txtStepNo
            // 
            this.txtStepNo.Location = new System.Drawing.Point(62, 19);
            this.txtStepNo.Name = "txtStepNo";
            this.txtStepNo.Size = new System.Drawing.Size(40, 21);
            this.txtStepNo.TabIndex = 10;
            this.txtStepNo.Text = "1";
            // 
            // optWord
            // 
            this.optWord.AutoSize = true;
            this.optWord.Location = new System.Drawing.Point(140, 49);
            this.optWord.Name = "optWord";
            this.optWord.Size = new System.Drawing.Size(58, 16);
            this.optWord.TabIndex = 1;
            this.optWord.Text = "WORD";
            this.optWord.UseVisualStyleBackColor = true;
            // 
            // optBit
            // 
            this.optBit.AutoSize = true;
            this.optBit.Checked = true;
            this.optBit.Location = new System.Drawing.Point(6, 49);
            this.optBit.Name = "optBit";
            this.optBit.Size = new System.Drawing.Size(119, 16);
            this.optBit.TabIndex = 0;
            this.optBit.TabStop = true;
            this.optBit.Text = "BIT(CC-Link \'X\')";
            this.optBit.UseVisualStyleBackColor = true;
            this.optBit.CheckedChanged += new System.EventHandler(this.optBit_CheckedChanged);
            // 
            // tmrInterval
            // 
            this.tmrInterval.Tick += new System.EventHandler(this.tmrInterval_Tick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lbStep
            // 
            this.lbStep.BackColor = System.Drawing.Color.Yellow;
            this.lbStep.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbStep.Location = new System.Drawing.Point(514, 14);
            this.lbStep.Name = "lbStep";
            this.lbStep.Size = new System.Drawing.Size(62, 54);
            this.lbStep.TabIndex = 10;
            this.lbStep.Text = "0";
            this.lbStep.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbStep.Visible = false;
            // 
            // chkCCLink
            // 
            this.chkCCLink.AutoSize = true;
            this.chkCCLink.Location = new System.Drawing.Point(96, 20);
            this.chkCCLink.Name = "chkCCLink";
            this.chkCCLink.Size = new System.Drawing.Size(68, 16);
            this.chkCCLink.TabIndex = 12;
            this.chkCCLink.Text = "CCLINK";
            this.chkCCLink.UseVisualStyleBackColor = true;
            this.chkCCLink.CheckedChanged += new System.EventHandler(this.chkCCLink_CheckedChanged);
            // 
            // chkPLC
            // 
            this.chkPLC.AutoSize = true;
            this.chkPLC.Checked = true;
            this.chkPLC.Location = new System.Drawing.Point(5, 20);
            this.chkPLC.Name = "chkPLC";
            this.chkPLC.Size = new System.Drawing.Size(47, 16);
            this.chkPLC.TabIndex = 11;
            this.chkPLC.TabStop = true;
            this.chkPLC.Text = "PLC";
            this.chkPLC.UseVisualStyleBackColor = true;
            this.chkPLC.CheckedChanged += new System.EventHandler(this.chkPLC_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkPLC);
            this.groupBox2.Controls.Add(this.chkCCLink);
            this.groupBox2.Location = new System.Drawing.Point(9, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(225, 48);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DEVICE TYPE";
            // 
            // FormScenario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(588, 368);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lbStep);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnScenarioPause);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnScenarioStart);
            this.Controls.Add(this.txtInterval);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSetInterval);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lstScenario);
            this.Name = "FormScenario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " ";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grbWord.ResumeLayout(false);
            this.grbWord.PerformLayout();
            this.grbBit.ResumeLayout(false);
            this.grbBit.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstScenario;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSetInterval;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInterval;
        private System.Windows.Forms.Button btnScenarioStart;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnScenarioPause;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton optWord;
        private System.Windows.Forms.RadioButton optBit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStepNo;
        private System.Windows.Forms.CheckBox chkPulse;
        private System.Windows.Forms.GroupBox grbBit;
        private System.Windows.Forms.RadioButton optBitOff;
        private System.Windows.Forms.RadioButton optBitOn;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox grbWord;
        private System.Windows.Forms.TextBox txtWordData;
        private System.Windows.Forms.Timer tmrInterval;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label lbStep;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.RadioButton chkCCLink;
        private System.Windows.Forms.RadioButton chkPLC;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}