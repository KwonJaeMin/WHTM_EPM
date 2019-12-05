namespace OMRON.CIP.ObjectLibrary
{
    using System;
    using System.Collections;
    using System.Text;

    public class PLCDataConverter
    {
        internal static byte[] _SystemDataToPLCData(object data, int destByteWidth, int plcDataFormat)
        {
            switch (plcDataFormat)
            {
                case 0:
                {
                    if (destByteWidth != 1)
                    {
                        throw new ArgumentException("sourceByteWidth");
                    }
                    bool flag = (bool) Convert.ChangeType(data, typeof(bool));
                    return new byte[] { (flag ? ((byte) 1) : ((byte) 0)) };
                }
                case 1:
                    switch (destByteWidth)
                    {
                        case 2:
                        {
                            ushort hostValue = (ushort) Convert.ChangeType(data, typeof(ushort));
                            return BitConverter.GetBytes(PLCByteOrderConverter.HostToPLCOrder(hostValue));
                        }
                        case 3:
                            goto Label_01D0;

                        case 4:
                        {
                            uint num5 = (uint) Convert.ChangeType(data, typeof(uint));
                            return BitConverter.GetBytes(PLCByteOrderConverter.HostToPLCOrder(num5));
                        }
                        case 8:
                        {
                            ulong num6 = (ulong) Convert.ChangeType(data, typeof(ulong));
                            return BitConverter.GetBytes(PLCByteOrderConverter.HostToPLCOrder(num6));
                        }
                    }
                    goto Label_01D0;

                case 2:
                    switch (destByteWidth)
                    {
                        case 2:
                        {
                            short num7 = (short) Convert.ChangeType(data, typeof(short));
                            num7 = (short) PLCByteOrderConverter.HostToPLCOrder((ushort) num7);
                            return BitConverter.GetBytes(num7);
                        }
                        case 3:
                            goto Label_0274;

                        case 4:
                        {
                            int num8 = (int) Convert.ChangeType(data, typeof(int));
                            return BitConverter.GetBytes((int) PLCByteOrderConverter.HostToPLCOrder((uint) num8));
                        }
                        case 8:
                        {
                            long num9 = (long) Convert.ChangeType(data, typeof(long));
                            return BitConverter.GetBytes((long) PLCByteOrderConverter.HostToPLCOrder((ulong) num9));
                        }
                    }
                    goto Label_0274;

                case 3:
                    switch (destByteWidth)
                    {
                        case 2:
                        {
                            ushort num = (ushort) Convert.ChangeType(data, typeof(ushort));
                            return BitConverter.GetBytes(PLCByteOrderConverter.HostToPLCOrder(Convert.ToUInt16(num.ToString(), 0x10)));
                        }
                        case 4:
                        {
                            uint num2 = (uint) Convert.ChangeType(data, typeof(uint));
                            return BitConverter.GetBytes(PLCByteOrderConverter.HostToPLCOrder(Convert.ToUInt32(num2.ToString(), 0x10)));
                        }
                        case 8:
                        {
                            ulong num3 = (ulong) Convert.ChangeType(data, typeof(ulong));
                            return BitConverter.GetBytes(PLCByteOrderConverter.HostToPLCOrder(Convert.ToUInt64(num3.ToString(), 0x10)));
                        }
                    }
                    break;

                case 4:
                    switch (destByteWidth)
                    {
                        case 4:
                        {
                            float num10 = (float) Convert.ChangeType(data, typeof(float));
                            return PLCByteOrderConverter.SwapByteIfNeed(BitConverter.GetBytes(num10));
                        }
                        case 8:
                        {
                            double num11 = (double) Convert.ChangeType(data, typeof(double));
                            return PLCByteOrderConverter.SwapByteIfNeed(BitConverter.GetBytes(num11));
                        }
                    }
                    throw new ArgumentOutOfRangeException("destByteWidht");

                case 5:
                {
                    byte[] destinationArray = new byte[destByteWidth];
                    for (int i = 0; i < destByteWidth; i++)
                    {
                        destinationArray[i] = 0;
                    }
                    string s = (string) Convert.ChangeType(data, typeof(string));
                    ASCIIEncoding encoding = new ASCIIEncoding();
                    Array.Copy(encoding.GetBytes(s), 0, destinationArray, 0, Math.Min(encoding.GetByteCount(s), destinationArray.Length));
                    return destinationArray;
                }
                default:
                    throw new ArgumentOutOfRangeException("destByteWidht");
            }
            throw new ArgumentOutOfRangeException("destByteWidht");
        Label_01D0:
            throw new ArgumentOutOfRangeException("destByteWidth");
        Label_0274:
            throw new ArgumentOutOfRangeException("destByteWidht");
        }

        public static string ByteArrayToString(byte[] value)
        {
            StringBuilder builder = new StringBuilder(value.Length * 4);
            for (int i = 0; i < value.Length; i++)
            {
                builder.Append(value[i].ToString("X2"));
            }
            return builder.ToString();
        }

        public static string ByteArrayToString(byte[] value, object separator)
        {
            StringBuilder builder = new StringBuilder(value.Length * 4);
            for (int i = 0; i < value.Length; i++)
            {
                builder.Append(value[i].ToString("X2"));
                builder.Append(separator.ToString());
            }
            return builder.ToString();
        }

        public static bool PLC1ByteAsBITToSystemBoolean(byte[] array, int startIndex)
        {
            return (bool) PLCDataToSystemData(array, startIndex, 1, 0, typeof(bool));
        }

        public static bool[] PLC1ByteAsBITToSystemBoolean(byte[] array, int startIndex, int element)
        {
            bool[] flagArray = new bool[element];
            for (int i = 0; i < element; i++)
            {
                flagArray[i] = PLC1ByteAsBITToSystemBoolean(array, startIndex);
                startIndex++;
            }
            return flagArray;
        }

        public static int PLC2ByteAsBCDToSystemInteger(byte[] array, int startIndex)
        {
            return (int) PLCDataToSystemData(array, startIndex, 2, 3, typeof(int));
        }

        public static int[] PLC2ByteAsBCDToSystemInteger(byte[] array, int startIndex, int element)
        {
            int[] numArray = new int[element];
            for (int i = 0; i < element; i++)
            {
                byte[] destinationArray = new byte[2];
                Array.Copy(array, startIndex, destinationArray, 0, 2);
                numArray[i] = PLC2ByteAsBCDToSystemInteger(destinationArray, 0);
                startIndex += 2;
            }
            return numArray;
        }

        public static int PLC2ByteAsBINToSystemInteger(byte[] array, int startIndex)
        {
            return (int) PLCDataToSystemData(array, startIndex, 2, 1, typeof(int));
        }

        public static int[] PLC2ByteAsBINToSystemInteger(byte[] array, int startIndex, int element)
        {
            int[] numArray = new int[element];
            for (int i = 0; i < element; i++)
            {
                byte[] destinationArray = new byte[2];
                Array.Copy(array, startIndex, destinationArray, 0, 2);
                numArray[i] = PLC2ByteAsBINToSystemInteger(destinationArray, 0);
                startIndex += 2;
            }
            return numArray;
        }

        public static int PLC2ByteAsSBINToSystemInteger(byte[] array, int startIndex)
        {
            return (int) PLCDataToSystemData(array, startIndex, 2, 2, typeof(int));
        }

        public static int[] PLC2ByteAsSBINToSystemInteger(byte[] array, int startIndex, int element)
        {
            int[] numArray = new int[element];
            for (int i = 0; i < element; i++)
            {
                byte[] destinationArray = new byte[2];
                Array.Copy(array, startIndex, destinationArray, 0, 2);
                numArray[i] = PLC2ByteAsSBINToSystemInteger(destinationArray, 0);
                startIndex += 2;
            }
            return numArray;
        }

        public static long PLC4ByteAsBCDToSystemInteger(byte[] array, int startIndex)
        {
            return (long) PLCDataToSystemData(array, startIndex, 4, 3, typeof(long));
        }

        public static long[] PLC4ByteAsBCDToSystemInteger(byte[] array, int startIndex, int element)
        {
            long[] numArray = new long[element];
            for (int i = 0; i < element; i++)
            {
                byte[] destinationArray = new byte[4];
                Array.Copy(array, startIndex, destinationArray, 0, 4);
                numArray[i] = PLC4ByteAsBCDToSystemInteger(destinationArray, 0);
                startIndex += 4;
            }
            return numArray;
        }

        public static long PLC4ByteAsBINToSystemInteger(byte[] array, int startIndex)
        {
            return (long) PLCDataToSystemData(array, startIndex, 4, 1, typeof(long));
        }

        public static long[] PLC4ByteAsBINToSystemInteger(byte[] array, int startIndex, int element)
        {
            long[] numArray = new long[element];
            for (int i = 0; i < element; i++)
            {
                byte[] destinationArray = new byte[4];
                Array.Copy(array, startIndex, destinationArray, 0, 4);
                numArray[i] = PLC4ByteAsBINToSystemInteger(destinationArray, 0);
                startIndex += 4;
            }
            return numArray;
        }

        public static long PLC4ByteAsSBINToSystemInteger(byte[] array, int startIndex)
        {
            return (long) PLCDataToSystemData(array, startIndex, 4, 2, typeof(long));
        }

        public static long[] PLC4ByteAsSBINToSystemInteger(byte[] array, int startIndex, int element)
        {
            long[] numArray = new long[element];
            for (int i = 0; i < element; i++)
            {
                byte[] destinationArray = new byte[4];
                Array.Copy(array, startIndex, destinationArray, 0, 4);
                numArray[i] = PLC4ByteAsSBINToSystemInteger(destinationArray, 0);
                startIndex += 4;
            }
            return numArray;
        }

        public static float PLC4ByteToSystemFloat(byte[] array, int startIndex)
        {
            return (float) PLCDataToSystemData(array, startIndex, 4, 4, typeof(float));
        }

        public static float[] PLC4ByteToSystemFloat(byte[] array, int startIndex, int element)
        {
            float[] numArray = new float[element];
            for (int i = 0; i < element; i++)
            {
                byte[] destinationArray = new byte[4];
                Array.Copy(array, startIndex, destinationArray, 0, 4);
                numArray[i] = PLC4ByteToSystemFloat(destinationArray, 0);
                startIndex += 4;
            }
            return numArray;
        }

        public static decimal PLC8ByteAsBCDToSystemLong(byte[] array, int startIndex)
        {
            return (decimal) PLCDataToSystemData(array, startIndex, 8, 3, typeof(decimal));
        }

        public static decimal[] PLC8ByteAsBCDToSystemLong(byte[] array, int startIndex, int element)
        {
            decimal[] numArray = new decimal[element];
            for (int i = 0; i < element; i++)
            {
                byte[] destinationArray = new byte[8];
                Array.Copy(array, startIndex, destinationArray, 0, 8);
                numArray[i] = PLC8ByteAsBCDToSystemLong(destinationArray, 0);
                startIndex += 8;
            }
            return numArray;
        }

        public static decimal PLC8ByteAsBINToSystemLong(byte[] array, int startIndex)
        {
            return (decimal) PLCDataToSystemData(array, startIndex, 8, 1, typeof(decimal));
        }

        public static decimal[] PLC8ByteAsBINToSystemLong(byte[] array, int startIndex, int element)
        {
            decimal[] numArray = new decimal[element];
            for (int i = 0; i < element; i++)
            {
                byte[] destinationArray = new byte[8];
                Array.Copy(array, startIndex, destinationArray, 0, 8);
                numArray[i] = PLC8ByteAsBINToSystemLong(destinationArray, 0);
                startIndex += 8;
            }
            return numArray;
        }

        public static decimal PLC8ByteAsSBINToSystemLong(byte[] array, int startIndex)
        {
            return (decimal) PLCDataToSystemData(array, startIndex, 8, 2, typeof(decimal));
        }

        public static decimal[] PLC8ByteAsSBINToSystemLong(byte[] array, int startIndex, int element)
        {
            decimal[] numArray = new decimal[element];
            for (int i = 0; i < element; i++)
            {
                byte[] destinationArray = new byte[8];
                Array.Copy(array, startIndex, destinationArray, 0, 8);
                numArray[i] = PLC8ByteAsSBINToSystemLong(destinationArray, 0);
                startIndex += 8;
            }
            return numArray;
        }

        public static double PLC8ByteToSystemFloat(byte[] array, int startIndex)
        {
            return (double) PLCDataToSystemData(array, startIndex, 8, 4, typeof(double));
        }

        public static double[] PLC8ByteToSystemFloat(byte[] array, int startIndex, int element)
        {
            double[] numArray = new double[element];
            for (int i = 0; i < element; i++)
            {
                byte[] destinationArray = new byte[8];
                Array.Copy(array, startIndex, destinationArray, 0, 8);
                numArray[i] = PLC8ByteToSystemFloat(destinationArray, 0);
                startIndex += 8;
            }
            return numArray;
        }

        public static object PLCDataToSystemData(byte[] array, int index, int sourceByteWidth, int plcDataFormat, Type systemDataType)
        {
            ulong num;
            object obj2;
            object obj3;
            byte[] destinationArray = new byte[sourceByteWidth];
            Array.Copy(array, index, destinationArray, 0, sourceByteWidth);
            switch (plcDataFormat)
            {
                case 0:
                {
                    if (sourceByteWidth != 1)
                    {
                        throw new ArgumentOutOfRangeException("sourceByteWidth");
                    }
                    bool flag = destinationArray[0] != 0;
                    return Convert.ChangeType(flag, systemDataType);
                }
                case 1:
                case 3:
                    destinationArray = PLCByteOrderConverter.SwapByteIfNeed(destinationArray);
                    switch (sourceByteWidth)
                    {
                        case 1:
                            num = destinationArray[0];
                            goto Label_00BB;

                        case 2:
                            num = BitConverter.ToUInt16(destinationArray, 0);
                            goto Label_00BB;

                        case 4:
                            num = BitConverter.ToUInt32(destinationArray, 0);
                            goto Label_00BB;

                        case 8:
                            num = BitConverter.ToUInt64(destinationArray, 0);
                            goto Label_00BB;
                    }
                    break;

                case 2:
                    destinationArray = PLCByteOrderConverter.SwapByteIfNeed(destinationArray);
                    switch (sourceByteWidth)
                    {
                        case 1:
                            obj2 = destinationArray[0];
                            goto Label_015F;

                        case 2:
                            obj2 = BitConverter.ToInt16(destinationArray, 0);
                            goto Label_015F;

                        case 3:
                            goto Label_0154;

                        case 4:
                            obj2 = BitConverter.ToInt32(destinationArray, 0);
                            goto Label_015F;

                        case 8:
                            obj2 = BitConverter.ToInt64(destinationArray, 0);
                            goto Label_015F;
                    }
                    goto Label_0154;

                case 4:
                    destinationArray = PLCByteOrderConverter.SwapByteIfNeed(destinationArray);
                    switch (sourceByteWidth)
                    {
                        case 4:
                            obj3 = BitConverter.ToSingle(destinationArray, 0);
                            goto Label_01AA;

                        case 8:
                            obj3 = BitConverter.ToDouble(destinationArray, 0);
                            goto Label_01AA;
                    }
                    throw new ArgumentOutOfRangeException("sourceByteWidth");

                case 5:
                {
                    ASCIIEncoding encoding = new ASCIIEncoding();
                    return Convert.ChangeType(encoding.GetString(destinationArray, index, sourceByteWidth), systemDataType);
                }
                default:
                    throw new ArgumentOutOfRangeException("plcDataFormat");
            }
            throw new ArgumentOutOfRangeException("sourceByteWidth");
        Label_00BB:
            if (plcDataFormat == 3)
            {
                try
                {
                    num = Convert.ToUInt64(num.ToString("X"));
                }
                catch (FormatException exception)
                {
                    throw new BCDFormatException((long) num, exception);
                }
            }
            return Convert.ChangeType(num, systemDataType);
        Label_0154:
            throw new ArgumentOutOfRangeException("sourceByteWidth");
        Label_015F:
            return Convert.ChangeType(obj2, systemDataType);
        Label_01AA:
            return Convert.ChangeType(obj3, systemDataType);
        }

        public static byte[] StirngToByteArray(string value)
        {
            if ((value.Length % 2) == 1)
            {
                value = value + '0';
            }
            byte[] buffer = new byte[value.Length / 2];
            for (int i = 0; i < (value.Length / 2); i++)
            {
                buffer[i] = Convert.ToByte(value.Substring(i * 2, 2), 0x10);
            }
            return buffer;
        }

        public static byte[] SystemBooleanToPLC1ByteAsBIT(bool systemNumeric)
        {
            byte[] array = new byte[1];
            SystemDataToPLCData(systemNumeric, ref array, 0, 1, 0);
            return array;
        }

        public static void SystemBooleanToPLC1ByteAsBIT(bool[] systemNumeric, ref byte[] array, int startIndex)
        {
            foreach (bool flag in systemNumeric)
            {
                SystemDataToPLCData(flag, ref array, startIndex, 1, 0);
                startIndex++;
            }
        }

        public static byte[] SystemDataToPLCData(object data, int destByteWidth, int plcDataFormat)
        {
            byte[] buffer2;
            try
            {
                if (data.GetType().IsArray)
                {
                    ArrayList list = new ArrayList();
                    foreach (object obj2 in (Array) data)
                    {
                        byte[] c = _SystemDataToPLCData(obj2, destByteWidth, plcDataFormat);
                        list.AddRange(c);
                    }
                    return (byte[]) list.ToArray(typeof(byte));
                }
                buffer2 = _SystemDataToPLCData(data, destByteWidth, plcDataFormat);
            }
            catch (OverflowException)
            {
                throw new ArgumentOutOfRangeException();
            }
            return buffer2;
        }

        public static void SystemDataToPLCData(object data, ref byte[] array, int startIndex, int destByteWidth, int plcDataFormat)
        {
            byte[] sourceArray = SystemDataToPLCData(data, destByteWidth, plcDataFormat);
            Array.Copy(sourceArray, 0, array, startIndex, Math.Min(sourceArray.Length, destByteWidth));
        }

        public static byte[] SystemFloatToPLC4Byte(float systemNumeric)
        {
            byte[] array = new byte[4];
            SystemDataToPLCData(systemNumeric, ref array, 0, 4, 4);
            return array;
        }

        public static void SystemFloatToPLC4Byte(float[] systemNumeric, ref byte[] array, int startIndex)
        {
            foreach (float num in systemNumeric)
            {
                SystemDataToPLCData(num, ref array, startIndex, 4, 4);
                startIndex += 4;
            }
        }

        public static byte[] SystemFloatToPLC8Byte(double systemNumeric)
        {
            byte[] array = new byte[8];
            SystemDataToPLCData(systemNumeric, ref array, 0, 8, 4);
            return array;
        }

        public static void SystemFloatToPLC8Byte(double[] systemNumeric, ref byte[] array, int startIndex)
        {
            foreach (double num in systemNumeric)
            {
                SystemDataToPLCData(num, ref array, startIndex, 8, 4);
                startIndex += 8;
            }
        }

        public static byte[] SystemIntegerToPLC2ByteAsBCD(int systemNumeric)
        {
            byte[] array = new byte[2];
            SystemDataToPLCData(systemNumeric, ref array, 0, 2, 3);
            return array;
        }

        public static void SystemIntegerToPLC2ByteAsBCD(int[] systemNumeric, ref byte[] array, int startIndex)
        {
            foreach (int num in systemNumeric)
            {
                SystemDataToPLCData(num, ref array, startIndex, 2, 3);
                startIndex += 2;
            }
        }

        public static byte[] SystemIntegerToPLC2ByteAsBIN(int systemNumeric)
        {
            byte[] array = new byte[2];
            SystemDataToPLCData(systemNumeric, ref array, 0, 2, 1);
            return array;
        }

        public static void SystemIntegerToPLC2ByteAsBIN(int[] systemNumeric, ref byte[] array, int startIndex)
        {
            foreach (int num in systemNumeric)
            {
                SystemDataToPLCData(num, ref array, startIndex, 2, 1);
                startIndex += 2;
            }
        }

        public static byte[] SystemIntegerToPLC2ByteAsSBIN(int systemNumeric)
        {
            byte[] array = new byte[2];
            SystemDataToPLCData(systemNumeric, ref array, 0, 2, 2);
            return array;
        }

        public static byte[] SystemIntegerToPLC2ByteAsSBIN(long systemNumeric)
        {
            byte[] array = new byte[4];
            SystemDataToPLCData(systemNumeric, ref array, 0, 4, 2);
            return array;
        }

        public static void SystemIntegerToPLC2ByteAsSBIN(int[] systemNumeric, ref byte[] array, int startIndex)
        {
            foreach (int num in systemNumeric)
            {
                SystemDataToPLCData(num, ref array, startIndex, 2, 2);
                startIndex += 2;
            }
        }

        public static void SystemIntegerToPLC2ByteAsSBIN(long[] systemNumeric, ref byte[] array, int startIndex)
        {
            foreach (long num in systemNumeric)
            {
                SystemDataToPLCData(num, ref array, startIndex, 4, 2);
                startIndex += 4;
            }
        }

        public static byte[] SystemIntegerToPLC4ByteAsBCD(long systemNumeric)
        {
            byte[] array = new byte[4];
            SystemDataToPLCData(systemNumeric, ref array, 0, 4, 3);
            return array;
        }

        public static void SystemIntegerToPLC4ByteAsBCD(long[] systemNumeric, ref byte[] array, int startIndex)
        {
            foreach (int num in systemNumeric)
            {
                SystemDataToPLCData(num, ref array, startIndex, 4, 3);
                startIndex += 4;
            }
        }

        public static byte[] SystemIntegerToPLC4ByteAsBIN(long systemNumeric)
        {
            byte[] array = new byte[4];
            SystemDataToPLCData(systemNumeric, ref array, 0, 4, 1);
            return array;
        }

        public static void SystemIntegerToPLC4ByteAsBIN(long[] systemNumeric, ref byte[] array, int startIndex)
        {
            foreach (long num in systemNumeric)
            {
                SystemDataToPLCData(num, ref array, startIndex, 4, 1);
                startIndex += 4;
            }
        }

        public static byte[] SystemIntegerToPLC4ByteAsSBIN(long systemNumeric)
        {
            byte[] array = new byte[4];
            SystemDataToPLCData(systemNumeric, ref array, 0, 4, 2);
            return array;
        }

        public static void SystemIntegerToPLC4ByteAsSBIN(long[] systemNumeric, ref byte[] array, int startIndex)
        {
            foreach (long num in systemNumeric)
            {
                SystemDataToPLCData(num, ref array, startIndex, 4, 2);
                startIndex += 4;
            }
        }

        public static byte[] SystemLongToPLC8ByteAsBCD(decimal systemNumeric)
        {
            byte[] array = new byte[8];
            SystemDataToPLCData(systemNumeric, ref array, 0, 8, 3);
            return array;
        }

        public static void SystemLongToPLC8ByteAsBCD(decimal[] systemNumeric, ref byte[] array, int startIndex)
        {
            foreach (decimal num in systemNumeric)
            {
                SystemDataToPLCData(num, ref array, startIndex, 8, 3);
                startIndex += 8;
            }
        }

        public static byte[] SystemLongToPLC8ByteAsBIN(decimal systemNumeric)
        {
            byte[] array = new byte[8];
            SystemDataToPLCData(systemNumeric, ref array, 0, 8, 1);
            return array;
        }

        public static void SystemLongToPLC8ByteAsBIN(decimal[] systemNumeric, ref byte[] array, int startIndex)
        {
            foreach (decimal num in systemNumeric)
            {
                SystemDataToPLCData(num, ref array, startIndex, 8, 1);
                startIndex += 8;
            }
        }

        public static byte[] SystemLongToPLC8ByteAsSBIN(decimal systemNumeric)
        {
            byte[] array = new byte[8];
            SystemDataToPLCData(systemNumeric, ref array, 0, 8, 2);
            return array;
        }

        public static void SystemLongToPLC8ByteAsSBIN(decimal[] systemNumeric, ref byte[] array, int startIndex)
        {
            foreach (decimal num in systemNumeric)
            {
                SystemDataToPLCData(num, ref array, startIndex, 8, 2);
                startIndex += 8;
            }
        }

        public enum PLCDataConverterSize
        {
            SizeOfBit = 1,
            SizeOfByte = 1,
            SizeOfChannel = 2,
            SizeOfDouble = 8,
            SizeOfInt = 4,
            SizeOfLong = 8,
            SizeOfShort = 2,
            SizeOfSingle = 4
        }

        public enum PLCDataFormat
        {
            BIT,
            BIN,
            SBIN,
            BCD,
            FLOAT,
            STRING
        }
    }
}

