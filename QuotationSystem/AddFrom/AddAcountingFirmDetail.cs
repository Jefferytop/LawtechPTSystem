using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.AddFrom
{
    public partial class AddAcountingFirmDetail : Form
    {
        public AddAcountingFirmDetail()
        {
            InitializeComponent();
        }

        public int ProAcountingFirmKey
        {
            get; set;
        }

        private void AddAcountingFirmDetail_Load(object sender, EventArgs e)
        {
            srotMax();
        }

        public void srotMax()
        {
            int iMaxSort = Public.Utility.GetMaxSort("AcountingFirmDetailT",sqlQuery: "AcountingFirmKey="+ ProAcountingFirmKey.ToString());
            numericUpDown_Sort.Value = decimal.Parse(iMaxSort.ToString());
        }

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void but_OK_Click(object sender, EventArgs e)
        {
            if (txt_BankName.Text == "")
            {
                MessageBox.Show("請輸入「銀行名稱」  ");
                return;
            }

            Public.CAcountingFirmDetailT Add = new Public.CAcountingFirmDetailT();
            Add.AcountingFirmKey = ProAcountingFirmKey;
            Add.BankName = txt_BankName.Text;
            Add.AccountName = txt_AccountName.Text;
            Add.BankAccount = txt_BankAccount.Text;
            Add.Sort = int.Parse(numericUpDown_Sort.Value.ToString());
            Add.IsEnable = chb_IsEnable.Checked;
            Add.Creator = Properties.Settings.Default.WorkerName;
            Add.Create();

            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.AccountingCompany != null)
            {
                DataRow dr = Forms.AccountingCompany.AcountingFirmDetailT.NewRow();
                DataRow drV = Public.CAccountingPublicFunction.GetAcountingFirmDetailTDataRow(Add.AcountingBankKey.ToString());
                dr.ItemArray = drV.ItemArray;
                Forms.AccountingCompany.AcountingFirmDetailT.Rows.Add(dr);
                dr.AcceptChanges();
            }

            MessageBox.Show("新增成功\r\n帳戶名稱：" + Add.BankName+"-"+Add.BankAccount);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
