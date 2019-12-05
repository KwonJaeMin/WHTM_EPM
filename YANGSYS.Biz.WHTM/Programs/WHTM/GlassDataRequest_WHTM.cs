using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YANGSYS.ControlLib;
using SOFD.Properties;
using SOFD.InterfaceTimeout;
using MainLibrary;
using SOFD.Component;
using SOFD.Component.Interface;

using SOFD.Logger;
using SOFD.Global.Manager;
using System.Threading;
using MainLibrary.Property;


namespace YANGSYS.Biz.Programs
{

    public class GlassDataRequest_WHTM : AProgram
    {
        private CMain _main = null;
        private bool _enable = false;

        //BC
        private CScanControlProperties IB_GLASS_DATA_REQUEST = null;//RV_B_GlassDataRequest_L3ToBC
        private CScanControlProperties IW_GLASS_DATA_REQUEST_REPLY_REPLY_STATUS = null;//SD_W_GlassDataRequestReply_BCToL3.ReplyStatus
        private CScanControlProperties IW_GLASS_DATA_REQUEST_REPLY_JOB_DATAA = null;//SD_W_GlassDataRequestReply_BCToL3.JobDataABlock
        //PROBE CIM
        private CPLCControlProperties OB_GLASS_DATA_REQUEST = null;//RV_B_GlassDataRequest_L3ToBC
        private CPLCControlProperties OW_GLASS_DATA_REQUEST_LOTID = null;//RV_W_GlassDataRequest_L3ToBC.LotID
        private CPLCControlProperties OW_GLASS_DATA_REQUEST_GLASSID = null;//RV_W_GlassDataRequest_L3ToBC.GlassID
        private CPLCControlProperties OW_GLASS_DATA_REQUEST_GLASS_TYPE = null;//RV_W_GlassDataRequest_L3ToBC.GlassType
        private CScanControlProperties VI_LOST_GLASS_DATA_REQUEST = null;
        private string _controlName = "";
        private CProbeControl _component = null;

        private const int REPLY_EXIST = 1;
        private const int REPLY_NO_EXIST = 2;

        public GlassDataRequest_WHTM()
        {
        }

        public override int Init()
        {
            _enable = true;

            //BC
            IB_GLASS_DATA_REQUEST = _main.SCANCONTEROLS.GetProperty(_controlName, "IB_GLASS_DATA_REQUEST");
            IW_GLASS_DATA_REQUEST_REPLY_REPLY_STATUS = _main.SCANCONTEROLS.GetProperty(_controlName, "IW_GLASS_DATA_REQUEST_REPLY_REPLY_STATUS");
            IW_GLASS_DATA_REQUEST_REPLY_JOB_DATAA = _main.SCANCONTEROLS.GetProperty(_controlName, "IW_GLASS_DATA_REQUEST_REPLY_JOB_DATAA");
            //PROBE CIM
            OB_GLASS_DATA_REQUEST = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_GLASS_DATA_REQUEST");
            OW_GLASS_DATA_REQUEST_LOTID = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_GLASS_DATA_REQUEST_LOTID");
            OW_GLASS_DATA_REQUEST_GLASSID = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_GLASS_DATA_REQUEST_GLASSID");
            OW_GLASS_DATA_REQUEST_GLASS_TYPE = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_GLASS_DATA_REQUEST_GLASS_TYPE");
            VI_LOST_GLASS_DATA_REQUEST = _main._YANSYS_SCANCONTEROLS.GetProperty(_controlName, "VI_LOST_GLASS_DATA_REQUEST");

            _component.ProgramsAdd(this);
            return 0;
        }

        public override int AddArgs(object[] args, bool beforeClear)
        {
            if (args == null || args.Length < 2)
                return -1;

            if ((args[0] is CMain && args[1] is CProbeControl && args[1] is CProbeControl) == false)
            {
                return -1;
            }

            if (beforeClear)
            {

            }

            _main = args[0] as CMain;
            _component = args[1] as CProbeControl;
            _controlName = _component.ControlName;
            return 0;
        }
        public override string Name
        {
            get { return "GLASS_DATA_REQUEST"; }
        }

        public override string Version
        {
            get { return "ver 1.0"; }
        }

