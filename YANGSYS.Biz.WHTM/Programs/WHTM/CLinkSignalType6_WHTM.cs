using System;
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
using SOFD.Global.Manager;


namespace YANGSYS.Biz.Programs
{
    public class CLinkSignalType6_WHTM : AProgram
    {
        //BC
        #region
        private CScanControlProperties IB_LINK_UP1_UPSTREAM_INLINE = null;
        private CScanControlProperties IB_LINK_UP1_UPSTREAM_TROUBLE = null;
        private CScanControlProperties IB_LINK_UP1_HAND_INTERFERENCE = null;
        private CScanControlProperties IB_LINK_UP1_JOB_TRANSFER_SIGNAL = null;
        private CScanControlProperties IB_LINK_UP1_SEND_ABLE = null;
        private CScanControlProperties IB_LINK_UP1_SEND_START = null;
        private CScanControlProperties IB_LINK_UP1_SEND_COMPLETE = null;
        private CScanControlProperties IB_LINK_UP1_EXCHANGE_POSSIBLE = null;
        private CScanControlProperties IB_LINK_UP1_CONVEYER_STATE = null;
        private CScanControlProperties IB_LINK_UP1_SHUTTER_STATE = null;
        private CScanControlProperties IB_LINK_UP1_JOB_TRANSFER_SIGNAL2 = null;
        private CScanControlProperties IB_LINK_UP1_DOUBLE_PITCH = null;
        private CScanControlProperties IB_LINK_UP1_FOUR_GLASSES = null;
        private CScanControlProperties IB_LINK_UP1_HAND2_INTERFERENCE = null;
        private CScanControlProperties IB_LINK_UP1_SEND_READY = null;
        private CScanControlProperties IB_LINK_UP1_HALFGLASSFLAG = null;
        private CScanControlProperties IB_LINK_UP1_CHK_AVAILABLE = null;
        private CScanControlProperties IB_LINK_UP1_CHK_LIFT_UP_OR_PIN_UP = null;
        private CScanControlProperties IB_LINK_UP1_CHK_LIFT_DOWN_OR_PIN_DOWN = null;
        private CScanControlProperties IB_LINK_UP1_CHK_STOPPER_UP_OR_DOOR_OPEN = null;
        private CScanControlProperties IB_LINK_UP1_CHK_STOPPER_DOWN_OR_DOOR_CLOSE = null;
        private CScanControlProperties IB_LINK_UP1_CHK_MANUAL_OPERATION = null;
        private CScanControlProperties IB_LINK_UP1_CHK_BODY_MOVING = null;
        private CScanControlProperties IB_LINK_UP1_CHK_COMPLETE = null;
        private CScanControlProperties IB_LINK_UP1_CHK_GLASS_EXIST_ARM1 = null;
        private CScanControlProperties IB_LINK_UP1_CHK_GLASS_EXIST_ARM2 = null;
        private CScanControlProperties IB_LINK_UP1_CHK_GLASS_EXIST_ARM3 = null;
        private CScanControlProperties IB_LINK_UP1_CHK_GLASS_EXIST_ARM4 = null;
        private CScanControlProperties IB_LINK_UP1_CHK_RESERVED1 = null;
        private CScanControlProperties IB_LINK_UP1_CHK_RESERVED2 = null;
        private CScanControlProperties IB_LINK_UP1_CHK_RESERVED3 = null;
        private CScanControlProperties IB_LINK_UP1_CHK_RESERVED4 = null;
        private CScanControlProperties IB_LINK_DOWN1_DOWNSTREAM_INLINE = null;
        private CScanControlProperties IB_LINK_DOWN1_DOWNSTREAM_TROUBLE = null;
        private CScanControlProperties IB_LINK_DOWN1_HAND_INTERFERENCE = null;
        private CScanControlProperties IB_LINK_DOWN1_JOB_TRANSFER_SIGNAL = null;
        private CScanControlProperties IB_LINK_DOWN1_RECEIVE_ABLE = null;
        private CScanControlProperties IB_LINK_DOWN1_RECEIVE_START = null;
        private CScanControlProperties IB_LINK_DOWN1_RECEIVE_COMPLETE = null;
        private CScanControlProperties IB_LINK_DOWN1_EXCHANGE_EXECUTE = null;
        private CScanControlProperties IB_LINK_DOWN1_CONVEYER_STATE = null;
        private CScanControlProperties IB_LINK_DOWN1_SHUTTER_STATE = null;
        private CScanControlProperties IB_LINK_DOWN1_DOUBLE_PITCH = null;
        private CScanControlProperties IB_LINK_DOWN1_FOUR_GLASSES = null;
        private CScanControlProperties IB_LINK_DOWN1_RESERVED1 = null;
        private CScanControlProperties IB_LINK_DOWN1_EXCHANGE_CANCEL_RECEIVE = null;
        private CScanControlProperties IB_LINK_DOWN1_RECEIVE_READY = null;
        private CScanControlProperties IB_LINK_DOWN1_RESERVED2 = null;
        private CScanControlProperties IB_LINK_DOWN1_CHK_AVAILABLE = null;
        private CScanControlProperties IB_LINK_DOWN1_CHK_LIFT_UP_OR_PIN_UP = null;
        private CScanControlProperties IB_LINK_DOWN1_CHK_LIFT_DOWN_OR_PIN_DOWN = null;
        private CScanControlProperties IB_LINK_DOWN1_CHK_STOPPER_UP_OR_DOOR_OPEN = null;
        private CScanControlProperties IB_LINK_DOWN1_CHK_STOPPER_DOWN_OR_DOOR_CLOSE = null;
        private CScanControlProperties IB_LINK_DOWN1_CHK_MANUAL_OPERATION = null;
        private CScanControlProperties IB_LINK_DOWN1_CHK_BODY_MOVING = null;
        private CScanControlProperties IB_LINK_DOWN1_CHK_COMPLETE = null;
        private CScanControlProperties IB_LINK_DOWN1_CHK_GLASS_EXIST_ARM1 = null;
        private CScanControlProperties IB_LINK_DOWN1_CHK_GLASS_EXIST_ARM2 = null;
        private CScanControlProperties IB_LINK_DOWN1_CHK_GLASS_EXIST_ARM3 = null;
        private CScanControlProperties IB_LINK_DOWN1_CHK_GLASS_EXIST_ARM4 = null;
        private CScanControlProperties IB_LINK_DOWN1_CHK_RESERVED1 = null;
        private CScanControlProperties IB_LINK_DOWN1_CHK_RESERVED2 = null;
        private CScanControlProperties IB_LINK_DOWN1_CHK_RESERVED3 = null;
        private CScanControlProperties IB_LINK_DOWN1_CHK_RESERVED4 = null;

        private CScanControlProperties IW_LINK_DOWN1_JOB_DATA1 = null;
        private CScanControlProperties IW_LINK_DOWN1_JOB_DATA2 = null;
        //private CScanControlProperties IW_LINK_DOWN1_JOB_DATA1_CASSETTE_INDEX = null;
        //private CScanControlProperties IW_LINK_DOWN1_JOB_DATA1_GLASS_INDEX = null;
        //private CScanControlProperties IW_LINK_DOWN1_JOB_DATA1_PRODUCT_CODE = null;
        //private CScanControlProperties IW_LINK_DOWN1_JOB_DATA1_GLASS_THICKNESS = null;
        //private CScanControlProperties IW_LINK_DOWN1_JOB_DATA1_LOT_ID = null;
        //private CScanControlProperties IW_LINK_DOWN1_JOB_DATA1_GLASS_ID = null;
        //private CScanControlProperties IW_LINK_DOWN1_JOB_DATA1_PPID = null;
        //private CScanControlProperties IW_LINK_DOWN1_JOB_DATA1_GLASSTYPE = null;
        //private CScanControlProperties IW_LINK_DOWN1_JOB_DATA1_JOB_JUDGE = null;
        //private CScanControlProperties IW_LINK_DOWN1_JOB_DATA1_JOB_GRADE = null;
        //private CScanControlProperties IW_LINK_DOWN1_JOB_DATA1_JOB_STATE = null;
        //private CScanControlProperties IW_LINK_DOWN1_JOB_DATA1_TRACKING_DATA = null;
        //private CScanControlProperties IW_LINK_DOWN1_JOB_DATA1_LOC_UNIT_PATH_NO = null;
        //private CScanControlProperties IW_LINK_DOWN1_JOB_DATA1_LOC_SLOT_NO = null;
        //private CScanControlProperties IW_LINK_DOWN1_JOB_DATA1_CYCLETIME = null;
        //private CScanControlProperties IW_LINK_DOWN1_JOB_DATA1_TACTTIME = null;
        //private CScanControlProperties IW_LINK_DOWN1_JOB_DATA1_REASON_CODE = null;
        //private CScanControlProperties IW_LINK_DOWN1_JOB_DATA1_SAMPLING_FLAG = null;
        //private CScanControlProperties IW_LINK_DOWN1_JOB_DATA1_LOT_END_FLAG = null;
        //private CScanControlProperties IW_LINK_DOWN1_JOB_DATA1_OPERATIONID = null;
        //private CScanControlProperties IW_LINK_DOWN1_JOB_DATA1_PRODUCTID = null;
        //private CScanControlProperties IW_LINK_DOWN1_JOB_DATA1_CASSETTEID = null;
        //private CScanControlProperties IW_LINK_DOWN1_JOB_DATA1_RESERVED = null;
        private CScanControlProperties IW_LINK_DOWN1_TRANS_JOB_DATA1 = null;
        private CScanControlProperties IW_LINK_DOWN1_TRANS_JOB_DATA2 = null;

