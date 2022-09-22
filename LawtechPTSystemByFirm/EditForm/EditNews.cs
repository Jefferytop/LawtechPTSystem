using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.EditForm
{
    public partial class EditNews : Form
    {
        public EditNews()
        {
            InitializeComponent();
        }

        private string sourceTableName = "NewsT";

        #region Public Property
        private int iNewsKey = -1;
        /// <summary>
        /// 公怖欄ID
        /// </summary>
        public int Pro_NewsKey
        {
            get { return iNewsKey; }
            set { iNewsKey = value; }
        } 
        #endregion


        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            //必填欄位
            TextBox[] txtList = { txt_NewsSubject };
            bool IsCheckTextBoxEmpty = Public.CommonFunctions.RequiredFieldsTextBoxIsEmpty(txtList);
            if (IsCheckTextBoxEmpty)
            {
                return;
            }

            DB_NewsTModel newsAdd = new DB_NewsTModel();
            DB_NewsTModel.ReadOne(Pro_NewsKey, ref newsAdd);

            newsAdd.NewsContent = txt_NewsContent.Text;
            newsAdd.NewsSubject = txt_NewsSubject.Text;
            newsAdd.NewsTypeKey = (int)comboBox_NewsTypeID.SelectedValue;

            newsAdd.Update();


           
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            if (Forms.News != null)
            {
                DataRow dr = Forms.News.DT_News.Rows.Find(Pro_NewsKey);
                DataRow drV = Public.CNewsPublicFunction.GetNewsDataRow(newsAdd.NewsKey.ToString());

                dr.ItemArray = drV.ItemArray;
                dr.AcceptChanges();

            }
                        

            MessageBox.Show("修改公怖消息成功", "提示訊息");
            this.Close();
        }

        #region EditNews_Load
        private void EditNews_Load(object sender, EventArgs e)
        {
            //鎖定該筆資料
            Public.CommonFunctions.LockRecordAuth(sourceTableName, Properties.Settings.Default.WorkerKEY, "NID=" + Pro_NewsKey);

            this.newsTypeTableAdapter.Fill(this.dataSet_News.NewsType);

            DB_NewsTModel newsEdit = new DB_NewsTModel();
            DB_NewsTModel.ReadOne(Pro_NewsKey, ref newsEdit);

            comboBox_NewsTypeID.SelectedValue = newsEdit.NewsTypeKey;
            txt_NewsContent.Text = newsEdit.NewsContent;
            txt_NewsSubject.Text = newsEdit.NewsSubject;

        } 
        #endregion

        private void EditNews_FormClosed(object sender, FormClosedEventArgs e)
        {
            //解除鎖定該筆資料
            Public.CommonFunctions.NuLockRecordAuth(sourceTableName, Properties.Settings.Default.WorkerKEY);
        }
    }
}
