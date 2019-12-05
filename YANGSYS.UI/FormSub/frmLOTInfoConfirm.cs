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
    
    public partial class frmLOTInfoConfirm : FrmPopUp
    {
        public delegate void delegateEqpBuzzerOffCommand(bool value);
        public event delegateEqpBuzzerOffCommand BuzzerOffCommand = null;

        public frmLOTInfoConfirm()
        {
            InitializeComponent();
            this.pnlButtonBack.Visible = false;
        }

       
        private void btnClose_Click(object sender, EventArgs e)
        {
            Log_Converter("UI", "Close Button Click");
            this.Close();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            Log_Converter("UI", "SelectAll Button Click");
            //추가 해야 할 사항
            //?
        }        

        private void btnDeselectAll_Click(object sender, EventArgs e)
        {
            Log_Converter("UI", "DeSelectAll Button Click");
            //추가 해야 할 사항
            //?
        }

        private void btnClearAllGlass_Click(object sender, EventArgs e)
        {
            Log_Converter("UI", "ClearAllGlass Button Click");
            //추가 해야 할 사항
            //dgv glass 데이터 지움.
        }

        private void btnBuzzerOff_Click(object sender, EventArgs e)
        {
            Log_Converter("UI", "BuzzerOff Button Click");
            if (BuzzerOffCommand != null)
                BuzzerOffCommand(false);
        }

        private void btnOffline_Click(object sender, EventArgs e)
        {
            Log_Converter("UI", "Offline Button Click");
            //추가 해야 할 사항
            //Offline 명령 날림.
        }

        private void btnLotCancel_Click(object sender, EventArgs e)
        {
            Log_Converter("UI", "LotCancel Button Click");
            //추가 해야 할 사항
            //LotCancel 명령 날림.
            this.Hide();
        }

        private void btnLotConfirm_Click(object sender, EventArgs e)
        {
            Log_Converter("UI", "LotConfirm Button Click");
            //추가 해야 할 사항
            // LotConfirm 명령 날림.
        }

        private void Log_Converter(string LogType, string strMsg)
        {
            switch (LogType)
            {
                case "UI":
                    CLogManager.Instance.Log(new CUILogFormat(Catagory.Info, "", "frmLotInfoConfirm", strMsg));
                    break;
            }
        }

        private void frmLOTInfoConfirm_Load(object sender, EventArgs e)
        {
            Init_DisPlay();
        }
        private void Init_DisPlay()
        {
            lblLot_PortID.Text = "";
            lblLot_PSNo.Text = "";
            lblLot_Qty.Text = "";
            txtLot_CstID.Text = "";
            txtLot_OperID.Text = "";
            txtLot_PPID.Text = "";
            txtLotID.Text = "";
            txtLotJudge.Text = "";
            txtLotPordID.Text = "";
            txtLotSortType.Text = "";

            dgvSlotInformation.Rows.Clear();
        }
    }
}