        //private CScanControlProperties IW_LINK_DOWN1_TRANS_JOB_DATA1_IN_UNIT_PATH_NO = null;
        //private CScanControlProperties IW_LINK_DOWN1_TRANS_JOB_DATA1_IN_SLOT_NO = null;
        //private CScanControlProperties IW_LINK_DOWN1_TRANS_JOB_DATA2_IN_UNIT_PATH_NO = null;
        //private CScanControlProperties IW_LINK_DOWN1_TRANS_JOB_DATA2_IN_SLOT_NO = null;
        #endregion
        //PROBE CIM
        #region
        private CPLCControlProperties OB_LINK_UP1_UPSTREAM_INLINE = null;
        private CPLCControlProperties OB_LINK_UP1_UPSTREAM_TROUBLE = null;
        private CPLCControlProperties OB_LINK_UP1_HAND_INTERFERENCE = null;
        private CPLCControlProperties OB_LINK_UP1_JOB_TRANSFER_SIGNAL = null;
        private CPLCControlProperties OB_LINK_UP1_SEND_ABLE = null;
        private CPLCControlProperties OB_LINK_UP1_SEND_START = null;
        private CPLCControlProperties OB_LINK_UP1_SEND_COMPLETE = null;
        private CPLCControlProperties OB_LINK_UP1_EXCHANGE_POSSIBLE = null;
        private CPLCControlProperties OB_LINK_UP1_CONVEYER_STATE = null;
        private CPLCControlProperties OB_LINK_UP1_SHUTTER_STATE = null;
        private CPLCControlProperties OB_LINK_UP1_JOB_TRANSFER_SIGNAL2 = null;
        private CPLCControlProperties OB_LINK_UP1_DOUBLE_PITCH = null;
        private CPLCControlProperties OB_LINK_UP1_FOUR_GLASSES = null;
        private CPLCControlProperties OB_LINK_UP1_HAND2_INTERFERENCE = null;
        private CPLCControlProperties OB_LINK_UP1_SEND_READY = null;
        private CPLCControlProperties OB_LINK_UP1_HALFGLASSFLAG = null;
        private CPLCControlProperties OB_LINK_UP1_CHK_AVAILABLE = null;
        private CPLCControlProperties OB_LINK_UP1_CHK_LIFT_UP_OR_PIN_UP = null;
        private CPLCControlProperties OB_LINK_UP1_CHK_LIFT_DOWN_OR_PIN_DOWN = null;
        private CPLCControlProperties OB_LINK_UP1_CHK_STOPPER_UP_OR_DOOR_OPEN = null;
        private CPLCControlProperties OB_LINK_UP1_CHK_STOPPER_DOWN_OR_DOOR_CLOSE = null;
        private CPLCControlProperties OB_LINK_UP1_CHK_MANUAL_OPERATION = null;
        private CPLCControlProperties OB_LINK_UP1_CHK_BODY_MOVING = null;
        private CPLCControlProperties OB_LINK_UP1_CHK_COMPLETE = null;
        private CPLCControlProperties OB_LINK_UP1_CHK_GLASS_EXIST_ARM1 = null;
        private CPLCControlProperties OB_LINK_UP1_CHK_GLASS_EXIST_ARM2 = null;
        private CPLCControlProperties OB_LINK_UP1_CHK_GLASS_EXIST_ARM3 = null;
        private CPLCControlProperties OB_LINK_UP1_CHK_GLASS_EXIST_ARM4 = null;
        private CPLCControlProperties OB_LINK_UP1_CHK_RESERVED1 = null;
        private CPLCControlProperties OB_LINK_UP1_CHK_RESERVED2 = null;
        private CPLCControlProperties OB_LINK_UP1_CHK_RESERVED3 = null;
        private CPLCControlProperties OB_LINK_UP1_CHK_RESERVED4 = null;
        private CPLCControlProperties OB_LINK_DOWN1_DOWNSTREAM_INLINE = null;
        private CPLCControlProperties OB_LINK_DOWN1_DOWNSTREAM_TROUBLE = null;
        private CPLCControlProperties OB_LINK_DOWN1_HAND_INTERFERENCE = null;
        private CPLCControlProperties OB_LINK_DOWN1_JOB_TRANSFER_SIGNAL = null;
        private CPLCControlProperties OB_LINK_DOWN1_RECEIVE_ABLE = null;
        private CPLCControlProperties OB_LINK_DOWN1_RECEIVE_START = null;
        private CPLCControlProperties OB_LINK_DOWN1_RECEIVE_COMPLETE = null;
        private CPLCControlProperties OB_LINK_DOWN1_EXCHANGE_EXECUTE = null;
        private CPLCControlProperties OB_LINK_DOWN1_CONVEYER_STATE = null;
        private CPLCControlProperties OB_LINK_DOWN1_SHUTTER_STATE = null;
        private CPLCControlProperties OB_LINK_DOWN1_DOUBLE_PITCH = null;
        private CPLCControlProperties OB_LINK_DOWN1_FOUR_GLASSES = null;
        private CPLCControlProperties OB_LINK_DOWN1_RESERVED1 = null;
        private CPLCControlProperties OB_LINK_DOWN1_EXCHANGE_CANCEL_RECEIVE = null;
        private CPLCControlProperties OB_LINK_DOWN1_RECEIVE_READY = null;
        private CPLCControlProperties OB_LINK_DOWN1_RESERVED2 = null;
        private CPLCControlProperties OB_LINK_DOWN1_CHK_AVAILABLE = null;
        private CPLCControlProperties OB_LINK_DOWN1_CHK_LIFT_UP_OR_PIN_UP = null;
        private CPLCControlProperties OB_LINK_DOWN1_CHK_LIFT_DOWN_OR_PIN_DOWN = null;
        private CPLCControlProperties OB_LINK_DOWN1_CHK_STOPPER_UP_OR_DOOR_OPEN = null;
        private CPLCControlProperties OB_LINK_DOWN1_CHK_STOPPER_DOWN_OR_DOOR_CLOSE = null;
        private CPLCControlProperties OB_LINK_DOWN1_CHK_MANUAL_OPERATION = null;
        private CPLCControlProperties OB_LINK_DOWN1_CHK_BODY_MOVING = null;
        private CPLCControlProperties OB_LINK_DOWN1_CHK_COMPLETE = null;
        private CPLCControlProperties OB_LINK_DOWN1_CHK_GLASS_EXIST_ARM1 = null;
        private CPLCControlProperties OB_LINK_DOWN1_CHK_GLASS_EXIST_ARM2 = null;
        private CPLCControlProperties OB_LINK_DOWN1_CHK_GLASS_EXIST_ARM3 = null;
        private CPLCControlProperties OB_LINK_DOWN1_CHK_GLASS_EXIST_ARM4 = null;
        private CPLCControlProperties OB_LINK_DOWN1_CHK_RESERVED1 = null;
        private CPLCControlProperties OB_LINK_DOWN1_CHK_RESERVED2 = null;
        private CPLCControlProperties OB_LINK_DOWN1_CHK_RESERVED3 = null;
        private CPLCControlProperties OB_LINK_DOWN1_CHK_RESERVED4 = null;

        private CPLCControlProperties OW_LINK_DOWN1_JOB_DATA1 = null;
        private CPLCControlProperties OW_LINK_DOWN1_JOB_DATA2 = null;

