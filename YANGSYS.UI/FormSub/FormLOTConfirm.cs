using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SOFD.Gui.PopUp;
using SOFD.Gui.Widget;

namespace YANGSYS.UI
{
    public partial class FormLOTConfirm : FrmPopUp
    {

        #region //delegate's

        #endregion

        #region //constructor's

        public FormLOTConfirm()
        {
            InitializeComponent();
            this.pnlButtonBack.Visible = false;
        }

        private LOTConfirmWindowViewType ConfirmViewType = LOTConfirmWindowViewType.OFFLINE;

        public FormLOTConfirm(string caution)
        {
            InitializeComponent();
            this.pnlButtonBack.Visible = false;
            //화면 초기화 진행
            InitializeDisplay();
            
        }
        private CEPSR _EPSR = null;
        private int MAXSlotCount { get; set; }
        private bool HOST_INFO = false;
        private enumTransferType TransferType = enumTransferType.GLASS;

        public FormLOTConfirm(CEPSR oEPSR, string CSTID, string PORTID, int _iMaxSlotCount, LOTConfirmWindowViewType oViewType, enumTransferType oType)
        {
            InitializeComponent();
            MAXSlotCount = _iMaxSlotCount;
            //oEPSR가 Null이 아니면, 화면에 EPSR 정보를 갱신
            TransferType = oType;
            ConfirmViewType = oViewType;

            if (oEPSR != null)
            {
                DisplayEPSRInfo(oEPSR);
                HOST_INFO = true;
                _EPSR = oEPSR;                
                btnOffLine.Enabled = false;
                //Offline Button 은 CT Time OUT, Validation Error 시에만 동작
            }
            else
            {
                _EPSR = new CEPSR();
                _EPSR.CST = CSTID;
                _EPSR.PORT = PORTID;
                for (int i = 1; i < MAXSlotCount + 1; i++)
                {
                    EPSR_CSTMap oMap = new EPSR_CSTMap();
                    oMap.SLOT = i.ToString();
                    _EPSR.CSTMAP.Add(oMap);
                }
                btnOffLine.Enabled = false;
            }

            txtPORTID.Text = PORTID;
            txtCSTID.Text = CSTID;

            if (oEPSR == null)
                btnCreateInfo.Enabled = true;
            else
                btnCreateInfo.Enabled = false;

            this.ActiveControl = txtLOTID;
        }
        #endregion

        #region //method's

        private void InitializeDisplay()
        {

            txtPORTID.Text = "";
            txtCSTID.Text = "";
            txtCSTSIZE.Text = "";
            txtPRODTYPE.Text = "";
            txtATTRIBUTE.Text = "";
            txtGLSTHICK.Text = "";
            txtPARTNUM.Text = "";
            txtPRCID.Text = "";
            cboRCP.Text = "";
            cboRCP.Items.Clear();

            dgrdLOTInfo.Rows.Clear();

            for (int i = 1; i <= 50; i++)
            {
                dgrdLOTInfo.Rows.Add(i, false, "", "","","");
            }
        }

        public void DisplayEPSRInfo(CEPSR oEPSR)
        {
            //EPSR시 비활성화 버튼 처리
            this.btnOffLine.Enabled = false;
            this.btnOK.Enabled = false;

            //화면 초기화 진행
            InitializeDisplay();

            //화면에 갱신 부분이 들어가야 됨

            if (oEPSR.CMD == "START")
            {
                lblMessageBOX.Text = "HOST로 부터 START이 내려 왔습니다.";
                this.btnOK.Enabled = true;
            }
            else if(oEPSR.CMD == "CANCEL")
            {
                lblMessageBOX.Text = "HOST로 부터 Cancel이 내려 왔습니다.";
            }
          
            txtPORTID.Text = oEPSR.PORT;
            txtLOTID.Text = oEPSR.LOT;
            txtCSTID.Text = oEPSR.CST;
            txtCSTSIZE.Text = oEPSR.CST_SIZE;
            txtPRODTYPE.Text = oEPSR.PROD_TYPE;
            txtATTRIBUTE.Text = oEPSR.ATTRIBUTE;
            txtGLSTHICK.Text = oEPSR.GLS_THK;
            txtPARTNUM.Text = oEPSR.PROD;
            txtPRCID.Text = oEPSR.OPER;

            string tmpRECIPE = oEPSR.RECIPE.ToString();

            tmpRECIPE = tmpRECIPE.Replace("[", "");
            tmpRECIPE = tmpRECIPE.Replace("]", "");

            string[] strRECIPEList = tmpRECIPE.Split(',');

            //Recipe ComboBox에 값을 저장하는 로직
            foreach (string strRECIPEItem in strRECIPEList)
	        {

                cboRCP.Items.Add(strRECIPEItem);
	        }

            cboRCP.Text = cboRCP.Items[0].ToString();


            //Grid에 EPSR의 Cassette 정보를 표시
            foreach (EPSR_CSTMap oMap in oEPSR.CSTMAP)
            {
                string tmpCSTMAP = oMap.ToString();

                string[] strCSTMAPList = tmpCSTMAP.Split(':');


                DataGridViewRow oFindRow = null;

                foreach (DataGridViewRow oRow in dgrdLOTInfo.Rows)
                {
                    if (oRow.Cells["colSlotID"].Value.ToString() == strCSTMAPList[0].ToString())
                    {
                        oFindRow = oRow;
                        break;
                    }
                }

                if (strCSTMAPList[9].ToString() == "0")
                    oFindRow.Cells["colSLOTCHECK"].Value = 0;
                else if(strCSTMAPList[9].ToString() == "1")
                    oFindRow.Cells["colSLOTCHECK"].Value = 1;

                    oFindRow.Cells["colGLSID"].Value =strCSTMAPList[1].ToString();
                    oFindRow.Cells["colJUDGE"].Value =strCSTMAPList[3].ToString();
                    oFindRow.Cells["colGSD"].Value = "";
                    //oFindRow.Cells["colPLNIF"].Value = "";
                    oFindRow.Cells["colPLNIF"].Value = strCSTMAPList[6].ToString();
            }
        }
        #endregion

