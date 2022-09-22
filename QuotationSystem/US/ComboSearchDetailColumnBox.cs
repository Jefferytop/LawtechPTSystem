using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.US
{
    public partial class ComboSearchDetailColumnBox : UserControl
    {
        private string strType = "Patent";
        private string strParameterName = "";
        private string strParameterValue = "";
        private SqlDbType MyparameterSqlDbType = SqlDbType.Int;
        private const string tableName = "QueryDefinedT";

        public ComboSearchDetailColumnBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 取得對應資料庫的查詢字段
        /// </summary>
        public string SQLSelectedValueColumn
        {
            get
            {
                string sWhere = "";

                ComboSearchColumnBox.CustomCombo ComboxItem = (ComboSearchColumnBox.CustomCombo)cb_SearchColumn.SelectedItem;

                switch (ComboxItem.DropDwonMode)
                {
                    case 1:
                    case 0:
                        sWhere = string.Format(" {0} Like '{1}' ", ComboxItem.ValueString, cbSelectedValue.Text.Trim());
                        break;
                    case 2:
                        sWhere = string.Format(" {0} ={1} ", ComboxItem.ValueString, cbSelectedValue.SelectedValue.ToString());
                        break;
                    case 3:
                        sWhere = string.Format(" {0} ='{1}' ", ComboxItem.ValueString, cbSelectedValue.SelectedValue.ToString());
                        break;
                }
                return sWhere;

            }
        }


        [Category("參數"), DefaultValue("")]
        public string SearchType
        {
            get { return strType; }
            set { strType = value; }
        }

        /// <summary>
        /// 所繫結的參數名稱
        /// </summary>
        [Category("參數"), DefaultValue("所繫結的參數名稱")]
        public string ParameterName
        {
            get { return strParameterName; }
            set { strParameterName = value; }
        }

        /// <summary>
        /// 所繫結參數的值
        /// </summary>
        [Category("參數"), DefaultValue("所繫結參數的值")]
        public string ParameterValue
        {
            get { return strParameterValue; }
            set
            {
                strParameterValue = value;
                cb_SearchColumn_SelectedIndexChanged(cb_SearchColumn, null);
            }
        }

        /// <summary>
        /// 所繫結參數的型態
        /// </summary>
        [Category("參數"), DefaultValue("所繫結參數的型態")]
        public SqlDbType ParameterSqlDbType
        {
            get { return MyparameterSqlDbType; }
            set { MyparameterSqlDbType = value; }
        }

        [Browsable(false)]
        [Category("參數"), DefaultValue("所繫結參數的參數名稱和值的結果")]
        private string ParameterValueSQLQuery
        {
            get
            {
                string result = "";
                if (ParameterName.Trim() != "" && ParameterValue.Trim() != "")
                {
                    switch (MyparameterSqlDbType)
                    {
                        case SqlDbType.DateTime:
                        case SqlDbType.NVarChar:
                            result = ParameterName + "='" + ParameterValue + "'";
                            break;
                        case SqlDbType.BigInt:
                        case SqlDbType.Int:
                            if (ParameterValue == "")
                            {
                                result = ParameterName + "=-1";
                            }
                            else
                            {
                                result = ParameterName + "=" + ParameterValue;
                            }
                            break;
                    }
                }
                return result;
            }

        }

        [Category("自訂屬性"), Description("選取的值 (第二個ComboBox)")]
        public ComboBox ComboBoxSelectedValue
        {
            get
            {
                return cbSelectedValue;
            }
        }


        #region ComboSearchDetailColumnBox_Load
        private void ComboSearchDetailColumnBox_Load(object sender, EventArgs e)
        {
            Public.DLL db = new Public.DLL();
            string Query = "";
            if (Query.Contains(","))
            {
                Query = string.Format("select * from {0} where QueryType in({1}) order by Sort", tableName, strType);
            }
            else
            {
                Query = string.Format("select * from {0} where QueryType='{1}' order by Sort", tableName, strType);
            }

            DataTable dt = new DataTable();

            dt = db.SqlDataAdapterDataTable( Query);

            cb_SearchColumn.Items.Clear();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ComboSearchColumnBox.CustomCombo ComboxItem = new ComboSearchColumnBox.CustomCombo();
                ComboxItem.SQLSelectString = dt.Rows[i]["SQLSelectString"].ToString();

                if (dt.Rows[i]["DropDwonMode"] != null && dt.Rows[i]["DropDwonMode"] != DBNull.Value)
                {
                    ComboxItem.DropDwonMode = (int)dt.Rows[i]["DropDwonMode"];
                }
                else
                {
                    ComboxItem.DropDwonMode = 1;
                }

                ComboxItem.BindingDisplay = dt.Rows[i]["BindingDisplay"].ToString();
                ComboxItem.BindingValue = dt.Rows[i]["BindingValue"].ToString();
                ComboxItem.DisplayString = dt.Rows[i]["DisplayString"].ToString();
                ComboxItem.ValueString = dt.Rows[i]["ValueString"].ToString();

                cb_SearchColumn.Items.Add(ComboxItem);
            }

            cb_SearchColumn.DisplayMember = "DisplayString";
            cb_SearchColumn.ValueMember = "ValueString";

            if (cb_SearchColumn.Items.Count > 0)
            {
                cb_SearchColumn.SelectedIndex = 0;
            }

            if (cbSelectedValue.DropDownStyle != ComboBoxStyle.DropDownList)
            {
                cbSelectedValue.Text = "";
            }
        }
        #endregion

        #region cb_SearchColumn_SelectedIndexChanged
        private void cb_SearchColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_SearchColumn.SelectedItem != null)
            {
                ComboSearchColumnBox.CustomCombo ComboxItem = (ComboSearchColumnBox.CustomCombo)((System.Windows.Forms.ComboBox)(sender)).SelectedItem;
                DataTable dt = new DataTable();
                if (ComboxItem.DropDwonMode != 0)
                {
                    Public.DLL db = new Public.DLL();

                    //ParameterValueSQLQuery 附加參數
                    if (ParameterValueSQLQuery == "")
                    {
                        dt = db.SqlDataAdapterDataTable( ComboxItem.SQLSelectString);
                    }
                    else
                    {
                        dt = db.SqlDataAdapterDataTable( string.Format(ComboxItem.SQLSelectString, ParameterValueSQLQuery + " and "));
                    }
                }

                switch (ComboxItem.DropDwonMode)
                {
                    case 0:
                        cbSelectedValue.AutoCompleteSource = AutoCompleteSource.None;
                        cbSelectedValue.AutoCompleteMode = AutoCompleteMode.None;
                        cbSelectedValue.DropDownStyle = ComboBoxStyle.Simple;
                        cbSelectedValue.Text = "";
                        break;
                    case 1:
                        cbSelectedValue.DropDownStyle = ComboBoxStyle.DropDown;
                        cbSelectedValue.AutoCompleteSource = AutoCompleteSource.ListItems;
                        cbSelectedValue.AutoCompleteMode = AutoCompleteMode.Suggest;
                        cbSelectedValue.DataSource = dt;
                        cbSelectedValue.DisplayMember = ComboxItem.BindingDisplay;
                        cbSelectedValue.ValueMember = ComboxItem.BindingValue;
                        cbSelectedValue.Text = "";
                        break;
                    case 3:
                    case 2:
                        cbSelectedValue.AutoCompleteSource = AutoCompleteSource.None;
                        cbSelectedValue.AutoCompleteMode = AutoCompleteMode.None;
                        cbSelectedValue.DropDownStyle = ComboBoxStyle.DropDownList;
                        cbSelectedValue.DataSource = dt;
                        cbSelectedValue.DisplayMember = ComboxItem.BindingDisplay;
                        cbSelectedValue.ValueMember = ComboxItem.BindingValue;
                        break;
                }
            }
        }
        #endregion
    }
}
