using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MainLibrary;
using ControlLibrary.Interface;
//using MainLibrary.Properties;
using MainLibrary.Property;

using SOFD.Logger;
using SOFD.InterfaceTimeout;
using SOFD.Driver;
using SOFD.Gui.PopUp;
using SOFD.Logger;
using MainLibrary.Utility;

namespace MainProgram
{
    public partial class FormLabelPrinter : FrmPopUp
    {

        #region //constructor's
        private CMain oMain = null;
        public FormLabelPrinter()
        {
            InitializeComponent();
        }
        public FormLabelPrinter(CMain _oMain)
        {
            InitializeComponent();
            oMain = _oMain;
        }
        #endregion



        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void FormPortInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
            this.Visible = false;
        }

        private void btnLabelTest_Click(object sender, EventArgs e)
        {
            try
            {
                //Logger.Log(Level.Info, "btnLabelTest_Click", "UI", Util.GetUILogTitle(this.Name, string.Empty));

                string strPrintData = oMain.LabelPrinterManager.GetLabelData(tbxTestHeader.Text, tbxTestBOXID.Text, tbxTestLOTID.Text, txtPartNumber.Text);

                //_ModuleProcess.PrintLabel(strPrintData, false);
                oMain.LabelPrinterManager.LabelPrint(strPrintData);

                GenerateBarCode(tbxTestLOTID.Text);

                //Logger.Log(Level.Info, Util.GetUILogValue(strPrintData), "UI", Util.GetUILogTitle(this.Name, "Label Print Test"));
            }
            catch (Exception ex)
            {
                CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "EMP", ex));
            }
        }

        private void GenerateBarCode(string strData)
        {
            try
            {
                Image lmgBarCode = MainLibrary.Utility.Code128.Code128Rendering.MakeBarcodeImage(strData, 1, true);
                picBoxBarCode.Image = lmgBarCode;
            }
            catch (Exception ex)
            {
                CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "EMP", ex));
            }
        }

        private void FormLabelPrinter_Move(object sender, EventArgs e)
        {            
            if (Owner != null)
            {
                int iWidthMax = Owner.Left + Owner.Width;
                if ((this.Left + this.Width) > iWidthMax)
                    this.Left = iWidthMax - this.Width;
                else if (Owner.Left > this.Left)
                    this.Left = Owner.Left;
                
                int iTopMax = Owner.Top + Owner.Height;
                if ((this.Top + this.Height) > iTopMax)
                    this.Top = iTopMax - this.Height;
                else if (Owner.Top > this.Top)
                    this.Top = Owner.Top;
            }
        }

        private void FormLabelPrinter_Load(object sender, EventArgs e)
        {

        }

        private void btnReload_Click(object sender, EventArgs e)
        {

        }

        public void RefresLOTCombo()
        {

        }

        private void txtLOTID_TextChanged(object sender, EventArgs e)
        {
            tbxTestLOTID.Text = txtLOTID.Text;
        }

        private void btnReconnect_Click(object sender, EventArgs e)
        {
            delegateReconnect Reconnect = new delegateReconnect(fnReconnect);
            Reconnect.BeginInvoke(null, null);
        }

        private delegate void delegateReconnect();

        private void fnReconnect()
        {
            btnReconnect.Enabled = false;
            oMain.LabelPrinterManager.ClosePort();

            System.Threading.Thread.Sleep(1000);

            oMain.LabelPrinterManager.Open();
            btnReconnect.Enabled = true;
        }
    }
}
