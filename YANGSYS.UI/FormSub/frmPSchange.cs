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
using YANGSYS.UI;

namespace YANGSYS.UI.SubForm
{
    public partial class frmPSchange : Form
    {
        public frmPSchange()
        {
            InitializeComponent();
        }

        public void setInformation(frmPSChangeDataList psChangeDataList)
        {
            frmPSChangeDataList PSChangeList = psChangeDataList;

            txtCurrentMode.Text = PSChangeList.CurrentMode;
            txtCurrentPassword.Text = PSChangeList.CurrentPassword;
            txtNewPassword.Text = PSChangeList.NewPassword;
            txtConfirmPassword.Text = PSChangeList.ConfirmPassword;
        }

        public void frmPSchange_Load(object sender, EventArgs e)
        {
            this.txtCurrentMode.Text = "";
            this.txtCurrentPassword.Text = "";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Log_Convert("UI", "Close Button Click");
            this.Close();
        }

        private void Log_Convert(string LogType, string strMsg)
        {
            switch (LogType)
            {
                case "UI":
                    CLogManager.Instance.Log(new CUILogFormat(Catagory.Info, "", "frmOvenDataEdit", strMsg));
                    break;
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            frmPSChangeDataList PSChangeList = null;
            frmConfirm frmCheck = new frmConfirm();
            if (txtNewPassword.Text != "")
            {
                if (txtNewPassword.Text == txtConfirmPassword.Text)
                {
                    frmCheck.SetContents("CHANGE PASSWORD DATA", "ARE YOU CHANGE PASSWORD");
                    frmCheck.ShowDialog(this);

                    if (frmCheck.RetValue)
                    {
                        PSChangeList.CurrentMode = "Administrator";
                        PSChangeList.CurrentPassword = txtNewPassword.Text;

                        this.txtNewPassword.Text = "";
                        this.txtConfirmPassword.Text = "";
                        this.Hide();
                    }
                    else
                    {
                        this.txtNewPassword.Text = "";
                        this.txtConfirmPassword.Text = "";
                        this.Hide();
                    }
                }
                else
                {
                    Console.WriteLine("Not Password");
                    this.txtNewPassword.Text = "";
                    this.txtConfirmPassword.Text = "";
                }
            }
        }
    }

    public class frmPSChangeDataList
    {
        public string CurrentMode { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
