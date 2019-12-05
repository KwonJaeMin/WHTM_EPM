using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOFD.Component;
using SOFD.Properties;
using MainLibrary;
using System.Threading;

using SOFD.InterfaceTimeout;
using YANGSYS.ControlLib;
using SOFD.Component.Interface;
using SOFD.Global.Manager;


namespace YANGSYS.Biz.Programs
{
    public class MachineHeartbeatSignal : AProgram
    {
        private CMain _main = null;
        private bool _enable = false;

        private CPLCControlProperties OB_MACHINE_HEARTBEAT_SIGNAL = null;
        private CPLCControlProperties VO_ALIVE = null;
        private Thread _thread = null;
        private string _controlName = "";
        private CProbeControl _component = null;
        public MachineHeartbeatSignal()
        {

        }

        public override int Init()
        {
            _enable = true;

            OB_MACHINE_HEARTBEAT_SIGNAL = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_MACHINE_HEARTBEAT_SIGNAL");
            VO_ALIVE = _main.PLCCONTEROLS.GetProperty(_controlName, "VO_ALIVE");

            _component.ProgramsAdd(this);
            _thread = new Thread(new ThreadStart(Cycle));
            _thread.IsBackground = true;
            _thread.Name = this.Name;
            _thread.Start();

            _component.ProgramsAdd(this);
            return 0;
        }

        public override int AddArgs(object[] args, bool beforeClear)
        {
            if (args == null || args.Length < 2)
                return -1;

            if ((args[0] is CMain && args[1] is CProbeControl) == false)
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
            get { return "MACHINE_HEARTBEAT_SIGNAL"; }
        }

        public override string Version
        {
            get { return "ver 1.0"; }
        }

        public override string Description
        {
            get { return "주기적으로 Heartbet 신호를 on/off"; }
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
            get { return true; }
        }

        public override string SIteName
        {
            get { return "B10"; }
        }

        public override bool IsAsyncCall
        {
            get { return false; }
        }

        public int _interval = 1000;
        public int _heartBeat = 0;

        public void Cycle()
        {
            bool blink = false;
            while (true)
            {
                blink = !blink;
                _main.MelsecNetBitOnOff(OB_MACHINE_HEARTBEAT_SIGNAL, blink);
                if (_component.Communication)
                {
                    _main.SendData(new List<string> { "ALIVE" });
                    
                    CSubject subject = CUIManager.Inst.GetData("ucCimStatus");
                    subject.SetValue("EqpLink", blink);
                    subject.Notify();
                }

                Thread.Sleep(_interval);
            }
        }

        protected override int InnerExecute()
        {
            throw new NotImplementedException();
        }
    }
}
