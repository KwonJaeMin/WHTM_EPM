using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SOFD.Logger;

namespace MainLibrary.LogFormat
{
    public class CLoaderLogFormat : CLogFormat
    {
        protected override List<string> GetLogHeaderInfo()
        {
            List<string> temp = new List<string>();
            return temp;
        }

        public CLoaderLogFormat(Catagory logCatagory, string controlName, string modeName, string contents)
            : base(logCatagory, "LOADER", "LOADER")
        {
            try
            {
                _contents.Add(controlName);
                _contents.Add(modeName);
                _contents.Add(contents);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
