using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.EditForm
{
    public partial class EditTrademarkWorkEvent : Form
    {
        public EditTrademarkWorkEvent()
        {
            InitializeComponent();
        }


        private int iWorkReportID = -1;
        /// <summary>
        /// 商標事件工作報告表 PK
        /// </summary>
        public int WorkReportID
        {
            get { return iWorkReportID; }
            set { iWorkReportID = value; }
        }

        private int iEventType = 1;
        /// <summary>
        /// 商標事件類型 1.事件記綠 2.付款  3.請款
        /// </summary>
        public int EventType
        {
            get { return iEventType; }
            set { iEventType = value; }
        }

        private int iEventID = -1;
        /// <summary>
        /// 事件(事件記綠 、付款 、請款)的 ID
        /// </summary>
        public int EventID
        {
            get { return iEventID; }
            set { iEventID = value; }
        }

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void but_OK_Click(object sender, EventArgs e)
        {
            if (txt_WorkContent.Text.Trim() != "")
            {
                Public.CTrademarkWorkReport Edit = new LawtechPTSystemByFirm.Public.CTrademarkWorkReport();
                Public.CTrademarkWorkReport.ReadOne(iWorkReportID, ref Edit);
                
                Edit.EventID = iEventID;
                Edit.EventType = iEventType;
                Edit.WorkContent = txt_WorkContent.Text;
                Edit.Memo = txt_Memo.Text;
                Edit.IsStart = checkBox_IsStart.Checked;

                DateTime dtEstimateDateTime ;
                bool IsEstimateDateTime = DateTime.TryParse(maskedTextBox_EstimateDateTime.Text.Replace("   :", ""), out dtEstimateDateTime);
                if (IsEstimateDateTime) Edit.EstimateDateTime = dtEstimateDateTime;
                else Edit.EstimateDateTime = null;

                DateTime dtWorkDate ;
                bool IsWorkDate = DateTime.TryParse(maskedTextBox_WorkDate.Text.Replace("   :", ""), out dtWorkDate);
                if (IsWorkDate) Edit.WorkDate = dtWorkDate;
                else Edit.WorkDate = null;

                DateTime dtStartTime ;
                bool IsStartTime = DateTime.TryParse(maskedTextBox_StartTime.Text.Replace("   :", ""), out dtStartTime);
                if (IsStartTime) Edit.StartTime = dtStartTime;
                else Edit.StartTime = null;

                DateTime dtEnd ;
                bool IsEndTime = DateTime.TryParse(maskedTextBox_EndTime.Text.Replace("   :", ""), out dtEnd);
                if (IsEndTime) Edit.EndTime = dtEnd;
                else Edit.EndTime = null;

                Edit.AllTime = txt_AllTime.Text;

                Edit.Worker = (int)comboBox_Worker.SelectedValue;
                Edit.Update();

                Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
                if (Forms.TrademarkControlEventList != null)
                {
                    DataRow dr = Forms.TrademarkControlEventList.DT_TrademarkWorkReportT.Rows.Find(iWorkReportID);
                    Forms.TrademarkControlEventList.DT_TrademarkWorkReportT.Rows.Remove(dr);

                    DataRow drNew = Forms.TrademarkControlEventList.DT_TrademarkWorkReportT.NewRow();
                    DataRow drV = Public.CTrademarkPublicFunction.GetTrademarkWorkReport(Edit.WorkReportID.ToString());
                    drNew.ItemArray = drV.ItemArray;
                    Forms.TrademarkControlEventList.DT_TrademarkWorkReportT.Rows.Add(drNew);
                    drNew.AcceptChanges();                  
                }
               

                MessageBox.Show("修改成功", "提示訊息", MessageBoxButtons.OK);
                this.Close();
            }
            else
            {
                MessageBox.Show("事件工作內容不得為空白，請輸入事件工作內容不得為空白");
                return;
            }
        }

        private void EditTrademarkWorkEvent_Load(object sender, EventArgs e)
        {
            this.workerTAllTableAdapter.Fill(this.qS_DataSet.WorkerTAll);

            Public.CTrademarkWorkReport edit = new LawtechPTSystemByFirm.Public.CTrademarkWorkReport();
            Public.CTrademarkWorkReport.ReadOne(iWorkReportID, ref edit);
          
            txt_WorkContent.Text = edit.WorkContent;
            txt_Memo.Text = edit.Memo;
            if (edit.Worker.HasValue)
            {
                comboBox_Worker.SelectedValue = edit.Worker.Value;
            }
            maskedTextBox_WorkDate.Text = edit.WorkDate.HasValue? edit.WorkDate.Value.ToString("yyyy/MM/dd HH:mm") : "";
            maskedTextBox_EndTime.Text = edit.EndTime.HasValue ? edit.EndTime.Value.ToString("yyyy/MM/dd HH:mm") : "";
            maskedTextBox_StartTime.Text = edit.StartTime.HasValue ? edit.StartTime.Value.ToString("yyyy/MM/dd HH:mm") : "";
            maskedTextBox_EstimateDateTime.Text = edit.EstimateDateTime.HasValue ? edit.EstimateDateTime.Value.ToString("yyyy/MM/dd HH:mm") : "";
            checkBox_IsStart.Checked = edit.IsStart.HasValue? edit.IsStart.Value:false;
            txt_AllTime.Text = edit.AllTime;

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


        public void GetAllTime()
        {
            DateTime StartTime;
            bool IsStartTime = DateTime.TryParse(maskedTextBox_StartTime.Text, out StartTime);
            

            DateTime EndTime;
            bool IsEndTime = DateTime.TryParse(maskedTextBox_EndTime.Text, out EndTime);
           

            if (IsStartTime && IsEndTime)
            {
                
                string returnValue = "";
                if (IsStartTime && IsEndTime)
                {
                    TimeSpan allTime = new TimeSpan();
                    allTime = EndTime.Subtract(StartTime);

                    if (allTime.Days > 0)
                    {
                        returnValue = allTime.Days.ToString() + "天";
                    }
                    if (allTime.Hours > 0)
                    {
                        returnValue += allTime.Hours.ToString() + "小時";
                    }
                    if (allTime.Minutes > 0)
                    {
                        returnValue += allTime.Minutes.ToString() + "分鐘";
                    }
                }

                txt_AllTime.Text = returnValue;
            }
        }

        private void maskedTextBox_StartTime_Leave(object sender, EventArgs e)
        {
            GetAllTime();
        }

        private void checkBox_IsStart_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = checkBox_IsStart.Checked;
        }
    }
}
