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
using System.Net.NetworkInformation;

namespace SOFD.Core
{

    public enum enumClassNo
    {
        Class1,
        Class3
    }

    public class COmronManager : IOManager
    {
        #region //member's
        private COmronClass1 _class1 = null;
        private COmronClass3 _class3 = null;

        private CIPPortCompolet _portCompolet = null;

        private CBasicCore _core = null;
        private CEMPCore _mainEMPCore = null;
        private CMainCore _mainMainCore = null;
        private DateTime _startTime = new DateTime();
        private enumMelsecConnect _melsecConnect = enumMelsecConnect.DISCONNECT;
        private enumScanMelsecConnect _scanConnect = enumScanMelsecConnect.DISCONNECT;
        //private CScanControlPropertiesCollections _scanAttribute = new CScanControlPropertiesCollections();

        private Thread _threadWatcher = null;

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
        public event delegateIOManagerCloseHandler IOManagerClose = null;
        #endregion

        #region //constructor's
        /// <summary>
        /// COmronManager Constructor
        /// </summary>
        public COmronManager()
        {
            _portCompolet = new CIPPortCompolet();
            _class1 = new COmronClass1(this);
            _class3 = new COmronClass3(this);
        }

        public void Disconnect(string className, string reason)
        {
            if (IOManagerClose != null)
                IOManagerClose(className, reason);
        }

        /// <summary>
        /// CMelsecNetManager Constructor
        /// CMain Set
        /// </summary>
        /// <param name="main"></param>
        public COmronManager(CBasicCore main)
            : this()
        {
            SetCore(main);

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
            SetCore(main);
            SetSystemMode(systemMode);
        }

        #endregion
        public void SetCore(CBasicCore main)
        {
            _core = main;
            if (main is CEMPCore)
            {
                _mainEMPCore = main as CEMPCore;
            }
            else if (main is CMainCore)
            {
                _mainMainCore = main as CMainCore;
            }
        }

