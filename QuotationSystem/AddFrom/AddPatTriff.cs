using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystem.AddFrom
{
    public partial class AddPatTriff : Form
    {
        public AddPatTriff()
        {
            InitializeComponent();
        }

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void but_OK_Click(object sender, EventArgs e)
        {
            if (numericUpDown5.Value >= numericUpDown4.Value)
            {
                Public.PublicForm Forms = new Public.PublicForm();

                SubFrom.Triff_PAT TriffM = Forms.Triff_PAT;
                Public.CPatTriff triff = new Public.CPatTriff();

                triff.Country = comboBox1.SelectedValue.ToString();
                triff.Kind = comboBox2.SelectedValue.ToString();
                triff.StaYear = numericUpDown4.Value;
                triff.EndYear = numericUpDown5.Value;
                triff.AttorneyGovFee = numericUpDown1.Value;
                triff.MeFee = numericUpDown2.Value;
                triff.Totall = numericUpDown3.Value;
                triff.Remark = txt_Remark.Text;
                triff.Describe = textBox1.Text;
                triff.Creator = Properties.Settings.Default.WorkerName;
                triff.Create();
                TriffM.upDataSet();
                MessageBox.Show("新增成功");
                this.Close();
            }
            else
            {
                MessageBox.Show("起年必須大於等於迄年");
            }

        }

        private void AddPatTriff_Load(object sender, EventArgs e)
        {
           
            this.kindforPatTableAdapter.FillbyPatKind(this.qS_DataSet.KindforPat);            
            
            this.countryTTableAdapter.Fill(this.qS_DataSet.CountryT);

            Public.PublicForm Forms = new Public.PublicForm();
            SubFrom.Triff_PAT triff = Forms.Triff_PAT;
            comboBox1.SelectedValue = triff.comboBox_Country.SelectedValue;
            comboBox2.SelectedValue = triff.comboBox_Kind.SelectedValue;
            textBox1.Text = "第1年年費";
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown3.Value = numericUpDown1.Value + numericUpDown2.Value;
        }
    }
}