using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YANGSYS.ControlLib
{
    public class CJobDataA
    {
        /// <summary>
        /// Port No(1,2,3,4,5) & Cassette Cassette Sequence No (1~255)
        ///- Upper Byte: Cassette Sequence No
        ///- Lower Byte: Port No
        ///- Loader: Create
        ///- Others: Copy
        ///- Cassette Index of the cassette.
        ///- It will be changed when the Cassette Data Request signal is turn On
        /// </summary>
        public Int16 CassetteIndex { get; set; }

        /// <summary>/// a fictitious slot number
        ///Slot Number in the cassette. (1, 2, 3, …)
        ///- Loader Create
        ///- Others: Copy
        /// </summary>
        public Int16 SubstrateIndex { get; set; }

        /// <summary>/// 1~35535
        /// </summary>
        public Int16 ProductCode { get; set; }

        /// <summary>/// Cassette Id
        ///-Loader: Input
        ///- Others: Copy
        /// </summary>
        public string CassetteId { get; set; }

        /// <summary>/// Host Lot Id
        ///-Loader: Input
        ///- Others: Copy
        /// </summary>
        public string LotId { get; set; }

        /// <summary>/// Glass Cell or Qpanel ID
        ///-Loader: Input
        ///- Others: Copy
        /// </summary>
        public string SubstrateID { get; set; }

        /// <summary>/// Process Program ID 
        ///- ‘1’ ~ ‘999’
        ///- CIM/Operator Create
        ///- Others: Copy
        /// </summary>        
        public Int16 PPID { get; set; }

        /// <summary>///       
        /// 1: Subsrate
        ///       2: Cell
        ///    3: Panel
        ///       4: Module
        ///       5: Q1
        ///       6: Q2
        ///       7: Q3
        ///[For our case, it is always 1]
        /// </summary>        
        public Int16 SubstrateType { get; set; }

        /// <summary>
        /// Job Type
        ///       1: TFT Glass
        ///       2: CF Glass
        ///       3: ITO Dummy
        ///       4: Bare Dummy
        ///       5: EN Glass(DV)
        ///       6: UVMask
        ///       7: PI Coating Dummy
        ///       ….
        ///-Loader: Input
        ///- Others: Copy]
        /// </summary>
        public Int16 JobType { get; set; }

        /// <summary>
        /// G: Good,   N: No Good,  R: Rework,  P: Repair,   S: Scrap
        ///[Glass Judge]
        ///-Loader/CIM Input
        ///-Others Copy
        /// </summary>        
        public string JobJudge { get; set; }

        /// <summary>/// Glass Grade
        ///[P,S,T,Q…]
        ///-Loader/CIM Input
        ///-Others Copy
        /// </summary>        
        public string JobGrade { get; set; }

        /// <summary>/// 1: No State
        ///2. Queued
        ///3: Selected
        ///4: WaitingForStart
        ///5: Executing
        ///6: Completed
        ///7. Paused
        ///8. Aborted
        ///-Load Set; Unloder Modify
        ///-Others Copy
        /// </summary>
        public Int16 JobState { get; set; }

        /// <summary>/// 0: Not Processed (In EQ)
        ///1: Normal Processed [In EQ]
        ///2: Abnormal Processed [In EQ]
        ///3: Process Skip [Not In EQ]
        /// </summary>
        public bool TrackingData { get; set; }

        /// <summary>
        /// Unit: Unit No
        ///Port: Port No
        ///Buffer: Slot No
        /// </summary>        
        public Int16 SourcePortNo { get; set; }

        /// <summary>/// Unit: Unit No
        ///Port: PortNo
        ///Buffer: Slot No
        /// </summary>
        public Int16 TargetPortNo { get; set; }

        /// <summary>/// Send Compete On, or Unload Complete On
        ///Write Cycle Time Value
        /// </summary>
        public Single CycleTime { get; set; }

        /// <summary>
        /// Send Compete On, or Unload Complete On
        ///Write Takt Time Value
        /// </summary>
        public Single TaktTime { get; set; }

        /// <summary>
        /// Lot End' signal.This data indicates  Lot End after the  Last Glass(Panel)  fetching/storing from/to the cassette
        ///0: Lot End Signal Off, Default
        ///1: Lot End Signal On
        ///[- Loader Create
        ///- Others: Copy or Modify]/// </summary>
        public Int16 LotEndFlag { get; set; }

        /// <summary>
        /// Abort, Judge Change, Scrap or Takeout Reason Code
        ///[Lot End Flag:
        /// 1: Normal End
        /// 2: Scrap the last Substrate
        /// 3: TakeOut the Last Substrate
        /// 4: Received CassetteIndex is different with Current CassetteIndex
        /// 5: No Same CassetteIndex in multi Stage equipment
        ///..
        /// Scrap Reason Code:
        /// 100~199
        ///Skip Reason Code:
        /// 200~399
        ///Judge Grade Change Reason Code:
        ///Abort Reason code:
        /// </summary>
        public Int16 ReasonCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OperatorID { get; set; }

        /// <summary>
        /// Spare
        /// </summary>
        public Int16 LineSpecificItem4 { get; set; }
        
        /// <summary>
        /// Spare
        /// </summary>
        public Int16 LineSpecificItem5 { get; set; }

        /// <summary>
        /// Spare
        /// </summary>
        public Int16 LineSpecificItem6 { get; set; }

        /// <summary>
        /// Spare
        /// </summary>
        public Int16 LineSpecificItem7 { get; set; }

        /// <summary>
        /// Spare
        /// </summary>
        public Int16 LineSpecificItem8 { get; set; }

        /// <summary>
        /// Spare
        /// </summary>
        public Int16 LineSpecificItem9 { get; set; }

        /// <summary>
        /// Spare
        /// </summary>
        public Int16 LineSpecificItem10 { get; set; }

        /// <summary>
        /// Spare
        /// </summary>
        public Int16 LineSpecificItem11 { get; set; }

        /// <summary>
        /// Spare
        /// </summary>
        public Int16 LineSpecificItem12 { get; set; }

        /// <summary>
        /// Spare
        /// </summary>
        public Int16 LineSpecificItem13 { get; set; }

        /// <summary>
        /// Spare
        /// </summary>
        public Int16 LineSpecificItem14 { get; set; }

        /// <summary>
        /// Spare
        /// </summary>
        public Int16 LineSpecificItem15 { get; set; }

        /// <summary>
        /// Spare
        /// </summary>
        public Int16 LineSpecificItem16 { get; set; }
    }
}
