using System.Collections.Generic;

namespace LawtechPTSystemByFirm.Public
{
    /// <summary>
    /// 系統通用設定
    /// </summary>
    public class CCommonPublicFunction
    {
        public CCommonPublicFunction()
        {
            List<Public.CStatueRecordT> record = new List<CStatueRecordT>();
            Public.CStatueRecordT.ReadList(ref record, "StatusName in('SystemName',  'EnableAddFee' ,'EnableAddPayment','WebSystemName','GoogleAnalytics') ");
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
    }
}
