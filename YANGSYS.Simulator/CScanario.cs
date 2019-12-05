using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOFD.Properties;
using SOFD.Global;

namespace SmartPLCSimulator
{
    public class CScanario
    {
       

        CScanControlPropertiesCollections _scans = null;
        CPLCControlPropertiesCollection _plcs = null;
        private const string BDevice = "23";
        private const string WDevice = "24";
        private string _controlName = "";

        public string ControlName
        {
            get { return _controlName; }
        }

        public CScanario(string controlName, CScanControlPropertiesCollections scans, CPLCControlPropertiesCollection plcs)
        {
            _controlName = controlName;
            _scans = scans;
            _plcs = plcs;
        }

        public void BC_CIMModeChangeCommand(string cimMode, bool value)
        {
            int temp = 0;
            int.TryParse(cimMode, out temp);

            BC_CIMModeData(_controlName, temp);
            BC_CIMModeChangeCommandBitOnOff(_controlName, value);
            //PROBE CIM 이 응답해야함.
        }

        public string EQ_CIMModeChangeReply()
        {
            string value = EQ_ReturnCode(_controlName);
            BC_CIMModeChangeCommandBitOnOff(_controlName, false);

            return value;
        }

        public void BC_RecipeParameterRequest(string recipeNo, string unitID,bool value)
        {
            int temp = 0;
            int.TryParse(recipeNo, out temp);

            BC_RecipeParameterData(_controlName, temp, unitID);
            BC_RecipeParameterRequestBitOnOff(_controlName, value);
            //PROBE CIM 이 응답해야함.
        }
        public string BC_RecipeParameterReply()
        {
            string value = EQ_RecipeParameterData(_controlName);
            BC_RecipeParameterRequestBitOnOff(_controlName, false);

            return value;
        }

        public void BC_RecipeParameterDownload(string recipeNo, string[] valueList, bool value)
        {
            int temp = 0;
            int.TryParse(recipeNo, out temp);

            BC_RecipeParameterDownloadData(_controlName, recipeNo, valueList);
            BC_RecipeParameterDownloadBitOnOff(_controlName, value);
            //PROBE CIM 이 응답해야함.
        }
        public string BC_RecipeParameterDownReply()
        {
            string value = EQ_RecipeParameterDownResult(_controlName);
            BC_RecipeParameterDownloadBitOnOff(_controlName, false);

            return value;
        }


        private void BC_CIMModeChangeCommandBitOnOff(string controlName, bool value)
        {
            BitWrite(_scans.GetProperty(controlName, "IB_CIM_MODE_CHANGE_COMMAND"), value);
        }
        private void BC_CIMModeData(string controlName, int cimMode)
        {
            WordWriteByHexValue(_scans.GetProperty(controlName, "IW_CIM_MODE"), cimMode.ToString());
        }


        private void BC_RecipeParameterRequestBitOnOff(string controlName, bool value)
        {
            BitWrite(_scans.GetProperty(controlName, "IB_RECIPE_PARAMETER_REQUEST"), value);
        }
        private void BC_RecipeParameterData(string controlName, int recipe, string unitID)
        {
            WordWriteByHexValue(_scans.GetProperty(controlName, "IW_RECIPE_PARAMETER_REQUEST_MACHINE_RECIPE"), recipe.ToString());
            WordWriteByHexValue(_scans.GetProperty(controlName, "IW_RECIPE_PARAMETER_REQUEST_UNIT_ID"), unitID);
        }
        private string EQ_RecipeParameterData(string controlName)
        {
            return WordRead(_plcs.GetProperty(controlName, "OW_CIM_MODE_CHANGE_RETURN_CODE"));
        }

        private void BC_RecipeParameterDownloadBitOnOff(string controlName, bool value)
        {
            BitWrite(_scans.GetProperty(controlName, "IB_RECIPE_PARAMETER_DOWNLOAD"), value);
        }
        private void BC_RecipeParameterDownloadData(string controlName, string recipe, string[] valueList)
        {
            WordWriteByHexValue(_scans.GetProperty(controlName, "IW_CIM_MODE"), recipe.ToString());
            string start = Utils.HexToDec(_scans.GetProperty(controlName, "IW_CIM_MODE").ScanArea);
            int startDec = int.Parse(start);

            foreach (string item in valueList)
            {
                WordWrite(startDec++.ToString("X"), Utils.DecToHex(item));
            }
        }
        public string EQ_RecipeParameterDownResult(string controlName)
        {
            return WordRead(_plcs.GetProperty(controlName, "OW_CIM_MODE_CHANGE_RETURN_CODE"));
        }

        private void EQ_CIMModeChangeReplyBitOnOff(string controlName, bool value)
        {
            BitWrite(_plcs.GetProperty(controlName, "OB_CIM_MODE_CHANGE_COMMAND_REPLY"), value);
        }
        private void EQ_ReturnCode(string controlName, int returnCode)
        {
            WordWriteByHexValue(_plcs.GetProperty(controlName, "OW_CIM_MODE_CHANGE_RETURN_CODE"), returnCode.ToString());
        }
        private string EQ_ReturnCode(string controlName)
        {
            return WordRead(_plcs.GetProperty(controlName, "OW_CIM_MODE_CHANGE_RETURN_CODE"));
        }
        public string EQ_MachineStatus(string controlName)
        {
            return WordRead(_plcs.GetProperty(controlName, Att.OW_MACHINE_STATUS.ToString()));
        }
        public string EQ_MachineReasonCode(string controlName)
        {
            return WordRead(_plcs.GetProperty(controlName, Att.OW_MACHINE_REASON_CODE.ToString()));
        }
        public string EQ_MachineDownAlarmCode(string controlName)
        {
            return WordRead(_plcs.GetProperty(controlName, Att.OW_MACHINE_DOWN_ALARM_CODE.ToString()));
        }
        public string EQ_Unit1Status(string controlName)
        {
            return WordRead(_plcs.GetProperty(controlName, Att.OW_UNIT1_STATUS.ToString()));
        }
        internal ushort[] EQ_OW_JOB_DATA_FOR_DOWNSTREAM_BLOCK1(string controlName)
        {            
            CPLCControlProperties property = _plcs.GetProperty(controlName, Att.OW_JOB_DATA_FOR_DOWNSTREAM_BLOCK1.ToString());
            return GetJobDataA(property);
        }

        internal ushort[] EQ_OW_SENT_OUT_JOB_DATA_SUB_BLOCK1(string controlName)
        {
            CPLCControlProperties property = _plcs.GetProperty(controlName, Att.OW_SENT_OUT_JOB_DATA_SUB_BLOCK1.ToString());
            return GetSubJobDataA(property);
        }

        public void BC_MachineStatusChangeReportReply(string controlName, bool value)
        {
            BitWrite(_scans.GetProperty(controlName, Att.IB_MACHINE_STATUS_CHANGE_REPORT_REPLY.ToString()), value);
        }
        #region Simulator PLC Method
        public string BitRead(string strHexAddr)
        {
            int iScanArea = int.Parse(Utils.HexToDec(strHexAddr.ToString()));
            string strRst = DeviceManager.Read(BDevice, iScanArea, 1);
            return strRst;
        }

        public string BitRead(CPLCControlProperties property)
        {
            return BitRead(property.PLCArea);
        }
        public string BitRead(CScanControlProperties property)
        {
            return BitRead(property.ScanArea);
        }

        public void BitWrite(string strHexAddr, bool bOn)
        {
            int iPLCArea = int.Parse(Utils.HexToDec(strHexAddr.ToString()));
            string strRst = DeviceManager.Write(BDevice, iPLCArea, 1, bOn ? "1" : "0");

        }

        public void BitWrite(CPLCControlProperties property, bool bOn)
        {
            if (property == null) throw new ArgumentException("SCAN/PLC 이름이 달라 못가져온경우니 xml 파일 확인" );
            BitWrite(property.PLCArea, bOn);
        }
        public void BitWrite(CScanControlProperties property, bool bOn)
        {
            if (property == null) throw new ArgumentException("SCAN/PLC 이름이 달라 못가져온경우니 xml 파일 확인");
            BitWrite(property.ScanArea, bOn);
        }

