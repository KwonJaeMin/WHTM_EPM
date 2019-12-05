using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YANGSYS.UI.WHTM
{
    #region //delegate's
    public delegate void delegateLedButtonClicked(object obj, string signalName);
    #endregion

    public partial class ucButtonText : UserControl
    {
        #region //member's
        private string _buttonText = string.Empty;
        private bool _buttonClickConfirm = false;





        #endregion

        #region //event's
        public delegateLedButtonClicked OnLedButtonClicked = null;
        #endregion

        #region //property's
        public Font ButtonFont
        {
            set
            {

                SetButtonFont(value);
            }
        }
        public string ButtonText
        {
            get { return _buttonText; }
            set
            {
                _buttonText = value;
                SetButtonText(value);
            }
        }
        public bool ButtonClickConfirm
        {
            get { return _buttonClickConfirm; }
            set
            {
                _buttonClickConfirm = value;
                if (_buttonClickConfirm)
                {
                    this.btnText.BackColor = Color.Lime;
                }
                else
                {
                    //this.btnText.BackColor = System.Drawing.SystemColors.Control;
                    btnText.BackColor = Color.White;
                }

                Invalidate();
            }
        }

        public string ButtonSignalName { get; set; }



        #endregion

        #region //constructor's

        public ucButtonText()
        {
            InitializeComponent();

        }
        #endregion

        #region //method's

        protected void SetButtonText(string str)
        {
            this.btnText.Text = str;
        }
        protected void SetButtonFont(Font value)
        {
            this.btnText.Font = value;
        }

        #endregion

        #region //event's 처리기

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            this.btnText.Font = this.Font;
        }
        #endregion
    }
}
