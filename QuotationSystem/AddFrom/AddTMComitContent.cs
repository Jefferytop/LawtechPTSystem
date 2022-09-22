using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystem.AddFrom
{
    public partial class AddTMComitContent : Form
    {
        public AddTMComitContent()
        {
            InitializeComponent();
        }

        string strCountry = "";
        /// <summary>
        /// 國別
        /// </summary>
        public string property_Country
        {
            get
            {
                return strCountry;
            }
            set
            {
                strCountry = value;
            }
        }

        private void AddTMComitContent_Load(object sender, EventArgs e)
        {
            
            this.processKindT_DropTableAdapter.Fill(this.qS_DataSet._ProcessKindT_Drop);
            this.tMStatusTTableAdapter.Fill(this.dataSet_Drop.TMStatusT);
           
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            if (txtComitContent.Text != "")
            {
                Public.CTMComitContent comit = new Public.CTMComitContent("1=0");
                comit.CountrySymbol = strCountry;
                comit.ComitContent = txtComitContent.Text;
                comit.Sort = int.Parse(numericUpDown_Sort.Value.ToString());
                comit.Status = (int)comboBox_patStatus.SelectedValue;
                comit.ProcessKEY = (int)comboBox_processKind.SelectedValue;
                comit.Insert();

                Public.PublicForm Forms = new Public.PublicForm();

                DataTable dt = Forms.TMComitContentMF.GetTMComitContentT;

                DataRow dr = dt.NewRow();
                dr["Sort"] = comit.Sort;
                dr["Status"] = comit.Status;
                dr["CountrySymbol"] = comit.CountrySymbol;
                dr["ComitContent"] = comit.ComitContent;
                dr["ProcessKEY"] = comit.ProcessKEY;
                dr["TMComitContentID"] = comit.TMComitContentID;
                dt.Rows.Add(dr);
                dt.AcceptChanges();

                MessageBox.Show("新增成功", "提示訊息", MessageBoxButtons.OK);
                this.Close();
            }
            else
            {
                MessageBox.Show("委辦內容不得為空白，請輸入委辦內容");
                return;
            }
        }

        private void AddTMComitContent_KeyDown(object sender, KeyEventArgs e)
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
