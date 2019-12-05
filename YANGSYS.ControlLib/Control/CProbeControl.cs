using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOFD.Component;
using SOFD.Logger;

using YANGSYS.ControlLib.LogFormat;
using SOFD.Component.Interface;
using System.Drawing;

namespace YANGSYS.ControlLib
{
    public partial class CProbeControl : CBasicControl
    {
        public bool ib_received_job_report_reply_upstream_path1 { get; set; }
        public bool ib_sent_out_job_report_reply_downstream_path1 { get; set; }
        public bool ib_scrap_job_report_reply { get; set; }
        public bool ib_stored_job_report_reply { get; set; }
        public bool ib_fetched_out_job_report_reply { get; set; }
        public bool ib_glass_data_change_report_reply { get; set; }
        public bool ib_glass_process_start_report_reply { get; set; }
        public bool ib_glass_process_end_report_reply { get; set; }
        public bool ib_machine_recipe_request_confirm { get; set; }
        public bool ib_machine_status_change_report_reply { get; set; }
        public bool ib_recipe_parameter_request { get; set; }
        public bool ib_recipe_parameter_download { get; set; }
        public bool ib_cim_message_set_command { get; set; }
        public bool ib_cim_message_clear_command { get; set; }
        public bool ib_machine_time_set_command { get; set; }
        public bool ib_cim_mode_change_command { get; set; }
        public bool ib_cv_report_time_change_command { get; set; }
        public bool ib_glass_judge_result_request_confirm { get; set; }
        public bool ib_glass_judge_result_report_reply { get; set; }
        public bool ib_glass_data_request_confirm { get; set; }
        public bool ib_machine_mode_change_command { get; set; }
        public bool ib_loading_stop_request_reply_cim { get; set; }
        public bool ib_loading_stop_release_reply_cim { get; set; }

        public bool ib_terminal_text { get; set; }
        public bool ib_operator_call { get; set; }
        public bool ib_ld_buzz_on { get; set; }
        public bool ib_date_time_set { get; set; }
        public bool ib_ppid_recipe_id_map_change { get; set; }
        public bool ib_equipment_mode_change { get; set; }
        public bool ib_ppid_recipe_map_request { get; set; }
        public bool ib_recipe_request { get; set; }


        #region YANGSYS I/F
        /// <summary>
        /// EQP TO CIM : 장비에서 CIM으로 Glass 투입 요청 신호를 보낼 시 송신한다.
        /// </summary>
        public bool vi_load_request { get; set; }
        /// <summary>
        /// CIM TO EQP :
        /// </summary>
        public bool vo_load_request_reply { get; set; }
        /// <summary>
        /// EQP TO CIM : CIM 으로부터 Glass Data 를 전달받은 후 HW적인 동작이 완료되었을 때 CIM으로 송신한다.
        /// </summary>
        public bool vi_load_enable { get; set; }
        /// <summary>
        /// CIM TO EQP : CIM 은 장비로부터 Enable 신호를 받은 시점부터 로봇을 동작시킨다. 
        /// </summary>
        public bool vo_load_enable_reply { get; set; }
        public bool vo_load_hand_down_completion { get; set; }
        public bool vi_load_hand_down_completion_reply { get; set; }
        public bool vo_load_complete { get; set; }
        public bool vi_load_complete_reply { get; set; }
        public bool vi_unload_request { get; set; }
        public bool vo_unload_request_reply { get; set; }
        public bool vi_unload_enable { get; set; }
        public bool vo_unload_enable_reply { get; set; }
        public bool vo_unload_hand_up_completion { get; set; }
        public bool vi_unload_hand_up_completion_reply { get; set; }
        public bool vo_unload_complete { get; set; }
        public bool vi_unload_complete_reply { get; set; }
        public bool vo_abnormal_interface { get; set; }
        public bool vi_initialize_request { get; set; }
        public bool vi_communication { get; set; }
        public bool vo_communication_ack { get; set; }
        public bool vo_alive { get; set; }
        public bool vi_alive_reply { get; set; }
        public bool vo_state_req { get; set; }
        public bool vi_state_req_ack { get; set; }
        public bool vo_state_change_req { get; set; }
        public bool vi_state_change_req_ack { get; set; }
        public bool vi_state_change_event { get; set; }
        public bool vo_state_change_event_reply { get; set; }
        public bool vi_stage_glass_exist { get; set; }
        public bool vo_stage_glass_exist_reply { get; set; }
        public bool vi_user_login { get; set; }
        public bool vo_user_login_reply { get; set; }
        public bool vi_user_login_recipe { get; set; }
        public bool vo_user_login_recipe_reply { get; set; }        
        public bool vo_glass_data_send { get; set; }
        public bool vi_glass_data_send_ack { get; set; }
        public bool vi_lost_glass_data_request { get; set; }
        public bool vo_lost_glass_data_request_ack { get; set; }
        public bool vi_glass_scrap { get; set; }
        public bool vo_glass_scrap_ack { get; set; }
        public bool vi_job_hold_event_report { get; set; }
        public bool vo_job_hold_event_report_ack { get; set; }
        public bool vi_alarm_set { get; set; }
        public bool vo_alarm_set_reply { get; set; }
        public bool vi_alarm_reset { get; set; }
        public bool vo_alarm_reset_reply { get; set; }
        public bool vo_alarm_set_request { get; set; }
        public bool vi_alarm_set_request_reply { get; set; }
        public bool vo_recipe_list_req { get; set; }
        public bool vi_recipe_list_req_reply { get; set; }
        public bool vi_current_recipe_change { get; set; }
        public bool vo_current_recipe_change_ack { get; set; }
        public bool vi_recipe_report { get; set; }
        public bool vo_recipe_report_ack { get; set; }
        public bool vo_buzzer { get; set; }
        public bool vi_buzzer_reply { get; set; }
        public bool vi_glass_data_value_file_report { get; set; }
        public bool vo_glass_data_value_file_report_ack { get; set; }
        public bool vi_ionizer { get; set; }
        public bool vo_ionizer_ack { get; set; }
        public bool vi_auto_mode_change_event { get; set; }
        public bool vo_auto_mode_change_event_reply { get; set; }
        public bool vi_oxr_information_update { get; set; }
        public bool vo_oxr_information_update_reply { get; set; }
        public bool vo_oxr_information_request_data { get; set; }
        public bool vi_oxr_information_request_data_reply { get; set; }
        public bool vi_tracking_data { get; set; }
        public bool vo_tracking_data_reply { get; set; }
        public bool vo_transfer_stop { get; set; }
        public bool vi_transfer_stop_reply { get; set; }
        public bool vo_cim_message_on { get; set; }
        public bool vi_cim_message_on_reply { get; set; }
        public bool vo_recovery_glass_data_send { get; set; }
        public bool vi_recovery_glass_data_send_ack { get; set; }
        public bool vo_defect_code_report { get; set; }
        public bool vo_defect_code_report_reply { get; set; }
        public bool vi_svid_send { get; set; }
        public bool vo_svid_send_reply { get; set; }
        public bool vi_machine_mode_change_report { get; set; }
        public bool vo_machine_mode_change_report_reply { get; set; }
        public bool vi_machine_mode_change_request_reply { get; set; }
        public bool vo_machine_mode_change_request { get; set; }
        public bool vi_cvid_send { get; set; }
        public bool vi_cvid_report_time_change_ack { get; set; }
        public bool vi_process_status_send { get; set; }
        public bool vi_cim_mode_reply { get; set; }
        public bool vo_shutter_Status_req { get; set; }
        public bool vi_shutter_Status_send { get; set; }
        public bool vo_recipe_request { get; set; }
        public bool vi_recipe_request_reply { get; set; }
        public bool vi_recipe_change_report { get; set; }
        public bool vo_recipe_change_report_ack { get; set; }
        #endregion

        public bool Running { get; set; }
        public bool BCconnect { get; set; }
        public int EqpStatus { get; set; }
        public int AlarmStatus { get; set; }
        public int ResonCode { get; set; }
        private int _cimMode = 1;
        public int CIMMode 
        {
            get
            {
                return _cimMode;
            }
            set
            {
                if (_cimMode <= 2 && _cimMode >= 1)
                {
                    _cimMode = value;
                }
            }
        }
        public bool UnloadHandDownCompletionReply { get; set; }
        public bool LoadHandDownCompletionReply { get; set; }
        public int EquipmentMode { get; set; }
        public bool LoadRequest { get; set; }
        public bool LoadEnable { get; set; }
        public bool UnloadRequest { get; set; }
        public bool UnloadEnable { get; set; }
        public bool InitialiazeRequest { get; set; } //20161214
        public bool StartLoadSEQ { get; set; }
        public bool StartUnLoadSEQ { get; set; }
        public bool StartExchangeSEQ { get; set; }
        public bool EQP_Shutter_Open { get; set; }
        public bool AbnormalSEQ { get; set; }
        public bool WaitLoadRequest { get; set; }
        public bool WaitUnloadRequest { get; set; }

        public bool Communication { get; set; }
        public bool Alive { get; set; }
        public bool MachineAutoMode { get; set; }
        public bool AutoRecipeMode { get; set; }
        public bool JobLoadingStop { get; set; }        
        public string CurrentRecipeNo { get; set; }
        public string CurrentPPID { get; set; }
        public int GlassCode1 {get; set;}
        public int GlassCode2 {get; set;}
        public bool GlassStageExist { get; set; }


        public bool ClientConnectionFlag { get; set; }

        public string LastAlarmCode { get; set; }
        public string LastAlarmText { get; set; }
        #region IControlAttribute 멤버

        public string Attribute
        {
            get;
            set;
        }

        #endregion

        public string MachineID = "";
        public string UnitNo = "";
        public string ImageType = "";
        public int DrawIndex = 0;
        public bool ExchangeMode = false;
        public bool UpStreamInlineMode { get; set; }
        public bool DownStreamInlineMode { get; set; }
        public bool ExchangePossible = false;

        public string RecipeList = "";
        public bool FlagRecipeCheck = false;
        public int GlassCodeLotNo1 = 0;
        public int GlassCodeSlotNo1 = 0;
        public string MachineMode = "0";
        public bool RecipeValdationAlarm = false;
        public int SEQ_T1 = 4;
        public int SEQ_T2 = 2;
        public bool RemainedGlassFlag = false;
        public bool vi_recipe_list_change = false;
        public bool vi_recipe_parameter_change = false;
        public bool vi_vcr_event_report = false;
        public bool vi_vcr_mode_change = false;
        public string VcrReadFailOperationMode = "";
        public string vcrMode = "";
        public bool vi_cancel_request = false;
        public bool CancelReuest = false;
        public bool vi_resume_request = false;
        public bool ResumeReuest = false;
        public bool vi_job_judge_result_report = false;
        public bool ppid_Request_Ack = false;
        public int PPIDReturnCode = 0;
        public string HostPPID_Value { get; set; }
        public int Glass_Tracking_DataA = 0;
        public int Glass_Tracking_DataB = 0;

