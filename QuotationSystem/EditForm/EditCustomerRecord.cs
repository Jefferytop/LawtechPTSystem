using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.EditForm
{
    public partial class EditCustomerRecord : Form
    {
        public EditCustomerRecord()
        {
            InitializeComponent();
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

        private int iTrackingRecordKey = -1;
        /// <summary>
        /// 來往記錄key
        /// </summary>
        public int TrackingRecordKey
        {
            get { return iTrackingRecordKey; }
            set { iTrackingRecordKey = value; }
        }

        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditCustomerRecord_Load(object sender, EventArgs e)
        {
            Public.CCustomerTrackingRecord Edit = new Public.CCustomerTrackingRecord();
            Public.CCustomerTrackingRecord.ReadOne(TrackingRecordKey, ref Edit);

            txt_ComplaintsComments.Text = Edit.ComplaintsComments;
            txt_TrackingTransactions.Text = Edit.TrackingTransactions;
            txt_VitalRecord.Text = Edit.VitalRecord;
        }

        private void but_OK_Click(object sender, EventArgs e)
        {
            if (txt_ComplaintsComments.Text.Trim() != "" || txt_TrackingTransactions.Text.Trim() != "" || txt_VitalRecord.Text.Trim() != "")
            {

                Public.CCustomerTrackingRecord Edit = new Public.CCustomerTrackingRecord();
                Public.CCustomerTrackingRecord.ReadOne(TrackingRecordKey, ref Edit);
                Edit.ComplaintsComments = txt_ComplaintsComments.Text;
                Edit.TrackingTransactions = txt_TrackingTransactions.Text;
                Edit.VitalRecord = txt_VitalRecord.Text;
                Edit.LastModifyWorker = Properties.Settings.Default.WorkerName;               
                Edit.Update();

                Public.PublicForm Forms = new Public.PublicForm();
                if (Forms.ApplicantList != null && Forms.ApplicantList.DT_CustomerTrackingRecordT != null)
                {
                    DataRow dr = Forms.ApplicantList.DT_CustomerTrackingRecordT.Rows.Find(iTrackingRecordKey);
                    DataRow drV = Public.CApplicantPublicFunction.GetCustomerTrackingRecordDataRow(Edit.TrackingRecordKey.ToString());
                    
                    for (int i = 0; i < drV.ItemArray.Length; i++)
                    {
                        if (Forms.ApplicantList.DT_CustomerTrackingRecordT.Columns[i].ReadOnly == false)
                        {
                            dr.ItemArray[i] = drV.ItemArray[i];
                        }                       
                    }
                    dr.AcceptChanges();
                }
                MessageBox.Show("編輯成功", "提示訊息");
                this.Close();
            }
            else
            {
                MessageBox.Show("請確認是否填寫資料", "提示訊息");
            }
        }
    }
}
