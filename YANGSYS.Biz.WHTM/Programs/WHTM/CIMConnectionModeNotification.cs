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

    public class CIMConnectionModeNotification : AProgram
    {
        private CMain _main = null;
        private bool _enable = false;

        //BC
        private CScanControlProperties IB_CIM_MODE = null;//RV_B_EQPNotify_L3ToBC
        //PROBE CIM
        private CPLCControlProperties OB_CIM_MODE = null;//RV_B_EQPNotify_L3ToBC
        private CPLCControlProperties OW_CIM_CONNECTION_MODE = null;//RV_W_CIMConnectionMode_L3ToBC

        private const int MODE_DISCONNECTED = 1; //1: Disconnected
        private const int MODE_CONNECTED = 2;    //2: Connected

        private string _controlName = "";
        private CProbeControl _component = null;

        public CIMConnectionModeNotification()
        {
        }

        public override int Init()
        {
            _enable = true;

            //BC
            IB_CIM_MODE = _main.SCANCONTEROLS.GetProperty(_controlName, "IB_CIM_MODE");
            OB_CIM_MODE = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_CIM_MODE");
            OW_CIM_CONNECTION_MODE = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_CIM_CONNECTION_MODE");

            _component.ProgramsAdd(this);
            
            ProgramDataList = new List<CProgramData>();

            CProgramData data = new CProgramData(ProgramDataList.Count, "CIM_CONNECTION_MODE", typeof(int));
            data.Add(1, "Disconnected");
            data.Add(2, "Connected");
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
            get { return "CIM_CONNECTION_MODE_NOTIFICATION"; }
        }

        public override string Version
        {
            get { return "ver 1.0"; }
        }

        public override string Description
        {
            get { return "CIM_CONNECTION MODE를 보고 하는 프로그램"; }
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
                mode = _component.CIMMode == 1 ? MODE_CONNECTED : MODE_DISCONNECTED;

            _main.MelsecNetWordWrite(OW_CIM_CONNECTION_MODE, mode);
            _main.MelsecNetBitOnOff(OB_CIM_MODE, true);
            Log(string.Format("{0}\t{1}", _component.ControlName, string.Format("PGM DATA SEND - CIM MODE={0}", mode)));

            Log(string.Format("{0}\t{1}", _component.ControlName, "PGM DATA DISPLAY"));

            //CSubject subject = CUIManager.Inst.GetData("ucCimStatus");
            //subject.SetValue("CIMMode", _component.CIMMode);
            //subject.Notify();

            //Thread.Sleep(1000);
            //_main.MelsecNetBitOnOff(OB_CIM_MODE, false);

            List<string> dataList = new List<string>();
            dataList.Add("CIM_MODE");
            dataList.Add(_component.CIMMode == 2 ? "1" : "2");

            _main.SendData(dataList);

            //CTimeout timeout = CTimeoutManager.GetTimeout(_controlName, T1);
            //timeout.TargetOffValueCheck = true;
            //timeout.Begin(OB_CIM_MODE, _main.CONTROLATTRIBUTES.GetProperty(IB_CIM_MODE.ControlName, IB_CIM_MODE.AttributeName) as ITimeoutResource);
            _main.MelsecNetBitOnOff(OB_CIM_MODE, true);
            Thread.Sleep(1000);
            IB_CIM_MODE.Value = true.ToString();

            //string tempMsg = "";

            //bool error = false;
            //if (CTimeout.WaitSync(timeout, 10))
            //{

            //}
            //else
            //{
            //    error = true;
            //    _main.MelsecNetBitOnOff(OB_CIM_MODE, false);
            //    tempMsg = string.Format("PGM DATA TIMEOUT No response [timeout T1={0} sec]", T1 / 1000);
            //    Log(string.Format("{0}\t{1}", _component.ControlName, tempMsg));
            //}

            //if (!error)
            //    return 0;

            //#region 메시지 창 표시
            //CSubject subject = null;

            //string receivedTime = DateTime.Now.ToString("yyyyMMdd HH:mm:ss");
            //string msgId = "0";
            //string message = string.Format("[{0}] {1}", this.Name, tempMsg);
            //string panelNo = "1";

            //subject = CUIManager.Inst.GetData("CIMMessage");
            //subject.SetValue("List", new List<string>() { "MESSAGE_SET", msgId, receivedTime, message, panelNo });
            //subject.Notify();

            //#endregion

            return 0;
        }
    }
}
