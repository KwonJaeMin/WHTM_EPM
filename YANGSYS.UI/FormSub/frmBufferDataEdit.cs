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
    public partial class frmBufferDataEdit : FrmPopUp
    {
        public frmBufferDataEdit()
        {
            InitializeComponent();
            this.pnlButtonBack.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Log_Converter("UI", "Close Button Click");
            this.Hide();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //Lot Information            
            this.txtLotID.Text = "";
            this.txtProdID.Text = "";
            this.txtOperID.Text = "";
            this.txtLotJudge.Text = "";
            this.txtLotSortType.Text = "";

            //SlotInformation
            //this.lblSlotID.Text = "";
            this.txtGlsID.Text = "";
            this.txtRwkcnt.Text = "";
            this.cmbGlsExist.SelectedIndex = 0;
            this.cmbSmplflag.SelectedIndex = 0;
            this.txtGlsType.Text = "";
            this.txtGlsJudge.Text = "";
            this.txtGlsSortType.Text = "";
            this.lblPPID.Text = "";
            this.txtCFGlsID.Text = "";
            this.cmbGlsPnlData.SelectedIndex = 0;
            this.cmbGlsProcFlag.SelectedIndex = 0;
            this.txtGlsPnlJudge.Text = "";
            this.txtGlsPnlGrade.Text = "";
            Log_Converter("UI", "Clear Button Click");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            BufferDataList BufferList = null;
            Log_Converter("UI", "UpdateButton Click");

            //추가 해야 할 사항
            BufferList.LOT_FROMPORTNO = this.lblFromCstID.Text;
            BufferList.LOT_FROMSLOTNO = this.lblFromSlotNo.Text;
            BufferList.LOT_FRMOCSTID = this.lblFromCstID.Text;
            BufferList.LOT_LOTID = this.txtLotID.Text;
            BufferList.LOT_PRODID = this.txtProdID.Text;
            BufferList.LOT_OPERID = this.txtOperID.Text;
            BufferList.LOT_LOTJUDGE = this.txtLotJudge.Text;
            BufferList.LOT_LOTSORTTYPE = this.txtLotSortType.Text;

            BufferList.SLOT_SLOTID = this.lblSlotID.Text;
            BufferList.SLOT_GLSID = this.txtGlsID.Text;
            BufferList.SLOT_RWKCNT = this.txtRwkcnt.Text;
            BufferList.SLOT_GLSEXIST = this.cmbGlsExist.Text;
            BufferList.SLOT_SMPLFLAG = this.cmbSmplflag.Text;
            BufferList.SLOT_GLSTYPE = this.txtGlsType.Text;
            BufferList.SLOT_GLSJUDGE = this.txtGlsJudge.Text;
            BufferList.SLOT_GLSSORTTYPE = this.txtGlsSortType.Text;
            BufferList.SLOT_PPID = this.lblPPID.Text;
            BufferList.SLOT_CFGLSID = this.txtCFGlsID.Text;
            BufferList.SLOT_GLSPNLDATA = this.cmbGlsPnlData.Text;
            BufferList.SLOT_GLSPROCFLAG = this.cmbGlsProcFlag.Text;
            BufferList.SLOT_GLSPNLJUDGE = this.txtGlsPnlJudge.Text;
            BufferList.SLOT_GLSPNLGRADE = this.txtGlsPnlGrade.Text;

            //BUFFER데이터 입력
            //UI 갱신.frmBufferInfo UI 갱신.
        }

        private void btnScrap_Click(object sender, EventArgs e)
        {
            BufferDataList BufferList = null;
            Log_Converter("UI", "ScrapButton Click");

            //추가 해야 할 사항
            BufferList.LOT_FROMPORTNO = this.lblFromCstID.Text;
            BufferList.LOT_FROMSLOTNO = this.lblFromSlotNo.Text;
            BufferList.LOT_FRMOCSTID = this.lblFromCstID.Text;
            BufferList.LOT_LOTID = this.txtLotID.Text;
            BufferList.LOT_PRODID = this.txtProdID.Text;
            BufferList.LOT_OPERID = this.txtOperID.Text;
            BufferList.LOT_LOTJUDGE = this.txtLotJudge.Text;
            BufferList.LOT_LOTSORTTYPE = this.txtLotSortType.Text;

            BufferList.SLOT_SLOTID = this.lblSlotID.Text;
            BufferList.SLOT_GLSID = this.txtGlsID.Text;
            BufferList.SLOT_RWKCNT = this.txtRwkcnt.Text;
            BufferList.SLOT_GLSEXIST = this.cmbGlsExist.Text;
            BufferList.SLOT_SMPLFLAG = this.cmbSmplflag.Text;
            BufferList.SLOT_GLSTYPE = this.txtGlsType.Text;
            BufferList.SLOT_GLSJUDGE = this.txtGlsJudge.Text;
            BufferList.SLOT_GLSSORTTYPE = this.txtGlsSortType.Text;
            BufferList.SLOT_PPID = this.lblPPID.Text;
            BufferList.SLOT_CFGLSID = this.txtCFGlsID.Text;
            BufferList.SLOT_GLSPNLDATA = this.cmbGlsPnlData.Text;
            BufferList.SLOT_GLSPROCFLAG = this.cmbGlsProcFlag.Text;
            BufferList.SLOT_GLSPNLJUDGE = this.txtGlsPnlJudge.Text;
            BufferList.SLOT_GLSPNLGRADE = this.txtGlsPnlGrade.Text;

            //데이터 정리
            //HOST추가사항 : S6F11_CEID331
            //bufferlistdata에 정리
        }

        public void frmBufferDataEdit_Load(object sender, EventArgs e)
        {
            Data_Reload();
        }

        private void Data_Reload()
        {
            this.cmbGlsPnlData.Items.Add("GLASS EXIST");
            this.cmbGlsPnlData.Items.Add("Not Exist");

            this.cmbSmplflag.Items.Add("Y");
            this.cmbSmplflag.Items.Add("N");

            this.cmbGlsProcFlag.Items.Add("EMPTY");
            this.cmbGlsProcFlag.Items.Add("PROCESS END");
            this.cmbGlsProcFlag.Items.Add("WAIT PROCESS");
            this.cmbGlsProcFlag.Items.Add("SKIP PROCESS");
            this.cmbGlsProcFlag.Items.Add("PROCESS FAIL");
            this.cmbGlsProcFlag.Items.Add("PROCESS RUN");

            this.cmbGlsExist.Items.Add("NOT EXIST");
            this.cmbGlsExist.Items.Add("EXIST");
        }

        private void setInformationDatas(BufferDataList bufferList)
        {
            BufferDataList BufferList = bufferList;

            this.lblFromCstID.Text = BufferList.LOT_FROMPORTNO;
            this.lblFromSlotNo.Text = BufferList.LOT_FROMSLOTNO;
            this.lblFromCstID.Text = BufferList.LOT_FRMOCSTID;
            this.txtLotID.Text = BufferList.LOT_LOTID;
            this.txtProdID.Text = BufferList.LOT_PRODID;
            this.txtOperID.Text = BufferList.LOT_OPERID;
            this.txtLotJudge.Text = BufferList.LOT_LOTJUDGE;
            this.txtLotSortType.Text = BufferList.LOT_LOTSORTTYPE;

            this.lblSlotID.Text = BufferList.SLOT_SLOTID;
            this.txtGlsID.Text = BufferList.SLOT_GLSID;
            this.txtRwkcnt.Text = BufferList.SLOT_RWKCNT;
            this.cmbGlsExist.Text = BufferList.SLOT_GLSEXIST;
            this.cmbSmplflag.Text = bufferList.SLOT_SMPLFLAG;
            this.txtGlsType.Text = BufferList.SLOT_GLSTYPE;
            this.txtGlsJudge.Text = BufferList.SLOT_GLSJUDGE;
            this.txtGlsSortType.Text = BufferList.SLOT_GLSSORTTYPE;
            this.lblPPID.Text = BufferList.SLOT_PPID;
            this.txtCFGlsID.Text = BufferList.SLOT_CFGLSID;
            this.cmbGlsPnlData.Text = BufferList.SLOT_GLSPNLDATA;
            this.cmbGlsProcFlag.Text = BufferList.SLOT_GLSPROCFLAG;
            this.txtGlsPnlJudge.Text = BufferList.SLOT_GLSPNLJUDGE;
            this.txtGlsPnlGrade.Text = BufferList.SLOT_GLSPNLGRADE;
        }
        
        private void Log_Converter(string LogType, string strMsg)
        {
            switch (LogType)
            {
                case "UI":
                    CLogManager.Instance.Log(new CUILogFormat(Catagory.Info, "", "frmBufferDataEdit", strMsg));
                    break;
            }
        }
    }

    public class BufferDataList
    {
        public string LOT_FROMPORTNO { get; set; }
        public string LOT_FROMSLOTNO { get; set; }
        public string LOT_FRMOCSTID { get; set; }
        public string LOT_LOTID { get; set; }
        public string LOT_PRODID { get; set; }
        public string LOT_OPERID { get; set; }
        public string LOT_LOTJUDGE { get; set; }
        public string LOT_LOTSORTTYPE { get; set; }
        public string SLOT_SLOTID { get; set; }
        public string SLOT_GLSID { get; set; }
        public string SLOT_RWKCNT { get; set; }
        public string SLOT_GLSEXIST { get; set; }
        public string SLOT_SMPLFLAG { get; set; }
        public string SLOT_GLSTYPE { get; set; }
        public string SLOT_GLSJUDGE { get; set; }
        public string SLOT_GLSSORTTYPE { get; set; }
        public string SLOT_PPID { get; set; }
        public string SLOT_CFGLSID { get; set; }
        public string SLOT_GLSPNLDATA { get; set; }
        public string SLOT_GLSPROCFLAG { get; set; }
        public string SLOT_GLSPNLJUDGE { get; set; }
        public string SLOT_GLSPNLGRADE { get; set; }
    }
}
