using H3Operator.DBModels;
using LawtechPTSystem.SubFrom;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LawtechPTSystem
{
    public partial class MainFrom : Form
    {
        private int ProgressBarMaximum = 200;
        readonly Stopwatch sw = new System.Diagnostics.Stopwatch();

        public MainFrom()
        {
            InitializeComponent();

            dataGridView_Trademark.AutoGenerateColumns = false;
            dataGridView_Patent.AutoGenerateColumns = false;
            dataGridView_News.AutoGenerateColumns = false;
            Public.DynamicGridViewColumn.GetGridColum(ref dataGridView_Patent);
            Public.DynamicGridViewColumn.GetGridColum(ref dataGridView_Trademark);
            Public.DynamicGridViewColumn.GetGridColum(ref dataGridView_News);
        }

        BindingSource bSource_PatentControl;
        BindingSource bSource_TrademarkControl;
        BindingSource bSource_News;
        BindingSource bSource_Program;
        BindingSource bSource_WorkerProgram;

        List<ViewModel_WorkerProgram> programList = new List<ViewModel_WorkerProgram>();

        #region Property
        private int iWorkerID = -1;
        /// <summary>
        /// 登入者ID
        /// </summary>
        public int ProWorkerID
        {
            get { return iWorkerID; }
            set { iWorkerID = value; }
        }


        private int iOfficeRole = -1;
        /// <summary>
        /// 權限 0.最高權限 1.指定權限 2.專利  3.商標 4.會計經理
        /// </summary>
        public int OfficeRole
        {
            get { return iOfficeRole; }
            set { iOfficeRole = value; }
        }

        /// <summary>
        /// 檔案路徑
        /// </summary>
        public string Pro_FilePath
        {
            get;set;
        }
        private System.Data.DataTable dt_PatentComitEvent = new System.Data.DataTable();
        /// <summary>
        /// 專利資料集
        /// </summary>
        public System.Data.DataTable DT_PatentControlEvent
        {
            get
            {
                return dt_PatentComitEvent;
            }
        }

        private System.Data.DataTable dt_TrademarkControlEvent = new System.Data.DataTable();
        /// <summary>
        ///  商標資料集
        /// </summary>
        public System.Data.DataTable DT_TrademarkControlEvent
        {
            get
            {
                return dt_TrademarkControlEvent;
            }
        }

        private System.Data.DataTable dt_News= new System.Data.DataTable();
        /// <summary>
        ///  個人公怖欄
        /// </summary>
        public System.Data.DataTable DT_News
        {
            get
            {
                return dt_News;
            }
        }
        #endregion

        /// <summary>
        /// 更新專利個人待辦事件
        /// </summary>
        public void RefreshPatentEvent()
        {
            GetPatentComitEventForWorker();
        }

        /// <summary>
        ///  更新商標個人待辦事件
        /// </summary>
        public void RefreshTrademarkEvent()
        {
            GetTrademarkComitEventForWorker(); 
        }

        #region ExitToolStripMenuItem_Click 離開
        /// <summary>
        /// 離開
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Dear " + Properties.Settings.Default.WorkerName + " ： \r\n  是否確定離開系統??", "提示訊息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
            }

        }
        #endregion

        #region ShowMDIChild 設定子視窗
        /// <summary>
        /// 設定子視窗
        /// </summary>
        /// <param name="ChildForm"></param>
        private void ShowMDIChild(Form ChildForm)
        {
            try
            {
                //使用 MDI視窗
                //if (Properties.Settings.Default.IsMdiParent)
                //{
                //    Public.PublicForm Forms = new Public.PublicForm();
                    //Forms.MainFrom.IsMdiChild = true;
                //    ChildForm.MdiParent = Forms.MainFrom;
                //}

                if (Properties.Settings.Default.WindowStatus == "Max")
                {
                    ChildForm.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    ChildForm.WindowState = FormWindowState.Normal;
                }
                ChildForm.Show();
            }
            catch (System.Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }
        #endregion

        /// <summary>
        /// 檢查視窗狀態
        /// </summary>
        /// <param name="fm"></param>
        private void CheckWindowsStatus(Form fm)
        {
            if (fm.WindowState == FormWindowState.Minimized)
            {
                fm.WindowState = FormWindowState.Normal;
            }
        }

        private void ClickMenuItem(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            if (sender is ToolStripMenuItem)
            {
                ToolStripMenuItem menuitem = (ToolStripMenuItem)sender;
               // bool hasForm = false;
                switch (menuitem.Name)
                {
                    case "QPToolStripMenuItem":

                        if (Forms.ClientFeeMF != null)
                        {
                            Forms.ClientFeeMF.Activate();
                            CheckWindowsStatus(Forms.ClientFeeMF);
                        }
                        else
                        {
                            SubFrom.ClientFeeMF CliMF = new SubFrom.ClientFeeMF();
                            ShowMDIChild(CliMF);
                        }
                        break;                  

                    case "QMToolStripMenuItem":


                        if (Forms.QPForm != null)
                        {
                            Forms.QPForm.Activate();
                        }
                        else
                        {
                            SubFrom.QPForm qpForm = new SubFrom.QPForm();
                            ShowMDIChild(qpForm);
                        }
                        break;

                    default:
                        break;
                }
            }
        }



        #region 查詢  申請需知
        private void PettiontoolStripMenuItem_Click(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            if (Forms.PetitionSearchMF != null)
            {
                Forms.PetitionSearchMF.Activate();
            }
            else
            {
                SubFrom.PetitionSearchMF PetSMF = new SubFrom.PetitionSearchMF();
                ShowMDIChild(PetSMF);
            }
        }
        #endregion

        private void PetitionSubjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SubFrom.SubjectMF SMF = new SubFrom.SubjectMF();
            SMF.ShowDialog();
        }

        #region 關閉表單 MainFrom_FormClosed
        /// <summary>
        /// 表單關閉事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainFrom_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.MainFrom = null;

            try
            {
                DB_Models.DB_WorkerLoginTModel login = new DB_Models.DB_WorkerLoginTModel();
                    login.WorkerKey = iWorkerID;
                    login.OutTime = DateTime.Now;
                    login.Online = false;
                    login.Create();
                
            }
            catch
            {

            }
            finally
            {
                Public.LoginForm LoginMF=new Public.LoginForm();

                if (!LoginMF.Login.Visible)
                {
                    Application.Exit();
                }
            }
        }
        #endregion

        #region MainFrom_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainFrom_Load(object sender, EventArgs e)
        {

            Public.PublicForm Forms = new Public.PublicForm();
            Forms.MainFrom = this;

            ProWorkerID = Properties.Settings.Default.WorkerKEY;
            OfficeRole = Properties.Settings.Default.OfficeRole;
            this.Text = Properties.Settings.Default.SystemName;

            lab_WorkerName.Text = Properties.Settings.Default.WorkerName;
            lab_OfficeRoleName.Text = Properties.Settings.Default.OfficeRoleName;
            lab_OnlineTime.Text = Properties.Settings.Default.OnlineTime.ToString("yyyy-MM-dd HH:mm");
            txt_OS.Text = string.Format("{0}  {1}bit", Properties.Settings.Default.OSVersion, Properties.Settings.Default.OSbit);

            txt_IPAddressList.Text = Properties.Settings.Default.IPAddressList;
            lab_IPAddress.Text = Properties.Settings.Default.IPAddress;

            label_DBName.Text = Properties.Settings.Default.DatabaseName;
            label_DataSource.Text = Properties.Settings.Default.DataSource;

            txt_MAC.Text = Properties.Settings.Default.MAC;

            if (OfficeRole == 0)
            {
                toolStripMenuItem_SetGridColumn.Visible = true;
                toolStripMenuItem_TmSetGridColumn.Visible = true;
            }
            else {
                toolStripMenuItem_SetGridColumn.Visible = false;
                toolStripMenuItem_TmSetGridColumn.Visible = false;
            }

                #region 取得檔案伺服器的權限
               // Public.DLL dll = new Public.DLL();

            if (Properties.Settings.Default.IsFileServer)
            {
                lab_IsFileServer.Text = "啟用";
                lab_IsFileServer.ForeColor = System.Drawing.Color.Blue;

                if (Properties.Settings.Default.FileServerType == "0")
                {
                    lab_FileServerType.Text = "(本機路徑)";                   
                    if (string.IsNullOrEmpty(Properties.Settings.Default.FileServerLocalhostPath_WorkerT.Trim()))
                    {
                        //預設路徑
                        txt_FilePath.Text = Path.Combine(Properties.Settings.Default.FileServerLocalhostPath, Properties.Settings.Default.RootFolder);
                    }
                    else {
                        //user 自定義路徑
                        txt_FilePath.Text = Path.Combine(Properties.Settings.Default.FileServerLocalhostPath_WorkerT, Properties.Settings.Default.RootFolder);
                    }
                }
                else
                {
                    lab_FileServerType.Text = "(區域網路)";
                    txt_FilePath.Text = Path.Combine(Properties.Settings.Default.IntranetPath, Properties.Settings.Default.RootFolder);
                }
                Pro_FilePath = txt_FilePath.Text;
                //建立相關的資料夾
                //dll.CreatFolder(true);
                CreatFolderAsync();


            }
            else {
                lab_IsFileServer.Text = "未啟用";
                lab_IsFileServer.ForeColor = System.Drawing.Color.Red;
            }        
            #endregion



            this.statusStrip1.Refresh();

            bSource_Program = new BindingSource();
            bSource_WorkerProgram = new BindingSource();
            



            System.Data.SqlClient.SqlParameter[] ParaList ={
                                                         H3Operator.DBHelper.DBAccess.MakeInParam("WorkerKEY",SqlDataType.Int,ProWorkerID)                                                          
                                                          };

            object objResult = ViewModel_WorkerProgram.ReadViewTableList("WorkerProgramT.WorkerKEY=@WorkerKEY", ref programList, ParaList);

            bSource_WorkerProgram.DataSource = programList;

            List<Program_Model> program = new List<Program_Model>();
            Program_Model.ReadList(ref program, "IsOpen='True'");
            bSource_Program.DataSource = program;
                       
            MenuItemPermissions();

            if (OfficeRole == 1)
            {
                if (Properties.Settings.Default.HistoryRecordMode == "0")
                {
                    toolStripMenuItem_PatentView.Visible = false;
                    toolStripMenuItem_TmView.Visible = false;
                }
                else
                {
                    toolStripMenuItem_PatentView.Visible = true;
                    toolStripMenuItem_TmView.Visible = true;
                }
            }

            #region 專利個人待辦事項
            bSource_PatentControl = new BindingSource();
            dataGridView_Patent.DataSource = bSource_PatentControl;
            bindingNavigator_Patent.BindingSource = bSource_PatentControl;
            GetPatentComitEventForWorker();
            #endregion

            #region 商標個人待辦事項
            bSource_TrademarkControl = new BindingSource();
            dataGridView_Trademark.DataSource = bSource_TrademarkControl;
            bindingNavigator_Trademark.BindingSource = bSource_TrademarkControl;
            GetTrademarkComitEventForWorker();
            #endregion

            #region 取得登入者的公怖欄資訊
            bSource_News = new BindingSource();
            dataGridView_News.DataSource = bSource_News;
            bindingNavigator_News.BindingSource = bSource_News;
            GetNewsWorker();
            #endregion

            

            DB_Models.DB_WorkerLoginTModel login = new DB_Models.DB_WorkerLoginTModel();

            login.WorkerKey = Properties.Settings.Default.WorkerKEY;
            login.Online = true;
            login.OnlineTime = DateTime.Now;
            login.LoginIP = Properties.Settings.Default.IPAddressList + "\r\n" + Properties.Settings.Default.IPAddress;
            login.LoginRemark = string.Format("CPU ID:{0}  ; MAC:{1}", Properties.Settings.Default.CPU, Properties.Settings.Default.MAC);
            login.Create();

            //記錄登入時間
            Properties.Settings.Default.OnlineTime = login.OnlineTime.Value;
            Properties.Settings.Default.Save();

            GetPatentEventPracticalityPayList();

            toolStripStatusLabel_User.Text = "登入者："+Properties.Settings.Default.WorkerName+" ["+Properties.Settings.Default.OfficeRoleName+"]  ";

        }
        #endregion

        public void GetPatentEventPracticalityPayList()
        {
            int iworkerKey = Properties.Settings.Default.WorkerKEY;
            DataTable dt = Public.CPatentPublicFunction.GetPatentEventPracticalityPayList(iworkerKey, DateTime.Now);
            if (dt.Rows.Count == 4)
            {
                decimal decPatMon;
                decimal.TryParse(dt.Rows[0]["MonthFee"].ToString(), out decPatMon);
                lab_PatMon .Text= decPatMon.ToString("#,##0");

                decimal decPatMon2;
                decimal.TryParse(dt.Rows[1]["MonthFee"].ToString(), out decPatMon2);
                lab_PatMon2.Text = decPatMon2.ToString("#,##0");

                decimal decTmMoth;
                decimal.TryParse(dt.Rows[2]["MonthFee"].ToString(), out decTmMoth);
                lab_TmMoth.Text = decTmMoth.ToString("#,##0");

                decimal decTmMonth2;
                decimal.TryParse(dt.Rows[3]["MonthFee"].ToString(), out decTmMonth2);
                lab_TmMonth2.Text = decTmMonth2.ToString("#,##0");
            }
        }

        #region 非同步--創建資料夾 private async void CreatFolderAsync()
        /// <summary>
        /// 非同步--創建資料夾
        /// </summary>
        private async void CreatFolderAsync()
        {

            Task t = Task.Run(() =>
               {
                   Public.DLL dll = new Public.DLL();
                   dll.CreatFolder(true);
               });

            await t;
            bool isCheckConnection = Properties.Settings.Default.IsFileServerConnection;
            if (isCheckConnection)
            {
                txt_FilePath.Text = "(路徑正確)\r\n" + Pro_FilePath;
                txt_FilePath.ForeColor = System.Drawing.Color.DarkSlateBlue;
            }
            else
            {
                txt_FilePath.Text = "(找不到網路路徑)\r\n" + Pro_FilePath;
                txt_FilePath.ForeColor = System.Drawing.Color.Red;
            }
            linkLabel_CheckFilePath.Enabled = true;
        } 
        #endregion

        #region 檔案路徑檢測  linkLabel_CheckFilePath
        /// <summary>
        /// 檔案路徑檢測
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel_CheckFilePath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel_CheckFilePath.Enabled = false;
            if (!string.IsNullOrEmpty(Pro_FilePath))
            {
                txt_FilePath.Text = "(檢測中...)\r\n" + Pro_FilePath;
                CreatFolderAsync();
            }
        } 
        #endregion

        /// <summary>
        /// 取得登入者的專利待辦事項清單
        /// </summary>
        public void GetPatentComitEventForWorker()
        {
            dt_PatentComitEvent = Public.CPatentPublicFunction.GetComitEvent("FinishDate is null and WorkerKey=" + Properties.Settings.Default.WorkerKEY.ToString());
            bSource_PatentControl.DataSource = dt_PatentComitEvent;
        }

        /// <summary>
        /// 取得登入者的商標待辦事項清單
        /// </summary>
        public void GetTrademarkComitEventForWorker()
        {
            dt_TrademarkControlEvent = Public.CTrademarkPublicFunction.GetComitEvent("FinishDate is null and WorkerKey=" + Properties.Settings.Default.WorkerKEY.ToString());
            bSource_TrademarkControl.DataSource = dt_TrademarkControlEvent;
        }

        /// <summary>
        /// 取得登入者的公怖欄資訊
        /// </summary>
        public void GetNewsWorker()
        {
            string strSQL = string.Format(" NewsKey not in(select NewsKey from NewsWorkerT where WorkerKey={0}) ", iWorkerID);
             Public.CNewsPublicFunction.GetNewsList(strSQL,ref dt_News);
            bSource_News.DataSource = dt_News;
        }

        #region MenuItemPermissions
        /// <summary>
        /// 確認使用者權限
        /// </summary>
        public void MenuItemPermissions()
        {
            int iCount = menuStrip1.Items.Count;
            this.toolStripProgressBar1.Visible = true;
            this.toolStripProgressBar1.Maximum = ProgressBarMaximum;
           
            foreach (ToolStripItem item in menuStrip1.Items)
            {
              ToolStripMenuItem MenuItem=(ToolStripMenuItem)item;

              bool IsPermissions=false;

              if (item.Tag != null && item.Tag.ToString() != "")
              {
                  if (MenuItem.DropDownItems.Count > 0)
                  {
                      item.Visible = MenuItemPermissions(MenuItem);
                  }
                  else
                  {
                      IsPermissions = PermissionsWorker( item.Tag.ToString());
                      item.Visible = IsPermissions;
                  }
              }

              this.toolStripProgressBar1.Value++;
            }
           
            this.toolStripProgressBar1.Visible = false;
            this.toolStripStatusLabel1.Visible = false;
        }



        public bool MenuItemPermissions(ToolStripMenuItem Items)
        {
            int iCount = 0;

            foreach (ToolStripMenuItem item in Items.DropDownItems)
            {
                bool IsPermissions =false;

                if (item.Tag != null && item.Tag.ToString() != "")
                {
                    if (item.DropDownItems.Count > 0)
                    {
                        IsPermissions = MenuItemPermissions(item);
                        item.Visible = IsPermissions;
                    }
                    else
                    {
                        IsPermissions = PermissionsWorker( item.Tag.ToString());
                        item.Visible = IsPermissions;
                    }

                    if (IsPermissions)
                    {
                        iCount++;
                    }

                    this.toolStripProgressBar1.Value++;
                }
            }

            if (iCount > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        

        #region 判斷登入者的程式授權
        /// <summary>
        /// 判斷登入者的程式授權; PublicProgram為公用的程式
        /// </summary>       
        /// <param name="programName"></param>
        /// <returns></returns>
        public  bool PermissionsWorker( string programName)
        {
            //AccountingFeeMF
            if (programName != "PublicProgram")//判斷是否為公用的程式  PublicProgram
            {
                
                //bSource_Program.Filter = "ProgramSymbol='" + programName + "'";
               // bSource_WorkerProgram.Filter = "WorkerKEY=" + ProWorkerID.ToString() + " and ProgramSymbol='" + programName + "'";

                int iFindIndex = ((List<ViewModel_WorkerProgram>)bSource_WorkerProgram.DataSource).FindIndex((x) => x.ProgramSymbol == programName);

                //程式種類
                int iProgramkind = -1;
                if (bSource_Program.Count > 0)
                {
                    var item = ((List<Program_Model>)bSource_Program.DataSource).Find((x) => x.ProgramSymbol == programName);
                    if (item != null)
                    {
                        iProgramkind = item.ProgramKind ?? -1;
                    }
                }

                bool ReValue = false;


                if (OfficeRole == (int)Public.OfficeRoleEnum.AdminRole)//最高授權
                {
                    return true;
                }
                else if (OfficeRole == (int)Public.OfficeRoleEnum.PatRole)//專利授權
                {
                    if (iProgramkind == (int)Public.OfficeRoleEnum.PatRole)
                    {
                        return true;
                    }
                    else
                    {                       
                        if (bSource_WorkerProgram.Count > 0)
                        {
                            if (bSource_WorkerProgram.Current.ToString() == "LawtechPTSystem.ViewModel_WorkerProgram")
                            {
                                if (iFindIndex != -1)
                                {
                                    ReValue = programList[iFindIndex].SearchAuthority;
                                }
                                else
                                {
                                    ReValue = false;
                                }
                            }
                            else
                            {
                                ReValue = (bool)((System.Data.DataRowView)(bSource_WorkerProgram.Current)).Row["SearchAuthority"];
                            }
                        }

                        return ReValue;
                    }
                }
                else if (OfficeRole == (int)Public.OfficeRoleEnum.TmRole)//商標授權
                {
                    if (iProgramkind == (int)Public.OfficeRoleEnum.TmRole)
                    {
                        return true;
                    }
                    else
                    {

                        if (bSource_WorkerProgram.Count > 0)
                        {
                            if (bSource_WorkerProgram.Current.ToString() == "LawtechPTSystem.ViewModel_WorkerProgram")
                            {
                                if (iFindIndex != -1)
                                {
                                    ReValue = programList[iFindIndex].SearchAuthority;
                                }
                                else
                                {
                                    ReValue = false;
                                }
                            }
                            else
                            {
                                ReValue = (bool)((System.Data.DataRowView)(bSource_WorkerProgram.Current)).Row["SearchAuthority"];
                            }
                        }

                        return ReValue;
                    }
                }
                //else if (OfficeRole == (int)Public.OfficeRoleEnum.LegalRole)//法務
                //{
                //    if (iProgramkind == (int)Public.OfficeRoleEnum.LegalRole)
                //    {
                //        return true;
                //    }
                //    else
                //    {

                //        if (bSource_WorkerProgram.Count > 0)
                //        {
                //            if (bSource_WorkerProgram.Current.ToString() == "LawtechPTSystem.ViewModel_WorkerProgram")
                //            {
                //                if (iFindIndex != -1)
                //                {
                //                    ReValue = ((LawtechPTSystem.ViewModel_WorkerProgram)(bSource_WorkerProgram.Current)).SearchAuthority;
                //                }
                //                else
                //                {
                //                    ReValue = false;
                //                }
                //            }
                //            else
                //            {
                //                ReValue = (bool)((System.Data.DataRowView)(bSource_WorkerProgram.Current)).Row["SearchAuthority"];
                //            }
                //        }

                //        return ReValue;
                //    }
                //}
                else//指定授權
                {
                    if (bSource_WorkerProgram.Count > 0)
                   {
                       if (bSource_WorkerProgram.Current.ToString() == "LawtechPTSystem.ViewModel_WorkerProgram")
                       {
                           if (iFindIndex != -1)
                           {
                               ReValue = programList[iFindIndex].SearchAuthority;
                           }
                           else
                           {
                               ReValue = false;
                           }
                       }
                       else
                       {
                           ReValue = (bool)((System.Data.DataRowView)(bSource_WorkerProgram.Current)).Row["SearchAuthority"];
                       }
                   }

                    return ReValue;
                }
            }
            else
            {
                return true;
            }

        }
        #endregion

        #endregion

        #region 事務所資料維護
        /// <summary>
        /// 事務所資料維護
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.AttorneyMF != null)
            {
                Forms.AttorneyMF.Activate();              
            }
            else
            {
                SubFrom.AttorneyMF AttMF = new SubFrom.AttorneyMF();
                ShowMDIChild(AttMF);
            }
        }
        #endregion

        #region 事務所查詢 private void toolStripMenuItem_AttorneySeach_Click(object sender, EventArgs e)
        /// <summary>
        /// 事務所查詢
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_AttorneySeach_Click(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.AttorneySearchMF != null)
            {
                Forms.AttorneySearchMF.Activate();
            }
            else
            {
                SubFrom.AttorneySearchMF AttMF = new SubFrom.AttorneySearchMF();
                ShowMDIChild(AttMF);
            }
        } 
        #endregion

        #region 標準牌價管理 private void toolStripMenuItem3_Click(object sender, EventArgs e)
        /// <summary>
        /// 標準牌價管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.QPForm != null)
            {
                Forms.QPForm.Activate();
            }
            else
            {
                SubFrom.QPForm QMF = new SubFrom.QPForm();
                ShowMDIChild(QMF);
            }
        } 
        #endregion

        #region 申請需知
        /// <summary>
        /// 申請需知
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.PetitionMF != null)
            {
                Forms.PetitionMF.Activate();
                CheckWindowsStatus(Forms.PetitionMF);
            }
            else
            {
                SubFrom.PetitionMF PMF = new SubFrom.PetitionMF();
                ShowMDIChild(PMF);
            }
        } 
        #endregion

        internal void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.ApplicantSearchMF != null)
            {
                Forms.ApplicantSearchMF.Activate();
                CheckWindowsStatus(Forms.ApplicantSearchMF);
            }
            else
            {
                SubFrom.ApplicantSearchMF ASMF = new SubFrom.ApplicantSearchMF();
                ShowMDIChild(ASMF);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.ApplicantMF != null)
            {
                Forms.ApplicantMF.Activate();
            }
            else
            {
                SubFrom.ApplicantMF AMF = new SubFrom.ApplicantMF();
                ShowMDIChild(AMF);
            }
        }

        #region 牌價查詢
        /// <summary>
        /// 牌價查詢
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.QPSearchForm != null)
            {
                Forms.QPSearchForm.Activate();
                CheckWindowsStatus(Forms.QPSearchForm);
            }
            else
            {
                SubFrom.QPSearchForm CAMF = new SubFrom.QPSearchForm();
                ShowMDIChild(CAMF);
            }
        }
        #endregion 

        #region 設定檔案上傳路徑
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 設定檔案上傳路徑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SubFrom.UpFilePath filepath = new LawtechPTSystem.SubFrom.UpFilePath();
            filepath.ShowDialog();
        }
        #endregion

        //private void MailToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    Public.PublicForm Forms = new Public.PublicForm();

        //    if (Forms.PrintLabelMF != null)
        //    {
        //        Forms.PrintLabelMF.Activate();
        //    }
        //    else
        //    {
        //        SubFrom.PrintLabelMF PL = new SubFrom.PrintLabelMF();
        //        ShowMDIChild(PL);
        //    }

        //}

        #region 員工權限管理ToolStripMenuItem_Click(object sender, EventArgs e)
        /// <summary>
        /// 員工權限管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 員工權限管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.AuthorityMF != null)
            {
                Forms.AuthorityMF.Activate();
                CheckWindowsStatus(Forms.AuthorityMF);
            }
            else
            {
                SubFrom.AuthorityMF PL = new SubFrom.AuthorityMF();
                ShowMDIChild(PL);
            }
        } 
        #endregion

        #region 知識管理
        private void 文章上傳ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.UploadFile != null)
            {
                Forms.UploadFile.Activate();
                CheckWindowsStatus(Forms.UploadFile);
            }
            else
            {
                SubFrom.UploadFile uf = new SubFrom.UploadFile();
                ShowMDIChild(uf);
            }
        }
        #endregion 

        private void 關鍵字設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Public.PublicForm Forms = new Public.PublicForm();

            //if (Forms.KeyWords != null)
            //{
            //    Forms.KeyWords.Activate();
            //}
            //else
            //{
            //    SubFrom.KeyWords kw = new SubFrom.KeyWords();
            //    ShowMDIChild(kw);
            //}

            SubFrom.KeyWords keywords = new LawtechPTSystem.SubFrom.KeyWords();
            keywords.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (menuStrip1.Visible != false)
            {
                menuStrip1.Visible = false;
            }
            else 
            {
                menuStrip1.Visible = true;
            }


        }

      

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (menuStrip1.Visible)
            {
                menuStrip1.Visible = false;
                //pictureBox1.BackgroundImage = global::LawtechPTSystem.Properties.Resources.manage_show;
            }
            else
            {

                menuStrip1.Visible = true;
               // pictureBox1.BackgroundImage = global::LawtechPTSystem.Properties.Resources.manage_close;
            }
        }

        #region 專利案件管理  internal void toolStripMenuItem_PATManagement_Click(object sender, EventArgs e)
        /// <summary>
        /// 專利案件管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void toolStripMenuItem_PATManagement_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.PatListMF != null)
            {
                Forms.PatListMF.Activate();
                CheckWindowsStatus(Forms.PatListMF);
            }
            else
            {
                SubFrom.PatListMF patent = new SubFrom.PatListMF();
                ShowMDIChild(patent);
            }

            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text = ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        } 
        #endregion

        #region 專利--各國年費
        /// <summary>
        /// 專利--各國年費
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void 各國年費設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.Triff_PAT != null)
            {
                Forms.Triff_PAT.Activate();
                CheckWindowsStatus(Forms.Triff_PAT);
            }
            else
            {
                SubFrom.Triff_PAT triffPat = new SubFrom.Triff_PAT();
                ShowMDIChild(triffPat);
            }
            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text =" | "+ ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        } 
        #endregion

        #region 專利--事件內容設定
        /// <summary>
        /// 專利--事件內容設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void 事件內容設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.ComitContentTMF != null)
            {
                Forms.ComitContentTMF.Activate();
                CheckWindowsStatus(Forms.ComitContentTMF);
            }
            else
            {
                SubFrom.ComitContentTMF ComitContent = new SubFrom.ComitContentTMF();
                ShowMDIChild(ComitContent);
            }

            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text =" | "+ ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        } 
        #endregion

        internal void 一般來函設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.PATNotifyContentMF != null)
            {
                Forms.PATNotifyContentMF.Activate();
                CheckWindowsStatus(Forms.PATNotifyContentMF);
            }
            else
            {
                SubFrom.PATNotifyContentMF PATNotifyContent = new SubFrom.PATNotifyContentMF();
                ShowMDIChild(PATNotifyContent);
            }
        }

        internal void 期限來函設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.PATNotifyDueMF != null)
            {
                Forms.PATNotifyDueMF.Activate();
                CheckWindowsStatus(Forms.PATNotifyDueMF);
            }
            else
            {
                SubFrom.PATNotifyDueMF PATNotifyDue = new SubFrom.PATNotifyDueMF();
                ShowMDIChild(PATNotifyDue);
            }
        }

        internal void 案件狀態設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.PATStatusMF != null)
            {
                Forms.PATStatusMF.Activate();
                CheckWindowsStatus(Forms.PATStatusMF);
            }
            else
            {
                SubFrom.PATStatusMF PATStatus = new SubFrom.PATStatusMF();
                ShowMDIChild(PATStatus);
            }

            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text =" | "+ ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        }
         
        #region 專利--案件性質 internal void 案件性質設定ToolStripMenuItem_Click(object sender, EventArgs e)
        /// <summary>
        /// 專利--案件性質
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void 案件性質設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.PATFeatureMF != null)
            {
                Forms.PATFeatureMF.Activate();
                CheckWindowsStatus(Forms.PATFeatureMF);
            }
            else
            {
                SubFrom.PATFeatureMF PATFeature = new SubFrom.PATFeatureMF();
                ShowMDIChild(PATFeature);
            }

            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text = " | " + ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        } 
        #endregion
    
        /// <summary>
        /// 商標--事件內容設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void 一般來函設定ToolStripMenuItem_TM_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.TMNotifyDueMF != null)
            {
                Forms.TMNotifyDueMF.Activate();
                CheckWindowsStatus(Forms.TMNotifyDueMF);
            }
            else
            {
                SubFrom.TMNotifyDueMF NotifyContentTM = new SubFrom.TMNotifyDueMF();
                ShowMDIChild(NotifyContentTM);
            }
            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text = " | " + ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        }

        internal void 期限來函設定ToolStripMenuItem_TM_Click(object sender, EventArgs e)
        {

        }

        #region 商標--案件階段設定
        /// <summary>
        /// 商標--案件階段設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void 案件狀態設定ToolStripMenuItem_TM_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.TMStatusMF != null)
            {
                Forms.TMStatusMF.Activate();
                CheckWindowsStatus(Forms.TMStatusMF);
            }
            else
            {
                SubFrom.TMStatusMF StatusTM = new SubFrom.TMStatusMF();
                ShowMDIChild(StatusTM);
            }

            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text =" | "+ ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        } 
        #endregion

        #region 商標--案件類別設定
        /// <summary>
        /// 商標--案件類別設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void 案件類別設定ToolStripMenuItem_TM_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.TMTypeMF != null)
            {
                Forms.TMTypeMF.Activate();
                CheckWindowsStatus(Forms.TMTypeMF);
            }
            else
            {
                SubFrom.TMTypeMF FeatureTM = new SubFrom.TMTypeMF();
                ShowMDIChild(FeatureTM);
            }

            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text =" | "+ ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        } 
        #endregion

        private void 專利主功能表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.PatentMF != null)
            {
                Forms.PatentMF.Activate();
                CheckWindowsStatus(Forms.PatentMF);
            }
            else
            {
                SubFrom.PatentMF PatMF = new SubFrom.PatentMF();
                ShowMDIChild(PatMF);
            }

            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text =" | "+ ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        }

        /// <summary>
        /// 商標主功能表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_TMmain_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.TMMF != null)
            {
                Forms.TMMF.Activate();
                CheckWindowsStatus(Forms.TMMF);
            }
            else
            {
                SubFrom.TMMF TMmain = new SubFrom.TMMF();
                ShowMDIChild(TMmain);
            }

            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text =" | "+ ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        }

        /// <summary>
        /// 標準作業流程設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void 事件處理歷程設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.PATEventProcess != null)
            {
                Forms.PATEventProcess.Activate();
                CheckWindowsStatus(Forms.PATEventProcess);
            }
            else
            {
                SubFrom.PATEventProcess EventProcess = new SubFrom.PATEventProcess();
                ShowMDIChild(EventProcess);
            }

            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text =" | "+ ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        }

        #region 專利--費用種類設定
        /// <summary>
        /// 專利--費用種類設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void 費用種類設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.PatFeePhase != null)
            {
                Forms.PatFeePhase.Activate();
                CheckWindowsStatus(Forms.PatFeePhase);
            }
            else
            {
                SubFrom.PatFeePhase Pafeephase = new SubFrom.PatFeePhase();
                ShowMDIChild(Pafeephase);
            }

            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text =" | "+ ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        }
        #endregion

        #region 商標--各國年費
        /// <summary>
        /// 商標--各國年費
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void 各國申請費設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.Triff_TM != null)
            {
                Forms.Triff_TM.Activate();
                CheckWindowsStatus(Forms.Triff_TM);
            }
            else
            {
                SubFrom.Triff_TM triffTM = new SubFrom.Triff_TM();
                ShowMDIChild(triffTM);
            }

            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text =" | "+ ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        } 
        #endregion

        internal void 待處理申請案管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        #region 商標尼斯分類設定       
        /// <summary>
        /// 商標尼斯分類設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void ToolStripMenuItem_TMClassification_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.TrademarkClassificationMF != null)
            {
                Forms.TrademarkClassificationMF.Activate();
                CheckWindowsStatus(Forms.TrademarkClassificationMF);
            }
            else
            {
                SubFrom.TrademarkClassificationMF ClassificationMF = new SubFrom.TrademarkClassificationMF();
                ShowMDIChild(ClassificationMF);
            }

            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text =" | "+ ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        }
        #endregion

        #region 商標事件處理設定
        /// <summary>
        /// 商標事件處理設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void toolStripMenuItem_TMEventProcess_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.TrademarkEventProcess != null)
            {
                Forms.TrademarkEventProcess.Activate();
                CheckWindowsStatus(Forms.TrademarkEventProcess);
            }
            else
            {
                SubFrom.TrademarkEventProcess TrademarkEventProcessMF = new SubFrom.TrademarkEventProcess();
                ShowMDIChild(TrademarkEventProcessMF);
            }

            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text =" | "+ ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        }
        #endregion

        #region 商標費用種類設定
        /// <summary>
        /// 商標費用種類設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void toolStripMenuItem_TMFeePhase_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.TrademarkFeePhase != null)
            {
                Forms.TrademarkFeePhase.Activate();
                CheckWindowsStatus(Forms.TrademarkFeePhase);
            }
            else
            {
                SubFrom.TrademarkFeePhase Pafeephase = new SubFrom.TrademarkFeePhase();
                ShowMDIChild(Pafeephase);
            }

            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text =" | "+ ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        }
        #endregion 

        #region 商標式樣設定
        /// <summary>
        /// 商標式樣設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void 商標式樣設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.TrademarkStyle != null)
            {
                Forms.TrademarkStyle.Activate();
                CheckWindowsStatus(Forms.TrademarkStyle);
            }
            else
            {
                SubFrom.TrademarkStyle TMStyle = new SubFrom.TrademarkStyle();
                ShowMDIChild(TMStyle);
            }

            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text =" | "+ ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        }
        #endregion

        #region 商標--事件種類
        /// <summary>
        /// 商標--事件種類
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void ToolStripMenuItem_TMNotifyEvent_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.TrademarkNotifyEventType != null)
            {
                Forms.TrademarkNotifyEventType.Activate();
                CheckWindowsStatus(Forms.TrademarkNotifyEventType);
            }
            else
            {
                SubFrom.TrademarkNotifyEventType TMType = new SubFrom.TrademarkNotifyEventType();
                ShowMDIChild(TMType);
            }

            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text =" | "+ ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        } 
        #endregion

        #region 商標基本資料管理
        /// <summary>
        /// 商標基本資料管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void ToolStripMenuItem_TrademarkManagement_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.TrademarkMF != null)
            {
                Forms.TrademarkMF.Activate();
                CheckWindowsStatus(Forms.TrademarkMF);
            }
            else
            {
                SubFrom.TrademarkMF TMMF = new SubFrom.TrademarkMF();
                ShowMDIChild(TMMF);
            }

            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text =" | "+ ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        } 
        #endregion

        #region 舊版本 不要使用 private void ToolStripMenuItem_TrademarkEvent_Click(object sender, EventArgs e)
        /// <summary>
        /// 舊版本 不要使用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_TrademarkEvent_Click(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.TrademarkControlEvent != null)
            {
                Forms.TrademarkControlEvent.Activate();
            }
            else
            {
                SubFrom.TrademarkControlEvent TMControlEvent = new SubFrom.TrademarkControlEvent();
                ShowMDIChild(TMControlEvent);
            }
        } 
        #endregion

        #region 專利--案件查詢統計 internal void 案件統計ToolStripMenuItem_Click(object sender, EventArgs e)
        /// <summary>
        /// 專利--案件查詢統計
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void 案件統計ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.PatentStatistics != null)
            {
                Forms.PatentStatistics.Activate();
                CheckWindowsStatus(Forms.PatentStatistics);
            }
            else
            {
                SubFrom.PatentStatistics Statistics = new SubFrom.PatentStatistics();
                ShowMDIChild(Statistics);
            }

            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text = " | " + ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        }
        #endregion

        #region 商標--案件查詢統計  private void ToolStripMenuItem_TrademarkAnalysis_Click(object sender, EventArgs e)
        /// <summary>
        /// 商標--案件查詢統計
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void ToolStripMenuItem_TrademarkAnalysis_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.TrademarkStatistics != null)
            {
                Forms.TrademarkStatistics.Activate();
                CheckWindowsStatus(Forms.TrademarkStatistics);
            }
            else
            {
                SubFrom.TrademarkStatistics Statistics = new SubFrom.TrademarkStatistics();

                ShowMDIChild(Statistics);
            }

            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text = " | " + ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        } 
        #endregion

        #region 幣別匯率設定 private void toolStripMenuItem_MoneyMF_Click(object sender, EventArgs e)
        /// <summary>
        /// 幣別匯率設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_MoneyMF_Click(object sender, EventArgs e)
        {

            SubFrom.MoneyMF mf = new SubFrom.MoneyMF();

            mf.ShowDialog();
        } 
        #endregion

        private void ToolStripMenuItem_EmailSet_Click(object sender, EventArgs e)
        {
            US.EmailSet mail = new LawtechPTSystem.US.EmailSet();
            mail.ShowDialog();
        }

        #region 郵件範本設定 private void toolStripMenuItem_EmailSampleList_Click(object sender, EventArgs e)
        /// <summary>
        /// 郵件範本設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_EmailSampleList_Click(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.MailSampleList != null)
            {
                Forms.MailSampleList.Activate();
                CheckWindowsStatus(Forms.MailSampleList);
            }
            else
            {
                SubFrom.MailSampleList MailSampl = new SubFrom.MailSampleList();

                ShowMDIChild(MailSampl);
            }
        }
        #endregion

        private void toolStripMenuItem_CurrencyExchange_Click(object sender, EventArgs e)
        {
            toolStripMenuItem_MoneyMF_Click(null,null);
        }

        #region 應付款項
        /// <summary>
        /// 應付款項
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_PaymentMF_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.AccountingPaymentMF != null)
            {
                Forms.AccountingPaymentMF.Activate();
                CheckWindowsStatus(Forms.AccountingPaymentMF);
            }
            else
            {
                SubFrom.AccountingPaymentMF AccountingPayment = new SubFrom.AccountingPaymentMF();

                ShowMDIChild(AccountingPayment);
            }

            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text =" | "+ ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        }
        #endregion

        #region 應請款項清單表
        /// <summary>
        /// 應請款項清單表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_AccountingFee_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.AccountingFeeList != null)
            {
                Forms.AccountingFeeList.Activate();
                CheckWindowsStatus(Forms.AccountingFeeList);
            }
            else
            {
                SubFrom.AccountingFeeList AccountingFee = new SubFrom.AccountingFeeList();

                ShowMDIChild(AccountingFee);
            }

            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text =" | "+ ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        }
        #endregion

        #region 寄件者設定
        /// <summary>
        /// 寄件者設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_SenderSet_Click(object sender, EventArgs e)
        {
            US.EmailSet mail = new LawtechPTSystem.US.EmailSet();
            mail.ShowDialog();
        }
        #endregion

        #region 修改個人密碼
        /// <summary>
        /// 修改個人密碼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_ChangePassword_Click(object sender, EventArgs e)
        {
            US.EmployeeChangePassword password = new LawtechPTSystem.US.EmployeeChangePassword();
            password.ShowDialog();
        }
        #endregion 

        #region 修改個人資料
        private void 修改個人資料ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditForm.EditWorker worker = new LawtechPTSystem.EditForm.EditWorker();
            worker.Text += " ("+Properties.Settings.Default.WorkerName+")";
            worker.ShowDialog();
        }
        #endregion
       
        #region 所內單位財產清單
        /// <summary>
        /// 所內單位財產清單
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_OfficeProperty_Click(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.OfficePropertyMF != null)
            {
                Forms.OfficePropertyMF.Activate();
                CheckWindowsStatus(Forms.OfficePropertyMF);
            }
            else
            {
                SubFrom.OfficePropertyMF OfficeProperty = new SubFrom.OfficePropertyMF();

                ShowMDIChild(OfficeProperty);
            }
        }
        #endregion 

        #region 客戶查詢
        /// <summary>
        /// 客戶查詢
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();
            if (Forms.ApplicantMF != null)
            {
                Forms.ApplicantMF.Activate();
                CheckWindowsStatus(Forms.ApplicantMF);
            }
            else
            {
                SubFrom.ApplicantMF AppMF = new SubFrom.ApplicantMF();
                ShowMDIChild(AppMF);
            }
            
            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text =" | "+ ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        }
        #endregion

        #region 代理人查詢
        /// <summary>
        /// 代理人查詢
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttorneyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();
            if (Forms.AttorneySearchMF != null)
            {
                Forms.AttorneySearchMF.Activate();
                CheckWindowsStatus(Forms.AttorneySearchMF);
            }
            else
            {
                SubFrom.AttorneySearchMF Attorney = new SubFrom.AttorneySearchMF();
                ShowMDIChild(Attorney);
            }

            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text =" | "+ ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        }
        #endregion

        #region 專利請款查詢
        /// <summary>
        /// 專利請款查詢
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_FeePatent_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.PatentFeeSearch != null)
            {
                Forms.PatentFeeSearch.Activate();
                CheckWindowsStatus(Forms.PatentFeeSearch);
            }
            else
            {
                SubFrom.PatentFeeSearch FeeSearch = new SubFrom.PatentFeeSearch();

                ShowMDIChild(FeeSearch);
            }

            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text =" | "+ ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        }
        #endregion

        #region 專利付款查詢
        private void ToolStripMenuItem_PaymentSearch_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.PatentPaymentSearch != null)
            {
                Forms.PatentPaymentSearch.Activate();
                CheckWindowsStatus(Forms.PatentPaymentSearch);
            }
            else
            {
                SubFrom.PatentPaymentSearch PaymentSearch = new SubFrom.PatentPaymentSearch();

                ShowMDIChild(PaymentSearch);
            }

            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text =" | "+ ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        }
        #endregion

        #region  客戶查詢表單 ApplicantSearchMF
        private void CustomersSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();
            if (Forms.ApplicantSearchMF != null)
            {
               // Forms.ApplicantSearchMF.Activate();
                Forms.ApplicantSearchMF.Activate();
                CheckWindowsStatus(Forms.ApplicantSearchMF);
            }
            else
            {
                //SubFrom.ApplicantSearchMF main = new SubFrom.ApplicantSearchMF();
                SubFrom.ApplicantSearchMF main = new SubFrom.ApplicantSearchMF();
                ShowMDIChild(main);
            }

            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text =" | "+ ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        }
        #endregion

        #region 法務--案件階段設定
        /// <summary>
        /// 法務--案件階段設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_LegalStatusSet_Click(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            if (Forms.LegalStatusSet != null)
            {
                Forms.LegalStatusSet.Activate();
            }
            else
            {
                SubFrom.LegalStatusSet LegalStatus = new SubFrom.LegalStatusSet();
                ShowMDIChild(LegalStatus);
            }
        }
        #endregion

        #region 法務--案件類別設定
        /// <summary>
        /// 法務--案件類別設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_LegalTypeSet_Click(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            if (Forms.LegalTypeSet != null)
            {
                Forms.LegalTypeSet.Activate();
            }
            else
            {
                SubFrom.LegalTypeSet LegalStatus = new SubFrom.LegalTypeSet();
                ShowMDIChild(LegalStatus);
            }
        }
        #endregion

        #region 法務--費用種類設定
        /// <summary>
        /// 法務--費用種類設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            if (Forms.LegalFeePhase != null)
            {
                Forms.LegalFeePhase.Activate();
            }
            else
            {
                SubFrom.LegalFeePhase LegalFee = new SubFrom.LegalFeePhase();
                ShowMDIChild(LegalFee);
            }
        }
        #endregion

        #region 應收應付總表
        /// <summary>
        /// 應收應付總表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_Combin_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();
            
            if (Forms.AccountingCombinList != null)
            {
                Forms.AccountingCombinList.Activate();
                CheckWindowsStatus(Forms.AccountingCombinList);
            }
            else
            {
                SubFrom.AccountingCombinList ACCombin = new SubFrom.AccountingCombinList();
                ShowMDIChild(ACCombin);
            }

            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text =" | "+ ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        }
        #endregion      

        #region 常用網站連結
        private void ToolStripMenuItem_Links_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();
            if (Forms.LinksMF != null)
            {
                Forms.LinksMF.Activate();
                CheckWindowsStatus(Forms.LinksMF);
            }
            else
            {
                SubFrom.LinksMF links = new SubFrom.LinksMF();
                ShowMDIChild(links);
            }
            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text =" | "+ ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        }
        #endregion

        #region 刪除記錄檔
        private void toolStripMenuItem_DelLog_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();
            if (Forms.DelDataLogMF != null)
            {
                Forms.DelDataLogMF.Activate();
                CheckWindowsStatus(Forms.DelDataLogMF);
            }
            else
            {
                SubFrom.DelDataLogMF delLog = new SubFrom.DelDataLogMF();
                ShowMDIChild(delLog);
            }
            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text =" | "+ ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        }
        #endregion

        #region Email 記錄檔
        private void toolStripMenuItem_EmailLog_Click(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            if (Forms.EmailLogMF != null)
            {
                Forms.EmailLogMF.Activate();
                CheckWindowsStatus(Forms.EmailLogMF);
            }
            else
            {
                SubFrom.EmailLogMF mailLog = new SubFrom.EmailLogMF();
                ShowMDIChild(mailLog);
            }
        }
        #endregion

        #region 商標請款查詢
        /// <summary>
        /// 商標請款查詢
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_TrademarkFeeSearch_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();
            if (Forms.TrademarkFeeSearchList != null)
            {
                Forms.TrademarkFeeSearchList.Activate();
                CheckWindowsStatus(Forms.TrademarkFeeSearchList);
            }
            else
            {
                SubFrom.TrademarkFeeSearchList FeeSearch = new SubFrom.TrademarkFeeSearchList();
                ShowMDIChild(FeeSearch);
            }

            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text =" | "+ ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        }
        #endregion

        #region 商標付款查詢
        /// <summary>
        /// 商標付款查詢
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_TrademarkPaymentSearch_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();
            if (Forms.TrademarkPaymentSearchList != null)
            {
                Forms.TrademarkPaymentSearchList.Activate();
                CheckWindowsStatus(Forms.TrademarkPaymentSearchList);
            }
            else
            {
                SubFrom.TrademarkPaymentSearchList FeeSearch = new SubFrom.TrademarkPaymentSearchList();
                ShowMDIChild(FeeSearch);
            }
            
            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text =" | "+ ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        
        }
        #endregion

        #region 客戶管理
        private void toolStripMenuItem_Customer_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();
            if (Forms.ApplicantList != null)
            {
                // Forms.ApplicantSearchMF.Activate();
                Forms.ApplicantList.Activate();
                CheckWindowsStatus(Forms.ApplicantList);
            }
            else
            {
                //SubFrom.ApplicantSearchMF main = new SubFrom.ApplicantSearchMF();
                SubFrom.ApplicantList main = new SubFrom.ApplicantList();
                ShowMDIChild(main);
            }

            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text =" | "+ ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        }
        #endregion

        #region 事務所管理
        private void toolStripMenuItem_FrimMgr_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.AttorneyMF != null)
            {
                Forms.AttorneyMF.Activate();
                CheckWindowsStatus(Forms.AttorneyMF);
            }
            else
            {
                SubFrom.AttorneyMF AttMF = new SubFrom.AttorneyMF();
                ShowMDIChild(AttMF);
            }

            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text =" | "+ ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        }
        #endregion

        #region 專利--申請案事件查詢統計 nternal void ToolStripMenuItem_PatentEventList_Click(object sender, EventArgs e)
        /// <summary>
        /// 專利--申請案事件查詢統計
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void ToolStripMenuItem_PatentEventList_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.PatentEventList != null)
            {
                Forms.PatentEventList.Activate();
                CheckWindowsStatus(Forms.PatentEventList);
            }
            else
            {
                SubFrom.PatentEventList PatEvent = new SubFrom.PatentEventList();
                ShowMDIChild(PatEvent);
            }

            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text =" | "+ ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        }
        #endregion

        #region 登入頁
        /// <summary>
        /// 登入頁
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loginLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.LoginLog != null)
            {
                Forms.LoginLog.Activate();
            }
            else
            {
                SubFrom.LoginLog LoginLogMF = new SubFrom.LoginLog();
                ShowMDIChild(LoginLogMF);
            }
        } 
        #endregion

        #region 專利-事件管制表 internal void ToolStripMenuItem_PatEventList_Click(object sender, EventArgs e)
        /// <summary>
        /// 專利-事件管制表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void ToolStripMenuItem_PatEventList_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.PATControlEventList != null)
            {
                Forms.PATControlEventList.Activate();
                CheckWindowsStatus(Forms.PATControlEventList);
            }
            else
            {
                SubFrom.PATControlEventList eventList = new SubFrom.PATControlEventList();
                ShowMDIChild(eventList);
            }

            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text =" | "+ ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        } 
        #endregion

        #region 登出按鈕 private void ToolStripMenuItem_Logout_Click(object sender, EventArgs e)
        /// <summary>
        /// 登出按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Logout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Dear " + Properties.Settings.Default.WorkerName + " ： \r\n  是否確定登出??", "提示訊息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Public.LoginForm loginMF = new Public.LoginForm();
                if (loginMF.Login != null)
                {
                    loginMF.Login.Activate();
                    loginMF.Login.Visible = true;
                }
                else
                {
                    Application.Exit();
                    Application.ExitThread();
                }

                this.Close();
            }
        } 
        #endregion

        #region 專利-年費管制表 private void ToolStripMenuItem_PatYearFee_Click(object sender, EventArgs e)
        /// <summary>
        /// 專利年費管制表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_PatYearFee_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.PATControlYearFeeList != null)
            {
                Forms.PATControlYearFeeList.Activate();
                CheckWindowsStatus(Forms.PATControlYearFeeList);
            }
            else
            {
                SubFrom.PATControlYearFeeList eventList = new SubFrom.PATControlYearFeeList();
                ShowMDIChild(eventList);
            }

            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text =" | "+ ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        } 
        #endregion

        #region 專利-付款記錄管制表 private void ToolStripMenuItem_PATControlPayment_Click(object sender, EventArgs e)
        /// <summary>
        /// 專利-付款記錄管制表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_PATControlPayment_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.PATControlPayment != null)
            {
                Forms.PATControlPayment.Activate();
                CheckWindowsStatus(Forms.PATControlPayment);
            }
            else
            {
                SubFrom.PATControlPayment eventList = new SubFrom.PATControlPayment();
                ShowMDIChild(eventList);
            }

            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text =" | "+ ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        } 
        #endregion

        #region 專利-請款管制表  private void ToolStripMenuItem_PATControlFeeList_Click(object sender, EventArgs e)
        /// <summary>
        /// 專利-請款管制表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_PATControlFeeList_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.PATControlFeeList != null)
            {
                Forms.PATControlFeeList.Activate();
                CheckWindowsStatus(Forms.PATControlFeeList);
            }
            else
            {
                SubFrom.PATControlFeeList eventList = new SubFrom.PATControlFeeList();
                ShowMDIChild(eventList);
            }

            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text =" | "+ ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        } 
        #endregion

        #region 專利-案件績效表 private void ToolStripMenuItem_PatentPerformanceList_Click(object sender, EventArgs e)
        /// <summary>
        /// 專利案件績效表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_PatentPerformanceList_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.PatentPerformanceList != null)
            {
                Forms.PatentPerformanceList.Activate();
                CheckWindowsStatus(Forms.PatentPerformanceList);
            }
            else
            {
                SubFrom.PatentPerformanceList Performance = new SubFrom.PatentPerformanceList();
                ShowMDIChild(Performance);
            }

            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text =" | "+ ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        }
        #endregion

        #region 商標-事件管制表 private void ToolStripMenuItem_TmEventList_Click(object sender, EventArgs e)
        /// <summary>
        ///  商標-事件管制表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void ToolStripMenuItem_TmEventList_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.TrademarkControlEventList != null)
            {
                Forms.TrademarkControlEventList.Activate();
                CheckWindowsStatus(Forms.TrademarkControlEventList);
            }
            else
            {
                SubFrom.TrademarkControlEventList eventList = new SubFrom.TrademarkControlEventList();
                ShowMDIChild(eventList);
            }

            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text =" | "+ ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        } 
        #endregion

        #region 商標-付款管制表 private void ToolStripMenuItem_TmPaymentList_Click(object sender, EventArgs e)
        /// <summary>
        /// 商標-付款管制表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_TmPaymentList_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.TrademarkControlPaymentList != null)
            {
                Forms.TrademarkControlPaymentList.Activate();
                CheckWindowsStatus(Forms.TrademarkControlPaymentList);
            }
            else
            {
                SubFrom.TrademarkControlPaymentList eventList = new SubFrom.TrademarkControlPaymentList();
                ShowMDIChild(eventList);
            }

            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text =" | "+ ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        } 
        #endregion

        #region 商標-請款管制表  private void ToolStripMenuItem_TmFeeList_Click(object sender, EventArgs e)
        /// <summary>
        /// 商標-請款管制表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_TmFeeList_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.TrademarkControlFeeList != null)
            {
                Forms.TrademarkControlFeeList.Activate();
                CheckWindowsStatus(Forms.TrademarkControlFeeList);
            }
            else
            {
                SubFrom.TrademarkControlFeeList eventList = new SubFrom.TrademarkControlFeeList();
                ShowMDIChild(eventList);
            }

            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text =" | "+ ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        } 
        #endregion

        #region 商標-延展管制表  private void ToolStripMenuItem_TrademarkControlExtendedFeeList_Click(object sender, EventArgs e)
        /// <summary>
        /// 商標-延展管制表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_TrademarkControlExtendedFeeList_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.TrademarkControlExtendedFeeList != null)
            {
                Forms.TrademarkControlExtendedFeeList.Activate();
                CheckWindowsStatus(Forms.TrademarkControlExtendedFeeList);
            }
            else
            {
                SubFrom.TrademarkControlExtendedFeeList eventList = new SubFrom.TrademarkControlExtendedFeeList();
                ShowMDIChild(eventList);
            }

            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text =" | "+ ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        } 
        #endregion

        #region 國別設定 private void ToolStripMenuItem_Conutry_Click(object sender, EventArgs e)
        /// <summary>
        /// 國別設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Conutry_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.CountrySetting != null)
            {
                Forms.CountrySetting.Activate();
                CheckWindowsStatus(Forms.CountrySetting);
            }
            else
            {
                SubFrom.CountrySetting Country = new SubFrom.CountrySetting();
                ShowMDIChild(Country);
            }

            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text =" | "+ ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        } 
        #endregion

        #region 商標事件績效表 private void ToolStripMenuItem_TrademarkEventList_Click(object sender, EventArgs e)
        /// <summary>
        /// 商標事件績效表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void ToolStripMenuItem_TrademarkEventList_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

              Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.TrademarkEventList != null)
            {
                Forms.TrademarkEventList.Activate();
                CheckWindowsStatus(Forms.TrademarkEventList);
            }
            else
            {
                SubFrom.TrademarkEventList Country = new SubFrom.TrademarkEventList();
                ShowMDIChild(Country);
            }

            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text =" | "+ ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        } 
        #endregion

        #region 商標申請案績效表 private void ToolStripMenuItem_TrademarkPerformanceList_Click(object sender, EventArgs e)
        /// <summary>
        /// 商標申請案績效表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_TrademarkPerformanceList_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.TrademarkPerformanceList != null)
            {
                Forms.TrademarkPerformanceList.Activate();
                CheckWindowsStatus(Forms.TrademarkPerformanceList);
            }
            else
            {
                SubFrom.TrademarkPerformanceList PerformanceList = new SubFrom.TrademarkPerformanceList();
                ShowMDIChild(PerformanceList);
            }

            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text =" | "+ ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        } 
        #endregion

        #region 系統通用設定 private void ToolStripMenuItem_SystemCommonSetting_Click(object sender, EventArgs e)
        /// <summary>
        /// 系統通用設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_SystemCommonSetting_Click(object sender, EventArgs e)
        {
            SubFrom.SystemCommonSetting Setting = new SubFrom.SystemCommonSetting();
            Setting.ShowDialog();
        }
        #endregion

        #region 公怖欄 private void ToolStripMenuItem_News_Click(object sender, EventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_News_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();
            if (Forms.News != null)
            {
                Forms.News.Activate();
                CheckWindowsStatus(Forms.News);
            }
            else
            {
                SubFrom.NewsList news = new SubFrom.NewsList();
                ShowMDIChild(news);
            }
            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text = " | " + ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        }

        #endregion

        #region 知識管理 private void ToolStripMenuItem_Knowladge_Click(object sender, EventArgs e)
        /// <summary>
        /// 知識管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Knowladge_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時
            Public.PublicForm Forms = new Public.PublicForm();

            if (Forms.UploadFile != null)
            {
                Forms.UploadFile.Activate();
                CheckWindowsStatus(Forms.UploadFile);
            }
            else
            {
                SubFrom.UploadFile uf = new SubFrom.UploadFile();
                ShowMDIChild(uf);
            }
            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text = " | " + ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        }

        #endregion

        #region 更新專利個人待辦事件 private void toolStripButton_PatentRefresh_Click(object sender, EventArgs e)
        /// <summary>
        /// 更新專利個人待辦事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_PatentRefresh_Click(object sender, EventArgs e)
        {
            GetPatentComitEventForWorker();
        } 
        #endregion

        private void toolStripButton_TrademarkRefresh_Click(object sender, EventArgs e)
        {
            GetTrademarkComitEventForWorker();
        }

        private void toolStripButton_NewsRefresh_Click(object sender, EventArgs e)
        {
            GetNewsWorker();
        }

        #region  contextMenuMainPatent 快顯選單、相關事件
        private void contextMenuMainPatent_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuMainPatent.Visible = false;

            switch (e.ClickedItem.Name)
            {
                
                case "EdittoolStripMenuItem":
                case "toolStripButtonEditItem":
                    if (dataGridView_Patent.CurrentRow != null)
                    {
                        //判斷是否有人使用中
                        int iLocker = Public.Utility.GetRecordAuth("PatComitEventT", "PatComitEventID=" + dataGridView_Patent.CurrentRow.Cells["PatComitEventID"].Value.ToString());
                        if (iLocker == -1 || iLocker == iWorkerID)
                        {
                            if (iLocker != iWorkerID)
                            {
                                Public.Utility.LockRecordAuth("PatComitEventT", iWorkerID, "PatComitEventID=" + dataGridView_Patent.CurrentRow.Cells["PatComitEventID"].Value.ToString());
                            }
                            EditForm.EditComitEvent comit_Edit = new EditForm.EditComitEvent();
                            comit_Edit.PatComitEventID = (int)dataGridView_Patent.CurrentRow.Cells["PatComitEventID"].Value;
                            comit_Edit.PatentID = (int)dataGridView_Patent.CurrentRow.Cells["PatentID"].Value;
                            comit_Edit.Text += "(" + dataGridView_Patent.CurrentRow.Cells["PatentNo"].Value.ToString() + "  " + dataGridView_Patent.CurrentRow.Cells["Country"].Value.ToString() + ")";
                            comit_Edit.CountrySymbol = dataGridView_Patent.CurrentRow.Cells["CountrySymbol"].Value.ToString();
                            if (OfficeRole == 1)
                            {
                                comit_Edit.HomePageEvent = Properties.Settings.Default.HomePageEvent;
                            }
                                comit_Edit.ShowDialog();
                        }
                        else
                        {
                            if (iLocker != -1)//無人使用中
                            {
                                Worker_Model worker = new Worker_Model();
                                Worker_Model.ReadOne(iLocker, ref worker);
                                MessageBox.Show("很抱歉~~   目前該筆資料正被【" + worker.EmployeeName + "】使用中，請等候!!\r\n 謝謝", "提示訊息");
                            }
                        }
                    }
                    break;
                case "ToolStripMenuItemPatentQuit":  //放棄
                    US.AbortControl AbortMF = new US.AbortControl();
                    AbortMF.PatentID = (int)dataGridView_Patent.CurrentRow.Cells["PatentID"].Value;
                    AbortMF.EventType = 1;
                    AbortMF.EventID = (int)dataGridView_Patent.CurrentRow.Cells["EventID"].Value;
                    AbortMF.ShowDialog();
                    break;             

                case "ToolStripMenuItem_EventFinish":  //事件處理完成

                    US.PatentComitEventFinish Comitfinish = new US.PatentComitEventFinish();
                    Comitfinish.Text += "--" + dataGridView_Patent.CurrentRow.Cells["PatentNo"].Value.ToString();
                    Comitfinish.EventType = 1;
                    Comitfinish.EventID = (int)dataGridView_Patent.CurrentRow.Cells["EventID"].Value;
                    if (Comitfinish.ShowDialog() == DialogResult.OK)
                    {
                        dataGridView_Patent.CurrentRow.Cells["FinishDate"].Value = Comitfinish.FinishDate;
                        dataGridView_Patent.CurrentRow.Cells["Result"].Value = Comitfinish.Result;
                        dataGridView_Patent.CurrentRow.Cells["DiffDueDate"].Value = 0;
                        dt_PatentComitEvent.AcceptChanges();
                    }

                    break;

                case "toolStripMenuItem_NotFinish":
                    if (MessageBox.Show("是否確定變更為【未完成處理的事件】?", "提示訊息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        int iComitEventID = (int)dataGridView_Patent.CurrentRow.Cells["EventID"].Value;
                        Public.CPatComitEvent Comit = new Public.CPatComitEvent();
                        Public.CPatComitEvent.ReadOne(iComitEventID, ref Comit);

                        Comit.FinishDate = null;
                        Comit.LastModifyWorker = Properties.Settings.Default.WorkerName;
                        Comit.Result = Comit.LastModifyWorker + " " + DateTime.Now.ToString("yyyy-MM-dd") + " 變更為未完成事件";
                        Comit.Update();
                        dataGridView_Patent.CurrentRow.Cells["FinishDate"].Value = System.DBNull.Value;
                        dt_PatentComitEvent.AcceptChanges();
                    }
                    break;

                case "ToolStripMenuItem_SendMail":
                    if (dataGridView_Patent.CurrentRow != null)
                    {
                        US.NotificationLetter letter = new LawtechPTSystem.US.NotificationLetter();
                        letter.ApplicantKeys = dataGridView_Patent.CurrentRow.Cells["ApplicantKeys"].Value.ToString();
                        letter.CaseKey = dataGridView_Patent.CurrentRow.Cells["EventID"].Value != null ? (int)dataGridView_Patent.CurrentRow.Cells["EventID"].Value : -1;

                        letter.EmailSampleType = "PatentEvent";
                        letter.DelegateType = dataGridView_Patent.CurrentRow.Cells["DelegateType"].Value != null ? (int)dataGridView_Patent.CurrentRow.Cells["DelegateType"].Value : -1;
                        letter.Attorney = dataGridView_Patent.CurrentRow.Cells["AttorneyKey"].Value != DBNull.Value ? (int)dataGridView_Patent.CurrentRow.Cells["AttorneyKey"].Value : -1;
                        letter.CaseNo = dataGridView_Patent.CurrentRow.Cells["PatentNo"].Value.ToString();
                        letter.Show();
                    }
                    break;
              
                case "toolStripMenuItem_SetGridColumn":
                    SetGridColumnT gc = new SetGridColumnT();
                    gc.CurrentGridSymboID = dataGridView_Patent.Tag.ToString();
                    gc.TitleName = "專利 個人待辦事件列表";
                    gc.Show();
                    break;

                case "toolStripMenuItem_WorkList":
                    if (dataGridView_Patent.CurrentRow != null)
                    {
                        PATControlEventWorkList worklist = new PATControlEventWorkList();
                        worklist.TypeMode = 1;
                        worklist.EventID = (int)dataGridView_Patent.CurrentRow.Cells["PatComitEventID"].Value;
                        worklist.EventType = 1;
                        worklist.EventContent = dataGridView_Patent.CurrentRow.Cells["EventContent"].Value.ToString();
                        worklist.Show();
                    }
                    break;
                case "toolStripMenuItem_PatentRefresh": //刷新
                    toolStripButton_PatentRefresh_Click(null, null);
                    break;
                case "toolStripMenuItem_PatentView"://申請案詳細資料                  
                    if ( dataGridView_Patent.CurrentRow != null)
                    {
                        if (OfficeRole != 1)//最高權限、主管權限
                        {
                            PatentHistoryRecord1 patent = new PatentHistoryRecord1();
                            patent.property_PatentID = (int)dataGridView_Patent.CurrentRow.Cells["PatentID"].Value;

                            patent.TabSelectedIndex = 1;
                            patent.Show();
                        }
                        else
                        {

                            //一般權限 , 判斷HistoryRecordMode=10 
                            if (Properties.Settings.Default.HistoryRecordMode == "10")
                            {
                                PatentHistoryRecord_Event patent = new PatentHistoryRecord_Event();
                                patent.property_PatentID = (int)dataGridView_Patent.CurrentRow.Cells["PatentID"].Value;
                                patent.TabSelectedIndex = 1;
                                patent.Show();
                            }
                            else {
                                PatentHistoryRecord1 patent = new PatentHistoryRecord1();
                                patent.property_PatentID = (int)dataGridView_Patent.CurrentRow.Cells["PatentID"].Value;
                                patent.TabSelectedIndex = 1;
                                patent.Show();
                            }
                          

                        }
                    }
                
                    break;
            }
        }

        #endregion

        #region  contextMenuMainTrademark 快顯選單、相關事件
        private void contextMenuMainTrademark_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuMainTrademark.Visible = false;

            switch (e.ClickedItem.Name)
            {
                case "EditNotifytoolStripMenuItem":
                case "toolStripButtonEidtItem_Notify":
                    if (dataGridView_Trademark.CurrentRow != null)
                    {
                        //鎖定資料
                        int iLocker = Public.Utility.GetRecordAuth("TrademarkNotifyEventT", "TMNotifyEventID=" + dataGridView_Trademark.CurrentRow.Cells["TMNotifyEventID"].Value.ToString());
                        if (iLocker == -1 || iLocker == iWorkerID)
                        {
                            if (iLocker != iWorkerID)
                            {
                                Public.Utility.LockRecordAuth("TrademarkNotifyEventT", iWorkerID, "TMNotifyEventID=" + dataGridView_Trademark.CurrentRow.Cells["TMNotifyEventID"].Value.ToString());
                            }
                            EditForm.EditTrademarkNotifyEvent Edit = new EditForm.EditTrademarkNotifyEvent();
                            Edit.property_TMNotifyEventID = (int)dataGridView_Trademark.CurrentRow.Cells["TMNotifyEventID"].Value;
                            Edit.CountrySymbol = dataGridView_Trademark.CurrentRow.Cells["CountrySymbol"].Value.ToString();
                            if (OfficeRole == 1)
                            {
                                Edit.HomePageEvent = Properties.Settings.Default.HomePageEvent;
                            }
                                Edit.ShowDialog();

                            //Public.Utility.NuLockRecordAuth("TrademarkNotifyEventT", "TMNotifyEventID=" + TMNotifyEventTDataGridView.CurrentRow.Cells["TMNotifyEventID"].Value.ToString());
                        }
                        else
                        {
                            if (iLocker != -1)//無人使用中
                            {
                                Worker_Model worker = new Worker_Model();
                                Worker_Model.ReadOne(iLocker, ref worker);
                                MessageBox.Show("很抱歉~~   目前該筆資料正被【" + worker.EmployeeName + "】使用中，請等候!!\r\n 謝謝", "提示訊息");
                            }
                        }
                    }

                    break;
             
                case "ToolStripMenuItemTmQuit":  //放棄
                    US.AbortControlTrademark AbortMF = new US.AbortControlTrademark();
                    AbortMF.TrademarkID = (int)dataGridView_Trademark.CurrentRow.Cells["TrademarkID"].Value;
                    AbortMF.EventType = 1;
                    AbortMF.EventID = (int)dataGridView_Trademark.CurrentRow.Cells["TMNotifyEventID"].Value;
                    AbortMF.ShowDialog();
                    break;


                case "ToolStripMenuItem_TmEventFinish":  //委辦送件完成

                    US.TrademarkNotifyFinish NotifyFinish = new LawtechPTSystem.US.TrademarkNotifyFinish();
                    NotifyFinish.TmNotifyEventID = (int)dataGridView_Trademark.CurrentRow.Cells["TMNotifyEventID"].Value;
                    NotifyFinish.DGvr = dataGridView_Trademark.CurrentRow;
                    NotifyFinish.TableTypeName = "TM";
                    NotifyFinish.ShowDialog();

                    break;

                case "toolStripMenuItem_TmNotFinish":
                    if (MessageBox.Show("是否確定變更為【未完成處理的事件】?", "提示訊息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        int iComitEventID = (int)dataGridView_Trademark.CurrentRow.Cells["TMNotifyEventID"].Value;
                        Public.CTrademarkNotifyEvent Comit = new Public.CTrademarkNotifyEvent();
                        Public.CTrademarkNotifyEvent.ReadOne(iComitEventID, ref Comit);

                        Comit.FinishDate = null;
                        Comit.LastModifyWorker = Properties.Settings.Default.WorkerName;
                        Comit.Result = Comit.LastModifyWorker + " " + DateTime.Now.ToString("yyyy-MM-dd") + " 變更為未完成事件";
                        Comit.Update();
                        dataGridView_Trademark.CurrentRow.Cells["FinishDate"].Value = System.DBNull.Value;
                        dt_TrademarkControlEvent.AcceptChanges();
                    }
                    break;

                case "ToolStripMenuItem_TmSendMail":
                    if (dataGridView_Trademark.CurrentRow != null)
                    {
                        US.NotificationLetter letter = new LawtechPTSystem.US.NotificationLetter();
                        letter.ApplicantKeys = dataGridView_Trademark.CurrentRow.Cells["MainTmApplicantKeys"].Value.ToString();
                        letter.CaseKey = dataGridView_Trademark.CurrentRow.Cells["TMNotifyEventID"].Value != null ? (int)dataGridView_Trademark.CurrentRow.Cells["TMNotifyEventID"].Value : -1;

                        letter.EmailSampleType = "TrademarkEvent";
                        letter.DelegateType = dataGridView_Trademark.CurrentRow.Cells["MainTmDelegateType"].Value != null ? (int)dataGridView_Trademark.CurrentRow.Cells["MainTmDelegateType"].Value : -1;
                        letter.Attorney = dataGridView_Trademark.CurrentRow.Cells["MainTmAttorneyKey"].Value != DBNull.Value ? (int)dataGridView_Trademark.CurrentRow.Cells["MainTmAttorneyKey"].Value : -1;
                        letter.CaseNo = dataGridView_Trademark.CurrentRow.Cells["TrademarkID"].Value.ToString();
                        letter.Show();
                    }
                    break;
             
                case "toolStripMenuItem_TmSetGridColumn":
                    SetGridColumnT gc = new SetGridColumnT();
                    gc.CurrentGridSymboID = dataGridView_Trademark.Tag.ToString();
                    gc.TitleName = "商標 個人待辦事件列表";
                    gc.Show();
                    break;
                case "toolStripMenuItem_TmWorkList":
                    if (dataGridView_Trademark.CurrentRow != null)
                    {
                        PATControlEventWorkList worklist = new PATControlEventWorkList();
                        worklist.TypeMode = 2;
                        worklist.EventID = (int)dataGridView_Trademark.CurrentRow.Cells["TMNotifyEventID"].Value;
                        worklist.EventType = 1;
                        worklist.EventContent = dataGridView_Trademark.CurrentRow.Cells["NotifyEventContent"].Value.ToString();
                        worklist.Show();
                    }
                    break;

                case "toolStripMenuItem_TmRefresh":
                    toolStripButton_TrademarkRefresh_Click(null,null);
                    break;
                case "toolStripMenuItem_TmView":
                   
                    if (dataGridView_Trademark.CurrentRow != null)
                    {
                        if (OfficeRole != 1)//最高權限、主管權限
                        {

                            TrademarkHistoryRecord HistoryRecord = new TrademarkHistoryRecord();
                            HistoryRecord.TrademarkID = (int)dataGridView_Trademark.CurrentRow.Cells["TrademarkID"].Value;
                            HistoryRecord.TabSelectedIndex = 1;
                            HistoryRecord.Show();
                        }
                        else
                        {
                            //一般權限
                            if (Properties.Settings.Default.HistoryRecordMode == "10")
                            {
                                TrademarkHistoryRecord_Event HistoryRecord = new TrademarkHistoryRecord_Event();
                                HistoryRecord.TrademarkID = (int)dataGridView_Trademark.CurrentRow.Cells["TrademarkID"].Value;
                                HistoryRecord.TabSelectedIndex = 1;
                                HistoryRecord.Show();
                            }
                            else {
                                TrademarkHistoryRecord HistoryRecord = new TrademarkHistoryRecord();
                                HistoryRecord.TrademarkID = (int)dataGridView_Trademark.CurrentRow.Cells["TrademarkID"].Value;
                                HistoryRecord.TabSelectedIndex = 1;
                                HistoryRecord.Show();
                            }
                         
                        }
                    }
                    
                    break;
            }
        }


        #endregion

        #region 官方公文管理 private void toolStripMenuItem_OfficialDocument_Click(object sender, EventArgs e)
        /// <summary>
        /// 官方公文管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_OfficialDocument_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();
            if (Forms.OfficialDocument != null)
            {
                Forms.OfficialDocument.Activate();
            }
            else
            {
                SubFrom.OfficialDocument od = new SubFrom.OfficialDocument();
                ShowMDIChild(od);
            }
            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text = " | " + ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        }

        #endregion

        #region 個人公怖欄
        /// <summary>
        ///  個人公怖欄
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel_News_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ToolStripMenuItem_News_Click(ToolStripMenuItem_News, null);
        }
        #endregion

        #region  private void dataGridView_Patent_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_Patent_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                if (dataGridView_Patent.CurrentRow != null)
                {                
                        contextMenuMainPatent_ItemClicked(contextMenuMainPatent, new ToolStripItemClickedEventArgs(EdittoolStripMenuItem));              
                }
            }
           
        }

        #endregion

        #region private void dataGridView_Trademark_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_Trademark_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                if (dataGridView_Trademark.CurrentRow != null)
                {
                    contextMenuMainTrademark_ItemClicked(dataGridView_Trademark, new ToolStripItemClickedEventArgs(EditNotifytoolStripMenuItem));
                }
            }
          
        }


        #endregion

        #region 匯入系統資料 private void toolStripMenuItem_Import_Click(object sender, EventArgs e)
        /// <summary>
        /// 匯入系統資料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_Import_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();
            if (Forms.ImportSystemData != null)
            {
                Forms.ImportSystemData.Activate();
                CheckWindowsStatus(Forms.ImportSystemData);
            }
            else
            {
                SubFrom.ImportSystemData od = new SubFrom.ImportSystemData();
                ShowMDIChild(od);
            }
            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text = " | " + ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        }

        #endregion

        #region MAC位址綁定 private void ToolStripMenuItem_MACsetting_Click(object sender, EventArgs e)
        /// <summary>
        /// MAC位址綁定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_MACsetting_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();
            if (Forms.MACsetting != null)
            {
                Forms.MACsetting.Activate();
                CheckWindowsStatus(Forms.MACsetting);
            }
            else
            {
                SubFrom.MACsetting od = new SubFrom.MACsetting();
                ShowMDIChild(od);
            }
            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text = " | " + ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        }

        #endregion

        #region 查看個人專利完成事件
        /// <summary>
        /// 查看個人專利完成事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_PatFinishEvent_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();
            if (Forms.PatentWorkerEventFinish != null)
            {
                Forms.PatentWorkerEventFinish.Activate();
                CheckWindowsStatus(Forms.PatentWorkerEventFinish);
            }
            else
            {
                SubFrom.PatentWorkerEventFinish od = new SubFrom.PatentWorkerEventFinish();
                ShowMDIChild(od);
            }
            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text = " | " + ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        }
        #endregion

        #region 查看個人商標完成事件 private void toolStripMenuItem_TmFinishEvent_Click(object sender, EventArgs e)
        /// <summary>
        /// 查看個人商標完成事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_TmFinishEvent_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();
            if (Forms.TrademarkWorkerEventFinish != null)
            {
                Forms.TrademarkWorkerEventFinish.Activate();
                CheckWindowsStatus(Forms.TrademarkWorkerEventFinish);
            }
            else
            {
                SubFrom.TrademarkWorkerEventFinish od = new SubFrom.TrademarkWorkerEventFinish();
                ShowMDIChild(od);
            }
            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text = " | " + ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        } 
        #endregion

        #region PTS 更新檢查 private void ToolStripMenuItem_ptsupdate_Click(object sender, EventArgs e)
        /// <summary>
        /// PTS 更新檢查
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_ptsupdate_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();
            if (Forms.PTSUpdate != null)
            {
                Forms.PTSUpdate.Activate();
                CheckWindowsStatus(Forms.PTSUpdate);
            }
            else
            {
                SubFrom.PTSUpdate od = new SubFrom.PTSUpdate();
                ShowMDIChild(od);
            }
            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text = " | " + ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        }



        #endregion

        #region private void toolStripButton_goRight_Click(object sender, EventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_goRight_Click(object sender, EventArgs e)
        {
            if (!splitContainer_main.Panel1Collapsed)
            {
                splitContainer_main.Panel1Collapsed = true;
                this.toolStripButton_goRight.Image = global::LawtechPTSystem.Properties.Resources.go_right;
            }
            else
            {
                splitContainer_main.Panel1Collapsed = false;
                this.toolStripButton_goRight.Image = global::LawtechPTSystem.Properties.Resources.go_left;
            }
        }

        #endregion

        #region 公佈欄快點2下 private void dataGridView_News_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        /// <summary>
        /// 公佈欄快點2下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_News_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                if (dataGridView_News.CurrentRow != null)
                {
                    ViewFrom.ViewNews news = new ViewFrom.ViewNews();
                    news.iNewsKey = (int)dataGridView_News.CurrentRow.Cells["NewsKey"].Value;
                    news.ShowDialog();
                    GetNewsWorker();
                }
            }
        }
        #endregion

        #region 簡訊發送 private void ToolStripMenuItem_SMsend_Click(object sender, EventArgs e)
        /// <summary>
        /// 簡訊發送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_SMsend_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();
            if (Forms.SMSsend != null)
            {
                Forms.SMSsend.Activate();
                CheckWindowsStatus(Forms.SMSsend);
            }
            else
            {
                SubFrom.SMSsend od = new SubFrom.SMSsend();
                //ShowMDIChild(od);
                od.Show();
            }
            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text = " | " + ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        }
        #endregion

        #region 簡訊記錄檔 private void ToolStripMenuItem_smsLog_Click(object sender, EventArgs e)
        /// <summary>
        /// 簡訊記錄檔
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_smsLog_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();
            if (Forms.SMSLogsMF != null)
            {
                Forms.SMSLogsMF.Activate();
                CheckWindowsStatus(Forms.SMSLogsMF);
            }
            else
            {
                SubFrom.SMSLogsMF od = new SubFrom.SMSLogsMF();
                ShowMDIChild(od);
            }
            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text = " | " + ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        }
        #endregion

        #region 入帳公司 private void toolStripMenuItem_ACompany_Click(object sender, EventArgs e)
        /// <summary>
        ///  入帳公司
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem_ACompany_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();
            if (Forms.AccountingCompany != null)
            {
                Forms.AccountingCompany.Activate();
                CheckWindowsStatus(Forms.AccountingCompany);
            }
            else
            {
                SubFrom.AccountingCompany od = new SubFrom.AccountingCompany();
                ShowMDIChild(od);
            }
            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text = " | " + ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        }
        #endregion

        /// <summary>
        /// 行事曆
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Calendar_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new Public.PublicForm();
            if (Forms.CalendarForm != null)
            {
                Forms.CalendarForm.Activate();
                CheckWindowsStatus(Forms.CalendarForm);
            }
            else
            {
                SubFrom.CalendarForm od = new SubFrom.CalendarForm();
                ShowMDIChild(od);
            }
            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text = " | " + ((ToolStripMenuItem)sender).Text + " 啟動耗時:" + sw.Elapsed.TotalSeconds.ToString("#,##0.##") + " 秒";
        }


       
    }
}