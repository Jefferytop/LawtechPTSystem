using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.SubFrom
{
    /// <summary>
    /// 知識管理
    /// </summary>
    public partial class UploadFile : Form
    {

        #region =====自定變數=====
        //private Public.CUpload cu; //Upload資料表公用變數
        private DataTable uploadDT; //上傳資料表
        /// <summary>
        /// 上傳資料表
        /// </summary>
        public DataTable UploadDT
        {
            get { return uploadDT; }
            set { uploadDT = value; }
        }

        /// <summary>
        /// 取得UploadDT資料
        /// </summary>
        public DataSet_KM.UploadTDataTable dt_UploadDT
        {
            get { return this.dataSet_KM.UploadT; }
            
        }


        private Public.DLL module = new Public.DLL(); //公用功能

        //時間格式測試
        private bool isDate(string sDate)
        {
            try
            {
                DateTime.Parse(sDate);
            }
            catch
            {
                return false;
            }
            return true;
        }
        #endregion

        public UploadFile()
        {
            InitializeComponent();
            dgvUploadFile.AutoGenerateColumns = false;
        }

        private void UploadFile_Load(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.UploadFile = this;

            this.uploadTTableAdapter.Fill(this.dataSet_KM.UploadT);

            UploadTControlBinding();
            

            //uploadDT.ColumnChanged += new DataColumnChangeEventHandler(uploadDT_ColumnChanged);
            //uploadDT.RowDeleting += new DataRowChangeEventHandler(uploadDT_RowDeleting);
        }

        private void UploadFile_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.UploadFile = null;
        }

        #region ================UploadTControlBinding================
        public void UploadTControlBinding()
        {

            //篇名
            txt_ArticleTitle.DataBindings.Clear();
            txt_ArticleTitle.DataBindings.Add("Text", uploadTBindingSource, "ArticleTitle", true, DataSourceUpdateMode.OnValidation, "", "");

            //簡述
            txt_Description.DataBindings.Clear();
            txt_Description.DataBindings.Add("Text", uploadTBindingSource, "Description", true, DataSourceUpdateMode.OnValidation, "", "");

            //
            txt_Author.DataBindings.Clear();
            txt_Author.DataBindings.Add("Text", uploadTBindingSource, "Author", true, DataSourceUpdateMode.OnValidation, "", "");

            //
            txt_KindSN.DataBindings.Clear();
            txt_KindSN.DataBindings.Add("Text", uploadTBindingSource, "Kind", true, DataSourceUpdateMode.OnValidation, "", "");

            //國別
            txt_CountrySymbol.DataBindings.Clear();
            txt_CountrySymbol.DataBindings.Add("Text", uploadTBindingSource, "Country", true, DataSourceUpdateMode.OnValidation, "", "");
                      
            //建立人員
            txt_BuildWorker.DataBindings.Clear();
            txt_BuildWorker.DataBindings.Add("Text", uploadTBindingSource, "Creator", true, DataSourceUpdateMode.OnValidation, "");

            //修改人員
            //txt_EditedWorker.DataBindings.Clear();
            //txt_EditedWorker.DataBindings.Add("Text", uploadTBindingSource, "EditedWorker", true, DataSourceUpdateMode.OnValidation, "");

            //
            txt_BuildDate.DataBindings.Clear();
            txt_BuildDate.DataBindings.Add("Text", uploadTBindingSource, "CreateDateTime", true, DataSourceUpdateMode.OnValidation, "", "yyyy/MM/dd HH:mm");

          

        }
        #endregion

        #region =====資料表觸發事件=====
        void uploadDT_RowDeleting(object sender, DataRowChangeEventArgs e)
        {
            module.SQLexecuteNonQuery(string.Format("Delete From UploadT Where UploadKey = {0}", e.Row["UploadKey"].ToString()));
        }

        void uploadDT_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            switch (e.Column.ColumnName)
            {
                case "Description":
                    module.SQLexecuteNonQuery(string.Format(@"Update UploadT Set Description = '{0}',EditedDate = '{3}', EditedWorker = '{1}' Where UploadKey = {2}",
                        e.Row["Description"].ToString(),
                        Properties.Settings.Default.WorkerKEY,
                        e.Row["UploadKey"].ToString(),
                        DateTime.Now.ToShortDateString()));
                    break;
                default:
                    break;
            }
        }
        #endregion

      

        #region =====btnSearch_Click=====
        //依條件進行查尋
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string strSQLWhere = Public.CommonFunctions.GetSQLScript(QueryFilter1, QueryFilter2, Radio_and.Checked ? " and " : " or ", userControlFilterDate1);
            uploadTBindingSource.Filter = strSQLWhere;
            
        }
        #endregion

        #region =====btnShowAll_Click=====
        //顯示所有資料列
        private void btnShowAll_Click(object sender, EventArgs e)
        {
            this.dataSet_KM.UploadT.Clear();
            this.uploadTTableAdapter.Fill(this.dataSet_KM.UploadT);
            uploadTBindingSource.Filter = "";
        }
        #endregion

        #region =====cmsUploadSelection_ItemClicked=====
        //快顯-更新選項 項目點選
        private void cmsUploadSelection_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            cmsUploadSelection.Visible = false;
            switch (e.ClickedItem.Name)
            {
                case "toolStripButton_Add":
                case "addToolStripMenuItem":
                    AddFrom.AddUploadFile upload = new AddFrom.AddUploadFile();
                    if (dt_UploadDT != null)
                    {
                        upload.NewRow = dt_UploadDT.NewRow();
                    }

                    if (upload.ShowDialog() == DialogResult.OK)
                    {
                        dt_UploadDT.Rows.Add(upload.NewRow);
                    }

                   
                    break;

                case "toolStripButton_Del":
                case "deleteToolStripMenuItem":

                    if (dgvUploadFile.CurrentRow != null)
                    {
                        if (MessageBox.Show(string.Format("確定要刪除【{0}】？", dgvUploadFile.CurrentRow.Cells["ArticleTitle"].Value.ToString()),
                       e.ClickedItem.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Public.DLL dll = new Public.DLL();
                            dll.DeleteFolder(dll.GeneralFolderRootUpload + "\\" + dgvUploadFile.CurrentRow.Cells["UploadKey"].Value.ToString(), true);

                            int Key = (int)dgvUploadFile.CurrentRow.Cells["UploadKey"].Value;
                            Public.CUploadT cu = new Public.CUploadT();
                            Public.CUploadT.ReadOne(Key, ref cu,"");
                            //刪除記錄檔    
                            Public.CSystemLogT log = new Public.CSystemLogT();
                            log.DelTime = DateTime.Now;
                            log.DelWorkerKey = Properties.Settings.Default.WorkerKEY;
                            log.DelWorker = Properties.Settings.Default.WorkerName;
                            log.DelContent = string.Format("知識管理資料:{0}-{1}\r\n ", cu.ArticleTitle, cu.Author);
                            log.DelTitle = string.Format("刪除「{0}」資料【{1}-{2}-{3}-{4}】", this.Text, cu.Author, cu.KindSN,cu.CountrySymbol,cu.RefURL);
                            log.Create();

                            cu.Delete(Key, "");

                            dgvUploadFile.Rows.Remove(dgvUploadFile.CurrentRow);
                            MessageBox.Show("刪除成功");
                        }
                    }
                    break;
                case "edittoolStripMenuItem":
                case "toolStripButton_Edit":
                    if (dgvUploadFile.CurrentRow != null)
                    {
                        EditForm.EditUploadFile edit = new LawtechPTSystem.EditForm.EditUploadFile();
                        edit.UploadKey = (int)dgvUploadFile.CurrentRow.Cells["UploadKey"].Value;
                        edit.ShowDialog();
                    }
                    break;

                case "ToolStripMenuItem_KeyWorkSetting"://關鍵字設定

                    SubFrom.KeyWords keywords = new LawtechPTSystem.SubFrom.KeyWords();
                    keywords.ShowDialog();
                    break;

                case "ToolStripMenuItem_UpLoad":
                    if (dgvUploadFile.CurrentRow != null)
                    {
                        bool bConnectionFile = Properties.Settings.Default.IsFileServerConnection;
                        if (bConnectionFile)
                        {
                            //US.UpdataFile upfile2 = new US.UpdataFile();
                            US.UpFileList upfile2 = new US.UpFileList();
                        upfile2.Text = "上傳申請案(" + dgvUploadFile.CurrentRow.Cells["ArticleTitle"].Value.ToString() + ")相關文件";
                        upfile2.MainFileKey = (int)dgvUploadFile.CurrentRow.Cells["UploadKey"].Value;
                        upfile2.UploadMode = 10;
                        upfile2.MainFileType = 50;
                        upfile2.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("請確認檔案上傳路徑是否有正常連結!!");
                        }
                    }
                    break;
                case "toolStripMenuItem_OpenFile":
                    if (dgvUploadFile.CurrentRow != null)
                    {
                        bool bConnectionFile = Properties.Settings.Default.IsFileServerConnection;
                        if (bConnectionFile)
                        {
                            ViewUpdateFileList subForm = new ViewUpdateFileList();
                        subForm.Text = dgvUploadFile.CurrentRow.Cells["ArticleTitle"].Value.ToString() + " 的相關文件";
                        subForm.FileKind = 10;
                        subForm.FileType = 50;
                        subForm.MainParentID = (int)dgvUploadFile.CurrentRow.Cells["UploadKey"].Value;
                        subForm.radoC.Checked = true;
                        subForm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("請確認檔案上傳路徑是否有正常連結!!");
                        }
                    }
                    break;
                case "toolStripMenuItem_Horizontal":
                case "toolStripButton_ContainerHorizontal":
                    Public.Utility.SsplitContainerHorizontal(ref splitContainer1);
                    break;
            }
        }
        #endregion

        #region =====dgvUploadFile_CellClick=====
        //擷取表格所選欄位名稱再做指定動作
        private void dgvUploadFile_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {
                switch (dgvUploadFile.Columns[e.ColumnIndex].Name)
                {
                    case "ArticleTitle"://點選的篇名後開啟相關檔案
                       

                        if (dgvUploadFile.CurrentRow.Cells["FilePath"].Value.ToString() != "")
                        {
                            Public.DLL module = new Public.DLL();
                            string file = string.Format(@"{0}\{1}", module.GeneralFolderRootUpload, dgvUploadFile.CurrentRow.Cells["FilePath"].Value.ToString());
                            if (System.IO.File.Exists(file))
                                System.Diagnostics.Process.Start(file);
                            else
                                MessageBox.Show("此相關檔案可能遺失！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;

                    case "Description"://編輯簡述
                        //AddFrom.InputMemo input = new AddFrom.InputMemo((DataGridViewTextBoxCell)dgvUploadFile.CurrentCell, false, "簡述");                       

                        break;

                    case "RefURL":
                        if (dgvUploadFile.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Replace("http://", "").Trim() != "")
                        {
                            Public.Utility.ProcessStart("http://" + dgvUploadFile.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Replace("http://", ""));
                        }
                        break;

                    default:
                        break;

                }
            }
        }
        #endregion

        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void maskedStartDate_DoubleClick(object sender, EventArgs e)
        {
            MaskedTextBox mtb = (MaskedTextBox)sender;
            DateTime dt;
            bool IsSuccess = DateTime.TryParse(mtb.Text, out dt);
            if (!IsSuccess)
            {
                mtb.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        private void but_ShowDetail_Click(object sender, EventArgs e)
        {
            if (!splitContainer1.Panel2Collapsed)
            {
                but_ShowDetail.Text = "開啟明細(Alt+E)";

                splitContainer1.Panel2Collapsed = true;
            }
            else
            {
                but_ShowDetail.Text = "關閉明細(Alt+E)";
                splitContainer1.Panel2Collapsed = false;
            }
        }

        private void UploadFile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt)
            {
                if (e.KeyCode == Keys.E)
                {
                    but_ShowDetail_Click(null, null);
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel link = (LinkLabel)sender;
            US.PopMemo pop;
            pop = new LawtechPTSystem.US.PopMemo(txt_Description, true, link.Text);

            pop.Show();
        }

        private void dgvUploadFile_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cmsUploadSelection_ItemClicked(cmsUploadSelection, new ToolStripItemClickedEventArgs(edittoolStripMenuItem));
        }

       
    }
}