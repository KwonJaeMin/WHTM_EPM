using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SOFD.Gui.PopUp;
using SOFD.Global.Manager;
using SOFD.Global.Interface;


namespace YANGSYS.UI.WHTM.FormSub
{
    public partial class frmLinkSignal : Form
    {
        public Timer _timer = new Timer();
        public frmLinkSignal()
        {
            InitializeComponent();
            Init();

            _timer.Interval = 500;
            _timer.Tick += new EventHandler(_timer_Tick);
        }

        void _timer_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void btnAllClear_Click(object sender, EventArgs e)
        {

        }

        private void btnBuzzerOff_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmLinkSignal_VisibleChanged(object sender, EventArgs e)
        {
            _timer.Enabled = this.Visible;

            ACommand command = CUIManager.Inst.GetCommand("REQUEST");
            command.SubCommandName = "LINK_SIGNAL_UPDATE";
            command.AddParameter("UPDATE", this.Visible.ToString());
            command.Execute();
        }

        #region LinkSignal
        private class CListData
        {
            public List<string> RobotList { get; set; }
            public List<string> StageList { get; set; }
            public CListData()
            {
                RobotList = new List<string>();
                StageList = new List<string>();
            }
            public bool SetValue<T>(string key, T value)
            {
                return true;
            }
        }
        private CListData _messageData = new CListData();
        CUpdateHandler<CListData> UpdateMessageHandler = null;
        private delegate void UpdateHandler2();
        public bool Init()
        {
            //base.Init();
            UpdateMessageHandler = new CUpdateHandler<CListData>(this, "LINKSIGNAL", ref _messageData);
            UpdateMessageHandler.OnUpdateData = new CUpdateHandler<CListData>.UpdateDataHandler(InvokeUpdateMessageData);
            UpdateMessageHandler.Subscribe();
            return true;
        }
        private void InvokeUpdateMessageData(bool noHandle, CListData linksignals)
        {
            if (linksignals == null || !this.IsHandleCreated)
                return;

            UpdateMessageHandler.Data = linksignals;
            //if (noHandle == false)

            //{
            if (this.InvokeRequired)
            {
                this.Invoke(UpdateMessageHandler.OnUpdateData, noHandle, linksignals);
            }
            else
            {
                UpdateHandler2 del = new UpdateHandler2(UpdateSignal);
                this.Invoke(del);
            }
            //}
        }


        private void UpdateSignal()
        {

        }
        #endregion

        private void StageLinkSignaOnOff_Click(object sender, EventArgs e)
        {
            Control control = sender as Control;
            if (control.Tag == null)
                return;
            ACommand command = CUIManager.Inst.GetCommand("REQUEST");
            command.SubCommandName = "STAGE_LINK_SIGNAL_ON/OFF";
            command.AddParameter("SIGNAL_NAME", control.Tag.ToString());
            command.Execute();
        }

        private void frmLinkSignal_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void btnInitIF_Click(object sender, EventArgs e)
        {
            ACommand command = CUIManager.Inst.GetCommand("REQUEST");
            command.SubCommandName = "STAGE_LINK_SIGNAL_INIT";
            command.Execute();
        }
        private const int ROBOT_UP_INDEX = 0;
        private const int ROBOT_DOWN_INDEX = 64;
        private const int STAGE_UP_INDEX = 0;
        private const int STAGE_DOWN_INDEX = 64;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);


