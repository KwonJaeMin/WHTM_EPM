using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOFD.Logger;

namespace YANGSYS.Biz.LogFormat
{
    public class CCimMessageLogFormatcs : CLogFormat
    {
        protected override List<string> GetLogHeaderInfo()
        {
            List<string> temp = new List<string>();

            return temp;
        }

        public CCimMessageLogFormatcs(Catagory logCategory, string equipmentName, string contents)
            : base(logCategory, "CIM_MESSAGE", "CIM_MESSAGE")
        {
            try
            {
                _contents.Add(equipmentName);
                _contents.Add(contents);
            }
            catch (Exception ex)
            {
                CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, CExceptionLogFormat.DEFAULT_KEY, ex));
            }
        }
    }
}
