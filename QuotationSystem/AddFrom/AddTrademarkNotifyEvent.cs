using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.AddFrom
{
    public partial class AddTrademarkNotifyEvent : Form
    {
        public AddTrademarkNotifyEvent()
        {
            InitializeComponent();
        }

        #region Property
        private int itrademark = -1;
        public int TrademarkID
        {
            get { return itrademark; }
            set { itrademark = value; }
        }

        private string strCountrySymbol = "";
        /// <summary>
        /// 國別
        /// </summary>
        public string CountrySymbol
        {
            get { return strCountrySymbol; }
            set { strCountrySymbol = value; }
        }

        private int iOfficialDocumentKey = -1;
        /// <summary>
        /// 官方公文Key
        /// </summary>
        public int OfficialDocumentKey
        {
            get { return iOfficialDocumentKey; }
            set { iOfficialDocumentKey = value; }
        }

        /// <summary>
        /// 官方發文日
        /// </summary>
        public string OfficerDate
        {
            get { return maskedTextBox_NotifyOfficerDate.Text; }
            set { maskedTextBox_NotifyOfficerDate.Text = value; }
        }

        /// <summary>
        /// 簽收時間
        /// </summary>
        public string OccurDate
        {
            get { return maskedTextBox_OccurDate.Text; }
            set { maskedTextBox_OccurDate.Text = value; }
        }

        /// <summary>
        /// 官方期限
        /// </summary>
        public string DueDate
        {
            get { return maskedTextBox_DueDate.Text; }
            set { maskedTextBox_DueDate.Text = value; }
        }

        /// <summary>
        /// 備註
        /// </summary>
        public string Remark
        {
            get { return txt_Remark.Text; }
            set { txt_Remark.Text = value; }
        }

        /// <summary>
        /// 記錄案件階段、描述是否有被異動
        /// </summary>
        public bool TrademarkChange
        {
            get;set;
        }

        #endregion

        #region 資料集
        private DataTable dt_AttorneyT = new DataTable();
        /// <summary>
        /// 承辦事務所
        /// </summary>
        public DataTable DT_Attorney
        {
            get { return dt_AttorneyT; }
            set { dt_AttorneyT = value; }
        }

        private DataTable dt_AttLiaisonerT = new DataTable();
        /// <summary>
        /// 承辦事務所的連絡人
        /// </summary>
        public DataTable DT_AttLiaisoner
        {
            get { return dt_AttLiaisonerT; }
            set { dt_AttLiaisonerT = value; }
        }

        private DataTable dt_WorkerT = new DataTable();
        /// <summary>
        /// 事件承辦人
        /// </summary>
        public DataTable DT_Worker
        {
            get { return dt_WorkerT; }
            set { dt_WorkerT = value; }
        }

        private DataTable dt_TMStatusT = new DataTable();
        /// <summary>
        /// 商標案件階段
        /// </summary>
        public DataTable DT_StatusT
        {
            get { return dt_TMStatusT; }
            set { dt_TMStatusT = value; }
        }

        private DataTable dt_TMNotifyDueT = new DataTable();
        /// <summary>
        /// 商標事件內容
        /// </summary>
        public DataTable DT_NotifyDue
        {
            get { return dt_TMNotifyDueT; }
            set { dt_TMNotifyDueT = value; }
        } 
        #endregion

        #region  private void AddTrademarkNotifyEvent_Load(object sender, EventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddTrademarkNotifyEvent_Load(object sender, EventArgs e)
        {

            BindingSource();

            button1_Click(null, null);

            TrademarkChange = false;

            comboBox_WorkerKey.SelectedValue = Properties.Settings.Default.WorkerKEY;
            maskedTextBox_NotifyComitDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
        }
        #endregion

        #region 資料綁定  private void BindingSource()
        /// <summary>
        /// 資料綁定
        /// </summary>
        private void BindingSource()
        {
            Public.CQueryDropT.GetTrademarkStatusDrop(ref dt_TMStatusT);
            tMStatusTBindingSource.DataSource = dt_TMStatusT;

            Public.CQueryDropT.GetAttorneyDrop(ref dt_AttorneyT);
            attorneyTBindingSource.DataSource = dt_AttorneyT;
            attorneyTBindingSource.Filter = "CountrySymbol ='" + CountrySymbol + "'";

            Public.CQueryDropT.GetWorkerDrop(ref dt_WorkerT);
            workerQuitNBindingSource.DataSource = dt_WorkerT;

            if (comboBox_Statue.SelectedValue != null)
            {
                Public.CQueryDropT.GetTrademarkNotifyDueDrop(CountrySymbol, (int)comboBox_Statue.SelectedValue, ref dt_TMNotifyDueT);
            }
            else
            {
                Public.CQueryDropT.GetTrademarkNotifyDueDrop(CountrySymbol, 0, ref dt_TMNotifyDueT);
            }
            tMNotifyDueTBindingSource.DataSource = dt_TMNotifyDueT;
        } 
        #endregion

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region  private void but_OK_Click(object sender, EventArgs e)
        private void but_OK_Click(object sender, EventArgs e)
        {
            if (comboBox_NotifyEventContent.Text.Trim() == "")
            {
                MessageBox.Show("事件內容不得為空白", "提示訊息");
                comboBox_NotifyEventContent.Focus();
                return;
            }


            Public.CTrademarkNotifyEvent AddCTrademarkNotifyEvent = new Public.CTrademarkNotifyEvent();

            AddCTrademarkNotifyEvent.TrademarkID = TrademarkID;

            AddCTrademarkNotifyEvent.NotifyEventContent = comboBox_NotifyEventContent.Text;


            //本所期限
            DateTime dtAttorneyDueDate;
            bool IsAttorneyDueDate = DateTime.TryParse(maskedTextBox_AttorneyDueDate.Text, out dtAttorneyDueDate);
            if (IsAttorneyDueDate)
            {
                AddCTrademarkNotifyEvent.AttorneyDueDate = dtAttorneyDueDate;

            }

            //NotifyComitDate
            DateTime dtNotifyComitDate;
            bool IsNotifyComitDate = DateTime.TryParse(maskedTextBox_NotifyComitDate.Text, out dtNotifyComitDate);
            if (IsNotifyComitDate)
            {
                AddCTrademarkNotifyEvent.NotifyComitDate = dtNotifyComitDate;

            }

            //承辦日期
            DateTime dtOccurDate;
            bool IsOccurDate = DateTime.TryParse(maskedTextBox_OccurDate.Text, out dtOccurDate);
            if (IsOccurDate)
            {
                AddCTrademarkNotifyEvent.OccurDate = dtOccurDate;
            }

            //官方發文日
            DateTime dtNotifyOfficerDate;
            bool IsNotifyOfficerDate = DateTime.TryParse(maskedTextBox_NotifyOfficerDate.Text, out dtNotifyOfficerDate);
            if (IsNotifyOfficerDate)
            {
                AddCTrademarkNotifyEvent.NotifyOfficerDate = dtNotifyOfficerDate;
            }

            //官方期限
            DateTime dtDueDate;
            bool IsDueDate = DateTime.TryParse(maskedTextBox_DueDate.Text, out dtDueDate);
            if (IsDueDate)
            {
                AddCTrademarkNotifyEvent.DueDate = dtDueDate;
            }


            //送件日期
            DateTime dtNoticeDate;
            bool IsNoticeDate = DateTime.TryParse(maskedTextBox_Notice.Text, out dtNoticeDate);
            if (IsNoticeDate)
            {
                AddCTrademarkNotifyEvent.NoticeDate = dtNoticeDate;
            }


            //委外日期
            DateTime dtOutsourcingDate;
            bool IsOutsourcingDate = DateTime.TryParse(maskedTextBox_OutsourcingDate.Text, out dtOutsourcingDate);
            if (IsOutsourcingDate)
            {
                AddCTrademarkNotifyEvent.OutsourcingDate = dtOutsourcingDate;
            }


            //完成日期
            DateTime dtFinishDate;
            bool IsFinishDate = DateTime.TryParse(maskedTextBox_FinishDate.Text, out dtFinishDate);
            if (IsFinishDate)
            {
                AddCTrademarkNotifyEvent.FinishDate = dtFinishDate;
            }

            if (Combo_EAttorney.SelectedValue != null)
            {
                AddCTrademarkNotifyEvent.AttorneyKey = (int)Combo_EAttorney.SelectedValue;
            }

            if (Combo_EAttorneyTransactor.SelectedValue != null)
            {
                AddCTrademarkNotifyEvent.ALiaisonerKey = (int)Combo_EAttorneyTransactor.SelectedValue;
            }

            if (comboBox_WorkerKey.SelectedValue != null)
            {
                AddCTrademarkNotifyEvent.WorkerKey = (int)comboBox_WorkerKey.SelectedValue;
            }

            AddCTrademarkNotifyEvent.EventType = comboBox_EventType.Text;

            AddCTrademarkNotifyEvent.Result = txt_Result.Text;

            AddCTrademarkNotifyEvent.Remark = txt_Remark.Text;

            AddCTrademarkNotifyEvent.Creator = Properties.Settings.Default.WorkerName;

            AddCTrademarkNotifyEvent.Create();

            #region 判斷是否有預設事件，Yes-->加入工作清單中
            //判斷是否有預設事件，Yes-->加入工作清單中
            if (comboBox_NotifyEventContent.SelectedValue != null && lab_ProcessKind.Text != "(無)")
            {

                Public.CTMNotifyDue notify = new Public.CTMNotifyDue();
                Public.CTMNotifyDue.ReadOne((int)comboBox_NotifyEventContent.SelectedValue, ref notify);


                List<Public.CTrademarkProcessStepE> processList = new List<Public.CTrademarkProcessStepE>();
                Public.CTrademarkProcessStepE.ReadList(ref processList, " IsUsing=1 and ProcessKEY=" + notify.ProcessKEY.ToString() + " order by Sort");

                if (notify.Note != "")
                {
                    MessageBox.Show("提醒訊息 :\r\n " + notify.Note, "提示訊息");
                }

                Public.CTrademarkWorkReport workList = new Public.CTrademarkWorkReport();
                for (int iRow = 0; iRow < processList.Count; iRow++)
                {
                    workList.IsStart = false;
                    workList.EventType = 1;
                    workList.WorkContent = processList[iRow].Handle;
                    workList.EventID = AddCTrademarkNotifyEvent.TMNotifyEventID;
                    workList.Worker = processList[iRow].DefualtWorker;//事件的預設承辦人
                    workList.Progress = processList[iRow].ProcessHandleKEY;
                    workList.WorkDate = DateTime.Now;
                    workList.OstatusSN = processList[iRow].Status;//申請案狀態
                    workList.Create();
                }

            }
            #endregion

            #region 更新案件階段
            Public.CTrademarkManagement Tm = new Public.CTrademarkManagement();
            Public.CTrademarkManagement.ReadOne(TrademarkID, ref Tm);

            if (TrademarkChange)//true:表示有被異動
            {
                Tm.Status = comboBox_Statue.SelectedValue != null ? (int)comboBox_Statue.SelectedValue : -1;
                Tm.StatusExplain = txt_StatusExplain.Text;
                Tm.LastModifyWorker = Properties.Settings.Default.WorkerName;
                Tm.Update();
            }
            #endregion

            #region Forms.TrademarkMF
            Public.PublicForm Forms = new Public.PublicForm();
            if (Forms.TrademarkMF != null)
            {
                DataRow drTrademark = Forms.TrademarkMF.dt_TrademarkManagementT.Rows.Find(TrademarkID);
                if (TrademarkChange && drTrademark != null)
                {
                    drTrademark["TMStatusID"] = Tm.Status;
                    drTrademark["StatusName"] = comboBox_Statue.Text;
                    drTrademark["StatusExplain"] = Tm.StatusExplain;
                    drTrademark["LastModifyWorker"] = Tm.LastModifyWorker;
                    // Forms.TrademarkMF.dt_TrademarkManagementT.AcceptChanges();
                }

                DataRow dr = Forms.TrademarkMF.dt_TrademarkNotifyEventT.Rows.Find(AddCTrademarkNotifyEvent.TMNotifyEventID);
                if (dr == null)
                {
                    dr = Forms.TrademarkMF.dt_TrademarkNotifyEventT.NewRow();
                    DataRow drV = Public.CTrademarkPublicFunction.GetTrademarkEvent(AddCTrademarkNotifyEvent.TMNotifyEventID.ToString());
                    dr.ItemArray = drV.ItemArray;
                    Forms.TrademarkMF.dt_TrademarkNotifyEventT.Rows.Add(dr);
                }

                if (dr != null)
                {
                    dr.AcceptChanges();
                }

            }
            #endregion
                    
            #region 官方公文管理處理
            //官方公文
            if (iOfficialDocumentKey != -1 && iOfficialDocumentKey > 0)
            {
                Public.COfficialDocumentEventT cdte = new Public.COfficialDocumentEventT();
                cdte.CaseType = "TE";
                cdte.OfficialDocumentKey = iOfficialDocumentKey;
                cdte.CaseEventKey = AddCTrademarkNotifyEvent.TMNotifyEventID;
                cdte.CaseKey = Tm.TrademarkID;
                cdte.CaseNo = Tm.TrademarkNo;
                object objCd = cdte.Create();

                if (objCd.ToString() == "0" && Forms.OfficialDocument != null)
                {
                    Forms.OfficialDocument.ReLoad();
                    //DataRow dr = Forms.OfficialDocument.DT_OfficialDocument.Rows.Find(iOfficialDocumentKey);
                    //Forms.OfficialDocument.DT_OfficialDocument.Rows.Remove(dr);
                    //DataRow dtOD = Public.COfficialDocumentPublicFunction.GetOfficialDocumentTDataRow(iOfficialDocumentKey.ToString());
                    //dr.ItemArray = dtOD.ItemArray;
                    //dr.AcceptChanges();
                }
            }
            #endregion

            MessageBox.Show("新增成功", "提示訊息");
            this.Close();
        }
        #endregion

        private void maskedTextBox_NotifyComitDate_DoubleClick(object sender, EventArgs e)
        {
            MaskedTextBox mtb = (MaskedTextBox)sender;
            DateTime dt;
            bool IsSuccess = DateTime.TryParse(mtb.Text, out dt);
            if (!IsSuccess)
            {
                mtb.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }
        }

        #region 回復目前階段按鈕 private void button1_Click(object sender, EventArgs e)
        /// <summary>
        /// 回復目前階段按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Public.CTrademarkManagement Tm = new Public.CTrademarkManagement();
            Public.CTrademarkManagement.ReadOne(TrademarkID, ref Tm);
            if (Tm.Status .HasValue)
            {
                comboBox_Statue.SelectedValue = Tm.Status;
            }
                txt_StatusExplain.Text = Tm.StatusExplain;

            TrademarkChange = false;
        } 
        #endregion

        #region 目前案件階段 private void comboBox_Statue_SelectedIndexChanged(object sender, EventArgs e)
        /// <summary>
        /// 目前案件階段
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_Statue_SelectedIndexChanged(object sender, EventArgs e)
        {
            TrademarkChange = true;
            if (comboBox_Statue.SelectedValue != null)
            {
                dt_TMNotifyDueT.Rows.Clear();
                Public.CQueryDropT.GetTrademarkNotifyDueDrop(CountrySymbol, (int)comboBox_Statue.SelectedValue, ref dt_TMNotifyDueT);
                //Public.CQueryDropT.GetTrademarkNotifyDueDrop(CountrySymbol, (int)comboBox_Statue.SelectedValue ,ref dt_TMNotifyDueT);
                comboBox_NotifyEventContent_SelectedIndexChanged(null, null);
            }
            else
            {
                dt_TMNotifyDueT.Rows.Clear();
            }
        } 
        #endregion
      
        private void AddTrademarkNotifyEvent_KeyDown(object sender, KeyEventArgs e)
        {
            Public.Utility.ControlTab(e);
        }

        #region private void comboBox_NotifyEventContent_SelectedIndexChanged(object sender, EventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_NotifyEventContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_NotifyEventContent.SelectedValue != null)
            {
                Public.CTMNotifyDue notify = new Public.CTMNotifyDue();
                Public.CTMNotifyDue.ReadOne((int)comboBox_NotifyEventContent.SelectedValue, ref notify);

                #region 申請案階段
                //if (notify.Status.HasValue && comboBox_Statue.SelectedValue.ToString() != notify.Status.ToString())
                //{
                //    comboBox_Statue.SelectedValue = notify.Status;
                //}
               // txt_StatusExplain.Text = DateTime.Now.ToShortDateString() + "  " + notify.NotifyContent;
                #endregion

                if (notify.ProcessKEY.HasValue)
                {
                    Public.CTrademarkProcessKind process = new Public.CTrademarkProcessKind();
                    Public.CTrademarkProcessKind.ReadOne(" bStop=1 and ProcessKEY=" + notify.ProcessKEY.Value, ref process);
                    if(process.ProcessKEY>0)
                    {
                        lab_ProcessKind.Text = "(" + process.ProcessKind + ")";
                    }
                    else
                    {
                        lab_ProcessKind.Text = "(無)";
                    }                    
                }
                else
                {
                    lab_ProcessKind.Text = "(無)";
                }
            }
        } 
        #endregion

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "ToolStripMenuItem_All":
                    
                    attorneyTBindingSource.Filter = "";
                    break;
                case "ToolStripMenuItem_CurrentCountry":
                    if (!string.IsNullOrEmpty(CountrySymbol.Trim() ))
                    {                     
                        attorneyTBindingSource.Filter = "CountrySymbol ='" + CountrySymbol + "'";
                    }
                    break;
            }
        }

        #region  private void Combo_EAttorney_SelectedIndexChanged(object sender, EventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Combo_EAttorney_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Combo_EAttorney.SelectedValue != null)
            {
                Public.CQueryDropT.GetAttLiaisonerDrop((int)Combo_EAttorney.SelectedValue, ref dt_AttLiaisonerT);

                if (attLiaisonerTBindingSource.DataSource == null)
                {
                    attLiaisonerTBindingSource.DataSource = dt_AttLiaisonerT;
                }
            }
        }


        #endregion

        private void maskedTextBox_NotifyComitDate_Leave(object sender, EventArgs e)
        {
            MaskedTextBox mak = (MaskedTextBox)sender;
            Public.Utility.CheckMaskedtextbox(mak);
        }

        #region 階段描述
        /// <summary>
        /// 階段描述
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_StatusExplain_TextChanged(object sender, EventArgs e)
        {
            TrademarkChange = true;
        } 
        #endregion
    }
}
