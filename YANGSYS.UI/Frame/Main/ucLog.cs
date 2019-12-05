using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SOFD.Gui.Window;
using SOFD.Gui.PopUp;
using SOFD.Logger;
using System.IO;
using System.Threading;

namespace YANGSYS.UI.WHTM
{
    public partial class ucLog : UCFrame
    {
        //각 컬럼의 이름을 상수로 지정.
        public const string COLUMNNAME_DATETIME = "TIME";
        public const string COLUMNNAME_EQPNAME = "EQP NAME";
        public const string COLUMNNAME_ID = "ID";
        public const string COLUMNNAME_MESSAGE = "MESSAGE";
        public const string COLUMNNAME_DATA = "DATA";
        public const string COLUMNNAME_CATEGORY = "CATEGORY";
        public const string COLUMNNAME_CODE = "CODE";
        public const string COLUMNNAME_CONTENTS = "CONTENTS";
        public const string COLUMNNAME_STATE = "STATE";
        public const string COLUMNNAME_OWNERNAME = "NAME";

        #region //delegate's
        private delegate void delegateDataGridViewRefresh(DataTable dt);
        #endregion

        #region //member's
        
        private DataTable _dt = new DataTable();
        private string _searchDate = string.Empty;
        private string _selectedLogPath = string.Empty;
        private ucRequestProgressBar requestProgressBar;

        #endregion

        #region //property's

        new public FrmMainFrame MainFrame
        {
            get { return _frmMainFrame; }
            set { _frmMainFrame = value; }
        }

         #endregion

        #region //event's

        #endregion

        #region //constructor's
        public ucLog()
        {
            InitializeComponent();
            this.dtpFindDate.Value = DateTime.Today;


            requestProgressBar = new ucRequestProgressBar();
            requestProgressBar.Visible = false;
            this.Controls.Add(requestProgressBar);


            //각 컬럼의 크기를 지정
            _columnWidthConfigs.Add(COLUMNNAME_DATETIME, 160);
            _columnWidthConfigs.Add(COLUMNNAME_EQPNAME, 80);
            _columnWidthConfigs.Add(COLUMNNAME_ID, 140);
            _columnWidthConfigs.Add(COLUMNNAME_MESSAGE, 500);
            _columnWidthConfigs.Add(COLUMNNAME_DATA, 500);
            _columnWidthConfigs.Add(COLUMNNAME_CATEGORY, 100);
            _columnWidthConfigs.Add(COLUMNNAME_CODE, 50);
            _columnWidthConfigs.Add(COLUMNNAME_CONTENTS, 500);
            _columnWidthConfigs.Add(COLUMNNAME_STATE, 80);
        }
        #endregion

        #region //method's

        private void LogDataClear()
        {
            lock (_dataTableLock)
            {
                _dt = null;
                _dt = new DataTable();
                dgvLog.DataSource = _dt.Copy();
            }
        }

        private void AlarmDataAdd()
        {
            _dt.Columns.Add(COLUMNNAME_DATETIME);
            _dt.Columns.Add(COLUMNNAME_CATEGORY);
            _dt.Columns.Add(COLUMNNAME_EQPNAME);
            //_dt.Columns.Add(COLUMNNAME_CODE);
            //_dt.Columns.Add(COLUMNNAME_ID);
            _dt.Columns.Add(COLUMNNAME_CONTENTS);
            //_dt.Columns.Add(COLUMNNAME_STATE);

            //if (string.IsNullOrEmpty(cmbEquipmentName.Text) || !cmbEquipmentName.Items.Contains(cmbEquipmentName.Text))
            //{
            //    //메세지 박스 띄움
            //    btnSearch.Enabled = true; //2012-12-17 김성원 일단 클릭하면 없어져서 넣음
            //    return;
            //}

            CLogger logger = CLogManager.Instance.GetLogger("ALARM", "ALARM");
            if (logger == null)
            {
                //메세지 박스 띄움
                btnSearch.Enabled = true; //2012-12-17 김성원 일단 클릭하면 없어져서 넣음
                return;
            }

            LogDataRead(logger.GetLoggerInfo("ALARM", "ALARM"));
        }

