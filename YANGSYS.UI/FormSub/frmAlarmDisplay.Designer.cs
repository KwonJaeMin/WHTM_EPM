namespace YANGSYS.UI.WHTM
{
    partial class frmAlarmDisplay
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
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.Label2 = new System.Windows.Forms.Label();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnAllClear = new System.Windows.Forms.Button();
            this.btnCLOSE = new System.Windows.Forms.Button();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.colMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAlarmCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvAlarmItem = new System.Windows.Forms.DataGridView();
            this.pnlTitle.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlarmItem)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTitle
            // 
            this.pnlTitle.Controls.Add(this.Label2);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(811, 42);
            this.pnlTitle.TabIndex = 0;
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.Color.Black;
            this.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label2.Font = new System.Drawing.Font("Malgun Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Label2.ForeColor = System.Drawing.Color.White;
            this.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label2.Location = new System.Drawing.Point(0, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(811, 42);
            this.Label2.TabIndex = 52;
            this.Label2.Text = "ALARM LIST";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.btnAllClear);
            this.pnlMenu.Controls.Add(this.btnCLOSE);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMenu.Location = new System.Drawing.Point(0, 282);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(811, 56);
            this.pnlMenu.TabIndex = 1;
            this.pnlMenu.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pnlMenu_MouseDoubleClick);
            // 
            // btnAllClear
            // 
            this.btnAllClear.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.btnAllClear.Location = new System.Drawing.Point(486, 10);
            this.btnAllClear.Name = "btnAllClear";
            this.btnAllClear.Size = new System.Drawing.Size(145, 35);
            this.btnAllClear.TabIndex = 16;
            this.btnAllClear.Text = "CLEAR";
            this.btnAllClear.UseVisualStyleBackColor = true;
            this.btnAllClear.Click += new System.EventHandler(this.btnAllClear_Click);
            // 
            // btnCLOSE
            // 
            this.btnCLOSE.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.btnCLOSE.Location = new System.Drawing.Point(655, 10);
            this.btnCLOSE.Name = "btnCLOSE";
            this.btnCLOSE.Size = new System.Drawing.Size(146, 35);
            this.btnCLOSE.TabIndex = 0;
            this.btnCLOSE.Text = "CLOSE";
            this.btnCLOSE.UseVisualStyleBackColor = true;
            this.btnCLOSE.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgvAlarmItem);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 42);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(811, 240);
            this.pnlGrid.TabIndex = 2;
            // 
            // colMessage
            // 
            this.colMessage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMessage.FillWeight = 81.10793F;
            this.colMessage.HeaderText = "MESSAGE";
            this.colMessage.Name = "colMessage";
            this.colMessage.ReadOnly = true;
            // 
            // colPosition
            // 
            this.colPosition.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colPosition.HeaderText = "POSITION";
            this.colPosition.Name = "colPosition";
            this.colPosition.ReadOnly = true;
            this.colPosition.Width = 85;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "STATUS";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Width = 5;
            // 
            // colType
            // 
            this.colType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colType.HeaderText = "TYPE";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            this.colType.Width = 58;
            // 
            // colAlarmCode
            // 
            this.colAlarmCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colAlarmCode.FillWeight = 45F;
            this.colAlarmCode.HeaderText = "CODE";
            this.colAlarmCode.Name = "colAlarmCode";
            this.colAlarmCode.ReadOnly = true;
            this.colAlarmCode.Width = 64;
            // 
            // colTime
            // 
            this.colTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colTime.HeaderText = "TIME";
            this.colTime.Name = "colTime";
            this.colTime.Width = 58;
            // 
            // colNO
            // 
            this.colNO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colNO.FillWeight = 5F;
            this.colNO.HeaderText = "NO";
            this.colNO.Name = "colNO";
            this.colNO.Width = 50;
            // 
            // dgvAlarmItem
            // 
            this.dgvAlarmItem.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAlarmItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAlarmItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNO,
            this.colTime,
            this.colAlarmCode,
            this.colType,
            this.colStatus,
            this.colPosition,
            this.colMessage});
            this.dgvAlarmItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAlarmItem.Location = new System.Drawing.Point(0, 0);
            this.dgvAlarmItem.Name = "dgvAlarmItem";
            this.dgvAlarmItem.RowTemplate.Height = 23;
            this.dgvAlarmItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAlarmItem.Size = new System.Drawing.Size(811, 240);
            this.dgvAlarmItem.TabIndex = 15;
            // 
            // FormAlarmDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(811, 338);
            this.ControlBox = false;
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlTitle);
            this.Name = "FormAlarmDisplay";
            this.Text = "ALARM DISPLAY";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAlarmDisplay_FormClosing);
            this.pnlTitle.ResumeLayout(false);
            this.pnlMenu.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlarmItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Button btnAllClear;
        private System.Windows.Forms.Button btnCLOSE;
        internal System.Windows.Forms.Label Label2;
        private System.Windows.Forms.DataGridView dgvAlarmItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAlarmCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMessage;


    }
}