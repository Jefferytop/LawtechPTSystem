using H3Operator.DBHelper;
using H3Operator.DBModels;
using System.Collections.Generic;

namespace LawtechPTSystemByFirm.Public
{
    #region CnTriff=================
    /// <summary>
    /// 標準牌價資料表
    /// </summary>
    [TableMapping("nTriffT")]
    public class CnTriff : SysBaseModel
    {
        #region Public property

        private int m_FeeSN;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("FeeSN", DbType = SqlDataType.Int, IsPrimary = true, IsCumulative = true, IsCanNull = false, DataLength = 4)]
        public int FeeSN
        {
            get
            {
                return m_FeeSN;
            }
            set
            {
                m_FeeSN = value;
            }
        }

        private int? m_Sort;
        /// <summary>
        /// 排序
        /// </summary>
        [TableColumnSetting("Sort", DbType = SqlDataType.Int, DataLength = 4)]
        public int? Sort
        {
            get
            {
                return m_Sort;
            }
            set
            {
                m_Sort = value;
            }
        }

        private string m_CountrySymbol;
        /// <summary>
        /// 國別
        /// </summary>
        [TableColumnSetting("CountrySymbol", DataLength = 200)]
        public string CountrySymbol
        {
            get
            {
                return m_CountrySymbol;
            }
            set
            {
                m_CountrySymbol = value;
            }
        }

