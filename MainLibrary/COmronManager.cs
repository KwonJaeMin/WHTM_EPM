using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOFD.Properties;
using SOFD.Driver;
using SOFD.Core.LogFormat;
using SOFD.Logger;
using System.Threading;
using SOFD.DataConvert;
using SOFD.Component;
using SOFD.BasicCore;
using OMRON.Compolet.Variable;
using OMRON.Compolet.CIP;
using SOFD.Global;
using SOFD.Component.Interface;

namespace SOFD.Core
{
    public class COmronManager : IOManager
    {
        #region //member's

        private VariableCompolet _class1 = null;
        private CJ2Compolet _class3 = null;
        private CIPPortCompolet _portCompolet = null;

        private CBasicCore _core = null;
        private CEMPCore _mainEMPCore = null;
        private CMainCore _mainMainCore = null;
        private DateTime _startTime = new DateTime();
        private enumMelsecConnect _melsecConnect = enumMelsecConnect.DISCONNECT;
        private enumScanMelsecConnect _scanConnect = enumScanMelsecConnect.DISCONNECT;
        private CScanControlPropertiesCollections _scanAttribute = new CScanControlPropertiesCollections();
        private Thread _threadscan = null;
        private bool _enable = false;
        private bool _isFirstScan = true;


        private int portID = 2;
        private Encoding plcEncoding = Encoding.UTF8;
        private string peerAddress = "127.0.0.1";
        private ConnectionType connectionType = ConnectionType.Class3;
        private int heartbeatTimer = 1000;
        private int receiveTimeLimit = 1000;
        private bool useRoutePath = false;
        private string routePath = @"2%127.0.0.1\1%0";

        #endregion

        #region //event's
        public event delegateIOManagerOpenHandler IOManagerOpen = null;
        #endregion

        #region //constructor's
        /// <summary>
        /// COmronManager Constructor
        /// </summary>
        public COmronManager()
        {
            _portCompolet = new CIPPortCompolet();

            _class1 = new VariableCompolet();
            //_class1.Active = true;
            //_class1.PlcEncoding = Encoding.UTF8;

            _class3 = new CJ2Compolet();
            //_class3.PeerAddress = "192.168.123.8";
            //_class3.Active = false;
            //_class3.ConnectionType = ConnectionType.Class3;
            ////_class2.DeviceType = 0;
            //_class3.HeartBeatTimer = 1000;
            ////_class2.IsConnected = false;
            //_class3.LocalPort = 2;
            ////_class2.MajorRevision = 0;
            ////_class2.MinorRevision = 0;
            //_class3.OnHeartBeatTimer += new EventHandler(_class2_OnHeartBeatTimer);
            //_class3.PlcEncoding = Encoding.UTF8;
            ////_class2.ProductCode = 0;
            //_class3.ReceiveTimeLimit = 5000;
            //_class3.RoutePath = @"2%192.168.123.8\1%0";
            ////_class2.SerialNumber = 0;
            ////_class2.TypeName = "";
            //_class3.UseRoutePath = false;
            ////_class2.VariableNames = new string[5];
            ////_class2.VendorID = 0;
        }

