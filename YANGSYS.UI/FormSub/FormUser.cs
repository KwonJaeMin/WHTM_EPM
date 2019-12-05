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

using YANGSYS.UI; // CMain

namespace YANGSYS.UI
{
    public partial class FormUser : FrmPopUp
    {

        #region //event's
        public event delegateLogExceptionEvent OnLogExceptionEvent = null;
        #endregion

        #region //member's
        
        #endregion

        #region //property's
        public string UserAccount { get; set; }
        public string UserPassword { get; set; }
        #endregion

        #region //constructor's
        public FormUser()
        {
            InitializeComponent();
            this.pnlButtonBack.Visible = false;
            InitDisplay();
        }

        public FormUser(CMain main)
        {
            InitializeComponent();
            this.pnlButtonBack.Visible = false;
            InitDisplay();
            _main = main;
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

        protected override void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                bool resultID = false;
                bool resultPW = false;
                if (_main.SystemConfig.UserAccount == txtUserID.Text.Trim())
                    resultID = true;
                else
                    lblReason.Text = "USER ID가 맞지 않습니다";

                if (_main.SystemConfig.UserPassword == txtUserPW.Text.Trim())
                    resultPW = true;
                else
                    lblReason.Text = "USER PW가 맞지 않습니다";

                if (resultID && resultPW)
                {
                    DialogResult = DialogResult.OK;
                    base.btnOK_Click(sender, e);
                }
                else if (!resultID && resultPW)
                {
                    lblReason.Text = "USER ID가 맞지 않습니다";
                }
                else if (!resultPW && resultID)
                {
                    lblReason.Text = "USER PW가 맞지 않습니다";
                }
                else if (!resultID && !resultPW)
                {
                    lblReason.Text = "USER ID와 PW가 맞지 않습니다";
                }



            }
            catch (Exception ex)
            {
                if (OnLogExceptionEvent != null)
                    OnLogExceptionEvent(this, ex);
            }

        }

        private void FormUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                //KIMSHINHYO - 20121210 Memory 증가문제로 인해 이벤트 해제 추가
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
