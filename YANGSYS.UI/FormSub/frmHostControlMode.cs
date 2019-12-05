using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//using YANGSYS.UI;
using SOFD.Gui.PopUp;
using SOFD.Gui.Widget;
using SOFD.Logger;
using YANGSYS.UI.LogFormat;
//using YANGSYS.UI.Manager;

using SOFD.Gui.PopUp;

namespace YANGSYS.UI
{
    public delegate void delegateControlStateChangeRequestHandler(object sender, string controlState);
    public partial class frmHostControlMode : FrmPopUp
    {
        #region //event's
        public event delegateLogExceptionEvent OnLogExceptionEvent = null;
        public event delegateControlStateChangeRequestHandler ControlStateChangeRequest = null;
        #endregion

        #region //member's
        private Timer _timer = new Timer();
        #endregion

        #region //property's


        #endregion

        #region //constructor's

        public frmHostControlMode()
        {
            InitializeComponent();
            this.pnlButtonBack.Visible = false;
            _timer.Tick += new EventHandler(_timer_Tick);
            _timer.Interval = 500;
            OnUpdateData = new UpdateDataHandler(UpdateData);
        }

        public delegate void UpdateDataHandler(CHostCOntrolModeData hostCOntrolModeData);
        /// <summary>
        /// Null 검사 후 호출
        /// </summary>
        public UpdateDataHandler OnUpdateData = null;


        private void UpdateData(CHostCOntrolModeData hostCOntrolModeData)
        {
            UpdateDataHandler del = new UpdateDataHandler(InvokeUpdateData);
            this.Invoke(del, hostCOntrolModeData);
        }

        private void InvokeUpdateData(CHostCOntrolModeData hostCOntrolModeData)
        {
            this.lbHostModeStatus.Text = hostCOntrolModeData.CurrentMode;
        }

        public class CHostCOntrolModeData
        {
            public string CurrentMode { get; set; }
            public CHostCOntrolModeData()
            {

            }
            public CHostCOntrolModeData(string currentMode)
                : this()
            {
                this.CurrentMode = currentMode;
            }
        }

        private int count = 0;
        void _timer_Tick(object sender, EventArgs e)
        {
            if(count++ > 5)
                _timer.Stop();

            InitDisplay();
        }        
        
        #endregion

        #region //method's

        private void SetInformationDatas(HostControlModeList hostMode)
        {
            HostControlModeList hostModeStatus = hostMode;

            if (hostModeStatus.HOSTMODESTATUS == "ONLINE")
            {
                this.lbHostModeStatus.BackColor = Color.Lime;
                this.lbHostModeStatus.Text = "HOSTONLINE - REMOTE";
            }
            else if (hostModeStatus.HOSTMODESTATUS == "LOCAL")
            {
                this.lbHostModeStatus.BackColor = Color.Yellow;
                this.lbHostModeStatus.Text = "HOSTONLINE - LOCAL";
            }
            else
            {
                this.lbHostModeStatus.BackColor = Color.Red;
                this.lbHostModeStatus.Text = "HOSTONLINE - OFFLINE";
            }
        }

        private void InitDisplay()
        {            
            string[] temp = cboEqpList.Text.Split('/');

            //추가 해야할 사항
            
            //호스와의 모드 상태가 online이면
            //this.lbHostModeStatus.BackColor = Color.Lime;
            //this.lbHostModeStatus.Text = "HOSTONLINE - REMOTE";
            //호스와의 모드 상태가 LOCAL이면
            //this.lbHostModeStatus.BackColor = Color.Yellow;
            //this.lbHostModeStatus.Text = "HOSTONLINE - LOCAL";
            //호스와의 모드 상태가 offline이면
            //this.lbHostModeStatus.BackColor = Color.Red;
            //this.lbHostModeStatus.Text = "HOSTONLINE - OFFLINE";

            // if (!_main.HostManagers.ContainsKey(temp[0]))
            //{
            //    return;                
            //}


            //if (!_main.HostManagers[temp[0]].HostControlState.ContainsKey(temp[1]))
            //    _main.HostManagers[temp[0]].HostControlState.Add(temp[1], enumHostControl.Offline);

            //if (_main.HostManagers[temp[0]].HostControlState[temp[1]] == enumHostControl.Online)
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
            Invalidate();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            Log_Converter("UI", "Close Button Click");
            this.Close();
        }

        private void btnOffline_Click(object sender, EventArgs e)
        {
            //추가 해야 할 사항
            //호스트 모드 변경 확인창 띄우기
            // ok 나면 host로 변경 모드 보고      

            Log_Converter("UI", "Offline Button Click");
            //if (_ucMain.ShowCheckConfirm(cboEqpList.Text + " 호스트 모드 변경", "호스트 모드를 <OFFLINE>으로 변경합니다. 계속 진행하시겠습니까?"))

            OnControlStateChangeRequest("OFFLINE");
            
            _timer.Start();
            this.TopMost = false;
            this.Hide();
        }

        private void btnOnline_Click(object sender, EventArgs e)
        {
            //추가 해야 할 사항
            //호스트 모드 변경 확인창 띄우기
            // ok 나면 host로 변경 모드 보고

            Log_Converter("UI", "Online Button Click");
            //if (_ucMain.ShowCheckConfirm(cboEqpList.Text + " 호스트 모드 변경", "호스트 모드를 <ONLINE>으로 변경합니다. 계속 진행하시겠습니까?"))

            OnControlStateChangeRequest("ONLINE_REMOTE");

            _timer.Start();
            this.TopMost = false;
            this.Hide();                
        }

        private void OnControlStateChangeRequest(string controlState)
        {
            if (ControlStateChangeRequest != null)
                ControlStateChangeRequest(this, controlState);
        }

        private void cboEqpList_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitDisplay();
        }

        private void btnLocal_Click(object sender, EventArgs e)
        {
            //추가 해야 할 사항
            //호스트 모드 변경 확인창 띄우기
            // ok 나면 host로 변경 모드 보고

            Log_Converter("UI", "Local Button Click");
            //string[] temp = cboEqpList.Text.Split('/');
            OnControlStateChangeRequest("ONLINE_LOCAL");

            _timer.Start();
            this.TopMost = false;
            this.Hide();  
        }

        private void Log_Converter(string LogType, string strMsg)
        {
            switch (LogType)
            {
                case "UI":
                    CLogManager.Instance.Log(new CUILogFormat(Catagory.Info, "", "frmHostControlMode", strMsg));
                    break;
            }
        }
    }

    public class HostControlModeList
    {
        public string HOSTMODESTATUS { get; set; }
    }
}
