namespace MainProgram
{
    partial class FormPortInfo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvPortInfo = new System.Windows.Forms.DataGridView();
            this.colSlotNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGlassExist = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colOPType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGlassCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLotID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGlassID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRecipe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGlassJudge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGlassType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkAutoRefresh = new System.Windows.Forms.CheckBox();
            this.lbTitle = new System.Windows.Forms.Label();
            this.cbPortSelect = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPortInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPortInfo
            // 
            this.dgvPortInfo.AllowUserToAddRows = false;
            this.dgvPortInfo.AllowUserToDeleteRows = false;
            this.dgvPortInfo.AllowUserToResizeColumns = false;
            this.dgvPortInfo.AllowUserToResizeRows = false;
            this.dgvPortInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvPortInfo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("맑은 고딕", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPortInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPortInfo.ColumnHeadersHeight = 25;
            this.dgvPortInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSlotNumber,
            this.colGlassExist,
            this.colOPType,
            this.colGlassCode,
            this.colLotID,
            this.colGlassID,
            this.colRecipe,
            this.colGlassJudge,
            this.colGlassType});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPortInfo.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPortInfo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvPortInfo.Location = new System.Drawing.Point(0, 32);
            this.dgvPortInfo.MultiSelect = false;
            this.dgvPortInfo.Name = "dgvPortInfo";
            this.dgvPortInfo.ReadOnly = true;
            this.dgvPortInfo.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvPortInfo.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPortInfo.RowTemplate.Height = 23;
            this.dgvPortInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPortInfo.Size = new System.Drawing.Size(777, 514);
            this.dgvPortInfo.TabIndex = 0;
            // 
            // colSlotNumber
            // 
            this.colSlotNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colSlotNumber.HeaderText = "SLOT";
            this.colSlotNumber.Name = "colSlotNumber";
            this.colSlotNumber.ReadOnly = true;
            this.colSlotNumber.Width = 60;
            // 
            // colGlassExist
            // 
            this.colGlassExist.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colGlassExist.HeaderText = "GLS EXIST";
            this.colGlassExist.Name = "colGlassExist";
            this.colGlassExist.ReadOnly = true;
            this.colGlassExist.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colGlassExist.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colGlassExist.Width = 86;
            // 
            // colOPType
            // 
            this.colOPType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colOPType.HeaderText = "OP TYPE";
            this.colOPType.Name = "colOPType";
            this.colOPType.ReadOnly = true;
            this.colOPType.Width = 78;
            // 
            // colGlassCode
            // 
            this.colGlassCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colGlassCode.HeaderText = "GLS CODE";
            this.colGlassCode.Name = "colGlassCode";
            this.colGlassCode.ReadOnly = true;
            this.colGlassCode.Width = 89;
            // 
            // colLotID
            // 
            this.colLotID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colLotID.HeaderText = "LOT ID";
            this.colLotID.Name = "colLotID";
            this.colLotID.ReadOnly = true;
            // 
            // colGlassID
            // 
            this.colGlassID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colGlassID.HeaderText = "GLS ID";
            this.colGlassID.Name = "colGlassID";
            this.colGlassID.ReadOnly = true;
            // 
            // colRecipe
            // 
            this.colRecipe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colRecipe.HeaderText = "RECIPE";
            this.colRecipe.Name = "colRecipe";
            this.colRecipe.ReadOnly = true;
            this.colRecipe.Width = 69;
            // 
            // colGlassJudge
            // 
            this.colGlassJudge.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colGlassJudge.HeaderText = "GLS JUDGE";
            this.colGlassJudge.Name = "colGlassJudge";
            this.colGlassJudge.ReadOnly = true;
            // 
            // colGlassType
            // 
            this.colGlassType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colGlassType.HeaderText = "GLS TYPE";
            this.colGlassType.Name = "colGlassType";
            this.colGlassType.ReadOnly = true;
            this.colGlassType.Width = 83;
            // 
            // chkAutoRefresh
            // 
            this.chkAutoRefresh.AutoSize = true;
            this.chkAutoRefresh.Checked = true;
            this.chkAutoRefresh.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoRefresh.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkAutoRefresh.Location = new System.Drawing.Point(9, 552);
            this.chkAutoRefresh.Name = "chkAutoRefresh";
            this.chkAutoRefresh.Size = new System.Drawing.Size(113, 19);
            this.chkAutoRefresh.TabIndex = 62;
            this.chkAutoRefresh.Text = "AUTO REFRESH";
            this.chkAutoRefresh.UseVisualStyleBackColor = true;
            this.chkAutoRefresh.Visible = false;
            this.chkAutoRefresh.CheckedChanged += new System.EventHandler(this.chkAutoRefresh_CheckedChanged);
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
            this.lbTitle.Size = new System.Drawing.Size(777, 32);
            this.lbTitle.TabIndex = 63;
            this.lbTitle.Text = "PORT GLASS DATA INFORMATION";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbPortSelect
            // 
            this.cbPortSelect.BackColor = System.Drawing.SystemColors.Window;
            this.cbPortSelect.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.cbPortSelect.FormattingEnabled = true;
            this.cbPortSelect.Location = new System.Drawing.Point(573, 7);
            this.cbPortSelect.Name = "cbPortSelect";
            this.cbPortSelect.Size = new System.Drawing.Size(121, 23);
            this.cbPortSelect.TabIndex = 64;
            this.cbPortSelect.Text = ":::선택하세요:::";
            this.cbPortSelect.SelectedValueChanged += new System.EventHandler(this.cbPortSelect_SelectedValueChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.btnRefresh.Location = new System.Drawing.Point(320, 549);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(106, 26);
            this.btnRefresh.TabIndex = 65;
            this.btnRefresh.Text = "REFRESH";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnClose.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(715, 6);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(58, 24);
            this.btnClose.TabIndex = 69;
            this.btnClose.Text = "닫기";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // FormPortInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 579);
            this.CloseButtonEnable = true;
            this.ControlBox = false;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.cbPortSelect);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.dgvPortInfo);
            this.Controls.Add(this.chkAutoRefresh);
            this.Name = "FormPortInfo";
            this.Text = "FormPortInfo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPortInfo_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPortInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPortInfo;
        private System.Windows.Forms.CheckBox chkAutoRefresh;
        internal System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.ComboBox cbPortSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSlotNumber;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colGlassExist;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOPType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGlassCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLotID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGlassID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRecipe;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGlassJudge;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGlassType;
        private System.Windows.Forms.Button btnRefresh;
        internal System.Windows.Forms.Button btnClose;
    }
}