using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.InteropServices;
using System.Threading;

using SmartDevice.UTILS;
using SOFD.InterfaceTimeout;
using SOFD.Properties;
using SOFD.File;
using SOFD.Driver;
using SOFD.DataConvert;
using SOFD.Component.Interface;
using SOFD.Logger;
using SOFD.Core;


using MainLibrary.LogFormat;
using MainLibrary.Global;
using MainLibrary.Manager;
using MainLibrary.Property;

using SOFD.Core.LogFormat;

using YANGSYS.ControlLib;
using SOFD.Component;
using YANGSYS.CommDrv;

using System.Windows.Forms;
using System.Runtime.Remoting;
using SOFD.Global.Manager;
using SmartDevice;
using System.IO;


namespace MainLibrary
{

    #region delegate's

    public delegate void delegateHeavyAlarmChanged(object sender, CAlarmProperties alarm, bool value);
    public delegate void delegateLightAlarmChanged(object sender, CAlarmProperties alarm, bool value);
    public delegate void delegateMessageOccurrenced(object sender, string title, string contents);
    public delegate void delegateMessageOccurrenced2(object sender, string title, string contents);
    public delegate void delegateMultiMessaageOccurrenced(object sender, CErrorReasonList content);

    public delegate void delegateAlarmMessageOccurrenced(object sender, CAlarmPropertiesCollection alarms);

    public delegate void delegatePortDataGridViewChange(object sender, bool value);
    public delegate void delegateEqpLinkTestChanged(object sender, string controlName, bool value);

    public delegate void delegatePortCountChanged(object sender, bool value, string controlName);

    public delegate void delegateEQPCIMMasterModeChanged(object sender, string controlName, bool value);
    public delegate void delegateScreenUILogWrite(string controlName, string strMsg);

    #endregion

    #region //B2 추가
    public delegate void delegateEqpBuzzerOffCommand(bool value);
    #endregion
    /// <summary>
    /// tttt
    /// </summary>

    public partial class CMain : CMainCore
    {
        #region Constructor
        public CMain()
        {
            this.FileManager.OnControlAddChange += new SOFD.BasicCore.delegateControlAddChange(FileManager_OnControlAddChange);
        }
        #endregion

        #region Memebers

        private CDataManager _DataManager = null;

        private CMaterialDataCollection _materials = new CMaterialDataCollection();
        private CLotDataPropertiesCollection _lotDatas = new CLotDataPropertiesCollection();
        private CSystemConfigProperties _systemConfig = new CSystemConfigProperties();

        private CIndexerControlCollection _indexers = new CIndexerControlCollection();
        private CProbeControlCollection _probe = new CProbeControlCollection();

        private List<CAlarmProperties> _alarms = new List<CAlarmProperties>();

        public List<CAlarmProperties> Alarms
        {
            get { return _alarms; }
        }

        private YangSysCommDrv _driver = null;

        public SOFD.Global.Interface.IDriver Driver
        {
            get { return _driver; }
        }

        public CPLCControlPropertiesCollection _YANSYS_PLCCONTEROLS = new CPLCControlPropertiesCollection();
        public CScanControlPropertiesCollections _YANSYS_SCANCONTEROLS = new CScanControlPropertiesCollections();
        public CIControlAttributeCollection _YANSYS_CONTROLATTRIBUTES = new CIControlAttributeCollection();

        #endregion

        #region Properties

        public CSystemConfigProperties SystemConfig
        {
            get { return _systemConfig; }
            set { _systemConfig = value; }
        }

        public CIndexerControlCollection Indexers
        {
            get { return _indexers; }
            set { _indexers = value; }
        }

        public CProbeControlCollection Probes
        {
            get { return _probe; }
            set { _probe = value; }
        }

        public CDataManager DataManager
        {
            get { return _DataManager; }
            set { _DataManager = value; }
        }

        public CMaterialDataCollection Materials
        {
            get { return _materials; }
            set { _materials = value; }
        }

        public CLotDataPropertiesCollection LotDatas
        {
            get { return _lotDatas; }
            set { _lotDatas = value; }
        }

        #endregion

        #region Event's
        public event delegateMessageOccurrenced OnMessageOccurrenced = null;
        public event delegateMessageOccurrenced2 OnFatalMessageOccurrenced = null;
        public event delegateAlarmMessageOccurrenced OnAlarmMessageOccurrenced = null;
        #endregion

        #region Initialize

