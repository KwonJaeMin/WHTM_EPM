﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOFD.Component.Interface;
using YANGSYS.ControlLib;
using SOFD.Component;
using MainLibrary;
using SOFD.Properties;
using SOFD.Logger;

using MainLibrary.Property;
using System.Threading;

namespace YANGSYS.Biz.Programs
{
    public class CLinkSignalType10 : AProgram
    {
        private CScanControlProperties IB_LINK_UP_UPSTREAM_INLINE = null;
        private CScanControlProperties IB_LINK_UP_UPSTREAM_TROUBLE = null;
        private CScanControlProperties IB_LINK_UP_SLOT_NUMBER1 = null;
        private CScanControlProperties IB_LINK_UP_SLOT_NUMBER2 = null;
        private CScanControlProperties IB_LINK_UP_SLOT_NUMBER3 = null;
        private CScanControlProperties IB_LINK_UP_SLOT_NUMBER4 = null;
        private CScanControlProperties IB_LINK_UP_SLOT_NUMBER5 = null;
        private CScanControlProperties IB_LINK_UP_SLOT_PAIR_FLAG = null;
        private CScanControlProperties IB_LINK_UP_ARM_SLOT_PAIR_FLAG = null;
        private CScanControlProperties IB_LINK_UP_JOB_TRANSFER_SIGNAL = null;
        private CScanControlProperties IB_LINK_UP_SEND_ABLE = null;
        private CScanControlProperties IB_LINK_UP_SEND_START = null;
        private CScanControlProperties IB_LINK_UP_SEND_COMPLETE = null;
        private CScanControlProperties IB_LINK_UP_EXCHANGE_POSSIBLE = null;
        private CScanControlProperties IB_LINK_UP_EXCHANGE_EXECUTE = null;
        private CScanControlProperties IB_LINK_UP_RESUME_REQUEST = null;
        private CScanControlProperties IB_LINK_UP_RESUME_ACK = null;
        private CScanControlProperties IB_LINK_UP_CANCEL_REQUEST = null;
        private CScanControlProperties IB_LINK_UP_CANCEL_ACK = null;
        private CScanControlProperties IB_LINK_UP_ABORT_REQUEST = null;
        private CScanControlProperties IB_LINK_UP_ABOR_ACK = null;
        private CScanControlProperties IB_LINK_UP_CONVEYER_STATE = null;
        private CScanControlProperties IB_LINK_UP_SHUTTER_STATE = null;
        private CScanControlProperties IB_LINK_UP_FIRST_SLOT_EXIST = null;
        private CScanControlProperties IB_LINK_UP_SECOND_SLOT_EXIST = null;
        private CScanControlProperties IB_LINK_UP_THIRD_SLOT_EXIST = null;
        private CScanControlProperties IB_LINK_UP_FOURTH_SLOT_EXIST = null;

        private CScanControlProperties IB_LINK_UP_CHK_ABNORMAL = null;
        private CScanControlProperties IB_LINK_UP_CHK_EMPTY = null;
        private CScanControlProperties IB_LINK_UP_CHK_IDLE = null;
        private CScanControlProperties IB_LINK_UP_CHK_RUN = null;
        private CScanControlProperties IB_LINK_UP_CHK_COMPLETE = null;
        private CScanControlProperties IB_LINK_UP_CHK_LIFT_UP_OR_PIN_UP = null;
        private CScanControlProperties IB_LINK_UP_CHK_LIFT_DOWN_OR_PIN_DOWN = null;
        private CScanControlProperties IB_LINK_UP_CHK_STOPPER_UP_OR_DOOR_OPEN = null;
        private CScanControlProperties IB_LINK_UP_CHK_STOPPER_DOWN_OR_DOOR_CLOSE = null;
        private CScanControlProperties IB_LINK_UP_CHK_MANUAL_OPERATION = null;
        private CScanControlProperties IB_LINK_UP_CHK_BODY_MOVING = null;
        private CScanControlProperties IB_LINK_UP_CHK_GLASS_EXIST_ARM1 = null;
        private CScanControlProperties IB_LINK_UP_CHK_GLASS_EXIST_ARM2 = null;
        private CScanControlProperties IB_LINK_UP_CHK_GLASS_EXIST_ARM3 = null;
        private CScanControlProperties IB_LINK_UP_CHK_GLASS_EXIST_ARM4 = null;
        private CScanControlProperties IB_LINK_UP_CHK_MAKE_DEFINE1 = null;
        private CScanControlProperties IB_LINK_UP_CHK_MAKE_DEFINE2 = null;
        private CScanControlProperties IB_LINK_UP_CHK_MAKE_DEFINE3 = null;
        private CScanControlProperties IB_LINK_UP_CHK_MAKE_DEFINE4 = null;
        private CScanControlProperties IB_LINK_UP_CHK_MAKE_DEFINE5 = null;
        private CScanControlProperties IB_LINK_UP_CHK_MAKE_DEFINE6 = null;
        private CScanControlProperties IB_LINK_UP_CHK_MAKE_DEFINE7 = null;
        private CScanControlProperties IB_LINK_UP_CHK_MAKE_DEFINE8 = null;

        private CScanControlProperties IB_LINK_DOWN_DOWNSTREAM_INLINE = null;
        private CScanControlProperties IB_LINK_DOWN_DOWNSTREAM_TROUBLE = null;
        private CScanControlProperties IB_LINK_DOWN_SLOT_NUMBER1 = null;
        private CScanControlProperties IB_LINK_DOWN_SLOT_NUMBER2 = null;
        private CScanControlProperties IB_LINK_DOWN_SLOT_NUMBER3 = null;
        private CScanControlProperties IB_LINK_DOWN_SLOT_NUMBER4 = null;
        private CScanControlProperties IB_LINK_DOWN_SLOT_NUMBER5 = null;
        private CScanControlProperties IB_LINK_DOWN_SLOT_PAIR_FLAG = null;
        private CScanControlProperties IB_LINK_DOWN_ARM_SLOT_PAIR_FLAG = null;
        private CScanControlProperties IB_LINK_DOWN_JOB_TRANSFER_SIGNAL = null;
        private CScanControlProperties IB_LINK_DOWN_RECEIVE_ABLE = null;
        private CScanControlProperties IB_LINK_DOWN_RECEIVE_START = null;
        private CScanControlProperties IB_LINK_DOWN_RECEIVE_COMPLETE = null;
        private CScanControlProperties IB_LINK_DOWN_EXCHANGE_POSSIBLE = null;
        private CScanControlProperties IB_LINK_DOWN_EXCHANGE_EXECUTE = null;
        private CScanControlProperties IB_LINK_DOWN_RESUME_REQUEST = null;
        private CScanControlProperties IB_LINK_DOWN_RESUME_ACK = null;
        private CScanControlProperties IB_LINK_DOWN_CANCEL_REQUEST = null;
        private CScanControlProperties IB_LINK_DOWN_CANCEL_ACK = null;
        private CScanControlProperties IB_LINK_DOWN_ABORT_REQUEST = null;
        private CScanControlProperties IB_LINK_DOWN_ABORT_ACK = null;
        private CScanControlProperties IB_LINK_DOWN_CONVEYER_STATE = null;
        private CScanControlProperties IB_LINK_DOWN_SHUTTER_STATE = null;
        private CScanControlProperties IB_LINK_DOWN_FIRST_SLOT_EXIST = null;
        private CScanControlProperties IB_LINK_DOWN_SECOND_SLOT_EXIST = null;
        private CScanControlProperties IB_LINK_DOWN_THIRD_SLOT_EXIST = null;
        private CScanControlProperties IB_LINK_DOWN_FOURTH_SLOT_EXIST = null;

