using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels.Tcp;
using System.Reflection;
using System.Net;
using System.Collections;
using System.Runtime.Serialization.Formatters;

using SOFD.Driver;
using SOFD.File;
using SOFD.Component;
using SOFD.Component.Interface;

using System.Threading;
using SOFD.Properties;



namespace SmartPLCSimulator
{
    public enum CHANNELTYPE
    {
        TCP = 0,
        HTTP = 1,
        IPC = 2
    }
    public partial class FormMain : Form
    {
        #region Property
        private CSystemConfig _systemConfig = new CSystemConfig();
        private string BDevice = "23";
        private string WDevice = "24";
        private BaseDevice _currentDevice = null;
        private CHANNELTYPE channel = CHANNELTYPE.TCP;
        private int count = 8;
        private string _portNo = "5556";
        private FormDevice formDevice = null;
        private string _objectUri = "StringRemoteObject.rem";

        //EMP SIM PROPERTY
        private CScanControlPropertiesCollections _scans = new CScanControlPropertiesCollections();
        private CIControlAttributeCollection _controlAttributeCollection = new CIControlAttributeCollection();
        private CPLCControlPropertiesCollection _plcs = new CPLCControlPropertiesCollection();
        private CScanario _scanario = null;

        private Thread ScanThread = null;

        private CXmlFileControl _fileControl = null;
        private string _siteName = string.Empty;
        private object _logdingGlassCodeLock = new object();

        private int _bpLoadingGlassCode = 1234;
        public int BPLoadingGlassCode 
        {
            get
            {
                lock (_logdingGlassCodeLock)
                {
                    return _bpLoadingGlassCode;
                }
            }
            set
            {
                lock (_logdingGlassCodeLock)
                {
                    _bpLoadingGlassCode = value;
                }
            }
        }
        public string GlassID = "A";
        public int GlassIDIndex = 0;

        public int BPSTKLoadingGlassCode = 3456;
        public int BPSTKLoadingGlassEqpRecipeNo = 0;
        private bool bLogging = true;

        public bool M1_PASS_CH03_PROCESSING = false; //PASS_CH03이 UNLOADING 중인지 여부 (M1의 PASS_CH03은 장비내에 Glass가 2장 흐르는데.. Unloading중 Loading완료를 탈경우가 발생하여 추가.

        public CScanControlPropertiesCollections Scans
        {
            get { return _scans; }
            set { _scans = value; }
        }
        public CIControlAttributeCollection ControlAttributeCollection
        {
            get { return _controlAttributeCollection; }
            set { _controlAttributeCollection = value; }
        }
        public CPLCControlPropertiesCollection Plcs
        {
            get { return _plcs; }
            set { _plcs = value; }
        }

        public string ObjectUri
        {
            get
            {
                return _objectUri;
            }
            set
            {
                _objectUri = value;
            }
        }
        public string PortNo
        {
            get
            {
                return _portNo;
            }
            set
            {
                _portNo = value;
            }
        }

        #endregion 

        public FormMain(int iPortNO)
        {
            _portNo = iPortNO.ToString();
            InitializeComponent();
            init();
            textBox18.Lines = _systemConfig.PPIDRecipe;
        }

        #region Simulator Initialize

        private void init()
        {
            RemotingInit();
            DeviceManager _device = new DeviceManager();

            for (int i = 0; i < 15; i++)
            {
                dataGridView1.Rows.Add();
            }
           
            IPAddress[] IPAddr = Dns.GetHostAddresses(Dns.GetHostName());

            IP.Text = "IP : " + IPAddr[0].ToString();

            PortNumber.Text = "PORTNO : " + PortNo;

            PortStatus.Text = "PORT : Open";

            lblObjectUri.Text = "ObjectUri : " + this.ObjectUri;
            Draw(count);

            #region EMP SIM Intance Load

            _fileControl = new CXmlFileControl();
            string xmlPath = string.Empty;
            xmlPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "Config\\";


            #region //Config
            string xmlConfigPath = xmlPath + "Config.xml";
            Dictionary<string, object> configs = new Dictionary<string, object>();
            configs = _fileControl.GetConvertXmlPattern(xmlConfigPath, "CONFIG");
            string siteName = string.Empty;
            foreach (string strConfig in configs.Keys)
            {
                CReturnObject value = new CReturnObject();
                value = configs[strConfig] as CReturnObject;
                siteName = value.ObjectString08.ToString();
                _siteName = siteName;
            }
            #endregion

            #region Control
            //string xmlControlPath = xmlPath + "Controls.xml";
            string xmlControlPath = xmlPath + siteName + @"\Controls.xml";
            Dictionary<string, object> controls = new Dictionary<string, object>();
            controls = _fileControl.GetConvertXmlPattern(xmlControlPath, "CONTROL");

            foreach (string strControl in controls.Keys)
            {
                CReturnObject value = new CReturnObject();
                value = controls[strControl] as CReturnObject;

                if (value.ObjectString03.ToString().Contains("EQP"))
                {

                }         
            }
            #endregion

            #region SCAN
            //string xmlScanControlPath = xmlPath + "ScanControls.xml";
            string xmlScanControlPath = xmlPath + siteName + @"\ScanControls.xml";
            Dictionary<string, object> scanControls = new Dictionary<string, object>();
            scanControls = _fileControl.GetConvertXmlPattern(xmlScanControlPath, "SCANCONTROL");
            int iScanIndex = 0;


            Dictionary<string, string> oTMPData = new Dictionary<string, string>();

            foreach (string strScan in scanControls.Keys)
            {
                CReturnObject value = new CReturnObject();
                value = scanControls[strScan] as CReturnObject;
                CScanControlPropertiesForSim scanControl = new CScanControlPropertiesForSim();
                CControlAttribute controlAttribute = new CControlAttribute();

                scanControl.ScanControlName = value.ObjectString02.ToString();
                controlAttribute.ControlName = scanControl.ScanControlName;
                scanControl.ScanAttribute = value.ObjectString03.ToString();
                controlAttribute.Attribute = scanControl.ScanAttribute;

                scanControl.ScanDataType = (enumReadDataType)Enum.Parse(typeof(enumReadDataType), value.ObjectString04.ToString());
                scanControl.ScanDeviceType = (enumDeviceType)Enum.Parse(typeof(enumDeviceType), value.ObjectString05.ToString());
                scanControl.ScanArea = value.ObjectString06.ToString();
                if (value.ObjectString09 != null)
                    scanControl.ScanLength = Convert.ToInt32(value.ObjectString09.ToString());

                controlAttribute.Number = iScanIndex.ToString();


                Scans.Add(iScanIndex, scanControl);
                ControlAttributeCollection.Add(controlAttribute.Number, controlAttribute);
                iScanIndex++;
            }

            #endregion 

            foreach (string oStr in oTMPData.Values)
            {   
                UILogDisplay(oStr, "");
            }

            #endregion

            #region PLC
            //string xmlPLCControlPath = xmlPath + "PLCControls.xml";
            string xmlPLCControlPath = xmlPath + siteName + @"\PLCControls.xml";
            Dictionary<string, object> plcControls = new Dictionary<string, object>();
            plcControls = _fileControl.GetConvertXmlPattern(xmlPLCControlPath, "PLCCONTROL");

            //EMP의 PLC는 Simulator의 Scan이 됨. 해당 영역에 Loading 시에 Current 값 적어 주고 주기적으로 읽어서 틀려지면 이벤트 발생.
            int iPLCIndex = 0;
            foreach (string strPLC in plcControls.Keys)
            {
                CReturnObject value = new CReturnObject();
                value = plcControls[strPLC] as CReturnObject;
                CPLCControlPropertiesForSim plcControl = new CPLCControlPropertiesForSim();
                plcControl.PLCControlName = value.ObjectString01.ToString();
                plcControl.PLCAttribute = value.ObjectString02.ToString();
                plcControl.PLCDataType = (enumReadDataType)Enum.Parse(typeof(enumReadDataType), value.ObjectString03.ToString());
                plcControl.PLCDeviceType = (enumDeviceType)Enum.Parse(typeof(enumDeviceType), value.ObjectString04.ToString());
                plcControl.PLCArea = value.ObjectString05.ToString();

                if (plcControl.PLCDeviceType == enumDeviceType.B)
                {
                    plcControl.CurrentBit = DeviceManager.Read(BDevice, int.Parse(Utils.HexToDec(plcControl.PLCArea)), 1) == "0" ? false : true;
                }
                
                Plcs.Add(iPLCIndex, plcControl);
                iPLCIndex++;

            }
            #endregion

            foreach (BaseDevice device in DeviceManager._deviceList.Values)
            {
                if (device.deviceType == DEVICETYPE.BIT && device.name == "B")
                {
                    oScanBitDevice = device;
                    break;
                }
            }

            _scanario = new CScanario("EPM01", _scans, _plcs);
            this.ScanThread = new Thread(new ThreadStart(SCANPLC));
            this.ScanThread.Name = "PLCSimulator/SCAN_THREAD";
            this.ScanThread.IsBackground = true;
            this.ScanThread.Start();

        }