        //private CPLCControlProperties OW_LINK_DOWN1_JOW_DATA1_CASSETTE_INDEX = null;
        //private CPLCControlProperties OW_LINK_DOWN1_JOW_DATA1_GLASS_INDEX = null;
        //private CPLCControlProperties OW_LINK_DOWN1_JOW_DATA1_PRODUCT_CODE = null;
        //private CPLCControlProperties OW_LINK_DOWN1_JOW_DATA1_GLASS_THICKNESS = null;
        //private CPLCControlProperties OW_LINK_DOWN1_JOW_DATA1_LOT_ID = null;
        //private CPLCControlProperties OW_LINK_DOWN1_JOW_DATA1_GLASS_ID = null;
        //private CPLCControlProperties OW_LINK_DOWN1_JOW_DATA1_PPID = null;
        //private CPLCControlProperties OW_LINK_DOWN1_JOW_DATA1_GLASSTYPE = null;
        //private CPLCControlProperties OW_LINK_DOWN1_JOW_DATA1_JOW_JUDGE = null;
        //private CPLCControlProperties OW_LINK_DOWN1_JOW_DATA1_JOW_GRADE = null;
        //private CPLCControlProperties OW_LINK_DOWN1_JOW_DATA1_JOW_STATE = null;
        //private CPLCControlProperties OW_LINK_DOWN1_JOW_DATA1_TRACKING_DATA = null;
        //private CPLCControlProperties OW_LINK_DOWN1_JOW_DATA1_LOC_UNIT_PATH_NO = null;
        //private CPLCControlProperties OW_LINK_DOWN1_JOW_DATA1_LOC_SLOT_NO = null;
        //private CPLCControlProperties OW_LINK_DOWN1_JOW_DATA1_CYCLETIME = null;
        //private CPLCControlProperties OW_LINK_DOWN1_JOW_DATA1_TACTTIME = null;
        //private CPLCControlProperties OW_LINK_DOWN1_JOW_DATA1_REASON_CODE = null;
        //private CPLCControlProperties OW_LINK_DOWN1_JOW_DATA1_SAMPLING_FLAG = null;
        //private CPLCControlProperties OW_LINK_DOWN1_JOW_DATA1_LOT_END_FLAG = null;
        //private CPLCControlProperties OW_LINK_DOWN1_JOW_DATA1_OPERATIONID = null;
        //private CPLCControlProperties OW_LINK_DOWN1_JOW_DATA1_PRODUCTID = null;
        //private CPLCControlProperties OW_LINK_DOWN1_JOW_DATA1_CASSETTEID = null;
        //private CPLCControlProperties OW_LINK_DOWN1_JOW_DATA1_RESERVED = null;

        private CPLCControlProperties OW_LINK_DOWN1_TRANS_JOB_DATA1 = null;
        private CPLCControlProperties OW_LINK_DOWN1_TRANS_JOB_DATA2 = null;

        //private CPLCControlProperties OW_LINK_DOWN1_TRANS_JOB_DATA1_IN_UNIT_PATH_NO = null;
        //private CPLCControlProperties OW_LINK_DOWN1_TRANS_JOB_DATA1_IN_SLOT_NO = null;
        //private CPLCControlProperties OW_LINK_DOWN1_TRANS_JOB_DATA2_IN_UNIT_PATH_NO = null;
        //private CPLCControlProperties OW_LINK_DOWN1_TRANS_JOB_DATA2_IN_SLOT_NO = null;
        #endregion

        private CMain _main = null;
        private bool _enable = false;
        private string _controlName = "";
        private CProbeControl _component = null;
        private CIndexerControl _indexer = null;

        private const int T1 = 30000;
        private const int T2 = 3000;
        private const int T3 = 30000;
        private const int T4 = 3000;

        public CLinkSignalType6_WHTM()
        {
        }

