using System;
using System.Collections.Generic;
using System.Text;

namespace SmartPLCSimulator
{
    public class BitDevice : BaseDevice
    {
        public BitDevice(string name, string deviceNumber)
        {
            this.deviceType = DEVICETYPE.BIT;
            this.dataFormat = DATAFORMAT.BIN;
            this.name = name;
            this.deviceNumber = deviceNumber;
        }

        public override string Read(int intStartAdd, int intLength)
        {
            char[] chArray = Array.ConvertAll<char, char>(Memory, new Converter<char, char>(CharToString));
            return new string(chArray, intStartAdd, intLength);
        }

        public override ushort[] ArrayRead(int intStartAdd, int intLength)
        {
            //return base.ArrayRead(intStartAdd, intLength);
            ushort[] shortArray = Array.ConvertAll<char, ushort>(Memory, new Converter<char, ushort>(CharToShort));
            return shortArray;
        }

        public override string Write(int intStartAdd, int intLength, string data)
        {
            string retValue = "";
            try
            {
                data = data.PadRight(intLength, '0');
                char[] buffer = new char[data.Length];
                for (int i = 0; i < data.Length; i++)
                {
                    int intmsg = Convert.ToInt32(data[i].ToString());
                    buffer[i] = (char)intmsg;
                }
                Array.ConstrainedCopy(buffer, 0, Memory, intStartAdd, intLength);
                retValue = "0";
            }
            catch
            {
                retValue = "-1";
            }
            return retValue;
        }
        private char CharToString(char charray)
        {
            int i = Convert.ToInt32(charray);
            return Convert.ToChar(i.ToString());
        }
        private ushort CharToShort(char charray)
        {
            int i = Convert.ToInt32(charray);
            return ushort.Parse(i.ToString());
        }
    }
}
