using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystem.AddFrom
{
    public partial class AddComitContent : Form
    {
        public AddComitContent()
        {
            InitializeComponent();
        }

        string strCountry = "";
        /// <summary>
        /// 國別
        /// </summary>
        public string property_Country
        {
            get {
                return strCountry;
            }
            set {
                strCountry = value;
            }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddComitContent_Load(object sender, EventArgs e)
        {
            this.patStatusT_DropTableAdapter.Fill(this.qS_DataSet._PatStatusT_Drop);
            this.processKindT_DropTableAdapter.Fill(this.qS_DataSet._ProcessKindT_Drop);

            numericUpDown_Sort.Value = Public.Utility.GetMaxSort("PatComitContentT");


        }

        private void butOK_Click(object sender, EventArgs e)
        {
            if (txtComitContent.Text != "")
            {
                Public.CPatComitContent comit = new Public.CPatComitContent();
                comit.CountrySymbol = strCountry;
                comit.ComitContent = txtComitContent.Text;
                comit.Sort=int.Parse(numericUpDown_Sort.Value.ToString());
                comit.Status = (int)comboBox_patStatus.SelectedValue;
                comit.ProcessKEY = (int)comboBox_processKind.SelectedValue;
                comit.Create();

                Public.PublicForm Forms = new Public.PublicForm();

                DataTable dt = Forms.ComitContentTMF.GetPatComitContent;

                DataRow dr = dt.NewRow();
                dr["Sort"] = comit.Sort;
                dr["Status"] = comit.Status;
                dr["CountrySymbol"] = comit.CountrySymbol;
                dr["ComitContent"] = comit.ComitContent;
                dr["ProcessKEY"] = comit.ProcessKEY;
                dr["ComitContentID"] = comit.ComitContentID;
                dt.Rows.Add(dr);
                dt.AcceptChanges();

                MessageBox.Show("新增成功","提示訊息",MessageBoxButtons.OK);
                this.Close();
            }
            else
            {
                MessageBox.Show("事件內容不得為空白，請輸入事件內容");
                return;
            }
        }

        private void AddComitContent_KeyDown(object sender, KeyEventArgs e)
        {
            Public.Utility.ControlTab(e);
        }
    }
}