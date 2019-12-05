using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MainLibrary;

//using MainLibrary.Properties;
using MainLibrary.Property;

using SOFD.Logger;
using SOFD.InterfaceTimeout;
using SOFD.Driver;
using SOFD.Gui.PopUp;

namespace MainProgram
{
    public partial class FormPortInfo : FrmPopUp
    {
        #region //delegate's
        private delegate void delegateGridViewRefresh(CMain main);
        private delegate void delegateButtonRefresh(bool value);
        #endregion

        #region //member's
        private CMain _main = null;
        #endregion
        private bool _autoRefresh = true;
        
        #region //property's
        private IPortControl _port;
        public IPortControl Port
        {
            get { return _port; }
            set
            {
                _port = value;
            }
        }

        public CMain Main
        {
            get { return _main; }
            set
            {
                _main = value;
                foreach (IPortControl portControl in _main.Ports.Values)
                {
                    if (portControl.ControlName != this.FormText) continue;

                    //SendButtonControl(portControl.UnloadDataRequest);

                    //portControl.OnPortUnloadDataReport += new delegatePortUnloadDataReport(portControl_OnPortUnloadDataReport);
                }
                this.Text = _main.SystemConfig.EQPID + " PORT INFOMATION DISPLAY";
                comboPortSelectList();
                SetDataGridView(_main);
                SlotInfoShow(_main);
            }
        }
        #endregion

        #region //event
        public delegatePopupFormClosed OnPopupFormClosed = null;
        #endregion

        #region //constructor's
        public FormPortInfo()
        {
            InitializeComponent();
            this.pnlButtonBack.Visible = false;
        }
        public FormPortInfo(string portName)
        {
            InitializeComponent();
            this.pnlButtonBack.Visible = false;
            this.FormText = portName;
            this.CloseButtonEnable = true;
            this.ButtonType = PopUpButton.Close;
            this.ButtonSize = new Size(70, 25);

            //if (this.FormText.Contains("BUFFER02") || this.FormText.Contains("BUFFER01"))
            //{
            //    this.lblSlotNumber.Visible = true;
            //    this.cmbSlotNumber.Visible = true;
            //    this.btnSend.Visible = true;
            //}

        }
        public FormPortInfo(IPortControl oPort)
        {
            InitializeComponent();
            this.pnlButtonBack.Visible = false;
            this.FormText = oPort.ControlName;

            //2013-12-05  by JSJ 주석 처리함.
            //this.CloseButtonEnable = true;
            //this.ButtonType = PopUpButton.Close;
            //this.ButtonSize = new Size(70, 25);

            //if (this.FormText.Contains("BUFFER02") || this.FormText.Contains("BUFFER01"))
            //{
            //    this.lblSlotNumber.Visible = true;
            //    this.cmbSlotNumber.Visible = true;
            //    this.btnSend.Visible = true;
            //}

        }
        #endregion




        private void comboPortSelectList()
        {
            if (_main == null)
                return;

            this.cbPortSelect.Items.Clear();
            this.cbPortSelect.Items.Add(":::포트선택:::");
            foreach (IPortControl oPort in _main.Ports.Values)
            {
                this.cbPortSelect.Items.Add(oPort.ControlName);
            }


        }











        #region //method's

        private void CheckUnloadRequest()
        {

            string strBitAttribute = string.Empty;
            IPortControl port = null;

            switch (this.FormText)
            {
                case "BUFFER02":
                    strBitAttribute = "O_BUFFER02_UNLOAD_REQUEST";
                    break;
                case "BUFFER01":
                    strBitAttribute = "O_BUFFER01_UNLOAD_REQUEST";
                    break;
                default:
                    break;
            }
            foreach (IPortControl butterControl in _main.Ports.Values)
            {
                if (butterControl.ControlName != this.FormText) continue;

                port = butterControl as IPortControl;
                //port.OnPortUnloadDataReport -= new delegatePortUnloadDataReport(portControl_OnPortUnloadDataReport);
            }

            //foreach (CPLCControlProperies oPlc in _main.Plcs.Values)
            //{
            //    if (oPlc.PLCControlName.Contains(port.ConnectEQP) && oPlc.PLCAttribute.Contains(strBitAttribute))
            //    {
            //        bool retUnloadRequest = _main.MelsecManager.MelsecNetBitRead(port.ControlName, port.ControlName, oPlc.PLCArea, enumDeviceType.B, 1);

            //        if (retUnloadRequest)
            //            _main.MelsecManager.MelsecNetBitOnOff(port.ControlName, port.ControlName, oPlc.PLCArea, enumDeviceType.B, false);


            //    }
            //}
        }

