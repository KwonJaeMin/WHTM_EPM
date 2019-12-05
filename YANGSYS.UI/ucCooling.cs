using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SOFD.Gui.Widget;


namespace Widgets
{
    public partial class ucCooling : UCBaseObject
    {
        #region // 기존버전
        //public ucCooling()
        //{
        //    InitializeComponent();
        //}

        //public ucCooling(Size size, Point location)
        //    : this()
        //{
        //    this.Size = size;
        //    this.Location = location;
        //}

        //public void PORTTYPE(string value)
        //{
        //    lbl_portType.Text = value;
        //}

        //public void PORTENABE(bool value)
        //{
        //    if (value)
        //    {
        //        lbl_portEnable.Text = "E";
        //        lbl_portEnable.BackColor = Color.Lime;
        //    }
        //    else
        //    {
        //        lbl_portEnable.Text = "D";
        //        lbl_portEnable.BackColor = Color.Red;
        //    }
        //}

        //public void QTY(string value)
        //{
        //    lbl_Qty.Text = value;
        //    if (value == "0")
        //    {
        //        pnl_Status.BackColor = Color.Yellow;
        //    }
        //    else
        //    {
        //        pnl_Status.BackColor = Color.Lime;
        //    }
        //}

        //public class CCoolingData
        //{
        //    public string PortType { get; set; }
        //    public bool PortEnable { get; set; }
        //    public string Qty { get; set; }
        //}

        //private void InvokeUpdateData(CCoolingData data)
        //{
        //    this.PORTTYPE(data.PortType);
        //    this.PORTENABE(data.PortEnable);
        //    this.QTY(data.Qty);
        //}

        //CUpdateHandler<CCoolingData> UpdateHandler = null;

        //public override void Init()
        //{
        //    base.Init();

        //    UpdateHandler = new CUpdateHandler<CCoolingData>(this, ElementId, new CCoolingData());
        //    UpdateHandler.OnUpdateData = new CUpdateHandler<CCoolingData>.UpdateDataHandler(InvokeUpdateData);
        //    UpdateHandler.Subscribe();
        //}
        #endregion

        //private IEQPControl _eqp = null;
        private string _controlID = string.Empty;

        public string ID
        {
            get { return _controlID; }
            set
            {
                if (value.Trim() != string.Empty && _controlID != null)
                    _controlID = value;
                else
                    _controlID = value;
            }
        }

        public ucCooling()
        {
            InitializeComponent();
        }
        //public ucCooling(IEQPControl eqp)
        //    : this()
        //{
        //    _eqp = eqp;

        //    this.ControlSize = _eqp.ControlSize;
        //    this.ControlLocation = _eqp.ControlLocation;

        //}

        public delegate void UpdateDataHandler(CEQPStatusData ucEqpStatusData);
        /// <summary>
        /// Null 검사 후 호출
        /// </summary>
        public UpdateDataHandler OnUpdateData = null;

        public void UpdateData(CEQPStatusData ucEqpStatusData)
        {
            UpdateDataHandler del = new UpdateDataHandler(InvokeUpdateData);
            this.Invoke(del, ucEqpStatusData);
        }

        private void InvokeUpdateData(CEQPStatusData ucEqpStatusData)
        {
            EQPNO(ucEqpStatusData.EQPID);
            EQPNAME(ucEqpStatusData.EQPNAME);
            STATUS(ucEqpStatusData.MOTIONSTATUS);
            IL_LOAD_REQ(ucEqpStatusData.LRSTATUS);
            IL_UNLOAD_REQ(ucEqpStatusData.URStatus);
            IL_ENABLE(ucEqpStatusData.INTERLOCKUSE);
            SET_CUR_RCPNO(ucEqpStatusData.RECIPE);
            UP_SLOT_GLS_EXIS(ucEqpStatusData.UP_SLOT_EXIST);
            LOW_SLOT_GLS_EXIST(ucEqpStatusData.LOW_SLOT_EXIST);
            LR_UP_SLOT(ucEqpStatusData.LR_UP_SLOT_TO);
            LR_LOW_SLOT(ucEqpStatusData.LR_LOW_SLOT_NO);
            UR_UP_SLOT(ucEqpStatusData.UR_UP_SLOT_NO);
            UR_LOW_SLOT(ucEqpStatusData.UR_LOW_SLOT_NO);
            NORMAL_STATUS(ucEqpStatusData.NORMALSTATUS);
            GLASS_QTY(ucEqpStatusData.QTY);
        }