        #region SCAN
        private bool bScan = true;
        private BaseDevice oScanBitDevice = null;
        private void SCANPLC()
        {
            if (Plcs == null) return;

            while (true)
            {
                if (bScan)
                {
                    DateTime start = DateTime.Now;
                    ushort[] oScanData = oScanBitDevice.ArrayRead(0, 65535);                    

                    int iScanCnt = 0;
                    foreach (CPLCControlPropertiesForSim plcControl in Plcs.Values)
                    {
                        if (plcControl.PLCDeviceType != enumDeviceType.B) continue;

                        iScanCnt++;

                        int iAddr = int.Parse(Utils.HexToDec(plcControl.PLCArea));
                        ushort ScanReadValue = oScanData[iAddr];
                        bool ReadValue = ScanReadValue == 1 ? true : false;
                        bool bLog = false;
                        if (plcControl.CurrentBit != ReadValue && ReadValue)
                        {
                            bLog = true;
                            DateTime start1 = DateTime.Now;
                            EventProcHandler del = new EventProcHandler(EventProess);
                            del.BeginInvoke(plcControl.PLCControlName, plcControl.PLCAttribute, null, null);
                        }
                        else if (plcControl.CurrentBit != ReadValue && ReadValue == false)
                        {
                            DateTime start2 = DateTime.Now;

                            EventProcHandler del = new EventProcHandler(EventProessOff);
                            del.BeginInvoke(plcControl.PLCControlName, plcControl.PLCAttribute, null, null); //김성원 추가 bit off 감지 handshake 용도                            
                        }

                        if (bLog) UILogDisplay(plcControl.PLCControlName.ToString() + "  " + plcControl.PLCAttribute + " SET", plcControl.ConnectTMName);

                        if (plcControl.CurrentBit != ReadValue && !ReadValue)
                        {
                            UILogDisplay(plcControl.PLCControlName.ToString() + "  " + plcControl.PLCAttribute + " RESET", plcControl.ConnectTMName);
                        }

                        plcControl.CurrentBit = ReadValue;
                    }
                }

                
                System.Threading.Thread.Sleep(200);

            }
        }

