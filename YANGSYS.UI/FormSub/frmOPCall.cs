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
    public partial class frmOPCall : FrmPopUp
    {
        public delegate void delegateEqpBuzzerOffCommand(bool BuzzerCommand);
        public event delegateEqpBuzzerOffCommand BuzzerOffCommand = null;
        public frmOPCall()
        {
            InitializeComponent();
            this.pnlButtonBack.Visible = false;
        }

        //public void ShowForm(string Title, string Message, string PTID, string OPCallID)
        //{
        //    this.lblTitle.Text = Title;
        //    this.lblMessage.Text = Message;
        //    this.lblPTID.Text = PTID;
        //    this.lblOPCallID.Text = OPCallID;

        //    //추가 해야 할 사항.
        //    //EQP로 Buzzer On 명령 날림.
        //    //SignalTower 색상 조정
        //}

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Log_Converter("UI", "Confirm Button Click");
            this.Hide();
        }

        private void btnBuzzerOff_Click(object sender, EventArgs e)
        {
            Log_Converter("UI", "BUZZER OFF Button Click");
            //추가 해야 할 사항
            if (BuzzerOffCommand != null)
                BuzzerOffCommand(false);
        }

        private void Log_Converter(string LogType, string strMsg)
        {
            switch (LogType)
            {
                case "UI":
                    CLogManager.Instance.Log(new CUILogFormat(Catagory.Info, "", "frmNotify", strMsg));
                    break;
            }
        }

        public void setInformationDatas(OPCallDataList opCallDataList)
        {
            OPCallDataList OPCallDataList = opCallDataList;

            lblTitle.Text = OPCallDataList.OpCallTitle;
            lblMessage.Text = OPCallDataList.OpCallMsg;
            lblPTID.Text = OPCallDataList.OpCallPTID;
            lblOPCallID.Text = OPCallDataList.OpCallID;
        }
    }

    public class OPCallDataList
    {
        public string OpCallTitle { get; set; }
        public string OpCallMsg { get; set; }
        public string OpCallPTID { get; set; }
        public string OpCallID { get; set; }
    }
}
