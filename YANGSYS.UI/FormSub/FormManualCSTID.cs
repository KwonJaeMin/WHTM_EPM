using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SOFD.Logger;
using SOFD.InterfaceTimeout;
using SOFD.Driver;
using SOFD.Gui.PopUp;
using MainLibrary;

namespace MainProgram
{
    public partial class FormManualCSTID : FrmPopUp
    {
        public delegate void delegateCompleteManualCSTID(string CSTID, int iPortNo);
        public event delegateCompleteManualCSTID CompleteManualCSTID;
        public FormManualCSTID()
        {
            InitializeComponent();
        }

        private CMain oMain = null;
        private int iPortNO = -1;
        public FormManualCSTID(CMain _main, int _iPortNo)
        {
            InitializeComponent();
            oMain = _main;
            iPortNO = _iPortNo;
            tbCSTID.Text = "";            
            label1.Text = string.Format("Port [{0}] CST ID 읽기 실패. 수동으로 입력하세요", iPortNO.ToString());
            tbCSTID.Focus();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (oMain != null)
            {                
                oMain.ManualCSTIDEndProcess(tbCSTID.Text, iPortNO);
            }
            this.Close();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            if (iPortNO != -1)
                oMain.LotCancelRequest(iPortNO);
            this.Close();
        }
    }
}
