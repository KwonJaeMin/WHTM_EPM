﻿namespace YANGSYS.UI
{
    partial class frmOVENInfo
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
            this.Panel4 = new System.Windows.Forms.Panel();
            this.cmbEqpNo = new System.Windows.Forms.ComboBox();
            this.lblGlsPnlJudge = new System.Windows.Forms.Label();
            this.Label14 = new System.Windows.Forms.Label();
            this.lblGlsPnlGrade = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.btnEditData = new System.Windows.Forms.Button();
            this.lblLoadTime = new System.Windows.Forms.Label();
            this.Label11 = new System.Windows.Forms.Label();
            this.dgvSlotInformation = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Label7 = new System.Windows.Forms.Label();
            this.lblQty = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.lblOvenID = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.Panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSlotInformation)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlButtonBack
            // 
            this.pnlButtonBack.Location = new System.Drawing.Point(0, 380);
            this.pnlButtonBack.Size = new System.Drawing.Size(1075, 39);
            // 
            // Panel4
            // 
            this.Panel4.BackColor = System.Drawing.SystemColors.Control;
            this.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel4.Controls.Add(this.cmbEqpNo);
            this.Panel4.Controls.Add(this.lblGlsPnlJudge);
            this.Panel4.Controls.Add(this.Label14);
            this.Panel4.Controls.Add(this.lblGlsPnlGrade);
            this.Panel4.Controls.Add(this.Label12);
            this.Panel4.Controls.Add(this.btnEditData);
            this.Panel4.Controls.Add(this.lblLoadTime);
            this.Panel4.Controls.Add(this.Label11);
            this.Panel4.Controls.Add(this.dgvSlotInformation);
            this.Panel4.Controls.Add(this.Label7);
            this.Panel4.Controls.Add(this.lblQty);
            this.Panel4.Controls.Add(this.Label6);
            this.Panel4.Controls.Add(this.lblOvenID);
            this.Panel4.Controls.Add(this.Label4);
            this.Panel4.Controls.Add(this.Label2);
            this.Panel4.Controls.Add(this.Label8);
            this.Panel4.Location = new System.Drawing.Point(0, 4);
            this.Panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Panel4.Name = "Panel4";
            this.Panel4.Size = new System.Drawing.Size(1075, 419);
            this.Panel4.TabIndex = 22;
            // 
            // cmbEqpNo
            // 
            this.cmbEqpNo.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmbEqpNo.FormattingEnabled = true;
            this.cmbEqpNo.Location = new System.Drawing.Point(103, 32);
            this.cmbEqpNo.Name = "cmbEqpNo";
            this.cmbEqpNo.Size = new System.Drawing.Size(48, 25);
            this.cmbEqpNo.TabIndex = 158;
            this.cmbEqpNo.SelectedValueChanged += new System.EventHandler(this.cmbEqpNo_SelectedValueChanged);
            // 
            // lblGlsPnlJudge
            // 
            this.lblGlsPnlJudge.BackColor = System.Drawing.Color.White;
            this.lblGlsPnlJudge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblGlsPnlJudge.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblGlsPnlJudge.ForeColor = System.Drawing.Color.Black;
            this.lblGlsPnlJudge.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblGlsPnlJudge.Location = new System.Drawing.Point(124, 361);
            this.lblGlsPnlJudge.Name = "lblGlsPnlJudge";
            this.lblGlsPnlJudge.Size = new System.Drawing.Size(771, 24);
            this.lblGlsPnlJudge.TabIndex = 53;
            this.lblGlsPnlJudge.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label14
            // 
            this.Label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label14.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label14.ForeColor = System.Drawing.Color.White;
            this.Label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label14.Location = new System.Drawing.Point(12, 361);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(112, 24);
            this.Label14.TabIndex = 52;
            this.Label14.Text = "GLSPNLJUDGE";
            this.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGlsPnlGrade
            // 
            this.lblGlsPnlGrade.BackColor = System.Drawing.Color.White;
            this.lblGlsPnlGrade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblGlsPnlGrade.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblGlsPnlGrade.ForeColor = System.Drawing.Color.Black;
            this.lblGlsPnlGrade.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblGlsPnlGrade.Location = new System.Drawing.Point(124, 385);
            this.lblGlsPnlGrade.Name = "lblGlsPnlGrade";
            this.lblGlsPnlGrade.Size = new System.Drawing.Size(771, 24);
            this.lblGlsPnlGrade.TabIndex = 51;
            this.lblGlsPnlGrade.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label12
            // 
            this.Label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label12.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label12.ForeColor = System.Drawing.Color.White;
            this.Label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label12.Location = new System.Drawing.Point(12, 385);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(112, 24);
            this.Label12.TabIndex = 50;
            this.Label12.Text = "GLSPNLGRADE";
            this.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnEditData
            // 
            this.btnEditData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnEditData.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnEditData.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnEditData.Location = new System.Drawing.Point(902, 361);
            this.btnEditData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEditData.Name = "btnEditData";
            this.btnEditData.Size = new System.Drawing.Size(168, 48);
            this.btnEditData.TabIndex = 49;
            this.btnEditData.Text = "EDIT DATA";
            this.btnEditData.UseVisualStyleBackColor = false;
            this.btnEditData.Click += new System.EventHandler(this.btnEditData_Click);
            // 
            // lblLoadTime
            // 
            this.lblLoadTime.BackColor = System.Drawing.Color.White;
            this.lblLoadTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLoadTime.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblLoadTime.ForeColor = System.Drawing.Color.Black;
            this.lblLoadTime.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblLoadTime.Location = new System.Drawing.Point(790, 32);
            this.lblLoadTime.Name = "lblLoadTime";
            this.lblLoadTime.Size = new System.Drawing.Size(192, 24);
            this.lblLoadTime.TabIndex = 48;
            this.lblLoadTime.Text = "2010-03-21 23:59:59";
            this.lblLoadTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label11
            // 
            this.Label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label11.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label11.ForeColor = System.Drawing.Color.White;
            this.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label11.Location = new System.Drawing.Point(694, 32);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(96, 24);
            this.Label11.TabIndex = 47;
            this.Label11.Text = "LOAD TIME";
            this.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvSlotInformation
            // 
            this.dgvSlotInformation.AllowUserToAddRows = false;
            this.dgvSlotInformation.AllowUserToDeleteRows = false;
            this.dgvSlotInformation.AllowUserToResizeColumns = false;
            this.dgvSlotInformation.AllowUserToResizeRows = false;
            this.dgvSlotInformation.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvSlotInformation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSlotInformation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column4,
            this.Column5,
            this.Column17,
            this.Column8,
            this.Column2,
            this.Column3,
            this.Column6,
            this.Column7});
            this.dgvSlotInformation.Location = new System.Drawing.Point(12, 88);
            this.dgvSlotInformation.MultiSelect = false;
            this.dgvSlotInformation.Name = "dgvSlotInformation";
            this.dgvSlotInformation.ReadOnly = true;
            this.dgvSlotInformation.RowHeadersWidth = 30;
            this.dgvSlotInformation.RowTemplate.Height = 23;
            this.dgvSlotInformation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvSlotInformation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSlotInformation.Size = new System.Drawing.Size(1058, 266);
            this.dgvSlotInformation.TabIndex = 44;
            this.dgvSlotInformation.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSlotInformation_CellClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "GLSID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 210;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "FROMPORTID";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column4.Width = 91;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "FROMCSTID";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column5.Width = 150;
            // 
            // Column17
            // 
            this.Column17.HeaderText = "FROMSLOTID";
            this.Column17.Name = "Column17";
            this.Column17.ReadOnly = true;
            this.Column17.Width = 85;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "PPID";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "GLSJUDGE";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "GLSSORTTYPE";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "SMPLFLAG";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column6.Width = 85;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "RWKCNT";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column7.Width = 80;
            // 
            // Label7
            // 
            this.Label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label7.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label7.ForeColor = System.Drawing.Color.White;
            this.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label7.Location = new System.Drawing.Point(12, 64);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(1058, 24);
            this.Label7.TabIndex = 43;
            this.Label7.Text = "SLOT INFORMATION";
            this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblQty
            // 
            this.lblQty.BackColor = System.Drawing.Color.White;
            this.lblQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblQty.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblQty.ForeColor = System.Drawing.Color.Black;
            this.lblQty.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblQty.Location = new System.Drawing.Point(1030, 32);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(40, 24);
            this.lblQty.TabIndex = 42;
            this.lblQty.Text = "1";
            this.lblQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label6
            // 
            this.Label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label6.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label6.ForeColor = System.Drawing.Color.White;
            this.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label6.Location = new System.Drawing.Point(990, 32);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(40, 24);
            this.Label6.TabIndex = 41;
            this.Label6.Text = "QTY";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOvenID
            // 
            this.lblOvenID.BackColor = System.Drawing.Color.White;
            this.lblOvenID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOvenID.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblOvenID.ForeColor = System.Drawing.Color.Black;
            this.lblOvenID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblOvenID.Location = new System.Drawing.Point(254, 32);
            this.lblOvenID.Name = "lblOvenID";
            this.lblOvenID.Size = new System.Drawing.Size(128, 24);
            this.lblOvenID.TabIndex = 40;
            this.lblOvenID.Text = "1";
            this.lblOvenID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label4
            // 
            this.Label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label4.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label4.ForeColor = System.Drawing.Color.White;
            this.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label4.Location = new System.Drawing.Point(163, 32);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(91, 24);
            this.Label4.TabIndex = 39;
            this.Label4.Text = "OVENID";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label2.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label2.ForeColor = System.Drawing.Color.White;
            this.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label2.Location = new System.Drawing.Point(8, 32);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(95, 24);
            this.Label2.TabIndex = 37;
            this.Label2.Text = "EQP NO.";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label8
            // 
            this.Label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label8.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label8.ForeColor = System.Drawing.Color.White;
            this.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label8.Location = new System.Drawing.Point(-1, 0);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(1149, 24);
            this.Label8.TabIndex = 34;
            this.Label8.Text = "LOT INFORMATION";
            this.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmOVENInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 419);
            this.ControlBox = false;
            this.Controls.Add(this.Panel4);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmOVENInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormOVENInfo";
            this.Controls.SetChildIndex(this.Panel4, 0);
            this.Controls.SetChildIndex(this.pnlButtonBack, 0);
            this.Panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSlotInformation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel4;
        internal System.Windows.Forms.ComboBox cmbEqpNo;
        internal System.Windows.Forms.Label lblGlsPnlJudge;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.Label lblGlsPnlGrade;
        internal System.Windows.Forms.Label Label12;
        internal System.Windows.Forms.Button btnEditData;
        internal System.Windows.Forms.Label lblLoadTime;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.DataGridView dgvSlotInformation;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label lblQty;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label lblOvenID;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label8;
    }
}