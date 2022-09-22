using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.AddFrom
{
    public partial class AddTrademarkWorkEvent : Form
    {
        public AddTrademarkWorkEvent()
        {
            InitializeComponent();
        }

        private int iEventType = 1;
        /// <summary>
        /// 1.事件記錄  2.付款  3.請款 
        /// </summary>
        public int EventType
        {
            get { return iEventType; }
            set { iEventType = value; }
        }

        private int iEventID = -1;
        /// <summary>
        /// 事件(事件記錄、請款、付款)的 ID
        /// </summary>
        public int EventID
        {
            get { return iEventID; }
            set { iEventID = value; }
        }

        private void AddTrademarkWorkEvent_Load(object sender, EventArgs e)
        {            
            this.worker_QuitNTableAdapter.Fill(this.qS_DataSet.Worker_QuitN);           

            maskedTextBox_WorkDate.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");

            comboBox_Worker.SelectedValue = Properties.Settings.Default.WorkerKEY;
        }

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void but_OK_Click(object sender, EventArgs e)
        {
            if (txt_WorkContent.Text.Trim() != "")
            {
                Public.CTrademarkWorkReport add = new LawtechPTSystemByFirm.Public.CTrademarkWorkReport();
                add.EventID = iEventID;
                add.EventType = iEventType;
                add.WorkContent = txt_WorkContent.Text;
                add.Memo = txt_Memo.Text;

                DateTime dtEstimateDateTime ;
                bool IsEstimateDateTime = DateTime.TryParse(maskedTextBox_EstimateDateTime.Text.Replace("   :", ""), out dtEstimateDateTime);
                if (IsEstimateDateTime) add.EstimateDateTime = dtEstimateDateTime;
                else add.EstimateDateTime = null;

                DateTime dtWorkDate ;
                bool IsWorkDate = DateTime.TryParse(maskedTextBox_WorkDate.Text.Replace("   :", ""), out dtWorkDate);
                if (IsWorkDate) add.WorkDate = dtWorkDate;
                else add.WorkDate = null;

           
                if (comboBox_Worker.SelectedValue != null)
                {
                    add.Worker = (int)comboBox_Worker.SelectedValue;
                }
                add.Create();

                Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
                if (Forms.TrademarkControlEventList != null)
                {
                    DataRow dr = Forms.TrademarkControlEventList.DT_TrademarkWorkReportT.NewRow();
                    DataRow drV = Public.CTrademarkPublicFunction.GetTrademarkWorkReport(add.WorkReportID.ToString());
                    dr.ItemArray = drV.ItemArray;
                   
                    Forms.TrademarkControlEventList.DT_TrademarkWorkReportT.Rows.Add(dr);
                    dr.AcceptChanges();
                }
                MessageBox.Show("新增成功", "提示訊息", MessageBoxButtons.OK);
                this.Close();
            }
            else
            {
                MessageBox.Show("事件工作內容不得為空白，請輸入事件工作內容不得為空白");
                return;
            }
        }

        private void maskedTextBox_WorkDate_DoubleClick(object sender, EventArgs e)
        {
            MaskedTextBox mtb = (MaskedTextBox)sender;
            DateTime dt;
            bool IsSuccess = DateTime.TryParse(mtb.Text, out dt);
            if (!IsSuccess)
            {
                mtb.Text = DateTime.Now.ToString("yyyy/MM/dd hh:mm");
            }
        }
    }
}
