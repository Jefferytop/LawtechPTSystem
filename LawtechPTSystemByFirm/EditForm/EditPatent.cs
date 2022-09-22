using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.EditForm
{
    public partial class EditPatent : Form
    {
        private bool iMode = true;
        /// <summary>
        /// 模式 true-可編輯  false-不可編輯
        /// </summary>
        public bool Mode
        {
            get { return iMode; }
            set { iMode = value; }
        }

        private int patentid = -1;
        /// <summary>
        /// 申請案ID
        /// </summary>
        public int Patent_ID
        {
            get { return patentid; }
            set { patentid = value; }
        }

        private bool bIsChangeApp = false;
        /// <summary>
        /// 是否有異動申請人
        /// </summary>
        public bool IsChangeApp
        {
            get { return bIsChangeApp; }
            set { bIsChangeApp = value; }
        }
        

        public EditPatent()
        {
            InitializeComponent();
        }

        #region EditPatent_Load
        private void EditPatent_Load(object sender, EventArgs e)
        {
          
            this.delegateFeatureTTableAdapter.Fill(this.dataSet_Drop.DelegateFeatureT);
                     
            this.workerTAllTableAdapter.Fill(this.qS_DataSet.WorkerTAll);
           
            this.delegateTypeTableAdapter.Fill(this.dataSet_Drop.DelegateType);
            this.patFeatureTTableAdapter.Fill(this.dataSet_Drop.PatFeatureT);
            this.patISexamTTableAdapter.Fill(this.dataSet_Drop.PatISexamT);
            this.pattPriorityBaseTTableAdapter.Fill(this.dataSet_Drop.PattPriorityBaseT);
            this.kindforPatTableAdapter.FillbyPatKind(this.qS_DataSet.KindforPat);
            this.patStatusT_DropTableAdapter.Fill(this.qS_DataSet._PatStatusT_Drop);
            this.countryT_DropTableAdapter.Fill(this.qS_DataSet.CountryT_Drop);
            //this.applicantT_DropTableAdapter.Fill(this.qS_DataSet.ApplicantT_Drop);
            this.attorneyTTableAdapter1.Fill(this.dataSet_Attorney.AttorneyT);

            Public.CPatentManagement pat = new LawtechPTSystemByFirm.Public.CPatentManagement();
            Public.CPatentManagement.ReadOne(Patent_ID, ref pat);            
           
            txt_PatentNo.Text = pat.PatentNo;
            txt_title.Text = pat.Title;
            txt_FileNo_Old.Text = pat.PatentNo_Old;
            txt_TitleEn.Text = pat.TitleEn;
            //comboBox_Applicant.SelectedValue = pat.Applicant;
            txt_ApplicantNames.Text = pat.ApplicantNames;
            txt_ApplicantKeys.Text = pat.ApplicantKeys;
            txt_EarlyPriorityNo.Text = pat.EarlyPriorityNo;

            //Combo_AttorneyFile.SelectedValue = pat.Attorney;
            //Combo_AttLiaisoner.SelectedValue = pat.AttorneyTransactor;
            txt_AttorneyRefNo.Text = pat.AttorneyRefNo;
            if (pat.Priority.HasValue)
            {
                Combo_Priority.SelectedValue = pat.Priority;
            }
            if (pat.EarlyPriorityDate.HasValue)
            {
                maskedTextBox_EarlyPriorityDate.Text = pat.EarlyPriorityDate.Value.ToString("yyyy/MM/dd") ;
            }
            if (pat.ISexam.HasValue)
            {
                Combo_ISExam.SelectedValue = pat.ISexam;
            }

            if (!string.IsNullOrEmpty(pat.CountrySymbol))
            {
                comboBox_Country.SelectedValue = pat.CountrySymbol;
            }
            //this.attorneyTTableAdapter.Fill(this.dataSet_Drop.AttorneyT);

            if (pat.Nature.HasValue)
            {
                comboBox_Nature.SelectedValue = pat.Nature;
            }

            if (pat.Kind != null)
            {
                comboBox_Kind.SelectedValue = pat.Kind;
            }

            if (pat.Status.HasValue)
            {
                comboBox_Status.SelectedValue = pat.Status;
            }
            txt_StatusExplain.Text = pat.StatusExplain;

            if (pat.Priority.HasValue)
            {
                Combo_Priority.SelectedValue = pat.Priority;
            }

            if (pat.ClientWorker.HasValue)
            {
                cbm_ClientWorker.SelectedValue = pat.ClientWorker;
            }

            if (pat.EarlyMotherDate.HasValue)
            {
                maskedTextBox_EarlyMotherDate.Text = pat.EarlyMotherDate.Value.ToString("yyyy/MM/dd") ;
            }
            if (pat.ApplicationDate.HasValue)
            {
                maskedTextBox_ApplicationDate.Text = pat.ApplicationDate.Value.ToString("yyyy/MM/dd") ;
            }
            txt_ApplicationNo.Text = pat.ApplicationNo;
            if (pat.Pubdate.HasValue)
            {
                maskedTextBox_Pubdate.Text = pat.Pubdate.Value.ToString("yyyy/MM/dd") ;
            }
            txt_PubNo.Text = pat.PubNo;

            if (pat.AllowDate.HasValue)
            {
                maskedTextBox_AllowDate.Text = pat.AllowDate.Value.ToString("yyyy/MM/dd") ;
            }

            txt_Inventor.Text = pat.Inventor;
            if (pat.AllowPubDate.HasValue)
            {
                maskedTextBox_AllowPubdate.Text = pat.AllowPubDate.Value.ToString("yyyy/MM/dd") ;
            }
            txt_AllowPubNo.Text = pat.AllowPubNo;
            if (pat.GetDate.HasValue)
            {
                maskedTextBox_GetDate.Text = pat.GetDate.Value.ToString("yyyy/MM/dd");
            }
            txt_CertifyNo.Text = pat.CertifyNo;
            if (pat.RegisterDate.HasValue)
            {
                maskedTextBox_Registerdate.Text = pat.RegisterDate.Value.ToString("yyyy/MM/dd") ;
            }

            if (pat.AddDay.HasValue)
            {
                NumericUpDown_AddDay.Value = pat.AddDay.Value;
            }

            if (pat.DueDate.HasValue)
            {
                maskedTextBox_DueDate.Text = pat.DueDate.Value.ToString("yyyy/MM/dd");
            }

            if (pat.PayYear.HasValue)
            {
                NumericUpDown_PayYear.Value = pat.PayYear.Value;
            }

            if (pat.RenewTo.HasValue)
            {
                maskedTextBox_RenewTo.Text = pat.RenewTo.Value.ToString("yyyy/MM/dd") ;
            }

            if (pat.CloseDate.HasValue)
            {
                maskedTextBox_CloseDate.Text = pat.CloseDate.Value.ToString("yyyy/MM/dd") ;
            }
            txt_CloseCaus.Text = pat.CloseCaus;
            txt_Remark.Text = pat.Remark;

            comboBox_DelegateFeatureKey.SelectedValue = pat.DelegateFeatureKey == null ? 1 : pat.DelegateFeatureKey;
            comboBox_DelegateType.SelectedValue = pat.DelegateType == -1 ? 1 : pat.DelegateType;
            comboBox_DelegateType_SelectedIndexChanged(comboBox_DelegateType,null);
            
            //本所自行辦理
            chb_IsBySelf.Checked = pat.IsBySelf.Value;

            if (pat.DelegateType == 1)//申請人直接委託
            {
                txt_MainCustomer.Text = txt_ApplicantNames.Text;
                txt_MainCustomerRefNo.Text = pat.MainCustomerRefNo;
                if (pat.MainCustomerTransactor.HasValue)
                {
                    cb_MainCustomerLiaisoner.SelectedValue = pat.MainCustomerTransactor;
                }

               
                if (!chb_IsBySelf.Checked)
                {
                    if (pat.Attorney.HasValue)
                    {
                        cb_Attorney.SelectedValue = pat.Attorney;
                    }

                    txt_AttorneyRefNo.Text = pat.AttorneyRefNo;
                    if (pat.AttorneyTransactor != -1)
                    {
                        if (cb_Attorney.SelectedValue != null)
                        {
                            this.attLiaisonerT_AllTableAdapter.Fill(this.dataSet_Drop.AttLiaisonerT_All, (int)cb_Attorney.SelectedValue);
                        }
                        if (pat.AttorneyTransactor.HasValue)
                        {
                            cb_AttorneyTransactor.SelectedValue = pat.AttorneyTransactor;
                        }
                    }
                }
            }
            else//複代委託
            {
                if (pat.MainCustomer.HasValue)
                {
                    comboBox_MainCustomer.SelectedValue = pat.MainCustomer;
                }
                txt_MainCustomerRefNo.Text = pat.MainCustomerRefNo;

                if (pat.MainCustomerTransactor.HasValue)
                {
                    cb_MainCustomerLiaisoner.SelectedValue = pat.MainCustomerTransactor;
                }

                if (!chb_IsBySelf.Checked)
                {
                    if (pat.Attorney.HasValue)
                    {
                        cb_Attorney.SelectedValue = pat.Attorney;
                    }
                    txt_AttorneyRefNo.Text = pat.AttorneyRefNo;

                    if (pat.AttorneyTransactor != -1)
                    {
                        this.attLiaisonerT_AllTableAdapter.Fill(this.dataSet_Drop.AttLiaisonerT_All, (int)cb_Attorney.SelectedValue);

                        if (pat.AttorneyTransactor.HasValue)
                        {
                            cb_AttorneyTransactor.SelectedValue = pat.AttorneyTransactor;
                        }
                    }
                }
            }

            txt_Introducer.Text = pat.Introducer;

            if (pat.IntroductionDate.HasValue)
            {
                mask_IntroductionDate.Text = pat.IntroductionDate.Value.ToString("yyyy/MM/dd");
            }

            if (!Mode)
            {
                panel1.Enabled = Mode;
                button1.Visible = Mode;
            }

        }
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region button1_Click
        private void button1_Click(object sender, EventArgs e)
        {
            Public.CPatentManagement pat = new LawtechPTSystemByFirm.Public.CPatentManagement();
            Public.CPatentManagement.ReadOne(Patent_ID,ref pat);
           

            string OriginalPatentNo = pat.PatentNo;

            if (txt_PatentNo.Text.Trim() == "")
            {
                MessageBox.Show("【申請案卷號】不得為空白，\r\n   請修改【申請案卷號】!!");
                txt_PatentNo.Focus();
                return;
            }

            if (OriginalPatentNo.Trim() != txt_PatentNo.Text.Trim())//不等於原始案號
            {
                bool isPatentNo=false;
                pat.CheckValueExist("PatentNo", txt_PatentNo.Text.Trim(), ref isPatentNo,false);
                if (isPatentNo)
                {
                    MessageBox.Show("【申請案卷號】重覆，\r\n   請修改【申請案卷號】!!");
                    txt_PatentNo.Focus();
                    return;
                }
            }

            pat.PatentNo = txt_PatentNo.Text.Trim();
            pat.Title = txt_title.Text;
            pat.PatentNo_Old = txt_FileNo_Old.Text;
            pat.TitleEn = txt_TitleEn.Text;
            pat.Applicant=comboBox_Applicant.SelectedValue!=null?(int)comboBox_Applicant.SelectedValue:-1;
            pat.ApplicantNames = txt_ApplicantNames.Text;
            pat.ApplicantKeys = txt_ApplicantKeys.Text;
            pat.EarlyPriorityNo = txt_EarlyPriorityNo.Text;

            //性質
            pat.Nature = comboBox_Nature.SelectedValue != null ? (int)comboBox_Nature.SelectedValue : -1;
            //國別 
            pat.CountrySymbol = comboBox_Country.SelectedValue != null ? comboBox_Country.SelectedValue.ToString():"";

            //種類
            pat.Kind = comboBox_Kind.SelectedValue != null ? comboBox_Kind.SelectedValue.ToString() : "";

            //狀態
            pat.Status = comboBox_Status.SelectedValue != null ? (int)comboBox_Status.SelectedValue : -1;
            //狀態描述
            pat.StatusExplain = txt_StatusExplain.Text;

            pat.Priority =Combo_Priority.SelectedValue!=null? (int)Combo_Priority.SelectedValue:-1;
            pat.PubNo = txt_PubNo.Text;
            pat.CloseCaus = txt_CloseCaus.Text;
            pat.Remark = txt_Remark.Text;
            pat.ApplicationNo = txt_ApplicationNo.Text;
            pat.ISexam =Combo_ISExam.SelectedValue!=null? (int)Combo_ISExam.SelectedValue:-1;
            pat.ClientWorker =cbm_ClientWorker.SelectedValue!=null? (int)cbm_ClientWorker.SelectedValue:-1;
            pat.Inventor = txt_Inventor.Text;
            pat.AllowPubNo = txt_AllowPubNo.Text;
            pat.CertifyNo = txt_CertifyNo.Text;
            pat.AddDay = int.Parse(NumericUpDown_AddDay.Value.ToString());
            pat.PayYear =NumericUpDown_PayYear.Value;
            pat.Introducer = txt_Introducer.Text;
           
            pat.DelegateType = (int)comboBox_DelegateType.SelectedValue;

            pat.DelegateFeatureKey = (int)comboBox_DelegateFeatureKey.SelectedValue;

            //本所直接處理
            pat.IsBySelf = chb_IsBySelf.Checked;

            if (pat.DelegateType == 1)//申請人直接委託
            {
                pat.MainCustomer = pat.PatentID;
                //主委託人
                pat.MainCustomerRefNo = txt_MainCustomerRefNo.Text;

                if (cb_MainCustomerLiaisoner.SelectedValue != null)
                {
                    pat.MainCustomerTransactor = (int)cb_MainCustomerLiaisoner.SelectedValue;
                }
                else
                {
                    pat.MainCustomerTransactor = -1;
                }               

                if (!pat.IsBySelf.Value)
                {
                    if (cb_Attorney.SelectedValue != null)
                    {
                        pat.Attorney = (int)cb_Attorney.SelectedValue;
                        if (cb_AttorneyTransactor.SelectedValue != null)
                        {
                            pat.AttorneyTransactor = (int)cb_AttorneyTransactor.SelectedValue;
                        }
                        else
                        {
                            pat.AttorneyTransactor = -1;
                        }
                    }

                    pat.AttorneyRefNo = txt_AttorneyRefNo.Text;
                }
                else
                {
                    pat.Attorney = -1;
                    pat.AttorneyTransactor = -1;
                    pat.AttorneyRefNo = "";
                }
            }
            else//複代委託
            {                
                if (comboBox_MainCustomer.SelectedValue != null)
                {
                    pat.MainCustomer = (int)comboBox_MainCustomer.SelectedValue;
                }
                else
                {
                    pat.MainCustomer = -1;
                }
                pat.MainCustomerRefNo = txt_MainCustomerRefNo.Text;
                if (cb_MainCustomerLiaisoner.SelectedValue != null)
                {
                    pat.MainCustomerTransactor = (int)cb_MainCustomerLiaisoner.SelectedValue;
                }
                else
                {
                    pat.MainCustomerTransactor = -1;
                }

                if (!pat.IsBySelf.Value)//非本所自行辦理
                {
                    if (cb_Attorney.SelectedValue != null)
                    {
                        pat.Attorney = (int)cb_Attorney.SelectedValue;
                        if (cb_AttorneyTransactor.SelectedValue != null)
                        {
                            pat.AttorneyTransactor = (int)cb_AttorneyTransactor.SelectedValue;
                        }
                        else
                        {
                            pat.AttorneyTransactor = -1;
                        }
                    }

                    pat.AttorneyRefNo = txt_AttorneyRefNo.Text;
                }
                else
                {
                    pat.Attorney = -1;
                    pat.AttorneyTransactor = -1;
                    pat.AttorneyRefNo = "";
                }
            }

            DateTime IntroductionDate ;
            bool IsIntroductionDate = DateTime.TryParse(mask_IntroductionDate.Text, out IntroductionDate);
            if (IsIntroductionDate) pat.IntroductionDate = IntroductionDate;
            else pat.IntroductionDate = null;

            DateTime EarlyPriority ;
           bool IsEarlyPriority= DateTime.TryParse(maskedTextBox_EarlyPriorityDate.Text, out EarlyPriority);
           if (IsEarlyPriority) pat.EarlyPriorityDate = EarlyPriority;
           else pat.EarlyPriorityDate =null;

            DateTime EarlyMother;
           bool IsEarlyMother= DateTime.TryParse(maskedTextBox_EarlyMotherDate.Text, out EarlyMother);
           if (IsEarlyMother) pat.EarlyMotherDate = EarlyMother;
           else pat.EarlyMotherDate = null;

            DateTime Application ;
           bool IsApplication= DateTime.TryParse(maskedTextBox_ApplicationDate.Text, out Application);
           if (IsApplication) pat.ApplicationDate = Application;
           else pat.ApplicationDate =null;


            DateTime Pubdate ;
           bool IsPubdate= DateTime.TryParse(maskedTextBox_Pubdate.Text, out Pubdate);
           if (IsPubdate) pat.Pubdate = Pubdate;
           else pat.Pubdate = null;

            DateTime AllowDate ;
            bool IsAllowDate =DateTime.TryParse(maskedTextBox_AllowDate.Text, out AllowDate);
            if(IsAllowDate)pat.AllowDate = AllowDate;
            else pat.AllowDate = null;

            DateTime AllowPubDate ;
            bool IsAllowPubDate= DateTime.TryParse(maskedTextBox_AllowPubdate.Text, out AllowPubDate);
            if (IsAllowPubDate) pat.AllowPubDate = AllowPubDate;
            else pat.AllowPubDate = null;

            DateTime GetDate;
            bool IsGetDate= DateTime.TryParse(maskedTextBox_GetDate.Text, out GetDate);
            if (IsGetDate) pat.GetDate = GetDate;
            else pat.GetDate = null;

            DateTime RegisterDate ;
            bool IsRegisterDate=DateTime.TryParse(maskedTextBox_Registerdate.Text, out RegisterDate);
            if (IsRegisterDate) pat.RegisterDate = RegisterDate;
            else pat.RegisterDate = null;

            DateTime DueDate ;
           bool IsDueDate= DateTime.TryParse(maskedTextBox_DueDate.Text, out DueDate);
           if (IsDueDate) pat.DueDate = DueDate;
           else pat.DueDate = null;

            DateTime RenewTo ;
            bool IsRenewTo= DateTime.TryParse(maskedTextBox_RenewTo.Text, out RenewTo);
            if (IsRenewTo) pat.RenewTo = RenewTo;
            else pat.RenewTo = null;

            DateTime CloseDate ;
           bool IsCloseDate= DateTime.TryParse(maskedTextBox_CloseDate.Text, out CloseDate);
           if (IsCloseDate) pat.CloseDate = CloseDate;
           else pat.CloseDate = null;

          
           pat.LastModifyWorker = Properties.Settings.Default.WorkerName;

            pat.Update();
                        

            if (IsChangeApp)
            {
                //申請人               
                Public.CPatentApplicant ptApp = new Public.CPatentApplicant();
                ptApp.Delete("PatentID=" + pat.PatentID.ToString(),"");

                string[] apps = txt_ApplicantKeys.Text.Split(',');
                for (int iApp = 0; iApp < apps.Length; iApp++)
                {
                    if (apps[iApp] != "")
                    {
                        ptApp.PatentID = pat.PatentID;
                        ptApp.ApplicantKey = int.Parse(apps[iApp]);
                        ptApp.Create();
                    }
                }
            }

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            if (Forms.PatListMF != null)
            {
                DataRow dr = Forms.PatListMF.DT_PatentList.Rows.Find(Patent_ID);               
                DataRow drV = Public.CPatentPublicFunction.GetPatentListDataRow(pat.PatentID.ToString());
              
                dr.ItemArray = drV.ItemArray;
                dr.AcceptChanges();
              
            }


            MessageBox.Show("修改資料成功 " + pat.PatentNo);
            this.Close();


        }
        #endregion

        #region comboBox_DelegateType_SelectedIndexChanged
        /// <summary>
        /// 委託類型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_DelegateType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (cb.SelectedValue.ToString() == "2")
            {
                //groupBox2.Enabled = false;
                //cb_Attorney.DataSource = null;
                //cb_AttorneyTransactor.DataSource = null;
                groupBox4.Text = "主要委託人(複代)";
                txt_MainCustomer.Visible = false;
                comboBox_MainCustomer.Visible = true;
                chb_IsBySelf.Checked = false;

                if (comboBox_MainCustomer.SelectedValue != null)
                {
                    List<Public.CAttLiaisoner> catt = new List<LawtechPTSystemByFirm.Public.CAttLiaisoner>();
                    Public.CAttLiaisoner.ReadList(ref catt, string.Format(" AttorneyKey={0} and Quit<>1  ", comboBox_MainCustomer.SelectedValue.ToString()));
                    
                    attLiaisonerTBindingSource1.DataSource = catt;
                }
                cb_MainCustomerLiaisoner.DataSource = attLiaisonerTBindingSource1;
                cb_MainCustomerLiaisoner.DisplayMember = "Liaisoner";
                cb_MainCustomerLiaisoner.ValueMember = "ALiaisonerKey";

                txt_AttorneyRefNo.Text = "";


            }
            else
            {
                //同申請人
                groupBox2.Enabled = true;
                chb_IsBySelf.Checked = true;
                //cb_Attorney.DisplayMember = "AttorneySymbol";
                //cb_Attorney.ValueMember = "AttorneyKey";
                //cb_Attorney.DataSource = attorneyTBindingSource;

                //cb_AttorneyTransactor.DataSource = attorneyTAttLiaisonerTBindingSource;
                //cb_AttorneyTransactor.DisplayMember = "Liaisoner";
                //cb_AttorneyTransactor.ValueMember = "ALiaisonerKey";

                groupBox4.Text = "主要委託人(同申請人)";
                txt_MainCustomer.Visible = true;
                comboBox_MainCustomer.Visible = false;
                txt_MainCustomer.Text = txt_ApplicantNames.Text;

                cb_MainCustomerLiaisoner.DataSource = liaisonerTOnlineBindingSource;
                cb_MainCustomerLiaisoner.DisplayMember = "LiaisonerName";
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
            string strSQL = string.Format(@"SELECT          - 1 AS LiaisonerKey, '' AS LiaisonerName
UNION
SELECT          LiaisonerKey, LiaisonerName
FROM              LiaisonerT
WHERE          (ApplicantKey in ({0}) ) and Quit<>1 ", ApplicantKey);
            Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
            dll.FetchDataTable(strSQL, this.qS_DataSet.LiaisonerTOnline);

        }
        #endregion

        private void comboBox_Applicant_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboBox_DelegateType.SelectedValue.ToString() == "1")//委託類型為申請人直接委託
            //{
            //    txt_MainCustomer.Text = comboBox_Applicant.Text;

            //    if (comboBox_Applicant.SelectedValue != null)
            //    {
            //        if (this.qS_DataSet.LiaisonerT.Rows.Count > 0)
            //        {
            //            this.qS_DataSet.LiaisonerT.Clear();
            //        }
            //        this.liaisonerTTableAdapter.Fill(this.qS_DataSet.LiaisonerT, (int)comboBox_Applicant.SelectedValue);
            //    }
            //}
        }

        private void comboBox_MainCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_DelegateType.SelectedValue.ToString() == "2")
            {
                if (comboBox_MainCustomer.SelectedValue != null)
                {
                    List<Public.CAttLiaisoner> catt = new List<LawtechPTSystemByFirm.Public.CAttLiaisoner>();
                    Public.CAttLiaisoner.ReadList(ref catt, string.Format(" AttorneyKey={0} and Quit<>1  " , comboBox_MainCustomer.SelectedValue.ToString()));
                  
                    attLiaisonerTBindingSource1.DataSource = catt;
                }
            }
            else
            {
                if (txt_ApplicantKeys.Text != "")
                    GetLiaisonerTOnline(txt_ApplicantKeys.Text);
            }
        }

        private void chb_IsBySelf_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;

            cb_Attorney.Enabled = cb_AttorneyTransactor.Enabled = txt_AttorneyRefNo.Enabled = !cb.Checked;
            if (cb.Checked == true)
            {
                txt_AttorneyRefNo.BackColor = Color.WhiteSmoke;
                txt_AttorneyRefNo.Text = "";
            }
            else
            {
                txt_AttorneyRefNo.BackColor = Color.White;
            }
        }

        #region cb_Attorney_SelectedIndexChanged
        private void cb_Attorney_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Attorney.SelectedValue != null)
            {
                this.attLiaisonerT_AllTableAdapter.Fill(this.dataSet_Drop.AttLiaisonerT_All, (int)cb_Attorney.SelectedValue);
            }
            else
            {
                this.attLiaisonerT_AllTableAdapter.Fill(this.dataSet_Drop.AttLiaisonerT_All, -1);
            }
        }
        #endregion

        private void maskedTextBox_EarlyPriorityDate_DoubleClick(object sender, EventArgs e)
        {
            MaskedTextBox mtb = (MaskedTextBox)sender;
            DateTime dt;
            bool IsSuccess = DateTime.TryParse(mtb.Text, out dt);
            if (!IsSuccess)
            {
                mtb.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }
        }

        #region comboBox_Country_SelectedIndexChanged
        private void comboBox_Country_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkBox_All.Checked == false)
            {
                if (comboBox_Country.SelectedValue != null)
                {
                    this.attorneyTTableAdapter.FillByCountry(this.dataSet_Drop.AttorneyT, comboBox_Country.SelectedValue.ToString());
                }
                else
                {
                    this.attorneyTTableAdapter.FillByCountry(this.dataSet_Drop.AttorneyT, "--");
                }
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

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            US.SelectApplicant app = new US.SelectApplicant();

            app.ApplicantNames = txt_ApplicantNames.Text;
            app.ApplicantKeys = txt_ApplicantKeys.Text;

            if (app.ShowDialog() == DialogResult.OK)
            {
                IsChangeApp = true;

                txt_ApplicantNames.Text = app.ApplicantNames;
                txt_ApplicantKeys.Text = app.ApplicantKeys;
                              
                comboBox_DelegateType_SelectedIndexChanged(comboBox_DelegateType, null);
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





        private void AddPatent_KeyDown(object sender, KeyEventArgs e)
        {
            Public.Utility.ControlTab(e);
        }

     

        #region 事務所快顯
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "ToolStripMenuItem_All":
                    checkBox_All.Checked = true;
                    attorneyTBindingSource.Filter = "";
                    break;
                case "ToolStripMenuItem_CurrentCountry":
                    if (comboBox_Country.SelectedValue != null)
                    {
                        checkBox_All.Checked = false;
                        attorneyTBindingSource.Filter = "CountrySymbol ='" + comboBox_Country.SelectedValue.ToString() + "'";
                    }
                    break;
            }
        }
        #endregion

        private void contextMenuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "ToolStripMenuItem_All2":
                    checkBox_All.Checked = true;
                    attorneyTBindingSource1.Filter = "";
                    break;
                case "ToolStripMenuItem_CurrentCountry2":
                    if (comboBox_Country.SelectedValue != null)
                    {
                        checkBox_All.Checked = false;
                        attorneyTBindingSource1.Filter = "CountrySymbol ='" + comboBox_Country.SelectedValue.ToString() + "'";
                    }
                    break;
            }
        }


    }
}