        public string glass_data_value_file_A { get; set; }
        public string glass_data_value_file_B { get; set; }

        #region CBasicControl override Notify's
        public override void SetProperties(Dictionary<string, string> keyvalue)
        {
            base.SetProperties(keyvalue);
            //this.ModelName = this.GetValue<string>("ModelName", ref keyvalue);
            this.ControlName = this.GetValue<string>("ControlName", ref keyvalue);
            this.ModelType = this.GetValue<string>("ModelType", ref keyvalue);
            this.ConnectEQP = this.GetValue<string>("ConnectEQP", ref keyvalue);

            this.ControlLocation = new Point(this.GetValue<int>("X", ref keyvalue), this.GetValue<int>("Y", ref keyvalue));
            this.ControlSize = new Size(this.GetValue<int>("Width", ref keyvalue), this.GetValue<int>("Height", ref keyvalue));

            this.MachineID = this.GetValue<string>("MACHINE_ID", ref keyvalue);
            this.UnitNo = this.GetValue<string>("UnitNo", ref keyvalue);
            this.ImageType = this.GetValue<string>("ImageType", ref keyvalue);
            this.DrawIndex = this.GetValue<int>("DrawIndex", ref keyvalue);
        }

        public override void AttributeCollection(SOFD.Component.Interface.CIControlAttributeCollection attributecollection)
        {
            base.AttributeCollection(attributecollection);
        }

