using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace LawtechPTSystem.CopyForm
{
    public partial class CopyTrademarkControversy : Form
    {
        public CopyTrademarkControversy()
        {
            InitializeComponent();
        }

        private int iTrademarkControversyID = -1;
        /// <summary>
        /// 商標案 ID
        /// </summary>
        public int TrademarkControversyID
        {
            get { return iTrademarkControversyID; }
            set { iTrademarkControversyID = value; }
        }

        #region TrademarkControversy_Load
        private void EditTrademarkControversy_Load(object sender, EventArgs e)
        {
            this.delegateTypeTableAdapter.Fill(this.dataSet_Drop.DelegateType);
            this.countryT_DropTableAdapter.Fill(this.qS_DataSet.CountryT_Drop);
            //this.attorneyTTableAdapter.FillByCountry(this.dataSet_Drop.AttorneyT, cb_Country.SelectedValue.ToString());
            this.attorneyTTableAdapter1.Fill(this.dataSet_Attorney.AttorneyT);
            this.workerTAllTableAdapter.Fill(this.qS_DataSet.WorkerTAll);
            this.tMStatusTTableAdapter.Fill(this.dataSet_Drop.TMStatusT);

            this.trademarkStyleTTableAdapter.Fill(this.dataSet_Drop.TrademarkStyleT);
            this.trademarkTypeTTableAdapter.Fill(this.dataSet_Drop.TrademarkTypeT);
            this.applicantT_DropTableAdapter.Fill(this.qS_DataSet.ApplicantT_Drop);

           

            Public.CTrademarkManagement CCTrademarkManagement = new Public.CTrademarkManagement();
            Public.CTrademarkManagement.ReadOne(TrademarkControversyID, ref CCTrademarkManagement);
            txt_TrademarOriginalNo.Text = CCTrademarkManagement.TrademarkNo;
            
            txt_TrademarkName.Text = CCTrademarkManagement.TrademarkName;
            //cb_ApplicantKey.SelectedValue = CCTrademarkManagement.ApplicantKey;
            txt_ApplicantNames.Text = CCTrademarkManagement.ApplicantNames;
            txt_ApplicantKeys.Text = CCTrademarkManagement.ApplicantKeys;
            cb_Country.SelectedValue = CCTrademarkManagement.CountrySymbol;
            cb_StyleName.Text = CCTrademarkManagement.StyleName;
            
            cb_Status.SelectedValue = CCTrademarkManagement.Status;
            txt_StatusExplain.Text = CCTrademarkManagement.StatusExplain;
            cb_WorkerKey.SelectedValue = CCTrademarkManagement.WorkerKey;
          
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
            maskedTextBox_OutsourcingDate.Text = CCTrademarkManagement.OutsourcingDate.HasValue ? CCTrademarkManagement.OutsourcingDate.Value.ToString("yyyy/MM/dd") : "";
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

           

            comboBox_DelegateType.SelectedValue = CCTrademarkManagement.DelegateType == -1 ? 1 : CCTrademarkManagement.DelegateType;
            comboBox_DelegateType_SelectedIndexChanged_1(comboBox_DelegateType, null);

            //本所自行辦理
            chb_IsBySelf.Checked = CCTrademarkManagement.IsBySelf.Value;

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

            Public.DLL dll = new Public.DLL();
            pictureBox1.ImageLocation = dll.TrademarkControversyFolderRoot + "\\" + txt_PicPath.Text;
            pictureBox2.ImageLocation = dll.TrademarkControversyFolderRoot + "\\" + txt_ObjectionPicPath.Text;


        }
        #endregion

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
            //ComboBox cb = (ComboBox)sender;
            //if (cb.SelectedValue.ToString() == "2")
            //{
            //    groupBox1.Enabled = false;
            //    cb_OutsourcingAttorney.DataSource = null;
            //    cb_OutsourcingAttorneyWorker.DataSource = null;
            //    chb_IsBySelf.Checked = false;

            //    txt_MainCustomer.Visible = false;
            //    comboBox_MainCustomer.Visible = true;


            //    groupBox2.Text = "主要委託人(複代)";

            //    cb_MainCustomerLiaisoner.DataSource = attorneyTAttLiaisonerTBindingSource;
            //    cb_MainCustomerLiaisoner.DisplayMember = "Liaisoner";
            //    cb_MainCustomerLiaisoner.ValueMember = "ALiaisonerKey";

            //    txt_OutsourcingTrademarkNo.Text = "";

            //    if (comboBox_MainCustomer.SelectedValue != null)
            //    {
            //        this.attLiaisonerTTableAdapter.Fill(this.dataSet_Drop.AttLiaisonerT, (int)comboBox_MainCustomer.SelectedValue);
            //    }
            //}
            //else
            //{
            //    groupBox1.Enabled = true;
            //    chb_IsBySelf.Checked = true;
            //    cb_OutsourcingAttorney.DisplayMember = "AttorneySymbol";
            //    cb_OutsourcingAttorney.ValueMember = "AttorneyKey";
            //    cb_OutsourcingAttorney.DataSource = attorneyTBindingSource;

            //    cb_OutsourcingAttorneyWorker.DataSource = attorneyTAttLiaisonerTBindingSource;
            //    cb_OutsourcingAttorneyWorker.DisplayMember = "Liaisoner";
            //    cb_OutsourcingAttorneyWorker.ValueMember = "ALiaisonerKey";

            //    groupBox2.Text = "主要委託人(同申請人)";
            //    txt_MainCustomer.Visible = true;
            //    comboBox_MainCustomer.Visible = false;
            //    txt_MainCustomer.Text = cb_ApplicantKey.Text;

            //    cb_MainCustomerLiaisoner.DataSource = liaisonerTBindingSource;
            //    cb_MainCustomerLiaisoner.DisplayMember = "Liaisoner";
            //    cb_MainCustomerLiaisoner.ValueMember = "LiaisonerKey";

            //    this.liaisonerTTableAdapter.Fill(this.qS_DataSet.LiaisonerT, (int)cb_ApplicantKey.SelectedValue);
            //}
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

                    US.CalculationDate Calculation = new LawtechPTSystem.US.CalculationDate();
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

        #region linkLabel2_LinkClicked
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileInfo file = new FileInfo(openFileDialog1.FileName);

                txt_ObjectionPicPathNew.Text = openFileDialog1.FileName;

                pictureBox2.ImageLocation = txt_ObjectionPicPathNew.Text;
            }
        }
        #endregion

        private void but_OK_Click(object sender, EventArgs e)
        {

            if (txt_TrademarkNo.Text.Trim() == "")
            {
                MessageBox.Show("【本所案號】不得為空白", "提示訊息");
                return;
            }

            Public.PublicForm Forms = new Public.PublicForm();            

            Public.CTrademarkControversyManagement AddCTrademarkManagement = new Public.CTrademarkControversyManagement();
            //AddCTrademarkManagement.SetCurrent(TrademarkControversyID);

            bool isExit = false;
            AddCTrademarkManagement.CheckValueExist("TrademarkNo", txt_TrademarkNo.Text, ref isExit);
            if (isExit)
            {
                MessageBox.Show("【本所案號】不得為重覆，請重新修改", "提示訊息");
                return;
            }           


            AddCTrademarkManagement.TrademarkNo = txt_TrademarkNo.Text;
            AddCTrademarkManagement.TrademarkName = txt_TrademarkName.Text;
            AddCTrademarkManagement.TrademarOriginalNo = txt_TrademarOriginalNo.Text;
            AddCTrademarkManagement.TrademarkOvertureName = txt_TrademarkOvertureName.Text;
            AddCTrademarkManagement.DisagreementNo = txt_DisagreementNo.Text;
            //AddCTrademarkManagement.ApplicantKey = cb_ApplicantKey.SelectedValue != null ? (int)cb_ApplicantKey.SelectedValue : -1;
            AddCTrademarkManagement.CountrySymbol = cb_Country.SelectedValue != null ? cb_Country.SelectedValue.ToString() : "";
            AddCTrademarkManagement.StyleName = cb_StyleName.Text;
            AddCTrademarkManagement.Status = cb_Status.SelectedValue != null ? (int)cb_Status.SelectedValue : -1;
            AddCTrademarkManagement.StatusExplain = txt_StatusExplain.Text;
            AddCTrademarkManagement.WorkerKey = cb_WorkerKey.SelectedValue != null ? (int)cb_WorkerKey.SelectedValue : -1;
            AddCTrademarkManagement.ApplicantNames= txt_ApplicantNames.Text;
            AddCTrademarkManagement.ApplicantKeys=txt_ApplicantKeys.Text;
            //本所委辦日期
            DateTime dtEntrustDate = new DateTime();
            bool IsEntrustDate = DateTime.TryParse(maskedTextBox_EntrustDate.Text, out dtEntrustDate);
            if (IsEntrustDate)
            {
                AddCTrademarkManagement.EntrustDate = dtEntrustDate;
            }
            else
            {
                AddCTrademarkManagement.EntrustDate = new DateTime(1900, 1, 1);
            }
            AddCTrademarkManagement.OutsourcingAttorney = cb_OutsourcingAttorney.SelectedValue != null ? (int)cb_OutsourcingAttorney.SelectedValue : -1;
            AddCTrademarkManagement.OutsourcingAttorneyWorker = cb_OutsourcingAttorneyWorker.SelectedValue != null ? (int)cb_OutsourcingAttorneyWorker.SelectedValue : -1;
            AddCTrademarkManagement.OutsourcingTrademarkNo = txt_OutsourcingTrademarkNo.Text;
            DateTime dtOutsourcingDate = new DateTime();
            bool IsCheckOutsourcingDate = DateTime.TryParse(maskedTextBox_OutsourcingDate.Text, out dtOutsourcingDate);
            if (IsCheckOutsourcingDate)
            {
                AddCTrademarkManagement.OutsourcingDate = dtOutsourcingDate;
            }
            else
            {
                AddCTrademarkManagement.OutsourcingDate = new DateTime(1900, 1, 1);
            }
            DateTime dtApplicationDate = new DateTime();
            bool IsCheckApplicationDate = DateTime.TryParse(maskedTextBox_ApplicationDate.Text, out dtApplicationDate);
            if (IsCheckApplicationDate)
            {
                AddCTrademarkManagement.ApplicationDate = dtApplicationDate;
            }
            else
            {
                AddCTrademarkManagement.ApplicationDate = new DateTime(1900, 1, 1);
            }
            AddCTrademarkManagement.ApplicationNo = txt_ApplicationNo.Text;

            DateTime dtObjectionDate = new DateTime();
            bool IsCheckObjectionDate = DateTime.TryParse(maskedTextBox_ObjectionDate.Text, out dtObjectionDate);
            if (IsCheckObjectionDate)
            {
                AddCTrademarkManagement.ObjectionDate = dtObjectionDate;
            }
            else
            {
                AddCTrademarkManagement.ObjectionDate = new DateTime(1900, 1, 1);
            }

            DateTime dtRegistrationDate = new DateTime();
            bool IsCheckRegistrationDate = DateTime.TryParse(maskedTextBox_RegistrationDate.Text, out dtRegistrationDate);
            if (IsCheckRegistrationDate)
            {
                AddCTrademarkManagement.RegistrationDate = dtRegistrationDate;
            }
            else
            {
                AddCTrademarkManagement.RegistrationDate = new DateTime(1900, 1, 1);
            }
            AddCTrademarkManagement.RegistrationNo = txt_RegistrationNo.Text;
            AddCTrademarkManagement.RegisterProduct = txt_RegisterProduct.Text;
            //AddCTrademarkManagement.RegisterProductName = txt_RegisterProduct.Text;
            DateTime dtCloseDate = new DateTime();
            bool IsCheckCloseDate = DateTime.TryParse(maskedTextBox_CloseDate.Text, out dtCloseDate);
            if (IsCheckCloseDate)
            {
                AddCTrademarkManagement.CloseDate = dtCloseDate;
            }
            else
            {
                AddCTrademarkManagement.CloseDate = new DateTime(1900, 1, 1);
            }
            AddCTrademarkManagement.Remarks = txt_Remarks.Text;
            //委託類型
            AddCTrademarkManagement.DelegateType = (int)comboBox_DelegateType.SelectedValue;
            AddCTrademarkManagement.ObjectionClass = txt_ObjectionClass.Text;
            AddCTrademarkManagement.ObjectionContent = txt_ObjectionContent.Text;
            AddCTrademarkManagement.ObjectionNo = txt_ObjectionNo.Text;
            AddCTrademarkManagement.ObjectionPeople = txt_ObjectionPeople.Text;


            AddCTrademarkManagement.IsBySelf = chb_IsBySelf.Checked;
            

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

           
            AddCTrademarkManagement.LastModifyWorker = Properties.Settings.Default.WorkerName;
           
            AddCTrademarkManagement.Create();


            //商標圖
            if (txt_NewPicture.Text != "")
            {
                Public.DLL dll = new Public.DLL();

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


                   List< Public.CUpLoadFile> upfile = new List< Public.CUpLoadFile>();
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
                        Insertfile.MainParentID = AddCTrademarkManagement.TrademarkControversyID;
                        Insertfile.FileKind = 5;
                        Insertfile.FileType = 10;

                        Insertfile.FilePath = AddCTrademarkManagement.PicPath;
                        Insertfile.FileDoc = "我方商標圖";
                        Insertfile.Uploader = Properties.Settings.Default.WorkerName;
                        Insertfile.Create();
                    }


                   
                }

            }

            //被異議人商標圖
            if (txt_ObjectionPicPathNew.Text != "")
            {
                Public.DLL dll = new Public.DLL();

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

                    List<Public.CUpLoadFile> upfile = new List<Public.CUpLoadFile>();
                    Public.CUpLoadFile.ReadList(ref upfile, string.Format(@"MainParentID={0} and FileKind=5 and FileType=10 and FilePath='{1}' ", TrademarkControversyID, AddCTrademarkManagement.PicPath));

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
                        Insertfile.MainParentID = AddCTrademarkManagement.TrademarkControversyID;
                        Insertfile.FileKind = 5;
                        Insertfile.FileType = 10;                       
                        Insertfile.FilePath = AddCTrademarkManagement.ObjectionPicPath;
                        Insertfile.FileDoc = "被異議人商標圖";
                        Insertfile.Uploader = Properties.Settings.Default.WorkerName;
                        Insertfile.Create();
                    }

                  
                }

            }
            
            AddCTrademarkManagement.Update();

            if (Forms.TrademarkControversyMF != null)
            {
                DataSet_TrademarkControversy.TrademarkControversyManagementTRow dr = Forms.TrademarkControversyMF.dt_TrademarkControversyManagementT.NewTrademarkControversyManagementTRow();
                dr["TrademarkNo"] = AddCTrademarkManagement.TrademarkNo;
                dr["TrademarkName"] = AddCTrademarkManagement.TrademarkName;
                dr["TrademarkOvertureName"] = AddCTrademarkManagement.TrademarkOvertureName;
                dr["ApplicantKey"] = AddCTrademarkManagement.ApplicantKey;
                dr["CountrySymbol"] = AddCTrademarkManagement.CountrySymbol;
                dr["StyleName"] = AddCTrademarkManagement.StyleName;
                dr["TrademarOriginalNo"] = AddCTrademarkManagement.TrademarOriginalNo;
                //AddCTrademarkManagement.TMTypeName = cb_TMTypeName.Text;
                //dr["TMTypeName"] = AddCTrademarkManagement.TMTypeName;            
                dr["Status"] = AddCTrademarkManagement.Status;
                dr["StatusExplain"] = AddCTrademarkManagement.StatusExplain;
                dr["WorkerKey"] = AddCTrademarkManagement.WorkerKey;
                if (AddCTrademarkManagement.EntrustDate.HasValue)
                {
                    dr["EntrustDate"] = AddCTrademarkManagement.EntrustDate;
                }
                else
                {
                    dr["EntrustDate"] = DBNull.Value;
                }
                dr["OutsourcingAttorney"] = AddCTrademarkManagement.OutsourcingAttorney;
                dr["OutsourcingAttorneyWorker"] = AddCTrademarkManagement.OutsourcingAttorneyWorker;
                dr["OutsourcingTrademarkNo"] = AddCTrademarkManagement.OutsourcingTrademarkNo;
                if (AddCTrademarkManagement.OutsourcingDate.HasValue)
                {
                    dr["OutsourcingDate"] = AddCTrademarkManagement.OutsourcingDate;
                }
                else
                {
                    dr["OutsourcingDate"] = DBNull.Value;
                }

                if (AddCTrademarkManagement.ApplicationDate.HasValue)
                {
                    dr["ApplicationDate"] = AddCTrademarkManagement.ApplicationDate;
                }
                else
                {
                    dr["ApplicationDate"] = DBNull.Value;
                }

                dr["ApplicationNo"] = AddCTrademarkManagement.ApplicationNo;


                if (AddCTrademarkManagement.ObjectionDate.HasValue)
                {
                    dr["ObjectionDate"] = AddCTrademarkManagement.ObjectionDate;
                }
                else
                {
                    dr["ObjectionDate"] = DBNull.Value;
                }


                if (AddCTrademarkManagement.RegistrationDate.HasValue)
                {
                    dr["RegistrationDate"] = AddCTrademarkManagement.RegistrationDate;
                }
                else
                {
                    dr["RegistrationDate"] = DBNull.Value;
                }
                dr["RegistrationNo"] = AddCTrademarkManagement.RegistrationNo;
                dr["RegisterProduct"] = AddCTrademarkManagement.RegisterProduct;
                dr["RegisterProductName"] = AddCTrademarkManagement.RegisterProductName;
                if (AddCTrademarkManagement.CloseDate.HasValue)
                {
                    dr["CloseDate"] = AddCTrademarkManagement.CloseDate;
                }
                else
                {
                    dr["CloseDate"] = DBNull.Value;
                }


                dr["Remarks"] = AddCTrademarkManagement.Remarks;
                dr["DelegateType"] = AddCTrademarkManagement.DelegateType;
                dr["DelegateTypeName"] = comboBox_DelegateType.Text;

                dr["IsBySelf"] = AddCTrademarkManagement.IsBySelf;

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


                    if (!AddCTrademarkManagement.IsBySelf.HasValue)
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

                    if (!AddCTrademarkManagement.IsBySelf.HasValue)
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
                                              

                dr["PicPath"] = AddCTrademarkManagement.PicPath;
                dr["ObjectionPicPath"] = AddCTrademarkManagement.ObjectionPicPath;
           
                Forms.TrademarkControversyMF.dt_TrademarkControversyManagementT.AcceptChanges();
            }
           

            MessageBox.Show("新增商標異議案成功", "提示訊息");

            this.Close();
        }

        #region cb_Country_SelectedIndexChanged
        private void cb_Country_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Country.SelectedValue != null)
            {
                this.attorneyTTableAdapter.FillByCountry(this.dataSet_Drop.AttorneyT, cb_Country.SelectedValue.ToString());
            }
        }
        #endregion

        #region linkLabel3_LinkClicked
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
        #endregion

        #region comboBox_DelegateType_SelectedIndexChanged_1
        private void comboBox_DelegateType_SelectedIndexChanged_1(object sender, EventArgs e)
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
                    List<Public.CAttLiaisoner> catt = new List<Public.CAttLiaisoner>();
                    Public.CAttLiaisoner.ReadList(ref catt, string.Format(" AttorneyKey={0} and Quit<>1  ", comboBox_MainCustomer.SelectedValue.ToString()));
                 
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
            Public.DLL dll = new Public.DLL();
            dll.FetchDataTable(strSQL, this.qS_DataSet.LiaisonerTOnline);

        }
        #endregion

        #region CopyTrademarkControversy_KeyDown
        private void CopyTrademarkControversy_KeyDown(object sender, KeyEventArgs e)
        {
            Public.Utility.ControlTab(e);
        }
        #endregion

        #region chb_IsBySelf_CheckedChanged_1
        private void chb_IsBySelf_CheckedChanged_1(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;

            cb_OutsourcingAttorney.Enabled = cb_OutsourcingAttorneyWorker.Enabled = txt_OutsourcingTrademarkNo.Enabled = maskedTextBox_OutsourcingDate.Enabled = !cb.Checked;

            txt_OutsourcingTrademarkNo.Text = "";
            maskedTextBox_OutsourcingDate.Text = "";
        }
        #endregion
    }
}
