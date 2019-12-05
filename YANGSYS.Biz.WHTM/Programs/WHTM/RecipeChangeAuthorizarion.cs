using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YANGSYS.ControlLib;
using SOFD.Properties;
using SOFD.InterfaceTimeout;
using MainLibrary;
using SOFD.Component;
using SOFD.Component.Interface;

using SOFD.Logger;
using SOFD.Global.Manager;
using System.Threading;


namespace YANGSYS.Biz.Programs
{

    public class RecipeChangeAuthorizarion : AProgram
    {
        private CMain _main = null;
        private bool _enable = false;

        //BC
        private CScanControlProperties IB_RECIPE_CHANGE_AUTHORIZATION = null; //RV_B_RecipeChangeAuthorization_L3ToBC
        private CScanControlProperties IW_RECIPE_CHANGE_PERMISSION_USER_ACCOUNT = null; //SD_W_RecipeChangePermission_BCToL3.UserAccount
        private CScanControlProperties IW_RECIPE_CHANGE_PERMISSION_PERMISSION_CODE = null; //SD_W_RecipeChangePermission_BCToL3.PermissionCode

        //PROBE CIM
        private CPLCControlProperties OB_RECIPE_CHANGE_AUTHORIZATION = null;//RV_B_RecipeChangeAuthorization_L3ToBC
        private CPLCControlProperties OW_RECIPE_CHANGE_AUTHORIZATION_USER_ACCOUNT = null;//RV_W_RecipeChangeAuthorization_L3ToBC.UserAccount
        private CPLCControlProperties OW_RECIPE_CHANGE_AUTHORIZATION_PASSWORD = null;//RV_W_RecipeChangeAuthorization_L3ToBC.Password      

        private CScanControlProperties VI_USER_LOGIN_RECIPE = null;
        private CPLCControlProperties VO_USER_LOGIN_RECIPE_REPLY = null;

        private string _controlName = "";
        private CProbeControl _component = null;
        private const int PERMISSION_ACCEPT = 1;
        private const int PERMISSION_REJECT = 2;

        public RecipeChangeAuthorizarion()
        {
        }

        public override int Init()
        {
            _enable = true;

            //BC
            IB_RECIPE_CHANGE_AUTHORIZATION = _main.SCANCONTEROLS.GetProperty(_controlName, "IB_RECIPE_CHANGE_AUTHORIZATION");
            IW_RECIPE_CHANGE_PERMISSION_USER_ACCOUNT = _main.SCANCONTEROLS.GetProperty(_controlName, "IW_RECIPE_CHANGE_PERMISSION_USER_ACCOUNT");
            IW_RECIPE_CHANGE_PERMISSION_PERMISSION_CODE = _main.SCANCONTEROLS.GetProperty(_controlName, "IW_RECIPE_CHANGE_PERMISSION_PERMISSION_CODE");

            //PROBE CIM
            OB_RECIPE_CHANGE_AUTHORIZATION = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_RECIPE_CHANGE_AUTHORIZATION");
            OW_RECIPE_CHANGE_AUTHORIZATION_USER_ACCOUNT = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_RECIPE_CHANGE_AUTHORIZATION_USER_ACCOUNT");
            OW_RECIPE_CHANGE_AUTHORIZATION_PASSWORD = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_RECIPE_CHANGE_AUTHORIZATION_PASSWORD");

            VI_USER_LOGIN_RECIPE = _main._YANSYS_SCANCONTEROLS.GetProperty(_controlName, "VI_USER_LOGIN_RECIPE");
            VO_USER_LOGIN_RECIPE_REPLY = _main._YANSYS_PLCCONTEROLS.GetProperty(_controlName, "VO_USER_LOGIN_RECIPE_REPLY");

            this.ProgramDataList.Add(new CProgramData(this.ProgramDataList.Count, "ACCOUNT", typeof(string)));
            this.ProgramDataList.Add(new CProgramData(this.ProgramDataList.Count, "PASSWORD", typeof(string)));

            _component.ProgramsAdd(this);
            return 0;
        }

        public override int AddArgs(object[] args, bool beforeClear)
        {
            if (args == null || args.Length < 2)
                return -1;

            if ((args[0] is CMain && args[1] is CProbeControl && args[1] is CProbeControl) == false)
            {
                return -1;
            }

            if (beforeClear)
            {

            }

            _main = args[0] as CMain;
            _component = args[1] as CProbeControl;
            _controlName = _component.ControlName;
            return 0;
        }
        public override string Name
        {
            get { return "RECIPE_CHANGE_AUTHORIZATION"; }
        }

        public override string Version
        {
            get { return "ver 1.0"; }
        }

        public override string Description
        {
            get { return "장비 PPID/RECIPE 변경 REPORT 처리 프로그램"; }
        }
        public override bool Enable
        {
            get { return _enable; }
        }
        public override string Development
        {
            get { return "(주)서진정보기술"; }
        }

