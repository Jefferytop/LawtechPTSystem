using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystem.CopyForm
{
    public partial class CopyTrademarkControversyEvent : Form
    {
        public CopyTrademarkControversyEvent()
        {
            InitializeComponent();
        }

        private int iTMNotifyEventID = -1;
        /// <summary>
        /// 複製商標異議案件記錄的 ID
        /// </summary>
        public int property_TMNotifyEventID
        {
            get { return iTMNotifyEventID; }
            set { iTMNotifyEventID = value; }
        }

        private int itrademark = -1;
        public int TrademarkControversyID
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


        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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



        private void contextMenuStrip_ForDate_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ContextMenuStrip content = (ContextMenuStrip)sender;
            MaskedTextBox mtb = content.SourceControl as MaskedTextBox;

            contextMenuStrip_ForDate.Visible = false;

            switch (e.ClickedItem.Name)
            {
                case "ToolStripMenuItem_Calculation":

                    US.CalculationDate Calculation = new LawtechPTSystem.US.CalculationDate();
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

        private void button1_Click(object sender, EventArgs e)
        {
            Public.CTrademarkControversyManagement Tm = new Public.CTrademarkControversyManagement();
            Public.CTrademarkControversyManagement.ReadOne(TrademarkControversyID, ref Tm);
            
            comboBox_Statue.SelectedValue = Tm.Status;
            txt_StatusExplain.Text = Tm.StatusExplain;
        }

        private void CopyTrademarkControversyEvent_Load(object sender, EventArgs e)
        {
            this.worker_QuitNTableAdapter.Fill(this.qS_DataSet.Worker_QuitN);

            this.tMStatusTTableAdapter.Fill(this.dataSet_Drop.TMStatusT);

            this.tMNotifyDueTTableAdapter.Fill(this.dataSet_TMDrop.TMNotifyDueT, (int)comboBox_Statue.SelectedValue, CountrySymbol);

            this.worker_QuitNTableAdapter.Fill(this.qS_DataSet.Worker_QuitN);

            Public.CTrademarkControversyNotifyEvent CCTrademarkNotifyEvent = new Public.CTrademarkControversyNotifyEvent("TMNotifyControversyEventID=" + iTMNotifyEventID.ToString());
            CCTrademarkNotifyEvent.SetCurrent(iTMNotifyEventID);
           
            itrademark = CCTrademarkNotifyEvent.TrademarkControversyID;

            this.tMStatusTTableAdapter.Fill(this.dataSet_Drop.TMStatusT);
            button1_Click(null, null);


            comboBox_NotifyEventContent.Text = CCTrademarkNotifyEvent.NotifyEventContent;

            maskedTextBox_NotifyComitDate.Text = CCTrademarkNotifyEvent.NotifyComitDate.ToString("yyyy/MM/dd") != "1900/01/01" ? CCTrademarkNotifyEvent.NotifyComitDate.ToString("yyyy/MM/dd") : "";

            maskedTextBox_OccurDate.Text = CCTrademarkNotifyEvent.OccurDate.ToString("yyyy/MM/dd") != "1900/01/01" ? CCTrademarkNotifyEvent.OccurDate.ToString("yyyy/MM/dd") : "";

            maskedTextBox_NotifyOfficerDate.Text = CCTrademarkNotifyEvent.NotifyOfficerDate.ToString("yyyy/MM/dd") != "1900/01/01" ? CCTrademarkNotifyEvent.NotifyOfficerDate.ToString("yyyy/MM/dd") : "";

            maskedTextBox_DueDate.Text = CCTrademarkNotifyEvent.DueDate.ToString("yyyy/MM/dd") != "1900/01/01" ? CCTrademarkNotifyEvent.DueDate.ToString("yyyy/MM/dd") : "";

            maskedTextBox_Notice.Text = CCTrademarkNotifyEvent.NoticeDate.ToString("yyyy/MM/dd") != "1900/01/01" ? CCTrademarkNotifyEvent.NoticeDate.ToString("yyyy/MM/dd") : "";

            maskedTextBox_CustomerAuthorizationDate.Text = CCTrademarkNotifyEvent.CustomerAuthorizationDate.ToString("yyyy/MM/dd") != "1900/01/01" ? CCTrademarkNotifyEvent.CustomerAuthorizationDate.ToString("yyyy/MM/dd") : "";

            maskedTextBox_OutsourcingDate.Text = CCTrademarkNotifyEvent.OutsourcingDate.ToString("yyyy/MM/dd") != "1900/01/01" ? CCTrademarkNotifyEvent.OutsourcingDate.ToString("yyyy/MM/dd") : "";

            maskedTextBox_FinishDate.Text = CCTrademarkNotifyEvent.FinishDate.ToString("yyyy/MM/dd") != "1900/01/01" ? CCTrademarkNotifyEvent.FinishDate.ToString("yyyy/MM/dd") : "";

            maskedTextBox_AttorneyDueDate.Text = CCTrademarkNotifyEvent.AttorneyDueDate.ToString("yyyy/MM/dd") != "1900/01/01" ? CCTrademarkNotifyEvent.AttorneyDueDate.ToString("yyyy/MM/dd") : "";

            comboBox_WorkerKey.SelectedValue = CCTrademarkNotifyEvent.WorkerKey;

            txt_Result.Text = CCTrademarkNotifyEvent.Result;

            txt_Remark.Text = CCTrademarkNotifyEvent.Remark;

        }

        private void but_OK_Click(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            DataSet_TrademarkControversy.TrademarkControversyNotifyEventTRow dr = Forms.TrademarkControversyMF.dt_TrademarkControversyNotifyEventT.NewTrademarkControversyNotifyEventTRow();

            Public.CTrademarkControversyNotifyEvent AddCTrademarkNotifyEvent = new Public.CTrademarkControversyNotifyEvent("1=0");

            AddCTrademarkNotifyEvent.TrademarkControversyID = TrademarkControversyID;
            dr["TrademarkControversyID"] = TrademarkControversyID;

            AddCTrademarkNotifyEvent.NotifyEventContent = comboBox_NotifyEventContent.Text;
            dr["NotifyEventContent"] = AddCTrademarkNotifyEvent.NotifyEventContent;

            //本所期限
            DateTime dtAttorneyDueDate;
            bool IsAttorneyDueDate = DateTime.TryParse(maskedTextBox_AttorneyDueDate.Text, out dtAttorneyDueDate);
            if (IsAttorneyDueDate)
            {
                AddCTrademarkNotifyEvent.AttorneyDueDate = dtAttorneyDueDate;
                dr["AttorneyDueDate"] = AddCTrademarkNotifyEvent.AttorneyDueDate;
            }

            //本所來函日
            DateTime dtNotifyComitDate;
            bool IsNotifyComitDate = DateTime.TryParse(maskedTextBox_NotifyComitDate.Text, out dtNotifyComitDate);
            if (IsNotifyComitDate)
            {
                AddCTrademarkNotifyEvent.NotifyComitDate = dtNotifyComitDate;
                dr["NotifyComitDate"] = AddCTrademarkNotifyEvent.NotifyComitDate;
            }

            //官方送達日
            DateTime dtOccurDate;
            bool IsOccurDate = DateTime.TryParse(maskedTextBox_OccurDate.Text, out dtOccurDate);
            if (IsOccurDate)
            {
                AddCTrademarkNotifyEvent.OccurDate = dtOccurDate;
                dr["OccurDate"] = AddCTrademarkNotifyEvent.OccurDate;
            }

            //官方發文日
            DateTime dtNotifyOfficerDate;
            bool IsNotifyOfficerDate = DateTime.TryParse(maskedTextBox_NotifyOfficerDate.Text, out dtNotifyOfficerDate);
            if (IsNotifyOfficerDate)
            {
                AddCTrademarkNotifyEvent.NotifyOfficerDate = dtNotifyOfficerDate;
                dr["NotifyOfficerDate"] = AddCTrademarkNotifyEvent.NotifyOfficerDate;
            }

            //官方期限
            DateTime dtDueDate;
            bool IsDueDate = DateTime.TryParse(maskedTextBox_DueDate.Text, out dtDueDate);
            if (IsDueDate)
            {
                AddCTrademarkNotifyEvent.DueDate = dtDueDate;
                dr["DueDate"] = AddCTrademarkNotifyEvent.DueDate;
            }


            //本所通知日
            DateTime dtNoticeDate;
            bool IsNoticeDate = DateTime.TryParse(maskedTextBox_Notice.Text, out dtNoticeDate);
            if (IsNoticeDate)
            {
                AddCTrademarkNotifyEvent.NoticeDate = dtNoticeDate;
                dr["NoticeDate"] = AddCTrademarkNotifyEvent.NoticeDate;
            }

            //客戶委託日
            DateTime dtCustomerAuthorizationDate;
            bool IsCustomerAuthorizationDate = DateTime.TryParse(maskedTextBox_CustomerAuthorizationDate.Text, out dtCustomerAuthorizationDate);
            if (IsCustomerAuthorizationDate)
            {
                AddCTrademarkNotifyEvent.CustomerAuthorizationDate = dtCustomerAuthorizationDate;
                dr["CustomerAuthorizationDate"] = AddCTrademarkNotifyEvent.CustomerAuthorizationDate;
            }

            //所外委辦日
            DateTime dtOutsourcingDate;
            bool IsOutsourcingDate = DateTime.TryParse(maskedTextBox_OutsourcingDate.Text, out dtOutsourcingDate);
            if (IsOutsourcingDate)
            {
                AddCTrademarkNotifyEvent.OutsourcingDate = dtOutsourcingDate;
                dr["OutsourcingDate"] = AddCTrademarkNotifyEvent.OutsourcingDate;
            }



            //完成日期
            DateTime dtFinishDate;
            bool IsFinishDate = DateTime.TryParse(maskedTextBox_FinishDate.Text, out dtFinishDate);
            if (IsFinishDate)
            {
                AddCTrademarkNotifyEvent.FinishDate = dtFinishDate;
                dr["FinishDate"] = AddCTrademarkNotifyEvent.FinishDate;
            }



            AddCTrademarkNotifyEvent.Result = txt_Result.Text;
            dr["Result"] = AddCTrademarkNotifyEvent.Result;

            AddCTrademarkNotifyEvent.Remark = txt_Remark.Text;
            dr["Remark"] = AddCTrademarkNotifyEvent.Remark;

            AddCTrademarkNotifyEvent.WorkerKey = (int)comboBox_WorkerKey.SelectedValue;
            dr["WorkerKey"] = AddCTrademarkNotifyEvent.WorkerKey;

            dr["WorkerName"] = comboBox_WorkerKey.Text;

            AddCTrademarkNotifyEvent.UpbuildDay = DateTime.Now;
            AddCTrademarkNotifyEvent.LastModifyDate = DateTime.Now;
            AddCTrademarkNotifyEvent.LastModifyWorker = Properties.Settings.Default.WorkerKEY;

            AddCTrademarkNotifyEvent.Insert();
            dr["TMNotifyControversyEventID"] = AddCTrademarkNotifyEvent.TMNotifyControversyEventID;
            Forms.TrademarkControversyMF.dt_TrademarkControversyNotifyEventT.Rows.Add(dr);

            #region 判斷是否有預設事件，Yes-->加入工作清單中
            //判斷是否有預設事件，Yes-->加入工作清單中
            if (comboBox_NotifyEventContent.SelectedValue != null)
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
                    workList.EventID = AddCTrademarkNotifyEvent.TMNotifyControversyEventID;
                    workList.Worker = processList[iRow].DefualtWorker;//事件的預設承辦人
                    workList.Progress = processList[iRow].ProcessHandleKEY;
                    workList.WorkDate = DateTime.Now;
                    workList.OstatusSN = processList[iRow].Status;//申請案狀態
                    workList.Create();
                }

            }
            #endregion

            //
            Public.CTrademarkControversyManagement Tm = new Public.CTrademarkControversyManagement();
            Public.CTrademarkControversyManagement.ReadOne(TrademarkControversyID, ref Tm);           

            DataRow drTrademark = Forms.TrademarkControversyMF.dt_TrademarkControversyManagementT.Rows.Find(TrademarkControversyID);
            if (comboBox_Statue.SelectedValue != null)
            {
                Tm.Status = (int)comboBox_Statue.SelectedValue;
                drTrademark["Status"] = Tm.Status;
                drTrademark["StatusName"] = comboBox_Statue.Text;
            }
                Tm.StatusExplain = txt_StatusExplain.Text;
              
                Tm.LastModifyWorker = Properties.Settings.Default.WorkerName;
                Tm.Update();
                
                
                drTrademark["StatusExplain"] = Tm.StatusExplain;
                Forms.TrademarkControversyMF.dt_TrademarkControversyManagementT.AcceptChanges();
            

            MessageBox.Show("新增成功", "提示訊息");
            this.Close();
        }

        private void CopyTrademarkControversyEvent_KeyDown(object sender, KeyEventArgs e)
        {
            Public.Utility.ControlTab(e);
        }
    }
}