        private CScanControlProperties IB_LINK_DOWN_CHK_ABNORMAL = null;
        private CScanControlProperties IB_LINK_DOWN_CHK_EMPTY = null;
        private CScanControlProperties IB_LINK_DOWN_CHK_IDLE = null;
        private CScanControlProperties IB_LINK_DOWN_CHK_RUN = null;
        private CScanControlProperties IB_LINK_DOWN_CHK_COMPLETE = null;
        private CScanControlProperties IB_LINK_DOWN_CHK_LIFT_UP_OR_PIN_UP = null;
        private CScanControlProperties IB_LINK_DOWN_CHK_LIFT_DOWN_OR_PIN_DOWN = null;
        private CScanControlProperties IB_LINK_DOWN_CHK_STOPPER_UP_OR_DOOR_OPEN = null;
        private CScanControlProperties IB_LINK_DOWN_CHK_STOPPER_DOWN_OR_DOOR_CLOSE = null;
        private CScanControlProperties IB_LINK_DOWN_CHK_MANUAL_OPERATION = null;
        private CScanControlProperties IB_LINK_DOWN_CHK_BODY_MOVING = null;
        private CScanControlProperties IB_LINK_DOWN_CHK_GLASS_EXIST_ARM1 = null;
        private CScanControlProperties IB_LINK_DOWN_CHK_GLASS_EXIST_ARM2 = null;
        private CScanControlProperties IB_LINK_DOWN_CHK_GLASS_EXIST_ARM3 = null;
        private CScanControlProperties IB_LINK_DOWN_CHK_GLASS_EXIST_ARM4 = null;
        private CScanControlProperties IB_LINK_DOWN_CHK_MAKE_DEFINE1 = null;
        private CScanControlProperties IB_LINK_DOWN_CHK_MAKE_DEFINE2 = null;
        private CScanControlProperties IB_LINK_DOWN_CHK_MAKE_DEFINE3 = null;
        private CScanControlProperties IB_LINK_DOWN_CHK_MAKE_DEFINE4 = null;
        private CScanControlProperties IB_LINK_DOWN_CHK_MAKE_DEFINE5 = null;
        private CScanControlProperties IB_LINK_DOWN_CHK_MAKE_DEFINE6 = null;
        private CScanControlProperties IB_LINK_DOWN_CHK_MAKE_DEFINE7 = null;
        private CScanControlProperties IB_LINK_DOWN_CHK_MAKE_DEFINE8 = null;

        private CScanControlProperties IW_JOB_DATA_FOR_DOWNSTREAM_BLOCK1 = null;
        private CScanControlProperties IW_JOB_DATA_FOR_DOWNSTREAM_BLOCK2 = null;
        private CScanControlProperties IW_SENT_OUT_JOB_DATA_SUB_BLOCK1 = null;
        private CScanControlProperties IW_SENT_OUT_JOB_DATA_SUB_BLOCK2 = null;

        private CScanControlProperties IW_JOB_DATA_FOR_UPSTREAM_BLOCK1 = null;
        private CScanControlProperties IW_JOB_DATA_FOR_UPSTREAM_BLOCK2 = null;
        private CScanControlProperties IW_RECEIVED_JOB_DATA_SUB_BLOCK1 = null;
        private CScanControlProperties IW_RECEIVED_JOB_DATA_SUB_BLOCK2 = null;

        private CScanControlProperties IB_RECEIVED_JOB_REPORT_REPLY_UPSTREAM_PATH1 = null;

        //PROBE CIM

        private CPLCControlProperties OB_LINK_UP1_UPSTREAM_INLINE = null;
        private CPLCControlProperties OB_LINK_UP1_UPSTREAM_TROUBLE = null;
        private CPLCControlProperties OB_LINK_UP1_SLOT_NUMBER1 = null;
        private CPLCControlProperties OB_LINK_UP1_SLOT_NUMBER2 = null;
        private CPLCControlProperties OB_LINK_UP1_SLOT_NUMBER3 = null;
        private CPLCControlProperties OB_LINK_UP1_SLOT_NUMBER4 = null;
        private CPLCControlProperties OB_LINK_UP1_SLOT_NUMBER5 = null;
        private CPLCControlProperties OB_LINK_UP1_SLOT_PAIR_FLAG = null;
        private CPLCControlProperties OB_LINK_UP1_ARM_SLOT_PAIR_FLAG = null;
        private CPLCControlProperties OB_LINK_UP1_JOB_TRANSFER_SIGNAL = null;
        private CPLCControlProperties OB_LINK_UP1_SEND_ABLE = null;
        private CPLCControlProperties OB_LINK_UP1_SEND_START = null;
        private CPLCControlProperties OB_LINK_UP1_SEND_COMPLETE = null;
        private CPLCControlProperties OB_LINK_UP1_EXCHANGE_POSSIBLE = null;
        private CPLCControlProperties OB_LINK_UP1_EXCHANGE_EXECUTE = null;
        private CPLCControlProperties OB_LINK_UP1_RESUME_REQUEST = null;
        private CPLCControlProperties OB_LINK_UP1_RESUME_ACK = null;
        private CPLCControlProperties OB_LINK_UP1_CANCEL_REQUEST = null;
        private CPLCControlProperties OB_LINK_UP1_CANCEL_ACK = null;
        private CPLCControlProperties OB_LINK_UP1_ABORT_REQUEST = null;
        private CPLCControlProperties OB_LINK_UP1_ABORT_ACK = null;
        private CPLCControlProperties OB_LINK_UP1_CONVEYER_STATE = null;
        private CPLCControlProperties OB_LINK_UP1_SHUTTER_STATE = null;
        private CPLCControlProperties OB_LINK_UP1_FIRST_SLOT_EXIST = null;
        private CPLCControlProperties OB_LINK_UP1_SECOND_SLOT_EXIST = null;
        private CPLCControlProperties OB_LINK_UP1_THIRD_SLOT_EXIST = null;
        private CPLCControlProperties OB_LINK_UP1_FOURTH_SLOT_EXIST = null;

