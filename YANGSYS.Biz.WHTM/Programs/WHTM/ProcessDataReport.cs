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
using MainLibrary.Utility;


namespace YANGSYS.Biz.Programs
{

    public class ProcessDataReport : AProgram
    {
        private CMain _main = null;
        private bool _enable = false;

        //BC
        private CScanControlProperties IB_PROCESS_DATA_REPORT = null;//RV_B_ProcessDataReport_L3ToBC
        //PROBE CIM
        private CPLCControlProperties OB_PROCESS_DATA_REPORT = null;//RV_B_ProcessDataReport_L3ToBC
        private CPLCControlProperties OW_PROCESS_DATA_REPORT_JOBDATAB = null;//RV_W_DV1_L3ToBC.JobDataB
        private CPLCControlProperties OW_PROCESS_DATA_REPORT_LOCAL_PROCESSING_TIME = null;//RV_W_DV1_L3ToBC.LocalProcessingTime      
        private CPLCControlProperties OW_PROCESS_DATA_REPORT_LOCAL_PROCESSING_START_TIME = null;//RV_W_DV1_L3ToBC.LocalProcessStartTime
        private CPLCControlProperties OW_PROCESS_DATA_REPORT_LOCAL_PROCESSING_END_TIME = null;//RV_W_DV1_L3ToBC.LocalProcessEndTime
        private CPLCControlProperties OW_PROCESS_DATA_REPORT_RECIPEID = null;//RV_W_DV1_L3ToBC.RecipeId
        private CPLCControlProperties OW_DV_DATA_1 = null;//RV_W_DV1_L3ToBC.VariableDataItems
        private CPLCControlProperties OW_DV_DATA_2 = null;
        private CPLCControlProperties OW_DV_DATA_3 = null;
        private CPLCControlProperties OW_DV_DATA_4 = null;
        private CPLCControlProperties OW_DV_DATA_5 = null;
        private CPLCControlProperties OW_DV_DATA_6 = null;
        private CPLCControlProperties OW_DV_DATA_7 = null;
        private CPLCControlProperties OW_DV_DATA_8 = null;
        private CPLCControlProperties OW_DV_DATA_9 = null;
        private CPLCControlProperties OW_DV_DATA_10 = null;
        private CPLCControlProperties OW_DV_DATA_11 = null;
        private CPLCControlProperties OW_DV_DATA_12 = null;
        private CPLCControlProperties OW_DV_DATA_13 = null;
        private CPLCControlProperties OW_DV_DATA_14 = null;
        private CPLCControlProperties OW_DV_DATA_15 = null;
        private CPLCControlProperties OW_DV_DATA_16 = null;
        private CPLCControlProperties OW_DV_DATA_17 = null;
        private CPLCControlProperties OW_DV_DATA_18 = null;
        private CPLCControlProperties OW_DV_DATA_19 = null;
        private CPLCControlProperties OW_DV_DATA_20 = null;
        private CPLCControlProperties OW_DV_DATA_21 = null;
        private CPLCControlProperties OW_DV_DATA_22 = null;
        private CPLCControlProperties OW_DV_DATA_23 = null;
        private CPLCControlProperties OW_DV_DATA_24 = null;
        private CPLCControlProperties OW_DV_DATA_25 = null;
        private CPLCControlProperties OW_DV_DATA_26 = null;
        private CPLCControlProperties OW_DV_DATA_27 = null; //20191202


        //private CScanControlProperties VI_GLASS_DATA_VALUE_FILE_REPORT = null;
        //aaaa
        private string _controlName = "";
        private CProbeControl _component = null;

        public ProcessDataReport()
        {
        }

