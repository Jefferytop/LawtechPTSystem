using H3Operator.DBHelper;
using H3Operator.DBModels;
using System.Collections.Generic;

namespace LawtechPTSystem.Public
{
    #region CGridColumn=================
    /// <summary>
    /// DataGrid設定表
    /// </summary>
    [TableMapping("GridColumnT")]
    public class CGridColumn : SysBaseModel
    {
        #region Public property

        private int m_GridColumnKey;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("GridColumnKey", DbType = SqlDataType.Int, IsPrimary = true, IsCumulative = true, IsCanNull = false, DataLength = 4)]
        public int GridColumnKey
        {
            get
            {
                return m_GridColumnKey;
            }
            set
            {
                m_GridColumnKey = value;
            }
        }

        private string m_GridSymboID;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("GridSymboID", DbType = SqlDataType.VarChar, IsCanNull = false, DataLength = 50)]
        public string GridSymboID
        {
            get
            {
                return m_GridSymboID;
            }
            set
            {
                m_GridSymboID = value;
            }
        }

        private short? m_GridColumnType;
        /// <summary>
        /// 1.Textbox ; 2.link ; 3.Image ; 4.Combobox ; 5.CheckBox ; 6.Button (預設為 1)
        /// </summary>
        [TableColumnSetting("GridColumnType", DbType = SqlDataType.SmallInt, DataLength = 2)]
        public short? GridColumnType
        {
            get
            {
                return m_GridColumnType;
            }
            set
            {
                m_GridColumnType = value;
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

        private string m_GridColumnName;
        /// <summary>
        /// 欄位的名稱
        /// </summary>
        [TableColumnSetting("GridColumnName", IsCanNull = false, DataLength = 200)]
        public string GridColumnName
        {
            get
            {
                return m_GridColumnName;
            }
            set
            {
                m_GridColumnName = value;
            }
        }

        private string m_DataPropertyName;
        /// <summary>
        /// 繫結資料來源屬性
        /// </summary>
        [TableColumnSetting("DataPropertyName", DataLength = 100)]
        public string DataPropertyName
        {
            get
            {
                return m_DataPropertyName;
            }
            set
            {
                m_DataPropertyName = value;
            }
        }

        private string m_HeaderText;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("HeaderText", DataLength = 100)]
        public string HeaderText
        {
            get
            {
                return m_HeaderText;
            }
            set
            {
                m_HeaderText = value;
            }
        }

        private string m_ToolTipText;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("ToolTipText", DataLength = 200)]
        public string ToolTipText
        {
            get
            {
                return m_ToolTipText;
            }
            set
            {
                m_ToolTipText = value;
            }
        }

        private string m_LinkText;
        /// <summary>
        /// DataGridViewLinkColumn使用的連結文字
        /// </summary>
        [TableColumnSetting("LinkText", DataLength = 100)]
        public string LinkText
        {
            get
            {
                return m_LinkText;
            }
            set
            {
                m_LinkText = value;
            }
        }

        private string m_DataSource;
        /// <summary>
        /// 4.Combobox 的資料來源
        /// </summary>
        [TableColumnSetting("DataSource", DataLength = 200)]
        public string DataSource
        {
            get
            {
                return m_DataSource;
            }
            set
            {
                m_DataSource = value;
            }
        }

        private string m_DisplayMember;
        /// <summary>
        /// 下拉顯示的字串
        /// </summary>
        [TableColumnSetting("DisplayMember", DataLength = 100)]
        public string DisplayMember
        {
            get
            {
                return m_DisplayMember;
            }
            set
            {
                m_DisplayMember = value;
            }
        }

        private string m_ValueMember;
        /// <summary>
        /// 下拉顯示的對應值
        /// </summary>
        [TableColumnSetting("ValueMember", DataLength = 100)]
        public string ValueMember
        {
            get
            {
                return m_ValueMember;
            }
            set
            {
                m_ValueMember = value;
            }
        }

        private bool? m_ReadOnly;
        /// <summary>
        /// 是否唯讀(true:唯讀)
        /// </summary>
        [TableColumnSetting("ReadOnly", DbType = SqlDataType.Bit, DataLength = 1)]
        public bool? ReadOnly
        {
            get
            {
                return m_ReadOnly;
            }
            set
            {
                m_ReadOnly = value;
            }
        }

        private short? m_Width;
        /// <summary>
        /// 寬度
        /// </summary>
        [TableColumnSetting("Width", DbType = SqlDataType.SmallInt, DataLength = 2)]
        public short? Width
        {
            get
            {
                return m_Width;
            }
            set
            {
                m_Width = value;
            }
        }

        private bool? m_Visible;
        /// <summary>
        /// 是否呈現(true:呈現 ; false: 隱藏)
        /// </summary>
        [TableColumnSetting("Visible", DbType = SqlDataType.Bit, DataLength = 1)]
        public bool? Visible
        {
            get
            {
                return m_Visible;
            }
            set
            {
                m_Visible = value;
            }
        }

        private string m_Alignment;
        /// <summary>
        /// 儲存格內容的位置
        /// </summary>
        [TableColumnSetting("Alignment", DataLength = 100)]
        public string Alignment
        {
            get
            {
                return m_Alignment;
            }
            set
            {
                m_Alignment = value;
            }
        }

        private string m_Format;
        /// <summary>
        /// 格式化
        /// </summary>
        [TableColumnSetting("Format", DataLength = 100)]
        public string Format
        {
            get
            {
                return m_Format;
            }
            set
            {
                m_Format = value;
            }
        }

        private string m_ForeColor;
        /// <summary>
        /// 字體的顏色
        /// </summary>
        [TableColumnSetting("ForeColor", DbType = SqlDataType.VarChar, DataLength = 50)]
        public string ForeColor
        {
            get
            {
                return m_ForeColor;
            }
            set
            {
                m_ForeColor = value;
            }
        }

        private string m_BackColor;
        /// <summary>
        /// Cell的背景顏色
        /// </summary>
        [TableColumnSetting("BackColor", DbType = SqlDataType.VarChar, DataLength = 50)]
        public string BackColor
        {
            get
            {
                return m_BackColor;
            }
            set
            {
                m_BackColor = value;
            }
        }

        private string m_Font;
        /// <summary>
        /// 字體(預設為微軟正黑體)
        /// </summary>
        [TableColumnSetting("Font", DataLength = 100)]
        public string Font
        {
            get
            {
                return m_Font;
            }
            set
            {
                m_Font = value;
            }
        }

        private string m_FontSize;
        /// <summary>
        /// 字體大小(預設為10)
        /// </summary>
        [TableColumnSetting("FontSize", DbType = SqlDataType.VarChar, DataLength = 50)]
        public string FontSize
        {
            get
            {
                return m_FontSize;
            }
            set
            {
                m_FontSize = value;
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
            List<CGridColumn> list = new List<CGridColumn>();
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
                retObj = orm.ReadListToObjs<CGridColumn>(ColumnName + "=@" + ColumnName, ref list, ParList);
            }
            else
            {
                retObj = orm.ReadListToObjs<CGridColumn>(ColumnName + "=@" + ColumnName + " and GridColumnKey<>" + this.GridColumnKey.ToString(), ref list, ParList);
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

        #region 取得一筆資料  ReadOne(ref CGridColumn Item, string strCusTableName = ")
        /// <summary>
        /// 取得一筆GridColumnT資料
        /// </summary>          
        /// <param name="item"></param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>       
        public static object ReadOne(ref CGridColumn Item, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadOneToObj(ref Item, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆資料 ReadOne(int iPKey, ref CGridColumn item, string strCusTableName = "")
        /// <summary>
        /// 取得一筆GridColumnT資料
        /// </summary>
        /// <param name="iPKey">指定某筆資料的Key值(不適合複合key)</param>     
        /// <param name="item"></param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>       
        public static object ReadOne(int iPKey, ref CGridColumn item, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadOneToObj(iPKey, ref item, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆GridColumnT資料 ReadOne(string strSqlWhere, System.Data.SqlClient.SqlParameter[] MySqlParameterList=null, string strCusTableName = "")
        /// <summary>
        /// 取得一筆GridColumnT資料;如果有多筆符合條件，則只回傳null
        /// </summary>
        /// <param name="strSqlWhere">查詢條件(不用加「where」關鍵字, 可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>
        public static object ReadOne(string strSqlWhere, ref CGridColumn item, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            List<CGridColumn> itemlist = new List<CGridColumn>();
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

        #region 取得多筆CGridColumn資料 ReadList
        /// <summary>
        /// 取得多筆 GridColumnT資料 
        /// </summary>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns></returns>
        public static object ReadList(ref List<CGridColumn> Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadListToObjs<CGridColumn>(strSqlWhere, ref Items, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }

        #endregion

        #region 取得多筆 GridColumnT資料 , 指定頁數和頁碼 ReadList
        /// <summary>
        /// 取得多筆 GridColumnT資料 , 指定頁數和頁碼
        /// </summary>
        /// <param name="PageSize">一頁的筆數</param>
        /// <param name="PageIndex">第 n 頁</param>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>       
        /// <returns></returns>
        public static object ReadList(int PageSize, int PageIndex, ref List<CGridColumn> Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadListToObjs<CGridColumn>(PageSize, PageIndex, strSqlWhere, ref Items, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }
        #endregion

        #region Create
        /// <summary>
        /// 新增GridColumnT 項目
        /// </summary> 
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns>0:成功 ; string:失敗</returns>
        public object Create(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.InsertByObj<CGridColumn>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新 GridColumnT 項目
        /// </summary>       
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param> 
        /// <returns>0:成功 ; string:失敗</returns>
        public object Update(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.UpdateObj<CGridColumn>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region Delete

        #region 刪除項目GridColumnT Delete()
        /// <summary>
        /// 刪除項目GridColumnT
        /// </summary>  
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns></returns>   
        public object Delete(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CGridColumn>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region 刪除項目GridColumnT Delete(int iPKey)
        /// <summary>
        /// 刪除項目GridColumnT , 指定某一筆主鍵刪除(單筆)
        /// </summary>
        /// <param name="iPKey">指定刪除某筆資料的Key值</param> 
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns></returns>
        public object Delete(int iPKey, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CGridColumn>(iPKey, strCusTableName);
            return retObj;
        }
        #endregion

        #region 刪除項目GridColumnT Delete(string strSqlWhere)
        /// <summary>
        /// 刪除項目GridColumnT ,符合條件刪除(多筆)
        /// </summary>
        /// <param name="strSqlWhere">查詢條件(不用加「where」關鍵字)</param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>    
        /// <returns></returns>
        public object Delete(string strSqlWhere, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CGridColumn>(strSqlWhere, strCusTableName);
            return retObj;
        }
        #endregion

        #endregion

        #endregion
    }
    #endregion =================
}
