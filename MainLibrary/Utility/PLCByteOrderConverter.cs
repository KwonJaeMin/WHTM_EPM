namespace MainLibrary.Utility
{
    using System;

    public class PLCByteOrderConverter
    {
        private static ByteOrder plcOrder = ByteOrder.LittleEndian;
        private static ByteOrder sysOrder = (BitConverter.IsLittleEndian ? ByteOrder.LittleEndian : ByteOrder.BigEndian);

        internal static ushort HostToPLCOrder(ushort hostValue)
        {
            if (SystemByteOrder == PLCByteOrder)
            {
                return hostValue;
            }
            return BitConverter.ToUInt16(SwapByte(BitConverter.GetBytes(hostValue)), 0);
        }

        internal static uint HostToPLCOrder(uint hostValue)
        {
            if (SystemByteOrder == PLCByteOrder)
            {
                return hostValue;
            }
            return BitConverter.ToUInt32(SwapByte(BitConverter.GetBytes(hostValue)), 0);
        }

        internal static ulong HostToPLCOrder(ulong hostValue)
        {
            if (SystemByteOrder == PLCByteOrder)
            {
                return hostValue;
            }
            return BitConverter.ToUInt64(SwapByte(BitConverter.GetBytes(hostValue)), 0);
        }

        internal static ushort PLCToHostOrder(ushort plcValue)
        {
            if (SystemByteOrder == PLCByteOrder)
            {
                return plcValue;
            }
            return BitConverter.ToUInt16(SwapByte(BitConverter.GetBytes(plcValue)), 0);
        }

        internal static uint PLCToHostOrder(uint plcValue)
        {
            if (SystemByteOrder == PLCByteOrder)
            {
                return plcValue;
            }
            return BitConverter.ToUInt32(SwapByte(BitConverter.GetBytes(plcValue)), 0);
        }

        internal static ulong PLCToHostOrder(ulong plcValue)
        {
            if (!BitConverter.IsLittleEndian)
            {
                return plcValue;
            }
            return BitConverter.ToUInt64(SwapByte(BitConverter.GetBytes(plcValue)), 0);
        }

        public static byte[] SwapByte(byte[] byteArray)
        {
            if (byteArray == null)
            {
                return new byte[0];
            }
            byte[] buffer = new byte[byteArray.Length];
            for (int i = 0; i < (byteArray.Length / 2); i++)
            {
                buffer[i * 2] = byteArray[(i * 2) + 1];
                buffer[(i * 2) + 1] = byteArray[i * 2];
            }
            if ((byteArray.Length % 2) != 0)
            {
                buffer[byteArray.Length - 1] = byteArray[byteArray.Length - 1];
            }
            return buffer;
        }

        public static byte[] SwapByteIfNeed(byte[] byteArray)
        {
            if (SystemByteOrder == PLCByteOrder)
            {
                return byteArray;
            }
            return SwapByte(byteArray);
        }

        public static ByteOrder PLCByteOrder
        {
            get
            {
                return plcOrder;
            }
            set
            {
                plcOrder = value;
            }
        }

        public static ByteOrder SystemByteOrder
        {
            get
            {
                return sysOrder;
            }
        }

        public enum ByteOrder
        {
            BigEndian,
            LittleEndian
        }
    }
}

