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

    public class PPIDRecipeMapReport : AProgram
    {
        private CMain _main = null;
        private bool _enable = false;

        //BC
        private CScanControlProperties IB_PPID_RECIPE_MAP_REPORT = null;//RV_B_PPIDRecipeIdMapReport_L3ToBC
        //PROBE CIM
        private CPLCControlProperties OB_PPID_RECIPE_MAP_REPORT = null;//RV_B_PPIDRecipeIdMapReport_L3ToBC
        private CPLCControlProperties OW_PPID_RECIPE_MAP_REPORT_PPID = null;//RV_W_PPIDRecipeMapReport_L3ToBC,0
        private CPLCControlProperties OW_PPID_RECIPE_MAP_REPORT_RECIPE_ID = null;//RV_W_PPIDRecipeMapReport_L3ToBC,1
        private CPLCControlProperties OW_PPID_RECIPE_MAP_REPORT_PPCINFO = null;//RV_W_PPIDRecipeMapReport_L3ToBC,2


        private const int PPCINFO_CREATED = 1;  //1: Created (a new mapping is created and registered)
        private const int PPCINFO_MODIFIED = 2; //2: Modified (PPID are modified)
        private const int PPCINFO_DELETED = 3;  //3: Deleted (any mapping is deleted)
        private const int PPCINFO_CHANGED = 4;  //4: Changed (Recipe Id is changed)

        private string _controlName = "";
        private CProbeControl _component = null;

        public PPIDRecipeMapReport()
        {
        }

        public override int Init()
        {
            _enable = true;

            //BC
            IB_PPID_RECIPE_MAP_REPORT = _main.SCANCONTEROLS.GetProperty(_controlName, "IB_PPID_RECIPE_MAP_REPORT");
            //PROBE CIM
            OB_PPID_RECIPE_MAP_REPORT = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_PPID_RECIPE_MAP_REPORT");
            //OB_PPID_RECIPE_MAP_REPORT = _main.PLCCONTEROLS.GetProperty(_controlName, "IB_PPID_RECIPE_MAP_REPORT");
            OW_PPID_RECIPE_MAP_REPORT_PPID = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_PPID_RECIPE_MAP_REPORT_PPID");
            OW_PPID_RECIPE_MAP_REPORT_RECIPE_ID = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_PPID_RECIPE_MAP_REPORT_RECIPE_ID");
            OW_PPID_RECIPE_MAP_REPORT_PPCINFO = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_PPID_RECIPE_MAP_REPORT_PPCINFO");
            this.ProgramDataList.Add(new CProgramData(this.ProgramDataList.Count, "PPID", typeof(string)));
            this.ProgramDataList.Add(new CProgramData(this.ProgramDataList.Count, "RecipeId", typeof(string)));
            this.ProgramDataList.Add(new CProgramData(this.ProgramDataList.Count, "PPCINFO", typeof(int)));
            this.ProgramDataList[this.ProgramDataList.Count - 1].Add(PPCINFO_CREATED, "Created (a new mapping is created and registered)");
            this.ProgramDataList[this.ProgramDataList.Count - 1].Add(PPCINFO_MODIFIED, "Modified (PPID are modified)");
            this.ProgramDataList[this.ProgramDataList.Count - 1].Add(PPCINFO_DELETED, "Deleted (any mapping is deleted)");
            this.ProgramDataList[this.ProgramDataList.Count - 1].Add(PPCINFO_CHANGED, "Changed (Recipe Id is changed)");
            this.ProgramDataList.Add(new CProgramData(this.ProgramDataList.Count, "ReturnCode", typeof(int)));
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
            get { return "PPID_RECIPE_MAP_REPORT"; }
        }

        public override string Version
        {
            get { return "ver 1.0"; }
        }

        public override string Description
        {
            get { return "BC에서 PPID로 장비 RECIPE 요청을 처리하는 프로그램"; }
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
            string PPID = "";
            string recipeId = "";
            int PPCINFO = 0;
            if (IsManualExecute)
            {
                PPID = "ABCDEFG";
                recipeId = "AAAA";
                PPCINFO = PPCINFO_CREATED;
            }
            else
            {
                switch (int.Parse(_values["PPCINFO"]))
                {
                    case PPCINFO_CREATED:  //1: Created (a new mapping is created and registered)
                        PPCINFO = PPCINFO_CREATED;
                        break;
                    case PPCINFO_MODIFIED: //2: Modified (PPID are modified)
                        PPCINFO = PPCINFO_MODIFIED;
                        break;
                    case PPCINFO_DELETED:  //3: Deleted (any mapping is deleted)
                        PPCINFO = PPCINFO_DELETED;
                        break;
                    case PPCINFO_CHANGED:  //4: Changed (Recipe Id is changed)
                        PPCINFO = PPCINFO_CHANGED;
                        break;
                    default:
                        //
                        break;
                }
            }
           
            _main.MelsecNetMultiWordWriteByString(OW_PPID_RECIPE_MAP_REPORT_PPID, _values["PPID"], 10, ' ');
            _main.MelsecNetMultiWordWriteByString(OW_PPID_RECIPE_MAP_REPORT_RECIPE_ID, _values["RECIPEID"], 10, ' ');
            _main.MelsecNetWordWrite(OW_PPID_RECIPE_MAP_REPORT_PPCINFO, PPCINFO);

            
            Log(string.Format("{0}\t{1}", _component.ControlName, string.Format("PGM DATA SEND - PPID={0} RECIPEID={1} PPCINFO={2}", PPID, recipeId, PPCINFO)));

            Log(string.Format("{0}\t{1}", _component.ControlName, "PGM DATA DISPLAY"));

            //CSubject subject = CUIManager.Inst.GetData("ucCimStatus");
            //subject.SetValue("EQPSTATUS", _component.MachineAutoMode);
            //subject.Notify();

            //Thread.Sleep(1000);
            //_main.MelsecNetBitOnOff(OB_PPID_RECIPE_MAP_REPORT, false);

            CTimeout timeout = CTimeoutManager.GetTimeout(_controlName, T1);
            timeout.TargetOffValueCheck = true;
            timeout.Begin(OB_PPID_RECIPE_MAP_REPORT, _main.CONTROLATTRIBUTES.GetProperty(IB_PPID_RECIPE_MAP_REPORT.ControlName, IB_PPID_RECIPE_MAP_REPORT.AttributeName) as ITimeoutResource);
            _main.MelsecNetBitOnOff(OB_PPID_RECIPE_MAP_REPORT, true);
            string tempMsg = "";
            bool error = false;
            if (CTimeout.WaitSync(timeout, 10))
            {
                string reasonText = "";

                switch (PPCINFO)
                {
                    case PPCINFO_CREATED:  //1: Created (a new mapping is created and registered)
                        _main.PPIDCreate(_values["PPID"], _values["RECIPEID"], out reasonText);
                        break;
                    case PPCINFO_MODIFIED: //2: Modified (PPID are modified)
                        _main.PPIDModify(_values["PPID"], _values["RECIPEID"], out reasonText);
                        break;
                    case PPCINFO_DELETED:  //3: Deleted (any mapping is deleted)
                        _main.PPIDDelete(_values["PPID"], _values["RECIPEID"], out reasonText);
                        break;
                    case PPCINFO_CHANGED:  //4: Changed (Recipe Id is changed)
                        _main.PPIDChange(_values["PPID"], _values["RECIPEID"], out reasonText);
                        break;
                    default:
                        break;
                }

                List<string> RecipeData = new List<string>(); ;
                CSubject subject = null;

                RecipeData.Add(_values["PPID"]);
                RecipeData.Add(_values["RECIPEID"]);
                RecipeData.Add(_values["PPCINFO"]);
                _values["TIME"] = DateTime.Now.ToString();
                RecipeData.Add(_values["TIME"]);
                _values["USER"] = _main.SystemConfig.UserAccount;
                RecipeData.Add(_values["USER"]);
                RecipeData.Add(_values["DESC"]);

                subject = CUIManager.Inst.GetData("UpdateRecipeData");
                subject.SetValue("Recipe", RecipeData);
                subject.Notify();

            }
            else
            {
                string reasonText = "";

                switch (PPCINFO)
                {
                    case PPCINFO_CREATED:  //1: Created (a new mapping is created and registered)
                        _main.PPIDCreate(_values["PPID"], _values["RECIPEID"], out reasonText);
                        break;
                    case PPCINFO_MODIFIED: //2: Modified (PPID are modified)
                        _main.PPIDModify(_values["PPID"], _values["RECIPEID"], out reasonText);
                        break;
                    case PPCINFO_DELETED:  //3: Deleted (any mapping is deleted)
                        _main.PPIDDelete(_values["PPID"], _values["RECIPEID"], out reasonText);
                        break;
                    case PPCINFO_CHANGED:  //4: Changed (Recipe Id is changed)
                        _main.PPIDChange(_values["PPID"], _values["RECIPEID"], out reasonText);
                        break;
                    default:
                        break;
                }

                List<string> RecipeData = new List<string>(); ;
                CSubject subject = null;

                RecipeData.Add(_values["PPID"]);
                RecipeData.Add(_values["RECIPEID"]);
                RecipeData.Add(_values["PPCINFO"]);
                _values["TIME"] = DateTime.Now.ToString();
                RecipeData.Add(_values["TIME"]);
                _values["USER"] = _main.SystemConfig.UserAccount;
                RecipeData.Add(_values["USER"]);
                RecipeData.Add(_values["DESC"]);

                subject = CUIManager.Inst.GetData("UpdateRecipeData");
                subject.SetValue("Recipe", RecipeData);
                subject.Notify();

                //error = true;
                _main.MelsecNetBitOnOff(OB_PPID_RECIPE_MAP_REPORT, false);
                //tempMsg = string.Format("PGM DATA TIMEOUT No response [timeout T1={0} sec]", T1 / 1000);
                //Log(string.Format("{0}\t{1}", _component.ControlName, tempMsg));
            }

            if (!error)
                return 0;
            CSubject subject1 = null;
            #region 메시지 창 표시

            string receivedTime = DateTime.Now.ToString("yyyyMMdd HH:mm:ss");
            string msgId = "0";
            string message = string.Format("[{0}] {1}", this.Name, tempMsg);
            string panelNo = "1";

            subject1 = CUIManager.Inst.GetData("CIMMessage");
            subject1.SetValue("List", new List<string>() { "MESSAGE_SET", msgId, receivedTime, message, panelNo });
            subject1.Notify();

            #endregion

            return 0;
        }

        public override int ExecuteManual(Dictionary<string, string> values)
        {
            _values = values;
            InnerExecute();
            return 0;
        }
    }
}
