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
    public partial class frmGlassDataWHTM : Form
    {
        public frmGlassDataWHTM()
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

                if (string.IsNullOrEmpty(comboBox1.Text))
                {
                    MessageBox.Show("Please be sure to select the Glass Type", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (string.IsNullOrEmpty(textBox1.Text) && string.IsNullOrEmpty(textBox2.Text))
                {
                    MessageBox.Show("Please be sure to select the Glass ID or Lot ID", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Log_Convert("UI", string.Format("{0} {1} {2} {3}", "GlassDataRequest_Click", comboBox1.Text, textBox1.Text.Trim(), textBox2.Text.Trim()));

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
                    CLogManager.Instance.Log(new CUILogFormat(Catagory.Info, "frmGlassDataWHTM", strMsg, ""));
                    break;
            }
        }

        internal void RefreshDgvList(List<Dictionary<string, string>> Temp, int glassCount)
        {
            try
            {
                if (Temp.Count > 0 && Temp[0] != null && Temp[0].Count > 0)
                {
                    ucGlassDataWHTM1.CassetteIndex = Temp[0]["CassetteIndex"];
                    ucGlassDataWHTM1.GlassIndex = Temp[0]["GlassIndex"];
                    ucGlassDataWHTM1.ProductCode = Temp[0]["ProductCode"];
                    ucGlassDataWHTM1.GlassThickness = Temp[0]["GlassThickness"];
                    ucGlassDataWHTM1.LotID = Temp[0]["LotID"];
                    ucGlassDataWHTM1.GlassID = Temp[0]["GlassID"];
                    ucGlassDataWHTM1.PPID = Temp[0]["PPID"];
                    ucGlassDataWHTM1.GlassType = Temp[0]["GlassType"];
                    ucGlassDataWHTM1.JobJudge = Temp[0]["JobJudge"];
                    ucGlassDataWHTM1.JobGrade = Temp[0]["JobGrade"];
                    ucGlassDataWHTM1.JobState = Temp[0]["JobState"];
                    ucGlassDataWHTM1.TrackingData = Temp[0]["TrackingData"];
                    ucGlassDataWHTM1.UnitPathNo = Temp[0]["UnitPathNo"];
                    ucGlassDataWHTM1.SlotNo = Temp[0]["SlotNo"];
                    ucGlassDataWHTM1.CycleTime = Temp[0]["CycleTime"];
                    ucGlassDataWHTM1.TactTime = Temp[0]["TactTime"];
                    ucGlassDataWHTM1.ReasonCode = Temp[0]["ReasonCode"];
                    ucGlassDataWHTM1.SamplingFlag = Temp[0]["SamplingFlag"];
                    ucGlassDataWHTM1.LotEndFlag = Temp[0]["LotEndFlag"];
                    ucGlassDataWHTM1.OperationId = Temp[0]["OperationId"];
                    ucGlassDataWHTM1.ProductId = Temp[0]["ProductId"];
                    ucGlassDataWHTM1.CassetteId = Temp[0]["CassetteId"];
                    ucGlassDataWHTM1.Reserved1 = Temp[0]["Reserved1"];
                }
                if (Temp.Count > 1 && Temp[1] != null && Temp[1].Count > 0)
                {
                    ucGlassDataWHTM2.CassetteIndex = Temp[1]["CassetteIndex"];
                    ucGlassDataWHTM2.GlassIndex = Temp[1]["GlassIndex"];
                    ucGlassDataWHTM2.ProductCode = Temp[1]["ProductCode"];
                    ucGlassDataWHTM2.GlassThickness = Temp[1]["GlassThickness"];
                    ucGlassDataWHTM2.LotID = Temp[1]["LotID"];
                    ucGlassDataWHTM2.GlassID = Temp[1]["GlassID"];
                    ucGlassDataWHTM2.PPID = Temp[1]["PPID"];
                    ucGlassDataWHTM2.GlassType = Temp[1]["GlassType"];
                    ucGlassDataWHTM2.JobJudge = Temp[1]["JobJudge"];
                    ucGlassDataWHTM2.JobGrade = Temp[1]["JobGrade"];
                    ucGlassDataWHTM2.JobState = Temp[1]["JobState"];
                    ucGlassDataWHTM2.TrackingData = Temp[1]["TrackingData"];
                    ucGlassDataWHTM2.UnitPathNo = Temp[1]["UnitPathNo"];
                    ucGlassDataWHTM2.SlotNo = Temp[1]["SlotNo"];
                    ucGlassDataWHTM2.CycleTime = Temp[1]["CycleTime"];
                    ucGlassDataWHTM2.TactTime = Temp[1]["TactTime"];
                    ucGlassDataWHTM2.ReasonCode = Temp[1]["ReasonCode"];
                    ucGlassDataWHTM2.SamplingFlag = Temp[1]["SamplingFlag"];
                    ucGlassDataWHTM2.LotEndFlag = Temp[1]["LotEndFlag"];
                    ucGlassDataWHTM2.OperationId = Temp[1]["OperationId"];
                    ucGlassDataWHTM2.ProductId = Temp[1]["ProductId"];
                    ucGlassDataWHTM2.CassetteId = Temp[1]["CassetteId"];
                    ucGlassDataWHTM2.Reserved1 = Temp[1]["Reserved1"];
                }
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

            newData.Add("CassetteIndex", ucGlassDataWHTM1.CassetteIndex);
            newData.Add("GlassIndex", ucGlassDataWHTM1.GlassIndex);
            newData.Add("ProductCode", ucGlassDataWHTM1.ProductCode);
            newData.Add("GlassThickness", ucGlassDataWHTM1.GlassThickness);
            newData.Add("LotID", ucGlassDataWHTM1.LotID);
            newData.Add("GlassID", ucGlassDataWHTM1.GlassID);
            newData.Add("PPID", ucGlassDataWHTM1.PPID);
            newData.Add("GlassType", ucGlassDataWHTM1.GlassType);
            newData.Add("JobJudge", ucGlassDataWHTM1.JobJudge);
            newData.Add("JobGrade", ucGlassDataWHTM1.JobGrade);
            newData.Add("JobState", ucGlassDataWHTM1.JobState);
            newData.Add("TrackingData", ucGlassDataWHTM1.TrackingData);
            newData.Add("UnitPathNo", ucGlassDataWHTM1.UnitPathNo);
            newData.Add("SlotNo", ucGlassDataWHTM1.SlotNo);
            newData.Add("CycleTime", ucGlassDataWHTM1.CycleTime);
            newData.Add("TactTime", ucGlassDataWHTM1.TactTime);
            newData.Add("ReasonCode", ucGlassDataWHTM1.ReasonCode);
            newData.Add("SamplingFlag", ucGlassDataWHTM1.SamplingFlag);
            newData.Add("LotEndFlag", ucGlassDataWHTM1.LotEndFlag);
            newData.Add("OperationId", ucGlassDataWHTM1.OperationId);
            newData.Add("ProductId", ucGlassDataWHTM1.ProductId);
            newData.Add("CassetteId", ucGlassDataWHTM1.CassetteId);
            newData.Add("Reserved1", ucGlassDataWHTM1.Reserved1);
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

            UpdateGlassInfoDisplayHandler = new CUpdateHandler<CGlassInfoDisplayData>(this, "frmGlassDataWHTM", ref _glassInfoDisplayData);
            UpdateGlassInfoDisplayHandler.OnUpdateData = new CUpdateHandler<CGlassInfoDisplayData>.UpdateDataHandler(InvokeUpdateGlassData);
            UpdateGlassInfoDisplayHandler.Subscribe();
            return true;
        }

        private class CGlassInfoDisplayData
        {
            public int GlassCount { get; set; }
            public Dictionary<string, string> Data { get; set; }
            public Dictionary<string, string> Data2 { get; set; }

            public CGlassInfoDisplayData()
            {
                GlassCount = 1;
                Data = new Dictionary<string, string>();
                Data2 = new Dictionary<string, string>();
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

            this.RefreshDgvList(new List<Dictionary<string, string>>() { data.Data, data.Data2 }, data.GlassCount);
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> newData = GetDisplayData();

            ACommand command = CUIManager.Inst.GetCommand("REQUEST");
            command.SubCommandName = "JOB_JUDGE_CHANGE";
            command.Execute<Dictionary<string, string>>(newData);
        }
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
