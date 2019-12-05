using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SOFD.Gui.Window;
using SOFD.Component.Interface;


using YANGSYS.UI.WHTM.Frame.Main;

namespace YANGSYS.UI.WHTM
{
    public partial class ucMain : UCFrame
    {
        #region //member's

        private int iSizeWidth = 0;
        private int iSizeHeight = 0;


        #endregion

        #region //property's
        new public FrmMainFrame MainFrame
        {
            get { return _frmMainFrame; }
            set { _frmMainFrame = value; }
        }

        public ucMonitorPanel MonitorPanel { get; set; }
        #endregion

        #region //constructor's
        public ucMain()
        {
            InitializeComponent();

            #region // 2013-10-30 김동광 추가
            this.plmain1 = new System.Windows.Forms.Panel();
            //this.plmain1.Size = new Size(200, 200);
            //this.plmain1.Location = new Point(100, 100);
            // this.plmain1.BackColor = System.Drawing.Color.Yellow;
            // this.plmain1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plmain1.Dock = DockStyle.Fill;
            //this.plmain1.Visible = true;

            this.plmain2 = new System.Windows.Forms.Panel();
            //this.plmain2.Size = new Size(200, 200);
            //this.plmain2.Location = new Point(300, 100);
            //this.plmain2.BackColor = System.Drawing.Color.Lime;
            //this.plmain2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plmain2.Dock = DockStyle.Fill;
            this.plmain2.Visible = false;

            this.plmain2.AutoScroll = true;




            this.Controls.Add(this.plmain1);
            this.Controls.Add(this.plmain2);







            #endregion
        }


        public System.Windows.Forms.Panel plmain1;
        public System.Windows.Forms.Panel plmain2;


        #endregion

        #region //method's
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            iSizeWidth = this.Size.Width;
            iSizeHeight = this.Size.Height;


        }

        public void AddControl(System.Windows.Forms.Control control)
        {
            control.Location = control.Location;
            control.Size = control.Size;
            this.Controls.Add(control);
        }

        public void AddControl(System.Windows.Forms.Control[] controls)
        {
            this.plmain1.Controls.Clear();
            this.plmain1.Controls.AddRange(controls);

           // this.Controls.Clear();
           // this.Controls.AddRange(controls);

        }
        public void AddControl2D(System.Windows.Forms.Control[] controls)
        {
            this.plmain2.Controls.Clear();            
            this.plmain2.Controls.AddRange(controls);            
        }
        public void AddControl2D(System.Windows.Forms.Control control)
        {
            control.Location = control.Location;
            control.Size = control.Size;
            this.plmain2.Controls.Add(control);
        }
        
        // false는 3D 화면 True 2D화면
        private bool _isOn = false;
        public void viewChanged(bool isOn)
        {
            if (_isOn != isOn)
            {
                if (isOn == false)
                {
                    this.plmain1.Visible = true;
                    this.plmain1.Dock = DockStyle.Fill;
                    this.plmain2.Visible = false;
                }
                else
                {
                    this.plmain2.Visible = true;
                    this.plmain2.Dock = DockStyle.Fill;
                    this.plmain1.Visible = false;
                }
            }
            _isOn = isOn;
        }

        public void ControlMouseClickEvent()
        {
            foreach (System.Windows.Forms.Control control in this.Controls)
            {
                //if (control is ucEqpTetragon)
                //{
                //    ucEqpTetragon equipment = control as ucEqpTetragon;

                //}
            }
        }

        // 확인창 띄우기.
        public bool ShowCheckConfirm(string vTitle, string vText)
        {
            frmConfirm fConfirm = new frmConfirm();
            fConfirm.SetContent(vTitle, vText);

            fConfirm.TopMost = true;
            fConfirm.ShowDialog(this);
            if (fConfirm.CheckReturn)
            {
                fConfirm.TopMost = false;
                return true;
            }
            else
            {
                fConfirm.TopMost = true;
                return false;
            }
        }
        #endregion

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
