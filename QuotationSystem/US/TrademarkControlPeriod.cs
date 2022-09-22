using System;
using System.Windows.Forms;

namespace LawtechPTSystem.US
{
    /// <summary>
    /// 設定延展管制時間
    /// </summary>
    public partial class TrademarkControlPeriod : Form
    {

        public TrademarkControlPeriod()
        {
            InitializeComponent();
        }

        private decimal decPeriod = 0;
        public decimal Trademarkcontrol
        {
            get
            {
                return decPeriod;
            }
            set
            {
                decPeriod = value;
            }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            Public.DLL dll = new Public.DLL();
            string strSQL = string.Format("update StatueRecordT set Value='{0}' where StatusName='TrademarkControlFee'", numericUpDown1.Value.ToString());
            dll.SQLexecuteNonQuery(strSQL);
            decPeriod = numericUpDown1.Value;
            MessageBox.Show("設定商標延展管制時間成功", "提示訊息");
            this.Close();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            label2.Text = string.Format("商標延展將在 {0} 個月前列入管制", numericUpDown1.Value.ToString());
        }

        private void TrademarkControlPeriod_Load(object sender, EventArgs e)
        {
            Public.DLL dll = new Public.DLL();
            string strSQL = "select Value from StatueRecordT where StatusName='TrademarkControlFee'";
            object obj = dll.SQLexecuteScalar(strSQL);

            if (obj == null)
            {
                numericUpDown1.Value = 1;
            }
            else
            {
                numericUpDown1.Value = decimal.Parse(obj.ToString());
            }
        }
    }
}
