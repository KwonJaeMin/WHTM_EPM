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
    public partial class ucEQP : UCBaseObject
    {
        public ucEQP()
        {
            InitializeComponent();
        }

        public ucEQP(Size size, Point location)
            : this()
        {
            this.Size = size;
            this.Location = location;
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
                    lbl_Status.Text = "PM";
                    lbl_Status.BackColor = Color.Maroon;
                    pnl_Status.BackColor = Color.Magenta;
                    break;

                case "5":
                    lbl_Status.Text = "STOP";
                    lbl_Status.BackColor = Color.Maroon;
                    pnl_Status.BackColor = Color.Yellow;
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
                lbl_LR_UpSlot.BackColor = Color.Lime;
            }
            else
            {
                lbl_LR_UpSlot.BackColor = Color.Gray;
            }
        }
        public void IL_LOAD_ENABLE(bool value)
        {
            if (value)
            {
                label9.BackColor = Color.Lime;
            }
            else
            {
                label9.BackColor = Color.Gray;
            }
        }

        public void IL_UNLOAD_ENABLE(bool value)
        {
            if (value)
            {
                label10.BackColor = Color.Lime;
            }
            else
            {
                label10.BackColor = Color.Gray;
            }
        }
        public void SET_CUR_RCPNO(string value)
        {
            lbl_SetCurRcpNo.Text = value;
        }

        public void GLASS_WHOLE(bool value)
        {
            lblGlass.BackColor = value ? Color.SkyBlue : Color.White;
            //lbl_UpSlotGlsExist.Visible = true;
            lblGlass.Visible = value;
            
        }

        public void GLASS_HALF1(bool value)
        {
            lblGlassHalf1.BackColor = value ? Color.SkyBlue : Color.White;
            lblGlassHalf1.Visible = value;
        }

        public void GLASS_HALF2(bool value)
        {
            lblGlassHalf2.BackColor = value ? Color.SkyBlue : Color.White;
            lblGlassHalf2.Visible = value;
        }

        public void LR_UP_SLOT(string value)
        {
            lbl_LR_UpSlot.Text = value;
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
        public void GLASS_CODE1(string value)
        {
            lblGlass.Text = value;
            lblGlassHalf1.Text = value;
            //if (!string.IsNullOrEmpty(value))
            //{
            //    lblGlass.Visible = true;
            //}
            //else
            //{
            //    lblGlass.Visible = false;
            //}
        }
        public void GLASS_ID1(string value)
        {
            lblGlass.Text += Environment.NewLine + value;
            lblGlassHalf1.Text += Environment.NewLine + value;
        }

        public void GLASS_CODE2(string value)
        {
            lblGlassHalf2.Text = value;
        }
        public void GLASS_ID2(string value)
        {
            lblGlassHalf2.Text += Environment.NewLine + value;
        }

        //public void GLASS_CODE2(string value)
        //{
        //    label7.Text = value;
        //}
        public class CEQPStatusData
        {
            public string EQPID { get; set; } // EQPID
            public string EQPNAME { get; set; } // EQPNAME
            public string EQPSTATUS { get; set; } //RUN/IDLE/DOWN
            public string RECIPE { get; set; } //RECIPE
            public string QTY { get; set; } // GLASS 개수
            public bool NORMALSTATUS { get; set; } //NORMAL ON/OFF
            public bool INTERLOCKUSE { get; set; } //INTERLOCK USE ENABLE/DISABLE
            public bool LRSTATUS { get; set; } // LR
            public bool URSTATUS { get; set; } // UR
            public bool LR_ENABLE { get; set; } // LR
            public bool UR_ENABLE{ get; set; } // UR
            public string LR_UP_SLOT_TO { get; set; } //LR UP SLOT TO
            public string LR_LOW_SLOT_NO { get; set; } //LR LOW SLOT TO

            public string UR_UP_SLOT_NO { get; set; } //UR UP SLOT NO
            public string UR_LOW_SLOT_NO { get; set; } //UR LOW SLOT NO
            public List<bool> HalfSIzeType { get; set; }
            public bool GlassStageExist { get; set; } //UP SLOT EXIST
            public bool GlassExist_Whole { get; set; }
            public bool GlassExist_A { get; set; }
            public bool GlassExist_B { get; set; }
            public string GlassCode1 { get; set; }
            public string GlassCode2 { get; set; }
            public string GlassID1 { get; set; }
            public string GlassID2 { get; set; }
            public List<string> LinkSignal { get; set; }
        }

        CUpdateHandler<CEQPStatusData> UpdateHandler = null;
        CEQPStatusData _EQPStatusData = new CEQPStatusData();
        public override bool Init()
        {
            base.Init();

            UpdateHandler = new CUpdateHandler<CEQPStatusData>(this, "ucEQP", ref _EQPStatusData);
            UpdateHandler.OnUpdateData = new CUpdateHandler<CEQPStatusData>.UpdateDataHandler(InvokeUpdateData);
            UpdateHandler.Subscribe();
 
            return true;
        }

        private void InvokeUpdateData(bool noHandle, CEQPStatusData ucEqpStatusData)
        {
            EQPNO(ucEqpStatusData.EQPID);
            EQPNAME(ucEqpStatusData.EQPNAME);
            STATUS(ucEqpStatusData.EQPSTATUS);
            IL_LOAD_REQ(ucEqpStatusData.LRSTATUS);
            IL_UNLOAD_REQ(ucEqpStatusData.URSTATUS);
            IL_LOAD_ENABLE(ucEqpStatusData.LR_ENABLE);
            IL_UNLOAD_ENABLE(ucEqpStatusData.UR_ENABLE);
            IL_ENABLE(ucEqpStatusData.INTERLOCKUSE);
            SET_CUR_RCPNO(ucEqpStatusData.RECIPE);



            NORMAL_STATUS(ucEqpStatusData.NORMALSTATUS);
            GLASS_QTY(ucEqpStatusData.QTY);
            GLASS_CODE1(ucEqpStatusData.GlassCode1);
            GLASS_ID1(ucEqpStatusData.GlassID1);
            GLASS_CODE2(ucEqpStatusData.GlassCode2);
            GLASS_ID2(ucEqpStatusData.GlassID2);

            if (ucEqpStatusData.LinkSignal == null || ucEqpStatusData.LinkSignal.Count <= 0)
                return;
            lblDownstreamInline.BackColor = ucEqpStatusData.LinkSignal[0] == "True" ? Color.Lime : Color.White;
            lblDownstreamTrouble.BackColor = ucEqpStatusData.LinkSignal[1] == "True" ? Color.Red : Color.White;
            lblUpstreamInline.BackColor = ucEqpStatusData.LinkSignal[2] == "True" ? Color.Lime : Color.White;
            lblUpstreamTrouble.BackColor = ucEqpStatusData.LinkSignal[3] == "True" ? Color.Red : Color.White;
            lblExchnagePassible.BackColor = ucEqpStatusData.LinkSignal[4] == "True" ? Color.Lime : Color.White;
            lblExchnagePassible.Text = ucEqpStatusData.LinkSignal[4] == "True" ? "ON" : "OFF";


            GLASS_WHOLE(ucEqpStatusData.GlassStageExist & ucEqpStatusData.GlassExist_Whole);
            GLASS_HALF1(ucEqpStatusData.GlassStageExist & ucEqpStatusData.GlassExist_A);
            GLASS_HALF2(ucEqpStatusData.GlassStageExist & ucEqpStatusData.GlassExist_B);

            //if (ucEqpStatusData.HalfSIzeType == null)
            //{
            //    GLASS_EXIST1(ucEqpStatusData.GlassStageExist);
            //    lblGlass.Visible = ucEqpStatusData.GlassStageExist;
            //    return;
            //}

            //if (ucEqpStatusData.HalfSIzeType[2])
            //{
            //    GLASS_EXIST1(ucEqpStatusData.GlassStageExist & ucEqpStatusData.HalfSIzeType[2]);
            //    lblGlass.Visible = ucEqpStatusData.GlassStageExist & ucEqpStatusData.HalfSIzeType[2];
            //}
            //else if (ucEqpStatusData.HalfSIzeType[0] == true || ucEqpStatusData.HalfSIzeType[1] == true)
            //{
            //    GLASS_HALF1(ucEqpStatusData.GlassStageExist & ucEqpStatusData.HalfSIzeType[0]);
            //    GLASS_HALF2(ucEqpStatusData.GlassStageExist & ucEqpStatusData.HalfSIzeType[1]);
            //    lblGlass.Visible = false;
            //}
            //else
            //{
            //    GLASS_EXIST1(ucEqpStatusData.GlassStageExist);
            //    lblGlass.Visible = ucEqpStatusData.GlassStageExist;
            //}
        }
    }    
}