        new private void FileManager_OnControlAddChange(object obj)
        {
            try
            {
                if (obj is CIndexerControl)
                {
                    CIndexerControl indexer = obj as CIndexerControl;
                    this.Indexers.Add(indexer.ControlName, indexer);
                }
                else if (obj is CProbeControl)
                {
                    CProbeControl probe = obj as CProbeControl;
                    this.Probes.Add(probe.ControlName, probe);
                }
            }
            catch (Exception ex)
            {
                CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, CExceptionLogFormat.DEFAULT_KEY, ex));
            }
        }

        public void Init()
        {
            InitializeConfigFile();
            //ACustomPropertyContainer.CustomPropertyConfig = new CCustomPropertyConfig(this.FileManager.FileControl, Application.StartupPath + "\\CustomProperties.xml");
            //bool bResult = InitializeDataBase(SystemConfig.DBPath, SystemConfig.DBLogPath, SystemConfig.DBName, SystemConfig.DBLogName);

            // Host Connection
            try
            {
                //Glass Data 관련한 처리 로직 (Melsec to GlassDataProperties, GlassDataProties to Melsec)
                DataManager = new CDataManager();
            }
            catch (Exception ex)
            {
                if (OnFatalMessageOccurrenced != null)
                    OnFatalMessageOccurrenced(this, "시스템 오류", "DATABASE와 연결이 정상적으로 진행되지 않았습니다.\n\n" + ex.StackTrace);
            }

            this.SystemMode = (SOFD.BasicCore.enumSystemMode)Enum.Parse(typeof(SOFD.BasicCore.enumSystemMode), this.SystemConfig.SystemMode);

            this.InitializePLCControlFile();
            this.InitializeScanControlFile();
            _YANSYS_PLCCONTEROLS = GetPLCControlInfo(Application.StartupPath + "\\Config\\YANGSYS.PLCControls.xml");
            _YANSYS_SCANCONTEROLS = GetScanControlInfo(Application.StartupPath + "\\Config\\YANGSYS.ScanControls.xml");

            this.InitializeControlFile("");
            this.InitializeAlarms();
            this.ScanEventHandler();
            this.InitializeMelsecNetDriver(this.SystemMode);
            this.MelsecNetDriverOpen();
            this.MelsecNetScanStart();

            string mode = "Server";// "Client";
            string ip = "127.0.0.1";
            string port = "7000";

            string yesConnectionString = this.GetCustomProperty("YESDRV", "CONNECTION_STRING", string.Format("DriverName={0},Mode={1},RemoteIP={2},RemotePort={3},LocalIP={2},LocalPort={3}", "SIMULATOR", mode, ip, port), "양전자 SYSTEM TCP/IP 접속");

            _driver = new YangSysCommDrv("EPM01", _YANSYS_CONTROLATTRIBUTES, _YANSYS_SCANCONTEROLS);
            _driver.Init(yesConnectionString);
            _driver.OnErrorException += new ErrorException(_driver_OnErrorException);
            _driver.Start();

            GetCustomPropertiesData();
            GetRcpParameterList();
            LoadCIMMessageHistory();
        }

        void _driver_OnErrorException(string message)
        {
            SystemConfig.YANG_Communi = false;

            _driver.ReStart();
        }

        public CAlarmDataCollection AlarmDatas = new CAlarmDataCollection();
        private void InitializeAlarms()
        {
            AlarmDatas.Add("990", new CAlarmWHTM().SetProperties(new Dictionary<string, string>() { { "ControlName", "EPM01" }, { "AlarmID", "990" }, { "AlarmCode", "2" }, { "AlarmLevel", "Light" }, { "AlarmTextUsingFlag", "1" }, { "AlarmText", "Unknown Alarm" } }) as AAlarmData);
            AlarmDatas.Add("991", new CAlarmWHTM().SetProperties(new Dictionary<string, string>() { { "ControlName", "EPM01" }, { "AlarmID", "991" }, { "AlarmCode", "2" }, { "AlarmLevel", "Light" }, { "AlarmTextUsingFlag", "1" }, { "AlarmText", "Link Signal Timeout Error T1 30 sec" } }) as AAlarmData);
            AlarmDatas.Add("992", new CAlarmWHTM().SetProperties(new Dictionary<string, string>() { { "ControlName", "EPM01" }, { "AlarmID", "992" }, { "AlarmCode", "2" }, { "AlarmLevel", "Light" }, { "AlarmTextUsingFlag", "1" }, { "AlarmText", "Link Signal Timeout Error T2 3 sec" } }) as AAlarmData);
            AlarmDatas.Add("993", new CAlarmWHTM().SetProperties(new Dictionary<string, string>() { { "ControlName", "EPM01" }, { "AlarmID", "993" }, { "AlarmCode", "2" }, { "AlarmLevel", "Light" }, { "AlarmTextUsingFlag", "1" }, { "AlarmText", "Link Signal Timeout Error T3 30 sec" } }) as AAlarmData);
            AlarmDatas.Add("994", new CAlarmWHTM().SetProperties(new Dictionary<string, string>() { { "ControlName", "EPM01" }, { "AlarmID", "994" }, { "AlarmCode", "2" }, { "AlarmLevel", "Light" }, { "AlarmTextUsingFlag", "1" }, { "AlarmText", "Link Signal Timeout Error T4 3 sec" } }) as AAlarmData);
            AlarmDatas.Add("995", new CAlarmWHTM().SetProperties(new Dictionary<string, string>() { { "ControlName", "EPM01" }, { "AlarmID", "995" }, { "AlarmCode", "2" }, { "AlarmLevel", "Serious" }, { "AlarmTextUsingFlag", "1" }, { "AlarmText", "Equipment Internal Communication Error (TCP_IP)" } }) as AAlarmData);
            AlarmDatas.Add("996", new CAlarmWHTM().SetProperties(new Dictionary<string, string>() { { "ControlName", "EPM01" }, { "AlarmID", "996" }, { "AlarmCode", "2" }, { "AlarmLevel", "Serious" }, { "AlarmTextUsingFlag", "1" }, { "AlarmText", "EthenetIP Connection Error (Class 3)" } }) as AAlarmData);
            AlarmDatas.Add("997", new CAlarmWHTM().SetProperties(new Dictionary<string, string>() { { "ControlName", "EPM01" }, { "AlarmID", "997" }, { "AlarmCode", "2" }, { "AlarmLevel", "Serious" }, { "AlarmTextUsingFlag", "1" }, { "AlarmText", "EthenetIP Connection Error - Active Failure(Class 1)" } }) as AAlarmData);
            AlarmDatas.Add("998", new CAlarmWHTM().SetProperties(new Dictionary<string, string>() { { "ControlName", "EPM01" }, { "AlarmID", "998" }, { "AlarmCode", "2" }, { "AlarmLevel", "Serious" }, { "AlarmTextUsingFlag", "1" }, { "AlarmText", "Link Signal Recipe Not Found Error" } }) as AAlarmData);
            AlarmDatas.Add("999", new CAlarmWHTM().SetProperties(new Dictionary<string, string>() { { "ControlName", "EPM01" }, { "AlarmID", "999" }, { "AlarmCode", "2" }, { "AlarmLevel", "Serious" }, { "AlarmTextUsingFlag", "1" }, { "AlarmText", "Link Signal Recipe Mismatch Error" } }) as AAlarmData);
        }

        public override void MelsecNetDriverOpen()
        {
            this.MelsecNetManager.MelsecNetDriverOpen(this.GetCustomProperty("OMRON", "CONNECTION_STRING", string.Format("PORTID={0},PLC_ENCODING={1},PEER_ADDRESS={2},CONNECTION_TYPE={3},HEARTBEAT_TIMER={4},RECEIVE_TIME_LIMIT={5},USE_ROUTE_PATH={6},ROUTE_PATH={7}"
                , 2, Encoding.UTF8.BodyName.ToString(), "192.168.123.76", "Class3", 5000, 5000, false, "2%192.168.123.76"), "OMRON DRIVER TCP/IP 접속"));
            //this.MelsecNetManager.MelsecNetDriverOpen(string.Format("PORTID={0},PLC_ENCODING={1},PEER_ADDRESS={2},CONNECTION_TYPE={3},HEARTBEAT_TIMER={4},RECEIVE_TIME_LIMIT={5},USE_ROUTE_PATH={6},ROUTE_PATH={7}"
            //    , 2, Encoding.UTF8.BodyName.ToString(), "192.168.123.8", "Class3", 1000, 1000, false, "2%192.168.123.8"));
        }

        /// <summary>
        /// YANGSYS.PLC Controls 초기화
        /// </summary>
        public CPLCControlPropertiesCollection GetPLCControlInfo(string filePath)
        {
            CPLCControlPropertiesCollection plcs = new CPLCControlPropertiesCollection();
            CKeyValueCollection plcControls = this.FileManager.PLCControlGet2(filePath);
            int plcIndex = 0;
            foreach (CKeyValue keyvalue in plcControls)
            {
                CPLCControlProperties plc = new CPLCControlProperties();
                plc.SetProperties(keyvalue);
                CControlAttribute attrubute = new CControlAttribute();
                attrubute.SetProperties(keyvalue);
                plcs.Add(plcIndex, plc);
                attrubute.Number = (_YANSYS_CONTROLATTRIBUTES.Count).ToString();
                _YANSYS_CONTROLATTRIBUTES.Add((_YANSYS_CONTROLATTRIBUTES.Count).ToString(), attrubute);
                plcIndex++;
            }
            return plcs;
        }

        /// <summary>
        /// YANGSYS.Scan Controls 초기화
        /// </summary>
        public CScanControlPropertiesCollections GetScanControlInfo(string filePath)
        {
            CScanControlPropertiesCollections scans = new CScanControlPropertiesCollections();
            CKeyValueCollection scanControls = this.FileManager.ScanControlGet2(filePath);
            int scanIndex = 0;
            foreach (CKeyValue keyvalue in scanControls)
            {
                CScanControlProperties scan = new CScanControlProperties();
                scan.SetProperties(keyvalue);
                CControlAttribute attrubute = new CControlAttribute();
                attrubute.SetProperties(keyvalue);

                scans.Add(scanIndex, scan);

                attrubute.Number = (_YANSYS_CONTROLATTRIBUTES.Count).ToString();
                _YANSYS_CONTROLATTRIBUTES.Add((_YANSYS_CONTROLATTRIBUTES.Count).ToString(), attrubute);
                scanIndex++;
            }

            return scans;
        }

        public int SendData(List<string> dataList)
        {
            if (_driver == null)
                return -1;
            string temp = "";

            foreach (string item in dataList)
            {
                temp += (item + "|");
            }
            temp = temp.Substring(0, temp.Length - 1);

            byte[] replyData = Encoding.ASCII.GetBytes(string.Format("{0}#", temp));
            _driver.Send(replyData);
            return 0;
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

        public override void InitializeConfigFile()
        {
            base.InitializeConfigFile();
            foreach (CKeyValue keyvalue in this.ConfigValue)
            {
                _systemConfig.SetProperties(keyvalue);
            }
            this.SiteName = _systemConfig.SiteName;
            this.SetLogger(_systemConfig.LogPath, _systemConfig.LogInfo);
        }


        public override void ScanEventHandler()
        {
            base.ScanEventHandler();

            foreach (IControlAttribute attribute in CONTROLATTRIBUTES.Values)
            {
                foreach (CBasicControl oLoader in Indexers.Values)
                {
                    if (oLoader.ControlName == attribute.ControlName)
                    {
                        oLoader.AttributeAdd(attribute);
                        oLoader.ScanEvents(attribute);
                    }
                }
                foreach (CBasicControl probe in Probes.Values)
                {
                    if (probe.ControlName == attribute.ControlName)
                    {
                        probe.AttributeAdd(attribute);
                        probe.ScanEvents(attribute);
                    }
                }
            }
            foreach (IControlAttribute attribute in _YANSYS_CONTROLATTRIBUTES.Values)
            {
                foreach (CBasicControl oLoader in Indexers.Values)
                {
                    if (oLoader.ControlName == attribute.ControlName)
                    {
                        oLoader.AttributeAdd(attribute);
                        oLoader.ScanEvents(attribute);
                    }
                }
                foreach (CBasicControl probe in Probes.Values)
                {
                    if (probe.ControlName == attribute.ControlName)
                    {
                        probe.AttributeAdd(attribute);
                        probe.ScanEvents(attribute);
                    }
                }
            }
        }

        public void InitializeAllDatas()
        {
            string DBName = SystemConfig.DBName;
            if (string.IsNullOrEmpty(DBName))
                return;

            LotDatas = CLotDataProperties.LoadAll(DBName);
            //GlassDatas = CGlassDataProperties.LoadAll(DBName);

            foreach (CPLCControlProperties oPLC in PLCCONTEROLS.Values)
            {
                if (oPLC.PLCDeviceType == enumDeviceType.B)
                {
                    //BIT Type 변수 전부 Off
                    MelsecNetManager.MelsecNetBitOnOff(oPLC.PLCControlName, oPLC.PLCAttribute, oPLC.PLCArea, oPLC.PLCDeviceType, false);
                }
            }
            StatusLogWrite("MELSEC BIT AREA CLEAR");
        }

        #endregion

        #region CIM 관련 Methods

        public CLotDataProperties GetLOTPropertiesByLOTCode(int iLotCOde)
        {
            CLotDataProperties oRetLot = null;
            foreach (CLotDataProperties oLot in LotDatas.Values)
            {
                if (oLot.LotCode == iLotCOde)
                {
                    oRetLot = oLot;
                    break;
                }
            }
            return oRetLot;
        }

        #endregion


        #region System

        public void ExceptionOccured(string MSG, string OccuredMethod)
        {
            if (OnMessageOccurrenced != null)
                OnMessageOccurrenced(this, OccuredMethod, MSG);
            Exception ex = new Exception(OccuredMethod + "\r\n" + MSG);
            CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "EMP", ex));
        }

        private bool bProgramExit = false;
        public override void ShutDown()
        {
            bProgramExit = true;

            if (MelsecNetManager != null)
                MelsecNetManager.MelsecNetDriverClose();
            _driver.Stop();
            Application.ExitThread();
            base.ShutDown();
        }

        //Main Form에서 Initialize가 완료된 시점에 호출
        public bool CIM_INITIALIZE_COMPLETE = false;
        public void InitializeComplete()
        {

            CIM_INITIALIZE_COMPLETE = true;

            _thread = new Thread(new ThreadStart(DoWork));
            _thread.IsBackground = true;
            _thread.Start();
        }
        //20170315
        public void Client_ReStart()
        {
            _driver.ReStart_ByClient();
        }
        private Thread _thread;

        private void DoWork()
        {
            while (true)
            {
                if (bProgramExit) break;

                CPLCControlProperties oPLC = null;
                CScanControlProperties oScan = null;
                foreach (CIndexerControl indexer in Indexers.Values)
                {
                    oScan = SCANCONTEROLS.GetProperty(indexer.ControlName, "IB_LINKTEST");
                    oPLC = PLCCONTEROLS.GetProperty(indexer.ControlName, "OB_LINKTEST");

                    //if (oScan != null && oPLC != null)
                    //{
                    //    bIsOn = MelsecNetManager.MelsecNetBitRead(oScan.ScanControlName, oScan.ScanAttribute, oScan.ScanArea, oScan.ScanDeviceType, 1);
                    //    bCIMIsOn = MelsecNetManager.MelsecNetBitRead(oPLC.PLCControlName, oPLC.PLCAttribute, oPLC.PLCArea, oPLC.PLCDeviceType, 1);

                    //    if (bCIMIsOn == bIsOn)
                    //    {
                    //        indexer.LinkTestCount = 0;
                    //        indexer.LinkTestLogging = true;
                    //    }
                    //    else
                    //    {
                    //        if (indexer.LinkTestCount > 3)
                    //        {
                    //            oPLC = PLCCONTEROLS.GetProperty(indexer.ControlName, "OB_LINKTEST");
                    //            if (oPLC != null)
                    //            {
                    //                if (indexer.LinkTestCount % 5 == 0)
                    //                {
                    //                    MelsecNetManager.MelsecNetBitOnOff(oPLC.PLCControlName, oPLC.PLCAttribute, oPLC.PLCArea, oPLC.PLCDeviceType, bIsOn);
                    //                    if (indexer.LinkTestLogging)
                    //                        CLogManager.Instance.Log(new CLoaderLogFormat(Catagory.Error, oPLC.PLCControlName, "FORCED OB_LINK_TEST", string.Format("LOADER]{0}] FORCE BIT [{1}]", indexer.ControlName, bIsOn ? "ON" : "OFF")));
                    //                }

                    //                if (indexer.LinkTestCount == 30)
                    //                {
                    //                    indexer.LinkTestLogging = false;
                    //                }

                    //                if (indexer.LinkTestCount == 180)
                    //                {
                    //                    CLogManager.Instance.Log(new CLoaderLogFormat(Catagory.Error, oPLC.PLCControlName, "FORCED LINK TEST FAIL", string.Format("LOADER]{0}] FORCE LINK FAIL RETRY : 180sec VALUE [{1}]", indexer.ControlName, bIsOn ? "ON" : "OFF")));
                    //                }

                    //            }
                    //        }

                    //        indexer.LinkTestCount++;

                    //    }
                    //}
                }

                foreach (CProbeControl probe in Probes.Values)
                {
                    oScan = SCANCONTEROLS.GetProperty(probe.ControlName, "IB_LINKTEST");
                    oPLC = PLCCONTEROLS.GetProperty(probe.ControlName, "OB_LINKTEST");
                    //if (oScan != null && oPLC != null)
                    //{
                    //    bIsOn = MelsecNetManager.MelsecNetBitRead(oScan.ScanControlName, oScan.ScanAttribute, oScan.ScanArea, oScan.ScanDeviceType, 1);
                    //    bCIMIsOn = MelsecNetManager.MelsecNetBitRead(oPLC.PLCControlName, oPLC.PLCAttribute, oPLC.PLCArea, oPLC.PLCDeviceType, 1);

                    //    if (bCIMIsOn == bIsOn)
                    //    {
                    //        //oEQP.LinkStatus = bIsOn;
                    //        probe.LinkTestCount = 0;
                    //        probe.LinkTestLogging = true;
                    //    }
                    //    else
                    //    {
                    //        if (probe.LinkTestCount > 3)
                    //        {
                    //            oPLC = PLCCONTEROLS.GetProperty(probe.ControlName, "OB_LINKTEST");
                    //            if (oPLC != null)
                    //            {
                    //                if (probe.LinkTestCount % 5 == 0)
                    //                {
                    //                    CLogManager.Instance.Log(new CLoaderLogFormat(Catagory.Error, oPLC.PLCControlName, "FORCED OB_LINK_TEST", string.Format("EQP[{0}] FORCE BIT [{1}]", probe.ControlName, bIsOn ? "ON" : "OFF")));
                    //                    MelsecNetManager.MelsecNetBitOnOff(oPLC.PLCControlName, oPLC.PLCAttribute, oPLC.PLCArea, oPLC.PLCDeviceType, bIsOn);
                    //                }
                    //                if (probe.LinkTestCount == 30)
                    //                {
                    //                    probe.LinkTestLogging = false;
                    //                }

                    //                if (probe.LinkTestCount == 180)
                    //                {
                    //                    CLogManager.Instance.Log(new CLoaderLogFormat(Catagory.Error, oPLC.PLCControlName, "FORCED LINK TEST FAIL", string.Format("EQP[{0}] FORCE LINK FAIL RETRY : 180sec VALUE [{1}]", probe.ControlName, bIsOn ? "ON" : "OFF")));
                    //                }
                    //            }
                    //        }
                    //        else
                    //        {
                    //            probe.LinkTestCount++;
                    //        }
                    //    }
                    //}
                }

                System.Threading.Thread.Sleep(1000);
            }
        }

        public void StatusLogWrite(string MSG)
        {
            CLogManager.Instance.Log(new CStatusLogFormat(Catagory.Info, "SYSTEM", "MAIN", MSG));
        }
        public void StatusLogWrite(string MSG, string OccuredPoint)
        {
            CLogManager.Instance.Log(new CStatusLogFormat(Catagory.Info, "SYSTEM", OccuredPoint, MSG));
        }
        #endregion

        //==================================================
        // GLASSID,LOTID,CSTID 8워드자리 LIST<INT>로 만들기.
        // 2013-08-27 김동광K
        //==================================================
        public List<int> DataWordConvert(string str, int length)
        {
            List<int> oWrite = new List<int>();


            string[] strInfo = new string[8];
            ushort[] ushortInfo = new ushort[16];
            List<int> Infomation = new List<int>();
            ushortInfo = CDataConvert.StringToAscii(str, length); // lotid 넣기
            strInfo = CDataConvert.AsciiTo1BitWord(ushortInfo, length * 2);
            for (int i = 0; i < strInfo.Length; i++)
            {
                Infomation.Add(CDataConvert.BinaryStringToRevseInt(strInfo[i]));
            }

            // 다시 리스트에 담기.
            for (int i = 0; i < Infomation.Count; i++)
            {
                oWrite.Add(Infomation[i]);
            }
            return oWrite;
        }

        private List<int> StringToIntArray(string str, int wordLength, char space)
        {
            string[] strInfo = new string[8];
            ushort[] ushortInfo = new ushort[16];
            List<int> Infomation = new List<int>();
            if (str.Length < wordLength * 2)
            {
                int spaceCount = wordLength * 2 - str.Length;
                for (int i = 0; i < spaceCount; i++)
                {
                    str += space;
                }
            }
            ushortInfo = CDataConvert.StringToAscii(str, wordLength);
            strInfo = CDataConvert.AsciiTo1BitWord(ushortInfo, wordLength * 2);
            for (int i = 0; i < wordLength; i++)
            {
                Infomation.Add(CDataConvert.BinaryStringToInt(strInfo[i]));
            }
            return Infomation;
        }

        public void MelsecNetWordWrite(CPLCControlProperties property, int value)
        {
            if (property == null)
                return;
            //this.MelsecNetManager.MelsecNetWordWrite(property.PLCControlName, property.PLCAttribute, property.PLCArea, property.PLCDeviceType, value);
            this.MelsecNetManager.MelsecNetWordWrite(property, value);
        }
        public void MelsecNetWordWrite(CPLCControlProperties property, ushort value)
        {
            if (property == null)
                return;
            //this.MelsecNetManager.MelsecNetWordWrite(property.PLCControlName, property.PLCAttribute, property.PLCArea, property.PLCDeviceType, value);
            this.MelsecNetManager.MelsecNetWordWrite(property, value);
        }

        public void MelsecNetMultiWordWrite(CPLCControlProperties property, List<int> value)
        {
            if (property == null)
                return;
            //this.MelsecNetManager.MelsecNetMultiWordWrite(property.PLCControlName, property.PLCAttribute, property.PLCArea, property.PLCDeviceType, value);
            this.MelsecNetManager.MelsecNetMultiWordWrite(property, value);
        }
        public void MelsecNetMultiWordWrite(CPLCControlProperties property, List<ushort> value)
        {
            if (property == null)
                return;
            //this.MelsecNetManager.MelsecNetMultiWordWrite(property.PLCControlName, property.PLCAttribute, property.PLCArea, property.PLCDeviceType, value);
            this.MelsecNetManager.MelsecNetMultiWordWrite(property, value);
        }

        public void MelsecNetMultiWordWriteByString(CPLCControlProperties property, string text, int length, char paddingChar)
        {
            if (property == null)
                return;
            string value = text;
            if (paddingChar != null)
                value = value.PadRight(length * 2, paddingChar);
            List<int> temp = new List<int>();

            for (int i = 0; i < length * 2; i++)
            {
                temp.Add(int.Parse(PLCUtils.HexToDec(PLCUtils.StringToReverseHex(string.Format("{0}{1}", value[i++], value[i])))));
            }

            //this.MelsecNetManager.MelsecNetMultiWordWrite(property.PLCControlName, property.PLCAttribute, property.PLCArea, property.PLCDeviceType, temp);
            this.MelsecNetManager.MelsecNetMultiWordWrite(property, temp);
        }

        public ushort[] MelsecNetMultiWordRead(CPLCControlProperties property, int length)
        {
            if (property == null)
                return new ushort[0];
            //return this.MelsecNetManager.MelsecNetMultiWordRead(property.PLCControlName, property.PLCAttribute, property.PLCArea, property.PLCDeviceType, length);
            return this.MelsecNetManager.MelsecNetMultiWordRead(property);
        }
        public ushort[] MelsecNetMultiWordRead(CScanControlProperties property)
        {
            if (property == null)
                return new ushort[0];
            //return this.MelsecNetManager.MelsecNetMultiWordRead(property.ScanControlName, property.ScanAttribute, property.ScanArea, property.ScanDeviceType, property.ScanLength);
            return this.MelsecNetManager.MelsecNetMultiWordRead(property);
        }

        public string MelsecNetMultiWordReadToString(CScanControlProperties property)
        {
            if (property == null)
                return "";
            //ushort[] temp = this.MelsecNetManager.MelsecNetMultiWordRead(property.ScanControlName, property.ScanAttribute, property.ScanArea, property.ScanDeviceType, property.ScanLength);
            ushort[] temp = this.MelsecNetManager.MelsecNetMultiWordRead(property);

            string tmpMsg = "";
            for (int i = 0; i < temp.Length; i++)
            {
                tmpMsg += string.Format("{0}{1}", (char)(temp[i] & 0xFF), (char)(temp[i] >> 8)); //SmartDevice.UTILS.PLCUtils.HexToAscii(SmartDevice.UTILS.PLCUtils.DecToHex(temp[i].ToString()));
            }
            tmpMsg = tmpMsg.Replace("\0", "");
            return tmpMsg;
        }

        public string MelsecNetWordRead(CPLCControlProperties plcProperty)
        {
            if (plcProperty == null)
                return "";
            //return this.MelsecNetManager.MelsecNetWordRead(plcProperty.PLCControlName, plcProperty.PLCAttribute, plcProperty.PLCArea, plcProperty.PLCDeviceType);
            return this.MelsecNetManager.MelsecNetWordRead(plcProperty);
        }
        public string MelsecNetWordRead(CScanControlProperties scanProperty)
        {
            if (scanProperty == null)
                return "";
            //return this.MelsecNetManager.MelsecNetWordRead(scanProperty.ScanControlName, scanProperty.ScanAttribute, scanProperty.ScanArea, scanProperty.ScanDeviceType);
            return this.MelsecNetManager.MelsecNetWordRead(scanProperty);
        }

        public int MelsecNetBitOnOff(CPLCControlProperties property, bool value)
        {
            if (property == null)
                return 0;
            //property.Value = value.ToString();
            //return this.MelsecNetManager.MelsecNetBitOnOff(property.PLCControlName, property.PLCAttribute, property.PLCArea, property.PLCDeviceType, value);

            int plcValue = this.MelsecNetManager.MelsecNetBitOnOff(property, value);
            return plcValue;
        }

        public bool MelsecNetBitRead(CPLCControlProperties property, int length)
        {
            if (property == null)
                return false;
            //bool value =this.MelsecNetManager.MelsecNetBitRead(property.PLCControlName, property.PLCAttribute, property.PLCArea, property.PLCDeviceType, length);
            //property.Value = value.ToString();
            //return value;

            bool plcValue = this.MelsecNetManager.MelsecNetBitRead(property, length);
            property.Value = plcValue.ToString();
            return plcValue;
        }
        public bool MelsecNetBitRead(CScanControlProperties property, int length)
        {
            if (property == null)
                return false;
            //bool value = this.MelsecNetManager.MelsecNetBitRead(property.ScanControlName, property.ScanAttribute, property.ScanArea, property.ScanDeviceType, length);
            //property.Value = value.ToString();
            //return value;
            bool plcValue = this.MelsecNetManager.MelsecNetBitRead(property, length);
            property.Value = plcValue.ToString();
            return plcValue;
        }

        public bool[] MelsecNetMultiBitRead(CPLCControlProperties property, int length)
        {
            if (property == null)
                return new bool[length];
            bool[] plcValues = this.MelsecNetManager.MelsecNetMultiBitRead(property, length);
            return plcValues;
        }

        public bool[] MelsecNetMultiBitRead(CScanControlProperties property, int length)
        {
            if (property == null)
                return new bool[length];
            bool[] plcValues = this.MelsecNetManager.MelsecNetMultiBitRead(property, length);
            return plcValues;
        }

        void timeout_Finished(CTimeout timeoutObject)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 시스템 내부 STOP 로직 미구현
        /// </summary>
        public void CycleStop()
        {
            CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Info, CExceptionLogFormat.DEFAULT_KEY, "CycleStop" + " START", new Exception("METHOD")));

            //TODO:
            //
            CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Info, CExceptionLogFormat.DEFAULT_KEY, "CycleStop" + " END", new Exception("METHOD")));
        }

        public CControlComponent GetComponent(string controlName)
        {
            foreach (CIndexerControl item in this.Indexers.Values)
            {
                if (item is CControlComponent && item.ControlName == controlName)
                {
                    return item as CControlComponent;
                }
            }

            foreach (CProbeControl item in this.Probes.Values)
            {
                if (item is CControlComponent && item.ControlName == controlName)
                {
                    return item as CControlComponent;
                }
            }

            return null;
        }
        private List<AProgram> _programs = new List<AProgram>();
        public void ProgramsAdd(AProgram program)
        {
            _programs.Add(program);
        }
        private object _programsLock = new object();
        public AProgram GetProgram(string programName)
        {
            lock (_programsLock)
            {
                for (int i = 0; i < _programs.Count; i++)
                {
                    if (_programs[i].Name == programName)
                    {
                        return _programs[i];
                    }
                }


                return AProgram.NullProgram;
            }
        }
        private object _linkSignalCheck = new object();
        public bool LinkSignalMonitoring = false;
        public void LinkSignalCheck()
        {
            lock (_linkSignalCheck)
            {
                foreach (AProgram program in _programs)
                {
                    if (program.Enable && program.IsCycle)
                    {
                        int ret = program.Execute();
                        if (ret != 0)
                        {
                            //Console.WriteLine(string.Format("PROGRAM={0} RET={1} {2}", program.Name, ret, "수행 불가능! PROGRAM 확인이 필요합니다."));
                        }
                    }
                }
            }
        }

        public void SetAlarm(CBasicControl component, DateTime time, string alid, string altx)
        {
            AProgram program = component.GetProgram("ALARM_SET_STATUS_REPORT");
            List<AProgram.CProgramData> programDataList = program.GetProgramData();
            //programDataList[2].Value = alid;
            program.Execute(programDataList);
        }

        public void ResetAlarm(CBasicControl _component, string alid, string altx)
        {
            //CAlarmProperties resetAlarm = null;
            //foreach (CAlarmProperties alarm in _alarms)
            //{
            //    if (alarm.AlarmID == alid)
            //    {
            //        resetAlarm = alarm;
            //        break;
            //    }
            //}
            //_alarms.Remove(resetAlarm);

            AProgram program = _component.GetProgram("ALARM_RESET_STATUS_REPORT");
            List<AProgram.CProgramData> programDataList = program.GetProgramData();

            program.Execute(programDataList);
        }

        //data cache 같은 역할
        private Dictionary<string, List<AMaterialData>> _receivedGlassDatas = new Dictionary<string, List<AMaterialData>>();
        private object _addRcvLock = new object();
        public void AddReceviedGlassData(string controlName, AMaterialData glassData, int location, bool saveFlag)
        {
            lock (_addRcvLock)
            {
                if (!_receivedGlassDatas.ContainsKey(controlName))
                {
                    _receivedGlassDatas.Add(controlName, new List<AMaterialData>());
                }

                if (_receivedGlassDatas[controlName].Count <= location)
                {
                    int gap = location - _receivedGlassDatas[controlName].Count;
                    for (int i = 0; i <= location; i++)
                    {
                        _receivedGlassDatas[controlName].Add(null);
                    }

                    _receivedGlassDatas[controlName][location] = glassData;
                }
                else
                    _receivedGlassDatas[controlName][location] = glassData;

                if (glassData != null)
                {
                    CLogManager.Instance.Log(new CMaterialDataLogFormat(Catagory.Info, "RECEVIE", glassData.ToString()));
                }

                if (saveFlag == true)
                {
                    try
                    {
                        this.SetCustomProperty("RECEIVE_DATA", "COUNT", _receivedGlassDatas[controlName].Count.ToString(), "");
                        this.SetCustomProperty("RECEIVE_DATA", "CONTROL_NAME", controlName, "");

                        int ReceiveCount = 0;
                        foreach (AMaterialData item in _receivedGlassDatas[controlName])
                        {
                            if (item == null)
                            {
                                ReceiveCount++;
                                continue;
                            }
                            this.SetCustomProperty("RECEIVE_DATA", "RCV" + ReceiveCount++.ToString("000"), CGlassDataPropertiesWHTM.GetSaveData(item as CGlassDataPropertiesWHTM), ""); //여기 AMaterialData로 사용해야함.               
                        }
                    }
                    catch (Exception e)
                    {
                        CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "ERROR", e));
                    }

                }
            }


        }

        public AMaterialData GetReceivedGlassData(string controlName, string materialId)
        {
            lock (_addRcvLock)
            {
                if (_receivedGlassDatas.ContainsKey(controlName))
                {
                    List<AMaterialData> materials = _receivedGlassDatas[controlName];
                    for (int i = 0; i < materials.Count; i++)
                    {
                        if (materials[i] == null)
                            continue;

                        if (materials[i].MatrialID == materialId)
                            return materials[i];
                    }
                }

                return null;
            }
        }

        public AMaterialData GetReceivedGlassDataByLoc(string controlName, int subLocationId)
        {
            lock (_addRcvLock)
            {
                if (_receivedGlassDatas.ContainsKey(controlName))
                {
                    List<AMaterialData> materials = _receivedGlassDatas[controlName];
                    for (int i = 0; i < materials.Count; i++)
                    {
                        if (materials[i] == null)
                            continue;

                        if (materials[i].MatrialSubLocationID == subLocationId.ToString())
                            return materials[i];
                    }
                }

                return null;
            }
        }

        public bool DelReceivedGlassDataByLoc(string controlName, int subLocationId)
        {
            lock (_addRcvLock)
            {
                if (_receivedGlassDatas.ContainsKey(controlName))
                {
                    List<AMaterialData> materials = _receivedGlassDatas[controlName];
                    for (int i = 0; i < materials.Count; i++)
                    {
                        if (materials[i] == null)
                            continue;

                        if (materials[i].MatrialSubLocationID == subLocationId.ToString())
                            _receivedGlassDatas.Remove(materials[i].MatrialSubLocationID);
                            return true;
                    }
                }

                return false;
            }
        }

        public List<AMaterialData> GetReceivedGlassDataList(string controlName)
        {
            lock (_addRcvLock)
            {
                List<AMaterialData> dataList = new List<AMaterialData>();
                if (_receivedGlassDatas.ContainsKey(controlName))
                {
                    return dataList = _receivedGlassDatas[controlName];
                }
                return dataList;
            }
        }

        private Dictionary<string, List<AMaterialData>> _processingGlassDatas = new Dictionary<string, List<AMaterialData>>();
        private object _addProcLock = new object();
        public void AddProcessingGlassData(string controlName, AMaterialData glassData, int location)
        {
            lock (_addProcLock)
            {
                if (!_processingGlassDatas.ContainsKey(controlName))
                {
                    _processingGlassDatas.Add(controlName, new List<AMaterialData>());
                }

                if (_processingGlassDatas[controlName].Count <= location)
                {
                    int gap = location - _processingGlassDatas[controlName].Count;
                    for (int i = 0; i <= location; i++)
                    {
                        _processingGlassDatas[controlName].Add(null);
                    }
                    _processingGlassDatas[controlName][location] = glassData;
                }
                else
                    _processingGlassDatas[controlName][location] = glassData;
                CLogManager.Instance.Log(new CMaterialDataLogFormat(Catagory.Info, "PROCESSING", glassData.ToString()));
            }
        }

        public AMaterialData GetProcessingGlassData(string controlName, string materialId)
        {
            lock (_addProcLock)
            {
                if (_processingGlassDatas.ContainsKey(controlName))
                {
                    List<AMaterialData> materials = _processingGlassDatas[controlName];
                    for (int i = 0; i < materials.Count; i++)
                    {
                        if (materials[i].MatrialID == materialId)
                            return materials[i];
                    }
                }

                return null;
            }
        }

        public AMaterialData GetProcessingGlassDataByLoc(string controlName, int subLocationId)
        {
            lock (_addProcLock)
            {
                if (_processingGlassDatas.ContainsKey(controlName))
                {
                    List<AMaterialData> materials = _processingGlassDatas[controlName];
                    for (int i = 0; i < materials.Count; i++)
                    {
                        if (materials[i].MatrialSubLocationID == subLocationId.ToString())
                            return materials[i];
                    }
                }

                return null;
            }
        }

        public List<AMaterialData> GetProcessingGlassDataList(string controlName)
        {
            lock (_addProcLock)
            {
                List<AMaterialData> dataList = new List<AMaterialData>();
                if (_processingGlassDatas.ContainsKey(controlName))
                {
                    return dataList = _processingGlassDatas[controlName];
                }
                return dataList;
            }
        }

        private Dictionary<string, List<AMaterialData>> _sentOutGlassDatas = new Dictionary<string, List<AMaterialData>>();
        private object _addSentLock = new object();
        public void AddSentOutGlassData(string controlName, AMaterialData glassData, int location)
        {
            lock (_addSentLock)
            {
                if (!_sentOutGlassDatas.ContainsKey(controlName))
                {
                    _sentOutGlassDatas.Add(controlName, new List<AMaterialData>());
                }

                if (_sentOutGlassDatas[controlName].Count <= location)
                {
                    int gap = location - _sentOutGlassDatas[controlName].Count;
                    for (int i = 0; i <= location; i++)
                    {
                        _sentOutGlassDatas[controlName].Add(null);
                    }
                    _sentOutGlassDatas[controlName][location] = glassData;
                }
                else
                    _sentOutGlassDatas[controlName][location] = glassData;

                CLogManager.Instance.Log(new CMaterialDataLogFormat(Catagory.Info, "SEND", glassData != null ? glassData.ToString() : "NULL"));
            }


            //this.SetCustomProperty("SEND_DATA", "COUNT", _sentOutGlassDatas[controlName].Count.ToString(), "");

            //int SendCount = 0;
            //foreach (AMaterialData item in _sentOutGlassDatas[controlName])
            //{
            //    this.SetCustomProperty("SEND_DATA", "SEND" + SendCount++.ToString("000"), CGlassDataProperties.GetSaveData(item as CGlassDataProperties), ""); //여기 AMaterialData로 사용해야함.               
            //}
        }

        public AMaterialData GetSentOutGlassData(string controlName, string materialId)
        {
            lock (_addProcLock)
            {
                if (_sentOutGlassDatas.ContainsKey(controlName))
                {
                    List<AMaterialData> materials = _sentOutGlassDatas[controlName];
                    for (int i = 0; i < materials.Count; i++)
                    {
                        if (materials[i] == null)
                            continue;

                        if (materials[i].MatrialID == materialId)
                            return materials[i];
                    }
                }

                return null;
            }
        }

        public AMaterialData GetSentOutGlassDataByLoc(string controlName, int subLocationId)
        {
            lock (_addProcLock)
            {
                try
                {
                    if (_sentOutGlassDatas.ContainsKey(controlName))
                    {
                        List<AMaterialData> materials = _sentOutGlassDatas[controlName];
                        for (int i = 0; i < materials.Count; i++)
                        {
                            if (materials[i] == null)
                                continue;

                            if (materials[i].MatrialSubLocationID == subLocationId.ToString())
                                return materials[i];
                        }
                    }

                    return null;
                }
                catch (Exception)
                {
                    return null;
                }

            }
        }

        public List<AMaterialData> GetSentOutGlassDataList(string controlName)
        {
            lock (_addSentLock)
            {
                List<AMaterialData> dataList = new List<AMaterialData>();
                if (_sentOutGlassDatas.ContainsKey(controlName))
                {
                    return dataList = _sentOutGlassDatas[controlName];
                }
                return dataList;
            }
        }

        //20161108
        private Dictionary<string, List<AMaterialData>> _removedGlassDatas = new Dictionary<string, List<AMaterialData>>();
        private object _addRemoveLock = new object();
        public void AddRemovedGlassData(string controlName, AMaterialData glassData, int location)
        {
            lock (_addRemoveLock)
            {
                if (!_removedGlassDatas.ContainsKey(controlName))
                {
                    _removedGlassDatas.Add(controlName, new List<AMaterialData>());
                }

                if (_removedGlassDatas[controlName].Count <= location)
                {
                    int gap = location - _removedGlassDatas[controlName].Count;
                    for (int i = 0; i <= location; i++)
                    {
                        _removedGlassDatas[controlName].Add(null);
                    }
                    _removedGlassDatas[controlName][location] = glassData;
                }
                else
                    _removedGlassDatas[controlName][location] = glassData;
                CLogManager.Instance.Log(new CMaterialDataLogFormat(Catagory.Info, "REMOVE", glassData.ToString()));
            }
        }

        public AMaterialData GetRemovedGlassData(string controlName, string materialId)
        {
            lock (_addRemoveLock)
            {
                if (_removedGlassDatas.ContainsKey(controlName))
                {
                    List<AMaterialData> materials = _removedGlassDatas[controlName];
                    for (int i = 0; i < materials.Count; i++)
                    {
                        if (materials[i].MatrialID == materialId)
                            return materials[i];
                    }
                }

                return null;
            }
        }

        public AMaterialData GetRemovedGlassDataByLoc(string controlName, int subLocationId)
        {
            lock (_addRemoveLock)
            {
                if (_removedGlassDatas.ContainsKey(controlName))
                {
                    List<AMaterialData> materials = _removedGlassDatas[controlName];
                    for (int i = 0; i < materials.Count; i++)
                    {
                        if (materials[i].MatrialSubLocationID == subLocationId.ToString())
                            return materials[i];
                    }
                }

                return null;
            }
        }

        public List<AMaterialData> GetRemovedGlassDataList(string controlName)
        {
            lock (_addRemoveLock)
            {
                List<AMaterialData> dataList = new List<AMaterialData>();
                if (_removedGlassDatas.ContainsKey(controlName))
                {
                    return dataList = _removedGlassDatas[controlName];
                }
                return dataList;
            }
        }

        public void Scrap(string controlName, AMaterialData materialData, int location, string glassID, bool remove)
        {
            if (!remove)
                if (_removedGlassDatas.ContainsKey(controlName))
                {
                    List<AMaterialData> list = _removedGlassDatas[controlName];
                    bool exist = false;
                    for (int i = 0; i < list.Count; i++)
                    {
                        AMaterialData item = list[i];
                        if (item.MatrialID == materialData.MatrialID)
                        {
                            list[i] = materialData;
                            exist = true;
                            break;
                        }
                    }

                    if (!exist)
                    {
                        _removedGlassDatas[controlName].Add(materialData);
                    }
                }
                else
                    _removedGlassDatas.Add(controlName, new List<AMaterialData>() { materialData });
            else
            {
                AMaterialData deleteItem = null;
                foreach (AMaterialData item in _removedGlassDatas[controlName])
                {
                    if (item.MatrialID == materialData.MatrialID)
                    {
                        deleteItem = item;
                        break;
                    }
                }
                if (deleteItem != null)
                    _removedGlassDatas[controlName].Remove(deleteItem);
            }

            this.SetCustomProperty("SCRAP_DATA", "COUNT", _removedGlassDatas[controlName].Count.ToString(), "");

            int scrapCount = 0;
            foreach (AMaterialData item in _removedGlassDatas[controlName])
            {
                this.SetCustomProperty("SCRAP_DATA", "SCRAP" + scrapCount++.ToString("000"), CGlassDataPropertiesB7.GetSaveData(item as CGlassDataPropertiesB7), ""); //여기 AMaterialData로 사용해야함.               
            }
        }

        public Dictionary<string, CRecipeDataProperties> _recipeParameterDatas = new Dictionary<string, CRecipeDataProperties>();
        private object _addLock = new object();
        public void AddRecipeParameterData(string parameterNo, CRecipeDataProperties parameterData)
        {
            lock (_addLock)
            {
                if (_recipeParameterDatas.ContainsKey(parameterNo))
                {
                    _recipeParameterDatas[parameterNo] = parameterData;
                }
                else
                {
                    _recipeParameterDatas.Add(parameterNo, parameterData);
                }
            }
        }

        public List<CRecipeDataProperties> GetRecipeParameterData()
        {
            List<CRecipeDataProperties> dataList = new List<CRecipeDataProperties>();
            for (int i = 0; i < _recipeParameterDatas.Count; i++)
            {
                dataList = _recipeParameterDatas.Values.ToList<CRecipeDataProperties>();
            }
            return dataList;
        }

        public void AddCIMMessageHistory(List<string> values)
        {
            bool Flag = false;

            List<string> tempMessageData = new List<string>();

            for (int i = 0; i <= _systemConfig.History_Count; i++)
            {
                tempMessageData.Add(this.GetCustomProperty("MESSAGE_HISTORY", i.ToString(), "", ""));
                if (tempMessageData[i] == "")
                {
                    Flag = true;

                    this.SetCustomProperty("MESSAGE_HISTORY", i.ToString(), values[1] + "," + values[2] + "," + values[3], "");
                    break;
                }
            }

            if (!Flag)
            {
                for (int i = 0; i < _systemConfig.History_Count; i++)
                {
                    tempMessageData[i] = tempMessageData[i + 1];
                }

                tempMessageData[_systemConfig.History_Count] = values[1] + "," + values[2] + "," + values[3];

                for (int i = 0; i <= _systemConfig.History_Count; i++)
                {
                    this.SetCustomProperty("MESSAGE_HISTORY", i.ToString(), tempMessageData[i], "");
                }
            }


        }

        public void LoadCIMMessageHistory()
        {
            _systemConfig.History_Count = int.Parse(this.GetCustomProperty("CIM_HISTORY_DATA", "HISTORY_COUNT", "20", ""));

            List<string> tempMessageData = new List<string>();

            for (int i = 0; i <= _systemConfig.History_Count; i++)
            {
                tempMessageData.Add(this.GetCustomProperty("MESSAGE_HISTORY", i.ToString(), "", ""));

                if (tempMessageData[i] != "")
                {
                    string[] tempData = tempMessageData[i].Split(',');

                    List<string> values = new List<string>();
                    values.Add("0");
                    values.Add(tempData[0]);
                    values.Add(tempData[1]);
                    values.Add(tempData[2]);
                    values.Add("0");

                    CSubject subject = CUIManager.Inst.GetData("CIMMessageHistory");
                    subject.SetValue("List", values);
                    subject.Notify();
                }
            }
        }

        public void SetCustomProperties() //20161111
        {
            this.SetCustomProperty("TIME_OUT_VALUE", "T1_TIMEOUT", _systemConfig.T1_TimeOut.ToString(), "");
            this.SetCustomProperty("TIME_OUT_VALUE", "T2_TIMEOUT", _systemConfig.T2_TimeOut.ToString(), "");

        }

        public DateTime Sent_Out_Time
        {
            get
            {
                return _systemConfig.Sent_Out_Job_Time;
            }
            set
            {
                _systemConfig.Sent_Out_Job_Time = value;
                this.SetCustomProperty("SENT_OUT_JOB_REPORT_TIME", "VALUE", _systemConfig.Sent_Out_Job_Time.ToString(), "");
            }
        }

        public DateTime Receive_Job_Time
        {
            get
            {
                return _systemConfig.Receive_Job_Time;
            }
            set
            {
                _systemConfig.Receive_Job_Time = value;
                this.SetCustomProperty("RECEIVE_JOB_REPORT_TIME", "VALUE", _systemConfig.Receive_Job_Time.ToString(), "");
            }
        }

        public DateTime Get_Process_Start_Time(int index)
        {
            //get
            //{
            if (_systemConfig.Process_Start_Time.ContainsKey(index))
            {
                return _systemConfig.Process_Start_Time[index];
            }
            else
            {
                return DateTime.Now.AddMinutes(-10);
            }
            //}
            //set
            //{
            //if (_systemConfig.Process_Start_Time.ContainsKey(index))
            //{
            //    _systemConfig.Process_Start_Time[index] = mtime;
            //    this.SetCustomProperty("PROCESS_START_TIME", "VALUE", _systemConfig.Process_Start_Time[index].ToString(), "");
            //}


            //}
        }

        public void Set_Process_Start_Time(int index, DateTime mtime)
        {
            //get
            //{
            //    if (_systemConfig.Process_Start_Time.ContainsKey(index))
            //    {
            //    return _systemConfig.Process_Start_Time[index];
            //    }
            //}
            //set
            //{
            if (_systemConfig.Process_Start_Time.ContainsKey(index))
            {
                _systemConfig.Process_Start_Time[index] = mtime;
                this.SetCustomProperty("PROCESS_START_TIME", index.ToString(), _systemConfig.Process_Start_Time[index].ToString(), "");
            }
            else
            {
                _systemConfig.Process_Start_Time.Add(index, mtime);
                this.SetCustomProperty("PROCESS_START_TIME", index.ToString(), mtime.ToString(), "");
            }
                
                
            //}
        }


        public DateTime Get_Process_End_Time(int index)
        {

            if (_systemConfig.Process_End_Time.ContainsKey(index))
            {
                return _systemConfig.Process_End_Time[index];
            }
            else
            {
                return DateTime.Now;
            }
        }

        public void Set_Process_End_Time(int index, DateTime mtime)
        {
            if (_systemConfig.Process_End_Time.ContainsKey(index))
            {
                _systemConfig.Process_End_Time[index] = mtime;
                this.SetCustomProperty("PROCESS_END_TIME", index.ToString(), _systemConfig.Process_End_Time[index].ToString(), "");
            }
            else
            {
                _systemConfig.Process_End_Time.Add(index, mtime);
                this.SetCustomProperty("PROCESS_END_TIME", index.ToString(), mtime.ToString(), "");
            }

            //get
            //{
            //    return _systemConfig.Process_End_Time;
            //}
            //set
            //{
            //    _systemConfig.Process_End_Time = value;
            //    this.SetCustomProperty("PROCESS_END_TIME", "VALUE", _systemConfig.Process_End_Time.ToString(), "");
            //}
        }

        //public DateTime Process_End_Time
        //{
        //    get
        //    {
        //        return _systemConfig.Process_End_Time;
        //    }
        //    set
        //    {
        //        _systemConfig.Process_End_Time = value;
        //        this.SetCustomProperty("PROCESS_END_TIME", "VALUE", _systemConfig.Process_End_Time.ToString(), "");
        //    }
        //}

        public string Saved_Current_PPID
        {
            get
            {
                return _systemConfig.Saved_Current_PPID;
            }
            set
            {
                _systemConfig.Saved_Current_PPID = value;
                this.SetCustomProperty("CURRENT_PPID_VALUE", "CURRENT_PPID", value, "");
            }
        }

        public string Saved_Current_RecipeID
        {
            get
            {
                return _systemConfig.Saved_Current_RecipeID;
            }
            set
            {
                _systemConfig.Saved_Current_RecipeID = value;
                this.SetCustomProperty("CURRENT_PPID_VALUE", "CURRENT_RECIPE", value, "");
            }
        }

        public void GetCustomPropertiesData()
        {
            string tempT1timeOut = "";
            string tempT2timeOut = "";

            tempT1timeOut = this.GetCustomProperty("TIME_OUT_VALUE", "T1_TIMEOUT", "4", "");
            tempT2timeOut = this.GetCustomProperty("TIME_OUT_VALUE", "T2_TIMEOUT", "2", "");

            _systemConfig.T1_TimeOut = int.Parse(tempT1timeOut);
            _systemConfig.T2_TimeOut = int.Parse(tempT2timeOut);

            _systemConfig.Upstream_inline_Flag = bool.Parse(this.GetCustomProperty("INLINE_MODE_VALUE", "UPSTREAM_INLINE", "True", ""));
            _systemConfig.Downstream_inline_Flag = bool.Parse(this.GetCustomProperty("INLINE_MODE_VALUE", "DOWNSTREAM_INLINE", "True", ""));
            _systemConfig.Auto_Recipe_Flag = bool.Parse(this.GetCustomProperty("AUTO_RECIPE_VALUE", "AUTO_RECIPE", "True", ""));
            _systemConfig.Exchange_Use_Flag = bool.Parse(this.GetCustomProperty("EXCHANGE_USE_VALUE", "EXCHANGE_USE", "True", ""));

            _systemConfig.Saved_Current_PPID = this.GetCustomProperty("CURRENT_PPID_VALUE", "CURRENT_PPID", "test", "");
            _systemConfig.Saved_Current_RecipeID = this.GetCustomProperty("CURRENT_PPID_VALUE", "CURRENT_RECIPE", "600", "");

            DateTime temp1;
            DateTime.TryParse(this.GetCustomProperty("SENT_OUT_JOB_REPORT_TIME", "VALUE", "True", ""), out temp1);
            _systemConfig.Sent_Out_Job_Time = temp1;
            DateTime.TryParse(this.GetCustomProperty("RECEIVE_JOB_REPORT_TIME", "VALUE", "True", ""), out temp1);
            _systemConfig.Receive_Job_Time = temp1;
            DateTime.TryParse(this.GetCustomProperty("PROCESS_START_TIME", "0", "True", ""), out temp1);
            _systemConfig.Process_Start_Time.Add(0, temp1);
            DateTime.TryParse(this.GetCustomProperty("PROCESS_END_TIME", "0", "True", ""), out temp1);
            _systemConfig.Process_End_Time.Add(0, temp1);
            DateTime.TryParse(this.GetCustomProperty("PROCESS_START_TIME", "1", "True", ""), out temp1);
            _systemConfig.Process_Start_Time.Add(1, temp1);
            DateTime.TryParse(this.GetCustomProperty("PROCESS_END_TIME", "1", "True", ""), out temp1);
            _systemConfig.Process_End_Time.Add(1, temp1);

            string tempCount = this.GetCustomProperty("RECEIVE_DATA", "COUNT", "0", "");
            string dControlName = "";
            int cnt = 0;

            if (tempCount != "0")
            {
                int.TryParse(tempCount, out cnt);
                dControlName = this.GetCustomProperty("RECEIVE_DATA", "CONTROL_NAME", "0", "");
            }

            List<string> tempGlassData = new List<string>();

            for (int i = 0; i < cnt; i++)
            {
                tempGlassData.Add(this.GetCustomProperty("RECEIVE_DATA", "RCV" + i.ToString("000"), "", ""));


                string[] tempData = tempGlassData[i].Split(',');
                if (tempData.Length == 23)
                {
                    Dictionary<string, string> data = CGlassDataPropertiesWHTM.GetRemovedData(tempData);
                    ushort[] udata = CGlassDataPropertiesWHTM.GetGuiDataToPLC(data);
                    CGlassDataPropertiesWHTM glassData = new CGlassDataPropertiesWHTM(udata);
     

                    //subject = CUIManager.Inst.GetData("GlassInfoDisplay");
                    //Dictionary<string, string> data1 = CGlassDataProperties.GetGuiData(glassData);
                    //subject.SetValue("Data", data);
                    //subject.Notify();
                    if (glassData.GlassID != "")
                    {
                        if (glassData.GlassPosition == 1 || glassData.GlassPosition == 3)
                        {
                            glassData.MatrialSubLocationID = "0";
                            glassData.TrackingData = 2;
                            AddReceviedGlassData(dControlName, glassData, 0, false); //glassData.MatrialSubLocationID);

                            CSubject subject = CUIManager.Inst.GetData("ucEQP");
                            subject.SetValue("RECIPE", getRecipeId(glassData.PPID));
                            subject.SetValue("GlassCode1", glassData.GlassIndex.ToString());
                            subject.SetValue("GlassID1", glassData.GlassID);

                            if (glassData.GlassPosition == 1)
                            {
                                subject.SetValue("GlassExist_Whole", false);
                                subject.SetValue("GlassExist_A", true);
                            }
                            else
                            {
                                subject.SetValue("GlassExist_Whole", true);
                                subject.SetValue("GlassExist_A", false);
                            }

                            subject.Notify();

                            CSubject subject1 = CUIManager.Inst.GetData("ucGlassData");
                            subject1.SetValue("Data", CGlassDataPropertiesWHTM.GetGuiData(glassData));
                            subject1.Notify();
                        }
                        else if (glassData.GlassPosition == 2)
                        {
                            glassData.MatrialSubLocationID = "1";
                            glassData.TrackingData = 2;
                            AddReceviedGlassData(dControlName, glassData, 1, false); //glassData.MatrialSubLocationID);

                            CSubject subject = CUIManager.Inst.GetData("ucEQP");
                            subject.SetValue("RECIPE", getRecipeId(glassData.PPID));
                            subject.SetValue("GlassCode2", glassData.GlassIndex.ToString());
                            subject.SetValue("GlassID2", glassData.GlassID);

                            subject.SetValue("GlassExist_Whole", false);
                            subject.SetValue("GlassExist_B", true);

                            subject.Notify();

                            CSubject subject1 = CUIManager.Inst.GetData("ucGlassData");
                            subject1.SetValue("Data2", CGlassDataPropertiesWHTM.GetGuiData(glassData));
                            subject1.Notify();
                        }
                    }
                    
                }
            }


            int RecipeCount = int.Parse(this.GetCustomProperty("PPID_MAP_LIST_COUNT", "COUNT", "0", ""));

            string reasonText = "";

            if (RecipeCount > 0)
            {
                for (int i = 1; i <= RecipeCount; i++)
                {
                    string[] tempData = this.GetCustomProperty("PPID_MAP_LIST", i.ToString(), "", "").Split(',');
                    if (tempData.Length == 6)
                    {
                        List<string> RecipeData = new List<string>();
                        CSubject subject = null;

                        RecipeData.Add(tempData[0]);
                        RecipeData.Add(tempData[1]);
                        RecipeData.Add("1");
                        RecipeData.Add(tempData[3]);
                        RecipeData.Add(tempData[4]);
                        RecipeData.Add(tempData[5]);

                        subject = CUIManager.Inst.GetData("UpdateRecipeData");
                        subject.SetValue("Recipe", RecipeData);
                        subject.Notify();

                        PPIDCreate(tempData[0], tempData[1], out reasonText);
                    }
                }
            }

            //if (_removedGlassDatas.Count == 0) //Recovery Data 가져오기
            //{
            //    string tempCount = "";
            //    tempCount = this.GetCustomProperty("SCRAP_DATA", "COUNT", "0", "");
            //    int cnt = 0;

            //    if (tempCount != "0")
            //    {
            //        int.TryParse(tempCount, out cnt);
            //    }

            //    List<string> tempGlassData = new List<string>();

            //    for (int i = 0; i < cnt; i++)
            //    {
            //        tempGlassData.Add(this.GetCustomProperty("SCRAP_DATA", "SCRAP" + i.ToString("000"), "", ""));
            //        string[] tempData = tempGlassData[i].Split(',');
            //        if (tempData.Length == 28)
            //        {
            //            Dictionary<string, string> data = CGlassDataPropertiesB7.GetRemovedData(tempData);
            //            ushort[] udata = CGlassDataPropertiesB7.GetGuiDataToPLC(data);
            //            CGlassDataPropertiesB7 glassData = new CGlassDataPropertiesB7(udata);
            //            AddRemovedGlassData(glassData.MatrialLocationID, glassData, 0); //glassData.MatrialSubLocationID);
            //        }
            //    }
            //}

        }

        public void GetRcpParameterList()
        {
            //StringBuilder temp = new StringBuilder(255);
            //long i = GetPrivateProfileString("DV_DATA_LIST_COUNT", "DV_COUNT", "0", temp, temp.Capacity, Application.StartupPath + "\\Config\\DV_DATA_LIST.ini");
            //int idvCnt = int.Parse(temp.ToString());


            //List<string> tempDvData = new List<string>();

            //for (int j = 0; j < idvCnt; j++)
            //{
            //    StringBuilder temp2 = new StringBuilder(255);
            //    long k = GetPrivateProfileString("DV_DATA_LIST", "DV_DATA" + j.ToString("000"), "0", temp2, temp2.Capacity, Application.StartupPath + "\\Config\\DV_DATA_LIST.ini");
            //    tempDvData.Add(temp2.ToString());
            //    string[] tempDvData2 = tempDvData[j].Split(',');
            //    CDvDataProperties dvData = new CDvDataProperties(tempDvData2);
            //    AddDvData(dvData.DVNo, dvData);
            //}

            string[] tempValue;
            try
            {
                using (StreamReader sr = new StreamReader(Application.StartupPath + "\\Config\\RECIPE_PARAMETER_LIST.ini"))
                {
                    String line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);

                        tempValue = line.Split(',');
                        if (tempValue.Length == 5)
                        {
                            CRecipeDataProperties parameterData = new CRecipeDataProperties(tempValue);
                            AddRecipeParameterData(parameterData.ParameterNo, parameterData);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

        }

        protected override IOManager CreateIOManager()
        {
            if (this.SiteName == "WHTM")
            {
                ObjectHandle oh = Activator.CreateInstanceFrom(@"YANGSYS.Manager.dll", "SOFD.Core.COmronManager");
                IOManager ioManager = (IOManager)oh.Unwrap();
                ioManager.IOManagerOpen += new delegateIOManagerOpenHandler(ioManager_IOManagerOpen);
                ioManager.IOManagerClose += new delegateIOManagerCloseHandler(ioManager_IOManagerClose);
                return ioManager;
            }
            else
            {
                return base.CreateIOManager();
            }
        }

        void ioManager_IOManagerClose(object obj, string errorReason)
        {
            //throw new NotImplementedException();
            if (errorReason == "Disconnect")
                _systemConfig.BC_Connect = false;
        }

        void ioManager_IOManagerOpen(object obj, bool value)
        {
            _systemConfig.BC_Connect = value;
        }

        protected override IOManager CreateIOManager(SOFD.BasicCore.enumSystemMode systemMode)
        {
            if (this.SiteName == "WHTM")
            {
                ObjectHandle oh = Activator.CreateInstanceFrom(@"YANGSYS.Manager.dll", "SOFD.Core.COmronManager");
                IOManager ioManager = (IOManager)oh.Unwrap();
                ioManager.IOManagerOpen += new delegateIOManagerOpenHandler(ioManager_IOManagerOpen);
                ioManager.IOManagerClose += new delegateIOManagerCloseHandler(ioManager_IOManagerClose);
                ioManager.SetCore(this);
                ioManager.SetSystemMode(this.SystemMode.ToString());
                return ioManager;
            }
            else
            {
                return base.CreateIOManager(systemMode);
            }
        }
        public Dictionary<string, string> PPIDMap = new Dictionary<string, string>();

        private object _PPIDMapLock = new object();

        public bool PPIDCreate(string PPID, string recipeID, out string reason)
        {
            lock (_PPIDMapLock)
            {
                reason = "";
                if (PPIDMap.ContainsKey(PPID))
                {
                    reason = string.Format("PPID/RECIPE ID MAP IS AREADY REGISTERED.  PPID={0} RECIPEID={1}", PPID, recipeID);
                    Log(new CDebugLogFormat(reason, "AddPPID"));
                    return false;
                }

                PPIDMap.Add(PPID, recipeID);
                Log(new CDebugLogFormat(string.Format("PPID/RECIPE ID MAP IS REGISTERED. PPID={0} RECIPEID={1}", PPID, recipeID), "AddPPID"));
                return true;
            }
        }

        public bool PPIDChange(string PPID, string recipeID, out string reason)
        {
            reason = "";
            if (PPIDMap.ContainsKey(PPID))
            {
                PPIDMap[PPID] = recipeID;
                Log(new CDebugLogFormat(string.Format("PPID/RECIPE ID MAP WAS CHANGED. PPID={0} RECIPEID={1} NEW RECIPEID={2}", PPID, PPIDMap[PPID], recipeID), "AddPPID"));
                return true;
            }
            reason = string.Format("PPID CHANGE FAILURE! - NO REGISTERED PPID. PPID={0} RECIPEID={1}", PPID, recipeID);
            Log(new CDebugLogFormat(reason, "AddPPID"));
            return false;
        }
        public bool PPIDModify(string PPID, string recipeID, out string reason)
        {
            reason = "";
            if (PPIDMap.ContainsKey(PPID))
            {
                Log(new CDebugLogFormat(string.Format("PPID/RECIPE ID MAP WAS MODIFIED. PPID={0} RECIPEID={1} NEW RECIPEID={2}", PPID, PPIDMap[PPID], recipeID), "AddPPID"));
                PPIDMap[PPID] = recipeID;
                return true;
            }
            reason = string.Format("PPID MODIFY FAILURE! - NO REGISTERED PPID. PPID={0} RECIPEID={1}", PPID, recipeID);
            Log(new CDebugLogFormat(reason, "AddPPID"));
            return false;
        }
        public bool PPIDDelete(string PPID, string recipeID, out string reason)
        {
            lock (_PPIDMapLock)
            {
                reason = "";
                if (PPIDMap.ContainsKey(PPID))
                {
                    PPIDMap.Remove(PPID);
                    Log(new CDebugLogFormat(string.Format("PPID/RECIPE ID MAP WAS DELETED. PPID={0} RECIPEID={1}", PPID, recipeID), "AddPPID"));
                    return true;
                }
                reason = string.Format("PPID DELETE FAILURE! - NO REGISTERED PPID. PPID={0} RECIPEID={1}", PPID, recipeID);
                Log(new CDebugLogFormat(reason, "AddPPID"));
                return false;
            }
        }


        public byte[] GetByte(List<bool> notifycation, int byteCount)
        {
            List<byte> temp = new List<byte>();

            string binary = "";
            for (int i = 0; i < notifycation.Count; i++)
            {
                binary = notifycation[i] ? "1" : "0" + binary;
            }

            string dec = PLCUtils.BinaryToHex(binary);

            char[] temp2 = dec.ToCharArray();
            for (int i = 0; i < temp2.Length; i++)
            {
                temp.Add(byte.Parse(PLCUtils.HexToDec(temp2[i].ToString())));
            }
            int value = 0;
            for (int i = 0; i < byteCount - temp.Count; i++)
            {
                temp.Add(0);
            }
            if (int.TryParse(dec, out value))
            {
                return temp.ToArray();
            }
            throw new Exception();

        }

        /// <summary>
        /// ABCD  -> BADC-> HEX -> DEC 로 변환 해준다.
        /// </summary>
        /// <param name="normalString"></param>
        /// <param name="wordMaxLength">WORD 기준 총개수, 내부적으로 *2한다.</param>
        /// <returns></returns>
        public List<int> CovertStringToWordList(string normalString, int wordMaxLength)
        {
            List<int> plcData = new List<int>();
            char[] tempLotID = normalString.ToCharArray();
            List<string> word = new List<string>();
            int maxLegnth = wordMaxLength * 2;

            for (int i = 0; i < maxLegnth; i++)
            {
                if (tempLotID.Length <= i)
                {
                    word.Insert(0, " ");
                }
                else
                {
                    word.Insert(0, tempLotID[i].ToString());
                }

                if (word.Count >= 2)
                {
                    plcData.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.StringToHex(word[0] + word[1]))));
                    word.Clear();
                }
            }
            //plcData.Add(0);//OMRON STRING은 1WORD NULL 줘야함.
            return plcData;
        }
        /// <summary>
        /// ABCD  -> BADC-> HEX -> DEC 로 변환 해준다.
        /// </summary>
        /// <param name="normalString"></param>
        /// <param name="wordMaxLength">WORD 기준 총개수, 내부적으로 *2한다.</param>
        /// <returns></returns>
        public List<ushort> CovertStringToWordushort(string normalString, int wordMaxLength)
        {
            List<ushort> plcData = new List<ushort>();
            char[] tempLotID = normalString.ToCharArray();
            List<string> word = new List<string>();
            long maxLegnth = wordMaxLength * 2;
            for (ushort i = 0; i < maxLegnth; i++)
            {
                if (tempLotID.Length <= i)
                {
                    word.Insert(0, " ");
                }
                else
                {
                    word.Insert(0, tempLotID[i].ToString());
                }
                if (word.Count >= 2)
                {
                    plcData.Add(ushort.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.StringToHex(word[0] + word[1]))));
                    word.Clear();
                }
            }

            return plcData;
        }

        public List<int> ConvertDecTo2WordList(int value)
        {
            List<int> wordList = new List<int>();
            wordList.Add((int)(value & 0xFFFF));
            wordList.Add((int)(value >> 16));
            return wordList;
        }

        public List<int> ConvertDecTo4WordList(ulong value)
        {
            List<int> wordList = new List<int>();
            wordList.Add((int)(value & 0xFFFF));
            wordList.Add((int)(value >> 16 & 0xFFFF));
            wordList.Add((int)(value >> 32 & 0xFFFF));
            wordList.Add((int)(value >> 48 & 0xFFFF));
            return wordList;
        }

        public List<int> ConvertDecToBCD3WordList(ushort yy, ushort MM, ushort dd, ushort HH, ushort mm, ushort ss)
        {
            List<int> wordList = new List<int>();

            wordList.Add(MM << 8 | yy);
            wordList.Add(HH << 8 | dd);
            wordList.Add(ss << 8 | mm);
            return wordList;
        }

        public List<int> GetDVValueToIntList()
        {
            List<int> wordList = new List<int>();
            wordList.Add(0); //1	Item1	G1	Int16	1	Unit1	0	999
            wordList.Add(1); //2	Item2	G1	Int16	1	Unit2	0	999
            wordList.Add(10); //3	Item3	G1	Int16	1	Unit3	0	999
            wordList.Add(100); //4	Item4	G1	Int16	1	Unit4	0	999
            wordList.Add(500); //5	Item5	G1	Int16	1	Unit5	0	999
            wordList.Add(999); //6	Item6	G1	Int16	1	Unit6	0	999
            wordList.Add(999); //7	Item7	G1	Int16	1	Unit7	0	999
            wordList.Add(999); //8	Item8	G1	Int16	1	Unit8	0	999
            wordList.Add(999); //9	Item9	G1	Int16	1	Unit9	0	999
            wordList.Add(999); //10	Item10	G1	Int16	1	Unit10	0	999
            wordList.Add(999); //11	Item11	G1	Int16	1	Unit11	0	999
            wordList.Add(999); //12	Item12	G1	Int16	1	Unit12	0	999
            wordList.AddRange(CovertStringToWordList("", 88)); //13	Item13	G1	ASCII	88	Unit13	0	999

            return wordList;
        }

        public bool GetClientConnected()
        {
            return _driver.GetStatus() == "Connected";
        }

        public string getRecipeId(string ppid)
        {
            if (PPIDMap.ContainsKey(ppid))
            {
                return PPIDMap[ppid];
            }
            return "0";
        }

        public string getPPID(string mRecipeID)
        {
            foreach (KeyValuePair<string,string> item in PPIDMap)
            {
                if (item.Value.Trim() == mRecipeID.Trim())
                    return item.Key;
            }
            return "0";
        }
    }

    #region Enum
    public enum enumOptionalData
    {
        PORT,
        UNIT,
        BUFFER,
        CONVEYOR
    }

    public enum enumControlType
    {
        NONE,
        EQP,
        PORT,
    }

    public enum enumSignalStatus
    {
        OFF,
        ON,
        FLICKER,
    }

    public enum enumLoaderType
    {
        LOADER,
        UNLOADER,
    }


    public enum LOTConfirmWindowViewType
    {
        ENGCD_1,
        CMD_CANCEL,
        OFFLINE,
        CTTIMEOUT,
        VALIDATIONERROR,
    }
    //public enum enumLoaderStatus
    //{
    //    RUN,
    //    IDLE,
    //    DOWN,
    //}
    //public enum enumPortType
    //{
    //    LG,
    //    UG,
    //    PG,
    //    SG,
    //    NG,
    //}
    #endregion


}
