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

    public class RemovedJobReport : AProgram
    {
        private CMain _main = null;
        private bool _enable = false;

        //BC
        private CScanControlProperties IB_REMOVED_JOB_REPORT = null;//RV_B_RemovedJobReport_L3ToBC
        //PROBE CIM
        private CPLCControlProperties OB_REMOVED_JOB_REPORT = null;//RV_B_RemovedJobReport_L3ToBC
        private CPLCControlProperties OW_REMOVED_JOB_REPORT_JOBDATAA = null;//RV_W_RemovedJob_L3ToBC.JobDataA

        private CScanControlProperties VI_GLASS_SCRAP = null;

        private string _controlName = "";
        private CProbeControl _component = null;

        public RemovedJobReport()
        {
        }

        public override int Init()
        {
            _enable = true;

            //BC
            IB_REMOVED_JOB_REPORT = _main.SCANCONTEROLS.GetProperty(_controlName, "IB_REMOVED_JOB_REPORT");
            //PROBE CIM
            OB_REMOVED_JOB_REPORT = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_REMOVED_JOB_REPORT");
            OW_REMOVED_JOB_REPORT_JOBDATAA = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_REMOVED_JOB_REPORT_JOBDATAA");

            VI_GLASS_SCRAP = _main._YANSYS_SCANCONTEROLS.GetProperty(_controlName, "VI_GLASS_SCRAP");

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
            get { return "REMOVED_JOB_REPORT"; }
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
            //받아서 처리하는 부분
            //양전자 RECIPE 가져오는 곳

            List<int> jobDataA = new List<int>();//96
            CGlassDataPropertiesWHTM glassData1 = null;
            CGlassDataPropertiesWHTM glassData2 = null;

            CGlassDataPropertiesWHTM glassData = null;
            int jobCount1 = 0; // 1
            int wipCount1 = 1; // 1

            string glassID = "";
            string mscrapCode = "";
            int mScrap_Index = 0;

            List<int> glassCode = new List<int>();
            List<int> scrapCode = new List<int>();
            List<int> operID = new List<int>();
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
                glassData1.SlotNo = 1;
                glassData1.CycleTime = 10000;
                glassData1.TactTime = 10000;
                glassData1.ReasonCode = 1;
                glassData1.SamplingFlag = 1;
                glassData1.LotEndFlag = 1;
                glassData1.OperationId = "ABCDEFG";
                glassData1.ProductId = "ABCDEFGAA";
                glassData1.CassetteId = "ABCDEFGAA";

                jobDataA = CGlassDataPropertiesWHTM.ConvertPLCData(glassData1);
                jobCount1 = 1;
                wipCount1 = 1;
            }
            else
            {
                //string value = VI_GLASS_SCRAP.Value;
                //string[] temp = value.Split('|');
                //if (temp.Length != 3)
                //    return -1;

                if (_values == null)
                    return -1;




                glassID = _values["GLASSID"];
                mScrap_Index = int.Parse(_values["SCRAPINDEX"]);

                AMaterialData materialData = _main.GetReceivedGlassDataByLoc(_component.ControlName, mScrap_Index);
                //AMaterialData materialData2 = _main.GetReceivedGlassDataByLoc(_component.ControlName, 1);
                if (materialData == null)
                {
                    //20161128
                    List<string> dataList = new List<string>();

                    dataList.Add("GLASS_SCRAP_ACK");
                    dataList.Add("X");

                    _main.SendData(dataList);
                    return -1;
                }

                //if (materialData2 == null)
                //{
                //    //20161128
                //    List<string> dataList = new List<string>();

                //    dataList.Add("GLASS_SCRAP_ACK");
                //    dataList.Add("X");

                //    _main.SendData(dataList);
                //    return -1;
                //}

                glassData = materialData as CGlassDataPropertiesWHTM;

                string[] tempGlassID = glassData.GlassID.Split('\0');

                if (glassID == tempGlassID[0].Trim())
                {

                    jobDataA = CGlassDataPropertiesWHTM.ConvertPLCData(glassData);

                    if (_component.GlassStageExist) //20161129
                    {
                        //glassCode.AddRange(ConvertDecTo2WordList(Convert.ToInt32(glassData.GlassCode)));
                        ////scrapCode.Add(0);
                        ////scrapCode.Add(0);

                        //unitID = int.Parse(_component.UnitNo);

                        //tempOperID = _main.SystemConfig.UserAccount.ToCharArray();
                        //string word = "";
                        //foreach (char item in tempOperID)
                        //{
                        //    word = item + word;
                        //    if (word.Length > 1)
                        //    {
                        //        operID.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.StringToHex(word))));
                        //        word = "";
                        //    }
                        //}

                        ////tempCode = mscrapCode.ToCharArray();
                        ////foreach (char item in tempCode)
                        ////{
                        ////    word = item + word;
                        ////    if (word.Length > 1)
                        ////    {
                        ////        scrapCode.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.StringToHex(word))));
                        ////        word = "";
                        ////    }
                        ////}

                        //tempCode = mscrapCode.ToCharArray();
                        //string hex = "";
                        //for (int i = 0; i < tempCode.Length; i = i + 2)
                        //{
                        //    if (tempCode.Length > i + 1)
                        //    {
                        //        hex += SmartDevice.UTILS.PLCUtils.DecToHex(((int)tempCode[i + 1]).ToString()).Substring(2, 2);
                        //    }
                        //    if (tempCode.Length > i)
                        //    {
                        //        hex += SmartDevice.UTILS.PLCUtils.DecToHex(((int)tempCode[i]).ToString()).Substring(2, 2);
                        //        scrapCode.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(hex)));
                        //    }

                        //    hex = "";
                        //}

                    }

                }
                else
                {
                    //20161128
                    List<string> dataList = new List<string>();

                    dataList.Add("GLASS_SCRAP_ACK");
                    dataList.Add("X");

                    _main.SendData(dataList);
                    return -1;
                }

            }
            _main.MelsecNetMultiWordWrite(OW_REMOVED_JOB_REPORT_JOBDATAA, jobDataA);


            //_main.MelsecNetBitOnOff(OB_REMOVED_JOB_REPORT, true);
            Log(string.Format("{0}\t{1}", _component.ControlName, string.Format("PGM DATA SEND - RECIPEID={0}", "")));
 
            //CSubject subject = CUIManager.Inst.GetData("ucCimStatus");
            //subject.SetValue("EQPSTATUS", _component.MachineAutoMode);
            //subject.Notify();

            //Thread.Sleep(1000);
            //_main.MelsecNetBitOnOff(OB_REMOVED_JOB_REPORT, false);


            CTimeout timeout = CTimeoutManager.GetTimeout(_controlName, T1);
            timeout.TargetOffValueCheck = true;
            timeout.Begin(OB_REMOVED_JOB_REPORT, _main.CONTROLATTRIBUTES.GetProperty(IB_REMOVED_JOB_REPORT.ControlName, IB_REMOVED_JOB_REPORT.AttributeName) as ITimeoutResource);
            _main.MelsecNetBitOnOff(OB_REMOVED_JOB_REPORT, true);
            Thread.Sleep(1000);
            IB_REMOVED_JOB_REPORT.Value = true.ToString();
            string tempMsg = "";
            bool error = false;
            CSubject subject = null;
            if (CTimeout.WaitSync(timeout, 10))
            {
                //<TODO> Test용 임시
                _component.GlassStageExist = false;
                _component.GlassCode1 = 0;

                AMaterialData materialData = null;// _main.GetReceivedGlassDataByLoc(_component.ControlName, 0);
                _main.AddReceviedGlassData(_component.ControlName, materialData, mScrap_Index, false);

                if (mScrap_Index == 0)
                {
                    subject = CUIManager.Inst.GetData("ucEQP");

                    if (glassData.GlassPosition == 1)
                    {
                        subject.SetValue("GlassExist_A", false);
                    }
                    else
                    {
                        subject.SetValue("GlassExist_Whole", false);
                    }
                    subject.SetValue("GlassCode1", "");
                    subject.SetValue("GlassID1", "");
                    subject.Notify();
                }
                else
                {
                    subject = CUIManager.Inst.GetData("ucEQP");
                    subject.SetValue("GlassExist_B", false);
                    subject.SetValue("GlassCode2", "");
                    subject.SetValue("GlassID2", "");
                    subject.Notify();
                }
                //20161128
                List<string> dataList = new List<string>();

                dataList.Add("GLASS_SCRAP_ACK");
                dataList.Add("O");

                _main.SendData(dataList);

                _main.MelsecNetBitOnOff(OB_REMOVED_JOB_REPORT, false);
            }
            else
            {
                //에러:응답이 없다..
                List<string> dataList = new List<string>();

                dataList.Add("GLASS_SCRAP_ACK");
                dataList.Add("X");

                _main.SendData(dataList);

                dataList = new List<string>();
                dataList.Add("ALARM_SET_REQUEST");
                dataList.Add("1");
                dataList.Add("9001");
                _main.SendData(dataList);

                error = true;
                _main.MelsecNetBitOnOff(OB_REMOVED_JOB_REPORT, false);
                tempMsg = string.Format("PGM DATA TIMEOUT No response [timeout T1={0} sec]", T1 / 1000);
                Log(string.Format("{0}\t{1}", _component.ControlName, tempMsg));
            }

            Log(string.Format("{0}\t{1}", _component.ControlName, "PGM DATA DISPLAY"));

            if (glassData1 != null || glassData2 != null)
            {
                subject = CUIManager.Inst.GetData("ucGlassData");
                subject.SetValue("GlassCount", 2);
                subject.SetValue("Data", CGlassDataPropertiesWHTM.GetGuiData(glassData1));
                subject.SetValue("Data2", CGlassDataPropertiesWHTM.GetGuiData(glassData2));
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

        public override int ExecuteManual(Dictionary<string, string> values)
        {
            _values = values;
            InnerExecute();
            return 0;
        }
    }
}
