using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOFD.Logger;

namespace YANGSYS.CommDrv.LogFormat
{
    public class CMessageLogFormat : CLogFormat
    {
        protected override List<string> GetLogHeaderInfo()
        {
            List<string> temp = new List<string>();

            return temp;
        }

        public CMessageLogFormat(Catagory logCategory, string driverName, string dir, string contents)
            : base(logCategory, "SYSTEM", "MESSAGE")
        {
            try
            {
                _contents.Add(driverName);
                _contents.Add(dir);
                _contents.Add(contents);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
