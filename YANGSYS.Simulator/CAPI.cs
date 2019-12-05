using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace SmartPLCSimulator
{
    public static class CAPI
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public static void WriteIniFile(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"CONFIG\\Config.ini");
        }

        public static string ReadIniFile(string section, string key)
        {
            StringBuilder sb = new StringBuilder(255);
            GetPrivateProfileString(section, key, "", sb, sb.Capacity, AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"CONFIG\\Config.ini");

            return sb.ToString();
        }
    }
}
