using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.CopyForm
{
    public partial class CopyPatentComitEvent : Form
    {
        public CopyPatentComitEvent()
        {
            InitializeComponent();
        }

        private int iPatComitEventID = -1;
        /// <summary>
        /// 事件記錄 ID
        /// </summary>
        public int PatComitEventID
        {
            get { return iPatComitEventID; }
            set { iPatComitEventID = value; }
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

        private int iPatentID = -1;
        /// <summary>
        /// 申請案ID
        /// </summary>
        public int PatentID
        {
            get { return iPatentID; }
            set { iPatentID = value; }
        }

        #region AddPatentComitEvent_Load
        private void CopyPatentComitEvent_Load(object sender, EventArgs e)
        {
            this.attorneyTTableAdapter.FillByCountry(this.dataSet_Drop.AttorneyT, sCountrySymbol);

            this.patStatusT_DropTableAdapter.Fill(this.qS_DataSet._PatStatusT_Drop);
            this.worker_QuitNTableAdapter.Fill(this.qS_DataSet.Worker_QuitN);
            this.applicantT_DropTableAdapter.Fill(this.qS_DataSet.ApplicantT_Drop);
            this.patComitContentTTableAdapter.Fill(this.dataSet_Drop.PatComitContentT, CountrySymbol);

            Public.CPatentManagement patent = new LawtechPTSystemByFirm.Public.CPatentManagement();
            Public.CPatentManagement.ReadOne(PatentID, ref patent);
            
            comboBox_Statue.SelectedValue = patent.Status;
            txt_StatusExplain.Text = patent.StatusExplain;
          
            Combo_EClientWorker.SelectedValue = Properties.Settings.Default.WorkerKEY;

            Public.CPatComitEvent edit = new LawtechPTSystemByFirm.Public.CPatComitEvent();
            Public.CPatComitEvent.ReadOne(PatComitEventID, ref edit);
           
            txt_EventContent.Text = edit.EventContent;

           
            Combo_EClientWorker.SelectedValue = edit.WorkerKey.HasValue?edit.WorkerKey.Value:-1;
            Combo_EAttorney.SelectedValue = edit.AttorneyKey.HasValue ? edit.AttorneyKey.Value : -1;
            Combo_EAttorneyTransactor.SelectedValue = edit.ALiaisonerKey.HasValue ? edit.ALiaisonerKey.Value : -1;


            maskedTextBox_EventContent.Text = edit.OccurDate.HasValue? edit.OccurDate.Value.ToString("yyyy/MM/dd") : "";
            maskedTextBox_OfficerDate.Text = edit.OfficerDate.HasValue ? edit.OfficerDate.Value.ToString("yyyy/MM/dd") : "";
            maskedTextBox_DueDate.Text = edit.DueDate.HasValue ? edit.DueDate.Value.ToString("yyyy/MM/dd") : "";
            maskedTextBox_StartDate.Text = edit.StartDate.HasValue ? edit.StartDate.Value.ToString("yyyy/MM/dd") : "";
            maskedTextBox_ComitDate.Text = edit.ComitDate.HasValue ? edit.ComitDate.Value.ToString("yyyy/MM/dd") : "";
            maskedTextBox_FinishDate.Text = edit.FinishDate.HasValue ? edit.FinishDate.Value.ToString("yyyy/MM/dd") : "";
            maskedTextBox_OfficeDueDate.Text = edit.OfficeDueDate.HasValue ? edit.OfficeDueDate.Value.ToString("yyyy/MM/dd") : "";
            maskedTextBox_CreateDate.Text = edit.CreateDate.HasValue ? edit.CreateDate.Value.ToString("yyyy/MM/dd") : "";
            txtRemark.Text = edit.Remark;
            txt_Result.Text = edit.Result;
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
            else
            {
                this.attLiaisonerTTableAdapter.Fill(this.dataSet_Drop.AttLiaisonerT, -1);
            }
        }
        #endregion

        #region but_OK_Click
        private void but_OK_Click(object sender, EventArgs e)
        {
            if (txt_EventContent.Text == "")
            {
                MessageBox.Show("【事件內容】不得為空，請確認", "提示訊息");
                return;
            }
            Public.CPatComitEvent add = new LawtechPTSystemByFirm.Public.CPatComitEvent();

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

            DateTime dtOfficerDate ;
            bool IsOfficerDate = DateTime.TryParse(maskedTextBox_OfficerDate.Text, out dtOfficerDate);
            if (IsOfficerDate) add.OfficerDate = dtOfficerDate;
            else add.OfficerDate =null;

            DateTime dtDueDate ;
            bool IsDueDate = DateTime.TryParse(maskedTextBox_DueDate.Text, out dtDueDate);
            if (IsDueDate) add.DueDate = dtDueDate;
            else add.DueDate = null;

            DateTime dtOfficeDueDate;
            bool IsOfficeDueDate = DateTime.TryParse(maskedTextBox_OfficeDueDate.Text, out dtOfficeDueDate);
            if (IsOfficeDueDate) add.OfficeDueDate = dtOfficeDueDate;
            else add.OfficeDueDate = null;

            DateTime dtCreateDate ;
            bool IsdtCreateDate = DateTime.TryParse(maskedTextBox_CreateDate.Text, out dtCreateDate);
            if (IsdtCreateDate) add.CreateDate = dtCreateDate;
            else add.CreateDate = null;

            DateTime dtFinishDate ;
            bool IsdtFinishDate = DateTime.TryParse(maskedTextBox_FinishDate.Text, out dtFinishDate);
            if (IsdtFinishDate) add.FinishDate = dtFinishDate;
            else add.FinishDate = null;

            DateTime dtStartDate;
            bool IsdtStartDate = DateTime.TryParse(maskedTextBox_StartDate.Text, out dtStartDate);
            if (IsdtStartDate) add.StartDate = dtStartDate;
            else add.StartDate = null;

            DateTime dtComitDate ;
            bool IsdtComitDate = DateTime.TryParse(maskedTextBox_ComitDate.Text, out dtComitDate);
            if (IsdtComitDate) add.ComitDate = dtComitDate;
            else add.ComitDate = null;

            add.Result = txt_Result.Text;
            add.Remark = txtRemark.Text;          
           
            add.Creator = Properties.Settings.Default.WorkerName;
            add.Create();

            Public.CPatentManagement patent = new LawtechPTSystemByFirm.Public.CPatentManagement();
            Public.CPatentManagement.ReadOne(PatentID, ref patent);
         
            patent.Status = (int)comboBox_Statue.SelectedValue;
            patent.StatusExplain = txt_StatusExplain.Text;
            patent.Update();

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            DataRow dr = Forms.PatListMF.DT_PatentList.Rows.Find(PatentID);
            dr["Status"] = patent.Status;
            dr["StatusName"] = comboBox_Statue.Text;
            dr["StatusExplain"] = txt_StatusExplain.Text;
            Forms.PatListMF.DT_PatentList.AcceptChanges();

           DataRow findrd= Forms.PatListMF.DT_PatComitEventT.Rows.Find(add.PatComitEventID);
           if (findrd == null)
           {
               DataRow drPatComitEvent = Forms.PatListMF.DT_PatComitEventT.NewRow();
               DataRow drV = Public.CPatentPublicFunction.GetPatentComitEventDataRow(add.PatComitEventID.ToString());
               drPatComitEvent.ItemArray = drV.ItemArray;     

               Forms.PatListMF.DT_PatComitEventT.Rows.Add(drPatComitEvent);             
           }

            //判斷是否有預設事件，Yes-->加入工作清單中
            if (txt_EventContent.SelectedValue != null)
            {
                Public.CPatComitContent comit = new LawtechPTSystemByFirm.Public.CPatComitContent();
                comit.ComitContentID = int.Parse(txt_EventContent.SelectedValue.ToString());
                Public.CPatComitContent.ReadOne(ref comit);

                List<Public.CProcessStep> process = new List<Public.CProcessStep>();
                Public.CProcessStep.ReadList(ref process, " IsUsing=1 and ProcessKEY=" + comit.ProcessKEY.ToString(), strOrderBy: "Sort");

                Public.CPatWorkReport workList = new LawtechPTSystemByFirm.Public.CPatWorkReport();
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

            MessageBox.Show("新增成功", "提示訊息", MessageBoxButtons.OK);

            this.Close();
        }
        #endregion

        #region maskedTextBox_EventContent_DoubleClick
        private void maskedTextBox_EventContent_DoubleClick(object sender, EventArgs e)
        {
            MaskedTextBox mtb = (MaskedTextBox)sender;
            DateTime dt;
            bool IsSuccess = DateTime.TryParse(mtb.Text, out dt);
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
            }
            else
            {
                this.dataSet_Drop.PatComitContentT.Rows.Clear();
            }
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

                    US.CalculationDate Calculation = new LawtechPTSystemByFirm.US.CalculationDate();
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

        private void button1_Click(object sender, EventArgs e)
        {
            Public.CPatentManagement patent = new LawtechPTSystemByFirm.Public.CPatentManagement();
            Public.CPatentManagement.ReadOne(PatentID, ref patent);
           
            comboBox_Statue.SelectedValue = patent.Status;
            txt_StatusExplain.Text = patent.StatusExplain;
        }

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

       

    }
}
