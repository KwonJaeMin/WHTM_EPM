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
    public partial class frmRBTConfirm : Form
    {
        public frmRBTConfirm()
        {
            InitializeComponent();
        }

        private void setInfromation(frmRBTConfirmList frmrBTConfirmList)
        {
            frmRBTConfirmList RBTConfrimList = frmrBTConfirmList;

            lblCommand.Text = RBTConfrimList.COMMAND;
            lblPortNo.Text = RBTConfrimList.PORTNO;
            lblRBTHand.Text = RBTConfrimList.RBTHAND;
            lblSlotNo.Text = RBTConfrimList.SLOTNO;
            lblTarget.Text = RBTConfrimList.TARGET;
            lblComment.Text = RBTConfrimList.COMMENT;
        }


        public void Show_frmRbtConfirm(string vCommand, string vUnitNo, string vPortNo, string vSlotNo, short vHandNo)
        {
            this.lblCommand.Text = vCommand;

            switch (vUnitNo)
            {
                case "1":
                    lblTarget.Text = " CASSETTE";
                    lblPortNo.Text = " " + vPortNo;
                    break;
                case "2":
                    lblTarget.Text = " ALIGN";
                    lblPortNo.Text = " " + vPortNo;
                    break;
                case "3":
                    lblTarget.Text = " BUFFER";
                    lblPortNo.Text = " " + vPortNo;
                    break;
                case "4":
                    lblTarget.Text = " OVEN";
                    lblPortNo.Text = " " + vPortNo;
                    break;
                case "5":
                    lblTarget.Text = " COOLINGBUFFER";
                    lblPortNo.Text = " " + vPortNo;
                    break;
            }

            lblSlotNo.Text = " " + vSlotNo;

            switch (vHandNo)
            {
                case 0:
                    lblRBTHand.Text = " UPER HAND";
                    break;
                case 1:
                    lblRBTHand.Text = " LOWER HAND";
                    break;
                case 2:
                    lblRBTHand.Text = " ALL HAND";
                    break;

                default:
                    lblRBTHand.Text = "";
                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Log_Convert("UI", "Cancel Button Click");
            this.Hide();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Log_Convert("UI", "OK Button Click");
            this.Hide();
        }

        private void Log_Convert(string LogType, string strMsg)
        {
            switch (LogType)
            {
                case "UI":
                    CLogManager.Instance.Log(new CUILogFormat(Catagory.Info, "", "frmRBTConfirm", strMsg));
                    break;
            }
        }
    }

    public class frmRBTConfirmList
    {
        public string COMMAND { get; set; }
        public string TARGET { get; set; }
        public string PORTNO { get; set; }
        public string SLOTNO { get; set; }
        public string RBTHAND { get; set; }
        public string COMMENT { get; set; }
    }
}
