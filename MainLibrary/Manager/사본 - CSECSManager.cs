using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SmartCom.Hsms;
using MainLibrary.LogFormat;
using SOFD.Logger;
using ControlLibrary.Interface;
using ControlLibrary;
using MainLibrary.Property;
using System.Windows.Forms;
using MainLibrary.Global;

// 임시 - SmartCom 수정완료시 삭제할 것.
using SmartCom;
using Driver_CHSMS;
using MainLibrary.Property;
using System.Threading;

namespace MainLibrary.Manager
{
    public enum enumHSMSConnect
    {
        Connect,
        Disconnect,
    }

    public delegate void delegateReceiveAFMsg(string LOTID, string MSG);
    public delegate void delegateReceiveLAMIMsg(string LOTID, string CSTID, string GLSID, string MSGType, string MSG);
    public delegate void delegateReceiveDeleteCMD(string CMD, string DeleteID);
    public delegate void delegateSecsConnectChange(string EQP, bool Connect);

    public delegate void delegateReceiveGIBMsg(string GlassID, CHSMS.CS6F7 oS6F7);

    public delegate void delegateReceiveS1Msg(string EQP);

    public class CSECSManager
    {

        private Queue<CLamiSendData> _waitQueue = new Queue<CLamiSendData>();
        private Thread _thread;
        private bool _isEnd = false;
      
        public event delegateReceiveAFMsg AFMsg = null;
        public event delegateReceiveLAMIMsg LAMIMsg = null;
        public event delegateReceiveDeleteCMD DeleteCMD = null;
        public event delegateSecsConnectChange SecsConnectChange = null;

        public event delegateReceiveGIBMsg ReceiveGIBMsg = null;

        public event delegateReceiveS1Msg ReceiveS1Msg = null;

        //private SecsProperties _properties = null;
        //private CHSMS _hsms = null;
        private CMain _main = null;

        public CMain oMain
        {
            get { return _main; }
            set { _main = value; }
        }
        
        private Dictionary<string, CHSMS> _HSMSCollection = new Dictionary<string, CHSMS>();

        public Dictionary<string, CHSMS> HSMSCollection
        {
            get { return _HSMSCollection; }
            set { _HSMSCollection = value; }
        }


        //private enumHostConnect _hostConnect = enumHostConnect.Disconnect;
        //private enumHSMSConnect _hsmsConnect = enumHSMSConnect.Disconnect;

        //public enumHSMSConnect HSMSConnect
        //{
        //    get { return _hsmsConnect; }
        //    set { _hsmsConnect = value; }
        //}

