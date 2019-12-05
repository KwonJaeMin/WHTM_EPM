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
    public partial class frmHostMessage : FrmPopUp
    {
        public frmHostMessage()
        {
            InitializeComponent();
            this.pnlButtonBack.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Log_Converter("UI", "Close Button Click");
            this.Close();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Log_Converter("UI", "Send Button Click");
            if (this.txtSendMessage.Text != "")
            {
                //추가 해야 할 사항
                //msg 전송
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Log_Converter("UI", "Clear Button Click");
            this.txtSendMessage.Text = "";
        }

        private void Log_Converter(string LogType, string strMsg)
        {
            switch (LogType)
            {
                case "UI":
                    CLogManager.Instance.Log(new CUILogFormat(Catagory.Info, "", "frmHostMessage", strMsg));
                    break;
            }
        }
    }
}
