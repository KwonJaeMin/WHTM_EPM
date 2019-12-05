using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SOFD.Gui.Window;
using SOFD.Logger;

using SOFD.Global.Manager;
using SOFD.Global.Interface;


namespace YANGSYS.UI.WHTM
{

    public partial class ucTitle : UCFrame
    {
        #region //event's handler

        private delegate void DisplayTextHandler(string gubun, string strValue);
        #endregion

        #region //member's

        private System.Windows.Forms.Timer cimTimer = new Timer();
        private System.Windows.Forms.Timer titleTimer = new Timer();
        //private Timer _displayTimer;

        /// <summary>
        /// 호기명 표시하기
        /// </summary>
        //private string _equipmentID = "";
        private bool plcConnect = false;
        private int aliveNoReply = 0; // 무응답 횟수

        #endregion

        #region //property's

        //public string EquipmentID
        //{
        //    get { return _equipmentID; }
        //    set
        //    {
        //        _equipmentID = value;
        //        DisplayText("EquipmentID", value);
        //    }
        //}

        //public string Version
        //{
        //    set
        //    {
        //        DisplayText("Version", value);
        //    }
        //}

        //public string ShortVersion
        //{
        //    get
        //    {
        //        return lblShortVersion.Text;
        //    }
        //    set
        //    {
        //        lblShortVersion.Text = value;
        //    }
        //}

        //public string ProjectName
        //{
        //    get
        //    {
        //        return lblProjectName.Text;
        //    }
        //    set
        //    {
        //        lblProjectName.Text = value;
        //    }
        //}

        #endregion

        #region //constructor's

        public ucTitle()
        {
            InitializeComponent();

            cimTimer.Interval = 1000;// 1초 마다 화면에 시간을 갱신한다.
            cimTimer.Enabled = true;
            cimTimer.Tick += new EventHandler(cimTimer_Tick);
        }

        #endregion

        #region //method's

        //private int diplayTimerCnt = 0;

        private delegate void delegateCrossThreadInvoke();

        #region 마우스 드래그시 창 이동, 더블클릭시 전환 2013-04-18 김동광

        bool windowMaximized = false;

        private void plTopCenter_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (windowMaximized == false)
            {
                windowMaximized = true;
            }
            else
            {
                windowMaximized = false;
            }
        }

        #endregion

        void OnMenuButtonCliceked(object sender, EventArgs e)
        {
            try
            {
                string service = this.Name.ToString();
                List<object> args = new List<object>();
                
                if (sender is Control)
                {
                    Control control = sender as Control;
                    args.Add(control.Name);

                    switch (control.Name)
                    {
                        case "lblCurrentUser":
                            args.Add(lblCurrentUser.Text);
                            break;
                        case "btnClose":
                            ACommand command = CUIManager.Inst.GetCommand("TITLE");
                            command.SubCommandName = "SHUTDOWN";
                            command.Execute();
                            break;
                    }
                }

                this.OnRequest(this.Name.ToString(), args.ToArray());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void CimAliveTimer_Tick(object sender, EventArgs e)
        {
            if (aliveNoReply == 0)
            {
                plcConnect = true;
            }
            else
            {
                if (aliveNoReply > 10)
                {
                    // 무응답횟수가 초과 되면 UI변경.
                    plcConnect = false;
                }
            }

            //Console.WriteLine(DateTime.Now.ToString() + " aliveNoReply:" + aliveNoReply + " BeforeCimAlvie:" + BeforeCimAlvie + " plcConnect:" + plcConnect);
            aliveNoReply++;
            // 응답횟수는 무조건 증가 하도록 한다.
            // 초기화는 응답이 있는 메서드에서 하도록한다.


            // UI가 너무 자주 변경되면 부하가 예상됨으로
            // 기존과 같다면 변경하지 않는다.
            //if (BeforeCimAlvie != plcConnect)
            //{
            if (plcConnect == true)
            {
                // this.plPlcConnect.BackColor = Color.Lime; // CIM DISABLE OFF인 상태가 연결된 상태로 판단
            }
            else
            {
                //this.plPlcConnect.BackColor = Color.Red;
            }
            //}
        }

        public void PlcAliveChecked(bool value)
        {
            //BeforeCimAlvie = value;
            // 이벤트가 티면 무조건 응답으로 간주한다.
            aliveNoReply = 0;
        }

        //public void DisplayText(string gubun, string strValue)
        //{
        //    try
        //    {
        //        if (this.InvokeRequired)
        //        {
        //            this.BeginInvoke(new DisplayTextHandler(DisplayText), gubun, strValue);
        //        }
        //        else
        //        {
        //            if (gubun == "EquipmentID")
        //            {
        //                this.lblEqpID.Text = strValue;
        //            }
        //            else if (gubun == "Version")
        //            {
        //                this.lblShortVersion.Text = strValue;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "EMP", ex));
        //    }
        //}

        void cimTimer_Tick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            this.lbTimeyyymmdd.Text = string.Format("{0:D4}-{1:D2}-{2:D2}"
                , DateTime.Now.Year
                , DateTime.Now.Month
                , DateTime.Now.Day
                );
            this.lbTimehhmmss.Text = string.Format("{0:D2}:{1:D2}:{2:D2}"
                , DateTime.Now.Hour
                , DateTime.Now.Minute
                , DateTime.Now.Second
                );
        }

        #endregion

        private class CTitleData
        {
            public string Title { get; set; }
            public string ShortVersion { get; set; }
            public string DispSiteName { get; set; }
            public string ProjectName { get; set; }
            public string SiteName { get; set; }
            public string UserName { get; set; }
            public string SystemMode { get; set; }
            public string CIMMode { get; set; }
            public DateTime CurrentDataTime;

            public CTitleData()
            {
                Title = "";
                ShortVersion = "";
                DispSiteName = "";
                ProjectName = "";
                SiteName = "";
                UserName = "";
                CurrentDataTime = DateTime.Now;
            }
            public bool SetValue<T>(string key, T value)
            {
                return true;
            }
        }

        private CTitleData _titleData = new CTitleData();
        CUpdateHandler<CTitleData> UpdateHandler = null;
        public override bool Init()
        {
            base.Init();

            UpdateHandler = new CUpdateHandler<CTitleData>(this, "ucTitle", ref _titleData);
            UpdateHandler.OnUpdateData = new CUpdateHandler<CTitleData>.UpdateDataHandler(InvokeUpdateData);
            UpdateHandler.Subscribe();
            return true;
        }

        private void InvokeUpdateData(bool noHandle, CTitleData titleData)
        {
            if (titleData == null)
                return;

            UpdateHandler.Data = titleData;
            if (noHandle == false)
            {
                lblCurrentUser.Text = titleData.UserName;
                lblSite.Text = titleData.SiteName;
                lblProjectName.Text = titleData.ProjectName;
                lblShortVersion.Text = titleData.ShortVersion;
                lblEqpID.Text = titleData.Title;
                lblSite.Text = titleData.DispSiteName;
                lblSimulatorMode.Visible = titleData.SystemMode == "SimulationMode";
                lblCimMode.Text = titleData.CIMMode == "2" ? "CIM ON" : "CIM OFF";
                lblCimMode.BackColor = titleData.CIMMode == "2" ? Color.Lime : Color.Red;
                lblCimMode.ForeColor = titleData.CIMMode == "2" ? Color.Black : Color.White;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            InvokeUpdateData(false, UpdateHandler.Data as CTitleData);
        }
    }
}