        public override void ScanEvents(SOFD.Component.Interface.IControlAttribute controlAttribute)
        {
            base.ScanEvents(controlAttribute);
            CControlAttribute oControlAttribute = controlAttribute as CControlAttribute;
            if (this.ControlName == oControlAttribute.ControlName)
            {
                switch (oControlAttribute.Attribute)
                {
                    case "IB_RECEIVED_JOB_REPORT_REPLY_UPSTREAM_PATH1":
                        __IB_RECEIVED_JOB_REPORT_REPLY_UPSTREAM_PATH1.AttributeOn += new delegateAttributeEvent(__IB_RECEIVED_JOB_REPORT_REPLY_UPSTREAM_PATH1_AttributeOn);
                        __IB_RECEIVED_JOB_REPORT_REPLY_UPSTREAM_PATH1.AttributeOff += new delegateAttributeEvent(__IB_RECEIVED_JOB_REPORT_REPLY_UPSTREAM_PATH1_AttributeOff);

                        break;
                    case "IB_SENT_OUT_JOB_REPORT_REPLY_DOWNSTREAM_PATH1":
                        __IB_SENT_OUT_JOB_REPORT_REPLY_DOWNSTREAM_PATH1.AttributeOn += new delegateAttributeEvent(__IB_SENT_OUT_JOB_REPORT_REPLY_DOWNSTREAM_PATH1_AttributeOn);
                        __IB_SENT_OUT_JOB_REPORT_REPLY_DOWNSTREAM_PATH1.AttributeOff += new delegateAttributeEvent(__IB_SENT_OUT_JOB_REPORT_REPLY_DOWNSTREAM_PATH1_AttributeOff);

                        break;
                    case "IB_SCRAP_JOB_REPORT_REPLY":
                        __IB_SCRAP_JOB_REPORT_REPLY.AttributeOn += new delegateAttributeEvent(__IB_SCRAP_JOB_REPORT_REPLY_AttributeOn);
                        __IB_SCRAP_JOB_REPORT_REPLY.AttributeOff += new delegateAttributeEvent(__IB_SCRAP_JOB_REPORT_REPLY_AttributeOff);

                        break;
                    case "IB_STORED_JOB_REPORT_REPLY":
                        __IB_STORED_JOB_REPORT_REPLY.AttributeOn += new delegateAttributeEvent(__IB_STORED_JOB_REPORT_REPLY_AttributeOn);
                        __IB_STORED_JOB_REPORT_REPLY.AttributeOff += new delegateAttributeEvent(__IB_STORED_JOB_REPORT_REPLY_AttributeOff);

                        break;
                    case "IB_FETCHED_OUT_JOB_REPORT_REPLY":
                        __IB_FETCHED_OUT_JOB_REPORT_REPLY.AttributeOn += new delegateAttributeEvent(__IB_FETCHED_OUT_JOB_REPORT_REPLY_AttributeOn);
                        __IB_FETCHED_OUT_JOB_REPORT_REPLY.AttributeOff += new delegateAttributeEvent(__IB_FETCHED_OUT_JOB_REPORT_REPLY_AttributeOff);

                        break;
                    case "IB_GLASS_DATA_CHANGE_REPORT_REPLY":
                        __IB_GLASS_DATA_CHANGE_REPORT_REPLY.AttributeOn += new delegateAttributeEvent(__IB_GLASS_DATA_CHANGE_REPORT_REPLY_AttributeOn);
                        __IB_GLASS_DATA_CHANGE_REPORT_REPLY.AttributeOff += new delegateAttributeEvent(__IB_GLASS_DATA_CHANGE_REPORT_REPLY_AttributeOff);

                        break;
                    case "IB_GLASS_PROCESS_START_REPORT_REPLY":
                        __IB_GLASS_PROCESS_START_REPORT_REPLY.AttributeOn += new delegateAttributeEvent(__IB_GLASS_PROCESS_START_REPORT_REPLY_AttributeOn);
                        __IB_GLASS_PROCESS_START_REPORT_REPLY.AttributeOff += new delegateAttributeEvent(__IB_GLASS_PROCESS_START_REPORT_REPLY_AttributeOff);

                        break;
                    case "IB_GLASS_PROCESS_END_REPORT_REPLY":
                        __IB_GLASS_PROCESS_END_REPORT_REPLY.AttributeOn += new delegateAttributeEvent(__IB_GLASS_PROCESS_END_REPORT_REPLY_AttributeOn);
                        __IB_GLASS_PROCESS_END_REPORT_REPLY.AttributeOff += new delegateAttributeEvent(__IB_GLASS_PROCESS_END_REPORT_REPLY_AttributeOff);

                        break;
                    case "IB_MACHINE_RECIPE_REQUEST_CONFIRM":
                        __IB_MACHINE_RECIPE_REQUEST_CONFIRM.AttributeOn += new delegateAttributeEvent(__IB_MACHINE_RECIPE_REQUEST_CONFIRM_AttributeOn);
                        __IB_MACHINE_RECIPE_REQUEST_CONFIRM.AttributeOff += new delegateAttributeEvent(__IB_MACHINE_RECIPE_REQUEST_CONFIRM_AttributeOff);

                        break;
                    case "IB_MACHINE_STATUS_CHANGE_REPORT_REPLY":
                        __IB_MACHINE_STATUS_CHANGE_REPORT_REPLY.AttributeOn += new delegateAttributeEvent(__IB_MACHINE_STATUS_CHANGE_REPORT_REPLY_AttributeOn);
                        __IB_MACHINE_STATUS_CHANGE_REPORT_REPLY.AttributeOff += new delegateAttributeEvent(__IB_MACHINE_STATUS_CHANGE_REPORT_REPLY_AttributeOff);

                        break;
                    case "IB_RECIPE_PARAMETER_REQUEST":
                        __IB_RECIPE_PARAMETER_REQUEST.AttributeOn += new delegateAttributeEvent(__IB_RECIPE_PARAMETER_REQUEST_AttributeOn);
                        __IB_RECIPE_PARAMETER_REQUEST.AttributeOff += new delegateAttributeEvent(__IB_RECIPE_PARAMETER_REQUEST_AttributeOff);

                        break;
                    case "IB_RECIPE_PARAMETER_DOWNLOAD":
                        __IB_RECIPE_PARAMETER_DOWNLOAD.AttributeOn += new delegateAttributeEvent(__IB_RECIPE_PARAMETER_DOWNLOAD_AttributeOn);
                        __IB_RECIPE_PARAMETER_DOWNLOAD.AttributeOff += new delegateAttributeEvent(__IB_RECIPE_PARAMETER_DOWNLOAD_AttributeOff);

                        break;
                    case "IB_CIM_MESSAGE_SET_COMMAND":
                        __IB_CIM_MESSAGE_SET_COMMAND.AttributeOn += new delegateAttributeEvent(__IB_CIM_MESSAGE_SET_COMMAND_AttributeOn);
                        __IB_CIM_MESSAGE_SET_COMMAND.AttributeOff += new delegateAttributeEvent(__IB_CIM_MESSAGE_SET_COMMAND_AttributeOff);

                        break;
                    case "IB_CIM_MESSAGE_CLEAR_COMMAND":
                        __IB_CIM_MESSAGE_CLEAR_COMMAND.AttributeOn += new delegateAttributeEvent(__IB_CIM_MESSAGE_CLEAR_COMMAND_AttributeOn);
                        __IB_CIM_MESSAGE_CLEAR_COMMAND.AttributeOff += new delegateAttributeEvent(__IB_CIM_MESSAGE_CLEAR_COMMAND_AttributeOff);

                        break;
                    case "IB_MACHINE_TIME_SET_COMMAND":
                        __IB_MACHINE_TIME_SET_COMMAND.AttributeOn += new delegateAttributeEvent(__IB_MACHINE_TIME_SET_COMMAND_AttributeOn);
                        __IB_MACHINE_TIME_SET_COMMAND.AttributeOff += new delegateAttributeEvent(__IB_MACHINE_TIME_SET_COMMAND_AttributeOff);

                        break;
                    case "IB_CIM_MODE_CHANGE_COMMAND":
                        __IB_CIM_MODE_CHANGE_COMMAND.AttributeOn += new delegateAttributeEvent(__IB_CIM_MODE_CHANGE_COMMAND_AttributeOn);
                        __IB_CIM_MODE_CHANGE_COMMAND.AttributeOff += new delegateAttributeEvent(__IB_CIM_MODE_CHANGE_COMMAND_AttributeOff);

                        break;
                    case "IB_CV_REPORT_TIME_CHANGE_COMMAND":
                        __IB_CV_REPORT_TIME_CHANGE_COMMAND.AttributeOn += new delegateAttributeEvent(__IB_CV_REPORT_TIME_CHANGE_COMMAND_AttributeOn);
                        __IB_CV_REPORT_TIME_CHANGE_COMMAND.AttributeOff += new delegateAttributeEvent(__IB_CV_REPORT_TIME_CHANGE_COMMAND_AttributeOff);

                        break;
                    case "IB_GLASS_JUDGE_RESULT_REQUEST_CONFIRM":
                        __IB_GLASS_JUDGE_RESULT_REQUEST_CONFIRM.AttributeOn += new delegateAttributeEvent(__IB_GLASS_JUDGE_RESULT_REQUEST_CONFIRM_AttributeOn);
                        __IB_GLASS_JUDGE_RESULT_REQUEST_CONFIRM.AttributeOff += new delegateAttributeEvent(__IB_GLASS_JUDGE_RESULT_REQUEST_CONFIRM_AttributeOff);

                        break;
                    case "IB_GLASS_JUDGE_RESULT_REPORT_REPLY":
                        __IB_GLASS_JUDGE_RESULT_REPORT_REPLY.AttributeOn += new delegateAttributeEvent(__IB_GLASS_JUDGE_RESULT_REPORT_REPLY_AttributeOn);
                        __IB_GLASS_JUDGE_RESULT_REPORT_REPLY.AttributeOff += new delegateAttributeEvent(__IB_GLASS_JUDGE_RESULT_REPORT_REPLY_AttributeOff);

                        break;
                    case "IB_GLASS_DATA_REQUEST_CONFIRM":
                        __IB_GLASS_DATA_REQUEST_CONFIRM.AttributeOn += new delegateAttributeEvent(__IB_GLASS_DATA_REQUEST_CONFIRM_AttributeOn);
                        __IB_GLASS_DATA_REQUEST_CONFIRM.AttributeOff += new delegateAttributeEvent(__IB_GLASS_DATA_REQUEST_CONFIRM_AttributeOff);

                        break;
                    case "IB_MACHINE_MODE_CHANGE_COMMAND":
                        __IB_MACHINE_MODE_CHANGE_COMMAND.AttributeOn += new delegateAttributeEvent(__IB_MACHINE_MODE_CHANGE_COMMAND_AttributeOn);
                        __IB_MACHINE_MODE_CHANGE_COMMAND.AttributeOff += new delegateAttributeEvent(__IB_MACHINE_MODE_CHANGE_COMMAND_AttributeOff);

                        break;
                    case "IB_LOADING_STOP_REQUEST_REPLY_CIM":
                        __IB_LOADING_STOP_REQUEST_REPLY_CIM.AttributeOn += new delegateAttributeEvent(__IB_LOADING_STOP_REQUEST_REPLY_CIM_AttributeOn);
                        __IB_LOADING_STOP_REQUEST_REPLY_CIM.AttributeOff += new delegateAttributeEvent(__IB_LOADING_STOP_REQUEST_REPLY_CIM_AttributeOff);

                        break;
                    case "IB_LOADING_STOP_RELEASE_REPLY_CIM":
                        __IB_LOADING_STOP_RELEASE_REPLY_CIM.AttributeOn += new delegateAttributeEvent(__IB_LOADING_STOP_RELEASE_REPLY_CIM_AttributeOn);
                        __IB_LOADING_STOP_RELEASE_REPLY_CIM.AttributeOff += new delegateAttributeEvent(__IB_LOADING_STOP_RELEASE_REPLY_CIM_AttributeOff);
                        break;

                    #region YANGSYS

                    case "VI_LOAD_REQUEST":
                        __VI_LOAD_REQUEST.AttributeOn += new delegateAttributeEvent(__VI_LOAD_REQUEST_AttributeOn);
                        __VI_LOAD_REQUEST.AttributeOff += new delegateAttributeEvent(__VI_LOAD_REQUEST_AttributeOff);
                        break;
                    case "VI_LOAD_ENABLE":
                        __VI_LOAD_ENABLE.AttributeOn += new delegateAttributeEvent(__VI_LOAD_ENABLE_AttributeOn);
                        __VI_LOAD_ENABLE.AttributeOff += new delegateAttributeEvent(__VI_LOAD_ENABLE_AttributeOff);
                        break;
                    case "VI_LOAD_HAND_DOWN_COMPLETION_REPLY":
                        __VI_LOAD_HAND_DOWN_COMPLETION_REPLY.AttributeOn += new delegateAttributeEvent(__VI_LOAD_HAND_DOWN_COMPLETION_REPLY_AttributeOn);
                        __VI_LOAD_HAND_DOWN_COMPLETION_REPLY.AttributeOff += new delegateAttributeEvent(__VI_LOAD_HAND_DOWN_COMPLETION_REPLY_AttributeOff);
                        break;
                    case "VI_LOAD_COMPLETE_REPLY":
                        __VI_LOAD_COMPLETE_REPLY.AttributeOn += new delegateAttributeEvent(__VI_LOAD_COMPLETE_REPLY_AttributeOn);
                        __VI_LOAD_COMPLETE_REPLY.AttributeOff += new delegateAttributeEvent(__VI_LOAD_COMPLETE_REPLY_AttributeOff);
                        break;
                    case "VI_UNLOAD_REQUEST":
                        __VI_UNLOAD_REQUEST.AttributeOn += new delegateAttributeEvent(__VI_UNLOAD_REQUEST_AttributeOn);
                        __VI_UNLOAD_REQUEST.AttributeOff += new delegateAttributeEvent(__VI_UNLOAD_REQUEST_AttributeOff);
                        break;
                    case "VI_UNLOAD_ENABLE":
                        __VI_UNLOAD_ENABLE.AttributeOn += new delegateAttributeEvent(__VI_UNLOAD_ENABLE_AttributeOn);
                        __VI_UNLOAD_ENABLE.AttributeOff += new delegateAttributeEvent(__VI_UNLOAD_ENABLE_AttributeOff);
                        break;
                    case "VI_UNLOAD_HAND_UP_COMPLETION_REPLY":
                        __VI_UNLOAD_HAND_UP_COMPLETION_REPLY.AttributeOn += new delegateAttributeEvent(__VI_UNLOAD_HAND_UP_COMPLETION_REPLY_AttributeOn);
                        __VI_UNLOAD_HAND_UP_COMPLETION_REPLY.AttributeOff += new delegateAttributeEvent(__VI_UNLOAD_HAND_UP_COMPLETION_REPLY_AttributeOff);
                        break;
                    case "VI_UNLOAD_COMPLETE_REPLY":
                        __VI_UNLOAD_COMPLETE_REPLY.AttributeOn += new delegateAttributeEvent(__VI_UNLOAD_COMPLETE_REPLY_AttributeOn);
                        __VI_UNLOAD_COMPLETE_REPLY.AttributeOff += new delegateAttributeEvent(__VI_UNLOAD_COMPLETE_REPLY_AttributeOff);
                        break;
                    case "VI_INITIALIZE_REQUEST":
                        __VI_INITIALIZE_REQUEST.AttributeOn += new delegateAttributeEvent(__VI_INITIALIZE_REQUEST_AttributeOn);
                        __VI_INITIALIZE_REQUEST.AttributeOff += new delegateAttributeEvent(__VI_INITIALIZE_REQUEST_AttributeOff);
                        break;
                    case "VI_COMMUNICATION":
                        __VI_COMMUNICATION.AttributeOn += new delegateAttributeEvent(__VI_COMMUNICATION_AttributeOn);
                        __VI_COMMUNICATION.AttributeOff += new delegateAttributeEvent(__VI_COMMUNICATION_AttributeOff);
                        break;
                    case "VI_ALIVE_REPLY":
                        __VI_ALIVE_REPLY.AttributeOn += new delegateAttributeEvent(__VI_ALIVE_REPLY_AttributeOn);
                        __VI_ALIVE_REPLY.AttributeOff += new delegateAttributeEvent(__VI_ALIVE_REPLY_AttributeOff);
                        break;
                    case "VI_STATE_REQUEST_ACK":
                        @__VI_STATE_REQUEST_ACK.AttributeOn += new delegateAttributeEvent(__VI_STATE_REQ_ACK_AttributeOn);
                        @__VI_STATE_REQUEST_ACK.AttributeOff += new delegateAttributeEvent(__VI_STATE_REQ_ACK_AttributeOff);
                        break;
                    case "VI_STATE_CHANGE_REQ_ACK":
                        __VI_STATE_CHANGE_REQ_ACK.AttributeOn += new delegateAttributeEvent(__VI_STATE_CHANGE_REQ_ACK_AttributeOn);
                        __VI_STATE_CHANGE_REQ_ACK.AttributeOff += new delegateAttributeEvent(__VI_STATE_CHANGE_REQ_ACK_AttributeOff);
                        break;
                    case "VI_STATE_CHANGE_EVENT":
                        __VI_STATE_CHANGE_EVENT.AttributeOn += new delegateAttributeEvent(__VI_STATE_CHANGE_EVENT_AttributeOn);
                        __VI_STATE_CHANGE_EVENT.AttributeOff += new delegateAttributeEvent(__VI_STATE_CHANGE_EVENT_AttributeOff);
                        break;
                    case "VI_STAGE_GLASS_EXIST":
                        __VI_STAGE_GLASS_EXIST.AttributeOn += new delegateAttributeEvent(__VI_STAGE_GLASS_EXIST_AttributeOn);
                        __VI_STAGE_GLASS_EXIST.AttributeOff += new delegateAttributeEvent(__VI_STAGE_GLASS_EXIST_AttributeOff);
                        break;
                    case "VI_USER_LOGIN":
                        __VI_USER_LOGIN.AttributeOn += new delegateAttributeEvent(__VI_USER_LOGIN_AttributeOn);
                        __VI_USER_LOGIN.AttributeOff += new delegateAttributeEvent(__VI_USER_LOGIN_AttributeOff);
                        break;
                    case "VI_USER_LOGIN_RECIPE":
                        __VI_USER_LOGIN_RECIPE.AttributeOn += new delegateAttributeEvent(__VI_USER_LOGIN_RECIPE_AttributeOn);
                        __VI_USER_LOGIN_RECIPE.AttributeOff += new delegateAttributeEvent(__VI_USER_LOGIN_RECIPE_AttributeOff);
                        break;
                    case "VI_GLASS_DATA_SEND_ACK":
                        __VI_GLASS_DATA_SEND_ACK.AttributeOn += new delegateAttributeEvent(__VI_GLASS_DATA_SEND_ACK_AttributeOn);
                        __VI_GLASS_DATA_SEND_ACK.AttributeOff += new delegateAttributeEvent(__VI_GLASS_DATA_SEND_ACK_AttributeOff);
                        break;
                    case "VI_LOST_GLASS_DATA_REQUEST":
                        __VI_LOST_GLASS_DATA_REQUEST.AttributeOn += new delegateAttributeEvent(__VI_LOST_GLASS_DATA_REQUEST_AttributeOn);
                        __VI_LOST_GLASS_DATA_REQUEST.AttributeOff += new delegateAttributeEvent(__VI_LOST_GLASS_DATA_REQUEST_AttributeOff);
                        break;
                    case "VI_GLASS_SCRAP":
                        __VI_GLASS_SCRAP.AttributeOn += new delegateAttributeEvent(__VI_GLASS_SCRAP_AttributeOn);
                        __VI_GLASS_SCRAP.AttributeOff += new delegateAttributeEvent(__VI_GLASS_SCRAP_AttributeOff);
                        break;
                    case "VI_JOB_HOLD_EVENT_REPORT":
                        __VI_JOB_HOLD_EVENT_REPORT.AttributeOn += new delegateAttributeEvent(__VI_JOB_HOLD_EVENT_REPORT_AttributeOn);
                        __VI_JOB_HOLD_EVENT_REPORT.AttributeOff += new delegateAttributeEvent(__VI_JOB_HOLD_EVENT_REPORT_AttributeOff);
                        break;
                    case "VI_ALARM_SET":
                        __VI_ALARM_SET.AttributeOn += new delegateAttributeEvent(__VI_ALARM_SET_AttributeOn);
                        __VI_ALARM_SET.AttributeOff += new delegateAttributeEvent(__VI_ALARM_SET_AttributeOff);
                        break;
                    case "VI_ALARM_RESET":
                        __VI_ALARM_RESET.AttributeOn += new delegateAttributeEvent(__VI_ALARM_RESET_AttributeOn);
                        __VI_ALARM_RESET.AttributeOff += new delegateAttributeEvent(__VI_ALARM_RESET_AttributeOff);
                        break;
                    case "VI_ALARM_SET_REQUEST_REPLY":
                        __VI_ALARM_SET_REQUEST_REPLY.AttributeOn += new delegateAttributeEvent(__VI_ALARM_SET_REQUEST_REPLY_AttributeOn);
                        __VI_ALARM_SET_REQUEST_REPLY.AttributeOff += new delegateAttributeEvent(__VI_ALARM_SET_REQUEST_REPLY_AttributeOff);
                        break;
                    case "VI_RECIPE_LIST_REQ_REPLY":
                        __VI_RECIPE_LIST_REQ_REPLY.AttributeOn += new delegateAttributeEvent(__VI_RECIPE_LIST_REQ_REPLY_AttributeOn);
                        __VI_RECIPE_LIST_REQ_REPLY.AttributeOff += new delegateAttributeEvent(__VI_RECIPE_LIST_REQ_REPLY_AttributeOff);
                        break;
                    case "VI_CURRENT_RECIPE_CHANGE":
                        __VI_CURRENT_RECIPE_CHANGE.AttributeOn += new delegateAttributeEvent(__VI_CURRENT_RECIPE_CHANGE_AttributeOn);
                        __VI_CURRENT_RECIPE_CHANGE.AttributeOff += new delegateAttributeEvent(__VI_CURRENT_RECIPE_CHANGE_AttributeOff);
                        break;
                    case "VI_RECIPE_REPORT":
                        __VI_RECIPE_REPORT.AttributeOn += new delegateAttributeEvent(__VI_RECIPE_REPORT_AttributeOn);
                        __VI_RECIPE_REPORT.AttributeOff += new delegateAttributeEvent(__VI_RECIPE_REPORT_AttributeOff);
                        break;
                    case "VI_BUZZER_REPLY":
                        __VI_BUZZER_REPLY.AttributeOn += new delegateAttributeEvent(__VI_BUZZER_REPLY_AttributeOn);
                        __VI_BUZZER_REPLY.AttributeOff += new delegateAttributeEvent(__VI_BUZZER_REPLY_AttributeOff);
                        break;
                    case "VI_GLASS_DATA_VALUE_FILE_REPORT":
                        __VI_GLASS_DATA_VALUE_FILE_REPORT.AttributeOn += new delegateAttributeEvent(__VI_GLASS_DATA_VALUE_FILE_REPORT_AttributeOn);
                        __VI_GLASS_DATA_VALUE_FILE_REPORT.AttributeOff += new delegateAttributeEvent(__VI_GLASS_DATA_VALUE_FILE_REPORT_AttributeOff);
                        break;
                    case "VI_IONIZER":
                        __VI_IONIZER.AttributeOn += new delegateAttributeEvent(__VI_IONIZER_AttributeOn);
                        __VI_IONIZER.AttributeOff += new delegateAttributeEvent(__VI_IONIZER_AttributeOff);
                        break;
                    case "VI_AUTO_MODE_CHANGE_EVENT":
                        __VI_AUTO_MODE_CHANGE_EVENT.AttributeOn += new delegateAttributeEvent(__VI_AUTO_MODE_CHANGE_EVENT_AttributeOn);
                        __VI_AUTO_MODE_CHANGE_EVENT.AttributeOff += new delegateAttributeEvent(__VI_AUTO_MODE_CHANGE_EVENT_AttributeOff);
                        break;
                    case "VI_OXR_INFORMATION_UPDATE":
                        __VI_OXR_INFORMATION_UPDATE.AttributeOn += new delegateAttributeEvent(__VI_OXR_INFORMATION_UPDATE_AttributeOn);
                        __VI_OXR_INFORMATION_UPDATE.AttributeOff += new delegateAttributeEvent(__VI_OXR_INFORMATION_UPDATE_AttributeOff);
                        break;
                    case "VI_OXR_INFORMATION_REQUEST_DATA_REPLY":
                        __VI_OXR_INFORMATION_REQUEST_DATA_REPLY.AttributeOn += new delegateAttributeEvent(__VI_OXR_INFORMATION_REQUEST_DATA_REPLY_AttributeOn);
                        __VI_OXR_INFORMATION_REQUEST_DATA_REPLY.AttributeOff += new delegateAttributeEvent(__VI_OXR_INFORMATION_REQUEST_DATA_REPLY_AttributeOff);
                        break;
                    case "VI_TRACKING_DATA":
                        __VI_TRACKING_DATA.AttributeOn += new delegateAttributeEvent(__VI_TRACKING_DATA_AttributeOn);
                        __VI_TRACKING_DATA.AttributeOff += new delegateAttributeEvent(__VI_TRACKING_DATA_AttributeOff);
                        break;
                    case "VI_TRANSFER_STOP_REPLY":
                        __VI_TRANSFER_STOP_REPLY.AttributeOn += new delegateAttributeEvent(__VI_TRANSFER_STOP_REPLY_AttributeOn);
                        __VI_TRANSFER_STOP_REPLY.AttributeOff += new delegateAttributeEvent(__VI_TRANSFER_STOP_REPLY_AttributeOff);
                        break;
                    case "VI_CIM_MESSAGE_ON_REPLY":
                        __VI_CIM_MESSAGE_ON_REPLY.AttributeOn += new delegateAttributeEvent(__VI_CIM_MESSAGE_ON_REPLY_AttributeOn);
                        __VI_CIM_MESSAGE_ON_REPLY.AttributeOff += new delegateAttributeEvent(__VI_CIM_MESSAGE_ON_REPLY_AttributeOff);
                        break;
                    case "VI_RECOVERY_GLASS_DATA_SEND_ACK":
                        __VI_RECOVERY_GLASS_DATA_SEND_ACK.AttributeOn += new delegateAttributeEvent(__VI_RECOVERY_GLASS_DATA_SEND_ACK_AttributeOn);
                        __VI_RECOVERY_GLASS_DATA_SEND_ACK.AttributeOff += new delegateAttributeEvent(__VI_RECOVERY_GLASS_DATA_SEND_ACK_AttributeOff);
                        break;
                    case "VI_SVID_SEND":
                        __VI_SVID_SEND.AttributeOn += new delegateAttributeEvent(__VI_SVID_SEND_AttributeOn);
                        __VI_SVID_SEND.AttributeOff += new delegateAttributeEvent(__VI_SVID_SEND_AttributeOff);
                        break;
                    case "VI_MACHINE_MODE_CHANGE_REPORT":
                        __VI_MACHINE_MODE_CHANGE_REPORT.AttributeOn += new delegateAttributeEvent(__VI_MACHINE_MODE_CHANGE_REPORT_AttributeOn);
                        __VI_MACHINE_MODE_CHANGE_REPORT.AttributeOff += new delegateAttributeEvent(__VI_MACHINE_MODE_CHANGE_REPORT_AttributeOff);
                        break;
                    case "VI_MACHINE_MODE_CHANGE_REQUEST_REPLY":
                        __VI_MACHINE_MODE_CHANGE_REQUEST_REPLY.AttributeOn += new delegateAttributeEvent(__VI_MACHINE_MODE_CHANGE_REQUEST_REPLY_AttributeOn);
                        __VI_MACHINE_MODE_CHANGE_REQUEST_REPLY.AttributeOff += new delegateAttributeEvent(__VI_MACHINE_MODE_CHANGE_REQUEST_REPLY_AttributeOff);
                        break;
                    case "VI_CVID_SEND":
                        __VI_CVID_SEND.AttributeOn += new delegateAttributeEvent(__VI_CVID_SEND_AttributeOn);
                        __VI_CVID_SEND.AttributeOff += new delegateAttributeEvent(__VI_CVID_SEND_AttributeOff);
                        break;
                    case "VI_CVID_REPORT_TIME_CHANGE_ACK":
                        __VI_CVID_REPORT_TIME_CHANGE_ACK.AttributeOn += new delegateAttributeEvent(__VI_CVID_REPORT_TIME_CHANGE_ACK_AttributeOn);
                        __VI_CVID_REPORT_TIME_CHANGE_ACK.AttributeOff += new delegateAttributeEvent(__VI_CVID_REPORT_TIME_CHANGE_ACK_AttributeOff);
                        break;
                    case "VI_PROCESS_STATUS_SEND":
                        __VI_PROCESS_STATUS_SEND.AttributeOn += new delegateAttributeEvent(__VI_PROCESS_STATUS_SEND_AttributeOn);
                        __VI_PROCESS_STATUS_SEND.AttributeOff += new delegateAttributeEvent(__VI_PROCESS_STATUS_SEND_AttributeOff);
                        break;
                    case "VI_CIM_MODE_REPLY":
                        __VI_CIM_MODE_REPLY.AttributeOn += new delegateAttributeEvent(__VI_CIM_MODE_REPLY_AttributeOn);
                        __VI_CIM_MODE_REPLY.AttributeOff += new delegateAttributeEvent(__VI_CIM_MODE_REPLY_AttributeOff);
                        break;
                    case "VI_SHUTTER_STATUS_SEND":
                        __VI_SHUTTER_STATUS_SEND.AttributeOn += new delegateAttributeEvent(__VI_SHUTTER_STATUS_SEND_AttributeOn);
                        __VI_SHUTTER_STATUS_SEND.AttributeOff += new delegateAttributeEvent(__VI_SHUTTER_STATUS_SEND_AttributeOff);
                        break;
                    case "VI_RECIPE_REQUEST_REPLY":
                        __VI_RECIPE_REQUEST_REPLY.AttributeOn += new delegateAttributeEvent(__VI_RECIPE_REQUEST_REPLY_AttributeOn);
                        __VI_RECIPE_REQUEST_REPLY.AttributeOff += new delegateAttributeEvent(__VI_RECIPE_REQUEST_REPLY_AttributeOff);
                        break;
                    case "VI_RECIPE_CHANGE_REPORT":
                        __VI_RECIPE_CHANGE_REPORT.AttributeOn += new delegateAttributeEvent(__VI_RECIPE_CHANGE_REPORT_AttributeOn);
                        __VI_RECIPE_CHANGE_REPORT.AttributeOff += new delegateAttributeEvent(__VI_RECIPE_CHANGE_REPORT_AttributeOff);
                        break;
                    #endregion

                    case "IB_TERMINAL_TEXT":
                        __IB_TERMINAL_TEXT.AttributeOn += new delegateAttributeEvent(__IB_TERMINAL_TEXT_AttributeOn);
                        __IB_TERMINAL_TEXT.AttributeOff += new delegateAttributeEvent(__IB_TERMINAL_TEXT_AttributeOff);
                        break;
                    case "IB_OPERATOR_CALL":
                        __IB_OPERATOR_CALL.AttributeOn += new delegateAttributeEvent(__IB_OPERATOR_CALL_AttributeOn);
                        __IB_OPERATOR_CALL.AttributeOff += new delegateAttributeEvent(__IB_OPERATOR_CALL_AttributeOff);
                        break;
                    case "IB_LD_BUZZ_ON":
                        __IB_LD_BUZZ_ON.AttributeOn += new delegateAttributeEvent(__IB_LD_BUZZ_ON_AttributeOn);
                        __IB_LD_BUZZ_ON.AttributeOff += new delegateAttributeEvent(__IB_LD_BUZZ_ON_AttributeOff);
                        break;
                    case "IB_DATE_TIME_SET":
                        __IB_DATE_TIME_SET.AttributeOn += new delegateAttributeEvent(__IB_DATE_TIME_SET_AttributeOn);
                        __IB_DATE_TIME_SET.AttributeOff += new delegateAttributeEvent(__IB_DATE_TIME_SET_AttributeOff);
                        break;
                    case "IB_PPID_RECIPE_ID_MAP_CHANGE":
                        __IB_PPID_RECIPE_ID_MAP_CHANGE.AttributeOn += new delegateAttributeEvent(__IB_PPID_RECIPE_ID_MAP_CHANGE_AttributeOn);
                        __IB_PPID_RECIPE_ID_MAP_CHANGE.AttributeOff += new delegateAttributeEvent(__IB_PPID_RECIPE_ID_MAP_CHANGE_AttributeOff);
                        break;
                    case "IB_EQUIPMENT_MODE_CHANGE":
                        __IB_EQUIPMENT_MODE_CHANGE.AttributeOn += new delegateAttributeEvent(__IB_EQUIPMENT_MODE_CHANGE_AttributeOn);
                        __IB_EQUIPMENT_MODE_CHANGE.AttributeOff += new delegateAttributeEvent(__IB_EQUIPMENT_MODE_CHANGE_AttributeOff);
                        break;
                    case "IB_PPID_RECIPE_MAP_REQUEST":
                        __IB_PPID_RECIPE_MAP_REQUEST.AttributeOn += new delegateAttributeEvent(__IB_PPID_RECIPE_MAP_REQUEST_AttributeOn);
                        __IB_PPID_RECIPE_MAP_REQUEST.AttributeOff += new delegateAttributeEvent(__IB_PPID_RECIPE_MAP_REQUEST_AttributeOff);
                        break;
                    case "IB_RECIPE_REQUEST":
                        __IB_RECIPE_REQUEST.AttributeOn += new delegateAttributeEvent(__IB_RECIPE_REQUEST_AttributeOn);
                        __IB_RECIPE_REQUEST.AttributeOff += new delegateAttributeEvent(__IB_RECIPE_REQUEST_AttributeOff);
                        break;

                    default:
                        Console.WriteLine(controlAttribute.Attribute + " OvenControl");
                        break;
                }
            }
        }



