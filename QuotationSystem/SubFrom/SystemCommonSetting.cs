using System;
using System.Windows.Forms;

namespace LawtechPTSystem.SubFrom
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
            txt_LoginLogo.Text = common.LoginLogo;
            txt_QuotationLogo.Text = common.QuotationLogo;

            switch (common.HomePageEvent)
            {
                case "0":
                    radioButton_EventSimple.Checked = true;
                    break;
                case "9":
                    radioButton_EventComplete.Checked = true;
                    break;
                default:
                    radioButton_EventComplete.Checked = true;
                    break;
            }

            switch (common.HistoryRecordMode)
            {
                case "0":
                    radioButton_HistoryRecordMode_0.Checked = true;
                    break;
                case "10":
                    radioButton_HistoryRecordMode_10.Checked = true;
                    break;
                case "99":
                    radioButton_HistoryRecordMode_99.Checked = true;
                    break;
                default:
                    radioButton_HistoryRecordMode_99.Checked = true;
                    break;
            }

            #region 首頁是否啟用新增事件記錄
            if (common.AddEnable == "1")
            {
                radioButton_AddEnable.Checked = true;
            }
            else
            {
                radioButton_AddNoEnable.Checked = true;
            } 
            #endregion

            txt_LoginLogo_Leave(null,null);
            txt_QuotationLogo_Leave(null,null);
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

            Public.CStatueRecordT.ReadOne("StatusName='LoginLogo'", ref sr);
            sr.Value = txt_LoginLogo.Text;
            sr.Update();

            Public.CStatueRecordT.ReadOne("StatusName='QuotationLogo'", ref sr);
            sr.Value = txt_QuotationLogo.Text;
            sr.Update();          

            #region HomePageEvent 0:僅僅「處理結果」、「備註」 欄位可編輯 ; 9:完整編輯事件記錄
            string strHomePageEvent = "9";
            if (radioButton_EventSimple.Checked)
            {
                strHomePageEvent = "0";
            }
            else if (radioButton_EventComplete.Checked)
            {
                strHomePageEvent = "9";
            }

            Public.CStatueRecordT.ReadOne("StatusName='HomePageEvent'", ref sr);
            sr.Value = strHomePageEvent;
            sr.Update();
            #endregion

            # region HistoryRecordMode 不提供檢視案件詳細資料; 10:供檢視案件詳細資料+事件記錄 ; 99:檢視完整案件詳細資料
            string strHistoryRecordMode = "99";
            if (radioButton_HistoryRecordMode_0.Checked)
            {
                strHistoryRecordMode = "0";
            }
            else if (radioButton_HistoryRecordMode_10.Checked)
            {
                strHistoryRecordMode = "10";
            }
            else if (radioButton_HistoryRecordMode_99.Checked)
            {
                strHistoryRecordMode = "99";
            }
            Public.CStatueRecordT.ReadOne("StatusName='HistoryRecordMode' ", ref sr);
            sr.Value = strHistoryRecordMode;
            sr.Update();
            #endregion

            #region 首頁啟用新增事件記錄功能
            string strAddEnable = "0";
            if (radioButton_AddEnable.Checked)
            {
                strAddEnable = "1";
            }
            else
            {
                strAddEnable = "0";
            }
            Public.CStatueRecordT.ReadOne("StatusName='AddEnable' ", ref sr);
            sr.Value = strAddEnable;
            sr.Update(); 
            #endregion

            Properties.Settings.Default.SystemName = txt_SystemName.Text;
            Properties.Settings.Default.EnableAddFee = chb_EnableAddFee.Checked;
            Properties.Settings.Default.EnableAddPayment = chb_EnableAddPayment.Checked;
            Properties.Settings.Default.WebSystemName = txt_WebSystemName.Text;
            Properties.Settings.Default.GoogleAnalytics = txt_GA.Text;
            Properties.Settings.Default.QuotationLogo = txt_QuotationLogo.Text;
            Properties.Settings.Default.HomePageEvent = strHomePageEvent;
            Properties.Settings.Default.HistoryRecordMode = strHistoryRecordMode;
            Properties.Settings.Default.Save();

            MessageBox.Show("儲存成功");

            btnConfirm.Enabled = true;
            this.Close();
        }

        /// <summary>
        /// 登入的logo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_LoginLogo_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_LoginLogo.Text.Trim()))
            {
                pictureBox_LoginLogo.ImageLocation = txt_LoginLogo.Text.Trim();
            }
            else {
                pictureBox_LoginLogo.ImageLocation = "";
            }
        }

        /// <summary>
        /// 請款單/報表的logo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_QuotationLogo_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_QuotationLogo.Text.Trim()))
            {
                pictureBox_QuotationLogo.ImageLocation = txt_QuotationLogo.Text.Trim();
            }
            else
            {
                pictureBox_QuotationLogo.ImageLocation = "";
            }
        }
    }
}
