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

    public class MachineRecipeListChangedReport : AProgram
    {
        private CMain _main = null;
        private bool _enable = false;

        //BC

        //PROBE CIM
        private CPLCControlProperties OB_RECIPE_LIST_CHANGE_REPORT = null;
        private CPLCControlProperties OW_MACHINE_RECIPE_LIST = null;

        private string _controlName = "";
        private CProbeControl _component = null;
        public MachineRecipeListChangedReport()
        {
        }
        public override int Init()
        {
            _enable = true; 

            OB_RECIPE_LIST_CHANGE_REPORT = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_RECIPE_LIST_CHANGE_REPORT");
            OW_MACHINE_RECIPE_LIST = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_MACHINE_RECIPE_LIST");

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
            get { return "MACHINE_RECIPE_LIST_CHANGED_REPORT"; }
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

            
            //양전자 메시지 있음.
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000010")))); //1번
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000000000000"))));
            recipeList.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.BinaryToHex("0000000010000000"))));//999

            _main.MelsecNetMultiWordWrite(OW_MACHINE_RECIPE_LIST, recipeList);

            _main.MelsecNetBitOnOff(OB_RECIPE_LIST_CHANGE_REPORT, true);
            Thread.Sleep(1000);
            _main.MelsecNetBitOnOff(OB_RECIPE_LIST_CHANGE_REPORT, false);

            return 0;
        }
    }
}
