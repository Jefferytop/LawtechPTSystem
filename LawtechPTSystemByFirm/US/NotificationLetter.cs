using System;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace LawtechPTSystemByFirm.US
{
    public partial class NotificationLetter : Form
    {
        private BackgroundWorker bw = new BackgroundWorker();

        string strSender = "", strReciver = "", strCC = "", strBcc = "", strSubject = "", strBody = "", strAttachments = "";
        int intPriorit = 0;

        public NotificationLetter()
        {
            InitializeComponent();

            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);

        }

        private string strEmailSampleType = "";
        /// <summary>
        /// Email類型，專利--Patent 專利案件記錄--PatentEvent  商標--Trademark 
        /// </summary>
        public string EmailSampleType
        {
            get { return strEmailSampleType; }
            set { strEmailSampleType = value; }
        }

        private int iMainParentKey = -1;
        /// <summary>
        /// 案件主Key值;如專利的key 、商標的key
        /// </summary>
        public int MainKey
        {
            get { return iMainParentKey; }
            set { iMainParentKey = value; }
        }


        private int iCaseKey = -1;
        /// <summary>
        /// 案件Key值
        /// </summary>
        public int CaseKey
        {
            get { return iCaseKey; }
            set { iCaseKey = value; }
        }


        private string strCaseNo = "";
        /// <summary>
        /// 案件編號
        /// </summary>
        public string CaseNo
        {
            get { return strCaseNo; }
            set { strCaseNo = value; }
        }

/*
        private int iApplicant = -1;
        /// <summary>
        /// 申請人(舊)
        /// </summary>
        public int Applicant
        {
            get { return iApplicant; }
            set { iApplicant = value; }
        }
        */

          private string strApplicantKeys = "";
        /// <summary>
        /// 申請人
        /// </summary>
          public string ApplicantKeys
        {
            get { return strApplicantKeys; }
            set { strApplicantKeys = value; }
        }
     
        private int iDelegateType = -1;
        /// <summary>
        /// 委託類型
        /// </summary>
        public int DelegateType
        {
            get { return iDelegateType; }
            set { iDelegateType = value; }
        }
        
        private int iAttorney = -1;
        /// <summary>
        /// 承辦事務所
        /// </summary>
        public int Attorney
        {
            get { return iAttorney; }
            set { iAttorney = value; }
        }

        #region ControlBinding
        private void ControlBinding()
        {         

            txt_SampleDescription.DataBindings.Clear();
            txt_SampleDescription.DataBindings.Add("Text", emailSampleListBindingSource, "EmailSampleDescription", true, DataSourceUpdateMode.OnValidation, "", "");

            //comboBox_Priority.DataBindings.Clear();
            //comboBox_Priority.DataBindings.Add("SelectedValue", emailSampleTBindingSource, "MailPriority", true, DataSourceUpdateMode.OnValidation, "", "");

            //comboBox_MailFormat.DataBindings.Clear();
            //comboBox_MailFormat.DataBindings.Add("SelectedValue", emailSampleTBindingSource, "MailPriority", true, DataSourceUpdateMode.OnValidation, "", "");

            //txt_Subject.DataBindings.Clear();
            //txt_Subject.DataBindings.Add("Text", emailSampleTBindingSource, "MailSubject", true, DataSourceUpdateMode.OnValidation, "", "");

            

            //WebBrowser_Body.DataBindings.Clear();
            //WebBrowser_Body.DataBindings.Add("Document.Body.InnerHtml", emailSampleTBindingSource, "MailBody", true, DataSourceUpdateMode.OnValidation, "", "");

        }
        #endregion

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region NotificationLetter_Load
        private void NotificationLetter_Load(object sender, EventArgs e)
        {          

            this.mailPriorityTableAdapter.Fill(this.dataSet_Email.MailPriority);
            
            this.mailFormatTableAdapter.Fill(this.dataSet_Email.MailFormat);

            this.emailSampleListTableAdapter.Fill(this.dataSet_Email.EmailSampleList, EmailSampleType);

            txt_Sender.Text = Properties.Settings.Default.EmailAddress;

            ControlBinding();

            InitListViewColumns();
        }
        #endregion

        #region 收件者
        /// <summary>
        /// 收件者
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void link_Receiver_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (strApplicantKeys=="" && iAttorney == -1)
            {
                MessageBox.Show("該案件無【主委託人】資料和【承辦事務所】資料，\r\n請提供正確的【主委託人】和【承辦事務所】", "提示訊息");
                return;
            }
            US.MailReceive receiver = new MailReceive();
            receiver.ApplicantKeys = strApplicantKeys;
            receiver.Attorney = iAttorney;
            receiver.DelegateType = iDelegateType;

            if (receiver.ShowDialog() == DialogResult.OK)
            {
                txt_Reciver.Text = receiver.MailReceiver;
                txt_cc.Text = receiver.MailCC;
                txt_Bcc.Text = receiver.MailBCC;
            }

        }
        #endregion 

        #region dataGridView1_SelectionChanged
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
            if (dataGridView1.CurrentRow != null)
            {
                txt_Subject.Text =ReplaceLabel( dataGridView1.CurrentRow.Cells["MailSubject"].Value.ToString());
                comboBox_Priority.SelectedValue =dataGridView1.CurrentRow.Cells["MailPriority"].Value.ToString();
                comboBox_MailFormat.SelectedValue=dataGridView1.CurrentRow.Cells["Format"].Value.ToString();

                if (comboBox_MailFormat.SelectedValue.ToString() == "HTML")
                {
                    editorHTML1.BodyHtml =ReplaceLabel( dataGridView1.CurrentRow.Cells["MailBody"].Value.ToString());
                    textBox_Body.Visible = false;
                    editorHTML1.Visible = true;
                }
                else
                {
                    textBox_Body.Text =ReplaceLabel( dataGridView1.CurrentRow.Cells["MailBody"].Value.ToString());
                    textBox_Body.Visible = true;
                    editorHTML1.Visible = false;
                }
            }
        }
        #endregion

        #region comboBox_MailFormat_SelectedIndexChanged
        private void comboBox_MailFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox_MailFormat.SelectedIndex)
            {
                case 0:
                    editorHTML1.Visible = false;
                    textBox_Body.Visible = true;
                    break;

                case 1:
                    editorHTML1.Visible = true;
                    textBox_Body.Visible = false;
                    break;
            }
        }
        #endregion

        #region ================LabelNameCombainT======================
        private DataTable GetLabelNameCombin(string LabelCode)
        {
            string strSQL = @"SELECT         TableColumn, LabelName, CCID
                                FROM             LabelNameCombainT
                                WHERE         (LabelCode = '" + LabelCode + "')";

            Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
            DataTable dt=dll.SqlDataAdapterDataTable(strSQL);
            return dt;
        }
        #endregion

        #region ==============取得專利資料==============
        private DataTable GetPatent(int PatentID)
        {
            QS_DataSetTableAdapters.PatentManagementTTableAdapter patent = new LawtechPTSystemByFirm.QS_DataSetTableAdapters.PatentManagementTTableAdapter();
            QS_DataSet.PatentManagementTDataTable tablePatetn=new QS_DataSet.PatentManagementTDataTable();
            patent.FillByPatentID(tablePatetn, PatentID);           
            return tablePatetn;
        }
        #endregion 

        #region ==============取得專利案件記錄資料==============
        private DataTable GetPatentComit(int PatComitEventID)
        {
            DataSet_EverySearchTableAdapters.PatentComitEventTableAdapter patentComit = new DataSet_EverySearchTableAdapters.PatentComitEventTableAdapter();
            DataSet_EverySearch.PatentComitEventDataTable table_PatentComitEvent = new DataSet_EverySearch.PatentComitEventDataTable();
            patentComit.Fill(table_PatentComitEvent, PatComitEventID);

            return table_PatentComitEvent;
        }
        #endregion 

        #region ==============取得專利請款記錄資料==============
        private DataTable GetPatentFee(int FeeKey)
        {
            DataSet_EverySearchTableAdapters.PatentFeeSearchTableAdapter patentComit = new DataSet_EverySearchTableAdapters.PatentFeeSearchTableAdapter();
            DataSet_EverySearch.PatentFeeSearchDataTable table_PatentFee = new DataSet_EverySearch.PatentFeeSearchDataTable();
            patentComit.Fill(table_PatentFee, FeeKey);

            return table_PatentFee;
        }
        #endregion 

        #region ==============取得專利付款記錄資料==============
        private DataTable GetPatentPayment(int PaymentID)
        {
            DataSet_EverySearchTableAdapters.PatentPaymentSearchTableAdapter patentComit = new DataSet_EverySearchTableAdapters.PatentPaymentSearchTableAdapter();
            DataSet_EverySearch.PatentPaymentSearchDataTable table_PatentPayment = new DataSet_EverySearch.PatentPaymentSearchDataTable();
            patentComit.Fill(table_PatentPayment, PaymentID);

            return table_PatentPayment;
        }
        #endregion 

        #region  =============取得商標資料=============
        private DataTable GetTrademark(int TrademarkID)
        {
            DataSet_TMTableAdapters.TrademarkManagementTTableAdapter Trademark = new LawtechPTSystemByFirm.DataSet_TMTableAdapters.TrademarkManagementTTableAdapter();
            DataSet_TM.TrademarkManagementTDataTable tm = new DataSet_TM.TrademarkManagementTDataTable();
            Trademark.FillByTrademarkID(tm,TrademarkID);
            return tm;
        }
        #endregion

        #region  =============取得商標案件記錄資料=============
        private DataTable GetTrademarkNotifyEventT(int TMNotifyEventID)
        {
            DataSet_EverySearchTableAdapters.TrademarkEventSearchTableAdapter Trademark = new DataSet_EverySearchTableAdapters.TrademarkEventSearchTableAdapter();
            DataSet_EverySearch.TrademarkEventSearchDataTable tm = new DataSet_EverySearch.TrademarkEventSearchDataTable();
            Trademark.Fill(tm, TMNotifyEventID);
            return tm;
        }
        #endregion

        #region  =============取得商標請款資料=============
        private DataTable GetTrademarkFeeT(int FeeKEY)
        {
            DataSet_EverySearchTableAdapters.TrademarkFeeSearchTableAdapter Trademark = new DataSet_EverySearchTableAdapters.TrademarkFeeSearchTableAdapter();
            DataSet_EverySearch.TrademarkFeeSearchDataTable tm = new DataSet_EverySearch.TrademarkFeeSearchDataTable();
            Trademark.Fill(tm, FeeKEY);
            return tm;
        }
        #endregion

        #region  =============取得商標付款資料=============
        private DataTable GetTrademarkPaymentT(int PaymentID)
        {
            DataSet_EverySearchTableAdapters.TrademarkPaymentSearchTableAdapter Trademark = new DataSet_EverySearchTableAdapters.TrademarkPaymentSearchTableAdapter();
            DataSet_EverySearch.TrademarkPaymentSearchDataTable tm = new DataSet_EverySearch.TrademarkPaymentSearchDataTable();
            Trademark.Fill(tm, PaymentID);
            return tm;
        }
        #endregion

        #region  =============取得商標異議資料=============
        private DataTable GetTrademarkControversy(int TrademarkID)
        {
            DataSet_TrademarkControversyTableAdapters.TrademarkControversyManagementTTableAdapter Trademark = new DataSet_TrademarkControversyTableAdapters.TrademarkControversyManagementTTableAdapter();
            DataSet_TrademarkControversy.TrademarkControversyManagementTDataTable tm = new DataSet_TrademarkControversy.TrademarkControversyManagementTDataTable();
            Trademark.FillByID(tm, TrademarkID);
            return tm;
        }
        #endregion

        #region  =============取得商標異議案件記錄資料=============
        private DataTable GetTrademarkControversyNotifyEventT(int TMNotifyEventID)
        {
            DataSet_EverySearchTableAdapters.TrademarkControversyEventSearchTableAdapter Trademark = new DataSet_EverySearchTableAdapters.TrademarkControversyEventSearchTableAdapter();
            DataSet_EverySearch.TrademarkControversyEventSearchDataTable tm = new DataSet_EverySearch.TrademarkControversyEventSearchDataTable();
            Trademark.Fill(tm, TMNotifyEventID);
            return tm;
        }
        #endregion

        #region  =============取得商標異議請款資料=============
        private DataTable GetTrademarkControversyFeeT(int FeeKEY)
        {
            DataSet_EverySearchTableAdapters.TrademarkContronversyFeeSearchTableAdapter Trademark = new DataSet_EverySearchTableAdapters.TrademarkContronversyFeeSearchTableAdapter();
            DataSet_EverySearch.TrademarkContronversyFeeSearchDataTable tm = new DataSet_EverySearch.TrademarkContronversyFeeSearchDataTable();
            Trademark.Fill(tm, FeeKEY);
            return tm;
        }
        #endregion

        #region  =============取得商標異議付款資料=============
        private DataTable GetTrademarkControversyPaymentT(int PaymentID)
        {
            DataSet_EverySearchTableAdapters.TrademarkContronversyPaymentSearchTableAdapter Trademark = new DataSet_EverySearchTableAdapters.TrademarkContronversyPaymentSearchTableAdapter();
            DataSet_EverySearch.TrademarkContronversyPaymentSearchDataTable tm = new DataSet_EverySearch.TrademarkContronversyPaymentSearchDataTable();
            Trademark.Fill(tm, PaymentID);
            return tm;
        }
        #endregion

        #region ============ReplaceLabel================
        /// <summary>
        /// 取代關鍵字，填入正確的值
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        private string ReplaceLabel(string txt)
        {
            if (txt.Contains("{-") && txt.Contains("-}"))
            {
              
                DataTable dtCase = new DataTable();

                switch (EmailSampleType)
                {
                    case "Patent":                                         
                        dtCase = GetPatent(CaseKey);
                        break;
                    case "Trademark":                                    
                        dtCase = GetTrademark(CaseKey);
                        break;
                    case "PatentEvent":
                        dtCase = GetPatentComit(CaseKey);
                        break;
                    case "PatentFee":
                        dtCase = GetPatentFee(CaseKey);
                        break;
                    case "PatentPayment":
                        dtCase = GetPatentPayment(CaseKey);
                        break;
                    case "TrademarkEvent":
                        dtCase = GetTrademarkNotifyEventT(CaseKey);
                        break;
                    case "TrademarkFee":
                        dtCase = GetTrademarkFeeT(CaseKey);
                        break;
                    case "TrademarkPayment":
                        dtCase = GetTrademarkPaymentT(CaseKey);
                        break;
                    case "TrademarkControversy":
                        dtCase = GetTrademarkControversy(CaseKey);
                        break;
                    case "TrademarkControversyEvent":
                        dtCase = GetTrademarkControversyNotifyEventT(CaseKey);
                        break;
                    case "TrademarkControversyFee":
                        dtCase = GetTrademarkControversyFeeT(CaseKey);
                        break;
                    case "TrademarkControversyPayment":
                        dtCase = GetTrademarkControversyPaymentT(CaseKey);
                        break;
                }

                if (dtCase.Rows.Count > 0)
                {
                    DataTable dt_label = GetLabelNameCombin(EmailSampleType);

                    StringBuilder sb = new StringBuilder(txt);

                    for (int iRow = 0; iRow < dt_label.Rows.Count; iRow++)
                    {
                        string ss = "{-" + dt_label.Rows[iRow]["LabelName"].ToString() + "-}";

                        if (txt.Contains(ss))
                        {
                            if (dtCase.Rows[0][dt_label.Rows[iRow]["TableColumn"].ToString()].GetType().ToString() == "System.DateTime")
                            {
                                if (dtCase.Rows[0][dt_label.Rows[iRow]["TableColumn"].ToString()] != null && dtCase.Rows[0][dt_label.Rows[iRow]["TableColumn"].ToString()].ToString() != "")
                                {
                                    sb = sb.Replace(ss, ((DateTime)dtCase.Rows[0][dt_label.Rows[iRow]["TableColumn"].ToString()]).ToShortDateString());
                                }
                            }
                            else if (dtCase.Rows[0][dt_label.Rows[iRow]["TableColumn"].ToString()].GetType().ToString() == "System.Decimal")
                            {
                                if (dtCase.Rows[0][dt_label.Rows[iRow]["TableColumn"].ToString()] != null && dtCase.Rows[0][dt_label.Rows[iRow]["TableColumn"].ToString()].ToString() != "")
                                {
                                    sb = sb.Replace(ss, ((decimal)dtCase.Rows[0][dt_label.Rows[iRow]["TableColumn"].ToString()]).ToString("#,##0.####"));
                                }
                            }
                            else
                            {
                                sb = sb.Replace(ss, dtCase.Rows[0][dt_label.Rows[iRow]["TableColumn"].ToString()].ToString());
                            }
                        }
                    }
                    return sb.ToString();
                }
                else
                {
                    return txt;
                }

            }
            else
            {
                return txt;
            }


        }
        #endregion

        #region but_SendMail_Click
        private void but_SendMail_Click(object sender, EventArgs e)
        {
            if (txt_Reciver.Text == string.Empty)
            {
                MessageBox.Show("請輸入【收件人】", "提示訊息");
                txt_Reciver.Focus();
                return;
            }

            if (txt_Sender.Text == string.Empty)
            {
                MessageBox.Show("【寄件人】不得為空白，請至【個人資料設定】==>【寄件者設定】設定相關資訊", "提示訊息");
                txt_Sender.Focus();
                return;
            }

            if (listView1.Items.Count > 0)
            {
                lab_ms.Visible = true;
                lab_ms.Refresh();
            }

            string sAttachments = GetAttachments();
            int iPriorit = 0;
            switch (comboBox_MailFormat.SelectedValue.ToString())
            {
                case "高":
                    iPriorit = 1;
                    break;
                case "低":
                    iPriorit = 2;
                    break;
                case "一般":
                    iPriorit = 3;
                    break;
                default:
                    iPriorit = 1;
                    break;
            }

            strSender = txt_Sender.Text;
            strReciver = txt_Reciver.Text;
            strCC = txt_cc.Text;
            strBcc = txt_Bcc.Text;
            strSubject = txt_Subject.Text;
            strBody = comboBox_MailFormat.SelectedValue.ToString() == "HTML" ? editorHTML1.BodyHtml : textBox_Body.Text;
            strAttachments = sAttachments;
            intPriorit= iPriorit;

            //bool IsSuccess=false;
            try
            {
                groupBox2.Enabled = false;
                but_SendMail.Enabled = false;
                NotificationLetter.CheckForIllegalCrossThreadCalls = false;
                this.bw.RunWorkerAsync();

                //IsSuccess = Public.EmailClass.SendEmail(txt_Sender.Text, txt_Reciver.Text, txt_cc.Text, txt_Bcc.Text, txt_Subject.Text, comboBox_MailFormat.SelectedValue.ToString() == "HTML" ? editorHTML1.BodyHtml : textBox_Body.Text, comboBox_MailFormat.SelectedValue.ToString() == "HTML" ? true : false, iPriorit, sAttachments);
                
            }
            catch (System.Exception ex)
            {
                but_SendMail.Enabled = true;
                groupBox2.Enabled = true;
                MessageBox.Show(ex.Message);
            }

           //if (IsSuccess)
           //{
           //    lab_ms.Visible = false;
           //    MessageBox.Show("寄送成功", "提示訊息");
           //    this.Close();
           //}
           //else
           //{
           //    but_SendMail.Enabled = true;
           //    MessageBox.Show("寄送失敗，請重新確認相關資料", "提示訊息");
           //}

        }
        #endregion

       
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Public.CEmailLog log = new LawtechPTSystemByFirm.Public.CEmailLog();
                log.EmailSampleType = EmailSampleType;
                log.EmailSender = strSender;
                log.EmailReciver = strReciver;
                log.EmailCC = strCC;
                log.EmailBCC = strBcc;
                log.EmailSubject = strSubject;
                log.EmailFormat = comboBox_MailFormat.SelectedValue.ToString();
                log.MailPriority = intPriorit;
                log.EmailBody = strBody;
                log.WorkerKey = Properties.Settings.Default.WorkerKEY;
                log.SendDateTime = DateTime.Now;
                log.Create();

                Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
                dll.CreatFolder(20, log.EmailLogID.ToString());
                string sRootPath=dll.EmailLogFolderRoot+"\\"+log.EmailLogID.ToString();
                StringBuilder sbFileName = new StringBuilder();
                string[] strAtt = strAttachments.Split(';');
                
                for (int iAtt = 0; iAtt < strAtt.Length; iAtt++)
                {
                    if (strAtt[iAtt].Trim() != "")
                    {
                        FileInfo file = new FileInfo(strAtt[iAtt]);
                        string FullPath=sRootPath+"\\"+file.Name;
                        file.CopyTo(FullPath, true);//複製檔案
                       
                        if (sbFileName.Length > 0)
                        {
                            sbFileName.Append(" ; ");
                        }
                        sbFileName.Append(file.Name);
                    }
                }
                log.AttachFile = sbFileName.ToString();
                log.Update();


                //e.Result = Public.EmailClass.SendEmail(txt_Sender.Text, txt_Reciver.Text, txt_cc.Text, txt_Bcc.Text, txt_Subject.Text, comboBox_MailFormat.SelectedValue.ToString() == "HTML" ? editorHTML1.BodyHtml : textBox_Body.Text, comboBox_MailFormat.SelectedValue.ToString() == "HTML" ? true : false, iPriorit, sAttachments);
                e.Result = Public.EmailClass.SendEmail(strSender, strReciver, strCC, strBcc, strSubject, strBody, true, intPriorit, strAttachments);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }

        }
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            but_SendMail.Enabled = true;
            groupBox2.Enabled = true;

            if ((e.Cancelled == true))
            {
                this.lab_ms.Text = "寄送失敗，請重新確認相關資料!";
            }

            else if (!(e.Error == null))
            {
                this.lab_ms.Text = ("Error: " + e.Error.Message);
            }

            else
            {
                this.lab_ms.Text = "恭禧~~  寄送成功";
                MessageBox.Show("寄送成功", "提示訊息");

                this.Close();
            }
           
            NotificationLetter.CheckForIllegalCrossThreadCalls = true;
           
        }
        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.lab_ms.Text = (e.ProgressPercentage.ToString() + "%");
        }


        #region contextMenuStrip_Attachments_ItemClicked
        private void contextMenuStrip_Attachments_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip_Attachments.Visible = false;

            switch(e.ClickedItem.Name)
            {
                case "ToolStripMenuItem_OpenFile":
                    SubFrom.ViewUpdateFileList subForm = new SubFrom.ViewUpdateFileList();
                    subForm.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    switch (EmailSampleType)
                    {
                        case "Patent":
                            subForm.Text = strCaseNo + "的相關文件";
                            subForm.FileKind = 3;
                            subForm.FileType = 0;
                            subForm.MainParentID =iCaseKey;
                            subForm.radoC.Checked = true;
                            break;
                        case "PatentEvent":
                            subForm.Text = strCaseNo + "的相關文件";
                            subForm.FileKind = 3;
                            subForm.FileType = 1;
                            subForm.MainParentID = MainKey;
                            subForm.radoC.Checked = true;
                            break;
                        case "PatentFee":
                            subForm.Text = strCaseNo + "的相關文件";
                            subForm.FileKind = 3;
                            subForm.FileType = 3;
                            subForm.MainParentID = MainKey;
                            subForm.radoC.Checked = true;
                            break;
                        case "PatentPayment":
                            subForm.Text = strCaseNo + "的相關文件";
                            subForm.FileKind = 3;
                            subForm.FileType = 4;
                            subForm.MainParentID = MainKey;
                            subForm.radoC.Checked = true;
                            break;

                        case "Trademark":
                            subForm.Text = strCaseNo + "的相關文件";
                            subForm.FileKind = 4;
                            subForm.FileType = 6;
                            subForm.MainParentID = iCaseKey;
                            subForm.radoC.Checked = true;
                            break;
                        case "TrademarkEvent":
                            subForm.Text = strCaseNo + "的相關文件";
                            subForm.FileKind = 4;
                            subForm.FileType = 7;
                            subForm.MainParentID = MainKey;
                            subForm.radoC.Checked = true;
                            break;
                        case "TrademarkFee":
                            subForm.Text = strCaseNo + "的相關文件";
                            subForm.FileKind = 4;
                            subForm.FileType = 8;
                            subForm.MainParentID = MainKey;
                            subForm.radoC.Checked = true;
                            break;
                        case "TrademarkPayment":
                            subForm.Text = strCaseNo + "的相關文件";
                            subForm.FileKind = 4;
                            subForm.FileType = 9;
                            subForm.MainParentID = MainKey;
                            subForm.radoC.Checked = true;
                            break;
                        case "TrademarkControversy":
                            subForm.Text = strCaseNo + "的相關文件";
                            subForm.FileKind = 5;
                            subForm.FileType =10;
                            subForm.MainParentID = iCaseKey;
                            subForm.radoC.Checked = true;
                            break;
                        case "TrademarkControversyEvent":
                            subForm.Text = strCaseNo + "的相關文件";
                            subForm.FileKind = 5;
                            subForm.FileType = 11;
                            subForm.MainParentID = MainKey;
                            subForm.radoC.Checked = true;
                            break;
                        case "TrademarkControversyFee":
                            subForm.Text = strCaseNo + "的相關文件";
                            subForm.FileKind = 5;
                            subForm.FileType = 12;
                            subForm.MainParentID = MainKey;
                            subForm.radoC.Checked = true;
                            break;
                        case "TrademarkControversyPayment":
                            subForm.Text = strCaseNo + "的相關文件";
                            subForm.FileKind = 5;
                            subForm.FileType = 13;
                            subForm.MainParentID = MainKey;
                            subForm.radoC.Checked = true;
                            break;
                    }
                    subForm.Show();
                    break;

                case "ToolStripMenuItem_InsertFile":

                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        string[] sFile = openFileDialog1.FileNames;
                        for (int iFile = 0; iFile < sFile.Length; iFile++)
                        {
                            if (sFile.Length > 0 && sFile[iFile].Length > 3 && sFile[iFile].Substring(sFile[iFile].Length - 3).ToLower() != "exe")
                            {
                                FileInfo file = new FileInfo(sFile[iFile]);
                                ListViewItem item = new ListViewItem(new string[4] { file.Name, (Convert.ToInt32(file.Length) / 1024).ToString(), file.LastWriteTime.ToString(), file.FullName });
                                listView1.Items.Add(item);

                            }
                        }
                    }

                   
                    break;

                case "ToolStripMenuItem_Remove":

                    listView1_DoubleClick(null, null);
                    break;
            }
        }
        #endregion

        #region InitListViewColumns
        public void InitListViewColumns()
        {
            listView1.Columns.Add("FileName", "檔案名稱", 150);
            listView1.Columns["FileName"].TextAlign = HorizontalAlignment.Left;

            listView1.Columns.Add("Size", "大小(KB)", 100);
            listView1.Columns["Size"].TextAlign = HorizontalAlignment.Right;

            listView1.Columns.Add("LastDate", "修改日期", 120);
            listView1.Columns["LastDate"].TextAlign = HorizontalAlignment.Left;

            listView1.Columns.Add("FullFileName", "完整路徑", 300);
            listView1.Columns["FullFileName"].TextAlign = HorizontalAlignment.Left;

            listView1.HideSelection = true;
        }
        #endregion

        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetType().ToString() == "System.Windows.Forms.DataObject" || e.Data.GetType().ToString() == "System.String")
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(typeof(string)) != null)
            {
                string[] sFile = e.Data.GetData(typeof(string)).ToString().Split(';');
                for (int iFile = 0; iFile < sFile.Length; iFile++)
                {
                    if (sFile.Length > 0 && sFile[iFile].Length > 3 && sFile[iFile].Substring(sFile[iFile].Length - 3).ToLower() != "exe")
                    {
                        FileInfo file = new FileInfo(sFile[iFile]);
                        ListViewItem item = new ListViewItem(new string[4] { file.Name, (Convert.ToInt32(file.Length) / 1024).ToString(), file.LastWriteTime.ToString(), file.FullName });
                        listView1.Items.Add(item);

                    }
                }
            }
            else
            {
                string[] sFile = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                for (int iFile = 0; iFile < sFile.Length; iFile++)
                {
                    if (sFile.Length > 0 && sFile[iFile].Length > 3 && sFile[iFile].Substring(sFile[iFile].Length - 3).ToLower() != "exe")
                    {
                        FileInfo file = new FileInfo(sFile[iFile]);
                        ListViewItem item = new ListViewItem(new string[4] { file.Name, (Convert.ToInt32(file.Length) / 1024).ToString(), file.LastWriteTime.ToString(), file.FullName });
                        listView1.Items.Add(item);

                    }
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            contextMenuStrip_Attachments_ItemClicked(contextMenuStrip_Attachments, new ToolStripItemClickedEventArgs(ToolStripMenuItem_OpenFile));
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                listView1.SelectedItems[0].Remove();
            }
        }

        #region 取得附件路徑字串
        /// <summary>
        /// 取得附件路徑字串
        /// </summary>
        /// <returns></returns>
        private string GetAttachments()
        {
            StringBuilder sb = new StringBuilder();
            for (int iRows = 0; iRows < listView1.Items.Count;iRows++ )
            {
                sb.Append(listView1.Items[iRows].SubItems[3].Text);

                if (iRows < listView1.Items.Count - 1)
                {
                    sb.Append(";");
                }
            }

            return sb.ToString();
        }
        #endregion
    }
}
