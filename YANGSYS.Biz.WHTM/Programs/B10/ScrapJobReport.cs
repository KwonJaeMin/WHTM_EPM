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

    public class ScrapJobReport : AProgram
    {
        private CMain _main = null;
        private bool _enable = false;

        //BC
        private CScanControlProperties IB_SCRAP_JOB_REPORT_REPLY = null;

        //PROBE CIM
        private CPLCControlProperties OB_SCRAP_JOB_REPORT = null;
        private CPLCControlProperties OW_SCRAP_DATA_GLASS_CODE = null;
        private CPLCControlProperties OW_SCRAP_DATA_SCRAP_CODE = null;
        private CPLCControlProperties OW_SCRAP_DATA_UNIT_ID = null;
        private CPLCControlProperties OW_SCRAP_DATA_OPERATORID = null;

        public const int GLASS_BREAKAGE = 9100;
        public const int BREAKAGE_DUE_TO_DATA_ERROR = 9200;
        public const int BREAKAGE_BY_AN_OPERATOR = 9300;
        public const int BREAKAGE_BY_AN_ENGINEER = 9400;
        public const int BREAKAGE_BY_OTHER_CAUSES = 9900;

        private string _controlName = "";
        private CProbeControl _component = null;
        public ScrapJobReport()
        {
        }
        public override int Init()
        {
            _enable = true;


            IB_SCRAP_JOB_REPORT_REPLY = _main.SCANCONTEROLS.GetProperty(_controlName, "IB_SCRAP_JOB_REPORT_REPLY");

            OB_SCRAP_JOB_REPORT = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_SCRAP_JOB_REPORT");
            OW_SCRAP_DATA_GLASS_CODE = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_SCRAP_DATA_GLASS_CODE");
            OW_SCRAP_DATA_SCRAP_CODE = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_SCRAP_DATA_SCRAP_CODE");
            OW_SCRAP_DATA_UNIT_ID = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_SCRAP_DATA_UNIT_ID");
            OW_SCRAP_DATA_OPERATORID = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_SCRAP_DATA_OPERATORID");

            
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
            get { return "SCRAP_JOB_REPORT"; }
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
        private bool isCommand = false;
        public override int ExecuteManual(Dictionary<string, string> values)
        {
            _values = values;
            isCommand = true;
            return 0;
        }

        protected override int InnerExecute()
        {
            List<int> glassCode = new List<int>();
            //glassCode.Add(101);//glass1
            //glassCode.Add(21);//glass2
            List<int> scrapCode = new List<int>();
           // scrapCode.Add(8900);//glass1 scrapcode
           // scrapCode.Add(0);//glass2 scrapcode
            
            //string operIDTempe = "";
            List<int> operID = new List<int>();
           // operID.Add(1);
           // operID.Add(2);

            int unitID = 0;
            if (isCommand)
            {
                isCommand = false;
                string temp1 = _values["GLASSCODE1XXYYYY"];
                string temp2 = _values["GLASSCODE1ZZZ"];
                string temp3 = _values["SCRAPCODE1"];
                string temp4 = _values["SCRAPCODE2"];

                string temp5 = _values["UNITID"];
                string temp6 = _values["OPERID"];
                glassCode.Add(int.Parse(temp1));
                glassCode.Add(int.Parse(temp2)); 
                scrapCode.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.StringToReverseHex(temp3))));
                scrapCode.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.StringToReverseHex(temp4))));
                if(string.IsNullOrEmpty(temp5))
                    temp5 = "0";

                unitID = int.Parse(temp5);

                char[] tempOperID = temp6.ToCharArray();
                string word = "";
                foreach (char item in tempOperID)
                {
                    word = item + word;
                    if (word.Length > 1)
                    {
                        operID.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.StringToHex(word))));
                        word = "";
                    }
                }

            }
            else
            {
                glassCode.Add(0);//glass1
                glassCode.Add(0);//glass2

                scrapCode.Add(0);//glass1 scrapcode
                scrapCode.Add(0);//glass2 scrapcode
            }


            
            
            _main.MelsecNetMultiWordWrite(OW_SCRAP_DATA_GLASS_CODE, glassCode);
            _main.MelsecNetMultiWordWrite(OW_SCRAP_DATA_SCRAP_CODE, scrapCode);
            _main.MelsecNetWordWrite(OW_SCRAP_DATA_UNIT_ID, unitID);
            _main.MelsecNetMultiWordWrite(OW_SCRAP_DATA_OPERATORID, operID);

            CTimeout timeout = CTimeoutManager.GetTimeout(_component.ControlName, 2000);
			timeout.TargetOffValueCheck = true; //이건 확인바람.
            timeout.Begin(OB_SCRAP_JOB_REPORT, _main.CONTROLATTRIBUTES.GetProperty(IB_SCRAP_JOB_REPORT_REPLY.ScanControlName, IB_SCRAP_JOB_REPORT_REPLY.ScanAttribute) as ITimeoutResource);

            _main.MelsecNetBitOnOff(OB_SCRAP_JOB_REPORT, true);

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

            _main.MelsecNetBitOnOff(OB_SCRAP_JOB_REPORT, false);

            return 0;
        }
    }
}
