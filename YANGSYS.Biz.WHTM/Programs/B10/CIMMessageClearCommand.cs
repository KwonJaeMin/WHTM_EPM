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

    public class CIMMessageClearCommand : AProgram
    {
        private CMain _main = null;
        private bool _enable = false;

        //BC
        private CScanControlProperties IB_CIM_MESSAGE_CLEAR_COMMAND = null;
        private CScanControlProperties IW_CIM_MESSAGE_ID = null;
        private CScanControlProperties IW_TOUCH_PANEL_NO = null;

        //PROBE CIM
 

        private const int CIM_MODE_CIM_OFF = 1;
        private const int CIM_MODE_CIM_ON = 2;

        private const int CIM_MODE_ACCEPT = 1;
        private const int CIM_MODE_ALREADY_IN_DESIRED_STATUS = 2;

        private string _controlName = "";
        private CProbeControl _component = null;
        public CIMMessageClearCommand()
        {
        }
        public override int Init()
        {
            _enable = true;

            IB_CIM_MESSAGE_CLEAR_COMMAND = _main.SCANCONTEROLS.GetProperty(_controlName, "IB_CIM_MESSAGE_CLEAR_COMMAND");
            IW_CIM_MESSAGE_ID = _main.SCANCONTEROLS.GetProperty(_controlName, "IW_CIM_MESSAGE_CLEAR_MESSAGE_ID");
            IW_TOUCH_PANEL_NO = _main.SCANCONTEROLS.GetProperty(_controlName, "IW_CIM_MESSAGE_CLEAR_TOUCH_PANEL_NO");

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
            get { return "CIM_MESSAGE_CLEAR_COMMAND"; }
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
        
        protected override int InnerExecute()
        {
            string tmpId = _main.MelsecNetWordRead(IW_CIM_MESSAGE_ID);
            string tmpPanelNo = _main.MelsecNetWordRead(IW_TOUCH_PANEL_NO);

            int mId = 0;
            int mPanelNo = 0;        

            int.TryParse(tmpId, out mId);
            int.TryParse(tmpPanelNo, out mPanelNo);

            List<string> values = new List<string>();

            values.Add("MESSAGE_CLEAR");
            values.Add(mId.ToString());
            values.Add(mPanelNo.ToString());
            CSubject subject = CUIManager.Inst.GetData("CIMMessage");
            subject.SetValue("List", values);
            subject.Notify();

            return 0;
        }
    }
}
