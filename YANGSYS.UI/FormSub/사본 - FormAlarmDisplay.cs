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
using YANGSYS.UI.LogFormat;

namespace YANGSYS.UI
{
    public partial class FormAlarmDisplay : Form
    {

        #region //event's
        public event delegateLogExceptionEvent OnLogExceptionEvent = null;
        #endregion

        #region //property's


        #endregion

        #region //constructor's

        public FormAlarmDisplay()
        {
            InitializeComponent();
        }
        #endregion

        #region //method's


        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            CLogManager.Instance.Log(new CUILogFormat(Catagory.Info, "OGS", "FormAlarmDisplay", "Close_Click"));
            this.Visible = false;
        }

        //public void AddData(string ControlName, string alarmCode, string alarmID, string alarmText, bool alarmSet)
        //{
        //    label1.Text = alarmText;
        //    Invalidate();
        //    if (alarmSet)
        //    {
        //        dgvAlarmItem.Rows.Add();
        //        DataGridViewRow oRow = dgvAlarmItem.Rows[dgvAlarmItem.Rows.Count - 1];

        //        oRow.Cells["colNo"].Value = dgvAlarmItem.Rows.Count.ToString();
        //        oRow.Cells["colControlName"].Value = ControlName;
        //        oRow.Cells["colAlarmCode"].Value = alarmCode;
        //        oRow.Cells["colAlarmID"].Value = alarmID;
        //        oRow.Cells["colAlarmText"].Value = alarmText;
        //    }
        //    else
        //    {
        //        // false 인경우 알람을 지운다.
        //        Console.WriteLine("알람을 지운다");
        //        //dgvAlarmItem.Container

        //    }
        //}

        private void btnAllClear_Click(object sender, EventArgs e)
        {
            CLogManager.Instance.Log(new CUILogFormat(Catagory.Info, "OGS", "FormAlarmDisplay", "Clear_Click"));
            dgvAlarmItem.Rows.Clear();
        }

        //public void RefreshDgvAlarm(CAlarmPropertiesCollection Alarms)
        //{
        //    int dgvAlarmItemCount = 0;
        //    dgvAlarmItem.Rows.Clear();
        //    try
        //    {
        //        if (this.dgvAlarmItem.InvokeRequired)
        //        {
        //            //delegateRefreshDgvAlarm refreshDgvAlarm = new delegateRefreshDgvAlarm(RefreshDgvAlarm);
        //            //this.BeginInvoke(refreshDgvAlarm, Alarms);
        //        }
        //        else
        //        {
        //            ////DataGridViewRow row = null;
        //            //foreach (CAlarmProperties oAlarm in Alarms.Values)
        //            //{

        //            //    dgvAlarmItem.Rows.Add();
        //            //    DataGridViewRow oRow = dgvAlarmItem.Rows[dgvAlarmItemCount];

        //            //    oRow.Cells["colNo"].Value = (dgvAlarmItemCount + 1).ToString();
        //            //    oRow.Cells["colAlarmGubun"].Value = oAlarm.AlarmGubun;
        //            //    oRow.Cells["colControlName"].Value = oAlarm.ControlName;
        //            //    oRow.Cells["colAlarmCode"].Value = oAlarm.AlarmCode;
        //            //    oRow.Cells["colAlarmID"].Value = oAlarm.AlarmID;
        //            //    oRow.Cells["colAlarmText"].Value = oAlarm.AlarmText;
        //            //    oRow.Cells["colRegtime"].Value = oAlarm.regtime.ToString();
        //            //    dgvAlarmItemCount++;

        //            //}
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "ERROR", ex));
        //    }
        //}

        private void FormAlarmDisplay_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void pnlMenu_Paint(object sender, PaintEventArgs e)
        {
           // this.Location = new Point(0, 0);
        }

        private void pnlMenu_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Location = new Point(0, 0);
        }
    }
}
