using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SOFD.Logger;

using YANGSYS.Biz.Programs;
using YANGSYS.ControlLib;
using MainLibrary;
using SOFD.Component.Interface;
using SOFD.Global.Interface;
using SOFD.Component;

namespace YANGSYS.Biz.CommandHandler
{
    public class CRequestGroupCommand : ACommand
    {
        public CRequestGroupCommand()
        {
            this.CommandName = "REQUEST";
            this.IsGroup = true;
        }

        public override int Execute()
        {
            if (this.IsGroup)
            {
                try
                {
                    Dictionary<string, string> values = new Dictionary<string, string>();

                    switch (SubCommandName)
                    {
                        case "LINK_SIGNAL_UPDATE":
                            bool update = this.GetParameterValue("UPDATE").ToLower() == "true";
                            _main.LinkSignalMonitoring = update;
                            break;
                        case "STAGE_LINK_SIGNAL_ON/OFF":

                            bool value = false;
                            SOFD.Properties.CPLCControlProperties property = _main.PLCCONTEROLS.GetProperty(_component.ControlName, this.GetParameterValue("SIGNAL_NAME"));

                            value = _main.MelsecNetBitRead(property, 1);
                            _main.MelsecNetBitOnOff(property, !value);//토글로 동작함.
                            break;
                        case "STAGE_LINK_SIGNAL_INIT":
                            Dictionary<string, string> values0 = new Dictionary<string, string>();
                            values0.Add("COMMAND_NAME", "LINK_SIGNAL_INIT");
                            values0.Add("COMMAND", "0");
                            _component.GetProgram("YANGSYS_MESSAGE_HANDLER").ExecuteManual(values0);
                            break;
                        case "BUZZER_OFF":
                            Dictionary<string, string> values1 = new Dictionary<string, string>();
                            values1.Add("COMMAND_NAME", "BUZZER");
                            values1.Add("COMMAND", "0");
                            _component.GetProgram("YANGSYS_MESSAGE_HANDLER").ExecuteManual(values1);
                            break;
                        case "ALARM_RESET":
                            Dictionary<string, string> values2 = new Dictionary<string, string>();
                            values2.Add("COMMAND_NAME", "ALARM_RESET_REQUEST");
                            values2.Add("COMMAND", "0");
                            values2.Add("ALARM_CODE", this.GetParameterValue("ALARM_CODE"));
                            _component.GetProgram("YANGSYS_MESSAGE_HANDLER").ExecuteManual(values2);
                            break;
                        case "SCRAP_REPORT":
                            Dictionary<string, string> values3 = new Dictionary<string, string>();
                            values3.Add("GLASSID", this.GetParameterValue("GLASSID"));
                            values3.Add("SCRAPINDEX", this.GetParameterValue("SCRAPINDEX"));
                            _component.GetProgram("REMOVED_JOB_REPORT").ExecuteManual(values3);

                            break;
                        case "READ_RECEIVED_GLASSDATA":
                            values.Clear();
                            values.Add("ACTION", "READ_RECEIVED_GLASSDATA");
                            _component.GetProgram("GLASS_DATA_HANDLER").ExecuteManual(values);
                            break;
                        case "READ_PROCESSING_GLASSDATA":
                            values.Clear();
                            values.Add("ACTION", "READ_PROCESSING_GLASSDATA");
                            _component.GetProgram("GLASS_DATA_HANDLER").ExecuteManual(values);
                            break;
                        case "READ_SENTOUT_GLASSDATA":
                            values.Clear();
                            values.Add("ACTION", "READ_SENTOUT_GLASSDATA");
                            _component.GetProgram("GLASS_DATA_HANDLER").ExecuteManual(values);
                            break;
                        case "JOB_JUDGE_CHANGE":

                            break;
                        case "YESDRVOPEN":
                            _main.Driver.Stop();
                            _main.Driver.Start();
                            break;
                        case "YESDRVCLOSE":
                            _main.Driver.Stop();
                            break;
                        case "PPID_MAP_REPORT":
                            Dictionary<string, string> values4 = new Dictionary<string, string>();
                            values4.Add("PPID", this.GetParameterValue("PPID"));
                            values4.Add("RECIPEID", this.GetParameterValue("RECIPEID"));
                            values4.Add("PPCINFO", this.GetParameterValue("PPCINFO"));
                            values4.Add("TIME", this.GetParameterValue("TIME"));
                            values4.Add("USER", this.GetParameterValue("USER"));
                            values4.Add("DESC", this.GetParameterValue("DESC"));
                            _component.GetProgram("RECIPE_CHANGE_AUTHORIZATION").ExecuteManual(values4);
                            break;
                        case "RECIPE_UPLOAD":
                            _main.SendData(new List<string>() { "RECIPE_LIST_REQ" });
                            break;
                        case "MESSAGE_ALLCLEAR":
                            _main.SendData(new List<string>() { "CIM_MESSAGE_ON", "X", "" });
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
            switch (SubCommandName)
            {
                case "MESSAGE_CONFIRM":
                    if (parameters is Dictionary<string, string>)
                    {
                        Dictionary<string, string> values = parameters as Dictionary<string, string>;
                        AProgram program = _component.GetProgram("CIM_MESSAGE_CONFIRM_REPORT");
                        program.ExecuteManual(values);
                    }
                    break;
                case "GLASS_DATA_REQUEST":
                    if (parameters is Dictionary<string, string>)
                    {
                        Dictionary<string, string> values = parameters as Dictionary<string, string>;
                        AProgram program = _component.GetProgram("GLASS_DATA_REQUEST");
                        program.ExecuteManual(values);
                    }

                    break;
                case "GLASS_DATA_MODIFY":
                    if (parameters is Dictionary<string, string>)
                    {
                        Dictionary<string, string> values = parameters as Dictionary<string, string>;
                        AProgram program = _component.GetProgram("GLASS_DATA_CHANGE_REPORT");
                        program.ExecuteManual(values);
                    }
                    break;
                case "JOB_JUDGE_CHANGE":
                    if (parameters is Dictionary<string, string>)
                    {
                        Dictionary<string, string> values = parameters as Dictionary<string, string>;
                        AProgram program = _component.GetProgram("JOB_JUDGE_CHANGE");
                        program.ExecuteManual(values);
                    }
                    break;
                default:
                    break;
            }

            return 0;
        }

        public override int Execute(KeyValuePair<string, string> value)
        {
            _component.ExchangeMode = !_component.ExchangeMode;
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
