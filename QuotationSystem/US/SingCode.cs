using System;
using System.Windows.Forms;

namespace LawtechPTSystem.US
{
    public partial class SingCode : Form
    {
        public SingCode()
        {
            InitializeComponent();
        }


        private bool isSuccess = false;
        /// <summary>
        /// 是否通過簽核
        /// </summary>
        public bool IsSuccess
        {
            get { return isSuccess; }
            set { isSuccess = value; }
        }

        private void but_OK_Click(object sender, EventArgs e)
        {
            if (txt_SingCode.Text.Trim() == "")
            {
                MessageBox.Show("【主管簽核碼】不得為空白，請再確認","提示訊息");
                return;
            }
            int iKey=Properties.Settings.Default.WorkerKEY;
            Worker_Model worker = new Worker_Model();
            Worker_Model.ReadOne(iKey,ref  worker);

            if (txt_SingCode.Text.Trim() == worker.SingCode.Trim())
            {
                isSuccess = true;
            }
            else
            {
                MessageBox.Show("【主管簽核碼】錯誤，請再確認", "提示訊息");
                return;
            }
        }

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txt_SingCode.PasswordChar = '\0';
            }
            else
            {
                txt_SingCode.PasswordChar = '*';
            }
        }

    }
}
