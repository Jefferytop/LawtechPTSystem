using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.EditForm
{
    public partial class EditNotifyEvent : Form
    {
        BindingSource bs_EventContent;

        private int iPatNotifyEventID = -1;
        /// <summary>
        /// 委辦 ID
        /// </summary>
        public int NotifyEventID
        {
            get { return iPatNotifyEventID; }
            set { iPatNotifyEventID = value; }
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

        private string sCountry = "";
        /// <summary>
        /// 國別
        /// </summary>
        public string Country
        {
            get { return sCountry; }
            set { sCountry = value; }
        }

        public EditNotifyEvent()
        {
            InitializeComponent();
        }

     

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void EditNotifyEvent_Load(object sender, EventArgs e)
        {
            this.workerTAllTableAdapter.Fill(this.qS_DataSet.WorkerTAll);
          

            Public.CPatNotifyEvent edit = new LawtechPTSystemByFirm.Public.CPatNotifyEvent("PatNotifyEventID=" + iPatNotifyEventID.ToString());
            edit.SetCurrent(iPatNotifyEventID);

            txt_EventContent.Text = edit.NotifyEventContent;
            Combo_EAttorney.SelectedValue = edit.AttorneyKey;
            Combo_EAttorneyTransactor.SelectedValue = edit.ALiaisonerKey;

            Combo_EClientWorker.SelectedValue = edit.WorkerKey;

            maskedTextBox_ComitDate.Text = edit.NotifyComitDate.ToString("yyyy/MM/dd") != "1900/01/01" ? edit.NotifyComitDate.ToString("yyyy/MM/dd") : "";
            maskedTextBox_OccurDate.Text = edit.OccurDate.ToString("yyyy/MM/dd") != "1900/01/01" ? edit.OccurDate.ToString("yyyy/MM/dd") : "";
            maskedTextBox_OfficerDate.Text = edit.NotifyOfficerDate.ToString("yyyy/MM/dd") != "1900/01/01" ? edit.NotifyOfficerDate.ToString("yyyy/MM/dd") : "";
            maskedTextBox_NotifyDueDate.Text = edit.DueDate.ToString("yyyy/MM/dd") != "1900/01/01" ? edit.DueDate.ToString("yyyy/MM/dd") : "";
            maskedTextBox_NotifyAttorneyDueDate.Text = edit.NotifyAttorneyDueDate.ToString("yyyy/MM/dd") != "1900/01/01" ? edit.NotifyAttorneyDueDate.ToString("yyyy/MM/dd") : "";
            maskedTextBox_NotifyStartDate.Text = edit.NotifyStartDate.ToString("yyyy/MM/dd") != "1900/01/01" ? edit.NotifyStartDate.ToString("yyyy/MM/dd") : "";
            maskedTextBox_NotifyFinishDate.Text = edit.FinishDate.ToString("yyyy/MM/dd") != "1900/01/01" ? edit.FinishDate.ToString("yyyy/MM/dd") : "";
            txt_NotifyResult.Text = edit.NotifyResult ;
            txt_NotifyRemark.Text = edit.NotifyRemark;
            txt_NotifyRespond.Text = edit.NotifyRespond;

            bs_EventContent = new BindingSource();
            radioButton1_CheckedChanged(null, null);
            comboBox_EventContent.Text = edit.NotifyEventContent;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {                

                Public.PublicForm Forms = new Public.PublicForm();
                Public.CPatNotifyContent NotifyContent = new Public.CPatNotifyContent("Country='" + sCountry + "' order by Sort");
                DataTable dt_Content = NotifyContent.GetDataTable();
                bs_EventContent.DataSource = dt_Content;
                comboBox_EventContent.DisplayMember = "NotifyContent";
                comboBox_EventContent.ValueMember = "NotifyContentID";
                comboBox_EventContent.DataSource = bs_EventContent;

                for (int i = 0; i < dt_Content.Rows.Count; i++)
                {
                    comboBox_EventContent.AutoCompleteCustomSource.Add(dt_Content.Rows[i]["NotifyContent"].ToString());
                }

                comboBox_EventContent.Text = "";
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
              
                Public.PublicForm Forms = new Public.PublicForm();
                Public.CPatNotifyDue due = new Public.CPatNotifyDue("Country='" + sCountry + "' order by Sort");
                DataTable dt_Content = due.GetDataTable();
                bs_EventContent.DataSource = dt_Content;
                comboBox_EventContent.DisplayMember = "NotifyContent";
                comboBox_EventContent.ValueMember = "PatNotifyDueID";
                comboBox_EventContent.DataSource = bs_EventContent;

                for (int i = 0; i < dt_Content.Rows.Count; i++)
                {
                    comboBox_EventContent.AutoCompleteCustomSource.Add(dt_Content.Rows[i]["NotifyContent"].ToString());
                }
                comboBox_EventContent.SelectedValue = -1;


            }
        }

        private void but_OK_Click(object sender, EventArgs e)
        {

            if (radioButton1.Checked == true)
            {
                #region 一般來函

                if (comboBox_EventContent.Text != "")
                {
                    try
                    {
                        Public.CPatNotifyEvent event0 = new Public.CPatNotifyEvent("PatNotifyEventID="+iPatNotifyEventID.ToString());
                        event0.SetCurrent(iPatNotifyEventID);

                        event0.NotifyEventContent = txt_EventContent.Text;
                        event0.AttorneyKey = Combo_EAttorney.SelectedValue != null ? (int)Combo_EAttorney.SelectedValue : -1;
                        event0.ALiaisonerKey = Combo_EAttorneyTransactor.SelectedValue != null ? (int)Combo_EAttorneyTransactor.SelectedValue : -1;
                        event0.WorkerKey = Combo_EClientWorker.SelectedValue != null ? (int)Combo_EClientWorker.SelectedValue : -1;

                        DateTime dtNotifyComitDate;
                        bool IsNotifyComitDate = DateTime.TryParse(maskedTextBox_ComitDate.Text, out dtNotifyComitDate);
                        if (IsNotifyComitDate) event0.NotifyComitDate = dtNotifyComitDate;
                        else event0.NotifyComitDate = new DateTime(1900, 1, 1);

                        DateTime dtOccurDate;
                        bool IsOccurDate = DateTime.TryParse(maskedTextBox_OccurDate.Text, out dtOccurDate);
                        if (IsOccurDate) event0.OccurDate = dtOccurDate;
                        else event0.OccurDate = new DateTime(1900, 1, 1);

                        DateTime dtNotifyOfficerDate;
                        bool IsNotifyOfficerDate = DateTime.TryParse(maskedTextBox_OfficerDate.Text, out dtNotifyOfficerDate);
                        if (IsNotifyOfficerDate) event0.NotifyOfficerDate = dtNotifyOfficerDate;
                        else event0.NotifyOfficerDate = new DateTime(1900, 1, 1);

                        DateTime dtNotifyAttorneyDueDate;
                        bool IsNotifyAttorneyDueDate = DateTime.TryParse(maskedTextBox_NotifyAttorneyDueDate.Text, out dtNotifyAttorneyDueDate);
                        if (IsNotifyAttorneyDueDate) event0.NotifyAttorneyDueDate = dtNotifyAttorneyDueDate;
                        else event0.NotifyAttorneyDueDate = new DateTime(1900, 1, 1);

                        DateTime dtDueDate;
                        bool IsDueDate = DateTime.TryParse(maskedTextBox_NotifyDueDate.Text, out dtDueDate);
                        if (IsDueDate) event0.DueDate = dtDueDate;
                        else event0.DueDate = new DateTime(1900, 1, 1);

                        DateTime dtNotifyStartDate;
                        bool IsNotifyStartDate = DateTime.TryParse(maskedTextBox_NotifyStartDate.Text, out dtNotifyStartDate);
                        if (IsNotifyStartDate) event0.NotifyStartDate = dtNotifyStartDate;
                        else event0.NotifyStartDate = new DateTime(1900, 1, 1);

                        DateTime dtFinishDate;
                        bool IsFinishDate = DateTime.TryParse(maskedTextBox_NotifyFinishDate.Text, out dtFinishDate);
                        if (IsFinishDate) event0.FinishDate = dtFinishDate;
                        else event0.FinishDate = new DateTime(1900, 1, 1);


                        event0.NotifyResult = txt_NotifyResult.Text;
                        event0.PatentID = iPatentID;
                        event0.NotifyRespond = txt_NotifyRespond.Text;
                        event0.NotifyRemark = txt_NotifyRemark.Text;
                        event0.LastModifyDate = DateTime.Now;
                        event0.Updata(iPatNotifyEventID);

                        Public.PublicForm Forms = new Public.PublicForm();

                      
                      
                        MessageBox.Show("修改來函成功", "提示訊息", MessageBoxButtons.OK);

                        /*
                        //提醒訊息
                        if (radioButton1.Checked)
                        {
                            if (comboBox_EventContent.SelectedValue != null)
                            {
                                Public.CPatNotifyContent notify = new Public.CPatNotifyContent("NotifyContentID=" + comboBox_EventContent.SelectedValue.ToString());
                                notify.SetCurrent((int)comboBox_EventContent.SelectedValue);
                                if (notify.Note != "")
                                {
                                    MessageBox.Show(notify.Note, "提示訊息", MessageBoxButtons.OK);
                                }
                            }
                        }
                        else
                        {
                            if (comboBox_EventContent.SelectedValue != null)
                            {
                                Public.CPatNotifyDue Due = new Public.CPatNotifyDue("PatNotifyDueID=" + comboBox_EventContent.SelectedValue.ToString());
                                Due.SetCurrent((int)comboBox_EventContent.SelectedValue);
                                if (Due.Note != "")
                                {
                                    MessageBox.Show(Due.Note, "提示訊息", MessageBoxButtons.OK);
                                }
                            }
                        }
                        */
                        this.Close();

                    }
                    catch (System.Exception EX)
                    {
                        MessageBox.Show(EX.Message.Replace("'", ""));
                    }
                }
                else
                {

                    MessageBox.Show("請輸入來函內容", "提示訊息", MessageBoxButtons.OK);
                }

                #endregion
            }
            else if (radioButton3.Checked == true)
            {
                #region 期限來函
                if (comboBox_EventContent.Text != "")
                {
                    try
                    {

                        Public.PublicForm Forms = new Public.PublicForm();

                        Public.CPatNotifyEvent event0 = new Public.CPatNotifyEvent("PatNotifyEventID=" + iPatNotifyEventID.ToString());
                        event0.SetCurrent(iPatNotifyEventID);

                        event0.NotifyEventContent = comboBox_EventContent.Text;

                        event0.AttorneyKey = Combo_EAttorney.SelectedValue != null ? (int)Combo_EAttorney.SelectedValue : -1;
                        event0.ALiaisonerKey = Combo_EAttorneyTransactor.SelectedValue != null ? (int)Combo_EAttorneyTransactor.SelectedValue : -1;
                        event0.WorkerKey = Combo_EClientWorker.SelectedValue != null ? (int)Combo_EClientWorker.SelectedValue : -1;

                        DateTime dtNotifyComitDate;
                        bool IsNotifyComitDate = DateTime.TryParse(maskedTextBox_ComitDate.Text, out dtNotifyComitDate);
                        if (IsNotifyComitDate) event0.NotifyComitDate = dtNotifyComitDate;
                        else event0.NotifyComitDate = new DateTime(1900, 1, 1);

                        DateTime dtOccurDate;
                        bool IsOccurDate = DateTime.TryParse(maskedTextBox_OccurDate.Text, out dtOccurDate);
                        if (IsOccurDate) event0.OccurDate = dtOccurDate;
                        else event0.OccurDate = new DateTime(1900, 1, 1);

                        DateTime dtNotifyOfficerDate;
                        bool IsNotifyOfficerDate = DateTime.TryParse(maskedTextBox_OfficerDate.Text, out dtNotifyOfficerDate);
                        if (IsNotifyOfficerDate) event0.NotifyOfficerDate = dtNotifyOfficerDate;
                        else event0.NotifyOfficerDate = new DateTime(1900, 1, 1);

                        DateTime dtNotifyAttorneyDueDate;
                        bool IsNotifyAttorneyDueDate = DateTime.TryParse(maskedTextBox_NotifyAttorneyDueDate.Text, out dtNotifyAttorneyDueDate);
                        if (IsNotifyAttorneyDueDate) event0.NotifyAttorneyDueDate = dtNotifyAttorneyDueDate;
                        else event0.NotifyAttorneyDueDate = new DateTime(1900, 1, 1);

                        DateTime dtDueDate;
                        bool IsDueDate = DateTime.TryParse(maskedTextBox_NotifyDueDate.Text, out dtDueDate);
                        if (IsDueDate) event0.DueDate = dtDueDate;
                        else event0.DueDate = new DateTime(1900, 1, 1);

                        DateTime dtNotifyStartDate;
                        bool IsNotifyStartDate = DateTime.TryParse(maskedTextBox_NotifyStartDate.Text, out dtNotifyStartDate);
                        if (IsNotifyStartDate) event0.NotifyStartDate = dtNotifyStartDate;
                        else event0.NotifyStartDate = new DateTime(1900, 1, 1);

                        DateTime dtFinishDate;
                        bool IsFinishDate = DateTime.TryParse(maskedTextBox_NotifyFinishDate.Text, out dtFinishDate);
                        if (IsFinishDate) event0.FinishDate = dtFinishDate;
                        else event0.FinishDate = new DateTime(1900, 1, 1);



                        event0.NotifyResult = txt_NotifyResult.Text;
                        event0.PatentID = iPatentID;
                        event0.NotifyRespond = txt_NotifyRespond.Text;
                        event0.NotifyRemark = txt_NotifyRemark.Text;
                        event0.LastModifyDate = DateTime.Now;
                        event0.LastModifyWorker = Properties.Settings.Default.WorkerKEY;
                        event0.Updata(iPatNotifyEventID);


                       



                        //Forms.OvertrueMF.upDataSet(6);

                        MessageBox.Show("修改來函成功", "提示訊息", MessageBoxButtons.OK);
                        this.Close();

                    }
                    catch (System.Exception EX)
                    {
                        MessageBox.Show(EX.Message.Replace("'", ""));
                    }
                }
                else
                {

                    MessageBox.Show("請輸入來函內容", "提示訊息", MessageBoxButtons.OK);
                }
                #endregion
            }


        }

        private void Combo_EAttorney_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Combo_EAttorney.SelectedValue != null)
            {
               // this.attLiaisonerTTableAdapter.FillByWindows(this.dataSet_Drop.AttLiaisonerT, (int)Combo_EAttorney.SelectedValue,(int)Public.WindowType.PatContract);
            }
        }

        private void comboBox_EventContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_EventContent.SelectedValue != null)
            {
                if (radioButton1.Checked)
                {
                    //Public.CPatNotifyContent comit = new LawtechPTSystemByFirm.Public.CPatNotifyContent(" NotifyContentID=" + comboBox_EventContent.SelectedValue.ToString());
                    //comit.SetCurrent((int)comboBox_EventContent.SelectedValue);
                    //comboBox_Statue.SelectedValue = comit.Status;
                    //txt_StatusExplain.Text = DateTime.Now.ToShortDateString() + "  " + comit.NotifyContent;
                }
                else
                {
                    Public.CPatNotifyDue comit = new LawtechPTSystemByFirm.Public.CPatNotifyDue(" PatNotifyDueID=" + comboBox_EventContent.SelectedValue.ToString());
                    comit.SetCurrent((int)comboBox_EventContent.SelectedValue);
                    //comboBox_Statue.SelectedValue = comit.Status;
                    //txt_StatusExplain.Text = DateTime.Now.ToShortDateString() + "  " + comit.NotifyContent;
                    txt_NotifyRespond.Text = comit.Answer;
                }
            }
        }

        private void maskedTextBox_ComitDate_DoubleClick(object sender, EventArgs e)
        {
            MaskedTextBox mtb = (MaskedTextBox)sender;
            DateTime dt;
            bool IsSuccess = DateTime.TryParse(mtb.Text, out dt);
            if (!IsSuccess)
            {
                mtb.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }
        }
    }
}
