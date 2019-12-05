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

    public class PPIDRecipeMapRequestCommand : AProgram
    {
        private CMain _main = null;
        private bool _enable = false;

        //BC
        private CScanControlProperties IB_PPID_RECIPE_MAP_REQUEST = null;//SD_B_PPIDRecipeMapRequest_BCToL3
        private CScanControlProperties IW_PPID_RECIPE_MAP_REQUEST_PPID = null;//SD_W_PPIDRecipeMapRequest_BCToL3,0
        private CScanControlProperties IW_PPID_RECIPE_MAP_REQUEST_RECIPEID_RETRUN = null;//SD_W_PPIDRecipeMapRequest_BCToL3,1

        //PROBE CIM
        private CPLCControlProperties OB_PPID_RECIPE_MAP_REQUEST = null;//SD_B_PPIDRecipeMapRequest_BCToL3
        private CPLCControlProperties OW_PPID_RECIPE_MAP_REQUEST_RECIPEID_RETRUN = null;//SD_W_PPIDRecipeMapRequest_BCToL3,1

        private const int RESULT_COMMAND_OK = 1;
        private const int RESULT_COMMAND_ERROR = 2;

        private string _controlName = "";
        private CProbeControl _component = null;

        public PPIDRecipeMapRequestCommand()
        {
        }

        public override int Init()
        {
            _enable = true;

            //BC
            IB_PPID_RECIPE_MAP_REQUEST = _main.SCANCONTEROLS.GetProperty(_controlName, "IB_PPID_RECIPE_MAP_REQUEST");
            IW_PPID_RECIPE_MAP_REQUEST_PPID = _main.SCANCONTEROLS.GetProperty(_controlName, "IW_PPID_RECIPE_MAP_REQUEST_PPID");
            IW_PPID_RECIPE_MAP_REQUEST_RECIPEID_RETRUN = _main.SCANCONTEROLS.GetProperty(_controlName, "IW_PPID_RECIPE_MAP_REQUEST_RECIPEID_RETRUN");

            //PROBE CIM
            OB_PPID_RECIPE_MAP_REQUEST = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_PPID_RECIPE_MAP_REQUEST");
            OW_PPID_RECIPE_MAP_REQUEST_RECIPEID_RETRUN = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_PPID_RECIPE_MAP_REQUEST_RECIPEID_RETRUN");

            this.ProgramDataList.Add(new CProgramData(this.ProgramDataList.Count, "PPID", typeof(string)));
            this.ProgramDataList.Add(new CProgramData(this.ProgramDataList.Count, "RecipeId", typeof(string)));

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
            get { return "PPID_RECIPE_MAP_REQUEST"; }
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
        
        protected override int InnerExecute()
        {
            string PPIDTemp = "";
            string resultTemp = "";

            if (IsManualExecute)
            {
                PPIDTemp = this.ProgramDataList[0].Value.ToString();
                resultTemp = this.ProgramDataList[1].Value.ToString();

                PPIDTemp = "AAAB";
                resultTemp = "BBBC";
            }

            else
            {
                PPIDTemp = _main.MelsecNetMultiWordReadToString(IW_PPID_RECIPE_MAP_REQUEST_PPID).Trim();
                resultTemp = _main.MelsecNetMultiWordReadToString(IW_PPID_RECIPE_MAP_REQUEST_RECIPEID_RETRUN).Trim();
            }

            Log(string.Format("{0}\t{1}", _component.ControlName, string.Format("PGM DATA RECV - PPID={0} RECIPEID={1}", PPIDTemp, resultTemp)));

            bool error = false;
            string tempMsg = "";

            if (_main.PPIDMap.ContainsKey(PPIDTemp.Trim()))
            {
                resultTemp = _main.PPIDMap[PPIDTemp.Trim()];
            }
            else
            {
                error = true;
                tempMsg = string.Format("PPID/RECIPE MAP ERROR - NO REGISTERED PPID={0}", PPIDTemp);
                Log(string.Format("{0}\t{1}", _component.ControlName, "PGM DATA " + tempMsg));


                resultTemp = "";            
            }

            _main.MelsecNetMultiWordWriteByString(OW_PPID_RECIPE_MAP_REQUEST_RECIPEID_RETRUN, resultTemp, 10, ' ');
            Thread.Sleep(1000);
            _main.MelsecNetBitOnOff(OB_PPID_RECIPE_MAP_REQUEST, false);

            Log(string.Format("{0}\t{1}", _component.ControlName, string.Format("PGM DATA SEND - {0}", resultTemp)));

            if (!error)
                return 0;

            Log(string.Format("{0}\t{1}", _component.ControlName, "PGM DATA DISPLAY"));
            #region 메시지 창 표시

            string receivedTime = DateTime.Now.ToString("yyyyMMdd HH:mm:ss");
            string msgId = "0";
            string message = string.Format("[{0}] {1}", this.Name, tempMsg);
            string panelNo = "1";

            CSubject subject = CUIManager.Inst.GetData("CIMMessage");
            subject.SetValue("List", new List<string>() { "MESSAGE_SET", msgId, receivedTime, message, panelNo });
            subject.Notify();

            #endregion

            return 0;
        }
    }
}
