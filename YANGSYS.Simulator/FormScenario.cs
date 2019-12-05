using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Xml;

namespace SmartPLCSimulator
{
    public partial class FormScenario : Form
    {
        ////SEQNO-STEPNO-DEVICETYPE-DATA
        public delegate void delegateScenarioDataSend(bool isBitType, string Address, string WriteData, string DeviceType);
        public event delegateScenarioDataSend ScenarioDataSend;
        private int iProgressStep = 0;
        public FormScenario()
        {
            InitializeComponent();
            txtInterval.Text = tmrInterval.Interval.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {   
            lstScenario.Items.Add(MakeData(false));            
        }

        private string[] SelectData = null;
        private const int TITLE = 0;
        private const int SEQNO = 1;
        private const int STEPNO = 2;
        private const int DEVICETYPE = 3;
        private const int ADDRESS = 4;
        private const int DATA = 5;
        private const int DESC = 6;
        private void lstScenario_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ScenarioDataSend(DEVICETYPE.BIT, lstScenario.SelectedItem.ToString());
            if (lstScenario.SelectedItem == null)
                return;

            SelectData = lstScenario.SelectedItem.ToString().Split(char.Parse("-"));
            if (SelectData.ToString().Length > 1)
            {
                txtStepNo.Text = SelectData[STEPNO];
                if (SelectData[DEVICETYPE] == "B")
                {
                    optBit.Checked = true;
                    if (SelectData[DATA] == "ON")
                        optBitOn.Checked = true;
                    else
                        optBitOff.Checked = true;
                }
                else
                {
                    optWord.Checked = true;
                    txtWordData.Text = SelectData[DATA];
                }

                txtAddress.Text = SelectData[ADDRESS];
                if (SelectData.Length > 6)
                    txtDesc.Text = SelectData[DESC];
                else
                    txtDesc.Text = "";
            }
        }

        private string MakeData(bool bModify)
        {
            //SEQNO-STEPNO-DEVICETYPE-ADDRESS-DATA
            string strScenario = "";
            if (bModify)
            {
                strScenario = "SEQ-" + SelectData[SEQNO];
            }
            else
            {
                strScenario = "SEQ-" + lstScenario.Items.Count.ToString();
            }
            strScenario += "-" + txtStepNo.Text.ToString();
            if (optBit.Checked)
            {
                strScenario += "-" + "B";
                strScenario += "-" + txtAddress.Text;
                if (optBitOn.Checked)
                {
                    strScenario += "-" + "ON";
                }
                else
                {
                    strScenario += "-" + "OFF";
                }
            }
            else
            {
                strScenario += "-" + "W" + "-" + txtAddress.Text + "-" + txtWordData.Text.ToString();
            }

            strScenario += "-" + txtDesc.Text;

            return strScenario;
        }
        
        private void btnModify_Click(object sender, EventArgs e)
        {
            string ReplaceData = MakeData(true);
            string strseqno = SelectData[SEQNO];
            int seqno = int.Parse(strseqno);

            lstScenario.Items[seqno] = ReplaceData;
        }

