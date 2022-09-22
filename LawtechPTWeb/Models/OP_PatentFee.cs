using System.Collections.Generic;

namespace LawtechPTWeb.Models
{
    public class OP_PatentFee
    {
        /// <summary>
        /// 總筆數
        /// </summary>
        public int total
        {
            get; set;
        }
        /// <summary>
        /// 
        /// </summary>
        public List<PV_PatentFee> rows
        {
            get; set;
        }

    }
}