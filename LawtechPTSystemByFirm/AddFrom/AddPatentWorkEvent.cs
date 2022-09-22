using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.AddFrom
{
    public partial class AddPatentWorkEvent : Form
    {
        public AddPatentWorkEvent()
        {
            InitializeComponent();
        }

        private int iEventType = 1;
        /// <summary>
        /// 1.事件記錄  2.來函 3.年費
        /// </summary>
        public int EventType
        {
            get { return iEventType; }
            set { iEventType = value; }
        }

        private int iEventID = -1;
        /// <summary>
        /// 事件(委辦、來函)的 ID
        /// </summary>
        public int EventID
        {
            get { return iEventID; }
            set { iEventID = value; }
        }

        private void AddPatentWorkEvent_Load(object sender, EventArgs e)
        {
            
            this.worker_QuitNTableAdapter.Fill(this.qS_DataSet.Worker_QuitN);

            maskedTextBox_WorkDate.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");

            comboBox_Worker.SelectedValue = Properties.Settings.Default.WorkerKEY;

        }

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void but_OK_Click(object sender, EventArgs e)
        {
            if (txt_WorkContent.Text.Trim() != "")
            {
                Public.CPatWorkReport add = new LawtechPTSystemByFirm.Public.CPatWorkReport();
                add.EventID = iEventID;
                add.EventType = iEventType;
                add.WorkContent = txt_WorkContent.Text;
                add.Memo = txt_Memo.Text;

                DateTime dtEstimateDateTime ;
                bool IsEstimateDateTime = DateTime.TryParse(maskedTextBox_EstimateDateTime.Text.Replace("   :",""), out dtEstimateDateTime);
                if (IsEstimateDateTime) add.EstimateDateTime = dtEstimateDateTime;
                else add.EstimateDateTime = null;

                DateTime dtWorkDate;
                bool IsWorkDate = DateTime.TryParse(maskedTextBox_WorkDate.Text.Replace("   :", ""), out dtWorkDate);
                if (IsWorkDate) add.WorkDate = dtWorkDate;
                else add.WorkDate = null;

                DateTime dtStartTime ;
                bool IsStartTime = DateTime.TryParse(maskedTextBox_StartTime.Text, out dtStartTime);
                if (IsStartTime) add.StartTime = dtStartTime;
                else add.StartTime =null;

                add.Worker = (int)comboBox_Worker.SelectedValue;
                add.Create();

                Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
                if (Forms.PATControlEventList != null)
                {
                    DataRow dr = Forms.PATControlEventList.DT_PatWorkReportT.NewRow();
                    DataRow drV = Public.CPatentPublicFunction.GetPatWorkReport(add.WorkReportID.ToString());
                    dr.ItemArray = drV.ItemArray;
                    Forms.PATControlEventList.DT_PatWorkReportT.Rows.Add(dr);
                    dr.AcceptChanges();
                }
                MessageBox.Show("新增成功", "提示訊息", MessageBoxButtons.OK);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("事件工作內容不得為空白，請輸入事件工作內容不得為空白");
                return;
            }
        }

        private void maskedTextBox_WorkDate_DoubleClick(object sender, EventArgs e)
        {
            MaskedTextBox mtb = (MaskedTextBox)sender;
            DateTime dt;
            bool IsSuccess = DateTime.TryParse(mtb.Text, out dt);
            if (!IsSuccess)
            {
                mtb.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
            }
        }

        private void AddPatentWorkEvent_KeyDown(object sender, KeyEventArgs e)
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
