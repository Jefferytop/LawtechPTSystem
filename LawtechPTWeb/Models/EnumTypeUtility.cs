using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawtechPTWeb.Models
{
    public class EnumTypeUtility
    {
    }

    #region StatusCode 狀態代碼
    /// <summary>
    /// 狀態代碼
    /// </summary>
    public enum StatusCode : int
    {
        /// <summary>
        /// 执行成功
        /// </summary>
        OK = 200,

        /// <summary>
        /// 服務器無法識別的請求
        /// </summary>
        BadRequest = 400,

        /// <summary>
        /// 服務器拒絕請求
        /// </summary>
        Forbidden = 403,

        /// <summary>
        /// 請求的資源不在服務器上
        /// </summary>
        NotFound = 404,

        /// <summary>
        /// 內部錯誤
        /// </summary>
        InternalServerError = 500,

        /// <summary>
        /// 帳號密碼錯誤
        /// </summary>
        AccountPasswordError = 600,

        /// <summary>
        /// 使用者密碼錯誤
        /// </summary>
        UserPasswordError = 601,

        /// <summary>
        /// Session 無效
        /// </summary>
        SessionInvalid = 602,

        /// <summary>
        /// GameCode/SiteId錯誤
        /// </summary>
        ProxyGameCodeError = 604,

        /// <summary>
        /// ProductStatus停用(產品本身不開放)
        /// </summary>
        ProxyProductStatusError = 605,

        /// <summary>
        /// UserProductStatus停用(當前用戶不開放該產品)
        /// </summary>
        ProxyUserProductStatusError = 606,

        /// <summary>
        ///帳號異常
        /// </summary>
        ProxyUserAccountError = 607,

        /// <summary>
        /// 帐号存在
        /// </summary>
        ProxyUserExistError = 608,

        /// <summary>
        /// 帳號不存在
        /// </summary>
        ProxyUserNotExistError = 609,

        /// <summary>
        /// 帐号等级不存在
        /// </summary>
        ProxyUserLevelNotExistError = 610,

        /// <summary>
        /// 父帐号异常
        /// </summary>
        ProxyPAError = 611,

        /// <summary>
        /// 不能跨级操作
        /// </summary>
        ProxyCLError = 612,

        /// <summary>
        /// 币别错误
        /// </summary>
        ProxyCEError = 613,

        /// <summary>
        /// 站台存在
        /// </summary>
        ProxySEError = 614,

        /// <summary>
        /// 参数有误
        /// </summary>
        ProxyPEError = 615,

        /// <summary>
        /// 钱包异常
        /// </summary>
        ProxyWAError = 616,

        /// <summary>
        /// 转账异常
        /// </summary>
        ProxyTAError = 617,

        /// <summary>
        /// 获取URL异常
        /// </summary>
        ProxyURLAError = 618,

        /// <summary>
        /// 帐号等级不正确
        /// </summary>
        ProxyULEError = 619,

        /// <summary>
        /// 交易单号不存在
        /// </summary>
        ProxyFTFEError = 620,

        /// <summary>
        /// 额度不能为0 或者额度错误
        /// </summary>
        ProxyCDEError = 621,

        /// <summary>
        /// 额度不能超出上层额度
        /// </summary>
        ProxyCDEDError = 622,

        /// <summary>
        /// 未實作當前產品
        /// </summary>
        ProNoInitialize = 623,

        /// <summary>
        /// 當前站臺不存在該帳號
        /// </summary>
        ProNoThisUser = 624,

        /// <summary>
        /// 當前產品未開通
        /// </summary>
        ProNoOpen = 625,

        /// <summary>
        /// 此Api不支援當前體系
        /// </summary>
        ApiNoSupport = 626,

        /// <summary>
        /// 额度不能超出本身剩余额度
        /// </summary>
        ProxyBNCGError = 627,

        /// <summary>
        /// 位置錯誤
        /// </summary>
        UnKnow = 99999
    }
    #endregion

    #region SessionCodeName
    /// <summary>
    /// 統一Session Name
    /// </summary>
    public enum SessionCodeName : int
    {
        /// <summary>
        /// 登入者的選單權限
        /// List PV_UserMenuTree
        /// </summary>
        UserMenuTree = 1000,

        /// <summary>
        /// 登入者的相關資料
        /// DB_ManagerTModel
        /// </summary>
        UserInfo = 1100,

        /// <summary>
        /// 登入者的角色名稱
        /// string
        /// </summary>
        UserRoleName = 1200,

        /// <summary>
        /// 登入者目前所在的功能選單Menu 
        /// US_UserActionMenuTree
        /// </summary>
        UserActionMenuTree = 1300
    }
    #endregion
}