        public override string Description
        {
            get { return "장비 RECIPE 변경 REPORT 처리 프로그램"; }
        }
        public override bool Enable
        {
            get { return _enable; }
        }
        public override string Development
        {
            get { return "(주)서진정보기술"; }
        }

        public override bool IsCycle
        {
            get { return false; }
        }
        public override string SIteName
        {
            get { return "WHTM"; }
        }
        public override bool IsAsyncCall
        {
            get { return true; }
        }
        private const int T1 = 4000;
        protected override int InnerExecute()
        {
            int requestOption = 0;
            int glassType = 0;
            string id1 = "";
            string id2 = "";
            string lotId = "";
            string value = "";
            if (_isManualMode)
            {
                if (_values.ContainsKey("REQ_OPTION") == false || _values.ContainsKey("GLS_CODE") == false || _values.ContainsKey("GLS_ID") == false)
                {
                    return -1;
                }
                int.TryParse(_values["REQ_OPTION"], out glassType);
                lotId = _values["GLS_CODE"];
                id1 = _values["GLS_ID"];
            }
            else
            {
                value = VI_LOST_GLASS_DATA_REQUEST.Value;
                string[] temp1 = value.Split('|');
                if (temp1.Length != 3)
                    return -1;
                requestOption = (temp1[1] == "P") ? 2 : 1;
                if (requestOption == 2)
                {
                    string[] temp2 = temp1[2].Split(',');
                    if (temp2.Length < 2)
                        return -1;
                    int.TryParse(temp2[0], out glassType);
                    lotId = temp2[1].Trim();
                }
                else if (requestOption == 1)
                {
                    string[] temp2 = temp1[2].Split(',');
                    if (temp2.Length < 2)
                        return -1;
                    int.TryParse(temp2[0], out glassType);

                    if (glassType == 0)//0 WHOLE, 1 HALF
                    {
                        id1 = temp2[1].Trim();
                    }
                    else
                    {
                        id1 = temp2[1].Trim();
                        id2 = temp2[2].Trim();

                        if (string.IsNullOrEmpty(id1))
                        {
                            id1 = id2;
                        }
                    }
                }
                else
                {
                    return -1;
                }     
            }
            //PROBE CIM
            _main.MelsecNetMultiWordWriteByString(OW_GLASS_DATA_REQUEST_LOTID, lotId, 10, ' ');
            _main.MelsecNetMultiWordWriteByString(OW_GLASS_DATA_REQUEST_GLASSID, id1, 10, ' ');

            _main.MelsecNetWordWrite(OW_GLASS_DATA_REQUEST_GLASS_TYPE, glassType);

            //_main.MelsecNetBitOnOff(OB_GLASS_DATA_REQUEST, true);
            Log(string.Format("{0}\t{1}", _component.ControlName, string.Format("PGM DATA SEND - LOTID={0} GLASSID={1} GLASSTYPE={2}", lotId, id1, glassType)));        

            //CSubject subject = CUIManager.Inst.GetData("ucCimStatus");
            //subject.SetValue("EQPSTATUS", _component.MachineAutoMode);
            //subject.Notify();

            //Thread.Sleep(1000);
            //_main.MelsecNetBitOnOff(OB_GLASS_DATA_REQUEST, false);
            
            CTimeout timeout = CTimeoutManager.GetTimeout(_controlName, T1);
            timeout.TargetOffValueCheck = true;
            timeout.Begin(OB_GLASS_DATA_REQUEST, _main.CONTROLATTRIBUTES.GetProperty(IB_GLASS_DATA_REQUEST.ControlName, IB_GLASS_DATA_REQUEST.AttributeName) as ITimeoutResource);

            _main.MelsecNetBitOnOff(OB_GLASS_DATA_REQUEST, true);
            Thread.Sleep(1000);
            IB_GLASS_DATA_REQUEST.Value = true.ToString();

            string tempMsg = "";
            bool error = false;
            if (CTimeout.WaitSync(timeout, 10))
            {
                string replyTemp = _main.MelsecNetWordRead(IW_GLASS_DATA_REQUEST_REPLY_REPLY_STATUS);
                int glassExist = int.Parse(replyTemp);
                Log(string.Format("{0}\t{1}", _component.ControlName, "PGM DATA RECV - GLASS EXIST={0}", replyTemp));
                if (glassExist == REPLY_EXIST)
                {
                    ushort[] data = _main.MelsecNetMultiWordRead(IW_GLASS_DATA_REQUEST_REPLY_JOB_DATAA);
                    CGlassDataPropertiesWHTM jobDataA = new CGlassDataPropertiesWHTM(data);
                    //CGlassDataPropertiesWHTM jobDataB = new CGlassDataPropertiesWHTM(data);
                    Log(string.Format("{0}\t{1}", _component.ControlName, "PGM DATA RECV - GLASS DATA {0}", jobDataA.ToString()));

                    CSubject subject = null;
                    bool noGlass1 = false;
                    bool noGlass2 = false;
                    bool halfSize1 = false;
                    bool halfSize2 = false;
                    bool whole = false;
                    List<bool> glassSizeType = new List<bool>();

                    subject = CUIManager.Inst.GetData("ucEQP");
                    if (!IsManualExecute)
                    {
                        string cstIndex1 = "";
                        string portNo1 = "";
                        string seqNo1 = "";
                        string glassIndex1 = "";
                        string position1 = "";
                        string slotNo1 = "";
                        string glassId1 = "";
                        string lotId1 = "";
                        string glassType1 = "";
                        string ppid1 = "";
                        string recipeId1 = "";
                        string prodId1 = "";
                        string stepid1 = "";
                        string cstid1 = "";

                        string cstIndex2 = "";
                        string portNo2 = "";
                        string seqNo2 = "";
                        string glassIndex2 = "";
                        string position2 = "";
                        string slotNo2 = "";
                        string glassId2 = "";
                        string lotId2 = "";
                        string glassType2 = "";
                        string ppid2 = "";
                        string recipeId2 = "";
                        string prodId2 = "";
                        string stepid2 = "";
                        string cstid2 = "";

                        if (jobDataA != null && jobDataA.CassetteIndex != 0)
                        {


                            if (jobDataA.GlassPosition.ToString() == "1" || jobDataA.GlassPosition.ToString() == "3")
                            {
                                cstIndex1 = jobDataA.CassetteIndex.ToString();
                                portNo1 = jobDataA.PortNo.ToString();
                                seqNo1 = jobDataA.SeqNo.ToString();
                                glassIndex1 = jobDataA.GlassIndex.ToString();
                                position1 = jobDataA.GlassPosition.ToString();
                                slotNo1 = jobDataA.SlotNo.ToString();
                                glassId1 = jobDataA.GlassID;
                                lotId1 = jobDataA.LotID;
                                glassType1 = jobDataA.GlassType.ToString();
                                ppid1 = jobDataA.PPID;
                                recipeId1 = _main.getRecipeId(ppid1);
                                prodId1 = jobDataA.ProductId.ToString();
                                stepid1 = jobDataA.OperationId.ToString();
                                cstid1 = jobDataA.CassetteId;
                                jobDataA.ChangeLocation(_component.ControlName, "0");
                                _main.AddReceviedGlassData(_component.ControlName, jobDataA, 0, true);

                                subject.SetValue("RECIPE", _component.CurrentRecipeNo);
                                subject.SetValue("GlassCode1", jobDataA.GlassIndex.ToString());
                                subject.SetValue("GlassID1", jobDataA.GlassID);
                            }
                            else
                            {
                                cstIndex2 = jobDataA.CassetteIndex.ToString();
                                portNo2 = jobDataA.PortNo.ToString();
                                seqNo2 = jobDataA.SeqNo.ToString();
                                glassIndex2 = jobDataA.GlassIndex.ToString();
                                position2 = jobDataA.GlassPosition.ToString();
                                slotNo2 = jobDataA.SlotNo.ToString();
                                glassId2 = jobDataA.GlassID;
                                lotId2 = jobDataA.LotID;
                                glassType2 = jobDataA.GlassType.ToString();
                                ppid2 = jobDataA.PPID;
                                recipeId2 = _main.getRecipeId(ppid2);
                                prodId2 = jobDataA.ProductId.ToString();
                                stepid2 = jobDataA.OperationId.ToString();
                                cstid2 = jobDataA.CassetteId;
                                jobDataA.ChangeLocation(_component.ControlName, "1");
                                _main.AddReceviedGlassData(_component.ControlName, jobDataA, 1, true);

                                subject.SetValue("RECIPE", _component.CurrentRecipeNo);
                                subject.SetValue("GlassCode2", jobDataA.GlassIndex.ToString());
                                subject.SetValue("GlassID2", jobDataA.GlassID);
                            }
                            

                        }
                        else
                        {
                            noGlass1 = true;
                        }

                        //if (jobDataB != null && jobDataB.CassetteIndex != 0)
                        //{
                        //    cstIndex2 = jobDataB.CassetteIndex.ToString();
                        //    portNo2 = jobDataB.PortNo.ToString();
                        //    seqNo2 = jobDataB.SeqNo.ToString();
                        //    glassIndex2 = jobDataB.GlassIndex.ToString();
                        //    position2 = jobDataB.GlassPosition.ToString();
                        //    slotNo2 = jobDataB.SlotNo.ToString();
                        //    glassId2 = jobDataB.GlassID;
                        //    lotId2 = jobDataB.LotID;
                        //    glassType2 = jobDataB.GlassType.ToString();
                        //    ppid2 = jobDataB.PPID;
                        //    recipeId2 = _main.getRecipeId(ppid2);
                        //    prodId2 = jobDataB.ProductId.ToString();
                        //    stepid2 = jobDataB.OperationId.ToString();
                        //    jobDataB.ChangeLocation(_component.ControlName, "1");
                        //    _main.AddReceviedGlassData(_component.ControlName, jobDataB, 1, true);

                        //    subject.SetValue("RECIPE", _component.CurrentRecipeNo);
                        //    subject.SetValue("GlassCode2", jobDataB.GlassIndex.ToString());
                        //    subject.SetValue("GlassID2", jobDataB.GlassID);

                        //    if (position2 == "2")
                        //    {
                        //        halfSize2 = true;
                        //    }
                        //}
                        //else
                        //{
                        //    noGlass2 = true;
                        //}

                        //if (jobDataA == null && jobDataB != null)
                        //{
                        //    glassType1 = glassType2;
                        //}
                        if (jobDataA.GlassPosition == 3)
                        {
                            whole = true;
                            halfSize1 = false;

                            subject.SetValue("GlassExist_Whole", whole);
                            subject.SetValue("GlassExist_A", halfSize1);
                            subject.Notify();
                        }
                        else if (jobDataA.GlassPosition == 1)
                        {
                            whole = false;
                            halfSize1 = true;

                            subject.SetValue("GlassExist_Whole", whole);
                            subject.SetValue("GlassExist_A", halfSize1);
                            subject.Notify();
                        }
                        else if (jobDataA.GlassPosition == 2)
                        {
                            whole = false;
                            halfSize2 = true;

                            subject.SetValue("GlassExist_Whole", whole);
                            subject.SetValue("GlassExist_B", halfSize2);
                            subject.Notify();
                        }

                        subject = CUIManager.Inst.GetData("frmGlassDataWHTM");

                        if (jobDataA != null && jobDataA.CassetteIndex != 0)
                        {
                            if (jobDataA.GlassPosition ==1)
                            {
                                subject.SetValue("Data", CGlassDataPropertiesWHTM.GetGuiData(jobDataA));
                            }
                            else if (jobDataA.GlassPosition == 2)
                            {
                                subject.SetValue("Data2", CGlassDataPropertiesWHTM.GetGuiData(jobDataA));
                            }
                            else
                            {
                                subject.SetValue("Data", CGlassDataPropertiesWHTM.GetGuiData(jobDataA));
                                subject.SetValue("Data2", CGlassDataPropertiesWHTM.GetClearData());
                            }
                            
                        }
                        //if (jobDataB != null && jobDataB.CassetteIndex != 0)
                        //{
                        //    data2 = CGlassDataPropertiesWHTM.GetGuiData(jobDataB);
                        //    subject.SetValue("Data2", data2);
                        //}
                        subject.Notify();

                        //20161125

                        CGlassDataPropertiesWHTM glassData1 = null;
                        CGlassDataPropertiesWHTM glassData2 = null;
                        AMaterialData materialData1 = null;
                        AMaterialData materialData2 = null;
                        materialData1 = _main.GetReceivedGlassDataByLoc(_component.ControlName, 0);
                        glassData1 = materialData1 as CGlassDataPropertiesWHTM;
                        materialData2 = _main.GetReceivedGlassDataByLoc(_component.ControlName, 1);
                        glassData2 = materialData2 as CGlassDataPropertiesWHTM;

                        if (glassData1 == null)
                            glassData1 = new CGlassDataPropertiesWHTM();

                        if (glassData2 == null)
                            glassData2 = new CGlassDataPropertiesWHTM();
                        

                        List<string> dataList = new List<string>();
                        string tempData2 = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19}", glassData1.PortNo, glassData1.SeqNo, glassData1.GlassPosition, glassData1.SlotNo, glassData1.GlassID, glassData1.LotID, _main.getRecipeId(glassData1.PPID), glassData1.OperationId, glassData1.ProductId, glassData1.CassetteId, glassData2.PortNo, glassData2.SeqNo, glassData2.GlassPosition, glassData2.SlotNo, glassData2.GlassID, glassData2.LotID, _main.getRecipeId(glassData2.PPID), glassData2.OperationId, glassData2.ProductId, glassData2.CassetteId);

                        dataList.Add("LOST_GLASS_DATA_REQUEST_ACK");
                        dataList.Add(glassData1.GlassID != "" || glassData2.GlassID != "" ? "O" : "X");
                        dataList.Add(tempData2);


                        //List<string> dataList = new List<string>();
                        //string tempData2 = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19}", portNo1, seqNo1, position1, slotNo1, glassId1, lotId1, recipeId1, stepid1, prodId1, cstid1, portNo2, seqNo2, position2, slotNo2, glassId2, lotId2, recipeId2, stepid2, prodId2, cstid2);

                        //dataList.Add("LOST_GLASS_DATA_REQUEST_ACK");
                        //dataList.Add(jobDataA != null && jobDataA.CassetteIndex != 0 ? "O" : "X");
                        //dataList.Add(tempData2);

                        _main.SendData(dataList);
                    }

                }
                else
                {
                    if (!IsManualExecute)
                    {
                        List<string> dataList = new List<string>();
                        string tempData2 = "".PadLeft(19, ','); //PORTNO,SEQNO,GLASSTYPE,SLOTNO,GLASS_ID,LOT_ID,PPID,RECIPEID,PORTNO,SEQNO,GLASSTYPE,SLOTNO,GLASS_ID,LOT_ID,PPID,RECIPEID

                        dataList.Add("LOST_GLASS_DATA_REQUEST_ACK");
                        dataList.Add("X");
                        dataList.Add(tempData2);

                        _main.SendData(dataList);
                    }
                }

                _main.MelsecNetBitOnOff(OB_GLASS_DATA_REQUEST, false);
            }
            else
            {
                error = true;
                _main.MelsecNetBitOnOff(OB_GLASS_DATA_REQUEST, false);
                tempMsg = string.Format("PGM DATA TIMEOUT No response [timeout T1={0} sec]", T1 / 1000);
                Log(string.Format("{0}\t{1}", _component.ControlName, tempMsg));
            }

            if (!error)
                return 0;
            Log(string.Format("{0}\t{1}", _component.ControlName, "PGM DATA DISPLAY"));

            
            #region 메시지 창 표시
            CSubject msgSubject = null;
            string receivedTime = DateTime.Now.ToString("yyyyMMdd HH:mm:ss");
            string msgId = "0";
            string message = string.Format("[{0}] {1}", this.Name, tempMsg);
            string panelNo = "1";

            msgSubject = CUIManager.Inst.GetData("CIMMessage");
            msgSubject.SetValue("List", new List<string>() { "MESSAGE_SET", msgId, receivedTime, message, panelNo });
            msgSubject.Notify();

            #endregion
            return 0;
        }
        
        public override int ExecuteManual(Dictionary<string, string> values)
        {
            _isManualMode = true;
            _values = values;
            return this.InnerExecute();
        }
        
    }
}
