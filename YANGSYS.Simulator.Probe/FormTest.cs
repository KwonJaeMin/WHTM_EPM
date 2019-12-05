using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using YANGSYS.CommDrv;

namespace YANGSYS.Simulator.Probe
{
    public partial class FormTest : Form
    {
        private CSystemConfig _systemConfig = new CSystemConfig();
        private YangSysCommDrv _driver = null;
        private System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();

        private bool _loadRequest = false;
        private bool _loadEnable = false;
        private bool _unloadRequest = false;
        private bool _unloadEnable = false;
        private bool _glassExist1 = false;
        private string _receivedGlassData = "";

        private int _processingTime = 0;
        private int _loadRequestTime = 0;

        public FormTest()
        {
            InitializeComponent();

            chkAutoConnection.Checked = _systemConfig.AutoConnection;
            chkAutoIF.Checked = _systemConfig.AutoInterface;
            txtIP.Text = _systemConfig.IP;
            txtPort.Text = _systemConfig.Port;
            cbServerClient.Text = _systemConfig.ServerClient.ToUpper();
            cbSite.Text = _systemConfig.Site;
            InitComboBoxItem(cbSite.Text);

            cbStageGlassExist.SelectedIndex = _systemConfig.GlassExist1 ? 0 : 1;
            txtCurChangePPID.Text =_systemConfig.CurrentPPID;
            txtCurChangeRecipeID.Text = _systemConfig.CurrentRecipeID;
            cbAutoMode.SelectedIndex = _systemConfig.AutoMode ? 1 : 0;
            cbEquipmentMode.SelectedIndex = _systemConfig.EquipmentMode - 1;
            cbEquipmentState.SelectedIndex = _systemConfig.EquipmentState - 1;

            _systemConfig.Initiallized = true;
            
            if (chkAutoConnection.Checked)
            {
                btnOpen_Click(btnOpen, new EventArgs());
            }

            _timer.Interval = 1000;
            _timer.Tick += new EventHandler(_timer_Tick);
            _timer.Start();
        }

        private void StageGlassExist(bool exist)
        {
            this.SetText(cbStageGlassExist, exist ? "O":"X");
            this.ButtonClickArg(btnStageGlassExist);
        }

        private void CurrentRecipeChange(string ppid, string recipeId)
        {
            this.SetText(txtCurChangePPID, ppid);
            this.SetText(txtCurChangeRecipeID, recipeId);
            this.ButtonClickArg(btnCurrentRecipeChange);
        }
        private void AutoModeChange(bool auto)
        {
            this.SetText(cbAutoMode, cbAutoMode.Items[auto ? 1 : 0].ToString());
            this.ButtonClickArg(btnAutoModeChange);
        }
        private void EquipmentModeChange(int mode)
        {
            this.SetText(cbEquipmentMode, cbEquipmentMode.Items[mode].ToString());
            this.ButtonClickArg(btnEquipmentModeChange);
        }
        private void EquipmentStateChange(int state)
        {
            this.SetText(cbEquipmentState, cbEquipmentState.Items[state].ToString());
            this.ButtonClickArg(btnStateChangeEvent);
        }
        private void Communication(bool online)
        {
            this.SetText(cbOnline, online ? "O":"X");
            this.ButtonClickArg(btnCommunication);
        }

        bool _onlineSeq = true;
        private void _timer_Tick(object sender, EventArgs e)
        {
            if (_driver != null && _driver.GetStatus() == "Connected")
            {
                if (!_onlineSeq)
                {
                    _onlineSeq = true;
                    StageGlassExist(_systemConfig.GlassExist1);
                    CurrentRecipeChange(_systemConfig.CurrentPPID, _systemConfig.CurrentRecipeID);
                    AutoModeChange(_systemConfig.AutoMode);
                    EquipmentModeChange(_systemConfig.EquipmentMode);
                    Communication(true);
                }

                SetColor(btnOpen, Color.Lime);
                SetColor(btnClose, SystemColors.Control);
            }
            else
            {
                _onlineSeq = false;
                SetColor(btnOpen, Color.DimGray);
                SetColor(btnClose, Color.Red);
            }

            SetText(label15, "Current Status : " + (_driver == null ? "X" : _driver.GetStatus()));
            
            this.SetCheckBox(checkBox1, _loadRequest);
            this.SetCheckBox(checkBox2, _loadEnable);
            this.SetCheckBox(checkBox3, _unloadRequest);
            this.SetCheckBox(checkBox4, _unloadEnable);
            this.SetCheckBox(chkGlassExist, _glassExist1);
            this.SetCheckBox(chkExchnage, _isExchange);

            if (_processingTime > 0)
            {
                _processingTime++;

                if (_processingTime > _systemConfig.ProcTime)
                {
                    _processingTime = 0;

                    this.ButtonClickNoneArg(btnUnloadRequest);
                }
            }

            if (_loadRequestTime > 0)
            {
                _loadRequestTime++;

                if (_loadRequestTime > _systemConfig.LoadReqTime)
                {
                    _loadRequestTime = 0;

                    this.ButtonClickNoneArg(btnLoadRequest);
                }
            }
        }

