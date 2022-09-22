using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.AddFrom
{
    public partial class AddInventor : Form
    {
        public AddInventor()
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

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            if (txt_InventorName.Text.Trim() == "")
            {
                MessageBox.Show("發明人姓名不得為空白，請確認", "提示訊息");
                return;
            }
            Public.CInventor add = new LawtechPTSystemByFirm.Public.CInventor();
            add.ApplicantKey = ApplicantKey;
            add.InventorName = txt_InventorName.Text;
            add.FamilyName = txt_FamilyName.Text;
            add.GivenName = txt_GivenName.Text;
            add.InventorID = txt_ID.Text;
            add.Address = txt_Address.Text;
            add.Creator = Properties.Settings.Default.WorkerName;
            add.Create();

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            if (Forms.ApplicantList != null && Forms.ApplicantList.DT_Inventor != null)
            {
                DataRow dr = Forms.ApplicantList.DT_Inventor.NewRow();
                DataRow drV = Public.CApplicantPublicFunction.GetInventorDataRow(add.InventorKey.ToString());
                dr.ItemArray = drV.ItemArray;
                Forms.ApplicantList.DT_Inventor.Rows.Add(dr);
                dr.AcceptChanges();
            }
            MessageBox.Show("新增發明人成功  " + add.InventorName, "提示訊息");
            this.Close();
        }

        private void AddInventor_KeyDown(object sender, KeyEventArgs e)
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
