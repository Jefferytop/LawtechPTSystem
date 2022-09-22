using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.AddFrom
{
    public partial class AddTrademarkControversyNotifyEvent : Form
    {
        public AddTrademarkControversyNotifyEvent()
        {
            InitializeComponent();
        }

        private int iTrademarkControversyID = -1;
        /// <summary>
        /// 異議案商標ID
        /// </summary>
        public int TrademarkControversyID
        {
            get { return iTrademarkControversyID; }
            set { iTrademarkControversyID = value; }
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

        private void maskedTextBox_AttorneyDueDate_DoubleClick(object sender, EventArgs e)
        {
            MaskedTextBox mtb = (MaskedTextBox)sender;
            DateTime dt;
            bool IsSuccess = DateTime.TryParse(mtb.Text, out dt);
            if (!IsSuccess)
            {
                mtb.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }
        }

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddTrademarkControversyNotifyEvent_Load(object sender, EventArgs e)
        {
            
            this.tMStatusTTableAdapter.Fill(this.dataSet_Drop.TMStatusT);
            button1_Click(null,null);
           
            this.worker_QuitNTableAdapter.Fill(this.qS_DataSet.Worker_QuitN);
            this.trademarkNotifyEventTypeTTableAdapter.Fill(this.dataSet_Drop.TrademarkNotifyEventTypeT);
            this.tMNotifyDueTTableAdapter1.Fill(this.dataSet_TMDrop.TMNotifyDueT, (int)comboBox_Statue.SelectedValue, CountrySymbol);

            comboBox_WorkerKey.SelectedValue = Properties.Settings.Default.WorkerKEY;
            maskedTextBox_NotifyComitDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
        }

        private void but_OK_Click(object sender, EventArgs e)
        {
            //if (comboBox_NotifyEventContent.Text.Trim() == "")
            //{
            //    MessageBox.Show("來函內容不得為空白", "提示訊息");
            //    comboBox_NotifyEventContent.Focus();
            //    return;
            //}

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            DataSet_TrademarkControversy.TrademarkControversyNotifyEventTRow dr = Forms.TrademarkControversyMF.dt_TrademarkControversyNotifyEventT.NewTrademarkControversyNotifyEventTRow();

            Public.CTrademarkControversyNotifyEvent AddCTrademarkNotifyEvent = new Public.CTrademarkControversyNotifyEvent("1=0");

            AddCTrademarkNotifyEvent.TrademarkControversyID = TrademarkControversyID;
            dr["TrademarkControversyID"] = TrademarkControversyID;

            AddCTrademarkNotifyEvent.NotifyEventContent = comboBox_NotifyEventContent.Text;
            dr["NotifyEventContent"] = AddCTrademarkNotifyEvent.NotifyEventContent;

            AddCTrademarkNotifyEvent.AttorneyDueDate = maskedTextBox_AttorneyDueDate.Text != "    /  /" ? DateTime.Parse(maskedTextBox_AttorneyDueDate.Text) : DateTime.Parse("1900/1/1");
            if (AddCTrademarkNotifyEvent.AttorneyDueDate.Year != 1900)
            {
                dr["AttorneyDueDate"] = AddCTrademarkNotifyEvent.AttorneyDueDate;
            }

            AddCTrademarkNotifyEvent.NotifyComitDate = maskedTextBox_NotifyComitDate.Text != "    /  /" ? DateTime.Parse(maskedTextBox_NotifyComitDate.Text) : DateTime.Parse("1900/1/1");
            if (AddCTrademarkNotifyEvent.NotifyComitDate.Year != 1900)
            {
                dr["NotifyComitDate"] = AddCTrademarkNotifyEvent.NotifyComitDate;
            }

            
            AddCTrademarkNotifyEvent.OccurDate = maskedTextBox_OccurDate.Text != "    /  /" ? DateTime.Parse(maskedTextBox_OccurDate.Text) : DateTime.Parse("1900/1/1");
            if (AddCTrademarkNotifyEvent.OccurDate.Year != 1900)
            {
                dr["OccurDate"] = AddCTrademarkNotifyEvent.OccurDate;
            }

            //官方發文日
            AddCTrademarkNotifyEvent.NotifyOfficerDate = maskedTextBox_NoticeDate.Text != "    /  /" ? DateTime.Parse(maskedTextBox_NoticeDate.Text) : DateTime.Parse("1900/1/1");
            if (AddCTrademarkNotifyEvent.NotifyOfficerDate.Year != 1900)
            {
                dr["NotifyOfficerDate"] = AddCTrademarkNotifyEvent.NotifyOfficerDate;
            }

            AddCTrademarkNotifyEvent.DueDate = maskedTextBox_DueDate.Text != "    /  /" ? DateTime.Parse(maskedTextBox_DueDate.Text) : DateTime.Parse("1900/1/1");
            if (AddCTrademarkNotifyEvent.DueDate.Year != 1900)
            {
                dr["DueDate"] = AddCTrademarkNotifyEvent.DueDate;
            }

            //本所通知日
            AddCTrademarkNotifyEvent.NoticeDate = maskedTextBox_Notice.Text != "    /  /" ? DateTime.Parse(maskedTextBox_Notice.Text) : DateTime.Parse("1900/1/1");
            if (AddCTrademarkNotifyEvent.NoticeDate.Year != 1900)
            {
                dr["NoticeDate"] = AddCTrademarkNotifyEvent.NoticeDate;
            }

            AddCTrademarkNotifyEvent.CustomerAuthorizationDate = maskedTextBox_CustomerAuthorizationDate.Text != "    /  /" ? DateTime.Parse(maskedTextBox_CustomerAuthorizationDate.Text) : DateTime.Parse("1900/1/1");
            if (AddCTrademarkNotifyEvent.CustomerAuthorizationDate.Year != 1900)
            {
                dr["CustomerAuthorizationDate"] = AddCTrademarkNotifyEvent.CustomerAuthorizationDate;
            }

            AddCTrademarkNotifyEvent.OutsourcingDate = maskedTextBox_OutsourcingDate.Text != "    /  /" ? DateTime.Parse(maskedTextBox_OutsourcingDate.Text) : DateTime.Parse("1900/1/1");
            if (AddCTrademarkNotifyEvent.OutsourcingDate.Year != 1900)
            {
                dr["OutsourcingDate"] = AddCTrademarkNotifyEvent.OutsourcingDate;
            }

            AddCTrademarkNotifyEvent.FinishDate = maskedTextBox_FinishDate.Text != "    /  /" ? DateTime.Parse(maskedTextBox_FinishDate.Text) : DateTime.Parse("1900/1/1");
            if (AddCTrademarkNotifyEvent.FinishDate.Year != 1900)
            {
                dr["FinishDate"] = AddCTrademarkNotifyEvent.FinishDate;
            }

            AddCTrademarkNotifyEvent.EventType = comboBox_EventType.Text;
            dr["EventType"] = AddCTrademarkNotifyEvent.EventType;

            AddCTrademarkNotifyEvent.Result = txt_Result.Text;
            dr["Result"] = AddCTrademarkNotifyEvent.Result;

            AddCTrademarkNotifyEvent.Remark = txt_Remark.Text;
            dr["Remark"] = AddCTrademarkNotifyEvent.Remark;

            AddCTrademarkNotifyEvent.WorkerKey = (int)comboBox_WorkerKey.SelectedValue;
            dr["WorkerKey"] = AddCTrademarkNotifyEvent.WorkerKey;

            dr["WorkerName"] = comboBox_WorkerKey.Text;

            AddCTrademarkNotifyEvent.LastModifyDate = DateTime.Now;
            AddCTrademarkNotifyEvent.LastModifyWorker = Properties.Settings.Default.WorkerKEY;

            dr["LastModifyDate"] = AddCTrademarkNotifyEvent.LastModifyDate;
            dr["LastModifyWorker"] = Properties.Settings.Default.WorkerName;

            AddCTrademarkNotifyEvent.Insert();
            dr["TMNotifyControversyEventID"] = AddCTrademarkNotifyEvent.TMNotifyControversyEventID;
            Forms.TrademarkControversyMF.dt_TrademarkControversyNotifyEventT.Rows.Add(dr);

            #region 判斷是否有預設事件，Yes-->加入工作清單中
            //判斷是否有預設事件，Yes-->加入工作清單中
            if (comboBox_NotifyEventContent.SelectedValue != null)
            {

                Public.CTMNotifyDue notify = new LawtechPTSystemByFirm.Public.CTMNotifyDue();
                 Public.CTMNotifyDue.ReadOne((int)comboBox_NotifyEventContent.SelectedValue,ref notify);
               

                List<Public.CTrademarkProcessStepE> processList = new List<Public.CTrademarkProcessStepE>();
                Public.CTrademarkProcessStepE.ReadList(ref processList, " IsUsing=1 and ProcessKEY=" + notify.ProcessKEY.ToString() + " order by Sort");
                if (notify.Note != "")
                {
                    MessageBox.Show("提醒訊息 :\r\n " + notify.Note, "提示訊息");
                }   
                Public.CTrademarkWorkReport workList = new LawtechPTSystemByFirm.Public.CTrademarkWorkReport();
                for (int iRow = 0; iRow < processList.Count; iRow++)
                {

                    workList.IsStart = false;
                    workList.EventType = 20;
                    workList.WorkContent = processList[iRow].Handle;
                    workList.EventID = AddCTrademarkNotifyEvent.TMNotifyControversyEventID;
                    if (processList[iRow].DefualtWorker.HasValue)
                    {
                        workList.Worker = processList[iRow].DefualtWorker.Value;//事件的預設承辦人
                    }
                    workList.Progress = processList[iRow].ProcessHandleKEY;
                    workList.WorkDate = DateTime.Now;
                    if (processList[iRow].Status.HasValue)
                    {
                        workList.OstatusSN = processList[iRow].Status.Value;//申請案狀態
                    }
                    workList.Create();
                }

            }
            #endregion

            //
            Public.CTrademarkControversyManagement Tm = new LawtechPTSystemByFirm.Public.CTrademarkControversyManagement();
            Public.CTrademarkControversyManagement.ReadOne(TrademarkControversyID, ref Tm);
           

            //案件階段           
            if (comboBox_Statue.SelectedValue != null && Tm.Status != (int)comboBox_Statue.SelectedValue)
            {
                Tm.Status = (int)comboBox_Statue.SelectedValue;
                           
            }            
            Tm.StatusExplain = txt_StatusExplain.Text;
            Tm.Update();

            DataRow drTrademark = Forms.TrademarkControversyMF.dt_TrademarkControversyManagementT.Rows.Find(TrademarkControversyID);
            if (drTrademark != null)
            {
                drTrademark["Status"] = Tm.Status;
                drTrademark["StatusName"] = comboBox_Statue.Text;
             
            }
            drTrademark["StatusExplain"] = Tm.StatusExplain;
            Forms.TrademarkControversyMF.dt_TrademarkControversyManagementT.AcceptChanges();


            

            MessageBox.Show("新增成功", "提示訊息");
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Public.CTrademarkControversyManagement Tm = new LawtechPTSystemByFirm.Public.CTrademarkControversyManagement();
            Public.CTrademarkControversyManagement.ReadOne(TrademarkControversyID, ref Tm);
            
            comboBox_Statue.SelectedValue = Tm.Status;
            txt_StatusExplain.Text = Tm.StatusExplain;
        }

        private void comboBox_Statue_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddTrademarkControversyNotifyEvent_KeyDown(object sender, KeyEventArgs e)
        {
            Public.Utility.ControlTab(e);
        }

      
     
    }
}
