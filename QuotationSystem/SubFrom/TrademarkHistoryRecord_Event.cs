using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.SubFrom
{
    public partial class TrademarkHistoryRecord_Event : Form
    {
        public TrademarkHistoryRecord_Event()
        {
            InitializeComponent();           

            TMNotifyEventTDataGridView.AutoGenerateColumns = false;
          

         
            Public.DynamicGridViewColumn.GetGridColum(ref TMNotifyEventTDataGridView);
       

        }

        private int iTrademarkID = -1;
        /// <summary>
        /// 商標的PK
        /// </summary>
        public int TrademarkID
        {
            get { return iTrademarkID; }
            set { iTrademarkID = value; }
        }

        string strTMrootPath = "";
        /// <summary>
        /// 商標的上傳資料夾路徑
        /// </summary>
        public string property_TMrootPath
        {
            get
            {
                return strTMrootPath;
            }
            set
            {
                strTMrootPath = value;
            }
        }


        private int iTabSelectedIndex = 0;
        /// <summary>
        /// 第幾個Tab 0.申請案基本資料  1.事件記錄 2.預估成本  3.請款  4.付款
        /// </summary>
        public int TabSelectedIndex
        {
            get { return iTabSelectedIndex; }
            set { iTabSelectedIndex = value; }
        }

        #region ================資料集================
        private DataTable dt_TrademarkList = new DataTable();
        /// <summary>
        /// TrademarkManagement 資料集
        /// </summary>
        public DataTable DT_TrademarkManagementT
        {
            get
            {
                return dt_TrademarkList;
            }

        }

        private DataTable dt_TrademarkNotifyEventT = new DataTable();
        /// <summary>
        /// TrademarkNotifyEventT  事件記錄
        /// </summary>
        public DataTable DT_TrademarkNotifyEventT
        {
            get
            {
                return dt_TrademarkNotifyEventT;
            }

        }

      

    

        /// <summary>
        /// 重新整理資料集 0.商標 1.事件記錄 2.預估成本  3.請款費用  4.付款費用 
        /// </summary>
        /// <param name="iTable"></param>
        public void RefrashDataTable(int iTable)
        {
            switch (iTable)
            {
                case 0:
                    this.DT_TrademarkManagementT.Rows.Clear();

                    break;
                case 1:
                    this.dt_TrademarkNotifyEventT.Rows.Clear();

                    break;   
            }
        }
        #endregion


        private void TrademarkHistoryRecord_Load(object sender, EventArgs e)
        {
            Public.DLL dll = new Public.DLL();
            property_TMrootPath = dll.TrademarkFolderRoot;

            SetBindingSource();

            TabTrademarkBinding();
            ControlBindingTMNotify();          

            Tabcontrol1.SelectedIndex = TabSelectedIndex;

            this.Text = this.Text + "(" + txt_TrademarkNo.Text + ")";

            if (!string.IsNullOrEmpty(txt_PicPath.Text) )
            {
                pictureBox1.ImageLocation = property_TMrootPath + "\\" + txt_PicPath.Text;
            }
        }

        #region 設定BindingSource的來源 private void SetBindingSource()
        /// <summary>
        /// 設定BindingSource的來源
        /// </summary>
        private void SetBindingSource()
        {
            if (DT_TrademarkManagementT.Columns.Count == 0)
            {
                Public.CTrademarkPublicFunction.GetTrademarkList("TrademarkID=" + TrademarkID.ToString(),ref dt_TrademarkList);
            }
            trademarkManagementTBindingSource.DataSource = DT_TrademarkManagementT;

            if (DT_TrademarkNotifyEventT.Columns.Count == 0)
            {
                Public.CTrademarkPublicFunction.GetTrademarkEvent(TrademarkID.ToString(),ref dt_TrademarkNotifyEventT);
            }
            trademarkNotifyEventTBindingSource.DataSource = DT_TrademarkNotifyEventT;

           
        }
        #endregion

        #region ================ControlBinding================

        #region TabTrademarkBinding
        public void TabTrademarkBinding()
        {

            txt_TrademarkName.DataBindings.Clear();
            txt_TrademarkName.DataBindings.Add("Text", trademarkManagementTBindingSource, "TrademarkName", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_ApplicantKey.DataBindings.Clear();
            txt_ApplicantKey.DataBindings.Add("Text", trademarkManagementTBindingSource, "ApplicantNames", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_TrademarkNo.DataBindings.Clear();
            txt_TrademarkNo.DataBindings.Add("Text", trademarkManagementTBindingSource, "TrademarkNo", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_Name.DataBindings.Clear();
            txt_Name.DataBindings.Add("Text", trademarkManagementTBindingSource, "EmployeeName", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_RegisterProductItems.Clear();
            txt_RegisterProductItems.DataBindings.Add("Text", trademarkManagementTBindingSource, "RegisterProductName", true, DataSourceUpdateMode.OnValidation, "", "");


            txt_OutsourcingTrademarkNo.DataBindings.Clear();
            txt_OutsourcingTrademarkNo.DataBindings.Add("Text", trademarkManagementTBindingSource, "OutsourcingTrademarkNo", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_ApplicationNo.DataBindings.Clear();
            txt_ApplicationNo.DataBindings.Add("Text", trademarkManagementTBindingSource, "ApplicationNo", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_NoticeNo.DataBindings.Clear();
            txt_NoticeNo.DataBindings.Add("Text", trademarkManagementTBindingSource, "NoticeNo1", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_NoticeNo2.DataBindings.Clear();
            txt_NoticeNo2.DataBindings.Add("Text", trademarkManagementTBindingSource, "NoticeNo", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_RegistrationNo.DataBindings.Clear();
            txt_RegistrationNo.DataBindings.Add("Text", trademarkManagementTBindingSource, "RegistrationNo", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_RegisterProduct.DataBindings.Clear();
            txt_RegisterProduct.DataBindings.Add("Text", trademarkManagementTBindingSource, "RegisterProduct", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_Remarks.DataBindings.Clear();
            txt_Remarks.DataBindings.Add("Text", trademarkManagementTBindingSource, "Remarks", true, DataSourceUpdateMode.OnPropertyChanged, "");

            txt_PicPath.DataBindings.Clear();
            txt_PicPath.DataBindings.Add("Text", trademarkManagementTBindingSource, "PicPath", true, DataSourceUpdateMode.OnPropertyChanged, "");


            txt_OutsourcingTrademarkNo.DataBindings.Clear();
            txt_OutsourcingTrademarkNo.DataBindings.Add("Text", trademarkManagementTBindingSource, "OutsourcingTrademarkNo", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_RegistrationNo.DataBindings.Clear();
            txt_RegistrationNo.DataBindings.Add("Text", trademarkManagementTBindingSource, "RegistrationNo", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_Status.DataBindings.Clear();
            txt_Status.DataBindings.Add("Text", trademarkManagementTBindingSource, "StatusName", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_StatusExplain.DataBindings.Clear();
            txt_StatusExplain.DataBindings.Add("Text", trademarkManagementTBindingSource, "StatusExplain", true, DataSourceUpdateMode.OnPropertyChanged, "");

            //優先權
            txt_Priority.DataBindings.Clear();
            txt_Priority.DataBindings.Add("Text", trademarkManagementTBindingSource, "PriorityBaseName", true, DataSourceUpdateMode.OnValidation);

            txt_EarlyPriorityNo.DataBindings.Clear();
            txt_EarlyPriorityNo.DataBindings.Add("Text", trademarkManagementTBindingSource, "EarlyPriorityNo", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_RegisterProduct.DataBindings.Clear();
            txt_RegisterProduct.DataBindings.Add("Text", trademarkManagementTBindingSource, "RegisterProduct", true, DataSourceUpdateMode.OnValidation, "", "");

            maskedTextBox_EntrustDate.DataBindings.Clear();
            maskedTextBox_EntrustDate.DataBindings.Add("Text", trademarkManagementTBindingSource, "EntrustDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_RegistrationDate.DataBindings.Clear();
            maskedTextBox_RegistrationDate.DataBindings.Add("Text", trademarkManagementTBindingSource, "RegistrationDate", true, DataSourceUpdateMode.OnValidation, "    /  /", "yyyy/MM/dd");

            maskedTextBox_LawDate.DataBindings.Clear();
            maskedTextBox_LawDate.DataBindings.Add("Text", trademarkManagementTBindingSource, "LawDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_NoticeDate.DataBindings.Clear();
            maskedTextBox_NoticeDate.DataBindings.Add("Text", trademarkManagementTBindingSource, "NoticeDate1", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_NoticeDate2.DataBindings.Clear();
            maskedTextBox_NoticeDate2.DataBindings.Add("Text", trademarkManagementTBindingSource, "NoticeDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_DueDate.DataBindings.Clear();
            maskedTextBox_DueDate.DataBindings.Add("Text", trademarkManagementTBindingSource, "DueDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_ExtendedDate.DataBindings.Clear();
            maskedTextBox_ExtendedDate.DataBindings.Add("Text", trademarkManagementTBindingSource, "ExtendedDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_CloseDate.DataBindings.Clear();
            maskedTextBox_CloseDate.DataBindings.Add("Text", trademarkManagementTBindingSource, "CloseDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_ApplicationDate.DataBindings.Clear();
            maskedTextBox_ApplicationDate.DataBindings.Add("Text", trademarkManagementTBindingSource, "ApplicationDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            //委託性質
            txt_DelegateFeatureName.DataBindings.Clear();
            txt_DelegateFeatureName.DataBindings.Add("Text", trademarkManagementTBindingSource, "DelegateFeatureName", true, DataSourceUpdateMode.OnValidation);

            //委託類型
            txt_DelegateType.DataBindings.Clear();
            txt_DelegateType.DataBindings.Add("Text", trademarkManagementTBindingSource, "DelegateTypeName", true, DataSourceUpdateMode.OnValidation);

            //主委託人
            txt_MainCustomer.DataBindings.Clear();
            txt_MainCustomer.DataBindings.Add("Text", trademarkManagementTBindingSource, "MainCustomerName", true, DataSourceUpdateMode.OnValidation);

            //主委託人--聯絡窗口
            txt_MainCustomerTransactor.DataBindings.Clear();
            txt_MainCustomerTransactor.DataBindings.Add("Text", trademarkManagementTBindingSource, "MainCustomerTransactorName", true, DataSourceUpdateMode.OnValidation);

            //主委託人--對方案號
            txt_MainCustomerRefNo.DataBindings.Clear();
            txt_MainCustomerRefNo.DataBindings.Add("Text", trademarkManagementTBindingSource, "MainCustomerRefNo", true, DataSourceUpdateMode.OnValidation);

            //是否本所承辦案件
            chb_IsBySelf.DataBindings.Clear();
            chb_IsBySelf.DataBindings.Add("Checked", trademarkManagementTBindingSource, "IsBySelf", true, DataSourceUpdateMode.OnPropertyChanged, false);

            //承辦事務所
            txt_AttorneyFirm.DataBindings.Clear();
            txt_AttorneyFirm.DataBindings.Add("Text", trademarkManagementTBindingSource, "AttorneyFirm", true, DataSourceUpdateMode.OnValidation, "", "");

            //事務所聯絡人
            txt_Liaisoner.DataBindings.Clear();
            txt_Liaisoner.DataBindings.Add("Text", trademarkManagementTBindingSource, "AttLiaisoner", true, DataSourceUpdateMode.OnValidation, "", "");

            //承辦事務所-委辦日期
            maskedTextBox_OutsourcingDate.DataBindings.Clear();
            maskedTextBox_OutsourcingDate.DataBindings.Add("Text", trademarkManagementTBindingSource, "OutsourcingDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            //提案家族
            txt_TrademarkOvertureName.DataBindings.Clear();
            txt_TrademarkOvertureName.DataBindings.Add("Text", trademarkManagementTBindingSource, "TrademarkOvertureName", true, DataSourceUpdateMode.OnValidation);

            txt_StyleName.Clear();
            txt_StyleName.DataBindings.Add("Text", trademarkManagementTBindingSource, "StyleName", true, DataSourceUpdateMode.OnValidation, "", "");
        }
        #endregion

        #region ControlBindingTMNotify
        public void ControlBindingTMNotify()
        {

            txt_NotifyEventContent.DataBindings.Clear();
            txt_NotifyEventContent.DataBindings.Add("Text", trademarkNotifyEventTBindingSource, "NotifyEventContent", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_WorkerKey.DataBindings.Clear(); 
            txt_WorkerKey.DataBindings.Add("Text", trademarkNotifyEventTBindingSource, "EmployeeName", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_NotifyResult.DataBindings.Clear();
            txt_NotifyResult.DataBindings.Add("Text", trademarkNotifyEventTBindingSource, "Result", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_NotifyRemark.DataBindings.Clear();
            txt_NotifyRemark.DataBindings.Add("Text", trademarkNotifyEventTBindingSource, "Remark", true, DataSourceUpdateMode.OnValidation, "", "");

            maskedTextBox_NotifyComitDate.DataBindings.Clear();
            maskedTextBox_NotifyComitDate.DataBindings.Add("Text", trademarkNotifyEventTBindingSource, "NotifyComitDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_NotifyOfficerDate.DataBindings.Clear();
            maskedTextBox_NotifyOfficerDate.DataBindings.Add("Text", trademarkNotifyEventTBindingSource, "NotifyOfficerDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_OccurDate.DataBindings.Clear();
            maskedTextBox_OccurDate.DataBindings.Add("Text", trademarkNotifyEventTBindingSource, "OccurDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_DueDate.DataBindings.Clear();
            maskedTextBox_DueDate.DataBindings.Add("Text", trademarkNotifyEventTBindingSource, "DueDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_Notice.DataBindings.Clear();
            maskedTextBox_Notice.DataBindings.Add("Text", trademarkNotifyEventTBindingSource, "NoticeDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_CustomerAuthorizationDate.DataBindings.Clear();
            maskedTextBox_CustomerAuthorizationDate.DataBindings.Add("Text", trademarkNotifyEventTBindingSource, "CustomerAuthorizationDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            mtb_OutsourcingDate.DataBindings.Clear();
            mtb_OutsourcingDate.DataBindings.Add("Text", trademarkNotifyEventTBindingSource, "OutsourcingDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_FinishDate.DataBindings.Clear();
            maskedTextBox_FinishDate.DataBindings.Add("Text", trademarkNotifyEventTBindingSource, "FinishDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_AttorneyDueDate.DataBindings.Clear();
            maskedTextBox_AttorneyDueDate.DataBindings.Add("Text", trademarkNotifyEventTBindingSource, "AttorneyDueDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

        }
        #endregion        

        #endregion            
   
        
        private void linkLabel_mome_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel link = (LinkLabel)sender;
            US.PopMemo pop;
            switch (link.Name)
            {
                case "linkLabel_CloseCaus":
                    pop = new LawtechPTSystem.US.PopMemo(txt_CloseCaus, true, link.Text);
                    break;
                case "linkLabel_mome":
                    pop = new LawtechPTSystem.US.PopMemo(txt_Remarks, true, link.Text);
                    break;
                case "linkLabel_ComintRemark":
                    pop = new LawtechPTSystem.US.PopMemo(txt_NotifyRemark, true, link.Text);
                    break;
                case "linkLabel_NotifyResult":
                    pop = new LawtechPTSystem.US.PopMemo(txt_NotifyResult, true, link.Text);
                    break;  
                default:
                    pop = new LawtechPTSystem.US.PopMemo(txt_Remarks, true, link.Text);
                    break;
            }

            pop.Show();
        }

       
        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            if (this.DT_TrademarkManagementT.Rows[0]["PicPath"].ToString() != "")
            {
                try
                {
                    string sPath = property_TMrootPath + "\\" + this.DT_TrademarkManagementT.Rows[0]["PicPath"].ToString();
                    Public.Utility.ProcessStart(sPath);
                }
                catch (System.Exception EX)
                {
                    MessageBox.Show(EX.Message, "提示訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureBox1_DoubleClick(null, null);
        }

     

        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
       
    }
}
