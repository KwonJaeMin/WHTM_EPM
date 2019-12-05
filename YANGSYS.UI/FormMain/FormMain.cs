using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SOFD.Global.Manager;
using SOFD.Gui.Dialog;

namespace YANGSYS.UI.WHTM
{
    public partial class FormMain : Form
    {
        public frmAlarm _frmAlarm = null;
        public frmCIMMessageDIsplay _frmCIMMessageDIsplay = null;
        public frmGlassData _frmGlassInfoForm = null;
        public frmGlassDataWHTM _frmGlassInfoFormWHTM = null;
        public FormMain()
        {
            InitializeComponent();
            _frmAlarm = new frmAlarm();
            _frmCIMMessageDIsplay = new frmCIMMessageDIsplay();
            _frmGlassInfoForm = new frmGlassData();
            _frmGlassInfoFormWHTM = new frmGlassDataWHTM();
            Init();
        }
        private class CAlarmData
        {
            public List<string> Alarm { get; set; }

            public CAlarmData()
            {
                Alarm = new List<string>();
            }
            public bool SetValue<T>(string key, T value)
            {
                return true;
            }
        }
        private CAlarmData _alarmData = new CAlarmData();
        CUpdateHandler<CAlarmData> UpdateHandler = null;
        public bool Init()
        {
            //base.Init();

            UpdateHandler = new CUpdateHandler<CAlarmData>(this, "CurrentAlarm", ref _alarmData);
            UpdateHandler.OnUpdateData = new CUpdateHandler<CAlarmData>.UpdateDataHandler(InvokeUpdateData);
            UpdateHandler.Subscribe();

            UpdateMessageHandler = new CUpdateHandler<CListData>(this, "CIMMessage", ref _messageData);
            UpdateMessageHandler.OnUpdateData = new CUpdateHandler<CListData>.UpdateDataHandler(InvokeUpdateMessageData);
            UpdateMessageHandler.Subscribe();

            UpdateMessageHistoryHandler = new CUpdateHandler<CListData>(this, "CIMMessageHistory", ref _messageHistoryData);
            UpdateMessageHistoryHandler.OnUpdateData = new CUpdateHandler<CListData>.UpdateDataHandler(InvokeUpdateMessageHistoryData);
            UpdateMessageHistoryHandler.Subscribe();

            UpdateGlassInfoDisplayHandler = new CUpdateHandler<CGlassInfoDisplayData>(this, "GlassInfoDisplay", ref _glassInfoDisplayData);
            UpdateGlassInfoDisplayHandler.OnUpdateData = new CUpdateHandler<CGlassInfoDisplayData>.UpdateDataHandler(InvokeUpdateGlassData);
            UpdateGlassInfoDisplayHandler.Subscribe();
            return true;
        }

        private delegate void UpdateHandler2();

        private void InvokeUpdateData(bool noHandle, CAlarmData titleData)
        {
            if (titleData == null)
                return;

            UpdateHandler.Data = titleData;
            //if (noHandle == false)
            //{
            //if (this.InvokeRequired)
            //{
                //this.Invoke(UpdateHandler.OnUpdateData, noHandle, titleData);
            //}
            //else
            //{
                UpdateHandler2 del = new UpdateHandler2(ShowAlarmForm);
                this.Invoke(del);
            //}
            ////}
        }

        #region CIM Message
        private class CListData
        {
            public List<string> List { get; set; }

            public CListData()
            {
                List = new List<string>();
            }
            public bool SetValue<T>(string key, T value)
            {
                return true;
            }
        }
        private CListData _messageData = new CListData();
        CUpdateHandler<CListData> UpdateMessageHandler = null;

        private void InvokeUpdateMessageData(bool noHandle, CListData titleData)
        {
            if (titleData == null)
                return;

            UpdateMessageHandler.Data = titleData;
            //if (noHandle == false)
            //{
            if (this.InvokeRequired)
            {
                this.Invoke(UpdateMessageHandler.OnUpdateData, noHandle, titleData);
            }
            else
            {
                UpdateHandler2 del = new UpdateHandler2(ShowMessageForm);
                this.Invoke(del);
            }
            //}
        }

        private CListData _messageHistoryData = new CListData();
        CUpdateHandler<CListData> UpdateMessageHistoryHandler = null;
        private void InvokeUpdateMessageHistoryData(bool noHandle, CListData titleData)
        {
            if (titleData == null)
                return;

            UpdateMessageHistoryHandler.Data = titleData;

            UpdateMessageHistory();
            //if (noHandle == false)
            //{
            //if (this.InvokeRequired)
            //{
            //    this.Invoke(UpdateMessageHistoryHandler.OnUpdateData, noHandle, titleData);
            //}
            //else
            //{
            //    UpdateHandler2 del = new UpdateHandler2(UpdateMessageHistory);
            //    //this.Invoke(del);
            //}
            //}
        }
        #endregion

