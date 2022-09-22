
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Mvc;


namespace LawtechPTWeb.Models
{
    /// <summary>
    /// 通用的方法集合
    /// </summary>
    public class PublicFunction
    {
        /// <summary>
        /// 取得或設定登入者目前所在的功能選單
        /// </summary>
        /// <param name="ControlName"></param>
        /// <param name="ActionName"></param>
        public static void GetControlActionMenu(string ControlName, string ActionName)
        {
            List<PV_UserMenuTree> menuList = (List<PV_UserMenuTree>)HttpContext.Current.Session[GetEnumString(SessionCodeName.UserMenuTree)];

            foreach (PV_UserMenuTree itemMenu in menuList)
            {
                foreach (PV_MenuPermitT item in itemMenu.ChildNavigate)
                {
                    if (item.ControllerName == ControlName && item.ActionName == ActionName)
                    {
                        US_UserActionMenuTree userCurrent = new US_UserActionMenuTree(itemMenu.MainNavigate, item);
                        HttpContext.Current.Session[GetEnumString(SessionCodeName.UserActionMenuTree)] = userCurrent;
                        break;
                    }
                }
            }
        }


        /// <summary>
        /// 取得系統角色的權限資料
        /// </summary>       
        /// <returns></returns>
        public static List<PV_UserMenuTree> GetUserMenuTreeMethod()
        {
            List<PV_UserMenuTree> MenuTree = new List<PV_UserMenuTree>();

            List<PV_MenuPermitT> MenuPermit = new List<PV_MenuPermitT>();
            object retobjMenuPermit = PV_MenuPermitT.ReadList("ParentModuleKey=0 and IsEnable='True' order by Sort", ref MenuPermit);

            foreach (PV_MenuPermitT item in MenuPermit)
            {
                PV_UserMenuTree Tree = new PV_UserMenuTree();
                Tree.MainNavigate = item;

                //取得子選單
                List<PV_MenuPermitT> MenuPermitChild = new List<PV_MenuPermitT>();
                object retobjTree = PV_MenuPermitT.ReadList("ParentModuleKey="+item.ModuleKey.ToString(), ref MenuPermitChild );

                Tree.ChildNavigate = MenuPermitChild;

                MenuTree.Add(Tree);
            }

            return MenuTree;
        }

        /// <summary>
        /// 取得列舉名稱
        /// </summary>
        /// <param name="codename"></param>
        /// <returns></returns>
        public static string GetEnumString(SessionCodeName codename)
        {
            string strEnumName = Enum.GetName(typeof(SessionCodeName), codename);
            return strEnumName;
        }

        /// <summary>
        /// 取得錯誤訊息集合
        /// </summary>
        /// <param name="ModelStateValues"></param>
        /// <returns></returns>
        public static string GetModelStateValues(ICollection<ModelState> ModelStateValues)
        {
            StringBuilder sb = new StringBuilder();
            //取得錯誤訊息
            foreach (ModelState error in ModelStateValues)
            {
                if (error.Errors.Count > 0)
                {
                    sb.Append("<p>" + error.Errors[0].ErrorMessage + "<p>"); ;

                }
            }
            return sb.ToString();
        }

        
    }
}