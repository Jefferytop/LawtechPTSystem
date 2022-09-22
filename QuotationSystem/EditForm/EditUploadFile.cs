using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystem.EditForm
{
    public partial class EditUploadFile : Form
    {
        public EditUploadFile()
        {
            InitializeComponent();
        }

        private int iUploadKey = -1;
        /// <summary>
        /// UploadT PK值
        /// </summary>
        public int UploadKey
        {
            get { return iUploadKey; }
            set { iUploadKey = value; }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditUploadFile_Load(object sender, EventArgs e)
        {
            this.kindItemTableAdapter.Fill(this.qS_DataSet.KindItem);
            this.countryTTableAdapter.Fill(this.qS_DataSet.CountryT);
            this.kindTTableAdapter.Fill(this.qS_DataSet.KindT);

            //過濾種類1的項目及增加一行空白國別到CountryT           
            //DataRow emptyRow = qS_DataSet.Tables["CountryT"].NewRow();
            //emptyRow["SN"] = -1;
            //emptyRow["CountrySymbol"] = "";
            //qS_DataSet.Tables["CountryT"].Rows.Add(emptyRow);

            Public.CUploadT cup = new Public.CUploadT();
            Public.CUploadT.ReadOne(UploadKey, ref cup);

            if (cup.KindSN != null) {
                cboKind2.SelectedValue = cup.KindSN;
            }
            
            if (cup.CountrySymbol!=null)
            {
                cboCountry.SelectedValue = cup.CountrySymbol;
            }
          
            txtArticleTitle.Text = cup.ArticleTitle;
            txtAuthor.Text = cup.Author;
            txtDescription.Text = cup.Description;
            txtReference.Text = cup.Reference;
            txtRefURL.Text = cup.RefURL;
            txtKeyWords.Text = cup.KeyWods;
        }



        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtArticleTitle.Text == "")
            {
                MessageBox.Show("必要欄位不得為空白！", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Public.DLL module = new Public.DLL();
            Public.CUploadT upload = new Public.CUploadT();
            Public.CUploadT.ReadOne(UploadKey, ref upload);
          

            //string fileServerPath = string.Format(@"{0}\", module.CreatFolder(2, ""));

            //string destFileName = "";

            //取得_NewRow的Table來源並將資料寫入
            //upload.SetDataTable(_NewRow.Table);
            upload.KindSN = cboKind2.SelectedValue != null ? cboKind2.SelectedValue.ToString() : "";
            upload.CountrySymbol = cboCountry.SelectedValue != null ? cboCountry.SelectedValue.ToString() : "";
            upload.ArticleTitle = txtArticleTitle.Text;
            upload.Author = txtAuthor.Text;
            upload.Description = txtDescription.Text;
            upload.KeyWods = txtKeyWords.Text;
            upload.Reference = txtReference.Text;
            upload.RefURL = txtRefURL.Text;
            //upload.FilePath = fileServerPath.Substring(fileServerPath.IndexOf("OfficeData")) +""+ destFileName; //上傳位置路徑+檔名
            upload.LastModifyDateTime = DateTime.Now;
            upload.LastModifyWorker = Properties.Settings.Default.WorkerName;
            upload.Update();

            /*
            if (File.Exists(txtFilePath.Text))
            {
                FileInfo file = new FileInfo(txtFilePath.Text);
                destFileName = file.Name.Substring(0, file.Name.LastIndexOf('.')) + "_" + module.GetRandom() + file.Extension;
                string sFullPath = string.Format(@"{0}{1}", fileServerPath, upload.UploadKey.ToString());
                module.CreatFolder(sFullPath);

                //將相關檔案上傳到相對位置後再把檔名後加上6位數亂碼

                file.CopyTo(string.Format(@"{0}{1}\{2}", fileServerPath, upload.UploadKey.ToString(), destFileName));

                upload.FilePath = string.Format(@"{0}\{1}", upload.UploadKey.ToString(), destFileName);
                upload.Updata(upload.UploadKey);
            }
            */

            Public.PublicForm Forms = new Public.PublicForm();
            DataRow _NewRow = Forms.UploadFile.dt_UploadDT.FindByUploadKey(UploadKey);

            //_NewRow["UploadKey"] = upload.UploadKey;
            _NewRow["Kind"] = cboKind2.Text;
            //_NewRow["CountrySymbol"] = upload.CountrySymbol;
            if (cboCountry.SelectedValue != null)
            {
                _NewRow["Country"] = cboCountry.Text;
            }
            else
            {
                _NewRow["Country"] = "";
            }
            _NewRow["ArticleTitle"] = upload.ArticleTitle;
            _NewRow["Description"] = upload.Description;
            _NewRow["Author"] = upload.Author;
            _NewRow["RefURL"] = upload.RefURL;
            _NewRow["LastModifyDateTime"] = upload.LastModifyDateTime;
            _NewRow["LastModifyWorker"] = Properties.Settings.Default.WorkerName;
            _NewRow["FilePath"] = upload.FilePath;
            Forms.UploadFile.dt_UploadDT.AcceptChanges();

            MessageBox.Show("修改成功");
            this.Close();
        }
    }
}
