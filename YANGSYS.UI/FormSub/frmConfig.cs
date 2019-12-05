using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using SOFD.Gui.PopUp;
using SOFD.Logger;
using YANGSYS.UI.WHTM.LogFormat;
using SOFD.File;
using SOFD.Global.Manager;

using SOFD.Component;
using SOFD.Global.Interface;

namespace YANGSYS.UI.WHTM
{
    public partial class FormConfig : Form
    {
        ConfigDataList _configDataList = new ConfigDataList();
        public FormConfig()
        {
            InitializeComponent();
            Init();
        }

        #region LinkSignal
        private class CListData
        {
            public string Status { get; set; }
            public CListData()
            {
                Status = "";
            }
        }
        private CListData _messageData = new CListData();
        CUpdateHandler<CListData> UpdateMessageHandler = null;
        private delegate void UpdateHandler2();
        public bool Init()
        {
            //base.Init();
            UpdateMessageHandler = new CUpdateHandler<CListData>(this, "frmConfig", ref _messageData);
            UpdateMessageHandler.OnUpdateData = new CUpdateHandler<CListData>.UpdateDataHandler(InvokeUpdateMessageData);
            UpdateMessageHandler.Subscribe();
            return true;
        }
        private void InvokeUpdateMessageData(bool noHandle, CListData data)
        {
            if (data == null)
                return;

            _messageData = data;
            lblStatus.Text = data.Status;
        }


        private void UpdateSignal()
        {

        }
        #endregion


        public delegate void UpdateDataHandler(ConfigDataList configDataList);

        public UpdateDataHandler OnUpdateData = null;


        private void UpdateData(ConfigDataList configDataList)
        {
            UpdateDataHandler del = new UpdateDataHandler(setInformationDatas);
            this.Invoke(del, configDataList);
        }

        public void setInformationDatas(ConfigDataList configList)
        {
            ConfigDataList ConfigList = configList;

            this.txtHSMSDriver.Text = ConfigList.HSMS_HSMSDRIVERID;
            this.txtDeviceName.Text = ConfigList.HSMS_DEIVCEID;
            this.cmbIdentity.Text = ConfigList.HSMS_IDENTITY;
            this.txtSECSMode.Text = ConfigList.HSMS_SECSMODE;
            this.txtRemoteIP.Text = ConfigList.HSMS_REMOTEIP;
            this.txtRemotePort.Text = ConfigList.HSMS_REMOTEPORT;
            this.txtSEComINI.Text = ConfigList.HSMS_SECOMINI;

            this.txtT3Time.Text = ConfigList.HSMS_T3TIMEOUT;
            this.txtT5Time.Text = ConfigList.HSMS_T5TIMEOUT;
            this.txtT6Time.Text = ConfigList.HSMS_T6TIMEOUT;
            this.txtT7Time.Text = ConfigList.HSMS_T7TIMEOUT;
            this.txtT8Time.Text = ConfigList.HSMS_T8TIMEOUT;
            this.txtCTTime.Text = ConfigList.HSMS_CTTIMEOUT;
            this.txtLinkTestTime.Text = ConfigList.HSMS_LINKTESTTIMEOUT;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Log("UI", "Close Button Click");
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ConfigDataList configList = null;
            Log("UI", "Save Button Click");
            Log("UI", _configDataList.YESDRV.ToString());

            //configList.HSMS_HSMSDRIVERID = this.txtHSMSDriver.Text;
            //configList.HSMS_DEIVCEID = this.txtDeviceName.Text;
            //configList.HSMS_IDENTITY = this.cmbIdentity.Text;
            //configList.HSMS_SECSMODE = this.txtSECSMode.Text;
            //configList.HSMS_REMOTEIP = this.txtRemoteIP.Text;
            //configList.HSMS_REMOTEPORT = this.txtRemotePort.Text;
            //configList.HSMS_SECOMINI = this.txtSEComINI.Text;

            //configList.HSMS_T3TIMEOUT = this.txtT3Time.Text;
            //configList.HSMS_T5TIMEOUT = this.txtT5Time.Text;
            //configList.HSMS_T6TIMEOUT = this.txtT6Time.Text;
            //configList.HSMS_T7TIMEOUT = this.txtT7Time.Text;
            //configList.HSMS_T8TIMEOUT = this.txtT8Time.Text;
            //configList.HSMS_CTTIMEOUT = this.txtCTTime.Text;
            //configList.HSMS_LINKTESTTIMEOUT = this.txtLinkTestTime.Text;
            _configDataList.YESDRV.Mode = cbServerClient.Text;
            if (cbServerClient.Text.ToUpper() == "SERVER")
            {
                _configDataList.YESDRV.LocalIP = txtIP.Text;
                _configDataList.YESDRV.LocalPort = int.Parse(txtPort.Text);
            }
            else
            {
                _configDataList.YESDRV.RemoteIP = txtIP.Text;
                _configDataList.YESDRV.RemotePort = int.Parse(txtPort.Text);
            }
            _configDataList.Save();

            Log("UI", _configDataList.YESDRV.ToString());
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            ConfigDataList configList = null;
            Log("UI", "Default Button Click");
            setInformationDatas(configList);
            //지정해 놓은 default값을 각 구간에 넣음.
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            Log("UI", "In Button Click");
            //파일 저장 로직 띄우기.
        }