        private void optBit_CheckedChanged(object sender, EventArgs e)
        {
            if (optBit.Checked)
            {
                grbBit.Visible = true;
                grbWord.Visible = false;
            }
            else
            {
                grbBit.Visible = false;
                grbWord.Visible = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string strseqno = SelectData[SEQNO];
            int seqno = int.Parse(strseqno);
            object oItem = lstScenario.Items[seqno];
            lstScenario.Items.Remove(oItem);

            RelocateScenarioNo();
        }

        //SEQNO-STEPNO-DEVICETYPE-ADDRESS-DATA
        private void RelocateScenarioNo()
        {
            for (int i = 0; i < lstScenario.Items.Count; i++)
            {
                string[] strData = lstScenario.Items[i].ToString().Split(char.Parse("-"));
                string strAddData = "";
                strAddData = strData[TITLE] + "-" + i.ToString() + "-" + strData[STEPNO] + "-" + strData[DEVICETYPE] + "-" + strData[ADDRESS] + "-" + strData[DATA];
                if (strData.Length > 6)
                     strAddData += "-" + strData[DESC];

                lstScenario.Items[i] = strAddData;

            }
        }

        private void btnScenarioStart_Click(object sender, EventArgs e)
        {

            
            if (btnScenarioStart.Text == "Scenario Start")
            {
                btnScenarioStart.Text = "Scenario Stop";
                btnScenarioPause.Enabled = true;
                iProgressStep = 0;
                tmrInterval.Enabled = true;
                lbStep.Visible = true;
            }
            else
            {
                btnScenarioStart.Text = "Scenario Start";
                btnScenarioPause.Enabled = false;
                iProgressStep = 0;
                tmrInterval.Enabled = false;
                lbStep.Visible = false;
                lbStep.Text = "0";
            }
        }

        private void btnScenarioPause_Click(object sender, EventArgs e)
        {
            if (btnScenarioPause.Text == "Scenario Pause")
            {
                btnScenarioPause.Text = "Scenario Resume";
                tmrInterval.Enabled = false;
            }
            else
            {
                btnScenarioPause.Text = "Scenario Pause";
                tmrInterval.Enabled = true;
            }
        }

        private bool VerifyData()
        {
            return true;
        }

        private void tmrInterval_Tick(object sender, EventArgs e)
        {
            iProgressStep++;
            int iMaxStep = 0;
            for (int i = 0; i < lstScenario.Items.Count; i++)
            {
                string[] oData = lstScenario.Items[i].ToString().Split(char.Parse("-"));

                if (int.Parse(oData[STEPNO]) > iMaxStep)
                    iMaxStep = int.Parse(oData[STEPNO]);

                if (iProgressStep == int.Parse(oData[STEPNO]))
                {
                    if (ScenarioDataSend != null)
                    {
                        if (chkPLC.Checked)
                            ScenarioDataSend((oData[DEVICETYPE] == "B" ? true : false), HexToDec(oData[ADDRESS]), oData[DATA], "PLC");
                        else
                            ScenarioDataSend((oData[DEVICETYPE] == "B" ? true : false), HexToDec(oData[ADDRESS]), oData[DATA], "CCLINK");
                    }
                }
            }

            lbStep.Text = iProgressStep.ToString();

            if (iProgressStep > iMaxStep)
                iProgressStep = 0;
        }

        public string HexToDec(string s)
        {
            string HexToDec = "";
            try
            {
                HexToDec = Convert.ToInt64(s, 16).ToString();
            }
            catch (Exception ex)
            {
                HexToDec = ex.Message.ToString();
            }
            return HexToDec;
        }

        private void btnSetInterval_Click(object sender, EventArgs e)
        {
            tmrInterval.Interval = int.Parse(txtInterval.Text);
        }


        string strSaveFilePath = "";

        private void btnLoad_Click(object sender, EventArgs e)
        {           
            openFileDialog1.FileName = "";

            openFileDialog1.DefaultExt = "map";
            openFileDialog1.Filter = "Scenario files (*.scn)|*.scn";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                strSaveFilePath = openFileDialog1.FileName.ToString();

                StreamReader SRead = new StreamReader(strSaveFilePath, System.Text.Encoding.UTF8);

                string strFileLine = string.Empty;

                while ((strFileLine = SRead.ReadLine()) != null)
                {
                    if (strFileLine == "SIMULATOR SCENARIO")
                    {
                        lstScenario.Items.Clear();
                    }
                    else if (strFileLine.Contains("INTERVAL:"))
                    {
                        string[] oInterval = strFileLine.Split(char.Parse(":"));
                        txtInterval.Text = oInterval[1];
                        tmrInterval.Interval = int.Parse(txtInterval.Text);
                    }
                    else if (strFileLine.Contains("DEVICE_TYPE:"))
                    {
                        string[] oDeviceType = strFileLine.Split(char.Parse(":"));
                        if (oDeviceType[1] == "PLC")
                            chkPLC.Checked = true;
                        else
                            chkCCLink.Checked = true;
                    }
                    else
                    {
                        lstScenario.Items.Add(strFileLine);
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string strTest = "SIMULATOR SCENARIO";

            saveFileDialog1.FileName = "";

            saveFileDialog1.DefaultExt = "map";
            saveFileDialog1.Filter = "Scenario files (*.scn)|*.scn";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                strSaveFilePath = saveFileDialog1.FileName;
                StreamWriter SWrite = new StreamWriter(strSaveFilePath, false, System.Text.Encoding.UTF8);

                SWrite.WriteLine(strTest);

                for (int i = 0; i < lstScenario.Items.Count; i++)
                {
                    SWrite.WriteLine(lstScenario.Items[i]);
                }

                if (chkPLC.Checked)
                    SWrite.WriteLine("DEVICE_TYPE:PLC");
                else
                    SWrite.WriteLine("DEVICE_TYPE:CCLINK");

                SWrite.WriteLine("INTERVAL:" + txtInterval.Text);

                SWrite.Close();
            }
        }

        private void chkPLC_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCCLink.Checked)
                optWord.Enabled = false;
            else
                optWord.Enabled = true;
        }

        private void chkCCLink_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCCLink.Checked)
                optWord.Enabled = false;
            else
                optWord.Enabled = true;

        }
    }
}
