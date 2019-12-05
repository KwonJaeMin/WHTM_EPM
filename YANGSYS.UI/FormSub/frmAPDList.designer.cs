namespace MainProgram
{
    partial class frmAPDList
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
            this.dgvAPDList = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnUnitC = new System.Windows.Forms.Button();
            this.btnUnitB = new System.Windows.Forms.Button();
            this.btnUnitA = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAPDList)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlButtonBack
            // 
            this.pnlButtonBack.Location = new System.Drawing.Point(0, 611);
            this.pnlButtonBack.Size = new System.Drawing.Size(835, 39);
            // 
            // dgvAPDList
            // 
            this.dgvAPDList.AllowUserToAddRows = false;
            this.dgvAPDList.AllowUserToDeleteRows = false;
            this.dgvAPDList.AllowUserToResizeColumns = false;
            this.dgvAPDList.AllowUserToResizeRows = false;
            this.dgvAPDList.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvAPDList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvAPDList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column6});
            this.dgvAPDList.Location = new System.Drawing.Point(0, 87);
            this.dgvAPDList.MultiSelect = false;
            this.dgvAPDList.Name = "dgvAPDList";
            this.dgvAPDList.ReadOnly = true;
            this.dgvAPDList.RowHeadersWidth = 30;
            this.dgvAPDList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvAPDList.RowTemplate.Height = 23;
            this.dgvAPDList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvAPDList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAPDList.Size = new System.Drawing.Size(832, 559);
            this.dgvAPDList.TabIndex = 106;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "EMSID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 190;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "ADDRESS";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 70;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "FORMAT";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "DESCRIPTION";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column6.Width = 423;
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(0, 4);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(832, 32);
            this.Label1.TabIndex = 105;
            this.Label1.Text = "APD LIST INFORMATION";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnUnitC
            // 
            this.btnUnitC.BackColor = System.Drawing.Color.Transparent;
            this.btnUnitC.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnUnitC.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnUnitC.Location = new System.Drawing.Point(434, 35);
            this.btnUnitC.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUnitC.Name = "btnUnitC";
            this.btnUnitC.Size = new System.Drawing.Size(208, 50);
            this.btnUnitC.TabIndex = 115;
            this.btnUnitC.Text = "Colling";
            this.btnUnitC.UseVisualStyleBackColor = false;
            this.btnUnitC.Click += new System.EventHandler(this.bunUnitC_Click);
            // 
            // btnUnitB
            // 
            this.btnUnitB.BackColor = System.Drawing.Color.Transparent;
            this.btnUnitB.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnUnitB.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnUnitB.Location = new System.Drawing.Point(227, 35);
            this.btnUnitB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUnitB.Name = "btnUnitB";
            this.btnUnitB.Size = new System.Drawing.Size(208, 50);
            this.btnUnitB.TabIndex = 114;
            this.btnUnitB.Text = "OVENB";
            this.btnUnitB.UseVisualStyleBackColor = false;
            this.btnUnitB.Click += new System.EventHandler(this.btnUnitB_Click);
            // 
            // btnUnitA
            // 
            this.btnUnitA.BackColor = System.Drawing.Color.Transparent;
            this.btnUnitA.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnUnitA.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnUnitA.Location = new System.Drawing.Point(-1, 35);
            this.btnUnitA.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUnitA.Name = "btnUnitA";
            this.btnUnitA.Size = new System.Drawing.Size(229, 50);
            this.btnUnitA.TabIndex = 113;
            this.btnUnitA.Text = "OVENA";
            this.btnUnitA.UseVisualStyleBackColor = false;
            this.btnUnitA.Click += new System.EventHandler(this.btnUnitA_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(641, 35);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(190, 50);
            this.btnClose.TabIndex = 112;
            this.btnClose.Text = "닫기";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmAPDList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 650);
            this.Controls.Add(this.btnUnitC);
            this.Controls.Add(this.btnUnitB);
            this.Controls.Add(this.btnUnitA);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvAPDList);
            this.Controls.Add(this.Label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAPDList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "APD List";
            this.Controls.SetChildIndex(this.Label1, 0);
            this.Controls.SetChildIndex(this.dgvAPDList, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.btnUnitA, 0);
            this.Controls.SetChildIndex(this.btnUnitB, 0);
            this.Controls.SetChildIndex(this.btnUnitC, 0);
            this.Controls.SetChildIndex(this.pnlButtonBack, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAPDList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridView dgvAPDList;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button btnUnitC;
        internal System.Windows.Forms.Button btnUnitB;
        internal System.Windows.Forms.Button btnUnitA;
        internal System.Windows.Forms.Button btnClose;


    }
}