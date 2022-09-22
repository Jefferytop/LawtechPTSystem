using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.AddFrom
{
    public partial class AddCustomerRecord : Form
    {
        public AddCustomerRecord()
        {
            InitializeComponent();
        }

        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
               

        private int iApplicantKey = -1;
        /// <summary>
        /// 客戶ID
        /// </summary>
        public int ApplicantKey
        {
            get { return iApplicantKey; }
            set { iApplicantKey = value; }
        }

        private void but_OK_Click(object sender, EventArgs e)
        {
            if (txt_ComplaintsComments.Text.Trim() != "" || txt_TrackingTransactions.Text.Trim() != "" || txt_VitalRecord.Text.Trim() != "")
            {
                Public.CCustomerTrackingRecord add = new LawtechPTSystemByFirm.Public.CCustomerTrackingRecord();

                add.ApplicantKey = iApplicantKey;
                add.ComplaintsComments = txt_ComplaintsComments.Text;
                add.TrackingTransactions = txt_TrackingTransactions.Text;
                add.VitalRecord = txt_VitalRecord.Text;
                add.Creator = Properties.Settings.Default.WorkerName;
                add.Create();

                Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
                if (Forms.ApplicantList != null && Forms.ApplicantList.DT_CustomerTrackingRecordT != null)
                {
                    DataRow dr = Forms.ApplicantList.DT_CustomerTrackingRecordT.NewRow();
                    DataRow drV = Public.CApplicantPublicFunction.GetCustomerTrackingRecordDataRow(add.TrackingRecordKey.ToString());
                    dr.ItemArray = drV.ItemArray;

                    Forms.ApplicantList.DT_CustomerTrackingRecordT.Rows.Add(dr);
                    dr.AcceptChanges();
                }
                MessageBox.Show("新增成功", "提示訊息");
                this.Close();
            }
            else
            {
                MessageBox.Show("請確認是否填寫資料", "提示訊息");
            }
        }

        private void AddCustomerRecord_KeyDown(object sender, KeyEventArgs e)
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
