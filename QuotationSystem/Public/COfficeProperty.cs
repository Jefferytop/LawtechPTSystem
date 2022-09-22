using System;
using System.Collections.Generic;
using H3Operator.DBHelper;
using H3Operator.DBModels;

namespace LawtechPTSystem.Public
{
    #region COfficeProperty=================
    /// <summary>
    /// 
    /// </summary>
    [TableMapping("OfficePropertyT")]
    public class COfficeProperty : SysBaseModel
    {
        #region Public property

        private int m_OfficePropertyID;
        /// <summary>
        /// 所內財產清單
        /// </summary>
        [TableColumnSetting("OfficePropertyID", DbType = SqlDataType.Int, IsPrimary = true, IsCumulative = true, IsCanNull = false, DataLength = 4)]
        public int OfficePropertyID
        {
            get
            {
                return m_OfficePropertyID;
            }
            set
            {
                m_OfficePropertyID = value;
            }
        }

        private string m_OfficePropertyNo;
        /// <summary>
        /// 財產編號
        /// </summary>
        [TableColumnSetting("OfficePropertyNo", DataLength = 300)]
        public string OfficePropertyNo
        {
            get
            {
                return m_OfficePropertyNo;
            }
            set
            {
                m_OfficePropertyNo = value;
            }
        }

        private string m_OfficePropertyName;
        /// <summary>
        /// 單位財產名稱
        /// </summary>
        [TableColumnSetting("OfficePropertyName", DataLength = 4000)]
        public string OfficePropertyName
        {
            get
            {
                return m_OfficePropertyName;
            }
            set
            {
                m_OfficePropertyName = value;
            }
        }

        private DateTime? m_CreateDate;
        /// <summary>
        /// 建檔時間
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

