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
    public partial class AddParagraphDetail : Form
    {
        public AddParagraphDetail()
        {
            InitializeComponent();
        }

        #region 自訂變數
        internal int iParaID;
        #endregion 

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Public .DLL dll=new Public.DLL();
                string sPath=dll.FileServerPath();//FileServer的路徑
                string sFilePath="";
                if (txt_FilePath.Text != "")
                {
                    FileInfo file = new FileInfo(txt_FilePath.Text);
                    string sDir = dll.SQLexecuteScalar(@"SELECT   PetitionSubjectT.PID
                                          FROM  ParagraphT INNER JOIN
                                          PetitionSubjectT ON ParagraphT.PSID = PetitionSubjectT.PSID
                                          where ParaID=" + iParaID).ToString();

                    dll.CreatFolder(1, sDir);

                    sFilePath = string.Format(@"general\BasedOn\{0}\{1}", sDir, file.Name.Replace(file.Extension,"") + "_" + dll.GetRandom() + file.Extension);

                    File.Copy(txt_FilePath.Text, sPath +"OfficeData\\"+ sFilePath);
                }

                Public.CParagraphDetail detail = new Public.CParagraphDetail("1=0");
                detail.EditDate = DateTime.Now;
                detail.EditWorker = Properties.Settings.Default.WorkerKEY;
                detail.detail = textBox1.Text;
                detail.ParaID = iParaID;
                detail.sort = int.Parse(numericUpDown1.Value.ToString());

                detail.UpFilePath = sFilePath;
                Public.PublicForm Forms = new Public.PublicForm();
                detail.SetDataTable(Forms.ParagraphDetailMF.ParagraphDetailT);
                detail.Insert();
                MessageBox.Show("新增成功");
                this.Close();
            }
        }

        private void AddParagraphDetail_Load(object sender, EventArgs e)
        {
            srotMax();
        }

        public void srotMax()
        {
            string sSQL = "select Max(sort)+1 from ParagraphDetailT where ParaID=" + iParaID;
            Public.DLL dll = new Public.DLL();
           object obj=  dll.SQLexecuteScalar(sSQL);
           if (obj != DBNull.Value && obj.ToString()!="")
               numericUpDown1.Value = decimal.Parse(obj.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txt_FilePath.Text= openFileDialog1.FileName;

            }
        }

        private void AddParagraphDetail_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    SendKeys.Send("{TAB}");
                    break;
                case Keys.PageDown:
                    SendKeys.Send("{TAB}");
                    break;
                case Keys.PageUp:
                    SendKeys.Send("+{TAB}");
                    break;
            }
        }

    }
}