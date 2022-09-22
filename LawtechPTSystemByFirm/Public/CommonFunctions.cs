using System;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.Public
{
    /// <summary>
    /// 控制SplitContainer.Panel2的開合狀態、控制SplitContainer 為水平或垂直、取得SQL查詢條件、查詢該資料是否有人正在使用中、MaskedTextBox控制項連按兩下取得目前日期、判斷User TextBox是否有空值
    /// </summary>
    class CommonFunctions
    {
        #region 控制SplitContainer.Panel2的開合狀態
        /// <summary>
        /// 控制SplitContainer.Panel2的開合狀態
        /// </summary>
        /// <param name="container"></param>
        public static string splitContainerCollapsed(SplitContainer container)
        {
            string result = "";

            if (!container.Panel2Collapsed)
            {
                result = "Close";

                container.Panel2Collapsed = true;
            }
            else
            {
                result = "Open";

                container.Panel2Collapsed = false;
            }

            return result;
        }
        #endregion

        #region splitContainerOrientation 控制SplitContainer 為水平或垂直
        /// <summary>
        /// 控制SplitContainer 為水平或垂直
        /// </summary>
        /// <param name="container"></param>
        /// <returns></returns>
        public static string splitContainerOrientation(SplitContainer container)
        {
            string result = "";

            if (container.Orientation == Orientation.Horizontal)
            {
                result = "Vertical";

                container.Orientation = Orientation.Vertical;
            }
            else
            {
                result = "Horizontal";

                container.Orientation = Orientation.Horizontal;
            }

            return result;
        }
        #endregion

        #region GetSQLScript 取得SQL查詢條件
        /// <summary>
        /// 取得SQL查詢條件
        /// </summary>
        /// <returns></returns>
        public static string GetSQLScript(US.ComboSearchColumnBox comb1,US.ComboSearchColumnBox combo2,string strAnd_Or,US.UserControlFilterDate FilterDate=null ,string StrSqlwhere="",string strOrderBy="")
        {
            string FullFilter = "", filter1 = "", filter2="",strfilterDate="";

            //查詢日期條件
            if (FilterDate != null)
            {
               strfilterDate= FilterDate.getQueryDate();
            }

            if (comb1.ComboBoxSelectedValue.Text != "")
            {
                filter1 = comb1.SQLSelectedValueColumn;
            }

            if (combo2.ComboBoxSelectedValue.Text != "")
            {
                filter2 = combo2.SQLSelectedValueColumn;
            }

            if (filter1 != "" && filter2 != "")
            {
                if (strAnd_Or.ToLower().Contains("and"))
                {
                    FullFilter = string.Format("{0} {1} {2}", filter1, strAnd_Or, filter2);
                }
                else
                {
                    FullFilter = string.Format("({0} {1} {2})", filter1, strAnd_Or, filter2);
                }

            }
            else if (filter1 == string.Empty && filter2 == string.Empty)
            {
                FullFilter = string.Empty;
            }
            else
            {
                if (filter1 != "")
                {
                    FullFilter = filter1;
                }
                else
                {
                    FullFilter = filter2;
                }
            }


            if (StrSqlwhere != "" || strfilterDate!="")
            {
                string ReString = "";

                string[] st = { FullFilter, strfilterDate, StrSqlwhere };

                ReString = GetComboString(st);

                return ReString + " " + strOrderBy;
            }
            else
            {
                if (!string.IsNullOrEmpty(FullFilter) && !string.IsNullOrEmpty(strOrderBy))
                {
                    return FullFilter + " " + strOrderBy;
                }
                else if (string.IsNullOrEmpty(FullFilter) && !string.IsNullOrEmpty(strOrderBy))
                {
                    return " " + strOrderBy;
                }
                else if (!string.IsNullOrEmpty(FullFilter) && string.IsNullOrEmpty(strOrderBy))
                {
                    return FullFilter;
                }
                else
                {
                    return "";
                }
            }
           
        }
        #endregion

        #region GetComboString 組合字串陣列
        /// <summary>
        /// 組合字串陣列
        /// </summary>
        /// <param name="sWhere">字串陣列</param>
        /// <returns></returns>
        public static string GetComboString(string[] sWhere)
        {
            StringBuilder FullWhere = new StringBuilder();

            for (int iArray = 0; iArray < sWhere.Length; iArray++)
            {
                if (sWhere[iArray] != "")
                {
                    if (FullWhere.Length > 0)
                    {
                        FullWhere.Append(" and ");
                    }
                    FullWhere.Append(sWhere[iArray]);
                }
            }

            return FullWhere.ToString();
        }
        #endregion

        #region CheckMeunItemVisible 檢查功能表狀態，隱藏無權限的功能選單
        /// <summary>
        /// 檢查功能表狀態，隱藏無權限的功能選單
        /// </summary>
        /// <param name="ContextMenu"></param>
        /// <param name="yourPermission"></param>
        public static void CheckMeunItemVisible(System.Windows.Forms.ContextMenuStrip contextMenu, PermissionTypes yourPermission)
        {
            foreach (object obj in contextMenu.Items)
            {
                ToolStripMenuItem toolbtn = obj as ToolStripMenuItem;

                if (toolbtn != null && toolbtn.Tag != null && string.IsNullOrEmpty(toolbtn.Tag.ToString()))
                {
                    if (yourPermission.HasFlag((PermissionTypes)Enum.Parse(typeof(PermissionTypes), toolbtn.Tag.ToString())))
                    {
                        toolbtn.Visible = true;
                    }
                    else
                    {
                        toolbtn.Visible = false;
                    }
                }

            }
        }

        /// <summary>
        /// 檢查功能表狀態，隱藏無權限的功能選單
        /// </summary>
        /// <param name="contextMenuList"></param>
        /// <param name="yourPermission"></param>
        public static void CheckMeunItemVisible(System.Windows.Forms.ContextMenuStrip[] contextMenuList, PermissionTypes yourPermission)
        {
            foreach (System.Windows.Forms.ContextMenuStrip contextMenu in contextMenuList)
            {
                foreach (object obj in contextMenu.Items)
                {
                    ToolStripMenuItem toolbtn = obj as ToolStripMenuItem;

                    if (toolbtn != null && toolbtn.Tag != null && !string.IsNullOrEmpty(toolbtn.Tag.ToString()))
                    {
                        if (yourPermission.HasFlag((PermissionTypes)Enum.Parse(typeof(PermissionTypes), toolbtn.Tag.ToString())))
                        {
                            toolbtn.Visible = true;
                        }
                        else
                        {
                            toolbtn.Visible = false;
                        }
                    }

                }
            }
        }

        /// <summary>
        /// 檢查功能表狀態，隱藏無權限的功能選單
        /// </summary>
        /// <param name="toolCollection"></param>
        /// <param name="yourPermission"></param>
        public static void CheckMeunItemVisible(System.Windows.Forms.BindingNavigator Navigator, PermissionTypes yourPermission)
        {
            foreach (object obj in Navigator.Items)
            {
                ToolStripButton toolbtn = obj as ToolStripButton;

                if (toolbtn != null && toolbtn.Tag != null && !string.IsNullOrEmpty(toolbtn.Tag.ToString()))
                {
                    if (yourPermission.HasFlag((PermissionTypes)Enum.Parse(typeof(PermissionTypes), toolbtn.Tag.ToString())))
                    {
                        toolbtn.Visible = true;
                    }
                    else
                    {
                        toolbtn.Visible = false;
                    }
                }

            }
        }

        /// <summary>
        /// 檢查功能表狀態，隱藏無權限的功能選單
        /// </summary>
        /// <param name="NavigatorList">BindingNavigator陣列</param>
        /// <param name="yourPermission"></param>
        public static void CheckMeunItemVisible(System.Windows.Forms.BindingNavigator[] NavigatorList, PermissionTypes yourPermission)
        {
            foreach (System.Windows.Forms.BindingNavigator Navigator in NavigatorList)
            {
                foreach (object obj in Navigator.Items)
                {
                    ToolStripButton toolbtn = obj as ToolStripButton;

                    if (toolbtn != null && toolbtn.Tag != null && !string.IsNullOrEmpty(toolbtn.Tag.ToString()) )
                    {
                        if (yourPermission.HasFlag((PermissionTypes)Enum.Parse(typeof(PermissionTypes), toolbtn.Tag.ToString())))
                        {
                            toolbtn.Visible = true;
                        }
                        else
                        {
                            toolbtn.Visible = false;
                        }
                    }

                }
            }
        }

        #endregion

        #region GetRecordAuth 查詢該資料是否有人正在使用中
        /// <summary>
        /// 查詢該資料是否有人正在使用中, 回傳-1表示無人使用中，反之，回傳目前使用者的id
        /// </summary>
        /// <param name="TableName">資料表名稱</param>
        /// <param name="QueryWhere">查詢條件(「Key值欄位」=「該筆資料的key值」)</param>
        /// <returns>-1:無人使用 </returns>
        public static int GetRecordAuth(string TableName, string QueryWhere)
        {
            string strSQL = string.Format("select LockedWorker from {0} where {1}", TableName, QueryWhere);

            Public.DLL helper = new Public.DLL();

            object obj = helper.SQLexecuteScalar(strSQL);
            if (obj != null && obj != DBNull.Value && Properties.Settings.Default.WorkerKEY != (int)obj)
            {
                return (int)obj;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 鎖定該筆資料
        /// </summary>
        /// <param name="TableName">資料表名稱</param>
        /// <param name="iManagerKey">系統登入者</param>
        /// <param name="sWhere">查詢條件</param>
        /// <returns></returns>
        public static void LockRecordAuth(string TableName, int iManagerKey, string sWhere)
        {
            string sSQL = string.Format("UPDATE {0} SET LockedWorker=null  where LockedWorker={1} ; UPDATE {0} set LockedWorker={1}  where {2}", TableName, iManagerKey, sWhere);

            Public.DLL helper = new Public.DLL();

            helper.SQLexecuteNonQuery(sSQL);
        }

        /// <summary>
        /// 解除鎖定資料
        /// </summary>
        /// <param name="TableName">資料表名稱</param>       
        /// <param name="sWhere">查詢條件</param>
        /// <returns></returns>
        public static void NuLockRecordAuth(string TableName, string sWhere)
        {
            string sSQL = string.Format("UPDATE {0} SET LockedWorker=null  where {1}", TableName, sWhere);

            Public.DLL helper = new Public.DLL();
            helper.SQLexecuteNonQuery(sSQL);
        }

        /// <summary>
        /// 解除鎖定資料
        /// </summary>
        /// <param name="TableName">資料表名稱</param>
        /// <param name="iManagerKey">系統登入者</param>
        public static void NuLockRecordAuth(string TableName, int iManagerKey)
        {
            string sSQL = string.Format("UPDATE {0} SET LockedWorker=null  where LockedWorker={1} ", TableName, iManagerKey.ToString());

            Public.DLL helper = new Public.DLL();
            helper.SQLexecuteNonQuery(sSQL);
        }

        #endregion

        #region MaskedTextBoxDoubleClick MaskedTextBox控制項連按兩下取得目前日期
        /// <summary>
        /// MaskedTextBox控制項連按兩下取得目前日期
        /// </summary>
        /// <param name="mtb"> MaskedTextBox控制項</param>
        /// <param name="formatDate">日期格式</param>        
        public static void MaskedTextBoxDoubleClick(MaskedTextBox mtb, string formatDate = "yyyy/MM/dd")
        {           
            DateTime dt;
            bool IsSuccess = DateTime.TryParse(mtb.Text, out dt);

            if (!IsSuccess)
            {
                mtb.Text= DateTime.Now.ToString(formatDate);
            }
            
        }
        #endregion

        #region 判斷User TextBox是否有空值，有空值:True ; 反之 False ;有空值就跳出迴圈
        /// <summary>
        /// 判斷TextBox是否有空值，有空值:True ; 反之 False ;
        /// 有空值就跳出迴圈
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool RequiredFieldsTextBoxIsEmpty(TextBox[] listTxt)
        {
            bool isEmpty = false;
            foreach (TextBox txt in listTxt)
            {
                if (txt.Text.Trim() == "")
                {
                    MessageBox.Show("【" + txt.Tag.ToString() + "】是必填欄位不得為空，請重新再確認", "提示訊息");
                    txt.Focus();
                    isEmpty = true;
                    break;
                }
            }
            return isEmpty;
        }
        #endregion
       
        #region 取得排序最大值, 回傳 Max+1，null時就回傳 1
        /// <summary>
        /// 取得排序最大值, 回傳 Max+1，null時就回傳 1
        /// </summary>
        /// <param name="TableName">資料表名稱</param>
        /// <param name="ColumnName">欄位名稱，預設為Sort</param>
        /// <param name="sqlQuery">SQL的查詢條件</param>
        /// <returns></returns>
        public static int GetMaxSort(string TableName, string ColumnName = "Sort", string sqlQuery = "")
        {
            DLL db = new DLL();
            string strSQL = string.Format("Select max({0})+1 from {1} {2}", ColumnName, TableName, sqlQuery != "" ? "where " + sqlQuery : "");
            object obj = db.SQLexecuteScalar(strSQL);

            if (obj != null && obj.ToString() != "")
            {
                return (int)obj;
            }
            else
            {
                return 1;
            }
        }


        #endregion

        #region  將 DataGridView匯出成 Excel
        /// <summary>
        /// 將 DataGridView匯出成 Excel
        /// </summary>
        /// <param name="gv"></param>
        /// <param name="isShowExcle">是否顯示Excel界面</param>
        //public static void GridViewTrasferExcel(DataGridView gv, bool isShowExcle = true)
        //{
        //    Microsoft.Office.Interop.Excel.Application excelLib = new Microsoft.Office.Interop.Excel.Application();//引用Excel
        //    try
        //    {
        //        excelLib.Application.Workbooks.Add(true);
        //        excelLib.Visible = isShowExcle;
        //        int Column = 1;
        //        for (int i = 0; i < gv.ColumnCount; i++) //匯出欄位名稱
        //        {
        //            if (gv.Columns[i].Visible != false)
        //            {
        //                excelLib.Cells[1, Column] = gv.Columns[i].HeaderText;
        //                Column++;
        //            }
        //        }


        //        for (int rowC = 0; rowC < gv.Rows.Count; rowC++)  //匯出值
        //        {
        //            int n = 1;
        //            for (int columnR = 0; columnR < gv.ColumnCount; columnR++)
        //            {
        //                if (gv.Columns[columnR].Visible != false)
        //                {
        //                    switch (gv.Columns[columnR].CellType.ToString())
        //                    {
        //                        case "System.Windows.Forms.DataGridViewComboBoxCell":
        //                            excelLib.Cells[rowC + 2, n] = gv.Rows[rowC].Cells[columnR].FormattedValue.ToString();
        //                            break;

        //                        case "System.Windows.Forms.DataGridViewTextBoxCell":
        //                            if (gv.Rows[rowC].Cells[columnR].Value != null && gv.Rows[rowC].Cells[columnR].Value.GetType().ToString() == "System.DateTime")
        //                            {
        //                                excelLib.Cells[rowC + 2, n] = gv.Rows[rowC].Cells[columnR].Value.ToString() != "" ? ((DateTime)gv.Rows[rowC].Cells[columnR].Value).ToShortDateString() : "";
        //                            }
        //                            else if (gv.Rows[rowC].Cells[columnR].Value != null && gv.Rows[rowC].Cells[columnR].Value.GetType().ToString() == "System.String")
        //                            {
        //                                excelLib.Cells[rowC + 2, n] = gv.Rows[rowC].Cells[columnR].Value != null ? "'" + gv.Rows[rowC].Cells[columnR].Value.ToString() : "";
        //                            }
        //                            else
        //                            {
        //                                excelLib.Cells[rowC + 2, n] = gv.Rows[rowC].Cells[columnR].Value != null ? gv.Rows[rowC].Cells[columnR].Value.ToString() : "";
        //                            }
        //                            break;
        //                        default:
        //                            excelLib.Cells[rowC + 2, n] = gv.Rows[rowC].Cells[columnR].Value != null ? gv.Rows[rowC].Cells[columnR].Value.ToString() : "";
        //                            break;
        //                    }


        //                    n++;
        //                }
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        excelLib.Quit();
        //        MessageBox.Show("匯出Excel失敗",  "錯誤訊息");
        //    }
        //    finally
        //    {
        //        excelLib.Application.Workbooks.Close();
        //    }

        //}
        #endregion

    }
}
