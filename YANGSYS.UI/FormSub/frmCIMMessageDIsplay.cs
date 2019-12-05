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
    public partial class frmCIMMessageDIsplay : Form
    {

        public frmCIMMessageDIsplay()
        {
            InitializeComponent();
            //this.pnlButtonBack.Visible = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Log_Converter("UI", "Clear Button Click");
            dgvListView.Rows.Clear();
        }

        private void btnBuzzerOff_Click(object sender, EventArgs e)
        {
            Log_Converter("UI", "BuzzerOff Button Click");

            KeyValuePair<string, string> values = new KeyValuePair<string, string>();

            ACommand command = CUIManager.Inst.GetCommand("TITLE");
            command.SubCommandName = "BUZZER_OFF";
            command.Execute(values);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Log_Converter("UI", "Close Button Click");
            this.Hide();
        }

        private delegate void delegateRefreshDgvAlarm(List<List<string>> list);
        public void RefreshDgvList(List<List<string>> list)
        {
            try
            {
                if (this.dgvListView.InvokeRequired)
                {
                    delegateRefreshDgvAlarm refreshDgvAlarm = new delegateRefreshDgvAlarm(RefreshDgvList);
                    this.BeginInvoke(refreshDgvAlarm, list);
                }
                else
                {

                    foreach (List<string> data in list)
                    {
                        if (data[0] == "MESSAGE_SET")
                        {
                            DataGridViewRow oRow = dgvListView.Rows[dgvListView.Rows.Add()];

                            oRow.Cells["colID"].Value = data[1];
                            oRow.Cells["colTime"].Value = data[2];
                            oRow.Cells["colMessage"].Value = data[3];
                            oRow.Cells["colConfirm"].Value = "Confirm";

                            //AddHistory(oRow);

                        }
                        else if (data[0] == "MESSAGE_CLEAR")
                        {
                            DataGridViewRow selectedRow = null;
                            foreach (DataGridViewRow row in dgvListView.Rows)
                            {
                                if (row.Cells["colID"].Value.ToString() == data[1])
                                {
                                    selectedRow = row;
                                    break;
                                }
                            }
                            if (selectedRow != null)
                            {
                                //Dictionary<string, string> values = new Dictionary<string, string>();
                                //values.Add("MESSAGE_ID", selectedRow.Cells["colID"].Value.ToString());
                                //values.Add("TOUCH_PANLE_NO", "1");
                                //ACommand command = CUIManager.Inst.GetCommand("REQUEST");
                                //command.SubCommandName = "MESSAGE_CONFIRM";
                                //command.Execute(values);

                                dgvListView.Rows.Remove(selectedRow);
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "ERROR", ex));
            }
        }

        private delegate void delegateUpdateHistory(List<List<string>> list);
        public void UpdateHistory(List<List<string>> list)
        {
            try
            {
                if (this.dgvListView.InvokeRequired)
                {
                    delegateUpdateHistory refreshHistory = new delegateUpdateHistory(UpdateHistory);
                    this.BeginInvoke(refreshHistory, list);
                }
                else
                {
                    foreach (List<string> data in list)
                    {
                        DataGridViewRow oHis = dataGridView1.Rows[dataGridView1.Rows.Add()];

                        oHis.Cells["HisID"].Value = data[1];
                        oHis.Cells["HisTime"].Value = data[2];
                        oHis.Cells["RcvMsg"].Value = data[3];

                        if (dataGridView1.Rows.Count > 21)
                        {
                            dataGridView1.Rows.RemoveAt(0);
                        }
                    }
 


                    //foreach (List<string> data in list)
                    //{
                    //    if (data[0] == "MESSAGE_SET")
                    //    {
                    //        DataGridViewRow oRow = dgvListView.Rows[dgvListView.Rows.Add()];

                    //        oRow.Cells["colID"].Value = data[1];
                    //        oRow.Cells["colTime"].Value = data[2];
                    //        oRow.Cells["colMessage"].Value = data[3];
                    //        oRow.Cells["colConfirm"].Value = "Confirm";

                    //        //AddHistory(oRow);

                    //    }
                    //    else if (data[0] == "MESSAGE_CLEAR")
                    //    {
                    //        DataGridViewRow selectedRow = null;
                    //        foreach (DataGridViewRow row in dgvListView.Rows)
                    //        {
                    //            if (row.Cells["colID"].Value.ToString() == data[1])
                    //            {
                    //                selectedRow = row;
                    //                break;
                    //            }
                    //        }
                    //        if (selectedRow != null)
                    //        {
                    //            //Dictionary<string, string> values = new Dictionary<string, string>();
                    //            //values.Add("MESSAGE_ID", selectedRow.Cells["colID"].Value.ToString());
                    //            //values.Add("TOUCH_PANLE_NO", "1");
                    //            //ACommand command = CUIManager.Inst.GetCommand("REQUEST");
                    //            //command.SubCommandName = "MESSAGE_CONFIRM";
                    //            //command.Execute(values);

                    //            dgvListView.Rows.Remove(selectedRow);
                    //        }
                    //    }

                    //}
                }
            }
            catch (Exception ex)
            {
                CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "ERROR", ex));
            }
        }

        public void AddHistory(DataGridViewRow oRow)
        {
            DataGridViewRow oHis = dataGridView1.Rows[dataGridView1.Rows.Add()];

            oHis.Cells["HisID"].Value = oRow.Cells["colID"].Value;
            oHis.Cells["HisTime"].Value = oRow.Cells["colTime"].Value;
            oHis.Cells["RcvMsg"].Value = oRow.Cells["colMessage"].Value;

            if (dataGridView1.Rows.Count > 20)
            {
                dataGridView1.Rows.RemoveAt(0);
            }

            //string TempValue = "";
            //int listCnt = 0;
            //foreach (DataGridViewRow item in dataGridView1.Rows)
            //{
            //    listCnt++;
            //    TempValue = listCnt.ToString() + "," + item.Cells["HisID"].Value + "," + item.Cells["HisTime"].Value + "," + item.Cells["RcvMsg"].Value;

            //    ACommand command = CUIManager.Inst.GetCommand("MENU");
            //    command.SubCommandName = "SAVE_CIM_MESSAGE_HISTORY";
            //    command.AddParameter("CIM_MESSAGE_HISTORY_ADD", TempValue.ToString());
            //    command.Execute();
            //}
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
                    CLogManager.Instance.Log(new CUILogFormat(Catagory.Info, "frmCIMMessageDisplay", strMsg, ""));
                    break;
            }
        }

        private void dgvListView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3) //20161031
            {
                
                Dictionary<string, string> values = new Dictionary<string, string>();
                values.Add("MESSAGE_ID", dgvListView.Rows[e.RowIndex].Cells["colID"].Value.ToString());
                values.Add("TOUCH_PANLE_NO", "1");
                //ACommand command = CUIManager.Inst.GetCommand("REQUEST");
                //command.SubCommandName = "MESSAGE_CONFIRM";
                //command.Execute(values);

                dgvListView.Rows.Remove(dgvListView.Rows[e.RowIndex]);
 
            }
        }

        private void btnConfirm_Click_1(object sender, EventArgs e)
        {
            List<string> ids = new List<string>();
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in dgvListView.Rows)
            {
                Dictionary<string, string> values = new Dictionary<string, string>();
                values.Add("MESSAGE_ID", row.Cells["colID"].Value.ToString());
                values.Add("TOUCH_PANLE_NO", "1");
                //ACommand command = CUIManager.Inst.GetCommand("REQUEST");
                //command.SubCommandName = "MESSAGE_CONFIRM";
                //command.Execute(values);

                rows.Add(row);
            }

            foreach (DataGridViewRow row in rows)
            {
                dgvListView.Rows.Remove(row); 
            }            

            dgvListView.Rows.Clear();

            //            _main.SendData(new List<string>() { "CIM_MESSAGE_ON", "O", tmpMsg });

            ACommand command = CUIManager.Inst.GetCommand("REQUEST");
            command.SubCommandName = "MESSAGE_ALLCLEAR";
            command.Execute();
        }

        //public class CEQPStatusData
        //{
        //    public DataGridViewRow mHistory { get; set; } // EQPID

        //}

        //CUpdateHandler<CEQPStatusData> UpdateHandler = null;
        //CEQPStatusData _EQPStatusData = new CEQPStatusData();
        //public override bool Init()
        //{

        //    UpdateHandler = new CUpdateHandler<CEQPStatusData>(this, "frmCIMMessageDIsplay", ref _EQPStatusData);
        //    UpdateHandler.OnUpdateData = new CUpdateHandler<CEQPStatusData>.UpdateDataHandler(InvokeUpdateData);
        //    UpdateHandler.Subscribe();

        //    return true;
        //}

        //private void InvokeUpdateData(bool noHandle, CEQPStatusData ucEqpStatusData)
        //{
        //    Update_History(ucEqpStatusData.mHistory);

        //}

        //public void Update_History(DataGridViewRow value)
        //{
        //    DataGridViewRow oHis = dataGridView1.Rows[dataGridView1.Rows.Add()];

        //    oHis.Cells["HisID"].Value = value.Cells[0].Value;
        //    oHis.Cells["HisTime"].Value = value.Cells[1].Value;
        //    oHis.Cells["RcvMsg"].Value = value.Cells[2].Value;
        //}
    }
}
