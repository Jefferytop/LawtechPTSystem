using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Reflection;

namespace LawtechPTSystem.US
{
     public partial class ComboSearchColumnBox : UserControl
    {
        #region struct CustomCombo
        public struct CustomCombo
        {
            /// <summary>
            /// DropDwon  0: Simple  1:DropDown 2:DropDownList(int) 3:DropDownList(string)
            /// </summary>
            private int _dropDwonMode;
            public int DropDwonMode
            {
                get { return _dropDwonMode; }
                set { _dropDwonMode = value; }
            }

            private string _sqlSelectString;
            public string SQLSelectString
            {
                get { return _sqlSelectString; }
                set { _sqlSelectString = value; }
            }

            private string _bindingDisplay;

            public string BindingDisplay
            {
                get { return _bindingDisplay; }
                set { _bindingDisplay = value; }
            }
            private string _bindingValue;

            public string BindingValue
            {
                get { return _bindingValue; }
                set { _bindingValue = value; }
            }

            private string _displayString;

            public string DisplayString
            {
                get { return _displayString; }
                set { _displayString = value; }
            }
            private string _valueString;

            public string ValueString
            {
                get { return _valueString; }
                set { _valueString = value; }
            }
        }
        #endregion

        private PropertyInfo _PropertyInfo = null;

        public ComboSearchColumnBox()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.SetStyle(
                        ControlStyles.UserPaint |
                        ControlStyles.AllPaintingInWmPaint |
                        ControlStyles.DoubleBuffer, true);

            this._PropertyInfo = this.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (Control rootCtrl in this.Controls)
            {
                this._PropertyInfo.SetValue(rootCtrl, true, null);

                if (rootCtrl.HasChildren)
                    SearchControl(rootCtrl);
            }

        }

        void SearchControl(Control Ctrl)
        {
            foreach (Control rootCtrl in Ctrl.Controls)
            {

                this._PropertyInfo.SetValue(rootCtrl, true, null);
                if (rootCtrl.HasChildren)
                    SearchControl(rootCtrl);
                else
                    break;
            }
        }


        private string strType = "ApplicantMF1";
        private const string tableName = "QueryDefinedT";

        [Category("自訂屬性"), DefaultValue("")]
        public string SearchType
        {
            get { return strType; }
            set
            {
                strType = value;
                ComboSearchColumnBox_Load(null, null);
            }
        }

        private string strSearchColumnValueString;
        /// <summary>
        /// 選取欄位值 Search Column Value
        /// </summary>
        [Category("自訂屬性"), Description("選取的欄位值")]
        public string SearchColumnValueString
        {
            get { return strSearchColumnValueString; }
            set { strSearchColumnValueString = value; }
        }


        [Category("自訂屬性"), Description("查詢的欄位(第一個ComboBox)")]
        public ComboBox ComboBoxSearchColumn
        {
            get
            {
                return cb_SearchColumn;
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

        /// <summary>
        /// 取得對應資料庫的查詢字段
        /// </summary>
        [Category("自訂屬性"), Description("取得對應資料庫的SQL Where查詢字段")]
        public string SQLSelectedValueColumn
        {
            get
            {
                string sWhere = "";
                CustomCombo ComboxItem = (CustomCombo)cb_SearchColumn.SelectedItem;
                switch (ComboxItem.DropDwonMode)
                {
                    case 1:
                    case 0:
                        sWhere = string.Format(" {0} Like N'{1}' ", ComboxItem.ValueString, cbSelectedValue.Text.Replace("--","")+"%" );
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

        private void ComboSearchColumnBox_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(SearchType))
            {
                Public.DLL db = new Public.DLL();
                string Query = "";
                if (SearchType.Contains(","))
                {
                    Query = string.Format("select * from {0} where QueryType in({1}) order by Sort", tableName, strType);
                }
                else
                {
                    Query = string.Format("select * from {0} where QueryType='{1}' order by Sort", tableName, strType);
                }

                DataTable dt = new DataTable();
                dt = db.SqlDataAdapterDataTable(Query);

                cb_SearchColumn.Items.Clear();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CustomCombo ComboxItem = new CustomCombo();
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

                this.cb_SearchColumn.SelectedIndexChanged += new System.EventHandler(this.cb_SearchColumn_SelectedIndexChanged);
            }
        }

        #region cb_SearchColumn_SelectedIndexChanged
        private void cb_SearchColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(SearchType))
            {
                CustomCombo ComboxItem = (CustomCombo)((System.Windows.Forms.ComboBox)(sender)).SelectedItem;
                DataTable dt = new DataTable();
                if (ComboxItem.DropDwonMode != 0)
                {
                    Public.DLL db = new Public.DLL();

                    dt = db.SqlDataAdapterDataTable(ComboxItem.SQLSelectString);
                    strSearchColumnValueString = ComboxItem.ValueString;
                }

                switch (ComboxItem.DropDwonMode)
                {
                    case 0:
                        cbSelectedValue.AutoCompleteSource = AutoCompleteSource.None;
                        cbSelectedValue.AutoCompleteMode = AutoCompleteMode.None;
                        cbSelectedValue.DropDownStyle = ComboBoxStyle.Simple;
                        //cbSelectedValue.Text = "";
                        break;
                    case 1:
                        cbSelectedValue.DropDownStyle = ComboBoxStyle.DropDown;
                        cbSelectedValue.AutoCompleteSource = AutoCompleteSource.ListItems;
                        cbSelectedValue.AutoCompleteMode = AutoCompleteMode.Suggest;
                        cbSelectedValue.DataSource = dt;
                        if (dt.Rows.Count > 0)
                        {
                            cbSelectedValue.DisplayMember = ComboxItem.BindingDisplay;
                            cbSelectedValue.ValueMember = ComboxItem.BindingValue;
                        }
                        //cbSelectedValue.Text = "";
                        break;
                    case 3:
                    case 2:
                        cbSelectedValue.AutoCompleteSource = AutoCompleteSource.None;
                        cbSelectedValue.AutoCompleteMode = AutoCompleteMode.None;
                        cbSelectedValue.DropDownStyle = ComboBoxStyle.DropDownList;
                        cbSelectedValue.DataSource = dt;
                        if (dt.Rows.Count > 0)
                        {
                            cbSelectedValue.DisplayMember = ComboxItem.BindingDisplay;
                            cbSelectedValue.ValueMember = ComboxItem.BindingValue;
                        }
                        break;
                }
            }

        }
        #endregion

    }
}

