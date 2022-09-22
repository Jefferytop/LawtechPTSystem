using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.CopyForm
{
    public partial class CopyOfficeProperty : Form
    {
        public CopyOfficeProperty()
        {
            InitializeComponent();
        }

        private int iOfficePropertyID = -1;
        /// <summary>
        /// 所內財產清單 ID
        /// </summary>
        public int OfficePropertyID
        {
            get { return iOfficePropertyID; }
            set { iOfficePropertyID = value; }
        }


        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void but_OK_Click(object sender, EventArgs e)
        {
            if (txt_OfficePropertyName.Text.Trim() == "")
            {
                MessageBox.Show("【單位財產名稱】不得為空白", "提示訊息");
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
            DataRow dr = Forms.OfficePropertyMF.GetOfficeProperty.NewRow();

            //所內財產清單
            dr["OfficePropertyID"] = AddCOfficeProperty.OfficePropertyID;

            //財產編號
            dr["OfficePropertyNo"] = AddCOfficeProperty.OfficePropertyNo;

            //單位財產名稱
            dr["OfficePropertyName"] = AddCOfficeProperty.OfficePropertyName;

            //品項類型
            dr["OfficePropertyType"] = AddCOfficeProperty.OfficePropertyType;

            //所屬單位
            dr["Unit"] = AddCOfficeProperty.Unit;

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

        private void CopyOfficeProperty_Load(object sender, EventArgs e)
        {
            this.moneyTTableAdapter.Fill(this.dataSet_Drop.MoneyT);

            this.workerTAllTableAdapter.Fill(this.qS_DataSet.WorkerTAll);

            Public.COfficeProperty EditCOfficeProperty = new LawtechPTSystemByFirm.Public.COfficeProperty();
            Public.COfficeProperty.ReadOne(OfficePropertyID, ref EditCOfficeProperty);

            //財產編號
            //txt_OfficePropertyNo.Text = EditCOfficeProperty.OfficePropertyNo;

            //單位財產名稱
            txt_OfficePropertyName.Text = EditCOfficeProperty.OfficePropertyName;


            //品項類型
            comboBox_OfficePropertyType.Text = EditCOfficeProperty.OfficePropertyType;

            //所屬單位
            comboBox_Unit.Text = EditCOfficeProperty.Unit;

            //建檔時間
            if (EditCOfficeProperty.CreateDate.Value.Year > 1900)
            {
                mask_CreateDate.Text = EditCOfficeProperty.CreateDate.Value.ToString("yyyy/MM/dd");
            }
            else
            {
                mask_CreateDate.Text = "";
            }
            //購買時間
            if (EditCOfficeProperty.BuyDate.Value.Year > 1900)
            {
                mask_BuyDate.Text = EditCOfficeProperty.BuyDate.Value.ToString("yyyy/MM/dd");
            }
            else
            {
                mask_BuyDate.Text = "";
            }
            //保固時間
            txt_WarrantyTime.Text = EditCOfficeProperty.WarrantyTime;

            //購買金額
            numericUpDown_Amount.Value = EditCOfficeProperty.Amount.Value;

            //幣別
            cb_Currency.Text = EditCOfficeProperty.Currency;

            //當時匯率
            numericUpDown_ExchangeRate.Value = EditCOfficeProperty.ExchangeRate.Value;

            //合計NT
            numericUpDown_TotalNT.Value = EditCOfficeProperty.TotalNT.Value;

            //詳細規格
            txt_Specifications.Text = EditCOfficeProperty.Specifications;

            //功能說明
            txt_FunctionDescription.Text = EditCOfficeProperty.FunctionDescription;

            //發票號碼
            txt_InvoiceNumber.Text = EditCOfficeProperty.InvoiceNumber;

            //所在地
            cb_Location.Text = EditCOfficeProperty.Location;

            //目前保管人
            cb_Owner.Text = EditCOfficeProperty.Owner;

            //配件
            txt_Parts.Text = EditCOfficeProperty.Parts;

            //狀態(10.使用中 15.列管中 20.報修中 30.報廢)
            cb_Status.Text = EditCOfficeProperty.Status;

            //備註
            txt_Memo.Text = EditCOfficeProperty.Memo; 
        }

        private void numericUpDown_ExchangeRate_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown_TotalNT.Value = numericUpDown_ExchangeRate.Value * numericUpDown_Amount.Value;
        }

        private void cb_Currency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Currency.SelectedItem != null)
            {
                numericUpDown_ExchangeRate.Value = (decimal)((System.Data.DataRowView)(cb_Currency.SelectedItem)).Row["ToNT"];
            }
        }
    }
}
