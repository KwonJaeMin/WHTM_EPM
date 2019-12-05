using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOFD.Logger;

namespace YANGSYS.ControlLib.LogFormat
{
    public class CStatusLogFormat:CLogFormat
    {
        protected override List<string> GetLogHeaderInfo()
        {
            List<string> temp = new List<string>();

            return temp;
        }

        public CStatusLogFormat(Catagory logCategory, string logKey, string equipmentName, string contents)
            : base(logCategory, logKey, "STATUS")
        {
            try
            {
                _contents.Add(equipmentName);
                _contents.Add(contents);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
