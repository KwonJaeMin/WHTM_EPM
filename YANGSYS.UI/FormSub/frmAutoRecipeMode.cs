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
    public partial class frmAutoRecipeMode : Form
    {
        public frmAutoRecipeMode()
        {
            InitializeComponent();
        }

        private void AutoRecipeModeChange(bool enable)
        {
            ACommand command = CUIManager.Inst.GetCommand("MENU");
            command.SubCommandName = "AUTO_RECIPE_CHANGE";
            command.AddParameter("AUTO_RECIPE_CHANGE", enable.ToString());
            command.Execute();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Log_Convert("UI", "Close Button Click");
            this.Hide();
        }

        private void btnEnable_Click(object sender, EventArgs e)
        {
            Log_Convert("UI", "Auto Recipe Change Enable Click");
            AutoRecipeModeChange(true);
            this.Hide();
        }

        private void btnDisable_Click(object sender, EventArgs e)
        {
            Log_Convert("UI", "Auto Recipe Change Disable Click");
            AutoRecipeModeChange(false);
            this.Hide();
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
    }
}
