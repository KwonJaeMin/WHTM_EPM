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

namespace YANGSYS.UI.SubForm
{
    public partial class frmRBTRetry : Form
    {
        public delegate void delegateEqpBuzzerOffCommand(bool value);
        public event delegateEqpBuzzerOffCommand BuzzerOffCommand = null;

        public frmRBTRetry()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Log("Close Button Click");
            this.Close();
        }

        private void btnRetry_Click(object sender, EventArgs e)
        {
            Log("Close Button Click");
            //추가 해야 할 사항
            //EQP에 재시도 명령 날림.
        }

        private void btnRobotReset_Click(object sender, EventArgs e)
        {
            Log("Close Button Click");
            //추가 해야 할 사항
            //EQP에 Robot 초기화 명령 날림
        }

        private void btnBuzzerOff_Click(object sender, EventArgs e)
        {
            Log("Close Button Click");
            if (BuzzerOffCommand != null)
                BuzzerOffCommand(false);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Log("Close Button Click");
           
            if (BuzzerOffCommand != null)
                BuzzerOffCommand(false);
            //추가 해야 할 사항
            //EQP에 Cancel명령 날림.
        }

        private void Log(string strMsg)
        {
            CLogManager.Instance.Log(new CUILogFormat(Catagory.Info, "", "frmRBTRetry", strMsg));
        }
    }
}
