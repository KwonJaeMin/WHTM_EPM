using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using SOFD.DataBase;
using SOFD.Logger;

namespace MainLibrary.Property
{
    public enum enumLotState
    {
        Ready,
        Wait,
        Processing,
        End,
        Going,
        None
    }

    public enum enumCEID
    {
        Normal_End,
        Operator_End,
        Abnormal_End,
        Terminated
    }

    public delegate void delegateLotStateChange(object sender, enumLotState lotState);
    public delegate void delegateLotUIChange(object sender);

    public class CLotDataProperties : CPersistenceObject
    {
        public const string CLASS = "CLotDataProperties";
        private static CDBControl _dbControl = null; // 09-22 by JSJ  CLotDataProperties.GetDBControl();

        public event delegateLotStateChange OnLotStateChange;
        public event delegateLotUIChange OnLotUIChanged;

        #region Properties

        private enumLotState _lotState;
        public enumLotState LotState
        {
            get { return _lotState; }
            set
            {
                _lotState = value;

                if (OnLotStateChange != null)
                    OnLotStateChange(this, _lotState);
            }
        }

        public int LotCode
        {
            get;
            set;
        }

        public int SlotCount
        {
            get;
            set;
        }

        public string Attribute
        {
            get;
            set;
        }

        public string ProdType
        {
            get;
            set;
        }

        public string PartNum
        {
            get;
            set;
        }

        public string GLSThick
        {
            get;
            set;
        }

        public string EngCode
        {
            get;
            set;
        }

        public string CSTSize
        {
            get;
            set;
        }

        public string KeyID
        {
            get;
            set;
        }

        public int OutNo
        {
            get;
            set;
        }

        public int InNo
        {
            get;
            set;
        }

        public int InLineCode
        {
            get;
            set;
        }

        public int LSDCount
        {
            get;
            set;
        }

        public string LotJudge
        {
            get;
            set;
        }

        public string PortID
        {
            get;
            set;
        }

        public enumCEID CEID
        {
            get;
            set;
        }

        public string PrcID
        {
            get;
            set;
        }

        public string RCP
        {
            get;
            set;
        }

        public string CSTID
        {
            get;
            set;
        }

        private string _lotID;
        public string LotID
        {
            get { return _lotID; }
            set
            {
                if (_lotID != value)
                {
                    _lotID = value;
                    if (OnLotUIChanged != null)
                        OnLotUIChanged(this);
                }
            }
        }

        //Recipe가 HOST로 부터 받은걸 사용했는지 작업자가 변경하여 사용하였는지 체크. N/F
        //ProdType  을 Online Start / Offline Start로 사용할려고 함. N : Online Start, F : Offline Start
        public string ModeCode
        {
            get;
            set;
        }

        public DateTime LotStartTime
        {
            get;
            set;
        }

        public DateTime DownloadTime
        {
            get;
            set;
        }

        public string LotCommand
        {
            get;
            set;
        }

        public int Permit
        {
            get;
            set;
        }

        public int PortNo
        {
            get;
            set;
        }

        public int PreInNo
        {
            get;
            set;
        }

        public int PreOutNo
        {
            get;
            set;
        }

        public string HostMsg
        {
            get;
            set;
        }

        public int HCACK
        {
            get;
            set;
        }

        private string[] _lsdItem;
        private string[] _lsdValue;

        public void SetLSDItem(int index, string value)
        {
            _lsdItem[index] = value;
        }

        public string GetLSDItem(int index)
        {
            return _lsdItem[index];
        }

        public void SetLSDValue(int index, string value)
        {
            _lsdValue[index] = value;
        }

        public string GetLSDValue(int index)
        {
            return _lsdValue[index];
        }

        #endregion

        public string GetCEID()
        {
            switch (CEID)
            {
                case enumCEID.Abnormal_End:
                    return "A";
                case enumCEID.Normal_End:
                    return "N";
                case enumCEID.Operator_End:
                    return "P";
                case enumCEID.Terminated:
                    return "T";
            }
            return "";
        }

        public string GetLotState()
        {
            switch (LotState)
            {
                case enumLotState.End:
                    return "E";
                case enumLotState.Going:
                    return "G";
                case enumLotState.Processing:
                    return "P";
                case enumLotState.Ready:
                    return "R";
                case enumLotState.Wait:
                    return "W";
                default:
                    return "";
            }
        }

