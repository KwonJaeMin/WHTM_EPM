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

    public class VCREnableModeChangeReport : AProgram
    {
        private CMain _main = null;
        private bool _enable = false;

        //BC
        private CScanControlProperties IB_STORED_JOB_REPORT_REPLY = null;

        //PROBE CIM
        private CPLCControlProperties OB_STORED_JOB_REPORT = null;

        private CPLCControlProperties OW_STORED_DATA_BLOCK = null;
        private CPLCControlProperties OW_STORED_DATA_UNIT_OR_PORT = null;
        private CPLCControlProperties OW_STORED_DATA_UNIT_NO = null;
        private CPLCControlProperties OW_STORED_DATA_SUB_UNIT_NO = null;
        private CPLCControlProperties OW_STORED_DATA_PORT_NO = null;
        private CPLCControlProperties OW_STORED_DATA_SLOT_NO = null;

        private const int CIM_MODE_CIM_OFF = 1;
        private const int CIM_MODE_CIM_ON = 2;

        private const int CIM_MODE_ACCEPT = 1;
        private const int CIM_MODE_ALREADY_IN_DESIRED_STATUS = 2;

        private string _controlName = "";
        private CProbeControl _component = null;
        public VCREnableModeChangeReport()
        {
        }

        public override int Init()
        {
            _enable = true;

            IB_STORED_JOB_REPORT_REPLY = _main.SCANCONTEROLS.GetProperty(_controlName, "IB_STORED_JOB_REPORT_REPLY");

            OB_STORED_JOB_REPORT = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_STORED_JOB_REPORT");
            OW_STORED_DATA_BLOCK = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_STORED_DATA_BLOCK");
            OW_STORED_DATA_UNIT_OR_PORT = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_STORED_JOB_DATA_SUB_BLOCK1");
            OW_STORED_DATA_UNIT_NO = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_STORED_JOB_DATA_SUB_BLOCK1");
            OW_STORED_DATA_SUB_UNIT_NO = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_STORED_JOB_DATA_SUB_BLOCK1");
            OW_STORED_DATA_PORT_NO = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_STORED_JOB_DATA_SUB_BLOCK1");
            OW_STORED_DATA_SLOT_NO = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_STORED_JOB_DATA_SUB_BLOCK1");

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
            get { return "VCR_ENABLE_MODE_CHANGE_REPORT"; }
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
        
        public const int UNIT = 1;
        public const int PORT = 2;

        protected override int InnerExecute()
        {
            List<int> storedJobData = new List<int>();
            int unitOrPort = UNIT;
            int unitNo = 0;
            int subUnitNo = 0;
            int portNo = 0;
            int slotNO = 0;

            _main.MelsecNetMultiWordWrite(OW_STORED_DATA_BLOCK, storedJobData);
            _main.MelsecNetWordWrite(OW_STORED_DATA_UNIT_OR_PORT, unitOrPort);
            _main.MelsecNetWordWrite(OW_STORED_DATA_UNIT_NO, unitNo);
            _main.MelsecNetWordWrite(OW_STORED_DATA_SUB_UNIT_NO, subUnitNo);
            _main.MelsecNetWordWrite(OW_STORED_DATA_PORT_NO, portNo);
            _main.MelsecNetWordWrite(OW_STORED_DATA_SLOT_NO, slotNO);

            CTimeout timeout = CTimeoutManager.GetTimeout(_component.ControlName, 2000);
            timeout.TargetOffValueCheck = true;
            timeout.Begin(OB_STORED_JOB_REPORT, _main.CONTROLATTRIBUTES.GetProperty(IB_STORED_JOB_REPORT_REPLY.ScanControlName, IB_STORED_JOB_REPORT_REPLY.ScanAttribute) as ITimeoutResource);

            _main.MelsecNetBitOnOff(OB_STORED_JOB_REPORT, true);

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

            _main.MelsecNetBitOnOff(OB_STORED_JOB_REPORT, false);

            return 0;
        }
    }
}
