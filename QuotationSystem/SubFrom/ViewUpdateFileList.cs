using System;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace LawtechPTSystem.SubFrom
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ViewUpdateFileList : Form
    {

        #region ===============Property===============
        private int mainParentID=-1;
        /// <summary>
        /// 主要ID(專利、商標案的ID)
        /// </summary>
        public int MainParentID
        {
            get { return mainParentID; }
            set { mainParentID = value; }
        }

        private int fileKind = -1;
        /// <summary>
        /// 檔案的類型(1.段落依據 2.相關檔案管理 3.專利案件相關檔案管理 4.商標案件相關檔案管理 5.商標異議案 6.單位財產 10.知識管理  40.客戶管理  50.事務/複代管理)
        /// </summary>
        public int FileKind
        {
            get { return fileKind; }
            set
            {
                fileKind = value;
                switch (fileKind)
                {
                    case 3:
                        groupBox_Pat.Visible = true;
                        groupBox_TM.Visible = false;
                        groupBox_Controvery.Visible = false;
                        groupBox_Default.Visible = false;
                        break;
                    case 4:
                        groupBox_Pat.Visible = false;
                        groupBox_TM.Visible = true;
                        groupBox_Controvery.Visible = false;
                        groupBox_Default.Visible = false;
                        break;
                    case 5:
                        groupBox_Pat.Visible = false;
                        groupBox_TM.Visible = false;
                        groupBox_Controvery.Visible = true;
                        groupBox_Default.Visible = false;
                        break;
                    default:
                        groupBox_Pat.Visible = false;
                        groupBox_TM.Visible = false;
                        groupBox_Controvery.Visible = false;
                        groupBox_Default.Visible = true;
                        break;
                }
                //if (fileKind == 3 || fileKind == 4 || fileKind == 5)//專利、商標、商標異議
                //{
                //    bool b = true; //true:專利  false:商標

                //    if (fileKind == 3)
                //    {
                //        b = true;
                //    }
                //    else
                //    {
                //        b = false;
                //    }
                //    radoC.Visible = b;
                //    radoD.Visible = b;

                //    radioButton_Fee.Visible = b; //請款
                //    radoF.Visible = b; //付款
                //    vb_TM.Visible = !b;
                //    vb_TMFee.Visible = !b;
                //    vb_TMNotify.Visible = !b;
                //    vb_TMPayment.Visible = !b;
                //}
                //else
                //{
                //  bool  b = false;
                //    radoC.Visible = b;
                //    radoD.Visible = b;

                //    radioButton_Fee.Visible = b; //請款
                //    radoF.Visible = b; //付款
                //    vb_TM.Visible = b;
                //    vb_TMFee.Visible = b;
                //    vb_TMNotify.Visible = b;
                //    vb_TMPayment.Visible = b;

                //    radB_all.Visible = true;
                //}
            }
        }

        private int fileType = -1;
        /// <summary>
        ///類型(例:專利 0.申請案 1.事件記錄(委辦)  2.來函  3.請款費用 4.付款費用   6.商標案件 7.來函  8.請款費用 9.付款費用  10商標異議案  11.商標異議案件記錄  12.商標異議請款  13商標異議付款) 40.單位財產 50.知識管理
        ///99.專利、商標、商標異議 的全部
        /// </summary>
        public int FileType
        {
            get { return fileType; }
            set { fileType = value; }
        }

        private int childID = -1;
        /// <summary>
        /// 子key值
        /// </summary>
        public int Child_ID
        {
            get { return childID; }
            set
            {
                childID = value;
                switch (FileType)
                {
                    case 0: 
                        radoC.Checked = true;
                        break;
                    case 1:
                        radoD.Checked = true;
                        break;
                    case 2:
                        //radoE.Checked = true;
                        break;
                    case 3:
                        radioButton_Fee.Checked = true; //請款
                        break;
                    case 4:
                        radoF.Checked = true; //付款
                        break;
                    case 5://---------------商標
                        radB_all.Checked = true; //全部
                        break;
                    case 6:
                        vb_TM.Checked = true;
                        break;
                    case 7:
                        vb_TMNotify.Checked = true;
                        break;
                    case 8:
                        vb_TMFee.Checked = true;
                        break;
                    case 9:
                        vb_TMPayment.Checked = true;
                        break;
                    case 10://------------商標異議
                        vb_Controvery.Checked = true;
                        break;
                    case 11:
                        rb_ControveryEvent.Checked = true;
                        break;
                    case 12:
                        rb_ControveryFee.Checked = true;
                        break;
                    case 13:
                        rb_ControveryPayment.Checked = true;
                        break;
                    case 40:
                        radioButton1.Text = "單位財產";
                        break;
                    case 50:
                        radioButton1.Text = "知識管理";
                        break;
                    default:
                        radB_all.Checked = true;//Patent All
                        break;

                }

            }
        }

        private bool bCheckFTP = false;
        /// <summary>
        /// 確認FTP是否有效
        /// </summary>
        public bool CheckFTP
        {
            get { return bCheckFTP; }
            set { bCheckFTP = value; }
        }
        #endregion

        public ViewUpdateFileList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// DataGridView SelectionMode,拖曳模式是FullRowSelect
        /// </summary>
        public DataGridViewSelectionMode SelectionMode
        {
            get {
                return dataGridView1.SelectionMode ;
            }
            set { dataGridView1.SelectionMode = value; }
        }
       
        private void GetFillUpLoadFile()
        {
            try
            {
                if (FileKind == 3 || FileKind == 4 || FileKind == 5)//專利、商標、商標異議
                {
                    if (FileType == 99)//All
                    {
                        this.upLoadFileTTableAdapter.FillByCaseAll(this.qS_DataSet.UpLoadFileT, FileKind, mainParentID);
                    }
                    //else if (FileType == 0 || FileType == 6 || FileType == 10)//案件 MainParent
                    //{
                    //    this.upLoadFileTTableAdapter.FillByMainParent(this.qS_DataSet.UpLoadFileT, FileKind, mainParentID);
                    //}
                    else
                    {
                        this.upLoadFileTTableAdapter.FillByKindByType(this.qS_DataSet.UpLoadFileT, FileKind, mainParentID, FileType);
                    }
                }
                else
                {
                    this.upLoadFileTTableAdapter.FillByCaseAll(this.qS_DataSet.UpLoadFileT, FileKind, mainParentID);
                }              

            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void ViewUpdateFileList_Load(object sender, EventArgs e)
        {
            Public.DLL dll = new Public.DLL();
            string root = "";

            if (FileKind == 1)
            {
                root = dll.GeneralBasedOnFolderRoot;
            }
            else if (FileKind == 2)
            {
                root = dll.GeneralFolderRoot;
            }
            else if (FileKind == 3)
            {
                root = dll.PatentFolderRoot;
            }
            else if (FileKind == 4)
            {
                root = dll.TrademarkFolderRoot;
            }
            else if (FileKind == 5)
            {
                root = dll.TrademarkControversyFolderRoot;
            }
            else if (FileKind == 10)
            {
                root = dll.KMFolderRoot;
            }
            else if (FileKind == 40)
            {
                root = dll.CustomerFolderRoot;
            }
            else if (FileKind == 50)
            {
                root = dll.FirmFolderRoot;
            }
            else//FileKind=6
            {
                root = dll.OfficePropertyFolderRoot;
            }
            toolStripLabel_Path.Text =Path.Combine( root, MainParentID.ToString());


            if (FileKind == 6 || FileKind == 10)
            {
                if (FileKind == 6)
                {
                    radioButton1.Text = "單位財產";
                }
                else if (FileKind == 10)
                {
                    radioButton1.Text = "知識管理";
                }
                GetFillUpLoadFile();
            }

          
            //webBrowser1.Navigating +=
            //    new WebBrowserNavigatingEventHandler(webBrowser1_Navigating);

        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            System.Windows.Forms.HtmlDocument document = this.webBrowser1.Document;

            if (document != null && document.All["userName"] != null &&  String.IsNullOrEmpty(  document.All["userName"].GetAttribute("value")))
            {
                e.Cancel = true;
                System.Windows.Forms.MessageBox.Show(
                    "You must enter your name before you can navigate to " +
                    e.Url.ToString());
            }
        }

        private void radB_all_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;

            switch (rb.Name)
            {
                case "radoC":
                    if (rb.Checked)//申請案
                    {
                        FileType = 0;
                    }
                    break;
                case "radoD":
                    if (rb.Checked) //事件記錄
                    {
                        FileType = 1;
                    }
                    break;
                case "radioButton_Fee":
                    if (rb.Checked)//請款
                    {
                        FileType = 3;
                    }
                    break;
                case "radoF":
                    if (rb.Checked)//付款
                    {
                        FileType = 4;
                    }
                    break;
                case "vb_TM":
                    if (rb.Checked)//商標
                    {
                        FileType = 6;
                    }
                    break;
                case "vb_TMNotify":
                    if (rb.Checked)//商標事件記錄
                    {
                        FileType = 7;
                    }
                    break;
                case "vb_TMFee":
                    if (rb.Checked)//請款
                    {
                        FileType = 8;
                    }
                    break;
                case "vb_TMPayment":
                    if (rb.Checked)//付款
                    {
                        FileType = 9;
                    }
                    break;
                case "vb_Controvery":
                    if (rb.Checked)
                    {
                        FileType = 10;//------------商標異議
                    }
                    break;
                case "rb_ControveryEvent":
                    if (rb.Checked)
                    {
                        FileType = 11;
                    }
                    break;
                case "rb_ControveryFee":
                    if (rb.Checked)
                    {
                        FileType = 12;
                    }
                    break;
                case "rb_ControveryPayment":
                    if (rb.Checked)
                    {
                        FileType = 13;
                    }
                    break;
                case "rb_ControveryAll":
                case "vb_TMall":
                case "radB_all":
                    if (rb.Checked)//全部
                    {
                        FileType = 99;
                    }
                    break;
            }

            if (rb.Checked)
            {
                GetFillUpLoadFile();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                switch (dataGridView1.Columns[e.ColumnIndex].Name)
                {

                    case "FileDoc":
                        try
                        {
                            Public.DLL dll = new Public.DLL();
                            string root = "";

                            if (FileKind == 1)
                            {
                                root = dll.GeneralBasedOnFolderRoot;
                            }
                            else if (FileKind == 2)
                            {
                                root = dll.GeneralFolderRoot;
                            }
                            else if (FileKind == 3)
                            {
                                root = dll.PatentFolderRoot;
                            }
                            else if (FileKind == 4)
                            {
                                root = dll.TrademarkFolderRoot;
                            }
                            else if (FileKind == 5)
                            {
                                root = dll.TrademarkControversyFolderRoot;
                            }
                            else if (FileKind == 10)
                            {
                                root = dll.KMFolderRoot;
                            }
                            else if (FileKind == 40)
                            {
                                root = dll.CustomerFolderRoot;
                            }
                            else if (FileKind == 50)
                            {
                                root = dll.FirmFolderRoot;
                            }
                            else//FileKind=6
                            {
                                root = dll.OfficePropertyFolderRoot;
                            }

                            string sPath =Path.Combine( root , dataGridView1.CurrentRow.Cells["FilePath"].Value.ToString());

                            if (File.Exists(sPath))
                            {
                                System.Diagnostics.Process.Start(sPath);
                            }
                            else
                            {
                                MessageBox.Show("該路徑並無此檔案  " + sPath);
                            }
                        }
                        catch (System.Exception EX)
                        {
                            MessageBox.Show(EX.Message.Replace("'", ""));
                        }
                        break;
                }
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                if (MessageBox.Show("是否確定刪除該檔案\r\n" + dataGridView1.CurrentRow.Cells["FileDoc"].Value.ToString(), "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    int iUpLoadID = (int)dataGridView1.CurrentRow.Cells["UpLoadID"].Value;
                    Public.CUpLoadFile upfile = new Public.CUpLoadFile();
                    Public.CUpLoadFile.ReadOne(iUpLoadID, ref upfile);
                    string FullPath = dataGridView1.CurrentRow.Cells["FilePath"].Value.ToString();
                   

                   // GetFillUpLoadFile();

                    //刪除記錄檔    
                    Public.CSystemLogT log = new Public.CSystemLogT();
                    log.DelTime = DateTime.Now;
                    log.DelWorkerKey = Properties.Settings.Default.WorkerKEY;
                    log.DelWorker = Properties.Settings.Default.WorkerName;
                    //string[] str = upfile.GetInsertString(iUpLoadID);
                    //log.TableName = str[2];
                    //log.DelContent_InsertColumn = str[0];
                    //log.DelContent_InsertSQL = str[1];
                    log.DelContent = string.Format("檔案說明:{0}", upfile.FileDoc);
                    log.DelTitle = string.Format("刪除附件【{0}】", upfile.FileDoc);
                    log.Create();


                    Public.DLL dll = new Public.DLL();
                    string delFileDir = "";
                    try
                    {
                        if (FileKind == 3)
                        {
                            delFileDir = string.Format(@"{0}\{1}", dll.PatentFolderRoot, FullPath);
                        }
                        else if (FileKind == 4)
                        {
                            delFileDir = string.Format(@"{0}\{1}", dll.TrademarkFolderRoot, FullPath);
                        }
                        else if (FileKind == 1)
                        {
                            delFileDir = string.Format(@"{0}\{1}", dll.GeneralBasedOnFolderRoot, FullPath);
                        }
                        else if (FileKind == 2)
                        {
                            delFileDir = string.Format(@"{0}\{1}", dll.GeneralFolderRoot, FullPath);
                        }
                        else if (FileKind == 5)
                        {
                            delFileDir = string.Format(@"{0}\{1}", dll.TrademarkControversyFolderRoot, FullPath);
                        }
                        else if (FileKind == 6)
                        {
                            delFileDir = string.Format(@"{0}\{1}", dll.OfficePropertyFolderRoot, FullPath);
                        }
                        else if (FileKind == 10)
                        {
                            delFileDir = string.Format(@"{0}\{1}", dll.KMFolderRoot, FullPath);
                        }
                        else if (FileKind == 40)
                        {
                            delFileDir = string.Format(@"{0}\{1}", dll.CustomerFolderRoot, FullPath);
                        }


                        if (File.Exists(delFileDir))
                        {
                            //建立存放的資料夾
                            dll.CreatFolder(Public.CreateFolerdMode.UpFileLog, log.SysLogID.ToString());
                            //複製一份到Log資料夾
                            FileInfo copyFile = new FileInfo(delFileDir);
                            string FileFullName = dll.DelFileFolderRoot +"\\"+log.SysLogID.ToString()+ "\\" + copyFile.Name;
                            copyFile.CopyTo(FileFullName,true);


                            File.Delete(delFileDir);
                        }

                        upfile.Delete(iUpLoadID);

                        dataGridView1.Rows.Remove(dataGridView1.CurrentRow);

                        MessageBox.Show("刪除成功", "提示訊息");
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message.Replace("'", ""), "提示訊息");
                    }

                  
                }
            }
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip1.Visible = false;
            switch (e.ClickedItem.Name)
            {
                case "ToolStripMenuItem_DelFile":
                    bindingNavigatorDeleteItem_Click(bindingNavigatorDeleteItem, null);
                    break;

                case "ToolStripMenuItem_SaveAs":                   

                    Public.DLL dll = new Public.DLL();
                    string SaveFileDir = "";

                    
                        if (dataGridView1.SelectedRows.Count > 0)
                        {
                            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                            {
                                for (int iRow = 0; iRow < dataGridView1.SelectedRows.Count; iRow++)
                                {
                                    if (folderBrowserDialog1.SelectedPath != "")
                                    {
                                        string NewPath = folderBrowserDialog1.SelectedPath;
                                        string FullPath = dataGridView1.SelectedRows[iRow].Cells["FilePath"].Value.ToString();
                                        if (FileKind == 3)
                                        {
                                            SaveFileDir = string.Format(@"{0}\{1}", dll.PatentFolderRoot, FullPath);
                                        }
                                        else if (FileKind == 4)
                                        {
                                            SaveFileDir = string.Format(@"{0}\{1}", dll.TrademarkFolderRoot, FullPath);
                                        }
                                        else if (FileKind == 1)
                                        {
                                            SaveFileDir = string.Format(@"{0}\{1}", dll.GeneralBasedOnFolderRoot, FullPath);
                                        }
                                        else if (FileKind == 2)
                                        {
                                            SaveFileDir = string.Format(@"{0}\{1}", dll.GeneralFolderRoot, FullPath);
                                        }
                                        else if (FileKind == 5)
                                        {
                                            SaveFileDir = string.Format(@"{0}\{1}", dll.TrademarkControversyFolderRoot, FullPath);
                                        }
                                        else if (FileKind == 6)
                                        {
                                            SaveFileDir = string.Format(@"{0}\{1}", dll.OfficePropertyFolderRoot, FullPath);
                                        }
                                        if (File.Exists(SaveFileDir))
                                        {
                                            try
                                            {
                                                FileInfo file = new FileInfo(SaveFileDir);
                                                File.Copy(SaveFileDir, NewPath + "\\" + file.Name);
                                            }
                                            catch (System.Exception EX)
                                            {
                                                MessageBox.Show(EX.Message);
                                                return;
                                            }
                                          
                                        }

                                    }
                                }
                                MessageBox.Show("另存檔案成功", "提示訊息");
                            }
                    }
                    else
                    {
                        if (dataGridView1.CurrentRow != null)
                        {
                            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                            {
                                if (folderBrowserDialog1.SelectedPath != "")
                                {
                                    string NewPath = folderBrowserDialog1.SelectedPath;

                                    string FullPath = dataGridView1.CurrentRow.Cells["FilePath"].Value.ToString();

                                    if (FileKind == 3)
                                    {
                                        SaveFileDir = string.Format(@"{0}\{1}", dll.PatentFolderRoot, FullPath);
                                    }
                                    else if (FileKind == 4)
                                    {
                                        SaveFileDir = string.Format(@"{0}\{1}", dll.TrademarkFolderRoot, FullPath);
                                    }
                                    else if (FileKind == 1)
                                    {
                                        SaveFileDir = string.Format(@"{0}\{1}", dll.GeneralBasedOnFolderRoot, FullPath);
                                    }
                                    else if (FileKind == 2)
                                    {
                                        SaveFileDir = string.Format(@"{0}\{1}", dll.GeneralFolderRoot, FullPath);
                                    }
                                    else if (FileKind == 5)
                                    {
                                        SaveFileDir = string.Format(@"{0}\{1}", dll.TrademarkControversyFolderRoot, FullPath);
                                    }
                                    else if (FileKind == 6)
                                    {
                                        SaveFileDir = string.Format(@"{0}\{1}", dll.OfficePropertyFolderRoot, FullPath);
                                    }

                                    if (File.Exists(SaveFileDir))
                                    {
                                        try
                                        {
                                            FileInfo file = new FileInfo(SaveFileDir);
                                            File.Copy(SaveFileDir, NewPath + "\\" + file.Name);
                                        }
                                        catch (System.Exception EX)
                                        {
                                            MessageBox.Show(EX.Message);
                                            return;
                                        }
                                        MessageBox.Show("另存檔案成功","提示訊息");
                                    }

                                }
                            }
                        }
                    }
                    break;
            }
        }


        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Public.DLL dll = new Public.DLL();
                string root = "";

                if (FileKind == 1)
                {
                    root = dll.GeneralBasedOnFolderRoot;
                }
                else if (FileKind == 2)
                {
                    root = dll.GeneralFolderRoot;
                }
                else if (FileKind == 3)
                {
                    root = dll.PatentFolderRoot;
                }
                else if (FileKind == 4)
                {
                    root = dll.TrademarkFolderRoot;
                }
                else if (FileKind == 5)
                {
                    root = dll.TrademarkControversyFolderRoot;
                }
                else//單位財產上傳路徑
                {
                    root = dll.OfficePropertyFolderRoot;
                }

                StringBuilder sb = new StringBuilder();

                if (dataGridView1.SelectedRows.Count == 1)
                {
                    sb.Append(root + "\\" + dataGridView1.Rows[e.RowIndex].Cells["FilePath"].Value.ToString());
                }
                else
                {
                    for (int iRow = 0; iRow < dataGridView1.SelectedRows.Count; iRow++)
                    {
                        sb.Append(root + "\\" + dataGridView1.SelectedRows[iRow].Cells["FilePath"].Value.ToString() + ";");
                    }
                }

                if (sb.Length > 0)
                {
                    dataGridView1.DoDragDrop(sb.ToString(), DragDropEffects.Copy);
                }
            }


        }

        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                Public.DLL dll = new Public.DLL();
                string SaveFileDir = "";

                string FullPath = dataGridView1.CurrentRow.Cells["FilePath"].Value.ToString();

                if (FileKind == 3)
                {
                    SaveFileDir = string.Format(@"{0}\{1}", dll.PatentFolderRoot, FullPath);
                }
                else if (FileKind == 4)
                {
                    SaveFileDir = string.Format(@"{0}\{1}", dll.TrademarkFolderRoot, FullPath);
                }
                else if (FileKind == 1)
                {
                    SaveFileDir = string.Format(@"{0}\{1}", dll.GeneralBasedOnFolderRoot, FullPath);
                }
                else if (FileKind == 2)
                {
                    SaveFileDir = string.Format(@"{0}\{1}", dll.GeneralFolderRoot, FullPath);
                }
                else if (FileKind == 5)
                {
                    SaveFileDir = string.Format(@"{0}\{1}", dll.TrademarkControversyFolderRoot, FullPath);
                }
                else if (FileKind == 6)
                {
                    SaveFileDir = string.Format(@"{0}\{1}", dll.OfficePropertyFolderRoot, FullPath);
                }

                if (File.Exists(SaveFileDir))
                {
                    try
                    {
                        //FileStream sFile= File.OpenRead(SaveFileDir);
                        string ExtensionName = System.IO.Path.GetExtension(SaveFileDir);
                        //webBrowser1.Navigate ( new Uri(SaveFileDir),false);
                        webBrowserShowFile(ExtensionName, SaveFileDir);
                    }
                    catch 
                    {
                       
                    }
                    
                }
            }
        }

        #region private void webBrowserShowFile(string fileType, string urlPath)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileType"></param>
        /// <param name="urlPath"></param>
        private void webBrowserShowFile(string fileType, string urlPath)
        {
            //webBrowser1.DocumentText =
            string strDocumentText =
     "<!DOCTYPE html><html><head><meta charset=\"UTF-8\"><meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">" +
     "<meta name=\"viewport\" content=\"width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no\" >" +
        "</head><body>" +
        "<div class=\"container\">" +
        "  <div class=\"row\">" +
        "<div class=\"col\">{0} </div>" +
         "</div>" +
        "</div>" +
     "</body></html>";

            switch (fileType.ToLower())
            {
                case ".jpg":
                case ".png":
                case ".jpeg":
                case ".gif":
                case ".bmp":
                    string img = "<img src=\"" + urlPath + "\">";
                    webBrowser1.DocumentText = string.Format(strDocumentText, img);
                    break;
                case ".pdf":
                    string strpdf = @"";
                    webBrowser1.DocumentText = string.Format(strDocumentText, strpdf);
                    break;
                default:

                    break;
            }

        }
        #endregion

        private void toolStripButton_View_Click(object sender, EventArgs e)
        {
            //if(splitContainer1.Panel2)

            if (!splitContainer1.Panel2Collapsed)
            {
                toolStripButton_View.Text = "開啟檔案預覽";
                splitContainer1.Panel2Collapsed = true;
            }
            else
            {
                toolStripButton_View.Text = "關閉檔案預覽";
                splitContainer1.Panel2Collapsed = false;
            }
        }

    }
}
