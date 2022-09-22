using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystem.AddFrom
{
    public partial class AddPatFeature : Form
    {
        public AddPatFeature()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_FeatureName.Text != "")
            {
                Public.CPATFeature feature = new Public.CPATFeature();
                feature.bStop = true;
                feature.FeatureName = txt_FeatureName.Text;
                feature.Sort = int.Parse(numericUpDown_Sort.Value.ToString());
                feature.Create();

                Public.PublicForm Forms = new Public.PublicForm();

                DataTable dt = Forms.PATFeatureMF.GetPATFeatureT;

                DataRow dr = dt.NewRow();
                dr["Sort"] = feature.Sort;
                dr["FeatureID"] = feature.FeatureID;
                dr["FeatureName"] = feature.FeatureName;
                dr["bStop"] = feature.bStop;
                dt.Rows.Add(dr);
                dt.AcceptChanges();

                MessageBox.Show("新增成功");
                this.Close();
            }
            else
            {
                MessageBox.Show("案件性質不得為空白，請輸入案件性質");
                return;
            }
        }

        private void AddPatFeature_Load(object sender, EventArgs e)
        {
            numericUpDown_Sort.Value = Public.Utility.GetMaxSort("PATFeatureT");
        }

        private void AddPatFeature_KeyDown(object sender, KeyEventArgs e)
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