        private CPLCControlProperties OB_LINK_UP1_CHK_ABNORMAL = null;
        private CPLCControlProperties OB_LINK_UP1_CHK_EMPTY = null;
        private CPLCControlProperties OB_LINK_UP1_CHK_IDLE = null;
        private CPLCControlProperties OB_LINK_UP1_CHK_RUN = null;
        private CPLCControlProperties OB_LINK_UP1_CHK_COMPLETE = null;
        private CPLCControlProperties OB_LINK_UP1_CHK_LIFT_UP_OR_PIN_UP = null;
        private CPLCControlProperties OB_LINK_UP1_CHK_LIFT_DOWN_OR_PIN_DOWN = null;
        private CPLCControlProperties OB_LINK_UP1_CHK_STOPPER_UP_OR_DOOR_OPEN = null;
        private CPLCControlProperties OB_LINK_UP1_CHK_STOPPER_DOWN_OR_DOOR_CLOSE = null;
        private CPLCControlProperties OB_LINK_UP1_CHK_MANUAL_OPERATION = null;
        private CPLCControlProperties OB_LINK_UP1_CHK_BODY_MOVING = null;
        private CPLCControlProperties OB_LINK_UP1_CHK_GLASS_EXIST_ARM1 = null;
        private CPLCControlProperties OB_LINK_UP1_CHK_GLASS_EXIST_ARM2 = null;
        private CPLCControlProperties OB_LINK_UP1_CHK_GLASS_EXIST_ARM3 = null;
        private CPLCControlProperties OB_LINK_UP1_CHK_GLASS_EXIST_ARM4 = null;
        private CPLCControlProperties OB_LINK_UP1_CHK_MAKE_DEFINE1 = null;
        private CPLCControlProperties OB_LINK_UP1_CHK_MAKE_DEFINE2 = null;
        private CPLCControlProperties OB_LINK_UP1_CHK_MAKE_DEFINE3 = null;
        private CPLCControlProperties OB_LINK_UP1_CHK_MAKE_DEFINE4 = null;
        private CPLCControlProperties OB_LINK_UP1_CHK_MAKE_DEFINE5 = null;
        private CPLCControlProperties OB_LINK_UP1_CHK_MAKE_DEFINE6 = null;
        private CPLCControlProperties OB_LINK_UP1_CHK_MAKE_DEFINE7 = null;
        private CPLCControlProperties OB_LINK_UP1_CHK_MAKE_DEFINE8 = null;
        private CPLCControlProperties OB_LINK_DOWN1_DOWNSTREAM_INLINE = null;
        private CPLCControlProperties OB_LINK_DOWN1_DOWNSTREAM_TROUBLE = null;
        private CPLCControlProperties OB_LINK_DOWN1_SLOT_NUMBER1 = null;
        private CPLCControlProperties OB_LINK_DOWN1_SLOT_NUMBER2 = null;
        private CPLCControlProperties OB_LINK_DOWN1_SLOT_NUMBER3 = null;
        private CPLCControlProperties OB_LINK_DOWN1_SLOT_NUMBER4 = null;
        private CPLCControlProperties OB_LINK_DOWN1_SLOT_NUMBER5 = null;
        private CPLCControlProperties OB_LINK_DOWN1_SLOT_PAIR_FLAG = null;
        private CPLCControlProperties OB_LINK_DOWN1_ARM_SLOT_PAIR_FLAG = null;
        private CPLCControlProperties OB_LINK_DOWN1_JOB_TRANSFER_SIGNAL = null;
        private CPLCControlProperties OB_LINK_DOWN1_RECEIVE_ABLE = null;
        private CPLCControlProperties OB_LINK_DOWN1_RECEIVE_START = null;
        private CPLCControlProperties OB_LINK_DOWN1_RECEIVE_COMPLETE = null;
        private CPLCControlProperties OB_LINK_DOWN1_EXCHANGE_POSSIBLE = null;
        private CPLCControlProperties OB_LINK_DOWN1_EXCHANGE_EXECUTE = null;
        private CPLCControlProperties OB_LINK_DOWN1_RESUME_REQUEST = null;
        private CPLCControlProperties OB_LINK_DOWN1_RESUME_ACK = null;
        private CPLCControlProperties OB_LINK_DOWN1_CANCEL_REQUEST = null;
        private CPLCControlProperties OB_LINK_DOWN1_CANCEL_ACK = null;
        private CPLCControlProperties OB_LINK_DOWN1_ABORT_REQUEST = null;
        private CPLCControlProperties OB_LINK_DOWN1_ABORT_ACK = null;
        private CPLCControlProperties OB_LINK_DOWN1_CONVEYER_STATE = null;
        private CPLCControlProperties OB_LINK_DOWN1_SHUTTER_STATE = null;
        private CPLCControlProperties OB_LINK_DOWN1_FIRST_SLOT_EXIST = null;
        private CPLCControlProperties OB_LINK_DOWN1_SECOND_SLOT_EXIST = null;
        private CPLCControlProperties OB_LINK_DOWN1_THIRD_SLOT_EXIST = null;
        private CPLCControlProperties OB_LINK_DOWN1_FOURTH_SLOT_EXIST = null;

        private CPLCControlProperties OB_LINK_DOWN1_CHK_ABNORMAL = null;
        private CPLCControlProperties OB_LINK_DOWN1_CHK_EMPTY = null;
        private CPLCControlProperties OB_LINK_DOWN1_CHK_IDLE = null;
        private CPLCControlProperties OB_LINK_DOWN1_CHK_RUN = null;
        private CPLCControlProperties OB_LINK_DOWN1_CHK_COMPLETE = null;
        private CPLCControlProperties OB_LINK_DOWN1_CHK_LIFT_UP_OR_PIN_UP = null;
        private CPLCControlProperties OB_LINK_DOWN1_CHK_LIFT_DOWN_OR_PIN_DOWN = null;
        private CPLCControlProperties OB_LINK_DOWN1_CHK_STOPPER_UP_OR_DOOR_OPEN = null;
        private CPLCControlProperties OB_LINK_DOWN1_CHK_STOPPER_DOWN_OR_DOOR_CLOSE = null;
        private CPLCControlProperties OB_LINK_DOWN1_CHK_MANUAL_OPERATION = null;
        private CPLCControlProperties OB_LINK_DOWN1_CHK_BODY_MOVING = null;
        private CPLCControlProperties OB_LINK_DOWN1_CHK_GLASS_EXIST_ARM1 = null;
        private CPLCControlProperties OB_LINK_DOWN1_CHK_GLASS_EXIST_ARM2 = null;
        private CPLCControlProperties OB_LINK_DOWN1_CHK_GLASS_EXIST_ARM3 = null;
        private CPLCControlProperties OB_LINK_DOWN1_CHK_GLASS_EXIST_ARM4 = null;
        private CPLCControlProperties OB_LINK_DOWN1_CHK_MAKE_DEFINE1 = null;
        private CPLCControlProperties OB_LINK_DOWN1_CHK_MAKE_DEFINE2 = null;
        private CPLCControlProperties OB_LINK_DOWN1_CHK_MAKE_DEFINE3 = null;
        private CPLCControlProperties OB_LINK_DOWN1_CHK_MAKE_DEFINE4 = null;
        private CPLCControlProperties OB_LINK_DOWN1_CHK_MAKE_DEFINE5 = null;
        private CPLCControlProperties OB_LINK_DOWN1_CHK_MAKE_DEFINE6 = null;
        private CPLCControlProperties OB_LINK_DOWN1_CHK_MAKE_DEFINE7 = null;
        private CPLCControlProperties OB_LINK_DOWN1_CHK_MAKE_DEFINE8 = null;


        private CPLCControlProperties OW_JOB_DATA_FOR_DOWNSTREAM_BLOCK1 = null;
        private CPLCControlProperties OW_SENT_OUT_JOB_DATA_SUB_BLOCK1 = null;
        private CPLCControlProperties OW_JOB_DATA_FOR_UPSTREAM_BLOCK1 = null;
        private CPLCControlProperties OW_RECEIVED_JOB_DATA_SUB_BLOCK1 = null;
        private CPLCControlProperties OB_RECEIVED_JOB_REPORT_UPSTREAMPATH1 = null;
        private CPLCControlProperties OB_SENT_OUT_JOB_REPORT_DOWNSTREAMPATH1 = null;

        private CMain _main = null;
        private bool _enable = false;
        private string _controlName = "";
        private CProbeControl _component = null;
        private CIndexerControl _indexer = null;

        private int T1 = 30000;
        private int T2 = 3000;
        private int T3 = 30000;
        private int T4 = 3000;

        public CLinkSignalType10()
        {
        }