        public void SetDataGridView(CMain main)
        {
            if (_autoRefresh)
            {
                try
                {
                    if (this.FormText.ToString()!="")
                    {

                        //if (this.tabGlassData.InvokeRequired)
                        //{
                        //    delegateGridViewRefresh gridViewRefresh = new delegateGridViewRefresh(SetDataGridView);
                        //    this.BeginInvoke(gridViewRefresh, main);
                        //}
                        //else
                        //{
                        //_port
                        DataGridViewRow row = null;
                        foreach (IPortControl portControl in main.Ports.Values)
                        {
                            if (portControl.ControlName == this.FormText)
                            {
                                if (dgvPortInfo.Rows.Count == 0)
                                {
                                    dgvPortInfo.Rows.Add(portControl.PortMap.Count);
                                }
                                //int i = 0;
                                //Console.WriteLine(portControl.ControlName);
                                foreach (IPortSlot slot in portControl.PortMap.Values)
                                {
                                    row = dgvPortInfo.Rows[slot.SlotNumber - 1];
                                    row.Cells["colSlotNumber"].Value = slot.SlotNumber.ToString();
                                    row.Cells["colGlassExist"].Value = (slot.GlassExist) ? true : false;
                                    //if (portControl.PortKind == enumPortKind.BPSTK)
                                    //{
                                    //    row.Cells["colOPType"].Value = slot.PortSlotOPType.ToString();
                                    //}
                                    //else
                                    //{
                                    // row.Cells["colOPType"].Value = "MASK";
                                    //}
                                    row.Cells["colGlassCode"].Value = slot.SlotGlassCode.ToString();
                                    //Console.WriteLine(i);
                                    //i++;
                                    if (slot.GlassExist)
                                    {
                                        if (GetGlassDataExistCheck(main, slot.SlotGlassCode.ToString()))
                                        {
                                            if (main.GlassDatas[Convert.ToInt32(slot.SlotGlassCode.ToString())].LotID != null)
                                            {
                                                row.Cells["colLotID"].Value = main.GlassDatas[Convert.ToInt32(slot.SlotGlassCode.ToString())].LotID.ToString();
                                            }
                                            if (main.GlassDatas[Convert.ToInt32(slot.SlotGlassCode.ToString())].GlassID != null)
                                            {
                                                row.Cells["colGlassID"].Value = main.GlassDatas[Convert.ToInt32(slot.SlotGlassCode.ToString())].GlassID.ToString();
                                            }

                                            if (main.GlassDatas[Convert.ToInt32(slot.SlotGlassCode.ToString())].HostRecipeNumber != null)
                                            {
                                                row.Cells["colRecipe"].Value = main.GlassDatas[Convert.ToInt32(slot.SlotGlassCode.ToString())].HostRecipeNumber.ToString();
                                            }
                                            if (main.GlassDatas[Convert.ToInt32(slot.SlotGlassCode.ToString())].GlassJudge != null)
                                            {
                                                row.Cells["colGlassJudge"].Value = main.GlassDatas[Convert.ToInt32(slot.SlotGlassCode.ToString())].GlassJudge.ToString();
                                            }
                                            if (main.GlassDatas[Convert.ToInt32(slot.SlotGlassCode.ToString())].GlassType != null)
                                            {
                                                row.Cells["colGlassType"].Value = main.GlassDatas[Convert.ToInt32(slot.SlotGlassCode.ToString())].GlassType.ToString();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        row.Cells["colLotID"].Value = "";
                                        row.Cells["colGlassID"].Value = "";
                                        row.Cells["colRecipe"].Value = "";
                                        row.Cells["colGlassJudge"].Value = "";
                                        row.Cells["colGlassType"].Value = "";

                                    }

                                }
                            }
                            //}
                        }
                    }
                }
                catch (Exception ex)
                {
                    CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "ERROR", ex));
                }
            }
        }

