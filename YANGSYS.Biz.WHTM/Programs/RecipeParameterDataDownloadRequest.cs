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

    public class RecipeParameterDataDownloadRequest : AProgram
    {
        private CMain _main = null;
        private bool _enable = false;

        //BC
        private CScanControlProperties IB_RECIPE_PARAMETER_DOWNLOAD = null;
        private CScanControlProperties IW_MACHINE_RECIPE = null;
        private CScanControlProperties IW_RECIPE_PARAMETER_DATA_DOWNLOAD = null;

        //PROBE CIM
        private CPLCControlProperties OB_RECIPE_PARMATER_DOWN_CONFIRM = null;
        private CPLCControlProperties OW_RECIPE_PARAMETER_DOWN_RESULT = null;

        private const int DOWNLOAD_ACCEPT = 1;
        private const int DOWNLOAD_RECIPE_NOT_EXIST = 2;
        private const int DOWNLOAD_RECIPE_BEING_USED = 3;
        private const int DOWNLOAD_VALIDATION_NG = 4;

        private string _controlName = "";
        private CProbeControl _component = null;
        public RecipeParameterDataDownloadRequest()
        {
        }
        public override int Init()
        {
            _enable = true;

            IB_RECIPE_PARAMETER_DOWNLOAD = _main.SCANCONTEROLS.GetProperty(_controlName, "IB_RECIPE_PARAMETER_DOWNLOAD");
            IW_MACHINE_RECIPE = _main.SCANCONTEROLS.GetProperty(_controlName, "IW_MACHINE_RECIPE");
            IW_RECIPE_PARAMETER_DATA_DOWNLOAD = _main.SCANCONTEROLS.GetProperty(_controlName, "IW_RECIPE_PARAMETER_DATA_DOWNLOAD");

            OB_RECIPE_PARMATER_DOWN_CONFIRM = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_RECIPE_PARMATER_DOWN_CONFIRM");
            OW_RECIPE_PARAMETER_DOWN_RESULT = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_RECIPE_PARAMETER_DOWN_RESULT");

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
            get { return "RECIPE_PARAMETER_DOWNLOAD"; }
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
            string temp = _main.MelsecNetWordRead(IW_MACHINE_RECIPE);

            ushort[] temp1 = _main.MelsecNetMultiWordRead(IW_RECIPE_PARAMETER_DATA_DOWNLOAD);

            int machineRecipe = 0;
            int resultCode = 0;
            bool check = false;

            int.TryParse(temp, out machineRecipe);


            resultCode = DOWNLOAD_ACCEPT;
            //check = _component.CIMMode != cimMode;
            //양전자 조건 검사 위치
            //에러: 
            //returnCode = check ? CIM_MODE_ACCEPT : CIM_MODE_ALREADY_IN_DESIRED_STATUS;

            //양전자 프로그램에 recipe 존재 여부 확인

            //있으면 양전자 Recipe 파라미터 업데이트 후 결과 받기


            _main.MelsecNetWordWrite(OW_RECIPE_PARAMETER_DOWN_RESULT, resultCode);

            _main.MelsecNetBitOnOff(OB_RECIPE_PARMATER_DOWN_CONFIRM, true);
            Thread.Sleep(1000);

            _main.MelsecNetBitOnOff(OB_RECIPE_PARMATER_DOWN_CONFIRM, false);

            return 0;
        }
    }
}
