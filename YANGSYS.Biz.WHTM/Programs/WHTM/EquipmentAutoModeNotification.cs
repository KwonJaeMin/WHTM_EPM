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

    public class EquipmentAutoModeNotification : AProgram
    {
        private CMain _main = null;
        private bool _enable = false;

        //BC

        //PROBE CIM
        private CPLCControlProperties OB_MACHINE_AUTO_MODE = null;//RV_B_EQPNotify_L3ToBC,2
        private CPLCControlProperties OW_AUTO_MODE = null;//RV_W_EqpAutoMode_L3ToBC

        private const int MODE_AUTO = 1;   //1: Auto
        private const int MODE_MANUAL = 2; //2: Manual

        private string _controlName = "";
        private CProbeControl _component = null;

        public EquipmentAutoModeNotification()
        {
        }

        public override int Init()
        {
            _enable = true;

            OB_MACHINE_AUTO_MODE = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_MACHINE_AUTO_MODE");
            OW_AUTO_MODE = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_AUTO_MODE");

            _component.ProgramsAdd(this);
            
            ProgramDataList = new List<CProgramData>();

            CProgramData data = new CProgramData(ProgramDataList.Count, "AUTO_MODE", typeof(int));
            data.Add(1, "Auto");
            data.Add(2, "Manual");
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
            get { return "EQUIPMENT_AUTO_MODE_NOTIFICATION"; }
        }

        public override string Version
        {
            get { return "ver 1.0"; }
        }

        public override string Description
        {
            get { return "장비 EQUIPMENT_AUTO_MODE를 변경 하는 프로그램"; }
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
        
        protected override int InnerExecute()
        {
            int mode = 0;
            if (_isManualMode)
                mode = (int)ProgramDataList[0].Value;
            else
                mode = _component.MachineAutoMode ? MODE_AUTO : MODE_MANUAL;

            OB_MACHINE_AUTO_MODE = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_MACHINE_AUTO_MODE");
            OW_AUTO_MODE = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_AUTO_MODE");

            _main.MelsecNetWordWrite(OW_AUTO_MODE, mode);
            _main.MelsecNetBitOnOff(OB_MACHINE_AUTO_MODE, true);

            Log(string.Format("{0}\t{1}", _component.ControlName, string.Format("PGM DATA SEND - AUTO MODE={0}", mode)));
            Log(string.Format("{0}\t{1}", _component.ControlName, "PGM DATA DISPLAY"));

            CSubject subject = CUIManager.Inst.GetData("ucCimStatus");
            subject.SetValue("AutoMode", _component.MachineAutoMode);
            subject.Notify();

            Thread.Sleep(1000);
            _main.MelsecNetBitOnOff(OB_MACHINE_AUTO_MODE, false);

            return 0;
        }
    }
}
