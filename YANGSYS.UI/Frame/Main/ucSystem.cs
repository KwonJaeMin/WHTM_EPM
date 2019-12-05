using System;
using System.Windows.Forms;

using SOFD.Gui.Window;
using SOFD.Logger;
using System.Collections.Generic;

namespace YANGSYS.UI.WHTM
{
    #region //enum
    public enum enumTM02SortingType : int
    {
        UNKNOWN = 0,
        NORMAL = 1,
        STK = 2,
    }
    public enum enumTM05SortingType : int
    {
        UNKNOWN = 0,
        BPMODE = 1,
        OLEDMOE = 4,
    }
    #endregion

    public partial class ucSystem : UCFrame
    {
        #region //delegate's
        public delegate void delegateTMModeChange(object obj, string controlName, int sortingType);
        #endregion

        #region //member's

        #endregion

        #region //property's


        public string LOG_PATH { get; set; }
        public string LOG_DELETE_PERIOD { get; set; }
        public string USER_ID { get; set; }
        public string USER_PW { get; set; }
        public bool CVD_STORE { get; set; }
        public string ROUTE_CONDITION { get; set; }

        public void AddControl(System.Windows.Forms.Control control)
        {
            System.Windows.Forms.Control tempControl = control as System.Windows.Forms.Control;
            tempControl.Location = control.Location;
            tempControl.Size = control.Size;
            this.Controls.Add(tempControl);
        }

        public void AddControl(System.Windows.Forms.Control[] controls)
        {
            this.Controls.Clear();
            this.Controls.AddRange(controls);

        }

        new public FrmMainFrame MainFrame
        {
            get { return _frmMainFrame; }
            set { _frmMainFrame = value; }
        }

        #endregion

        #region //event's
        //public event delegateTMModeChange OnTMModeChange = null;

        #endregion

        #region //constructor's
        public ucSystem()
        {
            InitializeComponent();
            //ucButtonLogPath.OnLedButtonClicked += new delegateLedButtonClicked(ButtonClicked);
            //ucButtonUserSave.OnLedButtonClicked += new delegateLedButtonClicked(ButtonClicked);
            //ucButtonCVDStore.OnLedButtonClicked += new delegateLedButtonClicked(ButtonClicked);
            //ucButtonTM02Type.OnLedButtonClicked += new delegateLedButtonClicked(ButtonClicked);
            //ucButtonTM05Type.OnLedButtonClicked += new delegateLedButtonClicked(ButtonClicked);
            //ucButtonRouteCondition.OnLedButtonClicked += new delegateLedButtonClicked(ButtonClicked);
            
        }
        #endregion

        #region //method's
        //private bool RouteCheck(string equipmentName, CRouteSetup routeDisplay)
        //{
        //    //TM05만 라우트 체크
        //    bool sRet = false;
        //    IEQPControl equipmentControl = null;
        //    foreach (IEQPControl equipment in //_main.Eqps.Values)
        //    {
        //        if (equipment.ControlName != routeDisplay.OwnerId) continue;

        //        equipmentControl = equipment;
        //    }
        //    string[] _glassSperation = equipmentControl.GlassSeparation.Split(',');

        //    if (_glassSperation.Length == 2)
        //    {
        //        CRouteLink[] routeLinkBP = routeDisplay.Route.GetLinks(_glassSperation[0]);

        //        if (TM05SortingType == enumTM05SortingType.OLEDMOE)
        //        {
        //            for (int k = 0; k < routeLinkBP.Length; k++)
        //            {
        //                if (routeLinkBP[k].LocationId.Contains("BFL"))
        //                {
        //                    sRet = false;
        //                    return sRet;
        //                }
        //                else
        //                {
        //                    sRet = true;
        //                }
        //            }
        //        }
        //        if (TM05SortingType == enumTM05SortingType.BPMODE)
        //        {
        //            //for (int k = 0; k < routeLinkBP.Length; k++)
        //            //{
        //            //    if (routeLinkBP[k].LocationId.Contains("BFL"))
        //            //    {
        //            //        sRet = true;
        //            //        return sRet;
        //            //    }
        //            //    else
        //            //        sRet = false;
        //            //}
        //            sRet = true;
        //        }

        //    }

        //    return sRet;
        //}

        //private IEQPControl SearchEquipment(string connectTMName)
        //{
        //    IEQPControl equipment = null;

        //    foreach (IEQPControl equipmentControl in //_main.Eqps.Values)
        //    {
        //        if (connectTMName != equipmentControl.ControlName) continue;
        //        equipment = equipmentControl;
        //    }

        //    return equipment;
        //}
        #endregion


