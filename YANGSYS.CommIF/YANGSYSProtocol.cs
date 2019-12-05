using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOFD.Global.Interface;

namespace YANGSYS.CommDrv
{
    public class YANGSYSProtocol : CommMessage
    {
        private  CommDrv Driver = null;

        public YANGSYSProtocol(CommDrv driver, string pName, string sName)
            : base(pName, sName)
        {
            this.Driver = driver;
        }

        public override bool Send()
        {
            //
            return false;
        }

        public override bool Reply()
        {
            //
            return false;
        }
    }
}