        public CLotDataProperties()
        {

            DbControl = _dbControl;
            _lotState = enumLotState.None;

            _lsdItem = new string[50];
            _lsdValue = new string[50];
        }

        //EPSR Data를 LOT Data Properties에 넣도록 함.
        public CLotDataProperties(object oEPSR)
        {
            DbControl = _dbControl;
            //_lotState = enumLotState.None;

            //_lsdItem = new string[50];
            //_lsdValue = new string[50];
            //EngCode = oEPSR.ENG_CD;
            //PortID = oEPSR.PORT;
            //PortNo = int.Parse(oEPSR.PORT);
            //LotID = oEPSR.LOT;
            //CSTID = oEPSR.CST;
            //PartNum = oEPSR.PROD;
            //PrcID = oEPSR.OPER;
            //RCP = oEPSR.RECIPE;
            //RCP = RCP.Replace("[", "");
            //RCP = RCP.Replace("]", "");
            //GLSThick = oEPSR.GLS_THK;
            //LSDCount = oEPSR.LSD.Count;
            //LotCommand = oEPSR.CMD;
            //LotStartTime = DateTime.Now;
            //LotState = enumLotState.Ready;
            //int iLSDCnt = 0;
            //foreach (LSDInfo oLSDInfo in oEPSR.LSD)
            //{
            //    SetLSDItem(iLSDCnt, oLSDInfo.LSDNAME);
            //    SetLSDValue(iLSDCnt, oLSDInfo.LSDVALUE);
            //}
            //LotStartTime = DateTime.Now;
            //DownloadTime = DateTime.Now;
        }

        private static CDBControl GetDBControl(string dbName)
        {
            if (_dbControl == null)
            {
                _dbControl = new CDBControl();
                _dbControl.DBConnect(dbName);
            }
            return _dbControl;
        }

        public static CLotDataPropertiesCollection LoadAll(string dbName)
        {
            SqlDataReader reader = null;
            CLotDataPropertiesCollection lotDatas = new CLotDataPropertiesCollection();

            try
            {
                using (SqlConnection connection = GetDBControl(dbName).GetOpenConnection())
                {
                    SqlCommand readCommand = connection.CreateCommand();

                    readCommand.CommandText = "SELECT * FROM LOT_DATA";
                    readCommand.Connection = connection;
                    reader = readCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        int intTemp = 0;
                        CLotDataProperties lotData = new CLotDataProperties();
                        lotData.CEID = (enumCEID)Enum.Parse(typeof(enumCEID), (string)reader["ceid"]);
                        lotData.CSTID = (string)reader["cst_id"];
                        lotData.CSTSize = (string)reader["cst_size"];
                        lotData.EngCode = (string)reader["eng_code"];
                        lotData.GLSThick = (string)reader["gls_thick"];
                        lotData.HostMsg = (string)reader["host_msg"];

                        int.TryParse((string)reader["inline_code"], out intTemp);
                        lotData.InLineCode = intTemp;
                        int.TryParse((string)reader["inno"], out intTemp);
                        lotData.InNo = intTemp;
                        int.TryParse((string)reader["outno"], out intTemp);
                        lotData.OutNo = intTemp;

                        lotData.KeyID = (string)reader["keyid"];
                        lotData.LotCommand = (string)reader["lot_command"];
                        lotData.LotID = (string)reader["lot_id"];
                        lotData.LotJudge = (string)reader["lot_judge"];
                        if (!String.IsNullOrEmpty(reader["lot_start_time"].ToString()))
                            lotData.LotStartTime = (DateTime)reader["lot_start_time"];

                        lotData.LotState = (enumLotState)Enum.Parse(typeof(enumLotState), (string)reader["lot_state"]);
                        lotData.ModeCode = (string)reader["mode_code"];
                        
                        lotData.PartNum = (string)reader["part_num"];
                        int.TryParse((string)reader["permit"], out intTemp);
                        lotData.Permit = intTemp;
                        lotData.PortID = (string)reader["port_id"];
                        lotData.PrcID = (string)reader["prc_id"];
                        lotData.ProdType = (string)reader["prod_type"];
                        lotData.RCP = (string)reader["rcp"];
                        int.TryParse((string)reader["slot_count"], out intTemp);
                        lotData.SlotCount = intTemp;

                        int.TryParse((string)reader["lot_code"], out intTemp);
                        lotData.LotCode = intTemp;
                        lotData.DownloadTime = (DateTime)reader["download_time"];

                        // by han - 확인 필요.
                        if (lotData.LotCode != 0)
                            lotDatas.Add(lotData.LotCode, lotData);
                        else
                        {
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "EMP", ex));
            }

            if (reader != null)
                reader.Close();

            return lotDatas;
        }

