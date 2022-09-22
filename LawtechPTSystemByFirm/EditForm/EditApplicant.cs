using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.EditForm
{
    public partial class EditApplicant : Form
    {
        public EditApplicant()
        {
            InitializeComponent();
        }

        //來源資料表
        private string sourceTableName = "ApplicantT";


        private int iApplicantKey = -1;
        /// <summary>
        /// 客戶KEY值
        /// </summary>
        public int ApplicantKey
        {
            get { return iApplicantKey; }
            set { iApplicantKey = value; }
        }


        #region EditApplicant_Load
        private void EditApplicant_Load(object sender, EventArgs e)
        {
           
            this.applicantSourceTTableAdapter.Fill(this.dataSet_Applicant.ApplicantSourceT);
           
            
                     
            //鎖定該筆資料
            Public.CommonFunctions.LockRecordAuth(sourceTableName, Properties.Settings.Default.WorkerKEY, "ApplicantKey=" + iApplicantKey);

            //企業實體
            this.largeEntyTTableAdapter.Fill(this.dataSet_Applicant.LargeEntyT);             

            //客戶評價
            this.customerEvaluationTTableAdapter.Fill(this.dataSet_Drop.CustomerEvaluationT);

            //所屬母公司
            this.applicantTTableAdapter.Fill(this.dataSet_Drop.ApplicantT);

            //本所人員
            workerTTableAdapter.Fill(dataSet_Drop.WorkerT, false);

            //產業別
            businessKindTTableAdapter.Fill(dataSet_Applicant.BusinessKindT);

            //請款方式
            this.recWayTTableAdapter.Fill(this.dataSet_Applicant.RecWayT);

            //客戶種類
            this.clientKindTTableAdapter.Fill(dataSet_Applicant.ClientKindT);

            Public.CApplicant app = new Public.CApplicant();
            Public.CApplicant.ReadOne(iApplicantKey, ref app);

            txt_ApplicantSymbol.Text = app.ApplicantSymbol;
            txt_ApplicantName.Text = app.ApplicantName;
            txt_ApplicantNameEn.Text = app.ApplicantNameEn;
            txt_Addr.Text = app.Address;
            txt_AddrEn.Text = app.AddressEn;
            txt_LiaisonAddr.Text = app.ContactAddr;
            txt_Account.Text = app.Account;
            txt_Password.Text = app.Password;
            txt_Chage.Text = app.Chage;
            txt_FAX.Text = app.FAX;
            txt_ID.Text = app.ID;
            txt_TEL.Text = app.TEL;
            txt_PrincipalName.Text = app.PrincipalName;//代表人
            txt_PrincipalNameEn.Text = app.PrincipalNameEn;//代表人(英)
            txt_Receiptor.Text = app.Receiptor;//收據抬頭
            txt_Remark.Text = app.Remart;
            txt_SendTitle.Text = app.SendTitle;//信件抬頭
            txt_SourceDescription.Text = app.SourceDescription;//客戶來源說明
            Check_P.Checked = app.P.HasValue?app.P.Value:false;
            Check_T.Checked = app.T ?? false;
            Check_C.Checked = app.C ?? false;
            Check_L.Checked = app.L ?? false;
            Check_E.Checked = app.E?? false;
            checkBox_LawVIP.Checked = app.LawVIP?? false;
            comboBox_LargeEnty.SelectedValue = app.LargeEnty.HasValue?app.LargeEnty.Value:0;
            if (app.MainCorp.HasValue)
            {
                comboBox_MainCorp.SelectedValue = app.MainCorp.Value;//所屬母公司
            }
            else
            {
                comboBox_MainCorp.SelectedIndex = 0;
            }

            //客戶種類
            if (app.ClientKind.HasValue)
            {
                comboBox_ClientKind.SelectedValue = app.ClientKind.Value;
            }
            else
            {
                comboBox_ClientKind.SelectedIndex = 0;
            }

            if (app.Source.HasValue)
            {
                comboBox_Source.SelectedValue = app.Source.Value;//客戶來源
            }
            else {
                comboBox_Source.SelectedIndex = 0;
            }

            if (app.RecWay.HasValue)
            {
                comboBox_RecWay.SelectedValue = app.RecWay;//付款方式
            }

            if (app.Worker.HasValue)
            {
                comboBox_Worker.SelectedValue = app.Worker.Value;//本所服務人員
            }

            if (app.BusinessKind.HasValue)
            {
                comboBox_BusinessKind.SelectedValue = app.BusinessKind; //產業別
            }

            txt_email.Text = app.Email;
            txt_Business.Text = app.Business;
            txt_WebSite.Text = app.WebSite;
            comboBox_Evaluation.Text = app.Evaluation;
            txt_CollectionRecord.Text = app.CollectionRecord;
            txt_Capital.Text = app.Capital;

            if (app.StartedDate.HasValue)
            {
                maskedTextBox_StartedDate.Text = app.StartedDate.Value.ToString("yyyy/MM/dd");
            }
           



        } 
        #endregion

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void but_OK_Click(object sender, EventArgs e)
        {
            //判斷必填欄位
            TextBox[] txtList = { txt_ApplicantName, txt_ApplicantSymbol };
            bool IsCheckTextBox = Public.CommonFunctions.RequiredFieldsTextBoxIsEmpty(txtList);
            if (IsCheckTextBox)//必槙欄位有空值，中斷程序
            {
                return;
            }


            Public.CApplicant app = new Public.CApplicant();
            Public.CApplicant.ReadOne(iApplicantKey, ref app);

            bool isWorkerSymbol = false;
            app.CheckValueExist("ApplicantSymbol", txt_ApplicantSymbol.Text, ref isWorkerSymbol, false);
            if (isWorkerSymbol)
            {
                MessageBox.Show("員工編號重覆，請重新再確認", "提示訊息");
                return;
            }

            app.ApplicantSymbol = txt_ApplicantSymbol.Text;
            app.ApplicantName = txt_ApplicantName.Text;
            app.ApplicantNameEn = txt_ApplicantNameEn.Text;
            app.Address = txt_Addr.Text;
            app.AddressEn = txt_AddrEn.Text;
            app.ContactAddr = txt_LiaisonAddr.Text;
            app.Account = txt_Account.Text;
            app.Password = txt_Password.Text;
            app.Chage = txt_Chage.Text;
            app.FAX = txt_FAX.Text;
            app.ID = txt_ID.Text;
            app.TEL = txt_TEL.Text;
            app.PrincipalName = txt_PrincipalName.Text;//代表人
            app.PrincipalNameEn = txt_PrincipalNameEn.Text;//代表人(英)
            app.Receiptor = txt_Receiptor.Text;//收據抬頭
            app.Remart = txt_Remark.Text;
            app.SendTitle = txt_SendTitle.Text;//信件抬頭
            app.SourceDescription = txt_SourceDescription.Text;//客戶來源說明
            app.P = Check_P.Checked == true ? true : false;
            app.T = Check_T.Checked == true ? true : false;
            app.C = Check_C.Checked == true ? true : false;
            app.L = Check_L.Checked == true ? true : false;
            app.E = Check_E.Checked == true ? true : false;
            app.LawVIP = checkBox_LawVIP.Checked == true ? true : false;
            if (comboBox_LargeEnty.SelectedValue != null)
            {
                app.LargeEnty = (int)comboBox_LargeEnty.SelectedValue;
            }
            else
            {
                app.LargeEnty = null;
            }
            if (comboBox_MainCorp.SelectedValue != null)
            {
                app.MainCorp = (int)comboBox_MainCorp.SelectedValue;
            }
            app.ClientKind = comboBox_ClientKind.SelectedValue != null ? (int)comboBox_ClientKind.SelectedValue : -1;
            app.Source = comboBox_Source.SelectedValue != null ? (int)comboBox_Source.SelectedValue : -1;
            app.RecWay = comboBox_RecWay.SelectedValue != null ? (int)comboBox_RecWay.SelectedValue : -1;
            app.Worker = comboBox_Worker.SelectedValue != null ? (int)comboBox_Worker.SelectedValue : -1;
            app.BusinessKind = comboBox_BusinessKind.SelectedValue != null ? (int)comboBox_BusinessKind.SelectedValue : -1;
            app.Business = txt_Business.Text;

            app.Email = txt_email.Text;
            app.WebSite = txt_WebSite.Text;
            app.Evaluation = comboBox_Evaluation.Text;
            app.CollectionRecord = txt_CollectionRecord.Text;
            app.Capital = txt_Capital.Text;

            DateTime dtStartedDate;
            bool IsStartedDate = DateTime.TryParse(maskedTextBox_StartedDate.Text, out dtStartedDate);
            if (IsStartedDate)
            {
                app.StartedDate = dtStartedDate;
            }
            else
            {
                app.StartedDate = null;
            }

            app.LastModifyWorker = Properties.Settings.Default.WorkerName;
            app.Update();

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            if (Forms.ApplicantList != null)
            {
                DataRow dr = Forms.ApplicantList.DT_ApplicantSearchT.Rows.Find(iApplicantKey);
                DataRow drV = Public.CApplicantPublicFunction.GetApplicantListDataRow(app.ApplicantKey.ToString());
                string ss = "";
                for (int i = 0; i < drV.ItemArray.Length; i++)
                {
                    if (Forms.ApplicantList.DT_ApplicantSearchT.Columns[i].ReadOnly == false)
                    {
                        dr.ItemArray[i] = drV.ItemArray[i];
                    }
                    else {
                        ss += Forms.ApplicantList.DT_ApplicantSearchT.Columns[i].ColumnName + "; "; 
                    }
                }
                dr.AcceptChanges();
            }
            MessageBox.Show("修改成功\r\n客戶名稱：" + app.ApplicantName);
            //this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #region EditApplicant_FormClosed
        private void EditApplicant_FormClosed(object sender, FormClosedEventArgs e)
        {
            //解除鎖定該筆資料
            Public.CommonFunctions.NuLockRecordAuth(sourceTableName, Properties.Settings.Default.WorkerKEY);

        } 
        #endregion

        #region but_CheckID_Click
        private void but_CheckID_Click(object sender, EventArgs e)
        {
            txt_ID_Leave(null, null);
        } 
        #endregion

        #region txt_ID_Leave
        private void txt_ID_Leave(object sender, EventArgs e)
        {
            if (txt_ID.Text != "")
            {
                Public.CApplicant capp = new Public.CApplicant();
                capp.ApplicantKey = iApplicantKey;
                bool isCheckValue = false;
                capp.CheckValueExist("ID", txt_ID.Text, ref isCheckValue,false);
                if (isCheckValue)
                {
                    MessageBox.Show("資料庫已有該【統編/身份証號】的客戶資料，請重新再確認");
                    txt_ID.Focus();
                }
                //else
                //{
                //    MessageBox.Show("【統編/身份証號】此資料合法，可使用\r\n" + txt_ID.Text);
                //}
            }
        }
        #endregion

        #region but_CheckApplicantSymbol_Click
        private void but_CheckApplicantSymbol_Click(object sender, EventArgs e)
        {
            if (txt_ApplicantSymbol.Text.Trim() != "")
            {
                Public.CApplicant capp = new Public.CApplicant();
                capp.ApplicantKey = iApplicantKey;
                bool IsValue = false;
                capp.CheckValueExist("ApplicantSymbol", txt_ApplicantSymbol.Text, ref IsValue, false);

                if (IsValue)
                {
                    MessageBox.Show("該【客戶代碼】已經被使用，請修改代碼\r\n" + txt_ApplicantSymbol.Text, "提示訊息");
                    txt_ApplicantSymbol.Focus();
                }
                else
                {
                    MessageBox.Show("【客戶代碼】此資料合法，可使用\r\n" + txt_ApplicantSymbol.Text);
                }
            }
        } 
        #endregion

        #region maskedTextBox_StartedDate_DoubleClick
        private void maskedTextBox_StartedDate_DoubleClick(object sender, EventArgs e)
        {
            MaskedTextBox masked = (MaskedTextBox)sender;
            Public.CommonFunctions.MaskedTextBoxDoubleClick(masked);

        } 
        #endregion

        #region AddApplicant_KeyDown
        private void AddApplicant_KeyDown(object sender, KeyEventArgs e)
        {
            Public.Utility.ControlTab(e);
        }
        #endregion     
        
    }
}
