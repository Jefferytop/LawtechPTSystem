using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LawtechPTSystem.AddFrom
{
    public partial class AddAccountingCompany : Form
    {
        public AddAccountingCompany()
        {
            InitializeComponent();
        }

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddAccountingCompany_Load(object sender, EventArgs e)
        {
            srotMax();
        }

        public void srotMax()
        {
           int iMaxSort= Public.Utility.GetMaxSort("AcountingFirmT");
            numericUpDown_Sort.Value = decimal.Parse(iMaxSort.ToString());
        }


        private void but_OK_Click(object sender, EventArgs e)
        {
            

            if (txt_AcountingFirmName.Text == "")
            {
                MessageBox.Show("請輸入「入帳公司名稱」  ");
                return;
            }

            Public.CAcountingFirmT Add = new Public.CAcountingFirmT();
            Add.AcountingFirmName = txt_AcountingFirmName.Text;
            Add.Sort = int.Parse(numericUpDown_Sort.Value.ToString());
            Add.IsEnable = chb_IsEnable.Checked;
            Add.LogoUrl = txt_LogoUrl.Text.Trim();
            Add.Creator = Properties.Settings.Default.WorkerName;
            Add.Create();

            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.AccountingCompany != null)
            {
                DataRow dr = Forms.AccountingCompany.AcountingFirmT.NewRow();
                DataRow drV = Public.CAccountingPublicFunction.GetAcountingFirmTDataRow(Add.AcountingFirmKey.ToString());
                dr.ItemArray = drV.ItemArray;
                Forms.AccountingCompany.AcountingFirmT.Rows.Add(dr);
                dr.AcceptChanges();
            }

            MessageBox.Show("新增成功\r\n入帳公司名稱：" + Add.AcountingFirmName);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void linkLabel_OpenLogo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_LogoUrl.Text.Trim()))
            {
                System.Diagnostics.Process.Start(txt_LogoUrl.Text.Trim());
            }
            else {
                txt_LogoUrl.Focus();
                MessageBox.Show("請輸入Logo 路徑");
            }
           
        }
    }
}
