using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.AddFrom
{
    public partial class AddNews : Form
    {
        public AddNews()
        {
            InitializeComponent();
        }

        private void AddNews_Load(object sender, EventArgs e)
        {
            
            this.newsTypeTableAdapter.Fill(this.dataSet_News.NewsType);

        }

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
            newsAdd.NewsContent = txt_NewsContent.Text;
            newsAdd.NewsSubject = txt_NewsSubject.Text;
            if (comboBox_NewsTypeID.SelectedValue != null)
            {
                newsAdd.NewsTypeKey = (int)comboBox_NewsTypeID.SelectedValue;
            }
            newsAdd.Creator = Properties.Settings.Default.WorkerName;
            object obj=newsAdd.Create();


            Public.PublicForm Forms = new Public.PublicForm();          
           
            if (Forms.News != null)
            {
                DataRow dr = Forms.News.DT_News.NewRow();
                DataRow drV = Public.CNewsPublicFunction.GetNewsDataRow(newsAdd.NewsKey.ToString());
                dr.ItemArray = drV.ItemArray;
                Forms.News.DT_News.Rows.Add(dr);

            }

            MessageBox.Show("新增公佈消息成功,\r\n主旨：" + newsAdd.NewsSubject, "提示訊息");
            this.Close();
        }

        #region AddNews_KeyDown
        private void AddNews_KeyDown(object sender, KeyEventArgs e)
        {
            Public.Utility.ControlTab(e);
        }
        #endregion
    }
}