        public CSECSManager(CMain main)
        {
            _main = main;
            string EQPID = oMain.SystemConfig.EQPID;
            int EQPNO = int.Parse(EQPID.Substring(EQPID.Length - 1, 1));
            string strFileName = "";
            if (main.SystemConfig.SPECIAL_EQP_TYPE == enumSPECIAL_EQP_TYPE.FPC)
            {                
                //FPC는 EQPNO가 1 or 2 가 나올것임.
                SecsProperties oProp = null;
                CHSMS oHSMS = null;
                string path = "";
                int iOpenPort = -1;
                for (int i = 0; i < 5; i++)
                {
                    iOpenPort = 7000 + EQPNO + (i * 2);  //EQP1 : 1,3,5,7,9     EQP2 : 2,4,6,8,10                                        
                    oProp = new SecsProperties();
                    oHSMS = new CHSMS(EQPID + "_" + iOpenPort.ToString(), oProp);
                    oProp.Library = new SecsLibrary();
                    oProp.Library.Description = "LIBRARY";
                    
                    //string strFileName = "OGS_PASSIVE_" + iOpenPort.ToString() + ".lic";
                    strFileName = "SC_" + iOpenPort.ToString() + "_P_FPC0" + EQPNO.ToString() + ".lic";

                    path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"\Config\" + strFileName;
                    oHSMS.Load(path);
                    
                    //PORT NO로 EQP 관련 정보를 찾을 수 있도록 고정화 시킴.
                    //개별 파일로 Load하게 수정 해당 코드 주석
                    //oHSMS.Properties.IsActive = false;
                    //oHSMS.m_LocalPort = iOpenPort;                              
                    AddEvent(oHSMS);

                    HSMSCollection.Add(iOpenPort.ToString(), oHSMS);
                }

                string strType = EQPNO == 1 ? "A" : "P";
                iOpenPort = 7011;                               
                oProp = new SecsProperties();
                oHSMS = new CHSMS(EQPID + "_" + iOpenPort.ToString() + strType, oProp);
                oProp.Library = new SecsLibrary();
                oProp.Library.Description = "LIBRARY";
                strFileName = "SC_" + iOpenPort.ToString() + "_" + strType + "_FPC0" + EQPNO.ToString() + ".lic";
                path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"\Config\" + strFileName;
                oHSMS.Load(path);              
                AddEvent(oHSMS);
                HSMSCollection.Add(iOpenPort.ToString(), oHSMS);

                if (EQPNO == 1) //FPC01일때
                {
                    iOpenPort = 7021;
                }
                else if (EQPNO == 2) //FPC02일때
                {
                    iOpenPort = 7022;
                }
                oProp = new SecsProperties();
                oHSMS = new CHSMS(EQPID + "_" + iOpenPort.ToString(), oProp);
                oProp.Library = new SecsLibrary();
                oProp.Library.Description = "LIBRARY";                
                strFileName = "SC_" + iOpenPort.ToString() + "_P_FPC0" + EQPNO.ToString() + ".lic";
                path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"\Config\" + strFileName;                
                oHSMS.Load(path);
                AddEvent(oHSMS);
                HSMSCollection.Add(iOpenPort.ToString(), oHSMS);

            }
            else if (main.SystemConfig.SPECIAL_EQP_TYPE == enumSPECIAL_EQP_TYPE.LAMI)
            {
                for (int i = 0; i < 2; i++)
                {
                    int iOpenPort = 0;   //EQP1 : 7, 8     EQP2 : 9, 10
                    if (EQPNO == 1) iOpenPort = 7007 + i;
                    else if (EQPNO == 2) iOpenPort = 7009 + i;
                    else
                    {
                        oMain.ExceptionOccured("EQP NO 정보 이상 기준 정보 확인 필요", "CSECSManager");
                        return;
                    }
                    SecsProperties oProp = new SecsProperties();
                    CHSMS oHSMS = new CHSMS(EQPID + "_" + iOpenPort.ToString(), oProp);

                    oProp.Library = new SecsLibrary();
                    oProp.Library.Description = "LIBRARY";
                    //string strFileName = "OGS_ACTIVE_" + iOpenPort.ToString() + ".lic";
                    strFileName = "SC_" + iOpenPort.ToString() + "_A_LAMI0" + EQPNO.ToString() + ".lic";
                    string path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"\Config\" + strFileName;
                    oHSMS.Load(path);

                    //PORT NO로 EQP 관련 정보를 찾을 수 있도록 고정화 시킴.
                    //개별 파일로 Load하게 수정 해당 코드 주석
                    //oHSMS.Properties.IsActive = true;
                    //oHSMS.m_RemotePort = iOpenPort;
                    //oHSMS.m_LocalPort = iOpenPort; 
                    //oHSMS.m_RemoteIP = oMain.SystemConfig.IP_ADDRESS;
                    //oHSMS.Properties.RemotePort = iOpenPort;


                    AddEvent(oHSMS);

                    HSMSCollection.Add(iOpenPort.ToString(), oHSMS);
                }

                _thread = new Thread(new ThreadStart(DoWork));
                _thread.IsBackground = true;
                _thread.Start();
            }
            else
            {
                return;
            }
        }

