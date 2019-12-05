using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net.Sockets;
using SOFD.Logger;
using System.Threading;
using System.IO;
using System.Net;
using SOFD.Properties;
using SOFD.Component.Interface;
using SOFD.Component;

using YANGSYS.CommDrv.LogFormat;
using SOFD.Global.Interface;

namespace YANGSYS.CommDrv
{
    public delegate void ReceivedMessage(string message);
    public delegate void ErrorException(string message);

    public class YangSysCommDrv : IDriver
    {
        //([Format : Protocol|data1|data2(,,,)#])--- 각 Data별 구분자는 '|' 로하며, Data2 내부구분자는 ',' 로한다. 메시지 종결자는 '#' 이며, 모든 통신 데이터는 대문자만을 사용한다.
        private TcpListener _listener = null;
        private TcpClient _client = null;
        private Thread _thread = null;
        private bool _threadRunFlag = false;
        private string _connectionString = "DriverName=Unknown, Mode=Client, RemoteIP=127.0.0.1, RemotePort=5000, LocalIP=127.0.0.1, LocalPort=6000";
        public event ReceivedMessage OnReceivedMessage;
        public event ErrorException OnErrorException;
        private CScanControlPropertiesCollections _SCANCONTROLS = new CScanControlPropertiesCollections();
        private CIControlAttributeCollection _CONTROLATTRIUBTES = new CIControlAttributeCollection();
        private string _controlName = "";
        private enumYESDrvStatus _status = enumYESDrvStatus.None;
        public enum enumYESDrvStatus
        {
            None,
            Init,
            Starting,
            WaitCRA,
            Listen,
            Connected,
            Closing,
            Closed
        }
        public YangSysCommDrv()
        {
            //이건 설정에서 로딩해야할듯.
            _connectionString = "DriverName=YANGSYS.CommDrv, Mode=Client, RemoteIP=127.0.0.1, RemotePort=5000, LocalIP=127.0.0.1, LocalPort=6000";
        }
        public YangSysCommDrv(string controlName, CIControlAttributeCollection controlAttributes, CScanControlPropertiesCollections scanControls)
        {
            _controlName = controlName;
            _SCANCONTROLS = scanControls;
            _CONTROLATTRIUBTES = controlAttributes;

            //이건 설정에서 로딩해야할듯.
            _connectionString = "DriverName=YANGSYS.CommDrv, Mode=Client, RemoteIP=127.0.0.1, RemotePort=5000, LocalIP=127.0.0.1, LocalPort=6000";
        }

        #region IDriver 멤버

        public string Name
        {
            get { return connectionInfo != null ? connectionInfo.DriverName : "TCP/IP Driver"; }
        }

        public string Version
        {
            get { return "v1.0"; }
        }

        public string CommType
        {
            get { return "TCP/IP"; }
        }

        public string Maker
        {
            get { return "(주)서진정보기술"; }
        }

        public string ConnectionString
        {
            get { return _connectionString; }
        }

        public string ConnectionStringFormat
        {
            get { return "DriverName=Unknown, Mode=Client, RemoteIP=127.0.0.1, RemotePort=5000, LocalIP=127.0.0.1, LocalPort=6000"; }
        }

        public bool Init()
        {
            this.DriverStatusChange(enumYESDrvStatus.Init);
            return Init(_connectionString);
        }

        private class ConnectionInfo
        {
            public string ConnectionString = "";
            public string DriverName = "";
            public string Mode = "";
            public string RemoteIP = "";
            public int RemotePort = 0;
            public string LocalIP = "";
            public int LocalPort = 0;
            public bool IsClientMode = false;
            public ConnectionInfo(string connectionString)
            {
                this.ConnectionString = connectionString;
                this.Parser();
            }