        private void APDDataAdd()
        {
            _dt.Columns.Add(COLUMNNAME_DATETIME);
            _dt.Columns.Add(COLUMNNAME_CATEGORY);
            _dt.Columns.Add(COLUMNNAME_EQPNAME);
            _dt.Columns.Add(COLUMNNAME_CONTENTS);
            //cmbEquipmentName.Text = "EQP01";
            //if (string.IsNullOrEmpty(cmbEquipmentName.Text) || !cmbEquipmentName.Items.Contains(cmbEquipmentName.Text))
            //{
            //    //메세지 박스 띄움
            //    btnSearch.Enabled = true; //2012-12-17 김성원 일단 클릭하면 없어져서 넣음
            //    return;
            //}

            CLogger logger = CLogManager.Instance.GetLogger("APD", "APD");
            if (logger == null)
            {
                //메세지 박스 띄움
                btnSearch.Enabled = true; //2012-12-17 김성원 일단 클릭하면 없어져서 넣음
                return;
            }

            LogDataRead(logger.GetLoggerInfo("APD", "APD"));
        }

        private void InterfaceDataAdd()
        {
            _dt.Columns.Add(COLUMNNAME_DATETIME);
            _dt.Columns.Add(COLUMNNAME_EQPNAME);
            _dt.Columns.Add(COLUMNNAME_OWNERNAME);
            _dt.Columns.Add(COLUMNNAME_STATE);
            _dt.Columns.Add(COLUMNNAME_CONTENTS);

            CLogger logger = CLogManager.Instance.GetLogger("LOADER", "LOADER");
            if (logger == null)
            {
                //메세지 박스 띄움
                btnSearch.Enabled = true; //2012-12-17 김성원 일단 클릭하면 없어져서 넣음
                return;
            }

            LogDataRead(logger.GetLoggerInfo("LOADER", "LOADER"));
        }
        private void GUIDataAdd()
        {
            _dt.Columns.Add(COLUMNNAME_DATETIME);
            _dt.Columns.Add(COLUMNNAME_CATEGORY);
            _dt.Columns.Add(COLUMNNAME_EQPNAME);
            _dt.Columns.Add(COLUMNNAME_CONTENTS);
            _dt.Columns.Add("비고");

            CLogger logger = CLogManager.Instance.GetLogger("SYSTEM", "UI");

            if (logger == null)
            {
                //메세지 박스 띄움
                btnSearch.Enabled = true; //2012-12-17 김성원 일단 클릭하면 없어져서 넣음
                return;
            }

            LogDataRead(logger.GetLoggerInfo("SYSTEM", "UI"));

        }
        private void EXCEPTIOnDataAdd()
        {
            _dt.Columns.Add(COLUMNNAME_DATETIME);
            _dt.Columns.Add(COLUMNNAME_CATEGORY);
            _dt.Columns.Add(COLUMNNAME_EQPNAME);
            _dt.Columns.Add(COLUMNNAME_CONTENTS);
            //_dt.Columns.Add("비고");

            CLogger logger = CLogManager.Instance.GetLogger("SYSTEM", "EXCEPTION");

            if (logger == null)
            {
                //메세지 박스 띄움
                btnSearch.Enabled = true; //2012-12-17 김성원 일단 클릭하면 없어져서 넣음
                return;
            }

            LogDataRead(logger.GetLoggerInfo("SYSTEM", "EXCEPTION"));

        }

        private void COREDataAdd()
        {
            _dt.Columns.Add(COLUMNNAME_DATETIME);
            _dt.Columns.Add(COLUMNNAME_CATEGORY);
            _dt.Columns.Add(COLUMNNAME_EQPNAME);
            _dt.Columns.Add(COLUMNNAME_CONTENTS);
            _dt.Columns.Add("비고");

            CLogger logger = CLogManager.Instance.GetLogger("SYSTEM", "DEBUG");

            if (logger == null)
            {
                //메세지 박스 띄움
                btnSearch.Enabled = true; //2012-12-17 김성원 일단 클릭하면 없어져서 넣음
                return;
            }

            LogDataRead(logger.GetLoggerInfo("SYSTEM", "DEBUG"));

        }

        private void GlassDataAdd()
        {
            _dt.Columns.Add(COLUMNNAME_DATETIME);
            _dt.Columns.Add(COLUMNNAME_CATEGORY);
            _dt.Columns.Add(COLUMNNAME_STATE);
            _dt.Columns.Add(COLUMNNAME_MESSAGE);

            CLogger logger = CLogManager.Instance.GetLogger("SYSTEM", "METERIAL_DATA");

            if (logger == null)
            {
                //메세지 박스 띄움
                btnSearch.Enabled = true; //2012-12-17 김성원 일단 클릭하면 없어져서 넣음
                return;
            }

            LogDataRead(logger.GetLoggerInfo("SYSTEM", "METERIAL_DATA"));

        }

