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

namespace MainLibrary.Manager
{
    public enum enumHSMSConnect
    {
        Connect,
        Disconnect,
    }

    public delegate void delegateReceiveAFMsg(string LOTID, string MSG);
    public delegate void delegateReceiveLAMIMsg(string LOTID, string CSTID, string GLSID, string MSGType, string MSG);
    
    public class CSECSManager
    {
        public event delegateReceiveAFMsg AFMsg = null;
        public event delegateReceiveLAMIMsg LAMIMsg = null;

        //private SecsProperties _properties = null;
        //private CHSMS _hsms = null;
        private CMain _main = null;

        private Dictionary<string, CHSMS> _HSMSCollection = new Dictionary<string, CHSMS>();

        public Dictionary<string, CHSMS> HSMSCollection
        {
            get { return _HSMSCollection; }
            set { _HSMSCollection = value; }
        }

        public CMain oMain
        {
            get { return _main; }
            set { _main = value; }
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

            if (main.SystemConfig.SPECIAL_EQP_TYPE == enumSPECIAL_EQP_TYPE.FPC)
            {                
                //FPC는 EQPNO가 1 or 2 가 나올것임.
                for (int i = 0; i < 5; i++)
                {
                    int iOpenPort = 7000 + EQPNO + (i * 2);  //EQP1 : 1,3,5,7,9     EQP2 : 2,4,6,8,10                                        
                    SecsProperties oProp = new SecsProperties();
                    CHSMS oHSMS = new CHSMS(EQPID + "_" + iOpenPort.ToString(), oProp);

                    oProp.Library = new SecsLibrary();
                    oProp.Library.Description = "LIBRARY";
                    string strFileName = "OGS_PASSIVE_" + iOpenPort.ToString() + ".lic";
                    string path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"\Config\" + strFileName;
                    oHSMS.Load(path);
                    
                    //PORT NO로 EQP 관련 정보를 찾을 수 있도록 고정화 시킴.
                    //개별 파일로 Load하게 수정 해당 코드 주석
                    //oHSMS.Properties.IsActive = false;
                    //oHSMS.m_LocalPort = iOpenPort;          
                    
                    AddEvent(oHSMS);

                    HSMSCollection.Add(iOpenPort.ToString(), oHSMS);
                }

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
                    string strFileName = "OGS_ACTIVE_" + iOpenPort.ToString() + ".lic";
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
        }

        void S6F6_OnReceived(CHSMS.CS6F6 S6F6)
        {
            
        }

        void S6F5_OnReceived(CHSMS.CS6F5 S6F5)
        {
            
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
            
        }

        void S1F1_OnReceived(CHSMS.CS1F1 S1F1)
        {            
            GetHSMS(S1F1.Driver.m_LocalPort).S1F2.Reply(S1F1);
        }

        #region Functions

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

        public void Dispose()
        {           
            //HSMSConnect = enumHSMSConnect.Disconnect;
            //_hsms.Dispose();
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
        }

        void _hsms_Connected(object sender, SecsEventArgs e)
        {
            //HSMSConnect = enumHSMSConnect.Connect;
        }
    }
}
