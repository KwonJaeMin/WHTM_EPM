using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SOFD.Logger;
using SOFD.InterfaceTimeout;
using SOFD.Gui.PopUp;

using SOFD.Global.Manager;
using SOFD.Global.Interface;

namespace YANGSYS.UI.WHTM
{
    public partial class frmScrap : FrmPopUp
    {
        public frmScrap()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                ACommand command = CUIManager.Inst.GetCommand("REQUEST");
                command.SubCommandName = "SCRAP_REPORT";
                command.AddParameter("GLASSID", TextBox3.Text);

                if (comboBox1.Text == "Whole" || comboBox1.Text == "A")
                {
                    command.AddParameter("SCRAPINDEX", "0");
                }
                else
                {
                    command.AddParameter("SCRAPINDEX", "1");
                }
                
                command.Execute();
            }
            catch
            {

            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
