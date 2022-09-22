using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.US
{
    public partial class AbortControl : Form
    {
        public AbortControl()
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

        private int iPatentID = -1;
        /// <summary>
        /// 申請案ID
        /// </summary>
        public int PatentID
        {
            get { return iPatentID; }
            set { iPatentID = value; }
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
            Public.CPatentManagement patent = new LawtechPTSystemByFirm.Public.CPatentManagement();
            Public.CPatentManagement.ReadOne(PatentID, ref patent);

            Public.CPatComitEvent patentEvent = new LawtechPTSystemByFirm.Public.CPatComitEvent();
            Public.CPatComitEvent.ReadOne(EventID, ref patentEvent);

            this.patStatusT_DropTableAdapter.Fill(this.qS_DataSet._PatStatusT_Drop);

            txtFileNo.Text = patent.PatentNo;  //申請案卷號

            mskFinishDate.Text = DateTime.Now.ToString("yyyy/MM/dd");

            txtEventContent.Text = patentEvent.EventContent; //事件內容               

           

            if (patent.Status.HasValue)
            {
                cboStatus.SelectedValue = patent.Status.Value;
            }
            txtStatusExplain.Text = patent.StatusExplain;
           
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
                SubFrom.PATControlEventList cmf = Forms.PATControlEventList;

                switch (EventType)
                { 
                    case 1://事件記錄
                        Public.CPatComitEvent ComitEvent = new Public.CPatComitEvent();
                        Public.CPatComitEvent.ReadOne(iEventID, ref ComitEvent);
                       
                        Public.CPatentManagement Patent = new Public.CPatentManagement();
                        Public.CPatentManagement.ReadOne(ComitEvent.PatentID, ref Patent);
                       
                        if (b)//true-申請案一起放棄
                        {                                               
                            Patent.Status = int.Parse(cboStatus.SelectedValue.ToString());
                            Patent.StatusExplain = txtStatusExplain.Text;

                            DateTime dtCloseDate;
                            bool IsCloseDate = DateTime.TryParse(maskedTextBox_CloseDate.Text, out dtCloseDate);
                            if (IsCloseDate)
                            {
                                Patent.CloseDate = dtCloseDate;
                            }
                            else
                            {
                                Patent.CloseDate = DateTime.Now;
                            }
                            Patent.CloseCaus = txt_CloseCaus.Text;
                            Patent.LastModifyDateTime = DateTime.Now;
                            Patent.LastModifyWorker = Properties.Settings.Default.WorkerName;
                            Patent.Update();
                        }
                        
                        
                        DateTime dtFinishDate;
                        bool IsFinishDate = DateTime.TryParse(mskFinishDate.Text,out dtFinishDate);
                        if (IsFinishDate)
                        {
                            ComitEvent.FinishDate = dtFinishDate;
                        }
                        ComitEvent.Result = txt_Result.Text;                      
                        ComitEvent.Update();

                        cmf.dgViewMF.CurrentRow.Cells["FinishDate"].Value = ComitEvent.FinishDate;
                        cmf.dgViewMF.CurrentRow.Cells["Result"].Value = ComitEvent.Result;
                        cmf.dgViewMF.CurrentRow.Cells["DiffDueDate"].Value = 0;                        
                        DataTable dtControl = cmf.dt_ControlEvent;
                        dtControl.AcceptChanges();

                        break;
                    case 2://來函
                        Public.CPatNotifyEvent NotifyEvent = new Public.CPatNotifyEvent("PatNotifyEventID=" + iEventID.ToString());
                        NotifyEvent.SetCurrent(iEventID);
                        
                        Public.CPatentManagement Patent1 = new Public.CPatentManagement();
                        Public.CPatentManagement.ReadOne(NotifyEvent.PatentID, ref Patent1);
                       

                        if (b)
                        {
                            Patent1.Status = int.Parse(cboStatus.SelectedValue.ToString());
                            Patent1.StatusExplain = txtStatusExplain.Text;
                            Patent1.CloseDate = mskFinishDate.Text.Replace("/", "").Replace(":", "").Replace(" ", "") != "" ? DateTime.Parse(mskFinishDate.Text) : DateTime.Parse("1900/1/1");
                            Patent1.CloseCaus = txt_Result.Text;
                            Patent1.LastModifyWorker = Properties.Settings.Default.WorkerName;
                           
                            Patent1.Update();
                        }

                        DateTime dtFinishDate_Notify = new DateTime(1900, 1, 1);
                        bool IsFinishDate_Notify = DateTime.TryParse(mskFinishDate.Text,out dtFinishDate_Notify);
                        if (IsFinishDate_Notify)
                        {
                            NotifyEvent.FinishDate = dtFinishDate_Notify;
                        }

                        NotifyEvent.NotifyResult = txt_Result.Text;
                        NotifyEvent.Updata(iEventID);

                        cmf.dgViewMF.CurrentRow.Cells["FinishDate"].Value = NotifyEvent.FinishDate;
                        cmf.dgViewMF.CurrentRow.Cells["Result"].Value = NotifyEvent.NotifyResult;
                        cmf.dgViewMF.CurrentRow.Cells["DiffDueDate"].Value = 0;
                        DataTable dt_Control = cmf.dt_ControlEvent;
                        dt_Control.AcceptChanges();
                        break;
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
      
    }
}
