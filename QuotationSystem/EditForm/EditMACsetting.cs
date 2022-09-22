using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.EditForm
{
    public partial class EditMACsetting : Form
    {
        //來源資料表
        private string sourceTableName = "MACsettingT";

        public EditMACsetting()
        {
            InitializeComponent();
        }

        private int iMACkey = 0;
        /// <summary>
        /// 取得目前該MAC的Key值
        /// </summary>
        public int MACkey
        {
            get
            {
                return iMACkey;
            }
            set {
                iMACkey = value;
            }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditMACsetting_Load(object sender, EventArgs e)
        {
            //鎖定該筆資料
            Public.CommonFunctions.LockRecordAuth(sourceTableName, Properties.Settings.Default.WorkerKEY, "MACkey=" + iMACkey);          

            Public.CMACsettingT mac = new Public.CMACsettingT();
            Public.CMACsettingT.ReadOne(iMACkey, ref mac);

            //cmb_Account.Items.Add("");
            //cmb_Account.Items.Add(Properties.Settings.Default.WorkerName);
            //cmb_Account.Items.Add(mac.Account);

            txt_MAC.Text = mac.MAC;
            txt_Memo.Text = mac.Memo;
            cmb_Account.Text = mac.Account;
            if (mac.IsEnable.HasValue)
            {
                checkBox_IsEnable.Checked = mac.IsEnable.Value;
            }
           


        }

        private void butOK_Click(object sender, EventArgs e)
        {
            if (txt_MAC.Text.Trim() == "")
            {
                MessageBox.Show("MAC不得為空白，請確認", "提示訊息");
                return;
            }

            Public.CMACsettingT edit = new Public.CMACsettingT();
            Public.CMACsettingT.ReadOne(iMACkey, ref edit);
            bool isExist = false;
            edit.CheckValueExist("MAC", txt_MAC.Text.Trim(), ref isExist,false);

            if (isExist)
            {
                txt_MAC.Focus();
                MessageBox.Show("該MAC位址已存在，請重新確認!!");
                return;
            }
            edit.IsEnable = checkBox_IsEnable.Checked;
            edit.MAC = txt_MAC.Text;
            edit.Account = cmb_Account.Text;
            edit.Memo = txt_Memo.Text;
            edit.LastModifyWorker = Properties.Settings.Default.WorkerName;
            edit.Update();

            Public.PublicForm Forms = new Public.PublicForm();
            if (Forms.MACsetting != null && Forms.MACsetting.DT_MACsettingT != null)
            {
                DataRow dr = Forms.MACsetting.DT_MACsettingT.Rows.Find(edit.MACkey);
                DataRow drV = Public.CMacSettingPublicFunction.GetMacSettingListDataRow(edit.MACkey.ToString());
                dr.ItemArray = drV.ItemArray;                
                dr.AcceptChanges();
            }
            MessageBox.Show("修改成功  " + edit.MAC, "提示訊息");
            this.Close();
        }
    }
}
