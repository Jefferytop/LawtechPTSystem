using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.SubFrom
{
    public partial class MoneyMF : Form
    {
        public MoneyMF()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            Public.DynamicGridViewColumn.GetGridColum(ref dataGridView1);
        }

        #region ========自訂變數========
        DataTable dt_Money;
        BindingSource bsMoney;
        #endregion 

        private void MoneyMF_Load(object sender, EventArgs e)
        {            
            List<Public.CMoney> money = new List<Public.CMoney>();
            Public.CMoney.ReadList(ref  money);           

            bsMoney = new BindingSource();
            bsMoney.DataSource = money;

            dataGridView1.DataSource = bsMoney;
            bindingNavigator1.BindingSource = bsMoney;            
        }


        #region  =============MoneyT_ColumnChanged事件===============
        private void MoneyT_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Row.RowState == DataRowState.Unchanged)
            {

                Public.CMoney CA_CMoney = new Public.CMoney();
                Public.CMoney.ReadOne(int.Parse(e.Row["MoneyKey"].ToString()), ref CA_CMoney);
              
                switch (e.Column.ColumnName)
                {
                    case "Money":
                        CA_CMoney.Money = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "MoneyName":
                        CA_CMoney.MoneyName = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "ToNT":
                        CA_CMoney.ToNT = e.ProposedValue != DBNull.Value ? decimal.Parse(e.ProposedValue.ToString()) : 0;
                        break;
                    case "SN":
                        CA_CMoney.SN = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                }
                CA_CMoney.Update();
                 dt_Money.AcceptChanges();
            }
        }
        #endregion

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dg1 = (DataGridView)sender;
            if (e.RowIndex != -1)
            {
                Public.CMoney CA_CMoney = new Public.CMoney();
                Public.CMoney.ReadOne(int.Parse(dg1.Rows[e.RowIndex].Cells["MoneyKey"].Value.ToString()), ref CA_CMoney);
                switch (dg1.Columns[e.ColumnIndex].Name)
                {
                    case "Money":
                        CA_CMoney.Money = dg1.Rows[e.RowIndex].Cells["Money"].Value.ToString();
                        break;
                    case "MoneyName":
                        CA_CMoney.MoneyName = dg1.Rows[e.RowIndex].Cells["MoneyName"].Value.ToString();
                        break;
                    case "ToNT":
                        decimal ToNT;
                        bool isToNT = decimal.TryParse(dg1.Rows[e.RowIndex].Cells["ToNT"].Value.ToString(), out ToNT);
                        if (isToNT)
                        {
                            CA_CMoney.ToNT = ToNT;
                        }
                        break;
                    case "SN":
                        int intSN;
                        bool isSN = int.TryParse(dg1.Rows[e.RowIndex].Cells["SN"].Value.ToString(), out intSN);
                        if (isSN)
                        {
                            CA_CMoney.SN = intSN;
                        }
                        break;
                }

                CA_CMoney.Update();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1)
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "UpdateToNT")
                {
                    if (MessageBox.Show("是否確定更新幣別匯率(" + dataGridView1.CurrentRow.Cells["MoneyName"].Value.ToString() + ")", "提示訊息", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {

                      List< Public.CnTriff> ctriff = new  List<Public.CnTriff>();
                      Public.CnTriff.ReadList(ref ctriff, string.Format("MoneyKindG='{0}'  or MoneyKind='{0}' ", dataGridView1.CurrentRow.Cells["Money"].Value.ToString()));


                      for (int i = 0; i < ctriff.Count; i++)
                        {
                            Public.CnTriff tri = ctriff[i];


                            decimal GovToNT = getToNT(tri.MoneyKindG.ToString());//官方收費的匯率
                            tri.GovFeeNT = tri.GovFee * GovToNT;//官方規費折合NT

                            decimal AttorneyToNT = getToNT(tri.MoneyKind);//國外代理人幣別的匯率
                            tri.AttorneyELFeeNT = tri.AttorneyFee * AttorneyToNT;//國外代理人服務費折合NT
                            tri.AttorneyElseFeeNT = tri.AttorneyElseFee * AttorneyToNT;//預估國外代理人雜費折合NT
                            tri.NotifyFeeNT = tri.NotifyFee * AttorneyToNT;//預估轉遞審定書費用折合NT
                            tri.AttorneyFeeNT = tri.AttorneyELFeeNT + tri.AttorneyElseFeeNT + tri.NotifyFeeNT + tri.TranFee + tri.WriteFee + tri.SafeFee;//國外代理費
                            tri.BeforeTotal = tri.Totall;//之前報價
                            tri.Totall = tri.AttorneyFeeNT + tri.GovFeeNT + tri.MeFee;//實際總價
                            tri.QuotaTotal = QuotaTotal(tri.Totall.Value);//報價總計NT
                            tri.Gain = tri.QuotaTotal - tri.Totall;
                            tri.Update();
                        }
                        Public.PublicForm Forms = new Public.PublicForm();
                        if(Forms.QPForm!=null)
                        {
                            Forms.QPForm.LoadData();
                        }
                        

                        MessageBox.Show("更新成功");
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
        }

        public decimal getToNT(string sMony)
        {
            decimal reValue=0;
            for (int n = 0; n < dataGridView1.Rows.Count; n++)
            {
                if (dataGridView1.Rows[n].Cells["Money"].Value.ToString() == sMony)
                {
                    reValue = (decimal)dataGridView1.Rows[n].Cells["ToNT"].Value;
                    break;
                }
            }

            return reValue;
        }

        #region ===========QuotaTotal============
        /// <summary>
        /// 計算報價總計差額
        /// </summary>
        /// <param name="Money"></param>
        /// <returns></returns>
        private decimal QuotaTotal(decimal Money)
        {
            //decimal qt = 0;
            //if (Money <= 100) //不用整數
            //{
            //    qt = Money;
            //}
            //else if (Money > 100 && Money <= 1000) //整數一位ex: 111=> 120
            //{
            //    int m = 0;//換算成銅鈑,用個數計算
            //    int i = (int)Money % 10; //求餘數
            //    if (i > 0)
            //        m = ((int)Money / 10) + 1;
            //    else
            //        m = (int)Money / 10;

            //    qt = (decimal)m * 10;
            //}
            //else if (Money > 1000) //整數2位ex: 1111 => 1200
            //{
            //    int m = 0;//換算成百鈔,用張數計算
            //    int i = (int)Money % 100; //求餘數
            //    if (i > 0)
            //        m = ((int)Money / 100) + 1;
            //    else
            //        m = (int)Money / 100;

            //    qt = (decimal)m * 100;
            //}
            //return qt;

            decimal qt = 0;
            if (Money <= 100) //不用整數
            {
                qt = Money;
            }
            else if (Money > 100 && Money <= 1000) //依50為一單位ex: 123 => 150, 156 => 200
            {
                int m = 0;//換算成銅鈑,用個數計算
                int i = (int)Money % 50; //求餘數
                if (i > 0)
                    m = ((int)Money / 50) + 1;
                else
                    m = (int)Money / 50;

                qt = (decimal)m * 50;
            }
            else if (Money > 1000 && Money <= 10000) //依500為一單位ex: 1234 => 1500, 1666 => 2000
            {
                int m = 0;//換算成500元,用張數計算
                int i = (int)Money % 500; //求餘數
                if (i > 0)
                    m = ((int)Money / 500) + 1;
                else
                    m = (int)Money / 500;

                qt = (decimal)m * 500;
            }
            else if (Money > 10000) //
            {
                int m = 0;//換算成100元,用張數計算 ex: 12345 => 12400
                int i = (int)Money % 100; //求餘數
                if (i > 0)
                    m = ((int)Money / 100) + 1;
                else
                    m = (int)Money / 100;

                qt = (decimal)m * 100;
            }
            return qt;
        }
        #endregion

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }

        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();

        }

     
    }
}