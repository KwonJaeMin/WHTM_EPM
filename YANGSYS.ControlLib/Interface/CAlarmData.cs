using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SOFD.Component.Interface;

//using Equipment.B2.ControlLib.Interface;

using SOFD.Component;

namespace YANGSYS.ControlLib
{
    public partial class CAlarmData
    {
        /// <summary>
        ///1: Alarm Set
        ///2: Alarm Clear
        /// </summary> 
        public Int16 AlarmStatus { get; set; }

        /// <summary>
        ///1: Equipment Level Alarm
        ///10~: Alarm Occurred Unit Path Number
        /// </summary>
        public Int16 AlarmIssuedUnitPathNo { get; set; }

        /// <summary>
        /// 1~65535
        ///【
        ///1~1200: Indexer
        ///1201~2400: Oven A
        ///2401~3600: Oven B
        ///3601~4800: Cooling
        ///65501 ~ 65535: CIS Reserved
        ///】
        /// </summary>
        public string AlarmID { get; set; }

        /// <summary>
        /// [00 ~ 06 Bit : Alarm Category]
        ///Bit 00 Danger for human
        ///Bit 01 Equipment error
        ///Bit 02 Parameter overflow cause 
        ///process error
        ///Bit 03 Parameter overflow cause 
        ///equipment can't work
        ///Bit 04 Can not recover trouble
        ///Bit 05 Equipment status warning
        ///Bit 06 Process reached to predefined 
        ///status
        /// </summary>
        public bool AlarmCode { get; set; }

        /// <summary>
        ///1: Light
        ///2: Serious
        /// </summary>
        public Int16 AlarmLevel { get; set; }

        /// <summary>
        ///1: Using EQ Report Alarm Text
        ///2: Using CIS Alarm Text
        /// </summary>
        public Int16 AlarmTextUsingFlag { get; set; }

        /// <summary>
        /// Alarm Text
        /// </summary>
        public string AlarmText { get; set; }

        /// <summary>
        /// YY/MM/DD/hh/mm/ss
        /// </summary>
        public string AlarmTime { get; set; }

        /// <summary>
        /// 1 : BuzzerControl On
        /// 2 : BuzzerControl Off
        /// </summary>
        public Int16 BuzzerControl { get; set; }

    }
}
