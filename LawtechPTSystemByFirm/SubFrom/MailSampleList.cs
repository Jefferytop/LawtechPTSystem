using System;
using System.Data;
using System.Windows.Forms;
using mshtml;

namespace LawtechPTSystemByFirm.SubFrom
{
    public partial class MailSampleList : Form
    {

        private IHTMLDocument2 doc;

        public MailSampleList()
        {
            InitializeComponent();
            emailSampleTDataGridView.AutoGenerateColumns = false;
        }

        /// <summary>
        /// MailSamplet資料集
        /// </summary>
        public DataTable DT_sampleList
        {
            get
            {
                return dataSet_Email.EmailSampleList;
            }
        }

        private void MailSampleList_Load(object sender, EventArgs e)
        {                     
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            Forms.MailSampleList = this;                       

            this.emailSampleTypeTTableAdapter.Fill(this.dataSet_Email.EmailSampleTypeT);

            //DataRow dr=this.dataSet_Email.EmailSampleTypeT.NewEmailSampleTypeTRow();
            //dr["TypeName"]=" ";
            //dr["EmailSampleType"] = "All";
            //this.dataSet_Email.EmailSampleTypeT.Rows.InsertAt(dr,0);

            SetupBrowser();
            
            but_Refresh_Click(null,null);
           
            ControlBinding();
            
        }

        private void MailSampleList_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            Forms.MailSampleList = null;
        }

        private void ControlBinding()
        {
           
            txt_SampleName.DataBindings.Clear();
            txt_SampleName.DataBindings.Add("Text", emailSampleTBindingSource, "SampleName", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_SampleDescription.DataBindings.Clear();
            txt_SampleDescription.DataBindings.Add("Text", emailSampleTBindingSource, "EmailSampleDescription", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_Priority.DataBindings.Clear();
            txt_Priority.DataBindings.Add("Text", emailSampleTBindingSource, "MailPriority", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_Subject.DataBindings.Clear();
            txt_Subject.DataBindings.Add("Text", emailSampleTBindingSource, "MailSubject", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_Format.DataBindings.Clear();
            txt_Format.DataBindings.Add("Text", emailSampleTBindingSource, "MailFormat", true, DataSourceUpdateMode.OnValidation, "", "");

            //WebBrowser_Body.DataBindings.Clear();
            //WebBrowser_Body.DataBindings.Add("Document.Body.InnerHtml", emailSampleTBindingSource, "MailBody", true, DataSourceUpdateMode.OnValidation, "", "");

        }

        private void SetupBrowser()
        {
            WebBrowser_Body.DocumentText = "<HTML><HEAD><TITLE></TITLE></HEAD><BODY></BODY></HTML>";
            doc = WebBrowser_Body.Document.DomDocument as IHTMLDocument2;
            doc.designMode = "Off";
            doc.write("<HTML><HEAD><TITLE></TITLE></HEAD><BODY></BODY></HTML>");

        }

      
        private void WebBrowser_Body_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string ss = e.Url.ToString();
        }

        private void contextMenuStrip_EmailSample_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip_EmailSample.Visible = false;
            switch (e.ClickedItem.Name)
            {
                case "toolStripButton_Add":
                case "toolStripMenuItem_AddSample":
                    US.SendMailSample sample = new LawtechPTSystemByFirm.US.SendMailSample();
                    sample.SelectType = comboBox_EmailSampleType.SelectedIndex;
                    sample.ShowDialog();

                    break;
                case "toolStripButton_Del":
                case "toolStripMenuItem_DelSample":
                    if (emailSampleTDataGridView.CurrentRow != null)
                    {
                        string sName=emailSampleTDataGridView.CurrentRow.Cells["SampleName"].Value.ToString();
                        if (MessageBox.Show("是否確定刪除 \r\n" + sName, "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            int iKey = (int)emailSampleTDataGridView.CurrentRow.Cells["ESID"].Value;
                            Public.CEmailSample del = new LawtechPTSystemByFirm.Public.CEmailSample("ESID=" + iKey.ToString());
                            del.SetCurrent(iKey);

                            //刪除記錄檔    
                            Public.CSystemLog log = new LawtechPTSystemByFirm.Public.CSystemLog();
                            log.DelTime = DateTime.Now;
                            log.DelWorkerKey = Properties.Settings.Default.WorkerKEY;
                            string[] str = del.GetInsertString(iKey);
                            log.TableName = str[2];
                            log.DelContent_InsertColumn = str[0];
                            log.DelContent_InsertSQL = str[1];
                            log.DelContent = string.Format("範本名稱:{0}\r\n範本使用說明:{1}\r\n mail主旨:{2}\r\n email 格式:{3}", del.SampleName, del.EmailSampleDescription, del.MailSubject, del.MailFormat);
                            log.DelTitle = string.Format("刪除郵件範本設定檔資料【{0}】", del.SampleName);
                            log.Create();

                            del.Delete(iKey);

                            emailSampleTDataGridView.Rows.Remove(emailSampleTDataGridView.CurrentRow);
                            this.dataSet_Email.EmailSampleList.AcceptChanges();

                            MessageBox.Show("刪除範本成功");
                        }
                    }
                    break;
                case "toolStripButton_Edit":
                case "toolStripMenuItem_EditSample":
                    if (emailSampleTDataGridView.CurrentRow != null)
                    {
                        EditForm.EditMailSampleList edit = new LawtechPTSystemByFirm.EditForm.EditMailSampleList();
                        edit.ESID = (int)emailSampleTDataGridView.CurrentRow.Cells["ESID"].Value;
                        edit.ShowDialog();
                    }

                    break;
            }
        }

        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox_EmailSampleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_EmailSampleType.SelectedIndex != -1)
            {
                emailSampleListTableAdapter.Fill(this.dataSet_Email.EmailSampleList, comboBox_EmailSampleType.SelectedValue.ToString());
            }
           
        }

        private void but_Refresh_Click(object sender, EventArgs e)
        {
            if (comboBox_EmailSampleType.SelectedIndex != -1)
            {
                if (comboBox_EmailSampleType.SelectedValue.ToString() == "All")
                {
                    emailSampleListTableAdapter.FillByAll(this.dataSet_Email.EmailSampleList);
                }
                else
                {
                    emailSampleListTableAdapter.Fill(this.dataSet_Email.EmailSampleList, comboBox_EmailSampleType.SelectedValue.ToString());
                }
            }
        }

        private void emailSampleTDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (emailSampleTDataGridView.CurrentRow != null)
            {
                if (WebBrowser_Body.Document != null && WebBrowser_Body.Document.Body != null)
                {
                    if (emailSampleTDataGridView.CurrentRow.Cells["Format"].Value.ToString() == "HTML")
                    {
                        WebBrowser_Body.Document.Body.InnerHtml = emailSampleTDataGridView.CurrentRow.Cells["MailBody"].Value.ToString();
                    }
                    else
                    {
                        WebBrowser_Body.Document.Body.InnerText = emailSampleTDataGridView.CurrentRow.Cells["MailBody"].Value.ToString();
                    }
                }
            }
            else
            {
                if (WebBrowser_Body.Document != null && WebBrowser_Body.Document.Body != null)
                {
                    WebBrowser_Body.Document.Body.InnerText = "";
                }
            }
        }

        private void emailSampleTDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex!=-1 && e.RowIndex!=-1)
            {
                contextMenuStrip_EmailSample_ItemClicked(contextMenuStrip_EmailSample, new ToolStripItemClickedEventArgs(this.toolStripMenuItem_EditSample));
            }
        }

       

      

        
    }
}
