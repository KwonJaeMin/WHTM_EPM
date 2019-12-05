using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOFD.DataBase;
using System.Data.SqlClient;
using SOFD.Logger;
using SOFD.Component;
using MainLibrary.Utility;

namespace MainLibrary.Property
{
    /// <summary>
    /// 장비에서 Control 하는 제품에 대한 기본을 제공하는 Class로 Framework로 이동 예정
    /// </summary>
    public abstract class AMaterialData : CPersistenceObject
    {
        protected static CDBControl _dbControl = null; // 09-22 by JSJ CGlassDataProperties.GetDBControl();

        public string MatrialID = "";
        public string MatrialCode = "";
        /// <summary>
        /// control name
        /// </summary>
        public string MatrialLocationID = "";
        /// <summary>
        /// slot no, stage no 등등.
        /// </summary>
        public string MatrialSubLocationID = "";
        public string MatrialType = "";

        protected DateTime _createTime = DateTime.Now;
        public DateTime CreateTime
        {
            get { return _createTime; }
        }
        protected DateTime _modifyTime = DateTime.Now;
        public DateTime ModifyTime
        {
            get { return _modifyTime; }
        }

        protected static CDBControl GetDBControl(string dbName)
        {
            if (_dbControl == null)
            {
                _dbControl = new CDBControl();
                _dbControl.DBConnect(dbName);
            }
            return _dbControl;
        }

        public void ChangeLocation(string locationId, string subLocationId)
        {
            MatrialLocationID = locationId;
            MatrialSubLocationID = subLocationId;
        }
        /// <summary>
        /// SubLocationID="0"으로 설정 됨.
        /// </summary>
        /// <param name="locationId">ControlName</param>
        public void ChangeLocation(string locationId)
        {
            this.ChangeLocation(locationId, "0");
        }
    }
    public class CGlassDataPropertiesB7 : AMaterialData
    {
        #region //member's
        public const string CLASS = "CGlassDataPropertiesB7";

        private DateTime _createTime = DateTime.Now;
        private DateTime _modifyTime = DateTime.Now;

        private static CDBControl _dbControl = null; // 09-22 by JSJ CGlassDataPropertiesB7.GetDBControl();
        #endregion

        #region //property's

        //64 Word 영역 순서
        public string LotID { get; set; }
        public string GlassID
        {
            get
            {
                return MatrialID;
            }
            set
            {
                MatrialID = value;
            }
        }
        public string OperID { get; set; }
        //public string GlassCode
        //{
        //    get { return string.Format("{0}{1}", this.GlassCodeLotNo, this.GlassCodeSlotNo); }
        //}
        public int GlassCode { get; set; }      
        public int GlassCodeLotNo { get; set; }
        public int GlassCodeSlotNo { get; set; }
        public int GlassJudgeCode { get; set; }
        public int GlassGradeCode { get; set; }
        public int PPID { get; set; }
        public string ProdID { get; set; }
        public int CIMPCData1 { get; set; }
        public int CIMPCData2 { get; set; }
        public int ProcFlag1 { get; set; }
        public int ProcFlag2 { get; set; }
        public int InspectionJudgeData1 { get; set; }
        public int InspectionJudgeData2 { get; set; }
        //public int JudgeFlag1 { get; set; }
        //public int JudgeFlag2 { get; set; }
        public int SkipFlag1 { get; set; }
        public int SkipFlag2 { get; set; }
        public int InspectionFlag1 { get; set; }
        public int InspectionFlag2 { get; set; }
        public int Mode { get; set; }
        public int GlassType1 { get; set; }
        public int GlassType2 { get; set; }
        public int DummyType { get; set; }
        public int ProcessCount { get; set; }
        public int ReservedData1 { get; set; }
        public int ReservedData2 { get; set; }
        public int ReservedData3 { get; set; }
        public int ReservedData4 { get; set; }
        public int ReservedData5 { get; set; }
        public int ReservedData6 { get; set; }
        public int ReservedData7 { get; set; }
        public int ReservedData8 { get; set; }
        public string ProcessStartTime { get; set; } //20161104
        public string ProcessEndTime { get; set; } //20161104

        public DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }
        public DateTime ModifyTime
        {
            get { return _modifyTime; }
            set { _modifyTime = value; }
        }

        #endregion

        #region //constructor's


        public CGlassDataPropertiesB7(ushort[] glassData)
        {
            DbControl = _dbControl;
            this.GlassDataConvert(glassData);
        }

        public CGlassDataPropertiesB7()
        {
            DbControl = _dbControl;        
        }