        private delegate void delegateRoutingScenarioSend(string TMControlName);
        private delegate void delegateRoutingScenarioSend2(string TMControlName, string attributeName, bool value);
        private void EventProess(string ControlName, string ControlAttribute)
        {
           if (!Enum.IsDefined(typeof(Att), ControlAttribute))
            {
                throw new ArgumentException();
            }

            Att attribute = (Att)Enum.Parse(typeof(Att), ControlAttribute);

            switch (attribute)
            {
                case Att.OB_RUNNING:
                    this.SetColor(label3, Color.Lime);
                    break;
                case Att.OB_CIM_MODE:
                    this.SetColor(label4, Color.Lime);
                    break;
                case Att.OB_MACHINE_AUTO_MODE:
                    this.SetColor(label2, Color.Lime);
                    break;
                case Att.OB_MACHINE_HEARTBEAT_SIGNAL:
                    this.SetColor(label5, Color.Lime);
                    break;
                case Att.OB_AUTO_RECIPE_CHANGE_MODE:
                    this.SetColor(label6, Color.Lime);
                    break;

                case Att.OB_MACHINE_STATUS_CHANGE_REPORT:                    
                    this.SetColor(label7, Color.Lime);
                    this.SetText(label8, _scanario.EQ_MachineStatus(_scanario.ControlName));
                    this.SetText(label9, _scanario.EQ_MachineReasonCode(_scanario.ControlName));
                    this.SetText(label10, _scanario.EQ_MachineDownAlarmCode(_scanario.ControlName));
                    this.SetText(label11, _scanario.EQ_Unit1Status(_scanario.ControlName));
                    _scanario.BC_MachineStatusChangeReportReply(_scanario.ControlName, true);
                    break;
                case Att.OB_CIM_MODE_CHANGE_COMMAND_REPLY:
                    this.SetColor(label60, Color.Lime);
                    _scanario.EQ_CIMModeChangeReply();
                    break;
                #region LInkType1
                case Att.OB_LINK_DOWN1_RECEIVE_ABLE:
                    this.SetColor(label12, Color.Lime);

                    if (!GetExchangeMode())
                    {
                        _scanario.IDX_IW_JOB_DATA_FOR_DOWNSTREAM_BLOCK1("INDEXER01", this.GetJobData1(true));
                        _scanario.IDX_IW_SENT_OUT_JOB_DATA_SUB_BLOCK1("INDEXER01", "1", "1");

                        Thread.Sleep(1000);
                        this.SetColor(lblRobotSendAble, Color.Lime);
                        _scanario.IDX_LINK_UP1_SEND_ABLE("INDEXER01", true);
                    }
                    else
                    {
                        //exchange 일 경우는 stage send able on 인 경우 write를 함.
                    }

                    break;
                case Att.OB_LINK_DOWN1_RECEIVE_START:
                    this.SetColor(label13, Color.Lime);
                    Thread.Sleep(1000);
                    this.SetColor(lblRobotSendStart, Color.Lime);
                    _scanario.IDX_LINK_UP1_SEND_START("INDEXER01", true);
                    Thread.Sleep(1000);

                    this.SetColor(lblRobotSendJobTransSignal, Color.Lime);
                    _scanario.IDX_LINK_UP1_JOB_TRANSFER_SIGNAL("INDEXER01", true);
                    Thread.Sleep(5000);

                    this.SetColor(lblRootSendComplete, Color.Lime);
                    _scanario.IDX_LINK_UP1_SEND_COMPLETE("INDEXER01", true);
                    break;
                case Att.OB_LINK_DOWN1_RECEIVE_COMPLETE:
                    this.SetColor(label14, Color.Lime);
                    Thread.Sleep(1000);
                    this.SetColor(lblRobotSendAble, Color.Red);
                    _scanario.IDX_LINK_UP1_SEND_ABLE("INDEXER01", false);
                    this.SetColor(lblRobotSendStart, Color.Red);
                    _scanario.IDX_LINK_UP1_SEND_START("INDEXER01", false);
                    this.SetColor(lblRootSendComplete, Color.Red);
                    _scanario.IDX_LINK_UP1_SEND_COMPLETE("INDEXER01", false);
                    this.SetColor(lblRobotSendJobTransSignal, Color.Red);
                    _scanario.IDX_LINK_UP1_JOB_TRANSFER_SIGNAL("INDEXER01", false);
                    if (GetExchangeMode())
                    {
                        this.SetColor(label78, Color.Red);
                        _scanario.IDX_LINK_DOWN1_EXCHANGE_EXECUTE("INDEXER01", false);
                    }
                    break;
                case Att.OB_LINK_UP1_UPSTREAM_INLINE:
                    this.SetColor(label30, Color.Lime);
                    break;
                case Att.OB_LINK_UP1_UPSTREAM_TROUBLE:
                    this.SetColor(label79, Color.Lime);
                    break;
                #endregion
                #region LinkType 5
                case Att.OB_LINK_UP1_SEND_ABLE:
                    this.SetColor(label21, Color.Lime);
                    //INDEXER가 RCMD, JobData Check
                    Thread.Sleep(1000);
                    this.SetColor(label24, Color.Lime);
                    if (GetExchangeMode())
                    {
                        _scanario.IDX_LINK_DOWN1_EXCHANGE_EXECUTE("INDEXER01", true);
                        _scanario.IDX_LINK_DOWN1_RECEIVE_ABLE("INDEXER01", true);
                        Thread.Sleep(20);
                        _scanario.IDX_IW_JOB_DATA_FOR_DOWNSTREAM_BLOCK1("INDEXER01", this.GetJobData1(true));
                        _scanario.IDX_IW_SENT_OUT_JOB_DATA_SUB_BLOCK1("INDEXER01", "1", "1");
                        this.SetColor(lblRobotSendAble, Color.Lime);
                        _scanario.IDX_LINK_UP1_SEND_ABLE("INDEXER01", true);
                    }
                    else
                    {
                        _scanario.IDX_LINK_DOWN1_EXCHANGE_EXECUTE("INDEXER01", false);
                        _scanario.IDX_LINK_DOWN1_RECEIVE_ABLE("INDEXER01", true);
                    }
                    break;
                case Att.OB_LINK_UP1_SEND_START:
                    this.SetColor(label22, Color.Lime);
                    CGlassData glassData = new CGlassData();

                    this.SetJobData2(glassData.GlassDataConvert(_scanario.EQ_OW_JOB_DATA_FOR_DOWNSTREAM_BLOCK1("EPM01")));
                    ushort[] temp = _scanario.EQ_OW_SENT_OUT_JOB_DATA_SUB_BLOCK1("EPM01");

                    Thread.Sleep(1000);
                    this.SetColor(label25, Color.Lime);
                    _scanario.IDX_LINK_DOWN1_RECEIVE_START("INDEXER01", true);
                    Thread.Sleep(1000);//Arm Origin
                    this.SetColor(label29, Color.Lime);
                    _scanario.IDX_LINK_DOWN1_JOB_TRANSFER_SIGNAL("INDEXER01", true);
                    Thread.Sleep(5000);//Arm Folding
                    this.SetColor(label26, Color.Lime);
                    _scanario.IDX_LINK_DOWN1_RECEIVE_COMPLETE("INDEXER01", true);
                    break;
                case Att.OB_LINK_UP1_SEND_COMPLETE:
                    this.SetColor(label23, Color.Lime);
                    Thread.Sleep(1000);
                    this.SetColor(label24, Color.Red);
                    _scanario.IDX_LINK_DOWN1_RECEIVE_ABLE("INDEXER01", false);
                    this.SetColor(label25, Color.Red);
                    _scanario.IDX_LINK_DOWN1_RECEIVE_START("INDEXER01", false);
                    this.SetColor(label26, Color.Red);
                    _scanario.IDX_LINK_DOWN1_RECEIVE_COMPLETE("INDEXER01", false);
                    this.SetColor(label29, Color.Red);
                    _scanario.IDX_LINK_DOWN1_JOB_TRANSFER_SIGNAL("INDEXER01", false);
                    break;
                case Att.OB_LINK_DOWN1_DOWNSTREAM_INLINE:
                    this.SetColor(label31, Color.Lime);
                    break;
                case Att.OB_LINK_DOWN1_DOWNSTREAM_TROUBLE:
                    this.SetColor(label76, Color.Lime);
                    break;
#endregion
                case Att.OB_RECEIVED_JOB_REPORT_UPSTREAMPATH1:
                    this.SetColor(label19, Color.Lime);
                    this.SetColor(label71, Color.Lime);
                    _scanario.BC_ReceivedJobReportReplyUpstreamPath1(true);
                    break;
                case Att.OB_SENT_OUT_JOB_REPORT_DOWNSTREAMPATH1:
                    this.SetColor(label20, Color.Lime);
                    this.SetColor(lblBCSentOutJobReply, Color.Lime);
                    _scanario.BC_SentOutJobReportReplyUpstreamPath1(true);
                    break;
                case Att.OB_RECIPE_PARAMETER_DATA_REPORT:
                    this.SetColor(label58, Color.Lime);
                    _scanario.BC_RecipeParameterReply();
                    break;
                case Att.OB_RECIPE_PARMATER_DOWN_CONFIRM:
                    this.SetColor(label61, Color.Lime);
                    _scanario.BC_RecipeParameterDownReply();
                    break;
                case Att.OB_LIGHT_ALARM_OCCURRED:
                    this.SetColor(label54, Color.Lime);
                    break;
                case Att.OB_MACHINE_CIM_MESSAGE_CONFIRM:
                    this.SetColor(label63, Color.Lime);
                    break;
                case Att.OB_MACHINE_TIME_SET_REPLY:
                    this.SetColor(label66, Color.Lime);
                    _scanario.BC_MachineTimeSetCommand("0", "0", "0", "0", "0", "0", false);
                    break;
                case Att.OB_GLASS_DATA_REQUEST:
                    this.SetColor(label67, Color.Lime);
                    _scanario.EQ_GlassDataRequest(this.GetJobData1(false));
                    this.SetText(label68, _scanario.EQ_GlassDataReqOptione(_scanario.ControlName));
                    this.SetText(label69, _scanario.EQ_GlassDataReqGlassID(_scanario.ControlName));
                    this.SetText(label70, _scanario.EQ_GlassDataReqGlassCode(_scanario.ControlName));
                    break;

                case Att.OB_SCRAP_JOB_REPORT:
                    this.SetColor(label72, Color.Lime);
                    Thread.Sleep(100);
                    this.SetColor(label73, Color.Lime);
                    _scanario.BC_ScrapJobReportReply( true);
                    break;
                case Att.OB_MACHINE_RECIPE_REQUEST:
                    this.SetColor(label74, Color.Lime);
                    Thread.Sleep(100);
                    this.SetColor(label75, Color.Lime);
                    int recipeId = 0;
                    int returnCode = 0;
                    string ppid = "";
                    string unitId = "";
                    ppid= Utils.HexToDec(_scanario.EQ_MachineRecipeReqPPID());
                    unitId = Utils.HexToDec(_scanario.EQ_MachineRecipeReqUnitID());

                    bool existRecipe = false;
                    foreach (string item in textBox18.Lines)
                    {
                        if (item.Contains(ppid + ":"))
                        {
                            string[] splited = item.Split(':');
                            recipeId = int.Parse(splited[1]);
                            returnCode = 1;//OK
                            _scanario.BC_MachineRecipeRequestData(recipeId, returnCode);
                            _scanario.BC_MachineRecipeRequestConfirm(true);
                            existRecipe = true;
                            break;
                        }
                    }
                    if (!existRecipe)
                    {
                        _scanario.BC_MachineRecipeRequestData(0, 2);//2: NG(There are no recipe in list)
                    }
                    _scanario.BC_MachineRecipeRequestConfirm(true);

                    break;
                case Att.OB_LINK_UP1_EXCHANGE_POSSIBLE:
                    this.SetColor(lblStageExchangePossible, Color.Lime);
                    _isExchangePossible = true;
                    break;
                default:
                    
                    break;
            }
        }
        private void EventProessOff(string ControlName, string ControlAttribute)
        {
            if (!Enum.IsDefined(typeof(Att), ControlAttribute))
            {
                throw new ArgumentException();
            }

            Att attribute = (Att)Enum.Parse(typeof(Att), ControlAttribute);
            switch (attribute)
            {
                case Att.OB_RUNNING:
                    this.SetColor(label3, Color.Red);
                    break;
                case Att.OB_CIM_MODE:
                    this.SetColor(label4, Color.Red);
                    break;
                case Att.OB_MACHINE_AUTO_MODE:
                    this.SetColor(label2, Color.Red); 
                    break;
                case Att.OB_MACHINE_HEARTBEAT_SIGNAL:
                    this.SetColor(label5, Color.Yellow);
                    break;
                case Att.OB_AUTO_RECIPE_CHANGE_MODE:
                    this.SetColor(label6, Color.Red);
                    break;
                case Att.OB_MACHINE_STATUS_CHANGE_REPORT:                    
                    _scanario.BC_MachineStatusChangeReportReply(_scanario.ControlName, false);
                    this.SetColor(label7, Color.Red);
                    break;
                case Att.OB_CIM_MODE_CHANGE_COMMAND_REPLY:
                    this.SetColor(label60, Color.Red);
                    break;
                case Att.OB_LINK_DOWN1_RECEIVE_ABLE:
                    this.SetColor(label12, Color.Red);
                    break;
                case Att.OB_LINK_DOWN1_RECEIVE_START:
                    this.SetColor(label13, Color.Red);
                    break;
                case Att.OB_LINK_DOWN1_RECEIVE_COMPLETE:
                    this.SetColor(label14, Color.Red);
                    break;
                case Att.OB_LINK_UP1_UPSTREAM_INLINE:
                    this.SetColor(label30, Color.Red);
                    break;
                case Att.OB_LINK_UP1_UPSTREAM_TROUBLE:
                    this.SetColor(label79, Color.Red);
                    break;
                case Att.OB_LINK_UP1_SEND_ABLE:
                    this.SetColor(label21, Color.Red);
                    
                    break;
                case Att.OB_LINK_UP1_SEND_START:
                    this.SetColor(label22, Color.Red);
                    
                    break;
                case Att.OB_LINK_UP1_SEND_COMPLETE:
                    this.SetColor(label23, Color.Red);
                    
                    break;
                case Att.OB_LINK_DOWN1_DOWNSTREAM_INLINE:
                    this.SetColor(label31, Color.Red);
                    break;
                case Att.OB_LINK_DOWN1_DOWNSTREAM_TROUBLE:
                    this.SetColor(label76, Color.Red);
                    break;
                case Att.OB_RECEIVED_JOB_REPORT_UPSTREAMPATH1:
                    this.SetColor(label19, Color.Red);
                    this.SetColor(label71, Color.Red);
                    _scanario.BC_ReceivedJobReportReplyUpstreamPath1(false);
                    break;
                case Att.OB_SENT_OUT_JOB_REPORT_DOWNSTREAMPATH1:
                    this.SetColor(label20, Color.Red);
                    this.SetColor(lblBCSentOutJobReply, Color.Red);
                    _scanario.BC_SentOutJobReportReplyUpstreamPath1(false);
                    break;
                case Att.OB_RECIPE_PARAMETER_DATA_REPORT:
                    this.SetColor(label58, Color.Red);
                    break;
                case Att.OB_RECIPE_PARMATER_DOWN_CONFIRM:
                    this.SetColor(label61, Color.Red);

                    label62.Text = _scanario.EQ_RecipeParameterDownResult("EPM01");
                    break;
                case Att.OB_MACHINE_CIM_MESSAGE_CONFIRM:
                    this.SetColor(label63, Color.Red);
                    break;
                case Att.OB_MACHINE_TIME_SET_REPLY:
                    this.SetColor(label66, Color.Red);
                    break;
                case Att.OB_GLASS_DATA_REQUEST:
                    this.SetColor(label67, Color.Red);
                    _scanario.BC_GlassDataRequestConfirm(_scanario.ControlName, false);
                    break;
                case Att.OB_SCRAP_JOB_REPORT:
                    this.SetColor(label72, Color.Red);
                    Thread.Sleep(100);
                    this.SetColor(label73, Color.Red);
                    _scanario.BC_ScrapJobReportReply(false);
                    break;
                case Att.OB_MACHINE_RECIPE_REQUEST:
                    this.SetColor(label74, Color.Red);

                    this.SetColor(label75, Color.Red);
                    _scanario.BC_MachineRecipeRequestConfirm(false);
                    break;
                case Att.OB_LINK_UP1_EXCHANGE_POSSIBLE:
                    this.SetColor(lblStageExchangePossible, Color.Red);
                    _isExchangePossible = false;
                    break;
                default:
                    break;
            }
        }
        #endregion

