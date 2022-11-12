using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystem.AddFrom
{
    public partial class AddWorker : Form
    {
        public AddWorker()
        {
            InitializeComponent();
        }

        #region btnCancel_Click
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        #endregion

        #region button1_Click 確定按鈕
        private void button1_Click(object sender, EventArgs e)
        {
            //判斷必填欄位
            TextBox[] txtList = {txt_WorkerSymbol, txt_Account,txt_EmployeeName,txt_Password };
            bool IsCheckTextBox = Public.CommonFunctions.RequiredFieldsTextBoxIsEmpty(txtList);
            if (IsCheckTextBox)//必槙欄位有空值，中斷程序
            {
                return ;
            }


            Worker_Model add = new Worker_Model();

            bool isWorkerSymbol=false;
            add.CheckValueExist("WorkerSymbol", txt_WorkerSymbol.Text,ref isWorkerSymbol);
            if (isWorkerSymbol)
            {
                MessageBox.Show("員工編號重覆，請重新再確認","提示訊息");
                return;
            }

            bool isAccount = false;
            add.CheckValueExist("Account", txt_Account.Text, ref isAccount);
            if (isAccount)
            {
                MessageBox.Show("帳號已重覆，請重新再確認", "提示訊息");
                return;
            }

           
            
            add.Addr = txt_Addr.Text;
            add.Background = txt_Background.Text;

            DateTime dateBirthday;
            bool isBirthday = DateTime.TryParse(maskedTextBox_Birthday.Text, out dateBirthday);
            if (isBirthday)
            {
                add.Birthday = dateBirthday;
            }

            DateTime dateReachDay;
            bool isReachDay = DateTime.TryParse(maskedTextBox_ReachDay.Text, out dateReachDay);
            if (isReachDay)
            {
                add.ReachDay = dateReachDay;
            }

            add.Email = txt_Email.Text;
            add.EverAddr = txt_EverAddr.Text;
            add.Experience = txt_Experience.Text;
            add.ext = txt_ext.Text;
            add.EmployeeID = txt_EmployeeID.Text;
            add.Account = txt_Account.Text;
             add.Password = txt_Password.Text;
            add.Mobilephone = txt_Mobilephone.Text;
            add.EmployeeName = txt_EmployeeName.Text;
            add.EmployeeNameEn = txt_EmployeeNameEn.Text;           
            add.IsQuit = false;
            add.Remark = txt_Remark.Text;
            add.Specialty = txt_Specialty.Text;
            add.TEL = txt_TEL.Text;
            add.WorkerSymbol = txt_WorkerSymbol.Text;           
            add.Creator = Properties.Settings.Default.WorkerName;
            add.OfficeRole = (int)comboBox_OfficeRole.SelectedValue;
            add.SingCode = txt_SingOffCode.Text;
            add.WorkScope = txt_WorkScope.Text;
            add.IsLoadData = true;
            add.LoadDataRange = 0;
            add.Create();

            Public.PublicForm Forms = new Public.PublicForm();
            DataRow dr=  Forms.AuthorityMF.DtWorkers.NewRow();
            dr["WorkerKey"] = add.WorkerKey;
            dr["Email"] = add.Email;
            dr["EverAddr"] = add.EverAddr;
            dr["Experience"] = add.Experience;
            dr["ext"] = add.ext;
            dr["EmployeeID"] = add.EmployeeID;
            dr["Account"] = add.Account;
            dr["Password"] = add.Password;
            dr["Mobilephone"] = add.Mobilephone;
            dr["EmployeeName"] = add.EmployeeName;
            dr["EmployeeNameEn"] = add.EmployeeNameEn;
            dr["IsQuit"] = add.IsQuit;
            dr["Remark"] = add.Remark;
            dr["Specialty"] = add.Specialty;
            dr["TEL"] = add.TEL;
            dr["WorkerSymbol"] = add.WorkerSymbol;
            dr["Creator"] =Properties.Settings.Default.WorkerName;
            dr["OfficeRole"] = add.OfficeRole;
            dr["SingCode"] = add.SingCode;
            dr["WorkScope"] = add.WorkScope;
            Forms.AuthorityMF.DtWorkers.Rows.Add(dr);

            MessageBox.Show(string.Format("員工編號：{0}\r\n員工姓名：{1} \r\n新增成功",add.WorkerSymbol, add.EmployeeName));
            btnConfirm.DialogResult = DialogResult.OK;
            this.Close();

       
        }
        #endregion

        #region AddWorker_Load 
        private void AddWorker_Load(object sender, EventArgs e)
        {

            this.officeRoleTTableAdapter.Fill(this.qS_DataSet.OfficeRoleT);

            maskedTextBox_ReachDay.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }
        
        #endregion

        private void comboBox_OfficeRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboBox_OfficeRole.SelectedValue != null && (int)comboBox_OfficeRole.SelectedValue != 1)
            //{
            //    lab_SingOffCode.Visible = true;
            //    txt_SingOffCode.Visible = true;
            //}
            //else
            //{
            //    lab_SingOffCode.Visible = false;
            //    txt_SingOffCode.Visible = false;
            //}
        }


        #region maskedTextBox 按兩下填入當天日期
        private void maskedTextBox_Birthday_DoubleClick(object sender, EventArgs e)
        {
            MaskedTextBox masked = (MaskedTextBox)sender;
            Public.CommonFunctions.MaskedTextBoxDoubleClick(masked);

        }

        #endregion

        private void maskedTextBox_Birthday_Leave(object sender, EventArgs e)
        {
            MaskedTextBox mak = (MaskedTextBox)sender;
            Public.Utility.CheckMaskedtextbox(mak);
        }
    }
}