        public override int Init()
        {
            _enable = true;

            //INDEX
            IB_LINK_UP_UPSTREAM_INLINE = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP_UPSTREAM_INLINE");
            IB_LINK_UP_UPSTREAM_TROUBLE = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP_UPSTREAM_TROUBLE");
            IB_LINK_UP_SLOT_NUMBER1 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP_SLOT_NUMBER1");
            IB_LINK_UP_SLOT_NUMBER2 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP_SLOT_NUMBER2");
            IB_LINK_UP_SLOT_NUMBER3 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP_SLOT_NUMBER3");
            IB_LINK_UP_SLOT_NUMBER4 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP_SLOT_NUMBER4");
            IB_LINK_UP_SLOT_NUMBER5 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP_SLOT_NUMBER5");
            IB_LINK_UP_SLOT_PAIR_FLAG = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP_SLOT_PAIR_FLAG");
            IB_LINK_UP_ARM_SLOT_PAIR_FLAG = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP_ARM_SLOT_PAIR_FLAG");
            IB_LINK_UP_JOB_TRANSFER_SIGNAL = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP_JOB_TRANSFER_SIGNAL");
            IB_LINK_UP_SEND_ABLE = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP_SEND_ABLE");
            IB_LINK_UP_SEND_START = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP_SEND_START");
            IB_LINK_UP_SEND_COMPLETE = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP_SEND_COMPLETE");
            IB_LINK_UP_EXCHANGE_POSSIBLE = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP_EXCHANGE_POSSIBLE");
            IB_LINK_UP_EXCHANGE_EXECUTE = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP_EXCHANGE_EXECUTE");
            IB_LINK_UP_RESUME_REQUEST = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP_RESUME_REQUEST");
            IB_LINK_UP_RESUME_ACK = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP_RESUME_ACK");
            IB_LINK_UP_CANCEL_REQUEST = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP_CANCEL_REQUEST");
            IB_LINK_UP_CANCEL_ACK = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP_CANCEL_ACK");
            IB_LINK_UP_ABORT_REQUEST = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP_ABORT_REQUEST");
            IB_LINK_UP_ABOR_ACK = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP_ABOR_ACK");
            IB_LINK_UP_CONVEYER_STATE = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP_CONVEYER_STATE");
            IB_LINK_UP_SHUTTER_STATE = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP_SHUTTER_STATE");
            IB_LINK_UP_FIRST_SLOT_EXIST = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP_FIRST_SLOT_EXIST");
            IB_LINK_UP_SECOND_SLOT_EXIST = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP_SECOND_SLOT_EXIST");
            IB_LINK_UP_THIRD_SLOT_EXIST = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP_THIRD_SLOT_EXIST");
            IB_LINK_UP_FOURTH_SLOT_EXIST = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP_FOURTH_SLOT_EXIST");

            IB_LINK_UP_CHK_ABNORMAL = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP_CHK_ABNORMAL");
            IB_LINK_UP_CHK_EMPTY = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP_CHK_EMPTY");
            IB_LINK_UP_CHK_IDLE = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP_CHK_IDLE");
            IB_LINK_UP_CHK_RUN = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP_CHK_RUN");
            IB_LINK_UP_CHK_COMPLETE = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP_CHK_COMPLETE");
            IB_LINK_UP_CHK_LIFT_UP_OR_PIN_UP = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP_CHK_LIFT_UP_OR_PIN_UP");
            IB_LINK_UP_CHK_LIFT_DOWN_OR_PIN_DOWN = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP_CHK_LIFT_DOWN_OR_PIN_DOWN");
            IB_LINK_UP_CHK_STOPPER_UP_OR_DOOR_OPEN = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP_CHK_STOPPER_UP_OR_DOOR_OPEN");
            IB_LINK_UP_CHK_STOPPER_DOWN_OR_DOOR_CLOSE = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP_CHK_STOPPER_DOWN_OR_DOOR_CLOSE");
            IB_LINK_UP_CHK_MANUAL_OPERATION = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP_CHK_MANUAL_OPERATION");
            IB_LINK_UP_CHK_BODY_MOVING = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP_CHK_BODY_MOVING");
            IB_LINK_UP_CHK_GLASS_EXIST_ARM1 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP_CHK_GLASS_EXIST_ARM1");
            IB_LINK_UP_CHK_GLASS_EXIST_ARM2 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP_CHK_GLASS_EXIST_ARM2");
            IB_LINK_UP_CHK_GLASS_EXIST_ARM3 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP_CHK_GLASS_EXIST_ARM3");
            IB_LINK_UP_CHK_GLASS_EXIST_ARM4 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP_CHK_GLASS_EXIST_ARM4");
            IB_LINK_UP_CHK_MAKE_DEFINE1 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP_CHK_MAKE_DEFINE1");
            IB_LINK_UP_CHK_MAKE_DEFINE2 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP_CHK_MAKE_DEFINE2");
            IB_LINK_UP_CHK_MAKE_DEFINE3 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP_CHK_MAKE_DEFINE3");
            IB_LINK_UP_CHK_MAKE_DEFINE4 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP_CHK_MAKE_DEFINE4");
            IB_LINK_UP_CHK_MAKE_DEFINE5 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP_CHK_MAKE_DEFINE5");
            IB_LINK_UP_CHK_MAKE_DEFINE6 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP_CHK_MAKE_DEFINE6");
            IB_LINK_UP_CHK_MAKE_DEFINE7 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP_CHK_MAKE_DEFINE7");
            IB_LINK_UP_CHK_MAKE_DEFINE8 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP_CHK_MAKE_DEFINE8");

            IB_LINK_DOWN_DOWNSTREAM_INLINE = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN_DOWNSTREAM_INLINE");
            IB_LINK_DOWN_DOWNSTREAM_TROUBLE = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN_DOWNSTREAM_TROUBLE");
            IB_LINK_DOWN_SLOT_NUMBER1 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN_SLOT_NUMBER1");
            IB_LINK_DOWN_SLOT_NUMBER2 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN_SLOT_NUMBER2");
            IB_LINK_DOWN_SLOT_NUMBER3 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN_SLOT_NUMBER3");
            IB_LINK_DOWN_SLOT_NUMBER4 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN_SLOT_NUMBER4");
            IB_LINK_DOWN_SLOT_NUMBER5 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN_SLOT_NUMBER5");
            IB_LINK_DOWN_SLOT_PAIR_FLAG = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN_SLOT_PAIR_FLAG");
            IB_LINK_DOWN_ARM_SLOT_PAIR_FLAG = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN_ARM_SLOT_PAIR_FLAG");
            IB_LINK_DOWN_JOB_TRANSFER_SIGNAL = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN_JOB_TRANSFER_SIGNAL");
            IB_LINK_DOWN_RECEIVE_ABLE = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN_RECEIVE_ABLE");
            IB_LINK_DOWN_RECEIVE_START = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN_RECEIVE_START");
            IB_LINK_DOWN_RECEIVE_COMPLETE = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN_RECEIVE_COMPLETE");
            IB_LINK_DOWN_EXCHANGE_POSSIBLE = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN_EXCHANGE_POSSIBLE");
            IB_LINK_DOWN_EXCHANGE_EXECUTE = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN_EXCHANGE_EXECUTE");
            IB_LINK_DOWN_RESUME_REQUEST = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN_RESUME_REQUEST");
            IB_LINK_DOWN_RESUME_ACK = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN_RESUME_ACK");
            IB_LINK_DOWN_CANCEL_REQUEST = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN_CANCEL_REQUEST");
            IB_LINK_DOWN_CANCEL_ACK = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN_CANCEL_ACK");
            IB_LINK_DOWN_ABORT_REQUEST = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN_ABORT_REQUEST");
            IB_LINK_DOWN_ABORT_ACK = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN_ABORT_ACK");
            IB_LINK_DOWN_CONVEYER_STATE = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN_CONVEYER_STATE");
            IB_LINK_DOWN_SHUTTER_STATE = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN_SHUTTER_STATE");
            IB_LINK_DOWN_FIRST_SLOT_EXIST = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN_FIRST_SLOT_EXIST");
            IB_LINK_DOWN_SECOND_SLOT_EXIST = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN_SECOND_SLOT_EXIST");
            IB_LINK_DOWN_THIRD_SLOT_EXIST = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN_THIRD_SLOT_EXIST");
            IB_LINK_DOWN_FOURTH_SLOT_EXIST = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN_FOURTH_SLOT_EXIST");

            IB_LINK_DOWN_CHK_ABNORMAL = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN_CHK_ABNORMAL");
            IB_LINK_DOWN_CHK_EMPTY = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN_CHK_EMPTY");
            IB_LINK_DOWN_CHK_IDLE = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN_CHK_IDLE");
            IB_LINK_DOWN_CHK_RUN = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN_CHK_RUN");
            IB_LINK_DOWN_CHK_COMPLETE = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN_CHK_COMPLETE");
            IB_LINK_DOWN_CHK_LIFT_UP_OR_PIN_UP = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN_CHK_LIFT_UP_OR_PIN_UP");
            IB_LINK_DOWN_CHK_LIFT_DOWN_OR_PIN_DOWN = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN_CHK_LIFT_DOWN_OR_PIN_DOWN");
            IB_LINK_DOWN_CHK_STOPPER_UP_OR_DOOR_OPEN = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN_CHK_STOPPER_UP_OR_DOOR_OPEN");
            IB_LINK_DOWN_CHK_STOPPER_DOWN_OR_DOOR_CLOSE = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN_CHK_STOPPER_DOWN_OR_DOOR_CLOSE");
            IB_LINK_DOWN_CHK_MANUAL_OPERATION = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN_CHK_MANUAL_OPERATION");
            IB_LINK_DOWN_CHK_BODY_MOVING = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN_CHK_BODY_MOVING");
            IB_LINK_DOWN_CHK_GLASS_EXIST_ARM1 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN_CHK_GLASS_EXIST_ARM1");
            IB_LINK_DOWN_CHK_GLASS_EXIST_ARM2 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN_CHK_GLASS_EXIST_ARM2");
            IB_LINK_DOWN_CHK_GLASS_EXIST_ARM3 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN_CHK_GLASS_EXIST_ARM3");
            IB_LINK_DOWN_CHK_GLASS_EXIST_ARM4 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN_CHK_GLASS_EXIST_ARM4");
            IB_LINK_DOWN_CHK_MAKE_DEFINE1 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN_CHK_MAKE_DEFINE1");
            IB_LINK_DOWN_CHK_MAKE_DEFINE2 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN_CHK_MAKE_DEFINE2");
            IB_LINK_DOWN_CHK_MAKE_DEFINE3 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN_CHK_MAKE_DEFINE3");
            IB_LINK_DOWN_CHK_MAKE_DEFINE4 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN_CHK_MAKE_DEFINE4");
            IB_LINK_DOWN_CHK_MAKE_DEFINE5 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN_CHK_MAKE_DEFINE5");
            IB_LINK_DOWN_CHK_MAKE_DEFINE6 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN_CHK_MAKE_DEFINE6");
            IB_LINK_DOWN_CHK_MAKE_DEFINE7 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN_CHK_MAKE_DEFINE7");
            IB_LINK_DOWN_CHK_MAKE_DEFINE8 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN_CHK_MAKE_DEFINE8");

            IW_JOB_DATA_FOR_DOWNSTREAM_BLOCK1 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IW_JOB_DATA_FOR_DOWNSTREAM_BLOCK1");
            IW_JOB_DATA_FOR_DOWNSTREAM_BLOCK2 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IW_JOB_DATA_FOR_DOWNSTREAM_BLOCK2");
            IW_SENT_OUT_JOB_DATA_SUB_BLOCK1 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IW_SENT_OUT_JOB_DATA_SUB_BLOCK1");
            IW_SENT_OUT_JOB_DATA_SUB_BLOCK2 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IW_SENT_OUT_JOB_DATA_SUB_BLOCK2");

            IW_JOB_DATA_FOR_UPSTREAM_BLOCK1 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IW_JOB_DATA_FOR_UPSTREAM_BLOCK1");
            IW_JOB_DATA_FOR_UPSTREAM_BLOCK2 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IW_JOB_DATA_FOR_UPSTREAM_BLOCK2");
            IW_RECEIVED_JOB_DATA_SUB_BLOCK1 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IW_RECEIVED_JOB_DATA_SUB_BLOCK1");
            IW_RECEIVED_JOB_DATA_SUB_BLOCK2 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IW_RECEIVED_JOB_DATA_SUB_BLOCK2");

            IB_RECEIVED_JOB_REPORT_REPLY_UPSTREAM_PATH1 = _main.SCANCONTEROLS.GetProperty(_component.ControlName, "IB_RECEIVED_JOB_REPORT_REPLY_UPSTREAM_PATH1");
            //PROBE CIM

            OB_LINK_UP1_UPSTREAM_INLINE = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_UPSTREAM_INLINE");
            OB_LINK_UP1_UPSTREAM_TROUBLE = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_UPSTREAM_TROUBLE");
            OB_LINK_UP1_SLOT_NUMBER1 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_SLOT_NUMBER1");
            OB_LINK_UP1_SLOT_NUMBER2 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_SLOT_NUMBER2");
            OB_LINK_UP1_SLOT_NUMBER3 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_SLOT_NUMBER3");
            OB_LINK_UP1_SLOT_NUMBER4 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_SLOT_NUMBER4");
            OB_LINK_UP1_SLOT_NUMBER5 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_SLOT_NUMBER5");
            OB_LINK_UP1_SLOT_PAIR_FLAG = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_SLOT_PAIR_FLAG");
            OB_LINK_UP1_ARM_SLOT_PAIR_FLAG = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_ARM_SLOT_PAIR_FLAG");
            OB_LINK_UP1_JOB_TRANSFER_SIGNAL = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_JOB_TRANSFER_SIGNAL");
            OB_LINK_UP1_SEND_ABLE = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_SEND_ABLE");
            OB_LINK_UP1_SEND_START = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_SEND_START");
            OB_LINK_UP1_SEND_COMPLETE = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_SEND_COMPLETE");
            OB_LINK_UP1_EXCHANGE_POSSIBLE = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_EXCHANGE_POSSIBLE");
            OB_LINK_UP1_EXCHANGE_EXECUTE = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_EXCHANGE_EXECUTE");
            OB_LINK_UP1_RESUME_REQUEST = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_RESUME_REQUEST");
            OB_LINK_UP1_RESUME_ACK = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_RESUME_ACK");
            OB_LINK_UP1_CANCEL_REQUEST = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_CANCEL_REQUEST");
            OB_LINK_UP1_CANCEL_ACK = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_CANCEL_ACK");
            OB_LINK_UP1_ABORT_REQUEST = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_ABORT_REQUEST");
            OB_LINK_UP1_ABORT_ACK = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_ABORT_ACK");
            OB_LINK_UP1_CONVEYER_STATE = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_CONVEYER_STATE");
            OB_LINK_UP1_SHUTTER_STATE = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_SHUTTER_STATE");
            OB_LINK_UP1_FIRST_SLOT_EXIST = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_FIRST_SLOT_EXIST");
            OB_LINK_UP1_SECOND_SLOT_EXIST = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_SECOND_SLOT_EXIST");
            OB_LINK_UP1_THIRD_SLOT_EXIST = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_THIRD_SLOT_EXIST");
            OB_LINK_UP1_FOURTH_SLOT_EXIST = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_FOURTH_SLOT_EXIST");

            OB_LINK_UP1_CHK_ABNORMAL = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_CHK_ABNORMAL");
            OB_LINK_UP1_CHK_EMPTY = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_CHK_EMPTY");
            OB_LINK_UP1_CHK_IDLE = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_CHK_IDLE");
            OB_LINK_UP1_CHK_RUN = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_CHK_RUN");
            OB_LINK_UP1_CHK_COMPLETE = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_CHK_COMPLETE");
            OB_LINK_UP1_CHK_LIFT_UP_OR_PIN_UP = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_CHK_LIFT_UP_OR_PIN_UP");
            OB_LINK_UP1_CHK_LIFT_DOWN_OR_PIN_DOWN = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_CHK_LIFT_DOWN_OR_PIN_DOWN");
            OB_LINK_UP1_CHK_STOPPER_UP_OR_DOOR_OPEN = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_CHK_STOPPER_UP_OR_DOOR_OPEN");
            OB_LINK_UP1_CHK_STOPPER_DOWN_OR_DOOR_CLOSE = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_CHK_STOPPER_DOWN_OR_DOOR_CLOSE");
            OB_LINK_UP1_CHK_MANUAL_OPERATION = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_CHK_MANUAL_OPERATION");
            OB_LINK_UP1_CHK_BODY_MOVING = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_CHK_BODY_MOVING");
            OB_LINK_UP1_CHK_GLASS_EXIST_ARM1 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_CHK_GLASS_EXIST_ARM1");
            OB_LINK_UP1_CHK_GLASS_EXIST_ARM2 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_CHK_GLASS_EXIST_ARM2");
            OB_LINK_UP1_CHK_GLASS_EXIST_ARM3 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_CHK_GLASS_EXIST_ARM3");
            OB_LINK_UP1_CHK_GLASS_EXIST_ARM4 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_CHK_GLASS_EXIST_ARM4");
            OB_LINK_UP1_CHK_MAKE_DEFINE1 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_CHK_MAKE_DEFINE1");
            OB_LINK_UP1_CHK_MAKE_DEFINE2 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_CHK_MAKE_DEFINE2");
            OB_LINK_UP1_CHK_MAKE_DEFINE3 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_CHK_MAKE_DEFINE3");
            OB_LINK_UP1_CHK_MAKE_DEFINE4 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_CHK_MAKE_DEFINE4");
            OB_LINK_UP1_CHK_MAKE_DEFINE5 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_CHK_MAKE_DEFINE5");
            OB_LINK_UP1_CHK_MAKE_DEFINE6 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_CHK_MAKE_DEFINE6");
            OB_LINK_UP1_CHK_MAKE_DEFINE7 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_CHK_MAKE_DEFINE7");
            OB_LINK_UP1_CHK_MAKE_DEFINE8 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_CHK_MAKE_DEFINE8");
            OB_LINK_DOWN1_DOWNSTREAM_INLINE = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_DOWNSTREAM_INLINE");
            OB_LINK_DOWN1_DOWNSTREAM_TROUBLE = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_DOWNSTREAM_TROUBLE");
            OB_LINK_DOWN1_SLOT_NUMBER1 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_SLOT_NUMBER1");
            OB_LINK_DOWN1_SLOT_NUMBER2 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_SLOT_NUMBER2");
            OB_LINK_DOWN1_SLOT_NUMBER3 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_SLOT_NUMBER3");
            OB_LINK_DOWN1_SLOT_NUMBER4 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_SLOT_NUMBER4");
            OB_LINK_DOWN1_SLOT_NUMBER5 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_SLOT_NUMBER5");
            OB_LINK_DOWN1_SLOT_PAIR_FLAG = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_SLOT_PAIR_FLAG");
            OB_LINK_DOWN1_ARM_SLOT_PAIR_FLAG = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_ARM_SLOT_PAIR_FLAG");
            OB_LINK_DOWN1_JOB_TRANSFER_SIGNAL = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_JOB_TRANSFER_SIGNAL");
            OB_LINK_DOWN1_RECEIVE_ABLE = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_RECEIVE_ABLE");
            OB_LINK_DOWN1_RECEIVE_START = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_RECEIVE_START");
            OB_LINK_DOWN1_RECEIVE_COMPLETE = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_RECEIVE_COMPLETE");
            OB_LINK_DOWN1_EXCHANGE_POSSIBLE = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_EXCHANGE_POSSIBLE");
            OB_LINK_DOWN1_EXCHANGE_EXECUTE = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_EXCHANGE_EXECUTE");
            OB_LINK_DOWN1_RESUME_REQUEST = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_RESUME_REQUEST");
            OB_LINK_DOWN1_RESUME_ACK = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_RESUME_ACK");
            OB_LINK_DOWN1_CANCEL_REQUEST = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_CANCEL_REQUEST");
            OB_LINK_DOWN1_CANCEL_ACK = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_CANCEL_ACK");
            OB_LINK_DOWN1_ABORT_REQUEST = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_ABORT_REQUEST");
            OB_LINK_DOWN1_ABORT_ACK = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_ABORT_ACK");
            OB_LINK_DOWN1_CONVEYER_STATE = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_CONVEYER_STATE");
            OB_LINK_DOWN1_SHUTTER_STATE = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_SHUTTER_STATE");
            OB_LINK_DOWN1_FIRST_SLOT_EXIST = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_FIRST_SLOT_EXIST");
            OB_LINK_DOWN1_SECOND_SLOT_EXIST = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_SECOND_SLOT_EXIST");
            OB_LINK_DOWN1_THIRD_SLOT_EXIST = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_THIRD_SLOT_EXIST");
            OB_LINK_DOWN1_FOURTH_SLOT_EXIST = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_FOURTH_SLOT_EXIST");

            OB_LINK_DOWN1_CHK_ABNORMAL = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_CHK_ABNORMAL");
            OB_LINK_DOWN1_CHK_EMPTY = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_CHK_EMPTY");
            OB_LINK_DOWN1_CHK_IDLE = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_CHK_IDLE");
            OB_LINK_DOWN1_CHK_RUN = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_CHK_RUN");
            OB_LINK_DOWN1_CHK_COMPLETE = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_CHK_COMPLETE");
            OB_LINK_DOWN1_CHK_LIFT_UP_OR_PIN_UP = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_CHK_LIFT_UP_OR_PIN_UP");
            OB_LINK_DOWN1_CHK_LIFT_DOWN_OR_PIN_DOWN = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_CHK_LIFT_DOWN_OR_PIN_DOWN");
            OB_LINK_DOWN1_CHK_STOPPER_UP_OR_DOOR_OPEN = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_CHK_STOPPER_UP_OR_DOOR_OPEN");
            OB_LINK_DOWN1_CHK_STOPPER_DOWN_OR_DOOR_CLOSE = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_CHK_STOPPER_DOWN_OR_DOOR_CLOSE");
            OB_LINK_DOWN1_CHK_MANUAL_OPERATION = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_CHK_MANUAL_OPERATION");
            OB_LINK_DOWN1_CHK_BODY_MOVING = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_CHK_BODY_MOVING");
            OB_LINK_DOWN1_CHK_GLASS_EXIST_ARM1 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_CHK_GLASS_EXIST_ARM1");
            OB_LINK_DOWN1_CHK_GLASS_EXIST_ARM2 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_CHK_GLASS_EXIST_ARM2");
            OB_LINK_DOWN1_CHK_GLASS_EXIST_ARM3 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_CHK_GLASS_EXIST_ARM3");
            OB_LINK_DOWN1_CHK_GLASS_EXIST_ARM4 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_CHK_GLASS_EXIST_ARM4");
            OB_LINK_DOWN1_CHK_MAKE_DEFINE1 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_CHK_MAKE_DEFINE1");
            OB_LINK_DOWN1_CHK_MAKE_DEFINE2 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_CHK_MAKE_DEFINE2");
            OB_LINK_DOWN1_CHK_MAKE_DEFINE3 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_CHK_MAKE_DEFINE3");
            OB_LINK_DOWN1_CHK_MAKE_DEFINE4 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_CHK_MAKE_DEFINE4");
            OB_LINK_DOWN1_CHK_MAKE_DEFINE5 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_CHK_MAKE_DEFINE5");
            OB_LINK_DOWN1_CHK_MAKE_DEFINE6 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_CHK_MAKE_DEFINE6");
            OB_LINK_DOWN1_CHK_MAKE_DEFINE7 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_CHK_MAKE_DEFINE7");
            OB_LINK_DOWN1_CHK_MAKE_DEFINE8 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_CHK_MAKE_DEFINE8");

            OW_JOB_DATA_FOR_DOWNSTREAM_BLOCK1 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OW_JOB_DATA_FOR_DOWNSTREAM_BLOCK1");
            OW_SENT_OUT_JOB_DATA_SUB_BLOCK1 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OW_SENT_OUT_JOB_DATA_SUB_BLOCK1");
            OW_JOB_DATA_FOR_UPSTREAM_BLOCK1 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OW_JOB_DATA_FOR_UPSTREAM_BLOCK1");
            OW_RECEIVED_JOB_DATA_SUB_BLOCK1 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OW_RECEIVED_JOB_DATA_SUB_BLOCK1");

            OB_RECEIVED_JOB_REPORT_UPSTREAMPATH1 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_RECEIVED_JOB_REPORT_UPSTREAMPATH1");
            OB_SENT_OUT_JOB_REPORT_DOWNSTREAMPATH1 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_SENT_OUT_JOB_REPORT_DOWNSTREAMPATH1");
            _main.ProgramsAdd(this);
            return 0;
        }