        private string GetStringIn(int start, int length, ushort[] glassData)
        {    

            if (glassData == null || glassData.Length <= 0)
                throw new ArgumentNullException();

            if (start + length > glassData.Length)
                throw new ArgumentException();
     

            try
            {
                string temp = "";
                ushort[] target = new ushort[length];
                Array.Copy(glassData, start, target, 0, length);

                for (int i = 0; i < target.Length; i++)
                {
                    char _convertChar00 = Convert.ToChar(Convert.ToInt16(target[i]) & 0xff);
                    char _convertChar01 = Convert.ToChar(((Convert.ToInt16(target[i]) & 0xff00)) >> 8);

                    //char _convertChar00 = Convert.ToChar(Convert.ToInt32(target[i]) & 0xff);    //20161107 OverFlow로 인해서 32로 수정함.
                    //char _convertChar01 = Convert.ToChar(((Convert.ToInt32(target[i]) & 0xff00)) >> 8);


                    temp += (_convertChar00.ToString() + _convertChar01.ToString());
                }
                return temp;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "";
        }

        private void GlassDataConvert(ushort[] glassData)
        {
            try
            {
                if (glassData == null || glassData.Length <= 0)
                    return;

                this.LotID = GetStringIn(0, 10, glassData);
                this.GlassID = GetStringIn(10, 10, glassData);
                this.OperID = GetStringIn(20, 5, glassData);
                this.GlassCodeLotNo = glassData[25];
                this.GlassCodeSlotNo = glassData[26];
                //this.GlassJudgeCode = GetStringIn(32, 1, glassData);
                this.GlassJudgeCode = glassData[27];
                this.GlassGradeCode = glassData[28];
                //this.PPID = glassData[29]; //<TODO> 20 Word를 사용하므로 다음 20Word 건너띔?
                this.PPID = glassData[30]; // 20161114 31 번째 word를 사용함.
                this.ProdID = GetStringIn(49, 10, glassData);
                this.ProcFlag1 = glassData[59];
                this.ProcFlag2 = glassData[60];
                this.InspectionJudgeData1 = glassData[61];
                this.InspectionJudgeData2 = glassData[62];
                //this.JudgeFlag1 = glassData[60];
                //this.JudgeFlag2 = glassData[61];
                this.SkipFlag1 = glassData[63];
                this.SkipFlag2 = glassData[64];
                this.InspectionFlag1 = glassData[65];
                this.InspectionFlag2 = glassData[66];
                this.Mode = glassData[67];
                this.GlassType1 = glassData[68];
                this.GlassType2 = glassData[69];
                this.DummyType = glassData[70];
                this.ProcessCount = glassData[71];
                this.ReservedData1 = glassData[72];
                this.ReservedData2 = glassData[73];
                this.ReservedData3 = glassData[74];
                this.ReservedData4 = glassData[75];
                this.ReservedData5 = glassData[76];
                this.ReservedData6 = glassData[77];
                //this.ReservedData7 = glassData[78];
                //this.ReservedData8 = glassData[79];
            }
            catch (Exception ex)
            {
                                CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, CExceptionLogFormat.DEFAULT_KEY, ex));
            }
        }
        #endregion

        #region //method's
        
        private static CDBControl GetDBControl(string dbName)
        {
            if (_dbControl == null)
            {
                _dbControl = new CDBControl();
                _dbControl.DBConnect(dbName);
            }
            return _dbControl;
        }

        public static CGlassDataPropertiesB7Collection LoadAll(string dbName)
        {
            SqlDataReader reader = null;
            CGlassDataPropertiesB7Collection glassDatas = new CGlassDataPropertiesB7Collection();
            try
            {
                using (SqlConnection connection = GetDBControl(dbName).GetOpenConnection())
                {
                    SqlCommand readCommand = connection.CreateCommand();
                    readCommand.CommandText = "select * from glass_data";
                    readCommand.Connection = connection;
                    reader = readCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        int intTemp = 0;

                        CGlassDataPropertiesB7 glassData = new CGlassDataPropertiesB7();

                        glassData.LotID = (string)reader["lot_id"];
                        glassData.GlassID = (string)reader["glass_id"];
                        glassData.OperID = (string)reader["operid"];

                        int.TryParse((string)reader["glass_code"], out intTemp);
                        glassData.GlassCode = intTemp;

                        int.TryParse((string)reader["glass_code_lotno"], out intTemp);
                        glassData.GlassCodeLotNo = intTemp;

                        int.TryParse((string)reader["glass_code_slotno"], out intTemp);
                        glassData.GlassCodeSlotNo = intTemp;

                        int.TryParse((string)reader["glass_judge_code"], out intTemp);
                        glassData.GlassJudgeCode = intTemp;

                        int.TryParse((string)reader["glass_grade_code"], out intTemp);
                        glassData.GlassGradeCode = intTemp;

                        int.TryParse((string)reader["ppid"], out intTemp);
                        glassData.PPID = intTemp;

                        glassData.ProdID = (string)reader["prodid"];

                        int.TryParse((string)reader["proc_flag1"], out intTemp);
                        glassData.ProcFlag1 = intTemp;
                        int.TryParse((string)reader["proc_flag2"], out intTemp);
                        glassData.ProcFlag2 = intTemp;

                        int.TryParse((string)reader["inspection_judge_data1"], out intTemp);
                        glassData.InspectionJudgeData1 = intTemp;
                        int.TryParse((string)reader["inspection_judge_data2"], out intTemp);
                        glassData.InspectionJudgeData2 = intTemp;

                        int.TryParse((string)reader["skip_flag1"], out intTemp);
                        glassData.SkipFlag1 = intTemp;
                        int.TryParse((string)reader["skip_flag2"], out intTemp);
                        glassData.SkipFlag2 = intTemp;

                        int.TryParse((string)reader["inspection_flag1"], out intTemp);
                        glassData.InspectionFlag1 = intTemp;
                        int.TryParse((string)reader["inspection_flag2"], out intTemp);
                        glassData.InspectionFlag2 = intTemp;

                        int.TryParse((string)reader["mode"], out intTemp);
                        glassData.Mode = intTemp;

                        int.TryParse((string)reader["glass_type1"], out intTemp);
                        glassData.GlassType1 = intTemp;
                        int.TryParse((string)reader["glass_type2"], out intTemp);
                        glassData.GlassType2 = intTemp;

                        int.TryParse((string)reader["dummy_type"], out intTemp);
                        glassData.DummyType = intTemp;

                        int.TryParse((string)reader["processing_count"], out intTemp);
                        glassData.ProcessCount = intTemp;

                        int.TryParse((string)reader["reserved_data1"], out intTemp);
                        glassData.ReservedData1 = intTemp;
                        int.TryParse((string)reader["reserved_data2"], out intTemp);
                        glassData.ReservedData2 = intTemp;
                        int.TryParse((string)reader["reserved_data3"], out intTemp);
                        glassData.ReservedData3 = intTemp;
                        int.TryParse((string)reader["reserved_data4"], out intTemp);
                        glassData.ReservedData4 = intTemp;
                        int.TryParse((string)reader["reserved_data5"], out intTemp);
                        glassData.ReservedData5 = intTemp;
                        int.TryParse((string)reader["reserved_data6"], out intTemp);
                        glassData.ReservedData6 = intTemp;

                        if (glassDatas.ContainsKey(glassData.GlassCode) == false)
                            glassDatas.Add(glassData.GlassCode, glassData);
                    }
                }
            }
            catch (SqlException ex)
            {
                CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "EPM", ex));
                //Console.WriteLine(ex.Message);
                //if (OnLogEvent != null)
                //    OnLogEvent(new CRecipeLogData(SOFD.Logger.Catagory.Error, METHOD, "sql error \n" + ex.StackTrace));
            }

            if (reader != null)
                reader.Close();

            return glassDatas;
        }

        public override bool Add()
        {

            SqlDataReader reader = null;
            try
            {
                using (SqlConnection connection = DbControl.GetOpenConnection())
                {
                    SqlCommand readCommand = connection.CreateCommand();

                    readCommand.Parameters.Add(new SqlParameter("@glass_code", System.Data.SqlDbType.Int)).Value = GlassCode;
                    readCommand.CommandText = "select * from glass_data where glass_code=@glass_code";
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
                        command.Parameters.Add(new SqlParameter("@lot_id", System.Data.SqlDbType.NVarChar)).Value = LotID == null ? "" : LotID;
                        command.Parameters.Add(new SqlParameter("@glass_id", System.Data.SqlDbType.NVarChar)).Value = GlassID == null ? "" : GlassID;
                        command.Parameters.Add(new SqlParameter("@operid", System.Data.SqlDbType.NVarChar)).Value = OperID == null ? "" : OperID;

                        command.Parameters.Add(new SqlParameter("@glass_code", System.Data.SqlDbType.Int)).Value = GlassCode == null ? 0 : GlassCode;
                        command.Parameters.Add(new SqlParameter("@glass_code_lotno", System.Data.SqlDbType.Int)).Value = GlassCodeLotNo == null ? 0 : GlassCodeLotNo;
                        command.Parameters.Add(new SqlParameter("@glass_code_slotno", System.Data.SqlDbType.Int)).Value = GlassCodeSlotNo == null ? 0 : GlassCodeSlotNo;
                        command.Parameters.Add(new SqlParameter("@glass_judge_code", System.Data.SqlDbType.Int)).Value = GlassJudgeCode == null ? 0 : GlassJudgeCode;
                        command.Parameters.Add(new SqlParameter("@glass_grade_code", System.Data.SqlDbType.Int)).Value = GlassGradeCode == null ? 0 : GlassGradeCode;
                        command.Parameters.Add(new SqlParameter("@ppid", System.Data.SqlDbType.Int)).Value = PPID == null ? 0 : PPID;

                        command.Parameters.Add(new SqlParameter("@prodid", System.Data.SqlDbType.NVarChar)).Value = ProdID == null ? "" : ProdID;

                        command.Parameters.Add(new SqlParameter("@proc_flag1", System.Data.SqlDbType.Int)).Value = ProcFlag1 == null ? 0 : ProcFlag1;
                        command.Parameters.Add(new SqlParameter("@proc_flag2", System.Data.SqlDbType.Int)).Value = ProcFlag2 == null ? 0 : ProcFlag2;
                        command.Parameters.Add(new SqlParameter("@inspection_judge_data1", System.Data.SqlDbType.Int)).Value = InspectionJudgeData1 == null ? 0 : InspectionJudgeData1;
                        command.Parameters.Add(new SqlParameter("@inspection_judge_data2", System.Data.SqlDbType.Int)).Value = InspectionJudgeData2 == null ? 0 : InspectionJudgeData2;
                        command.Parameters.Add(new SqlParameter("@skip_flag1", System.Data.SqlDbType.Int)).Value = SkipFlag1 == null ? 0 : SkipFlag1;
                        command.Parameters.Add(new SqlParameter("@skip_flag2", System.Data.SqlDbType.Int)).Value = SkipFlag2 == null ? 0 : SkipFlag2;
                        command.Parameters.Add(new SqlParameter("@inspection_flag1", System.Data.SqlDbType.Int)).Value = InspectionFlag1 == null ? 0 : InspectionFlag1;
                        command.Parameters.Add(new SqlParameter("@inspection_flag2", System.Data.SqlDbType.Int)).Value = InspectionFlag2 == null ? 0 : InspectionFlag2;

                        command.Parameters.Add(new SqlParameter("@mode", System.Data.SqlDbType.Int)).Value = Mode == null ? 0 : Mode;

                        command.Parameters.Add(new SqlParameter("@glass_type1", System.Data.SqlDbType.Int)).Value = GlassType1 == null ? 0 : GlassType1;
                        command.Parameters.Add(new SqlParameter("@glass_type2", System.Data.SqlDbType.Int)).Value = GlassType2 == null ? 0 : GlassType2;

                        command.Parameters.Add(new SqlParameter("@dummy_type", System.Data.SqlDbType.Int)).Value = DummyType == null ? 0 : DummyType;
                        command.Parameters.Add(new SqlParameter("@processing_count", System.Data.SqlDbType.Int)).Value = ProcessCount == null ? 0 : ProcessCount;

                        command.Parameters.Add(new SqlParameter("@reserved_data1", System.Data.SqlDbType.Int)).Value = ReservedData1 == null ? 0 : ReservedData1;
                        command.Parameters.Add(new SqlParameter("@reserved_data2", System.Data.SqlDbType.Int)).Value = ReservedData2 == null ? 0 : ReservedData2;
                        command.Parameters.Add(new SqlParameter("@reserved_data3", System.Data.SqlDbType.Int)).Value = ReservedData3 == null ? 0 : ReservedData3;
                        command.Parameters.Add(new SqlParameter("@reserved_data4", System.Data.SqlDbType.Int)).Value = ReservedData4 == null ? 0 : ReservedData4;
                        command.Parameters.Add(new SqlParameter("@reserved_data5", System.Data.SqlDbType.Int)).Value = ReservedData5 == null ? 0 : ReservedData5;
                        command.Parameters.Add(new SqlParameter("@reserved_data6", System.Data.SqlDbType.Int)).Value = ReservedData6 == null ? 0 : ReservedData6;

                      
                        command.Connection = connection;
                        command.CommandText = "insert into glass_data " +
                            "(lot_id, glass_id, operid, glass_code, glass_code_lotno, glass_code_slotno, glass_judge_code, glass_grade_code, ppid, prodid, proc_flag1, proc_flag2, inspection_judge_data1, inspection_judge_data2, skip_flag1, skip_flag2, inspection_flag1, inspection_flag2, mode, glass_type1, glass_type2, dummy_type, processing_count, reserved_data1, reserved_data2, reserved_data3, reserved_data4, reserved_data5, reserved_data6) " +
                            "values (@lot_id, @glass_id, @operid, @glass_code, @glass_code_lotno, @glass_code_slotno, @glass_judge_code, @glass_grade_code, @ppid, @prodid, @proc_flag1, @proc_flag2, @inspection_judge_data1, @inspection_judge_data2, @skip_flag1, @skip_flag2, @inspection_flag1, @inspection_flag2, @glass_type1, @glass_type2, @dummy_type, @processing_count, @reserved_data1, @reserved_data2, @reserved_data3, @reserved_data4, @reserved_data5, @reserved_data6)";
                        command.ExecuteNonQuery();

                        return true;
                    }
                }
            }
            catch (SqlException ex)
            {
                CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "EPM", ex));
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
                    command.Parameters.Add(new SqlParameter("@glass_code", System.Data.SqlDbType.Int)).Value = GlassCode;
                    command.CommandText = "delete from glass_data where glass_code=@glass_code";
                    command.Connection = connection;
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (SqlException ex)
            {
                CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "EPM", ex));
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

                    command.Parameters.Add(new SqlParameter("@lot_id", System.Data.SqlDbType.NVarChar)).Value = LotID == null ? "" : LotID;
                    command.Parameters.Add(new SqlParameter("@glass_id", System.Data.SqlDbType.NVarChar)).Value = GlassID == null ? "" : GlassID;
                    command.Parameters.Add(new SqlParameter("@operid", System.Data.SqlDbType.NVarChar)).Value = OperID == null ? "" : OperID;

                    command.Parameters.Add(new SqlParameter("@glass_code", System.Data.SqlDbType.Int)).Value = GlassCode == null ? 0 : GlassCode;
                    command.Parameters.Add(new SqlParameter("@glass_code_lotno", System.Data.SqlDbType.Int)).Value = GlassCodeLotNo == null ? 0 : GlassCodeLotNo;
                    command.Parameters.Add(new SqlParameter("@glass_code_slotno", System.Data.SqlDbType.Int)).Value = GlassCodeSlotNo == null ? 0 : GlassCodeSlotNo;
                    command.Parameters.Add(new SqlParameter("@glass_judge_code", System.Data.SqlDbType.Int)).Value = GlassJudgeCode == null ? 0 : GlassJudgeCode;
                    command.Parameters.Add(new SqlParameter("@glass_grade_code", System.Data.SqlDbType.Int)).Value = GlassGradeCode == null ? 0 : GlassGradeCode;
                    command.Parameters.Add(new SqlParameter("@ppid", System.Data.SqlDbType.Int)).Value = PPID == null ? 0 : PPID;

                    command.Parameters.Add(new SqlParameter("@prodid", System.Data.SqlDbType.NVarChar)).Value = ProdID == null ? "" : ProdID;

                    command.Parameters.Add(new SqlParameter("@proc_flag1", System.Data.SqlDbType.Int)).Value = ProcFlag1 == null ? 0 : ProcFlag1;
                    command.Parameters.Add(new SqlParameter("@proc_flag2", System.Data.SqlDbType.Int)).Value = ProcFlag2 == null ? 0 : ProcFlag2;
                    command.Parameters.Add(new SqlParameter("@inspection_judge_data1", System.Data.SqlDbType.Int)).Value = InspectionJudgeData1 == null ? 0 : InspectionJudgeData1;
                    command.Parameters.Add(new SqlParameter("@inspection_judge_data2", System.Data.SqlDbType.Int)).Value = InspectionJudgeData2 == null ? 0 : InspectionJudgeData2;
                    command.Parameters.Add(new SqlParameter("@skip_flag1", System.Data.SqlDbType.Int)).Value = SkipFlag1 == null ? 0 : SkipFlag1;
                    command.Parameters.Add(new SqlParameter("@skip_flag2", System.Data.SqlDbType.Int)).Value = SkipFlag2 == null ? 0 : SkipFlag2;
                    command.Parameters.Add(new SqlParameter("@inspection_flag1", System.Data.SqlDbType.Int)).Value = InspectionFlag1 == null ? 0 : InspectionFlag1;
                    command.Parameters.Add(new SqlParameter("@inspection_flag2", System.Data.SqlDbType.Int)).Value = InspectionFlag2 == null ? 0 : InspectionFlag2;

                    command.Parameters.Add(new SqlParameter("@mode", System.Data.SqlDbType.Int)).Value = Mode == null ? 0 : Mode;

                    command.Parameters.Add(new SqlParameter("@glass_type1", System.Data.SqlDbType.Int)).Value = GlassType1 == null ? 0 : GlassType1;
                    command.Parameters.Add(new SqlParameter("@glass_type2", System.Data.SqlDbType.Int)).Value = GlassType2 == null ? 0 : GlassType2;

                    command.Parameters.Add(new SqlParameter("@dummy_type", System.Data.SqlDbType.Int)).Value = DummyType == null ? 0 : DummyType;
                    command.Parameters.Add(new SqlParameter("@processing_count", System.Data.SqlDbType.Int)).Value = ProcessCount == null ? 0 : ProcessCount;

                    command.Parameters.Add(new SqlParameter("@reserved_data1", System.Data.SqlDbType.Int)).Value = ReservedData1 == null ? 0 : ReservedData1;
                    command.Parameters.Add(new SqlParameter("@reserved_data2", System.Data.SqlDbType.Int)).Value = ReservedData2 == null ? 0 : ReservedData2;
                    command.Parameters.Add(new SqlParameter("@reserved_data3", System.Data.SqlDbType.Int)).Value = ReservedData3 == null ? 0 : ReservedData3;
                    command.Parameters.Add(new SqlParameter("@reserved_data4", System.Data.SqlDbType.Int)).Value = ReservedData4 == null ? 0 : ReservedData4;
                    command.Parameters.Add(new SqlParameter("@reserved_data5", System.Data.SqlDbType.Int)).Value = ReservedData5 == null ? 0 : ReservedData5;
                    command.Parameters.Add(new SqlParameter("@reserved_data6", System.Data.SqlDbType.Int)).Value = ReservedData6 == null ? 0 : ReservedData6;
                    command.CommandText = "update glass_data set " +
                        "lot_id=@lot_id, glass_id=@glass_id, operid=@operid, glass_code=@glass_code, glass_code_lotno=@glass_code_lotno, glass_code_slotno=@glass_code_slotno, glass_judge_code=@glass_judge_code, glass_grade_code=@glass_grade_code, " +
                        "ppid=@ppid, prodid=@prodid, proc_flag1=@proc_flag1, proc_flag2=@proc_flag2, inspection_judge_data1=@inspection_judge_data1, " +
                        "inspection_judge_data2=@inspection_judge_data2, skip_flag1=@skip_flag1, skip_flag2=@skip_flag2, inspection_flag1=@inspection_flag1, " +
                        "inspection_flag2=@inspection_flag2, mode=@mode,  glass_type1=@glass_type1, glass_type2=@glass_type2, " +
                        "dummy_type=@dummy_type, processing_count=@processing_count, reserved_data1=@reserved_data1, reserved_data2=@reserved_data2, reserved_data3=@reserved_data3, reserved_data4=@reserved_data4, " +
                        "reserved_data5=@reserved_data5, reserved_data6=@reserved_data6 " +
                        "where glass_code=@glass_code";
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
                    readCommand.Parameters.Add("@glass_code", System.Data.SqlDbType.Int).Value = GlassCode;
                    readCommand.CommandText = "select * from glass_data where glass_code=@glass_code";
                    readCommand.CommandTimeout = 15;
                    readCommand.Connection = connection;
                    reader = readCommand.ExecuteReader();

                    if (reader.Read())
                    {
                        int intTemp = 0;
                  
                        LotID = (string)reader["lot_id"];
                        GlassID = (string)reader["glass_id"];
                        OperID = (string)reader["operid"];

                        int.TryParse((string)reader["glass_code"], out intTemp);
                        GlassCode = intTemp;

                        int.TryParse((string)reader["glass_code_lotno"], out intTemp);
                        GlassCodeLotNo = intTemp;

                        int.TryParse((string)reader["glass_code_slotno"], out intTemp);
                        GlassCodeSlotNo = intTemp;

                        int.TryParse((string)reader["glass_judge_code"], out intTemp);
                        GlassJudgeCode = intTemp;

                        int.TryParse((string)reader["glass_grade_code"], out intTemp);
                        GlassGradeCode = intTemp;

                        int.TryParse((string)reader["ppid"], out intTemp);
                        PPID = intTemp;

                        ProdID = (string)reader["prodid"];

                        int.TryParse((string)reader["proc_flag1"], out intTemp);
                        ProcFlag1 = intTemp;
                        int.TryParse((string)reader["proc_flag2"], out intTemp);
                        ProcFlag2 = intTemp;

                        int.TryParse((string)reader["inspection_judge_data1"], out intTemp);
                        InspectionJudgeData1 = intTemp;
                        int.TryParse((string)reader["inspection_judge_data2"], out intTemp);
                        InspectionJudgeData2 = intTemp;

                        int.TryParse((string)reader["skip_flag1"], out intTemp);
                        SkipFlag1 = intTemp;
                        int.TryParse((string)reader["skip_flag2"], out intTemp);
                        SkipFlag2 = intTemp;

                        int.TryParse((string)reader["inspection_flag1"], out intTemp);
                        InspectionFlag1 = intTemp;
                        int.TryParse((string)reader["inspection_flag2"], out intTemp);
                        InspectionFlag2 = intTemp;

                        int.TryParse((string)reader["mode"], out intTemp);
                        Mode = intTemp;

                        int.TryParse((string)reader["glass_type1"], out intTemp);
                        GlassType1 = intTemp;
                        int.TryParse((string)reader["glass_type2"], out intTemp);
                        GlassType2 = intTemp;

                        int.TryParse((string)reader["dummy_type"], out intTemp);
                        DummyType = intTemp;

                        int.TryParse((string)reader["processing_count"], out intTemp);
                        ProcessCount = intTemp;

                        int.TryParse((string)reader["reserved_data1"], out intTemp);
                        ReservedData1 = intTemp;
                        int.TryParse((string)reader["reserved_data2"], out intTemp);
                        ReservedData2 = intTemp;
                        int.TryParse((string)reader["reserved_data3"], out intTemp);
                        ReservedData3 = intTemp;
                        int.TryParse((string)reader["reserved_data4"], out intTemp);
                        ReservedData4 = intTemp;
                        int.TryParse((string)reader["reserved_data5"], out intTemp);
                        ReservedData5 = intTemp;
                        int.TryParse((string)reader["reserved_data6"], out intTemp);
                        ReservedData6 = intTemp;

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


        //public static CGlassDataPropertiesB7Collection LoadAll(string dbName)
        //{
        //    SqlDataReader reader = null;
        //    CGlassDataPropertiesB7Collection glassDatas = new CGlassDataPropertiesB7Collection();
        //    try
        //    {
        //        using (SqlConnection connection = GetDBControl(dbName).GetOpenConnection())
        //        {
        //            SqlCommand readCommand = connection.CreateCommand();
        //            readCommand.CommandText = "select * from glass_data";
        //            readCommand.Connection = connection;
        //            reader = readCommand.ExecuteReader();

        //            while (reader.Read())
        //            {
        //                int intTemp = 0;

        //                CGlassDataPropertiesB7 glassData = new CGlassDataPropertiesB7();
        //                //신규 데이터.
        //                glassData.EQPRecipeNumber = (string)reader["eqp_recipe_number"];    
                    
                        
        //                int.TryParse((string)reader["glass_judge_code"], out intTemp);
        //                glassData.GlassJudgeCode = intTemp;

        //                int.TryParse((string)reader["lot_code"], out intTemp);
        //                glassData.LOTCode = intTemp;


        //                glassData.LotID = (string)reader["lot_id"];
        //                glassData.ProcessingCode = (string)reader["processing_code"];
        //                glassData.LotSpecificData = (string)reader["lot_specific_data"];
                        
        //                int.TryParse((string)reader["host_recipe_number"], out intTemp);
        //                glassData.HostRecipeNumber = intTemp;

        //                glassData.GlassType = (string)reader["glass_type"];
        //                int.TryParse((string)reader["glass_code"], out intTemp);
        //                glassData.GlassCode = intTemp;
        //                glassData.GlassID = (string)reader["glass_id"];
        //                glassData.GlassJudge = (string)reader["glass_judge"];
        //                glassData.GlassSpecificData = (string)reader["glass_specific_data"];
        //                glassData.GlassAddData = (string)reader["glass_add_data"];
        //                //glassData.GlassVariety = (enumGlassVariety)Enum.Parse(typeof(enumGlassVariety), (string)reader["glass_variety"]);

        //                glassData.GlassProcessingStatus = (string)reader["glass_processing_status"];
        //                glassData.OriginalCassetteID = (string)reader["original_cassette_id"];
        //                int.TryParse((string)reader["glass_route_path"], out intTemp);
        //                glassData.GlassRoutePath = intTemp;
        //                glassData.GlassCurrentLocation = (string)reader["glass_current_loc"];

        //                glassData.PreviousUnitProcessingData = (string)reader["prev_unit_processing_data"];

        //                glassData.CurrentLocation = (string)reader["current_loc"];

        //                glassData.CreateTime = (DateTime)reader["create_time"];
        //                glassData.ModifyTime = (DateTime)reader["modify_time"];

        //                glassData.MainPNLIF = (string)reader["main_pnl_if"];
        //                glassData.SubPNLIF = (string)reader["sub_pnl_if"];
        //                glassData.OriginalPortID = (string)reader["original_port_id"];
        //                glassData.OriginalSlotID = (string)reader["original_slot_id"];
        //                glassData.SampleCode = (string)reader["sample_code"];
        //                glassData.STRING_GSD = (string)reader["string_gsd"];

        //                glassData.IsProcessed = (string)reader["is_processed"] == "TRUE" ? true : false;
        //                glassData.IsScraped = (string)reader["is_scraped"] == "TRUE" ? true : false;

        //                try
        //                {
        //                    glassData.MAIN_GLASS_TYPE = (string)reader["main_glass_type"];
        //                    glassData.SUB_GLASS_TYPE = (string)reader["sub_glass_type"];
        //                    glassData.IsCIMGenerateData = (string)reader["is_cim_generate_data"] == "TRUE" ? true : false;
        //                    glassData.CurrentCSTID = (string)reader["current_cst_id"];
        //                }
        //                catch { }
                        
        //                if (glassDatas.ContainsKey(glassData.GlassCode) == false)
        //                    glassDatas.Add(glassData.GlassCode, glassData);

        //                //로그 남겨야하는디
        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "EMP", ex));
        //        //Console.WriteLine(ex.Message);
        //        //if (OnLogEvent != null)
        //        //    OnLogEvent(new CRecipeLogData(SOFD.Logger.Catagory.Error, METHOD, "sql error \n" + ex.StackTrace));
        //    }

        //    if (reader != null)
        //        reader.Close();

        //    return glassDatas;
        //}
        //public static int LoadLastGlassCodeData(string dbName)
        //{
        //    int iNum = 0;
        //    SqlDataReader reader = null;
        //    try
        //    {
        //        using (SqlConnection connection = GetDBControl(dbName).GetOpenConnection())
        //        {
        //            SqlCommand readCommand = connection.CreateCommand();                    
        //            readCommand.CommandText = "select * from system_data";
        //            readCommand.CommandTimeout = 15;
        //            readCommand.Connection = connection;
        //            reader = readCommand.ExecuteReader();

        //            if (reader.Read())
        //            {
        //                int intTemp = 0;

        //                int.TryParse((string)reader["last_glass_code"], out intTemp);
        //                iNum = intTemp;                       
        //            }

        //            reader.Close();
        //            reader.Dispose();
        //        }
        //        return iNum;
        //    }
        //    catch (SqlException ex)
        //    {
        //        CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "EMP", ex));
        //    }
        //    finally
        //    {
        //        if (reader != null) reader.Close();
        //    }

        //    return 0;
        //}
        //public static bool SaveLastGlassCodeData(string dbName, int iCode)
        //{

        //    try
        //    {
        //        using (SqlConnection connection = GetDBControl(dbName).GetOpenConnection())
        //        {
        //            SqlCommand command = connection.CreateCommand();

        //            command.Parameters.Add(new SqlParameter("@last_glass_code", System.Data.SqlDbType.VarChar)).Value = iCode.ToString();

        //            command.CommandText = "update system_data set " +
        //                "last_glass_code=@last_glass_code";
                        
        //            command.Connection = connection;
        //            command.ExecuteNonQuery();
        //        }
        //        return true;
        //    }
        //    catch (SqlException ex)
        //    {

        //        CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "EMP", ex));
        //    }

        //    return false;
        //}        
        //public override bool Add()
        //{

        //    SqlDataReader reader = null;
        //    try
        //    {
        //        using (SqlConnection connection = DbControl.GetOpenConnection())
        //        {
        //            SqlCommand readCommand = connection.CreateCommand();

        //            readCommand.Parameters.Add(new SqlParameter("@glass_code", System.Data.SqlDbType.VarChar)).Value = GlassCode.ToString();
        //            readCommand.CommandText = "select * from glass_data where glass_code=@glass_code";
        //            readCommand.Connection = connection;
        //            reader = readCommand.ExecuteReader();

        //            if (reader.Read())
        //            {
        //                reader.Close();
        //            }
        //            else
        //            {
        //                reader.Close();

        //                SqlCommand command = connection.CreateCommand();

        //                //신규
        //                command.Parameters.Add(new SqlParameter("@eqp_recipe_number", System.Data.SqlDbType.VarChar)).Value = EQPRecipeNumber + "";
        //                command.Parameters.Add(new SqlParameter("@glass_judge_code", System.Data.SqlDbType.VarChar)).Value = GlassJudgeCode.ToString();
        //                command.Parameters.Add(new SqlParameter("@lot_code", System.Data.SqlDbType.VarChar)).Value = LOTCode.ToString();


        //                command.Parameters.Add(new SqlParameter("@lot_id", System.Data.SqlDbType.VarChar)).Value = LotID == null ? "" : LotID;
        //                command.Parameters.Add(new SqlParameter("@processing_code", System.Data.SqlDbType.VarChar)).Value = ProcessingCode == null ? "" : ProcessingCode.ToString();
        //                command.Parameters.Add(new SqlParameter("@lot_specific_data", System.Data.SqlDbType.VarChar)).Value = LotSpecificData == null ? "" : LotSpecificData;
        //                command.Parameters.Add(new SqlParameter("@host_recipe_number", System.Data.SqlDbType.VarChar)).Value = HostRecipeNumber.ToString();
        //                command.Parameters.Add(new SqlParameter("@glass_type", System.Data.SqlDbType.VarChar)).Value = GlassType == null ? "" : GlassType;
        //                command.Parameters.Add(new SqlParameter("@glass_code", System.Data.SqlDbType.VarChar)).Value = GlassCode.ToString();

        //                command.Parameters.Add(new SqlParameter("@glass_id", System.Data.SqlDbType.VarChar)).Value = GlassID == null ? "" : GlassID;
        //                command.Parameters.Add(new SqlParameter("@glass_judge", System.Data.SqlDbType.VarChar)).Value = GlassJudge == null ? "" : GlassJudge;
        //                command.Parameters.Add(new SqlParameter("@glass_specific_data", System.Data.SqlDbType.VarChar)).Value = GlassSpecificData == null ? "" : GlassSpecificData;
        //                command.Parameters.Add(new SqlParameter("@glass_add_data", System.Data.SqlDbType.VarChar)).Value = GlassAddData == null ? "" : GlassAddData;
        //                //command.Parameters.Add(new SqlParameter("@glass_variety", System.Data.SqlDbType.VarChar)).Value = GlassVariety.ToString();

        //                command.Parameters.Add(new SqlParameter("@glass_processing_status", System.Data.SqlDbType.VarChar)).Value = GlassProcessingStatus == null ? "" : GlassProcessingStatus;
        //                command.Parameters.Add(new SqlParameter("@original_cassette_id", System.Data.SqlDbType.VarChar)).Value = OriginalCassetteID == null ? "" : OriginalCassetteID;
        //                command.Parameters.Add(new SqlParameter("@glass_route_path", System.Data.SqlDbType.VarChar)).Value = GlassRoutePath.ToString();
        //                command.Parameters.Add(new SqlParameter("@glass_current_loc", System.Data.SqlDbType.VarChar)).Value = GlassCurrentLocation == null ? "" : GlassCurrentLocation;

        //                command.Parameters.Add(new SqlParameter("@glass_current_tm_loc", System.Data.SqlDbType.VarChar)).Value = "";


        //                command.Parameters.Add(new SqlParameter("@prev_unit_processing_data", System.Data.SqlDbType.VarChar)).Value = PreviousUnitProcessingData == null ? "" : PreviousUnitProcessingData;

        //                command.Parameters.Add(new SqlParameter("@current_loc", System.Data.SqlDbType.VarChar)).Value = CurrentLocation == null ? "" : CurrentLocation;

        //                command.Parameters.Add(new SqlParameter("@create_time", System.Data.SqlDbType.DateTime)).Value = _createTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
        //                command.Parameters.Add(new SqlParameter("@modify_time", System.Data.SqlDbType.DateTime)).Value = _modifyTime.ToString("yyyy-MM-dd HH:mm:ss.fff");


        //                command.Parameters.Add(new SqlParameter("@main_pnl_if", System.Data.SqlDbType.VarChar)).Value = MainPNLIF == null ? "" : MainPNLIF;
        //                command.Parameters.Add(new SqlParameter("@sub_pnl_if", System.Data.SqlDbType.VarChar)).Value = SubPNLIF == null ? "" : SubPNLIF;
        //                command.Parameters.Add(new SqlParameter("@original_port_id", System.Data.SqlDbType.VarChar)).Value = OriginalPortID == null ? "" : OriginalPortID;
        //                command.Parameters.Add(new SqlParameter("@original_slot_id", System.Data.SqlDbType.VarChar)).Value = OriginalSlotID == null ? "" : OriginalSlotID;
        //                command.Parameters.Add(new SqlParameter("@sample_code", System.Data.SqlDbType.VarChar)).Value = SampleCode == null ? "" : SampleCode;
        //                command.Parameters.Add(new SqlParameter("@string_gsd", System.Data.SqlDbType.VarChar)).Value = STRING_GSD == null ? "" : STRING_GSD;

        //                command.Parameters.Add(new SqlParameter("@is_processed", System.Data.SqlDbType.VarChar)).Value = IsProcessed == true ? "TRUE" : "FALSE";
        //                command.Parameters.Add(new SqlParameter("@is_scraped", System.Data.SqlDbType.VarChar)).Value = IsScraped == true ? "TRUE" : "FALSE";

        //                command.Parameters.Add(new SqlParameter("@main_glass_type", System.Data.SqlDbType.VarChar)).Value = MAIN_GLASS_TYPE == null ? "" : MAIN_GLASS_TYPE;                        
        //                command.Parameters.Add(new SqlParameter("@sub_glass_type", System.Data.SqlDbType.VarChar)).Value = SUB_GLASS_TYPE == null ? "" : SUB_GLASS_TYPE;

        //                command.Parameters.Add(new SqlParameter("@is_cim_generate_data", System.Data.SqlDbType.VarChar)).Value = IsCIMGenerateData == true ? "TRUE" : "FALSE";
        //                command.Parameters.Add(new SqlParameter("@current_cst_id", System.Data.SqlDbType.VarChar)).Value = CurrentCSTID == null ? "" : CurrentCSTID;
        //                command.Connection = connection;
        //                command.CommandText = "insert into glass_data " +
        //                    "(eqp_recipe_number, glass_judge_code, lot_code, lot_id, processing_code, lot_specific_data, host_recipe_number, glass_type, glass_code, glass_id, glass_judge, glass_specific_data, glass_add_data, glass_processing_status, original_cassette_id, glass_route_path, glass_current_loc, glass_current_tm_loc, prev_unit_processing_data, current_loc, create_time, modify_time, main_pnl_if, sub_pnl_if, original_port_id, original_slot_id, sample_code, string_gsd, is_processed, is_scraped, main_glass_type, sub_glass_type, is_cim_generate_data, current_cst_id) " +
        //                    "values (@eqp_recipe_number, @glass_judge_code, @lot_code, @lot_id, @processing_code, @lot_specific_data, @host_recipe_number, @glass_type, @glass_code, @glass_id, @glass_judge, @glass_specific_data, @glass_add_data, @glass_processing_status, @original_cassette_id, @glass_route_path, @glass_current_loc, @glass_current_tm_loc, @prev_unit_processing_data, @current_loc, @create_time, @modify_time, @main_pnl_if, @sub_pnl_if, @original_port_id, @original_slot_id, @sample_code, @string_gsd, @is_processed, @is_scraped, @main_glass_type, @sub_glass_type, @is_cim_generate_data, @current_cst_id)";
        //                command.ExecuteNonQuery();

        //                return true;
        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "EMP", ex));
        //    }
        //    finally
        //    {
        //        if (reader != null) reader.Close();
        //    }
        //    return false;
        //}
        //public override bool Delete()
        //{
        //    try
        //    {
        //        using (SqlConnection connection = DbControl.GetOpenConnection())
        //        {
        //            SqlCommand command = connection.CreateCommand();
        //            command.Parameters.Add(new SqlParameter("@glass_code", System.Data.SqlDbType.VarChar)).Value = GlassCode.ToString();
        //            command.CommandText = "delete from glass_data where glass_code=@glass_code";
        //            command.Connection = connection;
        //            command.ExecuteNonQuery();
        //        }
        //        return true;
        //    }
        //    catch (SqlException ex)
        //    {
        //        CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "EMP", ex));
        //    }

        //    return false;
        //}
        //public override bool Save()
        //{

        //    try
        //    {
        //        using (SqlConnection connection = DbControl.GetOpenConnection())
        //        {
        //            SqlCommand command = connection.CreateCommand();

        //            command.Parameters.Add(new SqlParameter("@eqp_recipe_number", System.Data.SqlDbType.VarChar)).Value = EQPRecipeNumber == null ? "" : EQPRecipeNumber;
        //            command.Parameters.Add(new SqlParameter("@glass_judge_code", System.Data.SqlDbType.VarChar)).Value = GlassJudgeCode.ToString();
        //            command.Parameters.Add(new SqlParameter("@lot_code", System.Data.SqlDbType.VarChar)).Value = LOTCode.ToString();


        //            command.Parameters.Add(new SqlParameter("@lot_id", System.Data.SqlDbType.VarChar)).Value = LotID == null ? "" : LotID;
        //            command.Parameters.Add(new SqlParameter("@processing_code", System.Data.SqlDbType.VarChar)).Value = ProcessingCode == null ? "" : ProcessingCode.ToString();
        //            command.Parameters.Add(new SqlParameter("@lot_specific_data", System.Data.SqlDbType.VarChar)).Value = LotSpecificData == null ? "" : LotSpecificData;
        //            command.Parameters.Add(new SqlParameter("@host_recipe_number", System.Data.SqlDbType.VarChar)).Value = HostRecipeNumber.ToString();
        //            command.Parameters.Add(new SqlParameter("@glass_type", System.Data.SqlDbType.VarChar)).Value = GlassType == null ? "" : GlassType;
        //            command.Parameters.Add(new SqlParameter("@glass_code", System.Data.SqlDbType.VarChar)).Value = GlassCode.ToString();

        //            command.Parameters.Add(new SqlParameter("@glass_id", System.Data.SqlDbType.VarChar)).Value = GlassID == null ? "" : GlassID;
        //            command.Parameters.Add(new SqlParameter("@glass_judge", System.Data.SqlDbType.VarChar)).Value = GlassJudge == null ? "" : GlassJudge;
        //            command.Parameters.Add(new SqlParameter("@glass_specific_data", System.Data.SqlDbType.VarChar)).Value = GlassSpecificData == null ? "" : GlassSpecificData;
        //            command.Parameters.Add(new SqlParameter("@glass_add_data", System.Data.SqlDbType.VarChar)).Value = GlassAddData == null ? "" : GlassAddData;
        //            //command.Parameters.Add(new SqlParameter("@glass_variety", System.Data.SqlDbType.VarChar)).Value = GlassVariety.ToString();

        //            command.Parameters.Add(new SqlParameter("@glass_processing_status", System.Data.SqlDbType.VarChar)).Value = GlassProcessingStatus == null ? "" : GlassProcessingStatus;
        //            command.Parameters.Add(new SqlParameter("@original_cassette_id", System.Data.SqlDbType.VarChar)).Value = OriginalCassetteID == null ? "" : OriginalCassetteID;
        //            command.Parameters.Add(new SqlParameter("@glass_route_path", System.Data.SqlDbType.VarChar)).Value = GlassRoutePath.ToString();
        //            command.Parameters.Add(new SqlParameter("@glass_current_loc", System.Data.SqlDbType.VarChar)).Value = GlassCurrentLocation == null ? "" : GlassCurrentLocation;

        //            command.Parameters.Add(new SqlParameter("@glass_current_tm_loc", System.Data.SqlDbType.VarChar)).Value = GlassCurrentLocation == null ? "" : GlassCurrentLocation;


        //            command.Parameters.Add(new SqlParameter("@prev_unit_processing_data", System.Data.SqlDbType.VarChar)).Value = PreviousUnitProcessingData == null ? "" : PreviousUnitProcessingData;

        //            command.Parameters.Add(new SqlParameter("@current_loc", System.Data.SqlDbType.VarChar)).Value = CurrentLocation == null ? "" : CurrentLocation;

        //            command.Parameters.Add(new SqlParameter("@create_time", System.Data.SqlDbType.DateTime)).Value = _createTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
        //            command.Parameters.Add(new SqlParameter("@modify_time", System.Data.SqlDbType.DateTime)).Value = _modifyTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

        //            command.Parameters.Add(new SqlParameter("@main_pnl_if", System.Data.SqlDbType.VarChar)).Value = MainPNLIF == null ? "" : MainPNLIF;
        //            command.Parameters.Add(new SqlParameter("@sub_pnl_if", System.Data.SqlDbType.VarChar)).Value = SubPNLIF == null ? "" : SubPNLIF;
        //            command.Parameters.Add(new SqlParameter("@original_port_id", System.Data.SqlDbType.VarChar)).Value = OriginalPortID == null ? "" : OriginalPortID;
        //            command.Parameters.Add(new SqlParameter("@original_slot_id", System.Data.SqlDbType.VarChar)).Value = OriginalSlotID == null ? "" : OriginalSlotID;
        //            command.Parameters.Add(new SqlParameter("@sample_code", System.Data.SqlDbType.VarChar)).Value = SampleCode == null ? "" : SampleCode;
        //            command.Parameters.Add(new SqlParameter("@string_gsd", System.Data.SqlDbType.VarChar)).Value = STRING_GSD == null ? "" : STRING_GSD;


        //            command.Parameters.Add(new SqlParameter("@is_processed", System.Data.SqlDbType.VarChar)).Value = IsProcessed == true ? "TRUE" : "FALSE";
        //            command.Parameters.Add(new SqlParameter("@is_scraped", System.Data.SqlDbType.VarChar)).Value = IsScraped == true ? "TRUE" : "FALSE";

        //            command.Parameters.Add(new SqlParameter("@main_glass_type", System.Data.SqlDbType.VarChar)).Value = MAIN_GLASS_TYPE == null ? "" : MAIN_GLASS_TYPE;
        //            command.Parameters.Add(new SqlParameter("@sub_glass_type", System.Data.SqlDbType.VarChar)).Value = SUB_GLASS_TYPE == null ? "" : SUB_GLASS_TYPE;

        //            command.Parameters.Add(new SqlParameter("@is_cim_generate_data", System.Data.SqlDbType.VarChar)).Value = IsCIMGenerateData == true ? "TRUE" : "FALSE";
        //            command.Parameters.Add(new SqlParameter("@current_cst_id", System.Data.SqlDbType.VarChar)).Value = CurrentCSTID == null ? "" : CurrentCSTID;
        //            command.CommandText = "update glass_data set " +
        //                "eqp_recipe_number=@eqp_recipe_number, glass_judge_code=@glass_judge_code, lot_code=@lot_code, lot_id=@lot_id, processing_code=@processing_code, lot_specific_data=@lot_specific_data, host_recipe_number=@host_recipe_number, glass_type=@glass_type, " +
        //                "glass_code=@glass_code, glass_id=@glass_id, glass_judge=@glass_judge, glass_specific_data=@glass_specific_data, glass_add_data=@glass_add_data, " +
        //                "glass_processing_status=@glass_processing_status, original_cassette_id=@original_cassette_id, glass_route_path=@glass_route_path, glass_current_loc=@glass_current_loc, " +
        //                "prev_unit_processing_data=@prev_unit_processing_data, current_loc=@current_loc,  create_time=@create_time, modify_time=@modify_time, " +
        //                "main_pnl_if=@main_pnl_if, sub_pnl_if=@sub_pnl_if, original_port_id=@original_port_id, original_slot_id=@original_slot_id, sample_code=@sample_code, string_gsd=@string_gsd, " +
        //                "is_processed=@is_processed, is_scraped=@is_scraped, main_glass_type=@main_glass_type, sub_glass_type=@sub_glass_type, is_cim_generate_data=@is_cim_generate_data, current_cst_id=@current_cst_id " +
        //                "where glass_code=@glass_code";
        //            command.Connection = connection;
        //            command.ExecuteNonQuery();
        //        }
        //        return true;
        //    }
        //    catch (SqlException ex)
        //    {
                
        //        CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "EMP", ex));
        //    }

        //    return false;
        //}
        //public override bool Load()
        //{
        //    SqlDataReader reader = null;
        //    try
        //    {
        //        using (SqlConnection connection = DbControl.GetOpenConnection())
        //        {
        //            SqlCommand readCommand = connection.CreateCommand();
        //            readCommand.Parameters.Add("@glass_code", System.Data.SqlDbType.VarChar).Value = GlassCode.ToString();
        //            readCommand.CommandText = "select * from glass_data where glass_code=@glass_code";
        //            readCommand.CommandTimeout = 15;
        //            readCommand.Connection = connection;
        //            reader = readCommand.ExecuteReader();

        //            if (reader.Read())
        //            {
        //                int intTemp = 0;

        //                EQPRecipeNumber = (string)reader["eqp_recipe_number"];
        //                int.TryParse((string)reader["glass_judge_code"], out intTemp);
        //                GlassJudgeCode = intTemp;
        //                int.TryParse((string)reader["lot_code"], out intTemp);
        //                LOTCode = intTemp;

        //                LotID = (string)reader["lot_id"];
        //                ProcessingCode = (string)reader["processing_code"];
        //                LotSpecificData = (string)reader["lot_specific_data"];
                        
        //                int.TryParse((string)reader["host_recipe_number"], out intTemp);

        //                HostRecipeNumber = intTemp;
        //                GlassType = (string)reader["glass_type"];
              
        //                int.TryParse((string)reader["glass_code"], out intTemp);
        //                GlassCode = intTemp;
        //                GlassID = (string)reader["glass_id"];
        //                GlassJudge = (string)reader["glass_judge"];
        //                GlassSpecificData = (string)reader["glass_specific_data"];
        //                GlassAddData = (string)reader["glass_add_data"];
        //                //GlassVariety = (enumGlassVariety)Enum.Parse(typeof(enumGlassVariety), (string)reader["glass_variety"]);

        //                GlassProcessingStatus = (string)reader["glass_processing_status"];
        //                OriginalCassetteID = (string)reader["original_cassette_id"];
        //                int.TryParse((string)reader["glass_route_path"], out intTemp);
        //                GlassRoutePath = intTemp;
        //                GlassCurrentLocation = (string)reader["glass_current_loc"];

        //                PreviousUnitProcessingData = (string)reader["prev_unit_processing_data"];

        //                CurrentLocation = (string)reader["current_loc"];

        //                _createTime = (DateTime)reader["create_time"];
        //                _modifyTime = (DateTime)reader["modify_time"];

        //                MainPNLIF = (string)reader["main_pnl_if"];
        //                SubPNLIF = (string)reader["sub_pnl_if"];
        //                OriginalPortID = (string)reader["original_port_id"];
        //                OriginalSlotID = (string)reader["original_slot_id"];
        //                SampleCode = (string)reader["sample_code"];
        //                STRING_GSD = (string)reader["string_gsd"];

        //                IsProcessed = (string)reader["is_processed"] == "TRUE" ? true : false;
        //                IsScraped = (string)reader["is_scraped"] == "TRUE" ? true : false;

        //                MAIN_GLASS_TYPE = (string)reader["main_glass_type"];
        //                SUB_GLASS_TYPE = (string)reader["sub_glass_type"];

        //                IsCIMGenerateData = (string)reader["is_cim_generate_data"] == "TRUE" ? true : false;
        //                CurrentCSTID = (string)reader["current_cst_id"];
        //            }

        //            reader.Close();
        //            reader.Dispose();
        //        }
        //        return true;
        //    }
        //    catch (SqlException ex)
        //    {
        //        CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "EMP", ex));
        //    }
        //    finally
        //    {
        //        if (reader != null) reader.Close();
        //    }

        //    return false;
        //}

        #endregion


        public static List<int> ConvertPLCData(CGlassDataPropertiesB7 glassData)
        {
            List<int> plcData = new List<int>();

            plcData.AddRange(CovertStringToWordList(glassData.LotID, 10));
            plcData.AddRange(CovertStringToWordList(glassData.GlassID, 10));
            plcData.AddRange(CovertStringToWordList(glassData.OperID, 5));
            plcData.Add(glassData.GlassCodeLotNo);
            plcData.Add(glassData.GlassCodeSlotNo);
            //plcData.AddRange(CovertStringToWordList(glassData.GlassJudgeCode, 1));
            plcData.Add(glassData.GlassJudgeCode);
            plcData.Add(glassData.GlassGradeCode);
            plcData.Add(0);
            plcData.Add(glassData.PPID);
            for (int i = 0; i < 18; i++)
            {
                plcData.Add(0);
            }
            //for (int i = 0; i < 19; i++)
            //{
            //    plcData.Add(0);
            //}
            plcData.AddRange(CovertStringToWordList(glassData.ProdID, 10));
            //plcData.Add(glassData.CIMPCData1); <TODO> 사용하는 것인지 확인이 필요함.
            //plcData.Add(glassData.CIMPCData2);
            plcData.Add(glassData.ProcFlag1);
            plcData.Add(glassData.ProcFlag2);
            plcData.Add(glassData.InspectionJudgeData1);
            plcData.Add(glassData.InspectionJudgeData2);
            //plcData.Add(glassData.JudgeFlag1);
            //plcData.Add(glassData.JudgeFlag2);
            plcData.Add(glassData.SkipFlag1);
            plcData.Add(glassData.SkipFlag2);
            plcData.Add(glassData.InspectionFlag1);
            plcData.Add(glassData.InspectionFlag2);
            plcData.Add(glassData.Mode);
            plcData.Add(glassData.GlassType1);
            plcData.Add(glassData.GlassType2);
            plcData.Add(glassData.DummyType);
            plcData.Add(glassData.ProcessCount);
            plcData.Add(glassData.ReservedData1);
            plcData.Add(glassData.ReservedData2);
            plcData.Add(glassData.ReservedData3);
            plcData.Add(glassData.ReservedData4);
            plcData.Add(glassData.ReservedData5);
            plcData.Add(glassData.ReservedData6);
            //plcData.Add(glassData.ReservedData7);
            //plcData.Add(glassData.ReservedData8); 

      
            return plcData;
        }

        //20161103 Stored Job, Fetched Out Job 에서 PPID Write하지 않고, 영역도 60 Word
        public static List<int> ConvertPLCData60word(CGlassDataPropertiesB7 glassData) 
        {
            List<int> plcData = new List<int>();

            plcData.AddRange(CovertStringToWordList(glassData.LotID, 10));
            plcData.AddRange(CovertStringToWordList(glassData.GlassID, 10));
            plcData.AddRange(CovertStringToWordList(glassData.OperID, 5));
            plcData.Add(glassData.GlassCodeLotNo);
            plcData.Add(glassData.GlassCodeSlotNo);
            //plcData.AddRange(CovertStringToWordList(glassData.GlassJudgeCode, 1));
            plcData.Add(glassData.GlassJudgeCode);
            plcData.Add(glassData.GlassGradeCode);     
            plcData.AddRange(CovertStringToWordList(glassData.ProdID, 10));
            //plcData.Add(glassData.CIMPCData1); <TODO> 사용하는 것인지 확인이 필요함.
            //plcData.Add(glassData.CIMPCData2);
            plcData.Add(glassData.ProcFlag1);
            plcData.Add(glassData.ProcFlag2);
            plcData.Add(glassData.InspectionJudgeData1);
            plcData.Add(glassData.InspectionJudgeData2);
            //plcData.Add(glassData.JudgeFlag1);
            //plcData.Add(glassData.JudgeFlag2);
            plcData.Add(glassData.SkipFlag1);
            plcData.Add(glassData.SkipFlag2);
            plcData.Add(glassData.InspectionFlag1);
            plcData.Add(glassData.InspectionFlag2);
            plcData.Add(glassData.Mode);
            plcData.Add(glassData.GlassType1);
            plcData.Add(glassData.GlassType2);
            plcData.Add(glassData.DummyType);
            plcData.Add(glassData.ProcessCount);
            plcData.Add(glassData.ReservedData1);
            plcData.Add(glassData.ReservedData2);
            plcData.Add(glassData.ReservedData3);
            plcData.Add(glassData.ReservedData4);
            plcData.Add(glassData.ReservedData5);
            plcData.Add(glassData.ReservedData6);
            //plcData.Add(glassData.ReservedData7);
            //plcData.Add(glassData.ReservedData8);

            return plcData;
        }

        /// <summary>
        /// ABCD  -> BADC-> HEX -> DEC 로 변환 해준다.
        /// </summary>
        /// <param name="normalString"></param>
        /// <param name="wordMaxLength">WORD 기준 총개수, 내부적으로 *2한다.</param>
        /// <returns></returns>
        public static List<int> CovertStringToWordList(string normalString, int wordMaxLength)
        {
            List<int> plcData = new List<int>();
            char[] tempLotID = normalString.ToCharArray();
            List<string> word = new List<string>();
            long maxLegnth = wordMaxLength * 2;
            for (int i = 0; i < maxLegnth; i++)
            {
                if (tempLotID.Length < i)
                {
                    word.Insert(0, " ");
                }
                else
                {
                    word.Insert(0, tempLotID[i].ToString());
                }
                if (word.Count >= 2)
                {
                    //plcData.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.StringToReverseHex(word[0] + word[1]))));
                    plcData.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.StringToHex(word[0] + word[1]))));
                    word.Clear();
                }
            }

            return plcData;
        }
        /// <summary>
        /// ABCD  -> BADC-> HEX -> DEC 로 변환 해준다.
        /// </summary>
        /// <param name="normalString"></param>
        /// <param name="wordMaxLength">WORD 기준 총개수, 내부적으로 *2한다.</param>
        /// <returns></returns>
        public static List<ushort> CovertStringToWordushort(string normalString, int wordMaxLength)
        {
            List<ushort> plcData = new List<ushort>();
            char[] tempLotID = normalString.ToCharArray();
            List<string> word = new List<string>();
            long maxLegnth = wordMaxLength * 2;
            for (ushort i = 0; i < maxLegnth; i++)
            {
                if (tempLotID.Length <= i)
                {
                    word.Insert(0, " ");
                }
                else
                {
                    word.Insert(0, tempLotID[i].ToString());
                }
                if (word.Count >= 2)
                {
                    //plcData.Add(ushort.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.StringToReverseHex(word[0] + word[1]))));
                    plcData.Add(ushort.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.StringToHex(word[0] + word[1])))); //20161107

                    word.Clear();
                }
            }

            return plcData;
        }
        public static Dictionary<string, string> GetGuiData(CGlassDataPropertiesB7 glassData)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("LotID", glassData.LotID);
            data.Add("GlassID", glassData.GlassID);
            data.Add("OperID", glassData.OperID);
            data.Add("GlassCodeLotNo", glassData.GlassCodeLotNo.ToString());
            data.Add("GlassCodeSlotNo", glassData.GlassCodeSlotNo.ToString());
            data.Add("GlassJudgeCode", glassData.GlassJudgeCode.ToString());
            data.Add("GlassGradeCode", glassData.GlassGradeCode.ToString());
            data.Add("PPID", glassData.PPID.ToString());
            data.Add("ProdID", glassData.ProdID);
            //data.Add("CIMPCData1", glassData.CIMPCData1.ToString());
            //data.Add("CIMPCData2", glassData.CIMPCData2.ToString());
            data.Add("ProcFlag1", glassData.ProcFlag1.ToString());
            data.Add("ProcFlag2", glassData.ProcFlag2.ToString());
            data.Add("InspectionJudgeData1", glassData.InspectionJudgeData1.ToString());
            data.Add("InspectionJudgeData2", glassData.InspectionJudgeData2.ToString());
            //data.Add("JudgeFlag1", glassData.JudgeFlag1.ToString());
            //data.Add("JudgeFlag2", glassData.JudgeFlag2.ToString());
            data.Add("SkipFlag1", glassData.SkipFlag1.ToString());
            data.Add("SkipFlag2", glassData.SkipFlag2.ToString());
            data.Add("InspectionFlag1", glassData.InspectionFlag1.ToString());
            data.Add("InspectionFlag2", glassData.InspectionFlag2.ToString());
            data.Add("Mode", glassData.Mode.ToString());
            data.Add("GlassType1", glassData.GlassType1.ToString());
            data.Add("GlassType2", glassData.GlassType2.ToString());
            data.Add("DummyType", glassData.DummyType.ToString());
            data.Add("ProcessCount", glassData.ProcessCount.ToString());
            data.Add("ReservedData1", glassData.ReservedData1.ToString());
            data.Add("ReservedData2", glassData.ReservedData2.ToString());
            data.Add("ReservedData3", glassData.ReservedData3.ToString());
            data.Add("ReservedData4", glassData.ReservedData4.ToString());
            data.Add("ReservedData5", glassData.ReservedData5.ToString());
            data.Add("ReservedData6", glassData.ReservedData6.ToString());
            //data.Add("ReservedData7", glassData.ReservedData7.ToString());
            //data.Add("ReservedData8", glassData.ReservedData8.ToString());
            return data;
        }

        public static Dictionary<string, string> GetRemovedData(string[] glassData)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("LotID", glassData[0]);
            data.Add("GlassID", glassData[1]);
            data.Add("OperID", glassData[2]);
            data.Add("GlassCodeLotNo", glassData[3]);
            data.Add("GlassCodeSlotNo", glassData[4]);
            data.Add("GlassJudgeCode", glassData[5]);
            data.Add("GlassGradeCode", glassData[6]);
            data.Add("PPID", glassData[7]);
            data.Add("ProdID", glassData[8]);
            //data.Add("CIMPCData1", glassData.CIMPCData1.ToString());
            //data.Add("CIMPCData2", glassData.CIMPCData2.ToString());
            data.Add("ProcFlag1", glassData[9]);
            data.Add("ProcFlag2", glassData[10]);
            data.Add("InspectionJudgeData1", glassData[11]);
            data.Add("InspectionJudgeData2", glassData[12]);
            //data.Add("JudgeFlag1", glassData.JudgeFlag1.ToString());
            //data.Add("JudgeFlag2", glassData.JudgeFlag2.ToString());
            data.Add("SkipFlag1", glassData[13]);
            data.Add("SkipFlag2", glassData[14]);
            data.Add("InspectionFlag1", glassData[15]);
            data.Add("InspectionFlag2", glassData[16]);
            data.Add("Mode", glassData[17]);
            data.Add("GlassType1", glassData[18]);
            data.Add("GlassType2", glassData[19]);
            data.Add("DummyType", glassData[20]);
            data.Add("ProcessCount", glassData[21]);
            data.Add("ReservedData1", glassData[22]);
            data.Add("ReservedData2", glassData[23]);
            data.Add("ReservedData3", glassData[24]);
            data.Add("ReservedData4", glassData[25]);
            data.Add("ReservedData5", glassData[26]);
            data.Add("ReservedData6", glassData[27]);
            //data.Add("ReservedData7", glassData.ReservedData7.ToString());
            //data.Add("ReservedData8", glassData.ReservedData8.ToString());
            return data;
        }



        public static ushort[] GetGuiDataToPLC(Dictionary<string, string> data)
        {
            List<ushort> plcData = new List<ushort>();

            plcData.AddRange(CovertStringToWordushort(data["LotID"], 10));
            plcData.AddRange(CovertStringToWordushort(data["GlassID"], 10));
            plcData.AddRange(CovertStringToWordushort(data["OperID"], 5));
            plcData.Add(ushort.Parse(data["GlassCodeLotNo"]));
            plcData.Add(ushort.Parse(data["GlassCodeSlotNo"]));
            plcData.Add(ushort.Parse(data["GlassJudgeCode"]));
            plcData.Add(ushort.Parse(data["GlassGradeCode"]));
            plcData.Add(0);
            plcData.Add(ushort.Parse(data["PPID"]));
            for (int i = 0; i < 18; i++) //20161114
            {
                plcData.Add(0);
            }
            plcData.AddRange(CovertStringToWordushort(data["ProdID"], 10));
            //plcData.Add(ushort.Parse(data["CIMPCData1"]));
            //plcData.Add(ushort.Parse(data["CIMPCData2"]));
            plcData.Add(ushort.Parse(data["ProcFlag1"]));
            plcData.Add(ushort.Parse(data["ProcFlag2"]));
            plcData.Add(ushort.Parse(data["InspectionJudgeData1"]));
            plcData.Add(ushort.Parse(data["InspectionJudgeData2"]));
            //plcData.Add(ushort.Parse(data["JudgeFlag1"]));
            //plcData.Add(ushort.Parse(data["JudgeFlag2"]));
            plcData.Add(ushort.Parse(data["SkipFlag1"]));
            plcData.Add(ushort.Parse(data["SkipFlag2"]));
            plcData.Add(ushort.Parse(data["InspectionFlag1"]));
            plcData.Add(ushort.Parse(data["InspectionFlag2"]));
            plcData.Add(ushort.Parse(data["Mode"]));
            plcData.Add(ushort.Parse(data["GlassType1"]));
            plcData.Add(ushort.Parse(data["GlassType2"]));
            plcData.Add(ushort.Parse(data["DummyType"]));
            plcData.Add(ushort.Parse(data["ProcessCount"]));
            plcData.Add(ushort.Parse(data["ReservedData1"]));
            plcData.Add(ushort.Parse(data["ReservedData2"]));
            plcData.Add(ushort.Parse(data["ReservedData3"]));
            plcData.Add(ushort.Parse(data["ReservedData4"]));
            plcData.Add(ushort.Parse(data["ReservedData5"]));
            plcData.Add(ushort.Parse(data["ReservedData6"]));
            //plcData.Add(ushort.Parse(data["ReservedData7"]));
            //plcData.Add(ushort.Parse(data["ReservedData8"]));

            return plcData.ToArray();
        }


        public static string GetSaveData(CGlassDataPropertiesB7 glassData)
        {
            Dictionary<string, string> data = GetGuiData(glassData);
            string temp = "";

            foreach (string item in data.Values)
            {
                temp += string.Format("{0},", item.ToString().Trim());
            }
            temp = temp.Substring(0, temp.Length - 1);
            return temp;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            Dictionary<string, string> data = GetGuiData(this);

            foreach (KeyValuePair<string, string> item in data)
            {
                sb.AppendFormat("{0}={1},", item.Key, item.Value);
            }
            return sb.ToString();
        }
    }

    public class CGlassDataPropertiesB7Collection : Dictionary<int, CGlassDataPropertiesB7>
    {
        public bool IsExistGlassDataByGLASSID(string GLASSID)
        {
            foreach (CGlassDataPropertiesB7 oGlass in this.Values)
            {
                if (oGlass.GlassID == GLASSID)
                {
                    return true;
                }
            }
            return false;
        }

        public CGlassDataPropertiesB7 GetGlassDataBy(string GLASSID)
        {
            foreach (CGlassDataPropertiesB7 oGlass in this.Values)
            {
                if (oGlass.GlassID == GLASSID)
                {
                    return oGlass;
                }
            }
            return null;
        }
        public bool IsExistGlassDataBy(string GLASSID, out CGlassDataPropertiesB7 glassData)
        {
            glassData = null;
            foreach (CGlassDataPropertiesB7 oGlass in this.Values)
            {
                if (oGlass.GlassID == GLASSID)
                {
                    glassData = oGlass;
                    return true;
                }
            }

            return false;
        }
        public bool IsExistGlassDataBy(int glassCode, out CGlassDataPropertiesB7 glassData)
        {
            glassData = null;
            foreach (CGlassDataPropertiesB7 oGlass in this.Values)
            {
                if (oGlass.GlassCode == glassCode)
                {
                    glassData = oGlass;
                    return true;
                }
            }

            return false;
        }
        public CGlassDataPropertiesB7 GetGlassDataBy(int glassCode)
        {
            foreach (CGlassDataPropertiesB7 oGlass in this.Values)
            {
                if (oGlass.GlassCode == glassCode)
                {
                    return oGlass;
                }
            }
            return null;
        }
    }

    public class CGlassDataPropertiesWHTM : AMaterialData
    {
        #region //member's
        public const string CLASS = "CGlassDataPropertiesWHTM";

        #endregion

        #region //property's

        //WHTM
        public int PortNo = 0;
        public int SeqNo = 0;
        public int GlassPosition = 0;
        public int GlassSlotNo = 0;
        public ushort CassetteIndex = 0;
        public ushort GlassIndex = 0;
        public ushort ProductCode = 0;
        public ushort GlassThickness = 0;
        public string LotID = "";
        public string GlassID
        {
            get
            {
                return this.MatrialID;
            }
            set
            {
                this.MatrialID = value;
            }
        }
        public string PPID = "";
        public ushort GlassType = 0;
        /// <summary>
        /// GPR
        /// </summary>
        public string JobJudge = "";
        /// <summary>
        /// PSTQ
        /// </summary>
        public string JobGrade = "";
        public ushort JobState = 0;
        /// <summary>
        /// Status:
        /// 1: No State
        /// 2. Queued
        /// 3: Selected
        /// 4: WaitingForStart
        /// 5: Executing
        /// 6: Completed
        /// 7. Paused
        /// 8. Aborted
        /// 9. Skipped
        /// 10. Lost
        ///-Equipment Modify
        /// </summary>
        public ushort JobStateInt = 0;
        /// <summary>
        /// 0: Not Processed (Not In EQ)
        /// 1: Normal Processed [In EQ]
        /// 2: Abnormal Processed [In EQ]
        /// 3: Process Skip [In EQ]
        /// "1st Word       
        /// Bit 00~01:                  
        /// Bit 02~03:           
        /// Bit 04~05: 
        /// Bit 06~07: 
        /// Bit 08~09:   
        /// Bit 10~11:              
        /// Bit 12~13:               
        /// Bit 14~15:               
        /// 2nd Word 
        /// Bit 00~01: -       
        /// Bit 02~03: -   
        /// Bit 04~05: -
        /// Bit 06~07: -             
        /// Bit 08~09: -              
        /// Bit 10~11: -
        /// Bit 12~13: -
        /// Bit 14~15:"
        /// </summary>
        public ulong TrackingData = 0;
        /// <summary>
        /// eam Path No:
          /// 200: #L2              300: #L3                  400: #L4  
          /// 1:Port1                301: #L3.A               
          /// 2: Port2               302: #L3.B
          /// 3: Port3
        /// 4: Port4
        /// </summary>
        public ushort UnitPathNo = 0;
        /// <summary>
        /// Single Stage 0
        /// </summary>
        public ushort SlotNo = 0;
        /// <summary>
        /// 2w Single?
        /// </summary>
        public float CycleTime = 0;
        /// <summary>
        ///  2w Single?
        /// </summary>
        public float TactTime = 0;
        /// <summary>
        /// Abort, Judge/Grade Change, Scrap or Takeout Reason Code
        /// Remove Reason Code:      1~99
          ///  1: Takeout【触摸屏保留10个记录】
          ///  2: TakeIn (Recovery Removed Job)
           /// 3~99:Scrap
        /// Skip Reason Code:      100~199
        /// Judge/Grade Change Reason Code: 200~299
        /// Abort Reason Code:    300~399
        /// </summary>
        public ushort ReasonCode = 0;
        /// <summary>
        /// The list of equipment that the job should be inspected. It is used only for test, inspection and measurement equipment.
        /// 0: No Reservation
        /// 1: Reserved
        /// [-Index/CIS Create -Others Monitor]
        /// BIT
        /// </summary>
        public ushort SamplingFlag = 0;
        public ushort LotEndFlag = 0;
        public string OperationId = "";
        public string ProductId = "";
        public string CassetteId = "";
        public string Reserved1 = "";
        /// <summary>
        /// Status:
        /// 1: At source
        /// 2: Processing Start
        /// 3: Processing End
        /// 4: At disination
        /// 5: Out Cassette
        /// 6: In Cassette
        /// </summary>
        public ushort TransportState = 0;
        public ushort ProcessedTime = 0;
        public string ProcessedStartTime = "";
        public string ProcessedEndTime = "";
        public ushort CurrentWIPCount = 0;
        #endregion

        #region //constructor's

        public CGlassDataPropertiesWHTM()
        {

        }
        public CGlassDataPropertiesWHTM(ushort[] glassData)
        {
            DbControl = _dbControl;
            this.GlassDataConvert(glassData);
        }

        private string GetStringIn(int start, int length, ushort[] glassData)
        {

            if (glassData == null || glassData.Length <= 0)
                throw new ArgumentNullException();

            if (start + length > glassData.Length)
                throw new ArgumentException();


            try
            {
                string temp = "";
                ushort[] target = new ushort[length];
                Array.Copy(glassData, start, target, 0, length);

                for (int i = 0; i < target.Length; i++)
                {
                    char _convertChar00 = Convert.ToChar(Convert.ToInt16(target[i]) & 0xff);
                    char _convertChar01 = Convert.ToChar(Convert.ToInt16(target[i]) >> 8);

                    temp += (_convertChar00.ToString() + _convertChar01.ToString());
                }
                return temp.Replace('\0', ' ').TrimEnd();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "";
        }

        private void SetCassetteIndex(ushort value)
        {
            string temp = value.ToString();

            int.TryParse(SmartDevice.UTILS.PLCUtils.HexToDec("00" + SmartDevice.UTILS.PLCUtils.DecToHex(temp).Substring(2, 2)), out SeqNo);
            int.TryParse(SmartDevice.UTILS.PLCUtils.HexToDec("00" + SmartDevice.UTILS.PLCUtils.DecToHex(temp).Substring(0, 2)), out PortNo);

            //if (temp.Length >= 4)
            //{
            //    int.TryParse(temp.Substring(temp.Length - 3, 3), out SeqNo);
            //    int.TryParse(temp.Substring(0, temp.Length - 3), out PortNo);
            //}
        }
        private void SetGlassIndex(ushort value)
        {
            string temp = value.ToString();

            //SmartDevice.UTILS.PLCUtils.HexToDec("00" + SmartDevice.UTILS.PLCUtils.DecToHex(temp).Substring(2,2))

            int.TryParse(SmartDevice.UTILS.PLCUtils.HexToDec("00" + SmartDevice.UTILS.PLCUtils.DecToHex(temp).Substring(2, 2)), out GlassSlotNo);
            int.TryParse(SmartDevice.UTILS.PLCUtils.HexToDec("00" + SmartDevice.UTILS.PLCUtils.DecToHex(temp).Substring(0, 2)), out GlassPosition);


            //if (temp.Length >= 4)
            //{
            //    int.TryParse(temp.Substring(temp.Length - 3, 3), out GlassSlotNo);
            //    int.TryParse(temp.Substring(0, temp.Length - 3), out GlassPosition);
            //}
        }
        private void GlassDataConvert(ushort[] glassData)
        {
            try
            {
                if (glassData == null || glassData.Length <= 0)
                    return;

                this.CassetteIndex = glassData[0];
                SetCassetteIndex(this.CassetteIndex);
                this.GlassIndex = glassData[1];
                SetGlassIndex(this.GlassIndex);
                this.ProductCode = glassData[2];
                this.GlassThickness = glassData[3];
                this.LotID = GetStringIn(4, 10, glassData);
                this.GlassID = GetStringIn(14, 10, glassData);//OMRON STRING 끝에 1WORD NULL 이있어 (10개+ 1개) 14가 아닌 15부터 시작
                this.PPID = GetStringIn(24, 10, glassData);
                this.GlassType = glassData[34];
                this.JobJudge = GetStringIn(35, 1, glassData);
                this.JobGrade = GetStringIn(36, 1, glassData);
                this.JobState = glassData[37];
                this.TrackingData = (ulong)(glassData[38] | (ulong)glassData[39] << 16 | (ulong)glassData[40] << 32 | (ulong)glassData[41] << 48);
                this.UnitPathNo = glassData[42];
                this.SlotNo = glassData[43];
                Console.WriteLine(float.MaxValue);
                this.CycleTime = PLCDataConverter.PLC4ByteToSystemFloat(ushortArrayToByteArray(glassData, 44, 2), 0);//(uint)glassData[45] << 16 | (uint)glassData[44];
                this.TactTime = PLCDataConverter.PLC4ByteToSystemFloat(ushortArrayToByteArray(glassData, 46, 2), 0);//(uint)glassData[47] << 16 | (uint)glassData[46];
                this.ReasonCode = glassData[48];
                this.SamplingFlag = glassData[49];
                this.LotEndFlag = glassData[50];
                this.OperationId = GetStringIn(51, 5, glassData);
                this.ProductId = GetStringIn(56, 10, glassData);
                this.CassetteId = GetStringIn(66, 5, glassData);
                this.Reserved1 = GetStringIn(71, 25, glassData);
               
            }
            catch (Exception ex)
            {
                CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, CExceptionLogFormat.DEFAULT_KEY, ex));
            }
        }
        #endregion

        #region //method's

        //public static CGlassDataPropertiesCollection LoadAll(string dbName)
        //{
        //    SqlDataReader reader = null;
        //    CGlassDataPropertiesCollection glassDatas = new CGlassDataPropertiesCollection();
        //    try
        //    {
        //        using (SqlConnection connection = GetDBControl(dbName).GetOpenConnection())
        //        {
        //            SqlCommand readCommand = connection.CreateCommand();
        //            readCommand.CommandText = "select * from glass_data";
        //            readCommand.Connection = connection;
        //            reader = readCommand.ExecuteReader();

        //            while (reader.Read())
        //            {
        //                int intTemp = 0;

        //                CGlassDataProperties glassData = new CGlassDataProperties();
        //                //신규 데이터.
        //                glassData.EQPRecipeNumber = (string)reader["eqp_recipe_number"];    


        //                int.TryParse((string)reader["glass_judge_code"], out intTemp);
        //                glassData.GlassJudgeCode = intTemp;

        //                int.TryParse((string)reader["lot_code"], out intTemp);
        //                glassData.LOTCode = intTemp;


        //                glassData.LotID = (string)reader["lot_id"];
        //                glassData.ProcessingCode = (string)reader["processing_code"];
        //                glassData.LotSpecificData = (string)reader["lot_specific_data"];

        //                int.TryParse((string)reader["host_recipe_number"], out intTemp);
        //                glassData.HostRecipeNumber = intTemp;

        //                glassData.GlassType = (string)reader["glass_type"];
        //                int.TryParse((string)reader["glass_code"], out intTemp);
        //                glassData.GlassCode = intTemp;
        //                glassData.GlassID = (string)reader["glass_id"];
        //                glassData.GlassJudge = (string)reader["glass_judge"];
        //                glassData.GlassSpecificData = (string)reader["glass_specific_data"];
        //                glassData.GlassAddData = (string)reader["glass_add_data"];
        //                //glassData.GlassVariety = (enumGlassVariety)Enum.Parse(typeof(enumGlassVariety), (string)reader["glass_variety"]);

        //                glassData.GlassProcessingStatus = (string)reader["glass_processing_status"];
        //                glassData.OriginalCassetteID = (string)reader["original_cassette_id"];
        //                int.TryParse((string)reader["glass_route_path"], out intTemp);
        //                glassData.GlassRoutePath = intTemp;
        //                glassData.GlassCurrentLocation = (string)reader["glass_current_loc"];

        //                glassData.PreviousUnitProcessingData = (string)reader["prev_unit_processing_data"];

        //                glassData.CurrentLocation = (string)reader["current_loc"];

        //                glassData.CreateTime = (DateTime)reader["create_time"];
        //                glassData.ModifyTime = (DateTime)reader["modify_time"];

        //                glassData.MainPNLIF = (string)reader["main_pnl_if"];
        //                glassData.SubPNLIF = (string)reader["sub_pnl_if"];
        //                glassData.OriginalPortID = (string)reader["original_port_id"];
        //                glassData.OriginalSlotID = (string)reader["original_slot_id"];
        //                glassData.SampleCode = (string)reader["sample_code"];
        //                glassData.STRING_GSD = (string)reader["string_gsd"];

        //                glassData.IsProcessed = (string)reader["is_processed"] == "TRUE" ? true : false;
        //                glassData.IsScraped = (string)reader["is_scraped"] == "TRUE" ? true : false;

        //                try
        //                {
        //                    glassData.MAIN_GLASS_TYPE = (string)reader["main_glass_type"];
        //                    glassData.SUB_GLASS_TYPE = (string)reader["sub_glass_type"];
        //                    glassData.IsCIMGenerateData = (string)reader["is_cim_generate_data"] == "TRUE" ? true : false;
        //                    glassData.CurrentCSTID = (string)reader["current_cst_id"];
        //                }
        //                catch { }

        //                if (glassDatas.ContainsKey(glassData.GlassCode) == false)
        //                    glassDatas.Add(glassData.GlassCode, glassData);

        //                //로그 남겨야하는디
        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "EMP", ex));
        //        Console.WriteLine(ex.StackTrace);
        //        //if (OnLogEvent != null)
        //        //    OnLogEvent(new CRecipeLogData(SOFD.Logger.Catagory.Error, METHOD, "sql error \n" + ex.StackTrace));
        //    }

        //    if (reader != null)
        //        reader.Close();

        //    return glassDatas;
        //}
        //public static int LoadLastGlassCodeData(string dbName)
        //{
        //    int iNum = 0;
        //    SqlDataReader reader = null;
        //    try
        //    {
        //        using (SqlConnection connection = GetDBControl(dbName).GetOpenConnection())
        //        {
        //            SqlCommand readCommand = connection.CreateCommand();                    
        //            readCommand.CommandText = "select * from system_data";
        //            readCommand.CommandTimeout = 15;
        //            readCommand.Connection = connection;
        //            reader = readCommand.ExecuteReader();

        //            if (reader.Read())
        //            {
        //                int intTemp = 0;

        //                int.TryParse((string)reader["last_glass_code"], out intTemp);
        //                iNum = intTemp;                       
        //            }

        //            reader.Close();
        //            reader.Dispose();
        //        }
        //        return iNum;
        //    }
        //    catch (SqlException ex)
        //    {
        //        CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "EMP", ex));
        //    }
        //    finally
        //    {
        //        if (reader != null) reader.Close();
        //    }

        //    return 0;
        //}
        //public static bool SaveLastGlassCodeData(string dbName, int iCode)
        //{

        //    try
        //    {
        //        using (SqlConnection connection = GetDBControl(dbName).GetOpenConnection())
        //        {
        //            SqlCommand command = connection.CreateCommand();

        //            command.Parameters.Add(new SqlParameter("@last_glass_code", System.Data.SqlDbType.VarChar)).Value = iCode.ToString();

        //            command.CommandText = "update system_data set " +
        //                "last_glass_code=@last_glass_code";

        //            command.Connection = connection;
        //            command.ExecuteNonQuery();
        //        }
        //        return true;
        //    }
        //    catch (SqlException ex)
        //    {

        //        CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "EMP", ex));
        //    }

        //    return false;
        //}        
        //public override bool Add()
        //{

        //    SqlDataReader reader = null;
        //    try
        //    {
        //        using (SqlConnection connection = DbControl.GetOpenConnection())
        //        {
        //            SqlCommand readCommand = connection.CreateCommand();

        //            readCommand.Parameters.Add(new SqlParameter("@glass_code", System.Data.SqlDbType.VarChar)).Value = GlassCode.ToString();
        //            readCommand.CommandText = "select * from glass_data where glass_code=@glass_code";
        //            readCommand.Connection = connection;
        //            reader = readCommand.ExecuteReader();

        //            if (reader.Read())
        //            {
        //                reader.Close();
        //            }
        //            else
        //            {
        //                reader.Close();

        //                SqlCommand command = connection.CreateCommand();

        //                //신규
        //                command.Parameters.Add(new SqlParameter("@eqp_recipe_number", System.Data.SqlDbType.VarChar)).Value = EQPRecipeNumber + "";
        //                command.Parameters.Add(new SqlParameter("@glass_judge_code", System.Data.SqlDbType.VarChar)).Value = GlassJudgeCode.ToString();
        //                command.Parameters.Add(new SqlParameter("@lot_code", System.Data.SqlDbType.VarChar)).Value = LOTCode.ToString();


        //                command.Parameters.Add(new SqlParameter("@lot_id", System.Data.SqlDbType.VarChar)).Value = LotID == null ? "" : LotID;
        //                command.Parameters.Add(new SqlParameter("@processing_code", System.Data.SqlDbType.VarChar)).Value = ProcessingCode == null ? "" : ProcessingCode.ToString();
        //                command.Parameters.Add(new SqlParameter("@lot_specific_data", System.Data.SqlDbType.VarChar)).Value = LotSpecificData == null ? "" : LotSpecificData;
        //                command.Parameters.Add(new SqlParameter("@host_recipe_number", System.Data.SqlDbType.VarChar)).Value = HostRecipeNumber.ToString();
        //                command.Parameters.Add(new SqlParameter("@glass_type", System.Data.SqlDbType.VarChar)).Value = GlassType == null ? "" : GlassType;
        //                command.Parameters.Add(new SqlParameter("@glass_code", System.Data.SqlDbType.VarChar)).Value = GlassCode.ToString();

        //                command.Parameters.Add(new SqlParameter("@glass_id", System.Data.SqlDbType.VarChar)).Value = GlassID == null ? "" : GlassID;
        //                command.Parameters.Add(new SqlParameter("@glass_judge", System.Data.SqlDbType.VarChar)).Value = GlassJudge == null ? "" : GlassJudge;
        //                command.Parameters.Add(new SqlParameter("@glass_specific_data", System.Data.SqlDbType.VarChar)).Value = GlassSpecificData == null ? "" : GlassSpecificData;
        //                command.Parameters.Add(new SqlParameter("@glass_add_data", System.Data.SqlDbType.VarChar)).Value = GlassAddData == null ? "" : GlassAddData;
        //                //command.Parameters.Add(new SqlParameter("@glass_variety", System.Data.SqlDbType.VarChar)).Value = GlassVariety.ToString();

        //                command.Parameters.Add(new SqlParameter("@glass_processing_status", System.Data.SqlDbType.VarChar)).Value = GlassProcessingStatus == null ? "" : GlassProcessingStatus;
        //                command.Parameters.Add(new SqlParameter("@original_cassette_id", System.Data.SqlDbType.VarChar)).Value = OriginalCassetteID == null ? "" : OriginalCassetteID;
        //                command.Parameters.Add(new SqlParameter("@glass_route_path", System.Data.SqlDbType.VarChar)).Value = GlassRoutePath.ToString();
        //                command.Parameters.Add(new SqlParameter("@glass_current_loc", System.Data.SqlDbType.VarChar)).Value = GlassCurrentLocation == null ? "" : GlassCurrentLocation;

        //                command.Parameters.Add(new SqlParameter("@glass_current_tm_loc", System.Data.SqlDbType.VarChar)).Value = "";


        //                command.Parameters.Add(new SqlParameter("@prev_unit_processing_data", System.Data.SqlDbType.VarChar)).Value = PreviousUnitProcessingData == null ? "" : PreviousUnitProcessingData;

        //                command.Parameters.Add(new SqlParameter("@current_loc", System.Data.SqlDbType.VarChar)).Value = CurrentLocation == null ? "" : CurrentLocation;

        //                command.Parameters.Add(new SqlParameter("@create_time", System.Data.SqlDbType.DateTime)).Value = _createTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
        //                command.Parameters.Add(new SqlParameter("@modify_time", System.Data.SqlDbType.DateTime)).Value = _modifyTime.ToString("yyyy-MM-dd HH:mm:ss.fff");


        //                command.Parameters.Add(new SqlParameter("@main_pnl_if", System.Data.SqlDbType.VarChar)).Value = MainPNLIF == null ? "" : MainPNLIF;
        //                command.Parameters.Add(new SqlParameter("@sub_pnl_if", System.Data.SqlDbType.VarChar)).Value = SubPNLIF == null ? "" : SubPNLIF;
        //                command.Parameters.Add(new SqlParameter("@original_port_id", System.Data.SqlDbType.VarChar)).Value = OriginalPortID == null ? "" : OriginalPortID;
        //                command.Parameters.Add(new SqlParameter("@original_slot_id", System.Data.SqlDbType.VarChar)).Value = OriginalSlotID == null ? "" : OriginalSlotID;
        //                command.Parameters.Add(new SqlParameter("@sample_code", System.Data.SqlDbType.VarChar)).Value = SampleCode == null ? "" : SampleCode;
        //                command.Parameters.Add(new SqlParameter("@string_gsd", System.Data.SqlDbType.VarChar)).Value = STRING_GSD == null ? "" : STRING_GSD;

        //                command.Parameters.Add(new SqlParameter("@is_processed", System.Data.SqlDbType.VarChar)).Value = IsProcessed == true ? "TRUE" : "FALSE";
        //                command.Parameters.Add(new SqlParameter("@is_scraped", System.Data.SqlDbType.VarChar)).Value = IsScraped == true ? "TRUE" : "FALSE";

        //                command.Parameters.Add(new SqlParameter("@main_glass_type", System.Data.SqlDbType.VarChar)).Value = MAIN_GLASS_TYPE == null ? "" : MAIN_GLASS_TYPE;                        
        //                command.Parameters.Add(new SqlParameter("@sub_glass_type", System.Data.SqlDbType.VarChar)).Value = SUB_GLASS_TYPE == null ? "" : SUB_GLASS_TYPE;

        //                command.Parameters.Add(new SqlParameter("@is_cim_generate_data", System.Data.SqlDbType.VarChar)).Value = IsCIMGenerateData == true ? "TRUE" : "FALSE";
        //                command.Parameters.Add(new SqlParameter("@current_cst_id", System.Data.SqlDbType.VarChar)).Value = CurrentCSTID == null ? "" : CurrentCSTID;
        //                command.Connection = connection;
        //                command.CommandText = "insert into glass_data " +
        //                    "(eqp_recipe_number, glass_judge_code, lot_code, lot_id, processing_code, lot_specific_data, host_recipe_number, glass_type, glass_code, glass_id, glass_judge, glass_specific_data, glass_add_data, glass_processing_status, original_cassette_id, glass_route_path, glass_current_loc, glass_current_tm_loc, prev_unit_processing_data, current_loc, create_time, modify_time, main_pnl_if, sub_pnl_if, original_port_id, original_slot_id, sample_code, string_gsd, is_processed, is_scraped, main_glass_type, sub_glass_type, is_cim_generate_data, current_cst_id) " +
        //                    "values (@eqp_recipe_number, @glass_judge_code, @lot_code, @lot_id, @processing_code, @lot_specific_data, @host_recipe_number, @glass_type, @glass_code, @glass_id, @glass_judge, @glass_specific_data, @glass_add_data, @glass_processing_status, @original_cassette_id, @glass_route_path, @glass_current_loc, @glass_current_tm_loc, @prev_unit_processing_data, @current_loc, @create_time, @modify_time, @main_pnl_if, @sub_pnl_if, @original_port_id, @original_slot_id, @sample_code, @string_gsd, @is_processed, @is_scraped, @main_glass_type, @sub_glass_type, @is_cim_generate_data, @current_cst_id)";
        //                command.ExecuteNonQuery();

        //                return true;
        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "EMP", ex));
        //    }
        //    finally
        //    {
        //        if (reader != null) reader.Close();
        //    }
        //    return false;
        //}
        //public override bool Delete()
        //{
        //    try
        //    {
        //        using (SqlConnection connection = DbControl.GetOpenConnection())
        //        {
        //            SqlCommand command = connection.CreateCommand();
        //            command.Parameters.Add(new SqlParameter("@glass_code", System.Data.SqlDbType.VarChar)).Value = GlassCode.ToString();
        //            command.CommandText = "delete from glass_data where glass_code=@glass_code";
        //            command.Connection = connection;
        //            command.ExecuteNonQuery();
        //        }
        //        return true;
        //    }
        //    catch (SqlException ex)
        //    {
        //        CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "EMP", ex));
        //    }

        //    return false;
        //}
        //public override bool Save()
        //{

        //    try
        //    {
        //        using (SqlConnection connection = DbControl.GetOpenConnection())
        //        {
        //            SqlCommand command = connection.CreateCommand();

        //            command.Parameters.Add(new SqlParameter("@eqp_recipe_number", System.Data.SqlDbType.VarChar)).Value = EQPRecipeNumber == null ? "" : EQPRecipeNumber;
        //            command.Parameters.Add(new SqlParameter("@glass_judge_code", System.Data.SqlDbType.VarChar)).Value = GlassJudgeCode.ToString();
        //            command.Parameters.Add(new SqlParameter("@lot_code", System.Data.SqlDbType.VarChar)).Value = LOTCode.ToString();


        //            command.Parameters.Add(new SqlParameter("@lot_id", System.Data.SqlDbType.VarChar)).Value = LotID == null ? "" : LotID;
        //            command.Parameters.Add(new SqlParameter("@processing_code", System.Data.SqlDbType.VarChar)).Value = ProcessingCode == null ? "" : ProcessingCode.ToString();
        //            command.Parameters.Add(new SqlParameter("@lot_specific_data", System.Data.SqlDbType.VarChar)).Value = LotSpecificData == null ? "" : LotSpecificData;
        //            command.Parameters.Add(new SqlParameter("@host_recipe_number", System.Data.SqlDbType.VarChar)).Value = HostRecipeNumber.ToString();
        //            command.Parameters.Add(new SqlParameter("@glass_type", System.Data.SqlDbType.VarChar)).Value = GlassType == null ? "" : GlassType;
        //            command.Parameters.Add(new SqlParameter("@glass_code", System.Data.SqlDbType.VarChar)).Value = GlassCode.ToString();

        //            command.Parameters.Add(new SqlParameter("@glass_id", System.Data.SqlDbType.VarChar)).Value = GlassID == null ? "" : GlassID;
        //            command.Parameters.Add(new SqlParameter("@glass_judge", System.Data.SqlDbType.VarChar)).Value = GlassJudge == null ? "" : GlassJudge;
        //            command.Parameters.Add(new SqlParameter("@glass_specific_data", System.Data.SqlDbType.VarChar)).Value = GlassSpecificData == null ? "" : GlassSpecificData;
        //            command.Parameters.Add(new SqlParameter("@glass_add_data", System.Data.SqlDbType.VarChar)).Value = GlassAddData == null ? "" : GlassAddData;
        //            //command.Parameters.Add(new SqlParameter("@glass_variety", System.Data.SqlDbType.VarChar)).Value = GlassVariety.ToString();

        //            command.Parameters.Add(new SqlParameter("@glass_processing_status", System.Data.SqlDbType.VarChar)).Value = GlassProcessingStatus == null ? "" : GlassProcessingStatus;
        //            command.Parameters.Add(new SqlParameter("@original_cassette_id", System.Data.SqlDbType.VarChar)).Value = OriginalCassetteID == null ? "" : OriginalCassetteID;
        //            command.Parameters.Add(new SqlParameter("@glass_route_path", System.Data.SqlDbType.VarChar)).Value = GlassRoutePath.ToString();
        //            command.Parameters.Add(new SqlParameter("@glass_current_loc", System.Data.SqlDbType.VarChar)).Value = GlassCurrentLocation == null ? "" : GlassCurrentLocation;

        //            command.Parameters.Add(new SqlParameter("@glass_current_tm_loc", System.Data.SqlDbType.VarChar)).Value = GlassCurrentLocation == null ? "" : GlassCurrentLocation;


        //            command.Parameters.Add(new SqlParameter("@prev_unit_processing_data", System.Data.SqlDbType.VarChar)).Value = PreviousUnitProcessingData == null ? "" : PreviousUnitProcessingData;

        //            command.Parameters.Add(new SqlParameter("@current_loc", System.Data.SqlDbType.VarChar)).Value = CurrentLocation == null ? "" : CurrentLocation;

        //            command.Parameters.Add(new SqlParameter("@create_time", System.Data.SqlDbType.DateTime)).Value = _createTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
        //            command.Parameters.Add(new SqlParameter("@modify_time", System.Data.SqlDbType.DateTime)).Value = _modifyTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

        //            command.Parameters.Add(new SqlParameter("@main_pnl_if", System.Data.SqlDbType.VarChar)).Value = MainPNLIF == null ? "" : MainPNLIF;
        //            command.Parameters.Add(new SqlParameter("@sub_pnl_if", System.Data.SqlDbType.VarChar)).Value = SubPNLIF == null ? "" : SubPNLIF;
        //            command.Parameters.Add(new SqlParameter("@original_port_id", System.Data.SqlDbType.VarChar)).Value = OriginalPortID == null ? "" : OriginalPortID;
        //            command.Parameters.Add(new SqlParameter("@original_slot_id", System.Data.SqlDbType.VarChar)).Value = OriginalSlotID == null ? "" : OriginalSlotID;
        //            command.Parameters.Add(new SqlParameter("@sample_code", System.Data.SqlDbType.VarChar)).Value = SampleCode == null ? "" : SampleCode;
        //            command.Parameters.Add(new SqlParameter("@string_gsd", System.Data.SqlDbType.VarChar)).Value = STRING_GSD == null ? "" : STRING_GSD;


        //            command.Parameters.Add(new SqlParameter("@is_processed", System.Data.SqlDbType.VarChar)).Value = IsProcessed == true ? "TRUE" : "FALSE";
        //            command.Parameters.Add(new SqlParameter("@is_scraped", System.Data.SqlDbType.VarChar)).Value = IsScraped == true ? "TRUE" : "FALSE";

        //            command.Parameters.Add(new SqlParameter("@main_glass_type", System.Data.SqlDbType.VarChar)).Value = MAIN_GLASS_TYPE == null ? "" : MAIN_GLASS_TYPE;
        //            command.Parameters.Add(new SqlParameter("@sub_glass_type", System.Data.SqlDbType.VarChar)).Value = SUB_GLASS_TYPE == null ? "" : SUB_GLASS_TYPE;

        //            command.Parameters.Add(new SqlParameter("@is_cim_generate_data", System.Data.SqlDbType.VarChar)).Value = IsCIMGenerateData == true ? "TRUE" : "FALSE";
        //            command.Parameters.Add(new SqlParameter("@current_cst_id", System.Data.SqlDbType.VarChar)).Value = CurrentCSTID == null ? "" : CurrentCSTID;
        //            command.CommandText = "update glass_data set " +
        //                "eqp_recipe_number=@eqp_recipe_number, glass_judge_code=@glass_judge_code, lot_code=@lot_code, lot_id=@lot_id, processing_code=@processing_code, lot_specific_data=@lot_specific_data, host_recipe_number=@host_recipe_number, glass_type=@glass_type, " +
        //                "glass_code=@glass_code, glass_id=@glass_id, glass_judge=@glass_judge, glass_specific_data=@glass_specific_data, glass_add_data=@glass_add_data, " +
        //                "glass_processing_status=@glass_processing_status, original_cassette_id=@original_cassette_id, glass_route_path=@glass_route_path, glass_current_loc=@glass_current_loc, " +
        //                "prev_unit_processing_data=@prev_unit_processing_data, current_loc=@current_loc,  create_time=@create_time, modify_time=@modify_time, " +
        //                "main_pnl_if=@main_pnl_if, sub_pnl_if=@sub_pnl_if, original_port_id=@original_port_id, original_slot_id=@original_slot_id, sample_code=@sample_code, string_gsd=@string_gsd, " +
        //                "is_processed=@is_processed, is_scraped=@is_scraped, main_glass_type=@main_glass_type, sub_glass_type=@sub_glass_type, is_cim_generate_data=@is_cim_generate_data, current_cst_id=@current_cst_id " +
        //                "where glass_code=@glass_code";
        //            command.Connection = connection;
        //            command.ExecuteNonQuery();
        //        }
        //        return true;
        //    }
        //    catch (SqlException ex)
        //    {

        //        CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "EMP", ex));
        //    }

        //    return false;
        //}
        //public override bool Load()
        //{
        //    SqlDataReader reader = null;
        //    try
        //    {
        //        using (SqlConnection connection = DbControl.GetOpenConnection())
        //        {
        //            SqlCommand readCommand = connection.CreateCommand();
        //            readCommand.Parameters.Add("@glass_code", System.Data.SqlDbType.VarChar).Value = GlassCode.ToString();
        //            readCommand.CommandText = "select * from glass_data where glass_code=@glass_code";
        //            readCommand.CommandTimeout = 15;
        //            readCommand.Connection = connection;
        //            reader = readCommand.ExecuteReader();

        //            if (reader.Read())
        //            {
        //                int intTemp = 0;

        //                EQPRecipeNumber = (string)reader["eqp_recipe_number"];
        //                int.TryParse((string)reader["glass_judge_code"], out intTemp);
        //                GlassJudgeCode = intTemp;
        //                int.TryParse((string)reader["lot_code"], out intTemp);
        //                LOTCode = intTemp;

        //                LotID = (string)reader["lot_id"];
        //                ProcessingCode = (string)reader["processing_code"];
        //                LotSpecificData = (string)reader["lot_specific_data"];

        //                int.TryParse((string)reader["host_recipe_number"], out intTemp);

        //                HostRecipeNumber = intTemp;
        //                GlassType = (string)reader["glass_type"];

        //                int.TryParse((string)reader["glass_code"], out intTemp);
        //                GlassCode = intTemp;
        //                GlassID = (string)reader["glass_id"];
        //                GlassJudge = (string)reader["glass_judge"];
        //                GlassSpecificData = (string)reader["glass_specific_data"];
        //                GlassAddData = (string)reader["glass_add_data"];
        //                //GlassVariety = (enumGlassVariety)Enum.Parse(typeof(enumGlassVariety), (string)reader["glass_variety"]);

        //                GlassProcessingStatus = (string)reader["glass_processing_status"];
        //                OriginalCassetteID = (string)reader["original_cassette_id"];
        //                int.TryParse((string)reader["glass_route_path"], out intTemp);
        //                GlassRoutePath = intTemp;
        //                GlassCurrentLocation = (string)reader["glass_current_loc"];

        //                PreviousUnitProcessingData = (string)reader["prev_unit_processing_data"];

        //                CurrentLocation = (string)reader["current_loc"];

        //                _createTime = (DateTime)reader["create_time"];
        //                _modifyTime = (DateTime)reader["modify_time"];

        //                MainPNLIF = (string)reader["main_pnl_if"];
        //                SubPNLIF = (string)reader["sub_pnl_if"];
        //                OriginalPortID = (string)reader["original_port_id"];
        //                OriginalSlotID = (string)reader["original_slot_id"];
        //                SampleCode = (string)reader["sample_code"];
        //                STRING_GSD = (string)reader["string_gsd"];

        //                IsProcessed = (string)reader["is_processed"] == "TRUE" ? true : false;
        //                IsScraped = (string)reader["is_scraped"] == "TRUE" ? true : false;

        //                MAIN_GLASS_TYPE = (string)reader["main_glass_type"];
        //                SUB_GLASS_TYPE = (string)reader["sub_glass_type"];

        //                IsCIMGenerateData = (string)reader["is_cim_generate_data"] == "TRUE" ? true : false;
        //                CurrentCSTID = (string)reader["current_cst_id"];
        //            }

        //            reader.Close();
        //            reader.Dispose();
        //        }
        //        return true;
        //    }
        //    catch (SqlException ex)
        //    {
        //        CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "EMP", ex));
        //    }
        //    finally
        //    {
        //        if (reader != null) reader.Close();
        //    }

        //    return false;
        //}

        #endregion

        public static List<int> ConvertPLCData(CGlassDataPropertiesWHTM glassData)
        {
            List<int> plcData = new List<int>();
            if (glassData == null)
            {
                plcData.AddRange(CovertIntList(96));
                return plcData;
            }
            plcData.Add(glassData.CassetteIndex);
            plcData.Add(glassData.GlassIndex);//glassData.GlassIndex);  glassData.CassetteIndex & 0xFFFF | glassData.CassetteIndex >> 8
            plcData.Add(glassData.ProductCode);
            plcData.Add(glassData.GlassThickness);
            plcData.AddRange(CovertStringToWordList(glassData.LotID, 10));
            plcData.AddRange(CovertStringToWordList(glassData.GlassID, 10));
            plcData.AddRange(CovertStringToWordList(glassData.PPID, 10));
            plcData.Add(glassData.GlassType);
            plcData.AddRange(CovertStringToWordList(glassData.JobJudge, 1));
            plcData.AddRange(CovertStringToWordList(glassData.JobGrade, 1));
            plcData.Add(glassData.JobState);
            plcData.Add((ushort)(glassData.TrackingData & 0xFFFF));
            plcData.Add((ushort)(glassData.TrackingData >> 16 & 0xFFFF));
            plcData.Add((ushort)(glassData.TrackingData >> 32 & 0xFFFF));
            plcData.Add((ushort)(glassData.TrackingData >> 48 & 0xFFFF));
            plcData.Add(glassData.UnitPathNo);
            plcData.Add(glassData.SlotNo);

            plcData.AddRange(ByteArrayToIntArray(PLCDataConverter.SystemFloatToPLC4Byte(glassData.CycleTime), 0, 2));
            plcData.AddRange(ByteArrayToIntArray(PLCDataConverter.SystemFloatToPLC4Byte(glassData.TactTime), 0, 2));

            //plcData.Add((int)(glassData.CycleTime & 0xFFFF ));
            //plcData.Add((int)(glassData.CycleTime >> 16));
            //plcData.Add((int)(glassData.TactTime & 0xFFFF ));
            //plcData.Add((int)(glassData.TactTime >> 16));
            plcData.Add(glassData.ReasonCode);
            plcData.Add(glassData.SamplingFlag);
            plcData.Add(glassData.LotEndFlag);
            plcData.AddRange(CovertStringToWordList(glassData.OperationId, 5));
            plcData.AddRange(CovertStringToWordList(glassData.ProductId, 10));
            plcData.AddRange(CovertStringToWordList(glassData.CassetteId, 5));
            plcData.AddRange(CovertStringToWordList(glassData.Reserved1, 25));




            return plcData;
        }

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
        public static byte[] ushortArrayToByteArray(ushort[] data, int start, int wordLength)
        {
            int arrayCount = wordLength * 2;
            if (data.Length > start + arrayCount)
            {
                byte[] temp = new byte[arrayCount];
                int j = 0;
                for (int i = 0; i < wordLength; i++)
                {
                    temp[j++] = ((byte)(data[start + i] & 0xFF));
                    temp[j++] = ((byte)(data[start + i] >> 8));
                }
                return temp;
            }
            else
            {
                throw new ArgumentOutOfRangeException("start and wordLength * 2 less then data's length");
            }
        }

        public static List<int> ConvertPLCDataB(CGlassDataPropertiesWHTM glassData)
        {
            List<int> plcData = new List<int>();
            if (glassData == null)
            {
                plcData.AddRange(CovertIntList(26));
                return plcData;
            }
            plcData.Add(glassData.CassetteIndex);
            plcData.Add(glassData.GlassIndex);
            plcData.AddRange(CovertStringToWordList(glassData.LotID, 10));
            plcData.AddRange(CovertStringToWordList(glassData.GlassID, 10));
            plcData.Add(glassData.UnitPathNo);
            plcData.Add(glassData.SlotNo);
            plcData.AddRange(CovertStringToWordList(glassData.JobJudge, 1));
            plcData.AddRange(CovertStringToWordList(glassData.JobGrade, 1));
            //plcData.Add(0);
            //plcData.Add(0);


            return plcData;
        }
        public static List<int> ConvertPLCDataC(CGlassDataPropertiesWHTM glassData)
        {
            List<int> plcData = new List<int>();
            if (glassData == null)
            {
                plcData.AddRange(CovertIntList(42));
                return plcData;
            }

            plcData.AddRange(CovertStringToWordList(glassData.LotID, 10));
            plcData.AddRange(CovertStringToWordList(glassData.GlassID, 10));
            plcData.Add(glassData.UnitPathNo);
            plcData.Add(glassData.SlotNo);
            plcData.Add(glassData.TransportState);
            plcData.Add(glassData.JobStateInt);
            plcData.AddRange(CovertStringToWordList(glassData.PPID, 10));
            plcData.Add(glassData.ProcessedTime);

            if (glassData.ProcessedStartTime != "")
            {
                DateTime yearTemp = new DateTime(); //DateTime.Parse(glassData.ProcessedStartTime);// DateTime.Now.Year.ToString();

                try
                {
                    if (DateTime.TryParse(glassData.ProcessedStartTime, out yearTemp))
                    {
                        string temp = yearTemp.Year.ToString();

                        string mYear = ushort.Parse(temp.Substring(temp.Length - 2, 2)).ToString("00");
                        string mMonth = yearTemp.Month.ToString("00");
                        string mDay = yearTemp.Day.ToString("00");
                        string mHour = yearTemp.Hour.ToString("00");
                        string mMin = yearTemp.Minute.ToString("00");
                        string mSec = yearTemp.Second.ToString("00");




                        plcData.Add(ushort.Parse(mMonth.Substring(0, 1)) << 12 | ushort.Parse(mMonth.Substring(1, 1)) << 8 | ushort.Parse(mYear.Substring(0, 1)) << 4 | ushort.Parse(mYear.Substring(1, 1)));
                        plcData.Add(ushort.Parse(mHour.Substring(0, 1)) << 12 | ushort.Parse(mHour.Substring(1, 1)) << 8 | ushort.Parse(mDay.Substring(0, 1)) << 4 | ushort.Parse(mDay.Substring(1, 1)));
                        plcData.Add(ushort.Parse(mSec.Substring(0, 1)) << 12 | ushort.Parse(mSec.Substring(1, 1)) << 8 | ushort.Parse(mMin.Substring(0, 1)) << 4 | ushort.Parse(mMin.Substring(1, 1)));
                    }
                    else
                    {
                        plcData.Add(0);
                        plcData.Add(0);
                        plcData.Add(0);
                    }
                }
                catch (Exception ex)
                {
                    plcData.Add(0);
                    plcData.Add(0);
                    plcData.Add(0);
                }
                

                
            }
            else
            {
                plcData.Add(0);
                plcData.Add(0);
                plcData.Add(0);
            }

            if (glassData.ProcessedEndTime != "")
            {
                DateTime yearTemp1 = new DateTime(); //DateTime.Parse(glassData.ProcessedEndTime);// DateTime.Now.Year.ToString();

                try
                {
                    if (DateTime.TryParse(glassData.ProcessedStartTime, out yearTemp1))
                    {
                        string temp1 = yearTemp1.Year.ToString();

                        string mYear1 = ushort.Parse(temp1.Substring(temp1.Length - 2, 2)).ToString("00");
                        string mMonth1 = yearTemp1.Month.ToString("00");
                        string mDay1 = yearTemp1.Day.ToString("00");
                        string mHour1 = yearTemp1.Hour.ToString("00");
                        string mMin1 = yearTemp1.Minute.ToString("00");
                        string mSec1 = yearTemp1.Second.ToString("00");

                        plcData.Add(ushort.Parse(mMonth1.Substring(0, 1)) << 12 | ushort.Parse(mMonth1.Substring(1, 1)) << 8 | ushort.Parse(mYear1.Substring(0, 1)) << 4 | ushort.Parse(mYear1.Substring(1, 1)));
                        plcData.Add(ushort.Parse(mHour1.Substring(0, 1)) << 12 | ushort.Parse(mHour1.Substring(1, 1)) << 8 | ushort.Parse(mDay1.Substring(0, 1)) << 4 | ushort.Parse(mDay1.Substring(1, 1)));
                        plcData.Add(ushort.Parse(mSec1.Substring(0, 1)) << 12 | ushort.Parse(mSec1.Substring(1, 1)) << 8 | ushort.Parse(mMin1.Substring(0, 1)) << 4 | ushort.Parse(mMin1.Substring(1, 1)));
                    }
                    else
                    {
                        plcData.Add(0);
                        plcData.Add(0);
                        plcData.Add(0);
                    }
                }
                catch (Exception ex)
                {
                    plcData.Add(0);
                    plcData.Add(0);
                    plcData.Add(0);
                }
                
           
            }
            else
            {
                plcData.Add(0);
                plcData.Add(0);
                plcData.Add(0);
            }

            plcData.Add(glassData.CurrentWIPCount);

       
            return plcData;
        }

        public static List<int> CovertIntList(int MaxLength)
        {
            List<int> plcData = new List<int>();

            for (int i = 0; i < MaxLength; i++)
            {
                plcData.Add(0);
            }
            //plcData.Add(0);//OMRON STRING은 1WORD NULL 줘야함.
            return plcData;
        }


        /// <summary>
        /// ABCD  -> BADC-> HEX -> DEC 로 변환 해준다.
        /// </summary>
        /// <param name="normalString"></param>
        /// <param name="wordMaxLength">WORD 기준 총개수, 내부적으로 *2한다.</param>
        /// <returns></returns>
        public static List<int> CovertStringToWordList(string normalString, int wordMaxLength)
        {
            List<int> plcData = new List<int>();
            char[] tempLotID = normalString.ToCharArray();
            List<string> word = new List<string>();
            int maxLegnth = wordMaxLength * 2;

            for (int i = 0; i < maxLegnth; i++)
            {
                if (tempLotID.Length <= i)
                {
                    word.Insert(0, " ");
                }
                else
                {
                    word.Insert(0, tempLotID[i].ToString());
                }

                if (word.Count >= 2)
                {
                    plcData.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.StringToHex(word[0] + word[1]))));
                    word.Clear();
                }
            }
            //plcData.Add(0);//OMRON STRING은 1WORD NULL 줘야함.
            return plcData;
        }
        /// <summary>
        /// ABCD  -> BADC-> HEX -> DEC 로 변환 해준다.
        /// </summary>
        /// <param name="normalString"></param>
        /// <param name="wordMaxLength">WORD 기준 총개수, 내부적으로 *2한다.</param>
        /// <returns></returns>
        public static List<ushort> CovertStringToWordushort(string normalString, int wordMaxLength)
        {
            List<ushort> plcData = new List<ushort>();
            char[] tempLotID = normalString.ToCharArray();
            List<string> word = new List<string>();
            long maxLegnth = wordMaxLength * 2;
            for (ushort i = 0; i < maxLegnth; i++)
            {
                if (tempLotID.Length <= i)
                {
                    word.Insert(0, " ");
                }
                else
                {
                    word.Insert(0, tempLotID[i].ToString());
                }
                if (word.Count >= 2)
                {
                    plcData.Add(ushort.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.StringToHex(word[0] + word[1]))));
                    word.Clear();
                }
            }

            return plcData;
        }
        public static Dictionary<string, string> GetGuiData(CGlassDataPropertiesWHTM glassData)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            if (glassData == null)
            {
                data.Add("CassetteIndex", "");
                data.Add("GlassIndex", "");
                data.Add("ProductCode", "");
                data.Add("GlassThickness", "");
                data.Add("LotID", "");
                data.Add("GlassID", "");
                data.Add("PPID", "");
                data.Add("GlassType", "");
                data.Add("JobJudge", "");
                data.Add("JobGrade", "");
                data.Add("JobState", "");
                data.Add("TrackingData", "");
                data.Add("UnitPathNo", "");
                data.Add("SlotNo", "");
                data.Add("CycleTime", "");
                data.Add("TactTime", "");
                data.Add("ReasonCode", "");
                data.Add("SamplingFlag","");
                data.Add("LotEndFlag", "");
                data.Add("OperationId", "");
                data.Add("ProductId", "");
                data.Add("CassetteId", "");
                data.Add("Reserved1", "");

                return data;
            }
            data.Add("CassetteIndex", glassData.CassetteIndex.ToString());
            data.Add("GlassIndex", glassData.GlassIndex.ToString());
            data.Add("ProductCode", glassData.ProductCode.ToString());
            data.Add("GlassThickness", glassData.GlassThickness.ToString());
            data.Add("LotID", glassData.LotID);
            data.Add("GlassID", glassData.GlassID);
            data.Add("PPID", glassData.PPID);
            data.Add("GlassType", glassData.GlassType.ToString());
            data.Add("JobJudge", glassData.JobJudge);
            data.Add("JobGrade", glassData.JobGrade);
            data.Add("JobState", glassData.JobState.ToString());
            data.Add("TrackingData", glassData.TrackingData.ToString());
            data.Add("UnitPathNo", glassData.UnitPathNo.ToString());
            data.Add("SlotNo", glassData.SlotNo.ToString());
            data.Add("CycleTime", glassData.CycleTime.ToString());
            data.Add("TactTime", glassData.TactTime.ToString());
            data.Add("ReasonCode", glassData.ReasonCode.ToString());
            data.Add("SamplingFlag", glassData.SamplingFlag.ToString());
            data.Add("LotEndFlag", glassData.LotEndFlag.ToString());
            data.Add("OperationId", glassData.OperationId);
            data.Add("ProductId", glassData.ProductId);
            data.Add("CassetteId", glassData.CassetteId);
            data.Add("Reserved1", glassData.Reserved1);

            return data;
        }

        public static Dictionary<string, string> GetClearData()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("CassetteIndex", "");
            data.Add("GlassIndex", "");
            data.Add("ProductCode", "");
            data.Add("GlassThickness", "");
            data.Add("LotID", "");
            data.Add("GlassID", "");
            data.Add("PPID", "");
            data.Add("GlassType", "");
            data.Add("JobJudge", "");
            data.Add("JobGrade", "");
            data.Add("JobState", "");
            data.Add("TrackingData", "");
            data.Add("UnitPathNo", "");
            data.Add("SlotNo", "");
            data.Add("CycleTime", "");
            data.Add("TactTime", "");
            data.Add("ReasonCode", "");
            data.Add("SamplingFlag", "");
            data.Add("LotEndFlag", "");
            data.Add("OperationId", "");
            data.Add("ProductId", "");
            data.Add("CassetteId", "");
            data.Add("Reserved1", "");
            return data;
        }

        public static ushort[] GetGuiDataToPLC(Dictionary<string, string> data)
        {
            List<ushort> plcData = new List<ushort>(); 

            plcData.Add(ushort.Parse(data["CassetteIndex"]));
            plcData.Add(ushort.Parse(data["GlassIndex"]));
            plcData.Add(ushort.Parse(data["ProductCode"]));
            plcData.Add(ushort.Parse(data["GlassThickness"]));
            plcData.AddRange(CovertStringToWordushort(data["LotID"], 10));
            plcData.AddRange(CovertStringToWordushort(data["GlassID"], 10));
            plcData.AddRange(CovertStringToWordushort(data["PPID"], 10));
            plcData.Add(ushort.Parse(data["GlassType"]));
            plcData.AddRange(CovertStringToWordushort(data["JobJudge"], 1));
            plcData.AddRange(CovertStringToWordushort(data["JobGrade"], 1));
            plcData.AddRange(CovertStringToWordushort(data["JobState"], 1));
            plcData.Add((ushort)(ulong.Parse(data["TrackingData"]) >> 64));
            plcData.Add((ushort)(ulong.Parse(data["TrackingData"]) >> 32));
            plcData.Add((ushort)(ulong.Parse(data["TrackingData"]) >> 16));
            plcData.Add((ushort)(ulong.Parse(data["TrackingData"]) & 0xFFFF));
            plcData.Add(ushort.Parse(data["UnitPathNo"]));
            plcData.Add(ushort.Parse(data["SlotNo"]));
            plcData.Add((ushort)(uint.Parse(data["CycleTime"]) >> 16));
            plcData.Add((ushort)(uint.Parse(data["CycleTime"]) & 0xFFFF));
            plcData.Add((ushort)(uint.Parse(data["TactTime"]) >> 16));
            plcData.Add((ushort)(uint.Parse(data["TactTime"]) & 0xFFFF));
            plcData.Add(ushort.Parse(data["ReasonCode"]));
            plcData.Add(ushort.Parse(data["SamplingFlag"]));
            plcData.Add(ushort.Parse(data["LotEndFlag"]));
            plcData.AddRange(CovertStringToWordushort(data["OperationId"], 10));
            plcData.AddRange(CovertStringToWordushort(data["ProductId"], 5));
            plcData.AddRange(CovertStringToWordushort(data["CassetteId"], 10));
            plcData.AddRange(CovertStringToWordushort(data["Reserved1"], 25));

            return plcData.ToArray();

        }

        public static Dictionary<string, string> GetRemovedData(string[] glassData)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("CassetteIndex", glassData[0]);
            data.Add("GlassIndex", glassData[1]);
            data.Add("ProductCode", glassData[2]);
            data.Add("GlassThickness", glassData[3]);
            data.Add("LotID", glassData[4]);
            data.Add("GlassID", glassData[5]);
            data.Add("PPID", glassData[6]);
            data.Add("GlassType", glassData[7]);
            data.Add("JobJudge", glassData[8]);
            data.Add("JobGrade", glassData[9]);
            data.Add("JobState", glassData[10]);
            data.Add("TrackingData", glassData[11]); // + glassData[12] + glassData[13] + glassData[14]);
            data.Add("UnitPathNo", glassData[12]);
            data.Add("SlotNo", glassData[13]);
            data.Add("CycleTime", glassData[14]);
            data.Add("TactTime", glassData[15]);
            data.Add("ReasonCode", glassData[16]);
            data.Add("SamplingFlag", glassData[17]);
            data.Add("LotEndFlag", glassData[18]);
            data.Add("OperationId", glassData[19]);
            data.Add("ProductId", glassData[20]);
            data.Add("CassetteId", glassData[21]);
            data.Add("Reserved1", glassData[22]);

            return data;
        }

        public static string GetSaveData(CGlassDataPropertiesWHTM glassData)
        {
            Dictionary<string, string> data = GetGuiData(glassData);
            string temp = "";

            foreach (string item in data.Values)
            {
                temp += string.Format("{0},", item.ToString().Trim());
            }
            temp = temp.Substring(0, temp.Length - 1);
            return temp;
        }
    }

    public class CGlassDataProperties : AMaterialData
    {
        #region //member's
        public const string CLASS = "CGlassDataProperties";

        #endregion

        #region //property's

        //64 Word 영역 순서
        public string LotID { get; set; }
        public string GlassID { get; set; }
        public string OperID { get; set; }
        /// <summary>
        /// GlassCodeXXYYYY + GlassCodeZZZ, xxyyyy+zzz = xxyyyyzzz, xx=port no(1~12), yyyy=seq no, zzz=slot no
        /// </summary>
        public string GlassCode
        {
            get { return string.Format("{0}{1}", this.GlassCodeXXYYYY, this.GlassCodeZZZ.ToString("000")); }
        }
        public int GlassCodeXXYYYY { get; set; }
        public int GlassCodeZZZ { get; set; }
        public string GlassJudgeCode { get; set; }
        public int PPID { get; set; }
        public string ProdID { get; set; }
        public int CIMPCData1 { get; set; }
        public int CIMPCData2 { get; set; }
        public int ProcFlag1 { get; set; }
        public int ProcFlag2 { get; set; }
        public int JudgeFlag1 { get; set; }
        public int JudgeFlag2 { get; set; }
        public int SkipFlag1 { get; set; }
        public int SkipFlag2 { get; set; }
        public int InspectionFlag1 { get; set; }
        public int InspectionFlag2 { get; set; }
        public int Mode { get; set; }
        public int GlassType1 { get; set; }
        public int GlassType2 { get; set; }
        public int DummyType { get; set; }
        public int ReservedData1 { get; set; }
        public int ReservedData2 { get; set; }
        public int ReservedData3 { get; set; }
        public int ReservedData4 { get; set; }
        public int ReservedData5 { get; set; }
        public int ReservedData6 { get; set; }
        /// <summary>
        /// BC로 부터 받은 Recipe No
        /// </summary>
        public int RecipeNo { get; set; }
        //WHTM
        public int CassetteIndex = 0;
        public int GlassIndex = 0;
        public int ProductCode = 0;
        public int GlassThickness = 0;
        //public string LotID = "";
        //public string GlassID = "";
        //public string PPID = "";
        public int GlassType = 0;
        public string JobJudge = "";
        public string JobGrade = "";
        public string JobState = "";
        public int TrackingData = 0;
        public int UnitPathNo = 0;
        public int SLogNo = 0;
        public string CycleTime = "";
        public string TactTime = "";
        public int ReasonCode = 0;
        public string SamplingFlag = "";
        public int LotEndFlag = 0;
        public string OperationId = "";
        public string ProductId = "";
        public string CassetteId = "";
        public string Reserved1 = "";



        #endregion

        #region //constructor's


        public CGlassDataProperties(ushort[] glassData, bool flag)
        {
            DbControl = _dbControl;
            this.GlassDataConvert(glassData, flag);
        }

        private string GetStringIn(int start, int length, ushort[] glassData)
        {    

            if (glassData == null || glassData.Length <= 0)
                throw new ArgumentNullException();

            if (start + length > glassData.Length)
                throw new ArgumentException();
     

            try
            {
                string temp = "";
                ushort[] target = new ushort[length];
                Array.Copy(glassData, start, target, 0, length);

                for (int i = 0; i < target.Length; i++)
                {
                    char _convertChar00 = Convert.ToChar(Convert.ToInt16(target[i]) & 0xff);
                    char _convertChar01 = Convert.ToChar(Convert.ToInt16(target[i]) >> 8);

                    temp += (_convertChar00.ToString() + _convertChar01.ToString());
                }
                return temp.Replace('\0', ' ').TrimEnd();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "";
        }

        private int GetIntIn(int start, ushort[] glassData, bool flag)
        {
            int temp = glassData[start] + glassData[start + 1] * 0x10000;
            string temp1 = temp.ToString();
            int mlengh = temp1.Length;
            if (flag)
            {
                return Convert.ToInt32(temp1.Substring(0,mlengh - 3));
            }
            else
            {
                return Convert.ToInt32(temp1.Substring(mlengh - 3));
            }

            return 0;
        }

        //public static int[] ByteArrayToIntArray(byte[] data, int start, int wordLength)
        //{
        //    int arrayCount = wordLength;
        //    if (data.Length > start + arrayCount)
        //    {
        //        int[] temp = new int[arrayCount];
        //        int j = 0;
        //        for (int i = 0; i < wordLength; i++)
        //        {
        //            temp[i] = (data[start + j++] | data[start + j++] << 8);
        //        }
        //        return temp;
        //    }
        //    else
        //    {
        //        throw new ArgumentOutOfRangeException("start and wordLength * 2 less then data's length");
        //    }
        //}
        //public static byte[] ushortArrayToByteArray(ushort[] data, int start, int wordLength)
        //{
        //    int arrayCount = wordLength * 2;
        //    if (data.Length > start + arrayCount)
        //    {
        //        byte[] temp = new byte[arrayCount];
        //        int j = 0;
        //        for (int i = 0; i < wordLength; i++)
        //        {
        //            temp[j++] = ((byte)(data[start + i] & 0xFF));
        //            temp[j++] = ((byte)(data[start + i] >> 8));
        //        }
        //        return temp;
        //    }
        //    else
        //    {
        //        throw new ArgumentOutOfRangeException("start and wordLength * 2 less then data's length");
        //    }
        //}


        private void GlassDataConvert(ushort[] glassData, bool flag)
        {
            try
            {
                if (glassData == null || glassData.Length <= 0)
                    return;

                //this.CassetteIndex = glassData[0];
                //this.GlassIndex = glassData[1];
                //this.ProductCode = glassData[2];
                //this.GlassThickness = glassData[3];
                //this.LotID = GetStringIn(4, 10, glassData);
                //this.GlassID = GetStringIn(15, 10, glassData);
                //this.PPID = GetStringIn(26, 10, glassData);
                //this.GlassType = glassData[37];
                //this.JobJudge = GetStringIn(38, 1, glassData);
                //this.JobGrade = GetStringIn(40, 1, glassData);
                //this.JobState = GetStringIn(42, 1, glassData);
                //this.TrackingData = glassData[44];
                //this.UnitPathNo = glassData[48];
                //this.SLogNo = glassData[49];

                //this.CycleTime = ((long)glassData[51] << 16 | (long)glassData[50]).ToString();
                //this.TactTime = ((long)glassData[53] << 16 | (long)glassData[52]).ToString();
                //this.ReasonCode = glassData[54];
                //this.SamplingFlag = glassData[55].ToString();
                //this.LotEndFlag = glassData[56];
                //this.OperationId = GetStringIn(57, 5, glassData);
                //this.ProductId = GetStringIn(63, 10, glassData);
                //this.CassetteId = GetStringIn(74, 5, glassData);
                //this.Reserved1 = GetStringIn(80, 25, glassData);

                this.LotID = GetStringIn(0, 10, glassData);
                this.GlassID = GetStringIn(10, 10, glassData);
                this.OperID = GetStringIn(20, 10, glassData);
                this.GlassCodeXXYYYY = flag == true ? GetIntIn(30, glassData, true) : glassData[30];
                this.GlassCodeZZZ = flag == true ? GetIntIn(30, glassData, false) : glassData[31];
                this.GlassJudgeCode = GetStringIn(32, 1, glassData);
                this.PPID = glassData[33];
                this.ProdID = GetStringIn(34, 10, glassData);
                this.ProcFlag1 = glassData[44];
                this.ProcFlag2 = glassData[45];
                this.JudgeFlag1 = glassData[46];
                this.JudgeFlag2 = glassData[47];
                this.SkipFlag1 = glassData[48];
                this.SkipFlag2 = glassData[49];
                this.InspectionFlag1 = glassData[50];
                this.InspectionFlag2 = glassData[51];
                this.Mode = glassData[52];
                this.GlassType1 = glassData[53];
                this.GlassType2 = glassData[54];
                this.DummyType = glassData[55];
                this.ReservedData1 = glassData[56];
                this.ReservedData2 = glassData[57];
                this.ReservedData3 = glassData[58];
                this.ReservedData4 = glassData[59];
                this.ReservedData3 = glassData[60];
                this.ReservedData3 = glassData[61];
                this.ReservedData3 = glassData[62];
                this.ReservedData3 = glassData[63];
            }
            catch (Exception ex)
            {
                CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, CExceptionLogFormat.DEFAULT_KEY, ex));
            }
        }
        #endregion

        #region //method's
        
        //public static CGlassDataPropertiesCollection LoadAll(string dbName)
        //{
        //    SqlDataReader reader = null;
        //    CGlassDataPropertiesCollection glassDatas = new CGlassDataPropertiesCollection();
        //    try
        //    {
        //        using (SqlConnection connection = GetDBControl(dbName).GetOpenConnection())
        //        {
        //            SqlCommand readCommand = connection.CreateCommand();
        //            readCommand.CommandText = "select * from glass_data";
        //            readCommand.Connection = connection;
        //            reader = readCommand.ExecuteReader();

        //            while (reader.Read())
        //            {
        //                int intTemp = 0;

        //                CGlassDataProperties glassData = new CGlassDataProperties();
        //                //신규 데이터.
        //                glassData.EQPRecipeNumber = (string)reader["eqp_recipe_number"];    
                    
                        
        //                int.TryParse((string)reader["glass_judge_code"], out intTemp);
        //                glassData.GlassJudgeCode = intTemp;

        //                int.TryParse((string)reader["lot_code"], out intTemp);
        //                glassData.LOTCode = intTemp;


        //                glassData.LotID = (string)reader["lot_id"];
        //                glassData.ProcessingCode = (string)reader["processing_code"];
        //                glassData.LotSpecificData = (string)reader["lot_specific_data"];
                        
        //                int.TryParse((string)reader["host_recipe_number"], out intTemp);
        //                glassData.HostRecipeNumber = intTemp;

        //                glassData.GlassType = (string)reader["glass_type"];
        //                int.TryParse((string)reader["glass_code"], out intTemp);
        //                glassData.GlassCode = intTemp;
        //                glassData.GlassID = (string)reader["glass_id"];
        //                glassData.GlassJudge = (string)reader["glass_judge"];
        //                glassData.GlassSpecificData = (string)reader["glass_specific_data"];
        //                glassData.GlassAddData = (string)reader["glass_add_data"];
        //                //glassData.GlassVariety = (enumGlassVariety)Enum.Parse(typeof(enumGlassVariety), (string)reader["glass_variety"]);

        //                glassData.GlassProcessingStatus = (string)reader["glass_processing_status"];
        //                glassData.OriginalCassetteID = (string)reader["original_cassette_id"];
        //                int.TryParse((string)reader["glass_route_path"], out intTemp);
        //                glassData.GlassRoutePath = intTemp;
        //                glassData.GlassCurrentLocation = (string)reader["glass_current_loc"];

        //                glassData.PreviousUnitProcessingData = (string)reader["prev_unit_processing_data"];

        //                glassData.CurrentLocation = (string)reader["current_loc"];

        //                glassData.CreateTime = (DateTime)reader["create_time"];
        //                glassData.ModifyTime = (DateTime)reader["modify_time"];

        //                glassData.MainPNLIF = (string)reader["main_pnl_if"];
        //                glassData.SubPNLIF = (string)reader["sub_pnl_if"];
        //                glassData.OriginalPortID = (string)reader["original_port_id"];
        //                glassData.OriginalSlotID = (string)reader["original_slot_id"];
        //                glassData.SampleCode = (string)reader["sample_code"];
        //                glassData.STRING_GSD = (string)reader["string_gsd"];

        //                glassData.IsProcessed = (string)reader["is_processed"] == "TRUE" ? true : false;
        //                glassData.IsScraped = (string)reader["is_scraped"] == "TRUE" ? true : false;

        //                try
        //                {
        //                    glassData.MAIN_GLASS_TYPE = (string)reader["main_glass_type"];
        //                    glassData.SUB_GLASS_TYPE = (string)reader["sub_glass_type"];
        //                    glassData.IsCIMGenerateData = (string)reader["is_cim_generate_data"] == "TRUE" ? true : false;
        //                    glassData.CurrentCSTID = (string)reader["current_cst_id"];
        //                }
        //                catch { }
                        
        //                if (glassDatas.ContainsKey(glassData.GlassCode) == false)
        //                    glassDatas.Add(glassData.GlassCode, glassData);

        //                //로그 남겨야하는디
        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "EMP", ex));
        //        Console.WriteLine(ex.StackTrace);
        //        //if (OnLogEvent != null)
        //        //    OnLogEvent(new CRecipeLogData(SOFD.Logger.Catagory.Error, METHOD, "sql error \n" + ex.StackTrace));
        //    }

        //    if (reader != null)
        //        reader.Close();

        //    return glassDatas;
        //}
        //public static int LoadLastGlassCodeData(string dbName)
        //{
        //    int iNum = 0;
        //    SqlDataReader reader = null;
        //    try
        //    {
        //        using (SqlConnection connection = GetDBControl(dbName).GetOpenConnection())
        //        {
        //            SqlCommand readCommand = connection.CreateCommand();                    
        //            readCommand.CommandText = "select * from system_data";
        //            readCommand.CommandTimeout = 15;
        //            readCommand.Connection = connection;
        //            reader = readCommand.ExecuteReader();

        //            if (reader.Read())
        //            {
        //                int intTemp = 0;

        //                int.TryParse((string)reader["last_glass_code"], out intTemp);
        //                iNum = intTemp;                       
        //            }

        //            reader.Close();
        //            reader.Dispose();
        //        }
        //        return iNum;
        //    }
        //    catch (SqlException ex)
        //    {
        //        CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "EMP", ex));
        //    }
        //    finally
        //    {
        //        if (reader != null) reader.Close();
        //    }

        //    return 0;
        //}
        //public static bool SaveLastGlassCodeData(string dbName, int iCode)
        //{

        //    try
        //    {
        //        using (SqlConnection connection = GetDBControl(dbName).GetOpenConnection())
        //        {
        //            SqlCommand command = connection.CreateCommand();

        //            command.Parameters.Add(new SqlParameter("@last_glass_code", System.Data.SqlDbType.VarChar)).Value = iCode.ToString();

        //            command.CommandText = "update system_data set " +
        //                "last_glass_code=@last_glass_code";
                        
        //            command.Connection = connection;
        //            command.ExecuteNonQuery();
        //        }
        //        return true;
        //    }
        //    catch (SqlException ex)
        //    {

        //        CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "EMP", ex));
        //    }

        //    return false;
        //}        
        //public override bool Add()
        //{

        //    SqlDataReader reader = null;
        //    try
        //    {
        //        using (SqlConnection connection = DbControl.GetOpenConnection())
        //        {
        //            SqlCommand readCommand = connection.CreateCommand();

        //            readCommand.Parameters.Add(new SqlParameter("@glass_code", System.Data.SqlDbType.VarChar)).Value = GlassCode.ToString();
        //            readCommand.CommandText = "select * from glass_data where glass_code=@glass_code";
        //            readCommand.Connection = connection;
        //            reader = readCommand.ExecuteReader();

        //            if (reader.Read())
        //            {
        //                reader.Close();
        //            }
        //            else
        //            {
        //                reader.Close();

        //                SqlCommand command = connection.CreateCommand();

        //                //신규
        //                command.Parameters.Add(new SqlParameter("@eqp_recipe_number", System.Data.SqlDbType.VarChar)).Value = EQPRecipeNumber + "";
        //                command.Parameters.Add(new SqlParameter("@glass_judge_code", System.Data.SqlDbType.VarChar)).Value = GlassJudgeCode.ToString();
        //                command.Parameters.Add(new SqlParameter("@lot_code", System.Data.SqlDbType.VarChar)).Value = LOTCode.ToString();


        //                command.Parameters.Add(new SqlParameter("@lot_id", System.Data.SqlDbType.VarChar)).Value = LotID == null ? "" : LotID;
        //                command.Parameters.Add(new SqlParameter("@processing_code", System.Data.SqlDbType.VarChar)).Value = ProcessingCode == null ? "" : ProcessingCode.ToString();
        //                command.Parameters.Add(new SqlParameter("@lot_specific_data", System.Data.SqlDbType.VarChar)).Value = LotSpecificData == null ? "" : LotSpecificData;
        //                command.Parameters.Add(new SqlParameter("@host_recipe_number", System.Data.SqlDbType.VarChar)).Value = HostRecipeNumber.ToString();
        //                command.Parameters.Add(new SqlParameter("@glass_type", System.Data.SqlDbType.VarChar)).Value = GlassType == null ? "" : GlassType;
        //                command.Parameters.Add(new SqlParameter("@glass_code", System.Data.SqlDbType.VarChar)).Value = GlassCode.ToString();

        //                command.Parameters.Add(new SqlParameter("@glass_id", System.Data.SqlDbType.VarChar)).Value = GlassID == null ? "" : GlassID;
        //                command.Parameters.Add(new SqlParameter("@glass_judge", System.Data.SqlDbType.VarChar)).Value = GlassJudge == null ? "" : GlassJudge;
        //                command.Parameters.Add(new SqlParameter("@glass_specific_data", System.Data.SqlDbType.VarChar)).Value = GlassSpecificData == null ? "" : GlassSpecificData;
        //                command.Parameters.Add(new SqlParameter("@glass_add_data", System.Data.SqlDbType.VarChar)).Value = GlassAddData == null ? "" : GlassAddData;
        //                //command.Parameters.Add(new SqlParameter("@glass_variety", System.Data.SqlDbType.VarChar)).Value = GlassVariety.ToString();

        //                command.Parameters.Add(new SqlParameter("@glass_processing_status", System.Data.SqlDbType.VarChar)).Value = GlassProcessingStatus == null ? "" : GlassProcessingStatus;
        //                command.Parameters.Add(new SqlParameter("@original_cassette_id", System.Data.SqlDbType.VarChar)).Value = OriginalCassetteID == null ? "" : OriginalCassetteID;
        //                command.Parameters.Add(new SqlParameter("@glass_route_path", System.Data.SqlDbType.VarChar)).Value = GlassRoutePath.ToString();
        //                command.Parameters.Add(new SqlParameter("@glass_current_loc", System.Data.SqlDbType.VarChar)).Value = GlassCurrentLocation == null ? "" : GlassCurrentLocation;

        //                command.Parameters.Add(new SqlParameter("@glass_current_tm_loc", System.Data.SqlDbType.VarChar)).Value = "";


        //                command.Parameters.Add(new SqlParameter("@prev_unit_processing_data", System.Data.SqlDbType.VarChar)).Value = PreviousUnitProcessingData == null ? "" : PreviousUnitProcessingData;

        //                command.Parameters.Add(new SqlParameter("@current_loc", System.Data.SqlDbType.VarChar)).Value = CurrentLocation == null ? "" : CurrentLocation;

        //                command.Parameters.Add(new SqlParameter("@create_time", System.Data.SqlDbType.DateTime)).Value = _createTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
        //                command.Parameters.Add(new SqlParameter("@modify_time", System.Data.SqlDbType.DateTime)).Value = _modifyTime.ToString("yyyy-MM-dd HH:mm:ss.fff");


        //                command.Parameters.Add(new SqlParameter("@main_pnl_if", System.Data.SqlDbType.VarChar)).Value = MainPNLIF == null ? "" : MainPNLIF;
        //                command.Parameters.Add(new SqlParameter("@sub_pnl_if", System.Data.SqlDbType.VarChar)).Value = SubPNLIF == null ? "" : SubPNLIF;
        //                command.Parameters.Add(new SqlParameter("@original_port_id", System.Data.SqlDbType.VarChar)).Value = OriginalPortID == null ? "" : OriginalPortID;
        //                command.Parameters.Add(new SqlParameter("@original_slot_id", System.Data.SqlDbType.VarChar)).Value = OriginalSlotID == null ? "" : OriginalSlotID;
        //                command.Parameters.Add(new SqlParameter("@sample_code", System.Data.SqlDbType.VarChar)).Value = SampleCode == null ? "" : SampleCode;
        //                command.Parameters.Add(new SqlParameter("@string_gsd", System.Data.SqlDbType.VarChar)).Value = STRING_GSD == null ? "" : STRING_GSD;

        //                command.Parameters.Add(new SqlParameter("@is_processed", System.Data.SqlDbType.VarChar)).Value = IsProcessed == true ? "TRUE" : "FALSE";
        //                command.Parameters.Add(new SqlParameter("@is_scraped", System.Data.SqlDbType.VarChar)).Value = IsScraped == true ? "TRUE" : "FALSE";

        //                command.Parameters.Add(new SqlParameter("@main_glass_type", System.Data.SqlDbType.VarChar)).Value = MAIN_GLASS_TYPE == null ? "" : MAIN_GLASS_TYPE;                        
        //                command.Parameters.Add(new SqlParameter("@sub_glass_type", System.Data.SqlDbType.VarChar)).Value = SUB_GLASS_TYPE == null ? "" : SUB_GLASS_TYPE;

        //                command.Parameters.Add(new SqlParameter("@is_cim_generate_data", System.Data.SqlDbType.VarChar)).Value = IsCIMGenerateData == true ? "TRUE" : "FALSE";
        //                command.Parameters.Add(new SqlParameter("@current_cst_id", System.Data.SqlDbType.VarChar)).Value = CurrentCSTID == null ? "" : CurrentCSTID;
        //                command.Connection = connection;
        //                command.CommandText = "insert into glass_data " +
        //                    "(eqp_recipe_number, glass_judge_code, lot_code, lot_id, processing_code, lot_specific_data, host_recipe_number, glass_type, glass_code, glass_id, glass_judge, glass_specific_data, glass_add_data, glass_processing_status, original_cassette_id, glass_route_path, glass_current_loc, glass_current_tm_loc, prev_unit_processing_data, current_loc, create_time, modify_time, main_pnl_if, sub_pnl_if, original_port_id, original_slot_id, sample_code, string_gsd, is_processed, is_scraped, main_glass_type, sub_glass_type, is_cim_generate_data, current_cst_id) " +
        //                    "values (@eqp_recipe_number, @glass_judge_code, @lot_code, @lot_id, @processing_code, @lot_specific_data, @host_recipe_number, @glass_type, @glass_code, @glass_id, @glass_judge, @glass_specific_data, @glass_add_data, @glass_processing_status, @original_cassette_id, @glass_route_path, @glass_current_loc, @glass_current_tm_loc, @prev_unit_processing_data, @current_loc, @create_time, @modify_time, @main_pnl_if, @sub_pnl_if, @original_port_id, @original_slot_id, @sample_code, @string_gsd, @is_processed, @is_scraped, @main_glass_type, @sub_glass_type, @is_cim_generate_data, @current_cst_id)";
        //                command.ExecuteNonQuery();

        //                return true;
        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "EMP", ex));
        //    }
        //    finally
        //    {
        //        if (reader != null) reader.Close();
        //    }
        //    return false;
        //}
        //public override bool Delete()
        //{
        //    try
        //    {
        //        using (SqlConnection connection = DbControl.GetOpenConnection())
        //        {
        //            SqlCommand command = connection.CreateCommand();
        //            command.Parameters.Add(new SqlParameter("@glass_code", System.Data.SqlDbType.VarChar)).Value = GlassCode.ToString();
        //            command.CommandText = "delete from glass_data where glass_code=@glass_code";
        //            command.Connection = connection;
        //            command.ExecuteNonQuery();
        //        }
        //        return true;
        //    }
        //    catch (SqlException ex)
        //    {
        //        CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "EMP", ex));
        //    }

        //    return false;
        //}
        //public override bool Save()
        //{

        //    try
        //    {
        //        using (SqlConnection connection = DbControl.GetOpenConnection())
        //        {
        //            SqlCommand command = connection.CreateCommand();

        //            command.Parameters.Add(new SqlParameter("@eqp_recipe_number", System.Data.SqlDbType.VarChar)).Value = EQPRecipeNumber == null ? "" : EQPRecipeNumber;
        //            command.Parameters.Add(new SqlParameter("@glass_judge_code", System.Data.SqlDbType.VarChar)).Value = GlassJudgeCode.ToString();
        //            command.Parameters.Add(new SqlParameter("@lot_code", System.Data.SqlDbType.VarChar)).Value = LOTCode.ToString();


        //            command.Parameters.Add(new SqlParameter("@lot_id", System.Data.SqlDbType.VarChar)).Value = LotID == null ? "" : LotID;
        //            command.Parameters.Add(new SqlParameter("@processing_code", System.Data.SqlDbType.VarChar)).Value = ProcessingCode == null ? "" : ProcessingCode.ToString();
        //            command.Parameters.Add(new SqlParameter("@lot_specific_data", System.Data.SqlDbType.VarChar)).Value = LotSpecificData == null ? "" : LotSpecificData;
        //            command.Parameters.Add(new SqlParameter("@host_recipe_number", System.Data.SqlDbType.VarChar)).Value = HostRecipeNumber.ToString();
        //            command.Parameters.Add(new SqlParameter("@glass_type", System.Data.SqlDbType.VarChar)).Value = GlassType == null ? "" : GlassType;
        //            command.Parameters.Add(new SqlParameter("@glass_code", System.Data.SqlDbType.VarChar)).Value = GlassCode.ToString();

        //            command.Parameters.Add(new SqlParameter("@glass_id", System.Data.SqlDbType.VarChar)).Value = GlassID == null ? "" : GlassID;
        //            command.Parameters.Add(new SqlParameter("@glass_judge", System.Data.SqlDbType.VarChar)).Value = GlassJudge == null ? "" : GlassJudge;
        //            command.Parameters.Add(new SqlParameter("@glass_specific_data", System.Data.SqlDbType.VarChar)).Value = GlassSpecificData == null ? "" : GlassSpecificData;
        //            command.Parameters.Add(new SqlParameter("@glass_add_data", System.Data.SqlDbType.VarChar)).Value = GlassAddData == null ? "" : GlassAddData;
        //            //command.Parameters.Add(new SqlParameter("@glass_variety", System.Data.SqlDbType.VarChar)).Value = GlassVariety.ToString();

        //            command.Parameters.Add(new SqlParameter("@glass_processing_status", System.Data.SqlDbType.VarChar)).Value = GlassProcessingStatus == null ? "" : GlassProcessingStatus;
        //            command.Parameters.Add(new SqlParameter("@original_cassette_id", System.Data.SqlDbType.VarChar)).Value = OriginalCassetteID == null ? "" : OriginalCassetteID;
        //            command.Parameters.Add(new SqlParameter("@glass_route_path", System.Data.SqlDbType.VarChar)).Value = GlassRoutePath.ToString();
        //            command.Parameters.Add(new SqlParameter("@glass_current_loc", System.Data.SqlDbType.VarChar)).Value = GlassCurrentLocation == null ? "" : GlassCurrentLocation;

        //            command.Parameters.Add(new SqlParameter("@glass_current_tm_loc", System.Data.SqlDbType.VarChar)).Value = GlassCurrentLocation == null ? "" : GlassCurrentLocation;


        //            command.Parameters.Add(new SqlParameter("@prev_unit_processing_data", System.Data.SqlDbType.VarChar)).Value = PreviousUnitProcessingData == null ? "" : PreviousUnitProcessingData;

        //            command.Parameters.Add(new SqlParameter("@current_loc", System.Data.SqlDbType.VarChar)).Value = CurrentLocation == null ? "" : CurrentLocation;

        //            command.Parameters.Add(new SqlParameter("@create_time", System.Data.SqlDbType.DateTime)).Value = _createTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
        //            command.Parameters.Add(new SqlParameter("@modify_time", System.Data.SqlDbType.DateTime)).Value = _modifyTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

        //            command.Parameters.Add(new SqlParameter("@main_pnl_if", System.Data.SqlDbType.VarChar)).Value = MainPNLIF == null ? "" : MainPNLIF;
        //            command.Parameters.Add(new SqlParameter("@sub_pnl_if", System.Data.SqlDbType.VarChar)).Value = SubPNLIF == null ? "" : SubPNLIF;
        //            command.Parameters.Add(new SqlParameter("@original_port_id", System.Data.SqlDbType.VarChar)).Value = OriginalPortID == null ? "" : OriginalPortID;
        //            command.Parameters.Add(new SqlParameter("@original_slot_id", System.Data.SqlDbType.VarChar)).Value = OriginalSlotID == null ? "" : OriginalSlotID;
        //            command.Parameters.Add(new SqlParameter("@sample_code", System.Data.SqlDbType.VarChar)).Value = SampleCode == null ? "" : SampleCode;
        //            command.Parameters.Add(new SqlParameter("@string_gsd", System.Data.SqlDbType.VarChar)).Value = STRING_GSD == null ? "" : STRING_GSD;


        //            command.Parameters.Add(new SqlParameter("@is_processed", System.Data.SqlDbType.VarChar)).Value = IsProcessed == true ? "TRUE" : "FALSE";
        //            command.Parameters.Add(new SqlParameter("@is_scraped", System.Data.SqlDbType.VarChar)).Value = IsScraped == true ? "TRUE" : "FALSE";

        //            command.Parameters.Add(new SqlParameter("@main_glass_type", System.Data.SqlDbType.VarChar)).Value = MAIN_GLASS_TYPE == null ? "" : MAIN_GLASS_TYPE;
        //            command.Parameters.Add(new SqlParameter("@sub_glass_type", System.Data.SqlDbType.VarChar)).Value = SUB_GLASS_TYPE == null ? "" : SUB_GLASS_TYPE;

        //            command.Parameters.Add(new SqlParameter("@is_cim_generate_data", System.Data.SqlDbType.VarChar)).Value = IsCIMGenerateData == true ? "TRUE" : "FALSE";
        //            command.Parameters.Add(new SqlParameter("@current_cst_id", System.Data.SqlDbType.VarChar)).Value = CurrentCSTID == null ? "" : CurrentCSTID;
        //            command.CommandText = "update glass_data set " +
        //                "eqp_recipe_number=@eqp_recipe_number, glass_judge_code=@glass_judge_code, lot_code=@lot_code, lot_id=@lot_id, processing_code=@processing_code, lot_specific_data=@lot_specific_data, host_recipe_number=@host_recipe_number, glass_type=@glass_type, " +
        //                "glass_code=@glass_code, glass_id=@glass_id, glass_judge=@glass_judge, glass_specific_data=@glass_specific_data, glass_add_data=@glass_add_data, " +
        //                "glass_processing_status=@glass_processing_status, original_cassette_id=@original_cassette_id, glass_route_path=@glass_route_path, glass_current_loc=@glass_current_loc, " +
        //                "prev_unit_processing_data=@prev_unit_processing_data, current_loc=@current_loc,  create_time=@create_time, modify_time=@modify_time, " +
        //                "main_pnl_if=@main_pnl_if, sub_pnl_if=@sub_pnl_if, original_port_id=@original_port_id, original_slot_id=@original_slot_id, sample_code=@sample_code, string_gsd=@string_gsd, " +
        //                "is_processed=@is_processed, is_scraped=@is_scraped, main_glass_type=@main_glass_type, sub_glass_type=@sub_glass_type, is_cim_generate_data=@is_cim_generate_data, current_cst_id=@current_cst_id " +
        //                "where glass_code=@glass_code";
        //            command.Connection = connection;
        //            command.ExecuteNonQuery();
        //        }
        //        return true;
        //    }
        //    catch (SqlException ex)
        //    {
                
        //        CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "EMP", ex));
        //    }

        //    return false;
        //}
        //public override bool Load()
        //{
        //    SqlDataReader reader = null;
        //    try
        //    {
        //        using (SqlConnection connection = DbControl.GetOpenConnection())
        //        {
        //            SqlCommand readCommand = connection.CreateCommand();
        //            readCommand.Parameters.Add("@glass_code", System.Data.SqlDbType.VarChar).Value = GlassCode.ToString();
        //            readCommand.CommandText = "select * from glass_data where glass_code=@glass_code";
        //            readCommand.CommandTimeout = 15;
        //            readCommand.Connection = connection;
        //            reader = readCommand.ExecuteReader();

        //            if (reader.Read())
        //            {
        //                int intTemp = 0;

        //                EQPRecipeNumber = (string)reader["eqp_recipe_number"];
        //                int.TryParse((string)reader["glass_judge_code"], out intTemp);
        //                GlassJudgeCode = intTemp;
        //                int.TryParse((string)reader["lot_code"], out intTemp);
        //                LOTCode = intTemp;

        //                LotID = (string)reader["lot_id"];
        //                ProcessingCode = (string)reader["processing_code"];
        //                LotSpecificData = (string)reader["lot_specific_data"];
                        
        //                int.TryParse((string)reader["host_recipe_number"], out intTemp);

        //                HostRecipeNumber = intTemp;
        //                GlassType = (string)reader["glass_type"];
              
        //                int.TryParse((string)reader["glass_code"], out intTemp);
        //                GlassCode = intTemp;
        //                GlassID = (string)reader["glass_id"];
        //                GlassJudge = (string)reader["glass_judge"];
        //                GlassSpecificData = (string)reader["glass_specific_data"];
        //                GlassAddData = (string)reader["glass_add_data"];
        //                //GlassVariety = (enumGlassVariety)Enum.Parse(typeof(enumGlassVariety), (string)reader["glass_variety"]);

        //                GlassProcessingStatus = (string)reader["glass_processing_status"];
        //                OriginalCassetteID = (string)reader["original_cassette_id"];
        //                int.TryParse((string)reader["glass_route_path"], out intTemp);
        //                GlassRoutePath = intTemp;
        //                GlassCurrentLocation = (string)reader["glass_current_loc"];

        //                PreviousUnitProcessingData = (string)reader["prev_unit_processing_data"];

        //                CurrentLocation = (string)reader["current_loc"];

        //                _createTime = (DateTime)reader["create_time"];
        //                _modifyTime = (DateTime)reader["modify_time"];

        //                MainPNLIF = (string)reader["main_pnl_if"];
        //                SubPNLIF = (string)reader["sub_pnl_if"];
        //                OriginalPortID = (string)reader["original_port_id"];
        //                OriginalSlotID = (string)reader["original_slot_id"];
        //                SampleCode = (string)reader["sample_code"];
        //                STRING_GSD = (string)reader["string_gsd"];

        //                IsProcessed = (string)reader["is_processed"] == "TRUE" ? true : false;
        //                IsScraped = (string)reader["is_scraped"] == "TRUE" ? true : false;

        //                MAIN_GLASS_TYPE = (string)reader["main_glass_type"];
        //                SUB_GLASS_TYPE = (string)reader["sub_glass_type"];

        //                IsCIMGenerateData = (string)reader["is_cim_generate_data"] == "TRUE" ? true : false;
        //                CurrentCSTID = (string)reader["current_cst_id"];
        //            }

        //            reader.Close();
        //            reader.Dispose();
        //        }
        //        return true;
        //    }
        //    catch (SqlException ex)
        //    {
        //        CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "EMP", ex));
        //    }
        //    finally
        //    {
        //        if (reader != null) reader.Close();
        //    }

        //    return false;
        //}

        #endregion


        public static List<int> ConvertPLCData(CGlassDataProperties glassData)
        {
            List<int> plcData = new List<int>();

            plcData.AddRange(CovertStringToWordList(glassData.LotID, 10));
            plcData.AddRange(CovertStringToWordList(glassData.GlassID, 10));
            plcData.AddRange(CovertStringToWordList(glassData.OperID, 10));
            plcData.AddRange(ConvertDecTo2WordList(Convert.ToInt32(glassData.GlassCodeXXYYYY.ToString() + glassData.GlassCodeZZZ.ToString("000"))));
            //plcData.Add(glassData.GlassCodeXXYYYY);
            //plcData.Add(glassData.GlassCodeZZZ);
            plcData.AddRange(CovertStringToWordList(glassData.GlassJudgeCode, 1));
            plcData.Add(glassData.PPID);
            plcData.AddRange(CovertStringToWordList(glassData.ProdID, 10));
            plcData.Add(glassData.CIMPCData1);
            plcData.Add(glassData.CIMPCData2);
            plcData.Add(glassData.ProcFlag1);
            plcData.Add(glassData.ProcFlag2);
            plcData.Add(glassData.JudgeFlag1);
            plcData.Add(glassData.JudgeFlag2);
            plcData.Add(glassData.SkipFlag1);
            plcData.Add(glassData.SkipFlag2);
            plcData.Add(glassData.InspectionFlag1);
            plcData.Add(glassData.InspectionFlag2);
            plcData.Add(glassData.Mode);
            plcData.Add(glassData.GlassType1);
            plcData.Add(glassData.GlassType2);
            plcData.Add(glassData.DummyType);
            plcData.Add(glassData.ReservedData1);
            plcData.Add(glassData.ReservedData2);
            plcData.Add(glassData.ReservedData3);
            plcData.Add(glassData.ReservedData4);
            plcData.Add(glassData.ReservedData5);
            plcData.Add(glassData.ReservedData6);

            return plcData;
        }

        public static List<int> ConvertPLC_DV_Data(List<string> DV_Data, int Length, bool iFlag)
        {
            List<int> plcData = new List<int>();

            if (iFlag)
            {
                for (int i = 0; i < DV_Data.Count; i++)
                {
                    if (i < 8)
                    {
                        plcData.AddRange(CovertStringToWordList(DV_Data[i].Trim(), Length));
                    }
                    else
                    {
                        plcData.AddRange(ByteArrayToIntArray(PLCDataConverter.SystemFloatToPLC4Byte(float.Parse(DV_Data[i].Trim() != "" ? DV_Data[i].Trim() : "0")), 0, 2));
                    }
                }
            }
            else
            {
                foreach (string item in DV_Data)
                {
                    plcData.AddRange(ByteArrayToIntArray(PLCDataConverter.SystemFloatToPLC4Byte(float.Parse(item.Trim() != "" ? item.Trim() : "0")), 0, 2));
                }
            }

            

            return plcData;
        }

        private static int[] ByteArrayToIntArray(byte[] data, int start, int wordLength)
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

        private static List<int> ConvertDecTo2WordList(int value)
        {
            List<int> wordList = new List<int>();
            wordList.Add((int)(value & 0xFFFF));
            wordList.Add((int)(value >> 16));

            return wordList;
        }

        /// <summary>
        /// ABCD  -> BADC-> HEX -> DEC 로 변환 해준다.
        /// </summary>
        /// <param name="normalString"></param>
        /// <param name="wordMaxLength">WORD 기준 총개수, 내부적으로 *2한다.</param>
        /// <returns></returns>
        public static List<int> CovertStringToWordList(string normalString, int wordMaxLength)
        {
            List<int> plcData = new List<int>();
            char[] tempLotID = normalString.ToCharArray();
            List<string> word = new List<string>();
            int maxLegnth = wordMaxLength * 2;

            if (tempLotID.Length < maxLegnth)
            {
                int emptyCount = maxLegnth - tempLotID.Length;

                string temp = "";
                temp.PadLeft(emptyCount, '\0');
                List<char> charLIst = new List<char>(tempLotID);
                for (int i = 0; i < emptyCount; i++)
                {
                    charLIst.Add('\0');
                }

                tempLotID = charLIst.ToArray();
            }
            for (int i = 0; i < maxLegnth; i++)
            {
                if (tempLotID.Length < i)
                {
                    word.Insert(0, " ");
                }
                else
                {
                    word.Insert(0, tempLotID[i].ToString());
                }
                if (word.Count >= 2)
                {
                    //plcData.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.StringToReverseHex(word[0] + word[1]))));
                    plcData.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.StringToHex(word[0] + word[1]))));
                    word.Clear();
                }
            }

            return plcData;
        }
        /// <summary>
        /// ABCD  -> BADC-> HEX -> DEC 로 변환 해준다.
        /// </summary>
        /// <param name="normalString"></param>
        /// <param name="wordMaxLength">WORD 기준 총개수, 내부적으로 *2한다.</param>
        /// <returns></returns>
        public static List<ushort> CovertStringToWordushort(string normalString, int wordMaxLength)
        {
            List<ushort> plcData = new List<ushort>();
            char[] tempLotID = normalString.ToCharArray();
            List<string> word = new List<string>();
            long maxLegnth = wordMaxLength * 2;
            for (ushort i = 0; i < maxLegnth; i++)
            {
                if (tempLotID.Length <= i)
                {
                    word.Insert(0, " ");
                }
                else
                {
                    word.Insert(0, tempLotID[i].ToString());
                }
                if (word.Count >= 2)
                {
                    //plcData.Add(ushort.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.StringToReverseHex(word[0] + word[1]))));
                    plcData.Add(ushort.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.StringToHex(word[0] + word[1]))));
                    word.Clear();
                }
            }

            return plcData;
        }
        public static Dictionary<string, string> GetGuiData(CGlassDataProperties glassData)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("LotID", glassData.LotID);
            data.Add("GlassID", glassData.GlassID);
            data.Add("OperID", glassData.OperID);
            data.Add("GlassCode", glassData.GlassCode);
            data.Add("GlassCodeXXYYYY", glassData.GlassCodeXXYYYY.ToString());
            data.Add("GlassCodeZZZ", glassData.GlassCodeZZZ.ToString());
            data.Add("GlassJudgeCode", glassData.GlassJudgeCode);
            data.Add("PPID", glassData.PPID.ToString());
            data.Add("ProdID", glassData.ProdID);
            data.Add("CIMPCData1", glassData.CIMPCData1.ToString());
            data.Add("CIMPCData2", glassData.CIMPCData2.ToString());
            data.Add("ProcFlag1", glassData.ProcFlag1.ToString());
            data.Add("ProcFlag2", glassData.ProcFlag2.ToString());
            data.Add("JudgeFlag1", glassData.JudgeFlag1.ToString());
            data.Add("JudgeFlag2", glassData.JudgeFlag2.ToString());
            data.Add("SkipFlag1", glassData.SkipFlag1.ToString());
            data.Add("SkipFlag2", glassData.SkipFlag2.ToString());
            data.Add("InspectionFlag1", glassData.InspectionFlag1.ToString());
            data.Add("InspectionFlag2", glassData.InspectionFlag2.ToString());
            data.Add("Mode", glassData.Mode.ToString());
            data.Add("GlassType1", glassData.GlassType1.ToString());
            data.Add("GlassType2", glassData.GlassType2.ToString());
            data.Add("DummyType", glassData.DummyType.ToString());
            data.Add("ReservedData1", glassData.ReservedData1.ToString());
            data.Add("ReservedData2", glassData.ReservedData2.ToString());
            data.Add("ReservedData3", glassData.ReservedData3.ToString());
            data.Add("ReservedData4", glassData.ReservedData4.ToString());
            data.Add("ReservedData5", glassData.ReservedData5.ToString());
            data.Add("ReservedData6", glassData.ReservedData6.ToString());
            return data;
        }

        public static Dictionary<string, string> GetClearData(CGlassDataProperties glassData)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("LotID", "");
            data.Add("GlassID", "");
            data.Add("OperID", "");
            data.Add("GlassCode", "");
            data.Add("GlassCodeXXYYYY", "");
            data.Add("GlassCodeZZZ", "");
            data.Add("GlassJudgeCode", "");
            data.Add("PPID", "");
            data.Add("ProdID", "");
            data.Add("CIMPCData1", "");
            data.Add("CIMPCData2", "");
            data.Add("ProcFlag1", "");
            data.Add("ProcFlag2", "");
            data.Add("JudgeFlag1", "");
            data.Add("JudgeFlag2", "");
            data.Add("SkipFlag1", "");
            data.Add("SkipFlag2", "");
            data.Add("InspectionFlag1", "");
            data.Add("InspectionFlag2", "");
            data.Add("Mode", "");
            data.Add("GlassType1", "");
            data.Add("GlassType2", "");
            data.Add("DummyType", "");
            data.Add("ReservedData1", "");
            data.Add("ReservedData2", "");
            data.Add("ReservedData3", "");
            data.Add("ReservedData4", "");
            data.Add("ReservedData5", "");
            data.Add("ReservedData6", "");
            return data;
        }

        public static Dictionary<string, string> GetRemovedData(string[] glassData)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("LotID", glassData[0]);
            data.Add("GlassID", glassData[1]);
            data.Add("OperID", glassData[2]);
            data.Add("GlassCode", glassData[3]);
            data.Add("GlassCodeXXYYYY", glassData[4]);
            data.Add("GlassCodeZZZ", glassData[5]);
            data.Add("GlassJudgeCode", glassData[6]);
            data.Add("PPID", glassData[7]);
            data.Add("ProdID", glassData[8]);
            data.Add("CIMPCData1", glassData[9]);
            data.Add("CIMPCData2", glassData[10]);
            data.Add("ProcFlag1", glassData[11]);
            data.Add("ProcFlag2", glassData[12]);
            data.Add("JudgeFlag1", glassData[13]);
            data.Add("JudgeFlag2", glassData[14]);
            data.Add("SkipFlag1", glassData[15]);
            data.Add("SkipFlag2", glassData[16]);
            data.Add("InspectionFlag1", glassData[17]);
            data.Add("InspectionFlag2", glassData[18]);
            data.Add("Mode", glassData[19]);
            data.Add("GlassType1", glassData[20]);
            data.Add("GlassType2", glassData[21]);
            data.Add("DummyType", glassData[22]);
            data.Add("ReservedData1", glassData[23]);
            data.Add("ReservedData2", glassData[24]);
            data.Add("ReservedData3", glassData[25]);
            data.Add("ReservedData4", glassData[26]);
            data.Add("ReservedData5", glassData[27]);
            data.Add("ReservedData6", glassData[28]);
            return data;
        }

        public static ushort[] GetGuiDataToPLC(Dictionary<string, string> data)
        {
            List<ushort> plcData = new List<ushort>();

            plcData.AddRange(CovertStringToWordushort(data["LotID"], 10));
            plcData.AddRange(CovertStringToWordushort(data["GlassID"], 10));
            plcData.AddRange(CovertStringToWordushort(data["OperID"], 10));
            plcData.Add(ushort.Parse(data["GlassCodeXXYYYY"]));
            plcData.Add(ushort.Parse(data["GlassCodeZZZ"]));
            plcData.AddRange(CovertStringToWordushort(data["GlassJudgeCode"], 1));
            plcData.Add(ushort.Parse(data["PPID"]));
            plcData.AddRange(CovertStringToWordushort(data["ProdID"], 10));
            plcData.Add(ushort.Parse(data["CIMPCData1"]));
            plcData.Add(ushort.Parse(data["CIMPCData2"]));
            plcData.Add(ushort.Parse(data["ProcFlag1"]));
            plcData.Add(ushort.Parse(data["ProcFlag2"]));
            plcData.Add(ushort.Parse(data["JudgeFlag1"]));
            plcData.Add(ushort.Parse(data["JudgeFlag2"]));
            plcData.Add(ushort.Parse(data["SkipFlag1"]));
            plcData.Add(ushort.Parse(data["SkipFlag2"]));
            plcData.Add(ushort.Parse(data["InspectionFlag1"]));
            plcData.Add(ushort.Parse(data["InspectionFlag2"]));
            plcData.Add(ushort.Parse(data["Mode"]));
            plcData.Add(ushort.Parse(data["GlassType1"]));
            plcData.Add(ushort.Parse(data["GlassType2"]));
            plcData.Add(ushort.Parse(data["DummyType"]));
            plcData.Add(ushort.Parse(data["ReservedData1"]));
            plcData.Add(ushort.Parse(data["ReservedData2"]));
            plcData.Add(ushort.Parse(data["ReservedData3"]));
            plcData.Add(ushort.Parse(data["ReservedData4"]));
            plcData.Add(ushort.Parse(data["ReservedData5"]));
            plcData.Add(ushort.Parse(data["ReservedData6"]));

            return plcData.ToArray();

        }

        public static string GetSaveData(CGlassDataProperties glassData)
        {
            Dictionary<string, string> data = GetGuiData(glassData);
            string temp = "";

            foreach (string item in data.Values)
            {
                temp += string.Format("{0},", item.ToString().Trim());
            }
            temp = temp.Substring(0, temp.Length - 1);
            return temp;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            Dictionary<string, string> data = GetGuiData(this);

            foreach (KeyValuePair<string, string> item in data)
            {
                sb.AppendFormat("{0}={1},", item.Key, item.Value);
            }
            return sb.ToString();
        }
    }

    public class CMaterialDataCollection : Dictionary<int, AMaterialData>
    {
        public bool IsExistMaterialDataByGLASSID(string matrialID)
        {
            foreach (AMaterialData oMaterial in this.Values)
            {
                if (oMaterial.MatrialID == matrialID)
                {
                    return true;
                }
            }
            return false;
        }

        public AMaterialData GetMaterialDataBy(string matrialID)
        {
            foreach (AMaterialData item in this.Values)
            {
                if (item.MatrialID == matrialID)
                {
                    return item;
                }
            }
            return null;
        }
        public bool IsExistMaterialDataBy(string matrialID, out AMaterialData material)
        {
            material = null;
            foreach (AMaterialData item in this.Values)
            {
                if (item.MatrialID == matrialID)
                {
                    material = item;
                    return true;
                }
            }

            return false;
        }
        public bool IsExistMaterialDataBy(int matrialCode, out AMaterialData material)
        {
            material = null;
            foreach (AMaterialData item in this.Values)
            {
                if (item.MatrialCode == matrialCode.ToString())
                {
                    material = item;
                    return true;
                }
            }

            return false;
        }
        public AMaterialData GetMaterialDataBy(int matrialCode)
        {
            foreach (AMaterialData item in this.Values)
            {
                if (item.MatrialCode == matrialCode.ToString())
                {
                    return item;
                }
            }
            return null;
        }

    }

    public class CGlassDataPropertiesCollection : Dictionary<int, CGlassDataProperties>
    {
        public bool IsExistGlassDataByGLASSID(string GLASSID)
        {
            foreach (CGlassDataProperties oGlass in this.Values)
            {
                if (oGlass.GlassID == GLASSID)
                {
                    return true;
                }
            }
            return false;
        }

        public CGlassDataProperties GetGlassDataBy(string GLASSID)
        {
            foreach (CGlassDataProperties oGlass in this.Values)
            {
                if (oGlass.GlassID == GLASSID)
                {
                    return oGlass;
                }
            }
            return null;
        }
        public bool IsExistGlassDataBy(string GLASSID, out CGlassDataProperties glassData)
        {
            glassData = null;
            foreach (CGlassDataProperties oGlass in this.Values)
            {
                if (oGlass.GlassID == GLASSID)
                {
                    glassData = oGlass;
                    return true;
                }
            }

            return false;
        }
        public bool IsExistGlassDataBy(int glassCode, out CGlassDataProperties glassData)
        {
            glassData = null;
            foreach (CGlassDataProperties oGlass in this.Values)
            {
                if (oGlass.GlassCode == glassCode.ToString())
                {
                    glassData = oGlass;
                    return true;
                }
            }

            return false;
        }
        public CGlassDataProperties GetGlassDataBy(int glassCode)
        {
            foreach (CGlassDataProperties oGlass in this.Values)
            {
                if (oGlass.GlassCode == glassCode.ToString())
                {
                    return oGlass;
                }
            }
            return null;
        }
    }
}

