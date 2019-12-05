using System;
using System.Collections.Generic;
using System.Text;

namespace SmartPLCSimulator
{
    public  class WordDevice : BaseDevice
    {
        public WordDevice(string name, string deviceNumber)
        {
            this.deviceType = DEVICETYPE.WORD;
            this.dataFormat = DATAFORMAT.HEX;
            this.name = name;
            this.deviceNumber = deviceNumber;
        }
        public override string Read(int intStartAdd, int intLength)
        {
            string retValue = "-1";
            try
            {
                retValue = new string(Memory, intStartAdd, intLength);
            }
            catch
            {
                retValue = "-1";
            }
            return retValue;
        }

        public override ushort[] ArrayRead(int intStartAdd, int intLength)
        {
            //return base.ArrayRead(intStartAdd, intLength);
            ushort[] retValue = new ushort[intLength];
            char[] convertValue = new char[intLength];
            try
            {
                //retValue = new string(Memory, intStartAdd, intLength);
                Array.Copy(Memory, intStartAdd, convertValue, 0, intLength);


                //retValue = Array.ConvertAll(Memory, short.Parse);
                ushort[] shortArray = Array.ConvertAll<char, ushort>(convertValue, new Converter<char, ushort>(CharToShort));
                retValue = shortArray;
                   // short[] shortArray = Array.ConvertAll<char, short>(Memory, new Converter<char, short>(CharToShort));
            }
            catch
            {
                retValue = null;
            }
            return retValue;
        }

        public override string Write(int intStartAdd, int intLength, string data)
        {
            string retValue = "-1";
            try
            {
                int index = 0;
                data = data.PadLeft((intLength * 4), '0');
                char[] buffer = new char[intLength];
                for (int i = 0; i < (intLength * 4); i += 4)
                {
                    string tocken = data.Substring(i, 4);
                    string s = Utils.HexToDec(tocken);
                    int tockenInt = Convert.ToInt32(s);
                    buffer[index] = Convert.ToChar(tockenInt);
                    index++;
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

        private ushort CharToShort(char charray)
        {
            int i = Convert.ToInt32(charray);
            return ushort.Parse(i.ToString());
        }
    }
}