        void _class2_OnHeartBeatTimer(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// CMelsecNetManager Constructor
        /// CMain Set
        /// </summary>
        /// <param name="main"></param>
        public COmronManager(CBasicCore main)
            : this()
        {
            if (main is CEMPCore)
            {
                _mainEMPCore = main as CEMPCore;
            }
            else if (main is CMainCore)
            {
                _mainMainCore = main as CMainCore;
            }

            _core = main;

            _startTime = DateTime.Now;
        }

        /// <summary>
        /// CMelsecNetManager Constructor
        /// </summary>
        /// <param name="main">CBasicCore</param>
        /// <param name="systemMode">systemMode</param>
        public COmronManager(CBasicCore main, string systemMode)
            : this()
        {
            if (main is CEMPCore)
            {
                _mainEMPCore = main as CEMPCore;
            }
            else if (main is CMainCore)
            {
                _mainMainCore = main as CMainCore;
            }
            _core = main;
            _startTime = DateTime.Now;
        }

        #endregion

        #region //method's
        /// <summary>
        /// Scan 할 모든 Attribute Set Method
        /// </summary>
        /// <param name="scanAttribute"></param>
        public void SetScanAttribute(CScanControlPropertiesCollections scanAttribute)
        {
            _scanAttribute = scanAttribute;
        }
        /// <summary>
        /// MelsecNet Driver Open Method
        /// </summary>
        public int MelsecNetDriverOpen()
        {
            return MelsecNetDriverOpen(string.Format("PORTID={0},PLC_ENCODING={1},PEER_ADDRESS={2},CONNECTION_TYPE={3},HEARTBEAT_TIMER={4},RECEIVE_TIME_LIMIT={5},USE_ROUTE_PATH={6},ROUTE_PATH={7}"
                , portID, plcEncoding.EncodingName, peerAddress, connectionType.ToString(), heartbeatTimer, receiveTimeLimit, useRoutePath, routePath));
        }

        public int MelsecNetDriverOpen(string connectionString)
        {
            return this.MelsecNetDriverOpen(CConnectionString.Parser(connectionString));
        }

        /// <summary>
        /// MelsecNet Driver Open Method
        /// </summary>
        public int MelsecNetDriverOpen(CConnectionString cs)
        {
            //_portCompolet = new CIPPortCompolet();

            //_class1 = new VariableCompolet();
            //_class1.Active = true;
            //_class1.PlcEncoding = Encoding.UTF8;

            //_class3 = new CommonCompolet();
            //_class3.PeerAddress = "192.168.123.8";
            //_class3.Active = false;
            //_class3.ConnectionType = ConnectionType.Class3;
            //_class2.DeviceType = 0;
            //_class3.HeartBeatTimer = 1000;
            //_class2.IsConnected = false;
            //_class3.LocalPort = 2;
            //_class2.MajorRevision = 0;
            //_class2.MinorRevision = 0;
            //_class3.OnHeartBeatTimer += new EventHandler(_class2_OnHeartBeatTimer);
            //_class3.PlcEncoding = Encoding.UTF8;
            //_class2.ProductCode = 0;
            //_class3.ReceiveTimeLimit = 5000;
            //_class3.RoutePath = @"2%192.168.123.8\1%0";
            //_class2.SerialNumber = 0;
            //_class2.TypeName = "";
            //_class3.UseRoutePath = false;
            //_class2.VariableNames = new string[5];
            //_class2.VendorID = 0;

            int portID = cs.GetValue<int>("PORTID", 2);
            string plcEncoding = cs.GetValue<string>("PLC_ENCODING", "UTF8");
            string peerAddress = cs.GetValue<string>("PEER_ADDRESS", "192.168.123.42");
            ConnectionType connectionType = cs.GetValue<ConnectionType>("CONNECTION_TYPE", ConnectionType.Class3);
            int heartbeatTimer = cs.GetValue<int>("HEARTBEAT_TIMER", 1000);
            int receiveTimeLimit = cs.GetValue<int>("RECEIVE_TIME_LIMIT", 1000);
            bool useRoutePath = cs.GetValue<bool>("USE_ROUTE_PATH", false);
            string routePath = cs.GetValue<string>("ROUTE_PATH", @"2%192.168.123.42\1%0");

            int iRet = 0;

            PortInformation portInfo = _portCompolet.GetPortInformation(portID);
            if (portInfo == null)
            {
                iRet = -99;
            }
            else
            {
                if (!portInfo.StartupOpen && !_portCompolet.IsOpened(portID))
                {
                    _portCompolet.Open(portID);
                }
                else
                {
                    //already open
                }
            }

            try
            {
                _class1.Active = true;
            }
            catch (Exception ex)
            {
                CLogManager.Instance.LogError(string.Format("Class1 active error"), ex);
            }

            try
            {
                _class3.PeerAddress = peerAddress;
                _class3.ConnectionType = ConnectionType.Class3;
                _class3.HeartBeatTimer = heartbeatTimer;
                _class3.LocalPort = portID;

                Encoding encoding = Encoding.UTF8;
                try
                {
                     encoding = Encoding.GetEncoding(plcEncoding);
                }
                catch (Exception ex)
                {
                    CLogManager.Instance.LogError(string.Format("Class3 {0} name error (default = UTF8)", plcEncoding), ex);
                }

                _class3.PlcEncoding = encoding;
                _class3.ReceiveTimeLimit = receiveTimeLimit;
                _class3.RoutePath = string.Format(@"2%{0}\1%0", peerAddress);
                _class3.UseRoutePath = false;
                _class3.Active = true;
            }
            catch (Exception ex)
            {
                CLogManager.Instance.LogError(string.Format("Class3 active error"), ex);
            }

            if (_portCompolet.IsOpened(portID) && _class1.Active && _class3.IsConnected)
            {
                iRet = 0;
            }
            else
            {
                iRet = -99;
            }

            if (iRet == 0)
            {
                _core.Log((new CMelsecLogFormat(Catagory.Debug, "SYSMAC GATEWAY CONNECT", "MelsecNetDriverOpen()", true)));
                _melsecConnect = enumMelsecConnect.CONNECT;

                if (IOManagerOpen != null)
                    IOManagerOpen(this, true);
            }
            else
            {
                _core.Log((new CMelsecLogFormat(Catagory.Debug, "SYSMAC GATEWAY DISCONNECT RETRUN CODE=" + iRet.ToString(), "MelsecNetDriverOpen()", true)));
                _melsecConnect = enumMelsecConnect.DISCONNECT;

                if (IOManagerOpen != null)
                    IOManagerOpen(this, false);
            }

            return iRet;
        }
        /// <summary>
        /// MelsecNet Driver Close Method
        /// </summary>
        public void MelsecNetDriverClose()
        {
            _portCompolet.Close(portID);
        }
        public enum enumClassNo
        {
            Class1,
            Class3
        }
        /// <summary>
        /// MelsecNet Driver Bit On/Off Method
        /// </summary>
        /// <param name="ownerId"></param>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="deviceType"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int MelsecNetBitOnOff(string ownerId, string name, string address, enumDeviceType deviceType, bool value)
        {
            return MelsecNetBitOnOff(ownerId, name, address, deviceType, value, true);
        }

        public int MelsecNetBitOnOff(string ownerId, string name, string address, enumDeviceType deviceType, bool value, bool display)
        {
            int iRet = -99;
            if (_melsecConnect == enumMelsecConnect.CONNECT)
            {
                iRet = WriteValiable(address, value);
                CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Info, false, ownerId, name, portID.ToString(), deviceType.ToString(), address, 1, value, iRet, display));
                return iRet;
            }
            return iRet;
        }
        /// <summary>
        /// MelsectNet Driver Word Write (int) Method
        /// </summary>
        /// <param name="ownerId"></param>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="deviceType"></param>
        /// <param name="data"></param>
        public void MelsecNetWordWirte(string ownerId, string name, string address, enumDeviceType deviceType, int data)
        {
            int iRet = -99;

            if (_melsecConnect == enumMelsecConnect.CONNECT)
            {
                iRet = WriteValiable(address, data); 
                CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Info, false, ownerId, name, portID.ToString(), deviceType.ToString(), address, 1, data.ToString(), iRet, true));
            }
        }
        /// <summary>
        /// MelsectNet Driver Word Write (ushort) Method
        /// </summary>
        /// <param name="ownerId"></param>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="deviceType"></param>
        /// <param name="data"></param>
        public void MelsecNetWordWrite(string ownerId, string name, string address, enumDeviceType deviceType, ushort data)
        {
            int iRet = 0;
            if (_melsecConnect == enumMelsecConnect.CONNECT)
            {
                iRet = WriteValiable(address, data);
                CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Info, false, ownerId, name, portID.ToString(), deviceType.ToString(), address, 1, data.ToString(), iRet, true));
            }
        }
        /// <summary>
        /// MelsecNet Driver Multi Word Write List<int>Method
        /// </summary>
        /// <param name="ownerId"></param>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="deviceType"></param>
        /// <param name="data"></param>
        public void MelsecNetMultiWordWrite(string ownerId, string name, string address, enumDeviceType deviceType, List<int> data)
        {
            int iRet = 0;
            if (_melsecConnect == enumMelsecConnect.CONNECT)
            {
                iRet = WriteValiable(address, data.ToArray());
                StringBuilder sb = new StringBuilder();
                foreach (int item in data)
                {
                    if (sb.ToString() != "")
                        sb.Append(",");
                    sb.Append(item.ToString());
                }
                CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Info, false, ownerId, name, portID.ToString(), deviceType.ToString(), address, data.Count, sb.ToString(), iRet, true));
            }

        }
        /// <summary>
        /// MelsecNet Driver Multi Word Write List<ushort>Method
        /// </summary>
        /// <param name="ownerId"></param>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="deviceType"></param>
        /// <param name="data"></param>
        public void MelsecNetMultiWordWrite(string ownerId, string name, string address, enumDeviceType deviceType, List<ushort> data)
        {
            int iRet = 0;
            if (_melsecConnect == enumMelsecConnect.CONNECT)
            {
                iRet = WriteValiable(address, data.ToArray());
                StringBuilder sb = new StringBuilder();
                foreach (ushort item in data)
                {
                    if (sb.ToString() != "")
                        sb.Append(",");
                    sb.Append(item.ToString());
                }
                CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Info, false, ownerId, name, portID.ToString(), deviceType.ToString(), address, data.Count, sb.ToString(), iRet, true));
            }
        }
        /// <summary>
        /// MelsecNet Driver Multi Word Read Method
        /// </summary>
        /// <param name="ownerId"></param>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="deviceType"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public ushort[] MelsecNetMultiWordRead(string ownerId, string name, string address, enumDeviceType deviceType, int length)
        {
            ushort[] resultData = new ushort[length];
            if (_melsecConnect == enumMelsecConnect.CONNECT)
            {
                object value = ReadValiable( address);
                resultData = null;
                StringBuilder sb = new StringBuilder();
                foreach (ushort item in resultData)
                {
                    if (sb.ToString() != "")
                        sb.Append(",");

                    sb.Append(item.ToString());
                }
                CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Info, true, ownerId, name, portID.ToString(), deviceType.ToString(), address, length, sb.ToString(), 0, true));
            }
            return resultData;
        }
        /// <summary>
        /// MelsecNet Driver Word Read Method
        /// </summary>
        /// <param name="ownerId"></param>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="deviceType"></param>
        /// <returns></returns>
        public string MelsecNetWordRead(string ownerId, string name, string address, enumDeviceType deviceType)
        {
            string resultData = string.Empty;
            if (_melsecConnect == enumMelsecConnect.CONNECT)
            {
                object value = ReadValiable(address);
                resultData = value.ToString();
                CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Info, true, ownerId, name, portID.ToString(), deviceType.ToString(), address, 1, resultData, 0, true));
            }
            return resultData;
        }
        /// <summary>
        /// MelsecNet Driver Bit Read Method
        /// </summary>
        /// <param name="ownerId"></param>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="deviceType"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public bool MelsecNetBitRead(string ownerId, string name, string address, enumDeviceType deviceType, int length)
        {
            string resultData = "";
            if (_melsecConnect == enumMelsecConnect.CONNECT)
            {
                object value = ReadValiable(address);
                resultData = value.ToString();
                CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Info, true, ownerId, name, portID.ToString(), deviceType.ToString(), address, 1, resultData, 0, true));
                return resultData == "true";
            }

            return false;
        }
        /// <summary>
        /// MelsecNet Driver Scan Start Method
        /// </summary>
        public void MelsecNetScanStart()
        {
            CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Debug, "MELSEC SCAN START INIT", "", true));
            if (_melsecConnect == enumMelsecConnect.CONNECT)
            {
                if (_scanConnect == enumScanMelsecConnect.DISCONNECT)
                {
                    if (_mainEMPCore != null)
                        _scanAttribute = _mainEMPCore.SCANCONTEROLS;
                    else if (_mainMainCore != null)
                        _scanAttribute = _mainMainCore.SCANCONTEROLS;

                    MelsecNetScanStarting();

                    _scanConnect = enumScanMelsecConnect.CONNECT;
                    CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Debug, "MELSEC SCAN START COMPLETED", "", true));
                }
                else
                {
                    CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Debug, "MELSEC SCAN START ERROR", "이미 연결 된 상태입니다. 해당 로그 외에 프로그램 처리 로직이 없습니다!", true));
                }
            }
            else
            {
                CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Debug, "MELSEC SCAN START ERROR", "MELSEC DISCONNECT 상태입니다. 드라이버 연결 상태 및 MELSEC CARD 상태를 확인 하십시오! MelscNetScanStarting()을 시작하지 못했습니다.", true));
            }
        }
        /// <summary>
        /// MelsecNet Driver Scan Stop Method
        /// </summary>
        public void MelsecNetScanStop()
        {
            _enable = false;
        }
        /// <summary>
        /// MelsecNet Scan Starting
        /// </summary>
        private void MelsecNetScanStarting()
        {
            _threadscan = new Thread(new ThreadStart(DoScan));
            _threadscan.Priority = ThreadPriority.Highest;
            _threadscan.IsBackground = true;
            _enable = true;
            _threadscan.Start();
            CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Debug, "MELSEC SCAN STARTED", "PRIORITY=" + _threadscan.Priority.ToString() + " ISBACKGROUND=" + _threadscan.IsBackground.ToString() + " THREADSTATE=" + _threadscan.ThreadState.ToString(), true));
        }
        /// <summary>
        /// Thread Start Method
        /// </summary>
        protected virtual void DoScan()
        {
            while (_enable)
            {
                ScanAttributeSet();

                Thread.Sleep(200);
            }
            CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Debug, "MELSEC SCAN STOP", "DoScan() 메서드 실행이 완료 되었습니다._enable=" + _enable.ToString(), true));
        }
        private object _scan = new object();
        /// <summary>
        /// Thread Excute Method
        /// </summary>
        protected virtual void ScanAttributeSet()
        {
            lock (_scan)
            {
                if (_scanAttribute.Count == 0)
                {
                    _enable = false;
                    if (_mainEMPCore != null)
                        _mainEMPCore.Log((new CMelsecLogFormat(Catagory.Debug, "MELSEC SCAN STOP", "SCAN할 대상이 없습니다. if (_scanProperies.Count == 0) ", true)));
                    else if (_mainMainCore != null)
                        _mainMainCore.Log((new CMelsecLogFormat(Catagory.Debug, "MELSEC SCAN STOP", "SCAN할 대상이 없습니다. if (_scanProperies.Count == 0) ", true)));
                    return;
                }

                string sscanarea = string.Empty;
                //추가 초기 기동 시 WORD를 읽기 전 BIT ON 감지하여, 화면에 WORD 값이 표시 안되는 현상 방지.
                if (_isFirstScan)
                {
                    foreach (CScanControlProperties scanProperty in _scanAttribute.Values)
                    {
                        try
                        {
                            if (!scanProperty.Monitoring)
                                continue;

                            sscanarea = scanProperty.ScanArea.ToString();

                            if (scanProperty.ScanDeviceType == enumDeviceType.W || scanProperty.ScanDeviceType == enumDeviceType.R)
                            {
                                MelsecNetScanWord(sscanarea, scanProperty);
                            }
                        }
                        catch (Exception ex)
                        {
                            CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "MELSEC SCAN ERROR", ex));
                        }
                    }
                    _isFirstScan = false;
                }

                foreach (CScanControlProperties scanProperty in _scanAttribute.Values)
                {
                    try
                    {
                        if (!scanProperty.Monitoring)
                            continue;

                        sscanarea = scanProperty.ScanArea.ToString();

                        if (scanProperty.ScanDeviceType == enumDeviceType.W || scanProperty.ScanDeviceType == enumDeviceType.R)
                        {
                            MelsecNetScanWord(sscanarea, scanProperty);
                        }
                        else if (scanProperty.ScanDeviceType == enumDeviceType.B || scanProperty.ScanDeviceType == enumDeviceType.M)
                        {
                            sscanarea = scanProperty.ScanArea.ToString();
                            MelsecNetScanBit(sscanarea, scanProperty);

                        }
                    }
                    catch (Exception ex)
                    {
                        CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "MELSEC SCAN ERROR", ex));
                    }
                }

                _isFirstScan = false;
            }
        }
        /// <summary>
        /// Bit Scan Method
        /// </summary>
        /// <param name="address"></param>
        /// <param name="scanproperty"></param>
        private void MelsecNetScanBit(string address, CScanControlProperties scanproperty)
        {
            bool bValue = false;
            bool bExistValue = false;
            string sMatchWordArea = string.Empty;
            string sConnEQPName = string.Empty;

            if (ReadValiable(address).ToString() == "true")
                bValue = true;
            else
                bValue = false;

            if (scanproperty.Value != bValue.ToString())
            {
                CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Info, scanproperty, string.IsNullOrEmpty(scanproperty.Value) ? false : bool.Parse(scanproperty.Value), bValue));
                scanproperty.Value = bValue.ToString();
                bExistValue = OrignalValueCompare(bValue, scanproperty);

            }
        }
        /// <summary>
        /// Word Scan Method
        /// </summary>
        /// <param name="address"></param>
        /// <param name="scanproperty"></param>
        private void MelsecNetScanWord(string address, CScanControlProperties scanproperty)
        {
            string sGetValue = string.Empty;
            if (scanproperty.ScanLength == 0)
            {
                object value = ReadValiable(address);
                sGetValue = value.ToString();
                //Smart Device에서 결과값을 Hex값으로 반환되어 다시 Dec형태로 반환하여 계산

                if (sGetValue != "-1")
                    sGetValue = CDataConvert.HexToDec(sGetValue);
            }
            else
            {
                object value = ReadValiable(address);
                sGetValue = value.ToString();
            }

            if (scanproperty.Value != sGetValue)
            {
                scanproperty.PreviousValue = scanproperty.Value;
                scanproperty.Value = sGetValue;

                if (scanproperty.PreviousValue == null)
                    scanproperty.PreviousValue = "";

                CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Info, scanproperty, scanproperty.PreviousValue, sGetValue));

                if (_mainEMPCore != null)
                {
                    foreach (CControlAttribute attribute in _mainEMPCore.CONTROLATTRIBUTES.Values)
                    {
                        if (scanproperty.ScanControlName == attribute.ControlName)
                        {
                            if (scanproperty.ScanAttribute == attribute.Attribute)
                            {
                                attribute.WordEvent(scanproperty.PreviousValue, sGetValue);
                            }
                        }
                    }
                }
                else if (_mainMainCore != null)
                {
                    foreach (CControlAttribute attribute in _mainMainCore.CONTROLATTRIBUTES.Values)
                    {
                        if (scanproperty.ScanControlName == attribute.ControlName)
                        {
                            if (scanproperty.ScanAttribute == attribute.Attribute)
                            {
                                attribute.WordEvent(scanproperty.PreviousValue, sGetValue);
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 이전 값과 현재 값을 비교 Method
        /// </summary>
        /// <param name="value"></param>
        /// <param name="scanproperty"></param>
        /// <returns></returns>
        private bool OrignalValueCompare(bool value, CScanControlProperties scanproperty)
        {
            bool bValue = false;
            //if (scanproperty.ScanIsTrue != value)
            //{
            //    scanproperty.ScanIsTrue = value;
            //    bValue = true;
            if (_mainEMPCore != null)
            {
                foreach (CControlAttribute attribute in _mainEMPCore.CONTROLATTRIBUTES.Values)
                {
                    if (scanproperty.ScanControlName == attribute.ControlName)
                    {
                        if (scanproperty.ScanAttribute == attribute.Attribute)
                        {
                            attribute.BitEvent(value);
                        }
                    }
                }
            }
            else if (_mainMainCore != null)
            {
                foreach (CControlAttribute attribute in _mainMainCore.CONTROLATTRIBUTES.Values)
                {
                    if (scanproperty.ScanControlName == attribute.ControlName)
                    {
                        if (scanproperty.ScanAttribute == attribute.Attribute)
                        {
                            attribute.BitEvent(value);
                        }
                    }
                }
            }
            //}
            //else
            //{
            //    bValue = false;
            //}
            return bValue;
        }

        #endregion

        private int WriteValiable(string address, object value)
        {
            
            try
            {
                enumClassNo classNo = enumClassNo.Class1;
                string temp = "";
                if (address.StartsWith("Class1"))
                {
                    classNo = enumClassNo.Class1;
                    temp = address.Replace("Class1,", "");
                }
                else if (address.StartsWith("Class3"))
                {
                    classNo = enumClassNo.Class3;
                    temp = address.Replace("Class3,", "");
                }
                else
                {
                    return -97;
                }


                bool useNum = false;
                string[] splitedAddress = null;

                if (temp.Contains(','))
                {
                    splitedAddress = address.Split(',');
                    for (int i = 0; i < splitedAddress.Length; i++)
                    {
                        splitedAddress[i] = splitedAddress[i].Trim();
                    }
                    useNum = true;
                }
                else
                {
                    return -97;
                }

                if (classNo == enumClassNo.Class3)
                {
                     OMRON.Compolet.CIP.VariableInfo variableInfo = _class3.GetVariableInfo(splitedAddress[1]);

                     if (useNum)
                     {
                         OMRON.Compolet.CIP.VariableInfo memberInfo = variableInfo.StructMembers[int.Parse(splitedAddress[2])];

                         _class3.WriteVariable(string.Format("{0}[{1}]", splitedAddress[1], splitedAddress[2]), value);//, int.Parse(splitedAddress[2]) + 1);
                     }
                     else
                         _class3.WriteVariable(splitedAddress[1], value);
                }
                else
                {
                    _class1.WriteVariable(splitedAddress[1], value);
                }

                return 0;
            }
            catch (Exception ex)
            {
                CLogManager.Instance.LogError(string.Format("WriteValiable Execute Error {0} {1}", address, value), ex);
                return -98;
            }
        }

        private object ReadValiable(string address)
        {
            try
            {
                enumClassNo classNo = enumClassNo.Class1;
                string temp = "";
                if (address.StartsWith("Class1"))
                {
                    classNo = enumClassNo.Class1;
                    temp = address.Replace("Class1,", "");
                }
                else if (address.StartsWith("Class3"))
                {
                    classNo = enumClassNo.Class3;
                    temp = address.Replace("Class3,", "");
                }
                else
                {
                    return -97;
                }


                bool useNum = false;
                string[] splitedAddress = null;
                if (temp.Contains(','))
                {
                    splitedAddress = address.Split(',');
                    for (int i = 0; i < splitedAddress.Length; i++)
                    {
                        splitedAddress[i] = splitedAddress[i].Trim();
                    }
                    useNum = true;
                }
                else
                {
                    return -97;
                }
                object value = "";

                if (classNo == enumClassNo.Class3)
                {
                    OMRON.Compolet.CIP.VariableInfo variableInfo = _class3.GetVariableInfo(splitedAddress[1]);

                    if (useNum)
                    {
                        OMRON.Compolet.CIP.VariableInfo member = variableInfo.StructMembers[int.Parse(splitedAddress[2])];
                        
                        value = _class3.ReadVariable(splitedAddress[1]);//, int.Parse(splitedAddress[2] + 1));
                    }
                    else
                        value = _class3.ReadVariable(splitedAddress[1]);

                }
                else
                {
                    value = _class1.ReadVariable(splitedAddress[1]);
                }

                return value == null ? "" : value;
            }
            catch (Exception ex)
            {
                CLogManager.Instance.LogError(string.Format("ReadValiable Execute Error {0}", address), ex);
                return null;
            }
        }
    }
}
