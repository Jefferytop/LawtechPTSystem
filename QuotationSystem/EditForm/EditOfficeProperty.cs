using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.EditForm
{
    public partial class EditOfficeProperty : Form
    {
        public EditOfficeProperty()
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


        private void EditOfficeProperty_Load(object sender, EventArgs e)
        {
            this.moneyTTableAdapter.Fill(this.dataSet_Drop.MoneyT);

            this.workerTAllTableAdapter.Fill(this.qS_DataSet.WorkerTAll);

            Public.COfficeProperty EditCOfficeProperty = new Public.COfficeProperty();
            Public.COfficeProperty.ReadOne(OfficePropertyID, ref EditCOfficeProperty);
            

            //財產編號
            txt_OfficePropertyNo.Text = EditCOfficeProperty.OfficePropertyNo;

            //單位財產名稱
            txt_OfficePropertyName.Text = EditCOfficeProperty.OfficePropertyName;

            //品項類型
            comboBox_OfficePropertyType.Text= EditCOfficeProperty.OfficePropertyType;

            //所屬單位
            comboBox_Unit.Text= EditCOfficeProperty.Unit ;

            //建檔時間
            mask_CreateDate.Text = EditCOfficeProperty.CreateDate.HasValue ? EditCOfficeProperty.CreateDate.Value.ToString("yyyy/MM/dd") : "";

            //購買時間
            mask_CreateDate.Text = EditCOfficeProperty.BuyDate.HasValue ? EditCOfficeProperty.BuyDate.Value.ToString("yyyy/MM/dd") : "";
           
            //保固時間
            txt_WarrantyTime.Text = EditCOfficeProperty.WarrantyTime;

            //購買金額
            numericUpDown_Amount.Value = EditCOfficeProperty.Amount.HasValue? EditCOfficeProperty.Amount.Value:0;

            //幣別
            cb_Currency.Text = EditCOfficeProperty.Currency;

            //當時匯率
            numericUpDown_ExchangeRate.Value = EditCOfficeProperty.ExchangeRate.HasValue? EditCOfficeProperty.ExchangeRate.Value:0;

            //合計NT
            numericUpDown_TotalNT.Value = EditCOfficeProperty.TotalNT.HasValue? EditCOfficeProperty.TotalNT.Value:0;

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
            Public.COfficeProperty EditCOfficeProperty = new Public.COfficeProperty();
            Public.COfficeProperty.ReadOne(iOfficePropertyID, ref EditCOfficeProperty);
            
            
            //財產編號
            EditCOfficeProperty.OfficePropertyNo = txt_OfficePropertyNo.Text;

            //單位財產名稱
            EditCOfficeProperty.OfficePropertyName = txt_OfficePropertyName.Text;

            //品項類型
            EditCOfficeProperty.OfficePropertyType = comboBox_OfficePropertyType.Text;

            //所屬單位
            EditCOfficeProperty.Unit = comboBox_Unit.Text;

            //建檔時間
            DateTime dtCreateDate;
            bool IsCreateDate = DateTime.TryParse(mask_CreateDate.Text, out dtCreateDate);
            if (IsCreateDate)
            {
                EditCOfficeProperty.CreateDate = dtCreateDate;
            }
            else
            {
                EditCOfficeProperty.CreateDate = new DateTime(1900, 1, 1);
            }

            //購買時間
            DateTime dtBuyDate;
            bool IsBuyDate = DateTime.TryParse(mask_BuyDate.Text, out dtBuyDate);
            if (IsBuyDate)
            {
                EditCOfficeProperty.BuyDate = dtBuyDate;
            }
            else
            {
                EditCOfficeProperty.BuyDate = new DateTime(1900,1,1);
            }

            //保固時間
            EditCOfficeProperty.WarrantyTime = txt_WarrantyTime.Text;

            //購買金額
            EditCOfficeProperty.Amount = numericUpDown_Amount.Value;

            //幣別
            EditCOfficeProperty.Currency = cb_Currency.Text;

            //當時匯率
            EditCOfficeProperty.ExchangeRate = numericUpDown_ExchangeRate.Value;

            //合計NT
            EditCOfficeProperty.TotalNT = numericUpDown_TotalNT.Value;

            //詳細規格
            EditCOfficeProperty.Specifications = txt_Specifications.Text;

            //功能說明
            EditCOfficeProperty.FunctionDescription = txt_FunctionDescription.Text;

            //發票號碼
            EditCOfficeProperty.InvoiceNumber = txt_InvoiceNumber.Text;

            //所在地
            EditCOfficeProperty.Location = cb_Location.Text;

            //目前保管人
            EditCOfficeProperty.Owner = cb_Owner.Text;

            //配件
            EditCOfficeProperty.Parts = txt_Parts.Text;

            //狀態(10.使用中 15.列管中 20.報修中 30.報廢)
            EditCOfficeProperty.Status = cb_Status.Text;

            //備註
            EditCOfficeProperty.Memo = txt_Memo.Text;

            //最後修改時間           
            EditCOfficeProperty.LastModifyDate = DateTime.Now;
            
            EditCOfficeProperty.LastModifyWorker =Properties.Settings.Default.WorkerKEY;           

            EditCOfficeProperty.Update();



            Public.PublicForm Forms = new Public.PublicForm();
            DataRow dr = Forms.OfficePropertyMF.GetOfficePropertyCurrentRow(iOfficePropertyID);
           

            //財產編號
            dr["OfficePropertyNo"] = EditCOfficeProperty.OfficePropertyNo;

            //單位財產名稱
            dr["OfficePropertyName"] = EditCOfficeProperty.OfficePropertyName;

            //品項類型
            dr["OfficePropertyType"] = EditCOfficeProperty.OfficePropertyType;

            //所屬單位
            dr["Unit"] = EditCOfficeProperty.Unit;

            //建檔時間
            if (EditCOfficeProperty.CreateDate.Value.Year > 1900)
            {
                dr["CreateDate"] = EditCOfficeProperty.CreateDate;
            }
            else
            {
                dr["CreateDate"] = DBNull.Value;
            }
            //購買時間
            if (EditCOfficeProperty.BuyDate.Value.Year > 1900)
            {
                dr["BuyDate"] = EditCOfficeProperty.BuyDate;
            }
            else
            {
                dr["BuyDate"] = DBNull.Value;
            }
            //保固時間
            dr["WarrantyTime"] = EditCOfficeProperty.WarrantyTime;

            //購買金額
            dr["Amount"] = EditCOfficeProperty.Amount;

            //幣別
            dr["Currency"] = EditCOfficeProperty.Currency;

            //當時匯率
            dr["ExchangeRate"] = EditCOfficeProperty.ExchangeRate;

            //合計NT
            dr["TotalNT"] = EditCOfficeProperty.TotalNT;

            //詳細規格
            dr["Specifications"] = EditCOfficeProperty.Specifications;

            //功能說明
            dr["FunctionDescription"] = EditCOfficeProperty.FunctionDescription;

            //發票號碼
            dr["InvoiceNumber"] = EditCOfficeProperty.InvoiceNumber;

            //所在地
            dr["Location"] = EditCOfficeProperty.Location;

            //目前保管人
            dr["Owner"] = EditCOfficeProperty.Owner;

            //配件
            dr["Parts"] = EditCOfficeProperty.Parts;

            //狀態(10.使用中 15.列管中 20.報修中 30.報廢)
            dr["Status"] = EditCOfficeProperty.Status;

            //備註
            dr["Memo"] = EditCOfficeProperty.Memo;

            Forms.OfficePropertyMF.GetOfficeProperty.AcceptChanges(); 
            MessageBox.Show("修改成功", "提示訊息", MessageBoxButtons.OK);
            this.Close();

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

        private void EditOfficeProperty_KeyDown(object sender, KeyEventArgs e)
        {
            Public.Utility.ControlTab(e);
        }

        private void mask_CreateDate_Leave(object sender, EventArgs e)
        {
            MaskedTextBox mak = (MaskedTextBox)sender;
            Public.Utility.CheckMaskedtextbox(mak);
        }
    }
}
