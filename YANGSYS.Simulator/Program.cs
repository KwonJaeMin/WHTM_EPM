using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

namespace SmartPLCSimulator
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {

            bool createdNew;
            int iPortNo = Convert.ToInt32("5556");

            if (args.Length > 0)    
                iPortNo = int.Parse(args[0]);

            //Mutex dup = new Mutex(true, "Mu", out createdNew);
            Mutex dup = new Mutex(true, iPortNo.ToString(), out createdNew);
            if (createdNew)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Application.Run(new FormMain(iPortNo));

                dup.ReleaseMutex();
            }
            else
            {
                //중복실행에 대한 처리
                MessageBox.Show("중복실행 방지");
                return;
            }

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FormMain());
        }
    }
}