        public override int AddArgs(object[] args, bool beforeClear)
        {
            if (args == null || args.Length < 3)
                return -1;

            if ((args[0] is CMain && args[1] is CProbeControl && args[2] is CIndexerControl) == false)
            {
                return -1;
            }

            if (beforeClear)
            {

            }

            _main = args[0] as CMain;
            _component = args[1] as CProbeControl;
            _indexer = args[2] as CIndexerControl;

            return 0;
        }

        public override string Description
        {
            get { return "Link Signal Type 1 대응"; }
        }

        public override string Development
        {
            get { return "(주)서진정보기술"; }
        }

        public override bool Enable
        {
            get { return _enable; }
        }

        public override bool IsCycle
        {
            get { return true; }
        }

        public override string Name
        {
            get { return "LINK_SIGNAL_TYPE5"; }
        }

        public override string Version
        {
            get { return "ver 1.0"; }
        }
        public override string SIteName
        {
            get { return "B10"; }
        }
        public override bool IsAsyncCall
        {
            get { return true; }
        }

        public enum enumStep
        {
            NONE,
            WAIT,
            DATA_CHECK,
            WAIT_START,
            START,
            MOVING,
            WAIT_RECV_COMPLETE,
            WAIT_SEND_COMPLETE,
            RECV_COMPLETE,
            SEND_COMPLETE,
            REPORT,
            END,
            CANCEL,
            T1,
            T2,
            T3,
            T4
        }

