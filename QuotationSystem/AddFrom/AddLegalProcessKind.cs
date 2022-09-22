using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystem.AddFrom
{
    public partial class AddLegalProcessKind : Form
    {
        public AddLegalProcessKind()
        {
            InitializeComponent();
        }

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void but_OK_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_ProcessKind.Text == "")
                {
                    MessageBox.Show("請輸入作業流程名稱");
                    txt_ProcessKind.Focus();
                    return;
                }

                Public.CLegalProcessKind processkind = new Public.CLegalProcessKind("1=0");
                processkind.sort = int.Parse(numericUpDown_sort.Value.ToString());
                processkind.ProcessKind = txt_ProcessKind.Text;
                processkind.bStop = 1;
                processkind.Insert();

                Public.PublicForm Forms = new Public.PublicForm();

                DataTable dt = Forms.LegalEventProcess.GetPKind;
                DataRow dr = dt.NewRow();
                dr["sort"] = processkind.sort;
                dr["ProcessKind"] = processkind.ProcessKind;
                dr["ProcessKEY"] = processkind.ProcessKEY;
                dr["bStop"] = processkind.bStop;

                dt.Rows.Add(dr);

                MessageBox.Show("新增成功");

                this.Close();
            }
            catch (System.Exception EX)
            {
                MessageBox.Show(EX.Message.Replace("'", ""));
            }
        }
    }
}
