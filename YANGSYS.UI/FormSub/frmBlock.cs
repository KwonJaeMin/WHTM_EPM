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

using SOFD.Gui.PopUp;

namespace YANGSYS.UI
{
    public partial class frmBlock : FrmPopUp
    {
        public event EventHandler Release = null;
        public frmBlock()
        {
            InitializeComponent();
            this.pnlButtonBack.Visible = false;
        }

        private void FormBlock_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0; 
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;

            label1.Top = 0;
            label1.Left = 0; 
            label1.Width = Screen.PrimaryScreen.WorkingArea.Width;
            label1.Height = Screen.PrimaryScreen.WorkingArea.Height;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // 종료 비번 창 띄움.
            // 종료 비번 넣고 맞을 경우만 창 닫기.

            if (Release != null)
                Release(this, e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Log_Converter("UI", "Close Button Click");
            this.Hide();
        }

        private void Log_Converter(string LogType, string strMsg)
        {
            switch (LogType)
            {
                case "UI":
                    CLogManager.Instance.Log(new CUILogFormat(Catagory.Info, "", "frmBlock", strMsg));
                    break;
            }
        }
    }
}
