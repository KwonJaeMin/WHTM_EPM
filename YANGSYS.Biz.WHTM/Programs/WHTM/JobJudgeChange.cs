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

    public class JobJudgeChange : AProgram
    {
        private CMain _main = null;
        private bool _enable = false;

        //BC
        private CScanControlProperties IB_JOB_JUDGE_CHANGE = null;//RV_B_JobJudgeChange_L3ToBC
        //PROBE CIM
        private CPLCControlProperties OB_JOB_JUDGE_CHANGE = null;//RV_B_JobJudgeChange_L3ToBC
        private CPLCControlProperties OW_JOB_JUDGE_CHANGE_JOBDATAB = null;//RV_W_JobJudgeChangeData_L3ToBC.JobDataB
        

        private string _controlName = "";
        private CProbeControl _component = null;

        public JobJudgeChange()
        {
        }

        public override int Init()
        {
            _enable = true;

            //BC
            IB_JOB_JUDGE_CHANGE = _main.SCANCONTEROLS.GetProperty(_controlName, "IB_JOB_JUDGE_CHANGE");
            //PROBE CIM
            OB_JOB_JUDGE_CHANGE = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_JOB_JUDGE_CHANGE");
            OW_JOB_JUDGE_CHANGE_JOBDATAB = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_JOB_JUDGE_CHANGE_JOBDATAB");

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
            get { return "JOB_JUDGE_CHANGE"; }
        }

        public override string Version
        {
            get { return "ver 1.0"; }
        }

        public override string Description
        {
            get { return "장비 JUDGE 변경 REPORT 처리 프로그램"; }
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
            //받아서 처리하는 부분
            //양전자 RECIPE 가져오는 곳

            List<int> jobDataB1 = new List<int>();
            List<int> jobDataB2 = new List<int>();
       
            CGlassDataPropertiesWHTM glassData1 = null;
            CGlassDataPropertiesWHTM glassData2 = null;

            userNewGlassData.UnitPathNo = 301;
            userNewGlassData.SlotNo = 0;

            List<int> changedJobData = new List<int>();
            if (_userRequest)
            {
                _userRequest = false;
                if (userNewGlassData != null)
                {
                    jobDataB1 = CGlassDataPropertiesWHTM.ConvertPLCDataB(userNewGlassData);
                    //jobDataB1 = CGlassDataPropertiesWHTM.ConvertPLCDataB(new CGlassDataPropertiesWHTM());
                }
            }
            else
            {
                AMaterialData materialData = _main.GetReceivedGlassDataByLoc(_component.ControlName, 0);
                glassData1 = materialData as CGlassDataPropertiesWHTM;
                jobDataB1 = CGlassDataPropertiesWHTM.ConvertPLCDataB(glassData1);

                AMaterialData materialData2 = _main.GetReceivedGlassDataByLoc(_component.ControlName, 1);
                glassData2 = materialData2 as CGlassDataPropertiesWHTM;
                jobDataB2 = CGlassDataPropertiesWHTM.ConvertPLCDataB(glassData2);
            }
            _main.MelsecNetMultiWordWrite(OW_JOB_JUDGE_CHANGE_JOBDATAB, jobDataB1);
            //_main.MelsecNetMultiWordWrite(OW_JOB_JUDGE_CHANGE_JOBDATAB, jobDataB2);

            //_main.MelsecNetBitOnOff(OB_JOB_JUDGE_CHANGE, true);
            Log(string.Format("{0}\t{1}", _component.ControlName, string.Format("PGM DATA SEND - RECIPEID={0}", "")));



            //CSubject subject = CUIManager.Inst.GetData("ucCimStatus");
            //subject.SetValue("EQPSTATUS", _component.MachineAutoMode);
            //subject.Notify();

            //Thread.Sleep(1000);
            //_main.MelsecNetBitOnOff(OB_JOB_JUDGE_CHANGE, false);

            CTimeout timeout = CTimeoutManager.GetTimeout(_controlName, T1);
            timeout.TargetOffValueCheck = true;
            timeout.Begin(OB_JOB_JUDGE_CHANGE, _main.CONTROLATTRIBUTES.GetProperty(IB_JOB_JUDGE_CHANGE.ControlName, IB_JOB_JUDGE_CHANGE.AttributeName) as ITimeoutResource);

            _main.MelsecNetBitOnOff(OB_JOB_JUDGE_CHANGE, true);
            Thread.Sleep(1000);
            IB_JOB_JUDGE_CHANGE.Value = true.ToString();

            string tempMsg = "";
            bool error = false;
            if (CTimeout.WaitSync(timeout, 10))
            {

            }
            else
            {
                error = true;
                _main.MelsecNetBitOnOff(OB_JOB_JUDGE_CHANGE, false);
                tempMsg = string.Format("PGM DATA TIMEOUT No response [timeout T1={0} sec]", T1 / 1000);
                Log(string.Format("{0}\t{1}", _component.ControlName, tempMsg));
            }

            if (!error)
                return 0;
            Log(string.Format("{0}\t{1}", _component.ControlName, "PGM DATA DISPLAY"));

            #region 메시지 창 표시
            CSubject subject = null;
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
            userNewGlassData = new CGlassDataPropertiesWHTM(CGlassDataPropertiesWHTM.GetGuiDataToPLC(values));
            _userRequest = true;
            InnerExecute();
            return 0;
        }
        CGlassDataPropertiesWHTM userNewGlassData = null;
        bool _userRequest = false;
    }
}
