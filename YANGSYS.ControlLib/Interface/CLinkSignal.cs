using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YANGSYS.ControlLib
{
    public class CSendToDownStream
    {
        public string Path { get; set; }

        /// <summary>
        /// Upstream Paths
        /// </summary>
        public bool SendInterlock { get; set; }

        /// <summary>
        /// Send to DownStream Path#1
        /// </summary>
        public bool SendRequest { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool SendStart { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool SendPosition { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool SendComplete { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool SubstrateDataOutput { get; set; }

        public bool T_AUpperUnitGlassPutILC { get; set; }
        public bool T_ADownUnitGlassPutILC { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool LotEndSignal { get; set; }
    }

    public class CUnloadToDownStream
    {
        public string Path { get; set; }
        /// <summary>
        /// Unload to Downstream Path#1
        /// </summary>
        public bool UnloadInterlock { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool UnloadPossible { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool UnloadPermit { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool UnloadComplete { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool SubstrateDataOutput { get; set; }

        public bool T_AUpperUnitGlassPutPermit { get; set; }
        public bool T_ADownUnitGlassPutPermit { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public bool LotEndSignal { get; set; }

    }

    public class CFetchFromUpStream
    {
        public string Path { get; set; }
        /// <summary>
        /// Fetch From Upstream Path#1
        /// </summary>
        public bool FetchInterlock { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool FetchRequest { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool FetchStart { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool FetchPosition { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool FetchComplete { get; set; }

        public bool T_AUpperUnitGlassGetPermit { get; set; }
        public bool T_ADownUnitGlassGetPermit { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool LotEndConfirm { get; set; }

    }

    public class CReceiveFromupStream
    {
        public string Path { get; set; }
        /// <summary>
        /// Receive from Upstream Path#1
        /// </summary>
        public bool ReceiveInterlock { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool ReceivePossible { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool ReceivePermit { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool ReceiveComplete { get; set; }

        public bool T_AUpperUnitGlassGetPermit { get; set; }
        public bool T_ADownUnitGlassGetPermit { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool LotEndConfirm { get; set; }

    }
}