        private void Log(string LogType, string strMsg)
        {
            switch (LogType)
            {
                case "UI":
                    CLogManager.Instance.Log(new CUILogFormat(Catagory.Info, "frmConfig", strMsg, ""));
                    break;
            }        
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {
            cmbIdentity.Items.Clear();
            cmbIdentity.Items.Add("Equipment");
            cmbIdentity.Items.Add("HOST");
            cmbIdentity.SelectedIndex = 0;
            cmbHSMSMode.Items.Clear();
            cmbHSMSMode.Items.Add("Active");
            cmbHSMSMode.Items.Add("Passive");
            cmbHSMSMode.SelectedIndex = 0;

            txtHSMSDriver.Text = "";
            txtDeviceName.Text = "";
            txtSECSMode.Text = "";
            txtRemoteIP.Text = "";
            txtRemotePort.Text = "";
            txtSEComINI.Text = "";
            txtT3Time.Text = "";
            txtT5Time.Text = "";
            txtT6Time.Text = "";
            txtT7Time.Text = "";
            txtT8Time.Text = "";
            txtCTTime.Text = "";
            txtLinkTestTime.Text = "";

            txtDriverName.Text = _configDataList.YESDRV.DriverName;
            cbServerClient.Text = _configDataList.YESDRV.Mode;
            if (_configDataList.YESDRV.IsClientMode)
            {
                txtIP.Text = _configDataList.YESDRV.RemoteIP;
                txtPort.Text = _configDataList.YESDRV.RemotePort.ToString();
            }
            else
            {
                txtIP.Text = _configDataList.YESDRV.LocalIP;
                txtPort.Text = _configDataList.YESDRV.LocalPort.ToString();
            }

        }

        private void btnDrvOpen_Click(object sender, EventArgs e)
        {
            ACommand command = CUIManager.Inst.GetCommand("REQUEST");
            command.SubCommandName = "YESDRVOPEN";
            command.Execute();

        }

        private void btnDrvClose_Click(object sender, EventArgs e)
        {
            ACommand command = CUIManager.Inst.GetCommand("REQUEST");
            command.SubCommandName = "YESDRVCLOSE";
            command.Execute();
        }

        private void FormConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;

            this.Hide();
        }

        private void cbServerClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbServerClient.Text == "Server")
            {
                txtIP.Text = _configDataList.YESDRV.RemoteIP;
                txtPort.Text = _configDataList.YESDRV.RemotePort.ToString();
            }
            else
            {
                txtIP.Text = _configDataList.YESDRV.LocalIP;
                txtPort.Text = _configDataList.YESDRV.LocalPort.ToString();
            }
        }



    }

    public class ConfigDataList : ACustomPropertyContainer
    {
        public string HSMS_HSMSDRIVERID { get; set; }
        public string HSMS_DEIVCEID { get; set; }
        public string HSMS_IDENTITY { get; set; }
        public string HSMS_SECSMODE { get; set; }
        public string HSMS_REMOTEIP { get; set; }
        public string HSMS_HSMSMODE { get; set; }
        public string HSMS_REMOTEPORT { get; set; }
        public string HSMS_LOCALPORT { get; set; }
        public string HSMS_SECOMINI { get; set; }
        public string HSMS_T3TIMEOUT { get; set; }
        public string HSMS_T5TIMEOUT { get; set; }
        public string HSMS_T6TIMEOUT { get; set; }
        public string HSMS_T7TIMEOUT { get; set; }
        public string HSMS_T8TIMEOUT { get; set; }
        public string HSMS_CTTIMEOUT { get; set; }
        public string HSMS_LINKTESTTIMEOUT { get; set; }
        public ConnectionInfo YESDRV = null;
        public ConfigDataList()
        {
            string yesConnectionString = this.GetCustomProperty("YESDRV", "CONNECTION_STRING", string.Format("DriverName={0},Mode={1},RemoteIP={2},RemotePort={3},LocalIP={2},LocalPort={3}", "SIMULATOR", "Server", "127.0.0.1", 7000), "양전자 SYSTEM TCP/IP 접속");
            YESDRV = new ConnectionInfo(yesConnectionString);
        }

        public class ConnectionInfo
        {
            public string ConnectionString = "";
            public string DriverName = "";
            public string Mode = "";
            public string RemoteIP = "";
            public int RemotePort = 0;
            public string LocalIP = "";
            public int LocalPort = 0;
            public bool IsClientMode = false;
            public ConnectionInfo(string connectionString)
            {
                this.ConnectionString = connectionString;
                this.Parser();
            }

            private void Parser()
            {
                //DriverName=YANGSYS.CommDrv, Mode=Client, RemoteIP=127.0.0.1, RemotePort=5000, LocalIP=127.0.0.1, LocalPort=6000
                string[] temp = ConnectionString.Split(',');

                foreach (string item in temp)
                {
                    string[] keyValue = item.Split('=');

                    if (keyValue.Length < 2)
                    {
                        continue;
                    }
                    //DriverName,YANGSYS.CommDrv
                    switch (keyValue[0].Trim())
                    {
                        case "DriverName":
                            DriverName = keyValue[1];
                            break;
                        case "Mode":
                            Mode = keyValue[1].ToUpper();
                            IsClientMode = (Mode == "CLIENT");

                            break;
                        case "RemoteIP":
                            RemoteIP = keyValue[1];
                            break;
                        case "RemotePort":
                            RemotePort = int.Parse(keyValue[1]);
                            break;
                        case "LocalIP":
                            LocalIP = keyValue[1];
                            break;
                        case "LocalPort":
                            LocalPort = int.Parse(keyValue[1]);
                            break;
                        default:
                            break;
                    }
                }
            }

            public override string ToString()
            {
                return string.Format("DriverName={0},Mode={1},RemoteIP={2},RemotePort={3},LocalIP={4},LocalPort={5}", this.DriverName, this.Mode, this.RemoteIP, this.RemotePort, this.LocalIP, this.LocalPort);
            }
        }

        public void Save()
        {
            if(this.YESDRV != null)
                this.SetCustomProperty("YESDRV", "CONNECTION_STRING", this.YESDRV.ToString(), "양전자 SYSTEM TCP/IP 접속");
        }
    }
}
