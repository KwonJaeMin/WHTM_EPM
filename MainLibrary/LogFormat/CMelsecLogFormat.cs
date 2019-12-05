using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MainLibrary.Property;

using SOFD.Logger;
using SOFD.Properties;

namespace MainLibrary.LogFormat
{
    public sealed class CMelsecLogFormat : CLogFormat
    {
        /// <summary>
        /// 부모 클래스에 로그 헤더 정보를 제공하기 위한 override method.
        /// <para>제일 앞: DateTime, 제일 끝: Log Format은 자동으로 추가 됨.</para>
        /// </summary>
        /// <returns></returns>
        protected override List<string> GetLogHeaderInfo()
        {
            List<string> temp = new List<string>();

            temp.Add("ACTION");
            temp.Add("NAME");
            temp.Add("MEMORY ID");
            temp.Add("BIT INDEX");
            temp.Add("LENGTH");
            temp.Add("PREVIOUS VALUE");
            temp.Add("VALUE");

            return temp;
        }

        public CMelsecLogFormat(Catagory logCategory, CScanControlProperties scanControlProperties, bool prevValue, bool value)
            : base(logCategory, "SYSTEM", "MELSEC")
        {
            try
            {
                _display = scanControlProperties.Display;
                _contents.Add("READ".PadRight(5));
                _contents.Add(scanControlProperties.ScanControlName == null ? "".PadRight(20) : scanControlProperties.ScanControlName.PadRight(20));
                _contents.Add(scanControlProperties.ScanAttribute == null ? "".PadRight(30) : scanControlProperties.ScanAttribute.PadRight(30));
                _contents.Add(string.Format("{0}{1}", scanControlProperties.ScanDeviceType.ToString(),
                    scanControlProperties.ScanArea == null ? "".PadRight(5) : scanControlProperties.ScanArea.PadRight(5)));
                _contents.Add(prevValue.ToString().PadRight(20));
                _contents.Add(string.Format("[{0}]", value).PadRight(30));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CMelsecLogFormat(Catagory logCategory, CScanControlProperties scanControlProperties, string prevValue, string value)
            : base(logCategory, "SYSTEM", "MELSEC")
        {
            try
            {
                if (prevValue == null)
                    prevValue = "";
                if (value == null)
                    value = "";

                _display = scanControlProperties.Display;
                _contents.Add("READ".PadRight(5));
                _contents.Add(scanControlProperties.ScanControlName == null ? "".PadRight(20) : scanControlProperties.ScanControlName.PadRight(20));
                _contents.Add(scanControlProperties.ScanAttribute == null ? "".PadRight(30) : scanControlProperties.ScanAttribute.PadRight(30));
                _contents.Add(string.Format("{0}{1}", scanControlProperties.ScanDeviceType.ToString(),
                    scanControlProperties.ScanArea == null ? "".PadRight(5) : scanControlProperties.ScanArea.PadRight(5)));
                _contents.Add(prevValue.ToString().PadRight(20));
                _contents.Add(string.Format("[{0}]", value).PadRight(30));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CMelsecLogFormat(Catagory logCategory, bool isRead, CPLCControlProperties plcControlProperties, bool prevValue, bool value, int ret)
            : base(logCategory, "SYSTEM", "MELSEC")
        {
            try
            {
                _display = plcControlProperties.Display;
                _contents.Add(isRead ? "READ" : "WRITE");
                _contents.Add(plcControlProperties.PLCControlName == null ? "".PadRight(20) : plcControlProperties.PLCControlName.PadRight(20));
                _contents.Add(plcControlProperties.PLCAttribute == null ? "".PadRight(30) : plcControlProperties.PLCAttribute.PadRight(30));
                _contents.Add(string.Format("{0}{1}", plcControlProperties.PLCDeviceType.ToString(),
                    plcControlProperties.PLCArea == null ? "".PadRight(5) : plcControlProperties.PLCArea.PadRight(5)));
                _contents.Add(prevValue.ToString().PadRight(20));
                _contents.Add(string.Format("[{0}]", value).PadRight(30));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CMelsecLogFormat(Catagory logCategory, bool isRead, CPLCControlProperties plcControlProperties, string prevValue, string value, int ret)
            : base(logCategory, "SYSTEM", "MELSEC")
        {
            try
            {
                if (prevValue == null)
                    prevValue = "";
                if (value == null)
                    value = "";

                _display = plcControlProperties.Display;
                _contents.Add(isRead ? "READ" : "WRITE");
                _contents.Add(plcControlProperties.PLCControlName == null ? "".PadRight(20) : plcControlProperties.PLCControlName.PadRight(20));
                _contents.Add(plcControlProperties.PLCAttribute == null ? "".PadRight(30) : plcControlProperties.PLCAttribute.PadRight(30));
                _contents.Add(string.Format("{0}{1}", plcControlProperties.PLCDeviceType.ToString(),
                    plcControlProperties.PLCArea == null ? "".PadRight(5) : plcControlProperties.PLCArea.PadRight(5)));
                _contents.Add(prevValue.ToString().PadRight(20));
                _contents.Add(string.Format("[{0}]", value).PadRight(30));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CMelsecLogFormat(Catagory logCategory, bool isRead, string ownerId, string attribute,
            string stationNo, string deviceType, string address, int length, bool value, int ret, bool isDisplay)
            : this(logCategory, isRead, ownerId, attribute, stationNo, deviceType, address, length, value.ToString(), ret, isDisplay)
        {
        }

        public CMelsecLogFormat(Catagory logCategory, bool isRead, string ownerId, string attribute, string stationNo,
            string deviceType, string address, int length, string value, int ret, bool isDisplay)
            : base(logCategory, "SYSTEM", "MELSEC")
        {
            try
            {
                _display = isDisplay;
                _contents.Add(isRead ? "READ" : "WRITE");
                _contents.Add(ownerId.PadRight(20));
                _contents.Add(attribute.PadRight(30));
                _contents.Add(string.Format("{0}{1}", deviceType, address.PadRight(5)));
                _contents.Add("".PadRight(20));
                _contents.Add(string.Format("[{0}]", value).PadRight(30));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CMelsecLogFormat(Catagory logCategory, string action, string remark, bool isDisplay)
            : base(logCategory, "SYSTEM", "MELSEC")
        {
            try
            {
                _display = isDisplay;
                _contents.Add("".PadRight(20));
                _contents.Add("".PadRight(20));
                _contents.Add(action.PadRight(30));
                _contents.Add("".PadRight(7));
                _contents.Add("".PadRight(20));
                _contents.Add("".PadRight(30));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
