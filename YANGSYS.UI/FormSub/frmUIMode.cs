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
    public partial class frmUIMode : Form
    {
        public frmUIMode()
        {
            InitializeComponent();
        }

        public string newPassWord { get; set; }
        public string prevPassWord { get; set; }
        public bool UIMode { get; set; }

        public void Display_Form(int vCIMOPMode)
        {
            switch (vCIMOPMode.ToString())
            {
                case "0":
                    lblCurrentMode.Text = "OPERATOR";
                    lblCurrentMode.ForeColor = Color.Black;
                    lblCurrentMode.BackColor = Color.Lime;
                    txtPassword.Enabled = false;
                    btnOK.Enabled = false;
                    break;

                case "1":
                    lblCurrentMode.Text = "ADMINISTRATOR";
                    lblCurrentMode.ForeColor = Color.Red;
                    lblCurrentMode.BackColor = Color.White;
                    txtPassword.Enabled = true;
                    btnOK.Enabled = true;
                    break;
            }
        }
        public void Display_Form(string vCIMOPMode, string vCIMPassWord)
        {
            switch (vCIMOPMode)
            {
                case "OPERATOR":
                    lblCurrentMode.Text = "OPERATOR";
                    lblCurrentMode.ForeColor = Color.Black;
                    lblCurrentMode.BackColor = Color.Lime;
                    txtPassword.Enabled = false;
                    btnOK.Enabled = false;
                    prevPassWord = vCIMPassWord;
                    break;

                case "admin":
                    lblCurrentMode.Text = "ADMINISTRATOR";
                    lblCurrentMode.ForeColor = Color.Red;
                    lblCurrentMode.BackColor = Color.White;
                    txtPassword.Enabled = true;
                    btnOK.Enabled = true;
                    prevPassWord = vCIMPassWord;
                    break;
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Log_Convert("UI", "Close Button Click");
            this.Hide();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Log_Convert("UI", "OK Button Click");
            switch (cmbOperator.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    if (newPassWord == prevPassWord)
                    {
                        UIMode = true;
                        prevPassWord = newPassWord;
                        //Todo:
                        //저장소에 저장해야함.
                    }
                    else
                    {
                        frmConfirm confirm = new frmConfirm();
                        if (string.IsNullOrEmpty(newPassWord))
                        {
                            confirm.SetContent("UI Mode", "PASSWORD INPUT PLEASE");
                        }
                        else
                        {
                            confirm.SetContent("UI Mode", "PASSWORD NOT MATCHED");
                        }
                        confirm.ShowDialog(this);                        
                        
                        UIMode = false;
                    }
                    break;
            }
            this.Hide();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            Log_Convert("UI", "IN Button Click");
            if (txtPassword.Text != "")
            {
                newPassWord = txtPassword.Text;
            }
            else
            {
                frmConfirm confirm = new frmConfirm();
                confirm.SetContent("UI Mode", "PASSWORD DATA INPUT PLEASE");
                confirm.ShowDialog(this);
            }
        }

        private void frmUIMode_Load(object sender, EventArgs e)
        {
            cmbOperator.Items.Clear();
            cmbOperator.Items.Add("OPERATOR");
            cmbOperator.Items.Add("ADMINISTRATOR");
            txtPassword.Text = "";
            //prevPassWord = "1"; //ToDo : 저장소에서 가져와야함.
            UIMode = false;
        }

        private void cmbOperator_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cmb = sender as ComboBox;

            switch (cmb.SelectedIndex)
            {
                case 0:
                    txtPassword.Text = "";
                    txtPassword.Enabled = false;
                    btnOK.Enabled = false;
                    break;
                case 1:
                    txtPassword.Enabled = true;
                    btnOK.Enabled = true;
                    break;
            }
        }

        private void Log_Convert(string LogType, string strMsg)
        {
            switch (LogType)
            {
                case "UI":
                    CLogManager.Instance.Log(new CUILogFormat(Catagory.Info, "frmAlarmDisplay", strMsg, ""));
                    break;
            }
        }
    }
}
