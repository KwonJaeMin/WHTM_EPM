using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOFD.Logger;

namespace MainLibrary.LogFormat
{
    public class CMaterialDataLogFormat : CLogFormat
    {
        protected override List<string> GetLogHeaderInfo()
        {
            List<string> temp = new List<string>();

            return temp;
        }

        public CMaterialDataLogFormat(Catagory logCategory, string action, string contents)
            : base(logCategory, "SYSTEM", "METERIAL_DATA")
        {
            try
            {
                _contents.Add(action);
                _contents.Add(contents);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
