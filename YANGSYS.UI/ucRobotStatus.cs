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
    public partial class ucRobotStatus : UCBaseObject
    {
        public ucRobotStatus()
        {
            InitializeComponent();
        }

        public class CRobotStatus
        {
            public string Command { get; set; }
            public bool Enable { get; set; }
            public bool Origin { get; set; }
            public bool Busy { get; set; }
            public bool Pause { get; set; }
            public bool Alarm { get; set; }
            public bool UpperHandExist { get; set; }
            public bool LowerHandExist { get; set; }
        }
        CRobotStatus _robotStatus = new CRobotStatus();
        public override bool Init()
        {
            base.Init();

            CUpdateHandler<CRobotStatus> UpdateHandler = null;
            UpdateHandler = new CUpdateHandler<CRobotStatus>(this, "ucRobotStatus", ref _robotStatus);
            UpdateHandler.OnUpdateData = new CUpdateHandler<CRobotStatus>.UpdateDataHandler(InvokeUpdateData);
            UpdateHandler.Subscribe();
            return true;
        }

        private void InvokeUpdateData(bool noHandle, CRobotStatus data)
        {
            this.lblCommand.Text = data.Command;
            this.lblEnable.Text = data.Enable ? "DISABLE" : "ENABLE";
            this.lblEnable.BackColor = data.Enable ? Color.Lime : Color.Red;
            this.lblBusy.Text = data.Busy ? "BUSY" : "IDLE";
            this.lblBusy.BackColor = data.Busy ? Color.Lime : Color.Yellow;
            this.lblPause.BackColor = data.Pause ? Color.Yellow : Color.Silver;
            this.lblAlarm.BackColor = data.Alarm ? Color.Red : Color.Silver;
            this.lblUpperGlassExist.Text = data.UpperHandExist ? "EXIST" : "NOT EXIST";
            this.lblUpperGlassExist.BackColor = data.UpperHandExist ? Color.Lime : Color.Silver;
            this.lblLowerGlassExist.Text = data.LowerHandExist ? "EXIST" : "NOT EXIST";
            this.lblLowerGlassExist.BackColor = data.LowerHandExist ? Color.Lime : Color.Silver;

        }

    }
}
