using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SOFD.Logger;
using SOFD.Properties;
using SOFD.DataConvert;

using MainLibrary.Property;
using SmartDevice.UTILS;

namespace MainLibrary.Manager
{
    // Data처리에 관련한 매니저
    //주 처리는 GlassData를 PLC에 Write할 수 있게 만들거나 반대로 PLC에서 읽은 Data를 GlassDataProperties형태로 바꾸어주는 역할 수행/
    //LOT DATA도 처리할 예정임. (아마도..)
    public class CDataManager
    {       

        public CDataManager()
        {
            
        }

        private List<int> InfoConvert(string str, int length)
        {
            string[] strInfo = new string[8];
            ushort[] ushortInfo = new ushort[16];
            List<int> Infomation = new List<int>();
            ushortInfo = CDataConvert.StringToAscii(str, length);
            strInfo = CDataConvert.AsciiTo1BitWord(ushortInfo, length * 2);
            for (int i = 0; i < strInfo.Length; i++)
            {
                Infomation.Add(CDataConvert.BinaryStringToRevseInt(strInfo[i]));
            }

            return Infomation;
        }

        public List<int> PanelInfoToHex(string pnlInfo)
        {
            if (pnlInfo == null) return null;

            List<int> hexData = new List<int>();

            if (pnlInfo.Length % 2 != 0)
                pnlInfo += " ";

            for (int i = 0; i < pnlInfo.Length; i += 2)
            {
                string temp = PLCUtils.AsciiToHex(pnlInfo.Substring(i, 2));
                int iTemp = Convert.ToInt32(PLCUtils.HexToDec(temp));
                hexData.Add(iTemp);
            }

            return hexData;
        }
    }
}
