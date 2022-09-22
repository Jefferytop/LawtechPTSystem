using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace LawtechPTSystemByFirm.EditForm
{
    public partial class CopyTrademarkControversy : Form
    {
        public CopyTrademarkControversy()
        {
            InitializeComponent();
        }

        private int iTrademarkControversyID = -1;
        /// <summary>
        /// 商標異議案 ID
        /// </summary>
        public int TrademarkControversyID
        {
            get { return iTrademarkControversyID; }
            set { iTrademarkControversyID = value; }
        }


        private void EditTrademarkControversy_Load(object sender, EventArgs e)
        {
            this.delegateTypeTableAdapter.Fill(this.dataSet_Drop.DelegateType);
            this.countryT_DropTableAdapter.Fill(this.qS_DataSet.CountryT_Drop);
            //this.attorneyTTableAdapter.FillByCountry(this.dataSet_Drop.AttorneyT, cb_Country.SelectedValue.ToString());
            this.attorneyTTableAdapter1.Fill(this.dataSet_Attorney.AttorneyT);  
            this.workerTAllTableAdapter.Fill(this.qS_DataSet.WorkerTAll);
            this.tMStatusTTableAdapter.Fill(this.dataSet_Drop.TMStatusT);

            this.trademarkStyleTTableAdapter.Fill(this.dataSet_Drop.TrademarkStyleT);
            this.trademarkTypeTTableAdapter.FillByObjection(this.dataSet_Drop.TrademarkTypeT);
            this.applicantT_DropTableAdapter.Fill(this.qS_DataSet.ApplicantT_Drop);


            Public.CTrademarkControversyManagement CCTrademarkManagement = new Public.CTrademarkControversyManagement();
            Public.CTrademarkControversyManagement.ReadOne(TrademarkControversyID, ref CCTrademarkManagement);
          
            txt_TrademarkNo.Text = CCTrademarkManagement.TrademarkNo;
            txt_TrademarOriginalNo.Text = CCTrademarkManagement.TrademarOriginalNo;
            txt_TrademarkName.Text = CCTrademarkManagement.TrademarkName;
            txt_DisagreementNo.Text = CCTrademarkManagement.DisagreementNo;
            
            if (CCTrademarkManagement.ApplicantKey.HasValue)
            {
                cb_ApplicantKey.SelectedValue = CCTrademarkManagement.ApplicantKey;
            }
            cb_Country.SelectedValue = CCTrademarkManagement.CountrySymbol;
            cb_StyleName.Text = CCTrademarkManagement.StyleName;
            cb_TypeName.Text = CCTrademarkManagement.TMTypeName;
            txt_ApplicantNames.Text = CCTrademarkManagement.ApplicantNames;
            txt_ApplicantKeys.Text = CCTrademarkManagement.ApplicantKeys;

            if (CCTrademarkManagement.Status.HasValue)
            {
                cb_Status.SelectedValue = CCTrademarkManagement.Status;
            }
            txt_StatusExplain.Text = CCTrademarkManagement.StatusExplain;

            if (CCTrademarkManagement.WorkerKey.HasValue)
            {
                cb_WorkerKey.SelectedValue = CCTrademarkManagement.WorkerKey;
            }

            maskedTextBox_ObjectionDate.Text = CCTrademarkManagement.ObjectionDate.HasValue ? CCTrademarkManagement.ObjectionDate.Value.ToString("yyyy/MM/dd") : "";
            maskedTextBox_EntrustDate.Text = CCTrademarkManagement.EntrustDate.HasValue ? CCTrademarkManagement.EntrustDate.Value.ToString("yyyy/MM/dd") : "";
            if (CCTrademarkManagement.OutsourcingAttorney.HasValue)
            {
                cb_OutsourcingAttorney.SelectedValue = CCTrademarkManagement.OutsourcingAttorney;
            }

            if (CCTrademarkManagement.OutsourcingAttorneyWorker.HasValue)
            {
                cb_OutsourcingAttorneyWorker.SelectedValue = CCTrademarkManagement.OutsourcingAttorneyWorker;
            }
            txt_OutsourcingTrademarkNo.Text = CCTrademarkManagement.OutsourcingTrademarkNo;

            maskedTextBox_ApplicationDate.Text = CCTrademarkManagement.ApplicationDate.HasValue ? CCTrademarkManagement.ApplicationDate.Value.ToString("yyyy/MM/dd") : "";
            txt_ApplicationNo.Text = CCTrademarkManagement.ApplicationNo;

            maskedTextBox_RegistrationDate.Text = CCTrademarkManagement.RegistrationDate.HasValue ? CCTrademarkManagement.RegistrationDate.Value.ToString("yyyy/MM/dd") : "";
            txt_RegistrationNo.Text = CCTrademarkManagement.RegistrationNo;
            maskedTextBox_LawDate.Text = CCTrademarkManagement.LawDate.HasValue ? CCTrademarkManagement.LawDate.Value.ToString("yyyy/MM/dd") : "";
            
            txt_RegisterProduct.Text = CCTrademarkManagement.RegisterProduct;

            maskedTextBox_CloseDate.Text = CCTrademarkManagement.CloseDate.HasValue ? CCTrademarkManagement.CloseDate.Value.ToString("yyyy/MM/dd") : "";
            txt_Remarks.Text = CCTrademarkManagement.Remarks;
            txt_PicPath.Text = CCTrademarkManagement.PicPath;
            txt_TrademarkOvertureName.Text = CCTrademarkManagement.TrademarkOvertureName;

            txt_ObjectionPeople.Text = CCTrademarkManagement.ObjectionPeople;
            txt_ObjectionNo.Text = CCTrademarkManagement.ObjectionNo;
            txt_ObjectionClass.Text = CCTrademarkManagement.ObjectionClass;
            txt_ObjectionContent.Text = CCTrademarkManagement.ObjectionContent;
            txt_ObjectionTrademarkName.Text = CCTrademarkManagement.ObjectionTrademarkName;

            txt_ObjectionRegistrationNo.Text = CCTrademarkManagement.ObjectionRegistrationNo;
            txt_ObjectionApplicationNo.Text = CCTrademarkManagement.ObjectionApplicationNo;
            txt_ObjectionNoticeNo.Text = CCTrademarkManagement.ObjectionNoticeNo;

            mask_ObjectionApplicationDate.Text = CCTrademarkManagement.ObjectionApplicationDate.HasValue ? CCTrademarkManagement.ObjectionApplicationDate.Value.ToString("yyyy/MM/dd") : "";
            mask_ObjectionNoticeDate.Text = CCTrademarkManagement.ObjectionNoticeDate.HasValue ? CCTrademarkManagement.ObjectionNoticeDate.Value.ToString("yyyy/MM/dd") : "";
            masked_ObjectionRegistrationDate.Text = CCTrademarkManagement.ObjectionRegistrationDate.HasValue ? CCTrademarkManagement.ObjectionRegistrationDate.Value.ToString("yyyy/MM/dd") : "";
            maskedTextBox_ObjectionDueDate.Text = CCTrademarkManagement.ObjectionDueDate.HasValue ? CCTrademarkManagement.ObjectionDueDate.Value.ToString("yyyy/MM/dd") : "";
            
            txt_ObjectionPicPath.Text = CCTrademarkManagement.ObjectionPicPath;

            comboBox_DelegateType.SelectedValue = CCTrademarkManagement.DelegateType == -1 ? 1 : CCTrademarkManagement.DelegateType;
            comboBox_DelegateType_SelectedIndexChanged(comboBox_DelegateType, null);

            //本所自行辦理
            chb_IsBySelf.Checked = CCTrademarkManagement.IsBySelf.HasValue ? CCTrademarkManagement.IsBySelf.Value : false;

            if (CCTrademarkManagement.DelegateType == 1)//申請人直接委託
            {
                txt_MainCustomer.Text = txt_ApplicantNames.Text;
                txt_MainCustomerRefNo.Text = CCTrademarkManagement.MainCustomerRefNo;

                if (CCTrademarkManagement.MainCustomerTransactor.HasValue)
                {
                    cb_MainCustomerLiaisoner.SelectedValue = CCTrademarkManagement.MainCustomerTransactor;
                }

                if (!chb_IsBySelf.Checked)
                {
                    if (CCTrademarkManagement.OutsourcingAttorney.HasValue)
                    {
                        cb_OutsourcingAttorney.SelectedValue = CCTrademarkManagement.OutsourcingAttorney;
                    }
                    txt_OutsourcingTrademarkNo.Text = CCTrademarkManagement.OutsourcingTrademarkNo;
                    if (CCTrademarkManagement.OutsourcingAttorneyWorker != -1)
                    {
                        this.attLiaisonerTTableAdapter.Fill(this.dataSet_Drop.AttLiaisonerT, (int)cb_OutsourcingAttorney.SelectedValue);

                        if (CCTrademarkManagement.OutsourcingAttorneyWorker.HasValue)
                        {
                            cb_OutsourcingAttorneyWorker.SelectedValue = CCTrademarkManagement.OutsourcingAttorneyWorker;
                        }
                    }
                }
            }
            else//複代委託
            {
                if (CCTrademarkManagement.MainCustomer.HasValue)
                {
                    comboBox_MainCustomer.SelectedValue = CCTrademarkManagement.MainCustomer;
                }
                txt_MainCustomerRefNo.Text = CCTrademarkManagement.MainCustomerRefNo;

                if (CCTrademarkManagement.MainCustomerTransactor.HasValue)
                {
                    cb_MainCustomerLiaisoner.SelectedValue = CCTrademarkManagement.MainCustomerTransactor;
                }

                if (!chb_IsBySelf.Checked)
                {
                    if (CCTrademarkManagement.OutsourcingAttorney.HasValue)
                    {
                        cb_OutsourcingAttorney.SelectedValue = CCTrademarkManagement.OutsourcingAttorney;
                    }
                    txt_OutsourcingTrademarkNo.Text = CCTrademarkManagement.OutsourcingTrademarkNo;

                    if (CCTrademarkManagement.OutsourcingAttorneyWorker != -1)
                    {
                        this.attLiaisonerTTableAdapter.Fill(this.dataSet_Drop.AttLiaisonerT, (int)cb_OutsourcingAttorney.SelectedValue);
                        if (CCTrademarkManagement.OutsourcingAttorneyWorker.HasValue)
                        {
                            cb_OutsourcingAttorneyWorker.SelectedValue = CCTrademarkManagement.OutsourcingAttorneyWorker;
                        }
                    }
                }
            }
            maskedTextBox_OutsourcingDate.Text = CCTrademarkManagement.OutsourcingDate.HasValue ? CCTrademarkManagement.OutsourcingDate.Value.ToString("yyyy/MM/dd") : "";

            Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
            pictureBox1.ImageLocation = dll.TrademarkControversyFolderRoot + "\\" + txt_PicPath.Text;
            pictureBox2.ImageLocation = dll.TrademarkControversyFolderRoot + "\\" + txt_ObjectionPicPath.Text;

           
        }

        #region linkLabel1_LinkClicked
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileInfo file = new FileInfo(openFileDialog1.FileName);

                txt_NewPicture.Text = openFileDialog1.FileName;

                pictureBox1.ImageLocation = txt_NewPicture.Text;
            }
        }
        #endregion

        #region comboBox_DelegateType_SelectedIndexChanged
        private void comboBox_DelegateType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (cb.SelectedValue.ToString() == "2")
            {

                groupBox2.Text = "主要委託人(複代)";
                txt_MainCustomer.Visible = false;
                comboBox_MainCustomer.Visible = true;
                chb_IsBySelf.Checked = false;

                if (comboBox_MainCustomer.SelectedValue != null)
                {
                    List<Public.CAttLiaisoner> catt = new  List<LawtechPTSystemByFirm.Public.CAttLiaisoner>();
                    Public.CAttLiaisoner.ReadList(ref catt, "AttorneyKey=" + comboBox_MainCustomer.SelectedValue.ToString());
                   
                }

                cb_MainCustomerLiaisoner.DataSource = attLiaisonerTBindingSource1;
                cb_MainCustomerLiaisoner.DisplayMember = "Liaisoner";
                cb_MainCustomerLiaisoner.ValueMember = "ALiaisonerKey";

                txt_OutsourcingTrademarkNo.Text = "";

            }
            else
            {


                //同申請人
                groupBox1.Enabled = true;
                chb_IsBySelf.Checked = true;

                groupBox2.Text = "主要委託人(同申請人)";
                txt_MainCustomer.Visible = true;
                comboBox_MainCustomer.Visible = false;
                txt_MainCustomer.Text = txt_ApplicantNames.Text;

                cb_MainCustomerLiaisoner.DataSource = liaisonerTOnlineBindingSource;
                cb_MainCustomerLiaisoner.DisplayMember = "Liaisoner";
                cb_MainCustomerLiaisoner.ValueMember = "LiaisonerKey";

                //this.liaisonerTOnlineTableAdapter.FillByWindow(this.qS_DataSet.LiaisonerTOnline, (int)Combo_Applicant.SelectedValue, (int)Public.WindowType.PatContract);
                if (txt_ApplicantKeys.Text != "")
                {
                    GetLiaisonerTOnline(txt_ApplicantKeys.Text);
                }
            }
        }
        #endregion

        #region GetLiaisonerTOnline
        /// <summary>
        /// 取得多家申請人的聯絡窗口 
        /// </summary>
        /// <param name="ApplicantKey"></param>
        private void GetLiaisonerTOnline(string ApplicantKey)
        {
            string strSQL = string.Format(@"SELECT          - 1 AS LiaisonerKey, '' AS Liaisoner
UNION
SELECT          LiaisonerKey, Liaisoner
FROM              LiaisonerT
WHERE          (ApplicantKey in ({0}) ) and Quit<>1 ", ApplicantKey);
            Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
            dll.FetchDataTable(strSQL, this.qS_DataSet.LiaisonerTOnline);

        }
        #endregion

        #region cb_OutsourcingAttorney_SelectedIndexChanged
        private void cb_OutsourcingAttorney_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_OutsourcingAttorney.SelectedValue != null)
            {
                this.attLiaisonerTTableAdapter1.FillByWindow(this.dataSet_Attorney.AttLiaisonerT, (int)cb_OutsourcingAttorney.SelectedValue, (int)Public.WindowType.TMContract);
            }
        }
        #endregion

        #region chb_IsBySelf_CheckedChanged
        private void chb_IsBySelf_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;

            cb_OutsourcingAttorney.Enabled = cb_OutsourcingAttorneyWorker.Enabled = txt_OutsourcingTrademarkNo.Enabled = maskedTextBox_OutsourcingDate.Enabled = !cb.Checked;

            txt_OutsourcingTrademarkNo.Text = "";
            maskedTextBox_OutsourcingDate.Text = "";
        }
        #endregion

        #region comboBox_MainCustomer_SelectedIndexChanged
        private void comboBox_MainCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_DelegateType.SelectedValue.ToString() == "2")
            {
                if (comboBox_MainCustomer.SelectedValue != null)
                {
                    List<Public.CAttLiaisoner> catt = new List<LawtechPTSystemByFirm.Public.CAttLiaisoner>();
                    Public.CAttLiaisoner.ReadList(ref catt, string.Format(" AttorneyKey={0} and Quit<>1  ", comboBox_MainCustomer.SelectedValue.ToString()));
                  
                    attLiaisonerTBindingSource1.DataSource = catt;
                }
            }
            else
            {
                if (txt_ApplicantKeys.Text != "")
                    GetLiaisonerTOnline(txt_ApplicantKeys.Text);
            }
        }
        #endregion

        #region maskedTextBox_ApplicationDate_DoubleClick
        private void maskedTextBox_ApplicationDate_DoubleClick(object sender, EventArgs e)
        {
            MaskedTextBox mtb = (MaskedTextBox)sender;
            DateTime dt;
            bool IsSuccess = DateTime.TryParse(mtb.Text, out dt);
            if (!IsSuccess)
            {
                mtb.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }
        }
        #endregion

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
                    DateTime dt = new DateTime(1900, 1, 1);
                    bool IsSuccess = DateTime.TryParse(mtb.Text, out dt);
                    if (IsSuccess)
                    {
                        Calculation.CurrentDate = dt;
                    }
                    else
                    {
                        Calculation.CurrentDate = new DateTime(1900, 1, 1);
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

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileInfo file = new FileInfo(openFileDialog1.FileName);

                txt_ObjectionPicPathNew.Text = openFileDialog1.FileName;

                pictureBox2.ImageLocation = txt_ObjectionPicPathNew.Text;
            }
        }

        #region but_OK_Click
        private void but_OK_Click(object sender, EventArgs e)
        {

            if (txt_TrademarkNo.Text.Trim() == "")
            {
                MessageBox.Show("【本所案號】不得為空白", "提示訊息");
                return;
            }


            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            DataSet_TrademarkControversy.TrademarkControversyManagementTRow dr = Forms.TrademarkControversyMF.dt_TrademarkControversyManagementT.FindByTrademarkControversyID(TrademarkControversyID);

            Public.CTrademarkControversyManagement AddCTrademarkManagement = new Public.CTrademarkControversyManagement();
            Public.CTrademarkControversyManagement.ReadOne(TrademarkControversyID, ref AddCTrademarkManagement);


            string OriginalTrademarkNo = AddCTrademarkManagement.TrademarkNo;

            //不等於原始的案號
            if (OriginalTrademarkNo.Trim() != txt_TrademarkNo.Text.Trim())
            {
                bool isExit = false;
                AddCTrademarkManagement.CheckValueExist("TrademarkNo", txt_TrademarkNo.Text, ref isExit, false);
                if (isExit)
                {
                    MessageBox.Show("【本所案號】不得為重覆，請重新修改", "提示訊息");
                    return;
                }
            }


            AddCTrademarkManagement.TrademarkNo = txt_TrademarkNo.Text;
            dr["TrademarkNo"] = AddCTrademarkManagement.TrademarkNo;

            AddCTrademarkManagement.TrademarOriginalNo = txt_TrademarOriginalNo.Text;
            dr["TrademarOriginalNo"] = AddCTrademarkManagement.TrademarOriginalNo;

            AddCTrademarkManagement.TrademarkName = txt_TrademarkName.Text;
            dr["TrademarkName"] = AddCTrademarkManagement.TrademarkName;

            AddCTrademarkManagement.DisagreementNo = txt_DisagreementNo.Text;
            dr["DisagreementNo"] = AddCTrademarkManagement.DisagreementNo;

            AddCTrademarkManagement.TrademarkOvertureName = txt_TrademarkOvertureName.Text;
            dr["TrademarkOvertureName"] = AddCTrademarkManagement.TrademarkOvertureName;

            AddCTrademarkManagement.ApplicantNames = txt_ApplicantNames.Text;
            dr["ApplicantNames"] = AddCTrademarkManagement.ApplicantNames;

            AddCTrademarkManagement.ApplicantKeys = txt_ApplicantKeys.Text;
            dr["ApplicantKeys"] = AddCTrademarkManagement.ApplicantKeys;

            AddCTrademarkManagement.ApplicantKey = cb_ApplicantKey.SelectedValue != null ? (int)cb_ApplicantKey.SelectedValue : -1;
            dr["ApplicantKey"] = AddCTrademarkManagement.ApplicantKey;

            AddCTrademarkManagement.CountrySymbol = cb_Country.SelectedValue != null ? cb_Country.SelectedValue.ToString() : "";
            dr["CountrySymbol"] = AddCTrademarkManagement.CountrySymbol;
            if (AddCTrademarkManagement.CountrySymbol != "")
            {
                dr["CountryName"] = AddCTrademarkManagement.CountrySymbol;
            }
            else
            {
                dr["CountryName"] = "";
            }

            AddCTrademarkManagement.StyleName = cb_StyleName.Text;
            dr["StyleName"] = AddCTrademarkManagement.StyleName;

            //案件類別
            AddCTrademarkManagement.TMTypeName = cb_TypeName.Text;
            dr["TMTypeName"] = AddCTrademarkManagement.TMTypeName;

            //該案申請號
            AddCTrademarkManagement.ObjectionApplicationNo = txt_ObjectionApplicationNo.Text;

            //該案申請日
            DateTime dtObjectionApplicationDate;
            bool IsObjectionApplicationDate = DateTime.TryParse(mask_ObjectionApplicationDate.Text, out dtObjectionApplicationDate);
            if (IsObjectionApplicationDate)
            {
                AddCTrademarkManagement.ObjectionApplicationDate = dtObjectionApplicationDate;
            }
            else
            {
                AddCTrademarkManagement.ObjectionApplicationDate = null;
            }

            //該案公告日
            DateTime dtObjectionNoticeDate;
            bool IsObjectionNoticeDate = DateTime.TryParse(mask_ObjectionNoticeDate.Text, out dtObjectionNoticeDate);
            if (IsObjectionNoticeDate)
            {
                AddCTrademarkManagement.ObjectionNoticeDate = dtObjectionNoticeDate;
            }
            else
            {
                AddCTrademarkManagement.ObjectionNoticeDate = null;
            }

            //該案公告號
            AddCTrademarkManagement.ObjectionNoticeNo = txt_ObjectionNoticeNo.Text;

            //該案註冊日
            DateTime dtObjectionRegistrationDate;
            bool IsObjectionRegistrationDate = DateTime.TryParse(masked_ObjectionRegistrationDate.Text, out dtObjectionRegistrationDate);
            if (IsObjectionRegistrationDate)
            {
                AddCTrademarkManagement.ObjectionRegistrationDate = dtObjectionRegistrationDate;
            }
            else {
                AddCTrademarkManagement.ObjectionRegistrationDate = null;
            }

            //該案註冊號
            AddCTrademarkManagement.ObjectionRegistrationNo = txt_ObjectionRegistrationNo.Text;

            //被異議/爭議商標名稱
            AddCTrademarkManagement.ObjectionTrademarkName = txt_ObjectionTrademarkName.Text;

            //被異議商標証號
            AddCTrademarkManagement.ObjectionRegistrationNo = txt_ObjectionRegistrationNo.Text;

            AddCTrademarkManagement.Status = cb_Status.SelectedValue != null ? (int)cb_Status.SelectedValue : -1;
            dr["Status"] = AddCTrademarkManagement.Status;

            AddCTrademarkManagement.StatusExplain = txt_StatusExplain.Text;
            dr["StatusExplain"] = AddCTrademarkManagement.StatusExplain;

            AddCTrademarkManagement.WorkerKey = cb_WorkerKey.SelectedValue != null ? (int)cb_WorkerKey.SelectedValue : -1;
            dr["WorkerKey"] = AddCTrademarkManagement.WorkerKey;
            if (AddCTrademarkManagement.WorkerKey != -1)
            {
                dr["EmployeeName"] = cb_WorkerKey.Text;
            }
            else
            {
                dr["EmployeeName"] = "";
            }

            //本所委辦日期
            DateTime dtEntrustDate = new DateTime();
            bool IsEntrustDate = DateTime.TryParse(maskedTextBox_EntrustDate.Text, out dtEntrustDate);
            if (IsEntrustDate)
            {
                AddCTrademarkManagement.EntrustDate = dtEntrustDate;
            }
            else {
                AddCTrademarkManagement.EntrustDate = null;
            }
          

            if (AddCTrademarkManagement.EntrustDate.HasValue)
            {
                dr["EntrustDate"] = AddCTrademarkManagement.EntrustDate;
            }
            else
            {
                dr["EntrustDate"] = DBNull.Value;
            }

                    

            AddCTrademarkManagement.OutsourcingTrademarkNo = txt_OutsourcingTrademarkNo.Text;
            dr["OutsourcingTrademarkNo"] = AddCTrademarkManagement.OutsourcingTrademarkNo;

            AddCTrademarkManagement.ObjectionRegistrationNo = txt_ObjectionRegistrationNo.Text;
            dr["ObjectionRegistrationNo"] = AddCTrademarkManagement.ObjectionRegistrationNo;

           

            

            //異議官方期限
            DateTime dtObjectionDueDate = new DateTime();
            bool IsObjectionDueDate = DateTime.TryParse(maskedTextBox_ObjectionDueDate.Text, out dtObjectionDueDate);
            if (IsObjectionDueDate)
            {
                AddCTrademarkManagement.ObjectionDueDate = dtObjectionDueDate;
            }
            else {
                AddCTrademarkManagement.ObjectionDueDate = null;
            }
            
            if (AddCTrademarkManagement.ObjectionDueDate.HasValue)
            {
                dr["ObjectionDueDate"] = AddCTrademarkManagement.ObjectionDueDate;
            }
            else
            {
                dr["ObjectionDueDate"] = DBNull.Value;
            }


            DateTime dtOutsourcingDate = new DateTime();
            bool IsCheckOutsourcingDate = DateTime.TryParse(maskedTextBox_OutsourcingDate.Text, out dtOutsourcingDate);
            if (IsCheckOutsourcingDate)
            {
                AddCTrademarkManagement.OutsourcingDate = dtOutsourcingDate;
            }
            else {
                AddCTrademarkManagement.OutsourcingDate = null;
            }
          
            if (AddCTrademarkManagement.OutsourcingDate.HasValue)
            {
                dr["OutsourcingDate"] = AddCTrademarkManagement.OutsourcingDate;
            }
            else
            {
                dr["OutsourcingDate"] = DBNull.Value;
            }


            DateTime dtApplicationDate = new DateTime();
            bool IsCheckApplicationDate = DateTime.TryParse(maskedTextBox_ApplicationDate.Text, out dtApplicationDate);
            if (IsCheckApplicationDate)
            {
                AddCTrademarkManagement.ApplicationDate = dtApplicationDate;
            }
            else {
                AddCTrademarkManagement.ApplicationDate = null;
            }
         
            if (AddCTrademarkManagement.ApplicationDate.HasValue)
            {
                dr["ApplicationDate"] = AddCTrademarkManagement.ApplicationDate;
            }
            else
            {
                dr["ApplicationDate"] = DBNull.Value;
            }

            AddCTrademarkManagement.ApplicationNo = txt_ApplicationNo.Text;
            dr["ApplicationNo"] = AddCTrademarkManagement.ApplicationNo;


            DateTime dtObjectionDate = new DateTime();
            bool IsCheckObjectionDate = DateTime.TryParse(maskedTextBox_ObjectionDate.Text, out dtObjectionDate);
            if (IsCheckObjectionDate)
            {
                AddCTrademarkManagement.ObjectionDate = dtObjectionDate;
            }
            else
            {
                AddCTrademarkManagement.ObjectionDate = null;
            }
           
            if (AddCTrademarkManagement.ObjectionDate.HasValue)
            {
                dr["ObjectionDate"] = AddCTrademarkManagement.ObjectionDate;
            }
            else
            {
                dr["ObjectionDate"] = DBNull.Value;
            }           

            //註冊日期
            DateTime dtRegistrationDate = new DateTime();
            bool IsCheckRegistrationDate = DateTime.TryParse(maskedTextBox_RegistrationDate.Text, out dtRegistrationDate);
            if (IsCheckRegistrationDate)
            {
                AddCTrademarkManagement.RegistrationDate = dtRegistrationDate;
            }
            else
            {
                AddCTrademarkManagement.RegistrationDate = null;
            }
          
            if (AddCTrademarkManagement.RegistrationDate.HasValue)
            {
                dr["RegistrationDate"] = AddCTrademarkManagement.RegistrationDate;
            }
            else
            {
                dr["RegistrationDate"] = DBNull.Value;
            }

            AddCTrademarkManagement.RegistrationNo = txt_RegistrationNo.Text;
            dr["RegistrationNo"] = AddCTrademarkManagement.RegistrationNo;

           
            AddCTrademarkManagement.RegisterProduct = txt_RegisterProduct.Text;
            dr["RegisterProduct"] = AddCTrademarkManagement.RegisterProduct;

            AddCTrademarkManagement.RegisterProduct = txt_RegisterProduct.Text;
            dr["RegisterProductName"] = AddCTrademarkManagement.RegisterProductName;

           

            DateTime dtCloseDate = new DateTime();
            bool IsCheckCloseDate = DateTime.TryParse(maskedTextBox_CloseDate.Text, out dtCloseDate);
            if (IsCheckCloseDate) AddCTrademarkManagement.CloseDate = dtCloseDate;
           
            if (AddCTrademarkManagement.CloseDate.HasValue)
            {
                dr["CloseDate"] = AddCTrademarkManagement.CloseDate;
            }
            else
            {
                dr["CloseDate"] = DBNull.Value;
            }

            AddCTrademarkManagement.Remarks = txt_Remarks.Text;
            dr["Remarks"] = AddCTrademarkManagement.Remarks;


            //委託類型
            AddCTrademarkManagement.DelegateType = (int)comboBox_DelegateType.SelectedValue;
            dr["DelegateType"] = AddCTrademarkManagement.DelegateType;
            dr["DelegateTypeName"] = comboBox_DelegateType.Text;

            AddCTrademarkManagement.IsBySelf = chb_IsBySelf.Checked;
            dr["IsBySelf"] = AddCTrademarkManagement.IsBySelf;

            //四種狀況
            //申請人-->本所-->複代(國外案)
            //申請人-->本所(國內案)
            //國內委辦所-->本所-->複代(國外案)
            //國外委辦所-->本所(國內案)
            if (comboBox_MainCustomer.SelectedValue != null)
            {
                AddCTrademarkManagement.MainCustomer = (int)comboBox_MainCustomer.SelectedValue;
            }
            else
            {
                AddCTrademarkManagement.MainCustomer = -1;
            }

            if (cb_MainCustomerLiaisoner.SelectedValue != null)
            {
                AddCTrademarkManagement.MainCustomerTransactor = (int)cb_MainCustomerLiaisoner.SelectedValue;
            }
            else
            {
                AddCTrademarkManagement.MainCustomerTransactor = -1;
            }

            //主要委託人--貴方案號
            AddCTrademarkManagement.MainCustomerRefNo = txt_MainCustomerRefNo.Text;

            if (AddCTrademarkManagement.IsBySelf.HasValue && !AddCTrademarkManagement.IsBySelf.Value)//非本所直接辦理
            {
                //承辦事務所
                if (cb_OutsourcingAttorney.SelectedValue != null)
                {
                    AddCTrademarkManagement.OutsourcingAttorney = (int)cb_OutsourcingAttorney.SelectedValue;
                }
                else
                {
                    AddCTrademarkManagement.OutsourcingAttorney = -1;
                }

                //對方案號
                AddCTrademarkManagement.OutsourcingTrademarkNo = txt_OutsourcingTrademarkNo.Text;

                //承辦事務所 聯絡窗口
                if (cb_OutsourcingAttorneyWorker.SelectedValue != null)
                {
                    AddCTrademarkManagement.OutsourcingAttorneyWorker = (int)cb_OutsourcingAttorneyWorker.SelectedValue;
                }
                else
                {
                    AddCTrademarkManagement.OutsourcingAttorneyWorker = -1;
                }
            }
            else//本所自行承辦
            {
                AddCTrademarkManagement.OutsourcingAttorney = -1;
                AddCTrademarkManagement.OutsourcingTrademarkNo = "";
                AddCTrademarkManagement.OutsourcingAttorneyWorker = -1;
            }

            if (AddCTrademarkManagement.DelegateType == 1)
            {
                //申請人直接委託
                dr["MainCustomerName"] = txt_MainCustomer.Text;
                if (cb_MainCustomerLiaisoner.SelectedValue != null)
                {
                    dr["MainCustomerTransactor"] = (int)cb_MainCustomerLiaisoner.SelectedValue;
                    dr["MainCustomerTransactorName"] = cb_MainCustomerLiaisoner.Text;
                }
                else
                {
                    dr["MainCustomerTransactor"] = -1;
                    dr["MainCustomerTransactorName"] = "";
                }

                dr["MainCustomerRefNo"] = AddCTrademarkManagement.MainCustomerRefNo;


                if (AddCTrademarkManagement.IsBySelf.HasValue && !AddCTrademarkManagement.IsBySelf.Value)
                {
                    //承辦事務所
                    dr["OutsourcingAttorney"] = AddCTrademarkManagement.OutsourcingAttorney;
                    dr["AttorneyFirm"] = cb_OutsourcingAttorney.Text;
                    dr["OutsourcingAttorneyWorker"] = AddCTrademarkManagement.OutsourcingAttorneyWorker;
                    dr["AttLiaisoner"] = cb_OutsourcingAttorneyWorker.Text;
                    dr["OutsourcingTrademarkNo"] = AddCTrademarkManagement.OutsourcingTrademarkNo;
                }
                else
                {
                    //本所自行承辦
                    dr["AttorneyFirm"] = "";
                    dr["AttLiaisoner"] = "";
                    dr["OutsourcingTrademarkNo"] = "";
                }
            }
            else//複代委託
            {
                dr["MainCustomer"] = AddCTrademarkManagement.MainCustomer;
                if (AddCTrademarkManagement.MainCustomer != -1)
                {
                    dr["MainCustomerName"] = comboBox_MainCustomer.Text;
                }
                else
                {
                    dr["MainCustomerName"] = "";
                }

                dr["MainCustomerRefNo"] = AddCTrademarkManagement.MainCustomerRefNo;

                if (cb_MainCustomerLiaisoner.SelectedValue != null)
                {
                    dr["MainCustomerTransactor"] = (int)cb_MainCustomerLiaisoner.SelectedValue;
                    dr["MainCustomerTransactorName"] = cb_MainCustomerLiaisoner.Text;
                }

                if (AddCTrademarkManagement.IsBySelf.HasValue &&  !AddCTrademarkManagement.IsBySelf.Value)
                {
                    //承辦事務所
                    dr["OutsourcingAttorney"] = AddCTrademarkManagement.OutsourcingAttorney;
                    if (AddCTrademarkManagement.OutsourcingAttorney != -1)
                    {
                        dr["AttorneyFirm"] = cb_OutsourcingAttorney.Text;
                    }
                    else
                    {
                        dr["AttorneyFirm"] = "";
                    }
                    dr["OutsourcingAttorneyWorker"] = AddCTrademarkManagement.OutsourcingAttorneyWorker;
                    if (AddCTrademarkManagement.OutsourcingAttorneyWorker != -1)
                    {
                        dr["AttLiaisoner"] = cb_OutsourcingAttorneyWorker.Text;
                    }
                    else
                    {
                        dr["AttLiaisoner"] = "";
                    }
                    dr["OutsourcingTrademarkNo"] = AddCTrademarkManagement.OutsourcingTrademarkNo;
                }
                else
                {
                    //本所自行承辦
                    dr["AttorneyFirm"] = "";
                    dr["AttLiaisoner"] = "";
                    dr["OutsourcingTrademarkNo"] = "";
                }
            }

            AddCTrademarkManagement.ObjectionClass = txt_ObjectionClass.Text;
            dr["ObjectionClass"] = AddCTrademarkManagement.ObjectionClass;

            AddCTrademarkManagement.ObjectionContent = txt_ObjectionContent.Text;
            dr["ObjectionContent"] = AddCTrademarkManagement.ObjectionContent;

            AddCTrademarkManagement.ObjectionNo = txt_ObjectionNo.Text;
            dr["ObjectionNo"] = AddCTrademarkManagement.ObjectionNo;

            AddCTrademarkManagement.ObjectionPeople = txt_ObjectionPeople.Text;
            dr["ObjectionPeople"] = AddCTrademarkManagement.ObjectionPeople;

            //被異議/爭議商標名稱
            dr["ObjectionTrademarkName"] = AddCTrademarkManagement.ObjectionTrademarkName;

            //該案申請號
            dr["ObjectionApplicationNo"] = AddCTrademarkManagement.ObjectionApplicationNo;

            //該案申請日
            if (AddCTrademarkManagement.ObjectionApplicationDate.HasValue)
            {
                dr["ObjectionApplicationDate"] = AddCTrademarkManagement.ObjectionApplicationDate;
            }
            else
            {
                dr["ObjectionApplicationDate"] = DBNull.Value;
            }

            //該案公告日
            if (AddCTrademarkManagement.ObjectionNoticeDate.HasValue)
            {
                dr["ObjectionNoticeDate"] = AddCTrademarkManagement.ObjectionNoticeDate;
            }
            else
            {
                dr["ObjectionNoticeDate"] = DBNull.Value;
            }

            //該案公告號
            dr["ObjectionNoticeNo"] = AddCTrademarkManagement.ObjectionNoticeNo;

            //該案註冊日
            if (AddCTrademarkManagement.ObjectionRegistrationDate.HasValue)
            {
                dr["ObjectionRegistrationDate"] = AddCTrademarkManagement.ObjectionRegistrationDate;
            }
            else
            {
                dr["ObjectionRegistrationDate"] = DBNull.Value;
            }

            //該案註冊號
            dr["ObjectionRegistrationNo"] = AddCTrademarkManagement.ObjectionRegistrationNo; 

            //商標圖
            if (txt_NewPicture.Text != "")
            {
                Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();

                //先刪除原本的圖
                string sPath = dll.TrademarkControversyFolderRoot + "\\" + AddCTrademarkManagement.PicPath;
                if (File.Exists(sPath))
                {
                    File.Delete(sPath);
                }

                if (File.Exists(txt_NewPicture.Text))
                {
                    FileInfo upload = new FileInfo(txt_NewPicture.Text);

                    //確認商標資料夾是否存在
                    dll.CreatFolder(5, AddCTrademarkManagement.TrademarkControversyID.ToString());


                    //Public.CUpLoadFile upfile = new LawtechPTSystemByFirm.Public.CUpLoadFile(string.Format(@"MainParentID={0} and FileKind=5 and FileType=10 and FilePath='{1}' ", TrademarkControversyID, AddCTrademarkManagement.PicPath));
                    List<Public.CUpLoadFile> upfile = new List<LawtechPTSystemByFirm.Public.CUpLoadFile>();
                    Public.CUpLoadFile.ReadList(ref upfile, string.Format(@"MainParentID={0} and FileKind=5 and FileType=10 and FilePath='{1}' ", TrademarkControversyID, AddCTrademarkManagement.PicPath));

                    AddCTrademarkManagement.PicPath = AddCTrademarkManagement.TrademarkControversyID.ToString() + "\\" + upload.Name;
                    string sPath_New = dll.TrademarkControversyFolderRoot + "\\" + AddCTrademarkManagement.PicPath;
                    File.Copy(txt_NewPicture.Text, sPath_New);
                    //Forms.TrademarkControversyMF.property_TMPicturePath = sPath_New;

                    

                    if (upfile.Count > 0)
                    {
                       
                        upfile[0].FilePath = AddCTrademarkManagement.PicPath;
                        upfile[0].Uploader = Properties.Settings.Default.WorkerName;
                        upfile[0].Update();
                    }
                    else
                    {
                         Public.CUpLoadFile Insertfile = new Public.CUpLoadFile();
                        Insertfile.MainParentID = TrademarkControversyID;
                        Insertfile.FileKind = 5;
                        Insertfile.FileType = 10;
                       
                        Insertfile.FilePath = AddCTrademarkManagement.PicPath;
                        Insertfile.FileDoc = "我方商標圖";
                        Insertfile.Uploader = Properties.Settings.Default.WorkerName;
                        Insertfile.Create();
                    }


                    dr["PicPath"] = AddCTrademarkManagement.PicPath;
                }

            }

            //被異議人商標圖
            if (txt_ObjectionPicPathNew.Text != "")
            {
                Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();

                //先刪除原本的圖
                string sPath = dll.TrademarkControversyFolderRoot + "\\" + AddCTrademarkManagement.ObjectionPicPath;
                if (File.Exists(sPath))
                {
                    File.Delete(sPath);
                }

                if (File.Exists(txt_ObjectionPicPathNew.Text))
                {
                    FileInfo upload = new FileInfo(txt_ObjectionPicPathNew.Text);

                    //確認商標資料夾是否存在
                    dll.CreatFolder(5, AddCTrademarkManagement.TrademarkControversyID.ToString());

                    //Public.CUpLoadFile upfile = new LawtechPTSystemByFirm.Public.CUpLoadFile(string.Format(@"MainParentID={0} and  FileKind=5 and FileType=10 and FilePath='{1}' ", TrademarkControversyID, AddCTrademarkManagement.ObjectionPicPath));
                    List<Public.CUpLoadFile> upfile = new List<LawtechPTSystemByFirm.Public.CUpLoadFile>();
                    Public.CUpLoadFile.ReadList(ref upfile, string.Format(@"MainParentID={0} and  FileKind=5 and FileType=10 and FilePath='{1}' ", TrademarkControversyID, AddCTrademarkManagement.ObjectionPicPath));

                    AddCTrademarkManagement.PicPath = AddCTrademarkManagement.TrademarkControversyID.ToString() + "\\" + upload.Name;
                    string sPath_New = dll.TrademarkControversyFolderRoot + "\\" + AddCTrademarkManagement.ObjectionPicPath;
                    File.Copy(txt_ObjectionPicPathNew.Text, sPath_New);
                    //Forms.TrademarkControversyMF.property_TMPicturePath = sPath_New;

                   

                    if (upfile.Count > 0)
                    {                        
                        upfile[0].FilePath = AddCTrademarkManagement.ObjectionPicPath;
                        upfile[0].Uploader = Properties.Settings.Default.WorkerName;
                        upfile[0].Update();
                    }
                    else
                    {
                        Public.CUpLoadFile Insertfile = new Public.CUpLoadFile();
                        Insertfile.MainParentID = TrademarkControversyID;
                        Insertfile.FileKind = 5;
                        Insertfile.FileType = 10;

                        Insertfile.FilePath = AddCTrademarkManagement.ObjectionPicPath;
                        Insertfile.FileDoc = "被異議人商標圖";
                        Insertfile.Uploader = Properties.Settings.Default.WorkerName;
                        Insertfile.Create();
                    }


                    dr["PicPath"] = AddCTrademarkManagement.PicPath;
                }

            }

           
            AddCTrademarkManagement.LastModifyWorker = Properties.Settings.Default.WorkerName;

            AddCTrademarkManagement.Update();
            Forms.TrademarkControversyMF.dt_TrademarkControversyManagementT.AcceptChanges();
           

            MessageBox.Show("修改成功", "提示訊息");
            this.Close();
        }
        #endregion

        private void cb_Country_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Country.SelectedValue != null)
            {

                this.attorneyTTableAdapter.FillByCountry(this.dataSet_Drop.AttorneyT, cb_Country.SelectedValue.ToString());
            }
        }



        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "ToolStripMenuItem_All":
                    checkBox_All.Checked = true;
                    attorneyTBindingSource1.Filter = "";
                    break;
                case "ToolStripMenuItem_CurrentCountry":
                    if (cb_Country.SelectedValue != null)
                    {
                        checkBox_All.Checked = false;
                        attorneyTBindingSource1.Filter = "Country ='" + cb_Country.SelectedValue.ToString() + "'";
                    }
                    break;
            }
        }

        private void contextMenuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "ToolStripMenuItem_All2":
                    checkBox_All.Checked = true;
                    attorneyTBindingSource.Filter = "";
                    break;
                case "ToolStripMenuItem_CurrentCountry2":
                    if (cb_Country.SelectedValue != null)
                    {
                        checkBox_All.Checked = false;
                        attorneyTBindingSource.Filter = "Country ='" + cb_Country.SelectedValue.ToString() + "'";
                    }
                    break;
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            US.SelectApplicant app = new US.SelectApplicant();

            app.ApplicantNames = txt_ApplicantNames.Text;
            app.ApplicantKeys = txt_ApplicantKeys.Text;

            if (app.ShowDialog() == DialogResult.OK)
            {

                txt_ApplicantNames.Text = app.ApplicantNames;
                txt_ApplicantKeys.Text = app.ApplicantKeys;

                //comboBox_DelegateType_SelectedIndexChanged(comboBox_DelegateType, null);
                txt_MainCustomer.Text = txt_ApplicantNames.Text;

                if (comboBox_DelegateType.SelectedValue.ToString() == "1")
                {
                    if (txt_ApplicantKeys.Text != "")
                    {
                        GetLiaisonerTOnline(txt_ApplicantKeys.Text);
                    }
                }
            }
        }

        private void chb_IsBySelf_CheckedChanged_1(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;

            cb_OutsourcingAttorney.Enabled = cb_OutsourcingAttorneyWorker.Enabled = txt_OutsourcingTrademarkNo.Enabled = maskedTextBox_OutsourcingDate.Enabled = !cb.Checked;

            txt_OutsourcingTrademarkNo.Text = "";
            maskedTextBox_OutsourcingDate.Text = "";
        }

        private void contextMenuStrip_ForDate_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {
            ContextMenuStrip content = (ContextMenuStrip)sender;
            MaskedTextBox mtb = content.SourceControl as MaskedTextBox;

            contextMenuStrip_ForDate.Visible = false;

            switch (e.ClickedItem.Name)
            {
                case "ToolStripMenuItem_Calculation":

                    US.CalculationDate Calculation = new LawtechPTSystemByFirm.US.CalculationDate();
                    DateTime dt = new DateTime(1900, 1, 1);
                    bool IsSuccess = DateTime.TryParse(mtb.Text, out dt);
                    if (IsSuccess)
                    {
                        Calculation.CurrentDate = dt;
                    }
                    else
                    {
                        Calculation.CurrentDate = new DateTime(1900, 1, 1);
                    }

                    //取得結果
                    if (Calculation.ShowDialog() == DialogResult.OK)
                    {
                        mtb.Text = Calculation.GetResult;
                    }
                    break;
            }
        }

    }
}