        private bool _isExchange = false;
        private bool _isExchangePossible = false;

        private bool GetExchangeMode()
        {
            return _isExchange && _isExchangePossible;
        }
        private void RemotingInit()
        {
            IDictionary prop = new Hashtable();
            prop["port"] = this.PortNo;


            IChannel _channelInstance = null;
            IChannel chan = null;
            switch (channel)
            {
                case CHANNELTYPE.HTTP:
                    prop["name"] = this.ObjectUri;
                    _channelInstance = ChannelServices.GetChannel(prop["name"].ToString());
                    if (_channelInstance != null)
                    {   
                        ChannelServices.UnregisterChannel(_channelInstance);
                        System.Threading.Thread.Sleep(1000);
                        //return;
                    }
                    chan = new HttpChannel(prop, null, null);
                    ChannelServices.RegisterChannel(chan, false);

                    RemotingConfiguration.RegisterWellKnownServiceType(typeof(PlcRemotingClass), this.ObjectUri, WellKnownObjectMode.Singleton);
                    break;
                case CHANNELTYPE.IPC:
                    _channelInstance = ChannelServices.GetChannel(this.ObjectUri);
                    if (_channelInstance != null)
                    {
                        return;
                    }
                    prop["portName"] = this.ObjectUri;
                    //prop["portName"] = this.ScanRemotingPORT;

                    _channelInstance = ChannelServices.GetChannel(prop["portName"].ToString());
                    if (_channelInstance != null)
                    {
                        ChannelServices.UnregisterChannel(_channelInstance);
                        System.Threading.Thread.Sleep(1000);
                        //return;
                    }

                    chan = new IpcChannel(prop, null, null);
                    ChannelServices.RegisterChannel(chan, false);

                    RemotingConfiguration.RegisterWellKnownServiceType(typeof(PlcRemotingClass), this.ObjectUri, WellKnownObjectMode.Singleton);
                    break;
                case CHANNELTYPE.TCP:
                    prop["name"] = this.ObjectUri;
                    prop["port"] = this.PortNo;
                    _channelInstance = ChannelServices.GetChannel(prop["name"].ToString());
                    if (_channelInstance != null)
                    {
                        ChannelServices.UnregisterChannel(_channelInstance);
                        //Socket이 닫히기를 기다림.
                        System.Threading.Thread.Sleep(1000);
                        //return;
                    }


                    try
                    {
                        chan = new TcpChannel(prop, null, null);

                        ChannelServices.RegisterChannel(chan, false);

                        RemotingConfiguration.RegisterWellKnownServiceType(typeof(PlcRemotingClass), this.ObjectUri, WellKnownObjectMode.Singleton);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                    break;
            }
        }

        #endregion 

        #region Component

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!bNeedGridUpdate) return;

            if (_currentDevice != null)
            {
                DataGridViewUpdate();
            }
        }

