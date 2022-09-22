using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace LawtechPTSystem.AddFrom
{
    public partial class UpFileParagraph : Form
    {
        public UpFileParagraph()
        {
            InitializeComponent();
        }

        #region 自訂變數
        internal int iParaDetailKEY;
        int iParaID;
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                Public.DLL dll = new Public.DLL();
                string sPath = dll.FileServerPath();//FileServer的路徑
                string sFilePath = "";
                FileInfo file = new FileInfo(textBox2.Text);
                string sDir = dll.SQLexecuteScalar(@"SELECT   PetitionSubjectT.PID
                                          FROM  ParagraphT INNER JOIN
                                          PetitionSubjectT ON ParagraphT.PSID = PetitionSubjectT.PSID
                                          where ParaID=" + iParaID).ToString();

                dll.CreatFolder(1, sDir);

                sFilePath = string.Format(@"general\BasedOn\{0}\{1}", sDir, file.Name.Replace(file.Extension, "") + "_" + dll.GetRandom() + file.Extension);

                File.Copy(textBox2.Text, sPath + "OfficeData\\" + sFilePath);

                Public.CParagraphDetail ParaDetail = new Public.CParagraphDetail("ParaDetailKEY=" + iParaDetailKEY.ToString());
                ParaDetail.SetCurrent(iParaDetailKEY);

                if (File.Exists(ParaDetail.UpFilePath))
                {
                    File.Delete(ParaDetail.UpFilePath);
                }                
                Public.PublicForm Forms = new Public.PublicForm();
                Forms.ParagraphDetailMF.dataGridView1.CurrentRow.Cells["UpFilePath"].Value = sFilePath;
                Forms.ParagraphDetailMF.dataGridView1.CurrentRow.Cells["detail"].Value = txt_detail.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show("請選擇要上傳的檔案");
                textBox2.Focus();
            }
        }

        private void UpFileParagraph_Load(object sender, EventArgs e)
        {
            Public.CParagraphDetail ParaDetail = new Public.CParagraphDetail("ParaDetailKEY=" + iParaDetailKEY.ToString());
            ParaDetail.SetCurrent(iParaDetailKEY);
            txt_detail.Text = ParaDetail.detail;
            if (ParaDetail.UpFilePath != "")
            {
                label3.Text = "已有上傳檔案，若需再上傳，將會覆蓋原先的檔案";
            }
            else
            {
                label3.Text = "目前無上傳檔案";
            }
          iParaID=  ParaDetail.ParaID;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox2.Text = openFileDialog1.FileName;

            }
        }
    }
}