        public string WordRead(string strHexAddr)
        {
            int iScanArea = int.Parse(Utils.HexToDec(strHexAddr.ToString()));
            string strRst = DeviceManager.Read(WDevice, iScanArea, 1);

            char[] buffer = strRst.ToCharArray();
            string result = "";

            for (int i = 0; i < buffer.Length; i++)
            {
                string temp = "";
                string ss = (Convert.ToUInt32(buffer[i])).ToString("X");
                temp = ss.PadLeft(4, '0');
                result = result.Insert(result.Length, temp);
            }

            return result; // Return은 Hex Value임.
        }
        public string WordRead(CPLCControlProperties property)
        {
            if (property == null) throw new ArgumentException("SCAN/PLC 이름이 달라 못가져온경우니 xml 파일 확인");
            return WordRead(property.PLCArea);
        }

        public string WordRead(CScanControlProperties property)
        {
            if (property == null) throw new ArgumentException("SCAN/PLC 이름이 달라 못가져온경우니 xml 파일 확인");
            return WordRead(property.ScanArea);
        }

        public void WordWrite(string strHexAddr, string HexWriteData)
        {
            int iPLCArea = int.Parse(Utils.HexToDec(strHexAddr.ToString()));
            string strRst = DeviceManager.Write(WDevice, iPLCArea, 1, HexWriteData);
        }
        public void WordWriteByHexValue(CPLCControlProperties property, string decValue)
        {
            if (property == null) throw new ArgumentException("SCAN/PLC 이름이 달라 못가져온경우니 xml 파일 확인");
            WordWrite(property.PLCArea, Utils.DecToHex(decValue));
        }

        public void WordWriteByHexValue(CScanControlProperties property, string decValue)
        {
            if (property == null) throw new ArgumentException("SCAN/PLC 이름이 달라 못가져온경우니 xml 파일 확인");
            WordWrite(property.ScanArea, Utils.DecToHex(decValue));
        }
        #endregion

        public void IDX_LINK_DOWNSTREAM_INLINE(string controlName, bool value)
        {
            BitWrite(_scans.GetProperty(controlName, "IB_LINK_DOWN_DOWNSTREAM_INLINE"), value);
        }

        public void IDX_LINK_DOWNSTREAM_TROUBLE(string controlName, bool value)
        {
            BitWrite(_scans.GetProperty(controlName, "IB_LINK_DOWN_DOWNSTREAM_TROUBLE"), value);
        }

        public void IDX_LINK_DOWN1_EXCHANGE_EXECUTE(string controlName, bool value)
        {
            BitWrite(_scans.GetProperty(controlName, "IB_LINK_DOWN_EXCHANGE_EXECUTE"), value);
        }

        public void IDX_LINK_UPSTREAM_INLINE(string controlName, bool value)
        {
            BitWrite(_scans.GetProperty(controlName, "IB_LINK_UP_UPSTREAM_INLINE"), value);
        }
        public void IDX_LINK_UPSTREAM_TROUBLE(string controlName, bool value)
        {
            BitWrite(_scans.GetProperty(controlName, "IB_LINK_UP_UPSTREAM_TROUBLE"), value);
        }
        internal void IDX_LINK_UP1_SEND_ABLE(string controlName, bool value)
        {
            BitWrite(_scans.GetProperty(controlName, "IB_LINK_UP_SEND_ABLE"), value);
        }

        internal void IDX_LINK_UP1_SEND_START(string controlName, bool value)
        {
            BitWrite(_scans.GetProperty(controlName, "IB_LINK_UP_SEND_START"), value);
        }

        internal void IDX_LINK_UP1_JOB_TRANSFER_SIGNAL(string controlName, bool value)
        {
            BitWrite(_scans.GetProperty(controlName, "IB_LINK_UP_JOB_TRANSFER_SIGNAL"), value);
        }

        internal void IDX_LINK_UP1_SEND_COMPLETE(string controlName, bool value)
        {
            BitWrite(_scans.GetProperty(controlName, "IB_LINK_UP_SEND_COMPLETE"), value);
        }



        internal void IDX_LINK_DOWN1_RECEIVE_ABLE(string controlName, bool value)
        {
            BitWrite(_scans.GetProperty(controlName, "IB_LINK_DOWN_RECEIVE_ABLE"), value);
        }

        internal void IDX_LINK_DOWN1_RECEIVE_START(string controlName, bool value)
        {
            BitWrite(_scans.GetProperty(controlName, "IB_LINK_DOWN_RECEIVE_START"), value);
        }

        internal void IDX_LINK_DOWN1_JOB_TRANSFER_SIGNAL(string controlName, bool value)
        {
            BitWrite(_scans.GetProperty(controlName, "IB_LINK_DOWN_JOB_TRANSFER_SIGNAL"), value);
        }

