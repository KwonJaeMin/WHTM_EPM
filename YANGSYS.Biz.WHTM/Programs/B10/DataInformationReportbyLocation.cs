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

    public class DataInformationReportbyLocation : AProgram
    {
        private CMain _main = null;
        private bool _enable = false;

        //BC

        //PROBE CIM
        private CPLCControlProperties OW_POSITION_GLASS_EXIST = null;
        private CPLCControlProperties OW_POSITION001_GLASS_CODE = null;
        private CPLCControlProperties OW_POSITION002_GLASS_CODE = null;

        private string _controlName = "";
        private CProbeControl _component = null;

        public DataInformationReportbyLocation()
        {
        }
        public override int Init()
        {
            _enable = true;

            OW_POSITION_GLASS_EXIST = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_POSITION_GLASS_EXIST");
            OW_POSITION001_GLASS_CODE = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_POSITION001_GLASS_CODE");
            OW_POSITION002_GLASS_CODE = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_POSITION002_GLASS_CODE");


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
            get { return "DATA_INFORMATION_REPORT_BY_LOCATION"; }
        }

        public override string Version
        {
            get { return "ver 1.0"; }
        }

        public override string Description
        {
            get { return ""; }
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



            //양전자 데이터 제공
            //bool glassExit1 = false;
            //bool glassExit2 = false;

            int glassExit = _component.GlassExist1 ? 1:0;
            int resonCode1 = 0;
            int resonCode2 = 0;

            if (_component.GlassExist1)
            {
                CGlassDataProperties glassData = null;
                if (_main.ReceivedGlassDatas.ContainsKey(_component.ControlName))
                {
                    glassData = _main.ReceivedGlassDatas[_component.ControlName][0] as CGlassDataProperties;
                    if (glassData != null)
                    {
                        resonCode1= glassData.GlassCodeXXYYYY;
                        resonCode2 = glassData.GlassCodeZZZ;
                    }
                }
                else if (_main.ProcessingGlassDatas.ContainsKey(_component.ControlName))
                {
                    glassData = _main.ProcessingGlassDatas[_component.ControlName][0] as CGlassDataProperties;
                    if (glassData != null)
                    {
                        resonCode1= glassData.GlassCodeXXYYYY;
                        resonCode2 = glassData.GlassCodeZZZ;
                    }
                }

            }
            else
            {
                resonCode1 = 0;
                resonCode2 = 0;
            }

            _main.MelsecNetWordWrite(OW_POSITION_GLASS_EXIST, glassExit);
            _main.MelsecNetWordWrite(OW_POSITION001_GLASS_CODE, resonCode1);
            _main.MelsecNetWordWrite(OW_POSITION002_GLASS_CODE, resonCode2);


            return 0;
        }
    }
}
