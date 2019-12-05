using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SOFD.Gui.Widget;
using SOFD.Global.Manager;

namespace Widgets
{
    public partial class ucCimStatus : UCBaseObject
    {
        public ucCimStatus()
        {
            InitializeComponent();
        }

        public class CCimStatusData
        {
            public string EqpID { get; set; }
            /// <summary>
            /// IDLE,RUN,DOWN,MAINT
            /// </summary>
            public string Status { get; set; }
            public bool BCConnection { get; set; }
            public bool HostConnection { get; set; }
            public string ConnectionStatus { get; set; }
            public string EqpControl { get; set; }
            public bool EqpLink { get; set; }
            public bool AutoMode { get; set; }
            public string InlineLinkMode { get; set; }
            public bool CIMConnectionMode { get; set; }
            public int EqpMode { get; set; }
            public bool UnitSkipMode { get; set; }
            public bool RobotPitchMode { get; set; }
            public bool CSTUnloadMode { get; set; }
            public bool AutoRecipeChange { get; set; }
            public string CurrentPPID { get; set; }
            public string CurrentRecipeID { get; set; }
            public string CurrentProdID { get; set; }
            public CCimStatusData()
            {
                ConnectionStatus = "";
            }

        }
        CCimStatusData _cimStatusData = new CCimStatusData();
        public override bool Init()
        {
            base.Init();

            CUpdateHandler<CCimStatusData> UpdateHandler = null;
            UpdateHandler = new CUpdateHandler<CCimStatusData>(this, "ucCimStatus", ref _cimStatusData);
            UpdateHandler.OnUpdateData = new CUpdateHandler<CCimStatusData>.UpdateDataHandler(InvokeUpdateData);
            UpdateHandler.Subscribe();
            return true;
        }

        private void InvokeUpdateData(bool noHandle, CCimStatusData cimStatusData)
        {
            if(string.IsNullOrEmpty(cimStatusData.EqpID) == false)
                this.lblEqpID.Text = cimStatusData.EqpID;
            //1 : IDLE, 2 : RUN, 3 : DOWN, 4 : PM, 5 : STOP
            switch (cimStatusData.Status)
            {   
                case "1":
                    this.lblStatus.BackColor = Color.Yellow;
                    this.lblStatus.Text = "IDLE";
                    break;
                case"2":
                    this.lblStatus.BackColor = Color.Lime;
                    this.lblStatus.Text = "RUN";
                    break;
                case"3":
                    this.lblStatus.BackColor = Color.Red;
                    this.lblStatus.Text = "DOWN";
                    break;
                case "4":
                    this.lblStatus.BackColor = Color.Violet;
                    this.lblStatus.Text = "PM";
                    break;
                case "5":
                    this.lblStatus.BackColor = Color.Yellow;
                    this.lblStatus.Text = "STOP";
                    break;
                default:
                    this.lblStatus.BackColor = Color.White;
                    break;
            }

            this.lblBCConnection.Text = cimStatusData.BCConnection ? "CONNECT" : "NOT CONNECT";
            this.lblBCConnection.BackColor = cimStatusData.BCConnection ? Color.Lime : Color.Red;


            if (cimStatusData.ConnectionStatus == "Listen")
            {
                this.lblHostConnection.Text = cimStatusData.HostConnection ? "CONNECT" : "WAIT EQP";
                this.lblHostConnection.BackColor = cimStatusData.HostConnection ? Color.Lime : Color.Yellow;
            }
            else
            {
                this.lblHostConnection.Text = cimStatusData.HostConnection ? "CONNECT" : "NOT CONNECT";
                this.lblHostConnection.BackColor = cimStatusData.HostConnection ? Color.Lime : Color.Red;
            }

            if (cimStatusData.CIMConnectionMode)
            {
                this.lblEqpControl.Text = "RUN";
                this.lblEqpLink.BackColor = cimStatusData.EqpLink ? Color.Lime : Color.Red;
            }
            else
            {
                this.lblEqpControl.Text = "NOT RUN";
                this.lblEqpLink.BackColor = Color.Red;                
            }

            

            this.label2.Text = cimStatusData.AutoRecipeChange ? "ENABLE" : "DISABLE";
            this.label2.BackColor = cimStatusData.AutoRecipeChange ? Color.Lime : Color.Red;
            this.lblCurrentPPID.Text = cimStatusData.CurrentPPID;
            this.lblCurrentRECIPEID.Text = cimStatusData.CurrentRecipeID;

            string eqpMode = cimStatusData.EqpMode.ToString();
            switch (cimStatusData.EqpMode)
            {
                case 1:
                    eqpMode = "NORMAL";
                    break;
                case 13:
                    eqpMode = "COLD RUN";
                    break;
                case 14:
                    eqpMode = "FORCE CLEAN OUT";
                    break;
                default:
                    break;
            }
            this.lblEquipmentMode.Text = eqpMode;
            this.lblEquipmentMode.BackColor = Color.White;
            this.lblEqpAutoMode.Text = cimStatusData.AutoMode ? "AUTO" : "MANUAL";
            this.lblEqpAutoMode.BackColor = cimStatusData.AutoMode ? Color.Lime : Color.Yellow;
        }
    }
}
