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
using SOFD.Global.Manager;
using MainLibrary.Property;
using SOFD.Logger;




namespace YANGSYS.Biz.Programs
{

    public class YANGSYSMessageHandler : AProgram
    {
        private CMain _main = null;
        private bool _enable = false;

        //PROBE
        private CScanControlProperties VI_LOAD_REQUEST = null;
        private CScanControlProperties VI_LOAD_ENABLE = null;
        private CScanControlProperties VI_LOAD_HAND_DOWN_COMPLETION_REPLY = null;
        private CScanControlProperties VI_LOAD_COMPLETE_REPLY = null;
        private CScanControlProperties VI_UNLOAD_REQUEST = null;
        private CScanControlProperties VI_UNLOAD_ENABLE = null;
        private CScanControlProperties VI_UNLOAD_HAND_UP_COMPLETION_REPLY = null;
        private CScanControlProperties VI_UNLOAD_COMPLETE_REPLY = null;
        private CScanControlProperties VI_INITIALIZE_REQUEST = null;
        private CScanControlProperties VI_COMMUNICATION = null;
        private CScanControlProperties VI_ALIVE_REPLY = null;
        private CScanControlProperties VI_STATE_REQUEST_ACK = null;
        private CScanControlProperties VI_STATE_CHANGE_REQ_ACK = null;
        private CScanControlProperties VI_STATE_CHANGE_EVENT = null;
        private CScanControlProperties VI_STAGE_GLASS_EXIST = null;
        private CScanControlProperties VI_USER_LOGIN = null;
        private CScanControlProperties VI_USER_LOGIN_RECIPE = null;
        private CScanControlProperties VI_GLASS_DATA_SEND_ACK = null;
        private CScanControlProperties VI_LOST_GLASS_DATA_REQUEST = null;
        private CScanControlProperties VI_GLASS_SCRAP = null;
        private CScanControlProperties VI_JOB_HOLD_EVENT_REPORT = null;
        private CScanControlProperties VI_ALARM_SET = null;
        private CScanControlProperties VI_ALARM_RESET = null;
        private CScanControlProperties VI_ALARM_SET_REQUEST_REPLY = null;
        private CScanControlProperties VI_RECIPE_LIST_REQ_REPLY = null;
        private CScanControlProperties VI_CURRENT_RECIPE_CHANGE = null;
        private CScanControlProperties VI_RECIPE_REPORT = null;
        private CScanControlProperties VI_BUZZER_REPLY = null;
        private CScanControlProperties VI_GLASS_DATA_VALUE_FILE_REPORT = null;
        private CScanControlProperties VI_IONIZER = null;
        private CScanControlProperties VI_AUTO_MODE_CHANGE_EVENT = null;
        private CScanControlProperties VI_OXR_INFORMATION_UPDATE = null;
        private CScanControlProperties VI_OXR_INFORMATION_REQUEST_DATA_REPLY = null;
        private CScanControlProperties VI_TRACKING_DATA = null;
        private CScanControlProperties VI_TRANSFER_STOP_REPLY = null;
        private CScanControlProperties VI_CIM_MESSAGE_ON = null;
        private CScanControlProperties VI_RECOVERY_GLASS_DATA_SEND_ACK = null;
        private CScanControlProperties VI_SVID_SEND = null;
        private CScanControlProperties VI_MACHINE_MODE_CHANGE_REPORT = null;
        private CScanControlProperties VI_PROCESS_STATUS_SEND = null;
        private CScanControlProperties VI_SHUTTER_STATUS_SEND = null;
        private CScanControlProperties VI_RECIPE_REQUEST_REPLY = null;

        //PROBE CIM
        //private CPLCControlProperties OB_STORED_JOB_REPORT = null;

        //private CPLCControlProperties OW_STORED_DATA_BLOCK = null;
        //private CPLCControlProperties OW_STORED_DATA_UNIT_OR_PORT = null;
        //private CPLCControlProperties OW_STORED_DATA_UNIT_NO = null;
        //private CPLCControlProperties OW_STORED_DATA_SUB_UNIT_NO = null;
        //private CPLCControlProperties OW_STORED_DATA_PORT_NO = null;
        //private CPLCControlProperties OW_STORED_DATA_SLOT_NO = null;

        private const int CIM_MODE_CIM_OFF = 1;
        private const int CIM_MODE_CIM_ON = 2;

        private const int CIM_MODE_ACCEPT = 1;
        private const int CIM_MODE_ALREADY_IN_DESIRED_STATUS = 2;

        private string _controlName = "";
        private CProbeControl _component = null;
        public YANGSYSMessageHandler()
        {
        }

