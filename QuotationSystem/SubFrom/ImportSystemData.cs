using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Text;
using H3Operator.DBHelper;

namespace LawtechPTSystem.SubFrom
{
    public partial class ImportSystemData : Form
    {

        UserPermissionForm myPermission;
        private const string ProgramSymbol = "ImportSystemData";
        private const string SourceTableName = "ImportTypeT";

        #region ==========Property ==========

        private int iWorkerID = -1;
        /// <summary>
        /// 登入者ID
        /// </summary>
        public int WorkerID
        {
            get { return iWorkerID; }
            set { iWorkerID = value; }
        }

        private string strWorkerName = "";
        /// <summary>
        /// 登入者的名字
        /// </summary>
        public string Property_WorkerName
        {
            get { return strWorkerName; }
            set { strWorkerName = value; }
        }


        /// <summary>
        /// 登入者的權限身份 1.員工 2.專利主管 3.商標主管 0.admin
        /// </summary>
        public int OfficeRole
        {
            get { return Properties.Settings.Default.OfficeRole; }
        }

        #endregion

        #region =========資料集=========
        private DataTable dt_improtSystemData = new DataTable();
        /// <summary>
        /// 
        /// </summary>
        public System.Data.DataTable DT__ImprotSystemData
        {
            get
            {
                return dt_improtSystemData;
            }
        }

        private DataTable dt_CSVdata = new DataTable();
        /// <summary>
        /// 匯入資料表
        /// </summary>
        public System.Data.DataTable DT__CSVData
        {
            get
            {
                return dt_CSVdata;
            }
        }

        #endregion

        public ImportSystemData()
        {
            InitializeComponent();
        }

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region private void ImportSystemData_Load(object sender, EventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImportSystemData_Load(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.ImportSystemData = this;

            //取得登入者身份
            iWorkerID = Properties.Settings.Default.WorkerKEY;

            List<Public.CImportTypeT> import = new List<Public.CImportTypeT>();
            Public.CImportTypeT.ReadList(ref dt_improtSystemData, strSqlWhere: "", strOrderBy: "Sort ");

            comboBox_type.DataSource = dt_improtSystemData;
            comboBox_type.DisplayMember = "ImportTypeName";
            comboBox_type.ValueMember = "ImportTypeKey";
        }
        #endregion

        #region private void ImportSystemData_FormClosed(object sender, FormClosedEventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImportSystemData_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.ImportSystemData = null;
        }
        #endregion

        #region private void but_SelectFolder_Click(object sender, EventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_SelectFolder_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "*.csv|*.*";
                openFileDialog1.FileName = DateTime.Now.ToString("yyyyMMddHHmmss");

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    txt_FilePath.Text = openFileDialog1.FileName;

                    dt_CSVdata = OpenCSV(txt_FilePath.Text);

                    bindingSource1.DataSource = dt_CSVdata;

                    dataGridView1.DataSource = bindingSource1;

