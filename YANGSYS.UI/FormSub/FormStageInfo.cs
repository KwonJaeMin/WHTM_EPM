using System;
using System.Windows.Forms;

using SOFD.Gui.PopUp;
using SOFD.Logger;

namespace YANGSYS.UI
{
    public partial class FormStageInfo : FrmPopUp
    {
        #region //delegate's

        #endregion

        #region //member's

        #endregion
        private bool _autoRefresh = true;

        #region //property's

        private IStageControl _stage;
        public IStageControl Stage
        {
            get { return _stage; }
            set
            {
                _stage = value;
            }
        }

        #endregion

        #region //event
        public delegatePopupFormClosed OnPopupFormClosed = null;
        #endregion

        #region //constructor's
        public FormStageInfo()
        {
            InitializeComponent();
            this.pnlButtonBack.Visible = false;
            //ucGlassDataView1.OnDataGridViewOneGlassView += new delegateDataGridViewOneGlassView(ucGlassDataViewOnDataGridViewOneGlassView);
            //ucGlassDataView2.OnDataGridViewOneGlassView += new delegateDataGridViewOneGlassView(ucGlassDataViewOnDataGridViewOneGlassView);
            //ucGlassDataView3.OnDataGridViewOneGlassView += new delegateDataGridViewOneGlassView(ucGlassDataViewOnDataGridViewOneGlassView);
            //ucGlassDataView4.OnDataGridViewOneGlassView += new delegateDataGridViewOneGlassView(ucGlassDataViewOnDataGridViewOneGlassView);

        }

        //void ucGlassDataViewOnDataGridViewOneGlassView(int iGlassCode)
        //{

        //    CGlassDataProperties oGlass = null;
        //    oGlass = Main.GlassDatas[iGlassCode];

        //    if (oGlass != null)
        //    {
        //        dataGridViewOneGlass.Rows.Clear();
        //        dataGridViewOneGlass.Rows.Add();

        //        DataGridViewRow row = null;

        //        row = dataGridViewOneGlass.Rows[0];
        //        row.Cells["dgvGlassCode"].Value = oGlass.GlassCode;
        //        row.Cells["dgvGlassID"].Value = oGlass.GlassID;
        //        row.Cells["dgvLotID"].Value = oGlass.LotID;
        //        row.Cells["dgvProcessingCode"].Value = oGlass.ProcessingCode;
        //        row.Cells["dgvLotSpecificData"].Value = oGlass.LotSpecificData;
        //        row.Cells["dgvHostRecipeNumber"].Value = oGlass.HostRecipeNumber;
        //        row.Cells["dgvGlassJudge"].Value = oGlass.GlassJudge;
        //        row.Cells["dgvGlassSpecificData"].Value = oGlass.GlassSpecificData;
        //        row.Cells["dgvGlassAddData"].Value = oGlass.GlassAddData;
        //        //row.Cells["GlassVariety"].Value = oGlass.;
        //        //row.Cells["GlassProcessingStatus"].Value = oGlass.ProcessingCode;
        //        row.Cells["dgvOriginalCassetteID"].Value = oGlass.OriginalCassetteID;
        //        row.Cells["dgvGlassCurrentLoc"].Value = oGlass.GlassCurrentLocation;
        //        //row.Cells["GlassCurrentTmLoc"].Value = oGlass.GlassCurrentLocation;
        //        row.Cells["dgvPrevUnitProcessingData"].Value = oGlass.PreviousUnitProcessingData;
        //        row.Cells["dgvCurrentLoc"].Value = oGlass.CurrentLocation;
        //        row.Cells["dgvCreateTime"].Value = oGlass.CreateTime;
        //        row.Cells["dgvModifyTime"].Value = oGlass.ModifyTime;
        //        row.Cells["dgvGlassRoutePath"].Value = oGlass.GlassRoutePath;
        //        row.Cells["dgvEqpRecipeNumber"].Value = oGlass.EQPRecipeNumber;
        //        row.Cells["dgvGlassJudgeCode"].Value = oGlass.GlassJudgeCode;
        //        row.Cells["dgvLotCode"].Value = oGlass.LOTCode;
        //    }
        //}

        // EQP에 Stage정보를 가져오기 위함.
        public FormStageInfo(IStageControl oStage)
        {
            InitializeComponent();
            this.FormText = oStage.ControlName;
            this._stage = oStage;
            this.CloseButtonEnable = true;
            this.ButtonType = PopUpButton.Close;
           // this.ButtonSize = new Size(70, 25);

            //if (this.FormText.Contains("BUFFER02") || this.FormText.Contains("BUFFER01"))
            //{
            //    this.lblSlotNumber.Visible = true;
            //    this.cmbSlotNumber.Visible = true;
            //    this.btnSend.Visible = true;
            //}

        }

