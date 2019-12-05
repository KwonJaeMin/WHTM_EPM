using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainLibrary
{
    public class Constants
    {
    }

    #region Driver

    public enum enumConnectionStateStep
    {
        Disabled = 0,
        Enabled = 1,
        Disconnected = 2,
        Connected = 3,
        Retry = 4
    }

    public enum enumConnectionStatePath
    {
        Enable = 0,
        Disable = 1,
        Connect = 2,
        Disconnect = 3
    }

    #endregion
}
