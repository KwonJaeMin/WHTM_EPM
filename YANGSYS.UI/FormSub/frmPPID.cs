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

namespace YANGSYS.UI.SubForm
{
    public partial class frmPPID : Form
    {
        int mSelPortNo = 0;
        public frmPPID()
        {
            InitializeComponent();
        }

        public void setInformation(frmPPIDDataList ppidDataList)
        {
            frmPPIDDataList PPIDList = ppidDataList;

            cmbPPIDList.Text = PPIDList.PPIDLIST;
            lblLCTime.Text = PPIDList.LCTIME;
            lsbPPIDInfo.Text = PPIDList.PPIDINFO;
            lblSelectedPortNo.Text = PPIDList.PORTNO;
            cmbUseType.Text = PPIDList.USETYPE;
            cmbRcpNo.Text = PPIDList.RCPNO;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Log_Converter("UI", "Close Button Click");
            this.Close();
        }

        private void btnAddorModify_Click(object sender, EventArgs e)
        {
            Log_Converter("UI", "Add & Modify Button Click");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Log_Converter("UI", "Delete Button Click");
        }

        private void btnPortAdd_Click(object sender, EventArgs e)
        {
            Log_Converter("UI", "Port Add Button Click");
            if (cmbUseType.SelectedIndex == 0 || cmbUseType.Text.Trim() == "" || mSelPortNo == 0)
                return;
        }

        private void btnPortDelete_Click(object sender, EventArgs e)
        {
            Log_Converter("UI", "Port Delete Button Click");
        }

        private void btnPortAllClear_Click(object sender, EventArgs e)
        {
            Log_Converter("UI", "Port All Clear Button Click");
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            Log_Converter("UI", "Test Button Click");
        }

        private void btnSetCurrentPPID_Click(object sender, EventArgs e)
        {
            Log_Converter("UI", "SetCurrent PPID Button Click");
        }

        private void btnGetEqpPPIDList_Click(object sender, EventArgs e)
        {
            Log_Converter("UI", "SetCurrent PPID Button Click");

            for (int i = 0; i < 10; i++)
            {
                cmbPPIDList.Items.Add("");
            }
        }

        private void Log_Converter(string LogType, string strMsg)
        {
            switch (LogType)
            {
                case "UI":
                    CLogManager.Instance.Log(new CUILogFormat(Catagory.Info, "", "frmPPID", strMsg));
                    break;
            }
        }
    }

    public class frmPPIDDataList
    {
        public string PPIDLIST { get; set; }
        public string LCTIME { get; set; }
        public string PPIDINFO { get; set; }
        public string PORTNO { get; set; }
        public string USETYPE { get; set; }
        public string RCPNO { get; set; }

    }
}
