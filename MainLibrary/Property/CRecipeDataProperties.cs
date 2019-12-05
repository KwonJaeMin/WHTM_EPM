using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOFD.DataBase;
using System.Data.SqlClient;
using SOFD.Logger;
using SOFD.Component;

namespace MainLibrary.Property
{
    public class CRecipeDataProperties : CPersistenceObject
    {
        #region //member's
        public const string CLASS = "CRecipeDataProperties";

        #endregion

        #region //property's

        public string ParameterNo { get; set; }
        public string ParameterName { get; set; }
        public string ParamterFormat { get; set; }
        public string ParameterLength { get; set; }
        public string ParameterValue { get; set; }

        #endregion

        #region //constructor's

        public CRecipeDataProperties(string[] recipeData)
        {

            this.RecipeDataConvert(recipeData);
        }

        private string GetStringIn(int start, int length, ushort[] recipeData)
        {

            if (recipeData == null || recipeData.Length <= 0)
                throw new ArgumentNullException();

            if (start + length > recipeData.Length)
                throw new ArgumentException();


            try
            {
                string temp = "";
                ushort[] target = new ushort[length];
                Array.Copy(recipeData, start, target, 0, length);

                for (int i = 0; i < target.Length; i++)
                {
                    char _convertChar00 = Convert.ToChar(Convert.ToInt16(target[i]) & 0xff);
                    char _convertChar01 = Convert.ToChar(((Convert.ToInt16(target[i]) & 0xff00)) >> 8);

                    temp += (_convertChar00.ToString() + _convertChar01.ToString());
                }
                return temp;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "";
        }

        private void RecipeDataConvert(string[] recipeData)
        {
            try
            {
                if (recipeData == null || recipeData.Length <= 0)
                    return;

                this.ParameterNo = recipeData[0];
                this.ParameterName = recipeData[1];
                this.ParamterFormat = recipeData[2];
                this.ParameterLength = recipeData[3];
                this.ParameterValue = recipeData[4];
            }
            catch (Exception ex)
            {
                CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, CExceptionLogFormat.DEFAULT_KEY, ex));
            }
        }
        #endregion


        public static List<int> ConvertPLCDataList(List<CRecipeDataProperties> recipeData)
        {
            List<int> plcData = new List<int>();

            for (int i = 0; i < recipeData.Count; i++)
            {
                if (recipeData[i].ParamterFormat == "ASCII")
                {
                    plcData.AddRange(CovertStringToWordList(recipeData[i].ParameterValue, int.Parse(recipeData[i].ParameterLength)));
                }
                else if (recipeData[i].ParamterFormat == "INT")
                {
                    switch (recipeData[i].ParameterLength)
                    {
                        case "1":
                            plcData.Add(int.Parse(recipeData[i].ParameterValue));
                            break;
                        case "2":
                            plcData.Add((int)(int.Parse(recipeData[i].ParameterValue) & 0xFFFF));
                            plcData.Add((int)(int.Parse(recipeData[i].ParameterValue) >> 16));
                            break;
                    }
                }
            }

            return plcData;
        }


        public static List<int> ConvertPLCData(CRecipeDataProperties recipeData)
        {
            List<int> plcData = new List<int>();

            if (recipeData.ParamterFormat == "ASCII")
            {
                plcData.AddRange(CovertStringToWordList(recipeData.ParameterValue, int.Parse(recipeData.ParameterLength)));
            }
            else if (recipeData.ParamterFormat == "INT")
            {
                plcData.Add(int.Parse(recipeData.ParameterValue));
            }

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
                if (tempLotID.Length <= i) //20170117
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
                    plcData.Add(int.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.StringToHex(word[0] + word[1])))); //201701/17
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
                    plcData.Add(ushort.Parse(SmartDevice.UTILS.PLCUtils.HexToDec(SmartDevice.UTILS.PLCUtils.StringToReverseHex(word[0] + word[1]))));
                    word.Clear();
                }
            }

            return plcData;
        }

    }

}

