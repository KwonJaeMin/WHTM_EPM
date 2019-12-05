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
    public partial class ucButtonImg : UserControl
    {
        public ucButtonImg()
        {
            InitializeComponent();
        }

        private void plBtn_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("프로그램을 종료합니다");
        }

        //private void plBtn_Paint(object sender, PaintEventArgs e)
        //{
        //    MessageBox.Show("프로그램을 종료합니다");
        //}
    }
}
