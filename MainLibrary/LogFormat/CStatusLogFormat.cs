using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOFD.Logger;

namespace MainLibrary.LogFormat
{
    public class CStatusLogFormat:CLogFormat
    {
        protected override List<string> GetLogHeaderInfo()
        {
            List<string> temp = new List<string>();

            return temp;
        }

        public CStatusLogFormat(Catagory logCategory, string logKey, string equipmentName, string contents)
            : base(logCategory, "STATUS", "STATUS")
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

        public CStatusLogFormat(Catagory logCategory, string logKey, string GlassID, string GlassCode, string contents, string Position)
            : base(logCategory, "FLOW", "FLOW")
        {
            try
            {
                _contents.Add(GlassID);
                _contents.Add(GlassCode.ToString());
                _contents.Add(contents);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