        internal void IDX_LINK_DOWN1_RECEIVE_COMPLETE(string controlName, bool value)
        {
            BitWrite(_scans.GetProperty(controlName, "IB_LINK_DOWN_RECEIVE_COMPLETE"), value);
        }
        /// <summary>
        /// received job
        /// </summary>
        /// <param name="controlName"></param>
        /// <param name="glassData"></param>
        internal void IDX_IW_JOB_DATA_FOR_UPSTREAM_BLOCK1(string controlName, CGlassData glassData)
        {
            CScanControlProperties property = _scans.GetProperty(controlName, "IW_JOB_DATA_FOR_UPSTREAM_BLOCK1");

            if (property == null) throw new ArgumentException("SCAN/PLC 이름이 달라 못가져온경우니 xml 파일 확인");

            int address = int.Parse(Utils.HexToDec(property.ScanArea));
            string reversedLotID = glassData.LotID;

            
            byte[] bytes = null;
            //10 WORD
            bytes = Encoding.ASCII.GetBytes(glassData.LotID);
            for (int i = 0; i < 20; i += 2)
            {
                if (bytes.Length > i)
                {
                    string hexL = "";
                    string hexH = "";

                    hexL = Utils.DecToHex(bytes[i].ToString()).Substring(2,2);//A
                    if (bytes.Length > i + 1)
                        hexH = Utils.DecToHex(bytes[i + 1].ToString()).Substring(2,2);//B
                    Console.Write(string.Format("{0}{1}", hexH, hexL));
                    WordWrite(address++.ToString("X"), string.Format("{0}{1}", hexH, hexL)); //BA로 저장.
                }
                else
                {
                    WordWrite(address++.ToString("X"), "2020");
                }
            }
            //10 WORD
            address = int.Parse(Utils.HexToDec(property.ScanArea)) + 10;
            bytes = Encoding.ASCII.GetBytes(glassData.GlassID);
            for (int i = 0; i < 20; i += 2)
            {
                if (bytes.Length > i)
                {
                    string hexL = "";
                    string hexH = "";

                    hexL = Utils.DecToHex(bytes[i].ToString()).Substring(2, 2);//A
                    if (bytes.Length > i + 1)
                        hexH = Utils.DecToHex(bytes[i + 1].ToString()).Substring(2, 2);//B

                    WordWrite(address++.ToString("X"), string.Format("{0}{1}", hexH, hexL)); //BA로 저장.
                }
                else
                {
                    WordWrite(address++.ToString("X"), "2020");
                }
            }
            //10 WORD
            address = int.Parse(Utils.HexToDec(property.ScanArea)) + 20;
            bytes = Encoding.ASCII.GetBytes(glassData.OperID);
            for (int i = 0; i < 20; i += 2)
            {
                if (bytes.Length > i)
                {
                    string hexL = "";
                    string hexH = "";

                    hexL = Utils.DecToHex(bytes[i].ToString()).Substring(2, 2);//A
                    if (bytes.Length > i + 1)
                        hexH = Utils.DecToHex(bytes[i + 1].ToString()).Substring(2, 2);//B

                    WordWrite(address++.ToString("X"), string.Format("{0}{1}", hexH, hexL)); //BA로 저장.
                }
                else
                {
                    WordWrite(address++.ToString("X"), "2020");
                }
            }

            List<int> glassCode = new List<int>();
            glassCode.AddRange(ConvertDecTo2WordList(Convert.ToInt32(glassData.GlassCodeXXYYYY.ToString() + glassData.GlassCodeZZZ.ToString("000"))));

            WordWrite(address++.ToString("X"), Utils.DecToHex(glassCode[0].ToString()));
            WordWrite(address++.ToString("X"), Utils.DecToHex(glassCode[1].ToString()));

            WordWrite(address++.ToString("X"), "20" + Utils.DecToHex(Encoding.ASCII.GetBytes(glassData.GlassJudgeCode)[0].ToString()).Substring(2, 2));
            WordWrite(address++.ToString("X"), Utils.DecToHex(glassData.PPID.ToString()));
            //10 WORD
            address = int.Parse(Utils.HexToDec(property.ScanArea)) + 34;
            bytes = Encoding.ASCII.GetBytes(glassData.ProdID);
            for (int i = 0; i < 20; i += 2)
            {
                if (bytes.Length > i)
                {
                    string hexL = "";
                    string hexH = "";

                    hexL = Utils.DecToHex(bytes[i].ToString()).Substring(2, 2);//A
                    if (bytes.Length > i + 1)
                        hexH = Utils.DecToHex(bytes[i + 1].ToString()).Substring(2, 2);//B

                    WordWrite(address++.ToString("X"), string.Format("{0}{1}", hexH, hexL)); //BA로 저장.
                }
                else
                {
                    WordWrite(address++.ToString("X"), "2020");
                }
            }
            address = int.Parse(Utils.HexToDec(property.ScanArea)) + 44;
            WordWrite(address++.ToString("X"), Utils.BinaryToHex(glassData.ProcFlag));
            address++;
            WordWrite(address++.ToString("X"), Utils.BinaryToHex(glassData.JudgeFlag));
            address++;
            WordWrite(address++.ToString("X"), Utils.BinaryToHex(glassData.SkipFlag));
            address++;
            WordWrite(address++.ToString("X"), Utils.BinaryToHex(glassData.InspectionFlag));
            address++;
            WordWrite(address++.ToString("X"), Utils.BinaryToHex(glassData.Mode));

            bool assembled = false;
            bool array = false;
            bool cf = false;
            bool reserved = false;
            string thickness = Utils.DecToHex("1");
            bool maskGlass = false;
            bool dummyGlass = false;
            bool lastLotGlass = false;
            bool firstLoGlass = false;
            string glassSIze = Utils.DecToHex("1");

            string glassType1 = "";//glassData.GlassType
            glassType1 += assembled ? "1" : "0";
            glassType1 += array ? "1" : "0";
            glassType1 += cf ? "1" : "0";
            glassType1 += reserved ? "1" : "0";
            glassType1 += thickness;
            glassType1 += maskGlass ? "1" : "0";
            glassType1 += dummyGlass ? "1" : "0";
            glassType1 += lastLotGlass ? "1" : "0";
            glassType1 += firstLoGlass ? "1" : "0";
            glassType1 += glassSIze;

            string glassType2 = "";

            glassType2 += "000000";//F~A not used
            glassType2 += "00";
            glassType2 += "00";
            glassType2 += "00";
            glassType2 += "00";
            glassType2 += "11";//glassAngle
            WordWrite(address++.ToString("X"), Utils.BinaryToHex(glassType1));// GlassType1 
            WordWrite(address++.ToString("X"), Utils.BinaryToHex(glassType2));// GlassType2
            WordWrite(address++.ToString("X"), Utils.DecToHex(glassData.DummyType));
        }

        private List<int> ConvertDecTo2WordList(int value)
        {
            List<int> wordList = new List<int>();
            wordList.Add((int)(value & 0xFFFF));
            wordList.Add((int)(value >> 16));

            return wordList;
        }
        /// <summary>
        /// received sub job
        /// </summary>
        /// <param name="controlName"></param>
        /// <param name="upstreamPathNo"></param>
        /// <param name="totalGlassCount"></param>
        internal void IDX_IW_RECEIVED_JOB_DATA_SUB_BLOCK1(string controlName, string upstreamPathNo, string totalGlassCount)
        {
            CScanControlProperties property = _scans.GetProperty(controlName, "IW_RECEIVED_JOB_DATA_SUB_BLOCK1");
            int address = int.Parse(Utils.HexToDec(property.ScanArea));
            WordWrite(address++.ToString("X"), Utils.DecToHex(upstreamPathNo));
            WordWrite(address++.ToString("X"), Utils.DecToHex(totalGlassCount));
        }
        /// <summary>
        /// sent out job
        /// </summary>
        /// <param name="controlName"></param>
        /// <param name="glassData"></param>
        internal void IDX_IW_JOB_DATA_FOR_DOWNSTREAM_BLOCK1(string controlName, CGlassData glassData)
        {
            CScanControlProperties property = _scans.GetProperty(controlName, "IW_JOB_DATA_FOR_DOWNSTREAM_BLOCK1");

            if (property == null) throw new ArgumentException("SCAN/PLC 이름이 달라 못가져온경우니 xml 파일 확인");

            int address = int.Parse(Utils.HexToDec(property.ScanArea));
            string reversedLotID = glassData.LotID;


            byte[] bytes = null;
            //10 WORD
            bytes = Encoding.ASCII.GetBytes(glassData.LotID);
            for (int i = 0; i < 20; i += 2)
            {
                if (bytes.Length > i)
                {
                    string hexL = "";
                    string hexH = "";

                    hexL = Utils.DecToHex(bytes[i].ToString()).Substring(2, 2);//A
                    if (bytes.Length > i + 1)
                        hexH = Utils.DecToHex(bytes[i + 1].ToString()).Substring(2, 2);//B
                    Console.Write(string.Format("{0}{1}", hexH, hexL));
                    WordWrite(address++.ToString("X"), string.Format("{0}{1}", hexH, hexL)); //BA로 저장.
                }
                else
                {
                    WordWrite(address++.ToString("X"), "2020");
                }
            }
            //10 WORD
            address = int.Parse(Utils.HexToDec(property.ScanArea)) + 10;
            bytes = Encoding.ASCII.GetBytes(glassData.GlassID);
            for (int i = 0; i < 20; i += 2)
            {
                if (bytes.Length > i)
                {
                    string hexL = "";
                    string hexH = "";

                    hexL = Utils.DecToHex(bytes[i].ToString()).Substring(2, 2);//A
                    if (bytes.Length > i + 1)
                        hexH = Utils.DecToHex(bytes[i + 1].ToString()).Substring(2, 2);//B

                    WordWrite(address++.ToString("X"), string.Format("{0}{1}", hexH, hexL)); //BA로 저장.
                }
                else
                {
                    WordWrite(address++.ToString("X"), "2020");
                }
            }
            //10 WORD
            address = int.Parse(Utils.HexToDec(property.ScanArea)) + 20;
            bytes = Encoding.ASCII.GetBytes(glassData.OperID);
            for (int i = 0; i < 20; i += 2)
            {
                if (bytes.Length > i)
                {
                    string hexL = "";
                    string hexH = "";

                    hexL = Utils.DecToHex(bytes[i].ToString()).Substring(2, 2);//A
                    if (bytes.Length > i + 1)
                        hexH = Utils.DecToHex(bytes[i + 1].ToString()).Substring(2, 2);//B

                    WordWrite(address++.ToString("X"), string.Format("{0}{1}", hexH, hexL)); //BA로 저장.
                }
                else
                {
                    WordWrite(address++.ToString("X"), "2020");
                }
            }

            WordWrite(address++.ToString("X"), Utils.DecToHex(glassData.GlassCodeXXYYYY.ToString()));
            WordWrite(address++.ToString("X"), Utils.DecToHex(glassData.GlassCodeZZZ.ToString()));

            WordWrite(address++.ToString("X"), "20" + Utils.DecToHex(Encoding.ASCII.GetBytes(glassData.GlassJudgeCode)[0].ToString()).Substring(2, 2));
            WordWrite(address++.ToString("X"), Utils.DecToHex(glassData.PPID.ToString()));
            //10 WORD
            address = int.Parse(Utils.HexToDec(property.ScanArea)) + 34;
            bytes = Encoding.ASCII.GetBytes(glassData.ProdID);
            for (int i = 0; i < 20; i += 2)
            {
                if (bytes.Length > i)
                {
                    string hexL = "";
                    string hexH = "";

                    hexL = Utils.DecToHex(bytes[i].ToString()).Substring(2, 2);//A
                    if (bytes.Length > i + 1)
                        hexH = Utils.DecToHex(bytes[i + 1].ToString()).Substring(2, 2);//B

                    WordWrite(address++.ToString("X"), string.Format("{0}{1}", hexH, hexL)); //BA로 저장.
                }
                else
                {
                    WordWrite(address++.ToString("X"), "2020");
                }
            }
            address = int.Parse(Utils.HexToDec(property.ScanArea)) + 44;
            WordWrite(address++.ToString("X"), Utils.BinaryToHex(glassData.ProcFlag));
            address++;
            WordWrite(address++.ToString("X"), Utils.BinaryToHex(glassData.JudgeFlag));
            address++;
            WordWrite(address++.ToString("X"), Utils.BinaryToHex(glassData.SkipFlag));
            address++;
            WordWrite(address++.ToString("X"), Utils.BinaryToHex(glassData.InspectionFlag));
            address++;
            WordWrite(address++.ToString("X"), Utils.BinaryToHex(glassData.Mode));

            bool assembled = false;
            bool array = false;
            bool cf = false;
            bool reserved = false;
            string thickness = Utils.DecToHex("1");
            bool maskGlass = false;
            bool dummyGlass = false;
            bool lastLotGlass = false;
            bool firstLoGlass = false;
            string glassSIze = Utils.DecToHex("1");

            string glassType1 = "";//glassData.GlassType
            glassType1 += assembled ? "1" : "0";
            glassType1 += array ? "1" : "0";
            glassType1 += cf ? "1" : "0";
            glassType1 += reserved ? "1" : "0";
            glassType1 += thickness;
            glassType1 += maskGlass ? "1" : "0";
            glassType1 += dummyGlass ? "1" : "0";
            glassType1 += lastLotGlass ? "1" : "0";
            glassType1 += firstLoGlass ? "1" : "0";
            glassType1 += glassSIze;

            string glassType2 = "";

            glassType2 += "000000";//F~A not used
            glassType2 += "00";
            glassType2 += "00";
            glassType2 += "00";
            glassType2 += "00";
            glassType2 += "11";//glassAngle
            WordWrite(address++.ToString("X"), Utils.BinaryToHex(glassType1));// GlassType1 
            WordWrite(address++.ToString("X"), Utils.BinaryToHex(glassType2));// GlassType2
            WordWrite(address++.ToString("X"), Utils.DecToHex(glassData.DummyType));
        }        
        /// <summary>
        /// sent out sub job
        /// </summary>
        /// <param name="controlName"></param>
        /// <param name="downstreamPathNo"></param>
        /// <param name="totalGlassCount"></param>
        internal void IDX_IW_SENT_OUT_JOB_DATA_SUB_BLOCK1(string controlName, string downstreamPathNo, string totalGlassCount)
        {
            CScanControlProperties property = _scans.GetProperty(controlName, "IW_SENT_OUT_JOB_DATA_SUB_BLOCK1");
            int address = int.Parse(Utils.HexToDec(property.ScanArea));
            WordWrite(address++.ToString("X"), Utils.DecToHex(downstreamPathNo));
            WordWrite(address++.ToString("X"), Utils.DecToHex(totalGlassCount));
        }

