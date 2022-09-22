using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.US
{
    public partial class ImportCSV : Form
    {
        public ImportCSV()
        {
            InitializeComponent();
        }

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        #region 確定匯入按鈕  private void but_OK_Click(object sender, EventArgs e)
        /// <summary>
        /// 確定匯入按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_OK_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                Public.COfficialDocumentT od = new Public.COfficialDocumentT();
                int iAdd = 0;
                DataTable dt = dataGridView1.DataSource as DataTable;

                foreach (DataRow dr in dt.Rows)
                {

                    #region 依欄位名稱綁定     
                    for (int icol = 0; icol < dt.Columns.Count; icol++)
                    {
                        switch (dt.Columns[icol].ColumnName)
                        {
                            case "發文文號":
                                od.DocumentNumber = dr["發文文號"].ToString().Trim() ;
                                break;
                            case "發文字號":
                                od.TextNumber = dr["發文字號"].ToString();
                                break;
                            case "案號類別":
                                od.NumberType = dr["案號類別"].ToString();
                                break;
                            case "案號":
                                od.NumberID = dr["案號"].ToString();
                                break;
                            case "原申請案號":
                                od.ApplicationNo = dr["原申請案號"].ToString();
                                break;
                            case "送達時間":
                                od.DeliveryTime = TransferDate(dr["送達時間"].ToString());
                                break;
                            case "案由":
                                od.Summary = dr["案由"].ToString();
                                break;
                            case "處理期限":
                                DateTime? dtProcessingPeriod = TransferDate(dr["處理期限"].ToString());
                                od.ProcessingPeriod = dtProcessingPeriod.HasValue? dtProcessingPeriod.Value.ToString("yyyy-MM-dd"):"";
                                break;
                            case "處理期間":
                                od.DuringProcessing = dr["處理期間"].ToString();
                                break;
                            case "簽收時間":
                                od.SubmissionTime = TransferDate(dr["簽收時間"].ToString());
                                break;
                            case "簽收人":
                                od.Signer = dr["簽收人"].ToString();
                                break;
                            case "受送達人":
                                od.Recipient = dr["受送達人"].ToString();
                                break;
                            case "發文日期":
                                od.IssueDate = TransferDate(dr["發文日期"].ToString());
                                break;
                            case "檔案":
                                od.FileName = dr["檔案"].ToString();
                                break;
                            case "案件種類":
                                od.CaseType = dr["案件種類"].ToString().Trim();
                                break;
                            case "受文者序號":
                                od.RecipientNumber = dr["受文者序號"].ToString();
                                break;
                            case "承審委員":
                                od.Reviewer = dr["承審委員"].ToString();
                                break;
                            case "IPC分類":
                                od.IPCclassification = dr["IPC分類"].ToString();
                                break;
                            case "事務所案號":
                                od.FirmNumberID = dr["事務所案號"].ToString();
                                break;
                            case "正副本":
                                od.OriginalCopy = dr["正副本"].ToString();
                                break;
                            case "受文者":
                                od.CasePerson = dr["受文者"].ToString();
                                break;
                            case "檔案路徑":
                                od.FilePath = dr["檔案路徑"].ToString();
                                break;
                        }

                    }
                    #endregion

                    od.Creator = Properties.Settings.Default.WorkerName;
                    object obj = od.Create();
                    if (obj.ToString() == "0")
                    {
                        iAdd++;
                    }
                }

                MessageBox.Show(string.Format("完成匯入作業，共 {0} 筆", iAdd.ToString()));
                Public.PublicForm forms = new Public.PublicForm();
                if (forms.OfficialDocument != null)
                {
                    forms.OfficialDocument.ReLoad();
                }

                this.Close();
            }
            else
            {
                txt_FilePath.Focus();
                MessageBox.Show("請選擇要匯入的CSV檔!!");
            }
        } 
        #endregion

        private DateTime? TransferDate(string str) {
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }
            else
            {
                string[] array= str.Split('/');

                int yer;
                bool iB= int.TryParse(array[0],out yer);
                yer = 1911 + yer;

                 DateTime dtime;
                bool isdtime = DateTime.TryParse(str.Replace(array[0]+"/", yer.ToString()+"/"), out dtime);

                if (iB && isdtime)
                {
                    return dtime;
                }
                else {
                    return null;
                }
            }
        }

        private void but_SelectFolder_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "*.csv|*.*";
                openFileDialog1.FileName = DateTime.Now.ToString("yyyyMMddHHmmss");

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    txt_FilePath.Text = openFileDialog1.FileName;

                    DataTable dt = OpenCSV(txt_FilePath.Text);

                    dataGridView1.DataSource = dt;

                    int isCheck = 0;
                    for (int iCol = 0; iCol < dt.Columns.Count; iCol++)
                    {
                        switch (dt.Columns[iCol].ColumnName)
                        {
                            case "發文文號":                           
                            case "原申請案號":
                            case "案件種類":
                            case "案由":
                                isCheck++;
                                break;
                        }
                    }

                    if (isCheck < 4)
                    {
                        but_OK.Enabled = false;
                        MessageBox.Show("注意：\r\n「發文文號」、「原申請案號」、「案件種類」、「案由」為必要欄位, 請確認匯入的csv檔案是否正確 !!");
                    }
                    else if (isCheck == 4)
                    {
                        but_OK.Enabled = true;
                    }

                }
            }
            catch (System.Exception EX) {
                MessageBox.Show(EX.Message);

            }
        }

        public  DataTable OpenCSV(string filePath)//從csv讀取資料返回table
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
                        DataColumn dc = new DataColumn(tableHead[i].Replace("\"",""));
                        dt.Columns.Add(dc);
                    }
                }
                else
                {
                    aryLine = strLine.Split(',');
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
            finally {
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

      
    }
}
