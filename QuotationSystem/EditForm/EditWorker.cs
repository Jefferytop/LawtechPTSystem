using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace LawtechPTSystem.EditForm
{
    public partial class EditWorker : Form
    {
        public EditWorker()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
        }

        private int iWorkerKey = -1;
        /// <summary>
        /// 員工KEY值
        /// </summary>
        public int WorkerKey
        {
            get { return iWorkerKey; }
            set { iWorkerKey = value; }
        }

        private int iOfficeRole = -1;
        /// <summary>
        /// 員工權限
        /// </summary>
        public int Property_OfficeRole
        {
            get { return iOfficeRole; }
            set { iOfficeRole = value; }
        }

        /// <summary>
        /// 是否啟用檔案上傳功能
        /// </summary>
        public bool IsFileServer
        {
            get;
            set;
        }

        /// <summary>
        /// 0:本機路徑 ; 1:區域網路
        /// </summary>
        public string FileServerType
        {
            get;
            set;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditWorker_Load(object sender, EventArgs e)
        {
            iWorkerKey = Properties.Settings.Default.WorkerKEY;
            IsFileServer = Properties.Settings.Default.IsFileServer;
            FileServerType = Properties.Settings.Default.FileServerType;

            if (IsFileServer && FileServerType == "0")
            {
                label22.Text = "啟用";
                label22.ForeColor = Color.Green;
                but_SelectFolder.Enabled = true;
            }

            Worker_Model worker = new Worker_Model();
            Worker_Model.ReadOne(iWorkerKey, ref  worker);          

            iOfficeRole = worker.OfficeRole.Value;

            txt_Addr.Text = worker.Addr;
            txt_Background.Text = worker.Background;
            if (worker.Birthday.HasValue)
            {
                maskedTextBox_Birthday.Text = worker.Birthday.Value.ToString("yyyy-MM-dd");
            }
          
           
            txt_Email.Text = worker.Email;
            txt_EverAddr.Text = worker.EverAddr;
            txt_Experience.Text = worker.Experience;
            txt_ext.Text = worker.ext;
            txt_ID.Text = worker.EmployeeID;
           
            txt_Mobilephone.Text = worker.Mobilephone;
            txt_Name.Text = worker.EmployeeName;
            txt_NameEn.Text = worker.EmployeeNameEn;
           
            txt_Remark.Text = worker.Remark;
            txt_Specialty.Text = worker.Specialty;
            txt_TEL.Text = worker.TEL;
            txt_WorkerId.Text = worker.WorkerSymbol;
            txt_SingOffCode.Text = worker.SingCode;
            txt_WorkScope.Text = worker.WorkScope;
            txt_LocalhostPath.Text = worker.FileServer_LocalhostPath;

            if (worker.IsLoadData.Value)
            {
                radioButton_Load.Checked = true;
                radioButton_NoLoad.Checked = false;
            }
            else
            {
                radioButton_Load.Checked = false;
                radioButton_NoLoad.Checked = true;
            }

            if (worker.LoadDataRange.HasValue)
            {
                switch (worker.LoadDataRange.Value)
                {
                    case 0:
                        radioButton_All.Checked = true;
                        break;
                    case 3:
                        radioButton_3.Checked = true;
                        break;
                    case 6:
                        radioButton_6.Checked = true;
                        break;
                    case 12:
                        radioButton_12.Checked = true;
                        break;
                }
            }

            DataTable dt = GetOfficeProperty();
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            dataGridView1.DataSource = bs;

            bindingNavigator1.BindingSource = bs;


            if (iOfficeRole != 1)
            {
                lab_SingOffCode.Visible = true;
                txt_SingOffCode.Visible = true;
            }
            else
            {
                lab_SingOffCode.Visible = false;
                txt_SingOffCode.Visible = false;
            }

            //功能表單的初始狀態
            if (Properties.Settings.Default.WindowStatus == "Max")
            {
                radioButton_WinMax.Checked = true;
            }
            else
            {
                radioButton_WinNormal.Checked = true;
            }

            //MDI視窗
            if (Properties.Settings.Default.IsMdiParent )
            {
                radioButton_mdiYes.Checked = true;
            }
            else
            {
                radioButton_mdiNo.Checked = true;
            }
        }


        public DataTable GetOfficeProperty()
        {
            string strSQL = " Select OfficePropertyID ,OfficePropertyNo,OfficePropertyName,Specifications,FunctionDescription,Location from  OfficePropertyT where  Owner like '%" + Properties.Settings.Default.WorkerName + "%'";
            Public.DLL dll = new Public.DLL();
            DataTable dt=  dll.SqlDataAdapterDataTable(strSQL);
            return dt;
        }

        private void but_OK_Click(object sender, EventArgs e)
        {
            if (txt_WorkerId.Text == "")
            {
                txt_WorkerId.Focus();
                return;
            }
            if (txt_Name.Text == "")
            {
                txt_Name.Focus();
                return;
            }

            Worker_Model add = new Worker_Model();
            Worker_Model.ReadOne(WorkerKey, ref  add);

           
            bool isWorkerSymbol= false;
                add.CheckValueExist("WorkerSymbol", txt_WorkerId.Text,ref isWorkerSymbol,false);
                if (txt_WorkerId.Text != "" && add.WorkerSymbol != txt_WorkerId.Text && isWorkerSymbol)
            {
                MessageBox.Show("員工編號重覆，請重新再確認", "提示訊息");
                return;
            }

            bool isEmployeeID = false;
            add.CheckValueExist("EmployeeID", txt_ID.Text,ref isEmployeeID,false);
            if (txt_ID.Text != "" && add.EmployeeID != txt_ID.Text && isEmployeeID)
            {
                MessageBox.Show("身份證字號重覆，請重新再確認", "提示訊息");
                return;
            }

           
            add.Addr = txt_Addr.Text;
            add.Background = txt_Background.Text;

            DateTime dtimeBirthday;
            bool isBirthday = DateTime.TryParse(maskedTextBox_Birthday.Text, out dtimeBirthday);
            if (isBirthday)
            {
                add.Birthday = dtimeBirthday;
            }
            else
            {
                add.Birthday = null;
            }

            add.Email = txt_Email.Text;
            add.EverAddr = txt_EverAddr.Text;
            add.Experience = txt_Experience.Text;
            add.ext = txt_ext.Text;
            add.EmployeeID = txt_ID.Text;
            
            add.Mobilephone = txt_Mobilephone.Text;
            add.EmployeeName = txt_Name.Text;
            add.EmployeeNameEn = txt_NameEn.Text;                     
            add.Remark = txt_Remark.Text;
            add.Specialty = txt_Specialty.Text;
            add.TEL = txt_TEL.Text;
            add.WorkerSymbol = txt_WorkerId.Text;
            add.FileServer_LocalhostPath = txt_LocalhostPath.Text.Trim();
            add.CreateDateTime = DateTime.Now;
            add.LastModifyDateTime = DateTime.Now;
            add.LastModifyWorker = Properties.Settings.Default.WorkerName;
           
            txt_LocalhostPath.Text= add.FileServer_LocalhostPath;
           
            add.SingCode = txt_SingOffCode.Text;
                      
            add.IsLoadData = radioButton_Load.Checked;

            if (radioButton_All.Checked)
            {
                add.LoadDataRange = 0;
            }
            else if (radioButton_3.Checked)
            {
                add.LoadDataRange = 3;
            }
            else if (radioButton_6.Checked)
            {
                add.LoadDataRange = 6;
            }
            else
            {
                add.LoadDataRange = 12;
            }

            if (radioButton_WinMax.Checked)
            {
                add.WindowStatus = "Max";
            }
            else
            {
                add.WindowStatus = "Normal";
            }

            if (radioButton_mdiYes.Checked)
            {
                add.IsMdiParent =true;
            }
            else
            {
                add.IsMdiParent = false;
            }

            Public.PublicForm Forms = new Public.PublicForm();
            if (Forms.AuthorityMF != null)
            {
                //add.SetDataTable(Forms.AuthorityMF.DtWorkers);
            }

            add.Update();

            Properties.Settings.Default.IsLoadData = add.IsLoadData.Value; //是否載入資料
            Properties.Settings.Default.LoadDataRange = add.LoadDataRange.Value;//載入資料的時間範圍
            Properties.Settings.Default.FileServerLocalhostPath = add.FileServer_LocalhostPath; //本機上傳路徑
            Properties.Settings.Default.WindowStatus = add.WindowStatus;
            Properties.Settings.Default.IsMdiParent = add.IsMdiParent.HasValue? add.IsMdiParent.Value:false;
            Properties.Settings.Default.Save();

            MessageBox.Show("修改個人資料成功");
            this.Close();
        }

        private void but_SelectFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txt_LocalhostPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void maskedTextBox_Birthday_Leave(object sender, EventArgs e)
        {
            MaskedTextBox mak = (MaskedTextBox)sender;
            Public.Utility.CheckMaskedtextbox(mak);
        }

        private void txt_LocalhostPath_TextChanged(object sender, EventArgs e)
        {
            lab_FilePath.Text = Path.Combine(txt_LocalhostPath.Text,Properties.Settings.Default.RootFolder);
        }
    }
}