        #endregion

        #region Event Handler
        public delegate void delegateRunningModeNoty(object sender, bool value);
        public delegate void delegateEquipmentAutoModeNotify(object sender, bool value);

        void __IB_RECEIVED_JOB_REPORT_REPLY_UPSTREAM_PATH1_AttributeOn(object sender)
        {
            ib_received_job_report_reply_upstream_path1 = true;
        }
        void __IB_RECEIVED_JOB_REPORT_REPLY_UPSTREAM_PATH1_AttributeOff(object sender)
        {
            ib_received_job_report_reply_upstream_path1 = false;
        }

        void __IB_SENT_OUT_JOB_REPORT_REPLY_DOWNSTREAM_PATH1_AttributeOn(object sender)
        {
            ib_sent_out_job_report_reply_downstream_path1 = true;
        }
        void __IB_SENT_OUT_JOB_REPORT_REPLY_DOWNSTREAM_PATH1_AttributeOff(object sender)
        {
            ib_sent_out_job_report_reply_downstream_path1 = false;
        }

        void __IB_SCRAP_JOB_REPORT_REPLY_AttributeOn(object sender)
        {
            ib_scrap_job_report_reply = true;
        }
        void __IB_SCRAP_JOB_REPORT_REPLY_AttributeOff(object sender)
        {
            ib_scrap_job_report_reply = false;
        }

