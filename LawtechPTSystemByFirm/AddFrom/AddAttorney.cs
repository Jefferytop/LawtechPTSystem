using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.AddFrom
{
    public partial class AddAttorney : Form
    {
        public AddAttorney()
        {
            InitializeComponent();
        }

        private string strCountry = "";
        /// <summary>
        /// 國別
        /// </summary>
        public string Country
        {
            get { return strCountry; }
            set { strCountry = value; }
        }


        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddAttorney_Load(object sender, EventArgs e)
        {           

            this.countryTTableAdapter.Fill(this.qS_DataSet.CountryT);
            if (Country.Trim() != "")
            {
                Combo_Country.SelectedValue = Country;
            }
            else {
                Combo_Country.SelectedIndex = 0;
            }

            numericUpDown_SN.Value = Public.Utility.GetMaxSort("AttorneyT", "Sort");
        }

        private void but_OK_Click(object sender, EventArgs e)
        {
            if (txt_AttorneySymbol.Text == "")
            {
                MessageBox.Show("請輸入事務所代碼");
                return;
            }

            if (txt_AttorneyFirm.Text == "")
            {
                MessageBox.Show("請輸入事務所名稱");
                return;
            }

            Public.CAttorney addAtt = new LawtechPTSystemByFirm.Public.CAttorney();

            addAtt.AttorneySymbol = txt_AttorneySymbol.Text;
            addAtt.AttorneyFirm = txt_AttorneyFirm.Text;
            addAtt.Addr = txt_Addr.Text;
            addAtt.Bank = txt_Bank.Text;
            addAtt.BankAccount = txt_BankAccount.Text;
            addAtt.BankAccountNo = txt_BankAccountNo.Text;
            if (Combo_Country.SelectedValue != null)
            {
                addAtt.CountrySymbol = Combo_Country.SelectedValue.ToString();
            }
            addAtt.FAX = txt_FAX.Text;
            addAtt.ID = txt_ID.Text;
            if (Combo_MotherAttorney.SelectedValue != null)
            {
                addAtt.MotherAttorney = (int)Combo_MotherAttorney.SelectedValue;
            }
            addAtt.Payment = txt_payment.Text;
            addAtt.Principal = txt_Principal.Text;
            addAtt.Remark = txt_Remark.Text;
            addAtt.TEL = txt_TEL.Text;
            addAtt.Email = txt_email.Text;
            addAtt.WebSite = txt_WebSite.Text;
            addAtt.Sort = int.Parse(numericUpDown_SN.Value.ToString());
           object obj= addAtt.Create();
            MessageBox.Show(string.Format("新增成功  {0}-{1}", addAtt.AttorneySymbol, addAtt.AttorneyFirm));
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void AddAttorney_KeyDown(object sender, KeyEventArgs e)
        {
            Public.Utility.ControlTab(e);
        }

     
    }
}