        private bool GetGlassDataExistCheck(CMain main, string glassCode)
        {
            bool bReturnValue = false;
            if (string.IsNullOrEmpty(glassCode)) return false;
            if (main.GlassDatas.ContainsKey(Convert.ToInt32(glassCode)))
            {
                bReturnValue = true;
            }
            return bReturnValue;

        }

        private void SlotInfoShow(CMain main)
        {
            //if (this.cmbSlotNumber.InvokeRequired)
            //{
            //    delegateGridViewRefresh SlotRefresh = new delegateGridViewRefresh(SlotInfoShow);
            //    this.BeginInvoke(SlotRefresh, main);
            //}
            //else
            //{
            //    if (this.FormText.Contains("BUFFER02") || this.FormText.Contains("BUFFER01"))
            //    {
            //        IPortControl port = null;
            //        foreach (IPortControl portControl in _main.Ports.Values)
            //        {
            //            if (portControl.ControlName != this.FormText) continue;

            //            port = portControl as IPortControl;
            //        }

            //        cmbSlotNumber.Items.Clear();

            //        foreach (IPortSlot slot in port.PortMap.Values)
            //        {
            //            if (slot.GlassExist)
            //            {
            //                cmbSlotNumber.Items.Add(slot.SlotGlassCode);
            //            }
            //        }

            //        if (cmbSlotNumber.Items.Count != 0)
            //            cmbSlotNumber.Text = cmbSlotNumber.Items[0].ToString();
            //    }
            //}
        }

        private void SendButtonControl(bool value)
        {
            //if (this.btnSend.InvokeRequired)
            //{
            //    delegateButtonRefresh buttonRefresh = new delegateButtonRefresh(SendButtonControl);
            //    if (this.Visible)
            //        this.BeginInvoke(buttonRefresh, value);
            //}
            //else
            //{
            //    if (!value)
            //    {
            //        if (this.btnSend != null)
            //        {
            //            this.btnSend.Enabled = true;
            //        }
            //    }
            //    else
            //        if (this.btnSend != null)
            //        {
            //            this.btnSend.Enabled = false;
            //        }
            //}
        }
        #endregion

        #region //event's 처리기

        private void portControl_OnPortUnloadDataReport(object sender, bool unloadDataReport)
        {
            try
            {
                if (!unloadDataReport)
                    SendButtonControl(unloadDataReport);

            }
            catch (Exception ex)
            {
                CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "ERROR", ex));
            }
        }

        private void FormPortInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                CheckUnloadRequest();
                for (int i = 0; i < this.Controls.Count; i++)
                {
                    this.Controls.Remove(this.Controls[i]);
                }


                if (OnPopupFormClosed != null)
                    OnPopupFormClosed(sender);
            }
            catch (Exception ex)
            {
                CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "ERROR", ex));
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {

        }

        private void oTimeOut_Finished(CTimeout timeoutObject)
        {
            try
            {
                if (this.IsDisposed) return;

                if (timeoutObject.Trigger is ITimeoutResource)
                {
                    //CPLCControlProperies oPlc = timeoutObject.Trigger as CPLCControlProperies;

                    //if (timeoutObject.Result == TimeoutResult.Success)
                    //{
                    //    _main.MelsectNetBitOnOff(oPlc.PLCControlName, oPlc.PLCAttribute, oPlc.PLCArea, false);
                    //}


                    //if (timeoutObject.Result == TimeoutResult.Failure)
                    //{
                    //    _main.MelsectNetBitOnOff(oPlc.PLCControlName, oPlc.PLCAttribute, oPlc.PLCArea, false);
                    //    SendButtonControl(false);
                    //}

                }
            }
            catch (Exception ex)
            {
                CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "ERROR", ex));
            }
        }
        #endregion

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

        private void cbPortSelect_SelectedValueChanged(object sender, EventArgs e)
        {

            if (this.cbPortSelect.SelectedItem.ToString() == ":::포트선택:::")
            {
                MessageBox.Show("포트를 선택하세요");
                return;
            }
            if (this.cbPortSelect.SelectedItem.ToString() != "")
           {
               this.FormText = this.cbPortSelect.SelectedItem.ToString();
               SetDataGridView(_main);
           }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            SetDataGridView(_main);
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void FormPortInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
