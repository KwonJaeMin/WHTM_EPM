using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YANGSYS.ControlLib
{
    #region // 둘다 체크 안되어 있음

    /// <summary>
    /// RetrunCode - Both Not Check
    /// </summary>
    public enum enmuReturnCode
    {
        Accept=1,
        NotAccept=2,
    }

    /// <summary>
    /// RetrunCode - Both Not Check
    /// </summary>
    public enum enumVCRStatus
    {
        Read_OK=1,
        Read_Fail=2,
        Skip=3,
    }

    public enum enumEquipmentStatus2
    {
        Idle=1,
        Run=2,
        Down=3,
        Maint=4  
    }
    /// <summary>
    /// SlotStatusChange - Both Not Check
    /// </summary>
    public enum enumSlotStatusChange
    {
        Empty=1,
        Process_End=2,
        WaitProcess=3,
        SkipProcess=4,
        FailProcess=5,
        Runing=6,
    }

    /// <summary>
    /// PortEnableModeChangeReturnCode - Both Not Check
    /// </summary>
    public enum enumPortEnableModeChangeReturnCode
    {
        OK=1,
        NG=2,
    }

    /// <summary>
    /// PortUseTypeChangeReturnCode - Both Not Check
    /// </summary>
    public enum enumPortUseTypeChangeReturnCode
    {
        OK=1,
        NG=2,
    }

    #endregion

    #region // Index만 체크 되어 있음

    /// <summary>
    /// PortEnableMode - Indexer Check
    /// </summary>
    public enum enumPortEnableMode
    {
        Port_Enabled=1,
        Port_Disabled=2,
    }

    /// <summary>
    /// enumPortTransferMode - Indexer Check
    /// </summary>
    public enum enumPortTransferMode
    {
        Stocker_Inline_Mode=1,
        MGV_Mode=2,
        AGV_Mode=3,
    }

    /// <summary>
    /// OPERATOR MODE - INDEXER CHECK
    /// MP1MODE=MPMODE - portmode가 pb
    /// MP2MODE=SKIPMODE - portmode가 pb
    /// DUMMYMODE=DUMMYMODE - portmode가 pl,pu
    /// SORTINGMODE=SORTINGMODE - portmode가 pl, pu
    /// </summary>
    public enum enumOperationMode
    {
        MP1_MODE = 1,
        MP2_MODE=2,
        DUMMY_MODE=3,
        SORTING_MODE=4,
    }

    /// <summary>
    /// PORT USE TYPE - INDEXER CHECK
    /// </summary>
    public enum enumPortUseType
    {
        TFT_MODE = 1,
        CF_MODE=2,
        TC_MODE=3,
        ITO_DUMMY_MODE=4,
        BARE_DUMMY_MODE=5,
    }

    /// <summary>
    /// Port Type - INDEXER CHECK
    /// PB - LOAD/UNLOAD BOTH PORT
    /// PL - LOAD PORT
    /// PU - UNLOAD PORT
    /// BB - BUFFER BOTH
    /// BL - BUFFER LOADER
    /// BU - BUFFER UNLOADER
    /// BO - BUFFER ONLY
    /// </summary>
    public enum enumPortType2
    {
        PB=1,
        PL=2,
        PU=3,
        BB=4,
        BL=5,
        BU=6,
        BO=7,
    }
    /// <summary>
    /// CstUnloadMode - INDEXER CHECK
    /// </summary>
    public enum enumCstUnlodeMode
    {
        Lot_Mode=1,
        Cst_Mode=2,
    }

    public enum enumControlStateChangeReturnCode
    {
        Command_OK = 1,
        Command_Error=2,
    }

    /// <summary>
    /// portStatus - Indexer Check
    /// </summary>
    public enum enumPortStatus2
    {
        LoadRequest=1,
        Pre_Load_Complete=2,
        Load_Complete=3,
        Unload_Request=4,
        Unload_Complete=5,
        Down=6,
    }

    /// <summary>
    /// CSTStatus - Indexer Check
    /// </summary>
    public enum enumCSTStatus
    {
        No_Cst_Exist=1,
        Wait_Cst_Data=2,
        Wait_Start_Command=3,
        Wait_Process=4,
        InProcessing=5,
        Process_Paused=6,
        Process_Canceled=7,
        Process_Aborted=8,
        Process_Normal_Completed=9,
    }

    /// <summary>
    /// CSTCompleteReasonCode - Indexer Check
    /// </summary>
    public enum enumCSTCompletedReasonCode
    {
        Normal_Complete=1,
        Operator_Cancel_Touch_Panel=2,
        Operator_Abort_Touch_Panel=3,
        CIS_Cancel=4,
        CIS_Abort=5,
        EQ_Auto_Cancel=6,
        EQ_AUto_Abort=7,
    }

    /// <summary>
    /// LoadingCSTType - IndexerChange
    /// </summary>
    public enum enumLoadingCSTType
    {
        Actual_CST=1,
        Empty_CST=2,
    }

    #endregion
    
    #region // unit만 체크 되어 있음

    /// <summary>
    /// CstUnloadMode - UNIT CHECK
    /// </summary>
    public enum enumRobotPitchMode
    {
        ExChange_Mode=1,
        Auto_Double_Pitch_Mode=2,
    }    

    #endregion

    #region // 둘다 체크 되어 있음

    /// <summary>
    /// RemoveFlag - Both Check
    /// </summary>
    public enum enumRemoveFlag
    {
        TakeOut=1,
        Scrap=2,
        TakeIn=3,
    }

    /// <summary>
    /// CimConnect - Both Check
    /// </summary>
    public enum enumRunningMode
    {
        None=0,
        Running=1,
        Not_Running=2,
    }

    /// <summary>
    /// CimConnect - Both Check
    /// </summary>
    public enum enumEqpAutoMode
    {
        AUTO=1,
        MANUAL=2,
    }

    /// <summary>
    /// CimConnect - Both Check
    /// </summary>
    public enum enumInlineLinkMode
    {
        Inline=1,
        Local=2,
    }

    /// <summary>
    /// CimConnect - Both Check
    /// </summary>
    public enum enumCstOperationMode
    {
        Sheet_by_Sheet_Mode=1,
        Cst_By_Cst_Mode=2,
    }

    /// <summary>
    /// CimConnect - Both Check
    /// </summary>
    public enum enumCimConnectMode
    {
        Connect=1,
        DisConnect=2,
    }

    /// <summary>
    /// CimConnect - Both Check
    /// </summary>
    public enum enumTerminalTextReturnCode
    {
        Command_OK=1,
        Command_Error=2,
    }

    /// <summary>
    /// CimConnect - Both Check
    /// </summary>
    public enum enumBuzOnReturnCode
    {
        Command_OK=1,
        Command_Error=2,
    }

    /// <summary>
    /// CimConnect - Both Check
    /// </summary>
    public enum enumDateSetCommandReturnCode
    {
        Command_OK=1,
        Command_Error=2,
    }

    /// <summary>
    /// PPCINFO - Both Check
    /// created : a new PPID is Created and registered
    /// Modified : some parameters of a PPID are modified
    /// Deleted : any PPID is deleted
    /// Changed : equipment sets up any PPID which different from current PPID
    /// </summary>
    public enum enumPPCINFO
    {
        Created=1,
        Modified=2,
        Deleted=3,
        Changed=4,
    }

    /// <summary>
    /// Return Code - Both Check
    /// </summary>
    public enum enumReturnCode
    {
        OK=1,
        NG=2,
    }

    /// <summary>
    /// RecipeCCdoe - Both Check
    /// CRE : CREATE,
    /// MOD : MODIFY
    /// DEL : DELETE
    /// CHA : CHANGE
    /// </summary>
    public enum enumRecipeCCode
    {
        CRE=1,
        MOD=2,
        DEL=3,
        CHA=4,
    }    

    #endregion   
    
    public class Class1
    {
        /// <summary>
        /// SKIP MODE - UNIT CHECK : oven만 들어가는듯.
        /// 1st word
        /// ON : SKIP
        /// OFF : NOT SKIP
        /// 00 ~ 01 : 1 : SKIP UNIT, 2 : SKIP SELECTED SLOT OF UNIT
        /// 02 ~ 15 : SLOT1 ~ SLOT14
        /// 2nd word
        /// 00 ~ 15 : slot15 ~ slot30
        /// </summary>
        /// 
        
        ///
        /// <summary>
        /// Job Existence Slot
        /// On : Job Exist
        /// Off : No Job Exist
        /// [1st word]
        /// 00 ~ 15 : Job Existence Slot 1 ~ 16
        /// 00 : JobExistence Slot 1
        /// 01 : JobExistence Slot 2
        /// ~
        /// 15 : JobExistence Slot 16
        /// 
        /// [2nd Word]
        /// 00 ~ 15 : JobExistence Slot 17 ~ 32
        /// 
        /// [3rd Word]
        /// 00 ~ 15 : JobExistence Slot 33 ~ 48
        /// 
        /// [4th Word]
        /// 00 ~ 15 : JobExistence Slot 49 ~ 64
        /// ~
        /// [14th Word]
        /// 00 ~ 15 : JobExistence Slot 209 ~ 210
        /// 
        /// </summary>
        ///

        ///
        /// <summary>
        /// CST Control Command Return Code
        /// HCACK : 
        /// 0 : OK
        /// 1 : PPID is invalid
        /// 2 : CSTID is invalid
        /// 3 : LotID is Invalid
        /// 4 : Command does not Exist
        /// 5 : Rejected, Already in Desired Condition
        /// 30 : PPID is invalid
        /// 31 : Rejected By Equipment
        /// 
        /// [CST Map Download Return Code]
        /// 1 : Accepted
        /// 2 : Busy
        /// 3 : CST is Invalid
        /// 4 : PPID is Invalid
        /// 5 : Slot INformation mismath
        /// 6 : Already Received (Lotinfo)
        /// 11 : Error
        /// </summary>
        /// 
    }

    #region // CIM -> Unit

    public enum enumCSTControlCommand
    {
        CSTProcessStart = 1,
        CSTProcessCancel = 2,
        CSTProcessAbort = 3,
        CSTProcessPause = 4,
        CSTProcessResume = 5,
        CSTMapDownload = 11,
    }

    public class CCSTControlCommandData
    {
        public string SendLotID { get; set; }
        public Int16 SendProductCode { get; set; }
        public Int16 SendPPID { get; set; }
    }
    #endregion
}
