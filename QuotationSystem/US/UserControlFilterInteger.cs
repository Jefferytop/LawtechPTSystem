using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using H3Operator.DBHelper;

namespace LawtechPTSystem.US
{

    /// <summary>
    /// 用於數字欄位的查詢
    /// </summary>
    public partial class UserControlFilterInteger : UserControl
    {
        #region struct CustomComboInteger
        public struct CustomComboInteger
        {
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

            private decimal _Maximum;
            /// <summary>
            /// 最大值
            /// </summary>
            public decimal Maximum
            {
                get { return _Maximum; }
                set { _Maximum = value; }
            }

            private decimal _Minimum;
            /// <summary>
            /// 最小值
            /// </summary>
            public decimal Minimum
            {
                get { return _Minimum; }
                set { _Minimum = value; }
            }

            private decimal _Increment;
            /// <summary>
            /// 每按一下所增加/減少的數量
            /// </summary>
            public decimal Increment
            {
                get { return _Increment; }
                set { _Increment = value; }
            }


            private int _DecimalPlaces;
            /// <summary>
            /// 要顯示的小數點
            /// </summary>
            public int DecimalPlaces
            {
                get { return _DecimalPlaces; }
                set { _DecimalPlaces = value; }
            }

        }
        #endregion

        public UserControlFilterInteger()
        {
            InitializeComponent();
        }

        private string strfilterInteger = "";
        /// <summary>
        /// 查詢sql 語法
        /// </summary>
        public string filterInteger
        {
            get { return strfilterInteger; }
            set { strfilterInteger = value; }
        }
        private const string tableName = "QueryDefinedIntegerT";

        private string strType = "";
        [Category("自訂屬性"), DefaultValue(""), Description("類型,當多個類型時,例如:『'type1','type2'』(SQL 的like 寫法) ")]
        public string SearchType
        {
            get { return strType; }
            set { strType = value; }
        }

        [Category("自訂屬性")]
        public SplitContainer SplitContainerControl
        {
            get
            {
                return SearchDateSplitContainer1;
            }
        }

        [Category("自訂屬性")]
        public ComboBox ComboSearchMode
        {
            get
            {
                return cb_Mode;
            }
        }

        [Category("自訂屬性")]
        public NumericUpDown numericUpDownValue
        {
            get
            {
                return numericUpDown_Value;
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
                CustomComboInteger ComboxItem = (CustomComboInteger)cb_Mode.SelectedItem;

                sWhere = string.Format(" {0}{1}{2} ", ComboxItem.ValueString, comboBox_Compare.SelectedValue.ToString() ,numericUpDown_Value.Value.ToString());

                return sWhere;

            }
        }

        #region UserControlFilterInteger_Load
        private void UserControlFilterInteger_Load(object sender, EventArgs e)
        {

            string Query = "";
            if (strType.Contains(','))
            {
                Query = string.Format("select DisplayString,ValueString,Maximum,Minimum,Increment,DecimalPlaces from {0} where QueryType in({1}) order by Sort", tableName, strType);
            }
            else
            {
                Query = string.Format("select DisplayString,ValueString,Maximum,Minimum,Increment,DecimalPlaces from {0} where QueryType='{1}' order by Sort", tableName, strType);
            }
            DBAccess db = new DBAccess();
            DataTable dt = new DataTable();
            object obj = db.QueryToDataTableByDataAdapter(Query, ref dt);

            cb_Mode.Items.Clear();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CustomComboInteger ComboxItem = new CustomComboInteger();

                ComboxItem.DisplayString = dt.Rows[i]["DisplayString"].ToString();
                ComboxItem.ValueString = dt.Rows[i]["ValueString"].ToString();
                ComboxItem.Maximum = (decimal)dt.Rows[i]["Maximum"];
                ComboxItem.Minimum = (decimal)dt.Rows[i]["Minimum"];
                ComboxItem.Increment = (decimal)dt.Rows[i]["Increment"];
                ComboxItem.DecimalPlaces = (int)dt.Rows[i]["DecimalPlaces"];
                cb_Mode.Items.Add(ComboxItem);
            }
            cb_Mode.DisplayMember = "DisplayString";
            cb_Mode.ValueMember = "ValueString";


            Query = @"select '大於' as DisplayString ,'>' as ValueString
union all
select '大於等於' as DisplayString ,'>=' as ValueString
union all
select '等於' as DisplayString ,'=' as ValueString
union all
select '小於' as DisplayString ,'<' as ValueString
union all
select '小於等於' as DisplayString ,'<=' as ValueString
union all
select '不等於' as DisplayString ,'<>' as ValueString ";
            DataTable dt_c1 = new DataTable();
            obj = db.QueryToDataTableByDataAdapter(Query, ref dt_c1);
            comboBox_Compare.DataSource = dt_c1;
            comboBox_Compare.DisplayMember = "DisplayString";
            comboBox_Compare.ValueMember = "ValueString";

        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_Mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var item = (System.Windows.Forms.ComboBox)(sender);
                if (item.SelectedItem != null)
                {
                    CustomComboInteger ComboxItem = (CustomComboInteger)item.SelectedItem;
                    numericUpDown_Value.Maximum = ComboxItem.Maximum;
                    numericUpDown_Value.Minimum = ComboxItem.Minimum;
                    numericUpDown_Value.Increment = ComboxItem.Increment;
                    numericUpDown_Value.DecimalPlaces = ComboxItem.DecimalPlaces;
                }
            }
            catch(System.Exception EX)
            {
                CommonFunction.ThreadWriteLog("ClassName:UserControlFilterInteger/r/n" + EX.Message);
            }
        }

       

    }
}
