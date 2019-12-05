using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SOFD.Logger;
using MainLibrary.LogFormat;

using SOFD.Gui.PopUp;
namespace MainProgram
{
    public partial class frmBufferInfo : FrmPopUp
    {
        public frmBufferInfo()
        {
            InitializeComponent();
            this.pnlButtonBack.Visible = false;
        }

        private void setInformationDatas(BufferInfoDataList bufferList)
        {
            BufferInfoDataList BufferList = bufferList;
            for (int i = 0; i < 10; i++)
            {
                dgvSlotInfomation.Rows[i].Cells[0].Value = BufferList.SLOT_GLSID;
                dgvSlotInfomation.Rows[i].Cells[1].Value = BufferList.SLOT_GLSJUDGE;
                dgvSlotInfomation.Rows[i].Cells[2].Value = BufferList.SLOT_GLSSORTTYPE;
                dgvSlotInfomation.Rows[i].Cells[3].Value = BufferList.SLOT_SMPLFLAG;
                dgvSlotInfomation.Rows[i].Cells[4].Value = BufferList.SLOT_RWKCNT;
                dgvSlotInfomation.Rows[i].Cells[5].Value = BufferList.SLOT_GLSTYPE;
                dgvSlotInfomation.Rows[i].Cells[6].Value = BufferList.SLOT_FROMPORTID;
                dgvSlotInfomation.Rows[i].Cells[7].Value = BufferList.SLOT_FROMCSTID;
                dgvSlotInfomation.Rows[i].Cells[8].Value = BufferList.SLOT_FROMSLOTID;
            }
            this.lblCSTID.Text = BufferList.Lot_PORTID;
            this.lblLoadTime.Text = BufferList.Lot_CSTID;
            this.lblPortID.Text = BufferList.Lot_LOADTIME;
            this.lblQty.Text = BufferList.Lot_QTY;
        }

        private void dgvClickEvent()
        {
            BufferInfoDataList BufferInfoList = null;
            foreach (DataGridViewRow dgvViewRow in dgvSlotInfomation.SelectedRows)
            {
                //추가 해야 할 사항
                BufferInfoList.SLOT_GLSID = dgvViewRow.Cells[0].Value.ToString();
                BufferInfoList.SLOT_GLSJUDGE = dgvViewRow.Cells[1].Value.ToString();
                BufferInfoList.SLOT_GLSSORTTYPE = dgvViewRow.Cells[2].Value.ToString();
                BufferInfoList.SLOT_SMPLFLAG = dgvViewRow.Cells[3].Value.ToString();
                BufferInfoList.SLOT_RWKCNT = dgvViewRow.Cells[4].Value.ToString();
                BufferInfoList.SLOT_GLSTYPE = dgvViewRow.Cells[5].Value.ToString();
                BufferInfoList.SLOT_FROMPORTID = dgvViewRow.Cells[6].Value.ToString();
                BufferInfoList.SLOT_FROMCSTID = dgvViewRow.Cells[7].Value.ToString();
                BufferInfoList.SLOT_FROMSLOTID = dgvViewRow.Cells[8].Value.ToString();

                BufferInfoList.Lot_PORTID = this.lblPortID.Text;
                BufferInfoList.Lot_CSTID = this.lblCSTID.Text;
                BufferInfoList.Lot_LOADTIME = this.lblLoadTime.Text;
                BufferInfoList.Lot_QTY = this.lblQty.Text;
                
                frmBufferDataEdit frmBufferDataEdit = new frmBufferDataEdit();
                frmBufferDataEdit.TopMost = true;
                frmBufferDataEdit.ShowDialog();
            }
        }

        private void btnEditData_Click(object sender, EventArgs e)
        {
            Log_Converter("UI", "EditData Button Click");
            if (dgvSlotInfomation.Rows.Count < 0)
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

        private void dgvSlotInfomation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow dgvRow in dgvSlotInfomation.SelectedRows)
            {
                //추가 해야 할 사항
                //lblGlsPnlJudge.text, lblGlsPnlJudge.Text의 값을 넣어야함.
                this.lblGlsPnlJudge.Text = dgvRow.Cells[0].Value.ToString();
                this.lblglsPnlGrade.Text = dgvRow.Cells[1].Value.ToString();
            }
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
    }

    public class BufferInfoDataList
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