            #region LinkType1
            int robotIndex = ROBOT_UP_INDEX;
            #region ROBOT UPSTREAM
            if (_messageData.RobotList.Count > 0)
            {
                lblType1UpStreamInline.BackColor = _messageData.RobotList[robotIndex++] == "True" ? Color.Lime : lblRobot.BackColor;
                lblType1UpStreamTrouble.BackColor = _messageData.RobotList[robotIndex++] == "True" ? Color.Lime : lblRobot.BackColor;
                lblType1HandInterfaceOn.BackColor = _messageData.RobotList[robotIndex] == "True" ? Color.Lime : lblRobot.BackColor;//IB_LINK_UP1_HAND_INTERFERENCE
                lblType1HandInterfaceOff.BackColor = _messageData.RobotList[robotIndex++] == "False" ? Color.Lime : lblRobot.BackColor;
                lblType1JobTransferSignalOn.BackColor = _messageData.RobotList[robotIndex] == "True" ? Color.Lime : lblRobot.BackColor;
                lblType1JobTransferSignalOff.BackColor = _messageData.RobotList[robotIndex++] == "False" ? Color.Red : lblRobot.BackColor;
                lblType1SendAbleOn.BackColor = _messageData.RobotList[robotIndex] == "True" ? Color.Lime : lblRobot.BackColor;
                lblType1SendAbleOff.BackColor = _messageData.RobotList[robotIndex++] == "False" ? Color.Red : lblRobot.BackColor;
                lblType1SendStartOn.BackColor = _messageData.RobotList[robotIndex] == "True" ? Color.Lime : lblRobot.BackColor;
                lblType1SendStartOff.BackColor = _messageData.RobotList[robotIndex++] == "False" ? Color.Red : lblRobot.BackColor;
                lblType1SendCompleteOn.BackColor = _messageData.RobotList[robotIndex] == "True" ? Color.Lime : lblRobot.BackColor;
                lblType1SendCompleteOff.BackColor = _messageData.RobotList[robotIndex++] == "False" ? Color.Red : lblRobot.BackColor;
                robotIndex++;//IB_LINK_UP1_EXCHANGE_POSSIBLE
                robotIndex++;//IB_LINK_UP1_CONVEYER_STATE
                lblType1ShutterStateOn.BackColor = _messageData.RobotList[robotIndex] == "True" ? Color.Lime : lblRobot.BackColor;
                lblType1ShutterStateOff.BackColor = _messageData.RobotList[robotIndex++] == "False" ? Color.Lime : lblRobot.BackColor;
                lblType1JobTransferSignal2On.BackColor = _messageData.RobotList[robotIndex] == "True" ? Color.Lime : lblRobot.BackColor;
                lblType1JobTransferSignal2Off.BackColor = _messageData.RobotList[robotIndex++] == "False" ? Color.Lime : lblRobot.BackColor;

                robotIndex++;//IB_LINK_UP1_DOUBLE_PITCH
                robotIndex++;//IB_LINK_UP1_FOUR_GLASSES
                lblType1Hand2InterfaceOn.BackColor = _messageData.RobotList[robotIndex] == "True" ? Color.Lime : lblRobot.BackColor;//IB_LINK_UP1_HAND2_INTERFERENCE
                lblType1Hand2InterfaceOff.BackColor = _messageData.RobotList[robotIndex++] == "False" ? Color.Lime : lblRobot.BackColor;
                robotIndex++;//IB_LINK_UP1_SEND_READY
                lblType1HalfGlassFlagOn.BackColor = _messageData.RobotList[robotIndex] == "True" ? Color.Lime : lblRobot.BackColor;//IB_LINK_UP1_HAND2_INTERFERENCE
                lblType1HalfGlassFlagOff.BackColor = _messageData.RobotList[robotIndex++] == "False" ? Color.Lime : lblRobot.BackColor;

            }
            #endregion
            int stageIndex = 0;
            #region STAGE DOWNSTREAM
            if (_messageData.StageList.Count > 0)
            {
                lblType1DownStreamInline.BackColor = _messageData.StageList[stageIndex++] == "True" ? Color.Lime : lblStage.BackColor;                
                lblType1DownStreamTrouble.BackColor = _messageData.StageList[stageIndex++] == "True" ? Color.Lime : lblStage.BackColor;
                stageIndex++;//OB_LINK_DOWN1_HAND_INTERFERENCE
                stageIndex++;//OB_LINK_DOWN1_JOB_TRANSFER_SIGNAL
                lblType1ReceiveAbleOn.BackColor = _messageData.StageList[stageIndex] == "True" ? Color.Lime : lblStage.BackColor;
                lblType1ReceiveAbleOff.BackColor = _messageData.StageList[stageIndex++] == "False" ? Color.Red : lblStage.BackColor;
                lblType1ReceiveStartOn.BackColor = _messageData.StageList[stageIndex] == "True" ? Color.Lime : lblStage.BackColor;
                lblType1ReceiveStartOff.BackColor = _messageData.StageList[stageIndex++] == "False" ? Color.Red : lblStage.BackColor;
                lblType1ReceiveCompleteOn.BackColor = _messageData.StageList[stageIndex] == "True" ? Color.Lime : lblStage.BackColor;
                lblType1ReceiveCompleteOff.BackColor = _messageData.StageList[stageIndex++] == "False" ? Color.Red : lblStage.BackColor;
                stageIndex++;//OB_LINK_DOWN1_EXCHANGE_EXECUTE
                stageIndex++;//OB_LINK_DOWN1_HAND_INTERFERENCE

                lblType1ShutterStateOn.BackColor = _messageData.StageList[stageIndex] == "True" ? Color.Lime : lblStage.BackColor;
                lblType1ShutterStateOff.BackColor = _messageData.StageList[stageIndex++] == "False" ? Color.Red : lblStage.BackColor;

                stageIndex++;//OB_LINK_DOWN1_HAND_INTERFERENCE
                stageIndex++;//OB_LINK_DOWN1_HAND_INTERFERENCE
                stageIndex++;//OB_LINK_DOWN1_HAND_INTERFERENCE
                stageIndex++;//OB_LINK_DOWN1_HAND_INTERFERENCE
                stageIndex++;//OB_LINK_DOWN1_HAND_INTERFERENCE
                stageIndex++;//OB_LINK_DOWN1_HAND_INTERFERENCE
            }
            #endregion
            #endregion

