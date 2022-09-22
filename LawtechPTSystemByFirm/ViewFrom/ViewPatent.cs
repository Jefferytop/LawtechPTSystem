using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.ViewFrom
{
    public partial class ViewPatent : Form
    {
        public ViewPatent()
        {
            InitializeComponent();
        }

        private int iPatentID = -1;
        /// <summary>
        /// 專利ID
        /// </summary>
        public int PatentID
        {
            get { return iPatentID; }
            set { iPatentID = value; }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void ViewPatent_Load(object sender, EventArgs e)
        {
            this.patentManagementTTableAdapter1.FillByPatentID(this.qS_DataSet.PatentManagementT,iPatentID);
            TabFileBinding();
        }

        public void TabFileBinding()
        {
            //申請案卷號
            txt_PatentNo.DataBindings.Clear();
            txt_PatentNo.DataBindings.Add("Text", bSource_File, "PatentNo", true, DataSourceUpdateMode.OnValidation, "", "");

            //提案名稱
            txt_FileNo_Old.DataBindings.Clear();
            txt_FileNo_Old.DataBindings.Add("Text", bSource_File, "PatentNo_Old", true, DataSourceUpdateMode.OnValidation, "", "");
            //申請案名稱
            txt_title.DataBindings.Clear();
            txt_title.DataBindings.Add("Text", bSource_File, "Title", true, DataSourceUpdateMode.OnValidation, "", "");
            //申請案名稱(英)
            txt_TitleEn.DataBindings.Clear();
            txt_TitleEn.DataBindings.Add("Text", bSource_File, "TitleEn", true, DataSourceUpdateMode.OnValidation, "", "");


            //國別
            txt_Country.DataBindings.Clear();
            txt_Country.DataBindings.Add("Text", bSource_File, "CountryName", true, DataSourceUpdateMode.OnValidation);

            //種類
            txt_Kind.DataBindings.Clear();
            txt_Kind.DataBindings.Add("Text", bSource_File, "KindName", true, DataSourceUpdateMode.OnValidation);

            //性質
            txt_Nature.DataBindings.Clear();
            txt_Nature.DataBindings.Add("Text", bSource_File, "FeatureName", true, DataSourceUpdateMode.OnValidation);

            //狀態
            txt_Status.DataBindings.Clear();
            txt_Status.DataBindings.Add("Text", bSource_File, "StatusName", true, DataSourceUpdateMode.OnValidation);

            //申請案號
            txt_ApplicationNo.DataBindings.Clear();
            txt_ApplicationNo.DataBindings.Add("Text", bSource_File, "ApplicationNo", true, DataSourceUpdateMode.OnValidation, "", "");
            //實際申請日
            txt_Applicant.DataBindings.Clear();
            txt_Applicant.DataBindings.Add("Text", bSource_File, "ApplicantName", true, DataSourceUpdateMode.OnValidation, "", "");
            //公開號數
            txt_PubNo.DataBindings.Clear();
            txt_PubNo.DataBindings.Add("Text", bSource_File, "PubNo", true, DataSourceUpdateMode.OnValidation, "", "");
            //專利號數
            txt_CertifyNo.DataBindings.Clear();
            txt_CertifyNo.DataBindings.Add("Text", bSource_File, "CertifyNo", true, DataSourceUpdateMode.OnValidation, "", "");
            //公告號數
            txt_AllowPubNo.DataBindings.Clear();
            txt_AllowPubNo.DataBindings.Add("Text", bSource_File, "AllowPubNo", true, DataSourceUpdateMode.OnValidation, "", "");

            //年費繳至第幾年
            txt_PayYear.DataBindings.Clear();
            txt_PayYear.DataBindings.Add("Value", bSource_File, "PayYear", false, DataSourceUpdateMode.OnValidation, 0m);

            txt_AddDay.DataBindings.Clear();
            txt_AddDay.DataBindings.Add("Value", bSource_File, "AddDay", true, DataSourceUpdateMode.OnValidation);

            //引案人
            txt_Introducer.DataBindings.Clear();
            txt_Introducer.DataBindings.Add("Text", bSource_File, "Introducer", true, DataSourceUpdateMode.OnValidation);

            //備註
            txt_Remark2.DataBindings.Clear();
            txt_Remark2.DataBindings.Add("Text", bSource_File, "Remark", true, DataSourceUpdateMode.OnValidation);

            //本所承辦人
            txt_ClientWorker.DataBindings.Clear();
            txt_ClientWorker.DataBindings.Add("Text", bSource_File, "WorkerName", true, DataSourceUpdateMode.OnValidation);

            //優先權
            txt_Priority.DataBindings.Clear();
            txt_Priority.DataBindings.Add("Text", bSource_File, "PriorityBaseName", true, DataSourceUpdateMode.OnValidation);

            //審查請求
            txt_ISexam.DataBindings.Clear();
            txt_ISexam.DataBindings.Add("Text", bSource_File, "ISExamName", true, DataSourceUpdateMode.OnValidation);


            //委託類型
            txt_DelegateType.DataBindings.Clear();
            txt_DelegateType.DataBindings.Add("Text", bSource_File, "DelegateTypeName", true, DataSourceUpdateMode.OnValidation);

            //主委託人
            txt_MainCustomer.DataBindings.Clear();
            txt_MainCustomer.DataBindings.Add("Text", bSource_File, "MainCustomerName", true, DataSourceUpdateMode.OnValidation);

            //主委託人--聯絡窗口
            txt_MainCustomerTransactor.DataBindings.Clear();
            txt_MainCustomerTransactor.DataBindings.Add("Text", bSource_File, "MainCustomerTransactorName", true, DataSourceUpdateMode.OnValidation);

            //主委託人--對方案號
            txt_MainCustomerRefNo.DataBindings.Clear();
            txt_MainCustomerRefNo.DataBindings.Add("Text", bSource_File, "MainCustomerRefNo", true, DataSourceUpdateMode.OnValidation);

            //承辦事務所
            txt_PatentAttorney.DataBindings.Clear();
            txt_PatentAttorney.DataBindings.Add("Text", bSource_File, "AttorneyFirm", true, DataSourceUpdateMode.OnValidation);

            //承辦事務所--對方案號
            txt_PatentAttorneyRefNo.DataBindings.Clear();
            txt_PatentAttorneyRefNo.DataBindings.Add("Text", bSource_File, "AttorneyRefNo", true, DataSourceUpdateMode.OnValidation);

            //承辦事務所--聯絡窗口
            txt_PatentAttorneyTransactor.DataBindings.Clear();
            txt_PatentAttorneyTransactor.DataBindings.Add("Text", bSource_File, "AttLiaisoner", true, DataSourceUpdateMode.OnValidation);

            //是否本所承辦案件
            chb_IsBySelf.DataBindings.Clear();
            chb_IsBySelf.DataBindings.Add("Checked", bSource_File, "IsBySelf", true, DataSourceUpdateMode.OnPropertyChanged, false);



            //引案日期
            mask_IntroductionDate.DataBindings.Clear();
            mask_IntroductionDate.DataBindings.Add("Text", bSource_File, "IntroductionDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            //最早母案申請日
            maskedTextBox_EarlyMotherDate.DataBindings.Clear();
            maskedTextBox_EarlyMotherDate.DataBindings.Add("Text", bSource_File, "EarlyMotherDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            //實際申請日
            maskedTextBox_ApplicationDate.DataBindings.Clear();
            maskedTextBox_ApplicationDate.DataBindings.Add("Text", bSource_File, "ApplicationDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            //公開日期
            maskedTextBox_Pubdate.DataBindings.Clear();
            maskedTextBox_Pubdate.DataBindings.Add("Text", bSource_File, "Pubdate", true, DataSourceUpdateMode.OnValidation, "    /  /", "yyyy/MM/dd");

            //核准日期
            maskedTextBox_AllowDate.DataBindings.Clear();
            maskedTextBox_AllowDate.DataBindings.Add("Text", bSource_File, "AllowDate", true, DataSourceUpdateMode.OnValidation, "    /  /", "yyyy/MM/dd");

            //公告日期
            maskedTextBox_AllowPubdate.DataBindings.Clear();
            maskedTextBox_AllowPubdate.DataBindings.Add("Text", bSource_File, "AllowPubdate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            //收到證書日
            maskedTextBox_GetDate.DataBindings.Clear();
            maskedTextBox_GetDate.DataBindings.Add("Text", bSource_File, "GetDate", true, DataSourceUpdateMode.OnValidation, "    /  /", "yyyy/MM/dd");

            maskedTextBox_Registerdate.DataBindings.Clear();
            maskedTextBox_Registerdate.DataBindings.Add("Text", bSource_File, "Registerdate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_DueDate.DataBindings.Clear();
            maskedTextBox_DueDate.DataBindings.Add("Text", bSource_File, "DueDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_RenewTo.DataBindings.Clear();
            maskedTextBox_RenewTo.DataBindings.Add("Text", bSource_File, "RenewTo", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_CloseDate.DataBindings.Clear();
            maskedTextBox_CloseDate.DataBindings.Add("Text", bSource_File, "CloseDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");



            //最早優先申請日
            maskedTextBox_EarlyPriorityDate.DataBindings.Clear();
            maskedTextBox_EarlyPriorityDate.DataBindings.Add("Text", bSource_File, "EarlyPriorityDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");


        }

       
    }
}
