using System.Collections.Generic;

namespace LawtechPTSystem.Public
{
    /// <summary>
    /// 系統通用設定, StatueRecordT
    /// </summary>
    public class CCommonPublicFunction
    {
        /// <summary>
        /// 系統通用設定, StatueRecordT
        /// </summary>
        public CCommonPublicFunction()
        {
            List<Public.CStatueRecordT> record = new List<CStatueRecordT>();
            Public.CStatueRecordT.ReadList(ref record, "StatusName in('SystemName',  'EnableAddFee' ,'EnableAddPayment','WebSystemName','GoogleAnalytics' ,'LoginLogo','QuotationLogo' , 'MACSettingType','FileServerType' ,'FileServer_LocalhostPath','IsFileServer' ,'IntranetPath' ,'HomePageEvent','HistoryRecordMode','DataBaseVersion') ");
            foreach (var item in record)
            {
                if (item.StatusName == "SystemName")
                {
                    this.SystemName = item.Value;
                }
                else if (item.StatusName == "EnableAddFee")
                {
                    if (string.IsNullOrEmpty(item.Value))
                    {
                        this.EnableAddFee = false;
                    }
                    else
                    {
                        this.EnableAddFee = item.Value=="1"?true:false;
                    }
                }
                else if (item.StatusName == "EnableAddPayment")
                {
                    if (string.IsNullOrEmpty(item.Value))
                    {
                        this.EnableAddPayment = false;
                    }
                    else
                    {
                        this.EnableAddPayment = item.Value == "1" ? true : false;
                    }
                }
                else if (item.StatusName == "WebSystemName")
                {
                    this.WebSystemName = item.Value;
                }
                else if (item.StatusName == "GoogleAnalytics")
                {
                    this.GoogleAnalytics = item.Value;
                }
                else if (item.StatusName == "LoginLogo")
                {
                    this.LoginLogo = item.Value;
                }
                else if (item.StatusName == "QuotationLogo")
                {
                    this.QuotationLogo = item.Value;
                }
                else if(item.StatusName == "MACSettingType")
                {
                    this.MACSettingType = item.Value;
                }
                else if (item.StatusName == "FileServerType")
                {
                    this.FileServerType = item.Value;
                }
                else if (item.StatusName == "FileServer_LocalhostPath")
                {
                    this.FileServer_LocalhostPath = item.Value;
                }
                else if (item.StatusName == "IsFileServer")
                {
                    this.IsFileServer = item.Value== "1"?true:false;
                }
                else if (item.StatusName == "IntranetPath")
                {
                    this.IntranetPath = item.Value ;
                }
                else if (item.StatusName == "HomePageEvent")
                {
                    this.HomePageEvent = item.Value;
                }
                else if (item.StatusName == "HistoryRecordMode")
                {
                    this.HistoryRecordMode = item.Value;
                }
                else if (item.StatusName == "DataBaseVersion")
                {
                    this.DataBaseVersion = item.Value;
                }


            }
        }

        /// <summary>
        /// 系統名稱
        /// </summary>
        public string SystemName
        {
            get;
            set;
        }

        /// <summary>
        /// 申請人案件進度查詢網站名稱
        /// </summary>
        public string WebSystemName
        {
            get;
            set;
        }

        /// <summary>
        /// Google Analytics(GA)
        /// </summary>
        public string GoogleAnalytics
        {
            get;
            set;
        }

        /// <summary>
        /// 是否啟用新增費用功能; 1: 停用 , 0:不停用
        /// </summary>
        public bool EnableAddFee
        {
            get;
            set;
        }

        /// <summary>
        /// 是否啟用新增付款功能; 1: 停用 , 0:不停用
        /// </summary>
        public bool EnableAddPayment
        {
            get;
            set;
        }

        /// <summary>
        /// 登入頁使用的logo
        /// </summary>
        public string LoginLogo
        {
            get;
            set;
        }

        /// <summary>
        /// 報價單使用的logo
        /// </summary>
        public string QuotationLogo
        {
            get;
            set;
        }

        /// <summary>
        /// 1:不啟用  ; 2:綁定MAC位址; 3:綁定 MAC位址+登入帳號
        /// </summary>
        public string MACSettingType
        {
            get;
            set;
        }

        /// <summary>
        ///0:本機路徑 ; 1:區域網路
        /// </summary>
        public string FileServerType
        {
            get;
            set;
        }

        /// <summary>
        /// 是否啟用檔案伺服器
        /// </summary>
        public bool  IsFileServer
        {
            get; set;
        }

        /// <summary>
        /// 系統預設本機路徑
        /// </summary>
        public string FileServer_LocalhostPath
        {
            get;set;
        }

        /// <summary>
        ///  區域網路路徑 
        /// </summary>
        public string IntranetPath
        {
            get; set;
        }

        /// <summary>
        ///  0:僅僅「處理結果」、「備註」 欄位可編輯 ; 9:完整編輯事件記錄
        /// </summary>
        public string HomePageEvent
        {
            get; set;
        }

        /// <summary>
        ///0:不提供檢視案件詳細資料; 10:供檢視案件詳細資料+事件記錄 ; 99:檢視完整案件詳細資料
        /// </summary>
        public string HistoryRecordMode
        {
            get; set;
        }

        /// <summary>
        /// 首頁是否啟用新增事件記錄
        /// </summary>
        public string AddEnable
        {
            get;set;
        }

        /// <summary>
        /// 目前資料庫版本
        /// </summary>
        public string DataBaseVersion
        {
            get; set;
        }

    }
}
