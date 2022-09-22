using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.US
{
    /// <summary>
    /// 商標事件轉放棄
    /// </summary>
    public partial class AbortControlTrademark : Form
    {
        public AbortControlTrademark()
        {
            InitializeComponent();
        }

       
        private int iEventType = 1;
        /// <summary>
        /// 1.事件記錄 2.來函 3.費用
        /// </summary>
        public int EventType
        {
            get { return iEventType; }
            set { iEventType = value; }
        }

        private int iTrademarkID = -1;
        /// <summary>
        /// 申請案ID
        /// </summary>
        public int TrademarkID
        {
            get { return iTrademarkID; }
            set { iTrademarkID = value; }
        }

        private int iEventID = -1;
        /// <summary>
        /// 事件ID
        /// </summary>
        public int EventID
        {
            get { return iEventID; }
            set { iEventID = value; }
        }



        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AbortControl_Load(object sender, EventArgs e)
        {
            Public.CTrademarkManagement tm = new Public.CTrademarkManagement();
            Public.CTrademarkManagement.ReadOne(iTrademarkID, ref tm);

            Public.CTrademarkNotifyEvent tmEvent = new Public.CTrademarkNotifyEvent();
            Public.CTrademarkNotifyEvent.ReadOne(EventID, ref tmEvent);

            this.patStatusT_DropTableAdapter.Fill(this.qS_DataSet._PatStatusT_Drop);

            txtFileNo.Text = tm.TrademarkNo;  //申請案卷號

            mskFinishDate.Text = DateTime.Now.ToString("yyyy/MM/dd");

            txtEventContent.Text = tmEvent.NotifyEventContent; //事件內容               

           

            if (tm.Status.HasValue)
            {
                cboStatus.SelectedValue = tm.Status.Value;
            }
            txtStatusExplain.Text = tm.StatusExplain;
           
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            PatentEvent_Insert(chkFileAbort.Checked);
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="b">申請案是否一併放棄</param>
        private void PatentEvent_Insert(bool b)
        {
            try
            {
                Public.PublicForm Forms = new Public.PublicForm();
                SubFrom.TrademarkControlEventList cmf = Forms.TrademarkControlEventList;

                switch (EventType)
                {
                    case 1://事件記錄
                        Public.CTrademarkNotifyEvent ComitEvent = new Public.CTrademarkNotifyEvent();
                        Public.CTrademarkNotifyEvent.ReadOne(iEventID, ref ComitEvent);

                        Public.CTrademarkManagement tm = new Public.CTrademarkManagement();
                        Public.CTrademarkManagement.ReadOne(ComitEvent.TrademarkID, ref tm);

                        if (b)//true-申請案一起放棄
                        {
                            tm.Status = int.Parse(cboStatus.SelectedValue.ToString());
                            tm.StatusExplain = txtStatusExplain.Text;

                            DateTime dtCloseDate;
                            bool IsCloseDate = DateTime.TryParse(maskedTextBox_CloseDate.Text, out dtCloseDate);
                            if (IsCloseDate)
                            {
                                tm.CloseDate = dtCloseDate;
                            }
                            else
                            {
                                tm.CloseDate = DateTime.Now;
                            }
                            tm.Remarks= txt_CloseCaus.Text;
                            tm.LastModifyDateTime = DateTime.Now;
                            tm.LastModifyWorker = Properties.Settings.Default.WorkerName;
                            tm.Update();
                        }


                        DateTime dtFinishDate;
                        bool IsFinishDate = DateTime.TryParse(mskFinishDate.Text, out dtFinishDate);
                        if (IsFinishDate)
                        {
                            ComitEvent.FinishDate = dtFinishDate;
                        }
                        ComitEvent.Result = txt_Result.Text;
                        ComitEvent.Update();

                        if (cmf != null)
                        {
                            cmf.dgViewMF.CurrentRow.Cells["FinishDate"].Value = ComitEvent.FinishDate;
                            cmf.dgViewMF.CurrentRow.Cells["Result"].Value = ComitEvent.Result;
                            cmf.dgViewMF.CurrentRow.Cells["DiffDueDate"].Value = 0;
                            DataTable dtControl = cmf.dt_ControlEvent;
                            dtControl.AcceptChanges();
                        }

                        break;
                  
                }                

                if (Forms.MainFrom != null)
                {
                    Forms.MainFrom.RefreshTrademarkEvent();
                }
                
               
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message.Replace("'", ""), "錯誤訊息",MessageBoxButtons.OK);
            }
        }

        private void chkFileAbort_CheckedChanged(object sender, EventArgs e)
        {
            groupBox_Patent.Enabled = chkFileAbort.Checked;
        }

        private void AbortControl_KeyDown(object sender, KeyEventArgs e)
        {
            Public.Utility.ControlTab(e);
        }

        private void mskFinishDate_Leave(object sender, EventArgs e)
        {
            MaskedTextBox mak = (MaskedTextBox)sender;
            Public.Utility.CheckMaskedtextbox(mak);
        }

        private void mskFinishDate_DoubleClick(object sender, EventArgs e)
        {
            MaskedTextBox masked = (MaskedTextBox)sender;
            Public.CommonFunctions.MaskedTextBoxDoubleClick(masked);
        }
    }
}
