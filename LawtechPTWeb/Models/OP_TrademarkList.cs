using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawtechPTWeb.Models
{
    public class OP_TrademarkList
    {
        public int total
        {
            get; set;
        }
        public List<PV_TrademarkList> rows
        {
            get; set;
        }

    }
}