using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOFD.File;
using SOFD.Component;

namespace YANGSYS.Simulator.Probe
{
    public class CSystemConfig : ACustomPropertyContainer
    {
        public bool Initiallized { get; set; }

        public string Site
        {
            set
            {
                this.SetCustomProperty("SYSTEM", "SITE", value, "대응 사이트 명");
            }
            get
            {
                return this.GetCustomProperty("SYSTEM", "SITE", "WHTM", "");
            }
        }
        public string IP
        {
            set
            {
                this.SetCustomProperty(this.Site, "IP", value, "대응 사이트 명");
            }
            get
            {
                return this.GetCustomProperty(this.Site, "IP", "127.0.0.1", "");
            }
        }

        public string Port
        {
            set
            {
                this.SetCustomProperty(this.Site, "PORT", value, "사용 할 PORT 번호");
            }
            get
            {
                return this.GetCustomProperty(this.Site, "PORT", "7000", "");

            }
        }

        public string ServerClient
        {
            set
            {
                this.SetCustomProperty(this.Site, "SERVER_CLIENT", value, "TCP/IP 동작 설정");
            }
            get
            {
                return this.GetCustomProperty(this.Site, "SERVER_CLIENT", "CLIENT", "");
            }
        }

        public bool AutoConnection
        {
            set
            {
                this.SetCustomProperty(this.Site, "AUTO_CONNECTION", value.ToString(), "현재 연결로 자동 연결 설정");
            }
            get
            {
                return this.GetCustomProperty(this.Site, "AUTO_CONNECTION", bool.FalseString, "") == bool.TrueString;
            }
        }

        public bool AutoInterface
        {
            set
            {
                this.SetCustomProperty(this.Site, "AUTO_INTERFACE", value.ToString(), "LINK SIGNAL 자동 대응 설정");
            }
            get
            {
                return this.GetCustomProperty(this.Site, "AUTO_INTERFACE", bool.FalseString, "") == bool.TrueString;
            }
        }

        public int LoadReqTime
        {
            set
            {
                this.SetCustomProperty("SYSTEM", "LOAD_REQ_TIME", value.ToString(), "EQP LOAD REQUEST ON TIME");
            }
            get
            {
                return int.Parse(this.GetCustomProperty("SYSTEM", "LOAD_REQ_TIME", "5", ""));
            }
        }

        public int ProcTime
        {
            set
            {
                this.SetCustomProperty("SYSTEM", "PROC_TIME", value.ToString(), "EQP PROCESSING TIME");
            }
            get
            {
                return int.Parse(this.GetCustomProperty("SYSTEM", "PROC_TIME", "5", ""));
            }
        }

        public bool GlassExist1
        {
            set
            {
                this.SetCustomProperty(this.Site, "GLASS_EXIST1", value.ToString(), "1번 stage의 Glass 유무");
            }
            get
            {
                return this.GetCustomProperty(this.Site, "GLASS_EXIST1", bool.FalseString, "") == bool.TrueString;
            }
        }
                    
        public string CurrentPPID
        {
            set
            {
                this.SetCustomProperty(this.Site, "CURRENT_PPID", value, "현재 장비의 PPID");
            }
            get
            {
                return this.GetCustomProperty(this.Site, "CURRENT_PPID", "1", "");
            }
        }
        public string CurrentRecipeID
        {
            set
            {
                this.SetCustomProperty(this.Site, "CURRENT_RECIPEID", value, "현재 장비의 RECIPE ID");
            }
            get
            {
                return this.GetCustomProperty(this.Site, "CURRENT_RECIPEID", "1", "");
            }
        }

        public bool AutoMode
        {
            set
            {
                this.SetCustomProperty(this.Site, "AUTO_MODE", value.ToString(), "Auto/Manual 상태");
            }
            get
            {
                return this.GetCustomProperty(this.Site, "AUTO_MODE", bool.FalseString, "") == bool.TrueString;
            }
        }
        
        public int EquipmentMode
        {
            set
            {
                this.SetCustomProperty("SYSTEM", "EQUIPMENT_MODE", value.ToString(), "EQP OPERATION MODE");
            }
            get
            {
                return int.Parse(this.GetCustomProperty("SYSTEM", "EQUIPMENT_MODE", "1", ""));
            }
        }

        public int ProcessState
        {
            set
            {
                this.SetCustomProperty("SYSTEM", "PROCESS_STATE", value.ToString(), "PROCESS STATE");
            }
            get
            {
                return int.Parse(this.GetCustomProperty("SYSTEM", "PROCESS_STATE", "1", ""));
            }
        }

        public int EquipmentState
        {
            set
            {
                this.SetCustomProperty("SYSTEM", "EQUIPMENT_STATE", value.ToString(), "EQP STATE");
            }
            get
            {
                return int.Parse(this.GetCustomProperty("SYSTEM", "EQUIPMENT_STATE", "1", ""));
            }
        }
    }
}
