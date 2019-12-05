using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SOFD.Logger;

namespace YANGSYS.UI.WHTM.LogFormat
{
    public sealed class CUILogFormat : CLogFormat
    {
        /// <summary>
        /// 부모 클래스에 로그 헤더 정보를 제공 하기 위한 오버라드 메서드
        /// <para>제일 앞: DATETIME, 제일 끝:LOG FORMAT은 자동으로 추가 됩니다. </para>
        /// </summary>
        /// <returns></returns>
        protected override List<string> GetLogHeaderInfo()
        {
            List<string> temp = new List<string>();
            return temp;
        }

        /// <summary>
        /// Catagory, 화면명, 내용, 추가 내용
        /// </summary>
        /// <param name="logCatagory"></param>
        /// <param name="displayName"></param>
        /// <param name="contents"></param>
        /// <param name="remark"></param>
        public CUILogFormat(Catagory logCatagory, string displayName, string contents, string remark)
            : base(logCatagory, "SYSTEM", "UI")
        {
            try
            {
                _contents.Add(displayName);
                _contents.Add(contents);
                _contents.Add(remark);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
