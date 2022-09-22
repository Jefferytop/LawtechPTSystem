using System;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace LawtechPTSystem.AddFrom
{
    public partial class AddUploadFile : Form
    {
        #region ====自定變數=====
        /// <summary>
        /// 取得或設定即將關聯的資料列
        /// </summary>
        private DataRow _NewRow = null;
        public DataRow NewRow
        {
            get { return _NewRow; }
            set { _NewRow = value; }
        }

        /// <summary>
        /// 設定視窗開啟模式 1:新增模式 2:修改模式
        /// </summary>
        private int _OpenMode = 1;
        public int OpenMode
        {
            set { _OpenMode = value; }
        }
        #endregion

        //檔案上傳的位置 OfficeData\general\Upload\
        public AddUploadFile()
        {
            InitializeComponent();
        }

        private void AddUploadFile_Load(object sender, EventArgs e)
        {
            this.kindItemTableAdapter.Fill(this.qS_DataSet.KindItem);
            this.countryTTableAdapter.Fill(this.qS_DataSet.CountryT);
            this.kindTTableAdapter.Fill(this.qS_DataSet.KindT);
            
            //過濾種類1的項目及增加一行空白國別到CountryT
            kindTBindingSource.Filter = string.Format("OvertureKind = '{0}'",cboKind1.SelectedValue);
            //DataRow emptyRow = qS_DataSet.Tables["CountryT"].NewRow();
            //emptyRow["SN"] = -1;
            //emptyRow["CountrySymbol"] = "";
            //qS_DataSet.Tables["CountryT"].Rows.Add(emptyRow);

            cboCountry.SelectedIndex = 0;
        }

        //取得上傳路徑
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = ofd.FileName;
            }
        }

        //確定新增
        private void btnOK_Click(object sender, EventArgs e)
        {
            switch (_OpenMode)
            {
                case 1:
                    if (txtArticleTitle.Text == "" )
                    {
                        MessageBox.Show("必要欄位不得為空白！", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                   
                        Public.DLL module = new Public.DLL();
                        Public.CUploadT upload = new Public.CUploadT();

                        string fileServerPath = string.Format(@"{0}\", module.CreatFolder(2, ""));
                           
                        string destFileName = "";

                        //取得_NewRow的Table來源並將資料寫入
                        //upload.SetDataTable(_NewRow.Table);
                        upload.KindSN = cboKind1.SelectedValue != null ? cboKind1.SelectedValue.ToString() : "";
                        upload.CountrySymbol = cboCountry.SelectedValue != null ? cboCountry.SelectedValue.ToString() : "";
                        upload.ArticleTitle = txtArticleTitle.Text;
                        upload.Author = txtAuthor.Text;
                        upload.Description = txtDescription.Text;
                        upload.KeyWods = txtKeyWords.Text;
                        upload.Reference = txtReference.Text;
                        upload.RefURL = txtRefURL.Text;
                        //upload.FilePath = fileServerPath.Substring(fileServerPath.IndexOf("OfficeData")) +""+ destFileName; //上傳位置路徑+檔名                     
                       upload.Creator = Properties.Settings.Default.WorkerName;
                        object obj=upload.Create();

                        if (File.Exists(txtFilePath.Text))
                        {
                            FileInfo file = new FileInfo(txtFilePath.Text);
                            destFileName = file.Name.Substring(0, file.Name.LastIndexOf('.')) + "_" + module.GetRandom() + file.Extension;
                            string sFullPath = string.Format(@"{0}{1}", fileServerPath, upload.UploadKey.ToString());
                            module.CreatFolder(sFullPath);

                            //將相關檔案上傳到相對位置後再把檔名後加上6位數亂碼

                            file.CopyTo(string.Format(@"{0}{1}\{2}", fileServerPath, upload.UploadKey.ToString(), destFileName));

                            upload.FilePath = string.Format(@"{0}\{1}", upload.UploadKey.ToString(), destFileName);
                            upload.Update();
                        }

                    //Public.PublicForm Forms = new Public.PublicForm();
                    //if (Forms.UploadFile != null)
                    //{
                    //    DataRow dr = Forms.upd.DT_ApplicantSearchT.NewRow();
                    //    DataRow drV = Public.CApplicantPublicFunction.GetApplicantListDataRow(app.ApplicantKey.ToString());
                    //    dr.ItemArray = drV.ItemArray;
                    //    Forms.ApplicantList.DT_ApplicantSearchT.Rows.Add(dr);
                    //    dr.AcceptChanges();
                    //}
                    _NewRow["UploadKey"]=upload.UploadKey;
                         _NewRow["KindSN"]=upload.KindSN;
                         if (cboKind2.SelectedValue != null)
                         {
                             _NewRow["Kind"] = cboKind1.Text;
                         }
                         else
                         {
                             _NewRow["Kind"] = "";
                         }
                         _NewRow["CountrySymbol"]=upload.CountrySymbol;
                         if (cboCountry.SelectedValue != null)
                         {
                             _NewRow["Country"] = cboCountry.Text;
                         }
                         else
                         {
                             _NewRow["Country"] = "";
                         }
                         _NewRow["ArticleTitle"]=upload.ArticleTitle ;
                         _NewRow["Description"]= upload.Description;
                         _NewRow["Author"]=upload.Author;
                         _NewRow["RefURL"] = upload.RefURL;
                         _NewRow["CreateDateTime"] =upload.CreateDateTime;
                         _NewRow["Creator"] = upload.Creator;
                         _NewRow["FilePath"]=upload.FilePath;

                        this.Close();
                  
                    break;

                case 2:


                default:
                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboKind1_SelectedIndexChanged(object sender, EventArgs e)
        {
            kindTBindingSource.Filter = string.Format("OvertureKind = '{0}'", cboKind1.SelectedValue);
        }

       

        private void txtKeyWords_DoubleClick(object sender, EventArgs e)
        {
            AddFrom.AddKeyWordsModify modify = new AddFrom.AddKeyWordsModify();
            modify.TxtSource = txtKeyWords;
            modify.ShowDialog();
        }

          
    }
}