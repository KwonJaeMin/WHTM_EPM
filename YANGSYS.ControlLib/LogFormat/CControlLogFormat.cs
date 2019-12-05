using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SOFD.Logger;

namespace YANGSYS.ControlLib.LogFormat
{
    public class CControlLogFormat : CLogFormat
    {
        protected override List<string> GetLogHeaderInfo()
        {
            List<string> temp = new List<string>();
            return temp;
        }

        public CControlLogFormat(Catagory logCatagory, string controlName, string attributeName, string value)
            : base(logCatagory, "CONTROL", "CONTROL")
        {
            try
            {
                _contents.Add(controlName);
                _contents.Add(attributeName);
                _contents.Add(value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        public CControlLogFormat(Catagory logCatagory, string controlName, string attributeName, string value, string contents)
            : base(logCatagory, "CONTROL", "CONTROL")
        {
            try
            {
                _contents.Add(controlName);
                _contents.Add(attributeName);
                _contents.Add(value);
                _contents.Add(contents);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
