using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MainLibrary;
using YANGSYS.ControlLib;
using SOFD.Global.Interface;

namespace YANGSYS.Biz.CommandHandler
{
    public class CMenuGroupCommand : ACommand
    {
        public CMenuGroupCommand()
        {
            this.CommandName = "MENU";
            this.IsGroup = true;
        }
        public override int Execute()
        {
            string temp = "";
            switch (SubCommandName)
            {
                case "SHUTDOWN":

                    break;
                case "RUNNING_MODE_CHANGE":

                    temp = this.GetParameterValue("RUNNING_MODE");
                    bool running = false;
                    if (bool.TryParse(temp, out running))
                    {
                        _component.Running = running;
                    }
                    break;
                case "CIM_MODE_CHANGE":

                    temp = this.GetParameterValue("CIM_MODE");
                    int cimMode = 0;
                    if(int.TryParse(temp, out cimMode))
                    {
                        _component.CIMMode = cimMode;
                    }
                    _component.GetProgram("CIM_CONNECTION_MODE_NOTIFICATION").Execute();
                    break;
                case "AUTO_RECIPE_CHANGE":

                    temp = this.GetParameterValue("AUTO_RECIPE_CHANGE");
                    bool autoRecipe = false;
                    if (bool.TryParse(temp, out autoRecipe))
                    {
                        _component.AutoRecipeMode = autoRecipe; 
                    }
                    break;
                case "EQP_MODE_CHANGE":

                    temp = this.GetParameterValue("EQP_MODE");
                    int eqpMode = 0;
                    if (int.TryParse(temp, out eqpMode))
                    {
                        _component.EquipmentMode = eqpMode;
                    }

                    _component.GetProgram("MACHINE_MODE_CHANGE_REPORT").Execute();

                    break;
                case "EXCHANGE_MODE_CHANGE":

                    temp = this.GetParameterValue("EXCHANGE_MODE_CHANGE");
                    bool exchangeMode = false;
                    if (bool.TryParse(temp, out exchangeMode))
                    {
                        _component.ExchangeMode = exchangeMode;
                    }

                    break;
                case "EXCHANGE_POSSIBLE_CHANGE":
                    temp = this.GetParameterValue("EXCHANGE_POSSIBLE");
                    bool exchangePossible = false;
                    if (bool.TryParse(temp, out exchangePossible))
                    {
                        _component.ExchangePossible = exchangePossible;
                    }
                    break;

                default:
                    break;
            }

            return 0;
        }

        public override int Execute<T>(T parameters)
        {
            throw new NotImplementedException();
        }

        private CMain _main = null;
        private CProbeControl _component = null;

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
            return 0;
        }

        public override int Init()
        {
            return 0;
        }
    }
}
