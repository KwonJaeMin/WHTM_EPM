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

using System.Threading;
using SOFD.Global.Manager;

namespace YANGSYS.Biz.Programs
{

    public class AlarmResetEvent : AProgram
    {
        private CMain _main = null;
        private bool _enable = false;

        //BC

        //PROBE CIM
        private CPLCControlProperties OB_SERIOUS_ALARM_OCCURRED = null;
        private CPLCControlProperties OB_SERIOUS_ALARM_CLEARED = null;
        private CPLCControlProperties OW_SERIOUS_ALARM_CODE = null;

        private CPLCControlProperties OB_LIGHT_ALARM_OCCURRED = null;
        private CPLCControlProperties OB_LIGHT_ALARM_CLEARED = null;
        private CPLCControlProperties OW_LIGHT_ALAM_CODE = null;
        private CScanControlProperties VI_ALARM_RESET = null;
        private string _controlName = "";
        private CProbeControl _component = null;
        public AlarmResetEvent()
        {
        }
        public override int Init()
        {
            _enable = true;




            OB_SERIOUS_ALARM_OCCURRED = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_SERIOUS_ALARM_OCCURRED");
            OB_SERIOUS_ALARM_CLEARED = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_SERIOUS_ALARM_CLEARED");
            OW_SERIOUS_ALARM_CODE = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_SERIOUS_ALARM_CODE");


            OB_LIGHT_ALARM_OCCURRED = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LIGHT_ALARM_OCCURRED");
            OB_LIGHT_ALARM_CLEARED = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LIGHT_ALARM_CLEARED");
            OW_LIGHT_ALAM_CODE = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_LIGHT_ALAM_CODE");

            VI_ALARM_RESET = _main._YANSYS_SCANCONTEROLS.GetProperty(_component.ControlName, "VI_ALARM_SET");
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
            get { return "ALARM_RESET_EVENT"; }
        }

        public override string Version
        {
            get { return "ver 1.0"; }
        }

        public override string Description
        {
            get { return "CIM 또는 장비에서 발생 하는 H/L ALARM을 처리한다."; }
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

            //InnerExecuteHandler del = new InnerExecuteHandler(InnerExecute);
            //del.BeginInvoke(null, null);
            Thread.Sleep(T2);//연속 방지가 될려나..
            InnerExecute();
            return 0;
        }
        public override int Execute(Dictionary<string, string> values)
        {
            throw new NotImplementedException();
        }
        public const int T1 = 1000;
        public const int T2 = 500; //연속 발생시
        
        private int InnerExecute()
        {
            int alarmCode = 0;
            string alarmText = "";
            string value = VI_ALARM_RESET.Value;
            string[] temp = value.Split('|');
            if (temp.Length < 2)
                return -1;

            int.TryParse(temp[1], out alarmCode);

            bool isLightAlarm = alarmCode < 1000;//양전자와 협의 해서 구분해야함. 일단 0~999 는 Light Alarm

            if (isLightAlarm)
            {
                this.LightAlarm(alarmCode, alarmText);
            }
            else
            {
                this.SeriousAlarm(alarmCode, alarmText);
            }

            return 0;
        }

        private void LightAlarm(int alarmCode, string alarmText)
        {
                //List<string> alarmData = new List<string>();
                //alarmData.Add(DateTime.Now.ToString("yyyyMMdd HH:mm:ss.ff")); //code
                //alarmData.Add(alarmCode.ToString()); //code
                //alarmData.Add("Light");
                //alarmData.Add("EMP01");
                //alarmData.Add(alarmText);
                //alarmData.Add("Y");
                //alarmData.Add("RESET");

                //CSubject subject = CUIManager.Inst.GetData("CurrentAlarm");
                //subject.SetValue("Alarm", alarmData);
                //subject.Notify();

                _main.MelsecNetWordWrite(OW_LIGHT_ALAM_CODE, alarmCode); //All Clear 시
                _main.MelsecNetBitOnOff(OB_LIGHT_ALARM_CLEARED, true);
                Thread.Sleep(T1);
                _main.MelsecNetBitOnOff(OB_LIGHT_ALARM_CLEARED, false);
        }

        private void SeriousAlarm(int alarmCode, string alarmText)
        {
                //List<string> alarmData = new List<string>();
                //alarmData.Add(DateTime.Now.ToString("yyyyMMdd HH:mm:ss.ff")); //code
                //alarmData.Add(alarmCode.ToString()); //code
                //alarmData.Add("Serious");
                //alarmData.Add("EMP01");
                //alarmData.Add(alarmText);
                //alarmData.Add("N");
                //alarmData.Add("RESET");

                //CSubject subject = CUIManager.Inst.GetData("CurrentAlarm");
                //subject.SetValue("Alarm", alarmData);
                //subject.Notify();

                _main.MelsecNetWordWrite(OW_SERIOUS_ALARM_CODE, alarmCode); //All clear 시
                _main.MelsecNetBitOnOff(OB_SERIOUS_ALARM_CLEARED, true);
                Thread.Sleep(T1);
                _main.MelsecNetBitOnOff(OB_SERIOUS_ALARM_CLEARED, false);
        }
    }
}