        private bool bNeedGridUpdate = false;
        private void tabSIMControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabSIMControl.SelectedIndex == 1)
                bNeedGridUpdate = true;
            else
                bNeedGridUpdate = false;
        }
        #endregion

        #region GridView Data

        private void DataGridViewUpdate()
        {
            try
            {
                if (_currentDevice.deviceType == DEVICETYPE.BIT)
                {
                    switch (_currentDevice.dataFormat)
                    {
                        case DATAFORMAT.BIN:
                            BitBinary();
                            break;
                        case DATAFORMAT.DEC:
                            BitDecimal();
                            break;
                        case DATAFORMAT.HEX:
                            Bithexadecimal();
                            break;
                    }
                }
                else
                {
                    switch (_currentDevice.dataFormat)
                    {
                        case DATAFORMAT.BIN:
                            WordBinary();
                            break;
                        case DATAFORMAT.DEC:
                            WordDecimal();
                            break;
                        case DATAFORMAT.HEX:
                            WordHexadecimal();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                Console.WriteLine(ex.Message);
            }
        }

        private void BitDecimal()
        {
            for (int i = 0; i < 16; i++)
            {
                int makePage = _currentDevice.index + i;
                int startIndex1 = (makePage * 16);
                int startIndex2 = (startIndex1 + 256);
                int startIndex3 = (startIndex2 + 256);
                int startIndex4 = (startIndex3 + 256);
                char[] tempMemory = new char[16];

                string address1 = startIndex1.ToString("X");
                address1 = _currentDevice.name + address1.PadLeft(4, '0');
                string address2 = startIndex2.ToString("X");
                address2 = _currentDevice.name + address2.PadLeft(4, '0');
                string address3 = startIndex3.ToString("X");
                address3 = _currentDevice.name + address3.PadLeft(4, '0');
                string address4 = startIndex4.ToString("X");
                address4 = _currentDevice.name + address4.PadLeft(4, '0');


                Array.ConstrainedCopy(_currentDevice.Memory, startIndex1, tempMemory, 0, 16);
                string grid1 = new string(CharMemoryTo(tempMemory));
                string toDec1 = Utils.BinToHex(grid1);
                toDec1 = Utils.HexToDec(toDec1);
                grid1 = FormatFilter(grid1);
                grid1 = grid1.Trim();
                Array.ConstrainedCopy(_currentDevice.Memory, startIndex2, tempMemory, 0, 16);
                string grid2 = new string(CharMemoryTo(tempMemory));
                string toDec2 = Utils.BinToHex(grid2);
                toDec2 = Utils.HexToDec(toDec2);
                grid2 = FormatFilter(grid2);
                grid2 = grid2.Trim();
                Array.ConstrainedCopy(_currentDevice.Memory, startIndex3, tempMemory, 0, 16);
                string grid3 = new string(CharMemoryTo(tempMemory));
                string toDec3 = Utils.BinToHex(grid3);
                toDec3 = Utils.HexToDec(toDec3);
                grid3 = FormatFilter(grid3);
                grid3 = grid3.Trim();
                Array.ConstrainedCopy(_currentDevice.Memory, startIndex4, tempMemory, 0, 16);
                string grid4 = new string(CharMemoryTo(tempMemory));
                string toDec4 = Utils.BinToHex(grid4);
                toDec4 = Utils.HexToDec(toDec4);
                grid4 = FormatFilter(grid4);
                grid4 = grid4.Trim();
                dataGridView1.Rows[i].SetValues(new string[] { address1, grid1 + "  " + toDec1, address2, grid2 + "  " + toDec2, address3, grid3 + "  " + toDec3, address4, grid4 + "  " + toDec4 });
            }
        }
        private void BitBinary()
        {
            for (int i = 0; i < 16; i++)
            {
                int makePage = _currentDevice.index + i;
                int startIndex1 = (makePage);
                int startIndex2 = (makePage + 16);
                int startIndex3 = (makePage + 32);
                int startIndex4 = (makePage + 48);
                char[] tempMemory = new char[16];

                string address1 = startIndex1.ToString("X");
                address1 = _currentDevice.name + address1.PadLeft(4, '0');
                string address2 = startIndex2.ToString("X");
                address2 = _currentDevice.name + address2.PadLeft(4, '0');
                string address3 = startIndex3.ToString("X");
                address3 = _currentDevice.name + address3.PadLeft(4, '0');
                string address4 = startIndex4.ToString("X");
                address4 = _currentDevice.name + address4.PadLeft(4, '0');

                dataGridView1.Rows[i].SetValues(new string[] { address1, Convert.ToInt32(_currentDevice.Memory[makePage]).ToString(), address2, Convert.ToInt32(_currentDevice.Memory[makePage + 16]).ToString(), address3, Convert.ToInt32(_currentDevice.Memory[makePage + 32]).ToString(), address4, Convert.ToInt32(_currentDevice.Memory[makePage + 48]).ToString() });
            }
        }
        private void Bithexadecimal()
        {
           
                for (int i = 0; i < 16; i++)
                {
                    int makePage = _currentDevice.index + i;
                    int startIndex1 = (makePage * 16);
                    int startIndex2 = (startIndex1 + 256);
                    int startIndex3 = (startIndex2 + 256);
                    int startIndex4 = (startIndex3 + 256);
                    char[] tempMemory = new char[16];

                    string address1 = startIndex1.ToString("X");
                    address1 = _currentDevice.name + address1.PadLeft(4, '0');
                    string address2 = startIndex2.ToString("X");
                    address2 = _currentDevice.name + address2.PadLeft(4, '0');
                    string address3 = startIndex3.ToString("X");
                    address3 = _currentDevice.name + address3.PadLeft(4, '0');
                    string address4 = startIndex4.ToString("X");
                    address4 = _currentDevice.name + address4.PadLeft(4, '0');


                    Array.ConstrainedCopy(_currentDevice.Memory, startIndex1, tempMemory, 0, 16);
                    string grid1 = new string(CharMemoryTo(tempMemory));
                    string toDec1 = Utils.BinToHex(grid1);
                    grid1 = FormatFilter(grid1);
                    grid1 = grid1.Trim();
                    Array.ConstrainedCopy(_currentDevice.Memory, startIndex2, tempMemory, 0, 16);
                    string grid2 = new string(CharMemoryTo(tempMemory));
                    string toDec2 = Utils.BinToHex(grid2);
                    grid2 = FormatFilter(grid2);
                    grid2 = grid2.Trim();
                    Array.ConstrainedCopy(_currentDevice.Memory, startIndex3, tempMemory, 0, 16);
                    string grid3 = new string(CharMemoryTo(tempMemory));
                    string toDec3 = Utils.BinToHex(grid3);
                    grid3 = FormatFilter(grid3);
                    grid3 = grid3.Trim();
                    Array.ConstrainedCopy(_currentDevice.Memory, startIndex4, tempMemory, 0, 16);
                    string grid4 = new string(CharMemoryTo(tempMemory));
                    string toDec4 = Utils.BinToHex(grid4);
                    grid4 = FormatFilter(grid4);
                    grid4 = grid4.Trim();
                    dataGridView1.Rows[i].SetValues(new string[] { address1, grid1 + "  " + toDec1, address2, grid2 + "  " + toDec2, address3, grid3 + "  " + toDec3, address4, grid4 + "  " + toDec4 });
                }
            
        }
        private void WordBinary()
        {
            
                for (int i = 0; i < 16; i++)
                {
                    int makePage = _currentDevice.index + i;
                    int startIndex1 = (makePage);
                    int startIndex2 = (makePage + 16);
                    int startIndex3 = (makePage + 32);
                    int startIndex4 = (makePage + 48);
                    char[] tempMemory = new char[16];

                    string address1 = startIndex1.ToString("X");
                    address1 = _currentDevice.name + address1.PadLeft(4, '0');
                    string address2 = startIndex2.ToString("X");
                    address2 = _currentDevice.name + address2.PadLeft(4, '0');
                    string address3 = startIndex3.ToString("X");
                    address3 = _currentDevice.name + address3.PadLeft(4, '0');
                    string address4 = startIndex4.ToString("X");
                    address4 = _currentDevice.name + address4.PadLeft(4, '0');


                    string grid1 = Convert.ToInt32(_currentDevice.Memory[startIndex1]).ToString();
                    grid1 = Utils.DecToBinary(grid1);
                    grid1 = FormatFilter(grid1);
                    grid1 = grid1.Trim();
                    string grid2 = Convert.ToInt32(_currentDevice.Memory[startIndex2]).ToString();
                    grid2 = Utils.DecToBinary(grid2);
                    grid2 = FormatFilter(grid2);
                    grid2 = grid2.Trim();
                    string grid3 = Convert.ToInt32(_currentDevice.Memory[startIndex3]).ToString();
                    grid3 = Utils.DecToBinary(grid3);
                    grid3 = FormatFilter(grid3);
                    grid3 = grid3.Trim();
                    string grid4 = Convert.ToInt32(_currentDevice.Memory[startIndex4]).ToString();
                    grid4 = Utils.DecToBinary(grid4);
                    grid4 = FormatFilter(grid4);
                    grid4 = grid4.Trim();
                    dataGridView1.Rows[i].SetValues(new string[] { address1, grid1, address2, grid2, address3, grid3, address4, grid4 });
                }
            
        }
        private void WordDecimal()
        {
            for (int i = 0; i < 16; i++)
            {
                int makePage = _currentDevice.index + i;
                int startIndex1 = (makePage);
                int startIndex2 = (makePage + 16);
                int startIndex3 = (makePage + 32);
                int startIndex4 = (makePage + 48);
                char[] tempMemory = new char[16];

                string address1 = startIndex1.ToString("X");
                address1 = _currentDevice.name + address1.PadLeft(4, '0');
                string address2 = startIndex2.ToString("X");
                address2 = _currentDevice.name + address2.PadLeft(4, '0');
                string address3 = startIndex3.ToString("X");
                address3 = _currentDevice.name + address3.PadLeft(4, '0');
                string address4 = startIndex4.ToString("X");
                address4 = _currentDevice.name + address4.PadLeft(4, '0');

                dataGridView1.Rows[i].SetValues(new string[] { address1, Convert.ToInt32(_currentDevice.Memory[makePage]).ToString(), address2, Convert.ToInt32(_currentDevice.Memory[makePage + 16]).ToString(), address3, Convert.ToInt32(_currentDevice.Memory[makePage + 32]).ToString(), address4, Convert.ToInt32(_currentDevice.Memory[makePage + 48]).ToString() });
            }
        }
        private void WordHexadecimal()
        {
            for (int i = 0; i < 16; i++)
            {
                int makePage = _currentDevice.index + i;
                int startIndex1 = (makePage);
                int startIndex2 = (makePage + 16);
                int startIndex3 = (makePage + 32);
                int startIndex4 = (makePage + 48);
                char[] tempMemory = new char[1];

                string address1 = startIndex1.ToString("X");
                address1 = _currentDevice.name + address1.PadLeft(4, '0');
                string address2 = startIndex2.ToString("X");
                address2 = _currentDevice.name + address2.PadLeft(4, '0');
                string address3 = startIndex3.ToString("X");
                address3 = _currentDevice.name + address3.PadLeft(4, '0');
                string address4 = startIndex4.ToString("X");
                address4 = _currentDevice.name + address4.PadLeft(4, '0');

                string grid1 = Convert.ToInt32(_currentDevice.Memory[startIndex1]).ToString();
                string toDec1 = Utils.DecToHex(grid1);
                toDec1 = toDec1.PadLeft(4, '0');
                string grid2 = Convert.ToInt32(_currentDevice.Memory[startIndex2]).ToString();
                string toDec2 = Utils.DecToHex(grid2);
                toDec2 = toDec2.PadLeft(4, '0');
                string grid3 = Convert.ToInt32(_currentDevice.Memory[startIndex3]).ToString();
                string toDec3 = Utils.DecToHex(grid3);
                toDec3 = toDec3.PadLeft(4, '0');
                string grid4 = Convert.ToInt32(_currentDevice.Memory[startIndex4]).ToString();
                string toDec4 = Utils.DecToHex(grid4);
                toDec4 = toDec4.PadLeft(4, '0');
                dataGridView1.Rows[i].SetValues(new string[] { address1, toDec1, address2, toDec2, address3, toDec3, address4, toDec4 });
            }
        }
        private string FormatFilter(string value)
        {
            string retValue = "";
            for (int i = 0; i < value.Length; i++)
            {
                if (i % 4 == 0)
                {
                    retValue = retValue.Insert(retValue.Length, " ");
                }
                retValue = retValue.Insert(retValue.Length, value[i].ToString());
            }
            return retValue;
        }
        private char[] CharMemoryTo(char[] Memory)
        {
            char[] chArray = Array.ConvertAll<char, char>(Memory, new Converter<char, char>(CharToString));
            return chArray;
        }
        private char CharToString(char charray)
        {
            int i = Convert.ToInt32(charray);
            return Convert.ToChar(i.ToString());
        }

        private void Draw(int count)
        {
            int _width = (this.Width / count);
            int _half = _width / 2;
            bool flag = true;
            //if (count == 4)
            //{
            foreach (DataGridViewTextBoxColumn Column in dataGridView1.Columns)
            {
                if (flag)
                {
                    Column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    Column.Width = _half;
                    flag = false;
                }
                else
                {
                    Column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    Column.Width = _width + _half;
                    flag = true;
                }
            }

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Draw(count);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_currentDevice == null || e.ColumnIndex < 0 || e.RowIndex < 0)
            {
                return;
            }

            int columnIndex = e.ColumnIndex;
            int rowIndex = e.RowIndex;
            string index = GetAddress(rowIndex, columnIndex);

            if (_currentDevice.deviceType == DEVICETYPE.WORD)
            {
                FormDataChange formDataChange = new FormDataChange(_currentDevice, index);
                DialogResult result = formDataChange.ShowDialog();

                if (result == DialogResult.OK)
                {

                }
            }
            else
            {
                if (_currentDevice.dataFormat == DATAFORMAT.BIN)
                {
                    int _currentData = Convert.ToInt32(_currentDevice.Memory[Convert.ToInt32(index)]);
                    string _trigger = "";
                    if (_currentData == 1)
                    {
                        _trigger = "OFF";
                    }
                    else
                    {
                        _trigger = "ON";
                    }
                    DialogResult result = MessageBox.Show("Change the device " + _currentDevice.name + " " + Utils.DecToHex(index) + " to " + _trigger + "." + "\nAll right?", "Data Changing", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        if (_currentData == 1)
                        {
                            _currentDevice.Memory[Convert.ToInt32(index)] = (char)0;
                        }
                        else
                        {
                            _currentDevice.Memory[Convert.ToInt32(index)] = (char)1;
                        }
                    }
                }
            }
        }

        private string GetAddress(int row, int col)
        {
            string result = "";
            int address = _currentDevice.index + ((col / 2) * 16) + row;
            if (address == -1)
            {
                throw new Exception("address error");
            }
            result = address.ToString();
            return result;
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            _currentDevice.index = e.NewValue;            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void DataWrite(bool isBitType, string Address, string WriteData, string DeviceType)
        {
            if (DeviceType == "PLC")
            {
                if (isBitType)
                {
                    if (WriteData == "ON")
                    {
                        DeviceManager.Write(BDevice, int.Parse(Address), 1, "1");
                    }
                    else
                    {
                        DeviceManager.Write(BDevice, int.Parse(Address), 1, "0");
                    }
                }
                else
                {
                    DeviceManager.Write(WDevice, int.Parse(Address), 1, WriteData);
                }
            }
            else if (DeviceType == "CCLINK")
            {
                if (WriteData == "ON")
                {
                    DeviceManager.Write("1", int.Parse(Address), 1, "1");
                }
                else
                {
                    DeviceManager.Write("1", int.Parse(Address), 1, "0");
                }
            }
        }

        void _fScenario_ScenarioDataSend(bool isBitType, string Address, string WriteData, string DeviceType)
        {
            DataWrite(isBitType, Address, WriteData, DeviceType);
        }

        private void btnScenarioMode_Click(object sender, EventArgs e)
        {
            FormScenario _fScenario = new FormScenario();
            _fScenario.ScenarioDataSend += new FormScenario.delegateScenarioDataSend(_fScenario_ScenarioDataSend);
            _fScenario.ShowDialog(this);
        }

        private void btnDeviceSetting_Click(object sender, EventArgs e)
        {
            if (formDevice == null)
            {
                formDevice = new FormDevice();
            }

            DialogResult result = formDevice.ShowDialog();
            if (result == DialogResult.OK)
            {
                _currentDevice = formDevice.Device;
                //if (_currentDevice.index > 65480)
                //{
                //    _currentDevice.index = 65480;
                //}
                hScrollBar1.Maximum = _currentDevice.maxIndex;
                hScrollBar1.Value = _currentDevice.index;
                this.labelDevice.Text = "Device Type : " + _currentDevice.name;
                this.labelDataType.Text = "Data Format : " + _currentDevice.dataFormat.ToString();

                ChangeDataTypeColor();
            }
        }

        private void ChangeDataTypeColor()
        {
            lbHEX.BackColor = Color.LightGray;
            lbBIN.BackColor = Color.LightGray;
            lbDEC.BackColor = Color.LightGray;
            if (_currentDevice.dataFormat == DATAFORMAT.HEX)
                lbHEX.BackColor = Color.LightGreen;
            else if (_currentDevice.dataFormat == DATAFORMAT.BIN)
                lbBIN.BackColor = Color.LightGreen;
            else if (_currentDevice.dataFormat == DATAFORMAT.DEC)
                lbDEC.BackColor = Color.LightGreen;
        }

        private void lbBIN_Click(object sender, EventArgs e)
        {
            try
            {
                if (_currentDevice == null)
                {
                    return;
                }
                hScrollBar1.Maximum = _currentDevice.maxIndex;
                hScrollBar1.Value = _currentDevice.index;
                _currentDevice.dataFormat = DATAFORMAT.BIN;
                this.labelDataType.Text = "Data Format : " + _currentDevice.dataFormat.ToString();

                ChangeDataTypeColor();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void lbDEC_Click(object sender, EventArgs e)
        {
            if (_currentDevice == null)
            {
                return;
            }
            if (_currentDevice.deviceType == DEVICETYPE.BIT)
            {
                _currentDevice.maxIndex = 4032;
                if (_currentDevice.index > _currentDevice.maxIndex)
                {
                    _currentDevice.index = _currentDevice.maxIndex;
                }
                hScrollBar1.Maximum = _currentDevice.maxIndex;
                hScrollBar1.Value = _currentDevice.index;
            }
            _currentDevice.dataFormat = DATAFORMAT.DEC;
            this.labelDataType.Text = "Data Format : " + _currentDevice.dataFormat.ToString();

            ChangeDataTypeColor();
        }

        private void lbHEX_Click(object sender, EventArgs e)
        {
            if (_currentDevice == null)
            {
                return;
            }
            if (_currentDevice.deviceType == DEVICETYPE.BIT)
            {
                _currentDevice.maxIndex = 4032;
                if (_currentDevice.index > _currentDevice.maxIndex)
                {
                    _currentDevice.index = _currentDevice.maxIndex;
                }
                hScrollBar1.Maximum = _currentDevice.maxIndex;
                hScrollBar1.Value = _currentDevice.index;
            }
            _currentDevice.dataFormat = DATAFORMAT.HEX;
            this.labelDataType.Text = "Data Format : " + _currentDevice.dataFormat.ToString();

            ChangeDataTypeColor();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        #endregion 

        private void SetColor(Control control, Color color)
        {
            SetColorHandler del = new SetColorHandler(InternalSetColor);
            this.Invoke(del, control, color);
        }
        private void InternalSetColor(Control control, Color color)
        {
            control.BackColor = color;
        }
        private void SetText(Control control, string text)
        {
            SetTextHandler del = new SetTextHandler(InternalSetText);
            this.Invoke(del, control, text);
        }
        private void InternalSetText(Control control, string text)
        {
            control.Text = text;
        }
        public delegate void CrossThreadHandleDelegate();
        public delegate void EventProcHandler(string controlName, string controlAttribute);
        public delegate void SetColorHandler(Control control, Color color);
        public delegate void SetTextHandler(Control control, string text);

        public List<int> ENCAPGLASSCODE = new List<int>();
        public delegate void ScanResultWrite(string result);
        public delegate void ResultWrite(string result, string TMName);
        private void UILogDisplay(string value, string TMName)
        {
            if (txtScannerLog.InvokeRequired)
            {
                ResultWrite d = new ResultWrite(UILogDisplay);
                try
                {
                    this.Invoke(d, new string[] { value, TMName });
                }
                catch
                {
                }
            }
            else
            {
                if (value.Contains("ENCAPGLASS_"))
                {
                    int iEncapGlassCode = int.Parse(value.Split(char.Parse("_"))[1]);
                    if (!ENCAPGLASSCODE.Contains(iEncapGlassCode))
                        ENCAPGLASSCODE.Add(iEncapGlassCode);
                    return;
                }            

                if (!bLogging) return;

                txtScannerLog.AppendText(DateTime.Now.ToString("[yyyy-MM-dd hh:mm:ss.fff] : "));
                txtScannerLog.AppendText(value + "\r\n");
                txtScannerLog.ScrollToCaret();
                txtScannerLog.Focus();

                if (txtScannerLog.Text.Length > 655350)
                {
                    txtScannerLog.Text = txtScannerLog.Text.Substring(32680, txtScannerLog.Text.Length - 32680);
                }

                if (string.IsNullOrEmpty(TMName)) return;                                
            }
        }


        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           _scanario.BC_CIMModeChangeCommand(comboBox1.Text.Split(':')[0], true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _scanario.BC_CIMModeChangeCommand("0", false);
        }

        private void label28_Click(object sender, EventArgs e)
        {
            Control control = sender as Control;
            if (control.BackColor != Color.Lime)
            {
                this.SetColor(control, Color.Lime);
                _scanario.IDX_LINK_DOWNSTREAM_INLINE("INDEXER01", true);
            }
            else
            {
                this.SetColor(control, Color.Red);
                _scanario.IDX_LINK_DOWNSTREAM_INLINE("INDEXER01", false);
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Control control = sender as Control;
            if (control.BackColor != Color.Lime)
            {
                this.SetColor(control, Color.Lime);
                _scanario.IDX_LINK_UP1_SEND_ABLE("INDEXER01", true);
            }
            else
            {
                this.SetColor(control, Color.Red);
                _scanario.IDX_LINK_UP1_SEND_ABLE("INDEXER01", false);
            }

        }

        private void label16_Click(object sender, EventArgs e)
        {
            Control control = sender as Control;
            if (control.BackColor != Color.Lime)
            {
                this.SetColor(control, Color.Lime);
                _scanario.IDX_LINK_UP1_SEND_START("INDEXER01", true);
            }
            else
            {
                this.SetColor(control, Color.Red);
                _scanario.IDX_LINK_UP1_SEND_START("INDEXER01", false);
            }
        }

        private void label17_Click(object sender, EventArgs e)
        {
            Control control = sender as Control;
            if (control.BackColor != Color.Lime)
            {
                this.SetColor(control, Color.Lime);
                _scanario.IDX_LINK_UP1_SEND_COMPLETE("INDEXER01", true);
            }
            else
            {
                this.SetColor(control, Color.Red);
                _scanario.IDX_LINK_UP1_SEND_COMPLETE("INDEXER01", false);
            }
        }

        private void label18_Click(object sender, EventArgs e)
        {
            Control control = sender as Control;
            if (control.BackColor != Color.Lime)
            {
                this.SetColor(control, Color.Lime);
                _scanario.IDX_LINK_UP1_JOB_TRANSFER_SIGNAL("INDEXER01", true);
            }
            else
            {
                this.SetColor(control, Color.Red);
                _scanario.IDX_LINK_UP1_JOB_TRANSFER_SIGNAL("INDEXER01", false);
            }
        }

        private void label27_Click(object sender, EventArgs e)
        {
            Control control = sender as Control;
            if (control.BackColor != Color.Lime)
            {
                this.SetColor(control, Color.Lime);
                _scanario.IDX_LINK_UPSTREAM_INLINE("INDEXER01", true);
            }
            else
            {
                this.SetColor(control, Color.Red);
                _scanario.IDX_LINK_UPSTREAM_INLINE("INDEXER01", false);
            }
        }

        private void label24_Click(object sender, EventArgs e)
        {
            Control control = sender as Control;
            if (control.BackColor != Color.Lime)
            {
                this.SetColor(control, Color.Lime);
                _scanario.IDX_LINK_DOWN1_RECEIVE_ABLE("INDEXER01", true);
            }
            else
            {
                this.SetColor(control, Color.Red);
                _scanario.IDX_LINK_DOWN1_RECEIVE_ABLE("INDEXER01", false);
            }
        }

        private void label25_Click(object sender, EventArgs e)
        {
            Control control = sender as Control;
            if (control.BackColor != Color.Lime)
            {
                this.SetColor(control, Color.Lime);
                _scanario.IDX_LINK_DOWN1_RECEIVE_START("INDEXER01", true);
            }
            else
            {
                this.SetColor(control, Color.Red);
                _scanario.IDX_LINK_DOWN1_RECEIVE_START("INDEXER01", false);
            }
        }
        private void label29_Click(object sender, EventArgs e)
        {
            Control control = sender as Control;
            if (control.BackColor != Color.Lime)
            {
                this.SetColor(control, Color.Lime);
                _scanario.IDX_LINK_DOWN1_JOB_TRANSFER_SIGNAL("INDEXER01", true);
            }
            else
            {
                this.SetColor(control, Color.Red);
                _scanario.IDX_LINK_DOWN1_JOB_TRANSFER_SIGNAL("INDEXER01", false);
            }
        }
        private void label26_Click(object sender, EventArgs e)
        {
            Control control = sender as Control;
            if (control.BackColor != Color.Lime)
            {
                this.SetColor(control, Color.Lime);
                _scanario.IDX_LINK_DOWN1_RECEIVE_COMPLETE("INDEXER01", true);
            }
            else
            {
                this.SetColor(control, Color.Red);
                _scanario.IDX_LINK_DOWN1_RECEIVE_COMPLETE("INDEXER01", false);
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            textBox6.Text = textBox7.Text + textBox8.Text;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            textBox6.Text = textBox7.Text + textBox8.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void SetJobData1(CGlassData glassData)
        {
            SetText(textBox3,glassData.LotID);
            SetText(textBox4,glassData.GlassID);
            SetText(textBox5,glassData.OperID);
            SetText(textBox6,glassData.GlassCode.ToString());
            SetText(textBox7,glassData.GlassCodeXXYYYY.ToString());
            SetText(textBox8,glassData.GlassCodeZZZ.ToString());
            SetText(textBox9,glassData.GlassJudgeCode);
            SetText(textBox10,glassData.PPID.ToString());
            SetText(textBox11,glassData.ProdID);
            SetText(textBox12,glassData.CIMPCData);
            SetText(textBox13,glassData.ProcFlag);
            SetText(textBox14,glassData.JudgeFlag);
            SetText(textBox15,glassData.SkipFlag);
            SetText(textBox16,glassData.InspectionFlag);
            SetText(textBox17,glassData.Mode);
            //SetText(textBox18,glassData.GlassType);
            SetText(textBox2,glassData.DummyType);
            SetText(textBox27,glassData.PanelGradeCode);
            SetText(textBox28,glassData.ArrayRepairRule);
            SetText(textBox19,glassData.ReservedData);
        }
        private void SetJobData2(CGlassData glassData)
        {
            SetText(textBox32,glassData.LotID);
            SetText(textBox33,glassData.GlassID);
            SetText(textBox34,glassData.OperID);
            //SetText(textBox35,glassData.GlassCode.ToString());
            SetText(textBox36,glassData.GlassCodeXXYYYY.ToString());
            SetText(textBox37,glassData.GlassCodeZZZ.ToString());
            SetText(textBox38,glassData.GlassJudgeCode);
            SetText(textBox39,glassData.PPID.ToString());
            SetText(textBox40,glassData.ProdID);
            SetText(textBox41,glassData.CIMPCData);
            SetText(textBox42,glassData.ProcFlag);
            SetText(textBox43,glassData.JudgeFlag);
            SetText(textBox44,glassData.SkipFlag);
            SetText(textBox45,glassData.InspectionFlag);
            SetText(textBox46,glassData.Mode);
            //SetText(textBox47,glassData.GlassType);
            SetText(textBox29,glassData.DummyType);
            SetText(textBox30,glassData.PanelGradeCode);
            SetText(textBox31,glassData.ArrayRepairRule);
            SetText(textBox48,glassData.ReservedData);
        }
        private void SetJobData3(CGlassData glassData)
        {
            SetText(textBox52,glassData.LotID);
            SetText(textBox53,glassData.GlassID);
            SetText(textBox54,glassData.OperID);
            //SetText(textBox55,glassData.GlassCode.ToString());
            SetText(textBox56,glassData.GlassCodeXXYYYY.ToString());
            SetText(textBox57,glassData.GlassCodeZZZ.ToString());
            SetText(textBox58,glassData.GlassJudgeCode);
            SetText(textBox59,glassData.PPID.ToString());
            SetText(textBox60,glassData.ProdID);
            SetText(textBox61,glassData.CIMPCData);
            SetText(textBox62,glassData.ProcFlag);
            SetText(textBox63,glassData.JudgeFlag);
            SetText(textBox64,glassData.SkipFlag);
            SetText(textBox65,glassData.InspectionFlag);
            SetText(textBox66,glassData.Mode);
            //SetText(textBox67,glassData.GlassType);
            SetText(textBox49,glassData.DummyType);
            SetText(textBox50,glassData.PanelGradeCode);
            SetText(textBox51,glassData.ArrayRepairRule);
            SetText(textBox68,glassData.ReservedData);

        }

        private CGlassData GetJobData1(bool nextGlassID)
        {
            CGlassData glassData = new CGlassData();
            glassData.LotID = textBox3.Text;
            
            int count = 0;

            if (int.TryParse(textBox4.Text, out count))
            {
                if(nextGlassID)
                    count++;

                SetText(textBox4, count.ToString());
            }
            else
            {
                SetText(textBox4, "1");
            }
            glassData.GlassID = count.ToString();
            glassData.OperID = textBox5.Text;
            //glassData.GlassCode = int.Parse(textBox6.Text);
            glassData.GlassCodeXXYYYY = 1;// int.Parse(textBox7.Text);
            glassData.GlassCodeZZZ = 34584;// int.Parse(textBox8.Text);
            glassData.GlassJudgeCode = textBox9.Text;
            glassData.PPID = int.Parse(textBox10.Text);
            glassData.ProdID = textBox11.Text;
            glassData.CIMPCData = textBox12.Text;
            glassData.ProcFlag = textBox13.Text;
            glassData.JudgeFlag = textBox14.Text;
            glassData.SkipFlag = textBox15.Text;
            glassData.InspectionFlag = textBox16.Text;
            glassData.Mode = textBox17.Text;
            glassData.GlassType = textBox1.Text + textBox20.Text + textBox21.Text + textBox22.Text + textBox23.Text + textBox24.Text + textBox25.Text + textBox26.Text;
            glassData.DummyType = textBox2.Text;
            glassData.PanelGradeCode = textBox27.Text;
            glassData.ArrayRepairRule = textBox28.Text;
            glassData.ReservedData = textBox19.Text;
            return glassData;
        }
        private CGlassData GetJobData2()
        {
            CGlassData glassData = new CGlassData();
            glassData.LotID = textBox32.Text;
            glassData.GlassID = textBox33.Text;
            glassData.OperID = textBox34.Text;
            //glassData.GlassCode = int.Parse(textBox35.Text);
            glassData.GlassCodeXXYYYY = int.Parse(textBox36.Text);
            glassData.GlassCodeZZZ = int.Parse(textBox37.Text);
            glassData.GlassJudgeCode = textBox38.Text;
            glassData.PPID = int.Parse(textBox39.Text);
            glassData.ProdID = textBox40.Text;
            glassData.CIMPCData = textBox41.Text;
            glassData.ProcFlag = textBox42.Text;
            glassData.JudgeFlag = textBox43.Text;
            glassData.SkipFlag = textBox44.Text;
            glassData.InspectionFlag = textBox45.Text;
            glassData.Mode = textBox46.Text;
            glassData.GlassType = textBox69.Text + textBox70.Text + textBox71.Text + textBox72.Text + textBox76.Text + textBox73.Text + textBox74.Text + textBox75.Text;
            glassData.DummyType = textBox29.Text;
            glassData.PanelGradeCode = textBox30.Text;
            glassData.ArrayRepairRule = textBox31.Text;
            glassData.ReservedData = textBox48.Text;
            return glassData;
        }
        private CGlassData GetJobData3()
        {
            CGlassData glassData = new CGlassData();
            glassData.LotID = textBox52.Text;
            glassData.GlassID = textBox53.Text;
            glassData.OperID = textBox54.Text;
            //glassData.GlassCode = int.Parse(textBox55.Text);
            glassData.GlassCodeXXYYYY = int.Parse(textBox56.Text);
            glassData.GlassCodeZZZ = int.Parse(textBox57.Text);
            glassData.GlassJudgeCode = textBox58.Text;
            glassData.PPID = int.Parse(textBox59.Text);
            glassData.ProdID = textBox60.Text;
            glassData.CIMPCData = textBox61.Text;
            glassData.ProcFlag = textBox62.Text;
            glassData.JudgeFlag = textBox63.Text;
            glassData.SkipFlag = textBox64.Text;
            glassData.InspectionFlag = textBox65.Text;
            glassData.Mode = textBox66.Text;
            glassData.GlassType = textBox77.Text + textBox78.Text + textBox79.Text + textBox80.Text + textBox84.Text + textBox81.Text + textBox82.Text + textBox83.Text;
            glassData.DummyType = textBox49.Text;
            glassData.PanelGradeCode = textBox50.Text;
            glassData.ArrayRepairRule = textBox51.Text;
            glassData.ReservedData = textBox68.Text;
            return glassData;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _scanario.BC_RecipeParameterRequest(textBox85.Text, textBox86.Text, true);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _scanario.BC_RecipeParameterRequest("0", textBox86.Text, false);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            _scanario.BC_RecipeParameterDownload(textBox87.Text, textBox87.Text.Split(','),  true);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string[] temp = new string[textBox87.Text.Split(',').Length];

            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = "0";
            }
            _scanario.BC_RecipeParameterDownload("0", temp, false);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            _scanario.BC_CIMMessageSetCommand(textBox89.Text, textBox90.Text, textBox91.Text, true);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            _scanario.BC_CIMMessageSetCommand("0", "0", "                                ", false);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            _scanario.BC_CIMMessageClearCommand(textBox89.Text, textBox90.Text, true);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            _scanario.BC_CIMMessageClearCommand("0", "0", false);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            _scanario.BC_MachineTimeSetCommand(textBox92.Text, textBox93.Text, textBox94.Text, textBox95.Text, textBox96.Text, textBox97.Text, true);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            _scanario.BC_MachineTimeSetCommand("0", "0", "0", "0", "0", "0", false);
        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            _systemConfig.PPIDRecipe = textBox18.Lines;
        }

        private void label75_Click(object sender, EventArgs e)
        {
            Control control = sender as Control;
            if (control.BackColor != Color.Lime)
            {
                this.SetColor(control, Color.Lime);
                _scanario.BC_MachineRecipeRequestConfirm(true);
            }
            else
            {
                this.SetColor(control, Color.Red);
                _scanario.BC_MachineRecipeRequestConfirm(false);
            }
        }

        private void chkExchange_CheckedChanged(object sender, EventArgs e)
        {
            _isExchange = chkExchange.Checked;
        }

        private void label80_Click(object sender, EventArgs e)
        {
            Control control = sender as Control;
            if (control.BackColor != Color.Lime)
            {
                this.SetColor(control, Color.Lime);
                _scanario.IDX_LINK_DOWNSTREAM_TROUBLE("INDEXER01", true);
            }
            else
            {
                this.SetColor(control, Color.Red);
                _scanario.IDX_LINK_DOWNSTREAM_TROUBLE("INDEXER01", false);
            }
        }

        private void label78_Click(object sender, EventArgs e)
        {
            Control control = sender as Control;
            if (control.BackColor != Color.Lime)
            {
                this.SetColor(control, Color.Lime);
                _scanario.IDX_LINK_DOWN1_EXCHANGE_EXECUTE("INDEXER01", true);
            }
            else
            {
                this.SetColor(control, Color.Red);
                _scanario.IDX_LINK_DOWN1_EXCHANGE_EXECUTE("INDEXER01", false);
            }
        }

        private void label77_Click(object sender, EventArgs e)
        {
            Control control = sender as Control;
            if (control.BackColor != Color.Lime)
            {
                this.SetColor(control, Color.Lime);
                _scanario.IDX_LINK_UPSTREAM_TROUBLE("INDEXER01", true);
            }
            else
            {
                this.SetColor(control, Color.Red);
                _scanario.IDX_LINK_UPSTREAM_TROUBLE("INDEXER01", false);
            }
        }
    }
}