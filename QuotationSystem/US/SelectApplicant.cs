using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystem.US
{
    /// <summary>
    /// 選取申請人
    /// </summary>
    public partial class SelectApplicant : Form
    {
        public SelectApplicant()
        {
            InitializeComponent();
            applicantT_DropDataGridView.AutoGenerateColumns = false;
            dataGridView1.AutoGenerateColumns = false;
            Public.DynamicGridViewColumn.GetGridColum(ref applicantT_DropDataGridView);

            //Public.DynamicGridViewColumn.GetGridColum(ref dataGridView1);
        }

        DataTable dtApplicant = new DataTable();

        private string strApplicantName = "";
        /// <summary>
        /// 申請人名稱(串接) ';'
        /// </summary>
        public string ApplicantNames
        {
            get { return strApplicantName; }
            set { strApplicantName = value; }
        }

        private string strApplicantKey = "";
        /// <summary>
        /// 申請人Key(串接) ','
        /// </summary>
        public string ApplicantKeys
        {
            get { return strApplicantKey; }
            set { strApplicantKey = value; }
        }


        private void SelectApplicant_Load(object sender, EventArgs e)
        {
            
            this.applicantT_DropTableAdapter.Fill(this.qS_DataSet.ApplicantT_Drop);
            comboBox_SelectMode.SelectedIndex = 0;
            InitApplicant();

            if (ApplicantKeys != "")
            {
                string[] strApplicantKeys = ApplicantKeys.Split(',');
                string[] strApplicantNames = ApplicantNames.Split(';');
                for (int iCount = 0; iCount < strApplicantKeys.Length; iCount++)
                {
                    if (strApplicantKeys[iCount] != "")
                    {
                        DataRow dr = dtApplicant.NewRow();
                        dr["ApplicantName"] = strApplicantNames[iCount].Trim();
                        dr["ApplicantKey"] =int.Parse( strApplicantKeys[iCount].Trim()) ;
                        dtApplicant.Rows.Add(dr);
                    }
                }
            }           
            dataGridView1.DataSource = dtApplicant;
        }

        #region 申請人資料表
        private void InitApplicant()
        {
            dtApplicant.Columns.Add("ApplicantName", typeof(string));
            dtApplicant.Columns.Add("ApplicantKey", typeof(int));
            DataColumn[] PK = new DataColumn[1] { dtApplicant.Columns["ApplicantKey"] };

            dtApplicant.PrimaryKey = PK;

        }
        #endregion

        private void comboBox_SelectMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SearchName = "";
            string strApp = "";
            switch (comboBox_app.Text)
            { 
                case "客戶編號":
                    strApp = "ApplicantSymbol";
                    break;
                case "公司名稱":
                    strApp = "ApplicantName";
                    break;
                default:
                    strApp = "ApplicantSymbol";
                    break;
            }

            if (txt_SearchName.Text != "")
            {
                if (comboBox_SelectMode.Text != "全部")
                {
                    SearchName = " and " + strApp + " like '%" + txt_SearchName.Text + "%'";
                }
                else
                {
                    SearchName = strApp+" like '%" + txt_SearchName.Text + "%'";
                }
            }

            switch (comboBox_SelectMode.Text)
            {
                case "全部":
                    applicantTDropBindingSource.Filter =  SearchName;
                    break;
                case "專利客戶":
                    applicantTDropBindingSource.Filter = " P='True' " + SearchName;
                    break;
                case "商標客戶":
                    applicantTDropBindingSource.Filter = " T='True' " + SearchName;
                    break;
                case "法務客戶":
                    applicantTDropBindingSource.Filter = " L='True' " + SearchName;
                    break;
            }
        }

        private void applicantT_DropDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (applicantT_DropDataGridView.CurrentRow != null)
            {
                try
                {
                    DataRow dr = dtApplicant.NewRow();
                    dr["ApplicantKey"] = (int)applicantT_DropDataGridView.CurrentRow.Cells["ApplicantKey"].Value;
                    dr["ApplicantName"] = applicantT_DropDataGridView.CurrentRow.Cells["ApplicantName"].Value.ToString().Trim();
                    dtApplicant.Rows.Add(dr);
                }
                catch
                {
                    //string ss = "";
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
            }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            StringBuilder sbApplicantNames = new StringBuilder();
            StringBuilder sbApplicantKey = new StringBuilder();

            for (int iRow = 0; iRow < dataGridView1.Rows.Count; iRow++)
            {
                if (sbApplicantNames.ToString().Length > 0)
                {
                    sbApplicantNames.Append(";");
                }
                sbApplicantNames.Append(dataGridView1.Rows[iRow].Cells["ApplicantName_Select"].Value.ToString());

                if (sbApplicantKey.ToString().Length > 0)
                {
                    sbApplicantKey.Append(",");
                }
                sbApplicantKey.Append(dataGridView1.Rows[iRow].Cells["ApplicantKey_Select"].Value.ToString());

            }

            ApplicantNames = sbApplicantNames.ToString();
            ApplicantKeys = sbApplicantKey.ToString();

                this.Close();
        }

        private void txt_SearchName_TextChanged(object sender, EventArgs e)
        {
            comboBox_SelectMode_SelectedIndexChanged(null,null);
        }

        private void but_Search_Click(object sender, EventArgs e)
        {

        }

         
    }
}