        public void SetSystemMode(string systemMode)
        {
            _startTime = DateTime.Now;
        }
        #region //method's
        /// <summary>
        /// Scan 할 모든 Attribute Set Method
        /// </summary>
        /// <param name="scanAttribute"></param>
        public void SetScanAttribute(CScanControlPropertiesCollections scanAttribute)
        {
            //_scanAttribute = scanAttribute;
            _class1.SetScanAttribute(scanAttribute, new CIControlAttributeCollection());
            _class3.SetScanAttribute(scanAttribute, new CIControlAttributeCollection());
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
            int iRet = 0;
            int portID = cs.GetValue<int>("PORTID", 2);

            PortInformation portInfo = _portCompolet.GetPortInformation(portID);
            if (portInfo == null)
            {
                iRet = -99;
            }
            else
            {
                if (!_portCompolet.IsOpened(portID))
                {
                    _portCompolet.Open(portID);
                }
                //already open
            }

            iRet = _class1.Open();
            if (iRet != 0 && _core != null)
                _core.Log((new CMelsecLogFormat(Catagory.Debug, "SYSMAC GATEWAY OPEN FAILURE RETRUN CODE=" + iRet.ToString(), "MelsecNetDriverOpen()", true)));
            
            iRet = _class3.Open(cs);
            if (iRet != 0 && _core != null)
                _core.Log((new CMelsecLogFormat(Catagory.Debug, "SYSMAC GATEWAY OPEN FAILURE RETRUN CODE=" + iRet.ToString(), "MelsecNetDriverOpen()", true)));

            if (_portCompolet.IsOpened(portID) && _class1.IsConnected && _class3.IsConnected)
            {
                if (_core != null)
                    _core.Log((new CMelsecLogFormat(Catagory.Debug, "SYSMAC GATEWAY CONNECT", "MelsecNetDriverOpen()", true)));

                _melsecConnect = enumMelsecConnect.CONNECT;

                if (IOManagerOpen != null)
                    IOManagerOpen(this, true);
            }
            else
            {
                if(_core != null)
                    _core.Log((new CMelsecLogFormat(Catagory.Debug, string.Format("SYSMAC GATEWAY DISCONNECT [CLASS1={0} CLASS3={1}]", _class1.IsConnected ? "OK" : "NG", _class3.IsConnected ? "OK" : "NG"), "MelsecNetDriverOpen()", true)));
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
            _melsecConnect = enumMelsecConnect.DISCONNECT;

            _class1.Close();
            _class3.Close();
            _portCompolet.Close(portID);

            if (IOManagerOpen != null)
                IOManagerOpen(this, false);
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
            //if (_melsecConnect == enumMelsecConnect.CONNECT || address.Contains("Class1"))
            //{
                if(_class1.IsClass1(address))
                {
                    iRet = _class1.WriteValiableClass1(address, value);
                    CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Info, false, ownerId, name, portID.ToString(), deviceType.ToString(), address, 1, value, iRet, display));
                    return iRet;
                }
                else if (_class3.IsClass3(address))
                {
                    iRet = _class3.WriteValiableClass3(address, value);
                    CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Info, false, ownerId, name, portID.ToString(), deviceType.ToString(), address, 1, value, iRet, display));
                    return iRet;
                }
            //}
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
        public void MelsecNetWordWrite(string ownerId, string name, string address, enumDeviceType deviceType, int data)
        {
            int iRet = -99;

            //if (_melsecConnect == enumMelsecConnect.CONNECT || address.Contains("Class1"))
            //{                
                if(_class1.IsClass1(address))
                {
                    iRet = _class1.WriteValiableClass1(address, data);
                    CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Info, false, ownerId, name, portID.ToString(), deviceType.ToString(), address, 1, data.ToString(), iRet, true));
                }
                else if (_class3.IsClass3(address))
                {
                    iRet = _class3.WriteValiableClass3(address, data);
                    CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Info, false, ownerId, name, portID.ToString(), deviceType.ToString(), address, 1, data.ToString(), iRet, true));
                }
            //}
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
            //if (_melsecConnect == enumMelsecConnect.CONNECT || address.Contains("Class1"))
            //{
                if(_class1.IsClass1(address))
                {
                    iRet = _class1.WriteValiableClass1(address, data);
                }
                else if (_class3.IsClass3(address))
                {
                    iRet = _class3.WriteValiableClass3(address, data);
                    CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Info, false, ownerId, name, portID.ToString(), deviceType.ToString(), address, 1, data.ToString(), iRet, true));
                }
            //}
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
            //if (_melsecConnect == enumMelsecConnect.CONNECT || address.Contains("Class1"))
            //{
                StringBuilder sb = new StringBuilder();
                if (_class1.IsClass1(address))
                {
                    iRet = _class1.WriteValiableMultiClass1(address, data);
                    
                    foreach (int item in data)
                    {
                        if (sb.ToString() != "")
                            sb.Append(",");
                        sb.Append(item.ToString());
                    }
                    CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Info, false, ownerId, name, portID.ToString(), deviceType.ToString(), address, data.Count, sb.ToString(), iRet, true));
                }
                else if(_class3.IsClass3(address))
                {
                    iRet = _class3.WriteValiableMultiClass3(address, data);

                    foreach (int item in data)
                    {
                        if (sb.ToString() != "")
                            sb.Append(",");
                        sb.Append(item.ToString());
                    }
                    CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Info, false, ownerId, name, portID.ToString(), deviceType.ToString(), address, data.Count, sb.ToString(), iRet, true));
                }
            //}

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
            //if (_melsecConnect == enumMelsecConnect.CONNECT || address.Contains("Class1"))
            //{
                StringBuilder sb = new StringBuilder();
                if (_class1.IsClass1(address))
                {
                    iRet = _class1.WriteValiableMultiClass1(address, data);
                    
                    foreach (ushort item in data)
                    {
                        if (sb.ToString() != "")
                            sb.Append(",");
                        sb.Append(item.ToString());
                    }
                    CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Info, false, ownerId, name, portID.ToString(), deviceType.ToString(), address, data.Count, sb.ToString(), iRet, true));
                }
                else if (_class3.IsClass3(address))
                {
                    iRet = _class3.WriteValiableMultiClass3(address, data);

                    foreach (ushort item in data)
                    {
                        if (sb.ToString() != "")
                            sb.Append(",");
                        sb.Append(item.ToString());
                    }
                    CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Info, false, ownerId, name, portID.ToString(), deviceType.ToString(), address, data.Count, sb.ToString(), iRet, true));
                }
            //}
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
            //if (_melsecConnect == enumMelsecConnect.CONNECT || address.Contains("Class1"))
            //{
                if(_class1.IsClass1(address))
                {
                    resultData = _class1.ReadValiableMultiClass1(address);
                    StringBuilder sb = new StringBuilder();
                    foreach (ushort item in resultData)
                    {
                        if (sb.ToString() != "")
                            sb.Append(",");
                        sb.Append(item.ToString());
                    }
                    CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Info, true, ownerId, name, portID.ToString(), deviceType.ToString(), address, length, sb.ToString(), 0, true));

                }
                else if (_class3.IsClass3(address))
                {
                    resultData = _class3.ReadValiableMultiClass3(address);
                    StringBuilder sb = new StringBuilder();
                    foreach (ushort item in resultData)
                    {
                        if (sb.ToString() != "")
                            sb.Append(",");
                        sb.Append(item.ToString());
                    }
                    CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Info, true, ownerId, name, portID.ToString(), deviceType.ToString(), address, length, sb.ToString(), 0, true));

                }
            //}
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
            //if (_melsecConnect == enumMelsecConnect.CONNECT || address.Contains("Class1"))
            //{
                if (_class1.IsClass1(address))
                {
                    object value = _class1.ReadValiableClass1(address);
                    resultData = value.ToString();
                    CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Info, true, ownerId, name, portID.ToString(), deviceType.ToString(), address, 1, resultData, 0, true));
                }
                else if(_class3.IsClass3(address))
                {
                    object value = _class3.ReadValiableClass3(address);
                    resultData = value.ToString();
                    CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Info, true, ownerId, name, portID.ToString(), deviceType.ToString(), address, 1, resultData, 0, true));
                }
            //}
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
            //if (_melsecConnect == enumMelsecConnect.CONNECT || address.Contains("Class1"))
            //{
                if (_class1.IsClass1(address))
                {
                    object value = _class1.ReadValiableClass1(address);
                    resultData = value.ToString();
                    CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Info, true, ownerId, name, portID.ToString(), deviceType.ToString(), address, 1, resultData, 0, true));
                    return (bool)value;
                }
                else if (_class3.IsClass3(address))
                {
                    object value = _class3.ReadValiableClass3(address);
                    resultData = value.ToString();
                    CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Info, true, ownerId, name, portID.ToString(), deviceType.ToString(), address, 1, resultData, 0, true));
                    return (bool)value;
                }
            //}

            return false;
        }
        public CScanControlPropertiesCollections _scanAttribute = new CScanControlPropertiesCollections();
        public CIControlAttributeCollection _controlAttribute = new CIControlAttributeCollection();
        /// <summary>
        /// MelsecNet Driver Scan Start Method
        /// </summary>
        public void MelsecNetScanStart()
        {
            CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Debug, "OMRON SCAN START INIT", "", true));
            if (_melsecConnect == enumMelsecConnect.CONNECT)
            {
                if (_scanConnect == enumScanMelsecConnect.DISCONNECT)
                {
                    if (_mainEMPCore != null)
                    {
                        _scanAttribute = _mainEMPCore.SCANCONTEROLS;
                        _controlAttribute = _mainEMPCore.CONTROLATTRIBUTES;
                    }
                    else if (_mainMainCore != null)
                    {
                        _scanAttribute = _mainMainCore.SCANCONTEROLS;
                        _controlAttribute = _mainMainCore.CONTROLATTRIBUTES;
                    }
                    _class1.SetScanAttribute(_scanAttribute, _controlAttribute);
                    _class3.SetScanAttribute(_scanAttribute, _controlAttribute);

                    MelsecNetScanStarting();

                    _scanConnect = enumScanMelsecConnect.CONNECT;
                    CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Debug, "OMRON SCAN START COMPLETED", "", true));
                }
                else
                {
                    CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Debug, "OMRON SCAN START ERROR", "이미 연결 된 상태입니다. 해당 로그 외에 프로그램 처리 로직이 없습니다!", true));
                }
            }
            else
            {
                CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Debug, "OMRON SCAN START ERROR", "OMRON DISCONNECT 상태입니다. 드라이버 연결 상태 및 MELSEC CARD 상태를 확인 하십시오! MelscNetScanStarting()을 시작하지 못했습니다.", true));
            }
        }
        /// <summary>
        /// MelsecNet Driver Scan Stop Method
        /// </summary>
        public void MelsecNetScanStop()
        {
            _enable = false;
            _class1.ScanStop();
            //_class3.ScanStop();
        }
        /// <summary>
        /// MelsecNet Scan Starting
        /// </summary>
        private void MelsecNetScanStarting()
        {
            _threadWatcher = new Thread(new ThreadStart(DoScan));
            _threadWatcher.Priority = ThreadPriority.Normal;
            _threadWatcher.IsBackground = true;
            _enable = true;
            _threadWatcher.Start();
            CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Debug, "OMRON SCAN STARTED", "PRIORITY=" + _threadWatcher.Priority.ToString() + " ISBACKGROUND=" + _threadWatcher.IsBackground.ToString() + " THREADSTATE=" + _threadWatcher.ThreadState.ToString(), true));
        }
        /// <summary>
        /// Thread Start Method
        /// </summary>
        protected virtual void DoScan()
        {
            while (_enable)
            {
                if (!_class1.IsScan)
                {
                    _class1.ScanInit();
                    _class1.ScanStart();
                }
                if (!_class3.IsScan)
                {
                    _class3.ScanInit();
                    _class3.ScanStart();
                }


                if (!_class1.IsConnected || !_class3.IsConnected)
                {
                    if (IOManagerClose != null)
                        IOManagerClose("Disconnect", "Disconnect");
                }
                else
                {
                    if (IOManagerOpen != null)
                        IOManagerOpen(this, true);
                }

                //PortInformation pi = _portCompolet.GetPortInformation(this.portID);
                //string temp = Encoding.ASCII.GetString(pi.SpecificSubData);
                //NetworkInterface[] network = NetworkInterface.GetAllNetworkInterfaces();
                //foreach (NetworkInterface item in network)
                //{
                //    if (temp.Contains(item.Id))
                //    {
                //        if (item.OperationalStatus != OperationalStatus.Up)
                //        {
                //            CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Debug, "NETWORK CARD NOT UP.", " CHECK CONNECTION OR CABLE", true));
                //            _class3.Close();
                //            if (IOManagerClose != null)
                //                IOManagerClose("Disconnect", "Disconnect");
                //        }
                //    }
                //}

                Thread.Sleep(1000);
            }
            CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Debug, "OMRON SCAN STOP", "DoScan() 메서드 실행이 완료 되었습니다._enable=" + _enable.ToString(), true));
        }

        #endregion

        #region IOManager 멤버
        public bool CompareValue(string strCurrentValue, bool bValue)
        {
            return (strCurrentValue.ToUpper() == "TRUE") == bValue;
        }
        public bool CompareValue(string strCurrentValue, string bValue)
        {
            return strCurrentValue == bValue;
        }

        public int MelsecNetBitOnOff(AControlProperties property, bool value)
        {
            if (property.DataType.ToUpper() == "BOOLEAN")
            {
                int iRet = -99;

                if (_class1.IsClass1(property.Area))
                {
                    iRet = _class1.WriteValiableClass1(property.Area, value);
                    if (!this.CompareValue(property.RawData, value))
                    {
                        property.RawData = value.ToString();
                        CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Info, false, property.ControlName, property.AttributeName, portID.ToString(), property.DeviceType, property.Area, property.Length, value, iRet, property.Display));
                    }
                    property.Value = value.ToString();
                    return iRet;
                }
                else if (_class3.IsClass3(property.Area))
                {
                    iRet = _class3.WriteValiableClass3(property.Area, value);
                    if (!this.CompareValue(property.RawData, value))
                    {
                        property.RawData = value.ToString();
                        CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Info, false, property.ControlName, property.AttributeName, portID.ToString(), property.DeviceType, property.Area, property.Length, value, iRet, property.Display));
                    }
                    property.Value = value.ToString();
                    return iRet;
                }
                return iRet;
            }
            throw new ArgumentException(string.Format("{0} data type is {1}! not boolean. check! plc or scancontrol.xml", property.AttributeName, property.DataType));
        }

        public bool MelsecNetBitRead(AControlProperties property, int length)
        {
            if (property.DataType.ToUpper() == "BOOLEAN")
            {
                int iRet = -99;
                object value = false;

                if (_class1.IsClass1(property.Area))
                {
                    value = _class1.ReadValiableClass1(property.Area);
                    if (value == null || string.IsNullOrEmpty(value.ToString()))
                        value = false;;

                    if (!this.CompareValue(property.RawData, value.ToString()))
                    {
                        property.RawData = value.ToString();
                        CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Info, false, property.ControlName, property.AttributeName, portID.ToString(), property.DeviceType, property.Area, property.Length, value.ToString(), iRet, property.Display));
                    }
                    property.Value = value.ToString();
                }
                else if (_class3.IsClass3(property.Area))
                {
                    value = _class3.ReadValiableClass3(property.Area);
                    if (value == null || string.IsNullOrEmpty(value.ToString()))
                        value = false;;

                    if (!this.CompareValue(property.RawData, value.ToString()))
                    {
                        property.RawData = value.ToString();
                        CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Info, false, property.ControlName, property.AttributeName, portID.ToString(), property.DeviceType, property.Area, property.Length, value.ToString(), iRet, property.Display));
                    }
                    property.Value = value.ToString();
                }
                else
                {
                    value = false;;
                }
                return (bool)value;
            }
            throw new ArgumentException(string.Format("{0} data type is {1}! not boolean. check! plc or scancontrol.xml", property.AttributeName, property.DataType));
        }
        public bool[] MelsecNetMultiBitRead(AControlProperties property, int length)
        {
            throw new NotSupportedException();
            //if (property.DataType.ToUpper() == "BOOLEAN")
            //{
            //    int iRet = -99;
            //    object value = false;

            //    if (_class1.IsClass1(property.Area))
            //    {
            //        value = _class1.ReadValiableClass1(property.Area);
            //        if (value == null)
            //            value = false;;

            //        if (property.Value != value.ToString())
            //            CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Info, false, property.ControlName, property.AttributeName, portID.ToString(), property.DeviceType, property.Area, property.Length, value.ToString(), iRet, property.Display));
            //        property.Value = value.ToString();
            //    }
            //    else if (_class3.IsClass3(property.Area))
            //    {
            //        value = _class3.ReadValiableClass3(property.Area);
            //        if (value == null)
            //            value = false;;

            //        if (property.Value != value.ToString())
            //            CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Info, false, property.ControlName, property.AttributeName, portID.ToString(), property.DeviceType, property.Area, property.Length, value.ToString(), iRet, property.Display));
            //        property.Value = value.ToString();
            //    }
            //    return (bool)value;
            //}
            //throw new ArgumentException(string.Format("{0} data type is {1}! not boolean. check! plc or scancontrol.xml", property.AttributeName, property.DataType));
        }
        public ushort[] MelsecNetMultiWordRead(AControlProperties property, int length)
        {
            ushort[] resultData = new ushort[length];
            //if (_melsecConnect == enumMelsecConnect.CONNECT || address.Contains("Class1"))
            //{
            if (_class1.IsClass1(property.Area))
            {
                resultData = _class1.ReadValiableMultiClass1(property.Area);
                StringBuilder sb = new StringBuilder();
                foreach (ushort item in resultData)
                {
                    if (sb.ToString() != "")
                        sb.Append(",");
                    sb.Append(item.ToString());
                }
                if (!CompareValue(property.RawData, sb.ToString()))
                {
                    property.RawData = sb.ToString();
                    CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Info, false, property.ControlName, property.AttributeName, portID.ToString(), property.DeviceType, property.Area, length, sb.ToString(), 0, true));
                }

            }
            else if (_class3.IsClass3(property.Area))
            {
                resultData = _class3.ReadValiableMultiClass3(property.Area);
                StringBuilder sb = new StringBuilder();
                foreach (ushort item in resultData)
                {
                    if (sb.ToString() != "")
                        sb.Append(",");
                    sb.Append(item.ToString());
                }
                if (!CompareValue(property.RawData, sb.ToString()))
                {
                    property.RawData = sb.ToString();
                    CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Info, false, property.ControlName, property.AttributeName, portID.ToString(), property.DeviceType, property.Area, length, sb.ToString(), 0, true));
                }
            }
            //}
            return resultData;
        }

        public ushort[] MelsecNetMultiWordRead(AControlProperties property)
        {
            return MelsecNetMultiWordRead(property, property.Length);
        }

        public void MelsecNetMultiWordWrite(AControlProperties property, List<int> data)
        {
            int iRet = 0;
            //if (_melsecConnect == enumMelsecConnect.CONNECT || address.Contains("Class1"))
            //{
            StringBuilder sb = new StringBuilder();
            if (_class1.IsClass1(property.Area))
            {
                iRet = _class1.WriteValiableMultiClass1(property.Area, data);

                foreach (int item in data)
                {
                    if (sb.ToString() != "")
                        sb.Append(",");
                    sb.AppendLine(item.ToString());
                }
                if (!CompareValue(property.RawData, sb.ToString()))
                {
                    property.RawData = sb.ToString();
                    CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Info, false, property.ControlName, property.AttributeName, portID.ToString(), property.DeviceType, property.Area, data.Count, sb.ToString(), iRet, true));
                }
            }
            else if (_class3.IsClass3(property.Area))
            {
                iRet = _class3.WriteValiableMultiClass3(property.Area, data);

                foreach (int item in data)
                {
                    if (sb.ToString() != "")
                        sb.Append(",");
                    sb.Append(item.ToString());
                }
                if (!CompareValue(property.RawData, sb.ToString()))
                {
                    property.RawData = sb.ToString();
                    CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Info, false, property.ControlName, property.AttributeName, portID.ToString(), property.DeviceType, property.Area, data.Count, sb.ToString(), iRet, true));
                }
            }
            //}
        }

        public void MelsecNetMultiWordWrite(AControlProperties property, List<ushort> data)
        {
            throw new NotImplementedException();
        }

        public string MelsecNetWordRead(AControlProperties property)
        {
            string resultData = string.Empty;
            //if (_melsecConnect == enumMelsecConnect.CONNECT || address.Contains("Class1"))
            //{
            if (_class1.IsClass1(property.Area))
            {
                object value = _class1.ReadValiableClass1(property.Area);
                resultData = value.ToString();
                if (!CompareValue(property.RawData, resultData))
                {
                    property.RawData = resultData;
                    CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Info, true, property.ControlName, property.AttributeName, portID.ToString(), property.DeviceType.ToString(), property.Area, 1, resultData, 0, true));
                }
            }
            else if (_class3.IsClass3(property.Area))
            {
                object value = _class3.ReadValiableClass3(property.Area);
                resultData = value.ToString();
                if (!CompareValue(property.RawData, resultData))
                {
                    property.RawData = resultData;
                    CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Info, true, property.ControlName, property.AttributeName, portID.ToString(), property.DeviceType.ToString(), property.Area, 1, resultData, 0, true));
                }
            }
            //}
            return resultData;
        }

        public void MelsecNetWordWrite(AControlProperties property, ushort data)
        {
            throw new NotImplementedException();
        }

        public void MelsecNetWordWrite(AControlProperties property, int data)
        {
            int iRet = -99;
            if (_class1.IsClass1(property.Area))
            {
                iRet = _class1.WriteValiableClass1(property.Area, data);
                if (!CompareValue(property.RawData, data.ToString()))
                {
                    property.RawData = data.ToString();
                    CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Info, false, property.ControlName, property.AttributeName, portID.ToString(), property.DeviceType, property.Area, property.Length, data.ToString(), iRet, property.Display));
                }
            }
            else if (_class3.IsClass3(property.Area))
            {
                iRet = _class3.WriteValiableClass3(property.Area, data);
                if (!CompareValue(property.RawData, data.ToString()))
                {
                    property.RawData = data.ToString();
                    CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Info, false, property.ControlName, property.AttributeName, portID.ToString(), property.DeviceType, property.Area, property.Length, data.ToString(), iRet, property.Display));
                }
            }
        }

        #endregion

    }

    public class COmronClass1
    {
        private CScanControlPropertiesCollections _scanAttribute = new CScanControlPropertiesCollections();
        private CIControlAttributeCollection _controlAttributes = new CIControlAttributeCollection();
        private VariableCompolet _class1 = null;
        public bool IsConnected = false;
        protected bool CheckConnected()
        {
            IsConnected = _class1 != null && _class1.Active;
            return IsConnected;
        }

        public bool IsScan
        {
            get
            {
                return _enable;
            }
        }

        private COmronManager _owner = null;
        public COmronClass1(COmronManager owner)
        {
            _owner = owner;
            _class1 = new VariableCompolet();

            //_class1 = new VariableCompolet();
            //_class1.Active = true;
            //_class1.PlcEncoding = Encoding.UTF8;
        }

        public void SetScanAttribute(CScanControlPropertiesCollections scanAttribute, CIControlAttributeCollection controlAttributes)
        {
            _scanAttribute = new CScanControlPropertiesCollections();
            _controlAttributes = new CIControlAttributeCollection();

            foreach (CScanControlProperties item in scanAttribute.Values)
            {
                string area = item.Area.ToUpper();
                if (area.StartsWith("CLASS1"))
                {
                    _scanAttribute.Add(_scanAttribute.Count, item);
                    _controlAttributes.Add(controlAttributes.GetProperty(item.ControlName, item.AttributeName));
                }
                else if (area.StartsWith("CLASS3"))
                {
                    //_scanAttribute.Add(_scanAttribute.Count, item);
                }
                else
                {
                    CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Debug, string.Format("UNKNOWN CLASS TYPE {0} {1} {2}", item.ControlName, item.AttributeName, item.Area), "", true));
                }
            }
        }
        public int Open()
        {

            try
            {
                _class1.Active = true;
                this.CheckConnected();
                return 0;
            }
            catch (Exception ex)
            {
                CLogManager.Instance.LogError(string.Format("Class1 active error"), ex);
            }
            return -99;
        }
        public void Close()
        {
            _enable = false;
            _class1.Active = false;
        }
        public bool IsClass1(string area)
        {
            return area.StartsWith("Class1");
        }

        public bool IsClass1Active()
        {
            return _class1.Active;
        }

        public object _class1ReadWriteLock = new object();

        public int WriteValiableClass1(string address, object value)
        {
            lock (_class1ReadWriteLock)
            {
                //Console.WriteLine(string.Format("WRITE VALIABLE START {0}", address));
                try
                {
                    enumClassNo classNo = enumClassNo.Class1;
                    string temp = "";
                    if (address.StartsWith("Class1"))
                    {
                        if (!CheckConnected())
                            return -1;
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
                        Console.WriteLine(string.Format("WRITE VALIABLE ERROR {0}", address));
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
                        splitedAddress = address.Split(',');
                    }

                    _class1.WriteVariable(splitedAddress[1], value);

                    //Console.WriteLine(string.Format("WRITE VALIABLE END {0}", address));

                    return 0;
                }
                catch (OMRON.CIP.ObjectLibrary.CIPObjectException cipEx)
                {
                    //_owner.Disconnect("class1", cipEx.Message);
                    CLogManager.Instance.LogError(string.Format("WriteValiable EXECUTE ERROR {0}", address), cipEx);
                    Console.WriteLine(string.Format("WRITE VALIABLE END [ERROR] {0}", address));
                    return -97;
                }
                catch (Exception ex)
                {
                    //_owner.Disconnect("class1", ex.Message);
                    Console.WriteLine(string.Format("WRITE VALIABLE END [ERROR] {0}", address));
                    CLogManager.Instance.LogError(string.Format("WriteValiable EXECUTE ERROR {0} {1}", address, value), ex);
                    return -98;
                }
            }

        }

        public int WriteValiableMultiClass1(string address, List<int> value)
        {
            lock (_class1ReadWriteLock)
            {
                //Console.WriteLine(string.Format("WRITE VALIABLE START {0}", address));

                //List<byte> byteArray = new List<byte>();
                //string temp = "";
                //foreach (int item in value)
                //{
                //    byte low = (byte)(item & 0xFF);
                //    byte high = (byte)(item >> 8);

                //    byteArray.Add(low);
                //    byteArray.Add(high);

                //    temp += string.Format("{0}{1}", (char)high, (char)low);
                //}

                try
                {
                    enumClassNo classNo = enumClassNo.Class1;
                    string temp = "";
                    bool isString = false;
                    if (address.StartsWith("Class1"))
                    {
                        if (!CheckConnected())
                            return -1;
                        classNo = enumClassNo.Class1;
                        temp = address.Replace("Class1,", "");
                    }
                    else if (address.StartsWith("Class3"))
                    {
                        classNo = enumClassNo.Class3;
                        if (address.Contains(":String"))
                        {
                            temp = address.Replace("Class3:String,", "");
                            isString = true;
                        }
                        else
                        {
                            temp = address.Replace("Class3,", "");
                        }
                    }
                    else
                    {
                        Console.WriteLine(string.Format("WRITE VALIABLE ERROR {0}", address));
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
                        splitedAddress = address.Split(',');
                    }

                    OMRON.Compolet.Variable.VariableInfo variableInfo = _class1.GetVariableInfo(splitedAddress[1]);
                    if (variableInfo.Type == OMRON.Compolet.Variable.VariableType.STRUCT)
                    {
                        //cibal    20170324
                        List<int> plcData = new List<int>();

                        foreach (int item in value)
                        {
                            plcData.Add(UpperLowerChange(item));
                        }

                        _class1.WriteVariable(splitedAddress[1], DataConverter.IntsToWords(plcData.ToArray(), OMRON.Compolet.CIP.DataTypes.BIN));
                    }
                    else
                    {
                        _class1.WriteVariable(splitedAddress[1], DataConverter.IntsToWords(value.ToArray(), OMRON.Compolet.CIP.DataTypes.BIN));
                    }
                    //Console.WriteLine(string.Format("WRITE VALIABLE END {0}", address));

                    return 0;
                }
                catch (OMRON.CIP.ObjectLibrary.CIPObjectException cipEx)
                {
                    CLogManager.Instance.LogError(string.Format("WriteValiableMulti EXECUTE ERROR {0}", address), cipEx);
                    Console.WriteLine(string.Format("WRITE VALIABLE END [ERROR] {0}", address));
                    return -97;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format("WRITE VALIABLE END [ERROR] {0}", address));
                    CLogManager.Instance.LogError(string.Format("WriteValiableMulti EXECUTE ERROR {0} {1}", address, value), ex);
                    return -98;
                }
            }

        }

        public static int UpperLowerChange(int lowerUpperValue)
        {
            return (lowerUpperValue & 0xFF) << 8 | lowerUpperValue >> 8;
        }

        public int WriteValiableMultiClass1(string address, List<ushort> value)
        {
            lock (_class1ReadWriteLock)
            {
                Console.WriteLine(string.Format("WRITE VALIABLE START {0}", address));

                //List<byte> byteArray = new List<byte>();
                //string temp = "";
                //foreach (int item in value)
                //{
                //    byte low = (byte)(item & 0xFF);
                //    byte high = (byte)(item >> 8);

                //    byteArray.Add(low);
                //    byteArray.Add(high);

                //    temp += string.Format("{0}{1}", (char)high, (char)low);
                //}

                try
                {
                    enumClassNo classNo = enumClassNo.Class1;
                    string temp = "";
                    if (address.StartsWith("Class1"))
                    {
                        if (!CheckConnected())
                            return -1;
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
                        Console.WriteLine(string.Format("WRITE VALIABLE ERROR {0}", address));
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
                        splitedAddress = address.Split(',');
                    }


                    _class1.WriteVariable(splitedAddress[1], value);
                    Console.WriteLine(string.Format("WRITE VALIABLE END {0}", address));

                    return 0;
                }
                catch (OMRON.CIP.ObjectLibrary.CIPObjectException cipEx)
                {
                    CLogManager.Instance.LogError(string.Format("WriteValiableMulti EXECUTE ERROR {0}", address), cipEx);
                    Console.WriteLine(string.Format("WRITE VALIABLE END [ERROR] {0}", address));
                    return -97;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format("WRITE VALIABLE END [ERROR] {0}", address));
                    CLogManager.Instance.LogError(string.Format("WriteValiableMulti EXECUTE ERROR {0} {1}", address, value), ex);
                    return -98;
                }
            }

        }

        public object ReadValiableClass1(string address)
        {
            lock (_class1ReadWriteLock)
            {
                //Console.WriteLine(string.Format("READ VALIABLE START {0}", address));
                try
                {
                    enumClassNo classNo = enumClassNo.Class1;
                    string temp = "";
                    if (address.StartsWith("Class1"))
                    {
                        if (!CheckConnected())
                            return "";
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
                        Console.WriteLine(string.Format("READ VALIABLE ERROR {0}", address));
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
                        splitedAddress = address.Split(',');
                    }

                    object value = "";
                    if (splitedAddress[1] == "SD_B_TerminalText_BCToL3")
                    {

                    }
                    value = _class1.ReadVariable(splitedAddress[1]);
                    //Console.WriteLine(string.Format("READ VALIABLE END {0}", address));
                    return value == null ? "" : value;
                }
                catch (OMRON.CIP.ObjectLibrary.CIPObjectException cipEx)
                {
                    CLogManager.Instance.LogError(string.Format("ReadValiable EXECUTE ERROR {0}", address), cipEx);
                    Console.WriteLine(string.Format("READ VALIABLE END [ERROR] {0}", address));
                    return "";
                }
                catch (Exception ex)
                {
                    CLogManager.Instance.LogError(string.Format("ReadValiable EXECUTE ERROR {0}", address), ex);
                    Console.WriteLine(string.Format("READ VALIABLE END [ERROR] {0}", address));
                    return "";
                }
            }
        }

        public ushort[] ReadValiableMultiClass1(string address)
        {
            ushort[] resultData = new ushort[0];
            lock (_class1ReadWriteLock)
            {
                //Console.WriteLine(string.Format("READ VALIABLE START {0}", address));
                try
                {
                    enumClassNo classNo = enumClassNo.Class1;
                    string temp = "";
                    if (address.StartsWith("Class1"))
                    {
                        if (!CheckConnected())
                            return resultData;
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
                        Console.WriteLine(string.Format("READ VALIABLE ERROR {0}", address));
                        return resultData;
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
                        splitedAddress = address.Split(',');
                    }

                    object value = "";

                    value = _class1.ReadVariable(splitedAddress[1]);
                    //Console.WriteLine(string.Format("READ VALIABLE END {0}", address));

                    //OMRON.Compolet.Variable.VariableInfo variableInfo2 = _class1.GetVariableInfo(splitedAddress[1]);
                    if (value == null || string.IsNullOrEmpty(value.ToString()))
                    {
                        resultData = new ushort[0];
                    }
                    else
                    {
                        List<ushort> temp1 = new List<ushort>();
                        Type valueType = value.GetType();
                        if (valueType == typeof(byte[]))
                        {
                            List<byte> bytes = new List<byte>((byte[])value);
                            Array array = value as Array;

                            bool word = false;
                            byte upper = 0;
                            byte lower = 0;
                            ushort value1 = 0;
                            foreach (object item in array)
                            {
                                ushort.TryParse(item.ToString(), out value1);
                                if (!word)
                                {
                                    upper = (byte)(value1 & 0xFF);
                                    word = true;
                                }
                                else
                                {
                                    word = false;
                                    lower = (byte)item;
                                    temp1.Add((ushort)((upper << 8) | lower));
                                }
                            }
                        }
                        else if (valueType == typeof(ushort[]))
                        {
                            temp1 = new List<ushort>((ushort[])value);
                        }

                        resultData = temp1.ToArray();
                    }

                    return resultData;
                }
                catch (OMRON.CIP.ObjectLibrary.CIPObjectException cipEx)
                {
                    CLogManager.Instance.LogError(string.Format("ReadValiableMulti EXECUTE ERROR {0}", address), cipEx);
                    Console.WriteLine(string.Format("READ VALIABLE END [ERROR] {0}", address));
                    return resultData;
                }
                catch (Exception ex)
                {
                    CLogManager.Instance.LogError(string.Format("ReadValiableMulti EXECUTE ERROR {0}", address), ex);
                    Console.WriteLine(string.Format("READ VALIABLE END [ERROR] {0}", address));
                    return resultData;
                }
            }
        }

        private bool _enable = false;
        private bool _isFirstScan = true;
        private Thread _thread = null;
        public void ScanInit()
        {
            if (_scanAttribute.Count == 0)
            {
                CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Debug, "OMRON CLASS1 SCAN STOP", "SCAN할 대상이 없습니다. if (_scanProperies.Count == 0) ", true));
            }

            string sscanarea = string.Empty;

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
                        CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "OMRON CLASS1 SCAN ERROR", ex));
                    }
                }
                _isFirstScan = false;
            }

            _isFirstScan = false;
        }
        public void ScanStart()
        {
            _enable = true;
            _thread = new Thread(new ThreadStart(Scan));
            _thread.Priority = ThreadPriority.Normal;
            _thread.Name = "CLASS3_SCAN";
            _thread.IsBackground = true;
            _thread.Start();
        }

        public void ScanStop()
        {
            _enable = false;
            _isFirstScan = true;
        }

        private void Scan()
        {
            if (_isFirstScan)
                ScanInit();

            while (_enable)
            {
                foreach (CScanControlProperties scanProperty in _scanAttribute.Values)
                {
                    try
                    {
                        if (!_enable)
                            return;

                        if (!scanProperty.Monitoring)
                            continue;

                        if (scanProperty.ScanDeviceType == enumDeviceType.W || scanProperty.ScanDeviceType == enumDeviceType.R)
                        {
                            MelsecNetScanWord(scanProperty.ScanArea, scanProperty);
                        }
                        else if (scanProperty.ScanDeviceType == enumDeviceType.B || scanProperty.ScanDeviceType == enumDeviceType.M)
                        {
                            MelsecNetScanBit(scanProperty.ScanArea, scanProperty);
                        }
                    }
                    catch (Exception ex)
                    {
                        CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "OMRON CLASS1 SCAN ERROR", ex));
                    }
                }
                Thread.Sleep(200);
            }

            CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Debug, "OMRON CLASS1 SCAN STOP", "Scan() 메서드 실행이 완료 되었습니다._enable=" + _enable.ToString(), true));
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

            object value = false;
            value = ReadValiableClass1(address);

            bValue = value == null || value.ToString() == "" ? false : bool.Parse(value.ToString());

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

            object value = ReadValiableClass1(address);

            if (value == null)
                value = "";

            sGetValue = value.ToString();

            if (scanproperty.Value != sGetValue)
            {
                scanproperty.Value = sGetValue;

                if (scanproperty.PreviousValue == null)
                    scanproperty.PreviousValue = "";

                CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Info, scanproperty, scanproperty.PreviousValue, sGetValue));

                foreach (CControlAttribute attribute in _controlAttributes.Values)
                {
                    if (scanproperty.ScanControlName == attribute.ControlName)
                    {
                        if (scanproperty.ScanAttribute == attribute.Attribute)
                        {
                            attribute.WordEvent(scanproperty.PreviousValue, sGetValue);
                            break;
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

            foreach (CControlAttribute attribute in _controlAttributes.Values)
            {
                if (scanproperty.ScanControlName == attribute.ControlName)
                {
                    if (scanproperty.ScanAttribute == attribute.Attribute)
                    {
                        attribute.BitEvent(value);
                        break;
                    }
                }
            }
            return bValue;
        }
    }

    public class COmronClass3
    {
        private CScanControlPropertiesCollections _scanAttribute = new CScanControlPropertiesCollections();
        private CIControlAttributeCollection _controlAttributes = new CIControlAttributeCollection();
        private CJ2Compolet _class3 = null;
        public bool IsConnected = false;
        protected bool CheckConnected()
        {

            IsConnected = _class3 != null && _class3.IsConnected;
            return IsConnected;

        }

        public bool IsScan
        {
            get
            {
                return _enable;
            }
        }

        private COmronManager _owner = null;
        public COmronClass3(COmronManager owner)
        {
            _owner = owner;
            _class3 = new CJ2Compolet();
            _class3.OnHeartBeatTimer += new EventHandler(_class3_OnHeartBeatTimer);

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
        }

        private void _class3_OnHeartBeatTimer(object sender, EventArgs e)
        {
            //Console.WriteLine("HEARBEATTIMER");
        }

        public void SetScanAttribute(CScanControlPropertiesCollections scanAttribute, CIControlAttributeCollection controlAttributes)
        {
            _scanAttribute = new CScanControlPropertiesCollections();
            _controlAttributes = new CIControlAttributeCollection();

            foreach (CScanControlProperties item in scanAttribute.Values)
            {
                string area = item.Area.ToUpper();
                if (area.StartsWith("CLASS1"))
                {
                    //_scanAttribute.Add(_scanAttribute.Count, item);                        
                }
                else if (area.StartsWith("CLASS3"))
                {
                    _scanAttribute.Add(_scanAttribute.Count, item);
                    _controlAttributes.Add(controlAttributes.GetProperty(item.ControlName, item.AttributeName));
                }
                else
                {
                    CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Debug, string.Format("UNKNOWN CLASS TYPE {0} {1} {2}", item.ControlName, item.AttributeName, item.Area), "", true));
                }
            }
        }

        public int Open(CConnectionString cs)
        {
            int portID = cs.GetValue<int>("PORTID", 2);
            string plcEncoding = cs.GetValue<string>("PLC_ENCODING", "UTF8Encoding");
            string peerAddress = cs.GetValue<string>("PEER_ADDRESS", "192.168.123.42");
            ConnectionType connectionType = cs.GetValue<ConnectionType>("CONNECTION_TYPE", ConnectionType.Class3);
            int heartbeatTimer = cs.GetValue<int>("HEARTBEAT_TIMER", 1000);
            int receiveTimeLimit = cs.GetValue<int>("RECEIVE_TIME_LIMIT", 1000);
            bool useRoutePath = cs.GetValue<bool>("USE_ROUTE_PATH", false);
            string routePath = cs.GetValue<string>("ROUTE_PATH", @"2%192.168.123.42\1%0");

            try
            {
                _class3.PeerAddress = peerAddress;
                _class3.ConnectionType = ConnectionType.Class3;
                //_class3.HeartBeatTimer = heartbeatTimer;
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
                //_class3.ReceiveTimeLimit = receiveTimeLimit;
                //_class3.RoutePath = string.Format(@"2%{0}\1%0", peerAddress);
                _class3.UseRoutePath = false;
                //_class3.ReceiveTimeLimit = receiveTimeLimit;
                //_class3.ReceiveTimeLimit = long.MaxValue;
                _class3.Active = true;
                this.CheckConnected();
                string unitName = _class3.UnitName;

                return 0;
            }
            catch (Exception ex)
            {
                CLogManager.Instance.LogError(string.Format("Class3 active error"), ex);
            }
            return -99;
        }
        public void Close()
        {
            _enable = false;
            _class3.Active = false;
        }
        public bool IsClass3(string area)
        {
            return area.StartsWith("Class3");
        }

        public bool IsClass3Active()
        {
            return _class3.Active;
        }

        public object _class3ReadWriteLock = new object();

        public int WriteValiableClass3(string address, object value)
        {
            lock (_class3ReadWriteLock)
            {
                //Console.WriteLine(string.Format("WRITE VALIABLE START {0}", address));
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
                        if (!this.CheckConnected())
                            return -1;

                        classNo = enumClassNo.Class3;
                        temp = address.Replace("Class3,", "");
                    }
                    else
                    {
                        Console.WriteLine(string.Format("WRITE VALIABLE ERROR {0}", address));
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
                        splitedAddress = address.Split(',');
                    }

                    OMRON.Compolet.CIP.VariableInfo variableInfo;
                    if (splitedAddress[1].Contains('.'))
                    {
                        variableInfo = _class3.GetVariableInfo(splitedAddress[1].Substring(0, splitedAddress[1].IndexOf('.')));
                    }
                    else
                    {
                        variableInfo = _class3.GetVariableInfo(splitedAddress[1]);
                    }
                    if (useNum)
                    {
                        if (variableInfo.IsArray)
                        {
                            _class3.WriteVariable(string.Format("{0}[{1}]", splitedAddress[1], splitedAddress[2]), value);
                        }
                        else
                        {
                            //if (splitedAddress[1].Contains("RV_B"))
                            //{
                            //    bool tempvalue = bool.Parse(value == null ? false.ToString() : value.ToString());
                            //    _class3.WriteVariable(string.Format("{0}[{1}]", splitedAddress[1], splitedAddress[2]), tempvalue ? 1 : 0);// new byte[] { 1, 0 } : new byte[] { 0, 0 });
                            //}
                            //else
                            //{
                            //    _class3.WriteVariable(string.Format("{0}[{1}]", splitedAddress[1], splitedAddress[2]), value);//, int.Parse(splitedAddress[2]) + 1);
                            //}
                            _class3.WriteVariable(string.Format("{0}[{1}]", splitedAddress[1], splitedAddress[2]), value);//, int.Parse(splitedAddress[2]) + 1);
                        }

                    }
                    else
                    {
                        _class3.WriteVariable(splitedAddress[1], value);
                        //Console.WriteLine(string.Format("WRITE VALIABLE END {0}", address));
                    }

                    return 0;
                }
                catch (OMRON.CIP.ObjectLibrary.CIPObjectException cipEx)
                {
                    //_owner.Disconnect("class3", cipEx.Message);
                    CLogManager.Instance.LogError(string.Format("WriteValiable EXECUTE ERROR {0}", address), cipEx);
                    Console.WriteLine(string.Format("WRITE VALIABLE END [ERROR] {0}", address));
                    return -97;
                }
                catch (Exception ex)
                {
                    //_owner.Disconnect("class3", ex.Message);
                    Console.WriteLine(string.Format("WRITE VALIABLE END [ERROR] {0}", address));
                    CLogManager.Instance.LogError(string.Format("WriteValiable EXECUTE ERROR {0} {1}", address, value), ex);
                    return -98;
                }
            }

        }

        public int WriteValiableMultiClass3(string address, List<int> value)
        {
            lock (_class3ReadWriteLock)
            {
                //Console.WriteLine(string.Format("WRITE VALIABLE START {0}", address));

                //List<byte> byteArray = new List<byte>();
                //string temp = "";
                //foreach (int item in value)
                //{
                //    byte low = (byte)(item & 0xFF);
                //    byte high = (byte)(item >> 8);

                //    byteArray.Add(low);
                //    byteArray.Add(high);

                //    temp += string.Format("{0}{1}", (char)high, (char)low);
                //}

                try
                {
                    enumClassNo classNo = enumClassNo.Class1;
                    string temp = "";
                    bool isString = false;
                    if (address.StartsWith("Class1"))
                    {
                        classNo = enumClassNo.Class1;
                        temp = address.Replace("Class1,", "");
                    }
                    else if (address.StartsWith("Class3"))
                    {
                        if (!this.CheckConnected())
                            return -1;
                        classNo = enumClassNo.Class3;
                        if (address.Contains(":String"))
                        {
                            temp = address.Replace("Class3:String,", "");
                            isString = true;
                        }
                        else
                        {
                            temp = address.Replace("Class3,", "");
                        }
                    }
                    else
                    {
                        Console.WriteLine(string.Format("WRITE VALIABLE ERROR {0}", address));
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
                        splitedAddress = address.Split(',');
                    }

                    OMRON.Compolet.CIP.VariableInfo variableInfo;
                    variableInfo = _class3.GetVariableInfo(splitedAddress[1]);

                    if (useNum)
                    {
                        if (variableInfo.IsArray)
                        {
                            _class3.WriteVariable(string.Format("{0}[{1}]", splitedAddress[1], splitedAddress[2]), value);
                        }
                        else
                        {
                            _class3.WriteVariable(string.Format("{0}[{1}]", splitedAddress[1], splitedAddress[2]), value);//, int.Parse(splitedAddress[2]) + 1);
                        }
                    }
                    else
                    {
                        if (isString)
                        {
                            _class3.WriteVariable(splitedAddress[1], value.ToArray());
                        }
                        else if (variableInfo.Type == OMRON.Compolet.CIP.VariableType.STRUCT)
                        {
                            byte[] bytes = DataConverter.IntsToWords(value.ToArray(), OMRON.Compolet.CIP.DataTypes.BIN);
                            List<byte> bytelist = new List<byte>();

                            //for (int i = 0; i < value.Count; i++)
                            //{
                            //    bytelist.Add((byte)(value[i] & 0xFFFF));
                            //    bytelist.Add((byte)(value[i] >> 8));
                            //}
                            _class3.WriteVariable(splitedAddress[1], bytes);
                        }
                        else
                        {
                            _class3.WriteVariable(splitedAddress[1], value.ToArray());
                        }
                        //byte[] bytes = DataConverter.IntsToWords(value.ToArray(), OMRON.Compolet.CIP.DataTypes.BIN);
                        //_class3.WriteVariable(splitedAddress[1], DataConverter.ByteArrayToString(bytes, _class3.PlcEncoding));
                    }

                    //Console.WriteLine(string.Format("WRITE VALIABLE END {0}", address));

                    return 0;
                }
                catch (OMRON.CIP.ObjectLibrary.CIPObjectException cipEx)
                {
                    CLogManager.Instance.LogError(string.Format("WriteValiableMulti EXECUTE ERROR {0}", address), cipEx);
                    Console.WriteLine(string.Format("WRITE VALIABLE END [ERROR] {0}", address));
                    return -97;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format("WRITE VALIABLE END [ERROR] {0}", address));
                    CLogManager.Instance.LogError(string.Format("WriteValiableMulti EXECUTE ERROR {0} {1}", address, value), ex);
                    return -98;
                }
            }

        }

        public int WriteValiableMultiClass3(string address, List<ushort> value)
        {
            lock (_class3ReadWriteLock)
            {
                Console.WriteLine(string.Format("WRITE VALIABLE START {0}", address));

                //List<byte> byteArray = new List<byte>();
                //string temp = "";
                //foreach (int item in value)
                //{
                //    byte low = (byte)(item & 0xFF);
                //    byte high = (byte)(item >> 8);

                //    byteArray.Add(low);
                //    byteArray.Add(high);

                //    temp += string.Format("{0}{1}", (char)high, (char)low);
                //}

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
                        if (!this.CheckConnected())
                            return -1;
                        classNo = enumClassNo.Class3;
                        temp = address.Replace("Class3,", "");
                    }
                    else
                    {
                        Console.WriteLine(string.Format("WRITE VALIABLE ERROR {0}", address));
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
                        splitedAddress = address.Split(',');
                    }

                    OMRON.Compolet.CIP.VariableInfo variableInfo;
                    if (splitedAddress[1].Contains('.'))
                    {
                        variableInfo = _class3.GetVariableInfo(splitedAddress[1].Substring(0, splitedAddress[1].IndexOf('.')));
                    }
                    else
                    {
                        variableInfo = _class3.GetVariableInfo(splitedAddress[1]);
                    }
                    if (useNum)
                    {
                        if (variableInfo.IsArray)
                        {
                            _class3.WriteVariable(string.Format("{0}[{1}]", splitedAddress[1], splitedAddress[2]), value);
                        }
                        else
                        {
                            _class3.WriteVariable(string.Format("{0}[{1}]", splitedAddress[1], splitedAddress[2]), value);//, int.Parse(splitedAddress[2]) + 1);
                        }

                    }
                    else
                        _class3.WriteVariable(splitedAddress[1], value);

                    Console.WriteLine(string.Format("WRITE VALIABLE END {0}", address));

                    return 0;
                }
                catch (OMRON.CIP.ObjectLibrary.CIPObjectException cipEx)
                {
                    CLogManager.Instance.LogError(string.Format("WriteValiableMulti EXECUTE ERROR {0}", address), cipEx);
                    Console.WriteLine(string.Format("WRITE VALIABLE END [ERROR] {0}", address));
                    return -97;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format("WRITE VALIABLE END [ERROR] {0}", address));
                    CLogManager.Instance.LogError(string.Format("WriteValiableMulti EXECUTE ERROR {0} {1}", address, value), ex);
                    return -98;
                }
            }

        }

        public object ReadValiableClass3(string address)
        {
            lock (_class3ReadWriteLock)
            {
                //Console.WriteLine(string.Format("READ VALIABLE START {0}", address));
                try
                {
                    enumClassNo classNo = enumClassNo.Class1;
                    string temp = "";
                    if (address.StartsWith("Class1"))
                    {
                        throw new MethodAccessException("해당 위치에서 잘못된 Classtype을 호출함. (예:COmronClass3를 사용하면서 class1인자를 넣고 호출");
                        //classNo = enumClassNo.Class1;
                        //temp = address.Replace("Class1,", "");
                        //if (!_class1.IsConnected)
                        //    return "";
                    }
                    else if (address.StartsWith("Class3"))
                    {
                        if (!this.CheckConnected())
                            return "";
                        classNo = enumClassNo.Class3;
                        temp = address.Replace("Class3,", "");
                    }
                    else
                    {
                        Console.WriteLine(string.Format("READ VALIABLE ERROR {0}", address));
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
                        splitedAddress = address.Split(',');
                    }

                    object value = "";
                    if (splitedAddress[1] == "SD_B_TerminalText_BCToL3")
                    {

                    }

                    OMRON.Compolet.CIP.VariableInfo variableInfo;

                    variableInfo = _class3.GetVariableInfo(splitedAddress[1]);

                    if (useNum)
                    {
                        if (variableInfo.IsArray)
                        {
                            value = _class3.ReadVariable(string.Format("{0}[{1}]", splitedAddress[1], splitedAddress[2]));
                        }
                        else
                        {
                            value = _class3.ReadVariable(splitedAddress[1]);//, int.Parse(splitedAddress[2] + 1));
                        }
                    }
                    else
                    {
                        if (variableInfo.Type == OMRON.Compolet.CIP.VariableType.STRING)
                        {
                            value = _class3.ReadVariable(splitedAddress[1]);
                            if (value == null)
                                value = "";

                            byte[] bytes = DataConverter.StringToByteArray(value.ToString(), _class3.PlcEncoding);

                            List<byte> newBytes = new List<byte>();

                            for (int i = 0; i < bytes.Length; i++)
                            {
                                newBytes.Add(bytes[i + 1]);
                                newBytes.Add(bytes[i++]);
                            }
                            value = DataConverter.ByteArrayToString(newBytes.ToArray(), _class3.PlcEncoding);
                        }
                        else
                        {
                            value = _class3.ReadVariable(splitedAddress[1]);
                            Console.WriteLine(value);
                        }

                    }

                    //Console.WriteLine(string.Format("READ VALIABLE END {0}", address));
                    return value == null ? "" : value;
                }
                catch (OMRON.CIP.ObjectLibrary.CIPObjectException cipEx)
                {
                    CLogManager.Instance.LogError(string.Format("ReadValiable EXECUTE ERROR {0}", address), cipEx);
                    Console.WriteLine(string.Format("READ VALIABLE END [ERROR] {0}", address));
                    return "";
                }
                catch (Exception ex)
                {
                    CLogManager.Instance.LogError(string.Format("ReadValiable EXECUTE ERROR {0}", address), ex);
                    Console.WriteLine(string.Format("READ VALIABLE END [ERROR] {0}", address));
                    return "";
                }
            }
        }

        public ushort[] ReadValiableMultiClass3(string address)
        {
            ushort[] resultData = new ushort[0];
            lock (_class3ReadWriteLock)
            {
                //Console.WriteLine(string.Format("READ VALIABLE START {0}", address));
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
                        if (!CheckConnected())
                            return resultData;
                        classNo = enumClassNo.Class3;
                        temp = address.Replace("Class3,", "");
                    }
                    else
                    {
                        Console.WriteLine(string.Format("READ VALIABLE ERROR {0}", address));
                        return resultData;
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
                        splitedAddress = address.Split(',');
                    }

                    object value = "";

                    OMRON.Compolet.CIP.VariableInfo variableInfo;
                    variableInfo = _class3.GetVariableInfo(splitedAddress[1]);

                    if (useNum)
                    {
                        if (variableInfo.IsArray)
                        {
                            value = _class3.ReadVariable(string.Format("{0}[{1}]", splitedAddress[1], splitedAddress[2]));
                        }
                        else
                        {
                            value = _class3.ReadVariable(splitedAddress[1]);//, int.Parse(splitedAddress[2] + 1));
                        }
                    }
                    else
                    {
                        if (variableInfo.Type == OMRON.Compolet.CIP.VariableType.STRING)
                        {
                            value = _class3.ReadVariable(splitedAddress[1]);
                            if (value == null)
                                value = "";


                            int[] bytes = DataConverter.WordsToInts(DataConverter.StringToByteArray(value.ToString(), _class3.PlcEncoding), OMRON.Compolet.CIP.DataTypes.BIN);
                            List<ushort> ushortList = new List<ushort>();

                            for (int i = 0; i < bytes.Length; i++)
                            {
                                ushortList.Add((ushort)bytes[i]);
                            }
                            return ushortList.ToArray();
                        }
                        else
                        {
                            value = _class3.ReadVariable(splitedAddress[1]);
                        }
                    }
                    //Console.WriteLine(string.Format("READ VALIABLE END {0}", address));

                    //OMRON.Compolet.Variable.VariableInfo variableInfo2 = _class1.GetVariableInfo(splitedAddress[1]);
                    if (value == null || string.IsNullOrEmpty(value.ToString()))
                    {
                        resultData = new ushort[0];
                    }
                    else
                    {
                        List<ushort> temp1 = new List<ushort>();
                        Type valueType = value.GetType();
                        if (valueType == typeof(byte[]))
                        {
                            List<byte> bytes = new List<byte>((byte[])value);
                            Array array = value as Array;

                            bool word = false;
                            byte upper = 0;
                            byte lower = 0;
                            ushort value1 = 0;
                            foreach (object item in array)
                            {
                                ushort.TryParse(item.ToString(), out value1);
                                if (!word)
                                {
                                    upper = (byte)item;
                                    word = true;
                                }
                                else
                                {
                                    word = false;
                                    lower = (byte)(value1 & 0xFF);
                                    temp1.Add((ushort)((upper) | lower << 8));
                                }
                            }
                            //lowerUpperValue & 0xFF) << 8 | lowerUpperValue >> 8
                        }
                        else if (valueType == typeof(ushort[]))
                        {
                            temp1 = new List<ushort>((ushort[])value);
                        }
                        else if (valueType == typeof(int[]))
                        {
                            List<int> iTemp = new List<int>((int[])value);

                            temp1 = new List<ushort>();
                            for (int i = 0; i < iTemp.Count; i++)
                            {
                                temp1.Add((ushort)iTemp[i]);
                            }

                        }
                        resultData = temp1.ToArray();
                    }

                    //cibal    20170324
                    List<int> plcData = new List<int>();

                    return resultData;
                }
                catch (OMRON.CIP.ObjectLibrary.CIPObjectException cipEx)
                {
                    CLogManager.Instance.LogError(string.Format("ReadValiableMulti EXECUTE ERROR {0}", address), cipEx);
                    Console.WriteLine(string.Format("READ VALIABLE END [ERROR] {0}", address));
                    return resultData;
                }
                catch (Exception ex)
                {
                    CLogManager.Instance.LogError(string.Format("ReadValiableMulti EXECUTE ERROR {0}", address), ex);
                    Console.WriteLine(string.Format("READ VALIABLE END [ERROR] {0}", address));
                    return resultData;
                }
            }
        }
        private bool _enable = false;
        private object _scan = new object();
        private bool _isFirstScan = true;
        private Thread _thread = null;
        public void ScanInit()
        {
            if (_scanAttribute.Count == 0)
            {
                CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Debug, "OMRON CLASS3 SCAN STOP", "SCAN할 대상이 없습니다. if (_scanProperies.Count == 0) ", true));
            }

            string sscanarea = string.Empty;

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
                        CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "OMRON CLASS3 SCAN ERROR", ex));
                    }
                }
                _isFirstScan = false;
            }

            _isFirstScan = false;
        }
        public void ScanStart()
        {
            _enable = true;
            _thread = new Thread(new ThreadStart(Scan));
            _thread.Priority = ThreadPriority.Normal;
            _thread.Name = "CLASS3_SCAN";
            _thread.IsBackground = true;
            _thread.Start();
        }

        public void ScanStop()
        {
            _enable = false;
            _isFirstScan = true;
        }

        private void Scan()
        {
            if (_isFirstScan)
                ScanInit();

            while (_enable)
            {
                foreach (CScanControlProperties scanProperty in _scanAttribute.Values)
                {
                    try
                    {
                        if (!_enable)
                            return;

                        if (!scanProperty.Monitoring)
                            continue;

                        if (scanProperty.ScanDeviceType == enumDeviceType.W || scanProperty.ScanDeviceType == enumDeviceType.R)
                        {
                            MelsecNetScanWord(scanProperty.ScanArea, scanProperty);
                        }
                        else if (scanProperty.ScanDeviceType == enumDeviceType.B || scanProperty.ScanDeviceType == enumDeviceType.M)
                        {
                            MelsecNetScanBit(scanProperty.ScanArea, scanProperty);
                        }
                    }
                    catch (Exception ex)
                    {
                        CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "OMRON CLASS3 SCAN ERROR", ex));
                    }
                    Thread.Sleep(10);
                }
                Thread.Sleep(200);
            }

            CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Debug, "OMRON CLASS3 SCAN STOP", "Scan() 메서드 실행이 완료 되었습니다._enable=" + _enable.ToString(), true));
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

            object value = false;
            value = this.ReadValiableClass3(address);
            bValue = value == null || value.ToString() == "" ? false : bool.Parse(value.ToString());

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

            object value = "";
            value = this.ReadValiableClass3(address);

            if (value == null)
                value = "";

            sGetValue = value.ToString();

            if (scanproperty.Value != sGetValue)
            {
                scanproperty.Value = sGetValue;

                if (scanproperty.PreviousValue == null)
                    scanproperty.PreviousValue = "";

                CLogManager.Instance.Log(new CMelsecLogFormat(Catagory.Info, scanproperty, scanproperty.PreviousValue, sGetValue));

                foreach (CControlAttribute attribute in _controlAttributes.Values)
                {
                    if (scanproperty.ScanControlName == attribute.ControlName)
                    {
                        if (scanproperty.ScanAttribute == attribute.Attribute)
                        {
                            attribute.WordEvent(scanproperty.PreviousValue, sGetValue);
                            break;
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

            foreach (CControlAttribute attribute in _controlAttributes.Values)
            {
                if (scanproperty.ScanControlName == attribute.ControlName)
                {
                    if (scanproperty.ScanAttribute == attribute.Attribute)
                    {
                        attribute.BitEvent(value);
                        break;
                    }
                }
            }
            return bValue;
        }
    }
}
