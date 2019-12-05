using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOFD.Component;
using SOFD.Properties;
using MainLibrary;
using System.Threading;

using SOFD.InterfaceTimeout;
using YANGSYS.ControlLib;
using SOFD.Component.Interface;
using SOFD.Global.Manager;


namespace YANGSYS.Biz.Programs
{
    public class CycleProgram_WHTM : AProgram
    {
        private CMain _main = null;
        private bool _enable = false;

        private CPLCControlProperties OB_RUNNING = null;
        private CPLCControlProperties OB_CIM_MODE = null;
        private CPLCControlProperties OB_MACHINE_AUTO_MODE = null;
        private CPLCControlProperties OB_MACHINE_HEARTBEAT_SIGNAL = null;
        private CPLCControlProperties OB_AUTO_RECIPE_CHANGE_MODE = null;
        private CPLCControlProperties OB_JOB_LOADING_STOP = null;

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

        private Thread _thread = null;
        private string _controlName = "";
        private CProbeControl _component = null;
        private CIndexerControl _indexer = null;

        private bool eqpOffline = false;

        public CycleProgram_WHTM()
        {

        }
        public override int Init()
        {
            _enable = true;

            OB_RUNNING = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_RUNNING");
            OB_CIM_MODE = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_CIM_MODE");
            OB_MACHINE_AUTO_MODE = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_MACHINE_AUTO_MODE");
            OB_AUTO_RECIPE_CHANGE_MODE = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_AUTO_RECIPE_CHANGE_MODE");
            OB_JOB_LOADING_STOP = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_JOB_LOADING_STOP");


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


            _component.ProgramsAdd(this);

            _component.UpStreamInlineMode = _main.SystemConfig.Upstream_inline_Flag;
            _component.DownStreamInlineMode = _main.SystemConfig.Downstream_inline_Flag;
            _main.MelsecNetBitOnOff(OB_LINK_DOWN1_DOWNSTREAM_TROUBLE, !_main.SystemConfig.Downstream_inline_Flag);
            _main.MelsecNetBitOnOff(OB_LINK_UP1_UPSTREAM_TROUBLE, !_main.SystemConfig.Upstream_inline_Flag);
            _component.ExchangePossible = _main.SystemConfig.Exchange_Use_Flag;

            _component.AutoRecipeMode = _main.SystemConfig.Auto_Recipe_Flag;

            //Dictionary<string, string> values0 = new Dictionary<string, string>();
            //values0.Add("COMMAND_NAME", "LINK_SIGNAL_INIT");
            //values0.Add("COMMAND", "0");

            //_main.GetProgram("LINK_SIGNAL_TYPE2").ExecuteManual(values0);
            //_main.GetProgram("LINK_SIGNAL_TYPE6").ExecuteManual(values0);
            //_main.GetProgram("LINK_SIGNAL_TYPE11").ExecuteManual(values0);


            _component.CurrentPPID = _main.Saved_Current_PPID;
            _component.CurrentRecipeNo = _main.Saved_Current_RecipeID;

            CSubject subject = CUIManager.Inst.GetData("ucEQP");
            subject.SetValue("RECIPE", _component.CurrentRecipeNo);
            subject.Notify();

            subject = CUIManager.Inst.GetData("ucCimStatus");
            subject.SetValue("CurrentPPID", _component.CurrentPPID);
            subject.SetValue("CurrentRecipeID", _component.CurrentRecipeNo);
            subject.Notify();

            subject = CUIManager.Inst.GetData("frmConfig");
            subject.SetValue("Status", _main.Driver.GetStatus());
            subject.Notify();

            SOFD.Global.Interface.ACommand command = CUIManager.Inst.GetCommand("MENU");
            command.SubCommandName = "CIM_MODE_CHANGE";
            command.AddParameter("CIM_MODE", "2");
            command.Execute();

            _thread = new Thread(new ThreadStart(Cycle));
            _thread.IsBackground = true;
            _thread.Name = this.Name;
            _thread.Start();

            _component.ProgramsAdd(this);
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
            _controlName = _component.ControlName;
            return 0;
        }
        public override string Name
        {
            get { return "CYCLE_PROGRAM"; }
        }

        public override string Version
        {
            get { return "ver 1.0"; }
        }

