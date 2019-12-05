using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;

using TIBCO.Rendezvous;
using MainLibrary.TibMessage;

using SOFD.Logger;
using MainLibrary.LogFormat;

namespace MainLibrary.Manager
{
    public delegate void delegateMsgReceive(string strHostMsg);
    public delegate void delegateHostT3Timeout(CTibRVMessageBase oTibMessage);
    public delegate void delegateTibCommunicationChange(object oSender, bool bConnect);

    public delegate void delegateRemoteControlStateChangeComplete(object sender, enumHostControl oChangedHostControl);

    public class CTibRVManager
    {
        public Dictionary<string, string> TIBConnectINFO = new Dictionary<string, string>();

        #region Properties
        private string mFiledName = string.Empty;
        public string FIELD_NAME
        {
            get { return mFiledName; }
            set { mFiledName = value; }
        }

        private string mRemoteSubject = string.Empty;
        public string REMOTE_SUBJECT
        {
            get { return mRemoteSubject; }
            set { mRemoteSubject = value; }
        }

        private string mLocalSubject = string.Empty;
        public string LOCAL_SUBJECT
        {
            get { return mLocalSubject; }
            set { mLocalSubject = value; }
        }

        private string mService = string.Empty;
        public string SERVICE
        {
            get { return mService; }
            set { mService = value; }
        }

        private string mADDR = string.Empty;
        public string ADDR
        {
            get { return mADDR; }
            set { mADDR = value; }
        }

        private string mDaemon = string.Empty;
        public string DAEMON
        {
            get { return mDaemon; }
            set { mDaemon = value; }
        }

        private string mNetwork = string.Empty;
        public string NETWORK
        {
            get { return mNetwork; }
            set { mNetwork = value; }
        }

        private bool mIsVirtual = false;
        /// <summary>
        /// Sim Driver인 경우 true
        /// </summary>
        public bool IS_VIRTUAL
        {
            get { return mIsVirtual; }
            set { mIsVirtual = value; }
        }

        private string _strDriverName = string.Empty;
        public string DriverName
        {
            get { return _strDriverName; }
            set { _strDriverName = value; }
        }

        private int mTimeOutInterval = 10;
        public int TIME_OUT_INTERVAL
        {
            get { return mTimeOutInterval; }
            set { mTimeOutInterval = value; }
        }

        private string _strMessageKey = string.Empty;
        public string MESSAGEKEY
        {
            get { return _strMessageKey; }
            set { _strMessageKey = value; }
        }

        public string ServicePort = null;
        public TIBCO.Rendezvous.Transport tibTrans;
        public TIBCO.Rendezvous.Listener tibListener;

        public TIBCO.Rendezvous.Listener tibListener_TSM; //구동 리스너
        public TIBCO.Rendezvous.Listener tibListener_EXT; //외관 리스너
        public TIBCO.Rendezvous.Listener tibListener_INT; //장입 리스너





        public List<string> _mExceptQueueMessage = new List<string>();
        public List<string> _mNoLogSecondaryMessage = new List<string>();


        private int _CurrentSystemByte = 1;

        /// <summary>
        /// Tib으로 Message 를 순차적으로(Key값에 따라) 보내기 위한 Queue. Tib 으로 Message 보내면 삭제함.
        /// [Key : EQP, value : Message 객체]
        /// </summary>
        private Dictionary<string, Queue<CTibRVMessageBase>> _mQueueMessageBeforeSend = new Dictionary<string, Queue<CTibRVMessageBase>>();

        /// <summary>
        /// Tib으로 Message 를 순차적으로(Key값에 따라) 보내기 위한 Queue. Tib 으로 Message 보내면 삭제함.
        /// [Key : EQP, value : Message 객체]
        /// </summary>
        public Dictionary<string, Queue<CTibRVMessageBase>> QueueMessageBeforeSend
        {
            get { return _mQueueMessageBeforeSend; }
            set { _mQueueMessageBeforeSend = value; }
        }

        /// <summary>
        /// Tib으로 Message 를 순차적으로(Key값에 따라) 보내기 위한 Queue. Tib 으로 Message 보내면 삭제함.
        /// [Key : EQP, value : Message 객체]
        /// </summary>
        private Dictionary<string, Queue<CTibRVMessageBase>> _mQueueMessageAfterSend = new Dictionary<string, Queue<CTibRVMessageBase>>();