        public static int LoadLastLOTCodeData(string dbName)
        {
            int iNum = 0;
            SqlDataReader reader = null;
            try
            {
                using (SqlConnection connection = GetDBControl(dbName).GetOpenConnection())
                {
                    SqlCommand readCommand = connection.CreateCommand();
                    readCommand.CommandText = "select * from system_data";
                    readCommand.CommandTimeout = 15;
                    readCommand.Connection = connection;
                    reader = readCommand.ExecuteReader();

                    if (reader.Read())
                    {
                        int intTemp = 0;

                        int.TryParse((string)reader["last_lot_code"], out intTemp);
                        iNum = intTemp;
                    }

                    reader.Close();
                    reader.Dispose();
                }
                return iNum;
            }
            catch (SqlException ex)
            {
                CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "EMP", ex));
            }
            finally
            {
                if (reader != null) reader.Close();
            }

            return 0;
        }

        public static bool SaveLastLOTCodeData(string dbName, int iCode)
        {

            try
            {
                using (SqlConnection connection = GetDBControl(dbName).GetOpenConnection())
                {
                    SqlCommand command = connection.CreateCommand();

                    command.Parameters.Add(new SqlParameter("@last_lot_code", System.Data.SqlDbType.VarChar)).Value = iCode.ToString();

                    command.CommandText = "update system_data set " +
                        "last_lot_code=@last_lot_code";

                    command.Connection = connection;
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (SqlException ex)
            {

                CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "EMP", ex));
            }

            return false;
        }

        public static int LoadLastSerialNoData(string dbName)
        {
            int iNum = 0;
            SqlDataReader reader = null;
            try
            {
                using (SqlConnection connection = GetDBControl(dbName).GetOpenConnection())
                {
                    SqlCommand readCommand = connection.CreateCommand();
                    readCommand.CommandText = "select * from system_data";
                    readCommand.CommandTimeout = 15;
                    readCommand.Connection = connection;
                    reader = readCommand.ExecuteReader();

                    if (reader.Read())
                    {
                        int intTemp = 0;

                        int.TryParse((string)reader["last_serial_no"], out intTemp);
                        iNum = intTemp;
                    }

                    reader.Close();
                    reader.Dispose();
                }
                return iNum;
            }
            catch (SqlException ex)
            {
                CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "EMP", ex));
            }
            finally
            {
                if (reader != null) reader.Close();
            }

            return 0;
        }

        public static bool SaveLastSerialNoData(string dbName, int iNo)
        {

            try
            {
                using (SqlConnection connection = GetDBControl(dbName).GetOpenConnection())
                {
                    SqlCommand command = connection.CreateCommand();

                    command.Parameters.Add(new SqlParameter("@last_serial_no", System.Data.SqlDbType.VarChar)).Value = iNo.ToString();

                    command.CommandText = "update system_data set " +
                        "last_serial_no=@last_serial_no";

                    command.Connection = connection;
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (SqlException ex)
            {

                CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "EMP", ex));
            }

            return false;
        }

        public override bool Add()
        {

            SqlDataReader reader = null;
            try
            {
                using (SqlConnection connection = DbControl.GetOpenConnection())
                {
                    SqlCommand readCommand = connection.CreateCommand();

                    readCommand.Parameters.Add(new SqlParameter("@lot_code", System.Data.SqlDbType.VarChar)).Value = LotCode.ToString();
                    readCommand.CommandText = "select * from lot_data where lot_code=@lot_code";
                    readCommand.Connection = connection;
                    reader = readCommand.ExecuteReader();

                    if (reader.Read())
                    {
                        reader.Close();
                    }
                    else
                    {
                        reader.Close();

                        SqlCommand command = connection.CreateCommand();

                        //신규
                        command.Parameters.Add(new SqlParameter("@ceid", System.Data.SqlDbType.VarChar)).Value = CEID.ToString();
                        command.Parameters.Add(new SqlParameter("@cst_id", System.Data.SqlDbType.VarChar)).Value = CSTID.ToString() + "";
                        command.Parameters.Add(new SqlParameter("@lot_code", System.Data.SqlDbType.VarChar)).Value = LotCode.ToString();


                        command.Parameters.Add(new SqlParameter("@lot_id", System.Data.SqlDbType.VarChar)).Value = LotID == null ? "" : LotID;


                        command.Parameters.Add(new SqlParameter("@cst_size", System.Data.SqlDbType.VarChar)).Value = CSTSize == null ? "" : CSTSize.ToString();
                        command.Parameters.Add(new SqlParameter("@eng_code", System.Data.SqlDbType.VarChar)).Value = EngCode == null ? "" : EngCode;
                        command.Parameters.Add(new SqlParameter("@gls_thick", System.Data.SqlDbType.VarChar)).Value = GLSThick == null ? "" : GLSThick.ToString();


                        command.Parameters.Add(new SqlParameter("@host_msg", System.Data.SqlDbType.VarChar)).Value = HostMsg == null ? "" : HostMsg;
                        command.Parameters.Add(new SqlParameter("@inline_code", System.Data.SqlDbType.VarChar)).Value = InLineCode.ToString() + "";

                        command.Parameters.Add(new SqlParameter("@inno", System.Data.SqlDbType.VarChar)).Value = InNo.ToString();
                        command.Parameters.Add(new SqlParameter("@outno", System.Data.SqlDbType.VarChar)).Value = OutNo.ToString();

                        command.Parameters.Add(new SqlParameter("@keyid", System.Data.SqlDbType.VarChar)).Value = KeyID == null ? "" : KeyID;
                        command.Parameters.Add(new SqlParameter("@lot_command", System.Data.SqlDbType.VarChar)).Value = LotCommand == null ? "" : LotCommand;
                      
                        command.Parameters.Add(new SqlParameter("@lot_judge", System.Data.SqlDbType.VarChar)).Value = LotJudge == null ? "" : LotJudge;
                        command.Parameters.Add(new SqlParameter("@lot_start_time", System.Data.SqlDbType.DateTime)).Value = LotStartTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

                        command.Parameters.Add(new SqlParameter("@lot_state", System.Data.SqlDbType.VarChar)).Value = LotState.ToString();
                        command.Parameters.Add(new SqlParameter("@mode_code", System.Data.SqlDbType.VarChar)).Value = ModeCode == null ? "" : ModeCode;
                        command.Parameters.Add(new SqlParameter("@part_num", System.Data.SqlDbType.VarChar)).Value = PartNum == null ? "" : PartNum;

                        command.Parameters.Add(new SqlParameter("@permit", System.Data.SqlDbType.VarChar)).Value = Permit.ToString();


                        command.Parameters.Add(new SqlParameter("@port_id", System.Data.SqlDbType.VarChar)).Value = PortID == null ? "" : PortID;

                        command.Parameters.Add(new SqlParameter("@prc_id", System.Data.SqlDbType.VarChar)).Value = PrcID == null ? "" : PrcID;
                        command.Parameters.Add(new SqlParameter("@prod_type", System.Data.SqlDbType.VarChar)).Value = ProdType == null ? "" : ProdType;
                        command.Parameters.Add(new SqlParameter("@rcp", System.Data.SqlDbType.VarChar)).Value = RCP == null ? "" : RCP;
                        command.Parameters.Add(new SqlParameter("@slot_count", System.Data.SqlDbType.VarChar)).Value = SlotCount.ToString();



                        command.Parameters.Add(new SqlParameter("@download_time", System.Data.SqlDbType.DateTime)).Value = DownloadTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
                        
                        
                        command.Connection = connection;

                        command.CommandText = "insert into lot_data " +
                            "(lot_code, ceid, cst_id, cst_size, eng_code, gls_thick, host_msg, inline_code, inno, outno, keyid, lot_command, lot_id, lot_judge, lot_state, mode_code, part_num, permit, port_id, prc_id, prod_type, rcp, slot_count, download_time) " +
                            "values (@lot_code, @ceid, @cst_id, @cst_size, @eng_code, @gls_thick, @host_msg, @inline_code, @inno, @outno, @keyid, @lot_command, @lot_id, @lot_judge, @lot_state, @mode_code, @part_num, @permit, @port_id, @prc_id, @prod_type, @rcp, @slot_count, @download_time)";
                        command.ExecuteNonQuery();

                        return true;
                    }
                }
            }
            catch (SqlException ex)
            {
                CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "EMP", ex));
            }
            finally
            {
                if (reader != null) reader.Close();
            }
            return false;
        }
        public override bool Delete()
        {
            try
            {
                using (SqlConnection connection = DbControl.GetOpenConnection())
                {
                    SqlCommand command = connection.CreateCommand();
                    command.Parameters.Add(new SqlParameter("@lot_code", System.Data.SqlDbType.VarChar)).Value = LotCode.ToString();
                    command.CommandText = "delete from lot_data where lot_code=@lot_code";
                    command.Connection = connection;
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (SqlException ex)
            {
                CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "EMP", ex));
            }

            return false;
        }
        public override bool Save()
        {

            try
            {
                using (SqlConnection connection = DbControl.GetOpenConnection())
                {
                    SqlCommand command = connection.CreateCommand();
                    command.Parameters.Add(new SqlParameter("@ceid", System.Data.SqlDbType.VarChar)).Value = CEID.ToString();
                    command.Parameters.Add(new SqlParameter("@cst_id", System.Data.SqlDbType.VarChar)).Value = CSTID.ToString();
                    command.Parameters.Add(new SqlParameter("@lot_code", System.Data.SqlDbType.VarChar)).Value = LotCode.ToString();


                    command.Parameters.Add(new SqlParameter("@lot_id", System.Data.SqlDbType.VarChar)).Value = LotID == null ? "" : LotID;


                    command.Parameters.Add(new SqlParameter("@cst_size", System.Data.SqlDbType.VarChar)).Value = CSTSize == null ? "" : CSTSize.ToString();
                    command.Parameters.Add(new SqlParameter("@eng_code", System.Data.SqlDbType.VarChar)).Value = EngCode == null ? "" : EngCode;
                    command.Parameters.Add(new SqlParameter("@gls_thick", System.Data.SqlDbType.VarChar)).Value = GLSThick == null ? "" : GLSThick.ToString();


                    command.Parameters.Add(new SqlParameter("@host_msg", System.Data.SqlDbType.VarChar)).Value = HostMsg == null ? "" : HostMsg;
                    command.Parameters.Add(new SqlParameter("@inline_code", System.Data.SqlDbType.VarChar)).Value = InLineCode.ToString() + "";

                    command.Parameters.Add(new SqlParameter("@inno", System.Data.SqlDbType.VarChar)).Value = InNo.ToString();
                    command.Parameters.Add(new SqlParameter("@outno", System.Data.SqlDbType.VarChar)).Value = OutNo.ToString();

                    command.Parameters.Add(new SqlParameter("@keyid", System.Data.SqlDbType.VarChar)).Value = KeyID == null ? "" : KeyID;
                    command.Parameters.Add(new SqlParameter("@lot_command", System.Data.SqlDbType.VarChar)).Value = LotCommand == null ? "" : LotCommand;
                  
                    command.Parameters.Add(new SqlParameter("@lot_judge", System.Data.SqlDbType.VarChar)).Value = LotJudge == null ? "" : LotJudge;
                    command.Parameters.Add(new SqlParameter("@lot_start_time", System.Data.SqlDbType.DateTime)).Value = LotStartTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

                    command.Parameters.Add(new SqlParameter("@lot_state", System.Data.SqlDbType.VarChar)).Value = LotState.ToString();
                    command.Parameters.Add(new SqlParameter("@mode_code", System.Data.SqlDbType.VarChar)).Value = ModeCode == null ? "" : ModeCode;
                    command.Parameters.Add(new SqlParameter("@part_num", System.Data.SqlDbType.VarChar)).Value = PartNum == null ? "" : PartNum;

                    command.Parameters.Add(new SqlParameter("@permit", System.Data.SqlDbType.VarChar)).Value = Permit.ToString();


                    command.Parameters.Add(new SqlParameter("@port_id", System.Data.SqlDbType.VarChar)).Value = PortID == null ? "" : PortID;

                    command.Parameters.Add(new SqlParameter("@prc_id", System.Data.SqlDbType.VarChar)).Value = PrcID == null ? "" : PrcID;
                    command.Parameters.Add(new SqlParameter("@prod_type", System.Data.SqlDbType.VarChar)).Value = ProdType == null ? "" : ProdType;
                    command.Parameters.Add(new SqlParameter("@rcp", System.Data.SqlDbType.VarChar)).Value = RCP == null ? "" : RCP;
                    command.Parameters.Add(new SqlParameter("@slot_count", System.Data.SqlDbType.VarChar)).Value = SlotCount.ToString();



                    command.Parameters.Add(new SqlParameter("@download_time", System.Data.SqlDbType.DateTime)).Value = DownloadTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    
                    command.CommandText = "update lot_data set " +
                        "ceid=@ceid, cst_id=@cst_id, cst_size=@cst_size, eng_code=@eng_code, gls_thick=@gls_thick, host_msg=@host_msg, inline_code=@inline_code, inno=@inno, " +
                            "outno=@outno, keyid=@keyid, lot_command=@lot_command, lot_id=@lot_id, lot_judge=@lot_judge, lot_start_time=@lot_start_time, lot_state=@lot_state, mode_code=@mode_code, part_num=part_num, permit=@permit, "+
                            "port_id=@port_id, prc_id=@prc_id, prod_type=@prod_type, rcp=@rcp, slot_count=@slot_count, download_time=@download_time " +
                        "where lot_code=@lot_code";
                    command.Connection = connection;
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (SqlException ex)
            {
                CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "EMP", ex));
            }

            return false;
        }
        public override bool Load()
        {
            SqlDataReader reader = null;
            try
            {
                using (SqlConnection connection = DbControl.GetOpenConnection())
                {
                    SqlCommand readCommand = connection.CreateCommand();
                    readCommand.Parameters.Add("@lot_code", System.Data.SqlDbType.VarChar).Value = LotCode.ToString();
                    readCommand.CommandText = "select * from lot_data where lot_code=@lot_code";
                    readCommand.CommandTimeout = 15;
                    readCommand.Connection = connection;
                    reader = readCommand.ExecuteReader();

                    if (reader.Read())
                    {
                        int intTemp = 0;
                        CEID = (enumCEID)Enum.Parse(typeof(enumCEID),(string)reader["ceid"]);
                        CSTID = (string)reader["cst_id"];
                        CSTSize = (string)reader["cst_size"];
                        EngCode = (string)reader["eng_code"];
                        GLSThick = (string)reader["gls_thick"];
                        HostMsg = (string)reader["host_msg"];
                        int.TryParse((string)reader["inline_code"], out intTemp);
                        InLineCode = intTemp;
                        int.TryParse((string)reader["inno"], out intTemp);
                        InNo = intTemp;
                        int.TryParse((string)reader["outno"], out intTemp);
                        OutNo = intTemp;
                        KeyID = (string)reader["keyid"];
                        LotCommand = (string)reader["lot_command"];
                        LotID = (string)reader["lot_id"];
                        LotJudge = (string)reader["lot_judge"];

                        if (!String.IsNullOrEmpty(reader["lot_start_time"].ToString()))
                            LotStartTime = (DateTime)reader["lot_start_time"];

                        LotState = (enumLotState)Enum.Parse(typeof(enumLotState), (string)reader["lot_state"]);
                        ModeCode = (string)reader["mode_code"];
                        PartNum = (string)reader["part_num"];
                        int.TryParse((string)reader["permit"], out intTemp);
                        Permit = intTemp;
                        PortID = (string)reader["port_id"];
                        PrcID = (string)reader["prc_id"];
                        ProdType = (string)reader["prod_type"];
                        RCP = (string)reader["rcp"];
                        int.TryParse((string)reader["slot_count"], out intTemp);
                        SlotCount = intTemp;

                        int.TryParse((string)reader["lot_code"], out intTemp);
                        LotCode = intTemp;

                        DownloadTime = (DateTime)reader["download_time"];

                    }

                    reader.Close();
                    reader.Dispose();
                }
                return true;
            }
            catch (SqlException ex)
            {
                CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "EMP", ex));
            }
            finally
            {
                if (reader != null) reader.Close();
            }

            return false;
        }
    }

    public class CLotDataPropertiesCollection : Dictionary<int, CLotDataProperties>
    {
        public bool IsExistLOTDataByLOTID(string LOTID)
        {
            foreach (CLotDataProperties oLOT in this.Values)
            {
                if (oLOT.LotID == LOTID)
                {
                    return true;
                }
            }
            return false;
        }

        public CLotDataProperties GetLOTDataByLOTID(string LOTID)
        {
            foreach (CLotDataProperties oLOT in this.Values)
            {
                if (oLOT.LotID == LOTID)
                {
                    return oLOT;
                }
            }
            return null;
        }
    }
}