        private enumStep _step = enumStep.NONE;
        private enumStep _previousStep = enumStep.NONE;
        private CGlassDataProperties glassData = null;
        protected override int InnerExecute()
        {
            int ret = 0;

            bool t1Start = false;
            bool t2Start = false;
            bool t3Start = false;
            bool t4Start = false;

            bool t1Timeout = false;
            bool t2Timeout = false;
            bool t3Timeout = false;
            bool t4Timeout = false;

            int t1Count = 0;
            int t2Count = 0;
            int t3Count = 0;
            int t4Count = 0;

            int T1 = 30000;
            int T2 = 3000;
            int T3 = 30000;
            int T4 = 3000;

            while (true)
            {
                bool stageUpstream = _main.MelsecNetBitRead(OB_LINK_UP1_UPSTREAM_INLINE, 1);
                bool stageDownstream = _main.MelsecNetBitRead(OB_LINK_DOWN1_DOWNSTREAM_INLINE, 1);
                bool stageExchangePossible = _main.MelsecNetBitRead(OB_LINK_UP1_EXCHANGE_POSSIBLE, 1);

                bool robotUpstream = _main.MelsecNetBitRead(IB_LINK_UP_UPSTREAM_INLINE, 1);
                bool robotDownstream = _main.MelsecNetBitRead(IB_LINK_DOWN_DOWNSTREAM_INLINE, 1);
                
                
                //bool sendAble = false;

                switch (_step)
                {
                    case enumStep.NONE:
                        if (stageUpstream && stageDownstream && stageExchangePossible && robotUpstream && robotDownstream && _component.UnloadRequest)
                        {
                            Log(string.Format("{0}\t[{1}]", "PROGRAM START", this.Name.ToUpper()));
                            //stage_downstream : job data write, send able on write

                            List<int> value1 = new List<int>();
                            value1.Add(1);
                            value1.Add(1);

                            List<int> value2 = new List<int>();
                            value2.Add(1);
                            value2.Add(1);

                            if (_main.ReceivedGlassDatas.ContainsKey(_component.ControlName))
                            {
                                //임시
                                glassData = _main.ReceivedGlassDatas[_component.ControlName][0] as CGlassDataProperties;
                                _main.AddSentOutGlassData(_component.ControlName, glassData, 0);

                                if (glassData != null)
                                {
                                    value1 = CGlassDataProperties.ConvertPLCData(glassData);

                                    _main.MelsecNetMultiWordWrite(OW_JOB_DATA_FOR_DOWNSTREAM_BLOCK1, value1);
                                    _main.MelsecNetMultiWordWrite(OW_SENT_OUT_JOB_DATA_SUB_BLOCK1, value2);
                                    _main.MelsecNetBitOnOff(OB_LINK_UP1_SEND_ABLE, true);

                                    _step = enumStep.WAIT;
                                }
                                else
                                {
                                    //Data가 없으면 어찌하지 ㅡㅡ;
                                }
                            }
                            else
                            {
 
                            }
                        }
                        break;
                    case enumStep.WAIT:
                        //robot_downstream : exchange execute on, receive able on
                        if (_main.MelsecNetBitRead(IB_LINK_DOWN_RECEIVE_ABLE, 1) && _main.MelsecNetBitRead(IB_LINK_DOWN_EXCHANGE_EXECUTE, 1))
                        {
                            //robot_upstream send able on
                            if (_main.MelsecNetBitRead(IB_LINK_UP_SEND_ABLE, 1))
                            {
                                _step = enumStep.DATA_CHECK;
                            }

                        }

                        break;
                    case enumStep.DATA_CHECK:

                        //stage_downstream : job data check
                        ushort[] jobDataRaw = null;
                        ushort[] jobDataSubRaw = null;

                        jobDataRaw = _main.MelsecNetMultiWordRead(IW_JOB_DATA_FOR_DOWNSTREAM_BLOCK1);
                        jobDataSubRaw = _main.MelsecNetMultiWordRead(IW_SENT_OUT_JOB_DATA_SUB_BLOCK1);

                        glassData = new CGlassDataProperties(jobDataRaw);

                        this.RecevieJobDataCheck(glassData);
                        _main.AddReceviedGlassData(_component.ControlName, glassData, 0);

                        _step = enumStep.WAIT_START;
                        break;
                    case enumStep.WAIT_START:

                        //stage_upstream : send start on
                        _main.MelsecNetBitOnOff(OB_LINK_UP1_SEND_START, true);

                        _step = enumStep.START;
                        break;
                    case enumStep.START:
                        //robot_downstream : receive start on
                        if (_main.MelsecNetBitRead(IB_LINK_DOWN_RECEIVE_START, 1))
                        {
                            _step = enumStep.MOVING;
                        }
 
                        break;
                    case enumStep.MOVING:
                        //robot_downstream : job transfer signal on
                        if (_main.MelsecNetBitRead(IB_LINK_DOWN_JOB_TRANSFER_SIGNAL, 1))
                        {
                            glassData = _main.ReceivedGlassDatas[_component.ControlName][0] as CGlassDataProperties;

                            if (glassData != null)
                            {
                                List<int> value1 = new List<int>();

                                value1 = CGlassDataProperties.ConvertPLCData(glassData);

                                _main.MelsecNetMultiWordWrite(OW_JOB_DATA_FOR_UPSTREAM_BLOCK1, value1);
                            }

                            //stage_upstream : sent out job report
                            _component.GetProgram("SENT_OUT_JOB_REPORT").Execute();

                            //stage_downstream : receive able on
                            _main.MelsecNetBitOnOff(OB_LINK_DOWN1_RECEIVE_ABLE, true); Thread.Sleep(20);//able on이 된후 start를 하게되있는데..
                            //stage_downstream : receive start on
                            _main.MelsecNetBitOnOff(OB_LINK_DOWN1_RECEIVE_START, true);
                            _step = enumStep.WAIT_RECV_COMPLETE;
                        }
                        else if (_main.MelsecNetBitRead(OB_LINK_UP1_CANCEL_REQUEST, 1))
                        {
                            if (_main.MelsecNetBitRead(IB_LINK_DOWN_CANCEL_ACK, 1))
                            {
                                _main.MelsecNetBitOnOff(OB_LINK_UP1_SEND_ABLE, false);
                                _main.MelsecNetBitOnOff(OB_LINK_UP1_SEND_START, false);
                                _main.MelsecNetBitOnOff(OB_LINK_UP1_CANCEL_REQUEST, false);
                                _step = enumStep.CANCEL;
                            }
                        }
                        break;
                    case enumStep.CANCEL:
                        if (_main.MelsecNetBitRead(IB_LINK_DOWN_CANCEL_ACK, 1) == false)
                        {
                            _step = enumStep.NONE;
                            Log(string.Format("{0}\t[{1}]\tRET={2}", "PROGRAM CANCEL END", this.Name.ToUpper(), ret));
                        }
                        break;
                    case enumStep.WAIT_RECV_COMPLETE:
                        //robot downstream : receive complete on
                        if (_main.MelsecNetBitRead(IB_LINK_DOWN_RECEIVE_COMPLETE, 1))
                        {
                            _component.UnloadRequest = false;
                            //stage upstream : send complete on 
                            _main.MelsecNetBitOnOff(OB_LINK_UP1_SEND_COMPLETE, true);
                            _step = enumStep.RECV_COMPLETE;
                        }
                        break;
                    case enumStep.RECV_COMPLETE:
                        //robot downstream : receive able, start, completed, transfer signal off
                        if (_main.MelsecNetBitRead(IB_LINK_DOWN_RECEIVE_ABLE, 1) == false)
                            if (_main.MelsecNetBitRead(IB_LINK_DOWN_RECEIVE_START, 1) == false)
                                if (_main.MelsecNetBitRead(IB_LINK_DOWN_RECEIVE_COMPLETE, 1) == false)
                                {
                                    //stage upstream : send able, start, completed, transfer signal off
                                    _main.MelsecNetBitOnOff(OB_LINK_UP1_SEND_ABLE, false);
                                    _main.MelsecNetBitOnOff(OB_LINK_UP1_SEND_START, false);
                                    _main.MelsecNetBitOnOff(OB_LINK_UP1_SEND_COMPLETE, false);
                                    _step = enumStep.WAIT_SEND_COMPLETE;
                                }

                        break;
                    case enumStep.WAIT_SEND_COMPLETE:
                        //robot upstream : send complete on
                        if (_main.MelsecNetBitRead(IB_LINK_UP_SEND_COMPLETE, 1))
                        {
                            _component.UnloadRequest = false;
                            //stage downstream : receive complete on 
                            _main.MelsecNetBitOnOff(OB_LINK_DOWN1_RECEIVE_COMPLETE, true);
                            _step = enumStep.SEND_COMPLETE;
                        }
                        break;
                    case enumStep.SEND_COMPLETE:
                        //robot upstream : send able, start, completed, transfer signal off
                        if (_main.MelsecNetBitRead(IB_LINK_UP_SEND_ABLE, 1) == false)
                            if (_main.MelsecNetBitRead(IB_LINK_UP_SEND_START, 1) == false)
                                if (_main.MelsecNetBitRead(IB_LINK_UP_SEND_COMPLETE, 1) == false)
                                {
                                    //stage downstream : receive able, start, completed, transfer signal off
                                    _main.MelsecNetBitOnOff(OB_LINK_DOWN1_RECEIVE_ABLE, false);
                                    _main.MelsecNetBitOnOff(OB_LINK_DOWN1_RECEIVE_START, false);
                                    _main.MelsecNetBitOnOff(OB_LINK_DOWN1_RECEIVE_COMPLETE, false);
                                    _step = enumStep.REPORT;
                                }

                        break;
                    case enumStep.REPORT:
                        _component.GetProgram("RECEIVED_JOB_REPORT").Execute();
                        _step = enumStep.END;
                        break;
                    case enumStep.END:
                        Log(string.Format("{0}\t[{1}]\tRET={2}", "PROGRAM END", this.Name.ToUpper(), ret));
                        _step = enumStep.NONE;
                        break;
                    case enumStep.T1:
                        Dictionary<string, string> t1Value = new Dictionary<string, string>();
                        t1Value.Add("ALARM_SET", "T1");
                        _component.GetProgram("").ExecuteManual(t1Value);
                        _step = _previousStep;
                        break;
                    case enumStep.T2:
                        Dictionary<string, string> t2Value = new Dictionary<string, string>();
                        t2Value.Add("ALARM_SET", "T2");
                        _component.GetProgram("").ExecuteManual(t2Value);
                        _step = _previousStep;
                        break;
                    case enumStep.T3:
                        Dictionary<string, string> t3Value = new Dictionary<string, string>();
                        t3Value.Add("ALARM_SET", "T3");
                        _component.GetProgram("").ExecuteManual(t3Value);
                        _step = _previousStep;
                        break;
                    case enumStep.T4:
                        Dictionary<string, string> t4Value = new Dictionary<string, string>();
                        t4Value.Add("ALARM_SET", "T4");
                        _component.GetProgram("").ExecuteManual(t4Value);
                        _step = _previousStep;
                        break;
                    default:
                        break;
                }

                if (t1Start)
                {
                    if (t1Count++ < T1 * 10) //100*10 = 1초,
                    {
                        t1Timeout = true;
                        t1Start = false;
                        t1Count = 0;
                        _previousStep = _step;
                        _step = enumStep.T1;
                    }
                }

                if (t2Start)
                {
                    if (t2Count++ < T2 * 10) //100*10 = 1초,
                    {
                        t2Timeout = true;
                        t2Start = false;
                        t2Count = 0;
                        _previousStep = _step;
                        _step = enumStep.T2;
                    }
                }

                if (t3Start)
                {
                    if (t3Count++ < T3 * 10) //100*10 = 1초,
                    {
                        t3Timeout = true;
                        t3Start = false;
                        t3Count = 0;
                        _previousStep = _step;
                        _step = enumStep.T3;
                    }
                }

                if (t4Start)
                {
                    if (t4Count++ < T4 * 10) //100*10 = 1초,
                    {
                        t4Timeout = true;
                        t4Start = false;
                        t4Count = 0;
                        _previousStep = _step;
                        _step = enumStep.T4;
                    }
                }

                Thread.Sleep(100);
            }
            return 0;
        }
        private bool RecevieJobDataCheck(CGlassDataProperties glassData)
        {
            //뭘검사하는건가...
            return true;
        }
    }
}