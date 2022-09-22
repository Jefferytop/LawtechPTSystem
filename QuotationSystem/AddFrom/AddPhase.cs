using System;
using System.Windows.Forms;

namespace LawtechPTSystem.AddFrom
{
    public partial class AddPhase : Form
    {
        public AddPhase()
        {
            InitializeComponent();
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            if (txtPhase.Text.Trim() == "")
            {
                MessageBox.Show("請輸入所屬階段");
                txtPhase.Focus();
                return;
            }

            Public.CPhase phaseC = new Public.CPhase();
            phaseC.Sort = int.Parse(numericUpDown_Sort.Value.ToString());
            phaseC.PhaseName = txtPhase.Text;
            phaseC.Create();
            butOK.DialogResult = DialogResult.OK;
            MessageBox.Show("新增成功\r\n所屬階段：" + phaseC.PhaseName, "提示訊息");
          
            this.Close();
        }
    }
}
