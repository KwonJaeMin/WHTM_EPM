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
    public partial class frmOvenDataEdit : FrmPopUp
    {
        public frmOvenDataEdit()
        {
            InitializeComponent();
            this.pnlButtonBack.Visible = false;
        }

        public void setInformation(OvenDataEditList ovenDataEditList)
        {
            OvenDataEditList OvenList = ovenDataEditList;

            this.lblLot_FromPortNo.Text = OvenList.LOT_FROMPORTNO;
            this.lblLot_FromSlotNo.Text = OvenList.LOT_FROMSLOTNO;
            this.lblLot_PPID.Text = OvenList.LOT_PPID;
            this.txtLotID.Text = OvenList.LOT_LOTID;
            this.txtLot_ProdID.Text = OvenList.LOT_PRODID;
            this.txtLot_OperID.Text = OvenList.LOT_OPERID;
            this.txtLotJudge.Text = OvenList.LOT_LOTJUDGE;
            this.txtLotSortType.Text = OvenList.LOT_LOTSORTTYPE;

            this.lblSlotID.Text = OvenList.SLOT_SLOTID;
            this.txtSlot_GlsID.Text = OvenList.SLOT_GLSID;
            this.txtSlot_RWKCNT.Text = OvenList.SLOT_RWKCNT;
            this.cmbSlot_GlsExist.Text = OvenList.SLOT_GLSEXIST;
            this.cmbSlot_SMPLFLAG.Text = OvenList.SLOT_SMPLFLAG;
            this.txtSlot_GlsType.Text = OvenList.SLOT_GLSTYPE;
            this.txtSlot_GlsJudge.Text = OvenList.SLOT_GLSJUDGE;
            this.txtSlot_GlsSortType.Text = OvenList.SLOT_GLSSORTTYPE;
            this.txtSlot_PPID.Text = OvenList.SLOT_PPID;
            this.txtSlot_CFGLSID.Text = OvenList.SLOT_CFGLSID;
            this.cmbSlot_GlsPnlData.Text = OvenList.SLOT_GLSPNLDATA;
            this.cmbSlot_GlsProcFlag.Text = OvenList.SLOT_GLSPROCFLAG;
            this.txtSlot_GlsPnlJudge.Text = OvenList.SLOT_GLSPNLJUDGE;
            this.txtSlot_GlsPnlGrade.Text = OvenList.SLOT_GLSPNLGRADE;
            this.txtSlot_FromEqpNo.Text = OvenList.SLOT_FROMEQPNO;
            this.txtSlot_FromPortNo.Text = OvenList.SLOT_FROMPORTNO;
            this.txtSlot_FromSlotNo.Text = OvenList.SLOT_FROMSLOTNO;
            this.txtSlot_InpuGlsID.Text = OvenList.SLOT_INPUTGLSID;
        }

        public void getInformation()
        {
            OvenDataEditList OvenList = null;

            OvenList.LOT_FROMPORTNO = this.lblLot_FromPortNo.Text;
            OvenList.LOT_FROMSLOTNO = this.lblLot_FromSlotNo.Text;
            OvenList.LOT_PPID = this.lblLot_PPID.Text;
            OvenList.LOT_LOTID = this.txtLotID.Text;
            OvenList.LOT_PRODID = this.txtLot_ProdID.Text;
            OvenList.LOT_OPERID = this.txtLot_OperID.Text;
            OvenList.LOT_LOTJUDGE = this.txtLotJudge.Text;
            OvenList.LOT_LOTSORTTYPE = this.txtLotSortType.Text;

            OvenList.SLOT_SLOTID = this.lblSlotID.Text;
            OvenList.SLOT_GLSID = this.txtSlot_GlsID.Text;
            OvenList.SLOT_RWKCNT = this.txtSlot_RWKCNT.Text;
            OvenList.SLOT_GLSEXIST = this.cmbSlot_GlsExist.Text;
            OvenList.SLOT_SMPLFLAG = this.cmbSlot_SMPLFLAG.Text;
            OvenList.SLOT_GLSTYPE = this.txtSlot_GlsType.Text;
            OvenList.SLOT_GLSJUDGE = this.txtSlot_GlsJudge.Text;
            OvenList.SLOT_GLSSORTTYPE = this.txtSlot_GlsSortType.Text;
            OvenList.SLOT_PPID = this.txtSlot_PPID.Text;
            OvenList.SLOT_CFGLSID = this.txtSlot_CFGLSID.Text;
            OvenList.SLOT_GLSPNLDATA = this.cmbSlot_GlsPnlData.Text;
            OvenList.SLOT_GLSPROCFLAG = this.cmbSlot_GlsProcFlag.Text;
            OvenList.SLOT_GLSPNLJUDGE = this.txtSlot_GlsPnlJudge.Text;
            OvenList.SLOT_GLSPNLGRADE = this.txtSlot_GlsPnlGrade.Text;
            OvenList.SLOT_FROMEQPNO = this.txtSlot_FromEqpNo.Text;
            OvenList.SLOT_FROMPORTNO = this.txtSlot_FromPortNo.Text;
            OvenList.SLOT_FROMSLOTNO = this.txtSlot_FromPortNo.Text;
            OvenList.SLOT_INPUTGLSID = this.txtSlot_InpuGlsID.Text;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Log_Converter("UI", "Close Button Click");
            this.Close();
        }

        private void btnGetGlassData_Click(object sender, EventArgs e)
        {
            OvenDataEditList OvenDataList = null;
            Log_Converter("UI", "GetGlassData Button Click");            
            //추가 해야 할 사항
            //db에서 InputGlsID를 검색하여 데이터를 OvenDataList를 넣음.
            setInformation(OvenDataList);            
        }

        private void btnScrap_Click(object sender, EventArgs e)
        {
            Log_Converter("UI", "Scrap Button Click");
            //추가 해야 할 사항
            //데이터 정리
            //HOST추가사항 : S6F11_CEID331
            //bufferlistdata에 정리
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            OvenDataEditList ovenDataList = null;
            Log_Converter("UI", "Update Button Click");
            getInformation();
            //추가 해야 할 사항
            //BUFFER데이터 입력            
            //UI 갱신.frmBufferInfo UI 갱신.
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //Lot Information
            this.txtLotID.Text = "";
            this.txtLot_ProdID.Text = "";
            this.txtLot_OperID.Text = "";
            this.txtLotJudge.Text = "";
            this.txtLotSortType.Text = "";

            //SlotInformation
            //this.lblSlotID.Text = "";
            this.txtSlot_GlsID.Text = "";
            this.txtSlot_RWKCNT.Text = "";
            this.cmbSlot_GlsExist.SelectedIndex = 0;
            this.cmbSlot_SMPLFLAG.SelectedIndex = 0;
            this.txtSlot_GlsType.Text = "";
            this.txtSlot_GlsJudge.Text = "";
            this.txtSlot_GlsSortType.Text = "";
            this.txtSlot_PPID.Text = "";
            this.txtSlot_CFGLSID.Text = "";
            this.cmbSlot_GlsPnlData.SelectedIndex = 0;
            this.cmbSlot_GlsProcFlag.SelectedIndex = 0;
            this.txtSlot_GlsPnlJudge.Text = "";
            this.txtSlot_GlsPnlGrade.Text = "";
            this.txtSlot_FromEqpNo.Text = "";
            this.txtSlot_FromPortNo.Text = "";
            this.txtSlot_FromSlotNo.Text = "";
            this.txtSlot_InpuGlsID.Text = "";
            Log_Converter("UI", "Clear Button Click");
        }

        public void frmOvenDataEdit_Load(object sender, EventArgs e)
        {
            Data_Reload();
        }

        private void Data_Reload()
        {
            this.cmbSlot_GlsPnlData.Items.Add("GLASS EXIST");
            this.cmbSlot_GlsPnlData.Items.Add("Not Exist");

            this.cmbSlot_SMPLFLAG.Items.Add("Y");
            this.cmbSlot_SMPLFLAG.Items.Add("N");

            this.cmbSlot_GlsProcFlag.Items.Add("EMPTY");
            this.cmbSlot_GlsProcFlag.Items.Add("PROCESS END");
            this.cmbSlot_GlsProcFlag.Items.Add("WAIT PROCESS");
            this.cmbSlot_GlsProcFlag.Items.Add("SKIP PROCESS");
            this.cmbSlot_GlsProcFlag.Items.Add("PROCESS FAIL");
            this.cmbSlot_GlsProcFlag.Items.Add("PROCESS RUN");

            this.cmbSlot_GlsExist.Items.Add("NOT EXIST");
            this.cmbSlot_GlsExist.Items.Add("EXIST");            
        }

        private void Log_Converter(string LogType, string strMsg)
        {
            switch (LogType)
            {
                case "UI":
                    CLogManager.Instance.Log(new CUILogFormat(Catagory.Info, "", "frmOvenDataEdit", strMsg));
                    break;
            }
        }
    }

    public class OvenDataEditList
    {
        public string LOT_FROMPORTNO { get; set; }
        public string LOT_FROMSLOTNO { get; set; }        
        public string LOT_PPID { get; set; }
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
        public string SLOT_FROMEQPNO { get; set; }
        public string SLOT_FROMPORTNO { get; set; }
        public string SLOT_FROMSLOTNO { get; set; }
        public string SLOT_INPUTGLSID { get; set; }
    }
}
