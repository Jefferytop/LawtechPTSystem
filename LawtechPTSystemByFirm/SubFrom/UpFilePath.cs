using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LawtechPTSystemByFirm.FTPClass;
using System.IO;


namespace LawtechPTSystemByFirm.SubFrom
{
    public partial class UpFilePath : Form
    {
        public UpFilePath()
        {
            InitializeComponent();
        }

        BaseClass bc = new BaseClass();

        private string strRootFolder = "";
        /// <summary>
        /// 預設最上層資料夾名稱
        /// </summary>
        public string RootFolder
        {

            get { return strRootFolder; }
            set { strRootFolder = value; }
        }

        /// <summary>
        /// 上傳檔案的路徑
        /// </summary>
        public string FullPath
        {
            get {
                if (radioButton1.Checked )//本機路徑
                {
                    if (!string.IsNullOrEmpty(txt_LocalhostPath.Text) && txt_LocalhostPath.Text.Substring(txt_LocalhostPath.Text.Trim().Length - 1) == "\\")
                    {
                        return txt_LocalhostPath.Text.Trim() + "\\" + RootFolder;
                    }
                    else {
                        return txt_LocalhostPath.Text.Trim() + "\\" + RootFolder;
                    }
                }
                else//區域網路路徑
                {
                    return  txt_IntranetPath.Text.Trim() ;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //Public.SecurityPermissions unc = new Public.SecurityPermissions(txt_FileServer_IP.Text, txt_FileServer_Account.Text, txt_FileServer_Password.Text, txt_FileServerFolder.Text);

            try
            {
                if (Directory.Exists(FullPath))
                {
                    if (!Directory.Exists(FullPath + "\\" + RootFolder))
                    {
                        Directory.CreateDirectory(FullPath + "\\" + RootFolder);
                    }

                    MessageBox.Show("連結成功，路徑正確");
                }
                else
                {
                    MessageBox.Show("連結失敗，路徑失敗：" + FullPath);
                }
            }
            catch (System.Exception EX)
            {
                MessageBox.Show(string.Format("連結失敗，路徑失敗：{0} \r\n{1}", FullPath, EX.Message));
            }

        }

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void but_OK_Click(object sender, EventArgs e)
        {
            try
            {
                if (FullPath != "")
                {
                    //判斷是否有指定的資料夾
                    if (Directory.Exists(FullPath))
                    {
                        //判斷是否有OfficeSystemData資料夾
                        if (!Directory.Exists(lab_FullPath.Text ))
                        {
                            Directory.CreateDirectory(lab_FullPath.Text );                            
                        }
                    }
                    else
                    {
                        MessageBox.Show("找不到該路徑：" + txt_FileServerFolder.Text);
                        return;
                    }

                    List<DB_Models.DB_StatueRecordTModel> StatueRecord = new List<DB_Models.DB_StatueRecordTModel>();
                    DB_Models.DB_StatueRecordTModel.ReadList(ref  StatueRecord);

                    //啟用檔案上傳功能
                    var item = StatueRecord.Find(x => x.StatusName == "IsFileServer");
                    item.Value = cb_IsFileServer.Checked == true ?"1" : "0";
                    item.Update();

                    Properties.Settings.Default.IsFileServer = cb_IsFileServer.Checked;
                    Properties.Settings.Default.Save();

                    item = StatueRecord.Find(x => x.StatusName == "FileServerType");
                    item.Value = radioButton1.Checked == true ? "0" : "1";
                    item.Update();

                    item = StatueRecord.Find(x => x.StatusName == "FileServerFolder");
                    item.Value = txt_FileServerFolder.Text;
                    item.Update();

                    //item = StatueRecord.Find(x => x.StatusName == "FileServer_Account");
                    //item.Value = txt_FileServer_Account.Text;
                    //item.Update();

                    //item = StatueRecord.Find(x => x.StatusName == "FileServer_Password");
                    //item.Value = txt_FileServer_Password.Text;
                    //item.Update();

                    item = StatueRecord.Find(x => x.StatusName == "FileServer_IP");
                    item.Value = txt_FileServer_IP.Text;
                    item.Update();

                    item = StatueRecord.Find(x => x.StatusName == "FileServer_LocalhostPath");
                    item.Value = txt_LocalhostPath.Text;
                    item.Update();

                    item = StatueRecord.Find(x => x.StatusName == "IntranetPath");
                    item.Value = txt_IntranetPath.Text;
                    item.Update();

                   
                    Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();

                    dll.CreatFolder(true);
                                        
                    MessageBox.Show("路徑修改成功，如舊的路徑上有檔案，請記得搬移資料到新的位置. ","提示");

                    this.Close();
                }
                else
                {
                    MessageBox.Show("請輸入檔案上傳路徑，並確認有使用權限");
                }
            }
            catch (System.Exception EX)
            {
                MessageBox.Show(EX.Message.Replace("'", ""));
                return;
            }
        }

        #region UpFilePath_Load
        private void UpFilePath_Load(object sender, EventArgs e)
        {
            List<DB_Models.DB_StatueRecordTModel> StatueRecord = new List<DB_Models.DB_StatueRecordTModel>();
            DB_Models.DB_StatueRecordTModel.ReadList(ref  StatueRecord);

            var item = StatueRecord.Find(x => x.StatusName == "IsFileServer");
            if (item.Value == "1")
            {
                cb_IsFileServer.Checked = true;
            }
            else
            {
                cb_IsFileServer.Checked = false;
            }

            cb_FTPServerEnable_CheckedChanged(null, null);


            item = StatueRecord.Find(x => x.StatusName == "IntranetPath");
            txt_IntranetPath.Text = item.Value.ToString();

            
            item = StatueRecord.Find(x => x.StatusName == "FileServer_LocalhostPath");
            txt_LocalhostPath.Text = item.Value.ToString();

            //item = StatueRecord.Find(x => x.StatusName == "FileServerFolder");
            //txt_FileServerFolder.Text = item.Value.ToString();
            
            item = StatueRecord.Find(x => x.StatusName == "RootFolder");
            strRootFolder = item.Value.ToString();

            if (cb_IsFileServer.Checked)
            {
                lab_FullPath.Text = FullPath;

                radioButton1_CheckedChanged(radioButton1, null);
            }

            label4.Text = "預設最上層資料夾名稱" + strRootFolder + "(系統自動建立)";

        }
        #endregion

        private void txt_IP_TextChanged(object sender, EventArgs e)
        {
            lab_FullPath.Text = string.Format(@"\\{0}\{1}\{2}", txt_FileServer_IP.Text, txt_FileServerFolder.Text, strRootFolder);
        }

        private void but_SelectFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txt_LocalhostPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb=( RadioButton )sender;
            if (rb.Name == "radioButton1" && rb.Checked)
            {
                groupBox2.Enabled = rb.Checked;
                groupBox3.Enabled = !rb.Checked;
            }
            else
            {
                groupBox2.Enabled = !rb.Checked;
                groupBox3.Enabled = rb.Checked;            
            }
            if (cb_IsFileServer.Checked)
            {
                lab_FullPath.Text = FullPath;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_LocalhostPath_TextChanged(object sender, EventArgs e)
        {
            if (cb_IsFileServer.Checked && radioButton1.Checked)
            {
                lab_FullPath.Text = txt_LocalhostPath.Text + "\\" + RootFolder;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_FileServer_IP_TextChanged(object sender, EventArgs e)
        {
            if (cb_IsFileServer.Checked && radioButton2.Checked)
            {
                lab_FullPath.Text = FullPath + "\\" + RootFolder;
            }
        }

        private void cb_FTPServerEnable_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = cb_IsFileServer.Checked;

        }

        #region 區域網路路徑
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_SelectFolderLan_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txt_IntranetPath.Text = folderBrowserDialog1.SelectedPath;
            }
        } 
        #endregion

        private void txt_IntranetPath_TextChanged(object sender, EventArgs e)
        {
            if (cb_IsFileServer.Checked && radioButton2.Checked)
            {
                lab_FullPath.Text = txt_IntranetPath.Text + "\\" + RootFolder;
            }
        }

                       
        
    }
}