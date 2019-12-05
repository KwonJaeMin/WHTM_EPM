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
    public partial class frmDataEdit : FrmPopUp
    {
        public frmDataEdit()
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
            Log_Converter("UI", "Clear Button Click");
            //Lot Information            
            this.txtLotID.Text = "";
            this.txtLot_ProdID.Text = "";
            this.txtLot_OperID.Text = "";
            this.txtLotJudge.Text = "";
            this.txtLotSortType.Text = "";
            
            //SlotInformation
            //this.lblSlotID.Text = "";
            this.txtSlot_GLSID.Text = "";
            this.txtSLot_RWKCNT.Text = "";
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
            this.txtSlot_glsPnlGrade.Text = "";
            this.txtSlot_FromEqpNo.Text = "";
            this.txtSlot_FromPortNo.Text = "";
            this.txtSlot_FromSlotNo.Text = "";
            this.txtSlot_InputGlsID.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Log_Converter("UI", "Update Button Click");
            //추가 해야 할 사항
            DataEditList dataEditList = null;

            dataEditList.LOT_PORTID = this.lblLot_PortID.Text;
            dataEditList.LOT_CSTID = this.lblLot_CSTID.Text;
            dataEditList.LOT_LOTID = this.txtLotID.Text;
            dataEditList.LOT_PRODID = this.txtLot_ProdID.Text;
            dataEditList.LOT_OPERID = this.txtLot_OperID.Text;
            dataEditList.LOT_LOTJUDGE = this.txtLotJudge.Text;
            dataEditList.LOT_LOTSORTTYPE = this.txtLotSortType.Text;

            dataEditList.SLOT_SLOTID = this.lblSlotID.Text;
            dataEditList.SLOT_GLSID = this.txtSlot_GLSID.Text;
            dataEditList.SLOT_RWKCNT = this.txtSLot_RWKCNT.Text;
            dataEditList.SLOT_GLSEXIST = this.cmbSlot_GlsExist.Text;
            dataEditList.SLOT_SMPLFLAG = this.cmbSlot_SMPLFLAG.Text;
            dataEditList.SLOT_GLSJUDGE = this.txtSlot_GlsType.Text;
            dataEditList.SLOT_GLSTYPE = this.txtSlot_GlsJudge.Text;
            dataEditList.SLOT_GLSSORTTYPE = this.txtSlot_GlsSortType.Text;
            dataEditList.SLOT_PPID = this.txtSlot_PPID.Text;
            dataEditList.SLOT_CFGLSID = this.txtSlot_CFGLSID.Text;
            dataEditList.SLOT_GLSPNLDATA = this.cmbSlot_GlsPnlData.Text;
            dataEditList.SLOT_GLSPROCFLAG = this.cmbSlot_GlsProcFlag.Text;
            dataEditList.SLOT_GLSPNLJUDGE = this.txtSlot_GlsPnlJudge.Text;
            dataEditList.SLOT_GLSPNLGRADE = this.txtSlot_glsPnlGrade.Text;
            dataEditList.SLOT_FROMEQPNO = this.txtSlot_FromEqpNo.Text;
            dataEditList.SLOT_FROMPORTNO = this.txtSlot_FromPortNo.Text;
            dataEditList.SLOT_FROMSLOTNO = this.txtSlot_FromSlotNo.Text;
            dataEditList.SLOT_INPUTGLSID = this.txtSlot_InputGlsID.Text;

            //현재 등록 되어 잇는 정보들을 조합하여 db에 업데이트 해야함.
        }

        private void btnScrap_Click(object sender, EventArgs e)
        {
            Log_Converter("UI", "Scrap Button Click");
            //추가 해야 할 사항
            //현재 등록 되어 있는 데이터에서 eqp, port, slot에 glass있는지 찾음
            //있을 경우를 찾아서 Scrap 시킴. (s6f11(ceid331))
        }

        private void btnGetGlass_Click(object sender, EventArgs e)
        {
            DataEditList dataEditList = null;
            Log_Converter("UI", "GetGlass Button Click");
            //추가 해야 할 사항
            setInformaionDatas(dataEditList);
            //db에 있는 lot, slot 데이터를 가지고 와서 각 부분에 맞게 보냄.
        }

        private void setInformaionDatas(DataEditList dataEditList)
        {
            DataEditList DataEditList = dataEditList;

            this.lblLot_PortID.Text = DataEditList.LOT_PORTID;
            this.lblLot_CSTID.Text = DataEditList.LOT_CSTID;
            this.txtLotID.Text = DataEditList.LOT_LOTID;
            this.txtLot_ProdID.Text = DataEditList.LOT_PRODID;
            this.txtLot_OperID.Text = DataEditList.LOT_OPERID;
            this.txtLotJudge.Text = DataEditList.LOT_LOTJUDGE;
            this.txtLotSortType.Text = DataEditList.LOT_LOTSORTTYPE;

            this.lblSlotID.Text = DataEditList.SLOT_SLOTID;
            this.txtSlot_GLSID.Text = DataEditList.SLOT_GLSID;
            this.txtSLot_RWKCNT.Text = DataEditList.SLOT_RWKCNT;
            this.cmbSlot_GlsExist.Text = DataEditList.SLOT_GLSEXIST;
            this.cmbSlot_SMPLFLAG.Text = DataEditList.SLOT_SMPLFLAG;
            this.txtSlot_GlsType.Text = DataEditList.SLOT_GLSJUDGE;
            this.txtSlot_GlsJudge.Text = DataEditList.SLOT_GLSTYPE;
            this.txtSlot_GlsSortType.Text = DataEditList.SLOT_GLSSORTTYPE;
            this.txtSlot_PPID.Text = DataEditList.SLOT_PPID;
            this.txtSlot_CFGLSID.Text = DataEditList.SLOT_CFGLSID;
            this.cmbSlot_GlsPnlData.Text = DataEditList.SLOT_GLSPNLDATA;
            this.cmbSlot_GlsProcFlag.Text = DataEditList.SLOT_GLSPROCFLAG;
            this.txtSlot_GlsPnlJudge.Text = DataEditList.SLOT_GLSPNLJUDGE;
            this.txtSlot_glsPnlGrade.Text = DataEditList.SLOT_GLSPNLGRADE;

            this.txtSlot_FromEqpNo.Text = DataEditList.SLOT_FROMEQPNO;
            this.txtSlot_FromPortNo.Text = DataEditList.SLOT_FROMPORTNO;
            this.txtSlot_FromSlotNo.Text = DataEditList.SLOT_FROMSLOTNO;
            this.txtSlot_InputGlsID.Text = DataEditList.SLOT_INPUTGLSID;
        }

        private void Log_Converter(string LogType, string strMsg)
        {
            switch (LogType)
            {
                case "UI":
                    CLogManager.Instance.Log(new CUILogFormat(Catagory.Info, "", "frmDataEdit", strMsg));
                    break;
            }
        }
    }

    public class DataEditList
    {        
        public string LOT_PORTID { get; set; }
        public string LOT_CSTID { get; set; }
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
