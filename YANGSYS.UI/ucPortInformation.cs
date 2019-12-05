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
    public partial class ucPortInformation : UCBaseObject
    {
        public ucPortInformation()
        {
            InitializeComponent();
        }

        public void Port1DataInput(string portData)
        {
            string[] portSplitData = portData.Split(',');
            
            this.DataGridView1.Rows.Add();
            DataGridViewRow oRow = DataGridView1.Rows[DataGridView1.Rows.Count-1];

            for (int i = 0; i < oRow.Cells.Count; i++)
            {                
                oRow.Cells[i].Value = portSplitData[i+1].ToString();
            }
        }

        public void Port2DataInput(string portData)
        {
        }

        public class CPortInformationData
        {
            public bool portConvert { get; set; }
            public string port1Data { get; set; }
            public string port2Data { get; set; }
        }

        CUpdateHandler<CPortInformationData> UpdateHandler = null;
        CPortInformationData _portInformationData = new CPortInformationData();
        public override bool Init()
        {
            base.Init();

            UpdateHandler = new CUpdateHandler<CPortInformationData>(this, "ucPortInformation", ref _portInformationData);
            UpdateHandler.OnUpdateData = new CUpdateHandler<CPortInformationData>.UpdateDataHandler(InvokeUpdateData);
            UpdateHandler.Subscribe();
            return true;
        }

        private void InvokeUpdateData(bool noHandle, CPortInformationData data)
        {
            if (data.portConvert)
            {
                Port1DataInput(data.port1Data);
            }
            else
            {
                Port2DataInput(data.port2Data);
            }
        }

    }
}
