using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.AddFrom
{
    public partial class AddProcessKind : Form
    {
        public AddProcessKind()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_ProcessKind.Text == "")
                {
                    MessageBox.Show("請輸入作業流程名稱");
                    txt_ProcessKind.Focus();
                    return;
                }

                Public.CProcessKind processkind = new Public.CProcessKind();
                processkind.sort = int.Parse(numericUpDown_sort.Value.ToString());
                processkind.ProcessKind = txt_ProcessKind.Text;                
                processkind.bStop = 1;
                processkind.Create();

                Public.PublicForm Forms = new Public.PublicForm();               

                DataTable dt = Forms.PATEventProcess.GetPKind;
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

        private void AddProcessKind_Load(object sender, EventArgs e)
        {           
            this.patStatusT_DropTableAdapter.Fill(this.qS_DataSet._PatStatusT_Drop);

        }

        private void AddProcessKind_KeyDown(object sender, KeyEventArgs e)
        {
            Public.Utility.ControlTab(e);
        }
    }
}