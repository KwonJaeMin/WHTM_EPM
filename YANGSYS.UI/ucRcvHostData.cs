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
    public partial class ucRcvHostData : UCBaseObject
    {
        public ucRcvHostData()
        {
            InitializeComponent();
        }

        public class CRcvHostData
        {
            public string RcvHostData { get; set; }
        }

        CUpdateHandler<CRcvHostData> UpdateHandler = null;
        CRcvHostData _rcvHostData = new CRcvHostData();
        public override bool Init()
        {
            base.Init();

            UpdateHandler = new CUpdateHandler<CRcvHostData>(this, "ucRcvHostData", ref _rcvHostData);
            UpdateHandler.OnUpdateData = new CUpdateHandler<CRcvHostData>.UpdateDataHandler(InvokeUpdateData);
            UpdateHandler.Subscribe();
            return true;
        }

        private void InvokeUpdateData(bool noHandle, CRcvHostData cRcvHostData)
        {
            this.lblRcvHostData.Text = cRcvHostData.RcvHostData;
        }
    }
}