        private void AddEvent(CHSMS _hsms)
        {
            _hsms.Connected += new ConnectEventHandler(_hsms_Connected);
            _hsms.Disconnected += new DisconnectEventHandler(_hsms_Disconnected);
            _hsms.PrimaryIn += new PrimaryInEventHandler(_hsms_PrimaryIn);
            _hsms.PrimaryOut += new PrimaryOutEventHandler(_hsms_PrimaryOut);
            _hsms.SecondaryIn += new SecondaryInEventHandler(_hsms_SecondaryIn);
            _hsms.SecondaryOut += new SecondaryOutEventHandler(_hsms_SecondaryOut);
            _hsms.SecsError += new SecsErrorEventHandler(_hsms_SecsError);
            _hsms.SecsTimeOut += new SecsTimeOutHandler(_hsms_SecsTimeOut);
            _hsms.SecsUnknownMessage += new SecsUnknownMessageHandler(_hsms_SecsUnknownMessage);

            _hsms.MakeMessageList();

            //ARE YOU THERE REQUEST
            _hsms.S1F1.OnReceived += new CHSMS.delegateS1F1Received(S1F1_OnReceived);
            _hsms.S1F2.OnReceived += new CHSMS.delegateS1F2Received(S1F2_OnReceived);

            //AF_DATA_SEND
            _hsms.S6F1.OnReceived += new CHSMS.delegateS6F1Received(S6F1_OnReceived);
            _hsms.S6F2.OnReceived += new CHSMS.delegateS6F2Received(S6F2_OnReceived);

            //LAMI_DATA_SEND
            _hsms.S6F3.OnReceived += new CHSMS.delegateS6F3Received(S6F3_OnReceived);
            _hsms.S6F4.OnReceived += new CHSMS.delegateS6F4Received(S6F4_OnReceived);

            //DELETE_REQUEST
            _hsms.S6F5.OnReceived += new CHSMS.delegateS6F5Received(S6F5_OnReceived);
            _hsms.S6F6.OnReceived += new CHSMS.delegateS6F6Received(S6F6_OnReceived);
            if (_hsms.S6F7 != null)
            {
                _hsms.S6F7.OnReceived += new CHSMS.delegateS6F7Received(S6F7_OnReceived);
                _hsms.S6F8.OnReceived += new CHSMS.delegateS6F8Received(S6F8_OnReceived);
            }
        }

        void S6F8_OnReceived(CHSMS.CS6F8 S6F8)
        {
            //throw new NotImplementedException();
        }

        void S6F7_OnReceived(CHSMS.CS6F7 S6F7)
        {
            //throw new NotImplementedException();
            if (ReceiveGIBMsg != null)
            {
                ReceiveGIBMsg(S6F7.GLASS_ID().ToString().Trim(), S6F7);
            }
        }

        void S6F6_OnReceived(CHSMS.CS6F6 S6F6)
        {
            
        }

        void S6F5_OnReceived(CHSMS.CS6F5 S6F5)
        {
            if (DeleteCMD != null)
                DeleteCMD(S6F5.CMD().Trim(), S6F5.DELETE_ID().Trim());
        }

        void S6F4_OnReceived(CHSMS.CS6F4 S6F4)
        {
            
        }

        //LIMI DATA SEND.. FPC 입장에서 On Receive할꺼임. LAMI는 EAPD보고 및 EMAP보고 시에 MSG SEND
        void S6F3_OnReceived(CHSMS.CS6F3 S6F3)
        {
            if (oMain.SystemConfig.SPECIAL_EQP_TYPE == enumSPECIAL_EQP_TYPE.FPC)
            {
                if (LAMIMsg != null)
                {
                    //LAMIMsg(S6F3.LOT_ID, S6F3.CST_ID, S6F3.GLASS_ID, S6F3.TYPE, S6F3.DATA);
                    LAMIMsg(S6F3.LOT_ID(), S6F3.CST_ID(), S6F3.GLASS_ID(), S6F3.TYPE(), S6F3.DATA());
                }
                GetHSMS(S6F3.Driver.m_LocalPort).S6F4.ACKC6("0");
                GetHSMS(S6F3.Driver.m_LocalPort).S6F4.Reply(S6F3);
            }
            else
            {
                oMain.ExceptionOccured(string.Format("FPC 이외의 장비에서 S6F3 수신됨"), "S6F3_OnReceived");
                GetHSMS(S6F3.Driver.m_LocalPort).S6F4.ACKC6("1");
                GetHSMS(S6F3.Driver.m_LocalPort).S6F4.Reply(S6F3);
            }
        }

