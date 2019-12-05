namespace YANGSYS.UI.WHTM
{
    partial class FormErrorDisplay
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
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnAllClear = new System.Windows.Forms.Button();
            this.btnCLOSE = new System.Windows.Forms.Button();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvErrorItem = new System.Windows.Forms.DataGridView();
            this.chkSimpleView = new System.Windows.Forms.CheckBox();
            this.colNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOccuredPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colErrorRegTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlTitle.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrorItem)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTitle
            // 
            this.pnlTitle.Controls.Add(this.label1);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(811, 61);
            this.pnlTitle.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(787, 48);
            this.label1.TabIndex = 2;
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.chkSimpleView);
            this.pnlMenu.Controls.Add(this.btnAllClear);
            this.pnlMenu.Controls.Add(this.btnCLOSE);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMenu.Location = new System.Drawing.Point(0, 298);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(811, 56);
            this.pnlMenu.TabIndex = 1;
            // 
            // btnAllClear
            // 
            this.btnAllClear.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAllClear.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAllClear.Location = new System.Drawing.Point(520, 0);
            this.btnAllClear.Name = "btnAllClear";
            this.btnAllClear.Size = new System.Drawing.Size(145, 56);
            this.btnAllClear.TabIndex = 16;
            this.btnAllClear.Text = "CLEAR";
            this.btnAllClear.UseVisualStyleBackColor = true;
            this.btnAllClear.Click += new System.EventHandler(this.btnAllClear_Click);
            // 
            // btnCLOSE
            // 
            this.btnCLOSE.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCLOSE.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCLOSE.Location = new System.Drawing.Point(665, 0);
            this.btnCLOSE.Name = "btnCLOSE";
            this.btnCLOSE.Size = new System.Drawing.Size(146, 56);
            this.btnCLOSE.TabIndex = 0;
            this.btnCLOSE.Text = "CLOSE";
            this.btnCLOSE.UseVisualStyleBackColor = true;
            this.btnCLOSE.Click += new System.EventHandler(this.btnCLOSE_Click);
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgvErrorItem);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 61);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(811, 237);
            this.pnlGrid.TabIndex = 2;
            // 
            // dgvErrorItem
            // 
            this.dgvErrorItem.AllowUserToAddRows = false;
            this.dgvErrorItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvErrorItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvErrorItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNO,
            this.colMessage,
            this.colOccuredPosition,
            this.colErrorRegTime});
            this.dgvErrorItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvErrorItem.Location = new System.Drawing.Point(0, 0);
            this.dgvErrorItem.Name = "dgvErrorItem";
            this.dgvErrorItem.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvErrorItem.RowTemplate.Height = 23;
            this.dgvErrorItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvErrorItem.Size = new System.Drawing.Size(811, 237);
            this.dgvErrorItem.TabIndex = 15;
            // 
            // chkSimpleView
            // 
            this.chkSimpleView.AutoSize = true;
            this.chkSimpleView.Font = new System.Drawing.Font("굴림", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkSimpleView.Location = new System.Drawing.Point(16, 22);
            this.chkSimpleView.Name = "chkSimpleView";
            this.chkSimpleView.Size = new System.Drawing.Size(104, 15);
            this.chkSimpleView.TabIndex = 17;
            this.chkSimpleView.Text = "Simple View";
            this.chkSimpleView.UseVisualStyleBackColor = true;
            this.chkSimpleView.CheckedChanged += new System.EventHandler(this.chkSimpleView_CheckedChanged);
            // 
            // colNO
            // 
            this.colNO.FillWeight = 5F;
            this.colNO.HeaderText = "NO";
            this.colNO.Name = "colNO";
            this.colNO.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colMessage
            // 
            this.colMessage.FillWeight = 81.10793F;
            this.colMessage.HeaderText = "MESSAGE";
            this.colMessage.Name = "colMessage";
            this.colMessage.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colOccuredPosition
            // 
            this.colOccuredPosition.FillWeight = 45F;
            this.colOccuredPosition.HeaderText = "OCCUR POSITION";
            this.colOccuredPosition.Name = "colOccuredPosition";
            this.colOccuredPosition.ReadOnly = true;
            this.colOccuredPosition.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colErrorRegTime
            // 
            this.colErrorRegTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colErrorRegTime.HeaderText = "RegTime";
            this.colErrorRegTime.Name = "colErrorRegTime";
            this.colErrorRegTime.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colErrorRegTime.Width = 81;
            // 
            // FormErrorDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(811, 354);
            this.ControlBox = false;
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlTitle);
            this.Name = "FormErrorDisplay";
            this.Text = "ERROR DISPLAY";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormErrorDisplay_FormClosing);
            this.pnlTitle.ResumeLayout(false);
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrorItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgvErrorItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAllClear;
        private System.Windows.Forms.Button btnCLOSE;
        private System.Windows.Forms.CheckBox chkSimpleView;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOccuredPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn colErrorRegTime;


    }
}