using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SOFD.BasicCore;

namespace SOFD.Global
{
    public abstract class ABizLogic
    {
        public string BizName { get; set; }
        public abstract void Init(CBasicCore initializedMain, System.Windows.Forms.Control control);
    }
}
