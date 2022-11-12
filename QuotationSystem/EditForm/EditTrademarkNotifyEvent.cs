using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.EditForm
{
    public partial class EditTrademarkNotifyEvent : Form
    {
        public EditTrademarkNotifyEvent()
        {
            InitializeComponent();
        }

        #region Property
        private int iTMNotifyEventID = -1;
        /// <summary>
        /// 商標來函 ID
        /// </summary>
        public int property_TMNotifyEventID
        {
            get { return iTMNotifyEventID; }
            set { iTMNotifyEventID = value; }
        }

        private int itrademark = -1;
        public int TrademarkID
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

        /// <summary>
        /// 登入者的名字
        /// </summary>
        public string WorkerName
        {
            get { return Properties.Settings.Default.WorkerName; }
        }

        //private int iOfficeRole = -1;
        /// <summary>
        /// 登入者的權限身份 1.員工 2.專利主管 3.商標主管 4.帳務主管 0.admin
        /// </summary>
        public int OfficeRole
        {
            get { return Properties.Settings.Default.OfficeRole; }

        }

        /// <summary>
        /// 記錄案件階段、描述是否有被異動
        /// </summary>
        public bool TrademarkChange
        {
            get; set;
        }

        /// <summary>
        /// 0:僅僅「處理結果」、「送件日期」、「委外日期」 欄位可編輯 ; 9:完整編輯事件記錄
        /// </summary>
        public string HomePageEvent
        {
            set {
                if (value == "0") {
                    comboBox_Statue.Enabled = false;
                    txt_StatusExplain.Enabled = false;
                    txt_Remark.Enabled = false;
                    comboBox_NotifyEventContent.Enabled = false;
                    maskedTextBox_NotifyComitDate.Enabled = false;
                    maskedTextBox_NotifyOfficerDate.Enabled = false;
                    maskedTextBox_OccurDate.Enabled = false;
                    maskedTextBox_AttorneyDueDate.Enabled = false;
                    maskedTextBox_DueDate.Enabled = false;
                    maskedTextBox_FinishDate.Enabled = false;
                    comboBox_WorkerKey.Enabled = false;
                    Combo_EAttorney.Enabled = false;
                    Combo_EAttorneyTransactor.Enabled = false;
                    //maskedTextBox_OutsourcingDate.Enabled = false;
                   // maskedTextBox_Notice.Enabled = false;
                }
            }
        }
        #endregion

        #region 資料集
        private DataTable dt_AttorneyT = new DataTable();
        /// <summary>
        /// 承辦事務所
        /// </summary>
        public DataTable DT_Attorney
        {
            get { return dt_AttorneyT; }
            set { dt_AttorneyT = value; }
        }

        private DataTable dt_AttLiaisonerT = new DataTable();
        /// <summary>
        /// 承辦事務所的連絡人
        /// </summary>
        public DataTable DT_AttLiaisoner
        {
            get { return dt_AttLiaisonerT; }
            set { dt_AttLiaisonerT = value; }
        }

        private DataTable dt_WorkerT = new DataTable();
        /// <summary>
        /// 事件承辦人
        /// </summary>
        public DataTable DT_Worker
        {
            get { return dt_WorkerT; }
            set { dt_WorkerT = value; }
        }

        private DataTable dt_TMStatusT = new DataTable();
        /// <summary>
        /// 商標案件階段
        /// </summary>
        public DataTable DT_StatusT
        {
            get { return dt_TMStatusT; }
            set { dt_TMStatusT = value; }
        }

        private DataTable dt_TMNotifyDueT = new DataTable();
        /// <summary>
        /// 商標事件內容
        /// </summary>
        public DataTable DT_NotifyDue
        {
            get { return dt_TMNotifyDueT; }
            set { dt_TMNotifyDueT = value; }
        } 
        #endregion

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region private void EditTrademarkNotifyEvent_Load(object sender, EventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditTrademarkNotifyEvent_Load(object sender, EventArgs e)
        {
            Public.CQueryDropT.GetAttorneyDrop(ref dt_AttorneyT);
            attorneyTBindingSource.DataSource = dt_AttorneyT;

            Public.CTrademarkNotifyEvent CCTrademarkNotifyEvent = new Public.CTrademarkNotifyEvent();
            Public.CTrademarkNotifyEvent.ReadOne(iTMNotifyEventID, ref CCTrademarkNotifyEvent);
            itrademark = CCTrademarkNotifyEvent.TrademarkID;

            BindingSource();

            button1_Click(null, null);

            comboBox_NotifyEventContent.Text = CCTrademarkNotifyEvent.NotifyEventContent;

            comboBox_EventType.Text = CCTrademarkNotifyEvent.EventType;

            maskedTextBox_NotifyComitDate.Text = CCTrademarkNotifyEvent.NotifyComitDate.HasValue ? CCTrademarkNotifyEvent.NotifyComitDate.Value.ToString("yyyy-MM-dd") : "";

            maskedTextBox_OccurDate.Text = CCTrademarkNotifyEvent.OccurDate.HasValue ? CCTrademarkNotifyEvent.OccurDate.Value.ToString("yyyy-MM-dd") : "";

            maskedTextBox_NotifyOfficerDate.Text = CCTrademarkNotifyEvent.NotifyOfficerDate.HasValue ? CCTrademarkNotifyEvent.NotifyOfficerDate.Value.ToString("yyyy-MM-dd") : "";

            maskedTextBox_DueDate.Text = CCTrademarkNotifyEvent.DueDate.HasValue ? CCTrademarkNotifyEvent.DueDate.Value.ToString("yyyy-MM-dd") : "";

            maskedTextBox_NoticeDate.Text = CCTrademarkNotifyEvent.NoticeDate.HasValue ? CCTrademarkNotifyEvent.NoticeDate.Value.ToString("yyyy-MM-dd") : "";

            //maskedTextBox_CustomerAuthorizationDate.Text = CCTrademarkNotifyEvent.CustomerAuthorizationDate.HasValue ? CCTrademarkNotifyEvent.CustomerAuthorizationDate.Value.ToString("yyyy-MM-dd") : "";

            maskedTextBox_OutsourcingDate.Text = CCTrademarkNotifyEvent.OutsourcingDate.HasValue ? CCTrademarkNotifyEvent.OutsourcingDate.Value.ToString("yyyy-MM-dd") : "";

            maskedTextBox_FinishDate.Text = CCTrademarkNotifyEvent.FinishDate.HasValue ? CCTrademarkNotifyEvent.FinishDate.Value.ToString("yyyy-MM-dd") : "";

            maskedTextBox_AttorneyDueDate.Text = CCTrademarkNotifyEvent.AttorneyDueDate.HasValue ? CCTrademarkNotifyEvent.AttorneyDueDate.Value.ToString("yyyy-MM-dd") : "";

            txt_Result.Text = CCTrademarkNotifyEvent.Result;

            txt_Remark.Text = CCTrademarkNotifyEvent.Remark;

            if (CCTrademarkNotifyEvent.AttorneyKey.HasValue)
            {
                Combo_EAttorney.SelectedValue = CCTrademarkNotifyEvent.AttorneyKey;
            }

            if (CCTrademarkNotifyEvent.ALiaisonerKey.HasValue)
            {
                Combo_EAttorneyTransactor.SelectedValue = CCTrademarkNotifyEvent.ALiaisonerKey;
            }

            if (CCTrademarkNotifyEvent.WorkerKey.HasValue)
            {
                comboBox_WorkerKey.SelectedValue = CCTrademarkNotifyEvent.WorkerKey;
            }

            attorneyTBindingSource.Filter = "CountrySymbol ='" + CountrySymbol + "'";

            SetOfficeRole();
        } 
        #endregion

        private void BindingSource()
        {
            Public.CQueryDropT.GetTrademarkStatusDrop(ref dt_TMStatusT);
            tMStatusTBindingSource.DataSource = dt_TMStatusT;

            Public.CQueryDropT.GetAttorneyDrop(ref dt_AttorneyT);
            attorneyTBindingSource.DataSource = dt_AttorneyT;
            Combo_EAttorney.DataSource = attorneyTBindingSource;
            Combo_EAttorney.DisplayMember = "AttorneyFirm";
            Combo_EAttorney.ValueMember = "AttorneyKey";

            Public.CQueryDropT.GetWorkerDrop(ref dt_WorkerT);
            workerQuitNBindingSource.DataSource = dt_WorkerT;

            if (comboBox_Statue.SelectedValue != null)
            {
                Public.CQueryDropT.GetTrademarkNotifyDueDrop(CountrySymbol, (int)comboBox_Statue.SelectedValue, ref dt_TMNotifyDueT);
            }
            else
            {
                Public.CQueryDropT.GetTrademarkNotifyDueDrop(CountrySymbol, 0, ref dt_TMNotifyDueT);
            }
            bindingSource_NotifyContent.DataSource= dt_TMNotifyDueT;
            comboBox_NotifyEventContent.DataSource = bindingSource_NotifyContent;
            comboBox_NotifyEventContent.ValueMember = "TMNotifyDueID";
            comboBox_NotifyEventContent.DisplayMember = "NotifyContent";
        }


        #region OfficeRole()
        public void SetOfficeRole()
        {
            switch (OfficeRole)
            {
                case 1:
                case 2:
                    //label12.Visible = true;
                    but_SingOff.Visible = false;
                    if (!string.IsNullOrEmpty(txt_SingcCode.Text))
                    {
                        but_OK.Visible = false;
                    }
                    else
                    {
                        but_OK.Visible = true;
                    }
                    break;
                case 3:
                case 0:
                    //label12.Visible = false;
                    but_SingOff.Visible = true;
                    if (txt_SingcCode.Text.Contains(WorkerName))
                    {
                        but_SingOff.Text = "取消簽核";
                        but_SingOff.Tag = "Cancel";
                    }
                    else
                    {
                        but_SingOff.Text = "簽核";
                        but_SingOff.Tag = "Sing";
                    }
                    break;


            }
        }
        #endregion

        #region ============but_SingOff_Click===============
        private void but_SingOff_Click(object sender, EventArgs e)
        {
            US.SingCode sing = new LawtechPTSystem.US.SingCode();
            sing.ShowDialog();
            if (sing.IsSuccess)
            {
                txt_SingcCode.Text = SingOffName(WorkerName);
                //txt_SingCodeStatus.Text = "";
                if (but_SingOff.Tag.ToString() == "Sing")
                {
                    but_SingOff.Tag = "Cancel";
                    but_SingOff.Text = "取消簽核";
                    txt_SingCodeStatus.Text += "★" + WorkerName + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "簽核\r\n";
                }
                else
                {
                    but_SingOff.Text = "簽核";
                    but_SingOff.Tag = "Sing";
                    txt_SingCodeStatus.Text += "Ⅹ" + WorkerName + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "取消簽核\r\n";
                }
            }

        }
        #endregion

        #region ===========SingOffName==============
        private string SingOffName(string Name)
        {
            string ReValue = "";
            if (but_SingOff.Tag.ToString() == "Sing")//簽核
            {
                txt_SingcCode.Text += ";" + Name;
            }
            else//取消簽核
            {
                txt_SingcCode.Text = txt_SingcCode.Text.Replace(Name, "");
            }

            string[] sSingName = txt_SingcCode.Text.Split(';');

            for (int iLenght = 0; iLenght < sSingName.Length; iLenght++)
            {
                if (sSingName[iLenght] != "")
                {
                    ReValue += sSingName[iLenght];
                    if (iLenght < sSingName.Length - 1)
                    {
                        ReValue += ";";
                    }
                }
            }

            return ReValue;
        }
        #endregion

        private void but_OK_Click(object sender, EventArgs e)
        {
            if (comboBox_NotifyEventContent.Text.Trim() == "")
            {
                MessageBox.Show("事件內容不得為空白", "提示訊息");
                comboBox_NotifyEventContent.Focus();
                return;
            }


            Public.CTrademarkNotifyEvent AddCTrademarkNotifyEvent = new Public.CTrademarkNotifyEvent();
            Public.CTrademarkNotifyEvent.ReadOne(iTMNotifyEventID, ref AddCTrademarkNotifyEvent);


            AddCTrademarkNotifyEvent.NotifyEventContent = comboBox_NotifyEventContent.Text;

            //本所期限
            DateTime dtAttorneyDueDate;
            bool IsAttorneyDueDate = DateTime.TryParse(maskedTextBox_AttorneyDueDate.Text, out dtAttorneyDueDate);
            if (IsAttorneyDueDate)
            {
                AddCTrademarkNotifyEvent.AttorneyDueDate = dtAttorneyDueDate;
            }
            else
            {
                AddCTrademarkNotifyEvent.AttorneyDueDate = null;

            }

            //事件發生日
            DateTime dtNotifyComitDate;
            bool IsNotifyComitDate = DateTime.TryParse(maskedTextBox_NotifyComitDate.Text, out dtNotifyComitDate);
            if (IsNotifyComitDate)
            {
                AddCTrademarkNotifyEvent.NotifyComitDate = dtNotifyComitDate;
            }
            else
            {
                AddCTrademarkNotifyEvent.NotifyComitDate = null;
            }


            //官方送達日
            DateTime dtOccurDate;
            bool IsOccurDate = DateTime.TryParse(maskedTextBox_OccurDate.Text, out dtOccurDate);
            if (IsOccurDate)
            {
                AddCTrademarkNotifyEvent.OccurDate = dtOccurDate;

            }
            else
            {
                AddCTrademarkNotifyEvent.OccurDate = null;
            }


            //官方發文日
            DateTime dtNotifyOfficerDate;
            bool IsNotifyOfficerDate = DateTime.TryParse(maskedTextBox_NotifyOfficerDate.Text, out dtNotifyOfficerDate);
            if (IsNotifyOfficerDate)
            {
                AddCTrademarkNotifyEvent.NotifyOfficerDate = dtNotifyOfficerDate;
            }
            else
            {
                AddCTrademarkNotifyEvent.NotifyOfficerDate = null;
            }

            //官方期限
            DateTime dtDueDate;
            bool IsDueDate = DateTime.TryParse(maskedTextBox_DueDate.Text, out dtDueDate);
            if (IsDueDate)
            {
                AddCTrademarkNotifyEvent.DueDate = dtDueDate;
            }
            else
            {
                AddCTrademarkNotifyEvent.DueDate = null;
            }


            //送件日期
            DateTime dtNoticeDate;
            bool IsNoticeDate = DateTime.TryParse(maskedTextBox_NoticeDate.Text, out dtNoticeDate);
            if (IsNoticeDate)
            {
                AddCTrademarkNotifyEvent.NoticeDate = dtNoticeDate;
            }
            else
            {
                AddCTrademarkNotifyEvent.NoticeDate = null;
            }



            //委外日期
            DateTime dtOutsourcingDate;
            bool IsOutsourcingDate = DateTime.TryParse(maskedTextBox_OutsourcingDate.Text, out dtOutsourcingDate);
            if (IsOutsourcingDate)
            {
                AddCTrademarkNotifyEvent.OutsourcingDate = dtOutsourcingDate;
            }
            else
            {
                AddCTrademarkNotifyEvent.OutsourcingDate = null;
            }


            //完成日期
            DateTime dtFinishDate;
            bool IsFinishDate = DateTime.TryParse(maskedTextBox_FinishDate.Text, out dtFinishDate);
            if (IsFinishDate)
            {
                AddCTrademarkNotifyEvent.FinishDate = dtFinishDate;
            }
            else
            {
                AddCTrademarkNotifyEvent.FinishDate = null;
            }

            //AddCTrademarkNotifyEvent.EventType = comboBox_EventType.Text;


            AddCTrademarkNotifyEvent.Result = txt_Result.Text;


            AddCTrademarkNotifyEvent.Remark = txt_Remark.Text;


            if (comboBox_WorkerKey.SelectedValue != null)
            {
                AddCTrademarkNotifyEvent.WorkerKey = (int)comboBox_WorkerKey.SelectedValue;

            }
            else
            {
                AddCTrademarkNotifyEvent.WorkerKey = -1;

            }

            if (Combo_EAttorney.SelectedValue != null)
            {
                AddCTrademarkNotifyEvent.AttorneyKey = (int)Combo_EAttorney.SelectedValue;

            }
            else
            {
                AddCTrademarkNotifyEvent.AttorneyKey = null;
            }

            if (Combo_EAttorneyTransactor.SelectedValue != null)
            {
                AddCTrademarkNotifyEvent.ALiaisonerKey = (int)Combo_EAttorneyTransactor.SelectedValue;

            }
            else
            {
                AddCTrademarkNotifyEvent.ALiaisonerKey = null;
            }

            AddCTrademarkNotifyEvent.LastModifyWorker = Properties.Settings.Default.WorkerName;

            AddCTrademarkNotifyEvent.Update();

            Public.PublicForm Forms = new Public.PublicForm();
            //Forms.TrademarkMF.dt_TrademarkNotifyEventT.AcceptChanges();


            #region 更新案件階段
            Public.CTrademarkManagement Tm = new Public.CTrademarkManagement();
            Public.CTrademarkManagement.ReadOne(TrademarkID, ref Tm);
         if (TrademarkChange   )
            {
                Tm.Status = comboBox_Statue.SelectedValue != null ? (int)comboBox_Statue.SelectedValue : -1;
                Tm.StatusExplain = txt_StatusExplain.Text;
                Tm.LastModifyWorker = Properties.Settings.Default.WorkerName;
                Tm.Update();
            }           
            #endregion

            #region Forms.TrademarkMF
            if (Forms.TrademarkMF != null)
            {
                DataRow drTrademark = Forms.TrademarkMF.dt_TrademarkManagementT.Rows.Find(TrademarkID);
                if (TrademarkChange && drTrademark != null)
                {
                    drTrademark["StatusName"] = comboBox_Statue.Text;
                    drTrademark["StatusExplain"] = Tm.StatusExplain;
                    drTrademark["LastModifyWorker"] = Properties.Settings.Default.WorkerName;
                    Forms.TrademarkMF.dt_TrademarkManagementT.AcceptChanges();
                }

                DataRow dr = Forms.TrademarkMF.dt_TrademarkNotifyEventT.Rows.Find(property_TMNotifyEventID);
                if (dr != null)
                {
                    DataRow drV = Public.CTrademarkPublicFunction.GetTrademarkEvent(property_TMNotifyEventID.ToString());
                    dr.ItemArray = drV.ItemArray;
                    dr.AcceptChanges();
                }
            }
            #endregion

            MessageBox.Show("修改成功", "提示訊息");
            this.Close();
        }

        private void maskedTextBox_NotifyComitDate_DoubleClick(object sender, EventArgs e)
        {
            MaskedTextBox mtb = (MaskedTextBox)sender;
            DateTime dt;
            bool IsSuccess = DateTime.TryParse(mtb.Text, out dt);
            if (!IsSuccess)
            {
                mtb.Text = DateTime.Now.ToString("yyyy-MM-dd");
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
                    DateTime dt = new DateTime();
                    bool IsSuccess = DateTime.TryParse(mtb.Text, out dt);
                    if (IsSuccess)
                    {
                        Calculation.CurrentDate = dt;
                    }
                    else
                    {
                        Calculation.CurrentDate = null;
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
            Public.CTrademarkManagement Tm = new Public.CTrademarkManagement();
            Public.CTrademarkManagement.ReadOne(TrademarkID, ref Tm);
            comboBox_Statue.SelectedValue = Tm.Status;
            txt_StatusExplain.Text = Tm.StatusExplain;

            TrademarkChange = false;
        }

        private void comboBox_Statue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Statue.SelectedValue != null)
            {
                Public.CQueryDropT.GetTrademarkNotifyDueDrop(CountrySymbol, (int)comboBox_Statue.SelectedValue, ref dt_TMNotifyDueT);
            }
            else
            {
                dt_TMNotifyDueT.Rows.Clear();
            }

            TrademarkChange = true;
      
    }

        private void EditTrademarkNotifyEvent_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.Utility.NuLockRecordAuth("TrademarkNotifyEventT", "TMNotifyEventID=" + property_TMNotifyEventID.ToString());
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "ToolStripMenuItem_All":

                    attorneyTBindingSource.Filter = "";
                    break;
                case "ToolStripMenuItem_CurrentCountry":
                    if (!string.IsNullOrEmpty(CountrySymbol.Trim()))
                    {
                        attorneyTBindingSource.Filter = "CountrySymbol ='" + CountrySymbol + "'";
                    }
                    break;
            }
        }

        #region  private void Combo_EAttorney_SelectedIndexChanged(object sender, EventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Combo_EAttorney_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Combo_EAttorney.SelectedValue != null)
            {
                Public.CQueryDropT.GetAttLiaisonerDrop((int)Combo_EAttorney.SelectedValue, ref dt_AttLiaisonerT);

                if (attLiaisonerTBindingSource.DataSource == null)
                {
                    attLiaisonerTBindingSource.DataSource = dt_AttLiaisonerT;
                }
            }
        }
        #endregion

        private void Combo_EAttorney_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (Combo_EAttorney.SelectedValue != null)
            {
                Public.CQueryDropT.GetAttLiaisonerDrop((int)Combo_EAttorney.SelectedValue, ref dt_AttLiaisonerT);

                if (attLiaisonerTBindingSource.DataSource == null)
                {
                    attLiaisonerTBindingSource.DataSource = dt_AttLiaisonerT;
                }
            }
        }

        private void maskedTextBox_NotifyComitDate_Leave(object sender, EventArgs e)
        {
            MaskedTextBox mak = (MaskedTextBox)sender;
            Public.Utility.CheckMaskedtextbox(mak);
        }

        private void txt_StatusExplain_TextChanged(object sender, EventArgs e)
        {
            TrademarkChange = true;
        }
    
    }
}
