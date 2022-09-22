using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.AddFrom
{
    public partial class AddTrademarkHandleProcess : Form
    {
        public AddTrademarkHandleProcess()
        {
            InitializeComponent();
        }

        private int iProcessKEY = -1;
        /// <summary>
        /// 商標事件ID
        /// </summary>
        public int ProcessKEY
        {
            get { return iProcessKEY; }
            set { iProcessKEY = value; }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtHandle.Text == "")
            {
                MessageBox.Show("請輸入【處理程序】");
                txtHandle.Focus();
                return;
            }
            Public.PublicForm Forms = new Public.PublicForm();
            Public.CTrademarkProcessStepE ProcessStep = new Public.CTrademarkProcessStepE();
            ProcessStep.sort = int.Parse(numericUpDown_sort.Value.ToString());
            ProcessStep.Handle = txtHandle.Text;

             if (cbStatus.SelectedValue == null || (int)cbStatus.SelectedValue == -1)
            {
                ProcessStep.Status = null;
            }
            else
            {
                ProcessStep.Status = int.Parse(cbStatus.SelectedValue.ToString());
            }

            if (comboBox_DefultWorker.SelectedValue == null || (int)comboBox_DefultWorker.SelectedValue == -1)
            {
                ProcessStep.DefualtWorker = null;
            }
            else
            {
                ProcessStep.DefualtWorker = int.Parse(comboBox_DefultWorker.SelectedValue.ToString());
            }

            ProcessStep.Days = int.Parse(nudDays.Text);
            ProcessStep.Hours = int.Parse(nudHours.Text);
            ProcessStep.Minutes = int.Parse(nudMinutes.Text);
            ProcessStep.IsUsing = chkIsUsing.Checked;
            ProcessStep.ProcessKEY = iProcessKEY;
            ProcessStep.Create();

            //handle.
           
            DataTable dt = Forms.TrademarkEventProcess.GetPHandle;

            DataRow dr = dt.NewRow();
            dr["ProcessHandleKEY"] = ProcessStep.ProcessHandleKEY;
            dr["sort"] = ProcessStep.sort;
            dr["Handle"] = ProcessStep.Handle;
          
            if (ProcessStep.Status.HasValue)
            {
                dr["Status"] = ProcessStep.Status;
            }
            else
            {
                dr["Status"] = DBNull.Value; ;
            }
            dr["Days"] = ProcessStep.Days;
            dr["Hours"] = ProcessStep.Hours;
            dr["Minutes"] = ProcessStep.Minutes;
            dr["IsUsing"] = ProcessStep.IsUsing;
            dr["ProcessKEY"] = ProcessStep.ProcessKEY;
            if (ProcessStep.DefualtWorker.HasValue)
            {
                dr["DefualtWorker"] = ProcessStep.DefualtWorker;
            }
            else
            {
                dr["DefualtWorker"] = DBNull.Value; ;
            }
            dt.Rows.Add(dr);
            dt.AcceptChanges();

            MessageBox.Show("新增成功");

            this.button1.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void AddTrademarkHandleProcess_Load(object sender, EventArgs e)
        {
           
            this.tMStatusTTableAdapter.Fill(this.dataSet_Drop.TMStatusT);

            this.workerTTableAdapter.Fill(this.dataSet_Drop.WorkerT,false);

            numericUpDown_sort.Value = Public.Utility.GetMaxSort("TrademarkProcessStepET",sqlQuery: "ProcessKEY="+ iProcessKEY.ToString());
        }
    }
}
