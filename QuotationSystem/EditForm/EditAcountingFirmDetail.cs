using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.EditForm
{
    public partial class EditAcountingFirmDetail : Form
    {
        public EditAcountingFirmDetail()
        {
            InitializeComponent();
        }

        public int ProAcountingBankKey
        {
            get; set;
        }

        private void AddAcountingFirmDetail_Load(object sender, EventArgs e)
        {
            Public.CAcountingFirmDetailT Edit = new Public.CAcountingFirmDetailT();
            Public.CAcountingFirmDetailT.ReadOne(ProAcountingBankKey, ref Edit);
            numericUpDown_Sort.Value = Edit.Sort.HasValue ? Edit.Sort.Value : 0;
            txt_BankName.Text = Edit.BankName;
            txt_AccountName.Text = Edit.AccountName;
            txt_BankAccount.Text = Edit.BankAccount;
            chb_IsEnable.Checked = Edit.IsEnable.HasValue ? Edit.IsEnable.Value : false;
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

            Public.CAcountingFirmDetailT Edit = new Public.CAcountingFirmDetailT();
            Public.CAcountingFirmDetailT.ReadOne(ProAcountingBankKey, ref Edit);
            Edit.BankName = txt_BankName.Text;
            Edit.AccountName = txt_AccountName.Text;
            Edit.BankAccount = txt_BankAccount.Text;
            Edit.Sort = int.Parse(numericUpDown_Sort.Value.ToString());
            Edit.IsEnable = chb_IsEnable.Checked;
            Edit.LastModifyWorker = Properties.Settings.Default.WorkerName;
            Edit.Update();

            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.AccountingCompany != null)
            {
                DataRow dr = Forms.AccountingCompany.AcountingFirmDetailT.Rows.Find(Edit.AcountingBankKey);
                DataRow drV = Public.CAccountingPublicFunction.GetAcountingFirmDetailTDataRow(Edit.AcountingBankKey.ToString());
                dr.ItemArray = drV.ItemArray;               
                dr.AcceptChanges();
            }

            MessageBox.Show("編輯成功\r\n帳戶名稱：" + Edit.BankName+"-"+ Edit.BankAccount);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