            #region LinkType5
            robotIndex += 16;
            #region ROBOT DOWNSTREAM
            if (_messageData.StageList.Count > 0)
            {
                lblType5DownstreamInline.BackColor = _messageData.RobotList[robotIndex++] == "True" ? Color.Lime : lblRobot.BackColor;
                lblType5DownstreamTrouble.BackColor = _messageData.RobotList[robotIndex++] == "True" ? Color.Lime : lblRobot.BackColor;
                robotIndex++;//OB_LINK_DOWN1_HAND_INTERFERENCE
                lblType5JobTransferSignalOn.BackColor = _messageData.RobotList[robotIndex] == "True" ? Color.Lime : lblRobot.BackColor;
                lblType5JobTransferSignalOff.BackColor = _messageData.RobotList[robotIndex++] == "False" ? Color.Red : lblRobot.BackColor;
                lblType5ReceiveAbleOn.BackColor = _messageData.RobotList[robotIndex] == "True" ? Color.Lime : lblRobot.BackColor;
                lblType5ReceiveAlbeOff.BackColor = _messageData.RobotList[robotIndex++] == "False" ? Color.Red : lblRobot.BackColor;
                lblType5ReceiveStartOn.BackColor = _messageData.RobotList[robotIndex] == "True" ? Color.Lime : lblRobot.BackColor;
                lblType5ReceiveStartOff.BackColor = _messageData.RobotList[robotIndex++] == "False" ? Color.Red : lblRobot.BackColor;
                lblType5ReceiveCompleteOn.BackColor = _messageData.RobotList[robotIndex] == "True" ? Color.Lime : lblRobot.BackColor;
                lblType5ReceiveCompleteOff.BackColor = _messageData.RobotList[robotIndex++] == "False" ? Color.Red : lblRobot.BackColor;

                robotIndex++;//OB_LINK_DOWN1_EXCHANGE_EXECUTE
                robotIndex++;//OB_LINK_DOWN1_HAND_INTERFERENCE
                robotIndex++;//OB_LINK_DOWN1_HAND_INTERFERENCE
                robotIndex++;//OB_LINK_DOWN1_HAND_INTERFERENCE
                robotIndex++;//OB_LINK_DOWN1_HAND_INTERFERENCE
                robotIndex++;//OB_LINK_DOWN1_HAND_INTERFERENCE
                robotIndex++;//OB_LINK_DOWN1_HAND_INTERFERENCE
                robotIndex++;//OB_LINK_DOWN1_HAND_INTERFERENCE
                robotIndex++;//OB_LINK_DOWN1_HAND_INTERFERENCE
            }
            #endregion
            stageIndex += 16;
            #region STAGE UPSTREAM
            if (_messageData.StageList.Count > 0)
            {
                lblType5UpstreamInline.BackColor = _messageData.StageList[stageIndex++] == "True" ? Color.Lime : lblRobot.BackColor;
                lblType5UpstreamTrouble.BackColor = _messageData.StageList[stageIndex++] == "True" ? Color.Lime : lblRobot.BackColor;
                stageIndex++;//IB_LINK_UP1_HAND_INTERFERENCE
                stageIndex++;

                lblType5SendAbleOn.BackColor = _messageData.StageList[stageIndex] == "True" ? Color.Lime : lblRobot.BackColor;
                lblType5SendAbleOff.BackColor = _messageData.StageList[stageIndex++] == "False" ? Color.Red : lblRobot.BackColor;
                lblType5SendStartOn.BackColor = _messageData.StageList[stageIndex] == "True" ? Color.Lime : lblRobot.BackColor;
                lblType5SendStartOff.BackColor = _messageData.StageList[stageIndex++] == "False" ? Color.Red : lblRobot.BackColor;
                lblType5SendCompleteOn.BackColor = _messageData.StageList[stageIndex] == "True" ? Color.Lime : lblRobot.BackColor;
                lblType5SendCompleteOff.BackColor = _messageData.StageList[stageIndex++] == "False" ? Color.Red : lblRobot.BackColor;
                stageIndex++;//IB_LINK_UP1_EXCHANGE_POSSIBLE
                stageIndex++;//IB_LINK_UP1_CONVEYER_STATE
                stageIndex++;//IB_LINK_UP1_SHUTTER_STATE
                stageIndex++;//IB_LINK_UP1_RESERVED1
                stageIndex++;//IB_LINK_UP1_DOUBLE_PITCH
                stageIndex++;//IB_LINK_UP1_FOUR_GLASSES
                stageIndex++;//IB_LINK_UP1_RESERVED2
                stageIndex++;//IB_LINK_UP1_SEND_READY
                stageIndex++;//IB_LINK_UP1_RESERVED3
            }
            #endregion
            #endregion

