using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOFD.Properties;
using SOFD.DataBase;
using System.Data.SqlClient;
using SOFD.Global;

namespace MainLibrary.Property
{


    #region //enum's
    //public enum enumURCondition
    //{
    //    NONE,
    //    RPSC,
    //    FIFO,
    //}
    #endregion
    public class CSystemConfigProperties : CBasicSystemConfigProperties
    {

        #region //member's
        
        #endregion

        #region //propety's

        private static CDBControl _dbControl = null; // 09-22 by JSJ  CSystemConfigProperties.GetDBControl();

        public string EQPID { get; set; }
         public int PortCount { get; set; } // 2013-11-04 포트 그림갯수땜시 추가함.

        public enumTransferType TransferType { get; set; }
        public string Title { get; set; }
        public bool IsDoubleRobot { get; set; }
        public enumSPECIAL_EQP_TYPE SPECIAL_EQP_TYPE { get; set; }
        public bool IsIgnoreLC { get; set; } //CST의 Load Complete 신호 무시할지 여부
        //public string IP_ADDRESS { get; set; }
        public string IsCimOnline { get; set; } // CIM_ONLIE 표현유무
        public string SoftVersion
        {
            get
            {
                return "Ver 1.03(20191105)";
            }
        }

        public string CTTimeOut { get; set; }
        public string DispSiteName { get; set; }
        public string ProjectName { get; set; }

        public int T1_TimeOut { get; set; } //20161031
        public int T2_TimeOut { get; set; }
        public int History_Count { get; set; }
        public bool Upstream_inline_Flag { get; set; }
        public bool Downstream_inline_Flag { get; set; }
        public bool Auto_Recipe_Flag { get; set; }
        public bool Exchange_Use_Flag { get; set; }
        public bool BC_Connect { get; set; }

        public string Saved_Current_PPID { get; set; }
        public string Saved_Current_RecipeID { get; set; }

        public DateTime Sent_Out_Job_Time { get; set; }
        public DateTime Receive_Job_Time { get; set; }

        public bool YANG_Communi { get; set; }

        public Dictionary<int, DateTime> Process_Start_Time = new Dictionary<int, DateTime>();
        public Dictionary<int, DateTime> Process_End_Time = new Dictionary<int, DateTime>();
        //public DateTime Process_Start_Time { get; set; }
        //public DateTime Process_End_Time { get; set; }

        #endregion

        private static CDBControl GetDBControl(string dbName)
        {
            if (_dbControl == null)
            {
                _dbControl = new CDBControl();
                _dbControl.DBConnect(dbName);
            }
            return _dbControl;
        }

        #region //constructor's
        public CSystemConfigProperties()
        {

        }
       
        #endregion

        #region //method's



        public override AProperties SetProperties(Dictionary<string, string> keyValue)
        {
            base.SetProperties(keyValue);
            foreach (string str in keyValue.Keys)
            {
                switch (str)
                {         
                    case "EqpID":
                        EQPID = GetValue<string>("EqpID", ref keyValue);
                        break;
                    case "Title":
                        Title = GetValue<string>("Title", ref keyValue);
                        break;
                    case "DispSiteName":
                        DispSiteName = GetValue<string>("DispSiteName", ref keyValue);
                        break;
                    case "ProjectName":
                        ProjectName = GetValue<string>("ProjectName", ref keyValue);
                        break;
                    case "GLS_TRANSFER_TYPE":
                        if (GetValue<string>("GLS_TRANSFER_TYPE", ref keyValue) == "CST")
                            TransferType = enumTransferType.CST;
                        else if (GetValue<string>("GLS_TRANSFER_TYPE", ref keyValue) == "SCRIBE")
                            TransferType = enumTransferType.SCRIBE;
                        else
                            TransferType = enumTransferType.GLASS;
                        break;
                    case "IS_DOUBLE_ROBOT":
                        IsDoubleRobot = GetValue<string>("IS_DOUBLE_ROBOT", ref keyValue) == "Y" ? true : false;
                        break;

                    case "SPECIAL_TYPE":
                        string TypeData = GetValue<string>("SPECIAL_TYPE", ref keyValue);
                        if (TypeData == "L")
                            SPECIAL_EQP_TYPE = enumSPECIAL_EQP_TYPE.LAMI;
                        else if (TypeData == "F")
                            SPECIAL_EQP_TYPE = enumSPECIAL_EQP_TYPE.FPC;
                        else if (TypeData == "E")
                            SPECIAL_EQP_TYPE = enumSPECIAL_EQP_TYPE.EDGE;
                        else
                            SPECIAL_EQP_TYPE = enumSPECIAL_EQP_TYPE.NORMAL;
                        break;
                    case "PortCount":
                        PortCount = GetValue<int>("PortCount", ref keyValue);
                        break;
                    case "IGNORE_LOADCOMPLETE":
                        IsIgnoreLC = GetValue<string>("IGNORE_LOADCOMPLETE", ref keyValue) == "Y" ? true : false;
                        break;
                    case "CIM_ONLINE":
                        IsCimOnline = GetValue<string>("CIM_ONLINE", ref keyValue);
                        break;
                    case "CT_TIMEOUT":
                        CTTimeOut = GetValue<string>("CT_TIMEOUT", ref keyValue);
                        break;
                }
            }
            return this;
        }
       
        #endregion
    }

    public enum enumTransferType
    {
        GLASS,
        CST,
        SCRIBE,
    }

    public enum enumSPECIAL_EQP_TYPE
    {
        NORMAL,
        LAMI,
        FPC,
        EDGE,
    }
}