        public override int Init()
        {
            _enable = true;

            //INDEX
            #region
            IB_LINK_UP1_UPSTREAM_INLINE = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP1_UPSTREAM_INLINE");
            IB_LINK_UP1_UPSTREAM_TROUBLE = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP1_UPSTREAM_TROUBLE");
            IB_LINK_UP1_HAND_INTERFERENCE = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP1_HAND_INTERFERENCE");
            IB_LINK_UP1_JOB_TRANSFER_SIGNAL = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP1_JOB_TRANSFER_SIGNAL");
            IB_LINK_UP1_SEND_ABLE = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP1_SEND_ABLE");
            IB_LINK_UP1_SEND_START = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP1_SEND_START");
            IB_LINK_UP1_SEND_COMPLETE = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP1_SEND_COMPLETE");
            IB_LINK_UP1_EXCHANGE_POSSIBLE = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP1_EXCHANGE_POSSIBLE");
            IB_LINK_UP1_CONVEYER_STATE = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP1_CONVEYER_STATE");
            IB_LINK_UP1_SHUTTER_STATE = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP1_SHUTTER_STATE");
            IB_LINK_UP1_JOB_TRANSFER_SIGNAL2 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP1_JOB_TRANSFER_SIGNAL2");
            IB_LINK_UP1_DOUBLE_PITCH = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP1_DOUBLE_PITCH");
            IB_LINK_UP1_FOUR_GLASSES = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP1_FOUR_GLASSES");
            IB_LINK_UP1_HAND2_INTERFERENCE = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP1_HAND2_INTERFERENCE");
            IB_LINK_UP1_SEND_READY = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP1_SEND_READY");
            IB_LINK_UP1_HALFGLASSFLAG = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP1_HALFGLASSFLAG");
            IB_LINK_UP1_CHK_AVAILABLE = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP1_CHK_AVAILABLE");
            IB_LINK_UP1_CHK_LIFT_UP_OR_PIN_UP = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP1_CHK_LIFT_UP_OR_PIN_UP");
            IB_LINK_UP1_CHK_LIFT_DOWN_OR_PIN_DOWN = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP1_CHK_LIFT_DOWN_OR_PIN_DOWN");
            IB_LINK_UP1_CHK_STOPPER_UP_OR_DOOR_OPEN = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP1_CHK_STOPPER_UP_OR_DOOR_OPEN");
            IB_LINK_UP1_CHK_STOPPER_DOWN_OR_DOOR_CLOSE = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP1_CHK_STOPPER_DOWN_OR_DOOR_CLOSE");
            IB_LINK_UP1_CHK_MANUAL_OPERATION = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP1_CHK_MANUAL_OPERATION");
            IB_LINK_UP1_CHK_BODY_MOVING = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP1_CHK_BODY_MOVING");
            IB_LINK_UP1_CHK_COMPLETE = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP1_CHK_COMPLETE");
            IB_LINK_UP1_CHK_GLASS_EXIST_ARM1 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP1_CHK_GLASS_EXIST_ARM1");
            IB_LINK_UP1_CHK_GLASS_EXIST_ARM2 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP1_CHK_GLASS_EXIST_ARM2");
            IB_LINK_UP1_CHK_GLASS_EXIST_ARM3 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP1_CHK_GLASS_EXIST_ARM3");
            IB_LINK_UP1_CHK_GLASS_EXIST_ARM4 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP1_CHK_GLASS_EXIST_ARM4");
            IB_LINK_UP1_CHK_RESERVED1 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP1_CHK_RESERVED1");
            IB_LINK_UP1_CHK_RESERVED2 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP1_CHK_RESERVED2");
            IB_LINK_UP1_CHK_RESERVED3 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP1_CHK_RESERVED3");
            IB_LINK_UP1_CHK_RESERVED4 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP1_CHK_RESERVED4");
            IB_LINK_DOWN1_DOWNSTREAM_INLINE = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN1_DOWNSTREAM_INLINE");
            IB_LINK_DOWN1_DOWNSTREAM_TROUBLE = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN1_DOWNSTREAM_TROUBLE");
            IB_LINK_DOWN1_HAND_INTERFERENCE = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN1_HAND_INTERFERENCE");
            IB_LINK_DOWN1_JOB_TRANSFER_SIGNAL = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN1_JOB_TRANSFER_SIGNAL");
            IB_LINK_DOWN1_RECEIVE_ABLE = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN1_RECEIVE_ABLE");
            IB_LINK_DOWN1_RECEIVE_START = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN1_RECEIVE_START");
            IB_LINK_DOWN1_RECEIVE_COMPLETE = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN1_RECEIVE_COMPLETE");
            IB_LINK_DOWN1_EXCHANGE_EXECUTE = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN1_EXCHANGE_EXECUTE");
            IB_LINK_DOWN1_CONVEYER_STATE = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN1_CONVEYER_STATE");
            IB_LINK_DOWN1_SHUTTER_STATE = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN1_SHUTTER_STATE");
            IB_LINK_DOWN1_DOUBLE_PITCH = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN1_DOUBLE_PITCH");
            IB_LINK_DOWN1_FOUR_GLASSES = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN1_FOUR_GLASSES");
            IB_LINK_DOWN1_RESERVED1 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN1_RESERVED1");
            IB_LINK_DOWN1_EXCHANGE_CANCEL_RECEIVE = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN1_EXCHANGE_CANCEL_RECEIVE");
            IB_LINK_DOWN1_RECEIVE_READY = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN1_RECEIVE_READY");
            IB_LINK_DOWN1_RESERVED2 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN1_RESERVED2");
            IB_LINK_DOWN1_CHK_AVAILABLE = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN1_CHK_AVAILABLE");
            IB_LINK_DOWN1_CHK_LIFT_UP_OR_PIN_UP = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN1_CHK_LIFT_UP_OR_PIN_UP");
            IB_LINK_DOWN1_CHK_LIFT_DOWN_OR_PIN_DOWN = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN1_CHK_LIFT_DOWN_OR_PIN_DOWN");
            IB_LINK_DOWN1_CHK_STOPPER_UP_OR_DOOR_OPEN = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN1_CHK_STOPPER_UP_OR_DOOR_OPEN");
            IB_LINK_DOWN1_CHK_STOPPER_DOWN_OR_DOOR_CLOSE = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN1_CHK_STOPPER_DOWN_OR_DOOR_CLOSE");
            IB_LINK_DOWN1_CHK_MANUAL_OPERATION = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN1_CHK_MANUAL_OPERATION");
            IB_LINK_DOWN1_CHK_BODY_MOVING = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN1_CHK_BODY_MOVING");
            IB_LINK_DOWN1_CHK_COMPLETE = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN1_CHK_COMPLETE");
            IB_LINK_DOWN1_CHK_GLASS_EXIST_ARM1 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN1_CHK_GLASS_EXIST_ARM1");
            IB_LINK_DOWN1_CHK_GLASS_EXIST_ARM2 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN1_CHK_GLASS_EXIST_ARM2");
            IB_LINK_DOWN1_CHK_GLASS_EXIST_ARM3 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN1_CHK_GLASS_EXIST_ARM3");
            IB_LINK_DOWN1_CHK_GLASS_EXIST_ARM4 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN1_CHK_GLASS_EXIST_ARM4");
            IB_LINK_DOWN1_CHK_RESERVED1 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN1_CHK_RESERVED1");
            IB_LINK_DOWN1_CHK_RESERVED2 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN1_CHK_RESERVED2");
            IB_LINK_DOWN1_CHK_RESERVED3 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN1_CHK_RESERVED3");
            IB_LINK_DOWN1_CHK_RESERVED4 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN1_CHK_RESERVED4");
            IW_LINK_DOWN1_JOB_DATA1 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IW_LINK_DOWN1_JOB_DATA1");
            IW_LINK_DOWN1_JOB_DATA2 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IW_LINK_DOWN1_JOB_DATA2");
            //IB_LINK_DOWN1_JOB_DATA1_CASSETTE_INDEX = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN1_JOB_DATA1_CASSETTE_INDEX");
            //IB_LINK_DOWN1_JOB_DATA1_GLASS_INDEX = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN1_JOB_DATA1_GLASS_INDEX");
            //IB_LINK_DOWN1_JOB_DATA1_PRODUCT_CODE = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN1_JOB_DATA1_PRODUCT_CODE");
            //IB_LINK_DOWN1_JOB_DATA1_GLASS_THICKNESS = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN1_JOB_DATA1_GLASS_THICKNESS");
            //IB_LINK_DOWN1_JOB_DATA1_LOT_ID = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN1_JOB_DATA1_LOT_ID");
            //IB_LINK_DOWN1_JOB_DATA1_GLASS_ID = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN1_JOB_DATA1_GLASS_ID");
            //IB_LINK_DOWN1_JOB_DATA1_PPID = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN1_JOB_DATA1_PPID");
            //IB_LINK_DOWN1_JOB_DATA1_GLASSTYPE = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN1_JOB_DATA1_GLASSTYPE");
            //IB_LINK_DOWN1_JOB_DATA1_JOB_JUDGE = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN1_JOB_DATA1_JOB_JUDGE");
            //IB_LINK_DOWN1_JOB_DATA1_JOB_GRADE = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN1_JOB_DATA1_JOB_GRADE");
            //IB_LINK_DOWN1_JOB_DATA1_JOB_STATE = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN1_JOB_DATA1_JOB_STATE");
            //IB_LINK_DOWN1_JOB_DATA1_TRACKING_DATA = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN1_JOB_DATA1_TRACKING_DATA");
            //IB_LINK_DOWN1_JOB_DATA1_LOC_UNIT_PATH_NO = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN1_JOB_DATA1_LOC_UNIT_PATH_NO");
            //IB_LINK_DOWN1_JOB_DATA1_LOC_SLOT_NO = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN1_JOB_DATA1_LOC_SLOT_NO");
            //IB_LINK_DOWN1_JOB_DATA1_CYCLETIME = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN1_JOB_DATA1_CYCLETIME");
            //IB_LINK_DOWN1_JOB_DATA1_TACTTIME = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN1_JOB_DATA1_TACTTIME");
            //IB_LINK_DOWN1_JOB_DATA1_REASON_CODE = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN1_JOB_DATA1_REASON_CODE");
            //IB_LINK_DOWN1_JOB_DATA1_SAMPLING_FLAG = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN1_JOB_DATA1_SAMPLING_FLAG");
            //IB_LINK_DOWN1_JOB_DATA1_LOT_END_FLAG = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN1_JOB_DATA1_LOT_END_FLAG");
            //IB_LINK_DOWN1_JOB_DATA1_OPERATIONID = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN1_JOB_DATA1_OPERATIONID");
            //IB_LINK_DOWN1_JOB_DATA1_PRODUCTID = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN1_JOB_DATA1_PRODUCTID");
            //IB_LINK_DOWN1_JOB_DATA1_CASSETTEID = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN1_JOB_DATA1_CASSETTEID");
            //IB_LINK_DOWN1_JOB_DATA1_RESERVED = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_DOWN1_JOB_DATA1_RESERVED");

            IW_LINK_DOWN1_TRANS_JOB_DATA1 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IW_LINK_DOWN1_TRANS_JOB_DATA1");
            IW_LINK_DOWN1_TRANS_JOB_DATA2 = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IW_LINK_DOWN1_TRANS_JOB_DATA2");

            //IW_LINK_DOWN1_TRANS_JOB_DATA1_IN_UNIT_PATH_NO = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IW_LINK_DOWN1_TRANS_JOB_DATA1_IN_UNIT_PATH_NO");
            //IW_LINK_DOWN1_TRANS_JOB_DATA1_IN_SLOT_NO = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IW_LINK_DOWN1_TRANS_JOB_DATA1_IN_SLOT_NO");
            //IW_LINK_DOWN1_TRANS_JOB_DATA2_IN_UNIT_PATH_NO = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IW_LINK_DOWN1_TRANS_JOB_DATA2_IN_UNIT_PATH_NO");
            //IW_LINK_DOWN1_TRANS_JOB_DATA2_IN_SLOT_NO = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IW_LINK_DOWN1_TRANS_JOB_DATA2_IN_SLOT_NO");
            #endregion

            //PROBE CIM
            #region
            OB_LINK_UP1_UPSTREAM_INLINE = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_UPSTREAM_INLINE");
            OB_LINK_UP1_UPSTREAM_TROUBLE = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_UPSTREAM_TROUBLE");
            OB_LINK_UP1_HAND_INTERFERENCE = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_HAND_INTERFERENCE");
            OB_LINK_UP1_JOB_TRANSFER_SIGNAL = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_JOB_TRANSFER_SIGNAL");
            OB_LINK_UP1_SEND_ABLE = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_SEND_ABLE");
            OB_LINK_UP1_SEND_START = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_SEND_START");
            OB_LINK_UP1_SEND_COMPLETE = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_SEND_COMPLETE");
            OB_LINK_UP1_EXCHANGE_POSSIBLE = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_EXCHANGE_POSSIBLE");
            OB_LINK_UP1_CONVEYER_STATE = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_CONVEYER_STATE");
            OB_LINK_UP1_SHUTTER_STATE = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_SHUTTER_STATE");
            OB_LINK_UP1_JOB_TRANSFER_SIGNAL2 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_JOB_TRANSFER_SIGNAL2");
            OB_LINK_UP1_DOUBLE_PITCH = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_DOUBLE_PITCH");
            OB_LINK_UP1_FOUR_GLASSES = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_FOUR_GLASSES");
            OB_LINK_UP1_HAND2_INTERFERENCE = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_HAND2_INTERFERENCE");
            OB_LINK_UP1_SEND_READY = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_SEND_READY");
            OB_LINK_UP1_HALFGLASSFLAG = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_HALFGLASSFLAG");
            OB_LINK_UP1_CHK_AVAILABLE = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_CHK_AVAILABLE");
            OB_LINK_UP1_CHK_LIFT_UP_OR_PIN_UP = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_CHK_LIFT_UP_OR_PIN_UP");
            OB_LINK_UP1_CHK_LIFT_DOWN_OR_PIN_DOWN = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_CHK_LIFT_DOWN_OR_PIN_DOWN");
            OB_LINK_UP1_CHK_STOPPER_UP_OR_DOOR_OPEN = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_CHK_STOPPER_UP_OR_DOOR_OPEN");
            OB_LINK_UP1_CHK_STOPPER_DOWN_OR_DOOR_CLOSE = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_CHK_STOPPER_DOWN_OR_DOOR_CLOSE");
            OB_LINK_UP1_CHK_MANUAL_OPERATION = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_CHK_MANUAL_OPERATION");
            OB_LINK_UP1_CHK_BODY_MOVING = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_CHK_BODY_MOVING");
            OB_LINK_UP1_CHK_COMPLETE = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_CHK_COMPLETE");
            OB_LINK_UP1_CHK_GLASS_EXIST_ARM1 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_CHK_GLASS_EXIST_ARM1");
            OB_LINK_UP1_CHK_GLASS_EXIST_ARM2 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_CHK_GLASS_EXIST_ARM2");
            OB_LINK_UP1_CHK_GLASS_EXIST_ARM3 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_CHK_GLASS_EXIST_ARM3");
            OB_LINK_UP1_CHK_GLASS_EXIST_ARM4 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_CHK_GLASS_EXIST_ARM4");
            OB_LINK_UP1_CHK_RESERVED1 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_CHK_RESERVED1");
            OB_LINK_UP1_CHK_RESERVED2 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_CHK_RESERVED2");
            OB_LINK_UP1_CHK_RESERVED3 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_CHK_RESERVED3");
            OB_LINK_UP1_CHK_RESERVED4 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_UP1_CHK_RESERVED4");
            OB_LINK_DOWN1_DOWNSTREAM_INLINE = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_DOWNSTREAM_INLINE");
            OB_LINK_DOWN1_DOWNSTREAM_TROUBLE = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_DOWNSTREAM_TROUBLE");
            OB_LINK_DOWN1_HAND_INTERFERENCE = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_HAND_INTERFERENCE");
            OB_LINK_DOWN1_JOB_TRANSFER_SIGNAL = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_JOB_TRANSFER_SIGNAL");
            OB_LINK_DOWN1_RECEIVE_ABLE = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_RECEIVE_ABLE");
            OB_LINK_DOWN1_RECEIVE_START = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_RECEIVE_START");
            OB_LINK_DOWN1_RECEIVE_COMPLETE = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_RECEIVE_COMPLETE");
            OB_LINK_DOWN1_EXCHANGE_EXECUTE = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_EXCHANGE_EXECUTE");
            OB_LINK_DOWN1_CONVEYER_STATE = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_CONVEYER_STATE");
            OB_LINK_DOWN1_SHUTTER_STATE = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_SHUTTER_STATE");
            OB_LINK_DOWN1_DOUBLE_PITCH = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_DOUBLE_PITCH");
            OB_LINK_DOWN1_FOUR_GLASSES = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_FOUR_GLASSES");
            OB_LINK_DOWN1_RESERVED1 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_RESERVED1");
            OB_LINK_DOWN1_EXCHANGE_CANCEL_RECEIVE = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_EXCHANGE_CANCEL_RECEIVE");
            OB_LINK_DOWN1_RECEIVE_READY = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_RECEIVE_READY");
            OB_LINK_DOWN1_RESERVED2 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_RESERVED2");
            OB_LINK_DOWN1_CHK_AVAILABLE = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_CHK_AVAILABLE");
            OB_LINK_DOWN1_CHK_LIFT_UP_OR_PIN_UP = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_CHK_LIFT_UP_OR_PIN_UP");
            OB_LINK_DOWN1_CHK_LIFT_DOWN_OR_PIN_DOWN = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_CHK_LIFT_DOWN_OR_PIN_DOWN");
            OB_LINK_DOWN1_CHK_STOPPER_UP_OR_DOOR_OPEN = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_CHK_STOPPER_UP_OR_DOOR_OPEN");
            OB_LINK_DOWN1_CHK_STOPPER_DOWN_OR_DOOR_CLOSE = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_CHK_STOPPER_DOWN_OR_DOOR_CLOSE");
            OB_LINK_DOWN1_CHK_MANUAL_OPERATION = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_CHK_MANUAL_OPERATION");
            OB_LINK_DOWN1_CHK_BODY_MOVING = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_CHK_BODY_MOVING");
            OB_LINK_DOWN1_CHK_COMPLETE = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_CHK_COMPLETE");
            OB_LINK_DOWN1_CHK_GLASS_EXIST_ARM1 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_CHK_GLASS_EXIST_ARM1");
            OB_LINK_DOWN1_CHK_GLASS_EXIST_ARM2 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_CHK_GLASS_EXIST_ARM2");
            OB_LINK_DOWN1_CHK_GLASS_EXIST_ARM3 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_CHK_GLASS_EXIST_ARM3");
            OB_LINK_DOWN1_CHK_GLASS_EXIST_ARM4 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_CHK_GLASS_EXIST_ARM4");
            OB_LINK_DOWN1_CHK_RESERVED1 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_CHK_RESERVED1");
            OB_LINK_DOWN1_CHK_RESERVED2 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_CHK_RESERVED2");
            OB_LINK_DOWN1_CHK_RESERVED3 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_CHK_RESERVED3");
            OB_LINK_DOWN1_CHK_RESERVED4 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_CHK_RESERVED4");
            OW_LINK_DOWN1_JOB_DATA1 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OW_LINK_DOWN1_JOB_DATA1");
            OW_LINK_DOWN1_JOB_DATA2 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OW_LINK_DOWN1_JOB_DATA2");
            //OB_LINK_DOWN1_JOB_DATA1_CASSETTE_INDEX = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_JOB_DATA1_CASSETTE_INDEX");
            //OB_LINK_DOWN1_JOB_DATA1_GLASS_INDEX = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_JOB_DATA1_GLASS_INDEX");
            //OB_LINK_DOWN1_JOB_DATA1_PRODUCT_CODE = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_JOB_DATA1_PRODUCT_CODE");
            //OB_LINK_DOWN1_JOB_DATA1_GLASS_THICKNESS = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_JOB_DATA1_GLASS_THICKNESS");
            //OB_LINK_DOWN1_JOB_DATA1_LOT_ID = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_JOB_DATA1_LOT_ID");
            //OB_LINK_DOWN1_JOB_DATA1_GLASS_ID = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_JOB_DATA1_GLASS_ID");
            //OB_LINK_DOWN1_JOB_DATA1_PPID = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_JOB_DATA1_PPID");
            //OB_LINK_DOWN1_JOB_DATA1_GLASSTYPE = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_JOB_DATA1_GLASSTYPE");
            //OB_LINK_DOWN1_JOB_DATA1_JOB_JUDGE = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_JOB_DATA1_JOB_JUDGE");
            //OB_LINK_DOWN1_JOB_DATA1_JOB_GRADE = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_JOB_DATA1_JOB_GRADE");
            //OB_LINK_DOWN1_JOB_DATA1_JOB_STATE = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_JOB_DATA1_JOB_STATE");
            //OB_LINK_DOWN1_JOB_DATA1_TRACKING_DATA = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_JOB_DATA1_TRACKING_DATA");
            //OB_LINK_DOWN1_JOB_DATA1_LOC_UNIT_PATH_NO = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_JOB_DATA1_LOC_UNIT_PATH_NO");
            //OB_LINK_DOWN1_JOB_DATA1_LOC_SLOT_NO = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_JOB_DATA1_LOC_SLOT_NO");
            //OB_LINK_DOWN1_JOB_DATA1_CYCLETIME = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_JOB_DATA1_CYCLETIME");
            //OB_LINK_DOWN1_JOB_DATA1_TACTTIME = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_JOB_DATA1_TACTTIME");
            //OB_LINK_DOWN1_JOB_DATA1_REASON_CODE = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_JOB_DATA1_REASON_CODE");
            //OB_LINK_DOWN1_JOB_DATA1_SAMPLING_FLAG = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_JOB_DATA1_SAMPLING_FLAG");
            //OB_LINK_DOWN1_JOB_DATA1_LOT_END_FLAG = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_JOB_DATA1_LOT_END_FLAG");
            //OB_LINK_DOWN1_JOB_DATA1_OPERATIONID = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_JOB_DATA1_OPERATIONID");
            //OB_LINK_DOWN1_JOB_DATA1_PRODUCTID = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_JOB_DATA1_PRODUCTID");
            //OB_LINK_DOWN1_JOB_DATA1_CASSETTEID = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_JOB_DATA1_CASSETTEID");
            //OB_LINK_DOWN1_JOB_DATA1_RESERVED = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OB_LINK_DOWN1_JOB_DATA1_RESERVED");

            OW_LINK_DOWN1_TRANS_JOB_DATA1 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OW_LINK_DOWN1_TRANS_JOB_DATA1");
            OW_LINK_DOWN1_TRANS_JOB_DATA2 = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OW_LINK_DOWN1_TRANS_JOB_DATA2");

            //OW_LINK_DOWN1_TRANS_JOB_DATA1_IN_UNIT_PATH_NO = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OW_LINK_DOWN1_TRANS_JOB_DATA1_IN_UNIT_PATH_NO");
            //OW_LINK_DOWN1_TRANS_JOB_DATA1_IN_SLOT_NO = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OW_LINK_DOWN1_TRANS_JOB_DATA1_IN_SLOT_NO");
            //OW_LINK_DOWN1_TRANS_JOB_DATA2_IN_UNIT_PATH_NO = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OW_LINK_DOWN1_TRANS_JOB_DATA2_IN_UNIT_PATH_NO");
            //OW_LINK_DOWN1_TRANS_JOB_DATA2_IN_SLOT_NO = _main.PLCCONTEROLS.GetProperty(_component.ControlName, "OW_LINK_DOWN1_TRANS_JOB_DATA2_IN_SLOT_NO");

            #endregion

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
            get { return "Link Signal Type 5 대응"; }
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
            get { return "LINK_SIGNAL_TYPE6"; }
        }

