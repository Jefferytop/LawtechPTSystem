using System;
using System.Windows.Forms;

namespace LawtechPTSystem.US
{
    public partial class FeeFinishDate : Form
    {
        public FeeFinishDate()
        {
            InitializeComponent();
        }

        DateTime dtCurrentDate = new DateTime(1900, 1, 1);
        /// <summary>
        /// 設定的日期
        /// </summary>
        public DateTime CurrentDate
        {
            get
            {
                bool IsSuccess = DateTime.TryParse(maskedTextBox_Result.Text, out dtCurrentDate);
                if (IsSuccess)
                {
                    return dtCurrentDate;
                }
                else
                {
                    return new DateTime(1900, 1, 1);
                }
            }
            set
            {
                if (value.Year > 1900)
                {
                    maskedTextBox_Result.Text = value.ToString("yyyy/MM/dd");
                }
                else
                {
                    maskedTextBox_Result.Text = "";
                }

            }
        }

        /// <summary>
        /// 已收款
        /// </summary>
        public bool Pro_Pay
        {
            get {
                return checkBox1.Checked;
            }
            set {
                checkBox1.Checked = value;
            }
        }

        /// <summary>
        /// 付款方式
        /// </summary>
        public string Pro_PayKind
        {
            get
            {
                return txt_PayKind.Text;
            }
            set
            {
                txt_PayKind.Text = value;
            }
        }


        public string GetResult
        {
            get { return maskedTextBox_Result.Text; }
        }

        private void maskedTextBox_Result_DoubleClick(object sender, EventArgs e)
        {
            MaskedTextBox mtb = (MaskedTextBox)sender;
            DateTime dt;
            bool IsSuccess = DateTime.TryParse(mtb.Text, out dt);
            if (!IsSuccess)
            {
                mtb.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }
        }

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void but_OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FeeFinishDate_Load(object sender, EventArgs e)
        {
            maskedTextBox_Result.Text = DateTime.Now.ToString("yyyy/MM/dd");
        }

        private void FeeFinishDate_KeyDown(object sender, KeyEventArgs e)
        {
            Public.Utility.ControlTab(e);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                maskedTextBox_Result.Enabled = true;
                maskedTextBox_Result.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }
            else
            {
                maskedTextBox_Result.Enabled = false;
                maskedTextBox_Result.Text = "";
            }
        }

        private void maskedTextBox_Result_Leave(object sender, EventArgs e)
        {
            MaskedTextBox mak = (MaskedTextBox)sender;
            Public.Utility.CheckMaskedtextbox(mak);
        }
    }
}
