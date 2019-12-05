using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SOFD.Gui.PopUp;

using SOFD.Gui.Window;
using SOFD.Logger;
using YANGSYS.UI.WHTM.LogFormat;

namespace YANGSYS.UI.WHTM
{
    public partial class frmConfirm : Form
    {
        private System.Windows.Forms.Timer tmrConfirm = new Timer();
        private int valCount = 0;
        private int vTask = 0;
        public bool CheckReturn { get; set; }

        public frmConfirm()
        {
            InitializeComponent();
            tmrConfirm.Tick += new EventHandler(tmrConfirm_Tick);
        }

        public void SetContent(string title, string Msg)
        {
            this.lbTitle.Text = title;
            this.lbMessage.Text = Msg;
        }

        void tmrConfirm_Tick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            // 시간 체크하기.
            System.DateTime cTimer = DateTime.Now;

            //Console.WriteLine("FormConfirm.cs 시간체크");
            switch (vTask)
            {
                case 0:
                    cTimer = System.DateTime.Now;
                    this.lbvCount.Text = valCount.ToString();
                    vTask = 20;
                    break;

                case 10:
                    this.lbvCount.Text = this.valCount.ToString();
                    //TIMEOUT CHECK
                    //If FN.Timeout(cTimer, 1) Then
                        vTask = 20;
                    //End If
                    break;

                case 20:
                    if (valCount <= 0)
                    {
                        this.tmrConfirm.Enabled = false;
                        this.CheckReturn = false;
                        this.Hide();
                        this.Close();
                    }
                    else
                    {
                        Console.WriteLine("20");
                        this.valCount--;
                        this.lbvCount.Text = this.valCount.ToString();
                        cTimer = DateTime.Now;
                        vTask = 20;
                    }

                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.tmrConfirm.Enabled = false;
            this.CheckReturn = false;
            this.Hide();

            Log_Converter("UI", "CANCEL Button Click");
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.tmrConfirm.Enabled = false;
            this.CheckReturn = true;
            this.Hide();

            Log_Converter("UI", "OK Button Click");
            this.Close();
        }

        private void frmConfirm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void frmConfirm_Load(object sender, EventArgs e)
        {
            this.CheckReturn = false;
            this.vTask = 0;
            this.valCount = 10;
            this.lbvCount.Text = valCount.ToString();
            tmrConfirm.Interval = 1000;
            tmrConfirm.Enabled = true;
        }


        private void Log_Converter(string LogType, string strMsg)
        {
            switch(LogType)
            {
                case "UI":
                    CLogManager.Instance.Log(new CUILogFormat(Catagory.Info, "frmConfirm", strMsg, ""));
                    break;
            }
        }
    }
}
