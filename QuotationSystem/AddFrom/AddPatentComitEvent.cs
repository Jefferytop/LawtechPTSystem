using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.AddFrom
{
    public partial class AddPatentComitEvent : Form
    {
        public AddPatentComitEvent()
        {
            InitializeComponent();
        }

        private int iPatentID = -1;
        /// <summary>
        /// 申請案ID
        /// </summary>
        public int PatentID
        {
            get { return iPatentID; }
            set { iPatentID = value; }
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

        private string sCountrySymbol = "";
        /// <summary>
        /// 國別
        /// </summary>
        public string CountrySymbol
        {
            get { return sCountrySymbol; }
            set { sCountrySymbol = value; }
        }

        /// <summary>
        /// 官方發文日
        /// </summary>
        public string OfficerDate
        {
            get { return maskedTextBox_OfficerDate.Text; }
            set { maskedTextBox_OfficerDate.Text = value; }
        }

        /// <summary>
        /// 簽收日期
        /// </summary>
        public string OccurDate
        {
            get { return maskedTextBox_EventContent.Text; }
            set { maskedTextBox_EventContent.Text = value; }
        }

        /// <summary>
        /// 官方期限
        /// </summary>
        public string DueDate
        {
            get { return maskedTextBox_DueDate.Text; }
            set { maskedTextBox_DueDate .Text= value; }
        }

        /// <summary>
        /// 備註
        /// </summary>
        public string Remark
        {
            get { return txtRemark.Text; }
            set { txtRemark.Text = value; }
        }

        /// <summary>
        /// 記錄案件階段、描述是否有被異動
        /// </summary>
        public bool PatentChange
        {
            get; set;
        }

        #region AddPatentComitEvent_Load
        private void AddPatentComitEvent_Load(object sender, EventArgs e)
        {

            this.attorneyTTableAdapter.Fill(this.dataSet_Drop.AttorneyT);

            this.patStatusT_DropTableAdapter.Fill(this.qS_DataSet._PatStatusT_Drop);
            this.worker_QuitNTableAdapter.Fill(this.qS_DataSet.Worker_QuitN);
            //this.applicantT_DropTableAdapter.Fill(this.qS_DataSet.ApplicantT_Drop);
         
            
            Public.CPatentManagement patent = new Public.CPatentManagement();
            Public.CPatentManagement.ReadOne(PatentID, ref patent);

            if (patent.Status.HasValue)
            {
                comboBox_Statue.SelectedValue = patent.Status;
                this.patComitContentTTableAdapter.FillBy(this.dataSet_Drop.PatComitContentT, CountrySymbol,patent.Status.Value);
            }
            txt_StatusExplain.Text = patent.StatusExplain;
            maskedTextBox_CreateDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            Combo_EClientWorker.SelectedValue = Properties.Settings.Default.WorkerKEY;

            attorneyTBindingSource.Filter = "CountrySymbol ='" + CountrySymbol + "'";
            //attorneyTBindingSource.Sort = "Sort";

            PatentChange = false;
        }
        #endregion

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Combo_EAttorney_SelectedIndexChanged
        private void Combo_EAttorney_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Combo_EAttorney.SelectedValue != null)
            {
                this.attLiaisonerTTableAdapter.FillByWindows(this.dataSet_Drop.AttLiaisonerT, (int)Combo_EAttorney.SelectedValue, (int)Public.WindowType.PatContract);
            }
        }
        #endregion 

        #region contextMenuStrip_EAttorneyTransactor_ItemClicked
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip_EAttorneyTransactor_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Tag != null && !string.IsNullOrEmpty(e.ClickedItem.Tag.ToString()))
            {
                if (Combo_EAttorney.SelectedValue != null)
                {
                    this.dataSet_Drop.AttLiaisonerT.Rows.Clear();
                    this.attLiaisonerTTableAdapter.FillByWindows(this.dataSet_Drop.AttLiaisonerT, (int)Combo_EAttorney.SelectedValue, int.Parse(e.ClickedItem.Tag.ToString()));
                }
            }
        }
        #endregion

        #region  private void but_OK_Click(object sender, EventArgs e)
        /// <summary>
        /// 確定按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_OK_Click(object sender, EventArgs e)
        {
            if (txt_EventContent.Text == "")
            {
                MessageBox.Show("【事件內容】不得為空，請確認", "提示訊息");
                return;
            }
            Public.CPatComitEvent add = new Public.CPatComitEvent();

            add.PatentID = iPatentID;
            add.EventContent = txt_EventContent.Text;

            // DateTime dtFinishDate=new DateTime(1900,1,1);
            //DateTime.TryParse(maskedTextBox_EventContent.Text,out dtFinishDate);
            //add.FinishDate = dtFinishDate;

            add.AttorneyKey = Combo_EAttorney.SelectedValue != null ? (int)Combo_EAttorney.SelectedValue : -1;
            add.ALiaisonerKey = Combo_EAttorneyTransactor.SelectedValue != null ? (int)Combo_EAttorneyTransactor.SelectedValue : -1;
            add.WorkerKey = Combo_EClientWorker.SelectedValue != null ? (int)Combo_EClientWorker.SelectedValue : -1;

            DateTime dtOccurDate;
            bool IsOccurDate = DateTime.TryParse(maskedTextBox_EventContent.Text, out dtOccurDate);
            if (IsOccurDate) add.OccurDate = dtOccurDate;
            else add.OccurDate = null;

            DateTime dtOfficerDate;
            bool IsOfficerDate = DateTime.TryParse(maskedTextBox_OfficerDate.Text, out dtOfficerDate);
            if (IsOfficerDate) add.OfficerDate = dtOfficerDate;
            else add.OfficerDate = null;

            DateTime dtDueDate;
            bool IsDueDate = DateTime.TryParse(maskedTextBox_DueDate.Text, out dtDueDate);
            if (IsDueDate) add.DueDate = dtDueDate;
            else add.DueDate = null;

            DateTime dtOfficeDueDate;
            bool IsOfficeDueDate = DateTime.TryParse(maskedTextBox_OfficeDueDate.Text, out dtOfficeDueDate);
            if (IsOfficeDueDate) add.OfficeDueDate = dtOfficeDueDate;
            else add.OfficeDueDate = null;

            DateTime dtCreateDate;
            bool IsdtCreateDate = DateTime.TryParse(maskedTextBox_CreateDate.Text, out dtCreateDate);
            if (IsdtCreateDate) add.CreateDate = dtCreateDate;
            else add.CreateDate = null;

            DateTime dtFinishDate;
            bool IsdtFinishDate = DateTime.TryParse(maskedTextBox_FinishDate.Text, out dtFinishDate);
            if (IsdtFinishDate) add.FinishDate = dtFinishDate;
            else add.FinishDate = null;

            //開工日期
            DateTime dtStartDate;
            bool IsStartDate = DateTime.TryParse(maskedTextBox_StartDate.Text, out dtStartDate);
            if (IsStartDate) add.StartDate = dtStartDate;
            else add.StartDate = null;

            //送件日期
            DateTime dtComitDate;
            bool IsComitDate = DateTime.TryParse(maskedTextBox_ComitDate.Text, out dtComitDate);
            if (IsComitDate) add.ComitDate = dtComitDate;
            else add.ComitDate = null;

            add.Result = txt_Result.Text;
            add.Remark = txtRemark.Text;


            add.Creator = Properties.Settings.Default.WorkerName;
            add.Create();

            Public.CPatentManagement patent = new Public.CPatentManagement();
            Public.CPatentManagement.ReadOne(PatentID, ref patent);

            #region 專利案件階段
            if(PatentChange)
            {
                patent.Status = comboBox_Statue.SelectedValue != null ? (int)comboBox_Statue.SelectedValue : -1;
                patent.StatusExplain = txt_StatusExplain.Text;
                patent.LastModifyWorker = Properties.Settings.Default.WorkerName;
                patent.Update();
            }        
            #endregion

            #region 專利申請案基本資料
            Public.PublicForm Forms = new Public.PublicForm();
            if (Forms.PatListMF != null)
            {
                DataRow dr = Forms.PatListMF.DT_PatentList.Rows.Find(PatentID);
                if (PatentChange && dr != null)
                {
                    dr["Status"] = patent.Status;
                    dr["StatusName"] = comboBox_Statue.Text;
                    dr["StatusExplain"] = txt_StatusExplain.Text;
                    dr["LastModifyWorker"] = Properties.Settings.Default.WorkerName;
                    Forms.PatListMF.DT_PatentList.AcceptChanges();
                }

                //DataTable dtPatComitEventT = Forms.PatListMF.DT_PatComitEventT;
                //Public.CPatentPublicFunction.GetPatentEvent(PatentID.ToString(), ref dtPatComitEventT);
                DataRow drPatComitEvent= Forms.PatListMF.DT_PatComitEventT.Rows.Find(add.PatComitEventID);
                if(drPatComitEvent==null)
                {
                    drPatComitEvent = Forms.PatListMF.DT_PatComitEventT.NewRow();
                    DataRow drV = Public.CPatentPublicFunction.GetPatentComitEventDataRow(add.PatComitEventID.ToString());
                    drPatComitEvent.ItemArray = drV.ItemArray;
                    //加入新的一筆
                    Forms.PatListMF.DT_PatComitEventT.Rows.Add(drPatComitEvent);
                }                
                if (drPatComitEvent != null)
                {                    
                    drPatComitEvent.AcceptChanges();
                }

            }
            #endregion

            #region 官方公文管理處理
            //官方公文
            if (iOfficialDocumentKey != -1 && iOfficialDocumentKey > 0)
            {
                Public.COfficialDocumentEventT cdte = new Public.COfficialDocumentEventT();
                cdte.CaseType = "PE";
                cdte.OfficialDocumentKey = iOfficialDocumentKey;
                cdte.CaseEventKey = add.PatComitEventID;
                cdte.CaseKey = patent.PatentID;
                cdte.CaseNo = patent.PatentNo;
                object objCd = cdte.Create();

                if (objCd.ToString() == "0" && Forms.OfficialDocument != null)
                {
                    Forms.OfficialDocument.ReLoad();
                    //DataRow dr = Forms.OfficialDocument.DT_OfficialDocument.Rows.Find(iOfficialDocumentKey);
                    //DataRow dtOD = Public.COfficialDocumentPublicFunction.GetOfficialDocumentTDataRow(iOfficialDocumentKey.ToString());
                    //dr.ItemArray = dtOD.ItemArray;
                    //dr.AcceptChanges();
                }
            }
            #endregion

            #region 判斷是否加入預設標準流程
            if (cb_Process.Checked)
                {
                    //判斷是否有預設事件，Yes-->加入工作清單中
                    if (txt_EventContent.SelectedValue != null && lab_ProcessKind.Text!= "(無)")
                    {
                        Public.CPatComitContent comit = new Public.CPatComitContent();
                        comit.ComitContentID = int.Parse(txt_EventContent.SelectedValue.ToString());
                        Public.CPatComitContent.ReadOne(ref comit);


                        List<Public.CProcessStep> process = new List<Public.CProcessStep>();
                        Public.CProcessStep.ReadList(ref process, " IsUsing=1 and ProcessKEY=" + comit.ProcessKEY.ToString(), strOrderBy: "Sort");
                        Public.CPatWorkReport workList = new Public.CPatWorkReport();
                        foreach (Public.CProcessStep item in process)
                        {
                            workList.IsStart = false;
                            workList.WorkContent = item.Handle;
                            workList.EventType = 1;
                            workList.EventID = add.PatComitEventID;
                            if (item.DefualtWorker.HasValue)
                            {
                                workList.Worker = item.DefualtWorker.Value;//事件的預設承辦人
                            }
                            workList.Progress = item.ProcessHandleKEY;
                            workList.WorkDate = DateTime.Now;
                            if (item.Status.HasValue)
                            {
                                workList.OstatusSN = item.Status.Value;//申請案狀態
                            }
                            workList.Create();
                        }
                    }
                } 
                #endregion

                MessageBox.Show("新增成功", "提示訊息", MessageBoxButtons.OK);

                this.Close();
           
        }
        #endregion

        private void txt_EventContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txt_EventContent.SelectedValue != null)
            {
                Public.CPatComitContent comit = new Public.CPatComitContent();
                Public.CPatComitContent.ReadOne((int)txt_EventContent.SelectedValue, ref comit);

                //#region 申請案階段
                //if (comit.Status.HasValue && comboBox_Statue.SelectedValue.ToString() != comit.Status.ToString())
                //{
                //    comboBox_Statue.SelectedValue = comit.Status;
                //}
                //txt_StatusExplain.Text = DateTime.Now.ToShortDateString() + "  " + comit.ComitContent; 
                //#endregion

                if (comit.ProcessKEY.HasValue)
                {
                    Public.CProcessKind process = new Public.CProcessKind();
                    Public.CProcessKind.ReadOne("bStop=1 and ProcessKEY=" + comit.ProcessKEY.Value, ref process);
                    if (process.ProcessKEY > 0)
                    {
                        lab_ProcessKind.Text = "(" + process.ProcessKind + ")";
                    }
                    else {
                        lab_ProcessKind.Text = "(無)";
                    }
                  
                }
                else
                {
                    lab_ProcessKind.Text = "(無)";
                }
            }
        }

        #region 回復申請案目前階段按鈕 private void button1_Click(object sender, EventArgs e)
        /// <summary>
        /// 回復申請案目前階段按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Public.CPatentManagement patent = new Public.CPatentManagement();
            Public.CPatentManagement.ReadOne(PatentID, ref patent);

            if (patent.Status.HasValue)
            {
                comboBox_Statue.SelectedValue = patent.Status;
            }
            txt_StatusExplain.Text = patent.StatusExplain;

            PatentChange = false;
        } 
        #endregion

        #region maskedTextBox_EventContent_DoubleClick
        private void maskedTextBox_EventContent_DoubleClick(object sender, EventArgs e)
        {
            MaskedTextBox mtb = (MaskedTextBox)sender;
            DateTime dt;
            bool IsSuccess=DateTime.TryParse(mtb.Text,out dt);
            if (!IsSuccess)
            {
                mtb.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }
        }
        #endregion 

        #region comboBox_Statue_SelectedIndexChanged
        private void comboBox_Statue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Statue.SelectedValue != null)
            {
                this.patComitContentTTableAdapter.FillBy(this.dataSet_Drop.PatComitContentT, CountrySymbol, (int)comboBox_Statue.SelectedValue);
                txt_EventContent_SelectedIndexChanged(null, null);
            }
            else
            {
                this.dataSet_Drop.PatComitContentT.Rows.Clear();
            }
            PatentChange = true;
        }
