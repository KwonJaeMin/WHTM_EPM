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

    public class RecipeRequestCommand : AProgram

    {
        private CMain _main = null;
        private bool _enable = false;

        //BC
        private CScanControlProperties IB_RECIPE_REQUEST = null;//SD_B_RecipeRequest_BCToL3
        private CScanControlProperties IW_RECIPE_REQUEST_RECIPE_ID = null;//SD_W_RecipeRequest_BCToL3,0
        private CScanControlProperties IW_RECIPE_REQUEST_RECIPE_PARAMS = null;//SD_W_RecipeRequest_BCToL3,1

        private CScanControlProperties VI_RECIPE_REQUEST_REPLY = null;

        //PROBE CIM
        private CPLCControlProperties OB_RECIPE_REQUEST = null;//SD_B_RecipeRequest_BCToL3
        private CPLCControlProperties OW_RECIPE_REQUEST_RECIPE_PARAMS = null;//SD_W_RecipeRequest_BCToL3,1


        private const int MASS_PRODUCTION_MODE1 = 1;         // 1: Mass Production Mode 1
        private const int MASS_PRODUCTION_MODE2 = 2;          // 2: Mass Production Mode 2
        private const int MASS_PRODUCTION_MODE3 = 3;          // 3: Mass Production Mode 3
        private const int MASS_PRODUCTION_MODE4 = 4;          // 4: Mass Production Mode 4
        private const int DUMMY_MODE = 10;                  //10: Dummy Mode
        private const int SORTING_MODE = 11;                //11: Sorting Mode
        private const int SKIP_MODE = 12;                   //12: Skip Mode
        private const int COLD_RUN_MODE_OR_CYCLE_MODE = 13; //13: Cold Run Mode(Cycle Mode)
        private const int FORCE_CLEAN_OUT_MODE =14;         //14: Force Clean Out Mode


        private const int RESULT_COMMAND_OK = 1;
        private const int RESULT_COMMAND_ERROR = 2;

        private string _controlName = "";
        private CProbeControl _component = null;

        public RecipeRequestCommand()
        {
        }

        public override int Init()
        {
            _enable = true;
            
            //BC
            IB_RECIPE_REQUEST = _main.SCANCONTEROLS.GetProperty(_controlName, "IB_RECIPE_REQUEST");
            IW_RECIPE_REQUEST_RECIPE_ID = _main.SCANCONTEROLS.GetProperty(_controlName, "IW_RECIPE_REQUEST_RECIPE_ID");
            IW_RECIPE_REQUEST_RECIPE_PARAMS = _main.SCANCONTEROLS.GetProperty(_controlName, "IW_RECIPE_REQUEST_RECIPE_PARAMS");

            VI_RECIPE_REQUEST_REPLY = _main._YANSYS_SCANCONTEROLS.GetProperty(_controlName, "VI_RECIPE_REQUEST_REPLY");


            //PROBE CIM
            OB_RECIPE_REQUEST = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_RECIPE_REQUEST");
            OW_RECIPE_REQUEST_RECIPE_PARAMS = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_RECIPE_REQUEST_RECIPE_PARAMS");

            this.ProgramDataList.Add(new CProgramData(this.ProgramDataList.Count, "RECIPEID", typeof(string)));

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
            get { return "RECIPE_REQUEST"; }
        }

        public override string Version
        {
            get { return "ver 1.0"; }
        }

        public override string Description
        {
            get { return "BC에서 장비 RECIPE PARAMETERS 요청을 처리하는 프로그램"; }
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
        
        protected override int InnerExecute()
        {
            List<int> Param_Data_List = new List<int>();

            string recipeTemp = "";
            if (IsManualExecute)
            {
                recipeTemp = this.ProgramDataList[0].Value.ToString();
            }
            else
            {
                recipeTemp = _main.MelsecNetMultiWordReadToString(IW_RECIPE_REQUEST_RECIPE_ID);
            }
            Log(string.Format("{0}\t{1}", _component.ControlName, string.Format("PGM DATA RECV - RECIPEID={0}", recipeTemp)));

            string tempMsg = "";

            tempMsg = string.Format("NO REGISTERED RECIPEID={0}", recipeTemp.Trim());
            Log(string.Format("{0}\t{1}", _component.ControlName, "PGM DATA " + tempMsg));

            List<string> dataList = new List<string>();
            dataList.Add("RECIPE_REQUEST");
            dataList.Add(recipeTemp);

            _main.SendData(dataList);


            while (true)
            {
                if (_component.vi_recipe_request_reply)
                {
                    _component.vi_recipe_request_reply = false;
                    break;
                }

                Thread.Sleep(50);
            }

            bool error = true;

            //CRecipeItems recipeItems = new CRecipeItems();

            string[] temp_Parm = VI_RECIPE_REQUEST_REPLY.Value.Split('|');

            //string[] Param_Data = null;

            List<CRecipeDataProperties> tempParameterList = _main.GetRecipeParameterData();


            if (temp_Parm != null && temp_Parm.Length == 3)
            {
                int ParmCount = int.Parse(temp_Parm[1]);

                string[] Parm_Value = temp_Parm[2].Split(',');


                if (ParmCount != Parm_Value.Length)
                    return -1;

                if (ParmCount != 0)
                {
                    for (int i = 0; i < Parm_Value.Length; i++)
                    {        
                        foreach (CRecipeDataProperties item in tempParameterList)
                        {
                            if (item.ParameterNo == (i + 1).ToString())
                            {
                                item.ParameterValue = (Parm_Value[i]);
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

                //if (Parm_Value != null && Parm_Value.Length > 0)
                //{
                //    //recipeItems.FL_GROUP_NUM = Parm_Value[0];
                //    //recipeItems.FR_GROUP_NUM = Parm_Value[1];
                //    //recipeItems.RL_GROUP_NUM = Parm_Value[2];
                //    //recipeItems.RR_GROUP_NUM = Parm_Value[3];
                //    //recipeItems.SUBSITE_NUM = Parm_Value[4];

                //    Param_Data = Parm_Value;
                //}

                Param_Data_List = CRecipeDataProperties.ConvertPLCDataList(tempParameterList);

            }

            //List<int> items = recipeItems.GetIntList(Param_Data);

            _main.MelsecNetMultiWordWrite(OW_RECIPE_REQUEST_RECIPE_PARAMS, Param_Data_List);
            Thread.Sleep(1000);
            _main.MelsecNetBitOnOff(OB_RECIPE_REQUEST, false);

            Log(string.Format("{0}\t{1}", _component.ControlName, string.Format("PGM DATA SEND - {0}", Param_Data_List.ToString())));

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
            public List<int> GetIntList(string[] data)
            {
                List<int> list = new List<int>();

                //list.AddRange(StringToIntWordList(FL_GROUP_NUM, 20, ' '));
                //list.AddRange(StringToIntWordList(FR_GROUP_NUM, 20, ' '));
                //list.AddRange(StringToIntWordList(RL_GROUP_NUM, 20, ' '));
                //list.AddRange(StringToIntWordList(RR_GROUP_NUM, 20, ' '));
                //list.AddRange(StringToIntWordList(SUBSITE_NUM, 20, ' '));

                for (int i = 0; i < data.Length; i++)
                {
                    list.AddRange(StringToIntWordList(data[i], 20, ' '));
                }


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
