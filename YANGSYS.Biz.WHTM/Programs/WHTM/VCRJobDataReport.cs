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

    public class VCRJobDataReport : AProgram
    {
        private CMain _main = null;
        private bool _enable = false;

        //BC
        private CScanControlProperties IB_VCR_JOBDATA_REPORT = null;//RV_B_VCRJobDataReport_L3ToBC
        //PROBE CIM
        private CPLCControlProperties OB_VCR_JOBDATA_REPORT = null;//RV_B_VCRJobDataReport_L3ToBC
        private CPLCControlProperties OW_VCR_JOBDATA_REPORT_VCRNO = null;//RV_W_VCRJobDataReport_L3ToBC.VCRNo
        private CPLCControlProperties OW_VCR_JOBDATA_REPORT_VCR_USING_MODE = null;//RV_W_VCRJobDataReport_L3ToBC.UsingMode
        private CPLCControlProperties OW_VCR_JOBDATA_REPORT_VCR_STATUS = null;//RV_W_VCRJobDataReport_L3ToBC.VCRStatus
        private CPLCControlProperties OW_VCR_JOBDATA_REPORT_VCR_JOBDATAB = null;//RV_W_VCRJobDataReport_L3ToBC.JobDataB

        private const int USING_MODE_DISABLE = 0;
        private const int USING_MODE_ENABLE = 1;

        private const int VCR_READ_OK = 1;
        private const int VCR_READ_FAILED = 2;
        private const int VCR_SKIP = 3;
        private const int VCR_MISMATCH = 4;

        private string _controlName = "";
        private CProbeControl _component = null;

        public VCRJobDataReport()
        {
        }

        public override int Init()
        {
            _enable = true;

            //BC
            IB_VCR_JOBDATA_REPORT = _main.SCANCONTEROLS.GetProperty(_controlName, "IB_VCR_JOBDATA_REPORT");
            //PROBE CIM
            OB_VCR_JOBDATA_REPORT = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_VCR_JOBDATA_REPORT");
            OW_VCR_JOBDATA_REPORT_VCRNO = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_VCR_JOBDATA_REPORT_VCRNO");
            OW_VCR_JOBDATA_REPORT_VCR_USING_MODE = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_VCR_JOBDATA_REPORT_VCR_USING_MODE");
            OW_VCR_JOBDATA_REPORT_VCR_STATUS = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_VCR_JOBDATA_REPORT_VCR_STATUS");
            OW_VCR_JOBDATA_REPORT_VCR_JOBDATAB = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_VCR_JOBDATA_REPORT_VCR_JOBDATAB");

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
            get { return "VCR_JOB_DATA_REPORT"; }
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
            get { return true; }
        }
        private const int T1 = 4000;
        protected override int InnerExecute()
        {
            int VCRNo = 0; // 1
            int VCRUsingMode = 0; // 1
            int VCRStatus = 0; // 1
            List<int> jobDataB = new List<int>();
            CGlassDataPropertiesWHTM glassData1 = null;
            if (_isManualMode)
            {
                VCRNo = 1;
                VCRUsingMode = USING_MODE_DISABLE;
                VCRStatus = VCR_READ_OK;

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

                jobDataB = CGlassDataPropertiesWHTM.ConvertPLCDataB(glassData1);
            }
            else
            {

            }

            _main.MelsecNetWordWrite(OW_VCR_JOBDATA_REPORT_VCRNO, VCRNo);
            _main.MelsecNetWordWrite(OW_VCR_JOBDATA_REPORT_VCR_USING_MODE, VCRUsingMode);
            _main.MelsecNetWordWrite(OW_VCR_JOBDATA_REPORT_VCR_STATUS, VCRStatus);
            _main.MelsecNetMultiWordWrite(OW_VCR_JOBDATA_REPORT_VCR_JOBDATAB, jobDataB);

            Log(string.Format("{0}\t{1}", _component.ControlName, string.Format("PGM DATA SEND - VCR NO={0} USING MODE={0} STATUS={0}", VCRNo, VCRUsingMode, VCRStatus)));


            CTimeout timeout = CTimeoutManager.GetTimeout(_controlName, T1);
            timeout.TargetOffValueCheck = true;
            timeout.Begin(OB_VCR_JOBDATA_REPORT, _main.CONTROLATTRIBUTES.GetProperty(IB_VCR_JOBDATA_REPORT.ControlName, IB_VCR_JOBDATA_REPORT.AttributeName) as ITimeoutResource);
            _main.MelsecNetBitOnOff(OB_VCR_JOBDATA_REPORT, true);
            Thread.Sleep(1000);
            IB_VCR_JOBDATA_REPORT.Value = true.ToString();

            string tempMsg = "";
            bool error = false;
            if (CTimeout.WaitSync(timeout, 10))
            {

            }
            else
            {
                error = true;
                _main.MelsecNetBitOnOff(OB_VCR_JOBDATA_REPORT, false);
                tempMsg = string.Format("PGM DATA TIMEOUT No response [timeout T1={0} sec]", T1 / 1000);
                Log(string.Format("{0}\t{1}", _component.ControlName, tempMsg));
            }

            Log(string.Format("{0}\t{1}", _component.ControlName, "PGM DATA DISPLAY"));

            CSubject subject = null;

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
    }
}
