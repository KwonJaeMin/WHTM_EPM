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
    public partial class ucGlassDataWHTM : UserControl
    {

        public string LotID
        {
            get
            {
                return label3.Text;
            }
            set
            {
                label3.Text = value;
            }

        }

        public string GlassID
        {
            get
            {
                return label4.Text;
            }
            set
            {
                label4.Text = value;
            }

        }

        public string GlassType
        {
            get
            {
                return label9.Text;
            }
            set
            {
                label9.Text = value;
            }

        }

        public string CassetteIndex
        {
            get
            {
                return label6.Text;
            }
            set
            {
                label6.Text = value;
            }

        }
        public string GlassIndex
        {
            get
            {
                return label7.Text;
            }
            set
            {
                label7.Text = value;
            }

        }
        public string ProductCode
        {
            get
            {
                return label13.Text;
            }
            set
            {
                label13.Text = value;//.PadLeft(3, '0');
            }
        }

        public string GlassThickness
        {
            get
            {
                return label17.Text;
            }
            set
            {
                label17.Text = value;
            }

        }

        public string PPID
        {
            get
            {
                return label23.Text;
            }
            set
            {
                label23.Text = value;
            }

        }
        public string JobGrade
        {
            get
            {
                return label64.Text;
            }
            set
            {
                label64.Text = value;// DecToBinary(value, 16);
            }

        }
        public string JobState
        {
            get
            {
                return label65.Text;
            }
            set
            {
                label65.Text = value;// DecToBinary(value, 16);
            }

        }
        public string JobJudge
        {
            get
            {
                return label21.Text;
            }
            set
            {
                label21.Text = value;
            }

        }

        public string TrackingData
        {
            get
            {
                return label37.Text;
            }
            set
            {
                label37.Text = DecToBinary(value, 64);

            }

        }

        private string DecToBinary(string dec, int maxLength)
        {

            try
            {
                long value = 0;
                long.TryParse(dec, out value);

                long sub;
                string reversed = "";
                while (true)
                {
                    sub = value % 2;
                    reversed += sub.ToString();
                    value = value / 2;
                    if (value == 0)
                        break;
                }
                //binary.Reverse();
                //string reversed = "";
                //for (int i = 0; i < binary.Count; i++)
                //{
                //    reversed += binary[i];
                //}
                return reversed.PadLeft(maxLength, '0');
            }
            catch
            {

            }

            return "";
        }
        public string UnitPathNo
        {
            get
            {
                return textBox1.Text;
            }
            set
            {
                textBox1.Text = value;//DecToBinary(value, 16);
            }

        }
        public string SlotNo
        {
            get
            {
                return label41.Text;
            }
            set
            {
                label41.Text = value;//DecToBinary(value, 16);
            }

        }
        public string CycleTime
        {
            get
            {
                return label61.Text;
            }
            set
            {
                label61.Text = value;//DecToBinary(value, 16);
            }

        }
        public string TactTime
        {
            get
            {
                return label19.Text;
            }
            set
            {
                label19.Text = value;//DecToBinary(value, 16);
            }

        }
        public string ReasonCode
        {
            get
            {
                return label60.Text;
            }
            set
            {
                label60.Text = value;//DecToBinary(value, 16);
            }

        }
        public string SamplingFlag
        {
            get
            {
                return label25.Text;
            }
            set
            {
                label25.Text = DecToBinary(value, 16);
            }

        }
        public string LotEndFlag
        {
            get
            {
                return label59.Text;
            }
            set
            {
                label59.Text = DecToBinary(value, 16);
            }

        }

        public string OperationId
        {
            get
            {
                return label39.Text;
            }
            set
            {
                label39.Text = value;
            }

        }
        public string ProductId
        {
            get
            {
                return label29.Text;
            }
            set
            {
                label29.Text = value;//DecToBinary(value, 16);
            }

        }

        public string CassetteId
        {
            get
            {
                return label58.Text;
            }
            set
            {
                label58.Text = value;//DecToBinary(value, 16);
            }

        }


        public string Reserved1
        {
            get
            {
                return label44.Text;
            }
            set
            {
                label44.Text = value;
            }

        }

        public string GLSTHICK
        {
            get
            {
                return label15.Text;
            }
            set
            {
                label15.Text = value;
            }

        }

        private bool _modifyMode = false;

        public bool ModifyMode
        {
            get
            {
                return _modifyMode;
            }
            set
            {
                _modifyMode = value;
                //foreach (Control item in this.Controls)//나중에
                //{
                //    if (item is TextBox)
                //    {
                //        TextBox textBox = item as TextBox;
                //        textBox.ReadOnly = !value;
                //    }
                //}
            }
        }
        public ucGlassDataWHTM()
        {
            InitializeComponent();
        }

        private void label17_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
