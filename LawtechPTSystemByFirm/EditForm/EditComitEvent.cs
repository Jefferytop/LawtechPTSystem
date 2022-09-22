using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.EditForm
{
    public partial class EditComitEvent : Form
    {
        public EditComitEvent()
        {
            InitializeComponent();
        }

        private int iPatComitEventID = -1;
        /// <summary>
        /// 事件記錄 ID
        /// </summary>
        public int PatComitEventID
        {
            get { return iPatComitEventID; }
            set { iPatComitEventID = value; }
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

        private int iPatentID = -1;
        /// <summary>
        /// 申請案ID
        /// </summary>
        public int PatentID
        {
            get { return iPatentID; }
            set { iPatentID = value; }
        }

        private int iOfficeRole = -1;
        /// <summary>
        /// 登入者的權限身份 1.員工 2.專利主管 3.商標主管 0.admin
        /// </summary>
        public int OfficeRole
        {
            get { return Properties.Settings.Default.OfficeRole; }
           
        }

      
        /// <summary>
        /// 登入者的名字
        /// </summary>
        public string WorkerName
        {
            get { return Properties.Settings.Default.WorkerName; }           
        }

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region but_OK_Click
        /// <summary>
        /// 確定按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_OK_Click(object sender, EventArgs e)
        {
            but_OK.Enabled = false;

            Public.CPatComitEvent edit = new LawtechPTSystemByFirm.Public.CPatComitEvent();
            Public.CPatComitEvent.ReadOne(iPatComitEventID, ref edit);
           
            edit.EventContent = txt_EventContent.Text;

            edit.WorkerKey = Combo_EClientWorker.SelectedValue != null ? (int)Combo_EClientWorker.SelectedValue : -1;
            edit.AttorneyKey = Combo_EAttorney.SelectedValue != null ? (int)Combo_EAttorney.SelectedValue : -1;
            edit.ALiaisonerKey = Combo_EAttorneyTransactor.SelectedValue != null ? (int)Combo_EAttorneyTransactor.SelectedValue : -1;

            DateTime dtCreateDate ;
            bool IsCreateDate = DateTime.TryParse(maskedTextBox_CreateDate.Text, out dtCreateDate);
            if (IsCreateDate) edit.CreateDate = dtCreateDate;
            else edit.CreateDate = null;


            DateTime dtOccurDate ;
           bool IsOccurDate= DateTime.TryParse(maskedTextBox_EventContent.Text, out dtOccurDate);
           if (IsOccurDate) edit.OccurDate = dtOccurDate;
           else edit.OccurDate = null;

            DateTime dtOfficerDate;
           bool IsOfficerDate= DateTime.TryParse(maskedTextBox_OfficerDate.Text, out dtOfficerDate);
           if (IsOfficerDate) edit.OfficerDate = dtOfficerDate;
           else edit.OfficerDate =null;

            DateTime dtDueDate;
           bool IsDueDate= DateTime.TryParse(maskedTextBox_DueDate.Text, out dtDueDate);
            if(IsDueDate) edit.DueDate = dtDueDate;    
            else  edit.DueDate =null;

            DateTime dtofficeDueDate ;
            bool IsOfficeDueDate = DateTime.TryParse(maskedTextBox_OfficeDueDate.Text, out dtofficeDueDate);
            if (IsOfficeDueDate) edit.OfficeDueDate = dtofficeDueDate;
            else edit.OfficeDueDate = null;
           

            DateTime dtStartDate ;
            bool IsStartDate= DateTime.TryParse(maskedTextBox_StartDate.Text, out dtStartDate);
            if (IsStartDate) edit.StartDate = dtStartDate;
            else edit.StartDate =null;

            DateTime dtComitDate ;
            bool IsComitDate= DateTime.TryParse(maskedTextBox_ComitDate.Text, out dtComitDate);
            if (IsComitDate) edit.ComitDate = dtComitDate;
            else edit.ComitDate = null;

            DateTime dtFinishDate ;
            bool IsFinishDate= DateTime.TryParse(maskedTextBox_FinishDate.Text, out dtFinishDate);
            if (IsFinishDate) edit.FinishDate = dtFinishDate;
            else edit.FinishDate =null;
                      
           
            edit.LastModifyWorker = Properties.Settings.Default.WorkerName;
            edit.Remark = txtRemark.Text;
            edit.Result = txt_Result.Text;
            edit.SingCode = txt_SingcCode.Text;
            edit.SingCodeStatus = txt_SingCodeStatus.Text + txt_SingCodeStatus_N.Text;
            edit.Update();

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            #region 專利申請案基本資料
            if (Forms.PatListMF != null)
            {
                Public.CPatentManagement patent = new LawtechPTSystemByFirm.Public.CPatentManagement();
                Public.CPatentManagement.ReadOne(PatentID, ref patent);

                patent.Status = comboBox_Statue.SelectedValue != null ? (int)comboBox_Statue.SelectedValue : -1;
                patent.StatusExplain = txt_StatusExplain.Text;
                patent.Update();

                DataRow drPatent = Forms.PatListMF.DT_PatentList.Rows.Find(PatentID);
                #region DataRow drPatent
                if (drPatent != null)
                {
                    drPatent["Status"] = patent.Status;
                    drPatent["StatusName"] = comboBox_Statue.Text;
                    drPatent["StatusExplain"] = txt_StatusExplain.Text;
                    drPatent.AcceptChanges();
                }
                #endregion

                DataRow dr = Forms.PatListMF.DT_PatComitEventT.Rows.Find(iPatComitEventID);
                #region DataSet_Pat.V_PatEventRow dr
                if (dr != null)
                {
                    DataRow drV = Public.CPatentPublicFunction.GetPatentComitEventDataRow(edit.PatComitEventID.ToString());
                    dr.ItemArray = drV.ItemArray;
                    dr.AcceptChanges();
                }
                #endregion
            } 
            #endregion

            #region 專利事件管制表           
            if (Forms.PATControlEventList != null)
            {
                DataRow dr = Forms.PATControlEventList.dt_CurrentControlEventDataRow;
                if (dr != null)
                {
                    DataRow drV = Public.CPatentPublicFunction.GetV_PATControlEventList(edit.PatentID.ToString(), edit.PatComitEventID.ToString());
                    dr.ItemArray = drV.ItemArray;
                    dr.AcceptChanges();
                }
            } 
            #endregion

            this.DialogResult = DialogResult.OK;
            MessageBox.Show("修改成功", "提示訊息", MessageBoxButtons.OK);
            but_OK.Enabled = true;
            this.Close();
        }
        #endregion

        #region EditComitEvent_Load
        private void EditComitEvent_Load(object sender, EventArgs e)
        {                       
            this.patStatusT_DropTableAdapter.Fill(this.qS_DataSet._PatStatusT_Drop);
            this.patComitContentTTableAdapter.Fill(this.dataSet_Drop.PatComitContentT, CountrySymbol);

            this.attorneyTTableAdapter.Fill(this.dataSet_Drop.AttorneyT);
            this.worker_QuitNTableAdapter.Fill(this.qS_DataSet.Worker_QuitN);

            attorneyTBindingSource.Filter = "CountrySymbol ='" + CountrySymbol + "'";
        

            Public.CPatentManagement patent = new LawtechPTSystemByFirm.Public.CPatentManagement();
            Public.CPatentManagement.ReadOne(PatentID, ref patent);
           
            comboBox_Statue.SelectedValue = patent.Status;
            txt_StatusExplain.Text = patent.StatusExplain;

            Public.CPatComitEvent edit = new LawtechPTSystemByFirm.Public.CPatComitEvent();
            Public.CPatComitEvent.ReadOne(iPatComitEventID, ref edit);
            
            txt_EventContent.Text = edit.EventContent;
            if (edit.WorkerKey.HasValue)
            {
                Combo_EClientWorker.SelectedValue = edit.WorkerKey;
            }
            if (edit.AttorneyKey.HasValue)
            {
                Combo_EAttorney.SelectedValue = edit.AttorneyKey;
            }

            if (edit.ALiaisonerKey.HasValue)
            {
                Combo_EAttorneyTransactor.SelectedValue = edit.ALiaisonerKey;
            }
           

            maskedTextBox_EventContent.Text =edit.OccurDate.HasValue? edit.OccurDate.Value.ToString("yyyy/MM/dd"):"";
            maskedTextBox_OfficerDate.Text = edit.OfficerDate.HasValue ? edit.OfficerDate.Value.ToString("yyyy/MM/dd") : "";
            maskedTextBox_DueDate.Text = edit.DueDate.HasValue ? edit.DueDate.Value.ToString("yyyy/MM/dd") : "";
            maskedTextBox_StartDate.Text = edit.StartDate.HasValue ? edit.StartDate.Value.ToString("yyyy/MM/dd") : "";
            maskedTextBox_ComitDate.Text = edit.ComitDate.HasValue ? edit.ComitDate.Value.ToString("yyyy/MM/dd") : "";
            maskedTextBox_FinishDate.Text = edit.FinishDate.HasValue ? edit.FinishDate.Value.ToString("yyyy/MM/dd") : "";
            maskedTextBox_OfficeDueDate.Text = edit.OfficeDueDate.HasValue ? edit.OfficeDueDate.Value.ToString("yyyy/MM/dd") : "";
            maskedTextBox_CreateDate.Text = edit.CreateDate.HasValue ? edit.CreateDate.Value.ToString("yyyy/MM/dd") : "";
            txtRemark.Text = edit.Remark;
            txt_Result.Text = edit.Result;
            txt_SingcCode.Text = edit.SingCode;
            txt_SingCodeStatus.Text = edit.SingCodeStatus;
            SetOfficeRole(); 

        }
        #endregion

        #region OfficeRole()
        public void SetOfficeRole()
        {
            switch (OfficeRole)
            {
                case 1:
                case 3:
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
                case 2:
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
            US.SingCode sing = new LawtechPTSystemByFirm.US.SingCode();
            sing.ShowDialog();
            if (sing.IsSuccess)
            {
                txt_SingcCode.Text = SingOffName(WorkerName);
                
                if (but_SingOff.Tag.ToString() == "Sing")
                {
                    but_SingOff.Tag = "Cancel";
                    but_SingOff.Text = "取消簽核";
                    txt_SingCodeStatus_N.Text = "★" + WorkerName + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "簽核\r\n";
                }
                else
                {
                    but_SingOff.Text = "簽核";
                    but_SingOff.Tag = "Sing";
                    txt_SingCodeStatus_N.Text = "Ⅹ" + WorkerName + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "取消簽核\r\n";
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

        private void Combo_EAttorney_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Combo_EAttorney.SelectedValue != null)
            {
                this.attLiaisonerTTableAdapter.FillByWindows(this.dataSet_Drop.AttLiaisonerT, (int)Combo_EAttorney.SelectedValue,(int)Public.WindowType.PatContract);
            }
        }

        private void maskedTextBox_EventContent_DoubleClick(object sender, EventArgs e)
        {
            MaskedTextBox mtb = (MaskedTextBox)sender;
            DateTime dt;
            bool IsSuccess = DateTime.TryParse(mtb.Text, out dt);
            if (!IsSuccess)
            {
                mtb.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }
        }

        private void comboBox_Statue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Statue.SelectedValue != null)
            {
                this.patComitContentTTableAdapter.FillBy(this.dataSet_Drop.PatComitContentT, CountrySymbol, (int)comboBox_Statue.SelectedValue);
            }
            else
            {
                this.dataSet_Drop.PatComitContentT.Rows.Clear();
            }
        }

        #region contextMenuStrip_ForDate_ItemClicked
        private void contextMenuStrip_ForDate_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ContextMenuStrip content = (ContextMenuStrip)sender;
            MaskedTextBox mtb = content.SourceControl as MaskedTextBox;

            contextMenuStrip_ForDate.Visible = false;

            switch (e.ClickedItem.Name)
            {
                case "ToolStripMenuItem_Calculation":

                    US.CalculationDate Calculation = new LawtechPTSystemByFirm.US.CalculationDate();
                    DateTime dt;
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
        #endregion

        private void EditComitEvent_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.Utility.NuLockRecordAuth("PatComitEventT", "PatComitEventID=" + PatComitEventID);
        }

        #region contextMenuStrip1_ItemClicked
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "ToolStripMenuItem_All":
                    checkBox_All.Checked = true;
                    attorneyTBindingSource.Filter = "";
                    break;
                case "ToolStripMenuItem_CurrentCountry":
                    if (CountrySymbol != "")
                    {
                        checkBox_All.Checked = false;
                        attorneyTBindingSource.Filter = "CountrySymbol ='" + CountrySymbol + "'";
                    }
                    break;
            }
        }
        #endregion

        private void txt_EventContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txt_EventContent.SelectedValue != null)
            {
                Public.CPatComitContent comit = new LawtechPTSystemByFirm.Public.CPatComitContent();
                Public.CPatComitContent.ReadOne((int)txt_EventContent.SelectedValue, ref comit);

                comboBox_Statue.SelectedValue = comit.Status;
                txt_StatusExplain.Text = DateTime.Now.ToShortDateString() + "  " + comit.ComitContent;
            }
        }

        private void contextMenuStrip_EAttorneyTransactor_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Tag != null && !string.IsNullOrEmpty(e.ClickedItem.Tag.ToString()))
            {
                if (Combo_EAttorney.SelectedValue != null)
                {
                    this.dataSet_Drop.AttLiaisonerT.Rows.Clear();
                    this.attLiaisonerTTableAdapter.FillByWindows(this.dataSet_Drop.AttLiaisonerT, (int)Combo_EAttorney.SelectedValue, int.Parse(e.ClickedItem.Tag.ToString()));
                }
            }
        }

       
    }
}
