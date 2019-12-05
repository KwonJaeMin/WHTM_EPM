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
using SOFD.Global.Manager;


namespace YANGSYS.Biz.Programs
{

    public class MachineStatusReport : AProgram
    {
        private CMain _main = null;
        private bool _enable = false;

        //BC
        private CScanControlProperties IB_MACHINE_STATUS_CHANGE_REPORT_REPLY = null;

        //PROBE CIM
        private CPLCControlProperties OB_MACHINE_STATUS_CHANGE_REPORT = null;
        private CPLCControlProperties OW_MACHINE_STATUS = null;
        private CPLCControlProperties OW_MACHINE_REASON_CODE = null;
        private CPLCControlProperties OW_MACHINE_DOWN_ALARM_CODE = null;
        private CPLCControlProperties OW_UNIT1_STATUS = null;
        
        //YANGSYS
        private CScanControlProperties VI_STATE_CHANGE_EVENT = null;
        private CScanControlProperties VI_ALARM_SET = null;
        
        //Machine / Unit Status
        private const int STATUS_RUN = 1;
        private const int STATUS_IDLE = 2;
        private const int STATUS_DOWN = 3;
        private const int STATUS_PM = 4;

        private const int YES_SETUP = 1;
        private const int YES_STOP = 2;
        private const int YES_PAUSE = 3;
        private const int YES_IDLE = 4;
        private const int YES_RUN = 5;
        //Machine Reason Code
    //    20. Machine Reason Code 사용 여부
    //- F Run, PM 만 사용
        private const int REASON_F_RUN = 1;
        //private const int REASON_P_RUN = 2;
        //private const int REASON_LOW_WIP = 3;
        //private const int REASON_MOVE_SLOW = 4;
        //private const int REASON_ETC = 5;
        //private const int REASON_WAITING = 6;
        //private const int REASON_E_DOWN = 7;
        //private const int REASON_PAUSE = 8;
        private const int REASON_PM = 9;
        //private const int REASON_MAINTENANCE = 10;

        private string _controlName = "";
        private CProbeControl _component = null;

        public MachineStatusReport()
        {
        }
        public override int Init()
        {
            _enable = true;

            IB_MACHINE_STATUS_CHANGE_REPORT_REPLY = _main.SCANCONTEROLS.GetProperty(_controlName, "IB_MACHINE_STATUS_CHANGE_REPORT_REPLY");

            OB_MACHINE_STATUS_CHANGE_REPORT = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_MACHINE_STATUS_CHANGE_REPORT");
            OW_MACHINE_STATUS = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_MACHINE_STATUS");
            OW_MACHINE_REASON_CODE = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_MACHINE_REASON_CODE");
            OW_MACHINE_DOWN_ALARM_CODE = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_MACHINE_DOWN_ALARM_CODE");
            OW_UNIT1_STATUS = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_UNIT1_STATUS");

            VI_STATE_CHANGE_EVENT = _main._YANSYS_SCANCONTEROLS.GetProperty(_controlName, "VI_STATE_CHANGE_EVENT");
            VI_ALARM_SET = _main._YANSYS_SCANCONTEROLS.GetProperty(_controlName, "VI_ALARM_SET");
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
            get { return "MACHINE_STATUS_CHANGE_REPORT"; }
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
            //양전자 데이터 제공
            int machineStatus = _component.EqpStatus;
            int resonCode = 0;
            int downAlarmCode = 0;
            int unitStatus = 0;

            //양전자값
            //1:SETUP
            //2:STOP
            //3:PAUSE
            //4:IDLE
            //5:RUN
            
            switch (machineStatus)
            {  
                case YES_SETUP:
                    machineStatus = STATUS_PM;
                    resonCode = REASON_PM;
                    break;
                case YES_PAUSE:
                case YES_STOP:
                    machineStatus = STATUS_DOWN;                    
                    int.TryParse(_component.LastAlarmCode, out downAlarmCode);
                    resonCode = REASON_F_RUN;
                    break;
                case YES_IDLE:
                    machineStatus = STATUS_IDLE;
                    break;
                case YES_RUN:
                    machineStatus = STATUS_RUN;
                    break;
                default:
                    return -1;
            }
            _component.LastAlarmCode = "";
            _component.LastAlarmText = "";
            string temp = VI_ALARM_SET.Value;

            _main.MelsecNetWordWrite(OW_MACHINE_STATUS, machineStatus);
            _main.MelsecNetWordWrite(OW_MACHINE_REASON_CODE, resonCode);
            _main.MelsecNetWordWrite(OW_MACHINE_DOWN_ALARM_CODE, downAlarmCode);
            _main.MelsecNetWordWrite(OW_UNIT1_STATUS, machineStatus);

            CTimeout timeout = CTimeoutManager.GetTimeout(_component.ControlName, 10000);
            timeout.Begin(OB_MACHINE_STATUS_CHANGE_REPORT, _main.CONTROLATTRIBUTES.GetProperty(IB_MACHINE_STATUS_CHANGE_REPORT_REPLY.ScanControlName, IB_MACHINE_STATUS_CHANGE_REPORT_REPLY.ScanAttribute) as ITimeoutResource);

            _main.MelsecNetBitOnOff(OB_MACHINE_STATUS_CHANGE_REPORT, true);

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

            _main.MelsecNetBitOnOff(OB_MACHINE_STATUS_CHANGE_REPORT, false);

            return 0;
        }
    }
}
