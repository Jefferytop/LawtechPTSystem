using System;
using System.Collections.Generic;
using H3Operator.DBHelper;
using H3Operator.DBModels;


namespace LawtechPTSystemByFirm.Public
{
    #region CPatentEstimateCost=================
    /// <summary>
    /// 
    /// </summary>
    [TableMapping("PatentEstimateCostT")]
    public class CPatentEstimateCost : SysBaseModel
    {
        #region Public property

        private int m_PTEstimateCostID;
        /// <summary>
        /// 預估成本資料表 PK
        /// </summary>
        [TableColumnSetting("PTEstimateCostID", DbType = SqlDataType.Int, IsPrimary = true, IsCumulative = true, IsCanNull = false, DataLength = 4)]
        public int PTEstimateCostID
        {
            get
            {
                return m_PTEstimateCostID;
            }
            set
            {
                m_PTEstimateCostID = value;
            }
        }

        private int m_PatentID;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("PatentID", DbType = SqlDataType.Int, IsCanNull = false, DataLength = 4)]
        public int PatentID
        {
            get
            {
                return m_PatentID;
            }
            set
            {
                m_PatentID = value;
            }
        }

        private DateTime? m_CreateDate;
        /// <summary>
        /// 預估日期
        /// </summary>
        [TableColumnSetting("CreateDate", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? CreateDate
        {
            get
            {
                return m_CreateDate;
            }
            set
            {
                m_CreateDate = value;
            }
        }

        private string m_FeeSubject;
        /// <summary>
        /// 費用內容
        /// </summary>
        [TableColumnSetting("FeeSubject", DataLength = 1000)]
        public string FeeSubject
        {
            get
            {
                return m_FeeSubject;
            }
            set
            {
                m_FeeSubject = value;
            }
        }

        private decimal? m_IAttorneyFee;
        /// <summary>
        /// 服務費
        /// </summary>
        [TableColumnSetting("IAttorneyFee", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? IAttorneyFee
        {
            get
            {
                return m_IAttorneyFee;
            }
            set
            {
                m_IAttorneyFee = value;
            }
        }

        private string m_IMoney;
        /// <summary>
        /// 服務費-幣別
        /// </summary>
        [TableColumnSetting("IMoney", DataLength = 200)]
        public string IMoney
        {
            get
            {
                return m_IMoney;
            }
            set
            {
                m_IMoney = value;
            }
        }

        private decimal? m_ItoNT;
        /// <summary>
        /// 服務費-兌換
        /// </summary>
        [TableColumnSetting("ItoNT", DbType = SqlDataType.Decimal, DataLength = 5)]
        public decimal? ItoNT
        {
            get
            {
                return m_ItoNT;
            }
            set
            {
                m_ItoNT = value;
            }
        }

        private decimal? m_ITotall;
        /// <summary>
        /// 服務費-合計NT
        /// </summary>
        [TableColumnSetting("ITotall", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? ITotall
        {
            get
            {
                return m_ITotall;
            }
            set
            {
                m_ITotall = value;
            }
        }

        private decimal? m_OAttorneyFee;
        /// <summary>
        /// 國外事務所費用
        /// </summary>
        [TableColumnSetting("OAttorneyFee", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? OAttorneyFee
        {
            get
            {
                return m_OAttorneyFee;
            }
            set
            {
                m_OAttorneyFee = value;
            }
        }

        private string m_OMoney;
        /// <summary>
        /// 國外事務所費用-幣別
        /// </summary>
        [TableColumnSetting("OMoney", DataLength = 200)]
        public string OMoney
        {
            get
            {
                return m_OMoney;
            }
            set
            {
                m_OMoney = value;
            }
        }

        private decimal? m_OtoNT;
        /// <summary>
        /// 國外事務所費用-匯率
        /// </summary>
        [TableColumnSetting("OtoNT", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? OtoNT
        {
            get
            {
                return m_OtoNT;
            }
            set
            {
                m_OtoNT = value;
            }
        }

        private decimal? m_OTotall;
        /// <summary>
        /// 國外事務所費用-合計NT
        /// </summary>
        [TableColumnSetting("OTotall", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? OTotall
        {
            get
            {
                return m_OTotall;
            }
            set
            {
                m_OTotall = value;
            }
        }

        private decimal? m_GovFee;
        /// <summary>
        /// 官方費用
        /// </summary>
        [TableColumnSetting("GovFee", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? GovFee
        {
            get
            {
                return m_GovFee;
            }
            set
            {
                m_GovFee = value;
            }
        }

        private string m_GMoney;
        /// <summary>
        /// 官方費用-幣別
        /// </summary>
        [TableColumnSetting("GMoney", DataLength = 200)]
        public string GMoney
        {
            get
            {
                return m_GMoney;
            }
            set
            {
                m_GMoney = value;
            }
        }

        private decimal? m_GtoNT;
        /// <summary>
        /// 官方費用-兌NT
        /// </summary>
        [TableColumnSetting("GtoNT", DbType = SqlDataType.Decimal, DataLength = 5)]
        public decimal? GtoNT
        {
            get
            {
                return m_GtoNT;
            }
            set
            {
                m_GtoNT = value;
            }
        }

        private decimal? m_GTotall;
        /// <summary>
        /// 官方費用-合計NT
        /// </summary>
        [TableColumnSetting("GTotall", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? GTotall
        {
            get
            {
                return m_GTotall;
            }
            set
            {
                m_GTotall = value;
            }
        }

        private decimal? m_OtherFee;
        /// <summary>
        /// 雜支
        /// </summary>
        [TableColumnSetting("OtherFee", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? OtherFee
        {
            get
            {
                return m_OtherFee;
            }
            set
            {
                m_OtherFee = value;
            }
        }

        private string m_OtherMoney;
        /// <summary>
        /// 雜支-幣別
        /// </summary>
        [TableColumnSetting("OtherMoney", DataLength = 200)]
        public string OtherMoney
        {
            get
            {
                return m_OtherMoney;
            }
            set
            {
                m_OtherMoney = value;
            }
        }

        private decimal? m_OtherNT;
        /// <summary>
        /// 雜支-兌NT
        /// </summary>
        [TableColumnSetting("OtherNT", DbType = SqlDataType.Decimal, DataLength = 5)]
        public decimal? OtherNT
        {
            get
            {
                return m_OtherNT;
            }
            set
            {
                m_OtherNT = value;
            }
        }

        private decimal? m_OtherTotal;
        /// <summary>
        /// 雜支-合計NT
        /// </summary>
        [TableColumnSetting("OtherTotal", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? OtherTotal
        {
            get
            {
                return m_OtherTotal;
            }
            set
            {
                m_OtherTotal = value;
            }
        }

        private decimal? m_EstimateCost;
        /// <summary>
        /// 預估成本
        /// </summary>
        [TableColumnSetting("EstimateCost", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? EstimateCost
        {
            get
            {
                return m_EstimateCost;
            }
            set
            {
                m_EstimateCost = value;
            }
        }

        private decimal? m_EstimateProfit;
        /// <summary>
        /// 預估利潤
        /// </summary>
        [TableColumnSetting("EstimateProfit", DbType = SqlDataType.Decimal, DataLength = 5)]
        public decimal? EstimateProfit
        {
            get
            {
                return m_EstimateProfit;
            }
            set
            {
                m_EstimateProfit = value;
            }
        }

        private decimal? m_ServicePrice;
        /// <summary>
        /// 預估報價
        /// </summary>
        [TableColumnSetting("ServicePrice", DbType = SqlDataType.Decimal, DataLength = 5)]
        public decimal? ServicePrice
        {
            get
            {
                return m_ServicePrice;
            }
            set
            {
                m_ServicePrice = value;
            }
        }

        private string m_PayMemo;
        /// <summary>
        /// 付款條件
        /// </summary>
        [TableColumnSetting("PayMemo", DataLength = 1000)]
        public string PayMemo
        {
            get
            {
                return m_PayMemo;
            }
            set
            {
                m_PayMemo = value;
            }
        }

        private decimal? m_RealPrice;
        /// <summary>
        /// 實際報價
        /// </summary>
        [TableColumnSetting("RealPrice", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? RealPrice
        {
            get
            {
                return m_RealPrice;
            }
            set
            {
                m_RealPrice = value;
            }
        }

        private string m_Remark;
        /// <summary>
        /// 備註
        /// </summary>
        [TableColumnSetting("Remark", DataLength = 6000)]
        public string Remark
        {
            get
            {
                return m_Remark;
            }
            set
            {
                m_Remark = value;
            }
        }

        private string m_Creator;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("Creator", DataLength = 100)]
        public string Creator
        {
            get
            {
                return m_Creator;
            }
            set
            {
                m_Creator = value;
            }
        }

        private int? m_Locker;
        /// <summary>
        /// 正在編輯者 進行資料鎖定, Null表示無人編輯中
        /// </summary>
        [TableColumnSetting("Locker", DbType = SqlDataType.Int, DataLength = 4)]
        public int? Locker
        {
            get
            {
                return m_Locker;
            }
            set
            {
                m_Locker = value;
            }
        }

        private string m_LastModifyWorker;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("LastModifyWorker", DataLength = 100)]
        public string LastModifyWorker
        {
            get
            {
                return m_LastModifyWorker;
            }
            set
            {
                m_LastModifyWorker = value;
            }
        }

        #endregion

        #region Method

        #region 確認指定欄位的值是否存在 CheckValueExist(string ColumnName, object Value ,ref bool IsExist, bool IsCreateMode = true)
        /// <summary>
        /// 確認指定欄位的值是否存在，true:已存在相同的值 ; false : 未存在 (有新增和編輯模式)
        /// </summary>
        /// <param name="ColumnName">欄位名稱</param>
        /// <param name="Value">要確認指定欄位是否有此值(只提供字串[string] 或數字[int])</param>
        /// <param name="IsExist">ture:已存在該值的資料 ; false:不存在該值的資料</param>
        /// <param name="IsCreateMode">模式 true:新增模式(預設值) ; false:編輯模式(排除本身的)</param>
        /// <returns>0:成功 ; string:失敗</returns>
        public object CheckValueExist(string ColumnName, object Value, ref bool IsExist, bool IsCreateMode = true)
        {
            ORMFactory orm = new ORMFactory();
            List<CPatentEstimateCost> list = new List<CPatentEstimateCost>();
            System.Data.SqlClient.SqlParameter para;

            if (Value.GetType() == string.Empty.GetType())
            {
                para = DBAccess.MakeInParam(ColumnName, SqlDataType.NVarChar, Value.ToString());
            }
            else
            {
                para = DBAccess.MakeInParam(ColumnName, SqlDataType.Int, (int)Value);
            }

            System.Data.SqlClient.SqlParameter[] ParList = { para };
            object retObj;
            if (IsCreateMode)
            {
                retObj = orm.ReadListToObjs<CPatentEstimateCost>(ColumnName + "=@" + ColumnName, ref list, ParList);
            }
            else
            {
                retObj = orm.ReadListToObjs<CPatentEstimateCost>(ColumnName + "=@" + ColumnName + " and PTEstimateCostID<>" + this.PTEstimateCostID.ToString(), ref list, ParList);
            }

            if (retObj.ToString() == "0")
            {
                if (list.Count > 0)
                {
                    IsExist = true;
                }
                else
                {
                    IsExist = false;
                }
            }
            return retObj;
        }
        #endregion

        #region 取得一筆資料  ReadOne(ref CPatentEstimateCost Item, string strCusTableName = ")
        /// <summary>
        /// 取得一筆PatentEstimateCostT資料
        /// </summary>          
        /// <param name="item"></param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>       
        public static object ReadOne(ref CPatentEstimateCost Item, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadOneToObj(ref Item, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆資料 ReadOne(int iPKey, ref DB_MenuRoleTModel item, string strCusTableName = "")
        /// <summary>
        /// 取得一筆PatentEstimateCostT資料
        /// </summary>
        /// <param name="iPKey">指定某筆資料的Key值(不適合複合key)</param>     
        /// <param name="item"></param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>       
        public static object ReadOne(int iPKey, ref CPatentEstimateCost item, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadOneToObj(iPKey, ref item, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆PatentEstimateCostT資料 ReadOne(string strSqlWhere, System.Data.SqlClient.SqlParameter[] MySqlParameterList=null, string strCusTableName = "")
        /// <summary>
        /// 取得一筆PatentEstimateCostT資料;如果有多筆符合條件，則只回傳null
        /// </summary>
        /// <param name="strSqlWhere">查詢條件(不用加「where」關鍵字, 可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>
        public static object ReadOne(string strSqlWhere, ref CPatentEstimateCost item, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            List<CPatentEstimateCost> itemlist = new List<CPatentEstimateCost>();
            object retObj = orm.ReadListToObjs(strSqlWhere, ref itemlist, sqlParameterList: MySqlParameterList, CusTableName: strCusTableName);
            if (retObj.ToString() == "0" && itemlist.Count > 0)
            {
                if (itemlist.Count == 1)
                {
                    item = itemlist[0];
                }
                else
                {
                    retObj = "Error：有一筆以上的資料";
                }
            }
            return retObj;
        }
        #endregion

        #region 取得多筆CPatentEstimateCost資料 ReadList
        /// <summary>
        /// 取得多筆 PatentEstimateCostT資料 
        /// </summary>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns></returns>
        public static object ReadList(ref List<CPatentEstimateCost> Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadListToObjs<CPatentEstimateCost>(strSqlWhere, ref Items, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }

        #endregion

        #region 取得多筆 PatentEstimateCostT資料 , 指定頁數和頁碼 ReadList
        /// <summary>
        /// 取得多筆 PatentEstimateCostT資料 , 指定頁數和頁碼
        /// </summary>
        /// <param name="PageSize">一頁的筆數</param>
        /// <param name="PageIndex">第 n 頁</param>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>       
        /// <returns></returns>
        public static object ReadList(int PageSize, int PageIndex, ref List<CPatentEstimateCost> Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadListToObjs<CPatentEstimateCost>(PageSize, PageIndex, strSqlWhere, ref Items, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }
        #endregion

        #region Create
        /// <summary>
        /// 新增PatentEstimateCostT 項目
        /// </summary> 
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns>0:成功 ; string:失敗</returns>
        public object Create(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.InsertByObj<CPatentEstimateCost>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新 PatentEstimateCostT 項目
        /// </summary>       
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param> 
        /// <returns>0:成功 ; string:失敗</returns>
        public object Update(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.UpdateObj<CPatentEstimateCost>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region Delete

        #region 刪除項目PatentEstimateCostT Delete()
        /// <summary>
        /// 刪除項目PatentEstimateCostT
        /// </summary>  
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns></returns>   
        public object Delete(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CPatentEstimateCost>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region 刪除項目PatentEstimateCostT Delete(int iPKey)
        /// <summary>
        /// 刪除項目PatentEstimateCostT , 指定某一筆主鍵刪除(單筆)
        /// </summary>
        /// <param name="iPKey">指定刪除某筆資料的Key值</param> 
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns></returns>
        public object Delete(int iPKey, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CPatentEstimateCost>(iPKey, strCusTableName);
            return retObj;
        }
        #endregion

        #region 刪除項目PatentEstimateCostT Delete(string strSqlWhere)
        /// <summary>
        /// 刪除項目PatentEstimateCostT ,符合條件刪除(多筆)
        /// </summary>
        /// <param name="strSqlWhere">查詢條件(不用加「where」關鍵字)</param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>    
        /// <returns></returns>
        public object Delete(string strSqlWhere, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CPatentEstimateCost>(strSqlWhere, strCusTableName);
            return retObj;
        }
        #endregion

        #endregion

        #endregion
    }
    #endregion =================
}
