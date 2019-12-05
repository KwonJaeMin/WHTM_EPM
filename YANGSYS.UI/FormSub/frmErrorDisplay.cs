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
using SOFD.Logger;
using YANGSYS.UI.WHTM.LogFormat;

namespace YANGSYS.UI.WHTM
{
    public partial class FormErrorDisplay : FrmPopUp
    {


        private int NormalWidth = 817;
       // private int NormalLabelSize = 787;
        private int SimpleWidth = 545;
        //private int NormalHeight = 435;

        #region //event's
        //public event delegateLogExceptionEvent OnLogExceptionEvent = null;
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

        public FormErrorDisplay()
        {
            InitializeComponent();
            this.pnlButtonBack.Visible = false;
        }
        #endregion

        #region //method's


        #endregion

        public bool ForceClose = false;

        private void btnCLOSE_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        public void AddData(string Title, string Content)
        {
            label1.Text = Content;
            Invalidate();

            dgvErrorItem.Rows.Add();
            DataGridViewRow oRow = dgvErrorItem.Rows[dgvErrorItem.Rows.Count - 1];

            oRow.Cells["colNo"].Value = dgvErrorItem.Rows.Count.ToString();
            oRow.Cells["colMessage"].Value = Content;
            oRow.Cells["colOccuredPosition"].Value = Title;
            oRow.Cells["colErrorRegTime"].Value = DateTime.Now.ToString();

            CLogManager.Instance.Log(new CUILogFormat(Catagory.Info, "frmErrorDisplay", Content, ""));
        }

        private void btnAllClear_Click(object sender, EventArgs e)
        {
            dgvErrorItem.Rows.Clear();
        }

        private void FormErrorDisplay_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ForceClose)
                e.Cancel = true;
        }

        private void chkSimpleView_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSimpleView.Checked)
            {
                dgvErrorItem.Columns["colOccuredPosition"].Visible = false;
                this.Width = SimpleWidth;
            }
            else
            {
                dgvErrorItem.Columns["colOccuredPosition"].Visible = true;
                this.Width = NormalWidth;
            }
        }
    }
}
