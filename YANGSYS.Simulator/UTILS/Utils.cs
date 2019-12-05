using System;
using System.Collections.Generic;
using System.Text;

namespace SmartPLCSimulator
{
    public class Utils
    {
        internal static string HexToDec(string tocken)
        {
            string HexToDec = "";
            try
            {
                HexToDec = Convert.ToInt64(tocken, 16).ToString();
            }
            catch (Exception ex)
            {
                HexToDec = ex.Message.ToString();
            }
            return HexToDec;
        }
        internal static string DecToHex(string tocken)
        {
            string DecToHex = "";
            try
            {
                DecToHex = Convert.ToInt32(tocken).ToString("X");
                DecToHex = DecToHex.PadLeft(4, '0');
            }
            catch (Exception ex)
            {
                DecToHex = ex.Message.ToString();
            }
            return DecToHex;
        }
        internal static string BinToHex(string tocken)
        {
            string retValue = "";
            retValue = (Convert.ToInt32(tocken, 2)).ToString("X");
            retValue = retValue.PadLeft(4, '0');
            return retValue;
        }
        internal static string DecToBinary(string value)
        {
            string retValue = "";
            retValue = Convert.ToString(Convert.ToInt32(value), 2);
            retValue = retValue.PadLeft(16, '0');
            return retValue;
        }

        internal static string ReverseString(string value)
        {
            char[] oChar = value.ToCharArray();
            string strRst = "";
            foreach(char tmpChar in oChar)
            {
                strRst = tmpChar.ToString() + strRst;
            }
            return strRst;
        }

        internal static string BinaryToHex(string value)
        {         
            string retValue = "";
            retValue = (Convert.ToInt32(value, 2)).ToString("X");
            return retValue;        
        }

        internal static string HexToBinary(string OneWordValue, int length)
        {           
            string retValue = "";
            retValue = Convert.ToString(Convert.ToInt32(OneWordValue, 16), 2);
            if (retValue.Length > length)
            {
                retValue = retValue.Substring(0, length);
            }
            retValue = retValue.PadLeft(length, '0');
            return retValue;
        }
    }
}
