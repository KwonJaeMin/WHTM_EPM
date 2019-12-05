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
using YANGSYS.Biz.LogFormat;

namespace YANGSYS.Biz.Programs
{

    public class CIMMessageConfirmReport : AProgram
    {
        private CMain _main = null;
        private bool _enable = false;

        //BC
        private CScanControlProperties IB_CIM_MESSAGE_CONFIRM_REPORT_REPLY = null;

        //PROBE CIM
        private CPLCControlProperties OB_MACHINE_CIM_MESSAGE_CONFIRM = null;
        private CPLCControlProperties OW_MACHINE_CIM_MESSAGE_ID = null;
        private CPLCControlProperties OW_MACHINE_TOUCH_PANLE_NO = null; 

        private const int CIM_MODE_CIM_OFF = 1;
        private const int CIM_MODE_CIM_ON = 2;

        private const int CIM_MODE_ACCEPT = 1;
        private const int CIM_MODE_ALREADY_IN_DESIRED_STATUS = 2;

        private string _controlName = "";
        private CProbeControl _component = null;
        public CIMMessageConfirmReport()
        {
        }
        public override int Init()
        {
            _enable = true;

            IB_CIM_MESSAGE_CONFIRM_REPORT_REPLY = _main.SCANCONTEROLS.GetProperty(_controlName, "IB_CIM_MESSAGE_CONFIRM_REPORT_REPLY");

            OB_MACHINE_CIM_MESSAGE_CONFIRM = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_MACHINE_CIM_MESSAGE_CONFIRM");
            OW_MACHINE_CIM_MESSAGE_ID = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_MACHINE_CIM_MESSAGE_ID");
            OW_MACHINE_TOUCH_PANLE_NO = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_MACHINE_TOUCH_PANLE_NO");

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
            get { return "CIM_MESSAGE_CONFIRM_REPORT"; }
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
        private Dictionary<string, string> _values = new Dictionary<string, string>();
        public override int Execute(Dictionary<string, string> values)
        {
            _values = values;
            return Execute();
        }

        private int InnerExecute()
        {
            string tmpId = "";
            string tmpPanelNo = "";

            if (_values.Count == 0)
            {
                CLogManager.Instance.Log(new CActionLogFormat(Catagory.Debug, _component.ControlName, "Argument is not exists"));
                return -1;
            }
            if (_values.ContainsKey("MESSAGE_ID"))
                tmpId = _values["MESSAGE_ID"];
            if (_values.ContainsKey("TOUCH_PANLE_NO"))
                tmpPanelNo = _values["TOUCH_PANLE_NO"];

            if (string.IsNullOrEmpty(tmpId) || string.IsNullOrEmpty(tmpPanelNo))
            {
                CLogManager.Instance.Log(new CActionLogFormat(Catagory.Debug, _component.ControlName, "Argument is not exists"));
                return -1;
            }

            int mId = 0;
            int mPanelNo = 0;
   
            int.TryParse(tmpId, out mId);
            int.TryParse(tmpPanelNo, out mPanelNo);

            _main.MelsecNetWordWrite(OW_MACHINE_CIM_MESSAGE_ID, mId);
            _main.MelsecNetWordWrite(OW_MACHINE_TOUCH_PANLE_NO, mPanelNo);

            _main.MelsecNetBitOnOff(OB_MACHINE_CIM_MESSAGE_CONFIRM, true);
            Thread.Sleep(1000);
            _main.MelsecNetBitOnOff(OB_MACHINE_CIM_MESSAGE_CONFIRM, false);

            return 0;
        }
    }
}
