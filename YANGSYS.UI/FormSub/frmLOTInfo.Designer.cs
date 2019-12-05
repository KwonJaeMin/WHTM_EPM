namespace YANGSYS.UI
{
    partial class frmLOTInfo
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
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSlotInformation = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblQty = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.lblCSTID = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.lblProdID = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.lblGlsPnlJudge = new System.Windows.Forms.Label();
            this.Label14 = new System.Windows.Forms.Label();
            this.lblGlsPnlGrade = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.btnEditData = new System.Windows.Forms.Button();
            this.lblLoadTime = new System.Windows.Forms.Label();
            this.Label11 = new System.Windows.Forms.Label();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.Label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSlotInformation)).BeginInit();
            this.Panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlButtonBack
            // 
            this.pnlButtonBack.Location = new System.Drawing.Point(0, 412);
            this.pnlButtonBack.Size = new System.Drawing.Size(1083, 10);
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
            this.Column8.HeaderText = "GLSTYPE";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column8.Width = 80;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "FROMCSTID";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column5.Width = 130;
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
            this.Column2,
            this.Column3,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column4,
            this.Column5,
            this.Column17});
            this.dgvSlotInformation.Location = new System.Drawing.Point(14, 88);
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
            this.Column1.Width = 190;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "GLSJUDGE";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 70;
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
            // Column4
            // 
            this.Column4.HeaderText = "FROMPORTID";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column4.Width = 91;
            // 
            // lblQty
            // 
            this.lblQty.BackColor = System.Drawing.Color.White;
            this.lblQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblQty.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblQty.ForeColor = System.Drawing.Color.Black;
            this.lblQty.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblQty.Location = new System.Drawing.Point(1032, 32);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(40, 24);
            this.lblQty.TabIndex = 42;
            this.lblQty.Text = "1";
            this.lblQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label7
            // 
            this.Label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label7.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label7.ForeColor = System.Drawing.Color.White;
            this.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label7.Location = new System.Drawing.Point(14, 64);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(1058, 24);
            this.Label7.TabIndex = 43;
            this.Label7.Text = "SLOT INFORMATION";
            this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label6
            // 
            this.Label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label6.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label6.ForeColor = System.Drawing.Color.White;
            this.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label6.Location = new System.Drawing.Point(992, 32);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(40, 24);
            this.Label6.TabIndex = 41;
            this.Label6.Text = "QTY";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCSTID
            // 
            this.lblCSTID.BackColor = System.Drawing.Color.White;
            this.lblCSTID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCSTID.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblCSTID.ForeColor = System.Drawing.Color.Black;
            this.lblCSTID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCSTID.Location = new System.Drawing.Point(202, 32);
            this.lblCSTID.Name = "lblCSTID";
            this.lblCSTID.Size = new System.Drawing.Size(128, 24);
            this.lblCSTID.TabIndex = 40;
            this.lblCSTID.Text = "1";
            this.lblCSTID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label4
            // 
            this.Label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label4.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label4.ForeColor = System.Drawing.Color.White;
            this.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label4.Location = new System.Drawing.Point(130, 32);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(72, 24);
            this.Label4.TabIndex = 39;
            this.Label4.Text = "CSTID";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProdID
            // 
            this.lblProdID.BackColor = System.Drawing.Color.White;
            this.lblProdID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblProdID.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblProdID.ForeColor = System.Drawing.Color.Black;
            this.lblProdID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblProdID.Location = new System.Drawing.Point(82, 32);
            this.lblProdID.Name = "lblProdID";
            this.lblProdID.Size = new System.Drawing.Size(40, 24);
            this.lblProdID.TabIndex = 38;
            this.lblProdID.Text = "1";
            this.lblProdID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label2.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label2.ForeColor = System.Drawing.Color.White;
            this.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label2.Location = new System.Drawing.Point(10, 32);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(72, 24);
            this.Label2.TabIndex = 37;
            this.Label2.Text = "PORTID";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGlsPnlJudge
            // 
            this.lblGlsPnlJudge.BackColor = System.Drawing.Color.White;
            this.lblGlsPnlJudge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblGlsPnlJudge.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblGlsPnlJudge.ForeColor = System.Drawing.Color.Black;
            this.lblGlsPnlJudge.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblGlsPnlJudge.Location = new System.Drawing.Point(126, 360);
            this.lblGlsPnlJudge.Name = "lblGlsPnlJudge";
            this.lblGlsPnlJudge.Size = new System.Drawing.Size(777, 24);
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
            this.Label14.Location = new System.Drawing.Point(14, 360);
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
            this.lblGlsPnlGrade.Location = new System.Drawing.Point(126, 384);
            this.lblGlsPnlGrade.Name = "lblGlsPnlGrade";
            this.lblGlsPnlGrade.Size = new System.Drawing.Size(777, 24);
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
            this.Label12.Location = new System.Drawing.Point(14, 384);
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
            this.btnEditData.Location = new System.Drawing.Point(904, 360);
            this.btnEditData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEditData.Name = "btnEditData";
            this.btnEditData.Size = new System.Drawing.Size(168, 48);
            this.btnEditData.TabIndex = 49;
            this.btnEditData.Text = "EDIT DATA";
            this.btnEditData.UseVisualStyleBackColor = false;
            // 
            // lblLoadTime
            // 
            this.lblLoadTime.BackColor = System.Drawing.Color.White;
            this.lblLoadTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLoadTime.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblLoadTime.ForeColor = System.Drawing.Color.Black;
            this.lblLoadTime.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblLoadTime.Location = new System.Drawing.Point(792, 32);
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
            this.Label11.Location = new System.Drawing.Point(696, 32);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(96, 24);
            this.Label11.TabIndex = 47;
            this.Label11.Text = "LOAD TIME";
            this.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Panel4
            // 
            this.Panel4.BackColor = System.Drawing.SystemColors.Control;
            this.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            this.Panel4.Controls.Add(this.lblCSTID);
            this.Panel4.Controls.Add(this.Label4);
            this.Panel4.Controls.Add(this.lblProdID);
            this.Panel4.Controls.Add(this.Label2);
            this.Panel4.Controls.Add(this.Label8);
            this.Panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel4.Location = new System.Drawing.Point(0, 0);
            this.Panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Panel4.Name = "Panel4";
            this.Panel4.Size = new System.Drawing.Size(1083, 422);
            this.Panel4.TabIndex = 23;
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
            // frmLOTInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 422);
            this.Controls.Add(this.Panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "frmLOTInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormLOTInfo";
            this.Controls.SetChildIndex(this.Panel4, 0);
            this.Controls.SetChildIndex(this.pnlButtonBack, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSlotInformation)).EndInit();
            this.Panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        internal System.Windows.Forms.DataGridView dgvSlotInformation;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        internal System.Windows.Forms.Label lblQty;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label lblCSTID;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label lblProdID;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label lblGlsPnlJudge;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.Label lblGlsPnlGrade;
        internal System.Windows.Forms.Label Label12;
        internal System.Windows.Forms.Button btnEditData;
        internal System.Windows.Forms.Label lblLoadTime;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.Panel Panel4;
        internal System.Windows.Forms.Label Label8;
    }
}