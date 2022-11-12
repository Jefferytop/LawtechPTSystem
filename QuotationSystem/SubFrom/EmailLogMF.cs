using H3Operator.DBHelper;
using mshtml;
using System;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LawtechPTSystem.SubFrom
{
    public partial class EmailLogMF : Form
    {
        private IHTMLDocument2 doc;

        public EmailLogMF()
        {
            InitializeComponent();
        }

        UserPermissionForm myPermission;
        private const string ProgramSymbol = "EmailLogMF";
        private const string SourceTableName = "EmailLogT";

        #region EmailLogMF_Load EmailLogMF_FormClosed
        private void EmailLogMF_Load(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.EmailLogMF = this;

            //取得權限
            myPermission = new UserPermissionForm(Properties.Settings.Default.WorkerKEY, ProgramSymbol);

            System.Windows.Forms.BindingNavigator[] listbinding = { emailLogBindingNavigator };
            System.Windows.Forms.ContextMenuStrip[] listtMenu = { contextMenuStrip1 };

            //確認可使用的功能選單
            Public.CommonFunctions.CheckMeunItemVisible(listbinding, myPermission.UserPermission);
            Public.CommonFunctions.CheckMeunItemVisible(listtMenu, myPermission.UserPermission);


            this.emailLogSearchTableAdapter.Fill(this.dataSet_Email.EmailLogSearch);            
            this.emailLogSearchDateTableAdapter.Fill(this.dataSet_Email.EmailLogSearchDate);
         
            this.emailLogTableAdapter.Fill(this.dataSet_Email.EmailLog);
            EmailLogTControlBinding();
            SetupBrowser();
            emailLogDataGridView_SelectionChanged(null,null);
        }

        private void EmailLogMF_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.EmailLogMF = null;
        }
        #endregion

        #region ================EmailLogTControlBinding================
        public void EmailLogTControlBinding()
        {          

            ////
            //txt_EmailSampleType.DataBindings.Clear();
            //txt_EmailSampleType.DataBindings.Add("Text", bSource_xxx, "EmailSampleType", true, DataSourceUpdateMode.OnValidation, "", "");

            //寄件者mail
            txt_EmailSender.DataBindings.Clear();
            txt_EmailSender.DataBindings.Add("Text", emailLogBindingSource, "EmailSender", true, DataSourceUpdateMode.OnValidation, "", "");

            //收件者
            txt_EmailReciver.DataBindings.Clear();
            txt_EmailReciver.DataBindings.Add("Text", emailLogBindingSource, "EmailReciver", true, DataSourceUpdateMode.OnValidation, "", "");

            //副本
            txt_EmailCC.DataBindings.Clear();
            txt_EmailCC.DataBindings.Add("Text", emailLogBindingSource, "EmailCC", true, DataSourceUpdateMode.OnValidation, "", "");

            //密件副本
            txt_EmailBCC.DataBindings.Clear();
            txt_EmailBCC.DataBindings.Add("Text", emailLogBindingSource, "EmailBCC", true, DataSourceUpdateMode.OnValidation, "", "");

            //Mail主旨
            txt_EmailSubject.DataBindings.Clear();
            txt_EmailSubject.DataBindings.Add("Text", emailLogBindingSource, "EmailSubject", true, DataSourceUpdateMode.OnValidation, "", "");

            //Mail格式
            txt_EmailFormat.DataBindings.Clear();
            txt_EmailFormat.DataBindings.Add("Text", emailLogBindingSource, "EmailFormat", true, DataSourceUpdateMode.OnValidation, "", "");

            //mail重要性
            txt_Priority.DataBindings.Clear();
            txt_Priority.DataBindings.Add("Text", emailLogBindingSource, "MailPriorityTXT", true, DataSourceUpdateMode.OnValidation, "", "");

            //內文
            //txt_EmailBody.DataBindings.Clear();
            //txt_EmailBody.DataBindings.Add("Text", emailLogBindingSource, "EmailBody", true, DataSourceUpdateMode.OnValidation, "", "");

            //附件
            txt_AttachFile.DataBindings.Clear();
            txt_AttachFile.DataBindings.Add("Text", emailLogBindingSource, "AttachFile", true, DataSourceUpdateMode.OnValidation, "", "");

            ////本所人員
            //txt_WorkerKey.DataBindings.Clear();
            //txt_WorkerKey.DataBindings.Add("Text", bSource_xxx, "WorkerKey", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            ////寄送時間
            //mask_SendDateTime.DataBindings.Clear();
            //mask_SendDateTime.DataBindings.Add("Text", bSource_xxx, "SendDateTime", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

        }
        #endregion     
       
        #region maskedTextBox_S_DoubleClick
        private void maskedTextBox_S_DoubleClick(object sender, EventArgs e)
        {
            MaskedTextBox mtb = (MaskedTextBox)sender;
            DateTime dt;
            bool IsSuccess = DateTime.TryParse(mtb.Text, out dt);
            if (!IsSuccess)
            {
                mtb.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }
        #endregion

        #region but_Search_Click
        private void but_Search_Click(object sender, EventArgs e)
        {
            but_Search.Enabled = false;

            string times = "";
            string sfilter = "";
            string strFilter1 = "";
            string sFinishDate = "";


            if (comboBox_SelectValue.Text == "" && comboBox_SelectValue1.Text == "" && maskedTextBox_S.Text == "    -  -" && maskedTextBox_D.Text == "    -  -")
            {
                sfilter = "";
            }
            else
            {
                DateTime dtS = new DateTime(), dtE = new DateTime();
                if (maskedTextBox_S.Text != "    -  -")
                {
                    bool IsS = DateTime.TryParse(maskedTextBox_S.Text, out dtS);
                    if (!IsS)
                    {
                        MessageBox.Show("日期格式錯誤 <<" + maskedTextBox_S.Text + ">>");
                        return;
                    }
                }

                if (maskedTextBox_D.Text != "    -  -")
                {
                    bool IsE = DateTime.TryParse(maskedTextBox_D.Text, out dtE);
                    if (!IsE)
                    {
                        MessageBox.Show("日期格式錯誤 <<" + maskedTextBox_D.Text + ">>");
                        return;
                    }
                }

                if (maskedTextBox_S.Text != "    -  -" && maskedTextBox_D.Text != "    -  -")
                {

                    if (dtS > dtE)
                    {
                        maskedTextBox_S.Text = dtE.ToString("yyyy-MM-dd");
                        maskedTextBox_D.Text = dtS.ToString("yyyy-MM-dd");
                    }
                }


                string strDateMode = comboBox_DateMode.SelectedValue.ToString();

                if (maskedTextBox_S.Text != "    -  -" && maskedTextBox_D.Text == "    -  -")
                {
                    times += " " + strDateMode + ">='" + maskedTextBox_S.Text + "'";
                }
                else if (maskedTextBox_S.Text == "    -  -" && maskedTextBox_D.Text != "    -  -")
                {
                    times += " " + strDateMode + "<='" + maskedTextBox_D.Text + "'";
                }
                else if (maskedTextBox_S.Text != "    -  -" && maskedTextBox_D.Text != "    -  -")
                {
                    times += " (" + strDateMode + " >= '" + maskedTextBox_S.Text + "' and " + strDateMode + "<= '" + maskedTextBox_D.Text + "')";
                }

                #region Select 1
                if (comboBox_SelectValue.Text.Trim() != "" || comboBox_SelectValue.SelectedValue != null)
                {
                    switch (comboBox_Select.SelectedValue.ToString())
                    {

                        case "DelContent":
                        case "DelTitle":
                            sfilter = comboBox_Select.SelectedValue.ToString() + " like '%" + comboBox_SelectValue.Text + "%' ";
                            break;
                        case "DelWorkerKey":
                            if (comboBox_SelectValue.SelectedValue != null)
                            {
                                sfilter = comboBox_Select.SelectedValue.ToString() + " = " + comboBox_SelectValue.SelectedValue.ToString();
                            }
                            else
                            {
                                comboBox_SelectValue.Text = "";
                            }
                            break;
                    }
                }
                #endregion

                #region Select 2

                if (comboBox_SelectValue1.Text.Trim() != "" || comboBox_SelectValue1.SelectedValue != null)
                {
                    switch (comboBox_Select1.SelectedValue.ToString())
                    {
                        case "DelContent":
                        case "DelTitle":
                            strFilter1 = comboBox_Select1.SelectedValue.ToString() + " like '%" + comboBox_SelectValue1.Text + "%' ";
                            break;

                        case "DelWorkerKey":
                            if (comboBox_SelectValue1.SelectedValue != null)
                            {
                                strFilter1 = comboBox_Select1.SelectedValue.ToString() + " = " + comboBox_SelectValue1.SelectedValue.ToString();
                            }
                            else
                            {
                                comboBox_SelectValue1.Text = "";
                            }
                            break;
                    }
                }
                #endregion

               
            }

            string FullFilter = "";
            if (strFilter1 != "" && sfilter != "")
            {
                string AndOr = "";
                if (rb_and.Checked)
                {
                    AndOr = " and ";
                    FullFilter = strFilter1 + AndOr + sfilter;
                }
                else
                {
                    AndOr = " or ";
                    FullFilter = "(" + strFilter1 + AndOr + sfilter + ")";
                }

            }
            else if (strFilter1 == "" && sfilter == "")
            {
                FullFilter = "";
            }
            else
            {
                if (strFilter1 != "")
                {
                    FullFilter = strFilter1;
                }
                else
                {
                    FullFilter = sfilter;
                }
            }

            string[] sWhere = { times, sFinishDate, FullFilter };

            StringBuilder FullWhere = new StringBuilder();
            for (int iArray = 0; iArray < sWhere.Length; iArray++)
            {
                if (sWhere[iArray] != "")
                {
                    if (FullWhere.Length > 0)
                    {
                        FullWhere.Append(" and ");
                    }
                    FullWhere.Append(sWhere[iArray]);
                }
            }

            GetEmailLog(FullWhere.ToString());

            but_Search.Enabled = true;
        }
        #endregion

        #region GetEmailLog 取得Email歷史記錄的資料
        /// <summary>
        /// 取得刪除歷史記錄的資料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public void GetEmailLog(string strWhere)
        {
            string strPatentFeeSQL = string.Format(
                        @"
                          SELECT   WorkerT.EmployeeName AS WorkerName, EmailLogT.EmailLogID, EmailLogT.EmailSender, EmailLogT.EmailReciver, 
                            EmailLogT.EmailCC, EmailLogT.EmailBCC, EmailLogT.EmailSubject, EmailLogT.EmailFormat, EmailLogT.MailPriority,
                             EmailLogT.AttachFile, EmailLogT.SendDateTime, EmailSampleTypeT.TypeName, 
                            CASE EmailLogT.MailPriority WHEN 1 THEN '高' WHEN 2 THEN '低' WHEN 3 THEN '普通' END AS MailPriorityTXT, 
                            EmailLogT.EmailSampleType
                            FROM   EmailLogT with(nolock) LEFT OUTER JOIN
                                EmailSampleTypeT with(nolock)  ON EmailLogT.EmailSampleType = EmailSampleTypeT.EmailSampleType LEFT OUTER JOIN
                                WorkerT with(nolock)  ON EmailLogT.WorkerKey = WorkerT.WorkerKey  {0}
                            ORDER BY   EmailLogT.SendDateTime DESC
                                      ", strWhere);

            Public.DLL dll = new Public.DLL();

            dll.FetchDataTable(strPatentFeeSQL, this.dataSet_Email.EmailLog);

        }
        #endregion


        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region SetupBrowser
        private void SetupBrowser()
        {
            WebBrowser_EmailBody.DocumentText = "<HTML><HEAD><TITLE></TITLE></HEAD><BODY></BODY></HTML>";
            doc = WebBrowser_EmailBody.Document.DomDocument as IHTMLDocument2;
            doc.designMode = "Off";
            doc.write("<HTML><HEAD><TITLE></TITLE></HEAD><BODY></BODY></HTML>");

        }
        #endregion

        #region but_Excel_Click
        private void but_Excel_Click(object sender, EventArgs e)
        {
            try
            {
                Public.DLL dll = new Public.DLL();
                Task task = dll.WriteToCSV(emailLogDataGridView);
            }
            catch
            {
                MessageBox.Show("匯出Excel失敗:匯出過程發生異常被終止");
            }
        }
        #endregion

        #region comboBox_Select_SelectedIndexChanged
        private void comboBox_Select_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            Public.DLL dll = new Public.DLL();
            string strSQL = "";
            if (comboBox_Select.SelectedValue != null)
            {
                switch (comboBox_Select.SelectedValue.ToString())
                {
                    case "EmailSender"://主旨

                        strSQL = "select distinct DelTitle from SystemLogT order by DelTitle";
                        dt = dll.SqlDataAdapterDataTable(strSQL);
                        comboBox_SelectValue.DropDownStyle = ComboBoxStyle.DropDown;
                        comboBox_SelectValue.AutoCompleteSource = AutoCompleteSource.ListItems;
                        comboBox_SelectValue.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        comboBox_SelectValue.DataSource = dt;
                        comboBox_SelectValue.DisplayMember = "DelTitle";
                        comboBox_SelectValue.ValueMember = "DelTitle";
                        comboBox_SelectValue.Text = "";
                        break;
                    case "EmailReciver"://刪除者
                        strSQL = "select WorkerKey,ISNULL(NameEn,'')+ Name as WorkerName from WorkerT order by ISNULL(NameEn,'')+ Name";
                        dt = dll.SqlDataAdapterDataTable(strSQL);
                        comboBox_SelectValue.DropDownStyle = ComboBoxStyle.DropDown;
                        comboBox_SelectValue.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        comboBox_SelectValue.AutoCompleteSource = AutoCompleteSource.ListItems;
                        comboBox_SelectValue.DataSource = dt;
                        comboBox_SelectValue.DisplayMember = "WorkerName";
                        comboBox_SelectValue.ValueMember = "WorkerKey";
                        break;
                    default:
                        comboBox_SelectValue.AutoCompleteMode = AutoCompleteMode.None;
                        comboBox_SelectValue.AutoCompleteSource = AutoCompleteSource.None;
                        comboBox_SelectValue.DropDownStyle = ComboBoxStyle.Simple;
                        comboBox_SelectValue.Text = "";
                        break;
                }
            }
        }
        #endregion

        #region emailLogDataGridView_SelectionChanged
        private void emailLogDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (emailLogDataGridView.CurrentRow != null)
            {
                if (WebBrowser_EmailBody.Document != null && WebBrowser_EmailBody.Document.Body != null)
                {
                    int iLog = (int)emailLogDataGridView.CurrentRow.Cells["EmailLogID"].Value;

                    Public.CEmailLog log = new Public.CEmailLog();
                    Public.CEmailLog.ReadOne(iLog,ref  log);

                    if (emailLogDataGridView.CurrentRow.Cells["EmailFormat"].Value.ToString() == "HTML")
                    {
                        WebBrowser_EmailBody.Document.Body.InnerHtml = log.EmailBody;
                    }
                    else
                    {
                        WebBrowser_EmailBody.Document.Body.InnerText = log.EmailBody;
                    }
                }
            }
            else
            {
                if (WebBrowser_EmailBody.Document != null && WebBrowser_EmailBody.Document.Body != null)
                {
                    WebBrowser_EmailBody.Document.Body.InnerText = "";
                }
            }
        }
        #endregion

        private void WebBrowser_EmailBody_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip1.Visible = false;

            switch (e.ClickedItem.Name)
            {
                case "toolStripMenuItem_del":
                case "toolStripButton_Del":
                    if (emailLogDataGridView.CurrentRow != null)
                    {
                        string strDelTitle = emailLogDataGridView.CurrentRow.Cells["dataGridViewTextBoxColumn8"].Value.ToString();
                        if (MessageBox.Show("是否確定刪除【" + strDelTitle + "】", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            int iKey = (int)emailLogDataGridView.CurrentRow.Cells["EmailLogID"].Value;
                            Public.CEmailLog del_Due = new Public.CEmailLog();
                            del_Due.Delete(iKey);

                            var item = emailLogDataGridView.CurrentRow;

                            emailLogDataGridView.Rows.Remove(item);

                            MessageBox.Show("刪除成功", "提示訊息", MessageBoxButtons.OK);
                        }
                    }
                    break;

                case "toolStripMenuItem_del3":
                case "toolStripButton_Del3":
                    if (MessageBox.Show("是否確定刪除3個月以前的資料", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        Public.CEmailLog del_Due = new Public.CEmailLog();
                        del_Due.Delete(" SendDateTime <DATEADD(month,-3,getdate()) ", "");

                        but_Search_Click(null, null);

                        MessageBox.Show("刪除成功", "提示訊息", MessageBoxButtons.OK);
                    }
                    break;
                case "toolStripButton_ClearAll":
                case "toolStripMenuItem_ClearAll":
                    if (MessageBox.Show("是否確定清空Email Logs資料", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        string str = "truncate table EmailLogT";
                        DBAccess db = new DBAccess();
                        object obj = db.ExecuteNonQuery(str);
                        if (obj.ToString() == "0")
                        {
                            MessageBox.Show("清空成功", "提示訊息", MessageBoxButtons.OK);
                        }
                    }
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