        public void EQPNO(string value)
        {
            if (value == null)
            {
                lblEqpNo.Text = "";
            }
            else
            {
                lblEqpNo.Text = value;
            }
        }

        public void EQPNAME(string value)
        {
            lblEqpName.Text = value;
        }

        public void STATUS(string value)
        {
            switch (value)
            {
                case "1":
                    lbl_Status.Text = "IDLE";
                    lbl_Status.BackColor = Color.Yellow;
                    pnl_Status.BackColor = Color.Yellow;
                    break;

                case "2":
                    lbl_Status.Text = "RUN";
                    lbl_Status.BackColor = Color.Lime;
                    pnl_Status.BackColor = Color.Lime;
                    break;

                case "3":
                    lbl_Status.Text = "DOWN";
                    lbl_Status.BackColor = Color.Red;
                    pnl_Status.BackColor = Color.Red;
                    break;

                case "4":
                    lbl_Status.Text = "MAINT";
                    lbl_Status.BackColor = Color.Maroon;
                    pnl_Status.BackColor = Color.Magenta;
                    break;

                default:
                    break;
            }
        }

        public void IL_LOAD_REQ(bool value)
        {
            if (value)
            {
                lbl_IL_LoadRequest.BackColor = Color.Lime;
            }
            else
            {
                lbl_IL_LoadRequest.BackColor = Color.Gray;
            }
        }

        public void IL_UNLOAD_REQ(bool value)
        {
            if (value)
            {
                lbl_IL_UnloadRequest.BackColor = Color.Lime;
            }
            else
            {
                lbl_IL_UnloadRequest.BackColor = Color.Gray;
            }
        }

        public void SET_CUR_RCPNO(string value)
        {
            lbl_SetCurRcpNo.Text = value;
        }

        public void UP_SLOT_GLS_EXIS(bool value)
        {
            if (value)
            {
                lbl_UpSlotGlsExist.BackColor = Color.Lime;
            }
            else
            {
                lbl_UpSlotGlsExist.BackColor = Color.Gray;
            }
        }

        public void LOW_SLOT_GLS_EXIST(bool value)
        {
            if (value)
            {
                lbl_LowSlotGlsExist.BackColor = Color.Lime;
            }
            else
            {
                lbl_LowSlotGlsExist.BackColor = Color.Gray;
            }
        }

        public void LR_UP_SLOT(string value)
        {
            lbl_LR_UpSlot.Text = value;
        }

        public void LR_LOW_SLOT(string value)
        {
            lbl_LR_LowSlot.Text = value;
        }

        public void UR_UP_SLOT(string value)
        {
            lbl_UR_UpSlot.Text = value;
        }

        public void UR_LOW_SLOT(string value)
        {
            lbl_UR_LowSlot.Text = value;
        }

        public void NORMAL_STATUS(bool value)
        {
            if (value)
            {
                lbl_NormalStatus.BackColor = Color.Lime;
            }
            else
            {
                lbl_NormalStatus.BackColor = Color.Gray;
            }
        }

        public void IL_ENABLE(bool value)
        {
            if (value)
            {
                lbl_Enable.BackColor = Color.Lime;
            }
            else
            {
                lbl_Enable.BackColor = Color.Gray;
            }
        }

        public void GLASS_QTY(string value)
        {
            lbl_Qty.Text = value;
        }

        public class CEQPStatusData
        {
            public string EQPID { get; set; } // EQPID
            public string EQPNAME { get; set; } // EQPNAME
            public string MOTIONSTATUS { get; set; } //RUN/IDLE/DOWN
            public string RECIPE { get; set; } //RECIPE
            public string QTY { get; set; } // GLASS 개수
            public bool NORMALSTATUS { get; set; } //NORMAL ON/OFF
            public bool INTERLOCKUSE { get; set; } //INTERLOCK USE ENABLE/DISABLE
            public bool LRSTATUS { get; set; } // LR
            public string LR_UP_SLOT_TO { get; set; } //LR UP SLOT TO
            public string LR_LOW_SLOT_NO { get; set; } //LR LOW SLOT TO
            public bool URStatus { get; set; } //UR
            public string UR_UP_SLOT_NO { get; set; } //UR UP SLOT NO
            public string UR_LOW_SLOT_NO { get; set; } //UR LOW SLOT NO
            public bool UP_SLOT_EXIST { get; set; } //UP SLOT EXIST
            public bool LOW_SLOT_EXIST { get; set; } // LOW SLOT EXIST
        }
    }
}
