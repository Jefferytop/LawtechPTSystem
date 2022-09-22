using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm
{
    public partial class AddSubject : Form
    {
        public AddSubject()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_SubjectName.Text != "")
            {
                Public.CSubject add = new LawtechPTSystemByFirm.Public.CSubject("1=0");
                add.SubjectName = txt_SubjectName.Text;
                add.SubjectNameCHS = txt_SubjectNameCHS.Text;
                add.SubjectNameEN = txt_SubjectNameEN.Text;
                add.sort =Convert.ToInt32 (numericUpDown_sort.Value);
                Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
                add.SetDataTable(Forms.SubjectMF.dt_Subject);
                add.Insert();
                add.GetDataTable().AcceptChanges();
                MessageBox.Show("新增成功");
                this.Close();
            }
            else
            {
                MessageBox.Show("請輸入主題名稱");
                txt_SubjectName.Focus();
            }
        }

        public void sortNumber()
        {
            string sSQL = @"select Max(sort)+1 from  SubjectT";
            Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();

            object obj = dll.SQLexecuteScalar(sSQL);
           if (obj .ToString()!="")
           {
               numericUpDown_sort.Value = decimal.Parse(obj.ToString());
           }
        }

        private void AddSubject_Load(object sender, EventArgs e)
        {
            sortNumber();
        }

        private void AddSubject_KeyDown(object sender, KeyEventArgs e)
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