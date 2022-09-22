using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.AddFrom
{
    public partial class AddMACsetting : Form
    {
        public AddMACsetting()
        {
            InitializeComponent();
        }

   

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddMACsetting_Load(object sender, EventArgs e)
        {
            //cmb_Account.Items.Add("");
            //cmb_Account.Items.Add(Properties.Settings.Default.WorkerName);
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            if (txt_MAC.Text.Trim() == "")
            {
                MessageBox.Show("MAC不得為空白，請確認", "提示訊息");
                return;
            }

            Public.CMACsettingT add = new Public.CMACsettingT();

            bool isExist = false;
            add.CheckValueExist("MAC", txt_MAC.Text.Trim(), ref isExist);

            if(isExist)
            {
                txt_MAC.Focus();
                MessageBox.Show("該MAC位址已存在，請重新確認!!");
                return;
            }

            add.MAC = txt_MAC.Text;
            add.IsEnable = checkBox_IsEnable.Checked;
            add.Account = cmb_Account.Text;
            add.Memo = txt_Memo.Text;           
            add.Creator = Properties.Settings.Default.WorkerName;
            add.Create();

            Public.PublicForm Forms = new Public.PublicForm();
            if (Forms.MACsetting != null && Forms.MACsetting.DT_MACsettingT != null)
            {
                DataRow dr = Forms.MACsetting.DT_MACsettingT.NewRow();
                DataRow drV = Public.CMacSettingPublicFunction.GetMacSettingListDataRow(add.MACkey.ToString());
                dr.ItemArray = drV.ItemArray;
                Forms.MACsetting.DT_MACsettingT.Rows.Add(dr);
                dr.AcceptChanges();
            }
            MessageBox.Show("新增MAC位址成功  " + add.MAC, "提示訊息");
            this.Close();
        }
    }
}