        void __IB_STORED_JOB_REPORT_REPLY_AttributeOn(object sender)
        {
            ib_stored_job_report_reply = true;
        }
        void __IB_STORED_JOB_REPORT_REPLY_AttributeOff(object sender)
        {
            ib_stored_job_report_reply = false;
        }

        void __IB_FETCHED_OUT_JOB_REPORT_REPLY_AttributeOn(object sender)
        {
            ib_fetched_out_job_report_reply = true;
        }
        void __IB_FETCHED_OUT_JOB_REPORT_REPLY_AttributeOff(object sender)
        {
            ib_fetched_out_job_report_reply = false;
        }

        void __IB_GLASS_DATA_CHANGE_REPORT_REPLY_AttributeOn(object sender)
        {
            ib_glass_data_change_report_reply = true;
        }
        void __IB_GLASS_DATA_CHANGE_REPORT_REPLY_AttributeOff(object sender)
        {
            ib_glass_data_change_report_reply = false;
        }

        void __IB_GLASS_PROCESS_START_REPORT_REPLY_AttributeOn(object sender)
        {
            ib_glass_process_start_report_reply = true;
        }
        void __IB_GLASS_PROCESS_START_REPORT_REPLY_AttributeOff(object sender)
        {
            ib_glass_process_start_report_reply = false;
        }

        void __IB_GLASS_PROCESS_END_REPORT_REPLY_AttributeOn(object sender)
        {
            ib_glass_process_end_report_reply = true;
        }
        void __IB_GLASS_PROCESS_END_REPORT_REPLY_AttributeOff(object sender)
        {
            ib_glass_process_end_report_reply = false;
        }

        void __IB_MACHINE_RECIPE_REQUEST_CONFIRM_AttributeOn(object sender)
        {
            ib_machine_recipe_request_confirm = true;
        }
        void __IB_MACHINE_RECIPE_REQUEST_CONFIRM_AttributeOff(object sender)
        {
            ib_machine_recipe_request_confirm = false;
        }

        void __IB_MACHINE_STATUS_CHANGE_REPORT_REPLY_AttributeOn(object sender)
        {
            ib_machine_status_change_report_reply = true;
        }
        void __IB_MACHINE_STATUS_CHANGE_REPORT_REPLY_AttributeOff(object sender)
        {
            ib_machine_status_change_report_reply = false;
        }

        void __IB_RECIPE_PARAMETER_REQUEST_AttributeOn(object sender)
        {
            ib_recipe_parameter_request = true;
            if (Programs.ContainsKey("RECIPE_PARAMETER_DATA_REQUEST"))
                Programs["RECIPE_PARAMETER_DATA_REQUEST"].Execute();
        }
        void __IB_RECIPE_PARAMETER_REQUEST_AttributeOff(object sender)
        {
            ib_recipe_parameter_request = false;
        }

        void __IB_RECIPE_PARAMETER_DOWNLOAD_AttributeOn(object sender)
        {
            ib_recipe_parameter_download = true;
            if (Programs.ContainsKey("RECIPE_PARAMETER_DOWNLOAD"))
                Programs["RECIPE_PARAMETER_DOWNLOAD"].Execute();
        }
        void __IB_RECIPE_PARAMETER_DOWNLOAD_AttributeOff(object sender)
        {
            ib_recipe_parameter_download = false;
        }

        void __IB_CIM_MESSAGE_SET_COMMAND_AttributeOn(object sender)
        {
            ib_cim_message_set_command = true;
            if (Programs.ContainsKey("CIM_MESSAGE_SET_COMMAND"))
                Programs["CIM_MESSAGE_SET_COMMAND"].Execute();
        }
        void __IB_CIM_MESSAGE_SET_COMMAND_AttributeOff(object sender)
        {
            ib_cim_message_set_command = false;
        }

