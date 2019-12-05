using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YANGSYS.ControlLib
{
    public class CJobDataB
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

        /// <summary>
        /// a fictitious slot number
        ///Slot Number in the cassette. (1, 2, 3, …)
        ///- Loader Create
        ///- Others: Copy
        /// </summary>
        public Int16 SubstrateIndex { get; set; }

        /// <summary>
        /// 1~35535
        /// </summary>
        public Int16 ProductCode { get; set; }

        /// <summary>
        /// Cassette Id
        ///-Loader: Input
        ///- Others: Copy
        /// </summary>
        public string LotId { get; set; }

        /// <summary>
        /// Glass Cell or Qpanel ID
        ///-Loader: Input
        ///- Others: Copy
        /// </summary>
        public string SubstrateID { get; set; }

        /// <summary>
        /// Process Program ID (Recipe)
        ///- ‘1’ ~ ‘999’
        ///- CIM/Operator
        ///- Others: Copy
        /// </summary>
        public Int16 PPID { get; set; }

        /// <summary>
        ///1: Subsrate
        ///2: Cell
        ///3: Panel
        ///4: Module
        ///5: Q1
        ///6: Q2
        ///7: Q3
        ///[For our case, it is always 1]
        /// </summary>
        public Int16 SubstrateType { get; set; }

        /// <summary>
        ///   Job Type
        ///    1: TFT Glass
        ///  2: CF Glass
        /// 3: ITO Dummy
        ///4: Bare Dummy
        ///5: EN Glass(DV)
        ///6: UVMask
        ///7: PI Coating Dummy
        ///….
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

        /// <summary>
        /// Glass Grade
        ///[P,S,T,Q…]
        ///-Loader/CIM Input
        ///-Others Copy
        /// </summary>
        public string JobGrade { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Reserved { get; set; }

        /// <summary>
        /// Spare
        /// </summary>
        public bool LineSpecificItem1 { get; set; }

        /// <summary>
        /// Spare
        /// </summary>
        public bool LineSpecificItem2 { get; set; }

        /// <summary>
        /// Spare
        /// </summary>
        public bool LineSpecificItem3 { get; set; }

        /// <summary>
        /// Spare
        /// </summary>
        public bool LineSpecificItem4 { get; set; }

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
        public Int16 LineSpecificItem13 { get; set; }

        /// <summary>
        /// Spare
        /// </summary>
        public Int16 LineSpecificItem14 { get; set; }

    }
}