            #region LinkType10
            robotIndex = 0;
            stageIndex = 0;
            #region ROBOT UPSTREAM
            if (_messageData.RobotList.Count > 0)
            {
                lblType10IndexerUpstreamInlineOn.BackColor = _messageData.RobotList[robotIndex++] == "True" ? Color.Lime : lblRobot.BackColor;
                lblType10IndexerUpstreamTrobuleOn.BackColor = _messageData.RobotList[robotIndex++] == "True" ? Color.Lime : lblRobot.BackColor;
                robotIndex++;//IB_LINK_UP1_HAND_INTERFERENCE
                lblLinkSignal10IndexerJobTransSignalOn.BackColor = _messageData.RobotList[robotIndex++] == "True" ? Color.Lime : lblRobot.BackColor;
                label342.BackColor = _messageData.RobotList[robotIndex] == "False" ? Color.Red : lblRobot.BackColor;
                lblLinkSignal10IndexerSendAbleOn.BackColor = _messageData.RobotList[robotIndex] == "True" ? Color.Lime : lblRobot.BackColor;
                lblLinkSignal10IndexerSendAbleOff.BackColor = _messageData.RobotList[robotIndex++] == "False" ? Color.Red : lblRobot.BackColor;
                lblLinkSignal10IndexerSendStartOn.BackColor = _messageData.RobotList[robotIndex] == "True" ? Color.Lime : lblRobot.BackColor;
                lblLinkSignal10IndexerSendStartOff.BackColor = _messageData.RobotList[robotIndex++] == "False" ? Color.Red : lblRobot.BackColor;
                lblLinkSignal10IndexerSendCompleteOn.BackColor = _messageData.RobotList[robotIndex] == "True" ? Color.Lime : lblRobot.BackColor;
                lblLinkSignal10IndexerSendCompleteOff.BackColor = _messageData.RobotList[robotIndex++] == "False" ? Color.Red : lblRobot.BackColor;
                robotIndex++;//IB_LINK_UP1_EXCHANGE_POSSIBLE
                robotIndex++;//IB_LINK_UP1_CONVEYER_STATE
                robotIndex++;//IB_LINK_UP1_SHUTTER_STATE
                robotIndex++;//IB_LINK_UP1_RESERVED1
                robotIndex++;//IB_LINK_UP1_DOUBLE_PITCH
                robotIndex++;//IB_LINK_UP1_FOUR_GLASSES
                robotIndex++;//IB_LINK_UP1_RESERVED2
                robotIndex++;//IB_LINK_UP1_SEND_READY
                robotIndex++;//IB_LINK_UP1_RESERVED3
            }
            #endregion
            robotIndex += 16;
            #region ROBOT DOWNSTREAM
            if (_messageData.RobotList.Count > 0)
            {
                lblType10IndexerDownstreamInlineOn.BackColor = _messageData.RobotList[robotIndex++] == "True" ? Color.Lime : lblRobot.BackColor;
                lblType10IndexerDownstreamTrobuleOn.BackColor = _messageData.RobotList[robotIndex++] == "True" ? Color.Lime : lblRobot.BackColor;
                robotIndex++;//OB_LINK_DOWN1_HAND_INTERFERENCE
                lblType10IndexerJobTransSignalOn.BackColor = _messageData.RobotList[robotIndex] == "True" ? Color.Lime : lblRobot.BackColor; //OB_LINK_DOWN1_JOB_TRANSFER_SIGNAL
                lblType10IndexerJobTransSignalOff.BackColor = _messageData.RobotList[robotIndex++] == "False" ? Color.Red : lblRobot.BackColor;
                lblType10IndexerReceiveAbleOn.BackColor = _messageData.RobotList[robotIndex] == "True" ? Color.Lime : lblRobot.BackColor;
                lblType10ReceiveAbleOff.BackColor = _messageData.RobotList[robotIndex++] == "False" ? Color.Red : lblRobot.BackColor;
                lblType10IndexerReceiveStartOn.BackColor = _messageData.RobotList[robotIndex] == "True" ? Color.Lime : lblRobot.BackColor;
                lblType10IndexerReceiveStartOff.BackColor = _messageData.RobotList[robotIndex++] == "False" ? Color.Red : lblRobot.BackColor;
                lblType10IndexerReceiveCompleteOn.BackColor = _messageData.RobotList[robotIndex] == "True" ? Color.Lime : lblRobot.BackColor;
                lblType10IndexerCompleteOff.BackColor = _messageData.RobotList[robotIndex++] == "False" ? Color.Red : lblRobot.BackColor;
                lblType10IndexerExchangeExecute.BackColor = _messageData.RobotList[robotIndex++] == "True" ? Color.Lime : lblRobot.BackColor; 
                robotIndex++;//OB_LINK_DOWN1_HAND_INTERFERENCE
                robotIndex++;//OB_LINK_DOWN1_HAND_INTERFERENCE
                robotIndex++;//OB_LINK_DOWN1_HAND_INTERFERENCE
                robotIndex++;//OB_LINK_DOWN1_HAND_INTERFERENCE
                robotIndex++;//OB_LINK_DOWN1_HAND_INTERFERENCE
                robotIndex++;//OB_LINK_DOWN1_HAND_INTERFERENCE
                robotIndex++;//OB_LINK_DOWN1_HAND_INTERFERENCE
                robotIndex++;//OB_LINK_DOWN1_HAND_INTERFERENCE
            }
            #endregion

