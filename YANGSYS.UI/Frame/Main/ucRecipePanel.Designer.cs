namespace YANGSYS.UI.WHTM
{
    partial class ucRecipePanel
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucRecipePanel));
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvPPIDRecipeMapView = new System.Windows.Forms.DataGridView();
            this.colPPID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRecipeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnChange = new System.Windows.Forms.Button();
            this.btnUploadRecipe = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ucRecipeStatus1 = new YANGSYS.UI.WHTM.ucRecipeStatus();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPPIDRecipeMapView)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1101, 24);
            this.label2.TabIndex = 127;
            this.label2.Text = "RECIPE";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.tabControl1.ItemSize = new System.Drawing.Size(350, 30);
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1101, 816);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 129;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvPPIDRecipeMapView);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1093, 778);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "PPID/RECIPE MAP";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvPPIDRecipeMapView
            // 
            this.dgvPPIDRecipeMapView.AllowUserToAddRows = false;
            this.dgvPPIDRecipeMapView.AllowUserToDeleteRows = false;
            this.dgvPPIDRecipeMapView.AllowUserToResizeRows = false;
            this.dgvPPIDRecipeMapView.ColumnHeadersHeight = 33;
            this.dgvPPIDRecipeMapView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPPID,
            this.colRecipeID,
            this.colCreateTime,
            this.colCreator,
            this.colDesc});
            this.dgvPPIDRecipeMapView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPPIDRecipeMapView.Location = new System.Drawing.Point(3, 141);
            this.dgvPPIDRecipeMapView.MultiSelect = false;
            this.dgvPPIDRecipeMapView.Name = "dgvPPIDRecipeMapView";
            this.dgvPPIDRecipeMapView.ReadOnly = true;
            this.dgvPPIDRecipeMapView.RowTemplate.Height = 23;
            this.dgvPPIDRecipeMapView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPPIDRecipeMapView.Size = new System.Drawing.Size(1087, 634);
            this.dgvPPIDRecipeMapView.TabIndex = 0;
            this.dgvPPIDRecipeMapView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPPIDRecipeMapView_CellClick);
            // 
            // colPPID
            // 
            this.colPPID.HeaderText = "PPID";
            this.colPPID.Name = "colPPID";
            this.colPPID.ReadOnly = true;
            this.colPPID.Width = 200;
            // 
            // colRecipeID
            // 
            this.colRecipeID.HeaderText = "RECIPE ID";
            this.colRecipeID.Name = "colRecipeID";
            this.colRecipeID.ReadOnly = true;
            this.colRecipeID.Width = 200;
            // 
            // colCreateTime
            // 
            this.colCreateTime.HeaderText = "CREATE TIME";
            this.colCreateTime.Name = "colCreateTime";
            this.colCreateTime.ReadOnly = true;
            this.colCreateTime.Width = 120;
            // 
            // colCreator
            // 
            this.colCreator.HeaderText = "CREATOR";
            this.colCreator.Name = "colCreator";
            this.colCreator.ReadOnly = true;
            // 
            // colDesc
            // 
            this.colDesc.HeaderText = "DESC";
            this.colDesc.Name = "colDesc";
            this.colDesc.ReadOnly = true;
            this.colDesc.Width = 300;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnChange);
            this.panel1.Controls.Add(this.btnUploadRecipe);
            this.panel1.Controls.Add(this.btnCreate);
            this.panel1.Controls.Add(this.comboBox2);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1087, 138);
            this.panel1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(79, 71);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(321, 25);
            this.textBox2.TabIndex = 49;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(79, 102);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(650, 25);
            this.textBox1.TabIndex = 49;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 15);
            this.label5.TabIndex = 48;
            this.label5.Text = "CREATOR";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 48;
            this.label4.Text = "DESC";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 48;
            this.label3.Text = "RECIPE ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 15);
            this.label1.TabIndex = 48;
            this.label1.Text = "PPID";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDelete.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDelete.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDelete.Location = new System.Drawing.Point(977, 91);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(95, 36);
            this.btnDelete.TabIndex = 47;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnChange
            // 
            this.btnChange.BackColor = System.Drawing.Color.Transparent;
            this.btnChange.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnChange.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnChange.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnChange.Location = new System.Drawing.Point(876, 91);
            this.btnChange.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(95, 36);
            this.btnChange.TabIndex = 47;
            this.btnChange.Text = "CHANGE";
            this.btnChange.UseVisualStyleBackColor = false;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnUploadRecipe
            // 
            this.btnUploadRecipe.BackColor = System.Drawing.Color.Transparent;
            this.btnUploadRecipe.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnUploadRecipe.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnUploadRecipe.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnUploadRecipe.Location = new System.Drawing.Point(406, 42);
            this.btnUploadRecipe.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUploadRecipe.Name = "btnUploadRecipe";
            this.btnUploadRecipe.Size = new System.Drawing.Size(95, 23);
            this.btnUploadRecipe.TabIndex = 47;
            this.btnUploadRecipe.Text = "UPLOAD";
            this.btnUploadRecipe.UseVisualStyleBackColor = false;
            this.btnUploadRecipe.Click += new System.EventHandler(this.btnUploadRecipe_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.Transparent;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCreate.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCreate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCreate.Location = new System.Drawing.Point(775, 91);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(95, 36);
            this.btnCreate.TabIndex = 47;
            this.btnCreate.Text = "CREATE";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(79, 42);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(321, 23);
            this.comboBox2.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(79, 13);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(321, 23);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ucRecipeStatus1);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1093, 778);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "RECIPE LIST";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ucRecipeStatus1
            // 
            this.ucRecipeStatus1.Alias = null;
            this.ucRecipeStatus1.BackColor = System.Drawing.SystemColors.Control;
            this.ucRecipeStatus1.BaseLocation = new System.Drawing.Point(0, 0);
            this.ucRecipeStatus1.BaseSize = new System.Drawing.Size(60, 60);
            this.ucRecipeStatus1.ControlLocation = new System.Drawing.Point(14, 4);
            this.ucRecipeStatus1.ControlName = "ControlName";
            this.ucRecipeStatus1.ControlSize = new System.Drawing.Size(60, 60);
            this.ucRecipeStatus1.ElementId = null;
            this.ucRecipeStatus1.eqpFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ucRecipeStatus1.eqpLineColor = System.Drawing.Color.Gold;
            this.ucRecipeStatus1.eqpLineWidth = 7F;
            this.ucRecipeStatus1.Font = new System.Drawing.Font("Arial", 9F);
            this.ucRecipeStatus1.FrameID = "";
            this.ucRecipeStatus1.Location = new System.Drawing.Point(14, 4);
            this.ucRecipeStatus1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucRecipeStatus1.ModelType = "NONE";
            this.ucRecipeStatus1.Name = "ucRecipeStatus1";
            this.ucRecipeStatus1.ObjectName = "";
            this.ucRecipeStatus1.Rotation = SOFD.Component.Interface.enumControlRotation.ROTATION_000;
            this.ucRecipeStatus1.Size = new System.Drawing.Size(1065, 781);
            this.ucRecipeStatus1.TabIndex = 128;
            // 
            // ucRecipePanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label2);
            this.Name = "ucRecipePanel";
            this.Size = new System.Drawing.Size(1101, 840);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPPIDRecipeMapView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label label2;
        private ucRecipeStatus ucRecipeStatus1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBox1;
        internal System.Windows.Forms.Button btnDelete;
        internal System.Windows.Forms.Button btnChange;
        internal System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Button btnUploadRecipe;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvPPIDRecipeMapView;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPPID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRecipeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreator;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDesc;
    }
}
