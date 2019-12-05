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
using SmartDevice.UTILS;
using MainLibrary.Property;


namespace YANGSYS.Biz.Programs
{

    public class RecipeChangeReport : AProgram
    {
        private CMain _main = null;
        private bool _enable = false;

        //BC
        private CScanControlProperties IB_RECIPE_CHANGE_REPORT = null;//RV_B_RecipeChangeReport_L3ToBC
        
        //PROBE CIM
        private CPLCControlProperties OB_RECIPE_CHANGE_REPORT = null;//RV_B_RecipeChangeReport_L3ToBC
        private CPLCControlProperties OW_RECIPE_CHANGE_REPORT_RECIPE_ID = null;//RV_W_RecipeChangeReport_L3ToBC.RecipeID
        private CPLCControlProperties OW_RECIPE_CHANGE_REPORT_RECIPE_CCODE = null;//RV_W_RecipeChangeReport_L3ToBC.RecipeCCODE      
        private CPLCControlProperties OW_RECIPE_CHANGE_REPORT_USER_ACCOUNT = null;//RV_W_RecipeChangeReport_L3ToBC.UserAccount
        private CPLCControlProperties OW_RECIPE_CHANGE_REPORT_ITEMS = null;//RV_W_RecipeChangeReport_L3ToBC.RecipeItems

        private CScanControlProperties VI_RECIPE_CHANGE_REPORT = null;
        private CScanControlProperties VI_USER_LOGIN_RECIPE = null;
        private CScanControlProperties VI_RECIPE_REQUEST_REPLY = null;

        //"Each command code corresponds to a unique process operation the machine is capable of performing. 
        private const int CCODE_CRE = 1;  //1: CRE: Create, new recipe was registered.
        private const int CCODE_MOD = 2;  //2: MOD: Modify, (some recipe parameter items’ value or related PPID were modified)
        private const int CCODE_DEL = 3;  //3: DEL: Delete, 
        //private const int CCODE_CHA = 4;  //4: CHA: Change. (Add new parameter items or delete some parameter items)" 사용하지 않음.

        private string _controlName = "";
        private CProbeControl _component = null;

        public RecipeChangeReport()
        {
        }