        #endregion

        #region GlassDataInfo 에 해당하는 메서드
        public void SetDataGridView(CMain main)
        {
            if (_autoRefresh)
            {
                int dataGridViewRowCount = 0;

                dgvStagetInfo.Rows.Clear();

                foreach (IStageControl oStage in main.Stages.Values)
                {
                    try
                    {
                        //Console.WriteLine(oStage.GlassCode);
                        // 같은 그룹에 있는 녀석들만 보이도록 한다.
                        if (_stage.MultiStageGroup == oStage.MultiStageGroup)
                        {
                            dgvStagetInfo.Rows.Add();
                            DataGridViewRow row = null;

                            row = dgvStagetInfo.Rows[dataGridViewRowCount];
                            
                            row.Cells["colStageNo"].Value = oStage.StageNo;
                            if(oStage.GlassExist)
                                row.Cells["colGlassCode"].Value = oStage.GlassCode;
                            if (oStage.UseStageStatus)
                            {
                                row.Cells["colStageStatus"].Value = oStage.StageStatus;
                            }
                            else
                            {
                                row.Cells["colStageStatus"].Value = "";
                            }

                            dataGridViewRowCount++;
                        }
                    }
                    catch (Exception ex)
                    {
                        CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "EMP", ex));
                        //throw;
                    }
                }
            }
        }

        private void btnDeleteSelect_Click(object sender, EventArgs e)
        {
            if (Main == null)
                return;

            CGlassDataProperties oGlass = null;

            if (ShowCheckConfirm("Glass Data 삭제", "정말 삭제하시겠습니까?"))
            {
                foreach (DataGridViewRow oRow in dgvStagetInfo.SelectedRows)
                {
                    // 작업중인 글라스를 지울수도 있다.
                    // 어떻게 방어 해야 하는지...
                    int GlassCode = int.Parse(oRow.Cells["GlassCode"].Value.ToString());
                    oGlass = Main.GlassDatas[GlassCode];
                    oGlass.Delete();



                    Main.GlassDatas.Remove(GlassCode);
                }

                // 화면 리플래쉬
                SetDataGridView(_main);
            }
        }
        public bool ShowCheckConfirm(string vTitle, string vText)
        {
            FormConfirm fConfirm = new FormConfirm();
            fConfirm.ShowForm(vTitle, vText);

            fConfirm.TopMost = true;
            fConfirm.ShowDialog(this);
            if (fConfirm.CheckReturn)
            {
                fConfirm.TopMost = false;
                return true;
            }
            else
            {
                fConfirm.TopMost = true;
                return false;
            }
        }

        private void chkAutoRefresh_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkAutoRefresh.Checked)
            {
                _autoRefresh = true;
            }
            else
            {
                _autoRefresh = false;
            }
        }

        //private void btnDeleteAll_Click(object sender, EventArgs e)
        //{
        //    if (Main == null)
        //        return;

        //    CGlassDataProperties oGlass = null;
        //    CLotDataProperties oLot = null;

        //    if (ShowCheckConfirm("Glass Data 모두삭제", "정말 삭제하시겠습니까?"))
        //    {
        //        if (ShowCheckConfirm("Glass Data 모두삭제", "진짜로 삭제하시겠습니까? 데이터 복구는 불가합니다."))
        //        {
        //            foreach (DataGridViewRow oRow in dgvStagetInfo.Rows)
        //            {
        //                // 작업중인 글라스를 지울수도 있다.
        //                // 어떻게 방어 해야 하는지...
        //                int GlassCode = int.Parse(oRow.Cells["GlassCode"].Value.ToString());
        //                oGlass = Main.GlassDatas[GlassCode];

        //                if (Main.LotDatas.ContainsKey(oGlass.LOTCode))
        //                {
        //                    oLot = Main.LotDatas[oGlass.LOTCode];
        //                    oLot.Delete();
        //                }
        //                oGlass.Delete();
        //            }

        //            // 화면 리플래쉬
        //            SetDataGridView();
        //        }
        //    }
           
        //}
        #endregion


        //public void comboListUpdate()
        //{
        //    int maxobject = (loadport_cnt - 1) + (unloadport_cnt - 1) + (robot_cnt - 1) + (eqp_cnt - 1);
        //    object[] glassMovePrimary = new object[maxobject];

        //    int glassMovelistCnt=0;
        //    if (loadport_controls != null)
        //    {
        //        //Console.WriteLine("");
        //        for (int i = 1; i < loadport_controls.Length; i++)
        //        {
        //            glassMovePrimary[glassMovelistCnt] = loadport_controls[i];
        //            glassMovelistCnt++;
        //        }
        //    }
        //    if (unloadport_controls != null)
        //    {
        //        //Console.WriteLine("");
        //        for (int i = 1; i < unloadport_controls.Length; i++)
        //        {
        //            glassMovePrimary[glassMovelistCnt] = unloadport_controls[i];
        //            glassMovelistCnt++;
        //        }
        //    }
        //    if (robot_controls != null)
        //    {
        //        //Console.WriteLine("");
        //        for (int i = 1; i < robot_controls.Length; i++)
        //        {
        //            glassMovePrimary[glassMovelistCnt] = loadport_controls[i];
        //            glassMovelistCnt++;
        //        }
        //    }
        //    if (eqp_controls != null)
        //    {
        //        //Console.WriteLine("");
        //        for (int i = 1; i < eqp_controls.Length; i++)
        //        {
        //            glassMovePrimary[glassMovelistCnt] = eqp_controls[i];
        //            glassMovelistCnt++;
        //        }
        //    }


        //    cbGlassMovePrimary.Items.Clear();
        //    cbGlassMovePrimary.Items.AddRange(glassMovePrimary);

        //}


        //#region Position 에 해당하는 메서드

        //private int loaderPortCount = 0;
        //private int unloaderPortCount = 0;

        //private object[] loadport_controls = null;
        //private object[] unloadport_controls = null;
        //private object[] robot_controls = null;
        //private object[] eqp_controls = null;

        //private int loadport_cnt = 1;
        //private int unloadport_cnt = 1;
        //private int robot_cnt = 1;
        //private int eqp_cnt = 1;

        //private void InitUserControlData()
        //{
        //    if (Main == null)
        //        return;


        //    loaderPortCount = 0;
        //    unloaderPortCount = 0;

        //    #region LOADER / UNLOADER 에 포트 채우기


        //    // 몇개를 생성해야 할지를 카운터한다.
        //    foreach (CPortControl oPort in Main.Ports.Values)
        //    {
        //        if (oPort.PortType == enumPortType.LG)
        //        {
        //            loaderPortCount++;
        //        }
        //        else
        //        {
        //            unloaderPortCount++;
        //        }
        //    }


        //    loadport_controls = new object[loaderPortCount+1];
        //    unloadport_controls = new object[unloaderPortCount + 1];

        //    loadport_cnt = 1;
        //    unloadport_cnt = 1;

        //    loadport_controls[0] = ":::장비선택:::";
        //    unloadport_controls[0] = ":::장비선택:::";
        //    foreach (CPortControl oPort in Main.Ports.Values)
        //    {
        //        if (oPort.PortType == enumPortType.LG)
        //        {
        //            loadport_controls[loadport_cnt] = oPort.ControlName;
        //            loadport_cnt++;
        //        }
        //        else
        //        {
        //            unloadport_controls[unloadport_cnt] = oPort.ControlName;
        //            unloadport_cnt++;
        //        }
        //    }

        //    try
        //    {
        //        this.ucGlassDataView1.ComboEquipment.Items.Clear();
        //        this.ucGlassDataView1.ComboEquipment.Items.AddRange(loadport_controls);

        //        this.ucGlassDataView4.ComboEquipment.Items.Clear();
        //        this.ucGlassDataView4.ComboEquipment.Items.AddRange(unloadport_controls);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //        //throw;
        //    }
        //    #endregion

        //    #region 로봇추가하기.
        //    robot_controls = new object[Main.Robots.Count + 1];
        //    robot_cnt = 1;

        //    robot_controls[0] = ":::장비선택:::";
        //    foreach (CRobotControl oRobot in Main.Robots.Values)
        //    {

        //        robot_controls[robot_cnt] = oRobot.ControlName;
        //        robot_cnt++;
        //    }
        //    this.ucGlassDataView2.ComboEquipment.Items.Clear();
        //    this.ucGlassDataView2.ComboEquipment.Items.AddRange(robot_controls);


        //    #endregion

        //    #region 장비추가하기.
        //    eqp_controls = new object[Main.Equipments.Count + 1];
        //    eqp_cnt = 1;

        //    eqp_controls[0] = ":::장비선택:::";
        //    foreach (CEQPControl oEqp in Main.Equipments.Values)
        //    {

        //        eqp_controls[eqp_cnt] = oEqp.ControlName;
        //        eqp_cnt++;
        //    }
        //    this.ucGlassDataView3.ComboEquipment.Items.Clear();
        //    this.ucGlassDataView3.ComboEquipment.Items.AddRange(eqp_controls);


        //    #endregion

        //    comboListUpdate();

        //}


        //private void btnAutoAddControl_Click(object sender, EventArgs e)
        //{
        //    // 유저 컨트롤을 자동으로 생성해서 붙이자...





        //    // 포트 최대 4개...
        //    // 장비는 최대 2개...
        //    // 로더는 최대 2개...
        //    // 로봇은 최대 2개..




        //}

        //#endregion

        //private void cbGlassMovePrimary_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    // 다음 셀렉트에 현재 셀렉트에 해당하는 값을 뿌려준다.
        //    // 현재 셀렉트가 만일 LOADER_PORT01 이면 
        //    // SLOT 번호 1~50을 뿌려준다.
            
        //    Console.WriteLine("");
        //}

        //private void cbGlassMovePrimary_SelectedValueChanged(object sender, EventArgs e)
        //{
        //    // 0,1,2,3,4 ~~ 이런식으로 나온다.

        //    string controlName= (cbGlassMovePrimary.Items[cbGlassMovePrimary.SelectedIndex]).ToString();
        //    object[] secondaryposition = null;
        //    cbGlassMoveSecondary.Items.Clear(); //초기화


            
        //    if (controlName.Contains("PORT")) // iPortID.ToString()))
        //    {
        //        IPortControl oPortControl = null;
        //        oPortControl = _main.Ports[controlName];

        //        secondaryposition = new object[oPortControl.MaxSlotCount];
        //        for (int i = 0; i < oPortControl.MaxSlotCount; i++)
        //        {
        //            secondaryposition[i] = (i + 1).ToString();
        //        }
        //    }
        //    else if (controlName.Contains("EQP")) // iPortID.ToString()))
        //    {
        //        //CStageControl oStageControl = null;
        //        //oStageControl = _main.Stages[controlName];

        //        //secondaryposition = new object[oPortControl.MaxSlotCount];
        //        //for (int i = 0; i < oPortControl.MaxSlotCount; i++)
        //        //{
        //        //    secondaryposition[i] = (i + 1).ToString();
        //        //}
        //    }
        //    if (secondaryposition != null)
        //    {

                
        //        cbGlassMoveSecondary.Items.AddRange(secondaryposition);
        //    }
        //}

        //private void btnGlassInfoMove_Click(object sender, EventArgs e)
        //{

        //    //============================
        //    // oGlass.CurrentLocation
        //    // 1~97 까지 포트
        //    // 98 robot (eqp unloading)
        //    // 99 robot (port unloading)
        //    // 100 
        //    // 101~xxx Eqp Stage
        //    //============================


        //    // 셀렉트된 정보로 데이터를 이동해야 한다.

        //    // 원본 Glass는 이동후 그위치가 변경되어야 한다.
        //    int CurrentLocation = 0;

        //    int GlassCurrentLocation = 0;

        //    string controlName = cbGlassMovePrimary.SelectedItem.ToString();

        //    if (controlName.Contains("PORT"))
        //    {
        //        // 포트넘버 넣기
        //        IPortControl oPortControl = null;
        //        oPortControl = _main.Ports[controlName];
        //        CurrentLocation = oPortControl.PortNo;
        //    }
        //    else if (controlName.Contains("EQP"))
        //    {
        //        // 유닛넘버 넣기.
        //        IEQPControl oEqpControl = null;
        //        oEqpControl = _main.Equipments[controlName];
        //        CurrentLocation = int.Parse(oEqpControl.UnitNo);
        //    }
            
        //    //secondarykey = int.Parse(cbGlassMoveSecondary.SelectedItem.ToString());
            
        //    int glassCode = int.Parse(dataGridViewOneGlass.Rows[0].Cells["dgvGlassCode"].Value.ToString());

        //    MoveGlassDataInfo(glassCode, CurrentLocation, GlassCurrentLocation);
        //    // 화면은 리플래쉬가 되어야한다.
        //}
        //public void MoveGlassDataInfo(int GlassCode, int primarykey, int secondarykey)
        //{
        //    Console.WriteLine("{0} {1} {2} {3}",DateTime.Now.ToString(), GlassCode, primarykey, secondarykey);

        //}
    }
}
