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


namespace YANGSYS.Biz.Programs
{

    public class LoadingStopRelease : AProgram
    {
        private CMain _main = null;
        private bool _enable = false;

        //BC
        private CScanControlProperties IB_LOADING_STOP_RELEASE_REPLY = null;
        private CScanControlProperties IW_LOADING_STOP_RELEASE_RETURN = null;

        //PROBE CIM
        private CPLCControlProperties OB_LOADING_STOP_RELEASE = null;


        public const int LOADING_STOP_RELEASE_OK = 1;
        public const int LOADING_STOP_RELEASE_NG = 2;

        private string _controlName = "";
        private CProbeControl _component = null;
        public LoadingStopRelease()
        {
        }
        public override int Init()
        {
            _enable = true;


            IB_LOADING_STOP_RELEASE_REPLY = _main.SCANCONTEROLS.GetProperty(_controlName, "IB_LOADING_STOP_RELEASE_REPLY");
            IW_LOADING_STOP_RELEASE_RETURN = _main.SCANCONTEROLS.GetProperty(_controlName, "IW_LOADING_STOP_RELEASE_RETURN");

            OB_LOADING_STOP_RELEASE = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LOADING_STOP_RELEASE");


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
            get { return "LOADING_STOP_RELEASE"; }
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
        private int InnerExecute()
        {

            int returnCode = 0;

            CTimeout timeout = CTimeoutManager.GetTimeout(_component.ControlName, 2000);
            timeout.TargetOffValueCheck = true;
            timeout.Begin(OB_LOADING_STOP_RELEASE, _main.CONTROLATTRIBUTES.GetProperty(IB_LOADING_STOP_RELEASE_REPLY.ScanControlName, IB_LOADING_STOP_RELEASE_REPLY.ScanAttribute) as ITimeoutResource);

            _main.MelsecNetBitOnOff(OB_LOADING_STOP_RELEASE, true);

            if (CTimeout.WaitSync(timeout, 10))
            {
                string temp = _main.MelsecNetWordRead(IW_LOADING_STOP_RELEASE_RETURN);

                int.TryParse(temp, out returnCode);

                if (returnCode == LOADING_STOP_RELEASE_OK)
                {

                }


                //if (returnCode == CIM_MODE_ACCEPT)
                //{
                //    _main.MelsecNetBitOnOff(OB_CIM_MODE, cimMode == CIM_MODE_CIM_ON);
                //    CSubject subject = CUIManager.Inst.GetData("ucCimStatus");
                //    subject.SetValue("CIMMode", cimMode);
                //    subject.Notify();
                //}
            }
            else
            {
                //에러:응답이 없다..
            }

            _main.MelsecNetBitOnOff(OB_LOADING_STOP_RELEASE, false);

            return 0;
        }
    }
}
