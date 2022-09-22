using System;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.SubFrom
{
    /// <summary>
    /// 系統通用設定
    /// </summary>
    public partial class SystemCommonSetting : Form
    {
        public SystemCommonSetting()
        {
            InitializeComponent();
        }

        private void SystemCommonSetting_Load(object sender, EventArgs e)
        {
            Public.CCommonPublicFunction common = new Public.CCommonPublicFunction();
            txt_SystemName.Text = common.SystemName;
            txt_WebSystemName.Text = common.WebSystemName;
            txt_GA.Text = common.GoogleAnalytics;
            chb_EnableAddFee.Checked = common.EnableAddFee;
            chb_EnableAddPayment.Checked = common.EnableAddPayment;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            btnConfirm.Enabled = false;

            Public.CStatueRecordT sr = new Public.CStatueRecordT();
            Public.CStatueRecordT.ReadOne("StatusName='SystemName'", ref sr);
            sr.Value = txt_SystemName.Text;
            sr.Update();

            Public.CStatueRecordT.ReadOne("StatusName='EnableAddFee'", ref sr);
            sr.Value = chb_EnableAddFee.Checked ? "1" : "0"; // 是否啟用新增費用功能; 1: 停用 , 0:不停用
            sr.Update();

            Public.CStatueRecordT.ReadOne("StatusName='EnableAddPayment'", ref sr);
            sr.Value = chb_EnableAddPayment.Checked ? "1" : "0"; // 是否啟用新增費用功能; 1: 停用 , 0:不停用
            sr.Update();

            Public.CStatueRecordT.ReadOne("StatusName='WebSystemName'", ref sr);
            sr.Value = txt_WebSystemName.Text;
            sr.Update();

            Public.CStatueRecordT.ReadOne("StatusName='GoogleAnalytics'", ref sr);
            sr.Value = txt_GA.Text;
            sr.Update();

            Properties.Settings.Default.SystemName = txt_SystemName.Text;
            Properties.Settings.Default.EnableAddFee = chb_EnableAddFee.Checked;
            Properties.Settings.Default.EnableAddPayment = chb_EnableAddPayment.Checked;
            Properties.Settings.Default.Save();            

            MessageBox.Show("儲存成功");

            btnConfirm.Enabled = true;
            this.Close();
        }

       

     
    }
}