        public override int Init()
        {
            _enable = true;

            //BC
            IB_PROCESS_DATA_REPORT = _main.SCANCONTEROLS.GetProperty(_controlName, "IB_PROCESS_DATA_REPORT");
            //PROBE CIM
            OB_PROCESS_DATA_REPORT = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_PROCESS_DATA_REPORT");
            OW_PROCESS_DATA_REPORT_JOBDATAB = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_PROCESS_DATA_REPORT_JOBDATAB");
            OW_PROCESS_DATA_REPORT_LOCAL_PROCESSING_TIME = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_PROCESS_DATA_REPORT_LOCAL_PROCESSING_TIME");
            OW_PROCESS_DATA_REPORT_LOCAL_PROCESSING_START_TIME = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_PROCESS_DATA_REPORT_LOCAL_PROCESSING_START_TIME");
            OW_PROCESS_DATA_REPORT_LOCAL_PROCESSING_END_TIME = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_PROCESS_DATA_REPORT_LOCAL_PROCESSING_END_TIME");
            OW_PROCESS_DATA_REPORT_RECIPEID = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_PROCESS_DATA_REPORT_RECIPEID");
            OW_DV_DATA_1 = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_DV_DATA_1");
            OW_DV_DATA_2 = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_DV_DATA_2");
            OW_DV_DATA_3 = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_DV_DATA_3");
            OW_DV_DATA_4 = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_DV_DATA_4");
            OW_DV_DATA_5 = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_DV_DATA_5");
            OW_DV_DATA_6 = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_DV_DATA_6");
            OW_DV_DATA_7 = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_DV_DATA_7");
            OW_DV_DATA_8 = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_DV_DATA_8");
            OW_DV_DATA_9 = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_DV_DATA_9");
            OW_DV_DATA_10 = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_DV_DATA_10");
            OW_DV_DATA_11 = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_DV_DATA_11");
            OW_DV_DATA_12 = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_DV_DATA_12");
            OW_DV_DATA_13 = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_DV_DATA_13");
            OW_DV_DATA_14 = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_DV_DATA_14");
            OW_DV_DATA_15 = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_DV_DATA_15");
            OW_DV_DATA_16 = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_DV_DATA_16");
            OW_DV_DATA_17 = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_DV_DATA_17");
            OW_DV_DATA_18 = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_DV_DATA_18");
            OW_DV_DATA_19 = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_DV_DATA_19");
            OW_DV_DATA_20 = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_DV_DATA_20"); //20191202
            OW_DV_DATA_21 = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_DV_DATA_21");
            OW_DV_DATA_22 = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_DV_DATA_22");
            OW_DV_DATA_23 = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_DV_DATA_23");
            OW_DV_DATA_24 = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_DV_DATA_24");
            OW_DV_DATA_25 = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_DV_DATA_25");
            OW_DV_DATA_26 = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_DV_DATA_26");
            OW_DV_DATA_27 = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_DV_DATA_27");
          

            //VI_GLASS_DATA_VALUE_FILE_REPORT = _main._YANSYS_SCANCONTEROLS.GetProperty(_controlName, "VI_GLASS_DATA_VALUE_FILE_REPORT");

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
            get { return "PROCESS_DATA_REPORT"; }
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

        public static int[] ByteArrayToIntArray(byte[] data, int start, int wordLength)
        {
            int arrayCount = wordLength;
            if (data.Length > start + arrayCount)
            {
                int[] temp = new int[arrayCount];
                int j = 0;
                for (int i = 0; i < wordLength; i++)
                {
                    temp[i] = (data[start + j++] | data[start + j++] << 8);
                }
                return temp;
            }
            else
            {
                throw new ArgumentOutOfRangeException("start and wordLength * 2 less then data's length");
            }
        }

        protected override int InnerExecute()
        {
            try
            {
                string recipeId = ""; //10
                int CCODE = 0; // 1
                string account = ""; //5

                string mYear = "";
                string mMonth = "";
                string mDay = "";
                string mHour = "";
                string mMin = "";
                string mSec = "";

                string mYear1 = "";
                string mMonth1 = "";
                string mDay1 = "";
                string mHour1 = "";
                string mMin1 = "";
                string mSec1 = "";

                int index = -1;

                index = int.Parse(_values["GLS_INDEX"]);

                if (index == -1)
                    return -1;

                string filePath = "";
                filePath = _values["FILE_PATH"];

                if (filePath == "")
                    return -1;

                //string mValue = VI_GLASS_DATA_VALUE_FILE_REPORT.Value;

                //string[] tempdata = mValue.Split('|');
                ////string filePath = "";

                //if (tempdata != null && tempdata.Length == 3)
                //{
                //    filePath = tempdata[1];// Glass Unloading시 측정 데이터 파일이 있는 Path 전송 ( 협의 후 수정 예정 )            
                //}

                //if (filePath != "")
                //{

                //}

                //받아서 처리하는 부분
                //양전자 RECIPE 가져오는 곳
                List<int> jobDataB = new List<int>();

                List<int> startTime = new List<int>();
                List<int> processingTime = new List<int>();
                List<int> endTime = new List<int>();
                List<int> variableDataItems = new List<int>();
                AMaterialData materialData = null;

                List<int> DV_List_Data1 = new List<int>();
                List<int> DV_List_Data2 = new List<int>();
                List<int> DV_List_Data3 = new List<int>();
                List<int> DV_List_Data4 = new List<int>();
                List<int> DV_List_Data5 = new List<int>();
                List<int> DV_List_Data6 = new List<int>();
                List<int> DV_List_Data7 = new List<int>();
                List<int> DV_List_Data8 = new List<int>();
                List<int> DV_List_Data9 = new List<int>();
                List<int> DV_List_Data10 = new List<int>();
                List<int> DV_List_Data11 = new List<int>();
                List<int> DV_List_Data12 = new List<int>();
                List<int> DV_List_Data13 = new List<int>();
                List<int> DV_List_Data14 = new List<int>();
                List<int> DV_List_Data15 = new List<int>();
                List<int> DV_List_Data16 = new List<int>();
                List<int> DV_List_Data17 = new List<int>();
                List<int> DV_List_Data18 = new List<int>();
                List<int> DV_List_Data19 = new List<int>();
                List<int> DV_List_Data20 = new List<int>(); //20191202
                List<int> DV_List_Data21 = new List<int>();
                List<int> DV_List_Data22 = new List<int>();
                List<int> DV_List_Data23 = new List<int>();
                List<int> DV_List_Data24 = new List<int>();
                List<int> DV_List_Data25 = new List<int>();
                List<int> DV_List_Data26 = new List<int>();
                List<int> DV_List_Data27 = new List<int>();
        

                if (_isManualMode)
                {
                    CGlassDataPropertiesWHTM jobData = new CGlassDataPropertiesWHTM();
                    jobData.CassetteIndex = 1;
                    jobData.GlassIndex = 2;
                    jobData.LotID = "A1";
                    jobData.GlassID = "G1";
                    jobData.UnitPathNo = 1;
                    jobData.SlotNo = 0;
                    jobData.JobJudge = "G";//GPR;
                    jobData.JobGrade = "G";
                    jobDataB = CGlassDataPropertiesWHTM.ConvertPLCDataB(jobData);

                    processingTime = _main.ConvertDecTo2WordList(2);
                    startTime = _main.ConvertDecToBCD3WordList(16, 11, 7, 22, 14, 30);
                    endTime = _main.ConvertDecToBCD3WordList(16, 11, 7, 22, 14, 30);
                    variableDataItems = _main.GetDVValueToIntList();
                    recipeId = "ABCDEFG12345";
                }
                else
                {
                    CGlassDataPropertiesWHTM jobData = new CGlassDataPropertiesWHTM();
                    materialData = _main.GetSentOutGlassDataByLoc(_component.ControlName, index);
                    jobData = materialData as CGlassDataPropertiesWHTM;

                    jobData.UnitPathNo = 301;
                    jobData.SlotNo = 0;

                    jobDataB = CGlassDataPropertiesWHTM.ConvertPLCDataB(jobData);

                    TimeSpan elapsedSpan = new TimeSpan(_main.Get_Process_End_Time(index).Ticks - _main.Get_Process_Start_Time(index).Ticks);

                    processingTime.AddRange(ByteArrayToIntArray(PLCDataConverter.SystemFloatToPLC4Byte((float)elapsedSpan.TotalSeconds), 0, 2));// _main.ConvertDecTo2WordList((ushort)elapsedSpan.TotalSeconds);

                    //processingTime =SmartDevice.UTILS.PLCUtils.(_main.MelsecNetWordRead(IW_PPID_RECIPE_ID_MAP_PPID_PPCINFO)).Trim();

                    if (_main.Get_Process_Start_Time(index) != null)
                    {
                        //DateTime yearTemp = DateTime.Parse(glassData.ProcessedStartTime);// DateTime.Now.Year.ToString();

                        string temp = _main.Get_Process_Start_Time(index).Year.ToString();

                        mYear = ushort.Parse(temp.Substring(temp.Length - 2, 2)).ToString("00");
                        mMonth = _main.Get_Process_Start_Time(index).Month.ToString("00");
                        mDay = _main.Get_Process_Start_Time(index).Day.ToString("00");
                        mHour = _main.Get_Process_Start_Time(index).Hour.ToString("00");
                        mMin = _main.Get_Process_Start_Time(index).Minute.ToString("00");
                        mSec = _main.Get_Process_Start_Time(index).Second.ToString("00");
                    }
                    else
                    {
                        mYear = "00";
                        mMonth = "00";
                        mDay = "00";
                        mHour = "00";
                        mMin = "00";
                        mSec = "00";
                    }

                    if (_main.Get_Process_End_Time(index) != null)
                    {
                        //DateTime yearTemp = DateTime.Parse(glassData.ProcessedStartTime);// DateTime.Now.Year.ToString();

                        string temp = _main.Get_Process_End_Time(index).Year.ToString();

                        mYear1 = ushort.Parse(temp.Substring(temp.Length - 2, 2)).ToString("00");
                        mMonth1 = _main.Get_Process_End_Time(index).Month.ToString("00");
                        mDay1 = _main.Get_Process_End_Time(index).Day.ToString("00");
                        mHour1 = _main.Get_Process_End_Time(index).Hour.ToString("00");
                        mMin1 = _main.Get_Process_End_Time(index).Minute.ToString("00");
                        mSec1 = _main.Get_Process_End_Time(index).Second.ToString("00");

                    }
                    else
                    {
                        mYear1 = "00";
                        mMonth1 = "00";
                        mDay1 = "00";
                        mHour1 = "00";
                        mMin1 = "00";
                        mSec1 = "00";
                    }

                    startTime.Add(ushort.Parse(mMonth.Substring(0, 1)) << 12 | ushort.Parse(mMonth.Substring(1, 1)) << 8 | ushort.Parse(mYear.Substring(0, 1)) << 4 | ushort.Parse(mYear.Substring(1, 1)));
                    startTime.Add(ushort.Parse(mHour.Substring(0, 1)) << 12 | ushort.Parse(mHour.Substring(1, 1)) << 8 | ushort.Parse(mDay.Substring(0, 1)) << 4 | ushort.Parse(mDay.Substring(1, 1)));
                    startTime.Add(ushort.Parse(mSec.Substring(0, 1)) << 12 | ushort.Parse(mSec.Substring(1, 1)) << 8 | ushort.Parse(mMin.Substring(0, 1)) << 4 | ushort.Parse(mMin.Substring(1, 1)));

                    endTime.Add(ushort.Parse(mMonth1.Substring(0, 1)) << 12 | ushort.Parse(mMonth1.Substring(1, 1)) << 8 | ushort.Parse(mYear1.Substring(0, 1)) << 4 | ushort.Parse(mYear1.Substring(1, 1)));
                    endTime.Add(ushort.Parse(mHour1.Substring(0, 1)) << 12 | ushort.Parse(mHour1.Substring(1, 1)) << 8 | ushort.Parse(mDay1.Substring(0, 1)) << 4 | ushort.Parse(mDay1.Substring(1, 1)));
                    endTime.Add(ushort.Parse(mSec1.Substring(0, 1)) << 12 | ushort.Parse(mSec1.Substring(1, 1)) << 8 | ushort.Parse(mMin1.Substring(0, 1)) << 4 | ushort.Parse(mMin1.Substring(1, 1)));

                    recipeId = _main.getRecipeId(jobData.PPID);

                    variableDataItems = _main.GetDVValueToIntList();  //임시 데이터

                    string tempValue;

                    //DateTime mTime = DateTime.Now;

                    //Console.WriteLine(mTime.Second.ToString() + "." + mTime.Millisecond.ToString());

                    List<string> DvWords = new List<string>();

                    if (System.IO.File.Exists(@filePath))
                    {
                        string[] lines = System.IO.File.ReadAllLines(@filePath);


                        foreach (string line in lines)
                        {
                            if (line != "")
                            {
                                tempValue = line.Substring(40).Trim();

                                if (tempValue == "***")
                                    tempValue = "";

                                DvWords.Add(tempValue);
                            }
                        }
                    }

                    //if (DvWords.Count != 920)
                    //    return -1;


                    List<string> DvData1 = new List<string>();
                    List<string> DvData2 = new List<string>();
                    List<string> DvData3 = new List<string>();
                    List<string> DvData4 = new List<string>();
                    List<string> DvData5 = new List<string>();
                    List<string> DvData6 = new List<string>();
                    List<string> DvData7 = new List<string>();
                    List<string> DvData8 = new List<string>();
                    List<string> DvData9 = new List<string>();
                    List<string> DvData10 = new List<string>();
                    List<string> DvData11 = new List<string>();
                    List<string> DvData12 = new List<string>();
                    List<string> DvData13 = new List<string>();
                    List<string> DvData14 = new List<string>();
                    List<string> DvData15 = new List<string>();
                    List<string> DvData16 = new List<string>();
                    List<string> DvData17 = new List<string>();
                    List<string> DvData18 = new List<string>();
                    List<string> DvData19 = new List<string>();
                    List<string> DvData20 = new List<string>(); //20191202
                    List<string> DvData21 = new List<string>();
                    List<string> DvData22 = new List<string>();
                    List<string> DvData23 = new List<string>();
                    List<string> DvData24 = new List<string>();
                    List<string> DvData25 = new List<string>();
                    List<string> DvData26 = new List<string>();
                    List<string> DvData27 = new List<string>();


                    //for (int i = 0; i < DvWords.Count; i++)
                    //{
                    //    if (i >= 0 && i < 236)
                    //    {
                    //        DvData1.Add(DvWords[i]);
                    //    }
                    //    else if (i >= 236 && i < 464)
                    //    {
                    //        DvData2.Add(DvWords[i]);
                    //    }
                    //    else if (i >= 464 && i < 730)
                    //    {
                    //        DvData3.Add(DvWords[i]);
                    //    }
                    //    else if (i >= 730 && i < 996)
                    //    {
                    //        DvData4.Add(DvWords[i]);
                    //    }
                    //    else if (i >= 996 && i < 1224)
                    //    {
                    //        DvData5.Add(DvWords[i]);
                    //    }
                    //    else if (i >= 1224 && i < 1490)
                    //    {
                    //        DvData6.Add(DvWords[i]);
                    //    }
                    //    else if (i >= 1490 && i < 1680)
                    //    {
                    //        DvData7.Add(DvWords[i]);
                    //    }
                    //    else if (i >= 1680 && i < 1946)
                    //    {
                    //        DvData8.Add(DvWords[i]);
                    //    }
                    //    else if (i >= 1946 && i < 2174)
                    //    {
                    //        DvData9.Add(DvWords[i]);
                    //    }
                    //    else if (i >= 2174 && i < 2402)
                    //    {
                    //        DvData10.Add(DvWords[i]);
                    //    }
                    //    else if (i >= 2402 && i <= 2592)
                    //    {
                    //        DvData11.Add(DvWords[i]);
                    //    }

                    //}


                    for (int i = 0; i < DvWords.Count; i++) //20191202
                    {
                        if (i >= 0 && i < 238)
                        {
                            DvData1.Add(DvWords[i]);
                        }
                        else if (i >= 238 && i < 488)
                        {
                            DvData2.Add(DvWords[i]);
                        }
                        else if (i >= 488 && i < 738)
                        {
                            DvData3.Add(DvWords[i]);
                        }
                        else if (i >= 738 && i < 988)
                        {
                            DvData4.Add(DvWords[i]);
                        }
                        else if (i >= 998 && i < 1238)
                        {
                            DvData5.Add(DvWords[i]);
                        }
                        else if (i >= 1238 && i < 1488)
                        {
                            DvData6.Add(DvWords[i]);
                        }
                        else if (i >= 1488 && i < 1738)
                        {
                            DvData7.Add(DvWords[i]);
                        }
                        else if (i >= 1738 && i < 1988)
                        {
                            DvData8.Add(DvWords[i]);
                        }
                        else if (i >= 1988 && i < 2238)
                        {
                            DvData9.Add(DvWords[i]);
                        }
                        else if (i >= 2238 && i < 2488)
                        {
                            DvData10.Add(DvWords[i]);
                        }
                        else if (i >= 2488 && i < 2738)
                        {
                            DvData11.Add(DvWords[i]);                           
                        }                    
                        else if (i >= 2488 && i < 2988)
                        {
                            DvData12.Add(DvWords[i]);
                        }
                        else if (i >= 2488 && i < 3238)
                        {
                            DvData13.Add(DvWords[i]);
                        }
                        else if (i >= 2488 && i < 3488)
                        {
                            DvData14.Add(DvWords[i]);
                        }
                        else if (i >= 2488 && i < 3738)
                        {
                            DvData15.Add(DvWords[i]);
                        }
                        else if (i >= 2488 && i < 3988)
                        {
                            DvData16.Add(DvWords[i]);
                        }
                        else if (i >= 2488 && i < 4238)
                        {
                            DvData17.Add(DvWords[i]);
                        }
                        else if (i >= 2488 && i < 4488)
                        {
                            DvData18.Add(DvWords[i]);
                        }
                        else if (i >= 2488 && i < 4738)
                        {
                            DvData19.Add(DvWords[i]);
                        }
                        else if (i >= 2488 && i < 4988)
                        {
                            DvData20.Add(DvWords[i]);
                        }
                        else if (i >= 2488 && i < 5238)
                        {
                            DvData21.Add(DvWords[i]);
                        }
                        else if (i >= 2488 && i < 5488)
                        {
                            DvData22.Add(DvWords[i]);
                        }
                        else if (i >= 2488 && i < 5738)
                        {
                            DvData23.Add(DvWords[i]);
                        }
                        else if (i >= 2488 && i < 5988)
                        {
                            DvData24.Add(DvWords[i]);
                        }
                        else if (i >= 2488 && i < 6238)
                        {
                            DvData25.Add(DvWords[i]);
                        }
                        else if (i >= 2488 && i < 6488)
                        {
                            DvData26.Add(DvWords[i]);
                        }
                        else if (i >= 2488 && i < 6594)
                        {
                            DvData27.Add(DvWords[i]);
                        }

                    }


                    DV_List_Data1 = CGlassDataProperties.ConvertPLC_DV_Data(DvData1, 10, true);
                    DV_List_Data2 = CGlassDataProperties.ConvertPLC_DV_Data(DvData2, 10, false);
                    DV_List_Data3 = CGlassDataProperties.ConvertPLC_DV_Data(DvData3, 10, false);
                    DV_List_Data4 = CGlassDataProperties.ConvertPLC_DV_Data(DvData4, 10, false);
                    DV_List_Data5 = CGlassDataProperties.ConvertPLC_DV_Data(DvData5, 10, false);
                    DV_List_Data6 = CGlassDataProperties.ConvertPLC_DV_Data(DvData6, 10, false);
                    DV_List_Data7 = CGlassDataProperties.ConvertPLC_DV_Data(DvData7, 10, false);
                    DV_List_Data8 = CGlassDataProperties.ConvertPLC_DV_Data(DvData8, 10, false);
                    DV_List_Data9 = CGlassDataProperties.ConvertPLC_DV_Data(DvData9, 10, false);
                    DV_List_Data10 = CGlassDataProperties.ConvertPLC_DV_Data(DvData10, 10, false);
                    DV_List_Data11 = CGlassDataProperties.ConvertPLC_DV_Data(DvData11, 10, false);
                    DV_List_Data12 = CGlassDataProperties.ConvertPLC_DV_Data(DvData12, 10, false);
                    DV_List_Data13 = CGlassDataProperties.ConvertPLC_DV_Data(DvData13, 10, false);
                    DV_List_Data14 = CGlassDataProperties.ConvertPLC_DV_Data(DvData14, 10, false);
                    DV_List_Data15 = CGlassDataProperties.ConvertPLC_DV_Data(DvData15, 10, false);
                    DV_List_Data16 = CGlassDataProperties.ConvertPLC_DV_Data(DvData16, 10, false);
                    DV_List_Data17 = CGlassDataProperties.ConvertPLC_DV_Data(DvData17, 10, false);
                    DV_List_Data18 = CGlassDataProperties.ConvertPLC_DV_Data(DvData18, 10, false);
                    DV_List_Data19 = CGlassDataProperties.ConvertPLC_DV_Data(DvData19, 10, false);
                    DV_List_Data20 = CGlassDataProperties.ConvertPLC_DV_Data(DvData20, 10, false); //20191202
                    DV_List_Data21 = CGlassDataProperties.ConvertPLC_DV_Data(DvData21, 10, false);
                    DV_List_Data22 = CGlassDataProperties.ConvertPLC_DV_Data(DvData22, 10, false);
                    DV_List_Data23 = CGlassDataProperties.ConvertPLC_DV_Data(DvData23, 10, false);
                    DV_List_Data24 = CGlassDataProperties.ConvertPLC_DV_Data(DvData24, 10, false);
                    DV_List_Data25 = CGlassDataProperties.ConvertPLC_DV_Data(DvData25, 10, false);
                    DV_List_Data26 = CGlassDataProperties.ConvertPLC_DV_Data(DvData26, 10, false);
                    DV_List_Data27 = CGlassDataProperties.ConvertPLC_DV_Data(DvData27, 10, false); 

                }

                //if (DV_List_Data6.Count < 1000)
                //{
                //    while (DV_List_Data6.Count == 1000)
                //    {
                //        DV_List_Data6.Add(0);
                //    }
                //}


                


                _main.MelsecNetMultiWordWrite(OW_PROCESS_DATA_REPORT_JOBDATAB, jobDataB);
                _main.MelsecNetMultiWordWrite(OW_PROCESS_DATA_REPORT_LOCAL_PROCESSING_TIME, processingTime);//2word
                _main.MelsecNetMultiWordWrite(OW_PROCESS_DATA_REPORT_LOCAL_PROCESSING_START_TIME, startTime);//3word
                _main.MelsecNetMultiWordWrite(OW_PROCESS_DATA_REPORT_LOCAL_PROCESSING_END_TIME, endTime);//3word
                _main.MelsecNetMultiWordWriteByString(OW_PROCESS_DATA_REPORT_RECIPEID, recipeId, 10, ' ');//10word

                _main.MelsecNetMultiWordWrite(OW_DV_DATA_1, DV_List_Data1);
                _main.MelsecNetMultiWordWrite(OW_DV_DATA_2, DV_List_Data2);
                _main.MelsecNetMultiWordWrite(OW_DV_DATA_3, DV_List_Data3);
                _main.MelsecNetMultiWordWrite(OW_DV_DATA_4, DV_List_Data4);
                _main.MelsecNetMultiWordWrite(OW_DV_DATA_5, DV_List_Data5);
                _main.MelsecNetMultiWordWrite(OW_DV_DATA_6, DV_List_Data6);
                _main.MelsecNetMultiWordWrite(OW_DV_DATA_7, DV_List_Data7);
                _main.MelsecNetMultiWordWrite(OW_DV_DATA_8, DV_List_Data8);
                _main.MelsecNetMultiWordWrite(OW_DV_DATA_9, DV_List_Data9);
                _main.MelsecNetMultiWordWrite(OW_DV_DATA_10, DV_List_Data10);
                _main.MelsecNetMultiWordWrite(OW_DV_DATA_11, DV_List_Data11);
                _main.MelsecNetMultiWordWrite(OW_DV_DATA_12, DV_List_Data12);
                _main.MelsecNetMultiWordWrite(OW_DV_DATA_13, DV_List_Data13);
                _main.MelsecNetMultiWordWrite(OW_DV_DATA_14, DV_List_Data14);
                _main.MelsecNetMultiWordWrite(OW_DV_DATA_15, DV_List_Data15);
                _main.MelsecNetMultiWordWrite(OW_DV_DATA_16, DV_List_Data16);
                _main.MelsecNetMultiWordWrite(OW_DV_DATA_17, DV_List_Data17);
                _main.MelsecNetMultiWordWrite(OW_DV_DATA_18, DV_List_Data18);
                _main.MelsecNetMultiWordWrite(OW_DV_DATA_19, DV_List_Data19);
                _main.MelsecNetMultiWordWrite(OW_DV_DATA_20, DV_List_Data20);
                _main.MelsecNetMultiWordWrite(OW_DV_DATA_21, DV_List_Data21);
                _main.MelsecNetMultiWordWrite(OW_DV_DATA_22, DV_List_Data22);
                _main.MelsecNetMultiWordWrite(OW_DV_DATA_23, DV_List_Data23);
                _main.MelsecNetMultiWordWrite(OW_DV_DATA_24, DV_List_Data24);
                _main.MelsecNetMultiWordWrite(OW_DV_DATA_25, DV_List_Data25);
                _main.MelsecNetMultiWordWrite(OW_DV_DATA_26, DV_List_Data26);
                _main.MelsecNetMultiWordWrite(OW_DV_DATA_27, DV_List_Data27);

                //DateTime mTime1 = DateTime.Now;

                //Console.WriteLine(mTime1.Second.ToString() + "." + mTime1.Millisecond.ToString());

                //main.MelsecNetBitOnOff(OB_PROCESS_DATA_REPORT, true);
                Log(string.Format("{0}\t{1}", _component.ControlName, string.Format("PGM DATA SEND - RECIPEID={0} CCODE={1} ACCOUNT={2}", recipeId, CCODE, account)));



                //CSubject subject = CUIManager.Inst.GetData("ucCimStatus");
                //subject.SetValue("EQPSTATUS", _component.MachineAutoMode);
                //subject.Notify();

                //Thread.Sleep(1000);
                //_main.MelsecNetBitOnOff(OB_PROCESS_DATA_REPORT, false);


                CTimeout timeout = CTimeoutManager.GetTimeout(_controlName, T1);
                timeout.TargetOffValueCheck = true;
                timeout.Begin(OB_PROCESS_DATA_REPORT, _main.CONTROLATTRIBUTES.GetProperty(IB_PROCESS_DATA_REPORT.ControlName, IB_PROCESS_DATA_REPORT.AttributeName) as ITimeoutResource);

                _main.MelsecNetBitOnOff(OB_PROCESS_DATA_REPORT, true);
                //Thread.Sleep(1000);
                //IB_PROCESS_DATA_REPORT.Value = true.ToString();
                string tempMsg = "";
                bool error = false;

                if (CTimeout.WaitSync(timeout, 10))
                {
                }
                else
                {
                    //error = true;
                    _main.MelsecNetBitOnOff(OB_PROCESS_DATA_REPORT, false);
                    //tempMsg = string.Format("PGM DATA TIMEOUT No response [timeout T1={0} sec]", T1 / 1000);
                    //Log(string.Format("{0}\t{1}", _component.ControlName, tempMsg));
                }

                if (!error)
                    return 0;

                Log(string.Format("{0}\t{1}", _component.ControlName, "PGM DATA DISPLAY"));
                CSubject subject = null;
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
            catch (Exception ex)
            {
                Log(string.Format("{0}\t{1}", _component.ControlName, ex.ToString()));

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