#endregion

        #region contextMenuStrip_ForDate_ItemClicked
        private void contextMenuStrip_ForDate_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ContextMenuStrip content = (ContextMenuStrip)sender;
            MaskedTextBox mtb = content.SourceControl as MaskedTextBox;

            contextMenuStrip_ForDate.Visible = false;

            switch (e.ClickedItem.Name)
            {
                case "ToolStripMenuItem_Calculation":

                    US.CalculationDate Calculation = new US.CalculationDate();
                    DateTime dt = new DateTime(1900, 1, 1);
                    bool IsSuccess = DateTime.TryParse(mtb.Text, out dt);
                    if (IsSuccess)
                    {
                        Calculation.CurrentDate = dt;
                    }
                    else
                    {
                        Calculation.CurrentDate = new DateTime(1900, 1, 1);
                    }

                    //取得結果
                    if (Calculation.ShowDialog() == DialogResult.OK)
                    {
                        mtb.Text = Calculation.GetResult;
                    }
                    break;
            }
        }
        #endregion

        #region AddPatentComitEvent_KeyDown
        private void AddPatentComitEvent_KeyDown(object sender, KeyEventArgs e)
        {
            
                Public.Utility.ControlTab(e);
            

        }
        #endregion

       

        private void contextMenuStrip_ForDate_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {
            ContextMenuStrip content = (ContextMenuStrip)sender;
            MaskedTextBox mtb = content.SourceControl as MaskedTextBox;

            contextMenuStrip_ForDate.Visible = false;

            switch (e.ClickedItem.Name)
            {
                case "ToolStripMenuItem_Calculation":

                    US.CalculationDate Calculation = new US.CalculationDate();
                    DateTime dt ;
                    bool IsSuccess = DateTime.TryParse(mtb.Text, out dt);
                    if (IsSuccess)
                    {
                        Calculation.CurrentDate = dt;
                    }
                    else
                    {
                        Calculation.CurrentDate = null;
                    }

                    //取得結果
                    if (Calculation.ShowDialog() == DialogResult.OK)
                    {
                        mtb.Text = Calculation.GetResult;
                    }
                    break;
            }
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "ToolStripMenuItem_All":
                    checkBox_All.Checked = true;
                    attorneyTBindingSource.Filter = "";
                    break;
                case "ToolStripMenuItem_CurrentCountry":
                    if (CountrySymbol != "")
                    {
                        checkBox_All.Checked = false;
                        attorneyTBindingSource.Filter = "CountrySymbol ='" + CountrySymbol + "'";
                    }
                    break;
            }
        }

        private void maskedTextBox_CreateDate_Leave(object sender, EventArgs e)
        {
            MaskedTextBox mak = (MaskedTextBox)sender;
            Public.Utility.CheckMaskedtextbox(mak);
        }

        /// <summary>
        /// 案件階段描述
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_StatusExplain_TextChanged(object sender, EventArgs e)
        {
            PatentChange = true;
        }
    }
}