        internal void BC_CIMMessageSetCommand(string p, string p_2, string p_3, bool value)
        {
            BC_CIMMessageSetCommandData(_controlName, p, p_2, p_3);
            BC_CIMMessageSetCommand(_controlName, value);
        }
        private void BC_CIMMessageSetCommand(string controlName, bool value)
        {
            BitWrite(_scans.GetProperty(controlName, "IB_CIM_MESSAGE_SET_COMMAND"), value);
        }
        private void BC_CIMMessageSetCommandData(string controlName, string p, string p_2, string p_3)
        {
            WordWriteByHexValue(_scans.GetProperty(controlName, "IW_CIM_MESSAGE_SET_MESSAGE_ID"), p);
            WordWriteByHexValue(_scans.GetProperty(controlName, "IW_CIM_MESSAGE_SET_TOUCH_PANEL_NO"), p_2);

            char[] temp = p_3.ToCharArray();
            string hex = "";
            CScanControlProperties property = _scans.GetProperty(controlName, "IW_CIM_MESSAGE_SET_MSG_DATA");
            int address = int.Parse(Utils.HexToDec(property.ScanArea));
            for (int i = 0; i < temp.Length; i = i + 2)
            {
                if (temp.Length <= i + 1)
                    break;
                hex += Utils.DecToHex(((int)temp[i + 1]).ToString()).Substring(2,2);
                hex += Utils.DecToHex(((int)temp[i]).ToString()).Substring(2, 2);
                WordWrite(Utils.DecToHex(address++.ToString()) , hex);
                hex = "";
            }            
        }

        internal void BC_CIMMessageClearCommand(string messageID, string touchPanelNo, bool value)
        {
            BC_CIMMessageClearCommandData(_controlName, messageID, touchPanelNo);
            BC_CIMMessageClearCommand(_controlName, value);
        }
        private void BC_CIMMessageClearCommand(string controlName, bool value)
        {
            BitWrite(_scans.GetProperty(controlName, "IB_CIM_MESSAGE_CLEAR_COMMAND"), value);
        }
        private void BC_CIMMessageClearCommandData(string controlName, string messageID, string touchPanelNo)
        {
            WordWriteByHexValue(_scans.GetProperty(controlName, "IW_CIM_MESSAGE_CLEAR_MESSAGE_ID"), messageID);
            WordWriteByHexValue(_scans.GetProperty(controlName, "IW_CIM_MESSAGE_CLEAR_TOUCH_PANEL_NO"), touchPanelNo);
        }

        internal void BC_MachineTimeSetCommand(string yyyy, string MM, string dd, string hh, string mm, string ss, bool value)
        {
            BC_MachineTimeSetCommandData(_controlName, yyyy, MM,dd,hh,mm,ss);
            BC_MachineTimeSetCommand(_controlName, value);
        }

        private void BC_MachineTimeSetCommand(string controlName, bool value)
        {
            BitWrite(_scans.GetProperty(controlName, "IB_MACHINE_TIME_SET_COMMAND"), value);
        }
        private void BC_MachineTimeSetCommandData(string controlName, string yyyy, string MM, string dd, string hh, string mm, string ss)
        {
            WordWriteByHexValue(_scans.GetProperty(controlName, "IW_MACHINE_TIME_SEND_YEAR"), yyyy);
            WordWriteByHexValue(_scans.GetProperty(controlName, "IW_MACHINE_TIME_SEND_MONTH"), MM);
            WordWriteByHexValue(_scans.GetProperty(controlName, "IW_MACHINE_TIME_SEND_DAY"), dd);
            WordWriteByHexValue(_scans.GetProperty(controlName, "IW_MACHINE_TIME_SEND_HOUR"), hh);
            WordWriteByHexValue(_scans.GetProperty(controlName, "IW_MACHINE_TIME_SEND_MINUTE"), mm);
            WordWriteByHexValue(_scans.GetProperty(controlName, "IW_MACHINE_TIME_SEND_SECOND"), ss);
        }

