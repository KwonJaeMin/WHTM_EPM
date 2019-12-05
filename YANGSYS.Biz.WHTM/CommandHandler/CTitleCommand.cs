using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SOFD.Logger;
using SOFD.Global.Interface;
using MainLibrary;
using YANGSYS.ControlLib;

namespace YANGSYS.Biz.CommandHandler
{
    public class CTitleGroupCommand : ACommand
    {
        public CTitleGroupCommand()
        {
            this.CommandName = "TITLE";
            this.IsGroup = true;
        }
        public override int Execute()
        {
            if (this.IsGroup)
            {
                try
                {
                    switch (SubCommandName)
                    {
                        case "SHUTDOWN":
                            _main.ShutDown();
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {

                    CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, CExceptionLogFormat.DEFAULT_KEY, ex));
                }
            }

            return 0;
        }

        public override int Execute<T>(T parameters)
        {
            throw new NotImplementedException();
        }

        public override int Execute(KeyValuePair<string, string> value)
        {
            switch (SubCommandName)
            {
                case "BUZZER_OFF":
                    Dictionary<string, string> values1 = new Dictionary<string, string>();
                    values1.Add("COMMAND_NAME", "BUZZER");
                    values1.Add("COMMAND", "0");
                    _component.GetProgram("YANGSYS_MESSAGE_HANDLER").ExecuteManual(values1);
                    break;
                default:
                    break;
            }

            return 0;
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
