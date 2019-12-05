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
using MainLibrary.Property;
using SOFD.Global.Manager;


namespace YANGSYS.Biz.Programs
{

    public class GlassDataRequest : AProgram
    {
        private CMain _main = null;
        private bool _enable = false;

        //BC
        private CScanControlProperties IB_GLASS_DATA_REQUEST_CONFIRM = null;
        private CScanControlProperties IW_GLASS_DATA_SEND = null;
        private CScanControlProperties IW_GLASS_DATA_REQUEST_ACK = null;

        //PROBE CIM
        private CPLCControlProperties OB_GLASS_DATA_REQUEST= null;
        private CPLCControlProperties OW_GLS_DATA_REQ_OPTION = null;
        private CPLCControlProperties OW_GLS_DATA_REQ_GLASS_ID = null;
        private CPLCControlProperties OW_GLS_DATA_REQ_GLASS_CODE = null;

        private const int OPTION_GLSID = 1;
        private const int OPTION_GLSCODE = 2;

        private string _controlName = "";
        private CProbeControl _component = null;

        public GlassDataRequest()
        {
        }

        public override int Init()
        {
            _enable = true;

            IB_GLASS_DATA_REQUEST_CONFIRM = _main.SCANCONTEROLS.GetProperty(_controlName, "IB_GLASS_DATA_REQUEST_CONFIRM");
            IW_GLASS_DATA_SEND = _main.SCANCONTEROLS.GetProperty(_controlName, "IW_GLASS_DATA_SEND");
            IW_GLASS_DATA_REQUEST_ACK = _main.SCANCONTEROLS.GetProperty(_controlName, "IW_GLASS_DATA_REQUEST_ACK");

            OB_GLASS_DATA_REQUEST = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_GLASS_DATA_REQUEST");
            OW_GLS_DATA_REQ_OPTION = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_GLS_DATA_REQ_OPTION");
            OW_GLS_DATA_REQ_GLASS_ID = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_GLS_DATA_REQ_GLASS_ID");
            OW_GLS_DATA_REQ_GLASS_CODE = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_GLS_DATA_REQ_GLASS_CODE");

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
            get { return "GLASS_DATA_REQUEST"; }
        }

        public override string Version
        {
            get { return "ver 1.0"; }
        }

        public override string Description
        {
            get { return "장비에서 BC로 GLASS DATA를 요청"; }
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
            int requestOption = 0;
            string glassID = "";
            string glassCode = "";

            if (_values.ContainsKey("REQ_OPTION") == false || _values.ContainsKey("GLS_CODE") == false || _values.ContainsKey("GLS_ID") == false)
            {
                return -1;
            }
            int.TryParse(_values["REQ_OPTION"], out requestOption);
            glassCode = _values["GLS_CODE"];
            glassID = _values["GLS_ID"];

            List<int> requestID = new List<int>();
            List<int> requestCode = new List<int>();
            
            char[] temp = glassID.ToCharArray();
            string hex = "";
            for (int i = 0; i < temp.Length; i = i + 2)
            {
                if (temp.Length > i + 1)
                {
                    hex += SmartDevice.UTILS.PLCUtils.DecToHex(((int)temp[i + 1]).ToString()).Substring(2, 2);
                }
                if (temp.Length > i)
                {
                    hex += SmartDevice.UTILS.PLCUtils.DecToHex(((int)temp[i]).ToString()).Substring(2, 2);
                    requestID.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(hex)));
                }

                hex = "";
            }

            string glassCode1 = "";
            string glassCode2 = "";
            if (string.IsNullOrEmpty(glassCode) || glassCode == "0")
            {
                requestCode.Add(0);
                requestCode.Add(0);
            }
            else if (glassCode.Length <= 3)
            {
                requestCode.Add(0);
                requestCode.Add(int.Parse(glassCode));
            }
            else
            {
                glassCode1 = glassCode.Substring(0, glassCode.Length - 3);
                glassCode2 = glassCode.Substring(glassCode.Length - 3, 3);

                requestCode.Add(int.Parse(glassCode1));
                requestCode.Add(int.Parse(glassCode2));
            }

            _main.MelsecNetWordWrite(OW_GLS_DATA_REQ_OPTION, requestOption);
            _main.MelsecNetMultiWordWrite(OW_GLS_DATA_REQ_GLASS_ID, requestID);
            _main.MelsecNetMultiWordWrite(OW_GLS_DATA_REQ_GLASS_CODE, requestCode);

            CTimeout timeout = CTimeoutManager.GetTimeout(_component.ControlName, 2000);
            timeout.Begin(OB_GLASS_DATA_REQUEST, _main.CONTROLATTRIBUTES.GetProperty(IB_GLASS_DATA_REQUEST_CONFIRM.ScanControlName, IB_GLASS_DATA_REQUEST_CONFIRM.ScanAttribute) as ITimeoutResource);
            _main.MelsecNetBitOnOff(OB_GLASS_DATA_REQUEST, true);

            if (CTimeout.WaitSync(timeout, 10))
            {
                ushort[] receviedGlassData = _main.MelsecNetMultiWordRead(IW_GLASS_DATA_SEND);
                
                string requestAck =  _main.MelsecNetWordRead(IW_GLASS_DATA_REQUEST_ACK);

                CGlassDataProperties glassData = new CGlassDataProperties(receviedGlassData);

                CSubject subject = CUIManager.Inst.GetData("GlassInfoDisplay");
                subject.SetValue("Data", CGlassDataProperties.GetGuiData(glassData));
                subject.Notify();
            }
            else
            {
                //에러:응답이 없다..
            }

            _main.MelsecNetBitOnOff(OB_GLASS_DATA_REQUEST, false);

            return 0;


        }

    }
}
