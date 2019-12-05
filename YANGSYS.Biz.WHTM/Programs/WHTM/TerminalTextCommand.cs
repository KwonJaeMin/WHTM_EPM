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

    public class TerminalTextCommand : AProgram
    {
        private CMain _main = null;
        private bool _enable = false;

        //BC        
        private CScanControlProperties IB_TERMINAL_TEXT = null;//SD_B_TerminalText_BCToL3
        private CScanControlProperties IW_TERMINAL_TEXT = null;//SD_W_TerminalText_BCToL3
        private CScanControlProperties IW_TERMINAL_RESULT = null;//SD_W_TerminalText_BCToL3

        //PROBE CIM 

        private CPLCControlProperties OB_TERMINAL_TEXT = null;//SD_B_TerminalText_BCToL3
        private CPLCControlProperties OW_TERMINAL_RESULT = null;//SD_W_TerminalText_BCToL3

        private const int RESULT_COMMAND_OK = 1;
        private const int RESULT_COMMAND_ERROR = 2;

        private string _controlName = "";
        private CProbeControl _component = null;
        public TerminalTextCommand()
        {
        }

        public override int Init()
        {
            Log(string.Format("{0}\t{1}", _component.ControlName, "PGM INIT"));
            _enable = true;

            //BC
            IB_TERMINAL_TEXT = _main.SCANCONTEROLS.GetProperty(_controlName, "IB_TERMINAL_TEXT");
            IW_TERMINAL_TEXT = _main.SCANCONTEROLS.GetProperty(_controlName, "IW_TERMINAL_TEXT");
            IW_TERMINAL_RESULT = _main.SCANCONTEROLS.GetProperty(_controlName, "IW_TERMINAL_RESULT");

            //PROBE CIM
            OB_TERMINAL_TEXT = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_TERMINAL_TEXT");
            OW_TERMINAL_RESULT = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_TERMINAL_RESULT");

            this.ProgramDataList.Add(new CProgramData(this.ProgramDataList.Count, "TEXT", typeof(string)));

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
            get { return "TERMINAL_TEXT"; }
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
            if (IsManualExecute)
            {
                tmpMsg = this.ProgramDataList[0].Value.ToString();
            }
            else
            {
                //IOB_TERMINAL_TEXT 이걸 감지 해서 실행됨. BC T1=4sec 검사중.
                textTemp = _main.MelsecNetMultiWordRead(IW_TERMINAL_TEXT);

                foreach (ushort item in textTemp)
                {
                    tmpMsg += SmartDevice.UTILS.PLCUtils.HexToAscii( SmartDevice.UTILS.PLCUtils.DecToHex(item.ToString()));
                    tmpMsg = tmpMsg.Replace('\0', ' ');
                    tmpMsg = tmpMsg.Trim();
                }
            }
            
            int result = 0;
            int.TryParse(resultTemp, out result);

            Log(string.Format("{0}\t{1}", _component.ControlName, string.Format("PGM DATA RECV - {0} {1}", tmpMsg, result)));

            result = RESULT_COMMAND_OK;
            _main.MelsecNetWordWrite(OW_TERMINAL_RESULT, result);
            _main.MelsecNetBitOnOff(OB_TERMINAL_TEXT, false);

            Log(string.Format("{0}\t{1}", _component.ControlName, string.Format("PGM DATA SEND - {0}", result)));
            Log(string.Format("{0}\t{1}", _component.ControlName, "PGM DATA DISPLAY"));

            List<string> values = new List<string>();
            values.Add("MESSAGE_SET");
            values.Add("0");
            values.Add(receivedTime);
            values.Add(tmpMsg);
            values.Add("0");
            CSubject subject = CUIManager.Inst.GetData("CIMMessage");
            subject.SetValue("List", values);
            subject.Notify();

            return 0;
        }
    }
}