        #region //Event's

        public event delegateLOTConfirmDataSend LotConfirmDataSend = null;

        private void btnLOTCancel_Click(object sender, EventArgs e)
        {
            if (LotConfirmDataSend != null)
                LotConfirmDataSend("LOTCANCEL", _EPSR);

            this.Close();
        }
        #endregion

        private void btnOffLine_Click(object sender, EventArgs e)
        {
            if (LotConfirmDataSend != null)
                LotConfirmDataSend("OFFLINE", _EPSR);
        }

        private void btnOK_Click_1(object sender, EventArgs e)
        {
            if (dgrdLOTInfo.Rows.Count < MAXSlotCount)
            {
                MessageBox.Show("생성된 Glass 정보가 없습니다", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string strLOTID = txtLOTID.Text;
            _EPSR.LOT = strLOTID;
            _EPSR.CST_SIZE = txtCSTID.Text;
            _EPSR.PROD_TYPE = txtPRODTYPE.Text;
            _EPSR.ATTRIBUTE = txtATTRIBUTE.Text;
            _EPSR.GLS_THK = txtGLSTHICK.Text;
            _EPSR.PROD = txtPARTNUM.Text;
            _EPSR.OPER = txtPRCID.Text;
            _EPSR.RECIPE = cboRCP.Text;
            _EPSR.RTN_CD = "0";
            _EPSR.ENG_CD = "0";

            if (ConfirmViewType == LOTConfirmWindowViewType.ENGCD_1)
            {
                _EPSR.MODE = "N";
            }
            else
            {
                _EPSR.MODE = "F";
            }

            foreach (DataGridViewRow oRow in dgrdLOTInfo.Rows)
            {
                foreach (EPSR_CSTMap oMap in _EPSR.CSTMAP)
                {
                    int iSlot = int.Parse(oRow.Cells["colSlotID"].Value.ToString());
                    if (int.Parse(oMap.SLOT) == iSlot)
                    {
                        oMap.GLS = oRow.Cells["colGLSID"].Value == null ? "" : oRow.Cells["colGLSID"].Value.ToString();
                        oMap.GLS_JUDGE = oRow.Cells["colJUDGE"].Value == null ? "" : oRow.Cells["colJUDGE"].Value.ToString();
                        oMap.MAIN_PNL_INFO = oRow.Cells["colPLNIF"].Value == null ? "" : oRow.Cells["colPLNIF"].Value.ToString();                        
                    }
                }
            }

            if (LotConfirmDataSend != null)
                LotConfirmDataSend("OK", _EPSR);

            this.Close();
        }

        private void FormLOTConfirm_Load(object sender, EventArgs e)
        {

        }

        private void btnCreateInfo_Click(object sender, EventArgs e)
        {
            if (txtLOTID.TextLength < 6)
            {
                ChangeTitleMessage("LOT ID는 최소 6글자 이상이어야 합니다");
                return;
            }

            //
            if (TransferType == enumTransferType.SCRIBE)
            {

                if (txtLOTID.TextLength != 10)
                {
                    ChangeTitleMessage("LOT ID는 10글자이어야 합니다.");
                    return;
                }
            }

            ChangeTitleMessage("LOT INFORMATION CREATING");

            string strLOTID = txtLOTID.Text;
            //_EPSR.LOT = strLOTID;
            //_EPSR.CST_SIZE = txtCSTID.Text;
            //_EPSR.PROD_TYPE = txtPRODTYPE.Text;
            //_EPSR.ATTRIBUTE = txtATTRIBUTE.Text;
            //_EPSR.GLS_THK = txtGLSTHICK.Text;
            //_EPSR.PROD = txtPARTNUM.Text;
            //_EPSR.OPER = txtPRCID.Text;
            //_EPSR.RECIPE = cboRCP.Text;

            dgrdLOTInfo.Rows.Clear();
            
            for (int i = 0; i < MAXSlotCount; i++)
            {
                string GenerateID = strLOTID;
                if (i.ToString().Length < 2)
                    GenerateID += "0" + i.ToString();
                else
                    GenerateID += i.ToString();

                dgrdLOTInfo.Rows.Add();
                DataGridViewRow oRow = dgrdLOTInfo.Rows[i];
                oRow.Cells["colSlotID"].Value = (i + 1).ToString();                
                oRow.Cells["colSLOTCHECK"].Value = true;
                oRow.Cells["colGLSID"].Value = GenerateID;
                oRow.Cells["colJUDGE"].Value = "G";
            }
        }

        delegate void delegateCrossThress(string MSG);
        private string OldMessage = "";
        private void ChangeTitleMessage(string MSG)
        {
            if (InvokeRequired)
            {
                delegateCrossThress oCrossThreas = new delegateCrossThress(ChangeTitleMessage);
                oCrossThreas.BeginInvoke(MSG, null, null);
            }
            else
            {
                OldMessage = lblMessageBOX.Text;
                lblMessageBOX.Text = MSG;
            }
        }

        private void cboRCP_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtPRCID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void txtCSTSIZE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsDigit(e.KeyChar) && e.KeyChar != 46 ) || e.KeyChar == Convert.ToChar(Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void FormLOTConfirm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.close 로 처리될 경우 cancel true 처리 하면 안됨.
            //e.Cancel = true;
        }

    }

    public enum enumLotConfirmButton
    {
        OK,
        CANCEL,
        OFFLINE,
    }
}
