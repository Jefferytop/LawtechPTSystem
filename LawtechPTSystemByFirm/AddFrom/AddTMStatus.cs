using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.AddFrom
{
    public partial class AddTMStatus : Form
    {
        public AddTMStatus()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_Status.Text != "")
            {
                Public.CTMStatus status = new LawtechPTSystemByFirm.Public.CTMStatus();
                status.bStop = true;
                status.Sort = int.Parse(numericUpDown_SN.Value.ToString());
                status.Status = txt_Status.Text;
                status.Create();

                Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
                DataTable dt = Forms.TMStatusMF.GetTMStatusT;
                DataRow dr = dt.NewRow();
                dr["bStop"] = 1;
                dr["Sort"] = status.Sort;
                dr["Status"] = status.Status;
                dr["TMStatusID"] = status.TMStatusID;
                dt.Rows.Add(dr);
                dt.AcceptChanges();

                MessageBox.Show("新增成功");
                this.Close();

            }
            else
            {
                MessageBox.Show("請輸入案件階段");
                return;
            }
        }

        private void AddTMStatus_Load(object sender, EventArgs e)
        {
            numericUpDown_SN.Value = Public.Utility.GetMaxSort("TMStatusT");
        }

        private void AddTMStatus_KeyDown(object sender, KeyEventArgs e)
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
