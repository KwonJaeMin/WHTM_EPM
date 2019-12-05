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


namespace Widgets
{
    public partial class ucPort : UCBaseObject
    {
        public ucPort()
        {
            InitializeComponent();
        }
        public ucPort(Size size, Point location)
            : this()
        {
            this.Size = size;
            this.Location = location;
        }

        public void cstTypeChange(string value)
        {
            if (value == "1")
            {
                lblCSTType.Text = "A";
            }
            else
            {
                lblCSTType.Text = "E";
            }
        }

        public void portNoChange(string value)
        {
            switch (value)
            {
                case "INDEXER_PORT01":
                    lblPortNo.Text = "1";
                    break;
                case "INDEXER_PORT02":
                    lblPortNo.Text = "2";
                    break;
                default :
                    lblPortNo.Text = "N";
                    break;
            }
        }

        public void cstIDChange(string value)
        {
            lblCstid.Text = value;
        }

        public void LotIDChange(string value)
        {
            lblLotID.Text = value;
        }

        public void glsThick(string value)
        {
            lblGlassThick.Text = value;
        }

        public void portTypeChange(string value)
        {
            switch (value)
            {
                case "1":
                    lblPortType.Text = "OA"; //PB는 OA를 사용함.
                    break;
                case "2":
                    lblPortType.Text = "PL";
                    break;
                case "3":
                    lblPortType.Text = "PU";
                    break;
                case "4":
                    lblPortType.Text = "BB";
                    break;
                case "5":
                    lblPortType.Text = "BL";
                    break;
                case "6":
                    lblPortType.Text = "BU";
                    break;
                case "7":
                    lblPortType.Text = "BO";
                    break;
                default:
                    lblPortType.Text = "";
                    break;
            }
        }

        public void sortTypeChange(string value)
        {
            switch (value)
            {
                case "1":
                    lblSortType.Text = "TFT";
                    break;
                case "2":
                    lblSortType.Text = "CF";
                    break;
                case "3":
                    lblSortType.Text = "TC";
                    break;
                case "4":
                    lblSortType.Text = "ITO";
                    break;
                case "5":
                    lblSortType.Text = "BARE";
                    break;

                default:
                    break;

            }
        }

        public void qtyChange(string value)
        {
            lblQTY.Text = value;
        }

        public void lotStatusChange(string value)
        {
            switch (value)
            {
                case "1": //NO CST EXIST
                    lblLotStatus.Text = "READY";
                    lblLotStatus.BackColor = Color.Yellow;
                    lblLotStatus.ForeColor = Color.Black;
                    break;
                case "2": //WAIT FOR CST DATA                    
                case "3": //WAIT FOR START
                case "4": //WAIT FOR PROCESS
                case "6": // PAUSED
                    lblLotStatus.Text = "WAIT";
                    lblLotStatus.BackColor = Color.Yellow;
                    lblLotStatus.ForeColor = Color.Black;
                    break;
                case "5": // IN PORCESSING
                    lblLotStatus.Text = "START";
                    lblLotStatus.BackColor = Color.Blue;
                    lblLotStatus.ForeColor = Color.White;
                    break;
                case "7": // CANCEL
                    lblLotStatus.Text = "CANCEL";
                    lblLotStatus.BackColor = Color.Pink;
                    lblLotStatus.ForeColor = Color.Black;
                    break;
                case "8": // ABORT
                    lblLotStatus.Text = "ABORT";
                    lblLotStatus.BackColor = Color.Pink;
                    lblLotStatus.ForeColor = Color.Black;
                    break;
                case "9": // END
                    lblLotStatus.Text = "COMPLETE";
                    lblLotStatus.BackColor = Color.Yellow;
                    lblLotStatus.ForeColor = Color.Black;
                    break;
                default:
                    lblLotStatus.Text = "DEFAULT";
                    lblLotStatus.BackColor = Color.Blue;
                    lblLotStatus.ForeColor = Color.White;
                    break;

                #region // B3 Oven참조
                //case "ABORT":
                //    lblLotStatus.BackColor = Color.Pink;
                //    lblLotStatus.ForeColor = Color.Black;
                //    break;

                //case "CANCEL":
                //    lblLotStatus.BackColor = Color.Pink;
                //    lblLotStatus.ForeColor = Color.Black;
                //    break;

                //case "READY":
                //    lblLotStatus.BackColor = Color.Yellow;
                //    lblLotStatus.ForeColor = Color.Black;
                //    break;

                //case "START":
                //    lblLotStatus.BackColor = Color.Blue;
                //    lblLotStatus.ForeColor = Color.White;
                //    break;

                //case "WAIT":
                //case "WAIT CMD":
                //case "WAIT START":
                //    lblLotStatus.BackColor = Color.Yellow;
                //    lblLotStatus.ForeColor = Color.Black;
                //    break;                
                //case "END":
                //    lblLotStatus.BackColor = Color.Yellow;
                //    lblLotStatus.ForeColor = Color.Black;
                //    break;

                //default :
                //    lblLotStatus.BackColor = Color.White;
                //    lblLotStatus.ForeColor = Color.Black;
                //    break;
                #endregion
            }
        }

