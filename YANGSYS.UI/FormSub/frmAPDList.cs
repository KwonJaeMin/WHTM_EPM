using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//using MainLibrary;
//
//using MainLibrary.Properties;
//using MainLibrary.Property;

using SOFD.Logger;
//using SOFD.InterfaceTimeout;
//using SOFD.Driver;
using SOFD.Gui.PopUp;

namespace MainProgram
{
    public partial class frmAPDList : FrmPopUp
    {
        public frmAPDList()
        {
            InitializeComponent();
            this.pnlButtonBack.Visible = false;
        }
        public frmAPDList(string portName)
        {
            InitializeComponent();
            this.pnlButtonBack.Visible = false;
            this.FormText = portName;
            this.CloseButtonEnable = true;
            this.ButtonType = PopUpButton.Close;
            this.ButtonSize = new Size(70, 25);
        }

        private void btnUnitA_Click(object sender, EventArgs e)
        {
            this.btnUnitA.ForeColor = Color.DarkGray;
            this.btnUnitB.ForeColor = Color.Transparent;
            this.btnUnitC.ForeColor = Color.Transparent;
        }

        private void btnUnitB_Click(object sender, EventArgs e)
        {
            this.btnUnitA.ForeColor = Color.Transparent;
            this.btnUnitB.ForeColor = Color.DarkGray;
            this.btnUnitC.ForeColor = Color.Transparent;
        }

        private void bunUnitC_Click(object sender, EventArgs e)
        {
            this.btnUnitA.ForeColor = Color.Transparent;
            this.btnUnitB.ForeColor = Color.Transparent;
            this.btnUnitC.ForeColor = Color.DarkGray;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Log("frmAPDList Form is Close");
            this.Close();
        }

        private void Log(string strMsg)
        {
            //Log 남김.
        }
    }
}