        internal void EQ_GlassDataRequest(CGlassData glassData)
        {
            CScanControlProperties property = _scans.GetProperty(ControlName, "IW_GLASS_DATA_SEND");

            //LotID
            char[] temp = glassData.LotID.ToCharArray();

            int address = int.Parse(Utils.HexToDec(property.ScanArea));
            string hex = "";
            for (int i = 0; i < temp.Length; i = i + 2)
            {
                if (temp.Length <= i + 1)
                {
                    WordWrite(Utils.DecToHex((address++).ToString()), "0000");
                    break;
                }
                else
                {
                    hex += Utils.DecToHex(((int)temp[i + 1]).ToString()).Substring(2, 2);
                    hex += Utils.DecToHex(((int)temp[i]).ToString()).Substring(2, 2);
                    WordWrite(Utils.DecToHex((address++).ToString()), hex);
                }
                hex = "";
            }

            //GLASSID
            address = int.Parse(Utils.HexToDec(property.ScanArea)) + 10;
            temp = glassData.GlassID.ToCharArray();
            hex = "";
            for (int i = 0; i < temp.Length; i = i + 2)
            {
                if (temp.Length <= i + 1)
                {
                    WordWrite(Utils.DecToHex((address++).ToString()), "0000");
                }
                else
                {
                    hex += Utils.DecToHex(((int)temp[i + 1]).ToString()).Substring(2, 2);
                    hex += Utils.DecToHex(((int)temp[i]).ToString()).Substring(2, 2);
                    WordWrite(Utils.DecToHex((address++).ToString()), hex);
                }
                hex = "";
            }
            
            //OPERID
            address = int.Parse(Utils.HexToDec(property.ScanArea)) + 20;
            temp = glassData.OperID.ToCharArray();
            hex = "";
            for (int i = 0; i < temp.Length; i = i + 2)
            {
                if (temp.Length <= i + 1)
                {
                    WordWrite(Utils.DecToHex((address++).ToString()), "0000");
                }
                else
                {
                    hex += Utils.DecToHex(((int)temp[i + 1]).ToString()).Substring(2, 2);
                    hex += Utils.DecToHex(((int)temp[i]).ToString()).Substring(2, 2);
                    WordWrite(Utils.DecToHex((address++).ToString()), hex);
                }
                hex = "";
            }
            //GLASSCODE01
            address = int.Parse(Utils.HexToDec(property.ScanArea)) + 30;
            WordWrite(Utils.DecToHex((address++).ToString()), Utils.DecToHex(glassData.GlassCodeXXYYYY.ToString()));
            WordWrite(Utils.DecToHex((address++).ToString()), Utils.DecToHex(glassData.GlassCodeZZZ.ToString()));
            WordWrite(Utils.DecToHex((address++).ToString()), Utils.DecToHex("20" + ((int)glassData.GlassJudgeCode[0]).ToString("X")));
            WordWrite(Utils.DecToHex((address++).ToString()), Utils.DecToHex(glassData.PPID.ToString()));
            
            temp = glassData.ProdID.ToCharArray();
            hex = "";
            for (int i = 0; i < temp.Length; i = i + 2)
            {
                if (temp.Length <= i + 1)
                {
                    WordWrite(Utils.DecToHex((address++).ToString()), "0000");
                }
                else
                {
                    hex += Utils.DecToHex(((int)temp[i + 1]).ToString()).Substring(2, 2);
                    hex += Utils.DecToHex(((int)temp[i]).ToString()).Substring(2, 2);
                    WordWrite(Utils.DecToHex((address++).ToString()), hex);
                }
                hex = "";
            }
            address += 10;
            
            WordWrite(Utils.DecToHex((address++).ToString()), "0000");//CIM PC DATA1
            WordWrite(Utils.DecToHex((address++).ToString()), "0000");//CIM PC DATA2

            string procFlag1 = glassData.ProcFlag.Substring(0, 16);
            string procFlag2 =glassData.ProcFlag.Substring(16, 16);
            procFlag1 = Utils.ReverseString(procFlag1);
            procFlag2 = Utils.ReverseString(procFlag2);
            WordWrite(Utils.DecToHex((address++).ToString()), Utils.BinaryToHex(procFlag1));
            WordWrite(Utils.DecToHex((address++).ToString()), Utils.BinaryToHex(procFlag2));

            string judgeFlag1 = glassData.JudgeFlag.Substring(0, 16);
            string judgeFlag2 = glassData.JudgeFlag.Substring(16, 16);
            judgeFlag1 = Utils.ReverseString(judgeFlag1);
            judgeFlag2 = Utils.ReverseString(judgeFlag2);
            WordWrite(Utils.DecToHex((address++).ToString()), Utils.BinaryToHex(judgeFlag1));
            WordWrite(Utils.DecToHex((address++).ToString()), Utils.BinaryToHex(judgeFlag2));

            string skipFlag1 = glassData.SkipFlag.Substring(0, 16);
            string skipFlag2 = glassData.SkipFlag.Substring(16, 16);
            skipFlag1 = Utils.ReverseString(skipFlag1);
            skipFlag2 = Utils.ReverseString(skipFlag2);
            WordWrite(Utils.DecToHex((address++).ToString()), Utils.BinaryToHex(skipFlag1));
            WordWrite(Utils.DecToHex((address++).ToString()), Utils.BinaryToHex(skipFlag2));

            string inpectionFlag1 = glassData.InspectionFlag.Substring(0, 16);
            string inpectionFlag2 = glassData.InspectionFlag.Substring(16, 16);
            inpectionFlag1 = Utils.ReverseString(inpectionFlag1);
            inpectionFlag2 = Utils.ReverseString(inpectionFlag2);
            WordWrite(Utils.DecToHex((address++).ToString()), Utils.BinaryToHex(inpectionFlag1));
            WordWrite(Utils.DecToHex((address++).ToString()), Utils.BinaryToHex(inpectionFlag2));

            WordWrite(Utils.DecToHex((address++).ToString()), Utils.DecToHex(glassData.Mode));
            WordWrite(Utils.DecToHex((address++).ToString()), Utils.BinaryToHex(glassData.GlassType));
            WordWrite(Utils.DecToHex((address++).ToString()), Utils.DecToHex(glassData.DummyType));

            string option =  EQ_GlassDataReqOptione(_controlName);
            string glassID = EQ_GlassDataReqGlassID(_controlName);
            string glassCode = EQ_GlassDataReqGlassCode(_controlName);

            BC_GlassDataRequestConfirm(_controlName, true);
        }
        public string EQ_GlassDataReqOptione(string controlName)
        {
            return WordRead(_plcs.GetProperty(controlName, "OW_GLS_DATA_REQ_OPTION"));
        }
        public string EQ_GlassDataReqGlassID(string controlName)
        {
            return WordRead(_plcs.GetProperty(controlName, "OW_GLS_DATA_REQ_GLASS_ID"));
        }
        public string EQ_GlassDataReqGlassCode(string controlName)
        {
            //IB_GLASS_DATA_REQUEST_CONFIRM = _main.SCANCONTEROLS.GetProperty(_controlName, "IB_GLASS_DATA_REQUEST_CONFIRM");
            //IW_GLASS_DATA_SEND = _main.SCANCONTEROLS.GetProperty(_controlName, "IW_GLASS_DATA_SEND");
            //IW_GLASS_DATA_REQUEST_ACK = _main.SCANCONTEROLS.GetProperty(_controlName, "IW_GLASS_DATA_REQUEST_ACK");

            //OB_GLASS_DATA_REQUEST = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_GLASS_DATA_REQUEST");
            //OW_GLS_DATA_REQ_OPTION = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_GLS_DATA_REQ_OPTION");
            //OW_GLS_DATA_REQ_GLASS_ID = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_GLS_DATA_REQ_GLASS_ID");
            //OW_GLS_DATA_REQ_GLASS_CODE = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_GLS_DATA_REQ_GLASS_CODE");

            return WordRead(_plcs.GetProperty(controlName, "OW_GLS_DATA_REQ_GLASS_CODE"));
        }

