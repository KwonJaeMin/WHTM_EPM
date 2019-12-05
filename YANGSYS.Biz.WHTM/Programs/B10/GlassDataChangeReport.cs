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


namespace YANGSYS.Biz.Programs
{

    public class GlassDataChangeReport : AProgram
    {
        private CMain _main = null;
        private bool _enable = false;

        //BC
        private CScanControlProperties IB_GLASS_DATA_CHANGE_REPORT_REPLY = null;

        //PROBE CIM
        private CPLCControlProperties OB_GLASS_DATA_CHANGE_REPORT = null;
        private CPLCControlProperties OW_GLASS_DATA_CHANGE_REPORT = null;

        private const int CIM_MODE_CIM_OFF = 1;
        private const int CIM_MODE_CIM_ON = 2;

        private const int CIM_MODE_ACCEPT = 1;
        private const int CIM_MODE_ALREADY_IN_DESIRED_STATUS = 2;

        private string _controlName = "";
        private CProbeControl _component = null;
        public GlassDataChangeReport()
        {
        }
        public override int Init()
        {
            _enable = true;

            IB_GLASS_DATA_CHANGE_REPORT_REPLY = _main.SCANCONTEROLS.GetProperty(_controlName, "IB_GLASS_DATA_CHANGE_REPORT_REPLY");

            OB_GLASS_DATA_CHANGE_REPORT = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_GLASS_DATA_CHANGE_REPORT");
            OW_GLASS_DATA_CHANGE_REPORT = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_GLASS_DATA_CHANGE_REPORT");

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
            get { return "GLASS_DATA_CHANGE_REPORT"; }
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
        public override int ExecuteManual(Dictionary<string, string> values)
        {
            _values = values;
            userNewGlassData = new CGlassDataProperties(CGlassDataProperties.GetGuiDataToPLC(values));
            _userRequest = true;
            InnerExecute();
            return 0;
        }
        CGlassDataProperties userNewGlassData = null;
        bool _userRequest = false;
        
        public const int UNIT = 1;
        public const int PORT = 2;

        protected override int InnerExecute()
        {
            List<int> changedJobData = new List<int>();
            if (_userRequest)
            {
                _userRequest = false;
                if (userNewGlassData != null)
                {
                    changedJobData = CGlassDataProperties.ConvertPLCData(userNewGlassData);
                }
            }
            _main.MelsecNetMultiWordWrite(OW_GLASS_DATA_CHANGE_REPORT, changedJobData);

            CTimeout timeout = CTimeoutManager.GetTimeout(_component.ControlName, 2000);//시뮬레이션 테스트로 10000 설정함);           
            timeout.Begin(OB_GLASS_DATA_CHANGE_REPORT, _main.CONTROLATTRIBUTES.GetProperty(IB_GLASS_DATA_CHANGE_REPORT_REPLY.ScanControlName, IB_GLASS_DATA_CHANGE_REPORT_REPLY.ScanAttribute) as ITimeoutResource);

            _main.MelsecNetBitOnOff(OB_GLASS_DATA_CHANGE_REPORT, true);

            if (CTimeout.WaitSync(timeout, 10))
            {
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

            _main.MelsecNetBitOnOff(OB_GLASS_DATA_CHANGE_REPORT, false);

            return 0;
        }
    }
}
