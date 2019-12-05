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

namespace YANGSYS.UI.WHTM.SubForm
{
    public partial class frmVCRMode : Form
    {
        public frmVCRMode()
        {
            InitializeComponent();
        }

        public void frmVCRMode_Form(int vEQPNo, int vVCRMode)
        {
            Label3.Text = "CURRENT VCR MODE";
            Label2.Text = "PS #" + vEQPNo.ToString() + " VCR MODE CHANGE";
            switch (vVCRMode)
            {
                case 10:
                    lblCurrentVCRMode.Text = "VCR ON(ERROR-SKIP)";
                    lblCurrentVCRMode.BackColor = Color.Lime;
                    break;

                case 20:
                    lblCurrentVCRMode.Text = "VCR ON(ERROR-KEY IN)";
                    lblCurrentVCRMode.BackColor = Color.Yellow;
                    break;

                case 30:
                    lblCurrentVCRMode.Text = "VCR OFF(ERROR-SKIP)";
                    lblCurrentVCRMode.BackColor = Color.Red;
                    break;
            }
        }

        private void VCRModeChange(short vVCRMode)
        {
            //추가 해야 할 사항
            //word VCRUnitMode = vVCRMode
            //Bit VCRModeChange = true;
            //Log
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Log_Convert("UI", "Close Button Click");
            this.Hide();
        }

        private void btnVcrOnErrSkip_Click(object sender, EventArgs e)
        {
            Log_Convert("UI", "VCROnErrorSkip Button Click");
            //추가 해야 할 사항
            //VCRModeChange()로 던짐.
            this.Hide();
        }

        private void btnVCROnErrKeyIn_Click(object sender, EventArgs e)
        {
            Log_Convert("UI", "VCROnErrorKeyIn Button Click");
            //추가 해야 할 사항
            //VCRModeChange()로 던짐.
            this.Hide();
        }

        private void btnVCROffErrSkip_Click(object sender, EventArgs e)
        {
            Log_Convert("UI", "VCROffErrorSkip Button Click");
            //추가 해야 할 사항
            //VCRModeChange()로 던짐.
            this.Hide();
        }

        private void Log_Convert(string LogType, string strMsg)
        {
            switch (LogType)
            {
                case "UI":
                    CLogManager.Instance.Log(new CUILogFormat(Catagory.Info, "frmVCRMode", strMsg, ""));
                    break;
            }
        }
    }
}
