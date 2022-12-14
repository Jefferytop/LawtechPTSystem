using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.EditForm
{
    public partial class EditAccountingCompany : Form
    {
        public EditAccountingCompany()
        {
            InitializeComponent();
        }

        public int ProAcountingFirmKey
        {
            get;set;
        }

        private void EditAccountingCompany_Load(object sender, EventArgs e)
        {
            Public.CAcountingFirmT Edit = new Public.CAcountingFirmT();
            Public.CAcountingFirmT.ReadOne(ProAcountingFirmKey, ref Edit);
            numericUpDown_Sort.Value = Edit.Sort.HasValue ? Edit.Sort.Value : 0;
            txt_AcountingFirmName.Text = Edit.AcountingFirmName;
            chb_IsEnable.Checked = Edit.IsEnable.HasValue ? Edit.IsEnable.Value : false;
            txt_LogoUrl.Text = Edit.LogoUrl;
        }

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void but_OK_Click(object sender, EventArgs e)
        {
            if (txt_AcountingFirmName.Text == "")
            {
                MessageBox.Show("請輸入「入帳公司名稱」  ");
                return;
            }

            Public.CAcountingFirmT Edit = new Public.CAcountingFirmT();
            Public.CAcountingFirmT.ReadOne(ProAcountingFirmKey,ref Edit);
            Edit.AcountingFirmName = txt_AcountingFirmName.Text;
            Edit.Sort = int.Parse(numericUpDown_Sort.Value.ToString());
            Edit.IsEnable = chb_IsEnable.Checked;
            Edit.LogoUrl = txt_LogoUrl.Text.Trim();

            Edit.LastModifyWorker = Properties.Settings.Default.WorkerName;
            Edit.Update();

            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.AccountingCompany != null)
            {
                DataRow dr = Forms.AccountingCompany.AcountingFirmT.Rows.Find(Edit.AcountingFirmKey);
                DataRow drV = Public.CAccountingPublicFunction.GetAcountingFirmTDataRow(Edit.AcountingFirmKey.ToString());
                dr.ItemArray = drV.ItemArray;             
                dr.AcceptChanges();
            }

            MessageBox.Show("編輯成功\r\n入帳公司名稱：" + Edit.AcountingFirmName );
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void linkLabel_OpenLogo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_LogoUrl.Text.Trim()))
            {
                System.Diagnostics.Process.Start(txt_LogoUrl.Text.Trim());
            }
            else
            {
                txt_LogoUrl.Focus();
                MessageBox.Show("請輸入Logo 路徑");
            }
        }



    }
}
