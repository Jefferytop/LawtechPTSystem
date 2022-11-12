﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace LawtechPTSystem.CopyForm
{
    public partial class Trademark : Form
    {
        public Trademark()
        {
            InitializeComponent();
        }

        private int iTrademarkIDSource = -1;
        /// <summary>
        /// 複製來源的商標ID
        /// </summary>
        public int TrademarkIDSource
        {
            get { return iTrademarkIDSource; }
            set { iTrademarkIDSource = value; }
        }
       
        #region EditTrademark_Load
        private void EditTrademark_Load(object sender, EventArgs e)
         {
            
             this.delegateTypeTableAdapter.Fill(this.dataSet_Drop.DelegateType);
             this.countryT_DropTableAdapter.Fill(this.qS_DataSet.CountryT_Drop);
            this.trademarkStyleModelTTableAdapter.Fill(this.dataSet_Drop.TrademarkStyleModelT);
            this.attorneyTTableAdapter1.Fill(this.dataSet_Attorney.AttorneyT);   
             this.workerTAllTableAdapter.Fill(this.qS_DataSet.WorkerTAll);
             this.tMStatusTTableAdapter.Fill(this.dataSet_Drop.TMStatusT);
             
             this.trademarkStyleTTableAdapter.Fill(this.dataSet_Drop.TrademarkStyleT);
             this.trademarkTypeTTableAdapter.Fill(this.dataSet_Drop.TrademarkTypeT);
             this.applicantT_DropTableAdapter.Fill(this.qS_DataSet.ApplicantT_Drop);

             //商標分類
             //this.trademarkClassSelectTableAdapter.Fill(this.dataSet_TM.TrademarkClassSelect, TrademarkID);

             Public.CTrademarkManagement CCTrademarkManagement = new Public.CTrademarkManagement();
             Public.CTrademarkManagement.ReadOne(TrademarkIDSource, ref CCTrademarkManagement);
            
             txt_TrademarkNo.Text = "";
             txt_TrademarkName.Text = CCTrademarkManagement.TrademarkName;

             txt_ApplicantNames.Text = CCTrademarkManagement.ApplicantNames;
             txt_ApplicantKeys.Text = CCTrademarkManagement.ApplicantKeys;

             cb_Country.SelectedValue = CCTrademarkManagement.CountrySymbol;
             cb_StyleName.Text = CCTrademarkManagement.StyleName;
             cb_TMTypeName.Text = CCTrademarkManagement.TMTypeName;
             cb_Status.SelectedValue = CCTrademarkManagement.Status;
             txt_StatusExplain.Text = CCTrademarkManagement.StatusExplain;
             cb_WorkerKey.SelectedValue = CCTrademarkManagement.WorkerKey;
             maskedTextBox_EntrustDate.Text = CCTrademarkManagement.EntrustDate.HasValue? CCTrademarkManagement.EntrustDate.Value.ToString("yyyy-MM-dd") : "";
             if (CCTrademarkManagement.OutsourcingAttorney.HasValue)
             {
                 cb_OutsourcingAttorney.SelectedValue = CCTrademarkManagement.OutsourcingAttorney;
             }

             if (CCTrademarkManagement.OutsourcingAttorneyWorker.HasValue)
             {
                 cb_OutsourcingAttorneyWorker.SelectedValue = CCTrademarkManagement.OutsourcingAttorneyWorker;
             }
             txt_OutsourcingTrademarkNo.Text = CCTrademarkManagement.OutsourcingTrademarkNo;
             maskedTextBox_OutsourcingDate.Text = CCTrademarkManagement.OutsourcingDate.HasValue ? CCTrademarkManagement.OutsourcingDate.Value.ToString("yyyy-MM-dd") : "";
             maskedTextBox_ApplicationDate.Text = CCTrademarkManagement.ApplicationDate.HasValue ? CCTrademarkManagement.ApplicationDate.Value.ToString("yyyy-MM-dd") : "";
             txt_ApplicationNo.Text = CCTrademarkManagement.ApplicationNo;

            //第一次公告日
             maskedTextBox_NoticeDate.Text = CCTrademarkManagement.NoticeDate1.HasValue ? CCTrademarkManagement.NoticeDate1.Value.ToString("yyyy-MM-dd") : "";
             txt_NoticeNo.Text = CCTrademarkManagement.NoticeNo;

             //第二次公告日
             maskedTextBox_NoticeDate2.Text = CCTrademarkManagement.NoticeDate.HasValue ? CCTrademarkManagement.NoticeDate.Value.ToString("yyyy-MM-dd") : "";
             txt_NoticeNo2.Text = CCTrademarkManagement.NoticeNo;

             maskedTextBox_RegistrationDate.Text = CCTrademarkManagement.RegistrationDate.HasValue ? CCTrademarkManagement.RegistrationDate.Value.ToString("yyyy-MM-dd") : "";
             txt_RegistrationNo.Text = CCTrademarkManagement.RegistrationNo;
             maskedTextBox_LawDate.Text = CCTrademarkManagement.LawDate.HasValue ? CCTrademarkManagement.LawDate.Value.ToString("yyyy-MM-dd") : "";
             txt_RegisterProductName.Text = CCTrademarkManagement.RegisterProductName;
             txt_RegisterProduct.Text = CCTrademarkManagement.RegisterProduct;
             maskedTextBox_ExtendedDate.Text = CCTrademarkManagement.ExtendedDate.HasValue ? CCTrademarkManagement.ExtendedDate.Value.ToString("yyyy-MM-dd") : "";
             maskedTextBox_CloseDate.Text = CCTrademarkManagement.CloseDate.HasValue ? CCTrademarkManagement.CloseDate.Value.ToString("yyyy-MM-dd") : "";
             txt_Remarks.Text = CCTrademarkManagement.Remarks;
             txt_PicPath.Text = CCTrademarkManagement.PicPath;
             txt_TrademarkOvertureName.Text = CCTrademarkManagement.TrademarkOvertureName;
           

             comboBox_DelegateType.SelectedValue = CCTrademarkManagement.DelegateType == -1 ? 1 : CCTrademarkManagement.DelegateType;
             comboBox_DelegateType_SelectedIndexChanged(comboBox_DelegateType, null);

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
                     cb_OutsourcingAttorney.SelectedValue = CCTrademarkManagement.OutsourcingAttorney;
                     txt_OutsourcingTrademarkNo.Text = CCTrademarkManagement.OutsourcingTrademarkNo;
                     if (CCTrademarkManagement.OutsourcingAttorneyWorker != -1)
                     {
                         this.attLiaisonerTTableAdapter.Fill(this.dataSet_Drop.AttLiaisonerT, (int)cb_OutsourcingAttorney.SelectedValue);
                         cb_OutsourcingAttorneyWorker.SelectedValue = CCTrademarkManagement.OutsourcingAttorneyWorker;
                     }
                 }
             }
             else//複代委託
             {
                 comboBox_MainCustomer.SelectedValue = CCTrademarkManagement.MainCustomer;
                 txt_MainCustomerRefNo.Text = CCTrademarkManagement.MainCustomerRefNo;
                if (CCTrademarkManagement.MainCustomerTransactor != null)
                {
                    cb_MainCustomerLiaisoner.SelectedValue = CCTrademarkManagement.MainCustomerTransactor;
                }

                 if (!chb_IsBySelf.Checked)
                 {
                     cb_OutsourcingAttorney.SelectedValue = CCTrademarkManagement.OutsourcingAttorney;
                     txt_OutsourcingTrademarkNo.Text = CCTrademarkManagement.OutsourcingTrademarkNo;

                     if (CCTrademarkManagement.OutsourcingAttorneyWorker != -1)
                     {
                         this.attLiaisonerTTableAdapter.Fill(this.dataSet_Drop.AttLiaisonerT, (int)cb_OutsourcingAttorney.SelectedValue);
                         cb_OutsourcingAttorneyWorker.SelectedValue = CCTrademarkManagement.OutsourcingAttorneyWorker;
                     }
                 }
             }

             maskedTextBox_OutsourcingDate.Text = CCTrademarkManagement.OutsourcingDate.HasValue? CCTrademarkManagement.OutsourcingDate.Value.ToString("yyyy-MM-dd") : "";

             Public.DLL dll = new Public.DLL();
             pictureBox1.ImageLocation = dll.TrademarkFolderRoot + "\\" + txt_PicPath.Text;

           
         }
        #endregion

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region but_OK_Click
        private void but_OK_Click(object sender, EventArgs e)
        {

            if (txt_TrademarkNo.Text.Trim() == "")
            {
                MessageBox.Show("【本所案號】不得為空白", "提示訊息");
                return;
            }
           

            Public.CTrademarkManagement AddCTrademarkManagement = new Public.CTrademarkManagement();
          
            bool isExit = false;
            AddCTrademarkManagement.CheckValueExist("TrademarkNo", txt_TrademarkNo.Text, ref isExit);
            if (isExit)
            {
                MessageBox.Show("【本所案號】不得為重覆", "提示訊息");
                return;
            }


            AddCTrademarkManagement.TrademarkNo = txt_TrademarkNo.Text;          

            AddCTrademarkManagement.TrademarkName = txt_TrademarkName.Text;          

            AddCTrademarkManagement.TrademarkOvertureName = txt_TrademarkOvertureName.Text;       

            AddCTrademarkManagement.ApplicantKeys = txt_ApplicantKeys.Text;      

            AddCTrademarkManagement.ApplicantNames = txt_ApplicantNames.Text;         

            AddCTrademarkManagement.CountrySymbol = cb_Country.SelectedValue != null ? cb_Country.SelectedValue.ToString() : "";
           
            if (AddCTrademarkManagement.CountrySymbol != "")
           

            AddCTrademarkManagement.StyleName = cb_StyleName.Text;

            AddCTrademarkManagement.TMStyleModelID = (int)comboBox_TMStyleModelID.SelectedValue;

            AddCTrademarkManagement.TMTypeName = cb_TMTypeName.Text;         

            //案件階段
            AddCTrademarkManagement.Status = cb_Status.SelectedValue != null ? (int)cb_Status.SelectedValue : -1;
           
           
            AddCTrademarkManagement.StatusExplain = txt_StatusExplain.Text;
        

            //本所承辦人
            AddCTrademarkManagement.WorkerKey = cb_WorkerKey.SelectedValue != null ? (int)cb_WorkerKey.SelectedValue : -1;
           
           

            DateTime dtEntrustDate = new DateTime();
            bool IsEntrustDate = DateTime.TryParse(maskedTextBox_EntrustDate.Text, out dtEntrustDate);
            if (IsEntrustDate) AddCTrademarkManagement.EntrustDate = dtEntrustDate;
            else AddCTrademarkManagement.EntrustDate =null;
           


            DateTime dtOutsourcingDate = new DateTime();
            bool IsCheckOutsourcingDate = DateTime.TryParse(maskedTextBox_OutsourcingDate.Text, out dtOutsourcingDate);
            if (IsCheckOutsourcingDate) AddCTrademarkManagement.OutsourcingDate = dtOutsourcingDate;
            else AddCTrademarkManagement.OutsourcingDate = null;
          


            DateTime dtApplicationDate = new DateTime();
            bool IsCheckApplicationDate = DateTime.TryParse(maskedTextBox_ApplicationDate.Text, out dtApplicationDate);
            if (IsCheckApplicationDate) AddCTrademarkManagement.ApplicationDate = dtApplicationDate;
            else AddCTrademarkManagement.ApplicationDate =null;
            

            AddCTrademarkManagement.ApplicationNo = txt_ApplicationNo.Text;
           


            DateTime dtNoticeDate = new DateTime();
            bool IsCheckNoticeDate = DateTime.TryParse(maskedTextBox_NoticeDate.Text, out dtNoticeDate);
            if (IsCheckNoticeDate) AddCTrademarkManagement.NoticeDate1 = dtNoticeDate;
            else AddCTrademarkManagement.NoticeDate1 = null;
           

            AddCTrademarkManagement.NoticeNo = txt_NoticeNo.Text;       


            DateTime dtNoticeDate2 = new DateTime();
            bool IsCheckNoticeDate2 = DateTime.TryParse(maskedTextBox_NoticeDate2.Text, out dtNoticeDate2);
            if (IsCheckNoticeDate2)
            {
                AddCTrademarkManagement.NoticeDate = dtNoticeDate2;
            }
            else
            {
                AddCTrademarkManagement.NoticeDate =null;
            }
           
            AddCTrademarkManagement.NoticeNo = txt_NoticeNo2.Text;
         

            DateTime dtRegistrationDate = new DateTime();
            bool IsCheckRegistrationDate = DateTime.TryParse(maskedTextBox_RegistrationDate.Text, out dtRegistrationDate);
            if (IsCheckRegistrationDate) AddCTrademarkManagement.RegistrationDate = dtRegistrationDate;
            else AddCTrademarkManagement.RegistrationDate = null;
            

            AddCTrademarkManagement.RegistrationNo = txt_RegistrationNo.Text;
            

            DateTime dtLawDate = new DateTime();
            bool IsCheckLawDate = DateTime.TryParse(maskedTextBox_LawDate.Text, out dtLawDate);
            if (IsCheckLawDate) AddCTrademarkManagement.LawDate = dtLawDate;
            else AddCTrademarkManagement.LawDate = null;
           

            AddCTrademarkManagement.RegisterProduct = txt_RegisterProduct.Text;           

            AddCTrademarkManagement.RegisterProductName = txt_RegisterProductName.Text;
            

            DateTime dtExtendedDate = new DateTime();
            bool IsCheckExtendedDate = DateTime.TryParse(maskedTextBox_ExtendedDate.Text, out dtExtendedDate);
            if (IsCheckExtendedDate) AddCTrademarkManagement.ExtendedDate = dtExtendedDate;
            else AddCTrademarkManagement.ExtendedDate = null;
           

            DateTime dtCloseDate = new DateTime();
            bool IsCheckCloseDate = DateTime.TryParse(maskedTextBox_CloseDate.Text, out dtCloseDate);
            if (IsCheckCloseDate) AddCTrademarkManagement.CloseDate = dtCloseDate;
            else AddCTrademarkManagement.CloseDate = null;
          

            AddCTrademarkManagement.Remarks = txt_Remarks.Text;
          


            //委託類型
            AddCTrademarkManagement.DelegateType = (int)comboBox_DelegateType.SelectedValue;
           

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

            if (cb_MainCustomerLiaisoner.SelectedValue != null)
            {
                AddCTrademarkManagement.MainCustomerTransactor = (int)cb_MainCustomerLiaisoner.SelectedValue;
            }

            //主要委託人--貴方案號
            AddCTrademarkManagement.MainCustomerRefNo = txt_MainCustomerRefNo.Text;

            if (!AddCTrademarkManagement.IsBySelf.Value)//非本所直接辦理
            {
                //承辦事務所
                if (cb_OutsourcingAttorney.SelectedValue != null)
                {
                    AddCTrademarkManagement.OutsourcingAttorney = (int)cb_OutsourcingAttorney.SelectedValue;
                }

                //對方案號
                AddCTrademarkManagement.OutsourcingTrademarkNo = txt_OutsourcingTrademarkNo.Text;

                //承辦事務所 聯絡窗口
                if (cb_OutsourcingAttorneyWorker.SelectedValue != null)
                {
                    AddCTrademarkManagement.OutsourcingAttorneyWorker = (int)cb_OutsourcingAttorneyWorker.SelectedValue;
                }
            }
            else//本所自行承辦
            {
                AddCTrademarkManagement.OutsourcingAttorney = -1;
                AddCTrademarkManagement.OutsourcingTrademarkNo = "";
                AddCTrademarkManagement.OutsourcingAttorneyWorker = -1;
            }

            AddCTrademarkManagement.Creator = Properties.Settings.Default.WorkerName;
            AddCTrademarkManagement.Create();

            #region 申請人 TrademarkApplicant
            //申請人               
            Public.CTrademarkApplicant TMApp = new Public.CTrademarkApplicant();
            TMApp.Delete("TrademarkID=" + AddCTrademarkManagement.TrademarkID.ToString());

            string[] apps = txt_ApplicantKeys.Text.Split(',');
            for (int iApp = 0; iApp < apps.Length; iApp++)
            {
                if (apps[iApp] != "")
                {
                    TMApp.TrademarkID = AddCTrademarkManagement.TrademarkID;
                    TMApp.ApplicantKey = int.Parse(apps[iApp]);
                    TMApp.Create();
                }
            }
            #endregion


            Public.PublicForm Forms = new Public.PublicForm();

            if (txt_NewPicture.Text != "")
            {
                Public.DLL dll = new Public.DLL();

                string sPath = dll.TrademarkFolderRoot + "\\" + AddCTrademarkManagement.PicPath;

                if (File.Exists(sPath))
                {
                    File.Delete(sPath);
                }

                if (File.Exists(txt_NewPicture.Text))
                {
                    FileInfo upload = new FileInfo(txt_NewPicture.Text);

                    //確認商標資料夾是否存在
                    dll.CreatFolder(4, AddCTrademarkManagement.TrademarkID.ToString());

                    AddCTrademarkManagement.PicPath = AddCTrademarkManagement.TrademarkID.ToString() + "\\" + upload.Name;
                    string sPath_New = dll.TrademarkFolderRoot + "\\" + AddCTrademarkManagement.PicPath;
                    File.Copy(txt_NewPicture.Text, sPath_New);
                    Forms.TrademarkMF.property_TMPicturePath = sPath_New;

                   // Public.CUpLoadFile upfile = new Public.CUpLoadFile(string.Format("MainParentID={0} and FileKind=4 and FileType=6 ", AddCTrademarkManagement.TrademarkID));
                    List<Public.CUpLoadFile> upfile = new List<Public.CUpLoadFile>();
                    Public.CUpLoadFile.ReadList(ref upfile, string.Format(@"MainParentID={0} and FileKind=4 and FileType=6  ", AddCTrademarkManagement.TrademarkID));


                    if (upfile.Count > 0)
                    {                       
                        upfile[0].FilePath = AddCTrademarkManagement.PicPath;
                        upfile[0].Uploader = Properties.Settings.Default.WorkerName;
                        upfile[0].Update();
                    }
                    else
                    {
                        Public.CUpLoadFile Insertfile = new Public.CUpLoadFile();
                        Insertfile.MainParentID = AddCTrademarkManagement.TrademarkID;
                        Insertfile.FileKind = 4;
                        Insertfile.FileType = 6;                        
                        Insertfile.FilePath = AddCTrademarkManagement.PicPath;
                        Insertfile.FileDoc = "商標圖";
                        Insertfile.Uploader = Properties.Settings.Default.WorkerName;
                        Insertfile.Create();
                    }
                                       
                }

            }
                     
            AddCTrademarkManagement.LastModifyWorker = Properties.Settings.Default.WorkerName;

            AddCTrademarkManagement.Update();

            if (Forms.TrademarkMF != null)
            {
                DataRow dr = Forms.TrademarkMF.dt_TrademarkManagementT.NewRow();
                DataRow drV = Public.CTrademarkPublicFunction.GetTrademarkList(AddCTrademarkManagement.TrademarkID.ToString());
                dr.ItemArray = drV.ItemArray;
                Forms.TrademarkMF.dt_TrademarkManagementT.Rows.Add(dr);
            }

            //商標分類
            //Public.CTrademarkClassSelect selectClass = new Public.CTrademarkClassSelect("1=0");
            //selectClass.Delete("TrademarkID=" + TrademarkIDSource.ToString());


            //Forms.TrademarkMF.RefrashDataTable(5);


            MessageBox.Show("複製商標成功", "提示訊息");
            this.Close();
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

        #region cb_OutsourcingAttorney_SelectedIndexChanged
        private void cb_OutsourcingAttorney_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_OutsourcingAttorney.SelectedValue != null)
            {
                this.attLiaisonerTTableAdapter1.FillByWindow(this.dataSet_Attorney.AttLiaisonerT, (int)cb_OutsourcingAttorney.SelectedValue, (int)Public.WindowType.TMContract);
            }
        }
        #endregion

        #region contextMenuStrip1_ItemClicked
        //private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        //{
        //    contextMenuStrip1.Visible = false;

        //    switch (e.ClickedItem.Name)
        //    {
        //        case "ToolStripMenuItem_SelectClass":
        //            US.SelectTrademarkClassification selectClass = new LawtechPTSystem.US.SelectTrademarkClassification();
        //            selectClass.property_CountrySymbolName = cb_Country.Text;
        //            selectClass.property_CountrySymbol = cb_Country.SelectedValue.ToString();
        //            if(dataGridView1.Rows.Count>0)
        //            {
        //                if (selectClass.Dt_TrademarkClass == null)
        //                {
        //                    selectClass.CreateDatatable();
        //                }
        //                DataTable dtClass = selectClass.Dt_TrademarkClass;
        //                for(int iClass=0;iClass<dataGridView1.Rows.Count;iClass++)
        //                {
        //                    DataRow dr= dtClass.NewRow();
        //                    dr["TMClassID"] = (int)dataGridView1.Rows[iClass].Cells["TMClassID"].Value;
        //                    dr["ClassName"] = dataGridView1.Rows[iClass].Cells["ClassName"].Value;
        //                    dr["ClassDescript"] = dataGridView1.Rows[iClass].Cells["ClassDescript"].Value;
        //                    dtClass.Rows.Add(dr);
        //                }
        //            }
        //            selectClass.ShowDialog();
        //            if (selectClass.IsChange)
        //            {

        //                IsChangeClass = selectClass.IsChange;

        //                if (selectClass.Dt_TrademarkClass.Rows.Count > 0)
        //                {
        //                    this.dataSet_TM.TrademarkClassSelect.Rows.Clear();

        //                    DataTable dt = selectClass.Dt_TrademarkClass;

        //                    for (int iRow = 0; iRow < dt.Rows.Count; iRow++)
        //                    {
        //                        DataSet_TM.TrademarkClassSelectRow dr = this.dataSet_TM.TrademarkClassSelect.NewTrademarkClassSelectRow();
        //                        dr["TMClassSelectID"] = iRow + 1;
        //                        dr["TMClassID"] = dt.Rows[iRow]["TMClassID"];
        //                        dr["ClassName"] = dt.Rows[iRow]["ClassName"];
        //                        dr["ClassDescript"] = dt.Rows[iRow]["ClassDescript"];
        //                        this.dataSet_TM.TrademarkClassSelect.Rows.Add(dr);
        //                    }
        //                }
        //                else
        //                {
        //                    this.dataSet_TM.TrademarkClassSelect.Rows.Clear();
        //                }
        //            }

        //            break;
        //    }
        //}
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
                    List<Public.CAttLiaisoner> catt = new List<Public.CAttLiaisoner>();
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
                mtb.Text = DateTime.Now.ToString("yyyy-MM-dd");
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

        private void cb_Country_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cb_Country.SelectedValue != null)
            //{
            //    this.attorneyTTableAdapter.FillByCountry(this.dataSet_Drop.AttorneyT, cb_Country.SelectedValue.ToString());
            //}
        }

        private void contextMenuStrip_ForDate_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
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

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void maskedTextBox_ApplicationDate_Leave(object sender, EventArgs e)
        {
            MaskedTextBox mak = (MaskedTextBox)sender;
            Public.Utility.CheckMaskedtextbox(mak);
        }
    }
}
