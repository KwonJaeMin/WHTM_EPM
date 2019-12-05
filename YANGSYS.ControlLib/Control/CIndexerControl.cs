using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOFD.Component;
using SOFD.Logger;
using YANGSYS.ControlLib.LogFormat;
using System.Drawing;
using SOFD.Component.Interface;

namespace YANGSYS.ControlLib
{
    public partial class CIndexerControl : CBasicControl
    {
        public string MachineID { get; set; }
        public string UnitNo { get; set; }
        public string ImageType { get; set; }
        public int DrawIndex { get; set; }

        #region //bit Property
        public bool ib_link_up_upstream_inline { get; set; }
        public bool ib_link_up_upstream_trouble { get; set; }
        public bool ib_link_up_slot_number1 { get; set; }
        public bool ib_link_up_slot_number2 { get; set; }
        public bool ib_link_up_slot_number3 { get; set; }
        public bool ib_link_up_slot_number4 { get; set; }
        public bool ib_link_up_slot_number5 { get; set; }
        public bool ib_link_up_slot_pair_flag { get; set; }
        public bool ib_link_up_arm_slot_pair_flag { get; set; }
        public bool ib_link_up_job_transfer_signal { get; set; }
        public bool ib_link_up_send_able { get; set; }
        public bool ib_link_up_send_start { get; set; }
        public bool ib_link_up_send_complete { get; set; }
        public bool ib_link_up_exchange_possible { get; set; }
        public bool ib_link_up_exchange_execute { get; set; }
        public bool ib_link_up_resume_request { get; set; }
        public bool ib_link_up_resume_ack { get; set; }
        public bool ib_link_up_cancel_request { get; set; }
        public bool ib_link_up_cancel_ack { get; set; }
        public bool ib_link_up_abort_request { get; set; }
        public bool ib_link_up_abort_ack { get; set; }
        public bool ib_link_up_conveyer_state { get; set; }
        public bool ib_link_up_shutter_state { get; set; }
        public bool ib_link_up_first_slot_exist { get; set; }
        public bool ib_link_up_second_slot_exist { get; set; }
        public bool ib_link_up_third_slot_exist { get; set; }
        public bool ib_link_up_fourth_slot_exist { get; set; }
        public bool ib_link_up_chk_abnormal { get; set; }
        public bool ib_link_up_chk_empty { get; set; }
        public bool ib_link_up_chk_idle { get; set; }
        public bool ib_link_up_chk_run { get; set; }
        public bool ib_link_up_chk_complete { get; set; }
        public bool ib_link_up_chk_pin_up { get; set; }
        public bool ib_link_up_chk_pin_down { get; set; }
        public bool ib_link_up_chk_stopper_up_chk_or_door_open { get; set; }
        public bool ib_link_up_chk_stopper_down_or_door_close { get; set; }
        public bool ib_link_up_chk_manual_operation { get; set; }
        public bool ib_link_up_chk_body_moving { get; set; }
        public bool ib_link_up_chk_glass_exist_arm1 { get; set; }
        public bool ib_link_up_chk_glass_exist_arm2 { get; set; }
        public bool ib_link_up_chk_glass_exist_arm3 { get; set; }
        public bool ib_link_up_chk_glass_exist_arm4 { get; set; }
        public bool ib_link_up_chk_make_define1 { get; set; }
        public bool ib_link_up_chk_make_define2 { get; set; }
        public bool ib_link_up_chk_make_define3 { get; set; }
        public bool ib_link_up_chk_make_define4 { get; set; }
        public bool ib_link_up_chk_make_define5 { get; set; }
        public bool ib_link_up_chk_make_define6 { get; set; }
        public bool ib_link_up_chk_make_define7 { get; set; }
        public bool ib_link_up_chk_make_define8 { get; set; }
        public bool ib_link_down_downstream_inline { get; set; }
        public bool ib_link_down_downstream_trouble { get; set; }
        public bool ib_link_down_slot_number1 { get; set; }
        public bool ib_link_down_slot_number2 { get; set; }
        public bool ib_link_down_slot_number3 { get; set; }
        public bool ib_link_down_slot_number4 { get; set; }
        public bool ib_link_down_slot_pair_flag { get; set; }
        public bool ib_link_down_arm_slot_pair_flag { get; set; }
        public bool ib_link_down_job_transfer_signal { get; set; }
        public bool ib_link_down_receive_able { get; set; }
        public bool ib_link_down_receive_start { get; set; }
        public bool ib_link_down_receive_complete { get; set; }
        public bool ib_link_down_exchange_possible { get; set; }
        public bool ib_link_down_exchange_execute { get; set; }
        public bool ib_link_down_resume_request { get; set; }
        public bool ib_link_down_resume_ack { get; set; }
        public bool ib_link_down_cancel_request { get; set; }
        public bool ib_link_down_cancel_ack { get; set; }
        public bool ib_link_down_abort_request { get; set; }
        public bool ib_link_down_abort_ack { get; set; }
        public bool ib_link_down_conveyer_state { get; set; }
        public bool ib_link_down_shutter_state { get; set; }
        public bool ib_link_down_first_slot_exist { get; set; }
        public bool ib_link_down_second_slot_exist { get; set; }
        public bool ib_link_down_third_slot_exist { get; set; }
        public bool ib_link_down_fourth_slot_exist { get; set; }
        public bool ib_link_down_abnormal { get; set; }
        public bool ib_link_down_empty { get; set; }
        public bool ib_link_down_idle { get; set; }
        public bool ib_link_down_run { get; set; }
        public bool ib_link_down_complete { get; set; }
        public bool ib_link_down_lift_up_or_pin_up { get; set; }
        public bool ib_link_down_lift_down_or_pin_down { get; set; }
        public bool ib_link_down_stopper_up_or_door_open { get; set; }
        public bool ib_link_down_stopper_down_or_door_close { get; set; }
        public bool ib_link_down_manual_operation { get; set; }
        public bool ib_link_down_body_moving { get; set; }
        public bool ib_link_down_glass_exist_arm1 { get; set; }
        public bool ib_link_down_glass_exist_arm2 { get; set; }
        public bool ib_link_down_glass_exist_arm3 { get; set; }
        public bool ib_link_down_glass_exist_arm4 { get; set; }
        public bool ib_link_down_make_define1 { get; set; }
        public bool ib_link_down_make_define2 { get; set; }
        public bool ib_link_down_make_define3 { get; set; }
        public bool ib_link_down_make_define4 { get; set; }
        public bool ib_link_down_make_define5 { get; set; }
        public bool ib_link_down_make_define6 { get; set; }
        public bool ib_link_down_make_define7 { get; set; }
        public bool ib_link_down_make_define8 { get; set; }

