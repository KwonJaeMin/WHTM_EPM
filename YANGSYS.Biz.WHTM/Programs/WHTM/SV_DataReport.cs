using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YANGSYS.ControlLib;
using SOFD.Properties;
using SOFD.InterfaceTimeout;
using MainLibrary;
using SOFD.Component;
using SOFD.Component.Interface;
using MainLibrary.Property;
using MainLibrary.Utility;


namespace YANGSYS.Biz.Programs
{
    public class SV_DataReport : AProgram
    {
        private CMain _main = null;
        private bool _enable = false;

        //BC

        //PROBE CIM
        private CPLCControlProperties OW_SV1 = null;

        private CScanControlProperties VI_SVID_SEND = null;

        private string _controlName = "";
        private CProbeControl _component = null;
        public SV_DataReport()
        {
        }

        public override int Init()
        {
            _enable = true;

            OW_SV1 = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_SV1");

            VI_SVID_SEND = _main._YANSYS_SCANCONTEROLS.GetProperty(_component.ControlName, "VI_SVID_SEND");

            _component.ProgramsAdd(this);
            return 0;
        }

        public override int AddArgs(object[] args, bool beforeClear)
        {
            if (args == null || args.Length < 2)
                return -1;

            if ((args[0] is CMain && args[1] is CProbeControl && args[1] is CProbeControl) == false)
            {
                return -1;
            }

            if (beforeClear)
            {

            }

            _main = args[0] as CMain;
            _component = args[1] as CProbeControl;
            _controlName = _component.ControlName;
            return 0;
        }

        public override string Name
        {
            get { return "SV_DATA_REPORT"; }
        }

        public override string Version
        {
            get { return "ver 1.0"; }
        }

        public override string Description
        {
            get { return "장비가 Glass를 받은후 Receive Report 이후에 보고하는 이벤트"; }
        }
        public override bool Enable
        {
            get { return _enable; }
        }
        public override string Development
        {
            get { return "(주)서진정보기술"; }
        }

        public override bool IsCycle
        {
            get { return false; }
        }

        public override bool IsAsyncCall
        {
            get { return true; }
        }
        public override string SIteName
        {
            get { return "WHTM"; }
        }
        protected override int InnerExecute()
        {
            string value = "";
            value = VI_SVID_SEND.Value;
            string[] temp = value.Split('|');
            string[] temp2 = temp[2].Split(',');


            List<int> SvData = new List<int>();


            for (int i = 0; i < temp2.Length; i++)
            {
                //if (int.Parse(temp2[i]) > 65535)
                //{
                //    SvData.AddRange(_main.ConvertDecTo2WordList(int.Parse(temp2[i])));
                //}
                //else
                //{
                //    SvData.Add(int.Parse(temp2[i]));
                //}

                SvData.AddRange(ByteArrayToIntArray(PLCDataConverter.SystemFloatToPLC4Byte(float.Parse(temp2[i])), 0, 2));

                //processingTime.AddRange(ByteArrayToIntArray(PLCDataConverter.SystemFloatToPLC4Byte((float)elapsedSpan.TotalSeconds), 0, 2));

                //char[] tempSvdata = temp2[i].ToCharArray();
                //string word = "";
                //int cnt = 0;
                //foreach (char item in tempSvdata)
                //{
                //    cnt++;
                //    word = item + word;
                //    if (word.Length > 1)
                //    {
                //        SvData.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.StringToHex(word))));
                //        word = "";
                //    }
                //    else if (tempSvdata.Length == cnt)
                //    {
                //        word = item + " ";
                //        SvData.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.StringToHex(word))));
                //        word = "";
                //    }
                //}
            }

            if (_component.CIMMode == 2)
            {
                _main.MelsecNetMultiWordWrite(OW_SV1, SvData);
            }
            return 0;
        }

        public static int[] ByteArrayToIntArray(byte[] data, int start, int wordLength)
        {
            int arrayCount = wordLength;
            if (data.Length > start + arrayCount)
            {
                int[] temp = new int[arrayCount];
                int j = 0;
                for (int i = 0; i < wordLength; i++)
                {
                    temp[i] = (data[start + j++] | data[start + j++] << 8);
                }
                return temp;
            }
            else
            {
                throw new ArgumentOutOfRangeException("start and wordLength * 2 less then data's length");
            }
        }
    }
}
