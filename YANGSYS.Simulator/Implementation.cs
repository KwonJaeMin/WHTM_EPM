using System;
using System.Security.Principal;
using PlcRemotingObject;

namespace SmartPLCSimulator
{
    public class PlcRemotingClass : MarshalByRefObject, IPlcRemotingClass
    {
        public PlcRemotingClass()
        {
            //Console.WriteLine("연결됨");
        }

        public string Send(string input)
        {
            string s = input as string;
            string result = null;
            if (s != null && s.Length != 0)
            {
                if (s.Equals("HelloPLC"))
                {
                    result = "0";
                }
                else
                {
                    //if (s.Contains("24R"))
                    //    Console.WriteLine("A");

                    result = GetData(s); //Form1.bitMemory[Convert.ToInt32(input)].ToString();
                }
            }
            return result;
        }


        //수정필요 JSJ
        public ushort[] SendArray(string input)
        {
            string s = input as string;
            ushort[] result = null;
            if (s != null && s.Length != 0)
            {
                if (s.Equals("HelloPLC"))
                {
                    result = null;
                }
                else
                {
                    //if (s.Contains("24R"))
                    //    Console.WriteLine("A");

                    result = GetArrayData(s); //Form1.bitMemory[Convert.ToInt32(input)].ToString();
                }
            }
            return result;
        }

        private string GetData(string msg)
        {
            #region MELSEC-G 의 2영역 대응 수정, 2013-02-13, 파주 지사, 김성원 수정
            string retValue = "-1";

            MessageParser parser = new MessageParser(msg);

            switch (parser.Command)
            {
                case ReadWriteType.Unknown:
                    break;
                case ReadWriteType.R:
                    retValue = DeviceManager.Read(parser.Device, parser.Address, parser.Length);
                    break;
                case ReadWriteType.W:
                    retValue = DeviceManager.Write(parser.Device, parser.Address, parser.Length, parser.Data);
                    break;
                default:
                    break;
            } 
            #endregion

            //string retValue = "-1";
            //string strdebugMsg = msg;

            //string device = msg.Substring(0, 2);  //23,24,,, --> Bit, Word, Register
            //device = Convert.ToInt32( device).ToString();
            //msg = msg.Remove(0, 2);
            //string command = msg.Substring(0, 1);  //'R', 'W' --> Read, Write
            //msg = msg.Remove(0, 1);

            //string startAdd = "";

            ////Melsec-G 의 2영역 관련하여 추가함. 4와 5자리에 대해서 구분해서 잘라주어야 함.
            //if (command == "R")
            //{
            //    //if (strdebugMsg.Length > 11)
            //    //{
            //    //    startAdd = msg.Substring(0, 5);
            //    //    msg = msg.Remove(0, 5);
            //    //}
            //    //else
            //    //{
            //        startAdd = msg.Substring(0, 4);
            //        msg = msg.Remove(0, 4);
            //    //}
            //}
            //else
            //{
            //    //if (strdebugMsg.Length > 12)
            //    //{
            //    //    startAdd = msg.Substring(0, 5);
            //    //    msg = msg.Remove(0, 5);
            //    //}
            //    //else
            //    //{
            //        startAdd = msg.Substring(0, 4);
            //        msg = msg.Remove(0, 4);
            //    //}
            //}

            //string length = msg.Substring(0, 4);
            //msg = msg.Remove(0, 4);
            //string data = "";
            //if (msg.Length != 0)
            //{
            //    data = msg;
            //}

            //int intStartAdd = Convert.ToInt32(Utils.HexToDec(startAdd));
            //int intLength = Convert.ToInt32(Utils.HexToDec(length));

            //strdebugMsg = strdebugMsg + "";

            //switch(command)
            //{
            //    case "R":
            //        retValue = DeviceManager.Read(device, intStartAdd, intLength);
            //        break;
            //    case "W":
            //        retValue = DeviceManager.Write(device, intStartAdd, intLength, data);
            //        break;
            //}
            return retValue;
        }