        public void InitComboBoxItem(string site)
        {
            switch (site)
            {
                case "B7": 
                    comboBox2.Items.Clear();
                    comboBox2.Items.AddRange(new object[] { "1:PM", "2:BM(DOWN)", "3:PAUSE", "4:IDLE", "5:RUN"});
                    cbEquipmentState.Items.Clear();
                    cbEquipmentState.Items.AddRange(new object[] { "1:PM", "2:BM(DOWN)", "3:PAUSE", "4:IDLE", "5:RUN" });

                    comboBox6.Items.Clear();
                    comboBox6.Items.AddRange(new object[] { "P:Lot/Slot No", "I:Glass ID"});
                    comboBox21.Items.Clear();
                    comboBox21.Items.AddRange(new object[] { "0:NOT USED" });
                    label10.Text = "GLASSID,LOTNO,SLOTNO";
                    textBox4.Text = "";
                    textBox4.Visible = true;
                    textBox5.Text = "";
                    textBox5.Visible = true;
                    textBox6.Text = "";
                    textBox6.Visible = true;
                    label11.Text = "LOTNO,SLOTNO,GLASSID,PPID";
                    comboBox21.Visible = false;
                    cbScrapFlag.Visible = false;
                    txtScrapOperID.Visible = false;
                    label12.Text = "GLASSID";

                    label7.Text = "SET/RESET,ALLV,ALID,ALCD,ALTX";
                    cbALLV.Items.Clear();
                    cbALLV.Items.AddRange(new object[] { "1:Light", "2:Heavy" });
                    cbALLV.SelectedIndex = 0;
                    cbALCD.Visible = true;
                    cbALCD.Items.Clear();
                    cbALCD.Items.AddRange(new object[] { "0:Danger for human",
                                                            "1:Machine error",
                                                            "2:Parameter overflow caused process error",
                                                            "3:Parameter overflow caused machine can’t work",
                                                            "4:Cannot recover trouble",
                                                            "5:Machine status warning",
                                                            "6:Process reached to predefined status",
                                                            "7:CIM PC Caused"});
                    cbALCD.SelectedIndex = 0;

                    txtMeasureFilePath.Text = Application.StartupPath + @"\TestFiles\" + txtMeasureFilePath.Tag.ToString();

                    label14.Text = "LOTNO,SLOTNO,GLASSID,PPID";
                    break;
                case "B10": 
                    comboBox2.Items.Clear();
                    comboBox2.Items.AddRange(new object[] { "1:RUN", "2:IDLE", "3:DOWN", "4:PM" });
                    cbEquipmentState.Items.Clear();
                    cbEquipmentState.Items.AddRange(new object[] { "1:RUN", "2:IDLE", "3:DOWN", "4:PM" });

                    comboBox6.Items.Clear();
                    comboBox6.Items.AddRange(new object[] { "P:Lot/Slot No", "I:Glass ID" });
                    comboBox21.Items.Clear();
                    comboBox21.Items.AddRange(new object[] { "0:NOT USED" });
                    label10.Text = "GLASSID,LOTNO,SLOTNO";
                    textBox4.Visible = true;
                    textBox5.Visible = true;
                    textBox6.Visible = true;
                    label11.Text = "LOTNO,SLOTNO,GLASSID,PPID";
                    comboBox21.Visible = false;
                    cbScrapFlag.Visible = false;
                    txtScrapOperID.Visible = false;
                    label12.Text = "GLASSID";

                    label7.Text = "SET/RESET,ALLV,ALID,ALTX";
                    cbALLV.Items.Clear();
                    cbALLV.Items.AddRange(new object[] { "1:Light", "2:Serious" });
                    cbALLV.SelectedIndex = 0;
                    cbALCD.Visible = false;
                    cbALCD.Items.Clear();
                    txtMeasureFilePath.Text = Application.StartupPath + @"\TestFiles\" + txtMeasureFilePath.Tag.ToString();
                    label14.Text = "LOTNO,SLOTNO,GLASSID,PPID";
                    break;
                case "WHTM":
                    comboBox2.Items.Clear();
                    comboBox2.Items.AddRange(new object[] { "1:IDLE", "2:RUN", "3:DOWN", "4:PM", "5:STOP" });
                    cbEquipmentState.Items.Clear();
                    cbEquipmentState.Items.AddRange(new object[] { "1:IDLE", "2:RUN", "3:DOWN", "4:PM", "5:STOP" });

                    comboBox6.Items.Clear();
                    comboBox6.Items.AddRange(new object[] { "P:Lot ID", "I:Glass ID" });
                    comboBox21.Items.Clear();
                    comboBox21.Items.AddRange(new object[] { "0:Whole", "1:Half" });
                    label10.Text = "GLASS TYPE,LOTID or GLASSID";
                    textBox4.Visible = true;
                    textBox5.Visible = false;
                    textBox6.Visible = false;
                    label11.Text = "CST_INDEX,GLASS_INDEX,GLASSID,LOT_ID,GLASS_TYPE,PPID";
                    comboBox21.Visible = true;

                    label12.Text = "GLASSID,SCRAPCODE,OPERID";
                    cbScrapFlag.Items.Clear();
                    for (int i = 3; i < 100; i++)
                    {
                        cbScrapFlag.Items.Add(string.Format("{0}:", i));
                    }
                    cbScrapFlag.Visible = true;
                    txtScrapOperID.Visible = true;

                    label7.Text = "SET/RESET,ALLV,ALID,ALCD,ALTX";
                    cbALLV.Items.Clear();
                    cbALLV.Items.AddRange(new object[] { "1:Light", "2:Serious" });
                    cbALLV.SelectedIndex = 0;
                    cbALCD.Visible = true;
                    cbALCD.Items.Clear();
                    cbALCD.Items.AddRange(new object[] { "0:Danger for human",
                                                            "1:Machine error",
                                                            "2:Parameter overflow caused process error",
                                                            "3:Parameter overflow caused machine can’t work",
                                                            "4:Cannot recover trouble",
                                                            "5:Machine status warning",
                                                            "6:Process reached to predefined status"});
                    cbALCD.SelectedIndex = 0;

                    txtMeasureFilePath.Text = Application.StartupPath + @"\TestFiles\" + txtMeasureFilePath.Tag.ToString();

                    label14.Text = "CST_INDEX,GLASS_INDEX,GLASSID,LOT_ID,GLASS_TYPE,PPID";
                    break;
                default:
                    break;
            }

            comboBox2.SelectedIndex = 0;
            cbEquipmentState.SelectedIndex = 0;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (_driver != null)
                _driver.Stop();

            string mode = cbServerClient.Text.ToUpper() == "SERVER" ? "Server" : "Client";
            string ip = txtIP.Text;
            string port = txtPort.Text;
            _driver = new YangSysCommDrv();
            _driver.OnReceivedMessage += new ReceivedMessage(_driver_OnReceivedMessage);
            //"DriverName=Unknown, Mode=Client, RemoteIP=127.0.0.1, RemotePort=5000, LocalIP=127.0.0.1, LocalPort=6000"
            _driver.Init(string.Format("DriverName={0}, Mode={1}, RemoteIP={2}, RemotePort={3}, LocalIP={2}, LocalPort={3}", "SIMULATOR", mode, ip, port));
            _driver.Start();
        }
        
