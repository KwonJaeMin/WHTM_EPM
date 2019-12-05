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

namespace YANGSYS.UI.WHTM
{
    public partial class ucNavigation : UCFrame
    {
        #region //property's

        new public FrmMainFrame MainFrame
        {
            get { return _frmMainFrame; }
            set { _frmMainFrame = value; }
        }
        #endregion

        #region //constructor's
        public ucNavigation()
        {
            InitializeComponent();
        }

        
        #endregion

        #region //event's handler
        protected void OnMenuButtonCliceked(object sender, EventArgs e)
        {
            try
            {
                Button btn = sender as Button;
                switch (btn.Name)
                {

                    case "btnMain":
                        if (btn != null)
                        {
                            this.OnRequest(this.Name.ToString(), btn.Text);
                        }
                        break;
                    case "btnSystem":
                        if (btn != null)
                        {
                            this.OnRequest(this.Name.ToString(), btn.Text);
                        }
                        break;

                    case "btnLog":
                        if (btn != null)
                        {
                            this.OnRequest(this.Name.ToString(), btn.Text);
                        }
                        break;
                    case "btnAlarm":
                        if (btn != null)
                        {
                            this.OnRequest(this.Name.ToString(), btn.Text);
                        }
                        break;
                    case "btnAPDList":
                        if (btn != null)
                        {
                            this.OnRequest(this.Name.ToString(), "APDList");
                        }
                        break;
                    case "btnClose":
                        if (btn != null)
                        {
                            this.OnRequest(this.Name.ToString(), btn.Text);
                        }
                        break;
                    case "btn_GlassData":
                        if (btn != null)
                        {
                            this.OnRequest(this.Name.ToString(), "GlassData");
                        }
                        break;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        #endregion




 
    }
}
