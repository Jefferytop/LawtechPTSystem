using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using H3Operator.DBHelper;
using H3Operator.DBModels;


namespace LawtechPTSystem.DAL
{
    #region View ViewModel_PatentEventList Script
    [ViewTableMapping(@"select * from V_PatentEventList")]
    public class ViewModel_PatentEventList
    {
        #region Public Property

        private string m_PatentNo;
        [TableColumnSetting("PatentNo", DbType = SqlDataType.NVarChar)]
        public string PatentNo
        {
            get
            {
                return m_PatentNo;
            }
            set
            {
                m_PatentNo = value;
            }
        }

        private string m_ApplicantNames;
        [TableColumnSetting("ApplicantNames", DbType = SqlDataType.NVarChar)]
        public string ApplicantNames
        {
            get
            {
                return m_ApplicantNames;
            }
            set
            {
                m_ApplicantNames = value;
            }
        }

        private string m_ApplicantKeys;
        [TableColumnSetting("ApplicantKeys", DbType = SqlDataType.NVarChar)]
        public string ApplicantKeys
        {
            get
            {
                return m_ApplicantKeys;
            }
            set
            {
                m_ApplicantKeys = value;
            }
        }

        private string m_Title;
        [TableColumnSetting("Title", DbType = SqlDataType.NVarChar)]
        public string Title
        {
            get
            {
                return m_Title;
            }
            set
            {
                m_Title = value;
            }
        }

        private int m_Nature;
        [TableColumnSetting("Nature", DbType = SqlDataType.Int)]
        public int Nature
        {
            get
            {
                return m_Nature;
            }
            set
            {
                m_Nature = value;
            }
        }

        private int m_PatComitEventID;
        [TableColumnSetting("PatComitEventID", DbType = SqlDataType.Int)]
        public int PatComitEventID
        {
            get
            {
                return m_PatComitEventID;
            }
            set
            {
                m_PatComitEventID = value;
            }
        }

        private DateTime m_CreateDate;
        [TableColumnSetting("CreateDate", DbType = SqlDataType.DateTime)]
        public DateTime CreateDate
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

        private DateTime m_OccurDate;
        [TableColumnSetting("OccurDate", DbType = SqlDataType.DateTime)]
        public DateTime OccurDate
        {
            get
            {
                return m_OccurDate;
            }
            set
            {
                m_OccurDate = value;
            }
        }

        private string m_EventContent;
        [TableColumnSetting("EventContent", DbType = SqlDataType.NVarChar)]
        public string EventContent
        {
            get
            {
                return m_EventContent;
            }
            set
            {
                m_EventContent = value;
            }
        }

        private string m_Result;
        [TableColumnSetting("Result", DbType = SqlDataType.NVarChar)]
        public string Result
        {
            get
            {
                return m_Result;
            }
            set
            {
                m_Result = value;
            }
        }

        private int m_WorkerKey;
        [TableColumnSetting("WorkerKey", DbType = SqlDataType.Int)]
        public int WorkerKey
        {
            get
            {
                return m_WorkerKey;
            }
            set
            {
                m_WorkerKey = value;
            }
        }

        private DateTime m_OfficerDate;
        [TableColumnSetting("OfficerDate", DbType = SqlDataType.DateTime)]
        public DateTime OfficerDate
        {
            get
            {
                return m_OfficerDate;
            }
            set
            {
                m_OfficerDate = value;
            }
        }

        private DateTime m_DueDate;
        [TableColumnSetting("DueDate", DbType = SqlDataType.DateTime)]
        public DateTime DueDate
        {
            get
            {
                return m_DueDate;
            }
            set
            {
                m_DueDate = value;
            }
        }

        private DateTime m_OfficeDueDate;
        [TableColumnSetting("OfficeDueDate", DbType = SqlDataType.DateTime)]
        public DateTime OfficeDueDate
        {
            get
            {
                return m_OfficeDueDate;
            }
            set
            {
                m_OfficeDueDate = value;
            }
        }

        private DateTime m_StartDate;
        [TableColumnSetting("StartDate", DbType = SqlDataType.DateTime)]
        public DateTime StartDate
        {
            get
            {
                return m_StartDate;
            }
            set
            {
                m_StartDate = value;
            }
        }

        private DateTime m_ComitDate;
        [TableColumnSetting("ComitDate", DbType = SqlDataType.DateTime)]
        public DateTime ComitDate
        {
            get
            {
                return m_ComitDate;
            }
            set
            {
                m_ComitDate = value;
            }
        }

        private DateTime m_FinishDate;
        [TableColumnSetting("FinishDate", DbType = SqlDataType.DateTime)]
        public DateTime FinishDate
        {
            get
            {
                return m_FinishDate;
            }
            set
            {
                m_FinishDate = value;
            }
        }

        private string m_Remark;
        [TableColumnSetting("Remark", DbType = SqlDataType.NVarChar)]
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

        private string m_EmployeeName;
        [TableColumnSetting("EmployeeName", DbType = SqlDataType.NVarChar)]
        public string EmployeeName
        {
            get
            {
                return m_EmployeeName;
            }
            set
            {
                m_EmployeeName = value;
            }
        }

        private string m_AttorneyFirm;
        [TableColumnSetting("AttorneyFirm", DbType = SqlDataType.NVarChar)]
        public string AttorneyFirm
        {
            get
            {
                return m_AttorneyFirm;
            }
            set
            {
                m_AttorneyFirm = value;
            }
        }

        private string m_Kind;
        [TableColumnSetting("Kind", DbType = SqlDataType.NVarChar)]
        public string Kind
        {
            get
            {
                return m_Kind;
            }
            set
            {
                m_Kind = value;
            }
        }