        private delegate void ButtonClickHandler(object sender);
        private void ButtonClickArg(object sender)
        {
            ButtonClickHandler del = new ButtonClickHandler(InnerButtonClickArg);
            this.Invoke(del, sender);
        }

        private void ButtonClickNoneArg(object sender)
        {
            ButtonClickHandler del = new ButtonClickHandler(InnerButtonClickNoneArg);
            this.Invoke(del, sender);
        }

        private void InnerButtonClickArg(object sender)
        {
            this.SendMessageArgs(sender, new EventArgs());
        }
        private void InnerButtonClickNoneArg(object sender)
        {
            this.SendMessageArg1(sender, new EventArgs());
        }

        private bool _isExchange = false;
        void _driver_OnReceivedMessage(string message)
        {
            message = message.Replace('\0', ' ');
            string temp = message;
            temp = temp.Trim();
            if (message.StartsWith("LOAD_REQUEST_REPLY"))
            {
                this.SetColor(button39, Color.Lime);
                Thread.Sleep(250);
                this.SetColor(button39, label1.BackColor);
            }
            else if (message.StartsWith("LOAD_ENABLE_REPLY"))
            {
                this.SetColor(button49, Color.Lime);
                Thread.Sleep(250);
                this.SetColor(button49, label1.BackColor);
            }
            else if (message.StartsWith("LOAD_HAND_DOWN_COMPLETION"))
            {
                this.SetColor(button50, Color.Lime);

                string data = string.Format("{0}", "LOAD_HAND_DOWN_COMPLETION_REPLY");
                _driver.Send(Encoding.ASCII.GetBytes(string.Format("{0}#", data).ToString()));                                

                this.SetColor(button3, Color.Lime);
                Thread.Sleep(250);
                this.SetColor(button50, label1.BackColor);
                this.SetColor(button3, label2.BackColor);
                
                this.SetText(textBox30, _receivedGlassData);
                
                //if (_systemConfig.AutoInterface)
                //{
                    this.SetText(cbStageGlassExist, "O");
                    this.ButtonClickArg(btnStageGlassExist);
                //}
            }
            else if (message.StartsWith("LOAD_COMPLETE"))
            {
                this.SetColor(button52, Color.Lime);

                string data = string.Format("{0}", "LOAD_COMPLETE_REPLY");
                _driver.Send(Encoding.ASCII.GetBytes(string.Format("{0}#", data).ToString()));

                this.SetColor(button4, Color.Lime);
                
                _loadEnable = false;
                _loadRequest = false;
                _isExchange = false;
                _processingTime = 1;

                Thread.Sleep(250);
                this.SetColor(button52, label1.BackColor);
                this.SetColor(button4, label2.BackColor);
            }
            else if (message.StartsWith("UNLOAD_REQUEST_REPLY"))
            {
                this.SetColor(button54, Color.Lime);
                Thread.Sleep(250);
                this.SetColor(button54, label1.BackColor);
            }
            else if (message.StartsWith("UNLOAD_ENABLE_REPLY"))
            {
                this.SetColor(button55, Color.Lime);
                Thread.Sleep(250);
                this.SetColor(button55, label1.BackColor);
            }
            else if (message.StartsWith("UNLOAD_HAND_UP_COMPLETION"))
            {
                this.SetColor(button51, Color.Lime);

                string data = string.Format("{0}", "UNLOAD_HAND_UP_COMPLETION_REPLY");
                _driver.Send(Encoding.ASCII.GetBytes(string.Format("{0}#", data).ToString()));

                this.SetColor(button7, Color.Lime);
                Thread.Sleep(250);
                this.SetColor(button51, label1.BackColor);
                this.SetColor(button7, label2.BackColor);

                this.SetText(textBox30, "");

                //if (_systemConfig.AutoInterface)
                //{
                    this.SetText(cbStageGlassExist, "X");
                    this.ButtonClickArg(btnStageGlassExist);
                //}
            }
            else if (message.StartsWith("UNLOAD_COMPLETE"))
            {
                this.SetColor(button53, Color.Lime);

                string data = string.Format("{0}", "UNLOAD_COMPLETE_REPLY");
                _driver.Send(Encoding.ASCII.GetBytes(string.Format("{0}#", data).ToString()));

                _unloadEnable = false;
                _unloadRequest = false;

                if (_systemConfig.AutoInterface)
                {
                    if (_isExchange && _glassExist1)
                    {
                        _loadRequestTime = 0;
                        _processingTime = 1;
                    }
                    else
                    {
                        _loadRequestTime = 1;
                        _processingTime = 0;
                    }
                }
                _isExchange = false;                

                this.SetColor(button8, Color.Lime);
                Thread.Sleep(250);
                this.SetColor(button53, label1.BackColor);
                this.SetColor(button8, label2.BackColor);
            }
            else if (message.StartsWith("ABNORMAL_INTERFACE"))
            {

                this.SetColor(button56, Color.Lime);
                Thread.Sleep(250);
                this.SetColor(button56, label1.BackColor);
            }
            else if (message.StartsWith("COMMUNICATION_ACK"))
            {
                string[] splitedMessage = message.Split('|');
                this.SetText(comboBox11, splitedMessage[1]);
                this.SetColor(button40, Color.Lime);
                Thread.Sleep(250);
                this.SetColor(button40, label1.BackColor);
            }
            else if (message.StartsWith("ALIVE"))
            {
                this.SetColor(button41, Color.Lime);
                Thread.Sleep(250);

                string data = string.Format("{0}", "ALIVE_REPLY");                
                _driver.Send(Encoding.ASCII.GetBytes(string.Format("{0}#", data).ToString()));

                this.SetColor(button12, Color.Lime);
                Thread.Sleep(250);
                this.SetColor(button41, label1.BackColor);
                this.SetColor(button12, label2.BackColor);
            }
            else if (message.StartsWith("STATE_REQUEST"))
            {
                this.SetColor(button42, Color.Lime);
                string arg1 = "";
                string arg2 = "";
                arg1 = GetText(comboBox2).Split(':')[0];
                arg2 = GetText(comboBox8).Split(':')[0];

                string data = string.Format("{0}|{1}|{2}", "STATE_REQUEST_ACK", arg1, arg2);
                _driver.Send(Encoding.ASCII.GetBytes(string.Format("{0}#", data).ToString()));
                
                this.SetColor(button13, Color.Lime);
                Thread.Sleep(250);
                this.SetColor(button42, label1.BackColor);
                this.SetColor(button13, label2.BackColor);
            }
            //else if (message.StartsWith("STATE_CHANGE_REQ"))
            //{
            //    string[] splitedMessage = message.Split('|');
            //    this.SetIndex(comboBox13, splitedMessage[1] == "R" ? 0 : 1);
            //    this.SetColor(button43, Color.Lime);
            //    Thread.Sleep(250);
            //    this.SetColor(button43, label1.BackColor);
            //}
            else if (message.StartsWith("STATE_CHANGE_EVENT_REPLY"))
            {
                this.SetColor(button44, Color.Lime);

                Thread.Sleep(250);
                this.SetColor(button44, label1.BackColor);
                this.SetColor(btnStateChangeEvent, label2.BackColor);
            }
            else if (message.StartsWith("STAGE_GLASS_EXIST_REPLY"))
            {
                this.SetColor(button45, Color.Lime);

                Thread.Sleep(250);
                this.SetColor(button45, label1.BackColor);
                this.SetColor(btnStageGlassExist, label2.BackColor);
            }
            else if (message.StartsWith("USER_LOGIN_REPLY"))
            {
                this.SetColor(button46, Color.Lime);

                Thread.Sleep(250);
                this.SetColor(button46, label1.BackColor);
                this.SetColor(button17, label2.BackColor);
            }
            else if (message.StartsWith("USER_LOGIN_RECIPE_REPLY"))
            {
                this.SetColor(button72, Color.Lime);
                
                string[] splitedMessage = message.Split('|');
                this.SetText(comboBox7, splitedMessage[1]);
                
                Thread.Sleep(250);
                this.SetColor(button72, label1.BackColor);
                this.SetColor(button77, label2.BackColor);
            }
            else if (message.StartsWith("GLASS_DATA_SEND"))
            {
                string[] splitedMessage = message.Split('|');
                this.SetText(comboBox12, splitedMessage[1]);
                if(splitedMessage.Length == 3)
                    this.SetText(textBox18, splitedMessage[2]);
                this.SetColor(button47, Color.Lime);

                string data = string.Format("{0}", "GLASS_DATA_SEND_ACK");
                _driver.Send(Encoding.ASCII.GetBytes(string.Format("{0}#", data).ToString()));

                _receivedGlassData = splitedMessage.Length == 3 ? splitedMessage[2] : "";

                this.SetColor(button18, Color.Lime);
                Thread.Sleep(250);
                this.SetColor(button47, label1.BackColor);
                this.SetColor(button18, label2.BackColor);

                if (_systemConfig.AutoInterface)
                {
                    bool receivedGlassExist = splitedMessage[1] == "O";
                    if(_loadRequest)
                        this.ButtonClickNoneArg(btnLoadEnable);
                    else if (_unloadRequest)
                    {
                        _isExchange = receivedGlassExist;
                        this.ButtonClickNoneArg(btnUnloadEnable);
                    }
                }
            }
            else if (message.StartsWith("LOST_GLASS_DATA_REQUEST_ACK"))
            {
                string[] splitedMessage = message.Split('|');
                this.SetText(comboBox14, splitedMessage[1]);
                this.SetText(textBox3, splitedMessage[2]);
                this.SetColor(button48, Color.Lime);
                Thread.Sleep(250);
                this.SetColor(button48, label1.BackColor);
            }
            else if (message.StartsWith("GLASS_SCRAP_ACK"))
            {
                string[] splitedMessage = message.Split('|');
                this.SetText(comboBox22, splitedMessage[1]);
                this.SetColor(button58, Color.Lime);
                Thread.Sleep(250);
                this.SetColor(button58, label1.BackColor);
            }
            else if (message.StartsWith("JOB_HOLD_EVENT_REPORT_ACK"))
            {

                this.SetColor(button59, Color.Lime);
                Thread.Sleep(250);
                this.SetColor(button59, label1.BackColor);
            }
            else if (message.StartsWith("ALARM_SET_REPLY"))
            {
                this.SetColor(button60, Color.Lime);

                Thread.Sleep(250);
                this.SetColor(button60, label1.BackColor);
                this.SetColor(btnEQPAlarmSet, label2.BackColor);
            }
            //else if (message.StartsWith("ALARM_RESET_REPLY"))
            //{
            //    this.SetColor(button9, Color.Lime);
            //    Thread.Sleep(250);
            //    this.SetColor(button9, label1.BackColor);
            //}
            else if (message.StartsWith("ALARM_SET_REQUEST"))
            {
                this.SetColor(button61, Color.Lime);

                string data = string.Format("{0}", "ALARM_SET_REQUEST_REPLY");
                _driver.Send(Encoding.ASCII.GetBytes(string.Format("{0}#", data).ToString()));

                string[] splitedMessage = message.Split('|');
                this.SetIndex(comboBox15, int.Parse(splitedMessage[1]));

                data = "";

                string alid = "";
                alid = splitedMessage[2];

                this.SetColor(button23, Color.Lime);

                Thread.Sleep(250);
                this.SetColor(button61, label1.BackColor);
                this.SetColor(button23, label2.BackColor);

                this.SetText(txtALID, alid);
                this.SetIndex(cbAlarmStatus, splitedMessage[1] == "1" ? 1 : 0);

                this.ButtonClickArg(btnEQPAlarmSet);

            }
            else if (message.StartsWith("RECIPE_LIST_REQ"))
            {
                this.SetColor(button62, Color.Lime);

                StringBuilder sb = new StringBuilder();
                List<string> recipeList = new List<string>(GetText(txtPPIDList).Split(','));
                string arg1 = "";
                string data = "";

                arg1 = recipeList.Count.ToString();
                if (_systemConfig.Site == "WHTM")
                {
                    sb.Append(GetText(txtPPIDList));
                }
                else
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        if (recipeList.Contains(i.ToString()))
                            sb.Append("1");
                        else
                            sb.Append("0");
                    }
                }
                data = string.Format("{0}|{1}", "RECIPE_LIST_REQ_REPLY", arg1, sb.ToString());
                _driver.Send(Encoding.ASCII.GetBytes(string.Format("{0}#", data).ToString()));

