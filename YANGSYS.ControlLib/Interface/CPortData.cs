using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOFD.DataConvert;

namespace YANGSYS.ControlLib
{
    public class CPortData
    {
        /// <summary>
        /// RecipeID
        /// </summary>
        public string PPID { get; set; }

        /// <summary>
        /// mes에서 내려 받을 때 LotID저장 하기.
        /// </summary>
        public string LotID { get; set; }

        public string portControlName { get; set; }
        /// <summary> 
        /// 1 : PB(Load/Unload Both Port)
        ///2 : PL(Loading Port)
        ///3 : PU(Unloading Port)
        ///4：Buffer Port - BB(Buffer Both L/U)
        ///5 : Buffer Port - BL(Loader in Buffer Type)
        ///6 : Buffer Port - BU(Un-loader in Buffer Type)
        ///7 : Buffer Port - BO(Buffer Only)
        /// </summary>
        public Int16 PortType { get; set; }

        /// <summary> 
        /// 1 : TFT Mode
        ///2 : CF Mode
        ///3:  TC Mode(TFT/CF Both)
        ///4 : ITO Dummy Mode
        ///5 : Bare Dummy Mode 
        ///6 : Through Dummy Mode
        ///7 : General Dummy Mode
        ///8 : MQC Dummy Mode 
        ///9 : Thickness Dummy Mode
        ///10 : Contact Angle Dummy
        ///11 : Sort Mode
        ///12 : MIX Mode
        ///13 : OK Mode
        ///14 : NG Mode
        ///15 : Rework Mode
        ///16 : Repair Mode
        ///17 : Reject Mode
        ///18 : SK Mode
        ///19 : EMP Mode (Empty Cassette)
        ///20 : Y Mode
        ///21 : L Mode
        ///22 : Q Mode
        ///23 : C Mode
        ///24 : Scrap Mode
        ///25 : Mismatch Mode
        ///26 : Abnormal Mode
        ///27 : TFT Not ODF Mode
        ///28 : CF Not ODF Mode
        ///29 : UV Mask Mode
        /// </summary>
        public Int16 PortUseType { get; set; }

        /// <summary> 
        ///1 : Load Request
        ///2 : Pre Load Complete
        ///3 : Load Complete
        ///4 : Unload Request
        ///5 : Unload Complete
        ///6 : Down
        /// </summary>
        public enumPortStatus2 PortStatus { get; set; }

        /// <summary> 
        /// 1: No Cassette Exist  
        ///2: Waiting for Cassette Data
        ///3: WaitingforStart Command    
        ///4: Waiting for Processing
        ///5: Inprocessing
        ///6: Process Paused
        ///7: Process Canceled
        ///8: Process Aborted
        ///9: Process Normal Completed
        /// </summary>
        public Int32 CassetteStatus { get; set; }

        /// <summary> 
        /// 
        /// </summary>
        public Int32 CassetteIndex { get; set; }

        /// <summary> 
        /// Cassette ID 
        /// </summary>
        public string CassetteID { get; set; }

        /// <summary> 
        /// 1~65535
        /// </summary>
        public Int16 JobCountinCassette { get; set; }

        /// <summary> 
        /// 1: Normal Complete
        ///2: Operator Forced Cancel on Touch Panel
        ///3: Operator Forced Abort on Touch Panel
        ///4: CIS Forced Cancel
        ///5: CIS Forced Abort
        ///6: EQ Auto Cancel
        ///7: EQ Auto Abort
        /// </summary>
        public Int16 CassetteCompletedReasonCode { get; set; }

        /// <summary> 
        /// ON=O, OFF=X
        /// On: Job Exist
        ///Off: No Job Exist
        ///[1st Word ]
        ///00 ~ 15 bool : Job Existence Slot 1 ~ 16
        ///   00 bool: Job Existence Slot 1
        ///   01 bool: Job Existence Slot 2
        ///   ….
        ///   15 bool: Job Existence Slot 16
        ///[2nd Word]
        ///00 ~ 15 bool : Job Existence Slot 17 ~ 32
        ///[3rd Word]
        ///00 ~ 15 bool : Job Existence Slot 33 ~ 48
        ///[4th Word]
        ///00 ~ 15 bool : Job Existence Slot 49 ~ 64
        ///   ...
        ///[14th Word ]
        ///00 ~ 01 bool : Job Existence Slot 209 ~ 210
        /// </summary>
        public string JobExistenceSlot { get; set; }

