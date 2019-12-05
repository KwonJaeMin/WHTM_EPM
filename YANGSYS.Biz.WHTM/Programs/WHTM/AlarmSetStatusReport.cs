using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YANGSYS.ControlLib;
using SOFD.Properties;
using SOFD.InterfaceTimeout;
using MainLibrary;
using SOFD.Component;
using SOFD.Component.Interface;

using SOFD.Logger;
using SOFD.Global.Manager;
using System.Threading;
using MainLibrary.Property;


namespace YANGSYS.Biz.Programs
{

    public class AlarmSetStatusReport : AProgram
    {
        private CMain _main = null;
        private bool _enable = false;

        //BC
        private CScanControlProperties IB_ALARM_STATUS_REPORT = null;//Class3,RV_B_AlarmStatusReport_L3ToBC
        //PROBE CIM
        private CPLCControlProperties OB_ALARM_STATUS_REPORT = null;//RV_B_AlarmStatusReport_L3ToBC
        private CPLCControlProperties OW_ALARM_STATUS_BLOCK = null;//RV_W_AlarmBlock_L3ToB
        private CPLCControlProperties OW_ALARM_STATUS = null;//RV_W_AlarmBlock_L3ToBC,0
        private CPLCControlProperties OW_ALARM_ISSUED_UNIT_PATH_NO = null;//RV_W_AlarmBlock_L3ToBC,1
        private CPLCControlProperties OW_ALARM_ID = null;//RV_W_AlarmBlock_L3ToBC,2
        private CPLCControlProperties OW_ALARM_CODE = null;//RV_W_AlarmBlock_L3ToBC,3
        private CPLCControlProperties OW_ALARM_LEVEL= null;//RV_W_AlarmBlock_L3ToBC,4
        private CPLCControlProperties OW_ALARM_TEXT_USING_FLAG = null;//RV_W_AlarmBlock_L3ToBC,5
        private CPLCControlProperties OW_ALARM_TEXT = null;//RV_W_AlarmBlock_L3ToBC,6
        private CPLCControlProperties OW_ALARM_TIME = null;//RV_W_AlarmBlock_L3ToBC,7

        private CScanControlProperties VI_ALARM_SET = null;
        private CScanControlProperties VI_ALARM_RESET = null;

        private const int ALARM_SET = 1;
        private const int ALARM_RESET = 2;

        private const int ALARM_LIGHT = 1;
        private const int ALARM_SERIOUS = 2;

        private const int ALARM_USING_EQ_REPORT_ALARM_TEXT = 1;
        private const int ALARM_USING_BC_ALARM_TEXT = 2;

        private string _controlName = "";
        private CProbeControl _component = null;

        public AlarmSetStatusReport()
        {
        }

