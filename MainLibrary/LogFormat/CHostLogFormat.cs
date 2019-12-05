using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SOFD.Logger;

namespace MainLibrary.LogFormat
{
    public class CHostLogFormat:CLogFormat
    {
        protected override List<string> GetLogHeaderInfo()
        {
            List<string> temp = new List<string>();

            return temp;
        }

        public CHostLogFormat(Catagory logCategory, string msgName, string contents)
            : base(logCategory, "HOST", "HOST")
        {
            try
            {   
                _contents.Add(msgName);
                _contents.Add(contents);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
