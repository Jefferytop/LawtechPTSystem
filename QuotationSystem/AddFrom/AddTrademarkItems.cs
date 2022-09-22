using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystem.AddFrom
{
    public partial class AddTrademarkItems : Form
    {
        public AddTrademarkItems()
        {
            InitializeComponent();
        }

        private int iTMClassID = -1;
        /// <summary>
        /// 商標類別ID
        /// </summary>
        public int TMClassID
        {
            get { return iTMClassID; }
            set { iTMClassID = value; }
        }


        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            if (txt_SerialNo.Text != "" && txt_IndicationOfGoods_En.Text != "" && txt_BasicNo.Text!="")
            {
                Public.CTrademarkItems Items = new Public.CTrademarkItems();
                Items.SerialNo = txt_SerialNo.Text;
                Items.TMClassID = iTMClassID;
                Items.BasicNo = txt_BasicNo.Text;
                Items.IndicationOfGoods_En = txt_IndicationOfGoods_En.Text;
                Items.IndicationOfGoods_CHT = txt_IndicationOfGoods_CHT.Text;
                Items.IndicationOfGoods_CHS = txt_IndicationOfGoods_CHS.Text;
                Items.Create();

                Public.PublicForm Forms = new Public.PublicForm();

                DataTable dt = Forms.TrademarkClassificationMF.GetTrademarkItemsT;

                DataRow dr = dt.NewRow();
                dr["SerialNo"] = Items.SerialNo;
                dr["BasicNo"] = Items.BasicNo;
                dr["IndicationOfGoods_En"] = Items.IndicationOfGoods_En;
                dr["IndicationOfGoods_CHT"] = Items.IndicationOfGoods_CHT;
                dr["IndicationOfGoods_CHS"] = Items.IndicationOfGoods_CHS;
                dr["TMItemsID"] = Items.TMItemsID;
                dr["TMClassID"] = Items.TMClassID;
                dt.Rows.Add(dr);
                dt.AcceptChanges();

                MessageBox.Show("新增成功");
                this.Close();
            }
            else
            {
                MessageBox.Show("序號、商品基本碼、商品名稱不得為空白，請輸入序號、商品基本碼、商品名稱");
                return;
            }
        }
    }
}