        public override int Init()
        {
            _enable = true;

            VI_LOAD_REQUEST = _main._YANSYS_SCANCONTEROLS.GetProperty(_controlName, "VI_LOAD_REQUEST");
            VI_LOAD_ENABLE = _main._YANSYS_SCANCONTEROLS.GetProperty(_controlName, "VI_LOAD_ENABLE");
            VI_LOAD_HAND_DOWN_COMPLETION_REPLY = _main._YANSYS_SCANCONTEROLS.GetProperty(_controlName, "VI_LOAD_HAND_DOWN_COMPLETION_REPLY");
            VI_LOAD_COMPLETE_REPLY = _main._YANSYS_SCANCONTEROLS.GetProperty(_controlName, "VI_LOAD_COMPLETE_REPLY");
            VI_UNLOAD_REQUEST = _main._YANSYS_SCANCONTEROLS.GetProperty(_controlName, "VI_UNLOAD_REQUEST");
            VI_UNLOAD_ENABLE = _main._YANSYS_SCANCONTEROLS.GetProperty(_controlName, "VI_UNLOAD_ENABLE");
            VI_UNLOAD_HAND_UP_COMPLETION_REPLY = _main._YANSYS_SCANCONTEROLS.GetProperty(_controlName, "VI_UNLOAD_HAND_UP_COMPLETION_REPLY");
            VI_UNLOAD_COMPLETE_REPLY = _main._YANSYS_SCANCONTEROLS.GetProperty(_controlName, "VI_UNLOAD_COMPLETE_REPLY");
            VI_INITIALIZE_REQUEST = _main._YANSYS_SCANCONTEROLS.GetProperty(_controlName, "VI_INITIALIZE_REQUEST");
            VI_COMMUNICATION = _main._YANSYS_SCANCONTEROLS.GetProperty(_controlName, "VI_COMMUNICATION");
            VI_ALIVE_REPLY = _main._YANSYS_SCANCONTEROLS.GetProperty(_controlName, "VI_ALIVE_REPLY");
            VI_STATE_REQUEST_ACK = _main._YANSYS_SCANCONTEROLS.GetProperty(_controlName, "VI_STATE_REQUEST_ACK");
            VI_STATE_CHANGE_REQ_ACK = _main._YANSYS_SCANCONTEROLS.GetProperty(_controlName, "VI_STATE_CHANGE_REQ_ACK");
            VI_STATE_CHANGE_EVENT = _main._YANSYS_SCANCONTEROLS.GetProperty(_controlName, "VI_STATE_CHANGE_EVENT");
            VI_STAGE_GLASS_EXIST = _main._YANSYS_SCANCONTEROLS.GetProperty(_controlName, "VI_STAGE_GLASS_EXIST");
            VI_USER_LOGIN = _main._YANSYS_SCANCONTEROLS.GetProperty(_controlName, "VI_USER_LOGIN");
            VI_USER_LOGIN_RECIPE = _main._YANSYS_SCANCONTEROLS.GetProperty(_controlName, "VI_USER_LOGIN_RECIPE");
            VI_GLASS_DATA_SEND_ACK = _main._YANSYS_SCANCONTEROLS.GetProperty(_controlName, "VI_GLASS_DATA_SEND_ACK");
            VI_LOST_GLASS_DATA_REQUEST = _main._YANSYS_SCANCONTEROLS.GetProperty(_controlName, "VI_LOST_GLASS_DATA_REQUEST");
            VI_GLASS_SCRAP = _main._YANSYS_SCANCONTEROLS.GetProperty(_controlName, "VI_GLASS_SCRAP");
            VI_JOB_HOLD_EVENT_REPORT = _main._YANSYS_SCANCONTEROLS.GetProperty(_controlName, "VI_JOB_HOLD_EVENT_REPORT");
            VI_ALARM_SET = _main._YANSYS_SCANCONTEROLS.GetProperty(_controlName, "VI_ALARM_SET");
            VI_ALARM_RESET = _main._YANSYS_SCANCONTEROLS.GetProperty(_controlName, "VI_ALARM_RESET");
            VI_ALARM_SET_REQUEST_REPLY = _main._YANSYS_SCANCONTEROLS.GetProperty(_controlName, "VI_ALARM_SET_REQUEST_REPLY");
            VI_RECIPE_LIST_REQ_REPLY = _main._YANSYS_SCANCONTEROLS.GetProperty(_controlName, "VI_RECIPE_LIST_REQ_REPLY");
            VI_CURRENT_RECIPE_CHANGE = _main._YANSYS_SCANCONTEROLS.GetProperty(_controlName, "VI_CURRENT_RECIPE_CHANGE");
            VI_RECIPE_REPORT = _main._YANSYS_SCANCONTEROLS.GetProperty(_controlName, "VI_RECIPE_REPORT");
            VI_BUZZER_REPLY = _main._YANSYS_SCANCONTEROLS.GetProperty(_controlName, "VI_BUZZER_REPLY");
            VI_GLASS_DATA_VALUE_FILE_REPORT = _main._YANSYS_SCANCONTEROLS.GetProperty(_controlName, "VI_GLASS_DATA_VALUE_FILE_REPORT");
            VI_IONIZER = _main._YANSYS_SCANCONTEROLS.GetProperty(_controlName, "VI_IONIZER");
            VI_AUTO_MODE_CHANGE_EVENT = _main._YANSYS_SCANCONTEROLS.GetProperty(_controlName, "VI_AUTO_MODE_CHANGE_EVENT");
            VI_OXR_INFORMATION_UPDATE = _main._YANSYS_SCANCONTEROLS.GetProperty(_controlName, "VI_OXR_INFORMATION_UPDATE");
            VI_OXR_INFORMATION_REQUEST_DATA_REPLY = _main._YANSYS_SCANCONTEROLS.GetProperty(_controlName, "VI_OXR_INFORMATION_REQUEST_DATA_REPLY");
            VI_TRACKING_DATA = _main._YANSYS_SCANCONTEROLS.GetProperty(_controlName, "VI_TRACKING_DATA");
            VI_TRANSFER_STOP_REPLY = _main._YANSYS_SCANCONTEROLS.GetProperty(_controlName, "VI_TRANSFER_STOP_REPLY");
            VI_CIM_MESSAGE_ON = _main._YANSYS_SCANCONTEROLS.GetProperty(_controlName, "VI_CIM_MESSAGE_ON");
            VI_RECOVERY_GLASS_DATA_SEND_ACK = _main._YANSYS_SCANCONTEROLS.GetProperty(_controlName, "VI_RECOVERY_GLASS_DATA_SEND_ACK");
            VI_SVID_SEND = _main._YANSYS_SCANCONTEROLS.GetProperty(_controlName, "VI_SVID_SEND");
            VI_MACHINE_MODE_CHANGE_REPORT = _main._YANSYS_SCANCONTEROLS.GetProperty(_controlName, "VI_MACHINE_MODE_CHANGE_REPORT");
            VI_PROCESS_STATUS_SEND = _main._YANSYS_SCANCONTEROLS.GetProperty(_controlName, "VI_PROCESS_STATUS_SEND");
            VI_SHUTTER_STATUS_SEND = _main._YANSYS_SCANCONTEROLS.GetProperty(_controlName, "VI_SHUTTER_STATUS_SEND");
            VI_RECIPE_REQUEST_REPLY = _main._YANSYS_SCANCONTEROLS.GetProperty(_controlName, "VI_RECIPE_REQUEST_REPLY");

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
            get { return "YANGSYS_MESSAGE_HANDLER"; }
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
            get { return false; }
        }

