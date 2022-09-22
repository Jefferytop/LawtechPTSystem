using System;
using System.Data;
using System.Windows.Forms;


namespace LawtechPTSystemByFirm.AddFrom
{
    public partial class AddApplicant : Form
    {
        public AddApplicant()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region AddApplicant_Load
        private void AddApplicant_Load(object sender, EventArgs e)
        {
                       
            this.clientKindTTableAdapter.Fill(this.dataSet_Applicant.ClientKindT);
            //企業實體
            this.largeEntyTTableAdapter.Fill(this.dataSet_Applicant.LargeEntyT);          
            

            //行業種類
            this.businessKindTTableAdapter.Fill(this.dataSet_Applicant.BusinessKindT);           

            //本所服務人員
            this.workerTTableAdapter.Fill(this.dataSet_Drop.WorkerT,false);

            //所屬母公司
            this.applicantTTableAdapter.Fill(this.dataSet_Drop.ApplicantT);

            //請款方式
            recWayTTableAdapter.Fill(dataSet_Applicant.RecWayT);

            //客戶來源
            this.applicantSourceTTableAdapter.Fill(this.dataSet_Applicant.ApplicantSourceT);

           

            comboBox_MainCorp.SelectedIndex = 0;

        } 
        #endregion
               
        #region 確定鈕
        private void button1_Click(object sender, EventArgs e)
        {
            //必填欄位
            TextBox[] txtList = { txt_ApplicantSymbol, txt_ApplicantName };
            bool IsCheckTextBox = Public.CommonFunctions.RequiredFieldsTextBoxIsEmpty(txtList);
            if (IsCheckTextBox)//必槙欄位有空值，中斷程序
            {
                return;
            }


            Public.CApplicant app = new Public.CApplicant();

            bool isWorkerSymbol = false;
            app.CheckValueExist("WorkerSymbol", txt_ApplicantSymbol.Text, ref isWorkerSymbol);
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
            app.PrincipalNameEn = txt_PrincipalNameEN.Text;//代表人(英)
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
            app.LargeEnty = (int)comboBox_LargeEnty.SelectedValue;
            if (comboBox_MainCorp.SelectedValue != null)
            {
                app.MainCorp = (int)comboBox_MainCorp.SelectedValue;
            }
            app.ClientKind = (int)comboBox_ClientKind.SelectedValue;
            app.Source = (int)comboBox_Source.SelectedValue;
            app.RecWay = (int)comboBox_RecWay.SelectedValue;
            app.Worker = (int)comboBox_Worker.SelectedValue;
            app.BusinessKind = (int)comboBox1.SelectedValue;
            app.Business = txt_Business.Text;

            app.Email = txt_email.Text;
            app.WebSite = txt_WebSite.Text;
            app.Evaluation = comboBox_Evaluation.Text;
            app.CollectionRecord = comboBox_CollectionRecord.Text;
            app.Capital = txt_Capital.Text;

            DateTime dtStartedDate;
            bool IsStartedDate = DateTime.TryParse(maskedTextBox_StartedDate.Text, out dtStartedDate);
            if (IsStartedDate)
            {
                app.StartedDate = dtStartedDate;
            }

            app.Creator = Properties.Settings.Default.WorkerName;
            object obj= app.Create();

            Public.DLL dll = new Public.DLL();
            if (Properties.Settings.Default.IsEnableFTP)
            {
                dll.CreatFolder(40, app.ApplicantKey.ToString());
            }

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            if (Forms.ApplicantList != null)
            {
                DataRow dr = Forms.ApplicantList.DT_ApplicantSearchT.NewRow();
                DataRow drV = Public.CApplicantPublicFunction.GetApplicantListDataRow(app.ApplicantKey.ToString());
                dr.ItemArray = drV.ItemArray;
                Forms.ApplicantList.DT_ApplicantSearchT.Rows.Add(dr);
                dr.AcceptChanges();
            }

            if (Forms.ApplicantSearchMF != null)
            {
                DataRow dr = Forms.ApplicantSearchMF.DT_ApplicantSearchT.NewRow();
                DataRow drV = Public.CApplicantPublicFunction.GetApplicantListDataRow(app.ApplicantKey.ToString());
                dr.ItemArray = drV.ItemArray;
                Forms.ApplicantSearchMF.DT_ApplicantSearchT.Rows.Add(dr);
                dr.AcceptChanges();
            }

            MessageBox.Show("新增成功\r\n客戶名稱：" + app.ApplicantName);
            this.DialogResult = DialogResult.OK;
            this.Close();

        }
        #endregion
        
