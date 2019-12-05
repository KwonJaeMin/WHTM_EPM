using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MainLibrary;
using System.Windows.Forms;
using SOFD.Component;
using System.Runtime.Remoting;
using SOFD.File;
using SOFD.Global;

namespace MainProgram
{
    public class CLoader
    {
        private static CLoader _loader = null;
        public static CLoader Loader
        {
            get
            {
                if (_loader == null)
                    _loader = new CLoader();

                return _loader;
            }
        }

        CMain _main = null;
        Form _form = null;
        ABizLogic _biz = null;

        public Form GetForm()
        {
            if (_form != null)
                return _form;

            Form from = null;
            string assemblyFile = "YANGSYS.UI.WHTM.DLL";
            string typeName = "YANGSYS.UI.WHTM.FormMain";
            ObjectHandle handle = Activator.CreateInstanceFrom(assemblyFile, typeName);
            if (handle == null)
            {
                from = new SOFD.Gui.Window.frmSimpleMain();
            }
            _form = handle.Unwrap() as Form;

            return _form;
        }
        public ABizLogic GetBiz(CMain initializedMain, System.Windows.Forms.Control control)
        {

            string assemblyFile = "YANGSYS.Biz.WHTM.DLL";
            string typeName = "YANGSYS.Biz.CBiz";
            ObjectHandle handle = Activator.CreateInstanceFrom(assemblyFile, typeName);

            if (handle == null)
            {
                _form = new SOFD.Gui.Window.frmSimpleMain();
            }

            ABizLogic biz = handle.Unwrap() as ABizLogic;
            biz.Init(initializedMain, control);

            return biz;
        }
        
        public CLoader()
        {
            _form = GetForm();

            _main = new CMain();
            _main.OnProgramEnd += new SOFD.BasicCore.delegateProgramEnd(_main_OnProgramEnd);
            _main.Init();

            _biz = GetBiz(_main, _form);

            //_form.ProgramName = _main.ProgramName;
            //_form.Version = _main.Version;
            //_form.ShutDown += new delegateShutDownEventHandler(form_ShutDown);

            //foreach (SOFD.Gui.Window.IFrame frame in _form.FrameList.Values)
            //{
            //    frame.OnRequestParentService += new SOFD.Gui.Window.delegateParentFormService(frame_OnRequestParentService);
            //}
            //if (UCBaseFrame.Widgets.ContainsKey("TITLE:COMMSTATUS"))
            //{
            //    UCWidget widget = UCBaseFrame.Widgets["TITLE:COMMSTATUS"];

            //    if (widget is ucConnectionStatus)
            //        status = widget as ucConnectionStatus;
            //}

            //List<ASubsystemControl> controls = _main.GetCommControls<ASubsystemControl>();
            //foreach (ASubsystemControl control in controls)
            //{
            //    //if (!string.IsNullOrEmpty(control.ConnectEQP) || control.ConnectEQP == control.ControlName)
            //    //    continue;

            //    if (control.ModelType == "GROUP" || !(control is IComm))//!string.IsNullOrEmpty(control.ConnectEQP) || !(control is IComm))
            //    {
            //        if (control.IsScanType)
            //            control.ScanStart();
            //        continue;
            //    }

            //    IComm commControl = control as IComm;
            //    commControl.Connected += new delegateCommEventHandler(commControl_CommStateChanged);
            //    commControl.Disconnected += new delegateCommEventHandler(commControl_CommStateChanged);


            //    try
            //    {
            //        if (status != null)
            //        {
            //            status.AddAlias(commControl.CommName, commControl.Alias);
            //            status.StateChange(commControl.CommName, commControl.Enable, commControl.LogicalDisconnect);
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("통신모듈이 포함된 컨트롤을 처리 중 오류가 발생 했습니다. \r\n" + ex.Message + ex.StackTrace);
            //    }

            //    try
            //    {
            //        commControl.Init();
            //        commControl.Open();

            //        if (control.IsScanType)
            //            control.ScanStart();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("통신모듈이 포함된 컨트롤을 처리 중 오류가 발생 했습니다. \r\n" + ex.Message + ex.StackTrace);
            //    }

            //}
        }

        void _main_OnProgramEnd()
        {
            if(_form != null)
                _form.Close();

            Application.Exit();
        }

        //frmConnectionControl form = null;
        private void frame_OnRequestParentService(string sService, params object[] args)
        {
            if (sService == "Recipe")
            {
                //if (args == null || args.Length < 2)
                //    return;

                //string command = (string)args[0];

                //if (command == "Start")
                //{
                //    if (args.Length <= 1)
                //        return;

                //    string recipeName = (string)args[1];

                //    int result = _main.RecipeStart(recipeName);
                //    if (result != 0)
                //    {
                //        string description = CExceptionManager.Instance.GetErrorDesc(result);
                //        MessageBox.Show(string.Format("{0} RECIPE는 아래와 같은 이유로 Start를 수행 할 수 없습니다. \n\n{1}", recipeName,
                //            description, "RECIPE START ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error));
                //    }
                //}
                //else if (command == "Stop")
                //{
                //    if (args.Length <= 1)
                //        return;

                //    string recipeName = (string)args[1];
                //    _main.RecipeStop(recipeName);

                //}
            }
            else if (sService == "Title")
            {
                //if (args != null && args.Length > 0)
                //{
                //    string name = (string)args[0];

                //    if (name == "TITLE:COMMSTATUS")
                //    {
                //        if (form == null)
                //        {
                //            form = new frmConnectionControl(_main.GetCommControls<IComm>());
                //            form.Show();
                //        }
                //        else
                //        {
                //            form.Show();
                //            form.Focus();
                //        }
                //    }
                //}

            }
        }

        private void _main_ScanControlPropertyChanged(object sender, string controlName, string attributeName, string value)
        {
            if (_form == null)
                return;

            //List<SOFD.Gui.Widget2.UCBaseObject> baseObjects = _form.GetWidget(controlName);
            //if (baseObjects.Count > 0)
            //{
            //    foreach (SOFD.Gui.Widget2.UCBaseObject baseObject in baseObjects)
            //    {
            //        baseObject.UpdateWidget.BeginInvoke(sender, attributeName, value, null, null);
            //    }
            //}
        }

        private void baseObject_WidgetMouseEvent(object obj, string elementId, MouseEventArgs e, bool down)
        {
            //CBasicControl control = _main.GetControl(elementId);
            //IComm comm = _main.GetCommControl<IComm>(elementId);
            //if (comm != null && !down)
            //{
            //    if (e.Button == MouseButtons.Right)
            //    {
            //        comm.Execute("UI:ManualControl.Show");
            //    }
            //    else if (e.Button == MouseButtons.Left)
            //    {
            //        comm.Execute("UI:ControlPanel.Show");
            //    }
            //}
        }

        private void form_ShutDown()
        {
            _main.ShutDown();
        }

        //ucConnectionStatus status = null;
        //private void commControl_CommStateChanged(object sender, CommEventArgs ce)
        //{
        //    if (status != null)
        //        status.StateChange(ce.CommName, ce.IsConnected, ce.LogicalDisconnect);
        //}

        private void FileManager_OnControlAddChange(object obj)
        {
            //if (obj is IComm)
            //{
            //    if (UCBaseFrame.Widgets.ContainsKey("TITLE:STATE"))
            //    {
            //        UCWidget widget = UCBaseFrame.Widgets["TITLE:STATE"];
            //    }
            //}
        }
    }
}
