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
    public class CLinkSignalType11_WHTM : AProgram
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
        private bool _Half_Glass_Flag = false;

        private const int T1 = 30000;
        private const int T2 = 3000;
        private const int T3 = 30000;
        private const int T4 = 3000;

        public CLinkSignalType11_WHTM()
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
            get { return "Link Signal Type 10 대응"; }
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
            get { return "LINK_SIGNAL_TYPE11"; }
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
            PROCESS_DATA_REPORT,
            SENT_OUT_JOB_REPORT,
            RECEIVE_START,
            WAIT_TROUBLE1_CLEAR,
            WAIT_TROUBLE2_CLEAR,
            TROUBLE1_COMPLETE,
            WAIT_RECV_COMPLETE,
            WAIT_SEND_COMPLETE,
            RECV_COMPLETE,
            WAIT_UP_TRANSFER_SIGNAL,
            SEND_COMPLETE,
            REPORT,
            END,
            CANCEL,
            T1,
            T2,
            T3,
            T4
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

        private CGlassDataPropertiesWHTM ULD_glassData1 = null;
        private CGlassDataPropertiesWHTM ULD_glassData2 = null;
        private CGlassDataPropertiesWHTM LD_glassData1 = null;
        private CGlassDataPropertiesWHTM LD_glassData2 = null;
        private bool _jobTransSignal = false;
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

            Log(string.Format("{0}", "LOOP START"));
            while (true)
            {
                bool stageUpstream = _main.MelsecNetBitRead(OB_LINK_UP1_UPSTREAM_INLINE, 1);
                bool stageDownstream = _main.MelsecNetBitRead(OB_LINK_DOWN1_DOWNSTREAM_INLINE, 1);
                bool stageExchangePossible = _main.MelsecNetBitRead(OB_LINK_UP1_EXCHANGE_POSSIBLE, 1);

                bool robotUpstream = bool.Parse(IB_LINK_UP1_UPSTREAM_INLINE.Value);
                bool robotDownstream = bool.Parse(IB_LINK_DOWN1_DOWNSTREAM_INLINE.Value);
                
                //bool sendAble = false;

                switch (_step)
                {
                    case enumStep.NONE:
                        _component.StartExchangeSEQ = false;

                        if (_component.AbnormalSEQ)
                        {
                            if (bool.Parse(IB_LINK_UP1_HAND_INTERFERENCE.Value) || bool.Parse(IB_LINK_DOWN1_HAND_INTERFERENCE.Value))
                            {
                                _component.AbnormalSEQ = false;

                                if (_component.WaitUnloadRequest)
                                {
                                    _component.WaitUnloadRequest = false;
                                    _component.UnloadRequest = true;
                                }

                                if (_component.WaitLoadRequest)
                                {
                                    _component.WaitLoadRequest = false;
                                    _component.LoadRequest = true;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }

                        if (stageUpstream && stageDownstream && stageExchangePossible && robotUpstream && robotDownstream && _component.UnloadRequest)
                        {
                            //this.ChangeStep(enumStep.WAIT);

                            _component.UnloadHandDownCompletionReply = false;

                            if (bool.Parse(IB_LINK_DOWN1_JOB_TRANSFER_SIGNAL.Value) || bool.Parse(IB_LINK_UP1_JOB_TRANSFER_SIGNAL.Value))
                                break;

                            if (bool.Parse(IB_LINK_DOWN1_RECEIVE_ABLE.Value) || bool.Parse(IB_LINK_DOWN1_RECEIVE_START.Value) || bool.Parse(IB_LINK_DOWN1_RECEIVE_COMPLETE.Value))
                            {
                                this.AbnormalStop();
                            }
                            else if (bool.Parse(IB_LINK_UP1_SEND_ABLE.Value) || bool.Parse(IB_LINK_UP1_SEND_START.Value) || bool.Parse(IB_LINK_UP1_SEND_COMPLETE.Value))
                            {
                                this.AbnormalStop();
                            }

                            List<int> value2 = new List<int>();
                            value2.Add(301);
                            value2.Add(0);

                            List<int> value4 = new List<int>();
                            value4.Add(301);
                            value4.Add(0);
                            AMaterialData materialData = _main.GetReceivedGlassDataByLoc(_component.ControlName, 0);
                            AMaterialData materialData2 = _main.GetReceivedGlassDataByLoc(_component.ControlName, 1);

                            if (materialData != null || materialData2 != null)
                            {
                                //임시
                                ULD_glassData1 = materialData as CGlassDataPropertiesWHTM;
                                ULD_glassData2 = materialData2 as CGlassDataPropertiesWHTM;

                                if (ULD_glassData1 != null)
                                {
                                    if (ULD_glassData1.GlassID != "")
                                    {
                                        ULD_glassData1.TrackingData = (ulong)_component.Glass_Tracking_DataA;
                                        //Fix Data
                                        ULD_glassData1.UnitPathNo = 301;
                                        ULD_glassData1.SlotNo = 0;

                                        _main.AddSentOutGlassData(_component.ControlName, ULD_glassData1, 0);
                                        _main.MelsecNetMultiWordWrite(OW_LINK_DOWN1_JOB_DATA1, CGlassDataPropertiesWHTM.ConvertPLCData(ULD_glassData1));
                                        _main.MelsecNetMultiWordWrite(OW_LINK_DOWN1_TRANS_JOB_DATA1, value2);
                                    }
                                    else
                                    {
                                        ULD_glassData1 = null;
                                        value2 = new List<int>() { 0, 0 };
                                        _main.MelsecNetMultiWordWrite(OW_LINK_DOWN1_JOB_DATA1, CGlassDataPropertiesWHTM.ConvertPLCData(ULD_glassData1));
                                        _main.MelsecNetBitOnOff(OB_LINK_UP1_HALFGLASSFLAG, true);
                                        _main.MelsecNetMultiWordWrite(OW_LINK_DOWN1_TRANS_JOB_DATA1, value2);
                                    }
                                }
                                else
                                {
                                    ULD_glassData1 = null;
                                    value2 = new List<int>() { 0, 0 };
                                    _main.MelsecNetMultiWordWrite(OW_LINK_DOWN1_JOB_DATA1, CGlassDataPropertiesWHTM.ConvertPLCData(ULD_glassData1));
                                    _main.MelsecNetBitOnOff(OB_LINK_UP1_HALFGLASSFLAG, true);
                                    _main.MelsecNetMultiWordWrite(OW_LINK_DOWN1_TRANS_JOB_DATA1, value2);
                                }

                                if (ULD_glassData2 != null)
                                {
                                    if (ULD_glassData2.GlassID != "")
                                    {
                                        ULD_glassData2.TrackingData = (ulong)_component.Glass_Tracking_DataB;
                                        //Fix Data
                                        ULD_glassData2.UnitPathNo = 301;
                                        ULD_glassData2.SlotNo = 0;

                                        _main.AddSentOutGlassData(_component.ControlName, ULD_glassData2, 1);
                                        _main.MelsecNetMultiWordWrite(OW_LINK_DOWN1_JOB_DATA2, CGlassDataPropertiesWHTM.ConvertPLCData(ULD_glassData2));
                                        _main.MelsecNetMultiWordWrite(OW_LINK_DOWN1_TRANS_JOB_DATA2, value4);
                                    }
                                    else
                                    {
                                        ULD_glassData2 = null;
                                        value4 = new List<int>() { 0, 0 };
                                        _main.MelsecNetMultiWordWrite(OW_LINK_DOWN1_JOB_DATA2, CGlassDataPropertiesWHTM.ConvertPLCData(ULD_glassData2));
                                        _main.MelsecNetMultiWordWrite(OW_LINK_DOWN1_TRANS_JOB_DATA2, value4);
                                    }
                                }
                                else
                                {
                                    ULD_glassData2 = null;
                                    value4 = new List<int>() { 0, 0 };
                                    _main.MelsecNetMultiWordWrite(OW_LINK_DOWN1_JOB_DATA2, CGlassDataPropertiesWHTM.ConvertPLCData(ULD_glassData2));
                                    _main.MelsecNetMultiWordWrite(OW_LINK_DOWN1_TRANS_JOB_DATA2, value4);
                                }
                                _main.MelsecNetBitOnOff(OB_LINK_UP1_SEND_ABLE, true);

                                this.ChangeStep(enumStep.WAIT);
                            }
                            else
                            {
                                //정보가 없으면 처리는?
                                _main.MelsecNetBitOnOff(OB_LINK_UP1_SEND_ABLE, true);

                                this.ChangeStep(enumStep.WAIT);
                            }
                        }
                        break;
                    case enumStep.WAIT:
                        //robot_downstream : exchange execute on, receive able on
                        _component.StartExchangeSEQ = true;
                        if (bool.Parse(IB_LINK_DOWN1_RECEIVE_ABLE.Value) && bool.Parse(IB_LINK_DOWN1_EXCHANGE_EXECUTE.Value)) //_main.MelsecNetBitRead(IB_LINK_DOWN1_RECEIVE_ABLE, 1) && _main.MelsecNetBitRead(IB_LINK_DOWN1_EXCHANGE_EXECUTE, 1))
                        {
                            //if(_main.MelsecNetBitRead(OB_LINK_UP1_SEND_START, 1) == false)
                            //    _main.MelsecNetBitOnOff(OB_LINK_UP1_SEND_START, true);
                            //robot_upstream send able on
                            if (_main.MelsecNetBitRead(IB_LINK_UP1_SEND_ABLE, 1))
                            {
                                _component.Glass_Tracking_DataA = 0;
                                _component.Glass_Tracking_DataB = 0;
                                this.ChangeStep(enumStep.DATA_CHECK);
                            }
                        }

                        break;
                    case enumStep.DATA_CHECK:

                        //stage_downstream : job data check
                        ushort[] jobDataRaw1 = null;
                        ushort[] jobDataSubRaw1 = null;
                        ushort[] jobDataRaw2 = null;
                        ushort[] jobDataSubRaw2 = null;

                        jobDataRaw1 = _main.MelsecNetMultiWordRead(IW_LINK_DOWN1_JOB_DATA1);
                        jobDataSubRaw1 = _main.MelsecNetMultiWordRead(IW_LINK_DOWN1_TRANS_JOB_DATA1);
                        LD_glassData1 = new CGlassDataPropertiesWHTM(jobDataRaw1);

                        jobDataRaw2 = _main.MelsecNetMultiWordRead(IW_LINK_DOWN1_JOB_DATA2);
                        jobDataSubRaw2 = _main.MelsecNetMultiWordRead(IW_LINK_DOWN1_TRANS_JOB_DATA2);
                        LD_glassData2 = new CGlassDataPropertiesWHTM(jobDataRaw2);

                        if (bool.Parse(IB_LINK_UP1_HALFGLASSFLAG.Value))
                        {
                            _Half_Glass_Flag = true;
                            if (this.RecevieJobDataCheck(LD_glassData1))
                            {
                                string cstIndex2 = "";
                                string portNo2 = "";
                                string seqNo2 = "";
                                string glassIndex2 = "";
                                string position2 = "";
                                string slotNo2 = "";
                                string glassId2 = "";
                                string lotId2 = "";
                                string glassType2 = "";
                                string ppid2 = "";
                                string recipeId2 = "";
                                string prodId2 = "";
                                string stepid2 = "";
                                string cstid2 = "";

                                CSubject subject = CUIManager.Inst.GetData("ucEQP");
                                bool noGlass1 = false;
                                bool noGlass2 = false;
                                bool halfSize1 = false;
                                bool halfSize2 = false;
                                bool whole = false;

                                if (LD_glassData1 != null && LD_glassData1.CassetteIndex != 0)
                                {
                                    cstIndex2 = LD_glassData1.CassetteIndex.ToString();
                                    portNo2 = LD_glassData1.PortNo.ToString();
                                    seqNo2 = LD_glassData1.SeqNo.ToString();
                                    glassIndex2 = LD_glassData1.GlassIndex.ToString();
                                    position2 = LD_glassData1.GlassPosition.ToString();
                                    slotNo2 = LD_glassData1.SlotNo.ToString();
                                    glassId2 = LD_glassData1.GlassID;
                                    lotId2 = LD_glassData1.LotID;
                                    glassType2 = LD_glassData1.GlassType.ToString();
                                    ppid2 = LD_glassData1.PPID;
                                    recipeId2 = _main.getRecipeId(ppid2);
                                    prodId2 = LD_glassData1.ProductId.ToString();
                                    stepid2 = LD_glassData1.OperationId.ToString();
                                    cstid2 = LD_glassData1.CassetteId;
                                    LD_glassData1.ChangeLocation(_component.ControlName, "1");
                                    _main.AddReceviedGlassData(_component.ControlName, LD_glassData1, 1, true);

                                    subject.SetValue("RECIPE", _component.CurrentRecipeNo);
                                    subject.SetValue("GlassCode1", LD_glassData1.GlassIndex.ToString());
                                    subject.SetValue("GlassID1", LD_glassData1.GlassID);

                                    if (position2 == "2")
                                    {
                                        whole = false;
                                        halfSize1 = false;
                                        halfSize2 = true;
                                    }
                                }
                                else
                                {
                                    noGlass1 = true;
                                }

                                if (_component.AutoRecipeMode || _component.CurrentRecipeNo == recipeId2)
                                {

                                    subject.SetValue("GlassExist_Whole", whole);
                                    subject.SetValue("GlassExist_A", halfSize1);
                                    subject.SetValue("GlassExist_B", halfSize2);

                                    _main.SendData(new List<string> { "GLASS_DATA_SEND", noGlass1 && noGlass2 ? "X" : "O", string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19}", "", "", "", "", "", "", "", "", "", "", portNo2, seqNo2, position2, slotNo2, glassId2, lotId2, recipeId2, stepid2, prodId2, cstid2) });

                                    _main.SendData(new List<string>() { "SHUTTER_STATUS_REQ" });

                                    this.ChangeStep(enumStep.SHUTTER_STATE);
                                    subject.Notify();
                                }
                                else
                                {
                                    _component.LoadRequest = false;
                                    _component.LoadEnable = false;
                                    _main.MelsecNetBitOnOff(OB_LINK_DOWN1_RECEIVE_ABLE, false);
                                    _main.MelsecNetBitOnOff(OB_LINK_UP1_HALFGLASSFLAG, false);

                                    //20161125
                                    List<string> dataList = new List<string>();
                                    dataList.Add("ALARM_SET_REQUEST");
                                    dataList.Add("1");
                                    dataList.Add("9000");
                                    _main.SendData(dataList);

                                    this.ChangeStep(enumStep.NONE);
                                }
                            }
                        }
                        else
                        {
                            if (this.RecevieJobDataCheck(LD_glassData1) || this.RecevieJobDataCheck(LD_glassData2))
                            {
                                string cstIndex1 = "";
                                string portNo1 = "";
                                string seqNo1 = "";
                                string glassIndex1 = "";
                                string position1 = "";
                                string slotNo1 = "";
                                string glassId1 = "";
                                string lotId1 = "";
                                string glassType1 = "";
                                string ppid1 = "";
                                string recipeId1 = "";
                                string prodId1 = "";
                                string stepid1 = "";
                                string cstid1 = "";

                                string cstIndex2 = "";
                                string portNo2 = "";
                                string seqNo2 = "";
                                string glassIndex2 = "";
                                string position2 = "";
                                string slotNo2 = "";
                                string glassId2 = "";
                                string lotId2 = "";
                                string glassType2 = "";
                                string ppid2 = "";
                                string recipeId2 = "";
                                string prodId2 = "";
                                string stepid2 = "";
                                string cstid2 = "";
                                CSubject subject = CUIManager.Inst.GetData("ucEQP");
                                bool noGlass1 = false;
                                bool noGlass2 = false;
                                bool halfSize1 = false;
                                bool halfSize2 = false;
                                bool whole = false;

                                if (LD_glassData1 != null && LD_glassData1.CassetteIndex != 0)
                                {
                                    cstIndex1 = LD_glassData1.CassetteIndex.ToString();
                                    portNo1 = LD_glassData1.PortNo.ToString();
                                    seqNo1 = LD_glassData1.SeqNo.ToString();
                                    glassIndex1 = LD_glassData1.GlassIndex.ToString();
                                    position1 = LD_glassData1.GlassPosition.ToString();
                                    slotNo1 = LD_glassData1.SlotNo.ToString();
                                    glassId1 = LD_glassData1.GlassID;
                                    lotId1 = LD_glassData1.LotID;
                                    glassType1 = LD_glassData1.GlassType.ToString();
                                    ppid1 = LD_glassData1.PPID;
                                    recipeId1 = _main.getRecipeId(ppid1);
                                    prodId1 = LD_glassData1.ProductId.ToString();
                                    stepid1 = LD_glassData1.OperationId.ToString();
                                    cstid1 = LD_glassData1.CassetteId;
                                    LD_glassData1.ChangeLocation(_component.ControlName, "0");
                                    _main.AddReceviedGlassData(_component.ControlName, LD_glassData1, 0, true);

                                    subject.SetValue("RECIPE", _component.CurrentRecipeNo);
                                    subject.SetValue("GlassCode1", LD_glassData1.GlassIndex.ToString());
                                    subject.SetValue("GlassID1", LD_glassData1.GlassID);

                                    if (position1 == "3")
                                    {
                                        whole = true;
                                        halfSize1 = false;
                                    }
                                    else if (position1 == "1")
                                    {
                                        whole = false;
                                        halfSize1 = true;
                                    }
                                }
                                else
                                {
                                    noGlass1 = true;
                                }

                                if (LD_glassData2 != null && LD_glassData2.CassetteIndex != 0)
                                {
                                    cstIndex2 = LD_glassData2.CassetteIndex.ToString();
                                    portNo2 = LD_glassData2.PortNo.ToString();
                                    seqNo2 = LD_glassData2.SeqNo.ToString();
                                    glassIndex2 = LD_glassData2.GlassIndex.ToString();
                                    position2 = LD_glassData2.GlassPosition.ToString();
                                    slotNo2 = LD_glassData2.SlotNo.ToString();
                                    glassId2 = LD_glassData2.GlassID;
                                    lotId2 = LD_glassData2.LotID;
                                    glassType2 = LD_glassData2.GlassType.ToString();
                                    ppid2 = LD_glassData2.PPID;
                                    recipeId2 = _main.getRecipeId(ppid2);
                                    prodId2 = LD_glassData2.ProductId.ToString();
                                    stepid2 = LD_glassData2.OperationId.ToString();
                                    cstid2 = LD_glassData2.CassetteId;
                                    LD_glassData2.ChangeLocation(_component.ControlName, "1");
                                    _main.AddReceviedGlassData(_component.ControlName, LD_glassData2, 1, true);

                                    subject.SetValue("RECIPE", _component.CurrentRecipeNo);
                                    subject.SetValue("GlassCode2", LD_glassData2.GlassIndex.ToString());
                                    subject.SetValue("GlassID2", LD_glassData2.GlassID);

                                    if (position2 == "2")
                                    {
                                        halfSize2 = true;
                                    }
                                }
                                else
                                {
                                    noGlass2 = true;
                                }

                                if (LD_glassData1 == null && LD_glassData2 != null)
                                {
                                    glassType1 = glassType2;
                                }
                                //subject.SetValue("HalfSIzeType", halfSize1 & halfSize1);
                                //_main.SendData(new List<string> { "GLASS_DATA_SEND", noGlass1 && noGlass2 ? "X":"O", string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13}", portNo1, seqNo1, position1, slotNo1, glassId1, lotId1, recipeId1, portNo2, seqNo2, position2, slotNo2, glassId2, lotId2, recipeId2) });


                                if (_component.AutoRecipeMode || _component.CurrentRecipeNo == recipeId1 || _component.CurrentRecipeNo == recipeId2)
                                {
                                    subject.SetValue("GlassExist_Whole", whole);
                                    subject.SetValue("GlassExist_A", halfSize1);
                                    subject.SetValue("GlassExist_B", halfSize2);

                                    _main.SendData(new List<string> { "GLASS_DATA_SEND", noGlass1 && noGlass2 ? "X" : "O", string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19}", 
                                    portNo1, seqNo1, position1, slotNo1, glassId1, lotId1, recipeId1, stepid1, prodId1, cstid1, portNo2, seqNo2, position2, slotNo2, glassId2, lotId2, recipeId2, stepid2, prodId2,cstid2) });

                                    _main.SendData(new List<string>() { "SHUTTER_STATUS_REQ" });

                                    this.ChangeStep(enumStep.SHUTTER_STATE);
                                    subject.Notify();
                                }
                                else
                                {
                                    _component.LoadRequest = false;
                                    _component.LoadEnable = false;
                                    _main.MelsecNetBitOnOff(OB_LINK_DOWN1_RECEIVE_ABLE, false);
                                    _main.MelsecNetBitOnOff(OB_LINK_UP1_HALFGLASSFLAG, false);

                                    //20161125
                                    List<string> dataList = new List<string>();
                                    dataList.Add("ALARM_SET_REQUEST");
                                    dataList.Add("1");
                                    dataList.Add("9000");
                                    _main.SendData(dataList);

                                    this.ChangeStep(enumStep.NONE);
                                }
                            }
                        }
                        //_main.SendData(new List<string>() { "SHUTTER_STATUS_REQ" });
                        //this.ChangeStep(enumStep.SHUTTER_STATE);
                        
                        break;
                  
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
                            //stage_upstream : send start on
                            _main.MelsecNetBitOnOff(OB_LINK_UP1_SEND_START, true);

                            this.ChangeStep(enumStep.START);
                        }
                        break;
                    case enumStep.START:
                        //robot_downstream : receive start on
                        if(!bool.Parse(IB_LINK_DOWN1_RECEIVE_ABLE.Value) || !bool.Parse(IB_LINK_UP1_UPSTREAM_INLINE.Value))
                        {
                            this.AbnormalStop();
                        }
                        else if (bool.Parse(IB_LINK_DOWN1_RECEIVE_START.Value))// _main.MelsecNetBitRead(IB_LINK_DOWN1_RECEIVE_START, 1))
                        {
                            this.ChangeStep(enumStep.MOVING);
                        }
                        else if (bool.Parse(OB_LINK_UP1_UPSTREAM_TROUBLE.Value) || bool.Parse(OB_LINK_DOWN1_DOWNSTREAM_TROUBLE.Value))
                        {
                            _main.MelsecNetBitOnOff(OB_LINK_UP1_SEND_ABLE, false);
                            _main.MelsecNetBitOnOff(OB_LINK_UP1_SEND_START, false);
                            _main.MelsecNetBitOnOff(OB_LINK_UP1_HALFGLASSFLAG, false);

                            _component.UnloadRequest = false;
                            _component.UnloadEnable = false;

                            _component.AbnormalSEQ = true;
                            this.ChangeStep(enumStep.NONE);
                        }
                        else if (bool.Parse(IB_LINK_UP1_UPSTREAM_TROUBLE.Value) || bool.Parse(IB_LINK_DOWN1_DOWNSTREAM_TROUBLE.Value))
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
                        //robot_downstream : job transfer signal on
                        if (!bool.Parse(IB_LINK_DOWN1_RECEIVE_ABLE.Value) || !bool.Parse(IB_LINK_UP1_UPSTREAM_INLINE.Value))
                        {
                            this.AbnormalStop();
                        }
                        else if (bool.Parse(IB_LINK_DOWN1_JOB_TRANSFER_SIGNAL.Value))// _main.MelsecNetBitRead(IB_LINK_DOWN1_JOB_TRANSFER_SIGNAL, 1))
                        {
                            _main.SendData(new List<string> { "UNLOAD_HAND_UP_COMPLETION" });


                            //stage_upstream : sent out job report


                            //stage_downstream : receive able on
                            //_main.MelsecNetBitOnOff(OB_LINK_DOWN1_RECEIVE_ABLE, true);
                            _jobTransSignal = false;

                            this.ChangeStep(enumStep.PROCESS_DATA_REPORT);
                        }
                        else if (bool.Parse(OB_LINK_UP1_UPSTREAM_TROUBLE.Value) || bool.Parse(OB_LINK_DOWN1_DOWNSTREAM_TROUBLE.Value))
                        {
                            _main.MelsecNetBitOnOff(OB_LINK_UP1_SEND_ABLE, false);
                            _main.MelsecNetBitOnOff(OB_LINK_UP1_SEND_START, false);
                            _main.MelsecNetBitOnOff(OB_LINK_UP1_HALFGLASSFLAG, false);

                            _component.UnloadRequest = false;
                            _component.UnloadEnable = false;

                            _component.AbnormalSEQ = true;
                            this.ChangeStep(enumStep.NONE);
                        }
                        else if (bool.Parse(IB_LINK_UP1_UPSTREAM_TROUBLE.Value) || bool.Parse(IB_LINK_DOWN1_DOWNSTREAM_TROUBLE.Value))
                        {
                            _main.MelsecNetBitOnOff(OB_LINK_UP1_SEND_ABLE, false);
                            _main.MelsecNetBitOnOff(OB_LINK_UP1_SEND_START, false);
                            _main.MelsecNetBitOnOff(OB_LINK_UP1_HALFGLASSFLAG, false);

                            _component.UnloadEnable = false;

                            _component.AbnormalSEQ = true;
                            this.ChangeStep(enumStep.NONE);
                        }
                        break;

                    case enumStep.PROCESS_DATA_REPORT:
                        if (_component.UnloadHandDownCompletionReply)
                        {
                            Dictionary<string, string> values = new Dictionary<string, string>();

                            if (ULD_glassData1 != null && (ULD_glassData1.GlassPosition == 1 || ULD_glassData1.GlassPosition == 3))
                            {
                                values.Clear();
                                values.Add("GLS_INDEX", "0");
                                values.Add("TRANS_STATE", "4");
                                _component.GetProgram("TRACKING_JOB_REPORT").ExecuteManual(values);
                            }

                            if (ULD_glassData2 != null && ULD_glassData2.GlassPosition == 2)
                            {
                                values.Clear();
                                values.Add("GLS_INDEX", "1");
                                values.Add("TRANS_STATE", "4");
                                _component.GetProgram("TRACKING_JOB_REPORT").ExecuteManual(values);
                            }

                            Thread.Sleep(100);

                            if (ULD_glassData1 != null && (ULD_glassData1.GlassPosition == 1 || ULD_glassData1.GlassPosition == 3))
                            {
                                values.Clear();
                                values.Add("GLS_INDEX", "0");
                                values.Add("FILE_PATH", _component.glass_data_value_file_A);
                                _component.GetProgram("PROCESS_DATA_REPORT").ExecuteManual(values);
                            }

                            if (ULD_glassData2 != null && ULD_glassData2.GlassPosition == 2)
                            {
                                values.Clear();
                                values.Add("GLS_INDEX", "1");
                                values.Add("FILE_PATH", _component.glass_data_value_file_B);
                                _component.GetProgram("PROCESS_DATA_REPORT").ExecuteManual(values);
                            }

                            _main.MelsecNetBitOnOff(OB_LINK_DOWN1_RECEIVE_ABLE, true);

                            this.ChangeStep(enumStep.SENT_OUT_JOB_REPORT);
                            
                        }
                        break;

                    case enumStep.SENT_OUT_JOB_REPORT:
                        Dictionary<string, string> values1 = new Dictionary<string, string>();


                        if (ULD_glassData1 != null && (ULD_glassData1.GlassPosition == 1 || ULD_glassData1.GlassPosition == 3))
                        {
                            values1.Clear();
                            values1.Add("GLS_INDEX", "0");
                            _component.GetProgram("SENT_OUT_JOB_REPORT").ExecuteManual(values1);
                        }
                        Thread.Sleep(100);
                        if (ULD_glassData2 != null && ULD_glassData2.GlassPosition == 2)
                        {
                            values1.Clear();
                            values1.Add("GLS_INDEX", "1");
                            _component.GetProgram("SENT_OUT_JOB_REPORT").ExecuteManual(values1);
                        }
                        this.ChangeStep(enumStep.RECEIVE_START);
                        break;

                    case enumStep.RECEIVE_START:
                        if (bool.Parse(IB_LINK_UP1_SEND_START.Value))
                        {
                            //stage_downstream : receive start on
                            _main.MelsecNetBitOnOff(OB_LINK_DOWN1_RECEIVE_START, true);

                            this.ChangeStep(enumStep.WAIT_RECV_COMPLETE);
                        }
                        else if (bool.Parse(OB_LINK_UP1_UPSTREAM_TROUBLE.Value) || bool.Parse(OB_LINK_DOWN1_DOWNSTREAM_TROUBLE.Value))
                        {
                            _main.MelsecNetBitOnOff(OB_LINK_UP1_SEND_ABLE, false);
                            _main.MelsecNetBitOnOff(OB_LINK_UP1_SEND_START, false);
                            _main.MelsecNetBitOnOff(OB_LINK_UP1_HALFGLASSFLAG, false);

                            _component.UnloadRequest = false;
                            _component.UnloadEnable = false;

                            _component.AbnormalSEQ = true;
                            this.ChangeStep(enumStep.NONE);
                        }
                        else if (bool.Parse(IB_LINK_UP1_UPSTREAM_TROUBLE.Value) || bool.Parse(IB_LINK_DOWN1_DOWNSTREAM_TROUBLE.Value))
                        {
                            _main.MelsecNetBitOnOff(OB_LINK_UP1_SEND_ABLE, false);
                            _main.MelsecNetBitOnOff(OB_LINK_UP1_SEND_START, false);
                            _main.MelsecNetBitOnOff(OB_LINK_UP1_HALFGLASSFLAG, false);

                            _component.UnloadEnable = false;

                            _component.AbnormalSEQ = true;
                            this.ChangeStep(enumStep.NONE);
                        }
                        break;

                    case enumStep.TROUBLE1_COMPLETE:
                    case enumStep.WAIT_RECV_COMPLETE:
                        //if (!_jobTransSignal && _main.MelsecNetBitRead(IB_LINK_UP1_JOB_TRANSFER_SIGNAL, 1) == true)
                        //{
                        //    _jobTransSignal = true;
                        //    _main.SendData(new List<string> { "LOAD_HAND_DOWN_COMPLETION" });
                        //}

                        if (_step != enumStep.TROUBLE1_COMPLETE && !bool.Parse(IB_LINK_UP1_UPSTREAM_INLINE.Value)) //(!bool.Parse(IB_LINK_DOWN1_RECEIVE_ABLE.Value) || !bool.Parse(IB_LINK_UP1_UPSTREAM_INLINE.Value)))
                        {
                            this.AbnormalStop();
                        }
                        //robot downstream : receive complete on
                        else if (bool.Parse(IB_LINK_DOWN1_RECEIVE_COMPLETE.Value))// _main.MelsecNetBitRead(IB_LINK_DOWN1_RECEIVE_COMPLETE, 1))
                        {
                            _component.UnloadRequest = false;
                            _jobTransSignal = false;
                            //stage upstream : send complete on 
                            _main.MelsecNetBitOnOff(OB_LINK_UP1_SEND_COMPLETE, true);
                            this.ChangeStep(enumStep.RECV_COMPLETE);
                        }
                        else if (!bool.Parse(OB_LINK_UP1_UPSTREAM_TROUBLE.Value) && !bool.Parse(OB_LINK_DOWN1_DOWNSTREAM_TROUBLE.Value) && (bool.Parse(IB_LINK_UP1_UPSTREAM_TROUBLE.Value) || bool.Parse(IB_LINK_DOWN1_DOWNSTREAM_TROUBLE.Value)))
                        {
                            //5.16. Robot(Upstream) Trouble: After Robot Putting Glass to Stage 

                            if (_component.UnloadRequest)
                            {
                                _component.WaitUnloadRequest = true;
                                _component.UnloadRequest = false;
                            }
                            _main.MelsecNetBitOnOff(OB_LINK_UP1_SEND_START, false);
                            _main.MelsecNetBitOnOff(OB_LINK_UP1_SEND_ABLE, false);
                            //_main.MelsecNetBitOnOff(OB_LINK_DOWN1_EXCHANGE_CANCEL_RECEIVE, true);
                            _main.MelsecNetBitOnOff(OB_LINK_DOWN1_RECEIVE_ABLE, false);
                            _main.MelsecNetBitOnOff(OB_LINK_DOWN1_RECEIVE_START, false);

                            _component.AbnormalSEQ = true;
                            this.ChangeStep(enumStep.WAIT_TROUBLE1_CLEAR);
                        }
                        else if (bool.Parse(OB_LINK_UP1_UPSTREAM_TROUBLE.Value) && bool.Parse(OB_LINK_DOWN1_DOWNSTREAM_TROUBLE.Value) && (bool.Parse(IB_LINK_UP1_UPSTREAM_TROUBLE.Value) || bool.Parse(IB_LINK_DOWN1_DOWNSTREAM_TROUBLE.Value)))
                        {
                            //5.16. Robot(Upstream) Trouble: After Robot Putting Glass to Stage 
                            _component.UnloadRequest = false;
                            _main.MelsecNetBitOnOff(OB_LINK_UP1_SEND_START, false);
                            _main.MelsecNetBitOnOff(OB_LINK_UP1_SEND_ABLE, false);
                            _main.MelsecNetBitOnOff(OB_LINK_DOWN1_RECEIVE_ABLE, false);
                            _main.MelsecNetBitOnOff(OB_LINK_DOWN1_RECEIVE_START, false);

                            _component.AbnormalSEQ = true;
                            this.ChangeStep(enumStep.WAIT_TROUBLE1_CLEAR);
                        }
                        break;

                    case enumStep.WAIT_TROUBLE1_CLEAR:

                        if (!bool.Parse(IB_LINK_DOWN1_JOB_TRANSFER_SIGNAL.Value))
                        {
                            this.AbnormalStop();
                        }
                        //else if (!bool.Parse(IB_LINK_UP1_SEND_ABLE.Value) && bool.Parse(OB_LINK_DOWN1_EXCHANGE_CANCEL_RECEIVE.Value))
                        //{
                        //    _main.MelsecNetBitOnOff(OB_LINK_DOWN1_EXCHANGE_CANCEL_RECEIVE, false);
                        //}
                        else if (!bool.Parse(OB_LINK_UP1_UPSTREAM_TROUBLE.Value) && !bool.Parse(OB_LINK_DOWN1_DOWNSTREAM_TROUBLE.Value))// && !bool.Parse(IB_LINK_DOWN1_DOWNSTREAM_TROUBLE.Value))//해결
                        {
                            this.ChangeStep(enumStep.TROUBLE1_COMPLETE);
                        }

                        break;

                    case enumStep.RECV_COMPLETE:
                        //robot downstream : receive able, start, completed, transfer signal off
                        if (bool.Parse(IB_LINK_DOWN1_RECEIVE_ABLE.Value) == false)// _main.MelsecNetBitRead(IB_LINK_DOWN1_RECEIVE_ABLE, 1) == false)
                            if (bool.Parse(IB_LINK_DOWN1_RECEIVE_START.Value) == false)//_main.MelsecNetBitRead(IB_LINK_DOWN1_RECEIVE_START, 1) == false)
                                if (bool.Parse(IB_LINK_DOWN1_RECEIVE_COMPLETE.Value) == false)//_main.MelsecNetBitRead(IB_LINK_DOWN1_RECEIVE_COMPLETE, 1) == false)
                                {
                                    _component.UnloadRequest = false;
                                    //stage upstream : send able, start, completed, transfer signal off
                                    _main.MelsecNetBitOnOff(OB_LINK_UP1_SEND_ABLE, false);
                                    _main.MelsecNetBitOnOff(OB_LINK_UP1_SEND_START, false);
                                    _main.MelsecNetBitOnOff(OB_LINK_UP1_SEND_COMPLETE, false);

                                    //20170325
                                    //if (_previousStep == enumStep.TROUBLE1_COMPLETE)
                                    //{
                                    //    Log(string.Format("{0}\t[{1}]\tRET={2}", "PROGRAM ABNORMAL", this.Name.ToUpper(), ret));
                                    //    _step = enumStep.END;
                                    //}
                                    //else
                                    //{
                                    this.ChangeStep(enumStep.WAIT_UP_TRANSFER_SIGNAL);
                                    //}
                                }

                        break;

                    case enumStep.WAIT_UP_TRANSFER_SIGNAL:
                        if (_main.MelsecNetBitRead(IB_LINK_UP1_SEND_START, 1))
                        {
                            if (_main.MelsecNetBitRead(IB_LINK_UP1_JOB_TRANSFER_SIGNAL, 1))
                            {
                                _main.SendData(new List<string> { "LOAD_HAND_DOWN_COMPLETION" }); //20161122
                                this.ChangeStep(enumStep.WAIT_SEND_COMPLETE);
                            }

                            else if (_main.MelsecNetBitRead(OB_LINK_DOWN1_DOWNSTREAM_TROUBLE, 1))
                            {
                                //_main.MelsecNetBitOnOff(OB_LINK_DOWN1_DOWNSTREAM_TROUBLE, true);
                                _main.SendData(new List<string> { "ABNORMAL_INTERFACE" });
                                this.ChangeStep(enumStep.NONE);

                            }
                            else if (_main.MelsecNetBitRead(IB_LINK_UP1_UPSTREAM_TROUBLE, 1)) //20171121
                            {
                                _main.SendData(new List<string> { "ABNORMAL_INTERFACE" });
                                this.ChangeStep(enumStep.NONE);
                            }
                        }
                        break;
                    
                    case enumStep.WAIT_SEND_COMPLETE:
                        //if (!_jobTransSignal)// && _main.MelsecNetBitRead(IB_LINK_UP1_JOB_TRANSFER_SIGNAL, 1) == true)
                        //{
                        //    _jobTransSignal = true;
                        //    _main.SendData(new List<string> { "LOAD_HAND_DOWN_COMPLETION" });
                        //}

                        //robot upstream : send complete on
                        if (bool.Parse(IB_LINK_UP1_SEND_COMPLETE.Value))//_main.MelsecNetBitRead(IB_LINK_UP1_SEND_COMPLETE, 1))
                        {
                            _jobTransSignal = false;
                            //stage downstream : receive complete on 
                            _main.MelsecNetBitOnOff(OB_LINK_DOWN1_RECEIVE_COMPLETE, true);
                            this.ChangeStep(enumStep.SEND_COMPLETE);
                            _main.SendData(new List<string> { "UNLOAD_COMPLETE" });
                        }
                        else if (_main.MelsecNetBitRead(OB_LINK_DOWN1_DOWNSTREAM_TROUBLE, 1) && _main.MelsecNetBitRead(OB_LINK_DOWN1_RECEIVE_ABLE, 1))
                        {
                            _component.UnloadRequest = false;
                            _main.MelsecNetBitOnOff(OB_LINK_DOWN1_RECEIVE_ABLE, false);
                            _main.MelsecNetBitOnOff(OB_LINK_DOWN1_RECEIVE_START, false);
                            ///_main.SendData(new List<string> { "ABNORMAL_INTERFACE" });
                            //this.ChangeStep(enumStep.LOAD_ABORT_BY_IDX1);
                        }
                        //else if (_component.EqpStatus == 3) //20161214 Down
                        //{
                        //    _main.MelsecNetBitOnOff(OB_LINK_DOWN1_DOWNSTREAM_TROUBLE, true);
                        //    _component.DownStreamInlineMode = false;

                        //    this.ChangeStep(enumStep.LOAD_ABORT_BY_EQP1);

                        //}
                        break;

                    case enumStep.SEND_COMPLETE:
                        //robot upstream : send able, start, completed, transfer signal off
                        if (bool.Parse(IB_LINK_UP1_SEND_ABLE.Value) == false)// _main.MelsecNetBitRead(IB_LINK_UP1_SEND_ABLE, 1) == false)
                            if (bool.Parse(IB_LINK_UP1_SEND_START.Value) == false)// _main.MelsecNetBitRead(IB_LINK_UP1_SEND_START, 1) == false)
                                if (bool.Parse(IB_LINK_UP1_SEND_COMPLETE.Value) == false)// _main.MelsecNetBitRead(IB_LINK_UP1_SEND_COMPLETE, 1) == false)
                                {
                                    //stage downstream : receive able, start, completed, transfer signal off
                                    _main.MelsecNetBitOnOff(OB_LINK_DOWN1_RECEIVE_ABLE, false);
                                    _main.MelsecNetBitOnOff(OB_LINK_DOWN1_RECEIVE_START, false);
                                    _main.MelsecNetBitOnOff(OB_LINK_DOWN1_RECEIVE_COMPLETE, false);
                                    _main.MelsecNetBitOnOff(OB_LINK_UP1_HALFGLASSFLAG, false);

                                    _component.UnloadRequest = false;
                                    _component.UnloadEnable = false;


                                    this.ChangeStep(enumStep.REPORT);
                                }

                        break;
                    case enumStep.REPORT:
                        Dictionary<string, string> values2 = new Dictionary<string, string>();

                        if (_Half_Glass_Flag)
                        {
                            _Half_Glass_Flag = false;
                            if (LD_glassData1 != null && LD_glassData1.GlassPosition == 2)
                            {
                                values2.Clear();
                                values2.Add("GLS_INDEX", "1");
                                _component.GetProgram("RECEIVED_JOB_REPORT").ExecuteManual(values2);
                            }

                            CSubject subject = null;

                            subject = CUIManager.Inst.GetData("ucGlassData");
                            subject.SetValue("Data", CGlassDataPropertiesWHTM.GetClearData());
                            subject.Notify();

                            Thread.Sleep(300);


                            if (LD_glassData1 != null && LD_glassData1.GlassPosition == 2)
                            {
                                values2.Clear();
                                values2.Add("GLS_INDEX", "1");
                                values2.Add("TRANS_STATE", "1");
                                _component.GetProgram("TRACKING_JOB_REPORT").ExecuteManual(values2);
                            }
                        }
                        else
                        {
                            if (LD_glassData1 != null && (LD_glassData1.GlassPosition == 1 || LD_glassData1.GlassPosition == 3))
                            {
                                values2.Clear();
                                values2.Add("GLS_INDEX", "0");
                                _component.GetProgram("RECEIVED_JOB_REPORT").ExecuteManual(values2);
                            }

                            if (LD_glassData2 != null && LD_glassData2.GlassPosition == 2)
                            {
                                values2.Clear();
                                values2.Add("GLS_INDEX", "1");
                                _component.GetProgram("RECEIVED_JOB_REPORT").ExecuteManual(values2);
                            }
                            //_component.GetProgram("RECEIVED_JOB_REPORT").Execute();

                            Thread.Sleep(300);


                            if (LD_glassData1 != null && (LD_glassData1.GlassPosition == 1 || LD_glassData1.GlassPosition == 3))
                            {
                                values2.Clear();
                                values2.Add("GLS_INDEX", "0");
                                values2.Add("TRANS_STATE", "1");
                                _component.GetProgram("TRACKING_JOB_REPORT").ExecuteManual(values2);
                            }

                            if (LD_glassData2 != null && LD_glassData2.GlassPosition == 2)
                            {
                                values2.Clear();
                                values2.Add("GLS_INDEX", "1");
                                values2.Add("TRANS_STATE", "1");
                                _component.GetProgram("TRACKING_JOB_REPORT").ExecuteManual(values2);
                            }
                        }
                        this.ChangeStep(enumStep.END);
                        break;
                    case enumStep.END:
                        //CSubject subject1 = CUIManager.Inst.GetData("ucGlassData");
                        //Dictionary<string, string> data = CGlassDataPropertiesWHTM.GetClearData(glassData1);
                        //Dictionary<string, string> data2 = CGlassDataPropertiesWHTM.GetClearData(glassData2);
                        //subject1.SetValue("GlassCount", 2);
                        //subject1.SetValue("Data", data);
                        //subject1.SetValue("Data2", data2);
                        //subject1.Notify();
                        this.ChangeStep(enumStep.NONE);
                        break;
                    case enumStep.T1:
                        Dictionary<string, string> t1Value = new Dictionary<string, string>();
                        _main.SetAlarm(_component, DateTime.Now, "991", "");
                        _component.GetProgram("").ExecuteManual(t1Value);
                        this.ChangeStep(_previousStep);
                        break;
                    case enumStep.T2:
                        Dictionary<string, string> t2Value = new Dictionary<string, string>();
                        _main.SetAlarm(_component, DateTime.Now, "992", "");
                        _component.GetProgram("").ExecuteManual(t2Value);
                        this.ChangeStep(_previousStep);
                        break;
                    case enumStep.T3:
                        Dictionary<string, string> t3Value = new Dictionary<string, string>();
                        _main.SetAlarm(_component, DateTime.Now, "993", "");
                        _component.GetProgram("").ExecuteManual(t3Value);
                        this.ChangeStep(_previousStep);
                        break;
                    case enumStep.T4:
                        Dictionary<string, string> t4Value = new Dictionary<string, string>();
                        _main.SetAlarm(_component, DateTime.Now, "994", "");
                        _component.GetProgram("").ExecuteManual(t4Value);
                        this.ChangeStep(_previousStep);
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
            return 0;
        }



        private bool RecevieJobDataCheck(CGlassDataPropertiesWHTM glassData)
        {
            //뭘검사하는건가...
            return true;
        }

        public override int ExecuteManual(Dictionary<string, string> values)
        {
            //this.StatusChange(enumProgramStatus.NONE);

            _component.LoadRequest = false;
            _component.LoadEnable = false;
            _component.UnloadRequest = false;
            _component.UnloadEnable = false;
            _component.StartExchangeSEQ = false;
            _component.AbnormalSEQ = false;
            _component.UnloadHandDownCompletionReply = false;
            _Half_Glass_Flag = false;
            _main.MelsecNetBitOnOff(OB_LINK_DOWN1_RECEIVE_ABLE, false);
            _main.MelsecNetBitOnOff(OB_LINK_DOWN1_RECEIVE_START, false);
            _main.MelsecNetBitOnOff(OB_LINK_DOWN1_RECEIVE_COMPLETE, false);

            _main.MelsecNetBitOnOff(OB_LINK_UP1_SEND_ABLE, false);
            _main.MelsecNetBitOnOff(OB_LINK_UP1_SEND_START, false);
            _main.MelsecNetBitOnOff(OB_LINK_UP1_SEND_COMPLETE, false);

            _main.MelsecNetBitOnOff(OB_LINK_UP1_HALFGLASSFLAG, false);

            _main.MelsecNetBitOnOff(OB_LINK_UP1_EXCHANGE_POSSIBLE, false);
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
