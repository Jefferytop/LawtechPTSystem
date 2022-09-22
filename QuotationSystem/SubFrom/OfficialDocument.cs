using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.SubFrom
{
    public partial class OfficialDocument : Form
    {

        UserPermissionForm myPermission;
        private const string ProgramSymbol = "OfficialDocument";
        private const string SourceTableName = "OfficialDocumentT";

        #region ==========Property ==========

        private int iWorkerID = -1;
        /// <summary>
        /// 登入者ID
        /// </summary>
        public int WorkerID
        {
            get { return iWorkerID; }
            set { iWorkerID = value; }
        }

        private string strWorkerName = "";
        /// <summary>
        /// 登入者的名字
        /// </summary>
        public string Property_WorkerName
        {
            get { return strWorkerName; }
            set { strWorkerName = value; }
        }

        
        /// <summary>
        /// 登入者的權限身份 1.員工 2.專利主管 3.商標主管 0.admin
        /// </summary>
        public int OfficeRole
        {
            get { return Properties.Settings.Default.OfficeRole; }
        }

        /// <summary>
        /// 
        /// </summary>
        public void ReLoad()
        {
            but_Search_Click(null, null);
        }

        #endregion

        #region =========資料集=========
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

        private DataTable dt_TrademarkNotifyEventT = new DataTable();
        /// <summary>
        /// TrademarkNotifyEventT 事件記錄
        /// </summary>
        public DataTable DT_TrademarkNotifyEventT
        {
            get
            {
                return dt_TrademarkNotifyEventT;
            }

        }

        private DataTable dt_OfficialDocument = new DataTable();
        /// <summary>
        /// 官方公文資料表
        /// </summary>
        public System.Data.DataTable DT_OfficialDocument
        {
            get
            {
                return dt_OfficialDocument;
            }
        }

        #endregion

        public OfficialDocument()
        {
            InitializeComponent();
            dataGridView_OfficialDocument.AutoGenerateColumns = false;
            Public.DynamicGridViewColumn.GetGridColum(ref dataGridView_OfficialDocument);

            dataGridView_Event.AutoGenerateColumns = false;
            Public.DynamicGridViewColumn.GetGridColum(ref dataGridView_Event);
        }

        #region private void OfficialDocument_Load(object sender, System.EventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OfficialDocument_Load(object sender, System.EventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.OfficialDocument = this;

            //取得登入者身份
            iWorkerID = Properties.Settings.Default.WorkerKEY;
            Worker_Model worker = new Worker_Model();
            Worker_Model.ReadOne(iWorkerID, ref worker);

            //取得權限
            myPermission = new UserPermissionForm(Properties.Settings.Default.WorkerKEY, ProgramSymbol);

            System.Windows.Forms.BindingNavigator[] listbinding = { bindingNavigator1,bindingNavigator_Event };
            System.Windows.Forms.ContextMenuStrip[] listtMenu = { contextMenuStrip1, contextMenuStrip_Event };

            //確認可使用的功能選單
            Public.CommonFunctions.CheckMeunItemVisible(listbinding, myPermission.UserPermission);
            Public.CommonFunctions.CheckMeunItemVisible(listtMenu, myPermission.UserPermission);

            Public.Utility.SetLoadDataRange(userControlFilterDate1);

            if (Properties.Settings.Default.IsLoadData)
            {
                but_Search_Click(null, null);
            }


        }

        #endregion

        #region private void OfficialDocument_FormClosed(object sender, FormClosedEventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OfficialDocument_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.OfficialDocument = null;
        }

        #endregion

        #region private void but_Search_Click(object sender, System.EventArgs e)
        /// <summary>
        /// 查詢按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_Search_Click(object sender, System.EventArgs e)
        {
            but_Search.Enabled = false;

            string strFilter = "";
            if (chb_Finish.Checked) //已完成
            {
                strFilter += " EventCount >0 ";
            }
            else if (chb_NoFinish.Checked)//未完成
            {
                strFilter += " EventCount=0 ";
            }

            string FullWhere = Public.CommonFunctions.GetSQLScript(QueryFilter1, QueryFilter2, rb_and.Checked ? " and " : " or ", userControlFilterDate1);

            string SQL = string.IsNullOrEmpty(FullWhere) ? strFilter : strFilter + " and " + FullWhere;

            dt_OfficialDocument = Public.COfficialDocumentPublicFunction.GetOfficialDocumentT(SQL);
            bindingSource1.DataSource = dt_OfficialDocument;

            but_Search.Enabled = true;

        }
        #endregion

        private void ChkSelected(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                rb.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btn_27;
                but_Search_Click(null, null);
            }
            else
            {
                rb.BackgroundImage = null;
            }
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip1.Visible = false;            

            switch (e.ClickedItem.Name)
            {
                case "toolStripMenuItem_Add":
                    if (dataGridView_OfficialDocument.CurrentRow != null)
                    {
                        int iKey = (int)dataGridView_OfficialDocument.CurrentRow.Cells["OfficialDocumentKey"].Value;
                        string Type = dataGridView_OfficialDocument.CurrentRow.Cells["CaseType"].Value.ToString().Trim();
                        string strDocumentNumber = dataGridView_OfficialDocument.CurrentRow.Cells["DocumentNumber"].Value.ToString();
                        string ApplicationNo = dataGridView_OfficialDocument.CurrentRow.Cells["ApplicationNo"].Value.ToString();
                        string Summary = dataGridView_OfficialDocument.CurrentRow.Cells["Summary"].Value.ToString();
                        string ProcessingPeriod = dataGridView_OfficialDocument.CurrentRow.Cells["ProcessingPeriod"].Value.ToString();
                        DateTime dtProcessingPeriod;
                        bool bpp = DateTime.TryParse(ProcessingPeriod, out dtProcessingPeriod);

                        string IssueDate = dataGridView_OfficialDocument.CurrentRow.Cells["IssueDate"].Value.ToString();
                        DateTime dtIssuedate;
                        bool isDate = DateTime.TryParse(IssueDate, out dtIssuedate);

                        string SubmissionTime = dataGridView_OfficialDocument.CurrentRow.Cells["SubmissionTime"].Value.ToString();
                        DateTime dtSubmissionTime;
                        bool isSubmissionTime = DateTime.TryParse(SubmissionTime, out dtSubmissionTime);

                        string DuringProcessing = dataGridView_OfficialDocument.CurrentRow.Cells["DuringProcessing"].Value.ToString();
                        int imon = 0;
                        switch (DuringProcessing)
                        {
                            case "1個月":
                                imon = 1;
                                break;
                            case "2個月":
                                imon = 2;
                                break;
                            case "3個月":
                                imon = 3;
                                break;
                        }

                        //if (iCaseEventKey == -1)
                        //{
                        switch (Type)
                        {
                            case "P":
                                #region 專利
                                List<Public.CPatentManagement> patList = new List<Public.CPatentManagement>();
                                Public.CPatentManagement.ReadList(ref patList, string.Format("ApplicationNo='{0}' ", ApplicationNo));
                                if (patList.Count > 0)
                                {
                                    AddFrom.AddPatentComitEvent comit = new AddFrom.AddPatentComitEvent();
                                    comit.Text += "(" + patList[0].PatentNo + "   申請案號：" + patList[0].ApplicationNo + " |  發文文號：" + strDocumentNumber + ")";
                                    comit.CountrySymbol = patList[0].CountrySymbol;
                                    comit.PatentID = patList[0].PatentID;
                                    comit.OfficialDocumentKey = iKey;
                                    if (isDate)
                                    {
                                        comit.OfficerDate = dtIssuedate.ToString("yyyy/MM/dd");
                                    }

                                    if (isSubmissionTime)
                                    {
                                        comit.OccurDate = dtSubmissionTime.ToString("yyyy/MM/dd");
                                        comit.DueDate = dtSubmissionTime.AddMonths(imon).ToString("yyyy/MM/dd");
                                    }

                                    if (bpp)
                                    {
                                        comit.DueDate = dtProcessingPeriod.ToString("yyyy/MM/dd");
                                    }
                                    comit.Remark = "發文文號：" + strDocumentNumber + "\r\n案由：" + Summary;
                                    comit.ShowDialog();
                                }
                                else
                                {
                                    MessageBox.Show("查無申請案號 " + ApplicationNo);
                                }
                                #endregion
                                break;
                            case "T":
                                #region 商標
                                List<Public.CTrademarkManagement> TmList = new List<Public.CTrademarkManagement>();
                                Public.CTrademarkManagement.ReadList(ref TmList, string.Format("ApplicationNo='{0}' ", ApplicationNo));
                                if (TmList.Count > 0)
                                {
                                    AddFrom.AddTrademarkNotifyEvent comit = new AddFrom.AddTrademarkNotifyEvent();
                                    comit.Text += "(" + TmList[0].TrademarkNo + "  申請案號：" + TmList[0].ApplicationNo + " |  發文文號：" + strDocumentNumber + ")";
                                    comit.CountrySymbol = TmList[0].CountrySymbol;
                                    comit.TrademarkID = TmList[0].TrademarkID;
                                    comit.OfficialDocumentKey = iKey;
                                    if (isDate)
                                    {
                                        comit.OfficerDate = dtIssuedate.ToString("yyyy/MM/dd");
                                    }

                                    if (isSubmissionTime)
                                    {
                                        comit.OccurDate = dtSubmissionTime.ToString("yyyy/MM/dd");
                                        comit.DueDate = dtSubmissionTime.AddMonths(imon).ToString("yyyy/MM/dd");
                                    }

                                    if (bpp)
                                    {
                                        comit.DueDate = dtProcessingPeriod.ToString("yyyy/MM/dd");
                                    }

                                    comit.Remark = "發文文號：" + strDocumentNumber + "\r\n案由：" + Summary;
                                    comit.ShowDialog();
                                }
                                else
                                {
                                    MessageBox.Show("查無申請案號 " + ApplicationNo);
                                }
                                #endregion
                                break;
                        }
                        //}
                        //else
                        //{
                        //    MessageBox.Show("該「發文文號 " + strDocumentNumber + " 」已綁定事件記錄 !! ");
                        //}

                    }
                    break;

                case "toolStripMenuItem_Del":
                    if (dataGridView_OfficialDocument.CurrentRow != null)
                    {
                        int iKey = (int)dataGridView_OfficialDocument.CurrentRow.Cells["OfficialDocumentKey"].Value;
                        string strDocumentNumber = dataGridView_OfficialDocument.CurrentRow.Cells["DocumentNumber"].Value.ToString();
                        if (MessageBox.Show("是否確定刪除【" + strDocumentNumber + "】", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            Public.COfficialDocumentT del = new Public.COfficialDocumentT();
                            Public.COfficialDocumentT.ReadOne(iKey, ref del);

                            Public.COfficialDocumentEventT delevent = new Public.COfficialDocumentEventT();
                            delevent.Delete("OfficialDocumentKey=" + iKey, "");

                            //刪除記錄檔    
                            Public.CSystemLogT log = new Public.CSystemLogT();
                            log.DelTime = DateTime.Now;
                            log.DelWorkerKey = Properties.Settings.Default.WorkerKEY;
                            log.DelWorker = Properties.Settings.Default.WorkerName;
                            log.DelContent = string.Format("申請案號:{3}\r\n案由:{0}\r\n 發文字號:{1}\r\n案件種類:{2}", del.Summary, del.TextNumber, del.CaseType, del.ApplicationNo);
                            log.DelTitle = string.Format("刪除「{0}」資料【發文文號-{1}】", this.Text, del.DocumentNumber);
                            log.Create();

                            del.Delete();

                            dataGridView_OfficialDocument.Rows.Remove(dataGridView_OfficialDocument.CurrentRow);
                        }
                    }
                    break;
                case "toolStripMenuItem_DelSelect":
                    if (dataGridView_OfficialDocument.Rows.Count > 0)
                    {
                        dataGridView_OfficialDocument.CurrentRow.Cells["ColumnCheck"].Selected = false;
                        if (MessageBox.Show("是否確定刪除批次刪除", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            try
                            {
                                for (int i = 0; i < dataGridView_OfficialDocument.Rows.Count; i++)
                                {
                                    bool isEditChanged = ((System.Windows.Forms.DataGridViewCheckBoxCell)dataGridView_OfficialDocument.Rows[i].Cells["ColumnCheck"]).EditingCellValueChanged;
                                    if (isEditChanged)
                                    {
                                        dataGridView_OfficialDocument.Rows[i].Cells["ColumnCheck"].Value = (bool)((System.Windows.Forms.DataGridViewCheckBoxCell)dataGridView_OfficialDocument.Rows[i].Cells["ColumnCheck"]).EditedFormattedValue;                                       
                                    }

                                    if (dataGridView_OfficialDocument.Rows[i].Cells["ColumnCheck"].Value != null && (dataGridView_OfficialDocument.Rows[i].Cells["ColumnCheck"].Value.ToString() == "1" || dataGridView_OfficialDocument.Rows[i].Cells["ColumnCheck"].Value.ToString() == "True"))
                                    {
                                        int iKey = (int)dataGridView_OfficialDocument.Rows[i].Cells["OfficialDocumentKey"].Value;
                                        Public.COfficialDocumentT del = new Public.COfficialDocumentT();
                                        Public.COfficialDocumentT.ReadOne(iKey, ref del);

                                        //公文轉事件關聯表
                                        Public.COfficialDocumentEventT delevent = new Public.COfficialDocumentEventT();
                                        delevent.Delete("OfficialDocumentKey=" + iKey, "");

                                        //刪除記錄檔    
                                        Public.CSystemLogT log = new Public.CSystemLogT();
                                        log.DelTime = DateTime.Now;
                                        log.DelWorkerKey = Properties.Settings.Default.WorkerKEY;
                                        log.DelWorker = Properties.Settings.Default.WorkerName;
                                        log.DelContent = string.Format("申請案號:{3}\r\n案由:{0}\r\n 發文字號:{1}\r\n案件種類:{2}", del.Summary, del.TextNumber, del.CaseType, del.ApplicationNo);
                                        log.DelTitle = string.Format("刪除「{0}」資料【發文文號-{1}】", this.Text, del.DocumentNumber);
                                        log.Create();

                                        del.Delete();
                                    }

                                }
                                but_Search_Click(null, null);
                            }
                            catch { }
                        }

                    }
                    break;
                case "toolStripMenuItem_Import":
                    US.ImportCSV imp = new US.ImportCSV();
                    imp.ShowDialog();
                    break;
                case "toolStripMenuItem_SetGridColumn":
                    SetGridColumnT gc = new SetGridColumnT();
                    gc.CurrentGridSymboID = dataGridView_OfficialDocument.Tag.ToString();
                    gc.TitleName = "官方公文列表";
                    gc.Show();
                    break;

                case "SelectAllToolStripMenuItem":
                    if (dataGridView_OfficialDocument.Rows.Count > 0)
                    {
                        dataGridView_OfficialDocument.CurrentCell.Selected = false;
                        //dataGridView_OfficialDocument.CurrentRow.Cells["StaYear"].Selected = true;

                        for (int i = 0; i < dataGridView_OfficialDocument.Rows.Count; i++)
                        {
                            dataGridView_OfficialDocument.Rows[i].Cells["ColumnCheck"].Value = 1;
                        }
                    }
                    break;
                case "CacelSelectToolStripMenuItem":
                    if (dataGridView_OfficialDocument.Rows.Count > 0)
                    {
                        dataGridView_OfficialDocument.CurrentCell.Selected = false;
                        // dataGridView_OfficialDocument.CurrentRow.Cells["StaYear"].Selected = true;
                        for (int i = 0; i < dataGridView_OfficialDocument.Rows.Count; i++)
                        {
                            dataGridView_OfficialDocument.Rows[i].Cells["ColumnCheck"].Value = 0;
                        }
                    }
                    break;
            }

        }

        private void but_Close_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void but_Import_Click(object sender, System.EventArgs e)
        {
            US.ImportCSV imp = new US.ImportCSV();
            imp.ShowDialog();
        }

        private void dataGridView_OfficialDocument_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                string Type = dataGridView_OfficialDocument.CurrentRow.Cells["CaseType"].Value.ToString().Trim();
                string ApplicationNo = dataGridView_OfficialDocument.CurrentRow.Cells["ApplicationNo"].Value.ToString();
                int iCaseEventKey = (dataGridView_OfficialDocument.CurrentRow.Cells["CaseEventKey"] != null && dataGridView_OfficialDocument.CurrentRow.Cells["CaseEventKey"].Value != DBNull.Value) ? (int)dataGridView_OfficialDocument.CurrentRow.Cells["CaseEventKey"].Value : -1;
                string strDocumentNumber = dataGridView_OfficialDocument.CurrentRow.Cells["DocumentNumber"].Value.ToString();

                switch (Type)
                {
                    case "P":
                        List<Public.CPatentManagement> patList = new List<Public.CPatentManagement>();
                        Public.CPatentManagement.ReadList(ref patList, string.Format("ApplicationNo='{0}' ", ApplicationNo));
                        if (patList.Count > 0)
                        {
                            PatentHistoryRecord1 patent = new LawtechPTSystem.SubFrom.PatentHistoryRecord1();
                            patent.property_PatentID = patList[0].PatentID;
                            if (iCaseEventKey != -1)
                            {
                                patent.TabSelectedIndex = 1;
                            }
                            else
                            {
                                patent.TabSelectedIndex = 0;
                            }
                            patent.Show();
                        }
                        else {
                            MessageBox.Show("查無對應的申請案號 「" + ApplicationNo + "」  !! ");
                        }
                        break;

                    case "T":
                        List<Public.CTrademarkManagement> TmList = new List<Public.CTrademarkManagement>();
                        Public.CTrademarkManagement.ReadList(ref TmList, string.Format("ApplicationNo='{0}' ", ApplicationNo));
                        if (TmList.Count > 0)
                        {
                            TrademarkHistoryRecord HistoryRecord = new TrademarkHistoryRecord();
                            HistoryRecord.TrademarkID = (int)TmList[0].TrademarkID;
                            if (iCaseEventKey != -1)
                            {
                                HistoryRecord.TabSelectedIndex = 1;
                            }
                            else
                            {
                                HistoryRecord.TabSelectedIndex = 0;
                            }                               
                            HistoryRecord.Show();
                        }
                        else
                        {
                            MessageBox.Show("查無對應的申請案號 「" + ApplicationNo + "」  !! ");
                        }
                        break;
                }



                //MessageBox.Show("該「發文文號 " + strDocumentNumber + "」 未指派到案件 !! ");


            }
        }

        private void dataGridView_OfficialDocument_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }

        private void dataGridView_OfficialDocument_SelectionChanged(object sender, EventArgs e)
        {
            try
            {

                if (dataGridView_OfficialDocument.CurrentRow != null && dataGridView_OfficialDocument.CurrentRow.Cells["CaseType"].Value !=null && dataGridView_OfficialDocument.CurrentRow.Cells["CaseType"].Value != DBNull.Value)
                {
                    string strCaseType = dataGridView_OfficialDocument.CurrentRow.Cells["CaseType"].Value.ToString();
                    int iOfficialDocumentKey = (int)dataGridView_OfficialDocument.CurrentRow.Cells["OfficialDocumentKey"].Value;
                    switch (strCaseType)
                    {
                        case "P":
                            if (dataGridView_Event.Tag.ToString() != "PatListMF_Event")
                            {
                                dataGridView_Event.Tag = "PatListMF_Event";
                                Public.DynamicGridViewColumn.GetGridColum(ref dataGridView_Event);
                                dataGridView_Event.DataSource = bindingSource_Event;
                            }
                            tagTitle2.TitleLableText = "公文轉換成事件--專利--" + dataGridView_OfficialDocument.CurrentRow.Cells["DocumentNumber"].Value.ToString();
                            Public.CPatentPublicFunction.GetOfficialDocumentPatentEvent(iOfficialDocumentKey.ToString(), ref dt_PatComitEventT);
                            int irowsP = dt_TrademarkNotifyEventT.Rows.Count;
                            bindingSource_Event.DataSource = dt_PatComitEventT;
                            break;
                        case "T":
                            if (dataGridView_Event.Tag.ToString() != "TrademarkMF_Event")
                            {
                                dataGridView_Event.Tag = "TrademarkMF_Event";
                                Public.DynamicGridViewColumn.GetGridColum(ref dataGridView_Event);
                                dataGridView_Event.DataSource = bindingSource_Event;
                            }
                            tagTitle2.TitleLableText = "公文轉換成事件--商標--" + dataGridView_OfficialDocument.CurrentRow.Cells["DocumentNumber"].Value.ToString();
                            Public.CTrademarkPublicFunction.GetOfficialDocumentTrademarkEvent(iOfficialDocumentKey.ToString(), ref dt_TrademarkNotifyEventT);
                            int irowsT = dt_TrademarkNotifyEventT.Rows.Count;
                            bindingSource_Event.DataSource = dt_TrademarkNotifyEventT;
                            break;
                    }

                }
                else
                {
                    this.dt_PatComitEventT.Rows.Clear();
                }


            }
            catch (System.Exception ex)
            {
                string ss = ex.Message;
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 事件快顯功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip_Event_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip1.Visible = false;
            string strCaseType = dataGridView_OfficialDocument.CurrentRow.Cells["CaseType"].Value.ToString();

            switch (e.ClickedItem.Name)
            {
                case "toolStripButton_AddEvent":
                case "toolStripMenuItem_EventAdd":
                    contextMenuStrip1_ItemClicked(contextMenuStrip1, new ToolStripItemClickedEventArgs(toolStripMenuItem_Add));
                    break;
                case "toolStripButton_EditEvent":
                case "toolStripMenuItem_EventEdit":
                    switch (strCaseType)
                    {
                        case "P":
                            #region 專利
                            if (dataGridView_Event.CurrentRow != null)
                            {
                                //判斷是否有人使用中
                                int iLocker = Public.Utility.GetRecordAuth("PatComitEventT", "PatComitEventID=" + dataGridView_Event.CurrentRow.Cells["PatComitEventID"].Value.ToString());
                                if (iLocker == -1 || iLocker == iWorkerID)
                                {
                                    if (iLocker != iWorkerID)
                                    {
                                        Public.Utility.LockRecordAuth("PatComitEventT", iWorkerID, "PatComitEventID=" + dataGridView_Event.CurrentRow.Cells["PatComitEventID"].Value.ToString());
                                    }
                                    EditForm.EditComitEvent comit_Edit = new EditForm.EditComitEvent();
                                    int iPatComitEventID = (int)dataGridView_Event.CurrentRow.Cells["PatComitEventID"].Value;
                                    Public.CPatComitEvent patevent = new Public.CPatComitEvent();
                                    Public.CPatComitEvent.ReadOne(iPatComitEventID, ref patevent, "");

                                    Public.CPatentManagement pat = new Public.CPatentManagement();
                                    Public.CPatentManagement.ReadOne(patevent.PatentID, ref pat, "");
                                    comit_Edit.PatComitEventID = iPatComitEventID;
                                    comit_Edit.PatentID = patevent.PatentID;
                                    comit_Edit.Text += "(" + pat.PatentNo + " " + pat.CountrySymbol + ")";
                                    comit_Edit.CountrySymbol = pat.CountrySymbol;
                                    comit_Edit.ShowDialog();
                                }
                                else
                                {
                                    if (iLocker != -1)//無人使用中
                                    {
                                        Worker_Model worker = new Worker_Model();
                                        Worker_Model.ReadOne(iLocker, ref worker);
                                        MessageBox.Show("很抱歉~~   目前該筆資料正被【" + worker.EmployeeName + "】使用中，請等候!!\r\n 謝謝", "提示訊息");
                                    }
                                }
                            } 
                            #endregion

                            break;
                        case "T":
                            #region 商標
                            if (dataGridView_Event.CurrentRow != null)
                            {
                                //判斷是否有人使用中
                                int iLocker = Public.Utility.GetRecordAuth("TrademarkNotifyEventT", "TMNotifyEventID=" + dataGridView_Event.CurrentRow.Cells["TMNotifyEventID"].Value.ToString());
                                if (iLocker == -1 || iLocker == iWorkerID)
                                {
                                    if (iLocker != iWorkerID)
                                    {
                                        Public.Utility.LockRecordAuth("TrademarkNotifyEventT", iWorkerID, "TMNotifyEventID=" + dataGridView_Event.CurrentRow.Cells["TMNotifyEventID"].Value.ToString());
                                    }
                                    EditForm.EditTrademarkNotifyEvent comit_Edit = new EditForm.EditTrademarkNotifyEvent();
                                    int iPatComitEventID = (int)dataGridView_Event.CurrentRow.Cells["TMNotifyEventID"].Value;
                                    Public.CTrademarkNotifyEvent tmEvent = new Public.CTrademarkNotifyEvent();
                                    Public.CTrademarkNotifyEvent.ReadOne(iPatComitEventID, ref tmEvent, "");

                                    Public.CTrademarkManagement Tm = new Public.CTrademarkManagement();
                                    Public.CTrademarkManagement.ReadOne(tmEvent.TrademarkID, ref Tm, "");
                                    comit_Edit.property_TMNotifyEventID = iPatComitEventID;
                                    comit_Edit.TrademarkID = Tm.TrademarkID;
                                    comit_Edit.Text += "(" + Tm.TrademarkNo + " " + Tm.CountrySymbol + ")";
                                    comit_Edit.CountrySymbol = Tm.CountrySymbol;
                                    comit_Edit.ShowDialog();
                                }
                                else
                                {
                                    if (iLocker != -1)//無人使用中
                                    {
                                        Worker_Model worker = new Worker_Model();
                                        Worker_Model.ReadOne(iLocker, ref worker);
                                        MessageBox.Show("很抱歉~~   目前該筆資料正被【" + worker.EmployeeName + "】使用中，請等候!!\r\n 謝謝", "提示訊息");
                                    }
                                }
                            } 
                            #endregion
                            break;
                    }
                    break;
                case "toolStripButton_DelEvent":
                case "toolStripMenuItem_EventDel":
                    switch (strCaseType)
                    {
                        case "P":
                            #region 專利
                            if (dataGridView_Event.CurrentRow != null)
                            {
                                if (dataGridView_Event.CurrentRow.Cells["EventSingCode"].Value.ToString() != "")
                                {
                                    MessageBox.Show("已有主管簽核，不得刪除，若要刪除，請洽簽核主管", "提示訊息", MessageBoxButtons.OK);
                                    return;
                                }

                                int iPatComitEventID = (int)dataGridView_Event.CurrentRow.Cells["PatComitEventID"].Value;
                                //判斷是否有人使用中
                                int iLocker = Public.Utility.GetRecordAuth("PatComitEventT", "PatComitEventID=" + iPatComitEventID.ToString());
                                if (iLocker == -1 || iLocker == iWorkerID)
                                {
                                    if (iLocker != iWorkerID)
                                    {
                                        Public.Utility.LockRecordAuth("PatComitEventT", iWorkerID, "PatComitEventID=" + dataGridView_Event.CurrentRow.Cells["PatComitEventID"].Value.ToString());
                                    }

                                    string ssName = dataGridView_Event.CurrentRow.Cells["EventContent"].Value.ToString();

                                    if (MessageBox.Show("是否確定刪除【" + ssName + "】", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                                    {
                                        int iKey = (int)dataGridView_Event.CurrentRow.Cells["PatComitEventID"].Value;
                                        Public.CPatComitEvent PatentComit = new Public.CPatComitEvent();
                                        Public.CPatComitEvent.ReadOne(iKey, ref PatentComit);

                                        //刪除標準流程項目
                                        Public.CPatWorkReport patwork = new Public.CPatWorkReport();
                                        patwork.Delete(" EventID=" + iPatComitEventID.ToString(), "");

                                        //刪除事件轉請款
                                        Public.CPatComitEventToFee ComitEventToFee = new Public.CPatComitEventToFee();
                                        ComitEventToFee.Delete("PatComitEventID=" + dataGridView_Event.CurrentRow.Cells["PatComitEventID"].Value.ToString(), "");

                                        //刪除事件轉付款
                                        Public.CPatComitEventToPayment ComitEventToPayment = new Public.CPatComitEventToPayment();
                                        ComitEventToPayment.Delete("PatComitEventID=" + dataGridView_Event.CurrentRow.Cells["PatComitEventID"].Value.ToString(), "");

                                        //刪除官方公文
                                        Public.COfficialDocumentEventT delDocumentEventT = new Public.COfficialDocumentEventT();
                                        delDocumentEventT.Delete(" EventCaseType='PE' and CaseEventKey=" + iKey.ToString(), "");

                                        Public.CPatentManagement pat = new Public.CPatentManagement();
                                        Public.CPatentManagement.ReadOne(PatentComit.PatentID, ref pat);

                                        //刪除記錄檔    
                                        Public.CSystemLogT log = new Public.CSystemLogT();
                                        log.DelTime = DateTime.Now;
                                        log.DelWorkerKey = Properties.Settings.Default.WorkerKEY;
                                        log.DelWorker = Properties.Settings.Default.WorkerName;
                                        log.DelContent = string.Format("申請案編號:{2}\r\n申請案名稱:{3}\r\n事件內容:{0}\r\n事件發生日:{1}\r\n所內期限:{4}\r\n官方期限:{5}\r\n完成日期:{6}\r\n處理結果:{7}\r\n備註:{8}", PatentComit.EventContent, PatentComit.CreateDate.HasValue ? PatentComit.CreateDate.Value.ToString("yyyy/MM/dd") : "", pat.PatentNo, pat.Title, PatentComit.OfficeDueDate.HasValue ? PatentComit.OfficeDueDate.Value.ToString("yyyy/MM/dd") : "", PatentComit.DueDate.HasValue ? PatentComit.DueDate.Value.ToString("yyyy/MM/dd") : "", PatentComit.FinishDate.HasValue ? PatentComit.FinishDate.Value.ToString("yyyy/MM/dd") : "", PatentComit.Result, PatentComit.Remark);
                                        log.DelTitle = string.Format("刪除「{0}」資料【事件記錄-{1}】", this.Text, PatentComit.EventContent);
                                        log.Create();

                                        PatentComit.Delete(iKey);
                                        dataGridView_Event.Rows.Remove(dataGridView_Event.CurrentRow);


                                        MessageBox.Show("刪除事件記錄成功", "確認視窗", MessageBoxButtons.OK);
                                    }
                                }
                                else
                                {
                                    if (iLocker != -1)
                                    {
                                        Worker_Model worker = new Worker_Model();
                                        Worker_Model.ReadOne(iLocker, ref worker);
                                        MessageBox.Show("很抱歉~~   目前該筆資料正被【" + worker.EmployeeName + "】使用中，請等候!!\r\n 謝謝", "提示訊息");
                                    }
                                }
                            } 
                            #endregion
                            break;
                        case "T":
                            #region 商標
                            if (dataGridView_Event.CurrentRow != null)
                            {
                                int iLocker = Public.Utility.GetRecordAuth("TrademarkNotifyEventT", "TMNotifyEventID=" + dataGridView_Event.CurrentRow.Cells["TMNotifyEventID"].Value.ToString());
                                if (iLocker == -1 || iLocker == iWorkerID)
                                {
                                    if (iLocker != iWorkerID)
                                    {
                                        Public.Utility.LockRecordAuth("TrademarkNotifyEventT", iWorkerID, "TMNotifyEventID=" + dataGridView_Event.CurrentRow.Cells["TMNotifyEventID"].Value.ToString());
                                    }
                                    string strName = dataGridView_Event.CurrentRow.Cells["NotifyEventContent"].Value.ToString();
                                    if (MessageBox.Show("是否確定刪除【" + strName + "】", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                                    {
                                        int iKey = (int)dataGridView_Event.CurrentRow.Cells["TMNotifyEventID"].Value;
                                        Public.CTrademarkNotifyEvent TMdel = new Public.CTrademarkNotifyEvent();
                                        Public.CTrademarkNotifyEvent.ReadOne(iKey, ref TMdel);

                                        Public.CTrademarkNotifyEventToFee NotifyEventToFee = new Public.CTrademarkNotifyEventToFee();
                                        NotifyEventToFee.Delete("TMNotifyEventID=" + iKey.ToString(), "");

                                        Public.CTrademarkNotifyEventToPayment NotifyEventToPayment = new Public.CTrademarkNotifyEventToPayment();
                                        NotifyEventToPayment.Delete("TMNotifyEventID=" + iKey.ToString(), "");

                                        //刪除官方公文
                                        Public.COfficialDocumentEventT delDocumentEventT = new Public.COfficialDocumentEventT();
                                        delDocumentEventT.Delete(" EventCaseType='TE' and CaseEventKey=" + iKey.ToString(), "");

                                        Public.CTrademarkManagement tm = new Public.CTrademarkManagement();
                                        Public.CTrademarkManagement.ReadOne(TMdel.TrademarkID, ref tm);

                                        //刪除記錄檔    
                                        Public.CSystemLogT log = new Public.CSystemLogT();
                                        log.DelTime = DateTime.Now;
                                        log.DelWorkerKey = Properties.Settings.Default.WorkerKEY;
                                        log.DelWorker = Properties.Settings.Default.WorkerName;

                                        log.DelContent = string.Format("商標案號:{5}\r\n商標名稱:{6}\r\n事件內容:{0}\r\n本所來函日:{1}\r\n官方期限:{2}\r\n本所期限:{3}\r\n完成日期:{4}\r\n處理結果:{7}\r\n備註:{8}", TMdel.NotifyEventContent, TMdel.NotifyComitDate.HasValue ? TMdel.NotifyComitDate.Value.ToString("yyyy/MM/dd") : "", TMdel.DueDate.HasValue ? TMdel.DueDate.Value.ToString("yyyy/MM/dd") : "", TMdel.AttorneyDueDate.HasValue ? TMdel.AttorneyDueDate.Value.ToString("yyyy/MM/dd") : "", TMdel.FinishDate.HasValue ? TMdel.FinishDate.Value.ToString("yyyy/MM/dd") : "", tm.TrademarkNo, tm.TrademarkName, TMdel.Result, TMdel.Remark);
                                        log.DelTitle = string.Format("刪除「{0}」資料【事件記錄-{1}】", this.Text, TMdel.NotifyEventContent);
                                        log.Create();

                                        TMdel.Delete(iKey);
                                        dataGridView_Event.Rows.Remove(dataGridView_Event.CurrentRow);

                                        MessageBox.Show("刪除成功", "提示訊息");
                                    }
                                    //Public.Utility.NuLockRecordAuth("TrademarkNotifyEventT", "TMNotifyEventID=" + TMNotifyEventTDataGridView.CurrentRow.Cells["TMNotifyEventID"].Value.ToString());
                                }
                                else
                                {
                                    if (iLocker != -1)//無人使用中
                                    {
                                        Worker_Model worker = new Worker_Model();
                                        Worker_Model.ReadOne(iLocker, ref worker);
                                        MessageBox.Show("很抱歉~~   目前該筆資料正被【" + worker.EmployeeName + "】使用中，請等候!!\r\n 謝謝", "提示訊息");
                                    }
                                }
                            } 
                            #endregion
                            break;
                    }

                    break;

            }
        }

        private void dataGridView_Event_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                if (dataGridView_Event.CurrentRow != null)
                {
                    if (myPermission.UserPermission.HasFlag(PermissionTypes.Modify))//判斷權限
                    {
                        contextMenuStrip_Event_ItemClicked(contextMenuStrip_Event, new ToolStripItemClickedEventArgs(toolStripButton_EditEvent));
                    }
                }
            }
        }


    }
}