        private string m_KindSN;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("KindSN", DataLength = 40)]
        public string KindSN
        {
            get
            {
                return m_KindSN;
            }
            set
            {
                m_KindSN = value;
            }
        }

        private string m_ProcedureName;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("ProcedureName", DataLength = 200)]
        public string ProcedureName
        {
            get
            {
                return m_ProcedureName;
            }
            set
            {
                m_ProcedureName = value;
            }
        }

        private string m_ProcedureName_CHS;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("ProcedureName_CHS", DataLength = 2000)]
        public string ProcedureName_CHS
        {
            get
            {
                return m_ProcedureName_CHS;
            }
            set
            {
                m_ProcedureName_CHS = value;
            }
        }

        private string m_ProcedureName_EN;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("ProcedureName_EN", DataLength = 4000)]
        public string ProcedureName_EN
        {
            get
            {
                return m_ProcedureName_EN;
            }
            set
            {
                m_ProcedureName_EN = value;
            }
        }

        private int? m_PhaseKEY;
        /// <summary>
        /// 所屬階段
        /// </summary>
        [TableColumnSetting("PhaseKEY", DbType = SqlDataType.Int, DataLength = 4)]
        public int? PhaseKEY
        {
            get
            {
                return m_PhaseKEY;
            }
            set
            {
                m_PhaseKEY = value;
            }
        }

        private string m_Examtime;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("Examtime", DataLength = 1000)]
        public string Examtime
        {
            get
            {
                return m_Examtime;
            }
            set
            {
                m_Examtime = value;
            }
        }

        private decimal? m_GovFee;
        /// <summary>
        /// 
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

        private decimal? m_GovFeeNT;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("GovFeeNT", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? GovFeeNT
        {
            get
            {
                return m_GovFeeNT;
            }
            set
            {
                m_GovFeeNT = value;
            }
        }

        private string m_MoneyKindG;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("MoneyKindG", DataLength = 20)]
        public string MoneyKindG
        {
            get
            {
                return m_MoneyKindG;
            }
            set
            {
                m_MoneyKindG = value;
            }
        }

        private int? m_AttorneyKey;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("AttorneyKey", DbType = SqlDataType.Int, DataLength = 4)]
        public int? AttorneyKey
        {
            get
            {
                return m_AttorneyKey;
            }
            set
            {
                m_AttorneyKey = value;
            }
        }

        private decimal? m_AttorneyFee;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("AttorneyFee", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? AttorneyFee
        {
            get
            {
                return m_AttorneyFee;
            }
            set
            {
                m_AttorneyFee = value;
            }
        }

        private decimal? m_AttorneyELFeeNT;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("AttorneyELFeeNT", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? AttorneyELFeeNT
        {
            get
            {
                return m_AttorneyELFeeNT;
            }
            set
            {
                m_AttorneyELFeeNT = value;
            }
        }

        private decimal? m_AttorneyElseFee;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("AttorneyElseFee", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? AttorneyElseFee
        {
            get
            {
                return m_AttorneyElseFee;
            }
            set
            {
                m_AttorneyElseFee = value;
            }
        }

        private decimal? m_AttorneyElseFeeNT;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("AttorneyElseFeeNT", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? AttorneyElseFeeNT
        {
            get
            {
                return m_AttorneyElseFeeNT;
            }
            set
            {
                m_AttorneyElseFeeNT = value;
            }
        }

        private decimal? m_NotifyFee;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("NotifyFee", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? NotifyFee
        {
            get
            {
                return m_NotifyFee;
            }
            set
            {
                m_NotifyFee = value;
            }
        }

        private decimal? m_NotifyFeeNT;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("NotifyFeeNT", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? NotifyFeeNT
        {
            get
            {
                return m_NotifyFeeNT;
            }
            set
            {
                m_NotifyFeeNT = value;
            }
        }

        private string m_MoneyKind;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("MoneyKind", DataLength = 20)]
        public string MoneyKind
        {
            get
            {
                return m_MoneyKind;
            }
            set
            {
                m_MoneyKind = value;
            }
        }

        private decimal? m_TranFee;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("TranFee", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? TranFee
        {
            get
            {
                return m_TranFee;
            }
            set
            {
                m_TranFee = value;
            }
        }

        private decimal? m_WriteFee;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("WriteFee", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? WriteFee
        {
            get
            {
                return m_WriteFee;
            }
            set
            {
                m_WriteFee = value;
            }
        }

        private decimal? m_SafeFee;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("SafeFee", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? SafeFee
        {
            get
            {
                return m_SafeFee;
            }
            set
            {
                m_SafeFee = value;
            }
        }

        private decimal? m_AttorneyFeeNT;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("AttorneyFeeNT", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? AttorneyFeeNT
        {
            get
            {
                return m_AttorneyFeeNT;
            }
            set
            {
                m_AttorneyFeeNT = value;
            }
        }

        private decimal? m_AttorneyGovFee;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("AttorneyGovFee", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? AttorneyGovFee
        {
            get
            {
                return m_AttorneyGovFee;
            }
            set
            {
                m_AttorneyGovFee = value;
            }
        }

        private decimal? m_MeFee;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("MeFee", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? MeFee
        {
            get
            {
                return m_MeFee;
            }
            set
            {
                m_MeFee = value;
            }
        }

        private decimal? m_Totall;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("Totall", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? Totall
        {
            get
            {
                return m_Totall;
            }
            set
            {
                m_Totall = value;
            }
        }

        private decimal? m_QuotaTotal;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("QuotaTotal", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? QuotaTotal
        {
            get
            {
                return m_QuotaTotal;
            }
            set
            {
                m_QuotaTotal = value;
            }
        }

        private string m_SignDocument;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("SignDocument", DataLength = 240)]
        public string SignDocument
        {
            get
            {
                return m_SignDocument;
            }
            set
            {
                m_SignDocument = value;
            }
        }

        private decimal? m_ToNT;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("ToNT", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? ToNT
        {
            get
            {
                return m_ToNT;
            }
            set
            {
                m_ToNT = value;
            }
        }

        private decimal? m_ToNTG;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("ToNTG", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? ToNTG
        {
            get
            {
                return m_ToNTG;
            }
            set
            {
                m_ToNTG = value;
            }
        }

        private string m_Remark;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("Remark", DataLength = 8000)]
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

        private string m_Remark_CHS;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("Remark_CHS", DataLength = 8000)]
        public string Remark_CHS
        {
            get
            {
                return m_Remark_CHS;
            }
            set
            {
                m_Remark_CHS = value;
            }
        }

        private string m_Remark_EN;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("Remark_EN", DataLength = 8000)]
        public string Remark_EN
        {
            get
            {
                return m_Remark_EN;
            }
            set
            {
                m_Remark_EN = value;
            }
        }

        private string m_MeRemark;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("MeRemark", DataLength = 8000)]
        public string MeRemark
        {
            get
            {
                return m_MeRemark;
            }
            set
            {
                m_MeRemark = value;
            }
        }

        private string m_MeRemark_CHS;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("MeRemark_CHS", DataLength = 8000)]
        public string MeRemark_CHS
        {
            get
            {
                return m_MeRemark_CHS;
            }
            set
            {
                m_MeRemark_CHS = value;
            }
        }

        private string m_MeRemark_EN;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("MeRemark_EN", DataLength = 8000)]
        public string MeRemark_EN
        {
            get
            {
                return m_MeRemark_EN;
            }
            set
            {
                m_MeRemark_EN = value;
            }
        }

        private decimal? m_Gain;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("Gain", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? Gain
        {
            get
            {
                return m_Gain;
            }
            set
            {
                m_Gain = value;
            }
        }

        private bool? m_LargeEntity;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("LargeEntity", DbType = SqlDataType.Bit, DataLength = 1)]
        public bool? LargeEntity
        {
            get
            {
                return m_LargeEntity;
            }
            set
            {
                m_LargeEntity = value;
            }
        }

        private bool? m_ForStander;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("ForStander", DbType = SqlDataType.Bit, DataLength = 1)]
        public bool? ForStander
        {
            get
            {
                return m_ForStander;
            }
            set
            {
                m_ForStander = value;
            }
        }

        private string m_NofityContent;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("NofityContent", DataLength = 400)]
        public string NofityContent
        {
            get
            {
                return m_NofityContent;
            }
            set
            {
                m_NofityContent = value;
            }
        }

        private decimal? m_BeforeTotal;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("BeforeTotal", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? BeforeTotal
        {
            get
            {
                return m_BeforeTotal;
            }
            set
            {
                m_BeforeTotal = value;
            }
        }

        private string m_AfterProcess;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("AfterProcess", DataLength = 8000)]
        public string AfterProcess
        {
            get
            {
                return m_AfterProcess;
            }
            set
            {
                m_AfterProcess = value;
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
            List<CnTriff> list = new List<CnTriff>();
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
                retObj = orm.ReadListToObjs<CnTriff>(ColumnName + "=@" + ColumnName, ref list, ParList);
            }
            else
            {
                retObj = orm.ReadListToObjs<CnTriff>(ColumnName + "=@" + ColumnName + " and FeeSN<>" + this.FeeSN.ToString(), ref list, ParList);
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

        #region 取得一筆資料  ReadOne(ref CnTriff Item, string strCusTableName = ")
        /// <summary>
        /// 取得一筆nTriffT資料
        /// </summary>          
        /// <param name="item"></param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>       
        public static object ReadOne(ref CnTriff Item, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadOneToObj(ref Item, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆資料 ReadOne(int iPKey, ref DB_MenuRoleTModel item, string strCusTableName = "")
        /// <summary>
        /// 取得一筆nTriffT資料
        /// </summary>
        /// <param name="iPKey">指定某筆資料的Key值(不適合複合key)</param>     
        /// <param name="item"></param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>       
        public static object ReadOne(int iPKey, ref CnTriff item, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadOneToObj(iPKey, ref item, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆nTriffT資料 ReadOne(string strSqlWhere, System.Data.SqlClient.SqlParameter[] MySqlParameterList=null, string strCusTableName = "")
        /// <summary>
        /// 取得一筆nTriffT資料;如果有多筆符合條件，則只回傳null
        /// </summary>
        /// <param name="strSqlWhere">查詢條件(不用加「where」關鍵字, 可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>
        public static object ReadOne(string strSqlWhere, ref CnTriff item, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            List<CnTriff> itemlist = new List<CnTriff>();
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

        #region 取得多筆CnTriff資料 ReadList
        /// <summary>
        /// 取得多筆 nTriffT資料 
        /// </summary>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns></returns>
        public static object ReadList(ref List<CnTriff> Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadListToObjs<CnTriff>(strSqlWhere, ref Items, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }

        #endregion

        #region 取得多筆 nTriffT資料 , 指定頁數和頁碼 ReadList
        /// <summary>
        /// 取得多筆 nTriffT資料 , 指定頁數和頁碼
        /// </summary>
        /// <param name="PageSize">一頁的筆數</param>
        /// <param name="PageIndex">第 n 頁</param>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>       
        /// <returns></returns>
        public static object ReadList(int PageSize, int PageIndex, ref List<CnTriff> Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadListToObjs<CnTriff>(PageSize, PageIndex, strSqlWhere, ref Items, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }
        #endregion

        #region Create
        /// <summary>
        /// 新增nTriffT 項目
        /// </summary> 
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns>0:成功 ; string:失敗</returns>
        public object Create(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.InsertByObj<CnTriff>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新 nTriffT 項目
        /// </summary>       
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param> 
        /// <returns>0:成功 ; string:失敗</returns>
        public object Update(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.UpdateObj<CnTriff>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region Delete

        #region 刪除項目nTriffT Delete()
        /// <summary>
        /// 刪除項目nTriffT
        /// </summary>  
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns></returns>   
        public object Delete(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CnTriff>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region 刪除項目nTriffT Delete(int iPKey)
        /// <summary>
        /// 刪除項目nTriffT , 指定某一筆主鍵刪除(單筆)
        /// </summary>
        /// <param name="iPKey">指定刪除某筆資料的Key值</param> 
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns></returns>
        public object Delete(int iPKey, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CnTriff>(iPKey, strCusTableName);
            return retObj;
        }
        #endregion

        #region 刪除項目nTriffT Delete(string strSqlWhere)
        /// <summary>
        /// 刪除項目nTriffT ,符合條件刪除(多筆)
        /// </summary>
        /// <param name="strSqlWhere">查詢條件(不用加「where」關鍵字)</param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>    
        /// <returns></returns>
        public object Delete(string strSqlWhere, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CnTriff>(strSqlWhere, strCusTableName);
            return retObj;
        }
        #endregion

        #endregion

        #endregion
    }
    #endregion =================
}