        public override string Description
        {
            get { return "주기적으로 값을 변경 하거나 입력 하는 프로그램"; }
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
            get { return true; }
        }

       
        public int _interval = 1000;
        public int _heartBeat = 0;
        public int _aliveCount = 0;
        public void Cycle()
        {
            while (true)
            {
                //bool eqpOffline = false;
                if (_component.Communication && _main.Driver.GetStatus() == "Connected")
                {
                    if (_component.Alive)
                    {
                        _aliveCount = 0;
                        _component.Alive = false;
                        eqpOffline = true;
                    }
                    else
                    {
                        if (_aliveCount > 10)
                        {
                            _aliveCount = 0;
                            eqpOffline = false;
                            //OFFLINE으로 간주..
                        }
                        else
                        {
                            //eqpOffline = true;
                            _aliveCount++;
                        }
                    }
                }
                else
                {
                    _component.Alive = false;
                    eqpOffline = false;
                }

                //20161126
                if (_main.GetClientConnected())
                {
                    if (!_component.ClientConnectionFlag)
                    {
                        _component.ClientConnectionFlag = true;
                        _main.SendData(new List<string> { "STATE_REQUEST" });
                    }
                }
                else
                {
                    _component.ClientConnectionFlag = false;
                }


                _component.Running = eqpOffline;
                List<bool> notifycation = new List<bool>();
                notifycation.Add(_component.Running);
                notifycation.Add(false);
                notifycation.Add(_component.MachineAutoMode);
                notifycation.Add(_component.CIMMode == 2);
                notifycation.Add(_component.AutoRecipeMode);
                notifycation.Add(_component.JobLoadingStop);
                notifycation.Add(false);
                notifycation.Add(false);
                byte[] value= _main.GetByte(notifycation, 1);

                _main.MelsecNetBitOnOff(OB_RUNNING, _component.Running);
                _main.MelsecNetBitOnOff(OB_CIM_MODE, _component.CIMMode == 2);
                _main.MelsecNetBitOnOff(OB_MACHINE_AUTO_MODE, _component.MachineAutoMode);
                _main.MelsecNetBitOnOff(OB_AUTO_RECIPE_CHANGE_MODE, _component.AutoRecipeMode);

                _main.MelsecNetBitOnOff(OB_LINK_DOWN1_DOWNSTREAM_INLINE, _component.DownStreamInlineMode);
                _main.MelsecNetBitOnOff(OB_LINK_DOWN1_DOWNSTREAM_TROUBLE, _component.GetDownstreamTrouble());
                _main.MelsecNetBitOnOff(OB_LINK_UP1_UPSTREAM_INLINE, _component.UpStreamInlineMode);
                _main.MelsecNetBitOnOff(OB_LINK_UP1_UPSTREAM_TROUBLE, _component.GetUpstreamTrouble());
                _main.MelsecNetBitOnOff(OB_LINK_UP1_EXCHANGE_POSSIBLE, _component.ExchangePossible);

                _main.MelsecNetBitOnOff(OB_LINK_DOWN1_SHUTTER_STATE, _component.EQP_Shutter_Open);
                _main.MelsecNetBitOnOff(OB_LINK_UP1_SHUTTER_STATE, _component.EQP_Shutter_Open);

                
                CSubject subject = CUIManager.Inst.GetData("ucCimStatus");
                //subject.SetValue("Status", "");
                subject.SetValue("BCConnection", _main.SystemConfig.BC_Connect);
                subject.SetValue("HostConnection", _main.SystemConfig.YANG_Communi && _main.GetClientConnected());
                subject.SetValue("ConnectionStatus", _main.Driver.GetStatus());
                subject.SetValue("EqpID", _main.SystemConfig.EQPID);
                //subject.SetValue("CIMMode", _component.CIMMode);
                //subject.SetValue("EqpControl", "");
                //subject.SetValue("EqpLink", connection);
                subject.SetValue("AutoMode", _component.MachineAutoMode);
                subject.SetValue("CIMConnectionMode", eqpOffline);
                subject.SetValue("EqpMode", _component.EquipmentMode);
                //subject.SetValue("UnitSkipMode", true);
                //subject.SetValue("RobotPitchMode", true);
                //subject.SetValue("CSTUnloadMode", true);
                subject.SetValue("AutoRecipeChange", _component.AutoRecipeMode);
                //subject.SetValue("CurrentPPID", "");
                //subject.SetValue("CurrentProdID", "");
                subject.Notify();

                string sss =  _main.Driver.GetStatus();

                List<string> linkSignal = new List<string>();

                linkSignal.Add(bool.Parse(OB_LINK_DOWN1_DOWNSTREAM_INLINE.Value).ToString());
                linkSignal.Add(bool.Parse(OB_LINK_DOWN1_DOWNSTREAM_TROUBLE.Value).ToString());
                linkSignal.Add(bool.Parse(OB_LINK_UP1_UPSTREAM_INLINE.Value).ToString());
                linkSignal.Add(bool.Parse(OB_LINK_UP1_UPSTREAM_TROUBLE.Value).ToString());
                linkSignal.Add(bool.Parse(OB_LINK_UP1_EXCHANGE_POSSIBLE.Value).ToString());

                subject = CUIManager.Inst.GetData("ucEQP");
                subject.SetValue("EQPNAME", _component.ControlName);
                subject.SetValue("EQPSTATUS", _component.EqpStatus.ToString());
                subject.SetValue("LRSTATUS", _component.LoadRequest);
                subject.SetValue("LR_ENABLE", _component.LoadEnable);
                subject.SetValue("URSTATUS", _component.UnloadRequest);
                subject.SetValue("UR_ENABLE", _component.UnloadEnable);
                subject.SetValue("RECIPE", _component.CurrentRecipeNo);
                subject.SetValue("LinkSignal", linkSignal);
                subject.Notify();

                subject = CUIManager.Inst.GetData("ucTitle");
                subject.SetValue("CIMMode", _component.CIMMode.ToString());
                subject.Notify();

                subject = CUIManager.Inst.GetData("frmConfig");
                subject.SetValue("Status", _main.Driver.GetStatus());
                subject.Notify();

                if (_main.LinkSignalMonitoring)
                {
                    List<string> stageList = new List<string>();

                    //1WORD
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_DOWNSTREAM_INLINE, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_DOWNSTREAM_TROUBLE, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_HAND_INTERFERENCE, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_JOB_TRANSFER_SIGNAL, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_RECEIVE_ABLE, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_RECEIVE_START, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_RECEIVE_COMPLETE, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_EXCHANGE_EXECUTE, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_CONVEYER_STATE, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_SHUTTER_STATE, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_DOUBLE_PITCH, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_FOUR_GLASSES, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_RESERVED1, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_EXCHANGE_CANCEL_RECEIVE, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_RECEIVE_READY, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_RESERVED2, 1).ToString());
                    //1WORD
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_CHK_AVAILABLE, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_CHK_LIFT_UP_OR_PIN_UP, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_CHK_LIFT_DOWN_OR_PIN_DOWN, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_CHK_STOPPER_UP_OR_DOOR_OPEN, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_CHK_STOPPER_DOWN_OR_DOOR_CLOSE, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_CHK_MANUAL_OPERATION, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_CHK_BODY_MOVING, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_CHK_COMPLETE, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_CHK_GLASS_EXIST_ARM1, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_CHK_GLASS_EXIST_ARM2, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_CHK_GLASS_EXIST_ARM3, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_CHK_GLASS_EXIST_ARM4, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_CHK_RESERVED1, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_CHK_RESERVED2, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_CHK_RESERVED3, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_CHK_RESERVED4, 1).ToString());
                    //1WORD
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_UPSTREAM_INLINE , 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_UPSTREAM_TROUBLE , 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_HAND_INTERFERENCE , 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_JOB_TRANSFER_SIGNAL , 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_SEND_ABLE , 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_SEND_START , 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_SEND_COMPLETE , 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_EXCHANGE_POSSIBLE , 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_CONVEYER_STATE , 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_SHUTTER_STATE , 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_JOB_TRANSFER_SIGNAL2, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_DOUBLE_PITCH , 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_FOUR_GLASSES , 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_HAND2_INTERFERENCE, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_SEND_READY , 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_HALFGLASSFLAG, 1).ToString());
                    //1WORD
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_CHK_AVAILABLE , 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_CHK_LIFT_UP_OR_PIN_UP , 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_CHK_LIFT_DOWN_OR_PIN_DOWN , 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_CHK_STOPPER_UP_OR_DOOR_OPEN , 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_CHK_STOPPER_DOWN_OR_DOOR_CLOSE , 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_CHK_MANUAL_OPERATION , 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_CHK_BODY_MOVING , 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_CHK_COMPLETE , 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_CHK_GLASS_EXIST_ARM1 , 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_CHK_GLASS_EXIST_ARM2 , 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_CHK_GLASS_EXIST_ARM3 , 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_CHK_GLASS_EXIST_ARM4 , 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_CHK_RESERVED1 , 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_CHK_RESERVED2 , 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_CHK_RESERVED3 , 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_CHK_RESERVED4 , 1).ToString());

                    List<string> robotList = new List<string>();
                    //1WORD
                    robotList.Add(IB_LINK_UP1_UPSTREAM_INLINE.Value.ToString());
                    robotList.Add(IB_LINK_UP1_UPSTREAM_TROUBLE.Value.ToString());
                    robotList.Add(IB_LINK_UP1_HAND_INTERFERENCE.Value.ToString());
                    robotList.Add(IB_LINK_UP1_JOB_TRANSFER_SIGNAL.Value.ToString());
                    robotList.Add(IB_LINK_UP1_SEND_ABLE.Value.ToString());
                    robotList.Add(IB_LINK_UP1_SEND_START.Value.ToString());
                    robotList.Add(IB_LINK_UP1_SEND_COMPLETE.Value.ToString());
                    robotList.Add(IB_LINK_UP1_EXCHANGE_POSSIBLE.Value.ToString());
                    robotList.Add(IB_LINK_UP1_CONVEYER_STATE.Value.ToString());
                    robotList.Add(IB_LINK_UP1_SHUTTER_STATE.Value.ToString());
                    robotList.Add(IB_LINK_UP1_JOB_TRANSFER_SIGNAL2.Value.ToString());
                    robotList.Add(IB_LINK_UP1_DOUBLE_PITCH.Value.ToString());
                    robotList.Add(IB_LINK_UP1_FOUR_GLASSES.Value.ToString());
                    robotList.Add(IB_LINK_UP1_HAND2_INTERFERENCE.Value.ToString());
                    robotList.Add(IB_LINK_UP1_SEND_READY.Value.ToString());
                    robotList.Add(IB_LINK_UP1_HALFGLASSFLAG.Value.ToString());
                    //1WORD
                    robotList.Add(IB_LINK_UP1_CHK_AVAILABLE.Value.ToString());
                    robotList.Add(IB_LINK_UP1_CHK_LIFT_UP_OR_PIN_UP.Value.ToString());
                    robotList.Add(IB_LINK_UP1_CHK_LIFT_DOWN_OR_PIN_DOWN.Value.ToString());
                    robotList.Add(IB_LINK_UP1_CHK_STOPPER_UP_OR_DOOR_OPEN.Value.ToString());
                    robotList.Add(IB_LINK_UP1_CHK_STOPPER_DOWN_OR_DOOR_CLOSE.Value.ToString());
                    robotList.Add(IB_LINK_UP1_CHK_MANUAL_OPERATION.Value.ToString());
                    robotList.Add(IB_LINK_UP1_CHK_BODY_MOVING.Value.ToString());
                    robotList.Add(IB_LINK_UP1_CHK_COMPLETE.Value.ToString());
                    robotList.Add(IB_LINK_UP1_CHK_GLASS_EXIST_ARM1.Value.ToString());
                    robotList.Add(IB_LINK_UP1_CHK_GLASS_EXIST_ARM2.Value.ToString());
                    robotList.Add(IB_LINK_UP1_CHK_GLASS_EXIST_ARM3.Value.ToString());
                    robotList.Add(IB_LINK_UP1_CHK_GLASS_EXIST_ARM4.Value.ToString());
                    robotList.Add(IB_LINK_UP1_CHK_RESERVED1.Value.ToString());
                    robotList.Add(IB_LINK_UP1_CHK_RESERVED2.Value.ToString());
                    robotList.Add(IB_LINK_UP1_CHK_RESERVED3.Value.ToString());
                    robotList.Add(IB_LINK_UP1_CHK_RESERVED4.Value.ToString());
                    //1WORD
                    robotList.Add(IB_LINK_DOWN1_DOWNSTREAM_INLINE.Value.ToString());
                    robotList.Add(IB_LINK_DOWN1_DOWNSTREAM_TROUBLE.Value.ToString());
                    robotList.Add(IB_LINK_DOWN1_HAND_INTERFERENCE.Value.ToString());
                    robotList.Add(IB_LINK_DOWN1_JOB_TRANSFER_SIGNAL.Value.ToString());
                    robotList.Add(IB_LINK_DOWN1_RECEIVE_ABLE.Value.ToString());
                    robotList.Add(IB_LINK_DOWN1_RECEIVE_START.Value.ToString());
                    robotList.Add(IB_LINK_DOWN1_RECEIVE_COMPLETE.Value.ToString());
                    robotList.Add(IB_LINK_DOWN1_EXCHANGE_EXECUTE.Value.ToString());
                    robotList.Add(IB_LINK_DOWN1_CONVEYER_STATE.Value.ToString());
                    robotList.Add(IB_LINK_DOWN1_SHUTTER_STATE.Value.ToString());
                    robotList.Add(IB_LINK_DOWN1_DOUBLE_PITCH.Value.ToString());
                    robotList.Add(IB_LINK_DOWN1_FOUR_GLASSES.Value.ToString());
                    robotList.Add(IB_LINK_DOWN1_RESERVED1.Value.ToString());
                    robotList.Add(IB_LINK_DOWN1_EXCHANGE_CANCEL_RECEIVE.Value.ToString());
                    robotList.Add(IB_LINK_DOWN1_RECEIVE_READY.Value.ToString());
                    robotList.Add(IB_LINK_DOWN1_RESERVED2.Value.ToString());
                    //1WORD
                    robotList.Add(IB_LINK_DOWN1_CHK_AVAILABLE.Value.ToString());
                    robotList.Add(IB_LINK_DOWN1_CHK_LIFT_UP_OR_PIN_UP.Value.ToString());
                    robotList.Add(IB_LINK_DOWN1_CHK_LIFT_DOWN_OR_PIN_DOWN.Value.ToString());
                    robotList.Add(IB_LINK_DOWN1_CHK_STOPPER_UP_OR_DOOR_OPEN.Value.ToString());
                    robotList.Add(IB_LINK_DOWN1_CHK_STOPPER_DOWN_OR_DOOR_CLOSE.Value.ToString());
                    robotList.Add(IB_LINK_DOWN1_CHK_MANUAL_OPERATION.Value.ToString());
                    robotList.Add(IB_LINK_DOWN1_CHK_BODY_MOVING.Value.ToString());
                    robotList.Add(IB_LINK_DOWN1_CHK_COMPLETE.Value.ToString());
                    robotList.Add(IB_LINK_DOWN1_CHK_GLASS_EXIST_ARM1.Value.ToString());
                    robotList.Add(IB_LINK_DOWN1_CHK_GLASS_EXIST_ARM2.Value.ToString());
                    robotList.Add(IB_LINK_DOWN1_CHK_GLASS_EXIST_ARM3.Value.ToString());
                    robotList.Add(IB_LINK_DOWN1_CHK_GLASS_EXIST_ARM4.Value.ToString());
                    robotList.Add(IB_LINK_DOWN1_CHK_RESERVED1.Value.ToString());
                    robotList.Add(IB_LINK_DOWN1_CHK_RESERVED2.Value.ToString());
                    robotList.Add(IB_LINK_DOWN1_CHK_RESERVED3.Value.ToString());
                    robotList.Add(IB_LINK_DOWN1_CHK_RESERVED4.Value.ToString());
                    
                    CSubject subject2 = CUIManager.Inst.GetData("LINKSIGNAL");
                    subject2.SetValue("StageList", stageList);
                    subject2.SetValue("RobotList", robotList);
                    subject2.Notify();
                }
                _main.LinkSignalCheck();
                Thread.Sleep(_interval);
            }
        }
        public override string SIteName
        {
            get { return "WHTM"; }
        }

        public override bool IsAsyncCall
        {
            get { return false; }
        }
        protected override int InnerExecute()
        {
            throw new NotImplementedException();
        }
    }
}
