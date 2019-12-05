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

namespace YANGSYS.Biz.Programs
{

    public class MachineModeChangeCommand : AProgram
    {
        private CMain _main = null;
        private bool _enable = false;

        //BC
        private CScanControlProperties IB_MACHINE_MODE_CHANGE_COMMAND = null;
        private CScanControlProperties IW_MACHINE_MODE_CHANGE_COMMAND = null;

        //PROBE CIM
        private CPLCControlProperties OB_MACHINE_MODE_CHANGE_COMMAND_REPLY = null;
        private CPLCControlProperties OW_MACHINE_MODE_CHANGE_RETURN_CODE = null;


    //    18. Mode

    //- Normal , Force Clean, Cold Run 만 사용

    //- Force Clean 은 Recovery Mode 로 변경 가능성 있음.

    //- 추후 Map data spec 배초시 spec 에  사용 모드 명기 예정
        private const int NORMAL_MODE = 1;
        private const int FORCE_CLEAN_OUT_MODE = 2;
        //private const int SKIP_MODE = 3;
        //private const int LOADING_STOP_SEND_MODE = 4;
        private const int COLD_RUN_MODE = 5;
        //private const int REPROCESS_MODE = 6;
        //private const int CASSETTE_PENDING_MODE = 7;
        private const int RECOVERY_MODE = 8;
        //private const int FORCE_ETCH_MODE = 9;

        private const int MACHINE_MODE_ACCEPT = 1;
        private const int MACHINE_MODE_ALREADY_THIS_MODE = 2;
        private const int MACHINE_MODE_MACHINE_HAVE_NO_THIS_MODE = 3;
        private const int MACHINE_MODE_OTHER_ERROR = 4;

        private string _controlName = "";
        private CProbeControl _component = null;
        public MachineModeChangeCommand()
        {
        }
        public override int Init()
        {
            _enable = true;

            IB_MACHINE_MODE_CHANGE_COMMAND = _main.SCANCONTEROLS.GetProperty(_controlName, "IB_MACHINE_MODE_CHANGE_COMMAND");
            IW_MACHINE_MODE_CHANGE_COMMAND = _main.SCANCONTEROLS.GetProperty(_controlName, "IW_MACHINE_MODE_CHANGE_COMMAND");

            OB_MACHINE_MODE_CHANGE_COMMAND_REPLY = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_MACHINE_MODE_CHANGE_COMMAND_REPLY");
            OW_MACHINE_MODE_CHANGE_RETURN_CODE = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_MACHINE_MODE_CHANGE_RETURN_CODE");

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
            get { return "MACHINE_MODE_CHANGE_COMMAND"; }
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
            string temp = _main.MelsecNetWordRead(IW_MACHINE_MODE_CHANGE_COMMAND);

            int machineMode = 0;
            int returnCode = 0;
            bool check = false;

            int.TryParse(temp, out machineMode);

            check = _component.CIMMode != machineMode;
            //양전자 조건 검사 위치
            //에러: 
            //returnCode = check ? MACHINE_MODE_ACCEPT : MACHINE_MODE_ALREADY_THIS_MODE : MACHINE_MODE_MACHINE_HAVE_NO_THIS_MODE : MACHINE_MODE_OTHER_ERROR;


            _main.MelsecNetWordWrite(OW_MACHINE_MODE_CHANGE_RETURN_CODE, returnCode);

            CTimeout timeout = CTimeoutManager.GetTimeout(_component.ControlName, 2000);
            timeout.TargetOffValueCheck = true;
            timeout.Begin(OB_MACHINE_MODE_CHANGE_COMMAND_REPLY, _main.CONTROLATTRIBUTES.GetProperty(IB_MACHINE_MODE_CHANGE_COMMAND.ScanControlName, IB_MACHINE_MODE_CHANGE_COMMAND.ScanAttribute) as ITimeoutResource);

            _main.MelsecNetBitOnOff(OB_MACHINE_MODE_CHANGE_COMMAND_REPLY, true);

            //if (CTimeout.WaitSync(timeout, 10))
            //{
                if (returnCode == MACHINE_MODE_ACCEPT)
                {
                    //_main.MelsecNetBitOnOff(OB_CIM_MODE, cimMode == CIM_MODE_CIM_ON);
                    //CSubject subject = CUIManager.Inst.GetData("ucCimStatus");
                    //subject.SetValue("CIMMode", cimMode);
                    //subject.Notify();
                }
            //}
            //else
            //{
            //    //에러:응답이 없다..
            //}

            _main.MelsecNetBitOnOff(OB_MACHINE_MODE_CHANGE_COMMAND_REPLY, false);

            return 0;
        }
    }
}
