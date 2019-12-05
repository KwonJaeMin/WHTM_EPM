using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOFD.File;

namespace SmartPLCSimulator
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

        public string[] PPIDRecipe
        {
            set
            {
                string temp = "";

                foreach (string item in value)
                {
                    if (item.Contains(":"))
                    {
                        temp += item + ",";
                    }
                }
                this.SetCustomProperty(this.Site, "PPID_RECIPE", temp, "PPID에 연결된 RECIPE 정보");
            }
            get
            {
                string temp = this.GetCustomProperty(this.Site, "PPID_RECIPE", "1:1,2:3,3:5", "");
                string[] splitedTemp = temp.Split(',');

                return splitedTemp;
            }
        }
    }
}