            private void Parser()
            {
                //DriverName=YANGSYS.CommDrv, Mode=Client, RemoteIP=127.0.0.1, RemotePort=5000, LocalIP=127.0.0.1, LocalPort=6000
                string[] temp = ConnectionString.Split(',');

                foreach (string item in temp)
                {
                    string[] keyValue = item.Split('=');

                    if (keyValue.Length < 2)
                    {
                        continue;
                    }
                    //DriverName,YANGSYS.CommDrv
                    switch (keyValue[0].Trim())
                    {
                        case "DriverName":
                            DriverName = keyValue[1];
                            break;
                        case "Mode":
                            Mode = keyValue[1].ToUpper();
                            IsClientMode = (Mode == "CLIENT");

                            break;
                        case "RemoteIP":
                            RemoteIP = keyValue[1];
                            break;
                        case "RemotePort":
                            RemotePort = int.Parse(keyValue[1]);
                            break;
                        case "LocalIP":
                            LocalIP = keyValue[1];
                            break;
                        case "LocalPort":
                            LocalPort = int.Parse(keyValue[1]);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        private ConnectionInfo connectionInfo = null;
        public bool Init(string connectionString)
        {
            _connectionString = connectionString;   

            try
            {
                connectionInfo = new ConnectionInfo(_connectionString);
                CLogManager.Instance.Log(new CMessageLogFormat(Catagory.Info, this.Name, "PROC", _connectionString));
                return true;
            }
            catch (Exception ex)
            {
                CLogManager.Instance.Log(new CMessageLogFormat(Catagory.Error, this.Name, "PROC", _connectionString));
                CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, CLogFormat.DEFAULT_KEY, ex));
            }
            return false;
        }
        private int _retryInterval = 5000;
        private bool _clinetConnected = false;
        //private Thread _connectionThread = null;
        private void DriverStatusChange(enumYESDrvStatus  newState)
        {
            switch (newState)
            {
                case enumYESDrvStatus.None:
                    break;
                case enumYESDrvStatus.Init:
                    break;
                case enumYESDrvStatus.Starting:
                    break;
                case enumYESDrvStatus.WaitCRA:
                    break;
                case enumYESDrvStatus.Listen:
                    break;
                case enumYESDrvStatus.Connected:
                    break;
                case enumYESDrvStatus.Closing:
                    break;
                case enumYESDrvStatus.Closed:
                    break;
                default:
                    break;
            }
            CLogManager.Instance.Log(new CMessageLogFormat(Catagory.Info, this.Name, "PROC", string.Format("DRIVER STATUS CHANGE {1}>{2}", this.Name, _status.ToString(), newState).ToUpper()));
            _status = newState;
        }
        public bool Start()
        {
            CLogManager.Instance.Log(new CMessageLogFormat(Catagory.Info, this.Name, "PROC", string.Format("START")));
            _userStop = false;
            _clinetConnected = false;
            _thread = new Thread(new ThreadStart(TryConnection));
            _thread.IsBackground = true;
            _thread.Start();
            return true;
        }

        private void TryConnection()
        {
            if (connectionInfo.IsClientMode)
            {
                _client = new TcpClient();

                this.DriverStatusChange(enumYESDrvStatus.WaitCRA);

                while (_client != null && !_client.Connected)
                {
                    try
                    {
                        _client.Connect(connectionInfo.RemoteIP, connectionInfo.RemotePort);
                        _clinetConnected = true;
                        break;
                    }
                    catch (Exception ex)
                    {
                        _clinetConnected = false;
                    }
                    if (_client == null)
                    {
                        return;
                    }

                    if (!_client.Connected)
                         Thread.Sleep(_retryInterval);
                }
                if (_client == null)
                    return;

                this.DriverStatusChange(enumYESDrvStatus.Connected);
            }
            else
            {
                this.DriverStatusChange(enumYESDrvStatus.Listen);
                IPAddress localAddr = IPAddress.Parse(connectionInfo.LocalIP);
                _listener = new TcpListener(localAddr, connectionInfo.LocalPort);
                try
                {
                    _listener.Start();
                }
                catch (Exception ex)
                {
                    return;
                }
            }

            _thread = new Thread(new ThreadStart(WaitMessage));
            _thread.IsBackground = true;
            _thread.Name = "WaitMessageThread";
            _threadRunFlag = true;
            _thread.Start();
        }

        public bool ReStart()
        {
            CLogManager.Instance.Log(new CMessageLogFormat(Catagory.Info, this.Name, "PROC", string.Format("RESTART")));
            return InternalStop(false) && Start();
        }
        private bool _userStop = false;
        public bool Stop()
        {
            CLogManager.Instance.Log(new CMessageLogFormat(Catagory.Info, this.Name, "PROC", string.Format("STOP BY USER")));
            _userStop = true;
            return InternalStop(true);
        }
        //20170315
        public bool ReStart_ByClient()
        {
            CLogManager.Instance.Log(new CMessageLogFormat(Catagory.Info, this.Name, "PROC", string.Format("RESTART BY CLIENT")));
            _userStop = true;
            return InternalStop(true) && Start();
        }
        private bool InternalStop(bool userStop)
        {
            _threadRunFlag = false;
            this.DriverStatusChange(enumYESDrvStatus.Closed);
            if (connectionInfo.IsClientMode)
            {
                if (_client != null)
                {
                    _client.Close();
                    _client = null;
                }
            }
            else
            {
                if (_client != null)
                {
                    _client.Close();
                    _client = null;
                }
                if (_listener != null)
                {
                    _listener.Stop();
                    _listener = null;
                }
            }
            return true;
        }

        public string GetStatus()
        {
            return _status.ToString();
        }

        #endregion
        private string _previousSend = "";
        public void Send(byte[] data)
        {
            if (_client == null)
            {
                return;
            }
            if (!_client.Connected)
            {
                return;
            }

            try
            {
                NetworkStream stream = _client.GetStream();
                stream.Write(data, 0, data.Length);
                stream.Flush();

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    if (i % 20 == 0)
                    {
                        //Console.Write("\r\n");
                    }
                    byte b = data[i];
                    //Console.Write(string.Format("${0:X2} ", b));
                    sb.Append(b);
                }

                string logMessage = Encoding.ASCII.GetString(data); //20161125
                if (_previousSend != logMessage)
                {
                    _previousSend = logMessage;
                    CLogManager.Instance.Log(new CMessageLogFormat(Catagory.Info, this.Name, "SEND", logMessage));
                }
                
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
                CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, CLogFormat.DEFAULT_KEY, e));
            }
            catch (SocketException e)
            {
                if (_userStop == false)
                    ReStart(); 
                Console.WriteLine("SocketException: {0}", e);
                CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, CLogFormat.DEFAULT_KEY, e));
            }
            catch (Exception e)
            {
                if (_userStop == false)
                    ReStart(); 
                Console.WriteLine("SocketException: {0}", e);
                CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, CLogFormat.DEFAULT_KEY, e));
            }
        }
        private string _previousRecevied = "";
        private void WaitMessage()
        {
            if (connectionInfo.IsClientMode == false)
            {
                try
                {
                    _client = _listener.AcceptTcpClient();

                    this.DriverStatusChange(enumYESDrvStatus.Connected);
                }
                catch
                {
                    return;
                }
            }

            byte[] tempBytes_headname = new byte[1024];
            byte b;

            List<byte> receivedBytes = new List<byte>();
            StringBuilder sb = null;
            while (_threadRunFlag)
            {
                int j;

                if (_status != enumYESDrvStatus.Connected || _client == null)
                {
                    return;
                }

                try
                {
                    NetworkStream stream = _client.GetStream(); 

                    string remainingMessage = "";
                    while (_client.Connected && (j = stream.Read(tempBytes_headname, 0, 1024)) != 0)
                    {
                        sb = new StringBuilder();

                        for (int i = 0; i < tempBytes_headname.Length; i++)
                        {
                            if (i % 20 == 0)
                            {
                                //Console.Write("\r\n");
                            }
                            b = tempBytes_headname[i];
                            //Console.Write(string.Format("${0:X2} ", b));
                            sb.Append(b);
                        }
                        receivedBytes.AddRange(tempBytes_headname);

                        try
                        {
                            byte[] temp = receivedBytes.ToArray();
                            string org = "";
                            string receivedMessage = Encoding.ASCII.GetString(temp);
                            if (receivedMessage.Contains("#") == false)
                            {
                                tempBytes_headname = new byte[1024];
                                continue;
                            }

                            receivedMessage = remainingMessage + receivedMessage.Replace("\0", "");
                            Console.WriteLine(receivedMessage);
                            org = receivedMessage;

                            List<string> messages = new List<string>();
                            char[] data = receivedMessage.ToCharArray();
                            string tempMessage = "";
                            foreach (char item in data)
                            {
                                tempMessage += item;
                                if (item == '#')
                                {
                                    messages.Add(tempMessage);
                                    tempMessage = "";
                                }
                            }

                            remainingMessage = tempMessage; //남았다는건 #으로 끝나지 않은 불완전한 메시지가 왔다는 이야기.
                            if (messages.Count > 1)
                            {
                                string temptemp = "";
                                foreach (string item in messages)
                                {
                                    temptemp += item + ",";
                                }

                                Console.WriteLine(temptemp + " " + messages.Count.ToString());
                            }
                            foreach (string innerItem in messages)
                            {
                                if (string.IsNullOrEmpty(innerItem))
                                    continue;

                                string message = innerItem.Substring(0, innerItem.Length - 1);
                                string[] splitedMessage = message.Split('|');

                                string header = message.Trim();

                                if (splitedMessage != null && splitedMessage.Length > 1)
                                    header = splitedMessage[0];

                                if (string.IsNullOrEmpty(header) == false)
                                {
                                    CScanControlProperties item = _SCANCONTROLS.GetProperty(_controlName, "VI_" + header);

                                    foreach (CScanControlProperties item2 in _SCANCONTROLS.Values)
                                    {
                                        if (_controlName != item2.ScanControlName)
                                            continue;

                                        if (item2.ScanAttribute.Contains("_" + header) && item2.DataName.Substring(3, item2.DataName.Length - 3) == (header))
                                        {

                                            item = item2;
                                        }
                                    }

                                    if (item != null)
                                    {
                                        Encoding.ASCII.GetString(receivedBytes.ToArray());
                                        if (_previousRecevied != org)
                                        {
                                            _previousRecevied = org;
                                            CLogManager.Instance.Log(new CMessageLogFormat(Catagory.Info, this.Name, "RECV", org)); //20161125
                                        }

                                        if (item != null)
                                        {
                                            item.Value = message;

                                            IControlAttribute iControlAttribute = _CONTROLATTRIUBTES.GetProperty(item.ControlName, item.AttributeName);
                                            CControlAttribute attribute = iControlAttribute as CControlAttribute;

                                            if (attribute != null)
                                            {
                                                attribute.BitEvent(true);
                                            }
                                            else
                                            {
                                                CLogManager.Instance.Log(new CMessageLogFormat(Catagory.Info, this.Name, "RECV", item.AttributeName + " " + message + " NOT EXIST EVENT [" + org + "]"));
                                            }

                                        }
                                        else
                                        {
                                            CLogManager.Instance.Log(new CMessageLogFormat(Catagory.Info, this.Name, "RECV", message + " (NOT EXIST SCANPROPERTY) [" + org + "]"));
                                        }
                                    }
                                    else
                                    {
                                        CLogManager.Instance.Log(new CMessageLogFormat(Catagory.Info, this.Name, "RECV", message + " (NOT EXIST SCANPROPERTY) [" + org + "]"));
                                    }
                                    if (OnReceivedMessage != null)
                                    {
                                        OnReceivedMessage(message);
                                    }
                                }
                                else
                                {
                                    CLogManager.Instance.Log(new CMessageLogFormat(Catagory.Info, this.Name, "RECV", message + " NO HEADER [" + org + "]"));
                                }
                            }
                            receivedBytes.Clear();
                        }
                        catch (Exception e)
                        {
                            tempBytes_headname = new byte[1024];
                            CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, CLogFormat.DEFAULT_KEY, e));
                        }

                        tempBytes_headname = new byte[1024];
                    }
                }
                catch (IOException io)
                {
                    //if (_userStop == false)
                    //    ReStart();
                    CLogManager.Instance.Log(new CMessageLogFormat(Catagory.Error, this.Name, "ERROR", io.Message));
                    CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, CLogFormat.DEFAULT_KEY, io));

                    if (_userStop == false && _client != null)
                        Stop();

                    if (OnErrorException != null)
                    {
                        OnErrorException(io.Message);
                    }

                    return;
                }

                catch (SocketException ex)
                {
                    CLogManager.Instance.Log(new CMessageLogFormat(Catagory.Error, this.Name, "ERROR", ex.Message));
                    CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, CLogFormat.DEFAULT_KEY, ex));
                    ReStart();
                }
                catch (Exception e)
                {
                    CLogManager.Instance.Log(new CMessageLogFormat(Catagory.Error, this.Name, "ERROR", e.Message));
                    CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, CLogFormat.DEFAULT_KEY, e));
                    //throw ex; //의도적인 오류 throw
                    this.ReStart();
                }

                //Console.WriteLine(sb != null ? sb.ToString() :"");
            }
        }

        private string GetMessageName(byte[] tempBytes_headname)
        {
            return Encoding.ASCII.GetString(tempBytes_headname);
        }

        private Dictionary<string, CommMessage> _messages = new Dictionary<string, CommMessage>();
        public Dictionary<string, CommMessage> Messages
        {
            get
            {
                return _messages;
            }
        }
        private void MessagenHandler(string messageName, string data)
        {
            if (_messages.ContainsKey(messageName))
                _messages[data].Value = data;
            else
            {
                //없으면 로그 남겨야지
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
            foreach (CControlAttribute attribute in _CONTROLATTRIUBTES.Values)
            {
                if (scanproperty.ScanControlName == attribute.ControlName)
                {
                    if (scanproperty.ScanAttribute == attribute.Attribute)
                    {
                        attribute.BitEvent(value);
                    }
                }
            }
            return bValue;
        }
    }

}


