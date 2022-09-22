using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.EditForm
{
    public partial class EditTrademarkControversyNotifyEvent : Form
    {
        public EditTrademarkControversyNotifyEvent()
        {
            InitializeComponent();
        }

        private int iTMNotifyControversyEventID = -1;
        /// <summary>
        /// 商標來函 ID
        /// </summary>
        public int property_TMNotifyEventID
        {
            get { return iTMNotifyControversyEventID; }
            set { iTMNotifyControversyEventID = value; }
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

        private void EditTrademarkControversyNotifyEvent_Load(object sender, EventArgs e)
        {           
            this.tMStatusTTableAdapter.Fill(this.dataSet_Drop.TMStatusT);
            Public.CTrademarkControversyNotifyEvent CCTrademarkNotifyEvent = new Public.CTrademarkControversyNotifyEvent("TMNotifyControversyEventID=" + property_TMNotifyEventID.ToString());
            CCTrademarkNotifyEvent.SetCurrent(iTMNotifyControversyEventID);

            TrademarkControversyID = CCTrademarkNotifyEvent.TrademarkControversyID;

            button1_Click(null,null);

            this.worker_QuitNTableAdapter.Fill(this.qS_DataSet.Worker_QuitN);           
          
            this.trademarkNotifyEventTypeTTableAdapter.Fill(this.dataSet_Drop.TrademarkNotifyEventTypeT);

         
            txt_NotifyEventContent.Text = CCTrademarkNotifyEvent.NotifyEventContent;

            comboBox_EventType.Text = CCTrademarkNotifyEvent.EventType;

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
            //if (txt_NotifyEventContent.Text.Trim() == "")
            //{
            //    MessageBox.Show("來函內容不得為空白", "提示訊息");
            //    txt_NotifyEventContent.Focus();
            //    return;
            //}
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            DataSet_TrademarkControversy.TrademarkControversyNotifyEventTRow dr = Forms.TrademarkControversyMF.dt_TrademarkControversyNotifyEventT.FindByTMNotifyControversyEventID(property_TMNotifyEventID);

            Public.CTrademarkControversyNotifyEvent AddCTrademarkNotifyEvent = new Public.CTrademarkControversyNotifyEvent("TMNotifyControversyEventID=" + property_TMNotifyEventID.ToString());
            AddCTrademarkNotifyEvent.SetCurrent(property_TMNotifyEventID);


            AddCTrademarkNotifyEvent.NotifyEventContent = txt_NotifyEventContent.Text;
            dr["NotifyEventContent"] = AddCTrademarkNotifyEvent.NotifyEventContent;

            AddCTrademarkNotifyEvent.NotifyComitDate = maskedTextBox_NotifyComitDate.Text != "    /  /" ? DateTime.Parse(maskedTextBox_NotifyComitDate.Text) : DateTime.Parse("1900/1/1");
            if (AddCTrademarkNotifyEvent.NotifyComitDate.Year != 1900)
            {
                dr["NotifyComitDate"] = AddCTrademarkNotifyEvent.NotifyComitDate;
            }
            else
            {
                dr["NotifyComitDate"] = DBNull.Value;
            }

            //本所通知日
            AddCTrademarkNotifyEvent.NoticeDate = maskedTextBox_Notice.Text != "    /  /" ? DateTime.Parse(maskedTextBox_Notice.Text) : DateTime.Parse("1900/1/1");
            if (AddCTrademarkNotifyEvent.NoticeDate.Year != 1900)
            {
                dr["NoticeDate"] = AddCTrademarkNotifyEvent.NoticeDate;
            }
            else
            {
                dr["NoticeDate"] = DBNull.Value;
            }

            AddCTrademarkNotifyEvent.AttorneyDueDate = maskedTextBox_AttorneyDueDate.Text != "    /  /" ? DateTime.Parse(maskedTextBox_AttorneyDueDate.Text) : DateTime.Parse("1900/1/1");
            if (AddCTrademarkNotifyEvent.AttorneyDueDate.Year != 1900)
            {
                dr["AttorneyDueDate"] = AddCTrademarkNotifyEvent.AttorneyDueDate;
            }
            else
            {
                dr["AttorneyDueDate"] = DBNull.Value;
            }

            AddCTrademarkNotifyEvent.OccurDate = maskedTextBox_OccurDate.Text != "    /  /" ? DateTime.Parse(maskedTextBox_OccurDate.Text) : DateTime.Parse("1900/1/1");
            if (AddCTrademarkNotifyEvent.OccurDate.Year != 1900)
            {
                dr["OccurDate"] = AddCTrademarkNotifyEvent.OccurDate;
            }
            else
            {
                dr["OccurDate"] = DBNull.Value;
            }

            AddCTrademarkNotifyEvent.NotifyOfficerDate = maskedTextBox_NotifyOfficerDate.Text != "    /  /" ? DateTime.Parse(maskedTextBox_NotifyOfficerDate.Text) : DateTime.Parse("1900/1/1");
            if (AddCTrademarkNotifyEvent.NotifyOfficerDate.Year != 1900)
            {
                dr["NotifyOfficerDate"] = AddCTrademarkNotifyEvent.NotifyOfficerDate;
            }
            else
            {
                dr["NotifyOfficerDate"] = DBNull.Value;
            }

            AddCTrademarkNotifyEvent.DueDate = maskedTextBox_DueDate.Text != "    /  /" ? DateTime.Parse(maskedTextBox_DueDate.Text) : DateTime.Parse("1900/1/1");
            if (AddCTrademarkNotifyEvent.DueDate.Year != 1900)
            {
                dr["DueDate"] = AddCTrademarkNotifyEvent.DueDate;
            }
            else
            {
                dr["DueDate"] = DBNull.Value;
            }

            AddCTrademarkNotifyEvent.NoticeDate = maskedTextBox_NotifyOfficerDate.Text != "    /  /" ? DateTime.Parse(maskedTextBox_NotifyOfficerDate.Text) : DateTime.Parse("1900/1/1");
            if (AddCTrademarkNotifyEvent.NoticeDate.Year != 1900)
            {
                dr["NoticeDate"] = AddCTrademarkNotifyEvent.NoticeDate;
            }
            else
            {
                dr["NoticeDate"] = DBNull.Value;
            }

            AddCTrademarkNotifyEvent.CustomerAuthorizationDate = maskedTextBox_CustomerAuthorizationDate.Text != "    /  /" ? DateTime.Parse(maskedTextBox_CustomerAuthorizationDate.Text) : DateTime.Parse("1900/1/1");
            if (AddCTrademarkNotifyEvent.CustomerAuthorizationDate.Year != 1900)
            {
                dr["CustomerAuthorizationDate"] = AddCTrademarkNotifyEvent.CustomerAuthorizationDate;
            }
            else
            {
                dr["CustomerAuthorizationDate"] = DBNull.Value;
            }

            AddCTrademarkNotifyEvent.OutsourcingDate = maskedTextBox_OutsourcingDate.Text != "    /  /" ? DateTime.Parse(maskedTextBox_OutsourcingDate.Text) : DateTime.Parse("1900/1/1");
            if (AddCTrademarkNotifyEvent.OutsourcingDate.Year != 1900)
            {
                dr["OutsourcingDate"] = AddCTrademarkNotifyEvent.OutsourcingDate;
            }
            else
            {
                dr["OutsourcingDate"] = DBNull.Value;
            }

            AddCTrademarkNotifyEvent.FinishDate = maskedTextBox_FinishDate.Text != "    /  /" ? DateTime.Parse(maskedTextBox_FinishDate.Text) : DateTime.Parse("1900/1/1");
            if (AddCTrademarkNotifyEvent.FinishDate.Year != 1900)
            {
                dr["FinishDate"] = AddCTrademarkNotifyEvent.FinishDate;
            }
            else
            {
                dr["FinishDate"] = DBNull.Value;
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


            AddCTrademarkNotifyEvent.Updata(property_TMNotifyEventID);

            Forms.TrademarkControversyMF.dt_TrademarkControversyNotifyEventT.AcceptChanges();

            //
            Public.CTrademarkControversyManagement Tm = new LawtechPTSystemByFirm.Public.CTrademarkControversyManagement();
            Public.CTrademarkControversyManagement.ReadOne(TrademarkControversyID, ref Tm);
            
            Tm.StatusExplain = txt_StatusExplain.Text;

            DataRow drTrademark = Forms.TrademarkControversyMF.dt_TrademarkControversyManagementT.Rows.Find(TrademarkControversyID);            
            drTrademark["StatusExplain"] = Tm.StatusExplain;

            if (comboBox_Statue.SelectedValue != null && Tm.Status != (int)comboBox_Statue.SelectedValue)
            {
                Tm.Status = (int)comboBox_Statue.SelectedValue;                
                drTrademark["Status"] = Tm.Status;
                drTrademark["StatusName"] = comboBox_Statue.Text;               
            }
            Tm.Update();
            Forms.TrademarkControversyMF.dt_TrademarkControversyManagementT.AcceptChanges();

            MessageBox.Show("修改成功", "提示訊息");
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Public.CTrademarkControversyManagement Tm = new LawtechPTSystemByFirm.Public.CTrademarkControversyManagement();
            Public.CTrademarkControversyManagement.ReadOne(TrademarkControversyID, ref Tm);
          
            comboBox_Statue.SelectedValue = Tm.Status;
            txt_StatusExplain.Text = Tm.StatusExplain;
        }

        private void EditTrademarkControversyNotifyEvent_KeyDown(object sender, KeyEventArgs e)
        {
            Public.Utility.ControlTab(e);
        }
    }
}
