using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.AddFrom
{
    public partial class AddHandleProcess : Form
    {
        public AddHandleProcess()
        {
            InitializeComponent();
        }

        Public.PublicForm Forms = new Public.PublicForm();


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtHandle.Text == "")
            {
                MessageBox.Show("請輸入流程");
                txtHandle.Focus();
                return;
            }

            Public.CProcessStep ProcessStep = new Public.CProcessStep();
            ProcessStep.sort = int.Parse(numericUpDown_sort.Value.ToString());
            ProcessStep.Handle = txtHandle.Text;

            if (cbStatus.SelectedValue == null)
            { ProcessStep.Status = -1; }
            else
            { ProcessStep.Status = int.Parse(cbStatus.SelectedValue.ToString()); }         

            ProcessStep.Days = int.Parse(nudDays.Text);
            ProcessStep.Hours = int.Parse(nudHours.Text);
            ProcessStep.Minutes = int.Parse(nudMinutes.Text);
            ProcessStep.IsUsing = chkIsUsing.Checked ;
            ProcessStep.ProcessKEY = (int)Forms.PATEventProcess.dataGridView_ProcessKind.CurrentRow.Cells["ProcessKEY"].Value;
            ProcessStep.Create();

            //handle.
            DataTable dt = Forms.PATEventProcess.GetPHandle;

            DataRow dr = dt.NewRow();
            dr["ProcessHandleKEY"] = ProcessStep.ProcessHandleKEY;
            dr["sort"] = ProcessStep.sort;
            dr["Handle"] = ProcessStep.Handle;
            dr["Status"] = ProcessStep.Status;            
            dr["Days"] = ProcessStep.Days;
            dr["Hours"] = ProcessStep.Hours;
            dr["Minutes"] = ProcessStep.Minutes;
            dr["IsUsing"] = ProcessStep.IsUsing;
            dr["ProcessKEY"] = ProcessStep.ProcessKEY;
            dt.Rows.Add(dr);
            dt.AcceptChanges();

           
            MessageBox.Show("新增成功");
            this.Close();
        }

        private void AddHandleProcess_Load(object sender, EventArgs e)
        {            
            this.patStatusT_DropTableAdapter.Fill(this.qS_DataSet._PatStatusT_Drop);
            numericUpDown_sort.Value = Public.Utility.GetMaxSort("ProcessStepET");
        }

        private void AddHandleProcess_KeyDown(object sender, KeyEventArgs e)
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