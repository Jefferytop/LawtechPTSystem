using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using H3Operator.DBHelper;

namespace LawtechPTSystem.US
{
    public partial class SearchMainByTM : UserControl
    {
        public SearchMainByTM()
        {
            InitializeComponent();
        }

        //private bool bStart = false;
        ///// <summary>
        ///// 是否已經被啟動
        ///// </summary>
        //public bool IsStart
        //{
        //    get { return bStart; }
        //    set { bStart = value; }
        //}

        private string strType = "TrademarkMF";
        /// <summary>
        /// 記錄使用的表單 Trademark,PATControlEvent
        /// </summary>        
        [Category("Custom"), DefaultValue("TrademarkMF"), Description("記錄使用的表單 TrademarkMF")]
        public string SearchType
        {
            get { return strType; }
            set { strType = value; }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.AutoCompleteCustomSource.Clear();
            SqlConnection conn = new SqlConnection(DBAccess.ConnectionListDefaultConnectionString);
            Public.CCombox Combox = (Public.CCombox)((System.Windows.Forms.ComboBox)(sender)).SelectedItem;
            SqlDataAdapter sAdapter = new SqlDataAdapter(Combox.strSQL, conn);
            DataTable dt = new DataTable();
            sAdapter.Fill(dt);

            switch (Combox.ListMode)
            {
                case 0:
                    comboBox2.AutoCompleteSource = AutoCompleteSource.None;
                    comboBox2.AutoCompleteMode = AutoCompleteMode.None;
                    comboBox2.DropDownStyle = ComboBoxStyle.Simple;
                    break;
                case 1:
                    comboBox2.DropDownStyle = ComboBoxStyle.DropDown;
                    comboBox2.AutoCompleteSource = AutoCompleteSource.ListItems;
                    comboBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    comboBox2.DataSource = dt;
                    comboBox2.DisplayMember = Combox.SelectString;
                    comboBox2.ValueMember = Combox.SelectValue;
                    comboBox2.Text = "";
                    break;
                case 2:
                    comboBox2.AutoCompleteSource = AutoCompleteSource.None;
                    comboBox2.AutoCompleteMode = AutoCompleteMode.None;
                    comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
                    comboBox2.DataSource = dt;
                    comboBox2.DisplayMember = Combox.SelectString;
                    comboBox2.ValueMember = Combox.SelectValue;
                    break;
            }



        }

        private void SearchMain_Load(object sender, EventArgs e)
        {


            SqlConnection conn = new SqlConnection(DBAccess.ConnectionListDefaultConnectionString);
            SqlDataAdapter sAdapter = new SqlDataAdapter("select * from TrademarkConditionT where Type='" + strType + "' order by Sort", conn);
            DataTable dt = new DataTable();
            sAdapter.Fill(dt);
            comboBox1.DisplayMember = "ShowString";
            comboBox1.ValueMember = "ValueString";

            comboBox1.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Public.CCombox Combox = new Public.CCombox();
                Combox.ShowString = dt.Rows[i]["DisplayData"].ToString();
                Combox.ValueString = dt.Rows[i]["ValueData"].ToString();
                Combox.strSQL = dt.Rows[i]["data"].ToString();
                Combox.ListMode = (int)dt.Rows[i]["Listmode"];
                Combox.SelectString = dt.Rows[i]["SelectString"].ToString();
                Combox.SelectValue = dt.Rows[i]["SelectValue"].ToString();

                if (dt.Rows[i]["DisplayData"].ToString() != "")
                    comboBox1.AutoCompleteCustomSource.Add(dt.Rows[i]["DisplayData"].ToString());

                comboBox1.Items.Add(Combox);
            }
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }

        }

        /// <summary>
        /// 取得TechnicalT的結構清單
        /// </summary>
        /// <param name="sourceData">來源資料表</param>
        /// <param name="destData">來的資料表</param>
        /// <param name="PID">TPID對應的key</param>
        private void GetItemList(DataTable sourceData, DataTable destData, string PID)
        {
            DataRow[] rows = sourceData.Select(string.Format("TPID = {0}", PID));
            for (int idx = 0; idx < rows.Length; idx++)
            {
                DataRow row = destData.NewRow();
                row["TID"] = rows[idx]["TID"];
                row["Name"] = rows[idx]["Name"];
                destData.Rows.Add(row);
                GetItemList(sourceData, destData, rows[idx]["TID"].ToString());
            }
        }

        //private void comboBox2_TextChanged(object sender, EventArgs e)
        //{

        //}
    }
}
