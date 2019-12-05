using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOFD.Logger;
using SmartDevice.UTILS;
using SOFD.Properties;
using SOFD.Core;
using YANGSYS.ControlLib;


using SOFD.Component.Interface;
using System.Windows.Forms;

using System.Drawing;
using MainLibrary;
using MainLibrary.Manager;
using System.ComponentModel;
using YANGSYS.Biz.CommandHandler;
using SOFD.Driver;

using System.Threading;
using SOFD.Component;
using SOFD.InterfaceTimeout;
using YANGSYS.Biz.Programs;
using System.Runtime.Remoting;
using SOFD.Global.Manager;
using SmartDevice;

using SOFD.Global;
using SOFD.Global.Interface;


namespace YANGSYS.Biz
{
    public class CBiz : ABizLogic
    {
        private CMain _main = null;
        private System.Windows.Forms.Control _control = null;
        public CBiz()
        {

        }
        public override void Init(SOFD.BasicCore.CBasicCore initializedMain, Control control)
        {
            _main = initializedMain as CMain;
            _control = control;

            CSubject subject = CUIManager.Inst.GetData("ucTitle");
            subject.SetValue("Title", _main.SystemConfig.Title);
            subject.SetValue("ShortVersion", _main.SystemConfig.SoftVersion);
            subject.SetValue("DispSiteName", _main.SystemConfig.DispSiteName);
            subject.SetValue("ProjectName", _main.SystemConfig.ProjectName);
            subject.SetValue("SiteName", _main.SystemConfig.SiteName);
            subject.SetValue("UserName", _main.SystemConfig.UserAccount);
            subject.SetValue("SystemMode", _main.SystemConfig.SystemMode);
            subject.Notify();

            AddCommand();
            AddProgram();
        }

        #region Notify

