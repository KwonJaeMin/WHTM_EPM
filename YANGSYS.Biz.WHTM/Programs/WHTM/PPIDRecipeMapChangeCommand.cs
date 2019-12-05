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

    public class PPIDRecipeMapChangeCommand : AProgram
    {
        private CMain _main = null;
        private bool _enable = false;

        //BC
        private CScanControlProperties IB_PPID_RECIPE_ID_MAP_CHANGE = null;//SD_B_PPIDRecipeIdMapChange_BCToL3
        private CScanControlProperties IW_PPID_RECIPE_ID_MAP_PPID = null;//SD_W_PPIDRecipeIdMapChange_BCToL3,0
        private CScanControlProperties IW_PPID_RECIPE_ID_MAP_PPID_RECIPEID = null;//SD_W_PPIDRecipeIdMapChange_BCToL3,1
        private CScanControlProperties IW_PPID_RECIPE_ID_MAP_PPID_PPCINFO = null;//SD_W_PPIDRecipeIdMapChange_BCToL3,2
        private CScanControlProperties IW_PPID_RECIPE_ID_MAP_PPID_RETURN = null;//SD_W_PPIDRecipeIdMapChange_BCToL3,3

        //PROBE CIM
        private CPLCControlProperties OB_PPID_RECIPE_ID_MAP_CHANGE = null;//SD_B_PPIDRecipeIdMapChange_BCToL3
        private CPLCControlProperties OW_PPID_RECIPE_ID_MAP_PPID_RETURN = null;//SD_W_PPIDRecipeIdMapChange_BCToL3,3

        private const int PPCINFO_CREATED = 1;  //1: Created (a new mapping is created and registered)
        private const int PPCINFO_MODIFIED = 2; //2: Modified (PPID are modified)
        private const int PPCINFO_DELETED = 3;  //3: Deleted (any mapping is deleted)
        private const int PPCINFO_CHANGED = 4;  //4: Changed (Recipe Id is changed)

        private const int RESULT_COMMAND_OK = 1;
        private const int RESULT_COMMAND_ERROR = 2;

        private string _controlName = "";
        private CProbeControl _component = null;

        public PPIDRecipeMapChangeCommand()
        {
        }

        public override int Init()
        {
            _enable = true;

            IB_PPID_RECIPE_ID_MAP_CHANGE = _main.SCANCONTEROLS.GetProperty(_controlName, "IB_PPID_RECIPE_ID_MAP_CHANGE");
            IW_PPID_RECIPE_ID_MAP_PPID = _main.SCANCONTEROLS.GetProperty(_controlName, "IW_PPID_RECIPE_ID_MAP_PPID");
            IW_PPID_RECIPE_ID_MAP_PPID_RECIPEID = _main.SCANCONTEROLS.GetProperty(_controlName, "IW_PPID_RECIPE_ID_MAP_PPID_RECIPEID");
            IW_PPID_RECIPE_ID_MAP_PPID_PPCINFO = _main.SCANCONTEROLS.GetProperty(_controlName, "IW_PPID_RECIPE_ID_MAP_PPID_PPCINFO");
            IW_PPID_RECIPE_ID_MAP_PPID_RETURN = _main.SCANCONTEROLS.GetProperty(_controlName, "IW_PPID_RECIPE_ID_MAP_PPID_RETURN");

            OB_PPID_RECIPE_ID_MAP_CHANGE = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_PPID_RECIPE_ID_MAP_CHANGE");
            OW_PPID_RECIPE_ID_MAP_PPID_RETURN = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_PPID_RECIPE_ID_MAP_PPID_RETURN");

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
            get { return "PPID_RECIPE_ID_MAP_CHANGE"; }
        }

        public override string Version
        {
            get { return "ver 1.0"; }
        }

        public override string Description
        {
            get { return "BC에서 PPID MAP 변경하라는 명령 처리 프로그램"; }
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
            string PPID = "";
            string recipeID = "";
            string PPCINFOTemp = "";
            string resultTemp = "";

            if (IsManualExecute)
            {
                PPID = this.ProgramDataList[0].Value.ToString();
                recipeID = this.ProgramDataList[1].Value.ToString();
                PPCINFOTemp = this.ProgramDataList[2].Value.ToString();
                resultTemp = this.ProgramDataList[3].Value.ToString();

                PPID = "AAAB";
                recipeID = "CCCD";
                PPCINFOTemp = "1";
                resultTemp = "0";
            }
            else
            {
                PPID = _main.MelsecNetMultiWordReadToString(IW_PPID_RECIPE_ID_MAP_PPID).Trim();
                recipeID = _main.MelsecNetMultiWordReadToString(IW_PPID_RECIPE_ID_MAP_PPID_RECIPEID).Trim();
                PPCINFOTemp = SmartDevice.UTILS.PLCUtils.HexToDec(_main.MelsecNetWordRead(IW_PPID_RECIPE_ID_MAP_PPID_PPCINFO)).Trim();
                resultTemp = SmartDevice.UTILS.PLCUtils.HexToDec(_main.MelsecNetWordRead(IW_PPID_RECIPE_ID_MAP_PPID_RETURN)).Trim();
            }

            Log(string.Format("{0}\t{1}", _component.ControlName, string.Format("PGM DATA RECV - {0} {1} {2} {3}", PPID, recipeID, PPCINFOTemp, resultTemp)));

            int result = 0;
            int.TryParse(resultTemp, out result);
            int PPCINFO = 0;
            int.TryParse(PPCINFOTemp, out PPCINFO);
            bool error = false;
            string tempMsg = "";

            switch (PPCINFO)
            {
                case PPCINFO_CREATED:  //1: Created (a new mapping is created and registered)
                    if (!_main.PPIDCreate(PPID.Trim(), recipeID.Trim(), out tempMsg))
                    {
                        Log(string.Format("{0}\t{1}", _component.ControlName, string.Format("PGM DATA MAP CREATED ERROR - PPID={0}", PPID)));
                        error = true;
                    }
                    break;
                case PPCINFO_MODIFIED: //2: Modified (PPID are modified)
                    if (!_main.PPIDModify(PPID.Trim(), recipeID.Trim(), out tempMsg))
                    {
                        Log(string.Format("{0}\t{1}", _component.ControlName, string.Format("PGM DATA MAP MODIFIED ERROR - PPID={0}", PPID)));
                        error = true;
                    }
                    break;
                case PPCINFO_DELETED:  //3: Deleted (any mapping is deleted)
                    if (!_main.PPIDDelete(PPID.Trim(), recipeID.Trim(), out tempMsg))
                    {
                        Log(string.Format("{0}\t{1}", _component.ControlName, string.Format("PGM DATA MAP DELETED ERROR - PPID={0}", PPID)));
                        error = true;
                    }
                    break;
                case PPCINFO_CHANGED:  //4: Changed (Recipe Id is changed)
                    if (!_main.PPIDChange(PPID.Trim(), recipeID.Trim(), out tempMsg))
                    {
                        Log(string.Format("{0}\t{1}", _component.ControlName, string.Format("PGM DATA MAP CHANGED ERROR - PPID={0}", PPID)));
                        error = true;
                    }
                    break;
                default:
                    Log(string.Format("{0}\t{1}", _component.ControlName, string.Format("PGM DATA MAP UNKNOWN CODE ERROR - PPID={0} PPCINFO={1}", PPID, PPCINFO)));
                    error = true;
                    break;
            }

            this.StatusChange(enumProgramStatus.PROCESSING);

            //거부 조건?

            result = error ? RESULT_COMMAND_ERROR : RESULT_COMMAND_OK;

            _main.MelsecNetWordWrite(OW_PPID_RECIPE_ID_MAP_PPID_RETURN, result);
            Thread.Sleep(1000);
            _main.MelsecNetBitOnOff(OB_PPID_RECIPE_ID_MAP_CHANGE, false);

            Log(string.Format("{0}\t{1}", _component.ControlName, string.Format("PGM DATA SEND - {0}", result)));

            if (!error)
            {
                string reasonText = "";

                switch (PPCINFO)
                {
                    case PPCINFO_CREATED:  //1: Created (a new mapping is created and registered)
                        _main.PPIDCreate(PPID, recipeID, out reasonText);
                        break;
                    case PPCINFO_MODIFIED: //2: Modified (PPID are modified)
                        _main.PPIDModify(PPID, recipeID, out reasonText);
                        break;
                    case PPCINFO_DELETED:  //3: Deleted (any mapping is deleted)
                        _main.PPIDDelete(PPID, recipeID, out reasonText);
                        break;
                    case PPCINFO_CHANGED:  //4: Changed (Recipe Id is changed)
                        _main.PPIDChange(PPID, recipeID, out reasonText);
                        break;
                    default:
                        break;
                }

                List<string> RecipeData = new List<string>(); ;
                CSubject subject = null;

                RecipeData.Add(PPID);
                RecipeData.Add(recipeID);
                RecipeData.Add(PPCINFO.ToString());
                RecipeData.Add(DateTime.Now.ToString());
                RecipeData.Add(_main.SystemConfig.UserAccount);
                RecipeData.Add("");

                subject = CUIManager.Inst.GetData("UpdateRecipeData");
                subject.SetValue("Recipe", RecipeData);
                subject.Notify();

                return 0;
            }

            Log(string.Format("{0}\t{1}", _component.ControlName, "PGM DATA DISPLAY"));
            #region 메시지 창 표시

            string receivedTime = DateTime.Now.ToString("yyyyMMdd HH:mm:ss");
            string msgId = "0";
            string message = string.Format("[{0}] {1}", this.Name, tempMsg);
            string panelNo = "1";

            CSubject subject1 = CUIManager.Inst.GetData("CIMMessage");
            subject1.SetValue("List", new List<string>() { "MESSAGE_SET", msgId, receivedTime, message, panelNo });
            subject1.Notify();

            #endregion

            return 0;
        }
    }
}