        /// <summary> 
        /// 1: Actual Cassette
        ///2: Empty Cassette
        /// </summary>
        public Int16 LoadingCassetteType { get; set; }

        /// <summary> 
        /// 1: Emtpy,              //Empty
        ///2: ProcessEnd,         //Process End normal
        ///3: WaitProcess,        //Wait Process
        ///4: SkipProcess,        //Skip Process
        ///5: FailProcess,        //Process Fail
        ///6: Runing,             //Process Run
        /// </summary>
        public Int16 SlotStatusChanged { get; set; }

        /// <summary> 
        /// In/Out Slot Number
        /// </summary>
        public Int16 SlotStatusInOut { get; set; }

        /// <summary>
        /// STKINLINE
        /// AGV
        /// MGV
        /// </summary>
        public Int16 TransferMode { get; set; }

        /// <summary>
        /// port 사용 유무
        /// </summary>
        public Int16 PortEnable { get; set; }

        public CPortData PortDataConvert(string strUnitConvertMessage, CPortData cPortData, ushort[] MelsecNetReadGlassData)
        {
            CPortData portData = cPortData;
            
            //Melsec 35 Word Data

            //string glassID = null;
            //string glassSpecificData = null;

            if (strUnitConvertMessage == "portStatus")
            {
                portData.PortStatus = (enumPortStatus2)Enum.Parse(typeof(enumPortStatus2), MelsecNetReadGlassData[0] == 0 ? "6" : MelsecNetReadGlassData[0].ToString());
            }
            portData.CassetteStatus = Convert.ToInt32(MelsecNetReadGlassData[1]);
            portData.CassetteIndex = Convert.ToInt32(MelsecNetReadGlassData[2]);

            string portCstID = string.Empty;
            string portIDSum = null;
            for (int i = 3; i < 11; i++)
            {
                char _convertChar00 = Convert.ToChar(Convert.ToInt32(MelsecNetReadGlassData[i]) & 0xff);
                char _convertChar01 = Convert.ToChar(((Convert.ToInt32(MelsecNetReadGlassData[i]) & 0xff00)) >> 8);

                portIDSum = _convertChar01.ToString() + _convertChar00.ToString();

                portCstID += portIDSum;
            }

            string[] strCstID = portCstID.Split('\0');
            portData.CassetteID = strCstID[0].ToString();
            portData.JobCountinCassette = Convert.ToInt16(MelsecNetReadGlassData[11]);
            portData.CassetteCompletedReasonCode = Convert.ToInt16(MelsecNetReadGlassData[12]);

            ushort[] portJobSlot = new ushort[18];
            int count = 0;
            for (int j = 13; j < 31; j++)
            {
                portJobSlot[count] = MelsecNetReadGlassData[j];
                count++;
            }
            string jobExistenceSlotTemp = "";
            try
            {
                foreach (ushort item in portJobSlot)
                {
                    string charTemp = CDataConvert.HexToBitString(item.ToString("X"), 4);
                    jobExistenceSlotTemp += charTemp;
                }
                jobExistenceSlotTemp = jobExistenceSlotTemp.Replace('0', 'X');
                jobExistenceSlotTemp = jobExistenceSlotTemp.Replace('1', 'O');
                portData.JobExistenceSlot = jobExistenceSlotTemp;
                portData.LoadingCassetteType = Convert.ToInt16(MelsecNetReadGlassData[31]);
                portData.SlotStatusChanged = Convert.ToInt16(MelsecNetReadGlassData[32]);
                portData.SlotStatusInOut = Convert.ToInt16(MelsecNetReadGlassData[33]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\r\n" + ex.StackTrace);
            }

            return portData;
        }
    }

    public partial class CucPortDataPropertiesCollections : Dictionary<string, CPortData>
    {
    }
}
