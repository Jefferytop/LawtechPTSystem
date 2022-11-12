using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using H3Operator.DBHelper;

namespace LawtechPTSystem.US
{
    public partial class UserControlFilterDate : UserControl
    {
        public UserControlFilterDate()
        {
            InitializeComponent();
        }

        private string strfilterDate = "";
        private const string tableName = "QueryDefinedDateT";

        private string strType = "";
        [Category("自訂屬性"), DefaultValue(""), Description("類型,當多個類型時,例如:『'type1','type2'』(SQL 的like 寫法) ")]
        public string SearchType
        {
            get { return strType; }
            set { strType = value;
            UserControlFilterDate_Load(null,null);
            }
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
        public ComboBox ComboSearchDate
        {
            get
            {
                return cb_DateMode;
            }
        }

        [Category("自訂屬性")]
        public MaskedTextBox MaskedStartDate
        {
            get
            {
                return maskedStartDate;
            }
        }

        [Category("自訂屬性")]
        public MaskedTextBox MaskedEndDate
        {
            get
            {
                return maskedEndDate;
            }
        }

        [Category("自訂屬性")]
        public Label LabelSeparated
        {
            get
            {
                return lab_Separated;
            }
        }

        #region UserControlFilterDate_Load
        private void UserControlFilterDate_Load(object sender, EventArgs e)
        {
            
            string Query = "";
            if (strType.Contains(','))
            {
                Query = string.Format("select DisplayString,ValueString from {0} where QueryType in({1}) order by Sort", tableName, strType);
            }
            else
            {
                Query = string.Format("select DisplayString,ValueString from {0} where QueryType='{1}' order by Sort", tableName, strType);
            }
            DBAccess db = new DBAccess();
            DataTable dt = new DataTable();
            object obj = db.QueryToDataTableByDataAdapter(Query, ref dt);

            cb_DateMode.DataSource = dt;
            cb_DateMode.DisplayMember = "DisplayString";
            cb_DateMode.ValueMember = "ValueString";
        }
        #endregion

        #region 取得查詢日期區間 getQueryDate()
        /// <summary>
        /// 取得查詢日期區間
        /// </summary>
        /// <returns></returns>
        public string getQueryDate()
        {
            #region 檢查輸入的日期格式是否合法，不合法則帶空值
            DateTime dtS;
            bool isdtS = DateTime.TryParse(maskedStartDate.Text, out dtS);
            if (!isdtS)
            {
                maskedStartDate.Text = "";
            }

            DateTime dtE;
            bool isdtE = DateTime.TryParse(maskedEndDate.Text, out dtE);
            if (!isdtE)
            {
                maskedEndDate.Text = "";
            } 
            #endregion

            if (maskedStartDate.Text != "    -  -" && maskedEndDate.Text != "    -  -")
            {
                if (dtS > dtE)
                {
                    maskedStartDate.Text = dtE.ToString("yyyy-MM-dd");
                    maskedEndDate.Text = dtS.ToString("yyyy-MM-dd");
                }
            }

            string strDateMode = cb_DateMode.SelectedValue != null ? cb_DateMode.SelectedValue.ToString() : "";

            if (maskedStartDate.Text != "    -  -" && maskedEndDate.Text == "    -  -")
            {
                strfilterDate = " " + strDateMode + ">='" + maskedStartDate.Text + "'";
            }
            else if (maskedStartDate.Text == "    -  -" && maskedEndDate.Text != "    -  -")
            {
                strfilterDate = " " + strDateMode + "<='" + maskedEndDate.Text + " 23:59:59'";
            }
            else if (maskedStartDate.Text != "    -  -" && maskedEndDate.Text != "    -  -")
            {
                strfilterDate = " (" + strDateMode + " >= '" + maskedStartDate.Text + "' and " + strDateMode + "<= '" + maskedEndDate.Text + " 23:59:59')";
            }
            else
            {
                strfilterDate = "";
            }

            return strfilterDate;
        }
        #endregion

        /// <summary>
        /// 清空 MaskedTextBox
        /// </summary>
        public void ClearMaskedTextBox()
        {
            maskedStartDate.Text = "";
            maskedEndDate.Text = "";
        }

        #region maskedStartDate_DoubleClick
        private void maskedStartDate_DoubleClick(object sender, EventArgs e)
        {
            MaskedTextBox mtb = (MaskedTextBox)sender;
            DateTime dt;
            bool IsSuccess = DateTime.TryParse(mtb.Text, out dt);
            
            if (!IsSuccess)
            {
                mtb.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }
        #endregion

    }
}
