using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SOFD.Gui.Window;
using SOFD.Logger;

using System.Threading;
using YANGSYS.UI.WHTM.SubForm;

using SOFD.Global.Manager;
using YANGSYS.UI.WHTM.LogFormat;
using YANGSYS.UI.WHTM.FormSub;
using SOFD.Global.Interface;

namespace YANGSYS.UI.WHTM
{
    public partial class ucMenu : UCFrame
    {
        #region //property's
        private frmLinkSignal _linkSignalForm = new frmLinkSignal();
        //private frmGlassData _glassDataformB10 = new frmGlassData();
        //private frmGlassDataWHTM _glassDataFormWHTM = new frmGlassDataWHTM();
        private frmAutoRecipeMode _autoRecipeform = new frmAutoRecipeMode();
        //private frmEqpMode _eqpModeForm = new frmEqpMode();
        private frmInlineMode _InlineModeForm = new frmInlineMode();
        private frmCIMMode _cimModeForm = new frmCIMMode();
        private FormConfig _configForm = new FormConfig();
        private frmScrap _scrapForm = new frmScrap();
         private frmAlarmDisplay _alarmDisplayForm = new frmAlarmDisplay();
         
        #endregion

        public ucMenu()
        {
            InitializeComponent();
        }

        #region //event's handler

        protected void OnMenuButtonCliceked(object sender, EventArgs e)
        {
            try
            {
                Button btn = sender as Button;
                if (btn == btnInlineMode)
                {
                    if (_InlineModeForm.Visible)
                        _InlineModeForm.BringToFront();
                    else
                        _InlineModeForm.Show();
                }
                //else if (btn == button1)
                //{
                //    ACommand command = CUIManager.Inst.GetCommand("REQUEST");
                //    command.SubCommandName = "EXCHANGE_MODE";
                //    KeyValuePair<string, string> values = new KeyValuePair<string, string>("MODE", true.ToString());
                //    command.Execute(values);
                //}
                else if (btn == button2)
                {
                    ShowForm(btn, _autoRecipeform);
                }
                //else if (btn == btnEqpMode)
                //{
                //    ShowForm(btn, _eqpModeForm);
                //}
                else if (btn == btnCIMMode)
                {
                    ShowForm(btn, _cimModeForm);
                }
                else if (btn == btnA)
                {
                    this.OnRequest("MAIN_VIEW");
                }
                else if (btn == btnB)
                {
                    this.OnRequest("GLASS_DATA_VIEW");

                    //string option = "WHTM";
                    //if (option != "WHTM")
                    //{
                    //    ShowForm(btn, _glassDataformB10);
                    //}
                    //else
                    //{
                    //    ShowForm(btn, _glassDataFormWHTM);
                    //}
                }
                else if (btn == btnRecipe)
                {
                    this.OnRequest("RECIPE_VIEW");
                }
                else if (btn == btnE)
                {
                    //this.OnRequest("LINK_SIGNAL_VIEW");
                    ShowForm(btn, _linkSignalForm);
                }
                else if (btn == btnC)
                {
                    this.OnRequest("LOG_VIEW");
                }
                else if (btn == btnConfiguration)
                {
                    ShowForm(btn, _configForm);
                }
                else if (btn == btnG)
                {
                    ShowForm(btn, _scrapForm);
                }
                else if (btn == btnD)
                {
                    ShowForm(btn, _alarmDisplayForm);
                }
                else if (btn == btnCimMsg)
                {
                    this.OnRequest("CIM_MSG_VIEW");
                }
                else if (btn == btnBuzzerOff)
                {
                    Log_Converter("UI", "BuzzerOff Button Click");

                    KeyValuePair<string, string> values = new KeyValuePair<string, string>();
                    ACommand command = CUIManager.Inst.GetCommand("TITLE");
                    command.SubCommandName = "BUZZER_OFF";
                    command.Execute(values);
                }
                else
                {
                    throw new NotImplementedException("button is not defined.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        #endregion

        public void InitializeButton()
        {
            Console.WriteLine("InitializeButton 구현해야함");
        }

        private delegate void ControlColorSetHandler(Control control, bool blink);
        private ControlColorSetHandler _delegateBlink = null;
        private void SetControlColor(Control control, bool blink)
        {
            control.BackColor = blink ? Color.Red : SystemColors.Control;
        }

        #region Blink
        private System.Threading.Timer _timer = null;

        private bool _alarmBlink = false;
        private bool _alarmBlinkState = false;
        private bool _cycleStopBlink = false;
        private bool _cycleStopBlinkState = false;

        private void Blink(object state)
        {
            if (_alarmBlink)
            {
                _alarmBlinkState = !_alarmBlinkState;
                this.Invoke(_delegateBlink, btnRecipe, _alarmBlinkState);
            }

            if (_cycleStopBlink)
            {
                _cycleStopBlinkState = !_cycleStopBlinkState;
                this.Invoke(_delegateBlink, btnCycleStop, _cycleStopBlinkState);
            }
        }

        private void StartBlink()
        {
            if (_delegateBlink == null)
                _delegateBlink = new ControlColorSetHandler(SetControlColor);

            if (_timer == null)
                _timer = new System.Threading.Timer(new TimerCallback(Blink));

            _timer.Change(0, 1000);
        }

        private void StopBlink()
        {
            if (_timer != null)
                _timer.Change(0, Timeout.Infinite);
        }
        #endregion

        private void Log_Converter(string LogType, string strMsg)
        {
            switch (LogType)
            {
                case "UI":
                    CLogManager.Instance.Log(new CUILogFormat(Catagory.Info, "", "frmAlarm", strMsg));
                    break;
            }
        }

        private void ShowForm(Button button, Form form)
        {            
            if (form == null)
            {
                throw new NotImplementedException("form is not defined.");
            }

            Log_Converter("UI", button.Text + " Button Click");

            form.StartPosition = FormStartPosition.CenterParent;
            if (form.Visible)
                form.BringToFront();
            else
                form.Show(this);
        }
    }
}
