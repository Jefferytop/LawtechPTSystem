using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace LawtechPTSystem.AddFrom
{
    public partial class AddPatent : Form
    {
        public AddPatent()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddPatent_Load(object sender, EventArgs e)
        {
           // this.qS_DataSet.EnforceConstraints = false;
            this.delegateFeatureTTableAdapter.Fill(this.dataSet_Drop.DelegateFeatureT);
            
            this.attorneyTTableAdapter1.Fill(this.dataSet_Attorney.AttorneyT);
                       
            this.delegateTypeTableAdapter.Fill(this.dataSet_Drop.DelegateType);
            this.applicantT_DropTableAdapter.Fill(this.qS_DataSet.ApplicantT_Drop);
            this.countryT_DropTableAdapter.Fill(this.qS_DataSet.CountryT_Drop);
            this.patISexamTTableAdapter.Fill(this.dataSet_Drop.PatISexamT);
            this.pattPriorityBaseTTableAdapter.Fill(this.dataSet_Drop.PattPriorityBaseT);
            
            
            if (combo_Country.SelectedValue != null)
            {
                attorneyTBindingSource1.Filter = " CountrySymbol ='" + combo_Country.SelectedValue.ToString() + "'";
            }


            this.worker_QuitNTableAdapter.Fill(this.qS_DataSet.Worker_QuitN);
            this.pATFeatureTTableAdapter.FillPatFeature(this.qS_DataSet.PATFeatureT);
            this.kindforPatTableAdapter.FillbyPatKind(this.qS_DataSet.KindforPat);
            DataRow dr = this.qS_DataSet.KindforPat.NewRow();
            dr["Kind"] = "";
            dr["KindSN"] = -1;
            this.qS_DataSet.KindforPat.Rows.InsertAt(dr,0);
            Combo_Kind.SelectedIndex = 1;

            Public.DLL dll = new Public.DLL();
            chb_IsBySelf.Checked = true;

            Combo_ClientWorker.SelectedValue = Properties.Settings.Default.WorkerKEY;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ( combo_Country.SelectedValue != null && txt_PatNo.Text.Trim() != "")
            {
                Public.CPatentManagement cfile = new Public.CPatentManagement();
                string strFileNO = txt_PatNo.Text.Trim();
                bool IsPatentNo = false;
                cfile.CheckValueExist("PatentNo", strFileNO, ref IsPatentNo);
                if (IsPatentNo)
                {
                    MessageBox.Show("【申請案卷號】重覆，\r\n   請修改【申請案卷號】!!");
                    txt_PatNo.Focus();
                    return;
                }

                cfile.ApplicantNames = txt_ApplicantNames.Text;
                cfile.ApplicantKeys = txt_ApplicantKeys.Text;

                cfile.CountrySymbol = combo_Country.SelectedValue.ToString();
                cfile.PatentNo = strFileNO;
                cfile.Title = txt_title.Text;
                cfile.TitleEn = txt_TitleEn.Text;
                cfile.PatentNo_Old = txt_FileNo_Old.Text;
                cfile.ECode = txt_Ecode.Text;
                cfile.ApplicationNo = txt_ApplicationNo.Text;

                cfile.Kind = Combo_Kind.SelectedValue.ToString();
                cfile.Nature = (int)Combo_Nature.SelectedValue;
                cfile.Inventor = txt_Inventor.Text;
                if (Combo_ClientWorker.SelectedValue != null)//申請案承辦人
                {
                    cfile.ClientWorker = (int)Combo_ClientWorker.SelectedValue;
                }


                if (Combo_ISExam.SelectedValue != null) cfile.ISexam = (int)Combo_ISExam.SelectedValue;//審查請求

                if (Combo_PriorityBase.SelectedValue != null) cfile.Priority = (int)Combo_PriorityBase.SelectedValue;//優先權 

                //if (txt_InventerKEY.Text != "")
                //    cfile.IneventerMan = int.Parse(txt_InventerKEY.Text);//申請案聯絡人

                
                
                cfile.Remark = txt_Remark.Text;
                cfile.Status = 3;//預設為待處理
                cfile.StatusExplain = DateTime.Now.ToShortDateString() + "建立";
                cfile.AddDay = 0;

                //引案
                cfile.Introducer = txt_Introducer.Text;
                DateTime dtIntroductionDate;
                bool IsIntroductionDate = DateTime.TryParse(mask_IntroductionDate.Text, out dtIntroductionDate);
                if (IsIntroductionDate)
                {
                    cfile.IntroductionDate = dtIntroductionDate;
                }
                else
                {
                    cfile.IntroductionDate = null;
                }

                cfile.IsBySelf = chb_IsBySelf.Checked;

                //委託類型
                cfile.DelegateFeatureKey = (int)comboBox_DelegateType.SelectedValue;

                //委託類型
                cfile.DelegateType = (int)comboBox_DelegateType.SelectedValue;
                
                
                //四種狀況
                //申請人-->本所-->複代(國外案)
                //申請人-->本所(國內案)
                //國內委辦所-->本所-->複代(國外案)
                //國外委辦所-->本所(國內案)
                if (cfile.DelegateType == 2)//本所直接辦理                
                {
                    if (comboBox_MainCustomer.SelectedValue != null)
                    {
                        cfile.MainCustomer = (int)comboBox_MainCustomer.SelectedValue;
                    }
                }

                if (cb_MainCustomerLiaisoner.SelectedValue != null)
                {
                    cfile.MainCustomerTransactor = (int)cb_MainCustomerLiaisoner.SelectedValue;
                }

                //主要委託人--貴方案號
                cfile.MainCustomerRefNo = txt_MainCustomerRefNo.Text;

                if (!cfile.IsBySelf.Value)//非本所直接辦理
                {
                    //承辦事務所
                    if (cb_Attorney.SelectedValue != null)
                    {
                        cfile.Attorney = (int)cb_Attorney.SelectedValue;
                    }

                    //對方案號
                    cfile.AttorneyRefNo = txt_AttorneyRefNo.Text;

                    //承辦事務所 聯絡窗口
                    if (cb_AttorneyTransactor.SelectedValue != null)
                    {
                        cfile.AttorneyTransactor = (int)cb_AttorneyTransactor.SelectedValue;
                    }
                }
              

                #region Old Code
                /*
                if (cfile.DelegateType == 1)//申請人直接委託
                {
                    //主委託人
                    cfile.MainCustomerRefNo = txt_MainCustomerRefNo.Text;
                    if (cb_MainCustomerLiaisoner.SelectedValue != null)
                    {
                        cfile.MainCustomerTransactor = (int)cb_MainCustomerLiaisoner.SelectedValue;
                    }

                    //本所直接處理
                    cfile.IsBySelf = chb_IsBySelf.Checked;

                    if (!cfile.IsBySelf)
                    {
                        if (cb_Attorney.SelectedValue != null)
                        {
                            cfile.Attorney = (int)cb_Attorney.SelectedValue;
                            if (cb_AttorneyTransactor.SelectedValue != null)
                            {
                                cfile.AttorneyTransactor = (int)cb_AttorneyTransactor.SelectedValue;
                            }
                        }

                        cfile.AttorneyRefNo = txt_AttorneyRefNo.Text;
                    }
                }
                else//複代委託, 存到Attorney、AttorneyRefNo、AttorneyTransactor
                {
                    if (comboBox_MainCustomer.SelectedValue != null)
                    {
                        cfile.MainCustomer = (int)comboBox_MainCustomer.SelectedValue;
                    }
                    cfile.MainCustomerRefNo = txt_MainCustomerRefNo.Text;

                    if (cb_MainCustomerLiaisoner.SelectedValue != null)
                    {
                        cfile.MainCustomerTransactor = (int)cb_MainCustomerLiaisoner.SelectedValue;
                    }

                    #region 複代委託，本所再委託其他事務所
                    if (!chb_IsBySelf.Checked)//不是本所辦理
                    {                       
                        if (cb_Attorney.SelectedValue != null)
                        {
                            cfile.Attorney = (int)cb_Attorney.SelectedValue;
                        }

                        cfile.AttorneyRefNo = txt_AttorneyRefNo.Text;

                        if (cb_AttorneyTransactor.SelectedValue != null)
                        {
                            cfile.AttorneyTransactor = (int)cb_AttorneyTransactor.SelectedValue;
                        }
                    }
                    #endregion
                }
                 */
                #endregion


                Public.PublicForm Forms = new Public.PublicForm();
                //cfile.SetDataTable(Forms.PATMF.dt_PatentManagement);
                cfile.Creator = Properties.Settings.Default.WorkerName;
                cfile.Create();

                if (cfile.DelegateType == 1)
                {
                    cfile.MainCustomer = cfile.PatentID;
                    cfile.Update();
                }

                #region 申請人 PatentApplicant
                //申請人               
                Public.CPatentApplicant ptApp = new Public.CPatentApplicant();
                ptApp.Delete("PatentID=" + cfile.PatentID.ToString());

                string[] apps = txt_ApplicantKeys.Text.Split(',');
                for (int iApp = 0; iApp < apps.Length; iApp++)
                {
                    if (apps[iApp] != "")
                    {
                        ptApp.PatentID = cfile.PatentID;
                        ptApp.ApplicantKey = int.Parse(apps[iApp]);
                        ptApp.Create();
                    }
                }
                #endregion

                if (Forms.PatListMF != null)
                {

                    DataRow dr = Forms.PatListMF.DT_PatentList.NewRow();
                    DataRow drV = Public.CPatentPublicFunction.GetPatentListDataRow(cfile.PatentID.ToString());
                    dr.ItemArray = drV.ItemArray;                   

                    Forms.PatListMF.DT_PatentList.Rows.Add(dr);
                 
                }

                #region ========建立專利案件資料夾========
                Public.DLL dll = new Public.DLL();
                dll.CreatFolder(Public.CreateFolerdMode.Patent, cfile.PatentID.ToString());
                #endregion

                MessageBox.Show("新增成功 " + cfile.PatentNo);

                this.Close();

            }
            else
            {
                MessageBox.Show("請輸入一個有效的申請案卷號");
            }
        }

       

       
        private void but_AutoNumber_Click(object sender, EventArgs e)
        {
            //int iCount = GetPatentSerialNumber();
            //txt_PatNo.Text =combo_Country.SelectedValue.ToString()+ DateTime.Now.Year.ToString() + iCount.ToString("D4") + "-" + txt_ApplicantSymbol.Text ;
            //lab_noticeNo.Visible = true;
        }


        public int GetPatentSerialNumber()
        {
            string strSQL = "SELECT max(cast(right(left(Replace(patentNo,PatentManagementT.country,''),8 ),4) as int))+1 FROM PatentManagementT  where Year( UpbuildDate) =Year(getDate()) ";

            Public.DLL dll = new Public.DLL();

            object obj=dll.SQLexecuteScalar(strSQL);
            if (obj != DBNull.Value && obj!=null)
            {
                return int.Parse(obj.ToString());
            }
            else
            {
                return 1;
            }
        }

        private void combo_Country_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_Country.SelectedValue != null)
            {
                //this.dataSet_Drop.PatComitContentT.Rows.Clear();
                //this.patComitContentTTableAdapter.Fill(this.dataSet_Drop.PatComitContentT, combo_Country.SelectedValue.ToString());

                this.attorneyTTableAdapter2.FillByCountry(this.dataSet_Drop.AttorneyT, combo_Country.SelectedValue.ToString());
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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
                    List<Public.CAttLiaisoner> catt = new List<Public.CAttLiaisoner>();
                    Public.CAttLiaisoner.ReadList(ref catt, "AttorneyKey=" + comboBox_MainCustomer.SelectedValue.ToString());
                    attLiaisonerTBindingSource1.DataSource = catt;
                   
                }
                cb_MainCustomerLiaisoner.DataSource = attLiaisonerTBindingSource1;
                cb_MainCustomerLiaisoner.DisplayMember="Liaisoner";
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

        #region GetLiaisonerTOnline
        /// <summary>
        /// 取得多家申請人的聯絡窗口 
        /// </summary>
        /// <param name="ApplicantKey"></param>
        private void GetLiaisonerTOnline(string ApplicantKey)
        {
            string strSQL =string.Format( @"SELECT          - 1 AS LiaisonerKey, '' AS Liaisoner
UNION
SELECT          LiaisonerKey, Liaisoner
FROM              LiaisonerT
WHERE          (ApplicantKey in ({0}) ) and Quit<>1 ", ApplicantKey);
            Public.DLL dll = new Public.DLL();
            dll.FetchDataTable(strSQL, this.qS_DataSet.LiaisonerTOnline);

        }
        #endregion

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

       

        #region 主委託人 --複代
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_DelegateType.SelectedValue.ToString() == "2")
            {
                if (comboBox_MainCustomer.SelectedValue != null)
                {
                    List<Public.CAttLiaisoner> catt = new List<Public.CAttLiaisoner>();
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

        private void mask_IntroductionDate_DoubleClick(object sender, EventArgs e)
        {
            MaskedTextBox mtb = (MaskedTextBox)sender;
            DateTime dt;
            bool IsSuccess = DateTime.TryParse(mtb.Text, out dt);
            if (!IsSuccess)
            {
                mtb.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }
        }

        private void but_CheckPatentNo_Click(object sender, EventArgs e)
        {
            if (txt_PatNo.Text.Trim() != "")
            {
                Public.CPatentManagement cfile = new Public.CPatentManagement();
                bool isPatentNo = false;
                cfile.CheckValueExist("PatentNo", txt_PatNo.Text.Trim(), ref isPatentNo);
                if (isPatentNo)
                {
                    MessageBox.Show("【申請案卷號】重覆，\r\n   請修改【申請案卷號】!!");
                    txt_PatNo.Focus();
                    return;
                }
                else
                {
                    MessageBox.Show("【申請案卷號：" + txt_PatNo.Text.Trim() + "】可使用!!");
                }
            }
        }

        #region 選取申請人
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            US.SelectApplicant app = new US.SelectApplicant();

            app.ApplicantNames = txt_ApplicantNames.Text;
            app.ApplicantKeys = txt_ApplicantKeys.Text;

            if (app.ShowDialog() == DialogResult.OK)
            {               

                txt_ApplicantNames.Text = app.ApplicantNames;
                txt_ApplicantKeys.Text = app.ApplicantKeys;

                comboBox1_SelectedIndexChanged(comboBox_DelegateType,null);
            }
        }
        #endregion

        private void AddPatent_KeyDown(object sender, KeyEventArgs e)
        {
            Public.Utility.ControlTab(e);
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
                    if (combo_Country.SelectedValue != null)
                    {
                        checkBox_All.Checked = false;
                        attorneyTBindingSource1.Filter = "CountrySymbol ='" + combo_Country.SelectedValue.ToString() + "'";
                    }
                    break;
            }
        }

      
        private void cb_Attorney_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Attorney.SelectedValue != null)
            {
                this.attLiaisonerTTableAdapter1.FillByWindow(this.dataSet_Attorney.AttLiaisonerT, (int)cb_Attorney.SelectedValue, (int)Public.WindowType.PatContract);
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
                    if (combo_Country.SelectedValue != null)
                    {
                        checkBox_All.Checked = false;
                        attorneyTBindingSource.Filter = "CountrySymbol ='" + combo_Country.SelectedValue.ToString() + "'";
                    }
                    break;
            }
        }

        #endregion

        private void mask_IntroductionDate_Leave(object sender, EventArgs e)
        {
            MaskedTextBox mak = (MaskedTextBox)sender;
            Public.Utility.CheckMaskedtextbox(mak);
        }
    }
}
