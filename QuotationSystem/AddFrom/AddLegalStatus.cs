using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystem.AddFrom
{
    public partial class AddLegalStatus : Form
    {
        public AddLegalStatus()
        {
            InitializeComponent();
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void but_OK_Click(object sender, EventArgs e)
        {
            if (txt_Status.Text != "")
            {
                Public.CLegalStatus status = new Public.CLegalStatus("1=0");
               
                status.Sort = int.Parse(numericUpDown_SN.Value.ToString());
                status.StatusName = txt_Status.Text;
                status.Insert();

                Public.PublicForm Forms = new Public.PublicForm();
                DataTable dt = Forms.LegalStatusSet.GetLegalStatusT;
                DataRow dr = dt.NewRow();
               
                dr["Sort"] = status.Sort;
                dr["StatusName"] = status.StatusName;
                dr["LegalStatusKey"] = status.LegalStatusKey;
                dt.Rows.Add(dr);
                dt.AcceptChanges();

                MessageBox.Show("新增成功");
                this.Close();

            }
            else
            {
                MessageBox.Show("請輸入案件階段");
                return;
            }
        }

        private void AddLegalStatus_Load(object sender, EventArgs e)
        {
            srotMax();
        }

        public void srotMax()
        {
            string sSQL = "select Max(Sort)+1 from LegalStatusT ";
            Public.DLL dll = new Public.DLL();
            object obj = dll.SQLexecuteScalar(sSQL);
            if (obj != null && obj.ToString() != "")
                numericUpDown_SN.Value = decimal.Parse(obj.ToString());
        }
    }
}