        internal void BC_GlassDataRequestConfirm(string controlName, bool value)
        {
            BitWrite(_scans.GetProperty(controlName, "IB_GLASS_DATA_REQUEST_CONFIRM"), value);            
        }

        internal void BC_ReceivedJobReportReplyUpstreamPath1(bool value)
        {
            BitWrite(_scans.GetProperty(_controlName, "IB_RECEIVED_JOB_REPORT_REPLY_UPSTREAM_PATH1"), value);     
        }

        internal void BC_SentOutJobReportReplyUpstreamPath1(bool value)
        {
            BitWrite(_scans.GetProperty(_controlName, "IB_SENT_OUT_JOB_REPORT_REPLY_DOWNSTREAM_PATH1"), value);     
        }

        internal void BC_ScrapJobReportReply(bool value)
        {
            BitWrite(_scans.GetProperty(_controlName, "IB_SCRAP_JOB_REPORT_REPLY"), value);     
        }

        internal void BC_MachineRecipeRequestData(int recipeId, int returnCode)
        {
            WordWrite(_scans.GetProperty(_controlName, "IW_MACHINE_RECIPE_CONFIRM_RETURN_CODE").Area, Utils.DecToHex(returnCode.ToString()));
            WordWrite(_scans.GetProperty(_controlName, "IW_MACHINE_RECIPE_CONFIRM_SEND_MACHINE_RECIPE").Area, Utils.DecToHex(recipeId.ToString()));
        }

        internal void BC_MachineRecipeRequestConfirm(bool value)
        {
            BitWrite(_scans.GetProperty(_controlName, "IB_MACHINE_RECIPE_REQUEST_CONFIRM"), value);
        }

        internal string EQ_MachineRecipeReqPPID()
        {
            return WordRead(_plcs.GetProperty(_controlName, "OW_MACHINE_RECIPE_REQUEST_PPID"));
        }

        internal string EQ_MachineRecipeReqUnitID()
        {
            return WordRead(_plcs.GetProperty(_controlName, "OW_MACHINE_RECIPE_REQUEST_UNIT_ID"));
        }

        internal ushort[] IDX_IW_JOB_DATA_FOR_UPSTREAM_BLOCK1(string controlName)
        {
            CScanControlProperties property = _scans.GetProperty(controlName, "IW_JOB_DATA_FOR_UPSTREAM_BLOCK1");
            return GetJobDataA(property);
        }

        internal ushort[] IDX_IW_SENT_OUT_JOB_DATA_SUB_BLOCK1(string controlName)
        {   
            CScanControlProperties property = _scans.GetProperty(controlName, "IW_SENT_OUT_JOB_DATA_SUB_BLOCK1");
            return GetSubJobDataA(property);
        }

        #region 공용 메서드
        public ushort[] GetJobDataA(AControlProperties property)
        {
            List<ushort> glassData = new List<ushort>();
            int address = int.Parse(Utils.HexToDec(property.Area));

            //LotID;
            //10 WORD
            for (int i = 0; i < 10; i++)
            {
                glassData.Add(ushort.Parse(Utils.HexToDec(WordRead(address++.ToString("X")))));
            }
            //GlassID
            //10 WORD
            for (int i = 0; i < 10; i++)
            {
                glassData.Add(ushort.Parse(Utils.HexToDec(WordRead(address++.ToString("X")))));
            }
            //OperID
            //10 WORD
            for (int i = 0; i < 10; i++)
            {
                glassData.Add(ushort.Parse(Utils.HexToDec(WordRead(address++.ToString("X")))));
            }
            //GlassCodeXXYYYY
            glassData.Add(ushort.Parse(Utils.HexToDec(WordRead(address++.ToString("X")))));
            //GlassCodeZZZ
            glassData.Add(ushort.Parse(Utils.HexToDec(WordRead(address++.ToString("X")))));
            //GlassJudgeCode
            glassData.Add(ushort.Parse(Utils.HexToDec(WordRead(address++.ToString("X")))));
            //PPID
            glassData.Add(ushort.Parse(Utils.HexToDec(WordRead(address++.ToString("X")))));
            //ProdID
            //10 WORD
            for (int i = 0; i < 10; i++)
            {
                glassData.Add(ushort.Parse(Utils.HexToDec(WordRead(address++.ToString("X")))));
            }
            //ProcFlag
            glassData.Add(ushort.Parse(Utils.HexToDec(WordRead(address++.ToString("X")))));
            glassData.Add(ushort.Parse(Utils.HexToDec(WordRead(address++.ToString("X")))));
            //JudgeFlag
            glassData.Add(ushort.Parse(Utils.HexToDec(WordRead(address++.ToString("X")))));
            glassData.Add(ushort.Parse(Utils.HexToDec(WordRead(address++.ToString("X")))));
            //SkipFlag
            glassData.Add(ushort.Parse(Utils.HexToDec(WordRead(address++.ToString("X")))));
            glassData.Add(ushort.Parse(Utils.HexToDec(WordRead(address++.ToString("X")))));
            //InspectionFlag
            glassData.Add(ushort.Parse(Utils.HexToDec(WordRead(address++.ToString("X")))));
            glassData.Add(ushort.Parse(Utils.HexToDec(WordRead(address++.ToString("X")))));
            //Mode
            glassData.Add(ushort.Parse(Utils.HexToDec(WordRead(address++.ToString("X")))));

            //glassType1
            glassData.Add(ushort.Parse(Utils.HexToDec(WordRead(address++.ToString("X")))));
            glassData.Add(ushort.Parse(Utils.HexToDec(WordRead(address++.ToString("X")))));

            //glassType2
            glassData.Add(ushort.Parse(Utils.HexToDec(WordRead(address++.ToString("X")))));
            glassData.Add(ushort.Parse(Utils.HexToDec(WordRead(address++.ToString("X")))));
            //DummyType
            glassData.Add(ushort.Parse(Utils.HexToDec(WordRead(address++.ToString("X")))));
            glassData.Add(ushort.Parse(Utils.HexToDec(WordRead(address++.ToString("X")))));
            //Panel Grade Code
            glassData.Add(ushort.Parse(Utils.HexToDec(WordRead(address++.ToString("X")))));
            //ArrayRepairRule
            glassData.Add(ushort.Parse(Utils.HexToDec(WordRead(address++.ToString("X")))));
            glassData.Add(ushort.Parse(Utils.HexToDec(WordRead(address++.ToString("X")))));
            //Reserved
            glassData.Add(ushort.Parse(Utils.HexToDec(WordRead(address++.ToString("X")))));
            glassData.Add(ushort.Parse(Utils.HexToDec(WordRead(address++.ToString("X")))));
            glassData.Add(ushort.Parse(Utils.HexToDec(WordRead(address++.ToString("X")))));
            glassData.Add(ushort.Parse(Utils.HexToDec(WordRead(address++.ToString("X")))));
            glassData.Add(ushort.Parse(Utils.HexToDec(WordRead(address++.ToString("X")))));

            return glassData.ToArray();
        }

        public ushort[] GetSubJobDataA(AControlProperties property)
        {
            List<ushort> glassData = new List<ushort>();
            int address = int.Parse(Utils.HexToDec(property.Area));
            glassData.Add(ushort.Parse(Utils.HexToDec(WordRead(address++.ToString("X")))));
            glassData.Add(ushort.Parse(Utils.HexToDec(WordRead(address++.ToString("X")))));
            return glassData.ToArray();
        }
        #endregion
    }

