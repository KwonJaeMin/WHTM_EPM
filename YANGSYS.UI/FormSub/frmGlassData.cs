using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SOFD.Global.Manager;

using SOFD.Logger;
using YANGSYS.UI.WHTM.LogFormat;
using SOFD.Global.Interface;

namespace YANGSYS.UI.WHTM
{
    public partial class frmGlassData : Form
    {
        public frmGlassData()
        {
            InitializeComponent();
            Init();
            //_updateHandler = new CUIDataUpdate<Dictionary<string, string>>(this, "frmGlassData", this.Data, new CUIDataUpdate<ushort[]>.UIUpdateHandler(UpdateGlassData));
            //_updateHandler.Init();
        }

        private void btnGlassDataRequest_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Please be sure to select the Request Option", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string[] temp = comboBox1.Text.Split(':');

                if (temp[0] == "1" && string.IsNullOrEmpty(textBox2.Text))
                {
                    MessageBox.Show("Please be sure to select the Glass ID", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (temp[0] == "2" && string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("Please be sure to select the Glass Code", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Log_Convert("UI", string.Format("{0} {1} {2}", "GlassDataRequest_Click", comboBox1.Text, temp[0] == "1" ? textBox1.Text.Trim() : textBox2.Text.Trim()));

                Dictionary<string, string> values = new Dictionary<string, string>();

                ACommand command = CUIManager.Inst.GetCommand("REQUEST");

                command.SubCommandName = "GLASS_DATA_REQUEST";
                values.Add("REQ_OPTION", temp[0]);
                values.Add("GLS_CODE", textBox1.Text.Trim());
                values.Add("GLS_ID", textBox2.Text.Trim());
                command.Execute(values);
                
            }
            catch (Exception ex)
            {
                CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, CExceptionLogFormat.DEFAULT_KEY, ex));
            }
        }

        private void Log_Convert(string LogType, string strMsg)
        {
            switch (LogType)
            {
                case "UI":
                    CLogManager.Instance.Log(new CUILogFormat(Catagory.Info, "frmGlassData", strMsg, ""));
                    break;
            }
        }

        internal void RefreshDgvList(Dictionary<string, string> temp)
        {
            try
            {
                //ucGlassData1.LotID = temp["LotID"];
                //ucGlassData1.GlassID = temp["GlassID"];
                ////ucGlassData1.OperID = temp["OperID"];
                //ucGlassData1.GlassCodeXXYYYYZZZ = temp["GlassCode"];
                //ucGlassData1.GlassCodeXXYYYY = temp["GlassCodeXXYYYY"];
                //ucGlassData1.GlassCodeZZZ = temp["GlassCodeZZZ"];
                //ucGlassData1.GlassJudgeCode = temp["GlassJudgeCode"];
                //ucGlassData1.PPID = temp["PPID"];
                //ucGlassData1.ProdID = temp["ProdID"];
                //ucGlassData1.CIMPCData1 = temp["CIMPCData1"];
                //ucGlassData1.CIMPCData2 = temp["CIMPCData2"];
                //ucGlassData1.ProcFlag1 = temp["ProcFlag1"];
                //ucGlassData1.ProcFlag2 = temp["ProcFlag2"];
                //ucGlassData1.JudgeFlag1 = temp["JudgeFlag1"];
                //ucGlassData1.JudgeFlag2 = temp["JudgeFlag2"];
                //ucGlassData1.SkipFlag1 = temp["SkipFlag1"];
                //ucGlassData1.SkipFlag2 = temp["SkipFlag2"];
                //ucGlassData1.InspectionFlag1 = temp["InspectionFlag1"];
                //ucGlassData1.InspectionFlag2 = temp["InspectionFlag2"];
                //ucGlassData1.Mode = temp["Mode"];
                //ucGlassData1.GlassType1 = temp["GlassType1"];
                //ucGlassData1.GlassType2 = temp["GlassType2"];
                //ucGlassData1.DummyType = temp["DummyType"];
                //ucGlassData1.ReservedData1 = temp["ReservedData1"];
                //ucGlassData1.ReservedData2 = temp["ReservedData2"];
                //ucGlassData1.ReservedData3 = temp["ReservedData3"];
                //ucGlassData1.ReservedData4 = temp["ReservedData4"];
                //ucGlassData1.ReservedData5 = temp["ReservedData5"];
                //ucGlassData1.ReservedData6 = temp["ReservedData6"];
            }
            catch (Exception ex)
            {
                CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, CExceptionLogFormat.DEFAULT_KEY, ex));
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> newData = GetDisplayData();

            ACommand command = CUIManager.Inst.GetCommand("REQUEST");
            command.SubCommandName = "GLASS_DATA_MODIFY";
            command.Execute<Dictionary<string, string>>(newData);
        }