        public override int Init()
        {
            _enable = true;

            //BC
            IB_RECIPE_CHANGE_REPORT = _main.SCANCONTEROLS.GetProperty(_controlName, "IB_RECIPE_CHANGE_REPORT");
            //PROBE CIM
            OB_RECIPE_CHANGE_REPORT = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_RECIPE_CHANGE_REPORT");
            OW_RECIPE_CHANGE_REPORT_RECIPE_ID = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_RECIPE_CHANGE_REPORT_RECIPE_ID");
            OW_RECIPE_CHANGE_REPORT_RECIPE_CCODE = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_RECIPE_CHANGE_REPORT_RECIPE_CCODE");
            OW_RECIPE_CHANGE_REPORT_USER_ACCOUNT = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_RECIPE_CHANGE_REPORT_USER_ACCOUNT");
            OW_RECIPE_CHANGE_REPORT_ITEMS = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_RECIPE_CHANGE_REPORT_ITEMS");

            VI_RECIPE_CHANGE_REPORT = _main._YANSYS_SCANCONTEROLS.GetProperty(_controlName, "VI_RECIPE_CHANGE_REPORT");
            VI_USER_LOGIN_RECIPE = _main._YANSYS_SCANCONTEROLS.GetProperty(_controlName, "VI_USER_LOGIN_RECIPE");
            VI_RECIPE_REQUEST_REPLY = _main._YANSYS_SCANCONTEROLS.GetProperty(_controlName, "VI_RECIPE_REQUEST_REPLY");

            this.ProgramDataList.Add(new CProgramData(this.ProgramDataList.Count, "RECIPEID", typeof(string)));
            this.ProgramDataList.Add(new CProgramData(this.ProgramDataList.Count, "CCODE", typeof(int)));
            this.ProgramDataList[this.ProgramDataList.Count - 1].Add(1, "Create");
            this.ProgramDataList[this.ProgramDataList.Count - 1].Add(2, "Modify");
            this.ProgramDataList[this.ProgramDataList.Count - 1].Add(3, "Delete");
            //this.ProgramDataList[this.ProgramDataList.Count - 1].Add(4, "Change");

            this.ProgramDataList.Add(new CProgramData(this.ProgramDataList.Count, "ACCOUNT", typeof(int)));
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
            get { return "RECIPE_CHANGE_REPORT"; }
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
            string recipeId = "A10"; //10
            string recipeVersionNo = "";
            int CCODE = CCODE_CRE; // 1
            string account = "ABCDEFGHIJK"; //5

            //List<string> Param_Data = new List<string>();
            List<int> Param_Data_List = new List<int>();

            if (this.IsManualExecute)
            {
                recipeId = this.ProgramDataList[0].Value.ToString();
                CCODE = int.Parse(ProgramDataList[1].Value.ToString());
                account = this.ProgramDataList[2].Value.ToString();
                Log(string.Format("{0}\t{1}", _component.ControlName, string.Format("PGM DATA SEND MANUAL")));
            }
            else
            {
                string value = VI_RECIPE_CHANGE_REPORT.Value;
                string[] temp = value.Split('|');
                int ParmCount = 0;

                if (temp != null && temp.Length == 3)
                {
                    switch (temp[1].Trim())//C,M,D
                    {
                        case "1":
                            CCODE = CCODE_CRE;
                            break;
                        case "2":
                            CCODE = CCODE_MOD;
                            break;
                        case "3":
                            CCODE = CCODE_DEL;
                            break;
                    }

                    string[] data2 = temp[2].Split(',');
                    recipeId = data2[0].Trim();
                    recipeVersionNo = data2[2].Trim();
                    ParmCount = int.Parse(data2[3]);

                    List<CRecipeDataProperties> tempParameterList = _main.GetRecipeParameterData();

                    if (ParmCount != data2.Length - 4)
                        return -1;

                    if (ParmCount != 0)
                    {
                        for (int i = 4; i < data2.Length; i++)
                        {
                            //Param_Data.Add(data2[i]);

                            foreach (CRecipeDataProperties item in tempParameterList)
                            {
                                if (item.ParameterNo == (i - 3).ToString())
                                {
                                    item.ParameterValue = (data2[i]);
                                    break;
                                }
                            }
                        }
                    }

                    if (ParmCount < tempParameterList.Count)
                    {
                        for (int i = ParmCount + 1; i <= tempParameterList.Count; i++)
                        {
                            //Param_Data.Add(data2[i]);

                            foreach (CRecipeDataProperties item in tempParameterList)
                            {
                                if (item.ParameterNo == i.ToString())
                                {
                                    item.ParameterValue = "";
                                    break;
                                }
                            }
                        }
                    }

                    //else if(ParmCount ==0)
                    //{
                    //    for (int i = 0; i < 50; i++)
                    //    {
                    //        Param_Data.Add("0");
                    //    }
                    //}


                    //if (Param_Data.Count < 50)
                    //{
                    //    while (Param_Data.Count < 50)
                    //    {
                    //        Param_Data.Add("0");
                    //    }
                    //}
                    


                    //OW_RECIPE_CHANGE_REPORT_ITEMS.Length

                    Param_Data_List = CRecipeDataProperties.ConvertPLCDataList(tempParameterList);

                }
                else
                {
                    throw new ArgumentException();
                }

                account = _main.SystemConfig.UserAccount;
            }


            

            //List<string> dataList = new List<string>();
            //dataList.Add("RECIPE_REQUEST");
            //dataList.Add(recipeId);

            //_main.SendData(dataList);


            //while (true)
            //{
            //    if (_component.vi_recipe_request_reply)
            //    {
            //        _component.vi_recipe_request_reply = false;
            //        break;
            //    }

            //    Thread.Sleep(50);
            //}

            _main.MelsecNetMultiWordWriteByString(OW_RECIPE_CHANGE_REPORT_RECIPE_ID, recipeId, 10, ' ');
            _main.MelsecNetWordWrite(OW_RECIPE_CHANGE_REPORT_RECIPE_CCODE, CCODE);
            _main.MelsecNetMultiWordWriteByString(OW_RECIPE_CHANGE_REPORT_USER_ACCOUNT, account, 5, ' ');


            CRecipeItems recipeItems = new CRecipeItems();

            //string[] temp_Parm = VI_RECIPE_REQUEST_REPLY.Value.Split('|');

            

            //if (temp_Parm != null && temp_Parm.Length == 3)
            //{
            //    string[] Parm_Value = temp_Parm[2].Split(',');

            //    if (Parm_Value != null && Parm_Value.Length > 0)
            //    {
            //        //recipeItems.FL_GROUP_NUM = Parm_Value[0];
            //        //recipeItems.FR_GROUP_NUM = Parm_Value[1];
            //        //recipeItems.RL_GROUP_NUM = Parm_Value[2];
            //        //recipeItems.RR_GROUP_NUM = Parm_Value[3];
            //        //recipeItems.SUBSITE_NUM = Parm_Value[4];

            //        Param_Data = Parm_Value;
            //    }

            //}

            //List<int> items = recipeItems.GetIntList(Param_Data); //134개

            _main.MelsecNetMultiWordWrite(OW_RECIPE_CHANGE_REPORT_ITEMS, Param_Data_List);

            Log(string.Format("{0}\t{1}", _component.ControlName, string.Format("PGM DATA SEND - RECIPEID={0} CCODE={1} ACCOUNT={2}", recipeId, CCODE, account)));

            Log(string.Format("{0}\t{1}", _component.ControlName, "PGM DATA DISPLAY"));

            CTimeout timeout = CTimeoutManager.GetTimeout(_controlName, T1);
            timeout.TargetOffValueCheck = true;
            timeout.Begin(OB_RECIPE_CHANGE_REPORT, _main.CONTROLATTRIBUTES.GetProperty(IB_RECIPE_CHANGE_REPORT.ControlName, IB_RECIPE_CHANGE_REPORT.AttributeName) as ITimeoutResource);

            _main.MelsecNetBitOnOff(OB_RECIPE_CHANGE_REPORT, true);
            Thread.Sleep(1000);
            IB_RECIPE_CHANGE_REPORT.Value = true.ToString();
            string tempMsg = "";
            bool error = false;
            if (CTimeout.WaitSync(timeout, 10))
            {                
                return 0;
            }
            else
            {
                error = true;
                _main.MelsecNetBitOnOff(OB_RECIPE_CHANGE_REPORT, false);

                tempMsg = string.Format("RECIPE CHANGE TIMEOUT No response [timeout T1={0} sec]", T1 / 1000);
                Log(string.Format("{0}\t{1}", _component.ControlName, "PGM DATA " + tempMsg));
                //tempMsg = string.Format("[{0}] Recipe Change Authorization Failure! No response [timeout T1={1} sec]", account.Trim(), T1 / 1000);
            }

            if (!error)
                return 0;

            Log(string.Format("{0}\t{1}", _component.ControlName, "PGM DATA DISPLAY"));

            #region 메시지 창 표시

            string receivedTime = DateTime.Now.ToString("yyyyMMdd HH:mm:ss");
            string msgId = "0";
            string message = string.Format("[{0}] {1}", this.Name, tempMsg);
            string panelNo = "1";

            CSubject subject = CUIManager.Inst.GetData("CIMMessage");
            subject.SetValue("List", new List<string>() { "MESSAGE_SET", msgId, receivedTime, message, panelNo });
            subject.Notify();

            #endregion

            return 0;
        }
        private class CRecipeItems
        {
            public string FL_GROUP_NUM = "";//	ASCII	20			
            public string FR_GROUP_NUM = "";//ASCII	20			
            public string RL_GROUP_NUM = "";//ASCII	20			
            public string RR_GROUP_NUM = "";//ASCII	20			
            public string SUBSITE_NUM = "";//ASCII	20			


