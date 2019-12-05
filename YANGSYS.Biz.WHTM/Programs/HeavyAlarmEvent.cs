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

using System.Threading;

namespace YANGSYS.Biz.Programs
{

    public class HeavyAlarmEvent : AProgram
    {
        private CMain _main = null;
        private bool _enable = false;

        //BC


        //PROBE CIM
        private CPLCControlProperties OB_SERIOUS_ALARM_OCCURRED = null;
        private CPLCControlProperties OB_SERIOUS_ALARM_CLEARED = null;
        private CPLCControlProperties OW_SERIOUS_ALARM_CODE = null;
        
        private string _controlName = "";
        private CProbeControl _component = null;
        public HeavyAlarmEvent()
        {
        }
        public override int Init()
        {
            _enable = true;




            OB_SERIOUS_ALARM_OCCURRED = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_SERIOUS_ALARM_OCCURRED");
            OB_SERIOUS_ALARM_CLEARED = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_SERIOUS_ALARM_CLEARED");
            OW_SERIOUS_ALARM_CODE = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_SERIOUS_ALARM_CODE");

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
            get { return "HEAVY_ALARM_EVENT"; }
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
        private delegate int InnerExecuteHandler();
        public override int Execute()
        {

            InnerExecuteHandler del = new InnerExecuteHandler(InnerExecute);
            del.BeginInvoke(null, null);
            return 0;
        }
        public override int Execute(Dictionary<string, string> values)
        {
            throw new NotImplementedException();
        }
        public const int UNIT = 1;
        public const int PORT = 2;

        public const int T1 = 1000;
        public const int T2 = 500; //연속 발생시

        private int InnerExecute()
        {
            bool alarmSet = false;
            int alarmCode = 0;


            if (alarmSet)
            {
                _main.MelsecNetWordWrite(OW_SERIOUS_ALARM_CODE, alarmCode);
                _main.MelsecNetBitOnOff(OB_SERIOUS_ALARM_OCCURRED, true);
                Thread.Sleep(T1);
                _main.MelsecNetBitOnOff(OB_SERIOUS_ALARM_OCCURRED, false);
            }
            else
            {
                _main.MelsecNetWordWrite(OW_SERIOUS_ALARM_CODE, 0); //All clear 시
                _main.MelsecNetBitOnOff(OB_SERIOUS_ALARM_CLEARED, true);
                Thread.Sleep(T1);
                _main.MelsecNetBitOnOff(OB_SERIOUS_ALARM_CLEARED, false);
            }

            return 0;
        }
    }
}
