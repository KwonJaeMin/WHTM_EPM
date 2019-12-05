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
    public partial class frmOVENInfo : FrmPopUp
    {
        public frmOVENInfo()
        {
            InitializeComponent();
            this.pnlButtonBack.Visible = false;
        }

        public void setInformationDatas(OvenInfoDataList ovenInfoDataList)
        {
            OvenInfoDataList OvenInfoList = ovenInfoDataList;

            for (int i = 0; i < 10; i++)
            {
                dgvSlotInformation.Rows[i].Cells[0].Value = OvenInfoList.SLOT_GLSID;
                dgvSlotInformation.Rows[i].Cells[1].Value = OvenInfoList.SLOT_FROMPORTID;
                dgvSlotInformation.Rows[i].Cells[2].Value = OvenInfoList.SLOT_FROMCSTID;
                dgvSlotInformation.Rows[i].Cells[3].Value = OvenInfoList.SLOT_FROMSLOTID;
                dgvSlotInformation.Rows[i].Cells[4].Value = OvenInfoList.SLOT_PPID;
                dgvSlotInformation.Rows[i].Cells[5].Value = OvenInfoList.SLOT_GLSJUDGE;
                dgvSlotInformation.Rows[i].Cells[6].Value = OvenInfoList.SLOT_GLSSORTTYPE;
                dgvSlotInformation.Rows[i].Cells[7].Value = OvenInfoList.SLOT_SMPLFLAG;
                dgvSlotInformation.Rows[i].Cells[8].Value = OvenInfoList.SLOT_RWKCNT;
            }
            this.cmbEqpNo.Text = OvenInfoList.Lot_EQPID;
            this.lblOvenID.Text = OvenInfoList.Lot_OVNEID;
            this.lblLoadTime.Text = OvenInfoList.Lot_LOADTIME;
            this.lblQty.Text = OvenInfoList.Lot_QTY;
        }

        private void dgvClickEvent()
        {
            foreach (DataGridViewRow dgvViewRow in dgvSlotInformation.SelectedRows)
            {
                //추가 해야 할 사항
                //dgv데이터를 frmbufferdataedit로 넘김
                //lblGlsPnlJudge.text, lblGlsPnlJudge.Text의 값을 넣어야함.

                frmBufferDataEdit frmBufferDataEdit = new frmBufferDataEdit();
                frmBufferDataEdit.TopMost = true;
                frmBufferDataEdit.ShowDialog();
            }
        }

        private void btnEditData_Click(object sender, EventArgs e)
        {
            Log_Converter("UI", "EditData Button Click");
            if (dgvSlotInformation.Rows.Count < 0)
            {
                return;
            }
            else
            {
                dgvClickEvent();
            }
        }

        private void dgvSlotInfomation_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Log_Converter("UI", "DataGridView Doublie Click");
            dgvClickEvent();
        }

        private void Log_Converter(string LogType, string strMsg)
        {
            switch (LogType)
            {
                case "UI":
                    CLogManager.Instance.Log(new CUILogFormat(Catagory.Info, "", "frmBufferInfo", strMsg));
                    break;
            }
        }

        private void dgvSlotInformation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow dgvRow in dgvSlotInformation.SelectedRows)
            {
                this.lblGlsPnlJudge.Text = dgvRow.Cells[0].Value.ToString();
                this.lblGlsPnlGrade.Text = dgvRow.Cells[1].Value.ToString();
            }
        }

        private void cmbEqpNo_SelectedValueChanged(object sender, EventArgs e)
        {
            Log_Converter("UI", "cmbEqpNo Selected");
            Update_OvenInfo(cmbEqpNo.SelectedValue.ToString());
        }

        public void Update_OvenInfo(string EqpNo)
        {
            //추가 해야 할 사항
            //EqpNo를 가지고, OvenINfo에서 동일한 EQP 정보를 가지고 옴.
            //가지고 온 정보를 dgvSlotInformation에 표시함.
            //LoadTime, Qty, OvenID를 넣음.
        }
    }

    public class OvenInfoDataList
    {
        public string Lot_EQPID { get; set; }
        public string Lot_OVNEID { get; set; }
        public string Lot_LOADTIME { get; set; }
        public string Lot_QTY { get; set; }

        public string SLOT_GLSID { get; set; }
        public string SLOT_FROMPORTID { get; set; }
        public string SLOT_FROMCSTID { get; set; }
        public string SLOT_FROMSLOTID { get; set; }
        public string SLOT_PPID { get; set; }
        public string SLOT_GLSJUDGE { get; set; }
        public string SLOT_GLSSORTTYPE { get; set; }
        public string SLOT_SMPLFLAG { get; set; }
        public string SLOT_RWKCNT { get; set; }
        public string SLOT_GLSPNLJUDGE { get; set; }
        public string SLOT_GLSPNLGRADE { get; set; }
    }
}
