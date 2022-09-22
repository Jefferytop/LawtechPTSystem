using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.AddFrom
{
    public partial class AddOfficeProperty : Form
    {
        public AddOfficeProperty()
        {
            InitializeComponent();
        }

        private void AddOfficeProperty_Load(object sender, EventArgs e)
        {
           
            this.moneyTTableAdapter.Fill(this.dataSet_Drop.MoneyT);
           
            this.workerTAllTableAdapter.Fill(this.qS_DataSet.WorkerTAll);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void but_OK_Click(object sender, EventArgs e)
        {
            if (txt_OfficePropertyName.Text.Trim() == "")
            {
                MessageBox.Show("【單位財產名稱】不得為空白","提示訊息");
                return;
            }

            Public.COfficeProperty AddCOfficeProperty = new Public.COfficeProperty();

            //財產編號
            AddCOfficeProperty.OfficePropertyNo = txt_OfficePropertyNo.Text;

            //單位財產名稱
            AddCOfficeProperty.OfficePropertyName = txt_OfficePropertyName.Text;

            //品項類型
            AddCOfficeProperty.OfficePropertyType = comboBox_OfficePropertyType.Text;

            //所屬單位
            AddCOfficeProperty.Unit = comboBox_Unit.Text;

            //建檔時間
            DateTime dtCreateDate;
            bool IsCreateDate = DateTime.TryParse(mask_CreateDate.Text, out dtCreateDate);
            if (IsCreateDate)
            {
                AddCOfficeProperty.CreateDate = dtCreateDate;
            }

            //購買時間
            DateTime dtBuyDate;
            bool IsBuyDate = DateTime.TryParse(mask_BuyDate.Text, out dtBuyDate);
            if (IsBuyDate)
            {
                AddCOfficeProperty.BuyDate = dtBuyDate;
            }

            //保固時間
            AddCOfficeProperty.WarrantyTime = txt_WarrantyTime.Text;

            //購買金額
            AddCOfficeProperty.Amount = numericUpDown_Amount.Value;

            //幣別
            AddCOfficeProperty.Currency = cb_Currency.Text;

            //當時匯率
            AddCOfficeProperty.ExchangeRate = numericUpDown_ExchangeRate.Value;

            //
            AddCOfficeProperty.TotalNT = numericUpDown_TotalNT.Value;

            //詳細規格
            AddCOfficeProperty.Specifications = txt_Specifications.Text;

            //功能說明
            AddCOfficeProperty.FunctionDescription = txt_FunctionDescription.Text;

            //發票號碼
            AddCOfficeProperty.InvoiceNumber = txt_InvoiceNumber.Text;

            //所在地
            AddCOfficeProperty.Location = cb_Location.Text;

            //目前保管人
            AddCOfficeProperty.Owner = cb_Owner.Text;

            //配件
            AddCOfficeProperty.Parts = txt_Parts.Text;

            //狀態(10.使用中 15.列管中 20.報修中 30.報廢)
            AddCOfficeProperty.Status = cb_Status.Text;

            //備註
            AddCOfficeProperty.Memo = txt_Memo.Text;

            //最後修改時間          
            AddCOfficeProperty.LastModifyDate = DateTime.Now;           

            //最後修改者
            AddCOfficeProperty.LastModifyWorker = Properties.Settings.Default.WorkerKEY;            

            AddCOfficeProperty.Create();

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
           DataRow dr= Forms.OfficePropertyMF.GetOfficeProperty.NewRow();

           //所內財產清單
           dr["OfficePropertyID"] = AddCOfficeProperty.OfficePropertyID;

           //品項類型
           dr["OfficePropertyType"] = AddCOfficeProperty.OfficePropertyType;

           //所屬單位
           dr["Unit"] = AddCOfficeProperty.Unit;

           //財產編號
           dr["OfficePropertyNo"] = AddCOfficeProperty.OfficePropertyNo;

           //單位財產名稱
           dr["OfficePropertyName"] = AddCOfficeProperty.OfficePropertyName;

           //建檔時間
           if (AddCOfficeProperty.CreateDate.Value.Year > 1900)
           {
               dr["CreateDate"] = AddCOfficeProperty.CreateDate;
           }

           //購買時間
           if (AddCOfficeProperty.BuyDate.Value.Year > 1900)
           {
               dr["BuyDate"] = AddCOfficeProperty.BuyDate;
           }

           //保固時間
           dr["WarrantyTime"] = AddCOfficeProperty.WarrantyTime;

           //購買金額
           dr["Amount"] = AddCOfficeProperty.Amount;

           //幣別
           dr["Currency"] = AddCOfficeProperty.Currency;

           //當時匯率
           dr["ExchangeRate"] = AddCOfficeProperty.ExchangeRate;

           //
           dr["TotalNT"] = AddCOfficeProperty.TotalNT;

           //詳細規格
           dr["Specifications"] = AddCOfficeProperty.Specifications;

           //功能說明
           dr["FunctionDescription"] = AddCOfficeProperty.FunctionDescription;

           //發票號碼
           dr["InvoiceNumber"] = AddCOfficeProperty.InvoiceNumber;

           //所在地
           dr["Location"] = AddCOfficeProperty.Location;

           //目前保管人
           dr["Owner"] = AddCOfficeProperty.Owner;

           //配件
           dr["Parts"] = AddCOfficeProperty.Parts;

           //狀態(10.使用中 15.列管中 20.報修中 30.報廢)
           dr["Status"] = AddCOfficeProperty.Status;

           //備註
           dr["Memo"] = AddCOfficeProperty.Memo;

           Forms.OfficePropertyMF.GetOfficeProperty.Rows.Add(dr);
           Forms.OfficePropertyMF.GetOfficeProperty.AcceptChanges();

           MessageBox.Show("新增成功", "提示訊息", MessageBoxButtons.OK);
           this.Close();
        }

        private void cb_Currency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Currency.SelectedItem != null)
            {
                numericUpDown_ExchangeRate.Value = (decimal)((System.Data.DataRowView)(cb_Currency.SelectedItem)).Row["ToNT"];
            }
        }

        private void numericUpDown_ExchangeRate_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown_TotalNT.Value = numericUpDown_ExchangeRate.Value * numericUpDown_Amount.Value;

        }

        private void mask_CreateDate_DoubleClick(object sender, EventArgs e)
        {
            MaskedTextBox mtb = (MaskedTextBox)sender;
            DateTime dt;
            bool IsSuccess = DateTime.TryParse(mtb.Text, out dt);
            if (!IsSuccess)
            {
                mtb.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }                
        }

        private void AddOfficeProperty_KeyDown(object sender, KeyEventArgs e)
        {
            Public.Utility.ControlTab(e);
        }
    }
}
