using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.SubFrom
{
    public partial class CountrySetting : Form
    {
        UserPermissionForm myPermission;
        private const string strProgramSymbol = "CountrySetting";
        private const string SourceTableName = "CountryT";

        /// <summary>
        /// 國別設定管理
        /// </summary>
        public CountrySetting()
        {
            InitializeComponent();

            DataGridViewCountrySetting.AutoGenerateColumns = false;
            Public.DynamicGridViewColumn.GetGridColum(ref DataGridViewCountrySetting);
        }

        #region 國別資料集
        private DataTable dt_CountryT = new DataTable();
        /// <summary>
        /// 國別資料集
        /// </summary>
        public DataTable DT_CountryT
        {
            get { return dt_CountryT; }
            set { dt_CountryT = value; }
        } 
        #endregion

        #region 關閉按鈕 private void button2_Click(object sender, EventArgs e)
        /// <summary>
        /// 關閉按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        #endregion

        #region private void CountrySetting_Load(object sender, EventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CountrySetting_Load(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.CountrySetting = this;

            //取得權限
            myPermission = new UserPermissionForm(Properties.Settings.Default.WorkerKEY, strProgramSymbol);

            System.Windows.Forms.BindingNavigator[] listbinding = { bindingNavigator1 };
            //System.Windows.Forms.ContextMenuStrip[] listtMenu = { contextMenuStrip1 };

            //確認可使用的功能選單
            Public.CommonFunctions.CheckMeunItemVisible(listbinding, myPermission.UserPermission);
            //Public.CommonFunctions.CheckMeunItemVisible(listtMenu, myPermission.UserPermission);

            Public.CCountryPublicFunction.GetCountryAllList(ref dt_CountryT);

            CountryBindingSource.DataSource = dt_CountryT;

            BindEvent();
        } 
        #endregion

        private void BindEvent()
        {
            this.DataGridViewCountrySetting.CellValueChanged += new DataGridViewCellEventHandler(this.dDataGridViewCountrySetting_CellValueChanged);
          
        }

        #region private void dDataGridViewCountrySetting_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dDataGridViewCountrySetting_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (DataGridViewCountrySetting.CurrentRow != null)
            {
                if (e.RowIndex != -1 && e.ColumnIndex != -1)
                {
                    try
                    {
                        Public.CCountry country = new Public.CCountry();
                        Public.CCountry.ReadOne(string.Format("CountrySymbol='{0}'", DataGridViewCountrySetting.CurrentRow.Cells["CountrySymbol"].Value.ToString()), ref country);

                        country.Country = DataGridViewCountrySetting.CurrentRow.Cells["Country"].Value.ToString();
                        country.CountryEn = DataGridViewCountrySetting.CurrentRow.Cells["CountryEn"].Value.ToString();
                        country.CountrySimp = DataGridViewCountrySetting.CurrentRow.Cells["CountrySimp"].Value.ToString();

                        country.SN = DataGridViewCountrySetting.CurrentRow.Cells["SN"].Value.ToString() != "" ? (int)DataGridViewCountrySetting.CurrentRow.Cells["SN"].Value : 0;

                        country.IsEnable = DataGridViewCountrySetting.CurrentRow.Cells["IsEnable"].Value == DBNull.Value ? false : (bool)DataGridViewCountrySetting.CurrentRow.Cells["IsEnable"].Value;

                        country.Update();

                        dt_CountryT.AcceptChanges();
                    }
                    catch (System.Exception EX)
                    {
                        MessageBox.Show(EX.Message.Replace("'", ""));
                    }
                }
            }
        } 
        #endregion

        #region private void DataGridViewCountrySetting_DataError(object sender, DataGridViewDataErrorEventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewCountrySetting_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        } 
        #endregion

        #region  private void CountrySetting_FormClosed(object sender, FormClosedEventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CountrySetting_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.CountrySetting = null;
        } 
        #endregion

        #region 刷新按鈕  private void but_Update_Click(object sender, EventArgs e)
        /// <summary>
        /// 刷新按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_Update_Click(object sender, EventArgs e)
        {
            but_Update.Enabled = false;
            if (dt_CountryT.Rows.Count > 0)
            {
                dt_CountryT.Rows.Clear();
            }
            Public.CCountryPublicFunction.GetCountryAllList(ref dt_CountryT);
            but_Update.Enabled = true;
        } 
        #endregion

        

       
    }
}