            public CRecipeItems()
            {

            }
            public List<int> GetIntList(List<string> data)
            {
                List<int> list = new List<int>();

                //list.AddRange(StringToIntWordList(FL_GROUP_NUM, 20, ' '));
                //list.AddRange(StringToIntWordList(FR_GROUP_NUM, 20, ' '));
                //list.AddRange(StringToIntWordList(RL_GROUP_NUM, 20, ' '));
                //list.AddRange(StringToIntWordList(RR_GROUP_NUM, 20, ' '));
                //list.AddRange(StringToIntWordList(SUBSITE_NUM, 20, ' '));

                foreach (string item in data)
                {
                    list.AddRange(StringToIntWordList(item, 20, ' '));
                }


                //for (int i = 0; i < data.Length; i++)
                //{
                //    list.AddRange(StringToIntWordList(data[i], 20, ' '));
                //}


                return list;
            }

            private int[] StringToIntWordList(string data, int wordLength, char space)
            {
                List<int> byteArray = new List<int>();
                string temp = data;

                temp = temp.PadRight(wordLength * 2, space);


                char[] charArray = temp.ToCharArray();
                string word = "";
                for (int i = 0; i < charArray.Length; i++)
                {
                    word = string.Format("{1}{0}", charArray[i++], charArray[i]);
                    byteArray.Add(int.Parse(PLCUtils.HexToDec(PLCUtils.StringToHex(word))));
                }

                return byteArray.ToArray();
            }
        }
    }
}
