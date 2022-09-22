using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using H3Operator.DBHelper;
using H3Operator.DBModels;
using System.Data.SqlClient;
using System.Drawing;


namespace LawtechPTSystem
{
    public partial class Login : Form
    {

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;

        public Login()
        {
            InitializeComponent();
        }

        #region Login_Load
        private void Login_Load(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.Login = this;

            // 找出字體大小,並算出比例
            float dpiX, dpiY;
            Graphics graphics = this.CreateGraphics();
            dpiX = graphics.DpiX;
            dpiY = graphics.DpiY;
            int intPercent = (dpiX == 96) ? 100 : (dpiX == 120) ? 125 : 150;

            // 針對字體變更Form的大小
            this.Height = this.Height * intPercent / 100;

            DBAccess.AddConnectionList("DataBaseConnectionString", Public.PublicCommonFunction.GetConnectionString());
            //DBAccess.SetDefaultConnection("DataBaseConnectionString");


            if (DBAccess.ConnectionList.Count > 0)
            {
                DBAccess.SetDefaultConnection("DataBaseConnectionString");

                SqlConnection sql = new SqlConnection(DBAccess.ConnectionList["DataBaseConnectionString"]);
                Properties.Settings.Default.DatabaseName = sql.Database;
                Properties.Settings.Default.DataSource = sql.DataSource;
                label_DBName.Text = sql.Database;

                #region 取得系統相關配置
                Public.CCommonPublicFunction common = new Public.CCommonPublicFunction();
                Properties.Settings.Default.SystemName = common.SystemName;
                Properties.Settings.Default.EnableAddFee = common.EnableAddFee;
                Properties.Settings.Default.EnableAddPayment = common.EnableAddPayment;
                Properties.Settings.Default.QuotationLogo = common.QuotationLogo;
                Properties.Settings.Default.MACSettingType = common.MACSettingType;
                Properties.Settings.Default.IsFileServer = common.IsFileServer;
                Properties.Settings.Default.FileServerType = common.FileServerType;
                Properties.Settings.Default.FileServerLocalhostPath = common.FileServer_LocalhostPath; //系統預設本機檔案上傳路徑
                Properties.Settings.Default.IntranetPath = common.IntranetPath; //區域網路路徑
                Properties.Settings.Default.IsFileServerConnection =false; //預設檔案服務器連線為false  
                Properties.Settings.Default.Save();
                #endregion

                #region 驗證MAC機制              

                if (common.MACSettingType == "2" || common.MACSettingType == "3")
                {  
                    if (common.MACSettingType == "2")
                    {
                        lab_MACSettingType.Text = "中安全性機制";
                        lab_MACSettingType.ForeColor = System.Drawing.Color.Green;
                    }
                    else {
                        lab_MACSettingType.Text = "高安全性機制";
                        lab_MACSettingType.ForeColor = System.Drawing.Color.Purple;
                    }
                    bool isPass = false;
                    Public.PublicClass my = new Public.PublicClass();
                    string strMAC = my.GetMACaddress();
                    string[] macArray = strMAC.Split(',');
                    Public.CMacSettingPublicFunction.CheckMACSettingTPass(macArray, ref isPass);

                    if (!isPass)
                    {
                        MessageBox.Show("您的MAC位址未在授權的名單中，請洽管理者啟用MAC授權\r\n "+ strMAC);
                        but_Cancel_Click(null,null);
                    }
                }
                else
                {
                    lab_MACSettingType.Text = "";
                } 
                #endregion

                #region Logo圖
                if (string.IsNullOrEmpty(common.LoginLogo))
                {
                    pictureBox1.Visible = false;
                }
                else
                {
                    pictureBox1.Visible = true;
                    pictureBox1.ImageLocation = common.LoginLogo;
                }
                #endregion

                #region 檢查授權
                Public.CStructure checkDB = new Public.CStructure();
                bool isAuthorize = checkDB.GetAuthorize(label_DBName.Text.Trim());
                if (!isAuthorize)
                {
                    but_OK.Visible = false;
                    MessageBox.Show("您使用的P.T.S系統租用時間已到期，請洽柏豐商務智權公司，感謝您!!");
                } 
                #endregion

            }
        }
        #endregion

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.Login = null;
        }

