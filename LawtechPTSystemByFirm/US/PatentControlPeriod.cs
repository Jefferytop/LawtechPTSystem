using System;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.US
{
    /// <summary>
    /// 專利年費管制期限
    /// </summary>
    public partial class PatentControlPeriod : Form
    {
        public PatentControlPeriod()
        {
            InitializeComponent();
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private decimal decPeriod = 0;
        public decimal patentcontrol
        {
            get {
                return decPeriod;
            }
            set
            {
                decPeriod = value;
            }
        }

        private void PatentControlPeriod_Load(object sender, EventArgs e)
        {
            Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
            string strSQL = "select Value from StatueRecordT where StatusName='PatentControlFee'";
           object obj= dll.SQLexecuteScalar(strSQL);

           if (obj == null)
           {
               numericUpDown1.Value = 1;
           }
           else
           {
               numericUpDown1.Value = decimal.Parse(obj.ToString());
           }

        }

        private void butOK_Click(object sender, EventArgs e)
        {
            Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
            string strSQL = string.Format("update StatueRecordT set Value='{0}' where StatusName='PatentControlFee'", numericUpDown1.Value.ToString());
            dll.SQLexecuteNonQuery(strSQL);
            decPeriod = numericUpDown1.Value;
            MessageBox.Show("設定年費管制時間成功","提示訊息");
            this.Close();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            label2.Text = string.Format("專利年費將[ 年費有效期限] 在 {0} 個月前列入管制", numericUpDown1.Value.ToString());
        }
    }
}
