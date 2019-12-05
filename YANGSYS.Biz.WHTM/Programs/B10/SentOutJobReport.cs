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

    public class SentOutJobReport : AProgram
    {
        private CMain _main = null;
        private bool _enable = false;

        //BC
        private CScanControlProperties IB_SENT_OUT_JOB_REPORT_REPLY_DOWNSTREAM_PATH1 = null;

        //PROBE CIM
        private CPLCControlProperties OB_SENT_OUT_JOB_REPORT_DOWNSTREAMPATH1 = null;
        private CPLCControlProperties OW_JOB_DATA_FOR_DOWNSTREAM_BLOCK1 = null;
        private CPLCControlProperties OW_SENT_OUT_JOB_DATA_SUB_BLOCK1 = null;

        private string _controlName = "";
        private CProbeControl _component = null;
        public SentOutJobReport()
        {
        }
        public override int Init()
        {
            _enable = true;

            IB_SENT_OUT_JOB_REPORT_REPLY_DOWNSTREAM_PATH1 = _main.SCANCONTEROLS.GetProperty(_controlName, "IB_SENT_OUT_JOB_REPORT_REPLY_DOWNSTREAM_PATH1");

            OB_SENT_OUT_JOB_REPORT_DOWNSTREAMPATH1 = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_SENT_OUT_JOB_REPORT_DOWNSTREAMPATH1");
            OW_JOB_DATA_FOR_DOWNSTREAM_BLOCK1 = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_JOB_DATA_FOR_DOWNSTREAM_BLOCK1");
            OW_SENT_OUT_JOB_DATA_SUB_BLOCK1 = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_SENT_OUT_JOB_DATA_SUB_BLOCK1");

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
            get { return "SENT_OUT_JOB_REPORT"; }
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
            if (_main.ReceivedGlassDatas.ContainsKey(_component.ControlName) == false)
            {
                return -1;
            }

            CGlassDataProperties glassData = _main.ReceivedGlassDatas[_component.ControlName][0] as CGlassDataProperties;
            List<int> receiveJobData = CGlassDataProperties.ConvertPLCData(glassData);
            List<int> receiveJobDataSub = new List<int>();
            receiveJobDataSub.Add(1);
            receiveJobDataSub.Add(1);
            
            _main.MelsecNetMultiWordWrite(OW_JOB_DATA_FOR_DOWNSTREAM_BLOCK1, receiveJobData);
            _main.MelsecNetMultiWordWrite(OW_SENT_OUT_JOB_DATA_SUB_BLOCK1, receiveJobDataSub);

            CTimeout timeout = CTimeoutManager.GetTimeout(_component.ControlName, 2000);
   
            timeout.Begin(OB_SENT_OUT_JOB_REPORT_DOWNSTREAMPATH1, _main.CONTROLATTRIBUTES.GetProperty(IB_SENT_OUT_JOB_REPORT_REPLY_DOWNSTREAM_PATH1.ScanControlName, IB_SENT_OUT_JOB_REPORT_REPLY_DOWNSTREAM_PATH1.ScanAttribute) as ITimeoutResource);

            _main.MelsecNetBitOnOff(OB_SENT_OUT_JOB_REPORT_DOWNSTREAMPATH1, true);

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

            _main.MelsecNetBitOnOff(OB_SENT_OUT_JOB_REPORT_DOWNSTREAMPATH1, false);

            if (glassData != null)
            {
                //CSubject subject = CUIManager.Inst.GetData("GlassInfoDisplay");
                //Dictionary<string, string> data = CGlassDataProperties.GetGuiData(glassData);
                //subject.SetValue("GlassInfos", data);
                //subject.Notify();
            }
            return 0;
        }
    }
}
