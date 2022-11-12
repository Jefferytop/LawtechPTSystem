
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LawtechPTSystem.SubFrom
{
    /// <summary>
    /// 案件歷史記錄精簡版(只有事件記錄)
    /// </summary>
    public partial class PatentHistoryRecord_Event : Form
    {
        public PatentHistoryRecord_Event()
        {
            InitializeComponent();         
           
            GridView_PatComit.AutoGenerateColumns = false;         
           
            Public.DynamicGridViewColumn.GetGridColum(ref GridView_PatComit);
         
        }

        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region  ============property============
        private int _PatentID = -1;
        /// <summary>
        /// PatentID
        /// </summary>
        public int property_PatentID
        {
            get
            {
                return _PatentID;

            }
            set
            {
                _PatentID = value;
            }
        }

        private int iTabSelectedIndex = 0;
        /// <summary>
        /// 第幾個Tab 0.申請案基本資料  1.事件記錄  2.請款  3.付款
        /// </summary>
        public int TabSelectedIndex
        {
            get { return iTabSelectedIndex; }
            set { iTabSelectedIndex = value; }
        }

        #endregion

        #region ===========資料集===========
        private DataTable dt_PatentList = new DataTable();
        /// <summary>
        /// PatentManagement 資料集
        /// </summary>
        public DataTable DT_PatentList
        {
            get
            {
                return dt_PatentList;
            }

        }

        private DataTable dt_PatComitEventT = new DataTable();
        /// <summary>
        /// PatComitEventT 事件記錄
        /// </summary>
        public DataTable DT_PatComitEventT
        {
            get
            {
                return dt_PatComitEventT;
            }

        }

     

      

        /// <summary>
        /// 重新整理資料集 1.事件記錄  2.預估費用  3.請款費用  4.付款費用
        /// </summary>
        /// <param name="iTable"></param>
        public void RefrashDataTable(int iTable)
        {
            switch (iTable)
            {
                case 0:
                    this.DT_PatentList.Rows.Clear();
                    break;
                case 1:
                    this.DT_PatComitEventT.Rows.Clear();
                    break;            
            }
        }
        #endregion

        #region PatentHistoryRecord_Load
        private void PatentHistoryRecord_Load(object sender, EventArgs e)
        {
            
            SetBindingSource();

            TabFileBinding();
            ControlBindingPatComit();            
      
           
            Tabcontrol1.SelectedIndex = TabSelectedIndex;
        }
        #endregion

        #region 設定BindingSource的來源 private void SetBindingSource()
        /// <summary>
        /// 設定BindingSource的來源
        /// </summary>
        private void SetBindingSource()
        {
            if (dt_PatentList.Columns.Count == 0)
            {
                Public.CPatentPublicFunction.GetPatentList(" PatentID=" + property_PatentID.ToString(), ref dt_PatentList);
            }
            bSource_File.DataSource = dt_PatentList;

            if (dt_PatComitEventT.Columns.Count == 0)
            {
                Public.CPatentPublicFunction.GetPatentEvent(property_PatentID.ToString(), ref dt_PatComitEventT);
            }
            patComitEventTBindingSource.DataSource = dt_PatComitEventT;
          
        }
        #endregion

        #region ================ControlBinding================

        #region TabFileBinding
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

            //申請案號
            txt_ApplicationNo.DataBindings.Clear();
            txt_ApplicationNo.DataBindings.Add("Text", bSource_File, "ApplicationNo", true, DataSourceUpdateMode.OnValidation, "", "");

            //申請人
            txt_Applicant.DataBindings.Clear();
            txt_Applicant.DataBindings.Add("Text", bSource_File, "ApplicantNames", true, DataSourceUpdateMode.OnValidation, "", "");

            //發明人
            txt_Inventor.DataBindings.Clear();
            txt_Inventor.DataBindings.Add("Text", bSource_File, "Inventor", true, DataSourceUpdateMode.OnValidation, "", "");

            //種類(發明、新型、新式樣)
            txt_Kind.DataBindings.Clear();
            txt_Kind.DataBindings.Add("Text", bSource_File, "KindName", true, DataSourceUpdateMode.OnValidation, "", "");

            //性質(案件性質: 一般案、接續案)
            txt_Nature.DataBindings.Clear();
            txt_Nature.DataBindings.Add("Text", bSource_File, "FeatureName", true, DataSourceUpdateMode.OnValidation, "", "");

            //國別
            txt_Country.DataBindings.Clear();
            txt_Country.DataBindings.Add("Text", bSource_File, "Country", true, DataSourceUpdateMode.OnValidation, "", "");

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
            //txt_PayYear.DataBindings.Clear();
            //txt_PayYear.DataBindings.Add("Value", bSource_File, "PayYear", false, DataSourceUpdateMode.OnValidation, 0m);

            textBox_PayYear.DataBindings.Clear();
            textBox_PayYear.DataBindings.Add("Text", bSource_File, "PayYear", false, DataSourceUpdateMode.OnValidation);

            //txt_AddDay.DataBindings.Clear();
            //txt_AddDay.DataBindings.Add("Value", bSource_File, "AddDay", true, DataSourceUpdateMode.OnValidation);

            textBox_AddDay.DataBindings.Clear();
            textBox_AddDay.DataBindings.Add("Text", bSource_File, "AddDay", true, DataSourceUpdateMode.OnValidation);

            //引案人
            txt_Introducer.DataBindings.Clear();
            txt_Introducer.DataBindings.Add("Text", bSource_File, "Introducer", true, DataSourceUpdateMode.OnValidation);

            //備註
            txt_Remark2.DataBindings.Clear();
            txt_Remark2.DataBindings.Add("Text", bSource_File, "Remark", true, DataSourceUpdateMode.OnValidation);

            //本所承辦人
            txt_ClientWorker.DataBindings.Clear();
            txt_ClientWorker.DataBindings.Add("Text", bSource_File, "ClientWorkerName", true, DataSourceUpdateMode.OnValidation);

            //優先權
            txt_Priority.DataBindings.Clear();
            txt_Priority.DataBindings.Add("Text", bSource_File, "PriorityBaseName", true, DataSourceUpdateMode.OnValidation);

            //審查請求
            txt_ISexam.DataBindings.Clear();
            txt_ISexam.DataBindings.Add("Text", bSource_File, "ISExamName", true, DataSourceUpdateMode.OnValidation);


            //委託類型
            txt_DelegateType.DataBindings.Clear();
            txt_DelegateType.DataBindings.Add("Text", bSource_File, "DelegateTypeName", true, DataSourceUpdateMode.OnValidation);

            //委託性質
            txt_DelegateFeatureName.DataBindings.Clear();
            txt_DelegateFeatureName.DataBindings.Add("Text", bSource_File, "DelegateFeatureName", true, DataSourceUpdateMode.OnValidation);

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
            mask_IntroductionDate.DataBindings.Add("Text", bSource_File, "IntroductionDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            //最早母案申請日
            maskedTextBox_EarlyMotherDate.DataBindings.Clear();
            maskedTextBox_EarlyMotherDate.DataBindings.Add("Text", bSource_File, "EarlyMotherDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            //實際申請日
            maskedTextBox_ApplicationDate.DataBindings.Clear();
            maskedTextBox_ApplicationDate.DataBindings.Add("Text", bSource_File, "ApplicationDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            //公開日期
            maskedTextBox_Pubdate.DataBindings.Clear();
            maskedTextBox_Pubdate.DataBindings.Add("Text", bSource_File, "Pubdate", true, DataSourceUpdateMode.OnValidation, "    -  -", "yyyy-MM-dd");

            //核准日期
            maskedTextBox_AllowDate.DataBindings.Clear();
            maskedTextBox_AllowDate.DataBindings.Add("Text", bSource_File, "AllowDate", true, DataSourceUpdateMode.OnValidation, "    -  -", "yyyy-MM-dd");

            //公告日期
            maskedTextBox_AllowPubdate.DataBindings.Clear();
            maskedTextBox_AllowPubdate.DataBindings.Add("Text", bSource_File, "AllowPubdate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            //收到證書日
            maskedTextBox_GetDate.DataBindings.Clear();
            maskedTextBox_GetDate.DataBindings.Add("Text", bSource_File, "GetDate", true, DataSourceUpdateMode.OnValidation, "    -  -", "yyyy-MM-dd");

            maskedTextBox_Registerdate.DataBindings.Clear();
            maskedTextBox_Registerdate.DataBindings.Add("Text", bSource_File, "Registerdate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            maskedTextBox_DueDate.DataBindings.Clear();
            maskedTextBox_DueDate.DataBindings.Add("Text", bSource_File, "DueDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            maskedTextBox_RenewTo.DataBindings.Clear();
            maskedTextBox_RenewTo.DataBindings.Add("Text", bSource_File, "RenewTo", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            maskedTextBox_CloseDate.DataBindings.Clear();
            maskedTextBox_CloseDate.DataBindings.Add("Text", bSource_File, "CloseDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");
            
            //最早優先申請日
            maskedTextBox_EarlyPriorityDate.DataBindings.Clear();
            maskedTextBox_EarlyPriorityDate.DataBindings.Add("Text", bSource_File, "EarlyPriorityDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            //優先權申請號
            txt_EarlyPriorityNo.DataBindings.Clear();
            txt_EarlyPriorityNo.DataBindings.Add("Text", bSource_File, "EarlyPriorityNo", true, DataSourceUpdateMode.OnValidation);

            //案件階段
            txt_StatusName.DataBindings.Clear();
            txt_StatusName.DataBindings.Add("Text", bSource_File, "StatusName", true, DataSourceUpdateMode.OnValidation);

            //階段描述
            txt_StatusExplain.DataBindings.Clear();
            txt_StatusExplain.DataBindings.Add("Text", bSource_File, "StatusExplain", true, DataSourceUpdateMode.OnValidation);

            //結案原因
            txt_CloseCaus.DataBindings.Clear();
            txt_CloseCaus.DataBindings.Add("Text", bSource_File, "CloseCaus", true, DataSourceUpdateMode.OnValidation);

            //結案原因
            txt_ECode.DataBindings.Clear();
            txt_ECode.DataBindings.Add("Text", bSource_File, "ECode", true, DataSourceUpdateMode.OnValidation);
        }
        #endregion

        #region ControlBindingPatComit
        public void ControlBindingPatComit()
        {
            txt_ComitEventContent.DataBindings.Clear();
            txt_ComitEventContent.DataBindings.Add("Text", patComitEventTBindingSource, "EventContent", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            txt_WorkerKey.DataBindings.Clear();
            txt_WorkerKey.DataBindings.Add("Text", patComitEventTBindingSource, "EmployeeName", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            maskedTextBox_OccurDate.DataBindings.Clear();
            maskedTextBox_OccurDate.DataBindings.Add("Text", patComitEventTBindingSource, "OccurDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            maskedTextBox_OfficerDate.DataBindings.Clear();
            maskedTextBox_OfficerDate.DataBindings.Add("Text", patComitEventTBindingSource, "OfficerDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            maskedTextBox_ComitDueDate.DataBindings.Clear();
            maskedTextBox_ComitDueDate.DataBindings.Add("Text", patComitEventTBindingSource, "DueDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            maskedTextBox_OfficeDueDate.DataBindings.Clear();
            maskedTextBox_OfficeDueDate.DataBindings.Add("Text", patComitEventTBindingSource, "OfficeDueDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            maskedTextBox_StartDate.DataBindings.Clear();
            maskedTextBox_StartDate.DataBindings.Add("Text", patComitEventTBindingSource, "StartDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            maskedTextBox_ComitDate.DataBindings.Clear();
            maskedTextBox_ComitDate.DataBindings.Add("Text", patComitEventTBindingSource, "ComitDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            maskedTextBox_FinishDate.DataBindings.Clear();
            maskedTextBox_FinishDate.DataBindings.Add("Text", patComitEventTBindingSource, "FinishDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            maskedTextBox_CreateDate.DataBindings.Clear();
            maskedTextBox_CreateDate.DataBindings.Add("Text", patComitEventTBindingSource, "CreateDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            txt_eRemark.DataBindings.Clear();
            txt_eRemark.DataBindings.Add("Text", patComitEventTBindingSource, "Remark", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            txt_ComitResult.DataBindings.Clear();
            txt_ComitResult.DataBindings.Add("Text", patComitEventTBindingSource, "Result", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

        }
        #endregion      

        #endregion

        #region =============linkLabel===============
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel link = (LinkLabel)sender;
            US.PopMemo pop;
            switch (link.Name)
            {
                case "linkLabel_CloseCaus":
                    pop = new LawtechPTSystem.US.PopMemo(txt_CloseCaus, true, link.Text);
                    break;
                case "linkLabel_mome":
                    pop = new LawtechPTSystem.US.PopMemo(txt_Remark2, true, link.Text);
                    break;
                case "linkLabel_ComitResult":
                    pop = new LawtechPTSystem.US.PopMemo(txt_ComitResult, true, link.Text);
                    break;
                case "linkLabel_eRemark":
                    pop = new LawtechPTSystem.US.PopMemo(txt_eRemark, true, link.Text);
                    break;
             
                case "linkLabel_MainCustomer":
                    pop = new LawtechPTSystem.US.PopMemo(txt_MainCustomer, true, link.Text);
                    break;
                case "linkLabel_PatentAttorney":
                    pop = new LawtechPTSystem.US.PopMemo(txt_PatentAttorney, true, link.Text);
                    break;
                case "linkLabel_Inventor":
                    pop = new LawtechPTSystem.US.PopMemo(txt_Inventor, true, link.Text);
                    break;
                case "linkLabel_EarlyPriorityNo":
                    pop = new LawtechPTSystem.US.PopMemo(txt_EarlyPriorityNo, true, link.Text);
                    break;
                default:
                    pop = new LawtechPTSystem.US.PopMemo(txt_FileNo, true, link.Text);
                    break;
               
            }

            pop.Show();
        }

        #endregion

        private void toolStripButton_ExcelEvent_Click(object sender, EventArgs e)
        {
            try
            {
                Public.DLL dll = new Public.DLL();
                Task task = dll.WriteToCSV(GridView_PatComit);
            }
            catch
            {
                MessageBox.Show("匯出CSV失敗");
            }
        }

       



        private void txt_PatentNo_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_PatentNo.Text))
            {
                this.Text += string.Format("({0})", txt_PatentNo.Text);
            }
        }
        
    }
}
