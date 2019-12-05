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
using SOFD.Global.Manager;


namespace YANGSYS.Biz.Programs
{

    public class GlassDataHandler : AProgram
    {
        private CMain _main = null;
        private bool _enable = false;

        //BC

        //PROBE CIM
        private CPLCControlProperties OB_RECEIVED_JOB_REPORT_UPSTREAMPATH1 = null;
        private CPLCControlProperties OW_JOB_DATA_FOR_UPSTREAM_BLOCK1 = null;
        private CPLCControlProperties OW_RECEIVED_JOB_DATA_SUB_BLOCK1 = null;
        private CPLCControlProperties OB_SENT_OUT_JOB_REPORT_DOWNSTREAMPATH1 = null;
        private CPLCControlProperties OW_JOB_DATA_FOR_DOWNSTREAM_BLOCK1 = null;
        private CPLCControlProperties OW_SENT_OUT_JOB_DATA_SUB_BLOCK1 = null;
        private CScanControlProperties IW_JOB_DATA_FOR_UPSTREAM_BLOCK1 = null;
        private CScanControlProperties IW_JOB_DATA_FOR_UPSTREAM_BLOCK2 = null;
        private CScanControlProperties IW_RECEIVED_JOB_DATA_SUB_BLOCK1 = null;
        private CScanControlProperties IW_RECEIVED_JOB_DATA_SUB_BLOCK2 = null;

        private CScanControlProperties IW_JOB_DATA_FOR_DOWNSTREAM_BLOCK1 = null;
        private CScanControlProperties IW_JOB_DATA_FOR_DOWNSTREAM_BLOCK2 = null;
        private CScanControlProperties IW_SENT_OUT_JOB_DATA_SUB_BLOCK1 = null;
        private CScanControlProperties IW_SENT_OUT_JOB_DATA_SUB_BLOCK2 = null;

        private string _controlName = "";
        private CProbeControl _component = null;
        private CIndexerControl _indexer = null;
        public GlassDataHandler()
        {
        }
        public override int Init()
        {
            _enable = true;

            OB_RECEIVED_JOB_REPORT_UPSTREAMPATH1 = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_RECEIVED_JOB_REPORT_UPSTREAMPATH1");
            OW_JOB_DATA_FOR_UPSTREAM_BLOCK1 = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_JOB_DATA_FOR_UPSTREAM_BLOCK1");
            OW_RECEIVED_JOB_DATA_SUB_BLOCK1 = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_RECEIVED_JOB_DATA_SUB_BLOCK1");

            OB_SENT_OUT_JOB_REPORT_DOWNSTREAMPATH1 = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_SENT_OUT_JOB_REPORT_DOWNSTREAMPATH1");
            OW_JOB_DATA_FOR_DOWNSTREAM_BLOCK1 = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_JOB_DATA_FOR_DOWNSTREAM_BLOCK1");
            OW_SENT_OUT_JOB_DATA_SUB_BLOCK1 = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_SENT_OUT_JOB_DATA_SUB_BLOCK1");

            IW_JOB_DATA_FOR_DOWNSTREAM_BLOCK1 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IW_JOB_DATA_FOR_DOWNSTREAM_BLOCK1");
            IW_JOB_DATA_FOR_DOWNSTREAM_BLOCK2 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IW_JOB_DATA_FOR_DOWNSTREAM_BLOCK2");
            IW_SENT_OUT_JOB_DATA_SUB_BLOCK1 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IW_SENT_OUT_JOB_DATA_SUB_BLOCK1");
            IW_SENT_OUT_JOB_DATA_SUB_BLOCK2 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IW_SENT_OUT_JOB_DATA_SUB_BLOCK2");

            IW_JOB_DATA_FOR_UPSTREAM_BLOCK1 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IW_JOB_DATA_FOR_UPSTREAM_BLOCK1");
            IW_JOB_DATA_FOR_UPSTREAM_BLOCK2 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IW_JOB_DATA_FOR_UPSTREAM_BLOCK2");
            IW_RECEIVED_JOB_DATA_SUB_BLOCK1 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IW_RECEIVED_JOB_DATA_SUB_BLOCK1");
            IW_RECEIVED_JOB_DATA_SUB_BLOCK2 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IW_RECEIVED_JOB_DATA_SUB_BLOCK2");

            _component.ProgramsAdd(this);
            return 0;
        }

        public override string Name
        {
            get { return "GLASS_DATA_HANDLER"; }
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
            get { return false; }
        }

        
        protected override int InnerExecute()
        {

            string action = "";
            CGlassDataProperties glassData = null;
            if(_values.ContainsKey("ACTION"))
            {
                action = _values["ACTION"];

                switch (action)
                {
                    case "READ_RECEIVED_GLASSDATA":

                        ushort[] jobDataRaw = null;
                        ushort[] jobDataSubRaw = null;

                        jobDataRaw = _main.MelsecNetMultiWordRead(IW_JOB_DATA_FOR_UPSTREAM_BLOCK1);
                        jobDataSubRaw = _main.MelsecNetMultiWordRead(IW_RECEIVED_JOB_DATA_SUB_BLOCK1);
                        glassData = new CGlassDataProperties(jobDataRaw);

                        break;
                    case "READ_PROCESSING_GLASSDATA":

                        if (_main.ProcessingGlassDatas.ContainsKey(_component.ControlName))
                        {
                            glassData = _main.ProcessingGlassDatas[_component.ControlName][0] as CGlassDataProperties;
                        }
                        break;
                    case "READ_SENTOUT_GLASSDATA":

                        jobDataRaw = _main.MelsecNetMultiWordRead(OW_JOB_DATA_FOR_UPSTREAM_BLOCK1, 64);
                        jobDataSubRaw = _main.MelsecNetMultiWordRead(OW_SENT_OUT_JOB_DATA_SUB_BLOCK1, 64);
                        glassData = new CGlassDataProperties(jobDataRaw);
                        break;
                    default:
                        break;
                }
            }

            
            if (glassData != null)
            {
                CSubject subject = CUIManager.Inst.GetData("frmGlassData");
                Dictionary<string, string> data = CGlassDataProperties.GetGuiData(glassData);
                subject.SetValue("Data", data);
                subject.Notify();
            }

            return 0;
        }

        public override int AddArgs(object[] args, bool beforeClear)
        {
            if (args == null || args.Length < 2)
                return -1;

            if ((args[0] is CMain && args[1] is CProbeControl && args[2] is CIndexerControl) == false)
            {
                return -1;
            }

            if (beforeClear)
            {

            }

            _main = args[0] as CMain;
            _component = args[1] as CProbeControl;
            _indexer = args[2] as CIndexerControl;
            _controlName = _component.ControlName;
            return 0;
        }
    }
}
