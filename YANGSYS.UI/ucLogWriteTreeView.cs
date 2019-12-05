using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SOFD.Logger;

namespace YANGSYS.UI.WHTM
{
    public partial class ucLogWriteTreeView : UserControl
    {
        public const int AUTO_DELETE_COUNT = 500;
        private delegate void LogDisplayLineHandler();
        private Queue<ILogData> _logQueue = new Queue<ILogData>();

        private Timer _displayTimer;

        //private bool _forcus = false;

        private bool _logBinding = false;

        public ucLogWriteTreeView()
        {
            InitializeComponent();
            _displayTimer = new Timer();
            _displayTimer.Interval = 500;
            _displayTimer.Tick += new EventHandler(_displayTimer_Tick);
            _displayTimer.Start();
        }



        private void _displayTimer_Tick(object sender, EventArgs e)
        {
            if (CLogManager.Instance != null && _logBinding == false)
            {
                _logBinding = true;
                CLogManager.Instance.LogQueued += new LogQueuedEventHandler(Instance_LogQueued);
            }

            if (_logQueue.Count <= 0)
                return;

            if (InvokeRequired)
            {
                BeginInvoke(new LogDisplayLineHandler(LogDisplayLineAdd));
            }
            else
            {
                LogDisplayLineAdd();
            }
        }

        private void LogDisplayLineAdd()
        {
            if (_logQueue.Count <= 0)
                return;
            List<TreeNode> nodes = new List<TreeNode>();

            int count = _logQueue.Count;
            TreeNode node = null;
            for (int i = 0; i < count; i++)
            {
                if (_logQueue.Count <= 0)
                    break;
                ILogData logData = _logQueue.Dequeue();

                if (logData != null)
                {
                    node = new TreeNode(logData.GetDataForDisplay("/"));
                    //node.Tag = logData;

                    //if (logData is CMelsecLogFormat)
                    //{
                    //    if (node.Text.Contains("WRITE"))
                    //    {
                    //        node.ForeColor = Color.DimGray;
                    //    }
                    //    else
                    //    {
                    //        node.ForeColor = Color.SandyBrown;
                    //    }
                    //}
                    //else if (logData is CExceptionLogFormat)
                    //{
                       // node.ForeColor = Color.Red;
                    node.ForeColor = Color.Yellow;
                    //}
                    //else if (logData is CSchedulerLogFormat)
                    //{
                    //    node.ForeColor = Color.SteelBlue;
                    //}
                    //else if (logData is CUILogFormat)
                    //{
                    //    node.ForeColor = Color.DeepSkyBlue;
                    //}

                    string[] temp = logData.GetDataForDisplay("\t").Split('\t');

                    TreeNode innerNode = new TreeNode(string.Format("LOG INFO [NAME]={0}, [KEY]={1}, [LEVEL]={2}, [CLASS]={3}", logData.LogName.PadRight(10), logData.LogKey, logData.LogLevel.ToString(), logData.LogType));
                    foreach (string item in temp)
                    {
                        innerNode.Nodes.Add(item);
                    }
                    node.Nodes.Add(innerNode);
                    node.ToolTipText = logData.GetDataForDisplay("\n");
                    //node.Expand();
                    nodes.Add(node);
                }
            }

            if (nodes.Count <= 0)
                return;


            if (treeViewLogSpy.Nodes.Count > AUTO_DELETE_COUNT)
            {
                int removeCount = treeViewLogSpy.Nodes.Count - AUTO_DELETE_COUNT;
                for (int i = 0; i < removeCount; i++)
                {
                    if (!treeViewLogSpy.IsDisposed && treeViewLogSpy.Nodes.Count > 0)
                        treeViewLogSpy.Nodes.RemoveAt(0);
                }
            }

            treeViewLogSpy.Nodes.AddRange(nodes.ToArray());

            if (node != null && treeViewLogSpy.Focused == false) //마지막 추가된 노드로 이동.
            {
                treeViewLogSpy.SelectedNode = node;
                treeViewLogSpy.Update();

            }
        }

        private delegate void LogQueuedHandler(string logdata);

        private void Instance_LogQueued(ILogData queuedLogData)
        {
            try
            {
                //lock (this)
                //{
                _logQueue.Enqueue(queuedLogData);
                //}
            }
            catch
            {
                //Console.WriteLine("");
            }
        }

        private void treeViewLogSpy_MouseHover(object sender, EventArgs e)
        {
            //if (treeViewLogSpy.Focused)
            //{
            //    treeViewLogSpy.Scrollable = true;
            //    treeViewLogSpy.Invalidate();
            //}
            //else
            //{
            //    treeViewLogSpy.Scrollable = false;
            //    treeViewLogSpy.Invalidate();
            //}

        }

        private void treeViewLogSpy_Click(object sender, EventArgs e)
        {
            //if (treeViewLogSpy.Focused)
            //{
            //    treeViewLogSpy.Scrollable = true;
            //    treeViewLogSpy.Invalidate();
            //}
            //else
            //{
            //    treeViewLogSpy.Scrollable = false;
            //    treeViewLogSpy.Invalidate();
            //}
        }

        private void treeViewLogSpy_Leave(object sender, EventArgs e)
        {
            //treeViewLogSpy.Scrollable = false;
        }

        private void treeViewLogSpy_Enter(object sender, EventArgs e)
        {
            //treeViewLogSpy.Scrollable = true;
        }
    }
}
