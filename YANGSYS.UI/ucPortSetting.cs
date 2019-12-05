using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YANGSYS.UI.WHTM
{
    public partial class ucPortSetting : UserControl
    {
        public ucPortSetting()
        {
            InitializeComponent();
        }
        public string portName { get; set; }
        public string portMode { get; set; }
        public string portUseStatus { get; set; }
        public string portData { get; set; }
        
        public void portInputSettingData()
        {
            if (portMode == "AGV")
            {
                btnAGV.Text = "AGV";
            }
            else
            {
                btnAGV.Text = "MGV";
            }

            if (portUseStatus == "Enable")
            {
                btnEnable.Text = "ENABLE";
            }
            else
            {
                btnEnable.Text = "DISABLE";
            }

            Label7.Text = portName;
            cmbSelect.Text = portData;
        }
    }

    public partial class CucPortPropertiesCollections : Dictionary<string, ucPortSetting>
    {
    }
}
