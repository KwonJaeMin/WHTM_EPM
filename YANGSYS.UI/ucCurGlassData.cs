using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SOFD.Gui.Widget;

using SOFD.Global.Manager;

namespace YANGSYS.UI.WHTM
{
    public partial class ucCurGlassData : UCBaseObject
    {
        public ucCurGlassData()
        {
            InitializeComponent();
        }

        public class CGlassData
        {
            public int GlassCount { get; set; }
            public Dictionary<string, string> Data { get; set; }
            public Dictionary<string, string> Data2 { get; set; }

            public CGlassData()
            {
                GlassCount = 2;
                Data = new Dictionary<string, string>();
                Data2 = new Dictionary<string, string>();
            }
            public bool SetValue<T>(string key, T value)
            {
                return true;
            }
        }

        CUpdateHandler<CGlassData> UpdateHandler = null;
        CGlassData _GlassData = new CGlassData();
        public override bool Init()
        {
            base.Init();

            UpdateHandler = new CUpdateHandler<CGlassData>(this, "ucGlassData", ref _GlassData);
            UpdateHandler.OnUpdateData = new CUpdateHandler<CGlassData>.UpdateDataHandler(InvokeUpdateData);
            UpdateHandler.Subscribe();

            return true;
        }

        private void InvokeUpdateData(bool noHandle, CGlassData ucUpdateGlassData)
        {
            if (ucUpdateGlassData == null)
                return;

            UpdateHandler.Data = ucUpdateGlassData;

            if (ucUpdateGlassData.Data.Count == 23)
            {

                ucGlassDataWHTM1.CassetteIndex = ucUpdateGlassData.Data["CassetteIndex"];
                ucGlassDataWHTM1.GlassIndex = ucUpdateGlassData.Data["GlassIndex"];
                ucGlassDataWHTM1.ProductCode = ucUpdateGlassData.Data["ProductCode"];
                ucGlassDataWHTM1.GlassThickness = ucUpdateGlassData.Data["GlassThickness"];
                ucGlassDataWHTM1.LotID = ucUpdateGlassData.Data["LotID"];
                ucGlassDataWHTM1.GlassID = ucUpdateGlassData.Data["GlassID"];
                ucGlassDataWHTM1.PPID = ucUpdateGlassData.Data["PPID"];
                ucGlassDataWHTM1.GlassType = ucUpdateGlassData.Data["GlassType"];
                ucGlassDataWHTM1.JobJudge = ucUpdateGlassData.Data["JobJudge"];
                ucGlassDataWHTM1.JobGrade = ucUpdateGlassData.Data["JobGrade"];
                ucGlassDataWHTM1.JobState = ucUpdateGlassData.Data["JobState"];
                ucGlassDataWHTM1.TrackingData = ucUpdateGlassData.Data["TrackingData"];
                ucGlassDataWHTM1.UnitPathNo = ucUpdateGlassData.Data["UnitPathNo"];
                ucGlassDataWHTM1.SlotNo = ucUpdateGlassData.Data["SlotNo"];
                ucGlassDataWHTM1.CycleTime = ucUpdateGlassData.Data["CycleTime"];
                ucGlassDataWHTM1.TactTime = ucUpdateGlassData.Data["TactTime"];
                ucGlassDataWHTM1.ReasonCode = ucUpdateGlassData.Data["ReasonCode"];
                ucGlassDataWHTM1.SamplingFlag = ucUpdateGlassData.Data["SamplingFlag"];
                ucGlassDataWHTM1.LotEndFlag = ucUpdateGlassData.Data["LotEndFlag"];
                ucGlassDataWHTM1.OperationId = ucUpdateGlassData.Data["OperationId"];
                ucGlassDataWHTM1.ProductId = ucUpdateGlassData.Data["ProductId"];
                ucGlassDataWHTM1.CassetteId = ucUpdateGlassData.Data["CassetteId"];
                ucGlassDataWHTM1.Reserved1 = ucUpdateGlassData.Data["Reserved1"];
            }

            if (ucUpdateGlassData.Data2.Count == 23)
            {

                ucGlassDataWHTM2.CassetteIndex = ucUpdateGlassData.Data2["CassetteIndex"];
                ucGlassDataWHTM2.GlassIndex = ucUpdateGlassData.Data2["GlassIndex"];
                ucGlassDataWHTM2.ProductCode = ucUpdateGlassData.Data2["ProductCode"];
                ucGlassDataWHTM2.GlassThickness = ucUpdateGlassData.Data2["GlassThickness"];
                ucGlassDataWHTM2.LotID = ucUpdateGlassData.Data2["LotID"];
                ucGlassDataWHTM2.GlassID = ucUpdateGlassData.Data2["GlassID"];
                ucGlassDataWHTM2.PPID = ucUpdateGlassData.Data2["PPID"];
                ucGlassDataWHTM2.GlassType = ucUpdateGlassData.Data2["GlassType"];
                ucGlassDataWHTM2.JobJudge = ucUpdateGlassData.Data2["JobJudge"];
                ucGlassDataWHTM2.JobGrade = ucUpdateGlassData.Data2["JobGrade"];
                ucGlassDataWHTM2.JobState = ucUpdateGlassData.Data2["JobState"];
                ucGlassDataWHTM2.TrackingData = ucUpdateGlassData.Data2["TrackingData"];
                ucGlassDataWHTM2.UnitPathNo = ucUpdateGlassData.Data2["UnitPathNo"];
                ucGlassDataWHTM2.SlotNo = ucUpdateGlassData.Data2["SlotNo"];
                ucGlassDataWHTM2.CycleTime = ucUpdateGlassData.Data2["CycleTime"];
                ucGlassDataWHTM2.TactTime = ucUpdateGlassData.Data2["TactTime"];
                ucGlassDataWHTM2.ReasonCode = ucUpdateGlassData.Data2["ReasonCode"];
                ucGlassDataWHTM2.SamplingFlag = ucUpdateGlassData.Data2["SamplingFlag"];
                ucGlassDataWHTM2.LotEndFlag = ucUpdateGlassData.Data2["LotEndFlag"];
                ucGlassDataWHTM2.OperationId = ucUpdateGlassData.Data2["OperationId"];
                ucGlassDataWHTM2.ProductId = ucUpdateGlassData.Data2["ProductId"];
                ucGlassDataWHTM2.CassetteId = ucUpdateGlassData.Data2["CassetteId"];
                ucGlassDataWHTM2.Reserved1 = ucUpdateGlassData.Data2["Reserved1"];
            }
        }
    }
}