        void S6F2_OnReceived(CHSMS.CS6F2 S6F2)
        {
            if (S6F2.ACKC6() != "0")
            {
                oMain.ExceptionOccured(string.Format(""), "S6F2_OnReceived");
            }
        }

        //AF DATA SEND.. FPC 입장에서 On Receive 할꺼임... LAMI는 이거 들어오면 에러임.
        void S6F1_OnReceived(CHSMS.CS6F1 S6F1)
        {
            if (oMain.SystemConfig.SPECIAL_EQP_TYPE == enumSPECIAL_EQP_TYPE.FPC)
            {
                if (AFMsg != null)
                {
                    AFMsg(S6F1.LOT_ID(), S6F1.DATA());
                }
                GetHSMS(S6F1.Driver.m_LocalPort).S6F2.ACKC6("0");
                GetHSMS(S6F1.Driver.m_LocalPort).S6F2.Reply(S6F1);
            }
            else
            {
                oMain.ExceptionOccured(string.Format("FPC 이외의 장비에서 S6F1 수신됨"), "S6F1_OnReceived");
                GetHSMS(S6F1.Driver.m_LocalPort).S6F2.ACKC6("1");
                GetHSMS(S6F1.Driver.m_LocalPort).S6F2.Reply(S6F1);
            }
        }

        private CHSMS GetHSMS(int PortNo)
        {                        
            foreach (string oSearchKey in HSMSCollection.Keys)
            {
                if (PortNo.ToString() == oSearchKey)
                    return HSMSCollection[oSearchKey];       
            }

            return null;
        }

        void S1F2_OnReceived(CHSMS.CS1F2 S1F2)
        {
            if (oMain.SystemConfig.SPECIAL_EQP_TYPE == enumSPECIAL_EQP_TYPE.FPC)
            {
                if (ReceiveS1Msg != null)
                    ReceiveS1Msg(GetFPCConnectEQPName(S1F2.Driver.m_LocalPort));
            }
            else if (oMain.SystemConfig.SPECIAL_EQP_TYPE == enumSPECIAL_EQP_TYPE.LAMI)
            {
                if (ReceiveS1Msg != null)
                    ReceiveS1Msg(GetLAMIConnectEQPName(S1F2.Driver.m_LocalPort));
            }

        }

        void S1F1_OnReceived(CHSMS.CS1F1 S1F1)
        {
            if (oMain.SystemConfig.SPECIAL_EQP_TYPE == enumSPECIAL_EQP_TYPE.FPC)
            {
                if (ReceiveS1Msg != null)
                    ReceiveS1Msg(GetFPCConnectEQPName(S1F1.Driver.m_LocalPort));
            }
            else if (oMain.SystemConfig.SPECIAL_EQP_TYPE == enumSPECIAL_EQP_TYPE.LAMI)
            {
                if (ReceiveS1Msg != null)
                    ReceiveS1Msg(GetLAMIConnectEQPName(S1F1.Driver.m_LocalPort));
            }

            GetHSMS(S1F1.Driver.m_LocalPort).S1F2.Reply(S1F1);
        }

