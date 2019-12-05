namespace YANGSYS.UI.WHTM
{
    partial class ucLog
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
            this.btnExcelFileSave = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.cmbEquipmentName = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSearchEquipmentName = new System.Windows.Forms.Label();
            this.dgvLog = new System.Windows.Forms.DataGridView();
            this.Label7 = new System.Windows.Forms.Label();
            this.pnlDataPanelBack = new System.Windows.Forms.Panel();
            this.rtbDataDetailView = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grbLogSearch = new System.Windows.Forms.GroupBox();
            this.dtpFindDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.grbLogKind = new System.Windows.Forms.GroupBox();
            this.rdbGUI = new System.Windows.Forms.RadioButton();
            this.rdbCORE = new System.Windows.Forms.RadioButton();
            this.rdbAlarm = new System.Windows.Forms.RadioButton();
            this.rdbInterface = new System.Windows.Forms.RadioButton();
            this.chkDataPanelVisible = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rdbEqpInterface = new System.Windows.Forms.RadioButton();
            this.rdbGlassData = new System.Windows.Forms.RadioButton();
            this.grbExcelOut = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).BeginInit();
            this.pnlDataPanelBack.SuspendLayout();
            this.panel2.SuspendLayout();
            this.grbLogSearch.SuspendLayout();
            this.grbLogKind.SuspendLayout();
            this.grbExcelOut.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExcelFileSave
            // 
            this.btnExcelFileSave.Location = new System.Drawing.Point(15, 14);
            this.btnExcelFileSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExcelFileSave.Name = "btnExcelFileSave";
            this.btnExcelFileSave.Size = new System.Drawing.Size(98, 30);
            this.btnExcelFileSave.TabIndex = 10;
            this.btnExcelFileSave.Text = "SAVE CSV";
            this.btnExcelFileSave.UseVisualStyleBackColor = true;
            // 
            // btnPrevious
            // 
            this.btnPrevious.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPrevious.Location = new System.Drawing.Point(235, 15);
            this.btnPrevious.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(49, 30);
            this.btnPrevious.TabIndex = 7;
            this.btnPrevious.Text = "<";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btn_Click);
            // 
            // cmbEquipmentName
            // 
            this.cmbEquipmentName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEquipmentName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbEquipmentName.FormattingEnabled = true;
            this.cmbEquipmentName.Location = new System.Drawing.Point(828, 6);
            this.cmbEquipmentName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbEquipmentName.Name = "cmbEquipmentName";
            this.cmbEquipmentName.Size = new System.Drawing.Size(145, 23);
            this.cmbEquipmentName.TabIndex = 3;
            this.cmbEquipmentName.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbEquipmentName);
            this.panel1.Controls.Add(this.lblSearchEquipmentName);
            this.panel1.Controls.Add(this.dgvLog);
            this.panel1.Controls.Add(this.Label7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1, 147);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(826, 692);
            this.panel1.TabIndex = 133;
            // 
            // lblSearchEquipmentName
            // 
            this.lblSearchEquipmentName.BackColor = System.Drawing.Color.Gray;
            this.lblSearchEquipmentName.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.lblSearchEquipmentName.ForeColor = System.Drawing.Color.White;
            this.lblSearchEquipmentName.Location = new System.Drawing.Point(724, 2);
            this.lblSearchEquipmentName.Name = "lblSearchEquipmentName";
            this.lblSearchEquipmentName.Size = new System.Drawing.Size(258, 20);
            this.lblSearchEquipmentName.TabIndex = 2;
            this.lblSearchEquipmentName.Text = " EQP NAME :";
            this.lblSearchEquipmentName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSearchEquipmentName.Visible = false;
            // 
            // dgvLog
            // 
            this.dgvLog.AllowUserToAddRows = false;
            this.dgvLog.AllowUserToDeleteRows = false;
            this.dgvLog.AllowUserToResizeRows = false;
            this.dgvLog.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLog.Location = new System.Drawing.Point(0, 26);
            this.dgvLog.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvLog.Name = "dgvLog";
            this.dgvLog.ReadOnly = true;
            this.dgvLog.RowTemplate.Height = 23;
            this.dgvLog.Size = new System.Drawing.Size(826, 666);
            this.dgvLog.TabIndex = 0;
            this.dgvLog.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLog_CellClick);
            // 
            // Label7
            // 
            this.Label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label7.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label7.ForeColor = System.Drawing.Color.White;
            this.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label7.Location = new System.Drawing.Point(0, 0);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(826, 26);
            this.Label7.TabIndex = 126;
            this.Label7.Tag = "";
            this.Label7.Text = "SEARCH RESULT";
            this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlDataPanelBack
            // 
            this.pnlDataPanelBack.Controls.Add(this.rtbDataDetailView);
            this.pnlDataPanelBack.Controls.Add(this.label3);
            this.pnlDataPanelBack.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDataPanelBack.Location = new System.Drawing.Point(827, 147);
            this.pnlDataPanelBack.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlDataPanelBack.Name = "pnlDataPanelBack";
            this.pnlDataPanelBack.Size = new System.Drawing.Size(273, 692);
            this.pnlDataPanelBack.TabIndex = 129;
            this.pnlDataPanelBack.Visible = false;
            // 
            // rtbDataDetailView
            // 
            this.rtbDataDetailView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbDataDetailView.Location = new System.Drawing.Point(0, 26);
            this.rtbDataDetailView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtbDataDetailView.Name = "rtbDataDetailView";
            this.rtbDataDetailView.Size = new System.Drawing.Size(273, 666);
            this.rtbDataDetailView.TabIndex = 127;
            this.rtbDataDetailView.Text = "";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(273, 26);
            this.label3.TabIndex = 127;
            this.label3.Tag = "";
            this.label3.Text = "DATA";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSearch.Location = new System.Drawing.Point(364, 15);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(118, 30);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "SEARCH";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnNext.Location = new System.Drawing.Point(302, 15);
            this.btnNext.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(49, 30);
            this.btnNext.TabIndex = 9;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btn_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.grbExcelOut);
            this.panel2.Controls.Add(this.grbLogSearch);
            this.panel2.Controls.Add(this.grbLogKind);
            this.panel2.Controls.Add(this.chkDataPanelVisible);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(1, 25);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(1);
            this.panel2.Size = new System.Drawing.Size(1099, 122);
            this.panel2.TabIndex = 130;
            // 
            // grbLogSearch
            // 
            this.grbLogSearch.Controls.Add(this.btnNext);
            this.grbLogSearch.Controls.Add(this.btnSearch);
            this.grbLogSearch.Controls.Add(this.btnPrevious);
            this.grbLogSearch.Controls.Add(this.dtpFindDate);
            this.grbLogSearch.Controls.Add(this.label1);
            this.grbLogSearch.Location = new System.Drawing.Point(13, 65);
            this.grbLogSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbLogSearch.Name = "grbLogSearch";
            this.grbLogSearch.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbLogSearch.Size = new System.Drawing.Size(489, 54);
            this.grbLogSearch.TabIndex = 3;
            this.grbLogSearch.TabStop = false;
            this.grbLogSearch.Text = "SEARCH CONDITION";
            // 
            // dtpFindDate
            // 
            this.dtpFindDate.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpFindDate.Location = new System.Drawing.Point(54, 19);
            this.dtpFindDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFindDate.Name = "dtpFindDate";
            this.dtpFindDate.Size = new System.Drawing.Size(171, 23);
            this.dtpFindDate.TabIndex = 1;
            this.dtpFindDate.ValueChanged += new System.EventHandler(this.dtpFindDate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "DATE :";
            // 
            // grbLogKind
            // 
            this.grbLogKind.Controls.Add(this.rdbGUI);
            this.grbLogKind.Controls.Add(this.rdbCORE);
            this.grbLogKind.Controls.Add(this.rdbAlarm);
            this.grbLogKind.Controls.Add(this.rdbGlassData);
            this.grbLogKind.Controls.Add(this.rdbEqpInterface);
            this.grbLogKind.Controls.Add(this.rdbInterface);
            this.grbLogKind.Location = new System.Drawing.Point(13, 5);
            this.grbLogKind.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbLogKind.Name = "grbLogKind";
            this.grbLogKind.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbLogKind.Size = new System.Drawing.Size(624, 54);
            this.grbLogKind.TabIndex = 0;
            this.grbLogKind.TabStop = false;
            this.grbLogKind.Text = "LOG CATAGORY";
            // 
            // rdbGUI
            // 
            this.rdbGUI.AutoSize = true;
            this.rdbGUI.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.rdbGUI.Location = new System.Drawing.Point(7, 18);
            this.rdbGUI.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdbGUI.Name = "rdbGUI";
            this.rdbGUI.Size = new System.Drawing.Size(47, 19);
            this.rdbGUI.TabIndex = 5;
            this.rdbGUI.TabStop = true;
            this.rdbGUI.Text = "GUI";
            this.rdbGUI.UseVisualStyleBackColor = true;
            // 
            // rdbCORE
            // 
            this.rdbCORE.AutoSize = true;
            this.rdbCORE.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.rdbCORE.Location = new System.Drawing.Point(243, 18);
            this.rdbCORE.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdbCORE.Name = "rdbCORE";
            this.rdbCORE.Size = new System.Drawing.Size(71, 19);
            this.rdbCORE.TabIndex = 3;
            this.rdbCORE.TabStop = true;
            this.rdbCORE.Text = "SYSTEM";
            this.rdbCORE.UseVisualStyleBackColor = true;
            // 
            // rdbAlarm
            // 
            this.rdbAlarm.AutoSize = true;
            this.rdbAlarm.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.rdbAlarm.Location = new System.Drawing.Point(160, 18);
            this.rdbAlarm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdbAlarm.Name = "rdbAlarm";
            this.rdbAlarm.Size = new System.Drawing.Size(67, 19);
            this.rdbAlarm.TabIndex = 2;
            this.rdbAlarm.TabStop = true;
            this.rdbAlarm.Text = "ALARM";
            this.rdbAlarm.UseVisualStyleBackColor = true;
            // 
            // rdbInterface
            // 
            this.rdbInterface.AutoSize = true;
            this.rdbInterface.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.rdbInterface.Location = new System.Drawing.Point(63, 18);
            this.rdbInterface.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdbInterface.Name = "rdbInterface";
            this.rdbInterface.Size = new System.Drawing.Size(88, 19);
            this.rdbInterface.TabIndex = 1;
            this.rdbInterface.TabStop = true;
            this.rdbInterface.Text = "INTERFACE";
            this.rdbInterface.UseVisualStyleBackColor = true;
            // 
            // chkDataPanelVisible
            // 
            this.chkDataPanelVisible.AutoSize = true;
            this.chkDataPanelVisible.ForeColor = System.Drawing.Color.Black;
            this.chkDataPanelVisible.Location = new System.Drawing.Point(643, 90);
            this.chkDataPanelVisible.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkDataPanelVisible.Name = "chkDataPanelVisible";
            this.chkDataPanelVisible.Size = new System.Drawing.Size(89, 19);
            this.chkDataPanelVisible.TabIndex = 132;
            this.chkDataPanelVisible.Text = "DATA VIEW";
            this.chkDataPanelVisible.UseVisualStyleBackColor = true;
            this.chkDataPanelVisible.CheckedChanged += new System.EventHandler(this.chkDataPanelVisible_CheckedChanged);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(1, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1099, 24);
            this.label2.TabIndex = 126;
            this.label2.Text = "LOG";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rdbEqpInterface
            // 
            this.rdbEqpInterface.AutoSize = true;
            this.rdbEqpInterface.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.rdbEqpInterface.Location = new System.Drawing.Point(320, 18);
            this.rdbEqpInterface.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdbEqpInterface.Name = "rdbEqpInterface";
            this.rdbEqpInterface.Size = new System.Drawing.Size(47, 19);
            this.rdbEqpInterface.TabIndex = 1;
            this.rdbEqpInterface.TabStop = true;
            this.rdbEqpInterface.Text = "EQP";
            this.rdbEqpInterface.UseVisualStyleBackColor = true;
            // 
            // rdbGlassData
            // 
            this.rdbGlassData.AutoSize = true;
            this.rdbGlassData.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold);
            this.rdbGlassData.Location = new System.Drawing.Point(373, 18);
            this.rdbGlassData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdbGlassData.Name = "rdbGlassData";
            this.rdbGlassData.Size = new System.Drawing.Size(62, 19);
            this.rdbGlassData.TabIndex = 1;
            this.rdbGlassData.TabStop = true;
            this.rdbGlassData.Text = "GLASS";
            this.rdbGlassData.UseVisualStyleBackColor = true;
            // 
            // grbExcelOut
            // 
            this.grbExcelOut.Controls.Add(this.btnExcelFileSave);
            this.grbExcelOut.Location = new System.Drawing.Point(508, 66);
            this.grbExcelOut.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbExcelOut.Name = "grbExcelOut";
            this.grbExcelOut.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbExcelOut.Size = new System.Drawing.Size(129, 52);
            this.grbExcelOut.TabIndex = 4;
            this.grbExcelOut.TabStop = false;
            this.grbExcelOut.Text = "FILE";
            // 
            // ucLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlDataPanelBack);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Malgun Gothic", 9F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ucLog";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Size = new System.Drawing.Size(1101, 840);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).EndInit();
            this.pnlDataPanelBack.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.grbLogSearch.ResumeLayout(false);
            this.grbLogSearch.PerformLayout();
            this.grbLogKind.ResumeLayout(false);
            this.grbLogKind.PerformLayout();
            this.grbExcelOut.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExcelFileSave;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.ComboBox cmbEquipmentName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvLog;
        internal System.Windows.Forms.Label Label7;
        private System.Windows.Forms.Panel pnlDataPanelBack;
        private System.Windows.Forms.RichTextBox rtbDataDetailView;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox grbLogSearch;
        private System.Windows.Forms.Label lblSearchEquipmentName;
        private System.Windows.Forms.DateTimePicker dtpFindDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grbLogKind;
        private System.Windows.Forms.RadioButton rdbAlarm;
        private System.Windows.Forms.RadioButton rdbInterface;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkDataPanelVisible;
        private System.Windows.Forms.RadioButton rdbCORE;
        private System.Windows.Forms.RadioButton rdbGUI;
        private System.Windows.Forms.RadioButton rdbEqpInterface;
        private System.Windows.Forms.RadioButton rdbGlassData;
        private System.Windows.Forms.GroupBox grbExcelOut;



    }
}
