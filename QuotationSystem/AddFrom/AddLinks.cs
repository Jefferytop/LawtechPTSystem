using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystem.AddFrom
{
    public partial class AddLinks : Form
    {
        public AddLinks()
        {
            InitializeComponent();
        }

        #region butCancel_Click
        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        #endregion

        #region butOK_Click
        private void butOK_Click(object sender, EventArgs e)
        {

            //必填欄位
            TextBox[] txtList = { txt_WebSiteName, txt_WebAddress };
            bool IsCheckTextBoxEmpty = Public.CommonFunctions.RequiredFieldsTextBoxIsEmpty(txtList);
            if (IsCheckTextBoxEmpty)
            {
                return;
            }


            Links_Model news = new Links_Model();

            news.Description = txt_Description.Text;
            news.WebAddress = txt_WebAddress.Text;
            news.WebSiteName = txt_WebSiteName.Text;
            news.Sort = int.Parse(numericUpDown_Sort.Value.ToString());
            if (comboBox_NewsTypeID.SelectedValue != null)
            {
                news.NewsTypeKey = (int)comboBox_NewsTypeID.SelectedValue;
            }
            news.Creator = Properties.Settings.Default.WorkerKEY;
            object obj=news.Create();


            Public.PublicForm Forms = new Public.PublicForm();
            DataRow dr = Forms.LinksMF.DT_Links.NewRow();
            dr["LinksKey"] = news.LinksKey;
            dr["Sort"] = news.Sort;
            dr["CreateDateTime"] =  DateTime.Now;
            dr["WebAddress"] = news.WebAddress;
            dr["WebSiteName"] = news.WebSiteName;
            dr["Description"] = news.Description;
            dr["NewsTypeKey"] = news.NewsTypeKey;
            dr["TypeName"] = comboBox_NewsTypeID.Text;
            dr["Creator"] = Properties.Settings.Default.WorkerName;

            Forms.LinksMF.DT_Links.Rows.Add(dr);
            Forms.LinksMF.DT_Links.AcceptChanges();

            MessageBox.Show("新增常用連結網址成功", "提示訊息");
            this.Close();
        } 
        #endregion

        #region AddLinks_Load
        private void AddLinks_Load(object sender, EventArgs e)
        {
           this.newsTypeTableAdapter.Fill(this.dataSet_News.NewsType);
           comboBox_NewsTypeID.SelectedIndex = 0;

           int iSort= Public.CommonFunctions.GetMaxSort("LinksT");
           numericUpDown_Sort.Value = iSort;
        } 
        #endregion
    }
}
