using System.Collections.Generic;

namespace LawtechPTWeb.Models
{
    public class OP_TrademarkFee
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
        public List<PV_TrademarkFee> rows
        {
            get; set;
        }

    }
}