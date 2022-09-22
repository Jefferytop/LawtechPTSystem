using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using H3Operator.DBHelper;

namespace LawtechPTSystem.AddFrom
{
    public partial class AddKeyWords : Form
    {
        public AddKeyWords()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_KeyWord.Text != "")
            {
                SqlConnection conn = new SqlConnection(DBAccess.ConnectionListDefaultConnectionString);
                string strSQL = "insert into KeyWordsT (KeyWord,SN) Values ('" + txt_KeyWord.Text + "'," + numericUpDown1.Value.ToString() + ")";
                SqlCommand comm = new SqlCommand(strSQL, conn);

                try
                {
                    conn.Open();
                    comm.ExecuteNonQuery();

                    MessageBox.Show("新增成功");

                }
                catch (SqlException ex)
                {
                    Public.Utility.WriteLog(string.Format("錯誤發生於:{0} 錯誤訊息:{1}", this.Name, ex.Message));
                }
                finally
                {
                    conn.Close();
                    this.DialogResult = DialogResult.OK;
                }
            }
            else
            {
                MessageBox.Show("請輸入關鍵字");
            }
        }

        private void AddKeyWords_Load(object sender, EventArgs e)
        {
            numericUpDown1.Value = Public.Utility.GetMaxSort("KeyWordsT","SN");
        }

        private void AddKeyWords_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    SendKeys.Send("{TAB}");
                    break;
                case Keys.PageDown:
                    SendKeys.Send("{TAB}");
                    break;
                case Keys.PageUp:
                    SendKeys.Send("+{TAB}");
                    break;
            }
        }
    }
}