        #region but_OK_Click
        private void but_OK_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Account.Text != "" && txt_Password.Text != "")
                {
                    #region 驗證MAC機制              

                    if (Properties.Settings.Default.MACSettingType == "3")
                    {                       
                        bool isPass = false;
                        Public.PublicClass my = new Public.PublicClass();
                        string strMAC = my.GetMACaddress();
                        string[] macArray = strMAC.Split(',');
                        Public.CMacSettingPublicFunction.CheckMACSettingTPass(macArray, txt_Account.Text.Trim(), ref isPass);

                        if (!isPass)
                        {
                            MessageBox.Show("您的MAC位址和登入帳號  "+ txt_Account.Text + " 不符，請洽管理者啟用MAC授權\r\n " + strMAC);
                            txt_Account.Focus();
                            return;
                        }
                    }
                    
                    #endregion

                    ORMFactory orm = new ORMFactory();
                    List<Worker_Model> Workers = new List<Worker_Model>();
                    System.Data.SqlClient.SqlParameter[] ParaList ={DBAccess.MakeInParam("Account",SqlDataType.NVarChar, txt_Account.Text.Trim()),
                                                                   DBAccess.MakeInParam("Password",SqlDataType.NVarChar, txt_Password.Text.Trim())};
                    object objResult = Worker_Model.ReadList(ref Workers, "Account=@Account and Password=@Password and IsQuit<>1", ParaList);

                    if (objResult.ToString() == "0")
                    {
                        if (Workers.Count == 1)
                        {
                            Properties.Settings.Default.WorkerName = Workers[0].EmployeeName;
                            Properties.Settings.Default.WorkerKEY = Workers[0].WorkerKey; //key值                      
                            Properties.Settings.Default.OfficeRole = Workers[0].OfficeRole.Value; //角色權限
                            Properties.Settings.Default.IsLoadData = Workers[0].IsLoadData ?? true; //是否載入資料
                            Properties.Settings.Default.LoadDataRange =Workers[0].LoadDataRange.HasValue? Workers[0].LoadDataRange.Value:(short)0;//載入資料的時間範圍                          
                            Properties.Settings.Default.FileServerLocalhostPath_WorkerT = Workers[0].FileServer_LocalhostPath == null ? "" : Workers[0].FileServer_LocalhostPath;//user自定義本機上傳檔案路徑
                            Properties.Settings.Default.WindowStatus = Workers[0].WindowStatus;//初始表單的設定
                            Properties.Settings.Default.IsMdiParent = Workers[0].IsMdiParent.HasValue? Workers[0].IsMdiParent.Value:false; //是否使用MDI子表單

                            Public.CCommonPublicFunction common = new Public.CCommonPublicFunction();
                            Properties.Settings.Default.HomePageEvent = common.HomePageEvent;
                            Properties.Settings.Default.HistoryRecordMode = common.HistoryRecordMode;

                            Public.PublicClass my = new Public.PublicClass();

                            if (string.IsNullOrEmpty(Properties.Settings.Default.OSVersion.ToString()))
                            {                               
                                Properties.Settings.Default.OSVersion = my.GetOSVersion();
                                Properties.Settings.Default.OSbit = my.GetAddressWidth();
                              
                            }
                            Properties.Settings.Default.MAC = my.GetMACaddress();
                            Properties.Settings.Default.CPU = my.GetCPU();
                            Properties.Settings.Default.IPAddressList = my.GetHostIPAddress();
                            Properties.Settings.Default.IPAddress = my.GetExtranetIPAddress();
                           

                            List< Public.V_OfficeRoleT> officeRole = new  List< Public.V_OfficeRoleT> ();
                           Public.V_OfficeRoleT.ReadViewTableList("OfficeRole=" + Workers[0].OfficeRole.Value.ToString(), ref officeRole);                          
                           if (officeRole.Count == 1)
                           {
                               Properties.Settings.Default.OfficeRoleName = officeRole[0].OfficeRoleName;
                           }
                 
                         
                            Properties.Settings.Default.Save();

                            this.Visible = false;
                            txt_Account.Text = "";
                            txt_Password.Text = "";

                            Public.LoginForm loginMF = new Public.LoginForm();
                            loginMF.Login = this;

                            MainFrom MDI = new MainFrom();
                            MDI.Show();
                                                       
                        }
                        else if (Workers.Count > 1)
                        {
                            MessageBox.Show("有兩筆以上相同之帳號，\r\n請洽最高管理者協助(帳號必為唯一值)!! ", "提示訊息");
                        }
                        else
                        {
                            MessageBox.Show("查無此帳號，請重新確認帳號、密碼 !!      ", "提示訊息");
                        }
                    }

                }
                else
                {
                    MessageBox.Show("請輸入『帳號』、『密碼』...", "提示訊息");
                }
            }
            catch(System.Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }
        #endregion

        #region but_Cancel_Click
        private void but_Cancel_Click(object sender, EventArgs e)
        {          
            Application.Exit();
            Application.ExitThread();
        }
        #endregion

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        #region private void label6_Click(object sender, EventArgs e)
        /// <summary>
        /// 版權所有 ‧ 翻版必究
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label6_Click(object sender, EventArgs e)
        {
            Public.PublicClass my = new Public.PublicClass();
            MessageBox.Show(my.GetApplicationExecutablePath());
        }
        #endregion

     
    }
}