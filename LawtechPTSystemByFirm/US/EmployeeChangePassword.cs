using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.US
{
    public partial class EmployeeChangePassword : Form
    {
        public EmployeeChangePassword()
        {
            InitializeComponent();
        }

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void but_OK_Click(object sender, EventArgs e)
        {
            if (txt_Comfirm.Text == "" || txt_Password.Text == "")
            {
                MessageBox.Show("密碼不得為空","提示訊息");
                return;
            }
            if (txt_Comfirm.Text.Trim() !=txt_Password.Text .Trim())
            {
                MessageBox.Show("請確定輸入的密碼相同", "提示訊息");
                return;
            }

            int iWorker = Properties.Settings.Default.WorkerKEY;          
            Worker_Model worker = new Worker_Model();
            Worker_Model.ReadOne(iWorker, ref  worker);
            worker.Password = txt_Password.Text;
            worker.Update();
            MessageBox.Show("修改密碼成功，下次登入請使用新密碼，謝謝", "提示訊息");
            this.Close();
        }

        private void EmployeeChangePassword_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txt_Password.PasswordChar = '\0';
                txt_Comfirm.PasswordChar = '\0';
            }
            else
            {
                txt_Password.PasswordChar = '*';
                txt_Comfirm.PasswordChar = '*';
            }
        }

        private void EmployeeChangePassword_KeyDown(object sender, KeyEventArgs e)
        {
            Public.Utility.ControlTab(e);
        }
    }
}
