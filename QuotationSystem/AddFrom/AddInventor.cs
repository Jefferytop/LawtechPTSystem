using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.AddFrom
{
    public partial class AddInventor : Form
    {
        public AddInventor()
        {
            InitializeComponent();
        }
        private int iApplicantKey = -1;
        /// <summary>
        /// 申請人Key值
        /// </summary>
        public int ApplicantKey
        {
            get { return iApplicantKey; }
            set { iApplicantKey = value; }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region 國籍資料  private void CountryCitizenshipTextBox()
        /// <summary>
        /// 國籍資料
        /// </summary>
        private void CountryCitizenshipTextBox()
        {
            DataTable dtCountryCitizenship = new DataTable();
            Public.CCountryPublicFunction.GetCountryCitizenshipAllList(ref dtCountryCitizenship);
            AutoCompleteStringCollection acsc = new AutoCompleteStringCollection();
            foreach (DataRow dr in dtCountryCitizenship.Rows)
            {
                acsc.Add(dr["CountrySymbol"].ToString());
            }
            txt_InventorCountryCitizenship.AutoCompleteMode = AutoCompleteMode.Suggest;
            txt_InventorCountryCitizenship.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_InventorCountryCitizenship.AutoCompleteCustomSource = acsc;
        }
        #endregion

        private void butOK_Click(object sender, EventArgs e)
        {
            if (txt_InventorName.Text.Trim() == "")
            {
                MessageBox.Show("發明人姓名不得為空白，請確認", "提示訊息");
                return;
            }
            Public.CInventor add = new Public.CInventor();
            add.ApplicantKey = ApplicantKey;
            add.InventorCountryCitizenship = txt_InventorCountryCitizenship.Text;
            add.InventorName = txt_InventorName.Text;
            add.FamilyName = txt_FamilyName.Text;
            add.GivenName = txt_GivenName.Text;
            add.InventorID = txt_ID.Text;
            add.FullEnName = txt_FullEnName.Text;
            add.Remark = txt_Remark.Text;
            add.Address = txt_Address.Text;
            add.Creator = Properties.Settings.Default.WorkerName;
            add.Create();

            Public.PublicForm Forms = new Public.PublicForm();
            if (Forms.ApplicantList != null && Forms.ApplicantList.DT_Inventor != null)
            {
                DataRow dr = Forms.ApplicantList.DT_Inventor.NewRow();
                DataRow drV = Public.CApplicantPublicFunction.GetInventorDataRow(add.InventorKey.ToString());
                dr.ItemArray = drV.ItemArray;
                Forms.ApplicantList.DT_Inventor.Rows.Add(dr);
                dr.AcceptChanges();
            }
            MessageBox.Show("新增發明人成功  " + add.InventorName, "提示訊息");
            this.Close();
        }

        private void AddInventor_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    SendKeys.Send("{TAB}");
                    break;
                case Keys.PageDown:
                    SendKeys.Send("{TAB}");
                    break;
                case Keys.PageUp:
                    SendKeys.Send("+{TAB}");
                    break;
            }
        }

        private void txt_FamilyName_TextChanged(object sender, EventArgs e)
        {
            txt_FullEnName.Text = txt_FamilyName.Text + " " + txt_GivenName.Text;
        }

        private void AddInventor_Load(object sender, EventArgs e)
        {
            CountryCitizenshipTextBox();
        }
    }
}
