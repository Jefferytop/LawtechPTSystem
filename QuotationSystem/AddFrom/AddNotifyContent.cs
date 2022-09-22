using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystem.AddFrom
{
    public partial class AddNotifyContent : Form
    {
        public AddNotifyContent()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddNotifyContent_Load(object sender, EventArgs e)
        {
            this.patStatusT_DropTableAdapter.Fill(this.qS_DataSet._PatStatusT_Drop);
            this.countryTTableAdapter.Fill(this.qS_DataSet.CountryT);

            Public.PublicForm Forms = new Public.PublicForm();
           comboBox_country.SelectedValue= Forms.PATNotifyContentMF.proCountry;

           numericUpDown_sort.Value = Public.Utility.GetMaxSort("PatNotifyContentT");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_Content.Text != "")
            {
                Public.CPatNotifyContent NotifyContent = new Public.CPatNotifyContent("1=0");
                NotifyContent.NotifyContent = txt_Content.Text;
                NotifyContent.Sort = int.Parse(numericUpDown_sort.Value.ToString());
                NotifyContent.Status = (int)comboBox_Status.SelectedValue;
                NotifyContent.Note = txt_Note.Text;
                NotifyContent.Country = comboBox_country.SelectedValue.ToString();
                NotifyContent.Insert();

                Public.PublicForm Forms = new Public.PublicForm();

                DataTable dt = Forms.PATNotifyContentMF.GetPatNotifyContent;

                DataRow dr = dt.NewRow();
                dr["Sort"] = NotifyContent.Sort;
                dr["Status"] = NotifyContent.Status;
                dr["NotifyContent"] = NotifyContent.NotifyContent;
                dr["Note"] = NotifyContent.Note;
                dr["CountrySymbol"] = NotifyContent.Country;
                dr["NotifyContentID"] = NotifyContent.NotifyContentID;
                dt.Rows.Add(dr);
                dt.AcceptChanges();

                MessageBox.Show("新增成功");
                this.Close();
            }
            else
            {
                MessageBox.Show("委辦內容不得為空白，請輸入委辦內容");
                return;
            }
        }

        private void AddNotifyContent_KeyDown(object sender, KeyEventArgs e)
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