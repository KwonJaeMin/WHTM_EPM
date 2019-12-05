using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SOFD.Logger;
using YANGSYS.UI.WHTM.LogFormat;

using SOFD.Global.Manager;
using SOFD.Global.Interface;


namespace YANGSYS.UI.WHTM.SubForm
{
    public partial class frmInlineMode : Form
    {
        public frmInlineMode()
        {
            InitializeComponent();
        }

         private void UpstreamInlineModeChange(bool value)
        {
            //if (value)
            //{
            //    lblUpstreamInlineMode.Text = "ON";
            //    lblUpstreamInlineMode.BackColor = Color.Lime;
            //}
            //else
            //{
            //    lblUpstreamInlineMode.Text = "OFF";
            //    lblUpstreamInlineMode.BackColor = Color.Red;
            //}

            ACommand command = CUIManager.Inst.GetCommand("MENU");
            command.SubCommandName = "UPSTREAM_INLINE_MODE_CHANGE";
            command.AddParameter("UPSTREAM_INLINE_MODE", value.ToString());
            command.Execute();            
        }

         private void DownstreamInlineModeChange(bool value)
        {
            ACommand command = CUIManager.Inst.GetCommand("MENU");
            command.SubCommandName = "DOWNSTREAM_INLINE_MODE_CHANGE";
            command.AddParameter("DOWNSTREAM_INLINE_MODE", value.ToString());
            command.Execute();
        }

         private void ExchangePossibleModeChange(bool value)
         {
             ACommand command = CUIManager.Inst.GetCommand("MENU");
             command.SubCommandName = "EXCHANGE_POSSIBLE_CHANGE";
             command.AddParameter("EXCHANGE_POSSIBLE", value.ToString());
             command.Execute();
         }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Log_Convert("UI", "Close Button Click");
            this.Hide();
        }

        private void btnUpStreamInlineModeON_Click(object sender, EventArgs e)
        {
            Log_Convert("UI", "UpStream Inline Mode On Click");
            UpstreamInlineModeChange(true);
            //this.Hide();
        }

        private void btnUpStreamInlineModeOff_Click(object sender, EventArgs e)
        {
            Log_Convert("UI", "UpStream Inline Mode Off Click");
            UpstreamInlineModeChange(false);
            //this.Hide();
        }
        private void btnDnStreamInlineModeON_Click(object sender, EventArgs e)
        {
            Log_Convert("UI", "DownStream Inline Mode On Click");
            DownstreamInlineModeChange(true);
            //this.Hide();
        }

        private void btnDnStreamInlineModeOff_Click(object sender, EventArgs e)
        {
            Log_Convert("UI", "DownStream Inline Mode Off Click");
            DownstreamInlineModeChange(false);
            //this.Hide();
        }

        private void btnExchangePossible_Click(object sender, EventArgs e)
        {
            Log_Convert("UI", "Exchange Possible On Click");
            ExchangePossibleModeChange(true);
        }

        private void btnExchangeImpossible_Click(object sender, EventArgs e)
        {
            Log_Convert("UI", "Exchange Possible Off Click");
            ExchangePossibleModeChange(false);
        }

        private void Log_Convert(string LogType, string strMsg)
        {
            switch (LogType)
            {
                case "UI":
                    CLogManager.Instance.Log(new CUILogFormat(Catagory.Info, "", "frmInlineMode", strMsg));
                    break;
            }
        }
    }
}
