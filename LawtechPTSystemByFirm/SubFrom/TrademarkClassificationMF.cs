using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.SubFrom
{
    /// <summary>
    /// 商標--尼斯分類設定
    /// </summary>
    public partial class TrademarkClassificationMF : Form
    {
        UserPermissionForm myPermission;
        private const string ProgramSymbol = "TrademarkClassificationMF";
        private const string SourceTableName = "TrademarkClassificationT";

        public TrademarkClassificationMF()
        {
            InitializeComponent();
            dataGridView_TrademarkClassification.AutoGenerateColumns = false;
            dataGridView_TrademarkItems.AutoGenerateColumns = false;

            Public.DynamicGridViewColumn.GetGridColum(ref dataGridView_TrademarkClassification);
            Public.DynamicGridViewColumn.GetGridColum(ref dataGridView_TrademarkItems);
        }

        public DataTable GetTrademarkClassificationT
        {
            get { return this.dataSet_TM.TrademarkClassificationT; }
        }

        public DataTable GetTrademarkItemsT
        {
            get { return this.dataSet_TM.TrademarkItemsT; }
        }

        private void TrademarkClassificationMF_Load(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            Forms.TrademarkClassificationMF = this;

            //取得權限
            myPermission = new UserPermissionForm(Properties.Settings.Default.WorkerKEY, ProgramSymbol);

            System.Windows.Forms.BindingNavigator[] listbinding = { bindingNavigator1, bindingNavigator2 };
            System.Windows.Forms.ContextMenuStrip[] listtMenu = { contextMenuStrip_TMClass, contextMenuStrip_TMItems };

            //確認可使用的功能選單
            Public.CommonFunctions.CheckMeunItemVisible(listbinding, myPermission.UserPermission);
            Public.CommonFunctions.CheckMeunItemVisible(listtMenu, myPermission.UserPermission);

            this.countryT_DropTableAdapter.Fill(this.qS_DataSet.CountryT_Drop);
            this.trademarkClassificationTTableAdapter.Fill(this.dataSet_TM.TrademarkClassificationT, comboBox_Country.SelectedValue.ToString());

            this.dataSet_TM.TrademarkClassificationT.ColumnChanged += new DataColumnChangeEventHandler(TrademarkClassificationT_ColumnChanged);
            this.dataSet_TM.TrademarkItemsT.ColumnChanged += new DataColumnChangeEventHandler(TrademarkItemsT_ColumnChanged);
            ControlBinding();
        }

        private void TrademarkClassificationMF_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            Forms.TrademarkClassificationMF = null;
        }

        #region  =============TrademarkClassificationT_ColumnChanged事件===============
        private void TrademarkClassificationT_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Row.RowState == DataRowState.Unchanged)
            {

                Public.CTrademarkClassification CA_CTrademarkClassification = new Public.CTrademarkClassification();
                Public.CTrademarkClassification.ReadOne((int)e.Row["TMClassID"], ref CA_CTrademarkClassification);
                switch (e.Column.ColumnName)
                {

                  
                    case "Sort":
                        CA_CTrademarkClassification.Sort = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                    case "CountrySymbol":
                        CA_CTrademarkClassification.CountrySymbol = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "ClassName":
                        CA_CTrademarkClassification.ClassName = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "ClassDescript":
                        CA_CTrademarkClassification.ClassDescript = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "ClassDescript_En":
                        CA_CTrademarkClassification.ClassDescript_En = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                }
                CA_CTrademarkClassification.Update();
                this.dataSet_TM.TrademarkClassificationT.AcceptChanges();
            }
        }
        #endregion

        #region  =============TrademarkItemsT_ColumnChanged事件===============
        private void TrademarkItemsT_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Row.RowState == DataRowState.Unchanged)
            {

                Public.CTrademarkItems CA_CTrademarkItems = new Public.CTrademarkItems();
                Public.CTrademarkItems.ReadOne((int)e.Row["TMItemsID"], ref CA_CTrademarkItems);
                switch (e.Column.ColumnName)
                {
                  
                    case "SerialNo":
                        CA_CTrademarkItems.SerialNo = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "BasicNo":
                        CA_CTrademarkItems.BasicNo = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "IndicationOfGoods_En":
                        CA_CTrademarkItems.IndicationOfGoods_En = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "IndicationOfGoods_CHT":
                        CA_CTrademarkItems.IndicationOfGoods_CHT = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "IndicationOfGoods_CHS":
                        CA_CTrademarkItems.IndicationOfGoods_CHS = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                }
                CA_CTrademarkItems.Update();
                this.dataSet_TM.TrademarkItemsT.AcceptChanges();
            }
        }
        #endregion

        public void ControlBinding()
        {
            txt_Descript_En.DataBindings.Clear();
            txt_Descript_En.DataBindings.Add("Text", trademarkClassificationTBindingSource, "ClassDescript_En", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_Descript_CHT.DataBindings.Clear();
            txt_Descript_CHT.DataBindings.Add("Text", trademarkClassificationTBindingSource, "ClassDescript", true, DataSourceUpdateMode.OnValidation, "", "");

         
        }

       

        private void dataGridView_TrademarkClassification_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_TrademarkClassification.CurrentRow != null)
            {
                this.trademarkItemsTTableAdapter.Fill(this.dataSet_TM.TrademarkItemsT, (int)dataGridView_TrademarkClassification.CurrentRow.Cells["TMClassID"].Value);
            }
        }

        private void comboBox_Country_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Country.SelectedValue != null)
            {
                this.trademarkClassificationTTableAdapter.Fill(this.dataSet_TM.TrademarkClassificationT, comboBox_Country.SelectedValue.ToString());
            }
        }

        private void contextMenuStrip_TMClass_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip_TMClass.Visible = false;
            switch (e.ClickedItem.Name)
            {
                case "ToolStripMenuItem_AddClass":
                    AddFrom.AddTrademarkClassification add = new AddFrom.AddTrademarkClassification();
                    add.Country = comboBox_Country.SelectedValue.ToString();
                    add.ShowDialog();

                    break;
                case "ToolStripMenuItem_DelClass":
                    if (dataGridView_TrademarkClassification.CurrentRow != null)
                    {
                        if (MessageBox.Show("是否確定刪除", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            Public.CTrademarkClassification TMStatus = new Public.CTrademarkClassification();
                            TMStatus.Delete((int)dataGridView_TrademarkClassification.CurrentRow.Cells["TMClassID"].Value);
                            dataGridView_TrademarkClassification.Rows.Remove(dataGridView_TrademarkClassification.CurrentRow);
                            MessageBox.Show("刪除成功");
                        }
                    }
                    break;

            }
        }

        private void contextMenuStrip_TMItems_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip_TMItems.Visible = false;
            switch (e.ClickedItem.Name)
            {
                case "ToolStripMenuItem_AddItem":
                    if (dataGridView_TrademarkClassification.CurrentRow != null)
                    {
                        AddFrom.AddTrademarkItems add = new AddFrom.AddTrademarkItems();
                        add.TMClassID = (int)dataGridView_TrademarkItems.CurrentRow.Cells["TMItemsID"].Value;
                        add.ShowDialog();
                    }
                    break;
                case "ToolStripMenuItem_DelItem":
                    if (dataGridView_TrademarkItems.CurrentRow != null)
                    {
                        if (MessageBox.Show("是否確定刪除", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            Public.CTrademarkItems TMItem = new Public.CTrademarkItems();
                            TMItem.Delete((int)dataGridView_TrademarkItems.CurrentRow.Cells["TMItemsID"].Value);
                            dataGridView_TrademarkItems.Rows.Remove(dataGridView_TrademarkItems.CurrentRow);
                            MessageBox.Show("刪除成功");
                        }
                    }
                    break;

            }
        }

        private void dataGridView_TrademarkClassification_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            string ss = e.Exception.Message;
        }

        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
