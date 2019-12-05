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

    public class MachineTimeSetCommand : AProgram
    {
        private CMain _main = null;
        private bool _enable = false;

        //BC
        private CScanControlProperties IB_MACHINE_TIME_SET_COMMAND = null;
        private CScanControlProperties IW_SET_TIME_DATA_YEAR = null;
        private CScanControlProperties IW_SET_TIME_DATA_MONTH = null;
        private CScanControlProperties IW_SET_TIME_DATA_DAY = null;
        private CScanControlProperties IW_SET_TIME_DATA_HOUR = null;
        private CScanControlProperties IW_SET_TIME_DATA_MINUTE = null;
        private CScanControlProperties IW_SET_TIME_DATA_SECOND = null;

        //PROBE CIM
        private CPLCControlProperties OB_MACHINE_TIME_SET_REPLY = null;

        private const int NORMAL_MODE = 1;
        private const int FORCE_CLEAN_OUT_MODE = 2;
        private const int SKIP_MODE = 3;
        private const int LOADING_STOP_SEND_MODE = 4;
        private const int COLD_RUN_MODE = 5;
        private const int REPROCESS_MODE = 6;
        private const int CASSETTE_PENDING_MODE = 7;
        private const int RECOVERY_MODE = 8;
        private const int FORCE_ETCH_MODE = 9;

        private const int MACHINE_MODE_ACCEPT = 1;
        private const int MACHINE_MODE_ALREADY_THIS_MODE = 2;
        private const int MACHINE_MODE_MACHINE_HAVE_NO_THIS_MODE = 3;
        private const int MACHINE_MODE_OTHER_ERROR = 4;

        private string _controlName = "";
        private CProbeControl _component = null;
        public MachineTimeSetCommand()
        {
        }
        public override int Init()
        {
            _enable = true;

            IB_MACHINE_TIME_SET_COMMAND = _main.SCANCONTEROLS.GetProperty(_controlName, "IB_MACHINE_TIME_SET_COMMAND");
            IW_SET_TIME_DATA_YEAR = _main.SCANCONTEROLS.GetProperty(_controlName, "IW_MACHINE_TIME_SEND_YEAR");
            IW_SET_TIME_DATA_MONTH = _main.SCANCONTEROLS.GetProperty(_controlName, "IW_MACHINE_TIME_SEND_MONTH");
            IW_SET_TIME_DATA_DAY = _main.SCANCONTEROLS.GetProperty(_controlName, "IW_MACHINE_TIME_SEND_DAY");
            IW_SET_TIME_DATA_HOUR = _main.SCANCONTEROLS.GetProperty(_controlName, "IW_MACHINE_TIME_SEND_HOUR");
            IW_SET_TIME_DATA_MINUTE = _main.SCANCONTEROLS.GetProperty(_controlName, "IW_MACHINE_TIME_SEND_MINUTE");
            IW_SET_TIME_DATA_SECOND = _main.SCANCONTEROLS.GetProperty(_controlName, "IW_MACHINE_TIME_SEND_SECOND");

            OB_MACHINE_TIME_SET_REPLY = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_MACHINE_TIME_SET_REPLY");

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
            get { return "MACHINE_TIMESET_COMMAND"; }
        }

        public override string Version
        {
            get { return "ver 1.0"; }
        }

        public override string Description
        {
            get { return "BC에서 CIM MODE를 변경하라는 명령 처리 프로그램"; }
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
            string tmpYear = SmartDevice.UTILS.PLCUtils.HexToDec(_main.MelsecNetWordRead(IW_SET_TIME_DATA_YEAR));
            string tmpMonth = SmartDevice.UTILS.PLCUtils.HexToDec(_main.MelsecNetWordRead(IW_SET_TIME_DATA_MONTH));
            string tmpDay = SmartDevice.UTILS.PLCUtils.HexToDec(_main.MelsecNetWordRead(IW_SET_TIME_DATA_DAY));
            string tmpHour = SmartDevice.UTILS.PLCUtils.HexToDec(_main.MelsecNetWordRead(IW_SET_TIME_DATA_HOUR));
            string tmpMin = SmartDevice.UTILS.PLCUtils.HexToDec(_main.MelsecNetWordRead(IW_SET_TIME_DATA_MINUTE));
            string tmpSec = SmartDevice.UTILS.PLCUtils.HexToDec(_main.MelsecNetWordRead(IW_SET_TIME_DATA_SECOND));


            ushort mYear = 0;
            ushort mMonth = 0;
            ushort mDay = 0;
            ushort mHour = 0;
            ushort mMin = 0;
            ushort mSec = 0;

            ushort.TryParse(tmpYear, out mYear);
            ushort.TryParse(tmpMonth, out mMonth);
            ushort.TryParse(tmpDay, out mDay);
            ushort.TryParse(tmpHour, out mHour);
            ushort.TryParse(tmpMin, out mMin);
            ushort.TryParse(tmpSec, out mSec);

            //check = _component.CIMMode != machineMode;
            //양전자 조건 검사 위치
            //에러: 
            //returnCode = check ? MACHINE_MODE_ACCEPT : MACHINE_MODE_ALREADY_THIS_MODE : MACHINE_MODE_MACHINE_HAVE_NO_THIS_MODE : MACHINE_MODE_OTHER_ERROR;

            CTimeout timeout = CTimeoutManager.GetTimeout(_component.ControlName, 2000);
            timeout.TargetOffValueCheck = true;
            timeout.Begin(OB_MACHINE_TIME_SET_REPLY, _main.CONTROLATTRIBUTES.GetProperty(IB_MACHINE_TIME_SET_COMMAND.ScanControlName, IB_MACHINE_TIME_SET_COMMAND.ScanAttribute) as ITimeoutResource);

            _main.MelsecNetBitOnOff(OB_MACHINE_TIME_SET_REPLY, true);

            _main.SetLocalTime(mYear, mMonth, mDay, mHour, mMin, mSec);

            _main.MelsecNetBitOnOff(OB_MACHINE_TIME_SET_REPLY, false);

            return 0;
        }
    }
}
