using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystem.AddFrom
{
    public partial class AddNotifyDue : Form
    {

        int sort = 1;
        public int Sort
        {
            get { return sort; }
            set { sort = value; }
        }

        private string sCountry = "";
        /// <summary>
        /// 國別
        /// </summary>
        public string Country
        {
            get { return sCountry; }
            set { sCountry = value; }
        }

        private string sCountryName = "";
        /// <summary>
        /// 國別名稱
        /// </summary>
        public string CountryName
        {
            get { return sCountryName; }
            set { sCountryName = value; }
        }

        public AddNotifyDue()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_Content.Text.Trim() != "")
            {
                Public.CPatNotifyDue due = new Public.CPatNotifyDue("1=0");
                due.Sort = int.Parse(numericUpDown1.Value.ToString());
                due.NotifyContent = txt_Content.Text;
                due.Status = comboBox_Status.Text == "" ? -1 : (int)comboBox_Status.SelectedValue;
                due.Country = sCountry;
                due.Note = txt_Note.Text;
                due.Answer = txt_Answer.Text;
                due.ProcessKEY = comboBox_ProcessKEY.SelectedValue != null ? (int)comboBox_ProcessKEY.SelectedValue : -1;
                due.AnswerTime = int.Parse(numericUpDown_AnswerTime.Value.ToString());
                due.TimeUnit = (int)comboBox_TimeUnit.SelectedValue;
                due.StartDate = (int)comboBox_StartDate.SelectedValue;
                due.ASday = int.Parse(numericUpDown_ASday.Value.ToString());
                due.FeePhase = (int)comboBox_FeePhase.SelectedValue;
                due.Insert();

                Public.PublicForm Forms = new Public.PublicForm();

                DataRow dr = Forms.PATNotifyDueMF.GetPatNotifyDue.NewRow();
                dr["PatNotifyDueID"] = due.PatNotifyDueID;
                dr["Sort"] = due.Sort;
                dr["NotifyContent"] = due.NotifyContent;
                dr["Note"] = due.Note;
                dr["ProcessKEY"] = due.ProcessKEY;
                dr["Answer"] = due.Answer;
                dr["AnswerTime"] = due.AnswerTime;
                dr["TimeUnit"] = due.TimeUnit;
                dr["StartDate"] = due.StartDate;
                dr["ASday"] = due.ASday;
                dr["Country"] = due.Country;
                dr["Status"] = due.Status;
                dr["FeePhase"] = due.FeePhase;
                Forms.PATNotifyDueMF.GetPatNotifyDue.Rows.Add(dr);

                MessageBox.Show("新增成功");

                this.Close();

            }
            else
            {
                MessageBox.Show("請輸入期限來函內容!!");
            }
        }

        private void AddNotifyDue_Load(object sender, EventArgs e)
        {
            
            this.processKindT_DropTableAdapter.Fill(this.qS_DataSet._ProcessKindT_Drop); 
            this.patStartDate_DropTableAdapter.Fill(this.qS_DataSet.PatStartDate_Drop);
            this.timeUnit_DropTableAdapter.Fill(this.qS_DataSet.TimeUnit_Drop);
            this.feePhaseTbyPat_DropTableAdapter.Fill(this.qS_DataSet.FeePhaseTbyPat_Drop);
            this.patStatusT_DropTableAdapter.Fill(this.qS_DataSet._PatStatusT_Drop);

            numericUpDown1.Value = Public.Utility.GetMaxSort("PatNotifyDueT");

            lab_CountryName.Text = CountryName;

        }
    }
}