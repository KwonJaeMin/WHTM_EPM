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
    public partial class ucIndexStatus : UCBaseObject
    {
        public ucIndexStatus()
        {
            InitializeComponent();
        }

        public class CIndexStatusData
        {
            public bool MelsecConnection { get; set; } //, 
            public bool IndexerControl { get; set; } //ONLINE, OFFLINE
            public string From { get; set; }
            public string To { get; set; }

            public bool RunningMode { get; set; }

        }

        CUpdateHandler<CIndexStatusData> UpdateHandler = null;
        CIndexStatusData _indexStatusData = new CIndexStatusData();
        public override bool Init()
        {
            base.Init();

            UpdateHandler = new CUpdateHandler<CIndexStatusData>(this, "ucIndexStatus", ref _indexStatusData);
            UpdateHandler.OnUpdateData = new CUpdateHandler<CIndexStatusData>.UpdateDataHandler(InvokeUpdateData);
            UpdateHandler.Subscribe();
            return true;
        }

        private void InvokeUpdateData(bool noHandle, CIndexStatusData indexStatusData)
        {
            this.lblMelsecConnect.Text = indexStatusData.MelsecConnection ? "CONNECT" : "NOT CONNECT";
            this.lblMelsecConnect.BackColor = indexStatusData.MelsecConnection ? Color.Lime : Color.Red;
            this.lblIndexerControl.Text = indexStatusData.IndexerControl ? "ONLINE" : "OFFLINE";
            this.lblIndexerControl.BackColor = indexStatusData.IndexerControl ? Color.Lime : Color.White;
            this.lblFrom.Text = indexStatusData.From;
            this.lblTo.Text = indexStatusData.To;
            this.lblRunningMode.Text = indexStatusData.RunningMode ? "RUNNING" : "NOT RUNNING";
            this.lblRunningMode.BackColor = indexStatusData.RunningMode ? Color.Lime : Color.White;
        }

    }
}