        public override int ExecuteManual(Dictionary<string, string> values)
        {
            _values = values;
            if (_values.ContainsKey("COMMAND_NAME"))
            {

                string name = _values["COMMAND_NAME"];
                switch (name)
                {
                    case "BUZZER":
                        if (_values.ContainsKey("COMMAND"))
                        {
                            string command = _values["COMMAND"];

                            List<string> dataList = new List<string>();
                            dataList.Add(name);
                            dataList.Add(command);
                            _main.SendData(dataList);
                        }
                        break;
                    case "ALARM_SET_REQUEST":
                        if (_values.ContainsKey("COMMAND"))
                        {
                            string command = _values["COMMAND"];
                            string value = _values["ALARM_CODE"];
                            List<string> dataList = new List<string>();
                            dataList.Add(name);
                            dataList.Add(command);
                            dataList.Add(value);
                            _main.SendData(dataList);
                        }
                        break;
                    case "LINK_SIGNAL_INIT":

                        List<string> dataList2 = new List<string>();
                        dataList2.Add("ABNORMAL_INTERFACE");
                        _main.SendData(dataList2);

                        _main.GetProgram("LINK_SIGNAL_TYPE2").ExecuteManual(values);
                        _main.GetProgram("LINK_SIGNAL_TYPE6").ExecuteManual(values);
                        _main.GetProgram("LINK_SIGNAL_TYPE11").ExecuteManual(values);
                        break;
                    default:
                        return -2;
                }
                return 0;
            }

            return -1;
        }

        public const int UNIT = 1;
        public const int PORT = 2;

