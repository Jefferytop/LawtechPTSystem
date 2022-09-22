using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystem.EditForm
{
    public partial class EditLinks : Form
    {
        public EditLinks()
        {
            InitializeComponent();
        }

        //來源資料表
        private string sourceTableName = "LinksT";

        private int iLinkKey = -1;
        /// <summary>
        /// 常用連結Key值
        /// </summary>
        public int ProLinkKey
        {
            get { return iLinkKey; }
            set { iLinkKey = value; }
        }

        #region EditLinks_Load
        private void EditLinks_Load(object sender, EventArgs e)
        {
            //鎖定該筆資料
            Public.CommonFunctions.LockRecordAuth(sourceTableName, Properties.Settings.Default.WorkerKEY, "LinksKey=" + ProLinkKey);


            this.newsTypeTableAdapter.Fill(this.dataSet_News.NewsType);

            Links_Model edit = new Links_Model();
            Links_Model.ReadOne(ProLinkKey, ref edit);

            comboBox_NewsTypeID.SelectedValue = edit.NewsTypeKey.HasValue ? edit.NewsTypeKey.Value : -1;
            txt_WebSiteName.Text = edit.WebSiteName;
            txt_WebAddress.Text = edit.WebAddress;
            txt_Description.Text = edit.Description;
            numericUpDown_Sort.Value = edit.Sort.HasValue ? edit.Sort.Value : 0;
        }
        #endregion

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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
            Links_Model edit = new Links_Model();
            Links_Model.ReadOne(ProLinkKey, ref edit);

            edit.Sort = int.Parse(numericUpDown_Sort.Value.ToString());
            edit.Description = txt_Description.Text;
            edit.WebAddress = txt_WebAddress.Text;
            edit.WebSiteName = txt_WebSiteName.Text;
            
            if (comboBox_NewsTypeID.SelectedValue != null)
            {
                edit.NewsTypeKey = (int)comboBox_NewsTypeID.SelectedValue;
            }
            else
            {
                edit.NewsTypeKey = null;
            }
            edit.LastModifyWorker = Properties.Settings.Default.WorkerKEY;

            edit.Update();


            Public.PublicForm Forms = new Public.PublicForm();
            DataRow dr = Forms.LinksMF.DT_Links.Rows.Find(ProLinkKey);

            dr["Sort"] = edit.Sort;

            if (edit.LastModifyDateTime.HasValue)
            {
                dr["LastModifyDateTime"] = edit.LastModifyDateTime.Value;
            }
            dr["WebAddress"] = edit.WebAddress;
            dr["WebSiteName"] = edit.WebSiteName;
            dr["Description"] = edit.Description;
            dr["NewsTypeKey"] = edit.NewsTypeKey;
            dr["TypeName"] = comboBox_NewsTypeID.Text;
            dr["LastModifyWorker"] = Properties.Settings.Default.WorkerName;


            Forms.LinksMF.DT_Links.AcceptChanges();

            MessageBox.Show("修改連結成功", "提示訊息");
            this.Close();
        } 
        #endregion

        private void EditLinks_FormClosed(object sender, FormClosedEventArgs e)
        {
            //鎖定該筆資料
            Public.CommonFunctions.NuLockRecordAuth(sourceTableName, Properties.Settings.Default.WorkerKEY);
        }
    }
}