        /// <summary>
        /// Tib으로 Message 를 순차적으로(Key값에 따라) 보내기 위한 Queue. Tib 으로 Message 보내면 삭제함.
        /// [Key : EQP, value : Message 객체]
        /// </summary>
        public Dictionary<string, Queue<CTibRVMessageBase>> QueueMessageAfterSend
        {
            get { return _mQueueMessageAfterSend; }
            set { _mQueueMessageAfterSend = value; }
        }


        #endregion

        #region Event 정의
        public event MessageReceivedEventHandler OnMessageReceived;
        public event MessageReceivedEventHandler OnMessageReceived_TMS;
        public event MessageReceivedEventHandler OnMessageReceived_EXT;
        public event MessageReceivedEventHandler OnMessageReceived_INT;
        

        public event delegateMsgReceive OnHostMsgReceived;
        public event delegateHostT3Timeout OnHostT3TimeoutOccurred;
        public event delegateTibCommunicationChange OnCommunicationChange;


        public event delegateRemoteControlStateChangeComplete RemoteControlStateChangeComplete = null;

        #endregion

        /// <summary>
        /// Tib/Rv Connection 기준정보
        /// </summary>
        class CHostConnection
        {
            protected object GetValue(string sName, string sValue)
            {
                object value = null;

                switch (sName)
                {
                    case "FIELDNAME":
                        value = sValue;
                        break;
                    case "REMOTESUBJECT":
                        value = sValue;
                        break;
                    case "LOCALSUBJECT":
                        value = sValue;
                        break;
                    case "SERVICE":
                        value = sValue;
                        break;
                    case "DAEMON":
                        value = sValue;
                        break;
                    case "NETWORK":
                        value = sValue;
                        break;
                    case "ISVIRTUAL":
                        value = sValue;
                        break;
                    case "TIMEOUT":
                        value = sValue;
                        break;
                    case "KEY":
                        value = sValue;
                        break;
                }

                return value;
            }


        }

        #region Initialize & Constructor

        /// <summary>
        /// Contructor
        /// </summary>
        public CTibRVManager(CMain _main)
        {
            TIBConnectINFO = _main.SystemConfig.TIBRVConnectInfo;
        }
        public CTibRVManager(Dictionary<string, string> ConnectInfo)
        {
            TIBConnectINFO = ConnectInfo;
        }

        public void InitConnectionString()
        {
            //CHECK NEED
            //_psConnectionInfo = (CDriverConnectionString)new CHostConnection();
            //_psConnectionInfo.Parse(sCnnString);

            setTibrvValue();
        }

        /// <summary>
        /// Tib/Rv  Connection String  초기화.
        /// </summary>
        private void setTibrvValue()
        {

            //LOCAL_SUBJECT = TIBConnectINFO["LOCALSUBJECT"] + GetLocalIPforSubject();

            //ADDR = GetFullAddr(LOCAL_SUBJECT);
            //LOCAL_SUBJECT = "HA.G1.EES.HACGCI01";
            LOCAL_SUBJECT = TIBConnectINFO["LOCALSUBJECT"];

            NETWORK = TIBConnectINFO["NETWORK"];

            try { FIELD_NAME = TIBConnectINFO["FIELDNAME"]; }
            catch { FIELD_NAME = "DATA"; }

            REMOTE_SUBJECT = TIBConnectINFO["REMOTESUBJECT"];

            ADDR = REMOTE_SUBJECT + "," + LOCAL_SUBJECT;
            //MHOST.127_0_0_1
            //MHOST.127_0_0_1
            //MECS.127_0_0_1
            try
            { SERVICE = TIBConnectINFO["SERVICE"]; }
            catch { SERVICE = "7600"; }

            ServicePort = SERVICE;

            try { DAEMON = TIBConnectINFO["DAEMON"]; }
            catch { DAEMON = "tcp::7500"; }

            try { TIME_OUT_INTERVAL = int.Parse(TIBConnectINFO["TIMEOUT"]); }
            catch { TIME_OUT_INTERVAL = 10000; }

            try { MESSAGEKEY = TIBConnectINFO["KEY"]; }
            catch { MESSAGEKEY = ""; }
        }

