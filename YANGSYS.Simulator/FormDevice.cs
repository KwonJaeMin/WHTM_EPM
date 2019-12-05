using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SmartPLCSimulator
{
    public partial class FormDevice : Form
    {
        private BaseDevice _device = null;
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
        public FormDevice()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            this.comboBox1.Items.Clear();
            foreach (BaseDevice device in DeviceManager._deviceList.Values)
            {
                this.comboBox1.Items.Add(device.name);
            }
            //comboBox1.sel
            numericUpDown1.Hexadecimal = true;
        }

        private void FormDevice_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_device == null)
            {
                return;
            }
            if (_device.deviceType == DEVICETYPE.BIT)
            {
                if (_device.dataFormat != DATAFORMAT.BIN)
                {
                    _device.maxIndex = 4032;
                }
            }
            if (radioButton1.Checked)   // HEX 일경우
            {
                string HextoDec = Utils.HexToDec(numericUpDown1.Text);
                _device.index = Convert.ToInt32(HextoDec);
                if (_device.index > _device.maxIndex)
                {
                    _device.index = _device.maxIndex;
                }
            }
            else  // DEC일 경우
            {
                _device.index = Convert.ToInt32(numericUpDown1.Text);
                if (_device.index > _device.maxIndex)
                {
                    _device.index = _device.maxIndex;
                }
            }
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (BaseDevice device in DeviceManager._deviceList.Values)
            {
                if (device.name.Equals(comboBox1.SelectedItem.ToString()))
                {
                    _device = device;
                    numericUpDown1.Text = Utils.DecToHex(_device.index.ToString());
                    break;
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)   // HEX 일경우
            {
                numericUpDown1.Hexadecimal = true;
                //string DectoHex = Utils.DecToHex(numericUpDown1.Text);
                //numericUpDown1.Text = DectoHex;
            }
            else  // DEC일 경우
            {
                numericUpDown1.Hexadecimal =false;
                //string HextoDec = Utils.HexToDec(numericUpDown1.Text);
                //numericUpDown1.Text = HextoDec.PadLeft(4, '0');

            }
        }

        private void FormDevice_Shown(object sender, EventArgs e)
        {
            Init();
        }
    }
}