        private DateTime? m_BuyDate;
        /// <summary>
        /// 購買時間
        /// </summary>
        [TableColumnSetting("BuyDate", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? BuyDate
        {
            get
            {
                return m_BuyDate;
            }
            set
            {
                m_BuyDate = value;
            }
        }

        private string m_WarrantyTime;
        /// <summary>
        /// 保固時間
        /// </summary>
        [TableColumnSetting("WarrantyTime", DataLength = 1000)]
        public string WarrantyTime
        {
            get
            {
                return m_WarrantyTime;
            }
            set
            {
                m_WarrantyTime = value;
            }
        }

        private decimal? m_Amount;
        /// <summary>
        /// 購買金額
        /// </summary>
        [TableColumnSetting("Amount", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? Amount
        {
            get
            {
                return m_Amount;
            }
            set
            {
                m_Amount = value;
            }
        }

        private string m_Currency;
        /// <summary>
        /// 幣別
        /// </summary>
        [TableColumnSetting("Currency", DataLength = 100)]
        public string Currency
        {
            get
            {
                return m_Currency;
            }
            set
            {
                m_Currency = value;
            }
        }

        private decimal? m_ExchangeRate;
        /// <summary>
        /// 當時匯率
        /// </summary>
        [TableColumnSetting("ExchangeRate", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? ExchangeRate
        {
            get
            {
                return m_ExchangeRate;
            }
            set
            {
                m_ExchangeRate = value;
            }
        }

        private decimal? m_TotalNT;
        /// <summary>
        /// 合計NT
        /// </summary>
        [TableColumnSetting("TotalNT", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? TotalNT
        {
            get
            {
                return m_TotalNT;
            }
            set
            {
                m_TotalNT = value;
            }
        }

        private string m_Specifications;
        /// <summary>
        /// 詳細規格
        /// </summary>
        [TableColumnSetting("Specifications", DataLength = 6000)]
        public string Specifications
        {
            get
            {
                return m_Specifications;
            }
            set
            {
                m_Specifications = value;
            }
        }

        private string m_FunctionDescription;
        /// <summary>
        /// 功能說明
        /// </summary>
        [TableColumnSetting("FunctionDescription")]
        public string FunctionDescription
        {
            get
            {
                return m_FunctionDescription;
            }
            set
            {
                m_FunctionDescription = value;
            }
        }

        private string m_InvoiceNumber;
        /// <summary>
        /// 發票號碼
        /// </summary>
        [TableColumnSetting("InvoiceNumber", DataLength = 1000)]
        public string InvoiceNumber
        {
            get
            {
                return m_InvoiceNumber;
            }
            set
            {
                m_InvoiceNumber = value;
            }
        }

        private string m_OfficePropertyType;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("OfficePropertyType", DataLength = 1000)]
        public string OfficePropertyType
        {
            get
            {
                return m_OfficePropertyType;
            }
            set
            {
                m_OfficePropertyType = value;
            }
        }

        private string m_Unit;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("Unit", DataLength = 1000)]
        public string Unit
        {
            get
            {
                return m_Unit;
            }
            set
            {
                m_Unit = value;
            }
        }

        private string m_Location;
        /// <summary>
        /// 所在地
        /// </summary>
        [TableColumnSetting("Location", DataLength = 1000)]
        public string Location
        {
            get
            {
                return m_Location;
            }
            set
            {
                m_Location = value;
            }
        }

        private string m_Owner;
        /// <summary>
        /// 目前保管人
        /// </summary>
        [TableColumnSetting("Owner", DataLength = 1000)]
        public string Owner
        {
            get
            {
                return m_Owner;
            }
            set
            {
                m_Owner = value;
            }
        }

        private string m_Parts;
        /// <summary>
        /// 配件
        /// </summary>
        [TableColumnSetting("Parts", DataLength = 4000)]
        public string Parts
        {
            get
            {
                return m_Parts;
            }
            set
            {
                m_Parts = value;
            }
        }

        private string m_Status;
        /// <summary>
        /// 狀態(10.使用中 15.列管中 20.報修中 30.報廢)
        /// </summary>
        [TableColumnSetting("Status", DataLength = 1000)]
        public string Status
        {
            get
            {
                return m_Status;
            }
            set
            {
                m_Status = value;
            }
        }

        private string m_Memo;
        /// <summary>
        /// 備註
        /// </summary>
        [TableColumnSetting("Memo", DataLength = 6000)]
        public string Memo
        {
            get
            {
                return m_Memo;
            }
            set
            {
                m_Memo = value;
            }
        }

        private DateTime? m_LastModifyDate;
        /// <summary>
        /// 最後修改時間
        /// </summary>
        [TableColumnSetting("LastModifyDate", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? LastModifyDate
        {
            get
            {
                return m_LastModifyDate;
            }
            set
            {
                m_LastModifyDate = value;
            }
        }

        private int? m_LastModifyWorker;
        /// <summary>
        /// 最後修改者
        /// </summary>
        [TableColumnSetting("LastModifyWorker", DbType = SqlDataType.Int, DataLength = 4)]
        public int? LastModifyWorker
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
            List<COfficeProperty> list = new List<COfficeProperty>();
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
                retObj = orm.ReadListToObjs<COfficeProperty>(ColumnName + "=@" + ColumnName, ref list, ParList);
            }
            else
            {
                retObj = orm.ReadListToObjs<COfficeProperty>(ColumnName + "=@" + ColumnName + " and OfficePropertyID<>" + this.OfficePropertyID.ToString(), ref list, ParList);
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

        #region 取得一筆資料  ReadOne(ref COfficeProperty Item, string strCusTableName = ")
        /// <summary>
        /// 取得一筆OfficePropertyT資料
        /// </summary>          
        /// <param name="item"></param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>       
        public static object ReadOne(ref COfficeProperty Item, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadOneToObj(ref Item, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆資料 ReadOne(int iPKey, ref DB_MenuRoleTModel item, string strCusTableName = "")
        /// <summary>
        /// 取得一筆OfficePropertyT資料
        /// </summary>
        /// <param name="iPKey">指定某筆資料的Key值(不適合複合key)</param>     
        /// <param name="item"></param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>       
        public static object ReadOne(int iPKey, ref COfficeProperty item, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadOneToObj(iPKey, ref item, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆OfficePropertyT資料 ReadOne(string strSqlWhere, System.Data.SqlClient.SqlParameter[] MySqlParameterList=null, string strCusTableName = "")
        /// <summary>
        /// 取得一筆OfficePropertyT資料;如果有多筆符合條件，則只回傳null
        /// </summary>
        /// <param name="strSqlWhere">查詢條件(不用加「where」關鍵字, 可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>
        public static object ReadOne(string strSqlWhere, ref COfficeProperty item, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            List<COfficeProperty> itemlist = new List<COfficeProperty>();
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

        #region 取得多筆COfficeProperty資料 ReadList
        /// <summary>
        /// 取得多筆 OfficePropertyT資料 
        /// </summary>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns></returns>
        public static object ReadList(ref List<COfficeProperty> Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadListToObjs<COfficeProperty>(strSqlWhere, ref Items, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }

        #endregion

        #region 取得多筆 OfficePropertyT資料 , 指定頁數和頁碼 ReadList
        /// <summary>
        /// 取得多筆 OfficePropertyT資料 , 指定頁數和頁碼
        /// </summary>
        /// <param name="PageSize">一頁的筆數</param>
        /// <param name="PageIndex">第 n 頁</param>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>       
        /// <returns></returns>
        public static object ReadList(int PageSize, int PageIndex, ref List<COfficeProperty> Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadListToObjs<COfficeProperty>(PageSize, PageIndex, strSqlWhere, ref Items, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }
        #endregion

        #region Create
        /// <summary>
        /// 新增OfficePropertyT 項目
        /// </summary> 
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns>0:成功 ; string:失敗</returns>
        public object Create(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.InsertByObj<COfficeProperty>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新 OfficePropertyT 項目
        /// </summary>       
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param> 
        /// <returns>0:成功 ; string:失敗</returns>
        public object Update(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.UpdateObj<COfficeProperty>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region Delete

        #region 刪除項目OfficePropertyT Delete()
        /// <summary>
        /// 刪除項目OfficePropertyT
        /// </summary>  
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns></returns>   
        public object Delete(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<COfficeProperty>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region 刪除項目OfficePropertyT Delete(int iPKey)
        /// <summary>
        /// 刪除項目OfficePropertyT , 指定某一筆主鍵刪除(單筆)
        /// </summary>
        /// <param name="iPKey">指定刪除某筆資料的Key值</param> 
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns></returns>
        public object Delete(int iPKey, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<COfficeProperty>(iPKey, strCusTableName);
            return retObj;
        }
        #endregion

        #region 刪除項目OfficePropertyT Delete(string strSqlWhere)
        /// <summary>
        /// 刪除項目OfficePropertyT ,符合條件刪除(多筆)
        /// </summary>
        /// <param name="strSqlWhere">查詢條件(不用加「where」關鍵字)</param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>    
        /// <returns></returns>
        public object Delete(string strSqlWhere, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<COfficeProperty>(strSqlWhere, strCusTableName);
            return retObj;
        }
        #endregion

        #endregion

        #endregion
    }
    #endregion =================
   
}
