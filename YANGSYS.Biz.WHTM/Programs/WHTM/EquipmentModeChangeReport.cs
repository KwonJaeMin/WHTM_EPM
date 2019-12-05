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

    public class EquipmentModeChangeReport : AProgram
    {
        private CMain _main = null;
        private bool _enable = false;

        //BC
        private CScanControlProperties IB_EQP_MODE_CHANGE_REPORT = null;//RV_B_EquipmentModeChangeReport_L3ToBC
        //PROBE CIM
        private CPLCControlProperties OB_EQP_MODE_CHANGE_REPORT = null;//RV_B_EquipmentModeChangeReport_L3ToBC
        private CPLCControlProperties OW_EQP_MODE = null;//RV_W_EqpMode_L3ToBC

        private const int MASS_PRODUCTION_MODE1 = 1;         // 1: Mass Production Mode 1
        private const int MASS_PRODUCTION_MODE2 = 2;          // 2: Mass Production Mode 2
        private const int MASS_PRODUCTION_MODE3 = 3;          // 3: Mass Production Mode 3
        private const int MASS_PRODUCTION_MODE4 = 4;          // 4: Mass Production Mode 4
        private const int DUMMY_MODE = 10;                  //10: Dummy Mode
        private const int SORTING_MODE = 11;                //11: Sorting Mode
        private const int SKIP_MODE = 12;                   //12: Skip Mode
        private const int COLD_RUN_MODE_OR_CYCLE_MODE = 13; //13: Cold Run Mode(Cycle Mode)
        private const int FORCE_CLEAN_OUT_MODE = 14;         //14: Force Clean Out Mode

        private string _controlName = "";
        private CProbeControl _component = null;

        public EquipmentModeChangeReport()
        {
        }

        public override int Init()
        {
            _enable = true;

            //BC
            IB_EQP_MODE_CHANGE_REPORT = _main.SCANCONTEROLS.GetProperty(_controlName, "IB_EQP_MODE_CHANGE_REPORT");

            //PROBE CIM
            OB_EQP_MODE_CHANGE_REPORT = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_EQP_MODE_CHANGE_REPORT");
            OW_EQP_MODE = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_EQP_MODE");

            _component.ProgramsAdd(this);
            
            ProgramDataList = new List<CProgramData>();

            CProgramData data = new CProgramData(ProgramDataList.Count, "EQP_MODE", typeof(int));
            data.Add(1, "Mass Production Mode 1");
            //data.Add(2, "Mass Production Mode 2");
            //data.Add(3, "Mass Production Mode 3");
            //data.Add(4, "Mass Production Mode 4");
            //data.Add(10, "Dummy Mode");
            //data.Add(11, "Sorting Mode");
            //data.Add(12, "Skip Mode");
            data.Add(13, "Cold Run Mode");
            data.Add(14, "Force Clean Out Mode");

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
            get { return "MACHINE_MODE_CHANGE_REPORT"; }
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
            int mode = 0;
            if (_isManualMode)
                mode = (int)ProgramDataList[0].Value;
            else
                mode = _component.EquipmentMode;

            _main.MelsecNetWordWrite(OW_EQP_MODE, mode);
            
            //_main.MelsecNetBitOnOff(OB_EQP_MODE_CHANGE_REPORT, true);
            Log(string.Format("{0}\t{1}", _component.ControlName, string.Format("PGM DATA SEND - EQP MODE={0}", mode)));

            Log(string.Format("{0}\t{1}", _component.ControlName, "PGM DATA DISPLAY"));

            CSubject subject = CUIManager.Inst.GetData("ucCimStatus");
            subject.SetValue("EqpMode", _component.EquipmentMode);
            subject.Notify();

            //Thread.Sleep(1000);
            //_main.MelsecNetBitOnOff(OB_EQP_MODE_CHANGE_REPORT, false);


            CTimeout timeout = CTimeoutManager.GetTimeout(_controlName, T1);
            timeout.TargetOffValueCheck = true;
            timeout.Begin(OB_EQP_MODE_CHANGE_REPORT, _main.CONTROLATTRIBUTES.GetProperty(IB_EQP_MODE_CHANGE_REPORT.ControlName, IB_EQP_MODE_CHANGE_REPORT.AttributeName) as ITimeoutResource);

            _main.MelsecNetBitOnOff(OB_EQP_MODE_CHANGE_REPORT, true);
            Thread.Sleep(1000);
            IB_EQP_MODE_CHANGE_REPORT.Value = true.ToString();

            string tempMsg = "";
            bool error = false;
            if (CTimeout.WaitSync(timeout, 10))
            {

            }
            else
            {
                error = true;
                _main.MelsecNetBitOnOff(OB_EQP_MODE_CHANGE_REPORT, false);
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
