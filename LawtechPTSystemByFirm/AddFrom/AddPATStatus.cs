using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.AddFrom
{
    public partial class AddPATStatus : Form
    {
        public AddPATStatus()
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
                Public.CPatStatus status = new LawtechPTSystemByFirm.Public.CPatStatus();
                status.bStop = true;
                status.Sort = int.Parse(numericUpDown_SN.Value.ToString());
                status.Status = txt_Status.Text;
                status.Creator = Properties.Settings.Default.WorkerName;
                status.Create();

                Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
                DataTable dt = Forms.PATStatusMF.GetPatStatusT;
                DataRow dr = dt.NewRow();
                dr["bStop"] = 1;
                dr["Sort"] = status.Sort;
                dr["Status"] = status.Status;
                dr["StatusID"] = status.StatusID;
                dr["Creator"] = status.Creator;
                dr["CreateDateTime"] = status.CreateDateTime;
                dt.Rows.Add(dr);
                dt.AcceptChanges();

                MessageBox.Show("新增成功");
                this.Close();

            }
        }

        private void AddPATStatus_Load(object sender, EventArgs e)
        {
            numericUpDown_SN.Value = Public.Utility.GetMaxSort("PatStatusT");
        }

        private void AddPATStatus_KeyDown(object sender, KeyEventArgs e)
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