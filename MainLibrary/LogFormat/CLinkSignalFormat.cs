using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOFD.Logger;

namespace MainLibrary.LogFormat
{
    public class CLinkSignalFormat : CLogFormat
    {
                /// <summary>
        /// 부모 클래스에 로그 헤더 정보를 제공하기 위한 override method.
        /// <para>제일 앞: DateTime, 제일 끝: Log Format은 자동으로 추가 됨.</para>
        /// </summary>
        /// <returns></returns>
        protected override List<string> GetLogHeaderInfo()
        {
            List<string> temp = new List<string>();

            return temp;
        }

        public CLinkSignalFormat(Catagory logCategory, string controlName, string attribute, bool value)
            : base(logCategory, "SYSTEM", "LINK_SIGNAL")
        {
            try
            {
                _display = false;

                _contents.Add(controlName);
                _contents.Add(attribute);
                _contents.Add(string.Format("[{0}]", value));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
