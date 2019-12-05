using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOFD.Global;

namespace MainLibrary.Property
{
    public abstract class AAlarmData : AProperties
    {
        public string ControlName { get; set; }
        public string EquipmentID { get; set; }
        public string MachineID { get; set; }
        public string UnitID { get; set; }
        public string AlarmText { get; set; }
        public string AlarmID { get; set; }
        public string AlarmCode { get; set; }
        public DateTime regtime { get; set; }

        public override AProperties SetProperties(Dictionary<string, string> keyValue)
        {
            foreach (string str in keyValue.Keys)
            {
                switch (str)
                {
                    case "ControlName":
                        ControlName = GetValue<string>("ControlName", ref keyValue);
                        break;
                    case "EquipmentID":
                        EquipmentID = GetValue<string>("EquipmentID", ref keyValue);
                        break;
                    case "UnitID":
                        UnitID = GetValue<string>("UnitID", ref keyValue);
                        break;
                    case "AlarmText":
                        AlarmText = GetValue<string>("AlarmText", ref keyValue);
                        break;
                    case "AlarmID":
                        AlarmID = GetValue<string>("AlarmID", ref keyValue);
                        break;
                    case "AlarmCode":
                        AlarmCode = GetValue<string>("AlarmCode", ref keyValue);
                        break;
                }
            }
   
            return this;
        }
    }

    public abstract class CAlarmProperties : AAlarmData
    {
        public int GetALCD(enumALCD oALCD)
        {
            return oALCD.GetHashCode();
        }

        public enum enumALCD
        {
            Personal_Safety_Set = 129,
            Equipment_Safety_Set = 130,
            Parameter_Control_Warning_Set = 131,
            Parameter_Control_Error_Set = 132,
        }
    }

    public class CAlarmWHTM : AAlarmData
    {
        public enum enumAlarmLevel
        {
            Light = 1,
            Serious = 2,
        }

        public int AlarmStatus = 0;
        public enumAlarmLevel AlarmLevel = 0;
        public int AlarmTextUsingFlag = 0;
        public int AlarmOffset = 0;

        public CAlarmWHTM()
        {
            regtime = DateTime.Now;
            this.UnitID = "0";
        }
        
        public override AProperties SetProperties(Dictionary<string, string> keyValue)
        {
            base.SetProperties(keyValue);

            foreach (string str in keyValue.Keys)
            {
                switch (str)
                {
                    case "AlarmLevel":
                        AlarmLevel = GetValue<enumAlarmLevel>("AlarmLevel", ref keyValue);
                        break;
                    case "AlarmTextUsingFlag":
                        AlarmTextUsingFlag = GetValue<int>("AlarmTextUsingFlag", ref keyValue);
                        break;
                }
            }

            return this;
        }

        public List<int> GetPLCData()
        {
            List<int> plcData = new List<int>();
            plcData.Add(AlarmStatus);
            plcData.Add(int.Parse(UnitID));//ISSUED_UNIT_PATH_NO;
            uint alarmID = 0;

            if (uint.Parse(AlarmID) < 30000)
            {
                alarmID = uint.Parse(AlarmID) + (uint)AlarmOffset;
            }
            else
            {
                alarmID = uint.Parse(AlarmID);
            }
            

            plcData.Add((int)(alarmID & 0xFFFF));
            plcData.Add((int)(alarmID >> 16));
            plcData.Add(int.Parse(AlarmCode));
            plcData.Add((int)AlarmLevel);
            plcData.Add(AlarmTextUsingFlag);
            plcData.AddRange(CovertStringToWordList(AlarmText, 35));

            string yearTemp = regtime.Year.ToString();
            string mYear = ushort.Parse(yearTemp.Substring(yearTemp.Length - 2, 2)).ToString("00");
            string mMonth = regtime.Month.ToString("00");
            string mDay = regtime.Day.ToString("00");
            string mHour = regtime.Hour.ToString("00");
            string mMin = regtime.Minute.ToString("00");
            string mSec = regtime.Second.ToString("00");

            //plcData.Add(mMonth << 8 | mYear);
            //plcData.Add(mHour << 8 | mDay);
            //plcData.Add(mSec << 8 | mMin);

            //DateTime yearTemp = DateTime.Parse(glassData.ProcessedStartTime);// DateTime.Now.Year.ToString();

            //string temp = yearTemp.Year.ToString();

            //string mYear = ushort.Parse(temp.Substring(temp.Length - 2, 2)).ToString("00");
            //string mMonth = yearTemp.Month.ToString("00");
            //string mDay = yearTemp.Day.ToString("00");
            //string mHour = yearTemp.Hour.ToString("00");
            //string mMin = yearTemp.Minute.ToString("00");
            //string mSec = yearTemp.Second.ToString("00");




            plcData.Add(ushort.Parse(mMonth.Substring(0, 1)) << 12 | ushort.Parse(mMonth.Substring(1, 1)) << 8 | ushort.Parse(mYear.Substring(0, 1)) << 4 | ushort.Parse(mYear.Substring(1, 1)));
            plcData.Add(ushort.Parse(mHour.Substring(0, 1)) << 12 | ushort.Parse(mHour.Substring(1, 1)) << 8 | ushort.Parse(mDay.Substring(0, 1)) << 4 | ushort.Parse(mDay.Substring(1, 1)));
            plcData.Add(ushort.Parse(mSec.Substring(0, 1)) << 12 | ushort.Parse(mSec.Substring(1, 1)) << 8 | ushort.Parse(mMin.Substring(0, 1)) << 4 | ushort.Parse(mMin.Substring(1, 1)));
            

            return plcData;
        }