        public override bool IsCycle
        {
            get { return false; }
        }
        public override string SIteName
        {
            get { return "WHTM"; }
        }
        public override bool IsAsyncCall
        {
            get { return true; }
        }
        private const int T1 = 4000;
        protected override int InnerExecute()
        {
            //0~9, a~z,A~Z
            string account = ""; //5
            string password = ""; //5

            //if (IsManualExecute)
            //{
            //    account = this.ProgramDataList[0].Value.ToString();
            //    password = this.ProgramDataList[1].Value.ToString();
            //    Log(string.Format("{0}\t{1}", _component.ControlName, string.Format("PGM DATA SEND MANUAL")));
            //}
            //else
            //{
            //    string value = VI_USER_LOGIN_RECIPE.Value;
            //    string[] temp = value.Split('|');
            //    if (temp != null && temp.Length == 3)
            //    {
            //        account = temp[1];
            //        password = temp[2];
            //    }
            //}

            if (_main.SystemConfig.UserAccount == null)
                return -1;

            account = _main.SystemConfig.UserAccount;
            password = _main.SystemConfig.UserPassword;


            //받아서 처리하는 부분
            //양전자 RECIPE 가져오는 곳

            this.StatusChange(enumProgramStatus.PROCESSING);

            _main.MelsecNetMultiWordWriteByString(OW_RECIPE_CHANGE_AUTHORIZATION_USER_ACCOUNT, account, 5, ' ');
            _main.MelsecNetMultiWordWriteByString(OW_RECIPE_CHANGE_AUTHORIZATION_PASSWORD, password, 5, ' ');


            Log(string.Format("{0}\t{1}", _component.ControlName, string.Format("PGM DATA SEND - ACCOUNT={0} PASSWORD=", account, password)));

            CTimeout timeout = CTimeoutManager.GetTimeout(_controlName, T1);
            timeout.TargetOffValueCheck = true;
            timeout.Begin(OB_RECIPE_CHANGE_AUTHORIZATION, _main.CONTROLATTRIBUTES.GetProperty(IB_RECIPE_CHANGE_AUTHORIZATION.ControlName, IB_RECIPE_CHANGE_AUTHORIZATION.AttributeName) as ITimeoutResource);
            _main.MelsecNetBitOnOff(OB_RECIPE_CHANGE_AUTHORIZATION, true);
            Thread.Sleep(1000);
            IB_RECIPE_CHANGE_AUTHORIZATION.Value = true.ToString();
            string tempMsg = "";
            bool error = false;
            if(CTimeout.WaitSync(timeout, 10))
            {
                string acceptAccount = _main.MelsecNetMultiWordReadToString(IW_RECIPE_CHANGE_PERMISSION_USER_ACCOUNT);
                string permissionCode = _main.MelsecNetWordRead(IW_RECIPE_CHANGE_PERMISSION_PERMISSION_CODE);

                if (acceptAccount.Trim() == account.Trim())
                {
                    if (permissionCode == PERMISSION_ACCEPT.ToString())
                    {
                        //_main.SendData(new List<string>() { "USER_LOGIN_RECIPE_REPLY", "O" });

                        AProgram program = _component.GetProgram("PPID_RECIPE_MAP_REPORT");
                        program.ExecuteManual(_values);
                    }
                    else
                    {
                        error = true;
                        tempMsg = string.Format("[{0}] Recipe Change Authorization Reject by BC", account.Trim());
                    }
                }
                else
                {
                    error = true;
                    tempMsg = string.Format("[{0}] Recipe Change Authorization Failure! Account mismatch error. RECV={1}", account.Trim(), acceptAccount.Trim());
                }
            }
            else
            {
                error = true;
                _main.MelsecNetBitOnOff(OB_RECIPE_CHANGE_AUTHORIZATION, false);
                
                tempMsg = string.Format("[{0}] Recipe Change Authorization Failure! No response [timeout T1={1} sec]", account.Trim(), T1 / 1000);
                Log(string.Format("{0}\t{1}", _component.ControlName, tempMsg));
            }
            if (!error)
                return 0;
            
            //_main.SendData(new List<string>() { "USER_LOGIN_RECIPE_REPLY", "X" });

            Log(string.Format("{0}\t{1}", _component.ControlName, "PGM DATA DISPLAY"));

            #region 메시지 창 표시

            string receivedTime = DateTime.Now.ToString("yyyyMMdd HH:mm:ss");
            string msgId = "0";
            string message = string.Format("[{0}] {1}", this.Name, tempMsg);
            string panelNo = "1";

            CSubject subject = CUIManager.Inst.GetData("CIMMessage");
            subject.SetValue("List", new List<string>() { "MESSAGE_SET", msgId, receivedTime, message, panelNo });
            subject.Notify();

            #endregion

            return 0;
        }

        public override int ExecuteManual(Dictionary<string, string> values)
        {
            _values = values;
            InnerExecute();
            return 0;
        }
    }
}
