using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//using YANGSYS.UI;
//
//using YANGSYS.UI.Properties;
//using YANGSYS.UI.Property;

using SOFD.Logger;
using SOFD.InterfaceTimeout;
using SOFD.Driver;
using SOFD.Gui.PopUp;
using YANGSYS.UI.LogFormat;

namespace YANGSYS.UI
{
    public partial class frmHostTerminalMessage : FrmPopUp
    {
        public delegate void delegateEqpBuzzerOffCommand(bool value);
        public event delegateEqpBuzzerOffCommand BuzzerOffCommand = null;

        #region //constructor's
        public frmHostTerminalMessage()
        {
            InitializeComponent();
            this.pnlButtonBack.Visible = false;
        }

        public frmHostTerminalMessage(string portName)
        {
            InitializeComponent();
            this.pnlButtonBack.Visible = false;
            this.FormText = portName;
            this.CloseButtonEnable = true;
            this.ButtonType = PopUpButton.Close;
            this.ButtonSize = new Size(70, 25);
        }
        #endregion

        public void Update_Host_Message()
        {
            this.lblTime.Text = DateTime.Now.ToString("yyyy:MM:dd:HH:mm:ss.fff");
            //추가 해야 할 사항
            //this.lblTid.Text = ""; //Tid에 맞는 데이터 넣기
            //this.lblHostMessage.Text = ""; HostMessage에 맞는 데이터 넣기
            //this.lblHostTitleMessage.Text = ""; HostTitleMessage에 맞는 데이터 넣기
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Log_Converter("UI", "Close Button Click");
            this.Hide();
        }

        private void btnBuzzer_Click(object sender, EventArgs e)
        {
            Log_Converter("UI", "Buzzer Off Button Click");
            if (BuzzerOffCommand != null)
                BuzzerOffCommand(false);
        }

        private void SetInformationData(HostTerminalMessageList hostTerMinalDatas)
        {
            HostTerminalMessageList HostTerMiminalData = hostTerMinalDatas;

            this.lblHostTitleMessage.Text = HostTerMiminalData.HOSTTITLE;
            this.lblTime.Text = HostTerMiminalData.HOSTLOADTIME;
            this.lblTid.Text = HostTerMiminalData.HSOTTID;
            this.lblHostMessage.Text = HostTerMiminalData.HOSTMSG;
        }

        private void Log_Converter(string LogType, string strMsg)
        {
            switch (LogType)
            {
                case "UI":
                    CLogManager.Instance.Log(new CUILogFormat(Catagory.Info, "", "frmHostTerminalMessage", strMsg));
                    break;
            }
        }
    }

    public class HostTerminalMessageList
    {
        public string HOSTTITLE { get; set; }
        public string HOSTMSG { get; set; }
        public string HOSTLOADTIME { get; set; }
        public string HSOTTID { get; set; }
    }
}