        #endregion

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
                    case "IB_LINK_UP_UPSTREAM_INLINE":
                        __IB_LINK_UP_UPSTREAM_INLINE.AttributeOn += new delegateAttributeEvent(__IB_LINK_UP_UPSTREAM_INLINE_AttributeOn);
                        __IB_LINK_UP_UPSTREAM_INLINE.AttributeOff += new delegateAttributeEvent(__IB_LINK_UP_UPSTREAM_INLINE_AttributeOff);
                        break;
                    case "IB_LINK_UP_UPSTREAM_TROUBLE":
                        __IB_LINK_UP_UPSTREAM_TROUBLE.AttributeOn += new delegateAttributeEvent(__IB_LINK_UP_UPSTREAM_TROUBLE_AttributeOn);
                        __IB_LINK_UP_UPSTREAM_TROUBLE.AttributeOff += new delegateAttributeEvent(__IB_LINK_UP_UPSTREAM_TROUBLE_AttributeOff);
                        break;
                    case "IB_LINK_UP_SLOT_NUMBER1":
                        __IB_LINK_UP_SLOT_NUMBER1.AttributeOn += new delegateAttributeEvent(__IB_LINK_UP_SLOT_NUMBER1_AttributeOn);
                        __IB_LINK_UP_SLOT_NUMBER1.AttributeOff += new delegateAttributeEvent(__IB_LINK_UP_SLOT_NUMBER1_AttributeOff);
                        break;
                    case "IB_LINK_UP_SLOT_NUMBER2":
                        __IB_LINK_UP_SLOT_NUMBER2.AttributeOn += new delegateAttributeEvent(__IB_LINK_UP_SLOT_NUMBER2_AttributeOn);
                        __IB_LINK_UP_SLOT_NUMBER2.AttributeOff += new delegateAttributeEvent(__IB_LINK_UP_SLOT_NUMBER2_AttributeOff);
                        break;
                    case "IB_LINK_UP_SLOT_NUMBER3":
                        __IB_LINK_UP_SLOT_NUMBER3.AttributeOn += new delegateAttributeEvent(__IB_LINK_UP_SLOT_NUMBER3_AttributeOn);
                        __IB_LINK_UP_SLOT_NUMBER3.AttributeOff += new delegateAttributeEvent(__IB_LINK_UP_SLOT_NUMBER3_AttributeOff);
                        break;
                    case "IB_LINK_UP_SLOT_NUMBER4":
                        __IB_LINK_UP_SLOT_NUMBER4.AttributeOn += new delegateAttributeEvent(__IB_LINK_UP_SLOT_NUMBER4_AttributeOn);
                        __IB_LINK_UP_SLOT_NUMBER4.AttributeOff += new delegateAttributeEvent(__IB_LINK_UP_SLOT_NUMBER4_AttributeOff);
                        break;
                    case "IB_LINK_UP_SLOT_NUMBER5":
                        __IB_LINK_UP_SLOT_NUMBER5.AttributeOn += new delegateAttributeEvent(__IB_LINK_UP_SLOT_NUMBER5_AttributeOn);
                        __IB_LINK_UP_SLOT_NUMBER5.AttributeOff += new delegateAttributeEvent(__IB_LINK_UP_SLOT_NUMBER5_AttributeOff);
                        break;
                    case "IB_LINK_UP_SLOT_PAIR_FLAG":
                        __IB_LINK_UP_SLOT_PAIR_FLAG.AttributeOn += new delegateAttributeEvent(__IB_LINK_UP_SLOT_PAIR_FLAG_AttributeOn);
                        __IB_LINK_UP_SLOT_PAIR_FLAG.AttributeOff += new delegateAttributeEvent(__IB_LINK_UP_SLOT_PAIR_FLAG_AttributeOff);
                        break;
                    case "IB_LINK_UP_ARM_SLOT_PAIR_FLAG":
                        __IB_LINK_UP_ARM_SLOT_PAIR_FLAG.AttributeOn += new delegateAttributeEvent(__IB_LINK_UP_ARM_SLOT_PAIR_FLAG_AttributeOn);
                        __IB_LINK_UP_ARM_SLOT_PAIR_FLAG.AttributeOff += new delegateAttributeEvent(__IB_LINK_UP_ARM_SLOT_PAIR_FLAG_AttributeOff);
                        break;
                    case "IB_LINK_UP_JOB_TRANSFER_SIGNAL":
                        __IB_LINK_UP_JOB_TRANSFER_SIGNAL.AttributeOn += new delegateAttributeEvent(__IB_LINK_UP_JOB_TRANSFER_SIGNAL_AttributeOn);
                        __IB_LINK_UP_JOB_TRANSFER_SIGNAL.AttributeOff += new delegateAttributeEvent(__IB_LINK_UP_JOB_TRANSFER_SIGNAL_AttributeOff);
                        break;
                    case "IB_LINK_UP_SEND_ABLE":
                        __IB_LINK_UP_SEND_ABLE.AttributeOn += new delegateAttributeEvent(__IB_LINK_UP_SEND_ABLE_AttributeOn);
                        __IB_LINK_UP_SEND_ABLE.AttributeOff += new delegateAttributeEvent(__IB_LINK_UP_SEND_ABLE_AttributeOff);
                        break;
                    case "IB_LINK_UP_SEND_START":
                        __IB_LINK_UP_SEND_START.AttributeOn += new delegateAttributeEvent(__IB_LINK_UP_SEND_START_AttributeOn);
                        __IB_LINK_UP_SEND_START.AttributeOff += new delegateAttributeEvent(__IB_LINK_UP_SEND_START_AttributeOff);
                        break;
                    case "IB_LINK_UP_SEND_COMPLETE":
                        __IB_LINK_UP_SEND_COMPLETE.AttributeOn += new delegateAttributeEvent(__IB_LINK_UP_SEND_COMPLETE_AttributeOn);
                        __IB_LINK_UP_SEND_COMPLETE.AttributeOff += new delegateAttributeEvent(__IB_LINK_UP_SEND_COMPLETE_AttributeOff);
                        break;
                    case "IB_LINK_UP_EXCHANGE_POSSIBLE":
                        __IB_LINK_UP_EXCHANGE_POSSIBLE.AttributeOn += new delegateAttributeEvent(__IB_LINK_UP_EXCHANGE_POSSIBLE_AttributeOn);
                        __IB_LINK_UP_EXCHANGE_POSSIBLE.AttributeOff += new delegateAttributeEvent(__IB_LINK_UP_EXCHANGE_POSSIBLE_AttributeOff);
                        break;
                    case "IB_LINK_UP_EXCHANGE_EXECUTE":
                        __IB_LINK_UP_EXCHANGE_EXECUTE.AttributeOn += new delegateAttributeEvent(__IB_LINK_UP_EXCHANGE_EXECUTE_AttributeOn);
                        __IB_LINK_UP_EXCHANGE_EXECUTE.AttributeOff += new delegateAttributeEvent(__IB_LINK_UP_EXCHANGE_EXECUTE_AttributeOff);
                        break;
                    case "IB_LINK_UP_RESUME_REQUEST":
                        __IB_LINK_UP_RESUME_REQUEST.AttributeOn += new delegateAttributeEvent(__IB_LINK_UP_RESUME_REQUEST_AttributeOn);
                        __IB_LINK_UP_RESUME_REQUEST.AttributeOff += new delegateAttributeEvent(__IB_LINK_UP_RESUME_REQUEST_AttributeOff);
                        break;
                    case "IB_LINK_UP_RESUME_ACK":
                        __IB_LINK_UP_RESUME_ACK.AttributeOn += new delegateAttributeEvent(__IB_LINK_UP_RESUME_ACK_AttributeOn);
                        __IB_LINK_UP_RESUME_ACK.AttributeOff += new delegateAttributeEvent(__IB_LINK_UP_RESUME_ACK_AttributeOff);
                        break;
                    case "IB_LINK_UP_CANCEL_REQUEST":
                        __IB_LINK_UP_CANCEL_REQUEST.AttributeOn += new delegateAttributeEvent(__IB_LINK_UP_CANCEL_REQUEST_AttributeOn);
                        __IB_LINK_UP_CANCEL_REQUEST.AttributeOff += new delegateAttributeEvent(__IB_LINK_UP_CANCEL_REQUEST_AttributeOff);
                        break;
                    case "IB_LINK_UP_CANCEL_ACK":
                        __IB_LINK_UP_CANCEL_ACK.AttributeOn += new delegateAttributeEvent(__IB_LINK_UP_CANCEL_ACK_AttributeOn);
                        __IB_LINK_UP_CANCEL_ACK.AttributeOff += new delegateAttributeEvent(__IB_LINK_UP_CANCEL_ACK_AttributeOff);
                        break;
                    case "IB_LINK_UP_ABORT_REQUEST":
                        __IB_LINK_UP_ABORT_REQUEST.AttributeOn += new delegateAttributeEvent(__IB_LINK_UP_ABORT_REQUEST_AttributeOn);
                        __IB_LINK_UP_ABORT_REQUEST.AttributeOff += new delegateAttributeEvent(__IB_LINK_UP_ABORT_REQUEST_AttributeOff);
                        break;
                    case "IB_LINK_UP_ABORT_ACK":
                        __IB_LINK_UP_ABORT_ACK.AttributeOn += new delegateAttributeEvent(__IB_LINK_UP_ABORT_ACK_AttributeOn);
                        __IB_LINK_UP_ABORT_ACK.AttributeOff += new delegateAttributeEvent(__IB_LINK_UP_ABORT_ACK_AttributeOff);
                        break;
                    case "IB_LINK_UP_CONVEYER_STATE":
                        __IB_LINK_UP_CONVEYER_STATE.AttributeOn += new delegateAttributeEvent(__IB_LINK_UP_CONVEYER_STATE_AttributeOn);
                        __IB_LINK_UP_CONVEYER_STATE.AttributeOff += new delegateAttributeEvent(__IB_LINK_UP_CONVEYER_STATE_AttributeOff);
                        break;
                    case "IB_LINK_UP_SHUTTER_STATE":
                        __IB_LINK_UP_SHUTTER_STATE.AttributeOn += new delegateAttributeEvent(__IB_LINK_UP_SHUTTER_STATE_AttributeOn);
                        __IB_LINK_UP_SHUTTER_STATE.AttributeOff += new delegateAttributeEvent(__IB_LINK_UP_SHUTTER_STATE_AttributeOff);
                        break;
                    case "IB_LINK_UP_FIRST_SLOT_EXIST":
                        __IB_LINK_UP_FIRST_SLOT_EXIST.AttributeOn += new delegateAttributeEvent(__IB_LINK_UP_FIRST_SLOT_EXIST_AttributeOn);
                        __IB_LINK_UP_FIRST_SLOT_EXIST.AttributeOff += new delegateAttributeEvent(__IB_LINK_UP_FIRST_SLOT_EXIST_AttributeOff);
                        break;
                    case "IB_LINK_UP_SECOND_SLOT_EXIST":
                        __IB_LINK_UP_SECOND_SLOT_EXIST.AttributeOn += new delegateAttributeEvent(__IB_LINK_UP_SECOND_SLOT_EXIST_AttributeOn);
                        __IB_LINK_UP_SECOND_SLOT_EXIST.AttributeOff += new delegateAttributeEvent(__IB_LINK_UP_SECOND_SLOT_EXIST_AttributeOff);
                        break;
                    case "IB_LINK_UP_THIRD_SLOT_EXIST":
                        __IB_LINK_UP_THIRD_SLOT_EXIST.AttributeOn += new delegateAttributeEvent(__IB_LINK_UP_THIRD_SLOT_EXIST_AttributeOn);
                        __IB_LINK_UP_THIRD_SLOT_EXIST.AttributeOff += new delegateAttributeEvent(__IB_LINK_UP_THIRD_SLOT_EXIST_AttributeOff);
                        break;
                    case "IB_LINK_UP_FOURTH_SLOT_EXIST":
                        __IB_LINK_UP_FOURTH_SLOT_EXIST.AttributeOn += new delegateAttributeEvent(__IB_LINK_UP_FOURTH_SLOT_EXIST_AttributeOn);
                        __IB_LINK_UP_FOURTH_SLOT_EXIST.AttributeOff += new delegateAttributeEvent(__IB_LINK_UP_FOURTH_SLOT_EXIST_AttributeOff);
                        break;
                    case "IB_LINK_UP_CHK_ABNORMAL":
                        __IB_LINK_UP_CHK_ABNORMAL.AttributeOn += new delegateAttributeEvent(__IB_LINK_UP_CHK_ABNORMAL_AttributeOn);
                        __IB_LINK_UP_CHK_ABNORMAL.AttributeOff += new delegateAttributeEvent(__IB_LINK_UP_CHK_ABNORMAL_AttributeOff);
                        break;
                    case "IB_LINK_UP_CHK_EMPTY":
                        __IB_LINK_UP_CHK_EMPTY.AttributeOn += new delegateAttributeEvent(__IB_LINK_UP_CHK_EMPTY_AttributeOn);
                        __IB_LINK_UP_CHK_EMPTY.AttributeOff += new delegateAttributeEvent(__IB_LINK_UP_CHK_EMPTY_AttributeOff);
                        break;
                    case "IB_LINK_UP_CHK_IDLE":
                        __IB_LINK_UP_CHK_IDLE.AttributeOn += new delegateAttributeEvent(__IB_LINK_UP_CHK_IDLE_AttributeOn);
                        __IB_LINK_UP_CHK_IDLE.AttributeOff += new delegateAttributeEvent(__IB_LINK_UP_CHK_IDLE_AttributeOff);
                        break;
                    case "IB_LINK_UP_CHK_RUN":
                        __IB_LINK_UP_CHK_RUN.AttributeOn += new delegateAttributeEvent(__IB_LINK_UP_CHK_RUN_AttributeOn);
                        __IB_LINK_UP_CHK_RUN.AttributeOff += new delegateAttributeEvent(__IB_LINK_UP_CHK_RUN_AttributeOff);
                        break;
                    case "IB_LINK_UP_CHK_COMPLETE":
                        __IB_LINK_UP_CHK_COMPLETE.AttributeOn += new delegateAttributeEvent(__IB_LINK_UP_CHK_COMPLETE_AttributeOn);
                        __IB_LINK_UP_CHK_COMPLETE.AttributeOff += new delegateAttributeEvent(__IB_LINK_UP_CHK_COMPLETE_AttributeOff);
                        break;
                    case "IB_LINK_UP_CHK_PIN_UP":
                        __IB_LINK_UP_CHK_PIN_UP.AttributeOn += new delegateAttributeEvent(__IB_LINK_UP_CHK_PIN_UP_AttributeOn);
                        __IB_LINK_UP_CHK_PIN_UP.AttributeOff += new delegateAttributeEvent(__IB_LINK_UP_CHK_PIN_UP_AttributeOff);
                        break;
                    case "IB_LINK_UP_CHK_PIN_DOWN":
                        __IB_LINK_UP_CHK_PIN_DOWN.AttributeOn += new delegateAttributeEvent(__IB_LINK_UP_CHK_PIN_DOWN_AttributeOn);
                        __IB_LINK_UP_CHK_PIN_DOWN.AttributeOff += new delegateAttributeEvent(__IB_LINK_UP_CHK_PIN_DOWN_AttributeOff);
                        break;
                    case "IB_LINK_UP_CHK_STOPPER_UP_CHK_OR_DOOR_OPEN":
                        __IB_LINK_UP_CHK_STOPPER_UP_CHK_OR_DOOR_OPEN.AttributeOn += new delegateAttributeEvent(__IB_LINK_UP_CHK_STOPPER_UP_CHK_OR_DOOR_OPEN_AttributeOn);
                        __IB_LINK_UP_CHK_STOPPER_UP_CHK_OR_DOOR_OPEN.AttributeOff += new delegateAttributeEvent(__IB_LINK_UP_CHK_STOPPER_UP_CHK_OR_DOOR_OPEN_AttributeOff);
                        break;
                    case "IB_LINK_UP_CHK_STOPPER_DOWN_OR_DOOR_CLOSE":
                        __IB_LINK_UP_CHK_STOPPER_DOWN_OR_DOOR_CLOSE.AttributeOn += new delegateAttributeEvent(__IB_LINK_UP_CHK_STOPPER_DOWN_OR_DOOR_CLOSE_AttributeOn);
                        __IB_LINK_UP_CHK_STOPPER_DOWN_OR_DOOR_CLOSE.AttributeOff += new delegateAttributeEvent(__IB_LINK_UP_CHK_STOPPER_DOWN_OR_DOOR_CLOSE_AttributeOff);
                        break;
                    case "IB_LINK_UP_CHK_MANUAL_OPERATION":
                        __IB_LINK_UP_CHK_MANUAL_OPERATION.AttributeOn += new delegateAttributeEvent(__IB_LINK_UP_CHK_MANUAL_OPERATION_AttributeOn);
                        __IB_LINK_UP_CHK_MANUAL_OPERATION.AttributeOff += new delegateAttributeEvent(__IB_LINK_UP_CHK_MANUAL_OPERATION_AttributeOff);
                        break;
                    case "IB_LINK_UP_CHK_BODY_MOVING":
                        __IB_LINK_UP_CHK_BODY_MOVING.AttributeOn += new delegateAttributeEvent(__IB_LINK_UP_CHK_BODY_MOVING_AttributeOn);
                        __IB_LINK_UP_CHK_BODY_MOVING.AttributeOff += new delegateAttributeEvent(__IB_LINK_UP_CHK_BODY_MOVING_AttributeOff);
                        break;
                    case "IB_LINK_UP_CHK_GLASS_EXIST_ARM1":
                        __IB_LINK_UP_CHK_GLASS_EXIST_ARM1.AttributeOn += new delegateAttributeEvent(__IB_LINK_UP_CHK_GLASS_EXIST_ARM1_AttributeOn);
                        __IB_LINK_UP_CHK_GLASS_EXIST_ARM1.AttributeOff += new delegateAttributeEvent(__IB_LINK_UP_CHK_GLASS_EXIST_ARM1_AttributeOff);
                        break;
                    case "IB_LINK_UP_CHK_GLASS_EXIST_ARM2":
                        __IB_LINK_UP_CHK_GLASS_EXIST_ARM2.AttributeOn += new delegateAttributeEvent(__IB_LINK_UP_CHK_GLASS_EXIST_ARM2_AttributeOn);
                        __IB_LINK_UP_CHK_GLASS_EXIST_ARM2.AttributeOff += new delegateAttributeEvent(__IB_LINK_UP_CHK_GLASS_EXIST_ARM2_AttributeOff);
                        break;
                    case "IB_LINK_UP_CHK_GLASS_EXIST_ARM3":
                        __IB_LINK_UP_CHK_GLASS_EXIST_ARM3.AttributeOn += new delegateAttributeEvent(__IB_LINK_UP_CHK_GLASS_EXIST_ARM3_AttributeOn);
                        __IB_LINK_UP_CHK_GLASS_EXIST_ARM3.AttributeOff += new delegateAttributeEvent(__IB_LINK_UP_CHK_GLASS_EXIST_ARM3_AttributeOff);
                        break;
                    case "IB_LINK_UP_CHK_GLASS_EXIST_ARM4":
                        __IB_LINK_UP_CHK_GLASS_EXIST_ARM4.AttributeOn += new delegateAttributeEvent(__IB_LINK_UP_CHK_GLASS_EXIST_ARM4_AttributeOn);
                        __IB_LINK_UP_CHK_GLASS_EXIST_ARM4.AttributeOff += new delegateAttributeEvent(__IB_LINK_UP_CHK_GLASS_EXIST_ARM4_AttributeOff);
                        break;
                    case "IB_LINK_UP_CHK_MAKE_DEFINE1":
                        __IB_LINK_UP_CHK_MAKE_DEFINE1.AttributeOn += new delegateAttributeEvent(__IB_LINK_UP_CHK_MAKE_DEFINE1_AttributeOn);
                        __IB_LINK_UP_CHK_MAKE_DEFINE1.AttributeOff += new delegateAttributeEvent(__IB_LINK_UP_CHK_MAKE_DEFINE1_AttributeOff);
                        break;
                    case "IB_LINK_UP_CHK_MAKE_DEFINE2":
                        __IB_LINK_UP_CHK_MAKE_DEFINE2.AttributeOn += new delegateAttributeEvent(__IB_LINK_UP_CHK_MAKE_DEFINE2_AttributeOn);
                        __IB_LINK_UP_CHK_MAKE_DEFINE2.AttributeOff += new delegateAttributeEvent(__IB_LINK_UP_CHK_MAKE_DEFINE2_AttributeOff);
                        break;
                    case "IB_LINK_UP_CHK_MAKE_DEFINE3":
                        __IB_LINK_UP_CHK_MAKE_DEFINE3.AttributeOn += new delegateAttributeEvent(__IB_LINK_UP_CHK_MAKE_DEFINE3_AttributeOn);
                        __IB_LINK_UP_CHK_MAKE_DEFINE3.AttributeOff += new delegateAttributeEvent(__IB_LINK_UP_CHK_MAKE_DEFINE3_AttributeOff);
                        break;
                    case "IB_LINK_UP_CHK_MAKE_DEFINE4":
                        __IB_LINK_UP_CHK_MAKE_DEFINE4.AttributeOn += new delegateAttributeEvent(__IB_LINK_UP_CHK_MAKE_DEFINE4_AttributeOn);
                        __IB_LINK_UP_CHK_MAKE_DEFINE4.AttributeOff += new delegateAttributeEvent(__IB_LINK_UP_CHK_MAKE_DEFINE4_AttributeOff);
                        break;
                    case "IB_LINK_UP_CHK_MAKE_DEFINE5":
                        __IB_LINK_UP_CHK_MAKE_DEFINE5.AttributeOn += new delegateAttributeEvent(__IB_LINK_UP_CHK_MAKE_DEFINE5_AttributeOn);
                        __IB_LINK_UP_CHK_MAKE_DEFINE5.AttributeOff += new delegateAttributeEvent(__IB_LINK_UP_CHK_MAKE_DEFINE5_AttributeOff);
                        break;
                    case "IB_LINK_UP_CHK_MAKE_DEFINE6":
                        __IB_LINK_UP_CHK_MAKE_DEFINE6.AttributeOn += new delegateAttributeEvent(__IB_LINK_UP_CHK_MAKE_DEFINE6_AttributeOn);
                        __IB_LINK_UP_CHK_MAKE_DEFINE6.AttributeOff += new delegateAttributeEvent(__IB_LINK_UP_CHK_MAKE_DEFINE6_AttributeOff);
                        break;
                    case "IB_LINK_UP_CHK_MAKE_DEFINE7":
                        __IB_LINK_UP_CHK_MAKE_DEFINE7.AttributeOn += new delegateAttributeEvent(__IB_LINK_UP_CHK_MAKE_DEFINE7_AttributeOn);
                        __IB_LINK_UP_CHK_MAKE_DEFINE7.AttributeOff += new delegateAttributeEvent(__IB_LINK_UP_CHK_MAKE_DEFINE7_AttributeOff);
                        break;
                    case "IB_LINK_UP_CHK_MAKE_DEFINE8":
                        __IB_LINK_UP_CHK_MAKE_DEFINE8.AttributeOn += new delegateAttributeEvent(__IB_LINK_UP_CHK_MAKE_DEFINE8_AttributeOn);
                        __IB_LINK_UP_CHK_MAKE_DEFINE8.AttributeOff += new delegateAttributeEvent(__IB_LINK_UP_CHK_MAKE_DEFINE8_AttributeOff);
                        break;
                    case "IB_LINK_DOWN_DOWNSTREAM_INLINE":
                        __IB_LINK_DOWN_DOWNSTREAM_INLINE.AttributeOn += new delegateAttributeEvent(__IB_LINK_DOWN_DOWNSTREAM_INLINE_AttributeOn);
                        __IB_LINK_DOWN_DOWNSTREAM_INLINE.AttributeOff += new delegateAttributeEvent(__IB_LINK_DOWN_DOWNSTREAM_INLINE_AttributeOff);
                        break;
                    case "IB_LINK_DOWN_DOWNSTREAM_TROUBLE":
                        __IB_LINK_DOWN_DOWNSTREAM_TROUBLE.AttributeOn += new delegateAttributeEvent(__IB_LINK_DOWN_DOWNSTREAM_TROUBLE_AttributeOn);
                        __IB_LINK_DOWN_DOWNSTREAM_TROUBLE.AttributeOff += new delegateAttributeEvent(__IB_LINK_DOWN_DOWNSTREAM_TROUBLE_AttributeOff);
                        break;
                    case "IB_LINK_DOWN_SLOT_NUMBER1":
                        __IB_LINK_DOWN_SLOT_NUMBER1.AttributeOn += new delegateAttributeEvent(__IB_LINK_DOWN_SLOT_NUMBER1_AttributeOn);
                        __IB_LINK_DOWN_SLOT_NUMBER1.AttributeOff += new delegateAttributeEvent(__IB_LINK_DOWN_SLOT_NUMBER1_AttributeOff);
                        break;
                    case "IB_LINK_DOWN_SLOT_NUMBER2":
                        __IB_LINK_DOWN_SLOT_NUMBER2.AttributeOn += new delegateAttributeEvent(__IB_LINK_DOWN_SLOT_NUMBER2_AttributeOn);
                        __IB_LINK_DOWN_SLOT_NUMBER2.AttributeOff += new delegateAttributeEvent(__IB_LINK_DOWN_SLOT_NUMBER2_AttributeOff);
                        break;
                    case "IB_LINK_DOWN_SLOT_NUMBER3":
                        __IB_LINK_DOWN_SLOT_NUMBER3.AttributeOn += new delegateAttributeEvent(__IB_LINK_DOWN_SLOT_NUMBER3_AttributeOn);
                        __IB_LINK_DOWN_SLOT_NUMBER3.AttributeOff += new delegateAttributeEvent(__IB_LINK_DOWN_SLOT_NUMBER3_AttributeOff);
                        break;
                    case "IB_LINK_DOWN_SLOT_NUMBER4":
                        __IB_LINK_DOWN_SLOT_NUMBER4.AttributeOn += new delegateAttributeEvent(__IB_LINK_DOWN_SLOT_NUMBER4_AttributeOn);
                        __IB_LINK_DOWN_SLOT_NUMBER4.AttributeOff += new delegateAttributeEvent(__IB_LINK_DOWN_SLOT_NUMBER4_AttributeOff);
                        break;
                    case "IB_LINK_DOWN_SLOT_PAIR_FLAG":
                        __IB_LINK_DOWN_SLOT_PAIR_FLAG.AttributeOn += new delegateAttributeEvent(__IB_LINK_DOWN_SLOT_PAIR_FLAG_AttributeOn);
                        __IB_LINK_DOWN_SLOT_PAIR_FLAG.AttributeOff += new delegateAttributeEvent(__IB_LINK_DOWN_SLOT_PAIR_FLAG_AttributeOff);
                        break;
                    case "IB_LINK_DOWN_ARM_SLOT_PAIR_FLAG":
                        __IB_LINK_DOWN_ARM_SLOT_PAIR_FLAG.AttributeOn += new delegateAttributeEvent(__IB_LINK_DOWN_ARM_SLOT_PAIR_FLAG_AttributeOn);
                        __IB_LINK_DOWN_ARM_SLOT_PAIR_FLAG.AttributeOff += new delegateAttributeEvent(__IB_LINK_DOWN_ARM_SLOT_PAIR_FLAG_AttributeOff);
                        break;
                    case "IB_LINK_DOWN_JOB_TRANSFER_SIGNAL":
                        __IB_LINK_DOWN_JOB_TRANSFER_SIGNAL.AttributeOn += new delegateAttributeEvent(__IB_LINK_DOWN_JOB_TRANSFER_SIGNAL_AttributeOn);
                        __IB_LINK_DOWN_JOB_TRANSFER_SIGNAL.AttributeOff += new delegateAttributeEvent(__IB_LINK_DOWN_JOB_TRANSFER_SIGNAL_AttributeOff);
                        break;
                    case "IB_LINK_DOWN_RECEIVE_ABLE":
                        __IB_LINK_DOWN_RECEIVE_ABLE.AttributeOn += new delegateAttributeEvent(__IB_LINK_DOWN_RECEIVE_ABLE_AttributeOn);
                        __IB_LINK_DOWN_RECEIVE_ABLE.AttributeOff += new delegateAttributeEvent(__IB_LINK_DOWN_RECEIVE_ABLE_AttributeOff);
                        break;
                    case "IB_LINK_DOWN_RECEIVE_START":
                        __IB_LINK_DOWN_RECEIVE_START.AttributeOn += new delegateAttributeEvent(__IB_LINK_DOWN_RECEIVE_START_AttributeOn);
                        __IB_LINK_DOWN_RECEIVE_START.AttributeOff += new delegateAttributeEvent(__IB_LINK_DOWN_RECEIVE_START_AttributeOff);
                        break;
                    case "IB_LINK_DOWN_RECEIVE_COMPLETE":
                        __IB_LINK_DOWN_RECEIVE_COMPLETE.AttributeOn += new delegateAttributeEvent(__IB_LINK_DOWN_RECEIVE_COMPLETE_AttributeOn);
                        __IB_LINK_DOWN_RECEIVE_COMPLETE.AttributeOff += new delegateAttributeEvent(__IB_LINK_DOWN_RECEIVE_COMPLETE_AttributeOff);
                        break;
                    case "IB_LINK_DOWN_EXCHANGE_POSSIBLE":
                        __IB_LINK_DOWN_EXCHANGE_POSSIBLE.AttributeOn += new delegateAttributeEvent(__IB_LINK_DOWN_EXCHANGE_POSSIBLE_AttributeOn);
                        __IB_LINK_DOWN_EXCHANGE_POSSIBLE.AttributeOff += new delegateAttributeEvent(__IB_LINK_DOWN_EXCHANGE_POSSIBLE_AttributeOff);
                        break;
                    case "IB_LINK_DOWN_EXCHANGE_EXECUTE":
                        __IB_LINK_DOWN_EXCHANGE_EXECUTE.AttributeOn += new delegateAttributeEvent(__IB_LINK_DOWN_EXCHANGE_EXECUTE_AttributeOn);
                        __IB_LINK_DOWN_EXCHANGE_EXECUTE.AttributeOff += new delegateAttributeEvent(__IB_LINK_DOWN_EXCHANGE_EXECUTE_AttributeOff);
                        break;
                    case "IB_LINK_DOWN_RESUME_REQUEST":
                        __IB_LINK_DOWN_RESUME_REQUEST.AttributeOn += new delegateAttributeEvent(__IB_LINK_DOWN_RESUME_REQUEST_AttributeOn);
                        __IB_LINK_DOWN_RESUME_REQUEST.AttributeOff += new delegateAttributeEvent(__IB_LINK_DOWN_RESUME_REQUEST_AttributeOff);
                        break;
                    case "IB_LINK_DOWN_RESUME_ACK":
                        __IB_LINK_DOWN_RESUME_ACK.AttributeOn += new delegateAttributeEvent(__IB_LINK_DOWN_RESUME_ACK_AttributeOn);
                        __IB_LINK_DOWN_RESUME_ACK.AttributeOff += new delegateAttributeEvent(__IB_LINK_DOWN_RESUME_ACK_AttributeOff);
                        break;
                    case "IB_LINK_DOWN_CANCEL_REQUEST":
                        __IB_LINK_DOWN_CANCEL_REQUEST.AttributeOn += new delegateAttributeEvent(__IB_LINK_DOWN_CANCEL_REQUEST_AttributeOn);
                        __IB_LINK_DOWN_CANCEL_REQUEST.AttributeOff += new delegateAttributeEvent(__IB_LINK_DOWN_CANCEL_REQUEST_AttributeOff);
                        break;
                    case "IB_LINK_DOWN_CANCEL_ACK":
                        __IB_LINK_DOWN_CANCEL_ACK.AttributeOn += new delegateAttributeEvent(__IB_LINK_DOWN_CANCEL_ACK_AttributeOn);
                        __IB_LINK_DOWN_CANCEL_ACK.AttributeOff += new delegateAttributeEvent(__IB_LINK_DOWN_CANCEL_ACK_AttributeOff);
                        break;
                    case "IB_LINK_DOWN_ABORT_REQUEST":
                        __IB_LINK_DOWN_ABORT_REQUEST.AttributeOn += new delegateAttributeEvent(__IB_LINK_DOWN_ABORT_REQUEST_AttributeOn);
                        __IB_LINK_DOWN_ABORT_REQUEST.AttributeOff += new delegateAttributeEvent(__IB_LINK_DOWN_ABORT_REQUEST_AttributeOff);
                        break;
                    case "IB_LINK_DOWN_ABORT_ACK":
                        __IB_LINK_DOWN_ABORT_ACK.AttributeOn += new delegateAttributeEvent(__IB_LINK_DOWN_ABORT_ACK_AttributeOn);
                        __IB_LINK_DOWN_ABORT_ACK.AttributeOff += new delegateAttributeEvent(__IB_LINK_DOWN_ABORT_ACK_AttributeOff);
                        break;
                    case "IB_LINK_DOWN_CONVEYER_STATE":
                        __IB_LINK_DOWN_CONVEYER_STATE.AttributeOn += new delegateAttributeEvent(__IB_LINK_DOWN_CONVEYER_STATE_AttributeOn);
                        __IB_LINK_DOWN_CONVEYER_STATE.AttributeOff += new delegateAttributeEvent(__IB_LINK_DOWN_CONVEYER_STATE_AttributeOff);
                        break;
                    case "IB_LINK_DOWN_SHUTTER_STATE":
                        __IB_LINK_DOWN_SHUTTER_STATE.AttributeOn += new delegateAttributeEvent(__IB_LINK_DOWN_SHUTTER_STATE_AttributeOn);
                        __IB_LINK_DOWN_SHUTTER_STATE.AttributeOff += new delegateAttributeEvent(__IB_LINK_DOWN_SHUTTER_STATE_AttributeOff);
                        break;
                    case "IB_LINK_DOWN_FIRST_SLOT_EXIST":
                        __IB_LINK_DOWN_FIRST_SLOT_EXIST.AttributeOn += new delegateAttributeEvent(__IB_LINK_DOWN_FIRST_SLOT_EXIST_AttributeOn);
                        __IB_LINK_DOWN_FIRST_SLOT_EXIST.AttributeOff += new delegateAttributeEvent(__IB_LINK_DOWN_FIRST_SLOT_EXIST_AttributeOff);
                        break;
                    case "IB_LINK_DOWN_SECOND_SLOT_EXIST":
                        __IB_LINK_DOWN_SECOND_SLOT_EXIST.AttributeOn += new delegateAttributeEvent(__IB_LINK_DOWN_SECOND_SLOT_EXIST_AttributeOn);
                        __IB_LINK_DOWN_SECOND_SLOT_EXIST.AttributeOff += new delegateAttributeEvent(__IB_LINK_DOWN_SECOND_SLOT_EXIST_AttributeOff);
                        break;
                    case "IB_LINK_DOWN_THIRD_SLOT_EXIST":
                        __IB_LINK_DOWN_THIRD_SLOT_EXIST.AttributeOn += new delegateAttributeEvent(__IB_LINK_DOWN_THIRD_SLOT_EXIST_AttributeOn);
                        __IB_LINK_DOWN_THIRD_SLOT_EXIST.AttributeOff += new delegateAttributeEvent(__IB_LINK_DOWN_THIRD_SLOT_EXIST_AttributeOff);
                        break;
                    case "IB_LINK_DOWN_FOURTH_SLOT_EXIST":
                        __IB_LINK_DOWN_FOURTH_SLOT_EXIST.AttributeOn += new delegateAttributeEvent(__IB_LINK_DOWN_FOURTH_SLOT_EXIST_AttributeOn);
                        __IB_LINK_DOWN_FOURTH_SLOT_EXIST.AttributeOff += new delegateAttributeEvent(__IB_LINK_DOWN_FOURTH_SLOT_EXIST_AttributeOff);
                        break;
                    case "IB_LINK_DOWN_ABNORMAL":
                        __IB_LINK_DOWN_ABNORMAL.AttributeOn += new delegateAttributeEvent(__IB_LINK_DOWN_ABNORMAL_AttributeOn);
                        __IB_LINK_DOWN_ABNORMAL.AttributeOff += new delegateAttributeEvent(__IB_LINK_DOWN_ABNORMAL_AttributeOff);
                        break;
                    case "IB_LINK_DOWN_EMPTY":
                        __IB_LINK_DOWN_EMPTY.AttributeOn += new delegateAttributeEvent(__IB_LINK_DOWN_EMPTY_AttributeOn);
                        __IB_LINK_DOWN_EMPTY.AttributeOff += new delegateAttributeEvent(__IB_LINK_DOWN_EMPTY_AttributeOff);
                        break;
                    case "IB_LINK_DOWN_IDLE":
                        __IB_LINK_DOWN_IDLE.AttributeOn += new delegateAttributeEvent(__IB_LINK_DOWN_IDLE_AttributeOn);
                        __IB_LINK_DOWN_IDLE.AttributeOff += new delegateAttributeEvent(__IB_LINK_DOWN_IDLE_AttributeOff);
                        break;
                    case "IB_LINK_DOWN_RUN":
                        __IB_LINK_DOWN_RUN.AttributeOn += new delegateAttributeEvent(__IB_LINK_DOWN_RUN_AttributeOn);
                        __IB_LINK_DOWN_RUN.AttributeOff += new delegateAttributeEvent(__IB_LINK_DOWN_RUN_AttributeOff);
                        break;
                    case "IB_LINK_DOWN_COMPLETE":
                        __IB_LINK_DOWN_COMPLETE.AttributeOn += new delegateAttributeEvent(__IB_LINK_DOWN_COMPLETE_AttributeOn);
                        __IB_LINK_DOWN_COMPLETE.AttributeOff += new delegateAttributeEvent(__IB_LINK_DOWN_COMPLETE_AttributeOff);
                        break;
                    case "IB_LINK_DOWN_LIFT_UP_OR_PIN_UP":
                        __IB_LINK_DOWN_LIFT_UP_OR_PIN_UP.AttributeOn += new delegateAttributeEvent(__IB_LINK_DOWN_LIFT_UP_OR_PIN_UP_AttributeOn);
                        __IB_LINK_DOWN_LIFT_UP_OR_PIN_UP.AttributeOff += new delegateAttributeEvent(__IB_LINK_DOWN_LIFT_UP_OR_PIN_UP_AttributeOff);
                        break;
                    case "IB_LINK_DOWN_LIFT_DOWN_OR_PIN_DOWN":
                        __IB_LINK_DOWN_LIFT_DOWN_OR_PIN_DOWN.AttributeOn += new delegateAttributeEvent(__IB_LINK_DOWN_LIFT_DOWN_OR_PIN_DOWN_AttributeOn);
                        __IB_LINK_DOWN_LIFT_DOWN_OR_PIN_DOWN.AttributeOff += new delegateAttributeEvent(__IB_LINK_DOWN_LIFT_DOWN_OR_PIN_DOWN_AttributeOff);
                        break;
                    case "IB_LINK_DOWN_STOPPER_UP_OR_DOOR_OPEN":
                        __IB_LINK_DOWN_STOPPER_UP_OR_DOOR_OPEN.AttributeOn += new delegateAttributeEvent(__IB_LINK_DOWN_STOPPER_UP_OR_DOOR_OPEN_AttributeOn);
                        __IB_LINK_DOWN_STOPPER_UP_OR_DOOR_OPEN.AttributeOff += new delegateAttributeEvent(__IB_LINK_DOWN_STOPPER_UP_OR_DOOR_OPEN_AttributeOff);
                        break;
                    case "IB_LINK_DOWN_STOPPER_DOWN_OR_DOOR_CLOSE":
                        __IB_LINK_DOWN_STOPPER_DOWN_OR_DOOR_CLOSE.AttributeOn += new delegateAttributeEvent(__IB_LINK_DOWN_STOPPER_DOWN_OR_DOOR_CLOSE_AttributeOn);
                        __IB_LINK_DOWN_STOPPER_DOWN_OR_DOOR_CLOSE.AttributeOff += new delegateAttributeEvent(__IB_LINK_DOWN_STOPPER_DOWN_OR_DOOR_CLOSE_AttributeOff);
                        break;
                    case "IB_LINK_DOWN_MANUAL_OPERATION":
                        __IB_LINK_DOWN_MANUAL_OPERATION.AttributeOn += new delegateAttributeEvent(__IB_LINK_DOWN_MANUAL_OPERATION_AttributeOn);
                        __IB_LINK_DOWN_MANUAL_OPERATION.AttributeOff += new delegateAttributeEvent(__IB_LINK_DOWN_MANUAL_OPERATION_AttributeOff);
                        break;
                    case "IB_LINK_DOWN_BODY_MOVING":
                        __IB_LINK_DOWN_BODY_MOVING.AttributeOn += new delegateAttributeEvent(__IB_LINK_DOWN_BODY_MOVING_AttributeOn);
                        __IB_LINK_DOWN_BODY_MOVING.AttributeOff += new delegateAttributeEvent(__IB_LINK_DOWN_BODY_MOVING_AttributeOff);
                        break;
                    case "IB_LINK_DOWN_GLASS_EXIST_ARM1":
                        __IB_LINK_DOWN_GLASS_EXIST_ARM1.AttributeOn += new delegateAttributeEvent(__IB_LINK_DOWN_GLASS_EXIST_ARM1_AttributeOn);
                        __IB_LINK_DOWN_GLASS_EXIST_ARM1.AttributeOff += new delegateAttributeEvent(__IB_LINK_DOWN_GLASS_EXIST_ARM1_AttributeOff);
                        break;
                    case "IB_LINK_DOWN_GLASS_EXIST_ARM2":
                        __IB_LINK_DOWN_GLASS_EXIST_ARM2.AttributeOn += new delegateAttributeEvent(__IB_LINK_DOWN_GLASS_EXIST_ARM2_AttributeOn);
                        __IB_LINK_DOWN_GLASS_EXIST_ARM2.AttributeOff += new delegateAttributeEvent(__IB_LINK_DOWN_GLASS_EXIST_ARM2_AttributeOff);
                        break;
                    case "IB_LINK_DOWN_GLASS_EXIST_ARM3":
                        __IB_LINK_DOWN_GLASS_EXIST_ARM3.AttributeOn += new delegateAttributeEvent(__IB_LINK_DOWN_GLASS_EXIST_ARM3_AttributeOn);
                        __IB_LINK_DOWN_GLASS_EXIST_ARM3.AttributeOff += new delegateAttributeEvent(__IB_LINK_DOWN_GLASS_EXIST_ARM3_AttributeOff);
                        break;
                    case "IB_LINK_DOWN_GLASS_EXIST_ARM4":
                        __IB_LINK_DOWN_GLASS_EXIST_ARM4.AttributeOn += new delegateAttributeEvent(__IB_LINK_DOWN_GLASS_EXIST_ARM4_AttributeOn);
                        __IB_LINK_DOWN_GLASS_EXIST_ARM4.AttributeOff += new delegateAttributeEvent(__IB_LINK_DOWN_GLASS_EXIST_ARM4_AttributeOff);
                        break;
                    case "IB_LINK_DOWN_MAKE_DEFINE1":
                        __IB_LINK_DOWN_MAKE_DEFINE1.AttributeOn += new delegateAttributeEvent(__IB_LINK_DOWN_MAKE_DEFINE1_AttributeOn);
                        __IB_LINK_DOWN_MAKE_DEFINE1.AttributeOff += new delegateAttributeEvent(__IB_LINK_DOWN_MAKE_DEFINE1_AttributeOff);
                        break;
                    case "IB_LINK_DOWN_MAKE_DEFINE2":
                        __IB_LINK_DOWN_MAKE_DEFINE2.AttributeOn += new delegateAttributeEvent(__IB_LINK_DOWN_MAKE_DEFINE2_AttributeOn);
                        __IB_LINK_DOWN_MAKE_DEFINE2.AttributeOff += new delegateAttributeEvent(__IB_LINK_DOWN_MAKE_DEFINE2_AttributeOff);
                        break;
                    case "IB_LINK_DOWN_MAKE_DEFINE3":
                        __IB_LINK_DOWN_MAKE_DEFINE3.AttributeOn += new delegateAttributeEvent(__IB_LINK_DOWN_MAKE_DEFINE3_AttributeOn);
                        __IB_LINK_DOWN_MAKE_DEFINE3.AttributeOff += new delegateAttributeEvent(__IB_LINK_DOWN_MAKE_DEFINE3_AttributeOff);
                        break;
                    case "IB_LINK_DOWN_MAKE_DEFINE4":
                        __IB_LINK_DOWN_MAKE_DEFINE4.AttributeOn += new delegateAttributeEvent(__IB_LINK_DOWN_MAKE_DEFINE4_AttributeOn);
                        __IB_LINK_DOWN_MAKE_DEFINE4.AttributeOff += new delegateAttributeEvent(__IB_LINK_DOWN_MAKE_DEFINE4_AttributeOff);
                        break;
                    case "IB_LINK_DOWN_MAKE_DEFINE5":
                        __IB_LINK_DOWN_MAKE_DEFINE5.AttributeOn += new delegateAttributeEvent(__IB_LINK_DOWN_MAKE_DEFINE5_AttributeOn);
                        __IB_LINK_DOWN_MAKE_DEFINE5.AttributeOff += new delegateAttributeEvent(__IB_LINK_DOWN_MAKE_DEFINE5_AttributeOff);
                        break;
                    case "IB_LINK_DOWN_MAKE_DEFINE6":
                        __IB_LINK_DOWN_MAKE_DEFINE6.AttributeOn += new delegateAttributeEvent(__IB_LINK_DOWN_MAKE_DEFINE6_AttributeOn);
                        __IB_LINK_DOWN_MAKE_DEFINE6.AttributeOff += new delegateAttributeEvent(__IB_LINK_DOWN_MAKE_DEFINE6_AttributeOff);
                        break;
                    case "IB_LINK_DOWN_MAKE_DEFINE7":
                        __IB_LINK_DOWN_MAKE_DEFINE7.AttributeOn += new delegateAttributeEvent(__IB_LINK_DOWN_MAKE_DEFINE7_AttributeOn);
                        __IB_LINK_DOWN_MAKE_DEFINE7.AttributeOff += new delegateAttributeEvent(__IB_LINK_DOWN_MAKE_DEFINE7_AttributeOff);
                        break;
                    case "IB_LINK_DOWN_MAKE_DEFINE8":
                        __IB_LINK_DOWN_MAKE_DEFINE8.AttributeOn += new delegateAttributeEvent(__IB_LINK_DOWN_MAKE_DEFINE8_AttributeOn);
                        __IB_LINK_DOWN_MAKE_DEFINE8.AttributeOff += new delegateAttributeEvent(__IB_LINK_DOWN_MAKE_DEFINE8_AttributeOff);
                        break;