        public override int Init()
        {
            _enable = true;

            //BC
            IB_ALARM_STATUS_REPORT = _main.SCANCONTEROLS.GetProperty(_controlName, "IB_ALARM_STATUS_REPORT");

            //PROBE CIM
            OB_ALARM_STATUS_REPORT = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_ALARM_STATUS_REPORT");

            OW_ALARM_STATUS_BLOCK = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_ALARM_STATUS_BLOCK");
            OW_ALARM_STATUS = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_ALARM_STATUS");
            OW_ALARM_ISSUED_UNIT_PATH_NO = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_ALARM_ISSUED_UNIT_PATH_NO");
            OW_ALARM_ID = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_ALARM_ID");
            OW_ALARM_CODE = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_ALARM_CODE");
            OW_ALARM_LEVEL = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_ALARM_LEVEL");
            OW_ALARM_TEXT_USING_FLAG = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_ALARM_TEXT_USING_FLAG");
            OW_ALARM_TEXT = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_ALARM_TEXT");
            OW_ALARM_TIME = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_ALARM_TIME");

            VI_ALARM_SET = _main._YANSYS_SCANCONTEROLS.GetProperty(_controlName, "VI_ALARM_SET");
            VI_ALARM_RESET = _main._YANSYS_SCANCONTEROLS.GetProperty(_controlName, "VI_ALARM_RESET");

            _component.ProgramsAdd(this);
            
            ProgramDataList = new List<CProgramData>();

            CProgramData data = new CProgramData(ProgramDataList.Count, "ALARM_STATUS", typeof(int));
            data.Add(1, "Alarm Set");
            data.Add(2, "Alarm Clear");
            data.ValueType = typeof(short);
            ProgramDataList.Add(data);

            data = new CProgramData(ProgramDataList.Count, "ALARM_ISSUED_UNIT_PATH_NO", typeof(int));
            data.Add(1, "Equipment Level Alarm");
            data.Add(10, "Alarm Occurred Unit Path Number");
            data.ValueType = typeof(short);
            ProgramDataList.Add(data);

            data = new CProgramData(ProgramDataList.Count, "ALARM_ID", typeof(int));
            data.ValueType = typeof(int);
            ProgramDataList.Add(data);

            data = new CProgramData(ProgramDataList.Count, "ALARM_CODE", typeof(int));
            data.ValueType = typeof(int);
            ProgramDataList.Add(data);

            data = new CProgramData(ProgramDataList.Count, "ALARM_LEVEL", typeof(int));
            data.Add(1, "Light");
            data.Add(2, "Serious");             
            data.ValueType = typeof(short);
            ProgramDataList.Add(data);

            data = new CProgramData(ProgramDataList.Count, "OW_ALARM_TEXT_USING_FLAG", typeof(int));
            data.Add(1, "Using EQ Report Alarm Text");
            data.Add(2, "Using BC Alarm Text");
            data.ValueType = typeof(short);
            ProgramDataList.Add(data);

            data = new CProgramData(ProgramDataList.Count, "OW_ALARM_TEXT", typeof(string));
            data.ValueType = typeof(string);
            ProgramDataList.Add(data);

            data = new CProgramData(ProgramDataList.Count, "OW_ALARM_TIME", typeof(string));
            data.Add("YYMMDDhhmmss", "not used");
            data.ValueType = typeof(string);
            ProgramDataList.Add(data);
            return 0;
        }

        public override int AddArgs(object[] args, bool beforeClear)
        {
            if (args == null || args.Length < 2)
                return -1;

            if ((args[0] is CMain && args[1] is CProbeControl && args[1] is CProbeControl) == false)
            {
                return -1;
            }

            if (beforeClear)
            {

            }

            _main = args[0] as CMain;
            _component = args[1] as CProbeControl;
            _controlName = _component.ControlName;
            return 0;
        }
        public override string Name
        {
            get { return "ALARM_SET_STATUS_REPORT"; }
        }

        public override string Version
        {
            get { return "ver 1.0"; }
        }

        public override string Description
        {
            get { return "장비 ALARM을 보고 하는 프로그램"; }
        }
        public override bool Enable
        {
            get { return _enable; }
        }
        public override string Development
        {
            get { return "(주)서진정보기술"; }
        }

        public override bool IsCycle
        {
            get { return false; }
        }
        public override string SIteName
        {
            get { return "WHTM"; }
        }
        public override bool IsAsyncCall
        {
            get { return true; }
        }

