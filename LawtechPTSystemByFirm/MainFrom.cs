using System;
using System.Collections.Generic;
using System.Windows.Forms;
using H3Operator.DBModels;
using System.Diagnostics;

namespace LawtechPTSystemByFirm
{
    public partial class MainFrom : Form
    {
        private int ProgressBarMaximum = 150;
       Stopwatch sw = new System.Diagnostics.Stopwatch();

        public MainFrom()
        {
            InitializeComponent();
        }

        BindingSource bSource_Program;
        BindingSource bSource_WorkerProgram;

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
        #endregion

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
                ChildForm.MdiParent = this;
                ChildForm.WindowState = FormWindowState.Maximized;
                ChildForm.Show();
            }
            catch (System.Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }
        #endregion


        private void ClickMenuItem(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            if (sender is ToolStripMenuItem)
            {
                ToolStripMenuItem menuitem = (ToolStripMenuItem)sender;
                bool hasForm = false;
                switch (menuitem.Name)
                {
                    case "QPToolStripMenuItem":

                        if (Forms.ClientFeeMF != null)
                        {
                            Forms.ClientFeeMF.Activate();
                        }
                        else
                        {
                            SubFrom.ClientFeeMF CliMF = new SubFrom.ClientFeeMF();
                            ShowMDIChild(CliMF);
                        }
                        break;

                    case "AttorneyToolStripMenuItem":

                        foreach (Form f in this.MdiChildren)
                        {
                            if (f.Name == "AttorneyMF")
                            {
                                hasForm = true;
                                f.BringToFront();
                                break;
                            }
                        }

                        if (!hasForm)
                        {
                            SubFrom.AttorneyMF AttMF = new SubFrom.AttorneyMF();
                            ShowMDIChild(AttMF);
                        }
                        break;

                    case "CustomersToolStripMenuItem":

                        if (Forms.ApplicantMF != null)
                        {
                            Forms.ApplicantMF.Activate();
                        }
                        else
                        {
                            SubFrom.ApplicantMF AppMF = new SubFrom.ApplicantMF();
                            ShowMDIChild(AppMF);
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
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
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
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            Forms.MainFrom = null;

            try
            {
                DB_Models.DB_WorkerLoginTModel login = new DB_Models.DB_WorkerLoginTModel();
                DB_Models.DB_WorkerLoginTModel.ReadOne(string.Format("WorkerKey={0} and  CONVERT(varchar(100), OnlineTime, 20) ='{1}'", Properties.Settings.Default.WorkerKEY.ToString(), Properties.Settings.Default.OnlineTime.ToString("yyyy-MM-dd HH:mm:ss")), ref login);
                if (login.WorkerLoginKey > 0)
                {
                    login.OutTime = DateTime.Now;
                    login.Online = false;
                    login.Update();
                }
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
           
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            Forms.MainFrom = this;

            ProWorkerID = Properties.Settings.Default.WorkerKEY;
            OfficeRole = Properties.Settings.Default.OfficeRole;
            this.Text = Properties.Settings.Default.SystemName;

            this.statusStrip1.Refresh();

            bSource_Program = new BindingSource();
            bSource_WorkerProgram = new BindingSource();
            
            List<ViewModel_WorkerProgram> programList = new List<ViewModel_WorkerProgram>();
            System.Data.SqlClient.SqlParameter[] ParaList ={
                                                         H3Operator.DBHelper.DBAccess.MakeInParam("WorkerKEY",SqlDataType.Int,ProWorkerID)                                                          
                                                          };

            object objResult = ViewModel_WorkerProgram.ReadViewTableList("WorkerProgramT.WorkerKEY=@WorkerKEY", ref programList, ParaList);

            bSource_WorkerProgram.DataSource = programList;

            List<Program_Model> program = new List<Program_Model>();
            Program_Model.ReadList(ref program, "IsOpen='True'");
            bSource_Program.DataSource = program;
                       
            MenuItemPermissions();

            #region 取得檔案伺服器的權限
            Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
            bool isEnableFileServer = Properties.Settings.Default.IsFileServer = dll.GetIsFileServer();
            Properties.Settings.Default.Save();

            #region 判斷是否啟用檔案上傳功能
            if (isEnableFileServer)
            {
                //檢查建立所需要的資料夾
                dll.CreatFolder( true);
                //Public.SecurityPermissions unc = new Public.SecurityPermissions(strFileServer_IP, strFileServer_Account, strFileServer_Password, strFileServerFolder);
            } 
            #endregion

            #endregion

            toolStripStatusLabel_User.Text = "登入者："+Properties.Settings.Default.WorkerName+" ["+Properties.Settings.Default.OfficeRoleName+"]  ";

        }
        #endregion

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
                        iProgramkind = item.ProgramKind.HasValue ? item.ProgramKind.Value : -1;
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
                            if (bSource_WorkerProgram.Current.ToString() == "LawtechPTSystemByFirm.ViewModel_WorkerProgram")
                            {
                                if (iFindIndex != -1)
                                {
                                    ReValue = ((LawtechPTSystemByFirm.ViewModel_WorkerProgram)(bSource_WorkerProgram.Current)).SearchAuthority;
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
                            if (bSource_WorkerProgram.Current.ToString() == "LawtechPTSystemByFirm.ViewModel_WorkerProgram")
                            {
                                if (iFindIndex != -1)
                                {
                                    ReValue = ((LawtechPTSystemByFirm.ViewModel_WorkerProgram)(bSource_WorkerProgram.Current)).SearchAuthority;
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
                //            if (bSource_WorkerProgram.Current.ToString() == "LawtechPTSystemByFirm.ViewModel_WorkerProgram")
                //            {
                //                if (iFindIndex != -1)
                //                {
                //                    ReValue = ((LawtechPTSystemByFirm.ViewModel_WorkerProgram)(bSource_WorkerProgram.Current)).SearchAuthority;
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
                       if (bSource_WorkerProgram.Current.ToString() == "LawtechPTSystemByFirm.ViewModel_WorkerProgram")
                       {
                           if (iFindIndex != -1)
                           {
                               ReValue = ((LawtechPTSystemByFirm.ViewModel_WorkerProgram)(bSource_WorkerProgram.Current)).SearchAuthority;
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
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            if (Forms.AttorneyMF !=null)
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
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

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
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

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
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            if (Forms.PetitionMF != null)
            {
                Forms.PetitionMF.Activate();
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
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            if (Forms.ApplicantSearchMF != null)
            {
                Forms.ApplicantSearchMF.Activate();
            }
            else
            {
                SubFrom.ApplicantSearchMF ASMF = new SubFrom.ApplicantSearchMF();
                ShowMDIChild(ASMF);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

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
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            if (Forms.QPSearchForm != null)
            {
                Forms.QPSearchForm.Activate();
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
            SubFrom.UpFilePath filepath = new LawtechPTSystemByFirm.SubFrom.UpFilePath();
            filepath.ShowDialog();
        } 
        #endregion

        private void MailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            if (Forms.PrintLabelMF != null)
            {
                Forms.PrintLabelMF.Activate();
            }
            else
            {
                SubFrom.PrintLabelMF PL = new SubFrom.PrintLabelMF();
                ShowMDIChild(PL);
            }

        }

        private void 員工權限管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            if (Forms.AuthorityMF != null)
            {
                Forms.AuthorityMF.Activate();
            }
            else
            {
                SubFrom.AuthorityMF PL = new SubFrom.AuthorityMF();
                ShowMDIChild(PL);
            }
        }

        #region 知識管理
        private void 文章上傳ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            if (Forms.UploadFile != null)
            {
                Forms.UploadFile.Activate();
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
            //Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            //if (Forms.KeyWords != null)
            //{
            //    Forms.KeyWords.Activate();
            //}
            //else
            //{
            //    SubFrom.KeyWords kw = new SubFrom.KeyWords();
            //    ShowMDIChild(kw);
            //}

            SubFrom.KeyWords keywords = new LawtechPTSystemByFirm.SubFrom.KeyWords();
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
                //pictureBox1.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.manage_show;
            }
            else
            {

                menuStrip1.Visible = true;
               // pictureBox1.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.manage_close;
            }
        }

        /// <summary>
        /// 專利案件管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void toolStripMenuItem_PATManagement_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            if (Forms.PatListMF != null)
            {
                Forms.PatListMF.Activate();
            }
            else
            {
                SubFrom.PatListMF patent = new SubFrom.PatListMF();
                ShowMDIChild(patent);
            }

            sw.Stop();//碼錶停止
            toolStripStatusLabel_stopwatch.Text = ((ToolStripMenuItem)sender).Text+" 啟動耗時:"+ sw.Elapsed.TotalSeconds.ToString("#,##0.##")+" 秒";
        }

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

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            if (Forms.Triff_PAT != null)
            {
                Forms.Triff_PAT.Activate();
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

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            if (Forms.ComitContentTMF != null)
            {
                Forms.ComitContentTMF.Activate();
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
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            if (Forms.PATNotifyContentMF != null)
            {
                Forms.PATNotifyContentMF.Activate();
            }
            else
            {
                SubFrom.PATNotifyContentMF PATNotifyContent = new SubFrom.PATNotifyContentMF();
                ShowMDIChild(PATNotifyContent);
            }
        }

        internal void 期限來函設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            if (Forms.PATNotifyDueMF != null)
            {
                Forms.PATNotifyDueMF.Activate();
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

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            if (Forms.PATStatusMF != null)
            {
                Forms.PATStatusMF.Activate();
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

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            if (Forms.PATFeatureMF != null)
            {
                Forms.PATFeatureMF.Activate();
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

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            if (Forms.TMNotifyContentMF != null)
            {
                Forms.TMNotifyContentMF.Activate();
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

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            if (Forms.TMStatusMF != null)
            {
                Forms.TMStatusMF.Activate();
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

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            if (Forms.TMTypeMF != null)
            {
                Forms.TMTypeMF.Activate();
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

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            if (Forms.PatentMF != null)
            {
                Forms.PatentMF.Activate();
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

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            if (Forms.TMMF != null)
            {
                Forms.TMMF.Activate();
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

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            if (Forms.PATEventProcess != null)
            {
                Forms.PATEventProcess.Activate();
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

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            if (Forms.PatFeePhase != null)
            {
                Forms.PatFeePhase.Activate();
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

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            if (Forms.Triff_TM != null)
            {
                Forms.Triff_TM.Activate();
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

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            if (Forms.TrademarkClassificationMF != null)
            {
                Forms.TrademarkClassificationMF.Activate();
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

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            if (Forms.TrademarkEventProcess != null)
            {
                Forms.TrademarkEventProcess.Activate();
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

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            if (Forms.TrademarkFeePhase != null)
            {
                Forms.TrademarkFeePhase.Activate();
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

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            if (Forms.TrademarkStyle != null)
            {
                Forms.TrademarkStyle.Activate();
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

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            if (Forms.TrademarkNotifyEventType != null)
            {
                Forms.TrademarkNotifyEventType.Activate();
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

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            if (Forms.TrademarkMF != null)
            {
                Forms.TrademarkMF.Activate();
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
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

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

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            if (Forms.PatentStatistics != null)
            {
                Forms.PatentStatistics.Activate();
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

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            if (Forms.TrademarkStatistics != null)
            {
                Forms.TrademarkStatistics.Activate();
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
            US.EmailSet mail = new LawtechPTSystemByFirm.US.EmailSet();
            mail.ShowDialog();
        }

        private void toolStripMenuItem_EmailSampleList_Click(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            if (Forms.MailSampleList != null)
            {
                Forms.MailSampleList.Activate();
            }
            else
            {
                SubFrom.MailSampleList MailSampl = new SubFrom.MailSampleList();

                ShowMDIChild(MailSampl);
            }
        }

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

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            if (Forms.AccountingPaymentMF != null)
            {
                Forms.AccountingPaymentMF.Activate();
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

        #region 應收款項
        /// <summary>
        /// 應收款項
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_AccountingFee_Click(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            if (Forms.AccountingFeeMF != null)
            {
                Forms.AccountingFeeMF.Activate();
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
            US.EmailSet mail = new LawtechPTSystemByFirm.US.EmailSet();
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
            US.EmployeeChangePassword password = new LawtechPTSystemByFirm.US.EmployeeChangePassword();
            password.ShowDialog();
        }
        #endregion 

        #region 修改個人資料
        private void 修改個人資料ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditForm.EditWorker worker = new LawtechPTSystemByFirm.EditForm.EditWorker();
            worker.Text += " ("+Properties.Settings.Default.WorkerName+")";
            worker.ShowDialog();
        }
        #endregion

        #region 商標異議案管理
        private void ToolStripMenuItem_ControversyCase_Click(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            if (Forms.TrademarkControversyMF != null)
            {
                Forms.TrademarkControversyMF.Activate();
            }
            else
            {
                SubFrom.TrademarkControversyMF ControversyMF = new SubFrom.TrademarkControversyMF();

                ShowMDIChild(ControversyMF);
            }
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
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            if (Forms.OfficePropertyMF != null)
            {
                Forms.OfficePropertyMF.Activate();
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

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            if (Forms.ApplicantMF != null)
            {
                Forms.ApplicantMF.Activate();
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

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            if (Forms.AttorneySearchMF != null)
            {
                Forms.AttorneySearchMF.Activate();
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

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            if (Forms.PatentFeeSearch != null)
            {
                Forms.PatentFeeSearch.Activate();
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

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            if (Forms.PatentPaymentSearch != null)
            {
                Forms.PatentPaymentSearch.Activate();
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

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            if (Forms.ApplicantSearchMF != null)
            {
               // Forms.ApplicantSearchMF.Activate();
                Forms.ApplicantSearchMF.Activate();
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
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
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
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
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
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
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

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            
            if (Forms.AccountingCombinList != null)
            {
                Forms.AccountingCombinList.Activate();
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

        #region 公佈欄
        /// <summary>
        /// 公佈欄
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem5_Click_1(object sender, EventArgs e)
        {
            sw.Reset();//碼表歸零
            sw.Start();//碼表開始計時

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            if (Forms.News != null)
            {
                Forms.News.Activate();
            }
            else
            {
                SubFrom.NewsList news = new SubFrom.NewsList();
                ShowMDIChild(news);
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

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            if (Forms.LinksMF != null)
            {
                Forms.LinksMF.Activate();
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

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            if (Forms.DelDataLogMF != null)
            {
                Forms.DelDataLogMF.Activate();
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
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            if (Forms.EmailLogMF != null)
            {
                Forms.EmailLogMF.Activate();
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

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            if (Forms.TrademarkFeeSearchList != null)
            {
                Forms.TrademarkFeeSearchList.Activate();
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

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            if (Forms.TrademarkPaymentSearchList != null)
            {
                Forms.TrademarkPaymentSearchList.Activate();
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

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            if (Forms.ApplicantList != null)
            {
                // Forms.ApplicantSearchMF.Activate();
                Forms.ApplicantList.Activate();
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

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            if (Forms.AttorneyMF != null)
            {
                Forms.AttorneyMF.Activate();
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

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            if (Forms.PatentEventList != null)
            {
                Forms.PatentEventList.Activate();
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
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

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

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            if (Forms.PATControlEventList != null)
            {
                Forms.PATControlEventList.Activate();
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
                Public.LoginForm loginMF = new LawtechPTSystemByFirm.Public.LoginForm();
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

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            if (Forms.PATControlYearFeeList != null)
            {
                Forms.PATControlYearFeeList.Activate();
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

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            if (Forms.PATControlPayment != null)
            {
                Forms.PATControlPayment.Activate();
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

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            if (Forms.PATControlFeeList != null)
            {
                Forms.PATControlFeeList.Activate();
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

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            if (Forms.PatentPerformanceList != null)
            {
                Forms.PatentPerformanceList.Activate();
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

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            if (Forms.TrademarkControlEventList != null)
            {
                Forms.TrademarkControlEventList.Activate();
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

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            if (Forms.TrademarkControlPaymentList != null)
            {
                Forms.TrademarkControlPaymentList.Activate();
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

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            if (Forms.TrademarkControlFeeList != null)
            {
                Forms.TrademarkControlFeeList.Activate();
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

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            if (Forms.TrademarkControlExtendedFeeList != null)
            {
                Forms.TrademarkControlExtendedFeeList.Activate();
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

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            if (Forms.CountrySetting != null)
            {
                Forms.CountrySetting.Activate();
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

              Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            if (Forms.TrademarkEventList != null)
            {
                Forms.TrademarkEventList.Activate();
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

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            if (Forms.TrademarkPerformanceList != null)
            {
                Forms.TrademarkPerformanceList.Activate();
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

     
       

    }
}