        void __IB_CIM_MESSAGE_CLEAR_COMMAND_AttributeOn(object sender)
        {
            ib_cim_message_clear_command = true;
            if (Programs.ContainsKey("CIM_MESSAGE_CLEAR_COMMAND"))
                Programs["CIM_MESSAGE_CLEAR_COMMAND"].Execute();
        }
        void __IB_CIM_MESSAGE_CLEAR_COMMAND_AttributeOff(object sender)
        {
            ib_cim_message_clear_command = false;
        }

        void __IB_MACHINE_TIME_SET_COMMAND_AttributeOn(object sender)
        {
            ib_machine_time_set_command = true;
            if (Programs.ContainsKey("MACHINE_TIMESET_COMMAND"))
                Programs["MACHINE_TIMESET_COMMAND"].Execute();
        }
        void __IB_MACHINE_TIME_SET_COMMAND_AttributeOff(object sender)
        {
            ib_machine_time_set_command = false;
        }

        void __IB_CIM_MODE_CHANGE_COMMAND_AttributeOn(object sender)
        {
            ib_cim_mode_change_command = true;
            if (Programs.ContainsKey("CIM_MODE_CHANGE_COMMAND"))
                Programs["CIM_MODE_CHANGE_COMMAND"].Execute();
        }
        void __IB_CIM_MODE_CHANGE_COMMAND_AttributeOff(object sender)
        {
            ib_cim_mode_change_command = false;
        }

        void __IB_CV_REPORT_TIME_CHANGE_COMMAND_AttributeOn(object sender)
        {
            ib_cv_report_time_change_command = true;
            if (Programs.ContainsKey("CV_REPORT_TIME_CHANGE_COMMAND"))
                Programs["CV_REPORT_TIME_CHANGE_COMMAND"].Execute();
        }
        void __IB_CV_REPORT_TIME_CHANGE_COMMAND_AttributeOff(object sender)
        {
            ib_cv_report_time_change_command = false;
        }

        void __IB_GLASS_JUDGE_RESULT_REQUEST_CONFIRM_AttributeOn(object sender)
        {
            ib_glass_judge_result_request_confirm = true;
        }
        void __IB_GLASS_JUDGE_RESULT_REQUEST_CONFIRM_AttributeOff(object sender)
        {
            ib_glass_judge_result_request_confirm = false;
        }

        void __IB_GLASS_JUDGE_RESULT_REPORT_REPLY_AttributeOn(object sender)
        {
            ib_glass_judge_result_report_reply = true;
        }
        void __IB_GLASS_JUDGE_RESULT_REPORT_REPLY_AttributeOff(object sender)
        {
            ib_glass_judge_result_report_reply = false;
        }

        void __IB_GLASS_DATA_REQUEST_CONFIRM_AttributeOn(object sender)
        {
            ib_glass_data_request_confirm = true;
        }
        void __IB_GLASS_DATA_REQUEST_CONFIRM_AttributeOff(object sender)
        {
            ib_glass_data_request_confirm = false;
        }

        void __IB_MACHINE_MODE_CHANGE_COMMAND_AttributeOn(object sender)
        {
            ib_machine_mode_change_command = true;
            if (Programs.ContainsKey("MACHINE_MODE_CHANGE_COMMAND"))
                Programs["MACHINE_MODE_CHANGE_COMMAND"].Execute();
        }
        void __IB_MACHINE_MODE_CHANGE_COMMAND_AttributeOff(object sender)
        {
            ib_machine_mode_change_command = false;
        }

        void __IB_LOADING_STOP_REQUEST_REPLY_CIM_AttributeOn(object sender)
        {
            ib_loading_stop_request_reply_cim = true;
        }
        void __IB_LOADING_STOP_REQUEST_REPLY_CIM_AttributeOff(object sender)
        {
            ib_loading_stop_request_reply_cim = false;
        }

        void __IB_LOADING_STOP_RELEASE_REPLY_CIM_AttributeOn(object sender)
        {
            ib_loading_stop_release_reply_cim = true;
        }
        void __IB_LOADING_STOP_RELEASE_REPLY_CIM_AttributeOff(object sender)
        {
            ib_loading_stop_release_reply_cim = false;
        }


        #endregion
        #region YANGSYS
        void __VI_LOAD_REQUEST_AttributeOn(object sender)
        {
            vi_load_request = true;
            if (Programs.ContainsKey("YANGSYS_MESSAGE_HANDLER"))
                Programs["YANGSYS_MESSAGE_HANDLER"].Execute();
        }
        void __VI_LOAD_REQUEST_AttributeOff(object sender)
        {
            vi_load_request = false;
        }

        void __VI_LOAD_ENABLE_AttributeOn(object sender)
        {
            vi_load_enable = true;
            if (Programs.ContainsKey("YANGSYS_MESSAGE_HANDLER"))
                Programs["YANGSYS_MESSAGE_HANDLER"].Execute();
        }
        void __VI_LOAD_ENABLE_AttributeOff(object sender)
        {
            vi_load_enable = false;
        }

        void __VI_LOAD_HAND_DOWN_COMPLETION_REPLY_AttributeOn(object sender)
        {
            vi_load_hand_down_completion_reply = true;
            if (Programs.ContainsKey("YANGSYS_MESSAGE_HANDLER"))
                Programs["YANGSYS_MESSAGE_HANDLER"].Execute();
        }
        void __VI_LOAD_HAND_DOWN_COMPLETION_REPLY_AttributeOff(object sender)
        {
            vi_load_hand_down_completion_reply = false;
        }

        void __VI_LOAD_COMPLETE_REPLY_AttributeOn(object sender)
        {
            vi_load_complete_reply = true;
            if (Programs.ContainsKey("YANGSYS_MESSAGE_HANDLER"))
                Programs["YANGSYS_MESSAGE_HANDLER"].Execute();
        }
        void __VI_LOAD_COMPLETE_REPLY_AttributeOff(object sender)
        {
            vi_load_complete_reply = false;
        }

        void __VI_UNLOAD_REQUEST_AttributeOn(object sender)
        {
            vi_unload_request = true;
            if (Programs.ContainsKey("YANGSYS_MESSAGE_HANDLER"))
                Programs["YANGSYS_MESSAGE_HANDLER"].Execute();
        }
        void __VI_UNLOAD_REQUEST_AttributeOff(object sender)
        {
            vi_unload_request = false;
        }

        void __VI_UNLOAD_ENABLE_AttributeOn(object sender)
        {
            vi_unload_enable = true;
            if (Programs.ContainsKey("YANGSYS_MESSAGE_HANDLER"))
                Programs["YANGSYS_MESSAGE_HANDLER"].Execute();
        }
        void __VI_UNLOAD_ENABLE_AttributeOff(object sender)
        {
            vi_unload_enable = false;
        }

        void __VI_UNLOAD_HAND_UP_COMPLETION_REPLY_AttributeOn(object sender)
        {
            vi_unload_hand_up_completion_reply = true;
            if (Programs.ContainsKey("YANGSYS_MESSAGE_HANDLER"))
                Programs["YANGSYS_MESSAGE_HANDLER"].Execute();
        }
        void __VI_UNLOAD_HAND_UP_COMPLETION_REPLY_AttributeOff(object sender)
        {
            vi_unload_hand_up_completion_reply = false;
        }

        void __VI_UNLOAD_COMPLETE_REPLY_AttributeOn(object sender)
        {
            vi_unload_complete_reply = true;
            if (Programs.ContainsKey("YANGSYS_MESSAGE_HANDLER"))
                Programs["YANGSYS_MESSAGE_HANDLER"].Execute();
        }
        void __VI_UNLOAD_COMPLETE_REPLY_AttributeOff(object sender)
        {
            vi_unload_complete_reply = false;
        }

        void __VI_INITIALIZE_REQUEST_AttributeOn(object sender)
        {
            vi_initialize_request = true;
            if (Programs.ContainsKey("YANGSYS_MESSAGE_HANDLER"))
                Programs["YANGSYS_MESSAGE_HANDLER"].Execute();
        }
        void __VI_INITIALIZE_REQUEST_AttributeOff(object sender)
        {
            vi_initialize_request = false;
        }

        void __VI_COMMUNICATION_AttributeOn(object sender)
        {
            vi_communication = true;
            if (Programs.ContainsKey("YANGSYS_MESSAGE_HANDLER"))
                Programs["YANGSYS_MESSAGE_HANDLER"].Execute();
        }
        void __VI_COMMUNICATION_AttributeOff(object sender)
        {
            vi_communication = false;
        }

        void __VI_ALIVE_REPLY_AttributeOn(object sender)
        {
            vi_alive_reply = true;
            if (Programs.ContainsKey("YANGSYS_MESSAGE_HANDLER"))
                Programs["YANGSYS_MESSAGE_HANDLER"].Execute();
        }
        void __VI_ALIVE_REPLY_AttributeOff(object sender)
        {
            vi_alive_reply = false;
        }

        void __VI_STATE_REQ_ACK_AttributeOn(object sender)
        {
            vi_state_req_ack = true;
            if (Programs.ContainsKey("YANGSYS_MESSAGE_HANDLER"))
                Programs["YANGSYS_MESSAGE_HANDLER"].Execute();
        }
        void __VI_STATE_REQ_ACK_AttributeOff(object sender)
        {
            vi_state_req_ack = false;
        }

        void __VI_STATE_CHANGE_REQ_ACK_AttributeOn(object sender)
        {
            vi_state_change_req_ack = true;
            if (Programs.ContainsKey("YANGSYS_MESSAGE_HANDLER"))
                Programs["YANGSYS_MESSAGE_HANDLER"].Execute();
        }
        void __VI_STATE_CHANGE_REQ_ACK_AttributeOff(object sender)
        {
            vi_state_change_req_ack = false;
        }

        void __VI_STATE_CHANGE_EVENT_AttributeOn(object sender)
        {
            vi_state_change_event = true;

            if (Programs.ContainsKey("YANGSYS_MESSAGE_HANDLER"))
                Programs["YANGSYS_MESSAGE_HANDLER"].Execute();
            if (Programs.ContainsKey("EQP_STATUS_REPORT"))
                Programs["EQP_STATUS_REPORT"].Execute();
        }
        void __VI_STATE_CHANGE_EVENT_AttributeOff(object sender)
        {
            vi_state_change_event = false;
        }

        void __VI_STAGE_GLASS_EXIST_AttributeOn(object sender)
        {
            vi_stage_glass_exist = true;
            if (Programs.ContainsKey("YANGSYS_MESSAGE_HANDLER"))
                Programs["YANGSYS_MESSAGE_HANDLER"].Execute();
        }
        void __VI_STAGE_GLASS_EXIST_AttributeOff(object sender)
        {
            vi_stage_glass_exist = false;
        }

