using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SOFD.Logger;
using YANGSYS.UI.WHTM.LogFormat;


using SOFD.Global.Manager;
using SOFD.Global.Interface;


namespace YANGSYS.UI.WHTM.SubForm
{
    public partial class frmExchangeMode : Form
    {
        public frmExchangeMode()
        {
            InitializeComponent();
        }

        private void ExchangeModeChange(bool exchangeMode)
        {
            ACommand command = CUIManager.Inst.GetCommand("MENU");
            command.SubCommandName = "EXCHANGE_MODE_CHANGE";
            command.AddParameter("EXCHANGE_MODE", exchangeMode.ToString());
            command.Execute();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Log_Convert("UI", "Exchange Mode Close Button Click");
            this.Hide();
        }

        private void btnCIMModeOn_Click(object sender, EventArgs e)
        {
            Log_Convert("UI", "Exchange Mode Enable Click");
            ExchangeModeChange(true);
            this.Hide();
        }

        private void btnCIMModeOff_Click(object sender, EventArgs e)
        {
            Log_Convert("UI", "Exchange Mode Disable Click");
            ExchangeModeChange(false);
            this.Hide();
        }

        private void Log_Convert(string LogType, string strMsg)
        {
            switch (LogType)
            {
                case "UI":
                    CLogManager.Instance.Log(new CUILogFormat(Catagory.Info, "frmExchangeMode", strMsg, ""));
                    break;
            }
        }
    }
}
