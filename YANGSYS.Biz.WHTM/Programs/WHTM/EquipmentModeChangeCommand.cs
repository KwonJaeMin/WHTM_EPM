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

    public class EquipmentModeChangeCommand : AProgram
    {
        private CMain _main = null;
        private bool _enable = false;

        //BC
        private CScanControlProperties IB_EQUIPMENT_MODE_CHANGE = null;//SD_B_EquipmentModeChange_BCToL3
        private CScanControlProperties IW_EQUIPMENT_MODE = null;//SD_W_EquipmentMode_BCToL3,0
        private CScanControlProperties IW_EQUIPMENT_MODE_CHANGE_RETURN = null;//SD_W_EquipmentMode_BCToL3,1

        //PROBE CIM
        private CPLCControlProperties OB_EQUIPMENT_MODE_CHANGE = null;//SD_B_EquipmentModeChange_BCToL3
        private CPLCControlProperties OW_EQUIPMENT_MODE_CHANGE_RETURN = null;//SD_W_EquipmentMode_BCToL3,1

        private const int MASS_PRODUCTION_MODE1 = 1;         // 1: Mass Production Mode 1
        private const int MASS_PRODUCTION_MODE2 = 2;          // 2: Mass Production Mode 2
        private const int MASS_PRODUCTION_MODE3 = 3;          // 3: Mass Production Mode 3
        private const int MASS_PRODUCTION_MODE4 = 4;          // 4: Mass Production Mode 4
        private const int DUMMY_MODE = 10;                  //10: Dummy Mode
        private const int SORTING_MODE = 11;                //11: Sorting Mode
        private const int SKIP_MODE = 12;                   //12: Skip Mode
        private const int COLD_RUN_MODE_OR_CYCLE_MODE = 13; //13: Cold Run Mode(Cycle Mode)
        private const int FORCE_CLEAN_OUT_MODE =14;         //14: Force Clean Out Mode


        private const int RESULT_COMMAND_OK = 1;
        private const int RESULT_COMMAND_ERROR = 2;

        private string _controlName = "";
        private CProbeControl _component = null;

        public EquipmentModeChangeCommand()
        {
        }

        public override int Init()
        {
            _enable = true;
                    
            //BC
            IB_EQUIPMENT_MODE_CHANGE = _main.SCANCONTEROLS.GetProperty(_controlName, "IB_EQUIPMENT_MODE_CHANGE");
            IW_EQUIPMENT_MODE = _main.SCANCONTEROLS.GetProperty(_controlName, "IW_EQUIPMENT_MODE");
            IW_EQUIPMENT_MODE_CHANGE_RETURN = _main.SCANCONTEROLS.GetProperty(_controlName, "IW_EQUIPMENT_MODE_CHANGE_RETURN");

            //PROBE CIM
            OB_EQUIPMENT_MODE_CHANGE = _main.PLCCONTEROLS.GetProperty(_controlName, "OB_EQUIPMENT_MODE_CHANGE");
            OW_EQUIPMENT_MODE_CHANGE_RETURN = _main.PLCCONTEROLS.GetProperty(_controlName, "OW_EQUIPMENT_MODE_CHANGE_RETURN");

            this.ProgramDataList.Add(new CProgramData(this.ProgramDataList.Count, "EQPMODE", typeof(int)));
            this.ProgramDataList[this.ProgramDataList.Count - 1].Add(MASS_PRODUCTION_MODE1, "Mass Production Mode 1");
            this.ProgramDataList[this.ProgramDataList.Count - 1].Add(MASS_PRODUCTION_MODE2, "Mass Production Mode 2");
            this.ProgramDataList[this.ProgramDataList.Count - 1].Add(MASS_PRODUCTION_MODE3, "Mass Production Mode 3");
            this.ProgramDataList[this.ProgramDataList.Count - 1].Add(MASS_PRODUCTION_MODE4, "Mass Production Mode 4");
            this.ProgramDataList[this.ProgramDataList.Count - 1].Add(DUMMY_MODE, "Dummy Mode");
            this.ProgramDataList[this.ProgramDataList.Count - 1].Add(SORTING_MODE, "Sorting Mode");
            this.ProgramDataList[this.ProgramDataList.Count - 1].Add(SKIP_MODE, "Skip Mode");
            this.ProgramDataList[this.ProgramDataList.Count - 1].Add(COLD_RUN_MODE_OR_CYCLE_MODE, "Cold Run Mode(Cycle Mode)");
            this.ProgramDataList[this.ProgramDataList.Count - 1].Add(FORCE_CLEAN_OUT_MODE, "Force Clean Out Mode");
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
            get { return "EQUIPMENT_MODE_CHANGE"; }
        }

        public override string Version
        {
            get { return "ver 1.0"; }
        }

        public override string Description
        {
            get { return "BC에서 장비 MODE를 변경하라는 명령 처리 프로그램"; }
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
        
        protected override int InnerExecute()
        {
            string modeTemp = "";
            string resultTemp = "";
            if (IsManualExecute)
            {
                modeTemp = this.ProgramDataList[0].Value.ToString();
            }
            else
            {
                modeTemp = _main.MelsecNetWordRead(IW_EQUIPMENT_MODE);
            }

            Log(string.Format("{0}\t{1}", _component.ControlName, string.Format("PGM DATA RECV - MODE={0} RESULT={1}", modeTemp, resultTemp)));

            int mode = 0;
            int.TryParse(modeTemp, out mode);
            int result = 0;
            int.TryParse(resultTemp, out result);

            //받아서 처리하는 부분
            result = RESULT_COMMAND_OK;
            string tempMsg = "";
            bool error = false;
            switch (mode)
            {
                case MASS_PRODUCTION_MODE1:
                    _component.EquipmentMode = mode;
                    break;
                case MASS_PRODUCTION_MODE2:
                case MASS_PRODUCTION_MODE3:
                case MASS_PRODUCTION_MODE4:
                    tempMsg = string.Format("MODE={0} MASS_PRODUCTION_MODE2~4 IS UNSUPPORTED.", mode);
                    Log(string.Format("{0}\t{1}", _component.ControlName, "PGM DATA ERROR - " + tempMsg));
                    result = RESULT_COMMAND_ERROR;
                    break;
                case DUMMY_MODE:
                    tempMsg = string.Format("MODE={0} DUMMY_MODE IS UNSUPPORTED.", mode);
                    Log(string.Format("{0}\t{1}", _component.ControlName, "PGM DATA ERROR - " + tempMsg));
                    result = RESULT_COMMAND_ERROR;
                    break;
                case SORTING_MODE:
                    tempMsg = string.Format("MODE={0} SORTING_MODE IS UNSUPPORTED.", mode);
                    Log(string.Format("{0}\t{1}", _component.ControlName, "PGM DATA ERROR - " + tempMsg));
                    result = RESULT_COMMAND_ERROR;
                    break;
                case SKIP_MODE:
                    tempMsg =string.Format("MODE={0} SKIP_MODE IS UNSUPPORTED.", mode);
                    Log(string.Format("{0}\t{1}", _component.ControlName, "PGM DATA ERROR - " + tempMsg));
                    result = RESULT_COMMAND_ERROR;
                    break;
                case COLD_RUN_MODE_OR_CYCLE_MODE:
                case FORCE_CLEAN_OUT_MODE:
                    _component.EquipmentMode = mode;
                    break;
                default:
                    tempMsg = string.Format("MODE={0} UNKNOWN MODE IS UNSUPPORTED.", mode);
                    Log(string.Format("{0}\t{1}", _component.ControlName, "PGM DATA ERROR - " + tempMsg));
                    result = RESULT_COMMAND_ERROR;
                    break;
            }
            error = result == RESULT_COMMAND_ERROR;
            //음 변경을 해야하는데...

            _main.MelsecNetWordWrite(OW_EQUIPMENT_MODE_CHANGE_RETURN, result);
            _main.MelsecNetBitOnOff(OB_EQUIPMENT_MODE_CHANGE, false);

            Log(string.Format("{0}\t{1}", _component.ControlName, string.Format("PGM DATA SEND - {0}", result)));

            _component.GetProgram("MACHINE_MODE_CHANGE_REPORT").Execute();
            if (!error)
                return 0;

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
    }
}