        #region Functions
        private object _thisLock = new object();
        private void DoWork()
        {
            while (true)
            {

                if (_waitQueue.Count == 0)
                {
                    if (_isEnd) return;
                }
                else if (_waitQueue.Count > 0)
                {
                    lock (_thisLock)
                    {
                        CLamiSendData oSendData = _waitQueue.Dequeue();
                        if (oSendData.HSMS.CurrentState == HsmsStateConst.Selected)
                        {
                            SendS6F3(oSendData.EQPID, oSendData.LOTID, oSendData.CSTID, oSendData.GLSID, oSendData.TYPE, oSendData.DATA, oSendData.HSMS);
                        }
                        else
                        {
                            _waitQueue.Enqueue(oSendData);
                        }

                        Thread.Sleep(100);
                    }
                }

                if (_isEnd == false)
                    Thread.Sleep(100);
            }
        }

        public void SendS1F1(string EQPID)
        {

            int SecsPort_01 = -1;
            int SecsPort_02 = -1;
            switch (EQPID)
            {
                case "AF01":
                    SecsPort_01 = 7001;
                    SecsPort_02 = 7002;
                    break;
                case "AF02":
                    SecsPort_01 = 7003;
                    SecsPort_02 = 7004;
                    break;
                case "AF03":
                    SecsPort_01 = 7005;
                    SecsPort_02 = 7006;
                    break;
                case "LAMI01":
                    SecsPort_01 = 7007;
                    SecsPort_02 = 7008;
                    break;
                case "LAMI02":
                    SecsPort_01 = 7009;
                    SecsPort_02 = 7010;
                    break;
                case "GIB":
                    SecsPort_01 = 7021;                                        
                    SecsPort_02 = 7022;                    
                    break;
            }

            foreach (CHSMS oHSMS in HSMSCollection.Values)
            {
                if (oHSMS.CurrentState == HsmsStateConst.Selected)
                {
                    if (SecsPort_01 != -1)
                    {
                        if (GetHSMS(SecsPort_01) != null)
                        {
                            GetHSMS(SecsPort_01).S1F1.Send();
                        }
                    }
                    if (SecsPort_02 != -1)
                    {
                        if (GetHSMS(SecsPort_02) != null)
                        {
                            GetHSMS(SecsPort_02).S1F1.Send();
                        }
                    }
                }
            }
        }

        public void SendS6F3(string EQPID, string LOTID, string CSTID, string GLSID, string TYPE, string DATA, CHSMS oHSMS)
        {
            if (oHSMS.CurrentState == HsmsStateConst.Selected)
            {
                oHSMS.S6F3.LOT_ID(LOTID);
                oHSMS.S6F3.CST_ID(CSTID);
                oHSMS.S6F3.GLASS_ID(GLSID);
                oHSMS.S6F3.TYPE(TYPE);
                oHSMS.S6F3.DATA(DATA);
                oHSMS.S6F3.Send();                
            }            
        }

        public void SendS6F3(string EQPID, string LOTID, string CSTID, string GLSID, string TYPE, string DATA)
        {
            foreach (CHSMS oHSMS in HSMSCollection.Values)
            {
                if (oHSMS.CurrentState == HsmsStateConst.Selected)
                {
                    oHSMS.S6F3.LOT_ID(LOTID);
                    oHSMS.S6F3.CST_ID(CSTID);
                    oHSMS.S6F3.GLASS_ID(GLSID);
                    oHSMS.S6F3.TYPE(TYPE);
                    oHSMS.S6F3.DATA(DATA);
                    oHSMS.S6F3.Send();
                }
                else
                {
                    //Queuing
                    CLamiSendData oData = new CLamiSendData();
                    oData.EQPID = EQPID;
                    oData.LOTID = LOTID;
                    oData.CSTID = CSTID;
                    oData.GLSID = GLSID;
                    oData.TYPE = TYPE;
                    oData.DATA = DATA;
                    oData.HSMS = oHSMS;
                    _waitQueue.Enqueue(oData);
                }
            }            
        }

