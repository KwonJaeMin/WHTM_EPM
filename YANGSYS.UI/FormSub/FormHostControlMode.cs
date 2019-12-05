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
using YANGSYS.UI.Manager;

namespace YANGSYS.UI
{
    public partial class FormHostControlMode : FrmPopUp
    {
        #region //event's
        public event delegateLogExceptionEvent OnLogExceptionEvent = null;
        #endregion

        #region //member's
        private ucMain _ucMain = null;

        #endregion

        #region //property's


        #endregion

        #region //constructor's

        public FormHostControlMode()
        {
            InitializeComponent();
            this.pnlButtonBack.Visible = false;
        }
        public FormHostControlMode(CMain main)
        {
            _main = main;
            InitializeComponent();
            this.pnlButtonBack.Visible = false;
            InitDisplay();
            //InitCaution(caution);
        }

        public FormHostControlMode(ucMain ucMain, CMain main)
        {
            _main = main;
            _ucMain = ucMain;
            InitializeComponent();
            this.pnlButtonBack.Visible = false;
            InitDisplay();
            //InitCaution(caution);
        }
        
        
        #endregion

        #region //method's

        private void InitDisplay()
        {
            //this.OKButtonEnable = false;
            //this.CancelButtonEnable = true;           
            //this.ButtonType = PopUpButton.Close;
            //this.ButtonSize = new Size(70, 25);
            //if (_main.HostManager.HostControlState == enumHostControl.Online)
            //{
            //    this.lbHostModeStatus.BackColor = Color.Lime;
            //    this.lbHostModeStatus.Text = "온라인";
            //}
            //else
            //{
            //    this.lbHostModeStatus.BackColor = Color.Red;
            //    this.lbHostModeStatus.Text = "오프라인";

            //}
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOffline_Click(object sender, EventArgs e)
        {
            //if (_main.Hsms.HostConnect == enumHostConnect.Connect)
           // {
            if (_ucMain.ShowCheckConfirm("호스트 모드 변경", "호스트 모드를 <OFFLINE>으로 변경합니다. 계속 진행하시겠습니까?"))
            {
                //_main.Hsms.HostControl = enumHostControl.Offline;
                //_main.CheckHostControlMode(enumHostControl.Offline);
                //_main.RemoteStateChangeRequest(enumHostControl.Offline);
                this.TopMost = false;
                this.Hide();
            }

           // }
        }

        private void btnOnline_Click(object sender, EventArgs e)
        {

            //if (_main.HostManager.HostConnect == enumHostConnect.Connect)
            //{
                if (_ucMain.ShowCheckConfirm("호스트 모드 변경", "호스트 모드를 <ONLINE>으로 변경합니다. 계속 진행하시겠습니까?"))
                {
                    //_main.Hsms.HostControl = enumHostControl.Online;
                    //_main.CheckHostControlMode(enumHostControl.Online);
                    //_main.RemoteStateChangeRequest(enumHostControl.Online);
                    this.TopMost = false;
                    this.Hide();
                }
                
            //}
        //            cManageLog.UpdateLog(clsManageLog.POS_LIST.POS_BTN, clsManageLog.CAT_LIST.CAT_SYS, clsManageLog.PORT_LIST.PORT_NONE, clsManageLog.DIR_LIST.DIR_RCV, "<호스트모드><온라인>")
        //If cManageHSMS.HostConnect <> SEOJINIT.LIB.HSMS.clsHSMS.HOST_CONNECT_LIST.HOST_CONNECT_OK Then Exit Sub
        //If cManageHSMS.HostControl <> SEOJINIT.LIB.HSMS.clsHSMS.HOST_CONTROL_LIST.HOST_CONTROL_OFF Then Exit Sub

        //If cFunctions.ShowCheckConfirm("호스트 모드 변경", "호스트 모드를 <ONLINE>으로 변경합니다. 계속 진행하시겠습니까?") Then
        //    RaiseEvent evBtnClick(CLICK_LIST.CLICK_ONLINE)
        //    Me.TopMost = False
        //    Me.Hide()
        //End If

        }

    }
}
