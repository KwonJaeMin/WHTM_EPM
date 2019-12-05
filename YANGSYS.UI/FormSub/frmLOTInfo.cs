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
    public partial class frmLOTInfo : FrmPopUp
    {
        public frmLOTInfo()
        {
            InitializeComponent();
            this.pnlButtonBack.Visible = false;
        }

        private void setInformationDatas(LotInfoDatList lotInfoDatas)
        {
            LotInfoDatList LotInfoList = lotInfoDatas;
            for (int i = 0; i < 10; i++)
            {
                dgvSlotInformation.Rows[i].Cells[0].Value = LotInfoList.SLOT_GLSID;
                dgvSlotInformation.Rows[i].Cells[1].Value = LotInfoList.SLOT_GLSJUDGE;
                dgvSlotInformation.Rows[i].Cells[2].Value = LotInfoList.SLOT_GLSSORTTYPE;
                dgvSlotInformation.Rows[i].Cells[3].Value = LotInfoList.SLOT_SMPLFLAG;
                dgvSlotInformation.Rows[i].Cells[4].Value = LotInfoList.SLOT_RWKCNT;
                dgvSlotInformation.Rows[i].Cells[5].Value = LotInfoList.SLOT_GLSTYPE;
                dgvSlotInformation.Rows[i].Cells[6].Value = LotInfoList.SLOT_FROMPORTID;
                dgvSlotInformation.Rows[i].Cells[7].Value = LotInfoList.SLOT_FROMCSTID;
                dgvSlotInformation.Rows[i].Cells[8].Value = LotInfoList.SLOT_FROMSLOTID;
            }
            this.lblProdID.Text = LotInfoList.Lot_PORTID;
            this.lblCSTID.Text = LotInfoList.Lot_CSTID;
            this.lblLoadTime.Text = LotInfoList.Lot_LOADTIME;
            this.lblQty.Text = LotInfoList.Lot_QTY;
        }

        public void UpdateDgvDatas()
        {
            //추가 해야 할 사항
            //업데이터 해야하는 데이터를 가져옴.
            //datagridview에 데이터를 업데이트 함.
            //아래 네개의 lbl에 값을 넣어야함.
            this.lblCSTID.Text = "";
            this.lblLoadTime.Text = "";
            this.lblProdID.Text = "";
            this.lblQty.Text = "";
        }

        private void dgvClickEvent()
        {
            foreach (DataGridViewRow dgvViewRow in dgvSlotInformation.SelectedRows)
            {
                //추가 해야 할 사항                
                //dgv데이터를 frmbufferdataedit로 넘김

                frmDataEdit frmDataEdit = new frmDataEdit();
                frmDataEdit.TopMost = true;
                frmDataEdit.ShowDialog();
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
                    CLogManager.Instance.Log(new CUILogFormat(Catagory.Info, "", "frmLotInfo", strMsg));
                    break;
            }
        }

        private void dgvSlotInformation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow dgvRow in dgvSlotInformation.SelectedRows)
            {
                //추가 해야 할 사항
                //lblGlsPnlJudge, lblGlsPnlGrade에 값을 넣어야함.
                this.lblGlsPnlJudge.Text = dgvRow.Cells[0].Value.ToString();
                this.lblGlsPnlGrade.Text = dgvRow.Cells[1].Value.ToString();
            }
        }
    }

    public class LotInfoDatList
    {
        public string Lot_PORTID { get; set; }
        public string Lot_CSTID { get; set; }
        public string Lot_LOADTIME { get; set; }
        public string Lot_QTY { get; set; }

        public string SLOT_GLSID { get; set; }
        public string SLOT_GLSJUDGE { get; set; }
        public string SLOT_GLSSORTTYPE { get; set; }
        public string SLOT_SMPLFLAG { get; set; }
        public string SLOT_RWKCNT { get; set; }
        public string SLOT_GLSTYPE { get; set; }
        public string SLOT_FROMPORTID { get; set; }
        public string SLOT_FROMCSTID { get; set; }
        public string SLOT_FROMSLOTID { get; set; }
        public string SLOT_GLSPNLJUDGE { get; set; }
        public string SLOT_GLSPNLGRADE { get; set; }
    }
}
