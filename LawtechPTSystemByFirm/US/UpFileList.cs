using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace LawtechPTSystemByFirm.US
{
   
    public partial class UpFileList : Form
    {
        DataTable dt;

        private int uploadMode;
        /// <summary>
        /// (主)檔案上傳模式: 1.段落依據 2.相關檔案管理 3.專利案件相關檔案管理 4.商標案件相關檔案管理 5.商標異議案 6.單位財產 10.知識管理
        ///               20.EmailLog的附件  30.已刪除的附件
        ///               40.客戶附加檔案
        ///               50.事務所附加檔案
        /// </summary>
        /// <remarks>1.段落依據 2.相關檔案管理 3.專利案件相關檔案管理 4.商標案件相關檔案管理 5.商標異議案 6.單位財產 10.知識管理 20.EmailLog的附件  30.已刪除的附件  40.客戶附加檔案 50.事務所附加檔案</remarks>
        public int UploadMode
        {
            get { return uploadMode; }
            set { uploadMode = value; }
        }


        private int mFileType = -1;
        /// <summary>
        /// 子類型(專利 0.申請案 1.委辦  2.來函  3.請款費用 4.付款費用    
        /// 商標 5.代表圖  6.商標案件       7.來函           8.請款費用   9.付款費用  
        /// 10商標異議案  11.商標異議來函  12.商標異議請款  13.商標異議付款  99.全部)        
        /// </summary>
        public int MainFileType
        {
            get { return mFileType; }
            set { mFileType = value; }
        }

        private int mFileKey = -1;
        /// <summary>
        /// 主Key值(如:專利、商標)。
        /// </summary>
        public int MainFileKey
        {
            get { return mFileKey; }
            set { mFileKey = value; }
        }

        private int childKey = -1;
        /// <summary>
        /// 副key值
        /// </summary>
        public int ChildFileKey
        {
            get { return childKey; }
            set { childKey = value; }
        }

       

        public UpFileList()
        {
            InitializeComponent();
        }

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region ==========listView1==========
        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            string[] sFile = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            for (int iFile = 0; iFile < sFile.Length; iFile++)
            {
                if (sFile.Length > 0 && sFile[iFile].Length>3 && sFile[iFile].Substring(sFile[iFile].Length - 3).ToLower() != "exe")
                {
                    FileInfo file = new FileInfo(sFile[iFile]);
                    ListViewItem item = new ListViewItem(new string[4] { file.Name, (Convert.ToInt32(file.Length)/1024).ToString(), file.LastWriteTime.ToString(), file.FullName });
                    listView1.Items.Add(item);
                   
                }
            }
        }

        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
          
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                listView1.SelectedItems[0].Remove();
            }
        }
        #endregion

        #region UpFileList_Load
        private void UpFileList_Load(object sender, EventArgs e)
        {
            maskedTextBox_EndDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            maskedTextBox_Start.Text = DateTime.Now.AddDays(-7).ToString("yyyy/MM/dd");

            dataGridView_outlook.AutoGenerateColumns = false;

            dt = new DataTable();
            dt.Columns.Add("Selected", typeof(bool));
            dt.Columns.Add("Number", typeof(string));
            dt.Columns.Add("SenderName", typeof(string));
            dt.Columns.Add("Subject", typeof(string));
            dt.Columns.Add("ReceivedTime", typeof(DateTime));
            dt.Columns.Add("Status", typeof(string));

            InitListViewColumns();
        }
        #endregion

        #region InitListViewColumns
        public void InitListViewColumns()
        {
            listView1.Columns.Add("FileName","檔案名稱",150);
            listView1.Columns["FileName"].TextAlign = HorizontalAlignment.Left;

            listView1.Columns.Add("Size","大小(KB)",100);
            listView1.Columns["Size"].TextAlign = HorizontalAlignment.Right;

            listView1.Columns.Add("LastDate","修改日期", 120);
            listView1.Columns["LastDate"].TextAlign = HorizontalAlignment.Left;

            listView1.Columns.Add("FullFileName","完整路徑", 300);
            listView1.Columns["FullFileName"].TextAlign = HorizontalAlignment.Left;
            listView1.HideSelection = true;
        }
        #endregion

        #region but_OK_Click
        private void but_OK_Click(object sender, EventArgs e)
        {
            try
            {
                Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
                for (int iRow = 0; iRow < listView1.Items.Count; iRow++)
                {
                    ListViewItem item = listView1.Items[iRow];
                    string SourcePath = item.SubItems[3].Text;
                    FileInfo Upfile = new FileInfo(SourcePath);

                    string CopyTo = string.Format(@"{0}\{1}", MainFileKey, Upfile.Name);
                    string FullCopyTo = "";
                    if (UploadMode == 1)
                    {
                        FullCopyTo = string.Format("{0}\\{1}", dll.GeneralBasedOnFolderRoot, CopyTo);
                    }
                    else if (UploadMode == 2)
                    {
                        FullCopyTo = string.Format("{0}\\{1}", dll.GeneralFolderRoot, CopyTo);
                    }
                    else if (UploadMode == 3)
                    {
                        FullCopyTo = string.Format("{0}\\{1}", dll.PatentFolderRoot, CopyTo);
                    }
                    else if (UploadMode == 4)
                    {
                        FullCopyTo = string.Format("{0}\\{1}", dll.TrademarkFolderRoot, CopyTo);
                    }
                    else if (UploadMode == 5)
                    {
                        FullCopyTo = string.Format("{0}\\{1}", dll.TrademarkControversyFolderRoot, CopyTo);
                    }
                    else if (UploadMode == 6)
                    {
                        FullCopyTo = string.Format("{0}\\{1}", dll.OfficePropertyFolderRoot, CopyTo);
                    }
                    else if (UploadMode == 10)
                    {
                        FullCopyTo = string.Format("{0}\\{1}", dll.KMFolderRoot, CopyTo);
                    }
                    else if (UploadMode == 40)
                    {
                        FullCopyTo = string.Format("{0}\\{1}", dll.CustomerFolderRoot, CopyTo);
                    }
                    else if (UploadMode == 50)
                    {
                        FullCopyTo = string.Format("{0}\\{1}", dll.FirmFolderRoot, CopyTo);
                    }

                    dll.CreatFolder(UploadMode, MainFileKey.ToString());
                    //dll.CreatFolder(FullCopyTo);

                    File.Copy(SourcePath, FullCopyTo);

                    Public.CUpLoadFile uploadfile = new LawtechPTSystemByFirm.Public.CUpLoadFile();
                    uploadfile.FilePath = CopyTo;
                    uploadfile.MainParentID = MainFileKey;                    
                    uploadfile.Uploader = Properties.Settings.Default.WorkerName;
                    uploadfile.FileDoc = Upfile.Name;
                    uploadfile.FileType = MainFileType;
                    uploadfile.FileKind = UploadMode;
                    uploadfile.ChildID = ChildFileKey;

                    uploadfile.Create();

                }

                if (dataGridView_outlook.Rows.Count > 0)
                {
                    SaveMailItem();
                }

                MessageBox.Show("完成上傳檔案", "提示訊息");
                this.Close();
            }
            catch (System.Exception EX)
            {
                MessageBox.Show(string.Format("上傳檔案失敗：{0}",EX.Message), "提示訊息");
            }
        }
        #endregion

        #region SaveMailItem
        public void SaveMailItem()
        {
            Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
            string FullCopyTo = "";
            if (UploadMode == 1)
            {
                FullCopyTo = string.Format("{0}\\{1}", dll.GeneralBasedOnFolderRoot, MainFileKey);
            }
            else if (UploadMode == 2)
            {
                FullCopyTo = string.Format("{0}\\{1}", dll.GeneralFolderRoot, MainFileKey);
            }
            else if (UploadMode == 3)
            {
                FullCopyTo = string.Format("{0}\\{1}", dll.PatentFolderRoot, MainFileKey);
            }
            else if (UploadMode == 4)
            {
                FullCopyTo = string.Format("{0}\\{1}", dll.TrademarkFolderRoot, MainFileKey);
            }
            else if (UploadMode == 5)
            {
                FullCopyTo = string.Format("{0}\\{1}", dll.TrademarkControversyFolderRoot, MainFileKey);
            }
            else if (UploadMode == 6)
            {
                FullCopyTo = string.Format("{0}\\{1}", dll.OfficePropertyFolderRoot, MainFileKey);
            }
            else if (UploadMode == 40)
            {
                FullCopyTo = string.Format("{0}\\{1}", dll.CustomerFolderRoot, MainFileKey);
            }

            dll.CreatFolder(FullCopyTo);

            //try
            //{
            //    Outlook.ApplicationClass olApp;
            //    Outlook.NameSpace ns;
            //    try
            //    {
            //        olApp = new Outlook.ApplicationClass();
            //        ns = olApp.GetNamespace("MAPI");

            //        Outlook.MAPIFolder selectFolder = null;
            //        Outlook.MailItem mi = null;

            //        string sCriteria = string.Format("[ReceivedTime] >= '{0} 03:00 AM' and [ReceivedTime] <= '{1} 11:59 PM'", maskedTextBox_Start.Text, maskedTextBox_EndDate.Text);

            //        selectFolder = ns.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);
            //        Outlook.Items oItems = (Outlook.Items)selectFolder.Items.Restrict(sCriteria);
            //        oItems.Sort("[ReceivedTime]", true);

            //        for (int iRow = 0; iRow < dataGridView_outlook.Rows.Count; iRow++)
            //        {
            //            if ((bool)dataGridView_outlook.Rows[iRow].Cells["Selected"].Value)
            //            {
            //                DateTime dtReceivedTime = (DateTime)dataGridView_outlook.Rows[iRow].Cells["ReceivedTime"].Value;

            //                string AMorPM = "AM";
            //                int iHour = 0;

            //                if (dtReceivedTime.Hour > 12)
            //                {
            //                    AMorPM = "PM";
            //                    iHour = dtReceivedTime.Hour - 12;
            //                }
            //                else
            //                {
            //                    iHour = dtReceivedTime.Hour;
            //                }
            //                string findStart = string.Format("{0}/{1}/{2} {3}:{4} {5}", dtReceivedTime.Year.ToString(), dtReceivedTime.Month.ToString("00"), dtReceivedTime.Day.ToString("00"), iHour.ToString("00"), dtReceivedTime.Minute.ToString("00"), AMorPM);
            //                string findEnd = string.Format("{0}/{1}/{2} {3}:{4} {5}", dtReceivedTime.Year.ToString(), dtReceivedTime.Month.ToString("00"), dtReceivedTime.Day.ToString("00"), iHour.ToString("00"), dtReceivedTime.AddMinutes(1).Minute.ToString("00"), AMorPM);
            //                object RestrictItemMail = oItems.Find(string.Format("[ReceivedTime]>='{0}' and [ReceivedTime]<'{1}'", findStart, findEnd));

            //                mi = (Outlook.MailItem)RestrictItemMail;
            //                string MailMsgName = mi.Subject.Replace("\\", "").Replace("/", "").Replace("*", "").Replace("?", "").Replace("<", "").Replace(">", "").Replace("|", "").Replace("\"", "").Replace(":", "");
            //                string SavePath = string.Format(@"{0}\{1}", FullCopyTo, MailMsgName + ".msg");
            //                mi.SaveAs(SavePath, Outlook.OlSaveAsType.olMSG);

            //                Public.CUpLoadFile uploadfile = new LawtechPTSystemByFirm.Public.CUpLoadFile();
            //                uploadfile.FilePath = string.Format(@"{0}\{1}", MainFileKey, MailMsgName + ".msg");
            //                uploadfile.MainParentID = MainFileKey;
                         
            //                uploadfile.Uploader = Properties.Settings.Default.WorkerName;
            //                uploadfile.FileDoc = mi.Subject;
            //                uploadfile.FileType = MainFileType;
            //                uploadfile.FileKind = UploadMode;
            //                uploadfile.ChildID = ChildFileKey;
            //                uploadfile.Create();
            //            }
            //        }

            //        oItems = null;
            //        ns = null;

            //        if (checkBox1.Checked)//關閉Outlook
            //        {
            //            olApp.Quit();
            //            olApp = null;
            //        }

            //    }
            //    catch (System.Runtime.InteropServices.COMException COMex)
            //    {
            //        string comex = COMex.Message;

            //        ns = null;

            //        olApp = null;
            //    }
            //    catch (System.Exception ex)
            //    {
            //        string ss = ex.Message;

            //        ns = null;

            //        olApp = null;
            //    }
            //}
            //catch (System.Exception EXoutlook)
            //{
            //    MessageBox.Show("Outlook 開啟失敗：\r\n"+EXoutlook.Message);
            //}
        }
        #endregion

        #region button1_Click
        private void button1_Click(object sender, EventArgs e)
        {
            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    dt.Rows.Clear();
            //}

            //Outlook.ApplicationClass olApp;
            //Outlook.NameSpace ns;

            //try
            //{
            //    olApp = new Outlook.ApplicationClass();
            //    ns = olApp.GetNamespace("MAPI");

            //    Outlook.MAPIFolder selectFolder = null;
            //    Outlook.MailItem mi = null;

            //    if (cbOutlookFolder.SelectedItem == null)
            //    {
            //        // 獲得收件箱信息
            //        selectFolder = ns.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);
            //    }
            //    else
            //    {
            //        ComboBoxOutlookProperty itemFloder = (ComboBoxOutlookProperty)cbOutlookFolder.SelectedItem;
            //        selectFolder = ns.GetFolderFromID(itemFloder.EntryID, Type.Missing);
            //    }

            //    this.lab_MailCount.Text = "收件匣:共有" + selectFolder.Items.Count.ToString() + "封郵件";
            //    this.lab_MailCount.Refresh();




            //    DataRow dr = null;

            //    string isread = "未讀";
            //    int i = 0;
            //    Outlook.Items oItems = (Outlook.Items)selectFolder.Items;

            //    String sCriteria;

            //    sCriteria = string.Format("[ReceivedTime] >= '{0} 03:00 AM' and [ReceivedTime] <= '{1} 11:59 PM'", maskedTextBox_Start.Text == "    /  /" ? "1990/01/01" : maskedTextBox_Start.Text, maskedTextBox_EndDate.Text == "    /  /" ? "1990/01/01" : maskedTextBox_EndDate.Text);
            //    Outlook.Items oRestrictedItems = oItems.Restrict(sCriteria);

            //    oRestrictedItems.Sort("[ReceivedTime]", true);

            //    int RestrictedItemsCount = oRestrictedItems.Count;

            //    foreach (object item in oRestrictedItems)
            //    {
            //        mi = item as Outlook.MailItem;
            //        if (mi.UnRead == false)
            //        {
            //            isread = "已讀";
            //        }
            //        dr = dt.NewRow();
            //        dr["Selected"] = false;
            //        dr["Number"] = (i + 1).ToString();
            //        dr["SenderName"] = mi.SenderName;
            //        dr["Subject"] = mi.Subject;
            //        dr["ReceivedTime"] = mi.ReceivedTime.ToString();
            //        dr["Status"] = isread;

            //        dt.Rows.Add(dr);

            //        i++;
            //        if (RestrictedItemsCount == i)
            //        {
            //            this.lab_Reader.Text = "讀取完畢";
            //        }
            //        else
            //        {
            //            this.lab_Reader.Text = "正在讀取：" + i.ToString();
            //        }
            //        this.lab_Reader.Refresh();

            //        //MailList.Add(mi);
            //    }

            //    this.dataGridView_outlook.DataSource = dt;


            //    oItems = null;
            //    ns = null;
            //    if (checkBox1.Checked)
            //    {
            //        olApp.Quit();
            //        olApp = null;
            //    }
            //}
            //catch (System.Exception EX)
            //{
            //    ns = null;

            //    olApp = null;

            //    MessageBox.Show("讀取Outlook發生錯誤："+EX.Message);
            //}
        }
        #endregion

        #region but_SelectFile_Click
        private void but_SelectFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] sFile = openFileDialog1.FileNames;
                for (int iFile = 0; iFile < sFile.Length; iFile++)
                {
                    if (sFile.Length > 0 && sFile[iFile].Length > 3 && sFile[iFile].Substring(sFile[iFile].Length - 3).ToLower() != "exe")
                    {
                        FileInfo file = new FileInfo(sFile[iFile]);
                        ListViewItem item = new ListViewItem(new string[4] { file.Name, (Convert.ToInt32(file.Length) / 1024).ToString(), file.LastWriteTime.ToString(), file.FullName });
                        listView1.Items.Add(item);

                    }
                }
            }
        }
        #endregion

        #region maskedTextBox_Start_DoubleClick
        private void maskedTextBox_Start_DoubleClick(object sender, EventArgs e)
        {
            MaskedTextBox mtb = (MaskedTextBox)sender;
            DateTime dt;
            bool IsSuccess = DateTime.TryParse(mtb.Text, out dt);
            if (!IsSuccess)
            {
                mtb.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }
        }
        #endregion

        private void btnOutlookFolder_Click(object sender, EventArgs e)
        {

        //    Outlook.ApplicationClass olApp;
        //    Outlook.NameSpace ns;

        //    olApp = new Outlook.ApplicationClass();
        //    ns = olApp.GetNamespace("MAPI");

        //    Outlook.MAPIFolder selectFolder = null;
        //    //Outlook.MailItem mi = null;

        //    selectFolder = ns.PickFolder();

        //    //if (cbOutlookFolder.Items.Count > 0)
        //    //{
        //    //    cbOutlookFolder.Items.Clear();
        //    //}

        //    bool isCheck=false;
        //    foreach (object checkItem in cbOutlookFolder.Items)
        //    {
        //        ComboBoxOutlookProperty outlook = (ComboBoxOutlookProperty)checkItem;
        //        if (outlook.EntryID == selectFolder.EntryID)
        //        { 
        //            isCheck=true;
        //            cbOutlookFolder.SelectedItem = checkItem;
        //            return;
        //        }
        //    }

        //    if (!isCheck)
        //    {
        //        ComboBoxOutlookProperty item = new ComboBoxOutlookProperty();
        //        item.EntryID = selectFolder.EntryID;
        //        item.ProFolderName = selectFolder.FolderPath;
        //        cbOutlookFolder.Items.Add(item);

        //        cbOutlookFolder.SelectedItem = item;
        //        //cbOutlookFolder.DisplayMember = "ProFolderName";
        //        //cbOutlookFolder.ValueMember = "EntryID";
        //    }
           
        }

       

    }


    public class ComboBoxOutlookProperty
    {

        public string EntryID
        {
            get;
            set;
        }

        public string ProFolderName
        {
            get;
            set;
        }


    }
}