        protected override int InnerExecute()
        {
            if (_component.vi_auto_mode_change_event)
            {
                _component.vi_auto_mode_change_event = false;
                this.Reply("AUTO_MODE_CHANGE_EVENT_REPLY");
                string value = VI_AUTO_MODE_CHANGE_EVENT.Value;
                string[] temp = value.Split('|');
                
                if(temp != null && temp.Length == 2)
                    _component.MachineAutoMode = temp[1] == "2";

                if (_component.MachineAutoMode != true)
                {
                    _component.LoadRequest = false;
                    //_component.LoadEnable = false;
                    _component.UnloadRequest = false;
                    //_component.UnloadEnable = false;
                    //Dictionary<string, string> values0 = new Dictionary<string, string>();
                    //values0.Add("COMMAND_NAME", "LINK_SIGNAL_INIT");
                    //values0.Add("COMMAND", "0");

                    //_main.GetProgram("LINK_SIGNAL_TYPE2").ExecuteManual(values0);
                    //_main.GetProgram("LINK_SIGNAL_TYPE6").ExecuteManual(values0);
                    //_main.GetProgram("LINK_SIGNAL_TYPE11").ExecuteManual(values0);
                }
            }

            if (_component.vi_load_request)
            {
                _component.vi_load_request = false;
                this.Reply("LOAD_REQUEST_REPLY");

                if (_component.AbnormalSEQ)
                {
                    _component.WaitLoadRequest = true;
                    _component.WaitUnloadRequest = false;
                }
                else
                {
                    _component.LoadRequest = true;

                    CSubject subject = CUIManager.Inst.GetData("ucEQP");
                    subject.SetValue("LRSTATUS", _component.LoadRequest);
                    subject.Notify();
                }
            }

            if (_component.vi_load_enable)
            {
                _component.vi_load_enable = false;
                _component.LoadEnable = true;
                this.Reply("LOAD_ENABLE_REPLY");
                CSubject subject = CUIManager.Inst.GetData("ucEQP");
                subject.SetValue("LR_ENABLE", _component.LoadEnable);
                subject.Notify();
            }

            if (_component.vi_load_hand_down_completion_reply)
            {
                _component.vi_load_hand_down_completion_reply = false;

                _component.LoadHandDownCompletionReply = true;
            }
            
            if (_component.vi_load_complete_reply)
            {
                _component.vi_load_complete_reply = false;
            }

            if (_component.vi_unload_request)
            {
                _component.vi_unload_request = false;
                this.Reply("UNLOAD_REQUEST_REPLY");

                if (_component.AbnormalSEQ)
                {
                    _component.WaitUnloadRequest = true;
                    _component.WaitLoadRequest = false;
                }
                else
                {
                    _component.UnloadRequest = true;

                    CSubject subject = CUIManager.Inst.GetData("ucEQP");
                    subject.SetValue("URSTATUS", _component.UnloadRequest);
                    subject.Notify();
                }
            } 

            if (_component.vi_unload_enable)
            {
                _component.vi_unload_enable = false;
                this.Reply("UNLOAD_ENABLE_REPLY");
                _component.UnloadEnable = true;
                CSubject subject = CUIManager.Inst.GetData("ucEQP");
                subject.SetValue("UR_ENABLE", _component.UnloadEnable);
                subject.Notify();
            }

            if (_component.vi_unload_hand_up_completion_reply)
            {
                _component.vi_unload_hand_up_completion_reply = false;

                _component.UnloadHandDownCompletionReply = true;
            }
            
            if (_component.vi_unload_complete_reply)
            {
                _component.vi_unload_complete_reply = false;
            }

            if (_component.vi_initialize_request) //ABNORMAL_INTERFACE 이것을 보내면 장비가 stop 후 전송 되는 메시지
            {
                _component.vi_initialize_request = false;                

                if (_component.StartLoadSEQ || _component.StartUnLoadSEQ || _component.StartExchangeSEQ)
                {
                    _component.InitialiazeRequest = true;
                }
                else
                {
                    _component.InitialiazeRequest = false;
                }
                //_component.UnloadRequest = false;
                //_main.MelsecNetBitOnOff(_main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_SEND_ABLE"), false);
                //_main.MelsecNetBitOnOff(_main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_SEND_START"), false);
                //_main.MelsecNetBitOnOff(_main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_SEND_COMPLETE"), false);
            }

            if (_component.vi_communication)
            {
                _component.vi_communication = false;
                
                string value = VI_COMMUNICATION.Value;
                string[] temp = value.Split('|');
                string arg1 = "";
                if (temp != null && temp.Length == 2)
                    arg1 = temp[1];//0,X

                _component.Communication = arg1 == "O";
                _component.Alive = true;// 최초 1회만 다음은 주기적으로
                this.Reply(new List<string>{"COMMUNICATION_ACK",arg1}, true);

                if (arg1 == "O")
                {
                    List<string> dataList = new List<string>();
                    dataList.Add("CIM_MODE");
                    dataList.Add(_component.CIMMode == 2 ? "1" : "2");

                    _main.SendData(dataList);

                    _main.SendData(new List<string> { "RECIPE_LIST_REQ" }); //20161123
                }
                else
                {
                    _main.Client_ReStart();
                }

                _main.SystemConfig.YANG_Communi = _component.Communication;

            }

            if (_component.vi_alive_reply)
            {
                _component.vi_alive_reply = false;
                _component.Alive = true;
            }

            if (_component.vi_state_req_ack)
            {
                _component.vi_state_req_ack = false;
                string value = VI_STATE_REQUEST_ACK.Value;
                string[] temp = value.Split('|');
                string arg1 = "";
                string arg2 = "";
                if (temp != null && temp.Length == 3)
                {
                    arg1 = temp[1];//WHTM 1 : IDLE, 2 : RUN, 3 : DOWN, 4 : PM, 5 : STOP
                    arg2 = temp[2];

                    _component.EqpStatus = int.Parse(arg1);
                    _component.AlarmStatus = int.Parse(arg2);
                }
                else
                {
                    throw new NotImplementedException();
                }
                //data.Add(1, "Idle");
                //data.Add(2, "Run");
                //data.Add(3, "Down");
                //data.Add(4, "PM");
                //data.Add(5, "STOP");


                
            }

            if (_component.vi_state_change_req_ack)
            {
                _component.vi_state_change_req_ack = false;
            }

            if (_component.vi_state_change_event)
            {
                _component.vi_state_change_event = false;
                this.Reply("STATE_CHANGE_EVENT_REPLY");
                string value = VI_STATE_CHANGE_EVENT.Value;
                string[] temp = value.Split('|');
                if (temp != null && temp.Length == 2)
                {
                    int arg1 = 0;
                    int.TryParse(temp[1], out arg1);

                    _component.EqpStatus = arg1;

                    //int arg2 = 0;
                    //int.TryParse(temp[2], out arg2);

                    //_component.ResonCode = arg2;
                }
                else
                {
                    throw new NotImplementedException();
                }
                CSubject subject = CUIManager.Inst.GetData("ucCimStatus");
                subject.SetValue("Status", _component.EqpStatus.ToString());
                subject.Notify();

                subject = CUIManager.Inst.GetData("ucEQP");
                subject.SetValue("EQPSTATUS", _component.EqpStatus.ToString());
                subject.Notify();
            }

            if (_component.vi_stage_glass_exist)
            {
                _component.vi_stage_glass_exist = false;
                this.Reply("STAGE_GLASS_EXIST_REPLY");
                string value = VI_STAGE_GLASS_EXIST.Value;
                string[] temp = value.Split('|');

                if (temp != null && temp.Length == 2)
                {
                    _component.GlassStageExist = temp[1] == "O";
                }
                else
                {
                    throw new NotImplementedException();
                }

                _component.GetProgram("DATA_INFORMATION_REPORT_BY_LOCATION").Execute();
                

                CSubject subject = CUIManager.Inst.GetData("ucEQP");
                //subject.SetValue("HalfSIzeType", false);
                subject.SetValue("GlassStageExist", _component.GlassStageExist);
                //subject.SetValue("GlassCode1", _component.GlassCode1.ToString());
                subject.Notify();
            }

            if (_component.vi_user_login)
            {
                _component.vi_user_login = false;
                this.Reply("USER_LOGIN_REPLY");
                string value = VI_USER_LOGIN.Value;
                string[] temp = value.Split('|');

                if (temp != null && temp.Length == 3)
                {
                    _main.SystemConfig.UserAccount = temp[1];
                    _main.SystemConfig.UserPassword = temp[2];
                }

                CSubject subject = CUIManager.Inst.GetData("ucTitle");
                subject.SetValue("UserName", temp[1]);
                subject.Notify();
            }

            if (_component.vi_user_login_recipe)
            {
                _component.vi_user_login_recipe = false;
            }

            if(_component.vi_glass_data_send_ack)
            {
                _component.vi_glass_data_send_ack = false;

                _component.HostPPID_Value = "";
            }

            if (_component.vi_lost_glass_data_request)
            {
                _component.vi_lost_glass_data_request = false;

                //string value = VI_LOST_GLASS_DATA_REQUEST.Value;
                //string[] temp = value.Split('|');
                //string arg1 = "";
                //string arg2 = "";

                //if (temp != null && temp.Length == 2)
                //{
                //    switch (temp[1])//P : CST Seq No & JOB Seq No에 의한 요청    I : Glass ID 에 의한 요청
                //    {
                //        case "P":
                //            break;
                //        case "I":
                //            break;
                //        default:
                //            break;
                //    }
                //}

                //string CST_SEQ_NO = "";
                //string JOB_SEQ_NO = "";
                //string GLASS_ID = "";
                //string RECIPE_ID = "";

                //AMaterialData material = null;
                //arg1 = _main.Materials.IsExistMaterialDataBy(_component.GlassCode1, out material) ? "O" : "X";
                //CGlassDataProperties glassData = material as CGlassDataProperties;
                //arg2 = string.Format("{0},{1},{2},{3}", CST_SEQ_NO, JOB_SEQ_NO, GLASS_ID, RECIPE_ID);

                //this.Reply("LOST_GLASS_DATA_REQUEST_ACK", arg1, arg2);
            }

            if (_component.vi_glass_scrap)
            {
                _component.vi_glass_scrap = false;


                string[] temp = VI_GLASS_SCRAP.Value.Split('|');
                if (temp.Length != 3)
                    return -1;


                Dictionary<string, string> values = new Dictionary<string, string>();
                values.Add("GLASSID", temp[1]);
                values.Add("SCRAPCODE", temp[2]);
                _component.GetProgram("REMOVED_JOB_REPORT").ExecuteManual(values);



                //this.Reply("GLASS_SCRAP_ACK");

                //string value = VI_GLASS_SCRAP.Value;
                //string[] temp = value.Split('|');
                //string glassId = "";
                //string flag = "";//( FLAG 1 : Normal Remove, 3 : Dirty Data Delete )
                //string reason = "";

                //if (temp != null && temp.Length == 3)
                //{
                //    glassId = temp[1];
                //    string[] splitedData2 = temp[2].Split(',');
                //    if (splitedData2.Length > 1)
                //    {
                //        flag = splitedData2[0].Trim();
                //        reason = splitedData2[1].Trim();
                //    }

                //    _component.GetProgram("SCRAP_JOB_REPORT").Execute();
                //}
                //else
                //{
                //    Log(string.Format("{0}\t{1}", _component.ControlName, "GLASS_SCRAP message struct error =" + value));
                //}
            }

            if (_component.vi_job_hold_event_report)//운영 미정
            {
                _component.vi_job_hold_event_report = false;
                this.Reply("JOB_HOLD_EVENT_REPORT_ACK");

            }

            if (_component.vi_alarm_set)
            {
                _component.vi_alarm_set = false;

                this.Reply("ALARM_SET_REPLY");

                string value = VI_ALARM_SET.Value;
                string[] temp = value.Split('|');
                string alSetReset = "";
                string allv = "";
                string alid = "";
                string altx = "";
                string alcd = "";

                if (temp != null && temp.Length == 3)
                {
                    alSetReset = temp[1];
                    string[] temp2 = temp[2].Split(',');
                    if (temp2.Length == 4)
                    {
                        allv = temp2[0];
                        alcd = temp2[1];
                        alid = temp2[2];
                        altx = temp2[3];

                        //////List<CProgramData> data = _component.GetProgram("ALARM_SET_STATUS_REPORT").GetProgramData();

                        ////////_component.GetProgram("ALARM_SET_STATUS_REPORT").Execute();


                        //////data[0].Value = alSetReset;
                        //////data[1].Value = 1;
                        //////data[2].Value = alid;
                        //////data[3].Value = alcd;
                        //////data[4].Value = allv;
                        //////data[5].Value = 1;
                        //////data[6].Value = altx;
                        //////data[7].Value = DateTime.Now.ToString("yyMMddhhmmss");
                        //////_main.SetAlarm(_component, DateTime.Now, alid, altx);

                        if (alSetReset == "1")
                        {
                            List<CProgramData> data = _component.GetProgram("ALARM_SET_STATUS_REPORT").GetProgramData();

                            //_component.GetProgram("ALARM_SET_STATUS_REPORT").Execute();


                            data[0].Value = alSetReset;
                            data[1].Value = 1;
                            data[2].Value = alid;
                            data[3].Value = alcd;
                            data[4].Value = allv;
                            data[5].Value = 1;
                            data[6].Value = altx;
                            data[7].Value = DateTime.Now.ToString("yyMMddhhmmss");
                            _main.SetAlarm(_component, DateTime.Now, alid, altx);
                        }
                        else if (alSetReset == "0")
                        {
                            List<CProgramData> data = _component.GetProgram("ALARM_RESET_STATUS_REPORT").GetProgramData();


                            data[0].Value = alSetReset;
                            data[1].Value = 1;
                            data[2].Value = alid;
                            data[3].Value = alcd;
                            data[4].Value = allv;
                            data[5].Value = 1;
                            data[6].Value = altx;
                            data[7].Value = DateTime.Now.ToString("yyMMddhhmmss");


                            _main.ResetAlarm(_component, alid, altx);

                           // _component.GetProgram("ALARM_RESET_STATUS_REPORT").Execute();
                        }
                    }
                    else
                    {
                        _main.SetAlarm(_component, DateTime.Now, "0", "Message Format Error =" + value);
                        Log(string.Format("{0}\t{1}", _component.ControlName, "Set Alarm message struct error =" + value));
                    }
                }
                else
                {
                    _main.SetAlarm(_component, DateTime.Now, "0", "Message Format Error =" + value);
                    Log(string.Format("{0}\t{1}", _component.ControlName, "Set Alarm message struct error =" + value));
                }

                //string value = VI_ALARM_SET.Value;
                //string[] temp = value.Split('|');
                //string alid = "";
                //string altx = "";

                //if (temp != null && temp.Length == 3)
                //{

                //    _component.LastAlarmCode = temp[1];
                //    _component.LastAlarmText = temp[2];
                //    alid = temp[1];
                //    altx = temp[2];
                //    //_main.SetAlarm(_component, DateTime.Now, alid, altx);
                //}
                //else
                //{
                //    _main.SetAlarm(_component, DateTime.Now, "0", "Message Format Error =" + value);
                //    Log(string.Format("{0}\t{1}", _component.ControlName, "Set Alarm message struct error =" + value));
                //}
            }

            if (_component.vi_alarm_reset)
            {
                _component.vi_alarm_reset = false;

                this.Reply("ALARM_RESET_REPLY");

                string value = VI_ALARM_RESET.Value;
                string[] temp = value.Split('|');
                string alid = "";
                string altx = "";

                if (temp != null && temp.Length == 3)
                {
                    alid = temp[1];
                    altx = temp[2];
                    //_main.ResetAlarm(_component, alid, altx);
                }
                else
                {
                    Log(string.Format("{0}\t{1}", _component.ControlName, "Reset Alarm message struct error =" + value));
                }

            }

            if (_component.vi_alarm_set_request_reply)
            {
                _component.vi_alarm_set_request_reply = false;
            }

            if (_component.vi_recipe_list_req_reply)
            {
                _component.vi_recipe_list_req_reply = false;

                string value = VI_RECIPE_LIST_REQ_REPLY.Value;
                string[] temp = value.Split('|');
                int count = 0;

                if (temp != null && temp.Length == 3)
                {
                    count = int.Parse(temp[1]);
                    string[] splitedRecipe = temp[2].Split(',');

                    _component.RecipeList = temp[2];
                    SortedList<int, string> sortedRecipeList = new SortedList<int, string>();
                    foreach (string item in splitedRecipe)
                    {
                        if (string.IsNullOrEmpty(item))
                            continue;

                        bool falg = false;
                        int recipeNo = 0;
                        falg = int.TryParse(item, out recipeNo);

                        if (falg)
                        {
                            sortedRecipeList.Add(recipeNo, item);
                        }
                        else
                        {
                            count = count - 1;
                        }
                    }

                    //for (int i = 0; i < 1000; i++)
                    //{
                    //    bool mFlag = temp[2].Substring(i, 1) == "1" ? true : false;
                    //    if (mFlag == true)
                    //    {
                    //        sortedRecipeList.Add(i, temp[2].Substring(i, 1));
                    //    }
                    //}



                    if (sortedRecipeList.Count == count)
                    {
                        CSubject subject = CUIManager.Inst.GetData("ucRecipeStatus");
                        subject.SetValue("RecipeList", sortedRecipeList);
                        subject.Notify();

                        subject = CUIManager.Inst.GetData("UpdateRecipeList");
                        subject.SetValue("RecipeList", sortedRecipeList);
                        subject.Notify();
                    }
                    else
                    {
                        //알람 발생 여부 확인.
                    }

                }
                else
                {
                    Log(string.Format("{0}\t{1}", _component.ControlName, "Reset Alarm message struct error =" + value));
                }

                //CGlassDataPropertiesWHTM glassData1 = null;
                //CGlassDataPropertiesWHTM glassData2 = null;
                //AMaterialData materialData1 = null;
                //AMaterialData materialData2 = null;
                //materialData1 = _main.GetReceivedGlassDataByLoc(_component.ControlName, 0);
                //glassData1 = materialData1 as CGlassDataPropertiesWHTM;
                //materialData2 = _main.GetReceivedGlassDataByLoc(_component.ControlName, 1);
                //glassData2 = materialData2 as CGlassDataPropertiesWHTM;

                //if (glassData1 == null)
                //    glassData1 = new CGlassDataPropertiesWHTM();

                //if (glassData2 == null)
                //    glassData2 = new CGlassDataPropertiesWHTM();

                //_main.SendData(new List<string> { "GLASS_DATA_SEND", glassData1.GlassID != "" || glassData2.GlassID != "" ? "O" : "X", string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19}", glassData1.PortNo, glassData1.SeqNo, glassData1.GlassPosition, glassData1.SlotNo, glassData1.GlassID, glassData1.LotID, _main.getRecipeId(glassData1.PPID), glassData1.OperationId, glassData1.ProductId, glassData1.CassetteId, glassData2.PortNo, glassData2.SeqNo, glassData2.GlassPosition, glassData2.SlotNo, glassData2.GlassID, glassData2.LotID, _main.getRecipeId(glassData2.PPID), glassData2.OperationId, glassData2.ProductId, glassData2.CassetteId) });

            }

            if (_component.vi_shutter_Status_send)
            {
                _component.vi_shutter_Status_send = false;

                string value = VI_SHUTTER_STATUS_SEND.Value;
                string[] temp = value.Split('|');

                if (temp != null && temp.Length == 2)
                {
                    _component.EQP_Shutter_Open = int.Parse(temp[1]) == 1 ? true : false;
                }

            }

            if (_component.vi_recipe_request_reply)
            {
                //_component.vi_recipe_request_reply = false;

               
            }

            if (_component.vi_current_recipe_change)
            {
                _component.vi_current_recipe_change = false;
                this.Reply("CURRENT_RECIPE_CHANGE_ACK");

                string value = VI_CURRENT_RECIPE_CHANGE.Value;
                string[] temp = value.Split('|');

                if (temp != null && temp.Length == 3)
                {
                    if (int.Parse(_component.CurrentRecipeNo) != int.Parse(temp[2].Trim()))
                    {
                        _component.CurrentPPID = _main.getPPID(temp[2].Trim());
                        _component.CurrentRecipeNo = temp[2].Trim();

                        _main.Saved_Current_PPID = _component.CurrentPPID;
                        _main.Saved_Current_RecipeID = _component.CurrentRecipeNo;

                        _component.GetProgram("CURRENT_PPID_RECIPE_REPORT").Execute();
                    }
                }

                CSubject subject = CUIManager.Inst.GetData("ucEQP");
                subject.SetValue("RECIPE", _component.CurrentRecipeNo);
                subject.Notify();

                subject = CUIManager.Inst.GetData("ucCimStatus");
                subject.SetValue("CurrentPPID", _component.CurrentPPID);
                subject.SetValue("CurrentRecipeID", _component.CurrentRecipeNo);
                subject.Notify();
            }

            if (_component.vi_machine_mode_change_report)
            {
                _component.vi_machine_mode_change_report = false;

                this.Reply("MACHINE_MODE_CHANGE_REPORT_REPLY");

                string value = VI_MACHINE_MODE_CHANGE_REPORT.Value;
                string[] temp = value.Split('|');

                if (temp != null && temp.Length == 2)
                {
                    int eqpMode = 0;
                    int.TryParse(temp[1], out eqpMode);
                    _component.EquipmentMode = eqpMode;
                }
            }

            if (_component.vi_recipe_report)
            {
                _component.vi_recipe_report = false;
                this.Reply("RECIPE_REPORT_ACK", "O");

                //_main.SendData(new List<string> { "RECIPE_LIST_REQ" });
                //string value = VI_CURRENT_RECIPE_CHANGE.Value;
                //string[] temp = value.Split('|');

                //string arg1 = "";
                //string arg2 = "";
                //if (temp != null && temp.Length == 3)
                //{
                //    arg1 = temp[1];//C,M,D
                //    arg2 = temp[2];//PPID, VersionNo(YYMMDDHHNNSS)
                //}
            }

            if (_component.vi_buzzer_reply)
            {
                _component.vi_buzzer_reply = false;// 0 : Buzzer OFF, 1,2,3 : 해당 부터 ON

                
            }
            if (_component.vi_glass_data_value_file_report)
            {
                _component.vi_glass_data_value_file_report = false;

                this.Reply("GLASS_DATA_VALUE_FILE_REPORT_ACK");

                string value = VI_GLASS_DATA_VALUE_FILE_REPORT.Value;
                string[] temp = value.Split('|');

                if (temp != null && temp.Length == 3)
                {
                    if (temp[2] == "A")
                    {
                        _component.glass_data_value_file_A = temp[1];

                        //Dictionary<string, string> values = new Dictionary<string, string>();

                        //values.Clear();
                        //values.Add("GLS_INDEX", "1");
                        //values.Add("FILE_PATH", _component.glass_data_value_file_A);
                        //_component.GetProgram("PROCESS_DATA_REPORT").ExecuteManual(values);
                    }
                    else
                    {
                        _component.glass_data_value_file_B = temp[1];
                    }

                }
            }

            if (_component.vi_ionizer)
            {
                _component.vi_ionizer = false;

                this.Reply("IONIZER_ACK");

                string value = VI_IONIZER.Value;
                string[] temp = value.Split('|');

                if (temp != null && temp.Length == 3)
                {
                    string[] splitedData = temp[2].Split(',');//ION1,ION2,ION3  Ionizer 상태 보고 ( 0 : OFF 또는 1 : ON ) 
                }
            }

            //if (_component.vi_auto_mode_change_event)
            //{
            //    _component.vi_auto_mode_change_event = false;
            //    this.Reply("AUTO_MODE_CHANGE_EVENT_REPLY");

            //    string value = VI_AUTO_MODE_CHANGE_EVENT.Value;
            //    string[] temp = value.Split('|');

            //    string arg1 = "";

            //    if (temp != null && temp.Length == 2)
            //    {
            //        arg1 = temp[1];// 1 : Manual Mode, 2 : Auto Mode   CIM에 Operation Mode를 전송한다.
            //    }
            //}

            if (_component.vi_oxr_information_update)
            {
                _component.vi_oxr_information_update = false;
                this.Reply("OXR_INFORMATION_UPDATE_REPLY");

                string value = VI_OXR_INFORMATION_UPDATE.Value;
                string[] temp = value.Split('|');

                if (temp != null && temp.Length == 2)
                {
                    string[] splited = temp[1].Split(','); //OXR 정보1, OXR정보2………….		 1200개의 OXR 변경 정보 전송
                }              

            }

            if (_component.vi_oxr_information_request_data_reply)
            {
                _component.vi_oxr_information_request_data_reply = false; //OXR 정보1, OXR정보2………….		 BC로 부터 전송 받은 1200개의 OXR 변경 정보 EQP로 전송
            }

            if (_component.vi_tracking_data)
            {
                _component.vi_tracking_data = false; 
                this.Reply("TRACKING_DATA_REPLY");

                string value = VI_TRACKING_DATA.Value;
                string[] temp = value.Split('|');
                string glassA = "";
                string glassB = "";
                if (temp != null && temp.Length == 3)
                {
                    glassA = temp[1];//1 or 2 or 3		 1 : Processed In EQ, 2 : Abnormal Processed In EQ, 3 : Skip
                    glassB = temp[2];
                }
                _component.Glass_Tracking_DataA = int.Parse(glassA);
                _component.Glass_Tracking_DataB = int.Parse(glassB);
            }

            if (_component.vi_transfer_stop_reply)
            {
                _component.vi_transfer_stop_reply = false; // 1 : Transfer Stop, 2 : Transfer Resume

                string value = VI_TRANSFER_STOP_REPLY.Value;
                string[] temp = value.Split('|');
                string arg1 = "";

                if (temp != null && temp.Length == 2)
                {
                    arg1 = temp[1];// O or X		 O : Transfer Stop/Resume 가능, X : Transer Stop/Resume 불가능
                }
            }

            if (_component.vi_cim_message_on_reply)
            {
                _component.vi_cim_message_on_reply = false;
                //this.Reply("CIM_MESSAGE_ON_REPLY");
                //string value = VI_CIM_MESSAGE_ON.Value;
                //string[] temp = value.Split('|');
                //string arg1 = "";

                //if (temp != null && temp.Length == 2)
                //{
                //    arg1 = temp[1];// O or X		 O : CIM Message 발생, X : CIM Message All Clear
                //}
            }

            if (_component.vi_recovery_glass_data_send_ack)
            {
                _component.vi_recovery_glass_data_send_ack = false;//O	"CST_SEQ_NO,JOB_SEQ_NO,GLASS_ID,RECIPE_ID"	 Remove or Delete 했던 Glass Data 복구 후 정보 전송


            }
            
            //DEFECT는 방향이 없음.확인이 필요

            if (_component.vi_svid_send)
            {
                _component.vi_svid_send = false;

                this.Reply("SVID_SEND_REPLY");
                string value = VI_SVID_SEND.Value;
                string[] temp = value.Split('|');
                string arg1 = "";

                if (temp != null && temp.Length == 3)
                {
                    arg1 = temp[1];//Count	data1,data2,data3	 EQP 에서 보고하는 전체 Svid List를 응답한다. COUNT 는 '0'~'9999' 를 스트링 데이터 형태로 전송하며, SVID의 데이터는 Comma로 구분하여 전송
                    string[] splited = temp[2].Split(',');

                }
            }

            if (_component.vi_cvid_send)
            {
                _component.vi_cvid_send = false;

                this.Reply("CVID_SEND_REPLY");
            }

            if (_component.vi_cvid_report_time_change_ack)
            {
                _component.vi_cvid_report_time_change_ack = false;
            }

            if (_component.vi_process_status_send)
            {
                _component.vi_process_status_send = false;

                this.Reply("PROCESS_STATUS_SEND_REPLY");

                string value = VI_PROCESS_STATUS_SEND.Value;
                string[] temp = value.Split('|');
                string statusA = "";
                string statusB = "";
                Dictionary<string, string> values = new Dictionary<string, string>();
                if (temp != null && temp.Length == 3)
                {
                    statusA = temp[1].Trim();  //Process 상태를 표시합니다. 1 : Process Start, 2 : Process End
                    statusB = temp[2].Trim();

                    if (statusA != "")
                    {
                        if (statusA == "1")
                        {
                            values.Clear();
                            values.Add("GLS_INDEX", "0");
                            values.Add("TRANS_STATE", "2");
                            _main.Set_Process_Start_Time(0, DateTime.Now);
                        }
                        else
                        {
                            values.Clear();
                            values.Add("GLS_INDEX", "0");
                            values.Add("TRANS_STATE", "3");
                            _main.Set_Process_End_Time(0, DateTime.Now);
                        }

                        _component.GetProgram("TRACKING_JOB_REPORT").ExecuteManual(values);
                    }


                    if (statusB != "")
                    {
                        if (statusB == "1")
                        {
                            values.Clear();
                            values.Add("GLS_INDEX", "1");
                            values.Add("TRANS_STATE", "2");
                            _main.Set_Process_Start_Time(1, DateTime.Now);
                        }
                        else
                        {
                            values.Clear();
                            values.Add("GLS_INDEX", "1");
                            values.Add("TRANS_STATE", "3");
                            _main.Set_Process_End_Time(1, DateTime.Now);
                        }

                        _component.GetProgram("TRACKING_JOB_REPORT").ExecuteManual(values);
                    }

                   
                }

            }

            if (_component.vi_recipe_change_report)
            {
                _component.vi_recipe_change_report = false;
                this.Reply("RECIPE_CHANGE_REPORT_ACK", "O");

                _main.SendData(new List<string> { "RECIPE_LIST_REQ" });
                //string value = VI_CURRENT_RECIPE_CHANGE.Value;
                //string[] temp = value.Split('|');

                //string arg1 = "";
                //string arg2 = "";
                //if (temp != null && temp.Length == 3)
                //{
                //    arg1 = temp[1];//C,M,D
                //    arg2 = temp[2];//PPID, VersionNo(YYMMDDHHNNSS)
                //}
            }

            if (_component.vi_cim_mode_reply)
            {
                _component.vi_cim_mode_reply = false;
            }

            return 0;
        }

        public void Reply(string message)
        {
            int iRet = this.Reply(new List<string>() { message });
        }
        public void Reply(string message, string value1)
        {
            int iRet = this.Reply(new List<string>() { message, value1 });
        }

        public void Reply(string message, string value1, string value2)
        {
            int iRet = this.Reply(new List<string>() { message, value1, value2 });
        }

        public int Reply(List<string> values)
        {
            return Reply(values, false);
        }

        /// <summary>
        /// _component.Communication 상태를 확인하지 않을 수 있음.
        /// </summary>
        /// <param name="values"></param>
        /// <param name="force"></param>
        /// <returns></returns>
        public int Reply(List<string> values, bool force)
        {
            //if (_component.Communication || force)
            if (_main.Driver.GetStatus() == "Connected" || force)
            {
                return _main.SendData(values);
            }
            else
            {
                return -1;
            }
        }
    }
}