        void __VI_USER_LOGIN_AttributeOn(object sender)
        {
            vi_user_login = true;
            if (Programs.ContainsKey("YANGSYS_MESSAGE_HANDLER"))
                Programs["YANGSYS_MESSAGE_HANDLER"].Execute();
        }
        void __VI_USER_LOGIN_AttributeOff(object sender)
        {
            vi_user_login = false;
        }
        
        void __VI_USER_LOGIN_RECIPE_AttributeOn(object sender)
        {
            vi_user_login_recipe = true;
            if (Programs.ContainsKey("YANGSYS_MESSAGE_HANDLER"))
                Programs["YANGSYS_MESSAGE_HANDLER"].Execute();
            //if (CIMMode == 2)
            //{
            //    if (Programs.ContainsKey("RECIPE_CHANGE_AUTHORIZATION"))
            //        Programs["RECIPE_CHANGE_AUTHORIZATION"].Execute();
            //}
        }
        void __VI_USER_LOGIN_RECIPE_AttributeOff(object sender)
        {
            vi_user_login_recipe = false;
        }

        void __VI_GLASS_DATA_SEND_ACK_AttributeOn(object sender)
        {
            vi_glass_data_send_ack = true;
            if (Programs.ContainsKey("YANGSYS_MESSAGE_HANDLER"))
                Programs["YANGSYS_MESSAGE_HANDLER"].Execute();
        }
        void __VI_GLASS_DATA_SEND_ACK_AttributeOff(object sender)
        {
            vi_glass_data_send_ack = false;
        }

        void __VI_LOST_GLASS_DATA_REQUEST_AttributeOn(object sender)
        {
            vi_lost_glass_data_request = true;
            if (Programs.ContainsKey("YANGSYS_MESSAGE_HANDLER"))
                Programs["YANGSYS_MESSAGE_HANDLER"].Execute();
            if (Programs.ContainsKey("GLASS_DATA_REQUEST"))
                Programs["GLASS_DATA_REQUEST"].Execute();
        }
        void __VI_LOST_GLASS_DATA_REQUEST_AttributeOff(object sender)
        {
            vi_lost_glass_data_request = false;
        }

        void __VI_GLASS_SCRAP_AttributeOn(object sender)
        {
            vi_glass_scrap = true;
            if (Programs.ContainsKey("YANGSYS_MESSAGE_HANDLER"))
                Programs["YANGSYS_MESSAGE_HANDLER"].Execute();

            //if (Programs.ContainsKey("REMOVED_JOB_REPORT"))
            //    Programs["REMOVED_JOB_REPORT"].Execute();
        }
        void __VI_GLASS_SCRAP_AttributeOff(object sender)
        {
            vi_glass_scrap = false;
        }

        void __VI_JOB_HOLD_EVENT_REPORT_AttributeOn(object sender)
        {
            vi_job_hold_event_report = true;
            if (Programs.ContainsKey("YANGSYS_MESSAGE_HANDLER"))
                Programs["YANGSYS_MESSAGE_HANDLER"].Execute();
        }
        void __VI_JOB_HOLD_EVENT_REPORT_AttributeOff(object sender)
        {
            vi_job_hold_event_report = false;
        }

        void __VI_ALARM_SET_AttributeOn(object sender)
        {
            vi_alarm_set = true;
            if (Programs.ContainsKey("YANGSYS_MESSAGE_HANDLER"))
                Programs["YANGSYS_MESSAGE_HANDLER"].Execute();
            //if (Programs.ContainsKey("ALARM_SET_STATUS_REPORT"))
            //    Programs["ALARM_SET_STATUS_REPORT"].Execute();
        }
        void __VI_ALARM_SET_AttributeOff(object sender)
        {
            vi_alarm_set = false;
        }

        void __VI_ALARM_RESET_AttributeOn(object sender)
        {
            vi_alarm_reset = true;
            if (Programs.ContainsKey("YANGSYS_MESSAGE_HANDLER"))
                Programs["YANGSYS_MESSAGE_HANDLER"].Execute();
            //if (Programs.ContainsKey("ALARM_RESET_STATUS_REPORT"))
            //    Programs["ALARM_RESET_STATUS_REPORT"].Execute();
        }
        void __VI_ALARM_RESET_AttributeOff(object sender)
        {
            vi_alarm_reset = false;
        }

        void __VI_ALARM_SET_REQUEST_REPLY_AttributeOn(object sender)
        {
            vi_alarm_set_request_reply = true;
            if (Programs.ContainsKey("YANGSYS_MESSAGE_HANDLER"))
                Programs["YANGSYS_MESSAGE_HANDLER"].Execute();
        }
        void __VI_ALARM_SET_REQUEST_REPLY_AttributeOff(object sender)
        {
            vi_alarm_set_request_reply = false;
        }

        void __VI_RECIPE_LIST_REQ_REPLY_AttributeOn(object sender)
        {
            vi_recipe_list_req_reply = true;
            if (Programs.ContainsKey("YANGSYS_MESSAGE_HANDLER"))
                Programs["YANGSYS_MESSAGE_HANDLER"].Execute();
        }
        void __VI_RECIPE_LIST_REQ_REPLY_AttributeOff(object sender)
        {
            vi_recipe_list_req_reply = false;
        }

        void __VI_CURRENT_RECIPE_CHANGE_AttributeOn(object sender)
        {
            vi_current_recipe_change = true;
            if (Programs.ContainsKey("YANGSYS_MESSAGE_HANDLER"))
                Programs["YANGSYS_MESSAGE_HANDLER"].Execute();
            //if (Programs.ContainsKey("CURRENT_PPID_RECIPE_REPORT"))
            //    Programs["CURRENT_PPID_RECIPE_REPORT"].Execute();
        }
        void __VI_CURRENT_RECIPE_CHANGE_AttributeOff(object sender)
        {
            vi_current_recipe_change = false;
        }

        void __VI_RECIPE_REPORT_AttributeOn(object sender)
        {
            vi_recipe_report = true;
            //if (Programs.ContainsKey("YANGSYS_MESSAGE_HANDLER"))
            //    Programs["YANGSYS_MESSAGE_HANDLER"].Execute();
            //if (CIMMode == 2)
            //{
            //    if (Programs.ContainsKey("RECIPE_CHANGE_REPORT"))
            //        Programs["RECIPE_CHANGE_REPORT"].Execute();
            //}
        }
        void __VI_RECIPE_REPORT_AttributeOff(object sender)
        {
            vi_recipe_report = false;
        }

        void __VI_BUZZER_REPLY_AttributeOn(object sender)
        {
            vi_buzzer_reply = true;
            if (Programs.ContainsKey("YANGSYS_MESSAGE_HANDLER"))
                Programs["YANGSYS_MESSAGE_HANDLER"].Execute();
        }
        void __VI_BUZZER_REPLY_AttributeOff(object sender)
        {
            vi_buzzer_reply = false;
        }

        void __VI_GLASS_DATA_VALUE_FILE_REPORT_AttributeOn(object sender)
        {
            vi_glass_data_value_file_report = true;
            if (Programs.ContainsKey("YANGSYS_MESSAGE_HANDLER"))
                Programs["YANGSYS_MESSAGE_HANDLER"].Execute();
            //if (Programs.ContainsKey("PROCESS_DATA_REPORT"))
            //    Programs["PROCESS_DATA_REPORT"].Execute();
        }
        void __VI_GLASS_DATA_VALUE_FILE_REPORT_AttributeOff(object sender)
        {
            vi_glass_data_value_file_report = false;
        }

        void __VI_IONIZER_AttributeOn(object sender)
        {
            vi_ionizer = true;
            if (Programs.ContainsKey("YANGSYS_MESSAGE_HANDLER"))
                Programs["YANGSYS_MESSAGE_HANDLER"].Execute();
        }
        void __VI_IONIZER_AttributeOff(object sender)
        {
            vi_ionizer = false;
        }

        void __VI_AUTO_MODE_CHANGE_EVENT_AttributeOn(object sender)
        {
            vi_auto_mode_change_event = true;
            if (Programs.ContainsKey("YANGSYS_MESSAGE_HANDLER"))
                Programs["YANGSYS_MESSAGE_HANDLER"].Execute();
            if (CIMMode == 2)
            {
                if (Programs.ContainsKey("EQUIPMENT_AUTO_MODE_NOTIFICATION"))
                    Programs["EQUIPMENT_AUTO_MODE_NOTIFICATION"].Execute();
            }
        }
        void __VI_AUTO_MODE_CHANGE_EVENT_AttributeOff(object sender)
        {
            vi_auto_mode_change_event = false;
        }

        void __VI_OXR_INFORMATION_UPDATE_AttributeOn(object sender)
        {
            vi_oxr_information_update = true;
            if (Programs.ContainsKey("YANGSYS_MESSAGE_HANDLER"))
                Programs["YANGSYS_MESSAGE_HANDLER"].Execute();
        }
        void __VI_OXR_INFORMATION_UPDATE_AttributeOff(object sender)
        {
            vi_oxr_information_update = false;
        }

        void __VI_OXR_INFORMATION_REQUEST_DATA_REPLY_AttributeOn(object sender)
        {
            vi_oxr_information_request_data_reply = true;
            if (Programs.ContainsKey("YANGSYS_MESSAGE_HANDLER"))
                Programs["YANGSYS_MESSAGE_HANDLER"].Execute();
        }
        void __VI_OXR_INFORMATION_REQUEST_DATA_REPLY_AttributeOff(object sender)
        {
            vi_oxr_information_request_data_reply = false;
        }

        void __VI_TRACKING_DATA_AttributeOn(object sender)
        {
            vi_tracking_data = true;
            if (Programs.ContainsKey("YANGSYS_MESSAGE_HANDLER"))
                Programs["YANGSYS_MESSAGE_HANDLER"].Execute();
        }
        void __VI_TRACKING_DATA_AttributeOff(object sender)
        {
            vi_tracking_data = false;
        }

        void __VI_TRANSFER_STOP_REPLY_AttributeOn(object sender)
        {
            vi_transfer_stop_reply = true;
            if (Programs.ContainsKey("YANGSYS_MESSAGE_HANDLER"))
                Programs["YANGSYS_MESSAGE_HANDLER"].Execute();
        }
        void __VI_TRANSFER_STOP_REPLY_AttributeOff(object sender)
        {
            vi_transfer_stop_reply = false;
        }