                this.SetColor(button24, Color.Lime);
                Thread.Sleep(250);
                this.SetColor(button62, label1.BackColor);
                this.SetColor(button24, label1.BackColor);
                
            }
            else if (message.StartsWith("CURRENT_RECIPE_CHANGE_ACK"))
            {
                this.SetColor(button63, Color.Lime);
                Thread.Sleep(250);
                this.SetColor(button63, label1.BackColor);
                this.SetColor(btnCurrentRecipeChange, label2.BackColor);
            }
            else if (message.StartsWith("RECIPE_REPORT_ACK"))
            {
                this.SetColor(button64, Color.Lime);

                string[] splitedMessage = message.Split('|');
                comboBox23.Text = splitedMessage[1];

                Thread.Sleep(250);
                this.SetColor(button64, label1.BackColor);
                this.SetColor(button26, label2.BackColor);
            }
            else if (message.StartsWith("BUZZER"))
            {
                this.SetColor(button65, Color.Lime);

                string[] splitedMessage = message.Split('|');
                this.SetIndex(comboBox16, int.Parse(splitedMessage[1]));

                if (splitedMessage[1] == "O")
                {
                    System.Media.SystemSounds.Beep.Play();
                }
                else
                {
                    
                }
                string data = string.Format("{0}", "BUZZER_REPLY");
                _driver.Send(Encoding.ASCII.GetBytes(string.Format("{0}#", data).ToString()));

                this.SetColor(button27, Color.Lime);
                Thread.Sleep(250);
                this.SetColor(button65, label1.BackColor);
                this.SetColor(button27, label2.BackColor);
            }
            else if (message.StartsWith("GLASS_DATA_VALUE_FILE_REPORT_ACK"))
            {
                this.SetColor(button34, Color.Lime);
                Thread.Sleep(250);
                this.SetColor(button34, label1.BackColor);
                this.SetColor(button57, label2.BackColor);
            }
            //else if (message.StartsWith("IONIZER_ACK"))
            //{

