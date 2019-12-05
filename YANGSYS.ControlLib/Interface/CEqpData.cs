using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YANGSYS.ControlLib
{
    public class CEqpData
    {
        /// <summary>
        /// cim 연결 상태
        /// 1 : DisConnect
        /// 2 : Connect
        /// </summary>
        public enumCimConnectMode CimConnectMode { get; set; }

        /// <summary>
        /// recipeId
        /// </summary>
        public string PPID { get; set; }

        /// <summary>
        /// InputPortID
        /// </summary>
        public string IPID { get; set; }

        /// <summary>
        /// OutputPortID
        /// </summary>
        public string OPID { get; set; }

        /// <summary>
        /// InputCSTID
        /// </summary>
        public string ICID { get; set; }

        /// <summary>
        /// OutputCstID
        /// </summary>
        public string OCID { get; set; }

        /// <summary>
        /// EQPStatus
        /// 1 : idle
        /// 2 : Run
        /// 3 : Trouble
        /// 4 : Maint
        /// </summary>
        public enumEquipmentStatus2 EqpStatus { get; set; }

        /// <summary>
        /// UnitID
        /// </summary>
        public string EqpID { get; set; }

        /// <summary>
        /// Run상태
        /// 1 : Running
        /// 2 : NotRunning
        /// </summary>
        public enumRunningMode RunningMode { get; set; }

        /// <summary>
        /// Auto상태
        /// 1 : Auto
        /// 2 : Manual
        /// </summary>
        public enumEqpAutoMode AutoMode { get; set; }

        /// <summary>
        /// InLine상태
        /// 1 : Inline
        /// 2 : Local
        /// </summary>
        public enumInlineLinkMode InlineMode { get; set; }

        /// <summary>
        /// Operation 상태
        /// 1 : sheet Mode
        /// 2 : CST Mode
        /// </summary>
        public enumCstOperationMode CSTOPMode { get; set; }        
    }
}
