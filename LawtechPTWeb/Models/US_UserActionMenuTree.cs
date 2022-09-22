
namespace LawtechPTWeb.Models
{
    /// <summary>
    /// 記錄登入者所在的功能選單
    /// </summary>
    public class US_UserActionMenuTree
    {
        /// <summary>
        /// 記錄登入者所在的功能選單
        /// </summary>
        /// <param name="main">登入者的主選單</param>
        /// <param name="current">登入者目前所在的二級選單 </param>
        public US_UserActionMenuTree(PV_MenuPermitT main, PV_MenuPermitT current)
        {
            UserMainMenu = main;
            UserCurrentMenu = current;
        }
        public PV_MenuPermitT UserMainMenu { get; set; }

        public PV_MenuPermitT UserCurrentMenu { get; set; }
    }
}