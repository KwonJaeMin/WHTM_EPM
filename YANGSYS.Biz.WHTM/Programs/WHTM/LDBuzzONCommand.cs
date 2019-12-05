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



namespace YANGSYS.Biz.Programs
{

    public class LDBuzzONCommand : AProgram
    {
        private CMain _main = null;
        private bool _enable = false;

        //BC        
        private CScanControlProperties IB_LD_BUZZ_ON = null;//SD_B_LDBuzzON_BCToL3
        private CScanControlProperties IW_BUZ_ALARM_ID = null;//SD_W_BuzAlarmID_BCToL3
        private CScanControlProperties IW_BUZ_ALARM_RESULT = null;//SD_W_BuzAlarmID_BCToL3

        //PROBE CIM 

        private CPLCControlProperties OB_LD_BUZZ_ON = null;//SD_B_LDBuzzON_BCToL3
        private CPLCControlProperties OW_BUZ_ALARM_RESULT = null;//SD_W_BuzAlarmID_BCToL3

        private const int RESULT_COMMAND_OK = 1;
        private const int RESULT_COMMAND_ERROR = 2;

        private string _controlName = "";
        private CProbeControl _component = null;
        public LDBuzzONCommand()
        {
        }

        public override int Init()
        {
            Log(string.Format("{0}\t{1}", _component.ControlName, "PGM INIT"));
            _enable = true;

            //BC
            IB_LD_BUZZ_ON = _main.SCANCONTEROLS.GetProperty(_controlName, "IB_LD_BUZZ_ON");
            IW_BUZ_ALARM_ID = _main.SCANCONTEROLS.GetProperty(_controlName, "IW_BUZ_ALARM_ID");
            IW_BUZ_ALARM_RESULT = _main.SCANCONTEROLS.GetProperty(_controlName, "IW_BUZ_ALARM_RESULT");

            //PROBE CIM
            OB_LD_BUZZ_ON = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LD_BUZZ_ON");
            OW_BUZ_ALARM_RESULT = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_BUZ_ALARM_RESULT");

            this.ProgramDataList.Add(new CProgramData(this.ProgramDataList.Count, "BUZALARMID", typeof(int)));

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
            get { return "LD_BUZZ_ON"; }
        }

        public override string Version
        {
            get { return "ver 1.0"; }
        }
        public string SiteName
        {
            get { return "WHTM"; }
        }

        public override string Description
        {
            get { return "BC에서 TEXT를 표시하라는 명령 처리 프로그램"; }
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
            string receivedTime = DateTime.Now.ToString("yyyyMMdd HH:mm:ss");
            string tmpMsg = "";
            string resultTemp = "";
            ushort[] textTemp = null;
            string alarmId = "0";
            if (IsManualExecute)
            {
                tmpMsg = this.ProgramDataList[0].Value.ToString();
            }
            else
            {
                //IOB_TERMINAL_TEXT 이걸 감지 해서 실행됨. BC T1=4sec 검사중.
                textTemp = _main.MelsecNetMultiWordRead(IW_BUZ_ALARM_ID);

                tmpMsg = ((uint)textTemp[1] << 8 | (uint)textTemp[0]).ToString();
                alarmId = tmpMsg;

                alarmId = "1";
            }
            
            int result = 0;
            int.TryParse(resultTemp, out result);

            Log(string.Format("{0}\t{1}", _component.ControlName, string.Format("PGM DATA RECV - {0} {1}", tmpMsg, result)));

            result = RESULT_COMMAND_OK;
            _main.MelsecNetWordWrite(OW_BUZ_ALARM_RESULT, result);
            _main.MelsecNetBitOnOff(OB_LD_BUZZ_ON, false);

            _main.SendData(new List<string>() { "CIM_MESSAGE_ON", "O" });

            Log(string.Format("{0}\t{1}", _component.ControlName, string.Format("PGM DATA SEND - {0}", result)));

            tmpMsg = string.Format("{0} BUZ ALARMID={1}", "PLEASE CONFIRM...", tmpMsg);

            Log(string.Format("{0}\t{1}", _component.ControlName, "PGM DATA DISPLAY"));

            List<string> dataList = new List<string>();
            dataList.Add("BUZZER");
            dataList.Add(alarmId);
            _main.SendData(dataList);

            #region 메시지 창 표시
            
            List<string> values = new List<string>();
            values.Add("MESSAGE_SET");
            values.Add("0");
            values.Add(receivedTime);
            values.Add(tmpMsg);
            values.Add("0");
            CSubject subject = CUIManager.Inst.GetData("CIMMessage");
            subject.SetValue("List", values);
            subject.Notify();
            
            #endregion

            return 0;
        }

        public override int ExecuteManual(List<AProgram.CProgramData> dataList)
        {
            return base.ExecuteManual(dataList);
        }
    }
}
