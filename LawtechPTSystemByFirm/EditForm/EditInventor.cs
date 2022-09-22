using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.EditForm
{
    public partial class EditInventor : Form
    {
        public EditInventor()
        {
            InitializeComponent();
        }

        private int iApplicantKey = -1;
        /// <summary>
        /// 申請人Key值
        /// </summary>
        public int ApplicantKey
        {
            get { return iApplicantKey; }
            set { iApplicantKey = value; }
        }

        private int iInventorKey = -1;
        /// <summary>
        /// 發明人Key值
        /// </summary>
        public int InventorKey
        {
            get { return iInventorKey; }
            set { iInventorKey = value; }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditInventor_Load(object sender, EventArgs e)
        {

            //鎖定該筆資料
            Public.CommonFunctions.LockRecordAuth("InventorT", Properties.Settings.Default.WorkerKEY, "InventorKey=" + iApplicantKey);

            Public.CInventor edit = new LawtechPTSystemByFirm.Public.CInventor();
            Public.CInventor.ReadOne(InventorKey, ref edit);

            txt_InventorName.Text = edit.InventorName;
            txt_FamilyName.Text = edit.FamilyName;
            txt_GivenName.Text = edit.GivenName;
            txt_ID.Text = edit.InventorID;
            txt_Address.Text = edit.Address;
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            if (txt_InventorName.Text.Trim() == "")
            {
                MessageBox.Show("發明人姓名不得為空白，請確認", "提示訊息");
                return;
            }

            Public.CInventor edit = new LawtechPTSystemByFirm.Public.CInventor();           
            Public.CInventor.ReadOne(InventorKey, ref edit);
            edit.ApplicantKey = ApplicantKey;
            edit.InventorName = txt_InventorName.Text;
            edit.FamilyName = txt_FamilyName.Text;
            edit.GivenName = txt_GivenName.Text;
            edit.InventorID = txt_ID.Text;
            edit.Address = txt_Address.Text;
            edit.LastModifyWorker = Properties.Settings.Default.WorkerName;
            edit.Update();

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            if (Forms.ApplicantList != null && Forms.ApplicantList.DT_Inventor != null)
            {
                DataRow dr = Forms.ApplicantList.DT_Inventor.Rows.Find(InventorKey);
                DataRow drV = Public.CApplicantPublicFunction.GetInventorDataRow(edit.InventorKey.ToString());
                for (int i = 0; i < drV.ItemArray.Length; i++)
                {
                    if (Forms.ApplicantList.DT_Inventor.Columns[i].ReadOnly == false)
                    {
                        dr.ItemArray[i] = drV.ItemArray[i];
                    }
                }
                dr.AcceptChanges();
            }
            MessageBox.Show("編輯發明人成功  " + edit.InventorName, "提示訊息");
            this.Close();
        }
    }
}
