using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartPLCSimulator
{
    public class CGlassData
    {
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
        public string CIMPCData { get; set; }
        public string ProcFlag { get; set; }
        public string JudgeFlag { get; set; }
        public string SkipFlag { get; set; }
        public string InspectionFlag { get; set; }
        public string Mode { get; set; }
        public string GlassType { get; set; }
        public string DummyType { get; set; }
        public string PanelGradeCode { get; set; }
        public string ArrayRepairRule { get; set; }
        public string ReservedData { get; set; }
        #endregion

        public CGlassData GlassDataConvert(ushort[] glassData)
        {
            try
            {
                if (glassData == null || glassData.Length <= 0)
                    return this;

                //LOT ID :TEXT,10 WORD
                this.LotID = GetStringIn(0, 10, glassData);
                //Glass ID :TEXT,10 WORD
                this.GlassID = GetStringIn(10, 10, glassData);
                //OPER ID :TEXT,10 WORD    (Process Step Name)
                this.OperID = GetStringIn(20, 10, glassData);
                //Glass Code
                this.GlassCodeXXYYYY = glassData[30];
                this.GlassCodeZZZ = glassData[31];
                //Glass Judge Code = Upper Space(20h), Lower Byte 1개만 즉 1자만 사용
                this.GlassJudgeCode = GetStringIn(32, 1, glassData);
                //PPID 숫자겠지?
                this.PPID = glassData[33];
                //PROD ID :TEXT,10 WORD
                this.ProdID = GetStringIn(34, 10, glassData);
                //Proc Flag
                this.ProcFlag = string.Format("{0} {1}", glassData[44], glassData[45]);
                //Judge Flag
                this.JudgeFlag = string.Format("{0} {1}", glassData[46], glassData[47]);
                //Skip Flag
                this.SkipFlag = string.Format("{0} {1}", glassData[48], glassData[49]);
                //Inspection Flag
                this.InspectionFlag = string.Format("{0} {1}", glassData[50], glassData[51]);
                //Mode
                this.Mode = string.Format("{0}", glassData[52]);
                //Glass Type
                this.GlassType = string.Format("{0} {1}", glassData[53], glassData[54]);
                //Dummy Type
                this.DummyType = string.Format("{0}", glassData[55]);
                //Reserved Data
                this.ReservedData = string.Format("{0} {1} {2} (3} {4} {5} {6} {7}", glassData[56], glassData[57], glassData[58], glassData[59], glassData[60], glassData[61], glassData[62], glassData[63]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

            return this;
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "";
            //string temp = "";

            //if (glassData == null || glassData.Length <= 0)
            //    return temp;

            //try
            //{
            //    for (int i = start; i < start + length; i++)
            //    {
            //        char _convertChar00 = Convert.ToChar(Convert.ToInt16(glassData[i]) & 0xff);
            //        char _convertChar01 = Convert.ToChar(((Convert.ToInt16(glassData[i]) & 0xff00)) >> 8);

            //        temp += (_convertChar00.ToString() + _convertChar01.ToString());
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //return temp;
        }

    }
}