        public void portEnableChange(string value, bool Data)
        {
            if (Data)
            {
                lblPortEnable.Text = "E";
                lblPortEnable.BackColor = Color.Lime;

                switch (lblPortStatus.Text)
                {
                    case "LR":
                    case "UC":
                        pnl_PortEnable.BackColor = Color.Yellow;
                        break;

                    case "PC":
                    case "LC":
                    case "UR":
                        pnl_PortEnable.BackColor = Color.Lime;
                        break;
                    default :
                        pnl_PortEnable.BackColor = Color.Yellow;
                        break;
                }
            }
            else
            {
                lblPortEnable.Text = "D";
                lblPortEnable.BackColor = Color.Red;
            }
        }

        public void portStatusChange(string value)
        {
            switch (value)
            {
                case "1":
                    lblPortStatus.Text = "LR";
                    lblPortStatus.BackColor = Color.Yellow;
                    pnl_PortEnable.BackColor = Color.Yellow;
                    break;

                case "2":
                    lblPortStatus.Text = "PC";
                    lblPortStatus.BackColor = Color.Yellow;
                    pnl_PortEnable.BackColor = Color.Yellow;
                    break;

                case "3":
                    lblPortStatus.Text = "LC";
                    lblPortStatus.BackColor = Color.Lime;
                    pnl_PortEnable.BackColor = Color.Lime;
                    break;

                case "4":
                    lblPortStatus.Text = "UR";
                    lblPortStatus.BackColor = Color.Lime;
                    pnl_PortEnable.BackColor = Color.Lime;
                    break;

                case "5":
                    lblPortStatus.Text = "UC";
                    lblPortStatus.BackColor = Color.Yellow;
                    pnl_PortEnable.BackColor = Color.Yellow;
                    break;

                case "6":
                    lblPortStatus.Text = "DN";
                    lblPortStatus.BackColor = Color.Red;
                    pnl_PortEnable.BackColor = Color.Red;
                    break;

                default:
                    lblPortStatus.Text = "";
                    lblPortStatus.BackColor = Color.White;
                    pnl_PortEnable.BackColor = Color.White;
                    break;
            }
        }

        public void transferModeChange(string value)
        {
            switch (value)
            {
                case"1":
                    lblTransferMode.Text = "STK";
                    lblTransferMode.BackColor = Color.Lime;
                    break;

                case"2":
                    lblTransferMode.Text = "AGV";
                    lblTransferMode.BackColor = Color.Red;
                    break;

                case "3":
                    lblTransferMode.Text = "MGV";
                    lblTransferMode.BackColor = Color.Red;
                    break;

                default:
                    lblTransferMode.Text = value;
                    lblTransferMode.BackColor = Color.Yellow;
                    break;

            }
        }

        public class CportStatusData
        {
            public string TransferModeData { get; set; }
            public string PortStatusData { get; set; }
            public bool PortEnable { get; set; }
            public string portEnableData { get; set; }
            public string Lotstatus { get; set; }
            public string GlsThick { get; set; }
            public string SortType { get; set; }
            public string PortType { get; set; }
            public string Qty { get; set; }
            public string LotID { get; set; }
            public string CstID { get; set; }
            public string PortNo { get; set; }
            public bool CstExist { get; set; }
            public bool ClampOn { get; set; }
            public string CSTType { get; set; }
        }

        CUpdateHandler<CportStatusData> UpdateHandler = null;
        CportStatusData _portStatusData = new CportStatusData();
        public override bool Init()
        {
            base.Init();

            UpdateHandler = new CUpdateHandler<CportStatusData>(this, "ucPort", ref _portStatusData);
            UpdateHandler.OnUpdateData = new CUpdateHandler<CportStatusData>.UpdateDataHandler(InvokeUpdateData);
            UpdateHandler.Subscribe();
            return true;
        }

        private void InvokeUpdateData(bool noHandle, CportStatusData ucPortStatusData)
        {
            portNoChange(ucPortStatusData.PortNo);
            cstIDChange(ucPortStatusData.CstID);
            LotIDChange(ucPortStatusData.LotID);
            glsThick(ucPortStatusData.GlsThick);
            portTypeChange(ucPortStatusData.PortType);
            sortTypeChange(ucPortStatusData.SortType);
            qtyChange(ucPortStatusData.Qty);
            lotStatusChange(ucPortStatusData.Lotstatus);
            portEnableChange(ucPortStatusData.portEnableData, ucPortStatusData.PortEnable);
            portStatusChange(ucPortStatusData.PortStatusData);
            transferModeChange(ucPortStatusData.TransferModeData);
            cstTypeChange(ucPortStatusData.CSTType);
        }
    }
}
