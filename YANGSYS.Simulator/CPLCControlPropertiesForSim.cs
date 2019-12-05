using System;
using System.Collections.Generic;
using System.Text;
using SOFD.Properties;

namespace SmartPLCSimulator
{
    public class CPLCControlPropertiesForSim : CPLCControlProperties
    {
        public bool CurrentBit { get; set; }
        public string ConnectTMName { get; set; }
    }
}
