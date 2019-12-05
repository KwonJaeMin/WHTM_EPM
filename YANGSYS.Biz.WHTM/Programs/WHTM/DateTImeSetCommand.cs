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

using SOFD.Logger;
using SOFD.Global.Manager;
using System.Threading;


namespace YANGSYS.Biz.Programs
{

    public class DateTImeSetCommand : AProgram

    {
        private CMain _main = null;
        private bool _enable = false;

        //BC
        private CScanControlProperties IB_DATE_TIME_SET = null;//SD_B_DateTimeSet_BCToL3
        private CScanControlProperties IW_DATE_TIME = null;//SD_W_DateTimeSet_BCToL3
        private CScanControlProperties IW_DATE_RESULT = null;//SD_W_DateTimeSet_BCToL3

        //PROBE CIM
        private CPLCControlProperties OB_DATE_TIME_SET = null;//SD_B_DateTimeSet_BCToL3
        private CPLCControlProperties OW_DATE_RESULT = null;//SD_W_DateTimeSet_BCToL3

        private const int RESULT_COMMAND_OK = 1;
        private const int RESULT_COMMAND_ERROR = 2;

        private string _controlName = "";
        private CProbeControl _component = null;
        public DateTImeSetCommand()
        {
        }
        public override int Init()
        {
            _enable = true;

            IB_DATE_TIME_SET = _main.SCANCONTEROLS.GetProperty(_controlName, "IB_DATE_TIME_SET");
            IW_DATE_TIME = _main.SCANCONTEROLS.GetProperty(_controlName, "IW_DATE_TIME");
            IW_DATE_RESULT = _main.SCANCONTEROLS.GetProperty(_controlName, "IW_DATE_RESULT");

            OB_DATE_TIME_SET = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_DATE_TIME_SET");
            OW_DATE_RESULT = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_DATE_RESULT");

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
            get { return "DATE_TIME_SET"; }
        }

        public override string Version
        {
            get { return "ver 1.0"; }
        }

        public override string Description
        {
            get { return "BC에서 현재 시간을 변경하라는 명령 처리 프로그램"; }
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
        public override string SIteName
        {
            get { return "B10"; }
        }
        public override bool IsAsyncCall
        {
            get { return true; }
        }

        protected override int InnerExecute()
        {
            ushort[] dateTime = _main.MelsecNetMultiWordRead(IW_DATE_TIME);

            ////에러:응답이 없다..
            //List<string> dataList = new List<string>();
            //dataList.Add("ALARM_SET_REQUEST");
            //dataList.Add("0");
            //dataList.Add("65501");
            //_main.SendData(dataList);

            //return 0;
            if (dateTime == null)
            {
                Log(string.Format("{0}\t{1}", _component.ControlName, string.Format("PGM DATA ERROR - dateTime is null")));
                _main.MelsecNetWordWrite(OW_DATE_RESULT, RESULT_COMMAND_ERROR);
                _main.MelsecNetBitOnOff(OB_DATE_TIME_SET, false);
                return -99;
            }
            try
            {
                int mYear = int.Parse(((int)dateTime[0] & 0xFF).ToString("X"));
                int mMonth = int.Parse(((int)dateTime[0] >> 8).ToString("X"));
                int mDay = int.Parse(((int)dateTime[1] & 0xFF).ToString("X"));
                int mHour = int.Parse(((int)dateTime[1] >> 8).ToString("X"));
                int mMin = int.Parse(((int)dateTime[2] & 0xFF).ToString("X"));
                int mSec = int.Parse(((int)dateTime[2] >> 8).ToString("X"));

                string tmpMsg = string.Format("{0}-{1}-{2} {3}:{4}:{5}", mYear, mMonth, mDay, mHour, mMin, mSec);
                string resultTemp = _main.MelsecNetWordRead(IW_DATE_RESULT);

                int result = 0;
                int.TryParse(resultTemp, out result);

                Log(string.Format("{0}\t{1}", _component.ControlName, string.Format("PGM DATA RECV - {0} {1}", tmpMsg, result)));
                mYear += (ushort)2000;

                _main.SetLocalTime((ushort)mYear, (ushort)mMonth, (ushort)mDay, (ushort)mHour, (ushort)mMin, (ushort)mSec);

                result = RESULT_COMMAND_OK;

                _main.MelsecNetWordWrite(OW_DATE_RESULT, result);
                _main.MelsecNetBitOnOff(OB_DATE_TIME_SET, false);

                Log(string.Format("{0}\t{1}", _component.ControlName, string.Format("PGM DATA SEND - {0}", result)));

                //Log(string.Format("{0}\t{1}", _component.ControlName, "PGM DATA DISPLAY"));

                return 0;
            }
            catch (Exception ex)
            {
                Log(string.Format("{0}\t{1}", _component.ControlName, string.Format("PGM DATA ERROR - {0}", ex.Message)));
                _main.MelsecNetWordWrite(OW_DATE_RESULT, RESULT_COMMAND_ERROR);
                _main.MelsecNetBitOnOff(OB_DATE_TIME_SET, false);
                CLogManager.Instance.LogError("DateTimeSetCommand Execute Error",ex);
                return -99;
            }
        }
    }
}