        #region GlassInfoDisplay
        private class CGlassInfoDisplayData
        {
            public int GlassCount { get; set; }
            public Dictionary<string,string> Data { get; set; }
            public Dictionary<string, string> Data2 { get; set; }

            public CGlassInfoDisplayData()
            {
                GlassCount = 1;
                Data = new Dictionary<string, string>();
                Data2 = new Dictionary<string, string>();
            }
            public bool SetValue<T>(string key, T value)
            {
                return true;
            }
        }
        private CGlassInfoDisplayData _glassInfoDisplayData = new CGlassInfoDisplayData();
        CUpdateHandler<CGlassInfoDisplayData> UpdateGlassInfoDisplayHandler = null;

        private void InvokeUpdateGlassData(bool noHandle, CGlassInfoDisplayData data)
        {
            if (data == null)
                return;

            UpdateGlassInfoDisplayHandler.Data = data;
            //if (noHandle == false)
            //{
            if (this.InvokeRequired)
            {
                this.Invoke(UpdateMessageHandler.OnUpdateData, noHandle, data);
            }
            else
            {
                UpdateHandler2 del = new UpdateHandler2(ShowGlassInfoForm);
                this.Invoke(del);
            }
            //}
        }
        #endregion
        public void ShowAlarmForm()
        {
            List<List<string>> temp = new List<List<string>>();
            temp.Add(_alarmData.Alarm);

            _frmAlarm.RefreshDgvAlarm(temp);
            if (_frmAlarm.Visible == false)
                _frmAlarm.Show(this);

            _frmAlarm.BringToFront();
        }

        public void ShowMessageForm()
        {
            List<List<string>> temp = new List<List<string>>();
            temp.Add(_messageData.List);

            _frmCIMMessageDIsplay.RefreshDgvList(temp);
            if (_frmCIMMessageDIsplay.Visible == false)
                _frmCIMMessageDIsplay.Show(this);

            _frmCIMMessageDIsplay.BringToFront();
        }

        public void UpdateMessageHistory()
        {
            List<List<string>> temp = new List<List<string>>();
            temp.Add(_messageHistoryData.List);

            _frmCIMMessageDIsplay.UpdateHistory(temp);

        }

        public void ShowGlassInfoForm()
        {
            string option = "WHTM";
            if (option != "WHTM")
            {
                _frmGlassInfoForm.RefreshDgvList(_glassInfoDisplayData.Data);
                if (_frmGlassInfoForm.Visible == false)
                    _frmGlassInfoForm.Show(this);

                _frmGlassInfoForm.BringToFront();
            }
            else
            {
                _frmGlassInfoFormWHTM.RefreshDgvList(new List<Dictionary<string, string>>(){_glassInfoDisplayData.Data, _glassInfoDisplayData.Data2}, _glassInfoDisplayData.GlassCount);
                if (_frmGlassInfoFormWHTM.Visible == false)
                    _frmGlassInfoFormWHTM.Show(this);

                _frmGlassInfoFormWHTM.BringToFront();
            }
        }

        private void ucMenu1_OnRequestParentService(string sService, object[] args)
        {
            switch (sService)
            {
                case "MAIN_VIEW":
                    this.ucMain1.Visible = true;
                    this.ucMain1.BringToFront();
                    break;
                case "GLASS_DATA_VIEW":
                    if (_frmGlassInfoFormWHTM.Visible == false)
                        _frmGlassInfoFormWHTM.Show(this);

                    _frmGlassInfoFormWHTM.BringToFront();
                    break;
                case "RECIPE_VIEW":
                    this.ucRecipePanel1.Visible = true;
                    this.ucRecipePanel1.BringToFront();
                    break;
                case "LINK_SIGNAL_VIEW":
                    this.ucLinkSignalPanel1.Visible = true;
                    this.ucLinkSignalPanel1.BringToFront();
                    break;
                case "LOG_VIEW":
                    this.ucLog1.Visible = true;
                    this.ucLog1.BringToFront();
                    break;
                case "CIM_MSG_VIEW":
                    if (_frmCIMMessageDIsplay.Visible == false)
                        _frmCIMMessageDIsplay.Show(this);

                    _frmCIMMessageDIsplay.BringToFront();
                    break;
                default:
                    MessageBox.Show(string.Format("{0} {1}", sService, "요청 처리가 등록 되지 않았습니다.", "화면 표시 이상", MessageBoxButtons.OK, MessageBoxIcon.Warning));
                    break;
            }
        }

        private void tsmiProgramList_Click(object sender, EventArgs e)
        {
            SOFD.Gui.Dialog.frmProgramStatusView form = new SOFD.Gui.Dialog.frmProgramStatusView();
            form.Show(this);
        }

        private void FormMain_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Shift && e.KeyCode == Keys.F10)
            {
                menuStrip1.Visible = !menuStrip1.Visible;
            }
        }

        private void FormMain_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void FormMain_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