        private Dictionary<string, string> GetDisplayData()
        {
            Dictionary<string, string> newData = new Dictionary<string,string>();
            newData.Add("LotID", ucGlassData1.LotID);
            newData.Add("GlassID", ucGlassData1.GlassID);
            newData.Add("OperID", ucGlassData1.OperID);
            newData.Add("GlassCodeXXYYYY", ucGlassData1.GlassCodeXXYYYY);
            newData.Add("GlassCodeZZZ", ucGlassData1.GlassCodeZZZ);
            newData.Add("GlassJudgeCode", ucGlassData1.GlassJudgeCode);
            newData.Add("PPID", ucGlassData1.PPID);
            newData.Add("ProdID", ucGlassData1.ProdID);
            newData.Add("CIMPCData1", ucGlassData1.CIMPCData1);
            newData.Add("CIMPCData2", ucGlassData1.CIMPCData2);
            newData.Add("ProcFlag1", ucGlassData1.ProcFlag1);
            newData.Add("ProcFlag2", ucGlassData1.ProcFlag2);
            newData.Add("JudgeFlag1", ucGlassData1.JudgeFlag1);
            newData.Add("JudgeFlag2", ucGlassData1.JudgeFlag2);
            newData.Add("SkipFlag1", ucGlassData1.SkipFlag1);
            newData.Add("SkipFlag2", ucGlassData1.SkipFlag2);
            newData.Add("InspectionFlag1", ucGlassData1.InspectionFlag1);
            newData.Add("InspectionFlag2", ucGlassData1.InspectionFlag2);
            newData.Add("Mode", ucGlassData1.Mode);
            newData.Add("GlassType1", ucGlassData1.GlassType1);
            newData.Add("GlassType2", ucGlassData1.GlassType2);
            newData.Add("DummyType", ucGlassData1.DummyType);
            newData.Add("ReservedData1", ucGlassData1.ReservedData1);
            newData.Add("ReservedData2", ucGlassData1.ReservedData2);
            newData.Add("ReservedData3", ucGlassData1.ReservedData3);
            newData.Add("ReservedData4", ucGlassData1.ReservedData4);
            newData.Add("ReservedData5", ucGlassData1.ReservedData5);
            newData.Add("ReservedData6", ucGlassData1.ReservedData6);

            return newData;
        }

        private void frmGlassData_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void btnReceve_Click(object sender, EventArgs e)
        {
            ACommand command = CUIManager.Inst.GetCommand("REQUEST");
            command.SubCommandName = "READ_RECEIVED_GLASSDATA";
            command.Execute();
        }

        private void btnProc_Click(object sender, EventArgs e)
        {
            ACommand command = CUIManager.Inst.GetCommand("REQUEST");
            command.SubCommandName = "READ_PROCESSING_GLASSDATA";
            command.Execute();
        }

        private void btnSentOut_Click(object sender, EventArgs e)
        {
            ACommand command = CUIManager.Inst.GetCommand("REQUEST");
            command.SubCommandName = "READ_SENTOUT_GLASSDATA";
            command.Execute();
        }

        #region GlassInfoDisplay

        public bool Init()
        {
            //base.Init();

            UpdateGlassInfoDisplayHandler = new CUpdateHandler<CGlassInfoDisplayData>(this, "frmGlassData", ref _glassInfoDisplayData);
            UpdateGlassInfoDisplayHandler.OnUpdateData = new CUpdateHandler<CGlassInfoDisplayData>.UpdateDataHandler(InvokeUpdateGlassData);
            UpdateGlassInfoDisplayHandler.Subscribe();
            return true;
        }

        private class CGlassInfoDisplayData
        {
            public Dictionary<string, string> Data { get; set; }

            public CGlassInfoDisplayData()
            {
                Data = new Dictionary<string, string>();
            }
            public bool SetValue<T>(string key, T value)
            {
                return true;
            }
        }
        private CGlassInfoDisplayData _glassInfoDisplayData = new CGlassInfoDisplayData();
        CUpdateHandler<CGlassInfoDisplayData> UpdateGlassInfoDisplayHandler = null;
        private delegate void UpdateHandler2();
        private void InvokeUpdateGlassData(bool noHandle, CGlassInfoDisplayData data)
        {
            if (data == null)
                return;

            UpdateGlassInfoDisplayHandler.Data = data;
            ////if (noHandle == false)
            ////{
            //if (this.InvokeRequired)
            //{
            //    this.Invoke(UpdateMessageHandler.OnUpdateData, noHandle, data);
            //}
            //else
            //{
            //    UpdateHandler2 del = new UpdateHandler2(ShowGlassInfoForm);
            //    this.Invoke(del);
            //}
            ////}

            this.RefreshDgvList(data.Data);
        }
        #endregion
        //private CUIDataUpdate<Dictionary<string, string>> _updateHandler = null;

        //public Dictionary<string, string> Data = new Dictionary<string, string>();
        //public class CUIDataUpdate<T>
        //{
        //    public delegate void UIUpdateHandler();
 
        //    public CUpdateHandler<T> UpdateHandler = null;
        //    public  T Data = default(T);

        //    private Control _owner = null;
        //    private string _elementId = "";
        //    private Delegate _callBackMethod = null;
        //    public CUIDataUpdate(Control owner, string elementId, T data, Delegate callBackMethod)
        //    {
        //        _owner = owner;
        //        _elementId = elementId;
        //        Data = data;
        //    }
        //    public bool Init()
        //    {
        //        UpdateHandler = new CUpdateHandler<T>(_owner, _elementId, ref Data);
        //        UpdateHandler.OnUpdateData = new CUpdateHandler<T>.UpdateDataHandler(InvokeUpdate);
        //        UpdateHandler.Subscribe();
        //        return true;
        //    }

        //    private void InvokeUpdate(bool noHandle, T data)
        //    {
        //        if (data == null)
        //            return;
        //        UpdateHandler.Data = data;
        //        _owner.Invoke(_callBackMethod);
        //    }
        //}

        //private void UpdateGlassData()
        //{
        //    this.RefreshDgvList(_updateHandler.Data);
        //}
    }
}
