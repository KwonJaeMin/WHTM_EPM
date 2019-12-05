using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using OMRON.Compolet.CIP;

namespace YANGSYS.Simulator.WHTM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitiallzeDataL2();
            InitiallzeDataL3();
 
        }

        private void InitiallzeDataL2()
        {
            dgvOutJobData1_L2.Rows.Clear();
            dgvOutJobData1_L2.Rows[dgvOutJobData1_L2.Rows.Add("CassetteIndex", "1255")].Cells["colValue"].ValueType = typeof(int);//((int)0x02FF).ToString())
            dgvOutJobData1_L2.Rows[dgvOutJobData1_L2.Rows.Add("GlassIndex", "1001")].Cells["colValue"].ValueType = typeof(int);
            dgvOutJobData1_L2.Rows[dgvOutJobData1_L2.Rows.Add("ProductCode", "1")].Cells["colValue"].ValueType = typeof(int);
            dgvOutJobData1_L2.Rows[dgvOutJobData1_L2.Rows.Add("GlassThickness", "1")].Cells["colValue"].ValueType = typeof(int);
            dgvOutJobData1_L2.Rows[dgvOutJobData1_L2.Rows.Add("LotID", "ABCD")].Cells["colValue"].ValueType = typeof(string);
            dgvOutJobData1_L2.Rows[dgvOutJobData1_L2.Rows.Add("GlassID", "ABCDE")].Cells["colValue"].ValueType = typeof(string);
            dgvOutJobData1_L2.Rows[dgvOutJobData1_L2.Rows.Add("PPID", "ABCDEF")].Cells["colValue"].ValueType = typeof(string);
            dgvOutJobData1_L2.Rows[dgvOutJobData1_L2.Rows.Add("GlassType", "1")].Cells["colValue"].ValueType = typeof(int);
            dgvOutJobData1_L2.Rows[dgvOutJobData1_L2.Rows.Add("JobJudge", "AB")].Cells["colValue"].ValueType = typeof(string);
            dgvOutJobData1_L2.Rows[dgvOutJobData1_L2.Rows.Add("JobGrade", "CD")].Cells["colValue"].ValueType = typeof(string);
            dgvOutJobData1_L2.Rows[dgvOutJobData1_L2.Rows.Add("JobState", "EF")].Cells["colValue"].ValueType = typeof(string);
            dgvOutJobData1_L2.Rows[dgvOutJobData1_L2.Rows.Add("TrackingData", "111111111111")].Cells["colValue"].ValueType = typeof(ulong);
            dgvOutJobData1_L2.Rows[dgvOutJobData1_L2.Rows.Add("UnitPathNo", "1")].Cells["colValue"].ValueType = typeof(int);
            dgvOutJobData1_L2.Rows[dgvOutJobData1_L2.Rows.Add("SlotNo", "0")].Cells["colValue"].ValueType = typeof(int);
            dgvOutJobData1_L2.Rows[dgvOutJobData1_L2.Rows.Add("CycleTime", float.MaxValue.ToString())].Cells["colValue"].ValueType = typeof(float);
            dgvOutJobData1_L2.Rows[dgvOutJobData1_L2.Rows.Add("TactTime", float.MinValue.ToString())].Cells["colValue"].ValueType = typeof(float);
            dgvOutJobData1_L2.Rows[dgvOutJobData1_L2.Rows.Add("ReasonCode", "32767")].Cells["colValue"].ValueType = typeof(int);
            dgvOutJobData1_L2.Rows[dgvOutJobData1_L2.Rows.Add("SamplingFlag", "65535")].Cells["colValue"].ValueType = typeof(ushort);
            dgvOutJobData1_L2.Rows[dgvOutJobData1_L2.Rows.Add("LotEndFlag", "32767")].Cells["colValue"].ValueType = typeof(int);
            dgvOutJobData1_L2.Rows[dgvOutJobData1_L2.Rows.Add("OperationId", "ABCDEFG")].Cells["colValue"].ValueType = typeof(string);
            dgvOutJobData1_L2.Rows[dgvOutJobData1_L2.Rows.Add("ProductId", "ABCDEFGH")].Cells["colValue"].ValueType = typeof(string);
            dgvOutJobData1_L2.Rows[dgvOutJobData1_L2.Rows.Add("CassetteId", "ABCDEFGHI")].Cells["colValue"].ValueType = typeof(string);
            dgvOutJobData1_L2.Rows[dgvOutJobData1_L2.Rows.Add("Reserved1", "ABCDEFGHIJ")].Cells["colValue"].ValueType = typeof(string);

            dgvOutJobData2_L2.Rows.Clear();
            dgvOutJobData1_L2.Rows[dgvOutJobData2_L2.Rows.Add("CassetteIndex", "1255")].Cells["colValue"].ValueType = typeof(int);//((int)0x02FF).ToString())
            dgvOutJobData1_L2.Rows[dgvOutJobData2_L2.Rows.Add("GlassIndex", "2001")].Cells["colValue"].ValueType = typeof(int);
            dgvOutJobData1_L2.Rows[dgvOutJobData2_L2.Rows.Add("ProductCode", "1")].Cells["colValue"].ValueType = typeof(int);
            dgvOutJobData1_L2.Rows[dgvOutJobData2_L2.Rows.Add("GlassThickness", "1")].Cells["colValue"].ValueType = typeof(int);
            dgvOutJobData1_L2.Rows[dgvOutJobData2_L2.Rows.Add("LotID", "ABCDC")].Cells["colValue"].ValueType = typeof(string);
            dgvOutJobData1_L2.Rows[dgvOutJobData2_L2.Rows.Add("GlassID", "ABCDEC")].Cells["colValue"].ValueType = typeof(string);
            dgvOutJobData1_L2.Rows[dgvOutJobData2_L2.Rows.Add("PPID", "ABCDEFC")].Cells["colValue"].ValueType = typeof(string);
            dgvOutJobData1_L2.Rows[dgvOutJobData2_L2.Rows.Add("GlassType", "1")].Cells["colValue"].ValueType = typeof(int);
            dgvOutJobData1_L2.Rows[dgvOutJobData2_L2.Rows.Add("JobJudge", "AB")].Cells["colValue"].ValueType = typeof(string);
            dgvOutJobData1_L2.Rows[dgvOutJobData2_L2.Rows.Add("JobGrade", "CD")].Cells["colValue"].ValueType = typeof(string);
            dgvOutJobData1_L2.Rows[dgvOutJobData2_L2.Rows.Add("JobState", "EF")].Cells["colValue"].ValueType = typeof(string);
            dgvOutJobData1_L2.Rows[dgvOutJobData2_L2.Rows.Add("TrackingData", "111111111111")].Cells["colValue"].ValueType = typeof(ulong);
            dgvOutJobData1_L2.Rows[dgvOutJobData2_L2.Rows.Add("UnitPathNo", "1")].Cells["colValue"].ValueType = typeof(int);
            dgvOutJobData1_L2.Rows[dgvOutJobData2_L2.Rows.Add("SlotNo", "0")].Cells["colValue"].ValueType = typeof(int);
            dgvOutJobData1_L2.Rows[dgvOutJobData2_L2.Rows.Add("CycleTime", float.MaxValue.ToString())].Cells["colValue"].ValueType = typeof(float);
            dgvOutJobData1_L2.Rows[dgvOutJobData2_L2.Rows.Add("TactTime", float.MinValue.ToString())].Cells["colValue"].ValueType = typeof(float);
            dgvOutJobData1_L2.Rows[dgvOutJobData2_L2.Rows.Add("ReasonCode", "32767")].Cells["colValue"].ValueType = typeof(int);
            dgvOutJobData1_L2.Rows[dgvOutJobData2_L2.Rows.Add("SamplingFlag", "65535")].Cells["colValue"].ValueType = typeof(ushort);
            dgvOutJobData1_L2.Rows[dgvOutJobData2_L2.Rows.Add("LotEndFlag", "32767")].Cells["colValue"].ValueType = typeof(int);
            dgvOutJobData1_L2.Rows[dgvOutJobData2_L2.Rows.Add("OperationId", "ABCDEFGC")].Cells["colValue"].ValueType = typeof(string);
            dgvOutJobData1_L2.Rows[dgvOutJobData2_L2.Rows.Add("ProductId", "ABCDEFGHC")].Cells["colValue"].ValueType = typeof(string);
            dgvOutJobData1_L2.Rows[dgvOutJobData2_L2.Rows.Add("CassetteId", "ABCDEFGHIC")].Cells["colValue"].ValueType = typeof(string);
            dgvOutJobData1_L2.Rows[dgvOutJobData2_L2.Rows.Add("Reserved1", "ABCDEFGHIJC")].Cells["colValue"].ValueType = typeof(string);

            dgvInJobData1_L2.Rows.Clear();
            dgvOutJobData1_L2.Rows[dgvInJobData1_L2.Rows.Add("UnitPathNo", "1")].Cells["colValue"].ValueType = typeof(int);
            dgvOutJobData1_L2.Rows[dgvInJobData1_L2.Rows.Add("SlotNo", "0")].Cells["colValue"].ValueType = typeof(int);
            dgvInJobData2_L2.Rows.Clear();
            dgvOutJobData1_L2.Rows[dgvInJobData2_L2.Rows.Add("UnitPathNo", "1")].Cells["colValue"].ValueType = typeof(int);
            dgvOutJobData1_L2.Rows[dgvInJobData2_L2.Rows.Add("SlotNo", "0")].Cells["colValue"].ValueType = typeof(int);
        }

        private void InitiallzeDataL3()
        {
            dgvOutJobData1_L3.Rows.Clear();
            dgvOutJobData1_L2.Rows[dgvOutJobData1_L3.Rows.Add("CassetteIndex", "0")].Cells["colValue"].ValueType = typeof(int);
            dgvOutJobData1_L2.Rows[dgvOutJobData1_L3.Rows.Add("GlassIndex", "0")].Cells["colValue"].ValueType = typeof(int);
            dgvOutJobData1_L2.Rows[dgvOutJobData1_L3.Rows.Add("ProductCode", "0")].Cells["colValue"].ValueType = typeof(int);
            dgvOutJobData1_L2.Rows[dgvOutJobData1_L3.Rows.Add("GlassThickness", "0")].Cells["colValue"].ValueType = typeof(int);
            dgvOutJobData1_L2.Rows[dgvOutJobData1_L3.Rows.Add("LotID", "")].Cells["colValue"].ValueType = typeof(string);
            dgvOutJobData1_L2.Rows[dgvOutJobData1_L3.Rows.Add("GlassID", "")].Cells["colValue"].ValueType = typeof(string);
            dgvOutJobData1_L2.Rows[dgvOutJobData1_L3.Rows.Add("PPID", "")].Cells["colValue"].ValueType = typeof(string);
            dgvOutJobData1_L2.Rows[dgvOutJobData1_L3.Rows.Add("GlassType", "0")].Cells["colValue"].ValueType = typeof(int);
            dgvOutJobData1_L2.Rows[dgvOutJobData1_L3.Rows.Add("JobJudge", "")].Cells["colValue"].ValueType = typeof(string);
            dgvOutJobData1_L2.Rows[dgvOutJobData1_L3.Rows.Add("JobGrade", "")].Cells["colValue"].ValueType = typeof(string);
            dgvOutJobData1_L2.Rows[dgvOutJobData1_L3.Rows.Add("JobState", "")].Cells["colValue"].ValueType = typeof(string);
            dgvOutJobData1_L2.Rows[dgvOutJobData1_L3.Rows.Add("TrackingData", "")].Cells["colValue"].ValueType = typeof(ulong);
            dgvOutJobData1_L2.Rows[dgvOutJobData1_L3.Rows.Add("UnitPathNo", "")].Cells["colValue"].ValueType = typeof(int);
            dgvOutJobData1_L2.Rows[dgvOutJobData1_L3.Rows.Add("SlotNo", "0")].Cells["colValue"].ValueType = typeof(int);
            dgvOutJobData1_L2.Rows[dgvOutJobData1_L3.Rows.Add("CycleTime", "")].Cells["colValue"].ValueType = typeof(float);
            dgvOutJobData1_L2.Rows[dgvOutJobData1_L3.Rows.Add("TactTime", "")].Cells["colValue"].ValueType = typeof(float);
            dgvOutJobData1_L2.Rows[dgvOutJobData1_L3.Rows.Add("ReasonCode", "0")].Cells["colValue"].ValueType = typeof(int);
            dgvOutJobData1_L2.Rows[dgvOutJobData1_L3.Rows.Add("SamplingFlag", "0")].Cells["colValue"].ValueType = typeof(ushort);
            dgvOutJobData1_L2.Rows[dgvOutJobData1_L3.Rows.Add("LotEndFlag", "0")].Cells["colValue"].ValueType = typeof(int);
            dgvOutJobData1_L2.Rows[dgvOutJobData1_L3.Rows.Add("OperationId", "")].Cells["colValue"].ValueType = typeof(string);
            dgvOutJobData1_L2.Rows[dgvOutJobData1_L3.Rows.Add("ProductId", "")].Cells["colValue"].ValueType = typeof(string);
            dgvOutJobData1_L2.Rows[dgvOutJobData1_L3.Rows.Add("CassetteId", "")].Cells["colValue"].ValueType = typeof(string);
            dgvOutJobData1_L2.Rows[dgvOutJobData1_L3.Rows.Add("Reserved1", "")].Cells["colValue"].ValueType = typeof(string);

            dgvOutJobData2_L3.Rows.Clear();
            dgvOutJobData1_L2.Rows[dgvOutJobData2_L3.Rows.Add("CassetteIndex", "0")].Cells["colValue"].ValueType = typeof(int);
            dgvOutJobData1_L2.Rows[dgvOutJobData2_L3.Rows.Add("GlassIndex", "0")].Cells["colValue"].ValueType = typeof(int);
            dgvOutJobData1_L2.Rows[dgvOutJobData2_L3.Rows.Add("ProductCode", "0")].Cells["colValue"].ValueType = typeof(int);
            dgvOutJobData1_L2.Rows[dgvOutJobData2_L3.Rows.Add("GlassThickness", "0")].Cells["colValue"].ValueType = typeof(int);
            dgvOutJobData1_L2.Rows[dgvOutJobData2_L3.Rows.Add("LotID", "")].Cells["colValue"].ValueType = typeof(string);
            dgvOutJobData1_L2.Rows[dgvOutJobData2_L3.Rows.Add("GlassID", "")].Cells["colValue"].ValueType = typeof(string);
            dgvOutJobData1_L2.Rows[dgvOutJobData2_L3.Rows.Add("PPID", "")].Cells["colValue"].ValueType = typeof(string);
            dgvOutJobData1_L2.Rows[dgvOutJobData2_L3.Rows.Add("GlassType", "0")].Cells["colValue"].ValueType = typeof(int);
            dgvOutJobData1_L2.Rows[dgvOutJobData2_L3.Rows.Add("JobJudge", "")].Cells["colValue"].ValueType = typeof(string);
            dgvOutJobData1_L2.Rows[dgvOutJobData2_L3.Rows.Add("JobGrade", "")].Cells["colValue"].ValueType = typeof(string);
            dgvOutJobData1_L2.Rows[dgvOutJobData2_L3.Rows.Add("JobState", "")].Cells["colValue"].ValueType = typeof(string);
            dgvOutJobData1_L2.Rows[dgvOutJobData2_L3.Rows.Add("TrackingData", "0")].Cells["colValue"].ValueType = typeof(ulong);
            dgvOutJobData1_L2.Rows[dgvOutJobData2_L3.Rows.Add("UnitPathNo", "0")].Cells["colValue"].ValueType = typeof(int);
            dgvOutJobData1_L2.Rows[dgvOutJobData2_L3.Rows.Add("SlotNo", "0")].Cells["colValue"].ValueType = typeof(int);
            dgvOutJobData1_L2.Rows[dgvOutJobData2_L3.Rows.Add("CycleTime", "0.0")].Cells["colValue"].ValueType = typeof(float);
            dgvOutJobData1_L2.Rows[dgvOutJobData2_L3.Rows.Add("TactTime", "0.0")].Cells["colValue"].ValueType = typeof(float);
            dgvOutJobData1_L2.Rows[dgvOutJobData2_L3.Rows.Add("ReasonCode", "0")].Cells["colValue"].ValueType = typeof(int);
            dgvOutJobData1_L2.Rows[dgvOutJobData2_L3.Rows.Add("SamplingFlag", "0")].Cells["colValue"].ValueType = typeof(ushort);
            dgvOutJobData1_L2.Rows[dgvOutJobData2_L3.Rows.Add("LotEndFlag", "0")].Cells["colValue"].ValueType = typeof(int);
            dgvOutJobData1_L2.Rows[dgvOutJobData2_L3.Rows.Add("OperationId", "")].Cells["colValue"].ValueType = typeof(string);
            dgvOutJobData1_L2.Rows[dgvOutJobData2_L3.Rows.Add("ProductId", "")].Cells["colValue"].ValueType = typeof(string);
            dgvOutJobData1_L2.Rows[dgvOutJobData2_L3.Rows.Add("CassetteId", "")].Cells["colValue"].ValueType = typeof(string);
            dgvOutJobData1_L2.Rows[dgvOutJobData2_L3.Rows.Add("Reserved1", "")].Cells["colValue"].ValueType = typeof(string);

            dgvInJobData1_L3.Rows.Clear();
            dgvOutJobData1_L2.Rows[dgvInJobData1_L3.Rows.Add("UnitPathNo", "0")].Cells["colValue"].ValueType = typeof(int);
            dgvOutJobData1_L2.Rows[dgvInJobData1_L3.Rows.Add("SlotNo", "0")].Cells["colValue"].ValueType = typeof(int);

            dgvInJobData2_L3.Rows.Clear();
            dgvOutJobData1_L2.Rows[dgvInJobData2_L3.Rows.Add("UnitPathNo", "0")].Cells["colValue"].ValueType = typeof(int);
            dgvOutJobData1_L2.Rows[dgvInJobData2_L3.Rows.Add("SlotNo", "0")].Cells["colValue"].ValueType = typeof(int);
        }

        private bool _unload = false ;
        private bool _load = false;
        private bool _exchange = false;

        private byte[] GetBytes<T>(object value, int wordLength)
        {
            List<byte> bytes = new List<byte>();

            if (typeof(T) == typeof(int))
            {
                int temp = (int)Convert.ChangeType(value, typeof(int));
                bytes.Add((byte)(temp & 0xFF));
                bytes.Add((byte)(temp >> 8 & 0xFF));
            }
            else if (typeof(T) == typeof(string))
            {
                string temp = (string)Convert.ChangeType(value, typeof(string));

                int letterCount = wordLength * 2;
                temp = temp.PadRight(letterCount, ' ');
                if (temp.Length > letterCount)
                {
                    temp = temp.Substring(0, letterCount);

                }
                char[] charArray = temp.ToCharArray();
                //char buffer;

                //for (int i = 0; i < letterCount; i++)
                //{
                //    buffer = charArray[i];
                //    charArray[i] = charArray[i + 1];
                //    charArray[i + 1] = buffer;
                //    i++;
                //}
                return Encoding.ASCII.GetBytes(charArray);
            }
            else if (typeof(T) == typeof(uint))
            {
                uint temp = (uint)Convert.ChangeType(value, typeof(uint));
                bytes.Add((byte)(temp & 0xFF));
                bytes.Add((byte)(temp >> 8 & 0xFF));
                bytes.Add((byte)(temp >> 16 & 0xFF));
                bytes.Add((byte)(temp >> 24));
            }
            else if (typeof(T) == typeof(ulong))
            {
                ulong temp = (ulong)Convert.ChangeType(value, typeof(ulong));

                bytes.Add((byte)(temp & 0xFF));
                bytes.Add((byte)(temp >> 8 & 0xFF));
                bytes.Add((byte)(temp >> 16 & 0xFF));
                bytes.Add((byte)(temp >> 24 & 0xFF));
                bytes.Add((byte)(temp >> 32 & 0xFF));
                bytes.Add((byte)(temp >> 40 & 0xFF));
                bytes.Add((byte)(temp >> 48 & 0xFF));
                bytes.Add((byte)(temp >> 56 & 0xFF));
            }
            else if (typeof(T) == typeof(ushort))
            {
                ushort temp = (ushort)Convert.ChangeType(value, typeof(ushort));
                bytes.Add((byte)(temp & 0xFF));
                bytes.Add((byte)(temp >> 8 & 0xFF));
            }
            else
            {
                throw new ArgumentException("형식을 추가해야합니다.");
            }
            return bytes.ToArray();
        }

        private byte[] GetOutJobData(DataGridView dgv)
        {
            List<byte> data = new List<byte>();
            data.AddRange(GetBytes<int>(dgv.Rows[0].Cells[1].Value, 1));   //dgv.Rows.Add("CassetteIndex", "0");
            data.AddRange(GetBytes<int>(dgv.Rows[1].Cells[1].Value, 1));   //dgv.Rows.Add("GlassIndex", "0");
            data.AddRange(GetBytes<int>(dgv.Rows[2].Cells[1].Value, 1));   //dgv.Rows.Add("ProductCode", "0");
            data.AddRange(GetBytes<int>(dgv.Rows[3].Cells[1].Value, 1));   //dgv.Rows.Add("GlassThickness", "0");
            data.AddRange(GetBytes<string>(dgv.Rows[4].Cells[1].Value, 10));   //dgv.Rows.Add("LotID", "");
            data.AddRange(GetBytes<string>(dgv.Rows[5].Cells[1].Value, 10));   //dgv.Rows.Add("GlassID", "");
            data.AddRange(GetBytes<string>(dgv.Rows[6].Cells[1].Value, 10));   //dgv.Rows.Add("PPID", "");
            data.AddRange(GetBytes<int>(dgv.Rows[7].Cells[1].Value, 1));   //dgv.Rows.Add("GlassType", "0");
            data.AddRange(GetBytes<string>(dgv.Rows[8].Cells[1].Value, 1));   //dgv.Rows.Add("JobJudge", "");
            data.AddRange(GetBytes<string>(dgv.Rows[9].Cells[1].Value, 1));   //dgv.Rows.Add("JobGrade", "");
            data.AddRange(GetBytes<string>(dgv.Rows[10].Cells[1].Value, 1));   //dgv.Rows.Add("JobState", "");
            data.AddRange(GetBytes<ulong>(dgv.Rows[11].Cells[1].Value, 1));   //dgv.Rows.Add("TrackingData", "");
            data.AddRange(GetBytes<int>(dgv.Rows[12].Cells[1].Value, 1));   //dgv.Rows.Add("UnitPathNo", "");
            data.AddRange(GetBytes<int>(dgv.Rows[13].Cells[1].Value, 1));   //dgv.Rows.Add("SlotNo", "0");
            float a, b;
            if(float.TryParse(dgv.Rows[14].Cells[1].Value.ToString(), out a))
                data.AddRange(DataConverter.SinglesToDwords(new float[] { a })); //GetBytes<uint>(dgv.Rows[14].Cells[1].Value, 2));   //dgv.Rows.Add("CycleTime", "");
            if (float.TryParse(dgv.Rows[15].Cells[1].Value.ToString(), out b))
                data.AddRange(DataConverter.SinglesToDwords(new float[] { b }));//GetBytes<uint>(dgv.Rows[15].Cells[1].Value, 2));   //dgv.Rows.Add("TactTime", "");

            data.AddRange(GetBytes<int>(dgv.Rows[16].Cells[1].Value, 1));   //dgv.Rows.Add("ReasonCode", "0");
            data.AddRange(GetBytes<ushort>(dgv.Rows[17].Cells[1].Value, 1));   //dgv.Rows.Add("SamplingFlag", "0");
            data.AddRange(GetBytes<int>(dgv.Rows[18].Cells[1].Value, 1));    //dgv.Rows.Add("LotEndFlag", "0");
            data.AddRange(GetBytes<string>(dgv.Rows[19].Cells[1].Value, 5));    //dgv.Rows.Add("OperationId", "");
            data.AddRange(GetBytes<string>(dgv.Rows[20].Cells[1].Value, 10));   //dgv.Rows.Add("ProductId", "");
            data.AddRange(GetBytes<string>(dgv.Rows[21].Cells[1].Value, 5));   //dgv.Rows.Add("CassetteId", "");
            data.AddRange(GetBytes<string>(dgv.Rows[22].Cells[1].Value, 25));   //dgv.Rows.Add("Reserved1", "");       
            
            return data.ToArray();
        }

        private void SetOutJobData(byte[] data, DataGridView dgv)
        {
            dgv.Rows[0].Cells[1].Value = (int)data[1] >> 8 | data[0];
            dgv.Rows[1].Cells[1].Value = (int)data[3] >> 8 | data[2];
            dgv.Rows[2].Cells[1].Value = (int)data[5] >> 8 | data[4];
            dgv.Rows[3].Cells[1].Value = (int)data[7] >> 8 | data[6];
            dgv.Rows[4].Cells[1].Value = GetString(data, 8, 10);
            dgv.Rows[5].Cells[1].Value = GetString(data, 20, 10);
            dgv.Rows[6].Cells[1].Value = GetString(data, 32, 10);
            dgv.Rows[7].Cells[1].Value = (int)data[45] >> 8 | data[44];
            dgv.Rows[8].Cells[1].Value = (int)data[47] >> 8 | data[46];
            dgv.Rows[9].Cells[1].Value = (int)data[49] >> 8 | data[48];
            dgv.Rows[10].Cells[1].Value = (int)data[51] >> 8 | data[50];
            dgv.Rows[11].Cells[1].Value = (ulong)data[59] >> 56 | (ulong)data[58] >> 48 | (ulong)data[57] >> 40 | (ulong)data[56] >> 32 | (ulong)data[55] >> 24 | (ulong)data[54] >> 16 | (ulong)data[53] >> 8 | (ulong)data[52];//trac d
            dgv.Rows[12].Cells[1].Value = (int)data[61] >> 8 | data[60];
            dgv.Rows[13].Cells[1].Value = (int)data[63] >> 8 | data[62];
            dgv.Rows[14].Cells[1].Value = DataConverter.DwordsToSingles(new byte[] { data[64], data[65], data[66], data[67] }); //(uint)data[67] >> 8 | (uint)data[66] | (uint)data[65] >> 8 | (uint)data[64];//2
            dgv.Rows[15].Cells[1].Value = DataConverter.DwordsToSingles(new byte[] { data[68], data[69], data[70], data[71] });//(uint)data[71] >> 8 | (uint)data[70] | (uint)data[69] >> 8 | (uint)data[68];//2
            dgv.Rows[16].Cells[1].Value = (int)data[73] >> 8 | data[72];
            dgv.Rows[17].Cells[1].Value = (int)data[75] >> 8 | data[74];
            dgv.Rows[18].Cells[1].Value = (int)data[77] >> 8 | data[76];
            dgv.Rows[19].Cells[1].Value = GetString(data, 78, 5);
            dgv.Rows[20].Cells[1].Value = GetString(data, 85, 10);
            dgv.Rows[21].Cells[1].Value = GetString(data, 97, 5);
            dgv.Rows[22].Cells[1].Value = GetString(data, 104, 25);
        }

        private string GetString(byte[] data, int start, int wordLength)
        {
            int maxLength = wordLength * 2;
            byte[] temp = new byte[maxLength];
            for (int i = 0; i < maxLength; i++)
            {
                temp[i] = data[i + start];
            }

            return Encoding.ASCII.GetString(temp);
        }

        private byte[] GetInJobData(DataGridView dgv)
        {
            List<byte> data = new List<byte>();
            data.AddRange(GetBytes<int>(dgv.Rows[0].Cells[1].Value, 1));   //dgvInJobData2_L3.Rows.Add("UnitPathNo", "0");
            data.AddRange(GetBytes<int>(dgv.Rows[1].Cells[1].Value, 1));   //dgvInJobData2_L3.Rows.Add("SlotNo", "0");
            return data.ToArray();
        }

        private void SetInJobData(byte[] data, DataGridView dgv)
        {
            dgv.Rows[0].Cells[1].Value = data[1] >> 8 | data[0];   //dgvInJobData2_L3.Rows.Add("UnitPathNo", "0");
            dgv.Rows[1].Cells[1].Value = data[3] >> 8 | data[2];   //dgvInJobData2_L3.Rows.Add("SlotNo", "0");
        }

        private void btnUnload_Click(object sender, EventArgs e)
        {
            _exchange = false;
            _load = false;
            _unload = false;

            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.UpstreamTransOutJobData1", GetOutJobData(dgvOutJobData1_L2));
            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.UpstreamTransOutJobData2", GetOutJobData(dgvOutJobData2_L2));
            //object value2 = cJ2Compolet1.ReadVariable("RV_B_LinkSignalPath1_L2.DownstreamTransInJobData1");
            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.DownstreamTransInJobData1", GetInJobData(dgvInJobData1_L2));
            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.DownstreamTransInJobData2", GetInJobData(dgvInJobData2_L2));
            _unload = true;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            _exchange = false;
            _load = false;
            _unload = false;

            _load = true;
        }

        private void btnExchange_Click(object sender, EventArgs e)
        {
            _exchange = false;
            _load = false;
            _unload = false;

            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.UpstreamTransOutJobData1", GetOutJobData(dgvOutJobData1_L2));
            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.UpstreamTransOutJobData2", GetOutJobData(dgvOutJobData2_L2));
            //object value2 = cJ2Compolet1.ReadVariable("RV_B_LinkSignalPath1_L2.DownstreamTransInJobData1");
            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.DownstreamTransInJobData1", GetInJobData(dgvInJobData1_L2));
            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.DownstreamTransInJobData2", GetInJobData(dgvInJobData2_L2));

            _exchange = true;

        }


        private delegate void SetTextHandler(Control control, string text);
        private delegate void SetColorHandler(Control control, Color color);

        private delegate void EngineStartHandler();
        private void chkActive_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkActive.Checked)
                {
                    cJ2Compolet1.ConnectionType = OMRON.Compolet.CIP.ConnectionType.UCMM;
                    cJ2Compolet1.PeerAddress = textBox1.Text.Trim();
                    cJ2Compolet1.Active = true;

                    comboBox1.Items.Clear();
                    comboBox1.Items.AddRange(cJ2Compolet1.VariableNames);
                }
            }
            catch (Exception ex)
            {
                chkActive.Checked = false;
            }
        }

        private void SetText(Control control, string text)
        {
            if (control.InvokeRequired)
            {
                SetTextHandler handler = new SetTextHandler(SetText);
                control.Invoke(handler, control, text);
            }
            else
                control.Text = text;
        }

        private void SetColor(Control control, Color color)
        {
            if (control.InvokeRequired)
            {
                SetColorHandler handler = new SetColorHandler(SetColor);
                control.Invoke(handler, control, color);
            }
            else
                control.BackColor = color;
        }

        private void chkIndexerInline_Click(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            if (chk == null)
                return;

            cJ2Compolet1.WriteVariable(chk.Tag.ToString(), !chk.Checked);
        }
        private bool _engineStop = true;

        private bool _sendAble = false;
        private bool _sendStart = false;
        private bool _sendComplete = true;

        private bool _receiveAble = false;
        private bool _receiveStart = false;
        private bool _receiveComplete = true;

        private void Unload()
        {
            _engineStop = true; //기존 호출 종료를 기대함.
            Thread.Sleep(1000);
            _engineStop = false;
            Console.WriteLine("RUN THREAD START [" + Thread.CurrentThread.ManagedThreadId.ToString() + "]");

            _sendAble = false;
            _sendStart = false;
            _sendComplete = false;

            _receiveAble = false;
            _receiveStart = false;
            _receiveComplete = false;
            bool _exchangePossible = false;
            while (!_engineStop)
            {
                try
                {
                    if (_unload)
                    {
                        if (!(bool)cJ2Compolet1.ReadVariable("RV_B_LinkSignalPath1_L3.Downstream.DownstreamInline"))
                        {
                            Thread.Sleep(100);
                            continue;
                        }

                        if ((bool)cJ2Compolet1.ReadVariable("RV_B_LinkSignalPath1_L3.Downstream.DownstreamTrouble"))
                        {
                            Thread.Sleep(100);
                            continue;
                        }

                        if (!_sendAble && _unload && (bool)cJ2Compolet1.ReadVariable("RV_B_LinkSignalPath1_L3.Downstream.ReceiveAble"))
                        {
                            //button 눌렀을때 데이터를 썼을 터임.
                            _sendAble = true;
                            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Upstream.SendAble", true);
                        }
                        else if (!_sendComplete && !_sendStart && _sendAble && (bool)cJ2Compolet1.ReadVariable("RV_B_LinkSignalPath1_L3.Downstream.ReceiveStart"))
                        {
                            _sendStart = true;
                            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Upstream.SendStart", true);
                            Thread.Sleep(1000);
                            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Upstream.HandInterference", false);

                            int count = 0;
                            while (count++ < 25)
                            {
                                if (_engineStop)
                                {
                                    return;
                                }
                                Thread.Sleep(100);//넣고
                            }

                            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Upstream.JobTransferredSignal", true);

                            count = 0;
                            while (count++ < 25)
                            {
                                if (_engineStop)
                                {
                                    return;
                                }
                                Thread.Sleep(100);//빼고
                            }

                            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Upstream.HandInterference", true);
                            Thread.Sleep(1000);
                            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Upstream.SendComplete", true);

                            _sendComplete = true;
                        }
                        else if (_sendComplete && (bool)cJ2Compolet1.ReadVariable("RV_B_LinkSignalPath1_L3.Downstream.ReceiveComplete"))
                        {
                            Thread.Sleep(1000);
                            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Upstream.SendAble", false);
                            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Upstream.SendStart", false);
                            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Upstream.SendComplete", false);
                            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Upstream.JobTransferredSignal", false);

                            _unload = false;
                            _sendAble = false;
                            _sendStart = false;
                            _sendComplete = false;
                        }
                    }
                    else if (_load)
                    {
                        if (!(bool)cJ2Compolet1.ReadVariable("RV_B_LinkSignalPath1_L3.Upstream.UpstreamInline"))
                        {
                            Thread.Sleep(100);
                            continue;
                        }

                        if ((bool)cJ2Compolet1.ReadVariable("RV_B_LinkSignalPath1_L3.Upstream.UpstreamTrouble"))
                        {
                            Thread.Sleep(100);
                            continue;
                        }

                        if (!_receiveAble && _load && (bool)cJ2Compolet1.ReadVariable("RV_B_LinkSignalPath1_L3.Upstream.SendAble"))
                        {

                            byte[] outJobData1 = (byte[])cJ2Compolet1.ReadVariable("RV_B_LinkSignalPath1_L3.UpstreamTransOutJobData1");//, GetOutJobData(dgvOutJobData1_L2));
                            byte[] outJobData2 = (byte[])cJ2Compolet1.ReadVariable("RV_B_LinkSignalPath1_L3.UpstreamTransOutJobData2");//, GetOutJobData(dgvOutJobData2_L2));
                            //object value2 = cJ2Compolet1.ReadVariable("RV_B_LinkSignalPath1_L2.DownstreamTransInJobData1");
                            byte[] outInJobData1 = (byte[])cJ2Compolet1.ReadVariable("RV_B_LinkSignalPath1_L3.DownstreamTransInJobData1");//, GetInJobData(dgvInJobData1_L2));
                            byte[] outInJobData2 = (byte[])cJ2Compolet1.ReadVariable("RV_B_LinkSignalPath1_L3.DownstreamTransInJobData2");//, GetInJobData(dgvInJobData2_L2));
                            SetOutJobData(outJobData1, dgvOutJobData1_L3);
                            SetOutJobData(outJobData2, dgvOutJobData2_L3);
                            SetInJobData(outInJobData1, dgvInJobData1_L3);
                            SetInJobData(outInJobData2, dgvInJobData2_L3);
                            _receiveAble = true;
                            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Downstream.ReceiveAble", true);
                        }
                        else if (!_receiveComplete && !_receiveStart && _receiveAble && (bool)cJ2Compolet1.ReadVariable("RV_B_LinkSignalPath1_L3.Upstream.SendStart"))
                        {
                            _receiveStart = true;
                            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Downstream.ReceiveStart", true);
                            Thread.Sleep(1000);
                            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Downstream.HandInterference", false);

                            int count = 0;
                            while (count++ < 25)
                            {
                                if (_engineStop)
                                {
                                    return;
                                }
                                Thread.Sleep(100);//넣고
                            }

                            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Downstream.JobTransferredSignal", true);

                            count = 0;
                            while (count++ < 25)
                            {
                                if (_engineStop)
                                {
                                    return;
                                }
                                Thread.Sleep(100);//빼고
                            }

                            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Downstream.HandInterference", true);
                            Thread.Sleep(1000);
                            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Downstream.ReceiveComplete", true);

                            _receiveComplete = true;
                        }
                        else if (_receiveComplete && (bool)cJ2Compolet1.ReadVariable("RV_B_LinkSignalPath1_L3.Upstream.SendComplete"))
                        {
                            Thread.Sleep(1000);
                            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Downstream.ReceiveAble", false);
                            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Downstream.ReceiveStart", false);
                            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Downstream.ReceiveComplete", false);
                            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Downstream.JobTransferredSignal", false);

                            _load = false;
                            _receiveAble = false;
                            _receiveStart = false;
                            _receiveComplete = false;
                        }
                    }
                    else if (_exchange)
                    {
                        if (!(bool)cJ2Compolet1.ReadVariable("RV_B_LinkSignalPath1_L3.Downstream.DownstreamInline"))
                        {
                            Thread.Sleep(100);
                            continue;
                        }

                        if ((bool)cJ2Compolet1.ReadVariable("RV_B_LinkSignalPath1_L3.Downstream.DownstreamTrouble"))
                        {
                            Thread.Sleep(100);
                            continue;
                        }

                        if (!(bool)cJ2Compolet1.ReadVariable("RV_B_LinkSignalPath1_L3.Upstream.UpstreamInline"))
                        {
                            Thread.Sleep(100);
                            continue;
                        }

                        if ((bool)cJ2Compolet1.ReadVariable("RV_B_LinkSignalPath1_L3.Upstream.UpstreamTrouble"))
                        {
                            Thread.Sleep(100);
                            continue;
                        }

                        if (!(bool)cJ2Compolet1.ReadVariable("RV_B_LinkSignalPath1_L2.Downstream.DownstreamInline"))
                        {
                            Thread.Sleep(100);
                            continue;
                        }

                        if ((bool)cJ2Compolet1.ReadVariable("RV_B_LinkSignalPath1_L2.Downstream.DownstreamTrouble"))
                        {
                            Thread.Sleep(100);
                            continue;
                        }

                        if (!(bool)cJ2Compolet1.ReadVariable("RV_B_LinkSignalPath1_L2.Upstream.UpstreamInline"))
                        {
                            Thread.Sleep(100);
                            continue;
                        }

                        if ((bool)cJ2Compolet1.ReadVariable("RV_B_LinkSignalPath1_L2.Upstream.UpstreamTrouble"))
                        {
                            Thread.Sleep(100);
                            continue;
                        }


                        if (!_receiveAble && _exchange && (bool)cJ2Compolet1.ReadVariable("RV_B_LinkSignalPath1_L3.Upstream.SendAble"))
                        {

                            byte[] outJobData1 = (byte[])cJ2Compolet1.ReadVariable("RV_B_LinkSignalPath1_L3.UpstreamTransOutJobData1");//, GetOutJobData(dgvOutJobData1_L2));
                            byte[] outJobData2 = (byte[])cJ2Compolet1.ReadVariable("RV_B_LinkSignalPath1_L3.UpstreamTransOutJobData2");//, GetOutJobData(dgvOutJobData2_L2));
                            //object value2 = cJ2Compolet1.ReadVariable("RV_B_LinkSignalPath1_L2.DownstreamTransInJobData1");
                            byte[] outInJobData1 = (byte[])cJ2Compolet1.ReadVariable("RV_B_LinkSignalPath1_L3.DownstreamTransInJobData1");//, GetInJobData(dgvInJobData1_L2));
                            byte[] outInJobData2 = (byte[])cJ2Compolet1.ReadVariable("RV_B_LinkSignalPath1_L3.DownstreamTransInJobData2");//, GetInJobData(dgvInJobData2_L2));
                            SetOutJobData(outJobData1, dgvOutJobData1_L3);
                            SetOutJobData(outJobData2, dgvOutJobData2_L3);
                            SetInJobData(outInJobData1, dgvInJobData1_L3);
                            SetInJobData(outInJobData2, dgvInJobData2_L3);

                            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Downstream.ReceiveAble", true);
                            _receiveAble = true;
                            Thread.Sleep(100);
                            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Downstream.ExchangeExecute", true);
                            _exchangePossible = true;
                        }
                        else if (!_receiveComplete && !_receiveStart && _receiveAble && (bool)cJ2Compolet1.ReadVariable("RV_B_LinkSignalPath1_L3.Upstream.SendStart"))
                        {
                            _receiveStart = true;
                            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Downstream.ReceiveStart", true);
                            Thread.Sleep(1000);
                            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Downstream.HandInterference", false);

                            int count = 0;
                            while (count++ < 25)
                            {
                                if (_engineStop)
                                {
                                    return;
                                }
                                Thread.Sleep(100);//넣고
                            }

                            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Downstream.JobTransferredSignal", true);

                            count = 0;
                            while (count++ < 25)
                            {
                                if (_engineStop)
                                {
                                    return;
                                }
                                Thread.Sleep(100);//빼고
                            }

                            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Downstream.HandInterference", true);
                            Thread.Sleep(1000);
                            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Downstream.ReceiveComplete", true);

                            _receiveComplete = true;
                        }
                        else if (_receiveComplete && (bool)cJ2Compolet1.ReadVariable("RV_B_LinkSignalPath1_L3.Upstream.SendComplete"))
                        {
                            Thread.Sleep(1000);
                            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Downstream.ReceiveAble", false);
                            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Downstream.ReceiveStart", false);
                            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Downstream.ReceiveComplete", false);
                            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Downstream.JobTransferredSignal", false);

                            _load = false;
                            _receiveAble = false;
                            _receiveStart = false;
                            _receiveComplete = false;
                        }

                        if (!_sendAble && _receiveAble && _exchangePossible && _exchange)
                        {
                            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.UpstreamTransOutJobData1", GetOutJobData(dgvOutJobData1_L2));
                            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.UpstreamTransOutJobData2", GetOutJobData(dgvOutJobData2_L2));
                            //object value2 = cJ2Compolet1.ReadVariable("RV_B_LinkSignalPath1_L2.DownstreamTransInJobData1");
                            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.DownstreamTransInJobData1", GetInJobData(dgvInJobData1_L2));
                            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.DownstreamTransInJobData2", GetInJobData(dgvInJobData2_L2));

                            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Upstream.SendAble", true);
                            _sendAble = true;
                        }
                        else if (!_sendComplete && !_sendStart && _sendAble && (bool)cJ2Compolet1.ReadVariable("RV_B_LinkSignalPath1_L3.Downstream.ReceiveAble"))
                        {
                            _sendStart = true;
                            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Upstream.SendStart", true);
                        }

                        else if (!_sendComplete && !_receiveStart && _sendStart && (bool)cJ2Compolet1.ReadVariable("RV_B_LinkSignalPath1_L3.Downstream.ReceiveStart"))
                        {
                            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Upstream.HandInterference", false);

                            int count = 0;
                            while (count++ < 25)
                            {
                                if (_engineStop)
                                {
                                    return;
                                }
                                Thread.Sleep(100);//넣고
                            }

                            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Upstream.JobTransferredSignal", true);

                            count = 0;
                            while (count++ < 25)
                            {
                                if (_engineStop)
                                {
                                    return;
                                }
                                Thread.Sleep(100);//빼고
                            }

                            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Upstream.HandInterference", true);
                            Thread.Sleep(1000);
                            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Upstream.SendComplete", true);

                            _sendComplete = true;
                        }
                        else if (_sendComplete && (bool)cJ2Compolet1.ReadVariable("RV_B_LinkSignalPath1_L3.Downstream.ReceiveComplete"))
                        {
                            Thread.Sleep(1000);
                            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Upstream.SendAble", false);
                            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Upstream.SendStart", false);
                            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Upstream.SendComplete", false);
                            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Upstream.JobTransferredSignal", false);

                            _unload = false;
                            _sendAble = false;
                            _sendStart = false;
                            _sendComplete = false;
                            _exchangePossible = false;
                        }
                    }


                    if ((bool)cJ2Compolet1.ReadVariable("RV_B_RecipeChangeAuthorization_L3ToBC"))
                    {
                        object temp = cJ2Compolet1.ReadVariable("RV_W_RecipeChangeAuthorization_L3ToBC.UserAccount");
                        string userId = "";
                        string password = "";
                        if (temp is int[])
                        {
                            byte[] bytes = OMRON.Compolet.CIP.DataConverter.IntsToWords(temp as int[], DataTypes.BIN);
                            userId = cJ2Compolet1.PlcEncoding.GetString(bytes);
                            SetText(txtReadUserID, userId);
                        }
                        temp = cJ2Compolet1.ReadVariable("RV_W_RecipeChangeAuthorization_L3ToBC.Password");
                        if (temp is int[])
                        {
                            byte[] bytes = OMRON.Compolet.CIP.DataConverter.IntsToWords(temp as int[], DataTypes.BIN);
                            password = cJ2Compolet1.PlcEncoding.GetString(bytes);

                            SetText(txtReadPassword, password);
                        }
                        int result = 0;

                        cJ2Compolet1.WriteVariable("SD_W_RecipeChangePermission_BCToL3.UserAccount", OMRON.Compolet.CIP.DataConverter.WordsToInts(cJ2Compolet1.PlcEncoding.GetBytes(userId), DataTypes.BIN));
                        cJ2Compolet1.WriteVariable("SD_W_RecipeChangePermission_BCToL3.PermissionCode", _authorizationResult);
                        cJ2Compolet1.WriteVariable("RV_B_RecipeChangeAuthorization_L3ToBC", false);
                    }

                    if ((bool)cJ2Compolet1.ReadVariable("RV_B_CurrentPPIDRecipeIdReport_L3ToBC"))
                    {
                        object temp = cJ2Compolet1.ReadVariable("RV_W_CurrentPPIDRecipeIDReport_L3ToBC.PPID");
                        string ppid = "";
                        string recipeId = "";
                        if (temp is int[])
                        {
                            byte[] bytes = OMRON.Compolet.CIP.DataConverter.IntsToWords(temp as int[], DataTypes.BIN);
                            ppid = cJ2Compolet1.PlcEncoding.GetString(bytes);
                            SetText(txtCurPPID, ppid);
                        }
                        temp = cJ2Compolet1.ReadVariable("RV_W_CurrentPPIDRecipeIDReport_L3ToBC.RecipeID");
                        if (temp is int[])
                        {
                            byte[] bytes = OMRON.Compolet.CIP.DataConverter.IntsToWords(temp as int[], DataTypes.BIN);
                            recipeId = cJ2Compolet1.PlcEncoding.GetString(bytes);
                            SetText(txtCurRecipeID, recipeId);

                        }

                        cJ2Compolet1.WriteVariable("RV_B_CurrentPPIDRecipeIdReport_L3ToBC", false);
                    }
                    if ((bool)cJ2Compolet1.ReadVariable("RV_B_EqpStatusReport_L3ToBC"))
                    {
                        //object temp = cJ2Compolet1.ReadVariable("RV_W_CurrentPPIDRecipeIDReport_L3ToBC.PPID");
                        //string ppid = "";
                        //string recipeId = "";
                        //if(temp is int[])
                        //{
                        //    byte[] bytes = OMRON.Compolet.CIP.DataConverter.IntsToWords(temp as int[], DataTypes.BIN);
                        //    ppid = cJ2Compolet1.PlcEncoding.GetString(bytes);
                        //    SetText(txtCurPPID, ppid);
                        //}
                        //temp = cJ2Compolet1.ReadVariable("RV_W_CurrentPPIDRecipeIDReport_L3ToBC.RecipeID");
                        //if(temp is int[])
                        //{
                        //    byte[] bytes = OMRON.Compolet.CIP.DataConverter.IntsToWords(temp as int[], DataTypes.BIN);
                        //    recipeId = cJ2Compolet1.PlcEncoding.GetString(bytes);
                        //    SetText(txtCurRecipeID, recipeId);

                        //}

                        cJ2Compolet1.WriteVariable("RV_B_EqpStatusReport_L3ToBC", false);
                    }
                    if ((bool)cJ2Compolet1.ReadVariable("RV_B_AlarmStatusReport_L3ToBC"))
                    {
                        //object temp = cJ2Compolet1.ReadVariable("RV_W_CurrentPPIDRecipeIDReport_L3ToBC.PPID");
                        //string ppid = "";
                        //string recipeId = "";
                        //if(temp is int[])
                        //{
                        //    byte[] bytes = OMRON.Compolet.CIP.DataConverter.IntsToWords(temp as int[], DataTypes.BIN);
                        //    ppid = cJ2Compolet1.PlcEncoding.GetString(bytes);
                        //    SetText(txtCurPPID, ppid);
                        //}
                        //temp = cJ2Compolet1.ReadVariable("RV_W_CurrentPPIDRecipeIDReport_L3ToBC.RecipeID");
                        //if(temp is int[])
                        //{
                        //    byte[] bytes = OMRON.Compolet.CIP.DataConverter.IntsToWords(temp as int[], DataTypes.BIN);
                        //    recipeId = cJ2Compolet1.PlcEncoding.GetString(bytes);
                        //    SetText(txtCurRecipeID, recipeId);

                        //}

                        cJ2Compolet1.WriteVariable("RV_B_AlarmStatusReport_L3ToBC", false);
                    }

                    if ((bool)cJ2Compolet1.ReadVariable("RV_B_EquipmentModeChangeReport_L3ToBC"))
                    {
                        cJ2Compolet1.WriteVariable("RV_B_EquipmentModeChangeReport_L3ToBC", false);
                    }

                    if ((bool)cJ2Compolet1.ReadVariable("RV_B_ForwardSentOutJobReport_L3ToBC"))
                    {
                        cJ2Compolet1.WriteVariable("RV_B_ForwardSentOutJobReport_L3ToBC", false);
                    }

                    if ((bool)cJ2Compolet1.ReadVariable("RV_B_ForwardReceivedJobReport_L3ToBC"))
                    {
                        cJ2Compolet1.WriteVariable("RV_B_ForwardReceivedJobReport_L3ToBC", false);
                    }

                    if ((bool)cJ2Compolet1.ReadVariable("RV_B_GlassDataRequest_L3ToBC"))
                    {
                        
                        int glassType = (int)cJ2Compolet1.ReadVariable("RV_W_GlassDataRequest_L3ToBC.GlassType");
                        string glassID = cJ2Compolet1.PlcEncoding.GetString(OMRON.Compolet.CIP.DataConverter.IntsToWords((int[]) cJ2Compolet1.ReadVariable("RV_W_GlassDataRequest_L3ToBC.GlassID"), DataTypes.BIN));
                        string lotID = cJ2Compolet1.PlcEncoding.GetString(OMRON.Compolet.CIP.DataConverter.IntsToWords((int[])cJ2Compolet1.ReadVariable("RV_W_GlassDataRequest_L3ToBC.LotID"), DataTypes.BIN));

                        cJ2Compolet1.WriteVariable("SD_W_GlassDataRequestReply_BCToL3.ReplyStatus", 1);//1 EXIST, 2 NO EXIST
                        cJ2Compolet1.WriteVariable("SD_W_GlassDataRequestReply_BCToL3.JobDataABlock", GetOutJobData(dgvOutJobData1_L2));

                        cJ2Compolet1.WriteVariable("RV_B_GlassDataRequest_L3ToBC", false);
                    }
                    if ((bool)cJ2Compolet1.ReadVariable("RV_B_RemovedJobReport_L3ToBC"))
                    {
                        cJ2Compolet1.WriteVariable("RV_B_RemovedJobReport_L3ToBC", false);
                    }
                                        
                    Thread.Sleep(100);

                }
                catch (Exception ex)
                {

                }
            }
        }

        private void btnEngineStop_Click(object sender, EventArgs e)
        {
            if (btnEngineStop.Text == "START")
            {            
                EngineStartHandler engineStart = new EngineStartHandler(Unload);
                engineStart.BeginInvoke(new AsyncCallback(CallBack), null);
                btnEngineStop.Text = "STOP";
            }
            else
            {
                btnEngineStop.Text = "START";
                _engineStop = true;
            }
        }

        private void CallBack(IAsyncResult result)
        {
            //SetText(btnEngineStop, "START");
            Console.WriteLine("RUN THREAD END [" + Thread.CurrentThread.ManagedThreadId.ToString() + "]");
        }

        private void btnInitDataL3_Click(object sender, EventArgs e)
        {
            InitiallzeDataL3();
        }

        private void btnInitDataL2_Click(object sender, EventArgs e)
        {
            InitiallzeDataL2();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Upstream", new byte[] { 0, 0 });
            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Upstream.UpstreamInline", true);
            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Upstream.UpstreamInline", true);
            //cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Upstream.UpstreamTrouble", false);
            //cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Upstream.SendAble", false);
            //cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Upstream.SendStart", false);
            //cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Upstream.SendComplete", false);
            //cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Upstream.JobTransferredSignal", false);
            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Upstream.HandInterference", true);
            //cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Upstream.ExchangePossible", false);

            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Downstream", new byte[] { 0, 0 });
            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Downstream.DownstreamInline", true);
            //cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Downstream.DownstreamTrouble", false);
            //cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Downstream.ReceiveAble", false);
            //cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Downstream.ReceiveStart", false);
            //cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Downstream.ReceiveComplete", false);
            //cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Downstream.JobTransferredSignal", false);
            cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Downstream.HandInterference", true);
            //cJ2Compolet1.WriteVariable("RV_B_LinkSignalPath1_L2.Downstream.ExchangeCancelReceive", false);

            _receiveAble = false;
        }

        private void btnVariableRead_Click(object sender, EventArgs e)
        {
            object value = cJ2Compolet1.ReadVariable(comboBox1.Text);

            if (value == null)
            {
                textBox2.Text = "NULL";
                return;
            }
            textBox2.Text = "";
            if (value.GetType() == typeof(byte[]))
            {
                byte[] tempValue = value as byte[];
                for (int i = 0; i < tempValue.Length; i++)
                {
                    textBox2.Text += tempValue[i] + Environment.NewLine;
                }
            }
        }

        private void btnVariableWrite_Click(object sender, EventArgs e)
        {
            cJ2Compolet1.WriteVariable(comboBox1.Text, textBox2.Text);
        }

        private int _authorizationResult = 1;
        private void cbAuthorizationResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            int value = 0;
            int.TryParse(cbAuthorizationResult.Text.Split(':')[0], out value);

            if (value != 1)
            {
                _authorizationResult = 2;
            }
            else
            {
                _authorizationResult = value;
            }
        }
    }
}
