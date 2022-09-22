using System.Collections.Generic;

namespace LawtechPTWeb.Models
{
    public class OP_PatentList
    {
        public int total
        {
            get; set;
        }
        public List<PV_PatentList> rows
        {
            get; set;
        }
    }
}