                    default:
                        Console.WriteLine(controlAttribute.Attribute + " IndexerControl");
                        break;
                }
            }
        }

        void __IB_LINK_UP_UPSTREAM_INLINE_AttributeOn(object sender)
        {
            ib_link_up_upstream_inline = true;
        }
        void __IB_LINK_UP_UPSTREAM_INLINE_AttributeOff(object sender)
        {
            ib_link_up_upstream_inline = false;
        }

        void __IB_LINK_UP_UPSTREAM_TROUBLE_AttributeOn(object sender)
        {
            ib_link_up_upstream_trouble = true;
        }
        void __IB_LINK_UP_UPSTREAM_TROUBLE_AttributeOff(object sender)
        {
            ib_link_up_upstream_trouble = false;
        }

        void __IB_LINK_UP_SLOT_NUMBER1_AttributeOn(object sender)
        {
            ib_link_up_slot_number1 = true;
        }
        void __IB_LINK_UP_SLOT_NUMBER1_AttributeOff(object sender)
        {
            ib_link_up_slot_number1 = false;
        }

        void __IB_LINK_UP_SLOT_NUMBER2_AttributeOn(object sender)
        {
            ib_link_up_slot_number2 = true;
        }
        void __IB_LINK_UP_SLOT_NUMBER2_AttributeOff(object sender)
        {
            ib_link_up_slot_number2 = false;
        }

        void __IB_LINK_UP_SLOT_NUMBER3_AttributeOn(object sender)
        {
            ib_link_up_slot_number3 = true;
        }
        void __IB_LINK_UP_SLOT_NUMBER3_AttributeOff(object sender)
        {
            ib_link_up_slot_number3 = false;
        }

        void __IB_LINK_UP_SLOT_NUMBER4_AttributeOn(object sender)
        {
            ib_link_up_slot_number4 = true;
        }
        void __IB_LINK_UP_SLOT_NUMBER4_AttributeOff(object sender)
        {
            ib_link_up_slot_number4 = false;
        }

        void __IB_LINK_UP_SLOT_NUMBER5_AttributeOn(object sender)
        {
            ib_link_up_slot_number5 = true;
        }
        void __IB_LINK_UP_SLOT_NUMBER5_AttributeOff(object sender)
        {
            ib_link_up_slot_number5 = false;
        }

        void __IB_LINK_UP_SLOT_PAIR_FLAG_AttributeOn(object sender)
        {
            ib_link_up_slot_pair_flag = true;
        }
        void __IB_LINK_UP_SLOT_PAIR_FLAG_AttributeOff(object sender)
        {
            ib_link_up_slot_pair_flag = false;
        }

        void __IB_LINK_UP_ARM_SLOT_PAIR_FLAG_AttributeOn(object sender)
        {
            ib_link_up_arm_slot_pair_flag = true;
        }
        void __IB_LINK_UP_ARM_SLOT_PAIR_FLAG_AttributeOff(object sender)
        {
            ib_link_up_arm_slot_pair_flag = false;
        }

        void __IB_LINK_UP_JOB_TRANSFER_SIGNAL_AttributeOn(object sender)
        {
            ib_link_up_job_transfer_signal = true;
        }
        void __IB_LINK_UP_JOB_TRANSFER_SIGNAL_AttributeOff(object sender)
        {
            ib_link_up_job_transfer_signal = false;
        }

        void __IB_LINK_UP_SEND_ABLE_AttributeOn(object sender)
        {
            ib_link_up_send_able = true;
        }
        void __IB_LINK_UP_SEND_ABLE_AttributeOff(object sender)
        {
            ib_link_up_send_able = false;
        }

        void __IB_LINK_UP_SEND_START_AttributeOn(object sender)
        {
            ib_link_up_send_start = true;
        }
        void __IB_LINK_UP_SEND_START_AttributeOff(object sender)
        {
            ib_link_up_send_start = false;
        }

        void __IB_LINK_UP_SEND_COMPLETE_AttributeOn(object sender)
        {
            ib_link_up_send_complete = true;
        }
        void __IB_LINK_UP_SEND_COMPLETE_AttributeOff(object sender)
        {
            ib_link_up_send_complete = false;
        }

        void __IB_LINK_UP_EXCHANGE_POSSIBLE_AttributeOn(object sender)
        {
            ib_link_up_exchange_possible = true;
        }
        void __IB_LINK_UP_EXCHANGE_POSSIBLE_AttributeOff(object sender)
        {
            ib_link_up_exchange_possible = false;
        }

        void __IB_LINK_UP_EXCHANGE_EXECUTE_AttributeOn(object sender)
        {
            ib_link_up_exchange_execute = true;
        }
        void __IB_LINK_UP_EXCHANGE_EXECUTE_AttributeOff(object sender)
        {
            ib_link_up_exchange_execute = false;
        }

        void __IB_LINK_UP_RESUME_REQUEST_AttributeOn(object sender)
        {
            ib_link_up_resume_request = true;
        }
        void __IB_LINK_UP_RESUME_REQUEST_AttributeOff(object sender)
        {
            ib_link_up_resume_request = false;
        }

        void __IB_LINK_UP_RESUME_ACK_AttributeOn(object sender)
        {
            ib_link_up_resume_ack = true;
        }
        void __IB_LINK_UP_RESUME_ACK_AttributeOff(object sender)
        {
            ib_link_up_resume_ack = false;
        }

        void __IB_LINK_UP_CANCEL_REQUEST_AttributeOn(object sender)
        {
            ib_link_up_cancel_request = true;
        }
        void __IB_LINK_UP_CANCEL_REQUEST_AttributeOff(object sender)
        {
            ib_link_up_cancel_request = false;
        }

        void __IB_LINK_UP_CANCEL_ACK_AttributeOn(object sender)
        {
            ib_link_up_cancel_ack = true;
        }
        void __IB_LINK_UP_CANCEL_ACK_AttributeOff(object sender)
        {
            ib_link_up_cancel_ack = false;
        }

        void __IB_LINK_UP_ABORT_REQUEST_AttributeOn(object sender)
        {
            ib_link_up_abort_request = true;
        }
        void __IB_LINK_UP_ABORT_REQUEST_AttributeOff(object sender)
        {
            ib_link_up_abort_request = false;
        }

        void __IB_LINK_UP_ABORT_ACK_AttributeOn(object sender)
        {
            ib_link_up_abort_ack = true;
        }
        void __IB_LINK_UP_ABORT_ACK_AttributeOff(object sender)
        {
            ib_link_up_abort_ack = false;
        }

        void __IB_LINK_UP_CONVEYER_STATE_AttributeOn(object sender)
        {
            ib_link_up_conveyer_state = true;
        }
        void __IB_LINK_UP_CONVEYER_STATE_AttributeOff(object sender)
        {
            ib_link_up_conveyer_state = false;
        }

        void __IB_LINK_UP_SHUTTER_STATE_AttributeOn(object sender)
        {
            ib_link_up_shutter_state = true;
        }
        void __IB_LINK_UP_SHUTTER_STATE_AttributeOff(object sender)
        {
            ib_link_up_shutter_state = false;
        }

        void __IB_LINK_UP_FIRST_SLOT_EXIST_AttributeOn(object sender)
        {
            ib_link_up_first_slot_exist = true;
        }
        void __IB_LINK_UP_FIRST_SLOT_EXIST_AttributeOff(object sender)
        {
            ib_link_up_first_slot_exist = false;
        }

        void __IB_LINK_UP_SECOND_SLOT_EXIST_AttributeOn(object sender)
        {
            ib_link_up_second_slot_exist = true;
        }
        void __IB_LINK_UP_SECOND_SLOT_EXIST_AttributeOff(object sender)
        {
            ib_link_up_second_slot_exist = false;
        }

        void __IB_LINK_UP_THIRD_SLOT_EXIST_AttributeOn(object sender)
        {
            ib_link_up_third_slot_exist = true;
        }
        void __IB_LINK_UP_THIRD_SLOT_EXIST_AttributeOff(object sender)
        {
            ib_link_up_third_slot_exist = false;
        }

        void __IB_LINK_UP_FOURTH_SLOT_EXIST_AttributeOn(object sender)
        {
            ib_link_up_fourth_slot_exist = true;
        }
        void __IB_LINK_UP_FOURTH_SLOT_EXIST_AttributeOff(object sender)
        {
            ib_link_up_fourth_slot_exist = false;
        }

        void __IB_LINK_UP_CHK_ABNORMAL_AttributeOn(object sender)
        {
            ib_link_up_chk_abnormal = true;
        }
        void __IB_LINK_UP_CHK_ABNORMAL_AttributeOff(object sender)
        {
            ib_link_up_chk_abnormal = false;
        }

        void __IB_LINK_UP_CHK_EMPTY_AttributeOn(object sender)
        {
            ib_link_up_chk_empty = true;
        }
        void __IB_LINK_UP_CHK_EMPTY_AttributeOff(object sender)
        {
            ib_link_up_chk_empty = false;
        }

        void __IB_LINK_UP_CHK_IDLE_AttributeOn(object sender)
        {
            ib_link_up_chk_idle = true;
        }
        void __IB_LINK_UP_CHK_IDLE_AttributeOff(object sender)
        {
            ib_link_up_chk_idle = false;
        }

        void __IB_LINK_UP_CHK_RUN_AttributeOn(object sender)
        {
            ib_link_up_chk_run = true;
        }
        void __IB_LINK_UP_CHK_RUN_AttributeOff(object sender)
        {
            ib_link_up_chk_run = false;
        }

        void __IB_LINK_UP_CHK_COMPLETE_AttributeOn(object sender)
        {
            ib_link_up_chk_complete = true;
        }
        void __IB_LINK_UP_CHK_COMPLETE_AttributeOff(object sender)
        {
            ib_link_up_chk_complete = false;
        }

        void __IB_LINK_UP_CHK_PIN_UP_AttributeOn(object sender)
        {
            ib_link_up_chk_pin_up = true;
        }
        void __IB_LINK_UP_CHK_PIN_UP_AttributeOff(object sender)
        {
            ib_link_up_chk_pin_up = false;
        }

        void __IB_LINK_UP_CHK_PIN_DOWN_AttributeOn(object sender)
        {
            ib_link_up_chk_pin_down = true;
        }
        void __IB_LINK_UP_CHK_PIN_DOWN_AttributeOff(object sender)
        {
            ib_link_up_chk_pin_down = false;
        }

        void __IB_LINK_UP_CHK_STOPPER_UP_CHK_OR_DOOR_OPEN_AttributeOn(object sender)
        {
            ib_link_up_chk_stopper_up_chk_or_door_open = true;
        }
        void __IB_LINK_UP_CHK_STOPPER_UP_CHK_OR_DOOR_OPEN_AttributeOff(object sender)
        {
            ib_link_up_chk_stopper_up_chk_or_door_open = false;
        }

        void __IB_LINK_UP_CHK_STOPPER_DOWN_OR_DOOR_CLOSE_AttributeOn(object sender)
        {
            ib_link_up_chk_stopper_down_or_door_close = true;
        }
        void __IB_LINK_UP_CHK_STOPPER_DOWN_OR_DOOR_CLOSE_AttributeOff(object sender)
        {
            ib_link_up_chk_stopper_down_or_door_close = false;
        }

        void __IB_LINK_UP_CHK_MANUAL_OPERATION_AttributeOn(object sender)
        {
            ib_link_up_chk_manual_operation = true;
        }
        void __IB_LINK_UP_CHK_MANUAL_OPERATION_AttributeOff(object sender)
        {
            ib_link_up_chk_manual_operation = false;
        }

        void __IB_LINK_UP_CHK_BODY_MOVING_AttributeOn(object sender)
        {
            ib_link_up_chk_body_moving = true;
        }
        void __IB_LINK_UP_CHK_BODY_MOVING_AttributeOff(object sender)
        {
            ib_link_up_chk_body_moving = false;
        }

        void __IB_LINK_UP_CHK_GLASS_EXIST_ARM1_AttributeOn(object sender)
        {
            ib_link_up_chk_glass_exist_arm1 = true;
        }
        void __IB_LINK_UP_CHK_GLASS_EXIST_ARM1_AttributeOff(object sender)
        {
            ib_link_up_chk_glass_exist_arm1 = false;
        }

        void __IB_LINK_UP_CHK_GLASS_EXIST_ARM2_AttributeOn(object sender)
        {
            ib_link_up_chk_glass_exist_arm2 = true;
        }
        void __IB_LINK_UP_CHK_GLASS_EXIST_ARM2_AttributeOff(object sender)
        {
            ib_link_up_chk_glass_exist_arm2 = false;
        }

        void __IB_LINK_UP_CHK_GLASS_EXIST_ARM3_AttributeOn(object sender)
        {
            ib_link_up_chk_glass_exist_arm3 = true;
        }
        void __IB_LINK_UP_CHK_GLASS_EXIST_ARM3_AttributeOff(object sender)
        {
            ib_link_up_chk_glass_exist_arm3 = false;
        }

        void __IB_LINK_UP_CHK_GLASS_EXIST_ARM4_AttributeOn(object sender)
        {
            ib_link_up_chk_glass_exist_arm4 = true;
        }
        void __IB_LINK_UP_CHK_GLASS_EXIST_ARM4_AttributeOff(object sender)
        {
            ib_link_up_chk_glass_exist_arm4 = false;
        }

        void __IB_LINK_UP_CHK_MAKE_DEFINE1_AttributeOn(object sender)
        {
            ib_link_up_chk_make_define1 = true;
        }
        void __IB_LINK_UP_CHK_MAKE_DEFINE1_AttributeOff(object sender)
        {
            ib_link_up_chk_make_define1 = false;
        }

        void __IB_LINK_UP_CHK_MAKE_DEFINE2_AttributeOn(object sender)
        {
            ib_link_up_chk_make_define2 = true;
        }
        void __IB_LINK_UP_CHK_MAKE_DEFINE2_AttributeOff(object sender)
        {
            ib_link_up_chk_make_define2 = false;
        }

        void __IB_LINK_UP_CHK_MAKE_DEFINE3_AttributeOn(object sender)
        {
            ib_link_up_chk_make_define3 = true;
        }
        void __IB_LINK_UP_CHK_MAKE_DEFINE3_AttributeOff(object sender)
        {
            ib_link_up_chk_make_define3 = false;
        }

        void __IB_LINK_UP_CHK_MAKE_DEFINE4_AttributeOn(object sender)
        {
            ib_link_up_chk_make_define4 = true;
        }
        void __IB_LINK_UP_CHK_MAKE_DEFINE4_AttributeOff(object sender)
        {
            ib_link_up_chk_make_define4 = false;
        }

        void __IB_LINK_UP_CHK_MAKE_DEFINE5_AttributeOn(object sender)
        {
            ib_link_up_chk_make_define5 = true;
        }
        void __IB_LINK_UP_CHK_MAKE_DEFINE5_AttributeOff(object sender)
        {
            ib_link_up_chk_make_define5 = false;
        }

        void __IB_LINK_UP_CHK_MAKE_DEFINE6_AttributeOn(object sender)
        {
            ib_link_up_chk_make_define6 = true;
        }
        void __IB_LINK_UP_CHK_MAKE_DEFINE6_AttributeOff(object sender)
        {
            ib_link_up_chk_make_define6 = false;
        }

        void __IB_LINK_UP_CHK_MAKE_DEFINE7_AttributeOn(object sender)
        {
            ib_link_up_chk_make_define7 = true;
        }
        void __IB_LINK_UP_CHK_MAKE_DEFINE7_AttributeOff(object sender)
        {
            ib_link_up_chk_make_define7 = false;
        }

        void __IB_LINK_UP_CHK_MAKE_DEFINE8_AttributeOn(object sender)
        {
            ib_link_up_chk_make_define8 = true;
        }
        void __IB_LINK_UP_CHK_MAKE_DEFINE8_AttributeOff(object sender)
        {
            ib_link_up_chk_make_define8 = false;
        }

        void __IB_LINK_DOWN_DOWNSTREAM_INLINE_AttributeOn(object sender)
        {
            ib_link_down_downstream_inline = true;
        }
        void __IB_LINK_DOWN_DOWNSTREAM_INLINE_AttributeOff(object sender)
        {
            ib_link_down_downstream_inline = false;
        }

        void __IB_LINK_DOWN_DOWNSTREAM_TROUBLE_AttributeOn(object sender)
        {
            ib_link_down_downstream_trouble = true;
        }
        void __IB_LINK_DOWN_DOWNSTREAM_TROUBLE_AttributeOff(object sender)
        {
            ib_link_down_downstream_trouble = false;
        }

        void __IB_LINK_DOWN_SLOT_NUMBER1_AttributeOn(object sender)
        {
            ib_link_down_slot_number1 = true;
        }
        void __IB_LINK_DOWN_SLOT_NUMBER1_AttributeOff(object sender)
        {
            ib_link_down_slot_number1 = false;
        }

        void __IB_LINK_DOWN_SLOT_NUMBER2_AttributeOn(object sender)
        {
            ib_link_down_slot_number2 = true;
        }
        void __IB_LINK_DOWN_SLOT_NUMBER2_AttributeOff(object sender)
        {
            ib_link_down_slot_number2 = false;
        }

        void __IB_LINK_DOWN_SLOT_NUMBER3_AttributeOn(object sender)
        {
            ib_link_down_slot_number3 = true;
        }
        void __IB_LINK_DOWN_SLOT_NUMBER3_AttributeOff(object sender)
        {
            ib_link_down_slot_number3 = false;
        }

        void __IB_LINK_DOWN_SLOT_NUMBER4_AttributeOn(object sender)
        {
            ib_link_down_slot_number4 = true;
        }
        void __IB_LINK_DOWN_SLOT_NUMBER4_AttributeOff(object sender)
        {
            ib_link_down_slot_number4 = false;
        }

        void __IB_LINK_DOWN_SLOT_PAIR_FLAG_AttributeOn(object sender)
        {
            ib_link_down_slot_pair_flag = true;
        }
        void __IB_LINK_DOWN_SLOT_PAIR_FLAG_AttributeOff(object sender)
        {
            ib_link_down_slot_pair_flag = false;
        }

        void __IB_LINK_DOWN_ARM_SLOT_PAIR_FLAG_AttributeOn(object sender)
        {
            ib_link_down_arm_slot_pair_flag = true;
        }
        void __IB_LINK_DOWN_ARM_SLOT_PAIR_FLAG_AttributeOff(object sender)
        {
            ib_link_down_arm_slot_pair_flag = false;
        }

        void __IB_LINK_DOWN_JOB_TRANSFER_SIGNAL_AttributeOn(object sender)
        {
            ib_link_down_job_transfer_signal = true;
        }
        void __IB_LINK_DOWN_JOB_TRANSFER_SIGNAL_AttributeOff(object sender)
        {
            ib_link_down_job_transfer_signal = false;
        }

        void __IB_LINK_DOWN_RECEIVE_ABLE_AttributeOn(object sender)
        {
            ib_link_down_receive_able = true;
        }
        void __IB_LINK_DOWN_RECEIVE_ABLE_AttributeOff(object sender)
        {
            ib_link_down_receive_able = false;
        }

        void __IB_LINK_DOWN_RECEIVE_START_AttributeOn(object sender)
        {
            ib_link_down_receive_start = true;
        }
        void __IB_LINK_DOWN_RECEIVE_START_AttributeOff(object sender)
        {
            ib_link_down_receive_start = false;
        }

        void __IB_LINK_DOWN_RECEIVE_COMPLETE_AttributeOn(object sender)
        {
            ib_link_down_receive_complete = true;
        }
        void __IB_LINK_DOWN_RECEIVE_COMPLETE_AttributeOff(object sender)
        {
            ib_link_down_receive_complete = false;
        }

        void __IB_LINK_DOWN_EXCHANGE_POSSIBLE_AttributeOn(object sender)
        {
            ib_link_down_exchange_possible = true;
        }
        void __IB_LINK_DOWN_EXCHANGE_POSSIBLE_AttributeOff(object sender)
        {
            ib_link_down_exchange_possible = false;
        }

        void __IB_LINK_DOWN_EXCHANGE_EXECUTE_AttributeOn(object sender)
        {
            ib_link_down_exchange_execute = true;
        }
        void __IB_LINK_DOWN_EXCHANGE_EXECUTE_AttributeOff(object sender)
        {
            ib_link_down_exchange_execute = false;
        }

        void __IB_LINK_DOWN_RESUME_REQUEST_AttributeOn(object sender)
        {
            ib_link_down_resume_request = true;
        }
        void __IB_LINK_DOWN_RESUME_REQUEST_AttributeOff(object sender)
        {
            ib_link_down_resume_request = false;
        }

        void __IB_LINK_DOWN_RESUME_ACK_AttributeOn(object sender)
        {
            ib_link_down_resume_ack = true;
        }
        void __IB_LINK_DOWN_RESUME_ACK_AttributeOff(object sender)
        {
            ib_link_down_resume_ack = false;
        }

        void __IB_LINK_DOWN_CANCEL_REQUEST_AttributeOn(object sender)
        {
            ib_link_down_cancel_request = true;
        }
        void __IB_LINK_DOWN_CANCEL_REQUEST_AttributeOff(object sender)
        {
            ib_link_down_cancel_request = false;
        }

        void __IB_LINK_DOWN_CANCEL_ACK_AttributeOn(object sender)
        {
            ib_link_down_cancel_ack = true;
        }
        void __IB_LINK_DOWN_CANCEL_ACK_AttributeOff(object sender)
        {
            ib_link_down_cancel_ack = false;
        }

        void __IB_LINK_DOWN_ABORT_REQUEST_AttributeOn(object sender)
        {
            ib_link_down_abort_request = true;
        }
        void __IB_LINK_DOWN_ABORT_REQUEST_AttributeOff(object sender)
        {
            ib_link_down_abort_request = false;
        }

        void __IB_LINK_DOWN_ABORT_ACK_AttributeOn(object sender)
        {
            ib_link_down_abort_ack = true;
        }
        void __IB_LINK_DOWN_ABORT_ACK_AttributeOff(object sender)
        {
            ib_link_down_abort_ack = false;
        }

        void __IB_LINK_DOWN_CONVEYER_STATE_AttributeOn(object sender)
        {
            ib_link_down_conveyer_state = true;
        }
        void __IB_LINK_DOWN_CONVEYER_STATE_AttributeOff(object sender)
        {
            ib_link_down_conveyer_state = false;
        }

        void __IB_LINK_DOWN_SHUTTER_STATE_AttributeOn(object sender)
        {
            ib_link_down_shutter_state = true;
        }
        void __IB_LINK_DOWN_SHUTTER_STATE_AttributeOff(object sender)
        {
            ib_link_down_shutter_state = false;
        }

        void __IB_LINK_DOWN_FIRST_SLOT_EXIST_AttributeOn(object sender)
        {
            ib_link_down_first_slot_exist = true;
        }
        void __IB_LINK_DOWN_FIRST_SLOT_EXIST_AttributeOff(object sender)
        {
            ib_link_down_first_slot_exist = false;
        }

        void __IB_LINK_DOWN_SECOND_SLOT_EXIST_AttributeOn(object sender)
        {
            ib_link_down_second_slot_exist = true;
        }
        void __IB_LINK_DOWN_SECOND_SLOT_EXIST_AttributeOff(object sender)
        {
            ib_link_down_second_slot_exist = false;
        }

        void __IB_LINK_DOWN_THIRD_SLOT_EXIST_AttributeOn(object sender)
        {
            ib_link_down_third_slot_exist = true;
        }
        void __IB_LINK_DOWN_THIRD_SLOT_EXIST_AttributeOff(object sender)
        {
            ib_link_down_third_slot_exist = false;
        }

        void __IB_LINK_DOWN_FOURTH_SLOT_EXIST_AttributeOn(object sender)
        {
            ib_link_down_fourth_slot_exist = true;
        }
        void __IB_LINK_DOWN_FOURTH_SLOT_EXIST_AttributeOff(object sender)
        {
            ib_link_down_fourth_slot_exist = false;
        }

        void __IB_LINK_DOWN_ABNORMAL_AttributeOn(object sender)
        {
            ib_link_down_abnormal = true;
        }
        void __IB_LINK_DOWN_ABNORMAL_AttributeOff(object sender)
        {
            ib_link_down_abnormal = false;
        }

        void __IB_LINK_DOWN_EMPTY_AttributeOn(object sender)
        {
            ib_link_down_empty = true;
        }
        void __IB_LINK_DOWN_EMPTY_AttributeOff(object sender)
        {
            ib_link_down_empty = false;
        }

        void __IB_LINK_DOWN_IDLE_AttributeOn(object sender)
        {
            ib_link_down_idle = true;
        }
        void __IB_LINK_DOWN_IDLE_AttributeOff(object sender)
        {
            ib_link_down_idle = false;
        }

        void __IB_LINK_DOWN_RUN_AttributeOn(object sender)
        {
            ib_link_down_run = true;
        }
        void __IB_LINK_DOWN_RUN_AttributeOff(object sender)
        {
            ib_link_down_run = false;
        }

        void __IB_LINK_DOWN_COMPLETE_AttributeOn(object sender)
        {
            ib_link_down_complete = true;
        }
        void __IB_LINK_DOWN_COMPLETE_AttributeOff(object sender)
        {
            ib_link_down_complete = false;
        }

        void __IB_LINK_DOWN_LIFT_UP_OR_PIN_UP_AttributeOn(object sender)
        {
            ib_link_down_lift_up_or_pin_up = true;
        }
        void __IB_LINK_DOWN_LIFT_UP_OR_PIN_UP_AttributeOff(object sender)
        {
            ib_link_down_lift_up_or_pin_up = false;
        }

        void __IB_LINK_DOWN_LIFT_DOWN_OR_PIN_DOWN_AttributeOn(object sender)
        {
            ib_link_down_lift_down_or_pin_down = true;
        }
        void __IB_LINK_DOWN_LIFT_DOWN_OR_PIN_DOWN_AttributeOff(object sender)
        {
            ib_link_down_lift_down_or_pin_down = false;
        }

        void __IB_LINK_DOWN_STOPPER_UP_OR_DOOR_OPEN_AttributeOn(object sender)
        {
            ib_link_down_stopper_up_or_door_open = true;
        }
        void __IB_LINK_DOWN_STOPPER_UP_OR_DOOR_OPEN_AttributeOff(object sender)
        {
            ib_link_down_stopper_up_or_door_open = false;
        }

        void __IB_LINK_DOWN_STOPPER_DOWN_OR_DOOR_CLOSE_AttributeOn(object sender)
        {
            ib_link_down_stopper_down_or_door_close = true;
        }
        void __IB_LINK_DOWN_STOPPER_DOWN_OR_DOOR_CLOSE_AttributeOff(object sender)
        {
            ib_link_down_stopper_down_or_door_close = false;
        }

        void __IB_LINK_DOWN_MANUAL_OPERATION_AttributeOn(object sender)
        {
            ib_link_down_manual_operation = true;
        }
        void __IB_LINK_DOWN_MANUAL_OPERATION_AttributeOff(object sender)
        {
            ib_link_down_manual_operation = false;
        }

        void __IB_LINK_DOWN_BODY_MOVING_AttributeOn(object sender)
        {
            ib_link_down_body_moving = true;
        }
        void __IB_LINK_DOWN_BODY_MOVING_AttributeOff(object sender)
        {
            ib_link_down_body_moving = false;
        }

        void __IB_LINK_DOWN_GLASS_EXIST_ARM1_AttributeOn(object sender)
        {
            ib_link_down_glass_exist_arm1 = true;
        }
        void __IB_LINK_DOWN_GLASS_EXIST_ARM1_AttributeOff(object sender)
        {
            ib_link_down_glass_exist_arm1 = false;
        }

        void __IB_LINK_DOWN_GLASS_EXIST_ARM2_AttributeOn(object sender)
        {
            ib_link_down_glass_exist_arm2 = true;
        }
        void __IB_LINK_DOWN_GLASS_EXIST_ARM2_AttributeOff(object sender)
        {
            ib_link_down_glass_exist_arm2 = false;
        }

        void __IB_LINK_DOWN_GLASS_EXIST_ARM3_AttributeOn(object sender)
        {
            ib_link_down_glass_exist_arm3 = true;
        }
        void __IB_LINK_DOWN_GLASS_EXIST_ARM3_AttributeOff(object sender)
        {
            ib_link_down_glass_exist_arm3 = false;
        }

        void __IB_LINK_DOWN_GLASS_EXIST_ARM4_AttributeOn(object sender)
        {
            ib_link_down_glass_exist_arm4 = true;
        }
        void __IB_LINK_DOWN_GLASS_EXIST_ARM4_AttributeOff(object sender)
        {
            ib_link_down_glass_exist_arm4 = false;
        }

        void __IB_LINK_DOWN_MAKE_DEFINE1_AttributeOn(object sender)
        {
            ib_link_down_make_define1 = true;
        }
        void __IB_LINK_DOWN_MAKE_DEFINE1_AttributeOff(object sender)
        {
            ib_link_down_make_define1 = false;
        }

        void __IB_LINK_DOWN_MAKE_DEFINE2_AttributeOn(object sender)
        {
            ib_link_down_make_define2 = true;
        }
        void __IB_LINK_DOWN_MAKE_DEFINE2_AttributeOff(object sender)
        {
            ib_link_down_make_define2 = false;
        }

        void __IB_LINK_DOWN_MAKE_DEFINE3_AttributeOn(object sender)
        {
            ib_link_down_make_define3 = true;
        }
        void __IB_LINK_DOWN_MAKE_DEFINE3_AttributeOff(object sender)
        {
            ib_link_down_make_define3 = false;
        }

        void __IB_LINK_DOWN_MAKE_DEFINE4_AttributeOn(object sender)
        {
            ib_link_down_make_define4 = true;
        }
        void __IB_LINK_DOWN_MAKE_DEFINE4_AttributeOff(object sender)
        {
            ib_link_down_make_define4 = false;
        }

        void __IB_LINK_DOWN_MAKE_DEFINE5_AttributeOn(object sender)
        {
            ib_link_down_make_define5 = true;
        }
        void __IB_LINK_DOWN_MAKE_DEFINE5_AttributeOff(object sender)
        {
            ib_link_down_make_define5 = false;
        }

        void __IB_LINK_DOWN_MAKE_DEFINE6_AttributeOn(object sender)
        {
            ib_link_down_make_define6 = true;
        }
        void __IB_LINK_DOWN_MAKE_DEFINE6_AttributeOff(object sender)
        {
            ib_link_down_make_define6 = false;
        }

        void __IB_LINK_DOWN_MAKE_DEFINE7_AttributeOn(object sender)
        {
            ib_link_down_make_define7 = true;
        }
        void __IB_LINK_DOWN_MAKE_DEFINE7_AttributeOff(object sender)
        {
            ib_link_down_make_define7 = false;
        }

        void __IB_LINK_DOWN_MAKE_DEFINE8_AttributeOn(object sender)
        {
            ib_link_down_make_define8 = true;
        }
        void __IB_LINK_DOWN_MAKE_DEFINE8_AttributeOff(object sender)
        {
            ib_link_down_make_define8 = false;
        }
        #endregion

        #region Event Handler
        //public delegate void delegateRunningModeNoty(object sender, bool value);
        //public delegate void delegateEquipmentAutoModeNotify(object sender, bool value);

        //public event delegateRunningModeNoty OnRunningModeNoty;
        //public event delegateEquipmentAutoModeNotify OnEquipmentAutoModeNotify;

        //void __IB_RUNING_MODE_NOTIFICATION_AttributeOn(object sender)
        //{
        //    RaiseRunningModeNoty(true, "IB_RUNING_MODE_NOTIFICATION");
        //}
        //void __IB_RUNING_MODE_NOTIFICATION_AttributeOff(object sender)
        //{
        //    RaiseRunningModeNoty(false, "IB_RUNING_MODE_NOTIFICATION");
        //}


        #endregion

        #region EventHandler Notify's

        //public void RaiseRunningModeNoty(bool value, string AttributeName)
        //{
        //    CLogManager.Instance.Log(new CControlLogFormat(Catagory.Info, ControlName, AttributeName, value.ToString()));
        //    if (OnRunningModeNoty != null)
        //    {
        //        OnRunningModeNoty(this, value);
        //    }
        //}

        //public void RaiseEquipmentAutoModeNotify(bool value, string AttributeName)
        //{
        //    CLogManager.Instance.Log(new CControlLogFormat(Catagory.Info, ControlName, AttributeName, value.ToString()));
        //    if (OnEquipmentAutoModeNotify != null)
        //    {
        //        OnEquipmentAutoModeNotify(this, value);
        //    }
        //}
        #endregion

    }

    public class CIndexerControlCollection : Dictionary<string, CIndexerControl>
    {
        public CIndexerControl GetControl(string controlName)
        {
            if(this.ContainsKey(controlName))
            {
                return this[controlName];
            }

            return null;
        }
    }
}
