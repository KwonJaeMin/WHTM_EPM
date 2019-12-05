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

    public class ForwardReceivedJobReport : AProgram
    {
        private CMain _main = null;
        private bool _enable = false;

        //BC
        private CScanControlProperties IB_FORWARD_RECEIVED_JOB_REPORT = null;//RV_B_ForwardReceivedJobReport_L3ToBC
        //PROBE CIM
        private CPLCControlProperties OB_FORWARD_RECEIVED_JOB_REPORT = null;//RV_B_ForwardReceivedJobReport_L3ToBC
        private CPLCControlProperties OW_FORWARD_RECEIVED_JOB_REPORT_JOBDATAA1 = null;//RV_W_ForwardReceivedJob_L3ToBC.JobData1
        private CPLCControlProperties OW_FORWARD_RECEIVED_JOB_REPORT_CURRENT_WIP_COUNT1 = null;//RV_W_ForwardReceivedJob_L3ToBC.CurrentWipCount1
        private CPLCControlProperties OW_FORWARD_RECEIVED_JOB_REPORT_JOBDATAA2 = null;//RV_W_ForwardReceivedJob_L3ToBC.JobData2
        private CPLCControlProperties OW_FORWARD_RECEIVED_JOB_REPORT_CURRENT_WIP_COUNT2 = null;//RV_W_ForwardReceivedJob_L3ToBC.CurrentWipCount2

        private CScanControlProperties IB_LINK_UP1_HALFGLASSFLAG = null;

        private string _controlName = "";
        private CProbeControl _component = null;

        public ForwardReceivedJobReport()
        {
        }

        public override int Init()
        {
            _enable = true;

            //BC
            IB_FORWARD_RECEIVED_JOB_REPORT = _main.SCANCONTEROLS.GetProperty(_controlName, "IB_FORWARD_RECEIVED_JOB_REPORT");
            //PROBE CIM
            OB_FORWARD_RECEIVED_JOB_REPORT = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_FORWARD_RECEIVED_JOB_REPORT");
            OW_FORWARD_RECEIVED_JOB_REPORT_JOBDATAA1 = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_FORWARD_RECEIVED_JOB_REPORT_JOBDATAA1");
            OW_FORWARD_RECEIVED_JOB_REPORT_CURRENT_WIP_COUNT1 = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_FORWARD_RECEIVED_JOB_REPORT_CURRENT_WIP_COUNT1");
            OW_FORWARD_RECEIVED_JOB_REPORT_JOBDATAA2 = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_FORWARD_RECEIVED_JOB_REPORT_JOBDATAA2");
            OW_FORWARD_RECEIVED_JOB_REPORT_CURRENT_WIP_COUNT2 = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_FORWARD_RECEIVED_JOB_REPORT_CURRENT_WIP_COUNT2");

            IB_LINK_UP1_HALFGLASSFLAG = _main.SCANCONTEROLS.GetProperty(_controlName, "IB_LINK_UP1_HALFGLASSFLAG");
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
            get { return "RECEIVED_JOB_REPORT"; }
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

        private const int T1 = 4000;

        protected override int InnerExecute()
        {
            int index = -1;
            int wipCount1 = 1; // 1
            CGlassDataPropertiesWHTM glassData1 = null;
            List<int> jobDataA1 = null;

            index = int.Parse(_values["GLS_INDEX"]);

            if (index == -1)
                return -1;

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

                jobDataA1 = CGlassDataPropertiesWHTM.ConvertPLCData(glassData1);
                wipCount1 = 1;
            }
            else
            {
                AMaterialData materialData = _main.GetReceivedGlassDataByLoc(_component.ControlName, index);
                glassData1 = materialData as CGlassDataPropertiesWHTM;

                glassData1.UnitPathNo = 301;
                glassData1.SlotNo = 0;

                jobDataA1 = CGlassDataPropertiesWHTM.ConvertPLCData(glassData1);
                wipCount1 = 1;
            }

            _main.MelsecNetMultiWordWrite(OW_FORWARD_RECEIVED_JOB_REPORT_JOBDATAA1, jobDataA1);
            _main.MelsecNetWordWrite(OW_FORWARD_RECEIVED_JOB_REPORT_CURRENT_WIP_COUNT1, wipCount1);

            Log(string.Format("{0}\t{1}", _component.ControlName, string.Format("PGM DATA SEND - JOB DATA1={0} WIP COUNT1={1}", glassData1.ToString(), wipCount1)));

            Log(string.Format("{0}\t{1}", _component.ControlName, "PGM DATA DISPLAY"));

            CTimeout timeout = CTimeoutManager.GetTimeout(_controlName, T1);
            timeout.TargetOffValueCheck = true;
            timeout.Begin(OB_FORWARD_RECEIVED_JOB_REPORT, _main.CONTROLATTRIBUTES.GetProperty(IB_FORWARD_RECEIVED_JOB_REPORT.ControlName, IB_FORWARD_RECEIVED_JOB_REPORT.AttributeName) as ITimeoutResource);

            _main.MelsecNetBitOnOff(OB_FORWARD_RECEIVED_JOB_REPORT, true);
            Thread.Sleep(1000);
            IB_FORWARD_RECEIVED_JOB_REPORT.Value = true.ToString();
            string tempMsg = "";
            bool error = false;
            if (CTimeout.WaitSync(timeout, 10))
            {

            }
            else
            {
                error = true;
                _main.MelsecNetBitOnOff(OB_FORWARD_RECEIVED_JOB_REPORT, false);
                tempMsg = string.Format("PGM DATA TIMEOUT No response [timeout T1={0} sec]", T1 / 1000);
                Log(string.Format("{0}\t{1}", _component.ControlName, tempMsg));
            }

            Log(string.Format("{0}\t{1}", _component.ControlName, "PGM DATA DISPLAY"));

            CSubject subject = null;
            if (glassData1 != null)
            {
                if (index == 0)
                {
                    subject = CUIManager.Inst.GetData("ucGlassData");
                    subject.SetValue("Data", CGlassDataPropertiesWHTM.GetGuiData(glassData1));
                    subject.Notify();
                }
                else
                {
                    subject = CUIManager.Inst.GetData("ucGlassData");
                    subject.SetValue("Data2", CGlassDataPropertiesWHTM.GetGuiData(glassData1));
                    subject.Notify();
                }
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

        public override int ExecuteManual(Dictionary<string, string> values)
        {
            _values = values;
            return InnerExecute(); ;
        }
    }
}
