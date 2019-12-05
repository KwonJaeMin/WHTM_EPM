using System;
using System.Collections.Generic;
using System.Text;

namespace SmartPLCSimulator
{
    public  class BaseDevice
    {
        public DEVICETYPE deviceType;
        public int index = 0;
        public int maxIndex = 131072;
        public DATAFORMAT dataFormat;
        public string name = "";
        //public char[] Memory = new char[65536];
        public char[] Memory = new char[131072];
        public string fullName = "";
        public string deviceNumber = "";
        public BaseDevice()
        {
            index = 0;
            dataFormat = DATAFORMAT.DEC;
            for (int i = 0; i < Memory.Length; i++)
            {
                Memory[i] = (char)0;
            }
        }
        public virtual string Read(int intStartAdd, int intLength)
        {
            return "";
        }

        public virtual ushort[] ArrayRead(int intStartAdd, int intLength)
        {
            return null;
        }

        public virtual string Write(int intStartAdd, int intLength, string data)
        {
            return "";
        }
    }
}