        public void SendS6F5(string DELETE_CMD, string DELETE_ID)
        {
            if (oMain.SystemConfig.SPECIAL_EQP_TYPE == enumSPECIAL_EQP_TYPE.FPC)
            {                
                GetHSMS(7011).S6F5.CMD(DELETE_CMD);
                GetHSMS(7011).S6F5.DELETE_ID(DELETE_ID);
                GetHSMS(7011).S6F5.Send();
            }
        }

        public void ReplyS6F8(string strGLSID, string DATA, CHSMS.CS6F7 oS6F7)
        {
            if (oMain.SystemConfig.SPECIAL_EQP_TYPE == enumSPECIAL_EQP_TYPE.FPC)
            {
                GetHSMS(oS6F7.Driver.m_LocalPort).S6F8.DATA(DATA);
                GetHSMS(oS6F7.Driver.m_LocalPort).S6F8.GLASS_ID(strGLSID);
                GetHSMS(oS6F7.Driver.m_LocalPort).S6F8.Reply(oS6F7);
            }
        }

        public void Open()
        {
            //_hsms.Open();
            foreach (CHSMS oHSMS in HSMSCollection.Values)
            {
                oHSMS.Open();
            }
        }

        public void Reconnect(string EQPID)
        {
            try
            {
                int SecsPort_01 = -1;
                int SecsPort_02 = -1;
                switch (EQPID)
                {
                    case "AF01":
                        SecsPort_01 = 7001;
                        SecsPort_02 = 7002;
                        break;
                    case "AF02":
                        SecsPort_01 = 7003;
                        SecsPort_02 = 7004;
                        break;
                    case "AF03":
                        SecsPort_01 = 7005;
                        SecsPort_02 = 7006;
                        break;
                    case "LAMI01":
                    case "FPC01":
                        SecsPort_01 = 7007;
                        SecsPort_02 = 7008;
                        break;
                    case "LAMI02":
                    case "FPC02":
                        SecsPort_01 = 7009;
                        SecsPort_02 = 7010;
                        break;
                    case "FPC":
                        SecsPort_01 = 7011;
                        SecsPort_02 = 7011;
                        break;
                    case "GIB":
                        SecsPort_01 = 7021;
                        SecsPort_02 = 7022;
                        break;
                }
                CHSMS oReconHSMS = null;

                foreach (CHSMS oHSMS in HSMSCollection.Values)
                {
                    //if (oHSMS.CurrentState == HsmsStateConst.Selected)
                    //{
                        if (SecsPort_01 != -1)
                        {
                            if (GetHSMS(SecsPort_01) != null)
                            {
                                oReconHSMS = GetHSMS(SecsPort_01);
                                break;
                            }
                        }
                        if (SecsPort_02 != -1)
                        {
                            if (GetHSMS(SecsPort_02) != null)
                            {
                                oReconHSMS = GetHSMS(SecsPort_02);
                                break;
                            }
                        }
                    //}
                }

                if (oReconHSMS != null)
                {
                    oReconHSMS.Close();
                    System.Threading.Thread.Sleep(300);
                    oReconHSMS.Open();                    
                }
            }
            catch { }
        }

        public void Dispose()
        {           
            //HSMSConnect = enumHSMSConnect.Disconnect;
            //_hsms.Dispose();
            _isEnd = true;
            foreach (CHSMS oHSMS in HSMSCollection.Values)
            {
                oHSMS.Dispose();
            }
        }

        #endregion

        void _hsms_SecsUnknownMessage(object sender, SecsMessageEventArgs e)
        {

        }

        void _hsms_SecsTimeOut(object sender, SecsEventArgs e)
        {

        }

        void _hsms_SecsError(object sender, SecsEventArgs e)
        {
            
        }

        void _hsms_SecondaryOut(object sender, SecsMessageEventArgs e)
        {

        }

        void _hsms_SecondaryIn(object sender, SecsMessageEventArgs e)
        {

        }