        void _main_OnFatalMessageOccurrenced(object sender, string title, string contents)
        {
            MessageBox.Show(contents, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.ExitThread();
        }

        private delegate bool CheckConfirmHandler(string title, string text);
        private bool CheckConfirm(string title, string text)
        {
            //CheckConfirmHandler del = new CheckConfirmHandler(InvokeCheckConfirm);
            //return (bool)this.Invoke(del, title, text);
            return true;
        }

        ///// <summary>
        ///// 특별히 지정되지 않은 컨트롤이면 컨트롤 이름을 사용 (ucCimStatus), 지정된 (Oven, Cooling 등) 컨트롤은 ControlName을 사용 바랍니다.
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="sender"></param>
        ///// <param name="keyOrControlName"></param>
        ///// <returns></returns>
        //public T GetWidget<T>(object sender, string keyOrControlName)
        //{
        //    foreach (Control c in _control.Controls)
        //    {
        //        if (c == null)
        //            continue;

        //        if (c.Name == keyOrControlName)
        //            return (T)Convert.ChangeType((object)c, typeof(T));
        //        Console.WriteLine(c.GetType().ToString() + " " + c.Name);
        //    }
        //    return default(T);
        //}

        /// <summary>
        /// B2 사양서에 PLC ON을 OFF 하도록 되어있음. 혹 전체 OFF를 안해도 된다면 여기를 주석처리하면됨.
        /// </summary>
        /// <param name="main"></param>
        /// <param name="controlName"></param>
        /// <param name="attribute"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool ScanBitOnOff(CMain main, string controlName, string attribute, bool value)
        {
            CScanControlProperties scan = _main.SCANCONTEROLS.GetProperty(controlName, attribute);
            if (scan == null)
                return false;
            _main.MelsecNetManager.MelsecNetBitOnOff(scan.ScanControlName, scan.ScanAttribute, scan.ScanArea, scan.ScanDeviceType, false);
            return true;
        }
        #endregion

        private void AddProgram()
        {
            string controlName1= "EPM01";
            string controlName2= "INDEXER01";
            CControlComponent componet1 = _main.GetComponent(controlName1);
            CControlComponent componet2 = _main.GetComponent(controlName2);

            List<string> typeNames = new List<string>(); //설정 파일로 빠질 예정
            typeNames.Add("YANGSYS.Biz.Programs.AlarmResetStatusReport");
            typeNames.Add("YANGSYS.Biz.Programs.AlarmSetStatusReport");
            typeNames.Add("YANGSYS.Biz.Programs.CIMConnectionModeNotification");
            typeNames.Add("YANGSYS.Biz.Programs.DateTImeSetCommand");
            typeNames.Add("YANGSYS.Biz.Programs.EqpStatusReport");
            typeNames.Add("YANGSYS.Biz.Programs.EquipmentAutoModeNotification");
            typeNames.Add("YANGSYS.Biz.Programs.EquipmentModeChangeCommand");
            typeNames.Add("YANGSYS.Biz.Programs.EquipmentModeChangeReport");
            typeNames.Add("YANGSYS.Biz.Programs.LDBuzzONCommand");
            typeNames.Add("YANGSYS.Biz.Programs.OperatorCallCommand");
            typeNames.Add("YANGSYS.Biz.Programs.PPIDRecipeMapChangeCommand");
            typeNames.Add("YANGSYS.Biz.Programs.PPIDRecipeMapReport");
            typeNames.Add("YANGSYS.Biz.Programs.PPIDRecipeMapRequestCommand");
            typeNames.Add("YANGSYS.Biz.Programs.RecipeRequestCommand");
            typeNames.Add("YANGSYS.Biz.Programs.TerminalTextCommand");
            typeNames.Add("YANGSYS.Biz.Programs.CycleProgram_WHTM");
            typeNames.Add("YANGSYS.Biz.Programs.RecipeChangeAuthorizarion");
            typeNames.Add("YANGSYS.Biz.Programs.RecipeChangeReport");
            typeNames.Add("YANGSYS.Biz.Programs.CurrentPPIDRecipeIdReport");
            typeNames.Add("YANGSYS.Biz.Programs.CLinkSignalType2_WHTM");
            typeNames.Add("YANGSYS.Biz.Programs.CLinkSignalType11_WHTM");
            typeNames.Add("YANGSYS.Biz.Programs.CLinkSignalType6_WHTM");
            typeNames.Add("YANGSYS.Biz.Programs.ForwardReceivedJobReport");
            typeNames.Add("YANGSYS.Biz.Programs.ForwardSentOutJobReport");
            typeNames.Add("YANGSYS.Biz.Programs.GlassDataRequest_WHTM");
            typeNames.Add("YANGSYS.Biz.Programs.ProcessDataReport");
            typeNames.Add("YANGSYS.Biz.Programs.RemovedJobReport");
            typeNames.Add("YANGSYS.Biz.Programs.VCRJobDataReport");
            //typeNames.Add("YANGSYS.Biz.Programs.VCRStatusReport");
            typeNames.Add("YANGSYS.Biz.Programs.JobJudgeChange");
            typeNames.Add("YANGSYS.Biz.Programs.TrackingJobReport");
            //typeNames.Add("YANGSYS.Biz.Programs.CIMMessageClearCommand");
            //typeNames.Add("YANGSYS.Biz.Programs.CIMMessageConfirmReport");
            //typeNames.Add("YANGSYS.Biz.Programs.CIMMessageSetCommand");
            //typeNames.Add("YANGSYS.Biz.Programs.CIMModeChangeCommand");
            //typeNames.Add("YANGSYS.Biz.Programs.CLinkSignalType1");
            //typeNames.Add("YANGSYS.Biz.Programs.CLinkSignalType10");
            //typeNames.Add("YANGSYS.Biz.Programs.CLinkSignalType5");
            //typeNames.Add("YANGSYS.Biz.Programs.CVDataReport");
            //typeNames.Add("YANGSYS.Biz.Programs.CVReportTimeChangeCommand");
            //typeNames.Add("YANGSYS.Biz.Programs.CycleProgram");
            //typeNames.Add("YANGSYS.Biz.Programs.DataInformationReportbyLocation");
            //typeNames.Add("YANGSYS.Biz.Programs.DVDataReport");
            //typeNames.Add("YANGSYS.Biz.Programs.GlassDataChangeReport");
            //typeNames.Add("YANGSYS.Biz.Programs.GlassDataHandler");
            //typeNames.Add("YANGSYS.Biz.Programs.GlassDataRequest");
            //typeNames.Add("YANGSYS.Biz.Programs.AlarmSetEvent");
            //typeNames.Add("YANGSYS.Biz.Programs.AlarmResetEvent");
            //typeNames.Add("YANGSYS.Biz.Programs.LoadingStopRelease");
            //typeNames.Add("YANGSYS.Biz.Programs.LoadingStopRequest");
            typeNames.Add("YANGSYS.Biz.Programs.MachineHeartbeatSignal");
            //typeNames.Add("YANGSYS.Biz.Programs.MachineModeChangeCommand");
            //typeNames.Add("YANGSYS.Biz.Programs.MachineStatusReport");
            //typeNames.Add("YANGSYS.Biz.Programs.MachineTimeSetCommand");
            //typeNames.Add("YANGSYS.Biz.Programs.ProcessEndReport");
            //typeNames.Add("YANGSYS.Biz.Programs.ProcessStartReport");
            //typeNames.Add("YANGSYS.Biz.Programs.ReceivedJobReport");
            //typeNames.Add("YANGSYS.Biz.Programs.RecipeParameterDataDownloadRequest");
            //typeNames.Add("YANGSYS.Biz.Programs.RecipeParameterDataRequest");
            //typeNames.Add("YANGSYS.Biz.Programs.ScrapJobReport");
            //typeNames.Add("YANGSYS.Biz.Programs.SentOutJobReport");
            //typeNames.Add("YANGSYS.Biz.Programs.StatusVariableDataReport");
            //typeNames.Add("YANGSYS.Biz.Programs.VCREnableModeChangeReport");
            typeNames.Add("YANGSYS.Biz.Programs.YANGSYSMessageHandler");
            //typeNames.Add("YANGSYS.Biz.Programs.StoredJobReport");
            //typeNames.Add("YANGSYS.Biz.Programs.FetchedOutJobReport");
            typeNames.Add("YANGSYS.Biz.Programs.SV_DataReport");

            foreach (string item in typeNames)
            {
                CProgramManager.Inst.AddProgram("YANGSYS.Biz.WHTM.dll", item, new object[] { _main, componet1, componet2 }, false);
            }
        }

        private void AddCommand()
        {
            string controlName1 = "EPM01";
            string controlName2 = "INDEXER01";
            CControlComponent componet1 = _main.GetComponent(controlName1);
            CControlComponent componet2 = _main.GetComponent(controlName2);

            ACommand command = null;
            ObjectHandle oh = null;

            oh = Activator.CreateInstanceFrom("YANGSYS.Biz.WHTM.dll", "YANGSYS.Biz.CommandHandler.CMenuGroupCommand");
            command = oh.Unwrap() as ACommand;
            command.AddArgs(new object[] { _main, componet1 }, false);
            command.Init(); CUIManager.Inst.AddCommand(command);
            oh = Activator.CreateInstanceFrom("YANGSYS.Biz.WHTM.dll", "YANGSYS.Biz.CommandHandler.CShutdownCommand");
            command = oh.Unwrap() as ACommand;
            command.AddArgs(new object[] { _main, componet1 }, false);
            command.Init(); CUIManager.Inst.AddCommand(command);
            oh = Activator.CreateInstanceFrom("YANGSYS.Biz.WHTM.dll", "YANGSYS.Biz.CommandHandler.CTitleGroupCommand");
            command = oh.Unwrap() as ACommand;
            command.AddArgs(new object[] { _main, componet1 }, false);
            command.Init(); CUIManager.Inst.AddCommand(command);
            oh = Activator.CreateInstanceFrom("YANGSYS.Biz.WHTM.dll", "YANGSYS.Biz.CommandHandler.CRequestGroupCommand");
            command = oh.Unwrap() as ACommand;
            command.AddArgs(new object[] { _main, componet1 }, false);
            command.Init(); CUIManager.Inst.AddCommand(command);
        }

        void TestMethod()
        {

        }

        void Seq()
        {

        }
    }
}

