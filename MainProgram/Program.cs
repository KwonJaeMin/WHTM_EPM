using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using System.Diagnostics;
using System.Threading;
using SOFD.Gui.Window;

namespace MainProgram
{
    static class Program
    {

        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

                if(CheckMultiExecution() == false)
                    Application.Run(CLoader.Loader.GetForm());
            }
            catch (Exception ex)
            {
                throw new Exception("오류로 인해 응용 프로그램이 종료 되었습니다!", ex);
            }
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;

            MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace, "Unhandled exception !!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message + Environment.NewLine + e.Exception.StackTrace, "Thread exception !!",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 중복 실행 검사를 실시 합니다. 중복=true, DEBUG 모드에서는 false를 반환
        /// </summary>
        /// <returns></returns>
        static bool CheckMultiExecution()
        {
            try
            {
                Process currentProcess = Process.GetCurrentProcess();
                if(currentProcess.ProcessName.Contains(".vshost"))
                    return false;

                Process[] process = Process.GetProcessesByName(currentProcess.ProcessName);

                if (process == null || process.Length <= 0)
                    return true;

                int processId = 0;
                foreach (Process item in process)
                {
                    if (item != null && item.Id != currentProcess.Id)
                    {
                        processId = item.Id;
                        break;
                    }
                }

                //System.Threading.Timer t = new System.Threading.Timer(new TimerCallback(Terminater));
                //t.Change(10000, System.Threading.Timeout.Infinite);
                if (processId != 0)
                {
                    MessageBox.Show(string.Format("{0} PROCESS ID로 이미 실행 중인 프로그램이 있습니다!", processId), "중복 실행 확인", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true;
                }
            }
            catch
            {
                MessageBox.Show(string.Format("중복 실행 검사 도중 오류 발생"), "오류발생", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return false;
        }

        static void Terminater(object sender)
        {
            try
            {
                Process.GetCurrentProcess().Kill();
            }
            catch (Exception ex)
            { 
                try
                {

                    string errorMsg = "An application error occurred. Please contact the adminstrator " +
                        "with the following information:\n\n";

                    // Since we can't prevent the app from terminating, log this to the event log.
                    if (!EventLog.SourceExists("TerminaterEMPException"))
                    {
                        EventLog.CreateEventSource("TerminaterEMPException", "Application");
                    }

                    // Create an EventLog instance and assign its source.
                    EventLog myLog = new EventLog();
                    myLog.Source = "TerminaterEMPException";

                    myLog.WriteEntry(errorMsg + ex.Message + "\n\nStack Trace:\n" + ex.StackTrace, EventLogEntryType.Error);
                }
                catch (Exception exc)
                {
                    try
                    {
                        MessageBox.Show("Fatal Non-UI Error",
                            "Fatal Non-UI Error. Could not write the error to the event log. Reason: "
                            + exc.Message, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    finally
                    {
                        Application.Exit();
                    }
                }
            }
        }
    }
}