        private string m_StatusExplain;
        [TableColumnSetting("StatusExplain", DbType = SqlDataType.NVarChar)]
        public string StatusExplain
        {
            get
            {
                return m_StatusExplain;
            }
            set
            {
                m_StatusExplain = value;
            }
        }

        private string m_FeatureName;
        [TableColumnSetting("FeatureName", DbType = SqlDataType.NVarChar)]
        public string FeatureName
        {
            get
            {
                return m_FeatureName;
            }
            set
            {
                m_FeatureName = value;
            }
        }

        private string m_Status;
        [TableColumnSetting("Status", DbType = SqlDataType.NVarChar)]
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

        private string m_Liaisoner;
        [TableColumnSetting("Liaisoner", DbType = SqlDataType.NVarChar)]
        public string Liaisoner
        {
            get
            {
                return m_Liaisoner;
            }
            set
            {
                m_Liaisoner = value;
            }
        }

        private int m_PatentID;
        [TableColumnSetting("PatentID", DbType = SqlDataType.Int)]
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

        #endregion

        #region 取得多筆ViewModel_PatentEventList資料 ReadList
        /// <summary>
        /// 取得多筆ViewModel_PatentEventList資料 ReadList
        /// 只要指定的Sql欄位有對應至類別屬性，則自動繫結       
        /// </summary>
        /// <param name="Items"></param>
        /// <param name="strSqlScript">完整的Sql Script語法</param>
        /// <param name="MySqlParameterList"></param>
        /// <param name="IsStoredProcedure">是否為StoredProcedure ,true:是 ; false:否(預設值) </param>
        /// <returns></returns>
        public static object ReadViewTableList(ref List<ViewModel_PatentEventList> Items, string strSqlScript = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false)
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadViewDBListToObjs<ViewModel_PatentEventList>(strSqlScript, ref Items, sqlParameterList: MySqlParameterList, isStoredProcedure: IsStoredProcedure);

            return retObj;
        }

        /// <summary>
        /// 取得多筆ViewModel_PatentEventList資料 ReadList
        /// 只要指定的Sql欄位有對應至類別屬性，則自動繫結        
        /// </summary>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字)</param>  
        /// <param name="Items"></param>       
        /// <param name="MySqlParameterList"></param>
        /// <param name="IsStoredProcedure">是否為StoredProcedure ,true:是 ; false:否(預設值)</param>
        /// <returns></returns>
        public static object ReadViewTableList(string strSqlWhere, ref List<ViewModel_PatentEventList> Items, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false)
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadViewDBListToObjs<ViewModel_PatentEventList>(ref Items, strSqlWhere, sqlParameterList: MySqlParameterList, isStoredProcedure: IsStoredProcedure);

            return retObj;
        }

        /// <summary>
        /// 取得多筆ViewModel_PatentEventList資料 ReadList
        /// 只要指定的Sql欄位有對應至類別屬性，則自動繫結        
        /// </summary>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字)</param>  
        /// <param name="strOrderBy">排序的欄位</param> 
        /// <param name="Items"></param>     
        /// <param name="myPageSize">一頁的筆數,預設一頁 10 筆</param>  
        /// <param name="myPageIndex">第 n 頁,預設第一頁</param>  
        /// <param name="MySqlParameterList"></param>
        /// <param name="IsStoredProcedure">是否為StoredProcedure ,true:是 ; false:否(預設值)</param>
        /// <returns></returns>
        public static object ReadViewTableList(string strSqlWhere, string strOrderBy, ref List<ViewModel_PatentEventList> Items, int myPageSize = 10, int myPageIndex = 1, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false, bool WithDelete = false)
        {
            ORMFactory orm = new ORMFactory();

            StringBuilder sb = new StringBuilder();

            string strSqlQuerySchema = ((ViewTableMappingAttribute)Attribute.GetCustomAttribute(typeof(ViewModel_PatentEventList), typeof(ViewTableMappingAttribute))).SqlQuerySchema.Replace("#Top", "Top(ViewModel_PatentEventList*{1})").Replace("#RankNumber", " ROW_Number() OVER (order by {2} ) AS RankNumber, ");

            strSqlQuerySchema = string.Format(strSqlQuerySchema.Replace("SELECT", "select ROW_Number() OVER (order by ViewModel_PatentEventList ) AS RankNumber, "), strOrderBy);

            sb.Append(string.Format(strSqlQuerySchema, myPageSize, myPageIndex, strOrderBy));

            if (strSqlWhere != null && strSqlWhere != "")
            {
                sb.Append(" Where " + strSqlWhere);
            }

            string myRange = "";
            //搜尋範圍(預設為第1頁)            
            if (myPageIndex == 1 || myPageIndex <= 0)
            {
                myRange = string.Format("{0}*({1}-1) and {0}*{1}", myPageSize, myPageIndex);
            }
            else
            {

                myRange = string.Format("{0}*({1}-1)+1 and {0}*{1}", myPageSize, myPageIndex);
            }

            string strSQL = string.Format("Select Top {2} * from({0} ) as QueryT where RankNumber between {1}", sb.ToString(), myRange, myPageSize);

            object retObj = null;
            try
            {
                retObj = orm.ReadViewDBListToObjs<ViewModel_PatentEventList>(strSQL, ref Items, sqlParameterList: MySqlParameterList, isStoredProcedure: IsStoredProcedure);
            }
            catch (InvalidCastException ex)
            {
                retObj = ex.Message;
            }

            return retObj;
        }

        #endregion

    }
    #endregion   
}
