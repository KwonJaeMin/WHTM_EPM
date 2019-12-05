namespace YANGSYS.UI.WHTM
{
    partial class FormMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiTools = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiProgramList = new System.Windows.Forms.ToolStripMenuItem();
            this.ucMenu1 = new YANGSYS.UI.WHTM.ucMenu();
            this.ucTitle1 = new YANGSYS.UI.WHTM.ucTitle();
            this.ucMain1 = new YANGSYS.UI.WHTM.ucMain();
            this.ucLog1 = new YANGSYS.UI.WHTM.ucLog();
            this.ucLinkSignalPanel1 = new YANGSYS.UI.WHTM.ucLinkSignalPanel();
            this.ucRecipePanel1 = new YANGSYS.UI.WHTM.ucRecipePanel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiTools});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1262, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // tsmiTools
            // 
            this.tsmiTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiProgramList});
            this.tsmiTools.Name = "tsmiTools";
            this.tsmiTools.Size = new System.Drawing.Size(48, 20);
            this.tsmiTools.Text = "Tools";
            // 
            // tsmiProgramList
            // 
            this.tsmiProgramList.Name = "tsmiProgramList";
            this.tsmiProgramList.Size = new System.Drawing.Size(141, 22);
            this.tsmiProgramList.Text = "Program List";
            this.tsmiProgramList.Click += new System.EventHandler(this.tsmiProgramList_Click);
            // 
            // ucMenu1
            // 
            this.ucMenu1.BackColor = System.Drawing.SystemColors.Control;
            this.ucMenu1.ColumnIndex = 0;
            this.ucMenu1.FrameLocation = SOFD.Gui.Window.enumFrameLocation.Top;
            this.ucMenu1.FrameName = null;
            this.ucMenu1.IsStartScreen = false;
            this.ucMenu1.LayoutName = null;
            this.ucMenu1.Location = new System.Drawing.Point(1102, 49);
            this.ucMenu1.MainFrame = null;
            this.ucMenu1.Name = "ucMenu1";
            this.ucMenu1.RowIndex = 0;
            this.ucMenu1.Size = new System.Drawing.Size(159, 840);
            this.ucMenu1.TabIndex = 2;
            this.ucMenu1.OnRequestParentService += new SOFD.Gui.Window.delegateParentFormService(this.ucMenu1_OnRequestParentService);
            // 
            // ucTitle1
            // 
            this.ucTitle1.BackColor = System.Drawing.Color.Black;
            this.ucTitle1.ColumnIndex = 0;
            this.ucTitle1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucTitle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ucTitle1.FrameLocation = SOFD.Gui.Window.enumFrameLocation.Top;
            this.ucTitle1.FrameName = null;
            this.ucTitle1.IsStartScreen = false;
            this.ucTitle1.LayoutName = null;
            this.ucTitle1.Location = new System.Drawing.Point(0, 0);
            this.ucTitle1.MainFrame = null;
            this.ucTitle1.Name = "ucTitle1";
            this.ucTitle1.RowIndex = 0;
            this.ucTitle1.Size = new System.Drawing.Size(1262, 49);
            this.ucTitle1.TabIndex = 0;
            // 
            // ucMain1
            // 
            this.ucMain1.BackColor = System.Drawing.SystemColors.Control;
            this.ucMain1.ColumnIndex = 0;
            this.ucMain1.FrameLocation = SOFD.Gui.Window.enumFrameLocation.Top;
            this.ucMain1.FrameName = null;
            this.ucMain1.IsStartScreen = false;
            this.ucMain1.LayoutName = null;
            this.ucMain1.Location = new System.Drawing.Point(0, 47);
            this.ucMain1.MainFrame = null;
            this.ucMain1.MonitorPanel = null;
            this.ucMain1.Name = "ucMain1";
            this.ucMain1.RowIndex = 0;
            this.ucMain1.Size = new System.Drawing.Size(1101, 840);
            this.ucMain1.TabIndex = 9;
            // 
            // ucLog1
            // 
            this.ucLog1.AutoScroll = true;
            this.ucLog1.BackColor = System.Drawing.SystemColors.Control;
            this.ucLog1.ColumnIndex = 0;
            this.ucLog1.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.ucLog1.FrameLocation = SOFD.Gui.Window.enumFrameLocation.Top;
            this.ucLog1.FrameName = null;
            this.ucLog1.IsStartScreen = false;
            this.ucLog1.LayoutName = null;
            this.ucLog1.Location = new System.Drawing.Point(0, 48);
            this.ucLog1.MainFrame = null;
            this.ucLog1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ucLog1.Name = "ucLog1";
            this.ucLog1.Padding = new System.Windows.Forms.Padding(1);
            this.ucLog1.RowIndex = 0;
            this.ucLog1.Size = new System.Drawing.Size(1101, 840);
            this.ucLog1.TabIndex = 8;
            // 
            // ucLinkSignalPanel1
            // 
            this.ucLinkSignalPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.ucLinkSignalPanel1.Location = new System.Drawing.Point(0, 49);
            this.ucLinkSignalPanel1.Name = "ucLinkSignalPanel1";
            this.ucLinkSignalPanel1.Size = new System.Drawing.Size(1101, 840);
            this.ucLinkSignalPanel1.TabIndex = 12;
            // 
            // ucRecipePanel1
            // 
            this.ucRecipePanel1.BackColor = System.Drawing.SystemColors.Control;
            this.ucRecipePanel1.ColumnIndex = 0;
            this.ucRecipePanel1.FrameLocation = SOFD.Gui.Window.enumFrameLocation.Top;
            this.ucRecipePanel1.FrameName = null;
            this.ucRecipePanel1.IsStartScreen = false;
            this.ucRecipePanel1.LayoutName = null;
            this.ucRecipePanel1.Location = new System.Drawing.Point(0, 49);
            this.ucRecipePanel1.MainFrame = null;
            this.ucRecipePanel1.Name = "ucRecipePanel1";
            this.ucRecipePanel1.RowIndex = 0;
            this.ucRecipePanel1.Size = new System.Drawing.Size(1101, 840);
            this.ucRecipePanel1.TabIndex = 10;
            // 
            // FormMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1262, 888);
            this.ControlBox = false;
            this.Controls.Add(this.ucMenu1);
            this.Controls.Add(this.ucTitle1);
            this.Controls.Add(this.ucMain1);
            this.Controls.Add(this.ucLog1);
            this.Controls.Add(this.ucLinkSignalPanel1);
            this.Controls.Add(this.ucRecipePanel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "TIANMA PROJECT CIM";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ucTitle ucTitle1;
        private ucMenu ucMenu1;
        private ucLog ucLog1;
        private ucMain ucMain1;
        private ucRecipePanel ucRecipePanel1;
        private ucLinkSignalPanel ucLinkSignalPanel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiTools;
        private System.Windows.Forms.ToolStripMenuItem tsmiProgramList;
    }
}