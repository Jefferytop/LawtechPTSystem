using System;
using System.Collections.Generic;
using System.Text;

namespace LawtechPTSystemByFirm.Public
{
    public enum SkinType
    {
        DiamondBlue,
        DeepCyan,
        Eighteen,
        Emerald,
        GlassBrown,
        Longhorn,
        MacOS,
        Midsummer,
        MP10,
        MSN,
        OneBlue,
        Page,
        RealOne,
        Silver,
        SportsBlack,
        SteelBlack,
        vista1,
        Vista2,
        Warm,
        Wave,
        XPSilver
    }

    public enum CreateFolerdMode
    {
        BasedOn=1,
        Upload=2,
        Patent=3,
        Trademark=4,
        TrademarkControversy = 5,
        OfficeProperty=6,
        KM=10,
        EmailLog=20,
        UpFileLog=30
    }

    public enum SystemType
    {
        BasedOn = 1,
        Upload = 2,
        Patent = 3,
        Trademark = 4
    }

    /// <summary>
    /// 聯絡窗口
    /// </summary>
    public enum WindowType
    {
        /// <summary>
        /// 信件窗口
        /// </summary>
        MailContract=1,

        /// <summary>
        /// 專利案窗口
        /// </summary>
        PatContract=2,

        /// <summary>
        /// 商標案窗口
        /// </summary>
        TMContract=3,

        /// <summary>
        /// 請款窗口
        /// </summary>
        PaymentContract=4,

        /// <summary>
        /// 催款窗口
        /// </summary>
        DunningContract=5,

        /// <summary>
        /// 全部
        /// </summary>
        ALL = 6
    }

    /// <summary>
    /// 授權角色
    /// </summary>
    public enum OfficeRoleEnum
    {
        /// <summary>
        /// 最高權限
        /// </summary>
        AdminRole = 0,

        /// <summary>
        /// 指定授權(一般員工)
        /// </summary>
        NormalRole = 1,

        /// <summary>
        /// 專利主管權限
        /// </summary>
        PatRole = 2,

        /// <summary>
        /// 商標主管權限
        /// </summary>
        TmRole = 3,

        /// <summary>
        /// 帳務主管權限
        /// </summary>
        LegalRole = 4
    }

    public enum EmailSampleType
    {
        Patent,
        Trademark
    }
}
