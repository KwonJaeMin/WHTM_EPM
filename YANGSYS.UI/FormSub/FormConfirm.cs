using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SOFD.Gui.PopUp;

//using SOFD.Gui.Window;
//using SOFD.Logger;

//using YANGSYS.UI; // CMain
//
//using YANGSYS.UI.Global;
//using YANGSYS.UI.Manager;

namespace YANGSYS.UI
{
    public partial class FormConfirm : FrmPopUp
    {
        //

        private System.Windows.Forms.Timer tmrConfirm = new Timer();
        private int valCount = 0;
        private int vTask = 0;
        private bool ChReturn = false;


        public bool CheckReturn
        {
            get { return ChReturn; }
            set { ChReturn = value; }
        }

        public void ShowForm(string title, string Msg)
        {
            this.lbTitle.Text = title;
            this.lbMessage.Text = Msg;
        }

        public FormConfirm()
        {
            InitializeComponent();
            this.pnlButtonBack.Visible = false;
            //tmrConfirm.Enabled = true;
            //tmrConfirm.Interval = 5000;
            //tmrConfirm.Tick += new EventHandler(tmrConfirm_Tick);
        }

        void tmrConfirm_Tick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            // 시간 체크하기.
            System.DateTime cTimer = new DateTime();

           // Console.WriteLine("FormConfirm.cs 시간체크");
            switch (vTask)
            {
                case 0:
                    cTimer = System.DateTime.Now;
                    this.lbvCount.Text = valCount.ToString();
                    vTask = 10;
                    break;

                case 10:
                    this.lbvCount.Text = valCount.ToString();
                    vTask = 30;
                    break;

                case 30:
                    this.tmrConfirm.Enabled = false;
                    this.ChReturn = false;
                    this.Hide();
                    this.Close();
                    vTask = 10;
                    break;

            }
        }

        //private void btnOK_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}

        //private void btnCancel_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.tmrConfirm.Enabled = false;
            this.ChReturn = false;
            this.Hide();
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.tmrConfirm.Enabled = false;
            this.ChReturn = true;
            this.Hide();
            this.Close();
        }

        private void FormConfirm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
