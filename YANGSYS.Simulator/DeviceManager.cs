using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace SmartPLCSimulator
{
    public  class DeviceManager
    {
        public static Dictionary<string, BaseDevice> _deviceList = new Dictionary<string, BaseDevice>();

        public DeviceManager()
        {
            SetDevice(DEVICETYPE.BIT.ToString(), "B", "23");
            SetDevice(DEVICETYPE.WORD.ToString(), "W", "24");
            SetDevice(DEVICETYPE.WORD.ToString(), "R", "22");

            //X/Y추가
            SetDevice(DEVICETYPE.BIT.ToString(), "X", "1");
            SetDevice(DEVICETYPE.BIT.ToString(), "Y", "2");

        }
        public void SetDevice(string type, string name, string number)
        {
            if (type.Equals("BIT"))
            {
                BaseDevice _device = new BitDevice(name, number);
                _deviceList.Add(_device.deviceNumber, _device);
            }
            else
            {
                BaseDevice _device = new WordDevice(name, number);

                _deviceList.Add(_device.deviceNumber, _device);
            }
        }

        public static string  Read(string deviceName, int start, int length)
        {
            string retValue = "";
            BaseDevice device = null;
            _deviceList.TryGetValue(deviceName, out device);
            if (device != null)
            {
                retValue = device.Read(start, length);
            }

            return retValue;
        }
        public static string Write(string deviceName, int start, int length, string data)
        {
            string retValue = "";
            BaseDevice device = null;
            _deviceList.TryGetValue(deviceName, out device);

            if (device != null)
            {
                retValue = device.Write(start, length, data);
            }
            return retValue;
        }


        public static ushort[] ArrayRead(string deviceName, int start, int length)
        {
            ushort[] retValue = null;
            BaseDevice device = null;
            _deviceList.TryGetValue(deviceName, out device);
            if (device != null)
            {
                retValue = device.ArrayRead(start, length);
            }

            return retValue;
        }
    }
}
