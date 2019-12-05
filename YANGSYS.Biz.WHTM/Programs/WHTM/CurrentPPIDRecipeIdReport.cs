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

    public class CurrentPPIDRecipeIdReport : AProgram
    {
        private CMain _main = null;
        private bool _enable = false;

        //BC
        private CScanControlProperties IB_CURRENT_PPID_RECIPEID_REPORT = null;//RV_B_CurrentPPIDRecipeIdReport_L3ToBC

        //PROBE CIM
        private CPLCControlProperties OB_CURRENT_PPID_RECIPEID_REPORT = null;//RV_B_CurrentPPIDRecipeIdReport_L3ToBC
        private CPLCControlProperties OW_CURRENT_PPID_RECIPEID_REPORT_PPID = null;//RV_W_CurrentPPIDRecipeIDReport_L3ToBC.PPID
        private CPLCControlProperties OW_CURRENT_PPID_RECIPEID_REPORT_RECIPEID = null;//RV_W_CurrentPPIDRecipeIDReport_L3ToBC.RecipeID      

        private CScanControlProperties VI_CURRENT_RECIPE_CHANGE = null;

        private string _controlName = "";
        private CProbeControl _component = null;

        public CurrentPPIDRecipeIdReport()
        {
        }

        public override int Init()
        {
            _enable = true;

            //BC
            IB_CURRENT_PPID_RECIPEID_REPORT = _main.SCANCONTEROLS.GetProperty(_controlName, "IB_CURRENT_PPID_RECIPEID_REPORT");
            //PROBE CIM
            OB_CURRENT_PPID_RECIPEID_REPORT = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_CURRENT_PPID_RECIPEID_REPORT");
            OW_CURRENT_PPID_RECIPEID_REPORT_PPID = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_CURRENT_PPID_RECIPEID_REPORT_PPID");
            OW_CURRENT_PPID_RECIPEID_REPORT_RECIPEID = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_CURRENT_PPID_RECIPEID_REPORT_RECIPEID");

            VI_CURRENT_RECIPE_CHANGE = _main._YANSYS_SCANCONTEROLS.GetProperty(_controlName, "VI_CURRENT_RECIPE_CHANGE");

            this.ProgramDataList.Add(new CProgramData(this.ProgramDataList.Count, "PPID", typeof(string)));
            this.ProgramDataList.Add(new CProgramData(this.ProgramDataList.Count, "RecipeID", typeof(string))); 
            
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
            get { return "CURRENT_PPID_RECIPE_REPORT"; }
        }

        public override string Version
        {
            get { return "ver 1.0"; }
        }

        public override string Description
        {
            get { return "장비 CURRENT PPID/RECIPE 변경 REPORT 처리 프로그램"; }
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
            string ppid = ""; //10
            string recipeId = ""; //10

            if (IsManualExecute)
            {
                ppid = this.ProgramDataList[0].Value.ToString();
                recipeId = this.ProgramDataList[1].Value.ToString();

                ppid = "AAA";
                recipeId = "BBB";
            }
            else
            {
                string value = VI_CURRENT_RECIPE_CHANGE.Value;
                string[] temp = value.Split('|');

                if (temp != null && temp.Length == 3)
                {
                    //일단 동일하게 처리
                    ppid = _main.getPPID(temp[2]);
                    recipeId = temp[2];
                }                
            }

            this.StatusChange(enumProgramStatus.PROCESSING);

            _main.MelsecNetMultiWordWriteByString(OW_CURRENT_PPID_RECIPEID_REPORT_PPID, ppid, 10, ' ');
            _main.MelsecNetMultiWordWriteByString(OW_CURRENT_PPID_RECIPEID_REPORT_RECIPEID, recipeId, 10, ' ');

            Log(string.Format("{0}\t{1}", _component.ControlName, string.Format("PGM DATA SEND - PPID={0} RECIPEID={1}", ppid, recipeId)));

            CTimeout timeout = CTimeoutManager.GetTimeout(_controlName, T1);
            timeout.TargetOffValueCheck = true;
            timeout.Begin(OB_CURRENT_PPID_RECIPEID_REPORT, _main.CONTROLATTRIBUTES.GetProperty(IB_CURRENT_PPID_RECIPEID_REPORT.ControlName, IB_CURRENT_PPID_RECIPEID_REPORT.AttributeName) as ITimeoutResource);
            _main.MelsecNetBitOnOff(OB_CURRENT_PPID_RECIPEID_REPORT, true);
            Thread.Sleep(1000);
            IB_CURRENT_PPID_RECIPEID_REPORT.Value = true.ToString();

            string tempMsg = "";
            bool error = false;
            if (CTimeout.WaitSync(timeout, 10))
            {

                _main.MelsecNetBitOnOff(OB_CURRENT_PPID_RECIPEID_REPORT, false);
            }
            else
            {
                error = true;
                _main.MelsecNetBitOnOff(OB_CURRENT_PPID_RECIPEID_REPORT, false);
                tempMsg = string.Format("PGM DATA TIMEOUT No response [timeout T1={0} sec]", T1 / 1000);
                Log(string.Format("{0}\t{1}", _component.ControlName, tempMsg));
            }

            Log(string.Format("{0}\t{1}", _component.ControlName, "PGM DATA DISPLAY"));

            CSubject subject = CUIManager.Inst.GetData("ucEQP");
            subject.SetValue("RECIPE", _component.CurrentRecipeNo);
            subject.Notify();
            
            if(!error)
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
