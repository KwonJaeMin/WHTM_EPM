namespace YANGSYS.UI
{
    partial class FormStageInfo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbTitle = new System.Windows.Forms.Label();
            this.dgvStagetInfo = new System.Windows.Forms.DataGridView();
            this.chkAutoRefresh = new System.Windows.Forms.CheckBox();
            this.colStageNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGlassCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStageStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStagetInfo)).BeginInit();
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
            this.lbTitle.Size = new System.Drawing.Size(318, 32);
            this.lbTitle.TabIndex = 59;
            this.lbTitle.Text = "STAGE GLASS DATA INFORMATION";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvStagetInfo
            // 
            this.dgvStagetInfo.AllowUserToAddRows = false;
            this.dgvStagetInfo.AllowUserToDeleteRows = false;
            this.dgvStagetInfo.AllowUserToResizeColumns = false;
            this.dgvStagetInfo.AllowUserToResizeRows = false;
            this.dgvStagetInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvStagetInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvStagetInfo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("맑은 고딕", 10F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStagetInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvStagetInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStagetInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colStageNo,
            this.colGlassCode,
            this.colStageStatus});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStagetInfo.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvStagetInfo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvStagetInfo.Location = new System.Drawing.Point(0, 35);
            this.dgvStagetInfo.MultiSelect = false;
            this.dgvStagetInfo.Name = "dgvStagetInfo";
            this.dgvStagetInfo.ReadOnly = true;
            this.dgvStagetInfo.RowHeadersVisible = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvStagetInfo.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvStagetInfo.RowTemplate.Height = 23;
            this.dgvStagetInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStagetInfo.Size = new System.Drawing.Size(317, 334);
            this.dgvStagetInfo.TabIndex = 60;
            // 
            // chkAutoRefresh
            // 
            this.chkAutoRefresh.AutoSize = true;
            this.chkAutoRefresh.Checked = true;
            this.chkAutoRefresh.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoRefresh.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkAutoRefresh.Location = new System.Drawing.Point(12, 375);
            this.chkAutoRefresh.Name = "chkAutoRefresh";
            this.chkAutoRefresh.Size = new System.Drawing.Size(113, 19);
            this.chkAutoRefresh.TabIndex = 61;
            this.chkAutoRefresh.Text = "AUTO REFRESH";
            this.chkAutoRefresh.UseVisualStyleBackColor = true;
            this.chkAutoRefresh.CheckedChanged += new System.EventHandler(this.chkAutoRefresh_CheckedChanged);
            // 
            // colStageNo
            // 
            this.colStageNo.HeaderText = "StageNo";
            this.colStageNo.Name = "colStageNo";
            this.colStageNo.ReadOnly = true;
            this.colStageNo.Width = 89;
            // 
            // colGlassCode
            // 
            this.colGlassCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colGlassCode.HeaderText = "Glass Code";
            this.colGlassCode.Name = "colGlassCode";
            this.colGlassCode.ReadOnly = true;
            // 
            // colStageStatus
            // 
            this.colStageStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colStageStatus.HeaderText = "Status";
            this.colStageStatus.Name = "colStageStatus";
            this.colStageStatus.ReadOnly = true;
            this.colStageStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colStageStatus.Width = 73;
            // 
            // FormStageInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 395);
            this.Controls.Add(this.chkAutoRefresh);
            this.Controls.Add(this.dgvStagetInfo);
            this.Controls.Add(this.lbTitle);
            this.Name = "FormStageInfo";
            this.Text = "STAGE GLASS DATA INFOMATION";
            ((System.ComponentModel.ISupportInitialize)(this.dgvStagetInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.DataGridView dgvStagetInfo;
        private System.Windows.Forms.CheckBox chkAutoRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStageNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGlassCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStageStatus;




    }
}