using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MainLibrary;
using YANGSYS.ControlLib;
using SOFD.Global.Interface;


namespace YANGSYS.Biz.CommandHandler
{
    public class CShutdownCommand : ACommand
    {
        public CShutdownCommand()
        {
            this.CommandName = "CLOSE";
        }

        public override int Execute()
        {
            Application.Exit();

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
