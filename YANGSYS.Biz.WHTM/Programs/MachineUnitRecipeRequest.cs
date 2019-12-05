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

    public class MachineUnitRecipeRequest : AProgram
    {
        private CMain _main = null;
        private bool _enable = false;

        //BC
        private CScanControlProperties IB_MACHINE_RECIPE_REQUEST_CONFIRM = null;
        private CScanControlProperties IW_MACHINE_RECIPE_CONFIRM_RETURN_CODE = null;
        private CScanControlProperties IW_MACHINE_RECIPE_CONFIRM_SEND_MACHINE_RECIPE = null;
         
            
        //PROBE CIM
        private CPLCControlProperties OB_MACHINE_RECIPE_REQUEST = null;
        private CPLCControlProperties OW_MACHINE_RECIPE_REQUEST_PPID = null;
        private CPLCControlProperties OW_MACHINE_RECIPE_REQUEST_UNIT_ID = null;


        private const int OK = 1;
        private const int NG_NO_RECIPE = 2;
        private const int NG_NOT_DATA_FORMAT = 3;
        private string _controlName = "";
        private CProbeControl _component = null;
        public MachineUnitRecipeRequest()
        {
        }
        public override int Init()
        {
            _enable = true;

            IB_MACHINE_RECIPE_REQUEST_CONFIRM = _main.SCANCONTEROLS.GetProperty(_controlName, "IB_MACHINE_RECIPE_REQUEST_CONFIRM");
            IW_MACHINE_RECIPE_CONFIRM_RETURN_CODE = _main.SCANCONTEROLS.GetProperty(_controlName, "IW_MACHINE_RECIPE_CONFIRM_RETURN_CODE");
            IW_MACHINE_RECIPE_CONFIRM_SEND_MACHINE_RECIPE = _main.SCANCONTEROLS.GetProperty(_controlName, "IW_MACHINE_RECIPE_CONFIRM_SEND_MACHINE_RECIPE");

            OB_MACHINE_RECIPE_REQUEST = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_MACHINE_RECIPE_REQUEST");
            OW_MACHINE_RECIPE_REQUEST_PPID = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_MACHINE_RECIPE_REQUEST_PPID");
            OW_MACHINE_RECIPE_REQUEST_UNIT_ID = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_MACHINE_RECIPE_REQUEST_UNIT_ID");

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
            get { return "MACHINE_UNIT_RECIPE_REQUEST"; }
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
            List<int> recipeList = new List<int>();

            int ppid = 0;
            int unitId = 0;

            _main.MelsecNetWordWrite(OW_MACHINE_RECIPE_REQUEST_PPID, ppid);
            _main.MelsecNetWordWrite(OW_MACHINE_RECIPE_REQUEST_UNIT_ID, unitId);

            
            CTimeout timeout = CTimeoutManager.GetTimeout(_component.ControlName, 2000);
            timeout.TargetOffValueCheck = true;
            timeout.Begin(OB_MACHINE_RECIPE_REQUEST, _main.CONTROLATTRIBUTES.GetProperty(IB_MACHINE_RECIPE_REQUEST_CONFIRM.ScanControlName, IB_MACHINE_RECIPE_REQUEST_CONFIRM.ScanAttribute) as ITimeoutResource);

            _main.MelsecNetBitOnOff(OB_MACHINE_RECIPE_REQUEST, true);


            if (CTimeout.WaitSync(timeout, 10))
            {

                string retrun = _main.MelsecNetWordRead(IW_MACHINE_RECIPE_CONFIRM_RETURN_CODE);
                string recipe = _main.MelsecNetWordRead(IW_MACHINE_RECIPE_CONFIRM_SEND_MACHINE_RECIPE);

                switch (int.Parse(retrun))
                {
                    case OK:
                        break;
                    case NG_NOT_DATA_FORMAT:
                        break;
                    case NG_NO_RECIPE:
                        break;
                    default:
                        break;
                }
            }
            else
            {
                //에러:응답이 없다..
            }
            _main.MelsecNetBitOnOff(OB_MACHINE_RECIPE_REQUEST, false);

            return 0;
        }
    }
}