        /// <summary>
        /// Driver Open
        /// </summary>
        /// <returns></returns>
        public int Open(bool bOnlySend, bool isFPC)
        {
            int iRet = -1;

            try
            {
                // Tib Driver Open
                TIBCO.Rendezvous.Environment.Open();
                
                // Tib 송신 Setting
                iRet = TibTransportSetting();
                if (iRet == 0)
                {
                    // Tib 수신 Setting
                    TibListenerSetting();

                    if (isFPC)
                        TibListenerSetting_ADD_FPC();

                    ConnectionState = enumConnectionStateStep.Connected;
                    RaiseCommunicationConnect();

                    InitializeTimeOutThread();
                    InitializeMessageSendThread();

                    delgateDispatch oDispatch = new delgateDispatch(ScanAttribute);
                    oDispatch.BeginInvoke(null, null);

                    CLogManager.Instance.Log(new CStatusLogFormat(Catagory.Error, "OGS", "TIB", "TIB Open Success"));

                    iRet = 0;
                }
                else
                {
                    Exception oEx = new Exception("TIB OPEN FAIL........");
                    CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "TIB OPEN FAIL", oEx));
                }
            }
            catch (Exception ex)
            {
                CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "EMP", ex));
                CLogManager.Instance.Log(new CStatusLogFormat(Catagory.Error, "OGS", "TIB", "Open \r\n" + ex.ToString()));
            }

            return iRet;
        }

        /// <summary>
        /// Driver Close
        /// </summary>
        /// <returns></returns>
        public int Close()
        {
            int returnCode = 0;

            try
            {
                TIBCO.Rendezvous.Environment.Close();
                ConnectionState = enumConnectionStateStep.Disconnected;
                RaiseCommunicationDisconnect();

                _threadMessageSend.Abort();
                _threadTimeout.Abort();
            }
            catch
            {
                returnCode = -1;
            }

            return returnCode;
        }

        delegate void delgateDispatch();
        public bool TibRVDispatchThread = true;
        private void ScanAttribute()
        {
            while (TibRVDispatchThread)
            {

                try
                {
                    Queue.Default.Dispatch();
                }
                catch (System.Exception ex)
                {
                    //CHECK NEED  SystemLogger.Log(ex);
                }

                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// Listener Set
        /// </summary>
        private void TibListenerSetting()
        {
            try
            {
                OnMessageReceived += new MessageReceivedEventHandler(__OnMessageReceived);
                tibListener = new Listener(Queue.Default, OnMessageReceived, tibTrans, LOCAL_SUBJECT, "");

                
            }
            catch (System.Exception ex)
            {
                CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "EMP", ex));
                CLogManager.Instance.Log(new CStatusLogFormat(Catagory.Error, "OGS", "TIB", "TibListenerSetting \r\n" + ex.ToString()));
            }
        }

        private void TibListenerSetting_ADD_FPC()
        {
            try
            {
                if (OnMessageReceived != null)
                {
                    tibListener_TSM = new Listener(Queue.Default, OnMessageReceived, tibTrans, LOCAL_SUBJECT.Replace("HACFOG", "HACFDI"), "");
                    tibListener_EXT = new Listener(Queue.Default, OnMessageReceived, tibTrans, LOCAL_SUBJECT.Replace("HACFOG", "HACFVI"), "");
                    tibListener_INT = new Listener(Queue.Default, OnMessageReceived, tibTrans, LOCAL_SUBJECT.Replace("HACFOG", "HACHPT"), "");
                }
            }
            catch (System.Exception ex)
            {
                CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "EMP", ex));
                CLogManager.Instance.Log(new CStatusLogFormat(Catagory.Error, "OGS", "TIB", "TibListenerSetting \r\n" + ex.ToString()));
            }
        }

        /// <summary>
        /// Trnasport Set
        /// </summary>
        private int TibTransportSetting()
        {
            int bRet = -1;
            try
            {
                tibTrans = new NetTransport(SERVICE, NETWORK, DAEMON);
                bRet = 0;
            }
            catch (Exception ex)
            {
                CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "EMP", ex));
                CLogManager.Instance.Log(new CStatusLogFormat(Catagory.Error, "OGS", "TIB", "TibTransportSetting \r\n" + ex.ToString()));
            }
            return bRet;
        }

        #region Message Send & T3 Timeout Thread

        /// <summary>
        /// 
        /// </summary>
        private Thread _threadTimeout = null;

        /// <summary>
        /// 
        /// </summary>
        private Thread _threadMessageSend = null;

        /// <summary>
        /// T3 Timeout Thread 초기화
        /// </summary>
        private void InitializeTimeOutThread()
        {
            try
            {
                _threadTimeout = new Thread(new ThreadStart(DoCheckT3TimeOut));
                _threadTimeout.Priority = ThreadPriority.Normal;
                _threadTimeout.IsBackground = true;

                _threadTimeout.Start();
            }
            catch (Exception ex)
            {
                //CHECK NEED  SystemLogger.Log(ex);
            }
        }

        /// <summary>
        /// T3 Timeout Thread 초기화
        /// </summary>
        private void InitializeMessageSendThread()
        {
            try
            {
                _threadMessageSend = new Thread(new ThreadStart(DoCheckMessageSend));
                _threadMessageSend.Priority = ThreadPriority.Normal;
                _threadMessageSend.IsBackground = true;

                _threadMessageSend.Start();
            }
            catch (Exception ex)
            {
                //CHECK NEED  SystemLogger.Log(ex);
            }
        }

        /// <summary>
        /// T3 Timeout Thread Start
        /// </summary>
        private void StartTimeoutThread()
        {
            if (_threadTimeout == null || !_threadTimeout.IsAlive)
                InitializeTimeOutThread();
        }

        /// <summary>
        /// Message Send Thread Start
        /// </summary>
        private void StartMessageSendThread()
        {
            //if (_threadMessageSend == null || !_threadMessageSend.IsAlive)
            InitializeMessageSendThread();
        }

        #endregion

        #endregion

        #region Event Handle

        private void __OnMessageReceived(object listener, MessageReceivedEventArgs messageReceivedEventArgs)
        {
            try
            {
                Message message = messageReceivedEventArgs.Message;
                MessageField messageField = message.GetField(FIELD_NAME);
                string sHostMsg = messageField.Value.ToString();
                Dictionary<string, string> oParseMessage = GetParseMessage(sHostMsg);

                string sHostFirstMsgName = (oParseMessage["MSG_NAME"].Contains("_")) ? sHostMsg.Substring(0, oParseMessage["MSG_NAME"].IndexOf('_')) : string.Empty;

                bool bExceptQueueMsg = _mExceptQueueMessage.Contains(sHostFirstMsgName);//oParseMessage["MSG_NAME"]);
                bool bNoLogSecondaryMsg = _mNoLogSecondaryMessage.Contains(sHostFirstMsgName);

                // Log 먼저 찍고 Event Raise 함.
                //CHECK NEED  SystemLogger.Log(Level.Debug, string.Format(" RECV Start:{0}", oParseMessage["MSG_NAME"]), ToString(), this.Name);
                CLogManager.Instance.Log(new CTIBRVFormat(Catagory.Info, string.Format(" RECV Start:{0}", oParseMessage["MSG_NAME"]), sHostMsg));


                if (!IS_VIRTUAL && !bExceptQueueMsg)
                {
                    sHostMsg = RemoveQueueMessage(sHostMsg, oParseMessage["EQP"], oParseMessage["MSG_NAME"]);
                }

                if (!bNoLogSecondaryMsg || oParseMessage["RTN_CD"] != "0")
                {
                    // System Byte 를 찍기 위해 Log 위치 이동함.
                    //CHECK NEED  SystemLogger.Log(Level.Verbose, GetMessageLog(sHostMsg, false), ToString(), this.Name);
                    RaiseHostMsgReceived(sHostMsg);
                }
                // Event Raise 완료 로그
                //CHECK NEED  SystemLogger.Log(Level.Debug, string.Format(" RECV End :{0}", oParseMessage["MSG_NAME"]), ToString(), this.Name);
            }
            catch (Exception ex)
            {
                //CHECK NEED  SystemLogger.Log(ex);
            }
        }
        #endregion

        #region Event Raise
        private void RaiseHostT3TimeOut(CTibRVMessageBase oTibMessage)
        {
            if (OnHostT3TimeoutOccurred != null)
                OnHostT3TimeoutOccurred(oTibMessage);
        }

        protected void RaiseHostMsgReceived(string sHostMsg)
        {
            if (this.OnHostMsgReceived != null)
            {
                this.OnHostMsgReceived(sHostMsg);
            }
        }

        protected void RaiseCommunicationConnect()
        {
            if (OnCommunicationChange != null)
            {
                OnCommunicationChange(this, true);
            }
        }

        protected void RaiseCommunicationDisconnect()
        {
            if (OnCommunicationChange != null)
            {
                OnCommunicationChange(this, false);
            }
        }
        #endregion

        #region public Function
        public void SendMessage(CTibRVMessageBase oTibMessage)
        {
            try
            {
                if (!oTibMessage.LogSecondaryMsg)
                {
                    if (!_mNoLogSecondaryMessage.Contains(oTibMessage.MSG_NAME))
                        _mNoLogSecondaryMessage.Add(oTibMessage.MSG_NAME);
                }

                if (oTibMessage.Queueing)
                {
                    AddQueueMessageBeforeSend(oTibMessage);
                }
                else
                {
                    if (!_mExceptQueueMessage.Contains(oTibMessage.MSG_NAME))
                        _mExceptQueueMessage.Add(oTibMessage.MSG_NAME);

                    SendTibMessage(oTibMessage);
                }
            }
            catch (Exception ex)
            {
                CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "EMP", ex));
                CLogManager.Instance.Log(new CStatusLogFormat(Catagory.Error, "OGS", "TIB", "SendMessage \r\n" + ex.ToString()));
            }
        }

        /// <summary>
        /// Test 용 Message Send Function
        /// </summary>
        /// <param name="sendMessage"></param>
        /// <param name="sendMSG"></param>
        public void SendMessage4Test(TIBCO.Rendezvous.Message sendMessage, string sendMSG)
        {
            try
            {
                sendMessage.SendSubject = REMOTE_SUBJECT;
                sendMessage.AddField(FIELD_NAME, sendMSG);
                tibTrans.Send(sendMessage);

                //CHECK NEED  SystemLogger.Log(Level.Verbose, GetMessageLog(sendMSG, true), ToString(), this.Name);
            }
            catch (Exception ex)
            {
                //CHECK NEED  SystemLogger.Log(ex);
            }
        }

        public object GetQueueLockObject()
        {
            return _oMessageQueue;
        }
        #endregion

        #region Private Function - Message Queue
        /// <summary>
        /// Message Send 가능한지 판단하여 Send
        /// </summary>
        private void DoCheckMessageSend()
        {
            try
            {
                while (true)
                {
                    lock (_oMessageQueue)
                    {
                        // 각 EQP 별로 Queue 에서 Send 할 Message 를 가져옴.
                        CTibRVMessageBase oMaxSystemByteMessage = null;
                        Queue<CTibRVMessageBase> oQueue = null;
                        List<CTibRVMessageBase> oCandidateList = new List<CTibRVMessageBase>();
                        foreach (string strKey in _mQueueMessageBeforeSend.Keys)
                        {
                            if (_mQueueMessageAfterSend.ContainsKey(strKey) && _mQueueMessageAfterSend[strKey].Count > 0) continue;

                            oQueue = _mQueueMessageBeforeSend[strKey];

                            if (oQueue.Count == 0) continue;

                            CTibRVMessageBase oTibMessage = oQueue.Peek();
                            oCandidateList.Add(oTibMessage);
                            if (oTibMessage.SystemBytes == Int32.MaxValue)
                                oMaxSystemByteMessage = oTibMessage;
                        }

                        // EQP 별 Send Message 중에 SystemByte 가 빠른것 부터 Send 함.
                        // 단 MaxSystemByte Message 는 먼저 보냄.
                        CTibRVMessageBase oSendMessage = null;
                        foreach (CTibRVMessageBase oTibMessage in oCandidateList)
                        {
                            if (oSendMessage == null)
                            {
                                oSendMessage = oTibMessage;
                            }
                            else
                            {
                                if (oSendMessage.SystemBytes > oTibMessage.SystemBytes)
                                {
                                    oSendMessage = oTibMessage;
                                }
                            }
                        }

                        // Message Dequeue & Send
                        if (oSendMessage != null)
                        {
                            if (oMaxSystemByteMessage != null)
                                oSendMessage = _mQueueMessageBeforeSend[oMaxSystemByteMessage.EQP].Dequeue();
                            else
                                oSendMessage = _mQueueMessageBeforeSend[oSendMessage.EQP].Dequeue();

                            //CHECK NEED  SystemLogger.Log(Level.Verbose, string.Format("  Del Message Queue ({0}/{1})", oSendMessage.EQP, oSendMessage.MSG_NAME), "MSGQueue", this.Name);

                            //CLogManager.Instance.Log(new CTIBRVFormat(Catagory.Debug, "QUEUE OUT SEND MSG", oSendMessage.ToString()));

                            SendTibMessage(oSendMessage);

                            //CHECK NEED..이거 어케 하는건지 사실 잘 모르곘음.
                            //AddQueueMessageAfterSend(oSendMessage);
                        }
                    }

                    Thread.Sleep(ScanInterval);
                }
            }
            catch (Exception ex)
            {
                //CHECK NEED  SystemLogger.Log(ex);
                // 비정상적으로 Thread 가 종료되었을 경우 새로운 Thread 를 만들어줌. 
                StartMessageSendThread();
            }
        }
        /// <summary>
        /// Check T3 Timeout
        /// </summary>
        private void DoCheckT3TimeOut()
        {
            try
            {
                while (true)
                {
                    lock (_oMessageQueue)
                    {
                        Queue<CTibRVMessageBase> oQueue = null;
                        foreach (string strKey in _mQueueMessageAfterSend.Keys)
                        {
                            oQueue = _mQueueMessageAfterSend[strKey];

                            if (oQueue.Count == 0) continue;

                            //CHECK NEED
                            //if (CAttributeAction.IsTimeOut(oQueue.Peek().StartTickCount, TIME_OUT_INTERVAL))
                            //{
                            //    CTibRVMessageBase oTibMessage = oQueue.Dequeue();
                            //    Logger.Log(Level.Warning, "Drv HOST T3 Timeout Occur!!", "T3", "Host");
                            //    //RaiseHostT3TimeOut(oTibMessage.MSG_NAME);
                            //    RaiseHostT3TimeOut(oTibMessage);
                            //}
                        }
                    }
                    Thread.Sleep(ScanInterval);
                }
            }
            catch (Exception ex)
            {
                //CHECK NEED  SystemLogger.Log(ex);
                // 비정상적으로 Thread 가 종료되었을 경우 새로운 Thread 를 만들어줌. 
                StartTimeoutThread();
            }
        }


        private object _MessageSend = new object();
        /// <summary>
        /// 실제로 Message를 전송
        /// </summary>
        /// <param name="sendMessage"></param>
        /// <param name="sendMSG"></param>
        private void SendTibMessage(CTibRVMessageBase oTibMessage)
        {
            lock (_MessageSend)
            {
                try
                {
                    oTibMessage.SEND_TIME = DateTime.Now;
                    oTibMessage.StartTickCount = System.Environment.TickCount;

                    TIBCO.Rendezvous.Message sendMessage = new TIBCO.Rendezvous.Message();

                    string sendMSG = oTibMessage.ToString();
                    sendMessage.SendSubject = REMOTE_SUBJECT;
                    sendMessage.AddField(FIELD_NAME, sendMSG);

                    tibTrans.Send(sendMessage);

                    //CELSC oELSC = oTibMessage as CELSC;
                    //if (oELSC != null)
                    //{
                    //    if (oELSC.IsOnlineChangeMessage)
                    //    {
                    //        if (RemoteControlStateChangeComplete != null)
                    //            RemoteControlStateChangeComplete(this, enumHostControl.Online);
                    //    }
                    //}

                    CEMCR oEMCR = oTibMessage as CEMCR;
                    if (oEMCR != null)
                    {
                        if (oEMCR.IsOnlineChangeMessage)
                        {
                            if (oEMCR.RCS == "F")
                            {
                                if (RemoteControlStateChangeComplete != null)
                                    RemoteControlStateChangeComplete(this, enumHostControl.Offline);
                            }
                            else
                            {
                                if (RemoteControlStateChangeComplete != null)
                                    RemoteControlStateChangeComplete(this, enumHostControl.Online);
                            }
                        }
                    }

                    // 보낸 Message String 에 System Byte 추가함.
                    sendMSG += string.Format(" SYSTEM_BYTE={0}", oTibMessage.SystemBytes.ToString());

                    CLogManager.Instance.Log(new CTIBRVFormat(Catagory.Info, oTibMessage.EQP, sendMSG));

                    //CHECK NEED  SystemLogger.Log(Level.Verbose, GetMessageLog(sendMSG, true), ToString(), this.Name);
                }
                catch (Exception ex)
                {
                    CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "EMP", ex));
                    CLogManager.Instance.Log(new CStatusLogFormat(Catagory.Error, "OGS", "TIB", "SendTibMessage \r\n" + ex.ToString()));
                }
            }
        }


        private object _oMessageQueue = new object();
        /// <summary>
        /// Message Queue Add
        /// </summary>
        /// <param name="msgObject"></param>
        private void AddQueueMessageBeforeSend(CTibRVMessageBase oTibMessage)
        {
            lock (_oMessageQueue)
            {
                try
                {
                    if (_CurrentSystemByte == Int32.MaxValue) _CurrentSystemByte = 1;
                    oTibMessage.SystemBytes = _CurrentSystemByte++;

                    if (!_mQueueMessageBeforeSend.ContainsKey(oTibMessage.EQP))
                        _mQueueMessageBeforeSend.Add(oTibMessage.EQP, new Queue<CTibRVMessageBase>());

                    _mQueueMessageBeforeSend[oTibMessage.EQP].Enqueue(oTibMessage);

                    //CLogManager.Instance.Log(new CTIBRVFormat(Catagory.Debug, "QUEUING MESSAGE", oTibMessage.ToString()));

                    //CHECK NEED  SystemLogger.Log(Level.Verbose, string.Format("  Add Queue Message Before Send({0}/{1})", oTibMessage.EQP, oTibMessage.MSG_NAME), "MSGQueue", this.Name);
                }
                catch (Exception ex)
                {
                    //CHECK NEED  SystemLogger.Log(ex);
                }
            }
        }
        /// <summary>
        /// Message Queue Add
        /// </summary>
        /// <param name="msgObject"></param>
        private void AddQueueMessageAfterSend(CTibRVMessageBase oTibMessage)
        {
            lock (_oMessageQueue)
            {
                try
                {
                    if (!_mQueueMessageAfterSend.ContainsKey(oTibMessage.EQP))
                        _mQueueMessageAfterSend.Add(oTibMessage.EQP, new Queue<CTibRVMessageBase>());

                    _mQueueMessageAfterSend[oTibMessage.EQP].Enqueue(oTibMessage);

                    //CHECK NEED  SystemLogger.Log(Level.Verbose, string.Format("  Add Queue Message After Send ({0}/{1})", oTibMessage.EQP, oTibMessage.MSG_NAME), "MSGQueue", this.Name);
                }
                catch (Exception ex)
                {
                    //CHECK NEED  SystemLogger.Log(ex);
                }
            }
        }

        private string RemoveQueueMessage(string strMessage, string strKey, string strMsgName)
        {
            lock (_oMessageQueue)
            {
                try
                {
                    if (_mQueueMessageAfterSend.ContainsKey(strKey) && _mQueueMessageAfterSend[strKey].Count > 0)
                    {
                        // System Byte Setting 을 위해 Primary Message Check
                        CTibRVMessageBase oTibMessage = _mQueueMessageAfterSend[strKey].Dequeue();

                        // 받은 Message String 에 System Byte 추가함.
                        strMessage += string.Format(" SYSTEM_BYTE={0}", oTibMessage.SystemBytes.ToString());

                        //CHECK NEED  SystemLogger.Log(Level.Verbose, string.Format("  Del Queue Message After Send ({0}/{1})", strKey, strMsgName), "MSGQueue", this.Name);
                    }
                }
                catch (Exception ex)
                {
                    //CHECK NEED  SystemLogger.Log(ex);
                }
                return strMessage;
            }
        }

        #endregion

        #region Private Function - Etc.

        /// <summary>
        /// Message 에서 Key 값(EQP) 를 가져옴.
        /// </summary>
        /// <param name="sHostMsg"></param>
        /// <returns></returns>
        private string GetMessageKeyValue(string sHostMsg)
        {
            string[] sHostMSGList = null;
            string strKey = string.Empty;
            string strRet = string.Empty;

            try
            {
                sHostMSGList = sHostMsg.Split(' ');

                foreach (string strValue in sHostMSGList)
                {
                    if (!strValue.Contains("=")) continue;

                    if (MESSAGEKEY == strValue.Substring(0, strValue.IndexOf('=')))
                    {
                        strRet = strValue.Substring(strValue.IndexOf('=') + 1);
                    }
                }
            }
            catch (Exception ex)
            {
                //CHECK NEED  SystemLogger.Log(ex);
            }

            return strRet;
        }

        /// <summary>
        /// Message의 Name을 가져옴
        /// </summary>
        /// <param name="strMSG"></param>
        /// <returns></returns>
        private string GetMessageName(string strMSG)
        {
            string[] sHostMSGList = null;
            string sHostMsgName = string.Empty;

            try
            {
                sHostMSGList = strMSG.Split(' ');
                sHostMsgName = sHostMSGList[0];
            }
            catch (Exception ex)
            {
                //CHECK NEED  SystemLogger.Log(ex);
            }

            return sHostMsgName;
        }


        private Dictionary<string, string> GetParseMessage(string strMSG)
        {
            Dictionary<string, string> hostMSGList = null;

            try
            {
                CTibRVMessageBase mMessage = new CTibRVMessageBase();
                hostMSGList = mMessage.msgParser(strMSG);
            }
            catch (Exception ex)
            {
                //CHECK NEED  SystemLogger.Log(ex);
                //CHECK NEED  SystemLogger.Log(strMSG);
            }
            return hostMSGList;
        }

        /// <summary>
        /// Message Log
        /// </summary>
        /// <param name="strMSG"></param>
        /// <param name="bSend"></param>
        /// <returns></returns>
        private string GetMessageLog(string strMSG, bool bSend)
        {
            StringBuilder sb = new StringBuilder();
            string sHostMsgName = string.Empty;
            Dictionary<string, string> hostMSGList = null;

            try
            {
                // ?? msgParser 가 필요한가?
                CTibRVMessageBase mMessage = new CTibRVMessageBase();
                hostMSGList = mMessage.msgParser(strMSG);

                sHostMsgName = hostMSGList["MSG_NAME"];

                sb.Append(string.Format(" {0} {1} \r\n", bSend ? "SEND" : "RECV", sHostMsgName));

                foreach (string strKey in hostMSGList.Keys)
                {
                    if (sHostMsgName != hostMSGList[strKey])
                    {
                        sb.Append(string.Format("  {0}={1}\r\n", strKey, hostMSGList[strKey]));
                    }
                }
            }
            catch (Exception ex)
            {
                //CHECK NEED  SystemLogger.Log(ex);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Message Log
        /// </summary>
        /// <param name="strMSG"></param>
        /// <param name="bSend"></param>
        /// <returns></returns>
        private string GetMessageLog(CTibRVMessageBase oMessage, bool bSend)
        {
            StringBuilder sb = new StringBuilder();
            try
            {

                sb.Append(string.Format(" {0} {1} \r\n", bSend ? "SEND" : "RECV", oMessage.MSG_NAME));
                sb.Append(oMessage.ToString());
                sb.Append(string.Format("  {0}={1}\r\n", "SYSTEM_BYTE", oMessage.SystemBytes.ToString()));
            }
            catch (Exception ex)
            {
                //CHECK NEED  SystemLogger.Log(ex);
            }

            return sb.ToString();
        }
        #endregion

        public static string GetLocalIPforSubject()
        {
            StringBuilder sLocalIPforSubject = new StringBuilder();
            string hostname = System.Net.Dns.GetHostName();

            System.Net.IPAddress[] ipaddresses = System.Net.Dns.GetHostEntry(hostname).AddressList;
            sLocalIPforSubject.Append(".");
            List<string> Value = new List<string>();

            for (int i = 0; i <= System.Net.Dns.GetHostEntry(hostname).AddressList.Length - 1; i++)
            {
                if (System.Net.Dns.GetHostEntry(hostname).AddressList[i].IsIPv6LinkLocal == false)
                {
                    Value.Add(System.Net.Dns.GetHostEntry(hostname).AddressList[i].ToString());
                }
            }

            sLocalIPforSubject.Append(Value[0].ToString().Replace(".", "_"));

            return (sLocalIPforSubject.ToString());
        }


        public static string GetFullAddr(string LocalSubject)
        {
            StringBuilder sFullAddr = new StringBuilder();

            sFullAddr.Append(LocalSubject);
            sFullAddr.Append(",");
            sFullAddr.Append(LocalSubject);

            return (sFullAddr.ToString());
        }

        public enumConnectionStateStep ConnectionState
        {
            get;
            set;
        }

        private int _iScanInterval = 100;
        public int ScanInterval
        {
            get { return _iScanInterval; }
            set { _iScanInterval = value; }
        }
    }
}
