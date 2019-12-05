namespace SmartPLCSimulator
{
    partial class FormMain
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.programeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.PortStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.IP = new System.Windows.Forms.ToolStripStatusLabel();
            this.PortNumber = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblObjectUri = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelDevice = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelDataType = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tmrStatusRefresh = new System.Windows.Forms.Timer(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbHEX = new System.Windows.Forms.Label();
            this.lbDEC = new System.Windows.Forms.Label();
            this.lbBIN = new System.Windows.Forms.Label();
            this.btnDeviceSetting = new System.Windows.Forms.Button();
            this.btnScenarioMode = new System.Windows.Forms.Button();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chkExchange = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label80 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label78 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label79 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblStageExchangePossible = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label76 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.label74 = new System.Windows.Forms.Label();
            this.textBox97 = new System.Windows.Forms.TextBox();
            this.textBox96 = new System.Windows.Forms.TextBox();
            this.textBox95 = new System.Windows.Forms.TextBox();
            this.textBox94 = new System.Windows.Forms.TextBox();
            this.textBox93 = new System.Windows.Forms.TextBox();
            this.textBox92 = new System.Windows.Forms.TextBox();
            this.textBox88 = new System.Windows.Forms.TextBox();
            this.textBox86 = new System.Windows.Forms.TextBox();
            this.textBox91 = new System.Windows.Forms.TextBox();
            this.textBox90 = new System.Windows.Forms.TextBox();
            this.textBox89 = new System.Windows.Forms.TextBox();
            this.textBox87 = new System.Windows.Forms.TextBox();
            this.textBox85 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblRobotSendAble = new System.Windows.Forms.Label();
            this.lblRobotUpstreamTrouble = new System.Windows.Forms.Label();
            this.lblRobotUpstreamInline = new System.Windows.Forms.Label();
            this.lblRobotSendStart = new System.Windows.Forms.Label();
            this.lblRootSendComplete = new System.Windows.Forms.Label();
            this.lblRobotSendJobTransSignal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblBCSentOutJobReply = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.label68 = new System.Windows.Forms.Label();
            this.label75 = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button14 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.btnGlassLoading = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabALL = new System.Windows.Forms.TabPage();
            this.txtScannerLog = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnErrorStop = new System.Windows.Forms.Button();
            this.btnAllEMPStop = new System.Windows.Forms.Button();
            this.btnAllScemarioStart = new System.Windows.Forms.Button();
            this.btnStartEMSScenario = new System.Windows.Forms.Button();
            this.chkLogging = new System.Windows.Forms.CheckBox();
            this.tabSIMControl = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.textBox68 = new System.Windows.Forms.TextBox();
            this.textBox48 = new System.Windows.Forms.TextBox();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.textBox84 = new System.Windows.Forms.TextBox();
            this.textBox76 = new System.Windows.Forms.TextBox();
            this.textBox23 = new System.Windows.Forms.TextBox();
            this.textBox83 = new System.Windows.Forms.TextBox();
            this.textBox75 = new System.Windows.Forms.TextBox();
            this.textBox26 = new System.Windows.Forms.TextBox();
            this.textBox82 = new System.Windows.Forms.TextBox();
            this.textBox74 = new System.Windows.Forms.TextBox();
            this.textBox25 = new System.Windows.Forms.TextBox();
            this.textBox81 = new System.Windows.Forms.TextBox();
            this.textBox73 = new System.Windows.Forms.TextBox();
            this.textBox24 = new System.Windows.Forms.TextBox();
            this.textBox80 = new System.Windows.Forms.TextBox();
            this.textBox72 = new System.Windows.Forms.TextBox();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.textBox79 = new System.Windows.Forms.TextBox();
            this.textBox71 = new System.Windows.Forms.TextBox();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.textBox78 = new System.Windows.Forms.TextBox();
            this.textBox70 = new System.Windows.Forms.TextBox();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.textBox77 = new System.Windows.Forms.TextBox();
            this.textBox69 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox66 = new System.Windows.Forms.TextBox();
            this.textBox46 = new System.Windows.Forms.TextBox();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.textBox65 = new System.Windows.Forms.TextBox();
            this.textBox45 = new System.Windows.Forms.TextBox();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.textBox64 = new System.Windows.Forms.TextBox();
            this.textBox44 = new System.Windows.Forms.TextBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.textBox63 = new System.Windows.Forms.TextBox();
            this.textBox43 = new System.Windows.Forms.TextBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.textBox62 = new System.Windows.Forms.TextBox();
            this.textBox42 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.textBox61 = new System.Windows.Forms.TextBox();
            this.textBox41 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox60 = new System.Windows.Forms.TextBox();
            this.textBox40 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox59 = new System.Windows.Forms.TextBox();
            this.textBox39 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox58 = new System.Windows.Forms.TextBox();
            this.textBox38 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox57 = new System.Windows.Forms.TextBox();
            this.textBox37 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox56 = new System.Windows.Forms.TextBox();
            this.textBox36 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox55 = new System.Windows.Forms.TextBox();
            this.textBox35 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox54 = new System.Windows.Forms.TextBox();
            this.textBox34 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox53 = new System.Windows.Forms.TextBox();
            this.textBox33 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox52 = new System.Windows.Forms.TextBox();
            this.textBox51 = new System.Windows.Forms.TextBox();
            this.textBox32 = new System.Windows.Forms.TextBox();
            this.textBox31 = new System.Windows.Forms.TextBox();
            this.textBox50 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox30 = new System.Windows.Forms.TextBox();
            this.textBox49 = new System.Windows.Forms.TextBox();
            this.textBox28 = new System.Windows.Forms.TextBox();
            this.textBox29 = new System.Windows.Forms.TextBox();
            this.textBox27 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label51 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabALL.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabSIMControl.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(837, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // programeToolStripMenuItem
            // 
            this.programeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.programeToolStripMenuItem.Name = "programeToolStripMenuItem";
            this.programeToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.programeToolStripMenuItem.Text = "Menu";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.AllowDrop = true;
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PortStatus,
            this.IP,
            this.PortNumber,
            this.lblObjectUri,
            this.labelDevice,
            this.labelDataType});
            this.statusStrip1.Location = new System.Drawing.Point(0, 803);
            this.statusStrip1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(837, 26);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.TabStop = true;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // PortStatus
            // 
            this.PortStatus.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.PortStatus.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.PortStatus.Name = "PortStatus";
            this.PortStatus.Size = new System.Drawing.Size(87, 21);
            this.PortStatus.Text = "PORT : CLOSE";
            // 
            // IP
            // 
            this.IP.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.IP.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.IP.Name = "IP";
            this.IP.Size = new System.Drawing.Size(83, 21);
            this.IP.Text = "IP : 127.0.0.1";
            // 
            // PortNumber
            // 
            this.PortNumber.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.PortNumber.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.PortNumber.Name = "PortNumber";
            this.PortNumber.Size = new System.Drawing.Size(97, 21);
            this.PortNumber.Text = "PORTNO : 3333";
            // 
            // lblObjectUri
            // 
            this.lblObjectUri.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblObjectUri.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.lblObjectUri.Name = "lblObjectUri";
            this.lblObjectUri.Size = new System.Drawing.Size(61, 21);
            this.lblObjectUri.Text = "ObjectUri";
            // 
            // labelDevice
            // 
            this.labelDevice.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.labelDevice.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.labelDevice.Name = "labelDevice";
            this.labelDevice.Size = new System.Drawing.Size(87, 21);
            this.labelDevice.Text = "Device Type : ";
            // 
            // labelDataType
            // 
            this.labelDataType.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.labelDataType.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.labelDataType.Name = "labelDataType";
            this.labelDataType.Size = new System.Drawing.Size(72, 21);
            this.labelDataType.Text = "Data Type :";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 600;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tmrStatusRefresh
            // 
            this.tmrStatusRefresh.Interval = 150;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(829, 752);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "DEVICE";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbHEX);
            this.panel2.Controls.Add(this.lbDEC);
            this.panel2.Controls.Add(this.lbBIN);
            this.panel2.Controls.Add(this.btnDeviceSetting);
            this.panel2.Controls.Add(this.btnScenarioMode);
            this.panel2.Controls.Add(this.hScrollBar1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 484);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(823, 265);
            this.panel2.TabIndex = 5;
            // 
            // lbHEX
            // 
            this.lbHEX.BackColor = System.Drawing.Color.LightGray;
            this.lbHEX.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbHEX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbHEX.Location = new System.Drawing.Point(703, 38);
            this.lbHEX.Name = "lbHEX";
            this.lbHEX.Size = new System.Drawing.Size(93, 45);
            this.lbHEX.TabIndex = 5;
            this.lbHEX.Text = "HEX";
            this.lbHEX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbHEX.Click += new System.EventHandler(this.lbHEX_Click);
            // 
            // lbDEC
            // 
            this.lbDEC.BackColor = System.Drawing.Color.LightGray;
            this.lbDEC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbDEC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbDEC.Location = new System.Drawing.Point(604, 38);
            this.lbDEC.Name = "lbDEC";
            this.lbDEC.Size = new System.Drawing.Size(93, 45);
            this.lbDEC.TabIndex = 4;
            this.lbDEC.Text = "DEC";
            this.lbDEC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbDEC.Click += new System.EventHandler(this.lbDEC_Click);
            // 
            // lbBIN
            // 
            this.lbBIN.BackColor = System.Drawing.Color.LightGray;
            this.lbBIN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbBIN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbBIN.Location = new System.Drawing.Point(505, 38);
            this.lbBIN.Name = "lbBIN";
            this.lbBIN.Size = new System.Drawing.Size(93, 45);
            this.lbBIN.TabIndex = 3;
            this.lbBIN.Text = "BIN";
            this.lbBIN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbBIN.Click += new System.EventHandler(this.lbBIN_Click);
            // 
            // btnDeviceSetting
            // 
            this.btnDeviceSetting.Location = new System.Drawing.Point(160, 36);
            this.btnDeviceSetting.Name = "btnDeviceSetting";
            this.btnDeviceSetting.Size = new System.Drawing.Size(149, 48);
            this.btnDeviceSetting.TabIndex = 2;
            this.btnDeviceSetting.Text = "Device Setting";
            this.btnDeviceSetting.UseVisualStyleBackColor = true;
            this.btnDeviceSetting.Click += new System.EventHandler(this.btnDeviceSetting_Click);
            // 
            // btnScenarioMode
            // 
            this.btnScenarioMode.Location = new System.Drawing.Point(5, 37);
            this.btnScenarioMode.Name = "btnScenarioMode";
            this.btnScenarioMode.Size = new System.Drawing.Size(149, 48);
            this.btnScenarioMode.TabIndex = 1;
            this.btnScenarioMode.Text = "Scenario Mode";
            this.btnScenarioMode.UseVisualStyleBackColor = true;
            this.btnScenarioMode.Click += new System.EventHandler(this.btnScenarioMode_Click);
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.hScrollBar1.Location = new System.Drawing.Point(0, 0);
            this.hScrollBar1.Maximum = 65481;
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(823, 29);
            this.hScrollBar1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(823, 481);
            this.panel1.TabIndex = 4;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(823, 481);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Column1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Column2
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Column3
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Column4
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column4.HeaderText = "Column4";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Column5
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column5.HeaderText = "Column5";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Column6
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.Column6.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column6.HeaderText = "Column6";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Column7
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            this.Column7.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column7.HeaderText = "Column7";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Column8
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            this.Column8.DefaultCellStyle = dataGridViewCellStyle8;
            this.Column8.HeaderText = "Column8";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkExchange);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.textBox18);
            this.tabPage1.Controls.Add(this.label74);
            this.tabPage1.Controls.Add(this.textBox97);
            this.tabPage1.Controls.Add(this.textBox96);
            this.tabPage1.Controls.Add(this.textBox95);
            this.tabPage1.Controls.Add(this.textBox94);
            this.tabPage1.Controls.Add(this.textBox93);
            this.tabPage1.Controls.Add(this.textBox92);
            this.tabPage1.Controls.Add(this.textBox88);
            this.tabPage1.Controls.Add(this.textBox86);
            this.tabPage1.Controls.Add(this.textBox91);
            this.tabPage1.Controls.Add(this.textBox90);
            this.tabPage1.Controls.Add(this.textBox89);
            this.tabPage1.Controls.Add(this.textBox87);
            this.tabPage1.Controls.Add(this.textBox85);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label20);
            this.tabPage1.Controls.Add(this.lblBCSentOutJobReply);
            this.tabPage1.Controls.Add(this.label71);
            this.tabPage1.Controls.Add(this.label19);
            this.tabPage1.Controls.Add(this.label62);
            this.tabPage1.Controls.Add(this.label59);
            this.tabPage1.Controls.Add(this.label60);
            this.tabPage1.Controls.Add(this.label65);
            this.tabPage1.Controls.Add(this.label64);
            this.tabPage1.Controls.Add(this.label70);
            this.tabPage1.Controls.Add(this.label69);
            this.tabPage1.Controls.Add(this.label68);
            this.tabPage1.Controls.Add(this.label75);
            this.tabPage1.Controls.Add(this.label73);
            this.tabPage1.Controls.Add(this.label72);
            this.tabPage1.Controls.Add(this.label67);
            this.tabPage1.Controls.Add(this.label66);
            this.tabPage1.Controls.Add(this.label63);
            this.tabPage1.Controls.Add(this.label61);
            this.tabPage1.Controls.Add(this.label58);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label57);
            this.tabPage1.Controls.Add(this.label56);
            this.tabPage1.Controls.Add(this.label55);
            this.tabPage1.Controls.Add(this.label54);
            this.tabPage1.Controls.Add(this.label53);
            this.tabPage1.Controls.Add(this.label52);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.button14);
            this.tabPage1.Controls.Add(this.button12);
            this.tabPage1.Controls.Add(this.button10);
            this.tabPage1.Controls.Add(this.button8);
            this.tabPage1.Controls.Add(this.button6);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.button15);
            this.tabPage1.Controls.Add(this.btnGlassLoading);
            this.tabPage1.Controls.Add(this.button11);
            this.tabPage1.Controls.Add(this.button9);
            this.tabPage1.Controls.Add(this.button7);
            this.tabPage1.Controls.Add(this.button5);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.tabControl1);
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(829, 752);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "BC/INDEXER";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chkExchange
            // 
            this.chkExchange.AutoSize = true;
            this.chkExchange.Location = new System.Drawing.Point(165, 321);
            this.chkExchange.Name = "chkExchange";
            this.chkExchange.Size = new System.Drawing.Size(79, 18);
            this.chkExchange.TabIndex = 50;
            this.chkExchange.Text = "Exchange";
            this.chkExchange.UseVisualStyleBackColor = true;
            this.chkExchange.CheckedChanged += new System.EventHandler(this.chkExchange_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label80);
            this.groupBox4.Controls.Add(this.label28);
            this.groupBox4.Controls.Add(this.label78);
            this.groupBox4.Controls.Add(this.label24);
            this.groupBox4.Controls.Add(this.label29);
            this.groupBox4.Controls.Add(this.label26);
            this.groupBox4.Controls.Add(this.label25);
            this.groupBox4.Location = new System.Drawing.Point(161, 362);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(135, 156);
            this.groupBox4.TabIndex = 49;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "ROBOT Downstream";
            // 
            // label80
            // 
            this.label80.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label80.Location = new System.Drawing.Point(4, 37);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(127, 19);
            this.label80.TabIndex = 39;
            this.label80.Text = "DownStream Trouble";
            this.label80.Click += new System.EventHandler(this.label80_Click);
            // 
            // label28
            // 
            this.label28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label28.Location = new System.Drawing.Point(4, 18);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(127, 19);
            this.label28.TabIndex = 39;
            this.label28.Text = "DownStream Inline";
            this.label28.Click += new System.EventHandler(this.label28_Click);
            // 
            // label78
            // 
            this.label78.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label78.Location = new System.Drawing.Point(4, 56);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(127, 19);
            this.label78.TabIndex = 39;
            this.label78.Text = "Exchange Execute";
            this.label78.Click += new System.EventHandler(this.label78_Click);
            // 
            // label24
            // 
            this.label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label24.Location = new System.Drawing.Point(4, 75);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(127, 19);
            this.label24.TabIndex = 39;
            this.label24.Text = "Receive Able";
            this.label24.Click += new System.EventHandler(this.label24_Click);
            // 
            // label29
            // 
            this.label29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label29.Location = new System.Drawing.Point(4, 113);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(127, 19);
            this.label29.TabIndex = 39;
            this.label29.Text = "Job Transfer Signal";
            this.label29.Click += new System.EventHandler(this.label29_Click);
            // 
            // label26
            // 
            this.label26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label26.Location = new System.Drawing.Point(4, 132);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(127, 19);
            this.label26.TabIndex = 39;
            this.label26.Text = "Receive Complete";
            this.label26.Click += new System.EventHandler(this.label26_Click);
            // 
            // label25
            // 
            this.label25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label25.Location = new System.Drawing.Point(4, 94);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(127, 19);
            this.label25.TabIndex = 39;
            this.label25.Text = "Receive Start";
            this.label25.Click += new System.EventHandler(this.label25_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label79);
            this.groupBox3.Controls.Add(this.label30);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.lblStageExchangePossible);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Location = new System.Drawing.Point(14, 362);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(135, 142);
            this.groupBox3.TabIndex = 49;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "STAGE Upstream";
            // 
            // label79
            // 
            this.label79.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label79.Location = new System.Drawing.Point(5, 37);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(127, 19);
            this.label79.TabIndex = 39;
            this.label79.Text = "Upstream Trouble";
            // 
            // label30
            // 
            this.label30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label30.Location = new System.Drawing.Point(5, 18);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(127, 19);
            this.label30.TabIndex = 39;
            this.label30.Text = "Upstream Inline";
            // 
            // label23
            // 
            this.label23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label23.Location = new System.Drawing.Point(5, 113);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(127, 19);
            this.label23.TabIndex = 39;
            this.label23.Text = "Send Complete";
            // 
            // label22
            // 
            this.label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label22.Location = new System.Drawing.Point(5, 94);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(127, 19);
            this.label22.TabIndex = 39;
            this.label22.Text = "Send Start";
            // 
            // lblStageExchangePossible
            // 
            this.lblStageExchangePossible.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStageExchangePossible.Location = new System.Drawing.Point(5, 56);
            this.lblStageExchangePossible.Name = "lblStageExchangePossible";
            this.lblStageExchangePossible.Size = new System.Drawing.Size(127, 19);
            this.lblStageExchangePossible.TabIndex = 39;
            this.lblStageExchangePossible.Text = "Exchange Possible";
            // 
            // label21
            // 
            this.label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label21.Location = new System.Drawing.Point(5, 75);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(127, 19);
            this.label21.TabIndex = 39;
            this.label21.Text = "Send Able";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label76);
            this.groupBox2.Controls.Add(this.label31);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Location = new System.Drawing.Point(14, 167);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(135, 128);
            this.groupBox2.TabIndex = 48;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "STAGE Downstream";
            // 
            // label76
            // 
            this.label76.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label76.Location = new System.Drawing.Point(4, 37);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(127, 19);
            this.label76.TabIndex = 39;
            this.label76.Text = "Downstream Trouble";
            // 
            // label31
            // 
            this.label31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label31.Location = new System.Drawing.Point(4, 18);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(127, 19);
            this.label31.TabIndex = 39;
            this.label31.Text = "Downstream Inline";
            // 
            // label12
            // 
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Location = new System.Drawing.Point(4, 56);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(127, 19);
            this.label12.TabIndex = 39;
            this.label12.Text = "Receive Able";
            // 
            // label13
            // 
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Location = new System.Drawing.Point(4, 75);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(127, 19);
            this.label13.TabIndex = 39;
            this.label13.Text = "Receive Start";
            // 
            // label14
            // 
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Location = new System.Drawing.Point(4, 94);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(127, 19);
            this.label14.TabIndex = 39;
            this.label14.Text = "Receive Complete";
            // 
            // textBox18
            // 
            this.textBox18.Location = new System.Drawing.Point(540, 370);
            this.textBox18.Multiline = true;
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(100, 80);
            this.textBox18.TabIndex = 47;
            this.textBox18.Text = "1,1\r\n2,5\r\n3,6\r\n4,8";
            this.textBox18.TextChanged += new System.EventHandler(this.textBox18_TextChanged);
            // 
            // label74
            // 
            this.label74.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label74.Location = new System.Drawing.Point(316, 370);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(180, 19);
            this.label74.TabIndex = 46;
            this.label74.Text = "Machine/Unit Recipe Request";
            // 
            // textBox97
            // 
            this.textBox97.Location = new System.Drawing.Point(718, 204);
            this.textBox97.Name = "textBox97";
            this.textBox97.Size = new System.Drawing.Size(24, 22);
            this.textBox97.TabIndex = 45;
            this.textBox97.Text = "3";
            this.textBox97.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox96
            // 
            this.textBox96.Location = new System.Drawing.Point(694, 204);
            this.textBox96.Name = "textBox96";
            this.textBox96.Size = new System.Drawing.Size(24, 22);
            this.textBox96.TabIndex = 45;
            this.textBox96.Text = "2";
            this.textBox96.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox95
            // 
            this.textBox95.Location = new System.Drawing.Point(670, 204);
            this.textBox95.Name = "textBox95";
            this.textBox95.Size = new System.Drawing.Size(24, 22);
            this.textBox95.TabIndex = 45;
            this.textBox95.Text = "4";
            this.textBox95.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox94
            // 
            this.textBox94.Location = new System.Drawing.Point(646, 204);
            this.textBox94.Name = "textBox94";
            this.textBox94.Size = new System.Drawing.Size(24, 22);
            this.textBox94.TabIndex = 45;
            this.textBox94.Text = "7";
            this.textBox94.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox93
            // 
            this.textBox93.Location = new System.Drawing.Point(622, 204);
            this.textBox93.Name = "textBox93";
            this.textBox93.Size = new System.Drawing.Size(24, 22);
            this.textBox93.TabIndex = 45;
            this.textBox93.Text = "10";
            this.textBox93.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox92
            // 
            this.textBox92.Location = new System.Drawing.Point(578, 204);
            this.textBox92.Name = "textBox92";
            this.textBox92.Size = new System.Drawing.Size(44, 22);
            this.textBox92.TabIndex = 45;
            this.textBox92.Text = "2016";
            this.textBox92.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox88
            // 
            this.textBox88.Location = new System.Drawing.Point(473, 113);
            this.textBox88.Name = "textBox88";
            this.textBox88.Size = new System.Drawing.Size(350, 22);
            this.textBox88.TabIndex = 44;
            this.textBox88.Text = "10,20,30";
            // 
            // textBox86
            // 
            this.textBox86.Location = new System.Drawing.Point(706, 38);
            this.textBox86.Name = "textBox86";
            this.textBox86.Size = new System.Drawing.Size(37, 22);
            this.textBox86.TabIndex = 43;
            this.textBox86.Text = "1";
            // 
            // textBox91
            // 
            this.textBox91.Location = new System.Drawing.Point(719, 135);
            this.textBox91.Name = "textBox91";
            this.textBox91.Size = new System.Drawing.Size(29, 22);
            this.textBox91.TabIndex = 43;
            this.textBox91.Text = "ABCDEFG";
            // 
            // textBox90
            // 
            this.textBox90.Location = new System.Drawing.Point(688, 151);
            this.textBox90.Name = "textBox90";
            this.textBox90.Size = new System.Drawing.Size(29, 22);
            this.textBox90.TabIndex = 43;
            this.textBox90.Text = "1";
            // 
            // textBox89
            // 
            this.textBox89.Location = new System.Drawing.Point(657, 151);
            this.textBox89.Name = "textBox89";
            this.textBox89.Size = new System.Drawing.Size(29, 22);
            this.textBox89.TabIndex = 43;
            this.textBox89.Text = "1";
            // 
            // textBox87
            // 
            this.textBox87.Location = new System.Drawing.Point(657, 84);
            this.textBox87.Name = "textBox87";
            this.textBox87.Size = new System.Drawing.Size(37, 22);
            this.textBox87.TabIndex = 43;
            this.textBox87.Text = "1";
            // 
            // textBox85
            // 
            this.textBox85.Location = new System.Drawing.Point(657, 38);
            this.textBox85.Name = "textBox85";
            this.textBox85.Size = new System.Drawing.Size(37, 22);
            this.textBox85.TabIndex = 43;
            this.textBox85.Text = "1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblRobotSendAble);
            this.groupBox1.Controls.Add(this.lblRobotUpstreamTrouble);
            this.groupBox1.Controls.Add(this.lblRobotUpstreamInline);
            this.groupBox1.Controls.Add(this.lblRobotSendStart);
            this.groupBox1.Controls.Add(this.lblRootSendComplete);
            this.groupBox1.Controls.Add(this.lblRobotSendJobTransSignal);
            this.groupBox1.Location = new System.Drawing.Point(161, 167);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(135, 148);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ROBOT UP";
            // 
            // lblRobotSendAble
            // 
            this.lblRobotSendAble.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRobotSendAble.Location = new System.Drawing.Point(4, 60);
            this.lblRobotSendAble.Name = "lblRobotSendAble";
            this.lblRobotSendAble.Size = new System.Drawing.Size(127, 19);
            this.lblRobotSendAble.TabIndex = 39;
            this.lblRobotSendAble.Text = "Send Able";
            this.lblRobotSendAble.Click += new System.EventHandler(this.label15_Click);
            // 
            // lblRobotUpstreamTrouble
            // 
            this.lblRobotUpstreamTrouble.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRobotUpstreamTrouble.Location = new System.Drawing.Point(4, 40);
            this.lblRobotUpstreamTrouble.Name = "lblRobotUpstreamTrouble";
            this.lblRobotUpstreamTrouble.Size = new System.Drawing.Size(127, 19);
            this.lblRobotUpstreamTrouble.TabIndex = 39;
            this.lblRobotUpstreamTrouble.Text = "Upstream Trouble";
            this.lblRobotUpstreamTrouble.Click += new System.EventHandler(this.label77_Click);
            // 
            // lblRobotUpstreamInline
            // 
            this.lblRobotUpstreamInline.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRobotUpstreamInline.Location = new System.Drawing.Point(4, 20);
            this.lblRobotUpstreamInline.Name = "lblRobotUpstreamInline";
            this.lblRobotUpstreamInline.Size = new System.Drawing.Size(127, 19);
            this.lblRobotUpstreamInline.TabIndex = 39;
            this.lblRobotUpstreamInline.Text = "Upstream Inline";
            this.lblRobotUpstreamInline.Click += new System.EventHandler(this.label27_Click);
            // 
            // lblRobotSendStart
            // 
            this.lblRobotSendStart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRobotSendStart.Location = new System.Drawing.Point(4, 80);
            this.lblRobotSendStart.Name = "lblRobotSendStart";
            this.lblRobotSendStart.Size = new System.Drawing.Size(127, 19);
            this.lblRobotSendStart.TabIndex = 39;
            this.lblRobotSendStart.Text = "Send Start";
            this.lblRobotSendStart.Click += new System.EventHandler(this.label16_Click);
            // 
            // lblRootSendComplete
            // 
            this.lblRootSendComplete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRootSendComplete.Location = new System.Drawing.Point(4, 100);
            this.lblRootSendComplete.Name = "lblRootSendComplete";
            this.lblRootSendComplete.Size = new System.Drawing.Size(127, 19);
            this.lblRootSendComplete.TabIndex = 39;
            this.lblRootSendComplete.Text = "Send Complete";
            this.lblRootSendComplete.Click += new System.EventHandler(this.label17_Click);
            // 
            // lblRobotSendJobTransSignal
            // 
            this.lblRobotSendJobTransSignal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRobotSendJobTransSignal.Location = new System.Drawing.Point(4, 120);
            this.lblRobotSendJobTransSignal.Name = "lblRobotSendJobTransSignal";
            this.lblRobotSendJobTransSignal.Size = new System.Drawing.Size(127, 19);
            this.lblRobotSendJobTransSignal.TabIndex = 39;
            this.lblRobotSendJobTransSignal.Text = "Job Transfer Signal";
            this.lblRobotSendJobTransSignal.Click += new System.EventHandler(this.label18_Click);
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(17, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 19);
            this.label3.TabIndex = 39;
            this.label3.Text = "Running";
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(17, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 19);
            this.label4.TabIndex = 39;
            this.label4.Text = "CIM Mode";
            // 
            // label11
            // 
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Location = new System.Drawing.Point(173, 140);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 19);
            this.label11.TabIndex = 39;
            // 
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Location = new System.Drawing.Point(121, 140);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 19);
            this.label10.TabIndex = 39;
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Location = new System.Drawing.Point(69, 140);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 19);
            this.label9.TabIndex = 39;
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Location = new System.Drawing.Point(17, 140);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 19);
            this.label8.TabIndex = 39;
            // 
            // label20
            // 
            this.label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label20.Location = new System.Drawing.Point(19, 507);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(126, 19);
            this.label20.TabIndex = 39;
            this.label20.Text = "Sent Out Job Report";
            // 
            // lblBCSentOutJobReply
            // 
            this.lblBCSentOutJobReply.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBCSentOutJobReply.Location = new System.Drawing.Point(88, 526);
            this.lblBCSentOutJobReply.Name = "lblBCSentOutJobReply";
            this.lblBCSentOutJobReply.Size = new System.Drawing.Size(57, 19);
            this.lblBCSentOutJobReply.TabIndex = 39;
            this.lblBCSentOutJobReply.Text = "BC Reply";
            // 
            // label71
            // 
            this.label71.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label71.Location = new System.Drawing.Point(88, 317);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(57, 19);
            this.label71.TabIndex = 39;
            this.label71.Text = "BC Reply";
            // 
            // label19
            // 
            this.label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label19.Location = new System.Drawing.Point(17, 298);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(128, 19);
            this.label19.TabIndex = 39;
            this.label19.Text = "Receive Job Report";
            // 
            // label62
            // 
            this.label62.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label62.Location = new System.Drawing.Point(284, 113);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(105, 22);
            this.label62.TabIndex = 39;
            // 
            // label59
            // 
            this.label59.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label59.Location = new System.Drawing.Point(284, 61);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(363, 22);
            this.label59.TabIndex = 39;
            // 
            // label60
            // 
            this.label60.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label60.Location = new System.Drawing.Point(284, 15);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(184, 19);
            this.label60.TabIndex = 39;
            this.label60.Text = "CIM Mode Change Reply";
            // 
            // label65
            // 
            this.label65.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label65.Location = new System.Drawing.Point(181, 61);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(97, 19);
            this.label65.TabIndex = 39;
            this.label65.Text = "Heavy Alarm";
            // 
            // label64
            // 
            this.label64.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label64.Location = new System.Drawing.Point(181, 24);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(97, 19);
            this.label64.TabIndex = 39;
            this.label64.Text = "Light Alarm";
            // 
            // label70
            // 
            this.label70.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label70.Location = new System.Drawing.Point(523, 273);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(51, 19);
            this.label70.TabIndex = 39;
            // 
            // label69
            // 
            this.label69.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label69.Location = new System.Drawing.Point(472, 273);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(51, 19);
            this.label69.TabIndex = 39;
            // 
            // label68
            // 
            this.label68.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label68.Location = new System.Drawing.Point(440, 273);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(32, 19);
            this.label68.TabIndex = 39;
            // 
            // label75
            // 
            this.label75.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label75.Location = new System.Drawing.Point(496, 370);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(44, 19);
            this.label75.TabIndex = 39;
            this.label75.Text = "REPLY";
            this.label75.Click += new System.EventHandler(this.label75_Click);
            // 
            // label73
            // 
            this.label73.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label73.Location = new System.Drawing.Point(468, 315);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(44, 19);
            this.label73.TabIndex = 39;
            this.label73.Text = "REPLY";
            // 
            // label72
            // 
            this.label72.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label72.Location = new System.Drawing.Point(316, 315);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(152, 19);
            this.label72.TabIndex = 39;
            this.label72.Text = "SCRAP JOB REPORT";
            // 
            // label67
            // 
            this.label67.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label67.Location = new System.Drawing.Point(316, 273);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(124, 19);
            this.label67.TabIndex = 39;
            this.label67.Text = "Glass Data Request";
            // 
            // label66
            // 
            this.label66.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label66.Location = new System.Drawing.Point(362, 207);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(106, 19);
            this.label66.TabIndex = 39;
            this.label66.Text = "Time Set Reply";
            // 
            // label63
            // 
            this.label63.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label63.Location = new System.Drawing.Point(284, 139);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(184, 19);
            this.label63.TabIndex = 39;
            this.label63.Text = "CIM Message Confirm";
            // 
            // label61
            // 
            this.label61.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label61.Location = new System.Drawing.Point(284, 86);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(184, 19);
            this.label61.TabIndex = 39;
            this.label61.Text = "Recipe Parmater Down Confirm";
            // 
            // label58
            // 
            this.label58.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label58.Location = new System.Drawing.Point(284, 40);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(184, 19);
            this.label58.TabIndex = 39;
            this.label58.Text = "Recipe Parameter Data Report";
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Location = new System.Drawing.Point(17, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(190, 19);
            this.label7.TabIndex = 39;
            this.label7.Text = "Machine Status Change Report";
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(17, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(158, 19);
            this.label6.TabIndex = 39;
            this.label6.Text = "Auto Recipe Change Mode";
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(17, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 19);
            this.label5.TabIndex = 39;
            this.label5.Text = "Heartbeat";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(17, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 19);
            this.label2.TabIndex = 39;
            this.label2.Text = "Auto Mode";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(458, 236);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(188, 14);
            this.label57.TabIndex = 38;
            this.label57.Text = "Machine Mode Change Command";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(470, 207);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(105, 14);
            this.label56.TabIndex = 38;
            this.label56.Text = "Machine Time Set";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(482, 173);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(165, 14);
            this.label55.TabIndex = 38;
            this.label55.Text = "CIM Message Clear Command";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(489, 138);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(158, 14);
            this.label54.TabIndex = 38;
            this.label54.Text = "CIM Message Set Command";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(490, 88);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(161, 14);
            this.label53.TabIndex = 38;
            this.label53.Text = "Recipe Parameter Download";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(470, 42);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(181, 14);
            this.label52.TabIndex = 38;
            this.label52.Text = "Recipe Parameter Data Request";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(483, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 14);
            this.label1.TabIndex = 38;
            this.label1.Text = "CIM Mode Change Command";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1:CIM Off",
            "2:CIM On"});
            this.comboBox1.Location = new System.Drawing.Point(657, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(86, 22);
            this.comboBox1.TabIndex = 37;
            this.comboBox1.Text = "2:CIM On";
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(786, 227);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(37, 23);
            this.button14.TabIndex = 36;
            this.button14.Text = "OFF";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button12_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(786, 202);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(37, 23);
            this.button12.TabIndex = 36;
            this.button12.Text = "OFF";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(786, 170);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(37, 23);
            this.button10.TabIndex = 36;
            this.button10.Text = "OFF";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(786, 135);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(37, 23);
            this.button8.TabIndex = 36;
            this.button8.Text = "OFF";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(786, 84);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(37, 23);
            this.button6.TabIndex = 36;
            this.button6.Text = "OFF";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(786, 38);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(37, 23);
            this.button4.TabIndex = 36;
            this.button4.Text = "OFF";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(692, 340);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(85, 26);
            this.button15.TabIndex = 36;
            this.button15.Text = "Unloading";
            this.button15.UseVisualStyleBackColor = true;
            // 
            // btnGlassLoading
            // 
            this.btnGlassLoading.Location = new System.Drawing.Point(601, 340);
            this.btnGlassLoading.Name = "btnGlassLoading";
            this.btnGlassLoading.Size = new System.Drawing.Size(85, 26);
            this.btnGlassLoading.TabIndex = 36;
            this.btnGlassLoading.Text = "Loding";
            this.btnGlassLoading.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(749, 202);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(37, 23);
            this.button11.TabIndex = 36;
            this.button11.Text = "ON";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(749, 170);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(37, 23);
            this.button9.TabIndex = 36;
            this.button9.Text = "ON";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(749, 135);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(37, 23);
            this.button7.TabIndex = 36;
            this.button7.Text = "ON";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(749, 84);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(37, 23);
            this.button5.TabIndex = 36;
            this.button5.Text = "ON";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(786, 11);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(37, 23);
            this.button2.TabIndex = 36;
            this.button2.Text = "OFF";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(749, 38);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(37, 23);
            this.button3.TabIndex = 36;
            this.button3.Text = "ON";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(749, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(37, 23);
            this.button1.TabIndex = 36;
            this.button1.Text = "ON";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabALL);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.Location = new System.Drawing.Point(3, 539);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(823, 172);
            this.tabControl1.TabIndex = 24;
            // 
            // tabALL
            // 
            this.tabALL.Controls.Add(this.txtScannerLog);
            this.tabALL.Location = new System.Drawing.Point(4, 23);
            this.tabALL.Name = "tabALL";
            this.tabALL.Padding = new System.Windows.Forms.Padding(3);
            this.tabALL.Size = new System.Drawing.Size(815, 145);
            this.tabALL.TabIndex = 0;
            this.tabALL.Text = "ALL";
            this.tabALL.UseVisualStyleBackColor = true;
            // 
            // txtScannerLog
            // 
            this.txtScannerLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtScannerLog.Enabled = false;
            this.txtScannerLog.Location = new System.Drawing.Point(3, 3);
            this.txtScannerLog.Multiline = true;
            this.txtScannerLog.Name = "txtScannerLog";
            this.txtScannerLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtScannerLog.Size = new System.Drawing.Size(809, 139);
            this.txtScannerLog.TabIndex = 12;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnErrorStop);
            this.panel3.Controls.Add(this.btnAllEMPStop);
            this.panel3.Controls.Add(this.btnAllScemarioStart);
            this.panel3.Controls.Add(this.btnStartEMSScenario);
            this.panel3.Controls.Add(this.chkLogging);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 711);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(823, 38);
            this.panel3.TabIndex = 42;
            // 
            // btnErrorStop
            // 
            this.btnErrorStop.Location = new System.Drawing.Point(713, 4);
            this.btnErrorStop.Name = "btnErrorStop";
            this.btnErrorStop.Size = new System.Drawing.Size(81, 28);
            this.btnErrorStop.TabIndex = 19;
            this.btnErrorStop.Text = "STOP";
            this.btnErrorStop.UseVisualStyleBackColor = true;
            // 
            // btnAllEMPStop
            // 
            this.btnAllEMPStop.Location = new System.Drawing.Point(626, 4);
            this.btnAllEMPStop.Name = "btnAllEMPStop";
            this.btnAllEMPStop.Size = new System.Drawing.Size(81, 28);
            this.btnAllEMPStop.TabIndex = 23;
            this.btnAllEMPStop.Text = "ALLSTOP";
            this.btnAllEMPStop.UseVisualStyleBackColor = true;
            // 
            // btnAllScemarioStart
            // 
            this.btnAllScemarioStart.Location = new System.Drawing.Point(412, 4);
            this.btnAllScemarioStart.Name = "btnAllScemarioStart";
            this.btnAllScemarioStart.Size = new System.Drawing.Size(81, 28);
            this.btnAllScemarioStart.TabIndex = 32;
            this.btnAllScemarioStart.Text = "ALLSTART";
            this.btnAllScemarioStart.UseVisualStyleBackColor = true;
            // 
            // btnStartEMSScenario
            // 
            this.btnStartEMSScenario.Location = new System.Drawing.Point(499, 4);
            this.btnStartEMSScenario.Name = "btnStartEMSScenario";
            this.btnStartEMSScenario.Size = new System.Drawing.Size(81, 28);
            this.btnStartEMSScenario.TabIndex = 33;
            this.btnStartEMSScenario.Text = "START";
            this.btnStartEMSScenario.UseVisualStyleBackColor = true;
            // 
            // chkLogging
            // 
            this.chkLogging.AutoSize = true;
            this.chkLogging.Checked = true;
            this.chkLogging.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLogging.Location = new System.Drawing.Point(328, 4);
            this.chkLogging.Name = "chkLogging";
            this.chkLogging.Size = new System.Drawing.Size(69, 18);
            this.chkLogging.TabIndex = 35;
            this.chkLogging.Text = "Logging";
            this.chkLogging.UseVisualStyleBackColor = true;
            // 
            // tabSIMControl
            // 
            this.tabSIMControl.Controls.Add(this.tabPage1);
            this.tabSIMControl.Controls.Add(this.tabPage2);
            this.tabSIMControl.Controls.Add(this.tabPage3);
            this.tabSIMControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSIMControl.Location = new System.Drawing.Point(0, 24);
            this.tabSIMControl.Name = "tabSIMControl";
            this.tabSIMControl.SelectedIndex = 0;
            this.tabSIMControl.Size = new System.Drawing.Size(837, 779);
            this.tabSIMControl.TabIndex = 3;
            this.tabSIMControl.SelectedIndexChanged += new System.EventHandler(this.tabSIMControl_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.textBox68);
            this.tabPage3.Controls.Add(this.textBox48);
            this.tabPage3.Controls.Add(this.textBox19);
            this.tabPage3.Controls.Add(this.textBox84);
            this.tabPage3.Controls.Add(this.textBox76);
            this.tabPage3.Controls.Add(this.textBox23);
            this.tabPage3.Controls.Add(this.textBox83);
            this.tabPage3.Controls.Add(this.textBox75);
            this.tabPage3.Controls.Add(this.textBox26);
            this.tabPage3.Controls.Add(this.textBox82);
            this.tabPage3.Controls.Add(this.textBox74);
            this.tabPage3.Controls.Add(this.textBox25);
            this.tabPage3.Controls.Add(this.textBox81);
            this.tabPage3.Controls.Add(this.textBox73);
            this.tabPage3.Controls.Add(this.textBox24);
            this.tabPage3.Controls.Add(this.textBox80);
            this.tabPage3.Controls.Add(this.textBox72);
            this.tabPage3.Controls.Add(this.textBox22);
            this.tabPage3.Controls.Add(this.textBox79);
            this.tabPage3.Controls.Add(this.textBox71);
            this.tabPage3.Controls.Add(this.textBox21);
            this.tabPage3.Controls.Add(this.textBox78);
            this.tabPage3.Controls.Add(this.textBox70);
            this.tabPage3.Controls.Add(this.textBox20);
            this.tabPage3.Controls.Add(this.textBox77);
            this.tabPage3.Controls.Add(this.textBox69);
            this.tabPage3.Controls.Add(this.textBox1);
            this.tabPage3.Controls.Add(this.textBox66);
            this.tabPage3.Controls.Add(this.textBox46);
            this.tabPage3.Controls.Add(this.textBox17);
            this.tabPage3.Controls.Add(this.textBox65);
            this.tabPage3.Controls.Add(this.textBox45);
            this.tabPage3.Controls.Add(this.textBox16);
            this.tabPage3.Controls.Add(this.textBox64);
            this.tabPage3.Controls.Add(this.textBox44);
            this.tabPage3.Controls.Add(this.textBox15);
            this.tabPage3.Controls.Add(this.textBox63);
            this.tabPage3.Controls.Add(this.textBox43);
            this.tabPage3.Controls.Add(this.textBox14);
            this.tabPage3.Controls.Add(this.textBox62);
            this.tabPage3.Controls.Add(this.textBox42);
            this.tabPage3.Controls.Add(this.textBox13);
            this.tabPage3.Controls.Add(this.textBox61);
            this.tabPage3.Controls.Add(this.textBox41);
            this.tabPage3.Controls.Add(this.textBox12);
            this.tabPage3.Controls.Add(this.textBox60);
            this.tabPage3.Controls.Add(this.textBox40);
            this.tabPage3.Controls.Add(this.textBox11);
            this.tabPage3.Controls.Add(this.textBox59);
            this.tabPage3.Controls.Add(this.textBox39);
            this.tabPage3.Controls.Add(this.textBox10);
            this.tabPage3.Controls.Add(this.textBox58);
            this.tabPage3.Controls.Add(this.textBox38);
            this.tabPage3.Controls.Add(this.textBox9);
            this.tabPage3.Controls.Add(this.textBox57);
            this.tabPage3.Controls.Add(this.textBox37);
            this.tabPage3.Controls.Add(this.textBox8);
            this.tabPage3.Controls.Add(this.textBox56);
            this.tabPage3.Controls.Add(this.textBox36);
            this.tabPage3.Controls.Add(this.textBox7);
            this.tabPage3.Controls.Add(this.textBox55);
            this.tabPage3.Controls.Add(this.textBox35);
            this.tabPage3.Controls.Add(this.textBox6);
            this.tabPage3.Controls.Add(this.textBox54);
            this.tabPage3.Controls.Add(this.textBox34);
            this.tabPage3.Controls.Add(this.textBox5);
            this.tabPage3.Controls.Add(this.textBox53);
            this.tabPage3.Controls.Add(this.textBox33);
            this.tabPage3.Controls.Add(this.textBox4);
            this.tabPage3.Controls.Add(this.textBox52);
            this.tabPage3.Controls.Add(this.textBox51);
            this.tabPage3.Controls.Add(this.textBox32);
            this.tabPage3.Controls.Add(this.textBox31);
            this.tabPage3.Controls.Add(this.textBox50);
            this.tabPage3.Controls.Add(this.textBox3);
            this.tabPage3.Controls.Add(this.textBox30);
            this.tabPage3.Controls.Add(this.textBox49);
            this.tabPage3.Controls.Add(this.textBox28);
            this.tabPage3.Controls.Add(this.textBox29);
            this.tabPage3.Controls.Add(this.textBox27);
            this.tabPage3.Controls.Add(this.textBox2);
            this.tabPage3.Controls.Add(this.label51);
            this.tabPage3.Controls.Add(this.label50);
            this.tabPage3.Controls.Add(this.label49);
            this.tabPage3.Controls.Add(this.label48);
            this.tabPage3.Controls.Add(this.label47);
            this.tabPage3.Controls.Add(this.label46);
            this.tabPage3.Controls.Add(this.label45);
            this.tabPage3.Controls.Add(this.label44);
            this.tabPage3.Controls.Add(this.label43);
            this.tabPage3.Controls.Add(this.label42);
            this.tabPage3.Controls.Add(this.label41);
            this.tabPage3.Controls.Add(this.label40);
            this.tabPage3.Controls.Add(this.label39);
            this.tabPage3.Controls.Add(this.label38);
            this.tabPage3.Controls.Add(this.label37);
            this.tabPage3.Controls.Add(this.label36);
            this.tabPage3.Controls.Add(this.label35);
            this.tabPage3.Controls.Add(this.label34);
            this.tabPage3.Controls.Add(this.label33);
            this.tabPage3.Controls.Add(this.label32);
            this.tabPage3.Location = new System.Drawing.Point(4, 23);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(829, 752);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "JOB DATA";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // textBox68
            // 
            this.textBox68.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox68.Location = new System.Drawing.Point(565, 515);
            this.textBox68.Name = "textBox68";
            this.textBox68.Size = new System.Drawing.Size(201, 21);
            this.textBox68.TabIndex = 107;
            this.textBox68.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox48
            // 
            this.textBox48.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox48.Location = new System.Drawing.Point(358, 516);
            this.textBox48.Name = "textBox48";
            this.textBox48.Size = new System.Drawing.Size(201, 21);
            this.textBox48.TabIndex = 107;
            this.textBox48.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox19
            // 
            this.textBox19.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox19.Location = new System.Drawing.Point(151, 515);
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(201, 21);
            this.textBox19.TabIndex = 107;
            this.textBox19.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox84
            // 
            this.textBox84.Location = new System.Drawing.Point(665, 399);
            this.textBox84.Name = "textBox84";
            this.textBox84.Size = new System.Drawing.Size(37, 22);
            this.textBox84.TabIndex = 100;
            this.textBox84.Text = "0000";
            this.textBox84.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox76
            // 
            this.textBox76.Location = new System.Drawing.Point(458, 399);
            this.textBox76.Name = "textBox76";
            this.textBox76.Size = new System.Drawing.Size(37, 22);
            this.textBox76.TabIndex = 100;
            this.textBox76.Text = "0000";
            this.textBox76.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox23
            // 
            this.textBox23.Location = new System.Drawing.Point(251, 398);
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new System.Drawing.Size(37, 22);
            this.textBox23.TabIndex = 100;
            this.textBox23.Text = "0000";
            this.textBox23.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox83
            // 
            this.textBox83.Location = new System.Drawing.Point(740, 399);
            this.textBox83.Name = "textBox83";
            this.textBox83.Size = new System.Drawing.Size(19, 22);
            this.textBox83.TabIndex = 101;
            this.textBox83.Text = "0";
            this.textBox83.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox75
            // 
            this.textBox75.Location = new System.Drawing.Point(533, 399);
            this.textBox75.Name = "textBox75";
            this.textBox75.Size = new System.Drawing.Size(19, 22);
            this.textBox75.TabIndex = 101;
            this.textBox75.Text = "0";
            this.textBox75.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox26
            // 
            this.textBox26.Location = new System.Drawing.Point(326, 398);
            this.textBox26.Name = "textBox26";
            this.textBox26.Size = new System.Drawing.Size(19, 22);
            this.textBox26.TabIndex = 101;
            this.textBox26.Text = "0";
            this.textBox26.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox82
            // 
            this.textBox82.Location = new System.Drawing.Point(721, 399);
            this.textBox82.Name = "textBox82";
            this.textBox82.Size = new System.Drawing.Size(19, 22);
            this.textBox82.TabIndex = 98;
            this.textBox82.Text = "0";
            this.textBox82.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox74
            // 
            this.textBox74.Location = new System.Drawing.Point(514, 399);
            this.textBox74.Name = "textBox74";
            this.textBox74.Size = new System.Drawing.Size(19, 22);
            this.textBox74.TabIndex = 98;
            this.textBox74.Text = "0";
            this.textBox74.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox25
            // 
            this.textBox25.Location = new System.Drawing.Point(307, 398);
            this.textBox25.Name = "textBox25";
            this.textBox25.Size = new System.Drawing.Size(19, 22);
            this.textBox25.TabIndex = 98;
            this.textBox25.Text = "0";
            this.textBox25.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox81
            // 
            this.textBox81.Location = new System.Drawing.Point(702, 399);
            this.textBox81.Name = "textBox81";
            this.textBox81.Size = new System.Drawing.Size(19, 22);
            this.textBox81.TabIndex = 99;
            this.textBox81.Text = "0";
            this.textBox81.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox73
            // 
            this.textBox73.Location = new System.Drawing.Point(495, 399);
            this.textBox73.Name = "textBox73";
            this.textBox73.Size = new System.Drawing.Size(19, 22);
            this.textBox73.TabIndex = 99;
            this.textBox73.Text = "0";
            this.textBox73.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox24
            // 
            this.textBox24.Location = new System.Drawing.Point(288, 398);
            this.textBox24.Name = "textBox24";
            this.textBox24.Size = new System.Drawing.Size(19, 22);
            this.textBox24.TabIndex = 99;
            this.textBox24.Text = "0";
            this.textBox24.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox80
            // 
            this.textBox80.Location = new System.Drawing.Point(646, 399);
            this.textBox80.Name = "textBox80";
            this.textBox80.Size = new System.Drawing.Size(19, 22);
            this.textBox80.TabIndex = 102;
            this.textBox80.Text = "0";
            this.textBox80.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox72
            // 
            this.textBox72.Location = new System.Drawing.Point(439, 399);
            this.textBox72.Name = "textBox72";
            this.textBox72.Size = new System.Drawing.Size(19, 22);
            this.textBox72.TabIndex = 102;
            this.textBox72.Text = "0";
            this.textBox72.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox22
            // 
            this.textBox22.Location = new System.Drawing.Point(232, 398);
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new System.Drawing.Size(19, 22);
            this.textBox22.TabIndex = 102;
            this.textBox22.Text = "0";
            this.textBox22.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox79
            // 
            this.textBox79.Location = new System.Drawing.Point(627, 399);
            this.textBox79.Name = "textBox79";
            this.textBox79.Size = new System.Drawing.Size(19, 22);
            this.textBox79.TabIndex = 105;
            this.textBox79.Text = "0";
            this.textBox79.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox71
            // 
            this.textBox71.Location = new System.Drawing.Point(420, 399);
            this.textBox71.Name = "textBox71";
            this.textBox71.Size = new System.Drawing.Size(19, 22);
            this.textBox71.TabIndex = 105;
            this.textBox71.Text = "0";
            this.textBox71.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox21
            // 
            this.textBox21.Location = new System.Drawing.Point(213, 398);
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new System.Drawing.Size(19, 22);
            this.textBox21.TabIndex = 105;
            this.textBox21.Text = "0";
            this.textBox21.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox78
            // 
            this.textBox78.Location = new System.Drawing.Point(608, 399);
            this.textBox78.Name = "textBox78";
            this.textBox78.Size = new System.Drawing.Size(19, 22);
            this.textBox78.TabIndex = 106;
            this.textBox78.Text = "0";
            this.textBox78.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox70
            // 
            this.textBox70.Location = new System.Drawing.Point(401, 399);
            this.textBox70.Name = "textBox70";
            this.textBox70.Size = new System.Drawing.Size(19, 22);
            this.textBox70.TabIndex = 106;
            this.textBox70.Text = "0";
            this.textBox70.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox20
            // 
            this.textBox20.Location = new System.Drawing.Point(194, 398);
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new System.Drawing.Size(19, 22);
            this.textBox20.TabIndex = 106;
            this.textBox20.Text = "0";
            this.textBox20.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox77
            // 
            this.textBox77.Location = new System.Drawing.Point(575, 399);
            this.textBox77.Name = "textBox77";
            this.textBox77.Size = new System.Drawing.Size(33, 22);
            this.textBox77.TabIndex = 103;
            this.textBox77.Text = "000";
            this.textBox77.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox69
            // 
            this.textBox69.Location = new System.Drawing.Point(368, 399);
            this.textBox69.Name = "textBox69";
            this.textBox69.Size = new System.Drawing.Size(33, 22);
            this.textBox69.TabIndex = 103;
            this.textBox69.Text = "000";
            this.textBox69.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(161, 398);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(33, 22);
            this.textBox1.TabIndex = 103;
            this.textBox1.Text = "000";
            // 
            // textBox66
            // 
            this.textBox66.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox66.Location = new System.Drawing.Point(565, 375);
            this.textBox66.Name = "textBox66";
            this.textBox66.Size = new System.Drawing.Size(201, 21);
            this.textBox66.TabIndex = 97;
            this.textBox66.Text = "1";
            this.textBox66.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox46
            // 
            this.textBox46.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox46.Location = new System.Drawing.Point(358, 376);
            this.textBox46.Name = "textBox46";
            this.textBox46.Size = new System.Drawing.Size(201, 21);
            this.textBox46.TabIndex = 97;
            this.textBox46.Text = "1";
            this.textBox46.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox17
            // 
            this.textBox17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox17.Location = new System.Drawing.Point(151, 375);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(201, 21);
            this.textBox17.TabIndex = 97;
            this.textBox17.Text = "1";
            this.textBox17.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox65
            // 
            this.textBox65.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox65.Location = new System.Drawing.Point(565, 351);
            this.textBox65.Name = "textBox65";
            this.textBox65.Size = new System.Drawing.Size(201, 21);
            this.textBox65.TabIndex = 96;
            this.textBox65.Text = "00000000000000000000000000000000";
            this.textBox65.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox45
            // 
            this.textBox45.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox45.Location = new System.Drawing.Point(358, 352);
            this.textBox45.Name = "textBox45";
            this.textBox45.Size = new System.Drawing.Size(201, 21);
            this.textBox45.TabIndex = 96;
            this.textBox45.Text = "00000000000000000000000000000000";
            this.textBox45.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox16
            // 
            this.textBox16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox16.Location = new System.Drawing.Point(151, 351);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(201, 21);
            this.textBox16.TabIndex = 96;
            this.textBox16.Text = "00000000000000000000000000000000";
            this.textBox16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox64
            // 
            this.textBox64.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox64.Location = new System.Drawing.Point(565, 327);
            this.textBox64.Name = "textBox64";
            this.textBox64.Size = new System.Drawing.Size(201, 21);
            this.textBox64.TabIndex = 95;
            this.textBox64.Text = "00000000000000000000000000000000";
            this.textBox64.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox44
            // 
            this.textBox44.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox44.Location = new System.Drawing.Point(358, 328);
            this.textBox44.Name = "textBox44";
            this.textBox44.Size = new System.Drawing.Size(201, 21);
            this.textBox44.TabIndex = 95;
            this.textBox44.Text = "00000000000000000000000000000000";
            this.textBox44.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox15
            // 
            this.textBox15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox15.Location = new System.Drawing.Point(151, 327);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(201, 21);
            this.textBox15.TabIndex = 95;
            this.textBox15.Text = "00000000000000000000000000000000";
            this.textBox15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox63
            // 
            this.textBox63.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox63.Location = new System.Drawing.Point(565, 303);
            this.textBox63.Name = "textBox63";
            this.textBox63.Size = new System.Drawing.Size(201, 21);
            this.textBox63.TabIndex = 94;
            this.textBox63.Text = "00000000000000000000000000000000";
            this.textBox63.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox43
            // 
            this.textBox43.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox43.Location = new System.Drawing.Point(358, 304);
            this.textBox43.Name = "textBox43";
            this.textBox43.Size = new System.Drawing.Size(201, 21);
            this.textBox43.TabIndex = 94;
            this.textBox43.Text = "00000000000000000000000000000000";
            this.textBox43.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox14
            // 
            this.textBox14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox14.Location = new System.Drawing.Point(151, 303);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(201, 21);
            this.textBox14.TabIndex = 94;
            this.textBox14.Text = "00000000000000000000000000000000";
            this.textBox14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox62
            // 
            this.textBox62.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox62.Location = new System.Drawing.Point(565, 279);
            this.textBox62.Name = "textBox62";
            this.textBox62.Size = new System.Drawing.Size(201, 21);
            this.textBox62.TabIndex = 93;
            this.textBox62.Text = "00000000000000000000000000000000";
            this.textBox62.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox42
            // 
            this.textBox42.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox42.Location = new System.Drawing.Point(358, 280);
            this.textBox42.Name = "textBox42";
            this.textBox42.Size = new System.Drawing.Size(201, 21);
            this.textBox42.TabIndex = 93;
            this.textBox42.Text = "00000000000000000000000000000000";
            this.textBox42.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox13
            // 
            this.textBox13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox13.Location = new System.Drawing.Point(151, 279);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(201, 21);
            this.textBox13.TabIndex = 93;
            this.textBox13.Text = "00000000000000000000000000000000";
            this.textBox13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox61
            // 
            this.textBox61.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox61.Location = new System.Drawing.Point(565, 255);
            this.textBox61.Name = "textBox61";
            this.textBox61.Size = new System.Drawing.Size(201, 21);
            this.textBox61.TabIndex = 92;
            this.textBox61.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox41
            // 
            this.textBox41.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox41.Location = new System.Drawing.Point(358, 256);
            this.textBox41.Name = "textBox41";
            this.textBox41.Size = new System.Drawing.Size(201, 21);
            this.textBox41.TabIndex = 92;
            this.textBox41.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox12
            // 
            this.textBox12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox12.Location = new System.Drawing.Point(151, 255);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(201, 21);
            this.textBox12.TabIndex = 92;
            this.textBox12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox60
            // 
            this.textBox60.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox60.Location = new System.Drawing.Point(565, 231);
            this.textBox60.Name = "textBox60";
            this.textBox60.Size = new System.Drawing.Size(201, 21);
            this.textBox60.TabIndex = 91;
            this.textBox60.Text = "PROD1";
            this.textBox60.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox40
            // 
            this.textBox40.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox40.Location = new System.Drawing.Point(358, 232);
            this.textBox40.Name = "textBox40";
            this.textBox40.Size = new System.Drawing.Size(201, 21);
            this.textBox40.TabIndex = 91;
            this.textBox40.Text = "PROD1";
            this.textBox40.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox11
            // 
            this.textBox11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox11.Location = new System.Drawing.Point(151, 231);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(201, 21);
            this.textBox11.TabIndex = 91;
            this.textBox11.Text = "PROD1";
            this.textBox11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox59
            // 
            this.textBox59.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox59.Location = new System.Drawing.Point(565, 207);
            this.textBox59.Name = "textBox59";
            this.textBox59.Size = new System.Drawing.Size(201, 21);
            this.textBox59.TabIndex = 90;
            this.textBox59.Text = "1";
            this.textBox59.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox39
            // 
            this.textBox39.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox39.Location = new System.Drawing.Point(358, 208);
            this.textBox39.Name = "textBox39";
            this.textBox39.Size = new System.Drawing.Size(201, 21);
            this.textBox39.TabIndex = 90;
            this.textBox39.Text = "1";
            this.textBox39.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox10
            // 
            this.textBox10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox10.Location = new System.Drawing.Point(151, 207);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(201, 21);
            this.textBox10.TabIndex = 90;
            this.textBox10.Text = "1";
            this.textBox10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox58
            // 
            this.textBox58.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox58.Location = new System.Drawing.Point(565, 183);
            this.textBox58.Name = "textBox58";
            this.textBox58.Size = new System.Drawing.Size(201, 21);
            this.textBox58.TabIndex = 89;
            this.textBox58.Text = "G";
            this.textBox58.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox38
            // 
            this.textBox38.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox38.Location = new System.Drawing.Point(358, 184);
            this.textBox38.Name = "textBox38";
            this.textBox38.Size = new System.Drawing.Size(201, 21);
            this.textBox38.TabIndex = 89;
            this.textBox38.Text = "G";
            this.textBox38.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox9
            // 
            this.textBox9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox9.Location = new System.Drawing.Point(151, 183);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(201, 21);
            this.textBox9.TabIndex = 89;
            this.textBox9.Text = "G";
            this.textBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox57
            // 
            this.textBox57.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox57.Location = new System.Drawing.Point(565, 159);
            this.textBox57.MaxLength = 3;
            this.textBox57.Name = "textBox57";
            this.textBox57.Size = new System.Drawing.Size(201, 21);
            this.textBox57.TabIndex = 88;
            this.textBox57.Text = "020";
            this.textBox57.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox37
            // 
            this.textBox37.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox37.Location = new System.Drawing.Point(358, 160);
            this.textBox37.MaxLength = 3;
            this.textBox37.Name = "textBox37";
            this.textBox37.Size = new System.Drawing.Size(201, 21);
            this.textBox37.TabIndex = 88;
            this.textBox37.Text = "020";
            this.textBox37.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox8
            // 
            this.textBox8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox8.Location = new System.Drawing.Point(151, 159);
            this.textBox8.MaxLength = 3;
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(201, 21);
            this.textBox8.TabIndex = 88;
            this.textBox8.Text = "020";
            this.textBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox56
            // 
            this.textBox56.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox56.Location = new System.Drawing.Point(565, 135);
            this.textBox56.MaxLength = 6;
            this.textBox56.Name = "textBox56";
            this.textBox56.Size = new System.Drawing.Size(201, 21);
            this.textBox56.TabIndex = 87;
            this.textBox56.Text = "1001";
            this.textBox56.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox36
            // 
            this.textBox36.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox36.Location = new System.Drawing.Point(358, 136);
            this.textBox36.MaxLength = 6;
            this.textBox36.Name = "textBox36";
            this.textBox36.Size = new System.Drawing.Size(201, 21);
            this.textBox36.TabIndex = 87;
            this.textBox36.Text = "1001";
            this.textBox36.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox7
            // 
            this.textBox7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox7.Location = new System.Drawing.Point(151, 135);
            this.textBox7.MaxLength = 6;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(201, 21);
            this.textBox7.TabIndex = 87;
            this.textBox7.Text = "1001";
            this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox55
            // 
            this.textBox55.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox55.Location = new System.Drawing.Point(565, 111);
            this.textBox55.Name = "textBox55";
            this.textBox55.ReadOnly = true;
            this.textBox55.Size = new System.Drawing.Size(201, 21);
            this.textBox55.TabIndex = 86;
            this.textBox55.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox35
            // 
            this.textBox35.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox35.Location = new System.Drawing.Point(358, 112);
            this.textBox35.Name = "textBox35";
            this.textBox35.ReadOnly = true;
            this.textBox35.Size = new System.Drawing.Size(201, 21);
            this.textBox35.TabIndex = 86;
            this.textBox35.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox6
            // 
            this.textBox6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.Location = new System.Drawing.Point(151, 111);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(201, 21);
            this.textBox6.TabIndex = 86;
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox54
            // 
            this.textBox54.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox54.Location = new System.Drawing.Point(565, 87);
            this.textBox54.Name = "textBox54";
            this.textBox54.Size = new System.Drawing.Size(201, 21);
            this.textBox54.TabIndex = 85;
            this.textBox54.Text = "OPERID";
            this.textBox54.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox34
            // 
            this.textBox34.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox34.Location = new System.Drawing.Point(358, 88);
            this.textBox34.Name = "textBox34";
            this.textBox34.Size = new System.Drawing.Size(201, 21);
            this.textBox34.TabIndex = 85;
            this.textBox34.Text = "OPERID";
            this.textBox34.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.Location = new System.Drawing.Point(151, 87);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(201, 21);
            this.textBox5.TabIndex = 85;
            this.textBox5.Text = "OPERID";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox53
            // 
            this.textBox53.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox53.Location = new System.Drawing.Point(565, 63);
            this.textBox53.Name = "textBox53";
            this.textBox53.Size = new System.Drawing.Size(201, 21);
            this.textBox53.TabIndex = 84;
            this.textBox53.Text = "GLASSID";
            this.textBox53.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox33
            // 
            this.textBox33.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox33.Location = new System.Drawing.Point(358, 64);
            this.textBox33.Name = "textBox33";
            this.textBox33.Size = new System.Drawing.Size(201, 21);
            this.textBox33.TabIndex = 84;
            this.textBox33.Text = "GLASSID";
            this.textBox33.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(151, 63);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(201, 21);
            this.textBox4.TabIndex = 84;
            this.textBox4.Text = "GLASSID";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox52
            // 
            this.textBox52.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox52.Location = new System.Drawing.Point(565, 39);
            this.textBox52.Name = "textBox52";
            this.textBox52.Size = new System.Drawing.Size(201, 21);
            this.textBox52.TabIndex = 83;
            this.textBox52.Text = "LOTTEST00001";
            this.textBox52.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox51
            // 
            this.textBox51.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox51.Location = new System.Drawing.Point(565, 494);
            this.textBox51.Name = "textBox51";
            this.textBox51.Size = new System.Drawing.Size(201, 21);
            this.textBox51.TabIndex = 80;
            this.textBox51.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox32
            // 
            this.textBox32.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox32.Location = new System.Drawing.Point(358, 40);
            this.textBox32.Name = "textBox32";
            this.textBox32.Size = new System.Drawing.Size(201, 21);
            this.textBox32.TabIndex = 83;
            this.textBox32.Text = "LOTTEST00001";
            this.textBox32.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox31
            // 
            this.textBox31.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox31.Location = new System.Drawing.Point(358, 495);
            this.textBox31.Name = "textBox31";
            this.textBox31.Size = new System.Drawing.Size(201, 21);
            this.textBox31.TabIndex = 80;
            this.textBox31.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox50
            // 
            this.textBox50.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox50.Location = new System.Drawing.Point(565, 474);
            this.textBox50.Name = "textBox50";
            this.textBox50.Size = new System.Drawing.Size(201, 21);
            this.textBox50.TabIndex = 81;
            this.textBox50.Text = "0";
            this.textBox50.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(151, 39);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(201, 21);
            this.textBox3.TabIndex = 83;
            this.textBox3.Text = "LOTTEST00001";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox30
            // 
            this.textBox30.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox30.Location = new System.Drawing.Point(358, 475);
            this.textBox30.Name = "textBox30";
            this.textBox30.Size = new System.Drawing.Size(201, 21);
            this.textBox30.TabIndex = 81;
            this.textBox30.Text = "0";
            this.textBox30.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox49
            // 
            this.textBox49.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox49.Location = new System.Drawing.Point(565, 450);
            this.textBox49.Name = "textBox49";
            this.textBox49.Size = new System.Drawing.Size(201, 21);
            this.textBox49.TabIndex = 82;
            this.textBox49.Text = "0";
            this.textBox49.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox28
            // 
            this.textBox28.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox28.Location = new System.Drawing.Point(151, 494);
            this.textBox28.Name = "textBox28";
            this.textBox28.Size = new System.Drawing.Size(201, 21);
            this.textBox28.TabIndex = 80;
            this.textBox28.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox29
            // 
            this.textBox29.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox29.Location = new System.Drawing.Point(358, 451);
            this.textBox29.Name = "textBox29";
            this.textBox29.Size = new System.Drawing.Size(201, 21);
            this.textBox29.TabIndex = 82;
            this.textBox29.Text = "0";
            this.textBox29.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox27
            // 
            this.textBox27.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox27.Location = new System.Drawing.Point(151, 474);
            this.textBox27.Name = "textBox27";
            this.textBox27.Size = new System.Drawing.Size(201, 21);
            this.textBox27.TabIndex = 81;
            this.textBox27.Text = "0";
            this.textBox27.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(151, 450);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(201, 21);
            this.textBox2.TabIndex = 82;
            this.textBox2.Text = "0";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label51
            // 
            this.label51.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label51.Location = new System.Drawing.Point(10, 495);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(135, 19);
            this.label51.TabIndex = 66;
            this.label51.Text = "ARRAY REPAIR RULE";
            // 
            // label50
            // 
            this.label50.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label50.Location = new System.Drawing.Point(10, 475);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(135, 19);
            this.label50.TabIndex = 65;
            this.label50.Text = "PANEL GRADE CODE";
            // 
            // label49
            // 
            this.label49.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label49.Location = new System.Drawing.Point(32, 516);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(113, 19);
            this.label49.TabIndex = 67;
            this.label49.Text = "RESERVED DATA";
            // 
            // label48
            // 
            this.label48.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label48.Location = new System.Drawing.Point(32, 451);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(113, 19);
            this.label48.TabIndex = 69;
            this.label48.Text = "DUMMY TYPE";
            // 
            // label47
            // 
            this.label47.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label47.Location = new System.Drawing.Point(32, 400);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(113, 19);
            this.label47.TabIndex = 68;
            this.label47.Text = "GLASS TYPE";
            // 
            // label46
            // 
            this.label46.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label46.Location = new System.Drawing.Point(32, 376);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(113, 19);
            this.label46.TabIndex = 61;
            this.label46.Text = "MODE";
            // 
            // label45
            // 
            this.label45.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label45.Location = new System.Drawing.Point(32, 353);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(113, 19);
            this.label45.TabIndex = 60;
            this.label45.Text = "INSPECTION FLAG";
            // 
            // label44
            // 
            this.label44.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label44.Location = new System.Drawing.Point(32, 327);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(113, 19);
            this.label44.TabIndex = 62;
            this.label44.Text = "SKIP FLAG";
            // 
            // label43
            // 
            this.label43.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label43.Location = new System.Drawing.Point(32, 303);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(113, 19);
            this.label43.TabIndex = 64;
            this.label43.Text = "JUDGE FLAG";
            // 
            // label42
            // 
            this.label42.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label42.Location = new System.Drawing.Point(32, 279);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(113, 19);
            this.label42.TabIndex = 63;
            this.label42.Text = "PROC FLAG";
            // 
            // label41
            // 
            this.label41.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label41.Location = new System.Drawing.Point(32, 256);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(113, 19);
            this.label41.TabIndex = 76;
            this.label41.Text = "CIM PC DATA";
            // 
            // label40
            // 
            this.label40.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label40.Location = new System.Drawing.Point(32, 232);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(113, 19);
            this.label40.TabIndex = 75;
            this.label40.Text = "PROD ID";
            // 
            // label39
            // 
            this.label39.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label39.Location = new System.Drawing.Point(32, 207);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(113, 19);
            this.label39.TabIndex = 77;
            this.label39.Text = "PPID";
            // 
            // label38
            // 
            this.label38.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label38.Location = new System.Drawing.Point(32, 184);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(113, 19);
            this.label38.TabIndex = 79;
            this.label38.Text = "JUDGE CODE";
            // 
            // label37
            // 
            this.label37.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label37.Location = new System.Drawing.Point(32, 161);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(113, 19);
            this.label37.TabIndex = 78;
            this.label37.Text = "ZZZ";
            // 
            // label36
            // 
            this.label36.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label36.Location = new System.Drawing.Point(32, 136);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(113, 19);
            this.label36.TabIndex = 71;
            this.label36.Text = "XXYYYY";
            // 
            // label35
            // 
            this.label35.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label35.Location = new System.Drawing.Point(32, 113);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(113, 19);
            this.label35.TabIndex = 70;
            this.label35.Text = "GLASS CODE";
            // 
            // label34
            // 
            this.label34.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label34.Location = new System.Drawing.Point(32, 89);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(113, 19);
            this.label34.TabIndex = 72;
            this.label34.Text = "OPER ID";
            // 
            // label33
            // 
            this.label33.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label33.Location = new System.Drawing.Point(32, 64);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(113, 19);
            this.label33.TabIndex = 74;
            this.label33.Text = "GLASS ID";
            // 
            // label32
            // 
            this.label32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label32.Location = new System.Drawing.Point(32, 40);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(113, 19);
            this.label32.TabIndex = 73;
            this.label32.Text = "LOT ID";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(837, 829);
            this.Controls.Add(this.tabSIMControl);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EMP Simulator";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabALL.ResumeLayout(false);
            this.tabALL.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabSIMControl.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripStatusLabel IP;
        private System.Windows.Forms.ToolStripStatusLabel PortStatus;
        private System.Windows.Forms.ToolStripStatusLabel PortNumber;
        private System.Windows.Forms.ToolStripMenuItem programeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel lblObjectUri;
        private System.Windows.Forms.ToolStripStatusLabel labelDevice;
        private System.Windows.Forms.ToolStripStatusLabel labelDataType;
        private System.Windows.Forms.Timer tmrStatusRefresh;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbHEX;
        private System.Windows.Forms.Label lbDEC;
        private System.Windows.Forms.Label lbBIN;
        private System.Windows.Forms.Button btnDeviceSetting;
        private System.Windows.Forms.Button btnScenarioMode;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox chkLogging;
        private System.Windows.Forms.Button btnStartEMSScenario;
        private System.Windows.Forms.Button btnAllScemarioStart;
        private System.Windows.Forms.Button btnAllEMPStop;
        private System.Windows.Forms.Button btnErrorStop;
        private System.Windows.Forms.TabControl tabSIMControl;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabALL;
        private System.Windows.Forms.TextBox txtScannerLog;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblRootSendComplete;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblRobotSendStart;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblRobotSendAble;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblRobotSendJobTransSignal;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label lblRobotUpstreamInline;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox textBox68;
        private System.Windows.Forms.TextBox textBox48;
        private System.Windows.Forms.TextBox textBox19;
        private System.Windows.Forms.TextBox textBox23;
        private System.Windows.Forms.TextBox textBox26;
        private System.Windows.Forms.TextBox textBox25;
        private System.Windows.Forms.TextBox textBox24;
        private System.Windows.Forms.TextBox textBox22;
        private System.Windows.Forms.TextBox textBox21;
        private System.Windows.Forms.TextBox textBox20;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox66;
        private System.Windows.Forms.TextBox textBox46;
        private System.Windows.Forms.TextBox textBox17;
        private System.Windows.Forms.TextBox textBox65;
        private System.Windows.Forms.TextBox textBox45;
        private System.Windows.Forms.TextBox textBox16;
        private System.Windows.Forms.TextBox textBox64;
        private System.Windows.Forms.TextBox textBox44;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.TextBox textBox63;
        private System.Windows.Forms.TextBox textBox43;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.TextBox textBox62;
        private System.Windows.Forms.TextBox textBox42;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.TextBox textBox61;
        private System.Windows.Forms.TextBox textBox41;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.TextBox textBox60;
        private System.Windows.Forms.TextBox textBox40;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox textBox59;
        private System.Windows.Forms.TextBox textBox39;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox58;
        private System.Windows.Forms.TextBox textBox38;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox57;
        private System.Windows.Forms.TextBox textBox37;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox56;
        private System.Windows.Forms.TextBox textBox36;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox55;
        private System.Windows.Forms.TextBox textBox35;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox54;
        private System.Windows.Forms.TextBox textBox34;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox53;
        private System.Windows.Forms.TextBox textBox33;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox52;
        private System.Windows.Forms.TextBox textBox51;
        private System.Windows.Forms.TextBox textBox32;
        private System.Windows.Forms.TextBox textBox31;
        private System.Windows.Forms.TextBox textBox50;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox30;
        private System.Windows.Forms.TextBox textBox49;
        private System.Windows.Forms.TextBox textBox28;
        private System.Windows.Forms.TextBox textBox29;
        private System.Windows.Forms.TextBox textBox27;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox textBox84;
        private System.Windows.Forms.TextBox textBox76;
        private System.Windows.Forms.TextBox textBox83;
        private System.Windows.Forms.TextBox textBox75;
        private System.Windows.Forms.TextBox textBox82;
        private System.Windows.Forms.TextBox textBox74;
        private System.Windows.Forms.TextBox textBox81;
        private System.Windows.Forms.TextBox textBox73;
        private System.Windows.Forms.TextBox textBox80;
        private System.Windows.Forms.TextBox textBox72;
        private System.Windows.Forms.TextBox textBox79;
        private System.Windows.Forms.TextBox textBox71;
        private System.Windows.Forms.TextBox textBox78;
        private System.Windows.Forms.TextBox textBox70;
        private System.Windows.Forms.TextBox textBox77;
        private System.Windows.Forms.TextBox textBox69;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.TextBox textBox85;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.TextBox textBox86;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox87;
        private System.Windows.Forms.TextBox textBox88;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.TextBox textBox91;
        private System.Windows.Forms.TextBox textBox90;
        private System.Windows.Forms.TextBox textBox89;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.TextBox textBox94;
        private System.Windows.Forms.TextBox textBox93;
        private System.Windows.Forms.TextBox textBox92;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.TextBox textBox97;
        private System.Windows.Forms.TextBox textBox96;
        private System.Windows.Forms.TextBox textBox95;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button btnGlassLoading;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.TextBox textBox18;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.Label label75;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.Label lblRobotUpstreamTrouble;
        private System.Windows.Forms.Label lblBCSentOutJobReply;
        private System.Windows.Forms.Label label80;
        private System.Windows.Forms.Label label79;
        private System.Windows.Forms.Label lblStageExchangePossible;
        private System.Windows.Forms.Label label78;
        private System.Windows.Forms.CheckBox chkExchange;
    }
}

