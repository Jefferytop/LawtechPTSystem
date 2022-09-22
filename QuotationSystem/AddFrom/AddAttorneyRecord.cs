using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.AddFrom
{
    public partial class AddAttorneyRecord : Form
    {
        public AddAttorneyRecord()
        {
            InitializeComponent();
        }

        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private int iAttorneyKey = -1;
        /// <summary>
        /// 事務所ID
        /// </summary>
        public int AttorneyKey
        {
            get { return iAttorneyKey; }
            set { iAttorneyKey = value; }
        }       

        private void but_OK_Click(object sender, EventArgs e)
        {

            Public.CAttorneyTrackingRecord add = new Public.CAttorneyTrackingRecord();
            add.AttorneyKey = iAttorneyKey;
            add.ComplaintsComments = txt_ComplaintsComments.Text;
            add.TrackingTransactions = txt_TrackingTransactions.Text;
            add.VitalRecord = txt_VitalRecord.Text;
            add.Creator = Properties.Settings.Default.WorkerName;
            add.CreateDateTime = DateTime.Now;           
            add.Create();

            MessageBox.Show("新增成功", "提示訊息");
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void AddAttorneyRecord_KeyDown(object sender, KeyEventArgs e)
        {
            Public.Utility.ControlTab(e);
        }
    }
}
