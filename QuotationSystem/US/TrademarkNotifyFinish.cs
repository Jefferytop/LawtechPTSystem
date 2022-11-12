using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.US
{
    /// <summary>
    /// 事件處理完成
    /// </summary>
    public partial class TrademarkNotifyFinish : Form
    {
        public TrademarkNotifyFinish()
        {
            InitializeComponent();
        }

        private int NotifyEventID = -1;
        /// <summary>
        /// 商標來函的PK
        /// </summary>
        public int TmNotifyEventID
        {
            get { return NotifyEventID; }
            set { NotifyEventID = value; }
        }


        private string strTableTypeName = "TM";
        /// <summary>
        /// TM:商標案     CO:異議案
        /// </summary>
        public string TableTypeName
        {
            get { return strTableTypeName; }
            set { strTableTypeName = value; }
        }


        private DataGridViewRow dgvr;
        /// <summary>
        /// dataGridView的Row
        /// </summary>
        public DataGridViewRow DGvr
        {
            get { return dgvr; }
            set { dgvr = value; }
        }

        private void TrademarkNotifyFinish_Load(object sender, EventArgs e)
        {
            if (TableTypeName != "CO")
            {
                Public.CTrademarkNotifyEvent notify = new Public.CTrademarkNotifyEvent();
                Public.CTrademarkNotifyEvent.ReadOne(NotifyEventID, ref notify);
              
                txt_NotifyEventContent.Text = notify.NotifyEventContent;
                maskedTextBox_NotifyComitDate.Text = notify.NotifyComitDate.HasValue ? notify.NotifyComitDate.Value.ToString("yyy/MM/dd") : "";
                maskedTextBox_DueDate.Text = notify.DueDate.HasValue ? notify.DueDate.Value.ToString("yyy/MM/dd") : "";
                maskedTextBox_OutsourcingDate.Text = notify.OutsourcingDate.HasValue ? notify.OutsourcingDate.Value.ToString("yyy/MM/dd") : "";
                maskedTextBox_FinishDate.Text = notify.FinishDate.HasValue ? notify.FinishDate.Value.ToString("yyy/MM/dd") : "";
                txt_Result.Text = notify.Result;
                txt_Remark.Text = notify.Remark;
            }
            else
            {
                Public.CTrademarkControversyNotifyEvent notify = new Public.CTrademarkControversyNotifyEvent("TMNotifyControversyEventID=" + NotifyEventID.ToString());

                notify.SetCurrent(NotifyEventID);
                txt_NotifyEventContent.Text = notify.NotifyEventContent;
                maskedTextBox_NotifyComitDate.Text = notify.NotifyComitDate.Year > 1900 ? notify.NotifyComitDate.ToString("yyy/MM/dd") : "";
                maskedTextBox_DueDate.Text = notify.DueDate.Year > 1900 ? notify.DueDate.ToString("yyy/MM/dd") : "";
                maskedTextBox_OutsourcingDate.Text = notify.OutsourcingDate.Year > 1900 ? notify.OutsourcingDate.ToString("yyy/MM/dd") : "";
                maskedTextBox_FinishDate.Text = notify.FinishDate.Year > 1900 ? notify.FinishDate.ToString("yyy/MM/dd") : "";
                txt_Result.Text = notify.Result;
                txt_Remark.Text = notify.Remark;
            }
        }

        private void maskedTextBox_OutsourcingDate_DoubleClick(object sender, EventArgs e)
        {
            MaskedTextBox mtb = (MaskedTextBox)sender;
            DateTime dt;
            bool IsSuccess = DateTime.TryParse(mtb.Text, out dt);
            if (!IsSuccess)
            {
                mtb.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        private void but_OK_Click(object sender, EventArgs e)
        {
            if (TableTypeName != "CO")
            {
                Public.CTrademarkNotifyEvent notify = new Public.CTrademarkNotifyEvent();
                Public.CTrademarkNotifyEvent.ReadOne(NotifyEventID, ref notify);

                DateTime dtOutsourcingDate;
                bool IsOutsourcingDate = DateTime.TryParse(maskedTextBox_OutsourcingDate.Text, out dtOutsourcingDate);
                if (IsOutsourcingDate)
                {
                    notify.OutsourcingDate = dtOutsourcingDate;
                }
                else
                {
                    notify.OutsourcingDate = null;
                }

                DateTime dtFinishDate;
                bool IsFinishDate = DateTime.TryParse(maskedTextBox_FinishDate.Text, out dtFinishDate);
                if (IsFinishDate)
                {
                    notify.FinishDate = dtFinishDate;
                }
                else
                {
                    notify.FinishDate = null;
                }

                notify.Result = txt_Result.Text;
                notify.Remark = txt_Remark.Text;
                notify.LastModifyWorker = Properties.Settings.Default.WorkerName;

                notify.Update();

                Public.PublicForm Forms = new Public.PublicForm();
                if (Forms.TrademarkControlEventList != null)
                {
                    DataRow dr = Forms.TrademarkControlEventList.dt_ControlEvent.Rows.Find(notify.TMNotifyEventID);
                    DataRow drV = Public.CTrademarkPublicFunction.GetTrademarkEventList(notify.TMNotifyEventID.ToString());
                    dr.ItemArray = drV.ItemArray;
                    dr.AcceptChanges();
                }

                if (Forms.MainFrom != null)
                {
                    Forms.MainFrom.GetTrademarkComitEventForWorker();
                }
            }
            else//異議案
            {
                Public.CTrademarkControversyNotifyEvent notify = new Public.CTrademarkControversyNotifyEvent("TMNotifyControversyEventID=" + NotifyEventID.ToString());
                notify.SetCurrent(NotifyEventID);

                DateTime dtOutsourcingDate;
                bool IsOutsourcingDate = DateTime.TryParse(maskedTextBox_OutsourcingDate.Text, out dtOutsourcingDate);
                if (IsOutsourcingDate)
                {
                    notify.OutsourcingDate = dtOutsourcingDate;
                }
                else
                {
                    notify.OutsourcingDate = new DateTime(1900, 1, 1);
                }

                DateTime dtFinishDate;
                bool IsFinishDate = DateTime.TryParse(maskedTextBox_FinishDate.Text, out dtFinishDate);
                if (IsFinishDate)
                {
                    notify.FinishDate = dtFinishDate;
                }
                else
                {
                    notify.FinishDate = new DateTime(1900, 1, 1);
                }

                notify.Result = txt_Result.Text;
                notify.Remark = txt_Remark.Text;
                notify.LastModifyWorker = Properties.Settings.Default.WorkerKEY;
                notify.LastModifyDate = DateTime.Now;
                notify.Updata(NotifyEventID);

                dgvr.Cells["FinishDate"].Value = notify.FinishDate;
                dgvr.Cells["Result"].Value = notify.Result;
                dgvr.Cells["DiffDueDate"].Value = DBNull.Value;
            }

          

            MessageBox.Show("更新成功", "提示訊息");
            this.Close();
        }

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TrademarkNotifyFinish_KeyDown(object sender, KeyEventArgs e)
        {
            Public.Utility.ControlTab(e);
        }

        private void maskedTextBox_FinishDate_Leave(object sender, EventArgs e)
        {
            MaskedTextBox mak = (MaskedTextBox)sender;
            Public.Utility.CheckMaskedtextbox(mak);
        }
    }
}