        /// <summary>
        /// ABCD  -> BADC-> HEX -> DEC 로 변환 해준다.
        /// </summary>
        /// <param name="normalString"></param>
        /// <param name="wordMaxLength">WORD 기준 총개수, 내부적으로 *2한다.</param>
        /// <returns></returns>
        public static List<int> CovertStringToWordList(string normalString, int wordMaxLength)
        {
            List<int> plcData = new List<int>();
            char[] tempLotID = normalString.ToCharArray();
            List<string> word = new List<string>();
            int maxLegnth = wordMaxLength * 2;

            for (int i = 0; i < maxLegnth; i++)
            {
                if (tempLotID.Length <= i)
                {
                    word.Insert(0, " ");
                }
                else
                {
                    word.Insert(0, tempLotID[i].ToString());
                }

                if (word.Count >= 2)
                {
                    plcData.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.StringToHex(word[0] + word[1]))));
                    word.Clear();
                }
            }
            //plcData.Add(0);//OMRON STRING은 1WORD NULL 줘야함.
            return plcData;
        }
        /// <summary>
        /// ABCD  -> BADC-> HEX -> DEC 로 변환 해준다.
        /// </summary>
        /// <param name="normalString"></param>
        /// <param name="wordMaxLength">WORD 기준 총개수, 내부적으로 *2한다.</param>
        /// <returns></returns>
        public static List<ushort> CovertStringToWordushort(string normalString, int wordMaxLength)
        {
            List<ushort> plcData = new List<ushort>();
            char[] tempLotID = normalString.ToCharArray();
            List<string> word = new List<string>();
            long maxLegnth = wordMaxLength * 2;
            for (ushort i = 0; i < maxLegnth; i++)
            {
                if (tempLotID.Length <= i)
                {
                    word.Insert(0, " ");
                }
                else
                {
                    word.Insert(0, tempLotID[i].ToString());
                }
                if (word.Count >= 2)
                {
                    plcData.Add(ushort.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.StringToHex(word[0] + word[1]))));
                    word.Clear();
                }
            }

            return plcData;
        }
    }

    public class CAlarmDataCollection : Dictionary<string, AAlarmData>
    {
        public AAlarmData GetAlarm(string alarmID)
        {
            foreach (AAlarmData item in this.Values)
            {
                if (item.AlarmID == alarmID)
                {
                    return item;
                }
            }
            return null;
        }

        public T GetAlarm<T>(string alarmID)
        {
            foreach (AAlarmData item in this.Values)
            {
                if (item.AlarmID == alarmID)
                {
                    if (item is T)
                    {
                        return (T)Convert.ChangeType(item, typeof(T));
                    }                    
                }
            }
            return default(T);
        }
    }

    public class CAlarmPropertiesCollection : Dictionary<string, CAlarmProperties>
    {
        //public bool IsExistLOTDataByLOTID(string LOTID)
        //{
        //    foreach (CAlarmProperties oAlarm in this.Values)
        //    {
        //        if (oAlarm.LotID == LOTID)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        //public CAlarmProperties GetLOTDataByLOTID(string LOTID)
        //{
        //    foreach (CAlarmProperties oAlarm in this.Values)
        //    {
        //        if (oAlarm.LotID == LOTID)
        //        {
        //            return oLOT;
        //        }
        //    }
        //    return null;
        //}
    }
}