        private ushort[] GetArrayData(string msg)
        {
            #region MELSEC-G 의 2영역 대응 수정, 2013-02-13, 파주 지사, 김성원 수정
            ushort[] retValue = null;
            MessageParser parser = new MessageParser(msg);

            switch (parser.Command)
            {
                case ReadWriteType.Unknown:
                    break;
                case ReadWriteType.R:
                    retValue = DeviceManager.ArrayRead(parser.Device, parser.Address, parser.Length);
                    break;
                case ReadWriteType.W:
                    retValue = null;
                    break;
                default:
                    break;
            }

            return retValue; 
            #endregion

            //ushort[] retValue = null;
            //string strdebugMsg = msg;
            

            //string device = msg.Substring(0, 2);  //23,24,,, --> Bit, Word, Register
            //device = Convert.ToInt32(device).ToString();
            //msg = msg.Remove(0, 2);
            //string command = msg.Substring(0, 1);  //'R', 'W' --> Read, Write
            //msg = msg.Remove(0, 1);

            //string startAdd = "";

            ////Melsec-G 의 2영역 관련하여 추가함. 4와 5자리에 대해서 구분해서 잘라주어야 함.
            //if (command == "R")
            //{
            //    if (strdebugMsg.Length > 11)
            //    {
            //        startAdd = msg.Substring(0, 5);
            //        msg = msg.Remove(0, 5);
            //    }
            //    else
            //    {
            //        startAdd = msg.Substring(0, 4);
            //        msg = msg.Remove(0, 4);
            //    }
            //}
            //else
            //{
            //    if (strdebugMsg.Length > 12)
            //    {
            //        startAdd = msg.Substring(0, 5);
            //        msg = msg.Remove(0, 5);
            //    }
            //    else
            //    {
            //        startAdd = msg.Substring(0, 4);
            //        msg = msg.Remove(0, 4);
            //    }
            //}

            //string length = msg.Substring(0, 4);
            //msg = msg.Remove(0, 4);
            //string data = "";
            //if (msg.Length != 0)
            //{
            //    data = msg;
            //}

            //int intStartAdd = Convert.ToInt32(Utils.HexToDec(startAdd));
            //int intLength = Convert.ToInt32(Utils.HexToDec(length));

            //strdebugMsg = strdebugMsg + "";

            //switch (command)
            //{
            //    case "R":
            //        retValue = DeviceManager.ArrayRead(device, intStartAdd, intLength);
            //        break;
            //    case "W":
            //        retValue = null;
            //        break;
            //}
            //return retValue;
        }

        /// <summary>
        /// SIMULATOR 통신에 사용되는 메시지 행위(Read/Write) 구분자
        /// <para>2013-02-13, 파주 지사, 김성원 추가 </para>
        /// </summary>
        private enum ReadWriteType
        {
            Unknown,
            R,
            W
        }

        /// <summary>
        /// SIMULATOR 통신에 사용되는 메시지를 파싱하는 파서
        /// <para>2013-02-13, 파주 지사, 김성원 추가 </para>
        /// </summary>
        private class MessageParser
        {
            public string Device { get; set; }
            public ReadWriteType Command { get; set; }
            public int Address { get; set; }
            public int Length { get; set; }
            public string Data { get; set; }
            public string OriginalMessage { get; set; }


            public MessageParser(string msg) //메시지 FORMAT은 "23R,ADDRESS=0000,LENGTH=FFFFF,DATA=0044" 모 요런식으로 들어옴
            {
                OriginalMessage = msg;

                string[] temp = msg.Split(',');
                if (temp.Length > 0) //23W
                {
                    Device = Convert.ToInt32(temp[0].Substring(0, 2)).ToString();

                    if (Enum.IsDefined(typeof(ReadWriteType), temp[0].Substring(2, 1)))
                    {
                        Command = (ReadWriteType)Enum.Parse(typeof(ReadWriteType), temp[0].Substring(2, 1));
                    }
                    else
                    {
                        Command = ReadWriteType.Unknown;
                    }
                }

                if (temp.Length > 1) //ADDRESS=
                {
                    string[] temp2 = temp[1].Split('=');
                    if (temp2[0] == "ADDRESS")
                    {
                        Address = Convert.ToInt32(Utils.HexToDec(temp2[1]));
                    }
                    else
                    {
                        throw new ArgumentException("REMOTING MESSAGE에 ADDRESS 항목이 없습니다.");
                    }
                }

                if (temp.Length > 2) //LENGTH=
                {
                    string[] temp3 = temp[2].Split('=');
                    if (temp3[0] == "LENGTH")
                    {
                        Length = Convert.ToInt32(Utils.HexToDec(temp3[1]));
                    }
                    else
                    {
                        throw new ArgumentException("REMOTING MESSAGE에 LENGTH 항목이 없습니다.");
                    }
                }
                if (temp.Length > 3) //DATA=
                {
                    string[] temp4 = temp[3].Split('=');
                    if (temp4[0] == "DATA")
                    {
                        Data = temp4[1];
                    }
                    else
                    {
                        throw new ArgumentException("REMOTING MESSAGE에 DATA 항목이 없습니다.");
                    }
                }
            }
        }
    }
}