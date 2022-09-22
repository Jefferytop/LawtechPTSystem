using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
namespace LawtechPTSystemByFirm.AddFrom
{
    public partial class AddTrademarkControversyManagement : Form
    {
        public AddTrademarkControversyManagement()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region button1_Click
        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_TrademarkNo.Text.Trim() == "")
            {
                MessageBox.Show("請輸入本所案號");
                txt_TrademarkNo.Focus();
                return;
            }
            if (txt_TrademarkName.Text.Trim() == "")
            {
                MessageBox.Show("請輸入商標名稱");
                txt_TrademarkName.Focus();
                return;
            }


            Public.CTrademarkControversyManagement AddCTrademarkManagement = new Public.CTrademarkControversyManagement();

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            DataSet_TrademarkControversy.TrademarkControversyManagementTRow dr = Forms.TrademarkControversyMF.dt_TrademarkControversyManagementT.NewTrademarkControversyManagementTRow();

            AddCTrademarkManagement.TrademarkNo = txt_TrademarkNo.Text;
            dr["TrademarkNo"] = AddCTrademarkManagement.TrademarkNo;

            AddCTrademarkManagement.TrademarkOvertureName = txt_TrademarkOvertureName.Text;
            dr["TrademarkOvertureName"] = AddCTrademarkManagement.TrademarkOvertureName;

            AddCTrademarkManagement.TrademarkName = txt_TrademarkName.Text;
            dr["TrademarkName"] = AddCTrademarkManagement.TrademarkName;

            AddCTrademarkManagement.TrademarOriginalNo = txt_TrademarOriginalNo.Text;
            dr["TrademarOriginalNo"] = AddCTrademarkManagement.TrademarOriginalNo;

            AddCTrademarkManagement.DisagreementNo = txt_DisagreementNo.Text;
            dr["DisagreementNo"] = AddCTrademarkManagement.DisagreementNo;

            //AddCTrademarkManagement.ApplicantKey = Combo_ApplicantKey.SelectedValue != null ? (int)Combo_ApplicantKey.SelectedValue : -1;
            //dr["ApplicantKey"] = AddCTrademarkManagement.ApplicantKey;
            //dr["ApplicantName"] = Combo_ApplicantKey.Text;

            //申請人(串接)
            AddCTrademarkManagement.ApplicantNames = txt_ApplicantNames.Text;
            dr["ApplicantNames"] = AddCTrademarkManagement.ApplicantNames;

            //申請人Key值(串接)
            AddCTrademarkManagement.ApplicantKeys = txt_ApplicantKeys.Text;
            dr["ApplicantKeys"] = AddCTrademarkManagement.ApplicantKeys;   

            //國別
            AddCTrademarkManagement.CountrySymbol = cb_Country.SelectedValue.ToString();
            dr["CountrySymbol"] = AddCTrademarkManagement.CountrySymbol;
            dr["CountryName"] = cb_Country.Text;

            AddCTrademarkManagement.StyleName = cb_StyleName.Text;
            dr["StyleName"] = AddCTrademarkManagement.StyleName;

            //案件類別
            AddCTrademarkManagement.TMTypeName = cb_TypeName.Text;
            dr["TMTypeName"] = AddCTrademarkManagement.TMTypeName;

            //案件類型
            //AddCTrademarkManagement.TMTypeName = cb_TMTypeName.Text;
            //dr["TMTypeName"] = AddCTrademarkManagement.TMTypeName;

            AddCTrademarkManagement.Status = cb_Status.SelectedValue != null ? (int)cb_Status.SelectedValue : -1;
            dr["Status"] = AddCTrademarkManagement.Status;
            dr["StatusName"] = cb_Status.Text;

            AddCTrademarkManagement.StatusExplain = txt_StatusExplain.Text;
            dr["StatusExplain"] = AddCTrademarkManagement.StatusExplain;

            AddCTrademarkManagement.WorkerKey = cb_WorkerName.SelectedValue != null ? (int)cb_WorkerName.SelectedValue : -1;
            dr["WorkerKey"] = AddCTrademarkManagement.WorkerKey;
            


            //該案申請號
            AddCTrademarkManagement.ObjectionApplicationNo = txt_ObjectionApplicationNo.Text;

