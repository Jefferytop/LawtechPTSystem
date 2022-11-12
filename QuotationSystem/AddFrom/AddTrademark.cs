using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace LawtechPTSystem.AddFrom
{
    public partial class AddTrademark : Form
    {
        public AddTrademark()
        {
            InitializeComponent();
        }

        private bool bIsChangeClass = false;
        /// <summary>
        /// 是否有變更商標分類
        /// </summary>
        public bool IsChangeClass
        {
            get { return bIsChangeClass; }
            set { bIsChangeClass = value; }
        }


        private void AddTrademark_Load(object sender, EventArgs e)
        {
          
            this.trademarkStyleModelTTableAdapter.Fill(this.dataSet_Drop.TrademarkStyleModelT);
         
            this.delegateFeatureTTableAdapter.Fill(this.dataSet_Drop.DelegateFeatureT);
           
            this.attorneyTTableAdapter1.Fill(this.dataSet_Attorney.AttorneyT);
            this.delegateTypeTableAdapter.Fill(this.dataSet_Drop.DelegateType);
            
          
            this.countryT_DropTableAdapter.Fill(this.qS_DataSet.CountryT_Drop);

            if (cb_Country.SelectedValue != null)
            {
                attorneyTBindingSource1.Filter = " CountrySymbol ='" + cb_Country.SelectedValue.ToString() + "'";
            }     
 
            this.worker_QuitNTableAdapter.Fill(this.qS_DataSet.Worker_QuitN);           
            this.trademarkTypeTTableAdapter.Fill(this.dataSet_Drop.TrademarkTypeT);
            this.trademarkStyleTTableAdapter.Fill(this.dataSet_Drop.TrademarkStyleT);
            this.tMStatusTTableAdapter.Fill(this.dataSet_Drop.TMStatusT);            
            this.applicantT_DropTableAdapter.Fill(this.qS_DataSet.ApplicantT_Drop);

            comboBox_DelegateType.SelectedIndex = 0;
            cb_WorkerName.SelectedValue = Properties.Settings.Default.WorkerKEY;
            maskedTextBox_EntrustDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            chb_IsBySelf.Checked = true;
            comboBox_DelegateType_SelectedIndexChanged(comboBox_DelegateType,null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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



            Public.CTrademarkManagement AddCTrademarkManagement = new Public.CTrademarkManagement();
            bool isExit = false;
            AddCTrademarkManagement.CheckValueExist("TrademarkNo", txt_TrademarkNo.Text, ref isExit);
            if (isExit)
            {
                MessageBox.Show("【本所案號】不得為重覆", "提示訊息");
                txt_TrademarkNo.Focus();
                return;
            }

            Public.PublicForm Forms = new Public.PublicForm();
           

            AddCTrademarkManagement.TrademarkNo = txt_TrademarkNo.Text;

            //申請人(串接)
            AddCTrademarkManagement.ApplicantNames = txt_ApplicantNames.Text;

            //申請人Key值(串接)
            AddCTrademarkManagement.ApplicantKeys = txt_ApplicantKeys.Text;


            AddCTrademarkManagement.TrademarkOvertureName = txt_TrademarkOvertureName.Text;


            AddCTrademarkManagement.TrademarkName = txt_TrademarkName.Text;


            //國別
            AddCTrademarkManagement.CountrySymbol = cb_Country.SelectedValue.ToString();

            AddCTrademarkManagement.StyleName = cb_StyleName.Text;


            //案件類型
            AddCTrademarkManagement.TMTypeName = cb_TMTypeName.Text;

            AddCTrademarkManagement.Status = cb_Status.SelectedValue != null ? (int)cb_Status.SelectedValue : -1;

            AddCTrademarkManagement.StatusExplain = txt_StatusExplain.Text;

            AddCTrademarkManagement.RegisterProductName = txt_RegisterProductName.Text;

            AddCTrademarkManagement.WorkerKey = cb_WorkerName.SelectedValue != null ? (int)cb_WorkerName.SelectedValue : -1;


            DateTime dt_EntrustDate;
            bool IsEntrustDate = DateTime.TryParse(maskedTextBox_EntrustDate.Text, out dt_EntrustDate);
            if (IsEntrustDate)
            {
                AddCTrademarkManagement.EntrustDate = dt_EntrustDate;

            }

            DateTime dt_OutsourcingDate;
            bool IsOutsourcingDate = DateTime.TryParse(maskedTextBox_OutsourcingDate.Text, out dt_OutsourcingDate);
            if (IsOutsourcingDate)
            {
                AddCTrademarkManagement.OutsourcingDate = dt_OutsourcingDate;

            }

            //委託性質
            AddCTrademarkManagement.DelegateFeatureKey = (int)comboBox_DelegateFeatureKey.SelectedValue;
            
            //委託類型
            AddCTrademarkManagement.DelegateType = (int)comboBox_DelegateType.SelectedValue;

            //委託類型
            AddCTrademarkManagement.TMStyleModelID = (int)comboBox_TMStyleModelID.SelectedValue;

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


            DateTime dt_ApplicationDate;
            bool IsApplicationDate = DateTime.TryParse(maskedTextBox_ApplicationDate.Text, out dt_ApplicationDate);
            if (IsApplicationDate)
            {
                AddCTrademarkManagement.ApplicationDate = dt_ApplicationDate;

            }
            else
            {
                AddCTrademarkManagement.ApplicationDate = null;
            }



            AddCTrademarkManagement.ApplicationNo = txt_ApplicationNo.Text;

            AddCTrademarkManagement.RegisterProduct = txt_RegisterProduct.Text;

            AddCTrademarkManagement.Remarks = txt_Remarks.Text;

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

            //dr["TrademarkID"] = AddCTrademarkManagement.TrademarkID;

            if (txt_PicPath.Text != "" && File.Exists(txt_PicPath.Text))
            {
                FileInfo Upfile = new FileInfo(txt_PicPath.Text);
                Public.CUpLoadFile uploadfile = new Public.CUpLoadFile();
                uploadfile.MainParentID = AddCTrademarkManagement.TrademarkID;

                uploadfile.Uploader = Properties.Settings.Default.WorkerName;
                uploadfile.FileDoc = "代表圖";
                uploadfile.FileKind = 4;
                uploadfile.FileType = 5;
               
                AddCTrademarkManagement.PicPath = string.Format(@"{0}\{1}", AddCTrademarkManagement.TrademarkID, Upfile.Name);

                uploadfile.FilePath = AddCTrademarkManagement.PicPath;
                Public.DLL dll = new Public.DLL();
                // string ss = string.Format("{0}\\{1}", dll.TrademarkFolderRoot, uploadfile.FilePath);
                dll.CreatFolder(4, AddCTrademarkManagement.TrademarkID.ToString());
                File.Copy(txt_PicPath.Text, string.Format("{0}\\{1}", dll.TrademarkFolderRoot, uploadfile.FilePath));
                uploadfile.Create();
            }

            //dr["PicPath"] = AddCTrademarkManagement.PicPath;
            AddCTrademarkManagement.Update();

            if (Forms.TrademarkMF != null)
            {
                DataRow dr = Forms.TrademarkMF.dt_TrademarkManagementT.NewRow();
                DataRow drV = Public.CTrademarkPublicFunction.GetTrademarkList(AddCTrademarkManagement.TrademarkID.ToString());
                dr.ItemArray = drV.ItemArray;
                Forms.TrademarkMF.dt_TrademarkManagementT.Rows.Add(dr);
            }

            MessageBox.Show("新增成功 " + AddCTrademarkManagement.TrademarkNo);
            this.Close();

        }

       

        private void Combo_OutsourcingAttorney_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Combo_OutsourcingAttorney.SelectedValue != null)
            {
                this.attLiaisonerTTableAdapter1.FillByWindow(this.dataSet_Attorney.AttLiaisonerT, (int)Combo_OutsourcingAttorney.SelectedValue, (int)Public.WindowType.PatContract);
            }
          
        }

        private void but_Path1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileInfo file = new FileInfo(openFileDialog1.FileName);

                txt_PicPath.Text = openFileDialog1.FileName;
                              
                
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txt_PicPath.Text = "";
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
            Public.DLL dll = new Public.DLL();
            dll.FetchDataTable(strSQL, this.qS_DataSet.LiaisonerTOnline);

        }
        #endregion

        private void chb_IsBySelf_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;

            Combo_OutsourcingAttorney.Enabled = Combo_OutsourcingAttorneyWorker.Enabled = txt_OutsourcingTrademarkNo.Enabled = maskedTextBox_OutsourcingDate.Enabled = !cb.Checked;

            txt_OutsourcingTrademarkNo.Text = "";
            maskedTextBox_OutsourcingDate.Text = "";
        }

        private void Combo_ApplicantKey_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_DelegateType.SelectedValue.ToString() == "1")//委託類型為申請人直接委託
            {
                txt_MainCustomer.Text = Combo_ApplicantKey.Text;

                if (Combo_ApplicantKey.SelectedValue != null)
                    this.liaisonerTOnlineTableAdapter.Fill(this.qS_DataSet.LiaisonerTOnline, (int)Combo_ApplicantKey.SelectedValue);
            }
        }

        private void comboBox_MainCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_DelegateType.SelectedValue.ToString() == "2")
            {
                if (comboBox_MainCustomer.SelectedValue != null)
                {
                    List<Public.CAttLiaisoner> catt = new List<Public.CAttLiaisoner>();
                    Public.CAttLiaisoner.ReadList(ref catt, "AttorneyKey=" + comboBox_MainCustomer.SelectedValue.ToString());
                    attLiaisonerTBindingSource1.DataSource = catt;
                }
            }
            else
            {
                if (txt_ApplicantKeys.Text != "")
                    GetLiaisonerTOnline(txt_ApplicantKeys.Text);
            }
        }

        private void maskedTextBox_EntrustDate_DoubleClick(object sender, EventArgs e)
        {
            MaskedTextBox mtb = (MaskedTextBox)sender;
            DateTime dt;
            bool IsSuccess = DateTime.TryParse(mtb.Text, out dt);
            if (!IsSuccess)
            {
                mtb.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        private void cb_Country_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Country.SelectedValue != null)
            {

                this.attorneyTTableAdapter.FillByCountry(this.dataSet_Drop.AttorneyT, cb_Country.SelectedValue.ToString());
            }
        }

        private void AddTrademark_KeyDown(object sender, KeyEventArgs e)
        {
            Public.Utility.ControlTab(e);
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
            contextMenuStrip2.Visible = false;

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
