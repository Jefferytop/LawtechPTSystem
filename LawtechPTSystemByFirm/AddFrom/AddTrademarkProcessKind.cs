using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.AddFrom
{
    public partial class AddTrademarkProcessKind : Form
    {
        public AddTrademarkProcessKind()
        {
            InitializeComponent();
        }

        private void AddTrademarkProcessKind_Load(object sender, EventArgs e)
        {
            numericUpDown_sort.Value = Public.Utility.GetMaxSort("TrademarkProcessKindT");
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
                    MessageBox.Show("請輸入標準流程名稱");
                    txt_ProcessKind.Focus();
                    return;
                }

                Public.CTrademarkProcessKind processkind = new Public.CTrademarkProcessKind();
                processkind.sort = int.Parse(numericUpDown_sort.Value.ToString());
                processkind.ProcessKind = txt_ProcessKind.Text;
                processkind.bStop = 1;
                processkind.Create();

                Public.PublicForm Forms = new Public.PublicForm();

                DataTable dt = Forms.TrademarkEventProcess.GetPKind;
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
