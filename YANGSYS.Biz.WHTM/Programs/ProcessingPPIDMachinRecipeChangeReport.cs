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

    public class ProcessingPPIDMachinRecipeChangeReport : AProgram
    {
        private CMain _main = null;
        private bool _enable = false;

        //BC

        //PROBE CIM
        private CPLCControlProperties OB_PROCESSING_PPID_RECIPE_CHANGE_REPORT = null;
        private CPLCControlProperties OW_PROCESSING_PPID = null;
        private CPLCControlProperties OW_PROCESSING_MACHINE_RECIPE = null;
        
        private string _controlName = "";
        private CProbeControl _component = null;
        public ProcessingPPIDMachinRecipeChangeReport()
        {
        }
        public override int Init()
        {
            _enable = true;

            OB_PROCESSING_PPID_RECIPE_CHANGE_REPORT = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_PROCESSING_PPID_RECIPE_CHANGE_REPORT");
            OW_PROCESSING_PPID = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_PROCESSING_PPID");
            OW_PROCESSING_MACHINE_RECIPE = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_PROCESSING_MACHINE_RECIPE");

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
            get { return "PROCESSING_PPID_MACHIN_RECIPE_CHANGE_REPORT"; }
        }

        public override string Version
        {
            get { return "ver 1.0"; }
        }

        public override string Description
        {
            get { return "장비 레시피 변경시 BC에 데이터 전송"; }
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
        public override int Execute(Dictionary<string, string> values)
        {
            throw new NotImplementedException();
        }
        private int InnerExecute()
        {
            string temp = "0";
            int ppid = 0;
            int machineRecipe = 0;

            int.TryParse(temp, out machineRecipe);

            //양전자 Recipe 존재여부 확인
            //있을 경우 parameter 받아 옴

            //check = _component.CIMMode != cimMode;
            //양전자 조건 검사 위치
            //에러: 

            _main.MelsecNetWordWrite(OW_PROCESSING_PPID, ppid);
            _main.MelsecNetWordWrite(OW_PROCESSING_MACHINE_RECIPE, machineRecipe);

            _main.MelsecNetBitOnOff(OB_PROCESSING_PPID_RECIPE_CHANGE_REPORT, true);

            Thread.Sleep(1000);

            _main.MelsecNetBitOnOff(OB_PROCESSING_PPID_RECIPE_CHANGE_REPORT, false);
            return 0;
        }
    }
}