        #region txt_ID_Leave
        private void txt_ID_Leave(object sender, EventArgs e)
        {
            if (txt_ID.Text != "")
            {
                Public.CApplicant capp = new Public.CApplicant();
                bool isCheckValue = false;
                capp.CheckValueExist("ID", txt_ID.Text, ref isCheckValue,true);
                if (isCheckValue)
                {
                    MessageBox.Show("資料庫已有該【統編/身份証號】的客戶資料，請重新再確認");
                    txt_ID.Focus();
                }
                else
                {
                    MessageBox.Show("【統編/身份証號】可使用 \r\n" + txt_ID.Text);
                }
            }
        } 
        #endregion

        #region txt_ApplicantSymbol_Leave
        private void txt_ApplicantSymbol_Leave(object sender, EventArgs e)
        {
            Public.CApplicant capp = new Public.CApplicant();
            bool isCheckValue = false;
            capp.CheckValueExist("ApplicantSymbol", txt_ApplicantSymbol.Text, ref isCheckValue);

            if (txt_ApplicantSymbol.Text != "" && isCheckValue)
            {
                MessageBox.Show("資料庫已有該【客戶代碼】的客戶資料，請重新再確認 \r\n 【客戶代碼】為唯一值，不可重覆", "提示訊息");
                txt_ApplicantSymbol.Focus();
            }
        } 
        #endregion

        #region txt_ApplicantName_Leave
        private void txt_ApplicantName_Leave(object sender, EventArgs e)
        {
            Public.CApplicant capp = new Public.CApplicant();
            bool isCheckValue = false;
            capp.CheckValueExist("ApplicantName", txt_ApplicantName.Text, ref isCheckValue);

            if (txt_ApplicantName.Text != "" && isCheckValue)
            {
                MessageBox.Show("資料庫已有該【客戶名稱】的客戶資料，請重新再確認 \r\n 【客戶名稱】為唯一值，不可重覆", "提示訊息");
                txt_ApplicantName.Focus();
            }
        } 
        #endregion

        #region txt_Addr_Leave
        private void txt_Addr_Leave(object sender, EventArgs e)
        {
            Public.CApplicant capp = new Public.CApplicant();
            bool isCheckValue = false;
            capp.CheckValueExist("Address", txt_Addr.Text, ref isCheckValue);

            if (txt_Addr.Text != "" && isCheckValue)
            {
                MessageBox.Show("資料庫已有該【地址】的客戶資料，請重新再確認", "提示訊息");
                txt_Addr.Focus();
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

        #region but_CheckApplicantSymbol_Click
        private void but_CheckApplicantSymbol_Click(object sender, EventArgs e)
        {
            if (txt_ApplicantSymbol.Text.Trim() != "")
            {
                Public.CApplicant capp = new Public.CApplicant();
                bool IsValue = false;
                capp.CheckValueExist("ApplicantSymbol", txt_ApplicantSymbol.Text, ref IsValue);

                if (IsValue==false)
                {
                    MessageBox.Show("該【客戶代碼】可使用\r\n" + txt_ApplicantSymbol.Text, "提示訊息");
                }
                else
                {
                    MessageBox.Show("該【客戶代碼】已經被使用，請修改代碼\r\n" + txt_ApplicantSymbol.Text, "提示訊息");
                    txt_ApplicantSymbol.Focus();
                }
            }

        } 
        #endregion

        private void but_CheckID_Click(object sender, EventArgs e)
        {
            txt_ID_Leave(null,null);
        }

        #region AddApplicant_KeyDown
        private void AddApplicant_KeyDown(object sender, KeyEventArgs e)
        {
            Public.Utility.ControlTab(e);
        }
        #endregion     

       
    }
}