        private void EqpInterfaceDataAdd()
        {
            _dt.Columns.Add(COLUMNNAME_DATETIME);
            _dt.Columns.Add(COLUMNNAME_CATEGORY);
            _dt.Columns.Add(COLUMNNAME_ID);
            _dt.Columns.Add(COLUMNNAME_STATE);
            _dt.Columns.Add(COLUMNNAME_MESSAGE);

            CLogger logger = CLogManager.Instance.GetLogger("SYSTEM", "MESSAGE");

            if (logger == null)
            {
                //메세지 박스 띄움
                btnSearch.Enabled = true; //2012-12-17 김성원 일단 클릭하면 없어져서 넣음
                return;
            }

            LogDataRead(logger.GetLoggerInfo("SYSTEM", "MESSAGE"));

        }
        
        private void MESDataAdd()
        {

            _dt.Columns.Add(COLUMNNAME_DATETIME);
            _dt.Columns.Add(COLUMNNAME_CATEGORY);
            _dt.Columns.Add(COLUMNNAME_EQPNAME);
            _dt.Columns.Add(COLUMNNAME_CONTENTS);
            _dt.Columns.Add("비고");

            CLogger logger = CLogManager.Instance.GetLogger("TIBRV", "TIBRV");

            if (logger == null)
            {
                //메세지 박스 띄움
                btnSearch.Enabled = true; //2012-12-17 김성원 일단 클릭하면 없어져서 넣음
                return;
            }

            LogDataRead(logger.GetLoggerInfo("TIBRV", "TIBRV"));
        }

        private void LogDataRead(ILoggerInfo loggerInfo)
        {
            string subFolderName = string.IsNullOrEmpty(loggerInfo.FolderNamingRule) ? "" : @"\" + dtpFindDate.Value.ToString(loggerInfo.FolderNamingRule) + @"\";
            string filePath = string.Empty;
            filePath += string.Format(@"{0}\{1}{2}", loggerInfo.FilePath, loggerInfo.LogName, subFolderName);
            filePath += string.Format("{0}_{1}.{2}", loggerInfo.LogName, dtpFindDate.Value.ToString("yyyyMMdd"), loggerInfo.FileExt);

            if (File.Exists(filePath))
            {
                completedCount = 1; //thread 돌리는 개수가 1개임.
                currnetProcessingCount = 0;

                _selectedLogPath = filePath;

                requestProgressBar.Clear();
                requestProgressBar.Message1 = "LOG를 읽는 중 입니다. 잠시 기다려 주십시오.";
                requestProgressBar.Message2 = "";

                requestProgressBar.Location = new Point((this.Width / 2) - (requestProgressBar.Width / 2), (this.Height / 2) - (requestProgressBar.Height));
                requestProgressBar.BringToFront();
                requestProgressBar.Visible = true;

                Thread logDisplayThread = new Thread(new ThreadStart(LogDisplay));
                logDisplayThread.Name = loggerInfo.LogKey + "_Display Thread";
                logDisplayThread.Priority = ThreadPriority.Normal;
                logDisplayThread.IsBackground = true;
                logDisplayThread.Start();

            }
            else
            {
                //메세지 박스 띄움
                btnSearch.Enabled = true;
                MessageBox.Show("조회된 로그가 없습니다");

                return;
            }
        }

        private void ExcelFileSave()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "로그파일 저장";
            dialog.FileName = string.Format("{0}_{1}", _selectedLogName, DateTime.Now.ToString("yyyyMMddHHmmssfff"));
            dialog.DefaultExt = "csv";
            dialog.InitialDirectory = Environment.CurrentDirectory;

