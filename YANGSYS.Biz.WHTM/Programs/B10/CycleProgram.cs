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
    public class CycleProgram : AProgram
    {
        private CMain _main = null;
        private bool _enable = false;

        private CPLCControlProperties OB_RUNNING = null;
        private CPLCControlProperties OB_CIM_MODE = null;
        private CPLCControlProperties OB_MACHINE_AUTO_MODE = null;
        private CPLCControlProperties OB_MACHINE_HEARTBEAT_SIGNAL = null;
        private CPLCControlProperties OB_AUTO_RECIPE_CHANGE_MODE = null;
        private CPLCControlProperties OB_LINK_DOWN1_DOWNSTREAM_INLINE = null;
        private CPLCControlProperties OB_LINK_UP1_UPSTREAM_INLINE = null;

        private CPLCControlProperties OB_LINK_DOWN1_DOWNSTREAM_TROUBLE = null;
        private CPLCControlProperties OB_LINK_UP1_UPSTREAM_TROUBLE = null;

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

        private CPLCControlProperties OB_LINK_UP1_SLOT_NUMBER1 = null;
        private CPLCControlProperties OB_LINK_UP1_SLOT_NUMBER2 = null;
        private CPLCControlProperties OB_LINK_UP1_SLOT_NUMBER3 = null;
        private CPLCControlProperties OB_LINK_UP1_SLOT_NUMBER4 = null;
        private CPLCControlProperties OB_LINK_UP1_SLOT_NUMBER5 = null;
        private CPLCControlProperties OB_LINK_UP1_SLOT_PAIR_FLAG = null;
        private CPLCControlProperties OB_LINK_UP1_ARM_SLOT_PAIR_FLAG = null;
        private CPLCControlProperties OB_LINK_UP1_JOB_TRANSFER_SIGNAL = null;
        private CPLCControlProperties OB_LINK_UP1_RECEIVE_ABLE = null;
        private CPLCControlProperties OB_LINK_UP1_RECEIVE_START = null;
        private CPLCControlProperties OB_LINK_UP1_RECEIVE_COMPLETE = null;
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


        private Thread _thread = null;
        private string _controlName = "";
        private CProbeControl _component = null;
        private CIndexerControl _indexer = null;
        public CycleProgram()
        {

        }
        public override int Init()
        {
            _enable = true;

            OB_RUNNING = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_RUNNING");
            OB_CIM_MODE = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_CIM_MODE");
            OB_MACHINE_AUTO_MODE = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_MACHINE_AUTO_MODE");
            OB_AUTO_RECIPE_CHANGE_MODE = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_AUTO_RECIPE_CHANGE_MODE");

            OB_LINK_DOWN1_DOWNSTREAM_INLINE = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LINK_DOWN1_DOWNSTREAM_INLINE");
            OB_LINK_DOWN1_DOWNSTREAM_TROUBLE = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LINK_DOWN1_DOWNSTREAM_TROUBLE");
            OB_LINK_DOWN1_SLOT_NUMBER1 = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LINK_DOWN1_SLOT_NUMBER1");
            OB_LINK_DOWN1_SLOT_NUMBER2 = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LINK_DOWN1_SLOT_NUMBER2");
            OB_LINK_DOWN1_SLOT_NUMBER3 = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LINK_DOWN1_SLOT_NUMBER3");
            OB_LINK_DOWN1_SLOT_NUMBER4 = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LINK_DOWN1_SLOT_NUMBER4");
            OB_LINK_DOWN1_SLOT_NUMBER5 = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LINK_DOWN1_SLOT_NUMBER5");
            OB_LINK_DOWN1_SLOT_PAIR_FLAG = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LINK_DOWN1_SLOT_PAIR_FLAG");
            OB_LINK_DOWN1_ARM_SLOT_PAIR_FLAG = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LINK_DOWN1_ARM_SLOT_PAIR_FLAG");
            OB_LINK_DOWN1_JOB_TRANSFER_SIGNAL = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LINK_DOWN1_JOB_TRANSFER_SIGNAL");
            OB_LINK_DOWN1_RECEIVE_ABLE = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LINK_DOWN1_RECEIVE_ABLE");
            OB_LINK_DOWN1_RECEIVE_START = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LINK_DOWN1_RECEIVE_START");
            OB_LINK_DOWN1_RECEIVE_COMPLETE = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LINK_DOWN1_RECEIVE_COMPLETE");
            OB_LINK_DOWN1_EXCHANGE_POSSIBLE = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LINK_DOWN1_EXCHANGE_POSSIBLE");
            OB_LINK_DOWN1_EXCHANGE_EXECUTE = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LINK_DOWN1_EXCHANGE_EXECUTE");
            OB_LINK_DOWN1_RESUME_REQUEST = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LINK_DOWN1_RESUME_REQUEST");
            OB_LINK_DOWN1_RESUME_ACK = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LINK_DOWN1_RESUME_ACK");
            OB_LINK_DOWN1_CANCEL_REQUEST = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LINK_DOWN1_CANCEL_REQUEST");
            OB_LINK_DOWN1_CANCEL_ACK = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LINK_DOWN1_CANCEL_ACK");
            OB_LINK_DOWN1_ABORT_REQUEST = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LINK_DOWN1_ABORT_REQUEST");
            OB_LINK_DOWN1_ABORT_ACK = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LINK_DOWN1_ABORT_ACK");
            OB_LINK_DOWN1_CONVEYER_STATE = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LINK_DOWN1_CONVEYER_STATE");
            OB_LINK_DOWN1_SHUTTER_STATE = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LINK_DOWN1_SHUTTER_STATE");
            OB_LINK_DOWN1_FIRST_SLOT_EXIST = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LINK_DOWN1_FIRST_SLOT_EXIST");
            OB_LINK_DOWN1_SECOND_SLOT_EXIST = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LINK_DOWN1_SECOND_SLOT_EXIST");
            OB_LINK_DOWN1_THIRD_SLOT_EXIST = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LINK_DOWN1_THIRD_SLOT_EXIST");
            OB_LINK_DOWN1_FOURTH_SLOT_EXIST = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LINK_DOWN1_FOURTH_SLOT_EXIST");

            OB_LINK_UP1_UPSTREAM_INLINE = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LINK_UP1_UPSTREAM_INLINE");
            OB_LINK_UP1_UPSTREAM_TROUBLE = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LINK_UP1_UPSTREAM_TROUBLE");
            OB_LINK_UP1_SLOT_NUMBER1 = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LINK_UP1_SLOT_NUMBER1");
            OB_LINK_UP1_SLOT_NUMBER2 = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LINK_UP1_SLOT_NUMBER2");
            OB_LINK_UP1_SLOT_NUMBER3 = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LINK_UP1_SLOT_NUMBER3");
            OB_LINK_UP1_SLOT_NUMBER4 = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LINK_UP1_SLOT_NUMBER4");
            OB_LINK_UP1_SLOT_NUMBER5 = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LINK_UP1_SLOT_NUMBER5");
            OB_LINK_UP1_SLOT_PAIR_FLAG = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LINK_UP1_SLOT_PAIR_FLAG");
            OB_LINK_UP1_ARM_SLOT_PAIR_FLAG = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LINK_UP1_ARM_SLOT_PAIR_FLAG");
            OB_LINK_UP1_JOB_TRANSFER_SIGNAL = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LINK_UP1_JOB_TRANSFER_SIGNAL");
            OB_LINK_UP1_RECEIVE_ABLE = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LINK_UP1_SEND_ABLE");
            OB_LINK_UP1_RECEIVE_START = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LINK_UP1_SEND_START");
            OB_LINK_UP1_RECEIVE_COMPLETE = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LINK_UP1_SEND_COMPLETE");
            OB_LINK_UP1_EXCHANGE_POSSIBLE = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LINK_UP1_EXCHANGE_POSSIBLE");
            OB_LINK_UP1_EXCHANGE_EXECUTE = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LINK_UP1_EXCHANGE_EXECUTE");
            OB_LINK_UP1_RESUME_REQUEST = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LINK_UP1_RESUME_REQUEST");
            OB_LINK_UP1_RESUME_ACK = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LINK_UP1_RESUME_ACK");
            OB_LINK_UP1_CANCEL_REQUEST = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LINK_UP1_CANCEL_REQUEST");
            OB_LINK_UP1_CANCEL_ACK = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LINK_UP1_CANCEL_ACK");
            OB_LINK_UP1_ABORT_REQUEST = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LINK_UP1_ABORT_REQUEST");
            OB_LINK_UP1_ABORT_ACK = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LINK_UP1_ABORT_ACK");
            OB_LINK_UP1_CONVEYER_STATE = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LINK_UP1_CONVEYER_STATE");
            OB_LINK_UP1_SHUTTER_STATE = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LINK_UP1_SHUTTER_STATE");
            OB_LINK_UP1_FIRST_SLOT_EXIST = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LINK_UP1_FIRST_SLOT_EXIST");
            OB_LINK_UP1_SECOND_SLOT_EXIST = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LINK_UP1_SECOND_SLOT_EXIST");
            OB_LINK_UP1_THIRD_SLOT_EXIST = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LINK_UP1_THIRD_SLOT_EXIST");
            OB_LINK_UP1_FOURTH_SLOT_EXIST = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_LINK_UP1_FOURTH_SLOT_EXIST");

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
            IB_LINK_UP_THIRD_SLOT_EXIST = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP_THIRD_SLOT_EXIST");
            IB_LINK_UP_FOURTH_SLOT_EXIST = _main.SCANCONTEROLS.GetProperty(_indexer.ControlName, "IB_LINK_UP_FOURTH_SLOT_EXIST");

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


            _component.ProgramsAdd(this);
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
                _main.MelsecNetBitOnOff(OB_RUNNING, true);//_component.Running);
                _main.MelsecNetBitOnOff(OB_CIM_MODE, _component.CIMMode == 2);

                bool eqpOffline = false;
                if (_component.Communication)
                {
                    if (_component.Alive)
                    {
                        _aliveCount = 0;
                        _component.Alive = false;
                        eqpOffline = true;
                    }
                    else
                    {
                        if (_aliveCount > 5)
                        {
                            _aliveCount = 0;
                            eqpOffline = false;
                            //OFFLINE으로 간주..
                        }
                        else
                        {
                            eqpOffline = true;
                            _aliveCount++;
                        }
                    }
                }
                else
                {
                    _component.Alive = false;
                    eqpOffline = false;
                }

                CSubject subject = CUIManager.Inst.GetData("ucCimStatus");
                //subject.SetValue("Status", "");
                subject.SetValue("HostConnection", _component.Communication);
                
                //subject.SetValue("EqpControl", "");
                //subject.SetValue("EqpLink", connection);
                subject.SetValue("AutoMode", _component.MachineAutoMode);
                //subject.SetValue("InlineLinkMode", "");
                subject.SetValue("CIMConnectionMode", eqpOffline);
                subject.SetValue("EqpMode", _component.EquipmentMode);
                //subject.SetValue("UnitSkipMode", true);
                //subject.SetValue("RobotPitchMode", true);
                //subject.SetValue("CSTUnloadMode", true);
                subject.SetValue("AutoRecipeChange", _component.AutoRecipeMode);
                //subject.SetValue("CurrentPPID", "");
                //subject.SetValue("CurrentProdID", "");
                subject.Notify();

                subject = CUIManager.Inst.GetData("ucEQP");
                subject.SetValue("EQPNAME", _component.ControlName);
                subject.SetValue("EQPSTATUS", _component.EqpStatus.ToString());
                subject.SetValue("LRSTATUS", _component.LoadRequest);
                subject.SetValue("LR_ENABLE", _component.LoadEnable);
                subject.SetValue("URSTATUS", _component.UnloadRequest);
                subject.SetValue("UR_ENABLE", _component.UnloadEnable);
                subject.SetValue("RECIPE", _component.CurrentRecipeNo);
                subject.Notify();

                subject = CUIManager.Inst.GetData("ucTitle");
                subject.SetValue("CIMMode", _component.CIMMode);
                subject.Notify();

                _main.MelsecNetBitOnOff(OB_MACHINE_AUTO_MODE, _component.MachineAutoMode);
                _main.MelsecNetBitOnOff(OB_AUTO_RECIPE_CHANGE_MODE, _component.AutoRecipeMode);

                _main.MelsecNetBitOnOff(OB_LINK_DOWN1_DOWNSTREAM_INLINE, true);
                _main.MelsecNetBitOnOff(OB_LINK_DOWN1_DOWNSTREAM_TROUBLE, false);

                _main.MelsecNetBitOnOff(OB_LINK_UP1_UPSTREAM_INLINE, true);
                _main.MelsecNetBitOnOff(OB_LINK_UP1_UPSTREAM_TROUBLE, false);

                if (_main.LinkSignalMonitoring)
                {
                    CSubject subject2 = CUIManager.Inst.GetData("LINKSIGNAL");
                    List<string> stageList = new List<string>();

                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_DOWNSTREAM_INLINE, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_DOWNSTREAM_TROUBLE, 1).ToString());
                    //stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_SLOT_NUMBER1, 1).ToString());
                    //stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_SLOT_NUMBER2, 1).ToString());
                    //stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_SLOT_NUMBER3, 1).ToString());
                    //stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_SLOT_NUMBER4, 1).ToString());
                    //stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_SLOT_NUMBER5, 1).ToString());
                    //stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_SLOT_PAIR_FLAG, 1).ToString());
                    //stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_ARM_SLOT_PAIR_FLAG, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_JOB_TRANSFER_SIGNAL, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_RECEIVE_ABLE, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_RECEIVE_START, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_RECEIVE_COMPLETE, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_EXCHANGE_POSSIBLE, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_EXCHANGE_EXECUTE, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_RESUME_REQUEST, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_RESUME_ACK, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_CANCEL_REQUEST, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_CANCEL_ACK, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_ABORT_REQUEST, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_ABORT_ACK, 1).ToString());
                    //stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_CONVEYER_STATE, 1).ToString());
                    //stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_SHUTTER_STATE, 1).ToString());
                    //stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_FIRST_SLOT_EXIST, 1).ToString());
                    //stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_SECOND_SLOT_EXIST, 1).ToString());
                    //stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_THIRD_SLOT_EXIST, 1).ToString());
                    //stageList.Add(_main.MelsecNetBitRead(OB_LINK_DOWN1_FOURTH_SLOT_EXIST, 1).ToString());

                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_UPSTREAM_INLINE, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_UPSTREAM_TROUBLE, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_SLOT_NUMBER1, 1).ToString());
                    //stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_SLOT_NUMBER2, 1).ToString());
                    //stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_SLOT_NUMBER3, 1).ToString());
                    //stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_SLOT_NUMBER4, 1).ToString());
                    //stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_SLOT_NUMBER5, 1).ToString());
                    //stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_SLOT_PAIR_FLAG, 1).ToString());
                    //stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_ARM_SLOT_PAIR_FLAG, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_JOB_TRANSFER_SIGNAL, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_RECEIVE_ABLE, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_RECEIVE_START, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_RECEIVE_COMPLETE, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_EXCHANGE_POSSIBLE, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_EXCHANGE_EXECUTE, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_RESUME_REQUEST, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_RESUME_ACK, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_CANCEL_REQUEST, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_CANCEL_ACK, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_ABORT_REQUEST, 1).ToString());
                    stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_ABORT_ACK, 1).ToString());
                    //stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_CONVEYER_STATE, 1).ToString());
                    //stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_SHUTTER_STATE, 1).ToString());
                    //stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_FIRST_SLOT_EXIST, 1).ToString());
                    //stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_SECOND_SLOT_EXIST, 1).ToString());
                    //stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_THIRD_SLOT_EXIST, 1).ToString());
                    //stageList.Add(_main.MelsecNetBitRead(OB_LINK_UP1_FOURTH_SLOT_EXIST, 1).ToString());

                    List<string> robotList = new List<string>();
                    robotList.Add(_main.MelsecNetBitRead(IB_LINK_UP_UPSTREAM_INLINE, 1).ToString());
                    robotList.Add(_main.MelsecNetBitRead(IB_LINK_UP_UPSTREAM_TROUBLE, 1).ToString());
                    //robotList.Add(_main.MelsecNetBitRead(IB_LINK_UP_SLOT_NUMBER1, 1).ToString());
                    //robotList.Add(_main.MelsecNetBitRead(IB_LINK_UP_SLOT_NUMBER2, 1).ToString());
                    //robotList.Add(_main.MelsecNetBitRead(IB_LINK_UP_SLOT_NUMBER3, 1).ToString());
                    //robotList.Add(_main.MelsecNetBitRead(IB_LINK_UP_SLOT_NUMBER4, 1).ToString());
                    //robotList.Add(_main.MelsecNetBitRead(IB_LINK_UP_SLOT_NUMBER5, 1).ToString());
                    //robotList.Add(_main.MelsecNetBitRead(IB_LINK_UP_SLOT_PAIR_FLAG, 1).ToString());
                    //robotList.Add(_main.MelsecNetBitRead(IB_LINK_UP_ARM_SLOT_PAIR_FLAG, 1).ToString());
                    robotList.Add(_main.MelsecNetBitRead(IB_LINK_UP_JOB_TRANSFER_SIGNAL, 1).ToString());
                    robotList.Add(_main.MelsecNetBitRead(IB_LINK_UP_SEND_ABLE, 1).ToString());
                    robotList.Add(_main.MelsecNetBitRead(IB_LINK_UP_SEND_START, 1).ToString());
                    robotList.Add(_main.MelsecNetBitRead(IB_LINK_UP_SEND_COMPLETE, 1).ToString());
                    robotList.Add(_main.MelsecNetBitRead(IB_LINK_UP_EXCHANGE_POSSIBLE, 1).ToString());
                    robotList.Add(_main.MelsecNetBitRead(IB_LINK_UP_EXCHANGE_EXECUTE, 1).ToString());
                    robotList.Add(_main.MelsecNetBitRead(IB_LINK_UP_RESUME_REQUEST, 1).ToString());
                    robotList.Add(_main.MelsecNetBitRead(IB_LINK_UP_RESUME_ACK, 1).ToString());
                    robotList.Add(_main.MelsecNetBitRead(IB_LINK_UP_CANCEL_REQUEST, 1).ToString());
                    robotList.Add(_main.MelsecNetBitRead(IB_LINK_UP_CANCEL_ACK, 1).ToString());
                    robotList.Add(_main.MelsecNetBitRead(IB_LINK_UP_ABORT_REQUEST, 1).ToString());
                    robotList.Add(_main.MelsecNetBitRead(IB_LINK_UP_ABOR_ACK, 1).ToString());
                    //robotList.Add(_main.MelsecNetBitRead(IB_LINK_UP_CONVEYER_STATE, 1).ToString());
                    //robotList.Add(_main.MelsecNetBitRead(IB_LINK_UP_SHUTTER_STATE, 1).ToString());
                    //robotList.Add(_main.MelsecNetBitRead(IB_LINK_UP_THIRD_SLOT_EXIST, 1).ToString());
                    //robotList.Add(_main.MelsecNetBitRead(IB_LINK_UP_FOURTH_SLOT_EXIST, 1).ToString());

                    robotList.Add(_main.MelsecNetBitRead(IB_LINK_DOWN_DOWNSTREAM_INLINE, 1).ToString());
                    robotList.Add(_main.MelsecNetBitRead(IB_LINK_DOWN_DOWNSTREAM_TROUBLE, 1).ToString());
                    //robotList.Add(_main.MelsecNetBitRead(IB_LINK_DOWN_SLOT_NUMBER1, 1).ToString());
                    //robotList.Add(_main.MelsecNetBitRead(IB_LINK_DOWN_SLOT_NUMBER2, 1).ToString());
                    //robotList.Add(_main.MelsecNetBitRead(IB_LINK_DOWN_SLOT_NUMBER3, 1).ToString());
                    //robotList.Add(_main.MelsecNetBitRead(IB_LINK_DOWN_SLOT_NUMBER4, 1).ToString());
                    //robotList.Add(_main.MelsecNetBitRead(IB_LINK_DOWN_SLOT_NUMBER5, 1).ToString());
                    //robotList.Add(_main.MelsecNetBitRead(IB_LINK_DOWN_SLOT_PAIR_FLAG, 1).ToString());
                    //robotList.Add(_main.MelsecNetBitRead(IB_LINK_DOWN_ARM_SLOT_PAIR_FLAG, 1).ToString());
                    robotList.Add(_main.MelsecNetBitRead(IB_LINK_DOWN_JOB_TRANSFER_SIGNAL, 1).ToString());
                    robotList.Add(_main.MelsecNetBitRead(IB_LINK_DOWN_RECEIVE_ABLE, 1).ToString());
                    robotList.Add(_main.MelsecNetBitRead(IB_LINK_DOWN_RECEIVE_START, 1).ToString());
                    robotList.Add(_main.MelsecNetBitRead(IB_LINK_DOWN_RECEIVE_COMPLETE, 1).ToString());
                    robotList.Add(_main.MelsecNetBitRead(IB_LINK_DOWN_EXCHANGE_POSSIBLE, 1).ToString());
                    robotList.Add(_main.MelsecNetBitRead(IB_LINK_DOWN_EXCHANGE_EXECUTE, 1).ToString());
                    robotList.Add(_main.MelsecNetBitRead(IB_LINK_DOWN_RESUME_REQUEST, 1).ToString());
                    robotList.Add(_main.MelsecNetBitRead(IB_LINK_DOWN_RESUME_ACK, 1).ToString());
                    robotList.Add(_main.MelsecNetBitRead(IB_LINK_DOWN_CANCEL_REQUEST, 1).ToString());
                    robotList.Add(_main.MelsecNetBitRead(IB_LINK_DOWN_CANCEL_ACK, 1).ToString());
                    robotList.Add(_main.MelsecNetBitRead(IB_LINK_DOWN_ABORT_REQUEST, 1).ToString());
                    robotList.Add(_main.MelsecNetBitRead(IB_LINK_DOWN_ABORT_ACK, 1).ToString());
                    //robotList.Add(_main.MelsecNetBitRead(IB_LINK_DOWN_CONVEYER_STATE, 1).ToString());
                    //robotList.Add(_main.MelsecNetBitRead(IB_LINK_DOWN_SHUTTER_STATE, 1).ToString());
                    //robotList.Add(_main.MelsecNetBitRead(IB_LINK_DOWN_FIRST_SLOT_EXIST, 1).ToString());
                    //robotList.Add(_main.MelsecNetBitRead(IB_LINK_DOWN_SECOND_SLOT_EXIST, 1).ToString());
                    //robotList.Add(_main.MelsecNetBitRead(IB_LINK_DOWN_THIRD_SLOT_EXIST, 1).ToString());
                    //robotList.Add(_main.MelsecNetBitRead(IB_LINK_DOWN_FOURTH_SLOT_EXIST, 1).ToString());	

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
            get { return "B10"; }
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
