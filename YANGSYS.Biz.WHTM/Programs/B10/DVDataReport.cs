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
    public class DVDataReport : AProgram
    {
        private CMain _main = null;
        private bool _enable = false;

        //BC


        //PROBE CIM
        private CPLCControlProperties OB_DV_DATA_REPORT = null;
        private CPLCControlProperties OW_DV_GLASS_CODE = null;
        private CPLCControlProperties OW_DV_DATA = null;


        private string _controlName = "";
        private CProbeControl _component = null;
        public DVDataReport()
        {
        }
        public override int Init()
        {
            _enable = true;

            OB_DV_DATA_REPORT = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_DV_DATA_REPORT");
            OW_DV_GLASS_CODE = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_DV_GLASS_CODE");
            OW_DV_DATA = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_DV_DATA");


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
            get { return "DV_DATA_REPORT"; }
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

            int glassCode = 10109;
            int processinginUnit = 324;

            List<int> dvData = new List<int>();
            dvData.Add(glassCode);//glass1
            dvData.Add(0);//glass1
            dvData.Add(processinginUnit);

            _main.MelsecNetWordWrite(OW_DV_GLASS_CODE, glassCode);

            _main.MelsecNetMultiWordWrite(OW_DV_DATA, dvData);

            _main.MelsecNetBitOnOff(OB_DV_DATA_REPORT, true);

            Thread.Sleep(1000);

            _main.MelsecNetBitOnOff(OB_DV_DATA_REPORT, false);

            return 0;
        }
    }
}