            //該案申請日
            DateTime dtObjectionApplicationDate;
            bool IsObjectionApplicationDate = DateTime.TryParse(mask_ObjectionApplicationDate.Text, out dtObjectionApplicationDate);
            if (IsObjectionApplicationDate)
            {
                AddCTrademarkManagement.ObjectionApplicationDate = dtObjectionApplicationDate;
            }

            //該案公告日
            DateTime dtObjectionNoticeDate;
            bool IsObjectionNoticeDate = DateTime.TryParse(mask_ObjectionNoticeDate.Text, out dtObjectionNoticeDate);
            if (IsObjectionNoticeDate)
            {
                AddCTrademarkManagement.ObjectionNoticeDate = dtObjectionNoticeDate;
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

            //該案註冊號
            AddCTrademarkManagement.ObjectionRegistrationNo = txt_ObjectionRegistrationNo.Text;

            //被異議/爭議商標名稱
            AddCTrademarkManagement.ObjectionTrademarkName = txt_ObjectionTrademarkName.Text; 

            //被異議商標証號
            AddCTrademarkManagement.ObjectionRegistrationNo = txt_ObjectionRegistrationNo.Text;

            //官方期限
            DateTime dtObjectionDueDate;
            bool IsObjectionDueDate = DateTime.TryParse(maskedTextBox_ObjectionDueDate.Text, out dtObjectionDueDate);
            if (IsObjectionDueDate)
            {
                AddCTrademarkManagement.ObjectionDueDate = dtObjectionDueDate;
            }

            

            //官方期限
            if (AddCTrademarkManagement.ObjectionDueDate.HasValue)
            {
                dr["ObjectionDueDate"] = AddCTrademarkManagement.ObjectionDueDate;
            }
            else
            {
                dr["ObjectionDueDate"] = DBNull.Value;
            }

            DateTime dt_EntrustDate;
            bool IsEntrustDate = DateTime.TryParse(maskedTextBox_EntrustDate.Text, out dt_EntrustDate);
            if (IsEntrustDate)
            {
                AddCTrademarkManagement.EntrustDate = dt_EntrustDate;
                dr["EntrustDate"] = AddCTrademarkManagement.EntrustDate;
            }
           


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

            if (cb_MainCustomerLiaisoner.SelectedValue != null)
            {
                AddCTrademarkManagement.MainCustomerTransactor = (int)cb_MainCustomerLiaisoner.SelectedValue;
            }

            //主要委託人--貴方案號
            AddCTrademarkManagement.MainCustomerRefNo = txt_MainCustomerRefNo.Text;

            if (AddCTrademarkManagement.IsBySelf.HasValue && !AddCTrademarkManagement.IsBySelf.Value)//非本所直接辦理
            {
                //承辦事務所
                if (Combo_OutsourcingAttorney.SelectedValue != null)
                {
                    AddCTrademarkManagement.OutsourcingAttorney = (int)Combo_OutsourcingAttorney.SelectedValue;
                }

                //對方案號
                AddCTrademarkManagement.OutsourcingTrademarkNo = txt_OutsourcingTrademarkNo.Text;

                //承辦事務所 聯絡窗口
                if (Combo_OutsourcingAttorneyWorker.SelectedValue != null)
                {
                    AddCTrademarkManagement.OutsourcingAttorneyWorker = (int)Combo_OutsourcingAttorneyWorker.SelectedValue;
                }
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
                dr["MainCustomerRefNo"] = AddCTrademarkManagement.MainCustomerRefNo;


                if (!AddCTrademarkManagement.IsBySelf.Value)
                {
                    //承辦事務所
                    dr["OutsourcingAttorney"] = AddCTrademarkManagement.OutsourcingAttorney;
                    dr["AttorneyFirm"] = Combo_OutsourcingAttorney.Text;
                    dr["OutsourcingAttorneyWorker"] = AddCTrademarkManagement.OutsourcingAttorneyWorker;
                    dr["AttLiaisoner"] = Combo_OutsourcingAttorneyWorker.Text;
                    dr["OutsourcingTrademarkNo"] = AddCTrademarkManagement.OutsourcingTrademarkNo;
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

                if (AddCTrademarkManagement.IsBySelf.HasValue && !AddCTrademarkManagement.IsBySelf.Value)
                {
                    //承辦事務所
                    dr["OutsourcingAttorney"] = AddCTrademarkManagement.OutsourcingAttorney;
                    if (AddCTrademarkManagement.OutsourcingAttorney != -1)
                    {
                        dr["AttorneyFirm"] = Combo_OutsourcingAttorney.Text;
                    }
                    else
                    {
                        dr["AttorneyFirm"] = "";
                    }
                    dr["OutsourcingAttorneyWorker"] = AddCTrademarkManagement.OutsourcingAttorneyWorker;
                    if (AddCTrademarkManagement.OutsourcingAttorneyWorker != -1)
                    {
                        dr["AttLiaisoner"] = Combo_OutsourcingAttorneyWorker.Text;
                    }
                    else
                    {
                        dr["AttLiaisoner"] = "";
                    }
                    dr["OutsourcingTrademarkNo"] = AddCTrademarkManagement.OutsourcingTrademarkNo;
                }
            }





            DateTime dt_ApplicationDate;
            bool IsApplicationDate = DateTime.TryParse(maskedTextBox_ApplicationDate.Text, out dt_ApplicationDate);
            if (IsApplicationDate)
            {
                AddCTrademarkManagement.ApplicationDate = dt_ApplicationDate;
                dr["ApplicationDate"] = AddCTrademarkManagement.ApplicationDate;
            }
          

            DateTime dt_ObjectionDate;
            bool IsObjectionDate = DateTime.TryParse(maskedTextBox_ObjectionDate.Text, out dt_ObjectionDate);
            if (IsObjectionDate)
            {
                AddCTrademarkManagement.ObjectionDate = dt_ObjectionDate;
                dr["ObjectionDate"] = AddCTrademarkManagement.ObjectionDate;
            }
          

            DateTime dt_RegistrationDate;
            bool IsRegistrationDate = DateTime.TryParse(maskedTextBox_RegistrationDate.Text, out dt_RegistrationDate);
            if (IsRegistrationDate)
            {
                AddCTrademarkManagement.RegistrationDate = dt_RegistrationDate;
                dr["RegistrationDate"] = AddCTrademarkManagement.RegistrationDate;
            }
           

            AddCTrademarkManagement.RegistrationNo = txt_RegistrationNo.Text;
            dr["RegistrationNo"] = AddCTrademarkManagement.RegistrationNo;

            AddCTrademarkManagement.ApplicationNo = txt_ApplicationNo.Text;
            dr["ApplicationNo"] = AddCTrademarkManagement.ApplicationNo;

            AddCTrademarkManagement.RegisterProduct = txt_RegisterProduct.Text;
            dr["RegisterProduct"] = AddCTrademarkManagement.RegisterProduct;

            AddCTrademarkManagement.Remarks = txt_Remarks.Text;
            dr["Remarks"] = AddCTrademarkManagement.Remarks;

            AddCTrademarkManagement.ObjectionClass = txt_ObjectionClass.Text;
            dr["ObjectionClass"] = AddCTrademarkManagement.ObjectionClass;

            AddCTrademarkManagement.ObjectionNo = txt_ObjectionNo.Text;
            dr["ObjectionNo"] = AddCTrademarkManagement.ObjectionNo;

            AddCTrademarkManagement.ObjectionPeople = txt_ObjectionPeople.Text;
            dr["ObjectionPeople"] = AddCTrademarkManagement.ObjectionPeople;

            AddCTrademarkManagement.ObjectionContent = txt_ObjectionContent.Text;
            dr["ObjectionContent"] = AddCTrademarkManagement.ObjectionContent;

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
           

            
            AddCTrademarkManagement.LastModifyWorker = Properties.Settings.Default.WorkerName;

            AddCTrademarkManagement.Create();

            dr["TrademarkControversyID"] = AddCTrademarkManagement.TrademarkControversyID;

            //商標異議案圖
            if (txt_PicPath.Text != "" && File.Exists(txt_PicPath.Text))
            {
                FileInfo Upfile = new FileInfo(txt_PicPath.Text);
                Public.CUpLoadFile uploadfile = new LawtechPTSystemByFirm.Public.CUpLoadFile();
                uploadfile.MainParentID = AddCTrademarkManagement.TrademarkControversyID;
                
                uploadfile.Uploader = Properties.Settings.Default.WorkerName;
                uploadfile.FileDoc = "我方商標圖";
                uploadfile.FileKind = 5;
                uploadfile.FileType = 10;
                AddCTrademarkManagement.PicPath = string.Format(@"{0}\{1}", AddCTrademarkManagement.TrademarkControversyID, Upfile.Name);

                uploadfile.FilePath = AddCTrademarkManagement.PicPath;
                Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
                // string ss = string.Format("{0}\\{1}", dll.TrademarkFolderRoot, uploadfile.FilePath);
                dll.CreatFolder(5, AddCTrademarkManagement.TrademarkControversyID.ToString());
                File.Copy(txt_PicPath.Text, string.Format("{0}\\{1}", dll.TrademarkControversyFolderRoot, uploadfile.FilePath));
                uploadfile.Create();
            }


            //商標異議案圖--被異議人
            if (txt_ObjectionPicPath.Text != "" && File.Exists(txt_ObjectionPicPath.Text))
            {
                FileInfo Upfile = new FileInfo(txt_ObjectionPicPath.Text);
                Public.CUpLoadFile uploadfile = new LawtechPTSystemByFirm.Public.CUpLoadFile();
                uploadfile.MainParentID = AddCTrademarkManagement.TrademarkControversyID;
               
                uploadfile.Uploader = Properties.Settings.Default.WorkerName;
                uploadfile.FileDoc = "被異議人商標圖";
                uploadfile.FileKind = 5;
                uploadfile.FileType = 10;
                AddCTrademarkManagement.ObjectionPicPath = string.Format(@"{0}\{1}", AddCTrademarkManagement.TrademarkControversyID, Upfile.Name);
                uploadfile.FilePath = AddCTrademarkManagement.ObjectionPicPath;
                Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
                // string ss = string.Format("{0}\\{1}", dll.TrademarkFolderRoot, uploadfile.FilePath);
                dll.CreatFolder(5, AddCTrademarkManagement.TrademarkControversyID.ToString());
                File.Copy(txt_ObjectionPicPath.Text, string.Format("{0}\\{1}", dll.TrademarkControversyFolderRoot, uploadfile.FilePath));
                uploadfile.Create();
            }

            dr["PicPath"] = AddCTrademarkManagement.PicPath;

            dr["ObjectionPicPath"] = AddCTrademarkManagement.ObjectionPicPath;

            AddCTrademarkManagement.Update();

            Forms.TrademarkControversyMF.dt_TrademarkControversyManagementT.Rows.Add(dr);
            Forms.TrademarkControversyMF.dt_TrademarkControversyManagementT.AcceptChanges();

            //Public.CTrademarkClassSelect selectClass = new LawtechPTSystemByFirm.Public.CTrademarkClassSelect("1=0");

            //for (int iRow = 0; iRow < dataGridView1.Rows.Count; iRow++)
            //{
            //    selectClass.TrademarkID = AddCTrademarkManagement.TrademarkID;
            //    selectClass.TMClassID = (int)dataGridView1.Rows[iRow].Cells["TMClassID"].Value;
            //    selectClass.Insert();
            //}
            //Forms.TrademarkControversyMF.RefrashDataTable(5);


            MessageBox.Show("新增成功 " + AddCTrademarkManagement.TrademarkNo);
            this.Close();


        }
        #endregion


        private void cb_Country_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cb_Country.SelectedValue != null)
            //{
            //    this.attorneyTTableAdapter.FillByCountry(this.dataSet_Drop.AttorneyT, cb_Country.SelectedValue.ToString());
            //}
        }


        private void comboBox_DelegateType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (cb.SelectedValue.ToString() == "2")
            {

                groupBox4.Text = "主要委託人(複代)";
                txt_MainCustomer.Visible = false;
                comboBox_MainCustomer.Visible = true;
                chb_IsBySelf.Checked = false;

                if (comboBox_MainCustomer.SelectedValue != null)
                {
                    List<Public.CAttLiaisoner> catt = new List<LawtechPTSystemByFirm.Public.CAttLiaisoner>();
                    Public.CAttLiaisoner.ReadList(ref catt, "AttorneyKey=" + comboBox_MainCustomer.SelectedValue.ToString());
                    attLiaisonerTBindingSource1.DataSource = catt;
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
            string strSQL = string.Format(@"SELECT          - 1 AS LiaisonerKey, '' AS Liaisoner
UNION
SELECT          LiaisonerKey, Liaisoner
FROM              LiaisonerT
WHERE          (ApplicantKey in ({0}) ) and Quit<>1 ", ApplicantKey);
            Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
            dll.FetchDataTable(strSQL, this.qS_DataSet.LiaisonerTOnline);

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

        private void Combo_OutsourcingAttorney_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (Combo_OutsourcingAttorney.SelectedValue != null)
            {
                this.attLiaisonerTTableAdapter1.FillByWindow(this.dataSet_Attorney.AttLiaisonerT, (int)Combo_OutsourcingAttorney.SelectedValue, (int)Public.WindowType.TMContract);
            }
        }

        private void chb_IsBySelf_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;

            Combo_OutsourcingAttorney.Enabled = Combo_OutsourcingAttorneyWorker.Enabled = txt_OutsourcingTrademarkNo.Enabled = maskedTextBox_OutsourcingDate.Enabled = !cb.Checked;

            txt_OutsourcingTrademarkNo.Text = "";
            maskedTextBox_OutsourcingDate.Text = "";
        }


        private void maskedTextBox_EntrustDate_DoubleClick(object sender, EventArgs e)
        {
            MaskedTextBox mtb = (MaskedTextBox)sender;
            DateTime dt;
            bool IsSuccess = DateTime.TryParse(mtb.Text, out dt);
            if (!IsSuccess)
            {
                mtb.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }
        }

        private void but_Clear_Click(object sender, EventArgs e)
        {
            txt_PicPath.Text = "";
        }

        private void but_Path1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileInfo file = new FileInfo(openFileDialog1.FileName);

                txt_PicPath.Text = openFileDialog1.FileName;


            }
        }

        private void but_ClearObjection_Click(object sender, EventArgs e)
        {
            txt_ObjectionPicPath.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileInfo file = new FileInfo(openFileDialog1.FileName);

                txt_ObjectionPicPath.Text = openFileDialog1.FileName;

            }
        }

        #region AddTrademarkControversyManagement_Load
        private void AddTrademarkControversyManagement_Load(object sender, EventArgs e)
        {

            this.delegateTypeTableAdapter.Fill(this.dataSet_Drop.DelegateType);
            this.attorneyTTableAdapter1.Fill(this.dataSet_Attorney.AttorneyT);
            

            this.countryT_DropTableAdapter.Fill(this.qS_DataSet.CountryT_Drop);

            if (cb_Country.SelectedValue != null)
            {
                attorneyTBindingSource1.Filter = " CountrySymbol ='" + cb_Country.SelectedValue.ToString() + "'";
            }
            this.worker_QuitNTableAdapter.Fill(this.qS_DataSet.Worker_QuitN);
            this.trademarkTypeTTableAdapter.FillByObjection(this.dataSet_Drop.TrademarkTypeT);
            this.trademarkStyleTTableAdapter.Fill(this.dataSet_Drop.TrademarkStyleT);
            this.tMStatusTTableAdapter.Fill(this.dataSet_Drop.TMStatusT);
            this.applicantT_DropTableAdapter.Fill(this.qS_DataSet.ApplicantT_Drop);

            comboBox_DelegateType.SelectedIndex = 0;
            cb_WorkerName.SelectedValue = Properties.Settings.Default.WorkerKEY;
            maskedTextBox_EntrustDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            chb_IsBySelf.Checked = true;
            comboBox_DelegateType_SelectedIndexChanged(comboBox_DelegateType, null);
        }
        #endregion

        private void Combo_ApplicantKey_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_DelegateType.SelectedValue.ToString() == "1")//委託類型為申請人直接委託
            {
                txt_MainCustomer.Text = Combo_ApplicantKey.Text;

                if (Combo_ApplicantKey.SelectedValue != null)
                    this.liaisonerTOnlineTableAdapter.Fill(this.qS_DataSet.LiaisonerTOnline, (int)Combo_ApplicantKey.SelectedValue);
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

        private void AddTrademarkControversyManagement_KeyDown(object sender, KeyEventArgs e)
        {
            Public.Utility.ControlTab(e);
        }

        
    }
}
