using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SmartPLCSimulator
{
    public partial class FormDataChange : Form
    {
        private BaseDevice _device = null;
        private int index = 0;
        public BaseDevice Device
        {
            get
            {
                return _device;
            }
            set
            {
                _device = value;
            }
        }
        public FormDataChange(BaseDevice _device, string index)
        {
            InitializeComponent();
            this.Device = _device;
            this.index = Convert.ToInt32(index);
            Init();
        }
        private void Init()
        {
            groupBox1.Text = "Device " + Device.name + " "+ Utils.DecToHex( index.ToString());
            int value = Convert.ToInt32(Device.Memory[index]);
            string data = value.ToString();
            data = data.PadLeft(4, '0');
            textBox1.Text = data;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                textBox1.Text = Utils.DecToHex( textBox1.Text);
            }
            else
            {
                string data = Utils.HexToDec(textBox1.Text);
                textBox1.Text = data.PadLeft(4, '0');
            }
        }

        private void FormDataChange_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked) // hex 일때
            {
                string retValue = Utils.HexToDec( textBox1.Text);

                Device.Memory[this.index] = (char)(Convert.ToInt32(retValue));
            }
            else                     // dec 일때
            {
                Device.Memory[this.index] = (char)(Convert.ToInt32(textBox1.Text));
            }
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}