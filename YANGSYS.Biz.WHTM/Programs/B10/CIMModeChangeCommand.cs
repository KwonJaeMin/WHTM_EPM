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

    public class CIMModeChangeCommand : AProgram
    {
        private CMain _main = null;
        private bool _enable = false;

        //BC
        private CScanControlProperties IB_CIM_MODE_CHANGE_COMMAND = null;
        private CScanControlProperties IW_CIM_MODE = null;

        //PROBE CIM
        private CPLCControlProperties OB_CIM_MODE = null;
        private CPLCControlProperties OB_CIM_MODE_CHANGE_COMMAND_REPLY = null;
        private CPLCControlProperties OW_CIM_MODE_CHANGE_RETURN_CODE = null;

        private const int CIM_MODE_CIM_OFF = 1;
        private const int CIM_MODE_CIM_ON = 2;

        private const int CIM_MODE_ACCEPT = 1;
        private const int CIM_MODE_ALREADY_IN_DESIRED_STATUS = 2;

        private string _controlName = "";
        private CProbeControl _component = null;
        public CIMModeChangeCommand()
        {
        }
        public override int Init()
        {
            _enable = true;

            IB_CIM_MODE_CHANGE_COMMAND = _main.SCANCONTEROLS.GetProperty(_controlName, "IB_CIM_MODE_CHANGE_COMMAND");
            IW_CIM_MODE = _main.SCANCONTEROLS.GetProperty(_controlName, "IW_CIM_MODE");

            OB_CIM_MODE = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_CIM_MODE");
            OB_CIM_MODE_CHANGE_COMMAND_REPLY = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_CIM_MODE_CHANGE_COMMAND_REPLY");
            OW_CIM_MODE_CHANGE_RETURN_CODE = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_CIM_MODE_CHANGE_RETURN_CODE");

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
            get { return "CIM_MODE_CHANGE_COMMAND"; }
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
            string temp = _main.MelsecNetWordRead(IW_CIM_MODE);

            int cimMode = 0;
            int returnCode = 0;
            bool check = false;

            int.TryParse(temp, out cimMode);                        
            
            check = _component.CIMMode != cimMode;
            //양전자 조건 검사 위치
            //에러: 
            returnCode = check ? CIM_MODE_ACCEPT : CIM_MODE_ALREADY_IN_DESIRED_STATUS;

            _main.MelsecNetWordWrite(OW_CIM_MODE_CHANGE_RETURN_CODE, returnCode);

            CTimeout timeout = CTimeoutManager.GetTimeout(_component.ControlName, 2000);
            timeout.TargetOffValueCheck = true;            
            timeout.Begin(OB_CIM_MODE_CHANGE_COMMAND_REPLY, _main.CONTROLATTRIBUTES.GetProperty(IB_CIM_MODE_CHANGE_COMMAND.ScanControlName, IB_CIM_MODE_CHANGE_COMMAND.ScanAttribute) as ITimeoutResource);

            _main.MelsecNetBitOnOff(OB_CIM_MODE_CHANGE_COMMAND_REPLY, true);

            if (CTimeout.WaitSync(timeout, 10))
            {
                
                if (returnCode == CIM_MODE_ACCEPT)
                {
                    _component.CIMMode = cimMode;
                    _main.MelsecNetBitOnOff(OB_CIM_MODE, _component.CIMMode == CIM_MODE_CIM_ON);
                    CSubject subject = CUIManager.Inst.GetData("ucCimStatus");
                    subject.SetValue("CIMMode", cimMode);
                    subject.Notify();
                }
            }
            else
            {
                //에러:응답이 없다..
            }
            //Thread.Sleep(1000);
            _main.MelsecNetBitOnOff(OB_CIM_MODE_CHANGE_COMMAND_REPLY, false);

            return 0;
        }
    }
}
