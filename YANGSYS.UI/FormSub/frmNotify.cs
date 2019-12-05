using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//using YANGSYS.UI;
using SOFD.Gui.PopUp;
using SOFD.Gui.Widget;
using YANGSYS.UI.LogFormat;
using SOFD.Logger;
//using YANGSYS.UI.Manager;
using SOFD.Gui.PopUp;

namespace YANGSYS.UI
{
    public partial class frmNotify : FrmPopUp
    {
        public delegate void delegateEqpBuzzerOffCommand(bool value);
        public event delegateEqpBuzzerOffCommand BuzzerOffCommand = null;

        #region //event's
        public event delegateLogExceptionEvent OnLogExceptionEvent = null;
        #endregion

        #region //member's
        //

        #endregion

        #region //property's


        #endregion

        #region //constructor's

        //public FormNotify()
        //{
        //    InitializeComponent();
        //}
        public frmNotify()
        {            
            InitializeComponent();
            this.pnlButtonBack.Visible = false;
            InitDisplay();
            //InitCaution(caution);
        }
        
        
        #endregion

        #region //method's

        private void InitDisplay()
        {
        }
        private void InitCaution(string caution)
        {
            //label1.Text = caution;
            Invalidate();
        }

        //protected override void btnOK_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        DialogResult = DialogResult.OK;
        //        base.btnOK_Click(sender, e);
        //    }
        //    catch (Exception ex)
        //    {
        //        if (OnLogExceptionEvent != null)
        //            OnLogExceptionEvent(this, ex);
        //    }
           
        //}

        private void FormCaution_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                for (int i = 0; i < this.Controls.Count; i++)
                {
                    this.Controls.Remove(this.Controls[i]);
                }
            }
            catch (Exception ex)
            {
                if (OnLogExceptionEvent != null)
                    OnLogExceptionEvent(this, ex);
            }
        }
        #endregion

        private void btnBuzzOff_Click(object sender, EventArgs e)
        {
            Log_Converter("UI", "BUZZER OFF BUTTON CLICK");
            if (BuzzerOffCommand != null)
                BuzzerOffCommand(false);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Log_Converter("UI", "CLOSE BUTTON CLICK");
            this.Hide();
        }

        public void ShowForm(string title, string Msg)
        {
            this.lblTitle.Text = title;
            this.lblMessage.Text = Msg;
        }

        public void setInformationDatas(NotifyDataList notifyList)
        {
            NotifyDataList NotifyDataList = notifyList;
            this.lblTitle.Text = NotifyDataList.NOTITYTITLE;
            this.lblMessage.Text = NotifyDataList.NOTITYMSG;
            this.lbloccurredTime.Text = NotifyDataList.NOTITYOCCURTIME;
        }

        private void Log_Converter(string LogType, string strMsg)
        {
            switch (LogType)
            {
                case "UI":
                    CLogManager.Instance.Log(new CUILogFormat(Catagory.Info, "", "frmNotify", strMsg));
                    break;
            }
        }
    }

    public class NotifyDataList
    {
        public string NOTITYTITLE { get; set; }
        public string NOTITYMSG { get; set; }
        public string NOTITYOCCURTIME { get; set; }        
    }
}
