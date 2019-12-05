using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using YANGSYS.UI;
using SOFD.Gui.PopUp;
using SOFD.Gui.Widget;

namespace YANGSYS.UI
{
    public partial class FormNotify : FrmPopUp
    {
       #region //event's
        public event delegateLogExceptionEvent OnLogExceptionEvent = null;
        #endregion

        #region //member's

        #endregion

        #region //property's


        #endregion

        #region //constructor's

        public FormNotify()
        {
            InitializeComponent();
            this.pnlButtonBack.Visible = false;
        }
        public FormNotify(CMain main)
        {
            _main = main;
            InitializeComponent();
            this.pnlButtonBack.Visible = false;
            InitDisplay();
            //InitCaution(caution);
        }
        
        
        #endregion

        #region //method's

        private void InitDisplay()
        {
        }
        private void InitCaution(string caution)
        {
            //label1.Text = caution;
            Invalidate();
        }

        //protected override void btnOK_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        DialogResult = DialogResult.OK;
        //        base.btnOK_Click(sender, e);
        //    }
        //    catch (Exception ex)
        //    {
        //        if (OnLogExceptionEvent != null)
        //            OnLogExceptionEvent(this, ex);
        //    }
           
        //}

        private void FormCaution_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                for (int i = 0; i < this.Controls.Count; i++)
                {
                    this.Controls.Remove(this.Controls[i]);
                }
            }
            catch (Exception ex)
            {
                if (OnLogExceptionEvent != null)
                    OnLogExceptionEvent(this, ex);
            }
        }
        #endregion

        private void btnBuzzOff_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ShowForm(string title, string Msg)
        {
            this.lbTitle.Text = title;
            this.lbMessage.Text = Msg;

        }

    }
}
