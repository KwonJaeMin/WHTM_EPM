using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SOFD.Gui.Widget;

namespace YANGSYS.UI.WHTM
{
    public partial class ucRequestProgressBar : UserControl
    {
        public event EventHandler ButtonClick;
        public event delegateLogExceptionEvent OnLogExceptionEvent = null;
        private delegate void CrossHandler2(string message);




        public string Message1
        {
            get
            {
                return label1.Text;
            }
            set
            {
                if (InvokeRequired)
                    BeginInvoke(new CrossHandler2(SetMessage1), value);
                else
                    label1.Text = value;
            }
        }



        public string Message2
        {
            get
            {
                return label2.Text;
            }
            set
            {
                if (InvokeRequired)
                    BeginInvoke(new CrossHandler2(SetMessage2), value);
                else
                    label2.Text = value;
            }
        }

        public ucRequestProgressBar()
        {
            InitializeComponent();
        }

        private void SetMessage1(string message)
        {
            label1.Text = message;
        }

        private void SetMessage2(string message)
        {
            label2.Text = message;
        }

        private delegate void CrossHandler();

        public void Clear()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new CrossHandler(Clear));
            }
            else
            {
                label1.ForeColor = Color.DimGray;
                label2.ForeColor = Color.DimGray;
                Message1 = string.Empty;
                Message2 = string.Empty;
                progressBar1.Step = 0;
                progressBar1.Visible = true;
                buttonOk.Visible = false;
            }
        }

        public void SetButtonShow()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new CrossHandler(SetButtonShow));
            }
            else
            {
                label1.ForeColor = Color.Red;
                label2.ForeColor = Color.Red;
                buttonOk.Visible = true;
                progressBar1.Visible = false;
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                label1.ForeColor = Color.DimGray;
                label2.ForeColor = Color.DimGray;
                Message1 = string.Empty;
                Message2 = string.Empty;
                progressBar1.Step = 0;
                progressBar1.Visible = true;
                buttonOk.Visible = false;
                this.Visible = false;
                if (ButtonClick != null)
                {
                    ButtonClick(this, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                if (OnLogExceptionEvent != null)
                    OnLogExceptionEvent(this, ex);
            }
        }
    }
}
