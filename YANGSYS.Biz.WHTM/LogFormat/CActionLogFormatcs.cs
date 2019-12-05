using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOFD.Logger;

namespace YANGSYS.Biz.LogFormat
{
    public class CActionLogFormat : CLogFormat
    {
        protected override List<string> GetLogHeaderInfo()
        {
            List<string> temp = new List<string>();

            return temp;
        }

        public CActionLogFormat(Catagory logCategory, string equipmentName, string contents)
            : base(logCategory, "ACTION", "ACTION")
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