            #region STAGE UPSTREAM
            if (_messageData.StageList.Count > 0)
            {
                lblType10StageDownstreamInlineOn.BackColor = _messageData.StageList[stageIndex++] == "True" ? Color.Lime : lblStage.BackColor;
                lblType10StageDownstreamTrobuleOn.BackColor = _messageData.StageList[stageIndex++] == "True" ? Color.Lime : lblStage.BackColor;
                stageIndex++;//OB_LINK_DOWN1_HAND_INTERFERENCE
                stageIndex++;//OB_LINK_DOWN1_JOB_TRANSFER_SIGNAL
                lblType10ReceiveAbleOn.BackColor = _messageData.StageList[stageIndex] == "True" ? Color.Lime : lblStage.BackColor;
                lblType10ReceiveAbleOff.BackColor = _messageData.StageList[stageIndex++] == "False" ? Color.Red : lblStage.BackColor;
                lblType10ReceiveStartOn.BackColor = _messageData.StageList[stageIndex] == "True" ? Color.Lime : lblStage.BackColor;
                lblType10ReceiveStartOff.BackColor = _messageData.StageList[stageIndex++] == "False" ? Color.Red : lblStage.BackColor;
                lblType10ReceiveCompleteOn.BackColor = _messageData.StageList[stageIndex] == "True" ? Color.Lime : lblStage.BackColor;
                lblType10ReceiveCompleteOff.BackColor = _messageData.StageList[stageIndex++] == "False" ? Color.Red : lblStage.BackColor;
                lblType10StageExchangePossibleOn.BackColor = _messageData.StageList[stageIndex++] == "True" ? Color.Lime : lblStage.BackColor;
                stageIndex++;//OB_LINK_DOWN1_HAND_INTERFERENCE
                stageIndex++;//OB_LINK_DOWN1_HAND_INTERFERENCE
                stageIndex++;//OB_LINK_DOWN1_HAND_INTERFERENCE
                stageIndex++;//OB_LINK_DOWN1_HAND_INTERFERENCE
                stageIndex++;//OB_LINK_DOWN1_HAND_INTERFERENCE
                stageIndex++;//OB_LINK_DOWN1_HAND_INTERFERENCE
                stageIndex++;//OB_LINK_DOWN1_HAND_INTERFERENCE
                stageIndex++;//OB_LINK_DOWN1_HAND_INTERFERENCE
            }
            #endregion
            stageIndex += 16;
            #region STAGE DOWNSTREAM
            if (_messageData.StageList.Count > 0)
            {
                lblType10StageUpstreamInlineOn.BackColor = _messageData.StageList[stageIndex++] == "True" ? Color.Lime : lblRobot.BackColor;
                lblType10StageUpstreamTrobuleOn.BackColor = _messageData.StageList[stageIndex++] == "True" ? Color.Lime : lblRobot.BackColor;
                stageIndex++;//IB_LINK_UP1_HAND_INTERFERENCE
                stageIndex++;
                //lblType10JobTransferSignalOn.BackColor = _messageData.StageList[] == "True" ? Color.Lime : lblRobot.BackColor;
                //lblType10JobTransferSignalOff.BackColor = _messageData.StageList[stageIndex++] == "False" ? Color.Red : lblRobot.BackColor;
                lblType10StageSendAbleOn.BackColor = _messageData.StageList[stageIndex] == "True" ? Color.Lime : lblRobot.BackColor;
                lblType10StageSendAbleOff.BackColor = _messageData.StageList[stageIndex++] == "False" ? Color.Red : lblRobot.BackColor;
                lblType10StageSendStartOn.BackColor = _messageData.StageList[stageIndex] == "True" ? Color.Lime : lblRobot.BackColor;
                lblType10StageSendStartOff.BackColor = _messageData.StageList[stageIndex++] == "False" ? Color.Red : lblRobot.BackColor;
                lblType10StageSendCompleteOn.BackColor = _messageData.StageList[stageIndex] == "True" ? Color.Lime : lblRobot.BackColor;
                lblType10StageSendCompleteOff.BackColor = _messageData.StageList[stageIndex++] == "False" ? Color.Red : lblRobot.BackColor;
                lblType10StageExchangePossibleOn.BackColor = _messageData.StageList[stageIndex++] == "True" ? Color.Lime : lblRobot.BackColor; //20191203
                stageIndex++;//IB_LINK_UP1_CONVEYER_STATE
                stageIndex++;//IB_LINK_UP1_SHUTTER_STATE
                stageIndex++;//IB_LINK_UP1_RESERVED1
                stageIndex++;//IB_LINK_UP1_DOUBLE_PITCH
                stageIndex++;//IB_LINK_UP1_FOUR_GLASSES
                stageIndex++;//IB_LINK_UP1_RESERVED2
                stageIndex++;//IB_LINK_UP1_SEND_READY
                stageIndex++;//IB_LINK_UP1_RESERVED3
            }
            #endregion
            #endregion
        }

    }
}