        private const int T1 = 4000;
        protected override int InnerExecute()
        {
            int alarmstatus = 0;
            int alarmIssuedUnitPathNo = 0;
            int alarmId = 0;
            int alarmCode = 0;
            int alarmLevel = 0;
            int alarmtextUsingFlag = 0;
            string alarmText = "";

            List<ushort> alarmTime = new List<ushort>();

            CAlarmWHTM alarmData = null;
            if (_isProgramDataUse)
            {
                 object value = ProgramDataList[2].Value;
                 if (value == null)
                     value = "0";

                 alarmData = _main.AlarmDatas.GetAlarm<CAlarmWHTM>(value.ToString());

                 if (alarmData == null)
                 {
                     alarmData = new CAlarmWHTM();
                     alarmData.AlarmStatus = int.Parse(ProgramDataList[0].Value.ToString());
                     alarmData.UnitID = ProgramDataList[1].Value.ToString();
                     alarmData.AlarmID = ProgramDataList[2].Value.ToString();
                     alarmData.AlarmCode = ProgramDataList[3].Value.ToString();
                     alarmData.AlarmLevel = (CAlarmWHTM.enumAlarmLevel)Enum.Parse(typeof(CAlarmWHTM.enumAlarmLevel), ProgramDataList[4].Value.ToString());
                     alarmData.AlarmTextUsingFlag = (int)ProgramDataList[5].Value;
                     alarmData.AlarmText = (string)ProgramDataList[6].Value;
                 }
            }
            else if (_isManualMode)
            {
                alarmData = new CAlarmWHTM();
                alarmData.AlarmStatus = int.Parse(ProgramDataList[0].Value.ToString());
                alarmData.UnitID = ProgramDataList[1].Value.ToString();
                alarmData.AlarmID = ProgramDataList[2].Value.ToString();
                alarmData.AlarmCode = ProgramDataList[3].Value.ToString();
                alarmData.AlarmLevel = (CAlarmWHTM.enumAlarmLevel)Enum.Parse(typeof(CAlarmWHTM.enumAlarmLevel), ProgramDataList[4].Value.ToString());
                alarmData.AlarmTextUsingFlag = (int)ProgramDataList[5].Value;
                alarmData.AlarmText = (string)ProgramDataList[6].Value;
            }
            else
            {

                alarmData = new CAlarmWHTM();
                alarmData.UnitID = "1";

                string value = VI_ALARM_SET.Value;
                string[] temp = value.Split('|');
                int alarmCodeTemp = 0;
                if(temp != null && temp.Length > 2)
                {
                    //alarmCodeTemp = int.Parse(temp[1].Trim());
                    alarmstatus = temp[1] == ALARM_SET.ToString() ? ALARM_SET : ALARM_RESET;

                    string[] temp2 = temp[2].Split(',');
                    alarmData.AlarmText = temp[2];

                    alarmData.AlarmLevel = temp2[0] == ALARM_LIGHT.ToString() ? CAlarmWHTM.enumAlarmLevel.Light : CAlarmWHTM.enumAlarmLevel.Serious;
                    alarmData.AlarmCode = temp2[1];
                    alarmData.AlarmID = temp2[2];
                    alarmData.AlarmText = temp2[3];
                }
                
                //alarmData.AlarmID = alarmCodeTemp.ToString();
                //alarmData.AlarmCode = "2";
                //"[00 ~ 06 Bit : Alarm Category]
                //Bit 00 Danger for human
                //Bit 01 Equipment error
                //Bit 02 Parameter overflow cause 
                //         process error
                //Bit 03 Parameter overflow cause 
                //         equipment can't work
                //Bit 04 Can not recover trouble
                //Bit 05 Equipment status warning
                //Bit 06 Process reached to predefined 
                //         status"
                //alarmData.AlarmLevel = alarmCode > 1000 ? CAlarmWHTM.enumAlarmLevel.Serious : CAlarmWHTM.enumAlarmLevel.Light;
                alarmData.AlarmTextUsingFlag = ALARM_USING_EQ_REPORT_ALARM_TEXT;
                //alarmData.AlarmText = alarmText;

                //string yearTemp = DateTime.Now.Year.ToString();

                //ushort mYear = ushort.Parse(yearTemp.Substring(yearTemp.Length - 2, 2));
                //ushort mMonth = (ushort)DateTime.Now.Month;
                //ushort mDay = (ushort)DateTime.Now.Day;
                //ushort mHour = (ushort)DateTime.Now.Hour;
                //ushort mMin = (ushort)DateTime.Now.Minute;
                //ushort mSec = (ushort)DateTime.Now.Second;
                //alarmTime.Add(mMonth);
                //alarmTime.Add(mYear);
                //alarmTime.Add(mHour);
                //alarmTime.Add(mDay);
                //alarmTime.Add(mSec);
                //alarmTime.Add(mMin);
            }

            if (alarmData != null)
            {
                alarmData.UnitID = "1";
                alarmData.AlarmOffset = 30000;//30001~39999: #L3
                alarmData.regtime = DateTime.Now;
                
                //alarmData.AlarmStatus = ALARM_SET;
                _main.MelsecNetMultiWordWrite(OW_ALARM_STATUS_BLOCK, alarmData.GetPLCData());
            }
            else
            {
                Log(string.Format("{0}\t{1}", _component.ControlName, string.Format("PGM DATA SEND - ALARM NOT FOUND")));
            }

            //_main.MelsecNetWordWrite(OW_ALARM_STATUS, alarmstatus);
            //_main.MelsecNetWordWrite(OW_ALARM_ISSUED_UNIT_PATH_NO, alarmIssuedUnitPathNo);
            //_main.MelsecNetWordWrite(OW_ALARM_ID, alarmId);
            //_main.MelsecNetWordWrite(OW_ALARM_CODE, alarmCode);
            //_main.MelsecNetWordWrite(OW_ALARM_LEVEL, alarmLevel);
            //_main.MelsecNetWordWrite(OW_ALARM_TEXT_USING_FLAG, alarmtextUsingFlag);
            //_main.MelsecNetMultiWordWriteByString(OW_ALARM_TEXT, alarmText, 35, ' ');
            //_main.MelsecNetMultiWordWrite(OW_ALARM_TIME, alarmTime);

            Log(string.Format("{0}\t{1}", _component.ControlName, string.Format("PGM DATA SEND - ALARM STATUS={0} ISSUEDUNITPATHNO={1} ID={2} CODE={3} LEVEL={4} TEXTUSINGFLAG={5} TEXT={6} TIME={7}", alarmstatus, alarmIssuedUnitPathNo, alarmId, alarmCode, alarmLevel, alarmtextUsingFlag, alarmText, alarmTime)));

            CTimeout timeout = CTimeoutManager.GetTimeout(_controlName, T1);
            timeout.TargetOffValueCheck = true;
            timeout.Begin(OB_ALARM_STATUS_REPORT, _main.CONTROLATTRIBUTES.GetProperty(IB_ALARM_STATUS_REPORT.ControlName, IB_ALARM_STATUS_REPORT.AttributeName) as ITimeoutResource);

            _main.MelsecNetBitOnOff(OB_ALARM_STATUS_REPORT, true);
            Thread.Sleep(1000);
            IB_ALARM_STATUS_REPORT.Value = true.ToString();
            string tempMsg = "";
            bool error = false;
            if (CTimeout.WaitSync(timeout, 10))
            {
                _main.MelsecNetBitOnOff(OB_ALARM_STATUS_REPORT, false);
            }
            else
            {
                error = true;
                _main.MelsecNetBitOnOff(OB_ALARM_STATUS_REPORT, false);
                tempMsg = string.Format("PGM DATA TIMEOUT No response [timeout T1={0} sec]", T1 / 1000);
                Log(string.Format("{0}\t{1}", _component.ControlName, tempMsg));
            }

            Log(string.Format("{0}\t{1}", _component.ControlName, "PGM DATA DISPLAY"));
            CSubject subject = CUIManager.Inst.GetData("CurrentAlarm");
            if (alarmData != null)
            {
                List<string> alarmDataTemp = new List<string>();
                alarmDataTemp.Add(alarmData.regtime.ToString("yyyyMMdd HH:mm:ss.ff")); //code
                alarmDataTemp.Add(((uint.Parse(alarmData.AlarmID) + alarmData.AlarmOffset).ToString())); //AlarmID
                alarmDataTemp.Add(alarmData.AlarmCode.ToString()); //code
                alarmDataTemp.Add(alarmData.AlarmLevel.ToString());
                alarmDataTemp.Add(_component.ControlName);
                alarmDataTemp.Add(alarmData.AlarmText);
                alarmDataTemp.Add("Y");
                alarmDataTemp.Add(alarmData.AlarmStatus == 1 ? "SET" :"RESET");


                subject.SetValue("Alarm", alarmDataTemp);
                subject.Notify();
            }

            if (!error)
                return 0;

            #region 메시지 창 표시

            string receivedTime = DateTime.Now.ToString("yyyyMMdd HH:mm:ss");
            string msgId = "0";
            string message = string.Format("[{0}] {1}", this.Name, tempMsg);
            string panelNo = "1";

            subject = CUIManager.Inst.GetData("CIMMessage");
            subject.SetValue("List", new List<string>() { "MESSAGE_SET", msgId, receivedTime, message, panelNo });
            subject.Notify();

            #endregion
            return 0;
        }

        public override int ExecuteManual(List<AProgram.CProgramData> dataList)
        {
            return base.ExecuteManual(dataList);
        }
    }
}
