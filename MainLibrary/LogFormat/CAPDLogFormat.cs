using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOFD.Logger;

namespace MainLibrary.LogFormat
{
    public sealed class CAPDLogFormat : CLogFormat
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

        public CAPDLogFormat(Catagory logCategory, string logKey, string equipmentName, string contents)
            : base(logCategory, logKey, "APD")
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
