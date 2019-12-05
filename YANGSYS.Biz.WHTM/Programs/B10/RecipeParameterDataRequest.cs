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

    public class RecipeParameterDataRequest : AProgram
    {
        private CMain _main = null;
        private bool _enable = false;

        //BC
        private CScanControlProperties IB_RECIPE_PARAMETER_DATA_REQUEST = null;
        private CScanControlProperties IW_RECIPE_PARAMETER_REQUEST_MACHINE_RECIPE = null;
        private CScanControlProperties IW_RECIPE_PARAMETER_REQUEST_UNIT_ID = null;

        //PROBE CIM
        private CPLCControlProperties OB_RECIPE_PARAMETER_DATA_REPORT = null;
        private CPLCControlProperties OW_MACHINE_RECIPE = null;
        private CPLCControlProperties OW_RECIPE_PARAMETER_DATA = null;

        private string _controlName = "";
        private CProbeControl _component = null;
        public RecipeParameterDataRequest()
        {
        }
        public override int Init()
        {
            _enable = true;

            IB_RECIPE_PARAMETER_DATA_REQUEST = _main.SCANCONTEROLS.GetProperty(_controlName, "IB_RECIPE_PARAMETER_DATA_REQUEST");
            IW_RECIPE_PARAMETER_REQUEST_MACHINE_RECIPE = _main.SCANCONTEROLS.GetProperty(_controlName, "IW_RECIPE_PARAMETER_REQUEST_MACHINE_RECIPE");
            IW_RECIPE_PARAMETER_REQUEST_UNIT_ID = _main.SCANCONTEROLS.GetProperty(_controlName, "IW_RECIPE_PARAMETER_REQUEST_UNIT_ID");

            OB_RECIPE_PARAMETER_DATA_REPORT = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_RECIPE_PARAMETER_DATA_REPORT");
            OW_MACHINE_RECIPE = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_MACHINE_RECIPE");
            OW_RECIPE_PARAMETER_DATA = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_RECIPE_PARAMETER_DATA");

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
            get { return "RECIPE_PARAMETER_DATA_REQUEST"; }
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
            string temp = _main.MelsecNetWordRead(IW_RECIPE_PARAMETER_REQUEST_MACHINE_RECIPE);

            int machineRecipe = 0;
            List<int> recipeParameter = new List<int>();

            int.TryParse(temp, out machineRecipe);

            string temp1 = _main.MelsecNetWordRead(IW_RECIPE_PARAMETER_REQUEST_UNIT_ID);
            

            //양전자 Recipe 존재여부 확인
            //있을 경우 parameter 받아 옴

            //check = _component.CIMMode != cimMode;
            //양전자 조건 검사 위치
            //에러: 

            _main.MelsecNetWordWrite(OW_MACHINE_RECIPE, machineRecipe);

            recipeParameter.Add(12);//glass1
            recipeParameter.Add(34);//glass1
            recipeParameter.Add(56);

            _main.MelsecNetMultiWordWrite(OW_RECIPE_PARAMETER_DATA, recipeParameter);

            _main.MelsecNetBitOnOff(OB_RECIPE_PARAMETER_DATA_REPORT, true);

            Thread.Sleep(1000);

            _main.MelsecNetBitOnOff(OB_RECIPE_PARAMETER_DATA_REPORT, false);

            return 0;
        }
    }
}
