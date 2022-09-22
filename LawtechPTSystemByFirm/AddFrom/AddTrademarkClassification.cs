using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.AddFrom
{
    public partial class AddTrademarkClassification : Form
    {
        public AddTrademarkClassification()
        {
            InitializeComponent();
        }
        private string sCountry = "" ;
        /// <summary>
        /// 國別
        /// </summary>
        public string Country
        {
            get { return sCountry; }
            set { sCountry = value; }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            if (txtClassName.Text != "")
            {
                Public.CTrademarkClassification Classificatio = new LawtechPTSystemByFirm.Public.CTrademarkClassification();
                Classificatio.CountrySymbol = sCountry;
                Classificatio.Sort = int.Parse(numericUpDown_sort.Value.ToString());
                Classificatio.ClassName = txtClassName.Text;
                Classificatio.ClassDescript = txt_ClassDescript.Text;
                Classificatio.ClassDescript_En = txt_ClassDescript_En.Text;
                Classificatio.Create();

                Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

                DataTable dt = Forms.TrademarkClassificationMF.GetTrademarkClassificationT;

                DataRow dr = dt.NewRow();
                dr["Sort"] = Classificatio.Sort;
                dr["ClassName"] = Classificatio.ClassName;
                dr["ClassDescript"] = Classificatio.ClassDescript;
                dr["ClassDescript_En"] = Classificatio.ClassDescript_En;
                dr["CountrySymbol"] = Classificatio.CountrySymbol;
                dr["TMClassID"] = Classificatio.TMClassID;
                dt.Rows.Add(dr);
                dt.AcceptChanges();

                MessageBox.Show("新增成功");
                this.Close();
            }
            else
            {
                MessageBox.Show("類別名稱不得為空白，請輸入類別名稱");
                return;
            }
        }

        private void AddTrademarkClassification_Load(object sender, EventArgs e)
        {
            numericUpDown_sort.Value = Public.Utility.GetMaxSort("TrademarkClassificationT");
        }

        private void AddTrademarkClassification_KeyDown(object sender, KeyEventArgs e)
        {
            Public.Utility.ControlTab(e);
        }
    }
}
