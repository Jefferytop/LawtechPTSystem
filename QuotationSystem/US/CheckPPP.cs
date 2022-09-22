using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.US
{
    /// <summary>
    /// 產生請款單號
    /// </summary>
    public partial class CheckPPP : Form
    {
        public CheckPPP()
        {
            InitializeComponent();
        }

        private int iModeType = 0;
        /// <summary>
        /// 1.專 利  2.商 標 3.商標異議
        /// </summary>
        public int ModeType
        {
            get { return iModeType; }
            set { iModeType = value; }
        }

        private int iMainKey = -1;
        /// <summary>
        /// 案件的主key PatentID or 
        /// </summary>
        public int MainKey
        {
            get { return iMainKey; }
            set { iMainKey = value; }
        }

        /// <summary>
        /// 取得請款單編號
        /// </summary>
        public string get_PPP
        {
            get { return txt_PPP.Text; }
            set { txt_PPP.Text = value; }
        }


        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CheckPPP_Load(object sender, EventArgs e)
        {
            int iYear=DateTime.Now.Year;
            for (int i = 2005; i < iYear + 4; i++)
            {
                comboBox_Year.Items.Add(i.ToString());
            }

            comboBox_Year.Text = DateTime.Now.Year.ToString();
            comboBox_Month.Text = DateTime.Now.Month.ToString("D2");

            if (ModeType == 1)
            {
                comboBox_Company.DataSource = GetPatentApplicantSymbol();
            }
            else if (ModeType == 2)
            {
                comboBox_Company.DataSource = GetTrademarkApplicantSymbol();
            }
            else if (ModeType == 3)
            {
                comboBox_Company.DataSource = GetTrademarkControversyApplicantSymbol();
            }

            comboBox_Company.ValueMember = "ApplicantKey";
            comboBox_Company.DisplayMember = "ApplicantSymbol";

            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox_Company.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox_Year.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox_Month.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            
            txt_SerialNo.Text = GetSerialNo();
            //txt_PPP.Text = GetPPP();
        }

        #region 取得申請人代碼
        public DataTable GetPatentApplicantSymbol()
        {
            string strSQL = @"SELECT     PatentApplicantT.ApplicantKey, ApplicantT.ApplicantSymbol, PatentApplicantT.PatentID
                            FROM         ApplicantT with(nolock) RIGHT OUTER JOIN
                                                  PatentApplicantT ON ApplicantT.ApplicantKey = PatentApplicantT.ApplicantKey
                            WHERE     (PatentApplicantT.PatentID = " + MainKey.ToString() + ")";

            Public.DLL dll = new Public.DLL();
           DataTable dt= dll.SqlDataAdapterDataTable(strSQL);
           return dt;
        }

        public DataTable GetTrademarkApplicantSymbol()
        {
            string strSQL = @"SELECT     TrademarkApplicantT.ApplicantKey, ApplicantT.ApplicantSymbol
                            FROM         ApplicantT with(nolock) RIGHT OUTER JOIN
                                                  TrademarkApplicantT ON ApplicantT.ApplicantKey = TrademarkApplicantT.ApplicantKey
                            WHERE     (TrademarkApplicantT.TrademarkID = " + MainKey.ToString() + ")";

            Public.DLL dll = new Public.DLL();
            DataTable dt = dll.SqlDataAdapterDataTable(strSQL);
            return dt;
        }

        public DataTable GetTrademarkControversyApplicantSymbol()
        {
            string strSQL = @"SELECT     TrademarkControversyApplicantT.ApplicantKey, ApplicantT.ApplicantSymbol
                            FROM         ApplicantT with(nolock) RIGHT OUTER JOIN
                                                  TrademarkControversyApplicantT ON ApplicantT.ApplicantKey = TrademarkControversyApplicantT.ApplicantKey
                            WHERE     (TrademarkControversyApplicantT.TrademarkControversyID = " + MainKey.ToString() + ")";

            Public.DLL dll = new Public.DLL();
            DataTable dt = dll.SqlDataAdapterDataTable(strSQL);
            return dt;
        }
        #endregion


        public string GetSerialNo()
        {
            string strYear = comboBox_Year.Text.Substring(2);
            string strNo = comboBox1.Text + "-" + comboBox_Company.Text + "-" + strYear + comboBox_Month.Text;
            string strSQL = "";
            if (ModeType == 1)
            {
                 strSQL = string.Format(@"select distinct top 1 convert(int , replace(ppp,'{0}','') ) as PPP from (
                            select distinct ppp from patentfeeT with(nolock)
                            union 
                            select distinct BillingNo as PPP from PatentPaymentT with(nolock)) as T where ppp like '{0}%' order by PPP desc
                            ", strNo);
            }
            else {
                strSQL = string.Format(@"select distinct top 1 convert(int , replace(ppp,'{0}','') ) as PPP from (
                            select distinct ppp from TrademarkFeeT with(nolock)
                            union 
                            select distinct BillingNo as PPP from TrademarkPaymentT with(nolock)) as T where ppp like '{0}%' order by PPP desc
                            ", strNo);
            }
            Public.DLL dll = new Public.DLL();
            object obj = dll.SQLexecuteScalar(strSQL);
            string ReValue = "001";
            if (obj != null && obj.ToString() != "")
            {
                int iNo=0;
                bool iSuccess = int.TryParse(obj.ToString().Replace(strNo, ""), out iNo);
                if (iSuccess)
                {
                    ReValue = (iNo+1).ToString("D3");
                }
            }

            return ReValue;

        }

        public string GetPPP()
        {
            string strYear = comboBox_Year.Text.Substring(2);
            string strNo = comboBox1.Text + "-" + comboBox_Company.Text + "-" + strYear + comboBox_Month.Text+txt_SerialNo.Text;

            return strNo;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_SerialNo.Text = GetSerialNo();
            txt_PPP.Text = GetPPP();
        }

        private void txt_SerialNo_TextChanged(object sender, EventArgs e)
        {
            txt_PPP.Text = GetPPP();
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