        void __VI_CIM_MESSAGE_ON_REPLY_AttributeOn(object sender)
        {
            vi_cim_message_on_reply = true;
            if (Programs.ContainsKey("YANGSYS_MESSAGE_HANDLER"))
                Programs["YANGSYS_MESSAGE_HANDLER"].Execute();
        }
        void __VI_CIM_MESSAGE_ON_REPLY_AttributeOff(object sender)
        {
            vi_cim_message_on_reply = false;
        }

        void __VI_RECOVERY_GLASS_DATA_SEND_ACK_AttributeOn(object sender)
        {
            vi_recovery_glass_data_send_ack = true;
            if (Programs.ContainsKey("YANGSYS_MESSAGE_HANDLER"))
                Programs["YANGSYS_MESSAGE_HANDLER"].Execute();
        }
        void __VI_RECOVERY_GLASS_DATA_SEND_ACK_AttributeOff(object sender)
        {
            vi_recovery_glass_data_send_ack = false;
        }

        void __VI_SVID_SEND_AttributeOn(object sender)
        {
            vi_svid_send = true;
            if (Programs.ContainsKey("YANGSYS_MESSAGE_HANDLER"))
                Programs["YANGSYS_MESSAGE_HANDLER"].Execute();
            if (Programs.ContainsKey("SV_DATA_REPORT"))
                Programs["SV_DATA_REPORT"].Execute();
        }

        void __VI_SVID_SEND_AttributeOff(object sender)
        {
            vi_svid_send = false;

        }

        void __VI_MACHINE_MODE_CHANGE_REPORT_AttributeOff(object sender)
        {
            vi_machine_mode_change_report = false;
        }

        void __VI_MACHINE_MODE_CHANGE_REPORT_AttributeOn(object sender)
        {
            vi_machine_mode_change_report = true;
            if (Programs.ContainsKey("YANGSYS_MESSAGE_HANDLER"))
                Programs["YANGSYS_MESSAGE_HANDLER"].Execute();

            if (Programs.ContainsKey("MACHINE_MODE_CHANGE_REPORT"))
                Programs["MACHINE_MODE_CHANGE_REPORT"].Execute();
        
        }

        void __VI_MACHINE_MODE_CHANGE_REQUEST_REPLY_AttributeOff(object sender)
        {
            vi_machine_mode_change_request_reply = false;
        }

        void __VI_MACHINE_MODE_CHANGE_REQUEST_REPLY_AttributeOn(object sender)
        {
            vi_machine_mode_change_request_reply = true;
            if (Programs.ContainsKey("YANGSYS_MESSAGE_HANDLER"))
                Programs["YANGSYS_MESSAGE_HANDLER"].Execute();
        }

        void __VI_CVID_REPORT_TIME_CHANGE_ACK_AttributeOff(object sender)
        {
            vi_cvid_report_time_change_ack = false;
        }

        void __VI_CVID_REPORT_TIME_CHANGE_ACK_AttributeOn(object sender)
        {
            vi_cvid_report_time_change_ack = true;
            if (Programs.ContainsKey("YANGSYS_MESSAGE_HANDLER"))
                Programs["YANGSYS_MESSAGE_HANDLER"].Execute();
        }

        void __VI_CVID_SEND_AttributeOff(object sender)
        {
            vi_cvid_send = false;
        }

        void __VI_CVID_SEND_AttributeOn(object sender)
        {
            vi_cvid_send = true;
            if (Programs.ContainsKey("YANGSYS_MESSAGE_HANDLER"))
                Programs["YANGSYS_MESSAGE_HANDLER"].Execute();
            if (Programs.ContainsKey("CV_DATA_REPORT"))
                Programs["CV_DATA_REPORT"].Execute();
        }

        void __VI_PROCESS_STATUS_SEND_AttributeOff(object sender)
        {
            vi_process_status_send = false;
        }

        void __VI_PROCESS_STATUS_SEND_AttributeOn(object sender)
        {
            vi_process_status_send = true;
            if (Programs.ContainsKey("YANGSYS_MESSAGE_HANDLER"))
                Programs["YANGSYS_MESSAGE_HANDLER"].Execute();
        }

        void __VI_CIM_MODE_REPLY_AttributeOff(object sender)
        {
            vi_cim_mode_reply = false;
        }

        void __VI_CIM_MODE_REPLY_AttributeOn(object sender)
        {
            vi_cim_mode_reply = true;
            if (Programs.ContainsKey("YANGSYS_MESSAGE_HANDLER"))
                Programs["YANGSYS_MESSAGE_HANDLER"].Execute();
        }

        void __VI_SHUTTER_STATUS_SEND_AttributeOff(object sender)
        {
            vi_shutter_Status_send = false;
        }

        void __VI_SHUTTER_STATUS_SEND_AttributeOn(object sender)
        {
            vi_shutter_Status_send = true;
            if (Programs.ContainsKey("YANGSYS_MESSAGE_HANDLER"))
                Programs["YANGSYS_MESSAGE_HANDLER"].Execute();
        }

        void __VI_RECIPE_REQUEST_REPLY_AttributeOff(object sender)
        {
            vi_recipe_request_reply = false;
        }

        void __VI_RECIPE_REQUEST_REPLY_AttributeOn(object sender)
        {
            vi_recipe_request_reply = true;
            if (Programs.ContainsKey("YANGSYS_MESSAGE_HANDLER"))
                Programs["YANGSYS_MESSAGE_HANDLER"].Execute();
        }

        void __VI_RECIPE_CHANGE_REPORT_AttributeOn(object sender)
        {
            vi_recipe_change_report = true;
            if (Programs.ContainsKey("YANGSYS_MESSAGE_HANDLER"))
                Programs["YANGSYS_MESSAGE_HANDLER"].Execute();
            if (CIMMode == 2)
            {
                if (Programs.ContainsKey("RECIPE_CHANGE_REPORT"))
                    Programs["RECIPE_CHANGE_REPORT"].Execute();
            }
        }
        void __VI_RECIPE_CHANGE_REPORT_AttributeOff(object sender)
        {
            vi_recipe_change_report = false;
        }

        void __IB_TERMINAL_TEXT_AttributeOn(object sender)
        {
            ib_terminal_text = true;
            if (Programs.ContainsKey("TERMINAL_TEXT"))
                Programs["TERMINAL_TEXT"].Execute();
        }

        void __IB_TERMINAL_TEXT_AttributeOff(object sender)
        {
            ib_terminal_text = false;
        }

        void __IB_OPERATOR_CALL_AttributeOn(object sender)
        {
            ib_operator_call = true;
            if (Programs.ContainsKey("OPERATOR_CALL"))
                Programs["OPERATOR_CALL"].Execute();
        }

        void __IB_OPERATOR_CALL_AttributeOff(object sender)
        {
            ib_operator_call = false;
        }

        void __IB_LD_BUZZ_ON_AttributeOn(object sender)
        {
            ib_ld_buzz_on = true;
            if (Programs.ContainsKey("LD_BUZZ_ON"))
                Programs["LD_BUZZ_ON"].Execute();
        }

        void __IB_LD_BUZZ_ON_AttributeOff(object sender)
        {
            ib_ld_buzz_on = false;
        }

        void __IB_DATE_TIME_SET_AttributeOn(object sender)
        {
            ib_date_time_set = true;
            if (Programs.ContainsKey("DATE_TIME_SET"))
                Programs["DATE_TIME_SET"].Execute();
        }

        void __IB_DATE_TIME_SET_AttributeOff(object sender)
        {
            ib_date_time_set = false;
        }

        void __IB_PPID_RECIPE_ID_MAP_CHANGE_AttributeOn(object sender)
        {
            ib_ppid_recipe_id_map_change = true;
            if (Programs.ContainsKey("PPID_RECIPE_ID_MAP_CHANGE"))
                Programs["PPID_RECIPE_ID_MAP_CHANGE"].Execute();
        }

        void __IB_PPID_RECIPE_ID_MAP_CHANGE_AttributeOff(object sender)
        {
            ib_ppid_recipe_id_map_change = false;
        }


        void __IB_EQUIPMENT_MODE_CHANGE_AttributeOn(object sender)
        {
            ib_equipment_mode_change = true;
            if (Programs.ContainsKey("EQUIPMENT_MODE_CHANGE"))
                Programs["EQUIPMENT_MODE_CHANGE"].Execute();
        }

        void __IB_EQUIPMENT_MODE_CHANGE_AttributeOff(object sender)
        {
            ib_equipment_mode_change = false;
        }


        void __IB_PPID_RECIPE_MAP_REQUEST_AttributeOn(object sender)
        {
            ib_ppid_recipe_map_request = true;
            if (Programs.ContainsKey("PPID_RECIPE_MAP_REQUEST"))
                Programs["PPID_RECIPE_MAP_REQUEST"].Execute();
        }

        void __IB_PPID_RECIPE_MAP_REQUEST_AttributeOff(object sender)
        {
            ib_ppid_recipe_map_request = false;
        }


        void __IB_RECIPE_REQUEST_AttributeOn(object sender)
        {
            ib_recipe_request = true;
            if (Programs.ContainsKey("RECIPE_REQUEST"))
                Programs["RECIPE_REQUEST"].Execute();
        }

        void __IB_RECIPE_REQUEST_AttributeOff(object sender)
        {
            ib_recipe_request = false;
        }
        #endregion

        //public bool GetDownstreamInline()
        //{
        //    if (this.EqpStatus == 3 || this.EqpStatus == 4)
        //    {
        //        return false;
        //    }
        //    else 
        //    {
        //        if (DownStreamInlineMode == true)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }

        //    //return true;
        //}

        public bool GetDownstreamTrouble()
        {
            if (this.EqpStatus == 3 || this.EqpStatus == 5)
            {
                return true;
            }
            return false;
        }

        //public bool GetUpstreamInline()
        //{
        //    if (this.EqpStatus == 3 || this.EqpStatus == 4)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        if (UpStreamInlineMode == true)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //}

        public bool GetUpstreamTrouble()
        {
            if (this.EqpStatus == 3 || this.EqpStatus == 5)
            {
                return true;
            }
            return false;
        }
    }

    public class CProbeControlCollection : Dictionary<string, CProbeControl>
    {
        public CProbeControl GetControl(string controlName)
        {
            if (this.ContainsKey(controlName))
            {
                return this[controlName];
            }

            return null;
        }
    }
}
