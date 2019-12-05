using System;
using System.Collections.Generic;
using System.Text;
using SOFD.Properties;
namespace SmartPLCSimulator
{
    public class CScanControlPropertiesForSim : CScanControlProperties
    {
        public string ConnectTMName { get; set; } //TM06, TM07 형태로 저장되어 있거나 TM일 경우에는 빈값.
        public string LoadTeachingNo { get; set; }
        public string UnloadTeachingNo { get; set; }

        public bool IsLinkedEQ { get; set; } //클러스터와 클러스터를 연결하는 장비 여부
        public bool isBiDirection { get; set; }
        public string LinkedTMName { get; set; } //LinkedEQ일때 다른쪽 TM Control Name...  TM06에 To Route가 LinkedEQ 이면.. LinkedEQ가 UR 내면 LinkedTM에 Route가 전달되어 해당Scan Control에 Access해야 함.
        public string LinkedTeachingNo { get; set; } //<==이게 아주 지랄 같은데... 

        public string EQToEQ_NAME { get; set; } //값이 있으면 장비에서 장비로 넘어가는 장비임.. ?? 엉 말이. ㅋㅋㅋㅋ 여튼... 로봇을 통한게 아니라 장비에서 장비로 넘어갈때 TO EQP Name가 들어감.
        public bool IsManualUR { get; set; }

        public bool IsBuffer { get; set; }

        public bool IsFirstEQP { get; set; }

        private bool bIsExchange = true;
        public bool IsExchange
        {
            get { return bIsExchange; }
            set { bIsExchange = value; }
        }

        public bool ENCAPLOADING { get; set; }
    }
}
