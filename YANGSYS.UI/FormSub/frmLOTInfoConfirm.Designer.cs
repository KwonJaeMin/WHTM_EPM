namespace YANGSYS.UI
{
    partial class frmLOTInfoConfirm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtLot_PPID = new System.Windows.Forms.TextBox();
            this.chkSetToAllGlassID = new System.Windows.Forms.CheckBox();
            this.btnClearAllGlass = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnDeselectAll = new System.Windows.Forms.Button();
            this.btnBuzzerOff = new System.Windows.Forms.Button();
            this.txtLot_CstID = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnLotCancel = new System.Windows.Forms.Button();
            this.btnLotConfirm = new System.Windows.Forms.Button();
            this.btnOffline = new System.Windows.Forms.Button();
            this.txtLotPordID = new System.Windows.Forms.TextBox();
            this.Label14 = new System.Windows.Forms.Label();
            this.txtLot_OperID = new System.Windows.Forms.TextBox();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Label13 = new System.Windows.Forms.Label();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtLotSortType = new System.Windows.Forms.TextBox();
            this.Label12 = new System.Windows.Forms.Label();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtLotJudge = new System.Windows.Forms.TextBox();
            this.Label11 = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txtLotID = new System.Windows.Forms.TextBox();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Label10 = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSlotInformation = new System.Windows.Forms.DataGridView();
            this.lblLot_Qty = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.lblLot_PSNo = new System.Windows.Forms.Label();
            this.lblLot_PortID = new System.Windows.Forms.Label();
            this.Label15 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSlotInformation)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlButtonBack
            // 
            this.pnlButtonBack.Location = new System.Drawing.Point(0, 642);
            this.pnlButtonBack.Size = new System.Drawing.Size(1099, 39);
            // 
            // txtLot_PPID
            // 
            this.txtLot_PPID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLot_PPID.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtLot_PPID.Location = new System.Drawing.Point(77, 71);
            this.txtLot_PPID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLot_PPID.MaxLength = 20;
            this.txtLot_PPID.Name = "txtLot_PPID";
            this.txtLot_PPID.Size = new System.Drawing.Size(145, 23);
            this.txtLot_PPID.TabIndex = 147;
            this.txtLot_PPID.Text = "AAAAAAAAAAAAAAAAAAAA";
            this.txtLot_PPID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkSetToAllGlassID
            // 
            this.chkSetToAllGlassID.AutoSize = true;
            this.chkSetToAllGlassID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkSetToAllGlassID.ForeColor = System.Drawing.Color.Yellow;
            this.chkSetToAllGlassID.Location = new System.Drawing.Point(97, 111);
            this.chkSetToAllGlassID.Name = "chkSetToAllGlassID";
            this.chkSetToAllGlassID.Size = new System.Drawing.Size(134, 16);
            this.chkSetToAllGlassID.TabIndex = 146;
            this.chkSetToAllGlassID.Text = "SET TO ALL GLSID";
            this.chkSetToAllGlassID.UseVisualStyleBackColor = false;
            // 
            // btnClearAllGlass
            // 
            this.btnClearAllGlass.BackColor = System.Drawing.Color.Gray;
            this.btnClearAllGlass.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClearAllGlass.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClearAllGlass.Location = new System.Drawing.Point(9, 630);
            this.btnClearAllGlass.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnClearAllGlass.Name = "btnClearAllGlass";
            this.btnClearAllGlass.Size = new System.Drawing.Size(144, 40);
            this.btnClearAllGlass.TabIndex = 145;
            this.btnClearAllGlass.Text = "CLEAR ALL GLSID";
            this.btnClearAllGlass.UseVisualStyleBackColor = false;
            this.btnClearAllGlass.Click += new System.EventHandler(this.btnClearAllGlass_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.BackColor = System.Drawing.Color.Gray;
            this.btnSelectAll.Enabled = false;
            this.btnSelectAll.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSelectAll.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSelectAll.Location = new System.Drawing.Point(873, 43);
            this.btnSelectAll.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(104, 48);
            this.btnSelectAll.TabIndex = 144;
            this.btnSelectAll.Text = "SELECT ALL";
            this.btnSelectAll.UseVisualStyleBackColor = false;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnDeselectAll
            // 
            this.btnDeselectAll.BackColor = System.Drawing.Color.Gray;
            this.btnDeselectAll.Enabled = false;
            this.btnDeselectAll.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDeselectAll.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDeselectAll.Location = new System.Drawing.Point(977, 43);
            this.btnDeselectAll.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnDeselectAll.Name = "btnDeselectAll";
            this.btnDeselectAll.Size = new System.Drawing.Size(112, 48);
            this.btnDeselectAll.TabIndex = 143;
            this.btnDeselectAll.Text = "DESELECT ALL";
            this.btnDeselectAll.UseVisualStyleBackColor = false;
            this.btnDeselectAll.Click += new System.EventHandler(this.btnDeselectAll_Click);
            // 
            // btnBuzzerOff
            // 
            this.btnBuzzerOff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnBuzzerOff.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnBuzzerOff.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBuzzerOff.Location = new System.Drawing.Point(201, 630);
            this.btnBuzzerOff.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnBuzzerOff.Name = "btnBuzzerOff";
            this.btnBuzzerOff.Size = new System.Drawing.Size(144, 40);
            this.btnBuzzerOff.TabIndex = 142;
            this.btnBuzzerOff.Text = "BUZZER OFF";
            this.btnBuzzerOff.UseVisualStyleBackColor = false;
            this.btnBuzzerOff.Click += new System.EventHandler(this.btnBuzzerOff_Click);
            // 
            // txtLot_CstID
            // 
            this.txtLot_CstID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLot_CstID.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtLot_CstID.Location = new System.Drawing.Point(534, 43);
            this.txtLot_CstID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLot_CstID.MaxLength = 20;
            this.txtLot_CstID.Name = "txtLot_CstID";
            this.txtLot_CstID.Size = new System.Drawing.Size(128, 23);
            this.txtLot_CstID.TabIndex = 141;
            this.txtLot_CstID.Text = "AAAAAAAA";
            this.txtLot_CstID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnClose.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(945, 630);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(144, 40);
            this.btnClose.TabIndex = 140;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnLotCancel
            // 
            this.btnLotCancel.BackColor = System.Drawing.Color.Yellow;
            this.btnLotCancel.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLotCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnLotCancel.Location = new System.Drawing.Point(577, 630);
            this.btnLotCancel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnLotCancel.Name = "btnLotCancel";
            this.btnLotCancel.Size = new System.Drawing.Size(144, 40);
            this.btnLotCancel.TabIndex = 139;
            this.btnLotCancel.Text = "LOT CANCEL";
            this.btnLotCancel.UseVisualStyleBackColor = false;
            this.btnLotCancel.Click += new System.EventHandler(this.btnLotCancel_Click);
            // 
            // btnLotConfirm
            // 
            this.btnLotConfirm.BackColor = System.Drawing.Color.Lime;
            this.btnLotConfirm.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLotConfirm.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnLotConfirm.Location = new System.Drawing.Point(761, 630);
            this.btnLotConfirm.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnLotConfirm.Name = "btnLotConfirm";
            this.btnLotConfirm.Size = new System.Drawing.Size(144, 40);
            this.btnLotConfirm.TabIndex = 138;
            this.btnLotConfirm.Text = "LOT CONFIRM";
            this.btnLotConfirm.UseVisualStyleBackColor = false;
            this.btnLotConfirm.Click += new System.EventHandler(this.btnLotConfirm_Click);
            // 
            // btnOffline
            // 
            this.btnOffline.BackColor = System.Drawing.Color.White;
            this.btnOffline.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOffline.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOffline.Location = new System.Drawing.Point(393, 630);
            this.btnOffline.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnOffline.Name = "btnOffline";
            this.btnOffline.Size = new System.Drawing.Size(144, 40);
            this.btnOffline.TabIndex = 137;
            this.btnOffline.Text = "OFF-LINE";
            this.btnOffline.UseVisualStyleBackColor = false;
            this.btnOffline.Click += new System.EventHandler(this.btnOffline_Click);
            // 
            // txtLotPordID
            // 
            this.txtLotPordID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLotPordID.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtLotPordID.Location = new System.Drawing.Point(534, 71);
            this.txtLotPordID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLotPordID.MaxLength = 20;
            this.txtLotPordID.Name = "txtLotPordID";
            this.txtLotPordID.Size = new System.Drawing.Size(128, 23);
            this.txtLotPordID.TabIndex = 136;
            this.txtLotPordID.Text = "AA";
            this.txtLotPordID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label14
            // 
            this.Label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label14.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label14.ForeColor = System.Drawing.Color.White;
            this.Label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label14.Location = new System.Drawing.Point(472, 71);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(61, 24);
            this.Label14.TabIndex = 135;
            this.Label14.Text = "PRODID";
            this.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtLot_OperID
            // 
            this.txtLot_OperID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLot_OperID.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtLot_OperID.Location = new System.Drawing.Point(299, 71);
            this.txtLot_OperID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLot_OperID.MaxLength = 20;
            this.txtLot_OperID.Name = "txtLot_OperID";
            this.txtLot_OperID.Size = new System.Drawing.Size(167, 23);
            this.txtLot_OperID.TabIndex = 134;
            this.txtLot_OperID.Text = "AAAAAAAAAAAAAAAAAAAA";
            this.txtLot_OperID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "RWKCNT";
            this.Column6.Name = "Column6";
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column6.Width = 70;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "GLSTYPE";
            this.Column7.Name = "Column7";
            this.Column7.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column7.Width = 70;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "SMPLFLAG";
            this.Column5.Name = "Column5";
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column5.Width = 80;
            // 
            // Label13
            // 
            this.Label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label13.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label13.ForeColor = System.Drawing.Color.White;
            this.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label13.Location = new System.Drawing.Point(235, 71);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(64, 24);
            this.Label13.TabIndex = 133;
            this.Label13.Text = "OPERID";
            this.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "GLSSORTTYPE";
            this.Column4.Name = "Column4";
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "CFGLSID";
            this.Column8.Name = "Column8";
            this.Column8.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column8.Width = 170;
            // 
            // txtLotSortType
            // 
            this.txtLotSortType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLotSortType.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtLotSortType.Location = new System.Drawing.Point(772, 71);
            this.txtLotSortType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLotSortType.MaxLength = 2;
            this.txtLotSortType.Name = "txtLotSortType";
            this.txtLotSortType.Size = new System.Drawing.Size(32, 23);
            this.txtLotSortType.TabIndex = 132;
            this.txtLotSortType.Text = "AA";
            this.txtLotSortType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label12
            // 
            this.Label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label12.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label12.ForeColor = System.Drawing.Color.White;
            this.Label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label12.Location = new System.Drawing.Point(668, 71);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(104, 24);
            this.Label12.TabIndex = 131;
            this.Label12.Text = "LOTSORTTYPE";
            this.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "GLSJUDGE";
            this.Column3.Name = "Column3";
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 80;
            // 
            // txtLotJudge
            // 
            this.txtLotJudge.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLotJudge.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtLotJudge.Location = new System.Drawing.Point(748, 43);
            this.txtLotJudge.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLotJudge.MaxLength = 1;
            this.txtLotJudge.Name = "txtLotJudge";
            this.txtLotJudge.Size = new System.Drawing.Size(32, 23);
            this.txtLotJudge.TabIndex = 130;
            this.txtLotJudge.Text = "A";
            this.txtLotJudge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label11
            // 
            this.Label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label11.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label11.ForeColor = System.Drawing.Color.White;
            this.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label11.Location = new System.Drawing.Point(668, 43);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(80, 24);
            this.Label11.TabIndex = 129;
            this.Label11.Text = "LOTJUDGE";
            this.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "EXIST";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.Width = 60;
            // 
            // txtLotID
            // 
            this.txtLotID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLotID.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtLotID.Location = new System.Drawing.Point(299, 43);
            this.txtLotID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLotID.MaxLength = 20;
            this.txtLotID.Name = "txtLotID";
            this.txtLotID.Size = new System.Drawing.Size(167, 23);
            this.txtLotID.TabIndex = 128;
            this.txtLotID.Text = "AAAAAAAAAAAAAAAAAAAA";
            this.txtLotID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "GLSID";
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 170;
            // 
            // Label10
            // 
            this.Label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label10.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label10.ForeColor = System.Drawing.Color.White;
            this.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label10.Location = new System.Drawing.Point(235, 43);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(64, 24);
            this.Label10.TabIndex = 127;
            this.Label10.Text = "LOTID";
            this.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label9
            // 
            this.Label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label9.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label9.ForeColor = System.Drawing.Color.White;
            this.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label9.Location = new System.Drawing.Point(13, 71);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(64, 24);
            this.Label9.TabIndex = 126;
            this.Label9.Text = "PPID";
            this.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label7
            // 
            this.Label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label7.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label7.ForeColor = System.Drawing.Color.White;
            this.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label7.Location = new System.Drawing.Point(1, 108);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(1096, 24);
            this.Label7.TabIndex = 125;
            this.Label7.Text = "SLOT INFORMATION";
            this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "GLSPNLJUDGE";
            this.Column9.Name = "Column9";
            this.Column9.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column9.Width = 245;
            // 
            // dgvSlotInformation
            // 
            this.dgvSlotInformation.AllowUserToAddRows = false;
            this.dgvSlotInformation.AllowUserToDeleteRows = false;
            this.dgvSlotInformation.AllowUserToResizeColumns = false;
            this.dgvSlotInformation.AllowUserToResizeRows = false;
            this.dgvSlotInformation.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvSlotInformation.ColumnHeadersHeight = 20;
            this.dgvSlotInformation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSlotInformation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9});
            this.dgvSlotInformation.Location = new System.Drawing.Point(1, 132);
            this.dgvSlotInformation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvSlotInformation.MultiSelect = false;
            this.dgvSlotInformation.Name = "dgvSlotInformation";
            this.dgvSlotInformation.RowHeadersWidth = 30;
            this.dgvSlotInformation.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dgvSlotInformation.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSlotInformation.RowTemplate.Height = 23;
            this.dgvSlotInformation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvSlotInformation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvSlotInformation.Size = new System.Drawing.Size(1096, 480);
            this.dgvSlotInformation.TabIndex = 124;
            // 
            // lblLot_Qty
            // 
            this.lblLot_Qty.BackColor = System.Drawing.Color.White;
            this.lblLot_Qty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLot_Qty.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblLot_Qty.ForeColor = System.Drawing.Color.Black;
            this.lblLot_Qty.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblLot_Qty.Location = new System.Drawing.Point(817, 67);
            this.lblLot_Qty.Name = "lblLot_Qty";
            this.lblLot_Qty.Size = new System.Drawing.Size(40, 24);
            this.lblLot_Qty.TabIndex = 123;
            this.lblLot_Qty.Text = "1";
            this.lblLot_Qty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label6
            // 
            this.Label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label6.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label6.ForeColor = System.Drawing.Color.White;
            this.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label6.Location = new System.Drawing.Point(817, 43);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(40, 24);
            this.Label6.TabIndex = 122;
            this.Label6.Text = "QTY";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label4
            // 
            this.Label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label4.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label4.ForeColor = System.Drawing.Color.White;
            this.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label4.Location = new System.Drawing.Point(472, 43);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(61, 24);
            this.Label4.TabIndex = 121;
            this.Label4.Text = "CSTID";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLot_PSNo
            // 
            this.lblLot_PSNo.BackColor = System.Drawing.Color.White;
            this.lblLot_PSNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLot_PSNo.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblLot_PSNo.ForeColor = System.Drawing.Color.Black;
            this.lblLot_PSNo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblLot_PSNo.Location = new System.Drawing.Point(77, 43);
            this.lblLot_PSNo.Name = "lblLot_PSNo";
            this.lblLot_PSNo.Size = new System.Drawing.Size(40, 24);
            this.lblLot_PSNo.TabIndex = 119;
            this.lblLot_PSNo.Text = "1";
            this.lblLot_PSNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLot_PortID
            // 
            this.lblLot_PortID.BackColor = System.Drawing.Color.White;
            this.lblLot_PortID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLot_PortID.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblLot_PortID.ForeColor = System.Drawing.Color.Black;
            this.lblLot_PortID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblLot_PortID.Location = new System.Drawing.Point(181, 43);
            this.lblLot_PortID.Name = "lblLot_PortID";
            this.lblLot_PortID.Size = new System.Drawing.Size(40, 24);
            this.lblLot_PortID.TabIndex = 120;
            this.lblLot_PortID.Text = "1";
            this.lblLot_PortID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label15
            // 
            this.Label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label15.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label15.ForeColor = System.Drawing.Color.White;
            this.Label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label15.Location = new System.Drawing.Point(13, 43);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(64, 24);
            this.Label15.TabIndex = 117;
            this.Label15.Text = "PS NO";
            this.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label2.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label2.ForeColor = System.Drawing.Color.White;
            this.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label2.Location = new System.Drawing.Point(117, 43);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(64, 24);
            this.Label2.TabIndex = 118;
            this.Label2.Text = "PORTID";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label8
            // 
            this.Label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label8.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.Label8.ForeColor = System.Drawing.Color.White;
            this.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label8.Location = new System.Drawing.Point(1, 3);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(1096, 30);
            this.Label8.TabIndex = 116;
            this.Label8.Text = "LOT INFORMATION";
            this.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmLOTInfoConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 681);
            this.ControlBox = false;
            this.Controls.Add(this.txtLot_PPID);
            this.Controls.Add(this.chkSetToAllGlassID);
            this.Controls.Add(this.btnClearAllGlass);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.btnDeselectAll);
            this.Controls.Add(this.btnBuzzerOff);
            this.Controls.Add(this.txtLot_CstID);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnLotCancel);
            this.Controls.Add(this.btnLotConfirm);
            this.Controls.Add(this.btnOffline);
            this.Controls.Add(this.txtLotPordID);
            this.Controls.Add(this.Label14);
            this.Controls.Add(this.txtLot_OperID);
            this.Controls.Add(this.Label13);
            this.Controls.Add(this.txtLotSortType);
            this.Controls.Add(this.Label12);
            this.Controls.Add(this.txtLotJudge);
            this.Controls.Add(this.Label11);
            this.Controls.Add(this.txtLotID);
            this.Controls.Add(this.Label10);
            this.Controls.Add(this.Label9);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.dgvSlotInformation);
            this.Controls.Add(this.lblLot_Qty);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.lblLot_PSNo);
            this.Controls.Add(this.lblLot_PortID);
            this.Controls.Add(this.Label15);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label8);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "frmLOTInfoConfirm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormLOTInfoConfirm";
            this.Load += new System.EventHandler(this.frmLOTInfoConfirm_Load);
            this.Controls.SetChildIndex(this.Label8, 0);
            this.Controls.SetChildIndex(this.Label2, 0);
            this.Controls.SetChildIndex(this.Label15, 0);
            this.Controls.SetChildIndex(this.lblLot_PortID, 0);
            this.Controls.SetChildIndex(this.lblLot_PSNo, 0);
            this.Controls.SetChildIndex(this.Label4, 0);
            this.Controls.SetChildIndex(this.Label6, 0);
            this.Controls.SetChildIndex(this.lblLot_Qty, 0);
            this.Controls.SetChildIndex(this.dgvSlotInformation, 0);
            this.Controls.SetChildIndex(this.Label7, 0);
            this.Controls.SetChildIndex(this.Label9, 0);
            this.Controls.SetChildIndex(this.Label10, 0);
            this.Controls.SetChildIndex(this.txtLotID, 0);
            this.Controls.SetChildIndex(this.Label11, 0);
            this.Controls.SetChildIndex(this.txtLotJudge, 0);
            this.Controls.SetChildIndex(this.Label12, 0);
            this.Controls.SetChildIndex(this.txtLotSortType, 0);
            this.Controls.SetChildIndex(this.Label13, 0);
            this.Controls.SetChildIndex(this.txtLot_OperID, 0);
            this.Controls.SetChildIndex(this.Label14, 0);
            this.Controls.SetChildIndex(this.txtLotPordID, 0);
            this.Controls.SetChildIndex(this.btnOffline, 0);
            this.Controls.SetChildIndex(this.btnLotConfirm, 0);
            this.Controls.SetChildIndex(this.btnLotCancel, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.txtLot_CstID, 0);
            this.Controls.SetChildIndex(this.btnBuzzerOff, 0);
            this.Controls.SetChildIndex(this.btnDeselectAll, 0);
            this.Controls.SetChildIndex(this.btnSelectAll, 0);
            this.Controls.SetChildIndex(this.btnClearAllGlass, 0);
            this.Controls.SetChildIndex(this.chkSetToAllGlassID, 0);
            this.Controls.SetChildIndex(this.txtLot_PPID, 0);
            this.Controls.SetChildIndex(this.pnlButtonBack, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSlotInformation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtLot_PPID;
        internal System.Windows.Forms.CheckBox chkSetToAllGlassID;
        internal System.Windows.Forms.Button btnClearAllGlass;
        internal System.Windows.Forms.Button btnSelectAll;
        internal System.Windows.Forms.Button btnDeselectAll;
        internal System.Windows.Forms.Button btnBuzzerOff;
        internal System.Windows.Forms.TextBox txtLot_CstID;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Button btnLotCancel;
        internal System.Windows.Forms.Button btnLotConfirm;
        internal System.Windows.Forms.Button btnOffline;
        internal System.Windows.Forms.TextBox txtLotPordID;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.TextBox txtLot_OperID;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        internal System.Windows.Forms.DataGridViewCheckBoxColumn Column5;
        internal System.Windows.Forms.Label Label13;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        internal System.Windows.Forms.TextBox txtLotSortType;
        internal System.Windows.Forms.Label Label12;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        internal System.Windows.Forms.TextBox txtLotJudge;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        internal System.Windows.Forms.TextBox txtLotID;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        internal System.Windows.Forms.DataGridView dgvSlotInformation;
        internal System.Windows.Forms.Label lblLot_Qty;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label lblLot_PSNo;
        internal System.Windows.Forms.Label lblLot_PortID;
        internal System.Windows.Forms.Label Label15;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label8;
    }
}