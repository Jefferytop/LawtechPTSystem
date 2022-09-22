using System;
using System.Windows.Forms;
using System.IO;

namespace LawtechPTSystem.US
{
    /// <summary>
    /// 舊版不要使用
    /// </summary>
    public partial class UpdataFile : Form
    {

        private int mDescriptMode = 1;
        /// <summary>
        /// 文件描述模式: 1:使用TextBox做描述輸入 2:使用ComboBox做描述輸入。
        /// </summary>
        public int DescriptMode
        {
            get { return mDescriptMode; }
            set { mDescriptMode = value; }
        }

        private int  uploadMode ;
        /// <summary>
        /// 檔案上傳模式: 1.段落依據 2.相關檔案管理 3.專利案件相關檔案管理 4.商標案件相關檔案管理
        /// </summary>
        public int UploadMode
        {
            get { return uploadMode; }
            set { uploadMode = value; }
        }

        private int mFileKey = -1;
        /// <summary>
        /// 申請案的Key值。
        /// </summary>
        public int MainFileKey
        {
            get { return mFileKey; }
            set { mFileKey = value; }
        }

        private int childKey = -1;
        /// <summary>
        /// 副key值
        /// </summary>
        public int ChildFileKey
        {
            get { return childKey; }
            set { childKey = value; }
        }

        private int mFileType = -1;
        /// <summary>
        /// 類型(例:專利 0.申請案 1.委辦  2.來函  3.請款費用 4.付款費用    商標5.代表圖 6.商標案件 7.來函 8.請款費用 9.付款費用)
        /// </summary>
        public int MainFileType
        {
            get { return mFileType; }
            set { mFileType = value; }
        }

        public UpdataFile()
        {
            InitializeComponent();
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            try
            {
                Public.DLL dll = new Public.DLL();
                dll.CreatFolder(3, MainFileKey.ToString());
                for (int i = 1; i < 6; i++)
                {
                    TextBox txt_Path = (TextBox)this.Controls.Find("path" + i.ToString(), false)[0];

                    Public.CUpLoadFile uploadfile = new Public.CUpLoadFile();
                    if (txt_Path.Text != "")
                    {
                        TextBox txt_Doc = (TextBox)this.Controls.Find("Name_Path" + i.ToString(), false)[0];
                        ComboBox cb = (ComboBox)this.Controls.Find("Ver" + i.ToString(), false)[0];
                        uploadfile.MainParentID = MainFileKey;
                      
                        uploadfile.Uploader = Properties.Settings.Default.WorkerName;
                        uploadfile.FileDoc = txt_Doc.Text + cb.Text;
                        uploadfile.FileType = MainFileType;
                        uploadfile.FileKind = uploadMode;
                        uploadfile.ChildID = ChildFileKey;
                        FileInfo Upfile = new FileInfo(txt_Path.Text);

                        uploadfile.FilePath = string.Format(@"{0}\{1}", MainFileKey, Upfile.Name);

                        string sPath = "";
                        if (UploadMode == 1)
                        {
                            sPath = string.Format("{0}\\{1}", dll.PatentFolderRoot, uploadfile.FilePath);
                        }
                        else
                        {
                            sPath = string.Format("{0}\\{1}", dll.TrademarkFolderRoot, uploadfile.FilePath);
                        }

                        File.Copy(txt_Path.Text, sPath);
                        uploadfile.Create();

                        txt_Path.Text = "";
                        txt_Doc.Text = "";
                        cb.Text = "";
                    }
                }

                if (checkBox6.Checked)
                {
                    this.Close();
                }
            }
            catch(System.IO.IOException IOEX)
            {
                MessageBox.Show(IOEX.Message);
            }
        }

        private void but_Path1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileInfo file = new FileInfo(openFileDialog1.FileName);

                path1.Text = openFileDialog1.FileName;

                if (mDescriptMode == 1)
                {
                    Name_Path1.Text = file.Name.Replace(file.Extension, "");
                }
                //checkBox1.Checked = true;
            }
        }

        private void but_Path2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileInfo file = new FileInfo(openFileDialog1.FileName);

                path2.Text = openFileDialog1.FileName;

                if (mDescriptMode == 1)
                {
                    Name_Path2.Text = file.Name.Replace(file.Extension, "");
                }

                //checkBox2.Checked = true;
            }
        }

        private void but_Path3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileInfo file = new FileInfo(openFileDialog1.FileName);

                path3.Text = openFileDialog1.FileName;

                if (mDescriptMode == 1)
                {
                    Name_Path3.Text = file.Name.Replace(file.Extension, "");
                }

                //checkBox3.Checked = true;
            }
        }

        private void but_Path4_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileInfo file = new FileInfo(openFileDialog1.FileName);

                path4.Text = openFileDialog1.FileName;

                if (mDescriptMode == 1)
                {
                    Name_Path4.Text = file.Name.Replace(file.Extension, "");
                }

                //checkBox4.Checked = true;
            }
        }

        private void but_Path5_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileInfo file = new FileInfo(openFileDialog1.FileName);

                path5.Text = openFileDialog1.FileName;

                if (mDescriptMode == 1)
                {
                    Name_Path5.Text = file.Name.Replace(file.Extension, "");
                }

                //checkBox5.Checked = true;
            }
        }

        private void but_Cancel1_Click(object sender, EventArgs e)
        {
            Button but = (Button)sender;
            switch (but.Name)
            {
                case "but_Cancel1":
                    path1.Text = "";
                    Name_Path1.Text = "";
                    break;
                case "but_Cancel2":
                    path2.Text = "";
                    Name_Path2.Text = "";
                    break;
                case "but_Cancel3":
                    path3.Text = "";
                    Name_Path3.Text = "";
                    break;
                case "but_Cancel4":
                    path4.Text = "";
                    Name_Path4.Text = "";
                    break;
                case "but_Cancel5":
                    path5.Text = "";
                    Name_Path5.Text = "";
                    break;
            }
        }

            
    }
}
