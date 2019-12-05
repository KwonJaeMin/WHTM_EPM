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

using SOFD.Logger;
using SOFD.Global.Manager;
using System.Threading;

namespace YANGSYS.Biz.Programs
{

    public class EqpStatusReport : AProgram
    {
        private CMain _main = null;
        private bool _enable = false;

        //BC
        private CScanControlProperties IB_EQP_STATUS_REPORT = null;//RV_B_EqpStatusReport_L3ToBC
        //PROBE CIM
        private CPLCControlProperties OB_EQP_STATUS_REPORT = null;//RV_B_EqpStatusReport_L3ToBC
        private CPLCControlProperties OW_EQP_STATUS = null;//RV_W_EqpStatusBlock_L3ToBC,0
        private CPLCControlProperties OW_EQP_SUB_MOUDLE_STATUS1 = null;//RV_W_EqpStatusBlock_L3ToBC,1

        private const int STATUS_IDLE = 1;//1 : Idle
        private const int STATUS_RUN = 2;//2 : Run
        private const int STATUS_DOWN = 3; //3 : Down
        private const int STATUS_PM = 4;    //4 : PM
        private const int STATUS_STOP = 5;    //4 : PM

        private string _controlName = "";
        private CProbeControl _component = null;

        public EqpStatusReport()
        {
        }

        public override int Init()
        {
            _enable = true;
            //BC
            IB_EQP_STATUS_REPORT = _main.SCANCONTEROLS.GetProperty(_controlName, "IB_EQP_STATUS_REPORT"); ;//RV_B_EqpStatusReport_L3ToBC
            //PROBE CIM
            OB_EQP_STATUS_REPORT = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_EQP_STATUS_REPORT");
            OW_EQP_STATUS = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_EQP_STATUS");
            OW_EQP_SUB_MOUDLE_STATUS1 = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_EQP_SUB_MOUDLE_STATUS1");

            _component.ProgramsAdd(this);
            
            ProgramDataList = new List<CProgramData>();

            CProgramData data = new CProgramData(ProgramDataList.Count, "EQP_STATUS", typeof(int));
            data.Add(1, "Idle");
            data.Add(2, "Run");
            data.Add(3, "Down");
            data.Add(4, "PM");
            data.Add(5, "STOP");
            data.ValueType = typeof(int);
            ProgramDataList.Add(data);

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
            get { return "EQP_STATUS_REPORT"; }
        }

        public override string Version
        {
            get { return "ver 1.0"; }
        }

        public override string Description
        {
            get { return "장비 STATUS를 보고 하는 프로그램"; }
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
            get { return "WHTM"; }
        }
        public override bool IsAsyncCall
        {
            get { return true; }
        }

        private const int T1 = 4000;
        protected override int InnerExecute()
        {
            int status = 0;
            if (_isManualMode)
                status = (int)ProgramDataList[0].Value;
            else
                status = _component.EqpStatus;



            int bcStatus = status;

            //switch (status.ToString())
            //{
            //    case "1":
            //        bcStatus = 1;
            //        break;
            //    case "2":
            //        bcStatus = 2;
            //        break;
            //    case "3":
            //        bcStatus = 3;
            //        break;
            //    case "4":
            //        bcStatus = 4;
            //        break;
            //    case "5":
            //        bcStatus = 5;
            //        break;
            //    default:
            //        break;
            //}
            _main.MelsecNetWordWrite(OW_EQP_STATUS, bcStatus);
            //_main.MelsecNetWordWrite(OW_EQP_SUB_MOUDLE_STATUS1, status); 사용하지 않음.
            
            //_main.MelsecNetBitOnOff(OB_EQP_STATUS_REPORT, true);
            Log(string.Format("{0}\t{1}", _component.ControlName, string.Format("PGM DATA SEND - EQP STATUS={0}", status)));

            Log(string.Format("{0}\t{1}", _component.ControlName, "PGM DATA DISPLAY"));

            CSubject subject = null;// CUIManager.Inst.GetData("ucCimStatus");
            //subject.SetValue("EQPSTATUS", _component.MachineAutoMode);
            //subject.Notify();

            //Thread.Sleep(1000);
            //_main.MelsecNetBitOnOff(OB_EQP_STATUS_REPORT, false);


            CTimeout timeout = CTimeoutManager.GetTimeout(_controlName, T1);
            timeout.TargetOffValueCheck = true;
            timeout.Begin(OB_EQP_STATUS_REPORT, _main.CONTROLATTRIBUTES.GetProperty(IB_EQP_STATUS_REPORT.ControlName, IB_EQP_STATUS_REPORT.AttributeName) as ITimeoutResource);
            
            _main.MelsecNetBitOnOff(OB_EQP_STATUS_REPORT, true);
            Thread.Sleep(1000);
            IB_EQP_STATUS_REPORT.Value = true.ToString();
            string tempMsg = "";
            bool error = false;
            if (CTimeout.WaitSync(timeout, 10))
            {

            }
            else
            {
                error = true;
                _main.MelsecNetBitOnOff(OB_EQP_STATUS_REPORT, false);
                tempMsg = string.Format("PGM DATA TIMEOUT No response [timeout T1={0} sec]", T1 / 1000);
                Log(string.Format("{0}\t{1}", _component.ControlName, tempMsg));
            }

            if (!error)
                return 0;

            #region 메시지 창 표시

            string receivedTime = DateTime.Now.ToString("yyyyMMdd HH:mm:ss");
            string msgId = "0";
            string message = string.Format("[{0}] {1}", this.Name, tempMsg);
            string panelNo = "1";

            subject = CUIManager.Inst.GetData("CIMMessage");
            subject.SetValue("List", new List<string>() { "MESSAGE_SET", msgId, receivedTime, message, panelNo });
            subject.Notify();

            #endregion
            return 0;
        }
    }
}
