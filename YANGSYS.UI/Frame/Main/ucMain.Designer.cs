namespace YANGSYS.UI.WHTM
{
    partial class ucMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucMain));
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.ucCimStatus1 = new Widgets.ucCimStatus();
            this.ucIndexStatus1 = new Widgets.ucIndexStatus();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ucCurGlassData1 = new YANGSYS.UI.WHTM.ucCurGlassData();
            this.ucEQP1 = new Widgets.ucEQP();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 151F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(999, 1042);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126F));
            this.tableLayoutPanel3.Controls.Add(this.ucCimStatus1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.ucIndexStatus1, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 99F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(151, 1042);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // ucCimStatus1
            // 
            this.ucCimStatus1.Alias = null;
            this.ucCimStatus1.BaseLocation = new System.Drawing.Point(0, 0);
            this.ucCimStatus1.BaseSize = new System.Drawing.Size(60, 60);
            this.ucCimStatus1.ControlLocation = new System.Drawing.Point(3, 3);
            this.ucCimStatus1.ControlName = "ControlName";
            this.ucCimStatus1.ControlSize = new System.Drawing.Size(60, 60);
            this.ucCimStatus1.ElementId = null;
            this.ucCimStatus1.eqpFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ucCimStatus1.eqpLineColor = System.Drawing.Color.Gold;
            this.ucCimStatus1.eqpLineWidth = 7F;
            this.ucCimStatus1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.ucCimStatus1.FrameID = "";
            this.ucCimStatus1.Location = new System.Drawing.Point(3, 3);
            this.ucCimStatus1.ModelType = "NONE";
            this.ucCimStatus1.Name = "ucCimStatus1";
            this.ucCimStatus1.ObjectName = "";
            this.ucCimStatus1.Rotation = SOFD.Component.Interface.enumControlRotation.ROTATION_000;
            this.ucCimStatus1.Size = new System.Drawing.Size(145, 693);
            this.ucCimStatus1.TabIndex = 0;
            // 
            // ucIndexStatus1
            // 
            this.ucIndexStatus1.Alias = null;
            this.ucIndexStatus1.BaseLocation = new System.Drawing.Point(0, 0);
            this.ucIndexStatus1.BaseSize = new System.Drawing.Size(60, 60);
            this.ucIndexStatus1.ControlLocation = new System.Drawing.Point(0, 943);
            this.ucIndexStatus1.ControlName = "ControlName";
            this.ucIndexStatus1.ControlSize = new System.Drawing.Size(60, 60);
            this.ucIndexStatus1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucIndexStatus1.ElementId = null;
            this.ucIndexStatus1.eqpFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ucIndexStatus1.eqpLineColor = System.Drawing.Color.Gold;
            this.ucIndexStatus1.eqpLineWidth = 7F;
            this.ucIndexStatus1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.ucIndexStatus1.FrameID = "";
            this.ucIndexStatus1.Location = new System.Drawing.Point(0, 943);
            this.ucIndexStatus1.Margin = new System.Windows.Forms.Padding(0);
            this.ucIndexStatus1.ModelType = "NONE";
            this.ucIndexStatus1.Name = "ucIndexStatus1";
            this.ucIndexStatus1.ObjectName = "";
            this.ucIndexStatus1.Rotation = SOFD.Component.Interface.enumControlRotation.ROTATION_000;
            this.ucIndexStatus1.Size = new System.Drawing.Size(151, 99);
            this.ucIndexStatus1.TabIndex = 0;
            this.ucIndexStatus1.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ucCurGlassData1);
            this.panel1.Controls.Add(this.ucEQP1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(151, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(848, 1042);
            this.panel1.TabIndex = 5;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // ucCurGlassData1
            // 
            this.ucCurGlassData1.Alias = null;
            this.ucCurGlassData1.BackColor = System.Drawing.Color.Gray;
            this.ucCurGlassData1.BaseLocation = new System.Drawing.Point(0, 0);
            this.ucCurGlassData1.BaseSize = new System.Drawing.Size(60, 60);
            this.ucCurGlassData1.ControlLocation = new System.Drawing.Point(83, 362);
            this.ucCurGlassData1.ControlName = "ControlName";
            this.ucCurGlassData1.ControlSize = new System.Drawing.Size(60, 60);
            this.ucCurGlassData1.ElementId = null;
            this.ucCurGlassData1.eqpFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ucCurGlassData1.eqpLineColor = System.Drawing.Color.Gold;
            this.ucCurGlassData1.eqpLineWidth = 7F;
            this.ucCurGlassData1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.ucCurGlassData1.FrameID = "";
            this.ucCurGlassData1.Location = new System.Drawing.Point(83, 362);
            this.ucCurGlassData1.ModelType = "NONE";
            this.ucCurGlassData1.Name = "ucCurGlassData1";
            this.ucCurGlassData1.ObjectName = "";
            this.ucCurGlassData1.Rotation = SOFD.Component.Interface.enumControlRotation.ROTATION_000;
            this.ucCurGlassData1.Size = new System.Drawing.Size(699, 458);
            this.ucCurGlassData1.TabIndex = 0;
            // 
            // ucEQP1
            // 
            this.ucEQP1.Alias = null;
            this.ucEQP1.BackColor = System.Drawing.SystemColors.Control;
            this.ucEQP1.BaseLocation = new System.Drawing.Point(0, 0);
            this.ucEQP1.BaseSize = new System.Drawing.Size(60, 60);
            this.ucEQP1.ControlLocation = new System.Drawing.Point(160, 10);
            this.ucEQP1.ControlName = "ControlName";
            this.ucEQP1.ControlSize = new System.Drawing.Size(60, 60);
            this.ucEQP1.ElementId = null;
            this.ucEQP1.eqpFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ucEQP1.eqpLineColor = System.Drawing.Color.Gold;
            this.ucEQP1.eqpLineWidth = 7F;
            this.ucEQP1.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.ucEQP1.FrameID = "";
            this.ucEQP1.Location = new System.Drawing.Point(160, 10);
            this.ucEQP1.ModelType = "NONE";
            this.ucEQP1.Name = "ucEQP1";
            this.ucEQP1.ObjectName = "";
            this.ucEQP1.Rotation = SOFD.Component.Interface.enumControlRotation.ROTATION_000;
            this.ucEQP1.Size = new System.Drawing.Size(549, 337);
            this.ucEQP1.TabIndex = 2;
            // 
            // ucMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ucMain";
            this.Size = new System.Drawing.Size(999, 1042);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private Widgets.ucEQP ucEQP1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private ucCurGlassData ucCurGlassData1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private Widgets.ucCimStatus ucCimStatus1;
        private Widgets.ucIndexStatus ucIndexStatus1;
    }
}
