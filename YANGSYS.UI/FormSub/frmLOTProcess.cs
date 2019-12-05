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
    public partial class frmLOTProcess : FrmPopUp
    {
        public frmLOTProcess()
        {
            InitializeComponent();
            this.pnlButtonBack.Visible = false;
        }

        public void setInfomationDatas(LotProcessDatasList lotProcessDatas)
        {
            LotProcessDatasList LotProcessDataList = lotProcessDatas;

            this.lblPortNo.Text = LotProcessDataList.PORTNO;
            this.lblCSTID.Text = LotProcessDataList.CSTID;
        }

        public void Display_Process()
        {
            //추가 해야 할 사항 :
            //상태에 따라 button 활성화 만들기.
            //port Number 넣기.
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            LotProcessDatasList LotProcessDataList = null;
            Log_Converter("UI", "Start Button Click");

            LotProcessDataList.LotProcessStatus = "START";
            //추가 해야 할 사항 :
            //eqp로 Start Message 전송
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LotProcessDatasList LotProcessDataList = null;
            Log_Converter("UI", "Cancel Button Click");

            LotProcessDataList.LotProcessStatus = "CANCEL";

            //추가 해야 할 사항 :
            //eqp로 Cancel Message 전송
            this.Hide();
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            LotProcessDatasList LotProcessDataList = null;
            Log_Converter("UI", "Abort Button Click");

            LotProcessDataList.LotProcessStatus = "ABORT";

            //추가 해야 할 사항 :
            //eqp로 Abort Message 전송
            this.Hide();
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
                    CLogManager.Instance.Log(new CUILogFormat(Catagory.Info, "", "frmLotProcess", strMsg));
                    break;
            }
        }
    }

    public class LotProcessDatasList
    {
        public string PORTNO { get; set; }
        public string CSTID { get; set; }
        public string LotProcessStatus { get; set; }
    }
}
