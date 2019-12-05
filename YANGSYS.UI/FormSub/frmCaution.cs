using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SOFD.Gui.PopUp;
using SOFD.Gui.Widget;

namespace YANGSYS.UI.WHTM
{
    public partial class FormCaution : FrmPopUp
    {

        #region //event's
        public event delegateLogExceptionEvent OnLogExceptionEvent = null;
        #endregion

        #region //property's
        public string Content
        {
            get
            {
                return label1.Text;
            }
        }

        #endregion

        #region //constructor's

        public FormCaution()
        {
            InitializeComponent();
            this.pnlButtonBack.Visible = false;
        }
        public FormCaution(string caution)
        {
            InitializeComponent();
            this.pnlButtonBack.Visible = false;
            InitDisplay();
            InitCaution(caution);
        }


        #endregion

        #region //method's

        private void InitDisplay()
        {
            this.OKButtonEnable = true;
            this.CancelButtonEnable = true;
            this.ButtonType = PopUpButton.OKCancel;
            this.ButtonSize = new Size(70, 25);
        }
        private void InitCaution(string caution)
        {
            label1.Text = caution;
            Invalidate();
        }

        protected override void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = DialogResult.OK;
                base.btnOK_Click(sender, e);
            }
            catch (Exception ex)
            {
                if (OnLogExceptionEvent != null)
                    OnLogExceptionEvent(this, ex);
            }

        }

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
    }
}
