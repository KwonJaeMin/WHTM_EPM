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

    public class TrackingJobReport : AProgram
    {
        private CMain _main = null;
        private bool _enable = false;

        //BC
        private CScanControlProperties IB_TRACKING_JOB_REPORT_UNIT1 = null;//RV_B_TrackingJobReportUnit1_L3ToBC
        //PROBE CIM
        private CPLCControlProperties OB_TRACKING_JOB_REPORT_UNIT1 = null;//RV_B_TrackingJobReportUnit1_L3ToBC
        private CPLCControlProperties OW_TRACKING_JOB_UNIT1 = null;//RV_W_TrackingJobUnit1_L3ToBC        

        private string _controlName = "";
        private CProbeControl _component = null;

        public TrackingJobReport()
        {
        }

        public override int Init()
        {
            _enable = true;

            //BC
            IB_TRACKING_JOB_REPORT_UNIT1 = _main.SCANCONTEROLS.GetProperty(_controlName, "IB_TRACKING_JOB_REPORT_UNIT1");
            //PROBE CIM
            OB_TRACKING_JOB_REPORT_UNIT1 = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_TRACKING_JOB_REPORT_UNIT1");
            OW_TRACKING_JOB_UNIT1 = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_TRACKING_JOB_UNIT1");

            _component.ProgramsAdd(this);
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
            get { return "TRACKING_JOB_REPORT"; }
        }

        public override string Version
        {
            get { return "ver 1.0"; }
        }

        public override string Description
        {
            get { return "장비 RECIPE 변경 REPORT 처리 프로그램"; }
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
            get { return false; }
        }
        private const int T1 = 1000;
        protected override int InnerExecute()
        {
            //받아서 처리하는 부분
            //양전자 RECIPE 가져오는 곳

            List<int> jobDataC = new List<int>();//42
            CGlassDataPropertiesWHTM glassData1 = null;
            AMaterialData materialData = null;
            TimeSpan elapsedSpan = new TimeSpan();
            int index = -1;

            index = int.Parse(_values["GLS_INDEX"]);

            if (index == -1)
                return -1;


            try
            {
                if (_isManualMode)
                {
                    glassData1 = new CGlassDataPropertiesWHTM();
                    glassData1.GlassIndex = 1;
                    glassData1.CassetteIndex = 2;
                    glassData1.CassetteIndex = 2;
                    glassData1.ProductCode = 1;
                    glassData1.GlassThickness = 1;
                    glassData1.LotID = "GA";
                    glassData1.GlassID = "GB";
                    glassData1.PPID = "1";
                    glassData1.GlassType = 1;
                    glassData1.JobJudge = "G";
                    glassData1.JobState = 5;
                    glassData1.JobGrade = "G";
                    glassData1.TrackingData = 1000;
                    glassData1.UnitPathNo = 1;
                    glassData1.SlotNo = 0;
                    glassData1.CycleTime = 10000;
                    glassData1.TactTime = 10000;
                    glassData1.ReasonCode = 1;
                    glassData1.SamplingFlag = 1;
                    glassData1.LotEndFlag = 1;
                    glassData1.OperationId = "ABCDEFG";
                    glassData1.ProductId = "ABCDEFGAA";
                    glassData1.CassetteId = "ABCDEFGAA";
                    glassData1.ProcessedTime = 10000;
                    glassData1.ProcessedStartTime = "100000";
                    glassData1.ProcessedEndTime = "100000";
                    glassData1.CurrentWIPCount = 1;
                    glassData1.JobState = 5;
                    glassData1.TransportState = 1;
                    jobDataC = CGlassDataPropertiesWHTM.ConvertPLCDataC(glassData1);
                }
                else
                {
                    switch (_values["TRANS_STATE"])
                    {
                        case "1":
                            materialData = _main.GetReceivedGlassDataByLoc(_component.ControlName, index);
                            glassData1 = materialData as CGlassDataPropertiesWHTM;
                            glassData1.ProcessedStartTime = "";
                            glassData1.ProcessedEndTime = "";
                            break;
                        case "2":
                            materialData = _main.GetReceivedGlassDataByLoc(_component.ControlName, index);
                            glassData1 = materialData as CGlassDataPropertiesWHTM;
                            glassData1.ProcessedStartTime = _main.Get_Process_Start_Time(index).ToString();
                            glassData1.ProcessedEndTime = "";
                            break;
                        case "3":
                            materialData = _main.GetReceivedGlassDataByLoc(_component.ControlName, index);
                            glassData1 = materialData as CGlassDataPropertiesWHTM;
                            ////임시
                            //glassData1 = new CGlassDataPropertiesWHTM();
                            glassData1.ProcessedStartTime = _main.Get_Process_Start_Time(index).ToString();
                            glassData1.ProcessedEndTime = _main.Get_Process_End_Time(index).ToString();
                            elapsedSpan = new TimeSpan(_main.Get_Process_End_Time(index).Ticks - _main.Get_Process_Start_Time(index).Ticks);
                            glassData1.ProcessedTime = (ushort)elapsedSpan.TotalSeconds < 0 ? (ushort)0 : (ushort)elapsedSpan.TotalSeconds;

                            break;
                        case "4":
                            materialData = _main.GetSentOutGlassDataByLoc(_component.ControlName, index);
                            glassData1 = materialData as CGlassDataPropertiesWHTM;
                            glassData1.ProcessedStartTime = _main.Get_Process_Start_Time(index).ToString();
                            glassData1.ProcessedEndTime = _main.Get_Process_End_Time(index).ToString();
                            elapsedSpan = new TimeSpan(_main.Get_Process_End_Time(index).Ticks - _main.Get_Process_Start_Time(index).Ticks);
                            glassData1.ProcessedTime = (ushort)elapsedSpan.TotalSeconds < 0 ? (ushort)0 : (ushort)elapsedSpan.TotalSeconds;
                            break;

                        default:
                            break;
                    }
                    glassData1.UnitPathNo = 301;
                    glassData1.SlotNo = 0;
                    glassData1.TransportState = ushort.Parse(_values["TRANS_STATE"]);
                    glassData1.JobStateInt = 5;
                    glassData1.CurrentWIPCount = 1;
                    jobDataC = CGlassDataPropertiesWHTM.ConvertPLCDataC(glassData1);
                }

                _main.MelsecNetMultiWordWrite(OW_TRACKING_JOB_UNIT1, jobDataC);


                //_main.MelsecNetBitOnOff(OB_REMOVED_JOB_REPORT, true);
                Log(string.Format("{0}\t{1}", _component.ControlName, string.Format("PGM DATA SEND - RECIPEID={0}", "")));

                //CSubject subject = CUIManager.Inst.GetData("ucCimStatus");
                //subject.SetValue("EQPSTATUS", _component.MachineAutoMode);
                //subject.Notify();

                //Thread.Sleep(1000);
                //_main.MelsecNetBitOnOff(OB_REMOVED_JOB_REPORT, false);


                CTimeout timeout = CTimeoutManager.GetTimeout(_controlName, T1);
                timeout.TargetOffValueCheck = true;
                timeout.Begin(OB_TRACKING_JOB_REPORT_UNIT1, _main.CONTROLATTRIBUTES.GetProperty(IB_TRACKING_JOB_REPORT_UNIT1.ControlName, IB_TRACKING_JOB_REPORT_UNIT1.AttributeName) as ITimeoutResource);

                _main.MelsecNetBitOnOff(OB_TRACKING_JOB_REPORT_UNIT1, true);
                //Thread.Sleep(1000);
                //IB_TRACKING_JOB_REPORT_UNIT1.Value = true.ToString();
                string tempMsg = "";
                bool error = false;
                if (CTimeout.WaitSync(timeout, 10))
                {
                    return 0;
                }
                else
                {
                    //error = true;
                    _main.MelsecNetBitOnOff(OB_TRACKING_JOB_REPORT_UNIT1, false);
                    //tempMsg = string.Format("PGM DATA TIMEOUT No response [timeout T1={0} sec]", T1 / 1000);
                    //Log(string.Format("{0}\t{1}", _component.ControlName, tempMsg));
                }

                Log(string.Format("{0}\t{1}", _component.ControlName, "PGM DATA DISPLAY"));

                CSubject subject = null;
                //if (glassData1 != null || glassData2 != null)
                //{
                //    subject = CUIManager.Inst.GetData("ucGlassData");
                //    subject.SetValue("GlassCount", 2);
                //    subject.SetValue("Data", CGlassDataPropertiesWHTM.GetGuiData(glassData1));
                //    subject.SetValue("Data2", CGlassDataPropertiesWHTM.GetGuiData(glassData2));
                //    subject.Notify();
                //}

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
            catch (Exception e)
            {

                Log(string.Format("{0}\t{1}", _component.ControlName, e.ToString()));

                return 0;
            }

            

        }

        public override int ExecuteManual(Dictionary<string, string> values)
        {
            _values = values;
            return InnerExecute(); ;
        }
    }
}
