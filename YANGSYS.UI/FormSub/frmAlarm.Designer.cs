namespace YANGSYS.UI.WHTM
{
    partial class frmAlarm
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
            this.btnBuzzerOff = new System.Windows.Forms.Button();
            this.dgvAlarmView = new System.Windows.Forms.DataGridView();
            this.button = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAlarmId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClearable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlarmView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBuzzerOff
            // 
            this.btnBuzzerOff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnBuzzerOff.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnBuzzerOff.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBuzzerOff.Location = new System.Drawing.Point(538, 9);
            this.btnBuzzerOff.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBuzzerOff.Name = "btnBuzzerOff";
            this.btnBuzzerOff.Size = new System.Drawing.Size(184, 40);
            this.btnBuzzerOff.TabIndex = 54;
            this.btnBuzzerOff.Text = "BUZZER OFF";
            this.btnBuzzerOff.UseVisualStyleBackColor = false;
            this.btnBuzzerOff.Click += new System.EventHandler(this.btnBuzzerOff_Click);
            // 
            // dgvAlarmView
            // 
            this.dgvAlarmView.AllowUserToAddRows = false;
            this.dgvAlarmView.AllowUserToDeleteRows = false;
            this.dgvAlarmView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvAlarmView.BackgroundColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAlarmView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAlarmView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTime,
            this.colAlarmId,
            this.colCode,
            this.colType,
            this.colPosition,
            this.colMessage,
            this.colClearable});
            this.dgvAlarmView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAlarmView.Location = new System.Drawing.Point(2, 34);
            this.dgvAlarmView.MultiSelect = false;
            this.dgvAlarmView.Name = "dgvAlarmView";
            this.dgvAlarmView.ReadOnly = true;
            this.dgvAlarmView.RowHeadersWidth = 30;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dgvAlarmView.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAlarmView.RowTemplate.Height = 23;
            this.dgvAlarmView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvAlarmView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAlarmView.Size = new System.Drawing.Size(919, 261);
            this.dgvAlarmView.TabIndex = 52;
            // 
            // button
            // 
            this.button.AutoSize = true;
            this.button.Location = new System.Drawing.Point(0, 0);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(75, 23);
            this.button.TabIndex = 0;
            this.button.UseMnemonic = false;
            this.button.UseVisualStyleBackColor = false;
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label2.Font = new System.Drawing.Font("Malgun Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Label2.ForeColor = System.Drawing.Color.White;
            this.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label2.Location = new System.Drawing.Point(2, 2);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(919, 32);
            this.Label2.TabIndex = 50;
            this.Label2.Text = "CURRENT ALARMS";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(728, 9);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(184, 40);
            this.btnClose.TabIndex = 55;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnBuzzerOff);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(2, 295);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(919, 60);
            this.panel1.TabIndex = 56;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button1.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(388, 9);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 40);
            this.button1.TabIndex = 54;
            this.button1.Text = "ALARM RESET";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // colTime
            // 
            this.colTime.HeaderText = "TIME";
            this.colTime.Name = "colTime";
            this.colTime.ReadOnly = true;
            this.colTime.Width = 58;
            // 
            // colAlarmId
            // 
            this.colAlarmId.HeaderText = "ID";
            this.colAlarmId.Name = "colAlarmId";
            this.colAlarmId.ReadOnly = true;
            this.colAlarmId.Width = 44;
            // 
            // colCode
            // 
            this.colCode.HeaderText = "CODE";
            this.colCode.Name = "colCode";
            this.colCode.ReadOnly = true;
            this.colCode.Width = 64;
            // 
            // colType
            // 
            this.colType.HeaderText = "TYPE";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            this.colType.Width = 58;
            // 
            // colPosition
            // 
            this.colPosition.HeaderText = "POSITION";
            this.colPosition.Name = "colPosition";
            this.colPosition.ReadOnly = true;
            this.colPosition.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colPosition.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colPosition.Width = 66;
            // 
            // colMessage
            // 
            this.colMessage.HeaderText = "MESSAGE";
            this.colMessage.Name = "colMessage";
            this.colMessage.ReadOnly = true;
            this.colMessage.Width = 85;
            // 
            // colClearable
            // 
            this.colClearable.HeaderText = "CLEARABLE";
            this.colClearable.Name = "colClearable";
            this.colClearable.ReadOnly = true;
            this.colClearable.Width = 94;
            // 
            // frmAlarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(923, 357);
            this.ControlBox = false;
            this.Controls.Add(this.dgvAlarmView);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmAlarm";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Current Alarms";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlarmView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button btnBuzzerOff;
        internal System.Windows.Forms.DataGridView dgvAlarmView;
        internal System.Windows.Forms.Button button;
        public System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAlarmId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClearable;
    }
}