            //    this.SetColor(button66, Color.Lime);
            //    Thread.Sleep(250);
            //    this.SetColor(button66, label1.BackColor);
            //}
            else if (message.StartsWith("AUTO_MODE_CHANGE_EVENT_REPLY"))
            {
                this.SetColor(button67, Color.Lime);
                Thread.Sleep(250);
                this.SetColor(button67, label1.BackColor);
                this.SetColor(btnAutoModeChange, label2.BackColor);
            }
            //else if (message.StartsWith("OXR_INFORMATION_UPDATE_REPLY"))
            //{

            //    this.SetColor(button68, Color.Lime);
            //    Thread.Sleep(250);
            //    this.SetColor(button68, label1.BackColor);
            //}
            //else if (message.StartsWith("OXR_INFORMATION_REQUEST_DATA"))
            //{
            //    string[] splitedMessage = message.Split('|');
            //    this.SetText(textBox21, splitedMessage[1]);

            //    this.SetColor(button69, Color.Lime);
            //    Thread.Sleep(250);
            //    this.SetColor(button69, label1.BackColor);
            //}
            else if (message.StartsWith("TRACKING_DATA_REPLY"))
            {
                this.SetColor(button70, Color.Lime);
                Thread.Sleep(250);
                this.SetColor(button70, label1.BackColor);
                this.SetColor(button32, label2.BackColor);
            }
            //else if (message.StartsWith("TRANSFER_STOP"))
            //{
            //    string[] splitedMessage = message.Split('|');
            //    this.SetIndex(comboBox17, int.Parse(splitedMessage[1]) - 1);
            //    this.SetColor(button71, Color.Lime);
            //    Thread.Sleep(250);
            //    this.SetColor(button71, label1.BackColor);
            //}
            else if (message.StartsWith("CIM_MESSAGE_ON"))
            {
                string[] splitedMessage = message.Split('|');
                this.SetText(comboBox10, splitedMessage[1]);
                this.SetColor(button73, Color.Lime);

                System.Media.SystemSounds.Beep.Play();

                string data = string.Format("{0}", "CIM_MESSAGE_ON_REPLY");
                _driver.Send(Encoding.ASCII.GetBytes(string.Format("{0}#", data).ToString()));

                this.SetColor(button35, Color.Lime);
                Thread.Sleep(250);
                this.SetColor(button73, label1.BackColor);
                this.SetColor(button35, label2.BackColor);

            }
            else if (message.StartsWith("RECOVERY_GLASS_DATA_SEND"))
            {
                this.SetColor(button74, Color.Lime);
                string[] splitedMessage = message.Split('|');
                this.SetText(textBox22, splitedMessage[1]);
                this.SetText(textBox25, splitedMessage[2]);
                this.SetColor(button36, Color.Lime);
                Thread.Sleep(250);
                this.SetColor(button74, label1.BackColor);
                this.SetColor(button36, label2.BackColor);
            }
            else if (message.StartsWith("DEFECT_CODE_REPORT_REPLY"))
            {

                this.SetColor(button75, Color.Lime);
                Thread.Sleep(250);
                this.SetColor(button75, label1.BackColor);
            }
            else if (message.StartsWith("SVID_SEND_REPLY"))
            {

                this.SetColor(button76, Color.Lime);


                Thread.Sleep(250);
                this.SetColor(button76, label1.BackColor);
                this.SetColor(button38, label2.BackColor);
            }
            else if (message.StartsWith("MACHINE_MODE_CHANGE_REPORT"))
            {
                this.SetColor(button88, Color.Lime);


                Thread.Sleep(250);
                this.SetColor(button88, label1.BackColor);
                this.SetColor(btnEquipmentModeChange, label2.BackColor);
            }
            
        }
        private delegate void SetCheckBoxHandler(CheckBox checkBox, bool value);
        private delegate void SetColorHandler(Control control, Color color);
        private delegate void SetTextHandler(Control control, string text);
        private delegate string GetTextHandler(Control control);
        private delegate void SetIndexHandler(ComboBox cb, int index);

        private void SetCheckBox(CheckBox checkBox, bool value)
        {
            SetCheckBoxHandler del = new SetCheckBoxHandler(InvokeSetChecked);
            this.Invoke(del, checkBox, value);            
        }
        private void SetColor(Control control, Color color)
        {
            SetColorHandler del = new SetColorHandler(InvokeSetColor);
            this.Invoke(del, control, color);
        }
        private void InvokeSetChecked(CheckBox checkBox, bool value)
        {
            checkBox.Checked = value;
        }
        private void InvokeSetColor(Control control, Color color)
        {
            control.BackColor = color;
        }
        private void SetText(Control control, string text)
        {
            SetTextHandler del = new SetTextHandler(InvokeText);
            this.Invoke(del, control, text);
        }
        private void InvokeText(Control control, string text)
        {
            control.Text = text;
        }
        private string GetText(Control control)
        {
            GetTextHandler del = new GetTextHandler(InvokeGetText);
            return this.Invoke(del, control) as string;
        }
        private string InvokeGetText(Control control)
        {
            return control.Text;
        }
        private void SetIndex(ComboBox cb, int index)
        {
            SetIndexHandler del = new SetIndexHandler(InvokeIndex);
            this.Invoke(del, cb, index);
        }
        private void InvokeIndex(ComboBox cb, int index)
        {
            cb.SelectedIndex = index;
        }
        public string GetBytePart(string[] str, int startIndex, int length)
        {

            string temp = "";

            for (int i = startIndex; i < str.Length; i++)
            {
                temp += str[i] + " ";
            }

            return temp.Trim();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (_driver != null)
                _driver.Stop();
        }

        private void Send(byte[] data)
        {
            if (_driver == null)
            {
                MessageBox.Show("TCP/IP 설정 및 OPEN을 수행 하십시오");
                return;
            }
            _driver.Send(data);
        }

        private void SendMessageArg1(object sender, EventArgs e)
        {
            Button button = sender as Button;
            string messageName = button.Text;
            string data = string.Format("{0}", messageName);

            if (sender == btnLoadRequest)
            {
                _loadRequest = true;
            }
            else if (sender == btnLoadEnable)
            {
                _loadEnable = true;
            }
            else if (sender == btnUnloadRequest)
            {
                _unloadRequest = true;
            }
            else if (sender == btnUnloadEnable)
            {
                _unloadEnable = true;
            }
            else if (sender == button10)
            {
                _unloadEnable = false;
                _unloadRequest = false;
                _loadEnable = false;
                _unloadEnable = false;
            }

            this.Send(Encoding.ASCII.GetBytes(string.Format("{0}#", data).ToString()));
        }

        private void SendMessageArgs(object sender, EventArgs e)
        {
            Button button = sender as Button;
            string messageName = button.Text;
            string arg1 = "";
            string arg2 = "";
            string arg3 = "";
            string data = "";
            string[] temp = null;

            if (button == btnCommunication)
            {
                arg1 = cbOnline.Text;
                data = string.Format("{0}|{1}", messageName, arg1);
                if (_systemConfig.AutoInterface)
                {
                    if (_glassExist1 == false)
                        _loadRequestTime = 1;
                    else
                        _processingTime = 1;
                }
            }
            else if (button == btnStateChangeEvent)
            {
                int state = 0;
                int.TryParse(cbEquipmentState.Text.Split(':')[0], out state);
                int option = 0;
                int.TryParse(comboBox20.Text.Split(':')[0], out option);

                arg1 = state.ToString();
                arg2 = option.ToString();
                data = string.Format("{0}|{1}|{2}", messageName, arg1, arg2);
                _systemConfig.EquipmentState = state;
                //_systemConfig.AlarmState = 
            }
            else if (button == btnStageGlassExist)
            {
                arg1 = cbStageGlassExist.Text;
                data = string.Format("{0}|{1}", messageName, arg1);
                _glassExist1 = arg1 == "O";
                _systemConfig.GlassExist1 = _glassExist1;

            }
            else if (button == button17)
            {
                arg1 = textBox1.Text;
                data = string.Format("{0}|{1}", messageName, arg1);
            }
            else if (button == button77)
            {
                arg1 = textBox1.Text;
                arg2 = textBox2.Text;
                data = string.Format("{0}|{1}|{2}", messageName, arg1, arg2);
            }
            else if (button == button20)
            {
                temp = comboBox6.Text.Split(':');
                if (_systemConfig.Site == "B7" || _systemConfig.Site == "B10")
                {
                    arg1 = temp[0];
                    arg2 = string.Format("{0},{1},{2}", textBox6.Text, textBox4.Text, textBox5.Text);
                    data = string.Format("{0}|{1}|{2}", messageName, arg1, arg2);
                }
                else if (_systemConfig.Site == "WHTM")
                {
                    arg1 = temp[0];
                    arg2 = string.Format("{0},{1}", comboBox21.Text.Split(':')[0],  textBox5.Text);
                    data = string.Format("{0}|{1}", messageName, arg1, arg2);
                }
            }
            else if (button == button19)
            {
                arg1 = txtScrapGlassID.Text;

                if (_systemConfig.Site == "B7" || _systemConfig.Site == "B10")
                {
                    data = string.Format("{0}|{1}", messageName, arg1);
                }
                else if (_systemConfig.Site == "WHTM")
                {
                    temp = cbScrapFlag.Text.Split(':');
                    arg2 = string.Format("{0},{1}", temp[0],txtScrapOperID.Text);
                    data = string.Format("{0}|{1}|{2}", messageName, arg1, arg2);
                }
            }
            else if (button == btnEQPAlarmSet)
            {
                arg1 = cbAlarmStatus.Text.Split(':')[0];
                arg2 = string.Format("{0},{1},{2},{3}", cbALLV.Text.Split(':')[0], _systemConfig.Site == "B10" ? "" : cbALCD.Text.Split(':')[0],txtALID.Text, txtALTX.Text);
                data = string.Format("{0}|{1}|{2}", messageName, arg1, arg2);
            }
            //else if (button == button22)
            //{
            //    arg1 = txtAlarmResetALID.Text;
            //    arg2 = txtAlarmResetALTX.Text;
            //    data = string.Format("{0}|{1}|{2}", messageName, arg1, arg2);
            //}
            else if (button == button24)
            {
                arg1 = txtPPIDList.Text.Split(',').Length.ToString(); 
                arg2 = txtPPIDList.Text;
                data = string.Format("{0}|{1}|{2}", messageName, arg1, arg2);
            }
            else if (button == btnCurrentRecipeChange)
            {
                arg1 = txtCurChangePPID.Text;
                arg2 = txtCurChangeRecipeID.Text;
                data = string.Format("{0}|{1}|{2}", messageName, arg1, arg2);
                _systemConfig.CurrentPPID = arg1;
                _systemConfig.CurrentRecipeID = arg2;
            }
            else if (button == button26)
            {
                temp = cbUpdateType.Text.Split(':');
                arg1 = temp[0];
                arg2 = txtRecipeReportPPID.Text;
                arg3 = txtRecipeReportRecieID.Text;
                string arg4 = txtRecipeVersion.Text;
                data = string.Format("{0}|{1}|{2},{3},{4}", messageName, arg1, arg2, arg3, arg4);
            }
            else if (button == button57)
            {
                arg1 = @txtMeasureFilePath.Text;
                data = string.Format("{0}|{1}", messageName, arg1);
            }
            else if (button == button28)
            {
                arg1 = textBox11.Text;
                data = string.Format("{0}|{1}", messageName, arg1);
            }
            else if (button == btnAutoModeChange)
            {
                temp = cbAutoMode.Text.Split(':');
                arg1 = temp[0];
                data = string.Format("{0}|{1}", messageName, arg1);
                _systemConfig.AutoMode = temp[0] == "2";
            }
            else if (button == button30)
            {
                arg1 = textBox12.Text;
                data = string.Format("{0}|{1}", messageName, arg1);
            }
            else if (button == button32)
            {
                temp = comboBox18.Text.Split(':');
                arg1 = int.Parse(temp[0]).ToString();
                data = string.Format("{0}|{1}", messageName, arg1);
            }
            else if (button == button35)
            {
                arg1 = comboBox10.Text;
                data = string.Format("{0}|{1}", messageName, arg1);
            }

            else if (button == button37)
            {
                arg1 = textBox16.Text;
                arg2 = textBox13.Text;
                data = string.Format("{0}|{1}|{2}", messageName, arg1, arg2);
            }
            else if (button == button38)
            {
                arg1 = textBox15.Text;
                arg2 = textBox14.Text;
                data = string.Format("{0}|{1}|{2}", messageName, arg1, arg2);
            }
            else if (button == button5)
            {
                arg1 = textBox33.Text;
                arg2 = textBox34.Text;
                data = string.Format("{0}|{1}|{2}", messageName, arg1, arg2);
            }
            else if (button == btnEquipmentModeChange)
            {
                temp = comboBox18.Text.Split(':');
                int mode = 0;
                int.TryParse(temp[0], out mode);
                arg1 = mode.ToString();
                data = string.Format("{0}|{1}", messageName, arg1);
                _systemConfig.EquipmentMode = mode;
            }
            else if (button == button1)
            {
                temp = comboBox1.Text.Split(':');
                int state = 0;
                int.TryParse(temp[0], out state);
                arg1 = state.ToString();
                data = string.Format("{0}|{1}", messageName, arg1);
                _systemConfig.ProcessState = state;
            }
            else
            {
                MessageBox.Show("처리가 등록되지 않았습니다.");
                return;
            }
            this.Send(Encoding.ASCII.GetBytes(string.Format("{0}#", data).ToString()));

            button.BackColor = button.BackColor == Color.Lime ? label2.BackColor : Color.Lime;
        }

        private void chkAutoConnection_CheckedChanged(object sender, EventArgs e)
        {
            if (_systemConfig.Initiallized)
            {
                _systemConfig.AutoConnection = chkAutoConnection.Checked;
            }
        }

        private void chkAutoIF_CheckedChanged(object sender, EventArgs e)
        {
            if (_systemConfig.Initiallized)
            {
                _systemConfig.AutoInterface = chkAutoIF.Checked;
            }
        }

        private void cbSite_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_systemConfig.Initiallized)
            {
                _systemConfig.Site = cbSite.Text;
                InitComboBoxItem(cbSite.Text);
            }
        }

        private void txtIP_TextChanged(object sender, EventArgs e)
        {
            if (_systemConfig.Initiallized)
            {
                _systemConfig.IP = txtIP.Text;
            }
        }

        private void txtPort_TextChanged(object sender, EventArgs e)
        {
            if (_systemConfig.Initiallized)
            {
                _systemConfig.Port = txtPort.Text;
            }
        }

        private void cbTcpIpType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_systemConfig.Initiallized)
            {
                _systemConfig.ServerClient = cbServerClient.Text;
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox20.Items.Clear();
            string site = _systemConfig.Site;

            switch (site)
            {
                case "B7":
                    if (cbEquipmentState.Text.Contains("PM"))
                    {
                        comboBox20.Items.Add("100:DOWN_BM");
                        comboBox20.Items.Add("101:PM_TBM, CBM(Regular)");
                        comboBox20.Items.Add("102:PM_NSP(Non-regular)");
                        comboBox20.Items.Add("103:Machine Down");
                        comboBox20.Items.Add("104:Process Down");
                        comboBox20.Items.Add("105:Change Same");
                        comboBox20.Items.Add("106:Change Different");
                        comboBox20.Items.Add("107:Change Material");
                        comboBox20.Items.Add("108:ETC");
                    }
                    else if (cbEquipmentState.Text.Contains("BM"))
                    {
                        comboBox20.Items.Add("200:Own Machine");
                        comboBox20.Items.Add("201:Related Machine");
                        comboBox20.Items.Add("203:Operator");
                        comboBox20.Items.Add("204:Emergency Stop");
                    }
                    else if (cbEquipmentState.Text.Contains("PAUSE"))
                    {
                        comboBox20.Items.Add("300:Regular Production");
                        comboBox20.Items.Add("301:Engineering Run");
                        comboBox20.Items.Add("302:Rework");
                    }
                    else if (cbEquipmentState.Text.Contains("IDLE"))
                    {
                        comboBox20.Items.Add("400:No Product");
                        comboBox20.Items.Add("401:No Support Tool");
                        comboBox20.Items.Add("402:No Operator");
                        comboBox20.Items.Add("403:Process Experiments");
                        comboBox20.Items.Add("404:Equipment Experiments");
                        comboBox20.Items.Add("405:Software Qualification");
                    }
                    else if (cbEquipmentState.Text.Contains("RUN"))
                    {
                        comboBox20.Items.Add("500:Equipment Failure");
                        comboBox20.Items.Add("501:Process Failure");
                        comboBox20.Items.Add("502:Facilities Failure");
                        comboBox20.Items.Add("503:Automation Failure");
                        comboBox20.Items.Add("504:ShuotDown");
                        comboBox20.Items.Add("505:Off-line training");
                        comboBox20.Items.Add("506:Installation, Upgrade");
                        comboBox20.Items.Add("507:Not Scheduled");
                    }
                    break;
                case "B10":
                    comboBox20.Items.Add("1:F Run (Full Run)");
                    comboBox20.Items.Add("2:P Run (Port of EQ / Unit / Chamber Run)");
                    comboBox20.Items.Add("3:Low WIP (Process WIP lower than standard)");
                    comboBox20.Items.Add("4:Move Slow (STK Moving Slow)");
                    comboBox20.Items.Add("5:ETC (ETC)");
                    comboBox20.Items.Add("6:Waiting (Wait for test result)");
                    comboBox20.Items.Add("7:E Down (Machine Down)");
                    comboBox20.Items.Add("8:Pause (Some specific Unit Manual stop)");
                    comboBox20.Items.Add("9:PM (Machine PM)");
                    comboBox20.Items.Add("10:Maintenance (Material Change and so on.)");
                    break;
                case "WHTM":
                    comboBox20.Items.Add("0:NOT USED");
                    break;
            }
            comboBox20.SelectedIndex = 0;
        }

        private void checkBox3_Click(object sender, EventArgs e)
        {
            if (sender == chkGlassExist)
            {
                _glassExist1 = chkGlassExist.Checked;
            }
            else if (sender == checkBox1)
            {
                _loadRequest = checkBox1.Checked;
            }
            else if (sender == checkBox2)
            {
                _loadEnable = checkBox2.Checked;
            }
            else if (sender == checkBox3)
            {
                _unloadRequest = checkBox3.Checked;
            }
            else if (sender == checkBox4)
            {
                _unloadEnable = checkBox4.Checked;
            }
        }

        private void textBox31_TextChanged(object sender, EventArgs e)
        {
            _systemConfig.ProcTime = int.Parse(textBox31.Text);
        }

        private void textBox32_TextChanged(object sender, EventArgs e)
        {
            _systemConfig.LoadReqTime = int.Parse(textBox32.Text);
        }
    }
}
