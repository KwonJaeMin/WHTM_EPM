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

    public class ReceivedJobReport : AProgram
    {
        private CMain _main = null;
        private bool _enable = false;

        //BC
        private CScanControlProperties IB_RECEIVED_JOB_REPORT_REPLY_UPSTREAM_PATH1 = null;

        //PROBE CIM
        private CPLCControlProperties OB_RECEIVED_JOB_REPORT_UPSTREAMPATH1 = null;
        private CPLCControlProperties OW_JOB_DATA_FOR_UPSTREAM_BLOCK1 = null;
        private CPLCControlProperties OW_RECEIVED_JOB_DATA_SUB_BLOCK1 = null;

        private string _controlName = "";
        private CProbeControl _component = null;
        public ReceivedJobReport()
        {
        }
        public override int Init()
        {
            _enable = true;

            IB_RECEIVED_JOB_REPORT_REPLY_UPSTREAM_PATH1 = _main.SCANCONTEROLS.GetProperty(_controlName, "IB_RECEIVED_JOB_REPORT_REPLY_UPSTREAM_PATH1");

            OB_RECEIVED_JOB_REPORT_UPSTREAMPATH1 = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_RECEIVED_JOB_REPORT_UPSTREAMPATH1");
            OW_JOB_DATA_FOR_UPSTREAM_BLOCK1 = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_JOB_DATA_FOR_UPSTREAM_BLOCK1");
            OW_RECEIVED_JOB_DATA_SUB_BLOCK1 = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_RECEIVED_JOB_DATA_SUB_BLOCK1");


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
            get { return "RECEIVED_JOB_REPORT"; }
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
            if(_main.ReceivedGlassDatas.ContainsKey(_component.ControlName) == false)
            {
                return -1;
            }

            CGlassDataProperties glassData = _main.ReceivedGlassDatas[_component.ControlName];

            List<int> receiveJobData = CGlassDataProperties.ConvertPLCData(glassData);
            List<int> receiveJobDataSub = new List<int>();
            receiveJobDataSub.Add(1); //upstream path no 
            receiveJobDataSub.Add(1); //total glass count

            _main.MelsecNetMultiWordWrite(OW_JOB_DATA_FOR_UPSTREAM_BLOCK1, receiveJobData);
            _main.MelsecNetMultiWordWrite(OW_RECEIVED_JOB_DATA_SUB_BLOCK1, receiveJobDataSub);

            CTimeout timeout = CTimeoutManager.GetTimeout(_component.ControlName, 2000);
            timeout.Begin(OB_RECEIVED_JOB_REPORT_UPSTREAMPATH1, _main.CONTROLATTRIBUTES.GetProperty(IB_RECEIVED_JOB_REPORT_REPLY_UPSTREAM_PATH1.ScanControlName, IB_RECEIVED_JOB_REPORT_REPLY_UPSTREAM_PATH1.ScanAttribute) as ITimeoutResource);

            _main.MelsecNetBitOnOff(OB_RECEIVED_JOB_REPORT_UPSTREAMPATH1, true);

            //if (CTimeout.WaitSync(timeout, 10))
            //{
                //if (returnCode == CIM_MODE_ACCEPT)
                //{
                //    _main.MelsecNetBitOnOff(OB_CIM_MODE, cimMode == CIM_MODE_CIM_ON);
                //    CSubject subject = CUIManager.Inst.GetData("ucCimStatus");
                //    subject.SetValue("CIMMode", cimMode);
                //    subject.Notify();
                //}
            //}
            //else
            //{
            //    //에러:응답이 없다..
            //}

            //딜레이 추가

            _main.MelsecNetBitOnOff(OB_RECEIVED_JOB_REPORT_UPSTREAMPATH1, false);

            if (glassData != null)
            {
                CSubject subject = CUIManager.Inst.GetData("GlassInfoDisplay");
                Dictionary<string, string> data = CGlassDataProperties.GetGuiData(glassData);
                subject.SetValue("Data", data);
                subject.Notify();
            }

            return 0;
        }
        public override int Execute(Dictionary<string, string> values)
        {
            throw new NotImplementedException();
        }
    }
}
