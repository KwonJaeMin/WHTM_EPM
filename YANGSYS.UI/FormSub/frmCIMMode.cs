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
    public partial class frmCIMMode : Form
    {
        public frmCIMMode()
        {
            InitializeComponent();
        }

        private void CIMModeChange(short cimMode)
        {
            ACommand command = CUIManager.Inst.GetCommand("MENU");
            command.SubCommandName = "CIM_MODE_CHANGE";
            command.AddParameter("CIM_MODE", cimMode.ToString());
            command.Execute();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Log_Convert("UI", "Close Button Click");
            this.Hide();
        }

        private void btnCIMModeOn_Click(object sender, EventArgs e)
        {
            Log_Convert("UI", "CIM Mode On Click");
            CIMModeChange(2);
            this.Hide();
        }

        private void btnCIMModeOff_Click(object sender, EventArgs e)
        {
            Log_Convert("UI", "CIM Mode Off Click");
            CIMModeChange(1);
            this.Hide();
        }

        private void Log_Convert(string LogType, string strMsg)
        {
            switch (LogType)
            {
                case "UI":
                    CLogManager.Instance.Log(new CUILogFormat(Catagory.Info, "frmCIMMode", strMsg, ""));
                    break;
            }
        }
    }
}
