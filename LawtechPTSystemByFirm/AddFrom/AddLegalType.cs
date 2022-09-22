using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.AddFrom
{
    public partial class AddLegalType : Form
    {
        public AddLegalType()
        {
            InitializeComponent();
        }

        private void but_OK_Click(object sender, EventArgs e)
        {
            if (txt_Status.Text != "")
            {
                Public.CLegalType status = new LawtechPTSystemByFirm.Public.CLegalType("1=0");

                status.Sort = int.Parse(numericUpDown_SN.Value.ToString());
                status.LegalTypeName = txt_Status.Text;
                status.Insert();

                Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
                DataTable dt = Forms.LegalTypeSet.GetLegalTypeT;
                DataRow dr = dt.NewRow();

                dr["Sort"] = status.Sort;
                dr["LegalTypeName"] = status.LegalTypeName;
                dr["LegalTypeKey"] = status.LegalTypeKey;
                dt.Rows.Add(dr);
                dt.AcceptChanges();

                MessageBox.Show("新增成功");
                this.Close();

            }
            else
            {
                MessageBox.Show("請輸入案件類別");
                return;
            }
        }

        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddLegalType_Load(object sender, EventArgs e)
        {
            srotMax();
        }


        public void srotMax()
        {
            string sSQL = "select Max(Sort)+1 from LegalTypeT " ;
            Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
            object obj = dll.SQLexecuteScalar(sSQL);
            if (obj != null && obj.ToString() != "")
                numericUpDown_SN.Value = decimal.Parse(obj.ToString());
        }

    }
}