    public enum Att
    {
        OB_RUNNING,
        OB_CIM_MODE,
        OB_MACHINE_AUTO_MODE,
        OB_AUTO_RECIPE_CHANGE_MODE,
        OB_MACHINE_HEARTBEAT_SIGNAL,
        OB_MACHINE_STATUS_CHANGE_REPORT,
        OB_CIM_MODE_CHANGE_COMMAND_REPLY,
        OB_MACHINE_TIME_SET_REPLY,
        OB_LIGHT_ALARM_OCCURRED,
        OB_LIGHT_ALARM_CLEARED,
        OB_SERIOUS_ALARM_OCCURRED,
        OB_SERIOUS_ALARM_CLEARED,
        OB_RECEIVED_JOB_REPORT_UPSTREAMPATH1,
        OB_SENT_OUT_JOB_REPORT_DOWNSTREAMPATH1,
        OB_SCRAP_JOB_REPORT,
        OB_STORED_JOB_REPORT,
        OB_FETCHED_OUT_JOB_REPORT,
        OB_GLASS_DATA_CHANGE_REPORT,
        OB_GLASS_PROCESS_START_REPORT,
        OB_GLASS_PROCESS_END_REPORT,
        OB_DV_DATA_REPORT,
        OB_RECIPE_LIST_CHANGE_REPORT,
        OB_MACHINE_RECIPE_REQUEST,
        OB_RECIPE_PARAMETER_DATA_REPORT,
        OB_RECIPE_PARAMETER_DATA_CHANGE_REPORT,
        OB_PROCESSING_PPID_RECIPE_CHANGE_REPORT,
        OB_RECIPE_PARMATER_DOWN_CONFIRM,
        OB_MACHINE_CIM_MESSAGE_CONFIRM,
        OB_PANEL_DATA_REQUEST,
        OB_PANEL_DATA_REPORT,
        OB_GLASS_JUDGE_RESULT_REQUEST,
        OB_GLASS_JUDGE_RESULT_REPORT,
        OB_GLASS_DATA_REQUEST,
        OB_IONIZER_STATUS_REPORT,
        OB_MACHINE_MODE_CHANGE_COMMAND_REPLY,
        OB_MACHINE_MODE_CHANGE_REPORT,
        OW_JOB_DATA_FOR_DOWNSTREAM_BLOCK1,
        OW_SENT_OUT_JOB_DATA_SUB_BLOCK1,
        OW_JOB_DATA_FOR_UPSTREAM_BLOCK1,
        OW_RECEIVED_JOB_DATA_SUB_BLOCK1,
        OW_SCRAP_DATA_GLASS_CODE,
        OW_SCRAP_DATA_SCRAP_CODE,
        OW_SCRAP_DATA_UNIT_ID,
        OW_SCRAP_DATA_OPERATORID,
        OW_STORED_DATA_UNIT_OR_PORT,
        OW_STORED_DATA_UNIT_NO,
        OW_STORED_DATA_SUB_UNIT_NO,
        OW_STORED_DATA_PORT_NO,
        OW_STORED_DATA_SLOT_NO,
        OW_FETCHED_OUT_DATA_JOB_DATA_BLOCK,
        OW_FETCHED_OUT_SUB_DATA_UNIT_OR_PORT,
        OW_FETCHED_OUT_SUB_DATA_UNIT_NO,
        OW_FETCHED_OUT_SUB_DATA_SUB_UNIT_NO,
        OW_FETCHED_OUT_SUB_DATA_PORT_NO,
        OW_FETCHED_OUT_SUB_DATA_SLOT_NO,
        OW_GLASS_DATA_CHANGE_REPORT,
        OW_GLS_PROCESS_START_GLASS_CODE,
        OW_GLS_PROCESS_START_UNIT_NO,
        OW_GLS_PROCESS_END_GLASS_CODE,
        OW_GLS_PROCESS_END_UNIT_NO,
        OW_MACHINE_STATUS,
        OW_MACHINE_REASON_CODE,
        OW_MACHINE_DOWN_ALARM_CODE,
        OW_UNIT1_STATUS,
        OW_MACHINE_GLASS_COUNT,
        OW_POSITION_GLASS_EXIST,
        OW_POSITION001_GLASS_CODE,
        OW_POSITION002_GLASS_CODE,
        OW_MACHINE_CIM_MESSAGE_ID,
        OW_MACHINE_TOUCH_PANLE_NO,
        OW_CIM_MODE_CHANGE_RETURN_CODE,
        OW_LIGHT_ALAM_CODE,
        OW_SERIOUS_ALARM_CODE,
        OW_RECIPE_PARAMETER_DOWN_RESULT,
        OW_MACHINE_RECIPE_REQUEST_PPID,
        OW_MACHINE_RECIPE_REQUEST_UNIT_ID,
        OW_MACHINE_RECIPE_LIST,
        OW_PROCESSING_PPID,
        OW_PROCESSING_MACHINE_RECIPE,
        OW_GLS_JUDGE_REQ_OPTION,
        OW_GLS_JUDGE_REQ_GLASS_ID,
        OW_GLS_JUDGE_REQ_GLASS_CODE,
        OW_GLS_JUDGE_REQ_GLASS_JUDGE_RESULT,
        OW_GLS_JUDGE_RRT_OPTION,
        OW_GLS_JUDGE_RRT_GLASS_ID,
        OW_GLS_JUDGE_RRT_GLASS_CODE,
        OW_GLS_JUDGE_RRT_GLASS_JUDGE_RESULT,
        OW_GLS_DATA_REQ_OPTION,
        OW_GLS_DATA_REQ_GLASS_ID,
        OW_GLS_DATA_REQ_GLASS_CODE,
        OW_IONIZER_STATUS,
        OW_MACHINE_MODE_CHANGE_RETURN_CODE,
        OW_MACHINE_MODE,
        OW_MACHINE_RECIPE,
        OW_RECIPE_PARAMETER_DATA,
        OW_CV_DATA,
        OW_SV_DATA,
        OW_DV_GLASS_CODE,
        OW_DV_PROCESSING_IN_UNIT,
        OW_DV_UNIT1_PROCESSED_HOUR,
        OW_DV_UNIT1_PROCESSED_MIN,
        OW_DV_UNIT1_PROCESSED_SEC,
        OW_DV_UNIT1_PROCESSED_MILSEC,
        OW_DV_DATA,
        IB_RECEIVED_JOB_REPORT_REPLY_UPSTREAM_PATH1,
        IB_SENT_OUT_JOB_REPORT_REPLY_DOWNSTREAM_PATH1,
        IB_SCRAP_JOB_REPORT_REPLY,
        IB_STORED_JOB_REPORT_REPLY,
        IB_FETCHED_OUT_JOB_REPORT_REPLY,
        IB_GLASS_DATA_CHANGE_REPORT_REPLY,
        IB_GLASS_PROCESS_START_REPORT_REPLY,
        IB_GLASS_PROCESS_END_REPORT_REPLY,
        IB_MACHINE_RECIPE_REQUEST_CONFIRM,
        IB_MACHINE_STATUS_CHANGE_REPORT_REPLY,
        IB_RECIPE_PARAMETER_REQUEST,
        IB_RECIPE_PARAMETER_DOWNLOAD,
        IB_CIM_MESSAGE_SET_COMMAND,
        IB_CIM_MESSAGE_CLEAR_COMMAND,
        IB_MACHINE_TIME_SET_COMMAND,
        IB_CIM_MODE_CHANGE_COMMAND,
        IB_GLASS_JUDGE_RESULT_REQUEST_CONFIRM,
        IB_GLASS_JUDGE_RESULT_REPORT_REPLY,
        IB_GLASS_DATA_REQUEST_CONFIRM,
        IB_MACHINE_MODE_CHANGE_COMMAND,
        IB_LOADING_STOP_REQUEST_REPLY_CIM,
        IB_LOADING_STOP_RELEASE_REPLY_CIM,
        IW_CIM_MESSAGE_SET_MESSAGE_ID,
        IW_CIM_MESSAGE_SET_TOUCH_PANEL_NO,
        IW_CIM_MESSAGE_SET_MSG_DATA,
        IW_CIM_MESSAGE_CLEAR_MESSAGE_ID,
        IW_CIM_MESSAGE_CLEAR_TOUCH_PANEL_NO,
        IW_CIM_MODE,
        IW_MACHINE_TIME_SEND_YEAR,
        IW_MACHINE_TIME_SEND_MONTH,
        IW_MACHINE_TIME_SEND_DAY,
        IW_MACHINE_TIME_SEND_HOUR,
        IW_MACHINE_TIME_SEND_MINUTE,
        IW_MACHINE_TIME_SEND_SECOND,
        IW_MACHINE_RECIPE_CONFIRM_RETURN_CODE,
        IW_MACHINE_RECIPE_CONFIRM_SEND_MACHINE_RECIPE,
        IW_RECIPE_PARAMETER_REQUEST_MACHINE_RECIPE,
        IW_RECIPE_PARAMETER_REQUEST_UNIT_ID,
        IW_MACHINE_SEND_GLASS_JUDGE_RESULT,
        IW_GLASS_DATA_SEND,
        IW_GLASS_DATA_REQUEST_ACK,
        IW_MACHINE_MODE_CHANGE_COMMAND,
        IW_LOADING_STOP_REQUEST_RETURN,
        IW_LOADING_STOP_RELEASE_RETURN,
        IW_MACHINE_RECIPE,
        IW_RECIPE_PARAMETER_DATA_DOWNLOAD,
        OB_LINK_UP1_UPSTREAM_INLINE,
        OB_LINK_UP1_UPSTREAM_TROUBLE,
        OB_LINK_UP1_SLOT_NUMBER1,
        OB_LINK_UP1_SLOT_NUMBER2,
        OB_LINK_UP1_SLOT_NUMBER3,
        OB_LINK_UP1_SLOT_NUMBER4,
        OB_LINK_UP1_SLOT_NUMBER5,
        OB_LINK_UP1_SLOT_PAIR_FLAG,
        OB_LINK_UP1_ARM_SLOT_PAIR_FLAG,
        OB_LINK_UP1_JOB_TRANSFER_SIGNAL,
        OB_LINK_UP1_SEND_ABLE,
        OB_LINK_UP1_SEND_START,
        OB_LINK_UP1_SEND_COMPLETE,
        OB_LINK_UP1_EXCHANGE_POSSIBLE,
        OB_LINK_UP1_EXCHANGE_EXECUTE,
        OB_LINK_UP1_RESUME_REQUEST,
        OB_LINK_UP1_RESUME_ACK,
        OB_LINK_UP1_CANCEL_REQUEST,
        OB_LINK_UP1_CANCEL_ACK,
        OB_LINK_UP1_ABORT_REQUEST,
        OB_LINK_UP1_ABOR_ACK,
        OB_LINK_UP1_CONVEYER_STATE,
        OB_LINK_UP1_SHUTTER_STATE,
        OB_LINK_UP1_FIRST_SLOT_EXIST,
        OB_LINK_UP1_SECOND_SLOT_EXIST,
        OB_LINK_UP1_THIRD_SLOT_EXIST,
        OB_LINK_UP1_FOURTH_SLOT_EXIST,
        OB_LINK_UP1_CHK__ABNORMAL,
        OB_LINK_UP1_CHK__EMPTY,
        OB_LINK_UP1_CHK__IDLE,
        OB_LINK_UP1_CHK__RUN,
        OB_LINK_UP1_CHK__COMPLETE,
        OB_LINK_UP1_CHK__PIN_UP,
        OB_LINK_UP1_CHK__PIN_DOWN,
        OB_LINK_UP1_CHK__STOPPER_UP_OR_DOOR_OPEN,
        OB_LINK_UP1_CHK__STOPPER_DOWN_OR_DOOR_CLOSE,
        OB_LINK_UP1_CHK__MANUAL_OPERATION,
        OB_LINK_UP1_CHK__BODY_MOVING,
        OB_LINK_UP1_CHK__GLASS_EXIST_ARM1,
        OB_LINK_UP1_CHK__GLASS_EXIST_ARM2,
        OB_LINK_UP1_CHK__GLASS_EXIST_ARM3,
        OB_LINK_UP1_CHK__GLASS_EXIST_ARM4,
        OB_LINK_UP1_CHK__MAKE_DEFINE1,
        OB_LINK_UP1_CHK__MAKE_DEFINE2,
        OB_LINK_UP1_CHK__MAKE_DEFINE3,
        OB_LINK_UP1_CHK__MAKE_DEFINE4,
        OB_LINK_UP1_CHK__MAKE_DEFINE5,
        OB_LINK_UP1_CHK__MAKE_DEFINE6,
        OB_LINK_UP1_CHK__MAKE_DEFINE7,
        OB_LINK_UP1_CHK__MAKE_DEFINE8,
        OB_LINK_DOWN1_DOWNSTREAM_INLINE,
        OB_LINK_DOWN1_DOWNSTREAM_TROUBLE,
        OB_LINK_DOWN1_SLOT_NUMBER1,
        OB_LINK_DOWN1_SLOT_NUMBER2,
        OB_LINK_DOWN1_SLOT_NUMBER3,
        OB_LINK_DOWN1_SLOT_NUMBER4,
        OB_LINK_DOWN1_SLOT_PAIR_FLAG,
        OB_LINK_DOWN1_ARM_SLOT_PAIR_FLAG,
        OB_LINK_DOWN1_JOB_TRANSFER_SIGNAL,
        OB_LINK_DOWN1_RECEIVE_ABLE,
        OB_LINK_DOWN1_RECEIVE_START,
        OB_LINK_DOWN1_RECEIVE_COMPLETE,
        OB_LINK_DOWN1_EXCHANGE_POSSIBLE,
        OB_LINK_DOWN1_EXCHANGE_EXECUTE,
        OB_LINK_DOWN1_RESUME_REQUEST,
        OB_LINK_DOWN1_RESUME_ACK,
        OB_LINK_DOWN1_CANCEL_REQUEST,
        OB_LINK_DOWN1_CANCEL_ACK,
        OB_LINK_DOWN1_ABORT_REQUEST,
        OB_LINK_DOWN1_ABORT_ACK,
        OB_LINK_DOWN1_CONVEYER_STATE,
        OB_LINK_DOWN1_SHUTTER_STATE,
        OB_LINK_DOWN1_FIRST_SLOT_EXIST,
        OB_LINK_DOWN1_SECOND_SLOT_EXIST,
        OB_LINK_DOWN1_THIRD_SLOT_EXIST,
        OB_LINK_DOWN1_FOURTH_SLOT_EXIST,
        OB_LINK_DOWN1_CHK__ABNORMAL,
        OB_LINK_DOWN1_CHK__EMPTY,
        OB_LINK_DOWN1_CHK__IDLE,
        OB_LINK_DOWN1_CHK__RUN,
        OB_LINK_DOWN1_CHK__COMPLETE,
        OB_LINK_DOWN1_CHK__LIFT_UP_OR_PIN_UP,
        OB_LINK_DOWN1_CHK__LIFT_DOWN_OR_PIN_DOWN,
        OB_LINK_DOWN1_CHK__STOPPER_UP_OR_DOOR_OPEN,
        OB_LINK_DOWN1_CHK__STOPPER_DOWN_OR_DOOR_CLOSE,
        OB_LINK_DOWN1_CHK__MANUAL_OPERATION,
        OB_LINK_DOWN1_CHK__BODY_MOVING,
        OB_LINK_DOWN1_CHK__GLASS_EXIST_ARM1,
        OB_LINK_DOWN1_CHK__GLASS_EXIST_ARM2,
        OB_LINK_DOWN1_CHK__GLASS_EXIST_ARM3,
        OB_LINK_DOWN1_CHK__GLASS_EXIST_ARM4,
        OB_LINK_DOWN1_CHK__MAKE_DEFINE1,
        OB_LINK_DOWN1_CHK__MAKE_DEFINE2,
        OB_LINK_DOWN1_CHK__MAKE_DEFINE3,
        OB_LINK_DOWN1_CHK__MAKE_DEFINE4,
        OB_LINK_DOWN1_CHK__MAKE_DEFINE5,
        OB_LINK_DOWN1_CHK__MAKE_DEFINE6,
        OB_LINK_DOWN1_CHK__MAKE_DEFINE7,
        OB_LINK_DOWN1_CHK__MAKE_DEFINE8,
    }
}
