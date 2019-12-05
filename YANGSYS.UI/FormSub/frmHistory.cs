using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SOFD.Logger;
using YANGSYS.UI.LogFormat;

using SOFD.Gui.PopUp;

namespace YANGSYS.UI
{
    public partial class frmHistory : FrmPopUp
    {
        public frmHistory()
        {
            InitializeComponent();
            this.pnlButtonBack.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Log_Converter("UI", "frmHistory Form is Close");
            this.Close();
        }

        private void Log_Converter(string LogType, string strMsg)
        {
            switch (LogType)
            {
                case "UI":
                    CLogManager.Instance.Log(new CUILogFormat(Catagory.Info, "", "frmHistory", strMsg));
                    break;
            }
        }
    }
}
