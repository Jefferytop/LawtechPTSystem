using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystem.US
{
    public partial class SelectTrademarkClassification : Form
    {
        public SelectTrademarkClassification()
        {
            InitializeComponent();
        }

        private string strCountrySymbol = "";
        /// <summary>
        /// 國別
        /// </summary>
        public string property_CountrySymbol
        {
            get { return strCountrySymbol; }
            set { strCountrySymbol = value; }
        }

        private string strCountrySymbolName = "";
        public string property_CountrySymbolName
        {
            get { return strCountrySymbolName; }
            set { strCountrySymbolName = value; }
        }

        private DataTable dt_TrademarkClass;
        /// <summary>
        /// 所選取的商標分類資料表
        /// </summary>
        public DataTable Dt_TrademarkClass
        {
            get { return dt_TrademarkClass; }
            set { dt_TrademarkClass = value; }
        }

        private bool bIsChange = false;
        /// <summary>
        /// 是否變更
        /// </summary>
        public bool IsChange
        {
            get { return bIsChange; }
            set { bIsChange = value; }
        }



        private void but_Cancel_Click(object sender, EventArgs e)
        {
            IsChange = false;
            this.Close();
        }

        private void SelectTrademarkClassification_Load(object sender, EventArgs e)
        {

            if (dt_TrademarkClass == null)
            {
                dt_TrademarkClass = new DataTable();
                dt_TrademarkClass.Columns.Add("TMClassID", typeof(int));
                dt_TrademarkClass.Columns.Add("ClassName", typeof(string));
                dt_TrademarkClass.Columns.Add("ClassDescript", typeof(string));
                DataColumn[] pk={dt_TrademarkClass.Columns["TMClassID"]} ;
                dt_TrademarkClass.PrimaryKey = pk;

                dataGridView2.DataSource = dt_TrademarkClass;
            }

            lab_Country.Text = property_CountrySymbolName;

            trademarkClassificationTTableAdapter.Fill(this.dataSet_TM.TrademarkClassificationT, property_CountrySymbol);
        }

        public void CreateDatatable()
        {
            if (dt_TrademarkClass == null)
            {
                dt_TrademarkClass = new DataTable();
                dt_TrademarkClass.Columns.Add("TMClassID", typeof(int));
                dt_TrademarkClass.Columns.Add("ClassName", typeof(string));
                dt_TrademarkClass.Columns.Add("ClassDescript", typeof(string));
                DataColumn[] pk = { dt_TrademarkClass.Columns["TMClassID"] };
                dt_TrademarkClass.PrimaryKey = pk;

                dataGridView2.DataSource = dt_TrademarkClass;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IsChange = true;
            if (dt_TrademarkClass.Rows.Count > 0)
            {
                dt_TrademarkClass.Rows.Clear();
            }
        }

        private void but_AddClass_Click(object sender, EventArgs e)
        {
            IsChange = true;
            for (int iRow = 0; iRow < dataGridView1.Rows.Count; iRow++)
            {
                if ((bool)dataGridView1.Rows[iRow].Cells["Column_Select"].FormattedValue)
                {
                  DataRow dr=  dt_TrademarkClass.NewRow();
                  dr["TMClassID"] = (int)dataGridView1.Rows[iRow].Cells["TMClassID"].Value;
                  dr["ClassName"] = dataGridView1.Rows[iRow].Cells["ClassName"].Value;
                  dr["ClassDescript"] = dataGridView1.Rows[iRow].Cells["ClassDescript"].Value;
                  try
                  {
                      dt_TrademarkClass.Rows.Add(dr);
                  }
                  catch
                  { }

                }
            }
        }

        private void but_RemoveClass_Click(object sender, EventArgs e)
        {
            IsChange = true;
            for (int iRow = 0; iRow < dataGridView2.Rows.Count; iRow++)
            {
                if ((bool)dataGridView2.Rows[iRow].Cells["Check"].FormattedValue)
                {
                    dt_TrademarkClass.Rows.Remove(dt_TrademarkClass.Rows[iRow]);
                    iRow --;
                }
            }
        }

        private void but_OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
