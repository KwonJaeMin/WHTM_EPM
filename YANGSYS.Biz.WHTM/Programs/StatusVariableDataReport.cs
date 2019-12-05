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

    public class StatusVariableDataReport : AProgram
    {
        private CMain _main = null;
        private bool _enable = false;

        //BC

        //PROBE CIM
        //PROBE CIM
        private CPLCControlProperties OB_SV_DATA_REPORT = null;
        private CPLCControlProperties OW_SV_DATA = null;

        private string _controlName = "";
        private CProbeControl _component = null;
        public StatusVariableDataReport()
        {
        }
        public override int Init()
        {
            _enable = true;

            OW_SV_DATA = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_SV_DATA");

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
            get { return "STATUS_VARIABLE_DATA_REPORT"; }
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

            int glassCode = 101;
            int processinginUnit = 789;

            List<int> SvData = new List<int>();
            SvData.Add(glassCode);//glass1
            SvData.Add(222);//glass1
            SvData.Add(processinginUnit);

            _main.MelsecNetMultiWordWrite(OW_SV_DATA, SvData);

            //_main.MelsecNetBitOnOff(OB_SV_DATA_REPORT, true);

            //Thread.Sleep(1000);

            //_main.MelsecNetBitOnOff(OB_SV_DATA_REPORT, false);

            return 0;
        }
    }
}
