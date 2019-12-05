using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainLibrary.Global
{
    public class CErrorReason
    {
        public DateTime CreateTime
        {
            get;
            set;
        }

        public string Content
        {
            get;
            set;
        }

        public string TroubleShooting
        {
            get;
            set;
        }

        public CErrorReason()
        {
            CreateTime = DateTime.Now;
            Content = "";
            TroubleShooting = "";
        }

        public CErrorReason(string content, string troubleShooting)
        {
            CreateTime = DateTime.Now;
            Content = content;
            TroubleShooting = troubleShooting;
        }
    }

    public class CErrorReasonList : List<CErrorReason>
    {
        public DateTime CreateTime
        {
            get;
            set;
        }

        public string Category
        {
            get;
            set;
        }

        public CErrorReasonList()
        {
            CreateTime = DateTime.Now;
        }
    }
}
