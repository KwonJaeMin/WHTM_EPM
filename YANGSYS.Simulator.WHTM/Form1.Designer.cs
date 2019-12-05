namespace YANGSYS.Simulator.WHTM
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnUnload = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnExchange = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnInitDataL2 = new System.Windows.Forms.Button();
            this.btnEngineStop = new System.Windows.Forms.Button();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.chkIndexerTrouble = new System.Windows.Forms.CheckBox();
            this.chkIndexerInline = new System.Windows.Forms.CheckBox();
            this.dgvInJobData2_L2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvOutJobData2_L2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvInJobData1_L2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvOutJobData1_L2 = new System.Windows.Forms.DataGridView();
            this.colKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkAbnormal3 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.chkAbnormal2 = new System.Windows.Forms.CheckBox();
            this.chkAbnormal1 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvOutJobData1_L3 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvOutJobData2_L3 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvInJobData1_L3 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvInJobData2_L3 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnInitDataL3 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnVariableWrite = new System.Windows.Forms.Button();
            this.btnVariableRead = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCurrentPPIDRecipe = new System.Windows.Forms.Label();
            this.cbAuthorizationResult = new System.Windows.Forms.ComboBox();
            this.txtCurRecipeID = new System.Windows.Forms.TextBox();
            this.txtCurPPID = new System.Windows.Forms.TextBox();
            this.txtReadPassword = new System.Windows.Forms.TextBox();
            this.txtReadUserID = new System.Windows.Forms.TextBox();
            this.cJ2Compolet1 = new OMRON.Compolet.CIP.CJ2Compolet(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInJobData2_L2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutJobData2_L2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInJobData1_L2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutJobData1_L2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutJobData1_L3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutJobData2_L3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInJobData1_L3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInJobData2_L3)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUnload
            // 
            this.btnUnload.Location = new System.Drawing.Point(11, 53);
            this.btnUnload.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUnload.Name = "btnUnload";
            this.btnUnload.Size = new System.Drawing.Size(99, 29);
            this.btnUnload.TabIndex = 0;
            this.btnUnload.Text = "Unload";
            this.btnUnload.UseVisualStyleBackColor = true;
            this.btnUnload.Click += new System.EventHandler(this.btnUnload_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(11, 90);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(99, 29);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnExchange
            // 
            this.btnExchange.Location = new System.Drawing.Point(116, 53);
            this.btnExchange.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExchange.Name = "btnExchange";
            this.btnExchange.Size = new System.Drawing.Size(99, 29);
            this.btnExchange.TabIndex = 0;
            this.btnExchange.Text = "Exchange";
            this.btnExchange.UseVisualStyleBackColor = true;
            this.btnExchange.Click += new System.EventHandler(this.btnExchange_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnInitDataL2);
            this.groupBox1.Controls.Add(this.btnEngineStop);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.chkIndexerTrouble);
            this.groupBox1.Controls.Add(this.chkIndexerInline);
            this.groupBox1.Controls.Add(this.dgvInJobData2_L2);
            this.groupBox1.Controls.Add(this.dgvOutJobData2_L2);
            this.groupBox1.Controls.Add(this.dgvInJobData1_L2);
            this.groupBox1.Controls.Add(this.dgvOutJobData1_L2);
            this.groupBox1.Controls.Add(this.chkActive);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chkAbnormal3);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.chkAbnormal2);
            this.groupBox1.Controls.Add(this.chkAbnormal1);
            this.groupBox1.Controls.Add(this.btnUnload);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnExchange);
            this.groupBox1.Controls.Add(this.btnLoad);
            this.groupBox1.Location = new System.Drawing.Point(6, 7);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(454, 445);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "INDEXER [L2]";
            // 
            // btnInitDataL2
            // 
            this.btnInitDataL2.Location = new System.Drawing.Point(355, 98);
            this.btnInitDataL2.Name = "btnInitDataL2";
            this.btnInitDataL2.Size = new System.Drawing.Size(67, 23);
            this.btnInitDataL2.TabIndex = 3;
            this.btnInitDataL2.Text = "Clear";
            this.btnInitDataL2.UseVisualStyleBackColor = true;
            this.btnInitDataL2.Click += new System.EventHandler(this.btnInitDataL2_Click);
            // 
            // btnEngineStop
            // 
            this.btnEngineStop.Location = new System.Drawing.Point(368, 20);
            this.btnEngineStop.Name = "btnEngineStop";
            this.btnEngineStop.Size = new System.Drawing.Size(53, 21);
            this.btnEngineStop.TabIndex = 5;
            this.btnEngineStop.Text = "START";
            this.btnEngineStop.UseVisualStyleBackColor = true;
            this.btnEngineStop.Click += new System.EventHandler(this.btnEngineStop_Click);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(361, 205);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(90, 19);
            this.checkBox2.TabIndex = 4;
            this.checkBox2.Tag = "RV_B_LinkSignalPath1_L2.Downstream.DownstreamTrouble";
            this.checkBox2.Text = "DW Trouble";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.Click += new System.EventHandler(this.chkIndexerInline_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(361, 180);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(79, 19);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Tag = "RV_B_LinkSignalPath1_L2.Downstream.DownstreamInline";
            this.checkBox1.Text = "DW Inline";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Click += new System.EventHandler(this.chkIndexerInline_Click);
            // 
            // chkIndexerTrouble
            // 
            this.chkIndexerTrouble.AutoSize = true;
            this.chkIndexerTrouble.Location = new System.Drawing.Point(362, 151);
            this.chkIndexerTrouble.Name = "chkIndexerTrouble";
            this.chkIndexerTrouble.Size = new System.Drawing.Size(85, 19);
            this.chkIndexerTrouble.TabIndex = 4;
            this.chkIndexerTrouble.Tag = "RV_B_LinkSignalPath1_L2.Upstream.UpstreamTrouble";
            this.chkIndexerTrouble.Text = "UP Trouble";
            this.chkIndexerTrouble.UseVisualStyleBackColor = true;
            this.chkIndexerTrouble.Click += new System.EventHandler(this.chkIndexerInline_Click);
            // 
            // chkIndexerInline
            // 
            this.chkIndexerInline.AutoSize = true;
            this.chkIndexerInline.Location = new System.Drawing.Point(362, 126);
            this.chkIndexerInline.Name = "chkIndexerInline";
            this.chkIndexerInline.Size = new System.Drawing.Size(74, 19);
            this.chkIndexerInline.TabIndex = 4;
            this.chkIndexerInline.Tag = "RV_B_LinkSignalPath1_L2.Upstream.UpstreamInline";
            this.chkIndexerInline.Text = "Up Inline";
            this.chkIndexerInline.UseVisualStyleBackColor = true;
            this.chkIndexerInline.Click += new System.EventHandler(this.chkIndexerInline_Click);
            // 
            // dgvInJobData2_L2
            // 
            this.dgvInJobData2_L2.AllowUserToAddRows = false;
            this.dgvInJobData2_L2.AllowUserToDeleteRows = false;
            this.dgvInJobData2_L2.AllowUserToResizeRows = false;
            this.dgvInJobData2_L2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInJobData2_L2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10});
            this.dgvInJobData2_L2.Location = new System.Drawing.Point(187, 364);
            this.dgvInJobData2_L2.Name = "dgvInJobData2_L2";
            this.dgvInJobData2_L2.RowHeadersVisible = false;
            this.dgvInJobData2_L2.RowTemplate.Height = 23;
            this.dgvInJobData2_L2.Size = new System.Drawing.Size(169, 66);
            this.dgvInJobData2_L2.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Key";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 80;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "Value";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 80;
            // 
            // dgvOutJobData2_L2
            // 
            this.dgvOutJobData2_L2.AllowUserToAddRows = false;
            this.dgvOutJobData2_L2.AllowUserToDeleteRows = false;
            this.dgvOutJobData2_L2.AllowUserToResizeRows = false;
            this.dgvOutJobData2_L2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOutJobData2_L2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgvOutJobData2_L2.Location = new System.Drawing.Point(187, 126);
            this.dgvOutJobData2_L2.Name = "dgvOutJobData2_L2";
            this.dgvOutJobData2_L2.RowHeadersVisible = false;
            this.dgvOutJobData2_L2.RowTemplate.Height = 23;
            this.dgvOutJobData2_L2.Size = new System.Drawing.Size(169, 232);
            this.dgvOutJobData2_L2.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Key";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Value";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dgvInJobData1_L2
            // 
            this.dgvInJobData1_L2.AllowUserToAddRows = false;
            this.dgvInJobData1_L2.AllowUserToDeleteRows = false;
            this.dgvInJobData1_L2.AllowUserToResizeRows = false;
            this.dgvInJobData1_L2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInJobData1_L2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            this.dgvInJobData1_L2.Location = new System.Drawing.Point(12, 364);
            this.dgvInJobData1_L2.Name = "dgvInJobData1_L2";
            this.dgvInJobData1_L2.RowHeadersVisible = false;
            this.dgvInJobData1_L2.RowTemplate.Height = 23;
            this.dgvInJobData1_L2.Size = new System.Drawing.Size(169, 66);
            this.dgvInJobData1_L2.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Key";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 80;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Value";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 80;
            // 
            // dgvOutJobData1_L2
            // 
            this.dgvOutJobData1_L2.AllowUserToAddRows = false;
            this.dgvOutJobData1_L2.AllowUserToDeleteRows = false;
            this.dgvOutJobData1_L2.AllowUserToResizeRows = false;
            this.dgvOutJobData1_L2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOutJobData1_L2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colKey,
            this.colValue});
            this.dgvOutJobData1_L2.Location = new System.Drawing.Point(12, 126);
            this.dgvOutJobData1_L2.Name = "dgvOutJobData1_L2";
            this.dgvOutJobData1_L2.RowHeadersVisible = false;
            this.dgvOutJobData1_L2.RowTemplate.Height = 23;
            this.dgvOutJobData1_L2.Size = new System.Drawing.Size(169, 232);
            this.dgvOutJobData1_L2.TabIndex = 2;
            // 
            // colKey
            // 
            this.colKey.HeaderText = "Key";
            this.colKey.Name = "colKey";
            this.colKey.Width = 80;
            // 
            // colValue
            // 
            this.colValue.HeaderText = "Value";
            this.colValue.Name = "colValue";
            this.colValue.Width = 80;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Location = new System.Drawing.Point(221, 27);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(59, 19);
            this.chkActive.TabIndex = 2;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;
            this.chkActive.CheckedChanged += new System.EventHandler(this.chkActive_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "NODE";
            // 
            // chkAbnormal3
            // 
            this.chkAbnormal3.AutoSize = true;
            this.chkAbnormal3.Location = new System.Drawing.Point(221, 102);
            this.chkAbnormal3.Name = "chkAbnormal3";
            this.chkAbnormal3.Size = new System.Drawing.Size(102, 19);
            this.chkAbnormal3.TabIndex = 1;
            this.chkAbnormal3.Text = "ABNORMAL 3";
            this.chkAbnormal3.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(77, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(138, 23);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "192.168.123.8";
            // 
            // chkAbnormal2
            // 
            this.chkAbnormal2.AutoSize = true;
            this.chkAbnormal2.Location = new System.Drawing.Point(221, 77);
            this.chkAbnormal2.Name = "chkAbnormal2";
            this.chkAbnormal2.Size = new System.Drawing.Size(102, 19);
            this.chkAbnormal2.TabIndex = 1;
            this.chkAbnormal2.Text = "ABNORMAL 2";
            this.chkAbnormal2.UseVisualStyleBackColor = true;
            // 
            // chkAbnormal1
            // 
            this.chkAbnormal1.AutoSize = true;
            this.chkAbnormal1.Location = new System.Drawing.Point(221, 52);
            this.chkAbnormal1.Name = "chkAbnormal1";
            this.chkAbnormal1.Size = new System.Drawing.Size(102, 19);
            this.chkAbnormal1.TabIndex = 1;
            this.chkAbnormal1.Text = "ABNORMAL 1";
            this.chkAbnormal1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(116, 90);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "I/F Init";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvOutJobData1_L3
            // 
            this.dgvOutJobData1_L3.AllowUserToAddRows = false;
            this.dgvOutJobData1_L3.AllowUserToDeleteRows = false;
            this.dgvOutJobData1_L3.AllowUserToResizeRows = false;
            this.dgvOutJobData1_L3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOutJobData1_L3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dgvOutJobData1_L3.Location = new System.Drawing.Point(472, 133);
            this.dgvOutJobData1_L3.Name = "dgvOutJobData1_L3";
            this.dgvOutJobData1_L3.RowHeadersVisible = false;
            this.dgvOutJobData1_L3.RowTemplate.Height = 23;
            this.dgvOutJobData1_L3.Size = new System.Drawing.Size(163, 232);
            this.dgvOutJobData1_L3.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Key";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 80;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Value";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 80;
            // 
            // dgvOutJobData2_L3
            // 
            this.dgvOutJobData2_L3.AllowUserToAddRows = false;
            this.dgvOutJobData2_L3.AllowUserToDeleteRows = false;
            this.dgvOutJobData2_L3.AllowUserToResizeRows = false;
            this.dgvOutJobData2_L3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOutJobData2_L3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.dgvOutJobData2_L3.Location = new System.Drawing.Point(647, 133);
            this.dgvOutJobData2_L3.Name = "dgvOutJobData2_L3";
            this.dgvOutJobData2_L3.RowHeadersVisible = false;
            this.dgvOutJobData2_L3.RowTemplate.Height = 23;
            this.dgvOutJobData2_L3.Size = new System.Drawing.Size(163, 232);
            this.dgvOutJobData2_L3.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Key";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 80;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Value";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 80;
            // 
            // dgvInJobData1_L3
            // 
            this.dgvInJobData1_L3.AllowUserToAddRows = false;
            this.dgvInJobData1_L3.AllowUserToDeleteRows = false;
            this.dgvInJobData1_L3.AllowUserToResizeRows = false;
            this.dgvInJobData1_L3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInJobData1_L3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12});
            this.dgvInJobData1_L3.Location = new System.Drawing.Point(472, 371);
            this.dgvInJobData1_L3.Name = "dgvInJobData1_L3";
            this.dgvInJobData1_L3.RowHeadersVisible = false;
            this.dgvInJobData1_L3.RowTemplate.Height = 23;
            this.dgvInJobData1_L3.Size = new System.Drawing.Size(163, 66);
            this.dgvInJobData1_L3.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "Key";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Width = 80;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "Value";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Width = 80;
            // 
            // dgvInJobData2_L3
            // 
            this.dgvInJobData2_L3.AllowUserToAddRows = false;
            this.dgvInJobData2_L3.AllowUserToDeleteRows = false;
            this.dgvInJobData2_L3.AllowUserToResizeRows = false;
            this.dgvInJobData2_L3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInJobData2_L3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14});
            this.dgvInJobData2_L3.Location = new System.Drawing.Point(647, 371);
            this.dgvInJobData2_L3.Name = "dgvInJobData2_L3";
            this.dgvInJobData2_L3.RowHeadersVisible = false;
            this.dgvInJobData2_L3.RowTemplate.Height = 23;
            this.dgvInJobData2_L3.Size = new System.Drawing.Size(163, 66);
            this.dgvInJobData2_L3.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.HeaderText = "Key";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.Width = 80;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.HeaderText = "Value";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.Width = 80;
            // 
            // btnInitDataL3
            // 
            this.btnInitDataL3.Location = new System.Drawing.Point(743, 107);
            this.btnInitDataL3.Name = "btnInitDataL3";
            this.btnInitDataL3.Size = new System.Drawing.Size(67, 23);
            this.btnInitDataL3.TabIndex = 3;
            this.btnInitDataL3.Text = "Clear";
            this.btnInitDataL3.UseVisualStyleBackColor = true;
            this.btnInitDataL3.Click += new System.EventHandler(this.btnInitDataL3_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1074, 562);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.btnVariableWrite);
            this.tabPage1.Controls.Add(this.btnVariableRead);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.btnInitDataL3);
            this.tabPage1.Controls.Add(this.dgvInJobData1_L3);
            this.tabPage1.Controls.Add(this.dgvInJobData2_L3);
            this.tabPage1.Controls.Add(this.dgvOutJobData1_L3);
            this.tabPage1.Controls.Add(this.dgvOutJobData2_L3);
            this.tabPage1.Controls.Add(this.textBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1066, 534);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "L2";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(497, 30);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(313, 23);
            this.comboBox1.TabIndex = 5;
            // 
            // btnVariableWrite
            // 
            this.btnVariableWrite.Location = new System.Drawing.Point(735, 66);
            this.btnVariableWrite.Name = "btnVariableWrite";
            this.btnVariableWrite.Size = new System.Drawing.Size(75, 23);
            this.btnVariableWrite.TabIndex = 4;
            this.btnVariableWrite.Text = "WRITE";
            this.btnVariableWrite.UseVisualStyleBackColor = true;
            this.btnVariableWrite.Click += new System.EventHandler(this.btnVariableWrite_Click);
            // 
            // btnVariableRead
            // 
            this.btnVariableRead.Location = new System.Drawing.Point(654, 66);
            this.btnVariableRead.Name = "btnVariableRead";
            this.btnVariableRead.Size = new System.Drawing.Size(75, 23);
            this.btnVariableRead.TabIndex = 4;
            this.btnVariableRead.Text = "READ";
            this.btnVariableRead.UseVisualStyleBackColor = true;
            this.btnVariableRead.Click += new System.EventHandler(this.btnVariableRead_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(816, 30);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(191, 335);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "5.2";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.txtCurrentPPIDRecipe);
            this.tabPage2.Controls.Add(this.cbAuthorizationResult);
            this.tabPage2.Controls.Add(this.txtCurRecipeID);
            this.tabPage2.Controls.Add(this.txtCurPPID);
            this.tabPage2.Controls.Add(this.txtReadPassword);
            this.tabPage2.Controls.Add(this.txtReadUserID);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1066, 534);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "L1";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(203, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 14;
            this.label3.Text = "Result";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 15);
            this.label2.TabIndex = 15;
            this.label2.Text = "Recipe Change User ID/Password";
            // 
            // txtCurrentPPIDRecipe
            // 
            this.txtCurrentPPIDRecipe.AutoSize = true;
            this.txtCurrentPPIDRecipe.Location = new System.Drawing.Point(12, 57);
            this.txtCurrentPPIDRecipe.Name = "txtCurrentPPIDRecipe";
            this.txtCurrentPPIDRecipe.Size = new System.Drawing.Size(129, 15);
            this.txtCurrentPPIDRecipe.TabIndex = 16;
            this.txtCurrentPPIDRecipe.Text = "Current PPID/RecipeID";
            // 
            // cbAuthorizationResult
            // 
            this.cbAuthorizationResult.FormattingEnabled = true;
            this.cbAuthorizationResult.Items.AddRange(new object[] {
            "1:ACCEPT",
            "2:REJECT"});
            this.cbAuthorizationResult.Location = new System.Drawing.Point(242, 24);
            this.cbAuthorizationResult.Name = "cbAuthorizationResult";
            this.cbAuthorizationResult.Size = new System.Drawing.Size(71, 23);
            this.cbAuthorizationResult.TabIndex = 13;
            this.cbAuthorizationResult.Text = "1:ACCEPT";
            // 
            // txtCurRecipeID
            // 
            this.txtCurRecipeID.Location = new System.Drawing.Point(136, 75);
            this.txtCurRecipeID.Name = "txtCurRecipeID";
            this.txtCurRecipeID.Size = new System.Drawing.Size(100, 23);
            this.txtCurRecipeID.TabIndex = 10;
            // 
            // txtCurPPID
            // 
            this.txtCurPPID.Location = new System.Drawing.Point(33, 75);
            this.txtCurPPID.Name = "txtCurPPID";
            this.txtCurPPID.Size = new System.Drawing.Size(100, 23);
            this.txtCurPPID.TabIndex = 9;
            // 
            // txtReadPassword
            // 
            this.txtReadPassword.Location = new System.Drawing.Point(136, 25);
            this.txtReadPassword.Name = "txtReadPassword";
            this.txtReadPassword.Size = new System.Drawing.Size(100, 23);
            this.txtReadPassword.TabIndex = 12;
            // 
            // txtReadUserID
            // 
            this.txtReadUserID.Location = new System.Drawing.Point(33, 25);
            this.txtReadUserID.Name = "txtReadUserID";
            this.txtReadUserID.Size = new System.Drawing.Size(100, 23);
            this.txtReadUserID.TabIndex = 11;
            // 
            // cJ2Compolet1
            // 
            this.cJ2Compolet1.Active = false;
            this.cJ2Compolet1.ConnectionType = OMRON.Compolet.CIP.ConnectionType.UCMM;
            this.cJ2Compolet1.HeartBeatTimer = 0;
            this.cJ2Compolet1.LocalPort = 2;
            this.cJ2Compolet1.PeerAddress = "";
            this.cJ2Compolet1.ReceiveTimeLimit = ((long)(750));
            this.cJ2Compolet1.RoutePath = "";
            this.cJ2Compolet1.UseRoutePath = false;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1074, 562);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "WHTM Simulator [INDEXER]";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInJobData2_L2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutJobData2_L2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInJobData1_L2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutJobData1_L2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutJobData1_L3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutJobData2_L3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInJobData1_L3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInJobData2_L3)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUnload;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnExchange;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkAbnormal3;
        private System.Windows.Forms.CheckBox chkAbnormal2;
        private System.Windows.Forms.CheckBox chkAbnormal1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.DataGridView dgvOutJobData1_L2;
        private System.Windows.Forms.DataGridView dgvInJobData2_L2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridView dgvOutJobData2_L2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridView dgvInJobData1_L2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValue;
        private System.Windows.Forms.DataGridView dgvOutJobData1_L3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridView dgvOutJobData2_L3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridView dgvInJobData1_L3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridView dgvInJobData2_L3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chkIndexerTrouble;
        private System.Windows.Forms.CheckBox chkIndexerInline;
        private System.Windows.Forms.Button btnEngineStop;
        private System.Windows.Forms.Button btnInitDataL3;
        private System.Windows.Forms.Button btnInitDataL2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnVariableWrite;
        private System.Windows.Forms.Button btnVariableRead;
        private System.Windows.Forms.TextBox textBox2;
        private OMRON.Compolet.CIP.CJ2Compolet cJ2Compolet1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txtCurrentPPIDRecipe;
        private System.Windows.Forms.ComboBox cbAuthorizationResult;
        private System.Windows.Forms.TextBox txtCurRecipeID;
        private System.Windows.Forms.TextBox txtCurPPID;
        private System.Windows.Forms.TextBox txtReadPassword;
        private System.Windows.Forms.TextBox txtReadUserID;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