        #region //event's 처리기
        private void ButtonClicked(object sender, string signalName)
        {
            try
            {
                switch (signalName)
                {
                    case "LOG_PATH":
                        FolderBrowserDialog folder = new FolderBrowserDialog();
                        if (folder.ShowDialog() == DialogResult.OK)
                        {
                            txtLocalLogPath.Text = folder.SelectedPath;
                        }
                        break;
                    case "LOG_DELETE_PERIOD":
                        break;
                    #region //USER
                    case "USER_SAVE":
                        {
                            if (!string.IsNullOrEmpty(txtUserID.Text) && !string.IsNullOrEmpty(txtUserPassword.Text))
                            {
                                ////_main.SystemConfig.UserAccount = txtUserID.Text.Trim();
                                ////_main.SystemConfig.UserPassword = txtUserPassword.Text.Trim();

                            }
                            else
                            {
                                lblUser.Text = "ID, PW를 올바르게 입력 요망!";
                            }
                        }
                        break;

                    #endregion

                    default:
                        break;
                }

                this.OnRequest(signalName, txtLocalLogPath.Text);


            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "ERROR", ex));
            }
        }

        private void cmbSortingType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void equipmentControl_OnCurrentRecipeChange(object obj, string currentRecipe)
        {
            try
            {

            }
            catch (Exception ex)
            {
                CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "ERROR", ex));
            }
        }



        private void cmbRouteChange_SelectedValueChanged(object sender, EventArgs e)
        {

        }
        private void cmbRouteCondition_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion

        private void Time_Data_Set_Click(object sender, EventArgs e)
        {
            ////_main.TimeSet(
            //    string.Format("{0:D4}{1:D2}{2:D2}{3:D2}{4:D2}{5:D2}",
            //    DateTime.Now.Year,
            //    DateTime.Now.Month,
            //    DateTime.Now.Day,
            //    DateTime.Now.Hour,
            //    DateTime.Now.Minute,
            //    DateTime.Now.Second
            //    ));
            //_main.oLoader_WriteTimeData();
        }

        private void btnLotCancelRequest_Click(object sender, EventArgs e)
        {
            //_main.LotCancelRequest(Convert.ToInt32( this.txtPortLotCancel.Text.ToString()));
            
        }

        private void btnLotPauseRequest_Click(object sender, EventArgs e)
        {
            //_main.oLoader_LotPauseRequest();
        }

        private void btnLotResumeRequest_Click(object sender, EventArgs e)
        {
            //_main.oLoader_LotResumeRequest();
        }

        private void btnSignalRequest_Click(object sender, EventArgs e)
        {
            //enumLoaderType LoaderType = enumLoaderType.LOADER;
            //enumSignalStatus REDSignal = enumSignalStatus.OFF;
            //enumSignalStatus GREENSignal = enumSignalStatus.OFF;
            //enumSignalStatus YELLOWSignal = enumSignalStatus.OFF;

            //if (this.cbRed.SelectedItem.ToString() == "OFF")
            //{
            //    REDSignal = enumSignalStatus.OFF;
            //}
            //else if (this.cbRed.SelectedItem.ToString() == "FLICKER")
            //{
            //    REDSignal = enumSignalStatus.FLICKER;
            //}
            //else if (this.cbRed.SelectedItem.ToString() == "ON")
            //{
            //    REDSignal = enumSignalStatus.ON;
            //}

            //if (this.cbYellow.SelectedItem.ToString() == "OFF")
            //{
            //    YELLOWSignal = enumSignalStatus.OFF;
            //}
            //else if (this.cbYellow.SelectedItem.ToString() == "FLICKER")
            //{
            //    YELLOWSignal = enumSignalStatus.FLICKER;
            //}
            //else if (this.cbYellow.SelectedItem.ToString() == "ON")
            //{
            //    YELLOWSignal = enumSignalStatus.ON;
            //}


            //if (this.cbGreen.SelectedItem.ToString() == "OFF")
            //{
            //    GREENSignal = enumSignalStatus.OFF;
            //}
            //else if (this.cbGreen.SelectedItem.ToString() == "FLICKER")
            //{
            //    GREENSignal = enumSignalStatus.FLICKER;
            //}
            //else if (this.cbGreen.SelectedItem.ToString() == "ON")
            //{
            //    GREENSignal = enumSignalStatus.ON;
            //}

            //_main.oLoader_WriteSignalStatus(LoaderType, REDSignal, GREENSignal, YELLOWSignal);
        }

        private void btnBuzzerOn_Click(object sender, EventArgs e)
        {
            //_main.oLoader_WriteBuzzer(true);
        }

        private void btnBuzzerOff_Click(object sender, EventArgs e)
        {
            //_main.oLoader_WriteBuzzer(false);
        }

        private void btnMelodyOn_Click(object sender, EventArgs e)
        {
            //_main.oLoader_WriteMelody(true);
        }

        private void btnMelodyOff_Click(object sender, EventArgs e)
        {
            //_main.oLoader_WriteMelody(false);
        }

        private void btnEQPTimeDataSet_Click(object sender, EventArgs e)
        {
            //_main.equipmentControl_WriteTimeData();
        }

        private void btnGlassDataSendWrite_Click(object sender, EventArgs e)
        {

        }

        private void btnGlassDataSend_Click(object sender, EventArgs e)
        {
            //// 글라스 데이터를 만들어서 넣자.
            //CGlassDataProperties oGlass = new CGlassDataProperties();

            //oGlass.EQPRecipeNumber = txtGlassDataSendRecipe.Text.ToString();
            //oGlass.GlassType = txtGlassDataSendGlassType.Text.ToString();


            //oGlass.GlassCode = int.Parse(txtGlassDataSendGlassCode.Text.ToString());
            //oGlass.GlassID = txtGlassDataSendGlassID.Text.ToString();
            //oGlass.LOTCode = int.Parse(txtGlassDataSendLOTCode.Text.ToString());
            //oGlass.GlassSpecificData = txtGlassDataSendGlassSpecialData.Text.ToString();

            //string unitNo = this.txtGlassDataSendUnitNo.Text.ToString();
            //string stageNo = this.txtGlassDataSendStageNo.Text.ToString();

            ////_main.oEQPTest_GlassDataSendWrite(unitNo, stageNo,oGlass);
        }

        private void btnLotEndReport_Click(object sender, EventArgs e)
        {
            // 데이터 쓰기.
            ////_main.oEQPTest_LotEndSendWrite("EQP01", this.txtLotEndcode.Text.ToString().Trim());

            // 비트 살리기
            ////_main.oEQPTest_LotEndReport("EQP01", true);

            //_main.LotEndSendToEquipment("EQP01", int.Parse(this.txtLotEndcode.Text.ToString().Trim()));
        }

        private void btnPanelInfoSend_Click(object sender, EventArgs e)
        {
            string panelInfo = txtPanelInfo.Text;
        }

        private void btnLinkTestOn_Click(object sender, EventArgs e)
        {

            if (this.txtLinkTest.Text.ToString() == "")
            {
                MessageBox.Show("Control Name를 입력하세요");
                return;
            }
            //_main.LinkTestOnOff(this.txtLinkTest.Text.ToString(), true);
        }



        private void btnLinkTestOff_Click(object sender, EventArgs e)
        {
            if (this.txtLinkTest.Text.ToString() == "")
            {
                MessageBox.Show("Control Name를 입력하세요");
                return;
            }
            //_main.LinkTestOnOff(this.txtLinkTest.Text.ToString(), false);
        }

        private void btnGlassDataSendRequest_Click(object sender, EventArgs e)
        {

            //int _unit = 0;
            //int _stage = 0;

            if (this.txtlostGlassCode.Text.ToString() == "")
            {
                MessageBox.Show("Glass Code를 입력하세요");
                return;
            }
            if (this.txtlostUnit.Text.ToString() == "")
            {
                MessageBox.Show("Unit를 입력하세요");
                return;
            }
            if (this.txtlostStage.Text.ToString() == "")
            {
                MessageBox.Show("Stage를 입력하세요");
                return;
            }
            ////_main.LinkTestOnOff(this.txtLinkTest.Text.ToString(), false);

            // Glass Code로 Glass 정보 검색
            bool find = false;
            int lostGlassCode = 0;

            //_unit = int.Parse(this.txtlostUnit.Text.ToString());
            //_stage = int.Parse(this.txtlostStage.Text.ToString());


            // 찾았다면 보낸다.
            if (find && lostGlassCode > 0)
            {
                //_main.GlassDataWriteSendToEquipment(this.txtlostUnit.Text.ToString(), this.txtlostStage.Text.ToString(), lostGlassCode);

            }
            else
            {
                MessageBox.Show("Glass Code로 조회된 정보가 없습니다.");
                return;
            }

        }

        private void btnGlassLoadCompConfirmON_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("정말실행 하시겠습니까? 설비로 Glass Data를 먼저 보내고 실시하세요", "확인창", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                // 항상 Glass Data Send가 실패했을때 정지함으로...
                //_main.oLoader_WriteGlassLoadCompleteConfirm("LOADER01", true);

                // 꺼지는 것은 로더 상대 비트가 꺼지면 off된다.
            }
        }
    }
}