        public override string Version
        {
            get { return "ver 1.0"; }
        }
        public override string SIteName
        {
            get { return "WHTM"; }
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
            SHUTTER_STATE,
            WAIT_START,
            START,
            MOVING,
            WAIT_TROUBLE1_CLEAR,
            WAIT_TROUBLE2_CLEAR,
            TROUBLE1_COMPLETE,
            WAIT_COMPLETE,
            COMPLETE,
            REPORT,
            END,
            CANCEL,
            T1,
            T2,
            T3,
            T4,
            CANCEL_BY_IDX1, //20161214
            CANCEL_BY_IDX2, //20161214
            CANCEL_BY_EQP1, //20161214
            CANCEL_BY_EQP2, //20161214
            CANCEL_BY_EQP3, //20161214
            CANCEL_BY_EQP4, //20161214
            ABORT_BY_IDX1, //20161214
            ABORT_BY_IDX2, //20161214
            ABORT_BY_EQP1, //20161214
            ABORT_BY_EQP2, //20161214
            ABORT_BY_EQP3, //20161214
            ABORT_BY_EQP4, //20161214
        }
        private enumStep _previousStep = enumStep.NONE;
        private enumStep _step = enumStep.NONE;

        private void ChangeStep(enumStep newState)
        {
            if (_step != newState)
                Log(string.Format("{0}\t{1}", newState.ToString(), ""));
            _previousStep = _step;
            _step = newState;
        }

