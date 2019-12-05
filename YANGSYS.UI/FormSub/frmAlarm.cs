using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SOFD.Gui.PopUp;
using SOFD.Gui.Widget;
using SOFD.Logger;

using SOFD.Component;
using SOFD.Component.Interface;
using YANGSYS.UI.WHTM.LogFormat;

using SOFD.Global.Manager;
using SOFD.Global.Interface;


namespace YANGSYS.UI.WHTM
{    
    public partial class frmAlarm : Form
    {
        public frmAlarm()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Log_Converter("UI", "Clear Button Click");
            dgvAlarmView.Rows.Clear();
        }

        private void btnBuzzerOff_Click(object sender, EventArgs e)
        {
            Log_Converter("UI", "BuzzerOff Button Click");         

            ACommand command = CUIManager.Inst.GetCommand("REQUEST");
            command.SubCommandName = "BUZZER_OFF";
            command.Execute();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Log_Converter("UI", "Close Button Click");
            this.Hide();
        }

        private delegate void delegateRefreshDgvAlarm(List<List<string>> alarms);
        public void RefreshDgvAlarm(List<List<string>> alarms)
        {
            //int dgvAlarmViewCount = 0;

            try
            {
                if (this.dgvAlarmView.InvokeRequired)
                {
                    delegateRefreshDgvAlarm refreshDgvAlarm = new delegateRefreshDgvAlarm(RefreshDgvAlarm);
                    this.BeginInvoke(refreshDgvAlarm, alarms);
                }
                else
                {
                    foreach (List<string> alarmData in alarms)
                    {
                        DataGridViewRow oRow = null;
                        if (alarmData[6] == "0")
                        {
                            foreach (DataGridViewRow item in dgvAlarmView.Rows)
                            {
                                if (item.Cells["colAlarmId"].Value.ToString() == alarmData[1])
                                {
                                    oRow = item;
                                    break;
                                }
                            }
                            if(oRow != null)
                                dgvAlarmView.Rows.Remove(oRow);
                            continue;
                        }

                        oRow = dgvAlarmView.Rows[dgvAlarmView.Rows.Add()];

                        //oRow.Cells["colNo"].Value = dgvAlarmView.Rows.Count.ToString();
                        oRow.Cells["colTime"].Value = alarmData[0];
                        oRow.Cells["colAlarmId"].Value = alarmData[1];
                        oRow.Cells["colCode"].Value = alarmData[2];
                        oRow.Cells["colType"].Value = alarmData[3];
                        oRow.Cells["colPosition"].Value = alarmData[4];
                        oRow.Cells["colMessage"].Value = alarmData[5];
                        oRow.Cells["colClearable"].Value = alarmData[6];
                    }
                }
            }
            catch (Exception ex)
            {
                CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "ERROR", ex));
            }
        }

        private void frmAlarmDisplay_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
        
        private void pnlMenu_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Location = new Point(0, 0);
        }

        private void Log_Converter(string LogType, string strMsg)
        {
            switch (LogType)
            {
                case "UI":
                    CLogManager.Instance.Log(new CUILogFormat(Catagory.Info, "frmAlarm", strMsg, ""));
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow oRow in dgvAlarmView.SelectedRows)
            {
                //oRow.Cells["colTime"].Value;
                string code = oRow.Cells["colAlarmId"].Value.ToString();

                int eqpAlarmCode = 0;
                int.TryParse(code, out eqpAlarmCode);

                eqpAlarmCode = eqpAlarmCode - 30000;
                //oRow.Cells["colType"].Value;
                //oRow.Cells["colPosition"].Value;
                //oRow.Cells["colMessage"].Value;
                string clearable = oRow.Cells["colClearable"].Value.ToString();

                if (clearable == "Y")
                {
                    ACommand command = CUIManager.Inst.GetCommand("REQUEST");
                    command.SubCommandName = "ALARM_RESET";
                    command.AddParameter("ALARM_CODE", eqpAlarmCode.ToString());
                    command.Execute();
                }
            }
        }
    }
}
