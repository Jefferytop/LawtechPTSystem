using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace LawtechPTSystemByFirm.SubFrom
{
    public partial class ApplicantViewDownFileList : Form
    {
        public ApplicantViewDownFileList()
        {
            InitializeComponent();
        }

        private int iFileKind = -1;
        /// <summary>
        /// 檔案上傳模式[大階層]: 1.段落依據 2.相關檔案管理 3.專利案件相關檔案管理 4.商標案件相關檔案管理 5.商標異議案 6.單位財產 
        /// 10.知識管理 20.EmailLog的附件  
        /// 30.已刪除的附件 
        /// 40.客戶附加檔案   50.事務所附加檔案
        /// </summary>
        public int Pro_FileKind
        {
            get { return iFileKind; }
            set { iFileKind = value; }
        }

        private int iMainKey = -1;
        /// <summary>
        /// 主要Key值
        /// </summary>
        public int Pro_MainKey
        {
            get { return iMainKey; }
            set { iMainKey = value; }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void ApplicantViewDownFileList_Load(object sender, EventArgs e)
        {
            this.upLoadFileTTableAdapter.Fill(this.dataSet_UpLoadFile.UpLoadFileT, Pro_FileKind, Pro_MainKey);
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip1.Visible = false;

            switch (e.ClickedItem.Name)
            {
                case "ToolStripMenuItem_DelFile":
                    //bindingNavigatorDeleteItem_Click(bindingNavigatorDeleteItem, null);
                    break;

                case "ToolStripMenuItem_SaveAs":

                    Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
                    string SaveFileDir = "";


                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                        {
                            for (int iRow = 0; iRow < dataGridView1.SelectedRows.Count; iRow++)
                            {
                                if (folderBrowserDialog1.SelectedPath != "")
                                {
                                    string NewPath = folderBrowserDialog1.SelectedPath;
                                    string FullPath = dataGridView1.SelectedRows[iRow].Cells["FilePath"].Value.ToString();
                                    if (Pro_FileKind == 40)
                                    {
                                        SaveFileDir = string.Format(@"{0}\{1}", dll.CustomerFolderRoot, FullPath);
                                    }
                                    else if (Pro_FileKind == 50)
                                    {
                                        SaveFileDir = string.Format(@"{0}\{1}", dll.FirmFolderRoot, FullPath);
                                    }
                                  
                                    if (File.Exists(SaveFileDir))
                                    {
                                        try
                                        {
                                            FileInfo file = new FileInfo(SaveFileDir);
                                            File.Copy(SaveFileDir, NewPath + "\\" + file.Name);
                                        }
                                        catch (System.Exception EX)
                                        {
                                            MessageBox.Show(EX.Message);
                                            return;
                                        }

                                    }

                                }
                            }
                            MessageBox.Show("另存檔案成功", "提示訊息");
                        }
                    }
                    else
                    {
                        if (dataGridView1.CurrentRow != null)
                        {
                            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                            {
                                if (folderBrowserDialog1.SelectedPath != "")
                                {
                                    string NewPath = folderBrowserDialog1.SelectedPath;

                                    string FullPath = dataGridView1.CurrentRow.Cells["FilePath"].Value.ToString();

                                    if (Pro_FileKind == 40)
                                    {
                                        SaveFileDir = string.Format(@"{0}\{1}", dll.CustomerFolderRoot, FullPath);
                                    }
                                    else if (Pro_FileKind == 50)
                                    {
                                        SaveFileDir = string.Format(@"{0}\{1}", dll.FirmFolderRoot, FullPath);
                                    }
                                    

                                    if (File.Exists(SaveFileDir))
                                    {
                                        try
                                        {
                                            FileInfo file = new FileInfo(SaveFileDir);
                                            File.Copy(SaveFileDir, NewPath + "\\" + file.Name);
                                        }
                                        catch (System.Exception EX)
                                        {
                                            MessageBox.Show(EX.Message);
                                            return;
                                        }
                                        MessageBox.Show("另存檔案成功", "提示訊息");
                                    }

                                }
                            }
                        }
                    }
                    break;
            }
        }
    }
}
