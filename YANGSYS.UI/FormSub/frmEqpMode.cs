using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SOFD.Global.Manager;

using SOFD.Logger;
using YANGSYS.UI.WHTM.LogFormat;
using SOFD.Global.Interface;

namespace YANGSYS.UI.WHTM.FormSub
{
    public partial class frmEqpMode : Form
    {
        public frmEqpMode()
        {
            InitializeComponent();
        }

        private void EqpModeChange(int mode)
        {
            ACommand command = CUIManager.Inst.GetCommand("MENU");
            command.SubCommandName = "EQP_MODE_CHANGE";
            command.AddParameter("EQP_MODE", mode.ToString());
            command.Execute();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Log_Convert("UI", "Close Button Click");
            this.Hide();
        }

        private void btnEnable_Click(object sender, EventArgs e)
        {
            Log_Convert("UI", "Eqp Mode Normal Mode Click");
            EqpModeChange(1);
        }

        private void btnDisable_Click(object sender, EventArgs e)
        {
            Log_Convert("UI", "Eqp Mode Cold Run Mode Click");
            EqpModeChange(13);
        }

        private void Log_Convert(string LogType, string strMsg)
        {
            switch (LogType)
            {
                case "UI":
                    CLogManager.Instance.Log(new CUILogFormat(Catagory.Info, "frmAutoRecipeMode", strMsg, ""));
                    break;
            }
        }

        private void btnForceCleanOut_Click(object sender, EventArgs e)
        {
            Log_Convert("UI", "Eqp Mode Force Clean Out Mode  Click");
            EqpModeChange(14);
        }
    }
}
