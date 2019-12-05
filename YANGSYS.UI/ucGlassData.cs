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
    public partial class ucGlassData : UserControl
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

        public string OperID
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

        public string GlassCodeXXYYYYZZZ
        {
            set
            {
                label6.Text = value;
            }

        }
        public string GlassCodeXXYYYY
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
        public string GlassCodeZZZ
        {
            get
            {
                return label13.Text;
            }
            set
            {
                label13.Text = value.PadLeft(3, '0');
            }
        }

        public string GlassJudgeCode
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
        public string CIMPCData1
        {
            get
            {
                return label64.Text;
            }
            set
            {
                label64.Text = DecToBinary(value, 16);
            }

        }
        public string CIMPCData2
        {
            get
            {
                return label65.Text;
            }
            set
            {
                label65.Text = DecToBinary(value, 16);
            }

        }
        public string ProdID
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

        public string ProcFlag1
        {
            get
            {
                return label37.Text;
            }
            set
            {
                label37.Text = DecToBinary(value, 16);

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
        public string ProcFlag2
        {
            get
            {
                return label62.Text;
            }
            set
            {
                label62.Text = DecToBinary(value, 16);
            }

        }
        public string JudgeFlag1
        {
            get
            {
                return label41.Text;
            }
            set
            {
                label41.Text = DecToBinary(value, 16);
            }

        }
        public string JudgeFlag2
        {
            get
            {
                return label61.Text;
            }
            set
            {
                label61.Text = DecToBinary(value, 16);
            }

        }
        public string SkipFlag1
        {
            get
            {
                return label19.Text;
            }
            set
            {
                label19.Text = DecToBinary(value, 16);
            }

        }
        public string SkipFlag2
        {
            get
            {
                return label60.Text;
            }
            set
            {
                label60.Text = DecToBinary(value, 16);
            }

        }
        public string InspectionFlag1
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
        public string InspectionFlag2
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

        public string Mode
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
        public string GlassType1
        {
            get
            {
                return label29.Text;
            }
            set
            {
                label29.Text = DecToBinary(value, 16);
            }

        }

        public string GlassType2
        {
            get
            {
                return label58.Text;
            }
            set
            {
                label58.Text = DecToBinary(value, 16);
            }

        }

        public string GLSSIZE
        {
            get
            {
                return label33.Text;
            }
            set
            {
                label33.Text = value;
            }

        }

        public string FIRSTLOT
        {
            get
            {
                return label43.Text;
            }
            set
            {
                label43.Text = value;
            }

        }

        public string LASTLOT
        {
            get
            {
                return label31.Text;
            }
            set
            {
                label31.Text = value;
            }

        }

        public string DummyType
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

        public string CF
        {
            get
            {
                return label35.Text;
            }
            set
            {
                label35.Text = value;
            }

        }

        public string ARRAY
        {
            get
            {
                return label46.Text;
            }
            set
            {
                label46.Text = value;
            }

        }

        public string ASSEMBLED
        {
            get
            {
                return label48.Text;
            }
            set
            {
                label48.Text = value;
            }

        }

        public string GLSANGLE
        {
            get
            {
                return label27.Text;
            }
            set
            {
                label27.Text = value;
            }

        }

        public string PNLGRADE
        {
            get
            {
                return label49.Text;
            }
            set
            {
                label49.Text = value;
            }

        }
        public string ReservedData1
        {
            get
            {
                return label52.Text;
            }
            set
            {
                label52.Text = value;
            }

        }
        public string ReservedData2
        {
            get
            {
                return label53.Text;
            }
            set
            {
                label53.Text = value;
            }

        }
        public string ReservedData3
        {
            get
            {
                return label54.Text;
            }
            set
            {
                label54.Text = value;
            }

        }
        public string ReservedData4
        {
            get
            {
                return label55.Text;
            }
            set
            {
                label55.Text = value;
            }

        }
        public string ReservedData5
        {
            get
            {
                return label56.Text;
            }
            set
            {
                label56.Text = value;
            }

        }
        public string ReservedData6
        {
            get
            {
                return label57.Text;
            }
            set
            {
                label57.Text = value;
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
        public ucGlassData()
        {
            InitializeComponent();
        }
    }
}