                    bindingNavigator1.BindingSource = bindingSource1;
                }
            }
            catch (System.Exception EX)
            {
                MessageBox.Show("匯入格式異常：請檢查CSV檔案" + EX.Message);

            }
        } 
        #endregion

        #region 從csv讀取資料返回table
        public DataTable OpenCSV(string filePath)//從csv讀取資料返回table
        {
            System.Text.Encoding encoding = GetType(filePath); //Encoding.ASCII;//
            DataTable dt = new DataTable();
            System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);

            System.IO.StreamReader sr = new System.IO.StreamReader(fs, encoding);

            //記錄每次讀取的一行記錄
            string strLine = "";
            //記錄每行記錄中的各欄位內容
            string[] aryLine = null;
            string[] tableHead = null;
            //標示列數
            int columnCount = 0;
            //標示是否是讀取的第一行
            bool IsFirst = true;
            //逐行讀取CSV中的資料
            while ((strLine = sr.ReadLine()) != null)
            {
                if (IsFirst == true)
                {
                    tableHead = strLine.Split(',');
                    IsFirst = false;
                    columnCount = tableHead.Length;
                    //建立列
                    for (int i = 0; i < columnCount; i++)
                    {
                        DataColumn dc = new DataColumn(tableHead[i].Replace("\"", "").Trim());
                        dt.Columns.Add(dc);
                    }
                }
                else
                {
                    aryLine =Public.PublicCommonFunction. CSVstrToArry (strLine);
                    DataRow dr = dt.NewRow();
                    for (int j = 0; j < columnCount; j++)
                    {
                        dr[j] = aryLine[j].Replace("\"", "");
                    }
                    dt.Rows.Add(dr);
                }
            }
            //if (aryLine != null && aryLine.Length > 0)
            //{
            //    dt.DefaultView.Sort = tableHead[0]. + " " + "asc";
            //}

            sr.Close();
            fs.Close();
            return dt;
        }

        /// 給定檔案的路徑，讀取檔案的二進位制資料，判斷檔案的編碼型別
        /// <param name="FILE_NAME">檔案路徑</param>
        /// <returns>檔案的編碼型別</returns>
        public static System.Text.Encoding GetType(string FILE_NAME)
        {
            System.IO.FileStream fs = new System.IO.FileStream(FILE_NAME, System.IO.FileMode.Open);
            try
            {
                System.Text.Encoding r = GetType(fs);
                fs.Close();
                return r;
            }
            catch
            {
                return System.Text.Encoding.UTF8;
            }
            finally
            {
                fs.Close();
            }

        }

        /// 通過給定的檔案流，判斷檔案的編碼型別
        /// <param name="fs">檔案流</param>
        /// <returns>檔案的編碼型別</returns>
        public static System.Text.Encoding GetType(System.IO.FileStream fs)
        {
            byte[] Unicode = new byte[] { 0xFF, 0xFE, 0x41 };
            byte[] UnicodeBIG = new byte[] { 0xFE, 0xFF, 0x00 };
            byte[] UTF8 = new byte[] { 0xEF, 0xBB, 0xBF }; //帶BOM
            System.Text.Encoding reVal = System.Text.Encoding.Default;

            System.IO.BinaryReader r = new System.IO.BinaryReader(fs, System.Text.Encoding.Default);
            int i;
            int.TryParse(fs.Length.ToString(), out i);
            byte[] ss = r.ReadBytes(i);
            if (IsUTF8Bytes(ss) || (ss[0] == 0xEF && ss[1] == 0xBB && ss[2] == 0xBF))
            {
                reVal = System.Text.Encoding.UTF8;
            }
            else if (ss[0] == 0xFE && ss[1] == 0xFF && ss[2] == 0x00)
            {
                reVal = System.Text.Encoding.BigEndianUnicode;
            }
            else if (ss[0] == 0xFF && ss[1] == 0xFE && ss[2] == 0x41)
            {
                reVal = System.Text.Encoding.Unicode;
            }
            r.Close();
            return reVal;
        }

        /// 判斷是否是不帶 BOM 的 UTF8 格式
        /// <param name="data"></param>
        /// <returns></returns>
        private static bool IsUTF8Bytes(byte[] data)
        {
            int charByteCounter = 1;  //計算當前正分析的字元應還有的位元組數
            byte curByte; //當前分析的位元組.
            for (int i = 0; i < data.Length; i++)
            {
                curByte = data[i];
                if (charByteCounter == 1)
                {
                    if (curByte >= 0x80)
                    {
                        //判斷當前
                        while (((curByte <<= 1) & 0x80) != 0)
                        {
                            charByteCounter++;
                        }
                        //標記位首位若為非0 則至少以2個1開始 如:110XXXXX...........1111110X　
                        if (charByteCounter == 1 || charByteCounter > 6)
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    //若是UTF-8 此時第一位必須為1
                    if ((curByte & 0xC0) != 0x80)
                    {
                        return false;
                    }
                    charByteCounter--;
                }
            }
            if (charByteCounter > 1)
            {
                throw new Exception("非預期的byte格式");
            }
            return true;
        }
        #endregion

        #region 確定匯入按鈕 private void but_OK_Click(object sender, EventArgs e)
        /// <summary>
        /// 確定匯入按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_OK_Click(object sender, EventArgs e)
        {
            but_OK.Enabled = false;
            if (MessageBox.Show("是否確定匯入 "+comboBox_type.Text+" ?","提示訊息",MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                return;
            }            

            if (dataGridView1.Rows.Count > 0)
            {
                DataRow drComboType = ((System.Data.DataRowView)comboBox_type.SelectedItem).Row;
                string tableName= drComboType["ImportTypeTableName"].ToString();
                string strInserScript= drComboType["InserScript"].ToString();
                string[] strArrayColumns = drComboType["ColumnName"].ToString().Split(',');
                StringBuilder sbSQL = new StringBuilder();
                if (radioButton2.Checked)
                {
                    sbSQL.Append(" delete  "+ tableName + ";\r\n");
                }

                StringBuilder sbValue = new StringBuilder();
                int iRows = 0;
                foreach (DataRow dr in dt_CSVdata.Rows)
                {
                    string sql = txt_InserScriptValue.Text;

                    for (int i = 0; i < strArrayColumns.Length; i++)
                    {
                        string strCname = strArrayColumns[i].Trim();//可匯入的欄位名稱

                        bool isOK = IsExistColumnName(strCname.Trim()); //檢查cvs檔是否有符合名稱

                        #region 檢查是否有符合可匯入欄位
                        if (isOK && dr[strCname.Trim()] != null) //檢查是否有符合可匯入欄位
                        {
                            string sValue = "'" + dr[strCname.Trim()].ToString().Replace("'", "") + "'";
                            if (sql.Contains("N[" + strCname.Trim() + "]"))
                            {
                                sql = sql.Replace("[" + strCname.Trim() + "]", sValue);
                            }
                            else
                            {
                                if (sValue == "''")
                                {
                                    sql = sql.Replace("[" + strCname.Trim() + "]", "null");
                                }
                                else
                                {
                                    sql = sql.Replace("[" + strCname.Trim() + "]", sValue);
                                }
                            }
                        }
                        else
                        {
                            if (sql.Contains("N[" + strCname.Trim() + "]"))
                            {
                                sql = sql.Replace("[" + strCname.Trim() + "]", "''");
                            }
                            else
                            {
                                sql = sql.Replace("[" + strCname.Trim() + "]", "null");
                            }
                        }
                        #endregion

                    }

                    if (sbValue.Length > 0)
                    {
                        if (iRows >= 1000)//Insert語句上限1000筆
                        {
                            sbValue.Append("  \r\n" + strInserScript);
                            iRows = 0;
                        }
                        else
                        {
                            sbValue.Append(",\r\n");
                        }
                    }
                    sbValue.Append(sql);
                    iRows++;

                }

                sbSQL.Append(txt_InserSricpt.Text);
                sbSQL.Append(sbValue.ToString());

                DBAccess dbhelp = new DBAccess();
                object obj = dbhelp.ExecuteNonQuery(sbSQL.ToString());

                if (obj.ToString() != "0")
                {
                    MessageBox.Show("匯入資料異常 : " + obj.ToString(), "提示訊息");
                }
                else
                {
                    dt_CSVdata.Rows.Clear();
                    MessageBox.Show("匯入資料成功，請至「"+comboBox_type.Text+"」查看結果", "提示訊息");
                }


            }
            
            but_OK.Enabled = true;
           

        }
        #endregion

        /// <summary>
        /// 檢查欄位是否存在
        /// </summary>
        /// <param name="strColumn"></param>
        /// <returns></returns>
        private bool IsExistColumnName(string strColumn)
        {
            bool Revalue = false;

            DataRow drComboType = ((System.Data.DataRowView)comboBox_type.SelectedItem).Row;
            string[] strArrayColumns = drComboType["ColumnName"].ToString().Split(',');

            for (int iC = 0; iC < dt_CSVdata.Columns.Count; iC++)
            {
                if (dt_CSVdata.Columns[iC].ColumnName == strColumn)
                {
                    Revalue = true;
                    break;
                }
            }
            return Revalue;
        }

        private void comboBox_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_type.SelectedValue != null)
            {
               DataRow dr= ((System.Data.DataRowView)comboBox_type.SelectedItem).Row;
                txt_Culnm.Text = dr["ColumnName"].ToString().Replace(",", "\r\n");
                txt_InserSricpt.Text = dr["InserScript"].ToString();
                txt_InserScriptValue.Text = dr["InserScriptValue"].ToString();
                txt_Remark.Text = dr["Remark"].ToString();
            }
        }
    }
}
