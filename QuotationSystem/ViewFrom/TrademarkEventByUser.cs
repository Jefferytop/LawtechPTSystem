using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LawtechPTSystem.ViewFrom
{
    public partial class TrademarkEventByUser : Form
    {
        public TrademarkEventByUser()
        {
            InitializeComponent();

            GridView_PatComit.AutoGenerateColumns = false;
            Public.DynamicGridViewColumn.GetGridColum(ref GridView_PatComit);
        }

        #region  ============property============
        private int _TrademarkID = -1;
        /// <summary>
        /// PatentID
        /// </summary>
        public int property_TrademarkID
        {
            get
            {
                return _TrademarkID;

            }
            set
            {
                _TrademarkID = value;
            }
        }

        private int _Userkey = -1;
        /// <summary>
        /// 事件承辦人
        /// </summary>
        public int property_UserKey
        {
            get
            {
                return _Userkey;

            }
            set
            {
                _Userkey = value;
            }
        }
        #endregion

        #region ===========資料集===========
        private DataTable dt_TmComitEventT = new DataTable();
        /// <summary>
        /// PatComitEventT 事件記錄
        /// </summary>
        public DataTable DT_TmComitEventT
        {
            get
            {
                return dt_TmComitEventT;
            }

        }
        #endregion

        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TrademarkEventByUser_Load(object sender, EventArgs e)
        {
            SetBindingSource();
            ControlBindingTMNotify();
        }

        #region 設定BindingSource的來源 private void SetBindingSource()
        /// <summary>
        /// 設定BindingSource的來源
        /// </summary>
        private void SetBindingSource()
        {
            if (dt_TmComitEventT.Columns.Count == 0)
            {
                Public.CTrademarkPublicFunction.GetTrademarkEventByUser(property_TrademarkID.ToString(), property_UserKey, ref dt_TmComitEventT);
            }
            TrademarkComitEventTBindingSource.DataSource = dt_TmComitEventT;
        }
        #endregion

        #region ControlBindingTMNotify
        public void ControlBindingTMNotify()
        {

            txt_NotifyEventContent.DataBindings.Clear();
            txt_NotifyEventContent.DataBindings.Add("Text", TrademarkComitEventTBindingSource, "NotifyEventContent", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_WorkerKey.DataBindings.Clear();
            txt_WorkerKey.DataBindings.Add("Text", TrademarkComitEventTBindingSource, "EmployeeName", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_NotifyResult.DataBindings.Clear();
            txt_NotifyResult.DataBindings.Add("Text", TrademarkComitEventTBindingSource, "Result", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_NotifyRemark.DataBindings.Clear();
            txt_NotifyRemark.DataBindings.Add("Text", TrademarkComitEventTBindingSource, "Remark", true, DataSourceUpdateMode.OnValidation, "", "");

            maskedTextBox_NotifyComitDate.DataBindings.Clear();
            maskedTextBox_NotifyComitDate.DataBindings.Add("Text", TrademarkComitEventTBindingSource, "NotifyComitDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_NotifyOfficerDate.DataBindings.Clear();
            maskedTextBox_NotifyOfficerDate.DataBindings.Add("Text", TrademarkComitEventTBindingSource, "NotifyOfficerDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_OccurDate.DataBindings.Clear();
            maskedTextBox_OccurDate.DataBindings.Add("Text", TrademarkComitEventTBindingSource, "OccurDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_DueDate.DataBindings.Clear();
            maskedTextBox_DueDate.DataBindings.Add("Text", TrademarkComitEventTBindingSource, "DueDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_Notice.DataBindings.Clear();
            maskedTextBox_Notice.DataBindings.Add("Text", TrademarkComitEventTBindingSource, "NoticeDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_CustomerAuthorizationDate.DataBindings.Clear();
            maskedTextBox_CustomerAuthorizationDate.DataBindings.Add("Text", TrademarkComitEventTBindingSource, "CustomerAuthorizationDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            mtb_OutsourcingDate.DataBindings.Clear();
            mtb_OutsourcingDate.DataBindings.Add("Text", TrademarkComitEventTBindingSource, "OutsourcingDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_FinishDate.DataBindings.Clear();
            maskedTextBox_FinishDate.DataBindings.Add("Text", TrademarkComitEventTBindingSource, "FinishDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_AttorneyDueDate.DataBindings.Clear();
            maskedTextBox_AttorneyDueDate.DataBindings.Add("Text", TrademarkComitEventTBindingSource, "AttorneyDueDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

        }
        #endregion

        private void toolStripButton_ExcelEvent_Click(object sender, EventArgs e)
        {
            try
            {
                Public.DLL dll = new Public.DLL();
                Task task = dll.WriteToCSV(GridView_PatComit);
            }
            catch
            {
                MessageBox.Show("匯出CSV失敗");
            }
        }

        private void linkLabel_ComitResult_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel link = (LinkLabel)sender;
            US.PopMemo pop;
            switch (link.Name)
            {
                case "linkLabel_NotifyResult":
                    pop = new LawtechPTSystem.US.PopMemo(txt_NotifyResult, true, link.Text);
                    break;
                case "linkLabel_ComintRemark":
                    pop = new LawtechPTSystem.US.PopMemo(txt_NotifyRemark, true, link.Text);
                    break;
            }
        }

    }
}
