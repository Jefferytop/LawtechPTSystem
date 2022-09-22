using System.Collections.Generic;

namespace LawtechPTWeb.Models
{
    /// <summary>
    /// 取得登入者所擁有的選單權限 PV_MenuPermitT、List PV_MenuPermitT
    /// </summary>
    public class PV_UserMenuTree
    {

        /// <summary>
        /// 主選單
        /// </summary>
        public PV_MenuPermitT MainNavigate { get; set; }


        /// <summary>
        /// 子選單
        /// </summary>
        public List<PV_MenuPermitT> ChildNavigate { get; set; }

    }
}