        private CGlassDataPropertiesWHTM glassData1 = null;
        private CGlassDataPropertiesWHTM glassData2 = null;
        protected override int InnerExecute()
        {
            try
            {
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

                int ret = 0;
                Log(string.Format("{0}", "LOOP START"));
                while (true)
                {
                    bool upstreamOn = _main.MelsecNetBitRead(OB_LINK_UP1_UPSTREAM_INLINE, 1);
                    bool stageExchangePossible = _main.MelsecNetBitRead(OB_LINK_UP1_EXCHANGE_POSSIBLE, 1);// OB_LINK_DOWN1_EXCHANGE_POSSIBLE, 1);
                    bool downstreamOn = bool.Parse(IB_LINK_DOWN1_DOWNSTREAM_INLINE.Value);// _main.MelsecNetBitRead(IB_LINK_DOWN1_DOWNSTREAM_INLINE ,1);

                    //bool sendAble = false;

                    switch (_step)
                    {
                        case enumStep.NONE:
                            _component.StartUnLoadSEQ = false;

                            if (_component.AbnormalSEQ)
                            {
                                if (bool.Parse(IB_LINK_DOWN1_HAND_INTERFERENCE.Value))
                                {
                                    _component.AbnormalSEQ = false;

                                    if (_component.WaitUnloadRequest)
                                    {
                                        _component.WaitUnloadRequest = false;
                                        _component.UnloadRequest = true;
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }

                            if (downstreamOn && upstreamOn && !_main.MelsecNetBitRead(IB_LINK_DOWN1_EXCHANGE_EXECUTE, 1) && _component.UnloadRequest)
                            {
                                if (bool.Parse(IB_LINK_DOWN1_RECEIVE_ABLE.Value) || bool.Parse(IB_LINK_DOWN1_RECEIVE_START.Value) || bool.Parse(IB_LINK_DOWN1_RECEIVE_COMPLETE.Value))
                                {
                                    break;
                                }
                                else if (bool.Parse(IB_LINK_UP1_SEND_ABLE.Value) || bool.Parse(IB_LINK_UP1_SEND_START.Value) || bool.Parse(IB_LINK_UP1_SEND_COMPLETE.Value))
                                {
                                    break;
                                }

                                AMaterialData materialData1 = _main.GetReceivedGlassDataByLoc(_component.ControlName, 0);
                                AMaterialData materialData2 = _main.GetReceivedGlassDataByLoc(_component.ControlName, 1);
                                if (materialData1 != null || materialData2 != null)//A,B or whole 이므로...하나라도 있으면 처리
                                {
                                    if (materialData1 != null)
                                    {
                                        glassData1 = materialData1 as CGlassDataPropertiesWHTM;

                                        if (glassData1.GlassID != "")
                                        {
                                            glassData1.TrackingData = (ulong)_component.Glass_Tracking_DataA;

                                            //Fix Data
                                            glassData1.UnitPathNo = 301;
                                            glassData1.SlotNo = 0;

                                            _main.AddSentOutGlassData(_component.ControlName, glassData1, 0);
                                            List<int> value2 = new List<int>() { 301, 0 };
                                            _main.MelsecNetMultiWordWrite(OW_LINK_DOWN1_JOB_DATA1, CGlassDataPropertiesWHTM.ConvertPLCData(glassData1));
                                            _main.MelsecNetMultiWordWrite(OW_LINK_DOWN1_TRANS_JOB_DATA1, value2);
                                        }
                                        else
                                        {
                                            glassData1 = null;
                                            List<int> value2 = new List<int>() { 0, 0 };
                                            _main.MelsecNetMultiWordWrite(OW_LINK_DOWN1_JOB_DATA1, CGlassDataPropertiesWHTM.ConvertPLCData(glassData1));
                                            _main.MelsecNetMultiWordWrite(OW_LINK_DOWN1_TRANS_JOB_DATA1, value2);
                                            _main.MelsecNetBitOnOff(OB_LINK_UP1_HALFGLASSFLAG, true);
                                        }
                                    }
                                    else
                                    {
                                        glassData1 = null;
                                        List<int> value2 = new List<int>() { 0, 0 };
                                        _main.MelsecNetMultiWordWrite(OW_LINK_DOWN1_JOB_DATA1, CGlassDataPropertiesWHTM.ConvertPLCData(glassData1));
                                        _main.MelsecNetMultiWordWrite(OW_LINK_DOWN1_TRANS_JOB_DATA1, value2);
                                        _main.MelsecNetBitOnOff(OB_LINK_UP1_HALFGLASSFLAG, true);
                                    }

                                    if (materialData2 != null)
                                    {
                                        glassData2 = materialData2 as CGlassDataPropertiesWHTM;

                                        if (glassData2.GlassID != "")
                                        {
                                            glassData2.TrackingData = (ulong)_component.Glass_Tracking_DataB;
                                            //Fix Data
                                            glassData2.UnitPathNo = 301;
                                            glassData2.SlotNo = 0;

                                            _main.AddSentOutGlassData(_component.ControlName, glassData2, 1);
                                            List<int> value4 = new List<int>() { 301, 0 };
                                            _main.MelsecNetMultiWordWrite(OW_LINK_DOWN1_JOB_DATA2, CGlassDataPropertiesWHTM.ConvertPLCData(glassData2));
                                            _main.MelsecNetMultiWordWrite(OW_LINK_DOWN1_TRANS_JOB_DATA2, value4);
                                        }
                                        else
                                        {
                                            glassData2 = null;
                                            List<int> value4 = new List<int>() { 0, 0 };
                                            _main.MelsecNetMultiWordWrite(OW_LINK_DOWN1_JOB_DATA2, CGlassDataPropertiesWHTM.ConvertPLCData(glassData2));
                                            _main.MelsecNetMultiWordWrite(OW_LINK_DOWN1_TRANS_JOB_DATA2, value4);
                                        }
                                    }
                                    else
                                    {
                                        glassData2 = null;
                                        List<int> value4 = new List<int>() { 0, 0 };
                                        _main.MelsecNetMultiWordWrite(OW_LINK_DOWN1_JOB_DATA2, CGlassDataPropertiesWHTM.ConvertPLCData(glassData2));
                                        _main.MelsecNetMultiWordWrite(OW_LINK_DOWN1_TRANS_JOB_DATA2, value4);
                                    }

                                    _main.MelsecNetBitOnOff(OB_LINK_UP1_SEND_ABLE, true);
                                    this.ChangeStep(enumStep.WAIT);
                                }
                                else
                                {
                                    _main.SetAlarm(_component, DateTime.Now, "6000", "SENT OUT DATA ERROR");
                                    AbnormalStop();
                                }
                            }
                            break;
                        case enumStep.WAIT:
                            if (bool.Parse(IB_LINK_DOWN1_RECEIVE_ABLE.Value))
                            {
                                Thread.Sleep(100);
                                if (stageExchangePossible && _main.MelsecNetBitRead(IB_LINK_DOWN1_EXCHANGE_EXECUTE, 1))
                                {
                                    this.ChangeStep(enumStep.NONE);
                                }
                                else
                                {
                                    _component.StartUnLoadSEQ = true;

                                    //20161123
                                    List<string> dataList = new List<string>();

                                    //GLASSTYPE,CST_INDEX,GLASS_INDEX,GLASS_ID,LOT_ID,PPID,RECIPEID,CST_INDEX,GLASS_INDEX,GLASS_ID,LOT_ID,PPID,RECIPEID
                                    _main.SendData(new List<string> { "GLASS_DATA_SEND", "X", "".PadLeft(19, ',')}); //PORTNO,SEQNO,GLASSTYPE,SLOTNO,GLASS_ID,LOT_ID,PPID,RECIPEID,PORTNO,SEQNO,GLASSTYPE,SLOTNO,GLASS_ID,LOT_ID,PPID,RECIPEID

                                    _main.SendData(new List<string>() { "SHUTTER_STATUS_REQ" });

                                    _component.Glass_Tracking_DataA = 0;
                                    _component.Glass_Tracking_DataB = 0;
                                    this.ChangeStep(enumStep.SHUTTER_STATE);
                                }
                            }
                            else if (bool.Parse(OB_LINK_UP1_UPSTREAM_TROUBLE.Value) && !_component.UnloadRequest)
                            {
                                _main.MelsecNetBitOnOff(OB_LINK_UP1_SEND_ABLE, false);
                                _main.MelsecNetBitOnOff(OB_LINK_UP1_SEND_START, false);

                                _main.MelsecNetBitOnOff(OB_LINK_UP1_HALFGLASSFLAG, false);

                                _component.UnloadRequest = false;
                                _component.UnloadEnable = false;

                                this.ChangeStep(enumStep.NONE);
                            }
                            break;
                        //Data Check가 없음.

                        case enumStep.SHUTTER_STATE:
                            if (_component.EQP_Shutter_Open)
                            {
                                if (bool.Parse(OB_LINK_DOWN1_SHUTTER_STATE.Value))
                                {
                                    this.ChangeStep(enumStep.WAIT_START);
                                }
                            }
                            break;

                        case enumStep.WAIT_START:
                            if (_component.UnloadEnable)
                            {
                                //_component.UnloadEnable = false;
                                _main.MelsecNetBitOnOff(OB_LINK_UP1_SEND_START, true);
                                this.ChangeStep(enumStep.START);
                            }
                            else if (_component.InitialiazeRequest)
                            {
                                _component.InitialiazeRequest = false;

                                _component.UnloadRequest = false;
                                _main.MelsecNetBitOnOff(OB_LINK_UP1_SEND_ABLE, false);

                                _main.MelsecNetBitOnOff(OB_LINK_UP1_HALFGLASSFLAG, false);
                                this.ChangeStep(enumStep.NONE);
                            }

                            break;
                        case enumStep.START:
                            if (bool.Parse(IB_LINK_DOWN1_RECEIVE_START.Value))//_main.MelsecNetBitRead(IB_LINK_DOWN1_RECEIVE_START, 1))
                            {
                                this.ChangeStep(enumStep.MOVING);
                            }
                            else if (bool.Parse(OB_LINK_UP1_UPSTREAM_TROUBLE.Value))
                            {
                                _main.MelsecNetBitOnOff(OB_LINK_UP1_SEND_ABLE, false);
                                _main.MelsecNetBitOnOff(OB_LINK_UP1_SEND_START, false);
                                _main.MelsecNetBitOnOff(OB_LINK_UP1_HALFGLASSFLAG, false);

                                _component.UnloadRequest = false;
                                _component.UnloadEnable = false;

                                _component.AbnormalSEQ = true;
                                this.ChangeStep(enumStep.NONE);
                            }
                            else if (bool.Parse(IB_LINK_DOWN1_DOWNSTREAM_TROUBLE.Value))
                            {
                                _main.MelsecNetBitOnOff(OB_LINK_UP1_SEND_ABLE, false);
                                _main.MelsecNetBitOnOff(OB_LINK_UP1_SEND_START, false);
                                _main.MelsecNetBitOnOff(OB_LINK_UP1_HALFGLASSFLAG, false);

                                _component.UnloadEnable = false;

                                _component.AbnormalSEQ = true;
                                this.ChangeStep(enumStep.NONE);
                            }
                            break;

                        case enumStep.MOVING:
                            if (bool.Parse(IB_LINK_DOWN1_JOB_TRANSFER_SIGNAL.Value))//_main.MelsecNetBitRead(IB_LINK_DOWN1_JOB_TRANSFER_SIGNAL, 1))
                            {
                                Dictionary<string, string> values = new Dictionary<string, string>();

                                if (glassData1 != null && (glassData1.GlassPosition == 1 || glassData1.GlassPosition == 3))
                                {
                                    values.Clear();
                                    values.Add("GLS_INDEX", "0");
                                    values.Add("TRANS_STATE", "4");
                                    _component.GetProgram("TRACKING_JOB_REPORT").ExecuteManual(values);
                                }
                                Thread.Sleep(300);
                                if (glassData2 != null && glassData2.GlassPosition == 2)
                                {
                                    values.Clear();
                                    values.Add("GLS_INDEX", "1");
                                    values.Add("TRANS_STATE", "4");
                                    _component.GetProgram("TRACKING_JOB_REPORT").ExecuteManual(values);
                                }

                                Thread.Sleep(300);

                                if (glassData1 != null && (glassData1.GlassPosition == 1 || glassData1.GlassPosition == 3))
                                {
                                    values.Clear();
                                    values.Add("GLS_INDEX", "0");
                                    values.Add("FILE_PATH", _component.glass_data_value_file_A);
                                    _component.GetProgram("PROCESS_DATA_REPORT").ExecuteManual(values);
                                }
                                Thread.Sleep(300);
                                if (glassData2 != null && glassData2.GlassPosition == 2)
                                {
                                    values.Clear();
                                    values.Add("GLS_INDEX", "1");
                                    values.Add("FILE_PATH", _component.glass_data_value_file_B);
                                    _component.GetProgram("PROCESS_DATA_REPORT").ExecuteManual(values);
                                }

                                //_component.GetProgram("PROCESS_DATA_REPORT").Execute();
                                Thread.Sleep(300);

                                if (glassData1 != null && (glassData1.GlassPosition == 1 || glassData1.GlassPosition == 3))
                                {
                                    values.Clear();
                                    values.Add("GLS_INDEX", "0");
                                    _component.GetProgram("SENT_OUT_JOB_REPORT").ExecuteManual(values);
                                }
                                Thread.Sleep(300);
                                if (glassData2 != null && glassData2.GlassPosition == 2)
                                {
                                    values.Clear();
                                    values.Add("GLS_INDEX", "1");
                                    _component.GetProgram("SENT_OUT_JOB_REPORT").ExecuteManual(values);
                                }

                                _main.SendData(new List<string> { "UNLOAD_HAND_UP_COMPLETION" });
                                this.ChangeStep(enumStep.WAIT_COMPLETE);
                            }
                            else if (bool.Parse(OB_LINK_UP1_UPSTREAM_TROUBLE.Value))
                            {
                                _main.MelsecNetBitOnOff(OB_LINK_UP1_SEND_ABLE, false);
                                _main.MelsecNetBitOnOff(OB_LINK_UP1_SEND_START, false);
                                _main.MelsecNetBitOnOff(OB_LINK_UP1_HALFGLASSFLAG, false);

                                _component.UnloadRequest = false;
                                _component.UnloadEnable = false;

                                _component.AbnormalSEQ = true;
                                this.ChangeStep(enumStep.NONE);
                            }
                            else if (bool.Parse(IB_LINK_DOWN1_DOWNSTREAM_TROUBLE.Value))
                            {
                                _main.MelsecNetBitOnOff(OB_LINK_UP1_SEND_ABLE, false);
                                _main.MelsecNetBitOnOff(OB_LINK_UP1_SEND_START, false);
                                _main.MelsecNetBitOnOff(OB_LINK_UP1_HALFGLASSFLAG, false);

                                _component.UnloadEnable = false;

                                _component.AbnormalSEQ = true;
                                this.ChangeStep(enumStep.NONE);
                            }
                            break;

                        case enumStep.WAIT_TROUBLE2_CLEAR:
                            if (bool.Parse(IB_LINK_DOWN1_JOB_TRANSFER_SIGNAL.Value))
                            {
                                this.AbnormalStop();
                            }
                            else if (!bool.Parse(OB_LINK_UP1_UPSTREAM_TROUBLE.Value) && !bool.Parse(IB_LINK_DOWN1_DOWNSTREAM_TROUBLE.Value))//해결
                            {
                                //if (bool.Parse(IB_LINK_DOWN1_HAND_INTERFERENCE.Value))
                                //                this.ChangeStep(enumStep.NONE);

                                this.ChangeStep(enumStep.TROUBLE1_COMPLETE);
                            }
                            break;

                        case enumStep.WAIT_COMPLETE:
                        case enumStep.TROUBLE1_COMPLETE:
                            if (bool.Parse(IB_LINK_DOWN1_RECEIVE_COMPLETE.Value))// _main.MelsecNetBitRead(IB_LINK_DOWN1_RECEIVE_COMPLETE, 1))
                            {
                                _component.UnloadRequest = false;
                                _main.MelsecNetBitOnOff(OB_LINK_UP1_SEND_COMPLETE, true);
                                this.ChangeStep(enumStep.COMPLETE);
                                _main.SendData(new List<string> { "UNLOAD_COMPLETE" });
                            }
                            else if (bool.Parse(OB_LINK_UP1_UPSTREAM_TROUBLE.Value) || bool.Parse(IB_LINK_DOWN1_DOWNSTREAM_TROUBLE.Value))
                            {
                                //5.16. Robot(Upstream) Trouble: After Robot Putting Glass to Stage 
                                _main.MelsecNetBitOnOff(OB_LINK_UP1_SEND_ABLE, false);
                                _main.MelsecNetBitOnOff(OB_LINK_UP1_SEND_START, false);

                                _component.AbnormalSEQ = true;
                                this.ChangeStep(enumStep.WAIT_TROUBLE1_CLEAR);
                            }
                            break;

                        case enumStep.WAIT_TROUBLE1_CLEAR:
                            if (!bool.Parse(IB_LINK_DOWN1_JOB_TRANSFER_SIGNAL.Value))
                            {
                                this.AbnormalStop();
                            }
                            else if (!bool.Parse(OB_LINK_UP1_UPSTREAM_TROUBLE.Value) && !bool.Parse(IB_LINK_DOWN1_DOWNSTREAM_TROUBLE.Value))//해결
                            {
                                this.ChangeStep(enumStep.TROUBLE1_COMPLETE);
                            }
                            break;
                        
                        case enumStep.COMPLETE:

                            if (bool.Parse(IB_LINK_DOWN1_RECEIVE_ABLE.Value) == false)//_main.MelsecNetBitRead(IB_LINK_DOWN1_RECEIVE_ABLE, 1) == false)
                                if (bool.Parse(IB_LINK_DOWN1_RECEIVE_START.Value) == false)//_main.MelsecNetBitRead(IB_LINK_DOWN1_RECEIVE_START, 1) == false)
                                    if (bool.Parse(IB_LINK_DOWN1_RECEIVE_COMPLETE.Value) == false)//_main.MelsecNetBitRead(IB_LINK_DOWN1_RECEIVE_COMPLETE, 1) == false)
                                    {
                                        _main.MelsecNetBitOnOff(OB_LINK_UP1_SEND_ABLE, false);
                                        _main.MelsecNetBitOnOff(OB_LINK_UP1_SEND_START, false);
                                        _main.MelsecNetBitOnOff(OB_LINK_UP1_SEND_COMPLETE, false);
                                        _main.MelsecNetBitOnOff(OB_LINK_UP1_HALFGLASSFLAG, false);

                                        _component.UnloadRequest = false;
                                        _component.UnloadEnable = false;

                                        this.ChangeStep(enumStep.END);
                                    }

                            break;

                        case enumStep.END:
                            CSubject subject = CUIManager.Inst.GetData("ucGlassData");
                            subject.SetValue("GlassCount", 2);
                            subject.SetValue("Data", CGlassDataPropertiesWHTM.GetClearData());
                            subject.SetValue("Data2", CGlassDataPropertiesWHTM.GetClearData());
                            subject.Notify();

                            this.ChangeStep(enumStep.NONE);
                            break;
                        case enumStep.T1:
                            _main.SetAlarm(_component, DateTime.Now, "991", "");
                            _step = _previousStep;
                            break;
                        case enumStep.T2:
                            _main.SetAlarm(_component, DateTime.Now, "992", "");
                            _step = _previousStep;
                            break;
                        case enumStep.T3:
                            _main.SetAlarm(_component, DateTime.Now, "993", "");
                            _step = _previousStep;
                            break;
                        case enumStep.T4:
                            _main.SetAlarm(_component, DateTime.Now, "994", "");
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
                            this.ChangeStep(enumStep.T1);
                        }
                    }

                    if (t2Start)
                    {
                        if (t2Count++ < T2 * 10) //100*10 = 1초,
                        {
                            t2Timeout = true;
                            t2Start = false;
                            t2Count = 0;
                            this.ChangeStep(enumStep.T2);
                        }
                    }

                    if (t3Start)
                    {
                        if (t3Count++ < T3 * 10) //100*10 = 1초,
                        {
                            t3Timeout = true;
                            t3Start = false;
                            t3Count = 0;
                            this.ChangeStep(enumStep.T3);
                        }
                    }

                    if (t4Start)
                    {
                        if (t4Count++ < T4 * 10) //100*10 = 1초,
                        {
                            t4Timeout = true;
                            t4Start = false;
                            t4Count = 0;
                            this.ChangeStep(enumStep.T4);
                        }
                    }
                    Thread.Sleep(100);
                }
                Log(string.Format("{0}", "LOOP END"));
                return 0;
            }
            catch (Exception ex)
            {
                CLogManager.Instance.LogError("InnerExecute EXECUTE ERROR", ex);
                return -1;
            }
        }
        private bool JobDataCheck(CGlassDataProperties glassData)
        {

            return true;
        }

        public override int ExecuteManual(Dictionary<string, string> values)
        {
            //this.StatusChange(enumProgramStatus.NONE);
            _component.UnloadRequest = false;
            _component.UnloadEnable = false;
            _component.StartUnLoadSEQ = false;
            _component.AbnormalSEQ = false;
            _main.MelsecNetBitOnOff(OB_LINK_UP1_SEND_ABLE, false);
            _main.MelsecNetBitOnOff(OB_LINK_UP1_SEND_START, false);
            _main.MelsecNetBitOnOff(OB_LINK_UP1_SEND_COMPLETE, false);

            _main.MelsecNetBitOnOff(OB_LINK_UP1_HALFGLASSFLAG, false);
            this.ChangeStep(enumStep.NONE);
            return 0;
        }

        private void AbnormalStop()
        {
            List<string> dataList2 = new List<string>();
            dataList2.Add("ABNORMAL_INTERFACE");
            _main.SendData(dataList2);
            this.ChangeStep(enumStep.NONE);
            _component.UnloadRequest = false;
            _component.LoadRequest = false;
        }
    }
}
