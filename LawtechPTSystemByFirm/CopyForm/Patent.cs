using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.CopyForm
{
    public partial class Patent : Form
    {
        public Patent()
        {
            InitializeComponent();
        }

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

        #region private void Patent_Load(object sender, EventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Patent_Load(object sender, EventArgs e)
        {

            this.attorneyTTableAdapter1.Fill(this.dataSet_Attorney.AttorneyT);

            this.worker_QuitNTableAdapter.Fill(this.qS_DataSet.Worker_QuitN);

            this.delegateTypeTableAdapter.Fill(this.dataSet_Drop.DelegateType);
            this.patFeatureTTableAdapter.Fill(this.dataSet_Drop.PatFeatureT);
            this.patISexamTTableAdapter.Fill(this.dataSet_Drop.PatISexamT);
            this.pattPriorityBaseTTableAdapter.Fill(this.dataSet_Drop.PattPriorityBaseT);
            this.kindforPatTableAdapter.FillbyPatKind(this.qS_DataSet.KindforPat);
            this.patStatusT_DropTableAdapter.Fill(this.qS_DataSet._PatStatusT_Drop);
            this.countryT_DropTableAdapter.Fill(this.qS_DataSet.CountryT_Drop);
            //this.applicantT_DropTableAdapter.Fill(this.qS_DataSet.ApplicantT_Drop);
            this.attorneyTTableAdapter.Fill(this.dataSet_Drop.AttorneyT);
            Public.CPatentManagement pat = new LawtechPTSystemByFirm.Public.CPatentManagement();
            Public.CPatentManagement.ReadOne(Patent_ID, ref pat);


            //txt_PatentNo.Text = pat.PatentNo;
            txt_title.Text = pat.Title;
            txt_FileNo_Old.Text = pat.PatentNo_Old;
            txt_TitleEn.Text = pat.TitleEn;
            //comboBox_Applicant.SelectedValue = pat.Applicant;
            txt_ApplicantKeys.Text = pat.ApplicantKeys;
            txt_ApplicantNames.Text = pat.ApplicantNames;
            txt_EarlyPriorityNo.Text = pat.EarlyPriorityNo;

            //Combo_AttorneyFile.SelectedValue = pat.Attorney;
            //Combo_AttLiaisoner.SelectedValue = pat.AttorneyTransactor;
            txt_AttorneyRefNo.Text = pat.AttorneyRefNo;
            Combo_Priority.SelectedValue = pat.Priority;
            if (pat.EarlyPriorityDate.HasValue)
            {
                maskedTextBox_EarlyPriorityDate.Text = pat.EarlyPriorityDate.Value.ToString("yyyy/MM/dd");
            }
            Combo_ISExam.SelectedValue = pat.ISexam;

            if (!string.IsNullOrEmpty(pat.CountrySymbol))
            {
                comboBox_Country.SelectedValue = pat.CountrySymbol;
            }

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

            cbm_ClientWorker.SelectedValue = Properties.Settings.Default.WorkerKEY;

            if (pat.EarlyMotherDate.HasValue)
            {
                maskedTextBox_EarlyMotherDate.Text = pat.EarlyMotherDate.Value.ToString("yyyy/MM/dd");
            }
            if (pat.ApplicationDate.HasValue)
            {
                maskedTextBox_ApplicationDate.Text = pat.ApplicationDate.Value.ToString("yyyy/MM/dd");
            }
            txt_ApplicationNo.Text = pat.ApplicationNo;

            if (pat.Pubdate.HasValue)
            {
                maskedTextBox_Pubdate.Text = pat.Pubdate.Value.ToString("yyyy/MM/dd");
            }
            txt_PubNo.Text = pat.PubNo;

            if (pat.AllowDate.HasValue)
            {
                maskedTextBox_AllowDate.Text = pat.AllowDate.Value.ToString("yyyy/MM/dd");
            }

            txt_Inventor.Text = pat.Inventor;
            if (pat.AllowPubDate.HasValue)
            {
                maskedTextBox_AllowPubdate.Text = pat.AllowPubDate.Value.ToString("yyyy/MM/dd");
            }
            txt_AllowPubNo.Text = pat.AllowPubNo;
            if (pat.GetDate.HasValue)
            {
                maskedTextBox_GetDate.Text = pat.GetDate.Value.ToString("yyyy/MM/dd");
            }
            txt_CertifyNo.Text = pat.CertifyNo;
            if (pat.RegisterDate.HasValue)
            {
                maskedTextBox_Registerdate.Text = pat.RegisterDate.Value.ToString("yyyy/MM/dd");
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
                maskedTextBox_RenewTo.Text = pat.RenewTo.Value.ToString("yyyy/MM/dd");
            }

            if (pat.CloseDate.HasValue)
            {
                maskedTextBox_CloseDate.Text = pat.CloseDate.Value.ToString("yyyy/MM/dd");
            }
            txt_CloseCaus.Text = pat.CloseCaus;
            txt_Remark.Text = pat.Remark;

            comboBox_DelegateType.SelectedValue = pat.DelegateType == -1 ? 1 : pat.DelegateType;
            comboBox_DelegateType_SelectedIndexChanged(comboBox_DelegateType, null);
            if (pat.DelegateType == 1)//申請人直接委託
            {
                txt_MainCustomer.Text = comboBox_Applicant.Text;
                txt_MainCustomerRefNo.Text = pat.MainCustomerRefNo;
                cb_MainCustomerLiaisoner.SelectedValue =pat.MainCustomerTransactor.HasValue? pat.MainCustomerTransactor.Value:-1;

                chb_IsBySelf.Checked = pat.IsBySelf.HasValue ? pat.IsBySelf.Value : false;
                if (!chb_IsBySelf.Checked)
                {
                    cb_Attorney.SelectedValue =pat.Attorney.HasValue? pat.Attorney.Value:-1;
                    txt_AttorneyRefNo.Text = pat.AttorneyRefNo;
                    if (pat.AttorneyTransactor != -1)
                    {
                        this.attLiaisonerT_AllTableAdapter.Fill(this.dataSet_Drop.AttLiaisonerT_All, (int)cb_Attorney.SelectedValue);

                        cb_AttorneyTransactor.SelectedValue =pat.AttorneyTransactor.HasValue? pat.AttorneyTransactor:-1;
                    }
                }
            }
            else//複代委託
            {
                comboBox_MainCustomer.SelectedValue = pat.Attorney.HasValue ? pat.Attorney.Value : -1;
                txt_MainCustomerRefNo.Text = pat.MainCustomerRefNo;
                cb_MainCustomerLiaisoner.SelectedValue = pat.AttorneyTransactor.HasValue ? pat.AttorneyTransactor : -1;
            }

            txt_Introducer.Text = pat.Introducer;

            if (pat.IntroductionDate.HasValue)
                mask_IntroductionDate.Text = pat.IntroductionDate.Value.ToString("yyyy/MM/dd");

            if (!Mode)
            {
                panel1.Enabled = Mode;
                but_OK.Visible = Mode;
            }
        } 
        #endregion

        private void but_OK_Click(object sender, EventArgs e)
        {
            Public.CPatentManagement pat = new LawtechPTSystemByFirm.Public.CPatentManagement();

            if (txt_PatentNo.Text.Trim() == "")
            {
                MessageBox.Show("【申請案卷號】不得為空白，\r\n   請修改【申請案卷號】!!");
                txt_PatentNo.Focus();
                return;
            }
            bool isPatentNo = false;
            pat.CheckValueExist("PatentNo", txt_PatentNo.Text.Trim(),ref isPatentNo);
            if (isPatentNo)
            {
                MessageBox.Show("【申請案卷號】重覆，\r\n   請修改【申請案卷號】!!");
                txt_PatentNo.Focus();
                return;
            }

            pat.PatentNo = txt_PatentNo.Text.Trim();
            pat.Title = txt_title.Text;
            pat.PatentNo_Old = txt_FileNo_Old.Text;
            pat.TitleEn = txt_TitleEn.Text;
            pat.Applicant = comboBox_Applicant.SelectedValue != null ? (int)comboBox_Applicant.SelectedValue : -1;
            pat.EarlyPriorityNo = txt_EarlyPriorityNo.Text;

            //性質
            pat.Nature = comboBox_Nature.SelectedValue != null ? (int)comboBox_Nature.SelectedValue : -1;
            //國別 
            pat.CountrySymbol = comboBox_Country.SelectedValue != null ? comboBox_Country.SelectedValue.ToString() : "";

            //種類
            pat.Kind = comboBox_Kind.SelectedValue != null ? comboBox_Kind.SelectedValue.ToString() : "";

            //狀態
            pat.Status = comboBox_Status.SelectedValue != null ? (int)comboBox_Status.SelectedValue : -1;
            //狀態描述
            pat.StatusExplain = txt_StatusExplain.Text;

            pat.Priority = Combo_Priority.SelectedValue != null ? (int)Combo_Priority.SelectedValue : -1;
            pat.PubNo = txt_PubNo.Text;
            pat.CloseCaus = txt_CloseCaus.Text;
            pat.Remark = txt_Remark.Text;
            pat.ApplicationNo = txt_ApplicationNo.Text;
            pat.ISexam = Combo_ISExam.SelectedValue != null ? (int)Combo_ISExam.SelectedValue : -1;
            pat.ClientWorker = cbm_ClientWorker.SelectedValue != null ? (int)cbm_ClientWorker.SelectedValue : -1;
            pat.Inventor = txt_Inventor.Text;
            pat.AllowPubNo = txt_AllowPubNo.Text;
            pat.CertifyNo = txt_CertifyNo.Text;
            pat.AddDay = int.Parse(NumericUpDown_AddDay.Value.ToString());
            pat.PayYear = NumericUpDown_PayYear.Value;
            pat.Introducer = txt_Introducer.Text;

            pat.DelegateType = (int)comboBox_DelegateType.SelectedValue;

            if (pat.DelegateType == 1)//申請人直接委託
            {
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

                //本所直接處理
                pat.IsBySelf = chb_IsBySelf.Checked;

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
            else//複代委託, 將主要委託人存到Attorney、MainCustomerRefNo、AttorneyTransactor
            {
                if (comboBox_MainCustomer.SelectedValue != null)
                {
                    pat.Attorney = (int)comboBox_MainCustomer.SelectedValue;
                }
                else
                {
                    pat.Attorney = -1;
                }
                pat.MainCustomerRefNo = txt_MainCustomerRefNo.Text;
                if (cb_MainCustomerLiaisoner.SelectedValue != null)
                {
                    pat.AttorneyTransactor = (int)cb_MainCustomerLiaisoner.SelectedValue;
                }
                else
                {
                    pat.AttorneyTransactor = -1;
                }

                pat.IsBySelf = false;
                pat.AttorneyRefNo = "";
            }

            DateTime IntroductionDate ;
            bool IsIntroductionDate = DateTime.TryParse(mask_IntroductionDate.Text, out IntroductionDate);
            if (IsIntroductionDate) pat.IntroductionDate = IntroductionDate;
            else pat.IntroductionDate = null;

            DateTime EarlyPriority ;
            bool IsEarlyPriority = DateTime.TryParse(maskedTextBox_EarlyPriorityDate.Text, out EarlyPriority);
            if (IsEarlyPriority) pat.EarlyPriorityDate = EarlyPriority;
            else pat.EarlyPriorityDate = null;

            DateTime EarlyMother ;
            bool IsEarlyMother = DateTime.TryParse(maskedTextBox_EarlyMotherDate.Text, out EarlyMother);
            if (IsEarlyMother) pat.EarlyMotherDate = EarlyMother;
            else pat.EarlyMotherDate = null;

            DateTime Application ;
            bool IsApplication = DateTime.TryParse(maskedTextBox_ApplicationDate.Text, out Application);
            if (IsApplication) pat.ApplicationDate = Application;
            else pat.ApplicationDate = null;


            DateTime Pubdate;
            bool IsPubdate = DateTime.TryParse(maskedTextBox_Pubdate.Text, out Pubdate);
            if (IsPubdate) pat.Pubdate = Pubdate;
            else pat.Pubdate = null;

            DateTime AllowDate;
            bool IsAllowDate = DateTime.TryParse(maskedTextBox_AllowDate.Text, out AllowDate);
            if (IsAllowDate) pat.AllowDate = AllowDate;
            else pat.AllowDate = null;

            DateTime AllowPubDate ;
            bool IsAllowPubDate = DateTime.TryParse(maskedTextBox_AllowPubdate.Text, out AllowPubDate);
            if (IsAllowPubDate) pat.AllowPubDate = AllowPubDate;
            else pat.AllowPubDate = null;

            DateTime GetDate ;
            bool IsGetDate = DateTime.TryParse(maskedTextBox_GetDate.Text, out GetDate);
            if (IsGetDate) pat.GetDate = GetDate;
            else pat.GetDate = null;

            DateTime RegisterDate ;
            bool IsRegisterDate = DateTime.TryParse(maskedTextBox_Registerdate.Text, out RegisterDate);
            if (IsRegisterDate) pat.RegisterDate = RegisterDate;
            else pat.RegisterDate = null;

            DateTime DueDate ;
            bool IsDueDate = DateTime.TryParse(maskedTextBox_DueDate.Text, out DueDate);
            if (IsDueDate) pat.DueDate = DueDate;
            else pat.DueDate = null;

            DateTime RenewTo ;
            bool IsRenewTo = DateTime.TryParse(maskedTextBox_RenewTo.Text, out RenewTo);
            if (IsRenewTo) pat.RenewTo = RenewTo;
            else pat.RenewTo = null;

            DateTime CloseDate ;
            bool IsCloseDate = DateTime.TryParse(maskedTextBox_CloseDate.Text, out CloseDate);
            if (IsCloseDate) pat.CloseDate = CloseDate;
            else pat.CloseDate = null;

          
            pat.LastModifyWorker = Properties.Settings.Default.WorkerName;
            pat.ApplicantNames = txt_ApplicantNames.Text;
            pat.ApplicantKeys = txt_ApplicantKeys.Text;

            pat.Create();

           
                //申請人               
                Public.CPatentApplicant ptApp = new Public.CPatentApplicant();
                ptApp.Delete("PatentID=" + pat.PatentID.ToString(),"");

                string[] apps = txt_ApplicantKeys.Text.Split(';');
                for (int iApp = 0; iApp < apps.Length; iApp++)
                {
                    if (apps[iApp] != "")
                    {
                        ptApp.PatentID = pat.PatentID;
                        ptApp.ApplicantKey = int.Parse(apps[iApp]);
                        ptApp.Create();
                    }
                }
            
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            if (Forms.PatListMF != null)
            {
                DataRow drCopy = Forms.PatListMF.DT_PatentList.Rows.Find(pat.PatentID);
                if (drCopy == null)
                {
                    DataRow dr = Forms.PatListMF.DT_PatentList.NewRow();
                    DataRow drV = Public.CPatentPublicFunction.GetPatentListDataRow(pat.PatentID.ToString());
                    dr.ItemArray = drV.ItemArray;
                    Forms.PatListMF.DT_PatentList.Rows.Add(dr);

                }
            }
            MessageBox.Show("新增申請案成功");
            this.Close();
        }



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
WHERE          (ApplicantKey in ({0}) )", ApplicantKey);
            Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
            dll.FetchDataTable(strSQL, this.qS_DataSet.LiaisonerTOnline);

        }
        #endregion



        private void comboBox_Applicant_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_DelegateType.SelectedValue.ToString() == "1")//委託類型為申請人直接委託
            {
                txt_MainCustomer.Text = comboBox_Applicant.Text;

                if (comboBox_Applicant.SelectedValue != null)
                {
                    this.liaisonerTTableAdapter.Fill(this.qS_DataSet.LiaisonerT, (int)comboBox_Applicant.SelectedValue);
                }
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

        private void cb_Attorney_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Attorney.SelectedValue != null)
            {
                this.attLiaisonerTTableAdapter1.FillByWindow(this.dataSet_Attorney.AttLiaisonerT, (int)cb_Attorney.SelectedValue, (int)Public.WindowType.PatContract);
            }
        }

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
                cb_MainCustomerLiaisoner.DisplayMember = "Liaisoner";
                cb_MainCustomerLiaisoner.ValueMember = "LiaisonerKey";

                //this.liaisonerTOnlineTableAdapter.FillByWindow(this.qS_DataSet.LiaisonerTOnline, (int)Combo_Applicant.SelectedValue, (int)Public.WindowType.PatContract);
                if (txt_ApplicantKeys.Text != "")
                {
                    GetLiaisonerTOnline(txt_ApplicantKeys.Text);
                }

            }
        }

       

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox_Country_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox_Country.SelectedValue != null)
            {
                this.attorneyTTableAdapter.FillByCountry(this.dataSet_Drop.AttorneyT, comboBox_Country.SelectedValue.ToString());
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            US.SelectApplicant app = new US.SelectApplicant();

            app.ApplicantNames = txt_ApplicantNames.Text;
            app.ApplicantKeys = txt_ApplicantKeys.Text;

            if (app.ShowDialog() == DialogResult.OK)
            {
               

                txt_ApplicantNames.Text = app.ApplicantNames;
                txt_ApplicantKeys.Text = app.ApplicantKeys;

                comboBox_DelegateType_SelectedIndexChanged(comboBox_DelegateType, null);
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
                    if (comboBox_Country.SelectedValue != null)
                    {
                        checkBox_All.Checked = false;
                        attorneyTBindingSource1.Filter = "CountrySymbol ='" + comboBox_Country.SelectedValue.ToString() + "'";
                    }
                    break;
            }
        }


        #region 委託的事務所
        private void contextMenuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "ToolStripMenuItem_All2":
                    checkBox_All.Checked = true;
                    attorneyTBindingSource.Filter = "";
                    break;
                case "ToolStripMenuItem_CurrentCountry2":
                    if (comboBox_Country.SelectedValue != null)
                    {
                        checkBox_All.Checked = false;
                        attorneyTBindingSource.Filter = "Country ='" + comboBox_Country.SelectedValue.ToString() + "'";
                    }
                    break;
            }
        }
        #endregion

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


   
    }


    
}
