using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class ucAlignStage : UserControl
    {
        public ucAlignStage()
        {
            InitializeComponent();
        }

        public void GLS_EXIST(bool value)
        {
            if (value)
            {
                lbl_Gls_Exist.BackColor = Color.Lime;
            }
            else
            {
                lbl_Gls_Exist.BackColor = Color.Gray;
            }
        }

        public void ALIGN_STATUS(string value)
        {
            switch (value)
            {
                case "IDLE":
                    pnl_Status.BackColor = Color.Yellow;
                    break;

                case "RUN":
                    pnl_Status.BackColor = Color.Lime;
                    break;

                case "DOWN":
                    pnl_Status.BackColor = Color.Red;
                    break;

                case "MAINT":
                    pnl_Status.BackColor = Color.Magenta;
                    break;
            }
        }

        //public void IL_STATUS(cEnumList.ALIGN_STAGE_IL_LIST value)
        //{
        //    switch (value)
        //    {
        //        case cEnumList.ALIGN_STAGE_IL_LIST.IL_LOAD_REQ :
        //            lbl_Align_Status.Text = "LR";
        //            lbl_Align_Status.BackColor = Color.Yellow;
        //            break;

        //        case cEnumList.ALIGN_STAGE_IL_LIST.IL_UNLOAD_REQ:
        //            lbl_Align_Status.Text = "UR";
        //            lbl_Align_Status.BackColor = Color.Lime;
        //            break;

        //        case cEnumList.ALIGN_STAGE_IL_LIST.IL_EXCHANGE_REQ:
        //            lbl_Align_Status.Text = "ER";
        //            lbl_Align_Status.BackColor = Color.Red;
        //            break;

        //        case cEnumList.ALIGN_STAGE_IL_LIST.IL_NONE:
        //            lbl_Align_Status.Text = "";
        //            lbl_Align_Status.BackColor = Color.Gray;
        //            break;
        //    }
        //}
    }
}