            DialogResult result = dialog.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            try
            {
                foreach (DataGridViewRow row in dgvLog.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {

                    }
                }

                //저장 로직
            }
            catch (Exception ex)
            {
                CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "SYSTEM", ex));
            }

            btnSearch.Enabled = true; //2012-12-17 김성원 일단 클릭하면 없어져서 넣음
        }

        private object _dataTableLock = new object();

        private void LogDisplay()
        {
            try
            {
                lock (_dataTableLock)
                {

                    if (string.IsNullOrEmpty(_selectedLogPath)) return;

                    FileStream fs = File.Open(_selectedLogPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    StreamReader sr = new StreamReader(fs, Encoding.Default);

                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        if (string.IsNullOrEmpty(line))
                            continue;

                        string[] split = line.Split('\t');

                        if (split.Length > _dt.Columns.Count)
                        {
                            int gap = split.Length - _dt.Columns.Count;
                            for (int i = 0; i < gap; i++)
                            {
                                _dt.Columns.Add("COLUMN" + (_dt.Columns.Count + i + 1).ToString());
                            }
                        }

                        List<string> temp = new List<string>();

                        for (int j = 0; j < _dt.Columns.Count; j++)
                        {
                            if (split.Length > j)
                            {
                                temp.Add(split[j]);
                            }
                            else
                            {
                                temp.Add("");
                            }
                        }
                       
                        _dt.Rows.Add(temp.ToArray());
                    }

                    UpdateDataGridView(_dt.Copy());

                    sr.Close();

                }
            }

            catch (Exception ex)
            {
                UpdateDataGridView(new DataTable());

                CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "SYSTEM", ex));
            }
        }

        private int completedCount = 0;
        private int currnetProcessingCount = 0;
        private string _selectedLogName = "";
        private Dictionary<string, int> _columnWidthConfigs = new Dictionary<string, int>();

        private void UpdateDataGridView(DataTable dt)
        {
            if (this.dgvLog.InvokeRequired)
            {
                delegateDataGridViewRefresh dgvUpdate = new delegateDataGridViewRefresh(UpdateDataGridView);
                this.BeginInvoke(dgvUpdate, dt);
            }
            else
            {
                dgvLog.DataSource = dt;


                foreach (KeyValuePair<string, int> item in _columnWidthConfigs)
                {
                    if (dgvLog.Columns.Contains(item.Key))
                        dgvLog.Columns[item.Key].Width = item.Value;
                }

                if (completedCount == ++currnetProcessingCount) //2012-12-17 김성원 PoistionLog Thread 개수와 일치하면 완료로 간주
                {
                    requestProgressBar.Visible = false;
                    requestProgressBar.Clear();

                    btnSearch.Enabled = true;
                }
                       
                dgvLog.Sort(dgvLog.Columns[0], ListSortDirection.Descending);
            }
        }

        #endregion

        #region //event's 처리기

        private void rdb_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btn_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = sender as Button;
                switch (btn.Name)
                {
                    case "btnPrevious":
                        this.dtpFindDate.Value = dtpFindDate.Value.AddDays(-1);
                        break;
                    case "btnNext":
                        this.dtpFindDate.Value = dtpFindDate.Value.AddDays(1);
                        break;
                    case "btnSearch":
                        this.btnSearch.Enabled = false;

                        LogDataClear();

                        if (rdbInterface.Checked)
                        {
                            InterfaceDataAdd();
                        }
                        else if (rdbAlarm.Checked)
                        {
                            AlarmDataAdd();
                        }
                        //else if (rdbAPD.Checked)
                        //{
                        //    APDDataAdd();
                        //}
                        //else if (rdbMES.Checked)
                        //{
                        //    MESDataAdd();
                        //}
                        else if (rdbGUI.Checked)
                        {
                            GUIDataAdd();
                        }
                        //else if (rdbEXCEPTIOn.Checked)
                        //{
                        //    EXCEPTIOnDataAdd();
                        //}
                        else if (rdbCORE.Checked)
                        {
                            COREDataAdd();
                        }
                        else if (rdbEqpInterface.Checked)
                        {
                            EqpInterfaceDataAdd();
                        }
                        else if (rdbGlassData.Checked)
                        {
                            GlassDataAdd();
                        }
                        else
                        {
                            MessageBox.Show("로그 종류를 선택하십시오.", "사용자 확인", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.btnSearch.Enabled = true;
                        }

                        break;
                    case "btnExcelFileSave":
                        ExcelFileSave();
                        MessageBox.Show("Excel 저장이 완료 되었습니다", "사용자 확인", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                this.btnSearch.Enabled = true;
                CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "SYSTEM", ex));
            }
        }

        private void dtpFindDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                _searchDate = this.dtpFindDate.Value.ToString("yyyy-mm-dd");
            }
            catch (Exception ex)
            {

                CLogManager.Instance.Log(new CExceptionLogFormat(Catagory.Error, "SYSTEM", ex));
            }
        }

        #endregion

        private void dgvLog_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

            object value = dgvLog.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

            if (value == null)
                return;

            rtbDataDetailView.Clear();
            string temp = value.ToString();
            temp = temp.Replace(',', '\n');
            //if (rdbPosition.Checked || rdbMES.Checked)
            //{
            //    temp = temp.Replace(' ', '\n');
            //}
            rtbDataDetailView.AppendText(temp);
        }

        private void chkDataPanelVisible_CheckedChanged(object sender, EventArgs e)
        {
            pnlDataPanelBack.Visible = chkDataPanelVisible.Checked;
        }

    }
}
