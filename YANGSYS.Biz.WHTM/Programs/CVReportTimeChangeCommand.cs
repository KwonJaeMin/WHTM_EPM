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

    public class CVReportTimeChangeCommand : AProgram
    {
        private CMain _main = null;
        private bool _enable = false;

        //BC
        private CScanControlProperties IB_CV_REPORT_TIME_CHANGE_COMMAND = null;
        private CScanControlProperties IW_CV_REPORT_ENABLE_MODE = null;
        private CScanControlProperties IW_CV_REPORT_TIME = null;

        //PROBE CIM
        private CPLCControlProperties OB_CV_REPORT_TIME_CHANGE_COMMAND_REPLY = null;
        private CPLCControlProperties OW_CV_COMMAND_RETURN_CODE = null;

        private const int CV_ENABLE_MODE = 1;
        private const int CV_DISABLE_MODE = 2;

        private const int CV_TIME_CHANGE_OK = 1;
        private const int CV_TIME_CHANGE_NG = 2;

        private string _controlName = "";
        private CProbeControl _component = null;
        public CVReportTimeChangeCommand()
        {
        }
        public override int Init()
        {
            _enable = true;

            IB_CV_REPORT_TIME_CHANGE_COMMAND = _main.SCANCONTEROLS.GetProperty(_controlName, "IB_CV_REPORT_TIME_CHANGE_COMMAND");
            IW_CV_REPORT_ENABLE_MODE = _main.SCANCONTEROLS.GetProperty(_controlName, "IW_CV_REPORT_ENABLE_MODE");
            IW_CV_REPORT_TIME = _main.SCANCONTEROLS.GetProperty(_controlName, "IW_CV_REPORT_TIME");

            OB_CV_REPORT_TIME_CHANGE_COMMAND_REPLY = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_CV_REPORT_TIME_CHANGE_COMMAND_REPLY");
            OW_CV_COMMAND_RETURN_CODE = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_CV_COMMAND_RETURN_CODE");

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
            get { return "CV_REPORT_TIME_CHANGE_COMMAND"; }
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
        public override bool IsAsyncCall
        {
            get { return true; }
        }
        public override string SIteName
        {
            get { return "B07"; }
        }
        protected override int InnerExecute()
        {
            string temp = _main.MelsecNetWordRead(IW_CV_REPORT_ENABLE_MODE);
            string temp1 = _main.MelsecNetWordRead(IW_CV_REPORT_TIME);

            int cvEnable = 0;
            int cvTime = 0;
            int returnCode = 0;
            bool check = false;

            int.TryParse(temp, out cvEnable);
            int.TryParse(temp1, out cvTime);

            //check = _component.CIMMode != cvEnable;  임시
            //양전자 조건 검사 위치
            //에러: 
            returnCode = check ? CV_TIME_CHANGE_OK : CV_TIME_CHANGE_NG;

            _main.MelsecNetWordWrite(OW_CV_COMMAND_RETURN_CODE, returnCode);

            CTimeout timeout = CTimeoutManager.GetTimeout(_component.ControlName, _main.SystemConfig.T2_TimeOut * 1000);
            timeout.TargetOffValueCheck = true;
            timeout.Begin(OB_CV_REPORT_TIME_CHANGE_COMMAND_REPLY, _main.CONTROLATTRIBUTES.GetProperty(IB_CV_REPORT_TIME_CHANGE_COMMAND.ScanControlName, IB_CV_REPORT_TIME_CHANGE_COMMAND.ScanAttribute) as ITimeoutResource);

            _main.MelsecNetBitOnOff(OB_CV_REPORT_TIME_CHANGE_COMMAND_REPLY, true);

            //if (CTimeout.WaitSync(timeout, 10))
            //{
                if (returnCode == CV_TIME_CHANGE_OK)
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

            _main.MelsecNetBitOnOff(OB_CV_REPORT_TIME_CHANGE_COMMAND_REPLY, false);

            return 0;
        }
    }
}
