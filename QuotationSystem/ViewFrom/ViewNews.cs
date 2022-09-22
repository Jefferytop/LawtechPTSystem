using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.ViewFrom
{
    public partial class ViewNews : Form
    {
        public ViewNews()
        {
            InitializeComponent();
        }

        private int iWorkerID = -1;
        /// <summary>
        /// 登入者ID
        /// </summary>
        public int WorkerID
        {
            get { return iWorkerID; }
            set { iWorkerID = value; }
        }

        public int iNewsKey
        {
            get;set;
        }

        private DataTable dt_News = new DataTable();
        public DataTable DT_News
        {
            get { return dt_News; }
        }

        private void ViewNews_Load(object sender, EventArgs e)
        {
            //登入者
            iWorkerID = Properties.Settings.Default.WorkerKEY;

            DataRow dr = Public.CNewsPublicFunction.GetNewsDataRow(iNewsKey.ToString());
            GetNews(dr);           

            GetNewsWorker();

            if (dt_News.Rows.Count <= 0)
            {
                linkLab_Next.Visible = false;
            }
            else {
                linkLab_Next.Visible = true;
            }

        }

        /// <summary>
        /// 取得登入者的公怖欄資訊
        /// </summary>
        public void GetNewsWorker()
        {
            string strSQL = string.Format(" NewsKey not in(select NewsKey from NewsWorkerT where WorkerKey={0}) ", iWorkerID);
            Public.CNewsPublicFunction.GetNewsList(strSQL, ref dt_News);
           
        }

        /// <summary>
        /// 將資料呈現
        /// </summary>
        /// <param name="dr"></param>
        public void GetNews(DataRow dr) {
            txt_TypeName.Text = dr["TypeName"].ToString();
            txt_NewsContent.Text = dr["NewsContent"].ToString();
            txt_NewsSubject.Text = dr["NewsSubject"].ToString();
            txt_WorkerName.Text = dr["Creator"].ToString();
            DateTime dtCreateDateTime;
            bool isCreateDateTime = DateTime.TryParse(dr["CreateDateTime"].ToString(), out dtCreateDateTime);
            if (isCreateDateTime)
            {
                txt_CreateDate.Text = dtCreateDateTime.ToString("yyyy-MM-dd HH:mm:ss");
            }
            else {
                txt_CreateDate.Text = "";
            }

            //檢查是否有閱讀過
            Public.CNewsWorkerT nw = new Public.CNewsWorkerT();
            string str = string.Format("NewsKey={0} and WorkerKey={1}",dr["NewsKey"].ToString(), iWorkerID.ToString());
            Public.CNewsWorkerT.ReadOne(str, ref nw);
            if (nw.NewsWorkerKey == 0)
            {
                Public.CNewsWorkerT nwAdd = new Public.CNewsWorkerT();
                nwAdd.WorkerKey = iWorkerID;
                nwAdd.NewsKey =int.Parse( dr["NewsKey"].ToString());
                nwAdd.Create();
            }
        }


        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLab_Next_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DataRow dr = dt_News.Rows[0];
            GetNews(dr);

            dt_News.Rows.Remove(dr);

            if (dt_News.Rows.Count > 0)
            {
                 linkLab_Next.Visible = true;
            }
                else {
                linkLab_Next.Visible = false;
            }
        }


    }
}