        void _hsms_PrimaryOut(object sender, SecsMessageEventArgs e)
        {

        }

        void _hsms_PrimaryIn(object sender, SecsMessageEventArgs e)
        {
           
        }

        void _hsms_Disconnected(object sender, SecsEventArgs e)
        {            
            //HSMSConnect = enumHSMSConnect.Disconnect;
            CHSMS oHsms = sender as CHSMS;
            if (oHsms != null)
            {
                try
                {
                    int iPort = oHsms.m_LocalPort;
                    if (SecsConnectChange != null)
                    {
                        string EQPName = "";
                        if (oMain.SystemConfig.SPECIAL_EQP_TYPE == enumSPECIAL_EQP_TYPE.FPC)
                        {
                            EQPName = GetFPCConnectEQPName(iPort);
                            SecsConnectChange(EQPName, false);
                        }
                        else if (oMain.SystemConfig.SPECIAL_EQP_TYPE == enumSPECIAL_EQP_TYPE.LAMI)
                        {
                            EQPName = GetLAMIConnectEQPName(iPort);
                            SecsConnectChange(EQPName, false);
                        }
                    }
                }
                catch (Exception ex)
                {
                    CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "EMP", ex));
                }
            }
        }

        void _hsms_Connected(object sender, SecsEventArgs e)
        {
            //HSMSConnect = enumHSMSConnect.Connect;
            CHSMS oHsms = sender as CHSMS;
            if (oHsms != null)
            {
                try
                {
                    int iPort =oHsms.m_LocalPort;
                    if (SecsConnectChange != null)
                    {
                        string EQPName = "";
                        if (oMain.SystemConfig.SPECIAL_EQP_TYPE == enumSPECIAL_EQP_TYPE.FPC)
                        {
                            EQPName = GetFPCConnectEQPName(iPort);
                            SecsConnectChange(EQPName, true);
                        }
                        else if (oMain.SystemConfig.SPECIAL_EQP_TYPE == enumSPECIAL_EQP_TYPE.LAMI)
                        {
                            EQPName = GetLAMIConnectEQPName(iPort);
                            SecsConnectChange(EQPName, true);
                        }
                    }
                }
                catch(Exception ex)
                {
                    CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "EMP", ex));
                }
            }
        }

        private string GetLAMIConnectEQPName(int iPort)
        {
            string strRet = "";
            switch (iPort)
            {
                case 7007:
                    strRet = "FPC01";
                    break;
                case 7008:
                    strRet = "FPC02";
                    break;
                case 7009:
                    strRet = "FPC01";
                    break;
                case 7010:
                    strRet = "FPC02";
                    break;
            }
            return strRet;
        }

        private string GetFPCConnectEQPName(int iPort)
        {
            string strRet = "";
            switch (iPort)
            {
                case 7001:
                    strRet = "AF01";
                    break;
                case 7002:
                    strRet = "AF01";
                    break;
                case 7003:
                    strRet = "AF02";
                    break;
                case 7004:
                    strRet = "AF02";
                    break;
                case 7005:
                    strRet = "AF03";
                    break;
                case 7006:
                    strRet = "AF03";
                    break;
                case 7007:
                    strRet = "LAMI01";
                    break;
                case 7008:
                    strRet = "LAMI01";
                    break;
                case 7009:
                    strRet = "LAMI02";
                    break;
                case 7010:
                    strRet = "LAMI02";
                    break;
                case 7011:
                    strRet = "FPC";
                    break;
                case 7021:
                    strRet = "GIB";
                    break;
                case 7022 :
                    strRet = "GIB";
                    break;
            }
            return strRet;
        }
    }

    public class CLamiSendData
    {
        public string EQPID { get; set; }
        public string LOTID { get; set; }
        public string CSTID { get; set; }
        public string GLSID { get; set; }
        public string TYPE { get; set; }
        public string DATA { get; set; }
        public CHSMS HSMS { get; set; }
    }
}

