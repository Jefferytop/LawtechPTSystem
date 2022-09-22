using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using H3Operator.DBHelper;
using H3Operator.DBModels;
using System.Data.SqlClient;
using System.Drawing;


namespace LawtechPTSystemByFirm
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
            // 找出字體大小,並算出比例
            float dpiX, dpiY;
            Graphics graphics = this.CreateGraphics();
            dpiX = graphics.DpiX;
            dpiY = graphics.DpiY;
            int intPercent = (dpiX == 96) ? 100 : (dpiX == 120) ? 125 : 150;

            // 針對字體變更Form的大小
            this.Height = this.Height * intPercent / 100;

            DBAccess.AddConnectionList("DataBaseConnectionString", Public.PublicCommonFunction.GetConnectionString());
           
            if (DBAccess.ConnectionList.Count > 0)
            {
                DBAccess.SetDefaultConnection("DataBaseConnectionString");

                SqlConnection sql = new SqlConnection(DBAccess.ConnectionList["DataBaseConnectionString"]);
                label_DBName.Text = sql.Database;

                Public.CCommonPublicFunction common = new Public.CCommonPublicFunction();
                Properties.Settings.Default.SystemName = common.SystemName;
                Properties.Settings.Default.EnableAddFee = common.EnableAddFee;
                Properties.Settings.Default.EnableAddPayment = common.EnableAddPayment;
                Properties.Settings.Default.Save();
            }
        }
        #endregion

        #region but_OK_Click
        private void but_OK_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Account.Text != "" && txt_Password.Text != "")
                {
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
                            Properties.Settings.Default.IsLoadData = Workers[0].IsLoadData.HasValue? Workers[0].IsLoadData.Value:true; //是否載入資料
                            Properties.Settings.Default.LoadDataRange =Workers[0].LoadDataRange.HasValue? Workers[0].LoadDataRange.Value:(short)0;//載入資料的時間範圍

                           List< Public.V_OfficeRoleT> officeRole = new  List< Public.V_OfficeRoleT> ();
                           Public.V_OfficeRoleT.ReadViewTableList("OfficeRole=" + Workers[0].OfficeRole.Value.ToString(), ref officeRole);                          
                           if (officeRole.Count == 1)
                           {
                               Properties.Settings.Default.OfficeRoleName = officeRole[0].OfficeRoleName;
                           }

                            Properties.Settings.Default.FileServerLocalhostPath = Workers[0].FileServer_LocalhostPath ?? ""; //本機檔案上傳路徑

                            DB_Models.DB_WorkerLoginTModel login = new DB_Models.DB_WorkerLoginTModel();
                        
                            login.WorkerKey = Properties.Settings.Default.WorkerKEY;
                            login.Online = true;
                            login.OnlineTime = DateTime.Now;
                            login.Create();

                            //記錄登入時間
                            Properties.Settings.Default.OnlineTime = login.OnlineTime.Value;
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
    }
}